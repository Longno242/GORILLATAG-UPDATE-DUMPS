using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: UnityEngineModuleAssembly]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.AMD;

[NativeHeader("Modules/AMD/AMDPlugins.h")]
public static class AMDUnityPlugin
{
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern bool Load();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern bool IsLoaded();
}
[Flags]
public enum FfxFsr2InitializationFlags
{
	EnableHighDynamicRange = 1,
	EnableDisplayResolutionMotionVectors = 2,
	EnableMotionVectorsJitterCancellation = 4,
	DepthInverted = 8,
	EnableDepthInfinite = 0x10,
	EnableAutoExposure = 0x20,
	EnableDynamicResolution = 0x40,
	EnableTexture1DUsage = 0x80
}
public enum FSR2Quality
{
	Quality,
	Balanced,
	Performance,
	UltraPerformance
}
public struct FSR2CommandInitializationData
{
	public uint maxRenderSizeWidth;

	public uint maxRenderSizeHeight;

	public uint displaySizeWidth;

	public uint displaySizeHeight;

	public FfxFsr2InitializationFlags ffxFsrFlags;

	internal uint featureSlot;

	public void SetFlag(FfxFsr2InitializationFlags flag, bool value)
	{
		if (value)
		{
			ffxFsrFlags |= flag;
		}
		else
		{
			ffxFsrFlags &= ~flag;
		}
	}

	public bool GetFlag(FfxFsr2InitializationFlags flag)
	{
		return (ffxFsrFlags & flag) != 0;
	}
}
public struct FSR2TextureTable
{
	public Texture colorInput { get; set; }

	public Texture colorOutput { get; set; }

	public Texture depth { get; set; }

	public Texture motionVectors { get; set; }

	public Texture transparencyMask { get; set; }

	public Texture exposureTexture { get; set; }

	public Texture reactiveMask { get; set; }

	public Texture biasColorMask { get; set; }
}
public struct FSR2CommandExecutionData
{
	internal enum Textures
	{
		ColorInput,
		ColorOutput,
		Depth,
		MotionVectors,
		TransparencyMask,
		ExposureTexture,
		ReactiveMask,
		BiasColorMask
	}

	public float jitterOffsetX;

	public float jitterOffsetY;

	public float MVScaleX;

	public float MVScaleY;

	public uint renderSizeWidth;

	public uint renderSizeHeight;

	public int enableSharpening;

	public float sharpness;

	public float frameTimeDelta;

	public float preExposure;

	public int reset;

	public float cameraNear;

	public float cameraFar;

	public float cameraFovAngleVertical;

	internal uint featureSlot;
}
internal class NativeData<T> : IDisposable where T : struct
{
	private IntPtr m_MarshalledValue = IntPtr.Zero;

	public T Value = new T();

	public unsafe IntPtr Ptr
	{
		get
		{
			UnsafeUtility.CopyStructureToPtr(ref Value, m_MarshalledValue.ToPointer());
			return m_MarshalledValue;
		}
	}

	public NativeData()
	{
		m_MarshalledValue = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (m_MarshalledValue != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(m_MarshalledValue);
			m_MarshalledValue = IntPtr.Zero;
		}
	}

	~NativeData()
	{
		Dispose(disposing: false);
	}
}
public class FSR2Context
{
	private NativeData<FSR2CommandInitializationData> m_InitData = new NativeData<FSR2CommandInitializationData>();

	private NativeData<FSR2CommandExecutionData> m_ExecData = new NativeData<FSR2CommandExecutionData>();

	public ref readonly FSR2CommandInitializationData initData => ref m_InitData.Value;

	public ref FSR2CommandExecutionData executeData => ref m_ExecData.Value;

	internal uint featureSlot => initData.featureSlot;

	internal FSR2Context()
	{
	}

	internal void Init(FSR2CommandInitializationData initSettings, uint featureSlot)
	{
		m_InitData.Value = initSettings;
		m_InitData.Value.featureSlot = featureSlot;
	}

	internal void Reset()
	{
		m_InitData.Value = default(FSR2CommandInitializationData);
		m_ExecData.Value = default(FSR2CommandExecutionData);
	}

	internal IntPtr GetInitCmdPtr()
	{
		return m_InitData.Ptr;
	}

	internal IntPtr GetExecuteCmdPtr()
	{
		m_ExecData.Value.featureSlot = featureSlot;
		return m_ExecData.Ptr;
	}
}
internal enum PluginEvent
{
	DestroyFeature,
	FSR2Execute,
	FSR2PostExecute,
	FSR2Init
}
public class GraphicsDevice
{
	private static GraphicsDevice sGraphicsDeviceInstance;

	private Stack<FSR2Context> s_ContextObjectPool = new Stack<FSR2Context>();

	public static GraphicsDevice device => sGraphicsDeviceInstance;

	public static uint version => AMDUP_GetDeviceVersion();

	private GraphicsDevice()
	{
	}

