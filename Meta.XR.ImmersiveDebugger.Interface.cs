using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

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
			FilePathsData = new byte[244]
			{
				0, 0, 0, 3, 0, 0, 0, 118, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 99, 111, 114, 101,
				64, 53, 48, 51, 97, 55, 50, 99, 97, 53,
				52, 57, 54, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 73, 109, 109, 101, 114, 115, 105, 118,
				101, 68, 101, 98, 117, 103, 103, 101, 114, 92,
				73, 110, 116, 101, 114, 102, 97, 99, 101, 92,
				67, 117, 115, 116, 111, 109, 73, 110, 116, 101,
				103, 114, 97, 116, 105, 111, 110, 67, 111, 110,
				102, 105, 103, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 110, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 99, 111, 114, 101, 64, 53, 48, 51,
				97, 55, 50, 99, 97, 53, 52, 57, 54, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 73, 109,
				109, 101, 114, 115, 105, 118, 101, 68, 101, 98,
				117, 103, 103, 101, 114, 92, 73, 110, 116, 101,
				114, 102, 97, 99, 101, 92, 68, 101, 98, 117,
				103, 65, 116, 116, 114, 105, 98, 117, 116, 101,
				115, 46, 99, 115
			},
			TypesData = new byte[209]
			{
				0, 0, 0, 0, 49, 77, 101, 116, 97, 46,
				88, 82, 46, 73, 109, 109, 101, 114, 115, 105,
				118, 101, 68, 101, 98, 117, 103, 103, 101, 114,
				124, 67, 117, 115, 116, 111, 109, 73, 110, 116,
				101, 103, 114, 97, 116, 105, 111, 110, 67, 111,
				110, 102, 105, 103, 0, 0, 0, 0, 50, 77,
				101, 116, 97, 46, 88, 82, 46, 73, 109, 109,
				101, 114, 115, 105, 118, 101, 68, 101, 98, 117,
				103, 103, 101, 114, 124, 73, 67, 117, 115, 116,
				111, 109, 73, 110, 116, 101, 103, 114, 97, 116,
				105, 111, 110, 67, 111, 110, 102, 105, 103, 0,
				0, 0, 0, 53, 77, 101, 116, 97, 46, 88,
				82, 46, 73, 109, 109, 101, 114, 115, 105, 118,
				101, 68, 101, 98, 117, 103, 103, 101, 114, 124,
				67, 117, 115, 116, 111, 109, 73, 110, 116, 101,
				103, 114, 97, 116, 105, 111, 110, 67, 111, 110,
				102, 105, 103, 66, 97, 115, 101, 0, 0, 0,
				0, 37, 77, 101, 116, 97, 46, 88, 82, 46,
				73, 109, 109, 101, 114, 115, 105, 118, 101, 68,
				101, 98, 117, 103, 103, 101, 114, 124, 68, 101,
				98, 117, 103, 77, 101, 109, 98, 101, 114
			},
			TotalFiles = 2,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace Meta.XR.ImmersiveDebugger;

public static class CustomIntegrationConfig
{
	public delegate Camera GetCameraDelegate();

	public delegate Transform GetLeftControllerTransformDelegate();

	public delegate Transform GetRightControllerTransformDelegate();

	public static event GetCameraDelegate GetCameraHandler;

	public static void SetupAllConfig(ICustomIntegrationConfig customConfig)
	{
		GetCameraHandler += customConfig.GetCamera;
	}

	public static void ClearAllConfig(ICustomIntegrationConfig customConfig)
	{
		GetCameraHandler -= customConfig.GetCamera;
	}

	public static Camera GetCamera()
	{
		return CustomIntegrationConfig.GetCameraHandler?.Invoke();
	}
}
public interface ICustomIntegrationConfig
{
	Camera GetCamera();
}
public class CustomIntegrationConfigBase : MonoBehaviour, ICustomIntegrationConfig
{
	private void Awake()
	{
		CustomIntegrationConfig.SetupAllConfig(this);
	}

	private void OnDestroy()
	{
		CustomIntegrationConfig.ClearAllConfig(this);
	}

	public virtual Camera GetCamera()
	{
		return null;
	}
}
public enum DebugColor
{
	Red,
	Gray
}
[Serializable]
[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
public class DebugMember : PreserveAttribute
{
	public const string DisplayNameTooltip = "Optional name override to be used in the Inspector Panel";

	private static readonly Dictionary<DebugColor, Color> ParsedColors = new Dictionary<DebugColor, Color>
	{
		{
			DebugColor.Red,
			Color.red
		},
		{
			DebugColor.Gray,
			Color.gray
		}
	};

	public DebugGizmoType GizmoType;

	public bool ShowGizmoByDefault;

	public Color Color = Color.gray;

	public bool Tweakable = true;

	public float Min;

	public float Max = 1f;

	public string Category;

	public string Description;

	[Tooltip("Optional name override to be used in the Inspector Panel")]
	public string DisplayName;

	public DebugMember(DebugColor color = DebugColor.Gray)
	{
		ParsedColors.TryGetValue(color, out Color);
	}

	public DebugMember(string colorString)
	{
		if (!string.IsNullOrEmpty(colorString))
		{
			Color = (ColorUtility.TryParseHtmlString(colorString, out var color) ? color : Color.gray);
		}
	}
}
public enum DebugGizmoType
{
	None,
	Axis,
	Point,
	Line,
	Lines,
	Plane,
	Cube,
	TopCenterBox,
	Box
}
