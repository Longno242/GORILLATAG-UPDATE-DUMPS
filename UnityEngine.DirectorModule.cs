using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("Unity.Animation.Timeline")]
[assembly: InternalsVisibleTo("Unity.Motion.Hybrid")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("Unity.Motion.Timeline")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.Playables;

[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
[StaticAccessor("DataPlayableBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayable.bindings.h")]
internal static class DataPlayableBindings
{
	[NativeThrows]
	public static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
	{
		return CreateHandleInternal_Injected(ref graph, ref handle);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle);
}
internal struct DataPlayable<TPayload> : IPlayable, IEquatable<DataPlayable<TPayload>> where TPayload : struct
{
	private PlayableHandle m_Handle;

	private static readonly DataPlayable<TPayload> m_NullPlayable = new DataPlayable<TPayload>(PlayableHandle.Null);

	public static DataPlayable<TPayload> Null => m_NullPlayable;

	public static DataPlayable<TPayload> Create(PlayableGraph graph, int inputCount = 0)
	{
		return Create(graph, default(TPayload), inputCount);
	}

	public static DataPlayable<TPayload> Create(PlayableGraph graph, TPayload payload, int inputCount = 0)
	{
		PlayableHandle handle = CreateHandle(graph, payload, inputCount);
		return new DataPlayable<TPayload>(handle);
	}

	private static PlayableHandle CreateHandle(PlayableGraph graph, TPayload payload, int inputCount)
	{
		PlayableHandle handle = PlayableHandle.Null;
		if (!DataPlayableBindings.CreateHandleInternal(graph, ref handle))
		{
			return PlayableHandle.Null;
		}
		handle.SetInputCount(inputCount);
		handle.SetScriptInstance(payload);
		return handle;
	}

	internal DataPlayable(PlayableHandle handle)
	{
		if (handle.IsValid() && typeof(TPayload) != handle.GetPlayableType())
		{
			throw new InvalidCastException($"Incompatible handle: Trying to assign a playable data of type `{handle.GetPlayableType()}` that is not compatible with the Payload of type `{typeof(TPayload)}`.");
		}
		m_Handle = handle;
	}

	public PlayableHandle GetHandle()
	{
		return m_Handle;
	}

	public TPayload GetPayload()
	{
		return m_Handle.GetPayload<TPayload>();
	}

	public void SetPayload(TPayload payload)
	{
		m_Handle.SetPayload(payload);
	}

	public static implicit operator Playable(DataPlayable<TPayload> playable)
	{
		return new Playable(playable.GetHandle());
	}

	public static explicit operator DataPlayable<TPayload>(Playable playable)
	{
		return new DataPlayable<TPayload>(playable.GetHandle());
	}

	public bool Equals(DataPlayable<TPayload> other)
	{
		return GetHandle() == other.GetHandle();
	}
}
internal static class DataPlayableBinding
{
	public static PlayableBinding Create<TDataStream, TPlayer>(string name, Object key) where TDataStream : new() where TPlayer : Object
	{
		return PlayableBinding.CreateInternal(name, key, typeof(TPlayer), CreateDataOutput<TDataStream>);
	}

	private static PlayableOutput CreateDataOutput<TDataStream>(PlayableGraph graph, string name) where TDataStream : new()
	{
		return DataPlayableOutput.Create<TDataStream>(graph, name);
	}
}
[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
[RequiredByNativeCode]
[StaticAccessor("DataPlayableOutputBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutput.bindings.h")]
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutputExtensions.bindings.h")]
[NativeHeader("Modules/Director/DataPlayableOutput.h")]
internal struct DataPlayableOutput : IPlayableOutput
{
	private PlayableOutputHandle m_Handle;

	public static DataPlayableOutput Null => new DataPlayableOutput(PlayableOutputHandle.Null);

	public Type GetStreamType()
	{
		return InternalGetType(ref m_Handle);
	}

	public bool GetConnectionChanged()
	{
		return InternalGetConnectionChanged(ref m_Handle);
	}

	public void ClearConnectionChanged()
	{
		InternalClearConnectionChanged(ref m_Handle);
	}

	public TDataStream GetDataStream<TDataStream>() where TDataStream : new()
	{
		if (!(InternalGetStream(ref m_Handle) is TDataStream result))
		{
			return default(TDataStream);
		}
		return result;
	}

	public void SetDataStream<TDataStream>(TDataStream stream) where TDataStream : new()
	{
		Type streamType = GetStreamType();
		if (!streamType.IsAssignableFrom(typeof(TDataStream)))
		{
			throw new ArgumentException(string.Format("{0} is of the wrong type. This output only accepts streams with type {1} or inheriting from type {2}", "stream", streamType, streamType), "stream");
		}
		InternalSetStream(ref m_Handle, stream);
	}

	public static DataPlayableOutput Create<TDataStream>(PlayableGraph graph, string name) where TDataStream : new()
	{
		if (!DataPlayableOutputExtensions.InternalCreateDataOutput(ref graph, name, typeof(TDataStream), out var handle))
		{
			return Null;
		}
		return new DataPlayableOutput(handle);
	}

	internal DataPlayableOutput(PlayableOutputHandle handle)
	{
		if (handle.IsValid() && !handle.IsPlayableOutputOfType<DataPlayableOutput>())
		{
			throw new InvalidCastException("Can't set handle: the playable is not a DataPlayableOutput.");
		}
		m_Handle = handle;
	}

	public PlayableOutputHandle GetHandle()
	{
		return m_Handle;
	}

	public static implicit operator PlayableOutput(DataPlayableOutput output)
	{
		return new PlayableOutput(output.GetHandle());
	}

	public static explicit operator DataPlayableOutput(PlayableOutput output)
	{
		return new DataPlayableOutput(output.GetHandle());
	}

	public IDataPlayer GetPlayer()
	{
		return InternalGetPlayer(ref m_Handle) as IDataPlayer;
	}

	public void SetPlayer<TPlayer>(TPlayer player) where TPlayer : Object, IDataPlayer
	{
		InternalSetPlayer(ref m_Handle, player);
	}

	[NativeThrows]
	private static Object InternalGetPlayer(ref PlayableOutputHandle handle)
	{
		return Unmarshal.UnmarshalUnityObject<Object>(InternalGetPlayer_Injected(ref handle));
	}

	[NativeThrows]
	private static void InternalSetPlayer(ref PlayableOutputHandle handle, Object player)
	{
		InternalSetPlayer_Injected(ref handle, Object.MarshalledUnityObject.Marshal(player));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern Type InternalGetType(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern void InternalSetStream(ref PlayableOutputHandle handle, object stream);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern object InternalGetStream(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern bool InternalGetConnectionChanged(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeThrows]
	private static extern void InternalClearConnectionChanged(ref PlayableOutputHandle handle);

	[RequiredByNativeCode]
	private static void Internal_CallOnPlayerChanged(PlayableOutputHandle handle, object previousPlayer, object currentPlayer)
	{
		DataPlayableOutput output = new DataPlayableOutput(handle);
		if (previousPlayer is IDataPlayer dataPlayer)
		{
			dataPlayer.Release(output);
		}
		if (currentPlayer is IDataPlayer dataPlayer2)
		{
			dataPlayer2.Bind(output);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr InternalGetPlayer_Injected(ref PlayableOutputHandle handle);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void InternalSetPlayer_Injected(ref PlayableOutputHandle handle, IntPtr player);
}
[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutputExtensions.bindings.h")]
[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
[StaticAccessor("DataPlayableOutputExtensionsBindings", StaticAccessorType.DoubleColon)]
internal static class DataPlayableOutputExtensions
{
	[NativeThrows]
	internal unsafe static bool InternalCreateDataOutput(ref PlayableGraph graph, string name, Type type, out PlayableOutputHandle handle)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return InternalCreateDataOutput_Injected(ref graph, ref managedSpanWrapper, type, out handle);
				}
			}
			return InternalCreateDataOutput_Injected(ref graph, ref managedSpanWrapper, type, out handle);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool InternalCreateDataOutput_Injected(ref PlayableGraph graph, ref ManagedSpanWrapper name, Type type, out PlayableOutputHandle handle);
}
internal interface IDataPlayer
{
	void Bind(DataPlayableOutput output);

	void Release(DataPlayableOutput output);
}
[NativeHeader("Modules/Director/PlayableDirector.h")]
[NativeHeader("Runtime/Mono/MonoBehaviour.h")]
[RequiredByNativeCode]
[HelpURL("https://docs.unity3d.com/ScriptReference/Playables.PlayableDirector.html")]
public class PlayableDirector : Behaviour, IExposedPropertyTable
{
	public PlayState state => GetPlayState();

	public DirectorWrapMode extrapolationMode
	{
		get
		{
			return GetWrapMode();
		}
		set
		{
			SetWrapMode(value);
		}
	}

	public PlayableAsset playableAsset
	{
		get
		{
			return Internal_GetPlayableAsset() as PlayableAsset;
		}
		set
		{
			SetPlayableAsset(value);
		}
	}

	public PlayableGraph playableGraph => GetGraphHandle();

	public bool playOnAwake
	{
		get
		{
			return GetPlayOnAwake();
		}
		set
		{
			SetPlayOnAwake(value);
		}
	}

	public DirectorUpdateMode timeUpdateMode
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_timeUpdateMode_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_timeUpdateMode_Injected(intPtr, value);
		}
	}

	public double time
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_time_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_time_Injected(intPtr, value);
		}
	}

	public double initialTime
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_initialTime_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_initialTime_Injected(intPtr, value);
		}
	}

	public double duration
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_duration_Injected(intPtr);
		}
	}

	public event Action<PlayableDirector> played;

	public event Action<PlayableDirector> paused;

	public event Action<PlayableDirector> stopped;

	public void DeferredEvaluate()
	{
		EvaluateNextFrame();
	}

	internal void Play(FrameRate frameRate)
	{
		PlayOnFrame(frameRate);
	}

	public void Play(PlayableAsset asset)
	{
		if (asset == null)
		{
			throw new ArgumentNullException("asset");
		}
		Play(asset, extrapolationMode);
	}

	public void Play(PlayableAsset asset, DirectorWrapMode mode)
	{
		if (asset == null)
		{
			throw new ArgumentNullException("asset");
		}
		playableAsset = asset;
		extrapolationMode = mode;
		Play();
	}

	public void SetGenericBinding(Object key, Object value)
	{
		Internal_SetGenericBinding(key, value);
	}

	[NativeThrows]
	public void Evaluate()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Evaluate_Injected(intPtr);
	}

	[NativeThrows]
	private void PlayOnFrame(FrameRate frameRate)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		PlayOnFrame_Injected(intPtr, ref frameRate);
	}

	[NativeThrows]
	public void Play()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Play_Injected(intPtr);
	}

	public void Stop()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Stop_Injected(intPtr);
	}

	public void Pause()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Pause_Injected(intPtr);
	}

	public void Resume()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Resume_Injected(intPtr);
	}

	[NativeThrows]
	public void RebuildGraph()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RebuildGraph_Injected(intPtr);
	}

	public void ClearReferenceValue(PropertyName id)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearReferenceValue_Injected(intPtr, ref id);
	}

	public void SetReferenceValue(PropertyName id, Object value)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetReferenceValue_Injected(intPtr, ref id, MarshalledUnityObject.Marshal(value));
	}

	public Object GetReferenceValue(PropertyName id, out bool idValid)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Object>(GetReferenceValue_Injected(intPtr, ref id, out idValid));
	}

	[NativeMethod("GetBindingFor")]
	public Object GetGenericBinding(Object key)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<Object>(GetGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key)));
	}

	[NativeMethod("ClearBindingFor")]
	public void ClearGenericBinding(Object key)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ClearGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key));
	}

	[NativeThrows]
	public void RebindPlayableGraphOutputs()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		RebindPlayableGraphOutputs_Injected(intPtr);
	}

	internal void ProcessPendingGraphChanges()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		ProcessPendingGraphChanges_Injected(intPtr);
	}

	[NativeMethod("HasBinding")]
	internal bool HasGenericBinding(Object key)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key));
	}

	private PlayState GetPlayState()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPlayState_Injected(intPtr);
	}

	private void SetWrapMode(DirectorWrapMode mode)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetWrapMode_Injected(intPtr, mode);
	}

	private DirectorWrapMode GetWrapMode()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetWrapMode_Injected(intPtr);
	}

	[NativeThrows]
	private void EvaluateNextFrame()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		EvaluateNextFrame_Injected(intPtr);
	}

	private PlayableGraph GetGraphHandle()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetGraphHandle_Injected(intPtr, out var ret);
		return ret;
	}

	private void SetPlayOnAwake(bool on)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPlayOnAwake_Injected(intPtr, on);
	}

	private bool GetPlayOnAwake()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetPlayOnAwake_Injected(intPtr);
	}

	[NativeThrows]
	private void Internal_SetGenericBinding(Object key, Object value)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		Internal_SetGenericBinding_Injected(intPtr, MarshalledUnityObject.Marshal(key), MarshalledUnityObject.Marshal(value));
	}

	private void SetPlayableAsset(ScriptableObject asset)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		SetPlayableAsset_Injected(intPtr, MarshalledUnityObject.Marshal(asset));
	}

	private ScriptableObject Internal_GetPlayableAsset()
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return Unmarshal.UnmarshalUnityObject<ScriptableObject>(Internal_GetPlayableAsset_Injected(intPtr));
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeHeader("Runtime/Director/Core/DirectorManager.h")]
	[StaticAccessor("GetDirectorManager()", StaticAccessorType.Dot)]
	internal static extern void ResetFrameTiming();

	[RequiredByNativeCode]
	private void SendOnPlayableDirectorPlay()
	{
		if (this.played != null)
		{
			this.played(this);
		}
	}

	[RequiredByNativeCode]
	private void SendOnPlayableDirectorPause()
	{
		if (this.paused != null)
		{
			this.paused(this);
		}
	}

	[RequiredByNativeCode]
	private void SendOnPlayableDirectorStop()
	{
		if (this.stopped != null)
		{
			this.stopped(this);
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_timeUpdateMode_Injected(IntPtr _unity_self, DirectorUpdateMode value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern DirectorUpdateMode get_timeUpdateMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_time_Injected(IntPtr _unity_self, double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_time_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_initialTime_Injected(IntPtr _unity_self, double value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_initialTime_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern double get_duration_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Evaluate_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void PlayOnFrame_Injected(IntPtr _unity_self, [In] ref FrameRate frameRate);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Play_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Stop_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Pause_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Resume_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RebuildGraph_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearReferenceValue_Injected(IntPtr _unity_self, [In] ref PropertyName id);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetReferenceValue_Injected(IntPtr _unity_self, [In] ref PropertyName id, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetReferenceValue_Injected(IntPtr _unity_self, [In] ref PropertyName id, out bool idValid);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetGenericBinding_Injected(IntPtr _unity_self, IntPtr key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ClearGenericBinding_Injected(IntPtr _unity_self, IntPtr key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RebindPlayableGraphOutputs_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void ProcessPendingGraphChanges_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasGenericBinding_Injected(IntPtr _unity_self, IntPtr key);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern PlayState GetPlayState_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetWrapMode_Injected(IntPtr _unity_self, DirectorWrapMode mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern DirectorWrapMode GetWrapMode_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void EvaluateNextFrame_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetGraphHandle_Injected(IntPtr _unity_self, out PlayableGraph ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPlayOnAwake_Injected(IntPtr _unity_self, bool on);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetPlayOnAwake_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_SetGenericBinding_Injected(IntPtr _unity_self, IntPtr key, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetPlayableAsset_Injected(IntPtr _unity_self, IntPtr asset);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr Internal_GetPlayableAsset_Injected(IntPtr _unity_self);
}
[StaticAccessor("PlayableSystemsBindings", StaticAccessorType.DoubleColon)]
[NativeHeader("Modules/Director/ScriptBindings/PlayableSystems.bindings.h")]
internal static class PlayableSystems
{
	public delegate void PlayableSystemDelegate(IReadOnlyList<DataPlayableOutput> outputs);

	public enum PlayableSystemStage : ushort
	{
		FixedUpdate,
		FixedUpdatePostPhysics,
		Update,
		AnimationBegin,
		AnimationEnd,
		LateUpdate,
		Render
	}

	private class DataPlayableOutputList : IReadOnlyList<DataPlayableOutput>, IEnumerable<DataPlayableOutput>, IEnumerable, IReadOnlyCollection<DataPlayableOutput>
	{
		private class DataPlayableOutputEnumerator : IEnumerator<DataPlayableOutput>, IEnumerator, IDisposable
		{
			private DataPlayableOutputList m_List;

			private int m_Index;

			public DataPlayableOutput Current
			{
				get
				{
					try
					{
						return m_List[m_Index];
					}
					catch (IndexOutOfRangeException)
					{
						throw new InvalidOperationException("Enumeration has either not started or has already finished.");
					}
				}
			}

			object IEnumerator.Current => Current;

			public DataPlayableOutputEnumerator(DataPlayableOutputList list)
			{
				m_List = list;
				m_Index = -1;
			}

			public void Dispose()
			{
				m_List = null;
			}

			public bool MoveNext()
			{
				m_Index++;
				return m_Index < m_List.Count;
			}

			public void Reset()
			{
				m_Index = -1;
			}
		}

		private unsafe PlayableOutputHandle* m_Outputs;

		private int m_Count;

		public unsafe DataPlayableOutput this[int index]
		{
			get
			{
				if (index >= m_Count)
				{
					throw new IndexOutOfRangeException($"index {index} is greater than the number of items: {m_Count}");
				}
				if (index < 0)
				{
					throw new IndexOutOfRangeException("index cannot be negative");
				}
				return new DataPlayableOutput(m_Outputs[index]);
			}
		}

		public int Count => m_Count;

		public unsafe DataPlayableOutputList(PlayableOutputHandle* outputs, int count)
		{
			m_Outputs = outputs;
			m_Count = count;
		}

		public IEnumerator<DataPlayableOutput> GetEnumerator()
		{
			return new DataPlayableOutputEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	private static Dictionary<int, Type> s_SystemTypes;

	private static Dictionary<int, PlayableSystemDelegate> s_Delegates;

	private static ReaderWriterLockSlim s_RWLock;

	public static void RegisterSystemPhaseDelegate<TDataStream>(PlayableSystemStage stage, PlayableSystemDelegate systemDelegate) where TDataStream : new()
	{
		RegisterSystemPhaseDelegate(typeof(TDataStream), stage, systemDelegate);
	}

	private static void RegisterSystemPhaseDelegate(Type streamType, PlayableSystemStage stage, PlayableSystemDelegate systemDelegate)
	{
		int num = RegisterStreamStage(streamType, (int)stage);
		try
		{
			s_RWLock.EnterWriteLock();
			s_SystemTypes.TryAdd(num, streamType);
			int key = CombineTypeAndIndex(num, stage);
			if (!s_Delegates.TryAdd(key, systemDelegate))
			{
				s_Delegates[key] = systemDelegate;
			}
		}
		finally
		{
			s_RWLock.ExitWriteLock();
		}
	}

	private static int CombineTypeAndIndex(int typeIndex, PlayableSystemStage stage)
	{
		return (typeIndex << 16) | (int)stage;
	}

	[RequiredByNativeCode]
	private unsafe static bool Internal_CallSystemDelegate(int systemIndex, PlayableSystemStage stage, IntPtr outputsPtr, int numOutputs)
	{
		PlayableOutputHandle* outputs = (PlayableOutputHandle*)(void*)outputsPtr;
		int key = CombineTypeAndIndex(systemIndex, stage);
		bool flag = false;
		bool flag2 = false;
		PlayableSystemDelegate value = null;
		s_RWLock.EnterReadLock();
		flag = s_SystemTypes.TryGetValue(systemIndex, out var _);
		if (flag)
		{
			flag2 = s_Delegates.TryGetValue(key, out value) && value != null;
		}
		s_RWLock.ExitReadLock();
		if (!flag || !flag2)
		{
			return false;
		}
		DataPlayableOutputList outputs2 = new DataPlayableOutputList(outputs, numOutputs);
		value(outputs2);
		return true;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadAndSerializationSafe]
	private static extern int RegisterStreamStage(Type streamType, int stage);

	static PlayableSystems()
	{
		s_Delegates = new Dictionary<int, PlayableSystemDelegate>();
		s_SystemTypes = new Dictionary<int, Type>();
		s_RWLock = new ReaderWriterLockSlim();
	}
}