	private bool Initialize()
	{
		return AMDUP_InitApi();
	}

	private void Shutdown()
	{
		AMDUP_ShutdownApi();
	}

	~GraphicsDevice()
	{
		Shutdown();
	}

	private void InsertEventCall(CommandBuffer cmd, PluginEvent pluginEvent, IntPtr ptr)
	{
		cmd.IssuePluginEventAndData(AMDUP_GetRenderEventCallback(), (int)(pluginEvent + AMDUP_GetBaseEventId()), ptr);
	}

	private static GraphicsDevice InternalCreate()
	{
		if (sGraphicsDeviceInstance != null)
		{
			sGraphicsDeviceInstance.Shutdown();
			sGraphicsDeviceInstance.Initialize();
			return sGraphicsDeviceInstance;
		}
		GraphicsDevice graphicsDevice = new GraphicsDevice();
		if (graphicsDevice.Initialize())
		{
			sGraphicsDeviceInstance = graphicsDevice;
			return graphicsDevice;
		}
		Debug.LogWarning("Unity has an invalid api for dvice. Init failed[");
		return null;
	}

	private static int CreateSetTextureUserData(int featureId, int textureSlot, bool clearTextureTable)
	{
		int num = featureId & 0xFFFF;
		int num2 = textureSlot & 0x7FFF;
		int num3 = (clearTextureTable ? 1 : 0);
		return (num << 16) | (num2 << 1) | num3;
	}

	private void SetTexture(CommandBuffer cmd, FSR2Context fsr2Context, FSR2CommandExecutionData.Textures textureSlot, Texture texture, bool clearTextureTable = false)
	{
		if (!(texture == null))
		{
			uint userData = (uint)CreateSetTextureUserData((int)fsr2Context.featureSlot, (int)textureSlot, clearTextureTable);
			cmd.IssuePluginCustomTextureUpdateV2(AMDUP_GetSetTextureEventCallback(), texture, userData);
		}
	}

	public static GraphicsDevice CreateGraphicsDevice()
	{
		return InternalCreate();
	}

	public FSR2Context CreateFeature(CommandBuffer cmd, in FSR2CommandInitializationData initSettings)
	{
		FSR2Context fSR2Context = null;
		fSR2Context = ((s_ContextObjectPool.Count != 0) ? s_ContextObjectPool.Pop() : new FSR2Context());
		fSR2Context.Init(initSettings, AMDUP_CreateFeatureSlot());
		InsertEventCall(cmd, PluginEvent.FSR2Init, fSR2Context.GetInitCmdPtr());
		return fSR2Context;
	}

	public bool GetRenderResolutionFromQualityMode(FSR2Quality qualityMode, uint displayWidth, uint displayHeight, out uint renderWidth, out uint renderHeight)
	{
		return AMDUP_GetRenderResolutionFromQualityMode(qualityMode, displayWidth, displayHeight, out renderWidth, out renderHeight);
	}

	public float GetUpscaleRatioFromQualityMode(FSR2Quality qualityMode)
	{
		return AMDUP_GetUpscaleRatioFromQualityMode(qualityMode);
	}

	public void DestroyFeature(CommandBuffer cmd, FSR2Context fsrContext)
	{
		InsertEventCall(cmd, PluginEvent.DestroyFeature, new IntPtr(fsrContext.featureSlot));
		fsrContext.Reset();
		s_ContextObjectPool.Push(fsrContext);
	}

	public void ExecuteFSR2(CommandBuffer cmd, FSR2Context fsr2Context, in FSR2TextureTable textures)
	{
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.ColorInput, textures.colorInput, clearTextureTable: true);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.ColorOutput, textures.colorOutput);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.Depth, textures.depth);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.MotionVectors, textures.motionVectors);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.TransparencyMask, textures.transparencyMask);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.ExposureTexture, textures.exposureTexture);
		SetTexture(cmd, fsr2Context, FSR2CommandExecutionData.Textures.BiasColorMask, textures.biasColorMask);
		InsertEventCall(cmd, PluginEvent.FSR2Execute, fsr2Context.GetExecuteCmdPtr());
		InsertEventCall(cmd, PluginEvent.FSR2PostExecute, fsr2Context.GetExecuteCmdPtr());
	}

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern bool AMDUP_InitApi();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern void AMDUP_ShutdownApi();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern uint AMDUP_GetDeviceVersion();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern IntPtr AMDUP_GetRenderEventCallback();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern IntPtr AMDUP_GetSetTextureEventCallback();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern uint AMDUP_CreateFeatureSlot();

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern bool AMDUP_GetRenderResolutionFromQualityMode(FSR2Quality qualityMode, uint displayWidth, uint displayHeight, out uint renderWidth, out uint renderHeight);

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern float AMDUP_GetUpscaleRatioFromQualityMode(FSR2Quality qualityMode);

	[DllImport("AMDUnityPlugin", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	private static extern int AMDUP_GetBaseEventId();
}
