using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.SpatialTracking;
using UnityEngine.UI;
using UnityEngine.XR;
using Valve.Newtonsoft.Json;
using Valve.VR;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
[ExecuteInEditMode]
public class URPMaterialSwitcher : MonoBehaviour
{
	public bool children;
}
public static class SteamVR_Utils
{
	public class Event
	{
		public delegate void Handler(params object[] args);

		private static Hashtable listeners = new Hashtable();

		public static void Listen(string message, Handler action)
		{
			if (listeners[message] is Handler a)
			{
				listeners[message] = (Handler)Delegate.Combine(a, action);
			}
			else
			{
				listeners[message] = action;
			}
		}

		public static void Remove(string message, Handler action)
		{
			if (listeners[message] is Handler source)
			{
				listeners[message] = (Handler)Delegate.Remove(source, action);
			}
		}

		public static void Send(string message, params object[] args)
		{
			if (listeners[message] is Handler handler)
			{
				handler(args);
			}
		}
	}

	[Serializable]
	public struct RigidTransform
	{
		public Vector3 pos;

		public Quaternion rot;

		public static RigidTransform identity => new RigidTransform(Vector3.zero, Quaternion.identity);

		public static RigidTransform FromLocal(Transform t)
		{
			return new RigidTransform(t.localPosition, t.localRotation);
		}

		public RigidTransform(Vector3 pos, Quaternion rot)
		{
			this.pos = pos;
			this.rot = rot;
		}

		public RigidTransform(Transform t)
		{
			pos = t.position;
			rot = t.rotation;
		}

		public RigidTransform(Transform from, Transform to)
		{
			Quaternion quaternion = Quaternion.Inverse(from.rotation);
			rot = quaternion * to.rotation;
			pos = quaternion * (to.position - from.position);
		}

		public RigidTransform(HmdMatrix34_t pose)
		{
			Matrix4x4 matrix = Matrix4x4.identity;
			matrix[0, 0] = pose.m0;
			matrix[0, 1] = pose.m1;
			matrix[0, 2] = 0f - pose.m2;
			matrix[0, 3] = pose.m3;
			matrix[1, 0] = pose.m4;
			matrix[1, 1] = pose.m5;
			matrix[1, 2] = 0f - pose.m6;
			matrix[1, 3] = pose.m7;
			matrix[2, 0] = 0f - pose.m8;
			matrix[2, 1] = 0f - pose.m9;
			matrix[2, 2] = pose.m10;
			matrix[2, 3] = 0f - pose.m11;
			pos = matrix.GetPosition();
			rot = matrix.GetRotation();
		}

		public RigidTransform(HmdMatrix44_t pose)
		{
			Matrix4x4 matrix = Matrix4x4.identity;
			matrix[0, 0] = pose.m0;
			matrix[0, 1] = pose.m1;
			matrix[0, 2] = 0f - pose.m2;
			matrix[0, 3] = pose.m3;
			matrix[1, 0] = pose.m4;
			matrix[1, 1] = pose.m5;
			matrix[1, 2] = 0f - pose.m6;
			matrix[1, 3] = pose.m7;
			matrix[2, 0] = 0f - pose.m8;
			matrix[2, 1] = 0f - pose.m9;
			matrix[2, 2] = pose.m10;
			matrix[2, 3] = 0f - pose.m11;
			matrix[3, 0] = pose.m12;
			matrix[3, 1] = pose.m13;
			matrix[3, 2] = 0f - pose.m14;
			matrix[3, 3] = pose.m15;
			pos = matrix.GetPosition();
			rot = matrix.GetRotation();
		}

		public HmdMatrix44_t ToHmdMatrix44()
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(pos, rot, Vector3.one);
			return new HmdMatrix44_t
			{
				m0 = matrix4x[0, 0],
				m1 = matrix4x[0, 1],
				m2 = 0f - matrix4x[0, 2],
				m3 = matrix4x[0, 3],
				m4 = matrix4x[1, 0],
				m5 = matrix4x[1, 1],
				m6 = 0f - matrix4x[1, 2],
				m7 = matrix4x[1, 3],
				m8 = 0f - matrix4x[2, 0],
				m9 = 0f - matrix4x[2, 1],
				m10 = matrix4x[2, 2],
				m11 = 0f - matrix4x[2, 3],
				m12 = matrix4x[3, 0],
				m13 = matrix4x[3, 1],
				m14 = 0f - matrix4x[3, 2],
				m15 = matrix4x[3, 3]
			};
		}

		public HmdMatrix34_t ToHmdMatrix34()
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(pos, rot, Vector3.one);
			return new HmdMatrix34_t
			{
				m0 = matrix4x[0, 0],
				m1 = matrix4x[0, 1],
				m2 = 0f - matrix4x[0, 2],
				m3 = matrix4x[0, 3],
				m4 = matrix4x[1, 0],
				m5 = matrix4x[1, 1],
				m6 = 0f - matrix4x[1, 2],
				m7 = matrix4x[1, 3],
				m8 = 0f - matrix4x[2, 0],
				m9 = 0f - matrix4x[2, 1],
				m10 = matrix4x[2, 2],
				m11 = 0f - matrix4x[2, 3]
			};
		}

		public override bool Equals(object o)
		{
			if (o is RigidTransform rigidTransform)
			{
				if (pos == rigidTransform.pos)
				{
					return rot == rigidTransform.rot;
				}
				return false;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return pos.GetHashCode() ^ rot.GetHashCode();
		}

		public static bool operator ==(RigidTransform a, RigidTransform b)
		{
			if (a.pos == b.pos)
			{
				return a.rot == b.rot;
			}
			return false;
		}

		public static bool operator !=(RigidTransform a, RigidTransform b)
		{
			if (!(a.pos != b.pos))
			{
				return a.rot != b.rot;
			}
			return true;
		}

		public static RigidTransform operator *(RigidTransform a, RigidTransform b)
		{
			return new RigidTransform
			{
				rot = a.rot * b.rot,
				pos = a.pos + a.rot * b.pos
			};
		}

		public void Inverse()
		{
			rot = Quaternion.Inverse(rot);
			pos = -(rot * pos);
		}

		public RigidTransform GetInverse()
		{
			RigidTransform result = new RigidTransform(pos, rot);
			result.Inverse();
			return result;
		}

		public void Multiply(RigidTransform a, RigidTransform b)
		{
			rot = a.rot * b.rot;
			pos = a.pos + a.rot * b.pos;
		}

		public Vector3 InverseTransformPoint(Vector3 point)
		{
			return Quaternion.Inverse(rot) * (point - pos);
		}

		public Vector3 TransformPoint(Vector3 point)
		{
			return pos + rot * point;
		}

		public static Vector3 operator *(RigidTransform t, Vector3 v)
		{
			return t.TransformPoint(v);
		}

		public static RigidTransform Interpolate(RigidTransform a, RigidTransform b, float t)
		{
			return new RigidTransform(Vector3.Lerp(a.pos, b.pos, t), Quaternion.Slerp(a.rot, b.rot, t));
		}

		public void Interpolate(RigidTransform to, float t)
		{
			pos = Lerp(pos, to.pos, t);
			rot = Slerp(rot, to.rot, t);
		}
	}

	public delegate object SystemFn(CVRSystem system, params object[] args);

	private const string secretKey = "foobar";

	public static bool IsValid(Vector3 vector)
	{
		if (!float.IsNaN(vector.x) && !float.IsNaN(vector.y))
		{
			return !float.IsNaN(vector.z);
		}
		return false;
	}

	public static bool IsValid(Quaternion rotation)
	{
		if (!float.IsNaN(rotation.x) && !float.IsNaN(rotation.y) && !float.IsNaN(rotation.z) && !float.IsNaN(rotation.w))
		{
			if (rotation.x == 0f && rotation.y == 0f && rotation.z == 0f)
			{
				return rotation.w != 0f;
			}
			return true;
		}
		return false;
	}

	public static Quaternion Slerp(Quaternion A, Quaternion B, float t)
	{
		float num = Mathf.Clamp(A.x * B.x + A.y * B.y + A.z * B.z + A.w * B.w, -1f, 1f);
		if (num < 0f)
		{
			B = new Quaternion(0f - B.x, 0f - B.y, 0f - B.z, 0f - B.w);
			num = 0f - num;
		}
		float num4;
		float num5;
		if (1f - num > 0.0001f)
		{
			float num2 = Mathf.Acos(num);
			float num3 = Mathf.Sin(num2);
			num4 = Mathf.Sin((1f - t) * num2) / num3;
			num5 = Mathf.Sin(t * num2) / num3;
		}
		else
		{
			num4 = 1f - t;
			num5 = t;
		}
		return new Quaternion(num4 * A.x + num5 * B.x, num4 * A.y + num5 * B.y, num4 * A.z + num5 * B.z, num4 * A.w + num5 * B.w);
	}

	public static Vector3 Lerp(Vector3 A, Vector3 B, float t)
	{
		return new Vector3(Lerp(A.x, B.x, t), Lerp(A.y, B.y, t), Lerp(A.z, B.z, t));
	}

	public static float Lerp(float A, float B, float t)
	{
		return A + (B - A) * t;
	}

	public static double Lerp(double A, double B, double t)
	{
		return A + (B - A) * t;
	}

	public static float InverseLerp(Vector3 A, Vector3 B, Vector3 result)
	{
		return Vector3.Dot(result - A, B - A);
	}

	public static float InverseLerp(float A, float B, float result)
	{
		return (result - A) / (B - A);
	}

	public static double InverseLerp(double A, double B, double result)
	{
		return (result - A) / (B - A);
	}

	public static float Saturate(float A)
	{
		if (!(A < 0f))
		{
			if (!(A > 1f))
			{
				return A;
			}
			return 1f;
		}
		return 0f;
	}

	public static Vector2 Saturate(Vector2 A)
	{
		return new Vector2(Saturate(A.x), Saturate(A.y));
	}

	public static float Abs(float A)
	{
		if (!(A < 0f))
		{
			return A;
		}
		return 0f - A;
	}

	public static Vector2 Abs(Vector2 A)
	{
		return new Vector2(Abs(A.x), Abs(A.y));
	}

	private static float _copysign(float sizeval, float signval)
	{
		if (Mathf.Sign(signval) != 1f)
		{
			return 0f - Mathf.Abs(sizeval);
		}
		return Mathf.Abs(sizeval);
	}

	public static Quaternion GetRotation(this Matrix4x4 matrix)
	{
		Quaternion result = default(Quaternion);
		result.w = Mathf.Sqrt(Mathf.Max(0f, 1f + matrix.m00 + matrix.m11 + matrix.m22)) / 2f;
		result.x = Mathf.Sqrt(Mathf.Max(0f, 1f + matrix.m00 - matrix.m11 - matrix.m22)) / 2f;
		result.y = Mathf.Sqrt(Mathf.Max(0f, 1f - matrix.m00 + matrix.m11 - matrix.m22)) / 2f;
		result.z = Mathf.Sqrt(Mathf.Max(0f, 1f - matrix.m00 - matrix.m11 + matrix.m22)) / 2f;
		result.x = Mathf.Sign(result.x) * Mathf.Abs(matrix.m21 - matrix.m12);
		result.y = Mathf.Sign(result.y) * Mathf.Abs(matrix.m02 - matrix.m20);
		result.z = Mathf.Sign(result.z) * Mathf.Abs(matrix.m10 - matrix.m01);
		return result;
	}

	public static Vector3 GetPosition(this Matrix4x4 matrix)
	{
		float m = matrix.m03;
		float m2 = matrix.m13;
		float m3 = matrix.m23;
		return new Vector3(m, m2, m3);
	}

	public static Vector3 GetScale(this Matrix4x4 m)
	{
		float x = Mathf.Sqrt(m.m00 * m.m00 + m.m01 * m.m01 + m.m02 * m.m02);
		float y = Mathf.Sqrt(m.m10 * m.m10 + m.m11 * m.m11 + m.m12 * m.m12);
		float z = Mathf.Sqrt(m.m20 * m.m20 + m.m21 * m.m21 + m.m22 * m.m22);
		return new Vector3(x, y, z);
	}

	public static float GetLossyScale(Transform t)
	{
		return t.lossyScale.x;
	}

	public static string GetBadMD5Hash(string usedString)
	{
		return GetBadMD5Hash(Encoding.UTF8.GetBytes(usedString + "foobar"));
	}

	public static string GetBadMD5Hash(byte[] bytes)
	{
		byte[] array = new MD5CryptoServiceProvider().ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("x2"));
		}
		return stringBuilder.ToString();
	}

	public static string GetBadMD5HashFromFile(string filePath)
	{
		if (!File.Exists(filePath))
		{
			return null;
		}
		return GetBadMD5Hash(File.ReadAllText(filePath) + "foobar");
	}

	public static string SanitizePath(string path, bool allowLeadingSlash = true)
	{
		if (path.Contains("\\\\"))
		{
			path = path.Replace("\\\\", "\\");
		}
		if (path.Contains("//"))
		{
			path = path.Replace("//", "/");
		}
		if (!allowLeadingSlash && (path[0] == '/' || path[0] == '\\'))
		{
			path = path.Substring(1);
		}
		return path;
	}

	public static Type FindType(string typeName)
	{
		Type type = Type.GetType(typeName);
		if (type != null)
		{
			return type;
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			type = assemblies[i].GetType(typeName);
			if (type != null)
			{
				return type;
			}
		}
		return null;
	}

	public static object CallSystemFn(SystemFn fn, params object[] args)
	{
		bool flag = !SteamVR.active && !SteamVR.usingNativeSupport;
		if (flag)
		{
			EVRInitError peError = EVRInitError.None;
			OpenVR.Init(ref peError, EVRApplicationType.VRApplication_Utility);
		}
		CVRSystem system = OpenVR.System;
		object result = ((system != null) ? fn(system, args) : null);
		if (flag)
		{
			OpenVR.Shutdown();
		}
		return result;
	}

	public static void TakeStereoScreenshot(uint screenshotHandle, GameObject target, int cellSize, float ipd, ref string previewFilename, ref string VRFilename)
	{
		Texture2D texture2D = new Texture2D(4096, 4096, TextureFormat.ARGB32, mipChain: false);
		Stopwatch stopwatch = new Stopwatch();
		Camera camera = null;
		stopwatch.Start();
		Camera camera2 = target.GetComponent<Camera>();
		if (camera2 == null)
		{
			if (camera == null)
			{
				camera = new GameObject().AddComponent<Camera>();
			}
			camera2 = camera;
		}
		Texture2D texture2D2 = new Texture2D(2048, 2048, TextureFormat.ARGB32, mipChain: false);
		RenderTexture renderTexture = new RenderTexture(2048, 2048, 24);
		RenderTexture targetTexture = camera2.targetTexture;
		bool orthographic = camera2.orthographic;
		float fieldOfView = camera2.fieldOfView;
		float aspect = camera2.aspect;
		StereoTargetEyeMask stereoTargetEye = camera2.stereoTargetEye;
		camera2.stereoTargetEye = StereoTargetEyeMask.None;
		camera2.fieldOfView = 60f;
		camera2.orthographic = false;
		camera2.targetTexture = renderTexture;
		camera2.aspect = 1f;
		camera2.Render();
		RenderTexture.active = renderTexture;
		texture2D2.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
		RenderTexture.active = null;
		camera2.targetTexture = null;
		UnityEngine.Object.DestroyImmediate(renderTexture);
		SteamVR_SphericalProjection steamVR_SphericalProjection = camera2.gameObject.AddComponent<SteamVR_SphericalProjection>();
		Vector3 localPosition = target.transform.localPosition;
		Quaternion localRotation = target.transform.localRotation;
		Vector3 position = target.transform.position;
		Quaternion quaternion = Quaternion.Euler(0f, target.transform.rotation.eulerAngles.y, 0f);
		Transform transform = camera2.transform;
		int num = 1024 / cellSize;
		float num2 = 90f / (float)num;
		float num3 = num2 / 2f;
		RenderTexture renderTexture2 = new RenderTexture(cellSize, cellSize, 24);
		renderTexture2.wrapMode = TextureWrapMode.Clamp;
		renderTexture2.antiAliasing = 8;
		camera2.fieldOfView = num2;
		camera2.orthographic = false;
		camera2.targetTexture = renderTexture2;
		camera2.aspect = aspect;
		camera2.stereoTargetEye = StereoTargetEyeMask.None;
		for (int i = 0; i < num; i++)
		{
			float num4 = 90f - (float)i * num2 - num3;
			int num5 = 4096 / renderTexture2.width;
			float num6 = 360f / (float)num5;
			float num7 = num6 / 2f;
			int num8 = i * 1024 / num;
			for (int j = 0; j < 2; j++)
			{
				if (j == 1)
				{
					num4 = 0f - num4;
					num8 = 2048 - num8 - cellSize;
				}
				for (int k = 0; k < num5; k++)
				{
					float num9 = -180f + (float)k * num6 + num7;
					int destX = k * 4096 / num5;
					int num10 = 0;
					float num11 = (0f - ipd) / 2f * Mathf.Cos(num4 * (MathF.PI / 180f));
					for (int l = 0; l < 2; l++)
					{
						if (l == 1)
						{
							num10 = 2048;
							num11 = 0f - num11;
						}
						Vector3 vector = quaternion * Quaternion.Euler(0f, num9, 0f) * new Vector3(num11, 0f, 0f);
						transform.position = position + vector;
						Quaternion quaternion2 = Quaternion.Euler(num4, num9, 0f);
						transform.rotation = quaternion * quaternion2;
						Vector3 vector2 = quaternion2 * Vector3.forward;
						float num12 = num9 - num6 / 2f;
						float num13 = num12 + num6;
						float num14 = num4 + num2 / 2f;
						float num15 = num14 - num2;
						float y = (num12 + num13) / 2f;
						float x = ((Mathf.Abs(num14) < Mathf.Abs(num15)) ? num14 : num15);
						Vector3 vector3 = Quaternion.Euler(x, num12, 0f) * Vector3.forward;
						Vector3 vector4 = Quaternion.Euler(x, num13, 0f) * Vector3.forward;
						Vector3 vector5 = Quaternion.Euler(num14, y, 0f) * Vector3.forward;
						Vector3 vector6 = Quaternion.Euler(num15, y, 0f) * Vector3.forward;
						Vector3 vector7 = vector3 / Vector3.Dot(vector3, vector2);
						Vector3 vector8 = vector4 / Vector3.Dot(vector4, vector2);
						Vector3 vector9 = vector5 / Vector3.Dot(vector5, vector2);
						Vector3 vector10 = vector6 / Vector3.Dot(vector6, vector2);
						Vector3 vector11 = vector8 - vector7;
						Vector3 vector12 = vector10 - vector9;
						float magnitude = vector11.magnitude;
						float magnitude2 = vector12.magnitude;
						float num16 = 1f / magnitude;
						float num17 = 1f / magnitude2;
						Vector3 uAxis = vector11 * num16;
						Vector3 vAxis = vector12 * num17;
						steamVR_SphericalProjection.Set(vector2, num12, num13, num14, num15, uAxis, vector7, num16, vAxis, vector9, num17);
						camera2.aspect = magnitude / magnitude2;
						camera2.Render();
						RenderTexture.active = renderTexture2;
						texture2D.ReadPixels(new Rect(0f, 0f, renderTexture2.width, renderTexture2.height), destX, num8 + num10);
						RenderTexture.active = null;
					}
					float flProgress = ((float)i * ((float)num5 * 2f) + (float)k + (float)(j * num5)) / ((float)num * ((float)num5 * 2f));
					OpenVR.Screenshots.UpdateScreenshotProgress(screenshotHandle, flProgress);
				}
			}
		}
		OpenVR.Screenshots.UpdateScreenshotProgress(screenshotHandle, 1f);
		previewFilename += ".png";
		VRFilename += ".png";
		texture2D2.Apply();
		File.WriteAllBytes(previewFilename, texture2D2.EncodeToPNG());
		texture2D.Apply();
		File.WriteAllBytes(VRFilename, texture2D.EncodeToPNG());
		if (camera2 != camera)
		{
			camera2.targetTexture = targetTexture;
			camera2.orthographic = orthographic;
			camera2.fieldOfView = fieldOfView;
			camera2.aspect = aspect;
			camera2.stereoTargetEye = stereoTargetEye;
			target.transform.localPosition = localPosition;
			target.transform.localRotation = localRotation;
		}
		else
		{
			camera.targetTexture = null;
		}
		UnityEngine.Object.DestroyImmediate(renderTexture2);
		UnityEngine.Object.DestroyImmediate(steamVR_SphericalProjection);
		stopwatch.Stop();
		UnityEngine.Debug.Log($"Screenshot took {stopwatch.Elapsed} seconds.");
		if (camera != null)
		{
			UnityEngine.Object.DestroyImmediate(camera.gameObject);
		}
		UnityEngine.Object.DestroyImmediate(texture2D2);
		UnityEngine.Object.DestroyImmediate(texture2D);
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
			FilePathsData = new byte[11552]
			{
				0, 0, 0, 1, 0, 0, 0, 46, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 69, 120, 116, 114, 97, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 67,
				97, 109, 101, 114, 97, 72, 101, 108, 112, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 50, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 69, 120,
				116, 114, 97, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 70, 111, 114, 99, 101, 83, 116,
				101, 97, 109, 86, 82, 77, 111, 100, 101, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 45,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 69, 120, 116, 114,
				97, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 71, 97, 122, 101, 84, 114, 97, 99, 107,
				101, 114, 46, 99, 115, 0, 0, 0, 2, 0,
				0, 0, 46, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 69,
				120, 116, 114, 97, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 76, 97, 115, 101, 114, 80,
				111, 105, 110, 116, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 43, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 69, 120, 116, 114, 97, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 84, 101,
				115, 116, 84, 104, 114, 111, 119, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 51, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 69, 120, 116, 114, 97, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 84,
				101, 115, 116, 84, 114, 97, 99, 107, 101, 100,
				67, 97, 109, 101, 114, 97, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 76, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 112, 117, 116, 92, 66,
				101, 104, 97, 118, 105, 111, 117, 114, 85, 110,
				105, 116, 121, 69, 118, 101, 110, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 66, 101,
				104, 97, 118, 105, 111, 117, 114, 95, 66, 111,
				111, 108, 101, 97, 110, 69, 118, 101, 110, 116,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				73, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 112,
				117, 116, 92, 66, 101, 104, 97, 118, 105, 111,
				117, 114, 85, 110, 105, 116, 121, 69, 118, 101,
				110, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 95, 80, 111, 115, 101, 69, 118, 101, 110,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 90, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				112, 117, 116, 92, 66, 101, 104, 97, 118, 105,
				111, 117, 114, 85, 110, 105, 116, 121, 69, 118,
				101, 110, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 66, 101, 104, 97, 118, 105, 111,
				117, 114, 95, 80, 111, 115, 101, 95, 67, 111,
				110, 110, 101, 99, 116, 101, 100, 67, 104, 97,
				110, 103, 101, 100, 69, 118, 101, 110, 116, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 92,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 85, 110, 105, 116, 121, 69, 118, 101, 110,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 66, 101, 104, 97, 118, 105, 111, 117, 114,
				95, 80, 111, 115, 101, 95, 68, 101, 118, 105,
				99, 101, 73, 110, 100, 101, 120, 67, 104, 97,
				110, 103, 101, 100, 69, 118, 101, 110, 116, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 89,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 85, 110, 105, 116, 121, 69, 118, 101, 110,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 66, 101, 104, 97, 118, 105, 111, 117, 114,
				95, 80, 111, 115, 101, 95, 84, 114, 97, 99,
				107, 105, 110, 103, 67, 104, 97, 110, 103, 101,
				100, 69, 118, 101, 110, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 75, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 112, 117, 116, 92, 66,
				101, 104, 97, 118, 105, 111, 117, 114, 85, 110,
				105, 116, 121, 69, 118, 101, 110, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 66, 101,
				104, 97, 118, 105, 111, 117, 114, 95, 83, 105,
				110, 103, 108, 101, 69, 118, 101, 110, 116, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 77,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 85, 110, 105, 116, 121, 69, 118, 101, 110,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 66, 101, 104, 97, 118, 105, 111, 117, 114,
				95, 83, 107, 101, 108, 101, 116, 111, 110, 69,
				118, 101, 110, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 94, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 112, 117, 116, 92, 66, 101, 104,
				97, 118, 105, 111, 117, 114, 85, 110, 105, 116,
				121, 69, 118, 101, 110, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 66, 101, 104, 97,
				118, 105, 111, 117, 114, 95, 83, 107, 101, 108,
				101, 116, 111, 110, 95, 67, 111, 110, 110, 101,
				99, 116, 101, 100, 67, 104, 97, 110, 103, 101,
				100, 69, 118, 101, 110, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 93, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 112, 117, 116, 92, 66,
				101, 104, 97, 118, 105, 111, 117, 114, 85, 110,
				105, 116, 121, 69, 118, 101, 110, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 66, 101,
				104, 97, 118, 105, 111, 117, 114, 95, 83, 107,
				101, 108, 101, 116, 111, 110, 95, 84, 114, 97,
				99, 107, 105, 110, 103, 67, 104, 97, 110, 103,
				101, 100, 69, 118, 101, 110, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 76, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 112, 117, 116, 92,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 85,
				110, 105, 116, 121, 69, 118, 101, 110, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 66,
				101, 104, 97, 118, 105, 111, 117, 114, 95, 86,
				101, 99, 116, 111, 114, 50, 69, 118, 101, 110,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 76, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				112, 117, 116, 92, 66, 101, 104, 97, 118, 105,
				111, 117, 114, 85, 110, 105, 116, 121, 69, 118,
				101, 110, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 66, 101, 104, 97, 118, 105, 111,
				117, 114, 95, 86, 101, 99, 116, 111, 114, 51,
				69, 118, 101, 110, 116, 46, 99, 115, 0, 0,
				0, 7, 0, 0, 0, 39, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				111, 110, 46, 99, 115, 0, 0, 0, 3, 0,
				0, 0, 42, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 65, 99, 116, 105, 111, 110, 83,
				101, 116, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 50, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 65, 99, 116, 105, 111, 110, 83,
				101, 116, 95, 77, 97, 110, 97, 103, 101, 114,
				46, 99, 115, 0, 0, 0, 4, 0, 0, 0,
				47, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 112,
				117, 116, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 66, 111,
				111, 108, 101, 97, 110, 46, 99, 115, 0, 0,
				0, 5, 0, 0, 0, 42, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				111, 110, 95, 73, 110, 46, 99, 115, 0, 0,
				0, 4, 0, 0, 0, 43, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				111, 110, 95, 79, 117, 116, 46, 99, 115, 0,
				0, 0, 5, 0, 0, 0, 44, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 112, 117, 116, 92, 83,
				116, 101, 97, 109, 86, 82, 95, 65, 99, 116,
				105, 111, 110, 95, 80, 111, 115, 101, 46, 99,
				115, 0, 0, 0, 4, 0, 0, 0, 46, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 112, 117, 116,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 65,
				99, 116, 105, 111, 110, 95, 83, 105, 110, 103,
				108, 101, 46, 99, 115, 0, 0, 0, 7, 0,
				0, 0, 48, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 65, 99, 116, 105, 111, 110, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 46, 99,
				115, 0, 0, 0, 4, 0, 0, 0, 47, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 112, 117, 116,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 65,
				99, 116, 105, 111, 110, 95, 86, 101, 99, 116,
				111, 114, 50, 46, 99, 115, 0, 0, 0, 4,
				0, 0, 0, 47, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 112, 117, 116, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 65, 99, 116, 105, 111, 110,
				95, 86, 101, 99, 116, 111, 114, 51, 46, 99,
				115, 0, 0, 0, 4, 0, 0, 0, 49, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 112, 117, 116,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 65,
				99, 116, 105, 111, 110, 95, 86, 105, 98, 114,
				97, 116, 105, 111, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 56, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				118, 97, 116, 101, 65, 99, 116, 105, 111, 110,
				83, 101, 116, 79, 110, 76, 111, 97, 100, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 50,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				66, 111, 111, 108, 101, 97, 110, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 47, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 112, 117, 116, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 66, 101,
				104, 97, 118, 105, 111, 117, 114, 95, 80, 111,
				115, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 49, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 66, 101, 104, 97, 118, 105, 111,
				117, 114, 95, 83, 105, 110, 103, 108, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 51,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 57, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 112, 117, 116,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 66,
				101, 104, 97, 118, 105, 111, 117, 114, 95, 83,
				107, 101, 108, 101, 116, 111, 110, 67, 117, 115,
				116, 111, 109, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 50, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 112, 117, 116, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 66, 101, 104, 97, 118, 105,
				111, 117, 114, 95, 86, 101, 99, 116, 111, 114,
				50, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 50, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				112, 117, 116, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 95, 86, 101, 99, 116, 111, 114, 51, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 38,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 83, 116, 101, 97, 109, 86, 82, 95,
				73, 110, 112, 117, 116, 46, 99, 115, 0, 0,
				0, 13, 0, 0, 0, 49, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 73, 110, 112, 117,
				116, 95, 65, 99, 116, 105, 111, 110, 70, 105,
				108, 101, 46, 99, 115, 0, 0, 0, 9, 0,
				0, 0, 50, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 73, 110, 112, 117, 116, 95, 66,
				105, 110, 100, 105, 110, 103, 70, 105, 108, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				54, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 112,
				117, 116, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 73, 110, 112, 117, 116, 95, 71, 101, 110,
				101, 114, 97, 116, 111, 114, 95, 78, 97, 109,
				101, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 45, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 73, 110, 112, 117, 116, 95, 83,
				111, 117, 114, 99, 101, 46, 99, 115, 0, 0,
				0, 3, 0, 0, 0, 46, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 83, 107, 101, 108,
				101, 116, 111, 110, 95, 80, 111, 115, 101, 46,
				99, 115, 0, 0, 0, 5, 0, 0, 0, 47,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 112, 117,
				116, 92, 83, 116, 101, 97, 109, 86, 82, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 95, 80,
				111, 115, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 62, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 67,
				111, 114, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 66, 111, 100, 121, 67, 111, 108, 108,
				105, 100, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 63, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 67,
				111, 114, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 67, 105, 114, 99, 117, 108, 97, 114,
				68, 114, 105, 118, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 66, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 67, 111, 109, 112, 108, 101, 120,
				84, 104, 114, 111, 119, 97, 98, 108, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 74,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 67, 111, 114, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 72, 111, 118,
				101, 114, 72, 105, 103, 104, 108, 105, 103, 104,
				116, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 62, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 67, 111, 114, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 67,
				117, 115, 116, 111, 109, 69, 118, 101, 110, 116,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 57, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 67, 111, 114, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 68,
				101, 98, 117, 103, 85, 73, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 75, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				92, 67, 111, 114, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 68, 101, 115, 116, 114, 111,
				121, 79, 110, 68, 101, 116, 97, 99, 104, 101,
				100, 70, 114, 111, 109, 72, 97, 110, 100, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 78,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 67, 111, 114, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 68, 101, 115,
				116, 114, 111, 121, 79, 110, 80, 97, 114, 116,
				105, 99, 108, 101, 83, 121, 115, 116, 101, 109,
				68, 101, 97, 116, 104, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 71, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 68, 101, 115, 116, 114, 111, 121,
				79, 110, 84, 114, 105, 103, 103, 101, 114, 69,
				110, 116, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 65, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 67,
				111, 114, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 68, 105, 115, 116, 97, 110, 99, 101,
				72, 97, 112, 116, 105, 99, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 67, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 67, 111, 114, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 68, 111, 110, 116, 68,
				101, 115, 116, 114, 111, 121, 79, 110, 76, 111,
				97, 100, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 59, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 67, 111, 114,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				69, 110, 117, 109, 70, 108, 97, 103, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 60,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 67, 111, 114, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 69, 113, 117,
				105, 112, 112, 97, 98, 108, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 74, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 67, 111, 114, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 70, 97, 108, 108, 98,
				97, 99, 107, 67, 97, 109, 101, 114, 97, 67,
				111, 110, 116, 114, 111, 108, 108, 101, 114, 46,
				99, 115, 0, 0, 0, 3, 0, 0, 0, 54,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 67, 111, 114, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 72, 97, 110,
				100, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 62, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 67, 111, 114, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 72,
				97, 110, 100, 67, 111, 108, 108, 105, 100, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 61, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 67, 111, 114, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 72,
				97, 110, 100, 80, 104, 121, 115, 105, 99, 115,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				60, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 72, 97,
				112, 116, 105, 99, 82, 97, 99, 107, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 69, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 67, 111, 114, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 72, 105, 100, 101,
				79, 110, 72, 97, 110, 100, 70, 111, 99, 117,
				115, 76, 111, 115, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 61, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 72, 111, 118, 101, 114, 66, 117,
				116, 116, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 64, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 67,
				111, 114, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 103, 110, 111, 114, 101, 72, 111,
				118, 101, 114, 105, 110, 103, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 61, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				92, 67, 111, 114, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 73, 110, 112, 117, 116, 77,
				111, 100, 117, 108, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 62, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 97, 98, 108, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 67, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 97, 98, 108, 101, 68, 101, 98, 117, 103,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				73, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 97, 98, 108, 101,
				72, 111, 118, 101, 114, 69, 118, 101, 110, 116,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 61, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 67, 111, 114, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 73,
				116, 101, 109, 80, 97, 99, 107, 97, 103, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				70, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 73, 116,
				101, 109, 80, 97, 99, 107, 97, 103, 101, 82,
				101, 102, 101, 114, 101, 110, 99, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 68, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 67, 111, 114, 101, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 73, 116, 101, 109,
				80, 97, 99, 107, 97, 103, 101, 83, 112, 97,
				119, 110, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 65, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 67,
				111, 114, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 76, 105, 110, 101, 97, 114, 65, 110,
				105, 109, 97, 116, 105, 111, 110, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 64, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 67, 111, 114, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 76, 105, 110, 101, 97,
				114, 65, 110, 105, 109, 97, 116, 111, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 66,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 67, 111, 114, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 76, 105, 110,
				101, 97, 114, 65, 117, 100, 105, 111, 80, 105,
				116, 99, 104, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 66, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 67, 111,
				114, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 105, 110, 101, 97, 114, 66, 108, 101,
				110, 100, 115, 104, 97, 112, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 68, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 67, 111, 114, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 76, 105, 110, 101, 97,
				114, 68, 105, 115, 112, 108, 97, 99, 101, 109,
				101, 110, 116, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 61, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 67, 111,
				114, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 105, 110, 101, 97, 114, 68, 114, 105,
				118, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 63, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 67, 111, 114,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				76, 105, 110, 101, 97, 114, 77, 97, 112, 112,
				105, 110, 103, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 64, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 67, 111,
				114, 101, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 77, 111, 100, 97, 108, 84, 104, 114, 111,
				119, 97, 98, 108, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 56, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 80, 108, 97, 121, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 59,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 67, 111, 114, 101, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 80, 108, 97,
				121, 83, 111, 117, 110, 100, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 61, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				92, 67, 111, 114, 101, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 82, 101, 110, 100, 101, 114,
				77, 111, 100, 101, 108, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 57, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 101, 101, 84, 104, 114, 117,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				62, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 108,
				101, 101, 112, 79, 110, 65, 119, 97, 107, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				63, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 111,
				117, 110, 100, 68, 101, 112, 97, 114, 101, 110,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 66, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 67, 111, 114, 101,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				111, 117, 110, 100, 80, 108, 97, 121, 79, 110,
				101, 115, 104, 111, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 89, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				67, 111, 114, 101, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 112, 97, 119, 110, 65, 110,
				100, 65, 116, 116, 97, 99, 104, 65, 102, 116,
				101, 114, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 73, 115, 84, 114, 97, 99, 107, 105,
				110, 103, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 70, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 67, 111, 114,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				83, 112, 97, 119, 110, 65, 110, 100, 65, 116,
				116, 97, 99, 104, 84, 111, 72, 97, 110, 100,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				59, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 84, 104,
				114, 111, 119, 97, 98, 108, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 59, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 67, 111, 114, 101, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 85, 73, 69, 108, 101,
				109, 101, 110, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 58, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 67,
				111, 114, 101, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 85, 110, 112, 97, 114, 101, 110, 116,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				54, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 67, 111, 114, 101, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 85, 116,
				105, 108, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 67, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 67, 111, 114,
				101, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				86, 101, 108, 111, 99, 105, 116, 121, 69, 115,
				116, 105, 109, 97, 116, 111, 114, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 72, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 72, 105, 110, 116, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 66, 117, 116, 116,
				111, 110, 72, 105, 110, 116, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 66, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 76, 111, 110, 103, 98, 111, 119, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 65, 114,
				99, 104, 101, 114, 121, 84, 97, 114, 103, 101,
				116, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 58, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 76, 111, 110, 103,
				98, 111, 119, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 65, 114, 114, 111, 119, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 62, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 76, 111, 110, 103, 98, 111, 119, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 65, 114,
				114, 111, 119, 72, 97, 110, 100, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 70, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 76, 111, 110, 103, 98, 111, 119, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 65, 114,
				114, 111, 119, 104, 101, 97, 100, 82, 111, 116,
				97, 116, 105, 111, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 60, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				76, 111, 110, 103, 98, 111, 119, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 66, 97, 108, 108,
				111, 111, 110, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 69, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 76, 111,
				110, 103, 98, 111, 119, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 97, 108, 108, 111, 111,
				110, 67, 111, 108, 108, 105, 100, 101, 114, 115,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				70, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 76, 111, 110, 103, 98,
				111, 119, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 66, 97, 108, 108, 111, 111, 110, 72, 97,
				112, 116, 105, 99, 66, 117, 109, 112, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 67, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 76, 111, 110, 103, 98, 111, 119,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				97, 108, 108, 111, 111, 110, 83, 112, 97, 119,
				110, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 68, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 76, 111,
				110, 103, 98, 111, 119, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 69, 120, 112, 108, 111, 115,
				105, 111, 110, 87, 111, 98, 98, 108, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 63,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 76, 111, 110, 103, 98, 111,
				119, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				70, 105, 114, 101, 83, 111, 117, 114, 99, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				60, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 76, 111, 110, 103, 98,
				111, 119, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 76, 111, 110, 103, 98, 111, 119, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 66, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 76, 111, 110, 103, 98, 111, 119,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				111, 117, 110, 100, 66, 111, 119, 67, 108, 105,
				99, 107, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 74, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 83, 97, 109,
				112, 108, 101, 115, 92, 66, 117, 103, 103, 121,
				66, 117, 100, 100, 121, 92, 65, 117, 100, 105,
				111, 92, 65, 109, 98, 105, 101, 110, 116, 83,
				111, 117, 110, 100, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 66, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 83,
				97, 109, 112, 108, 101, 115, 92, 66, 117, 103,
				103, 121, 66, 117, 100, 100, 121, 92, 66, 117,
				103, 103, 121, 66, 117, 100, 100, 121, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 71, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 83, 97, 109, 112, 108, 101, 115,
				92, 66, 117, 103, 103, 121, 66, 117, 100, 100,
				121, 92, 66, 117, 103, 103, 121, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 67, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 83, 97, 109, 112, 108, 101, 115, 92,
				66, 117, 103, 103, 121, 66, 117, 100, 100, 121,
				92, 76, 111, 99, 107, 84, 111, 80, 111, 105,
				110, 116, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 64, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 83, 97, 109,
				112, 108, 101, 115, 92, 66, 117, 103, 103, 121,
				66, 117, 100, 100, 121, 92, 116, 114, 97, 99,
				107, 67, 97, 109, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 64, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 83,
				97, 109, 112, 108, 101, 115, 92, 66, 117, 103,
				103, 121, 66, 117, 100, 100, 121, 92, 116, 114,
				97, 99, 107, 79, 98, 106, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 65, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				92, 83, 97, 109, 112, 108, 101, 115, 92, 66,
				117, 103, 103, 121, 66, 117, 100, 100, 121, 92,
				87, 104, 101, 101, 108, 68, 117, 115, 116, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 60,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 83, 97, 109, 112, 108, 101,
				115, 92, 71, 114, 101, 110, 97, 100, 101, 92,
				71, 114, 101, 110, 97, 100, 101, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 60, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 83, 97, 109, 112, 108, 101, 115, 92,
				74, 111, 101, 74, 101, 102, 102, 92, 74, 111,
				101, 74, 101, 102, 102, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 70, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				83, 97, 109, 112, 108, 101, 115, 92, 74, 111,
				101, 74, 101, 102, 102, 92, 74, 111, 101, 74,
				101, 102, 102, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 68, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 83, 97,
				109, 112, 108, 101, 115, 92, 74, 111, 101, 74,
				101, 102, 102, 92, 74, 111, 101, 74, 101, 102,
				102, 71, 101, 115, 116, 117, 114, 101, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 67,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 83, 97, 109, 112, 108, 101,
				115, 92, 74, 111, 101, 74, 101, 102, 102, 92,
				80, 114, 111, 99, 101, 100, 117, 114, 97, 108,
				72, 97, 116, 115, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 65, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 83,
				97, 109, 112, 108, 101, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 66, 117, 116, 116, 111,
				110, 69, 102, 102, 101, 99, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 66, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 83, 97, 109, 112, 108, 101, 115, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 66, 117,
				116, 116, 111, 110, 69, 120, 97, 109, 112, 108,
				101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 75, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 92, 83, 97, 109, 112,
				108, 101, 115, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 72, 105, 110, 116, 115, 69, 120, 97,
				109, 112, 108, 101, 46, 99, 115, 0, 0, 0,
				4, 0, 0, 0, 73, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 83,
				97, 109, 112, 108, 101, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 67, 117, 115, 116, 111,
				109, 83, 107, 101, 108, 101, 116, 111, 110, 72,
				101, 108, 112, 101, 114, 46, 99, 115, 0, 0,
				0, 2, 0, 0, 0, 63, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				83, 97, 109, 112, 108, 101, 115, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 70, 108, 111, 112,
				112, 121, 72, 97, 110, 100, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 66, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				92, 83, 97, 109, 112, 108, 101, 115, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 70, 108, 111,
				119, 101, 114, 80, 108, 97, 110, 116, 101, 100,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				72, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 83, 97, 109, 112, 108,
				101, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 97,
				98, 108, 101, 69, 120, 97, 109, 112, 108, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				61, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 83, 97, 109, 112, 108,
				101, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 80, 108, 97, 110, 116, 105, 110, 103, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 73,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 83, 97, 109, 112, 108, 101,
				115, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				82, 101, 110, 100, 101, 114, 77, 111, 100, 101,
				108, 67, 104, 97, 110, 103, 101, 114, 85, 73,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				70, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 92, 83, 97, 109, 112, 108,
				101, 115, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 83, 107, 101, 108, 101, 116, 111, 110, 85,
				73, 79, 112, 116, 105, 111, 110, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 68, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 83, 97, 109, 112, 108, 101, 115,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 84,
				97, 114, 103, 101, 116, 72, 105, 116, 69, 102,
				102, 101, 99, 116, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 70, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 83,
				97, 109, 112, 108, 101, 115, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 84, 97, 114, 103, 101,
				116, 77, 101, 97, 115, 117, 114, 101, 109, 101,
				110, 116, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 72, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 83, 97, 109,
				112, 108, 101, 115, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 85, 82, 80, 77, 97, 116, 101,
				114, 105, 97, 108, 83, 119, 105, 116, 99, 104,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 63, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 83, 97, 109,
				112, 108, 101, 115, 92, 83, 113, 117, 105, 115,
				104, 121, 92, 83, 113, 117, 105, 115, 104, 121,
				84, 111, 121, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 54, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 92, 83, 110,
				97, 112, 84, 117, 114, 110, 92, 83, 110, 97,
				112, 84, 117, 114, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 86, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				84, 101, 108, 101, 112, 111, 114, 116, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 65, 108, 108,
				111, 119, 84, 101, 108, 101, 112, 111, 114, 116,
				87, 104, 105, 108, 101, 65, 116, 116, 97, 99,
				104, 101, 100, 84, 111, 72, 97, 110, 100, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 67,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 92, 84, 101, 108, 101, 112, 111,
				114, 116, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 67, 104, 97, 112, 101, 114, 111, 110, 101,
				73, 110, 102, 111, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 73, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 92, 84,
				101, 108, 101, 112, 111, 114, 116, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 73, 103, 110, 111,
				114, 101, 84, 101, 108, 101, 112, 111, 114, 116,
				84, 114, 97, 99, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 62, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				84, 101, 108, 101, 112, 111, 114, 116, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 84, 101, 108,
				101, 112, 111, 114, 116, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 65, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 92,
				84, 101, 108, 101, 112, 111, 114, 116, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 84, 101, 108,
				101, 112, 111, 114, 116, 65, 114, 99, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 66, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 92, 84, 101, 108, 101, 112, 111, 114,
				116, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				84, 101, 108, 101, 112, 111, 114, 116, 65, 114,
				101, 97, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 72, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 84, 101, 108,
				101, 112, 111, 114, 116, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 84, 101, 108, 101, 112, 111,
				114, 116, 77, 97, 114, 107, 101, 114, 66, 97,
				115, 101, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 67, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 92, 84, 101, 108,
				101, 112, 111, 114, 116, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 84, 101, 108, 101, 112, 111,
				114, 116, 80, 111, 105, 110, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 71, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 92, 84, 101, 108, 101, 112, 111, 114, 116,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 84,
				101, 108, 101, 112, 111, 114, 116, 85, 82, 80,
				72, 101, 108, 112, 101, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 34, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 44, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 66, 101, 104, 97, 118, 105, 111, 117, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				41, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 67, 97, 109, 101, 114, 97, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 45,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 67, 97, 109, 101, 114, 97, 70, 108,
				105, 112, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 45, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 95, 67, 97, 109, 101, 114,
				97, 77, 97, 115, 107, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 39, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 69, 97,
				114, 115, 46, 99, 115, 0, 0, 0, 3, 0,
				0, 0, 55, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 95, 69, 110, 117, 109, 69,
				113, 117, 97, 108, 105, 116, 121, 67, 111, 109,
				112, 97, 114, 101, 114, 46, 99, 115, 0, 0,
				0, 10, 0, 0, 0, 41, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 69, 118,
				101, 110, 116, 115, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 49, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 95, 69, 120, 116,
				101, 114, 110, 97, 108, 67, 97, 109, 101, 114,
				97, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 63, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 69, 120, 116, 101, 114, 110,
				97, 108, 67, 97, 109, 101, 114, 97, 95, 76,
				101, 103, 97, 99, 121, 77, 97, 110, 97, 103,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 39, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 95, 70, 97, 100, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 42,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 70, 114, 117, 115, 116, 117, 109, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 37,
				92, 65, 115, 115, 101, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 75, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 44, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 95, 76, 111, 97,
				100, 76, 101, 118, 101, 108, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 39, 92, 65, 115,
				115, 101, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 77,
				101, 110, 117, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 42, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 79, 118, 101, 114,
				108, 97, 121, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 43, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 80, 108, 97, 121,
				65, 114, 101, 97, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 41, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 95, 82, 101, 110,
				100, 101, 114, 46, 99, 115, 0, 0, 0, 3,
				0, 0, 0, 46, 92, 65, 115, 115, 101, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 82, 101, 110, 100,
				101, 114, 77, 111, 100, 101, 108, 46, 99, 115,
				0, 0, 0, 3, 0, 0, 0, 45, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 83, 116, 101, 97, 109, 86, 82, 95,
				82, 105, 110, 103, 66, 117, 102, 102, 101, 114,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				43, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 83, 101, 116, 116, 105, 110, 103,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 41, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 83, 107, 121, 98, 111, 120,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				54, 92, 65, 115, 115, 101, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 83, 112, 104, 101, 114, 105, 99,
				97, 108, 80, 114, 111, 106, 101, 99, 116, 105,
				111, 110, 46, 99, 115, 0, 0, 0, 3, 0,
				0, 0, 48, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 95, 84, 114, 97, 99, 107,
				101, 100, 67, 97, 109, 101, 114, 97, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 48, 92,
				65, 115, 115, 101, 116, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				95, 84, 114, 97, 99, 107, 101, 100, 79, 98,
				106, 101, 99, 116, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 59, 92, 65, 115, 115, 101,
				116, 115, 92, 83, 116, 101, 97, 109, 86, 82,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 83,
				116, 101, 97, 109, 86, 82, 95, 84, 114, 97,
				99, 107, 105, 110, 103, 82, 101, 102, 101, 114,
				101, 110, 99, 101, 77, 97, 110, 97, 103, 101,
				114, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 40, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 85, 116, 105, 108, 115, 46,
				99, 115
			},
			TypesData = new byte[11893]
			{
				0, 0, 0, 0, 29, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 67, 97, 109, 101, 114, 97, 72, 101,
				108, 112, 101, 114, 0, 0, 0, 0, 40, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 69, 120,
				116, 114, 97, 115, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 70, 111, 114, 99, 101, 83, 116,
				101, 97, 109, 86, 82, 77, 111, 100, 101, 0,
				0, 0, 0, 35, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 69, 120, 116, 114, 97, 115, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 71, 97,
				122, 101, 84, 114, 97, 99, 107, 101, 114, 0,
				0, 0, 0, 29, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 69, 120, 116, 114, 97, 115, 124,
				71, 97, 122, 101, 69, 118, 101, 110, 116, 65,
				114, 103, 115, 0, 0, 0, 0, 36, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 69, 120, 116,
				114, 97, 115, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 76, 97, 115, 101, 114, 80, 111, 105,
				110, 116, 101, 114, 0, 0, 0, 0, 32, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 69, 120,
				116, 114, 97, 115, 124, 80, 111, 105, 110, 116,
				101, 114, 69, 118, 101, 110, 116, 65, 114, 103,
				115, 0, 0, 0, 0, 33, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 69, 120, 116, 114, 97,
				115, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				84, 101, 115, 116, 84, 104, 114, 111, 119, 0,
				0, 0, 0, 41, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 69, 120, 116, 114, 97, 115, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 84, 101,
				115, 116, 84, 114, 97, 99, 107, 101, 100, 67,
				97, 109, 101, 114, 97, 0, 0, 0, 0, 39,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 66, 101, 104,
				97, 118, 105, 111, 117, 114, 95, 66, 111, 111,
				108, 101, 97, 110, 69, 118, 101, 110, 116, 0,
				0, 0, 0, 36, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 66, 101, 104, 97, 118, 105, 111, 117, 114,
				95, 80, 111, 115, 101, 69, 118, 101, 110, 116,
				0, 0, 0, 0, 53, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 95, 80, 111, 115, 101, 95, 67, 111, 110,
				110, 101, 99, 116, 101, 100, 67, 104, 97, 110,
				103, 101, 100, 69, 118, 101, 110, 116, 0, 0,
				0, 0, 55, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				80, 111, 115, 101, 95, 68, 101, 118, 105, 99,
				101, 73, 110, 100, 101, 120, 67, 104, 97, 110,
				103, 101, 100, 69, 118, 101, 110, 116, 0, 0,
				0, 0, 52, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				80, 111, 115, 101, 95, 84, 114, 97, 99, 107,
				105, 110, 103, 67, 104, 97, 110, 103, 101, 100,
				69, 118, 101, 110, 116, 0, 0, 0, 0, 38,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 66, 101, 104,
				97, 118, 105, 111, 117, 114, 95, 83, 105, 110,
				103, 108, 101, 69, 118, 101, 110, 116, 0, 0,
				0, 0, 40, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 69, 118,
				101, 110, 116, 0, 0, 0, 0, 57, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 66, 101, 104, 97, 118,
				105, 111, 117, 114, 95, 83, 107, 101, 108, 101,
				116, 111, 110, 95, 67, 111, 110, 110, 101, 99,
				116, 101, 100, 67, 104, 97, 110, 103, 101, 100,
				69, 118, 101, 110, 116, 0, 0, 0, 0, 56,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 66, 101, 104,
				97, 118, 105, 111, 117, 114, 95, 83, 107, 101,
				108, 101, 116, 111, 110, 95, 84, 114, 97, 99,
				107, 105, 110, 103, 67, 104, 97, 110, 103, 101,
				100, 69, 118, 101, 110, 116, 0, 0, 0, 0,
				39, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 66, 101,
				104, 97, 118, 105, 111, 117, 114, 95, 86, 101,
				99, 116, 111, 114, 50, 69, 118, 101, 110, 116,
				0, 0, 0, 0, 39, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 95, 86, 101, 99, 116, 111, 114, 51, 69,
				118, 101, 110, 116, 1, 0, 0, 0, 23, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				111, 110, 1, 0, 0, 0, 23, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 65, 99, 116, 105, 111, 110,
				1, 0, 0, 0, 34, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 65, 99, 116, 105, 111, 110, 95, 83,
				111, 117, 114, 99, 101, 95, 77, 97, 112, 1,
				0, 0, 0, 34, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 83, 111,
				117, 114, 99, 101, 95, 77, 97, 112, 0, 0,
				0, 0, 30, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				65, 99, 116, 105, 111, 110, 95, 83, 111, 117,
				114, 99, 101, 0, 0, 0, 0, 24, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 73, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				111, 110, 0, 0, 0, 0, 31, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 73, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 83, 111, 117, 114, 99, 101, 0, 0,
				0, 0, 26, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				65, 99, 116, 105, 111, 110, 83, 101, 116, 0,
				0, 0, 0, 31, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 83, 101, 116,
				95, 68, 97, 116, 97, 0, 0, 0, 0, 27,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 73,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 83, 101, 116, 0, 0, 0,
				0, 34, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 65,
				99, 116, 105, 111, 110, 83, 101, 116, 95, 77,
				97, 110, 97, 103, 101, 114, 0, 0, 0, 0,
				31, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 95, 66, 111, 111, 108, 101,
				97, 110, 0, 0, 0, 0, 42, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 65, 99, 116, 105, 111, 110,
				95, 66, 111, 111, 108, 101, 97, 110, 95, 83,
				111, 117, 114, 99, 101, 95, 77, 97, 112, 0,
				0, 0, 0, 38, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 66, 111,
				111, 108, 101, 97, 110, 95, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 32, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 73, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 66, 111, 111, 108, 101, 97, 110, 0,
				0, 0, 0, 26, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 73, 110,
				0, 0, 0, 0, 37, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 65, 99, 116, 105, 111, 110, 95, 73,
				110, 95, 83, 111, 117, 114, 99, 101, 95, 77,
				97, 112, 0, 0, 0, 0, 33, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 65, 99, 116, 105, 111, 110,
				95, 73, 110, 95, 83, 111, 117, 114, 99, 101,
				0, 0, 0, 0, 27, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 73, 83, 116, 101, 97, 109,
				86, 82, 95, 65, 99, 116, 105, 111, 110, 95,
				73, 110, 0, 0, 0, 0, 34, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 73, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 73, 110, 95, 83, 111, 117, 114, 99,
				101, 0, 0, 0, 0, 27, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 65, 99, 116, 105, 111, 110, 95,
				79, 117, 116, 0, 0, 0, 0, 34, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 79, 117, 116, 95, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 28, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 73, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 79, 117, 116, 0, 0, 0, 0, 35,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 73,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 95, 79, 117, 116, 95, 83,
				111, 117, 114, 99, 101, 0, 0, 0, 0, 28,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 65, 99, 116,
				105, 111, 110, 95, 80, 111, 115, 101, 0, 0,
				0, 0, 33, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				65, 99, 116, 105, 111, 110, 95, 80, 111, 115,
				101, 95, 66, 97, 115, 101, 0, 0, 0, 0,
				39, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 95, 80, 111, 115, 101, 95,
				83, 111, 117, 114, 99, 101, 95, 77, 97, 112,
				0, 0, 0, 0, 35, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 65, 99, 116, 105, 111, 110, 95, 80,
				111, 115, 101, 95, 83, 111, 117, 114, 99, 101,
				0, 0, 0, 0, 29, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 73, 83, 116, 101, 97, 109,
				86, 82, 95, 65, 99, 116, 105, 111, 110, 95,
				80, 111, 115, 101, 0, 0, 0, 0, 30, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 65, 99, 116, 105,
				111, 110, 95, 83, 105, 110, 103, 108, 101, 0,
				0, 0, 0, 41, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 83, 105,
				110, 103, 108, 101, 95, 83, 111, 117, 114, 99,
				101, 95, 77, 97, 112, 0, 0, 0, 0, 37,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 65, 99, 116,
				105, 111, 110, 95, 83, 105, 110, 103, 108, 101,
				95, 83, 111, 117, 114, 99, 101, 0, 0, 0,
				0, 31, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 73, 83, 116, 101, 97, 109, 86, 82, 95,
				65, 99, 116, 105, 111, 110, 95, 83, 105, 110,
				103, 108, 101, 0, 0, 0, 0, 32, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 83, 107, 101, 108, 101, 116, 111, 110,
				0, 0, 0, 0, 43, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 65, 99, 116, 105, 111, 110, 95, 83,
				107, 101, 108, 101, 116, 111, 110, 95, 83, 111,
				117, 114, 99, 101, 95, 77, 97, 112, 0, 0,
				0, 0, 39, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				65, 99, 116, 105, 111, 110, 95, 83, 107, 101,
				108, 101, 116, 111, 110, 95, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 40, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 73, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 83, 107, 101, 108, 101, 116, 111, 110,
				95, 83, 111, 117, 114, 99, 101, 0, 0, 0,
				0, 38, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 83,
				107, 101, 108, 101, 116, 111, 110, 95, 74, 111,
				105, 110, 116, 73, 110, 100, 101, 120, 101, 115,
				0, 0, 0, 0, 39, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 83, 107, 101, 108, 101, 116, 111, 110,
				95, 70, 105, 110, 103, 101, 114, 73, 110, 100,
				101, 120, 101, 115, 0, 0, 0, 0, 44, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 83, 107, 101, 108,
				101, 116, 111, 110, 95, 70, 105, 110, 103, 101,
				114, 83, 112, 108, 97, 121, 73, 110, 100, 101,
				120, 101, 115, 0, 0, 0, 0, 31, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 86, 101, 99, 116, 111, 114, 50, 0,
				0, 0, 0, 42, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 86, 101,
				99, 116, 111, 114, 50, 95, 83, 111, 117, 114,
				99, 101, 95, 77, 97, 112, 0, 0, 0, 0,
				38, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 95, 86, 101, 99, 116, 111,
				114, 50, 95, 83, 111, 117, 114, 99, 101, 0,
				0, 0, 0, 32, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 73, 83, 116, 101, 97, 109, 86,
				82, 95, 65, 99, 116, 105, 111, 110, 95, 86,
				101, 99, 116, 111, 114, 50, 0, 0, 0, 0,
				31, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 95, 86, 101, 99, 116, 111,
				114, 51, 0, 0, 0, 0, 42, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 65, 99, 116, 105, 111, 110,
				95, 86, 101, 99, 116, 111, 114, 51, 95, 83,
				111, 117, 114, 99, 101, 95, 77, 97, 112, 0,
				0, 0, 0, 38, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 86, 101,
				99, 116, 111, 114, 51, 95, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 32, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 73, 83, 116, 101,
				97, 109, 86, 82, 95, 65, 99, 116, 105, 111,
				110, 95, 86, 101, 99, 116, 111, 114, 51, 0,
				0, 0, 0, 33, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 65, 99, 116, 105, 111, 110, 95, 86, 105,
				98, 114, 97, 116, 105, 111, 110, 0, 0, 0,
				0, 44, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 65,
				99, 116, 105, 111, 110, 95, 86, 105, 98, 114,
				97, 116, 105, 111, 110, 95, 83, 111, 117, 114,
				99, 101, 95, 77, 97, 112, 0, 0, 0, 0,
				40, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 95, 86, 105, 98, 114, 97,
				116, 105, 111, 110, 95, 83, 111, 117, 114, 99,
				101, 0, 0, 0, 0, 34, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 73, 83, 116, 101, 97,
				109, 86, 82, 95, 65, 99, 116, 105, 111, 110,
				95, 86, 105, 98, 114, 97, 116, 105, 111, 110,
				0, 0, 0, 0, 40, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 65, 99, 116, 105, 118, 97, 116, 101,
				65, 99, 116, 105, 111, 110, 83, 101, 116, 79,
				110, 76, 111, 97, 100, 0, 0, 0, 0, 34,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 66, 101, 104,
				97, 118, 105, 111, 117, 114, 95, 66, 111, 111,
				108, 101, 97, 110, 0, 0, 0, 0, 31, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 66, 101, 104, 97,
				118, 105, 111, 117, 114, 95, 80, 111, 115, 101,
				0, 0, 0, 0, 33, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 66, 101, 104, 97, 118, 105, 111, 117,
				114, 95, 83, 105, 110, 103, 108, 101, 0, 0,
				0, 0, 35, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 0, 0,
				0, 0, 41, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				66, 101, 104, 97, 118, 105, 111, 117, 114, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 67, 117,
				115, 116, 111, 109, 0, 0, 0, 0, 34, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 66, 101, 104, 97,
				118, 105, 111, 117, 114, 95, 86, 101, 99, 116,
				111, 114, 50, 0, 0, 0, 0, 34, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 66, 101, 104, 97, 118,
				105, 111, 117, 114, 95, 86, 101, 99, 116, 111,
				114, 51, 0, 0, 0, 0, 22, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 73, 110, 112, 117, 116, 0,
				0, 0, 0, 33, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 73, 110, 112, 117, 116, 95, 65, 99, 116,
				105, 111, 110, 70, 105, 108, 101, 0, 0, 0,
				0, 48, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 73,
				110, 112, 117, 116, 95, 65, 99, 116, 105, 111,
				110, 70, 105, 108, 101, 95, 68, 101, 102, 97,
				117, 108, 116, 66, 105, 110, 100, 105, 110, 103,
				0, 0, 0, 0, 43, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 95, 65, 99,
				116, 105, 111, 110, 70, 105, 108, 101, 95, 65,
				99, 116, 105, 111, 110, 83, 101, 116, 0, 0,
				0, 0, 40, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				73, 110, 112, 117, 116, 95, 65, 99, 116, 105,
				111, 110, 70, 105, 108, 101, 95, 65, 99, 116,
				105, 111, 110, 0, 0, 0, 0, 50, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 73, 110, 112, 117, 116,
				95, 65, 99, 116, 105, 111, 110, 70, 105, 108,
				101, 95, 76, 111, 99, 97, 108, 105, 122, 97,
				116, 105, 111, 110, 73, 116, 101, 109, 0, 0,
				0, 0, 35, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				73, 110, 112, 117, 116, 95, 77, 97, 110, 105,
				102, 101, 115, 116, 70, 105, 108, 101, 0, 0,
				0, 0, 47, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				73, 110, 112, 117, 116, 95, 77, 97, 110, 105,
				102, 101, 115, 116, 70, 105, 108, 101, 95, 65,
				112, 112, 108, 105, 99, 97, 116, 105, 111, 110,
				0, 0, 0, 0, 52, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 95, 85, 110,
				105, 116, 121, 95, 65, 115, 115, 101, 109, 98,
				108, 121, 70, 105, 108, 101, 95, 68, 101, 102,
				105, 110, 105, 116, 105, 111, 110, 0, 0, 0,
				0, 53, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 73,
				110, 112, 117, 116, 95, 77, 97, 110, 105, 102,
				101, 115, 116, 70, 105, 108, 101, 95, 65, 112,
				112, 108, 105, 99, 97, 116, 105, 111, 110, 83,
				116, 114, 105, 110, 103, 0, 0, 0, 0, 55,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 73, 110, 112,
				117, 116, 95, 77, 97, 110, 105, 102, 101, 115,
				116, 70, 105, 108, 101, 95, 65, 112, 112, 108,
				105, 99, 97, 116, 105, 111, 110, 95, 66, 105,
				110, 100, 105, 110, 103, 0, 0, 0, 0, 71,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 73, 110, 112,
				117, 116, 95, 77, 97, 110, 105, 102, 101, 115,
				116, 70, 105, 108, 101, 95, 65, 112, 112, 108,
				105, 99, 97, 116, 105, 111, 110, 95, 66, 105,
				110, 100, 105, 110, 103, 95, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 84, 121, 112, 101,
				115, 0, 0, 0, 0, 45, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 73, 110, 112, 117, 116, 95, 65,
				99, 116, 105, 111, 110, 70, 105, 108, 101, 95,
				65, 99, 116, 105, 111, 110, 84, 121, 112, 101,
				115, 0, 0, 0, 0, 50, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 73, 110, 112, 117, 116, 95, 65,
				99, 116, 105, 111, 110, 70, 105, 108, 101, 95,
				65, 99, 116, 105, 111, 110, 83, 101, 116, 95,
				85, 115, 97, 103, 101, 115, 0, 0, 0, 0,
				34, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 73, 110,
				112, 117, 116, 95, 66, 105, 110, 100, 105, 110,
				103, 70, 105, 108, 101, 0, 0, 0, 0, 45,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 73, 110, 112,
				117, 116, 95, 66, 105, 110, 100, 105, 110, 103,
				70, 105, 108, 101, 95, 65, 99, 116, 105, 111,
				110, 76, 105, 115, 116, 0, 0, 0, 0, 40,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 73, 110, 112,
				117, 116, 95, 66, 105, 110, 100, 105, 110, 103,
				70, 105, 108, 101, 95, 67, 104, 111, 114, 100,
				0, 0, 0, 0, 39, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 95, 66, 105,
				110, 100, 105, 110, 103, 70, 105, 108, 101, 95,
				80, 111, 115, 101, 0, 0, 0, 0, 41, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 73, 110, 112, 117,
				116, 95, 66, 105, 110, 100, 105, 110, 103, 70,
				105, 108, 101, 95, 72, 97, 112, 116, 105, 99,
				0, 0, 0, 0, 43, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 95, 66, 105,
				110, 100, 105, 110, 103, 70, 105, 108, 101, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 0, 0,
				0, 0, 41, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				73, 110, 112, 117, 116, 95, 66, 105, 110, 100,
				105, 110, 103, 70, 105, 108, 101, 95, 83, 111,
				117, 114, 99, 101, 0, 0, 0, 0, 47, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 73, 110, 112, 117,
				116, 95, 66, 105, 110, 100, 105, 110, 103, 70,
				105, 108, 101, 95, 83, 111, 117, 114, 99, 101,
				95, 73, 110, 112, 117, 116, 0, 0, 0, 0,
				64, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 73, 110,
				112, 117, 116, 95, 66, 105, 110, 100, 105, 110,
				103, 70, 105, 108, 101, 95, 83, 111, 117, 114,
				99, 101, 95, 73, 110, 112, 117, 116, 95, 83,
				116, 114, 105, 110, 103, 68, 105, 99, 116, 105,
				111, 110, 97, 114, 121, 0, 0, 0, 0, 38,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 73, 110, 112,
				117, 116, 95, 71, 101, 110, 101, 114, 97, 116,
				111, 114, 95, 78, 97, 109, 101, 115, 0, 0,
				0, 0, 29, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				73, 110, 112, 117, 116, 95, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 30, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 83, 107, 101, 108, 101, 116,
				111, 110, 95, 80, 111, 115, 101, 0, 0, 0,
				0, 35, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 83,
				107, 101, 108, 101, 116, 111, 110, 95, 80, 111,
				115, 101, 95, 72, 97, 110, 100, 0, 0, 0,
				0, 50, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 83,
				107, 101, 108, 101, 116, 111, 110, 95, 70, 105,
				110, 103, 101, 114, 69, 120, 116, 101, 110, 115,
				105, 111, 110, 84, 121, 112, 101, 76, 105, 115,
				116, 115, 0, 0, 0, 0, 31, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 83, 107, 101, 108, 101, 116,
				111, 110, 95, 80, 111, 115, 101, 114, 0, 0,
				0, 0, 53, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 83, 116, 101, 97, 109, 86, 82, 95,
				83, 107, 101, 108, 101, 116, 111, 110, 95, 80,
				111, 115, 101, 114, 124, 83, 107, 101, 108, 101,
				116, 111, 110, 66, 108, 101, 110, 100, 97, 98,
				108, 101, 80, 111, 115, 101, 0, 0, 0, 0,
				53, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				83, 116, 101, 97, 109, 86, 82, 95, 83, 107,
				101, 108, 101, 116, 111, 110, 95, 80, 111, 115,
				101, 114, 124, 80, 111, 115, 101, 66, 108, 101,
				110, 100, 105, 110, 103, 66, 101, 104, 97, 118,
				105, 111, 117, 114, 0, 0, 0, 0, 38, 86,
				97, 108, 118, 101, 46, 86, 82, 124, 83, 116,
				101, 97, 109, 86, 82, 95, 83, 107, 101, 108,
				101, 116, 111, 110, 95, 80, 111, 115, 101, 83,
				110, 97, 112, 115, 104, 111, 116, 0, 0, 0,
				0, 34, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 83,
				107, 101, 108, 101, 116, 111, 110, 95, 72, 97,
				110, 100, 77, 97, 115, 107, 0, 0, 0, 0,
				39, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 66, 111,
				100, 121, 67, 111, 108, 108, 105, 100, 101, 114,
				0, 0, 0, 0, 40, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 67, 105, 114, 99, 117, 108, 97, 114,
				68, 114, 105, 118, 101, 0, 0, 0, 0, 43,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 124, 67, 111, 109,
				112, 108, 101, 120, 84, 104, 114, 111, 119, 97,
				98, 108, 101, 0, 0, 0, 0, 51, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 67, 111, 110, 116, 114,
				111, 108, 108, 101, 114, 72, 111, 118, 101, 114,
				72, 105, 103, 104, 108, 105, 103, 104, 116, 0,
				0, 0, 0, 39, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 67, 117, 115, 116, 111, 109, 69, 118, 101,
				110, 116, 115, 0, 0, 0, 0, 61, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 46, 67, 117, 115, 116, 111,
				109, 69, 118, 101, 110, 116, 115, 124, 85, 110,
				105, 116, 121, 69, 118, 101, 110, 116, 83, 105,
				110, 103, 108, 101, 70, 108, 111, 97, 116, 0,
				0, 0, 0, 54, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				46, 67, 117, 115, 116, 111, 109, 69, 118, 101,
				110, 116, 115, 124, 85, 110, 105, 116, 121, 69,
				118, 101, 110, 116, 72, 97, 110, 100, 0, 0,
				0, 0, 34, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				68, 101, 98, 117, 103, 85, 73, 0, 0, 0,
				0, 52, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 68,
				101, 115, 116, 114, 111, 121, 79, 110, 68, 101,
				116, 97, 99, 104, 101, 100, 70, 114, 111, 109,
				72, 97, 110, 100, 0, 0, 0, 0, 55, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 68, 101, 115, 116,
				114, 111, 121, 79, 110, 80, 97, 114, 116, 105,
				99, 108, 101, 83, 121, 115, 116, 101, 109, 68,
				101, 97, 116, 104, 0, 0, 0, 0, 48, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 68, 101, 115, 116,
				114, 111, 121, 79, 110, 84, 114, 105, 103, 103,
				101, 114, 69, 110, 116, 101, 114, 0, 0, 0,
				0, 42, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 68,
				105, 115, 116, 97, 110, 99, 101, 72, 97, 112,
				116, 105, 99, 115, 0, 0, 0, 0, 44, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 68, 111, 110, 116,
				68, 101, 115, 116, 114, 111, 121, 79, 110, 76,
				111, 97, 100, 0, 0, 0, 0, 36, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 69, 110, 117, 109, 70,
				108, 97, 103, 115, 0, 0, 0, 0, 37, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 69, 113, 117, 105,
				112, 112, 97, 98, 108, 101, 0, 0, 0, 0,
				51, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 70, 97,
				108, 108, 98, 97, 99, 107, 67, 97, 109, 101,
				114, 97, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 0, 0, 0, 0, 31, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 124, 72, 97, 110, 100, 0, 0,
				0, 0, 46, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 46,
				72, 97, 110, 100, 124, 65, 116, 116, 97, 99,
				104, 101, 100, 79, 98, 106, 101, 99, 116, 0,
				0, 0, 0, 36, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 72, 97, 110, 100, 69, 118, 101, 110, 116,
				0, 0, 0, 0, 39, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 72, 97, 110, 100, 67, 111, 108, 108,
				105, 100, 101, 114, 0, 0, 0, 0, 55, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 46, 72, 97, 110, 100,
				67, 111, 108, 108, 105, 100, 101, 114, 124, 70,
				105, 110, 103, 101, 114, 67, 111, 108, 108, 105,
				100, 101, 114, 115, 0, 0, 0, 0, 38, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 72, 97, 110, 100,
				80, 104, 121, 115, 105, 99, 115, 0, 0, 0,
				0, 37, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 72,
				97, 112, 116, 105, 99, 82, 97, 99, 107, 0,
				0, 0, 0, 46, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 72, 105, 100, 101, 79, 110, 72, 97, 110,
				100, 70, 111, 99, 117, 115, 76, 111, 115, 116,
				0, 0, 0, 0, 38, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 72, 111, 118, 101, 114, 66, 117, 116,
				116, 111, 110, 0, 0, 0, 0, 41, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 73, 103, 110, 111, 114,
				101, 72, 111, 118, 101, 114, 105, 110, 103, 0,
				0, 0, 0, 38, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 73, 110, 112, 117, 116, 77, 111, 100, 117,
				108, 101, 0, 0, 0, 0, 39, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 124, 73, 110, 116, 101, 114, 97,
				99, 116, 97, 98, 108, 101, 0, 0, 0, 0,
				44, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 73, 110,
				116, 101, 114, 97, 99, 116, 97, 98, 108, 101,
				68, 101, 98, 117, 103, 0, 0, 0, 0, 50,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 124, 73, 110, 116,
				101, 114, 97, 99, 116, 97, 98, 108, 101, 72,
				111, 118, 101, 114, 69, 118, 101, 110, 116, 115,
				0, 0, 0, 0, 38, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 73, 116, 101, 109, 80, 97, 99, 107,
				97, 103, 101, 0, 0, 0, 0, 47, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 73, 116, 101, 109, 80,
				97, 99, 107, 97, 103, 101, 82, 101, 102, 101,
				114, 101, 110, 99, 101, 0, 0, 0, 0, 45,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 124, 73, 116, 101,
				109, 80, 97, 99, 107, 97, 103, 101, 83, 112,
				97, 119, 110, 101, 114, 0, 0, 0, 0, 42,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 124, 76, 105, 110,
				101, 97, 114, 65, 110, 105, 109, 97, 116, 105,
				111, 110, 0, 0, 0, 0, 41, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 124, 76, 105, 110, 101, 97, 114,
				65, 110, 105, 109, 97, 116, 111, 114, 0, 0,
				0, 0, 43, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				76, 105, 110, 101, 97, 114, 65, 117, 100, 105,
				111, 80, 105, 116, 99, 104, 0, 0, 0, 0,
				43, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 76, 105,
				110, 101, 97, 114, 66, 108, 101, 110, 100, 115,
				104, 97, 112, 101, 0, 0, 0, 0, 45, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 76, 105, 110, 101,
				97, 114, 68, 105, 115, 112, 108, 97, 99, 101,
				109, 101, 110, 116, 0, 0, 0, 0, 38, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 76, 105, 110, 101,
				97, 114, 68, 114, 105, 118, 101, 0, 0, 0,
				0, 40, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 76,
				105, 110, 101, 97, 114, 77, 97, 112, 112, 105,
				110, 103, 0, 0, 0, 0, 41, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 124, 77, 111, 100, 97, 108, 84,
				104, 114, 111, 119, 97, 98, 108, 101, 0, 0,
				0, 0, 33, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				80, 108, 97, 121, 101, 114, 0, 0, 0, 0,
				36, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 80, 108,
				97, 121, 83, 111, 117, 110, 100, 0, 0, 0,
				0, 38, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 82,
				101, 110, 100, 101, 114, 77, 111, 100, 101, 108,
				0, 0, 0, 0, 34, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 83, 101, 101, 84, 104, 114, 117, 0,
				0, 0, 0, 39, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 83, 108, 101, 101, 112, 79, 110, 65, 119,
				97, 107, 101, 0, 0, 0, 0, 40, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 83, 111, 117, 110, 100,
				68, 101, 112, 97, 114, 101, 110, 116, 0, 0,
				0, 0, 43, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				83, 111, 117, 110, 100, 80, 108, 97, 121, 79,
				110, 101, 115, 104, 111, 116, 0, 0, 0, 0,
				66, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 83, 112,
				97, 119, 110, 65, 110, 100, 65, 116, 116, 97,
				99, 104, 65, 102, 116, 101, 114, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 73, 115, 84,
				114, 97, 99, 107, 105, 110, 103, 0, 0, 0,
				0, 47, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 83,
				112, 97, 119, 110, 65, 110, 100, 65, 116, 116,
				97, 99, 104, 84, 111, 72, 97, 110, 100, 0,
				0, 0, 0, 36, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 84, 104, 114, 111, 119, 97, 98, 108, 101,
				0, 0, 0, 0, 36, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 85, 73, 69, 108, 101, 109, 101, 110,
				116, 0, 0, 0, 0, 35, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 85, 110, 112, 97, 114, 101, 110,
				116, 0, 0, 0, 0, 31, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 85, 116, 105, 108, 0, 0, 0,
				0, 47, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 65,
				102, 116, 101, 114, 84, 105, 109, 101, 114, 95,
				67, 111, 109, 112, 111, 110, 101, 110, 116, 0,
				0, 0, 0, 44, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 86, 101, 108, 111, 99, 105, 116, 121, 69,
				115, 116, 105, 109, 97, 116, 111, 114, 0, 0,
				0, 0, 48, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				67, 111, 110, 116, 114, 111, 108, 108, 101, 114,
				66, 117, 116, 116, 111, 110, 72, 105, 110, 116,
				115, 0, 0, 0, 0, 63, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 46, 67, 111, 110, 116, 114, 111, 108,
				108, 101, 114, 66, 117, 116, 116, 111, 110, 72,
				105, 110, 116, 115, 124, 65, 99, 116, 105, 111,
				110, 72, 105, 110, 116, 73, 110, 102, 111, 0,
				0, 0, 0, 40, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 73, 110, 116, 101, 114, 97, 99,
				116, 105, 111, 110, 83, 121, 115, 116, 101, 109,
				124, 65, 114, 99, 104, 101, 114, 121, 84, 97,
				114, 103, 101, 116, 0, 0, 0, 0, 32, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 65, 114, 114, 111,
				119, 0, 0, 0, 0, 36, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 65, 114, 114, 111, 119, 72, 97,
				110, 100, 0, 0, 0, 0, 44, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 124, 65, 114, 114, 111, 119, 104,
				101, 97, 100, 82, 111, 116, 97, 116, 105, 111,
				110, 0, 0, 0, 0, 34, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 66, 97, 108, 108, 111, 111, 110,
				0, 0, 0, 0, 43, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 66, 97, 108, 108, 111, 111, 110, 67,
				111, 108, 108, 105, 100, 101, 114, 115, 0, 0,
				0, 0, 44, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				66, 97, 108, 108, 111, 111, 110, 72, 97, 112,
				116, 105, 99, 66, 117, 109, 112, 0, 0, 0,
				0, 41, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 66,
				97, 108, 108, 111, 111, 110, 83, 112, 97, 119,
				110, 101, 114, 0, 0, 0, 0, 42, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 69, 120, 112, 108, 111,
				115, 105, 111, 110, 87, 111, 98, 98, 108, 101,
				0, 0, 0, 0, 37, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 124, 70, 105, 114, 101, 83, 111, 117, 114,
				99, 101, 0, 0, 0, 0, 34, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 124, 76, 111, 110, 103, 98, 111,
				119, 0, 0, 0, 0, 40, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 83, 111, 117, 110, 100, 66, 111,
				119, 67, 108, 105, 99, 107, 0, 0, 0, 0,
				46, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 46, 83, 97,
				109, 112, 108, 101, 124, 65, 109, 98, 105, 101,
				110, 116, 83, 111, 117, 110, 100, 0, 0, 0,
				0, 44, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 46, 83,
				97, 109, 112, 108, 101, 124, 66, 117, 103, 103,
				121, 66, 117, 100, 100, 121, 0, 0, 0, 0,
				49, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 46, 83, 97,
				109, 112, 108, 101, 124, 66, 117, 103, 103, 121,
				67, 111, 110, 116, 114, 111, 108, 108, 101, 114,
				0, 0, 0, 0, 45, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 124, 76,
				111, 99, 107, 84, 111, 80, 111, 105, 110, 116,
				0, 0, 0, 0, 42, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 124, 116,
				114, 97, 99, 107, 67, 97, 109, 0, 0, 0,
				0, 42, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 46, 83,
				97, 109, 112, 108, 101, 124, 116, 114, 97, 99,
				107, 79, 98, 106, 0, 0, 0, 0, 43, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 46, 83, 97, 109, 112,
				108, 101, 124, 87, 104, 101, 101, 108, 68, 117,
				115, 116, 0, 0, 0, 0, 41, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 46, 83, 97, 109, 112, 108, 101,
				124, 71, 114, 101, 110, 97, 100, 101, 0, 0,
				0, 0, 41, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 46,
				83, 97, 109, 112, 108, 101, 124, 74, 111, 101,
				74, 101, 102, 102, 0, 0, 0, 0, 51, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 46, 83, 97, 109, 112,
				108, 101, 124, 74, 111, 101, 74, 101, 102, 102,
				67, 111, 110, 116, 114, 111, 108, 108, 101, 114,
				0, 0, 0, 0, 49, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 124, 74,
				111, 101, 74, 101, 102, 102, 71, 101, 115, 116,
				117, 114, 101, 115, 0, 0, 0, 0, 48, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 46, 83, 97, 109, 112,
				108, 101, 124, 80, 114, 111, 99, 101, 100, 117,
				114, 97, 108, 72, 97, 116, 115, 0, 0, 0,
				0, 46, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 46, 83,
				97, 109, 112, 108, 101, 124, 66, 117, 116, 116,
				111, 110, 69, 102, 102, 101, 99, 116, 0, 0,
				0, 0, 47, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 46,
				83, 97, 109, 112, 108, 101, 124, 66, 117, 116,
				116, 111, 110, 69, 120, 97, 109, 112, 108, 101,
				0, 0, 0, 0, 56, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 124, 67,
				111, 110, 116, 114, 111, 108, 108, 101, 114, 72,
				105, 110, 116, 115, 69, 120, 97, 109, 112, 108,
				101, 0, 0, 0, 0, 54, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 46, 83, 97, 109, 112, 108, 101, 124,
				67, 117, 115, 116, 111, 109, 83, 107, 101, 108,
				101, 116, 111, 110, 72, 101, 108, 112, 101, 114,
				0, 0, 0, 0, 67, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 46, 67,
				117, 115, 116, 111, 109, 83, 107, 101, 108, 101,
				116, 111, 110, 72, 101, 108, 112, 101, 114, 124,
				82, 101, 116, 97, 114, 103, 101, 116, 97, 98,
				108, 101, 0, 0, 0, 0, 60, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 46, 83, 97, 109, 112, 108, 101,
				46, 67, 117, 115, 116, 111, 109, 83, 107, 101,
				108, 101, 116, 111, 110, 72, 101, 108, 112, 101,
				114, 124, 84, 104, 117, 109, 98, 0, 0, 0,
				0, 61, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 46, 83,
				97, 109, 112, 108, 101, 46, 67, 117, 115, 116,
				111, 109, 83, 107, 101, 108, 101, 116, 111, 110,
				72, 101, 108, 112, 101, 114, 124, 70, 105, 110,
				103, 101, 114, 0, 0, 0, 0, 44, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 46, 83, 97, 109, 112, 108,
				101, 124, 70, 108, 111, 112, 112, 121, 72, 97,
				110, 100, 0, 0, 0, 0, 51, 86, 97, 108,
				118, 101, 46, 86, 82, 46, 73, 110, 116, 101,
				114, 97, 99, 116, 105, 111, 110, 83, 121, 115,
				116, 101, 109, 46, 83, 97, 109, 112, 108, 101,
				46, 70, 108, 111, 112, 112, 121, 72, 97, 110,
				100, 124, 70, 105, 110, 103, 101, 114, 0, 0,
				0, 0, 47, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 46,
				83, 97, 109, 112, 108, 101, 124, 70, 108, 111,
				119, 101, 114, 80, 108, 97, 110, 116, 101, 100,
				0, 0, 0, 0, 53, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 124, 73,
				110, 116, 101, 114, 97, 99, 116, 97, 98, 108,
				101, 69, 120, 97, 109, 112, 108, 101, 0, 0,
				0, 0, 42, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 46,
				83, 97, 109, 112, 108, 101, 124, 80, 108, 97,
				110, 116, 105, 110, 103, 0, 0, 0, 0, 54,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 46, 83, 97, 109,
				112, 108, 101, 124, 82, 101, 110, 100, 101, 114,
				77, 111, 100, 101, 108, 67, 104, 97, 110, 103,
				101, 114, 85, 73, 0, 0, 0, 0, 51, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 46, 83, 97, 109, 112,
				108, 101, 124, 83, 107, 101, 108, 101, 116, 111,
				110, 85, 73, 79, 112, 116, 105, 111, 110, 115,
				0, 0, 0, 0, 49, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 73, 110, 116, 101, 114, 97,
				99, 116, 105, 111, 110, 83, 121, 115, 116, 101,
				109, 46, 83, 97, 109, 112, 108, 101, 124, 84,
				97, 114, 103, 101, 116, 72, 105, 116, 69, 102,
				102, 101, 99, 116, 0, 0, 0, 0, 51, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 46, 83, 97, 109, 112,
				108, 101, 124, 84, 97, 114, 103, 101, 116, 77,
				101, 97, 115, 117, 114, 101, 109, 101, 110, 116,
				0, 0, 0, 0, 20, 124, 85, 82, 80, 77,
				97, 116, 101, 114, 105, 97, 108, 83, 119, 105,
				116, 99, 104, 101, 114, 0, 0, 0, 0, 44,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 73,
				110, 116, 101, 114, 97, 99, 116, 105, 111, 110,
				83, 121, 115, 116, 101, 109, 46, 83, 97, 109,
				112, 108, 101, 124, 83, 113, 117, 105, 115, 104,
				121, 84, 111, 121, 0, 0, 0, 0, 35, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 83, 110, 97, 112,
				84, 117, 114, 110, 0, 0, 0, 0, 59, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 65, 108, 108, 111,
				119, 84, 101, 108, 101, 112, 111, 114, 116, 87,
				104, 105, 108, 101, 65, 116, 116, 97, 99, 104,
				101, 100, 84, 111, 72, 97, 110, 100, 0, 0,
				0, 0, 40, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 73, 110, 116, 101, 114, 97, 99, 116,
				105, 111, 110, 83, 121, 115, 116, 101, 109, 124,
				67, 104, 97, 112, 101, 114, 111, 110, 101, 73,
				110, 102, 111, 0, 0, 0, 0, 46, 86, 97,
				108, 118, 101, 46, 86, 82, 46, 73, 110, 116,
				101, 114, 97, 99, 116, 105, 111, 110, 83, 121,
				115, 116, 101, 109, 124, 73, 103, 110, 111, 114,
				101, 84, 101, 108, 101, 112, 111, 114, 116, 84,
				114, 97, 99, 101, 0, 0, 0, 0, 35, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 84, 101, 108, 101,
				112, 111, 114, 116, 0, 0, 0, 0, 38, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 73, 110,
				116, 101, 114, 97, 99, 116, 105, 111, 110, 83,
				121, 115, 116, 101, 109, 124, 84, 101, 108, 101,
				112, 111, 114, 116, 65, 114, 99, 0, 0, 0,
				0, 39, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 73, 110, 116, 101, 114, 97, 99, 116, 105,
				111, 110, 83, 121, 115, 116, 101, 109, 124, 84,
				101, 108, 101, 112, 111, 114, 116, 65, 114, 101,
				97, 0, 0, 0, 0, 45, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 84, 101, 108, 101, 112, 111, 114,
				116, 77, 97, 114, 107, 101, 114, 66, 97, 115,
				101, 0, 0, 0, 0, 40, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 73, 110, 116, 101, 114,
				97, 99, 116, 105, 111, 110, 83, 121, 115, 116,
				101, 109, 124, 84, 101, 108, 101, 112, 111, 114,
				116, 80, 111, 105, 110, 116, 0, 0, 0, 0,
				44, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				73, 110, 116, 101, 114, 97, 99, 116, 105, 111,
				110, 83, 121, 115, 116, 101, 109, 124, 84, 101,
				108, 101, 112, 111, 114, 116, 85, 82, 80, 72,
				101, 108, 112, 101, 114, 0, 0, 0, 0, 16,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 0, 0, 0, 0,
				26, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 66, 101,
				104, 97, 118, 105, 111, 117, 114, 0, 0, 0,
				0, 23, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 67,
				97, 109, 101, 114, 97, 0, 0, 0, 0, 27,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 67, 97, 109,
				101, 114, 97, 70, 108, 105, 112, 0, 0, 0,
				0, 27, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 67,
				97, 109, 101, 114, 97, 77, 97, 115, 107, 0,
				0, 0, 0, 21, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 69, 97, 114, 115, 0, 0, 0, 0, 36,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 69, 110, 117, 109,
				69, 113, 117, 97, 108, 105, 116, 121, 67, 111,
				109, 112, 97, 114, 101, 114, 0, 0, 0, 0,
				22, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				124, 66, 111, 120, 65, 118, 111, 105, 100, 97,
				110, 99, 101, 0, 0, 0, 0, 39, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 73, 110, 112, 117, 116,
				95, 83, 111, 117, 114, 99, 101, 115, 95, 67,
				111, 109, 112, 97, 114, 101, 114, 0, 0, 0,
				0, 23, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 69,
				118, 101, 110, 116, 115, 1, 0, 0, 0, 30,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 83,
				116, 101, 97, 109, 86, 82, 95, 69, 118, 101,
				110, 116, 115, 124, 65, 99, 116, 105, 111, 110,
				0, 0, 0, 0, 36, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 83, 116, 101, 97, 109, 86,
				82, 95, 69, 118, 101, 110, 116, 115, 124, 65,
				99, 116, 105, 111, 110, 78, 111, 65, 114, 103,
				115, 1, 0, 0, 0, 30, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 83, 116, 101, 97, 109,
				86, 82, 95, 69, 118, 101, 110, 116, 115, 124,
				65, 99, 116, 105, 111, 110, 1, 0, 0, 0,
				30, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				83, 116, 101, 97, 109, 86, 82, 95, 69, 118,
				101, 110, 116, 115, 124, 65, 99, 116, 105, 111,
				110, 1, 0, 0, 0, 30, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 83, 116, 101, 97, 109,
				86, 82, 95, 69, 118, 101, 110, 116, 115, 124,
				65, 99, 116, 105, 111, 110, 1, 0, 0, 0,
				29, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				83, 116, 101, 97, 109, 86, 82, 95, 69, 118,
				101, 110, 116, 115, 124, 69, 118, 101, 110, 116,
				1, 0, 0, 0, 29, 86, 97, 108, 118, 101,
				46, 86, 82, 46, 83, 116, 101, 97, 109, 86,
				82, 95, 69, 118, 101, 110, 116, 115, 124, 69,
				118, 101, 110, 116, 1, 0, 0, 0, 29, 86,
				97, 108, 118, 101, 46, 86, 82, 46, 83, 116,
				101, 97, 109, 86, 82, 95, 69, 118, 101, 110,
				116, 115, 124, 69, 118, 101, 110, 116, 1, 0,
				0, 0, 29, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 83, 116, 101, 97, 109, 86, 82, 95,
				69, 118, 101, 110, 116, 115, 124, 69, 118, 101,
				110, 116, 0, 0, 0, 0, 31, 86, 97, 108,
				118, 101, 46, 86, 82, 124, 83, 116, 101, 97,
				109, 86, 82, 95, 69, 120, 116, 101, 114, 110,
				97, 108, 67, 97, 109, 101, 114, 97, 0, 0,
				0, 0, 38, 86, 97, 108, 118, 101, 46, 86,
				82, 46, 83, 116, 101, 97, 109, 86, 82, 95,
				69, 120, 116, 101, 114, 110, 97, 108, 67, 97,
				109, 101, 114, 97, 124, 67, 111, 110, 102, 105,
				103, 0, 0, 0, 0, 45, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 69, 120, 116, 101, 114, 110, 97,
				108, 67, 97, 109, 101, 114, 97, 95, 76, 101,
				103, 97, 99, 121, 77, 97, 110, 97, 103, 101,
				114, 0, 0, 0, 0, 21, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 70, 97, 100, 101, 0, 0, 0,
				0, 24, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 70,
				114, 117, 115, 116, 117, 109, 0, 0, 0, 0,
				19, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 73, 75,
				0, 0, 0, 0, 26, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 76, 111, 97, 100, 76, 101, 118, 101,
				108, 0, 0, 0, 0, 21, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 77, 101, 110, 117, 0, 0, 0,
				0, 24, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 79,
				118, 101, 114, 108, 97, 121, 0, 0, 0, 0,
				44, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				83, 116, 101, 97, 109, 86, 82, 95, 79, 118,
				101, 114, 108, 97, 121, 124, 73, 110, 116, 101,
				114, 115, 101, 99, 116, 105, 111, 110, 82, 101,
				115, 117, 108, 116, 115, 0, 0, 0, 0, 25,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 80, 108, 97,
				121, 65, 114, 101, 97, 0, 0, 0, 0, 23,
				86, 97, 108, 118, 101, 46, 86, 82, 124, 83,
				116, 101, 97, 109, 86, 82, 95, 82, 101, 110,
				100, 101, 114, 0, 0, 0, 0, 28, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 82, 101, 110, 100, 101,
				114, 77, 111, 100, 101, 108, 0, 0, 0, 0,
				40, 86, 97, 108, 118, 101, 46, 86, 82, 46,
				83, 116, 101, 97, 109, 86, 82, 95, 82, 101,
				110, 100, 101, 114, 77, 111, 100, 101, 108, 124,
				82, 101, 110, 100, 101, 114, 77, 111, 100, 101,
				108, 0, 0, 0, 0, 55, 86, 97, 108, 118,
				101, 46, 86, 82, 46, 83, 116, 101, 97, 109,
				86, 82, 95, 82, 101, 110, 100, 101, 114, 77,
				111, 100, 101, 108, 124, 82, 101, 110, 100, 101,
				114, 77, 111, 100, 101, 108, 73, 110, 116, 101,
				114, 102, 97, 99, 101, 72, 111, 108, 100, 101,
				114, 0, 0, 0, 0, 27, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 82, 105, 110, 103, 66, 117, 102,
				102, 101, 114, 0, 0, 0, 0, 30, 86, 97,
				108, 118, 101, 46, 86, 82, 124, 83, 116, 101,
				97, 109, 86, 82, 95, 72, 105, 115, 116, 111,
				114, 121, 66, 117, 102, 102, 101, 114, 0, 0,
				0, 0, 28, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				72, 105, 115, 116, 111, 114, 121, 83, 116, 101,
				112, 0, 0, 0, 0, 25, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 83, 101, 116, 116, 105, 110, 103,
				115, 0, 0, 0, 0, 23, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 83, 107, 121, 98, 111, 120, 0,
				0, 0, 0, 36, 86, 97, 108, 118, 101, 46,
				86, 82, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 83, 112, 104, 101, 114, 105, 99, 97, 108,
				80, 114, 111, 106, 101, 99, 116, 105, 111, 110,
				0, 0, 0, 0, 30, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 84, 114, 97, 99, 107, 101, 100, 67,
				97, 109, 101, 114, 97, 0, 0, 0, 0, 49,
				86, 97, 108, 118, 101, 46, 86, 82, 46, 83,
				116, 101, 97, 109, 86, 82, 95, 84, 114, 97,
				99, 107, 101, 100, 67, 97, 109, 101, 114, 97,
				124, 86, 105, 100, 101, 111, 83, 116, 114, 101,
				97, 109, 84, 101, 120, 116, 117, 114, 101, 0,
				0, 0, 0, 42, 86, 97, 108, 118, 101, 46,
				86, 82, 46, 83, 116, 101, 97, 109, 86, 82,
				95, 84, 114, 97, 99, 107, 101, 100, 67, 97,
				109, 101, 114, 97, 124, 86, 105, 100, 101, 111,
				83, 116, 114, 101, 97, 109, 0, 0, 0, 0,
				30, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 84, 114,
				97, 99, 107, 101, 100, 79, 98, 106, 101, 99,
				116, 0, 0, 0, 0, 41, 86, 97, 108, 118,
				101, 46, 86, 82, 124, 83, 116, 101, 97, 109,
				86, 82, 95, 84, 114, 97, 99, 107, 105, 110,
				103, 82, 101, 102, 101, 114, 101, 110, 99, 101,
				77, 97, 110, 97, 103, 101, 114, 0, 0, 0,
				0, 65, 86, 97, 108, 118, 101, 46, 86, 82,
				46, 83, 116, 101, 97, 109, 86, 82, 95, 84,
				114, 97, 99, 107, 105, 110, 103, 82, 101, 102,
				101, 114, 101, 110, 99, 101, 77, 97, 110, 97,
				103, 101, 114, 124, 84, 114, 97, 99, 107, 105,
				110, 103, 82, 101, 102, 101, 114, 101, 110, 99,
				101, 79, 98, 106, 101, 99, 116, 0, 0, 0,
				0, 14, 124, 83, 116, 101, 97, 109, 86, 82,
				95, 85, 116, 105, 108, 115, 0, 0, 0, 0,
				19, 83, 116, 101, 97, 109, 86, 82, 95, 85,
				116, 105, 108, 115, 124, 69, 118, 101, 110, 116,
				0, 0, 0, 0, 28, 83, 116, 101, 97, 109,
				86, 82, 95, 85, 116, 105, 108, 115, 124, 82,
				105, 103, 105, 100, 84, 114, 97, 110, 115, 102,
				111, 114, 109
			},
			TotalFiles = 170,
			TotalTypes = 271,
			IsEditorOnly = false
		};
	}
}
namespace Valve.VR
{
	public class SteamVR_CameraHelper : MonoBehaviour
	{
		private void Start()
		{
			if (base.gameObject.GetComponent<TrackedPoseDriver>() == null)
			{
				base.gameObject.AddComponent<TrackedPoseDriver>();
			}
		}
	}
	[Serializable]
	public class SteamVR_Behaviour_BooleanEvent : UnityEvent<SteamVR_Behaviour_Boolean, SteamVR_Input_Sources, bool>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_PoseEvent : UnityEvent<SteamVR_Behaviour_Pose, SteamVR_Input_Sources>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Pose_ConnectedChangedEvent : UnityEvent<SteamVR_Behaviour_Pose, SteamVR_Input_Sources, bool>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Pose_DeviceIndexChangedEvent : UnityEvent<SteamVR_Behaviour_Pose, SteamVR_Input_Sources, int>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Pose_TrackingChangedEvent : UnityEvent<SteamVR_Behaviour_Pose, SteamVR_Input_Sources, ETrackingResult>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_SingleEvent : UnityEvent<SteamVR_Behaviour_Single, SteamVR_Input_Sources, float, float>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_SkeletonEvent : UnityEvent<SteamVR_Behaviour_Skeleton, SteamVR_Input_Sources>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Skeleton_ConnectedChangedEvent : UnityEvent<SteamVR_Behaviour_Skeleton, SteamVR_Input_Sources, bool>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Skeleton_TrackingChangedEvent : UnityEvent<SteamVR_Behaviour_Skeleton, SteamVR_Input_Sources, ETrackingResult>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Vector2Event : UnityEvent<SteamVR_Behaviour_Vector2, SteamVR_Input_Sources, Vector2, Vector2>
	{
	}
	[Serializable]
	public class SteamVR_Behaviour_Vector3Event : UnityEvent<SteamVR_Behaviour_Vector3, SteamVR_Input_Sources, Vector3, Vector3>
	{
	}
	[Serializable]
	public abstract class SteamVR_Action<SourceMap, SourceElement> : SteamVR_Action, ISteamVR_Action, ISteamVR_Action_Source where SourceMap : SteamVR_Action_Source_Map<SourceElement>, new() where SourceElement : SteamVR_Action_Source, new()
	{
		[NonSerialized]
		protected SourceMap sourceMap;

		[NonSerialized]
		protected bool initialized;

		public virtual SourceElement this[SteamVR_Input_Sources inputSource] => sourceMap[inputSource];

		public override string fullPath => sourceMap.fullPath;

		public override ulong handle => sourceMap.handle;

		public override SteamVR_ActionSet actionSet => sourceMap.actionSet;

		public override SteamVR_ActionDirections direction => sourceMap.direction;

		public override bool active => sourceMap[SteamVR_Input_Sources.Any].active;

		public override bool lastActive => sourceMap[SteamVR_Input_Sources.Any].lastActive;

		public override bool activeBinding => sourceMap[SteamVR_Input_Sources.Any].activeBinding;

		public override bool lastActiveBinding => sourceMap[SteamVR_Input_Sources.Any].lastActiveBinding;

		public override void PreInitialize(string newActionPath)
		{
			actionPath = newActionPath;
			sourceMap = new SourceMap();
			sourceMap.PreInitialize(this, actionPath);
			initialized = true;
		}

		protected override void CreateUninitialized(string newActionPath, bool caseSensitive)
		{
			actionPath = newActionPath;
			sourceMap = new SourceMap();
			sourceMap.PreInitialize(this, actionPath, throwErrors: false);
			needsReinit = true;
			initialized = false;
		}

		protected override void CreateUninitialized(string newActionSet, SteamVR_ActionDirections direction, string newAction, bool caseSensitive)
		{
			actionPath = SteamVR_Input_ActionFile_Action.CreateNewName(newActionSet, direction, newAction);
			sourceMap = new SourceMap();
			sourceMap.PreInitialize(this, actionPath, throwErrors: false);
			needsReinit = true;
			initialized = false;
		}

		public override string TryNeedsInitData()
		{
			if (needsReinit && actionPath != null)
			{
				SteamVR_Action steamVR_Action = SteamVR_Action.FindExistingActionForPartialPath(actionPath);
				if (!(steamVR_Action == null))
				{
					actionPath = steamVR_Action.fullPath;
					sourceMap = (SourceMap)steamVR_Action.GetSourceMap();
					initialized = true;
					needsReinit = false;
					return actionPath;
				}
				sourceMap = null;
			}
			return null;
		}

		public override void Initialize(bool createNew = false, bool throwErrors = true)
		{
			if (needsReinit)
			{
				TryNeedsInitData();
			}
			if (createNew)
			{
				sourceMap.Initialize();
			}
			else
			{
				sourceMap = SteamVR_Input.GetActionDataFromPath<SourceMap>(actionPath);
				_ = sourceMap;
			}
			initialized = true;
		}

		public override SteamVR_Action_Source_Map GetSourceMap()
		{
			return sourceMap;
		}

		protected override void InitializeCopy(string newActionPath, SteamVR_Action_Source_Map newData)
		{
			actionPath = newActionPath;
			sourceMap = (SourceMap)newData;
			initialized = true;
		}

		protected void InitAfterDeserialize()
		{
			if (sourceMap != null)
			{
				if (sourceMap.fullPath != actionPath)
				{
					needsReinit = true;
					TryNeedsInitData();
				}
				if (string.IsNullOrEmpty(actionPath))
				{
					sourceMap = null;
				}
			}
			if (!initialized)
			{
				Initialize(false, false);
			}
		}

		public override bool GetActive(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].active;
		}

		public override bool GetActiveBinding(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].activeBinding;
		}

		public override bool GetLastActive(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastActive;
		}

		public override bool GetLastActiveBinding(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastActiveBinding;
		}
	}
	[Serializable]
	public abstract class SteamVR_Action : IEquatable<SteamVR_Action>, ISteamVR_Action, ISteamVR_Action_Source
	{
		[SerializeField]
		protected string actionPath;

		[SerializeField]
		protected bool needsReinit;

		public static bool startUpdatingSourceOnAccess = true;

		[NonSerialized]
		private string cachedShortName;

		public abstract string fullPath { get; }

		public abstract ulong handle { get; }

		public abstract SteamVR_ActionSet actionSet { get; }

		public abstract SteamVR_ActionDirections direction { get; }

		public bool setActive => actionSet.IsActive();

		public abstract bool active { get; }

		public abstract bool activeBinding { get; }

		public abstract bool lastActive { get; }

		public abstract bool lastActiveBinding { get; }

		public SteamVR_Action()
		{
		}

		public static CreateType Create<CreateType>(string newActionPath) where CreateType : SteamVR_Action, new()
		{
			CreateType val = new CreateType();
			val.PreInitialize(newActionPath);
			return val;
		}

		public static CreateType CreateUninitialized<CreateType>(string setName, SteamVR_ActionDirections direction, string newActionName, bool caseSensitive) where CreateType : SteamVR_Action, new()
		{
			CreateType val = new CreateType();
			val.CreateUninitialized(setName, direction, newActionName, caseSensitive);
			return val;
		}

		public static CreateType CreateUninitialized<CreateType>(string actionPath, bool caseSensitive) where CreateType : SteamVR_Action, new()
		{
			CreateType val = new CreateType();
			val.CreateUninitialized(actionPath, caseSensitive);
			return val;
		}

		public CreateType GetCopy<CreateType>() where CreateType : SteamVR_Action, new()
		{
			if (SteamVR_Input.ShouldMakeCopy())
			{
				CreateType val = new CreateType();
				val.InitializeCopy(actionPath, GetSourceMap());
				return val;
			}
			return (CreateType)this;
		}

		public abstract string TryNeedsInitData();

		protected abstract void InitializeCopy(string newActionPath, SteamVR_Action_Source_Map newData);

		public abstract void PreInitialize(string newActionPath);

		protected abstract void CreateUninitialized(string newActionPath, bool caseSensitive);

		protected abstract void CreateUninitialized(string newActionSet, SteamVR_ActionDirections direction, string newAction, bool caseSensitive);

		public abstract void Initialize(bool createNew = false, bool throwNotSetError = true);

		public abstract float GetTimeLastChanged(SteamVR_Input_Sources inputSource);

		public abstract SteamVR_Action_Source_Map GetSourceMap();

		public abstract bool GetActive(SteamVR_Input_Sources inputSource);

		public bool GetSetActive(SteamVR_Input_Sources inputSource)
		{
			return actionSet.IsActive(inputSource);
		}

		public abstract bool GetActiveBinding(SteamVR_Input_Sources inputSource);

		public abstract bool GetLastActive(SteamVR_Input_Sources inputSource);

		public abstract bool GetLastActiveBinding(SteamVR_Input_Sources inputSource);

		public string GetPath()
		{
			return actionPath;
		}

		public abstract bool IsUpdating(SteamVR_Input_Sources inputSource);

		public override int GetHashCode()
		{
			if (actionPath == null)
			{
				return 0;
			}
			return actionPath.GetHashCode();
		}

		public bool Equals(SteamVR_Action other)
		{
			if ((object)other == null)
			{
				return false;
			}
			return actionPath == other.actionPath;
		}

		public override bool Equals(object other)
		{
			if (other == null)
			{
				if (string.IsNullOrEmpty(actionPath))
				{
					return true;
				}
				if (GetSourceMap() == null)
				{
					return true;
				}
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (other is SteamVR_Action)
			{
				return Equals((SteamVR_Action)other);
			}
			return false;
		}

		public static bool operator !=(SteamVR_Action action1, SteamVR_Action action2)
		{
			return !(action1 == action2);
		}

		public static bool operator ==(SteamVR_Action action1, SteamVR_Action action2)
		{
			bool flag = (object)action1 == null || string.IsNullOrEmpty(action1.actionPath) || action1.GetSourceMap() == null;
			bool flag2 = (object)action2 == null || string.IsNullOrEmpty(action2.actionPath) || action2.GetSourceMap() == null;
			if (flag && flag2)
			{
				return true;
			}
			if (flag != flag2)
			{
				return false;
			}
			return action1.Equals(action2);
		}

		public static SteamVR_Action FindExistingActionForPartialPath(string path)
		{
			if (string.IsNullOrEmpty(path) || path.IndexOf('/') == -1)
			{
				return null;
			}
			string[] array = path.Split('/');
			if (array.Length >= 5 && string.IsNullOrEmpty(array[2]))
			{
				string actionSetName = array[2];
				string actionName = array[4];
				return SteamVR_Input.GetBaseAction(actionSetName, actionName);
			}
			return SteamVR_Input.GetBaseActionFromPath(path);
		}

		public string GetShortName()
		{
			if (cachedShortName == null)
			{
				cachedShortName = SteamVR_Input_ActionFile.GetShortName(fullPath);
			}
			return cachedShortName;
		}

		public void ShowOrigins()
		{
			OpenVR.Input.ShowActionOrigins(actionSet.handle, handle);
		}

		public void HideOrigins()
		{
			OpenVR.Input.ShowActionOrigins(0uL, 0uL);
		}
	}
	public abstract class SteamVR_Action_Source_Map<SourceElement> : SteamVR_Action_Source_Map where SourceElement : SteamVR_Action_Source, new()
	{
		protected SourceElement[] sources = new SourceElement[SteamVR_Input_Source.numSources];

		public SourceElement this[SteamVR_Input_Sources inputSource] => GetSourceElementForIndexer(inputSource);

		protected virtual void OnAccessSource(SteamVR_Input_Sources inputSource)
		{
		}

		public override void Initialize()
		{
			base.Initialize();
			for (int i = 0; i < sources.Length; i++)
			{
				if (sources[i] != null)
				{
					sources[i].Initialize();
				}
			}
		}

		protected override void PreinitializeMap(SteamVR_Input_Sources inputSource, SteamVR_Action wrappingAction)
		{
			sources[(int)inputSource] = new SourceElement();
			sources[(int)inputSource].Preinitialize(wrappingAction, inputSource);
		}

		protected virtual SourceElement GetSourceElementForIndexer(SteamVR_Input_Sources inputSource)
		{
			OnAccessSource(inputSource);
			return sources[(int)inputSource];
		}
	}
	public abstract class SteamVR_Action_Source_Map
	{
		public SteamVR_Action action;

		private static string inLowered = "IN".ToLower(CultureInfo.CurrentCulture);

		private static string outLowered = "OUT".ToLower(CultureInfo.CurrentCulture);

		public string fullPath { get; protected set; }

		public ulong handle { get; protected set; }

		public SteamVR_ActionSet actionSet { get; protected set; }

		public SteamVR_ActionDirections direction { get; protected set; }

		public virtual void PreInitialize(SteamVR_Action wrappingAction, string actionPath, bool throwErrors = true)
		{
			fullPath = actionPath;
			action = wrappingAction;
			actionSet = SteamVR_Input.GetActionSetFromPath(GetActionSetPath());
			direction = GetActionDirection();
			SteamVR_Input_Sources[] allSources = SteamVR_Input_Source.GetAllSources();
			for (int i = 0; i < allSources.Length; i++)
			{
				PreinitializeMap(allSources[i], wrappingAction);
			}
		}

		protected abstract void PreinitializeMap(SteamVR_Input_Sources inputSource, SteamVR_Action wrappingAction);

		public virtual void Initialize()
		{
			ulong pHandle = 0uL;
			EVRInputError actionHandle = OpenVR.Input.GetActionHandle(fullPath.ToLowerInvariant(), ref pHandle);
			handle = pHandle;
			if (actionHandle != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetActionHandle (" + fullPath.ToLowerInvariant() + ") error: " + actionHandle);
			}
		}

		private string GetActionSetPath()
		{
			int startIndex = fullPath.IndexOf('/', 1) + 1;
			int length = fullPath.IndexOf('/', startIndex);
			return fullPath.Substring(0, length);
		}

		private SteamVR_ActionDirections GetActionDirection()
		{
			int startIndex = fullPath.IndexOf('/', 1) + 1;
			int num = fullPath.IndexOf('/', startIndex);
			int length = fullPath.IndexOf('/', num + 1) - num - 1;
			string text = fullPath.Substring(num + 1, length);
			if (text == inLowered)
			{
				return SteamVR_ActionDirections.In;
			}
			if (text == outLowered)
			{
				return SteamVR_ActionDirections.Out;
			}
			UnityEngine.Debug.LogError("Could not find match for direction: " + text);
			return SteamVR_ActionDirections.In;
		}
	}
	public abstract class SteamVR_Action_Source : ISteamVR_Action_Source
	{
		protected ulong inputSourceHandle;

		protected SteamVR_Action action;

		public string fullPath => action.fullPath;

		public ulong handle => action.handle;

		public SteamVR_ActionSet actionSet => action.actionSet;

		public SteamVR_ActionDirections direction => action.direction;

		public SteamVR_Input_Sources inputSource { get; protected set; }

		public bool setActive => actionSet.IsActive(inputSource);

		public abstract bool active { get; }

		public abstract bool activeBinding { get; }

		public abstract bool lastActive { get; protected set; }

		public abstract bool lastActiveBinding { get; }

		public virtual void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			action = wrappingAction;
			inputSource = forInputSource;
		}

		public SteamVR_Action_Source()
		{
		}

		public virtual void Initialize()
		{
			inputSourceHandle = SteamVR_Input_Source.GetHandle(inputSource);
		}
	}
	public interface ISteamVR_Action : ISteamVR_Action_Source
	{
		bool GetActive(SteamVR_Input_Sources inputSource);

		string GetShortName();
	}
	public interface ISteamVR_Action_Source
	{
		bool active { get; }

		bool activeBinding { get; }

		bool lastActive { get; }

		bool lastActiveBinding { get; }

		string fullPath { get; }

		ulong handle { get; }

		SteamVR_ActionSet actionSet { get; }

		SteamVR_ActionDirections direction { get; }
	}
	public enum SteamVR_ActionDirections
	{
		In,
		Out
	}
	[Serializable]
	public class SteamVR_ActionSet : IEquatable<SteamVR_ActionSet>, ISteamVR_ActionSet, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string actionSetPath;

		[NonSerialized]
		protected SteamVR_ActionSet_Data setData;

		[NonSerialized]
		protected bool initialized;

		public SteamVR_Action[] allActions
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.allActions;
			}
		}

		public ISteamVR_Action_In[] nonVisualInActions
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.nonVisualInActions;
			}
		}

		public ISteamVR_Action_In[] visualActions
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.visualActions;
			}
		}

		public SteamVR_Action_Pose[] poseActions
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.poseActions;
			}
		}

		public SteamVR_Action_Skeleton[] skeletonActions
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.skeletonActions;
			}
		}

		public ISteamVR_Action_Out[] outActionArray
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.outActionArray;
			}
		}

		public string fullPath
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.fullPath;
			}
		}

		public string usage
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.usage;
			}
		}

		public ulong handle
		{
			get
			{
				if (!initialized)
				{
					Initialize();
				}
				return setData.handle;
			}
		}

		public static CreateType Create<CreateType>(string newSetPath) where CreateType : SteamVR_ActionSet, new()
		{
			CreateType val = new CreateType();
			val.PreInitialize(newSetPath);
			return val;
		}

		public static CreateType CreateFromName<CreateType>(string newSetName) where CreateType : SteamVR_ActionSet, new()
		{
			CreateType val = new CreateType();
			val.PreInitialize(SteamVR_Input_ActionFile_ActionSet.GetPathFromName(newSetName));
			return val;
		}

		public void PreInitialize(string newActionPath)
		{
			actionSetPath = newActionPath;
			setData = new SteamVR_ActionSet_Data();
			setData.fullPath = actionSetPath;
			setData.PreInitialize();
			initialized = true;
		}

		public virtual void FinishPreInitialize()
		{
			setData.FinishPreInitialize();
		}

		public virtual void Initialize(bool createNew = false, bool throwErrors = true)
		{
			if (createNew)
			{
				setData.Initialize();
			}
			else
			{
				setData = SteamVR_Input.GetActionSetDataFromPath(actionSetPath);
				_ = setData;
			}
			initialized = true;
		}

		public string GetPath()
		{
			return actionSetPath;
		}

		public bool IsActive(SteamVR_Input_Sources source = SteamVR_Input_Sources.Any)
		{
			return setData.IsActive(source);
		}

		public float GetTimeLastChanged(SteamVR_Input_Sources source = SteamVR_Input_Sources.Any)
		{
			return setData.GetTimeLastChanged(source);
		}

		public void Activate(SteamVR_Input_Sources activateForSource = SteamVR_Input_Sources.Any, int priority = 0, bool disableAllOtherActionSets = false)
		{
			setData.Activate(activateForSource, priority, disableAllOtherActionSets);
		}

		public void Deactivate(SteamVR_Input_Sources forSource = SteamVR_Input_Sources.Any)
		{
			setData.Deactivate(forSource);
		}

		public string GetShortName()
		{
			return setData.GetShortName();
		}

		public bool ShowBindingHints(ISteamVR_Action_In originToHighlight = null)
		{
			if (originToHighlight == null)
			{
				return SteamVR_Input.ShowBindingHints(this);
			}
			return SteamVR_Input.ShowBindingHints(originToHighlight);
		}

		public bool ReadRawSetActive(SteamVR_Input_Sources inputSource)
		{
			return setData.ReadRawSetActive(inputSource);
		}

		public float ReadRawSetLastChanged(SteamVR_Input_Sources inputSource)
		{
			return setData.ReadRawSetLastChanged(inputSource);
		}

		public int ReadRawSetPriority(SteamVR_Input_Sources inputSource)
		{
			return setData.ReadRawSetPriority(inputSource);
		}

		public SteamVR_ActionSet_Data GetActionSetData()
		{
			return setData;
		}

		public CreateType GetCopy<CreateType>() where CreateType : SteamVR_ActionSet, new()
		{
			if (SteamVR_Input.ShouldMakeCopy())
			{
				return new CreateType
				{
					actionSetPath = actionSetPath,
					setData = setData,
					initialized = true
				};
			}
			return (CreateType)this;
		}

		public bool Equals(SteamVR_ActionSet other)
		{
			if ((object)other == null)
			{
				return false;
			}
			return actionSetPath == other.actionSetPath;
		}

		public override bool Equals(object other)
		{
			if (other == null)
			{
				if (string.IsNullOrEmpty(actionSetPath))
				{
					return true;
				}
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (other is SteamVR_ActionSet)
			{
				return Equals((SteamVR_ActionSet)other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (actionSetPath == null)
			{
				return 0;
			}
			return actionSetPath.GetHashCode();
		}

		public static bool operator !=(SteamVR_ActionSet set1, SteamVR_ActionSet set2)
		{
			return !(set1 == set2);
		}

		public static bool operator ==(SteamVR_ActionSet set1, SteamVR_ActionSet set2)
		{
			bool flag = (object)set1 == null || string.IsNullOrEmpty(set1.actionSetPath) || set1.GetActionSetData() == null;
			bool flag2 = (object)set2 == null || string.IsNullOrEmpty(set2.actionSetPath) || set2.GetActionSetData() == null;
			if (flag && flag2)
			{
				return true;
			}
			if (flag != flag2)
			{
				return false;
			}
			return set1.Equals(set2);
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (setData != null && setData.fullPath != actionSetPath)
			{
				setData = SteamVR_Input.GetActionSetDataFromPath(actionSetPath);
			}
			if (!initialized)
			{
				Initialize(createNew: false, throwErrors: false);
			}
		}
	}
	public class SteamVR_ActionSet_Data : ISteamVR_ActionSet
	{
		protected bool[] rawSetActive = new bool[SteamVR_Input_Source.numSources];

		protected float[] rawSetLastChanged = new float[SteamVR_Input_Source.numSources];

		protected int[] rawSetPriority = new int[SteamVR_Input_Source.numSources];

		protected bool initialized;

		private string cachedShortName;

		public SteamVR_Action[] allActions { get; set; }

		public ISteamVR_Action_In[] nonVisualInActions { get; set; }

		public ISteamVR_Action_In[] visualActions { get; set; }

		public SteamVR_Action_Pose[] poseActions { get; set; }

		public SteamVR_Action_Skeleton[] skeletonActions { get; set; }

		public ISteamVR_Action_Out[] outActionArray { get; set; }

		public string fullPath { get; set; }

		public string usage { get; set; }

		public ulong handle { get; set; }

		public void PreInitialize()
		{
		}

		public void FinishPreInitialize()
		{
			List<SteamVR_Action> list = new List<SteamVR_Action>();
			List<ISteamVR_Action_In> list2 = new List<ISteamVR_Action_In>();
			List<ISteamVR_Action_In> list3 = new List<ISteamVR_Action_In>();
			List<SteamVR_Action_Pose> list4 = new List<SteamVR_Action_Pose>();
			List<SteamVR_Action_Skeleton> list5 = new List<SteamVR_Action_Skeleton>();
			List<ISteamVR_Action_Out> list6 = new List<ISteamVR_Action_Out>();
			if (SteamVR_Input.actions == null)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Input]</b> Actions not initialized!");
				return;
			}
			for (int i = 0; i < SteamVR_Input.actions.Length; i++)
			{
				SteamVR_Action steamVR_Action = SteamVR_Input.actions[i];
				if (steamVR_Action.actionSet.GetActionSetData() == this)
				{
					list.Add(steamVR_Action);
					if (steamVR_Action is ISteamVR_Action_Boolean || steamVR_Action is ISteamVR_Action_Single || steamVR_Action is ISteamVR_Action_Vector2 || steamVR_Action is ISteamVR_Action_Vector3)
					{
						list2.Add((ISteamVR_Action_In)steamVR_Action);
					}
					else if (steamVR_Action is SteamVR_Action_Pose)
					{
						list3.Add((ISteamVR_Action_In)steamVR_Action);
						list4.Add((SteamVR_Action_Pose)steamVR_Action);
					}
					else if (steamVR_Action is SteamVR_Action_Skeleton)
					{
						list3.Add((ISteamVR_Action_In)steamVR_Action);
						list5.Add((SteamVR_Action_Skeleton)steamVR_Action);
					}
					else if (steamVR_Action is ISteamVR_Action_Out)
					{
						list6.Add((ISteamVR_Action_Out)steamVR_Action);
					}
					else
					{
						UnityEngine.Debug.LogError("<b>[SteamVR Input]</b> Action doesn't implement known interface: " + steamVR_Action.fullPath);
					}
				}
			}
			allActions = list.ToArray();
			nonVisualInActions = list2.ToArray();
			visualActions = list3.ToArray();
			poseActions = list4.ToArray();
			skeletonActions = list5.ToArray();
			outActionArray = list6.ToArray();
		}

		public void Initialize()
		{
			ulong pHandle = 0uL;
			EVRInputError actionSetHandle = OpenVR.Input.GetActionSetHandle(fullPath.ToLower(), ref pHandle);
			handle = pHandle;
			if (actionSetHandle != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetActionSetHandle (" + fullPath + ") error: " + actionSetHandle);
			}
			initialized = true;
		}

		public bool IsActive(SteamVR_Input_Sources source = SteamVR_Input_Sources.Any)
		{
			if (initialized)
			{
				if (!rawSetActive[(int)source])
				{
					return rawSetActive[0];
				}
				return true;
			}
			return false;
		}

		public float GetTimeLastChanged(SteamVR_Input_Sources source = SteamVR_Input_Sources.Any)
		{
			if (initialized)
			{
				return rawSetLastChanged[(int)source];
			}
			return 0f;
		}

		public void Activate(SteamVR_Input_Sources activateForSource = SteamVR_Input_Sources.Any, int priority = 0, bool disableAllOtherActionSets = false)
		{
			if (disableAllOtherActionSets)
			{
				SteamVR_ActionSet_Manager.DisableAllActionSets();
			}
			if (!rawSetActive[(int)activateForSource])
			{
				rawSetActive[(int)activateForSource] = true;
				SteamVR_ActionSet_Manager.SetChanged();
				rawSetLastChanged[(int)activateForSource] = Time.realtimeSinceStartup;
			}
			if (rawSetPriority[(int)activateForSource] != priority)
			{
				rawSetPriority[(int)activateForSource] = priority;
				SteamVR_ActionSet_Manager.SetChanged();
				rawSetLastChanged[(int)activateForSource] = Time.realtimeSinceStartup;
			}
		}

		public void Deactivate(SteamVR_Input_Sources forSource = SteamVR_Input_Sources.Any)
		{
			if (rawSetActive[(int)forSource])
			{
				rawSetLastChanged[(int)forSource] = Time.realtimeSinceStartup;
				SteamVR_ActionSet_Manager.SetChanged();
			}
			rawSetActive[(int)forSource] = false;
			rawSetPriority[(int)forSource] = 0;
		}

		public string GetShortName()
		{
			if (cachedShortName == null)
			{
				cachedShortName = SteamVR_Input_ActionFile.GetShortName(fullPath);
			}
			return cachedShortName;
		}

		public bool ReadRawSetActive(SteamVR_Input_Sources inputSource)
		{
			return rawSetActive[(int)inputSource];
		}

		public float ReadRawSetLastChanged(SteamVR_Input_Sources inputSource)
		{
			return rawSetLastChanged[(int)inputSource];
		}

		public int ReadRawSetPriority(SteamVR_Input_Sources inputSource)
		{
			return rawSetPriority[(int)inputSource];
		}
	}
	public interface ISteamVR_ActionSet
	{
		SteamVR_Action[] allActions { get; }

		ISteamVR_Action_In[] nonVisualInActions { get; }

		ISteamVR_Action_In[] visualActions { get; }

		SteamVR_Action_Pose[] poseActions { get; }

		SteamVR_Action_Skeleton[] skeletonActions { get; }

		ISteamVR_Action_Out[] outActionArray { get; }

		string fullPath { get; }

		string usage { get; }

		ulong handle { get; }

		bool ReadRawSetActive(SteamVR_Input_Sources inputSource);

		float ReadRawSetLastChanged(SteamVR_Input_Sources inputSource);

		int ReadRawSetPriority(SteamVR_Input_Sources inputSource);

		bool IsActive(SteamVR_Input_Sources source = SteamVR_Input_Sources.Any);

		float GetTimeLastChanged(SteamVR_Input_Sources source = SteamVR_Input_Sources.Any);

		void Activate(SteamVR_Input_Sources activateForSource = SteamVR_Input_Sources.Any, int priority = 0, bool disableAllOtherActionSets = false);

		void Deactivate(SteamVR_Input_Sources forSource = SteamVR_Input_Sources.Any);

		string GetShortName();
	}
	public static class SteamVR_ActionSet_Manager
	{
		public static VRActiveActionSet_t[] rawActiveActionSetArray;

		[NonSerialized]
		private static uint activeActionSetSize;

		private static bool changed;

		private static int lastFrameUpdated;

		public static string debugActiveSetListText;

		public static bool updateDebugTextInBuilds;

		public static void Initialize()
		{
			activeActionSetSize = (uint)Marshal.SizeOf(typeof(VRActiveActionSet_t));
		}

		public static void DisableAllActionSets()
		{
			for (int i = 0; i < SteamVR_Input.actionSets.Length; i++)
			{
				SteamVR_Input.actionSets[i].Deactivate();
				SteamVR_Input.actionSets[i].Deactivate(SteamVR_Input_Sources.LeftHand);
				SteamVR_Input.actionSets[i].Deactivate(SteamVR_Input_Sources.RightHand);
			}
		}

		public static void UpdateActionStates(bool force = false)
		{
			if (!force && Time.frameCount == lastFrameUpdated)
			{
				return;
			}
			lastFrameUpdated = Time.frameCount;
			if (changed)
			{
				UpdateActionSetsArray();
			}
			if (rawActiveActionSetArray != null && rawActiveActionSetArray.Length != 0 && OpenVR.Input != null)
			{
				EVRInputError eVRInputError = OpenVR.Input.UpdateActionState(rawActiveActionSetArray, activeActionSetSize);
				if (eVRInputError != EVRInputError.None)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> UpdateActionState error: " + eVRInputError);
				}
			}
		}

		public static void SetChanged()
		{
			changed = true;
		}

		private static void UpdateActionSetsArray()
		{
			List<VRActiveActionSet_t> list = new List<VRActiveActionSet_t>();
			SteamVR_Input_Sources[] allSources = SteamVR_Input_Source.GetAllSources();
			for (int i = 0; i < SteamVR_Input.actionSets.Length; i++)
			{
				SteamVR_ActionSet steamVR_ActionSet = SteamVR_Input.actionSets[i];
				foreach (SteamVR_Input_Sources inputSource in allSources)
				{
					if (steamVR_ActionSet.ReadRawSetActive(inputSource))
					{
						VRActiveActionSet_t item = new VRActiveActionSet_t
						{
							ulActionSet = steamVR_ActionSet.handle,
							nPriority = steamVR_ActionSet.ReadRawSetPriority(inputSource),
							ulRestrictedToDevice = SteamVR_Input_Source.GetHandle(inputSource)
						};
						int num = 0;
						for (num = 0; num < list.Count && list[num].nPriority <= item.nPriority; num++)
						{
						}
						list.Insert(num, item);
					}
				}
			}
			changed = false;
			rawActiveActionSetArray = list.ToArray();
			if (Application.isEditor || updateDebugTextInBuilds)
			{
				UpdateDebugText();
			}
		}

		public static SteamVR_ActionSet GetSetFromHandle(ulong handle)
		{
			for (int i = 0; i < SteamVR_Input.actionSets.Length; i++)
			{
				SteamVR_ActionSet steamVR_ActionSet = SteamVR_Input.actionSets[i];
				if (steamVR_ActionSet.handle == handle)
				{
					return steamVR_ActionSet;
				}
			}
			return null;
		}

		private static void UpdateDebugText()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < rawActiveActionSetArray.Length; i++)
			{
				VRActiveActionSet_t vRActiveActionSet_t = rawActiveActionSetArray[i];
				stringBuilder.Append(vRActiveActionSet_t.nPriority);
				stringBuilder.Append("\t");
				stringBuilder.Append(SteamVR_Input_Source.GetSource(vRActiveActionSet_t.ulRestrictedToDevice));
				stringBuilder.Append("\t");
				stringBuilder.Append(GetSetFromHandle(vRActiveActionSet_t.ulActionSet).GetShortName());
				stringBuilder.Append("\n");
			}
			debugActiveSetListText = stringBuilder.ToString();
		}
	}
	[Serializable]
	public class SteamVR_Action_Boolean : SteamVR_Action_In<SteamVR_Action_Boolean_Source_Map, SteamVR_Action_Boolean_Source>, ISteamVR_Action_Boolean, ISteamVR_Action_In_Source, ISteamVR_Action_Source, ISerializationCallbackReceiver
	{
		public delegate void StateDownHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource);

		public delegate void StateUpHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource);

		public delegate void StateHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource);

		public delegate void ActiveChangeHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState);

		public delegate void UpdateHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState);

		public bool state => sourceMap[SteamVR_Input_Sources.Any].state;

		public bool stateDown => sourceMap[SteamVR_Input_Sources.Any].stateDown;

		public bool stateUp => sourceMap[SteamVR_Input_Sources.Any].stateUp;

		public bool lastState => sourceMap[SteamVR_Input_Sources.Any].lastState;

		public bool lastStateDown => sourceMap[SteamVR_Input_Sources.Any].lastStateDown;

		public bool lastStateUp => sourceMap[SteamVR_Input_Sources.Any].lastStateUp;

		public event ChangeHandler onChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange -= value;
			}
		}

		public event UpdateHandler onUpdate
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate -= value;
			}
		}

		public event StateHandler onState
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onState += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onState -= value;
			}
		}

		public event StateDownHandler onStateDown
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onStateDown += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onStateDown -= value;
			}
		}

		public event StateUpHandler onStateUp
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onStateUp += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onStateUp -= value;
			}
		}

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public bool GetStateDown(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].stateDown;
		}

		public bool GetStateUp(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].stateUp;
		}

		public bool GetState(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].state;
		}

		public bool GetLastStateDown(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastStateDown;
		}

		public bool GetLastStateUp(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastStateUp;
		}

		public bool GetLastState(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastState;
		}

		public void AddOnActiveChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange -= functionToStopCalling;
		}

		public void AddOnActiveBindingChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange += functionToCall;
		}

		public void RemoveOnActiveBindingChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange -= functionToStopCalling;
		}

		public void AddOnChangeListener(ChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange += functionToCall;
		}

		public void RemoveOnChangeListener(ChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange -= functionToStopCalling;
		}

		public void AddOnUpdateListener(UpdateHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate += functionToCall;
		}

		public void RemoveOnUpdateListener(UpdateHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate -= functionToStopCalling;
		}

		public void AddOnStateDownListener(StateDownHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onStateDown += functionToCall;
		}

		public void RemoveOnStateDownListener(StateDownHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onStateDown -= functionToStopCalling;
		}

		public void AddOnStateUpListener(StateUpHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onStateUp += functionToCall;
		}

		public void RemoveOnStateUpListener(StateUpHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onStateUp -= functionToStopCalling;
		}

		public void RemoveAllListeners(SteamVR_Input_Sources input_Sources)
		{
			sourceMap[input_Sources].RemoveAllListeners();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}
	}
	public class SteamVR_Action_Boolean_Source_Map : SteamVR_Action_In_Source_Map<SteamVR_Action_Boolean_Source>
	{
	}
	public class SteamVR_Action_Boolean_Source : SteamVR_Action_In_Source, ISteamVR_Action_Boolean, ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		protected static uint actionData_size;

		protected InputDigitalActionData_t actionData;

		protected InputDigitalActionData_t lastActionData;

		protected SteamVR_Action_Boolean booleanAction;

		public bool state
		{
			get
			{
				if (active)
				{
					return actionData.bState;
				}
				return false;
			}
		}

		public bool stateDown
		{
			get
			{
				if (active && actionData.bState)
				{
					return actionData.bChanged;
				}
				return false;
			}
		}

		public bool stateUp
		{
			get
			{
				if (active && !actionData.bState)
				{
					return actionData.bChanged;
				}
				return false;
			}
		}

		public override bool changed
		{
			get
			{
				if (active)
				{
					return actionData.bChanged;
				}
				return false;
			}
			protected set
			{
			}
		}

		public bool lastState => lastActionData.bState;

		public bool lastStateDown
		{
			get
			{
				if (lastActionData.bState)
				{
					return lastActionData.bChanged;
				}
				return false;
			}
		}

		public bool lastStateUp
		{
			get
			{
				if (!lastActionData.bState)
				{
					return lastActionData.bChanged;
				}
				return false;
			}
		}

		public override bool lastChanged
		{
			get
			{
				return lastActionData.bChanged;
			}
			protected set
			{
			}
		}

		public override ulong activeOrigin
		{
			get
			{
				if (active)
				{
					return actionData.activeOrigin;
				}
				return 0uL;
			}
		}

		public override ulong lastActiveOrigin => lastActionData.activeOrigin;

		public override bool active
		{
			get
			{
				if (activeBinding)
				{
					return action.actionSet.IsActive(base.inputSource);
				}
				return false;
			}
		}

		public override bool activeBinding => actionData.bActive;

		public override bool lastActive { get; protected set; }

		public override bool lastActiveBinding => lastActionData.bActive;

		public event SteamVR_Action_Boolean.StateDownHandler onStateDown;

		public event SteamVR_Action_Boolean.StateUpHandler onStateUp;

		public event SteamVR_Action_Boolean.StateHandler onState;

		public event SteamVR_Action_Boolean.ActiveChangeHandler onActiveChange;

		public event SteamVR_Action_Boolean.ActiveChangeHandler onActiveBindingChange;

		public event SteamVR_Action_Boolean.ChangeHandler onChange;

		public event SteamVR_Action_Boolean.UpdateHandler onUpdate;

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			booleanAction = (SteamVR_Action_Boolean)wrappingAction;
		}

		public override void Initialize()
		{
			base.Initialize();
			if (actionData_size == 0)
			{
				actionData_size = (uint)Marshal.SizeOf(typeof(InputDigitalActionData_t));
			}
		}

		public void RemoveAllListeners()
		{
			Delegate[] invocationList;
			if (this.onStateDown != null)
			{
				invocationList = this.onStateDown.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj in array)
					{
						onStateDown -= (SteamVR_Action_Boolean.StateDownHandler)obj;
					}
				}
			}
			if (this.onStateUp != null)
			{
				invocationList = this.onStateUp.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj2 in array)
					{
						onStateUp -= (SteamVR_Action_Boolean.StateUpHandler)obj2;
					}
				}
			}
			if (this.onState == null)
			{
				return;
			}
			invocationList = this.onState.GetInvocationList();
			if (invocationList != null)
			{
				Delegate[] array = invocationList;
				foreach (Delegate obj3 in array)
				{
					onState -= (SteamVR_Action_Boolean.StateHandler)obj3;
				}
			}
		}

		public override void UpdateValue()
		{
			lastActionData = actionData;
			lastActive = active;
			EVRInputError digitalActionData = OpenVR.Input.GetDigitalActionData(action.handle, ref actionData, actionData_size, inputSourceHandle);
			if (digitalActionData != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetDigitalActionData error (" + action.fullPath + "): " + digitalActionData.ToString() + " handle: " + action.handle);
			}
			if (changed)
			{
				base.changedTime = Time.realtimeSinceStartup + actionData.fUpdateTime;
			}
			base.updateTime = Time.realtimeSinceStartup;
			if (active)
			{
				if (this.onStateDown != null && stateDown)
				{
					this.onStateDown(booleanAction, base.inputSource);
				}
				if (this.onStateUp != null && stateUp)
				{
					this.onStateUp(booleanAction, base.inputSource);
				}
				if (this.onState != null && state)
				{
					this.onState(booleanAction, base.inputSource);
				}
				if (this.onChange != null && changed)
				{
					this.onChange(booleanAction, base.inputSource, state);
				}
				if (this.onUpdate != null)
				{
					this.onUpdate(booleanAction, base.inputSource, state);
				}
			}
			if (this.onActiveBindingChange != null && lastActiveBinding != activeBinding)
			{
				this.onActiveBindingChange(booleanAction, base.inputSource, activeBinding);
			}
			if (this.onActiveChange != null && lastActive != active)
			{
				this.onActiveChange(booleanAction, base.inputSource, activeBinding);
			}
		}
	}
	public interface ISteamVR_Action_Boolean : ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		bool state { get; }

		bool stateDown { get; }

		bool stateUp { get; }

		bool lastState { get; }

		bool lastStateDown { get; }

		bool lastStateUp { get; }
	}
	[Serializable]
	public abstract class SteamVR_Action_In<SourceMap, SourceElement> : SteamVR_Action<SourceMap, SourceElement>, ISteamVR_Action_In, ISteamVR_Action, ISteamVR_Action_Source, ISteamVR_Action_In_Source where SourceMap : SteamVR_Action_In_Source_Map<SourceElement>, new() where SourceElement : SteamVR_Action_In_Source, new()
	{
		public bool changed => sourceMap[SteamVR_Input_Sources.Any].changed;

		public bool lastChanged => sourceMap[SteamVR_Input_Sources.Any].changed;

		public float changedTime => sourceMap[SteamVR_Input_Sources.Any].changedTime;

		public float updateTime => sourceMap[SteamVR_Input_Sources.Any].updateTime;

		public ulong activeOrigin => sourceMap[SteamVR_Input_Sources.Any].activeOrigin;

		public ulong lastActiveOrigin => sourceMap[SteamVR_Input_Sources.Any].lastActiveOrigin;

		public SteamVR_Input_Sources activeDevice => sourceMap[SteamVR_Input_Sources.Any].activeDevice;

		public uint trackedDeviceIndex => sourceMap[SteamVR_Input_Sources.Any].trackedDeviceIndex;

		public string renderModelComponentName => sourceMap[SteamVR_Input_Sources.Any].renderModelComponentName;

		public string localizedOriginName => sourceMap[SteamVR_Input_Sources.Any].localizedOriginName;

		public virtual void UpdateValues()
		{
			sourceMap.UpdateValues();
		}

		public virtual string GetRenderModelComponentName(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].renderModelComponentName;
		}

		public virtual SteamVR_Input_Sources GetActiveDevice(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].activeDevice;
		}

		public virtual uint GetDeviceIndex(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].trackedDeviceIndex;
		}

		public virtual bool GetChanged(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].changed;
		}

		public override float GetTimeLastChanged(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].changedTime;
		}

		public string GetLocalizedOriginPart(SteamVR_Input_Sources inputSource, params EVRInputStringBits[] localizedParts)
		{
			return sourceMap[inputSource].GetLocalizedOriginPart(localizedParts);
		}

		public string GetLocalizedOrigin(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].GetLocalizedOrigin();
		}

		public override bool IsUpdating(SteamVR_Input_Sources inputSource)
		{
			return sourceMap.IsUpdating(inputSource);
		}

		public void ForceAddSourceToUpdateList(SteamVR_Input_Sources inputSource)
		{
			sourceMap.ForceAddSourceToUpdateList(inputSource);
		}

		public string GetControllerType(SteamVR_Input_Sources inputSource)
		{
			return SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ControllerType_String, GetDeviceIndex(inputSource));
		}
	}
	public class SteamVR_Action_In_Source_Map<SourceElement> : SteamVR_Action_Source_Map<SourceElement> where SourceElement : SteamVR_Action_In_Source, new()
	{
		protected List<int> updatingSources = new List<int>();

		public bool IsUpdating(SteamVR_Input_Sources inputSource)
		{
			for (int i = 0; i < updatingSources.Count; i++)
			{
				if (inputSource == (SteamVR_Input_Sources)updatingSources[i])
				{
					return true;
				}
			}
			return false;
		}

		protected override void OnAccessSource(SteamVR_Input_Sources inputSource)
		{
			if (SteamVR_Action.startUpdatingSourceOnAccess)
			{
				ForceAddSourceToUpdateList(inputSource);
			}
		}

		public void ForceAddSourceToUpdateList(SteamVR_Input_Sources inputSource)
		{
			if (sources[(int)inputSource] == null)
			{
				sources[(int)inputSource] = new SourceElement();
			}
			if (!sources[(int)inputSource].isUpdating)
			{
				updatingSources.Add((int)inputSource);
				sources[(int)inputSource].isUpdating = true;
				if (!SteamVR_Input.isStartupFrame)
				{
					sources[(int)inputSource].UpdateValue();
				}
			}
		}

		public void UpdateValues()
		{
			for (int i = 0; i < updatingSources.Count; i++)
			{
				sources[updatingSources[i]].UpdateValue();
			}
		}
	}
	public abstract class SteamVR_Action_In_Source : SteamVR_Action_Source, ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		protected static uint inputOriginInfo_size;

		protected InputOriginInfo_t inputOriginInfo;

		protected InputOriginInfo_t lastInputOriginInfo;

		public bool isUpdating { get; set; }

		public float updateTime { get; protected set; }

		public abstract ulong activeOrigin { get; }

		public abstract ulong lastActiveOrigin { get; }

		public abstract bool changed { get; protected set; }

		public abstract bool lastChanged { get; protected set; }

		public SteamVR_Input_Sources activeDevice
		{
			get
			{
				UpdateOriginTrackedDeviceInfo();
				return SteamVR_Input_Source.GetSource(inputOriginInfo.devicePath);
			}
		}

		public uint trackedDeviceIndex
		{
			get
			{
				UpdateOriginTrackedDeviceInfo();
				return inputOriginInfo.trackedDeviceIndex;
			}
		}

		public string renderModelComponentName
		{
			get
			{
				UpdateOriginTrackedDeviceInfo();
				return inputOriginInfo.rchRenderModelComponentName;
			}
		}

		public string localizedOriginName
		{
			get
			{
				UpdateOriginTrackedDeviceInfo();
				return GetLocalizedOrigin();
			}
		}

		public float changedTime { get; protected set; }

		protected int lastOriginGetFrame { get; set; }

		public abstract void UpdateValue();

		public override void Initialize()
		{
			base.Initialize();
			if (inputOriginInfo_size == 0)
			{
				inputOriginInfo_size = (uint)Marshal.SizeOf(typeof(InputOriginInfo_t));
			}
		}

		protected void UpdateOriginTrackedDeviceInfo()
		{
			if (lastOriginGetFrame != Time.frameCount)
			{
				EVRInputError originTrackedDeviceInfo = OpenVR.Input.GetOriginTrackedDeviceInfo(activeOrigin, ref inputOriginInfo, inputOriginInfo_size);
				if (originTrackedDeviceInfo != EVRInputError.None)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetOriginTrackedDeviceInfo error (" + base.fullPath + "): " + originTrackedDeviceInfo.ToString() + " handle: " + base.handle + " activeOrigin: " + activeOrigin + " active: " + active);
				}
				lastInputOriginInfo = inputOriginInfo;
				lastOriginGetFrame = Time.frameCount;
			}
		}

		public string GetLocalizedOriginPart(params EVRInputStringBits[] localizedParts)
		{
			UpdateOriginTrackedDeviceInfo();
			if (active)
			{
				return SteamVR_Input.GetLocalizedName(activeOrigin, localizedParts);
			}
			return null;
		}

		public string GetLocalizedOrigin()
		{
			UpdateOriginTrackedDeviceInfo();
			if (active)
			{
				return SteamVR_Input.GetLocalizedName(activeOrigin, EVRInputStringBits.VRInputString_All);
			}
			return null;
		}
	}
	public interface ISteamVR_Action_In : ISteamVR_Action, ISteamVR_Action_Source, ISteamVR_Action_In_Source
	{
		void UpdateValues();

		string GetRenderModelComponentName(SteamVR_Input_Sources inputSource);

		SteamVR_Input_Sources GetActiveDevice(SteamVR_Input_Sources inputSource);

		uint GetDeviceIndex(SteamVR_Input_Sources inputSource);

		bool GetChanged(SteamVR_Input_Sources inputSource);

		string GetLocalizedOriginPart(SteamVR_Input_Sources inputSource, params EVRInputStringBits[] localizedParts);

		string GetLocalizedOrigin(SteamVR_Input_Sources inputSource);
	}
	public interface ISteamVR_Action_In_Source : ISteamVR_Action_Source
	{
		bool changed { get; }

		bool lastChanged { get; }

		float changedTime { get; }

		float updateTime { get; }

		ulong activeOrigin { get; }

		ulong lastActiveOrigin { get; }

		SteamVR_Input_Sources activeDevice { get; }

		uint trackedDeviceIndex { get; }

		string renderModelComponentName { get; }

		string localizedOriginName { get; }
	}
	[Serializable]
	public abstract class SteamVR_Action_Out<SourceMap, SourceElement> : SteamVR_Action<SourceMap, SourceElement>, ISteamVR_Action_Out, ISteamVR_Action, ISteamVR_Action_Source, ISteamVR_Action_Out_Source where SourceMap : SteamVR_Action_Source_Map<SourceElement>, new() where SourceElement : SteamVR_Action_Out_Source, new()
	{
	}
	public abstract class SteamVR_Action_Out_Source : SteamVR_Action_Source, ISteamVR_Action_Out_Source, ISteamVR_Action_Source
	{
	}
	public interface ISteamVR_Action_Out : ISteamVR_Action, ISteamVR_Action_Source, ISteamVR_Action_Out_Source
	{
	}
	public interface ISteamVR_Action_Out_Source : ISteamVR_Action_Source
	{
	}
	[Serializable]
	public class SteamVR_Action_Pose : SteamVR_Action_Pose_Base<SteamVR_Action_Pose_Source_Map<SteamVR_Action_Pose_Source>, SteamVR_Action_Pose_Source>, ISerializationCallbackReceiver
	{
		public delegate void ActiveChangeHandler(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource);

		public delegate void UpdateHandler(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource);

		public delegate void TrackingChangeHandler(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource, ETrackingResult trackingState);

		public delegate void ValidPoseChangeHandler(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource, bool validPose);

		public delegate void DeviceConnectedChangeHandler(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource, bool deviceConnected);

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public event ChangeHandler onChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange -= value;
			}
		}

		public event UpdateHandler onUpdate
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate -= value;
			}
		}

		public event TrackingChangeHandler onTrackingChanged
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onTrackingChanged += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onTrackingChanged -= value;
			}
		}

		public event ValidPoseChangeHandler onValidPoseChanged
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onValidPoseChanged += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onValidPoseChanged -= value;
			}
		}

		public event DeviceConnectedChangeHandler onDeviceConnectedChanged
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onDeviceConnectedChanged += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onDeviceConnectedChanged -= value;
			}
		}

		public void AddOnDeviceConnectedChanged(SteamVR_Input_Sources inputSource, DeviceConnectedChangeHandler functionToCall)
		{
			sourceMap[inputSource].onDeviceConnectedChanged += functionToCall;
		}

		public void RemoveOnDeviceConnectedChanged(SteamVR_Input_Sources inputSource, DeviceConnectedChangeHandler functionToStopCalling)
		{
			sourceMap[inputSource].onDeviceConnectedChanged -= functionToStopCalling;
		}

		public void AddOnTrackingChanged(SteamVR_Input_Sources inputSource, TrackingChangeHandler functionToCall)
		{
			sourceMap[inputSource].onTrackingChanged += functionToCall;
		}

		public void RemoveOnTrackingChanged(SteamVR_Input_Sources inputSource, TrackingChangeHandler functionToStopCalling)
		{
			sourceMap[inputSource].onTrackingChanged -= functionToStopCalling;
		}

		public void AddOnValidPoseChanged(SteamVR_Input_Sources inputSource, ValidPoseChangeHandler functionToCall)
		{
			sourceMap[inputSource].onValidPoseChanged += functionToCall;
		}

		public void RemoveOnValidPoseChanged(SteamVR_Input_Sources inputSource, ValidPoseChangeHandler functionToStopCalling)
		{
			sourceMap[inputSource].onValidPoseChanged -= functionToStopCalling;
		}

		public void AddOnActiveChangeListener(SteamVR_Input_Sources inputSource, ActiveChangeHandler functionToCall)
		{
			sourceMap[inputSource].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(SteamVR_Input_Sources inputSource, ActiveChangeHandler functionToStopCalling)
		{
			sourceMap[inputSource].onActiveChange -= functionToStopCalling;
		}

		public void AddOnChangeListener(SteamVR_Input_Sources inputSource, ChangeHandler functionToCall)
		{
			sourceMap[inputSource].onChange += functionToCall;
		}

		public void RemoveOnChangeListener(SteamVR_Input_Sources inputSource, ChangeHandler functionToStopCalling)
		{
			sourceMap[inputSource].onChange -= functionToStopCalling;
		}

		public void AddOnUpdateListener(SteamVR_Input_Sources inputSource, UpdateHandler functionToCall)
		{
			sourceMap[inputSource].onUpdate += functionToCall;
		}

		public void RemoveOnUpdateListener(SteamVR_Input_Sources inputSource, UpdateHandler functionToStopCalling)
		{
			sourceMap[inputSource].onUpdate -= functionToStopCalling;
		}

		public void RemoveAllListeners(SteamVR_Input_Sources input_Sources)
		{
			sourceMap[input_Sources].RemoveAllListeners();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}

		public static void SetTrackingUniverseOrigin(ETrackingUniverseOrigin newOrigin)
		{
			SteamVR_Action_Pose_Base<SteamVR_Action_Pose_Source_Map<SteamVR_Action_Pose_Source>, SteamVR_Action_Pose_Source>.SetUniverseOrigin(newOrigin);
			OpenVR.Compositor.SetTrackingSpace(newOrigin);
		}
	}
	[Serializable]
	public abstract class SteamVR_Action_Pose_Base<SourceMap, SourceElement> : SteamVR_Action_In<SourceMap, SourceElement>, ISteamVR_Action_Pose, ISteamVR_Action_In_Source, ISteamVR_Action_Source where SourceMap : SteamVR_Action_Pose_Source_Map<SourceElement>, new() where SourceElement : SteamVR_Action_Pose_Source, new()
	{
		public Vector3 localPosition => sourceMap[SteamVR_Input_Sources.Any].localPosition;

		public Quaternion localRotation => sourceMap[SteamVR_Input_Sources.Any].localRotation;

		public ETrackingResult trackingState => sourceMap[SteamVR_Input_Sources.Any].trackingState;

		public Vector3 velocity => sourceMap[SteamVR_Input_Sources.Any].velocity;

		public Vector3 angularVelocity => sourceMap[SteamVR_Input_Sources.Any].angularVelocity;

		public bool poseIsValid => sourceMap[SteamVR_Input_Sources.Any].poseIsValid;

		public bool deviceIsConnected => sourceMap[SteamVR_Input_Sources.Any].deviceIsConnected;

		public Vector3 lastLocalPosition => sourceMap[SteamVR_Input_Sources.Any].lastLocalPosition;

		public Quaternion lastLocalRotation => sourceMap[SteamVR_Input_Sources.Any].lastLocalRotation;

		public ETrackingResult lastTrackingState => sourceMap[SteamVR_Input_Sources.Any].lastTrackingState;

		public Vector3 lastVelocity => sourceMap[SteamVR_Input_Sources.Any].lastVelocity;

		public Vector3 lastAngularVelocity => sourceMap[SteamVR_Input_Sources.Any].lastAngularVelocity;

		public bool lastPoseIsValid => sourceMap[SteamVR_Input_Sources.Any].lastPoseIsValid;

		public bool lastDeviceIsConnected => sourceMap[SteamVR_Input_Sources.Any].lastDeviceIsConnected;

		protected static void SetUniverseOrigin(ETrackingUniverseOrigin newOrigin)
		{
			for (int i = 0; i < SteamVR_Input.actionsPose.Length; i++)
			{
				SteamVR_Input.actionsPose[i].sourceMap.SetTrackingUniverseOrigin(newOrigin);
			}
			for (int j = 0; j < SteamVR_Input.actionsSkeleton.Length; j++)
			{
				SteamVR_Input.actionsSkeleton[j].sourceMap.SetTrackingUniverseOrigin(newOrigin);
			}
		}

		public SteamVR_Action_Pose_Base()
		{
		}

		public virtual void UpdateValues(bool skipStateAndEventUpdates)
		{
			sourceMap.UpdateValues(skipStateAndEventUpdates);
		}

		public bool GetVelocitiesAtTimeOffset(SteamVR_Input_Sources inputSource, float secondsFromNow, out Vector3 velocity, out Vector3 angularVelocity)
		{
			return sourceMap[inputSource].GetVelocitiesAtTimeOffset(secondsFromNow, out velocity, out angularVelocity);
		}

		public bool GetPoseAtTimeOffset(SteamVR_Input_Sources inputSource, float secondsFromNow, out Vector3 localPosition, out Quaternion localRotation, out Vector3 velocity, out Vector3 angularVelocity)
		{
			return sourceMap[inputSource].GetPoseAtTimeOffset(secondsFromNow, out localPosition, out localRotation, out velocity, out angularVelocity);
		}

		public virtual void UpdateTransform(SteamVR_Input_Sources inputSource, Transform transformToUpdate)
		{
			sourceMap[inputSource].UpdateTransform(transformToUpdate);
		}

		public Vector3 GetLocalPosition(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].localPosition;
		}

		public Quaternion GetLocalRotation(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].localRotation;
		}

		public Vector3 GetVelocity(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].velocity;
		}

		public Vector3 GetAngularVelocity(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].angularVelocity;
		}

		public bool GetDeviceIsConnected(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].deviceIsConnected;
		}

		public bool GetPoseIsValid(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].poseIsValid;
		}

		public ETrackingResult GetTrackingResult(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].trackingState;
		}

		public Vector3 GetLastLocalPosition(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastLocalPosition;
		}

		public Quaternion GetLastLocalRotation(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastLocalRotation;
		}

		public Vector3 GetLastVelocity(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastVelocity;
		}

		public Vector3 GetLastAngularVelocity(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastAngularVelocity;
		}

		public bool GetLastDeviceIsConnected(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastDeviceIsConnected;
		}

		public bool GetLastPoseIsValid(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastPoseIsValid;
		}

		public ETrackingResult GetLastTrackingResult(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastTrackingState;
		}
	}
	public class SteamVR_Action_Pose_Source_Map<Source> : SteamVR_Action_In_Source_Map<Source> where Source : SteamVR_Action_Pose_Source, new()
	{
		public void SetTrackingUniverseOrigin(ETrackingUniverseOrigin newOrigin)
		{
			for (int i = 0; i < sources.Length; i++)
			{
				if (sources[i] != null)
				{
					sources[i].universeOrigin = newOrigin;
				}
			}
		}

		public virtual void UpdateValues(bool skipStateAndEventUpdates)
		{
			for (int i = 0; i < updatingSources.Count; i++)
			{
				sources[updatingSources[i]].UpdateValue(skipStateAndEventUpdates);
			}
		}
	}
	public class SteamVR_Action_Pose_Source : SteamVR_Action_In_Source, ISteamVR_Action_Pose, ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		public ETrackingUniverseOrigin universeOrigin = ETrackingUniverseOrigin.TrackingUniverseRawAndUncalibrated;

		protected static uint poseActionData_size = 0u;

		public float changeTolerance = Mathf.Epsilon;

		protected InputPoseActionData_t poseActionData;

		protected InputPoseActionData_t lastPoseActionData;

		protected InputPoseActionData_t tempPoseActionData;

		protected SteamVR_Action_Pose poseAction;

		public static float framesAhead = 2f;

		public override bool changed { get; protected set; }

		public override bool lastChanged { get; protected set; }

		public override ulong activeOrigin
		{
			get
			{
				if (active)
				{
					return poseActionData.activeOrigin;
				}
				return 0uL;
			}
		}

		public override ulong lastActiveOrigin => lastPoseActionData.activeOrigin;

		public override bool active
		{
			get
			{
				if (activeBinding)
				{
					return action.actionSet.IsActive(base.inputSource);
				}
				return false;
			}
		}

		public override bool activeBinding => poseActionData.bActive;

		public override bool lastActive { get; protected set; }

		public override bool lastActiveBinding => lastPoseActionData.bActive;

		public ETrackingResult trackingState => poseActionData.pose.eTrackingResult;

		public ETrackingResult lastTrackingState => lastPoseActionData.pose.eTrackingResult;

		public bool poseIsValid => poseActionData.pose.bPoseIsValid;

		public bool lastPoseIsValid => lastPoseActionData.pose.bPoseIsValid;

		public bool deviceIsConnected => poseActionData.pose.bDeviceIsConnected;

		public bool lastDeviceIsConnected => lastPoseActionData.pose.bDeviceIsConnected;

		public Vector3 localPosition { get; protected set; }

		public Quaternion localRotation { get; protected set; }

		public Vector3 lastLocalPosition { get; protected set; }

		public Quaternion lastLocalRotation { get; protected set; }

		public Vector3 velocity { get; protected set; }

		public Vector3 lastVelocity { get; protected set; }

		public Vector3 angularVelocity { get; protected set; }

		public Vector3 lastAngularVelocity { get; protected set; }

		public event SteamVR_Action_Pose.ActiveChangeHandler onActiveChange;

		public event SteamVR_Action_Pose.ActiveChangeHandler onActiveBindingChange;

		public event SteamVR_Action_Pose.ChangeHandler onChange;

		public event SteamVR_Action_Pose.UpdateHandler onUpdate;

		public event SteamVR_Action_Pose.TrackingChangeHandler onTrackingChanged;

		public event SteamVR_Action_Pose.ValidPoseChangeHandler onValidPoseChanged;

		public event SteamVR_Action_Pose.DeviceConnectedChangeHandler onDeviceConnectedChanged;

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			poseAction = wrappingAction as SteamVR_Action_Pose;
		}

		public override void Initialize()
		{
			base.Initialize();
			if (poseActionData_size == 0)
			{
				poseActionData_size = (uint)Marshal.SizeOf(typeof(InputPoseActionData_t));
			}
		}

		public virtual void RemoveAllListeners()
		{
			Delegate[] invocationList;
			if (this.onActiveChange != null)
			{
				invocationList = this.onActiveChange.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj in array)
					{
						onActiveChange -= (SteamVR_Action_Pose.ActiveChangeHandler)obj;
					}
				}
			}
			if (this.onChange != null)
			{
				invocationList = this.onChange.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj2 in array)
					{
						onChange -= (SteamVR_Action_Pose.ChangeHandler)obj2;
					}
				}
			}
			if (this.onUpdate != null)
			{
				invocationList = this.onUpdate.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj3 in array)
					{
						onUpdate -= (SteamVR_Action_Pose.UpdateHandler)obj3;
					}
				}
			}
			if (this.onTrackingChanged != null)
			{
				invocationList = this.onTrackingChanged.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj4 in array)
					{
						onTrackingChanged -= (SteamVR_Action_Pose.TrackingChangeHandler)obj4;
					}
				}
			}
			if (this.onValidPoseChanged != null)
			{
				invocationList = this.onValidPoseChanged.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj5 in array)
					{
						onValidPoseChanged -= (SteamVR_Action_Pose.ValidPoseChangeHandler)obj5;
					}
				}
			}
			if (this.onDeviceConnectedChanged == null)
			{
				return;
			}
			invocationList = this.onDeviceConnectedChanged.GetInvocationList();
			if (invocationList != null)
			{
				Delegate[] array = invocationList;
				foreach (Delegate obj6 in array)
				{
					onDeviceConnectedChanged -= (SteamVR_Action_Pose.DeviceConnectedChangeHandler)obj6;
				}
			}
		}

		public override void UpdateValue()
		{
			UpdateValue(skipStateAndEventUpdates: false);
		}

		public virtual void UpdateValue(bool skipStateAndEventUpdates)
		{
			lastChanged = changed;
			lastPoseActionData = poseActionData;
			lastLocalPosition = localPosition;
			lastLocalRotation = localRotation;
			lastVelocity = velocity;
			lastAngularVelocity = angularVelocity;
			EVRInputError eVRInputError = ((framesAhead != 0f) ? OpenVR.Input.GetPoseActionDataRelativeToNow(base.handle, universeOrigin, framesAhead * (Time.timeScale / SteamVR.instance.hmd_DisplayFrequency), ref poseActionData, poseActionData_size, inputSourceHandle) : OpenVR.Input.GetPoseActionDataForNextFrame(base.handle, universeOrigin, ref poseActionData, poseActionData_size, inputSourceHandle));
			if (eVRInputError != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetPoseActionData error (" + base.fullPath + "): " + eVRInputError.ToString() + " Handle: " + base.handle + ". Input source: " + base.inputSource);
			}
			if (active)
			{
				SetCacheVariables();
				changed = GetChanged();
			}
			if (changed)
			{
				base.changedTime = base.updateTime;
			}
			if (!skipStateAndEventUpdates)
			{
				CheckAndSendEvents();
			}
		}

		protected void SetCacheVariables()
		{
			localPosition = poseActionData.pose.mDeviceToAbsoluteTracking.GetPosition();
			localRotation = poseActionData.pose.mDeviceToAbsoluteTracking.GetRotation();
			velocity = GetUnityCoordinateVelocity(poseActionData.pose.vVelocity);
			angularVelocity = GetUnityCoordinateAngularVelocity(poseActionData.pose.vAngularVelocity);
			base.updateTime = Time.realtimeSinceStartup;
		}

		protected bool GetChanged()
		{
			if (Vector3.Distance(localPosition, lastLocalPosition) > changeTolerance)
			{
				return true;
			}
			if (Mathf.Abs(Quaternion.Angle(localRotation, lastLocalRotation)) > changeTolerance)
			{
				return true;
			}
			if (Vector3.Distance(velocity, lastVelocity) > changeTolerance)
			{
				return true;
			}
			if (Vector3.Distance(angularVelocity, lastAngularVelocity) > changeTolerance)
			{
				return true;
			}
			return false;
		}

		public bool GetVelocitiesAtTimeOffset(float secondsFromNow, out Vector3 velocityAtTime, out Vector3 angularVelocityAtTime)
		{
			EVRInputError poseActionDataRelativeToNow = OpenVR.Input.GetPoseActionDataRelativeToNow(base.handle, universeOrigin, secondsFromNow, ref tempPoseActionData, poseActionData_size, inputSourceHandle);
			if (poseActionDataRelativeToNow != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetPoseActionData error (" + base.fullPath + "): " + poseActionDataRelativeToNow.ToString() + " handle: " + base.handle);
				velocityAtTime = Vector3.zero;
				angularVelocityAtTime = Vector3.zero;
				return false;
			}
			velocityAtTime = GetUnityCoordinateVelocity(tempPoseActionData.pose.vVelocity);
			angularVelocityAtTime = GetUnityCoordinateAngularVelocity(tempPoseActionData.pose.vAngularVelocity);
			return true;
		}

		public bool GetPoseAtTimeOffset(float secondsFromNow, out Vector3 positionAtTime, out Quaternion rotationAtTime, out Vector3 velocityAtTime, out Vector3 angularVelocityAtTime)
		{
			EVRInputError poseActionDataRelativeToNow = OpenVR.Input.GetPoseActionDataRelativeToNow(base.handle, universeOrigin, secondsFromNow, ref tempPoseActionData, poseActionData_size, inputSourceHandle);
			if (poseActionDataRelativeToNow != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetPoseActionData error (" + base.fullPath + "): " + poseActionDataRelativeToNow.ToString() + " handle: " + base.handle);
				velocityAtTime = Vector3.zero;
				angularVelocityAtTime = Vector3.zero;
				positionAtTime = Vector3.zero;
				rotationAtTime = Quaternion.identity;
				return false;
			}
			velocityAtTime = GetUnityCoordinateVelocity(tempPoseActionData.pose.vVelocity);
			angularVelocityAtTime = GetUnityCoordinateAngularVelocity(tempPoseActionData.pose.vAngularVelocity);
			positionAtTime = tempPoseActionData.pose.mDeviceToAbsoluteTracking.GetPosition();
			rotationAtTime = tempPoseActionData.pose.mDeviceToAbsoluteTracking.GetRotation();
			return true;
		}

		public void UpdateTransform(Transform transformToUpdate)
		{
			transformToUpdate.localPosition = localPosition;
			transformToUpdate.localRotation = localRotation;
		}

		protected virtual void CheckAndSendEvents()
		{
			if (trackingState != lastTrackingState && this.onTrackingChanged != null)
			{
				this.onTrackingChanged(poseAction, base.inputSource, trackingState);
			}
			if (poseIsValid != lastPoseIsValid && this.onValidPoseChanged != null)
			{
				this.onValidPoseChanged(poseAction, base.inputSource, poseIsValid);
			}
			if (deviceIsConnected != lastDeviceIsConnected && this.onDeviceConnectedChanged != null)
			{
				this.onDeviceConnectedChanged(poseAction, base.inputSource, deviceIsConnected);
			}
			if (changed && this.onChange != null)
			{
				this.onChange(poseAction, base.inputSource);
			}
			if (active != lastActive && this.onActiveChange != null)
			{
				this.onActiveChange(poseAction, base.inputSource, active);
			}
			if (activeBinding != lastActiveBinding && this.onActiveBindingChange != null)
			{
				this.onActiveBindingChange(poseAction, base.inputSource, activeBinding);
			}
			if (this.onUpdate != null)
			{
				this.onUpdate(poseAction, base.inputSource);
			}
		}

		protected Vector3 GetUnityCoordinateVelocity(HmdVector3_t vector)
		{
			return GetUnityCoordinateVelocity(vector.v0, vector.v1, vector.v2);
		}

		protected Vector3 GetUnityCoordinateAngularVelocity(HmdVector3_t vector)
		{
			return GetUnityCoordinateAngularVelocity(vector.v0, vector.v1, vector.v2);
		}

		protected Vector3 GetUnityCoordinateVelocity(float x, float y, float z)
		{
			return new Vector3
			{
				x = x,
				y = y,
				z = 0f - z
			};
		}

		protected Vector3 GetUnityCoordinateAngularVelocity(float x, float y, float z)
		{
			return new Vector3
			{
				x = 0f - x,
				y = 0f - y,
				z = z
			};
		}
	}
	public interface ISteamVR_Action_Pose : ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		Vector3 localPosition { get; }

		Quaternion localRotation { get; }

		ETrackingResult trackingState { get; }

		Vector3 velocity { get; }

		Vector3 angularVelocity { get; }

		bool poseIsValid { get; }

		bool deviceIsConnected { get; }

		Vector3 lastLocalPosition { get; }

		Quaternion lastLocalRotation { get; }

		ETrackingResult lastTrackingState { get; }

		Vector3 lastVelocity { get; }

		Vector3 lastAngularVelocity { get; }

		bool lastPoseIsValid { get; }

		bool lastDeviceIsConnected { get; }
	}
	[Serializable]
	public class SteamVR_Action_Single : SteamVR_Action_In<SteamVR_Action_Single_Source_Map, SteamVR_Action_Single_Source>, ISteamVR_Action_Single, ISteamVR_Action_In_Source, ISteamVR_Action_Source, ISerializationCallbackReceiver
	{
		public delegate void AxisHandler(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta);

		public delegate void ActiveChangeHandler(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta);

		public delegate void UpdateHandler(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta);

		public float axis => sourceMap[SteamVR_Input_Sources.Any].axis;

		public float lastAxis => sourceMap[SteamVR_Input_Sources.Any].lastAxis;

		public float delta => sourceMap[SteamVR_Input_Sources.Any].delta;

		public float lastDelta => sourceMap[SteamVR_Input_Sources.Any].lastDelta;

		public event ChangeHandler onChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange -= value;
			}
		}

		public event UpdateHandler onUpdate
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate -= value;
			}
		}

		public event AxisHandler onAxis
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onAxis += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onAxis -= value;
			}
		}

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public float GetAxis(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].axis;
		}

		public float GetAxisDelta(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].delta;
		}

		public float GetLastAxis(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastAxis;
		}

		public float GetLastAxisDelta(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastDelta;
		}

		public void AddOnActiveChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange -= functionToStopCalling;
		}

		public void AddOnActiveBindingChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange += functionToCall;
		}

		public void RemoveOnActiveBindingChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange -= functionToStopCalling;
		}

		public void AddOnChangeListener(ChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange += functionToCall;
		}

		public void RemoveOnChangeListener(ChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange -= functionToStopCalling;
		}

		public void AddOnUpdateListener(UpdateHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate += functionToCall;
		}

		public void RemoveOnUpdateListener(UpdateHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate -= functionToStopCalling;
		}

		public void AddOnAxisListener(AxisHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onAxis += functionToCall;
		}

		public void RemoveOnAxisListener(AxisHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onAxis -= functionToStopCalling;
		}

		public void RemoveAllListeners(SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].RemoveAllListeners();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}
	}
	public class SteamVR_Action_Single_Source_Map : SteamVR_Action_In_Source_Map<SteamVR_Action_Single_Source>
	{
	}
	public class SteamVR_Action_Single_Source : SteamVR_Action_In_Source, ISteamVR_Action_Single, ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		protected static uint actionData_size;

		public float changeTolerance = Mathf.Epsilon;

		protected InputAnalogActionData_t actionData;

		protected InputAnalogActionData_t lastActionData;

		protected SteamVR_Action_Single singleAction;

		public float axis
		{
			get
			{
				if (active)
				{
					return actionData.x;
				}
				return 0f;
			}
		}

		public float lastAxis
		{
			get
			{
				if (active)
				{
					return lastActionData.x;
				}
				return 0f;
			}
		}

		public float delta
		{
			get
			{
				if (active)
				{
					return actionData.deltaX;
				}
				return 0f;
			}
		}

		public float lastDelta
		{
			get
			{
				if (active)
				{
					return lastActionData.deltaX;
				}
				return 0f;
			}
		}

		public override bool changed { get; protected set; }

		public override bool lastChanged { get; protected set; }

		public override ulong activeOrigin
		{
			get
			{
				if (active)
				{
					return actionData.activeOrigin;
				}
				return 0uL;
			}
		}

		public override ulong lastActiveOrigin => lastActionData.activeOrigin;

		public override bool active
		{
			get
			{
				if (activeBinding)
				{
					return action.actionSet.IsActive(base.inputSource);
				}
				return false;
			}
		}

		public override bool activeBinding => actionData.bActive;

		public override bool lastActive { get; protected set; }

		public override bool lastActiveBinding => lastActionData.bActive;

		public event SteamVR_Action_Single.AxisHandler onAxis;

		public event SteamVR_Action_Single.ActiveChangeHandler onActiveChange;

		public event SteamVR_Action_Single.ActiveChangeHandler onActiveBindingChange;

		public event SteamVR_Action_Single.ChangeHandler onChange;

		public event SteamVR_Action_Single.UpdateHandler onUpdate;

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			singleAction = (SteamVR_Action_Single)wrappingAction;
		}

		public override void Initialize()
		{
			base.Initialize();
			if (actionData_size == 0)
			{
				actionData_size = (uint)Marshal.SizeOf(typeof(InputAnalogActionData_t));
			}
		}

		public void RemoveAllListeners()
		{
			Delegate[] invocationList;
			if (this.onAxis != null)
			{
				invocationList = this.onAxis.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj in array)
					{
						onAxis -= (SteamVR_Action_Single.AxisHandler)obj;
					}
				}
			}
			if (this.onUpdate != null)
			{
				invocationList = this.onUpdate.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj2 in array)
					{
						onUpdate -= (SteamVR_Action_Single.UpdateHandler)obj2;
					}
				}
			}
			if (this.onChange == null)
			{
				return;
			}
			invocationList = this.onChange.GetInvocationList();
			if (invocationList != null)
			{
				Delegate[] array = invocationList;
				foreach (Delegate obj3 in array)
				{
					onChange -= (SteamVR_Action_Single.ChangeHandler)obj3;
				}
			}
		}

		public override void UpdateValue()
		{
			lastActionData = actionData;
			lastActive = active;
			EVRInputError analogActionData = OpenVR.Input.GetAnalogActionData(base.handle, ref actionData, actionData_size, SteamVR_Input_Source.GetHandle(base.inputSource));
			if (analogActionData != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetAnalogActionData error (" + base.fullPath + "): " + analogActionData.ToString() + " handle: " + base.handle);
			}
			base.updateTime = Time.realtimeSinceStartup;
			changed = false;
			if (active)
			{
				if (delta > changeTolerance || delta < 0f - changeTolerance)
				{
					changed = true;
					base.changedTime = Time.realtimeSinceStartup + actionData.fUpdateTime;
					if (this.onChange != null)
					{
						this.onChange(singleAction, base.inputSource, axis, delta);
					}
				}
				if (axis != 0f && this.onAxis != null)
				{
					this.onAxis(singleAction, base.inputSource, axis, delta);
				}
				if (this.onUpdate != null)
				{
					this.onUpdate(singleAction, base.inputSource, axis, delta);
				}
			}
			if (this.onActiveBindingChange != null && lastActiveBinding != activeBinding)
			{
				this.onActiveBindingChange(singleAction, base.inputSource, activeBinding);
			}
			if (this.onActiveChange != null && lastActive != active)
			{
				this.onActiveChange(singleAction, base.inputSource, activeBinding);
			}
		}
	}
	public interface ISteamVR_Action_Single : ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		float axis { get; }

		float lastAxis { get; }

		float delta { get; }

		float lastDelta { get; }
	}
	[Serializable]
	public class SteamVR_Action_Skeleton : SteamVR_Action_Pose_Base<SteamVR_Action_Skeleton_Source_Map, SteamVR_Action_Skeleton_Source>, ISteamVR_Action_Skeleton_Source, ISerializationCallbackReceiver
	{
		public delegate void ActiveChangeHandler(SteamVR_Action_Skeleton fromAction, bool active);

		public delegate void ChangeHandler(SteamVR_Action_Skeleton fromAction);

		public delegate void UpdateHandler(SteamVR_Action_Skeleton fromAction);

		public delegate void TrackingChangeHandler(SteamVR_Action_Skeleton fromAction, ETrackingResult trackingState);

		public delegate void ValidPoseChangeHandler(SteamVR_Action_Skeleton fromAction, bool validPose);

		public delegate void DeviceConnectedChangeHandler(SteamVR_Action_Skeleton fromAction, bool deviceConnected);

		public const int numBones = 31;

		public static Quaternion steamVRFixUpRotation = Quaternion.AngleAxis(180f, Vector3.up);

		public Vector3[] bonePositions => sourceMap[SteamVR_Input_Sources.Any].bonePositions;

		public Quaternion[] boneRotations => sourceMap[SteamVR_Input_Sources.Any].boneRotations;

		public Vector3[] lastBonePositions => sourceMap[SteamVR_Input_Sources.Any].lastBonePositions;

		public Quaternion[] lastBoneRotations => sourceMap[SteamVR_Input_Sources.Any].lastBoneRotations;

		public EVRSkeletalMotionRange rangeOfMotion
		{
			get
			{
				return sourceMap[SteamVR_Input_Sources.Any].rangeOfMotion;
			}
			set
			{
				sourceMap[SteamVR_Input_Sources.Any].rangeOfMotion = value;
			}
		}

		public EVRSkeletalTransformSpace skeletalTransformSpace
		{
			get
			{
				return sourceMap[SteamVR_Input_Sources.Any].skeletalTransformSpace;
			}
			set
			{
				sourceMap[SteamVR_Input_Sources.Any].skeletalTransformSpace = value;
			}
		}

		public EVRSummaryType summaryDataType
		{
			get
			{
				return sourceMap[SteamVR_Input_Sources.Any].summaryDataType;
			}
			set
			{
				sourceMap[SteamVR_Input_Sources.Any].summaryDataType = value;
			}
		}

		public EVRSkeletalTrackingLevel skeletalTrackingLevel => sourceMap[SteamVR_Input_Sources.Any].skeletalTrackingLevel;

		public float thumbCurl => sourceMap[SteamVR_Input_Sources.Any].thumbCurl;

		public float indexCurl => sourceMap[SteamVR_Input_Sources.Any].indexCurl;

		public float middleCurl => sourceMap[SteamVR_Input_Sources.Any].middleCurl;

		public float ringCurl => sourceMap[SteamVR_Input_Sources.Any].ringCurl;

		public float pinkyCurl => sourceMap[SteamVR_Input_Sources.Any].pinkyCurl;

		public float thumbIndexSplay => sourceMap[SteamVR_Input_Sources.Any].thumbIndexSplay;

		public float indexMiddleSplay => sourceMap[SteamVR_Input_Sources.Any].indexMiddleSplay;

		public float middleRingSplay => sourceMap[SteamVR_Input_Sources.Any].middleRingSplay;

		public float ringPinkySplay => sourceMap[SteamVR_Input_Sources.Any].ringPinkySplay;

		public float lastThumbCurl => sourceMap[SteamVR_Input_Sources.Any].lastThumbCurl;

		public float lastIndexCurl => sourceMap[SteamVR_Input_Sources.Any].lastIndexCurl;

		public float lastMiddleCurl => sourceMap[SteamVR_Input_Sources.Any].lastMiddleCurl;

		public float lastRingCurl => sourceMap[SteamVR_Input_Sources.Any].lastRingCurl;

		public float lastPinkyCurl => sourceMap[SteamVR_Input_Sources.Any].lastPinkyCurl;

		public float lastThumbIndexSplay => sourceMap[SteamVR_Input_Sources.Any].lastThumbIndexSplay;

		public float lastIndexMiddleSplay => sourceMap[SteamVR_Input_Sources.Any].lastIndexMiddleSplay;

		public float lastMiddleRingSplay => sourceMap[SteamVR_Input_Sources.Any].lastMiddleRingSplay;

		public float lastRingPinkySplay => sourceMap[SteamVR_Input_Sources.Any].lastRingPinkySplay;

		public float[] fingerCurls => sourceMap[SteamVR_Input_Sources.Any].fingerCurls;

		public float[] fingerSplays => sourceMap[SteamVR_Input_Sources.Any].fingerSplays;

		public float[] lastFingerCurls => sourceMap[SteamVR_Input_Sources.Any].lastFingerCurls;

		public float[] lastFingerSplays => sourceMap[SteamVR_Input_Sources.Any].lastFingerSplays;

		public bool poseChanged => sourceMap[SteamVR_Input_Sources.Any].poseChanged;

		public bool onlyUpdateSummaryData
		{
			get
			{
				return sourceMap[SteamVR_Input_Sources.Any].onlyUpdateSummaryData;
			}
			set
			{
				sourceMap[SteamVR_Input_Sources.Any].onlyUpdateSummaryData = value;
			}
		}

		public int boneCount => (int)GetBoneCount();

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public event ChangeHandler onChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange -= value;
			}
		}

		public event UpdateHandler onUpdate
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate -= value;
			}
		}

		public event TrackingChangeHandler onTrackingChanged
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onTrackingChanged += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onTrackingChanged -= value;
			}
		}

		public event ValidPoseChangeHandler onValidPoseChanged
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onValidPoseChanged += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onValidPoseChanged -= value;
			}
		}

		public event DeviceConnectedChangeHandler onDeviceConnectedChanged
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onDeviceConnectedChanged += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onDeviceConnectedChanged -= value;
			}
		}

		public virtual void UpdateValue(bool skipStateAndEventUpdates)
		{
			sourceMap[SteamVR_Input_Sources.Any].UpdateValue(skipStateAndEventUpdates);
		}

		public void UpdateValueWithoutEvents()
		{
			sourceMap[SteamVR_Input_Sources.Any].UpdateValue(skipStateAndEventUpdates: true);
		}

		public void UpdateTransform(Transform transformToUpdate)
		{
			base.UpdateTransform(SteamVR_Input_Sources.Any, transformToUpdate);
		}

		public bool GetActive()
		{
			return sourceMap[SteamVR_Input_Sources.Any].active;
		}

		public bool GetSetActive()
		{
			return actionSet.IsActive();
		}

		public bool GetVelocitiesAtTimeOffset(float secondsFromNow, out Vector3 velocity, out Vector3 angularVelocity)
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetVelocitiesAtTimeOffset(secondsFromNow, out velocity, out angularVelocity);
		}

		public bool GetPoseAtTimeOffset(float secondsFromNow, out Vector3 position, out Quaternion rotation, out Vector3 velocity, out Vector3 angularVelocity)
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetPoseAtTimeOffset(secondsFromNow, out position, out rotation, out velocity, out angularVelocity);
		}

		public Vector3 GetLocalPosition()
		{
			return sourceMap[SteamVR_Input_Sources.Any].localPosition;
		}

		public Quaternion GetLocalRotation()
		{
			return sourceMap[SteamVR_Input_Sources.Any].localRotation;
		}

		public Vector3 GetVelocity()
		{
			return sourceMap[SteamVR_Input_Sources.Any].velocity;
		}

		public Vector3 GetAngularVelocity()
		{
			return sourceMap[SteamVR_Input_Sources.Any].angularVelocity;
		}

		public bool GetDeviceIsConnected()
		{
			return sourceMap[SteamVR_Input_Sources.Any].deviceIsConnected;
		}

		public bool GetPoseIsValid()
		{
			return sourceMap[SteamVR_Input_Sources.Any].poseIsValid;
		}

		public ETrackingResult GetTrackingResult()
		{
			return sourceMap[SteamVR_Input_Sources.Any].trackingState;
		}

		public Vector3 GetLastLocalPosition()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastLocalPosition;
		}

		public Quaternion GetLastLocalRotation()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastLocalRotation;
		}

		public Vector3 GetLastVelocity()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastVelocity;
		}

		public Vector3 GetLastAngularVelocity()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastAngularVelocity;
		}

		public bool GetLastDeviceIsConnected()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastDeviceIsConnected;
		}

		public bool GetLastPoseIsValid()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastPoseIsValid;
		}

		public ETrackingResult GetLastTrackingResult()
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastTrackingState;
		}

		public Vector3[] GetBonePositions(bool copy = false)
		{
			if (copy)
			{
				return (Vector3[])sourceMap[SteamVR_Input_Sources.Any].bonePositions.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].bonePositions;
		}

		public Quaternion[] GetBoneRotations(bool copy = false)
		{
			if (copy)
			{
				return (Quaternion[])sourceMap[SteamVR_Input_Sources.Any].boneRotations.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].boneRotations;
		}

		public Vector3[] GetLastBonePositions(bool copy = false)
		{
			if (copy)
			{
				return (Vector3[])sourceMap[SteamVR_Input_Sources.Any].lastBonePositions.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].lastBonePositions;
		}

		public Quaternion[] GetLastBoneRotations(bool copy = false)
		{
			if (copy)
			{
				return (Quaternion[])sourceMap[SteamVR_Input_Sources.Any].lastBoneRotations.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].lastBoneRotations;
		}

		public void SetRangeOfMotion(EVRSkeletalMotionRange range)
		{
			sourceMap[SteamVR_Input_Sources.Any].rangeOfMotion = range;
		}

		public void SetSkeletalTransformSpace(EVRSkeletalTransformSpace space)
		{
			sourceMap[SteamVR_Input_Sources.Any].skeletalTransformSpace = space;
		}

		public uint GetBoneCount()
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetBoneCount();
		}

		public int[] GetBoneHierarchy()
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetBoneHierarchy();
		}

		public string GetBoneName(int boneIndex)
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetBoneName(boneIndex);
		}

		public SteamVR_Utils.RigidTransform[] GetReferenceTransforms(EVRSkeletalTransformSpace transformSpace, EVRSkeletalReferencePose referencePose)
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetReferenceTransforms(transformSpace, referencePose);
		}

		public EVRSkeletalTrackingLevel GetSkeletalTrackingLevel()
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetSkeletalTrackingLevel();
		}

		public float[] GetFingerCurls(bool copy = false)
		{
			if (copy)
			{
				return (float[])sourceMap[SteamVR_Input_Sources.Any].fingerCurls.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].fingerCurls;
		}

		public float[] GetLastFingerCurls(bool copy = false)
		{
			if (copy)
			{
				return (float[])sourceMap[SteamVR_Input_Sources.Any].lastFingerCurls.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].lastFingerCurls;
		}

		public float[] GetFingerSplays(bool copy = false)
		{
			if (copy)
			{
				return (float[])sourceMap[SteamVR_Input_Sources.Any].fingerSplays.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].fingerSplays;
		}

		public float[] GetLastFingerSplays(bool copy = false)
		{
			if (copy)
			{
				return (float[])sourceMap[SteamVR_Input_Sources.Any].lastFingerSplays.Clone();
			}
			return sourceMap[SteamVR_Input_Sources.Any].lastFingerSplays;
		}

		public float GetFingerCurl(int finger)
		{
			return sourceMap[SteamVR_Input_Sources.Any].fingerCurls[finger];
		}

		public float GetSplay(int fingerGapIndex)
		{
			return sourceMap[SteamVR_Input_Sources.Any].fingerSplays[fingerGapIndex];
		}

		public float GetFingerCurl(SteamVR_Skeleton_FingerIndexEnum finger)
		{
			return GetFingerCurl((int)finger);
		}

		public float GetSplay(SteamVR_Skeleton_FingerSplayIndexEnum fingerSplay)
		{
			return GetSplay((int)fingerSplay);
		}

		public float GetLastFingerCurl(int finger)
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastFingerCurls[finger];
		}

		public float GetLastSplay(int fingerGapIndex)
		{
			return sourceMap[SteamVR_Input_Sources.Any].lastFingerSplays[fingerGapIndex];
		}

		public float GetLastFingerCurl(SteamVR_Skeleton_FingerIndexEnum finger)
		{
			return GetLastFingerCurl((int)finger);
		}

		public float GetLastSplay(SteamVR_Skeleton_FingerSplayIndexEnum fingerSplay)
		{
			return GetLastSplay((int)fingerSplay);
		}

		public string GetLocalizedName(params EVRInputStringBits[] localizedParts)
		{
			return sourceMap[SteamVR_Input_Sources.Any].GetLocalizedOriginPart(localizedParts);
		}

		public void RemoveAllListeners(SteamVR_Input_Sources input_Sources)
		{
			sourceMap[input_Sources].RemoveAllListeners();
		}

		public void AddOnDeviceConnectedChanged(DeviceConnectedChangeHandler functionToCall)
		{
			sourceMap[SteamVR_Input_Sources.Any].onDeviceConnectedChanged += functionToCall;
		}

		public void RemoveOnDeviceConnectedChanged(DeviceConnectedChangeHandler functionToStopCalling)
		{
			sourceMap[SteamVR_Input_Sources.Any].onDeviceConnectedChanged -= functionToStopCalling;
		}

		public void AddOnTrackingChanged(TrackingChangeHandler functionToCall)
		{
			sourceMap[SteamVR_Input_Sources.Any].onTrackingChanged += functionToCall;
		}

		public void RemoveOnTrackingChanged(TrackingChangeHandler functionToStopCalling)
		{
			sourceMap[SteamVR_Input_Sources.Any].onTrackingChanged -= functionToStopCalling;
		}

		public void AddOnValidPoseChanged(ValidPoseChangeHandler functionToCall)
		{
			sourceMap[SteamVR_Input_Sources.Any].onValidPoseChanged += functionToCall;
		}

		public void RemoveOnValidPoseChanged(ValidPoseChangeHandler functionToStopCalling)
		{
			sourceMap[SteamVR_Input_Sources.Any].onValidPoseChanged -= functionToStopCalling;
		}

		public void AddOnActiveChangeListener(ActiveChangeHandler functionToCall)
		{
			sourceMap[SteamVR_Input_Sources.Any].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(ActiveChangeHandler functionToStopCalling)
		{
			sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= functionToStopCalling;
		}

		public void AddOnChangeListener(ChangeHandler functionToCall)
		{
			sourceMap[SteamVR_Input_Sources.Any].onChange += functionToCall;
		}

		public void RemoveOnChangeListener(ChangeHandler functionToStopCalling)
		{
			sourceMap[SteamVR_Input_Sources.Any].onChange -= functionToStopCalling;
		}

		public void AddOnUpdateListener(UpdateHandler functionToCall)
		{
			sourceMap[SteamVR_Input_Sources.Any].onUpdate += functionToCall;
		}

		public void RemoveOnUpdateListener(UpdateHandler functionToStopCalling)
		{
			sourceMap[SteamVR_Input_Sources.Any].onUpdate -= functionToStopCalling;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}
	}
	public class SteamVR_Action_Skeleton_Source_Map : SteamVR_Action_Pose_Source_Map<SteamVR_Action_Skeleton_Source>
	{
		protected override SteamVR_Action_Skeleton_Source GetSourceElementForIndexer(SteamVR_Input_Sources inputSource)
		{
			return sources[0];
		}
	}
	public class SteamVR_Action_Skeleton_Source : SteamVR_Action_Pose_Source, ISteamVR_Action_Skeleton_Source
	{
		protected static uint skeletonActionData_size;

		protected VRSkeletalSummaryData_t skeletalSummaryData;

		protected VRSkeletalSummaryData_t lastSkeletalSummaryData;

		protected SteamVR_Action_Skeleton skeletonAction;

		protected VRBoneTransform_t[] tempBoneTransforms = new VRBoneTransform_t[31];

		protected InputSkeletalActionData_t skeletonActionData;

		protected InputSkeletalActionData_t lastSkeletonActionData;

		protected InputSkeletalActionData_t tempSkeletonActionData;

		public override bool activeBinding => skeletonActionData.bActive;

		public override bool lastActiveBinding => lastSkeletonActionData.bActive;

		public Vector3[] bonePositions { get; protected set; }

		public Quaternion[] boneRotations { get; protected set; }

		public Vector3[] lastBonePositions { get; protected set; }

		public Quaternion[] lastBoneRotations { get; protected set; }

		public EVRSkeletalMotionRange rangeOfMotion { get; set; }

		public EVRSkeletalTransformSpace skeletalTransformSpace { get; set; }

		public EVRSummaryType summaryDataType { get; set; }

		public float thumbCurl => fingerCurls[0];

		public float indexCurl => fingerCurls[1];

		public float middleCurl => fingerCurls[2];

		public float ringCurl => fingerCurls[3];

		public float pinkyCurl => fingerCurls[4];

		public float thumbIndexSplay => fingerSplays[0];

		public float indexMiddleSplay => fingerSplays[1];

		public float middleRingSplay => fingerSplays[2];

		public float ringPinkySplay => fingerSplays[3];

		public float lastThumbCurl => lastFingerCurls[0];

		public float lastIndexCurl => lastFingerCurls[1];

		public float lastMiddleCurl => lastFingerCurls[2];

		public float lastRingCurl => lastFingerCurls[3];

		public float lastPinkyCurl => lastFingerCurls[4];

		public float lastThumbIndexSplay => lastFingerSplays[0];

		public float lastIndexMiddleSplay => lastFingerSplays[1];

		public float lastMiddleRingSplay => lastFingerSplays[2];

		public float lastRingPinkySplay => lastFingerSplays[3];

		public float[] fingerCurls { get; protected set; }

		public float[] fingerSplays { get; protected set; }

		public float[] lastFingerCurls { get; protected set; }

		public float[] lastFingerSplays { get; protected set; }

		public bool poseChanged { get; protected set; }

		public bool onlyUpdateSummaryData { get; set; }

		public int boneCount => (int)GetBoneCount();

		public int[] boneHierarchy => GetBoneHierarchy();

		public EVRSkeletalTrackingLevel skeletalTrackingLevel => GetSkeletalTrackingLevel();

		public new event SteamVR_Action_Skeleton.ActiveChangeHandler onActiveChange;

		public new event SteamVR_Action_Skeleton.ActiveChangeHandler onActiveBindingChange;

		public new event SteamVR_Action_Skeleton.ChangeHandler onChange;

		public new event SteamVR_Action_Skeleton.UpdateHandler onUpdate;

		public new event SteamVR_Action_Skeleton.TrackingChangeHandler onTrackingChanged;

		public new event SteamVR_Action_Skeleton.ValidPoseChangeHandler onValidPoseChanged;

		public new event SteamVR_Action_Skeleton.DeviceConnectedChangeHandler onDeviceConnectedChanged;

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			skeletonAction = (SteamVR_Action_Skeleton)wrappingAction;
			bonePositions = new Vector3[31];
			lastBonePositions = new Vector3[31];
			boneRotations = new Quaternion[31];
			lastBoneRotations = new Quaternion[31];
			rangeOfMotion = EVRSkeletalMotionRange.WithController;
			skeletalTransformSpace = EVRSkeletalTransformSpace.Parent;
			fingerCurls = new float[SteamVR_Skeleton_FingerIndexes.enumArray.Length];
			fingerSplays = new float[SteamVR_Skeleton_FingerSplayIndexes.enumArray.Length];
			lastFingerCurls = new float[SteamVR_Skeleton_FingerIndexes.enumArray.Length];
			lastFingerSplays = new float[SteamVR_Skeleton_FingerSplayIndexes.enumArray.Length];
		}

		public override void Initialize()
		{
			base.Initialize();
			if (skeletonActionData_size == 0)
			{
				skeletonActionData_size = (uint)Marshal.SizeOf(typeof(InputSkeletalActionData_t));
			}
		}

		public override void RemoveAllListeners()
		{
			base.RemoveAllListeners();
			Delegate[] invocationList;
			if (this.onActiveChange != null)
			{
				invocationList = this.onActiveChange.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj in array)
					{
						onActiveChange -= (SteamVR_Action_Skeleton.ActiveChangeHandler)obj;
					}
				}
			}
			if (this.onChange != null)
			{
				invocationList = this.onChange.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj2 in array)
					{
						onChange -= (SteamVR_Action_Skeleton.ChangeHandler)obj2;
					}
				}
			}
			if (this.onUpdate != null)
			{
				invocationList = this.onUpdate.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj3 in array)
					{
						onUpdate -= (SteamVR_Action_Skeleton.UpdateHandler)obj3;
					}
				}
			}
			if (this.onTrackingChanged != null)
			{
				invocationList = this.onTrackingChanged.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj4 in array)
					{
						onTrackingChanged -= (SteamVR_Action_Skeleton.TrackingChangeHandler)obj4;
					}
				}
			}
			if (this.onValidPoseChanged != null)
			{
				invocationList = this.onValidPoseChanged.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj5 in array)
					{
						onValidPoseChanged -= (SteamVR_Action_Skeleton.ValidPoseChangeHandler)obj5;
					}
				}
			}
			if (this.onDeviceConnectedChanged == null)
			{
				return;
			}
			invocationList = this.onDeviceConnectedChanged.GetInvocationList();
			if (invocationList != null)
			{
				Delegate[] array = invocationList;
				foreach (Delegate obj6 in array)
				{
					onDeviceConnectedChanged -= (SteamVR_Action_Skeleton.DeviceConnectedChangeHandler)obj6;
				}
			}
		}

		public override void UpdateValue()
		{
			UpdateValue(skipStateAndEventUpdates: false);
		}

		public override void UpdateValue(bool skipStateAndEventUpdates)
		{
			lastActive = active;
			lastSkeletonActionData = skeletonActionData;
			lastSkeletalSummaryData = skeletalSummaryData;
			if (!onlyUpdateSummaryData)
			{
				for (int i = 0; i < 31; i++)
				{
					lastBonePositions[i] = bonePositions[i];
					lastBoneRotations[i] = boneRotations[i];
				}
			}
			for (int j = 0; j < SteamVR_Skeleton_FingerIndexes.enumArray.Length; j++)
			{
				lastFingerCurls[j] = fingerCurls[j];
			}
			for (int k = 0; k < SteamVR_Skeleton_FingerSplayIndexes.enumArray.Length; k++)
			{
				lastFingerSplays[k] = fingerSplays[k];
			}
			base.UpdateValue(skipStateAndEventUpdates: true);
			poseChanged = changed;
			EVRInputError skeletalActionData = OpenVR.Input.GetSkeletalActionData(base.handle, ref skeletonActionData, skeletonActionData_size);
			if (skeletalActionData != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetSkeletalActionData error (" + base.fullPath + "): " + skeletalActionData.ToString() + " handle: " + base.handle);
				return;
			}
			if (active)
			{
				if (!onlyUpdateSummaryData)
				{
					skeletalActionData = OpenVR.Input.GetSkeletalBoneData(base.handle, skeletalTransformSpace, rangeOfMotion, tempBoneTransforms);
					if (skeletalActionData != EVRInputError.None)
					{
						UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetSkeletalBoneData error (" + base.fullPath + "): " + skeletalActionData.ToString() + " handle: " + base.handle);
					}
					for (int l = 0; l < tempBoneTransforms.Length; l++)
					{
						bonePositions[l].x = 0f - tempBoneTransforms[l].position.v0;
						bonePositions[l].y = tempBoneTransforms[l].position.v1;
						bonePositions[l].z = tempBoneTransforms[l].position.v2;
						boneRotations[l].x = tempBoneTransforms[l].orientation.x;
						boneRotations[l].y = 0f - tempBoneTransforms[l].orientation.y;
						boneRotations[l].z = 0f - tempBoneTransforms[l].orientation.z;
						boneRotations[l].w = tempBoneTransforms[l].orientation.w;
					}
					boneRotations[0] = SteamVR_Action_Skeleton.steamVRFixUpRotation * boneRotations[0];
				}
				UpdateSkeletalSummaryData(summaryDataType, force: true);
			}
			if (!changed)
			{
				for (int m = 0; m < tempBoneTransforms.Length; m++)
				{
					if (Vector3.Distance(lastBonePositions[m], bonePositions[m]) > changeTolerance)
					{
						changed = true;
						break;
					}
					if (Mathf.Abs(Quaternion.Angle(lastBoneRotations[m], boneRotations[m])) > changeTolerance)
					{
						changed = true;
						break;
					}
				}
			}
			if (changed)
			{
				base.changedTime = Time.realtimeSinceStartup;
			}
			if (!skipStateAndEventUpdates)
			{
				CheckAndSendEvents();
			}
		}

		public uint GetBoneCount()
		{
			uint pBoneCount = 0u;
			EVRInputError eVRInputError = OpenVR.Input.GetBoneCount(base.handle, ref pBoneCount);
			if (eVRInputError != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetBoneCount error (" + base.fullPath + "): " + eVRInputError.ToString() + " handle: " + base.handle);
			}
			return pBoneCount;
		}

		public int[] GetBoneHierarchy()
		{
			int[] array = new int[GetBoneCount()];
			EVRInputError eVRInputError = OpenVR.Input.GetBoneHierarchy(base.handle, array);
			if (eVRInputError != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetBoneHierarchy error (" + base.fullPath + "): " + eVRInputError.ToString() + " handle: " + base.handle);
			}
			return array;
		}

		public string GetBoneName(int boneIndex)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			EVRInputError boneName = OpenVR.Input.GetBoneName(base.handle, boneIndex, stringBuilder, 255u);
			if (boneName != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetBoneName error (" + base.fullPath + "): " + boneName.ToString() + " handle: " + base.handle);
			}
			return stringBuilder.ToString();
		}

		public SteamVR_Utils.RigidTransform[] GetReferenceTransforms(EVRSkeletalTransformSpace transformSpace, EVRSkeletalReferencePose referencePose)
		{
			SteamVR_Utils.RigidTransform[] array = new SteamVR_Utils.RigidTransform[GetBoneCount()];
			VRBoneTransform_t[] array2 = new VRBoneTransform_t[array.Length];
			EVRInputError skeletalReferenceTransforms = OpenVR.Input.GetSkeletalReferenceTransforms(base.handle, transformSpace, referencePose, array2);
			if (skeletalReferenceTransforms != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetSkeletalReferenceTransforms error (" + base.fullPath + "): " + skeletalReferenceTransforms.ToString() + " handle: " + base.handle);
			}
			for (int i = 0; i < array2.Length; i++)
			{
				Vector3 pos = new Vector3(0f - array2[i].position.v0, array2[i].position.v1, array2[i].position.v2);
				Quaternion rot = new Quaternion(array2[i].orientation.x, 0f - array2[i].orientation.y, 0f - array2[i].orientation.z, array2[i].orientation.w);
				array[i] = new SteamVR_Utils.RigidTransform(pos, rot);
			}
			if (array.Length != 0)
			{
				Quaternion quaternion = Quaternion.AngleAxis(180f, Vector3.up);
				array[0].rot = quaternion * array[0].rot;
			}
			return array;
		}

		public EVRSkeletalTrackingLevel GetSkeletalTrackingLevel()
		{
			EVRSkeletalTrackingLevel pSkeletalTrackingLevel = EVRSkeletalTrackingLevel.VRSkeletalTracking_Estimated;
			EVRInputError eVRInputError = OpenVR.Input.GetSkeletalTrackingLevel(base.handle, ref pSkeletalTrackingLevel);
			if (eVRInputError != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetSkeletalTrackingLevel error (" + base.fullPath + "): " + eVRInputError.ToString() + " handle: " + base.handle);
			}
			return pSkeletalTrackingLevel;
		}

		protected VRSkeletalSummaryData_t GetSkeletalSummaryData(EVRSummaryType summaryType = EVRSummaryType.FromAnimation, bool force = false)
		{
			UpdateSkeletalSummaryData(summaryType, force);
			return skeletalSummaryData;
		}

		protected void UpdateSkeletalSummaryData(EVRSummaryType summaryType = EVRSummaryType.FromAnimation, bool force = false)
		{
			if (force || (summaryDataType != summaryDataType && active))
			{
				EVRInputError eVRInputError = OpenVR.Input.GetSkeletalSummaryData(base.handle, summaryType, ref skeletalSummaryData);
				if (eVRInputError != EVRInputError.None)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetSkeletalSummaryData error (" + base.fullPath + "): " + eVRInputError.ToString() + " handle: " + base.handle);
				}
				fingerCurls[0] = skeletalSummaryData.flFingerCurl0;
				fingerCurls[1] = skeletalSummaryData.flFingerCurl1;
				fingerCurls[2] = skeletalSummaryData.flFingerCurl2;
				fingerCurls[3] = skeletalSummaryData.flFingerCurl3;
				fingerCurls[4] = skeletalSummaryData.flFingerCurl4;
				fingerSplays[0] = skeletalSummaryData.flFingerSplay0;
				fingerSplays[1] = skeletalSummaryData.flFingerSplay1;
				fingerSplays[2] = skeletalSummaryData.flFingerSplay2;
				fingerSplays[3] = skeletalSummaryData.flFingerSplay3;
			}
		}

		protected override void CheckAndSendEvents()
		{
			if (base.trackingState != base.lastTrackingState && this.onTrackingChanged != null)
			{
				this.onTrackingChanged(skeletonAction, base.trackingState);
			}
			if (base.poseIsValid != base.lastPoseIsValid && this.onValidPoseChanged != null)
			{
				this.onValidPoseChanged(skeletonAction, base.poseIsValid);
			}
			if (base.deviceIsConnected != base.lastDeviceIsConnected && this.onDeviceConnectedChanged != null)
			{
				this.onDeviceConnectedChanged(skeletonAction, base.deviceIsConnected);
			}
			if (changed && this.onChange != null)
			{
				this.onChange(skeletonAction);
			}
			if (active != lastActive && this.onActiveChange != null)
			{
				this.onActiveChange(skeletonAction, active);
			}
			if (activeBinding != lastActiveBinding && this.onActiveBindingChange != null)
			{
				this.onActiveBindingChange(skeletonAction, activeBinding);
			}
			if (this.onUpdate != null)
			{
				this.onUpdate(skeletonAction);
			}
		}
	}
	public interface ISteamVR_Action_Skeleton_Source
	{
		EVRSkeletalTrackingLevel skeletalTrackingLevel { get; }

		Vector3[] bonePositions { get; }

		Quaternion[] boneRotations { get; }

		Vector3[] lastBonePositions { get; }

		Quaternion[] lastBoneRotations { get; }

		EVRSkeletalMotionRange rangeOfMotion { get; set; }

		EVRSkeletalTransformSpace skeletalTransformSpace { get; set; }

		bool onlyUpdateSummaryData { get; set; }

		float thumbCurl { get; }

		float indexCurl { get; }

		float middleCurl { get; }

		float ringCurl { get; }

		float pinkyCurl { get; }

		float thumbIndexSplay { get; }

		float indexMiddleSplay { get; }

		float middleRingSplay { get; }

		float ringPinkySplay { get; }

		float lastThumbCurl { get; }

		float lastIndexCurl { get; }

		float lastMiddleCurl { get; }

		float lastRingCurl { get; }

		float lastPinkyCurl { get; }

		float lastThumbIndexSplay { get; }

		float lastIndexMiddleSplay { get; }

		float lastMiddleRingSplay { get; }

		float lastRingPinkySplay { get; }

		float[] fingerCurls { get; }

		float[] fingerSplays { get; }

		float[] lastFingerCurls { get; }

		float[] lastFingerSplays { get; }
	}
	public enum SkeletalMotionRangeChange
	{
		None = -1,
		WithController,
		WithoutController
	}
	public static class SteamVR_Skeleton_JointIndexes
	{
		public const int root = 0;

		public const int wrist = 1;

		public const int thumbMetacarpal = 2;

		public const int thumbProximal = 2;

		public const int thumbMiddle = 3;

		public const int thumbDistal = 4;

		public const int thumbTip = 5;

		public const int indexMetacarpal = 6;

		public const int indexProximal = 7;

		public const int indexMiddle = 8;

		public const int indexDistal = 9;

		public const int indexTip = 10;

		public const int middleMetacarpal = 11;

		public const int middleProximal = 12;

		public const int middleMiddle = 13;

		public const int middleDistal = 14;

		public const int middleTip = 15;

		public const int ringMetacarpal = 16;

		public const int ringProximal = 17;

		public const int ringMiddle = 18;

		public const int ringDistal = 19;

		public const int ringTip = 20;

		public const int pinkyMetacarpal = 21;

		public const int pinkyProximal = 22;

		public const int pinkyMiddle = 23;

		public const int pinkyDistal = 24;

		public const int pinkyTip = 25;

		public const int thumbAux = 26;

		public const int indexAux = 27;

		public const int middleAux = 28;

		public const int ringAux = 29;

		public const int pinkyAux = 30;

		public static int GetFingerForBone(int boneIndex)
		{
			switch (boneIndex)
			{
			case 0:
			case 1:
				return -1;
			case 2:
			case 3:
			case 4:
			case 5:
			case 26:
				return 0;
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 27:
				return 1;
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 28:
				return 2;
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 29:
				return 3;
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 30:
				return 4;
			default:
				return -1;
			}
		}

		public static int GetBoneForFingerTip(int fingerIndex)
		{
			return fingerIndex switch
			{
				0 => 5, 
				1 => 10, 
				2 => 15, 
				3 => 20, 
				4 => 25, 
				_ => 10, 
			};
		}
	}
	public enum SteamVR_Skeleton_JointIndexEnum
	{
		root = 0,
		wrist = 1,
		thumbMetacarpal = 2,
		thumbProximal = 2,
		thumbMiddle = 3,
		thumbDistal = 4,
		thumbTip = 5,
		indexMetacarpal = 6,
		indexProximal = 7,
		indexMiddle = 8,
		indexDistal = 9,
		indexTip = 10,
		middleMetacarpal = 11,
		middleProximal = 12,
		middleMiddle = 13,
		middleDistal = 14,
		middleTip = 15,
		ringMetacarpal = 16,
		ringProximal = 17,
		ringMiddle = 18,
		ringDistal = 19,
		ringTip = 20,
		pinkyMetacarpal = 21,
		pinkyProximal = 22,
		pinkyMiddle = 23,
		pinkyDistal = 24,
		pinkyTip = 25,
		thumbAux = 26,
		indexAux = 27,
		middleAux = 28,
		ringAux = 29,
		pinkyAux = 30
	}
	public class SteamVR_Skeleton_FingerIndexes
	{
		public const int thumb = 0;

		public const int index = 1;

		public const int middle = 2;

		public const int ring = 3;

		public const int pinky = 4;

		public static SteamVR_Skeleton_FingerIndexEnum[] enumArray = (SteamVR_Skeleton_FingerIndexEnum[])Enum.GetValues(typeof(SteamVR_Skeleton_FingerIndexEnum));
	}
	public class SteamVR_Skeleton_FingerSplayIndexes
	{
		public const int thumbIndex = 0;

		public const int indexMiddle = 1;

		public const int middleRing = 2;

		public const int ringPinky = 3;

		public static SteamVR_Skeleton_FingerSplayIndexEnum[] enumArray = (SteamVR_Skeleton_FingerSplayIndexEnum[])Enum.GetValues(typeof(SteamVR_Skeleton_FingerSplayIndexEnum));
	}
	public enum SteamVR_Skeleton_FingerSplayIndexEnum
	{
		thumbIndex,
		indexMiddle,
		middleRing,
		ringPinky
	}
	public enum SteamVR_Skeleton_FingerIndexEnum
	{
		thumb,
		index,
		middle,
		ring,
		pinky
	}
	[Serializable]
	public class SteamVR_Action_Vector2 : SteamVR_Action_In<SteamVR_Action_Vector2_Source_Map, SteamVR_Action_Vector2_Source>, ISteamVR_Action_Vector2, ISteamVR_Action_In_Source, ISteamVR_Action_Source, ISerializationCallbackReceiver
	{
		public delegate void AxisHandler(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta);

		public delegate void ActiveChangeHandler(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta);

		public delegate void UpdateHandler(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta);

		public Vector2 axis => sourceMap[SteamVR_Input_Sources.Any].axis;

		public Vector2 lastAxis => sourceMap[SteamVR_Input_Sources.Any].lastAxis;

		public Vector2 delta => sourceMap[SteamVR_Input_Sources.Any].delta;

		public Vector2 lastDelta => sourceMap[SteamVR_Input_Sources.Any].lastDelta;

		public event ChangeHandler onChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange -= value;
			}
		}

		public event UpdateHandler onUpdate
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate -= value;
			}
		}

		public event AxisHandler onAxis
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onAxis += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onAxis -= value;
			}
		}

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public Vector2 GetAxis(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].axis;
		}

		public Vector2 GetAxisDelta(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].delta;
		}

		public Vector2 GetLastAxis(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastAxis;
		}

		public Vector2 GetLastAxisDelta(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastDelta;
		}

		public void AddOnActiveChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange -= functionToStopCalling;
		}

		public void AddOnActiveBindingChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange += functionToCall;
		}

		public void RemoveOnActiveBindingChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange -= functionToStopCalling;
		}

		public void AddOnChangeListener(ChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange += functionToCall;
		}

		public void RemoveOnChangeListener(ChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange -= functionToStopCalling;
		}

		public void AddOnUpdateListener(UpdateHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate += functionToCall;
		}

		public void RemoveOnUpdateListener(UpdateHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate -= functionToStopCalling;
		}

		public void AddOnAxisListener(AxisHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onAxis += functionToCall;
		}

		public void RemoveOnAxisListener(AxisHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onAxis -= functionToStopCalling;
		}

		public void RemoveAllListeners(SteamVR_Input_Sources input_Sources)
		{
			sourceMap[input_Sources].RemoveAllListeners();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}
	}
	public class SteamVR_Action_Vector2_Source_Map : SteamVR_Action_In_Source_Map<SteamVR_Action_Vector2_Source>
	{
	}
	public class SteamVR_Action_Vector2_Source : SteamVR_Action_In_Source, ISteamVR_Action_Vector2, ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		protected static uint actionData_size;

		public float changeTolerance = Mathf.Epsilon;

		protected InputAnalogActionData_t actionData;

		protected InputAnalogActionData_t lastActionData;

		protected SteamVR_Action_Vector2 vector2Action;

		public Vector2 axis { get; protected set; }

		public Vector2 lastAxis { get; protected set; }

		public Vector2 delta { get; protected set; }

		public Vector2 lastDelta { get; protected set; }

		public override bool changed { get; protected set; }

		public override bool lastChanged { get; protected set; }

		public override ulong activeOrigin
		{
			get
			{
				if (active)
				{
					return actionData.activeOrigin;
				}
				return 0uL;
			}
		}

		public override ulong lastActiveOrigin => lastActionData.activeOrigin;

		public override bool active
		{
			get
			{
				if (activeBinding)
				{
					return action.actionSet.IsActive(base.inputSource);
				}
				return false;
			}
		}

		public override bool activeBinding => actionData.bActive;

		public override bool lastActive { get; protected set; }

		public override bool lastActiveBinding => lastActionData.bActive;

		public event SteamVR_Action_Vector2.AxisHandler onAxis;

		public event SteamVR_Action_Vector2.ActiveChangeHandler onActiveChange;

		public event SteamVR_Action_Vector2.ActiveChangeHandler onActiveBindingChange;

		public event SteamVR_Action_Vector2.ChangeHandler onChange;

		public event SteamVR_Action_Vector2.UpdateHandler onUpdate;

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			vector2Action = (SteamVR_Action_Vector2)wrappingAction;
		}

		public override void Initialize()
		{
			base.Initialize();
			if (actionData_size == 0)
			{
				actionData_size = (uint)Marshal.SizeOf(typeof(InputAnalogActionData_t));
			}
		}

		public void RemoveAllListeners()
		{
			Delegate[] invocationList;
			if (this.onAxis != null)
			{
				invocationList = this.onAxis.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj in array)
					{
						onAxis -= (SteamVR_Action_Vector2.AxisHandler)obj;
					}
				}
			}
			if (this.onUpdate != null)
			{
				invocationList = this.onUpdate.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj2 in array)
					{
						onUpdate -= (SteamVR_Action_Vector2.UpdateHandler)obj2;
					}
				}
			}
			if (this.onChange == null)
			{
				return;
			}
			invocationList = this.onChange.GetInvocationList();
			if (invocationList != null)
			{
				Delegate[] array = invocationList;
				foreach (Delegate obj3 in array)
				{
					onChange -= (SteamVR_Action_Vector2.ChangeHandler)obj3;
				}
			}
		}

		public override void UpdateValue()
		{
			lastActionData = actionData;
			lastActive = active;
			lastAxis = axis;
			lastDelta = delta;
			EVRInputError analogActionData = OpenVR.Input.GetAnalogActionData(base.handle, ref actionData, actionData_size, SteamVR_Input_Source.GetHandle(base.inputSource));
			if (analogActionData != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetAnalogActionData error (" + base.fullPath + "): " + analogActionData.ToString() + " handle: " + base.handle);
			}
			base.updateTime = Time.realtimeSinceStartup;
			axis = new Vector2(actionData.x, actionData.y);
			delta = new Vector2(actionData.deltaX, actionData.deltaY);
			changed = false;
			if (active)
			{
				if (delta.magnitude > changeTolerance)
				{
					changed = true;
					base.changedTime = Time.realtimeSinceStartup + actionData.fUpdateTime;
					if (this.onChange != null)
					{
						this.onChange(vector2Action, base.inputSource, axis, delta);
					}
				}
				if (axis != Vector2.zero && this.onAxis != null)
				{
					this.onAxis(vector2Action, base.inputSource, axis, delta);
				}
				if (this.onUpdate != null)
				{
					this.onUpdate(vector2Action, base.inputSource, axis, delta);
				}
			}
			if (this.onActiveBindingChange != null && lastActiveBinding != activeBinding)
			{
				this.onActiveBindingChange(vector2Action, base.inputSource, activeBinding);
			}
			if (this.onActiveChange != null && lastActive != active)
			{
				this.onActiveChange(vector2Action, base.inputSource, activeBinding);
			}
		}
	}
	public interface ISteamVR_Action_Vector2 : ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		Vector2 axis { get; }

		Vector2 lastAxis { get; }

		Vector2 delta { get; }

		Vector2 lastDelta { get; }
	}
	[Serializable]
	public class SteamVR_Action_Vector3 : SteamVR_Action_In<SteamVR_Action_Vector3_Source_Map, SteamVR_Action_Vector3_Source>, ISteamVR_Action_Vector3, ISteamVR_Action_In_Source, ISteamVR_Action_Source, ISerializationCallbackReceiver
	{
		public delegate void AxisHandler(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 axis, Vector3 delta);

		public delegate void ActiveChangeHandler(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 axis, Vector3 delta);

		public delegate void UpdateHandler(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 axis, Vector3 delta);

		public Vector3 axis => sourceMap[SteamVR_Input_Sources.Any].axis;

		public Vector3 lastAxis => sourceMap[SteamVR_Input_Sources.Any].lastAxis;

		public Vector3 delta => sourceMap[SteamVR_Input_Sources.Any].delta;

		public Vector3 lastDelta => sourceMap[SteamVR_Input_Sources.Any].lastDelta;

		public event ChangeHandler onChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onChange -= value;
			}
		}

		public event UpdateHandler onUpdate
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onUpdate -= value;
			}
		}

		public event AxisHandler onAxis
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onAxis += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onAxis -= value;
			}
		}

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public Vector3 GetAxis(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].axis;
		}

		public Vector3 GetAxisDelta(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].delta;
		}

		public Vector3 GetLastAxis(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastAxis;
		}

		public Vector3 GetLastAxisDelta(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].lastDelta;
		}

		public void AddOnActiveChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange -= functionToStopCalling;
		}

		public void AddOnActiveBindingChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange += functionToCall;
		}

		public void RemoveOnActiveBindingChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange -= functionToStopCalling;
		}

		public void AddOnChangeListener(ChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange += functionToCall;
		}

		public void RemoveOnChangeListener(ChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onChange -= functionToStopCalling;
		}

		public void AddOnUpdateListener(UpdateHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate += functionToCall;
		}

		public void RemoveOnUpdateListener(UpdateHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onUpdate -= functionToStopCalling;
		}

		public void AddOnAxisListener(AxisHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onAxis += functionToCall;
		}

		public void RemoveOnAxisListener(AxisHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onAxis -= functionToStopCalling;
		}

		public void RemoveAllListeners(SteamVR_Input_Sources input_Sources)
		{
			sourceMap[input_Sources].RemoveAllListeners();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}
	}
	public class SteamVR_Action_Vector3_Source_Map : SteamVR_Action_In_Source_Map<SteamVR_Action_Vector3_Source>
	{
	}
	public class SteamVR_Action_Vector3_Source : SteamVR_Action_In_Source, ISteamVR_Action_Vector3, ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		protected static uint actionData_size;

		public float changeTolerance = Mathf.Epsilon;

		protected InputAnalogActionData_t actionData;

		protected InputAnalogActionData_t lastActionData;

		protected SteamVR_Action_Vector3 vector3Action;

		public Vector3 axis { get; protected set; }

		public Vector3 lastAxis { get; protected set; }

		public Vector3 delta { get; protected set; }

		public Vector3 lastDelta { get; protected set; }

		public override bool changed { get; protected set; }

		public override bool lastChanged { get; protected set; }

		public override ulong activeOrigin
		{
			get
			{
				if (active)
				{
					return actionData.activeOrigin;
				}
				return 0uL;
			}
		}

		public override ulong lastActiveOrigin => lastActionData.activeOrigin;

		public override bool active
		{
			get
			{
				if (activeBinding)
				{
					return action.actionSet.IsActive(base.inputSource);
				}
				return false;
			}
		}

		public override bool activeBinding => actionData.bActive;

		public override bool lastActive { get; protected set; }

		public override bool lastActiveBinding => lastActionData.bActive;

		public event SteamVR_Action_Vector3.AxisHandler onAxis;

		public event SteamVR_Action_Vector3.ActiveChangeHandler onActiveChange;

		public event SteamVR_Action_Vector3.ActiveChangeHandler onActiveBindingChange;

		public event SteamVR_Action_Vector3.ChangeHandler onChange;

		public event SteamVR_Action_Vector3.UpdateHandler onUpdate;

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			vector3Action = (SteamVR_Action_Vector3)wrappingAction;
		}

		public override void Initialize()
		{
			base.Initialize();
			if (actionData_size == 0)
			{
				actionData_size = (uint)Marshal.SizeOf(typeof(InputAnalogActionData_t));
			}
		}

		public void RemoveAllListeners()
		{
			Delegate[] invocationList;
			if (this.onAxis != null)
			{
				invocationList = this.onAxis.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj in array)
					{
						onAxis -= (SteamVR_Action_Vector3.AxisHandler)obj;
					}
				}
			}
			if (this.onUpdate != null)
			{
				invocationList = this.onUpdate.GetInvocationList();
				if (invocationList != null)
				{
					Delegate[] array = invocationList;
					foreach (Delegate obj2 in array)
					{
						onUpdate -= (SteamVR_Action_Vector3.UpdateHandler)obj2;
					}
				}
			}
			if (this.onChange == null)
			{
				return;
			}
			invocationList = this.onChange.GetInvocationList();
			if (invocationList != null)
			{
				Delegate[] array = invocationList;
				foreach (Delegate obj3 in array)
				{
					onChange -= (SteamVR_Action_Vector3.ChangeHandler)obj3;
				}
			}
		}

		public override void UpdateValue()
		{
			lastActionData = actionData;
			lastActive = active;
			lastAxis = axis;
			lastDelta = delta;
			EVRInputError analogActionData = OpenVR.Input.GetAnalogActionData(base.handle, ref actionData, actionData_size, SteamVR_Input_Source.GetHandle(base.inputSource));
			if (analogActionData != EVRInputError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetAnalogActionData error (" + base.fullPath + "): " + analogActionData.ToString() + " handle: " + base.handle);
			}
			base.updateTime = Time.realtimeSinceStartup;
			axis = new Vector3(actionData.x, actionData.y, actionData.z);
			delta = new Vector3(actionData.deltaX, actionData.deltaY, actionData.deltaZ);
			changed = false;
			if (active)
			{
				if (delta.magnitude > changeTolerance)
				{
					changed = true;
					base.changedTime = Time.realtimeSinceStartup + actionData.fUpdateTime;
					if (this.onChange != null)
					{
						this.onChange(vector3Action, base.inputSource, axis, delta);
					}
				}
				if (axis != Vector3.zero && this.onAxis != null)
				{
					this.onAxis(vector3Action, base.inputSource, axis, delta);
				}
				if (this.onUpdate != null)
				{
					this.onUpdate(vector3Action, base.inputSource, axis, delta);
				}
			}
			if (this.onActiveBindingChange != null && lastActiveBinding != activeBinding)
			{
				this.onActiveBindingChange(vector3Action, base.inputSource, activeBinding);
			}
			if (this.onActiveChange != null && lastActive != active)
			{
				this.onActiveChange(vector3Action, base.inputSource, activeBinding);
			}
		}
	}
	public interface ISteamVR_Action_Vector3 : ISteamVR_Action_In_Source, ISteamVR_Action_Source
	{
		Vector3 axis { get; }

		Vector3 lastAxis { get; }

		Vector3 delta { get; }

		Vector3 lastDelta { get; }
	}
	[Serializable]
	public class SteamVR_Action_Vibration : SteamVR_Action_Out<SteamVR_Action_Vibration_Source_Map, SteamVR_Action_Vibration_Source>, ISerializationCallbackReceiver
	{
		public delegate void ActiveChangeHandler(SteamVR_Action_Vibration fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ExecuteHandler(SteamVR_Action_Vibration fromAction, SteamVR_Input_Sources fromSource, float secondsFromNow, float durationSeconds, float frequency, float amplitude);

		public event ActiveChangeHandler onActiveChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveChange -= value;
			}
		}

		public event ActiveChangeHandler onActiveBindingChange
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onActiveBindingChange -= value;
			}
		}

		public event ExecuteHandler onExecute
		{
			add
			{
				sourceMap[SteamVR_Input_Sources.Any].onExecute += value;
			}
			remove
			{
				sourceMap[SteamVR_Input_Sources.Any].onExecute -= value;
			}
		}

		public void Execute(float secondsFromNow, float durationSeconds, float frequency, float amplitude, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].Execute(secondsFromNow, durationSeconds, frequency, amplitude);
		}

		public void AddOnActiveChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange += functionToCall;
		}

		public void RemoveOnActiveChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveChange -= functionToStopCalling;
		}

		public void AddOnActiveBindingChangeListener(ActiveChangeHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange += functionToCall;
		}

		public void RemoveOnActiveBindingChangeListener(ActiveChangeHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onActiveBindingChange -= functionToStopCalling;
		}

		public void AddOnExecuteListener(ExecuteHandler functionToCall, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onExecute += functionToCall;
		}

		public void RemoveOnExecuteListener(ExecuteHandler functionToStopCalling, SteamVR_Input_Sources inputSource)
		{
			sourceMap[inputSource].onExecute -= functionToStopCalling;
		}

		public override float GetTimeLastChanged(SteamVR_Input_Sources inputSource)
		{
			return sourceMap[inputSource].timeLastExecuted;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			InitAfterDeserialize();
		}

		public override bool IsUpdating(SteamVR_Input_Sources inputSource)
		{
			return sourceMap.IsUpdating(inputSource);
		}
	}
	public class SteamVR_Action_Vibration_Source_Map : SteamVR_Action_Source_Map<SteamVR_Action_Vibration_Source>
	{
		public bool IsUpdating(SteamVR_Input_Sources inputSource)
		{
			return sources[(int)inputSource].timeLastExecuted != 0f;
		}
	}
	public class SteamVR_Action_Vibration_Source : SteamVR_Action_Out_Source
	{
		protected SteamVR_Action_Vibration vibrationAction;

		public override bool active
		{
			get
			{
				if (activeBinding)
				{
					return base.setActive;
				}
				return false;
			}
		}

		public override bool activeBinding => true;

		public override bool lastActive { get; protected set; }

		public override bool lastActiveBinding => true;

		public float timeLastExecuted { get; protected set; }

		public event SteamVR_Action_Vibration.ActiveChangeHandler onActiveChange;

		public event SteamVR_Action_Vibration.ActiveChangeHandler onActiveBindingChange;

		public event SteamVR_Action_Vibration.ExecuteHandler onExecute;

		public override void Initialize()
		{
			base.Initialize();
			lastActive = true;
		}

		public override void Preinitialize(SteamVR_Action wrappingAction, SteamVR_Input_Sources forInputSource)
		{
			base.Preinitialize(wrappingAction, forInputSource);
			vibrationAction = (SteamVR_Action_Vibration)wrappingAction;
		}

		public void Execute(float secondsFromNow, float durationSeconds, float frequency, float amplitude)
		{
			if (!SteamVR_Input.isStartupFrame)
			{
				timeLastExecuted = Time.realtimeSinceStartup;
				EVRInputError eVRInputError = OpenVR.Input.TriggerHapticVibrationAction(base.handle, secondsFromNow, durationSeconds, frequency, amplitude, inputSourceHandle);
				if (eVRInputError != EVRInputError.None)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> TriggerHapticVibrationAction (" + base.fullPath + ") error: " + eVRInputError.ToString() + " handle: " + base.handle);
				}
				if (this.onExecute != null)
				{
					this.onExecute(vibrationAction, base.inputSource, secondsFromNow, durationSeconds, frequency, amplitude);
				}
			}
		}
	}
	public interface ISteamVR_Action_Vibration : ISteamVR_Action_Out, ISteamVR_Action, ISteamVR_Action_Source, ISteamVR_Action_Out_Source
	{
		void Execute(float secondsFromNow, float durationSeconds, float frequency, float amplitude, SteamVR_Input_Sources inputSource);
	}
	public class SteamVR_ActivateActionSetOnLoad : MonoBehaviour
	{
		public SteamVR_ActionSet actionSet = SteamVR_Input.GetActionSet("default");

		public SteamVR_Input_Sources forSources;

		public bool disableAllOtherActionSets;

		public bool activateOnStart = true;

		public bool deactivateOnDestroy = true;

		public int initialPriority;

		private void Start()
		{
			if (actionSet != null && activateOnStart)
			{
				actionSet.Activate(forSources, initialPriority, disableAllOtherActionSets);
			}
		}

		private void OnDestroy()
		{
			if (actionSet != null && deactivateOnDestroy)
			{
				actionSet.Deactivate(forSources);
			}
		}
	}
	public class SteamVR_Behaviour_Boolean : MonoBehaviour
	{
		public delegate void StateDownHandler(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource);

		public delegate void StateUpHandler(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource);

		public delegate void StateHandler(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource);

		public delegate void ActiveChangeHandler(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState);

		public delegate void UpdateHandler(SteamVR_Behaviour_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState);

		[Tooltip("The SteamVR boolean action that this component should use")]
		public SteamVR_Action_Boolean booleanAction;

		[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
		public SteamVR_Input_Sources inputSource;

		public SteamVR_Behaviour_BooleanEvent onChange;

		public SteamVR_Behaviour_BooleanEvent onUpdate;

		public SteamVR_Behaviour_BooleanEvent onPress;

		public SteamVR_Behaviour_BooleanEvent onPressDown;

		public SteamVR_Behaviour_BooleanEvent onPressUp;

		public bool isActive => booleanAction[inputSource].active;

		public SteamVR_ActionSet actionSet
		{
			get
			{
				if (booleanAction != null)
				{
					return booleanAction.actionSet;
				}
				return null;
			}
		}

		public event ChangeHandler onChangeEvent;

		public event UpdateHandler onUpdateEvent;

		public event StateHandler onPressEvent;

		public event StateDownHandler onPressDownEvent;

		public event StateUpHandler onPressUpEvent;

		protected virtual void OnEnable()
		{
			if (booleanAction == null)
			{
				UnityEngine.Debug.LogError("[SteamVR] Boolean action not set.", this);
			}
			else
			{
				AddHandlers();
			}
		}

		protected virtual void OnDisable()
		{
			RemoveHandlers();
		}

		protected void AddHandlers()
		{
			booleanAction[inputSource].onUpdate += SteamVR_Behaviour_Boolean_OnUpdate;
			booleanAction[inputSource].onChange += SteamVR_Behaviour_Boolean_OnChange;
			booleanAction[inputSource].onState += SteamVR_Behaviour_Boolean_OnState;
			booleanAction[inputSource].onStateDown += SteamVR_Behaviour_Boolean_OnStateDown;
			booleanAction[inputSource].onStateUp += SteamVR_Behaviour_Boolean_OnStateUp;
		}

		protected void RemoveHandlers()
		{
			if (booleanAction != null)
			{
				booleanAction[inputSource].onUpdate -= SteamVR_Behaviour_Boolean_OnUpdate;
				booleanAction[inputSource].onChange -= SteamVR_Behaviour_Boolean_OnChange;
				booleanAction[inputSource].onState -= SteamVR_Behaviour_Boolean_OnState;
				booleanAction[inputSource].onStateDown -= SteamVR_Behaviour_Boolean_OnStateDown;
				booleanAction[inputSource].onStateUp -= SteamVR_Behaviour_Boolean_OnStateUp;
			}
		}

		private void SteamVR_Behaviour_Boolean_OnStateUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
		{
			if (onPressUp != null)
			{
				onPressUp.Invoke(this, fromSource, arg2: false);
			}
			if (this.onPressUpEvent != null)
			{
				this.onPressUpEvent(this, fromSource);
			}
		}

		private void SteamVR_Behaviour_Boolean_OnStateDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
		{
			if (onPressDown != null)
			{
				onPressDown.Invoke(this, fromSource, arg2: true);
			}
			if (this.onPressDownEvent != null)
			{
				this.onPressDownEvent(this, fromSource);
			}
		}

		private void SteamVR_Behaviour_Boolean_OnState(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
		{
			if (onPress != null)
			{
				onPress.Invoke(this, fromSource, arg2: true);
			}
			if (this.onPressEvent != null)
			{
				this.onPressEvent(this, fromSource);
			}
		}

		private void SteamVR_Behaviour_Boolean_OnUpdate(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
		{
			if (onUpdate != null)
			{
				onUpdate.Invoke(this, fromSource, newState);
			}
			if (this.onUpdateEvent != null)
			{
				this.onUpdateEvent(this, fromSource, newState);
			}
		}

		private void SteamVR_Behaviour_Boolean_OnChange(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
		{
			if (onChange != null)
			{
				onChange.Invoke(this, fromSource, newState);
			}
			if (this.onChangeEvent != null)
			{
				this.onChangeEvent(this, fromSource, newState);
			}
		}

		public string GetLocalizedName(params EVRInputStringBits[] localizedParts)
		{
			if (booleanAction != null)
			{
				return booleanAction.GetLocalizedOriginPart(inputSource, localizedParts);
			}
			return null;
		}
	}
	public class SteamVR_Behaviour_Pose : MonoBehaviour
	{
		public delegate void ActiveChangeHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource, bool active);

		public delegate void ChangeHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource);

		public delegate void UpdateHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource);

		public delegate void TrackingChangeHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource, ETrackingResult trackingState);

		public delegate void ValidPoseChangeHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource, bool validPose);

		public delegate void DeviceConnectedChangeHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource, bool deviceConnected);

		public delegate void DeviceIndexChangedHandler(SteamVR_Behaviour_Pose fromAction, SteamVR_Input_Sources fromSource, int newDeviceIndex);

		public SteamVR_Action_Pose poseAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("Pose");

		[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
		public SteamVR_Input_Sources inputSource;

		[Tooltip("If not set, relative to parent")]
		public Transform origin;

		public SteamVR_Behaviour_PoseEvent onTransformUpdated;

		public SteamVR_Behaviour_PoseEvent onTransformChanged;

		public SteamVR_Behaviour_Pose_ConnectedChangedEvent onConnectedChanged;

		public SteamVR_Behaviour_Pose_TrackingChangedEvent onTrackingChanged;

		public SteamVR_Behaviour_Pose_DeviceIndexChangedEvent onDeviceIndexChanged;

		public UpdateHandler onTransformUpdatedEvent;

		public ChangeHandler onTransformChangedEvent;

		public DeviceConnectedChangeHandler onConnectedChangedEvent;

		public TrackingChangeHandler onTrackingChangedEvent;

		public DeviceIndexChangedHandler onDeviceIndexChangedEvent;

		[Tooltip("Can be disabled to stop broadcasting bound device status changes")]
		public bool broadcastDeviceChanges = true;

		protected int deviceIndex = -1;

		protected SteamVR_HistoryBuffer historyBuffer = new SteamVR_HistoryBuffer(30);

		protected int lastFrameUpdated;

		public bool isValid => poseAction[inputSource].poseIsValid;

		public bool isActive => poseAction[inputSource].active;

		protected virtual void Start()
		{
			if (poseAction == null)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> No pose action set for this component", this);
				return;
			}
			CheckDeviceIndex();
			if (origin == null)
			{
				origin = base.transform.parent;
			}
		}

		protected virtual void OnEnable()
		{
			SteamVR.Initialize();
			if (poseAction != null)
			{
				poseAction[inputSource].onUpdate += SteamVR_Behaviour_Pose_OnUpdate;
				poseAction[inputSource].onDeviceConnectedChanged += OnDeviceConnectedChanged;
				poseAction[inputSource].onTrackingChanged += OnTrackingChanged;
				poseAction[inputSource].onChange += SteamVR_Behaviour_Pose_OnChange;
			}
		}

		protected virtual void OnDisable()
		{
			if (poseAction != null)
			{
				poseAction[inputSource].onUpdate -= SteamVR_Behaviour_Pose_OnUpdate;
				poseAction[inputSource].onDeviceConnectedChanged -= OnDeviceConnectedChanged;
				poseAction[inputSource].onTrackingChanged -= OnTrackingChanged;
				poseAction[inputSource].onChange -= SteamVR_Behaviour_Pose_OnChange;
			}
			historyBuffer.Clear();
		}

		private void SteamVR_Behaviour_Pose_OnUpdate(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource)
		{
			UpdateHistoryBuffer();
			UpdateTransform();
			if (onTransformUpdated != null)
			{
				onTransformUpdated.Invoke(this, inputSource);
			}
			if (onTransformUpdatedEvent != null)
			{
				onTransformUpdatedEvent(this, inputSource);
			}
		}

		protected virtual void UpdateTransform()
		{
			CheckDeviceIndex();
			if (origin != null)
			{
				base.transform.position = origin.transform.TransformPoint(poseAction[inputSource].localPosition);
				base.transform.rotation = origin.rotation * poseAction[inputSource].localRotation;
			}
			else
			{
				base.transform.localPosition = poseAction[inputSource].localPosition;
				base.transform.localRotation = poseAction[inputSource].localRotation;
			}
		}

		private void SteamVR_Behaviour_Pose_OnChange(SteamVR_Action_Pose fromAction, SteamVR_Input_Sources fromSource)
		{
			if (onTransformChanged != null)
			{
				onTransformChanged.Invoke(this, fromSource);
			}
			if (onTransformChangedEvent != null)
			{
				onTransformChangedEvent(this, fromSource);
			}
		}

		protected virtual void OnDeviceConnectedChanged(SteamVR_Action_Pose changedAction, SteamVR_Input_Sources changedSource, bool connected)
		{
			CheckDeviceIndex();
			if (onConnectedChanged != null)
			{
				onConnectedChanged.Invoke(this, inputSource, connected);
			}
			if (onConnectedChangedEvent != null)
			{
				onConnectedChangedEvent(this, inputSource, connected);
			}
		}

		protected virtual void OnTrackingChanged(SteamVR_Action_Pose changedAction, SteamVR_Input_Sources changedSource, ETrackingResult trackingChanged)
		{
			if (onTrackingChanged != null)
			{
				onTrackingChanged.Invoke(this, inputSource, trackingChanged);
			}
			if (onTrackingChangedEvent != null)
			{
				onTrackingChangedEvent(this, inputSource, trackingChanged);
			}
		}

		protected virtual void CheckDeviceIndex()
		{
			if (!poseAction[inputSource].active || !poseAction[inputSource].deviceIsConnected)
			{
				return;
			}
			int trackedDeviceIndex = (int)poseAction[inputSource].trackedDeviceIndex;
			if (deviceIndex != trackedDeviceIndex)
			{
				deviceIndex = trackedDeviceIndex;
				if (broadcastDeviceChanges)
				{
					base.gameObject.BroadcastMessage("SetInputSource", inputSource, SendMessageOptions.DontRequireReceiver);
					base.gameObject.BroadcastMessage("SetDeviceIndex", deviceIndex, SendMessageOptions.DontRequireReceiver);
				}
				if (onDeviceIndexChanged != null)
				{
					onDeviceIndexChanged.Invoke(this, inputSource, deviceIndex);
				}
				if (onDeviceIndexChangedEvent != null)
				{
					onDeviceIndexChangedEvent(this, inputSource, deviceIndex);
				}
			}
		}

		public int GetDeviceIndex()
		{
			if (deviceIndex == -1)
			{
				CheckDeviceIndex();
			}
			return deviceIndex;
		}

		public Vector3 GetVelocity()
		{
			return poseAction[inputSource].velocity;
		}

		public Vector3 GetAngularVelocity()
		{
			return poseAction[inputSource].angularVelocity;
		}

		public bool GetVelocitiesAtTimeOffset(float secondsFromNow, out Vector3 velocity, out Vector3 angularVelocity)
		{
			return poseAction[inputSource].GetVelocitiesAtTimeOffset(secondsFromNow, out velocity, out angularVelocity);
		}

		public void GetEstimatedPeakVelocities(out Vector3 velocity, out Vector3 angularVelocity)
		{
			int topVelocity = historyBuffer.GetTopVelocity(10, 1);
			historyBuffer.GetAverageVelocities(out velocity, out angularVelocity, 2, topVelocity);
		}

		protected void UpdateHistoryBuffer()
		{
			int frameCount = Time.frameCount;
			if (lastFrameUpdated != frameCount)
			{
				historyBuffer.Update(poseAction[inputSource].localPosition, poseAction[inputSource].localRotation, poseAction[inputSource].velocity, poseAction[inputSource].angularVelocity);
				lastFrameUpdated = frameCount;
			}
		}

		public string GetLocalizedName(params EVRInputStringBits[] localizedParts)
		{
			if (poseAction != null)
			{
				return poseAction.GetLocalizedOriginPart(inputSource, localizedParts);
			}
			return null;
		}
	}
	public class SteamVR_Behaviour_Single : MonoBehaviour
	{
		public delegate void AxisHandler(SteamVR_Behaviour_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta);

		public delegate void ChangeHandler(SteamVR_Behaviour_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta);

		public delegate void UpdateHandler(SteamVR_Behaviour_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta);

		public SteamVR_Action_Single singleAction;

		[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
		public SteamVR_Input_Sources inputSource;

		[Tooltip("Fires whenever the action's value has changed since the last update.")]
		public SteamVR_Behaviour_SingleEvent onChange;

		[Tooltip("Fires whenever the action's value has been updated.")]
		public SteamVR_Behaviour_SingleEvent onUpdate;

		[Tooltip("Fires whenever the action's value has been updated and is non-zero.")]
		public SteamVR_Behaviour_SingleEvent onAxis;

		public ChangeHandler onChangeEvent;

		public UpdateHandler onUpdateEvent;

		public AxisHandler onAxisEvent;

		public bool isActive => singleAction.GetActive(inputSource);

		protected virtual void OnEnable()
		{
			if (singleAction == null)
			{
				UnityEngine.Debug.LogError("[SteamVR] Single action not set.", this);
			}
			else
			{
				AddHandlers();
			}
		}

		protected virtual void OnDisable()
		{
			RemoveHandlers();
		}

		protected void AddHandlers()
		{
			singleAction[inputSource].onUpdate += SteamVR_Behaviour_Single_OnUpdate;
			singleAction[inputSource].onChange += SteamVR_Behaviour_Single_OnChange;
			singleAction[inputSource].onAxis += SteamVR_Behaviour_Single_OnAxis;
		}

		protected void RemoveHandlers()
		{
			if (singleAction != null)
			{
				singleAction[inputSource].onUpdate -= SteamVR_Behaviour_Single_OnUpdate;
				singleAction[inputSource].onChange -= SteamVR_Behaviour_Single_OnChange;
				singleAction[inputSource].onAxis -= SteamVR_Behaviour_Single_OnAxis;
			}
		}

		private void SteamVR_Behaviour_Single_OnUpdate(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
		{
			if (onUpdate != null)
			{
				onUpdate.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onUpdateEvent != null)
			{
				onUpdateEvent(this, fromSource, newAxis, newDelta);
			}
		}

		private void SteamVR_Behaviour_Single_OnChange(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
		{
			if (onChange != null)
			{
				onChange.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onChangeEvent != null)
			{
				onChangeEvent(this, fromSource, newAxis, newDelta);
			}
		}

		private void SteamVR_Behaviour_Single_OnAxis(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
		{
			if (onAxis != null)
			{
				onAxis.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onAxisEvent != null)
			{
				onAxisEvent(this, fromSource, newAxis, newDelta);
			}
		}

		public string GetLocalizedName(params EVRInputStringBits[] localizedParts)
		{
			if (singleAction != null)
			{
				return singleAction.GetLocalizedOriginPart(inputSource, localizedParts);
			}
			return null;
		}
	}
	public class SteamVR_Behaviour_Skeleton : MonoBehaviour
	{
		public enum MirrorType
		{
			None,
			LeftToRight,
			RightToLeft
		}

		public delegate void ActiveChangeHandler(SteamVR_Behaviour_Skeleton fromAction, SteamVR_Input_Sources inputSource, bool active);

		public delegate void ChangeHandler(SteamVR_Behaviour_Skeleton fromAction, SteamVR_Input_Sources inputSource);

		public delegate void UpdateHandler(SteamVR_Behaviour_Skeleton fromAction, SteamVR_Input_Sources inputSource);

		public delegate void TrackingChangeHandler(SteamVR_Behaviour_Skeleton fromAction, SteamVR_Input_Sources inputSource, ETrackingResult trackingState);

		public delegate void ValidPoseChangeHandler(SteamVR_Behaviour_Skeleton fromAction, SteamVR_Input_Sources inputSource, bool validPose);

		public delegate void DeviceConnectedChangeHandler(SteamVR_Behaviour_Skeleton fromAction, SteamVR_Input_Sources inputSource, bool deviceConnected);

		[Tooltip("If not set, will try to auto assign this based on 'Skeleton' + inputSource")]
		public SteamVR_Action_Skeleton skeletonAction;

		[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
		public SteamVR_Input_Sources inputSource;

		[Tooltip("The range of motion you'd like the hand to move in. With controller is the best estimate of the fingers wrapped around a controller. Without is from a flat hand to a fist.")]
		public EVRSkeletalMotionRange rangeOfMotion = EVRSkeletalMotionRange.WithoutController;

		[Tooltip("This needs to be in the order of: root -> wrist -> thumb, index, middle, ring, pinky")]
		public Transform skeletonRoot;

		[Tooltip("If not set, relative to parent")]
		public Transform origin;

		[Tooltip("Set to true if you want this script to update its position and rotation. False if this will be handled elsewhere")]
		public bool updatePose = true;

		[Tooltip("Check this to not set the positions of the bones. This is helpful for differently scaled skeletons.")]
		public bool onlySetRotations;

		[Range(0f, 1f)]
		[Tooltip("Modify this to blend between animations setup on the hand")]
		public float skeletonBlend = 1f;

		public SteamVR_Behaviour_SkeletonEvent onBoneTransformsUpdated;

		public SteamVR_Behaviour_SkeletonEvent onTransformUpdated;

		public SteamVR_Behaviour_SkeletonEvent onTransformChanged;

		public SteamVR_Behaviour_Skeleton_ConnectedChangedEvent onConnectedChanged;

		public SteamVR_Behaviour_Skeleton_TrackingChangedEvent onTrackingChanged;

		public UpdateHandler onBoneTransformsUpdatedEvent;

		public UpdateHandler onTransformUpdatedEvent;

		public ChangeHandler onTransformChangedEvent;

		public DeviceConnectedChangeHandler onConnectedChangedEvent;

		public TrackingChangeHandler onTrackingChangedEvent;

		[Tooltip("Is this rendermodel a mirror of another one?")]
		public MirrorType mirroring;

		[Header("No Skeleton - Fallback")]
		[Tooltip("The fallback SkeletonPoser to drive hand animation when no skeleton data is available")]
		public SteamVR_Skeleton_Poser fallbackPoser;

		[Tooltip("The fallback action to drive finger curl values when no skeleton data is available")]
		public SteamVR_Action_Single fallbackCurlAction;

		protected SteamVR_Skeleton_Poser blendPoser;

		protected SteamVR_Skeleton_PoseSnapshot blendSnapshot;

		protected Coroutine blendRoutine;

		protected Coroutine rangeOfMotionBlendRoutine;

		protected Coroutine attachRoutine;

		protected Transform[] bones;

		protected EVRSkeletalMotionRange? temporaryRangeOfMotion;

		protected static readonly Quaternion rightFlipAngle = Quaternion.AngleAxis(180f, Vector3.right);

		public bool skeletonAvailable => skeletonAction.activeBinding;

		public bool isActive => skeletonAction.GetActive();

		public float[] fingerCurls
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.GetFingerCurls();
				}
				float[] array = new float[5];
				for (int i = 0; i < 5; i++)
				{
					array[i] = fallbackCurlAction.GetAxis(inputSource);
				}
				return array;
			}
		}

		public float thumbCurl
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.GetFingerCurl(SteamVR_Skeleton_FingerIndexEnum.thumb);
				}
				return fallbackCurlAction.GetAxis(inputSource);
			}
		}

		public float indexCurl
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.GetFingerCurl(SteamVR_Skeleton_FingerIndexEnum.index);
				}
				return fallbackCurlAction.GetAxis(inputSource);
			}
		}

		public float middleCurl
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.GetFingerCurl(SteamVR_Skeleton_FingerIndexEnum.middle);
				}
				return fallbackCurlAction.GetAxis(inputSource);
			}
		}

		public float ringCurl
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.GetFingerCurl(SteamVR_Skeleton_FingerIndexEnum.ring);
				}
				return fallbackCurlAction.GetAxis(inputSource);
			}
		}

		public float pinkyCurl
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.GetFingerCurl(SteamVR_Skeleton_FingerIndexEnum.pinky);
				}
				return fallbackCurlAction.GetAxis(inputSource);
			}
		}

		public Transform root => bones[0];

		public Transform wrist => bones[1];

		public Transform indexMetacarpal => bones[6];

		public Transform indexProximal => bones[7];

		public Transform indexMiddle => bones[8];

		public Transform indexDistal => bones[9];

		public Transform indexTip => bones[10];

		public Transform middleMetacarpal => bones[11];

		public Transform middleProximal => bones[12];

		public Transform middleMiddle => bones[13];

		public Transform middleDistal => bones[14];

		public Transform middleTip => bones[15];

		public Transform pinkyMetacarpal => bones[21];

		public Transform pinkyProximal => bones[22];

		public Transform pinkyMiddle => bones[23];

		public Transform pinkyDistal => bones[24];

		public Transform pinkyTip => bones[25];

		public Transform ringMetacarpal => bones[16];

		public Transform ringProximal => bones[17];

		public Transform ringMiddle => bones[18];

		public Transform ringDistal => bones[19];

		public Transform ringTip => bones[20];

		public Transform thumbMetacarpal => bones[2];

		public Transform thumbProximal => bones[2];

		public Transform thumbMiddle => bones[3];

		public Transform thumbDistal => bones[4];

		public Transform thumbTip => bones[5];

		public Transform thumbAux => bones[26];

		public Transform indexAux => bones[27];

		public Transform middleAux => bones[28];

		public Transform ringAux => bones[29];

		public Transform pinkyAux => bones[30];

		public Transform[] proximals { get; protected set; }

		public Transform[] middles { get; protected set; }

		public Transform[] distals { get; protected set; }

		public Transform[] tips { get; protected set; }

		public Transform[] auxs { get; protected set; }

		public EVRSkeletalTrackingLevel skeletalTrackingLevel
		{
			get
			{
				if (skeletonAvailable)
				{
					return skeletonAction.skeletalTrackingLevel;
				}
				return EVRSkeletalTrackingLevel.VRSkeletalTracking_Estimated;
			}
		}

		public bool isBlending => blendRoutine != null;

		public SteamVR_ActionSet actionSet => skeletonAction.actionSet;

		public SteamVR_ActionDirections direction => skeletonAction.direction;

		protected virtual void Awake()
		{
			SteamVR.Initialize();
			AssignBonesArray();
			proximals = new Transform[5] { thumbProximal, indexProximal, middleProximal, ringProximal, pinkyProximal };
			middles = new Transform[5] { thumbMiddle, indexMiddle, middleMiddle, ringMiddle, pinkyMiddle };
			distals = new Transform[5] { thumbDistal, indexDistal, middleDistal, ringDistal, pinkyDistal };
			tips = new Transform[5] { thumbTip, indexTip, middleTip, ringTip, pinkyTip };
			auxs = new Transform[5] { thumbAux, indexAux, middleAux, ringAux, pinkyAux };
			CheckSkeletonAction();
		}

		protected virtual void CheckSkeletonAction()
		{
			if (skeletonAction == null)
			{
				skeletonAction = SteamVR_Input.GetAction<SteamVR_Action_Skeleton>("Skeleton" + inputSource);
			}
		}

		protected virtual void AssignBonesArray()
		{
			bones = skeletonRoot.GetComponentsInChildren<Transform>();
		}

		protected virtual void OnEnable()
		{
			CheckSkeletonAction();
			SteamVR_Input.onSkeletonsUpdated += SteamVR_Input_OnSkeletonsUpdated;
			if (skeletonAction != null)
			{
				skeletonAction.onDeviceConnectedChanged += OnDeviceConnectedChanged;
				skeletonAction.onTrackingChanged += OnTrackingChanged;
			}
		}

		protected virtual void OnDisable()
		{
			SteamVR_Input.onSkeletonsUpdated -= SteamVR_Input_OnSkeletonsUpdated;
			if (skeletonAction != null)
			{
				skeletonAction.onDeviceConnectedChanged -= OnDeviceConnectedChanged;
				skeletonAction.onTrackingChanged -= OnTrackingChanged;
			}
		}

		private void OnDeviceConnectedChanged(SteamVR_Action_Skeleton fromAction, bool deviceConnected)
		{
			if (onConnectedChanged != null)
			{
				onConnectedChanged.Invoke(this, inputSource, deviceConnected);
			}
			if (onConnectedChangedEvent != null)
			{
				onConnectedChangedEvent(this, inputSource, deviceConnected);
			}
		}

		private void OnTrackingChanged(SteamVR_Action_Skeleton fromAction, ETrackingResult trackingState)
		{
			if (onTrackingChanged != null)
			{
				onTrackingChanged.Invoke(this, inputSource, trackingState);
			}
			if (onTrackingChangedEvent != null)
			{
				onTrackingChangedEvent(this, inputSource, trackingState);
			}
		}

		protected virtual void SteamVR_Input_OnSkeletonsUpdated(bool skipSendingEvents)
		{
			UpdateSkeleton();
		}

		protected virtual void UpdateSkeleton()
		{
			if (skeletonAction == null)
			{
				return;
			}
			if (updatePose)
			{
				UpdatePose();
			}
			if (blendPoser != null && skeletonBlend < 1f)
			{
				if (blendSnapshot == null)
				{
					blendSnapshot = blendPoser.GetBlendedPose(this);
				}
				blendSnapshot = blendPoser.GetBlendedPose(this);
			}
			if (rangeOfMotionBlendRoutine == null)
			{
				if (temporaryRangeOfMotion.HasValue)
				{
					skeletonAction.SetRangeOfMotion(temporaryRangeOfMotion.Value);
				}
				else
				{
					skeletonAction.SetRangeOfMotion(rangeOfMotion);
				}
				UpdateSkeletonTransforms();
			}
		}

		public void SetTemporaryRangeOfMotion(EVRSkeletalMotionRange newRangeOfMotion, float blendOverSeconds = 0.1f)
		{
			if (rangeOfMotion != newRangeOfMotion || temporaryRangeOfMotion != newRangeOfMotion)
			{
				TemporaryRangeOfMotionBlend(newRangeOfMotion, blendOverSeconds);
			}
		}

		public void ResetTemporaryRangeOfMotion(float blendOverSeconds = 0.1f)
		{
			ResetTemporaryRangeOfMotionBlend(blendOverSeconds);
		}

		public void SetRangeOfMotion(EVRSkeletalMotionRange newRangeOfMotion, float blendOverSeconds = 0.1f)
		{
			if (rangeOfMotion != newRangeOfMotion)
			{
				RangeOfMotionBlend(newRangeOfMotion, blendOverSeconds);
			}
		}

		public void BlendToSkeleton(float overTime = 0.1f)
		{
			if (blendPoser != null)
			{
				blendSnapshot = blendPoser.GetBlendedPose(this);
			}
			blendPoser = null;
			BlendTo(1f, overTime);
		}

		public void BlendToPoser(SteamVR_Skeleton_Poser poser, float overTime = 0.1f)
		{
			if (!(poser == null))
			{
				blendPoser = poser;
				BlendTo(0f, overTime);
			}
		}

		public void BlendToAnimation(float overTime = 0.1f)
		{
			BlendTo(0f, overTime);
		}

		public void BlendTo(float blendToAmount, float overTime)
		{
			if (blendRoutine != null)
			{
				StopCoroutine(blendRoutine);
			}
			if (base.gameObject.activeInHierarchy)
			{
				blendRoutine = StartCoroutine(DoBlendRoutine(blendToAmount, overTime));
			}
		}

		protected IEnumerator DoBlendRoutine(float blendToAmount, float overTime)
		{
			float startTime = Time.time;
			float endTime = startTime + overTime;
			float startAmount = skeletonBlend;
			while (Time.time < endTime)
			{
				yield return null;
				skeletonBlend = Mathf.Lerp(startAmount, blendToAmount, (Time.time - startTime) / overTime);
			}
			skeletonBlend = blendToAmount;
			blendRoutine = null;
		}

		protected void RangeOfMotionBlend(EVRSkeletalMotionRange newRangeOfMotion, float blendOverSeconds)
		{
			if (rangeOfMotionBlendRoutine != null)
			{
				StopCoroutine(rangeOfMotionBlendRoutine);
			}
			EVRSkeletalMotionRange oldRangeOfMotion = rangeOfMotion;
			rangeOfMotion = newRangeOfMotion;
			if (base.gameObject.activeInHierarchy)
			{
				rangeOfMotionBlendRoutine = StartCoroutine(DoRangeOfMotionBlend(oldRangeOfMotion, newRangeOfMotion, blendOverSeconds));
			}
		}

		protected void TemporaryRangeOfMotionBlend(EVRSkeletalMotionRange newRangeOfMotion, float blendOverSeconds)
		{
			if (rangeOfMotionBlendRoutine != null)
			{
				StopCoroutine(rangeOfMotionBlendRoutine);
			}
			EVRSkeletalMotionRange value = rangeOfMotion;
			if (temporaryRangeOfMotion.HasValue)
			{
				value = temporaryRangeOfMotion.Value;
			}
			temporaryRangeOfMotion = newRangeOfMotion;
			if (base.gameObject.activeInHierarchy)
			{
				rangeOfMotionBlendRoutine = StartCoroutine(DoRangeOfMotionBlend(value, newRangeOfMotion, blendOverSeconds));
			}
		}

		protected void ResetTemporaryRangeOfMotionBlend(float blendOverSeconds)
		{
			if (temporaryRangeOfMotion.HasValue)
			{
				if (rangeOfMotionBlendRoutine != null)
				{
					StopCoroutine(rangeOfMotionBlendRoutine);
				}
				EVRSkeletalMotionRange value = temporaryRangeOfMotion.Value;
				EVRSkeletalMotionRange newRangeOfMotion = rangeOfMotion;
				temporaryRangeOfMotion = null;
				if (base.gameObject.activeInHierarchy)
				{
					rangeOfMotionBlendRoutine = StartCoroutine(DoRangeOfMotionBlend(value, newRangeOfMotion, blendOverSeconds));
				}
			}
		}

		protected IEnumerator DoRangeOfMotionBlend(EVRSkeletalMotionRange oldRangeOfMotion, EVRSkeletalMotionRange newRangeOfMotion, float overTime)
		{
			float startTime = Time.time;
			float endTime = startTime + overTime;
			while (Time.time < endTime)
			{
				yield return null;
				float t = (Time.time - startTime) / overTime;
				if (skeletonBlend > 0f)
				{
					skeletonAction.SetRangeOfMotion(oldRangeOfMotion);
					skeletonAction.UpdateValueWithoutEvents();
					Vector3[] array = (Vector3[])GetBonePositions().Clone();
					Quaternion[] array2 = (Quaternion[])GetBoneRotations().Clone();
					skeletonAction.SetRangeOfMotion(newRangeOfMotion);
					skeletonAction.UpdateValueWithoutEvents();
					Vector3[] bonePositions = GetBonePositions();
					Quaternion[] boneRotations = GetBoneRotations();
					for (int i = 0; i < bones.Length; i++)
					{
						if (bones[i] == null || !SteamVR_Utils.IsValid(boneRotations[i]) || !SteamVR_Utils.IsValid(array2[i]))
						{
							continue;
						}
						Vector3 vector = Vector3.Lerp(array[i], bonePositions[i], t);
						Quaternion quaternion = Quaternion.Lerp(array2[i], boneRotations[i], t);
						if (skeletonBlend < 1f)
						{
							if (blendPoser != null)
							{
								SetBonePosition(i, Vector3.Lerp(blendSnapshot.bonePositions[i], vector, skeletonBlend));
								SetBoneRotation(i, Quaternion.Lerp(GetBlendPoseForBone(i, quaternion), quaternion, skeletonBlend));
							}
							else
							{
								SetBonePosition(i, Vector3.Lerp(bones[i].localPosition, vector, skeletonBlend));
								SetBoneRotation(i, Quaternion.Lerp(bones[i].localRotation, quaternion, skeletonBlend));
							}
						}
						else
						{
							SetBonePosition(i, vector);
							SetBoneRotation(i, quaternion);
						}
					}
				}
				if (onBoneTransformsUpdated != null)
				{
					onBoneTransformsUpdated.Invoke(this, inputSource);
				}
				if (onBoneTransformsUpdatedEvent != null)
				{
					onBoneTransformsUpdatedEvent(this, inputSource);
				}
			}
			rangeOfMotionBlendRoutine = null;
		}

		protected virtual Quaternion GetBlendPoseForBone(int boneIndex, Quaternion skeletonRotation)
		{
			return blendSnapshot.boneRotations[boneIndex];
		}

		public virtual void UpdateSkeletonTransforms()
		{
			Vector3[] bonePositions = GetBonePositions();
			Quaternion[] boneRotations = GetBoneRotations();
			if (skeletonBlend <= 0f)
			{
				if (blendPoser != null)
				{
					SteamVR_Skeleton_Pose_Hand hand = blendPoser.skeletonMainPose.GetHand(inputSource);
					for (int i = 0; i < bones.Length; i++)
					{
						if (!(bones[i] == null))
						{
							if ((i == 1 && hand.ignoreWristPoseData) || (i == 0 && hand.ignoreRootPoseData))
							{
								SetBonePosition(i, bonePositions[i]);
								SetBoneRotation(i, boneRotations[i]);
							}
							else
							{
								Quaternion blendPoseForBone = GetBlendPoseForBone(i, boneRotations[i]);
								SetBonePosition(i, blendSnapshot.bonePositions[i]);
								SetBoneRotation(i, blendPoseForBone);
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < bones.Length; j++)
					{
						Quaternion blendPoseForBone2 = GetBlendPoseForBone(j, boneRotations[j]);
						SetBonePosition(j, blendSnapshot.bonePositions[j]);
						SetBoneRotation(j, blendPoseForBone2);
					}
				}
			}
			else if (skeletonBlend >= 1f)
			{
				for (int k = 0; k < bones.Length; k++)
				{
					if (!(bones[k] == null))
					{
						SetBonePosition(k, bonePositions[k]);
						SetBoneRotation(k, boneRotations[k]);
					}
				}
			}
			else
			{
				for (int l = 0; l < bones.Length; l++)
				{
					if (bones[l] == null)
					{
						continue;
					}
					if (blendPoser != null)
					{
						SteamVR_Skeleton_Pose_Hand hand2 = blendPoser.skeletonMainPose.GetHand(inputSource);
						if ((l == 1 && hand2.ignoreWristPoseData) || (l == 0 && hand2.ignoreRootPoseData))
						{
							SetBonePosition(l, bonePositions[l]);
							SetBoneRotation(l, boneRotations[l]);
						}
						else
						{
							SetBonePosition(l, Vector3.Lerp(blendSnapshot.bonePositions[l], bonePositions[l], skeletonBlend));
							SetBoneRotation(l, Quaternion.Lerp(blendSnapshot.boneRotations[l], boneRotations[l], skeletonBlend));
						}
					}
					else if (blendSnapshot == null)
					{
						SetBonePosition(l, Vector3.Lerp(bones[l].localPosition, bonePositions[l], skeletonBlend));
						SetBoneRotation(l, Quaternion.Lerp(bones[l].localRotation, boneRotations[l], skeletonBlend));
					}
					else
					{
						SetBonePosition(l, Vector3.Lerp(blendSnapshot.bonePositions[l], bonePositions[l], skeletonBlend));
						SetBoneRotation(l, Quaternion.Lerp(blendSnapshot.boneRotations[l], boneRotations[l], skeletonBlend));
					}
				}
			}
			if (onBoneTransformsUpdated != null)
			{
				onBoneTransformsUpdated.Invoke(this, inputSource);
			}
			if (onBoneTransformsUpdatedEvent != null)
			{
				onBoneTransformsUpdatedEvent(this, inputSource);
			}
		}

		public virtual void SetBonePosition(int boneIndex, Vector3 localPosition)
		{
			if (!onlySetRotations)
			{
				bones[boneIndex].localPosition = localPosition;
			}
		}

		public virtual void SetBoneRotation(int boneIndex, Quaternion localRotation)
		{
			bones[boneIndex].localRotation = localRotation;
		}

		public virtual Transform GetBone(int joint)
		{
			if (bones == null || bones.Length == 0)
			{
				Awake();
			}
			return bones[joint];
		}

		public Vector3 GetBonePosition(int joint, bool local = false)
		{
			if (local)
			{
				return bones[joint].localPosition;
			}
			return bones[joint].position;
		}

		public Quaternion GetBoneRotation(int joint, bool local = false)
		{
			if (local)
			{
				return bones[joint].localRotation;
			}
			return bones[joint].rotation;
		}

		protected Vector3[] GetBonePositions()
		{
			if (skeletonAvailable)
			{
				Vector3[] bonePositions = skeletonAction.GetBonePositions();
				if (mirroring == MirrorType.LeftToRight || mirroring == MirrorType.RightToLeft)
				{
					for (int i = 0; i < bonePositions.Length; i++)
					{
						bonePositions[i] = MirrorPosition(i, bonePositions[i]);
					}
				}
				return bonePositions;
			}
			if (fallbackPoser != null)
			{
				return fallbackPoser.GetBlendedPose(skeletonAction, inputSource).bonePositions;
			}
			UnityEngine.Debug.LogError("Skeleton Action is not bound, and you have not provided a fallback SkeletonPoser. Please create one to drive hand animation when no skeleton data is available.", this);
			return null;
		}

		protected Quaternion[] GetBoneRotations()
		{
			if (skeletonAvailable)
			{
				Quaternion[] boneRotations = skeletonAction.GetBoneRotations();
				if (mirroring == MirrorType.LeftToRight || mirroring == MirrorType.RightToLeft)
				{
					for (int i = 0; i < boneRotations.Length; i++)
					{
						boneRotations[i] = MirrorRotation(i, boneRotations[i]);
					}
				}
				return boneRotations;
			}
			if (fallbackPoser != null)
			{
				return fallbackPoser.GetBlendedPose(skeletonAction, inputSource).boneRotations;
			}
			UnityEngine.Debug.LogError("Skeleton Action is not bound, and you have not provided a fallback SkeletonPoser. Please create one to drive hand animation when no skeleton data is available.", this);
			return null;
		}

		public static Vector3 MirrorPosition(int boneIndex, Vector3 rawPosition)
		{
			if (boneIndex == 1 || IsMetacarpal(boneIndex))
			{
				rawPosition.Scale(new Vector3(-1f, 1f, 1f));
			}
			else if (boneIndex != 0)
			{
				rawPosition *= -1f;
			}
			return rawPosition;
		}

		public static Quaternion MirrorRotation(int boneIndex, Quaternion rawRotation)
		{
			if (boneIndex == 1)
			{
				rawRotation.y *= -1f;
				rawRotation.z *= -1f;
			}
			if (IsMetacarpal(boneIndex))
			{
				rawRotation = rightFlipAngle * rawRotation;
			}
			return rawRotation;
		}

		protected virtual void UpdatePose()
		{
			if (skeletonAction == null)
			{
				return;
			}
			Vector3 position = skeletonAction.GetLocalPosition();
			Quaternion quaternion = skeletonAction.GetLocalRotation();
			if (origin == null)
			{
				if (base.transform.parent != null)
				{
					position = base.transform.parent.TransformPoint(position);
					quaternion = base.transform.parent.rotation * quaternion;
				}
			}
			else
			{
				position = origin.TransformPoint(position);
				quaternion = origin.rotation * quaternion;
			}
			if (skeletonAction.poseChanged)
			{
				if (onTransformChanged != null)
				{
					onTransformChanged.Invoke(this, inputSource);
				}
				if (onTransformChangedEvent != null)
				{
					onTransformChangedEvent(this, inputSource);
				}
			}
			base.transform.position = position;
			base.transform.rotation = quaternion;
			if (onTransformUpdated != null)
			{
				onTransformUpdated.Invoke(this, inputSource);
			}
		}

		public void ForceToReferencePose(EVRSkeletalReferencePose referencePose)
		{
			bool flag = false;
			if (Application.isEditor && !Application.isPlaying)
			{
				flag = SteamVR.InitializeTemporarySession(initInput: true);
				Awake();
				skeletonAction.actionSet.Activate();
				SteamVR_ActionSet_Manager.UpdateActionStates(force: true);
				skeletonAction.UpdateValueWithoutEvents();
			}
			if (!skeletonAction.active)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Input]</b> Please turn on your " + inputSource.ToString() + " controller and ensure SteamVR is open.", this);
				return;
			}
			SteamVR_Utils.RigidTransform[] referenceTransforms = skeletonAction.GetReferenceTransforms(EVRSkeletalTransformSpace.Parent, referencePose);
			if (referenceTransforms == null || referenceTransforms.Length == 0)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Input]</b> Unable to get the reference transform for " + inputSource.ToString() + ". Please make sure SteamVR is open and both controllers are connected.", this);
			}
			if (mirroring == MirrorType.LeftToRight || mirroring == MirrorType.RightToLeft)
			{
				for (int i = 0; i < referenceTransforms.Length; i++)
				{
					bones[i].localPosition = MirrorPosition(i, referenceTransforms[i].pos);
					bones[i].localRotation = MirrorRotation(i, referenceTransforms[i].rot);
				}
			}
			else
			{
				for (int j = 0; j < referenceTransforms.Length; j++)
				{
					bones[j].localPosition = referenceTransforms[j].pos;
					bones[j].localRotation = referenceTransforms[j].rot;
				}
			}
			if (flag)
			{
				SteamVR.ExitTemporarySession();
			}
		}

		protected static bool IsMetacarpal(int boneIndex)
		{
			if (boneIndex != 6 && boneIndex != 11 && boneIndex != 16 && boneIndex != 21)
			{
				return boneIndex == 2;
			}
			return true;
		}
	}
	public class SteamVR_Behaviour_SkeletonCustom : SteamVR_Behaviour_Skeleton
	{
		[SerializeField]
		protected Transform _wrist;

		[SerializeField]
		protected Transform _thumbMetacarpal;

		[SerializeField]
		protected Transform _thumbProximal;

		[SerializeField]
		protected Transform _thumbMiddle;

		[SerializeField]
		protected Transform _thumbDistal;

		[SerializeField]
		protected Transform _thumbTip;

		[SerializeField]
		protected Transform _thumbAux;

		[SerializeField]
		protected Transform _indexMetacarpal;

		[SerializeField]
		protected Transform _indexProximal;

		[SerializeField]
		protected Transform _indexMiddle;

		[SerializeField]
		protected Transform _indexDistal;

		[SerializeField]
		protected Transform _indexTip;

		[SerializeField]
		protected Transform _indexAux;

		[SerializeField]
		protected Transform _middleMetacarpal;

		[SerializeField]
		protected Transform _middleProximal;

		[SerializeField]
		protected Transform _middleMiddle;

		[SerializeField]
		protected Transform _middleDistal;

		[SerializeField]
		protected Transform _middleTip;

		[SerializeField]
		protected Transform _middleAux;

		[SerializeField]
		protected Transform _ringMetacarpal;

		[SerializeField]
		protected Transform _ringProximal;

		[SerializeField]
		protected Transform _ringMiddle;

		[SerializeField]
		protected Transform _ringDistal;

		[SerializeField]
		protected Transform _ringTip;

		[SerializeField]
		protected Transform _ringAux;

		[SerializeField]
		protected Transform _pinkyMetacarpal;

		[SerializeField]
		protected Transform _pinkyProximal;

		[SerializeField]
		protected Transform _pinkyMiddle;

		[SerializeField]
		protected Transform _pinkyDistal;

		[SerializeField]
		protected Transform _pinkyTip;

		[SerializeField]
		protected Transform _pinkyAux;

		protected override void AssignBonesArray()
		{
			bones[1] = _wrist;
			bones[2] = _thumbProximal;
			bones[3] = _thumbMiddle;
			bones[4] = _thumbDistal;
			bones[5] = _thumbTip;
			bones[26] = _thumbAux;
			bones[7] = _indexProximal;
			bones[8] = _indexMiddle;
			bones[9] = _indexDistal;
			bones[10] = _indexTip;
			bones[27] = _indexAux;
			bones[12] = _middleProximal;
			bones[13] = _middleMiddle;
			bones[14] = _middleDistal;
			bones[15] = _middleTip;
			bones[28] = _middleAux;
			bones[17] = _ringProximal;
			bones[18] = _ringMiddle;
			bones[19] = _ringDistal;
			bones[20] = _ringTip;
			bones[29] = _ringAux;
			bones[22] = _pinkyProximal;
			bones[23] = _pinkyMiddle;
			bones[24] = _pinkyDistal;
			bones[25] = _pinkyTip;
			bones[30] = _pinkyAux;
		}
	}
	public class SteamVR_Behaviour_Vector2 : MonoBehaviour
	{
		public delegate void AxisHandler(SteamVR_Behaviour_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 newAxis, Vector2 newDelta);

		public delegate void ChangeHandler(SteamVR_Behaviour_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 newAxis, Vector2 newDelta);

		public delegate void UpdateHandler(SteamVR_Behaviour_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 newAxis, Vector2 newDelta);

		public SteamVR_Action_Vector2 vector2Action;

		[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
		public SteamVR_Input_Sources inputSource;

		[Tooltip("Fires whenever the action's value has changed since the last update.")]
		public SteamVR_Behaviour_Vector2Event onChange;

		[Tooltip("Fires whenever the action's value has been updated.")]
		public SteamVR_Behaviour_Vector2Event onUpdate;

		[Tooltip("Fires whenever the action's value has been updated and is non-zero.")]
		public SteamVR_Behaviour_Vector2Event onAxis;

		public ChangeHandler onChangeEvent;

		public UpdateHandler onUpdateEvent;

		public AxisHandler onAxisEvent;

		public bool isActive => vector2Action.GetActive(inputSource);

		protected virtual void OnEnable()
		{
			if (vector2Action == null)
			{
				UnityEngine.Debug.LogError("[SteamVR] Vector2 action not set.", this);
			}
			else
			{
				AddHandlers();
			}
		}

		protected virtual void OnDisable()
		{
			RemoveHandlers();
		}

		protected void AddHandlers()
		{
			vector2Action[inputSource].onUpdate += SteamVR_Behaviour_Vector2_OnUpdate;
			vector2Action[inputSource].onChange += SteamVR_Behaviour_Vector2_OnChange;
			vector2Action[inputSource].onAxis += SteamVR_Behaviour_Vector2_OnAxis;
		}

		protected void RemoveHandlers()
		{
			if (vector2Action != null)
			{
				vector2Action[inputSource].onUpdate -= SteamVR_Behaviour_Vector2_OnUpdate;
				vector2Action[inputSource].onChange -= SteamVR_Behaviour_Vector2_OnChange;
				vector2Action[inputSource].onAxis -= SteamVR_Behaviour_Vector2_OnAxis;
			}
		}

		private void SteamVR_Behaviour_Vector2_OnUpdate(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 newAxis, Vector2 newDelta)
		{
			if (onUpdate != null)
			{
				onUpdate.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onUpdateEvent != null)
			{
				onUpdateEvent(this, fromSource, newAxis, newDelta);
			}
		}

		private void SteamVR_Behaviour_Vector2_OnChange(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 newAxis, Vector2 newDelta)
		{
			if (onChange != null)
			{
				onChange.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onChangeEvent != null)
			{
				onChangeEvent(this, fromSource, newAxis, newDelta);
			}
		}

		private void SteamVR_Behaviour_Vector2_OnAxis(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 newAxis, Vector2 newDelta)
		{
			if (onAxis != null)
			{
				onAxis.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onAxisEvent != null)
			{
				onAxisEvent(this, fromSource, newAxis, newDelta);
			}
		}

		public string GetLocalizedName(params EVRInputStringBits[] localizedParts)
		{
			if (vector2Action != null)
			{
				return vector2Action.GetLocalizedOriginPart(inputSource, localizedParts);
			}
			return null;
		}
	}
	public class SteamVR_Behaviour_Vector3 : MonoBehaviour
	{
		public delegate void AxisHandler(SteamVR_Behaviour_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 newAxis, Vector3 newDelta);

		public delegate void ChangeHandler(SteamVR_Behaviour_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 newAxis, Vector3 newDelta);

		public delegate void UpdateHandler(SteamVR_Behaviour_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 newAxis, Vector3 newDelta);

		public SteamVR_Action_Vector3 vector3Action;

		[Tooltip("The device this action should apply to. Any if the action is not device specific.")]
		public SteamVR_Input_Sources inputSource;

		[Tooltip("Fires whenever the action's value has changed since the last update.")]
		public SteamVR_Behaviour_Vector3Event onChange;

		[Tooltip("Fires whenever the action's value has been updated.")]
		public SteamVR_Behaviour_Vector3Event onUpdate;

		[Tooltip("Fires whenever the action's value has been updated and is non-zero.")]
		public SteamVR_Behaviour_Vector3Event onAxis;

		public ChangeHandler onChangeEvent;

		public UpdateHandler onUpdateEvent;

		public AxisHandler onAxisEvent;

		public bool isActive => vector3Action.GetActive(inputSource);

		protected virtual void OnEnable()
		{
			if (vector3Action == null)
			{
				UnityEngine.Debug.LogError("[SteamVR] Vector3 action not set.", this);
			}
			else
			{
				AddHandlers();
			}
		}

		protected virtual void OnDisable()
		{
			RemoveHandlers();
		}

		protected void AddHandlers()
		{
			vector3Action[inputSource].onUpdate += SteamVR_Behaviour_Vector3_OnUpdate;
			vector3Action[inputSource].onChange += SteamVR_Behaviour_Vector3_OnChange;
			vector3Action[inputSource].onAxis += SteamVR_Behaviour_Vector3_OnAxis;
		}

		protected void RemoveHandlers()
		{
			if (vector3Action != null)
			{
				vector3Action[inputSource].onUpdate -= SteamVR_Behaviour_Vector3_OnUpdate;
				vector3Action[inputSource].onChange -= SteamVR_Behaviour_Vector3_OnChange;
				vector3Action[inputSource].onAxis -= SteamVR_Behaviour_Vector3_OnAxis;
			}
		}

		private void SteamVR_Behaviour_Vector3_OnUpdate(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 newAxis, Vector3 newDelta)
		{
			if (onUpdate != null)
			{
				onUpdate.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onUpdateEvent != null)
			{
				onUpdateEvent(this, fromSource, newAxis, newDelta);
			}
		}

		private void SteamVR_Behaviour_Vector3_OnChange(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 newAxis, Vector3 newDelta)
		{
			if (onChange != null)
			{
				onChange.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onChangeEvent != null)
			{
				onChangeEvent(this, fromSource, newAxis, newDelta);
			}
		}

		private void SteamVR_Behaviour_Vector3_OnAxis(SteamVR_Action_Vector3 fromAction, SteamVR_Input_Sources fromSource, Vector3 newAxis, Vector3 newDelta)
		{
			if (onAxis != null)
			{
				onAxis.Invoke(this, fromSource, newAxis, newDelta);
			}
			if (onAxisEvent != null)
			{
				onAxisEvent(this, fromSource, newAxis, newDelta);
			}
		}

		public string GetLocalizedName(params EVRInputStringBits[] localizedParts)
		{
			if (vector3Action != null)
			{
				return vector3Action.GetLocalizedOriginPart(inputSource, localizedParts);
			}
			return null;
		}
	}
	public class SteamVR_Input
	{
		public delegate void PosesUpdatedHandler(bool skipSendingEvents);

		public delegate void SkeletonsUpdatedHandler(bool skipSendingEvents);

		public const string defaultInputGameObjectName = "[SteamVR Input]";

		private const string localizationKeyName = "localization";

		public static bool fileInitialized;

		public static bool initialized;

		public static bool preInitialized;

		public static SteamVR_Input_ActionFile actionFile;

		public static string actionFileHash;

		protected static bool initializing;

		protected static int startupFrame;

		public static SteamVR_ActionSet[] actionSets;

		public static SteamVR_Action[] actions;

		public static ISteamVR_Action_In[] actionsIn;

		public static ISteamVR_Action_Out[] actionsOut;

		public static SteamVR_Action_Boolean[] actionsBoolean;

		public static SteamVR_Action_Single[] actionsSingle;

		public static SteamVR_Action_Vector2[] actionsVector2;

		public static SteamVR_Action_Vector3[] actionsVector3;

		public static SteamVR_Action_Pose[] actionsPose;

		public static SteamVR_Action_Skeleton[] actionsSkeleton;

		public static SteamVR_Action_Vibration[] actionsVibration;

		public static ISteamVR_Action_In[] actionsNonPoseNonSkeletonIn;

		protected static Dictionary<string, SteamVR_ActionSet> actionSetsByPath;

		protected static Dictionary<string, SteamVR_ActionSet> actionSetsByPathLowered;

		protected static Dictionary<string, SteamVR_Action> actionsByPath;

		protected static Dictionary<string, SteamVR_Action> actionsByPathLowered;

		protected static Dictionary<string, SteamVR_ActionSet> actionSetsByPathCache;

		protected static Dictionary<string, SteamVR_Action> actionsByPathCache;

		protected static Dictionary<string, SteamVR_Action> actionsByNameCache;

		protected static Dictionary<string, SteamVR_ActionSet> actionSetsByNameCache;

		private static uint sizeVRActiveActionSet_t;

		private static VRActiveActionSet_t[] setCache;

		public static bool isStartupFrame
		{
			get
			{
				if (Time.frameCount >= startupFrame - 1)
				{
					return Time.frameCount <= startupFrame + 1;
				}
				return false;
			}
		}

		public static event Action onNonVisualActionsUpdated;

		public static event PosesUpdatedHandler onPosesUpdated;

		public static event SkeletonsUpdatedHandler onSkeletonsUpdated;

		static SteamVR_Input()
		{
			fileInitialized = false;
			initialized = false;
			preInitialized = false;
			initializing = false;
			startupFrame = 0;
			actionSetsByPath = new Dictionary<string, SteamVR_ActionSet>();
			actionSetsByPathLowered = new Dictionary<string, SteamVR_ActionSet>();
			actionsByPath = new Dictionary<string, SteamVR_Action>();
			actionsByPathLowered = new Dictionary<string, SteamVR_Action>();
			actionSetsByPathCache = new Dictionary<string, SteamVR_ActionSet>();
			actionsByPathCache = new Dictionary<string, SteamVR_Action>();
			actionsByNameCache = new Dictionary<string, SteamVR_Action>();
			actionSetsByNameCache = new Dictionary<string, SteamVR_ActionSet>();
			sizeVRActiveActionSet_t = 0u;
			setCache = new VRActiveActionSet_t[1];
			FindPreinitializeMethod();
		}

		public static void ForcePreinitialize()
		{
			FindPreinitializeMethod();
		}

		private static void FindPreinitializeMethod()
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				Type type = assemblies[i].GetType("Valve.VR.SteamVR_Actions");
				if (type != null)
				{
					MethodInfo method = type.GetMethod("PreInitialize");
					if (method != null)
					{
						method.Invoke(null, null);
						break;
					}
				}
			}
		}

		public static void Initialize(bool force = false)
		{
			if (initialized && !force)
			{
				return;
			}
			initializing = true;
			startupFrame = Time.frameCount;
			SteamVR_ActionSet_Manager.Initialize();
			SteamVR_Input_Source.Initialize();
			for (int i = 0; i < actions.Length; i++)
			{
				actions[i].Initialize(createNew: true);
			}
			for (int j = 0; j < actionSets.Length; j++)
			{
				actionSets[j].Initialize(createNew: true);
			}
			if (SteamVR_Settings.instance.activateFirstActionSetOnStart)
			{
				if (actionSets.Length != 0)
				{
					actionSets[0].Activate();
				}
				else
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> No action sets to activate.");
				}
			}
			SteamVR_Action_Pose.SetTrackingUniverseOrigin(SteamVR_Settings.instance.trackingSpace);
			initialized = true;
			initializing = false;
		}

		public static void PreinitializeFinishActionSets()
		{
			for (int i = 0; i < actionSets.Length; i++)
			{
				actionSets[i].FinishPreInitialize();
			}
		}

		public static void PreinitializeActionSetDictionaries()
		{
			actionSetsByPath.Clear();
			actionSetsByPathLowered.Clear();
			actionSetsByPathCache.Clear();
			for (int i = 0; i < actionSets.Length; i++)
			{
				SteamVR_ActionSet steamVR_ActionSet = actionSets[i];
				actionSetsByPath.Add(steamVR_ActionSet.fullPath, steamVR_ActionSet);
				actionSetsByPathLowered.Add(steamVR_ActionSet.fullPath.ToLower(), steamVR_ActionSet);
			}
		}

		public static void PreinitializeActionDictionaries()
		{
			actionsByPath.Clear();
			actionsByPathLowered.Clear();
			actionsByPathCache.Clear();
			for (int i = 0; i < actions.Length; i++)
			{
				SteamVR_Action steamVR_Action = actions[i];
				actionsByPath.Add(steamVR_Action.fullPath, steamVR_Action);
				actionsByPathLowered.Add(steamVR_Action.fullPath.ToLower(), steamVR_Action);
			}
		}

		public static void Update()
		{
			if (initialized && !isStartupFrame)
			{
				if (SteamVR.settings.IsInputUpdateMode(SteamVR_UpdateModes.OnUpdate))
				{
					UpdateNonVisualActions();
				}
				if (SteamVR.settings.IsPoseUpdateMode(SteamVR_UpdateModes.OnUpdate))
				{
					UpdateVisualActions();
				}
			}
		}

		public static void LateUpdate()
		{
			if (initialized && !isStartupFrame)
			{
				if (SteamVR.settings.IsInputUpdateMode(SteamVR_UpdateModes.OnLateUpdate))
				{
					UpdateNonVisualActions();
				}
				if (SteamVR.settings.IsPoseUpdateMode(SteamVR_UpdateModes.OnLateUpdate))
				{
					UpdateVisualActions();
				}
				else
				{
					UpdateSkeletonActions(skipSendingEvents: true);
				}
			}
		}

		public static void FixedUpdate()
		{
			if (initialized && !isStartupFrame)
			{
				if (SteamVR.settings.IsInputUpdateMode(SteamVR_UpdateModes.OnFixedUpdate))
				{
					UpdateNonVisualActions();
				}
				if (SteamVR.settings.IsPoseUpdateMode(SteamVR_UpdateModes.OnFixedUpdate))
				{
					UpdateVisualActions();
				}
			}
		}

		public static void OnPreCull()
		{
			if (initialized && !isStartupFrame)
			{
				if (SteamVR.settings.IsInputUpdateMode(SteamVR_UpdateModes.OnPreCull))
				{
					UpdateNonVisualActions();
				}
				if (SteamVR.settings.IsPoseUpdateMode(SteamVR_UpdateModes.OnPreCull))
				{
					UpdateVisualActions();
				}
			}
		}

		public static void UpdateVisualActions(bool skipStateAndEventUpdates = false)
		{
			if (initialized)
			{
				SteamVR_ActionSet_Manager.UpdateActionStates();
				UpdatePoseActions(skipStateAndEventUpdates);
				UpdateSkeletonActions(skipStateAndEventUpdates);
			}
		}

		public static void UpdatePoseActions(bool skipSendingEvents = false)
		{
			if (initialized)
			{
				for (int i = 0; i < actionsPose.Length; i++)
				{
					actionsPose[i].UpdateValues(skipSendingEvents);
				}
				if (SteamVR_Input.onPosesUpdated != null)
				{
					SteamVR_Input.onPosesUpdated(skipSendingEvents: false);
				}
			}
		}

		public static void UpdateSkeletonActions(bool skipSendingEvents = false)
		{
			if (initialized)
			{
				for (int i = 0; i < actionsSkeleton.Length; i++)
				{
					actionsSkeleton[i].UpdateValue(skipSendingEvents);
				}
				if (SteamVR_Input.onSkeletonsUpdated != null)
				{
					SteamVR_Input.onSkeletonsUpdated(skipSendingEvents);
				}
			}
		}

		public static void UpdateNonVisualActions()
		{
			if (initialized)
			{
				SteamVR_ActionSet_Manager.UpdateActionStates();
				for (int i = 0; i < actionsNonPoseNonSkeletonIn.Length; i++)
				{
					actionsNonPoseNonSkeletonIn[i].UpdateValues();
				}
				if (SteamVR_Input.onNonVisualActionsUpdated != null)
				{
					SteamVR_Input.onNonVisualActionsUpdated();
				}
			}
		}

		protected static void ShowBindingHintsForSets(VRActiveActionSet_t[] sets, ulong highlightAction = 0uL)
		{
			if (sizeVRActiveActionSet_t == 0)
			{
				sizeVRActiveActionSet_t = (uint)Marshal.SizeOf(typeof(VRActiveActionSet_t));
			}
			OpenVR.Input.ShowBindingsForActionSet(sets, sizeVRActiveActionSet_t, highlightAction);
		}

		public static bool ShowBindingHints(ISteamVR_Action_In originToHighlight)
		{
			if (originToHighlight != null)
			{
				setCache[0].ulActionSet = originToHighlight.actionSet.handle;
				ShowBindingHintsForSets(setCache, originToHighlight.activeOrigin);
				return true;
			}
			return false;
		}

		public static bool ShowBindingHints(ISteamVR_ActionSet setToShow)
		{
			if (setToShow != null)
			{
				setCache[0].ulActionSet = setToShow.handle;
				ShowBindingHintsForSets(setCache, 0uL);
				return true;
			}
			return false;
		}

		public static void ShowBindingHintsForActiveActionSets(ulong highlightAction = 0uL)
		{
			if (sizeVRActiveActionSet_t == 0)
			{
				sizeVRActiveActionSet_t = (uint)Marshal.SizeOf(typeof(VRActiveActionSet_t));
			}
			OpenVR.Input.ShowBindingsForActionSet(SteamVR_ActionSet_Manager.rawActiveActionSetArray, sizeVRActiveActionSet_t, highlightAction);
		}

		public static T GetActionDataFromPath<T>(string path, bool caseSensitive = false) where T : SteamVR_Action_Source_Map
		{
			SteamVR_Action baseActionFromPath = GetBaseActionFromPath(path, caseSensitive);
			if (baseActionFromPath != null)
			{
				return (T)baseActionFromPath.GetSourceMap();
			}
			return null;
		}

		public static SteamVR_ActionSet_Data GetActionSetDataFromPath(string path, bool caseSensitive = false)
		{
			SteamVR_ActionSet actionSetFromPath = GetActionSetFromPath(path, caseSensitive);
			if (actionSetFromPath != null)
			{
				return actionSetFromPath.GetActionSetData();
			}
			return null;
		}

		public static T GetActionFromPath<T>(string path, bool caseSensitive = false, bool returnNulls = false) where T : SteamVR_Action, new()
		{
			SteamVR_Action baseActionFromPath = GetBaseActionFromPath(path, caseSensitive);
			if (baseActionFromPath != null)
			{
				return baseActionFromPath.GetCopy<T>();
			}
			if (returnNulls)
			{
				return null;
			}
			return CreateFakeAction<T>(path, caseSensitive);
		}

		public static SteamVR_Action GetBaseActionFromPath(string path, bool caseSensitive = false)
		{
			if (string.IsNullOrEmpty(path))
			{
				return null;
			}
			if (caseSensitive)
			{
				if (actionsByPath.ContainsKey(path))
				{
					return actionsByPath[path];
				}
			}
			else
			{
				if (actionsByPathCache.ContainsKey(path))
				{
					return actionsByPathCache[path];
				}
				if (actionsByPath.ContainsKey(path))
				{
					actionsByPathCache.Add(path, actionsByPath[path]);
					return actionsByPath[path];
				}
				string key = path.ToLower();
				if (actionsByPathLowered.ContainsKey(key))
				{
					actionsByPathCache.Add(path, actionsByPathLowered[key]);
					return actionsByPathLowered[key];
				}
				actionsByPathCache.Add(path, null);
			}
			return null;
		}

		public static bool HasActionPath(string path, bool caseSensitive = false)
		{
			return GetBaseActionFromPath(path, caseSensitive) != null;
		}

		public static bool HasAction(string actionName, bool caseSensitive = false)
		{
			return GetBaseAction(null, actionName, caseSensitive) != null;
		}

		public static bool HasAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetBaseAction(actionSetName, actionName, caseSensitive) != null;
		}

		public static SteamVR_Action_Boolean GetBooleanActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Boolean>(path, caseSensitive);
		}

		public static SteamVR_Action_Single GetSingleActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Single>(path, caseSensitive);
		}

		public static SteamVR_Action_Vector2 GetVector2ActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Vector2>(path, caseSensitive);
		}

		public static SteamVR_Action_Vector3 GetVector3ActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Vector3>(path, caseSensitive);
		}

		public static SteamVR_Action_Vibration GetVibrationActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Vibration>(path, caseSensitive);
		}

		public static SteamVR_Action_Pose GetPoseActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Pose>(path, caseSensitive);
		}

		public static SteamVR_Action_Skeleton GetSkeletonActionFromPath(string path, bool caseSensitive = false)
		{
			return GetActionFromPath<SteamVR_Action_Skeleton>(path, caseSensitive);
		}

		public static T GetAction<T>(string actionSetName, string actionName, bool caseSensitive = false, bool returnNulls = false) where T : SteamVR_Action, new()
		{
			SteamVR_Action baseAction = GetBaseAction(actionSetName, actionName, caseSensitive);
			if (baseAction != null)
			{
				return baseAction.GetCopy<T>();
			}
			if (returnNulls)
			{
				return null;
			}
			return CreateFakeAction<T>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action GetBaseAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			if (actions == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(actionSetName))
			{
				for (int i = 0; i < actions.Length; i++)
				{
					if (caseSensitive)
					{
						if (actions[i].GetShortName() == actionName)
						{
							return actions[i];
						}
					}
					else if (string.Equals(actions[i].GetShortName(), actionName, StringComparison.CurrentCultureIgnoreCase))
					{
						return actions[i];
					}
				}
			}
			else
			{
				SteamVR_ActionSet actionSet = GetActionSet(actionSetName, caseSensitive, returnsNulls: true);
				if (actionSet != null)
				{
					for (int j = 0; j < actionSet.allActions.Length; j++)
					{
						if (caseSensitive)
						{
							if (actionSet.allActions[j].GetShortName() == actionName)
							{
								return actionSet.allActions[j];
							}
						}
						else if (string.Equals(actionSet.allActions[j].GetShortName(), actionName, StringComparison.CurrentCultureIgnoreCase))
						{
							return actionSet.allActions[j];
						}
					}
				}
			}
			return null;
		}

		private static T CreateFakeAction<T>(string actionSetName, string actionName, bool caseSensitive) where T : SteamVR_Action, new()
		{
			if (typeof(T) == typeof(SteamVR_Action_Vibration))
			{
				return SteamVR_Action.CreateUninitialized<T>(actionSetName, SteamVR_ActionDirections.Out, actionName, caseSensitive);
			}
			return SteamVR_Action.CreateUninitialized<T>(actionSetName, SteamVR_ActionDirections.In, actionName, caseSensitive);
		}

		private static T CreateFakeAction<T>(string actionPath, bool caseSensitive) where T : SteamVR_Action, new()
		{
			return SteamVR_Action.CreateUninitialized<T>(actionPath, caseSensitive);
		}

		public static T GetAction<T>(string actionName, bool caseSensitive = false) where T : SteamVR_Action, new()
		{
			return GetAction<T>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Boolean GetBooleanAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Boolean>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Boolean GetBooleanAction(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Boolean>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Single GetSingleAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Single>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Single GetSingleAction(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Single>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Vector2 GetVector2Action(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Vector2>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Vector2 GetVector2Action(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Vector2>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Vector3 GetVector3Action(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Vector3>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Vector3 GetVector3Action(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Vector3>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Pose GetPoseAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Pose>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Pose GetPoseAction(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Pose>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Skeleton GetSkeletonAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Skeleton>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Skeleton GetSkeletonAction(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Skeleton>(null, actionName, caseSensitive);
		}

		public static SteamVR_Action_Vibration GetVibrationAction(string actionSetName, string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Vibration>(actionSetName, actionName, caseSensitive);
		}

		public static SteamVR_Action_Vibration GetVibrationAction(string actionName, bool caseSensitive = false)
		{
			return GetAction<SteamVR_Action_Vibration>(null, actionName, caseSensitive);
		}

		public static T GetActionSet<T>(string actionSetName, bool caseSensitive = false, bool returnNulls = false) where T : SteamVR_ActionSet, new()
		{
			if (actionSets == null)
			{
				if (returnNulls)
				{
					return null;
				}
				return SteamVR_ActionSet.CreateFromName<T>(actionSetName);
			}
			for (int i = 0; i < actionSets.Length; i++)
			{
				if (caseSensitive)
				{
					if (actionSets[i].GetShortName() == actionSetName)
					{
						return actionSets[i].GetCopy<T>();
					}
				}
				else if (string.Equals(actionSets[i].GetShortName(), actionSetName, StringComparison.CurrentCultureIgnoreCase))
				{
					return actionSets[i].GetCopy<T>();
				}
			}
			if (returnNulls)
			{
				return null;
			}
			return SteamVR_ActionSet.CreateFromName<T>(actionSetName);
		}

		public static SteamVR_ActionSet GetActionSet(string actionSetName, bool caseSensitive = false, bool returnsNulls = false)
		{
			return GetActionSet<SteamVR_ActionSet>(actionSetName, caseSensitive, returnsNulls);
		}

		protected static bool HasActionSet(string name, bool caseSensitive = false)
		{
			return GetActionSet(name, caseSensitive, returnsNulls: true) != null;
		}

		public static T GetActionSetFromPath<T>(string path, bool caseSensitive = false, bool returnsNulls = false) where T : SteamVR_ActionSet, new()
		{
			if (actionSets == null || actionSets[0] == null || string.IsNullOrEmpty(path))
			{
				if (returnsNulls)
				{
					return null;
				}
				return SteamVR_ActionSet.Create<T>(path);
			}
			if (caseSensitive)
			{
				if (actionSetsByPath.ContainsKey(path))
				{
					return actionSetsByPath[path].GetCopy<T>();
				}
			}
			else
			{
				if (actionSetsByPathCache.ContainsKey(path))
				{
					SteamVR_ActionSet steamVR_ActionSet = actionSetsByPathCache[path];
					if (steamVR_ActionSet == null)
					{
						return null;
					}
					return steamVR_ActionSet.GetCopy<T>();
				}
				if (actionSetsByPath.ContainsKey(path))
				{
					actionSetsByPathCache.Add(path, actionSetsByPath[path]);
					return actionSetsByPath[path].GetCopy<T>();
				}
				string key = path.ToLower();
				if (actionSetsByPathLowered.ContainsKey(key))
				{
					actionSetsByPathCache.Add(path, actionSetsByPathLowered[key]);
					return actionSetsByPath[key].GetCopy<T>();
				}
				actionSetsByPathCache.Add(path, null);
			}
			if (returnsNulls)
			{
				return null;
			}
			return SteamVR_ActionSet.Create<T>(path);
		}

		public static SteamVR_ActionSet GetActionSetFromPath(string path, bool caseSensitive = false)
		{
			return GetActionSetFromPath<SteamVR_ActionSet>(path, caseSensitive);
		}

		public static bool GetState(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Boolean action2 = GetAction<SteamVR_Action_Boolean>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetState(inputSource);
			}
			return false;
		}

		public static bool GetState(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetState(null, action, inputSource, caseSensitive);
		}

		public static bool GetStateDown(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Boolean action2 = GetAction<SteamVR_Action_Boolean>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetStateDown(inputSource);
			}
			return false;
		}

		public static bool GetStateDown(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetStateDown(null, action, inputSource, caseSensitive);
		}

		public static bool GetStateUp(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Boolean action2 = GetAction<SteamVR_Action_Boolean>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetStateUp(inputSource);
			}
			return false;
		}

		public static bool GetStateUp(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetStateUp(null, action, inputSource, caseSensitive);
		}

		public static float GetFloat(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Single action2 = GetAction<SteamVR_Action_Single>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetAxis(inputSource);
			}
			return 0f;
		}

		public static float GetFloat(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetFloat(null, action, inputSource, caseSensitive);
		}

		public static float GetSingle(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Single action2 = GetAction<SteamVR_Action_Single>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetAxis(inputSource);
			}
			return 0f;
		}

		public static float GetSingle(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetFloat(null, action, inputSource, caseSensitive);
		}

		public static Vector2 GetVector2(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Vector2 action2 = GetAction<SteamVR_Action_Vector2>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetAxis(inputSource);
			}
			return Vector2.zero;
		}

		public static Vector2 GetVector2(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetVector2(null, action, inputSource, caseSensitive);
		}

		public static Vector3 GetVector3(string actionSet, string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			SteamVR_Action_Vector3 action2 = GetAction<SteamVR_Action_Vector3>(actionSet, action, caseSensitive);
			if (action2 != null)
			{
				return action2.GetAxis(inputSource);
			}
			return Vector3.zero;
		}

		public static Vector3 GetVector3(string action, SteamVR_Input_Sources inputSource, bool caseSensitive = false)
		{
			return GetVector3(null, action, inputSource, caseSensitive);
		}

		public static SteamVR_ActionSet[] GetActionSets()
		{
			return actionSets;
		}

		public static T[] GetActions<T>() where T : SteamVR_Action
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(SteamVR_Action))
			{
				return actions as T[];
			}
			if (typeFromHandle == typeof(ISteamVR_Action_In))
			{
				return actionsIn as T[];
			}
			if (typeFromHandle == typeof(ISteamVR_Action_Out))
			{
				return actionsOut as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Boolean))
			{
				return actionsBoolean as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Single))
			{
				return actionsSingle as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Vector2))
			{
				return actionsVector2 as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Vector3))
			{
				return actionsVector3 as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Pose))
			{
				return actionsPose as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Skeleton))
			{
				return actionsSkeleton as T[];
			}
			if (typeFromHandle == typeof(SteamVR_Action_Vibration))
			{
				return actionsVibration as T[];
			}
			UnityEngine.Debug.Log("<b>[SteamVR]</b> Wrong type.");
			return null;
		}

		internal static bool ShouldMakeCopy()
		{
			return !SteamVR_Behaviour.isPlaying;
		}

		public static string GetLocalizedName(ulong originHandle, params EVRInputStringBits[] localizedParts)
		{
			int num = 0;
			for (int i = 0; i < localizedParts.Length; i++)
			{
				num |= (int)localizedParts[i];
			}
			StringBuilder stringBuilder = new StringBuilder(500);
			OpenVR.Input.GetOriginLocalizedName(originHandle, stringBuilder, 500u, num);
			return stringBuilder.ToString();
		}

		public static bool CheckOldLocation()
		{
			return false;
		}

		public static void IdentifyActionsFile(bool showLogs = true)
		{
			string actionsFilePath = GetActionsFilePath();
			if (File.Exists(actionsFilePath))
			{
				if (OpenVR.Input == null)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> Could not instantiate OpenVR Input interface.");
					return;
				}
				EVRInputError eVRInputError = OpenVR.Input.SetActionManifestPath(actionsFilePath);
				if (eVRInputError != EVRInputError.None)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> Error loading action manifest into SteamVR: " + eVRInputError);
					return;
				}
				int num = 0;
				if (actions != null)
				{
					num = actions.Length;
					if (showLogs)
					{
						UnityEngine.Debug.Log($"<b>[SteamVR]</b> Successfully loaded {num} actions from action manifest into SteamVR ({actionsFilePath})");
					}
				}
				else if (showLogs)
				{
					UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> No actions found, but the action manifest was loaded. This usually means you haven't generated actions. Window -> SteamVR Input -> Save and Generate.");
				}
			}
			else if (showLogs)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Could not find actions file at: " + actionsFilePath);
			}
		}

		public static bool HasFileInMemoryBeenModified()
		{
			string actionsFilePath = GetActionsFilePath();
			string text = null;
			if (File.Exists(actionsFilePath))
			{
				text = File.ReadAllText(actionsFilePath);
				string badMD5Hash = SteamVR_Utils.GetBadMD5Hash(text);
				string badMD5Hash2 = SteamVR_Utils.GetBadMD5Hash(JsonConvert.SerializeObject(actionFile, Formatting.Indented, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				}));
				return badMD5Hash != badMD5Hash2;
			}
			return true;
		}

		public static bool CreateEmptyActionsFile(bool completelyEmpty = false)
		{
			string actionsFilePath = GetActionsFilePath();
			if (File.Exists(actionsFilePath))
			{
				UnityEngine.Debug.LogErrorFormat("<b>[SteamVR]</b> Actions file already exists in project root: {0}", actionsFilePath);
				return false;
			}
			actionFile = new SteamVR_Input_ActionFile();
			if (!completelyEmpty)
			{
				actionFile.action_sets.Add(SteamVR_Input_ActionFile_ActionSet.CreateNew());
				actionFile.actions.Add(SteamVR_Input_ActionFile_Action.CreateNew(actionFile.action_sets[0].shortName, SteamVR_ActionDirections.In, SteamVR_Input_ActionFile_ActionTypes.boolean));
			}
			string contents = JsonConvert.SerializeObject(actionFile, Formatting.Indented, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			});
			File.WriteAllText(actionsFilePath, contents);
			actionFile.InitializeHelperLists();
			fileInitialized = true;
			return true;
		}

		public static bool DoesActionsFileExist()
		{
			return File.Exists(GetActionsFilePath());
		}

		public static bool InitializeFile(bool force = false, bool showErrors = true)
		{
			bool num = DoesActionsFileExist();
			string actionsFilePath = GetActionsFilePath();
			string text = null;
			if (num)
			{
				text = File.ReadAllText(actionsFilePath);
				if (fileInitialized || (fileInitialized && !force))
				{
					string badMD5Hash = SteamVR_Utils.GetBadMD5Hash(text);
					if (badMD5Hash == actionFileHash)
					{
						return true;
					}
					actionFileHash = badMD5Hash;
				}
				actionFile = SteamVR_Input_ActionFile.Open(GetActionsFilePath());
				fileInitialized = true;
				return true;
			}
			if (showErrors)
			{
				UnityEngine.Debug.LogErrorFormat("<b>[SteamVR]</b> Actions file does not exist in project root: {0}", actionsFilePath);
			}
			return false;
		}

		public static string GetActionsFileFolder(bool fullPath = true)
		{
			string streamingAssetsPath = Application.streamingAssetsPath;
			if (!Directory.Exists(streamingAssetsPath))
			{
				Directory.CreateDirectory(streamingAssetsPath);
			}
			string text = Path.Combine(streamingAssetsPath, "SteamVR");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public static string GetActionsFilePath(bool fullPath = true)
		{
			return SteamVR_Utils.SanitizePath(Path.Combine(GetActionsFileFolder(fullPath), SteamVR_Settings.instance.actionsFilePath));
		}

		public static string GetActionsFileName()
		{
			return SteamVR_Settings.instance.actionsFilePath;
		}

		public static bool DeleteManifestAndBindings()
		{
			if (!DoesActionsFileExist())
			{
				return false;
			}
			InitializeFile();
			string[] filesToCopy = actionFile.GetFilesToCopy();
			foreach (string obj in filesToCopy)
			{
				new FileInfo(obj).IsReadOnly = false;
				File.Delete(obj);
			}
			string actionsFilePath = GetActionsFilePath();
			if (File.Exists(actionsFilePath))
			{
				new FileInfo(actionsFilePath).IsReadOnly = false;
				File.Delete(actionsFilePath);
				actionFile = null;
				fileInitialized = false;
				return true;
			}
			return false;
		}

		public static void OpenBindingUI(SteamVR_ActionSet actionSetToEdit = null, SteamVR_Input_Sources deviceBindingToEdit = SteamVR_Input_Sources.Any)
		{
			ulong handle = SteamVR_Input_Source.GetHandle(deviceBindingToEdit);
			ulong ulActionSetHandle = 0uL;
			if (actionSetToEdit != null)
			{
				ulActionSetHandle = actionSetToEdit.handle;
			}
			OpenVR.Input.OpenBindingUI(null, ulActionSetHandle, handle, bShowOnDesktop: false);
		}
	}
	[Serializable]
	public class SteamVR_Input_ActionFile
	{
		public List<SteamVR_Input_ActionFile_Action> actions = new List<SteamVR_Input_ActionFile_Action>();

		public List<SteamVR_Input_ActionFile_ActionSet> action_sets = new List<SteamVR_Input_ActionFile_ActionSet>();

		public List<SteamVR_Input_ActionFile_DefaultBinding> default_bindings = new List<SteamVR_Input_ActionFile_DefaultBinding>();

		public List<Dictionary<string, string>> localization = new List<Dictionary<string, string>>();

		[JsonIgnore]
		public string filePath;

		[JsonIgnore]
		public List<SteamVR_Input_ActionFile_LocalizationItem> localizationHelperList = new List<SteamVR_Input_ActionFile_LocalizationItem>();

		private const string findString_appKeyStart = "\"app_key\"";

		private const string findString_appKeyEnd = "\",";

		public void InitializeHelperLists()
		{
			foreach (SteamVR_Input_ActionFile_ActionSet actionset in action_sets)
			{
				actionset.actionsInList = new List<SteamVR_Input_ActionFile_Action>(actions.Where((SteamVR_Input_ActionFile_Action action) => action.path.StartsWith(actionset.name) && Enumerable.Contains(SteamVR_Input_ActionFile_ActionTypes.listIn, action.type)));
				actionset.actionsOutList = new List<SteamVR_Input_ActionFile_Action>(actions.Where((SteamVR_Input_ActionFile_Action action) => action.path.StartsWith(actionset.name) && Enumerable.Contains(SteamVR_Input_ActionFile_ActionTypes.listOut, action.type)));
				actionset.actionsList = new List<SteamVR_Input_ActionFile_Action>(actions.Where((SteamVR_Input_ActionFile_Action action) => action.path.StartsWith(actionset.name)));
			}
			foreach (Dictionary<string, string> item in localization)
			{
				localizationHelperList.Add(new SteamVR_Input_ActionFile_LocalizationItem(item));
			}
		}

		public void SaveHelperLists()
		{
			foreach (SteamVR_Input_ActionFile_ActionSet action_set in action_sets)
			{
				action_set.actionsList.Clear();
				action_set.actionsList.AddRange(action_set.actionsInList);
				action_set.actionsList.AddRange(action_set.actionsOutList);
			}
			actions.Clear();
			foreach (SteamVR_Input_ActionFile_ActionSet action_set2 in action_sets)
			{
				actions.AddRange(action_set2.actionsInList);
				actions.AddRange(action_set2.actionsOutList);
			}
			localization.Clear();
			foreach (SteamVR_Input_ActionFile_LocalizationItem localizationHelper in localizationHelperList)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary.Add("language_tag", localizationHelper.language);
				foreach (KeyValuePair<string, string> item in localizationHelper.items)
				{
					dictionary.Add(item.Key, item.Value);
				}
				localization.Add(dictionary);
			}
		}

		public static string GetShortName(string name)
		{
			string text = name;
			int num = text.LastIndexOf('/');
			if (num != -1)
			{
				if (num == text.Length - 1)
				{
					text = text.Remove(num);
					num = text.LastIndexOf('/');
					if (num == -1)
					{
						return GetCodeFriendlyName(text);
					}
				}
				return GetCodeFriendlyName(text.Substring(num + 1));
			}
			return GetCodeFriendlyName(text);
		}

		public static string GetCodeFriendlyName(string name)
		{
			name = name.Replace('/', '_').Replace(' ', '_');
			if (!char.IsLetter(name[0]))
			{
				name = "_" + name;
			}
			for (int i = 0; i < name.Length; i++)
			{
				if (!char.IsLetterOrDigit(name[i]) && name[i] != '_')
				{
					name = name.Remove(i, 1);
					name = name.Insert(i, "_");
				}
			}
			return name;
		}

		public string[] GetFilesToCopy(bool throwErrors = false)
		{
			List<string> list = new List<string>();
			string fullName = new FileInfo(filePath).Directory.FullName;
			list.Add(filePath);
			foreach (SteamVR_Input_ActionFile_DefaultBinding default_binding in default_bindings)
			{
				string text = Path.Combine(fullName, default_binding.binding_url);
				if (File.Exists(text))
				{
					list.Add(text);
				}
				else if (throwErrors)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> Could not bind binding file specified by the actions.json manifest: " + text);
				}
			}
			return list.ToArray();
		}

		public void CopyFilesToPath(string toPath, bool overwrite)
		{
			string[] filesToCopy = SteamVR_Input.actionFile.GetFilesToCopy();
			foreach (string text in filesToCopy)
			{
				FileInfo fileInfo = new FileInfo(text);
				string text2 = Path.Combine(toPath, fileInfo.Name);
				bool flag = false;
				if (File.Exists(text2))
				{
					flag = true;
				}
				if (flag)
				{
					if (overwrite)
					{
						FileInfo fileInfo2 = new FileInfo(text2);
						fileInfo2.IsReadOnly = false;
						fileInfo2.Delete();
						File.Copy(text, text2);
						RemoveAppKey(text2);
						UnityEngine.Debug.Log("<b>[SteamVR]</b> Copied (overwrote) SteamVR Input file at path: " + text2);
					}
					else
					{
						UnityEngine.Debug.Log("<b>[SteamVR]</b> Skipped writing existing file at path: " + text2);
					}
				}
				else
				{
					File.Copy(text, text2);
					RemoveAppKey(text2);
					UnityEngine.Debug.Log("<b>[SteamVR]</b> Copied SteamVR Input file to folder: " + text2);
				}
			}
		}

		private static void RemoveAppKey(string newFilePath)
		{
			if (!File.Exists(newFilePath))
			{
				return;
			}
			string text = File.ReadAllText(newFilePath);
			string value = "\"app_key\"";
			int num = text.IndexOf(value);
			if (num != -1)
			{
				int num2 = text.IndexOf("\",", num);
				if (num2 != -1)
				{
					num2 += "\",".Length;
					int count = num2 - num;
					string contents = text.Remove(num, count);
					new FileInfo(newFilePath).IsReadOnly = false;
					File.WriteAllText(newFilePath, contents);
				}
			}
		}

		public static SteamVR_Input_ActionFile Open(string path)
		{
			if (File.Exists(path))
			{
				SteamVR_Input_ActionFile steamVR_Input_ActionFile = JsonConvert.DeserializeObject<SteamVR_Input_ActionFile>(File.ReadAllText(path));
				steamVR_Input_ActionFile.filePath = path;
				steamVR_Input_ActionFile.InitializeHelperLists();
				return steamVR_Input_ActionFile;
			}
			return null;
		}

		public void Save(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			if (fileInfo.Exists)
			{
				fileInfo.IsReadOnly = false;
			}
			string contents = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore
			});
			File.WriteAllText(path, contents);
		}
	}
	public enum SteamVR_Input_ActionFile_DefaultBinding_ControllerTypes
	{
		vive,
		vive_pro,
		vive_controller,
		generic,
		holographic_controller,
		oculus_touch,
		gamepad,
		knuckles,
		index_hmd,
		vive_cosmos_controller,
		rift,
		vive_tracker_camera,
		vive_tracker
	}
	[Serializable]
	public class SteamVR_Input_ActionFile_DefaultBinding
	{
		public string controller_type;

		public string binding_url;

		public SteamVR_Input_ActionFile_DefaultBinding GetCopy()
		{
			return new SteamVR_Input_ActionFile_DefaultBinding
			{
				controller_type = controller_type,
				binding_url = binding_url
			};
		}
	}
	[Serializable]
	public class SteamVR_Input_ActionFile_ActionSet
	{
		[JsonIgnore]
		private const string actionSetInstancePrefix = "instance_";

		public string name;

		public string usage;

		private const string nameTemplate = "/actions/{0}";

		[JsonIgnore]
		public List<SteamVR_Input_ActionFile_Action> actionsInList = new List<SteamVR_Input_ActionFile_Action>();

		[JsonIgnore]
		public List<SteamVR_Input_ActionFile_Action> actionsOutList = new List<SteamVR_Input_ActionFile_Action>();

		[JsonIgnore]
		public List<SteamVR_Input_ActionFile_Action> actionsList = new List<SteamVR_Input_ActionFile_Action>();

		[JsonIgnore]
		public string codeFriendlyName => SteamVR_Input_ActionFile.GetCodeFriendlyName(name);

		[JsonIgnore]
		public string shortName
		{
			get
			{
				if (name.LastIndexOf('/') == name.Length - 1)
				{
					return string.Empty;
				}
				return SteamVR_Input_ActionFile.GetShortName(name);
			}
		}

		public void SetNewShortName(string newShortName)
		{
			name = GetPathFromName(newShortName);
		}

		public static string CreateNewName()
		{
			return GetPathFromName("NewSet");
		}

		public static string GetPathFromName(string name)
		{
			return $"/actions/{name}";
		}

		public static SteamVR_Input_ActionFile_ActionSet CreateNew()
		{
			return new SteamVR_Input_ActionFile_ActionSet
			{
				name = CreateNewName()
			};
		}

		public SteamVR_Input_ActionFile_ActionSet GetCopy()
		{
			return new SteamVR_Input_ActionFile_ActionSet
			{
				name = name,
				usage = usage
			};
		}

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_ActionFile_ActionSet)
			{
				SteamVR_Input_ActionFile_ActionSet steamVR_Input_ActionFile_ActionSet = (SteamVR_Input_ActionFile_ActionSet)obj;
				if (steamVR_Input_ActionFile_ActionSet == this)
				{
					return true;
				}
				if (steamVR_Input_ActionFile_ActionSet.name == name)
				{
					return true;
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public enum SteamVR_Input_ActionFile_Action_Requirements
	{
		optional,
		suggested,
		mandatory
	}
	[Serializable]
	public class SteamVR_Input_ActionFile_Action
	{
		[JsonIgnore]
		private static string[] _requirementValues;

		public string name;

		public string type;

		public string scope;

		public string skeleton;

		public string requirement;

		private const string nameTemplate = "/actions/{0}/{1}/{2}";

		protected const string prefix = "/actions/";

		[JsonIgnore]
		public static string[] requirementValues
		{
			get
			{
				if (_requirementValues == null)
				{
					_requirementValues = Enum.GetNames(typeof(SteamVR_Input_ActionFile_Action_Requirements));
				}
				return _requirementValues;
			}
		}

		[JsonIgnore]
		public SteamVR_Input_ActionFile_Action_Requirements requirementEnum
		{
			get
			{
				for (int i = 0; i < requirementValues.Length; i++)
				{
					if (string.Equals(requirementValues[i], requirement, StringComparison.CurrentCultureIgnoreCase))
					{
						return (SteamVR_Input_ActionFile_Action_Requirements)i;
					}
				}
				return SteamVR_Input_ActionFile_Action_Requirements.suggested;
			}
			set
			{
				requirement = value.ToString();
			}
		}

		[JsonIgnore]
		public string codeFriendlyName => SteamVR_Input_ActionFile.GetCodeFriendlyName(name);

		[JsonIgnore]
		public string shortName => SteamVR_Input_ActionFile.GetShortName(name);

		[JsonIgnore]
		public string path
		{
			get
			{
				int num = name.LastIndexOf('/');
				if (num != -1 && num + 1 < name.Length)
				{
					return name.Substring(0, num + 1);
				}
				return name;
			}
		}

		[JsonIgnore]
		public SteamVR_ActionDirections direction
		{
			get
			{
				if (type.ToLower() == SteamVR_Input_ActionFile_ActionTypes.vibration)
				{
					return SteamVR_ActionDirections.Out;
				}
				return SteamVR_ActionDirections.In;
			}
		}

		[JsonIgnore]
		public string actionSet
		{
			get
			{
				int num = name.IndexOf('/', "/actions/".Length);
				if (num == -1)
				{
					return string.Empty;
				}
				return name.Substring(0, num);
			}
		}

		public SteamVR_Input_ActionFile_Action GetCopy()
		{
			return new SteamVR_Input_ActionFile_Action
			{
				name = name,
				type = type,
				scope = scope,
				skeleton = skeleton,
				requirement = requirement
			};
		}

		public static string CreateNewName(string actionSet, string direction)
		{
			return string.Format("/actions/{0}/{1}/{2}", actionSet, direction, "NewAction");
		}

		public static string CreateNewName(string actionSet, SteamVR_ActionDirections direction, string actionName)
		{
			return $"/actions/{actionSet}/{direction.ToString().ToLower()}/{actionName}";
		}

		public static SteamVR_Input_ActionFile_Action CreateNew(string actionSet, SteamVR_ActionDirections direction, string actionType)
		{
			return new SteamVR_Input_ActionFile_Action
			{
				name = CreateNewName(actionSet, direction.ToString().ToLower()),
				type = actionType
			};
		}

		public void SetNewActionSet(string newSetName)
		{
			name = $"/actions/{newSetName}/{direction.ToString().ToLower()}/{shortName}";
		}

		public override string ToString()
		{
			return shortName;
		}

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_ActionFile_Action)
			{
				SteamVR_Input_ActionFile_Action steamVR_Input_ActionFile_Action = (SteamVR_Input_ActionFile_Action)obj;
				if (this == obj)
				{
					return true;
				}
				if (name == steamVR_Input_ActionFile_Action.name && type == steamVR_Input_ActionFile_Action.type && skeleton == steamVR_Input_ActionFile_Action.skeleton && requirement == steamVR_Input_ActionFile_Action.requirement)
				{
					return true;
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public class SteamVR_Input_ActionFile_LocalizationItem
	{
		public const string languageTagKeyName = "language_tag";

		public string language;

		public Dictionary<string, string> items = new Dictionary<string, string>();

		public SteamVR_Input_ActionFile_LocalizationItem(string newLanguage)
		{
			language = newLanguage;
		}

		public SteamVR_Input_ActionFile_LocalizationItem(Dictionary<string, string> dictionary)
		{
			if (dictionary == null)
			{
				return;
			}
			if (dictionary.ContainsKey("language_tag"))
			{
				language = dictionary["language_tag"];
			}
			else
			{
				UnityEngine.Debug.Log("<b>[SteamVR]</b> Input: Error in actions file, no language_tag in localization array item.");
			}
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				if (item.Key != "language_tag")
				{
					items.Add(item.Key, item.Value);
				}
			}
		}
	}
	public class SteamVR_Input_ManifestFile
	{
		public string source;

		public List<SteamVR_Input_ManifestFile_Application> applications;
	}
	public class SteamVR_Input_ManifestFile_Application
	{
		public string app_key;

		public string launch_type;

		public string url;

		public string binary_path_windows;

		public string binary_path_linux;

		public string binary_path_osx;

		public string action_manifest_path;

		public string image_path;

		public Dictionary<string, SteamVR_Input_ManifestFile_ApplicationString> strings = new Dictionary<string, SteamVR_Input_ManifestFile_ApplicationString>();
	}
	public class SteamVR_Input_Unity_AssemblyFile_Definition
	{
		public string name = "SteamVR_Actions";

		public string[] references = new string[1] { "SteamVR" };

		public string[] optionalUnityReferences = new string[0];

		public string[] includePlatforms = new string[0];

		public string[] excludePlatforms = new string[1] { "Android" };

		public bool allowUnsafeCode;

		public bool overrideReferences;

		public string[] precompiledReferences = new string[0];

		public bool autoReferenced;

		public string[] defineConstraints = new string[0];
	}
	public class SteamVR_Input_ManifestFile_ApplicationString
	{
		public string name;
	}
	public class SteamVR_Input_ManifestFile_Application_Binding
	{
		public string controller_type;

		public string binding_url;
	}
	public class SteamVR_Input_ManifestFile_Application_Binding_ControllerTypes
	{
		public static string oculus_touch = "oculus_touch";

		public static string vive_controller = "vive_controller";

		public static string knuckles = "knuckles";

		public static string holographic_controller = "holographic_controller";

		public static string vive = "vive";

		public static string vive_pro = "vive_pro";

		public static string holographic_hmd = "holographic_hmd";

		public static string rift = "rift";

		public static string vive_tracker_camera = "vive_tracker_camera";

		public static string vive_cosmos = "vive_cosmos";

		public static string vive_cosmos_controller = "vive_cosmos_controller";

		public static string index_hmd = "index_hmd";
	}
	public static class SteamVR_Input_ActionFile_ActionTypes
	{
		public static string boolean = "boolean";

		public static string vector1 = "vector1";

		public static string vector2 = "vector2";

		public static string vector3 = "vector3";

		public static string vibration = "vibration";

		public static string pose = "pose";

		public static string skeleton = "skeleton";

		public static string skeletonLeftPath = "\\skeleton\\hand\\left";

		public static string skeletonRightPath = "\\skeleton\\hand\\right";

		public static string[] listAll = new string[7] { boolean, vector1, vector2, vector3, vibration, pose, skeleton };

		public static string[] listIn = new string[6] { boolean, vector1, vector2, vector3, pose, skeleton };

		public static string[] listOut = new string[1] { vibration };

		public static string[] listSkeletons = new string[2] { skeletonLeftPath, skeletonRightPath };
	}
	public static class SteamVR_Input_ActionFile_ActionSet_Usages
	{
		public static string leftright = "leftright";

		public static string single = "single";

		public static string hidden = "hidden";

		public static string leftrightDescription = "per hand";

		public static string singleDescription = "mirrored";

		public static string hiddenDescription = "hidden";

		public static string[] listValues = new string[3] { leftright, single, hidden };

		public static string[] listDescriptions = new string[3] { leftrightDescription, singleDescription, hiddenDescription };
	}
	public enum SteamVR_Input_ActionScopes
	{
		ActionSet,
		Application,
		Global
	}
	public enum SteamVR_Input_ActionSetUsages
	{
		LeftRight,
		Single,
		Hidden
	}
	[Serializable]
	public class SteamVR_Input_BindingFile
	{
		public string app_key;

		public Dictionary<string, SteamVR_Input_BindingFile_ActionList> bindings = new Dictionary<string, SteamVR_Input_BindingFile_ActionList>();

		public string controller_type;

		public string description;

		public string name;
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_ActionList
	{
		public List<SteamVR_Input_BindingFile_Chord> chords = new List<SteamVR_Input_BindingFile_Chord>();

		public List<SteamVR_Input_BindingFile_Pose> poses = new List<SteamVR_Input_BindingFile_Pose>();

		public List<SteamVR_Input_BindingFile_Haptic> haptics = new List<SteamVR_Input_BindingFile_Haptic>();

		public List<SteamVR_Input_BindingFile_Source> sources = new List<SteamVR_Input_BindingFile_Source>();

		public List<SteamVR_Input_BindingFile_Skeleton> skeleton = new List<SteamVR_Input_BindingFile_Skeleton>();
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Chord
	{
		public string output;

		public List<List<string>> inputs = new List<List<string>>();

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Chord)
			{
				SteamVR_Input_BindingFile_Chord steamVR_Input_BindingFile_Chord = (SteamVR_Input_BindingFile_Chord)obj;
				if (output == steamVR_Input_BindingFile_Chord.output && inputs != null && steamVR_Input_BindingFile_Chord.inputs != null && inputs.Count == steamVR_Input_BindingFile_Chord.inputs.Count)
				{
					for (int i = 0; i < inputs.Count; i++)
					{
						if (inputs[i] == null || steamVR_Input_BindingFile_Chord.inputs[i] == null || inputs[i].Count != steamVR_Input_BindingFile_Chord.inputs[i].Count)
						{
							continue;
						}
						for (int j = 0; j < inputs[i].Count; j++)
						{
							if (inputs[i][j] != steamVR_Input_BindingFile_Chord.inputs[i][j])
							{
								return false;
							}
						}
						return true;
					}
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Pose
	{
		public string output;

		public string path;

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Pose)
			{
				SteamVR_Input_BindingFile_Pose steamVR_Input_BindingFile_Pose = (SteamVR_Input_BindingFile_Pose)obj;
				if (steamVR_Input_BindingFile_Pose.output == output && steamVR_Input_BindingFile_Pose.path == path)
				{
					return true;
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Haptic
	{
		public string output;

		public string path;

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Haptic)
			{
				SteamVR_Input_BindingFile_Haptic steamVR_Input_BindingFile_Haptic = (SteamVR_Input_BindingFile_Haptic)obj;
				if (steamVR_Input_BindingFile_Haptic.output == output && steamVR_Input_BindingFile_Haptic.path == path)
				{
					return true;
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Skeleton
	{
		public string output;

		public string path;

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Skeleton)
			{
				SteamVR_Input_BindingFile_Skeleton steamVR_Input_BindingFile_Skeleton = (SteamVR_Input_BindingFile_Skeleton)obj;
				if (steamVR_Input_BindingFile_Skeleton.output == output && steamVR_Input_BindingFile_Skeleton.path == path)
				{
					return true;
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Source
	{
		public string path;

		public string mode;

		public SteamVR_Input_BindingFile_Source_Input_StringDictionary parameters = new SteamVR_Input_BindingFile_Source_Input_StringDictionary();

		public SteamVR_Input_BindingFile_Source_Input inputs = new SteamVR_Input_BindingFile_Source_Input();

		protected const string outputKeyName = "output";

		public string GetOutput()
		{
			foreach (KeyValuePair<string, SteamVR_Input_BindingFile_Source_Input_StringDictionary> input in inputs)
			{
				foreach (KeyValuePair<string, string> item in input.Value)
				{
					if (item.Key == "output")
					{
						return item.Value;
					}
				}
			}
			return null;
		}

		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Source)
			{
				SteamVR_Input_BindingFile_Source steamVR_Input_BindingFile_Source = (SteamVR_Input_BindingFile_Source)obj;
				if (steamVR_Input_BindingFile_Source.mode == mode && steamVR_Input_BindingFile_Source.path == path)
				{
					bool flag = false;
					if (parameters != null && steamVR_Input_BindingFile_Source.parameters != null)
					{
						if (parameters.Equals(steamVR_Input_BindingFile_Source.parameters))
						{
							flag = true;
						}
					}
					else if (parameters == null && steamVR_Input_BindingFile_Source.parameters == null)
					{
						flag = true;
					}
					if (flag)
					{
						bool result = false;
						if (inputs != null && steamVR_Input_BindingFile_Source.inputs != null)
						{
							if (inputs.Equals(steamVR_Input_BindingFile_Source.inputs))
							{
								result = true;
							}
						}
						else if (inputs == null && steamVR_Input_BindingFile_Source.inputs == null)
						{
							result = true;
						}
						return result;
					}
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Source_Input : Dictionary<string, SteamVR_Input_BindingFile_Source_Input_StringDictionary>
	{
		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Source_Input)
			{
				SteamVR_Input_BindingFile_Source_Input steamVR_Input_BindingFile_Source_Input = (SteamVR_Input_BindingFile_Source_Input)obj;
				if (this == steamVR_Input_BindingFile_Source_Input)
				{
					return true;
				}
				if (base.Count == steamVR_Input_BindingFile_Source_Input.Count)
				{
					using (Enumerator enumerator = GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							KeyValuePair<string, SteamVR_Input_BindingFile_Source_Input_StringDictionary> current = enumerator.Current;
							if (!steamVR_Input_BindingFile_Source_Input.ContainsKey(current.Key))
							{
								return false;
							}
							if (!base[current.Key].Equals(steamVR_Input_BindingFile_Source_Input[current.Key]))
							{
								return false;
							}
						}
					}
					return true;
				}
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	[Serializable]
	public class SteamVR_Input_BindingFile_Source_Input_StringDictionary : Dictionary<string, string>
	{
		public override bool Equals(object obj)
		{
			if (obj is SteamVR_Input_BindingFile_Source_Input_StringDictionary)
			{
				SteamVR_Input_BindingFile_Source_Input_StringDictionary steamVR_Input_BindingFile_Source_Input_StringDictionary = (SteamVR_Input_BindingFile_Source_Input_StringDictionary)obj;
				if (this == steamVR_Input_BindingFile_Source_Input_StringDictionary)
				{
					return true;
				}
				if (base.Count == steamVR_Input_BindingFile_Source_Input_StringDictionary.Count)
				{
					return !this.Except(steamVR_Input_BindingFile_Source_Input_StringDictionary).Any();
				}
				return false;
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	public class SteamVR_Input_Generator_Names
	{
		public const string fullActionsClassName = "Valve.VR.SteamVR_Actions";

		public const string actionsClassName = "SteamVR_Actions";

		public const string preinitializeMethodName = "PreInitialize";

		public const string actionsFieldName = "actions";

		public const string actionsInFieldName = "actionsIn";

		public const string actionsOutFieldName = "actionsOut";

		public const string actionsVibrationFieldName = "actionsVibration";

		public const string actionsPoseFieldName = "actionsPose";

		public const string actionsBooleanFieldName = "actionsBoolean";

		public const string actionsSingleFieldName = "actionsSingle";

		public const string actionsVector2FieldName = "actionsVector2";

		public const string actionsVector3FieldName = "actionsVector3";

		public const string actionsSkeletonFieldName = "actionsSkeleton";

		public const string actionsNonPoseNonSkeletonIn = "actionsNonPoseNonSkeletonIn";

		public const string actionSetsFieldName = "actionSets";
	}
	public static class SteamVR_Input_Source
	{
		public static int numSources = Enum.GetValues(typeof(SteamVR_Input_Sources)).Length;

		private static ulong[] inputSourceHandlesBySource;

		private static Dictionary<ulong, SteamVR_Input_Sources> inputSourceSourcesByHandle = new Dictionary<ulong, SteamVR_Input_Sources>();

		private static Type enumType = typeof(SteamVR_Input_Sources);

		private static Type descriptionType = typeof(DescriptionAttribute);

		private static SteamVR_Input_Sources[] allSources;

		public static ulong GetHandle(SteamVR_Input_Sources inputSource)
		{
			if ((int)inputSource < inputSourceHandlesBySource.Length)
			{
				return inputSourceHandlesBySource[(int)inputSource];
			}
			return 0uL;
		}

		public static SteamVR_Input_Sources GetSource(ulong handle)
		{
			if (inputSourceSourcesByHandle.ContainsKey(handle))
			{
				return inputSourceSourcesByHandle[handle];
			}
			return SteamVR_Input_Sources.Any;
		}

		public static SteamVR_Input_Sources[] GetAllSources()
		{
			if (allSources == null)
			{
				allSources = (SteamVR_Input_Sources[])Enum.GetValues(typeof(SteamVR_Input_Sources));
			}
			return allSources;
		}

		private static string GetPath(string inputSourceEnumName)
		{
			return ((DescriptionAttribute)enumType.GetMember(inputSourceEnumName)[0].GetCustomAttributes(descriptionType, inherit: false)[0]).Description;
		}

		public static void Initialize()
		{
			List<SteamVR_Input_Sources> list = new List<SteamVR_Input_Sources>();
			string[] names = Enum.GetNames(enumType);
			inputSourceHandlesBySource = new ulong[names.Length];
			inputSourceSourcesByHandle = new Dictionary<ulong, SteamVR_Input_Sources>();
			for (int i = 0; i < names.Length; i++)
			{
				string path = GetPath(names[i]);
				ulong pHandle = 0uL;
				EVRInputError inputSourceHandle = OpenVR.Input.GetInputSourceHandle(path, ref pHandle);
				if (inputSourceHandle != EVRInputError.None)
				{
					UnityEngine.Debug.LogError("<b>[SteamVR]</b> GetInputSourceHandle (" + path + ") error: " + inputSourceHandle);
				}
				if (names[i] == SteamVR_Input_Sources.Any.ToString())
				{
					inputSourceHandlesBySource[i] = 0uL;
					inputSourceSourcesByHandle.Add(0uL, (SteamVR_Input_Sources)i);
				}
				else
				{
					inputSourceHandlesBySource[i] = pHandle;
					inputSourceSourcesByHandle.Add(pHandle, (SteamVR_Input_Sources)i);
				}
				list.Add((SteamVR_Input_Sources)i);
			}
			allSources = list.ToArray();
		}
	}
	public enum SteamVR_Input_Sources
	{
		[Description("/unrestricted")]
		Any,
		[Description("/user/hand/left")]
		LeftHand,
		[Description("/user/hand/right")]
		RightHand,
		[Description("/user/foot/left")]
		LeftFoot,
		[Description("/user/foot/right")]
		RightFoot,
		[Description("/user/shoulder/left")]
		LeftShoulder,
		[Description("/user/shoulder/right")]
		RightShoulder,
		[Description("/user/waist")]
		Waist,
		[Description("/user/chest")]
		Chest,
		[Description("/user/head")]
		Head,
		[Description("/user/gamepad")]
		Gamepad,
		[Description("/user/camera")]
		Camera,
		[Description("/user/keyboard")]
		Keyboard,
		[Description("/user/treadmill")]
		Treadmill
	}
	public class SteamVR_Skeleton_Pose : ScriptableObject
	{
		public SteamVR_Skeleton_Pose_Hand leftHand = new SteamVR_Skeleton_Pose_Hand(SteamVR_Input_Sources.LeftHand);

		public SteamVR_Skeleton_Pose_Hand rightHand = new SteamVR_Skeleton_Pose_Hand(SteamVR_Input_Sources.RightHand);

		protected const int leftHandInputSource = 1;

		protected const int rightHandInputSource = 2;

		public bool applyToSkeletonRoot = true;

		public SteamVR_Skeleton_Pose_Hand GetHand(int hand)
		{
			return hand switch
			{
				1 => leftHand, 
				2 => rightHand, 
				_ => null, 
			};
		}

		public SteamVR_Skeleton_Pose_Hand GetHand(SteamVR_Input_Sources hand)
		{
			return hand switch
			{
				SteamVR_Input_Sources.LeftHand => leftHand, 
				SteamVR_Input_Sources.RightHand => rightHand, 
				_ => null, 
			};
		}
	}
	[Serializable]
	public class SteamVR_Skeleton_Pose_Hand
	{
		public SteamVR_Input_Sources inputSource;

		public SteamVR_Skeleton_FingerExtensionTypes thumbFingerMovementType;

		public SteamVR_Skeleton_FingerExtensionTypes indexFingerMovementType;

		public SteamVR_Skeleton_FingerExtensionTypes middleFingerMovementType;

		public SteamVR_Skeleton_FingerExtensionTypes ringFingerMovementType;

		public SteamVR_Skeleton_FingerExtensionTypes pinkyFingerMovementType;

		public bool ignoreRootPoseData = true;

		public bool ignoreWristPoseData = true;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3[] bonePositions;

		public Quaternion[] boneRotations;

		public SteamVR_Skeleton_FingerExtensionTypes GetFingerExtensionType(int finger)
		{
			switch (finger)
			{
			case 0:
				return thumbFingerMovementType;
			case 1:
				return indexFingerMovementType;
			case 2:
				return middleFingerMovementType;
			case 3:
				return ringFingerMovementType;
			case 4:
				return pinkyFingerMovementType;
			default:
				UnityEngine.Debug.LogWarning("Finger not in range!");
				return SteamVR_Skeleton_FingerExtensionTypes.Static;
			}
		}

		public SteamVR_Skeleton_Pose_Hand(SteamVR_Input_Sources source)
		{
			inputSource = source;
		}

		public SteamVR_Skeleton_FingerExtensionTypes GetMovementTypeForBone(int boneIndex)
		{
			return SteamVR_Skeleton_JointIndexes.GetFingerForBone(boneIndex) switch
			{
				0 => thumbFingerMovementType, 
				1 => indexFingerMovementType, 
				2 => middleFingerMovementType, 
				3 => ringFingerMovementType, 
				4 => pinkyFingerMovementType, 
				_ => SteamVR_Skeleton_FingerExtensionTypes.Static, 
			};
		}
	}
	public enum SteamVR_Skeleton_FingerExtensionTypes
	{
		Static,
		Free,
		Extend,
		Contract
	}
	public class SteamVR_Skeleton_FingerExtensionTypeLists
	{
		private SteamVR_Skeleton_FingerExtensionTypes[] _enumList;

		private string[] _stringList;

		public SteamVR_Skeleton_FingerExtensionTypes[] enumList
		{
			get
			{
				if (_enumList == null)
				{
					_enumList = (SteamVR_Skeleton_FingerExtensionTypes[])Enum.GetValues(typeof(SteamVR_Skeleton_FingerExtensionTypes));
				}
				return _enumList;
			}
		}

		public string[] stringList
		{
			get
			{
				if (_stringList == null)
				{
					_stringList = enumList.Select((SteamVR_Skeleton_FingerExtensionTypes element) => element.ToString()).ToArray();
				}
				return _stringList;
			}
		}
	}
	public class SteamVR_Skeleton_Poser : MonoBehaviour
	{
		public class SkeletonBlendablePose
		{
			public SteamVR_Skeleton_Pose pose;

			public SteamVR_Skeleton_PoseSnapshot snapshotR;

			public SteamVR_Skeleton_PoseSnapshot snapshotL;

			public SteamVR_Skeleton_PoseSnapshot GetHandSnapshot(SteamVR_Input_Sources inputSource)
			{
				if (inputSource == SteamVR_Input_Sources.LeftHand)
				{
					return snapshotL;
				}
				return snapshotR;
			}

			public void UpdateAdditiveAnimation(SteamVR_Action_Skeleton skeletonAction, SteamVR_Input_Sources inputSource)
			{
				if (skeletonAction.GetSkeletalTrackingLevel() == EVRSkeletalTrackingLevel.VRSkeletalTracking_Estimated)
				{
					return;
				}
				SteamVR_Skeleton_PoseSnapshot handSnapshot = GetHandSnapshot(inputSource);
				SteamVR_Skeleton_Pose_Hand hand = pose.GetHand(inputSource);
				for (int i = 0; i < snapshotL.bonePositions.Length; i++)
				{
					int fingerForBone = SteamVR_Skeleton_JointIndexes.GetFingerForBone(i);
					SteamVR_Skeleton_FingerExtensionTypes movementTypeForBone = hand.GetMovementTypeForBone(i);
					if (movementTypeForBone == SteamVR_Skeleton_FingerExtensionTypes.Free)
					{
						handSnapshot.bonePositions[i] = skeletonAction.bonePositions[i];
						handSnapshot.boneRotations[i] = skeletonAction.boneRotations[i];
					}
					if (movementTypeForBone == SteamVR_Skeleton_FingerExtensionTypes.Extend)
					{
						handSnapshot.bonePositions[i] = Vector3.Lerp(hand.bonePositions[i], skeletonAction.bonePositions[i], 1f - skeletonAction.fingerCurls[fingerForBone]);
						handSnapshot.boneRotations[i] = Quaternion.Lerp(hand.boneRotations[i], skeletonAction.boneRotations[i], 1f - skeletonAction.fingerCurls[fingerForBone]);
					}
					if (movementTypeForBone == SteamVR_Skeleton_FingerExtensionTypes.Contract)
					{
						handSnapshot.bonePositions[i] = Vector3.Lerp(hand.bonePositions[i], skeletonAction.bonePositions[i], skeletonAction.fingerCurls[fingerForBone]);
						handSnapshot.boneRotations[i] = Quaternion.Lerp(hand.boneRotations[i], skeletonAction.boneRotations[i], skeletonAction.fingerCurls[fingerForBone]);
					}
				}
			}

			public SkeletonBlendablePose(SteamVR_Skeleton_Pose p)
			{
				pose = p;
				snapshotR = new SteamVR_Skeleton_PoseSnapshot(p.rightHand.bonePositions.Length, SteamVR_Input_Sources.RightHand);
				snapshotL = new SteamVR_Skeleton_PoseSnapshot(p.leftHand.bonePositions.Length, SteamVR_Input_Sources.LeftHand);
			}

			public void PoseToSnapshots()
			{
				snapshotR.position = pose.rightHand.position;
				snapshotR.rotation = pose.rightHand.rotation;
				pose.rightHand.bonePositions.CopyTo(snapshotR.bonePositions, 0);
				pose.rightHand.boneRotations.CopyTo(snapshotR.boneRotations, 0);
				snapshotL.position = pose.leftHand.position;
				snapshotL.rotation = pose.leftHand.rotation;
				pose.leftHand.bonePositions.CopyTo(snapshotL.bonePositions, 0);
				pose.leftHand.boneRotations.CopyTo(snapshotL.boneRotations, 0);
			}

			public SkeletonBlendablePose()
			{
			}
		}

		[Serializable]
		public class PoseBlendingBehaviour
		{
			public enum BlenderTypes
			{
				Manual,
				AnalogAction,
				BooleanAction
			}

			public string name;

			public bool enabled = true;

			public float influence = 1f;

			public int pose = 1;

			public float value;

			public SteamVR_Action_Single action_single;

			public SteamVR_Action_Boolean action_bool;

			public float smoothingSpeed;

			public BlenderTypes type;

			public bool useMask;

			public SteamVR_Skeleton_HandMask mask = new SteamVR_Skeleton_HandMask();

			public bool previewEnabled;

			public void Update(float deltaTime, SteamVR_Input_Sources inputSource)
			{
				if (type == BlenderTypes.AnalogAction)
				{
					if (smoothingSpeed == 0f)
					{
						value = action_single.GetAxis(inputSource);
					}
					else
					{
						value = Mathf.Lerp(value, action_single.GetAxis(inputSource), deltaTime * smoothingSpeed);
					}
				}
				if (type == BlenderTypes.BooleanAction)
				{
					if (smoothingSpeed == 0f)
					{
						value = (action_bool.GetState(inputSource) ? 1 : 0);
					}
					else
					{
						value = Mathf.Lerp(value, action_bool.GetState(inputSource) ? 1 : 0, deltaTime * smoothingSpeed);
					}
				}
			}

			public void ApplyBlending(SteamVR_Skeleton_PoseSnapshot snapshot, SkeletonBlendablePose[] blendPoses, SteamVR_Input_Sources inputSource)
			{
				SteamVR_Skeleton_PoseSnapshot handSnapshot = blendPoses[pose].GetHandSnapshot(inputSource);
				if (mask.GetFinger(0) || !useMask)
				{
					snapshot.position = Vector3.Lerp(snapshot.position, handSnapshot.position, influence * value);
					snapshot.rotation = Quaternion.Slerp(snapshot.rotation, handSnapshot.rotation, influence * value);
				}
				for (int i = 0; i < snapshot.bonePositions.Length; i++)
				{
					if (mask.GetFinger(SteamVR_Skeleton_JointIndexes.GetFingerForBone(i) + 1) || !useMask)
					{
						snapshot.bonePositions[i] = Vector3.Lerp(snapshot.bonePositions[i], handSnapshot.bonePositions[i], influence * value);
						snapshot.boneRotations[i] = Quaternion.Slerp(snapshot.boneRotations[i], handSnapshot.boneRotations[i], influence * value);
					}
				}
			}

			public PoseBlendingBehaviour()
			{
				enabled = true;
				influence = 1f;
			}
		}

		public bool poseEditorExpanded = true;

		public bool blendEditorExpanded = true;

		public string[] poseNames;

		public GameObject overridePreviewLeftHandPrefab;

		public GameObject overridePreviewRightHandPrefab;

		public SteamVR_Skeleton_Pose skeletonMainPose;

		public List<SteamVR_Skeleton_Pose> skeletonAdditionalPoses = new List<SteamVR_Skeleton_Pose>();

		[SerializeField]
		protected bool showLeftPreview;

		[SerializeField]
		protected bool showRightPreview = true;

		[SerializeField]
		protected GameObject previewLeftInstance;

		[SerializeField]
		protected GameObject previewRightInstance;

		[SerializeField]
		protected int previewPoseSelection;

		public List<PoseBlendingBehaviour> blendingBehaviours = new List<PoseBlendingBehaviour>();

		public SteamVR_Skeleton_PoseSnapshot blendedSnapshotL;

		public SteamVR_Skeleton_PoseSnapshot blendedSnapshotR;

		private SkeletonBlendablePose[] blendPoses;

		private int boneCount;

		private bool poseUpdatedThisFrame;

		public float scale;

		public int blendPoseCount => blendPoses.Length;

		protected void Awake()
		{
			if (previewLeftInstance != null)
			{
				UnityEngine.Object.DestroyImmediate(previewLeftInstance);
			}
			if (previewRightInstance != null)
			{
				UnityEngine.Object.DestroyImmediate(previewRightInstance);
			}
			blendPoses = new SkeletonBlendablePose[skeletonAdditionalPoses.Count + 1];
			for (int i = 0; i < blendPoseCount; i++)
			{
				blendPoses[i] = new SkeletonBlendablePose(GetPoseByIndex(i));
				blendPoses[i].PoseToSnapshots();
			}
			boneCount = skeletonMainPose.leftHand.bonePositions.Length;
			blendedSnapshotL = new SteamVR_Skeleton_PoseSnapshot(boneCount, SteamVR_Input_Sources.LeftHand);
			blendedSnapshotR = new SteamVR_Skeleton_PoseSnapshot(boneCount, SteamVR_Input_Sources.RightHand);
		}

		public void SetBlendingBehaviourValue(string behaviourName, float value)
		{
			PoseBlendingBehaviour poseBlendingBehaviour = FindBlendingBehaviour(behaviourName);
			if (poseBlendingBehaviour != null)
			{
				poseBlendingBehaviour.value = value;
				if (poseBlendingBehaviour.type != PoseBlendingBehaviour.BlenderTypes.Manual)
				{
					UnityEngine.Debug.LogWarning("[SteamVR] Blending Behaviour: " + behaviourName + " is not a manual behaviour. Its value will likely be overriden.", this);
				}
			}
		}

		public float GetBlendingBehaviourValue(string behaviourName)
		{
			return FindBlendingBehaviour(behaviourName)?.value ?? 0f;
		}

		public void SetBlendingBehaviourEnabled(string behaviourName, bool value)
		{
			PoseBlendingBehaviour poseBlendingBehaviour = FindBlendingBehaviour(behaviourName);
			if (poseBlendingBehaviour != null)
			{
				poseBlendingBehaviour.enabled = value;
			}
		}

		public bool GetBlendingBehaviourEnabled(string behaviourName)
		{
			return FindBlendingBehaviour(behaviourName)?.enabled ?? false;
		}

		public PoseBlendingBehaviour GetBlendingBehaviour(string behaviourName)
		{
			return FindBlendingBehaviour(behaviourName);
		}

		protected PoseBlendingBehaviour FindBlendingBehaviour(string behaviourName, bool throwErrors = true)
		{
			PoseBlendingBehaviour poseBlendingBehaviour = blendingBehaviours.Find((PoseBlendingBehaviour b) => b.name == behaviourName);
			if (poseBlendingBehaviour == null)
			{
				if (throwErrors)
				{
					UnityEngine.Debug.LogError("[SteamVR] Blending Behaviour: " + behaviourName + " not found on Skeleton Poser: " + base.gameObject.name, this);
				}
				return null;
			}
			return poseBlendingBehaviour;
		}

		public SteamVR_Skeleton_Pose GetPoseByIndex(int index)
		{
			if (index == 0)
			{
				return skeletonMainPose;
			}
			return skeletonAdditionalPoses[index - 1];
		}

		private SteamVR_Skeleton_PoseSnapshot GetHandSnapshot(SteamVR_Input_Sources inputSource)
		{
			if (inputSource == SteamVR_Input_Sources.LeftHand)
			{
				return blendedSnapshotL;
			}
			return blendedSnapshotR;
		}

		public SteamVR_Skeleton_PoseSnapshot GetBlendedPose(SteamVR_Action_Skeleton skeletonAction, SteamVR_Input_Sources handType)
		{
			UpdatePose(skeletonAction, handType);
			return GetHandSnapshot(handType);
		}

		public SteamVR_Skeleton_PoseSnapshot GetBlendedPose(SteamVR_Behaviour_Skeleton skeletonBehaviour)
		{
			return GetBlendedPose(skeletonBehaviour.skeletonAction, skeletonBehaviour.inputSource);
		}

		public void UpdatePose(SteamVR_Action_Skeleton skeletonAction, SteamVR_Input_Sources inputSource)
		{
			if (!poseUpdatedThisFrame)
			{
				poseUpdatedThisFrame = true;
				if (skeletonAction.activeBinding)
				{
					blendPoses[0].UpdateAdditiveAnimation(skeletonAction, inputSource);
				}
				SteamVR_Skeleton_PoseSnapshot handSnapshot = GetHandSnapshot(inputSource);
				handSnapshot.CopyFrom(blendPoses[0].GetHandSnapshot(inputSource));
				ApplyBlenderBehaviours(skeletonAction, inputSource, handSnapshot);
				if (inputSource == SteamVR_Input_Sources.RightHand)
				{
					blendedSnapshotR = handSnapshot;
				}
				if (inputSource == SteamVR_Input_Sources.LeftHand)
				{
					blendedSnapshotL = handSnapshot;
				}
			}
		}

		protected void ApplyBlenderBehaviours(SteamVR_Action_Skeleton skeletonAction, SteamVR_Input_Sources inputSource, SteamVR_Skeleton_PoseSnapshot snapshot)
		{
			for (int i = 0; i < blendingBehaviours.Count; i++)
			{
				blendingBehaviours[i].Update(Time.deltaTime, inputSource);
				if (blendingBehaviours[i].enabled && blendingBehaviours[i].influence * blendingBehaviours[i].value > 0.01f)
				{
					if (blendingBehaviours[i].pose != 0 && skeletonAction.activeBinding)
					{
						blendPoses[blendingBehaviours[i].pose].UpdateAdditiveAnimation(skeletonAction, inputSource);
					}
					blendingBehaviours[i].ApplyBlending(snapshot, blendPoses, inputSource);
				}
			}
		}

		protected void LateUpdate()
		{
			poseUpdatedThisFrame = false;
		}

		protected Vector3 BlendVectors(Vector3[] vectors, float[] weights)
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < vectors.Length; i++)
			{
				zero += vectors[i] * weights[i];
			}
			return zero;
		}

		protected Quaternion BlendQuaternions(Quaternion[] quaternions, float[] weights)
		{
			Quaternion identity = Quaternion.identity;
			for (int i = 0; i < quaternions.Length; i++)
			{
				identity *= Quaternion.Slerp(Quaternion.identity, quaternions[i], weights[i]);
			}
			return identity;
		}

		public Vector3 GetTargetHandPosition(SteamVR_Behaviour_Skeleton hand, Transform origin)
		{
			Vector3 position = origin.position;
			Quaternion rotation = hand.transform.rotation;
			hand.transform.rotation = GetBlendedPose(hand).rotation;
			origin.position = hand.transform.TransformPoint(GetBlendedPose(hand).position);
			Vector3 position2 = origin.InverseTransformPoint(hand.transform.position);
			origin.position = position;
			hand.transform.rotation = rotation;
			return origin.TransformPoint(position2);
		}

		public Quaternion GetTargetHandRotation(SteamVR_Behaviour_Skeleton hand, Transform origin)
		{
			Quaternion rotation = origin.rotation;
			origin.rotation = hand.transform.rotation * GetBlendedPose(hand).rotation;
			Quaternion quaternion = Quaternion.Inverse(origin.rotation) * hand.transform.rotation;
			origin.rotation = rotation;
			return origin.rotation * quaternion;
		}
	}
	public class SteamVR_Skeleton_PoseSnapshot
	{
		public SteamVR_Input_Sources inputSource;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3[] bonePositions;

		public Quaternion[] boneRotations;

		public SteamVR_Skeleton_PoseSnapshot(int boneCount, SteamVR_Input_Sources source)
		{
			inputSource = source;
			bonePositions = new Vector3[boneCount];
			boneRotations = new Quaternion[boneCount];
			position = Vector3.zero;
			rotation = Quaternion.identity;
		}

		public void CopyFrom(SteamVR_Skeleton_PoseSnapshot source)
		{
			inputSource = source.inputSource;
			position = source.position;
			rotation = source.rotation;
			for (int i = 0; i < bonePositions.Length; i++)
			{
				bonePositions[i] = source.bonePositions[i];
				boneRotations[i] = source.boneRotations[i];
			}
		}
	}
	[Serializable]
	public class SteamVR_Skeleton_HandMask
	{
		public bool palm;

		public bool thumb;

		public bool index;

		public bool middle;

		public bool ring;

		public bool pinky;

		public bool[] values = new bool[6];

		public static readonly SteamVR_Skeleton_HandMask fullMask = new SteamVR_Skeleton_HandMask();

		public void SetFinger(int i, bool value)
		{
			values[i] = value;
			Apply();
		}

		public bool GetFinger(int i)
		{
			return values[i];
		}

		public SteamVR_Skeleton_HandMask()
		{
			values = new bool[6];
			Reset();
		}

		public void Reset()
		{
			values = new bool[6];
			for (int i = 0; i < 6; i++)
			{
				values[i] = true;
			}
			Apply();
		}

		protected void Apply()
		{
			palm = values[0];
			thumb = values[1];
			index = values[2];
			middle = values[3];
			ring = values[4];
			pinky = values[5];
		}
	}
	public enum SteamVR_UpdateModes
	{
		Nothing = 1,
		OnUpdate = 2,
		OnFixedUpdate = 4,
		OnPreCull = 8,
		OnLateUpdate = 0x10
	}
	public class SteamVR : IDisposable
	{
		public enum InitializedStates
		{
			None,
			Initializing,
			InitializeSuccess,
			InitializeFailure
		}

		private static bool _enabled = true;

		private static SteamVR _instance;

		public static InitializedStates initializedState = InitializedStates.None;

		public static bool[] connected = new bool[64];

		public ETextureType textureType;

		private static bool runningTemporarySession = false;

		public const string defaultUnityAppKeyTemplate = "application.generated.unity.{0}.exe";

		public const string defaultAppKeyTemplate = "application.generated.{0}";

		public static bool active => _instance != null;

		public static bool enabled
		{
			get
			{
				if (XRSettings.supportedDevices.Length == 0)
				{
					enabled = false;
				}
				return _enabled;
			}
			set
			{
				_enabled = value;
				if (_enabled)
				{
					Initialize();
				}
				else
				{
					SafeDispose();
				}
			}
		}

		public static SteamVR instance
		{
			get
			{
				if (!enabled)
				{
					return null;
				}
				if (_instance == null)
				{
					_instance = CreateInstance();
					if (_instance == null)
					{
						_enabled = false;
					}
				}
				return _instance;
			}
		}

		public static bool usingNativeSupport => XRDevice.GetNativePtr() != IntPtr.Zero;

		public static SteamVR_Settings settings { get; private set; }

		public CVRSystem hmd { get; private set; }

		public CVRCompositor compositor { get; private set; }

		public CVROverlay overlay { get; private set; }

		public static bool initializing { get; private set; }

		public static bool calibrating { get; private set; }

		public static bool outOfRange { get; private set; }

		public float sceneWidth { get; private set; }

		public float sceneHeight { get; private set; }

		public float aspect { get; private set; }

		public float fieldOfView { get; private set; }

		public Vector2 tanHalfFov { get; private set; }

		public VRTextureBounds_t[] textureBounds { get; private set; }

		public SteamVR_Utils.RigidTransform[] eyes { get; private set; }

		public string hmd_TrackingSystemName => GetStringProperty(ETrackedDeviceProperty.Prop_TrackingSystemName_String);

		public string hmd_ModelNumber => GetStringProperty(ETrackedDeviceProperty.Prop_ModelNumber_String);

		public string hmd_SerialNumber => GetStringProperty(ETrackedDeviceProperty.Prop_SerialNumber_String);

		public string hmd_Type => GetStringProperty(ETrackedDeviceProperty.Prop_ControllerType_String);

		public float hmd_SecondsFromVsyncToPhotons => GetFloatProperty(ETrackedDeviceProperty.Prop_SecondsFromVsyncToPhotons_Float);

		public float hmd_DisplayFrequency => GetFloatProperty(ETrackedDeviceProperty.Prop_DisplayFrequency_Float);

		public static void Initialize(bool forceUnityVRMode = false)
		{
			if (forceUnityVRMode)
			{
				SteamVR_Behaviour.instance.InitializeSteamVR(forceUnityVRToOpenVR: true);
				return;
			}
			if (_instance == null)
			{
				_instance = CreateInstance();
				if (_instance == null)
				{
					_enabled = false;
				}
			}
			if (_enabled)
			{
				SteamVR_Behaviour.Initialize(forceUnityVRMode);
			}
		}

		private static void ReportGeneralErrors()
		{
			UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> Initialization failed. " + "Please verify that you have SteamVR installed, your hmd is functioning, and OpenVR Loader is checked in the XR Plugin Management section of Project Settings.");
		}

		private static SteamVR CreateInstance()
		{
			initializedState = InitializedStates.Initializing;
			try
			{
				EVRInitError peError = EVRInitError.None;
				OpenVR.GetGenericInterface("IVRCompositor_026", ref peError);
				if (peError != EVRInitError.None)
				{
					initializedState = InitializedStates.InitializeFailure;
					ReportError(peError);
					ReportGeneralErrors();
					SteamVR_Events.Initialized.Send(arg0: false);
					return null;
				}
				OpenVR.GetGenericInterface("IVROverlay_024", ref peError);
				if (peError != EVRInitError.None)
				{
					initializedState = InitializedStates.InitializeFailure;
					ReportError(peError);
					SteamVR_Events.Initialized.Send(arg0: false);
					return null;
				}
				OpenVR.GetGenericInterface("IVRInput_010", ref peError);
				if (peError != EVRInitError.None)
				{
					initializedState = InitializedStates.InitializeFailure;
					ReportError(peError);
					SteamVR_Events.Initialized.Send(arg0: false);
					return null;
				}
				settings = SteamVR_Settings.instance;
				if (SteamVR_Settings.instance.inputUpdateMode != SteamVR_UpdateModes.Nothing || SteamVR_Settings.instance.poseUpdateMode != SteamVR_UpdateModes.Nothing)
				{
					SteamVR_Input.Initialize();
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> " + ex);
				SteamVR_Events.Initialized.Send(arg0: false);
				return null;
			}
			_enabled = true;
			initializedState = InitializedStates.InitializeSuccess;
			SteamVR_Events.Initialized.Send(arg0: true);
			return new SteamVR();
		}

		private static void ReportError(EVRInitError error)
		{
			switch (error)
			{
			case EVRInitError.VendorSpecific_UnableToConnectToOculusRuntime:
				UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> Initialization Failed!  Make sure device is on, Oculus runtime is installed, and OVRService_*.exe is running.");
				break;
			case EVRInitError.Init_VRClientDLLNotFound:
				UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> Drivers not found!  They can be installed via Steam under Library > Tools.  Visit http://steampowered.com to install Steam.");
				break;
			case EVRInitError.Driver_RuntimeOutOfDate:
				UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> Initialization Failed!  Make sure device's runtime is up to date.");
				break;
			default:
				UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> " + OpenVR.GetStringForHmdError(error));
				break;
			case EVRInitError.None:
				break;
			}
		}

		public EDeviceActivityLevel GetHeadsetActivityLevel()
		{
			return OpenVR.System.GetTrackedDeviceActivityLevel(0u);
		}

		public string GetTrackedDeviceString(uint deviceId)
		{
			ETrackedPropertyError pError = ETrackedPropertyError.TrackedProp_Success;
			uint stringTrackedDeviceProperty = hmd.GetStringTrackedDeviceProperty(deviceId, ETrackedDeviceProperty.Prop_AttachedDeviceId_String, null, 0u, ref pError);
			if (stringTrackedDeviceProperty > 1)
			{
				StringBuilder stringBuilder = new StringBuilder((int)stringTrackedDeviceProperty);
				hmd.GetStringTrackedDeviceProperty(deviceId, ETrackedDeviceProperty.Prop_AttachedDeviceId_String, stringBuilder, stringTrackedDeviceProperty, ref pError);
				return stringBuilder.ToString();
			}
			return null;
		}

		public string GetStringProperty(ETrackedDeviceProperty prop, uint deviceId = 0u)
		{
			ETrackedPropertyError pError = ETrackedPropertyError.TrackedProp_Success;
			uint stringTrackedDeviceProperty = hmd.GetStringTrackedDeviceProperty(deviceId, prop, null, 0u, ref pError);
			if (stringTrackedDeviceProperty > 1)
			{
				StringBuilder stringBuilder = new StringBuilder((int)stringTrackedDeviceProperty);
				hmd.GetStringTrackedDeviceProperty(deviceId, prop, stringBuilder, stringTrackedDeviceProperty, ref pError);
				return stringBuilder.ToString();
			}
			if (pError == ETrackedPropertyError.TrackedProp_Success)
			{
				return "<unknown>";
			}
			return pError.ToString();
		}

		public float GetFloatProperty(ETrackedDeviceProperty prop, uint deviceId = 0u)
		{
			ETrackedPropertyError pError = ETrackedPropertyError.TrackedProp_Success;
			return hmd.GetFloatTrackedDeviceProperty(deviceId, prop, ref pError);
		}

		public static bool InitializeTemporarySession(bool initInput = false)
		{
			if (Application.isEditor)
			{
				EVRInitError peError = EVRInitError.None;
				OpenVR.GetGenericInterface("IVRCompositor_026", ref peError);
				bool flag = peError != EVRInitError.None;
				if (flag)
				{
					EVRInitError peError2 = EVRInitError.None;
					OpenVR.Init(ref peError2, EVRApplicationType.VRApplication_Overlay);
					if (peError2 != EVRInitError.None)
					{
						UnityEngine.Debug.LogError("<b>[SteamVR]</b> Error during OpenVR Init: " + peError2);
						return false;
					}
					IdentifyEditorApplication(showLogs: false);
					SteamVR_Input.IdentifyActionsFile(showLogs: false);
					runningTemporarySession = true;
				}
				if (initInput)
				{
					SteamVR_Input.Initialize(force: true);
				}
				return flag;
			}
			return false;
		}

		public static void ExitTemporarySession()
		{
			if (runningTemporarySession)
			{
				OpenVR.Shutdown();
				runningTemporarySession = false;
			}
		}

		public static string GenerateAppKey()
		{
			string arg = GenerateCleanProductName();
			return $"application.generated.unity.{arg}.exe";
		}

		public static string GenerateCleanProductName()
		{
			string productName = Application.productName;
			if (string.IsNullOrEmpty(productName))
			{
				return "unnamed_product";
			}
			productName = Regex.Replace(Application.productName, "[^\\w\\._]", "");
			return productName.ToLower();
		}

		private static string GetManifestFile()
		{
			string dataPath = Application.dataPath;
			int num = dataPath.LastIndexOf('/');
			dataPath = dataPath.Remove(num, dataPath.Length - num);
			string text = Path.Combine(dataPath, "unityProject.vrmanifest");
			FileInfo fileInfo = new FileInfo(SteamVR_Input.GetActionsFilePath());
			if (File.Exists(text))
			{
				SteamVR_Input_ManifestFile steamVR_Input_ManifestFile = JsonConvert.DeserializeObject<SteamVR_Input_ManifestFile>(File.ReadAllText(text));
				if (steamVR_Input_ManifestFile != null && steamVR_Input_ManifestFile.applications != null && steamVR_Input_ManifestFile.applications.Count > 0 && steamVR_Input_ManifestFile.applications[0].app_key != SteamVR_Settings.instance.editorAppKey)
				{
					UnityEngine.Debug.Log("<b>[SteamVR]</b> Deleting existing VRManifest because it has a different app key.");
					FileInfo fileInfo2 = new FileInfo(text);
					if (fileInfo2.IsReadOnly)
					{
						fileInfo2.IsReadOnly = false;
					}
					fileInfo2.Delete();
				}
				if (steamVR_Input_ManifestFile != null && steamVR_Input_ManifestFile.applications != null && steamVR_Input_ManifestFile.applications.Count > 0 && steamVR_Input_ManifestFile.applications[0].action_manifest_path != fileInfo.FullName)
				{
					UnityEngine.Debug.Log("<b>[SteamVR]</b> Deleting existing VRManifest because it has a different action manifest path:\nExisting:" + steamVR_Input_ManifestFile.applications[0].action_manifest_path + "\nNew: " + fileInfo.FullName);
					FileInfo fileInfo3 = new FileInfo(text);
					if (fileInfo3.IsReadOnly)
					{
						fileInfo3.IsReadOnly = false;
					}
					fileInfo3.Delete();
				}
			}
			if (!File.Exists(text))
			{
				SteamVR_Input_ManifestFile steamVR_Input_ManifestFile2 = new SteamVR_Input_ManifestFile();
				steamVR_Input_ManifestFile2.source = "Unity";
				SteamVR_Input_ManifestFile_Application item = new SteamVR_Input_ManifestFile_Application
				{
					app_key = SteamVR_Settings.instance.editorAppKey,
					action_manifest_path = fileInfo.FullName,
					launch_type = "url",
					url = "steam://launch/",
					strings = { 
					{
						"en_us",
						new SteamVR_Input_ManifestFile_ApplicationString
						{
							name = $"{Application.productName} [Testing]"
						}
					} }
				};
				steamVR_Input_ManifestFile2.applications = new List<SteamVR_Input_ManifestFile_Application>();
				steamVR_Input_ManifestFile2.applications.Add(item);
				string contents = JsonConvert.SerializeObject(steamVR_Input_ManifestFile2, Formatting.Indented, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				});
				File.WriteAllText(text, contents);
			}
			return text;
		}

		private static void IdentifyEditorApplication(bool showLogs = true)
		{
			if (string.IsNullOrEmpty(SteamVR_Settings.instance.editorAppKey))
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Critical Error identifying application. EditorAppKey is null or empty. Input may not work.");
				return;
			}
			string manifestFile = GetManifestFile();
			EVRApplicationError eVRApplicationError = OpenVR.Applications.AddApplicationManifest(manifestFile, bTemporary: true);
			if (eVRApplicationError != EVRApplicationError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Error adding vr manifest file: " + eVRApplicationError);
			}
			else if (showLogs)
			{
				UnityEngine.Debug.Log("<b>[SteamVR]</b> Successfully added VR manifest to SteamVR");
			}
			int id = Process.GetCurrentProcess().Id;
			EVRApplicationError eVRApplicationError2 = OpenVR.Applications.IdentifyApplication((uint)id, SteamVR_Settings.instance.editorAppKey);
			if (eVRApplicationError2 != EVRApplicationError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Error identifying application: " + eVRApplicationError2);
			}
			else if (showLogs)
			{
				UnityEngine.Debug.Log($"<b>[SteamVR]</b> Successfully identified process as editor project to SteamVR ({SteamVR_Settings.instance.editorAppKey})");
			}
		}

		private void OnInitializing(bool initializing)
		{
			SteamVR.initializing = initializing;
		}

		private void OnCalibrating(bool calibrating)
		{
			SteamVR.calibrating = calibrating;
		}

		private void OnOutOfRange(bool outOfRange)
		{
			SteamVR.outOfRange = outOfRange;
		}

		private void OnDeviceConnected(int i, bool connected)
		{
			SteamVR.connected[i] = connected;
		}

		private void OnNewPoses(TrackedDevicePose_t[] poses)
		{
			eyes[0] = new SteamVR_Utils.RigidTransform(hmd.GetEyeToHeadTransform(EVREye.Eye_Left));
			eyes[1] = new SteamVR_Utils.RigidTransform(hmd.GetEyeToHeadTransform(EVREye.Eye_Right));
			for (int i = 0; i < poses.Length; i++)
			{
				bool bDeviceIsConnected = poses[i].bDeviceIsConnected;
				if (bDeviceIsConnected != connected[i])
				{
					SteamVR_Events.DeviceConnected.Send(i, bDeviceIsConnected);
				}
			}
			if ((long)poses.Length > 0L)
			{
				ETrackingResult eTrackingResult = poses[0].eTrackingResult;
				bool flag = eTrackingResult == ETrackingResult.Uninitialized;
				if (flag != initializing)
				{
					SteamVR_Events.Initializing.Send(flag);
				}
				bool flag2 = eTrackingResult == ETrackingResult.Calibrating_InProgress || eTrackingResult == ETrackingResult.Calibrating_OutOfRange;
				if (flag2 != calibrating)
				{
					SteamVR_Events.Calibrating.Send(flag2);
				}
				bool flag3 = eTrackingResult == ETrackingResult.Running_OutOfRange || eTrackingResult == ETrackingResult.Calibrating_OutOfRange;
				if (flag3 != outOfRange)
				{
					SteamVR_Events.OutOfRange.Send(flag3);
				}
			}
		}

		private SteamVR()
		{
			hmd = OpenVR.System;
			UnityEngine.Debug.LogFormat("<b>[SteamVR]</b> Initialized. Connected to {0} : {1} : {2} :: {3}", hmd_TrackingSystemName, hmd_ModelNumber, hmd_SerialNumber, hmd_Type);
			compositor = OpenVR.Compositor;
			overlay = OpenVR.Overlay;
			uint pnWidth = 0u;
			uint pnHeight = 0u;
			hmd.GetRecommendedRenderTargetSize(ref pnWidth, ref pnHeight);
			sceneWidth = pnWidth;
			sceneHeight = pnHeight;
			float pfLeft = 0f;
			float pfRight = 0f;
			float pfTop = 0f;
			float pfBottom = 0f;
			hmd.GetProjectionRaw(EVREye.Eye_Left, ref pfLeft, ref pfRight, ref pfTop, ref pfBottom);
			float pfLeft2 = 0f;
			float pfRight2 = 0f;
			float pfTop2 = 0f;
			float pfBottom2 = 0f;
			hmd.GetProjectionRaw(EVREye.Eye_Right, ref pfLeft2, ref pfRight2, ref pfTop2, ref pfBottom2);
			tanHalfFov = new Vector2(Mathf.Max(0f - pfLeft, pfRight, 0f - pfLeft2, pfRight2), Mathf.Max(0f - pfTop, pfBottom, 0f - pfTop2, pfBottom2));
			textureBounds = new VRTextureBounds_t[2];
			textureBounds[0].uMin = 0.5f + 0.5f * pfLeft / tanHalfFov.x;
			textureBounds[0].uMax = 0.5f + 0.5f * pfRight / tanHalfFov.x;
			textureBounds[0].vMin = 0.5f - 0.5f * pfBottom / tanHalfFov.y;
			textureBounds[0].vMax = 0.5f - 0.5f * pfTop / tanHalfFov.y;
			textureBounds[1].uMin = 0.5f + 0.5f * pfLeft2 / tanHalfFov.x;
			textureBounds[1].uMax = 0.5f + 0.5f * pfRight2 / tanHalfFov.x;
			textureBounds[1].vMin = 0.5f - 0.5f * pfBottom2 / tanHalfFov.y;
			textureBounds[1].vMax = 0.5f - 0.5f * pfTop2 / tanHalfFov.y;
			sceneWidth /= Mathf.Max(textureBounds[0].uMax - textureBounds[0].uMin, textureBounds[1].uMax - textureBounds[1].uMin);
			sceneHeight /= Mathf.Max(textureBounds[0].vMax - textureBounds[0].vMin, textureBounds[1].vMax - textureBounds[1].vMin);
			aspect = tanHalfFov.x / tanHalfFov.y;
			fieldOfView = 2f * Mathf.Atan(tanHalfFov.y) * 57.29578f;
			eyes = new SteamVR_Utils.RigidTransform[2]
			{
				new SteamVR_Utils.RigidTransform(hmd.GetEyeToHeadTransform(EVREye.Eye_Left)),
				new SteamVR_Utils.RigidTransform(hmd.GetEyeToHeadTransform(EVREye.Eye_Right))
			};
			switch (SystemInfo.graphicsDeviceType)
			{
			case GraphicsDeviceType.OpenGLES2:
			case GraphicsDeviceType.OpenGLES3:
			case GraphicsDeviceType.OpenGLCore:
				textureType = ETextureType.OpenGL;
				break;
			case GraphicsDeviceType.Vulkan:
				textureType = ETextureType.Vulkan;
				break;
			default:
				textureType = ETextureType.DirectX;
				break;
			}
			SteamVR_Events.Initializing.Listen(OnInitializing);
			SteamVR_Events.Calibrating.Listen(OnCalibrating);
			SteamVR_Events.OutOfRange.Listen(OnOutOfRange);
			SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
			SteamVR_Events.NewPoses.Listen(OnNewPoses);
		}

		~SteamVR()
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
			SteamVR_Events.Initializing.Remove(OnInitializing);
			SteamVR_Events.Calibrating.Remove(OnCalibrating);
			SteamVR_Events.OutOfRange.Remove(OnOutOfRange);
			SteamVR_Events.DeviceConnected.Remove(OnDeviceConnected);
			SteamVR_Events.NewPoses.Remove(OnNewPoses);
			_instance = null;
		}

		public static void SafeDispose()
		{
			if (_instance != null)
			{
				_instance.Dispose();
			}
		}
	}
	public class SteamVR_Behaviour : MonoBehaviour
	{
		private const string openVRDeviceName = "OpenVR";

		public static bool forcingInitialization = false;

		private static SteamVR_Behaviour _instance;

		public bool initializeSteamVROnAwake = true;

		public bool doNotDestroy = true;

		[HideInInspector]
		public SteamVR_Render steamvr_render;

		internal static bool isPlaying = false;

		private static bool initializing = false;

		private Coroutine initializeCoroutine;

		private bool loadedOpenVRDeviceSuccess;

		protected static int lastFrameCount = -1;

		public static SteamVR_Behaviour instance
		{
			get
			{
				if (_instance == null)
				{
					Initialize();
				}
				return _instance;
			}
		}

		public static void Initialize(bool forceUnityVRToOpenVR = false)
		{
			if (!(_instance == null) || initializing)
			{
				return;
			}
			initializing = true;
			GameObject gameObject = null;
			if (forceUnityVRToOpenVR)
			{
				forcingInitialization = true;
			}
			SteamVR_Render steamVR_Render = UnityEngine.Object.FindObjectOfType<SteamVR_Render>();
			if (steamVR_Render != null)
			{
				gameObject = steamVR_Render.gameObject;
			}
			SteamVR_Behaviour steamVR_Behaviour = UnityEngine.Object.FindObjectOfType<SteamVR_Behaviour>();
			if (steamVR_Behaviour != null)
			{
				gameObject = steamVR_Behaviour.gameObject;
			}
			if (gameObject == null)
			{
				GameObject gameObject2 = new GameObject("[SteamVR]");
				_instance = gameObject2.AddComponent<SteamVR_Behaviour>();
				_instance.steamvr_render = gameObject2.AddComponent<SteamVR_Render>();
			}
			else
			{
				steamVR_Behaviour = gameObject.GetComponent<SteamVR_Behaviour>();
				if (steamVR_Behaviour == null)
				{
					steamVR_Behaviour = gameObject.AddComponent<SteamVR_Behaviour>();
				}
				if (steamVR_Render != null)
				{
					steamVR_Behaviour.steamvr_render = steamVR_Render;
				}
				else
				{
					steamVR_Behaviour.steamvr_render = gameObject.GetComponent<SteamVR_Render>();
					if (steamVR_Behaviour.steamvr_render == null)
					{
						steamVR_Behaviour.steamvr_render = gameObject.AddComponent<SteamVR_Render>();
					}
				}
				_instance = steamVR_Behaviour;
			}
			if (_instance != null && _instance.doNotDestroy)
			{
				UnityEngine.Object.DontDestroyOnLoad(_instance.transform.root.gameObject);
			}
			initializing = false;
		}

		protected void Awake()
		{
			isPlaying = true;
			if (initializeSteamVROnAwake && !forcingInitialization)
			{
				InitializeSteamVR();
			}
		}

		public void InitializeSteamVR(bool forceUnityVRToOpenVR = false)
		{
			if (forceUnityVRToOpenVR)
			{
				forcingInitialization = true;
				if (initializeCoroutine != null)
				{
					StopCoroutine(initializeCoroutine);
				}
				if (XRSettings.loadedDeviceName == "OpenVR")
				{
					EnableOpenVR();
				}
				else
				{
					initializeCoroutine = StartCoroutine(DoInitializeSteamVR(forceUnityVRToOpenVR));
				}
			}
			else
			{
				SteamVR.Initialize();
			}
		}

		private IEnumerator DoInitializeSteamVR(bool forceUnityVRToOpenVR = false)
		{
			XRDevice.deviceLoaded += XRDevice_deviceLoaded;
			XRSettings.LoadDeviceByName("OpenVR");
			while (!loadedOpenVRDeviceSuccess)
			{
				yield return null;
			}
			XRDevice.deviceLoaded -= XRDevice_deviceLoaded;
			EnableOpenVR();
		}

		private void XRDevice_deviceLoaded(string deviceName)
		{
			if (deviceName == "OpenVR")
			{
				loadedOpenVRDeviceSuccess = true;
				return;
			}
			UnityEngine.Debug.LogError("<b>[SteamVR]</b> Tried to async load: OpenVR. Loaded: " + deviceName, this);
			loadedOpenVRDeviceSuccess = true;
		}

		private void EnableOpenVR()
		{
			XRSettings.enabled = true;
			SteamVR.Initialize();
			initializeCoroutine = null;
			forcingInitialization = false;
		}

		protected void OnEnable()
		{
			Application.onBeforeRender += OnBeforeRender;
			SteamVR_Events.System(EVREventType.VREvent_Quit).Listen(OnQuit);
		}

		protected void OnDisable()
		{
			Application.onBeforeRender -= OnBeforeRender;
			SteamVR_Events.System(EVREventType.VREvent_Quit).Remove(OnQuit);
		}

		protected void OnBeforeRender()
		{
			PreCull();
		}

		protected void PreCull()
		{
			if (OpenVR.Input != null && Time.frameCount != lastFrameCount)
			{
				lastFrameCount = Time.frameCount;
				SteamVR_Input.OnPreCull();
			}
		}

		protected void FixedUpdate()
		{
			if (OpenVR.Input != null)
			{
				SteamVR_Input.FixedUpdate();
			}
		}

		protected void LateUpdate()
		{
			if (OpenVR.Input != null)
			{
				SteamVR_Input.LateUpdate();
			}
		}

		protected void Update()
		{
			if (OpenVR.Input != null)
			{
				SteamVR_Input.Update();
			}
		}

		protected void OnQuit(VREvent_t vrEvent)
		{
			Application.Quit();
		}
	}
	[RequireComponent(typeof(Camera))]
	public class SteamVR_Camera : MonoBehaviour
	{
		[SerializeField]
		private Transform _head;

		[SerializeField]
		private Transform _ears;

		public bool wireframe;

		private static Hashtable values;

		private const string eyeSuffix = " (eye)";

		private const string earsSuffix = " (ears)";

		private const string headSuffix = " (head)";

		private const string originSuffix = " (origin)";

		public Transform head => _head;

		public Transform offset => _head;

		public Transform origin => _head.parent;

		public Camera camera { get; private set; }

		public Transform ears => _ears;

		public static float sceneResolutionScale
		{
			get
			{
				return XRSettings.eyeTextureResolutionScale;
			}
			set
			{
				XRSettings.eyeTextureResolutionScale = value;
			}
		}

		public string baseName
		{
			get
			{
				if (!base.name.EndsWith(" (eye)"))
				{
					return base.name;
				}
				return base.name.Substring(0, base.name.Length - " (eye)".Length);
			}
		}

		public Ray GetRay()
		{
			return new Ray(_head.position, _head.forward);
		}

		private void OnDisable()
		{
			SteamVR_Render.Remove(this);
		}

		private void OnEnable()
		{
			if (SteamVR.instance == null)
			{
				if (head != null)
				{
					head.GetComponent<SteamVR_TrackedObject>().enabled = false;
				}
				base.enabled = false;
				return;
			}
			Transform transform = base.transform;
			if (head != transform)
			{
				Expand();
				transform.parent = origin;
				while (head.childCount > 0)
				{
					head.GetChild(0).parent = transform;
				}
				head.parent = transform;
				head.localPosition = Vector3.zero;
				head.localRotation = Quaternion.identity;
				head.localScale = Vector3.one;
				head.gameObject.SetActive(value: false);
				_head = transform;
			}
			if (ears == null)
			{
				SteamVR_Ears componentInChildren = base.transform.GetComponentInChildren<SteamVR_Ears>();
				if (componentInChildren != null)
				{
					_ears = componentInChildren.transform;
				}
			}
			if (ears != null)
			{
				ears.GetComponent<SteamVR_Ears>().vrcam = this;
			}
			SteamVR_Render.Add(this);
		}

		private void Awake()
		{
			camera = GetComponent<Camera>();
			ForceLast();
		}

		public void ForceLast()
		{
			if (values != null)
			{
				foreach (DictionaryEntry value in values)
				{
					(value.Key as FieldInfo).SetValue(this, value.Value);
				}
				values = null;
				return;
			}
			UnityEngine.Component[] components = GetComponents<UnityEngine.Component>();
			for (int i = 0; i < components.Length; i++)
			{
				SteamVR_Camera steamVR_Camera = components[i] as SteamVR_Camera;
				if (steamVR_Camera != null && steamVR_Camera != this)
				{
					UnityEngine.Object.DestroyImmediate(steamVR_Camera);
				}
			}
			if (!(this != GetComponents<UnityEngine.Component>()[^1]))
			{
				return;
			}
			values = new Hashtable();
			FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeField), inherit: true))
				{
					values[fieldInfo] = fieldInfo.GetValue(this);
				}
			}
			GameObject obj = base.gameObject;
			UnityEngine.Object.DestroyImmediate(this);
			obj.AddComponent<SteamVR_Camera>().ForceLast();
		}

		public void Expand()
		{
			Transform parent = base.transform.parent;
			if (parent == null)
			{
				parent = new GameObject(base.name + " (origin)").transform;
				parent.localPosition = base.transform.localPosition;
				parent.localRotation = base.transform.localRotation;
				parent.localScale = base.transform.localScale;
			}
			if (head == null)
			{
				_head = new GameObject(base.name + " (head)", typeof(SteamVR_TrackedObject)).transform;
				head.parent = parent;
				head.position = base.transform.position;
				head.rotation = base.transform.rotation;
				head.localScale = Vector3.one;
				head.tag = base.tag;
			}
			if (base.transform.parent != head)
			{
				base.transform.parent = head;
				base.transform.localPosition = Vector3.zero;
				base.transform.localRotation = Quaternion.identity;
				base.transform.localScale = Vector3.one;
				while (base.transform.childCount > 0)
				{
					base.transform.GetChild(0).parent = head;
				}
				AudioListener component = GetComponent<AudioListener>();
				if (component != null)
				{
					UnityEngine.Object.DestroyImmediate(component);
					_ears = new GameObject(base.name + " (ears)", typeof(SteamVR_Ears)).transform;
					ears.parent = _head;
					ears.localPosition = Vector3.zero;
					ears.localRotation = Quaternion.identity;
					ears.localScale = Vector3.one;
				}
			}
			if (!base.name.EndsWith(" (eye)"))
			{
				base.name += " (eye)";
			}
		}

		public void Collapse()
		{
			base.transform.parent = null;
			while (head.childCount > 0)
			{
				head.GetChild(0).parent = base.transform;
			}
			if (ears != null)
			{
				while (ears.childCount > 0)
				{
					ears.GetChild(0).parent = base.transform;
				}
				UnityEngine.Object.DestroyImmediate(ears.gameObject);
				_ears = null;
				base.gameObject.AddComponent(typeof(AudioListener));
			}
			if (origin != null)
			{
				if (origin.name.EndsWith(" (origin)"))
				{
					Transform transform = origin;
					while (transform.childCount > 0)
					{
						transform.GetChild(0).parent = transform.parent;
					}
					UnityEngine.Object.DestroyImmediate(transform.gameObject);
				}
				else
				{
					base.transform.parent = origin;
				}
			}
			UnityEngine.Object.DestroyImmediate(head.gameObject);
			_head = null;
			if (base.name.EndsWith(" (eye)"))
			{
				base.name = base.name.Substring(0, base.name.Length - " (eye)".Length);
			}
		}
	}
	[ExecuteInEditMode]
	public class SteamVR_CameraFlip : MonoBehaviour
	{
		private void Awake()
		{
			UnityEngine.Debug.Log("<b>[SteamVR]</b> SteamVR_CameraFlip is deprecated in Unity 5.4 - REMOVING");
			UnityEngine.Object.DestroyImmediate(this);
		}
	}
	[ExecuteInEditMode]
	public class SteamVR_CameraMask : MonoBehaviour
	{
		private void Awake()
		{
			UnityEngine.Debug.Log("<b>[SteamVR]</b> SteamVR_CameraMask is deprecated in Unity 5.4 - REMOVING");
			UnityEngine.Object.DestroyImmediate(this);
		}
	}
	[RequireComponent(typeof(AudioListener))]
	public class SteamVR_Ears : MonoBehaviour
	{
		public SteamVR_Camera vrcam;

		private bool usingSpeakers;

		private Quaternion offset;

		private void OnNewPosesApplied()
		{
			Transform origin = vrcam.origin;
			Quaternion quaternion = ((origin != null) ? origin.rotation : Quaternion.identity);
			base.transform.rotation = quaternion * offset;
		}

		private void OnEnable()
		{
			usingSpeakers = false;
			CVRSettings settings = OpenVR.Settings;
			if (settings != null)
			{
				EVRSettingsError peError = EVRSettingsError.None;
				if (settings.GetBool("steamvr", "usingSpeakers", ref peError))
				{
					usingSpeakers = true;
					float y = settings.GetFloat("steamvr", "speakersForwardYawOffsetDegrees", ref peError);
					offset = Quaternion.Euler(0f, y, 0f);
				}
			}
			if (usingSpeakers)
			{
				SteamVR_Events.NewPosesApplied.Listen(OnNewPosesApplied);
			}
		}

		private void OnDisable()
		{
			if (usingSpeakers)
			{
				SteamVR_Events.NewPosesApplied.Remove(OnNewPosesApplied);
			}
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct SteamVREnumEqualityComparer<TEnum> : IEqualityComparer<TEnum> where TEnum : struct
	{
		private static class BoxAvoidance
		{
			private static readonly Func<TEnum, int> _wrapper;

			public static int ToInt(TEnum enu)
			{
				return _wrapper(enu);
			}

			static BoxAvoidance()
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TEnum), null);
				_wrapper = Expression.Lambda<Func<TEnum, int>>(Expression.ConvertChecked(parameterExpression, typeof(int)), new ParameterExpression[1] { parameterExpression }).Compile();
			}
		}

		public bool Equals(TEnum firstEnum, TEnum secondEnum)
		{
			return BoxAvoidance.ToInt(firstEnum) == BoxAvoidance.ToInt(secondEnum);
		}

		public int GetHashCode(TEnum firstEnum)
		{
			return BoxAvoidance.ToInt(firstEnum);
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct SteamVR_Input_Sources_Comparer : IEqualityComparer<SteamVR_Input_Sources>
	{
		public bool Equals(SteamVR_Input_Sources x, SteamVR_Input_Sources y)
		{
			return x == y;
		}

		public int GetHashCode(SteamVR_Input_Sources obj)
		{
			return (int)obj;
		}
	}
	public static class SteamVR_Events
	{
		public abstract class Action
		{
			public bool enabled
			{
				set
				{
					Enable(value);
				}
			}

			public abstract void Enable(bool enabled);
		}

		[Serializable]
		public class ActionNoArgs : Action
		{
			private Event _event;

			private UnityAction action;

			public ActionNoArgs(Event _event, UnityAction action)
			{
				this._event = _event;
				this.action = action;
			}

			public override void Enable(bool enabled)
			{
				if (enabled)
				{
					_event.Listen(action);
				}
				else
				{
					_event.Remove(action);
				}
			}
		}

		[Serializable]
		public class Action<T> : Action
		{
			private Event<T> _event;

			private UnityAction<T> action;

			public Action(Event<T> _event, UnityAction<T> action)
			{
				this._event = _event;
				this.action = action;
			}

			public override void Enable(bool enabled)
			{
				if (enabled)
				{
					_event.Listen(action);
				}
				else
				{
					_event.Remove(action);
				}
			}
		}

		[Serializable]
		public class Action<T0, T1> : Action
		{
			private Event<T0, T1> _event;

			private UnityAction<T0, T1> action;

			public Action(Event<T0, T1> _event, UnityAction<T0, T1> action)
			{
				this._event = _event;
				this.action = action;
			}

			public override void Enable(bool enabled)
			{
				if (enabled)
				{
					_event.Listen(action);
				}
				else
				{
					_event.Remove(action);
				}
			}
		}

		[Serializable]
		public class Action<T0, T1, T2> : Action
		{
			private Event<T0, T1, T2> _event;

			private UnityAction<T0, T1, T2> action;

			public Action(Event<T0, T1, T2> _event, UnityAction<T0, T1, T2> action)
			{
				this._event = _event;
				this.action = action;
			}

			public override void Enable(bool enabled)
			{
				if (enabled)
				{
					_event.Listen(action);
				}
				else
				{
					_event.Remove(action);
				}
			}
		}

		public class Event : UnityEvent
		{
			public void Listen(UnityAction action)
			{
				AddListener(action);
			}

			public void Remove(UnityAction action)
			{
				RemoveListener(action);
			}

			public void Send()
			{
				Invoke();
			}
		}

		public class Event<T> : UnityEvent<T>
		{
			public void Listen(UnityAction<T> action)
			{
				AddListener(action);
			}

			public void Remove(UnityAction<T> action)
			{
				RemoveListener(action);
			}

			public void Send(T arg0)
			{
				Invoke(arg0);
			}
		}

		public class Event<T0, T1> : UnityEvent<T0, T1>
		{
			public void Listen(UnityAction<T0, T1> action)
			{
				AddListener(action);
			}

			public void Remove(UnityAction<T0, T1> action)
			{
				RemoveListener(action);
			}

			public void Send(T0 arg0, T1 arg1)
			{
				Invoke(arg0, arg1);
			}
		}

		public class Event<T0, T1, T2> : UnityEvent<T0, T1, T2>
		{
			public void Listen(UnityAction<T0, T1, T2> action)
			{
				AddListener(action);
			}

			public void Remove(UnityAction<T0, T1, T2> action)
			{
				RemoveListener(action);
			}

			public void Send(T0 arg0, T1 arg1, T2 arg2)
			{
				Invoke(arg0, arg1, arg2);
			}
		}

		public static Event<bool> Calibrating = new Event<bool>();

		public static Event<int, bool> DeviceConnected = new Event<int, bool>();

		public static Event<Color, float, bool> Fade = new Event<Color, float, bool>();

		public static Event FadeReady = new Event();

		public static Event<bool> HideRenderModels = new Event<bool>();

		public static Event<bool> Initializing = new Event<bool>();

		public static Event<bool> InputFocus = new Event<bool>();

		public static Event<bool> Loading = new Event<bool>();

		public static Event<float> LoadingFadeIn = new Event<float>();

		public static Event<float> LoadingFadeOut = new Event<float>();

		public static Event<TrackedDevicePose_t[]> NewPoses = new Event<TrackedDevicePose_t[]>();

		public static Event NewPosesApplied = new Event();

		public static Event<bool> Initialized = new Event<bool>();

		public static Event<bool> OutOfRange = new Event<bool>();

		public static Event<SteamVR_RenderModel, bool> RenderModelLoaded = new Event<SteamVR_RenderModel, bool>();

		private static Dictionary<EVREventType, Event<VREvent_t>> systemEvents = new Dictionary<EVREventType, Event<VREvent_t>>();

		public static Action CalibratingAction(UnityAction<bool> action)
		{
			return new Action<bool>(Calibrating, action);
		}

		public static Action DeviceConnectedAction(UnityAction<int, bool> action)
		{
			return new Action<int, bool>(DeviceConnected, action);
		}

		public static Action FadeAction(UnityAction<Color, float, bool> action)
		{
			return new Action<Color, float, bool>(Fade, action);
		}

		public static Action FadeReadyAction(UnityAction action)
		{
			return new ActionNoArgs(FadeReady, action);
		}

		public static Action HideRenderModelsAction(UnityAction<bool> action)
		{
			return new Action<bool>(HideRenderModels, action);
		}

		public static Action InitializingAction(UnityAction<bool> action)
		{
			return new Action<bool>(Initializing, action);
		}

		public static Action InputFocusAction(UnityAction<bool> action)
		{
			return new Action<bool>(InputFocus, action);
		}

		public static Action LoadingAction(UnityAction<bool> action)
		{
			return new Action<bool>(Loading, action);
		}

		public static Action LoadingFadeInAction(UnityAction<float> action)
		{
			return new Action<float>(LoadingFadeIn, action);
		}

		public static Action LoadingFadeOutAction(UnityAction<float> action)
		{
			return new Action<float>(LoadingFadeOut, action);
		}

		public static Action NewPosesAction(UnityAction<TrackedDevicePose_t[]> action)
		{
			return new Action<TrackedDevicePose_t[]>(NewPoses, action);
		}

		public static Action NewPosesAppliedAction(UnityAction action)
		{
			return new ActionNoArgs(NewPosesApplied, action);
		}

		public static Action InitializedAction(UnityAction<bool> action)
		{
			return new Action<bool>(Initialized, action);
		}

		public static Action OutOfRangeAction(UnityAction<bool> action)
		{
			return new Action<bool>(OutOfRange, action);
		}

		public static Action RenderModelLoadedAction(UnityAction<SteamVR_RenderModel, bool> action)
		{
			return new Action<SteamVR_RenderModel, bool>(RenderModelLoaded, action);
		}

		public static Event<VREvent_t> System(EVREventType eventType)
		{
			if (!systemEvents.TryGetValue(eventType, out var value))
			{
				value = new Event<VREvent_t>();
				systemEvents.Add(eventType, value);
			}
			return value;
		}

		public static Action SystemAction(EVREventType eventType, UnityAction<VREvent_t> action)
		{
			return new Action<VREvent_t>(System(eventType), action);
		}
	}
	public class SteamVR_ExternalCamera : MonoBehaviour
	{
		[Serializable]
		public struct Config
		{
			public float x;

			public float y;

			public float z;

			public float rx;

			public float ry;

			public float rz;

			public float fov;

			public float near;

			public float far;

			public float sceneResolutionScale;

			public float frameSkip;

			public float nearOffset;

			public float farOffset;

			public float hmdOffset;

			public float r;

			public float g;

			public float b;

			public float a;

			public bool disableStandardAssets;
		}

		private SteamVR_Action_Pose cameraPose;

		private SteamVR_Input_Sources cameraInputSource = SteamVR_Input_Sources.Camera;

		[Space]
		public Config config;

		public string configPath;

		[Tooltip("This will automatically activate the action set the specified pose belongs to. And deactivate it when this component is disabled.")]
		public bool autoEnableDisableActionSet = true;

		private FileSystemWatcher watcher;

		private Camera cam;

		private Transform target;

		private GameObject clipQuad;

		private Material clipMaterial;

		protected SteamVR_ActionSet activatedActionSet;

		protected SteamVR_Input_Sources activatedInputSource;

		private Material colorMat;

		private Material alphaMat;

		private Camera[] cameras;

		private Rect[] cameraRects;

		private float sceneResolutionScale;

		public void ReadConfig()
		{
			try
			{
				HmdMatrix34_t pose = default(HmdMatrix34_t);
				bool flag = false;
				object obj = config;
				string[] array = File.ReadAllLines(configPath);
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split('=');
					if (array2.Length != 2)
					{
						continue;
					}
					string text = array2[0];
					if (text == "m")
					{
						string[] array3 = array2[1].Split(',');
						if (array3.Length == 12)
						{
							pose.m0 = float.Parse(array3[0]);
							pose.m1 = float.Parse(array3[1]);
							pose.m2 = float.Parse(array3[2]);
							pose.m3 = float.Parse(array3[3]);
							pose.m4 = float.Parse(array3[4]);
							pose.m5 = float.Parse(array3[5]);
							pose.m6 = float.Parse(array3[6]);
							pose.m7 = float.Parse(array3[7]);
							pose.m8 = float.Parse(array3[8]);
							pose.m9 = float.Parse(array3[9]);
							pose.m10 = float.Parse(array3[10]);
							pose.m11 = float.Parse(array3[11]);
							flag = true;
						}
					}
					else if (text == "disableStandardAssets")
					{
						FieldInfo field = obj.GetType().GetField(text);
						if (field != null)
						{
							field.SetValue(obj, bool.Parse(array2[1]));
						}
					}
					else
					{
						FieldInfo field2 = obj.GetType().GetField(text);
						if (field2 != null)
						{
							field2.SetValue(obj, float.Parse(array2[1]));
						}
					}
				}
				config = (Config)obj;
				if (flag)
				{
					SteamVR_Utils.RigidTransform rigidTransform = new SteamVR_Utils.RigidTransform(pose);
					config.x = rigidTransform.pos.x;
					config.y = rigidTransform.pos.y;
					config.z = rigidTransform.pos.z;
					Vector3 eulerAngles = rigidTransform.rot.eulerAngles;
					config.rx = eulerAngles.x;
					config.ry = eulerAngles.y;
					config.rz = eulerAngles.z;
				}
			}
			catch
			{
			}
			target = null;
			if (watcher == null)
			{
				FileInfo fileInfo = new FileInfo(configPath);
				watcher = new FileSystemWatcher(fileInfo.DirectoryName, fileInfo.Name);
				watcher.NotifyFilter = NotifyFilters.LastWrite;
				watcher.Changed += OnChanged;
				watcher.EnableRaisingEvents = true;
			}
		}

		public void SetupPose(SteamVR_Action_Pose newCameraPose, SteamVR_Input_Sources newCameraSource)
		{
			cameraPose = newCameraPose;
			cameraInputSource = newCameraSource;
			AutoEnableActionSet();
			SteamVR_Behaviour_Pose steamVR_Behaviour_Pose = base.gameObject.AddComponent<SteamVR_Behaviour_Pose>();
			steamVR_Behaviour_Pose.poseAction = newCameraPose;
			steamVR_Behaviour_Pose.inputSource = newCameraSource;
		}

		public void SetupDeviceIndex(int deviceIndex)
		{
			base.gameObject.AddComponent<SteamVR_TrackedObject>().SetDeviceIndex(deviceIndex);
		}

		private void OnChanged(object source, FileSystemEventArgs e)
		{
			ReadConfig();
		}

		public void AttachToCamera(SteamVR_Camera steamVR_Camera)
		{
			Camera camera;
			if (steamVR_Camera == null)
			{
				camera = Camera.main;
				if (target == camera.transform)
				{
					return;
				}
				target = camera.transform;
			}
			else
			{
				camera = steamVR_Camera.camera;
				if (target == steamVR_Camera.head)
				{
					return;
				}
				target = steamVR_Camera.head;
			}
			Transform parent = base.transform.parent;
			Transform parent2 = target.parent;
			parent.parent = parent2;
			parent.localPosition = Vector3.zero;
			parent.localRotation = Quaternion.identity;
			parent.localScale = Vector3.one;
			camera.enabled = false;
			GameObject gameObject = UnityEngine.Object.Instantiate(camera.gameObject);
			camera.enabled = true;
			gameObject.name = "camera";
			UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<SteamVR_Camera>());
			UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<SteamVR_Fade>());
			cam = gameObject.GetComponent<Camera>();
			cam.stereoTargetEye = StereoTargetEyeMask.None;
			cam.fieldOfView = config.fov;
			cam.useOcclusionCulling = false;
			cam.enabled = false;
			cam.rect = new Rect(0f, 0f, 1f, 1f);
			colorMat = new Material(Shader.Find("Custom/SteamVR_ColorOut"));
			alphaMat = new Material(Shader.Find("Custom/SteamVR_AlphaOut"));
			clipMaterial = new Material(Shader.Find("Custom/SteamVR_ClearAll"));
			Transform transform = gameObject.transform;
			transform.parent = base.transform;
			transform.localPosition = new Vector3(config.x, config.y, config.z);
			transform.localRotation = Quaternion.Euler(config.rx, config.ry, config.rz);
			transform.localScale = Vector3.one;
			while (transform.childCount > 0)
			{
				UnityEngine.Object.DestroyImmediate(transform.GetChild(0).gameObject);
			}
			clipQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);
			clipQuad.name = "ClipQuad";
			UnityEngine.Object.DestroyImmediate(clipQuad.GetComponent<MeshCollider>());
			MeshRenderer component = clipQuad.GetComponent<MeshRenderer>();
			component.material = clipMaterial;
			component.shadowCastingMode = ShadowCastingMode.Off;
			component.receiveShadows = false;
			component.lightProbeUsage = LightProbeUsage.Off;
			component.reflectionProbeUsage = ReflectionProbeUsage.Off;
			Transform obj = clipQuad.transform;
			obj.parent = transform;
			obj.localScale = new Vector3(1000f, 1000f, 1f);
			obj.localRotation = Quaternion.identity;
			clipQuad.SetActive(value: false);
		}

		public float GetTargetDistance()
		{
			if (target == null)
			{
				return config.near + 0.01f;
			}
			Transform transform = cam.transform;
			Vector3 normalized = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
			Vector3 inPoint = target.position + new Vector3(target.forward.x, 0f, target.forward.z).normalized * config.hmdOffset;
			return Mathf.Clamp(0f - new Plane(normalized, inPoint).GetDistanceToPoint(transform.position), config.near + 0.01f, config.far - 0.01f);
		}

		public void RenderNear()
		{
			int num = Screen.width / 2;
			int num2 = Screen.height / 2;
			if (cam.targetTexture == null || cam.targetTexture.width != num || cam.targetTexture.height != num2)
			{
				RenderTexture renderTexture = new RenderTexture(num, num2, 24, RenderTextureFormat.ARGB32);
				renderTexture.antiAliasing = ((QualitySettings.antiAliasing == 0) ? 1 : QualitySettings.antiAliasing);
				cam.targetTexture = renderTexture;
			}
			cam.nearClipPlane = config.near;
			cam.farClipPlane = config.far;
			CameraClearFlags clearFlags = cam.clearFlags;
			Color backgroundColor = cam.backgroundColor;
			cam.clearFlags = CameraClearFlags.Color;
			cam.backgroundColor = Color.clear;
			clipMaterial.color = new Color(config.r, config.g, config.b, config.a);
			float num3 = Mathf.Clamp(GetTargetDistance() + config.nearOffset, config.near, config.far);
			Transform parent = clipQuad.transform.parent;
			clipQuad.transform.position = parent.position + parent.forward * num3;
			MonoBehaviour[] array = null;
			bool[] array2 = null;
			if (config.disableStandardAssets)
			{
				array = cam.gameObject.GetComponents<MonoBehaviour>();
				array2 = new bool[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					MonoBehaviour monoBehaviour = array[i];
					if (monoBehaviour.enabled && monoBehaviour.GetType().ToString().StartsWith("UnityStandardAssets."))
					{
						monoBehaviour.enabled = false;
						array2[i] = true;
					}
				}
			}
			clipQuad.SetActive(value: true);
			cam.Render();
			Graphics.DrawTexture(new Rect(0f, 0f, num, num2), cam.targetTexture, colorMat);
			MonoBehaviour monoBehaviour2 = cam.gameObject.GetComponent("PostProcessingBehaviour") as MonoBehaviour;
			if (monoBehaviour2 != null && monoBehaviour2.enabled)
			{
				monoBehaviour2.enabled = false;
				cam.Render();
				monoBehaviour2.enabled = true;
			}
			Graphics.DrawTexture(new Rect(num, 0f, num, num2), cam.targetTexture, alphaMat);
			clipQuad.SetActive(value: false);
			if (array != null)
			{
				for (int j = 0; j < array.Length; j++)
				{
					if (array2[j])
					{
						array[j].enabled = true;
					}
				}
			}
			cam.clearFlags = clearFlags;
			cam.backgroundColor = backgroundColor;
		}

		public void RenderFar()
		{
			cam.nearClipPlane = config.near;
			cam.farClipPlane = config.far;
			cam.Render();
			int num = Screen.width / 2;
			int num2 = Screen.height / 2;
			Graphics.DrawTexture(new Rect(0f, num2, num, num2), cam.targetTexture, colorMat);
		}

		private void OnGUI()
		{
		}

		private void OnEnable()
		{
			cameras = UnityEngine.Object.FindObjectsOfType<Camera>();
			if (cameras != null)
			{
				int num = cameras.Length;
				cameraRects = new Rect[num];
				for (int i = 0; i < num; i++)
				{
					Camera camera = cameras[i];
					cameraRects[i] = camera.rect;
					if (!(camera == cam) && !(camera.targetTexture != null) && !(camera.GetComponent<SteamVR_Camera>() != null))
					{
						camera.rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
					}
				}
			}
			if (config.sceneResolutionScale > 0f)
			{
				sceneResolutionScale = SteamVR_Camera.sceneResolutionScale;
				SteamVR_Camera.sceneResolutionScale = config.sceneResolutionScale;
			}
			AutoEnableActionSet();
		}

		private void AutoEnableActionSet()
		{
			if (autoEnableDisableActionSet && cameraPose != null && !cameraPose.actionSet.IsActive(cameraInputSource))
			{
				activatedActionSet = cameraPose.actionSet;
				activatedInputSource = cameraInputSource;
				cameraPose.actionSet.Activate(cameraInputSource);
			}
		}

		private void OnDisable()
		{
			if (autoEnableDisableActionSet && activatedActionSet != null)
			{
				activatedActionSet.Deactivate(activatedInputSource);
				activatedActionSet = null;
			}
			if (cameras != null)
			{
				int num = cameras.Length;
				for (int i = 0; i < num; i++)
				{
					Camera camera = cameras[i];
					if (camera != null)
					{
						camera.rect = cameraRects[i];
					}
				}
				cameras = null;
				cameraRects = null;
			}
			if (config.sceneResolutionScale > 0f)
			{
				SteamVR_Camera.sceneResolutionScale = sceneResolutionScale;
			}
		}
	}
	public class SteamVR_ExternalCamera_LegacyManager
	{
		public static int cameraIndex = -1;

		private static SteamVR_Events.Action newPosesAction = null;

		public static bool hasCamera => cameraIndex != -1;

		public static void SubscribeToNewPoses()
		{
			if (newPosesAction == null)
			{
				newPosesAction = SteamVR_Events.NewPosesAction(OnNewPoses);
			}
			newPosesAction.enabled = true;
		}

		private static void OnNewPoses(TrackedDevicePose_t[] poses)
		{
			if (cameraIndex != -1)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < poses.Length; i++)
			{
				if (!poses[i].bDeviceIsConnected)
				{
					continue;
				}
				ETrackedDeviceClass trackedDeviceClass = OpenVR.System.GetTrackedDeviceClass((uint)i);
				if (trackedDeviceClass == ETrackedDeviceClass.Controller || trackedDeviceClass == ETrackedDeviceClass.GenericTracker)
				{
					num++;
					if (num >= 3)
					{
						cameraIndex = i;
						break;
					}
				}
			}
		}
	}
	public class SteamVR_Fade : MonoBehaviour
	{
		private Color currentColor = new Color(0f, 0f, 0f, 0f);

		private Color targetColor = new Color(0f, 0f, 0f, 0f);

		private Color deltaColor = new Color(0f, 0f, 0f, 0f);

		private bool fadeOverlay;

		private static Material fadeMaterial = null;

		private static int fadeMaterialColorID = -1;

		public static void Start(Color newColor, float duration, bool fadeOverlay = false)
		{
			SteamVR_Events.Fade.Send(newColor, duration, fadeOverlay);
		}

		public static void View(Color newColor, float duration)
		{
			OpenVR.Compositor?.FadeToColor(duration, newColor.r, newColor.g, newColor.b, newColor.a, bBackground: false);
		}

		public void OnStartFade(Color newColor, float duration, bool fadeOverlay)
		{
			if (duration > 0f)
			{
				targetColor = newColor;
				deltaColor = (targetColor - currentColor) / duration;
			}
			else
			{
				currentColor = newColor;
			}
		}

		private void OnEnable()
		{
			if (fadeMaterial == null)
			{
				fadeMaterial = new Material(Shader.Find("Custom/SteamVR_Fade"));
				fadeMaterialColorID = Shader.PropertyToID("fadeColor");
			}
			SteamVR_Events.Fade.Listen(OnStartFade);
			SteamVR_Events.FadeReady.Send();
		}

		private void OnDisable()
		{
			SteamVR_Events.Fade.Remove(OnStartFade);
		}

		private void OnPostRender()
		{
			if (currentColor != targetColor)
			{
				if (Mathf.Abs(currentColor.a - targetColor.a) < Mathf.Abs(deltaColor.a) * Time.deltaTime)
				{
					currentColor = targetColor;
					deltaColor = new Color(0f, 0f, 0f, 0f);
				}
				else
				{
					currentColor += deltaColor * Time.deltaTime;
				}
				if (fadeOverlay)
				{
					SteamVR_Overlay instance = SteamVR_Overlay.instance;
					if (instance != null)
					{
						instance.alpha = 1f - currentColor.a;
					}
				}
			}
			if (currentColor.a > 0f && (bool)fadeMaterial)
			{
				fadeMaterial.SetColor(fadeMaterialColorID, currentColor);
				fadeMaterial.SetPass(0);
				GL.Begin(7);
				GL.Vertex3(-1f, -1f, 0f);
				GL.Vertex3(1f, -1f, 0f);
				GL.Vertex3(1f, 1f, 0f);
				GL.Vertex3(-1f, 1f, 0f);
				GL.End();
			}
		}
	}
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class SteamVR_Frustum : MonoBehaviour
	{
		public SteamVR_TrackedObject.EIndex index;

		public float fovLeft = 45f;

		public float fovRight = 45f;

		public float fovTop = 45f;

		public float fovBottom = 45f;

		public float nearZ = 0.5f;

		public float farZ = 2.5f;

		public void UpdateModel()
		{
			fovLeft = Mathf.Clamp(fovLeft, 1f, 89f);
			fovRight = Mathf.Clamp(fovRight, 1f, 89f);
			fovTop = Mathf.Clamp(fovTop, 1f, 89f);
			fovBottom = Mathf.Clamp(fovBottom, 1f, 89f);
			farZ = Mathf.Max(farZ, nearZ + 0.01f);
			nearZ = Mathf.Clamp(nearZ, 0.01f, farZ - 0.01f);
			float num = Mathf.Sin((0f - fovLeft) * (MathF.PI / 180f));
			float num2 = Mathf.Sin(fovRight * (MathF.PI / 180f));
			float num3 = Mathf.Sin(fovTop * (MathF.PI / 180f));
			float num4 = Mathf.Sin((0f - fovBottom) * (MathF.PI / 180f));
			float num5 = Mathf.Cos((0f - fovLeft) * (MathF.PI / 180f));
			float num6 = Mathf.Cos(fovRight * (MathF.PI / 180f));
			float num7 = Mathf.Cos(fovTop * (MathF.PI / 180f));
			float num8 = Mathf.Cos((0f - fovBottom) * (MathF.PI / 180f));
			Vector3[] array = new Vector3[8]
			{
				new Vector3(num * nearZ / num5, num3 * nearZ / num7, nearZ),
				new Vector3(num2 * nearZ / num6, num3 * nearZ / num7, nearZ),
				new Vector3(num2 * nearZ / num6, num4 * nearZ / num8, nearZ),
				new Vector3(num * nearZ / num5, num4 * nearZ / num8, nearZ),
				new Vector3(num * farZ / num5, num3 * farZ / num7, farZ),
				new Vector3(num2 * farZ / num6, num3 * farZ / num7, farZ),
				new Vector3(num2 * farZ / num6, num4 * farZ / num8, farZ),
				new Vector3(num * farZ / num5, num4 * farZ / num8, farZ)
			};
			int[] array2 = new int[48]
			{
				0, 4, 7, 0, 7, 3, 0, 7, 4, 0,
				3, 7, 1, 5, 6, 1, 6, 2, 1, 6,
				5, 1, 2, 6, 0, 4, 5, 0, 5, 1,
				0, 5, 4, 0, 1, 5, 2, 3, 7, 2,
				7, 6, 2, 7, 3, 2, 6, 7
			};
			int num9 = 0;
			Vector3[] array3 = new Vector3[array2.Length];
			Vector3[] array4 = new Vector3[array2.Length];
			for (int i = 0; i < array2.Length / 3; i++)
			{
				Vector3 vector = array[array2[i * 3]];
				Vector3 vector2 = array[array2[i * 3 + 1]];
				Vector3 vector3 = array[array2[i * 3 + 2]];
				array4[i * 3 + 2] = (array4[i * 3 + 1] = (array4[i * 3] = Vector3.Cross(vector2 - vector, vector3 - vector).normalized));
				array3[i * 3] = vector;
				array3[i * 3 + 1] = vector2;
				array3[i * 3 + 2] = vector3;
				array2[i * 3] = num9++;
				array2[i * 3 + 1] = num9++;
				array2[i * 3 + 2] = num9++;
			}
			Mesh mesh = new Mesh();
			mesh.vertices = array3;
			mesh.normals = array4;
			mesh.triangles = array2;
			GetComponent<MeshFilter>().mesh = mesh;
		}

		private void OnDeviceConnected(int i, bool connected)
		{
			if (i != (int)index)
			{
				return;
			}
			GetComponent<MeshFilter>().mesh = null;
			if (!connected)
			{
				return;
			}
			CVRSystem system = OpenVR.System;
			if (system != null && system.GetTrackedDeviceClass((uint)i) == ETrackedDeviceClass.TrackingReference)
			{
				ETrackedPropertyError pError = ETrackedPropertyError.TrackedProp_Success;
				float floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_FieldOfViewLeftDegrees_Float, ref pError);
				if (pError == ETrackedPropertyError.TrackedProp_Success)
				{
					fovLeft = floatTrackedDeviceProperty;
				}
				floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_FieldOfViewRightDegrees_Float, ref pError);
				if (pError == ETrackedPropertyError.TrackedProp_Success)
				{
					fovRight = floatTrackedDeviceProperty;
				}
				floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_FieldOfViewTopDegrees_Float, ref pError);
				if (pError == ETrackedPropertyError.TrackedProp_Success)
				{
					fovTop = floatTrackedDeviceProperty;
				}
				floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_FieldOfViewBottomDegrees_Float, ref pError);
				if (pError == ETrackedPropertyError.TrackedProp_Success)
				{
					fovBottom = floatTrackedDeviceProperty;
				}
				floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_TrackingRangeMinimumMeters_Float, ref pError);
				if (pError == ETrackedPropertyError.TrackedProp_Success)
				{
					nearZ = floatTrackedDeviceProperty;
				}
				floatTrackedDeviceProperty = system.GetFloatTrackedDeviceProperty((uint)i, ETrackedDeviceProperty.Prop_TrackingRangeMaximumMeters_Float, ref pError);
				if (pError == ETrackedPropertyError.TrackedProp_Success)
				{
					farZ = floatTrackedDeviceProperty;
				}
				UpdateModel();
			}
		}

		private void OnEnable()
		{
			GetComponent<MeshFilter>().mesh = null;
			SteamVR_Events.DeviceConnected.Listen(OnDeviceConnected);
		}

		private void OnDisable()
		{
			SteamVR_Events.DeviceConnected.Remove(OnDeviceConnected);
			GetComponent<MeshFilter>().mesh = null;
		}
	}
	public class SteamVR_IK : MonoBehaviour
	{
		public Transform target;

		public Transform start;

		public Transform joint;

		public Transform end;

		public Transform poleVector;

		public Transform upVector;

		public float blendPct = 1f;

		[HideInInspector]
		public Transform startXform;

		[HideInInspector]
		public Transform jointXform;

		[HideInInspector]
		public Transform endXform;

		private void LateUpdate()
		{
			if (blendPct < 0.001f)
			{
				return;
			}
			Vector3 worldUp = (upVector ? upVector.up : Vector3.Cross(end.position - start.position, joint.position - start.position).normalized);
			Vector3 position = target.position;
			Quaternion rotation = target.rotation;
			Vector3 result = joint.position;
			Solve(start.position, position, poleVector.position, (joint.position - start.position).magnitude, (end.position - joint.position).magnitude, ref result, out var _, out var up);
			if (!(up == Vector3.zero))
			{
				Vector3 position2 = start.position;
				Vector3 position3 = joint.position;
				Vector3 position4 = end.position;
				Quaternion localRotation = start.localRotation;
				Quaternion localRotation2 = joint.localRotation;
				Quaternion localRotation3 = end.localRotation;
				Transform parent = start.parent;
				Transform parent2 = joint.parent;
				Transform parent3 = end.parent;
				Vector3 localScale = start.localScale;
				Vector3 localScale2 = joint.localScale;
				Vector3 localScale3 = end.localScale;
				if (startXform == null)
				{
					startXform = new GameObject("startXform").transform;
					startXform.parent = base.transform;
				}
				startXform.position = position2;
				startXform.LookAt(joint, worldUp);
				start.parent = startXform;
				if (jointXform == null)
				{
					jointXform = new GameObject("jointXform").transform;
					jointXform.parent = startXform;
				}
				jointXform.position = position3;
				jointXform.LookAt(end, worldUp);
				joint.parent = jointXform;
				if (endXform == null)
				{
					endXform = new GameObject("endXform").transform;
					endXform.parent = jointXform;
				}
				endXform.position = position4;
				end.parent = endXform;
				startXform.LookAt(result, up);
				jointXform.LookAt(position, up);
				endXform.rotation = rotation;
				start.parent = parent;
				joint.parent = parent2;
				end.parent = parent3;
				end.rotation = rotation;
				if (blendPct < 1f)
				{
					start.localRotation = Quaternion.Slerp(localRotation, start.localRotation, blendPct);
					joint.localRotation = Quaternion.Slerp(localRotation2, joint.localRotation, blendPct);
					end.localRotation = Quaternion.Slerp(localRotation3, end.localRotation, blendPct);
				}
				start.localScale = localScale;
				joint.localScale = localScale2;
				end.localScale = localScale3;
			}
		}

		public static bool Solve(Vector3 start, Vector3 end, Vector3 poleVector, float jointDist, float targetDist, ref Vector3 result, out Vector3 forward, out Vector3 up)
		{
			float num = jointDist + targetDist;
			Vector3 vector = end - start;
			Vector3 normalized = (poleVector - start).normalized;
			float magnitude = vector.magnitude;
			result = start;
			if (magnitude < 0.001f)
			{
				result += normalized * jointDist;
				forward = Vector3.Cross(normalized, Vector3.up);
				up = Vector3.Cross(forward, normalized).normalized;
			}
			else
			{
				forward = vector * (1f / magnitude);
				up = Vector3.Cross(forward, normalized).normalized;
				if (magnitude + 0.001f < num)
				{
					float num2 = (num + magnitude) * 0.5f;
					if (num2 > jointDist + 0.001f && num2 > targetDist + 0.001f)
					{
						float num3 = Mathf.Sqrt(num2 * (num2 - jointDist) * (num2 - targetDist) * (num2 - magnitude));
						float num4 = 2f * num3 / magnitude;
						float num5 = Mathf.Sqrt(jointDist * jointDist - num4 * num4);
						Vector3 vector2 = Vector3.Cross(up, forward);
						result += forward * num5 + vector2 * num4;
						return true;
					}
					result += normalized * jointDist;
				}
				else
				{
					result += forward * jointDist;
				}
			}
			return false;
		}
	}
	public class SteamVR_LoadLevel : MonoBehaviour
	{
		private static SteamVR_LoadLevel _active;

		public string levelName;

		public string internalProcessPath;

		public string internalProcessArgs;

		public bool loadAdditive;

		public bool loadAsync = true;

		public Texture loadingScreen;

		public Texture progressBarEmpty;

		public Texture progressBarFull;

		public float loadingScreenWidthInMeters = 6f;

		public float progressBarWidthInMeters = 3f;

		public float loadingScreenDistance;

		public Transform loadingScreenTransform;

		public Transform progressBarTransform;

		public Texture front;

		public Texture back;

		public Texture left;

		public Texture right;

		public Texture top;

		public Texture bottom;

		public Color backgroundColor = Color.black;

		public bool showGrid;

		public float fadeOutTime = 0.5f;

		public float fadeInTime = 0.5f;

		public float postLoadSettleTime;

		public float loadingScreenFadeInTime = 1f;

		public float loadingScreenFadeOutTime = 0.25f;

		private float fadeRate = 1f;

		private float alpha;

		private UnityEngine.AsyncOperation async;

		private RenderTexture renderTexture;

		private ulong loadingScreenOverlayHandle;

		private ulong progressBarOverlayHandle;

		public bool autoTriggerOnEnable;

		public static bool loading => _active != null;

		public static float progress
		{
			get
			{
				if (!(_active != null) || _active.async == null)
				{
					return 0f;
				}
				return _active.async.progress;
			}
		}

		public static Texture progressTexture
		{
			get
			{
				if (!(_active != null))
				{
					return null;
				}
				return _active.renderTexture;
			}
		}

		private void OnEnable()
		{
			if (autoTriggerOnEnable)
			{
				Trigger();
			}
		}

		public void Trigger()
		{
			if (!loading && !string.IsNullOrEmpty(levelName))
			{
				StartCoroutine(LoadLevel());
			}
		}

		public static void Begin(string levelName, bool showGrid = false, float fadeOutTime = 0.5f, float r = 0f, float g = 0f, float b = 0f, float a = 1f)
		{
			SteamVR_LoadLevel steamVR_LoadLevel = new GameObject("loader").AddComponent<SteamVR_LoadLevel>();
			steamVR_LoadLevel.levelName = levelName;
			steamVR_LoadLevel.showGrid = showGrid;
			steamVR_LoadLevel.fadeOutTime = fadeOutTime;
			steamVR_LoadLevel.backgroundColor = new Color(r, g, b, a);
			steamVR_LoadLevel.Trigger();
		}

		private void OnGUI()
		{
			if (_active != this || !(progressBarEmpty != null) || !(progressBarFull != null))
			{
				return;
			}
			if (progressBarOverlayHandle == 0L)
			{
				progressBarOverlayHandle = GetOverlayHandle("progressBar", (progressBarTransform != null) ? progressBarTransform : base.transform, progressBarWidthInMeters);
			}
			if (progressBarOverlayHandle != 0L)
			{
				float num = ((async != null) ? async.progress : 0f);
				int width = progressBarFull.width;
				int height = progressBarFull.height;
				if (renderTexture == null)
				{
					renderTexture = new RenderTexture(width, height, 0);
					renderTexture.Create();
				}
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = renderTexture;
				if (Event.current.type == EventType.Repaint)
				{
					GL.Clear(clearDepth: false, clearColor: true, Color.clear);
				}
				GUILayout.BeginArea(new Rect(0f, 0f, width, height));
				GUI.DrawTexture(new Rect(0f, 0f, width, height), progressBarEmpty);
				GUI.DrawTextureWithTexCoords(new Rect(0f, 0f, num * (float)width, height), progressBarFull, new Rect(0f, 0f, num, 1f));
				GUILayout.EndArea();
				RenderTexture.active = active;
				CVROverlay overlay = OpenVR.Overlay;
				if (overlay != null)
				{
					Texture_t pTexture = new Texture_t
					{
						handle = renderTexture.GetNativeTexturePtr(),
						eType = SteamVR.instance.textureType,
						eColorSpace = EColorSpace.Auto
					};
					overlay.SetOverlayTexture(progressBarOverlayHandle, ref pTexture);
				}
			}
		}

		private void Update()
		{
			if (_active != this)
			{
				return;
			}
			alpha = Mathf.Clamp01(alpha + fadeRate * Time.deltaTime);
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay != null)
			{
				if (loadingScreenOverlayHandle != 0L)
				{
					overlay.SetOverlayAlpha(loadingScreenOverlayHandle, alpha);
				}
				if (progressBarOverlayHandle != 0L)
				{
					overlay.SetOverlayAlpha(progressBarOverlayHandle, alpha);
				}
			}
		}

		private IEnumerator LoadLevel()
		{
			if (loadingScreen != null && loadingScreenDistance > 0f)
			{
				Transform transform = base.transform;
				if (Camera.main != null)
				{
					transform = Camera.main.transform;
				}
				Quaternion quaternion = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
				Vector3 position = transform.position + quaternion * new Vector3(0f, 0f, loadingScreenDistance);
				Transform obj = ((loadingScreenTransform != null) ? loadingScreenTransform : base.transform);
				obj.position = position;
				obj.rotation = quaternion;
			}
			_active = this;
			SteamVR_Events.Loading.Send(arg0: true);
			if (loadingScreenFadeInTime > 0f)
			{
				fadeRate = 1f / loadingScreenFadeInTime;
			}
			else
			{
				alpha = 1f;
			}
			CVROverlay overlay = OpenVR.Overlay;
			if (loadingScreen != null && overlay != null)
			{
				loadingScreenOverlayHandle = GetOverlayHandle("loadingScreen", (loadingScreenTransform != null) ? loadingScreenTransform : base.transform, loadingScreenWidthInMeters);
				if (loadingScreenOverlayHandle != 0L)
				{
					Texture_t pTexture = new Texture_t
					{
						handle = loadingScreen.GetNativeTexturePtr(),
						eType = SteamVR.instance.textureType,
						eColorSpace = EColorSpace.Auto
					};
					overlay.SetOverlayTexture(loadingScreenOverlayHandle, ref pTexture);
				}
			}
			bool fadedForeground = false;
			SteamVR_Events.LoadingFadeOut.Send(fadeOutTime);
			CVRCompositor compositor = OpenVR.Compositor;
			if (compositor != null)
			{
				if (front != null)
				{
					SteamVR_Skybox.SetOverride(front, back, left, right, top, bottom);
					compositor.FadeGrid(fadeOutTime, bFadeIn: true);
					yield return new WaitForSeconds(fadeOutTime);
				}
				else if (backgroundColor != Color.clear)
				{
					if (showGrid)
					{
						compositor.FadeToColor(0f, backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a, bBackground: true);
						compositor.FadeGrid(fadeOutTime, bFadeIn: true);
						yield return new WaitForSeconds(fadeOutTime);
					}
					else
					{
						compositor.FadeToColor(fadeOutTime, backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a, bBackground: false);
						yield return new WaitForSeconds(fadeOutTime + 0.1f);
						compositor.FadeGrid(0f, bFadeIn: true);
						fadedForeground = true;
					}
				}
			}
			SteamVR_Render.pauseRendering = true;
			while (alpha < 1f)
			{
				yield return null;
			}
			base.transform.parent = null;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (!string.IsNullOrEmpty(internalProcessPath))
			{
				UnityEngine.Debug.Log("<b>[SteamVR]</b> Launching external application...");
				CVRApplications applications = OpenVR.Applications;
				if (applications == null)
				{
					UnityEngine.Debug.Log("<b>[SteamVR]</b> Failed to get OpenVR.Applications interface!");
				}
				else
				{
					string currentDirectory = Directory.GetCurrentDirectory();
					string text = Path.Combine(currentDirectory, internalProcessPath);
					UnityEngine.Debug.Log("<b>[SteamVR]</b> LaunchingInternalProcess");
					UnityEngine.Debug.Log("<b>[SteamVR]</b> ExternalAppPath = " + internalProcessPath);
					UnityEngine.Debug.Log("<b>[SteamVR]</b> FullPath = " + text);
					UnityEngine.Debug.Log("<b>[SteamVR]</b> ExternalAppArgs = " + internalProcessArgs);
					UnityEngine.Debug.Log("<b>[SteamVR]</b> WorkingDirectory = " + currentDirectory);
					UnityEngine.Debug.Log("<b>[SteamVR]</b> LaunchInternalProcessError: " + applications.LaunchInternalProcess(text, internalProcessArgs, currentDirectory));
					Process.GetCurrentProcess().Kill();
				}
			}
			else
			{
				LoadSceneMode mode = (loadAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single);
				if (loadAsync)
				{
					Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.Low;
					async = SceneManager.LoadSceneAsync(levelName, mode);
					while (!async.isDone)
					{
						yield return null;
					}
				}
				else
				{
					SceneManager.LoadScene(levelName, mode);
				}
			}
			yield return null;
			GC.Collect();
			yield return null;
			Shader.WarmupAllShaders();
			yield return new WaitForSeconds(postLoadSettleTime);
			SteamVR_Render.pauseRendering = false;
			if (loadingScreenFadeOutTime > 0f)
			{
				fadeRate = -1f / loadingScreenFadeOutTime;
			}
			else
			{
				alpha = 0f;
			}
			SteamVR_Events.LoadingFadeIn.Send(fadeInTime);
			compositor = OpenVR.Compositor;
			if (compositor != null)
			{
				if (fadedForeground)
				{
					compositor.FadeGrid(0f, bFadeIn: false);
					compositor.FadeToColor(fadeInTime, 0f, 0f, 0f, 0f, bBackground: false);
					yield return new WaitForSeconds(fadeInTime);
				}
				else
				{
					compositor.FadeGrid(fadeInTime, bFadeIn: false);
					yield return new WaitForSeconds(fadeInTime);
					if (front != null)
					{
						SteamVR_Skybox.ClearOverride();
					}
				}
			}
			while (alpha > 0f)
			{
				yield return null;
			}
			if (overlay != null)
			{
				if (progressBarOverlayHandle != 0L)
				{
					overlay.HideOverlay(progressBarOverlayHandle);
				}
				if (loadingScreenOverlayHandle != 0L)
				{
					overlay.HideOverlay(loadingScreenOverlayHandle);
				}
			}
			UnityEngine.Object.Destroy(base.gameObject);
			_active = null;
			SteamVR_Events.Loading.Send(arg0: false);
		}

		private ulong GetOverlayHandle(string overlayName, Transform transform, float widthInMeters = 1f)
		{
			ulong pOverlayHandle = 0uL;
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay == null)
			{
				return pOverlayHandle;
			}
			string pchOverlayKey = SteamVR_Overlay.key + "." + overlayName;
			EVROverlayError eVROverlayError = overlay.FindOverlay(pchOverlayKey, ref pOverlayHandle);
			if (eVROverlayError != EVROverlayError.None)
			{
				eVROverlayError = overlay.CreateOverlay(pchOverlayKey, overlayName, ref pOverlayHandle);
			}
			if (eVROverlayError == EVROverlayError.None)
			{
				overlay.ShowOverlay(pOverlayHandle);
				overlay.SetOverlayAlpha(pOverlayHandle, alpha);
				overlay.SetOverlayWidthInMeters(pOverlayHandle, widthInMeters);
				if (SteamVR.instance.textureType == ETextureType.DirectX)
				{
					VRTextureBounds_t pOverlayTextureBounds = new VRTextureBounds_t
					{
						uMin = 0f,
						vMin = 1f,
						uMax = 1f,
						vMax = 0f
					};
					overlay.SetOverlayTextureBounds(pOverlayHandle, ref pOverlayTextureBounds);
				}
				SteamVR_Camera steamVR_Camera = ((loadingScreenDistance == 0f) ? SteamVR_Render.Top() : null);
				if (steamVR_Camera != null && steamVR_Camera.origin != null)
				{
					SteamVR_Utils.RigidTransform rigidTransform = new SteamVR_Utils.RigidTransform(steamVR_Camera.origin, transform);
					rigidTransform.pos.x /= steamVR_Camera.origin.localScale.x;
					rigidTransform.pos.y /= steamVR_Camera.origin.localScale.y;
					rigidTransform.pos.z /= steamVR_Camera.origin.localScale.z;
					HmdMatrix34_t pmatTrackingOriginToOverlayTransform = rigidTransform.ToHmdMatrix34();
					overlay.SetOverlayTransformAbsolute(pOverlayHandle, SteamVR.settings.trackingSpace, ref pmatTrackingOriginToOverlayTransform);
				}
				else
				{
					HmdMatrix34_t pmatTrackingOriginToOverlayTransform2 = new SteamVR_Utils.RigidTransform(transform).ToHmdMatrix34();
					overlay.SetOverlayTransformAbsolute(pOverlayHandle, SteamVR.settings.trackingSpace, ref pmatTrackingOriginToOverlayTransform2);
				}
			}
			return pOverlayHandle;
		}
	}
	public class SteamVR_Menu : MonoBehaviour
	{
		public Texture cursor;

		public Texture background;

		public Texture logo;

		public float logoHeight;

		public float menuOffset;

		public Vector2 scaleLimits = new Vector2(0.1f, 5f);

		public float scaleRate = 0.5f;

		private SteamVR_Overlay overlay;

		private Camera overlayCam;

		private Vector4 uvOffset;

		private float distance;

		private string scaleLimitX;

		private string scaleLimitY;

		private string scaleRateText;

		private CursorLockMode savedCursorLockState;

		private bool savedCursorVisible;

		public RenderTexture texture
		{
			get
			{
				if (!overlay)
				{
					return null;
				}
				return overlay.texture as RenderTexture;
			}
		}

		public float scale { get; private set; }

		private void Awake()
		{
			scaleLimitX = $"{scaleLimits.x:N1}";
			scaleLimitY = $"{scaleLimits.y:N1}";
			scaleRateText = $"{scaleRate:N1}";
			SteamVR_Overlay instance = SteamVR_Overlay.instance;
			if (instance != null)
			{
				uvOffset = instance.uvOffset;
				distance = instance.distance;
			}
		}

		private void OnGUI()
		{
			if (overlay == null)
			{
				return;
			}
			RenderTexture renderTexture = overlay.texture as RenderTexture;
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			if (Event.current.type == EventType.Repaint)
			{
				GL.Clear(clearDepth: false, clearColor: true, Color.clear);
			}
			Rect screenRect = new Rect(0f, 0f, renderTexture.width, renderTexture.height);
			if (Screen.width < renderTexture.width)
			{
				screenRect.width = Screen.width;
				overlay.uvOffset.x = (0f - (float)(renderTexture.width - Screen.width)) / (float)(2 * renderTexture.width);
			}
			if (Screen.height < renderTexture.height)
			{
				screenRect.height = Screen.height;
				overlay.uvOffset.y = (float)(renderTexture.height - Screen.height) / (float)(2 * renderTexture.height);
			}
			GUILayout.BeginArea(screenRect);
			if (background != null)
			{
				GUI.DrawTexture(new Rect((screenRect.width - (float)background.width) / 2f, (screenRect.height - (float)background.height) / 2f, background.width, background.height), background);
			}
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.BeginVertical();
			if (logo != null)
			{
				GUILayout.Space(screenRect.height / 2f - logoHeight);
				GUILayout.Box(logo);
			}
			GUILayout.Space(menuOffset);
			bool num = GUILayout.Button("[Esc] - Close menu");
			GUILayout.BeginHorizontal();
			GUILayout.Label($"Scale: {scale:N4}");
			float num2 = GUILayout.HorizontalSlider(scale, scaleLimits.x, scaleLimits.y);
			if (num2 != scale)
			{
				SetScale(num2);
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label($"Scale limits:");
			string text = GUILayout.TextField(scaleLimitX);
			if (text != scaleLimitX && float.TryParse(text, out scaleLimits.x))
			{
				scaleLimitX = text;
			}
			string text2 = GUILayout.TextField(scaleLimitY);
			if (text2 != scaleLimitY && float.TryParse(text2, out scaleLimits.y))
			{
				scaleLimitY = text2;
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			GUILayout.Label($"Scale rate:");
			string text3 = GUILayout.TextField(scaleRateText);
			if (text3 != scaleRateText && float.TryParse(text3, out scaleRate))
			{
				scaleRateText = text3;
			}
			GUILayout.EndHorizontal();
			if (SteamVR.active)
			{
				SteamVR instance = SteamVR.instance;
				GUILayout.BeginHorizontal();
				float sceneResolutionScale = SteamVR_Camera.sceneResolutionScale;
				int num3 = (int)(instance.sceneWidth * sceneResolutionScale);
				int num4 = (int)(instance.sceneHeight * sceneResolutionScale);
				int num5 = (int)(100f * sceneResolutionScale);
				GUILayout.Label($"Scene quality: {num3}x{num4} ({num5}%)");
				int num6 = Mathf.RoundToInt(GUILayout.HorizontalSlider(num5, 50f, 200f));
				if (num6 != num5)
				{
					SteamVR_Camera.sceneResolutionScale = (float)num6 / 100f;
				}
				GUILayout.EndHorizontal();
			}
			SteamVR_Camera steamVR_Camera = SteamVR_Render.Top();
			if (steamVR_Camera != null)
			{
				steamVR_Camera.wireframe = GUILayout.Toggle(steamVR_Camera.wireframe, "Wireframe");
				if (SteamVR.settings.trackingSpace == ETrackingUniverseOrigin.TrackingUniverseSeated)
				{
					if (GUILayout.Button("Switch to Standing"))
					{
						SteamVR.settings.trackingSpace = ETrackingUniverseOrigin.TrackingUniverseStanding;
					}
					if (GUILayout.Button("Center View"))
					{
						OpenVR.Chaperone?.ResetZeroPose(SteamVR.settings.trackingSpace);
					}
				}
				else if (GUILayout.Button("Switch to Seated"))
				{
					SteamVR.settings.trackingSpace = ETrackingUniverseOrigin.TrackingUniverseSeated;
				}
			}
			if (GUILayout.Button("Exit"))
			{
				Application.Quit();
			}
			GUILayout.Space(menuOffset);
			string environmentVariable = Environment.GetEnvironmentVariable("VR_OVERRIDE");
			if (environmentVariable != null)
			{
				GUILayout.Label("VR_OVERRIDE=" + environmentVariable);
			}
			GUILayout.Label("Graphics device: " + SystemInfo.graphicsDeviceVersion);
			GUILayout.EndVertical();
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			if (cursor != null)
			{
				float x = Input.mousePosition.x;
				float y = (float)Screen.height - Input.mousePosition.y;
				float width = cursor.width;
				float height = cursor.height;
				GUI.DrawTexture(new Rect(x, y, width, height), cursor);
			}
			RenderTexture.active = active;
			if (num)
			{
				HideMenu();
			}
		}

		public void ShowMenu()
		{
			SteamVR_Overlay instance = SteamVR_Overlay.instance;
			if (instance == null)
			{
				return;
			}
			RenderTexture renderTexture = instance.texture as RenderTexture;
			if (renderTexture == null)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Menu requires overlay texture to be a render texture.", this);
				return;
			}
			SaveCursorState();
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			overlay = instance;
			uvOffset = instance.uvOffset;
			distance = instance.distance;
			Camera[] array = UnityEngine.Object.FindObjectsOfType(typeof(Camera)) as Camera[];
			foreach (Camera camera in array)
			{
				if (camera.enabled && camera.targetTexture == renderTexture)
				{
					overlayCam = camera;
					overlayCam.enabled = false;
					break;
				}
			}
			SteamVR_Camera steamVR_Camera = SteamVR_Render.Top();
			if (steamVR_Camera != null)
			{
				scale = steamVR_Camera.origin.localScale.x;
			}
		}

		public void HideMenu()
		{
			RestoreCursorState();
			if (overlayCam != null)
			{
				overlayCam.enabled = true;
			}
			if (overlay != null)
			{
				overlay.uvOffset = uvOffset;
				overlay.distance = distance;
				overlay = null;
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
			{
				if (overlay == null)
				{
					ShowMenu();
				}
				else
				{
					HideMenu();
				}
			}
			else if (Input.GetKeyDown(KeyCode.Home))
			{
				SetScale(1f);
			}
			else if (Input.GetKey(KeyCode.PageUp))
			{
				SetScale(Mathf.Clamp(scale + scaleRate * Time.deltaTime, scaleLimits.x, scaleLimits.y));
			}
			else if (Input.GetKey(KeyCode.PageDown))
			{
				SetScale(Mathf.Clamp(scale - scaleRate * Time.deltaTime, scaleLimits.x, scaleLimits.y));
			}
		}

		private void SetScale(float scale)
		{
			this.scale = scale;
			SteamVR_Camera steamVR_Camera = SteamVR_Render.Top();
			if (steamVR_Camera != null)
			{
				steamVR_Camera.origin.localScale = new Vector3(scale, scale, scale);
			}
		}

		private void SaveCursorState()
		{
			savedCursorVisible = Cursor.visible;
			savedCursorLockState = Cursor.lockState;
		}

		private void RestoreCursorState()
		{
			Cursor.visible = savedCursorVisible;
			Cursor.lockState = savedCursorLockState;
		}
	}
	public class SteamVR_Overlay : MonoBehaviour
	{
		public struct IntersectionResults
		{
			public Vector3 point;

			public Vector3 normal;

			public Vector2 UVs;

			public float distance;
		}

		public Texture texture;

		[Tooltip("Size of overlay view.")]
		public float scale = 3f;

		[Tooltip("Distance from surface.")]
		public float distance = 1.25f;

		[Tooltip("Opacity")]
		[Range(0f, 1f)]
		public float alpha = 1f;

		public Vector4 uvOffset = new Vector4(0f, 0f, 1f, 1f);

		public Vector2 mouseScale = new Vector2(1f, 1f);

		public VROverlayInputMethod inputMethod;

		private ulong handle;

		public static SteamVR_Overlay instance { get; private set; }

		public static string key => "unity:" + Application.companyName + "." + Application.productName;

		private void OnEnable()
		{
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay != null)
			{
				EVROverlayError eVROverlayError = overlay.CreateOverlay(key, base.gameObject.name, ref handle);
				if (eVROverlayError != EVROverlayError.None)
				{
					UnityEngine.Debug.Log("<b>[SteamVR]</b> " + overlay.GetOverlayErrorNameFromEnum(eVROverlayError));
					base.enabled = false;
					return;
				}
			}
			instance = this;
		}

		private void OnDisable()
		{
			if (handle != 0L)
			{
				OpenVR.Overlay?.DestroyOverlay(handle);
				handle = 0uL;
			}
			instance = null;
		}

		public void UpdateOverlay()
		{
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay == null)
			{
				return;
			}
			if (texture != null)
			{
				EVROverlayError eVROverlayError = overlay.ShowOverlay(handle);
				if ((eVROverlayError != EVROverlayError.InvalidHandle && eVROverlayError != EVROverlayError.UnknownOverlay) || overlay.FindOverlay(key, ref handle) == EVROverlayError.None)
				{
					Texture_t pTexture = new Texture_t
					{
						handle = texture.GetNativeTexturePtr(),
						eType = SteamVR.instance.textureType,
						eColorSpace = EColorSpace.Auto
					};
					overlay.SetOverlayTexture(handle, ref pTexture);
					overlay.SetOverlayAlpha(handle, alpha);
					overlay.SetOverlayWidthInMeters(handle, scale);
					VRTextureBounds_t pOverlayTextureBounds = new VRTextureBounds_t
					{
						uMin = (0f + uvOffset.x) * uvOffset.z,
						vMin = (1f + uvOffset.y) * uvOffset.w,
						uMax = (1f + uvOffset.x) * uvOffset.z,
						vMax = (0f + uvOffset.y) * uvOffset.w
					};
					overlay.SetOverlayTextureBounds(handle, ref pOverlayTextureBounds);
					HmdVector2_t pvecMouseScale = new HmdVector2_t
					{
						v0 = mouseScale.x,
						v1 = mouseScale.y
					};
					overlay.SetOverlayMouseScale(handle, ref pvecMouseScale);
					SteamVR_Camera steamVR_Camera = SteamVR_Render.Top();
					if (steamVR_Camera != null && steamVR_Camera.origin != null)
					{
						SteamVR_Utils.RigidTransform rigidTransform = new SteamVR_Utils.RigidTransform(steamVR_Camera.origin, base.transform);
						rigidTransform.pos.x /= steamVR_Camera.origin.localScale.x;
						rigidTransform.pos.y /= steamVR_Camera.origin.localScale.y;
						rigidTransform.pos.z /= steamVR_Camera.origin.localScale.z;
						rigidTransform.pos.z += distance;
						HmdMatrix34_t pmatTrackingOriginToOverlayTransform = rigidTransform.ToHmdMatrix34();
						overlay.SetOverlayTransformAbsolute(handle, SteamVR.settings.trackingSpace, ref pmatTrackingOriginToOverlayTransform);
					}
					overlay.SetOverlayInputMethod(handle, inputMethod);
				}
			}
			else
			{
				overlay.HideOverlay(handle);
			}
		}

		public bool PollNextEvent(ref VREvent_t pEvent)
		{
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay == null)
			{
				return false;
			}
			uint uncbVREvent = (uint)Marshal.SizeOf(typeof(VREvent_t));
			return overlay.PollNextOverlayEvent(handle, ref pEvent, uncbVREvent);
		}

		public bool ComputeIntersection(Vector3 source, Vector3 direction, ref IntersectionResults results)
		{
			CVROverlay overlay = OpenVR.Overlay;
			if (overlay == null)
			{
				return false;
			}
			VROverlayIntersectionParams_t pParams = new VROverlayIntersectionParams_t
			{
				eOrigin = SteamVR.settings.trackingSpace,
				vSource = 
				{
					v0 = source.x,
					v1 = source.y,
					v2 = 0f - source.z
				},
				vDirection = 
				{
					v0 = direction.x,
					v1 = direction.y,
					v2 = 0f - direction.z
				}
			};
			VROverlayIntersectionResults_t pResults = default(VROverlayIntersectionResults_t);
			if (!overlay.ComputeOverlayIntersection(handle, ref pParams, ref pResults))
			{
				return false;
			}
			results.point = new Vector3(pResults.vPoint.v0, pResults.vPoint.v1, 0f - pResults.vPoint.v2);
			results.normal = new Vector3(pResults.vNormal.v0, pResults.vNormal.v1, 0f - pResults.vNormal.v2);
			results.UVs = new Vector2(pResults.vUVs.v0, pResults.vUVs.v1);
			results.distance = pResults.fDistance;
			return true;
		}
	}
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	public class SteamVR_PlayArea : MonoBehaviour
	{
		public enum Size
		{
			Calibrated,
			_400x300,
			_300x225,
			_200x150
		}

		public float borderThickness = 0.15f;

		public float wireframeHeight = 2f;

		public bool drawWireframeWhenSelectedOnly;

		public bool drawInGame = true;

		public Size size;

		public Color color = Color.cyan;

		[HideInInspector]
		public Vector3[] vertices;

		public static bool GetBounds(Size size, ref HmdQuad_t pRect)
		{
			bool flag;
			int num;
			if (size == Size.Calibrated)
			{
				flag = false;
				if (Application.isEditor && !Application.isPlaying)
				{
					flag = SteamVR.InitializeTemporarySession();
				}
				CVRChaperone chaperone = OpenVR.Chaperone;
				if (chaperone != null)
				{
					num = (chaperone.GetPlayAreaRect(ref pRect) ? 1 : 0);
					if (num != 0)
					{
						goto IL_003a;
					}
				}
				else
				{
					num = 0;
				}
				UnityEngine.Debug.LogWarning("<b>[SteamVR]</b> Failed to get Calibrated Play Area bounds!  Make sure you have tracking first, and that your space is calibrated.");
				goto IL_003a;
			}
			try
			{
				string[] array = size.ToString().Substring(1).Split(new char[1] { 'x' }, 2);
				float num2 = float.Parse(array[0]) / 200f;
				float num3 = float.Parse(array[1]) / 200f;
				pRect.vCorners0.v0 = num2;
				pRect.vCorners0.v1 = 0f;
				pRect.vCorners0.v2 = 0f - num3;
				pRect.vCorners1.v0 = 0f - num2;
				pRect.vCorners1.v1 = 0f;
				pRect.vCorners1.v2 = 0f - num3;
				pRect.vCorners2.v0 = 0f - num2;
				pRect.vCorners2.v1 = 0f;
				pRect.vCorners2.v2 = num3;
				pRect.vCorners3.v0 = num2;
				pRect.vCorners3.v1 = 0f;
				pRect.vCorners3.v2 = num3;
				return true;
			}
			catch
			{
			}
			return false;
			IL_003a:
			if (flag)
			{
				SteamVR.ExitTemporarySession();
			}
			return (byte)num != 0;
		}

		public void BuildMesh()
		{
			HmdQuad_t pRect = default(HmdQuad_t);
			if (!GetBounds(size, ref pRect))
			{
				return;
			}
			HmdVector3_t[] array = new HmdVector3_t[4] { pRect.vCorners0, pRect.vCorners1, pRect.vCorners2, pRect.vCorners3 };
			vertices = new Vector3[array.Length * 2];
			for (int i = 0; i < array.Length; i++)
			{
				HmdVector3_t hmdVector3_t = array[i];
				vertices[i] = new Vector3(hmdVector3_t.v0, 0.01f, hmdVector3_t.v2);
			}
			if (borderThickness == 0f)
			{
				GetComponent<MeshFilter>().mesh = null;
				return;
			}
			for (int j = 0; j < array.Length; j++)
			{
				int num = (j + 1) % array.Length;
				int num2 = (j + array.Length - 1) % array.Length;
				Vector3 normalized = (vertices[num] - vertices[j]).normalized;
				Vector3 normalized2 = (vertices[num2] - vertices[j]).normalized;
				Vector3 vector = vertices[j];
				vector += Vector3.Cross(normalized, Vector3.up) * borderThickness;
				vector += Vector3.Cross(normalized2, Vector3.down) * borderThickness;
				vertices[array.Length + j] = vector;
			}
			int[] triangles = new int[24]
			{
				0, 4, 1, 1, 4, 5, 1, 5, 2, 2,
				5, 6, 2, 6, 3, 3, 6, 7, 3, 7,
				0, 0, 7, 4
			};
			Vector2[] uv = new Vector2[8]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			};
			Color[] colors = new Color[8]
			{
				color,
				color,
				color,
				color,
				new Color(color.r, color.g, color.b, 0f),
				new Color(color.r, color.g, color.b, 0f),
				new Color(color.r, color.g, color.b, 0f),
				new Color(color.r, color.g, color.b, 0f)
			};
			Mesh mesh = new Mesh();
			GetComponent<MeshFilter>().mesh = mesh;
			mesh.vertices = vertices;
			mesh.uv = uv;
			mesh.colors = colors;
			mesh.triangles = triangles;
			MeshRenderer component = GetComponent<MeshRenderer>();
			component.material = new Material(Shader.Find("Sprites/Default"));
			component.reflectionProbeUsage = ReflectionProbeUsage.Off;
			component.shadowCastingMode = ShadowCastingMode.Off;
			component.receiveShadows = false;
			component.lightProbeUsage = LightProbeUsage.Off;
		}

		private void OnDrawGizmos()
		{
			if (!drawWireframeWhenSelectedOnly)
			{
				DrawWireframe();
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (drawWireframeWhenSelectedOnly)
			{
				DrawWireframe();
			}
		}

		public void DrawWireframe()
		{
			if (vertices != null && vertices.Length != 0)
			{
				Vector3 vector = base.transform.TransformVector(Vector3.up * wireframeHeight);
				for (int i = 0; i < 4; i++)
				{
					int num = (i + 1) % 4;
					Vector3 vector2 = base.transform.TransformPoint(vertices[i]);
					Vector3 vector3 = vector2 + vector;
					Vector3 vector4 = base.transform.TransformPoint(vertices[num]);
					Vector3 to = vector4 + vector;
					Gizmos.DrawLine(vector2, vector3);
					Gizmos.DrawLine(vector2, vector4);
					Gizmos.DrawLine(vector3, to);
				}
			}
		}

		public void OnEnable()
		{
			if (Application.isPlaying)
			{
				GetComponent<MeshRenderer>().enabled = drawInGame;
				base.enabled = false;
				if (drawInGame && size == Size.Calibrated)
				{
					StartCoroutine(UpdateBounds());
				}
			}
		}

		private IEnumerator UpdateBounds()
		{
			GetComponent<MeshFilter>().mesh = null;
			CVRChaperone chaperone = OpenVR.Chaperone;
			if (chaperone != null)
			{
				while (chaperone.GetCalibrationState() != ChaperoneCalibrationState.OK)
				{
					yield return null;
				}
				BuildMesh();
			}
		}
	}
	public class SteamVR_Render : MonoBehaviour
	{
		public SteamVR_ExternalCamera externalCamera;

		public string externalCameraConfigPath = "externalcamera.cfg";

		private static bool isQuitting;

		private SteamVR_Camera[] cameras = new SteamVR_Camera[0];

		public TrackedDevicePose_t[] poses = new TrackedDevicePose_t[64];

		public TrackedDevicePose_t[] gamePoses = new TrackedDevicePose_t[0];

		private static bool _pauseRendering;

		private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

		private bool? doesPathExist;

		private float sceneResolutionScale = 1f;

		private float timeScale = 1f;

		private EVRScreenshotType[] screenshotTypes = new EVRScreenshotType[1] { EVRScreenshotType.StereoPanorama };

		public static EVREye eye { get; private set; }

		public static SteamVR_Render instance => SteamVR_Behaviour.instance.steamvr_render;

		public static bool pauseRendering
		{
			get
			{
				return _pauseRendering;
			}
			set
			{
				_pauseRendering = value;
				OpenVR.Compositor?.SuspendRendering(value);
			}
		}

		private void OnApplicationQuit()
		{
			isQuitting = true;
			SteamVR.SafeDispose();
		}

		public static void Add(SteamVR_Camera vrcam)
		{
			if (!isQuitting)
			{
				instance.AddInternal(vrcam);
			}
		}

		public static void Remove(SteamVR_Camera vrcam)
		{
			if (!isQuitting && instance != null)
			{
				instance.RemoveInternal(vrcam);
			}
		}

		public static SteamVR_Camera Top()
		{
			if (!isQuitting)
			{
				return instance.TopInternal();
			}
			return null;
		}

		private void AddInternal(SteamVR_Camera vrcam)
		{
			Camera component = vrcam.GetComponent<Camera>();
			int num = cameras.Length;
			SteamVR_Camera[] array = new SteamVR_Camera[num + 1];
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				Camera component2 = cameras[i].GetComponent<Camera>();
				if (i == num2 && component2.depth > component.depth)
				{
					array[num2++] = vrcam;
				}
				array[num2++] = cameras[i];
			}
			if (num2 == num)
			{
				array[num2] = vrcam;
			}
			cameras = array;
		}

		private void RemoveInternal(SteamVR_Camera vrcam)
		{
			int num = cameras.Length;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				if (cameras[i] == vrcam)
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				return;
			}
			SteamVR_Camera[] array = new SteamVR_Camera[num - num2];
			int num3 = 0;
			for (int j = 0; j < num; j++)
			{
				SteamVR_Camera steamVR_Camera = cameras[j];
				if (steamVR_Camera != vrcam)
				{
					array[num3++] = steamVR_Camera;
				}
			}
			cameras = array;
		}

		private SteamVR_Camera TopInternal()
		{
			if (cameras.Length != 0)
			{
				return cameras[cameras.Length - 1];
			}
			return null;
		}

		private IEnumerator RenderLoop()
		{
			while (Application.isPlaying)
			{
				yield return waitForEndOfFrame;
				if (pauseRendering)
				{
					continue;
				}
				CVRCompositor compositor = OpenVR.Compositor;
				if (compositor != null)
				{
					if (!compositor.CanRenderScene())
					{
						continue;
					}
					compositor.SetTrackingSpace(SteamVR.settings.trackingSpace);
				}
				SteamVR_Overlay steamVR_Overlay = SteamVR_Overlay.instance;
				if (steamVR_Overlay != null)
				{
					steamVR_Overlay.UpdateOverlay();
				}
				if (CheckExternalCamera())
				{
					RenderExternalCamera();
				}
			}
		}

		private bool CheckExternalCamera()
		{
			if (doesPathExist == false)
			{
				return false;
			}
			if (!doesPathExist.HasValue)
			{
				doesPathExist = File.Exists(externalCameraConfigPath);
			}
			if (externalCamera == null && doesPathExist == true)
			{
				GameObject gameObject = Resources.Load<GameObject>("SteamVR_ExternalCamera");
				if (gameObject == null)
				{
					doesPathExist = false;
					return false;
				}
				if (SteamVR_Settings.instance.legacyMixedRealityCamera)
				{
					if (!SteamVR_ExternalCamera_LegacyManager.hasCamera)
					{
						return false;
					}
					GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
					gameObject2.gameObject.name = "External Camera";
					externalCamera = gameObject2.transform.GetChild(0).GetComponent<SteamVR_ExternalCamera>();
					externalCamera.configPath = externalCameraConfigPath;
					externalCamera.ReadConfig();
					externalCamera.SetupDeviceIndex(SteamVR_ExternalCamera_LegacyManager.cameraIndex);
				}
				else
				{
					SteamVR_Action_Pose mixedRealityCameraPose = SteamVR_Settings.instance.mixedRealityCameraPose;
					SteamVR_Input_Sources mixedRealityCameraInputSource = SteamVR_Settings.instance.mixedRealityCameraInputSource;
					if (mixedRealityCameraPose != null && SteamVR_Settings.instance.mixedRealityActionSetAutoEnable && mixedRealityCameraPose.actionSet != null && !mixedRealityCameraPose.actionSet.IsActive(mixedRealityCameraInputSource))
					{
						mixedRealityCameraPose.actionSet.Activate(mixedRealityCameraInputSource);
					}
					if (mixedRealityCameraPose == null)
					{
						doesPathExist = false;
						return false;
					}
					if (mixedRealityCameraPose != null && mixedRealityCameraPose[mixedRealityCameraInputSource].active && mixedRealityCameraPose[mixedRealityCameraInputSource].deviceIsConnected)
					{
						GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject);
						gameObject3.gameObject.name = "External Camera";
						externalCamera = gameObject3.transform.GetChild(0).GetComponent<SteamVR_ExternalCamera>();
						externalCamera.configPath = externalCameraConfigPath;
						externalCamera.ReadConfig();
						externalCamera.SetupPose(mixedRealityCameraPose, mixedRealityCameraInputSource);
					}
				}
			}
			return externalCamera != null;
		}

		private void RenderExternalCamera()
		{
			if (!(externalCamera == null) && externalCamera.gameObject.activeInHierarchy)
			{
				int num = (int)Mathf.Max(externalCamera.config.frameSkip, 0f);
				if (Time.frameCount % (num + 1) == 0)
				{
					externalCamera.AttachToCamera(TopInternal());
					externalCamera.RenderNear();
					externalCamera.RenderFar();
				}
			}
		}

		private void OnInputFocus(bool hasFocus)
		{
			if (!SteamVR.active)
			{
				return;
			}
			if (hasFocus)
			{
				if (SteamVR.settings.pauseGameWhenDashboardVisible)
				{
					Time.timeScale = timeScale;
				}
				SteamVR_Camera.sceneResolutionScale = sceneResolutionScale;
				return;
			}
			if (SteamVR.settings.pauseGameWhenDashboardVisible)
			{
				timeScale = Time.timeScale;
				Time.timeScale = 0f;
			}
			sceneResolutionScale = SteamVR_Camera.sceneResolutionScale;
			SteamVR_Camera.sceneResolutionScale = 0.5f;
		}

		private string GetScreenshotFilename(uint screenshotHandle, EVRScreenshotPropertyFilenames screenshotPropertyFilename)
		{
			EVRScreenshotError pError = EVRScreenshotError.None;
			uint screenshotPropertyFilename2 = OpenVR.Screenshots.GetScreenshotPropertyFilename(screenshotHandle, screenshotPropertyFilename, null, 0u, ref pError);
			if (pError != EVRScreenshotError.None && pError != EVRScreenshotError.BufferTooSmall)
			{
				return null;
			}
			if (screenshotPropertyFilename2 > 1)
			{
				StringBuilder stringBuilder = new StringBuilder((int)screenshotPropertyFilename2);
				OpenVR.Screenshots.GetScreenshotPropertyFilename(screenshotHandle, screenshotPropertyFilename, stringBuilder, screenshotPropertyFilename2, ref pError);
				if (pError != EVRScreenshotError.None)
				{
					return null;
				}
				return stringBuilder.ToString();
			}
			return null;
		}

		private void OnRequestScreenshot(VREvent_t vrEvent)
		{
			uint handle = vrEvent.data.screenshot.handle;
			EVRScreenshotType type = (EVRScreenshotType)vrEvent.data.screenshot.type;
			if (type == EVRScreenshotType.StereoPanorama)
			{
				string previewFilename = GetScreenshotFilename(handle, EVRScreenshotPropertyFilenames.Preview);
				string VRFilename = GetScreenshotFilename(handle, EVRScreenshotPropertyFilenames.VR);
				if (previewFilename != null && VRFilename != null)
				{
					GameObject gameObject = new GameObject("screenshotPosition");
					gameObject.transform.position = Top().transform.position;
					gameObject.transform.rotation = Top().transform.rotation;
					gameObject.transform.localScale = Top().transform.lossyScale;
					SteamVR_Utils.TakeStereoScreenshot(handle, gameObject, 32, 0.064f, ref previewFilename, ref VRFilename);
					OpenVR.Screenshots.SubmitScreenshot(handle, type, previewFilename, VRFilename);
				}
			}
		}

		private void OnEnable()
		{
			StartCoroutine(RenderLoop());
			SteamVR_Events.InputFocus.Listen(OnInputFocus);
			SteamVR_Events.System(EVREventType.VREvent_RequestScreenshot).Listen(OnRequestScreenshot);
			if (SteamVR_Settings.instance.legacyMixedRealityCamera)
			{
				SteamVR_ExternalCamera_LegacyManager.SubscribeToNewPoses();
			}
			Application.onBeforeRender += OnBeforeRender;
			if (SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess)
			{
				OpenVR.Screenshots.HookScreenshot(screenshotTypes);
			}
			else
			{
				SteamVR_Events.Initialized.AddListener(OnSteamVRInitialized);
			}
		}

		private void OnSteamVRInitialized(bool success)
		{
			if (success)
			{
				OpenVR.Screenshots.HookScreenshot(screenshotTypes);
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
			SteamVR_Events.InputFocus.Remove(OnInputFocus);
			SteamVR_Events.System(EVREventType.VREvent_RequestScreenshot).Remove(OnRequestScreenshot);
			Application.onBeforeRender -= OnBeforeRender;
			if (SteamVR.initializedState != SteamVR.InitializedStates.InitializeSuccess)
			{
				SteamVR_Events.Initialized.RemoveListener(OnSteamVRInitialized);
			}
		}

		public void UpdatePoses()
		{
			CVRCompositor compositor = OpenVR.Compositor;
			if (compositor != null)
			{
				compositor.GetLastPoses(poses, gamePoses);
				SteamVR_Events.NewPoses.Send(poses);
				SteamVR_Events.NewPosesApplied.Send();
			}
		}

		private void OnBeforeRender()
		{
			if (SteamVR.active && SteamVR.settings.IsPoseUpdateMode(SteamVR_UpdateModes.OnPreCull))
			{
				UpdatePoses();
			}
		}

		private void Update()
		{
			if (!SteamVR.active)
			{
				return;
			}
			CVRSystem system = OpenVR.System;
			if (system == null)
			{
				return;
			}
			UpdatePoses();
			VREvent_t pEvent = default(VREvent_t);
			uint uncbVREvent = (uint)Marshal.SizeOf(typeof(VREvent_t));
			for (int i = 0; i < 64; i++)
			{
				if (!system.PollNextEvent(ref pEvent, uncbVREvent))
				{
					break;
				}
				switch ((EVREventType)pEvent.eventType)
				{
				case EVREventType.VREvent_InputFocusCaptured:
					if (pEvent.data.process.oldPid == 0)
					{
						SteamVR_Events.InputFocus.Send(arg0: false);
					}
					break;
				case EVREventType.VREvent_InputFocusReleased:
					if (pEvent.data.process.pid == 0)
					{
						SteamVR_Events.InputFocus.Send(arg0: true);
					}
					break;
				case EVREventType.VREvent_ShowRenderModels:
					SteamVR_Events.HideRenderModels.Send(arg0: false);
					break;
				case EVREventType.VREvent_HideRenderModels:
					SteamVR_Events.HideRenderModels.Send(arg0: true);
					break;
				default:
					SteamVR_Events.System((EVREventType)pEvent.eventType).Send(pEvent);
					break;
				}
			}
			Application.targetFrameRate = -1;
			Application.runInBackground = true;
			QualitySettings.maxQueuedFrames = -1;
			QualitySettings.vSyncCount = 0;
			if (SteamVR.settings.lockPhysicsUpdateRateToRenderFrequency && Time.timeScale > 0f)
			{
				SteamVR steamVR = SteamVR.instance;
				if (steamVR != null && Application.isPlaying)
				{
					Time.fixedDeltaTime = Time.timeScale / steamVR.hmd_DisplayFrequency;
				}
			}
		}
	}
	[ExecuteInEditMode]
	public class SteamVR_RenderModel : MonoBehaviour
	{
		public class RenderModel
		{
			public Mesh mesh { get; private set; }

			public Material material { get; private set; }

			public RenderModel(Mesh mesh, Material material)
			{
				this.mesh = mesh;
				this.material = material;
			}
		}

		public sealed class RenderModelInterfaceHolder : IDisposable
		{
			private bool needsShutdown;

			private bool failedLoadInterface;

			private CVRRenderModels _instance;

			public CVRRenderModels instance
			{
				get
				{
					if (_instance == null && !failedLoadInterface)
					{
						if (Application.isEditor && !Application.isPlaying)
						{
							needsShutdown = SteamVR.InitializeTemporarySession();
						}
						_instance = OpenVR.RenderModels;
						if (_instance == null)
						{
							UnityEngine.Debug.LogError("<b>[SteamVR]</b> Failed to load IVRRenderModels interface version IVRRenderModels_006");
							failedLoadInterface = true;
						}
					}
					return _instance;
				}
			}

			public void Dispose()
			{
				if (needsShutdown)
				{
					SteamVR.ExitTemporarySession();
				}
			}
		}

		public SteamVR_TrackedObject.EIndex index = SteamVR_TrackedObject.EIndex.None;

		protected SteamVR_Input_Sources inputSource;

		public const string modelOverrideWarning = "Model override is really only meant to be used in the scene view for lining things up; using it at runtime is discouraged.  Use tracked device index instead to ensure the correct model is displayed for all users.";

		[Tooltip("Model override is really only meant to be used in the scene view for lining things up; using it at runtime is discouraged.  Use tracked device index instead to ensure the correct model is displayed for all users.")]
		public string modelOverride;

		[Tooltip("Shader to apply to model.")]
		public Shader shader;

		[Tooltip("Enable to print out when render models are loaded.")]
		public bool verbose;

		[Tooltip("If available, break down into separate components instead of loading as a single mesh.")]
		public bool createComponents = true;

		[Tooltip("Update transforms of components at runtime to reflect user action.")]
		public bool updateDynamically = true;

		public RenderModel_ControllerMode_State_t controllerModeState;

		public const string k_localTransformName = "attach";

		private Dictionary<string, Transform> componentAttachPoints = new Dictionary<string, Transform>();

		private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

		public static Hashtable models = new Hashtable();

		public static Hashtable materials = new Hashtable();

		private SteamVR_Events.Action deviceConnectedAction;

		private SteamVR_Events.Action hideRenderModelsAction;

		private SteamVR_Events.Action modelSkinSettingsHaveChangedAction;

		private Dictionary<int, string> nameCache;

		public string renderModelName { get; private set; }

		public bool initializedAttachPoints { get; set; }

		private void OnModelSkinSettingsHaveChanged(VREvent_t vrEvent)
		{
			if (!string.IsNullOrEmpty(renderModelName))
			{
				renderModelName = "";
				UpdateModel();
			}
		}

		public void SetMeshRendererState(bool state)
		{
			for (int i = 0; i < meshRenderers.Count; i++)
			{
				MeshRenderer meshRenderer = meshRenderers[i];
				if (meshRenderer != null)
				{
					meshRenderer.enabled = state;
				}
			}
		}

		private void OnHideRenderModels(bool hidden)
		{
			SetMeshRendererState(!hidden);
		}

		private void OnDeviceConnected(int i, bool connected)
		{
			if (i == (int)index && connected)
			{
				UpdateModel();
			}
		}

		public void UpdateModel()
		{
			CVRSystem system = OpenVR.System;
			if (system == null || index == SteamVR_TrackedObject.EIndex.None)
			{
				return;
			}
			ETrackedPropertyError pError = ETrackedPropertyError.TrackedProp_Success;
			uint stringTrackedDeviceProperty = system.GetStringTrackedDeviceProperty((uint)index, ETrackedDeviceProperty.Prop_RenderModelName_String, null, 0u, ref pError);
			if (stringTrackedDeviceProperty <= 1)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Failed to get render model name for tracked object " + index);
				return;
			}
			StringBuilder stringBuilder = new StringBuilder((int)stringTrackedDeviceProperty);
			system.GetStringTrackedDeviceProperty((uint)index, ETrackedDeviceProperty.Prop_RenderModelName_String, stringBuilder, stringTrackedDeviceProperty, ref pError);
			string text = stringBuilder.ToString();
			if (renderModelName != text)
			{
				StartCoroutine(SetModelAsync(text));
			}
		}

		private IEnumerator SetModelAsync(string newRenderModelName)
		{
			meshRenderers.Clear();
			if (string.IsNullOrEmpty(newRenderModelName))
			{
				yield break;
			}
			using (RenderModelInterfaceHolder holder = new RenderModelInterfaceHolder())
			{
				CVRRenderModels renderModels = holder.instance;
				if (renderModels == null)
				{
					yield break;
				}
				uint componentCount = renderModels.GetComponentCount(newRenderModelName);
				string[] renderModelNames;
				if (componentCount == 0)
				{
					renderModelNames = ((models[newRenderModelName] is RenderModel renderModel && !(renderModel.mesh == null)) ? new string[0] : new string[1] { newRenderModelName });
				}
				else
				{
					renderModelNames = new string[componentCount];
					for (int i = 0; i < componentCount; i++)
					{
						uint componentName = renderModels.GetComponentName(newRenderModelName, (uint)i, null, 0u);
						if (componentName == 0)
						{
							continue;
						}
						StringBuilder stringBuilder = new StringBuilder((int)componentName);
						if (renderModels.GetComponentName(newRenderModelName, (uint)i, stringBuilder, componentName) == 0)
						{
							continue;
						}
						string pchComponentName = stringBuilder.ToString();
						componentName = renderModels.GetComponentRenderModelName(newRenderModelName, pchComponentName, null, 0u);
						if (componentName == 0)
						{
							continue;
						}
						StringBuilder stringBuilder2 = new StringBuilder((int)componentName);
						if (renderModels.GetComponentRenderModelName(newRenderModelName, pchComponentName, stringBuilder2, componentName) != 0)
						{
							string text = stringBuilder2.ToString();
							if (!(models[text] is RenderModel renderModel2) || renderModel2.mesh == null)
							{
								renderModelNames[i] = text;
							}
						}
					}
				}
				while (true)
				{
					bool flag = false;
					for (int j = 0; j < renderModelNames.Length; j++)
					{
						if (string.IsNullOrEmpty(renderModelNames[j]))
						{
							continue;
						}
						IntPtr ppRenderModel = IntPtr.Zero;
						switch (renderModels.LoadRenderModel_Async(renderModelNames[j], ref ppRenderModel))
						{
						case EVRRenderModelError.Loading:
							flag = true;
							break;
						case EVRRenderModelError.None:
						{
							RenderModel_t renderModel_t = MarshalRenderModel(ppRenderModel);
							Material material = materials[renderModel_t.diffuseTextureId] as Material;
							if (material == null || material.mainTexture == null)
							{
								IntPtr ppTexture = IntPtr.Zero;
								EVRRenderModelError eVRRenderModelError = renderModels.LoadTexture_Async(renderModel_t.diffuseTextureId, ref ppTexture);
								if (eVRRenderModelError == EVRRenderModelError.Loading)
								{
									flag = true;
								}
							}
							break;
						}
						}
					}
					if (!flag)
					{
						break;
					}
					yield return new WaitForSecondsRealtime(0.1f);
				}
			}
			bool arg = SetModel(newRenderModelName);
			renderModelName = newRenderModelName;
			SteamVR_Events.RenderModelLoaded.Send(this, arg);
		}

		private bool SetModel(string renderModelName)
		{
			StripMesh(base.gameObject);
			using (RenderModelInterfaceHolder renderModelInterfaceHolder = new RenderModelInterfaceHolder())
			{
				if (createComponents)
				{
					componentAttachPoints.Clear();
					if (LoadComponents(renderModelInterfaceHolder, renderModelName))
					{
						UpdateComponents(renderModelInterfaceHolder.instance);
						return true;
					}
					UnityEngine.Debug.Log("<b>[SteamVR]</b> [" + base.gameObject.name + "] Render model does not support components, falling back to single mesh.");
				}
				if (!string.IsNullOrEmpty(renderModelName))
				{
					RenderModel renderModel = models[renderModelName] as RenderModel;
					if (renderModel == null || renderModel.mesh == null)
					{
						CVRRenderModels instance = renderModelInterfaceHolder.instance;
						if (instance == null)
						{
							return false;
						}
						if (verbose)
						{
							UnityEngine.Debug.Log("<b>[SteamVR]</b> Loading render model " + renderModelName);
						}
						renderModel = LoadRenderModel(instance, renderModelName, renderModelName);
						if (renderModel == null)
						{
							return false;
						}
						models[renderModelName] = renderModel;
					}
					base.gameObject.AddComponent<MeshFilter>().mesh = renderModel.mesh;
					MeshRenderer meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
					meshRenderer.sharedMaterial = renderModel.material;
					meshRenderers.Add(meshRenderer);
					return true;
				}
			}
			return false;
		}

		private RenderModel LoadRenderModel(CVRRenderModels renderModels, string renderModelName, string baseName)
		{
			IntPtr ppRenderModel = IntPtr.Zero;
			while (true)
			{
				EVRRenderModelError eVRRenderModelError = renderModels.LoadRenderModel_Async(renderModelName, ref ppRenderModel);
				switch (eVRRenderModelError)
				{
				case EVRRenderModelError.Loading:
					break;
				default:
					UnityEngine.Debug.LogError($"<b>[SteamVR]</b> Failed to load render model {renderModelName} - {eVRRenderModelError.ToString()}");
					return null;
				case EVRRenderModelError.None:
				{
					RenderModel_t renderModel_t = MarshalRenderModel(ppRenderModel);
					Vector3[] array = new Vector3[renderModel_t.unVertexCount];
					Vector3[] array2 = new Vector3[renderModel_t.unVertexCount];
					Vector2[] array3 = new Vector2[renderModel_t.unVertexCount];
					Type typeFromHandle = typeof(RenderModel_Vertex_t);
					for (int i = 0; i < renderModel_t.unVertexCount; i++)
					{
						RenderModel_Vertex_t renderModel_Vertex_t = (RenderModel_Vertex_t)Marshal.PtrToStructure(new IntPtr(renderModel_t.rVertexData.ToInt64() + i * Marshal.SizeOf(typeFromHandle)), typeFromHandle);
						array[i] = new Vector3(renderModel_Vertex_t.vPosition.v0, renderModel_Vertex_t.vPosition.v1, 0f - renderModel_Vertex_t.vPosition.v2);
						array2[i] = new Vector3(renderModel_Vertex_t.vNormal.v0, renderModel_Vertex_t.vNormal.v1, 0f - renderModel_Vertex_t.vNormal.v2);
						array3[i] = new Vector2(renderModel_Vertex_t.rfTextureCoord0, renderModel_Vertex_t.rfTextureCoord1);
					}
					uint num = renderModel_t.unTriangleCount * 3;
					short[] array4 = new short[num];
					Marshal.Copy(renderModel_t.rIndexData, array4, 0, array4.Length);
					int[] array5 = new int[num];
					for (int j = 0; j < renderModel_t.unTriangleCount; j++)
					{
						array5[j * 3] = array4[j * 3 + 2];
						array5[j * 3 + 1] = array4[j * 3 + 1];
						array5[j * 3 + 2] = array4[j * 3];
					}
					Mesh mesh = new Mesh();
					mesh.vertices = array;
					mesh.normals = array2;
					mesh.uv = array3;
					mesh.triangles = array5;
					Material material = materials[renderModel_t.diffuseTextureId] as Material;
					if (material == null || material.mainTexture == null)
					{
						IntPtr ppTexture = IntPtr.Zero;
						while (true)
						{
							eVRRenderModelError = renderModels.LoadTexture_Async(renderModel_t.diffuseTextureId, ref ppTexture);
							switch (eVRRenderModelError)
							{
							case EVRRenderModelError.Loading:
								goto IL_0230;
							case EVRRenderModelError.None:
							{
								RenderModel_TextureMap_t renderModel_TextureMap_t = MarshalRenderModel_TextureMap(ppTexture);
								Texture2D texture2D = new Texture2D(renderModel_TextureMap_t.unWidth, renderModel_TextureMap_t.unHeight, TextureFormat.RGBA32, mipChain: false);
								if (SystemInfo.graphicsDeviceType == GraphicsDeviceType.Direct3D11)
								{
									texture2D.Apply();
									IntPtr nativeTexturePtr = texture2D.GetNativeTexturePtr();
									while (true)
									{
										eVRRenderModelError = renderModels.LoadIntoTextureD3D11_Async(renderModel_t.diffuseTextureId, nativeTexturePtr);
										if (eVRRenderModelError != EVRRenderModelError.Loading)
										{
											break;
										}
										Sleep();
									}
								}
								else
								{
									byte[] array6 = new byte[renderModel_TextureMap_t.unWidth * renderModel_TextureMap_t.unHeight * 4];
									Marshal.Copy(renderModel_TextureMap_t.rubTextureMapData, array6, 0, array6.Length);
									Color32[] array7 = new Color32[renderModel_TextureMap_t.unWidth * renderModel_TextureMap_t.unHeight];
									int num2 = 0;
									for (int k = 0; k < renderModel_TextureMap_t.unHeight; k++)
									{
										for (int l = 0; l < renderModel_TextureMap_t.unWidth; l++)
										{
											byte r = array6[num2++];
											byte g = array6[num2++];
											byte b = array6[num2++];
											byte a = array6[num2++];
											array7[k * renderModel_TextureMap_t.unWidth + l] = new Color32(r, g, b, a);
										}
									}
									texture2D.SetPixels32(array7);
									texture2D.Apply();
								}
								material = new Material((shader != null) ? shader : Shader.Find("Universal Render Pipeline/Lit"));
								material.mainTexture = texture2D;
								materials[renderModel_t.diffuseTextureId] = material;
								renderModels.FreeTexture(ppTexture);
								break;
							}
							default:
								UnityEngine.Debug.Log("<b>[SteamVR]</b> Failed to load render model texture for render model " + renderModelName + ". Error: " + eVRRenderModelError);
								break;
							}
							break;
							IL_0230:
							Sleep();
						}
					}
					StartCoroutine(FreeRenderModel(ppRenderModel));
					return new RenderModel(mesh, material);
				}
				}
				Sleep();
			}
		}

		private IEnumerator FreeRenderModel(IntPtr pRenderModel)
		{
			yield return new WaitForSeconds(1f);
			using RenderModelInterfaceHolder renderModelInterfaceHolder = new RenderModelInterfaceHolder();
			renderModelInterfaceHolder.instance.FreeRenderModel(pRenderModel);
		}

		public Transform FindTransformByName(string componentName, Transform inTransform = null)
		{
			if (inTransform == null)
			{
				inTransform = base.transform;
			}
			for (int i = 0; i < inTransform.childCount; i++)
			{
				Transform child = inTransform.GetChild(i);
				if (child.name == componentName)
				{
					return child;
				}
			}
			return null;
		}

		public Transform GetComponentTransform(string componentName)
		{
			if (componentName == null)
			{
				return base.transform;
			}
			if (componentAttachPoints.ContainsKey(componentName))
			{
				return componentAttachPoints[componentName];
			}
			return null;
		}

		private void StripMesh(GameObject go)
		{
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != null)
			{
				UnityEngine.Object.DestroyImmediate(component);
			}
			MeshFilter component2 = go.GetComponent<MeshFilter>();
			if (component2 != null)
			{
				UnityEngine.Object.DestroyImmediate(component2);
			}
		}

		private bool LoadComponents(RenderModelInterfaceHolder holder, string renderModelName)
		{
			Transform transform = base.transform;
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				child.gameObject.SetActive(value: false);
				StripMesh(child.gameObject);
			}
			if (string.IsNullOrEmpty(renderModelName))
			{
				return true;
			}
			CVRRenderModels instance = holder.instance;
			if (instance == null)
			{
				return false;
			}
			uint componentCount = instance.GetComponentCount(renderModelName);
			if (componentCount == 0)
			{
				return false;
			}
			for (int j = 0; j < componentCount; j++)
			{
				uint componentName = instance.GetComponentName(renderModelName, (uint)j, null, 0u);
				if (componentName == 0)
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder((int)componentName);
				if (instance.GetComponentName(renderModelName, (uint)j, stringBuilder, componentName) == 0)
				{
					continue;
				}
				string text = stringBuilder.ToString();
				transform = FindTransformByName(text);
				if (transform != null)
				{
					transform.gameObject.SetActive(value: true);
					componentAttachPoints[text] = FindTransformByName("attach", transform);
				}
				else
				{
					transform = new GameObject(text).transform;
					transform.parent = base.transform;
					transform.gameObject.layer = base.gameObject.layer;
					Transform transform2 = new GameObject("attach").transform;
					transform2.parent = transform;
					transform2.localPosition = Vector3.zero;
					transform2.localRotation = Quaternion.identity;
					transform2.localScale = Vector3.one;
					transform2.gameObject.layer = base.gameObject.layer;
					componentAttachPoints[text] = transform2;
				}
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				transform.localScale = Vector3.one;
				componentName = instance.GetComponentRenderModelName(renderModelName, text, null, 0u);
				if (componentName == 0)
				{
					continue;
				}
				StringBuilder stringBuilder2 = new StringBuilder((int)componentName);
				if (instance.GetComponentRenderModelName(renderModelName, text, stringBuilder2, componentName) == 0)
				{
					continue;
				}
				string text2 = stringBuilder2.ToString();
				RenderModel renderModel = models[text2] as RenderModel;
				if (renderModel == null || renderModel.mesh == null)
				{
					if (verbose)
					{
						UnityEngine.Debug.Log("<b>[SteamVR]</b> Loading render model " + text2);
					}
					renderModel = LoadRenderModel(instance, text2, renderModelName);
					if (renderModel == null)
					{
						continue;
					}
					models[text2] = renderModel;
				}
				transform.gameObject.AddComponent<MeshFilter>().mesh = renderModel.mesh;
				MeshRenderer meshRenderer = transform.gameObject.AddComponent<MeshRenderer>();
				meshRenderer.sharedMaterial = renderModel.material;
				meshRenderers.Add(meshRenderer);
			}
			return true;
		}

		private SteamVR_RenderModel()
		{
			deviceConnectedAction = SteamVR_Events.DeviceConnectedAction(OnDeviceConnected);
			hideRenderModelsAction = SteamVR_Events.HideRenderModelsAction(OnHideRenderModels);
			modelSkinSettingsHaveChangedAction = SteamVR_Events.SystemAction(EVREventType.VREvent_ModelSkinSettingsHaveChanged, OnModelSkinSettingsHaveChanged);
		}

		private void OnEnable()
		{
			if (!string.IsNullOrEmpty(modelOverride))
			{
				UnityEngine.Debug.Log("<b>[SteamVR]</b> Model override is really only meant to be used in the scene view for lining things up; using it at runtime is discouraged.  Use tracked device index instead to ensure the correct model is displayed for all users.");
				base.enabled = false;
				return;
			}
			CVRSystem system = OpenVR.System;
			if (system != null && system.IsTrackedDeviceConnected((uint)index))
			{
				UpdateModel();
			}
			deviceConnectedAction.enabled = true;
			hideRenderModelsAction.enabled = true;
			modelSkinSettingsHaveChangedAction.enabled = true;
		}

		private void OnDisable()
		{
			deviceConnectedAction.enabled = false;
			hideRenderModelsAction.enabled = false;
			modelSkinSettingsHaveChangedAction.enabled = false;
		}

		private void Update()
		{
			if (updateDynamically)
			{
				UpdateComponents(OpenVR.RenderModels);
			}
		}

		public void UpdateComponents(CVRRenderModels renderModels)
		{
			if (renderModels == null || base.transform.childCount == 0)
			{
				return;
			}
			if (nameCache == null)
			{
				nameCache = new Dictionary<int, string>();
			}
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				if (!nameCache.TryGetValue(child.GetInstanceID(), out var value))
				{
					value = child.name;
					nameCache.Add(child.GetInstanceID(), value);
				}
				RenderModel_ComponentState_t pComponentState = default(RenderModel_ComponentState_t);
				if (!renderModels.GetComponentStateForDevicePath(renderModelName, value, SteamVR_Input_Source.GetHandle(inputSource), ref controllerModeState, ref pComponentState))
				{
					continue;
				}
				child.localPosition = pComponentState.mTrackingToComponentRenderModel.GetPosition();
				child.localRotation = pComponentState.mTrackingToComponentRenderModel.GetRotation();
				Transform transform = null;
				for (int j = 0; j < child.childCount; j++)
				{
					Transform child2 = child.GetChild(j);
					int instanceID = child2.GetInstanceID();
					if (!nameCache.TryGetValue(instanceID, out var value2))
					{
						value2 = child2.name;
						nameCache.Add(instanceID, value);
					}
					if (value2 == "attach")
					{
						transform = child2;
					}
				}
				if (transform != null)
				{
					transform.position = base.transform.TransformPoint(pComponentState.mTrackingToComponentLocal.GetPosition());
					transform.rotation = base.transform.rotation * pComponentState.mTrackingToComponentLocal.GetRotation();
					initializedAttachPoints = true;
				}
				bool flag = (pComponentState.uProperties & 2) != 0;
				if (flag != child.gameObject.activeSelf)
				{
					child.gameObject.SetActive(flag);
				}
			}
		}

		public void SetDeviceIndex(int newIndex)
		{
			index = (SteamVR_TrackedObject.EIndex)newIndex;
			modelOverride = "";
			if (base.enabled)
			{
				UpdateModel();
			}
		}

		public void SetInputSource(SteamVR_Input_Sources newInputSource)
		{
			inputSource = newInputSource;
		}

		private static void Sleep()
		{
			Thread.Sleep(1);
		}

		private RenderModel_t MarshalRenderModel(IntPtr pRenderModel)
		{
			if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
			{
				RenderModel_t_Packed renderModel_t_Packed = (RenderModel_t_Packed)Marshal.PtrToStructure(pRenderModel, typeof(RenderModel_t_Packed));
				RenderModel_t unpacked = default(RenderModel_t);
				renderModel_t_Packed.Unpack(ref unpacked);
				return unpacked;
			}
			return (RenderModel_t)Marshal.PtrToStructure(pRenderModel, typeof(RenderModel_t));
		}

		private RenderModel_TextureMap_t MarshalRenderModel_TextureMap(IntPtr pRenderModel)
		{
			if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
			{
				RenderModel_TextureMap_t_Packed renderModel_TextureMap_t_Packed = (RenderModel_TextureMap_t_Packed)Marshal.PtrToStructure(pRenderModel, typeof(RenderModel_TextureMap_t_Packed));
				RenderModel_TextureMap_t unpacked = default(RenderModel_TextureMap_t);
				renderModel_TextureMap_t_Packed.Unpack(ref unpacked);
				return unpacked;
			}
			return (RenderModel_TextureMap_t)Marshal.PtrToStructure(pRenderModel, typeof(RenderModel_TextureMap_t));
		}
	}
	public class SteamVR_RingBuffer<T>
	{
		protected T[] buffer;

		protected int currentIndex;

		protected T lastElement;

		private bool cleared;

		public SteamVR_RingBuffer(int size)
		{
			buffer = new T[size];
			currentIndex = 0;
		}

		public void Add(T newElement)
		{
			buffer[currentIndex] = newElement;
			StepForward();
		}

		public virtual void StepForward()
		{
			lastElement = buffer[currentIndex];
			currentIndex++;
			if (currentIndex >= buffer.Length)
			{
				currentIndex = 0;
			}
			cleared = false;
		}

		public virtual T GetAtIndex(int atIndex)
		{
			if (atIndex < 0)
			{
				atIndex += buffer.Length;
			}
			return buffer[atIndex];
		}

		public virtual T GetLast()
		{
			return lastElement;
		}

		public virtual int GetLastIndex()
		{
			int num = currentIndex - 1;
			if (num < 0)
			{
				num += buffer.Length;
			}
			return num;
		}

		public void Clear()
		{
			if (!cleared && buffer != null)
			{
				for (int i = 0; i < buffer.Length; i++)
				{
					buffer[i] = default(T);
				}
				lastElement = default(T);
				currentIndex = 0;
				cleared = true;
			}
		}
	}
	public class SteamVR_HistoryBuffer : SteamVR_RingBuffer<SteamVR_HistoryStep>
	{
		public SteamVR_HistoryBuffer(int size)
			: base(size)
		{
		}

		public void Update(Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 angularVelocity)
		{
			if (buffer[currentIndex] == null)
			{
				buffer[currentIndex] = new SteamVR_HistoryStep();
			}
			buffer[currentIndex].position = position;
			buffer[currentIndex].rotation = rotation;
			buffer[currentIndex].velocity = velocity;
			buffer[currentIndex].angularVelocity = angularVelocity;
			buffer[currentIndex].timeInTicks = DateTime.Now.Ticks;
			StepForward();
		}

		public float GetVelocityMagnitudeTrend(int toIndex = -1, int fromIndex = -1)
		{
			if (toIndex == -1)
			{
				toIndex = currentIndex - 1;
			}
			if (toIndex < 0)
			{
				toIndex += buffer.Length;
			}
			if (fromIndex == -1)
			{
				fromIndex = toIndex - 1;
			}
			if (fromIndex < 0)
			{
				fromIndex += buffer.Length;
			}
			SteamVR_HistoryStep steamVR_HistoryStep = buffer[toIndex];
			SteamVR_HistoryStep steamVR_HistoryStep2 = buffer[fromIndex];
			if (IsValid(steamVR_HistoryStep) && IsValid(steamVR_HistoryStep2))
			{
				return steamVR_HistoryStep.velocity.sqrMagnitude - steamVR_HistoryStep2.velocity.sqrMagnitude;
			}
			return 0f;
		}

		public bool IsValid(SteamVR_HistoryStep step)
		{
			if (step != null)
			{
				return step.timeInTicks != -1;
			}
			return false;
		}

		public int GetTopVelocity(int forFrames, int addFrames = 0)
		{
			int num = currentIndex;
			float num2 = 0f;
			int num3 = currentIndex;
			while (forFrames > 0)
			{
				forFrames--;
				num3--;
				if (num3 < 0)
				{
					num3 = buffer.Length - 1;
				}
				SteamVR_HistoryStep step = buffer[num3];
				if (!IsValid(step))
				{
					break;
				}
				float sqrMagnitude = buffer[num3].velocity.sqrMagnitude;
				if (sqrMagnitude > num2)
				{
					num = num3;
					num2 = sqrMagnitude;
				}
			}
			num += addFrames;
			if (num >= buffer.Length)
			{
				num -= buffer.Length;
			}
			return num;
		}

		public void GetAverageVelocities(out Vector3 velocity, out Vector3 angularVelocity, int forFrames, int startFrame = -1)
		{
			velocity = Vector3.zero;
			angularVelocity = Vector3.zero;
			if (startFrame == -1)
			{
				startFrame = currentIndex - 1;
			}
			if (startFrame < 0)
			{
				startFrame = buffer.Length - 1;
			}
			int num = startFrame - forFrames;
			if (num < 0)
			{
				num += buffer.Length;
			}
			Vector3 zero = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			float num2 = 0f;
			int num3 = startFrame;
			while (forFrames > 0)
			{
				forFrames--;
				num3--;
				if (num3 < 0)
				{
					num3 = buffer.Length - 1;
				}
				SteamVR_HistoryStep steamVR_HistoryStep = buffer[num3];
				if (!IsValid(steamVR_HistoryStep))
				{
					break;
				}
				num2 += 1f;
				zero += steamVR_HistoryStep.velocity;
				zero2 += steamVR_HistoryStep.angularVelocity;
			}
			velocity = zero / num2;
			angularVelocity = zero2 / num2;
		}
	}
	public class SteamVR_HistoryStep
	{
		public Vector3 position;

		public Quaternion rotation;

		public Vector3 velocity;

		public Vector3 angularVelocity;

		public long timeInTicks = -1L;
	}
	public class SteamVR_Settings : ScriptableObject
	{
		private static SteamVR_Settings _instance;

		public bool pauseGameWhenDashboardVisible;

		public bool lockPhysicsUpdateRateToRenderFrequency = true;

		[SerializeField]
		[FormerlySerializedAs("trackingSpace")]
		private ETrackingUniverseOrigin trackingSpaceOrigin = ETrackingUniverseOrigin.TrackingUniverseStanding;

		[Tooltip("Filename local to StreamingAssets/SteamVR/ folder")]
		public string actionsFilePath = "actions.json";

		[Tooltip("Path local to the directory the SteamVR folder as in")]
		public string steamVRInputPath = "SteamVR_Input";

		public SteamVR_UpdateModes inputUpdateMode = SteamVR_UpdateModes.OnUpdate;

		public SteamVR_UpdateModes poseUpdateMode = SteamVR_UpdateModes.OnPreCull;

		public bool activateFirstActionSetOnStart = true;

		[Tooltip("This is the app key the unity editor will use to identify your application. (can be \"steam.app.[appid]\" to persist bindings between editor steam)")]
		public string editorAppKey;

		[Tooltip("The SteamVR Plugin can automatically make sure VR is enabled in your player settings and if not, enable it.")]
		public bool autoEnableVR = true;

		[Space]
		[Tooltip("This determines if we use legacy mixed reality mode (3rd controller/tracker device connected) or the new input system mode (pose / input source)")]
		public bool legacyMixedRealityCamera = true;

		[Tooltip("[NON-LEGACY] This is the pose action that will be used for positioning a mixed reality camera if connected")]
		public SteamVR_Action_Pose mixedRealityCameraPose = SteamVR_Input.GetPoseAction("ExternalCamera");

		[Tooltip("[NON-LEGACY] This is the input source to check on the pose for the mixed reality camera")]
		public SteamVR_Input_Sources mixedRealityCameraInputSource = SteamVR_Input_Sources.Camera;

		[Tooltip("[NON-LEGACY] Auto enable mixed reality action set if file exists")]
		public bool mixedRealityActionSetAutoEnable = true;

		[Tooltip("[EDITOR ONLY] The (left) prefab to be used for showing previews while posing hands")]
		public GameObject previewHandLeft;

		[Tooltip("[EDITOR ONLY] The (right) prefab to be used for showing previews while posing hands")]
		public GameObject previewHandRight;

		private const string previewLeftDefaultAssetName = "vr_glove_left_model_slim";

		private const string previewRightDefaultAssetName = "vr_glove_right_model_slim";

		private const string defaultSettingsAssetName = "SteamVR_Settings";

		public static SteamVR_Settings instance
		{
			get
			{
				LoadInstance();
				return _instance;
			}
		}

		public ETrackingUniverseOrigin trackingSpace
		{
			get
			{
				return trackingSpaceOrigin;
			}
			set
			{
				trackingSpaceOrigin = value;
				if (SteamVR_Behaviour.isPlaying)
				{
					SteamVR_Action_Pose.SetTrackingUniverseOrigin(trackingSpaceOrigin);
				}
			}
		}

		public bool IsInputUpdateMode(SteamVR_UpdateModes tocheck)
		{
			return (inputUpdateMode & tocheck) == tocheck;
		}

		public bool IsPoseUpdateMode(SteamVR_UpdateModes tocheck)
		{
			return (poseUpdateMode & tocheck) == tocheck;
		}

		public static void VerifyScriptableObject()
		{
			LoadInstance();
		}

		private static void LoadInstance()
		{
			if (_instance == null)
			{
				_instance = Resources.Load<SteamVR_Settings>("SteamVR_Settings");
				if (_instance == null)
				{
					_instance = ScriptableObject.CreateInstance<SteamVR_Settings>();
				}
				SetDefaultsIfNeeded();
			}
		}

		public static void Save()
		{
		}

		private static void SetDefaultsIfNeeded()
		{
			if (string.IsNullOrEmpty(_instance.editorAppKey))
			{
				_instance.editorAppKey = SteamVR.GenerateAppKey();
				UnityEngine.Debug.Log("<b>[SteamVR Setup]</b> Generated you an editor app key of: " + _instance.editorAppKey + ". This lets the editor tell SteamVR what project this is. Has no effect on builds. This can be changed in Assets/SteamVR/Resources/SteamVR_Settings");
			}
			OpenVRSettings.GetSettings().ActionManifestFileRelativeFilePath = SteamVR_Input.GetActionsFilePath();
		}

		private static GameObject FindDefaultPreviewHand(string assetName)
		{
			return null;
		}
	}
	public class SteamVR_Skybox : MonoBehaviour
	{
		public enum CellSize
		{
			x1024,
			x64,
			x32,
			x16,
			x8
		}

		public Texture front;

		public Texture back;

		public Texture left;

		public Texture right;

		public Texture top;

		public Texture bottom;

		public CellSize StereoCellSize = CellSize.x32;

		public float StereoIpdMm = 64f;

		public void SetTextureByIndex(int i, Texture t)
		{
			switch (i)
			{
			case 0:
				front = t;
				break;
			case 1:
				back = t;
				break;
			case 2:
				left = t;
				break;
			case 3:
				right = t;
				break;
			case 4:
				top = t;
				break;
			case 5:
				bottom = t;
				break;
			}
		}

		public Texture GetTextureByIndex(int i)
		{
			return i switch
			{
				0 => front, 
				1 => back, 
				2 => left, 
				3 => right, 
				4 => top, 
				5 => bottom, 
				_ => null, 
			};
		}

		public static void SetOverride(Texture front = null, Texture back = null, Texture left = null, Texture right = null, Texture top = null, Texture bottom = null)
		{
			CVRCompositor compositor = OpenVR.Compositor;
			if (compositor == null)
			{
				return;
			}
			Texture[] array = new Texture[6] { front, back, left, right, top, bottom };
			Texture_t[] array2 = new Texture_t[6];
			for (int i = 0; i < 6; i++)
			{
				array2[i].handle = ((array[i] != null) ? array[i].GetNativeTexturePtr() : IntPtr.Zero);
				array2[i].eType = SteamVR.instance.textureType;
				array2[i].eColorSpace = EColorSpace.Auto;
			}
			EVRCompositorError eVRCompositorError = compositor.SetSkyboxOverride(array2);
			if (eVRCompositorError != EVRCompositorError.None)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR]</b> Failed to set skybox override with error: " + eVRCompositorError);
				switch (eVRCompositorError)
				{
				case EVRCompositorError.TextureIsOnWrongDevice:
					UnityEngine.Debug.Log("<b>[SteamVR]</b> Set your graphics driver to use the same video card as the headset is plugged into for Unity.");
					break;
				case EVRCompositorError.TextureUsesUnsupportedFormat:
					UnityEngine.Debug.Log("<b>[SteamVR]</b> Ensure skybox textures are not compressed and have no mipmaps.");
					break;
				}
			}
		}

		public static void ClearOverride()
		{
			OpenVR.Compositor?.ClearSkyboxOverride();
		}

		private void OnEnable()
		{
			SetOverride(front, back, left, right, top, bottom);
		}

		private void OnDisable()
		{
			ClearOverride();
		}
	}
	[ExecuteInEditMode]
	public class SteamVR_SphericalProjection : MonoBehaviour
	{
		private static Material material;

		public void Set(Vector3 N, float phi0, float phi1, float theta0, float theta1, Vector3 uAxis, Vector3 uOrigin, float uScale, Vector3 vAxis, Vector3 vOrigin, float vScale)
		{
			if (material == null)
			{
				material = new Material(Shader.Find("Custom/SteamVR_SphericalProjection"));
			}
			material.SetVector("_N", new Vector4(N.x, N.y, N.z));
			material.SetFloat("_Phi0", phi0 * (MathF.PI / 180f));
			material.SetFloat("_Phi1", phi1 * (MathF.PI / 180f));
			material.SetFloat("_Theta0", theta0 * (MathF.PI / 180f) + MathF.PI / 2f);
			material.SetFloat("_Theta1", theta1 * (MathF.PI / 180f) + MathF.PI / 2f);
			material.SetVector("_UAxis", uAxis);
			material.SetVector("_VAxis", vAxis);
			material.SetVector("_UOrigin", uOrigin);
			material.SetVector("_VOrigin", vOrigin);
			material.SetFloat("_UScale", uScale);
			material.SetFloat("_VScale", vScale);
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			Graphics.Blit(src, dest, material);
		}
	}
	public class SteamVR_TrackedCamera
	{
		public class VideoStreamTexture
		{
			private Texture2D _texture;

			private int prevFrameCount = -1;

			private uint glTextureId;

			private VideoStream videostream;

			private CameraVideoStreamFrameHeader_t header;

			public bool undistorted { get; private set; }

			public uint deviceIndex => videostream.deviceIndex;

			public bool hasCamera => videostream.hasCamera;

			public bool hasTracking
			{
				get
				{
					Update();
					return header.trackedDevicePose.bPoseIsValid;
				}
			}

			public uint frameId
			{
				get
				{
					Update();
					return header.nFrameSequence;
				}
			}

			public VRTextureBounds_t frameBounds { get; private set; }

			public EVRTrackedCameraFrameType frameType
			{
				get
				{
					if (!undistorted)
					{
						return EVRTrackedCameraFrameType.Distorted;
					}
					return EVRTrackedCameraFrameType.Undistorted;
				}
			}

			public Texture2D texture
			{
				get
				{
					Update();
					return _texture;
				}
			}

			public SteamVR_Utils.RigidTransform transform
			{
				get
				{
					Update();
					return new SteamVR_Utils.RigidTransform(header.trackedDevicePose.mDeviceToAbsoluteTracking);
				}
			}

			public Vector3 velocity
			{
				get
				{
					Update();
					TrackedDevicePose_t trackedDevicePose = header.trackedDevicePose;
					return new Vector3(trackedDevicePose.vVelocity.v0, trackedDevicePose.vVelocity.v1, 0f - trackedDevicePose.vVelocity.v2);
				}
			}

			public Vector3 angularVelocity
			{
				get
				{
					Update();
					TrackedDevicePose_t trackedDevicePose = header.trackedDevicePose;
					return new Vector3(0f - trackedDevicePose.vAngularVelocity.v0, 0f - trackedDevicePose.vAngularVelocity.v1, trackedDevicePose.vAngularVelocity.v2);
				}
			}

			public VideoStreamTexture(uint deviceIndex, bool undistorted)
			{
				this.undistorted = undistorted;
				videostream = Stream(deviceIndex);
			}

			public TrackedDevicePose_t GetPose()
			{
				Update();
				return header.trackedDevicePose;
			}

			public ulong Acquire()
			{
				return videostream.Acquire();
			}

			public ulong Release()
			{
				ulong result = videostream.Release();
				if (videostream.handle == 0L)
				{
					UnityEngine.Object.Destroy(_texture);
					_texture = null;
				}
				return result;
			}

			private void Update()
			{
				if (Time.frameCount == prevFrameCount)
				{
					return;
				}
				prevFrameCount = Time.frameCount;
				if (videostream.handle == 0L)
				{
					return;
				}
				SteamVR instance = SteamVR.instance;
				if (instance == null)
				{
					return;
				}
				CVRTrackedCamera trackedCamera = OpenVR.TrackedCamera;
				if (trackedCamera == null)
				{
					return;
				}
				IntPtr ppD3D11ShaderResourceView = IntPtr.Zero;
				Texture2D texture2D = ((_texture != null) ? _texture : new Texture2D(2, 2));
				uint nFrameHeaderSize = (uint)Marshal.SizeOf(header.GetType());
				if (instance.textureType == ETextureType.OpenGL)
				{
					if (glTextureId != 0)
					{
						trackedCamera.ReleaseVideoStreamTextureGL(videostream.handle, glTextureId);
					}
					if (trackedCamera.GetVideoStreamTextureGL(videostream.handle, frameType, ref glTextureId, ref header, nFrameHeaderSize) != EVRTrackedCameraError.None)
					{
						return;
					}
					ppD3D11ShaderResourceView = (IntPtr)glTextureId;
				}
				else if (instance.textureType == ETextureType.DirectX && trackedCamera.GetVideoStreamTextureD3D11(videostream.handle, frameType, texture2D.GetNativeTexturePtr(), ref ppD3D11ShaderResourceView, ref header, nFrameHeaderSize) != EVRTrackedCameraError.None)
				{
					return;
				}
				if (_texture == null)
				{
					_texture = Texture2D.CreateExternalTexture((int)header.nWidth, (int)header.nHeight, TextureFormat.RGBA32, mipChain: false, linear: false, ppD3D11ShaderResourceView);
					uint pnWidth = 0u;
					uint pnHeight = 0u;
					VRTextureBounds_t pTextureBounds = default(VRTextureBounds_t);
					if (trackedCamera.GetVideoStreamTextureSize(deviceIndex, frameType, ref pTextureBounds, ref pnWidth, ref pnHeight) == EVRTrackedCameraError.None)
					{
						pTextureBounds.vMin = 1f - pTextureBounds.vMin;
						pTextureBounds.vMax = 1f - pTextureBounds.vMax;
						frameBounds = pTextureBounds;
					}
				}
				else
				{
					_texture.UpdateExternalTexture(ppD3D11ShaderResourceView);
				}
			}
		}

		private class VideoStream
		{
			private ulong _handle;

			private bool _hasCamera;

			private ulong refCount;

			public uint deviceIndex { get; private set; }

			public ulong handle => _handle;

			public bool hasCamera => _hasCamera;

			public VideoStream(uint deviceIndex)
			{
				this.deviceIndex = deviceIndex;
				OpenVR.TrackedCamera?.HasCamera(deviceIndex, ref _hasCamera);
			}

			public ulong Acquire()
			{
				if (_handle == 0L && hasCamera)
				{
					OpenVR.TrackedCamera?.AcquireVideoStreamingService(deviceIndex, ref _handle);
				}
				return ++refCount;
			}

			public ulong Release()
			{
				if (refCount != 0 && --refCount == 0L && _handle != 0L)
				{
					OpenVR.TrackedCamera?.ReleaseVideoStreamingService(_handle);
					_handle = 0uL;
				}
				return refCount;
			}
		}

		private static VideoStreamTexture[] distorted;

		private static VideoStreamTexture[] undistorted;

		private static VideoStream[] videostreams;

		public static VideoStreamTexture Distorted(int deviceIndex = 0)
		{
			if (distorted == null)
			{
				distorted = new VideoStreamTexture[64];
			}
			if (distorted[deviceIndex] == null)
			{
				distorted[deviceIndex] = new VideoStreamTexture((uint)deviceIndex, undistorted: false);
			}
			return distorted[deviceIndex];
		}

		public static VideoStreamTexture Undistorted(int deviceIndex = 0)
		{
			if (undistorted == null)
			{
				undistorted = new VideoStreamTexture[64];
			}
			if (undistorted[deviceIndex] == null)
			{
				undistorted[deviceIndex] = new VideoStreamTexture((uint)deviceIndex, undistorted: true);
			}
			return undistorted[deviceIndex];
		}

		public static VideoStreamTexture Source(bool undistorted, int deviceIndex = 0)
		{
			if (!undistorted)
			{
				return Distorted(deviceIndex);
			}
			return Undistorted(deviceIndex);
		}

		private static VideoStream Stream(uint deviceIndex)
		{
			if (videostreams == null)
			{
				videostreams = new VideoStream[64];
			}
			if (videostreams[deviceIndex] == null)
			{
				videostreams[deviceIndex] = new VideoStream(deviceIndex);
			}
			return videostreams[deviceIndex];
		}
	}
	public class SteamVR_TrackedObject : MonoBehaviour
	{
		public enum EIndex
		{
			None = -1,
			Hmd,
			Device1,
			Device2,
			Device3,
			Device4,
			Device5,
			Device6,
			Device7,
			Device8,
			Device9,
			Device10,
			Device11,
			Device12,
			Device13,
			Device14,
			Device15,
			Device16
		}

		public EIndex index;

		[Tooltip("If not set, relative to parent")]
		public Transform origin;

		private SteamVR_Events.Action newPosesAction;

		public bool isValid { get; private set; }

		private void OnNewPoses(TrackedDevicePose_t[] poses)
		{
			if (index == EIndex.None)
			{
				return;
			}
			int num = (int)index;
			isValid = false;
			if (poses.Length > num && poses[num].bDeviceIsConnected && poses[num].bPoseIsValid)
			{
				isValid = true;
				SteamVR_Utils.RigidTransform rigidTransform = new SteamVR_Utils.RigidTransform(poses[num].mDeviceToAbsoluteTracking);
				if (origin != null)
				{
					base.transform.position = origin.transform.TransformPoint(rigidTransform.pos);
					base.transform.rotation = origin.rotation * rigidTransform.rot;
				}
				else
				{
					base.transform.localPosition = rigidTransform.pos;
					base.transform.localRotation = rigidTransform.rot;
				}
			}
		}

		private SteamVR_TrackedObject()
		{
			newPosesAction = SteamVR_Events.NewPosesAction(OnNewPoses);
		}

		private void Awake()
		{
			OnEnable();
		}

		private void OnEnable()
		{
			if (SteamVR_Render.instance == null)
			{
				base.enabled = false;
			}
			else
			{
				newPosesAction.enabled = true;
			}
		}

		private void OnDisable()
		{
			newPosesAction.enabled = false;
			isValid = false;
		}

		public void SetDeviceIndex(int index)
		{
			if (Enum.IsDefined(typeof(EIndex), index))
			{
				this.index = (EIndex)index;
			}
		}
	}
	public class SteamVR_TrackingReferenceManager : MonoBehaviour
	{
		private class TrackingReferenceObject
		{
			public ETrackedDeviceClass trackedDeviceClass;

			public GameObject gameObject;

			public SteamVR_RenderModel renderModel;

			public SteamVR_TrackedObject trackedObject;
		}

		private Dictionary<uint, TrackingReferenceObject> trackingReferences = new Dictionary<uint, TrackingReferenceObject>();

		private void OnEnable()
		{
			SteamVR_Events.NewPoses.AddListener(OnNewPoses);
		}

		private void OnDisable()
		{
			SteamVR_Events.NewPoses.RemoveListener(OnNewPoses);
		}

		private void OnNewPoses(TrackedDevicePose_t[] poses)
		{
			if (poses == null)
			{
				return;
			}
			for (uint num = 0u; num < poses.Length; num++)
			{
				if (!trackingReferences.ContainsKey(num))
				{
					ETrackedDeviceClass trackedDeviceClass = OpenVR.System.GetTrackedDeviceClass(num);
					if (trackedDeviceClass == ETrackedDeviceClass.TrackingReference)
					{
						TrackingReferenceObject trackingReferenceObject = new TrackingReferenceObject();
						trackingReferenceObject.trackedDeviceClass = trackedDeviceClass;
						trackingReferenceObject.gameObject = new GameObject("Tracking Reference " + num);
						trackingReferenceObject.gameObject.transform.parent = base.transform;
						trackingReferenceObject.trackedObject = trackingReferenceObject.gameObject.AddComponent<SteamVR_TrackedObject>();
						trackingReferenceObject.renderModel = trackingReferenceObject.gameObject.AddComponent<SteamVR_RenderModel>();
						trackingReferenceObject.renderModel.createComponents = false;
						trackingReferenceObject.renderModel.updateDynamically = false;
						trackingReferences.Add(num, trackingReferenceObject);
						trackingReferenceObject.gameObject.SendMessage("SetDeviceIndex", (int)num, SendMessageOptions.DontRequireReceiver);
					}
					else
					{
						trackingReferences.Add(num, new TrackingReferenceObject
						{
							trackedDeviceClass = trackedDeviceClass
						});
					}
				}
			}
		}
	}
}
namespace Valve.VR.InteractionSystem
{
	[RequireComponent(typeof(CapsuleCollider))]
	public class BodyCollider : MonoBehaviour
	{
		public Transform head;

		private CapsuleCollider capsuleCollider;

		private void Awake()
		{
			capsuleCollider = GetComponent<CapsuleCollider>();
		}

		private void FixedUpdate()
		{
			float num = Vector3.Dot(head.localPosition, Vector3.up);
			capsuleCollider.height = Mathf.Max(capsuleCollider.radius, num);
			base.transform.localPosition = head.localPosition - 0.5f * num * Vector3.up;
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class CircularDrive : MonoBehaviour
	{
		public enum Axis_t
		{
			XAxis,
			YAxis,
			ZAxis
		}

		[Tooltip("The axis around which the circular drive will rotate in local space")]
		public Axis_t axisOfRotation;

		[Tooltip("Child GameObject which has the Collider component to initiate interaction, only needs to be set if there is more than one Collider child")]
		public Collider childCollider;

		[Tooltip("A LinearMapping component to drive, if not specified one will be dynamically added to this GameObject")]
		public LinearMapping linearMapping;

		[Tooltip("If true, the drive will stay manipulating as long as the button is held down, if false, it will stop if the controller moves out of the collider")]
		public bool hoverLock;

		[Header("Limited Rotation")]
		[Tooltip("If true, the rotation will be limited to [minAngle, maxAngle], if false, the rotation is unlimited")]
		public bool limited;

		public Vector2 frozenDistanceMinMaxThreshold = new Vector2(0.1f, 0.2f);

		public UnityEvent onFrozenDistanceThreshold;

		[Header("Limited Rotation Min")]
		[Tooltip("If limited is true, the specifies the lower limit, otherwise value is unused")]
		public float minAngle = -45f;

		[Tooltip("If limited, set whether drive will freeze its angle when the min angle is reached")]
		public bool freezeOnMin;

		[Tooltip("If limited, event invoked when minAngle is reached")]
		public UnityEvent onMinAngle;

		[Header("Limited Rotation Max")]
		[Tooltip("If limited is true, the specifies the upper limit, otherwise value is unused")]
		public float maxAngle = 45f;

		[Tooltip("If limited, set whether drive will freeze its angle when the max angle is reached")]
		public bool freezeOnMax;

		[Tooltip("If limited, event invoked when maxAngle is reached")]
		public UnityEvent onMaxAngle;

		[Tooltip("If limited is true, this forces the starting angle to be startAngle, clamped to [minAngle, maxAngle]")]
		public bool forceStart;

		[Tooltip("If limited is true and forceStart is true, the starting angle will be this, clamped to [minAngle, maxAngle]")]
		public float startAngle;

		[Tooltip("If true, the transform of the GameObject this component is on will be rotated accordingly")]
		public bool rotateGameObject = true;

		[Tooltip("If true, the path of the Hand (red) and the projected value (green) will be drawn")]
		public bool debugPath;

		[Tooltip("If debugPath is true, this is the maximum number of GameObjects to create to draw the path")]
		public int dbgPathLimit = 50;

		[Tooltip("If not null, the TextMesh will display the linear value and the angular value of this circular drive")]
		public TextMesh debugText;

		[Tooltip("The output angle value of the drive in degrees, unlimited will increase or decrease without bound, take the 360 modulus to find number of rotations")]
		public float outAngle;

		private Quaternion start;

		private Vector3 worldPlaneNormal = new Vector3(1f, 0f, 0f);

		private Vector3 localPlaneNormal = new Vector3(1f, 0f, 0f);

		private Vector3 lastHandProjected;

		private Color red = new Color(1f, 0f, 0f);

		private Color green = new Color(0f, 1f, 0f);

		private GameObject[] dbgHandObjects;

		private GameObject[] dbgProjObjects;

		private GameObject dbgObjectsParent;

		private int dbgObjectCount;

		private int dbgObjectIndex;

		private bool driving;

		private float minMaxAngularThreshold = 1f;

		private bool frozen;

		private float frozenAngle;

		private Vector3 frozenHandWorldPos = new Vector3(0f, 0f, 0f);

		private Vector2 frozenSqDistanceMinMaxThreshold = new Vector2(0f, 0f);

		private Hand handHoverLocked;

		private Interactable interactable;

		private GrabTypes grabbedWithType;

		private void Freeze(Hand hand)
		{
			frozen = true;
			frozenAngle = outAngle;
			frozenHandWorldPos = hand.hoverSphereTransform.position;
			frozenSqDistanceMinMaxThreshold.x = frozenDistanceMinMaxThreshold.x * frozenDistanceMinMaxThreshold.x;
			frozenSqDistanceMinMaxThreshold.y = frozenDistanceMinMaxThreshold.y * frozenDistanceMinMaxThreshold.y;
		}

		private void UnFreeze()
		{
			frozen = false;
			frozenHandWorldPos.Set(0f, 0f, 0f);
		}

		private void Awake()
		{
			interactable = GetComponent<Interactable>();
		}

		private void Start()
		{
			if (childCollider == null)
			{
				childCollider = GetComponentInChildren<Collider>();
			}
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
			if (linearMapping == null)
			{
				linearMapping = base.gameObject.AddComponent<LinearMapping>();
			}
			worldPlaneNormal = new Vector3(0f, 0f, 0f);
			worldPlaneNormal[(int)axisOfRotation] = 1f;
			localPlaneNormal = worldPlaneNormal;
			if ((bool)base.transform.parent)
			{
				worldPlaneNormal = base.transform.parent.localToWorldMatrix.MultiplyVector(worldPlaneNormal).normalized;
			}
			if (limited)
			{
				start = Quaternion.identity;
				outAngle = base.transform.localEulerAngles[(int)axisOfRotation];
				if (forceStart)
				{
					outAngle = Mathf.Clamp(startAngle, minAngle, maxAngle);
				}
			}
			else
			{
				start = Quaternion.AngleAxis(base.transform.localEulerAngles[(int)axisOfRotation], localPlaneNormal);
				outAngle = 0f;
			}
			if ((bool)debugText)
			{
				debugText.alignment = TextAlignment.Left;
				debugText.anchor = TextAnchor.UpperLeft;
			}
			UpdateAll();
		}

		private void OnDisable()
		{
			if ((bool)handHoverLocked)
			{
				handHoverLocked.HideGrabHint();
				handHoverLocked.HoverUnlock(interactable);
				handHoverLocked = null;
			}
		}

		private IEnumerator HapticPulses(Hand hand, float flMagnitude, int nCount)
		{
			if (hand != null)
			{
				int nRangeMax = (int)Util.RemapNumberClamped(flMagnitude, 0f, 1f, 100f, 900f);
				nCount = Mathf.Clamp(nCount, 1, 10);
				ushort i = 0;
				while (i < nCount)
				{
					ushort microSecondsDuration = (ushort)UnityEngine.Random.Range(100, nRangeMax);
					hand.TriggerHapticPulse(microSecondsDuration);
					yield return new WaitForSeconds(0.01f);
					ushort num = (ushort)(i + 1);
					i = num;
				}
			}
		}

		private void OnHandHoverBegin(Hand hand)
		{
			hand.ShowGrabHint();
		}

		private void OnHandHoverEnd(Hand hand)
		{
			hand.HideGrabHint();
			if (driving && (bool)hand)
			{
				StartCoroutine(HapticPulses(hand, 1f, 10));
			}
			driving = false;
			handHoverLocked = null;
		}

		private void HandHoverUpdate(Hand hand)
		{
			GrabTypes grabStarting = hand.GetGrabStarting();
			bool flag = !hand.IsGrabbingWithType(grabbedWithType);
			if (grabbedWithType == GrabTypes.None && grabStarting != GrabTypes.None)
			{
				grabbedWithType = grabStarting;
				lastHandProjected = ComputeToTransformProjected(hand.hoverSphereTransform);
				if (hoverLock)
				{
					hand.HoverLock(interactable);
					handHoverLocked = hand;
				}
				driving = true;
				ComputeAngle(hand);
				UpdateAll();
				hand.HideGrabHint();
			}
			else if (grabbedWithType != GrabTypes.None && flag)
			{
				if (hoverLock)
				{
					hand.HoverUnlock(interactable);
					handHoverLocked = null;
				}
				driving = false;
				grabbedWithType = GrabTypes.None;
			}
			if (driving && !flag && hand.hoveringInteractable == interactable)
			{
				ComputeAngle(hand);
				UpdateAll();
			}
		}

		private Vector3 ComputeToTransformProjected(Transform xForm)
		{
			Vector3 normalized = (xForm.position - base.transform.position).normalized;
			Vector3 vector = new Vector3(0f, 0f, 0f);
			if (normalized.sqrMagnitude > 0f)
			{
				vector = Vector3.ProjectOnPlane(normalized, worldPlaneNormal).normalized;
			}
			else
			{
				UnityEngine.Debug.LogFormat("<b>[SteamVR Interaction]</b> The collider needs to be a minimum distance away from the CircularDrive GameObject {0}", base.gameObject.ToString());
			}
			if (debugPath && dbgPathLimit > 0)
			{
				DrawDebugPath(xForm, vector);
			}
			return vector;
		}

		private void DrawDebugPath(Transform xForm, Vector3 toTransformProjected)
		{
			if (dbgObjectCount == 0)
			{
				dbgObjectsParent = new GameObject("Circular Drive Debug");
				dbgHandObjects = new GameObject[dbgPathLimit];
				dbgProjObjects = new GameObject[dbgPathLimit];
				dbgObjectCount = dbgPathLimit;
				dbgObjectIndex = 0;
			}
			GameObject gameObject = null;
			if ((bool)dbgHandObjects[dbgObjectIndex])
			{
				gameObject = dbgHandObjects[dbgObjectIndex];
			}
			else
			{
				gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject.transform.SetParent(dbgObjectsParent.transform);
				dbgHandObjects[dbgObjectIndex] = gameObject;
			}
			gameObject.name = $"actual_{(int)((1f - red.r) * 10f)}";
			gameObject.transform.position = xForm.position;
			gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
			gameObject.gameObject.GetComponent<Renderer>().material.color = red;
			if (red.r > 0.1f)
			{
				red.r -= 0.1f;
			}
			else
			{
				red.r = 1f;
			}
			gameObject = null;
			if ((bool)dbgProjObjects[dbgObjectIndex])
			{
				gameObject = dbgProjObjects[dbgObjectIndex];
			}
			else
			{
				gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				gameObject.transform.SetParent(dbgObjectsParent.transform);
				dbgProjObjects[dbgObjectIndex] = gameObject;
			}
			gameObject.name = $"projed_{(int)((1f - green.g) * 10f)}";
			gameObject.transform.position = base.transform.position + toTransformProjected * 0.25f;
			gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
			gameObject.gameObject.GetComponent<Renderer>().material.color = green;
			if (green.g > 0.1f)
			{
				green.g -= 0.1f;
			}
			else
			{
				green.g = 1f;
			}
			dbgObjectIndex = (dbgObjectIndex + 1) % dbgObjectCount;
		}

		private void UpdateLinearMapping()
		{
			if (limited)
			{
				linearMapping.value = (outAngle - minAngle) / (maxAngle - minAngle);
			}
			else
			{
				float num = outAngle / 360f;
				linearMapping.value = num - Mathf.Floor(num);
			}
			UpdateDebugText();
		}

		private void UpdateGameObject()
		{
			if (rotateGameObject)
			{
				base.transform.localRotation = start * Quaternion.AngleAxis(outAngle, localPlaneNormal);
			}
		}

		private void UpdateDebugText()
		{
			if ((bool)debugText)
			{
				debugText.text = $"Linear: {linearMapping.value}\nAngle:  {outAngle}\n";
			}
		}

		private void UpdateAll()
		{
			UpdateLinearMapping();
			UpdateGameObject();
			UpdateDebugText();
		}

		private void ComputeAngle(Hand hand)
		{
			Vector3 vector = ComputeToTransformProjected(hand.hoverSphereTransform);
			if (vector.Equals(lastHandProjected))
			{
				return;
			}
			float num = Vector3.Angle(lastHandProjected, vector);
			if (!(num > 0f))
			{
				return;
			}
			if (frozen)
			{
				float sqrMagnitude = (hand.hoverSphereTransform.position - frozenHandWorldPos).sqrMagnitude;
				if (sqrMagnitude > frozenSqDistanceMinMaxThreshold.x)
				{
					outAngle = frozenAngle + UnityEngine.Random.Range(-1f, 1f);
					float num2 = Util.RemapNumberClamped(sqrMagnitude, frozenSqDistanceMinMaxThreshold.x, frozenSqDistanceMinMaxThreshold.y, 0f, 1f);
					if (num2 > 0f)
					{
						StartCoroutine(HapticPulses(hand, num2, 10));
					}
					else
					{
						StartCoroutine(HapticPulses(hand, 0.5f, 10));
					}
					if (sqrMagnitude >= frozenSqDistanceMinMaxThreshold.y)
					{
						onFrozenDistanceThreshold.Invoke();
					}
				}
				return;
			}
			Vector3 normalized = Vector3.Cross(lastHandProjected, vector).normalized;
			float num3 = Vector3.Dot(worldPlaneNormal, normalized);
			float num4 = num;
			if (num3 < 0f)
			{
				num4 = 0f - num4;
			}
			if (limited)
			{
				float num5 = Mathf.Clamp(outAngle + num4, minAngle, maxAngle);
				if (outAngle == minAngle)
				{
					if (num5 > minAngle && num < minMaxAngularThreshold)
					{
						outAngle = num5;
						lastHandProjected = vector;
					}
				}
				else if (outAngle == maxAngle)
				{
					if (num5 < maxAngle && num < minMaxAngularThreshold)
					{
						outAngle = num5;
						lastHandProjected = vector;
					}
				}
				else if (num5 == minAngle)
				{
					outAngle = num5;
					lastHandProjected = vector;
					onMinAngle.Invoke();
					if (freezeOnMin)
					{
						Freeze(hand);
					}
				}
				else if (num5 == maxAngle)
				{
					outAngle = num5;
					lastHandProjected = vector;
					onMaxAngle.Invoke();
					if (freezeOnMax)
					{
						Freeze(hand);
					}
				}
				else
				{
					outAngle = num5;
					lastHandProjected = vector;
				}
			}
			else
			{
				outAngle += num4;
				lastHandProjected = vector;
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class ComplexThrowable : MonoBehaviour
	{
		public enum AttachMode
		{
			FixedJoint,
			Force
		}

		public float attachForce = 800f;

		public float attachForceDamper = 25f;

		public AttachMode attachMode;

		[EnumFlags]
		public Hand.AttachmentFlags attachmentFlags;

		private List<Hand> holdingHands = new List<Hand>();

		private List<Rigidbody> holdingBodies = new List<Rigidbody>();

		private List<Vector3> holdingPoints = new List<Vector3>();

		private List<Rigidbody> rigidBodies = new List<Rigidbody>();

		private void Awake()
		{
			GetComponentsInChildren(rigidBodies);
		}

		private void Update()
		{
			for (int i = 0; i < holdingHands.Count; i++)
			{
				if (holdingHands[i].IsGrabEnding(base.gameObject))
				{
					PhysicsDetach(holdingHands[i]);
				}
			}
		}

		private void OnHandHoverBegin(Hand hand)
		{
			if (holdingHands.IndexOf(hand) == -1 && hand.isActive)
			{
				hand.TriggerHapticPulse(800);
			}
		}

		private void OnHandHoverEnd(Hand hand)
		{
			if (holdingHands.IndexOf(hand) == -1 && hand.isActive)
			{
				hand.TriggerHapticPulse(500);
			}
		}

		private void HandHoverUpdate(Hand hand)
		{
			GrabTypes grabStarting = hand.GetGrabStarting();
			if (grabStarting != GrabTypes.None)
			{
				PhysicsAttach(hand, grabStarting);
			}
		}

		private void PhysicsAttach(Hand hand, GrabTypes startingGrabType)
		{
			PhysicsDetach(hand);
			Rigidbody rigidbody = null;
			Vector3 zero = Vector3.zero;
			float num = float.MaxValue;
			for (int i = 0; i < rigidBodies.Count; i++)
			{
				float num2 = Vector3.Distance(rigidBodies[i].worldCenterOfMass, hand.transform.position);
				if (num2 < num)
				{
					rigidbody = rigidBodies[i];
					num = num2;
				}
			}
			if (!(rigidbody == null))
			{
				if (attachMode == AttachMode.FixedJoint)
				{
					Util.FindOrAddComponent<Rigidbody>(hand.gameObject).isKinematic = true;
					hand.gameObject.AddComponent<FixedJoint>().connectedBody = rigidbody;
				}
				hand.HoverLock(null);
				Vector3 vector = hand.transform.position - rigidbody.worldCenterOfMass;
				vector = Mathf.Min(vector.magnitude, 1f) * vector.normalized;
				zero = rigidbody.transform.InverseTransformPoint(rigidbody.worldCenterOfMass + vector);
				hand.AttachObject(base.gameObject, startingGrabType, attachmentFlags);
				holdingHands.Add(hand);
				holdingBodies.Add(rigidbody);
				holdingPoints.Add(zero);
			}
		}

		private bool PhysicsDetach(Hand hand)
		{
			int num = holdingHands.IndexOf(hand);
			if (num != -1)
			{
				holdingHands[num].DetachObject(base.gameObject, restoreOriginalParent: false);
				holdingHands[num].HoverUnlock(null);
				if (attachMode == AttachMode.FixedJoint)
				{
					UnityEngine.Object.Destroy(holdingHands[num].GetComponent<FixedJoint>());
				}
				Util.FastRemove(holdingHands, num);
				Util.FastRemove(holdingBodies, num);
				Util.FastRemove(holdingPoints, num);
				return true;
			}
			return false;
		}

		private void FixedUpdate()
		{
			if (attachMode == AttachMode.Force)
			{
				for (int i = 0; i < holdingHands.Count; i++)
				{
					Vector3 vector = holdingBodies[i].transform.TransformPoint(holdingPoints[i]);
					Vector3 vector2 = holdingHands[i].transform.position - vector;
					holdingBodies[i].AddForceAtPosition(attachForce * vector2 * holdingBodies[i].mass, vector, ForceMode.Force);
					holdingBodies[i].AddForceAtPosition((0f - attachForceDamper) * holdingBodies[i].GetPointVelocity(vector) * holdingBodies[i].mass, vector, ForceMode.Force);
				}
			}
		}
	}
	public class ControllerHoverHighlight : MonoBehaviour
	{
		public Material highLightMaterial;

		public bool fireHapticsOnHightlight = true;

		protected Hand hand;

		protected RenderModel renderModel;

		protected SteamVR_Events.Action renderModelLoadedAction;

		protected void Awake()
		{
			hand = GetComponentInParent<Hand>();
		}

		protected void OnHandInitialized(int deviceIndex)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(hand.renderModelPrefab);
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = hand.renderModelPrefab.transform.localScale;
			renderModel = gameObject.GetComponent<RenderModel>();
			renderModel.SetInputSource(hand.handType);
			renderModel.OnHandInitialized(deviceIndex);
			renderModel.SetMaterial(highLightMaterial);
			hand.SetHoverRenderModel(renderModel);
			renderModel.onControllerLoaded += RenderModel_onControllerLoaded;
			renderModel.Hide();
		}

		private void RenderModel_onControllerLoaded()
		{
			renderModel.Hide();
		}

		protected void OnParentHandHoverBegin(Interactable other)
		{
			if (base.isActiveAndEnabled && other.transform.parent != base.transform.parent)
			{
				ShowHighlight();
			}
		}

		private void OnParentHandHoverEnd(Interactable other)
		{
			HideHighlight();
		}

		private void OnParentHandInputFocusAcquired()
		{
			if (base.isActiveAndEnabled && (bool)hand.hoveringInteractable && hand.hoveringInteractable.transform.parent != base.transform.parent)
			{
				ShowHighlight();
			}
		}

		private void OnParentHandInputFocusLost()
		{
			HideHighlight();
		}

		public void ShowHighlight()
		{
			if (!(renderModel == null))
			{
				if (fireHapticsOnHightlight)
				{
					hand.TriggerHapticPulse(500);
				}
				renderModel.Show();
			}
		}

		public void HideHighlight()
		{
			if (!(renderModel == null))
			{
				if (fireHapticsOnHightlight)
				{
					hand.TriggerHapticPulse(300);
				}
				renderModel.Hide();
			}
		}
	}
	public static class CustomEvents
	{
		[Serializable]
		public class UnityEventSingleFloat : UnityEvent<float>
		{
		}

		[Serializable]
		public class UnityEventHand : UnityEvent<Hand>
		{
		}
	}
	public class DebugUI : MonoBehaviour
	{
		private Player player;

		private static DebugUI _instance;

		public static DebugUI instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindObjectOfType<DebugUI>();
				}
				return _instance;
			}
		}

		private void Start()
		{
			player = Player.instance;
		}

		private void OnGUI()
		{
			if (UnityEngine.Debug.isDebugBuild)
			{
				player.Draw2DDebug();
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class DestroyOnDetachedFromHand : MonoBehaviour
	{
		private void OnDetachedFromHand(Hand hand)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
	[RequireComponent(typeof(ParticleSystem))]
	public class DestroyOnParticleSystemDeath : MonoBehaviour
	{
		private ParticleSystem particles;

		private void Awake()
		{
			particles = GetComponent<ParticleSystem>();
			InvokeRepeating("CheckParticleSystem", 0.1f, 0.1f);
		}

		private void CheckParticleSystem()
		{
			if (!particles.IsAlive())
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
	public class DestroyOnTriggerEnter : MonoBehaviour
	{
		public string tagFilter;

		private bool useTag;

		private void Start()
		{
			if (!string.IsNullOrEmpty(tagFilter))
			{
				useTag = true;
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			if (!useTag || (useTag && collider.gameObject.tag == tagFilter))
			{
				UnityEngine.Object.Destroy(collider.gameObject.transform.root.gameObject);
			}
		}
	}
	public class DistanceHaptics : MonoBehaviour
	{
		public Transform firstTransform;

		public Transform secondTransform;

		public AnimationCurve distanceIntensityCurve = AnimationCurve.Linear(0f, 800f, 1f, 800f);

		public AnimationCurve pulseIntervalCurve = AnimationCurve.Linear(0f, 0.01f, 1f, 0f);

		private IEnumerator Start()
		{
			while (true)
			{
				float time = Vector3.Distance(firstTransform.position, secondTransform.position);
				Hand componentInParent = GetComponentInParent<Hand>();
				if (componentInParent != null)
				{
					float num = distanceIntensityCurve.Evaluate(time);
					componentInParent.TriggerHapticPulse((ushort)num);
				}
				float seconds = pulseIntervalCurve.Evaluate(time);
				yield return new WaitForSeconds(seconds);
			}
		}
	}
	public class DontDestroyOnLoad : MonoBehaviour
	{
		private void Awake()
		{
			UnityEngine.Object.DontDestroyOnLoad(this);
		}
	}
	public class EnumFlags : PropertyAttribute
	{
	}
	public enum WhichHand
	{
		Left,
		Right
	}
	[RequireComponent(typeof(Throwable))]
	public class Equippable : MonoBehaviour
	{
		[Tooltip("Array of children you do not want to be mirrored. Text, logos, etc.")]
		public Transform[] antiFlip;

		public WhichHand defaultHand = WhichHand.Right;

		private Vector3 initialScale;

		private Interactable interactable;

		[HideInInspector]
		public SteamVR_Input_Sources attachedHandType
		{
			get
			{
				if ((bool)interactable.attachedToHand)
				{
					return interactable.attachedToHand.handType;
				}
				return SteamVR_Input_Sources.Any;
			}
		}

		private void Start()
		{
			initialScale = base.transform.localScale;
			interactable = GetComponent<Interactable>();
		}

		private void Update()
		{
			if (!interactable.attachedToHand)
			{
				return;
			}
			Vector3 localScale = initialScale;
			if ((attachedHandType == SteamVR_Input_Sources.RightHand && defaultHand == WhichHand.Right) || (attachedHandType == SteamVR_Input_Sources.LeftHand && defaultHand == WhichHand.Left))
			{
				localScale.x *= 1f;
				for (int i = 0; i < antiFlip.Length; i++)
				{
					antiFlip[i].localScale = new Vector3(1f, 1f, 1f);
				}
			}
			else
			{
				localScale.x *= -1f;
				for (int j = 0; j < antiFlip.Length; j++)
				{
					antiFlip[j].localScale = new Vector3(-1f, 1f, 1f);
				}
			}
			base.transform.localScale = localScale;
		}
	}
	[RequireComponent(typeof(Camera))]
	public class FallbackCameraController : MonoBehaviour
	{
		public float speed = 4f;

		public float shiftSpeed = 16f;

		public bool showInstructions = true;

		private Vector3 startEulerAngles;

		private Vector3 startMousePosition;

		private float realTime;

		private void OnEnable()
		{
			realTime = Time.realtimeSinceStartup;
		}

		private void Update()
		{
			float num = 0f;
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				num += 1f;
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				num -= 1f;
			}
			float num2 = 0f;
			if (Input.GetKey(KeyCode.E))
			{
				num2 += 1f;
			}
			if (Input.GetKey(KeyCode.Q))
			{
				num2 -= 1f;
			}
			float num3 = 0f;
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				num3 += 1f;
			}
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				num3 -= 1f;
			}
			float num4 = speed;
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				num4 = shiftSpeed;
			}
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float num5 = realtimeSinceStartup - realTime;
			realTime = realtimeSinceStartup;
			Vector3 direction = new Vector3(num3, num2, num) * num4 * num5;
			base.transform.position += base.transform.TransformDirection(direction);
			Vector3 mousePosition = Input.mousePosition;
			if (Input.GetMouseButtonDown(1))
			{
				startMousePosition = mousePosition;
				startEulerAngles = base.transform.localEulerAngles;
			}
			if (Input.GetMouseButton(1))
			{
				Vector3 vector = mousePosition - startMousePosition;
				base.transform.localEulerAngles = startEulerAngles + new Vector3((0f - vector.y) * 360f / (float)Screen.height, vector.x * 360f / (float)Screen.width, 0f);
			}
		}

		private void OnGUI()
		{
			if (showInstructions)
			{
				GUI.Label(new Rect(10f, 10f, 600f, 400f), "WASD EQ/Arrow Keys to translate the camera\nRight mouse click to rotate the camera\nLeft mouse click for standard interactions.\n");
			}
		}
	}
	public enum GrabTypes
	{
		None,
		Trigger,
		Pinch,
		Grip,
		Scripted
	}
	public class Hand : MonoBehaviour
	{
		[Flags]
		public enum AttachmentFlags
		{
			SnapOnAttach = 1,
			DetachOthers = 2,
			DetachFromOtherHand = 4,
			ParentToHand = 8,
			VelocityMovement = 0x10,
			TurnOnKinematic = 0x20,
			TurnOffGravity = 0x40,
			AllowSidegrade = 0x80
		}

		public struct AttachedObject
		{
			public GameObject attachedObject;

			public Interactable interactable;

			public Rigidbody attachedRigidbody;

			public CollisionDetectionMode collisionDetectionMode;

			public bool attachedRigidbodyWasKinematic;

			public bool attachedRigidbodyUsedGravity;

			public GameObject originalParent;

			public bool isParentedToHand;

			public GrabTypes grabbedWithType;

			public AttachmentFlags attachmentFlags;

			public Vector3 initialPositionalOffset;

			public Quaternion initialRotationalOffset;

			public Transform attachedOffsetTransform;

			public Transform handAttachmentPointTransform;

			public Vector3 easeSourcePosition;

			public Quaternion easeSourceRotation;

			public float attachTime;

			public AllowTeleportWhileAttachedToHand allowTeleportWhileAttachedToHand;

			public bool HasAttachFlag(AttachmentFlags flag)
			{
				return (attachmentFlags & flag) == flag;
			}
		}

		public const AttachmentFlags defaultAttachmentFlags = AttachmentFlags.SnapOnAttach | AttachmentFlags.DetachOthers | AttachmentFlags.DetachFromOtherHand | AttachmentFlags.ParentToHand | AttachmentFlags.TurnOnKinematic;

		public Hand otherHand;

		public SteamVR_Input_Sources handType;

		public SteamVR_Behaviour_Pose trackedObject;

		public SteamVR_Action_Boolean grabPinchAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");

		public SteamVR_Action_Boolean grabGripAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabGrip");

		public SteamVR_Action_Vibration hapticAction = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");

		public SteamVR_Action_Boolean uiInteractAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

		public bool useHoverSphere = true;

		public Transform hoverSphereTransform;

		public float hoverSphereRadius = 0.05f;

		public LayerMask hoverLayerMask = -1;

		public float hoverUpdateInterval = 0.1f;

		public bool useControllerHoverComponent = true;

		public string controllerHoverComponent = "tip";

		public float controllerHoverRadius = 0.075f;

		public bool useFingerJointHover = true;

		public SteamVR_Skeleton_JointIndexEnum fingerJointHover = SteamVR_Skeleton_JointIndexEnum.indexTip;

		public float fingerJointHoverRadius = 0.025f;

		[Tooltip("A transform on the hand to center attached objects on")]
		public Transform objectAttachmentPoint;

		public Camera noSteamVRFallbackCamera;

		public float noSteamVRFallbackMaxDistanceNoItem = 10f;

		public float noSteamVRFallbackMaxDistanceWithItem = 0.5f;

		private float noSteamVRFallbackInteractorDistance = -1f;

		public GameObject renderModelPrefab;

		[HideInInspector]
		public List<RenderModel> renderModels = new List<RenderModel>();

		[HideInInspector]
		public RenderModel mainRenderModel;

		[HideInInspector]
		public RenderModel hoverhighlightRenderModel;

		public bool showDebugText;

		public bool spewDebugText;

		public bool showDebugInteractables;

		private List<AttachedObject> attachedObjects = new List<AttachedObject>();

		private Interactable _hoveringInteractable;

		private TextMesh debugText;

		private int prevOverlappingColliders;

		private const int ColliderArraySize = 32;

		private Collider[] overlappingColliders;

		private Player playerInstance;

		private GameObject applicationLostFocusObject;

		private SteamVR_Events.Action inputFocusAction;

		protected const float MaxVelocityChange = 10f;

		protected const float VelocityMagic = 6000f;

		protected const float AngularVelocityMagic = 50f;

		protected const float MaxAngularVelocityChange = 20f;

		public ReadOnlyCollection<AttachedObject> AttachedObjects => attachedObjects.AsReadOnly();

		public bool hoverLocked { get; private set; }

		public bool isActive
		{
			get
			{
				if (trackedObject != null)
				{
					return trackedObject.isActive;
				}
				return base.gameObject.activeInHierarchy;
			}
		}

		public bool isPoseValid => trackedObject.isValid;

		public Interactable hoveringInteractable
		{
			get
			{
				return _hoveringInteractable;
			}
			set
			{
				if (!(_hoveringInteractable != value))
				{
					return;
				}
				if (_hoveringInteractable != null)
				{
					if (spewDebugText)
					{
						HandDebugLog("HoverEnd " + _hoveringInteractable.gameObject);
					}
					_hoveringInteractable.SendMessage("OnHandHoverEnd", this, SendMessageOptions.DontRequireReceiver);
					if (_hoveringInteractable != null)
					{
						BroadcastMessage("OnParentHandHoverEnd", _hoveringInteractable, SendMessageOptions.DontRequireReceiver);
					}
				}
				_hoveringInteractable = value;
				if (_hoveringInteractable != null)
				{
					if (spewDebugText)
					{
						HandDebugLog("HoverBegin " + _hoveringInteractable.gameObject);
					}
					_hoveringInteractable.SendMessage("OnHandHoverBegin", this, SendMessageOptions.DontRequireReceiver);
					if (_hoveringInteractable != null)
					{
						BroadcastMessage("OnParentHandHoverBegin", _hoveringInteractable, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}

		public GameObject currentAttachedObject
		{
			get
			{
				CleanUpAttachedObjectStack();
				if (attachedObjects.Count > 0)
				{
					return attachedObjects[attachedObjects.Count - 1].attachedObject;
				}
				return null;
			}
		}

		public AttachedObject? currentAttachedObjectInfo
		{
			get
			{
				CleanUpAttachedObjectStack();
				if (attachedObjects.Count > 0)
				{
					return attachedObjects[attachedObjects.Count - 1];
				}
				return null;
			}
		}

		public AllowTeleportWhileAttachedToHand currentAttachedTeleportManager
		{
			get
			{
				if (currentAttachedObjectInfo.HasValue)
				{
					return currentAttachedObjectInfo.Value.allowTeleportWhileAttachedToHand;
				}
				return null;
			}
		}

		public SteamVR_Behaviour_Skeleton skeleton
		{
			get
			{
				if (mainRenderModel != null)
				{
					return mainRenderModel.GetSkeleton();
				}
				return null;
			}
		}

		public void ShowController(bool permanent = false)
		{
			if (mainRenderModel != null)
			{
				mainRenderModel.SetControllerVisibility(state: true, permanent);
			}
			if (hoverhighlightRenderModel != null)
			{
				hoverhighlightRenderModel.SetControllerVisibility(state: true, permanent);
			}
		}

		public void HideController(bool permanent = false)
		{
			if (mainRenderModel != null)
			{
				mainRenderModel.SetControllerVisibility(state: false, permanent);
			}
			if (hoverhighlightRenderModel != null)
			{
				hoverhighlightRenderModel.SetControllerVisibility(state: false, permanent);
			}
		}

		public void ShowSkeleton(bool permanent = false)
		{
			if (mainRenderModel != null)
			{
				mainRenderModel.SetHandVisibility(state: true, permanent);
			}
			if (hoverhighlightRenderModel != null)
			{
				hoverhighlightRenderModel.SetHandVisibility(state: true, permanent);
			}
		}

		public void HideSkeleton(bool permanent = false)
		{
			if (mainRenderModel != null)
			{
				mainRenderModel.SetHandVisibility(state: false, permanent);
			}
			if (hoverhighlightRenderModel != null)
			{
				hoverhighlightRenderModel.SetHandVisibility(state: false, permanent);
			}
		}

		public bool HasSkeleton()
		{
			if (mainRenderModel != null)
			{
				return mainRenderModel.GetSkeleton() != null;
			}
			return false;
		}

		public void Show()
		{
			SetVisibility(visible: true);
		}

		public void Hide()
		{
			SetVisibility(visible: false);
		}

		public void SetVisibility(bool visible)
		{
			if (mainRenderModel != null)
			{
				mainRenderModel.SetVisibility(visible);
			}
		}

		public void SetSkeletonRangeOfMotion(EVRSkeletalMotionRange newRangeOfMotion, float blendOverSeconds = 0.1f)
		{
			for (int i = 0; i < renderModels.Count; i++)
			{
				renderModels[i].SetSkeletonRangeOfMotion(newRangeOfMotion, blendOverSeconds);
			}
		}

		public void SetTemporarySkeletonRangeOfMotion(SkeletalMotionRangeChange temporaryRangeOfMotionChange, float blendOverSeconds = 0.1f)
		{
			for (int i = 0; i < renderModels.Count; i++)
			{
				renderModels[i].SetTemporarySkeletonRangeOfMotion(temporaryRangeOfMotionChange, blendOverSeconds);
			}
		}

		public void ResetTemporarySkeletonRangeOfMotion(float blendOverSeconds = 0.1f)
		{
			for (int i = 0; i < renderModels.Count; i++)
			{
				renderModels[i].ResetTemporarySkeletonRangeOfMotion(blendOverSeconds);
			}
		}

		public void SetAnimationState(int stateValue)
		{
			for (int i = 0; i < renderModels.Count; i++)
			{
				renderModels[i].SetAnimationState(stateValue);
			}
		}

		public void StopAnimation()
		{
			for (int i = 0; i < renderModels.Count; i++)
			{
				renderModels[i].StopAnimation();
			}
		}

		public void AttachObject(GameObject objectToAttach, GrabTypes grabbedWithType, AttachmentFlags flags = AttachmentFlags.SnapOnAttach | AttachmentFlags.DetachOthers | AttachmentFlags.DetachFromOtherHand | AttachmentFlags.ParentToHand | AttachmentFlags.TurnOnKinematic, Transform attachmentOffset = null)
		{
			AttachedObject item = new AttachedObject
			{
				attachmentFlags = flags,
				attachedOffsetTransform = attachmentOffset,
				attachTime = Time.time
			};
			if (flags == (AttachmentFlags)0)
			{
				flags = AttachmentFlags.SnapOnAttach | AttachmentFlags.DetachOthers | AttachmentFlags.DetachFromOtherHand | AttachmentFlags.ParentToHand | AttachmentFlags.TurnOnKinematic;
			}
			CleanUpAttachedObjectStack();
			if (ObjectIsAttached(objectToAttach))
			{
				DetachObject(objectToAttach);
			}
			if (item.HasAttachFlag(AttachmentFlags.DetachFromOtherHand) && otherHand != null)
			{
				otherHand.DetachObject(objectToAttach);
			}
			if (item.HasAttachFlag(AttachmentFlags.DetachOthers))
			{
				while (attachedObjects.Count > 0)
				{
					DetachObject(attachedObjects[0].attachedObject);
				}
			}
			if ((bool)currentAttachedObject)
			{
				currentAttachedObject.SendMessage("OnHandFocusLost", this, SendMessageOptions.DontRequireReceiver);
			}
			item.attachedObject = objectToAttach;
			item.interactable = objectToAttach.GetComponent<Interactable>();
			item.allowTeleportWhileAttachedToHand = objectToAttach.GetComponent<AllowTeleportWhileAttachedToHand>();
			item.handAttachmentPointTransform = base.transform;
			if (item.interactable != null)
			{
				if (item.interactable.attachEaseIn)
				{
					item.easeSourcePosition = item.attachedObject.transform.position;
					item.easeSourceRotation = item.attachedObject.transform.rotation;
					item.interactable.snapAttachEaseInCompleted = false;
				}
				if (item.interactable.useHandObjectAttachmentPoint)
				{
					item.handAttachmentPointTransform = objectAttachmentPoint;
				}
				if (item.interactable.hideHandOnAttach)
				{
					Hide();
				}
				if (item.interactable.hideSkeletonOnAttach && mainRenderModel != null && mainRenderModel.displayHandByDefault)
				{
					HideSkeleton();
				}
				if (item.interactable.hideControllerOnAttach && mainRenderModel != null && mainRenderModel.displayControllerByDefault)
				{
					HideController();
				}
				if (item.interactable.handAnimationOnPickup != 0)
				{
					SetAnimationState(item.interactable.handAnimationOnPickup);
				}
				if (item.interactable.setRangeOfMotionOnPickup != SkeletalMotionRangeChange.None)
				{
					SetTemporarySkeletonRangeOfMotion(item.interactable.setRangeOfMotionOnPickup);
				}
			}
			item.originalParent = ((objectToAttach.transform.parent != null) ? objectToAttach.transform.parent.gameObject : null);
			item.attachedRigidbody = objectToAttach.GetComponent<Rigidbody>();
			if (item.attachedRigidbody != null)
			{
				if (item.interactable.attachedToHand != null)
				{
					for (int i = 0; i < item.interactable.attachedToHand.attachedObjects.Count; i++)
					{
						AttachedObject attachedObject = item.interactable.attachedToHand.attachedObjects[i];
						if (attachedObject.interactable == item.interactable)
						{
							item.attachedRigidbodyWasKinematic = attachedObject.attachedRigidbodyWasKinematic;
							item.attachedRigidbodyUsedGravity = attachedObject.attachedRigidbodyUsedGravity;
							item.originalParent = attachedObject.originalParent;
						}
					}
				}
				else
				{
					item.attachedRigidbodyWasKinematic = item.attachedRigidbody.isKinematic;
					item.attachedRigidbodyUsedGravity = item.attachedRigidbody.useGravity;
				}
			}
			item.grabbedWithType = grabbedWithType;
			if (item.HasAttachFlag(AttachmentFlags.ParentToHand))
			{
				objectToAttach.transform.parent = base.transform;
				item.isParentedToHand = true;
			}
			else
			{
				item.isParentedToHand = false;
			}
			if (item.HasAttachFlag(AttachmentFlags.SnapOnAttach))
			{
				if (item.interactable != null && item.interactable.skeletonPoser != null && HasSkeleton())
				{
					SteamVR_Skeleton_PoseSnapshot blendedPose = item.interactable.skeletonPoser.GetBlendedPose(skeleton);
					objectToAttach.transform.position = base.transform.TransformPoint(blendedPose.position);
					objectToAttach.transform.rotation = base.transform.rotation * blendedPose.rotation;
					item.initialPositionalOffset = item.handAttachmentPointTransform.InverseTransformPoint(objectToAttach.transform.position);
					item.initialRotationalOffset = Quaternion.Inverse(item.handAttachmentPointTransform.rotation) * objectToAttach.transform.rotation;
				}
				else
				{
					if (attachmentOffset != null)
					{
						Quaternion quaternion = Quaternion.Inverse(attachmentOffset.transform.rotation) * objectToAttach.transform.rotation;
						objectToAttach.transform.rotation = item.handAttachmentPointTransform.rotation * quaternion;
						Vector3 vector = objectToAttach.transform.position - attachmentOffset.transform.position;
						objectToAttach.transform.position = item.handAttachmentPointTransform.position + vector;
					}
					else
					{
						objectToAttach.transform.rotation = item.handAttachmentPointTransform.rotation;
						objectToAttach.transform.position = item.handAttachmentPointTransform.position;
					}
					Transform transform = objectToAttach.transform;
					item.initialPositionalOffset = item.handAttachmentPointTransform.InverseTransformPoint(transform.position);
					item.initialRotationalOffset = Quaternion.Inverse(item.handAttachmentPointTransform.rotation) * transform.rotation;
				}
			}
			else if (item.interactable != null && item.interactable.skeletonPoser != null && HasSkeleton())
			{
				item.initialPositionalOffset = item.handAttachmentPointTransform.InverseTransformPoint(objectToAttach.transform.position);
				item.initialRotationalOffset = Quaternion.Inverse(item.handAttachmentPointTransform.rotation) * objectToAttach.transform.rotation;
			}
			else if (attachmentOffset != null)
			{
				Quaternion quaternion2 = Quaternion.Inverse(attachmentOffset.transform.rotation) * objectToAttach.transform.rotation;
				Quaternion quaternion3 = item.handAttachmentPointTransform.rotation * quaternion2 * Quaternion.Inverse(objectToAttach.transform.rotation);
				Vector3 vector2 = quaternion3 * objectToAttach.transform.position - quaternion3 * attachmentOffset.transform.position;
				item.initialPositionalOffset = item.handAttachmentPointTransform.InverseTransformPoint(item.handAttachmentPointTransform.position + vector2);
				item.initialRotationalOffset = Quaternion.Inverse(item.handAttachmentPointTransform.rotation) * (item.handAttachmentPointTransform.rotation * quaternion2);
			}
			else
			{
				item.initialPositionalOffset = item.handAttachmentPointTransform.InverseTransformPoint(objectToAttach.transform.position);
				item.initialRotationalOffset = Quaternion.Inverse(item.handAttachmentPointTransform.rotation) * objectToAttach.transform.rotation;
			}
			if (item.HasAttachFlag(AttachmentFlags.TurnOnKinematic) && item.attachedRigidbody != null)
			{
				item.collisionDetectionMode = item.attachedRigidbody.collisionDetectionMode;
				if (item.collisionDetectionMode == CollisionDetectionMode.Continuous)
				{
					item.attachedRigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
				}
				item.attachedRigidbody.isKinematic = true;
			}
			if (item.HasAttachFlag(AttachmentFlags.TurnOffGravity) && item.attachedRigidbody != null)
			{
				item.attachedRigidbody.useGravity = false;
			}
			if (item.interactable != null && item.interactable.attachEaseIn)
			{
				item.attachedObject.transform.position = item.easeSourcePosition;
				item.attachedObject.transform.rotation = item.easeSourceRotation;
			}
			attachedObjects.Add(item);
			UpdateHovering();
			if (spewDebugText)
			{
				HandDebugLog("AttachObject " + objectToAttach);
			}
			objectToAttach.SendMessage("OnAttachedToHand", this, SendMessageOptions.DontRequireReceiver);
		}

		public bool ObjectIsAttached(GameObject go)
		{
			for (int i = 0; i < attachedObjects.Count; i++)
			{
				if (attachedObjects[i].attachedObject == go)
				{
					return true;
				}
			}
			return false;
		}

		public void ForceHoverUnlock()
		{
			hoverLocked = false;
		}

		public void DetachObject(GameObject objectToDetach, bool restoreOriginalParent = true)
		{
			int num = attachedObjects.FindIndex((AttachedObject l) => l.attachedObject == objectToDetach);
			if (num != -1)
			{
				if (spewDebugText)
				{
					HandDebugLog("DetachObject " + objectToDetach);
				}
				GameObject gameObject = currentAttachedObject;
				if (attachedObjects[num].interactable != null)
				{
					if (attachedObjects[num].interactable.hideHandOnAttach)
					{
						Show();
					}
					if (attachedObjects[num].interactable.hideSkeletonOnAttach && mainRenderModel != null && mainRenderModel.displayHandByDefault)
					{
						ShowSkeleton();
					}
					if (attachedObjects[num].interactable.hideControllerOnAttach && mainRenderModel != null && mainRenderModel.displayControllerByDefault)
					{
						ShowController();
					}
					if (attachedObjects[num].interactable.handAnimationOnPickup != 0)
					{
						StopAnimation();
					}
					if (attachedObjects[num].interactable.setRangeOfMotionOnPickup != SkeletalMotionRangeChange.None)
					{
						ResetTemporarySkeletonRangeOfMotion();
					}
				}
				Transform parent = null;
				if (attachedObjects[num].isParentedToHand)
				{
					if (restoreOriginalParent && attachedObjects[num].originalParent != null)
					{
						parent = attachedObjects[num].originalParent.transform;
					}
					if (attachedObjects[num].attachedObject != null)
					{
						attachedObjects[num].attachedObject.transform.parent = parent;
					}
				}
				if (attachedObjects[num].HasAttachFlag(AttachmentFlags.TurnOnKinematic) && attachedObjects[num].attachedRigidbody != null)
				{
					attachedObjects[num].attachedRigidbody.isKinematic = attachedObjects[num].attachedRigidbodyWasKinematic;
					attachedObjects[num].attachedRigidbody.collisionDetectionMode = attachedObjects[num].collisionDetectionMode;
				}
				if (attachedObjects[num].HasAttachFlag(AttachmentFlags.TurnOffGravity) && attachedObjects[num].attachedObject != null && attachedObjects[num].attachedRigidbody != null)
				{
					attachedObjects[num].attachedRigidbody.useGravity = attachedObjects[num].attachedRigidbodyUsedGravity;
				}
				if (attachedObjects[num].interactable != null && attachedObjects[num].interactable.handFollowTransform && HasSkeleton())
				{
					skeleton.transform.localPosition = Vector3.zero;
					skeleton.transform.localRotation = Quaternion.identity;
				}
				if (attachedObjects[num].attachedObject != null)
				{
					if (attachedObjects[num].interactable == null || (attachedObjects[num].interactable != null && !attachedObjects[num].interactable.isDestroying))
					{
						attachedObjects[num].attachedObject.SetActive(value: true);
					}
					attachedObjects[num].attachedObject.SendMessage("OnDetachedFromHand", this, SendMessageOptions.DontRequireReceiver);
				}
				attachedObjects.RemoveAt(num);
				CleanUpAttachedObjectStack();
				GameObject gameObject2 = currentAttachedObject;
				hoverLocked = false;
				if (gameObject2 != null && gameObject2 != gameObject)
				{
					gameObject2.SetActive(value: true);
					gameObject2.SendMessage("OnHandFocusAcquired", this, SendMessageOptions.DontRequireReceiver);
				}
			}
			CleanUpAttachedObjectStack();
			if (mainRenderModel != null)
			{
				mainRenderModel.MatchHandToTransform(mainRenderModel.transform);
			}
			if (hoverhighlightRenderModel != null)
			{
				hoverhighlightRenderModel.MatchHandToTransform(hoverhighlightRenderModel.transform);
			}
		}

		public Vector3 GetTrackedObjectVelocity(float timeOffset = 0f)
		{
			if (trackedObject == null)
			{
				GetUpdatedAttachedVelocities(currentAttachedObjectInfo.Value, out var velocityTarget, out var _);
				return velocityTarget;
			}
			if (isActive)
			{
				if (timeOffset == 0f)
				{
					return Player.instance.trackingOriginTransform.TransformVector(trackedObject.GetVelocity());
				}
				trackedObject.GetVelocitiesAtTimeOffset(timeOffset, out var velocity, out var _);
				return Player.instance.trackingOriginTransform.TransformVector(velocity);
			}
			return Vector3.zero;
		}

		public Vector3 GetTrackedObjectAngularVelocity(float timeOffset = 0f)
		{
			if (trackedObject == null)
			{
				GetUpdatedAttachedVelocities(currentAttachedObjectInfo.Value, out var _, out var angularTarget);
				return angularTarget;
			}
			if (isActive)
			{
				if (timeOffset == 0f)
				{
					return Player.instance.trackingOriginTransform.TransformDirection(trackedObject.GetAngularVelocity());
				}
				trackedObject.GetVelocitiesAtTimeOffset(timeOffset, out var _, out var angularVelocity);
				return Player.instance.trackingOriginTransform.TransformDirection(angularVelocity);
			}
			return Vector3.zero;
		}

		public void GetEstimatedPeakVelocities(out Vector3 velocity, out Vector3 angularVelocity)
		{
			trackedObject.GetEstimatedPeakVelocities(out velocity, out angularVelocity);
			velocity = Player.instance.trackingOriginTransform.TransformVector(velocity);
			angularVelocity = Player.instance.trackingOriginTransform.TransformDirection(angularVelocity);
		}

		private void CleanUpAttachedObjectStack()
		{
			attachedObjects.RemoveAll((AttachedObject l) => l.attachedObject == null);
		}

		protected virtual void Awake()
		{
			inputFocusAction = SteamVR_Events.InputFocusAction(OnInputFocus);
			if (hoverSphereTransform == null)
			{
				hoverSphereTransform = base.transform;
			}
			if (objectAttachmentPoint == null)
			{
				objectAttachmentPoint = base.transform;
			}
			applicationLostFocusObject = new GameObject("_application_lost_focus");
			applicationLostFocusObject.transform.parent = base.transform;
			applicationLostFocusObject.SetActive(value: false);
			if (trackedObject == null)
			{
				trackedObject = base.gameObject.GetComponent<SteamVR_Behaviour_Pose>();
				if (trackedObject != null)
				{
					SteamVR_Behaviour_Pose steamVR_Behaviour_Pose = trackedObject;
					steamVR_Behaviour_Pose.onTransformUpdatedEvent = (SteamVR_Behaviour_Pose.UpdateHandler)Delegate.Combine(steamVR_Behaviour_Pose.onTransformUpdatedEvent, new SteamVR_Behaviour_Pose.UpdateHandler(OnTransformUpdated));
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (trackedObject != null)
			{
				SteamVR_Behaviour_Pose steamVR_Behaviour_Pose = trackedObject;
				steamVR_Behaviour_Pose.onTransformUpdatedEvent = (SteamVR_Behaviour_Pose.UpdateHandler)Delegate.Remove(steamVR_Behaviour_Pose.onTransformUpdatedEvent, new SteamVR_Behaviour_Pose.UpdateHandler(OnTransformUpdated));
			}
		}

		protected virtual void OnTransformUpdated(SteamVR_Behaviour_Pose updatedPose, SteamVR_Input_Sources updatedSource)
		{
			HandFollowUpdate();
		}

		protected virtual IEnumerator Start()
		{
			playerInstance = Player.instance;
			if (!playerInstance)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> No player instance found in Hand Start()", this);
			}
			if (base.gameObject.layer == 0)
			{
				UnityEngine.Debug.LogWarning("<b>[SteamVR Interaction]</b> Hand is on default layer. This puts unnecessary strain on hover checks as it is always true for hand colliders (which are then ignored).", this);
			}
			else
			{
				hoverLayerMask = (int)hoverLayerMask & ~(1 << base.gameObject.layer);
			}
			overlappingColliders = new Collider[32];
			if (!noSteamVRFallbackCamera)
			{
				while (!isPoseValid)
				{
					yield return null;
				}
				InitController();
			}
		}

		protected virtual void UpdateHovering()
		{
			if ((!(noSteamVRFallbackCamera == null) || isActive) && !hoverLocked && !applicationLostFocusObject.activeSelf)
			{
				float closestDistance = float.MaxValue;
				Interactable closestInteractable = null;
				if (useHoverSphere)
				{
					float hoverRadius = hoverSphereRadius * Mathf.Abs(SteamVR_Utils.GetLossyScale(hoverSphereTransform));
					CheckHoveringForTransform(hoverSphereTransform.position, hoverRadius, ref closestDistance, ref closestInteractable, Color.green);
				}
				if (useControllerHoverComponent && mainRenderModel != null && mainRenderModel.IsControllerVisibile())
				{
					float num = controllerHoverRadius * Mathf.Abs(SteamVR_Utils.GetLossyScale(base.transform));
					CheckHoveringForTransform(mainRenderModel.GetControllerPosition(controllerHoverComponent), num / 2f, ref closestDistance, ref closestInteractable, Color.blue);
				}
				if (useFingerJointHover && mainRenderModel != null && mainRenderModel.IsHandVisibile())
				{
					float num2 = fingerJointHoverRadius * Mathf.Abs(SteamVR_Utils.GetLossyScale(base.transform));
					CheckHoveringForTransform(mainRenderModel.GetBonePosition((int)fingerJointHover), num2 / 2f, ref closestDistance, ref closestInteractable, Color.yellow);
				}
				hoveringInteractable = closestInteractable;
			}
		}

		protected virtual bool CheckHoveringForTransform(Vector3 hoverPosition, float hoverRadius, ref float closestDistance, ref Interactable closestInteractable, Color debugColor)
		{
			bool flag = false;
			for (int i = 0; i < overlappingColliders.Length; i++)
			{
				overlappingColliders[i] = null;
			}
			if (Physics.OverlapSphereNonAlloc(hoverPosition, hoverRadius, overlappingColliders, hoverLayerMask.value) >= 32)
			{
				UnityEngine.Debug.LogWarning("<b>[SteamVR Interaction]</b> This hand is overlapping the max number of colliders: " + 32 + ". Some collisions may be missed. Increase ColliderArraySize on Hand.cs");
			}
			int num = 0;
			for (int j = 0; j < overlappingColliders.Length; j++)
			{
				Collider collider = overlappingColliders[j];
				if (collider == null)
				{
					continue;
				}
				Interactable componentInParent = collider.GetComponentInParent<Interactable>();
				if (componentInParent == null)
				{
					continue;
				}
				IgnoreHovering component = collider.GetComponent<IgnoreHovering>();
				if (component != null && (component.onlyIgnoreHand == null || component.onlyIgnoreHand == this))
				{
					continue;
				}
				bool flag2 = false;
				for (int k = 0; k < attachedObjects.Count; k++)
				{
					if (attachedObjects[k].attachedObject == componentInParent.gameObject)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					float num2 = Vector3.Distance(componentInParent.transform.position, hoverPosition);
					bool flag3 = false;
					if (closestInteractable != null)
					{
						flag3 = componentInParent.hoverPriority < closestInteractable.hoverPriority;
					}
					if (num2 < closestDistance && !flag3)
					{
						closestDistance = num2;
						closestInteractable = componentInParent;
						flag = true;
					}
					num++;
				}
			}
			if (showDebugInteractables && flag)
			{
				UnityEngine.Debug.DrawLine(hoverPosition, closestInteractable.transform.position, debugColor, 0.05f, depthTest: false);
			}
			if (num > 0 && num != prevOverlappingColliders)
			{
				prevOverlappingColliders = num;
				if (spewDebugText)
				{
					HandDebugLog("Found " + num + " overlapping colliders.");
				}
			}
			return flag;
		}

		protected virtual void UpdateNoSteamVRFallback()
		{
			if (!noSteamVRFallbackCamera)
			{
				return;
			}
			Ray ray = noSteamVRFallbackCamera.ScreenPointToRay(Input.mousePosition);
			if (attachedObjects.Count > 0)
			{
				base.transform.position = ray.origin + noSteamVRFallbackInteractorDistance * ray.direction;
				return;
			}
			Vector3 position = base.transform.position;
			base.transform.position = noSteamVRFallbackCamera.transform.forward * -1000f;
			if (Physics.Raycast(ray, out var hitInfo, noSteamVRFallbackMaxDistanceNoItem))
			{
				base.transform.position = hitInfo.point;
				noSteamVRFallbackInteractorDistance = Mathf.Min(noSteamVRFallbackMaxDistanceNoItem, hitInfo.distance);
			}
			else if (noSteamVRFallbackInteractorDistance > 0f)
			{
				base.transform.position = ray.origin + Mathf.Min(noSteamVRFallbackMaxDistanceNoItem, noSteamVRFallbackInteractorDistance) * ray.direction;
			}
			else
			{
				base.transform.position = position;
			}
		}

		private void UpdateDebugText()
		{
			if (showDebugText)
			{
				if (debugText == null)
				{
					debugText = new GameObject("_debug_text").AddComponent<TextMesh>();
					debugText.fontSize = 120;
					debugText.characterSize = 0.001f;
					debugText.transform.parent = base.transform;
					debugText.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
				}
				if (handType == SteamVR_Input_Sources.RightHand)
				{
					debugText.transform.localPosition = new Vector3(-0.05f, 0f, 0f);
					debugText.alignment = TextAlignment.Right;
					debugText.anchor = TextAnchor.UpperRight;
				}
				else
				{
					debugText.transform.localPosition = new Vector3(0.05f, 0f, 0f);
					debugText.alignment = TextAlignment.Left;
					debugText.anchor = TextAnchor.UpperLeft;
				}
				debugText.text = string.Format("Hovering: {0}\nHover Lock: {1}\nAttached: {2}\nTotal Attached: {3}\nType: {4}\n", hoveringInteractable ? hoveringInteractable.gameObject.name : "null", hoverLocked, currentAttachedObject ? currentAttachedObject.name : "null", attachedObjects.Count, handType.ToString());
			}
			else if (debugText != null)
			{
				UnityEngine.Object.Destroy(debugText.gameObject);
			}
		}

		protected virtual void OnEnable()
		{
			inputFocusAction.enabled = true;
			float time = ((otherHand != null && otherHand.GetInstanceID() < GetInstanceID()) ? (0.5f * hoverUpdateInterval) : 0f);
			InvokeRepeating("UpdateHovering", time, hoverUpdateInterval);
			InvokeRepeating("UpdateDebugText", time, hoverUpdateInterval);
		}

		protected virtual void OnDisable()
		{
			inputFocusAction.enabled = false;
			CancelInvoke();
		}

		protected virtual void Update()
		{
			UpdateNoSteamVRFallback();
			GameObject gameObject = currentAttachedObject;
			if (gameObject != null)
			{
				gameObject.SendMessage("HandAttachedUpdate", this, SendMessageOptions.DontRequireReceiver);
			}
			if ((bool)hoveringInteractable)
			{
				hoveringInteractable.SendMessage("HandHoverUpdate", this, SendMessageOptions.DontRequireReceiver);
			}
		}

		public bool IsStillHovering(Interactable interactable)
		{
			return hoveringInteractable == interactable;
		}

		protected virtual void HandFollowUpdate()
		{
			if (!(currentAttachedObject != null) || !(currentAttachedObjectInfo.Value.interactable != null))
			{
				return;
			}
			SteamVR_Skeleton_PoseSnapshot steamVR_Skeleton_PoseSnapshot = null;
			if (currentAttachedObjectInfo.Value.interactable.skeletonPoser != null && HasSkeleton())
			{
				steamVR_Skeleton_PoseSnapshot = currentAttachedObjectInfo.Value.interactable.skeletonPoser.GetBlendedPose(skeleton);
			}
			if (currentAttachedObjectInfo.Value.interactable.handFollowTransform)
			{
				Quaternion handRotation;
				Vector3 handPosition;
				if (steamVR_Skeleton_PoseSnapshot == null)
				{
					Quaternion rotation = Quaternion.Inverse(base.transform.rotation) * currentAttachedObjectInfo.Value.handAttachmentPointTransform.rotation;
					handRotation = currentAttachedObjectInfo.Value.interactable.transform.rotation * Quaternion.Inverse(rotation);
					Vector3 vector = base.transform.position - currentAttachedObjectInfo.Value.handAttachmentPointTransform.position;
					Vector3 vector2 = mainRenderModel.GetHandRotation() * Quaternion.Inverse(base.transform.rotation) * vector;
					handPosition = currentAttachedObjectInfo.Value.interactable.transform.position + vector2;
				}
				else
				{
					Transform obj = currentAttachedObjectInfo.Value.attachedObject.transform;
					Vector3 position = obj.position;
					Quaternion rotation2 = obj.transform.rotation;
					obj.position = TargetItemPosition(currentAttachedObjectInfo.Value);
					obj.rotation = TargetItemRotation(currentAttachedObjectInfo.Value);
					Vector3 position2 = obj.InverseTransformPoint(base.transform.position);
					Quaternion quaternion = Quaternion.Inverse(obj.rotation) * base.transform.rotation;
					obj.position = position;
					obj.rotation = rotation2;
					handPosition = obj.TransformPoint(position2);
					handRotation = obj.rotation * quaternion;
				}
				if (mainRenderModel != null)
				{
					mainRenderModel.SetHandRotation(handRotation);
				}
				if (hoverhighlightRenderModel != null)
				{
					hoverhighlightRenderModel.SetHandRotation(handRotation);
				}
				if (mainRenderModel != null)
				{
					mainRenderModel.SetHandPosition(handPosition);
				}
				if (hoverhighlightRenderModel != null)
				{
					hoverhighlightRenderModel.SetHandPosition(handPosition);
				}
			}
		}

		protected virtual void FixedUpdate()
		{
			if (!(currentAttachedObject != null))
			{
				return;
			}
			AttachedObject value = currentAttachedObjectInfo.Value;
			if (!(value.attachedObject != null))
			{
				return;
			}
			if (value.HasAttachFlag(AttachmentFlags.VelocityMovement))
			{
				if (!value.interactable.attachEaseIn || value.interactable.snapAttachEaseInCompleted)
				{
					UpdateAttachedVelocity(value);
				}
			}
			else if (value.HasAttachFlag(AttachmentFlags.ParentToHand))
			{
				value.attachedObject.transform.position = TargetItemPosition(value);
				value.attachedObject.transform.rotation = TargetItemRotation(value);
			}
			if (!value.interactable.attachEaseIn)
			{
				return;
			}
			float num = Util.RemapNumberClamped(Time.time, value.attachTime, value.attachTime + value.interactable.snapAttachEaseInTime, 0f, 1f);
			if (num < 1f)
			{
				if (value.HasAttachFlag(AttachmentFlags.VelocityMovement))
				{
					value.attachedRigidbody.linearVelocity = Vector3.zero;
					value.attachedRigidbody.angularVelocity = Vector3.zero;
				}
				num = value.interactable.snapAttachEaseInCurve.Evaluate(num);
				value.attachedObject.transform.position = Vector3.Lerp(value.easeSourcePosition, TargetItemPosition(value), num);
				value.attachedObject.transform.rotation = Quaternion.Lerp(value.easeSourceRotation, TargetItemRotation(value), num);
			}
			else if (!value.interactable.snapAttachEaseInCompleted)
			{
				value.interactable.gameObject.SendMessage("OnThrowableAttachEaseInCompleted", this, SendMessageOptions.DontRequireReceiver);
				value.interactable.snapAttachEaseInCompleted = true;
			}
		}

		protected void UpdateAttachedVelocity(AttachedObject attachedObjectInfo)
		{
			if (GetUpdatedAttachedVelocities(attachedObjectInfo, out var velocityTarget, out var angularTarget))
			{
				float lossyScale = SteamVR_Utils.GetLossyScale(currentAttachedObjectInfo.Value.handAttachmentPointTransform);
				float maxDistanceDelta = 20f * lossyScale;
				float maxDistanceDelta2 = 10f * lossyScale;
				attachedObjectInfo.attachedRigidbody.linearVelocity = Vector3.MoveTowards(attachedObjectInfo.attachedRigidbody.linearVelocity, velocityTarget, maxDistanceDelta2);
				attachedObjectInfo.attachedRigidbody.angularVelocity = Vector3.MoveTowards(attachedObjectInfo.attachedRigidbody.angularVelocity, angularTarget, maxDistanceDelta);
			}
		}

		public void ResetAttachedTransform(AttachedObject attachedObject)
		{
			attachedObject.attachedObject.transform.position = TargetItemPosition(attachedObject);
			attachedObject.attachedObject.transform.rotation = TargetItemRotation(attachedObject);
		}

		protected Vector3 TargetItemPosition(AttachedObject attachedObject)
		{
			if (attachedObject.interactable != null && attachedObject.interactable.skeletonPoser != null && HasSkeleton())
			{
				Vector3 position = attachedObject.handAttachmentPointTransform.InverseTransformPoint(base.transform.TransformPoint(attachedObject.interactable.skeletonPoser.GetBlendedPose(skeleton).position));
				return currentAttachedObjectInfo.Value.handAttachmentPointTransform.TransformPoint(position);
			}
			return currentAttachedObjectInfo.Value.handAttachmentPointTransform.TransformPoint(attachedObject.initialPositionalOffset);
		}

		protected Quaternion TargetItemRotation(AttachedObject attachedObject)
		{
			if (attachedObject.interactable != null && attachedObject.interactable.skeletonPoser != null && HasSkeleton())
			{
				Quaternion quaternion = Quaternion.Inverse(attachedObject.handAttachmentPointTransform.rotation) * (base.transform.rotation * attachedObject.interactable.skeletonPoser.GetBlendedPose(skeleton).rotation);
				return currentAttachedObjectInfo.Value.handAttachmentPointTransform.rotation * quaternion;
			}
			return currentAttachedObjectInfo.Value.handAttachmentPointTransform.rotation * attachedObject.initialRotationalOffset;
		}

		protected bool GetUpdatedAttachedVelocities(AttachedObject attachedObjectInfo, out Vector3 velocityTarget, out Vector3 angularTarget)
		{
			bool flag = false;
			float num = 6000f;
			float num2 = 50f;
			Vector3 vector = TargetItemPosition(attachedObjectInfo) - attachedObjectInfo.attachedRigidbody.position;
			velocityTarget = vector * num * Time.deltaTime;
			if (!float.IsNaN(velocityTarget.x) && !float.IsInfinity(velocityTarget.x))
			{
				if ((bool)noSteamVRFallbackCamera)
				{
					velocityTarget /= 10f;
				}
				flag = true;
			}
			else
			{
				velocityTarget = Vector3.zero;
			}
			(TargetItemRotation(attachedObjectInfo) * Quaternion.Inverse(attachedObjectInfo.attachedObject.transform.rotation)).ToAngleAxis(out var angle, out var axis);
			if (angle > 180f)
			{
				angle -= 360f;
			}
			if (angle != 0f && !float.IsNaN(axis.x) && !float.IsInfinity(axis.x))
			{
				angularTarget = angle * axis * num2 * Time.deltaTime;
				if ((bool)noSteamVRFallbackCamera)
				{
					angularTarget /= 10f;
				}
				flag = flag;
			}
			else
			{
				angularTarget = Vector3.zero;
			}
			return flag;
		}

		protected virtual void OnInputFocus(bool hasFocus)
		{
			if (hasFocus)
			{
				DetachObject(applicationLostFocusObject);
				applicationLostFocusObject.SetActive(value: false);
				UpdateHovering();
				BroadcastMessage("OnParentHandInputFocusAcquired", SendMessageOptions.DontRequireReceiver);
			}
			else
			{
				applicationLostFocusObject.SetActive(value: true);
				AttachObject(applicationLostFocusObject, GrabTypes.Scripted, AttachmentFlags.ParentToHand);
				BroadcastMessage("OnParentHandInputFocusLost", SendMessageOptions.DontRequireReceiver);
			}
		}

		protected virtual void OnDrawGizmos()
		{
			if (useHoverSphere && hoverSphereTransform != null)
			{
				Gizmos.color = Color.green;
				float num = hoverSphereRadius * Mathf.Abs(SteamVR_Utils.GetLossyScale(hoverSphereTransform));
				Gizmos.DrawWireSphere(hoverSphereTransform.position, num / 2f);
			}
			if (useControllerHoverComponent && mainRenderModel != null && mainRenderModel.IsControllerVisibile())
			{
				Gizmos.color = Color.blue;
				float num2 = controllerHoverRadius * Mathf.Abs(SteamVR_Utils.GetLossyScale(base.transform));
				Gizmos.DrawWireSphere(mainRenderModel.GetControllerPosition(controllerHoverComponent), num2 / 2f);
			}
			if (useFingerJointHover && mainRenderModel != null && mainRenderModel.IsHandVisibile())
			{
				Gizmos.color = Color.yellow;
				float num3 = fingerJointHoverRadius * Mathf.Abs(SteamVR_Utils.GetLossyScale(base.transform));
				Gizmos.DrawWireSphere(mainRenderModel.GetBonePosition((int)fingerJointHover), num3 / 2f);
			}
		}

		private void HandDebugLog(string msg)
		{
			if (spewDebugText)
			{
				UnityEngine.Debug.Log("<b>[SteamVR Interaction]</b> Hand (" + base.name + "): " + msg);
			}
		}

		public void HoverLock(Interactable interactable)
		{
			if (spewDebugText)
			{
				HandDebugLog("HoverLock " + interactable);
			}
			hoverLocked = true;
			hoveringInteractable = interactable;
		}

		public void HoverUnlock(Interactable interactable)
		{
			if (spewDebugText)
			{
				HandDebugLog("HoverUnlock " + interactable);
			}
			if (hoveringInteractable == interactable)
			{
				hoverLocked = false;
			}
		}

		public void TriggerHapticPulse(ushort microSecondsDuration)
		{
			float num = (float)(int)microSecondsDuration / 1000000f;
			hapticAction.Execute(0f, num, 1f / num, 1f, handType);
		}

		public void TriggerHapticPulse(float duration, float frequency, float amplitude)
		{
			hapticAction.Execute(0f, duration, frequency, amplitude, handType);
		}

		public void ShowGrabHint()
		{
			ControllerButtonHints.ShowButtonHint(this, grabGripAction);
		}

		public void HideGrabHint()
		{
			ControllerButtonHints.HideButtonHint(this, grabGripAction);
		}

		public void ShowGrabHint(string text)
		{
			ControllerButtonHints.ShowTextHint(this, grabGripAction, text);
		}

		public GrabTypes GetGrabStarting(GrabTypes explicitType = GrabTypes.None)
		{
			if (explicitType != GrabTypes.None)
			{
				if ((bool)noSteamVRFallbackCamera)
				{
					if (Input.GetMouseButtonDown(0))
					{
						return explicitType;
					}
					return GrabTypes.None;
				}
				if (explicitType == GrabTypes.Pinch && grabPinchAction.GetStateDown(handType))
				{
					return GrabTypes.Pinch;
				}
				if (explicitType == GrabTypes.Grip && grabGripAction.GetStateDown(handType))
				{
					return GrabTypes.Grip;
				}
			}
			else
			{
				if ((bool)noSteamVRFallbackCamera)
				{
					if (Input.GetMouseButtonDown(0))
					{
						return GrabTypes.Grip;
					}
					return GrabTypes.None;
				}
				if (grabPinchAction != null && grabPinchAction.GetStateDown(handType))
				{
					return GrabTypes.Pinch;
				}
				if (grabGripAction != null && grabGripAction.GetStateDown(handType))
				{
					return GrabTypes.Grip;
				}
			}
			return GrabTypes.None;
		}

		public GrabTypes GetGrabEnding(GrabTypes explicitType = GrabTypes.None)
		{
			if (explicitType != GrabTypes.None)
			{
				if ((bool)noSteamVRFallbackCamera)
				{
					if (Input.GetMouseButtonUp(0))
					{
						return explicitType;
					}
					return GrabTypes.None;
				}
				if (explicitType == GrabTypes.Pinch && grabPinchAction.GetStateUp(handType))
				{
					return GrabTypes.Pinch;
				}
				if (explicitType == GrabTypes.Grip && grabGripAction.GetStateUp(handType))
				{
					return GrabTypes.Grip;
				}
			}
			else
			{
				if ((bool)noSteamVRFallbackCamera)
				{
					if (Input.GetMouseButtonUp(0))
					{
						return GrabTypes.Grip;
					}
					return GrabTypes.None;
				}
				if (grabPinchAction.GetStateUp(handType))
				{
					return GrabTypes.Pinch;
				}
				if (grabGripAction.GetStateUp(handType))
				{
					return GrabTypes.Grip;
				}
			}
			return GrabTypes.None;
		}

		public bool IsGrabEnding(GameObject attachedObject)
		{
			for (int i = 0; i < attachedObjects.Count; i++)
			{
				if (attachedObjects[i].attachedObject == attachedObject)
				{
					return !IsGrabbingWithType(attachedObjects[i].grabbedWithType);
				}
			}
			return false;
		}

		public bool IsGrabbingWithType(GrabTypes type)
		{
			if ((bool)noSteamVRFallbackCamera)
			{
				if (Input.GetMouseButton(0))
				{
					return true;
				}
				return false;
			}
			return type switch
			{
				GrabTypes.Pinch => grabPinchAction.GetState(handType), 
				GrabTypes.Grip => grabGripAction.GetState(handType), 
				_ => false, 
			};
		}

		public bool IsGrabbingWithOppositeType(GrabTypes type)
		{
			if ((bool)noSteamVRFallbackCamera)
			{
				if (Input.GetMouseButton(0))
				{
					return true;
				}
				return false;
			}
			return type switch
			{
				GrabTypes.Pinch => grabGripAction.GetState(handType), 
				GrabTypes.Grip => grabPinchAction.GetState(handType), 
				_ => false, 
			};
		}

		public GrabTypes GetBestGrabbingType()
		{
			return GetBestGrabbingType(GrabTypes.None);
		}

		public GrabTypes GetBestGrabbingType(GrabTypes preferred, bool forcePreference = false)
		{
			if ((bool)noSteamVRFallbackCamera)
			{
				if (Input.GetMouseButton(0))
				{
					return preferred;
				}
				return GrabTypes.None;
			}
			if (preferred == GrabTypes.Pinch)
			{
				if (grabPinchAction.GetState(handType))
				{
					return GrabTypes.Pinch;
				}
				if (forcePreference)
				{
					return GrabTypes.None;
				}
			}
			if (preferred == GrabTypes.Grip)
			{
				if (grabGripAction.GetState(handType))
				{
					return GrabTypes.Grip;
				}
				if (forcePreference)
				{
					return GrabTypes.None;
				}
			}
			if (grabPinchAction.GetState(handType))
			{
				return GrabTypes.Pinch;
			}
			if (grabGripAction.GetState(handType))
			{
				return GrabTypes.Grip;
			}
			return GrabTypes.None;
		}

		private void InitController()
		{
			if (spewDebugText)
			{
				HandDebugLog("Hand " + base.name + " connected with type " + handType);
			}
			bool flag = mainRenderModel != null;
			EVRSkeletalMotionRange newRangeOfMotion = EVRSkeletalMotionRange.WithController;
			if (flag)
			{
				newRangeOfMotion = mainRenderModel.GetSkeletonRangeOfMotion;
			}
			foreach (RenderModel renderModel in renderModels)
			{
				if (renderModel != null)
				{
					UnityEngine.Object.Destroy(renderModel.gameObject);
				}
			}
			renderModels.Clear();
			GameObject gameObject = UnityEngine.Object.Instantiate(renderModelPrefab);
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			gameObject.transform.parent = base.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = renderModelPrefab.transform.localScale;
			int deviceIndex = trackedObject.GetDeviceIndex();
			mainRenderModel = gameObject.GetComponent<RenderModel>();
			renderModels.Add(mainRenderModel);
			if (flag)
			{
				mainRenderModel.SetSkeletonRangeOfMotion(newRangeOfMotion);
			}
			BroadcastMessage("SetInputSource", handType, SendMessageOptions.DontRequireReceiver);
			BroadcastMessage("OnHandInitialized", deviceIndex, SendMessageOptions.DontRequireReceiver);
		}

		public void SetRenderModel(GameObject prefab)
		{
			renderModelPrefab = prefab;
			if (mainRenderModel != null && isPoseValid)
			{
				InitController();
			}
		}

		public void SetHoverRenderModel(RenderModel hoverRenderModel)
		{
			hoverhighlightRenderModel = hoverRenderModel;
			renderModels.Add(hoverRenderModel);
		}

		public int GetDeviceIndex()
		{
			return trackedObject.GetDeviceIndex();
		}
	}
	[Serializable]
	public class HandEvent : UnityEvent<Hand>
	{
	}
	public class HandCollider : MonoBehaviour
	{
		[Serializable]
		public class FingerColliders
		{
			[Tooltip("Starting at tip and going down. Max 2.")]
			public Transform[] thumbColliders = new Transform[1];

			[Tooltip("Starting at tip and going down. Max 3.")]
			public Transform[] indexColliders = new Transform[2];

			[Tooltip("Starting at tip and going down. Max 3.")]
			public Transform[] middleColliders = new Transform[2];

			[Tooltip("Starting at tip and going down. Max 3.")]
			public Transform[] ringColliders = new Transform[2];

			[Tooltip("Starting at tip and going down. Max 3.")]
			public Transform[] pinkyColliders = new Transform[2];

			public Transform[] this[int finger]
			{
				get
				{
					return finger switch
					{
						0 => thumbColliders, 
						1 => indexColliders, 
						2 => middleColliders, 
						3 => ringColliders, 
						4 => pinkyColliders, 
						_ => null, 
					};
				}
				set
				{
					switch (finger)
					{
					case 0:
						thumbColliders = value;
						break;
					case 1:
						indexColliders = value;
						break;
					case 2:
						middleColliders = value;
						break;
					case 3:
						ringColliders = value;
						break;
					case 4:
						pinkyColliders = value;
						break;
					}
				}
			}
		}

		private Rigidbody rigidbody;

		[HideInInspector]
		public HandPhysics hand;

		public LayerMask collisionMask;

		private Collider[] colliders;

		public FingerColliders fingerColliders;

		private static PhysicsMaterial physicMaterial_lowfriction;

		private static PhysicsMaterial physicMaterial_highfriction;

		private float scale;

		private Vector3 center;

		private Vector3 targetPosition = Vector3.zero;

		private Quaternion targetRotation = Quaternion.identity;

		protected const float MaxVelocityChange = 10f;

		protected const float VelocityMagic = 6000f;

		protected const float AngularVelocityMagic = 50f;

		protected const float MaxAngularVelocityChange = 20f;

		public bool collidersInRadius;

		private const float minCollisionEnergy = 0.1f;

		private const float maxCollisionEnergy = 1f;

		private const float minCollisionHapticsTime = 0.2f;

		private float lastCollisionHapticsTime;

		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
			rigidbody.maxAngularVelocity = 50f;
		}

		private void Start()
		{
			colliders = GetComponentsInChildren<Collider>();
			if (physicMaterial_lowfriction == null)
			{
				physicMaterial_lowfriction = new PhysicsMaterial("hand_lowFriction");
				physicMaterial_lowfriction.dynamicFriction = 0f;
				physicMaterial_lowfriction.staticFriction = 0f;
				physicMaterial_lowfriction.bounciness = 0f;
				physicMaterial_lowfriction.bounceCombine = PhysicsMaterialCombine.Minimum;
				physicMaterial_lowfriction.frictionCombine = PhysicsMaterialCombine.Minimum;
			}
			if (physicMaterial_highfriction == null)
			{
				physicMaterial_highfriction = new PhysicsMaterial("hand_highFriction");
				physicMaterial_highfriction.dynamicFriction = 1f;
				physicMaterial_highfriction.staticFriction = 1f;
				physicMaterial_highfriction.bounciness = 0f;
				physicMaterial_highfriction.bounceCombine = PhysicsMaterialCombine.Minimum;
				physicMaterial_highfriction.frictionCombine = PhysicsMaterialCombine.Average;
			}
			SetPhysicMaterial(physicMaterial_lowfriction);
			scale = SteamVR_Utils.GetLossyScale(hand.transform);
		}

		private void SetPhysicMaterial(PhysicsMaterial mat)
		{
			if (colliders == null)
			{
				colliders = GetComponentsInChildren<Collider>();
			}
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].sharedMaterial = mat;
			}
		}

		public void SetCollisionDetectionEnabled(bool value)
		{
			rigidbody.detectCollisions = value;
		}

		public void MoveTo(Vector3 position, Quaternion rotation)
		{
			targetPosition = position;
			targetRotation = rotation;
			ExecuteFixedUpdate();
		}

		public void TeleportTo(Vector3 position, Quaternion rotation)
		{
			targetPosition = position;
			targetRotation = rotation;
			MoveTo(position, rotation);
			rigidbody.position = position;
			if (rotation.x != 0f || rotation.y != 0f || rotation.z != 0f || rotation.w != 0f)
			{
				rigidbody.rotation = rotation;
			}
			base.transform.position = position;
			base.transform.rotation = rotation;
		}

		public void Reset()
		{
			TeleportTo(targetPosition, targetRotation);
		}

		public void SetCenterPoint(Vector3 newCenter)
		{
			center = newCenter;
		}

		protected void ExecuteFixedUpdate()
		{
			collidersInRadius = Physics.CheckSphere(center, 0.2f, collisionMask);
			Vector3 velocityTarget;
			Vector3 angularTarget;
			if (!collidersInRadius)
			{
				rigidbody.linearVelocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
				rigidbody.MovePosition(targetPosition);
				rigidbody.MoveRotation(targetRotation);
			}
			else if (GetTargetVelocities(out velocityTarget, out angularTarget))
			{
				float maxDistanceDelta = 20f * scale;
				float maxDistanceDelta2 = 10f * scale;
				rigidbody.linearVelocity = Vector3.MoveTowards(rigidbody.linearVelocity, velocityTarget, maxDistanceDelta2);
				rigidbody.angularVelocity = Vector3.MoveTowards(rigidbody.angularVelocity, angularTarget, maxDistanceDelta);
			}
		}

		protected bool GetTargetVelocities(out Vector3 velocityTarget, out Vector3 angularTarget)
		{
			bool flag = false;
			float num = 6000f;
			float num2 = 50f;
			Vector3 vector = targetPosition - rigidbody.position;
			velocityTarget = vector * num * Time.deltaTime;
			if (!float.IsNaN(velocityTarget.x) && !float.IsInfinity(velocityTarget.x))
			{
				flag = true;
			}
			else
			{
				velocityTarget = Vector3.zero;
			}
			(targetRotation * Quaternion.Inverse(rigidbody.rotation)).ToAngleAxis(out var angle, out var axis);
			if (angle > 180f)
			{
				angle -= 360f;
			}
			if (angle != 0f && !float.IsNaN(axis.x) && !float.IsInfinity(axis.x))
			{
				angularTarget = angle * axis * num2 * Time.deltaTime;
				flag = flag;
			}
			else
			{
				angularTarget = Vector3.zero;
			}
			return flag;
		}

		private void OnCollisionEnter(Collision collision)
		{
			bool flag = false;
			if (collision.rigidbody != null && !collision.rigidbody.isKinematic)
			{
				flag = true;
			}
			SetPhysicMaterial(flag ? physicMaterial_highfriction : physicMaterial_lowfriction);
			float magnitude = collision.relativeVelocity.magnitude;
			if (magnitude > 0.1f && Time.time - lastCollisionHapticsTime > 0.2f)
			{
				lastCollisionHapticsTime = Time.time;
				float amplitude = Util.RemapNumber(magnitude, 0.1f, 1f, 0.3f, 1f);
				float duration = Util.RemapNumber(magnitude, 0.1f, 1f, 0f, 0.06f);
				hand.hand.TriggerHapticPulse(duration, 100f, amplitude);
			}
		}
	}
	public class HandPhysics : MonoBehaviour
	{
		[Tooltip("Hand collider prefab to instantiate")]
		public HandCollider handColliderPrefab;

		[HideInInspector]
		public HandCollider handCollider;

		[Tooltip("Layers to consider when checking if an area is clear")]
		public LayerMask clearanceCheckMask;

		[HideInInspector]
		public Hand hand;

		private const float handResetDistance = 0.6f;

		private const float collisionReenableClearanceRadius = 0.1f;

		private bool initialized;

		private bool collisionsEnabled = true;

		private Matrix4x4 wristToRoot;

		private Matrix4x4 rootToArmature;

		private Matrix4x4 wristToArmature;

		private Vector3 targetPosition = Vector3.zero;

		private Quaternion targetRotation = Quaternion.identity;

		private const int wristBone = 1;

		private const int rootBone = 0;

		private Collider[] clearanceBuffer = new Collider[1];

		private Transform wrist;

		private const int thumbBone = 4;

		private const int indexBone = 9;

		private const int middleBone = 14;

		private const int ringBone = 19;

		private const int pinkyBone = 24;

		private void Start()
		{
			hand = GetComponent<Hand>();
			handCollider = UnityEngine.Object.Instantiate(handColliderPrefab.gameObject).GetComponent<HandCollider>();
			Vector3 localPosition = handCollider.transform.localPosition;
			Quaternion localRotation = handCollider.transform.localRotation;
			handCollider.transform.parent = Player.instance.transform;
			handCollider.transform.localPosition = localPosition;
			handCollider.transform.localRotation = localRotation;
			handCollider.hand = this;
			GetComponent<SteamVR_Behaviour_Pose>().onTransformUpdated.AddListener(UpdateHand);
		}

		private void FixedUpdate()
		{
			if (!(hand.skeleton == null))
			{
				initialized = true;
				UpdateCenterPoint();
				handCollider.MoveTo(targetPosition, targetRotation);
				if ((handCollider.transform.position - targetPosition).sqrMagnitude > 0.36f)
				{
					handCollider.TeleportTo(targetPosition, targetRotation);
				}
				UpdateFingertips();
			}
		}

		private void UpdateCenterPoint()
		{
			Vector3 vector = hand.skeleton.GetBonePosition(12) - hand.skeleton.GetBonePosition(0);
			if (hand.HasSkeleton())
			{
				handCollider.SetCenterPoint(hand.skeleton.transform.position + vector);
			}
		}

		private void UpdatePositions()
		{
			if (hand.currentAttachedObject != null)
			{
				collisionsEnabled = false;
			}
			else if (!collisionsEnabled)
			{
				clearanceBuffer[0] = null;
				Physics.OverlapSphereNonAlloc(hand.objectAttachmentPoint.position, 0.1f, clearanceBuffer);
				if (clearanceBuffer[0] == null)
				{
					collisionsEnabled = true;
				}
			}
			handCollider.SetCollisionDetectionEnabled(collisionsEnabled);
			if (!(hand.skeleton == null))
			{
				initialized = true;
				wristToRoot = Matrix4x4.TRS(ProcessPos(1, hand.skeleton.GetBone(1).localPosition), ProcessRot(1, hand.skeleton.GetBone(1).localRotation), Vector3.one).inverse;
				rootToArmature = Matrix4x4.TRS(ProcessPos(0, hand.skeleton.GetBone(0).localPosition), ProcessRot(0, hand.skeleton.GetBone(0).localRotation), Vector3.one).inverse;
				wristToArmature = (wristToRoot * rootToArmature).inverse;
				targetPosition = base.transform.TransformPoint(wristToArmature.MultiplyPoint3x4(Vector3.zero));
				targetRotation = base.transform.rotation * wristToArmature.GetRotation();
				if (Time.timeScale == 0f)
				{
					handCollider.TeleportTo(targetPosition, targetRotation);
				}
			}
		}

		private void UpdateFingertips()
		{
			wrist = hand.skeleton.GetBone(1);
			for (int i = 0; i < 5; i++)
			{
				int boneForFingerTip = SteamVR_Skeleton_JointIndexes.GetBoneForFingerTip(i);
				int num = boneForFingerTip;
				for (int j = 0; j < handCollider.fingerColliders[i].Length; j++)
				{
					num = boneForFingerTip - 1 - j;
					if (handCollider.fingerColliders[i][j] != null)
					{
						handCollider.fingerColliders[i][j].localPosition = wrist.InverseTransformPoint(hand.skeleton.GetBone(num).position);
					}
				}
			}
		}

		private void UpdateHand(SteamVR_Behaviour_Pose pose, SteamVR_Input_Sources inputSource)
		{
			if (initialized)
			{
				UpdateCenterPoint();
				UpdatePositions();
				Quaternion rotation = handCollider.transform.rotation * wristToArmature.inverse.GetRotation();
				hand.mainRenderModel.transform.rotation = rotation;
				Vector3 position = handCollider.transform.TransformPoint(wristToArmature.inverse.MultiplyPoint3x4(Vector3.zero));
				hand.mainRenderModel.transform.position = position;
			}
		}

		private Vector3 ProcessPos(int boneIndex, Vector3 pos)
		{
			if (hand.skeleton.mirroring != SteamVR_Behaviour_Skeleton.MirrorType.None)
			{
				return SteamVR_Behaviour_Skeleton.MirrorPosition(boneIndex, pos);
			}
			return pos;
		}

		private Quaternion ProcessRot(int boneIndex, Quaternion rot)
		{
			if (hand.skeleton.mirroring != SteamVR_Behaviour_Skeleton.MirrorType.None)
			{
				return SteamVR_Behaviour_Skeleton.MirrorRotation(boneIndex, rot);
			}
			return rot;
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class HapticRack : MonoBehaviour
	{
		[Tooltip("The linear mapping driving the haptic rack")]
		public LinearMapping linearMapping;

		[Tooltip("The number of haptic pulses evenly distributed along the mapping")]
		public int teethCount = 128;

		[Tooltip("Minimum duration of the haptic pulse")]
		public int minimumPulseDuration = 500;

		[Tooltip("Maximum duration of the haptic pulse")]
		public int maximumPulseDuration = 900;

		[Tooltip("This event is triggered every time a haptic pulse is made")]
		public UnityEvent onPulse;

		private Hand hand;

		private int previousToothIndex = -1;

		private void Awake()
		{
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}

		private void OnHandHoverBegin(Hand hand)
		{
			this.hand = hand;
		}

		private void OnHandHoverEnd(Hand hand)
		{
			this.hand = null;
		}

		private void Update()
		{
			int num = Mathf.RoundToInt(linearMapping.value * (float)teethCount - 0.5f);
			if (num != previousToothIndex)
			{
				Pulse();
				previousToothIndex = num;
			}
		}

		private void Pulse()
		{
			if ((bool)hand && hand.isActive && hand.GetBestGrabbingType() != GrabTypes.None)
			{
				ushort microSecondsDuration = (ushort)UnityEngine.Random.Range(minimumPulseDuration, maximumPulseDuration + 1);
				hand.TriggerHapticPulse(microSecondsDuration);
				onPulse.Invoke();
			}
		}
	}
	public class HideOnHandFocusLost : MonoBehaviour
	{
		private void OnHandFocusLost(Hand hand)
		{
			base.gameObject.SetActive(value: false);
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class HoverButton : MonoBehaviour
	{
		public Transform movingPart;

		public Vector3 localMoveDistance = new Vector3(0f, -0.1f, 0f);

		[Range(0f, 1f)]
		public float engageAtPercent = 0.95f;

		[Range(0f, 1f)]
		public float disengageAtPercent = 0.9f;

		public HandEvent onButtonDown;

		public HandEvent onButtonUp;

		public HandEvent onButtonIsPressed;

		public bool engaged;

		public bool buttonDown;

		public bool buttonUp;

		private Vector3 startPosition;

		private Vector3 endPosition;

		private Vector3 handEnteredPosition;

		private bool hovering;

		private Hand lastHoveredHand;

		private void Start()
		{
			if (movingPart == null && base.transform.childCount > 0)
			{
				movingPart = base.transform.GetChild(0);
			}
			startPosition = movingPart.localPosition;
			endPosition = startPosition + localMoveDistance;
			handEnteredPosition = endPosition;
		}

		private void HandHoverUpdate(Hand hand)
		{
			hovering = true;
			lastHoveredHand = hand;
			bool wasEngaged = engaged;
			float num = Vector3.Distance(movingPart.parent.InverseTransformPoint(hand.transform.position), endPosition);
			float num2 = Vector3.Distance(handEnteredPosition, endPosition);
			if (num > num2)
			{
				num2 = num;
				handEnteredPosition = movingPart.parent.InverseTransformPoint(hand.transform.position);
			}
			float value = num2 - num;
			float num3 = Mathf.InverseLerp(0f, localMoveDistance.magnitude, value);
			if (num3 > engageAtPercent)
			{
				engaged = true;
			}
			else if (num3 < disengageAtPercent)
			{
				engaged = false;
			}
			movingPart.localPosition = Vector3.Lerp(startPosition, endPosition, num3);
			InvokeEvents(wasEngaged, engaged);
		}

		private void LateUpdate()
		{
			if (!hovering)
			{
				movingPart.localPosition = startPosition;
				handEnteredPosition = endPosition;
				InvokeEvents(engaged, isEngaged: false);
				engaged = false;
			}
			hovering = false;
		}

		private void InvokeEvents(bool wasEngaged, bool isEngaged)
		{
			buttonDown = !wasEngaged && isEngaged;
			buttonUp = wasEngaged && !isEngaged;
			if (buttonDown && onButtonDown != null)
			{
				onButtonDown.Invoke(lastHoveredHand);
			}
			if (buttonUp && onButtonUp != null)
			{
				onButtonUp.Invoke(lastHoveredHand);
			}
			if (isEngaged && onButtonIsPressed != null)
			{
				onButtonIsPressed.Invoke(lastHoveredHand);
			}
		}
	}
	public class IgnoreHovering : MonoBehaviour
	{
		[Tooltip("If Hand is not null, only ignore the specified hand")]
		public Hand onlyIgnoreHand;
	}
	public class InputModule : BaseInputModule
	{
		private GameObject submitObject;

		private static InputModule _instance;

		public static InputModule instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindObjectOfType<InputModule>();
				}
				return _instance;
			}
		}

		public override bool ShouldActivateModule()
		{
			if (!base.ShouldActivateModule())
			{
				return false;
			}
			return submitObject != null;
		}

		public void HoverBegin(GameObject gameObject)
		{
			PointerEventData eventData = new PointerEventData(base.eventSystem);
			ExecuteEvents.Execute(gameObject, eventData, ExecuteEvents.pointerEnterHandler);
		}

		public void HoverEnd(GameObject gameObject)
		{
			PointerEventData pointerEventData = new PointerEventData(base.eventSystem);
			pointerEventData.selectedObject = null;
			ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerExitHandler);
		}

		public void Submit(GameObject gameObject)
		{
			submitObject = gameObject;
		}

		public override void Process()
		{
			if ((bool)submitObject)
			{
				BaseEventData baseEventData = GetBaseEventData();
				baseEventData.selectedObject = submitObject;
				ExecuteEvents.Execute(submitObject, baseEventData, ExecuteEvents.submitHandler);
				submitObject = null;
			}
		}
	}
	public class Interactable : MonoBehaviour
	{
		public delegate void OnAttachedToHandDelegate(Hand hand);

		public delegate void OnDetachedFromHandDelegate(Hand hand);

		[Tooltip("Activates an action set on attach and deactivates on detach")]
		public SteamVR_ActionSet activateActionSetOnAttach;

		[Tooltip("Hide the whole hand on attachment and show on detach")]
		public bool hideHandOnAttach = true;

		[Tooltip("Hide the skeleton part of the hand on attachment and show on detach")]
		public bool hideSkeletonOnAttach;

		[Tooltip("Hide the controller part of the hand on attachment and show on detach")]
		public bool hideControllerOnAttach;

		[Tooltip("The integer in the animator to trigger on pickup. 0 for none")]
		public int handAnimationOnPickup;

		[Tooltip("The range of motion to set on the skeleton. None for no change.")]
		public SkeletalMotionRangeChange setRangeOfMotionOnPickup = SkeletalMotionRangeChange.None;

		[Tooltip("Specify whether you want to snap to the hand's object attachment point, or just the raw hand")]
		public bool useHandObjectAttachmentPoint = true;

		public bool attachEaseIn;

		[HideInInspector]
		public AnimationCurve snapAttachEaseInCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public float snapAttachEaseInTime = 0.15f;

		public bool snapAttachEaseInCompleted;

		[HideInInspector]
		public SteamVR_Skeleton_Poser skeletonPoser;

		[Tooltip("Should the rendered hand lock on to and follow the object")]
		public bool handFollowTransform = true;

		[Tooltip("Set whether or not you want this interactible to highlight when hovering over it")]
		public bool highlightOnHover = true;

		protected MeshRenderer[] highlightRenderers;

		protected MeshRenderer[] existingRenderers;

		protected GameObject highlightHolder;

		protected SkinnedMeshRenderer[] highlightSkinnedRenderers;

		protected SkinnedMeshRenderer[] existingSkinnedRenderers;

		protected static Material highlightMat;

		[Tooltip("An array of child gameObjects to not render a highlight for. Things like transparent parts, vfx, etc.")]
		public GameObject[] hideHighlight;

		[Tooltip("Higher is better")]
		public int hoverPriority;

		[NonSerialized]
		public Hand attachedToHand;

		[NonSerialized]
		public List<Hand> hoveringHands = new List<Hand>();

		protected float blendToPoseTime = 0.1f;

		protected float releasePoseBlendTime = 0.2f;

		public Hand hoveringHand
		{
			get
			{
				if (hoveringHands.Count > 0)
				{
					return hoveringHands[0];
				}
				return null;
			}
		}

		public bool isDestroying { get; protected set; }

		public bool isHovering { get; protected set; }

		public bool wasHovering { get; protected set; }

		public event OnAttachedToHandDelegate onAttachedToHand;

		public event OnDetachedFromHandDelegate onDetachedFromHand;

		private void Awake()
		{
			skeletonPoser = GetComponent<SteamVR_Skeleton_Poser>();
		}

		protected virtual void Start()
		{
			if (highlightMat == null)
			{
				highlightMat = (Material)Resources.Load("SteamVR_HoverHighlight_URP", typeof(Material));
			}
			if (highlightMat == null)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> Hover Highlight Material is missing. Please create a material named 'SteamVR_HoverHighlight' and place it in a Resources folder", this);
			}
			if (skeletonPoser != null && useHandObjectAttachmentPoint)
			{
				useHandObjectAttachmentPoint = false;
			}
		}

		protected virtual bool ShouldIgnoreHighlight(UnityEngine.Component component)
		{
			return ShouldIgnore(component.gameObject);
		}

		protected virtual bool ShouldIgnore(GameObject check)
		{
			for (int i = 0; i < hideHighlight.Length; i++)
			{
				if (check == hideHighlight[i])
				{
					return true;
				}
			}
			return false;
		}

		protected virtual void CreateHighlightRenderers()
		{
			existingSkinnedRenderers = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			highlightHolder = new GameObject("Highlighter");
			highlightSkinnedRenderers = new SkinnedMeshRenderer[existingSkinnedRenderers.Length];
			for (int i = 0; i < existingSkinnedRenderers.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = existingSkinnedRenderers[i];
				if (!ShouldIgnoreHighlight(skinnedMeshRenderer))
				{
					GameObject obj = new GameObject("SkinnedHolder");
					obj.transform.parent = highlightHolder.transform;
					SkinnedMeshRenderer skinnedMeshRenderer2 = obj.AddComponent<SkinnedMeshRenderer>();
					Material[] array = new Material[skinnedMeshRenderer.sharedMaterials.Length];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = highlightMat;
					}
					skinnedMeshRenderer2.sharedMaterials = array;
					skinnedMeshRenderer2.sharedMesh = skinnedMeshRenderer.sharedMesh;
					skinnedMeshRenderer2.rootBone = skinnedMeshRenderer.rootBone;
					skinnedMeshRenderer2.updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
					skinnedMeshRenderer2.bones = skinnedMeshRenderer.bones;
					highlightSkinnedRenderers[i] = skinnedMeshRenderer2;
				}
			}
			MeshFilter[] componentsInChildren = GetComponentsInChildren<MeshFilter>(includeInactive: true);
			existingRenderers = new MeshRenderer[componentsInChildren.Length];
			highlightRenderers = new MeshRenderer[componentsInChildren.Length];
			for (int k = 0; k < componentsInChildren.Length; k++)
			{
				MeshFilter meshFilter = componentsInChildren[k];
				MeshRenderer component = meshFilter.GetComponent<MeshRenderer>();
				if (!(meshFilter == null) && !(component == null) && !ShouldIgnoreHighlight(meshFilter))
				{
					GameObject obj2 = new GameObject("FilterHolder");
					obj2.transform.parent = highlightHolder.transform;
					obj2.AddComponent<MeshFilter>().sharedMesh = meshFilter.sharedMesh;
					MeshRenderer meshRenderer = obj2.AddComponent<MeshRenderer>();
					Material[] array2 = new Material[component.sharedMaterials.Length];
					for (int l = 0; l < array2.Length; l++)
					{
						array2[l] = highlightMat;
					}
					meshRenderer.sharedMaterials = array2;
					highlightRenderers[k] = meshRenderer;
					existingRenderers[k] = component;
				}
			}
		}

		protected virtual void UpdateHighlightRenderers()
		{
			if (highlightHolder == null)
			{
				return;
			}
			for (int i = 0; i < existingSkinnedRenderers.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = existingSkinnedRenderers[i];
				SkinnedMeshRenderer skinnedMeshRenderer2 = highlightSkinnedRenderers[i];
				if (skinnedMeshRenderer != null && skinnedMeshRenderer2 != null && !attachedToHand)
				{
					skinnedMeshRenderer2.transform.position = skinnedMeshRenderer.transform.position;
					skinnedMeshRenderer2.transform.rotation = skinnedMeshRenderer.transform.rotation;
					skinnedMeshRenderer2.transform.localScale = skinnedMeshRenderer.transform.lossyScale;
					skinnedMeshRenderer2.localBounds = skinnedMeshRenderer.localBounds;
					skinnedMeshRenderer2.enabled = isHovering && skinnedMeshRenderer.enabled && skinnedMeshRenderer.gameObject.activeInHierarchy;
					int blendShapeCount = skinnedMeshRenderer.sharedMesh.blendShapeCount;
					for (int j = 0; j < blendShapeCount; j++)
					{
						skinnedMeshRenderer2.SetBlendShapeWeight(j, skinnedMeshRenderer.GetBlendShapeWeight(j));
					}
				}
				else if (skinnedMeshRenderer2 != null)
				{
					skinnedMeshRenderer2.enabled = false;
				}
			}
			for (int k = 0; k < highlightRenderers.Length; k++)
			{
				MeshRenderer meshRenderer = existingRenderers[k];
				MeshRenderer meshRenderer2 = highlightRenderers[k];
				if (meshRenderer != null && meshRenderer2 != null && !attachedToHand)
				{
					meshRenderer2.transform.position = meshRenderer.transform.position;
					meshRenderer2.transform.rotation = meshRenderer.transform.rotation;
					meshRenderer2.transform.localScale = meshRenderer.transform.lossyScale;
					meshRenderer2.enabled = isHovering && meshRenderer.enabled && meshRenderer.gameObject.activeInHierarchy;
				}
				else if (meshRenderer2 != null)
				{
					meshRenderer2.enabled = false;
				}
			}
		}

		protected virtual void OnHandHoverBegin(Hand hand)
		{
			wasHovering = isHovering;
			isHovering = true;
			hoveringHands.Add(hand);
			if (highlightOnHover && !wasHovering)
			{
				CreateHighlightRenderers();
				UpdateHighlightRenderers();
			}
		}

		protected virtual void OnHandHoverEnd(Hand hand)
		{
			wasHovering = isHovering;
			hoveringHands.Remove(hand);
			if (hoveringHands.Count == 0)
			{
				isHovering = false;
				if (highlightOnHover && highlightHolder != null)
				{
					UnityEngine.Object.Destroy(highlightHolder);
				}
			}
		}

		protected virtual void Update()
		{
			if (highlightOnHover)
			{
				UpdateHighlightRenderers();
				if (!isHovering && highlightHolder != null)
				{
					UnityEngine.Object.Destroy(highlightHolder);
				}
			}
		}

		protected virtual void OnAttachedToHand(Hand hand)
		{
			if (activateActionSetOnAttach != null)
			{
				activateActionSetOnAttach.Activate(hand.handType);
			}
			if (this.onAttachedToHand != null)
			{
				this.onAttachedToHand(hand);
			}
			if (skeletonPoser != null && hand.skeleton != null)
			{
				hand.skeleton.BlendToPoser(skeletonPoser, blendToPoseTime);
			}
			attachedToHand = hand;
		}

		protected virtual void OnDetachedFromHand(Hand hand)
		{
			if (activateActionSetOnAttach != null && (hand.otherHand == null || !hand.otherHand.currentAttachedObjectInfo.HasValue || (hand.otherHand.currentAttachedObjectInfo.Value.interactable != null && hand.otherHand.currentAttachedObjectInfo.Value.interactable.activateActionSetOnAttach != activateActionSetOnAttach)))
			{
				activateActionSetOnAttach.Deactivate(hand.handType);
			}
			if (this.onDetachedFromHand != null)
			{
				this.onDetachedFromHand(hand);
			}
			if (skeletonPoser != null && hand.skeleton != null)
			{
				hand.skeleton.BlendToSkeleton(releasePoseBlendTime);
			}
			attachedToHand = null;
		}

		protected virtual void OnDestroy()
		{
			isDestroying = true;
			if (attachedToHand != null)
			{
				attachedToHand.DetachObject(base.gameObject, restoreOriginalParent: false);
				attachedToHand.skeleton.BlendToSkeleton();
			}
			if (highlightHolder != null)
			{
				UnityEngine.Object.Destroy(highlightHolder);
			}
		}

		protected virtual void OnDisable()
		{
			isDestroying = true;
			if (attachedToHand != null)
			{
				attachedToHand.ForceHoverUnlock();
			}
			if (highlightHolder != null)
			{
				UnityEngine.Object.Destroy(highlightHolder);
			}
		}
	}
	public class InteractableDebug : MonoBehaviour
	{
		[NonSerialized]
		public Hand attachedToHand;

		public float simulateReleasesForXSecondsAroundRelease;

		public float simulateReleasesEveryXSeconds = 0.005f;

		public bool setPositionsForSimulations;

		private Renderer[] selfRenderers;

		private Collider[] colliders;

		private Color lastColor;

		private Throwable throwable;

		private const bool onlyColorOnChange = true;

		public Rigidbody rigidbody;

		private bool isSimulation;

		private bool isThrowable => throwable != null;

		private void Awake()
		{
			selfRenderers = GetComponentsInChildren<Renderer>();
			throwable = GetComponent<Throwable>();
			rigidbody = GetComponent<Rigidbody>();
			colliders = GetComponentsInChildren<Collider>();
		}

		private void OnAttachedToHand(Hand hand)
		{
			attachedToHand = hand;
			CreateMarker(Color.green);
		}

		protected virtual void HandAttachedUpdate(Hand hand)
		{
			Color color = hand.currentAttachedObjectInfo.Value.grabbedWithType switch
			{
				GrabTypes.Grip => Color.blue, 
				GrabTypes.Pinch => Color.green, 
				GrabTypes.Trigger => Color.yellow, 
				GrabTypes.Scripted => Color.red, 
				_ => Color.white, 
			};
			if (color != lastColor)
			{
				ColorSelf(color);
			}
			lastColor = color;
		}

		private void OnDetachedFromHand(Hand hand)
		{
			if (isThrowable)
			{
				throwable.GetReleaseVelocities(hand, out var velocity, out var _);
				CreateMarker(Color.cyan, velocity.normalized);
			}
			CreateMarker(Color.red);
			attachedToHand = null;
			if (isSimulation || simulateReleasesForXSecondsAroundRelease == 0f)
			{
				return;
			}
			float num = 0f - simulateReleasesForXSecondsAroundRelease;
			float num2 = simulateReleasesForXSecondsAroundRelease;
			List<InteractableDebug> list = new List<InteractableDebug>();
			list.Add(this);
			for (float num3 = num; num3 <= num2; num3 += simulateReleasesEveryXSeconds)
			{
				float t = Mathf.InverseLerp(num, num2, num3);
				InteractableDebug item = CreateSimulation(hand, num3, Color.Lerp(Color.red, Color.green, t));
				list.Add(item);
			}
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					list[i].IgnoreObject(list[j]);
				}
			}
		}

		public Collider[] GetColliders()
		{
			return colliders;
		}

		public void IgnoreObject(InteractableDebug otherInteractable)
		{
			Collider[] array = otherInteractable.GetColliders();
			for (int i = 0; i < colliders.Length; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					Physics.IgnoreCollision(colliders[i], array[j]);
				}
			}
		}

		public void SetIsSimulation()
		{
			isSimulation = true;
		}

		private InteractableDebug CreateSimulation(Hand fromHand, float timeOffset, Color copyColor)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(base.gameObject);
			InteractableDebug component = gameObject.GetComponent<InteractableDebug>();
			component.SetIsSimulation();
			component.ColorSelf(copyColor);
			gameObject.name = $"{gameObject.name} [offset: {timeOffset:0.000}]";
			Vector3 trackedObjectVelocity = fromHand.GetTrackedObjectVelocity(timeOffset);
			trackedObjectVelocity *= throwable.scaleReleaseVelocity;
			component.rigidbody.linearVelocity = trackedObjectVelocity;
			return component;
		}

		private void CreateMarker(Color markerColor, float destroyAfter = 10f)
		{
			CreateMarker(markerColor, attachedToHand.GetTrackedObjectVelocity().normalized, destroyAfter);
		}

		private void CreateMarker(Color markerColor, Vector3 forward, float destroyAfter = 10f)
		{
			GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<Collider>());
			gameObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
			gameObject2.transform.localScale = new Vector3(0.01f, 0.01f, 0.25f);
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.localPosition = new Vector3(0f, 0f, gameObject2.transform.localScale.z / 2f);
			gameObject.transform.position = attachedToHand.transform.position;
			gameObject.transform.forward = forward;
			ColorThing(markerColor, gameObject.GetComponentsInChildren<Renderer>());
			if (destroyAfter > 0f)
			{
				UnityEngine.Object.Destroy(gameObject, destroyAfter);
			}
		}

		private void ColorSelf(Color newColor)
		{
			ColorThing(newColor, selfRenderers);
		}

		private void ColorThing(Color newColor, Renderer[] renderers)
		{
			for (int i = 0; i < renderers.Length; i++)
			{
				renderers[i].material.color = newColor;
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class InteractableHoverEvents : MonoBehaviour
	{
		public UnityEvent onHandHoverBegin;

		public UnityEvent onHandHoverEnd;

		public UnityEvent onAttachedToHand;

		public UnityEvent onDetachedFromHand;

		private void OnHandHoverBegin()
		{
			onHandHoverBegin.Invoke();
		}

		private void OnHandHoverEnd()
		{
			onHandHoverEnd.Invoke();
		}

		private void OnAttachedToHand(Hand hand)
		{
			onAttachedToHand.Invoke();
		}

		private void OnDetachedFromHand(Hand hand)
		{
			onDetachedFromHand.Invoke();
		}
	}
	public class ItemPackage : MonoBehaviour
	{
		public enum ItemPackageType
		{
			Unrestricted,
			OneHanded,
			TwoHanded
		}

		public new string name;

		public ItemPackageType packageType;

		public GameObject itemPrefab;

		public GameObject otherHandItemPrefab;

		public GameObject previewPrefab;

		public GameObject fadedPreviewPrefab;
	}
	public class ItemPackageReference : MonoBehaviour
	{
		public ItemPackage itemPackage;
	}
	[RequireComponent(typeof(Interactable))]
	public class ItemPackageSpawner : MonoBehaviour
	{
		public ItemPackage _itemPackage;

		public bool useItemPackagePreview = true;

		private bool useFadedPreview;

		private GameObject previewObject;

		public bool requireGrabActionToTake;

		public bool requireReleaseActionToReturn;

		public bool showTriggerHint;

		[EnumFlags]
		public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.SnapOnAttach | Hand.AttachmentFlags.DetachOthers | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.TurnOnKinematic;

		public bool takeBackItem;

		public bool acceptDifferentItems;

		private GameObject spawnedItem;

		private bool itemIsSpawned;

		public UnityEvent pickupEvent;

		public UnityEvent dropEvent;

		public bool justPickedUpItem;

		public ItemPackage itemPackage
		{
			get
			{
				return _itemPackage;
			}
			set
			{
				CreatePreviewObject();
			}
		}

		private void CreatePreviewObject()
		{
			if (!useItemPackagePreview)
			{
				return;
			}
			ClearPreview();
			if (!useItemPackagePreview || itemPackage == null)
			{
				return;
			}
			if (!useFadedPreview)
			{
				if (itemPackage.previewPrefab != null)
				{
					previewObject = UnityEngine.Object.Instantiate(itemPackage.previewPrefab, base.transform.position, Quaternion.identity);
					previewObject.transform.parent = base.transform;
					previewObject.transform.localRotation = Quaternion.identity;
				}
			}
			else if (itemPackage.fadedPreviewPrefab != null)
			{
				previewObject = UnityEngine.Object.Instantiate(itemPackage.fadedPreviewPrefab, base.transform.position, Quaternion.identity);
				previewObject.transform.parent = base.transform;
				previewObject.transform.localRotation = Quaternion.identity;
			}
		}

		private void Start()
		{
			VerifyItemPackage();
		}

		private void VerifyItemPackage()
		{
			if (itemPackage == null)
			{
				ItemPackageNotValid();
			}
			if (itemPackage.itemPrefab == null)
			{
				ItemPackageNotValid();
			}
		}

		private void ItemPackageNotValid()
		{
			UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> ItemPackage assigned to " + base.gameObject.name + " is not valid. Destroying this game object.", this);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void ClearPreview()
		{
			foreach (Transform item in base.transform)
			{
				if (Time.time > 0f)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(item.gameObject);
				}
			}
		}

		private void Update()
		{
			if (itemIsSpawned && spawnedItem == null)
			{
				itemIsSpawned = false;
				useFadedPreview = false;
				dropEvent.Invoke();
				CreatePreviewObject();
			}
		}

		private void OnHandHoverBegin(Hand hand)
		{
			if (GetAttachedItemPackage(hand) == itemPackage && takeBackItem && !requireReleaseActionToReturn)
			{
				TakeBackItem(hand);
			}
			if (!requireGrabActionToTake)
			{
				SpawnAndAttachObject(hand, GrabTypes.Scripted);
			}
			if (requireGrabActionToTake && showTriggerHint)
			{
				hand.ShowGrabHint("PickUp");
			}
		}

		private void TakeBackItem(Hand hand)
		{
			RemoveMatchingItemsFromHandStack(itemPackage, hand);
			if (itemPackage.packageType == ItemPackage.ItemPackageType.TwoHanded)
			{
				RemoveMatchingItemsFromHandStack(itemPackage, hand.otherHand);
			}
		}

		private ItemPackage GetAttachedItemPackage(Hand hand)
		{
			if (hand.currentAttachedObject == null)
			{
				return null;
			}
			ItemPackageReference component = hand.currentAttachedObject.GetComponent<ItemPackageReference>();
			if (component == null)
			{
				return null;
			}
			return component.itemPackage;
		}

		private void HandHoverUpdate(Hand hand)
		{
			if (takeBackItem && requireReleaseActionToReturn && hand.isActive)
			{
				ItemPackage attachedItemPackage = GetAttachedItemPackage(hand);
				if (attachedItemPackage == itemPackage && hand.IsGrabEnding(attachedItemPackage.gameObject))
				{
					TakeBackItem(hand);
					return;
				}
			}
			if (requireGrabActionToTake && hand.GetGrabStarting() != GrabTypes.None)
			{
				SpawnAndAttachObject(hand, GrabTypes.Scripted);
			}
		}

		private void OnHandHoverEnd(Hand hand)
		{
			if (!justPickedUpItem && requireGrabActionToTake && showTriggerHint)
			{
				hand.HideGrabHint();
			}
			justPickedUpItem = false;
		}

		private void RemoveMatchingItemsFromHandStack(ItemPackage package, Hand hand)
		{
			if (hand == null)
			{
				return;
			}
			for (int i = 0; i < hand.AttachedObjects.Count; i++)
			{
				ItemPackageReference component = hand.AttachedObjects[i].attachedObject.GetComponent<ItemPackageReference>();
				if (component != null)
				{
					ItemPackage itemPackage = component.itemPackage;
					if (itemPackage != null && itemPackage == package)
					{
						GameObject attachedObject = hand.AttachedObjects[i].attachedObject;
						hand.DetachObject(attachedObject);
					}
				}
			}
		}

		private void RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType packageType, Hand hand)
		{
			for (int i = 0; i < hand.AttachedObjects.Count; i++)
			{
				ItemPackageReference component = hand.AttachedObjects[i].attachedObject.GetComponent<ItemPackageReference>();
				if (component != null && component.itemPackage.packageType == packageType)
				{
					GameObject attachedObject = hand.AttachedObjects[i].attachedObject;
					hand.DetachObject(attachedObject);
				}
			}
		}

		private void SpawnAndAttachObject(Hand hand, GrabTypes grabType)
		{
			if (hand.otherHand != null && GetAttachedItemPackage(hand.otherHand) == itemPackage)
			{
				TakeBackItem(hand.otherHand);
			}
			if (showTriggerHint)
			{
				hand.HideGrabHint();
			}
			if (itemPackage.otherHandItemPrefab != null && hand.otherHand.hoverLocked)
			{
				UnityEngine.Debug.Log("<b>[SteamVR Interaction]</b> Not attaching objects because other hand is hoverlocked and we can't deliver both items.");
				return;
			}
			if (itemPackage.packageType == ItemPackage.ItemPackageType.OneHanded)
			{
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.OneHanded, hand);
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.TwoHanded, hand);
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.TwoHanded, hand.otherHand);
			}
			if (itemPackage.packageType == ItemPackage.ItemPackageType.TwoHanded)
			{
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.OneHanded, hand);
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.OneHanded, hand.otherHand);
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.TwoHanded, hand);
				RemoveMatchingItemTypesFromHand(ItemPackage.ItemPackageType.TwoHanded, hand.otherHand);
			}
			spawnedItem = UnityEngine.Object.Instantiate(itemPackage.itemPrefab);
			spawnedItem.SetActive(value: true);
			hand.AttachObject(spawnedItem, grabType, attachmentFlags);
			if (itemPackage.otherHandItemPrefab != null && hand.otherHand.isActive)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(itemPackage.otherHandItemPrefab);
				gameObject.SetActive(value: true);
				hand.otherHand.AttachObject(gameObject, grabType, attachmentFlags);
			}
			itemIsSpawned = true;
			justPickedUpItem = true;
			if (takeBackItem)
			{
				useFadedPreview = true;
				pickupEvent.Invoke();
				CreatePreviewObject();
			}
		}
	}
	public class LinearAnimation : MonoBehaviour
	{
		public LinearMapping linearMapping;

		public Animation animation;

		private AnimationState animState;

		private float animLength;

		private float lastValue;

		private void Awake()
		{
			if (animation == null)
			{
				animation = GetComponent<Animation>();
			}
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
			animation.playAutomatically = true;
			animState = animation[animation.clip.name];
			animState.wrapMode = WrapMode.PingPong;
			animState.speed = 0f;
			animLength = animState.length;
		}

		private void Update()
		{
			float value = linearMapping.value;
			if (value != lastValue)
			{
				animState.time = value * animLength;
			}
			lastValue = value;
		}
	}
	public class LinearAnimator : MonoBehaviour
	{
		public LinearMapping linearMapping;

		public Animator animator;

		private float currentLinearMapping = float.NaN;

		private int framesUnchanged;

		private void Awake()
		{
			if (animator == null)
			{
				animator = GetComponent<Animator>();
			}
			animator.speed = 0f;
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}

		private void Update()
		{
			if (currentLinearMapping != linearMapping.value)
			{
				currentLinearMapping = linearMapping.value;
				animator.enabled = true;
				animator.Play(0, 0, currentLinearMapping);
				framesUnchanged = 0;
			}
			else
			{
				framesUnchanged++;
				if (framesUnchanged > 2)
				{
					animator.enabled = false;
				}
			}
		}
	}
	public class LinearAudioPitch : MonoBehaviour
	{
		public LinearMapping linearMapping;

		public AnimationCurve pitchCurve;

		public float minPitch;

		public float maxPitch;

		public bool applyContinuously = true;

		private AudioSource audioSource;

		private void Awake()
		{
			if (audioSource == null)
			{
				audioSource = GetComponent<AudioSource>();
			}
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}

		private void Update()
		{
			if (applyContinuously)
			{
				Apply();
			}
		}

		private void Apply()
		{
			float t = pitchCurve.Evaluate(linearMapping.value);
			audioSource.pitch = Mathf.Lerp(minPitch, maxPitch, t);
		}
	}
	public class LinearBlendshape : MonoBehaviour
	{
		public LinearMapping linearMapping;

		public SkinnedMeshRenderer skinnedMesh;

		private float lastValue;

		private void Awake()
		{
			if (skinnedMesh == null)
			{
				skinnedMesh = GetComponent<SkinnedMeshRenderer>();
			}
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}

		private void Update()
		{
			float value = linearMapping.value;
			if (value != lastValue)
			{
				float value2 = Util.RemapNumberClamped(value, 0f, 1f, 1f, 100f);
				skinnedMesh.SetBlendShapeWeight(0, value2);
			}
			lastValue = value;
		}
	}
	public class LinearDisplacement : MonoBehaviour
	{
		public Vector3 displacement;

		public LinearMapping linearMapping;

		private Vector3 initialPosition;

		private void Start()
		{
			initialPosition = base.transform.localPosition;
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}

		private void Update()
		{
			if ((bool)linearMapping)
			{
				base.transform.localPosition = initialPosition + linearMapping.value * displacement;
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class LinearDrive : MonoBehaviour
	{
		public Transform startPosition;

		public Transform endPosition;

		public LinearMapping linearMapping;

		public bool repositionGameObject = true;

		public bool maintainMomemntum = true;

		public float momemtumDampenRate = 5f;

		protected Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

		protected float initialMappingOffset;

		protected int numMappingChangeSamples = 5;

		protected float[] mappingChangeSamples;

		protected float prevMapping;

		protected float mappingChangeRate;

		protected int sampleCount;

		protected Interactable interactable;

		protected virtual void Awake()
		{
			mappingChangeSamples = new float[numMappingChangeSamples];
			interactable = GetComponent<Interactable>();
		}

		protected virtual void Start()
		{
			if (linearMapping == null)
			{
				linearMapping = GetComponent<LinearMapping>();
			}
			if (linearMapping == null)
			{
				linearMapping = base.gameObject.AddComponent<LinearMapping>();
			}
			initialMappingOffset = linearMapping.value;
			if (repositionGameObject)
			{
				UpdateLinearMapping(base.transform);
			}
		}

		protected virtual void HandHoverUpdate(Hand hand)
		{
			GrabTypes grabStarting = hand.GetGrabStarting();
			if (interactable.attachedToHand == null && grabStarting != GrabTypes.None)
			{
				initialMappingOffset = linearMapping.value - CalculateLinearMapping(hand.transform);
				sampleCount = 0;
				mappingChangeRate = 0f;
				hand.AttachObject(base.gameObject, grabStarting, attachmentFlags);
			}
		}

		protected virtual void HandAttachedUpdate(Hand hand)
		{
			UpdateLinearMapping(hand.transform);
			if (hand.IsGrabEnding(base.gameObject))
			{
				hand.DetachObject(base.gameObject);
			}
		}

		protected virtual void OnDetachedFromHand(Hand hand)
		{
			CalculateMappingChangeRate();
		}

		protected void CalculateMappingChangeRate()
		{
			mappingChangeRate = 0f;
			int num = Mathf.Min(sampleCount, mappingChangeSamples.Length);
			if (num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					mappingChangeRate += mappingChangeSamples[i];
				}
				mappingChangeRate /= num;
			}
		}

		protected void UpdateLinearMapping(Transform updateTransform)
		{
			prevMapping = linearMapping.value;
			linearMapping.value = Mathf.Clamp01(initialMappingOffset + CalculateLinearMapping(updateTransform));
			mappingChangeSamples[sampleCount % mappingChangeSamples.Length] = 1f / Time.deltaTime * (linearMapping.value - prevMapping);
			sampleCount++;
			if (repositionGameObject)
			{
				base.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, linearMapping.value);
			}
		}

		protected float CalculateLinearMapping(Transform updateTransform)
		{
			Vector3 rhs = endPosition.position - startPosition.position;
			float magnitude = rhs.magnitude;
			rhs.Normalize();
			return Vector3.Dot(updateTransform.position - startPosition.position, rhs) / magnitude;
		}

		protected virtual void Update()
		{
			if (maintainMomemntum && mappingChangeRate != 0f)
			{
				mappingChangeRate = Mathf.Lerp(mappingChangeRate, 0f, momemtumDampenRate * Time.deltaTime);
				linearMapping.value = Mathf.Clamp01(linearMapping.value + mappingChangeRate * Time.deltaTime);
				if (repositionGameObject)
				{
					base.transform.position = Vector3.Lerp(startPosition.position, endPosition.position, linearMapping.value);
				}
			}
		}
	}
	public class LinearMapping : MonoBehaviour
	{
		public float value;
	}
	public class ModalThrowable : Throwable
	{
		[Tooltip("The local point which acts as a positional and rotational offset to use while held with a grip type grab")]
		public Transform gripOffset;

		[Tooltip("The local point which acts as a positional and rotational offset to use while held with a pinch type grab")]
		public Transform pinchOffset;

		protected override void HandHoverUpdate(Hand hand)
		{
			GrabTypes grabStarting = hand.GetGrabStarting();
			switch (grabStarting)
			{
			case GrabTypes.Pinch:
				hand.AttachObject(base.gameObject, grabStarting, attachmentFlags, pinchOffset);
				break;
			case GrabTypes.Grip:
				hand.AttachObject(base.gameObject, grabStarting, attachmentFlags, gripOffset);
				break;
			default:
				hand.AttachObject(base.gameObject, grabStarting, attachmentFlags, attachmentOffset);
				break;
			case GrabTypes.None:
				return;
			}
			hand.HideGrabHint();
		}

		protected override void HandAttachedUpdate(Hand hand)
		{
			if (interactable.skeletonPoser != null)
			{
				interactable.skeletonPoser.SetBlendingBehaviourEnabled("PinchPose", hand.currentAttachedObjectInfo.Value.grabbedWithType == GrabTypes.Pinch);
			}
			base.HandAttachedUpdate(hand);
		}
	}
	public class Player : MonoBehaviour
	{
		[Tooltip("Virtual transform corresponding to the meatspace tracking origin. Devices are tracked relative to this.")]
		public Transform trackingOriginTransform;

		[Tooltip("List of possible transforms for the head/HMD, including the no-SteamVR fallback camera.")]
		public Transform[] hmdTransforms;

		[Tooltip("List of possible Hands, including no-SteamVR fallback Hands.")]
		public Hand[] hands;

		[Tooltip("Reference to the physics collider that follows the player's HMD position.")]
		public Collider headCollider;

		[Tooltip("These objects are enabled when SteamVR is available")]
		public GameObject rigSteamVR;

		[Tooltip("These objects are enabled when SteamVR is not available, or when the user toggles out of VR")]
		public GameObject rig2DFallback;

		[Tooltip("The audio listener for this player")]
		public Transform audioListener;

		[Tooltip("This action lets you know when the player has placed the headset on their head")]
		public SteamVR_Action_Boolean headsetOnHead = SteamVR_Input.GetBooleanAction("HeadsetOnHead");

		public bool allowToggleTo2D = true;

		private static Player _instance;

		public static Player instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindObjectOfType<Player>();
				}
				return _instance;
			}
		}

		public int handCount
		{
			get
			{
				int num = 0;
				for (int i = 0; i < hands.Length; i++)
				{
					if (hands[i].gameObject.activeInHierarchy)
					{
						num++;
					}
				}
				return num;
			}
		}

		public Hand leftHand
		{
			get
			{
				for (int i = 0; i < hands.Length; i++)
				{
					if (hands[i].gameObject.activeInHierarchy && hands[i].handType == SteamVR_Input_Sources.LeftHand)
					{
						return hands[i];
					}
				}
				return null;
			}
		}

		public Hand rightHand
		{
			get
			{
				for (int i = 0; i < hands.Length; i++)
				{
					if (hands[i].gameObject.activeInHierarchy && hands[i].handType == SteamVR_Input_Sources.RightHand)
					{
						return hands[i];
					}
				}
				return null;
			}
		}

		public float scale => base.transform.lossyScale.x;

		public Transform hmdTransform
		{
			get
			{
				if (hmdTransforms != null)
				{
					for (int i = 0; i < hmdTransforms.Length; i++)
					{
						if (hmdTransforms[i].gameObject.activeInHierarchy)
						{
							return hmdTransforms[i];
						}
					}
				}
				return null;
			}
		}

		public float eyeHeight
		{
			get
			{
				Transform transform = hmdTransform;
				if ((bool)transform)
				{
					return Vector3.Project(transform.position - trackingOriginTransform.position, trackingOriginTransform.up).magnitude / trackingOriginTransform.lossyScale.x;
				}
				return 0f;
			}
		}

		public Vector3 feetPositionGuess
		{
			get
			{
				Transform transform = hmdTransform;
				if ((bool)transform)
				{
					return trackingOriginTransform.position + Vector3.ProjectOnPlane(transform.position - trackingOriginTransform.position, trackingOriginTransform.up);
				}
				return trackingOriginTransform.position;
			}
		}

		public Vector3 bodyDirectionGuess
		{
			get
			{
				Transform transform = hmdTransform;
				if ((bool)transform)
				{
					Vector3 vector = Vector3.ProjectOnPlane(transform.forward, trackingOriginTransform.up);
					if (Vector3.Dot(transform.up, trackingOriginTransform.up) < 0f)
					{
						vector = -vector;
					}
					return vector;
				}
				return trackingOriginTransform.forward;
			}
		}

		public Hand GetHand(int i)
		{
			for (int j = 0; j < hands.Length; j++)
			{
				if (hands[j].gameObject.activeInHierarchy)
				{
					if (i <= 0)
					{
						return hands[j];
					}
					i--;
				}
			}
			return null;
		}

		private void Awake()
		{
			if (trackingOriginTransform == null)
			{
				trackingOriginTransform = base.transform;
			}
			if (hmdTransforms == null)
			{
				return;
			}
			Transform[] array = hmdTransforms;
			foreach (Transform transform in array)
			{
				if (transform.GetComponent<TrackedPoseDriver>() == null)
				{
					transform.gameObject.AddComponent<TrackedPoseDriver>();
				}
			}
		}

		private IEnumerator Start()
		{
			_instance = this;
			while (SteamVR.initializedState == SteamVR.InitializedStates.None || SteamVR.initializedState == SteamVR.InitializedStates.Initializing)
			{
				yield return null;
			}
			if (SteamVR.instance != null)
			{
				ActivateRig(rigSteamVR);
			}
			else
			{
				ActivateRig(rig2DFallback);
			}
		}

		protected virtual void Update()
		{
			if (SteamVR.initializedState == SteamVR.InitializedStates.InitializeSuccess && headsetOnHead != null)
			{
				if (headsetOnHead.GetStateDown(SteamVR_Input_Sources.Head))
				{
					UnityEngine.Debug.Log("<b>SteamVR Interaction System</b> Headset placed on head");
				}
				else if (headsetOnHead.GetStateUp(SteamVR_Input_Sources.Head))
				{
					UnityEngine.Debug.Log("<b>SteamVR Interaction System</b> Headset removed");
				}
			}
		}

		private void OnDrawGizmos()
		{
			if (this != instance)
			{
				return;
			}
			Gizmos.color = Color.white;
			Gizmos.DrawIcon(feetPositionGuess, "vr_interaction_system_feet.png");
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(feetPositionGuess, feetPositionGuess + trackingOriginTransform.up * eyeHeight);
			Gizmos.color = Color.blue;
			Vector3 vector = bodyDirectionGuess;
			Vector3 vector2 = Vector3.Cross(trackingOriginTransform.up, vector);
			Vector3 vector3 = feetPositionGuess + trackingOriginTransform.up * eyeHeight * 0.75f;
			Vector3 vector4 = vector3 + vector * 0.33f;
			Gizmos.DrawLine(vector3, vector4);
			Gizmos.DrawLine(vector4, vector4 - 0.033f * (vector + vector2));
			Gizmos.DrawLine(vector4, vector4 - 0.033f * (vector - vector2));
			Gizmos.color = Color.red;
			int num = handCount;
			for (int i = 0; i < num; i++)
			{
				Hand hand = GetHand(i);
				if (hand.handType == SteamVR_Input_Sources.LeftHand)
				{
					Gizmos.DrawIcon(hand.transform.position, "vr_interaction_system_left_hand.png");
				}
				else if (hand.handType == SteamVR_Input_Sources.RightHand)
				{
					Gizmos.DrawIcon(hand.transform.position, "vr_interaction_system_right_hand.png");
				}
			}
		}

		public void Draw2DDebug()
		{
			if (!allowToggleTo2D || !SteamVR.active)
			{
				return;
			}
			int num = 100;
			int num2 = 25;
			int num3 = Screen.width / 2 - num / 2;
			int num4 = Screen.height - num2 - 10;
			if (GUI.Button(text: rigSteamVR.activeSelf ? "2D Debug" : "VR", position: new Rect(num3, num4, num, num2)))
			{
				if (rigSteamVR.activeSelf)
				{
					ActivateRig(rig2DFallback);
				}
				else
				{
					ActivateRig(rigSteamVR);
				}
			}
		}

		private void ActivateRig(GameObject rig)
		{
			rigSteamVR.SetActive(rig == rigSteamVR);
			rig2DFallback.SetActive(rig == rig2DFallback);
			if ((bool)audioListener)
			{
				audioListener.transform.parent = hmdTransform;
				audioListener.transform.localPosition = Vector3.zero;
				audioListener.transform.localRotation = Quaternion.identity;
			}
		}

		public void PlayerShotSelf()
		{
		}
	}
	[RequireComponent(typeof(AudioSource))]
	public class PlaySound : MonoBehaviour
	{
		[Tooltip("List of audio clips to play.")]
		public AudioClip[] waveFile;

		[Tooltip("Stops the currently playing clip in the audioSource. Otherwise clips will overlap/mix.")]
		public bool stopOnPlay;

		[Tooltip("After the audio clip finishes playing, disable the game object the sound is on.")]
		public bool disableOnEnd;

		[Tooltip("Loop the sound after the wave file variation has been chosen.")]
		public bool looping;

		[Tooltip("If the sound is looping and updating it's position every frame, stop the sound at the end of the wav/clip length. ")]
		public bool stopOnEnd;

		[Tooltip("Start a wave file playing on awake, but after a delay.")]
		public bool playOnAwakeWithDelay;

		[Header("Random Volume")]
		public bool useRandomVolume = true;

		[Tooltip("Minimum volume that will be used when randomly set.")]
		[Range(0f, 1f)]
		public float volMin = 1f;

		[Tooltip("Maximum volume that will be used when randomly set.")]
		[Range(0f, 1f)]
		public float volMax = 1f;

		[Header("Random Pitch")]
		[Tooltip("Use min and max random pitch levels when playing sounds.")]
		public bool useRandomPitch = true;

		[Tooltip("Minimum pitch that will be used when randomly set.")]
		[Range(-3f, 3f)]
		public float pitchMin = 1f;

		[Tooltip("Maximum pitch that will be used when randomly set.")]
		[Range(-3f, 3f)]
		public float pitchMax = 1f;

		[Header("Random Time")]
		[Tooltip("Use Retrigger Time to repeat the sound within a time range")]
		public bool useRetriggerTime;

		[Tooltip("Inital time before the first repetion starts")]
		[Range(0f, 360f)]
		public float timeInitial;

		[Tooltip("Minimum time that will pass before the sound is retriggered")]
		[Range(0f, 360f)]
		public float timeMin;

		[Tooltip("Maximum pitch that will be used when randomly set.")]
		[Range(0f, 360f)]
		public float timeMax;

		[Header("Random Silence")]
		[Tooltip("Use Retrigger Time to repeat the sound within a time range")]
		public bool useRandomSilence;

		[Tooltip("Percent chance that the wave file will not play")]
		[Range(0f, 1f)]
		public float percentToNotPlay;

		[Header("Delay Time")]
		[Tooltip("Time to offset playback of sound")]
		public float delayOffsetTime;

		private AudioSource audioSource;

		private AudioClip clip;

		private void Awake()
		{
			audioSource = GetComponent<AudioSource>();
			clip = audioSource.clip;
			if (audioSource.playOnAwake)
			{
				if (useRetriggerTime)
				{
					InvokeRepeating("Play", timeInitial, UnityEngine.Random.Range(timeMin, timeMax));
				}
				else
				{
					Play();
				}
			}
			else if (!audioSource.playOnAwake && playOnAwakeWithDelay)
			{
				PlayWithDelay(delayOffsetTime);
				if (useRetriggerTime)
				{
					InvokeRepeating("Play", timeInitial, UnityEngine.Random.Range(timeMin, timeMax));
				}
			}
			else if (audioSource.playOnAwake && playOnAwakeWithDelay)
			{
				PlayWithDelay(delayOffsetTime);
				if (useRetriggerTime)
				{
					InvokeRepeating("Play", timeInitial, UnityEngine.Random.Range(timeMin, timeMax));
				}
			}
		}

		public void Play()
		{
			if (looping)
			{
				PlayLooping();
			}
			else
			{
				PlayOneShotSound();
			}
		}

		public void PlayWithDelay(float delayTime)
		{
			if (looping)
			{
				Invoke("PlayLooping", delayTime);
			}
			else
			{
				Invoke("PlayOneShotSound", delayTime);
			}
		}

		public AudioClip PlayOneShotSound()
		{
			if (!audioSource.isActiveAndEnabled)
			{
				return null;
			}
			SetAudioSource();
			if (stopOnPlay)
			{
				audioSource.Stop();
			}
			if (disableOnEnd)
			{
				Invoke("Disable", clip.length);
			}
			audioSource.PlayOneShot(clip);
			return clip;
		}

		public AudioClip PlayLooping()
		{
			SetAudioSource();
			if (!audioSource.loop)
			{
				audioSource.loop = true;
			}
			audioSource.Play();
			if (stopOnEnd)
			{
				Invoke("Stop", audioSource.clip.length);
			}
			return clip;
		}

		public void Disable()
		{
			base.gameObject.SetActive(value: false);
		}

		public void Stop()
		{
			audioSource.Stop();
		}

		private void SetAudioSource()
		{
			if (useRandomVolume)
			{
				audioSource.volume = UnityEngine.Random.Range(volMin, volMax);
				if (useRandomSilence && (float)UnityEngine.Random.Range(0, 1) < percentToNotPlay)
				{
					audioSource.volume = 0f;
				}
			}
			if (useRandomPitch)
			{
				audioSource.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
			}
			if (waveFile.Length != 0)
			{
				audioSource.clip = waveFile[UnityEngine.Random.Range(0, waveFile.Length)];
				clip = audioSource.clip;
			}
		}
	}
	public class RenderModel : MonoBehaviour
	{
		public GameObject handPrefab;

		protected GameObject handInstance;

		protected Renderer[] handRenderers;

		public bool displayHandByDefault = true;

		protected SteamVR_Behaviour_Skeleton handSkeleton;

		protected Animator handAnimator;

		protected string animatorParameterStateName = "AnimationState";

		protected int handAnimatorStateId = -1;

		[Space]
		public GameObject controllerPrefab;

		protected GameObject controllerInstance;

		protected Renderer[] controllerRenderers;

		protected SteamVR_RenderModel controllerRenderModel;

		public bool displayControllerByDefault = true;

		protected Material delayedSetMaterial;

		protected SteamVR_Events.Action renderModelLoadedAction;

		protected SteamVR_Input_Sources inputSource;

		public EVRSkeletalMotionRange GetSkeletonRangeOfMotion
		{
			get
			{
				if (handSkeleton != null)
				{
					return handSkeleton.rangeOfMotion;
				}
				return EVRSkeletalMotionRange.WithController;
			}
		}

		public event Action onControllerLoaded;

		protected void Awake()
		{
			renderModelLoadedAction = SteamVR_Events.RenderModelLoadedAction(OnRenderModelLoaded);
			InitializeHand();
			InitializeController();
		}

		protected void InitializeHand()
		{
			if (handPrefab != null)
			{
				handInstance = UnityEngine.Object.Instantiate(handPrefab);
				handInstance.transform.parent = base.transform;
				handInstance.transform.localPosition = Vector3.zero;
				handInstance.transform.localRotation = Quaternion.identity;
				handInstance.transform.localScale = handPrefab.transform.localScale;
				handSkeleton = handInstance.GetComponent<SteamVR_Behaviour_Skeleton>();
				handSkeleton.origin = Player.instance.trackingOriginTransform;
				handSkeleton.updatePose = false;
				handSkeleton.skeletonAction.onActiveChange += OnSkeletonActiveChange;
				handRenderers = handInstance.GetComponentsInChildren<Renderer>();
				if (!displayHandByDefault)
				{
					SetHandVisibility(state: false);
				}
				handAnimator = handInstance.GetComponentInChildren<Animator>();
				if (!handSkeleton.skeletonAction.activeBinding && handSkeleton.fallbackPoser == null)
				{
					UnityEngine.Debug.LogWarning("Skeleton action: " + handSkeleton.skeletonAction.GetPath() + " is not bound. Your controller may not support SteamVR Skeleton Input. Please add a fallback skeleton poser to your skeleton if you want hands to be visible");
					DestroyHand();
				}
			}
		}

		protected void InitializeController()
		{
			if (controllerPrefab != null)
			{
				controllerInstance = UnityEngine.Object.Instantiate(controllerPrefab);
				controllerInstance.transform.parent = base.transform;
				controllerInstance.transform.localPosition = Vector3.zero;
				controllerInstance.transform.localRotation = Quaternion.identity;
				controllerInstance.transform.localScale = controllerPrefab.transform.localScale;
				controllerRenderModel = controllerInstance.GetComponent<SteamVR_RenderModel>();
			}
		}

		protected virtual void DestroyHand()
		{
			if (handSkeleton != null)
			{
				handSkeleton.skeletonAction.onActiveChange -= OnSkeletonActiveChange;
			}
			if (handInstance != null)
			{
				UnityEngine.Object.Destroy(handInstance);
				handRenderers = null;
				handInstance = null;
				handSkeleton = null;
				handAnimator = null;
			}
		}

		protected virtual void OnSkeletonActiveChange(SteamVR_Action_Skeleton changedAction, bool newState)
		{
			if (newState)
			{
				InitializeHand();
			}
			else
			{
				DestroyHand();
			}
		}

		protected void OnEnable()
		{
			renderModelLoadedAction.enabled = true;
		}

		protected void OnDisable()
		{
			renderModelLoadedAction.enabled = false;
		}

		protected void OnDestroy()
		{
			DestroyHand();
		}

		public SteamVR_Behaviour_Skeleton GetSkeleton()
		{
			return handSkeleton;
		}

		public virtual void SetInputSource(SteamVR_Input_Sources newInputSource)
		{
			inputSource = newInputSource;
			if (controllerRenderModel != null)
			{
				controllerRenderModel.SetInputSource(inputSource);
			}
		}

		public virtual void OnHandInitialized(int deviceIndex)
		{
			controllerRenderModel.SetInputSource(inputSource);
			controllerRenderModel.SetDeviceIndex(deviceIndex);
		}

		public void MatchHandToTransform(Transform match)
		{
			if (handInstance != null)
			{
				handInstance.transform.position = match.transform.position;
				handInstance.transform.rotation = match.transform.rotation;
			}
		}

		public void SetHandPosition(Vector3 newPosition)
		{
			if (handInstance != null)
			{
				handInstance.transform.position = newPosition;
			}
		}

		public void SetHandRotation(Quaternion newRotation)
		{
			if (handInstance != null)
			{
				handInstance.transform.rotation = newRotation;
			}
		}

		public Vector3 GetHandPosition()
		{
			if (handInstance != null)
			{
				return handInstance.transform.position;
			}
			return Vector3.zero;
		}

		public Quaternion GetHandRotation()
		{
			if (handInstance != null)
			{
				return handInstance.transform.rotation;
			}
			return Quaternion.identity;
		}

		private void OnRenderModelLoaded(SteamVR_RenderModel loadedRenderModel, bool success)
		{
			if (controllerRenderModel == loadedRenderModel)
			{
				controllerRenderers = controllerInstance.GetComponentsInChildren<Renderer>();
				if (!displayControllerByDefault)
				{
					SetControllerVisibility(state: false);
				}
				if (delayedSetMaterial != null)
				{
					SetControllerMaterial(delayedSetMaterial);
				}
				if (this.onControllerLoaded != null)
				{
					this.onControllerLoaded();
				}
			}
		}

		public void SetVisibility(bool state, bool overrideDefault = false)
		{
			if (!state || displayControllerByDefault || overrideDefault)
			{
				SetControllerVisibility(state);
			}
			if (!state || displayHandByDefault || overrideDefault)
			{
				SetHandVisibility(state);
			}
		}

		public void Show(bool overrideDefault = false)
		{
			SetVisibility(state: true, overrideDefault);
		}

		public void Hide()
		{
			SetVisibility(state: false);
		}

		public virtual void SetMaterial(Material material)
		{
			SetControllerMaterial(material);
			SetHandMaterial(material);
		}

		public void SetControllerMaterial(Material material)
		{
			if (controllerRenderers == null)
			{
				delayedSetMaterial = material;
				return;
			}
			for (int i = 0; i < controllerRenderers.Length; i++)
			{
				controllerRenderers[i].material = material;
			}
		}

		public void SetHandMaterial(Material material)
		{
			for (int i = 0; i < handRenderers.Length; i++)
			{
				handRenderers[i].material = material;
			}
		}

		public void SetControllerVisibility(bool state, bool permanent = false)
		{
			if (permanent)
			{
				displayControllerByDefault = state;
			}
			if (controllerRenderers != null)
			{
				for (int i = 0; i < controllerRenderers.Length; i++)
				{
					controllerRenderers[i].enabled = state;
				}
			}
		}

		public void SetHandVisibility(bool state, bool permanent = false)
		{
			if (permanent)
			{
				displayHandByDefault = state;
			}
			if (handRenderers != null)
			{
				for (int i = 0; i < handRenderers.Length; i++)
				{
					handRenderers[i].enabled = state;
				}
			}
		}

		public bool IsHandVisibile()
		{
			if (handRenderers == null)
			{
				return false;
			}
			for (int i = 0; i < handRenderers.Length; i++)
			{
				if (handRenderers[i].enabled)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsControllerVisibile()
		{
			if (controllerRenderers == null)
			{
				return false;
			}
			for (int i = 0; i < controllerRenderers.Length; i++)
			{
				if (controllerRenderers[i].enabled)
				{
					return true;
				}
			}
			return false;
		}

		public Transform GetBone(int boneIndex)
		{
			if (handSkeleton != null)
			{
				return handSkeleton.GetBone(boneIndex);
			}
			return null;
		}

		public Vector3 GetBonePosition(int boneIndex, bool local = false)
		{
			if (handSkeleton != null)
			{
				return handSkeleton.GetBonePosition(boneIndex, local);
			}
			return Vector3.zero;
		}

		public Vector3 GetControllerPosition(string componentName = null)
		{
			if (controllerRenderModel != null)
			{
				return controllerRenderModel.GetComponentTransform(componentName).position;
			}
			return Vector3.zero;
		}

		public Quaternion GetBoneRotation(int boneIndex, bool local = false)
		{
			if (handSkeleton != null)
			{
				return handSkeleton.GetBoneRotation(boneIndex, local);
			}
			return Quaternion.identity;
		}

		public void SetSkeletonRangeOfMotion(EVRSkeletalMotionRange newRangeOfMotion, float blendOverSeconds = 0.1f)
		{
			if (handSkeleton != null)
			{
				handSkeleton.SetRangeOfMotion(newRangeOfMotion, blendOverSeconds);
			}
		}

		public void SetTemporarySkeletonRangeOfMotion(SkeletalMotionRangeChange temporaryRangeOfMotionChange, float blendOverSeconds = 0.1f)
		{
			if (handSkeleton != null)
			{
				handSkeleton.SetTemporaryRangeOfMotion((EVRSkeletalMotionRange)temporaryRangeOfMotionChange, blendOverSeconds);
			}
		}

		public void ResetTemporarySkeletonRangeOfMotion(float blendOverSeconds = 0.1f)
		{
			if (handSkeleton != null)
			{
				handSkeleton.ResetTemporaryRangeOfMotion(blendOverSeconds);
			}
		}

		public void SetAnimationState(int stateValue)
		{
			if (handSkeleton != null)
			{
				if (!handSkeleton.isBlending)
				{
					handSkeleton.BlendToAnimation();
				}
				if (CheckAnimatorInit())
				{
					handAnimator.SetInteger(handAnimatorStateId, stateValue);
				}
			}
		}

		public void StopAnimation()
		{
			if (handSkeleton != null)
			{
				if (!handSkeleton.isBlending)
				{
					handSkeleton.BlendToSkeleton();
				}
				if (CheckAnimatorInit())
				{
					handAnimator.SetInteger(handAnimatorStateId, 0);
				}
			}
		}

		private bool CheckAnimatorInit()
		{
			if (handAnimatorStateId == -1 && handAnimator != null && handAnimator.gameObject.activeInHierarchy && handAnimator.isInitialized)
			{
				AnimatorControllerParameter[] parameters = handAnimator.parameters;
				for (int i = 0; i < parameters.Length; i++)
				{
					if (string.Equals(parameters[i].name, animatorParameterStateName, StringComparison.CurrentCultureIgnoreCase))
					{
						handAnimatorStateId = parameters[i].nameHash;
					}
				}
			}
			if (handAnimatorStateId != -1 && handAnimator != null)
			{
				return handAnimator.isInitialized;
			}
			return false;
		}
	}
	public class SeeThru : MonoBehaviour
	{
		public Material seeThruMaterial;

		private GameObject seeThru;

		private Interactable interactable;

		private Renderer sourceRenderer;

		private Renderer destRenderer;

		private void Awake()
		{
			interactable = GetComponentInParent<Interactable>();
			seeThru = new GameObject("_see_thru");
			seeThru.transform.parent = base.transform;
			seeThru.transform.localPosition = Vector3.zero;
			seeThru.transform.localRotation = Quaternion.identity;
			seeThru.transform.localScale = Vector3.one;
			MeshFilter component = GetComponent<MeshFilter>();
			if (component != null)
			{
				seeThru.AddComponent<MeshFilter>().sharedMesh = component.sharedMesh;
			}
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				sourceRenderer = component2;
				destRenderer = seeThru.AddComponent<MeshRenderer>();
			}
			SkinnedMeshRenderer component3 = GetComponent<SkinnedMeshRenderer>();
			if (component3 != null)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = seeThru.AddComponent<SkinnedMeshRenderer>();
				sourceRenderer = component3;
				destRenderer = skinnedMeshRenderer;
				skinnedMeshRenderer.sharedMesh = component3.sharedMesh;
				skinnedMeshRenderer.rootBone = component3.rootBone;
				skinnedMeshRenderer.bones = component3.bones;
				skinnedMeshRenderer.quality = component3.quality;
				skinnedMeshRenderer.updateWhenOffscreen = component3.updateWhenOffscreen;
			}
			if (sourceRenderer != null && destRenderer != null)
			{
				int num = sourceRenderer.sharedMaterials.Length;
				Material[] array = new Material[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = seeThruMaterial;
				}
				destRenderer.sharedMaterials = array;
				for (int j = 0; j < destRenderer.materials.Length; j++)
				{
					destRenderer.materials[j].renderQueue = 2001;
				}
				for (int k = 0; k < sourceRenderer.materials.Length; k++)
				{
					if (sourceRenderer.materials[k].renderQueue == 2000)
					{
						sourceRenderer.materials[k].renderQueue = 2002;
					}
				}
			}
			seeThru.gameObject.SetActive(value: false);
		}

		private void OnEnable()
		{
			interactable.onAttachedToHand += AttachedToHand;
			interactable.onDetachedFromHand += DetachedFromHand;
		}

		private void OnDisable()
		{
			interactable.onAttachedToHand -= AttachedToHand;
			interactable.onDetachedFromHand -= DetachedFromHand;
		}

		private void AttachedToHand(Hand hand)
		{
			seeThru.SetActive(value: true);
		}

		private void DetachedFromHand(Hand hand)
		{
			seeThru.SetActive(value: false);
		}

		private void Update()
		{
			if (seeThru.activeInHierarchy)
			{
				int num = Mathf.Min(sourceRenderer.materials.Length, destRenderer.materials.Length);
				for (int i = 0; i < num; i++)
				{
					destRenderer.materials[i].mainTexture = sourceRenderer.materials[i].mainTexture;
					destRenderer.materials[i].color = destRenderer.materials[i].color * sourceRenderer.materials[i].color;
				}
			}
		}
	}
	public class SleepOnAwake : MonoBehaviour
	{
		private void Awake()
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.Sleep();
			}
		}
	}
	public class SoundDeparent : MonoBehaviour
	{
		public bool destroyAfterPlayOnce = true;

		private AudioSource thisAudioSource;

		private void Awake()
		{
			thisAudioSource = GetComponent<AudioSource>();
		}

		private void Start()
		{
			base.gameObject.transform.parent = null;
			if (destroyAfterPlayOnce)
			{
				UnityEngine.Object.Destroy(base.gameObject, thisAudioSource.clip.length);
			}
		}
	}
	public class SoundPlayOneshot : MonoBehaviour
	{
		public AudioClip[] waveFiles;

		private AudioSource thisAudioSource;

		public float volMin;

		public float volMax;

		public float pitchMin;

		public float pitchMax;

		public bool playOnAwake;

		private void Awake()
		{
			thisAudioSource = GetComponent<AudioSource>();
			if (playOnAwake)
			{
				Play();
			}
		}

		public void Play()
		{
			if (thisAudioSource != null && thisAudioSource.isActiveAndEnabled && !Util.IsNullOrEmpty(waveFiles))
			{
				thisAudioSource.volume = UnityEngine.Random.Range(volMin, volMax);
				thisAudioSource.pitch = UnityEngine.Random.Range(pitchMin, pitchMax);
				thisAudioSource.PlayOneShot(waveFiles[UnityEngine.Random.Range(0, waveFiles.Length)]);
			}
		}

		public void Pause()
		{
			if (thisAudioSource != null)
			{
				thisAudioSource.Pause();
			}
		}

		public void UnPause()
		{
			if (thisAudioSource != null)
			{
				thisAudioSource.UnPause();
			}
		}
	}
	public class SpawnAndAttachAfterControllerIsTracking : MonoBehaviour
	{
		private Hand hand;

		public GameObject itemPrefab;

		private void Start()
		{
			hand = GetComponentInParent<Hand>();
		}

		private void Update()
		{
			if (itemPrefab != null && hand.isActive && hand.isPoseValid)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(itemPrefab);
				gameObject.SetActive(value: true);
				hand.AttachObject(gameObject, GrabTypes.Scripted);
				hand.TriggerHapticPulse(800);
				UnityEngine.Object.Destroy(base.gameObject);
				gameObject.transform.localScale = itemPrefab.transform.localScale;
			}
		}
	}
	public class SpawnAndAttachToHand : MonoBehaviour
	{
		public Hand hand;

		public GameObject prefab;

		public void SpawnAndAttach(Hand passedInhand)
		{
			Hand hand = passedInhand;
			if (passedInhand == null)
			{
				hand = this.hand;
			}
			if (!(hand == null))
			{
				GameObject objectToAttach = UnityEngine.Object.Instantiate(prefab);
				hand.AttachObject(objectToAttach, GrabTypes.Scripted);
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	[RequireComponent(typeof(Rigidbody))]
	public class Throwable : MonoBehaviour
	{
		[EnumFlags]
		[Tooltip("The flags used to attach this object to the hand.")]
		public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.TurnOnKinematic;

		[Tooltip("The local point which acts as a positional and rotational offset to use while held")]
		public Transform attachmentOffset;

		[Tooltip("How fast must this object be moving to attach due to a trigger hold instead of a trigger press? (-1 to disable)")]
		public float catchingSpeedThreshold = -1f;

		public ReleaseStyle releaseVelocityStyle = ReleaseStyle.GetFromHand;

		[Tooltip("The time offset used when releasing the object with the RawFromHand option")]
		public float releaseVelocityTimeOffset = -0.011f;

		public float scaleReleaseVelocity = 1.1f;

		[Tooltip("The release velocity magnitude representing the end of the scale release velocity curve. (-1 to disable)")]
		public float scaleReleaseVelocityThreshold = -1f;

		[Tooltip("Use this curve to ease into the scaled release velocity based on the magnitude of the measured release velocity. This allows greater differentiation between a drop, toss, and throw.")]
		public AnimationCurve scaleReleaseVelocityCurve = AnimationCurve.EaseInOut(0f, 0.1f, 1f, 1f);

		[Tooltip("When detaching the object, should it return to its original parent?")]
		public bool restoreOriginalParent;

		protected VelocityEstimator velocityEstimator;

		protected bool attached;

		protected float attachTime;

		protected Vector3 attachPosition;

		protected Quaternion attachRotation;

		protected Transform attachEaseInTransform;

		public UnityEvent onPickUp;

		public UnityEvent onDetachFromHand;

		public HandEvent onHeldUpdate;

		protected RigidbodyInterpolation hadInterpolation;

		protected Rigidbody rigidbody;

		[HideInInspector]
		public Interactable interactable;

		protected virtual void Awake()
		{
			velocityEstimator = GetComponent<VelocityEstimator>();
			interactable = GetComponent<Interactable>();
			rigidbody = GetComponent<Rigidbody>();
			rigidbody.maxAngularVelocity = 50f;
			_ = attachmentOffset != null;
		}

		protected virtual void OnHandHoverBegin(Hand hand)
		{
			bool flag = false;
			if (!attached && catchingSpeedThreshold != -1f)
			{
				float num = catchingSpeedThreshold * SteamVR_Utils.GetLossyScale(Player.instance.trackingOriginTransform);
				GrabTypes bestGrabbingType = hand.GetBestGrabbingType();
				if (bestGrabbingType != GrabTypes.None && rigidbody.linearVelocity.magnitude >= num)
				{
					hand.AttachObject(base.gameObject, bestGrabbingType, attachmentFlags);
					flag = false;
				}
			}
			if (flag)
			{
				hand.ShowGrabHint();
			}
		}

		protected virtual void OnHandHoverEnd(Hand hand)
		{
			hand.HideGrabHint();
		}

		protected virtual void HandHoverUpdate(Hand hand)
		{
			GrabTypes grabStarting = hand.GetGrabStarting();
			if (grabStarting != GrabTypes.None)
			{
				hand.AttachObject(base.gameObject, grabStarting, attachmentFlags, attachmentOffset);
				hand.HideGrabHint();
			}
		}

		protected virtual void OnAttachedToHand(Hand hand)
		{
			hadInterpolation = rigidbody.interpolation;
			attached = true;
			onPickUp.Invoke();
			hand.HoverLock(null);
			rigidbody.interpolation = RigidbodyInterpolation.None;
			if (velocityEstimator != null)
			{
				velocityEstimator.BeginEstimatingVelocity();
			}
			attachTime = Time.time;
			attachPosition = base.transform.position;
			attachRotation = base.transform.rotation;
		}

		protected virtual void OnDetachedFromHand(Hand hand)
		{
			attached = false;
			onDetachFromHand.Invoke();
			hand.HoverUnlock(null);
			rigidbody.interpolation = hadInterpolation;
			GetReleaseVelocities(hand, out var velocity, out var angularVelocity);
			rigidbody.linearVelocity = velocity;
			rigidbody.angularVelocity = angularVelocity;
		}

		public virtual void GetReleaseVelocities(Hand hand, out Vector3 velocity, out Vector3 angularVelocity)
		{
			if ((bool)hand.noSteamVRFallbackCamera && releaseVelocityStyle != ReleaseStyle.NoChange)
			{
				releaseVelocityStyle = ReleaseStyle.ShortEstimation;
			}
			switch (releaseVelocityStyle)
			{
			case ReleaseStyle.ShortEstimation:
				if (velocityEstimator != null)
				{
					velocityEstimator.FinishEstimatingVelocity();
					velocity = velocityEstimator.GetVelocityEstimate();
					angularVelocity = velocityEstimator.GetAngularVelocityEstimate();
				}
				else
				{
					UnityEngine.Debug.LogWarning("[SteamVR Interaction System] Throwable: No Velocity Estimator component on object but release style set to short estimation. Please add one or change the release style.");
					velocity = rigidbody.linearVelocity;
					angularVelocity = rigidbody.angularVelocity;
				}
				break;
			case ReleaseStyle.AdvancedEstimation:
				hand.GetEstimatedPeakVelocities(out velocity, out angularVelocity);
				break;
			case ReleaseStyle.GetFromHand:
				velocity = hand.GetTrackedObjectVelocity(releaseVelocityTimeOffset);
				angularVelocity = hand.GetTrackedObjectAngularVelocity(releaseVelocityTimeOffset);
				break;
			default:
				velocity = rigidbody.linearVelocity;
				angularVelocity = rigidbody.angularVelocity;
				break;
			}
			if (releaseVelocityStyle != ReleaseStyle.NoChange)
			{
				float num = 1f;
				if (scaleReleaseVelocityThreshold > 0f)
				{
					num = Mathf.Clamp01(scaleReleaseVelocityCurve.Evaluate(velocity.magnitude / scaleReleaseVelocityThreshold));
				}
				velocity *= num * scaleReleaseVelocity;
			}
		}

		protected virtual void HandAttachedUpdate(Hand hand)
		{
			if (hand.IsGrabEnding(base.gameObject))
			{
				hand.DetachObject(base.gameObject, restoreOriginalParent);
			}
			if (onHeldUpdate != null)
			{
				onHeldUpdate.Invoke(hand);
			}
		}

		protected virtual IEnumerator LateDetach(Hand hand)
		{
			yield return new WaitForEndOfFrame();
			hand.DetachObject(base.gameObject, restoreOriginalParent);
		}

		protected virtual void OnHandFocusAcquired(Hand hand)
		{
			base.gameObject.SetActive(value: true);
			if (velocityEstimator != null)
			{
				velocityEstimator.BeginEstimatingVelocity();
			}
		}

		protected virtual void OnHandFocusLost(Hand hand)
		{
			base.gameObject.SetActive(value: false);
			if (velocityEstimator != null)
			{
				velocityEstimator.FinishEstimatingVelocity();
			}
		}
	}
	public enum ReleaseStyle
	{
		NoChange,
		GetFromHand,
		ShortEstimation,
		AdvancedEstimation
	}
	[RequireComponent(typeof(Interactable))]
	public class UIElement : MonoBehaviour
	{
		public CustomEvents.UnityEventHand onHandClick;

		protected Hand currentHand;

		protected virtual void Awake()
		{
			Button component = GetComponent<Button>();
			if ((bool)component)
			{
				component.onClick.AddListener(OnButtonClick);
			}
		}

		protected virtual void OnHandHoverBegin(Hand hand)
		{
			currentHand = hand;
			InputModule.instance.HoverBegin(base.gameObject);
			ControllerButtonHints.ShowButtonHint(hand, hand.uiInteractAction);
		}

		protected virtual void OnHandHoverEnd(Hand hand)
		{
			InputModule.instance.HoverEnd(base.gameObject);
			ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
			currentHand = null;
		}

		protected virtual void HandHoverUpdate(Hand hand)
		{
			if (hand.uiInteractAction != null && hand.uiInteractAction.GetStateDown(hand.handType))
			{
				InputModule.instance.Submit(base.gameObject);
				ControllerButtonHints.HideButtonHint(hand, hand.uiInteractAction);
			}
		}

		protected virtual void OnButtonClick()
		{
			onHandClick.Invoke(currentHand);
		}
	}
	public class Unparent : MonoBehaviour
	{
		private Transform oldParent;

		private void Start()
		{
			oldParent = base.transform.parent;
			base.transform.parent = null;
			base.gameObject.name = oldParent.gameObject.name + "." + base.gameObject.name;
		}

		private void Update()
		{
			if (oldParent == null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		public Transform GetOldParent()
		{
			return oldParent;
		}
	}
	public static class Util
	{
		public const float FeetToMeters = 0.3048f;

		public const float FeetToCentimeters = 30.48f;

		public const float InchesToMeters = 0.0254f;

		public const float InchesToCentimeters = 2.54f;

		public const float MetersToFeet = 3.28084f;

		public const float MetersToInches = 39.3701f;

		public const float CentimetersToFeet = 0.0328084f;

		public const float CentimetersToInches = 0.393701f;

		public const float KilometersToMiles = 0.621371f;

		public const float MilesToKilometers = 1.60934f;

		public static float RemapNumber(float num, float low1, float high1, float low2, float high2)
		{
			return low2 + (num - low1) * (high2 - low2) / (high1 - low1);
		}

		public static float RemapNumberClamped(float num, float low1, float high1, float low2, float high2)
		{
			return Mathf.Clamp(RemapNumber(num, low1, high1, low2, high2), Mathf.Min(low2, high2), Mathf.Max(low2, high2));
		}

		public static float Approach(float target, float value, float speed)
		{
			float num = target - value;
			value = ((num > speed) ? (value + speed) : ((!(num < 0f - speed)) ? target : (value - speed)));
			return value;
		}

		public static Vector3 BezierInterpolate3(Vector3 p0, Vector3 c0, Vector3 p1, float t)
		{
			Vector3 a = Vector3.Lerp(p0, c0, t);
			Vector3 b = Vector3.Lerp(c0, p1, t);
			return Vector3.Lerp(a, b, t);
		}

		public static Vector3 BezierInterpolate4(Vector3 p0, Vector3 c0, Vector3 c1, Vector3 p1, float t)
		{
			Vector3 a = Vector3.Lerp(p0, c0, t);
			Vector3 vector = Vector3.Lerp(c0, c1, t);
			Vector3 b = Vector3.Lerp(c1, p1, t);
			Vector3 a2 = Vector3.Lerp(a, vector, t);
			Vector3 b2 = Vector3.Lerp(vector, b, t);
			return Vector3.Lerp(a2, b2, t);
		}

		public static Vector3 Vector3FromString(string szString)
		{
			string[] array = szString.Substring(1, szString.Length - 1).Split(',');
			float x = float.Parse(array[0]);
			float y = float.Parse(array[1]);
			float z = float.Parse(array[2]);
			return new Vector3(x, y, z);
		}

		public static Vector2 Vector2FromString(string szString)
		{
			string[] array = szString.Substring(1, szString.Length - 1).Split(',');
			float x = float.Parse(array[0]);
			float y = float.Parse(array[1]);
			return (Vector3)new Vector2(x, y);
		}

		public static float Normalize(float value, float min, float max)
		{
			return (value - min) / (max - min);
		}

		public static Vector3 Vector2AsVector3(Vector2 v)
		{
			return new Vector3(v.x, 0f, v.y);
		}

		public static Vector2 Vector3AsVector2(Vector3 v)
		{
			return new Vector2(v.x, v.z);
		}

		public static float AngleOf(Vector2 v)
		{
			float magnitude = v.magnitude;
			if (v.y >= 0f)
			{
				return Mathf.Acos(v.x / magnitude);
			}
			return Mathf.Acos((0f - v.x) / magnitude) + MathF.PI;
		}

		public static float YawOf(Vector3 v)
		{
			float magnitude = v.magnitude;
			if (v.z >= 0f)
			{
				return Mathf.Acos(v.x / magnitude);
			}
			return Mathf.Acos((0f - v.x) / magnitude) + MathF.PI;
		}

		public static void Swap<T>(ref T lhs, ref T rhs)
		{
			T val = lhs;
			lhs = rhs;
			rhs = val;
		}

		public static void Shuffle<T>(T[] array)
		{
			for (int num = array.Length - 1; num > 0; num--)
			{
				int num2 = UnityEngine.Random.Range(0, num);
				Swap(ref array[num], ref array[num2]);
			}
		}

		public static void Shuffle<T>(List<T> list)
		{
			for (int num = list.Count - 1; num > 0; num--)
			{
				int index = UnityEngine.Random.Range(0, num);
				T value = list[num];
				list[num] = list[index];
				list[index] = value;
			}
		}

		public static int RandomWithLookback(int min, int max, List<int> history, int historyCount)
		{
			int num = UnityEngine.Random.Range(min, max - history.Count);
			for (int i = 0; i < history.Count; i++)
			{
				if (num >= history[i])
				{
					num++;
				}
			}
			history.Add(num);
			if (history.Count > historyCount)
			{
				history.RemoveRange(0, history.Count - historyCount);
			}
			return num;
		}

		public static Transform FindChild(Transform parent, string name)
		{
			if (parent.name == name)
			{
				return parent;
			}
			foreach (Transform item in parent)
			{
				Transform transform = FindChild(item, name);
				if (transform != null)
				{
					return transform;
				}
			}
			return null;
		}

		public static bool IsNullOrEmpty<T>(T[] array)
		{
			if (array == null)
			{
				return true;
			}
			if (array.Length == 0)
			{
				return true;
			}
			return false;
		}

		public static bool IsValidIndex<T>(T[] array, int i)
		{
			if (array == null)
			{
				return false;
			}
			if (i >= 0)
			{
				return i < array.Length;
			}
			return false;
		}

		public static bool IsValidIndex<T>(List<T> list, int i)
		{
			if (list == null || list.Count == 0)
			{
				return false;
			}
			if (i >= 0)
			{
				return i < list.Count;
			}
			return false;
		}

		public static int FindOrAdd<T>(List<T> list, T item)
		{
			int num = list.IndexOf(item);
			if (num == -1)
			{
				list.Add(item);
				num = list.Count - 1;
			}
			return num;
		}

		public static List<T> FindAndRemove<T>(List<T> list, Predicate<T> match)
		{
			List<T> result = list.FindAll(match);
			list.RemoveAll(match);
			return result;
		}

		public static T FindOrAddComponent<T>(GameObject gameObject) where T : UnityEngine.Component
		{
			T component = gameObject.GetComponent<T>();
			if ((bool)component)
			{
				return component;
			}
			return gameObject.AddComponent<T>();
		}

		public static void FastRemove<T>(List<T> list, int index)
		{
			list[index] = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}

		public static void ReplaceGameObject<T, U>(T replace, U replaceWith) where T : MonoBehaviour where U : MonoBehaviour
		{
			replace.gameObject.SetActive(value: false);
			replaceWith.gameObject.SetActive(value: true);
		}

		public static void SwitchLayerRecursively(Transform transform, int fromLayer, int toLayer)
		{
			if (transform.gameObject.layer == fromLayer)
			{
				transform.gameObject.layer = toLayer;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				SwitchLayerRecursively(transform.GetChild(i), fromLayer, toLayer);
			}
		}

		public static void DrawCross(Vector3 origin, Color crossColor, float size)
		{
			Vector3 start = origin + Vector3.right * size;
			Vector3 end = origin - Vector3.right * size;
			UnityEngine.Debug.DrawLine(start, end, crossColor);
			Vector3 start2 = origin + Vector3.up * size;
			Vector3 end2 = origin - Vector3.up * size;
			UnityEngine.Debug.DrawLine(start2, end2, crossColor);
			Vector3 start3 = origin + Vector3.forward * size;
			Vector3 end3 = origin - Vector3.forward * size;
			UnityEngine.Debug.DrawLine(start3, end3, crossColor);
		}

		public static void ResetTransform(Transform t, bool resetScale = true)
		{
			t.localPosition = Vector3.zero;
			t.localRotation = Quaternion.identity;
			if (resetScale)
			{
				t.localScale = new Vector3(1f, 1f, 1f);
			}
		}

		public static Vector3 ClosestPointOnLine(Vector3 vA, Vector3 vB, Vector3 vPoint)
		{
			Vector3 rhs = vPoint - vA;
			Vector3 normalized = (vB - vA).normalized;
			float num = Vector3.Distance(vA, vB);
			float num2 = Vector3.Dot(normalized, rhs);
			if (num2 <= 0f)
			{
				return vA;
			}
			if (num2 >= num)
			{
				return vB;
			}
			Vector3 vector = normalized * num2;
			return vA + vector;
		}

		public static void AfterTimer(GameObject go, float _time, Action callback, bool trigger_if_destroyed_early = false)
		{
			go.AddComponent<AfterTimer_Component>().Init(_time, callback, trigger_if_destroyed_early);
		}

		public static void SendPhysicsMessage(Collider collider, string message, SendMessageOptions sendMessageOptions)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if ((bool)attachedRigidbody && attachedRigidbody.gameObject != collider.gameObject)
			{
				attachedRigidbody.SendMessage(message, sendMessageOptions);
			}
			collider.SendMessage(message, sendMessageOptions);
		}

		public static void SendPhysicsMessage(Collider collider, string message, object arg, SendMessageOptions sendMessageOptions)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if ((bool)attachedRigidbody && attachedRigidbody.gameObject != collider.gameObject)
			{
				attachedRigidbody.SendMessage(message, arg, sendMessageOptions);
			}
			collider.SendMessage(message, arg, sendMessageOptions);
		}

		public static void IgnoreCollisions(GameObject goA, GameObject goB)
		{
			Collider[] componentsInChildren = goA.GetComponentsInChildren<Collider>();
			Collider[] componentsInChildren2 = goB.GetComponentsInChildren<Collider>();
			if (componentsInChildren.Length == 0 || componentsInChildren2.Length == 0)
			{
				return;
			}
			Collider[] array = componentsInChildren;
			foreach (Collider collider in array)
			{
				Collider[] array2 = componentsInChildren2;
				foreach (Collider collider2 in array2)
				{
					if (collider.enabled && collider2.enabled)
					{
						Physics.IgnoreCollision(collider, collider2, ignore: true);
					}
				}
			}
		}

		public static IEnumerator WrapCoroutine(IEnumerator coroutine, Action onCoroutineFinished)
		{
			while (coroutine.MoveNext())
			{
				yield return coroutine.Current;
			}
			onCoroutineFinished();
		}

		public static Color ColorWithAlpha(this Color color, float alpha)
		{
			color.a = alpha;
			return color;
		}

		public static void Quit()
		{
			Process.GetCurrentProcess().Kill();
		}

		public static decimal FloatToDecimal(float value, int decimalPlaces = 2)
		{
			return Math.Round((decimal)value, decimalPlaces);
		}

		public static T Median<T>(this IEnumerable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentException("Argument cannot be null.", "source");
			}
			int num = source.Count();
			if (num == 0)
			{
				throw new InvalidOperationException("Enumerable must contain at least one element.");
			}
			return source.OrderBy((T x) => x).ElementAt(num / 2);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			if (source == null)
			{
				throw new ArgumentException("Argument cannot be null.", "source");
			}
			foreach (T item in source)
			{
				action(item);
			}
		}

		public static string FixupNewlines(string text)
		{
			bool flag = true;
			while (flag)
			{
				int num = text.IndexOf("\\n");
				if (num == -1)
				{
					flag = false;
					continue;
				}
				text = text.Remove(num - 1, 3);
				text = text.Insert(num - 1, "\n");
			}
			return text;
		}

		public static float PathLength(NavMeshPath path)
		{
			if (path.corners.Length < 2)
			{
				return 0f;
			}
			Vector3 a = path.corners[0];
			float num = 0f;
			for (int i = 1; i < path.corners.Length; i++)
			{
				Vector3 vector = path.corners[i];
				num += Vector3.Distance(a, vector);
				a = vector;
			}
			return num;
		}

		public static bool HasCommandLineArgument(string argumentName)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i].Equals(argumentName))
				{
					return true;
				}
			}
			return false;
		}

		public static int GetCommandLineArgValue(string argumentName, int nDefaultValue)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i].Equals(argumentName))
				{
					if (i == commandLineArgs.Length - 1)
					{
						return nDefaultValue;
					}
					return int.Parse(commandLineArgs[i + 1]);
				}
			}
			return nDefaultValue;
		}

		public static float GetCommandLineArgValue(string argumentName, float flDefaultValue)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i].Equals(argumentName))
				{
					if (i == commandLineArgs.Length - 1)
					{
						return flDefaultValue;
					}
					return (float)double.Parse(commandLineArgs[i + 1]);
				}
			}
			return flDefaultValue;
		}

		public static void SetActive(GameObject gameObject, bool active)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(active);
			}
		}

		public static string CombinePaths(params string[] paths)
		{
			if (paths.Length == 0)
			{
				return "";
			}
			string text = paths[0];
			for (int i = 1; i < paths.Length; i++)
			{
				text = Path.Combine(text, paths[i]);
			}
			return text;
		}
	}
	[Serializable]
	public class AfterTimer_Component : MonoBehaviour
	{
		private Action callback;

		private float triggerTime;

		private bool timerActive;

		private bool triggerOnEarlyDestroy;

		public void Init(float _time, Action _callback, bool earlydestroy)
		{
			triggerTime = _time;
			callback = _callback;
			triggerOnEarlyDestroy = earlydestroy;
			timerActive = true;
			StartCoroutine(Wait());
		}

		private IEnumerator Wait()
		{
			yield return new WaitForSeconds(triggerTime);
			timerActive = false;
			callback();
			UnityEngine.Object.Destroy(this);
		}

		private void OnDestroy()
		{
			if (timerActive)
			{
				StopCoroutine(Wait());
				timerActive = false;
				if (triggerOnEarlyDestroy)
				{
					callback();
				}
			}
		}
	}
	public class VelocityEstimator : MonoBehaviour
	{
		[Tooltip("How many frames to average over for computing velocity")]
		public int velocityAverageFrames = 5;

		[Tooltip("How many frames to average over for computing angular velocity")]
		public int angularVelocityAverageFrames = 11;

		public bool estimateOnAwake;

		private Coroutine routine;

		private int sampleCount;

		private Vector3[] velocitySamples;

		private Vector3[] angularVelocitySamples;

		public void BeginEstimatingVelocity()
		{
			FinishEstimatingVelocity();
			routine = StartCoroutine(EstimateVelocityCoroutine());
		}

		public void FinishEstimatingVelocity()
		{
			if (routine != null)
			{
				StopCoroutine(routine);
				routine = null;
			}
		}

		public Vector3 GetVelocityEstimate()
		{
			Vector3 zero = Vector3.zero;
			int num = Mathf.Min(sampleCount, velocitySamples.Length);
			if (num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					zero += velocitySamples[i];
				}
				zero *= 1f / (float)num;
			}
			return zero;
		}

		public Vector3 GetAngularVelocityEstimate()
		{
			Vector3 zero = Vector3.zero;
			int num = Mathf.Min(sampleCount, angularVelocitySamples.Length);
			if (num != 0)
			{
				for (int i = 0; i < num; i++)
				{
					zero += angularVelocitySamples[i];
				}
				zero *= 1f / (float)num;
			}
			return zero;
		}

		public Vector3 GetAccelerationEstimate()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 2 + sampleCount - velocitySamples.Length; i < sampleCount; i++)
			{
				if (i >= 2)
				{
					int num = i - 2;
					int num2 = i - 1;
					Vector3 vector = velocitySamples[num % velocitySamples.Length];
					Vector3 vector2 = velocitySamples[num2 % velocitySamples.Length];
					zero += vector2 - vector;
				}
			}
			return zero * (1f / Time.deltaTime);
		}

		private void Awake()
		{
			velocitySamples = new Vector3[velocityAverageFrames];
			angularVelocitySamples = new Vector3[angularVelocityAverageFrames];
			if (estimateOnAwake)
			{
				BeginEstimatingVelocity();
			}
		}

		private IEnumerator EstimateVelocityCoroutine()
		{
			sampleCount = 0;
			Vector3 previousPosition = base.transform.position;
			Quaternion previousRotation = base.transform.rotation;
			while (true)
			{
				yield return new WaitForEndOfFrame();
				float num = 1f / Time.deltaTime;
				int num2 = sampleCount % velocitySamples.Length;
				int num3 = sampleCount % angularVelocitySamples.Length;
				sampleCount++;
				velocitySamples[num2] = num * (base.transform.position - previousPosition);
				Quaternion quaternion = base.transform.rotation * Quaternion.Inverse(previousRotation);
				float num4 = 2f * Mathf.Acos(Mathf.Clamp(quaternion.w, -1f, 1f));
				if (num4 > MathF.PI)
				{
					num4 -= MathF.PI * 2f;
				}
				Vector3 vector = new Vector3(quaternion.x, quaternion.y, quaternion.z);
				if (vector.sqrMagnitude > 0f)
				{
					vector = num4 * num * vector.normalized;
				}
				angularVelocitySamples[num3] = vector;
				previousPosition = base.transform.position;
				previousRotation = base.transform.rotation;
			}
		}
	}
	public class ControllerButtonHints : MonoBehaviour
	{
		private enum OffsetType
		{
			Up,
			Right,
			Forward,
			Back
		}

		private class ActionHintInfo
		{
			public string componentName;

			public List<MeshRenderer> renderers;

			public Transform localTransform;

			public GameObject textHintObject;

			public Transform textStartAnchor;

			public Transform textEndAnchor;

			public Vector3 textEndOffsetDir;

			public Transform canvasOffset;

			public Text text;

			public TextMesh textMesh;

			public Canvas textCanvas;

			public LineRenderer line;

			public float distanceFromCenter;

			public bool textHintActive;
		}

		public Material controllerMaterial;

		public Material urpControllerMaterial;

		public Color flashColor = new Color(1f, 0.557f, 0f);

		public GameObject textHintPrefab;

		public SteamVR_Action_Vibration hapticFlash = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");

		public bool autoSetWithControllerRangeOfMotion = true;

		[Header("Debug")]
		public bool debugHints;

		private SteamVR_RenderModel renderModel;

		private Player player;

		private List<MeshRenderer> renderers = new List<MeshRenderer>();

		private List<MeshRenderer> flashingRenderers = new List<MeshRenderer>();

		private float startTime;

		private float tickCount;

		private Dictionary<ISteamVR_Action_In_Source, ActionHintInfo> actionHintInfos;

		private Transform textHintParent;

		private int colorID;

		private Vector3 centerPosition = Vector3.zero;

		private SteamVR_Events.Action renderModelLoadedAction;

		protected SteamVR_Input_Sources inputSource;

		private Dictionary<string, Transform> componentTransformMap = new Dictionary<string, Transform>();

		public Material usingMaterial => urpControllerMaterial;

		public bool initialized { get; private set; }

		private void Awake()
		{
			renderModelLoadedAction = SteamVR_Events.RenderModelLoadedAction(OnRenderModelLoaded);
			colorID = Shader.PropertyToID("_BaseColor");
		}

		private void Start()
		{
			player = Player.instance;
		}

		private void HintDebugLog(string msg)
		{
			if (debugHints)
			{
				UnityEngine.Debug.Log("<b>[SteamVR Interaction]</b> Hints: " + msg);
			}
		}

		private void OnEnable()
		{
			renderModelLoadedAction.enabled = true;
		}

		private void OnDisable()
		{
			renderModelLoadedAction.enabled = false;
			Clear();
		}

		private void OnParentHandInputFocusLost()
		{
			HideAllButtonHints();
			HideAllText();
		}

		public virtual void SetInputSource(SteamVR_Input_Sources newInputSource)
		{
			inputSource = newInputSource;
			if (renderModel != null)
			{
				renderModel.SetInputSource(newInputSource);
			}
		}

		private void OnHandInitialized(int deviceIndex)
		{
			renderModel = new GameObject("SteamVR_RenderModel").AddComponent<SteamVR_RenderModel>();
			renderModel.transform.parent = base.transform;
			renderModel.transform.localPosition = Vector3.zero;
			renderModel.transform.localRotation = Quaternion.identity;
			renderModel.transform.localScale = Vector3.one;
			renderModel.SetInputSource(inputSource);
			renderModel.SetDeviceIndex(deviceIndex);
			if (!initialized)
			{
				renderModel.gameObject.SetActive(value: true);
			}
		}

		private void OnRenderModelLoaded(SteamVR_RenderModel renderModel, bool succeess)
		{
			if (renderModel == this.renderModel)
			{
				if (initialized)
				{
					UnityEngine.Object.Destroy(textHintParent.gameObject);
					componentTransformMap.Clear();
					flashingRenderers.Clear();
				}
				renderModel.SetMeshRendererState(state: false);
				StartCoroutine(DoInitialize(renderModel));
			}
		}

		private IEnumerator DoInitialize(SteamVR_RenderModel renderModel)
		{
			while (!renderModel.initializedAttachPoints)
			{
				yield return null;
			}
			textHintParent = new GameObject("Text Hints").transform;
			textHintParent.SetParent(base.transform);
			textHintParent.localPosition = Vector3.zero;
			textHintParent.localRotation = Quaternion.identity;
			textHintParent.localScale = Vector3.one;
			if (OpenVR.RenderModels != null)
			{
				string text = "";
				if (debugHints)
				{
					text = "Components for render model " + renderModel.index;
				}
				for (int i = 0; i < renderModel.transform.childCount; i++)
				{
					Transform child = renderModel.transform.GetChild(i);
					if (componentTransformMap.ContainsKey(child.name))
					{
						if (debugHints)
						{
							text = text + "\n\t!    Child component already exists with name: " + child.name;
						}
					}
					else
					{
						componentTransformMap.Add(child.name, child);
					}
					if (debugHints)
					{
						text = text + "\n\t" + child.name + ".";
					}
				}
				HintDebugLog(text);
			}
			actionHintInfos = new Dictionary<ISteamVR_Action_In_Source, ActionHintInfo>();
			for (int j = 0; j < SteamVR_Input.actionsNonPoseNonSkeletonIn.Length; j++)
			{
				ISteamVR_Action_In steamVR_Action_In = SteamVR_Input.actionsNonPoseNonSkeletonIn[j];
				if (steamVR_Action_In.GetActive(inputSource))
				{
					CreateAndAddButtonInfo(steamVR_Action_In, inputSource);
				}
			}
			ComputeTextEndTransforms();
			initialized = true;
			renderModel.SetMeshRendererState(state: true);
			renderModel.gameObject.SetActive(value: false);
		}

		private void CreateAndAddButtonInfo(ISteamVR_Action_In action, SteamVR_Input_Sources inputSource)
		{
			Transform transform = null;
			List<MeshRenderer> list = new List<MeshRenderer>();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Looking for action: ");
			stringBuilder.AppendLine(action.GetShortName());
			stringBuilder.Append("Action localized origin: ");
			stringBuilder.AppendLine(action.GetLocalizedOrigin(inputSource));
			string renderModelComponentName = action.GetRenderModelComponentName(inputSource);
			if (componentTransformMap.ContainsKey(renderModelComponentName))
			{
				stringBuilder.AppendLine($"Found component: {renderModelComponentName} for {action.GetShortName()}");
				Transform transform2 = componentTransformMap[renderModelComponentName];
				transform = transform2;
				stringBuilder.AppendLine($"Found componentTransform: {transform2}. buttonTransform: {transform}");
				list.AddRange(transform2.GetComponentsInChildren<MeshRenderer>());
			}
			else
			{
				stringBuilder.AppendLine($"Can't find component transform for action: {action.GetShortName()}. Component name: \"{renderModelComponentName}\"");
			}
			stringBuilder.AppendLine($"Found {list.Count} renderers for {action.GetShortName()}");
			foreach (MeshRenderer item in list)
			{
				stringBuilder.Append("\t");
				stringBuilder.AppendLine(item.name);
			}
			HintDebugLog(stringBuilder.ToString());
			if (transform == null)
			{
				HintDebugLog("Couldn't find buttonTransform for " + action.GetShortName());
				return;
			}
			ActionHintInfo actionHintInfo = new ActionHintInfo();
			actionHintInfos.Add(action, actionHintInfo);
			actionHintInfo.componentName = transform.name;
			actionHintInfo.renderers = list;
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name == "attach")
				{
					actionHintInfo.localTransform = child;
				}
			}
			switch (OffsetType.Right)
			{
			case OffsetType.Forward:
				actionHintInfo.textEndOffsetDir = actionHintInfo.localTransform.forward;
				break;
			case OffsetType.Back:
				actionHintInfo.textEndOffsetDir = -actionHintInfo.localTransform.forward;
				break;
			case OffsetType.Right:
				actionHintInfo.textEndOffsetDir = actionHintInfo.localTransform.right;
				break;
			case OffsetType.Up:
				actionHintInfo.textEndOffsetDir = actionHintInfo.localTransform.up;
				break;
			}
			Vector3 position = actionHintInfo.localTransform.position + actionHintInfo.localTransform.forward * 0.01f;
			actionHintInfo.textHintObject = UnityEngine.Object.Instantiate(textHintPrefab, position, Quaternion.identity);
			actionHintInfo.textHintObject.name = "Hint_" + actionHintInfo.componentName + "_Start";
			actionHintInfo.textHintObject.transform.SetParent(textHintParent);
			actionHintInfo.textHintObject.layer = base.gameObject.layer;
			actionHintInfo.textHintObject.tag = base.gameObject.tag;
			actionHintInfo.textStartAnchor = actionHintInfo.textHintObject.transform.Find("Start");
			actionHintInfo.textEndAnchor = actionHintInfo.textHintObject.transform.Find("End");
			actionHintInfo.canvasOffset = actionHintInfo.textHintObject.transform.Find("CanvasOffset");
			actionHintInfo.line = actionHintInfo.textHintObject.transform.Find("Line").GetComponent<LineRenderer>();
			actionHintInfo.textCanvas = actionHintInfo.textHintObject.GetComponentInChildren<Canvas>();
			actionHintInfo.text = actionHintInfo.textCanvas.GetComponentInChildren<Text>();
			actionHintInfo.textMesh = actionHintInfo.textCanvas.GetComponentInChildren<TextMesh>();
			actionHintInfo.textHintObject.SetActive(value: false);
			actionHintInfo.textStartAnchor.position = position;
			if (actionHintInfo.text != null)
			{
				actionHintInfo.text.text = actionHintInfo.componentName;
			}
			if (actionHintInfo.textMesh != null)
			{
				actionHintInfo.textMesh.text = actionHintInfo.componentName;
			}
			centerPosition += actionHintInfo.textStartAnchor.position;
			actionHintInfo.textCanvas.transform.localScale = Vector3.Scale(actionHintInfo.textCanvas.transform.localScale, player.transform.localScale);
			actionHintInfo.textStartAnchor.transform.localScale = Vector3.Scale(actionHintInfo.textStartAnchor.transform.localScale, player.transform.localScale);
			actionHintInfo.textEndAnchor.transform.localScale = Vector3.Scale(actionHintInfo.textEndAnchor.transform.localScale, player.transform.localScale);
			actionHintInfo.line.transform.localScale = Vector3.Scale(actionHintInfo.line.transform.localScale, player.transform.localScale);
		}

		private void ComputeTextEndTransforms()
		{
			centerPosition /= (float)actionHintInfos.Count;
			float num = 0f;
			foreach (KeyValuePair<ISteamVR_Action_In_Source, ActionHintInfo> actionHintInfo in actionHintInfos)
			{
				actionHintInfo.Value.distanceFromCenter = Vector3.Distance(actionHintInfo.Value.textStartAnchor.position, centerPosition);
				if (actionHintInfo.Value.distanceFromCenter > num)
				{
					num = actionHintInfo.Value.distanceFromCenter;
				}
			}
			foreach (KeyValuePair<ISteamVR_Action_In_Source, ActionHintInfo> actionHintInfo2 in actionHintInfos)
			{
				Vector3 vector = actionHintInfo2.Value.textStartAnchor.position - centerPosition;
				vector.Normalize();
				vector = Vector3.Project(vector, renderModel.transform.forward);
				float num2 = actionHintInfo2.Value.distanceFromCenter / num;
				float num3 = actionHintInfo2.Value.distanceFromCenter * Mathf.Pow(2f, 10f * (num2 - 1f)) * 20f;
				float num4 = 0.1f;
				Vector3 vector2 = actionHintInfo2.Value.textStartAnchor.position + actionHintInfo2.Value.textEndOffsetDir * num4 + vector * num3 * 0.1f;
				if (SteamVR_Utils.IsValid(vector2))
				{
					actionHintInfo2.Value.textEndAnchor.position = vector2;
					actionHintInfo2.Value.canvasOffset.position = vector2;
				}
				else
				{
					UnityEngine.Debug.LogWarning("<b>[SteamVR Interaction]</b> Invalid end position for: " + actionHintInfo2.Value.textStartAnchor.name, actionHintInfo2.Value.textStartAnchor.gameObject);
				}
				actionHintInfo2.Value.canvasOffset.localRotation = Quaternion.identity;
			}
		}

		private void ShowButtonHint(params ISteamVR_Action_In_Source[] actions)
		{
			renderModel.gameObject.SetActive(value: true);
			renderModel.GetComponentsInChildren(renderers);
			for (int i = 0; i < renderers.Count; i++)
			{
				Texture mainTexture = renderers[i].material.mainTexture;
				renderers[i].sharedMaterial = usingMaterial;
				renderers[i].material.mainTexture = mainTexture;
				renderers[i].material.renderQueue = usingMaterial.renderQueue;
			}
			for (int j = 0; j < actions.Length; j++)
			{
				if (!actionHintInfos.ContainsKey(actions[j]))
				{
					continue;
				}
				foreach (MeshRenderer renderer in actionHintInfos[actions[j]].renderers)
				{
					if (!flashingRenderers.Contains(renderer))
					{
						flashingRenderers.Add(renderer);
					}
				}
			}
			startTime = Time.realtimeSinceStartup;
			tickCount = 0f;
		}

		private void HideAllButtonHints()
		{
			Clear();
			if (renderModel != null && renderModel.gameObject != null)
			{
				renderModel.gameObject.SetActive(value: false);
			}
		}

		private void HideButtonHint(params ISteamVR_Action_In_Source[] actions)
		{
			Color color = usingMaterial.GetColor(colorID);
			for (int i = 0; i < actions.Length; i++)
			{
				if (!actionHintInfos.ContainsKey(actions[i]))
				{
					continue;
				}
				foreach (MeshRenderer renderer in actionHintInfos[actions[i]].renderers)
				{
					renderer.material.color = color;
					flashingRenderers.Remove(renderer);
				}
			}
			if (flashingRenderers.Count == 0)
			{
				renderModel.gameObject.SetActive(value: false);
			}
		}

		private bool IsButtonHintActive(ISteamVR_Action_In_Source action)
		{
			if (actionHintInfos.ContainsKey(action))
			{
				foreach (MeshRenderer renderer in actionHintInfos[action].renderers)
				{
					if (flashingRenderers.Contains(renderer))
					{
						return true;
					}
				}
			}
			return false;
		}

		private IEnumerator TestButtonHints()
		{
			while (true)
			{
				for (int actionIndex = 0; actionIndex < SteamVR_Input.actionsNonPoseNonSkeletonIn.Length; actionIndex++)
				{
					ISteamVR_Action_In steamVR_Action_In = SteamVR_Input.actionsNonPoseNonSkeletonIn[actionIndex];
					if (steamVR_Action_In.GetActive(inputSource))
					{
						ShowButtonHint(steamVR_Action_In);
						yield return new WaitForSeconds(1f);
					}
					yield return null;
				}
			}
		}

		private IEnumerator TestTextHints()
		{
			while (true)
			{
				for (int actionIndex = 0; actionIndex < SteamVR_Input.actionsNonPoseNonSkeletonIn.Length; actionIndex++)
				{
					ISteamVR_Action_In steamVR_Action_In = SteamVR_Input.actionsNonPoseNonSkeletonIn[actionIndex];
					if (steamVR_Action_In.GetActive(inputSource))
					{
						ShowText(steamVR_Action_In, steamVR_Action_In.GetShortName());
						yield return new WaitForSeconds(3f);
					}
					yield return null;
				}
				HideAllText();
				yield return new WaitForSeconds(3f);
			}
		}

		private void Update()
		{
			if (!(renderModel != null) || !renderModel.gameObject.activeInHierarchy || flashingRenderers.Count <= 0)
			{
				return;
			}
			Color color = usingMaterial.GetColor(colorID);
			float f = (Time.realtimeSinceStartup - startTime) * MathF.PI * 2f;
			f = Mathf.Cos(f);
			f = Util.RemapNumberClamped(f, -1f, 1f, 0f, 1f);
			if (Time.realtimeSinceStartup - startTime - tickCount > 1f)
			{
				tickCount += 1f;
				hapticFlash.Execute(0f, 0.005f, 0.005f, 1f, inputSource);
			}
			for (int i = 0; i < flashingRenderers.Count; i++)
			{
				flashingRenderers[i].material.SetColor(colorID, Color.Lerp(color, flashColor, f));
			}
			if (!initialized)
			{
				return;
			}
			foreach (KeyValuePair<ISteamVR_Action_In_Source, ActionHintInfo> actionHintInfo in actionHintInfos)
			{
				if (actionHintInfo.Value.textHintActive)
				{
					UpdateTextHint(actionHintInfo.Value);
				}
			}
		}

		private void UpdateTextHint(ActionHintInfo hintInfo)
		{
			Transform hmdTransform = player.hmdTransform;
			Vector3 forward = hmdTransform.position - hintInfo.canvasOffset.position;
			Quaternion a = Quaternion.LookRotation(forward, Vector3.up);
			Quaternion b = Quaternion.LookRotation(forward, hmdTransform.up);
			float t = ((!(hmdTransform.forward.y > 0f)) ? Util.RemapNumberClamped(hmdTransform.forward.y, -0.8f, -0.6f, 1f, 0f) : Util.RemapNumberClamped(hmdTransform.forward.y, 0.6f, 0.4f, 1f, 0f));
			hintInfo.canvasOffset.rotation = Quaternion.Slerp(a, b, t);
			Transform transform = hintInfo.line.transform;
			hintInfo.line.useWorldSpace = false;
			hintInfo.line.SetPosition(0, transform.InverseTransformPoint(hintInfo.textStartAnchor.position));
			hintInfo.line.SetPosition(1, transform.InverseTransformPoint(hintInfo.textEndAnchor.position));
		}

		private void Clear()
		{
			renderers.Clear();
			flashingRenderers.Clear();
		}

		private void ShowText(ISteamVR_Action_In_Source action, string text, bool highlightButton = true)
		{
			if (actionHintInfos.ContainsKey(action))
			{
				ActionHintInfo actionHintInfo = actionHintInfos[action];
				actionHintInfo.textHintObject.SetActive(value: true);
				actionHintInfo.textHintActive = true;
				if (actionHintInfo.text != null)
				{
					actionHintInfo.text.text = text;
				}
				if (actionHintInfo.textMesh != null)
				{
					actionHintInfo.textMesh.text = text;
				}
				UpdateTextHint(actionHintInfo);
				if (highlightButton)
				{
					ShowButtonHint(action);
				}
				renderModel.gameObject.SetActive(value: true);
			}
		}

		private void HideText(ISteamVR_Action_In_Source action)
		{
			if (actionHintInfos.ContainsKey(action))
			{
				ActionHintInfo actionHintInfo = actionHintInfos[action];
				actionHintInfo.textHintObject.SetActive(value: false);
				actionHintInfo.textHintActive = false;
				HideButtonHint(action);
			}
		}

		private void HideAllText()
		{
			if (actionHintInfos == null)
			{
				return;
			}
			foreach (KeyValuePair<ISteamVR_Action_In_Source, ActionHintInfo> actionHintInfo in actionHintInfos)
			{
				actionHintInfo.Value.textHintObject.SetActive(value: false);
				actionHintInfo.Value.textHintActive = false;
			}
			HideAllButtonHints();
		}

		private string GetActiveHintText(ISteamVR_Action_In_Source action)
		{
			if (actionHintInfos.ContainsKey(action))
			{
				ActionHintInfo actionHintInfo = actionHintInfos[action];
				if (actionHintInfo.textHintActive)
				{
					return actionHintInfo.text.text;
				}
			}
			return string.Empty;
		}

		private static ControllerButtonHints GetControllerButtonHints(Hand hand)
		{
			if (hand != null)
			{
				ControllerButtonHints componentInChildren = hand.GetComponentInChildren<ControllerButtonHints>();
				if (componentInChildren != null && componentInChildren.initialized)
				{
					return componentInChildren;
				}
			}
			return null;
		}

		public static void ShowButtonHint(Hand hand, params ISteamVR_Action_In_Source[] actions)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				controllerButtonHints.ShowButtonHint(actions);
			}
		}

		public static void HideButtonHint(Hand hand, params ISteamVR_Action_In_Source[] actions)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				controllerButtonHints.HideButtonHint(actions);
			}
		}

		public static void HideAllButtonHints(Hand hand)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				controllerButtonHints.HideAllButtonHints();
			}
		}

		public static bool IsButtonHintActive(Hand hand, ISteamVR_Action_In_Source action)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				return controllerButtonHints.IsButtonHintActive(action);
			}
			return false;
		}

		public static void ShowTextHint(Hand hand, ISteamVR_Action_In_Source action, string text, bool highlightButton = true)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				controllerButtonHints.ShowText(action, text, highlightButton);
				if (hand != null && controllerButtonHints.autoSetWithControllerRangeOfMotion)
				{
					hand.SetTemporarySkeletonRangeOfMotion(SkeletalMotionRangeChange.WithController);
				}
			}
		}

		public static void HideTextHint(Hand hand, ISteamVR_Action_In_Source action)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				controllerButtonHints.HideText(action);
				if (hand != null && controllerButtonHints.autoSetWithControllerRangeOfMotion)
				{
					hand.ResetTemporarySkeletonRangeOfMotion();
				}
			}
		}

		public static void HideAllTextHints(Hand hand)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				controllerButtonHints.HideAllText();
			}
		}

		public static string GetActiveHintText(Hand hand, ISteamVR_Action_In_Source action)
		{
			ControllerButtonHints controllerButtonHints = GetControllerButtonHints(hand);
			if (controllerButtonHints != null)
			{
				return controllerButtonHints.GetActiveHintText(action);
			}
			return string.Empty;
		}
	}
	public class ArcheryTarget : MonoBehaviour
	{
		public UnityEvent onTakeDamage;

		public bool onceOnly;

		public Transform targetCenter;

		public Transform baseTransform;

		public Transform fallenDownTransform;

		public float fallTime = 0.5f;

		private const float targetRadius = 0.25f;

		private bool targetEnabled = true;

		private void ApplyDamage()
		{
			OnDamageTaken();
		}

		private void FireExposure()
		{
			OnDamageTaken();
		}

		private void OnDamageTaken()
		{
			if (targetEnabled)
			{
				onTakeDamage.Invoke();
				StartCoroutine(FallDown());
				if (onceOnly)
				{
					targetEnabled = false;
				}
			}
		}

		private IEnumerator FallDown()
		{
			if ((bool)baseTransform)
			{
				Quaternion startingRot = baseTransform.rotation;
				float startTime = Time.time;
				float rotLerp = 0f;
				while (rotLerp < 1f)
				{
					rotLerp = Util.RemapNumberClamped(Time.time, startTime, startTime + fallTime, 0f, 1f);
					baseTransform.rotation = Quaternion.Lerp(startingRot, fallenDownTransform.rotation, rotLerp);
					yield return null;
				}
			}
			yield return null;
		}
	}
	public class Arrow : MonoBehaviour
	{
		public ParticleSystem glintParticle;

		public Rigidbody arrowHeadRB;

		public Rigidbody shaftRB;

		public PhysicsMaterial targetPhysMaterial;

		private Vector3 prevPosition;

		private Quaternion prevRotation;

		private Vector3 prevVelocity;

		private Vector3 prevHeadPosition;

		public SoundPlayOneshot fireReleaseSound;

		public SoundPlayOneshot airReleaseSound;

		public SoundPlayOneshot hitTargetSound;

		public PlaySound hitGroundSound;

		private bool inFlight;

		private bool released;

		private bool hasSpreadFire;

		private int travelledFrames;

		private GameObject scaleParentObject;

		private void Start()
		{
			Physics.IgnoreCollision(shaftRB.GetComponent<Collider>(), Player.instance.headCollider);
		}

		private void FixedUpdate()
		{
			if (released && inFlight)
			{
				prevPosition = base.transform.position;
				prevRotation = base.transform.rotation;
				prevVelocity = GetComponent<Rigidbody>().linearVelocity;
				prevHeadPosition = arrowHeadRB.transform.position;
				travelledFrames++;
			}
		}

		public void ArrowReleased(float inputVelocity)
		{
			inFlight = true;
			released = true;
			airReleaseSound.Play();
			if (glintParticle != null)
			{
				glintParticle.Play();
			}
			if (base.gameObject.GetComponentInChildren<FireSource>().isBurning)
			{
				fireReleaseSound.Play();
			}
			RaycastHit[] array = Physics.SphereCastAll(base.transform.position, 0.01f, base.transform.forward, 0.8f, -5, QueryTriggerInteraction.Ignore);
			for (int i = 0; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (raycastHit.collider.gameObject != base.gameObject && raycastHit.collider.gameObject != arrowHeadRB.gameObject && raycastHit.collider != Player.instance.headCollider)
				{
					UnityEngine.Object.Destroy(base.gameObject);
					return;
				}
			}
			travelledFrames = 0;
			prevPosition = base.transform.position;
			prevRotation = base.transform.rotation;
			prevHeadPosition = arrowHeadRB.transform.position;
			prevVelocity = GetComponent<Rigidbody>().linearVelocity;
			SetCollisionMode(CollisionDetectionMode.ContinuousDynamic);
			UnityEngine.Object.Destroy(base.gameObject, 30f);
		}

		protected void SetCollisionMode(CollisionDetectionMode newMode, bool force = false)
		{
			Rigidbody[] componentsInChildren = GetComponentsInChildren<Rigidbody>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!componentsInChildren[i].isKinematic || force)
				{
					componentsInChildren[i].collisionDetectionMode = newMode;
				}
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (!inFlight)
			{
				return;
			}
			float sqrMagnitude = GetComponent<Rigidbody>().linearVelocity.sqrMagnitude;
			bool flag = targetPhysMaterial != null && collision.collider.sharedMaterial == targetPhysMaterial && sqrMagnitude > 0.2f;
			bool flag2 = collision.collider.gameObject.GetComponent<Balloon>() != null;
			if (travelledFrames < 2 && !flag)
			{
				base.transform.position = prevPosition - prevVelocity * Time.deltaTime;
				base.transform.rotation = prevRotation;
				Vector3 vector = Vector3.Reflect(arrowHeadRB.linearVelocity, collision.contacts[0].normal);
				arrowHeadRB.linearVelocity = vector * 0.25f;
				shaftRB.linearVelocity = vector * 0.25f;
				travelledFrames = 0;
				return;
			}
			if (glintParticle != null)
			{
				glintParticle.Stop(withChildren: true);
			}
			if (sqrMagnitude > 0.1f)
			{
				hitGroundSound.Play();
			}
			FireSource componentInChildren = base.gameObject.GetComponentInChildren<FireSource>();
			FireSource componentInParent = collision.collider.GetComponentInParent<FireSource>();
			if (componentInChildren != null && componentInChildren.isBurning && componentInParent != null)
			{
				if (!hasSpreadFire)
				{
					collision.collider.gameObject.SendMessageUpwards("FireExposure", base.gameObject, SendMessageOptions.DontRequireReceiver);
					hasSpreadFire = true;
				}
			}
			else if (sqrMagnitude > 0.1f || flag2)
			{
				collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
				base.gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
			}
			if (flag2)
			{
				base.transform.position = prevPosition;
				base.transform.rotation = prevRotation;
				arrowHeadRB.linearVelocity = prevVelocity;
				Physics.IgnoreCollision(arrowHeadRB.GetComponent<Collider>(), collision.collider);
				Physics.IgnoreCollision(shaftRB.GetComponent<Collider>(), collision.collider);
			}
			if (flag)
			{
				StickInTarget(collision, travelledFrames < 2);
			}
			if ((bool)Player.instance && collision.collider == Player.instance.headCollider)
			{
				Player.instance.PlayerShotSelf();
			}
		}

		private void StickInTarget(Collision collision, bool bSkipRayCast)
		{
			Vector3 direction = prevRotation * Vector3.forward;
			if (!bSkipRayCast)
			{
				RaycastHit[] array = Physics.RaycastAll(prevHeadPosition - prevVelocity * Time.deltaTime, direction, prevVelocity.magnitude * Time.deltaTime * 2f);
				bool flag = false;
				foreach (RaycastHit raycastHit in array)
				{
					if (raycastHit.collider == collision.collider)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return;
				}
			}
			UnityEngine.Object.Destroy(glintParticle);
			inFlight = false;
			SetCollisionMode(CollisionDetectionMode.Discrete, force: true);
			shaftRB.linearVelocity = Vector3.zero;
			shaftRB.angularVelocity = Vector3.zero;
			shaftRB.isKinematic = true;
			shaftRB.useGravity = false;
			shaftRB.transform.GetComponent<BoxCollider>().enabled = false;
			arrowHeadRB.linearVelocity = Vector3.zero;
			arrowHeadRB.angularVelocity = Vector3.zero;
			arrowHeadRB.isKinematic = true;
			arrowHeadRB.useGravity = false;
			arrowHeadRB.transform.GetComponent<BoxCollider>().enabled = false;
			hitTargetSound.Play();
			scaleParentObject = new GameObject("Arrow Scale Parent");
			Transform parent = collision.collider.transform;
			if (!collision.collider.gameObject.GetComponent<ExplosionWobble>() && (bool)parent.parent)
			{
				parent = parent.parent;
			}
			scaleParentObject.transform.parent = parent;
			base.transform.parent = scaleParentObject.transform;
			base.transform.rotation = prevRotation;
			base.transform.position = prevPosition;
			base.transform.position = collision.contacts[0].point - base.transform.forward * (0.75f - (Util.RemapNumberClamped(prevVelocity.magnitude, 0f, 10f, 0f, 0.1f) + UnityEngine.Random.Range(0f, 0.05f)));
		}

		private void OnDestroy()
		{
			if (scaleParentObject != null)
			{
				UnityEngine.Object.Destroy(scaleParentObject);
			}
		}
	}
	public class ArrowHand : MonoBehaviour
	{
		private Hand hand;

		private Longbow bow;

		private GameObject currentArrow;

		public GameObject arrowPrefab;

		public Transform arrowNockTransform;

		public float nockDistance = 0.1f;

		public float lerpCompleteDistance = 0.08f;

		public float rotationLerpThreshold = 0.15f;

		public float positionLerpThreshold = 0.15f;

		private bool allowArrowSpawn = true;

		private bool nocked;

		private GrabTypes nockedWithType;

		private bool inNockRange;

		private bool arrowLerpComplete;

		public SoundPlayOneshot arrowSpawnSound;

		private AllowTeleportWhileAttachedToHand allowTeleport;

		public int maxArrowCount = 10;

		private List<GameObject> arrowList;

		private void Awake()
		{
			allowTeleport = GetComponent<AllowTeleportWhileAttachedToHand>();
			allowTeleport.overrideHoverLock = false;
			arrowList = new List<GameObject>();
		}

		private void OnAttachedToHand(Hand attachedHand)
		{
			hand = attachedHand;
			FindBow();
		}

		private GameObject InstantiateArrow()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(arrowPrefab, arrowNockTransform.position, arrowNockTransform.rotation);
			gameObject.name = "Bow Arrow";
			gameObject.transform.parent = arrowNockTransform;
			Util.ResetTransform(gameObject.transform);
			arrowList.Add(gameObject);
			while (arrowList.Count > maxArrowCount)
			{
				GameObject gameObject2 = arrowList[0];
				arrowList.RemoveAt(0);
				if ((bool)gameObject2)
				{
					UnityEngine.Object.Destroy(gameObject2);
				}
			}
			return gameObject;
		}

		private void HandAttachedUpdate(Hand hand)
		{
			if (bow == null)
			{
				FindBow();
			}
			if (bow == null)
			{
				return;
			}
			if (allowArrowSpawn && currentArrow == null)
			{
				currentArrow = InstantiateArrow();
				arrowSpawnSound.Play();
			}
			float num = Vector3.Distance(base.transform.parent.position, bow.nockTransform.position);
			if (!nocked)
			{
				if (num < rotationLerpThreshold)
				{
					float t = Util.RemapNumber(num, rotationLerpThreshold, lerpCompleteDistance, 0f, 1f);
					arrowNockTransform.rotation = Quaternion.Lerp(arrowNockTransform.parent.rotation, bow.nockRestTransform.rotation, t);
				}
				else
				{
					arrowNockTransform.localRotation = Quaternion.identity;
				}
				if (num < positionLerpThreshold)
				{
					float value = Util.RemapNumber(num, positionLerpThreshold, lerpCompleteDistance, 0f, 1f);
					value = Mathf.Clamp(value, 0f, 1f);
					arrowNockTransform.position = Vector3.Lerp(arrowNockTransform.parent.position, bow.nockRestTransform.position, value);
				}
				else
				{
					arrowNockTransform.position = arrowNockTransform.parent.position;
				}
				if (num < lerpCompleteDistance)
				{
					if (!arrowLerpComplete)
					{
						arrowLerpComplete = true;
						hand.TriggerHapticPulse(500);
					}
				}
				else if (arrowLerpComplete)
				{
					arrowLerpComplete = false;
				}
				if (num < nockDistance)
				{
					if (!inNockRange)
					{
						inNockRange = true;
						bow.ArrowInPosition();
					}
				}
				else if (inNockRange)
				{
					inNockRange = false;
				}
				GrabTypes bestGrabbingType = hand.GetBestGrabbingType(GrabTypes.Pinch, forcePreference: true);
				if (num < nockDistance && bestGrabbingType != GrabTypes.None && !nocked)
				{
					if (currentArrow == null)
					{
						currentArrow = InstantiateArrow();
					}
					nocked = true;
					nockedWithType = bestGrabbingType;
					bow.StartNock(this);
					hand.HoverLock(GetComponent<Interactable>());
					allowTeleport.teleportAllowed = false;
					currentArrow.transform.parent = bow.nockTransform;
					Util.ResetTransform(currentArrow.transform);
					Util.ResetTransform(arrowNockTransform);
				}
			}
			if (nocked && !hand.IsGrabbingWithType(nockedWithType))
			{
				if (bow.pulled)
				{
					FireArrow();
				}
				else
				{
					arrowNockTransform.rotation = currentArrow.transform.rotation;
					currentArrow.transform.parent = arrowNockTransform;
					Util.ResetTransform(currentArrow.transform);
					nocked = false;
					nockedWithType = GrabTypes.None;
					bow.ReleaseNock();
					hand.HoverUnlock(GetComponent<Interactable>());
					allowTeleport.teleportAllowed = true;
				}
				bow.StartRotationLerp();
			}
		}

		private void OnDetachedFromHand(Hand hand)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void FireArrow()
		{
			currentArrow.transform.parent = null;
			Arrow component = currentArrow.GetComponent<Arrow>();
			component.shaftRB.isKinematic = false;
			component.shaftRB.useGravity = true;
			component.shaftRB.transform.GetComponent<BoxCollider>().enabled = true;
			component.arrowHeadRB.isKinematic = false;
			component.arrowHeadRB.useGravity = true;
			component.arrowHeadRB.transform.GetComponent<BoxCollider>().enabled = true;
			component.arrowHeadRB.AddForce(currentArrow.transform.forward * bow.GetArrowVelocity() * component.arrowHeadRB.mass, ForceMode.Impulse);
			component.arrowHeadRB.AddTorque(currentArrow.transform.forward * 10f);
			nocked = false;
			nockedWithType = GrabTypes.None;
			currentArrow.GetComponent<Arrow>().ArrowReleased(bow.GetArrowVelocity());
			bow.ArrowReleased();
			allowArrowSpawn = false;
			Invoke("EnableArrowSpawn", 0.5f);
			StartCoroutine(ArrowReleaseHaptics());
			currentArrow = null;
			allowTeleport.teleportAllowed = true;
		}

		private void EnableArrowSpawn()
		{
			allowArrowSpawn = true;
		}

		private IEnumerator ArrowReleaseHaptics()
		{
			yield return new WaitForSeconds(0.05f);
			hand.otherHand.TriggerHapticPulse(1500);
			yield return new WaitForSeconds(0.05f);
			hand.otherHand.TriggerHapticPulse(800);
			yield return new WaitForSeconds(0.05f);
			hand.otherHand.TriggerHapticPulse(500);
			yield return new WaitForSeconds(0.05f);
			hand.otherHand.TriggerHapticPulse(300);
		}

		private void OnHandFocusLost(Hand hand)
		{
			base.gameObject.SetActive(value: false);
		}

		private void OnHandFocusAcquired(Hand hand)
		{
			base.gameObject.SetActive(value: true);
		}

		private void FindBow()
		{
			bow = hand.otherHand.GetComponentInChildren<Longbow>();
		}
	}
	public class ArrowheadRotation : MonoBehaviour
	{
		private void Start()
		{
			float x = UnityEngine.Random.Range(0f, 180f);
			base.transform.localEulerAngles = new Vector3(x, -90f, 90f);
		}
	}
	public class Balloon : MonoBehaviour
	{
		public enum BalloonColor
		{
			Red,
			OrangeRed,
			Orange,
			YellowOrange,
			Yellow,
			GreenYellow,
			Green,
			BlueGreen,
			Blue,
			VioletBlue,
			Violet,
			RedViolet,
			LightGray,
			DarkGray,
			Random
		}

		private Hand hand;

		public GameObject popPrefab;

		public float maxVelocity = 5f;

		public float lifetime = 15f;

		public bool burstOnLifetimeEnd;

		public GameObject lifetimeEndParticlePrefab;

		public SoundPlayOneshot lifetimeEndSound;

		private float destructTime;

		private float releaseTime = 99999f;

		public SoundPlayOneshot collisionSound;

		private float lastSoundTime;

		private float soundDelay = 0.2f;

		private Rigidbody balloonRigidbody;

		private bool bParticlesSpawned;

		private static float s_flLastDeathSound;

		private void Start()
		{
			destructTime = Time.time + lifetime + UnityEngine.Random.value;
			hand = GetComponentInParent<Hand>();
			balloonRigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (destructTime != 0f && Time.time > destructTime)
			{
				if (burstOnLifetimeEnd)
				{
					SpawnParticles(lifetimeEndParticlePrefab, lifetimeEndSound);
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void SpawnParticles(GameObject particlePrefab, SoundPlayOneshot sound)
		{
			if (bParticlesSpawned)
			{
				return;
			}
			bParticlesSpawned = true;
			if (particlePrefab != null)
			{
				GameObject obj = UnityEngine.Object.Instantiate(particlePrefab, base.transform.position, base.transform.rotation);
				obj.GetComponent<ParticleSystem>().Play();
				UnityEngine.Object.Destroy(obj, 2f);
			}
			if (sound != null)
			{
				if (Time.time - s_flLastDeathSound < 0.1f)
				{
					sound.volMax *= 0.25f;
					sound.volMin *= 0.25f;
				}
				sound.Play();
				s_flLastDeathSound = Time.time;
			}
		}

		private void FixedUpdate()
		{
			if (balloonRigidbody.linearVelocity.sqrMagnitude > maxVelocity)
			{
				balloonRigidbody.linearVelocity *= 0.97f;
			}
		}

		private void ApplyDamage()
		{
			SpawnParticles(popPrefab, null);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (bParticlesSpawned)
			{
				return;
			}
			Hand hand = null;
			BalloonHapticBump component = collision.gameObject.GetComponent<BalloonHapticBump>();
			if (component != null && component.physParent != null)
			{
				hand = component.physParent.GetComponentInParent<Hand>();
			}
			if (Time.time > lastSoundTime + soundDelay)
			{
				if (hand != null)
				{
					if (Time.time > releaseTime + soundDelay)
					{
						collisionSound.Play();
						lastSoundTime = Time.time;
					}
				}
				else
				{
					collisionSound.Play();
					lastSoundTime = Time.time;
				}
			}
			if (!(destructTime > 0f))
			{
				if (balloonRigidbody.linearVelocity.magnitude > maxVelocity * 10f)
				{
					balloonRigidbody.linearVelocity = balloonRigidbody.linearVelocity.normalized * maxVelocity;
				}
				if (this.hand != null)
				{
					ushort microSecondsDuration = (ushort)Mathf.Clamp(Util.RemapNumber(collision.relativeVelocity.magnitude, 0f, 3f, 500f, 800f), 500f, 800f);
					this.hand.TriggerHapticPulse(microSecondsDuration);
				}
			}
		}

		public void SetColor(BalloonColor color)
		{
			GetComponentInChildren<MeshRenderer>().material.color = BalloonColorToRGB(color);
		}

		private Color BalloonColorToRGB(BalloonColor balloonColorVar)
		{
			Color result = new Color(255f, 0f, 0f);
			switch (balloonColorVar)
			{
			case BalloonColor.Red:
				return new Color(237f, 29f, 37f, 255f) / 255f;
			case BalloonColor.OrangeRed:
				return new Color(241f, 91f, 35f, 255f) / 255f;
			case BalloonColor.Orange:
				return new Color(245f, 140f, 31f, 255f) / 255f;
			case BalloonColor.YellowOrange:
				return new Color(253f, 185f, 19f, 255f) / 255f;
			case BalloonColor.Yellow:
				return new Color(254f, 243f, 0f, 255f) / 255f;
			case BalloonColor.GreenYellow:
				return new Color(172f, 209f, 54f, 255f) / 255f;
			case BalloonColor.Green:
				return new Color(0f, 167f, 79f, 255f) / 255f;
			case BalloonColor.BlueGreen:
				return new Color(108f, 202f, 189f, 255f) / 255f;
			case BalloonColor.Blue:
				return new Color(0f, 119f, 178f, 255f) / 255f;
			case BalloonColor.VioletBlue:
				return new Color(82f, 80f, 162f, 255f) / 255f;
			case BalloonColor.Violet:
				return new Color(102f, 46f, 143f, 255f) / 255f;
			case BalloonColor.RedViolet:
				return new Color(182f, 36f, 102f, 255f) / 255f;
			case BalloonColor.LightGray:
				return new Color(192f, 192f, 192f, 255f) / 255f;
			case BalloonColor.DarkGray:
				return new Color(128f, 128f, 128f, 255f) / 255f;
			case BalloonColor.Random:
			{
				int balloonColorVar2 = UnityEngine.Random.Range(0, 12);
				return BalloonColorToRGB((BalloonColor)balloonColorVar2);
			}
			default:
				return result;
			}
		}
	}
	public class BalloonColliders : MonoBehaviour
	{
		public GameObject[] colliders;

		private Vector3[] colliderLocalPositions;

		private Quaternion[] colliderLocalRotations;

		private Rigidbody rb;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
			colliderLocalPositions = new Vector3[colliders.Length];
			colliderLocalRotations = new Quaternion[colliders.Length];
			for (int i = 0; i < colliders.Length; i++)
			{
				colliderLocalPositions[i] = colliders[i].transform.localPosition;
				colliderLocalRotations[i] = colliders[i].transform.localRotation;
				colliders[i].name = base.gameObject.name + "." + colliders[i].name;
			}
		}

		private void OnEnable()
		{
			for (int i = 0; i < colliders.Length; i++)
			{
				colliders[i].transform.SetParent(base.transform);
				colliders[i].transform.localPosition = colliderLocalPositions[i];
				colliders[i].transform.localRotation = colliderLocalRotations[i];
				colliders[i].transform.SetParent(null);
				FixedJoint fixedJoint = colliders[i].AddComponent<FixedJoint>();
				fixedJoint.connectedBody = rb;
				fixedJoint.breakForce = float.PositiveInfinity;
				fixedJoint.breakTorque = float.PositiveInfinity;
				fixedJoint.enableCollision = false;
				fixedJoint.enablePreprocessing = true;
				colliders[i].SetActive(value: true);
			}
		}

		private void OnDisable()
		{
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i] != null)
				{
					UnityEngine.Object.Destroy(colliders[i].GetComponent<FixedJoint>());
					colliders[i].SetActive(value: false);
				}
			}
		}

		private void OnDestroy()
		{
			for (int i = 0; i < colliders.Length; i++)
			{
				UnityEngine.Object.Destroy(colliders[i]);
			}
		}
	}
	public class BalloonHapticBump : MonoBehaviour
	{
		public GameObject physParent;

		private void OnCollisionEnter(Collision other)
		{
			if (other.collider.GetComponentInParent<Balloon>() != null)
			{
				Hand componentInParent = physParent.GetComponentInParent<Hand>();
				if (componentInParent != null)
				{
					componentInParent.TriggerHapticPulse(500);
				}
			}
		}
	}
	public class BalloonSpawner : MonoBehaviour
	{
		public float minSpawnTime = 5f;

		public float maxSpawnTime = 15f;

		private float nextSpawnTime;

		public GameObject balloonPrefab;

		public bool autoSpawn = true;

		public bool spawnAtStartup = true;

		public bool playSounds = true;

		public SoundPlayOneshot inflateSound;

		public SoundPlayOneshot stretchSound;

		public bool sendSpawnMessageToParent;

		public float scale = 1f;

		public Transform spawnDirectionTransform;

		public float spawnForce;

		public bool attachBalloon;

		public Balloon.BalloonColor color = Balloon.BalloonColor.Random;

		private void Start()
		{
			if (!(balloonPrefab == null) && autoSpawn && spawnAtStartup)
			{
				SpawnBalloon(color);
				nextSpawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
			}
		}

		private void Update()
		{
			if (!(balloonPrefab == null) && Time.time > nextSpawnTime && autoSpawn)
			{
				SpawnBalloon(color);
				nextSpawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
			}
		}

		public GameObject SpawnBalloon(Balloon.BalloonColor color = Balloon.BalloonColor.Red)
		{
			if (balloonPrefab == null)
			{
				return null;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(balloonPrefab, base.transform.position, base.transform.rotation);
			gameObject.transform.localScale = new Vector3(scale, scale, scale);
			if (attachBalloon)
			{
				gameObject.transform.parent = base.transform;
			}
			if (sendSpawnMessageToParent && base.transform.parent != null)
			{
				base.transform.parent.SendMessage("OnBalloonSpawned", gameObject, SendMessageOptions.DontRequireReceiver);
			}
			if (playSounds)
			{
				if (inflateSound != null)
				{
					inflateSound.Play();
				}
				if (stretchSound != null)
				{
					stretchSound.Play();
				}
			}
			gameObject.GetComponentInChildren<Balloon>().SetColor(color);
			if (spawnDirectionTransform != null)
			{
				gameObject.GetComponentInChildren<Rigidbody>().AddForce(spawnDirectionTransform.forward * spawnForce);
			}
			return gameObject;
		}

		public void SpawnBalloonFromEvent(int color)
		{
			SpawnBalloon((Balloon.BalloonColor)color);
		}
	}
	public class ExplosionWobble : MonoBehaviour
	{
		public void ExplosionEvent(Vector3 explosionPos)
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.AddExplosionForce(2000f, explosionPos, 10f);
			}
		}
	}
	public class FireSource : MonoBehaviour
	{
		public GameObject fireParticlePrefab;

		public bool startActive;

		private GameObject fireObject;

		public ParticleSystem customParticles;

		public bool isBurning;

		public float burnTime;

		public float ignitionDelay;

		private float ignitionTime;

		private Hand hand;

		public AudioSource ignitionSound;

		public bool canSpreadFromThisSource = true;

		private void Start()
		{
			if (startActive)
			{
				StartBurning();
			}
		}

		private void Update()
		{
			if (burnTime != 0f && Time.time > ignitionTime + burnTime && isBurning)
			{
				isBurning = false;
				if (customParticles != null)
				{
					customParticles.Stop();
				}
				else
				{
					UnityEngine.Object.Destroy(fireObject);
				}
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (isBurning && canSpreadFromThisSource)
			{
				other.SendMessageUpwards("FireExposure", SendMessageOptions.DontRequireReceiver);
			}
		}

		private void FireExposure()
		{
			if (fireObject == null)
			{
				Invoke("StartBurning", ignitionDelay);
			}
			if ((bool)(hand = GetComponentInParent<Hand>()))
			{
				hand.TriggerHapticPulse(1000);
			}
		}

		private void StartBurning()
		{
			isBurning = true;
			ignitionTime = Time.time;
			if (ignitionSound != null)
			{
				ignitionSound.Play();
			}
			if (customParticles != null)
			{
				customParticles.Play();
			}
			else if (fireParticlePrefab != null)
			{
				fireObject = UnityEngine.Object.Instantiate(fireParticlePrefab, base.transform.position, base.transform.rotation);
				fireObject.transform.parent = base.transform;
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class Longbow : MonoBehaviour
	{
		public enum Handedness
		{
			Left,
			Right
		}

		public Handedness currentHandGuess;

		private float timeOfPossibleHandSwitch;

		private float timeBeforeConfirmingHandSwitch = 1.5f;

		private bool possibleHandSwitch;

		public Transform pivotTransform;

		public Transform handleTransform;

		private Hand hand;

		private ArrowHand arrowHand;

		public Transform nockTransform;

		public Transform nockRestTransform;

		public bool autoSpawnArrowHand = true;

		public ItemPackage arrowHandItemPackage;

		public GameObject arrowHandPrefab;

		public bool nocked;

		public bool pulled;

		private const float minPull = 0.05f;

		private const float maxPull = 0.5f;

		private float nockDistanceTravelled;

		private float hapticDistanceThreshold = 0.01f;

		private float lastTickDistance;

		private const float bowPullPulseStrengthLow = 100f;

		private const float bowPullPulseStrengthHigh = 500f;

		private Vector3 bowLeftVector;

		public float arrowMinVelocity = 3f;

		public float arrowMaxVelocity = 30f;

		private float arrowVelocity = 30f;

		private float minStrainTickTime = 0.1f;

		private float maxStrainTickTime = 0.5f;

		private float nextStrainTick;

		private bool lerpBackToZeroRotation;

		private float lerpStartTime;

		private float lerpDuration = 0.15f;

		private Quaternion lerpStartRotation;

		private float nockLerpStartTime;

		private Quaternion nockLerpStartRotation;

		public float drawOffset = 0.06f;

		public LinearMapping bowDrawLinearMapping;

		private Vector3 lateUpdatePos;

		private Quaternion lateUpdateRot;

		public SoundBowClick drawSound;

		private float drawTension;

		public SoundPlayOneshot arrowSlideSound;

		public SoundPlayOneshot releaseSound;

		public SoundPlayOneshot nockSound;

		private SteamVR_Events.Action newPosesAppliedAction;

		private void OnAttachedToHand(Hand attachedHand)
		{
			hand = attachedHand;
		}

		private void HandAttachedUpdate(Hand hand)
		{
			EvaluateHandedness();
			if (nocked)
			{
				Vector3 lhs = arrowHand.arrowNockTransform.parent.position - nockRestTransform.position;
				float num = Util.RemapNumberClamped(Time.time, nockLerpStartTime, nockLerpStartTime + lerpDuration, 0f, 1f);
				float num2 = Util.RemapNumberClamped(lhs.magnitude, 0.05f, 0.5f, 0f, 1f);
				Vector3 normalized = (Player.instance.hmdTransform.position + Vector3.down * 0.05f - arrowHand.arrowNockTransform.parent.position).normalized;
				Vector3 normalized2 = (arrowHand.arrowNockTransform.parent.position + normalized * drawOffset * num2 - pivotTransform.position).normalized;
				Vector3 normalized3 = (handleTransform.position - pivotTransform.position).normalized;
				bowLeftVector = -Vector3.Cross(normalized3, normalized2);
				pivotTransform.rotation = Quaternion.Lerp(nockLerpStartRotation, Quaternion.LookRotation(normalized2, bowLeftVector), num);
				if (Vector3.Dot(lhs, -nockTransform.forward) > 0f)
				{
					float num3 = lhs.magnitude * num;
					nockTransform.localPosition = new Vector3(0f, 0f, Mathf.Clamp(0f - num3, -0.5f, 0f));
					nockDistanceTravelled = 0f - nockTransform.localPosition.z;
					arrowVelocity = Util.RemapNumber(nockDistanceTravelled, 0.05f, 0.5f, arrowMinVelocity, arrowMaxVelocity);
					drawTension = Util.RemapNumberClamped(nockDistanceTravelled, 0f, 0.5f, 0f, 1f);
					bowDrawLinearMapping.value = drawTension;
					if (nockDistanceTravelled > 0.05f)
					{
						pulled = true;
					}
					else
					{
						pulled = false;
					}
					if (nockDistanceTravelled > lastTickDistance + hapticDistanceThreshold || nockDistanceTravelled < lastTickDistance - hapticDistanceThreshold)
					{
						ushort microSecondsDuration = (ushort)Util.RemapNumber(nockDistanceTravelled, 0f, 0.5f, 100f, 500f);
						hand.TriggerHapticPulse(microSecondsDuration);
						hand.otherHand.TriggerHapticPulse(microSecondsDuration);
						drawSound.PlayBowTensionClicks(drawTension);
						lastTickDistance = nockDistanceTravelled;
					}
					if (nockDistanceTravelled >= 0.5f && Time.time > nextStrainTick)
					{
						hand.TriggerHapticPulse(400);
						hand.otherHand.TriggerHapticPulse(400);
						drawSound.PlayBowTensionClicks(drawTension);
						nextStrainTick = Time.time + UnityEngine.Random.Range(minStrainTickTime, maxStrainTickTime);
					}
				}
				else
				{
					nockTransform.localPosition = new Vector3(0f, 0f, 0f);
					bowDrawLinearMapping.value = 0f;
				}
			}
			else if (lerpBackToZeroRotation)
			{
				float num4 = Util.RemapNumber(Time.time, lerpStartTime, lerpStartTime + lerpDuration, 0f, 1f);
				pivotTransform.localRotation = Quaternion.Lerp(lerpStartRotation, Quaternion.identity, num4);
				if (num4 >= 1f)
				{
					lerpBackToZeroRotation = false;
				}
			}
		}

		public void ArrowReleased()
		{
			nocked = false;
			hand.HoverUnlock(GetComponent<Interactable>());
			hand.otherHand.HoverUnlock(arrowHand.GetComponent<Interactable>());
			if (releaseSound != null)
			{
				releaseSound.Play();
			}
			StartCoroutine(ResetDrawAnim());
		}

		private IEnumerator ResetDrawAnim()
		{
			float startTime = Time.time;
			float startLerp = drawTension;
			while (Time.time < startTime + 0.02f)
			{
				float value = Util.RemapNumberClamped(Time.time, startTime, startTime + 0.02f, startLerp, 0f);
				bowDrawLinearMapping.value = value;
				yield return null;
			}
			bowDrawLinearMapping.value = 0f;
		}

		public float GetArrowVelocity()
		{
			return arrowVelocity;
		}

		public void StartRotationLerp()
		{
			lerpStartTime = Time.time;
			lerpBackToZeroRotation = true;
			lerpStartRotation = pivotTransform.localRotation;
			Util.ResetTransform(nockTransform);
		}

		public void StartNock(ArrowHand currentArrowHand)
		{
			arrowHand = currentArrowHand;
			hand.HoverLock(GetComponent<Interactable>());
			nocked = true;
			nockLerpStartTime = Time.time;
			nockLerpStartRotation = pivotTransform.rotation;
			arrowSlideSound.Play();
			DoHandednessCheck();
		}

		private void EvaluateHandedness()
		{
			if (hand.handType == SteamVR_Input_Sources.LeftHand)
			{
				if (possibleHandSwitch && currentHandGuess == Handedness.Left)
				{
					possibleHandSwitch = false;
				}
				if (!possibleHandSwitch && currentHandGuess == Handedness.Right)
				{
					possibleHandSwitch = true;
					timeOfPossibleHandSwitch = Time.time;
				}
				if (possibleHandSwitch && Time.time > timeOfPossibleHandSwitch + timeBeforeConfirmingHandSwitch)
				{
					currentHandGuess = Handedness.Left;
					possibleHandSwitch = false;
				}
			}
			else
			{
				if (possibleHandSwitch && currentHandGuess == Handedness.Right)
				{
					possibleHandSwitch = false;
				}
				if (!possibleHandSwitch && currentHandGuess == Handedness.Left)
				{
					possibleHandSwitch = true;
					timeOfPossibleHandSwitch = Time.time;
				}
				if (possibleHandSwitch && Time.time > timeOfPossibleHandSwitch + timeBeforeConfirmingHandSwitch)
				{
					currentHandGuess = Handedness.Right;
					possibleHandSwitch = false;
				}
			}
		}

		private void DoHandednessCheck()
		{
			if (currentHandGuess == Handedness.Left)
			{
				pivotTransform.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				pivotTransform.localScale = new Vector3(1f, -1f, 1f);
			}
		}

		public void ArrowInPosition()
		{
			DoHandednessCheck();
			if (nockSound != null)
			{
				nockSound.Play();
			}
		}

		public void ReleaseNock()
		{
			nocked = false;
			hand.HoverUnlock(GetComponent<Interactable>());
			StartCoroutine(ResetDrawAnim());
		}

		private void ShutDown()
		{
			if (hand != null && hand.otherHand.currentAttachedObject != null && hand.otherHand.currentAttachedObject.GetComponent<ItemPackageReference>() != null && hand.otherHand.currentAttachedObject.GetComponent<ItemPackageReference>().itemPackage == arrowHandItemPackage)
			{
				hand.otherHand.DetachObject(hand.otherHand.currentAttachedObject);
			}
		}

		private void OnHandFocusLost(Hand hand)
		{
			base.gameObject.SetActive(value: false);
		}

		private void OnHandFocusAcquired(Hand hand)
		{
			base.gameObject.SetActive(value: true);
			OnAttachedToHand(hand);
		}

		private void OnDetachedFromHand(Hand hand)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void OnDestroy()
		{
			ShutDown();
		}
	}
	public class SoundBowClick : MonoBehaviour
	{
		public AudioClip bowClick;

		public AnimationCurve pitchTensionCurve;

		public float minPitch;

		public float maxPitch;

		private AudioSource thisAudioSource;

		private void Awake()
		{
			thisAudioSource = GetComponent<AudioSource>();
		}

		public void PlayBowTensionClicks(float normalizedTension)
		{
			float num = pitchTensionCurve.Evaluate(normalizedTension);
			thisAudioSource.pitch = (maxPitch - minPitch) * num + minPitch;
			thisAudioSource.PlayOneShot(bowClick);
		}
	}
	public class SnapTurn : MonoBehaviour
	{
		public float snapAngle = 90f;

		public bool showTurnAnimation = true;

		public AudioSource snapTurnSource;

		public AudioClip rotateSound;

		public GameObject rotateRightFX;

		public GameObject rotateLeftFX;

		public SteamVR_Action_Boolean snapLeftAction = SteamVR_Input.GetBooleanAction("SnapTurnLeft");

		public SteamVR_Action_Boolean snapRightAction = SteamVR_Input.GetBooleanAction("SnapTurnRight");

		public bool fadeScreen = true;

		public float fadeTime = 0.1f;

		public Color screenFadeColor = Color.black;

		public float distanceFromFace = 1.3f;

		public Vector3 additionalOffset = new Vector3(0f, -0.3f, 0f);

		public static float teleportLastActiveTime;

		private bool canRotate = true;

		public float canTurnEverySeconds = 0.4f;

		private Coroutine rotateCoroutine;

		private void Start()
		{
			AllOff();
		}

		private void AllOff()
		{
			if (rotateLeftFX != null)
			{
				rotateLeftFX.SetActive(value: false);
			}
			if (rotateRightFX != null)
			{
				rotateRightFX.SetActive(value: false);
			}
		}

		private void Update()
		{
			Player instance = Player.instance;
			if (canRotate && snapLeftAction != null && snapRightAction != null && snapLeftAction.activeBinding && snapRightAction.activeBinding && !(Time.time < teleportLastActiveTime + canTurnEverySeconds))
			{
				bool flag = instance.rightHand.currentAttachedObject == null || (instance.rightHand.currentAttachedObject != null && instance.rightHand.currentAttachedTeleportManager != null && instance.rightHand.currentAttachedTeleportManager.teleportAllowed);
				bool flag2 = instance.leftHand.currentAttachedObject == null || (instance.leftHand.currentAttachedObject != null && instance.leftHand.currentAttachedTeleportManager != null && instance.leftHand.currentAttachedTeleportManager.teleportAllowed);
				bool num = snapLeftAction.GetStateDown(SteamVR_Input_Sources.LeftHand) && flag2;
				bool flag3 = snapLeftAction.GetStateDown(SteamVR_Input_Sources.RightHand) && flag;
				bool flag4 = snapRightAction.GetStateDown(SteamVR_Input_Sources.LeftHand) && flag2;
				bool flag5 = snapRightAction.GetStateDown(SteamVR_Input_Sources.RightHand) && flag;
				if (num || flag3)
				{
					RotatePlayer(0f - snapAngle);
				}
				else if (flag4 || flag5)
				{
					RotatePlayer(snapAngle);
				}
			}
		}

		public void RotatePlayer(float angle)
		{
			if (rotateCoroutine != null)
			{
				StopCoroutine(rotateCoroutine);
				AllOff();
			}
			rotateCoroutine = StartCoroutine(DoRotatePlayer(angle));
		}

		private IEnumerator DoRotatePlayer(float angle)
		{
			Player player = Player.instance;
			canRotate = false;
			snapTurnSource.panStereo = angle / 90f;
			snapTurnSource.PlayOneShot(rotateSound);
			if (fadeScreen)
			{
				SteamVR_Fade.Start(Color.clear, 0f);
				Color color = screenFadeColor;
				color = color.linear * 0.6f;
				SteamVR_Fade.Start(color, fadeTime);
			}
			yield return new WaitForSeconds(fadeTime);
			Vector3 vector = player.trackingOriginTransform.position - player.feetPositionGuess;
			player.trackingOriginTransform.position -= vector;
			player.transform.Rotate(Vector3.up, angle);
			vector = Quaternion.Euler(0f, angle, 0f) * vector;
			player.trackingOriginTransform.position += vector;
			GameObject fx = ((angle > 0f) ? rotateRightFX : rotateLeftFX);
			if (showTurnAnimation)
			{
				ShowRotateFX(fx);
			}
			if (fadeScreen)
			{
				SteamVR_Fade.Start(Color.clear, fadeTime);
			}
			float time = Time.time;
			float endTime = time + canTurnEverySeconds;
			while (Time.time <= endTime)
			{
				yield return null;
				UpdateOrientation(fx);
			}
			fx.SetActive(value: false);
			canRotate = true;
		}

		private void ShowRotateFX(GameObject fx)
		{
			if (!(fx == null))
			{
				fx.SetActive(value: false);
				UpdateOrientation(fx);
				fx.SetActive(value: true);
				UpdateOrientation(fx);
			}
		}

		private void UpdateOrientation(GameObject fx)
		{
			Player instance = Player.instance;
			base.transform.position = instance.hmdTransform.position + instance.hmdTransform.forward * distanceFromFace;
			base.transform.rotation = Quaternion.LookRotation(instance.hmdTransform.position - base.transform.position, Vector3.up);
			base.transform.Translate(additionalOffset, Space.Self);
			base.transform.rotation = Quaternion.LookRotation(instance.hmdTransform.position - base.transform.position, Vector3.up);
		}
	}
	public class AllowTeleportWhileAttachedToHand : MonoBehaviour
	{
		public bool teleportAllowed = true;

		public bool overrideHoverLock = true;
	}
	public class ChaperoneInfo : MonoBehaviour
	{
		public static SteamVR_Events.Event Initialized = new SteamVR_Events.Event();

		private static ChaperoneInfo _instance;

		public bool initialized { get; private set; }

		public float playAreaSizeX { get; private set; }

		public float playAreaSizeZ { get; private set; }

		public bool roomscale { get; private set; }

		public static ChaperoneInfo instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GameObject("[ChaperoneInfo]").AddComponent<ChaperoneInfo>();
					_instance.initialized = false;
					_instance.playAreaSizeX = 1f;
					_instance.playAreaSizeZ = 1f;
					_instance.roomscale = false;
					UnityEngine.Object.DontDestroyOnLoad(_instance.gameObject);
				}
				return _instance;
			}
		}

		public static SteamVR_Events.Action InitializedAction(UnityAction action)
		{
			return new SteamVR_Events.ActionNoArgs(Initialized, action);
		}

		private IEnumerator Start()
		{
			CVRChaperone chaperone = OpenVR.Chaperone;
			if (chaperone == null)
			{
				UnityEngine.Debug.LogWarning("<b>[SteamVR Interaction]</b> Failed to get IVRChaperone interface.");
				initialized = true;
				yield break;
			}
			float pSizeX;
			float pSizeZ;
			while (true)
			{
				pSizeX = 0f;
				pSizeZ = 0f;
				if (chaperone.GetPlayAreaSize(ref pSizeX, ref pSizeZ))
				{
					break;
				}
				yield return null;
			}
			initialized = true;
			playAreaSizeX = pSizeX;
			playAreaSizeZ = pSizeZ;
			roomscale = Mathf.Max(pSizeX, pSizeZ) > 1.01f;
			UnityEngine.Debug.LogFormat("<b>[SteamVR Interaction]</b> ChaperoneInfo initialized. {2} play area {0:0.00}m x {1:0.00}m", pSizeX, pSizeZ, roomscale ? "Roomscale" : "Standing");
			Initialized.Send();
		}
	}
	public class IgnoreTeleportTrace : MonoBehaviour
	{
	}
	public class Teleport : MonoBehaviour
	{
		public SteamVR_Action_Boolean teleportAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Teleport");

		public LayerMask traceLayerMask;

		public LayerMask floorFixupTraceLayerMask;

		public float floorFixupMaximumTraceDistance = 1f;

		public Material areaVisibleMaterial;

		public Material areaLockedMaterial;

		public Material areaHighlightedMaterial;

		public Material pointVisibleMaterial;

		public Material pointLockedMaterial;

		public Material pointHighlightedMaterial;

		public Transform destinationReticleTransform;

		public Transform invalidReticleTransform;

		public GameObject playAreaPreviewCorner;

		public GameObject playAreaPreviewSide;

		public Color pointerValidColor;

		public Color pointerInvalidColor;

		public Color pointerLockedColor;

		public bool showPlayAreaMarker = true;

		public float teleportFadeTime = 0.1f;

		public float meshFadeTime = 0.2f;

		public float arcDistance = 10f;

		[Header("Effects")]
		public Transform onActivateObjectTransform;

		public Transform onDeactivateObjectTransform;

		public float activateObjectTime = 1f;

		public float deactivateObjectTime = 1f;

		[Header("Audio Sources")]
		public AudioSource pointerAudioSource;

		public AudioSource loopingAudioSource;

		public AudioSource headAudioSource;

		public AudioSource reticleAudioSource;

		[Header("Sounds")]
		public AudioClip teleportSound;

		public AudioClip pointerStartSound;

		public AudioClip pointerLoopSound;

		public AudioClip pointerStopSound;

		public AudioClip goodHighlightSound;

		public AudioClip badHighlightSound;

		[Header("Debug")]
		public bool debugFloor;

		public bool showOffsetReticle;

		public Transform offsetReticleTransform;

		public MeshRenderer floorDebugSphere;

		public LineRenderer floorDebugLine;

		private LineRenderer pointerLineRenderer;

		private GameObject teleportPointerObject;

		private Transform pointerStartTransform;

		private Hand pointerHand;

		private Player player;

		private TeleportArc teleportArc;

		private bool visible;

		private TeleportMarkerBase[] teleportMarkers;

		private TeleportMarkerBase pointedAtTeleportMarker;

		private TeleportMarkerBase teleportingToMarker;

		private Vector3 pointedAtPosition;

		private Vector3 prevPointedAtPosition;

		private bool teleporting;

		private float currentFadeTime;

		private float meshAlphaPercent = 1f;

		private float pointerShowStartTime;

		private float pointerHideStartTime;

		private bool meshFading;

		private float fullTintAlpha;

		private float invalidReticleMinScale = 0.2f;

		private float invalidReticleMaxScale = 1f;

		private float invalidReticleMinScaleDistance = 0.4f;

		private float invalidReticleMaxScaleDistance = 2f;

		private Vector3 invalidReticleScale = Vector3.one;

		private Quaternion invalidReticleTargetRotation = Quaternion.identity;

		private Transform playAreaPreviewTransform;

		private Transform[] playAreaPreviewCorners;

		private Transform[] playAreaPreviewSides;

		private float loopingAudioMaxVolume;

		private Coroutine hintCoroutine;

		private bool originalHoverLockState;

		private Interactable originalHoveringInteractable;

		private AllowTeleportWhileAttachedToHand allowTeleportWhileAttached;

		private Vector3 startingFeetOffset = Vector3.zero;

		private bool movedFeetFarEnough;

		private SteamVR_Events.Action chaperoneInfoInitializedAction;

		public static SteamVR_Events.Event<float> ChangeScene = new SteamVR_Events.Event<float>();

		public static SteamVR_Events.Event<TeleportMarkerBase> Player = new SteamVR_Events.Event<TeleportMarkerBase>();

		public static SteamVR_Events.Event<TeleportMarkerBase> PlayerPre = new SteamVR_Events.Event<TeleportMarkerBase>();

		private static Teleport _instance;

		public static Teleport instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = UnityEngine.Object.FindObjectOfType<Teleport>();
				}
				return _instance;
			}
		}

		public static SteamVR_Events.Action<float> ChangeSceneAction(UnityAction<float> action)
		{
			return new SteamVR_Events.Action<float>(ChangeScene, action);
		}

		public static SteamVR_Events.Action<TeleportMarkerBase> PlayerAction(UnityAction<TeleportMarkerBase> action)
		{
			return new SteamVR_Events.Action<TeleportMarkerBase>(Player, action);
		}

		public static SteamVR_Events.Action<TeleportMarkerBase> PlayerPreAction(UnityAction<TeleportMarkerBase> action)
		{
			return new SteamVR_Events.Action<TeleportMarkerBase>(PlayerPre, action);
		}

		private void Awake()
		{
			_instance = this;
			chaperoneInfoInitializedAction = ChaperoneInfo.InitializedAction(OnChaperoneInfoInitialized);
			pointerLineRenderer = GetComponentInChildren<LineRenderer>();
			teleportPointerObject = pointerLineRenderer.gameObject;
			fullTintAlpha = 0.5f;
			teleportArc = GetComponent<TeleportArc>();
			teleportArc.traceLayerMask = traceLayerMask;
			loopingAudioMaxVolume = loopingAudioSource.volume;
			playAreaPreviewCorner.SetActive(value: false);
			playAreaPreviewSide.SetActive(value: false);
			float x = invalidReticleTransform.localScale.x;
			invalidReticleMinScale *= x;
			invalidReticleMaxScale *= x;
		}

		private void Start()
		{
			teleportMarkers = UnityEngine.Object.FindObjectsOfType<TeleportMarkerBase>();
			HidePointer();
			player = Valve.VR.InteractionSystem.Player.instance;
			if (player == null)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.", this);
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else
			{
				CheckForSpawnPoint();
				Invoke("ShowTeleportHint", 5f);
			}
		}

		private void OnEnable()
		{
			chaperoneInfoInitializedAction.enabled = true;
			OnChaperoneInfoInitialized();
		}

		private void OnDisable()
		{
			chaperoneInfoInitializedAction.enabled = false;
			HidePointer();
		}

		private void CheckForSpawnPoint()
		{
			TeleportMarkerBase[] array = teleportMarkers;
			foreach (TeleportMarkerBase teleportMarkerBase in array)
			{
				TeleportPoint teleportPoint = teleportMarkerBase as TeleportPoint;
				if ((bool)teleportPoint && teleportPoint.playerSpawnPoint)
				{
					teleportingToMarker = teleportMarkerBase;
					TeleportPlayer();
					break;
				}
			}
		}

		public void HideTeleportPointer()
		{
			if (pointerHand != null)
			{
				HidePointer();
			}
		}

		private void Update()
		{
			Hand oldPointerHand = pointerHand;
			Hand hand = null;
			Hand[] hands = player.hands;
			foreach (Hand hand2 in hands)
			{
				if (visible && WasTeleportButtonReleased(hand2) && pointerHand == hand2)
				{
					TryTeleportPlayer();
				}
				if (WasTeleportButtonPressed(hand2))
				{
					hand = hand2;
				}
			}
			if ((bool)allowTeleportWhileAttached && !allowTeleportWhileAttached.teleportAllowed)
			{
				HidePointer();
			}
			else if (!visible && hand != null)
			{
				ShowPointer(hand, oldPointerHand);
			}
			else if (visible)
			{
				if (hand == null && !IsTeleportButtonDown(pointerHand))
				{
					HidePointer();
				}
				else if (hand != null)
				{
					ShowPointer(hand, oldPointerHand);
				}
			}
			if (visible)
			{
				UpdatePointer();
				if (meshFading)
				{
					UpdateTeleportColors();
				}
				if (onActivateObjectTransform.gameObject.activeSelf && Time.time - pointerShowStartTime > activateObjectTime)
				{
					onActivateObjectTransform.gameObject.SetActive(value: false);
				}
			}
			else if (onDeactivateObjectTransform.gameObject.activeSelf && Time.time - pointerHideStartTime > deactivateObjectTime)
			{
				onDeactivateObjectTransform.gameObject.SetActive(value: false);
			}
		}

		private void UpdatePointer()
		{
			Vector3 position = pointerStartTransform.position;
			Vector3 forward = pointerStartTransform.forward;
			bool flag = false;
			bool active = false;
			Vector3 vector = player.trackingOriginTransform.position - player.feetPositionGuess;
			Vector3 velocity = forward * arcDistance;
			TeleportMarkerBase teleportMarkerBase = null;
			float num = Vector3.Dot(forward, Vector3.up);
			float num2 = Vector3.Dot(forward, player.hmdTransform.forward);
			bool flag2 = false;
			if ((num2 > 0f && num > 0.75f) || (num2 < 0f && num > 0.5f))
			{
				flag2 = true;
			}
			teleportArc.SetArcData(position, velocity, gravity: true, flag2);
			if (teleportArc.DrawArc(out var hitInfo))
			{
				flag = true;
				teleportMarkerBase = hitInfo.collider.GetComponentInParent<TeleportMarkerBase>();
			}
			if (flag2)
			{
				teleportMarkerBase = null;
			}
			HighlightSelected(teleportMarkerBase);
			Vector3 vector3;
			if (teleportMarkerBase != null)
			{
				if (teleportMarkerBase.locked)
				{
					teleportArc.SetColor(pointerLockedColor);
					pointerLineRenderer.startColor = pointerLockedColor;
					pointerLineRenderer.endColor = pointerLockedColor;
					destinationReticleTransform.gameObject.SetActive(value: false);
				}
				else
				{
					teleportArc.SetColor(pointerValidColor);
					pointerLineRenderer.startColor = pointerValidColor;
					pointerLineRenderer.endColor = pointerValidColor;
					destinationReticleTransform.gameObject.SetActive(teleportMarkerBase.showReticle);
				}
				offsetReticleTransform.gameObject.SetActive(value: true);
				invalidReticleTransform.gameObject.SetActive(value: false);
				pointedAtTeleportMarker = teleportMarkerBase;
				pointedAtPosition = hitInfo.point;
				if (showPlayAreaMarker)
				{
					TeleportArea teleportArea = pointedAtTeleportMarker as TeleportArea;
					if (teleportArea != null && !teleportArea.locked && playAreaPreviewTransform != null)
					{
						Vector3 vector2 = vector;
						if (!movedFeetFarEnough)
						{
							float num3 = Vector3.Distance(vector, startingFeetOffset);
							if (num3 < 0.1f)
							{
								vector2 = startingFeetOffset;
							}
							else if (num3 < 0.4f)
							{
								vector2 = Vector3.Lerp(startingFeetOffset, vector, (num3 - 0.1f) / 0.3f);
							}
							else
							{
								movedFeetFarEnough = true;
							}
						}
						playAreaPreviewTransform.position = pointedAtPosition + vector2;
						active = true;
					}
				}
				vector3 = hitInfo.point;
			}
			else
			{
				destinationReticleTransform.gameObject.SetActive(value: false);
				offsetReticleTransform.gameObject.SetActive(value: false);
				teleportArc.SetColor(pointerInvalidColor);
				pointerLineRenderer.startColor = pointerInvalidColor;
				pointerLineRenderer.endColor = pointerInvalidColor;
				invalidReticleTransform.gameObject.SetActive(!flag2);
				Vector3 toDirection = hitInfo.normal;
				if (Vector3.Angle(hitInfo.normal, Vector3.up) < 15f)
				{
					toDirection = Vector3.up;
				}
				invalidReticleTargetRotation = Quaternion.FromToRotation(Vector3.up, toDirection);
				invalidReticleTransform.rotation = Quaternion.Slerp(invalidReticleTransform.rotation, invalidReticleTargetRotation, 0.1f);
				float num4 = Util.RemapNumberClamped(Vector3.Distance(hitInfo.point, player.hmdTransform.position), invalidReticleMinScaleDistance, invalidReticleMaxScaleDistance, invalidReticleMinScale, invalidReticleMaxScale);
				invalidReticleScale.x = num4;
				invalidReticleScale.y = num4;
				invalidReticleScale.z = num4;
				invalidReticleTransform.transform.localScale = invalidReticleScale;
				pointedAtTeleportMarker = null;
				vector3 = ((!flag) ? teleportArc.GetArcPositionAtTime(teleportArc.arcDuration) : hitInfo.point);
				if (debugFloor)
				{
					floorDebugSphere.gameObject.SetActive(value: false);
					floorDebugLine.gameObject.SetActive(value: false);
				}
			}
			if (playAreaPreviewTransform != null)
			{
				playAreaPreviewTransform.gameObject.SetActive(active);
			}
			if (!showOffsetReticle)
			{
				offsetReticleTransform.gameObject.SetActive(value: false);
			}
			destinationReticleTransform.position = pointedAtPosition;
			invalidReticleTransform.position = vector3;
			onActivateObjectTransform.position = vector3;
			onDeactivateObjectTransform.position = vector3;
			offsetReticleTransform.position = vector3 - vector;
			reticleAudioSource.transform.position = pointedAtPosition;
			pointerLineRenderer.SetPosition(0, position);
			pointerLineRenderer.SetPosition(1, vector3);
		}

		private void FixedUpdate()
		{
			if (visible && debugFloor && pointedAtTeleportMarker as TeleportArea != null && floorFixupMaximumTraceDistance > 0f)
			{
				floorDebugSphere.gameObject.SetActive(value: true);
				floorDebugLine.gameObject.SetActive(value: true);
				Vector3 down = Vector3.down;
				down.x = 0.01f;
				if (Physics.Raycast(pointedAtPosition + 0.05f * down, down, out var hitInfo, floorFixupMaximumTraceDistance, floorFixupTraceLayerMask))
				{
					floorDebugSphere.transform.position = hitInfo.point;
					floorDebugSphere.material.color = Color.green;
					floorDebugLine.startColor = Color.green;
					floorDebugLine.endColor = Color.green;
					floorDebugLine.SetPosition(0, pointedAtPosition);
					floorDebugLine.SetPosition(1, hitInfo.point);
				}
				else
				{
					Vector3 position = pointedAtPosition + down * floorFixupMaximumTraceDistance;
					floorDebugSphere.transform.position = position;
					floorDebugSphere.material.color = Color.red;
					floorDebugLine.startColor = Color.red;
					floorDebugLine.endColor = Color.red;
					floorDebugLine.SetPosition(0, pointedAtPosition);
					floorDebugLine.SetPosition(1, position);
				}
			}
		}

		private void OnChaperoneInfoInitialized()
		{
			ChaperoneInfo chaperoneInfo = ChaperoneInfo.instance;
			if (chaperoneInfo.initialized && chaperoneInfo.roomscale)
			{
				if (playAreaPreviewTransform == null)
				{
					playAreaPreviewTransform = new GameObject("PlayAreaPreviewTransform").transform;
					playAreaPreviewTransform.parent = base.transform;
					Util.ResetTransform(playAreaPreviewTransform);
					playAreaPreviewCorner.SetActive(value: true);
					playAreaPreviewCorners = new Transform[4];
					playAreaPreviewCorners[0] = playAreaPreviewCorner.transform;
					playAreaPreviewCorners[1] = UnityEngine.Object.Instantiate(playAreaPreviewCorners[0]);
					playAreaPreviewCorners[2] = UnityEngine.Object.Instantiate(playAreaPreviewCorners[0]);
					playAreaPreviewCorners[3] = UnityEngine.Object.Instantiate(playAreaPreviewCorners[0]);
					playAreaPreviewCorners[0].transform.parent = playAreaPreviewTransform;
					playAreaPreviewCorners[1].transform.parent = playAreaPreviewTransform;
					playAreaPreviewCorners[2].transform.parent = playAreaPreviewTransform;
					playAreaPreviewCorners[3].transform.parent = playAreaPreviewTransform;
					playAreaPreviewSide.SetActive(value: true);
					playAreaPreviewSides = new Transform[4];
					playAreaPreviewSides[0] = playAreaPreviewSide.transform;
					playAreaPreviewSides[1] = UnityEngine.Object.Instantiate(playAreaPreviewSides[0]);
					playAreaPreviewSides[2] = UnityEngine.Object.Instantiate(playAreaPreviewSides[0]);
					playAreaPreviewSides[3] = UnityEngine.Object.Instantiate(playAreaPreviewSides[0]);
					playAreaPreviewSides[0].transform.parent = playAreaPreviewTransform;
					playAreaPreviewSides[1].transform.parent = playAreaPreviewTransform;
					playAreaPreviewSides[2].transform.parent = playAreaPreviewTransform;
					playAreaPreviewSides[3].transform.parent = playAreaPreviewTransform;
				}
				float playAreaSizeX = chaperoneInfo.playAreaSizeX;
				float playAreaSizeZ = chaperoneInfo.playAreaSizeZ;
				playAreaPreviewSides[0].localPosition = new Vector3(0f, 0f, 0.5f * playAreaSizeZ - 0.25f);
				playAreaPreviewSides[1].localPosition = new Vector3(0f, 0f, -0.5f * playAreaSizeZ + 0.25f);
				playAreaPreviewSides[2].localPosition = new Vector3(0.5f * playAreaSizeX - 0.25f, 0f, 0f);
				playAreaPreviewSides[3].localPosition = new Vector3(-0.5f * playAreaSizeX + 0.25f, 0f, 0f);
				playAreaPreviewSides[0].localScale = new Vector3(playAreaSizeX - 0.5f, 1f, 1f);
				playAreaPreviewSides[1].localScale = new Vector3(playAreaSizeX - 0.5f, 1f, 1f);
				playAreaPreviewSides[2].localScale = new Vector3(playAreaSizeZ - 0.5f, 1f, 1f);
				playAreaPreviewSides[3].localScale = new Vector3(playAreaSizeZ - 0.5f, 1f, 1f);
				playAreaPreviewSides[0].localRotation = Quaternion.Euler(0f, 0f, 0f);
				playAreaPreviewSides[1].localRotation = Quaternion.Euler(0f, 180f, 0f);
				playAreaPreviewSides[2].localRotation = Quaternion.Euler(0f, 90f, 0f);
				playAreaPreviewSides[3].localRotation = Quaternion.Euler(0f, 270f, 0f);
				playAreaPreviewCorners[0].localPosition = new Vector3(0.5f * playAreaSizeX - 0.25f, 0f, 0.5f * playAreaSizeZ - 0.25f);
				playAreaPreviewCorners[1].localPosition = new Vector3(0.5f * playAreaSizeX - 0.25f, 0f, -0.5f * playAreaSizeZ + 0.25f);
				playAreaPreviewCorners[2].localPosition = new Vector3(-0.5f * playAreaSizeX + 0.25f, 0f, -0.5f * playAreaSizeZ + 0.25f);
				playAreaPreviewCorners[3].localPosition = new Vector3(-0.5f * playAreaSizeX + 0.25f, 0f, 0.5f * playAreaSizeZ - 0.25f);
				playAreaPreviewCorners[0].localRotation = Quaternion.Euler(0f, 0f, 0f);
				playAreaPreviewCorners[1].localRotation = Quaternion.Euler(0f, 90f, 0f);
				playAreaPreviewCorners[2].localRotation = Quaternion.Euler(0f, 180f, 0f);
				playAreaPreviewCorners[3].localRotation = Quaternion.Euler(0f, 270f, 0f);
				playAreaPreviewTransform.gameObject.SetActive(value: false);
			}
		}

		private void HidePointer()
		{
			if (visible)
			{
				pointerHideStartTime = Time.time;
			}
			visible = false;
			if ((bool)pointerHand)
			{
				if (ShouldOverrideHoverLock())
				{
					if (originalHoverLockState)
					{
						pointerHand.HoverLock(originalHoveringInteractable);
					}
					else
					{
						pointerHand.HoverUnlock(null);
					}
				}
				loopingAudioSource.Stop();
				PlayAudioClip(pointerAudioSource, pointerStopSound);
			}
			teleportPointerObject.SetActive(value: false);
			teleportArc.Hide();
			TeleportMarkerBase[] array = teleportMarkers;
			foreach (TeleportMarkerBase teleportMarkerBase in array)
			{
				if (teleportMarkerBase != null && teleportMarkerBase.markerActive && teleportMarkerBase.gameObject != null)
				{
					teleportMarkerBase.gameObject.SetActive(value: false);
				}
			}
			destinationReticleTransform.gameObject.SetActive(value: false);
			invalidReticleTransform.gameObject.SetActive(value: false);
			offsetReticleTransform.gameObject.SetActive(value: false);
			if (playAreaPreviewTransform != null)
			{
				playAreaPreviewTransform.gameObject.SetActive(value: false);
			}
			if (onActivateObjectTransform.gameObject.activeSelf)
			{
				onActivateObjectTransform.gameObject.SetActive(value: false);
			}
			onDeactivateObjectTransform.gameObject.SetActive(value: true);
			pointerHand = null;
		}

		private void ShowPointer(Hand newPointerHand, Hand oldPointerHand)
		{
			if (!visible)
			{
				pointedAtTeleportMarker = null;
				pointerShowStartTime = Time.time;
				visible = true;
				meshFading = true;
				teleportPointerObject.SetActive(value: false);
				teleportArc.Show();
				TeleportMarkerBase[] array = teleportMarkers;
				foreach (TeleportMarkerBase teleportMarkerBase in array)
				{
					if (teleportMarkerBase.markerActive && teleportMarkerBase.ShouldActivate(player.feetPositionGuess))
					{
						teleportMarkerBase.gameObject.SetActive(value: true);
						teleportMarkerBase.Highlight(highlight: false);
					}
				}
				startingFeetOffset = player.trackingOriginTransform.position - player.feetPositionGuess;
				movedFeetFarEnough = false;
				if (onDeactivateObjectTransform.gameObject.activeSelf)
				{
					onDeactivateObjectTransform.gameObject.SetActive(value: false);
				}
				onActivateObjectTransform.gameObject.SetActive(value: true);
				loopingAudioSource.clip = pointerLoopSound;
				loopingAudioSource.loop = true;
				loopingAudioSource.Play();
				loopingAudioSource.volume = 0f;
			}
			if ((bool)oldPointerHand && ShouldOverrideHoverLock())
			{
				if (originalHoverLockState)
				{
					oldPointerHand.HoverLock(originalHoveringInteractable);
				}
				else
				{
					oldPointerHand.HoverUnlock(null);
				}
			}
			pointerHand = newPointerHand;
			if (visible && oldPointerHand != pointerHand)
			{
				PlayAudioClip(pointerAudioSource, pointerStartSound);
			}
			if ((bool)pointerHand)
			{
				pointerStartTransform = GetPointerStartTransform(pointerHand);
				if (pointerHand.currentAttachedObject != null)
				{
					allowTeleportWhileAttached = pointerHand.currentAttachedObject.GetComponent<AllowTeleportWhileAttachedToHand>();
				}
				originalHoverLockState = pointerHand.hoverLocked;
				originalHoveringInteractable = pointerHand.hoveringInteractable;
				if (ShouldOverrideHoverLock())
				{
					pointerHand.HoverLock(null);
				}
				pointerAudioSource.transform.SetParent(pointerStartTransform);
				pointerAudioSource.transform.localPosition = Vector3.zero;
				loopingAudioSource.transform.SetParent(pointerStartTransform);
				loopingAudioSource.transform.localPosition = Vector3.zero;
			}
		}

		private void UpdateTeleportColors()
		{
			float num = Time.time - pointerShowStartTime;
			if (num > meshFadeTime)
			{
				meshAlphaPercent = 1f;
				meshFading = false;
			}
			else
			{
				meshAlphaPercent = Mathf.Lerp(0f, 1f, num / meshFadeTime);
			}
			TeleportMarkerBase[] array = teleportMarkers;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetAlpha(fullTintAlpha * meshAlphaPercent, meshAlphaPercent);
			}
		}

		private void PlayAudioClip(AudioSource source, AudioClip clip)
		{
			source.clip = clip;
			source.Play();
		}

		private void PlayPointerHaptic(bool validLocation)
		{
			if (pointerHand != null)
			{
				if (validLocation)
				{
					pointerHand.TriggerHapticPulse(800);
				}
				else
				{
					pointerHand.TriggerHapticPulse(100);
				}
			}
		}

		private void TryTeleportPlayer()
		{
			if (visible && !teleporting && pointedAtTeleportMarker != null && !pointedAtTeleportMarker.locked)
			{
				teleportingToMarker = pointedAtTeleportMarker;
				InitiateTeleportFade();
				CancelTeleportHint();
			}
		}

		private void InitiateTeleportFade()
		{
			teleporting = true;
			currentFadeTime = teleportFadeTime;
			TeleportPoint teleportPoint = teleportingToMarker as TeleportPoint;
			if (teleportPoint != null && teleportPoint.teleportType == TeleportPoint.TeleportPointType.SwitchToNewScene)
			{
				currentFadeTime *= 3f;
				ChangeScene.Send(currentFadeTime);
			}
			SteamVR_Fade.Start(Color.clear, 0f);
			SteamVR_Fade.Start(Color.black, currentFadeTime);
			headAudioSource.transform.SetParent(player.hmdTransform);
			headAudioSource.transform.localPosition = Vector3.zero;
			PlayAudioClip(headAudioSource, teleportSound);
			Invoke("TeleportPlayer", currentFadeTime);
		}

		private void TeleportPlayer()
		{
			teleporting = false;
			PlayerPre.Send(pointedAtTeleportMarker);
			SteamVR_Fade.Start(Color.clear, currentFadeTime);
			TeleportPoint teleportPoint = teleportingToMarker as TeleportPoint;
			Vector3 vector = pointedAtPosition;
			if (teleportPoint != null)
			{
				vector = teleportPoint.transform.position;
				if (teleportPoint.teleportType == TeleportPoint.TeleportPointType.SwitchToNewScene)
				{
					teleportPoint.TeleportToScene();
					return;
				}
			}
			if (teleportingToMarker as TeleportArea != null && floorFixupMaximumTraceDistance > 0f && Physics.Raycast(vector + 0.05f * Vector3.down, Vector3.down, out var hitInfo, floorFixupMaximumTraceDistance, floorFixupTraceLayerMask))
			{
				vector = hitInfo.point;
			}
			if (teleportingToMarker.ShouldMovePlayer())
			{
				Vector3 vector2 = player.trackingOriginTransform.position - player.feetPositionGuess;
				player.trackingOriginTransform.position = vector + vector2;
				if (player.leftHand.currentAttachedObjectInfo.HasValue)
				{
					player.leftHand.ResetAttachedTransform(player.leftHand.currentAttachedObjectInfo.Value);
				}
				if (player.rightHand.currentAttachedObjectInfo.HasValue)
				{
					player.rightHand.ResetAttachedTransform(player.rightHand.currentAttachedObjectInfo.Value);
				}
			}
			else
			{
				teleportingToMarker.TeleportPlayer(pointedAtPosition);
			}
			Player.Send(pointedAtTeleportMarker);
		}

		private void HighlightSelected(TeleportMarkerBase hitTeleportMarker)
		{
			if (pointedAtTeleportMarker != hitTeleportMarker)
			{
				if (pointedAtTeleportMarker != null)
				{
					pointedAtTeleportMarker.Highlight(highlight: false);
				}
				if (hitTeleportMarker != null)
				{
					hitTeleportMarker.Highlight(highlight: true);
					prevPointedAtPosition = pointedAtPosition;
					PlayPointerHaptic(!hitTeleportMarker.locked);
					PlayAudioClip(reticleAudioSource, goodHighlightSound);
					loopingAudioSource.volume = loopingAudioMaxVolume;
				}
				else if (pointedAtTeleportMarker != null)
				{
					PlayAudioClip(reticleAudioSource, badHighlightSound);
					loopingAudioSource.volume = 0f;
				}
			}
			else if (hitTeleportMarker != null && Vector3.Distance(prevPointedAtPosition, pointedAtPosition) > 1f)
			{
				prevPointedAtPosition = pointedAtPosition;
				PlayPointerHaptic(!hitTeleportMarker.locked);
			}
		}

		public void ShowTeleportHint()
		{
			CancelTeleportHint();
			hintCoroutine = StartCoroutine(TeleportHintCoroutine());
		}

		public void CancelTeleportHint()
		{
			if (hintCoroutine != null)
			{
				ControllerButtonHints.HideTextHint(player.leftHand, teleportAction);
				ControllerButtonHints.HideTextHint(player.rightHand, teleportAction);
				StopCoroutine(hintCoroutine);
				hintCoroutine = null;
			}
			CancelInvoke("ShowTeleportHint");
		}

		private IEnumerator TeleportHintCoroutine()
		{
			float prevBreakTime = Time.time;
			float prevHapticPulseTime = Time.time;
			while (true)
			{
				bool pulsed = false;
				Hand[] hands = player.hands;
				foreach (Hand hand in hands)
				{
					bool flag = IsEligibleForTeleport(hand);
					bool flag2 = !string.IsNullOrEmpty(ControllerButtonHints.GetActiveHintText(hand, teleportAction));
					if (flag)
					{
						if (!flag2)
						{
							ControllerButtonHints.ShowTextHint(hand, teleportAction, "Teleport");
							prevBreakTime = Time.time;
							prevHapticPulseTime = Time.time;
						}
						if (Time.time > prevHapticPulseTime + 0.05f)
						{
							pulsed = true;
							hand.TriggerHapticPulse(500);
						}
					}
					else if (!flag && flag2)
					{
						ControllerButtonHints.HideTextHint(hand, teleportAction);
					}
				}
				if (Time.time > prevBreakTime + 3f)
				{
					yield return new WaitForSeconds(3f);
					prevBreakTime = Time.time;
				}
				if (pulsed)
				{
					prevHapticPulseTime = Time.time;
				}
				yield return null;
			}
		}

		public bool IsEligibleForTeleport(Hand hand)
		{
			if (hand == null)
			{
				return false;
			}
			if (!hand.gameObject.activeInHierarchy)
			{
				return false;
			}
			if (hand.hoveringInteractable != null)
			{
				return false;
			}
			if (hand.noSteamVRFallbackCamera == null)
			{
				if (!hand.isActive)
				{
					return false;
				}
				if (hand.currentAttachedObject != null)
				{
					AllowTeleportWhileAttachedToHand component = hand.currentAttachedObject.GetComponent<AllowTeleportWhileAttachedToHand>();
					if (component != null && component.teleportAllowed)
					{
						return true;
					}
					return false;
				}
			}
			return true;
		}

		private bool ShouldOverrideHoverLock()
		{
			if (!allowTeleportWhileAttached || allowTeleportWhileAttached.overrideHoverLock)
			{
				return true;
			}
			return false;
		}

		private bool WasTeleportButtonReleased(Hand hand)
		{
			if (IsEligibleForTeleport(hand))
			{
				if (hand.noSteamVRFallbackCamera != null)
				{
					return Input.GetKeyUp(KeyCode.T);
				}
				return teleportAction.GetStateUp(hand.handType);
			}
			return false;
		}

		private bool IsTeleportButtonDown(Hand hand)
		{
			if (IsEligibleForTeleport(hand))
			{
				if (hand.noSteamVRFallbackCamera != null)
				{
					return Input.GetKey(KeyCode.T);
				}
				return teleportAction.GetState(hand.handType);
			}
			return false;
		}

		private bool WasTeleportButtonPressed(Hand hand)
		{
			if (IsEligibleForTeleport(hand))
			{
				if (hand.noSteamVRFallbackCamera != null)
				{
					return Input.GetKeyDown(KeyCode.T);
				}
				return teleportAction.GetStateDown(hand.handType);
			}
			return false;
		}

		private Transform GetPointerStartTransform(Hand hand)
		{
			if (hand.noSteamVRFallbackCamera != null)
			{
				return hand.noSteamVRFallbackCamera.transform;
			}
			return hand.transform;
		}
	}
	public class TeleportArc : MonoBehaviour
	{
		public int segmentCount = 60;

		public float thickness = 0.01f;

		[Tooltip("The amount of time in seconds to predict the motion of the projectile.")]
		public float arcDuration = 3f;

		[Tooltip("The amount of time in seconds between each segment of the projectile.")]
		public float segmentBreak = 0.025f;

		[Tooltip("The speed at which the line segments of the arc move.")]
		public float arcSpeed = 0.2f;

		public Material material;

		[HideInInspector]
		public int traceLayerMask;

		private LineRenderer[] lineRenderers;

		private float arcTimeOffset;

		private float prevThickness;

		private int prevSegmentCount;

		private bool showArc = true;

		private Vector3 startPos;

		private Vector3 projectileVelocity;

		private bool useGravity = true;

		private Transform arcObjectsTransfrom;

		private bool arcInvalid;

		private float scale = 1f;

		private void Start()
		{
			arcTimeOffset = Time.time;
		}

		private void Update()
		{
			scale = Player.instance.transform.lossyScale.x;
			if (thickness != prevThickness || segmentCount != prevSegmentCount)
			{
				CreateLineRendererObjects();
				prevThickness = thickness;
				prevSegmentCount = segmentCount;
			}
		}

		private void CreateLineRendererObjects()
		{
			if (arcObjectsTransfrom != null)
			{
				UnityEngine.Object.Destroy(arcObjectsTransfrom.gameObject);
			}
			GameObject gameObject = new GameObject("ArcObjects");
			arcObjectsTransfrom = gameObject.transform;
			arcObjectsTransfrom.SetParent(base.transform);
			lineRenderers = new LineRenderer[segmentCount];
			for (int i = 0; i < segmentCount; i++)
			{
				GameObject gameObject2 = new GameObject("LineRenderer_" + i);
				gameObject2.transform.SetParent(arcObjectsTransfrom);
				lineRenderers[i] = gameObject2.AddComponent<LineRenderer>();
				lineRenderers[i].receiveShadows = false;
				lineRenderers[i].reflectionProbeUsage = ReflectionProbeUsage.Off;
				lineRenderers[i].lightProbeUsage = LightProbeUsage.Off;
				lineRenderers[i].shadowCastingMode = ShadowCastingMode.Off;
				lineRenderers[i].material = material;
				lineRenderers[i].startWidth = thickness * scale;
				lineRenderers[i].endWidth = thickness * scale;
				lineRenderers[i].enabled = false;
			}
		}

		public void SetArcData(Vector3 position, Vector3 velocity, bool gravity, bool pointerAtBadAngle)
		{
			startPos = position;
			projectileVelocity = velocity;
			useGravity = gravity;
			if (arcInvalid && !pointerAtBadAngle)
			{
				arcTimeOffset = Time.time;
			}
			arcInvalid = pointerAtBadAngle;
		}

		public void Show()
		{
			showArc = true;
			if (lineRenderers == null)
			{
				CreateLineRendererObjects();
			}
		}

		public void Hide()
		{
			if (showArc)
			{
				HideLineSegments(0, segmentCount);
			}
			showArc = false;
		}

		public bool DrawArc(out RaycastHit hitInfo)
		{
			float num = arcDuration / (float)segmentCount;
			float num2 = (Time.time - arcTimeOffset) * arcSpeed;
			if (num2 > num + segmentBreak)
			{
				arcTimeOffset = Time.time;
				num2 = 0f;
			}
			float num3 = num2;
			float num4 = FindProjectileCollision(out hitInfo);
			if (arcInvalid)
			{
				lineRenderers[0].enabled = true;
				lineRenderers[0].SetPosition(0, GetArcPositionAtTime(0f));
				lineRenderers[0].SetPosition(1, GetArcPositionAtTime((num4 < num) ? num4 : num));
				HideLineSegments(1, segmentCount);
			}
			else
			{
				int num5 = 0;
				if (num3 > segmentBreak)
				{
					float num6 = num2 - segmentBreak;
					if (num4 < num6)
					{
						num6 = num4;
					}
					DrawArcSegment(0, 0f, num6);
					num5 = 1;
				}
				bool flag = false;
				int num7 = 0;
				if (num3 < num4)
				{
					for (num7 = num5; num7 < segmentCount; num7++)
					{
						float num8 = num3 + num;
						if (num8 >= arcDuration)
						{
							num8 = arcDuration;
							flag = true;
						}
						if (num8 >= num4)
						{
							num8 = num4;
							flag = true;
						}
						DrawArcSegment(num7, num3, num8);
						num3 += num + segmentBreak;
						if (flag || num3 >= arcDuration || num3 >= num4)
						{
							break;
						}
					}
				}
				else
				{
					num7--;
				}
				HideLineSegments(num7 + 1, segmentCount);
			}
			return num4 != float.MaxValue;
		}

		private void DrawArcSegment(int index, float startTime, float endTime)
		{
			lineRenderers[index].enabled = true;
			lineRenderers[index].SetPosition(0, GetArcPositionAtTime(startTime));
			lineRenderers[index].SetPosition(1, GetArcPositionAtTime(endTime));
		}

		public void SetColor(Color color)
		{
			for (int i = 0; i < segmentCount; i++)
			{
				lineRenderers[i].startColor = color;
				lineRenderers[i].endColor = color;
			}
		}

		private float FindProjectileCollision(out RaycastHit hitInfo)
		{
			float num = arcDuration / (float)segmentCount;
			float num2 = 0f;
			hitInfo = default(RaycastHit);
			Vector3 vector = GetArcPositionAtTime(num2);
			for (int i = 0; i < segmentCount; i++)
			{
				float num3 = num2 + num;
				Vector3 arcPositionAtTime = GetArcPositionAtTime(num3);
				if (Physics.Linecast(vector, arcPositionAtTime, out hitInfo, traceLayerMask) && hitInfo.collider.GetComponent<IgnoreTeleportTrace>() == null)
				{
					Util.DrawCross(hitInfo.point, Color.red, 0.5f);
					float num4 = Vector3.Distance(vector, arcPositionAtTime);
					return num2 + num * (hitInfo.distance / num4);
				}
				num2 = num3;
				vector = arcPositionAtTime;
			}
			return float.MaxValue;
		}

		public Vector3 GetArcPositionAtTime(float time)
		{
			Vector3 vector = (useGravity ? Physics.gravity : Vector3.zero);
			return startPos + (projectileVelocity * time + 0.5f * time * time * vector) * scale;
		}

		private void HideLineSegments(int startSegment, int endSegment)
		{
			if (lineRenderers != null)
			{
				for (int i = startSegment; i < endSegment; i++)
				{
					lineRenderers[i].enabled = false;
				}
			}
		}
	}
	public class TeleportArea : TeleportMarkerBase
	{
		private MeshRenderer areaMesh;

		private int tintColorId;

		private Color visibleTintColor = Color.clear;

		private Color highlightedTintColor = Color.clear;

		private Color lockedTintColor = Color.clear;

		private bool highlighted;

		public Bounds meshBounds { get; private set; }

		public void Awake()
		{
			areaMesh = GetComponent<MeshRenderer>();
			tintColorId = Shader.PropertyToID("_BaseColor");
			CalculateBounds();
		}

		public void Start()
		{
			visibleTintColor = Teleport.instance.areaVisibleMaterial.GetColor(tintColorId);
			highlightedTintColor = Teleport.instance.areaHighlightedMaterial.GetColor(tintColorId);
			lockedTintColor = Teleport.instance.areaLockedMaterial.GetColor(tintColorId);
		}

		public override bool ShouldActivate(Vector3 playerPosition)
		{
			return true;
		}

		public override bool ShouldMovePlayer()
		{
			return true;
		}

		public override void Highlight(bool highlight)
		{
			if (!locked)
			{
				highlighted = highlight;
				if (highlight)
				{
					areaMesh.material = Teleport.instance.areaHighlightedMaterial;
				}
				else
				{
					areaMesh.material = Teleport.instance.areaVisibleMaterial;
				}
			}
		}

		public override void SetAlpha(float tintAlpha, float alphaPercent)
		{
			Color tintColor = GetTintColor();
			tintColor.a *= alphaPercent;
			areaMesh.material.SetColor(tintColorId, tintColor);
		}

		public override void UpdateVisuals()
		{
			if (locked)
			{
				areaMesh.material = Teleport.instance.areaLockedMaterial;
			}
			else
			{
				areaMesh.material = Teleport.instance.areaVisibleMaterial;
			}
		}

		public void UpdateVisualsInEditor()
		{
			if (!(Teleport.instance == null))
			{
				areaMesh = GetComponent<MeshRenderer>();
				if (locked)
				{
					areaMesh.sharedMaterial = Teleport.instance.areaLockedMaterial;
				}
				else
				{
					areaMesh.sharedMaterial = Teleport.instance.areaVisibleMaterial;
				}
			}
		}

		private bool CalculateBounds()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			if (component == null)
			{
				return false;
			}
			Mesh sharedMesh = component.sharedMesh;
			if (sharedMesh == null)
			{
				return false;
			}
			meshBounds = sharedMesh.bounds;
			return true;
		}

		private Color GetTintColor()
		{
			if (locked)
			{
				return lockedTintColor;
			}
			if (highlighted)
			{
				return highlightedTintColor;
			}
			return visibleTintColor;
		}
	}
	public abstract class TeleportMarkerBase : MonoBehaviour
	{
		public bool locked;

		public bool markerActive = true;

		public virtual bool showReticle => true;

		public void SetLocked(bool locked)
		{
			this.locked = locked;
			UpdateVisuals();
		}

		public virtual void TeleportPlayer(Vector3 pointedAtPosition)
		{
		}

		public abstract void UpdateVisuals();

		public abstract void Highlight(bool highlight);

		public abstract void SetAlpha(float tintAlpha, float alphaPercent);

		public abstract bool ShouldActivate(Vector3 playerPosition);

		public abstract bool ShouldMovePlayer();
	}
	public class TeleportPoint : TeleportMarkerBase
	{
		public enum TeleportPointType
		{
			MoveToLocation,
			SwitchToNewScene
		}

		public TeleportPointType teleportType;

		public string title;

		public string switchToScene;

		public Color titleVisibleColor;

		public Color titleHighlightedColor;

		public Color titleLockedColor;

		public bool playerSpawnPoint;

		private bool gotReleventComponents;

		private MeshRenderer markerMesh;

		private MeshRenderer switchSceneIcon;

		private MeshRenderer moveLocationIcon;

		private MeshRenderer lockedIcon;

		private MeshRenderer pointIcon;

		private Transform lookAtJointTransform;

		private Animation animation;

		private Text titleText;

		private Player player;

		private Vector3 lookAtPosition = Vector3.zero;

		private int tintColorID;

		private Color tintColor = Color.clear;

		private Color titleColor = Color.clear;

		private float fullTitleAlpha;

		private const string switchSceneAnimation = "switch_scenes_idle";

		private const string moveLocationAnimation = "move_location_idle";

		private const string lockedAnimation = "locked_idle";

		public override bool showReticle => false;

		private void Awake()
		{
			GetRelevantComponents();
			animation = GetComponent<Animation>();
			tintColorID = Shader.PropertyToID("_BaseColor");
			moveLocationIcon.gameObject.SetActive(value: false);
			switchSceneIcon.gameObject.SetActive(value: false);
			lockedIcon.gameObject.SetActive(value: false);
			UpdateVisuals();
		}

		private void Start()
		{
			player = Player.instance;
		}

		private void Update()
		{
			if (Application.isPlaying)
			{
				lookAtPosition.x = player.hmdTransform.position.x;
				lookAtPosition.y = lookAtJointTransform.position.y;
				lookAtPosition.z = player.hmdTransform.position.z;
				lookAtJointTransform.LookAt(lookAtPosition);
			}
		}

		public override bool ShouldActivate(Vector3 playerPosition)
		{
			return Vector3.Distance(base.transform.position, playerPosition) > 1f;
		}

		public override bool ShouldMovePlayer()
		{
			return true;
		}

		public override void Highlight(bool highlight)
		{
			if (!locked)
			{
				if (highlight)
				{
					SetMeshMaterials(Teleport.instance.pointHighlightedMaterial, titleHighlightedColor);
				}
				else
				{
					SetMeshMaterials(Teleport.instance.pointVisibleMaterial, titleVisibleColor);
				}
			}
			if (highlight)
			{
				pointIcon.gameObject.SetActive(value: true);
				animation.Play();
			}
			else
			{
				pointIcon.gameObject.SetActive(value: false);
				animation.Stop();
			}
		}

		public override void UpdateVisuals()
		{
			if (!gotReleventComponents)
			{
				return;
			}
			if (locked)
			{
				SetMeshMaterials(Teleport.instance.pointLockedMaterial, titleLockedColor);
				pointIcon = lockedIcon;
				animation.clip = animation.GetClip("locked_idle");
			}
			else
			{
				SetMeshMaterials(Teleport.instance.pointVisibleMaterial, titleVisibleColor);
				switch (teleportType)
				{
				case TeleportPointType.MoveToLocation:
					pointIcon = moveLocationIcon;
					animation.clip = animation.GetClip("move_location_idle");
					break;
				case TeleportPointType.SwitchToNewScene:
					pointIcon = switchSceneIcon;
					animation.clip = animation.GetClip("switch_scenes_idle");
					break;
				}
			}
			titleText.text = title;
		}

		public override void SetAlpha(float tintAlpha, float alphaPercent)
		{
			tintColor = markerMesh.material.GetColor(tintColorID);
			tintColor.a = tintAlpha;
			markerMesh.material.SetColor(tintColorID, tintColor);
			switchSceneIcon.material.SetColor(tintColorID, tintColor);
			moveLocationIcon.material.SetColor(tintColorID, tintColor);
			lockedIcon.material.SetColor(tintColorID, tintColor);
			titleColor.a = fullTitleAlpha * alphaPercent;
			titleText.color = titleColor;
		}

		public void SetMeshMaterials(Material material, Color textColor)
		{
			markerMesh.material = material;
			switchSceneIcon.material = material;
			moveLocationIcon.material = material;
			lockedIcon.material = material;
			titleColor = textColor;
			fullTitleAlpha = textColor.a;
			titleText.color = titleColor;
		}

		public void TeleportToScene()
		{
			if (!string.IsNullOrEmpty(switchToScene))
			{
				UnityEngine.Debug.Log("<b>[SteamVR Interaction]</b> TeleportPoint: Hook up your level loading logic to switch to new scene: " + switchToScene, this);
			}
			else
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> TeleportPoint: Invalid scene name to switch to: " + switchToScene, this);
			}
		}

		public void GetRelevantComponents()
		{
			markerMesh = base.transform.Find("teleport_marker_mesh").GetComponent<MeshRenderer>();
			switchSceneIcon = base.transform.Find("teleport_marker_lookat_joint/teleport_marker_icons/switch_scenes_icon").GetComponent<MeshRenderer>();
			moveLocationIcon = base.transform.Find("teleport_marker_lookat_joint/teleport_marker_icons/move_location_icon").GetComponent<MeshRenderer>();
			lockedIcon = base.transform.Find("teleport_marker_lookat_joint/teleport_marker_icons/locked_icon").GetComponent<MeshRenderer>();
			lookAtJointTransform = base.transform.Find("teleport_marker_lookat_joint");
			titleText = base.transform.Find("teleport_marker_lookat_joint/teleport_marker_canvas/teleport_marker_canvas_text").GetComponent<Text>();
			gotReleventComponents = true;
		}

		public void ReleaseRelevantComponents()
		{
			markerMesh = null;
			switchSceneIcon = null;
			moveLocationIcon = null;
			lockedIcon = null;
			lookAtJointTransform = null;
			titleText = null;
		}

		public void UpdateVisualsInEditor()
		{
			if (Application.isPlaying)
			{
				return;
			}
			GetRelevantComponents();
			if (locked)
			{
				lockedIcon.gameObject.SetActive(value: true);
				moveLocationIcon.gameObject.SetActive(value: false);
				switchSceneIcon.gameObject.SetActive(value: false);
				markerMesh.sharedMaterial = Teleport.instance.pointLockedMaterial;
				lockedIcon.sharedMaterial = Teleport.instance.pointLockedMaterial;
				titleText.color = titleLockedColor;
			}
			else
			{
				lockedIcon.gameObject.SetActive(value: false);
				markerMesh.sharedMaterial = Teleport.instance.pointVisibleMaterial;
				switchSceneIcon.sharedMaterial = Teleport.instance.pointVisibleMaterial;
				moveLocationIcon.sharedMaterial = Teleport.instance.pointVisibleMaterial;
				titleText.color = titleVisibleColor;
				switch (teleportType)
				{
				case TeleportPointType.MoveToLocation:
					moveLocationIcon.gameObject.SetActive(value: true);
					switchSceneIcon.gameObject.SetActive(value: false);
					break;
				case TeleportPointType.SwitchToNewScene:
					moveLocationIcon.gameObject.SetActive(value: false);
					switchSceneIcon.gameObject.SetActive(value: true);
					break;
				}
			}
			titleText.text = title;
			ReleaseRelevantComponents();
		}
	}
	[ExecuteInEditMode]
	public class TeleportURPHelper : MonoBehaviour
	{
	}
}
namespace Valve.VR.InteractionSystem.Sample
{
	public class AmbientSound : MonoBehaviour
	{
		private AudioSource s;

		public float fadeintime;

		private float t;

		public bool fadeblack;

		private float vol;

		private void Start()
		{
			AudioListener.volume = 1f;
			s = GetComponent<AudioSource>();
			s.time = UnityEngine.Random.Range(0f, s.clip.length);
			if (fadeintime > 0f)
			{
				t = 0f;
			}
			vol = s.volume;
			SteamVR_Fade.Start(Color.black, 0f);
			SteamVR_Fade.Start(Color.clear, 7f);
		}

		private void Update()
		{
			if (fadeintime > 0f && t < 1f)
			{
				t += Time.deltaTime / fadeintime;
				s.volume = t * vol;
			}
		}
	}
	public class BuggyBuddy : MonoBehaviour
	{
		public Transform turret;

		private float turretRot;

		[Tooltip("Maximum steering angle of the wheels")]
		public float maxAngle = 30f;

		[Tooltip("Maximum Turning torque")]
		public float maxTurnTorque = 30f;

		[Tooltip("Maximum torque applied to the driving wheels")]
		public float maxTorque = 300f;

		[Tooltip("Maximum brake torque applied to the driving wheels")]
		public float brakeTorque = 30000f;

		[Tooltip("If you need the visual wheels to be attached automatically, drag the wheel shape here.")]
		public GameObject[] wheelRenders;

		[Tooltip("The vehicle's speed when the physics engine can use different amount of sub-steps (in m/s).")]
		public float criticalSpeed = 5f;

		[Tooltip("Simulation sub-steps when the speed is above critical.")]
		public int stepsBelow = 5;

		[Tooltip("Simulation sub-steps when the speed is below critical.")]
		public int stepsAbove = 1;

		private WheelCollider[] m_Wheels;

		public AudioSource au_motor;

		[HideInInspector]
		public float mvol;

		public AudioSource au_skid;

		private float svol;

		public WheelDust skidsample;

		private float skidSpeed = 3f;

		public Vector3 localGravity;

		[HideInInspector]
		public Rigidbody body;

		public float rapidfireTime;

		private float shootTimer;

		[HideInInspector]
		public Vector2 steer;

		[HideInInspector]
		public float throttle;

		[HideInInspector]
		public float handBrake;

		[HideInInspector]
		public Transform controllerReference;

		[HideInInspector]
		public float speed;

		public Transform centerOfMass;

		private void Start()
		{
			body = GetComponent<Rigidbody>();
			m_Wheels = GetComponentsInChildren<WheelCollider>();
			body.centerOfMass = body.transform.InverseTransformPoint(centerOfMass.position) * body.transform.lossyScale.x;
		}

		private void Update()
		{
			m_Wheels[0].ConfigureVehicleSubsteps(criticalSpeed, stepsBelow, stepsAbove);
			float num = maxTorque * throttle;
			if (steer.y < -0.5f)
			{
				num *= -1f;
			}
			float num2 = maxAngle * steer.x;
			speed = base.transform.InverseTransformVector(body.linearVelocity).z;
			float num3 = Mathf.Abs(speed);
			num2 /= 1f + num3 / 20f;
			float num4 = Mathf.Abs(num);
			mvol = Mathf.Lerp(mvol, Mathf.Pow(num4 / maxTorque, 0.8f) * Mathf.Lerp(0.4f, 1f, Mathf.Abs(m_Wheels[2].rpm) / 200f) * Mathf.Lerp(1f, 0.5f, handBrake), Time.deltaTime * 9f);
			au_motor.volume = Mathf.Clamp01(mvol);
			float value = Mathf.Lerp(0.8f, 1f, mvol);
			au_motor.pitch = Mathf.Clamp01(value);
			svol = Mathf.Lerp(svol, skidsample.amt / skidSpeed, Time.deltaTime * 9f);
			au_skid.volume = Mathf.Clamp01(svol);
			float value2 = Mathf.Lerp(0.9f, 1f, svol);
			au_skid.pitch = Mathf.Clamp01(value2);
			for (int i = 0; i < wheelRenders.Length; i++)
			{
				WheelCollider wheelCollider = m_Wheels[i];
				if (wheelCollider.transform.localPosition.z > 0f)
				{
					wheelCollider.steerAngle = num2;
					wheelCollider.motorTorque = num;
				}
				_ = wheelCollider.transform.localPosition.z;
				_ = 0f;
				wheelCollider.motorTorque = num;
				_ = wheelCollider.transform.localPosition.x;
				_ = 0f;
				_ = wheelCollider.transform.localPosition.x;
				_ = 0f;
				if (wheelRenders[i] != null && m_Wheels[0].enabled)
				{
					wheelCollider.GetWorldPose(out var pos, out var quat);
					Transform obj = wheelRenders[i].transform;
					obj.position = pos;
					obj.rotation = quat;
				}
			}
			steer = Vector2.Lerp(steer, Vector2.zero, Time.deltaTime * 4f);
		}

		private void FixedUpdate()
		{
			body.AddForce(localGravity * body.mass, ForceMode.Force);
		}

		public static float FindAngle(Vector3 fromVector, Vector3 toVector, Vector3 upVector)
		{
			if (toVector == Vector3.zero)
			{
				return 0f;
			}
			float num = Vector3.Angle(fromVector, toVector);
			Vector3 lhs = Vector3.Cross(fromVector, toVector);
			return num * Mathf.Sign(Vector3.Dot(lhs, upVector)) * (MathF.PI / 180f);
		}
	}
	public class BuggyController : MonoBehaviour
	{
		public Transform modelJoystick;

		public float joystickRot = 20f;

		public Transform modelTrigger;

		public float triggerRot = 20f;

		public BuggyBuddy buggy;

		public Transform buttonBrake;

		public Transform buttonReset;

		public Canvas ui_Canvas;

		public Image ui_rpm;

		public Image ui_speed;

		public RectTransform ui_steer;

		public float ui_steerangle;

		public Vector2 ui_fillAngles;

		public Transform resetToPoint;

		public SteamVR_Action_Vector2 actionSteering = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("buggy", "Steering");

		public SteamVR_Action_Single actionThrottle = SteamVR_Input.GetAction<SteamVR_Action_Single>("buggy", "Throttle");

		public SteamVR_Action_Boolean actionBrake = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("buggy", "Brake");

		public SteamVR_Action_Boolean actionReset = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("buggy", "Reset");

		private float usteer;

		private Interactable interactable;

		private Quaternion trigSRot;

		private Quaternion joySRot;

		private Coroutine resettingRoutine;

		private Vector3 initialScale;

		private float buzztimer;

		private void Start()
		{
			joySRot = modelJoystick.localRotation;
			trigSRot = modelTrigger.localRotation;
			interactable = GetComponent<Interactable>();
			StartCoroutine(DoBuzz());
			buggy.controllerReference = base.transform;
			initialScale = buggy.transform.localScale;
		}

		private void Update()
		{
			Vector2 steer = Vector2.zero;
			float num = 0f;
			float handBrake = 0f;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if ((bool)interactable.attachedToHand)
			{
				SteamVR_Input_Sources handType = interactable.attachedToHand.handType;
				steer = actionSteering.GetAxis(handType);
				num = actionThrottle.GetAxis(handType);
				flag2 = actionBrake.GetState(handType);
				flag3 = actionReset.GetState(handType);
				handBrake = (flag2 ? 1 : 0);
				flag = actionReset.GetStateDown(handType);
			}
			if (flag && resettingRoutine == null)
			{
				resettingRoutine = StartCoroutine(DoReset());
			}
			if (ui_Canvas != null)
			{
				ui_Canvas.gameObject.SetActive(interactable.attachedToHand);
				usteer = Mathf.Lerp(usteer, steer.x, Time.deltaTime * 9f);
				ui_steer.localEulerAngles = Vector3.forward * usteer * (0f - ui_steerangle);
				ui_rpm.fillAmount = Mathf.Lerp(ui_rpm.fillAmount, Mathf.Lerp(ui_fillAngles.x, ui_fillAngles.y, num), Time.deltaTime * 4f);
				float num2 = 40f;
				ui_speed.fillAmount = Mathf.Lerp(ui_fillAngles.x, ui_fillAngles.y, 1f - Mathf.Exp((0f - buggy.speed) / num2));
			}
			modelJoystick.localRotation = joySRot;
			modelJoystick.Rotate(steer.y * (0f - joystickRot), steer.x * (0f - joystickRot), 0f, Space.Self);
			modelTrigger.localRotation = trigSRot;
			modelTrigger.Rotate(num * (0f - triggerRot), 0f, 0f, Space.Self);
			buttonBrake.localScale = new Vector3(1f, 1f, flag2 ? 0.4f : 1f);
			buttonReset.localScale = new Vector3(1f, 1f, flag3 ? 0.4f : 1f);
			buggy.steer = steer;
			buggy.throttle = num;
			buggy.handBrake = handBrake;
			buggy.controllerReference = base.transform;
		}

		private IEnumerator DoReset()
		{
			float time = Time.time;
			float num = 1f;
			float endTime = time + num;
			buggy.transform.position = resetToPoint.transform.position;
			buggy.transform.rotation = resetToPoint.transform.rotation;
			buggy.transform.localScale = initialScale * 0.1f;
			while (Time.time < endTime)
			{
				buggy.transform.localScale = Vector3.Lerp(buggy.transform.localScale, initialScale, Time.deltaTime * 5f);
				yield return null;
			}
			buggy.transform.localScale = initialScale;
			resettingRoutine = null;
		}

		private IEnumerator DoBuzz()
		{
			while (true)
			{
				if (buzztimer < 1f)
				{
					buzztimer += Time.deltaTime * buggy.mvol * 70f;
					yield return null;
					continue;
				}
				buzztimer = 0f;
				if ((bool)interactable.attachedToHand)
				{
					interactable.attachedToHand.TriggerHapticPulse((ushort)Mathf.RoundToInt(300f * Mathf.Lerp(1f, 0.6f, buggy.mvol)));
				}
			}
		}
	}
	public class LockToPoint : MonoBehaviour
	{
		public Transform snapTo;

		private Rigidbody body;

		public float snapTime = 2f;

		private float dropTimer;

		private Interactable interactable;

		private void Start()
		{
			interactable = GetComponent<Interactable>();
			body = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			bool flag = false;
			if (interactable != null)
			{
				flag = interactable.attachedToHand;
			}
			if (flag)
			{
				body.isKinematic = false;
				dropTimer = -1f;
				return;
			}
			dropTimer += Time.deltaTime / (snapTime / 2f);
			body.isKinematic = dropTimer > 1f;
			if (dropTimer > 1f)
			{
				base.transform.position = snapTo.position;
				base.transform.rotation = snapTo.rotation;
				return;
			}
			float num = Mathf.Pow(35f, dropTimer);
			body.linearVelocity = Vector3.Lerp(body.linearVelocity, Vector3.zero, Time.fixedDeltaTime * 4f);
			if (body.useGravity)
			{
				body.AddForce(-Physics.gravity);
			}
			base.transform.position = Vector3.Lerp(base.transform.position, snapTo.position, Time.fixedDeltaTime * num * 3f);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, snapTo.rotation, Time.fixedDeltaTime * num * 2f);
		}
	}
	public class trackCam : MonoBehaviour
	{
		public float speed;

		public bool negative;

		private void Update()
		{
			Vector3 vector = Camera.main.transform.position - base.transform.position;
			if (negative)
			{
				vector = -vector;
			}
			if (speed == 0f)
			{
				base.transform.rotation = Quaternion.LookRotation(vector);
			}
			else
			{
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(vector), speed * Time.deltaTime);
			}
		}
	}
	public class trackObj : MonoBehaviour
	{
		public Transform target;

		public float speed;

		public bool negative;

		private void Update()
		{
			Vector3 vector = target.position - base.transform.position;
			if (negative)
			{
				vector = -vector;
			}
			if (speed == 0f)
			{
				base.transform.rotation = Quaternion.LookRotation(vector);
			}
			else
			{
				base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(vector), speed * Time.deltaTime);
			}
		}
	}
	public class WheelDust : MonoBehaviour
	{
		private WheelCollider col;

		public ParticleSystem p;

		public float EmissionMul;

		public float velocityMul = 2f;

		public float maxEmission;

		public float minSlip;

		[HideInInspector]
		public float amt;

		[HideInInspector]
		public Vector3 slip;

		private float emitTimer;

		private void Start()
		{
			col = GetComponent<WheelCollider>();
			StartCoroutine(emitter());
		}

		private void Update()
		{
			slip = Vector3.zero;
			if (col.isGrounded)
			{
				col.GetGroundHit(out var hit);
				slip += Vector3.right * hit.sidewaysSlip;
				slip += Vector3.forward * (0f - hit.forwardSlip);
			}
			amt = slip.magnitude;
		}

		private IEnumerator emitter()
		{
			while (true)
			{
				if (emitTimer < 1f)
				{
					yield return null;
					if (amt > minSlip)
					{
						emitTimer += Mathf.Clamp(EmissionMul * amt, 0.01f, maxEmission);
					}
				}
				else
				{
					emitTimer = 0f;
					DoEmit();
				}
			}
		}

		private void DoEmit()
		{
			p.transform.rotation = Quaternion.LookRotation(base.transform.TransformDirection(slip));
			ParticleSystem.MainModule main = p.main;
			main.startSpeed = velocityMul * amt;
			p.Emit(1);
		}
	}
	public class Grenade : MonoBehaviour
	{
		public GameObject explodePartPrefab;

		public int explodeCount = 10;

		public float minMagnitudeToExplode = 1f;

		private Interactable interactable;

		private void Start()
		{
			interactable = GetComponent<Interactable>();
		}

		private void OnCollisionEnter(Collision collision)
		{
			if ((!(interactable != null) || !(interactable.attachedToHand != null)) && collision.impulse.magnitude > minMagnitudeToExplode)
			{
				for (int i = 0; i < explodeCount; i++)
				{
					UnityEngine.Object.Instantiate(explodePartPrefab, base.transform.position, base.transform.rotation).GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
				}
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
	public class JoeJeff : MonoBehaviour
	{
		public float animationSpeed;

		public float jumpVelocity;

		[SerializeField]
		private float m_MovingTurnSpeed = 360f;

		[SerializeField]
		private float m_StationaryTurnSpeed = 180f;

		public float airControl;

		[Tooltip("The time it takes after landing a jump to slow down")]
		public float frictionTime = 0.2f;

		[SerializeField]
		private float footHeight = 0.1f;

		[SerializeField]
		private float footRadius = 0.03f;

		private RaycastHit footHit;

		private bool isGrounded;

		private float turnAmount;

		private float forwardAmount;

		private float groundedTime;

		private Animator animator;

		private Vector3 input;

		private bool held;

		private Rigidbody rigidbody;

		private Interactable interactable;

		public FireSource fire;

		private float jumpTimer;

		private void Start()
		{
			animator = GetComponent<Animator>();
			rigidbody = GetComponent<Rigidbody>();
			interactable = GetComponent<Interactable>();
			animator.speed = animationSpeed;
		}

		private void Update()
		{
			held = interactable.attachedToHand != null;
			jumpTimer -= Time.deltaTime;
			CheckGrounded();
			rigidbody.freezeRotation = !held;
			if (!held)
			{
				FixRotation();
			}
		}

		private void FixRotation()
		{
			Vector3 eulerAngles = base.transform.eulerAngles;
			eulerAngles.x = 0f;
			eulerAngles.z = 0f;
			Quaternion b = Quaternion.Euler(eulerAngles);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * (float)(isGrounded ? 20 : 3));
		}

		public void OnAnimatorMove()
		{
			if (!(Time.deltaTime > 0f))
			{
				return;
			}
			Vector3 vector = animator.deltaPosition / Time.deltaTime;
			vector = Vector3.ProjectOnPlane(vector, footHit.normal);
			if (isGrounded && jumpTimer < 0f)
			{
				if (groundedTime < frictionTime)
				{
					float num = Mathf.InverseLerp(0f, frictionTime, groundedTime);
					Vector3 vector2 = Vector3.Lerp(rigidbody.linearVelocity, vector, num * Time.deltaTime * 30f);
					vector.x = vector2.x;
					vector.z = vector2.z;
				}
				vector.y += -0.2f;
				rigidbody.linearVelocity = vector;
			}
			else
			{
				rigidbody.linearVelocity += input * Time.deltaTime * airControl;
			}
		}

		public void Move(Vector3 move, bool jump)
		{
			input = move;
			if (move.magnitude > 1f)
			{
				move.Normalize();
			}
			move = base.transform.InverseTransformDirection(move);
			turnAmount = Mathf.Atan2(move.x, move.z);
			forwardAmount = move.z;
			ApplyExtraTurnRotation();
			if (isGrounded)
			{
				HandleGroundedMovement(jump);
			}
			UpdateAnimator(move);
		}

		private void UpdateAnimator(Vector3 move)
		{
			animator.speed = (fire.isBurning ? (animationSpeed * 2f) : animationSpeed);
			animator.SetFloat("Forward", fire.isBurning ? 2f : forwardAmount, 0.1f, Time.deltaTime);
			animator.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
			animator.SetBool("OnGround", isGrounded);
			animator.SetBool("Holding", held);
			if (!isGrounded)
			{
				animator.SetFloat("FallSpeed", Mathf.Abs(rigidbody.linearVelocity.y));
				animator.SetFloat("Jump", rigidbody.linearVelocity.y);
			}
		}

		private void ApplyExtraTurnRotation()
		{
			float num = Mathf.Lerp(m_StationaryTurnSpeed, m_MovingTurnSpeed, forwardAmount);
			base.transform.Rotate(0f, turnAmount * num * Time.deltaTime, 0f);
		}

		private void CheckGrounded()
		{
			isGrounded = false;
			if ((jumpTimer < 0f) & !held)
			{
				isGrounded = Physics.SphereCast(new Ray(base.transform.position + Vector3.up * footHeight, Vector3.down), footRadius, out footHit, footHeight - footRadius);
				if (Vector2.Distance(new Vector2(base.transform.position.x, base.transform.position.z), new Vector2(footHit.point.x, footHit.point.z)) > footRadius / 2f)
				{
					isGrounded = false;
				}
			}
		}

		private void FixedUpdate()
		{
			groundedTime += Time.fixedDeltaTime;
			if (!isGrounded)
			{
				groundedTime = 0f;
			}
			if (isGrounded & !held)
			{
				UnityEngine.Debug.DrawLine(base.transform.position, footHit.point);
				rigidbody.position = new Vector3(rigidbody.position.x, footHit.point.y, rigidbody.position.z);
			}
		}

		private void HandleGroundedMovement(bool jump)
		{
			if (jump && isGrounded)
			{
				Jump();
			}
		}

		public void Jump()
		{
			isGrounded = false;
			jumpTimer = 0.1f;
			animator.applyRootMotion = false;
			rigidbody.position += Vector3.up * 0.03f;
			Vector3 linearVelocity = rigidbody.linearVelocity;
			linearVelocity.y = jumpVelocity;
			rigidbody.linearVelocity = linearVelocity;
		}
	}
	public class JoeJeffController : MonoBehaviour
	{
		public Transform Joystick;

		public float joyMove = 0.1f;

		public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");

		public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");

		public JoeJeff character;

		public Renderer jumpHighlight;

		private Vector3 movement;

		private bool jump;

		private float glow;

		private SteamVR_Input_Sources hand;

		private Interactable interactable;

		private void Start()
		{
			interactable = GetComponent<Interactable>();
		}

		private void Update()
		{
			if ((bool)interactable.attachedToHand)
			{
				hand = interactable.attachedToHand.handType;
				Vector2 axis = moveAction[hand].axis;
				movement = new Vector3(axis.x, 0f, axis.y);
				jump = jumpAction[hand].stateDown;
				glow = Mathf.Lerp(glow, jumpAction[hand].state ? 1.5f : 1f, Time.deltaTime * 20f);
			}
			else
			{
				movement = Vector2.zero;
				jump = false;
				glow = 0f;
			}
			Joystick.localPosition = movement * joyMove;
			float y = base.transform.eulerAngles.y;
			movement = Quaternion.AngleAxis(y, Vector3.up) * movement;
			jumpHighlight.sharedMaterial.SetColor("_EmissionColor", Color.white * glow);
			character.Move(movement * 2f, jump);
		}
	}
	public class JoeJeffGestures : MonoBehaviour
	{
		private const float openFingerAmount = 0.1f;

		private const float closedFingerAmount = 0.9f;

		private const float closedThumbAmount = 0.4f;

		private JoeJeff joeJeff;

		private bool lastPeaceSignState;

		private void Awake()
		{
			joeJeff = GetComponent<JoeJeff>();
		}

		private void Update()
		{
			if (Player.instance == null)
			{
				return;
			}
			Transform transform = Camera.main.transform;
			if (!(Vector3.Angle(transform.forward, base.transform.position - transform.position) < 90f))
			{
				return;
			}
			for (int i = 0; i < Player.instance.hands.Length; i++)
			{
				if (!(Player.instance.hands[i] != null))
				{
					continue;
				}
				SteamVR_Behaviour_Skeleton skeleton = Player.instance.hands[i].skeleton;
				if (skeleton != null)
				{
					if (skeleton.indexCurl <= 0.1f && skeleton.middleCurl <= 0.1f && skeleton.thumbCurl >= 0.4f && skeleton.ringCurl >= 0.9f && skeleton.pinkyCurl >= 0.9f)
					{
						PeaceSignRecognized(currentPeaceSignState: true);
					}
					else
					{
						PeaceSignRecognized(currentPeaceSignState: false);
					}
				}
			}
		}

		private void PeaceSignRecognized(bool currentPeaceSignState)
		{
			if (!lastPeaceSignState && currentPeaceSignState)
			{
				joeJeff.Jump();
			}
			lastPeaceSignState = currentPeaceSignState;
		}
	}
	public class ProceduralHats : MonoBehaviour
	{
		public GameObject[] hats;

		public float hatSwitchTime;

		private void Start()
		{
			SwitchToHat(0);
		}

		private void OnEnable()
		{
			StartCoroutine(HatSwitcher());
		}

		private IEnumerator HatSwitcher()
		{
			while (true)
			{
				yield return new WaitForSeconds(hatSwitchTime);
				Transform cam = Camera.main.transform;
				while (Vector3.Angle(cam.forward, base.transform.position - cam.position) < 90f)
				{
					yield return new WaitForSeconds(0.1f);
				}
				ChooseHat();
			}
		}

		private void ChooseHat()
		{
			SwitchToHat(UnityEngine.Random.Range(0, hats.Length));
		}

		private void SwitchToHat(int hat)
		{
			for (int i = 0; i < hats.Length; i++)
			{
				hats[i].SetActive(hat == i);
			}
		}
	}
	public class ButtonEffect : MonoBehaviour
	{
		public void OnButtonDown(Hand fromHand)
		{
			ColorSelf(Color.cyan);
			fromHand.TriggerHapticPulse(1000);
		}

		public void OnButtonUp(Hand fromHand)
		{
			ColorSelf(Color.white);
		}

		private void ColorSelf(Color newColor)
		{
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].material.color = newColor;
			}
		}
	}
	public class ButtonExample : MonoBehaviour
	{
		public HoverButton hoverButton;

		public GameObject prefab;

		private void Start()
		{
			hoverButton.onButtonDown.AddListener(OnButtonDown);
		}

		private void OnButtonDown(Hand hand)
		{
			StartCoroutine(DoPlant());
		}

		private IEnumerator DoPlant()
		{
			GameObject planting = UnityEngine.Object.Instantiate(prefab);
			planting.transform.position = base.transform.position;
			planting.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f);
			planting.GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
			Rigidbody rigidbody = planting.GetComponent<Rigidbody>();
			if (rigidbody != null)
			{
				rigidbody.isKinematic = true;
			}
			Vector3 initialScale = Vector3.one * 0.01f;
			Vector3 targetScale = Vector3.one * (1f + UnityEngine.Random.value * 0.25f);
			float startTime = Time.time;
			float overTime = 0.5f;
			float endTime = startTime + overTime;
			while (Time.time < endTime)
			{
				planting.transform.localScale = Vector3.Slerp(initialScale, targetScale, (Time.time - startTime) / overTime);
				yield return null;
			}
			if (rigidbody != null)
			{
				rigidbody.isKinematic = false;
			}
		}
	}
	public class ControllerHintsExample : MonoBehaviour
	{
		private Coroutine buttonHintCoroutine;

		private Coroutine textHintCoroutine;

		public void ShowButtonHints(Hand hand)
		{
			if (buttonHintCoroutine != null)
			{
				StopCoroutine(buttonHintCoroutine);
			}
			buttonHintCoroutine = StartCoroutine(TestButtonHints(hand));
		}

		public void ShowTextHints(Hand hand)
		{
			if (textHintCoroutine != null)
			{
				StopCoroutine(textHintCoroutine);
			}
			textHintCoroutine = StartCoroutine(TestTextHints(hand));
		}

		public void DisableHints()
		{
			if (buttonHintCoroutine != null)
			{
				StopCoroutine(buttonHintCoroutine);
				buttonHintCoroutine = null;
			}
			if (textHintCoroutine != null)
			{
				StopCoroutine(textHintCoroutine);
				textHintCoroutine = null;
			}
			Hand[] hands = Player.instance.hands;
			foreach (Hand hand in hands)
			{
				ControllerButtonHints.HideAllButtonHints(hand);
				ControllerButtonHints.HideAllTextHints(hand);
			}
		}

		private IEnumerator TestButtonHints(Hand hand)
		{
			ControllerButtonHints.HideAllButtonHints(hand);
			while (true)
			{
				for (int actionIndex = 0; actionIndex < SteamVR_Input.actionsIn.Length; actionIndex++)
				{
					ISteamVR_Action_In action = SteamVR_Input.actionsIn[actionIndex];
					if (action.GetActive(hand.handType))
					{
						ControllerButtonHints.ShowButtonHint(hand, action);
						yield return new WaitForSeconds(1f);
						ControllerButtonHints.HideButtonHint(hand, action);
						yield return new WaitForSeconds(0.5f);
					}
					yield return null;
				}
				ControllerButtonHints.HideAllButtonHints(hand);
				yield return new WaitForSeconds(1f);
			}
		}

		private IEnumerator TestTextHints(Hand hand)
		{
			ControllerButtonHints.HideAllTextHints(hand);
			while (true)
			{
				for (int actionIndex = 0; actionIndex < SteamVR_Input.actionsIn.Length; actionIndex++)
				{
					ISteamVR_Action_In action = SteamVR_Input.actionsIn[actionIndex];
					if (action.GetActive(hand.handType))
					{
						ControllerButtonHints.ShowTextHint(hand, action, action.GetShortName());
						yield return new WaitForSeconds(3f);
						ControllerButtonHints.HideTextHint(hand, action);
						yield return new WaitForSeconds(0.5f);
					}
					yield return null;
				}
				ControllerButtonHints.HideAllTextHints(hand);
				yield return new WaitForSeconds(3f);
			}
		}
	}
	public class CustomSkeletonHelper : MonoBehaviour
	{
		public enum MirrorType
		{
			None,
			LeftToRight,
			RightToLeft
		}

		[Serializable]
		public class Retargetable
		{
			public Transform source;

			public Transform destination;

			public Retargetable(Transform source, Transform destination)
			{
				this.source = source;
				this.destination = destination;
			}
		}

		[Serializable]
		public class Thumb
		{
			public Retargetable metacarpal;

			public Retargetable middle;

			public Retargetable distal;

			public Transform aux;

			public Thumb(Retargetable metacarpal, Retargetable middle, Retargetable distal, Transform aux)
			{
				this.metacarpal = metacarpal;
				this.middle = middle;
				this.distal = distal;
				this.aux = aux;
			}
		}

		[Serializable]
		public class Finger
		{
			public Retargetable metacarpal;

			public Retargetable proximal;

			public Retargetable middle;

			public Retargetable distal;

			public Transform aux;

			public Finger(Retargetable metacarpal, Retargetable proximal, Retargetable middle, Retargetable distal, Transform aux)
			{
				this.metacarpal = metacarpal;
				this.proximal = proximal;
				this.middle = middle;
				this.distal = distal;
				this.aux = aux;
			}
		}

		public Retargetable wrist;

		public Finger[] fingers;

		public Thumb[] thumbs;

		private void Update()
		{
			for (int i = 0; i < fingers.Length; i++)
			{
				Finger finger = fingers[i];
				finger.metacarpal.destination.rotation = finger.metacarpal.source.rotation;
				finger.proximal.destination.rotation = finger.proximal.source.rotation;
				finger.middle.destination.rotation = finger.middle.source.rotation;
				finger.distal.destination.rotation = finger.distal.source.rotation;
			}
			for (int j = 0; j < thumbs.Length; j++)
			{
				Thumb thumb = thumbs[j];
				thumb.metacarpal.destination.rotation = thumb.metacarpal.source.rotation;
				thumb.middle.destination.rotation = thumb.middle.source.rotation;
				thumb.distal.destination.rotation = thumb.distal.source.rotation;
			}
			wrist.destination.position = wrist.source.position;
			wrist.destination.rotation = wrist.source.rotation;
		}
	}
	public class FloppyHand : MonoBehaviour
	{
		[Serializable]
		public class Finger
		{
			public enum eulerAxis
			{
				X,
				Y,
				Z
			}

			public float mass;

			[Range(0f, 1f)]
			public float pos;

			public Vector3 forwardAxis;

			public SkinnedMeshRenderer renderer;

			[HideInInspector]
			public SteamVR_Action_Single squeezyAction;

			public SteamVR_Input_Sources inputSource;

			public Transform[] bones;

			public Transform referenceBone;

			public Vector2 referenceAngles;

			public eulerAxis referenceAxis;

			[HideInInspector]
			public float flexAngle;

			private Vector3[] rotation;

			private Vector3[] velocity;

			private Transform[] boneTips;

			private Vector3[] oldTipPosition;

			private Vector3[] oldTipDelta;

			private Vector3[,] inertiaSmoothing;

			private float squeezySmooth;

			private int inertiaSteps = 10;

			private float k = 400f;

			private float damping = 8f;

			private Quaternion[] startRot;

			public void ApplyForce(Vector3 worldForce)
			{
				for (int i = 0; i < startRot.Length; i++)
				{
					velocity[i] += worldForce / 50f;
				}
			}

			public void Init()
			{
				startRot = new Quaternion[bones.Length];
				rotation = new Vector3[bones.Length];
				velocity = new Vector3[bones.Length];
				oldTipPosition = new Vector3[bones.Length];
				oldTipDelta = new Vector3[bones.Length];
				boneTips = new Transform[bones.Length];
				inertiaSmoothing = new Vector3[bones.Length, inertiaSteps];
				for (int i = 0; i < bones.Length; i++)
				{
					startRot[i] = bones[i].localRotation;
					if (i < bones.Length - 1)
					{
						boneTips[i] = bones[i + 1];
					}
				}
			}

			public void UpdateFinger(float deltaTime)
			{
				if (deltaTime == 0f)
				{
					return;
				}
				float f = 0f;
				if (squeezyAction != null && squeezyAction.GetActive(inputSource))
				{
					f = squeezyAction.GetAxis(inputSource);
				}
				squeezySmooth = Mathf.Lerp(squeezySmooth, Mathf.Sqrt(f), deltaTime * 10f);
				if (renderer.sharedMesh.blendShapeCount > 0)
				{
					renderer.SetBlendShapeWeight(0, squeezySmooth * 100f);
				}
				float ang = 0f;
				if (referenceAxis == eulerAxis.X)
				{
					ang = referenceBone.localEulerAngles.x;
				}
				if (referenceAxis == eulerAxis.Y)
				{
					ang = referenceBone.localEulerAngles.y;
				}
				if (referenceAxis == eulerAxis.Z)
				{
					ang = referenceBone.localEulerAngles.z;
				}
				ang = FixAngle(ang);
				pos = Mathf.InverseLerp(referenceAngles.x, referenceAngles.y, ang);
				if (mass > 0f)
				{
					for (int i = 0; i < bones.Length; i++)
					{
						bool flag = boneTips[i] != null;
						if (flag)
						{
							Vector3 vector = (boneTips[i].localPosition - bones[i].InverseTransformPoint(oldTipPosition[i])) / deltaTime;
							Vector3 vector2 = (vector - oldTipDelta[i]) / deltaTime;
							oldTipDelta[i] = vector;
							Vector3 vector3 = vector * -2f;
							vector2 *= -2f;
							for (int num = inertiaSteps - 1; num > 0; num--)
							{
								inertiaSmoothing[i, num] = inertiaSmoothing[i, num - 1];
							}
							inertiaSmoothing[i, 0] = vector2;
							Vector3 zero = Vector3.zero;
							for (int j = 0; j < inertiaSteps; j++)
							{
								zero += inertiaSmoothing[i, j];
							}
							zero /= (float)inertiaSteps;
							zero = PowVector(zero / 20f, 3f) * 20f;
							Vector3 fromDirection = forwardAxis;
							Vector3 toDirection = forwardAxis + vector3;
							Vector3 toDirection2 = forwardAxis + zero;
							Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
							Quaternion quaternion2 = Quaternion.FromToRotation(fromDirection, toDirection2);
							velocity[i] += FixVector(quaternion.eulerAngles) * 2f * deltaTime;
							velocity[i] += FixVector(quaternion2.eulerAngles) * 50f * deltaTime;
							velocity[i] = Vector3.ClampMagnitude(velocity[i], 1000f);
						}
						Vector3 vector4 = pos * Vector3.right * (flexAngle / (float)bones.Length);
						Vector3 vector5 = (0f - k) * (rotation[i] - vector4);
						Vector3 vector6 = damping * velocity[i];
						Vector3 vector7 = (vector5 - vector6) / mass;
						velocity[i] += vector7 * deltaTime;
						rotation[i] += velocity[i] * Time.deltaTime;
						rotation[i] = Vector3.ClampMagnitude(rotation[i], 180f);
						if (flag)
						{
							oldTipPosition[i] = boneTips[i].position;
						}
					}
				}
				else
				{
					UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> finger mass is zero");
				}
			}

			public void ApplyTransforms()
			{
				for (int i = 0; i < bones.Length; i++)
				{
					bones[i].localRotation = startRot[i];
					bones[i].Rotate(rotation[i], Space.Self);
				}
			}

			private Vector3 FixVector(Vector3 ang)
			{
				return new Vector3(FixAngle(ang.x), FixAngle(ang.y), FixAngle(ang.z));
			}

			private float FixAngle(float ang)
			{
				if (ang > 180f)
				{
					ang = -360f + ang;
				}
				return ang;
			}

			private Vector3 PowVector(Vector3 vector, float power)
			{
				Vector3 vector2 = new Vector3(Mathf.Sign(vector.x), Mathf.Sign(vector.y), Mathf.Sign(vector.z));
				vector.x = Mathf.Pow(Mathf.Abs(vector.x), power) * vector2.x;
				vector.y = Mathf.Pow(Mathf.Abs(vector.y), power) * vector2.y;
				vector.z = Mathf.Pow(Mathf.Abs(vector.z), power) * vector2.z;
				return vector;
			}
		}

		protected float fingerFlexAngle = 140f;

		public SteamVR_Action_Single squeezyAction = SteamVR_Input.GetAction<SteamVR_Action_Single>("Squeeze");

		public SteamVR_Input_Sources inputSource;

		public Finger[] fingers;

		public Vector3 constforce;

		private void Start()
		{
			for (int i = 0; i < fingers.Length; i++)
			{
				fingers[i].Init();
				fingers[i].flexAngle = fingerFlexAngle;
				fingers[i].squeezyAction = squeezyAction;
				fingers[i].inputSource = inputSource;
			}
		}

		private void Update()
		{
			for (int i = 0; i < fingers.Length; i++)
			{
				fingers[i].ApplyForce(constforce);
				fingers[i].UpdateFinger(Time.deltaTime);
				fingers[i].ApplyTransforms();
			}
		}
	}
	public class FlowerPlanted : MonoBehaviour
	{
		private void Start()
		{
			Plant();
		}

		public void Plant()
		{
			StartCoroutine(DoPlant());
		}

		private IEnumerator DoPlant()
		{
			Vector3 position;
			if (Physics.Raycast(base.transform.position, Vector3.down, out var hitInfo))
			{
				position = hitInfo.point + Vector3.up * 0.05f;
			}
			else
			{
				position = base.transform.position;
				position.y = Player.instance.transform.position.y;
			}
			GameObject planting = base.gameObject;
			planting.transform.position = position;
			planting.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f);
			Color value = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
			value.a = 0.75f;
			planting.GetComponentInChildren<MeshRenderer>().material.SetColor("_BaseColor", value);
			Rigidbody rigidbody = planting.GetComponent<Rigidbody>();
			if (rigidbody != null)
			{
				rigidbody.isKinematic = true;
			}
			Vector3 initialScale = Vector3.one * 0.01f;
			Vector3 targetScale = Vector3.one * (1f + UnityEngine.Random.value * 0.25f);
			float startTime = Time.time;
			float overTime = 0.5f;
			float endTime = startTime + overTime;
			while (Time.time < endTime)
			{
				planting.transform.localScale = Vector3.Slerp(initialScale, targetScale, (Time.time - startTime) / overTime);
				yield return null;
			}
			if (rigidbody != null)
			{
				rigidbody.isKinematic = false;
			}
		}
	}
	[RequireComponent(typeof(Interactable))]
	public class InteractableExample : MonoBehaviour
	{
		private TextMesh generalText;

		private TextMesh hoveringText;

		private Vector3 oldPosition;

		private Quaternion oldRotation;

		private float attachTime;

		private Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.TurnOnKinematic;

		private Interactable interactable;

		private bool lastHovering;

		private void Awake()
		{
			TextMesh[] componentsInChildren = GetComponentsInChildren<TextMesh>();
			generalText = componentsInChildren[0];
			hoveringText = componentsInChildren[1];
			generalText.text = "No Hand Hovering";
			hoveringText.text = "Hovering: False";
			interactable = GetComponent<Interactable>();
		}

		private void OnHandHoverBegin(Hand hand)
		{
			generalText.text = "Hovering hand: " + hand.name;
		}

		private void OnHandHoverEnd(Hand hand)
		{
			generalText.text = "No Hand Hovering";
		}

		private void HandHoverUpdate(Hand hand)
		{
			GrabTypes grabStarting = hand.GetGrabStarting();
			bool flag = hand.IsGrabEnding(base.gameObject);
			if (interactable.attachedToHand == null && grabStarting != GrabTypes.None)
			{
				oldPosition = base.transform.position;
				oldRotation = base.transform.rotation;
				hand.HoverLock(interactable);
				hand.AttachObject(base.gameObject, grabStarting, attachmentFlags);
			}
			else if (flag)
			{
				hand.DetachObject(base.gameObject);
				hand.HoverUnlock(interactable);
				base.transform.position = oldPosition;
				base.transform.rotation = oldRotation;
			}
		}

		private void OnAttachedToHand(Hand hand)
		{
			generalText.text = $"Attached: {hand.name}";
			attachTime = Time.time;
		}

		private void OnDetachedFromHand(Hand hand)
		{
			generalText.text = $"Detached: {hand.name}";
		}

		private void HandAttachedUpdate(Hand hand)
		{
			generalText.text = $"Attached: {hand.name} :: Time: {Time.time - attachTime:F2}";
		}

		private void Update()
		{
			if (interactable.isHovering != lastHovering)
			{
				hoveringText.text = $"Hovering: {interactable.isHovering}";
				lastHovering = interactable.isHovering;
			}
		}

		private void OnHandFocusAcquired(Hand hand)
		{
		}

		private void OnHandFocusLost(Hand hand)
		{
		}
	}
	public class Planting : MonoBehaviour
	{
		public SteamVR_Action_Boolean plantAction;

		public Hand hand;

		public GameObject prefabToPlant;

		private void OnEnable()
		{
			if (hand == null)
			{
				hand = GetComponent<Hand>();
			}
			if (plantAction == null)
			{
				UnityEngine.Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned", this);
			}
			else
			{
				plantAction.AddOnChangeListener(OnPlantActionChange, hand.handType);
			}
		}

		private void OnDisable()
		{
			if (plantAction != null)
			{
				plantAction.RemoveOnChangeListener(OnPlantActionChange, hand.handType);
			}
		}

		private void OnPlantActionChange(SteamVR_Action_Boolean actionIn, SteamVR_Input_Sources inputSource, bool newValue)
		{
			if (newValue)
			{
				Plant();
			}
		}

		public void Plant()
		{
			StartCoroutine(DoPlant());
		}

		private IEnumerator DoPlant()
		{
			Vector3 position;
			if (Physics.Raycast(hand.transform.position, Vector3.down, out var hitInfo))
			{
				position = hitInfo.point + Vector3.up * 0.05f;
			}
			else
			{
				position = hand.transform.position;
				position.y = Player.instance.transform.position.y;
			}
			GameObject planting = UnityEngine.Object.Instantiate(prefabToPlant);
			planting.transform.position = position;
			planting.transform.rotation = Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f);
			planting.GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
			Rigidbody rigidbody = planting.GetComponent<Rigidbody>();
			if (rigidbody != null)
			{
				rigidbody.isKinematic = true;
			}
			Vector3 initialScale = Vector3.one * 0.01f;
			Vector3 targetScale = Vector3.one * (1f + UnityEngine.Random.value * 0.25f);
			float startTime = Time.time;
			float overTime = 0.5f;
			float endTime = startTime + overTime;
			while (Time.time < endTime)
			{
				planting.transform.localScale = Vector3.Slerp(initialScale, targetScale, (Time.time - startTime) / overTime);
				yield return null;
			}
			if (rigidbody != null)
			{
				rigidbody.isKinematic = false;
			}
		}
	}
	public class RenderModelChangerUI : UIElement
	{
		public GameObject leftPrefab;

		public GameObject rightPrefab;

		protected SkeletonUIOptions ui;

		protected override void Awake()
		{
			base.Awake();
			ui = GetComponentInParent<SkeletonUIOptions>();
		}

		protected override void OnButtonClick()
		{
			base.OnButtonClick();
			if (ui != null)
			{
				ui.SetRenderModel(this);
			}
		}
	}
	public class SkeletonUIOptions : MonoBehaviour
	{
		public void AnimateHandWithController()
		{
			for (int i = 0; i < Player.instance.hands.Length; i++)
			{
				Hand hand = Player.instance.hands[i];
				if (hand != null)
				{
					hand.SetSkeletonRangeOfMotion(EVRSkeletalMotionRange.WithController);
				}
			}
		}

		public void AnimateHandWithoutController()
		{
			for (int i = 0; i < Player.instance.hands.Length; i++)
			{
				Hand hand = Player.instance.hands[i];
				if (hand != null)
				{
					hand.SetSkeletonRangeOfMotion(EVRSkeletalMotionRange.WithoutController);
				}
			}
		}

		public void ShowController()
		{
			for (int i = 0; i < Player.instance.hands.Length; i++)
			{
				Hand hand = Player.instance.hands[i];
				if (hand != null)
				{
					hand.ShowController(permanent: true);
				}
			}
		}

		public void SetRenderModel(RenderModelChangerUI prefabs)
		{
			for (int i = 0; i < Player.instance.hands.Length; i++)
			{
				Hand hand = Player.instance.hands[i];
				if (hand != null)
				{
					if (hand.handType == SteamVR_Input_Sources.RightHand)
					{
						hand.SetRenderModel(prefabs.rightPrefab);
					}
					if (hand.handType == SteamVR_Input_Sources.LeftHand)
					{
						hand.SetRenderModel(prefabs.leftPrefab);
					}
				}
			}
		}

		public void HideController()
		{
			for (int i = 0; i < Player.instance.hands.Length; i++)
			{
				Hand hand = Player.instance.hands[i];
				if (hand != null)
				{
					hand.HideController(permanent: true);
				}
			}
		}
	}
	public class TargetHitEffect : MonoBehaviour
	{
		public Collider targetCollider;

		public GameObject spawnObjectOnCollision;

		public bool colorSpawnedObject = true;

		public bool destroyOnTargetCollision = true;

		private void OnCollisionEnter(Collision collision)
		{
			if (!(collision.collider == targetCollider))
			{
				return;
			}
			ContactPoint contactPoint = collision.contacts[0];
			float num = 1f;
			Ray ray = new Ray(contactPoint.point - -contactPoint.normal * num, -contactPoint.normal);
			if (collision.collider.Raycast(ray, out var hitInfo, 2f) && colorSpawnedObject)
			{
				Color pixelBilinear = ((Texture2D)collision.gameObject.GetComponent<Renderer>().material.mainTexture).GetPixelBilinear(hitInfo.textureCoord.x, hitInfo.textureCoord.y);
				pixelBilinear = ((pixelBilinear.r > 0.7f && pixelBilinear.g > 0.7f && pixelBilinear.b < 0.7f) ? Color.yellow : ((Mathf.Max(pixelBilinear.r, pixelBilinear.g, pixelBilinear.b) == pixelBilinear.r) ? Color.red : ((Mathf.Max(pixelBilinear.r, pixelBilinear.g, pixelBilinear.b) != pixelBilinear.g) ? Color.yellow : Color.green)));
				pixelBilinear *= 15f;
				GameObject obj = UnityEngine.Object.Instantiate(spawnObjectOnCollision);
				obj.transform.position = contactPoint.point;
				obj.transform.forward = ray.direction;
				Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
				foreach (Renderer renderer in componentsInChildren)
				{
					renderer.material.color = pixelBilinear;
					if (renderer.material.HasProperty("_EmissionColor"))
					{
						renderer.material.SetColor("_EmissionColor", pixelBilinear);
					}
				}
			}
			UnityEngine.Debug.DrawRay(ray.origin, ray.direction, Color.cyan, 5f, depthTest: true);
			if (destroyOnTargetCollision)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}
	public class TargetMeasurement : MonoBehaviour
	{
		public GameObject visualWrapper;

		public Transform measurementTape;

		public Transform endPoint;

		public Text measurementTextM;

		public Text measurementTextFT;

		public float maxDistanceToDraw = 6f;

		public bool drawTape;

		private float lastDistance;

		private void Update()
		{
			if (Camera.main != null)
			{
				Vector3 position = Camera.main.transform.position;
				position.y = endPoint.position.y;
				float num = Vector3.Distance(position, endPoint.position);
				Vector3 position2 = Vector3.Lerp(position, endPoint.position, 0.5f);
				base.transform.position = position2;
				base.transform.forward = endPoint.position - position;
				measurementTape.localScale = new Vector3(0.05f, num, 0.05f);
				if (Mathf.Abs(num - lastDistance) > 0.01f)
				{
					measurementTextM.text = num.ToString("00.0m");
					measurementTextFT.text = ((double)num * 3.28084).ToString("00.0ft");
					lastDistance = num;
				}
				if (drawTape)
				{
					visualWrapper.SetActive(num < maxDistanceToDraw);
				}
				else
				{
					visualWrapper.SetActive(value: false);
				}
			}
		}
	}
	public class SquishyToy : MonoBehaviour
	{
		public Interactable interactable;

		public SkinnedMeshRenderer renderer;

		public bool affectMaterial = true;

		public SteamVR_Action_Single gripSqueeze = SteamVR_Input.GetAction<SteamVR_Action_Single>("Squeeze");

		public SteamVR_Action_Single pinchSqueeze = SteamVR_Input.GetAction<SteamVR_Action_Single>("Squeeze");

		private Rigidbody rigidbody;

		private void Start()
		{
			if (rigidbody == null)
			{
				rigidbody = GetComponent<Rigidbody>();
			}
			if (interactable == null)
			{
				interactable = GetComponent<Interactable>();
			}
			if (renderer == null)
			{
				renderer = GetComponent<SkinnedMeshRenderer>();
			}
		}

		private void Update()
		{
			float num = 0f;
			float num2 = 0f;
			if ((bool)interactable.attachedToHand)
			{
				num = gripSqueeze.GetAxis(interactable.attachedToHand.handType);
				num2 = pinchSqueeze.GetAxis(interactable.attachedToHand.handType);
			}
			renderer.SetBlendShapeWeight(0, Mathf.Lerp(renderer.GetBlendShapeWeight(0), num * 100f, Time.deltaTime * 10f));
			if (renderer.sharedMesh.blendShapeCount > 1)
			{
				renderer.SetBlendShapeWeight(1, Mathf.Lerp(renderer.GetBlendShapeWeight(1), num2 * 100f, Time.deltaTime * 10f));
			}
			if (affectMaterial)
			{
				renderer.material.SetFloat("_Deform", Mathf.Pow(num * 1f, 0.5f));
				if (renderer.material.HasProperty("_PinchDeform"))
				{
					renderer.material.SetFloat("_PinchDeform", Mathf.Pow(num2 * 1f, 0.5f));
				}
			}
		}
	}
}
namespace Valve.VR.Extras
{
	public class SteamVR_ForceSteamVRMode : MonoBehaviour
	{
		public GameObject vrCameraPrefab;

		public GameObject[] disableObjectsOnLoad;

		private IEnumerator Start()
		{
			yield return new WaitForSeconds(1f);
			SteamVR.Initialize(forceUnityVRMode: true);
			while (SteamVR.initializedState != SteamVR.InitializedStates.InitializeSuccess)
			{
				yield return null;
			}
			for (int i = 0; i < disableObjectsOnLoad.Length; i++)
			{
				GameObject gameObject = disableObjectsOnLoad[i];
				if (gameObject != null)
				{
					gameObject.SetActive(value: false);
				}
			}
			UnityEngine.Object.Instantiate(vrCameraPrefab);
		}
	}
	public class SteamVR_GazeTracker : MonoBehaviour
	{
		public bool isInGaze;

		public float gazeInCutoff = 0.15f;

		public float gazeOutCutoff = 0.4f;

		protected Transform hmdTrackedObject;

		public event GazeEventHandler GazeOn;

		public event GazeEventHandler GazeOff;

		public virtual void OnGazeOn(GazeEventArgs gazeEventArgs)
		{
			if (this.GazeOn != null)
			{
				this.GazeOn(this, gazeEventArgs);
			}
		}

		public virtual void OnGazeOff(GazeEventArgs gazeEventArgs)
		{
			if (this.GazeOff != null)
			{
				this.GazeOff(this, gazeEventArgs);
			}
		}

		protected virtual void Update()
		{
			if (hmdTrackedObject == null)
			{
				SteamVR_TrackedObject[] array = UnityEngine.Object.FindObjectsOfType<SteamVR_TrackedObject>();
				foreach (SteamVR_TrackedObject steamVR_TrackedObject in array)
				{
					if (steamVR_TrackedObject.index == SteamVR_TrackedObject.EIndex.Hmd)
					{
						hmdTrackedObject = steamVR_TrackedObject.transform;
						break;
					}
				}
			}
			if (!hmdTrackedObject)
			{
				return;
			}
			Ray ray = new Ray(hmdTrackedObject.position, hmdTrackedObject.forward);
			Plane plane = new Plane(hmdTrackedObject.forward, base.transform.position);
			float enter = 0f;
			if (plane.Raycast(ray, out enter))
			{
				float num = Vector3.Distance(hmdTrackedObject.position + hmdTrackedObject.forward * enter, base.transform.position);
				if (num < gazeInCutoff && !isInGaze)
				{
					isInGaze = true;
					GazeEventArgs gazeEventArgs = default(GazeEventArgs);
					gazeEventArgs.distance = num;
					OnGazeOn(gazeEventArgs);
				}
				else if (num >= gazeOutCutoff && isInGaze)
				{
					isInGaze = false;
					GazeEventArgs gazeEventArgs2 = default(GazeEventArgs);
					gazeEventArgs2.distance = num;
					OnGazeOff(gazeEventArgs2);
				}
			}
		}
	}
	public struct GazeEventArgs
	{
		public float distance;
	}
	public delegate void GazeEventHandler(object sender, GazeEventArgs gazeEventArgs);
	public class SteamVR_LaserPointer : MonoBehaviour
	{
		public SteamVR_Behaviour_Pose pose;

		public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");

		public bool active = true;

		public Color color;

		public float thickness = 0.002f;

		public Color clickColor = Color.green;

		public GameObject holder;

		public GameObject pointer;

		private bool isActive;

		public bool addRigidBody;

		public Transform reference;

		private Transform previousContact;

		public event PointerEventHandler PointerIn;

		public event PointerEventHandler PointerOut;

		public event PointerEventHandler PointerClick;

		private void Start()
		{
			if (pose == null)
			{
				pose = GetComponent<SteamVR_Behaviour_Pose>();
			}
			if (pose == null)
			{
				UnityEngine.Debug.LogError("No SteamVR_Behaviour_Pose component found on this object", this);
			}
			if (interactWithUI == null)
			{
				UnityEngine.Debug.LogError("No ui interaction action has been set on this component.", this);
			}
			holder = new GameObject();
			holder.transform.parent = base.transform;
			holder.transform.localPosition = Vector3.zero;
			holder.transform.localRotation = Quaternion.identity;
			pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
			pointer.transform.parent = holder.transform;
			pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
			pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
			pointer.transform.localRotation = Quaternion.identity;
			BoxCollider component = pointer.GetComponent<BoxCollider>();
			if (addRigidBody)
			{
				if ((bool)component)
				{
					component.isTrigger = true;
				}
				pointer.AddComponent<Rigidbody>().isKinematic = true;
			}
			else if ((bool)component)
			{
				UnityEngine.Object.Destroy(component);
			}
			Material material = new Material(Shader.Find("Unlit/Color"));
			material.SetColor("_Color", color);
			pointer.GetComponent<MeshRenderer>().material = material;
		}

		public virtual void OnPointerIn(PointerEventArgs e)
		{
			if (this.PointerIn != null)
			{
				this.PointerIn(this, e);
			}
		}

		public virtual void OnPointerClick(PointerEventArgs e)
		{
			if (this.PointerClick != null)
			{
				this.PointerClick(this, e);
			}
		}

		public virtual void OnPointerOut(PointerEventArgs e)
		{
			if (this.PointerOut != null)
			{
				this.PointerOut(this, e);
			}
		}

		private void Update()
		{
			if (!isActive)
			{
				isActive = true;
				base.transform.GetChild(0).gameObject.SetActive(value: true);
			}
			float num = 100f;
			RaycastHit hitInfo;
			bool num2 = Physics.Raycast(new Ray(base.transform.position, base.transform.forward), out hitInfo);
			if ((bool)previousContact && previousContact != hitInfo.transform)
			{
				OnPointerOut(new PointerEventArgs
				{
					fromInputSource = pose.inputSource,
					distance = 0f,
					flags = 0u,
					target = previousContact
				});
				previousContact = null;
			}
			if (num2 && previousContact != hitInfo.transform)
			{
				OnPointerIn(new PointerEventArgs
				{
					fromInputSource = pose.inputSource,
					distance = hitInfo.distance,
					flags = 0u,
					target = hitInfo.transform
				});
				previousContact = hitInfo.transform;
			}
			if (!num2)
			{
				previousContact = null;
			}
			if (num2 && hitInfo.distance < 100f)
			{
				num = hitInfo.distance;
			}
			if (num2 && interactWithUI.GetStateUp(pose.inputSource))
			{
				OnPointerClick(new PointerEventArgs
				{
					fromInputSource = pose.inputSource,
					distance = hitInfo.distance,
					flags = 0u,
					target = hitInfo.transform
				});
			}
			if (interactWithUI != null && interactWithUI.GetState(pose.inputSource))
			{
				pointer.transform.localScale = new Vector3(thickness * 5f, thickness * 5f, num);
				pointer.GetComponent<MeshRenderer>().material.color = clickColor;
			}
			else
			{
				pointer.transform.localScale = new Vector3(thickness, thickness, num);
				pointer.GetComponent<MeshRenderer>().material.color = color;
			}
			pointer.transform.localPosition = new Vector3(0f, 0f, num / 2f);
		}
	}
	public struct PointerEventArgs
	{
		public SteamVR_Input_Sources fromInputSource;

		public uint flags;

		public float distance;

		public Transform target;
	}
	public delegate void PointerEventHandler(object sender, PointerEventArgs e);
	[RequireComponent(typeof(SteamVR_TrackedObject))]
	public class SteamVR_TestThrow : MonoBehaviour
	{
		public GameObject prefab;

		public Rigidbody attachPoint;

		public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

		private SteamVR_Behaviour_Pose trackedObj;

		private FixedJoint joint;

		private void Awake()
		{
			trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
		}

		private void FixedUpdate()
		{
			if (joint == null && spawn.GetStateDown(trackedObj.inputSource))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
				gameObject.transform.position = attachPoint.transform.position;
				joint = gameObject.AddComponent<FixedJoint>();
				joint.connectedBody = attachPoint;
			}
			else if (joint != null && spawn.GetStateUp(trackedObj.inputSource))
			{
				GameObject obj = joint.gameObject;
				Rigidbody component = obj.GetComponent<Rigidbody>();
				UnityEngine.Object.DestroyImmediate(joint);
				joint = null;
				UnityEngine.Object.Destroy(obj, 15f);
				Transform transform = (trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent);
				if (transform != null)
				{
					component.linearVelocity = transform.TransformVector(trackedObj.GetVelocity());
					component.angularVelocity = transform.TransformVector(trackedObj.GetAngularVelocity());
				}
				else
				{
					component.linearVelocity = trackedObj.GetVelocity();
					component.angularVelocity = trackedObj.GetAngularVelocity();
				}
				component.maxAngularVelocity = component.angularVelocity.magnitude;
			}
		}
	}
	public class SteamVR_TestTrackedCamera : MonoBehaviour
	{
		public Material material;

		public Transform target;

		public bool undistorted = true;

		public bool cropped = true;

		private void OnEnable()
		{
			SteamVR_TrackedCamera.VideoStreamTexture videoStreamTexture = SteamVR_TrackedCamera.Source(undistorted);
			videoStreamTexture.Acquire();
			if (!videoStreamTexture.hasCamera)
			{
				base.enabled = false;
			}
		}

		private void OnDisable()
		{
			material.mainTexture = null;
			SteamVR_TrackedCamera.Source(undistorted).Release();
		}

		private void Update()
		{
			SteamVR_TrackedCamera.VideoStreamTexture videoStreamTexture = SteamVR_TrackedCamera.Source(undistorted);
			Texture2D texture = videoStreamTexture.texture;
			if (!(texture == null))
			{
				material.mainTexture = texture;
				float num = (float)texture.width / (float)texture.height;
				if (cropped)
				{
					VRTextureBounds_t frameBounds = videoStreamTexture.frameBounds;
					material.mainTextureOffset = new Vector2(frameBounds.uMin, frameBounds.vMin);
					float num2 = frameBounds.uMax - frameBounds.uMin;
					float num3 = frameBounds.vMax - frameBounds.vMin;
					material.mainTextureScale = new Vector2(num2, num3);
					num *= Mathf.Abs(num2 / num3);
				}
				else
				{
					material.mainTextureOffset = Vector2.zero;
					material.mainTextureScale = new Vector2(1f, -1f);
				}
				target.localScale = new Vector3(1f, 1f / num, 1f);
				if (videoStreamTexture.hasTracking)
				{
					SteamVR_Utils.RigidTransform rigidTransform = videoStreamTexture.transform;
					target.localPosition = rigidTransform.pos;
					target.localRotation = rigidTransform.rot;
				}
			}
		}
	}
}
