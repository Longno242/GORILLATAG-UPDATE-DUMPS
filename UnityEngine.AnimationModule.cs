using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.CodeAnalysis;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Playables;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubsystemsModule")]
[assembly: InternalsVisibleTo("UnityEngine.SubstanceModule")]
[assembly: InternalsVisibleTo("UnityEngine.StreamingModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteMaskModule")]
[assembly: InternalsVisibleTo("UnityEngine.TilemapModule")]
[assembly: InternalsVisibleTo("UnityEngine.SpriteShapeModule")]
[assembly: InternalsVisibleTo("UnityEngine.ShaderVariantAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.ContentLoadModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterRendererModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClusterInputModule")]
[assembly: InternalsVisibleTo("UnityEngine.ClothModule")]
[assembly: InternalsVisibleTo("UnityEngine.AudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.AssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.HotReloadModule")]
[assembly: InternalsVisibleTo("UnityEngine.AnimationModule")]
[assembly: InternalsVisibleTo("UnityEngine.AndroidJNIModule")]
[assembly: InternalsVisibleTo("UnityEngine.AccessibilityModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class IsUnmanagedAttribute : Attribute
	{
	}
}
namespace UnityEngine
{
	public interface IAnimationClipSource
	{
		void GetAnimationClips(List<AnimationClip> results);
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	[RequiredByNativeCode]
	public sealed class SharedBetweenAnimatorsAttribute : Attribute
	{
	}
	[RequiredByNativeCode]
	public abstract class StateMachineBehaviour : ScriptableObject
	{
		public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
		}

		public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
		{
		}

		public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash)
		{
		}

		public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
		{
		}

		public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
		{
		}

		public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
		{
		}

		public virtual void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
		{
		}

		public virtual void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
		{
		}

		public virtual void OnStateMachineEnter(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller)
		{
		}

		public virtual void OnStateMachineExit(Animator animator, int stateMachinePathHash, AnimatorControllerPlayable controller)
		{
		}
	}
	public enum PlayMode
	{
		StopSameLayer = 0,
		StopAll = 4
	}
	public enum QueueMode
	{
		CompleteOthers = 0,
		PlayNow = 2
	}
	public enum AnimationBlendMode
	{
		Blend,
		Additive
	}
	public enum AnimationPlayMode
	{
		Stop,
		Queue,
		Mix
	}
	public enum AnimationCullingType
	{
		AlwaysAnimate,
		BasedOnRenderers,
		[Obsolete("Enum member AnimatorCullingMode.BasedOnClipBounds has been deprecated. Use AnimationCullingType.AlwaysAnimate or AnimationCullingType.BasedOnRenderers instead")]
		BasedOnClipBounds,
		[Obsolete("Enum member AnimatorCullingMode.BasedOnUserBounds has been deprecated. Use AnimationCullingType.AlwaysAnimate or AnimationCullingType.BasedOnRenderers instead")]
		BasedOnUserBounds
	}
	public enum AnimationUpdateMode
	{
		Normal,
		Fixed
	}
	internal enum AnimationEventSource
	{
		NoSource,
		Legacy,
		Animator
	}
	[NativeHeader("Modules/Animation/Animation.h")]
	public sealed class Animation : Behaviour, IEnumerable
	{
		private sealed class Enumerator : IEnumerator
		{
			private Animation m_Outer;

			private int m_CurrentIndex = -1;

			public object Current => m_Outer.GetStateAtIndex(m_CurrentIndex);

			internal Enumerator(Animation outer)
			{
				m_Outer = outer;
			}

			public bool MoveNext()
			{
				int stateCount = m_Outer.GetStateCount();
				m_CurrentIndex++;
				return m_CurrentIndex < stateCount;
			}

			public void Reset()
			{
				m_CurrentIndex = -1;
			}
		}

		public AnimationClip clip
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AnimationClip>(get_clip_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_clip_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public bool playAutomatically
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_playAutomatically_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_playAutomatically_Injected(intPtr, value);
			}
		}

		public WrapMode wrapMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wrapMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wrapMode_Injected(intPtr, value);
			}
		}

		public bool isPlaying
		{
			[NativeName("IsPlaying")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isPlaying_Injected(intPtr);
			}
		}

		public AnimationState this[string name] => GetState(name);

		public bool animatePhysics
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_animatePhysics_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_animatePhysics_Injected(intPtr, value);
			}
		}

		public AnimationUpdateMode updateMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_updateMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_updateMode_Injected(intPtr, value);
			}
		}

		[Obsolete("Use cullingType instead")]
		public bool animateOnlyIfVisible
		{
			[FreeFunction("AnimationBindings::GetAnimateOnlyIfVisible", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_animateOnlyIfVisible_Injected(intPtr);
			}
			[FreeFunction("AnimationBindings::SetAnimateOnlyIfVisible", HasExplicitThis = true)]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_animateOnlyIfVisible_Injected(intPtr, value);
			}
		}

		public AnimationCullingType cullingType
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_cullingType_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_cullingType_Injected(intPtr, value);
			}
		}

		public Bounds localBounds
		{
			[NativeName("GetLocalAABB")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_localBounds_Injected(intPtr, out var ret);
				return ret;
			}
			[NativeName("SetLocalAABB")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_localBounds_Injected(intPtr, ref value);
			}
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

		public void Stop(string name)
		{
			StopNamed(name);
		}

		[NativeName("Stop")]
		private unsafe void StopNamed(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						StopNamed_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				StopNamed_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public void Rewind()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Rewind_Injected(intPtr);
		}

		public void Rewind(string name)
		{
			RewindNamed(name);
		}

		[NativeName("Rewind")]
		private unsafe void RewindNamed(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						RewindNamed_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				RewindNamed_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public void Sample()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Sample_Injected(intPtr);
		}

		public unsafe bool IsPlaying(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return IsPlaying_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return IsPlaying_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public bool Play()
		{
			return Play(PlayMode.StopSameLayer);
		}

		public bool Play([UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode)
		{
			return PlayDefaultAnimation(mode);
		}

		[NativeName("Play")]
		private bool PlayDefaultAnimation(PlayMode mode)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return PlayDefaultAnimation_Injected(intPtr, mode);
		}

		[ExcludeFromDocs]
		public bool Play(string animation)
		{
			return Play(animation, PlayMode.StopSameLayer);
		}

		public unsafe bool Play(string animation, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(animation, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(animation);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return Play_Injected(intPtr, ref managedSpanWrapper, mode);
					}
				}
				return Play_Injected(intPtr, ref managedSpanWrapper, mode);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public void CrossFade(string animation)
		{
			CrossFade(animation, 0.3f);
		}

		[ExcludeFromDocs]
		public void CrossFade(string animation, float fadeLength)
		{
			CrossFade(animation, fadeLength, PlayMode.StopSameLayer);
		}

		public unsafe void CrossFade(string animation, [UnityEngine.Internal.DefaultValue("0.3F")] float fadeLength, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(animation, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(animation);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						CrossFade_Injected(intPtr, ref managedSpanWrapper, fadeLength, mode);
						return;
					}
				}
				CrossFade_Injected(intPtr, ref managedSpanWrapper, fadeLength, mode);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public void Blend(string animation)
		{
			Blend(animation, 1f);
		}

		[ExcludeFromDocs]
		public void Blend(string animation, float targetWeight)
		{
			Blend(animation, targetWeight, 0.3f);
		}

		public unsafe void Blend(string animation, [UnityEngine.Internal.DefaultValue("1.0F")] float targetWeight, [UnityEngine.Internal.DefaultValue("0.3F")] float fadeLength)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(animation, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(animation);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						Blend_Injected(intPtr, ref managedSpanWrapper, targetWeight, fadeLength);
						return;
					}
				}
				Blend_Injected(intPtr, ref managedSpanWrapper, targetWeight, fadeLength);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public AnimationState CrossFadeQueued(string animation)
		{
			return CrossFadeQueued(animation, 0.3f);
		}

		[ExcludeFromDocs]
		public AnimationState CrossFadeQueued(string animation, float fadeLength)
		{
			return CrossFadeQueued(animation, fadeLength, QueueMode.CompleteOthers);
		}

		[ExcludeFromDocs]
		public AnimationState CrossFadeQueued(string animation, float fadeLength, QueueMode queue)
		{
			return CrossFadeQueued(animation, fadeLength, queue, PlayMode.StopSameLayer);
		}

		[FreeFunction("AnimationBindings::CrossFadeQueuedImpl", HasExplicitThis = true)]
		[return: Unmarshalled]
		public unsafe AnimationState CrossFadeQueued(string animation, [UnityEngine.Internal.DefaultValue("0.3F")] float fadeLength, [UnityEngine.Internal.DefaultValue("QueueMode.CompleteOthers")] QueueMode queue, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(animation, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(animation);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return CrossFadeQueued_Injected(intPtr, ref managedSpanWrapper, fadeLength, queue, mode);
					}
				}
				return CrossFadeQueued_Injected(intPtr, ref managedSpanWrapper, fadeLength, queue, mode);
			}
			finally
			{
			}
		}

		[ExcludeFromDocs]
		public AnimationState PlayQueued(string animation)
		{
			return PlayQueued(animation, QueueMode.CompleteOthers);
		}

		[ExcludeFromDocs]
		public AnimationState PlayQueued(string animation, QueueMode queue)
		{
			return PlayQueued(animation, queue, PlayMode.StopSameLayer);
		}

		[FreeFunction("AnimationBindings::PlayQueuedImpl", HasExplicitThis = true)]
		[return: Unmarshalled]
		public unsafe AnimationState PlayQueued(string animation, [UnityEngine.Internal.DefaultValue("QueueMode.CompleteOthers")] QueueMode queue, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(animation, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(animation);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return PlayQueued_Injected(intPtr, ref managedSpanWrapper, queue, mode);
					}
				}
				return PlayQueued_Injected(intPtr, ref managedSpanWrapper, queue, mode);
			}
			finally
			{
			}
		}

		public void AddClip(AnimationClip clip, string newName)
		{
			AddClip(clip, newName, int.MinValue, int.MaxValue);
		}

		[ExcludeFromDocs]
		public void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame)
		{
			AddClip(clip, newName, firstFrame, lastFrame, addLoopFrame: false);
		}

		public unsafe void AddClip([NotNull] AnimationClip clip, string newName, int firstFrame, int lastFrame, [UnityEngine.Internal.DefaultValue("false")] bool addLoopFrame)
		{
			//The blocks IL_005d are reachable both inside and outside the pinned region starting at IL_004c. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(clip);
				if (intPtr2 == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(clip, "clip");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(newName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(newName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						AddClip_Injected(intPtr, intPtr2, ref managedSpanWrapper, firstFrame, lastFrame, addLoopFrame);
						return;
					}
				}
				AddClip_Injected(intPtr, intPtr2, ref managedSpanWrapper, firstFrame, lastFrame, addLoopFrame);
			}
			finally
			{
			}
		}

		public void RemoveClip([NotNull] AnimationClip clip)
		{
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(clip);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			RemoveClip_Injected(intPtr, intPtr2);
		}

		public void RemoveClip(string clipName)
		{
			RemoveClipNamed(clipName);
		}

		[NativeName("RemoveClip")]
		private unsafe void RemoveClipNamed(string clipName)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(clipName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(clipName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						RemoveClipNamed_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				RemoveClipNamed_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public int GetClipCount()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetClipCount_Injected(intPtr);
		}

		[Obsolete("use PlayMode instead of AnimationPlayMode.")]
		public bool Play(AnimationPlayMode mode)
		{
			return PlayDefaultAnimation((PlayMode)mode);
		}

		[Obsolete("use PlayMode instead of AnimationPlayMode.")]
		public bool Play(string animation, AnimationPlayMode mode)
		{
			return Play(animation, (PlayMode)mode);
		}

		public void SyncLayer(int layer)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SyncLayer_Injected(intPtr, layer);
		}

		public IEnumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		[FreeFunction("AnimationBindings::GetState", HasExplicitThis = true)]
		[return: Unmarshalled]
		internal unsafe AnimationState GetState(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetState_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetState_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction("AnimationBindings::GetStateAtIndex", HasExplicitThis = true, ThrowsException = true)]
		[return: Unmarshalled]
		internal AnimationState GetStateAtIndex(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetStateAtIndex_Injected(intPtr, index);
		}

		[NativeName("GetAnimationStateCount")]
		internal int GetStateCount()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetStateCount_Injected(intPtr);
		}

		public AnimationClip GetClip(string name)
		{
			AnimationState state = GetState(name);
			if ((bool)state)
			{
				return state.clip;
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_clip_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_clip_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_playAutomatically_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playAutomatically_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern WrapMode get_wrapMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wrapMode_Injected(IntPtr _unity_self, WrapMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Stop_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StopNamed_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Rewind_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RewindNamed_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Sample_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isPlaying_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsPlaying_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool PlayDefaultAnimation_Injected(IntPtr _unity_self, PlayMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool Play_Injected(IntPtr _unity_self, ref ManagedSpanWrapper animation, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CrossFade_Injected(IntPtr _unity_self, ref ManagedSpanWrapper animation, [UnityEngine.Internal.DefaultValue("0.3F")] float fadeLength, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Blend_Injected(IntPtr _unity_self, ref ManagedSpanWrapper animation, [UnityEngine.Internal.DefaultValue("1.0F")] float targetWeight, [UnityEngine.Internal.DefaultValue("0.3F")] float fadeLength);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationState CrossFadeQueued_Injected(IntPtr _unity_self, ref ManagedSpanWrapper animation, [UnityEngine.Internal.DefaultValue("0.3F")] float fadeLength, [UnityEngine.Internal.DefaultValue("QueueMode.CompleteOthers")] QueueMode queue, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationState PlayQueued_Injected(IntPtr _unity_self, ref ManagedSpanWrapper animation, [UnityEngine.Internal.DefaultValue("QueueMode.CompleteOthers")] QueueMode queue, [UnityEngine.Internal.DefaultValue("PlayMode.StopSameLayer")] PlayMode mode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddClip_Injected(IntPtr _unity_self, IntPtr clip, ref ManagedSpanWrapper newName, int firstFrame, int lastFrame, [UnityEngine.Internal.DefaultValue("false")] bool addLoopFrame);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveClip_Injected(IntPtr _unity_self, IntPtr clip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveClipNamed_Injected(IntPtr _unity_self, ref ManagedSpanWrapper clipName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetClipCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SyncLayer_Injected(IntPtr _unity_self, int layer);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationState GetState_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationState GetStateAtIndex_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetStateCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_animatePhysics_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_animatePhysics_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationUpdateMode get_updateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_updateMode_Injected(IntPtr _unity_self, AnimationUpdateMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_animateOnlyIfVisible_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_animateOnlyIfVisible_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationCullingType get_cullingType_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_cullingType_Injected(IntPtr _unity_self, AnimationCullingType value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_localBounds_Injected(IntPtr _unity_self, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_localBounds_Injected(IntPtr _unity_self, [In] ref Bounds value);
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/Animation/AnimationState.h")]
	public sealed class AnimationState : TrackedReference
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(AnimationState animationState)
			{
				return animationState.m_Ptr;
			}
		}

		public bool enabled
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_enabled_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_enabled_Injected(intPtr, value);
			}
		}

		public float weight
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public WrapMode wrapMode
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wrapMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wrapMode_Injected(intPtr, value);
			}
		}

		public float time
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_time_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_time_Injected(intPtr, value);
			}
		}

		public float normalizedTime
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_normalizedTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_normalizedTime_Injected(intPtr, value);
			}
		}

		public float speed
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_speed_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_speed_Injected(intPtr, value);
			}
		}

		public float normalizedSpeed
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_normalizedSpeed_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_normalizedSpeed_Injected(intPtr, value);
			}
		}

		public float length
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_length_Injected(intPtr);
			}
		}

		public int layer
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_layer_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_layer_Injected(intPtr, value);
			}
		}

		public AnimationClip clip
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<AnimationClip>(get_clip_Injected(intPtr));
			}
		}

		public unsafe string name
		{
			get
			{
				ManagedSpanWrapper ret = default(ManagedSpanWrapper);
				string stringAndDispose;
				try
				{
					IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					get_name_Injected(intPtr, out ret);
				}
				finally
				{
					stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
				}
				return stringAndDispose;
			}
			set
			{
				//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
				try
				{
					IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
					if (!StringMarshaller.TryMarshalEmptyOrNullString(value, ref managedSpanWrapper))
					{
						ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(value);
						fixed (char* begin = readOnlySpan)
						{
							managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
							set_name_Injected(intPtr, ref managedSpanWrapper);
							return;
						}
					}
					set_name_Injected(intPtr, ref managedSpanWrapper);
				}
				finally
				{
				}
			}
		}

		public AnimationBlendMode blendMode
		{
			get
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_blendMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_blendMode_Injected(intPtr, value);
			}
		}

		[ExcludeFromDocs]
		public void AddMixingTransform(Transform mix)
		{
			AddMixingTransform(mix, recursive: true);
		}

		public void AddMixingTransform([NotNull] Transform mix, [UnityEngine.Internal.DefaultValue("true")] bool recursive)
		{
			if ((object)mix == null)
			{
				ThrowHelper.ThrowArgumentNullException(mix, "mix");
			}
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(mix);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(mix, "mix");
			}
			AddMixingTransform_Injected(intPtr, intPtr2, recursive);
		}

		public void RemoveMixingTransform([NotNull] Transform mix)
		{
			if ((object)mix == null)
			{
				ThrowHelper.ThrowArgumentNullException(mix, "mix");
			}
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(mix);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(mix, "mix");
			}
			RemoveMixingTransform_Injected(intPtr, intPtr2);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_enabled_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_enabled_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern WrapMode get_wrapMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wrapMode_Injected(IntPtr _unity_self, WrapMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_time_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_time_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_normalizedTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_normalizedTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_speed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_speed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_normalizedSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_normalizedSpeed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_length_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_layer_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_layer_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_clip_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_name_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_name_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationBlendMode get_blendMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_blendMode_Injected(IntPtr _unity_self, AnimationBlendMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddMixingTransform_Injected(IntPtr _unity_self, IntPtr mix, [UnityEngine.Internal.DefaultValue("true")] bool recursive);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveMixingTransform_Injected(IntPtr _unity_self, IntPtr mix);
	}
	[Serializable]
	[RequiredByNativeCode]
	internal struct AnimationEventBlittable : IDisposable
	{
		internal float m_Time;

		internal IntPtr m_FunctionName;

		internal IntPtr m_StringParameter;

		internal IntPtr m_ObjectReferenceParameter;

		internal float m_FloatParameter;

		internal int m_IntParameter;

		internal int m_MessageOptions;

		internal AnimationEventSource m_Source;

		internal IntPtr m_StateSender;

		internal AnimatorStateInfo m_AnimatorStateInfo;

		internal AnimatorClipInfo m_AnimatorClipInfo;

		[ThreadStatic]
		private static GCHandlePool s_handlePool;

		internal static AnimationEventBlittable FromAnimationEvent(AnimationEvent animationEvent)
		{
			if (s_handlePool == null)
			{
				s_handlePool = new GCHandlePool();
			}
			GCHandlePool gCHandlePool = s_handlePool;
			return new AnimationEventBlittable
			{
				m_Time = animationEvent.m_Time,
				m_FunctionName = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_FunctionName),
				m_StringParameter = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_StringParameter),
				m_ObjectReferenceParameter = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_ObjectReferenceParameter),
				m_FloatParameter = animationEvent.m_FloatParameter,
				m_IntParameter = animationEvent.m_IntParameter,
				m_MessageOptions = animationEvent.m_MessageOptions,
				m_Source = animationEvent.m_Source,
				m_StateSender = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_StateSender),
				m_AnimatorStateInfo = animationEvent.m_AnimatorStateInfo,
				m_AnimatorClipInfo = animationEvent.m_AnimatorClipInfo
			};
		}

		internal unsafe static void FromAnimationEvents(AnimationEvent[] animationEvents, AnimationEventBlittable* animationEventBlittables)
		{
			if (s_handlePool == null)
			{
				s_handlePool = new GCHandlePool();
			}
			GCHandlePool gCHandlePool = s_handlePool;
			AnimationEventBlittable* ptr = animationEventBlittables;
			foreach (AnimationEvent animationEvent in animationEvents)
			{
				ptr->m_Time = animationEvent.m_Time;
				ptr->m_FunctionName = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_FunctionName);
				ptr->m_StringParameter = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_StringParameter);
				ptr->m_ObjectReferenceParameter = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_ObjectReferenceParameter);
				ptr->m_FloatParameter = animationEvent.m_FloatParameter;
				ptr->m_IntParameter = animationEvent.m_IntParameter;
				ptr->m_MessageOptions = animationEvent.m_MessageOptions;
				ptr->m_Source = animationEvent.m_Source;
				ptr->m_StateSender = gCHandlePool.AllocHandleIfNotNull(animationEvent.m_StateSender);
				ptr->m_AnimatorStateInfo = animationEvent.m_AnimatorStateInfo;
				ptr->m_AnimatorClipInfo = animationEvent.m_AnimatorClipInfo;
				ptr++;
			}
		}

		[RequiredByNativeCode]
		internal unsafe static AnimationEvent PointerToAnimationEvent(IntPtr animationEventBlittable)
		{
			return ToAnimationEvent(*(AnimationEventBlittable*)(void*)animationEventBlittable);
		}

		internal unsafe static AnimationEvent[] PointerToAnimationEvents(IntPtr animationEventBlittableArray, int size)
		{
			AnimationEvent[] array = new AnimationEvent[size];
			AnimationEventBlittable* ptr = (AnimationEventBlittable*)(void*)animationEventBlittableArray;
			for (int i = 0; i < size; i++)
			{
				array[i] = PointerToAnimationEvent((IntPtr)(ptr + i));
			}
			return array;
		}

		internal unsafe static void DisposeEvents(IntPtr animationEventBlittableArray, int size)
		{
			AnimationEventBlittable* ptr = (AnimationEventBlittable*)(void*)animationEventBlittableArray;
			for (int i = 0; i < size; i++)
			{
				ptr[i].Dispose();
			}
			FreeEventsInternal(animationEventBlittableArray);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction(Name = "AnimationClipBindings::FreeEventsInternal")]
		private static extern void FreeEventsInternal(IntPtr value);

		internal static AnimationEvent ToAnimationEvent(AnimationEventBlittable animationEventBlittable)
		{
			AnimationEvent animationEvent = new AnimationEvent();
			animationEvent.m_Time = animationEventBlittable.m_Time;
			if (animationEventBlittable.m_FunctionName != IntPtr.Zero)
			{
				animationEvent.m_FunctionName = (string)UnsafeUtility.As<IntPtr, GCHandle>(ref animationEventBlittable.m_FunctionName).Target;
			}
			if (animationEventBlittable.m_StringParameter != IntPtr.Zero)
			{
				animationEvent.m_StringParameter = (string)UnsafeUtility.As<IntPtr, GCHandle>(ref animationEventBlittable.m_StringParameter).Target;
			}
			if (animationEventBlittable.m_ObjectReferenceParameter != IntPtr.Zero)
			{
				animationEvent.m_ObjectReferenceParameter = (Object)UnsafeUtility.As<IntPtr, GCHandle>(ref animationEventBlittable.m_ObjectReferenceParameter).Target;
			}
			animationEvent.m_FloatParameter = animationEventBlittable.m_FloatParameter;
			animationEvent.m_IntParameter = animationEventBlittable.m_IntParameter;
			animationEvent.m_MessageOptions = animationEventBlittable.m_MessageOptions;
			animationEvent.m_Source = animationEventBlittable.m_Source;
			if (animationEventBlittable.m_StateSender != IntPtr.Zero)
			{
				animationEvent.m_StateSender = (AnimationState)UnsafeUtility.As<IntPtr, GCHandle>(ref animationEventBlittable.m_StateSender).Target;
			}
			animationEvent.m_AnimatorStateInfo = animationEventBlittable.m_AnimatorStateInfo;
			animationEvent.m_AnimatorClipInfo = animationEventBlittable.m_AnimatorClipInfo;
			return animationEvent;
		}

		public void Dispose()
		{
			if (s_handlePool == null)
			{
				s_handlePool = new GCHandlePool();
			}
			GCHandlePool gCHandlePool = s_handlePool;
			if (m_FunctionName != IntPtr.Zero)
			{
				gCHandlePool.Free(UnsafeUtility.As<IntPtr, GCHandle>(ref m_FunctionName));
			}
			if (m_StringParameter != IntPtr.Zero)
			{
				gCHandlePool.Free(UnsafeUtility.As<IntPtr, GCHandle>(ref m_StringParameter));
			}
			if (m_ObjectReferenceParameter != IntPtr.Zero)
			{
				gCHandlePool.Free(UnsafeUtility.As<IntPtr, GCHandle>(ref m_ObjectReferenceParameter));
			}
			if (m_StateSender != IntPtr.Zero)
			{
				gCHandlePool.Free(UnsafeUtility.As<IntPtr, GCHandle>(ref m_StateSender));
			}
		}
	}
	[Serializable]
	[RequiredByNativeCode]
	public sealed class AnimationEvent
	{
		internal float m_Time;

		internal string m_FunctionName;

		internal string m_StringParameter;

		internal Object m_ObjectReferenceParameter;

		internal float m_FloatParameter;

		internal int m_IntParameter;

		internal int m_MessageOptions;

		internal AnimationEventSource m_Source;

		internal AnimationState m_StateSender;

		internal AnimatorStateInfo m_AnimatorStateInfo;

		internal AnimatorClipInfo m_AnimatorClipInfo;

		[Obsolete("Use stringParameter instead")]
		public string data
		{
			get
			{
				return m_StringParameter;
			}
			set
			{
				m_StringParameter = value;
			}
		}

		public string stringParameter
		{
			get
			{
				return m_StringParameter;
			}
			set
			{
				m_StringParameter = value;
			}
		}

		public float floatParameter
		{
			get
			{
				return m_FloatParameter;
			}
			set
			{
				m_FloatParameter = value;
			}
		}

		public int intParameter
		{
			get
			{
				return m_IntParameter;
			}
			set
			{
				m_IntParameter = value;
			}
		}

		public Object objectReferenceParameter
		{
			get
			{
				return m_ObjectReferenceParameter;
			}
			set
			{
				m_ObjectReferenceParameter = value;
			}
		}

		public string functionName
		{
			get
			{
				return m_FunctionName;
			}
			set
			{
				m_FunctionName = value;
			}
		}

		public float time
		{
			get
			{
				return m_Time;
			}
			set
			{
				m_Time = value;
			}
		}

		public SendMessageOptions messageOptions
		{
			get
			{
				return (SendMessageOptions)m_MessageOptions;
			}
			set
			{
				m_MessageOptions = (int)value;
			}
		}

		public bool isFiredByLegacy => m_Source == AnimationEventSource.Legacy;

		public bool isFiredByAnimator => m_Source == AnimationEventSource.Animator;

		public AnimationState animationState
		{
			get
			{
				if (!isFiredByLegacy)
				{
					Debug.LogError("AnimationEvent was not fired by Animation component, you shouldn't use AnimationEvent.animationState");
				}
				return m_StateSender;
			}
		}

		public AnimatorStateInfo animatorStateInfo
		{
			get
			{
				if (!isFiredByAnimator)
				{
					Debug.LogError("AnimationEvent was not fired by Animator component, you shouldn't use AnimationEvent.animatorStateInfo");
				}
				return m_AnimatorStateInfo;
			}
		}

		public AnimatorClipInfo animatorClipInfo
		{
			get
			{
				if (!isFiredByAnimator)
				{
					Debug.LogError("AnimationEvent was not fired by Animator component, you shouldn't use AnimationEvent.animatorClipInfo");
				}
				return m_AnimatorClipInfo;
			}
		}

		public AnimationEvent()
		{
			m_Time = 0f;
			m_FunctionName = "";
			m_StringParameter = "";
			m_ObjectReferenceParameter = null;
			m_FloatParameter = 0f;
			m_IntParameter = 0;
			m_MessageOptions = 0;
			m_Source = AnimationEventSource.NoSource;
			m_StateSender = null;
		}

		internal int GetHash()
		{
			int num = 0;
			num = functionName.GetHashCode();
			return 33 * num + time.GetHashCode();
		}
	}
	[NativeType("Modules/Animation/AnimationClip.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationClip.bindings.h")]
	public sealed class AnimationClip : Motion
	{
		[NativeProperty("Length", false, TargetType.Function)]
		public float length
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_length_Injected(intPtr);
			}
		}

		[NativeProperty("StartTime", false, TargetType.Function)]
		internal float startTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_startTime_Injected(intPtr);
			}
		}

		[NativeProperty("StopTime", false, TargetType.Function)]
		internal float stopTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_stopTime_Injected(intPtr);
			}
		}

		[NativeProperty("SampleRate", false, TargetType.Function)]
		public float frameRate
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_frameRate_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_frameRate_Injected(intPtr, value);
			}
		}

		[NativeProperty("WrapMode", false, TargetType.Function)]
		public WrapMode wrapMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_wrapMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_wrapMode_Injected(intPtr, value);
			}
		}

		[NativeProperty("Bounds", false, TargetType.Function)]
		public Bounds localBounds
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_localBounds_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_localBounds_Injected(intPtr, ref value);
			}
		}

		public new bool legacy
		{
			[NativeMethod("IsLegacy")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_legacy_Injected(intPtr);
			}
			[NativeMethod("SetLegacy")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_legacy_Injected(intPtr, value);
			}
		}

		public bool humanMotion
		{
			[NativeMethod("IsHumanMotion")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_humanMotion_Injected(intPtr);
			}
		}

		public bool empty
		{
			[NativeMethod("IsEmpty")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_empty_Injected(intPtr);
			}
		}

		public bool hasGenericRootTransform
		{
			[NativeMethod("HasGenericRootTransform")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasGenericRootTransform_Injected(intPtr);
			}
		}

		public bool hasMotionFloatCurves
		{
			[NativeMethod("HasMotionFloatCurves")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasMotionFloatCurves_Injected(intPtr);
			}
		}

		public bool hasMotionCurves
		{
			[NativeMethod("HasMotionCurves")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasMotionCurves_Injected(intPtr);
			}
		}

		public bool hasRootCurves
		{
			[NativeMethod("HasRootCurves")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasRootCurves_Injected(intPtr);
			}
		}

		internal bool hasRootMotion
		{
			[FreeFunction(Name = "AnimationClipBindings::Internal_GetHasRootMotion", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasRootMotion_Injected(intPtr);
			}
		}

		public unsafe AnimationEvent[] events
		{
			get
			{
				GetEventsInternal(out var values, out var size);
				AnimationEvent[] result = AnimationEventBlittable.PointerToAnimationEvents(values, size);
				AnimationEventBlittable.DisposeEvents(values, size);
				return result;
			}
			set
			{
				using NativeArray<AnimationEventBlittable> nativeArray = new NativeArray<AnimationEventBlittable>(value.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				AnimationEventBlittable* ptr = (AnimationEventBlittable*)nativeArray.GetUnsafePtr();
				AnimationEventBlittable.FromAnimationEvents(value, ptr);
				SetEventsInternal(ptr, nativeArray.Length);
				for (int i = 0; i < value.Length; i++)
				{
					ptr->Dispose();
					ptr++;
				}
			}
		}

		public AnimationClip()
		{
			Internal_CreateAnimationClip(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("AnimationClipBindings::Internal_CreateAnimationClip")]
		private static extern void Internal_CreateAnimationClip([Writable] AnimationClip self);

		public void SampleAnimation(GameObject go, float time)
		{
			SampleAnimation(go, this, time, wrapMode);
		}

		[FreeFunction]
		[NativeHeader("Modules/Animation/AnimationUtility.h")]
		internal static void SampleAnimation([NotNull] GameObject go, [NotNull] AnimationClip clip, float inTime, WrapMode wrapMode)
		{
			if ((object)go == null)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(go);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(clip);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			SampleAnimation_Injected(intPtr, intPtr2, inTime, wrapMode);
		}

		[FreeFunction("AnimationClipBindings::Internal_SetCurve", HasExplicitThis = true)]
		public unsafe void SetCurve([NotNull] string relativePath, [NotNull] Type type, [NotNull] string propertyName, AnimationCurve curve)
		{
			//The blocks IL_0066, IL_0074, IL_0082, IL_0090, IL_0095, IL_009c, IL_00a5, IL_00a8 are reachable both inside and outside the pinned region starting at IL_0055. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0095, IL_009c, IL_00a5, IL_00a8 are reachable both inside and outside the pinned region starting at IL_0082. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0095, IL_009c, IL_00a5, IL_00a8 are reachable both inside and outside the pinned region starting at IL_0082. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if (relativePath == null)
			{
				ThrowHelper.ThrowArgumentNullException(relativePath, "relativePath");
			}
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException(type, "type");
			}
			if (propertyName == null)
			{
				ThrowHelper.ThrowArgumentNullException(propertyName, "propertyName");
			}
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper relativePath2;
				Type type2;
				ManagedSpanWrapper managedSpanWrapper2 = default(ManagedSpanWrapper);
				ReadOnlySpan<char> readOnlySpan2;
				ref ManagedSpanWrapper propertyName2;
				IntPtr curve2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(relativePath, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(relativePath);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						relativePath2 = ref managedSpanWrapper;
						type2 = type;
						if (!StringMarshaller.TryMarshalEmptyOrNullString(propertyName, ref managedSpanWrapper2))
						{
							readOnlySpan2 = MemoryExtensions.AsSpan(propertyName);
							fixed (char* begin2 = readOnlySpan2)
							{
								managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
								propertyName2 = ref managedSpanWrapper2;
								curve2 = ((curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
								SetCurve_Injected(intPtr, ref relativePath2, type2, ref propertyName2, curve2);
								return;
							}
						}
						propertyName2 = ref managedSpanWrapper2;
						curve2 = ((curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
						SetCurve_Injected(intPtr, ref relativePath2, type2, ref propertyName2, curve2);
						return;
					}
				}
				relativePath2 = ref managedSpanWrapper;
				type2 = type;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(propertyName, ref managedSpanWrapper2))
				{
					readOnlySpan2 = MemoryExtensions.AsSpan(propertyName);
					fixed (char* begin2 = readOnlySpan2)
					{
						managedSpanWrapper2 = new ManagedSpanWrapper(begin2, readOnlySpan2.Length);
						propertyName2 = ref managedSpanWrapper2;
						curve2 = ((curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
						SetCurve_Injected(intPtr, ref relativePath2, type2, ref propertyName2, curve2);
						return;
					}
				}
				propertyName2 = ref managedSpanWrapper2;
				curve2 = ((curve == null) ? ((IntPtr)0) : AnimationCurve.BindingsMarshaller.ConvertToNative(curve));
				SetCurve_Injected(intPtr, ref relativePath2, type2, ref propertyName2, curve2);
			}
			finally
			{
			}
		}

		public void EnsureQuaternionContinuity()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			EnsureQuaternionContinuity_Injected(intPtr);
		}

		public void ClearCurves()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearCurves_Injected(intPtr);
		}

		public void AddEvent(AnimationEvent evt)
		{
			if (evt == null)
			{
				throw new ArgumentNullException("evt");
			}
			AnimationEventBlittable animationEventBlittable = AnimationEventBlittable.FromAnimationEvent(evt);
			AddEventInternal(animationEventBlittable);
			animationEventBlittable.Dispose();
		}

		[FreeFunction(Name = "AnimationClipBindings::AddEventInternal", HasExplicitThis = true)]
		private void AddEventInternal(object evt)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddEventInternal_Injected(intPtr, evt);
		}

		[FreeFunction(Name = "AnimationClipBindings::SetEventsInternal", HasExplicitThis = true)]
		private unsafe void SetEventsInternal(void* data, int length)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetEventsInternal_Injected(intPtr, data, length);
		}

		[FreeFunction(Name = "AnimationClipBindings::GetEventsInternal", HasExplicitThis = true)]
		private void GetEventsInternal(out IntPtr values, out int size)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetEventsInternal_Injected(intPtr, out values, out size);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SampleAnimation_Injected(IntPtr go, IntPtr clip, float inTime, WrapMode wrapMode);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_length_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_startTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_stopTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_frameRate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_frameRate_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetCurve_Injected(IntPtr _unity_self, ref ManagedSpanWrapper relativePath, Type type, ref ManagedSpanWrapper propertyName, IntPtr curve);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EnsureQuaternionContinuity_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearCurves_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern WrapMode get_wrapMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_wrapMode_Injected(IntPtr _unity_self, WrapMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_localBounds_Injected(IntPtr _unity_self, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_localBounds_Injected(IntPtr _unity_self, [In] ref Bounds value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_legacy_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_legacy_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_humanMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_empty_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasGenericRootTransform_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasMotionFloatCurves_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasMotionCurves_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasRootCurves_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasRootMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddEventInternal_Injected(IntPtr _unity_self, object evt);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void SetEventsInternal_Injected(IntPtr _unity_self, void* data, int length);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetEventsInternal_Injected(IntPtr _unity_self, out IntPtr values, out int size);
	}
	internal class GCHandlePool
	{
		private GCHandle[] m_handles;

		private int m_current;

		public GCHandlePool()
		{
			m_handles = new GCHandle[128];
		}

		public GCHandle Alloc()
		{
			if (m_current > 0)
			{
				return m_handles[--m_current];
			}
			return GCHandle.Alloc(null);
		}

		public GCHandle Alloc(object o)
		{
			if (m_current > 0)
			{
				GCHandle result = m_handles[--m_current];
				result.Target = o;
				return result;
			}
			return GCHandle.Alloc(o);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IntPtr AllocHandleIfNotNull(object o)
		{
			if (o == null)
			{
				return IntPtr.Zero;
			}
			return (IntPtr)Alloc(o);
		}

		public void Free(GCHandle h)
		{
			if (m_current == m_handles.Length)
			{
				int num = m_handles.Length * 2;
				GCHandle[] array = new GCHandle[num];
				Array.Copy(m_handles, array, m_handles.Length);
				m_handles = array;
			}
			h.Target = null;
			m_handles[m_current++] = h;
		}
	}
	public enum AvatarTarget
	{
		Root,
		Body,
		LeftFoot,
		RightFoot,
		LeftHand,
		RightHand
	}
	public enum AvatarIKGoal
	{
		LeftFoot,
		RightFoot,
		LeftHand,
		RightHand
	}
	public enum AvatarIKHint
	{
		LeftKnee,
		RightKnee,
		LeftElbow,
		RightElbow
	}
	public enum AnimatorControllerParameterType
	{
		Float = 1,
		Int = 3,
		Bool = 4,
		Trigger = 9
	}
	internal static class AnimatorControllerParameterTypeConstants
	{
		public const int InvalidType = 0;
	}
	internal enum TransitionType
	{
		Normal = 1,
		Entry = 2,
		Exit = 4
	}
	internal enum StateInfoIndex
	{
		CurrentState,
		NextState,
		ExitState,
		InterruptedState
	}
	public enum AnimatorRecorderMode
	{
		Offline,
		Playback,
		Record
	}
	public enum DurationUnit
	{
		Fixed,
		Normalized
	}
	public enum AnimatorCullingMode
	{
		AlwaysAnimate,
		CullUpdateTransforms,
		CullCompletely
	}
	public enum AnimatorUpdateMode
	{
		Normal,
		Fixed,
		UnscaledTime
	}
	[NativeHeader("Modules/Animation/AnimatorInfo.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
	[UsedByNativeCode]
	public struct AnimatorClipInfo
	{
		private int m_ClipInstanceID;

		private float m_Weight;

		public AnimationClip clip => (m_ClipInstanceID != 0) ? InstanceIDToAnimationClipPPtr(m_ClipInstanceID) : null;

		public float weight => m_Weight;

		[FreeFunction("AnimationBindings::InstanceIDToAnimationClipPPtr")]
		private static AnimationClip InstanceIDToAnimationClipPPtr(EntityId entityId)
		{
			return Unmarshal.UnmarshalUnityObject<AnimationClip>(InstanceIDToAnimationClipPPtr_Injected(ref entityId));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InstanceIDToAnimationClipPPtr_Injected([In] ref EntityId entityId);
	}
	[NativeHeader("Modules/Animation/AnimatorInfo.h")]
	[RequiredByNativeCode]
	public struct AnimatorStateInfo
	{
		private int m_Name;

		private int m_Path;

		private int m_FullPath;

		private float m_NormalizedTime;

		private float m_Length;

		private float m_Speed;

		private float m_SpeedMultiplier;

		private int m_Tag;

		private int m_Loop;

		public int fullPathHash => m_FullPath;

		[Obsolete("AnimatorStateInfo.nameHash has been deprecated. Use AnimatorStateInfo.fullPathHash instead.")]
		public int nameHash => m_Path;

		public int shortNameHash => m_Name;

		public float normalizedTime => m_NormalizedTime;

		public float length => m_Length;

		public float speed => m_Speed;

		public float speedMultiplier => m_SpeedMultiplier;

		public int tagHash => m_Tag;

		public bool loop => m_Loop != 0;

		public bool IsName(string name)
		{
			int num = Animator.StringToHash(name);
			return num == m_FullPath || num == m_Name || num == m_Path;
		}

		public bool IsTag(string tag)
		{
			return Animator.StringToHash(tag) == m_Tag;
		}
	}
	[RequiredByNativeCode]
	[NativeHeader("Modules/Animation/AnimatorInfo.h")]
	public struct AnimatorTransitionInfo
	{
		[NativeName("fullPathHash")]
		private int m_FullPath;

		[NativeName("userNameHash")]
		private int m_UserName;

		[NativeName("nameHash")]
		private int m_Name;

		[NativeName("hasFixedDuration")]
		private bool m_HasFixedDuration;

		[NativeName("duration")]
		private float m_Duration;

		[NativeName("normalizedTime")]
		private float m_NormalizedTime;

		[NativeName("anyState")]
		private bool m_AnyState;

		[NativeName("transitionType")]
		private int m_TransitionType;

		public int fullPathHash => m_FullPath;

		public int nameHash => m_Name;

		public int userNameHash => m_UserName;

		public DurationUnit durationUnit => (!m_HasFixedDuration) ? DurationUnit.Normalized : DurationUnit.Fixed;

		public float duration => m_Duration;

		public float normalizedTime => m_NormalizedTime;

		public bool anyState => m_AnyState;

		internal bool entry => (m_TransitionType & 2) != 0;

		internal bool exit => (m_TransitionType & 4) != 0;

		public bool IsName(string name)
		{
			return Animator.StringToHash(name) == m_Name || Animator.StringToHash(name) == m_FullPath;
		}

		public bool IsUserName(string name)
		{
			return Animator.StringToHash(name) == m_UserName;
		}
	}
	[NativeHeader("Modules/Animation/Animator.h")]
	public struct MatchTargetWeightMask(Vector3 positionXYZWeight, float rotationWeight)
	{
		private Vector3 m_PositionXYZWeight = positionXYZWeight;

		private float m_RotationWeight = rotationWeight;

		public Vector3 positionXYZWeight
		{
			get
			{
				return m_PositionXYZWeight;
			}
			set
			{
				m_PositionXYZWeight = value;
			}
		}

		public float rotationWeight
		{
			get
			{
				return m_RotationWeight;
			}
			set
			{
				m_RotationWeight = value;
			}
		}
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerParameter.bindings.h")]
	[NativeHeader("Modules/Animation/Animator.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animator.bindings.h")]
	public class Animator : Behaviour
	{
		public bool isOptimizable
		{
			[NativeMethod("IsOptimizable")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isOptimizable_Injected(intPtr);
			}
		}

		public bool isHuman
		{
			[NativeMethod("IsHuman")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isHuman_Injected(intPtr);
			}
		}

		public bool hasRootMotion
		{
			[NativeMethod("HasRootMotion")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasRootMotion_Injected(intPtr);
			}
		}

		internal bool isRootPositionOrRotationControlledByCurves
		{
			[NativeMethod("IsRootTranslationOrRotationControllerByCurves")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isRootPositionOrRotationControlledByCurves_Injected(intPtr);
			}
		}

		public float humanScale
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_humanScale_Injected(intPtr);
			}
		}

		public bool isInitialized
		{
			[NativeMethod("IsInitialized")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isInitialized_Injected(intPtr);
			}
		}

		public Vector3 deltaPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_deltaPosition_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Quaternion deltaRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_deltaRotation_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Vector3 velocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_velocity_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Vector3 angularVelocity
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_angularVelocity_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Vector3 rootPosition
		{
			[NativeMethod("GetAvatarPosition")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rootPosition_Injected(intPtr, out var ret);
				return ret;
			}
			[NativeMethod("SetAvatarPosition")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rootPosition_Injected(intPtr, ref value);
			}
		}

		public Quaternion rootRotation
		{
			[NativeMethod("GetAvatarRotation")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rootRotation_Injected(intPtr, out var ret);
				return ret;
			}
			[NativeMethod("SetAvatarRotation")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rootRotation_Injected(intPtr, ref value);
			}
		}

		public bool applyRootMotion
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_applyRootMotion_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_applyRootMotion_Injected(intPtr, value);
			}
		}

		[Obsolete("Animator.linearVelocityBlending is no longer used and has been deprecated.")]
		public bool linearVelocityBlending
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_linearVelocityBlending_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_linearVelocityBlending_Injected(intPtr, value);
			}
		}

		public bool animatePhysics
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_animatePhysics_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_animatePhysics_Injected(intPtr, value);
			}
		}

		public AnimatorUpdateMode updateMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_updateMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_updateMode_Injected(intPtr, value);
			}
		}

		public bool hasTransformHierarchy
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasTransformHierarchy_Injected(intPtr);
			}
		}

		internal bool allowConstantClipSamplingOptimization
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_allowConstantClipSamplingOptimization_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_allowConstantClipSamplingOptimization_Injected(intPtr, value);
			}
		}

		public float gravityWeight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_gravityWeight_Injected(intPtr);
			}
		}

		public Vector3 bodyPosition
		{
			get
			{
				CheckIfInIKPass();
				return bodyPositionInternal;
			}
			set
			{
				CheckIfInIKPass();
				bodyPositionInternal = value;
			}
		}

		internal Vector3 bodyPositionInternal
		{
			[NativeMethod("GetBodyPosition")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_bodyPositionInternal_Injected(intPtr, out var ret);
				return ret;
			}
			[NativeMethod("SetBodyPosition")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bodyPositionInternal_Injected(intPtr, ref value);
			}
		}

		public Quaternion bodyRotation
		{
			get
			{
				CheckIfInIKPass();
				return bodyRotationInternal;
			}
			set
			{
				CheckIfInIKPass();
				bodyRotationInternal = value;
			}
		}

		internal Quaternion bodyRotationInternal
		{
			[NativeMethod("GetBodyRotation")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_bodyRotationInternal_Injected(intPtr, out var ret);
				return ret;
			}
			[NativeMethod("SetBodyRotation")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_bodyRotationInternal_Injected(intPtr, ref value);
			}
		}

		public bool stabilizeFeet
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_stabilizeFeet_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_stabilizeFeet_Injected(intPtr, value);
			}
		}

		public int layerCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_layerCount_Injected(intPtr);
			}
		}

		public AnimatorControllerParameter[] parameters
		{
			[FreeFunction(Name = "AnimatorBindings::GetParameters", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_parameters_Injected(intPtr);
			}
		}

		public int parameterCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_parameterCount_Injected(intPtr);
			}
		}

		public float feetPivotActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_feetPivotActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_feetPivotActive_Injected(intPtr, value);
			}
		}

		public float pivotWeight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_pivotWeight_Injected(intPtr);
			}
		}

		public Vector3 pivotPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_pivotPosition_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public bool isMatchingTarget
		{
			[NativeMethod("IsMatchingTarget")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isMatchingTarget_Injected(intPtr);
			}
		}

		public float speed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_speed_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_speed_Injected(intPtr, value);
			}
		}

		public Vector3 targetPosition
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetPosition_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Quaternion targetRotation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_targetRotation_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public Transform avatarRoot
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Transform>(get_avatarRoot_Injected(intPtr));
			}
		}

		public AnimatorCullingMode cullingMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_cullingMode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_cullingMode_Injected(intPtr, value);
			}
		}

		public float playbackTime
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_playbackTime_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_playbackTime_Injected(intPtr, value);
			}
		}

		public float recorderStartTime
		{
			get
			{
				return GetRecorderStartTime();
			}
			set
			{
			}
		}

		public float recorderStopTime
		{
			get
			{
				return GetRecorderStopTime();
			}
			set
			{
			}
		}

		public AnimatorRecorderMode recorderMode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_recorderMode_Injected(intPtr);
			}
		}

		public RuntimeAnimatorController runtimeAnimatorController
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<RuntimeAnimatorController>(get_runtimeAnimatorController_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_runtimeAnimatorController_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public bool hasBoundPlayables
		{
			[NativeMethod("HasBoundPlayables")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasBoundPlayables_Injected(intPtr);
			}
		}

		public Avatar avatar
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Avatar>(get_avatar_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_avatar_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public PlayableGraph playableGraph
		{
			get
			{
				PlayableGraph graph = default(PlayableGraph);
				GetCurrentGraph(ref graph);
				return graph;
			}
		}

		public bool layersAffectMassCenter
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_layersAffectMassCenter_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_layersAffectMassCenter_Injected(intPtr, value);
			}
		}

		public float leftFeetBottomHeight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_leftFeetBottomHeight_Injected(intPtr);
			}
		}

		public float rightFeetBottomHeight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rightFeetBottomHeight_Injected(intPtr);
			}
		}

		[NativeConditional("UNITY_EDITOR")]
		internal bool supportsOnAnimatorMove
		{
			[NativeMethod("SupportsOnAnimatorMove")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_supportsOnAnimatorMove_Injected(intPtr);
			}
		}

		public bool logWarnings
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_logWarnings_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_logWarnings_Injected(intPtr, value);
			}
		}

		public bool fireEvents
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_fireEvents_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_fireEvents_Injected(intPtr, value);
			}
		}

		[Obsolete("keepAnimatorControllerStateOnDisable is deprecated, use keepAnimatorStateOnDisable instead. (UnityUpgradable) -> keepAnimatorStateOnDisable", false)]
		public bool keepAnimatorControllerStateOnDisable
		{
			get
			{
				return keepAnimatorStateOnDisable;
			}
			set
			{
				keepAnimatorStateOnDisable = value;
			}
		}

		public bool keepAnimatorStateOnDisable
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_keepAnimatorStateOnDisable_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_keepAnimatorStateOnDisable_Injected(intPtr, value);
			}
		}

		public bool writeDefaultValuesOnDisable
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_writeDefaultValuesOnDisable_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_writeDefaultValuesOnDisable_Injected(intPtr, value);
			}
		}

		public float GetFloat(string name)
		{
			return GetFloatString(name);
		}

		public float GetFloat(int id)
		{
			return GetFloatID(id);
		}

		public void SetFloat(string name, float value)
		{
			SetFloatString(name, value);
		}

		public void SetFloat(string name, float value, float dampTime, float deltaTime)
		{
			SetFloatStringDamp(name, value, dampTime, deltaTime);
		}

		public void SetFloat(int id, float value)
		{
			SetFloatID(id, value);
		}

		public void SetFloat(int id, float value, float dampTime, float deltaTime)
		{
			SetFloatIDDamp(id, value, dampTime, deltaTime);
		}

		public bool GetBool(string name)
		{
			return GetBoolString(name);
		}

		public bool GetBool(int id)
		{
			return GetBoolID(id);
		}

		public void SetBool(string name, bool value)
		{
			SetBoolString(name, value);
		}

		public void SetBool(int id, bool value)
		{
			SetBoolID(id, value);
		}

		public int GetInteger(string name)
		{
			return GetIntegerString(name);
		}

		public int GetInteger(int id)
		{
			return GetIntegerID(id);
		}

		public void SetInteger(string name, int value)
		{
			SetIntegerString(name, value);
		}

		public void SetInteger(int id, int value)
		{
			SetIntegerID(id, value);
		}

		public void SetTrigger(string name)
		{
			SetTriggerString(name);
		}

		public void SetTrigger(int id)
		{
			SetTriggerID(id);
		}

		public void ResetTrigger(string name)
		{
			ResetTriggerString(name);
		}

		public void ResetTrigger(int id)
		{
			ResetTriggerID(id);
		}

		public bool IsParameterControlledByCurve(string name)
		{
			return IsParameterControlledByCurveString(name);
		}

		public bool IsParameterControlledByCurve(int id)
		{
			return IsParameterControlledByCurveID(id);
		}

		public Vector3 GetIKPosition(AvatarIKGoal goal)
		{
			CheckIfInIKPass();
			return GetGoalPosition(goal);
		}

		private Vector3 GetGoalPosition(AvatarIKGoal goal)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetGoalPosition_Injected(intPtr, goal, out var ret);
			return ret;
		}

		public void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition)
		{
			CheckIfInIKPass();
			SetGoalPosition(goal, goalPosition);
		}

		private void SetGoalPosition(AvatarIKGoal goal, Vector3 goalPosition)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetGoalPosition_Injected(intPtr, goal, ref goalPosition);
		}

		public Quaternion GetIKRotation(AvatarIKGoal goal)
		{
			CheckIfInIKPass();
			return GetGoalRotation(goal);
		}

		private Quaternion GetGoalRotation(AvatarIKGoal goal)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetGoalRotation_Injected(intPtr, goal, out var ret);
			return ret;
		}

		public void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation)
		{
			CheckIfInIKPass();
			SetGoalRotation(goal, goalRotation);
		}

		private void SetGoalRotation(AvatarIKGoal goal, Quaternion goalRotation)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetGoalRotation_Injected(intPtr, goal, ref goalRotation);
		}

		public float GetIKPositionWeight(AvatarIKGoal goal)
		{
			CheckIfInIKPass();
			return GetGoalWeightPosition(goal);
		}

		private float GetGoalWeightPosition(AvatarIKGoal goal)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetGoalWeightPosition_Injected(intPtr, goal);
		}

		public void SetIKPositionWeight(AvatarIKGoal goal, float value)
		{
			CheckIfInIKPass();
			SetGoalWeightPosition(goal, value);
		}

		private void SetGoalWeightPosition(AvatarIKGoal goal, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetGoalWeightPosition_Injected(intPtr, goal, value);
		}

		public float GetIKRotationWeight(AvatarIKGoal goal)
		{
			CheckIfInIKPass();
			return GetGoalWeightRotation(goal);
		}

		private float GetGoalWeightRotation(AvatarIKGoal goal)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetGoalWeightRotation_Injected(intPtr, goal);
		}

		public void SetIKRotationWeight(AvatarIKGoal goal, float value)
		{
			CheckIfInIKPass();
			SetGoalWeightRotation(goal, value);
		}

		private void SetGoalWeightRotation(AvatarIKGoal goal, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetGoalWeightRotation_Injected(intPtr, goal, value);
		}

		public Vector3 GetIKHintPosition(AvatarIKHint hint)
		{
			CheckIfInIKPass();
			return GetHintPosition(hint);
		}

		private Vector3 GetHintPosition(AvatarIKHint hint)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetHintPosition_Injected(intPtr, hint, out var ret);
			return ret;
		}

		public void SetIKHintPosition(AvatarIKHint hint, Vector3 hintPosition)
		{
			CheckIfInIKPass();
			SetHintPosition(hint, hintPosition);
		}

		private void SetHintPosition(AvatarIKHint hint, Vector3 hintPosition)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetHintPosition_Injected(intPtr, hint, ref hintPosition);
		}

		public float GetIKHintPositionWeight(AvatarIKHint hint)
		{
			CheckIfInIKPass();
			return GetHintWeightPosition(hint);
		}

		private float GetHintWeightPosition(AvatarIKHint hint)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetHintWeightPosition_Injected(intPtr, hint);
		}

		public void SetIKHintPositionWeight(AvatarIKHint hint, float value)
		{
			CheckIfInIKPass();
			SetHintWeightPosition(hint, value);
		}

		private void SetHintWeightPosition(AvatarIKHint hint, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetHintWeightPosition_Injected(intPtr, hint, value);
		}

		public void SetLookAtPosition(Vector3 lookAtPosition)
		{
			CheckIfInIKPass();
			SetLookAtPositionInternal(lookAtPosition);
		}

		[NativeMethod("SetLookAtPosition")]
		private void SetLookAtPositionInternal(Vector3 lookAtPosition)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetLookAtPositionInternal_Injected(intPtr, ref lookAtPosition);
		}

		public void SetLookAtWeight(float weight)
		{
			CheckIfInIKPass();
			SetLookAtWeightInternal(weight, 0f, 1f, 0f, 0.5f);
		}

		public void SetLookAtWeight(float weight, float bodyWeight)
		{
			CheckIfInIKPass();
			SetLookAtWeightInternal(weight, bodyWeight, 1f, 0f, 0.5f);
		}

		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight)
		{
			CheckIfInIKPass();
			SetLookAtWeightInternal(weight, bodyWeight, headWeight, 0f, 0.5f);
		}

		public void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight)
		{
			CheckIfInIKPass();
			SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, 0.5f);
		}

		public void SetLookAtWeight(float weight, [UnityEngine.Internal.DefaultValue("0.0f")] float bodyWeight, [UnityEngine.Internal.DefaultValue("1.0f")] float headWeight, [UnityEngine.Internal.DefaultValue("0.0f")] float eyesWeight, [UnityEngine.Internal.DefaultValue("0.5f")] float clampWeight)
		{
			CheckIfInIKPass();
			SetLookAtWeightInternal(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
		}

		[NativeMethod("SetLookAtWeight")]
		private void SetLookAtWeightInternal(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetLookAtWeightInternal_Injected(intPtr, weight, bodyWeight, headWeight, eyesWeight, clampWeight);
		}

		public void SetBoneLocalRotation(HumanBodyBones humanBoneId, Quaternion rotation)
		{
			CheckIfInIKPass();
			SetBoneLocalRotationInternal(HumanTrait.GetBoneIndexFromMono((int)humanBoneId), rotation);
		}

		[NativeMethod("SetBoneLocalRotation")]
		private void SetBoneLocalRotationInternal(int humanBoneId, Quaternion rotation)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetBoneLocalRotationInternal_Injected(intPtr, humanBoneId, ref rotation);
		}

		private ScriptableObject GetBehaviour([NotNull] Type type)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException(type, "type");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<ScriptableObject>(GetBehaviour_Injected(intPtr, type));
		}

		public T GetBehaviour<T>() where T : StateMachineBehaviour
		{
			return GetBehaviour(typeof(T)) as T;
		}

		private static T[] ConvertStateMachineBehaviour<T>(ScriptableObject[] rawObjects) where T : StateMachineBehaviour
		{
			if (rawObjects == null)
			{
				return null;
			}
			T[] array = new T[rawObjects.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (T)rawObjects[i];
			}
			return array;
		}

		public T[] GetBehaviours<T>() where T : StateMachineBehaviour
		{
			return ConvertStateMachineBehaviour<T>(InternalGetBehaviours(typeof(T)));
		}

		[FreeFunction(Name = "AnimatorBindings::InternalGetBehaviours", HasExplicitThis = true)]
		internal ScriptableObject[] InternalGetBehaviours([NotNull] Type type)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException(type, "type");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return InternalGetBehaviours_Injected(intPtr, type);
		}

		public StateMachineBehaviour[] GetBehaviours(int fullPathHash, int layerIndex)
		{
			return InternalGetBehavioursByKey(fullPathHash, layerIndex, typeof(StateMachineBehaviour)) as StateMachineBehaviour[];
		}

		[FreeFunction(Name = "AnimatorBindings::InternalGetBehavioursByKey", HasExplicitThis = true)]
		internal ScriptableObject[] InternalGetBehavioursByKey(int fullPathHash, int layerIndex, [NotNull] Type type)
		{
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException(type, "type");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return InternalGetBehavioursByKey_Injected(intPtr, fullPathHash, layerIndex, type);
		}

		public string GetLayerName(int layerIndex)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetLayerName_Injected(intPtr, layerIndex, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public unsafe int GetLayerIndex(string layerName)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(layerName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(layerName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetLayerIndex_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetLayerIndex_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		public float GetLayerWeight(int layerIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetLayerWeight_Injected(intPtr, layerIndex);
		}

		public void SetLayerWeight(int layerIndex, float weight)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetLayerWeight_Injected(intPtr, layerIndex, weight);
		}

		private void GetAnimatorStateInfo(int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAnimatorStateInfo_Injected(intPtr, layerIndex, stateInfoIndex, out info);
		}

		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex)
		{
			GetAnimatorStateInfo(layerIndex, StateInfoIndex.CurrentState, out var info);
			return info;
		}

		public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex)
		{
			GetAnimatorStateInfo(layerIndex, StateInfoIndex.NextState, out var info);
			return info;
		}

		private void GetAnimatorTransitionInfo(int layerIndex, out AnimatorTransitionInfo info)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAnimatorTransitionInfo_Injected(intPtr, layerIndex, out info);
		}

		public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex)
		{
			GetAnimatorTransitionInfo(layerIndex, out var info);
			return info;
		}

		internal int GetAnimatorClipInfoCount(int layerIndex, bool current)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAnimatorClipInfoCount_Injected(intPtr, layerIndex, current);
		}

		public int GetCurrentAnimatorClipInfoCount(int layerIndex)
		{
			return GetAnimatorClipInfoCount(layerIndex, current: true);
		}

		public int GetNextAnimatorClipInfoCount(int layerIndex)
		{
			return GetAnimatorClipInfoCount(layerIndex, current: false);
		}

		[FreeFunction(Name = "AnimatorBindings::GetCurrentAnimatorClipInfo", HasExplicitThis = true)]
		[return: Unmarshalled]
		public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetCurrentAnimatorClipInfo_Injected(intPtr, layerIndex);
		}

		[FreeFunction(Name = "AnimatorBindings::GetNextAnimatorClipInfo", HasExplicitThis = true)]
		[return: Unmarshalled]
		public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetNextAnimatorClipInfo_Injected(intPtr, layerIndex);
		}

		public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			if (clips == null)
			{
				throw new ArgumentNullException("clips");
			}
			GetAnimatorClipInfoInternal(layerIndex, isCurrent: true, clips);
		}

		[FreeFunction(Name = "AnimatorBindings::GetAnimatorClipInfoInternal", HasExplicitThis = true)]
		private void GetAnimatorClipInfoInternal(int layerIndex, bool isCurrent, object clips)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetAnimatorClipInfoInternal_Injected(intPtr, layerIndex, isCurrent, clips);
		}

		public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			if (clips == null)
			{
				throw new ArgumentNullException("clips");
			}
			GetAnimatorClipInfoInternal(layerIndex, isCurrent: false, clips);
		}

		public bool IsInTransition(int layerIndex)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsInTransition_Injected(intPtr, layerIndex);
		}

		[FreeFunction(Name = "AnimatorBindings::GetParameterInternal", HasExplicitThis = true)]
		private AnimatorControllerParameter GetParameterInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetParameterInternal_Injected(intPtr, index);
		}

		public AnimatorControllerParameter GetParameter(int index)
		{
			AnimatorControllerParameter parameterInternal = GetParameterInternal(index);
			if (parameterInternal.m_Type == (AnimatorControllerParameterType)0)
			{
				throw new IndexOutOfRangeException("Index must be between 0 and " + parameterCount);
			}
			return parameterInternal;
		}

		private void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, int targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime, bool completeMatch)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			MatchTarget_Injected(intPtr, ref matchPosition, ref matchRotation, targetBodyPart, ref weightMask, startNormalizedTime, targetNormalizedTime, completeMatch);
		}

		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime)
		{
			MatchTarget(matchPosition, matchRotation, (int)targetBodyPart, weightMask, startNormalizedTime, 1f, completeMatch: true);
		}

		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [UnityEngine.Internal.DefaultValue("1")] float targetNormalizedTime)
		{
			MatchTarget(matchPosition, matchRotation, (int)targetBodyPart, weightMask, startNormalizedTime, targetNormalizedTime, completeMatch: true);
		}

		public void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, [UnityEngine.Internal.DefaultValue("1")] float targetNormalizedTime, [UnityEngine.Internal.DefaultValue("true")] bool completeMatch)
		{
			MatchTarget(matchPosition, matchRotation, (int)targetBodyPart, weightMask, startNormalizedTime, targetNormalizedTime, completeMatch);
		}

		public void InterruptMatchTarget()
		{
			InterruptMatchTarget(completeMatch: true);
		}

		public void InterruptMatchTarget([UnityEngine.Internal.DefaultValue("true")] bool completeMatch)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			InterruptMatchTarget_Injected(intPtr, completeMatch);
		}

		[Obsolete("ForceStateNormalizedTime is deprecated. Please use Play or CrossFade instead.")]
		public void ForceStateNormalizedTime(float normalizedTime)
		{
			Play(0, 0, normalizedTime);
		}

		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration)
		{
			float normalizedTransitionTime = 0f;
			float fixedTimeOffset = 0f;
			int layer = -1;
			CrossFadeInFixedTime(StringToHash(stateName), fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer)
		{
			float normalizedTransitionTime = 0f;
			float fixedTimeOffset = 0f;
			CrossFadeInFixedTime(StringToHash(stateName), fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, int layer, float fixedTimeOffset)
		{
			float normalizedTransitionTime = 0f;
			CrossFadeInFixedTime(StringToHash(stateName), fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFadeInFixedTime(string stateName, float fixedTransitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float fixedTimeOffset, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTransitionTime)
		{
			CrossFadeInFixedTime(StringToHash(stateName), fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer, float fixedTimeOffset)
		{
			float normalizedTransitionTime = 0f;
			CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, int layer)
		{
			float normalizedTransitionTime = 0f;
			float fixedTimeOffset = 0f;
			CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration)
		{
			float normalizedTransitionTime = 0f;
			float fixedTimeOffset = 0f;
			int layer = -1;
			CrossFadeInFixedTime(stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		[FreeFunction(Name = "AnimatorBindings::CrossFadeInFixedTime", HasExplicitThis = true)]
		public void CrossFadeInFixedTime(int stateHashName, float fixedTransitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float fixedTimeOffset, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTransitionTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			CrossFadeInFixedTime_Injected(intPtr, stateHashName, fixedTransitionDuration, layer, fixedTimeOffset, normalizedTransitionTime);
		}

		[FreeFunction(Name = "AnimatorBindings::WriteDefaultValues", HasExplicitThis = true)]
		public void WriteDefaultValues()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			WriteDefaultValues_Injected(intPtr);
		}

		public void CrossFade(string stateName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset)
		{
			float normalizedTransitionTime = 0f;
			CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFade(string stateName, float normalizedTransitionDuration, int layer)
		{
			float normalizedTransitionTime = 0f;
			float normalizedTimeOffset = float.NegativeInfinity;
			CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFade(string stateName, float normalizedTransitionDuration)
		{
			float normalizedTransitionTime = 0f;
			float normalizedTimeOffset = float.NegativeInfinity;
			int layer = -1;
			CrossFade(stateName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFade(string stateName, float normalizedTransitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTimeOffset, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTransitionTime)
		{
			CrossFade(StringToHash(stateName), normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		[FreeFunction(Name = "AnimatorBindings::CrossFade", HasExplicitThis = true)]
		public void CrossFade(int stateHashName, float normalizedTransitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTimeOffset, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTransitionTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			CrossFade_Injected(intPtr, stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer, float normalizedTimeOffset)
		{
			float normalizedTransitionTime = 0f;
			CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFade(int stateHashName, float normalizedTransitionDuration, int layer)
		{
			float normalizedTransitionTime = 0f;
			float normalizedTimeOffset = float.NegativeInfinity;
			CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void CrossFade(int stateHashName, float normalizedTransitionDuration)
		{
			float normalizedTransitionTime = 0f;
			float normalizedTimeOffset = float.NegativeInfinity;
			int layer = -1;
			CrossFade(stateHashName, normalizedTransitionDuration, layer, normalizedTimeOffset, normalizedTransitionTime);
		}

		public void PlayInFixedTime(string stateName, int layer)
		{
			float fixedTime = float.NegativeInfinity;
			PlayInFixedTime(stateName, layer, fixedTime);
		}

		public void PlayInFixedTime(string stateName)
		{
			float fixedTime = float.NegativeInfinity;
			int layer = -1;
			PlayInFixedTime(stateName, layer, fixedTime);
		}

		public void PlayInFixedTime(string stateName, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float fixedTime)
		{
			PlayInFixedTime(StringToHash(stateName), layer, fixedTime);
		}

		[FreeFunction(Name = "AnimatorBindings::PlayInFixedTime", HasExplicitThis = true)]
		public void PlayInFixedTime(int stateNameHash, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float fixedTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			PlayInFixedTime_Injected(intPtr, stateNameHash, layer, fixedTime);
		}

		public void PlayInFixedTime(int stateNameHash, int layer)
		{
			float fixedTime = float.NegativeInfinity;
			PlayInFixedTime(stateNameHash, layer, fixedTime);
		}

		public void PlayInFixedTime(int stateNameHash)
		{
			float fixedTime = float.NegativeInfinity;
			int layer = -1;
			PlayInFixedTime(stateNameHash, layer, fixedTime);
		}

		public void Play(string stateName, int layer)
		{
			float normalizedTime = float.NegativeInfinity;
			Play(stateName, layer, normalizedTime);
		}

		public void Play(string stateName)
		{
			float normalizedTime = float.NegativeInfinity;
			int layer = -1;
			Play(stateName, layer, normalizedTime);
		}

		public void Play(string stateName, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime)
		{
			Play(StringToHash(stateName), layer, normalizedTime);
		}

		[FreeFunction(Name = "AnimatorBindings::Play", HasExplicitThis = true)]
		public void Play(int stateNameHash, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Play_Injected(intPtr, stateNameHash, layer, normalizedTime);
		}

		public void Play(int stateNameHash, int layer)
		{
			float normalizedTime = float.NegativeInfinity;
			Play(stateNameHash, layer, normalizedTime);
		}

		public void Play(int stateNameHash)
		{
			float normalizedTime = float.NegativeInfinity;
			int layer = -1;
			Play(stateNameHash, layer, normalizedTime);
		}

		public void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTarget_Injected(intPtr, targetIndex, targetNormalizedTime);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use mask and layers to control subset of transfroms in a skeleton.", true)]
		public bool IsControlled(Transform transform)
		{
			return false;
		}

		internal bool IsBoneTransform(Transform transform)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsBoneTransform_Injected(intPtr, MarshalledUnityObject.Marshal(transform));
		}

		public Transform GetBoneTransform(HumanBodyBones humanBoneId)
		{
			if (avatar == null)
			{
				throw new InvalidOperationException("Avatar is null.");
			}
			if (!avatar.isValid)
			{
				throw new InvalidOperationException("Avatar is not valid.");
			}
			if (!avatar.isHuman)
			{
				throw new InvalidOperationException("Avatar is not of type humanoid.");
			}
			if (humanBoneId < HumanBodyBones.Hips || humanBoneId >= HumanBodyBones.LastBone)
			{
				throw new IndexOutOfRangeException("humanBoneId must be between 0 and " + HumanBodyBones.LastBone);
			}
			return GetBoneTransformInternal(HumanTrait.GetBoneIndexFromMono((int)humanBoneId));
		}

		[NativeMethod("GetBoneTransform")]
		internal Transform GetBoneTransformInternal(int humanBoneId)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Transform>(GetBoneTransformInternal_Injected(intPtr, humanBoneId));
		}

		public void StartPlayback()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StartPlayback_Injected(intPtr);
		}

		public void StopPlayback()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StopPlayback_Injected(intPtr);
		}

		public void StartRecording(int frameCount)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StartRecording_Injected(intPtr, frameCount);
		}

		public void StopRecording()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			StopRecording_Injected(intPtr);
		}

		private float GetRecorderStartTime()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetRecorderStartTime_Injected(intPtr);
		}

		private float GetRecorderStopTime()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetRecorderStopTime_Injected(intPtr);
		}

		internal void ClearInternalControllerPlayable()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearInternalControllerPlayable_Injected(intPtr);
		}

		public bool HasState(int layerIndex, int stateID)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return HasState_Injected(intPtr, layerIndex, stateID);
		}

		[NativeMethod(Name = "ScriptingStringToCRC32", IsThreadSafe = true)]
		public unsafe static int StringToHash(string name)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return StringToHash_Injected(ref managedSpanWrapper);
					}
				}
				return StringToHash_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		internal string GetStats()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetStats_Injected(intPtr, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[FreeFunction(Name = "AnimatorBindings::GetCurrentGraph", HasExplicitThis = true)]
		private void GetCurrentGraph(ref PlayableGraph graph)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCurrentGraph_Injected(intPtr, ref graph);
		}

		private void CheckIfInIKPass()
		{
			if (logWarnings && !IsInIKPass())
			{
				Debug.LogWarning("Setting and getting Body Position/Rotation, IK Goals, Lookat and BoneLocalRotation should only be done in OnAnimatorIK or OnStateIK");
			}
		}

		private bool IsInIKPass()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsInIKPass_Injected(intPtr);
		}

		[FreeFunction(Name = "AnimatorBindings::SetFloatString", HasExplicitThis = true)]
		private unsafe void SetFloatString(string name, float value)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						SetFloatString_Injected(intPtr, ref managedSpanWrapper, value);
						return;
					}
				}
				SetFloatString_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::SetFloatID", HasExplicitThis = true)]
		private void SetFloatID(int id, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFloatID_Injected(intPtr, id, value);
		}

		[FreeFunction(Name = "AnimatorBindings::GetFloatString", HasExplicitThis = true)]
		private unsafe float GetFloatString(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetFloatString_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetFloatString_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::GetFloatID", HasExplicitThis = true)]
		private float GetFloatID(int id)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetFloatID_Injected(intPtr, id);
		}

		[FreeFunction(Name = "AnimatorBindings::SetBoolString", HasExplicitThis = true)]
		private unsafe void SetBoolString(string name, bool value)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						SetBoolString_Injected(intPtr, ref managedSpanWrapper, value);
						return;
					}
				}
				SetBoolString_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::SetBoolID", HasExplicitThis = true)]
		private void SetBoolID(int id, bool value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetBoolID_Injected(intPtr, id, value);
		}

		[FreeFunction(Name = "AnimatorBindings::GetBoolString", HasExplicitThis = true)]
		private unsafe bool GetBoolString(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetBoolString_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetBoolString_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::GetBoolID", HasExplicitThis = true)]
		private bool GetBoolID(int id)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetBoolID_Injected(intPtr, id);
		}

		[FreeFunction(Name = "AnimatorBindings::SetIntegerString", HasExplicitThis = true)]
		private unsafe void SetIntegerString(string name, int value)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						SetIntegerString_Injected(intPtr, ref managedSpanWrapper, value);
						return;
					}
				}
				SetIntegerString_Injected(intPtr, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::SetIntegerID", HasExplicitThis = true)]
		private void SetIntegerID(int id, int value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetIntegerID_Injected(intPtr, id, value);
		}

		[FreeFunction(Name = "AnimatorBindings::GetIntegerString", HasExplicitThis = true)]
		private unsafe int GetIntegerString(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetIntegerString_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return GetIntegerString_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::GetIntegerID", HasExplicitThis = true)]
		private int GetIntegerID(int id)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetIntegerID_Injected(intPtr, id);
		}

		[FreeFunction(Name = "AnimatorBindings::SetTriggerString", HasExplicitThis = true)]
		private unsafe void SetTriggerString(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						SetTriggerString_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				SetTriggerString_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::SetTriggerID", HasExplicitThis = true)]
		private void SetTriggerID(int id)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTriggerID_Injected(intPtr, id);
		}

		[FreeFunction(Name = "AnimatorBindings::ResetTriggerString", HasExplicitThis = true)]
		private unsafe void ResetTriggerString(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						ResetTriggerString_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				ResetTriggerString_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::ResetTriggerID", HasExplicitThis = true)]
		private void ResetTriggerID(int id)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResetTriggerID_Injected(intPtr, id);
		}

		[FreeFunction(Name = "AnimatorBindings::IsParameterControlledByCurveString", HasExplicitThis = true)]
		private unsafe bool IsParameterControlledByCurveString(string name)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return IsParameterControlledByCurveString_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				return IsParameterControlledByCurveString_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::IsParameterControlledByCurveID", HasExplicitThis = true)]
		private bool IsParameterControlledByCurveID(int id)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return IsParameterControlledByCurveID_Injected(intPtr, id);
		}

		[FreeFunction(Name = "AnimatorBindings::SetFloatStringDamp", HasExplicitThis = true)]
		private unsafe void SetFloatStringDamp(string name, float value, float dampTime, float deltaTime)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						SetFloatStringDamp_Injected(intPtr, ref managedSpanWrapper, value, dampTime, deltaTime);
						return;
					}
				}
				SetFloatStringDamp_Injected(intPtr, ref managedSpanWrapper, value, dampTime, deltaTime);
			}
			finally
			{
			}
		}

		[FreeFunction(Name = "AnimatorBindings::SetFloatIDDamp", HasExplicitThis = true)]
		private void SetFloatIDDamp(int id, float value, float dampTime, float deltaTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetFloatIDDamp_Injected(intPtr, id, value, dampTime, deltaTime);
		}

		[NativeConditional("UNITY_EDITOR")]
		internal void OnUpdateModeChanged()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			OnUpdateModeChanged_Injected(intPtr);
		}

		[NativeConditional("UNITY_EDITOR")]
		internal void OnCullingModeChanged()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			OnCullingModeChanged_Injected(intPtr);
		}

		[NativeConditional("UNITY_EDITOR")]
		internal void WriteDefaultPose()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			WriteDefaultPose_Injected(intPtr);
		}

		[NativeMethod("UpdateWithDelta")]
		public void Update(float deltaTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Update_Injected(intPtr, deltaTime);
		}

		public void Rebind()
		{
			Rebind(writeDefaultValues: true);
		}

		private void Rebind(bool writeDefaultValues)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Rebind_Injected(intPtr, writeDefaultValues);
		}

		public void ApplyBuiltinRootMotion()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ApplyBuiltinRootMotion_Injected(intPtr);
		}

		[NativeConditional("UNITY_EDITOR")]
		internal void EvaluateController()
		{
			EvaluateController(0f);
		}

		private void EvaluateController(float deltaTime)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			EvaluateController_Injected(intPtr, deltaTime);
		}

		[NativeConditional("UNITY_EDITOR")]
		internal string GetCurrentStateName(int layerIndex)
		{
			return GetAnimatorStateName(layerIndex, current: true);
		}

		[NativeConditional("UNITY_EDITOR")]
		internal string GetNextStateName(int layerIndex)
		{
			return GetAnimatorStateName(layerIndex, current: false);
		}

		[NativeConditional("UNITY_EDITOR")]
		private string GetAnimatorStateName(int layerIndex, bool current)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetAnimatorStateName_Injected(intPtr, layerIndex, current, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		internal string ResolveHash(int hash)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ResolveHash_Injected(intPtr, hash, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[Obsolete("GetVector is deprecated.")]
		public Vector3 GetVector(string name)
		{
			return Vector3.zero;
		}

		[Obsolete("GetVector is deprecated.")]
		public Vector3 GetVector(int id)
		{
			return Vector3.zero;
		}

		[Obsolete("SetVector is deprecated.")]
		public void SetVector(string name, Vector3 value)
		{
		}

		[Obsolete("SetVector is deprecated.")]
		public void SetVector(int id, Vector3 value)
		{
		}

		[Obsolete("GetQuaternion is deprecated.")]
		public Quaternion GetQuaternion(string name)
		{
			return Quaternion.identity;
		}

		[Obsolete("GetQuaternion is deprecated.")]
		public Quaternion GetQuaternion(int id)
		{
			return Quaternion.identity;
		}

		[Obsolete("SetQuaternion is deprecated.")]
		public void SetQuaternion(string name, Quaternion value)
		{
		}

		[Obsolete("SetQuaternion is deprecated.")]
		public void SetQuaternion(int id, Quaternion value)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isOptimizable_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isHuman_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasRootMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isRootPositionOrRotationControlledByCurves_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_humanScale_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isInitialized_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_deltaPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_deltaRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_velocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_angularVelocity_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rootPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rootPosition_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rootRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rootRotation_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_applyRootMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_applyRootMotion_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_linearVelocityBlending_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_linearVelocityBlending_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_animatePhysics_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_animatePhysics_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorUpdateMode get_updateMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_updateMode_Injected(IntPtr _unity_self, AnimatorUpdateMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasTransformHierarchy_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_allowConstantClipSamplingOptimization_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_allowConstantClipSamplingOptimization_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_gravityWeight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_bodyPositionInternal_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bodyPositionInternal_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_bodyRotationInternal_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_bodyRotationInternal_Injected(IntPtr _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetGoalPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGoalPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal, [In] ref Vector3 goalPosition);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetGoalRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGoalRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal, [In] ref Quaternion goalRotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetGoalWeightPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGoalWeightPosition_Injected(IntPtr _unity_self, AvatarIKGoal goal, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetGoalWeightRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGoalWeightRotation_Injected(IntPtr _unity_self, AvatarIKGoal goal, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetHintPosition_Injected(IntPtr _unity_self, AvatarIKHint hint, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetHintPosition_Injected(IntPtr _unity_self, AvatarIKHint hint, [In] ref Vector3 hintPosition);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetHintWeightPosition_Injected(IntPtr _unity_self, AvatarIKHint hint);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetHintWeightPosition_Injected(IntPtr _unity_self, AvatarIKHint hint, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLookAtPositionInternal_Injected(IntPtr _unity_self, [In] ref Vector3 lookAtPosition);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLookAtWeightInternal_Injected(IntPtr _unity_self, float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBoneLocalRotationInternal_Injected(IntPtr _unity_self, int humanBoneId, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetBehaviour_Injected(IntPtr _unity_self, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ScriptableObject[] InternalGetBehaviours_Injected(IntPtr _unity_self, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern ScriptableObject[] InternalGetBehavioursByKey_Injected(IntPtr _unity_self, int fullPathHash, int layerIndex, Type type);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_stabilizeFeet_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_stabilizeFeet_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_layerCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLayerName_Injected(IntPtr _unity_self, int layerIndex, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetLayerIndex_Injected(IntPtr _unity_self, ref ManagedSpanWrapper layerName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetLayerWeight_Injected(IntPtr _unity_self, int layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLayerWeight_Injected(IntPtr _unity_self, int layerIndex, float weight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAnimatorStateInfo_Injected(IntPtr _unity_self, int layerIndex, StateInfoIndex stateInfoIndex, out AnimatorStateInfo info);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAnimatorTransitionInfo_Injected(IntPtr _unity_self, int layerIndex, out AnimatorTransitionInfo info);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetAnimatorClipInfoCount_Injected(IntPtr _unity_self, int layerIndex, bool current);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorClipInfo[] GetCurrentAnimatorClipInfo_Injected(IntPtr _unity_self, int layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorClipInfo[] GetNextAnimatorClipInfo_Injected(IntPtr _unity_self, int layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAnimatorClipInfoInternal_Injected(IntPtr _unity_self, int layerIndex, bool isCurrent, object clips);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsInTransition_Injected(IntPtr _unity_self, int layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorControllerParameter[] get_parameters_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_parameterCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorControllerParameter GetParameterInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_feetPivotActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_feetPivotActive_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_pivotWeight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_pivotPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MatchTarget_Injected(IntPtr _unity_self, [In] ref Vector3 matchPosition, [In] ref Quaternion matchRotation, int targetBodyPart, [In] ref MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime, bool completeMatch);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InterruptMatchTarget_Injected(IntPtr _unity_self, [UnityEngine.Internal.DefaultValue("true")] bool completeMatch);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isMatchingTarget_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_speed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_speed_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CrossFadeInFixedTime_Injected(IntPtr _unity_self, int stateHashName, float fixedTransitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float fixedTimeOffset, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTransitionTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WriteDefaultValues_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CrossFade_Injected(IntPtr _unity_self, int stateHashName, float normalizedTransitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTimeOffset, [UnityEngine.Internal.DefaultValue("0.0f")] float normalizedTransitionTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PlayInFixedTime_Injected(IntPtr _unity_self, int stateNameHash, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float fixedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Play_Injected(IntPtr _unity_self, int stateNameHash, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTarget_Injected(IntPtr _unity_self, AvatarTarget targetIndex, float targetNormalizedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetPosition_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_targetRotation_Injected(IntPtr _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsBoneTransform_Injected(IntPtr _unity_self, IntPtr transform);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_avatarRoot_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetBoneTransformInternal_Injected(IntPtr _unity_self, int humanBoneId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorCullingMode get_cullingMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_cullingMode_Injected(IntPtr _unity_self, AnimatorCullingMode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StartPlayback_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StopPlayback_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_playbackTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_playbackTime_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StartRecording_Injected(IntPtr _unity_self, int frameCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void StopRecording_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetRecorderStartTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetRecorderStopTime_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimatorRecorderMode get_recorderMode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_runtimeAnimatorController_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_runtimeAnimatorController_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasBoundPlayables_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearInternalControllerPlayable_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool HasState_Injected(IntPtr _unity_self, int layerIndex, int stateID);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int StringToHash_Injected(ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_avatar_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_avatar_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetStats_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentGraph_Injected(IntPtr _unity_self, ref PlayableGraph graph);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsInIKPass_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloatString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloatID_Injected(IntPtr _unity_self, int id, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloatString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloatID_Injected(IntPtr _unity_self, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBoolString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBoolID_Injected(IntPtr _unity_self, int id, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBoolString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBoolID_Injected(IntPtr _unity_self, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetIntegerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetIntegerID_Injected(IntPtr _unity_self, int id, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIntegerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIntegerID_Injected(IntPtr _unity_self, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTriggerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTriggerID_Injected(IntPtr _unity_self, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetTriggerString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetTriggerID_Injected(IntPtr _unity_self, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsParameterControlledByCurveString_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsParameterControlledByCurveID_Injected(IntPtr _unity_self, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloatStringDamp_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, float value, float dampTime, float deltaTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloatIDDamp_Injected(IntPtr _unity_self, int id, float value, float dampTime, float deltaTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_layersAffectMassCenter_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_layersAffectMassCenter_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_leftFeetBottomHeight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_rightFeetBottomHeight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_supportsOnAnimatorMove_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void OnUpdateModeChanged_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void OnCullingModeChanged_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void WriteDefaultPose_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Update_Injected(IntPtr _unity_self, float deltaTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Rebind_Injected(IntPtr _unity_self, bool writeDefaultValues);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ApplyBuiltinRootMotion_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EvaluateController_Injected(IntPtr _unity_self, float deltaTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAnimatorStateName_Injected(IntPtr _unity_self, int layerIndex, bool current, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResolveHash_Injected(IntPtr _unity_self, int hash, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_logWarnings_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_logWarnings_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_fireEvents_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_fireEvents_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_keepAnimatorStateOnDisable_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_keepAnimatorStateOnDisable_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_writeDefaultValuesOnDisable_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_writeDefaultValuesOnDisable_Injected(IntPtr _unity_self, bool value);
	}
	[StructLayout(LayoutKind.Sequential)]
	[NativeType(CodegenOptions.Custom, "MonoAnimatorControllerParameter")]
	[UsedByNativeCode]
	[NativeAsStruct]
	[NativeHeader("Modules/Animation/AnimatorControllerParameter.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerParameter.bindings.h")]
	public class AnimatorControllerParameter
	{
		internal string m_Name = "";

		internal AnimatorControllerParameterType m_Type;

		internal float m_DefaultFloat;

		internal int m_DefaultInt;

		internal bool m_DefaultBool;

		public string name => m_Name;

		public int nameHash => Animator.StringToHash(m_Name);

		public AnimatorControllerParameterType type
		{
			get
			{
				return m_Type;
			}
			set
			{
				m_Type = value;
			}
		}

		public float defaultFloat
		{
			get
			{
				return m_DefaultFloat;
			}
			set
			{
				m_DefaultFloat = value;
			}
		}

		public int defaultInt
		{
			get
			{
				return m_DefaultInt;
			}
			set
			{
				m_DefaultInt = value;
			}
		}

		public bool defaultBool
		{
			get
			{
				return m_DefaultBool;
			}
			set
			{
				m_DefaultBool = value;
			}
		}

		public override bool Equals(object o)
		{
			return o is AnimatorControllerParameter animatorControllerParameter && m_Name == animatorControllerParameter.m_Name && m_Type == animatorControllerParameter.m_Type && m_DefaultFloat == animatorControllerParameter.m_DefaultFloat && m_DefaultInt == animatorControllerParameter.m_DefaultInt && m_DefaultBool == animatorControllerParameter.m_DefaultBool;
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[Obsolete("This class is not used anymore. See AnimatorOverrideController.GetOverrides() and AnimatorOverrideController.ApplyOverrides()")]
	public class AnimationClipPair
	{
		public AnimationClip originalClip;

		public AnimationClip overrideClip;
	}
	[NativeHeader("Modules/Animation/AnimatorOverrideController.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
	[UsedByNativeCode]
	[HelpURL("AnimatorOverrideController")]
	public class AnimatorOverrideController : RuntimeAnimatorController
	{
		internal delegate void OnOverrideControllerDirtyCallback();

		internal OnOverrideControllerDirtyCallback OnOverrideControllerDirty;

		public RuntimeAnimatorController runtimeAnimatorController
		{
			[NativeMethod("GetAnimatorController")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<RuntimeAnimatorController>(get_runtimeAnimatorController_Injected(intPtr));
			}
			[NativeMethod("SetAnimatorController")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_runtimeAnimatorController_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public AnimationClip this[string name]
		{
			get
			{
				return Internal_GetClipByName(name, returnEffectiveClip: true);
			}
			set
			{
				Internal_SetClipByName(name, value);
			}
		}

		public AnimationClip this[AnimationClip clip]
		{
			get
			{
				return GetClip(clip, returnEffectiveClip: true);
			}
			set
			{
				SetClip(clip, value, notify: true);
			}
		}

		public int overridesCount
		{
			[NativeMethod("GetOriginalClipsCount")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_overridesCount_Injected(intPtr);
			}
		}

		[Obsolete("AnimatorOverrideController.clips property is deprecated. Use AnimatorOverrideController.GetOverrides and AnimatorOverrideController.ApplyOverrides instead.")]
		public AnimationClipPair[] clips
		{
			get
			{
				int num = overridesCount;
				AnimationClipPair[] array = new AnimationClipPair[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = new AnimationClipPair();
					array[i].originalClip = GetOriginalClip(i);
					array[i].overrideClip = GetOverrideClip(array[i].originalClip);
				}
				return array;
			}
			set
			{
				for (int i = 0; i < value.Length; i++)
				{
					SetClip(value[i].originalClip, value[i].overrideClip, notify: false);
				}
				SendNotification();
			}
		}

		public AnimatorOverrideController()
		{
			Internal_Create(this, null);
			OnOverrideControllerDirty = null;
		}

		public AnimatorOverrideController(RuntimeAnimatorController controller)
		{
			Internal_Create(this, controller);
			OnOverrideControllerDirty = null;
		}

		[FreeFunction("AnimationBindings::CreateAnimatorOverrideController")]
		private static void Internal_Create([Writable] AnimatorOverrideController self, RuntimeAnimatorController controller)
		{
			Internal_Create_Injected(self, MarshalledUnityObject.Marshal(controller));
		}

		[NativeMethod("GetClip")]
		private unsafe AnimationClip Internal_GetClipByName(string name, bool returnEffectiveClip)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			IntPtr gcHandlePtr = default(IntPtr);
			AnimationClip result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						gcHandlePtr = Internal_GetClipByName_Injected(intPtr, ref managedSpanWrapper, returnEffectiveClip);
					}
				}
				else
				{
					gcHandlePtr = Internal_GetClipByName_Injected(intPtr, ref managedSpanWrapper, returnEffectiveClip);
				}
			}
			finally
			{
				result = Unmarshal.UnmarshalUnityObject<AnimationClip>(gcHandlePtr);
			}
			return result;
		}

		[NativeMethod("SetClip")]
		private unsafe void Internal_SetClipByName(string name, AnimationClip clip)
		{
			//The blocks IL_0039 are reachable both inside and outside the pinned region starting at IL_0028. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						Internal_SetClipByName_Injected(intPtr, ref managedSpanWrapper, MarshalledUnityObject.Marshal(clip));
						return;
					}
				}
				Internal_SetClipByName_Injected(intPtr, ref managedSpanWrapper, MarshalledUnityObject.Marshal(clip));
			}
			finally
			{
			}
		}

		private AnimationClip GetClip(AnimationClip originalClip, bool returnEffectiveClip)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<AnimationClip>(GetClip_Injected(intPtr, MarshalledUnityObject.Marshal(originalClip), returnEffectiveClip));
		}

		private void SetClip(AnimationClip originalClip, AnimationClip overrideClip, bool notify)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetClip_Injected(intPtr, MarshalledUnityObject.Marshal(originalClip), MarshalledUnityObject.Marshal(overrideClip), notify);
		}

		private void SendNotification()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SendNotification_Injected(intPtr);
		}

		private AnimationClip GetOriginalClip(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<AnimationClip>(GetOriginalClip_Injected(intPtr, index));
		}

		private AnimationClip GetOverrideClip(AnimationClip originalClip)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<AnimationClip>(GetOverrideClip_Injected(intPtr, MarshalledUnityObject.Marshal(originalClip)));
		}

		public void GetOverrides(List<KeyValuePair<AnimationClip, AnimationClip>> overrides)
		{
			if (overrides == null)
			{
				throw new ArgumentNullException("overrides");
			}
			int num = overridesCount;
			if (overrides.Capacity < num)
			{
				overrides.Capacity = num;
			}
			overrides.Clear();
			for (int i = 0; i < num; i++)
			{
				AnimationClip originalClip = GetOriginalClip(i);
				overrides.Add(new KeyValuePair<AnimationClip, AnimationClip>(originalClip, GetOverrideClip(originalClip)));
			}
		}

		public void ApplyOverrides(IList<KeyValuePair<AnimationClip, AnimationClip>> overrides)
		{
			if (overrides == null)
			{
				throw new ArgumentNullException("overrides");
			}
			for (int i = 0; i < overrides.Count; i++)
			{
				SetClip(overrides[i].Key, overrides[i].Value, notify: false);
			}
			SendNotification();
		}

		[NativeConditional("UNITY_EDITOR")]
		internal void PerformOverrideClipListCleanup()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			PerformOverrideClipListCleanup_Injected(intPtr);
		}

		[RequiredByNativeCode]
		[NativeConditional("UNITY_EDITOR")]
		internal static void OnInvalidateOverrideController(AnimatorOverrideController controller)
		{
			if (controller.OnOverrideControllerDirty != null)
			{
				controller.OnOverrideControllerDirty();
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create_Injected([Writable] AnimatorOverrideController self, IntPtr controller);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_runtimeAnimatorController_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_runtimeAnimatorController_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_GetClipByName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, bool returnEffectiveClip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_SetClipByName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name, IntPtr clip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetClip_Injected(IntPtr _unity_self, IntPtr originalClip, bool returnEffectiveClip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetClip_Injected(IntPtr _unity_self, IntPtr originalClip, IntPtr overrideClip, bool notify);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendNotification_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetOriginalClip_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetOverrideClip_Injected(IntPtr _unity_self, IntPtr originalClip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_overridesCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void PerformOverrideClipListCleanup_Injected(IntPtr _unity_self);
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AnimatorUtility.bindings.h")]
	public class AnimatorUtility
	{
		[FreeFunction("AnimatorUtilityBindings::OptimizeTransformHierarchy")]
		public static void OptimizeTransformHierarchy([NotNull] GameObject go, string[] exposedTransforms)
		{
			if ((object)go == null)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(go);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			OptimizeTransformHierarchy_Injected(intPtr, exposedTransforms);
		}

		[FreeFunction("AnimatorUtilityBindings::DeoptimizeTransformHierarchy")]
		public static void DeoptimizeTransformHierarchy([NotNull] GameObject go)
		{
			if ((object)go == null)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(go);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			DeoptimizeTransformHierarchy_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void OptimizeTransformHierarchy_Injected(IntPtr go, string[] exposedTransforms);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DeoptimizeTransformHierarchy_Injected(IntPtr go);
	}
	public enum BodyDof
	{
		SpineFrontBack,
		SpineLeftRight,
		SpineRollLeftRight,
		ChestFrontBack,
		ChestLeftRight,
		ChestRollLeftRight,
		UpperChestFrontBack,
		UpperChestLeftRight,
		UpperChestRollLeftRight,
		LastBodyDof
	}
	public enum HeadDof
	{
		NeckFrontBack,
		NeckLeftRight,
		NeckRollLeftRight,
		HeadFrontBack,
		HeadLeftRight,
		HeadRollLeftRight,
		LeftEyeDownUp,
		LeftEyeInOut,
		RightEyeDownUp,
		RightEyeInOut,
		JawDownUp,
		JawLeftRight,
		LastHeadDof
	}
	public enum LegDof
	{
		UpperLegFrontBack,
		UpperLegInOut,
		UpperLegRollInOut,
		LegCloseOpen,
		LegRollInOut,
		FootCloseOpen,
		FootInOut,
		ToesUpDown,
		LastLegDof
	}
	public enum ArmDof
	{
		ShoulderDownUp,
		ShoulderFrontBack,
		ArmDownUp,
		ArmFrontBack,
		ArmRollInOut,
		ForeArmCloseOpen,
		ForeArmRollInOut,
		HandDownUp,
		HandInOut,
		LastArmDof
	}
	public enum FingerDof
	{
		ProximalDownUp,
		ProximalInOut,
		IntermediateCloseOpen,
		DistalCloseOpen,
		LastFingerDof
	}
	public enum HumanPartDof
	{
		Body,
		Head,
		LeftLeg,
		RightLeg,
		LeftArm,
		RightArm,
		LeftThumb,
		LeftIndex,
		LeftMiddle,
		LeftRing,
		LeftLittle,
		RightThumb,
		RightIndex,
		RightMiddle,
		RightRing,
		RightLittle,
		LastHumanPartDof
	}
	internal enum Dof
	{
		BodyDofStart = 0,
		HeadDofStart = 9,
		LeftLegDofStart = 21,
		RightLegDofStart = 29,
		LeftArmDofStart = 37,
		RightArmDofStart = 46,
		LeftThumbDofStart = 55,
		LeftIndexDofStart = 59,
		LeftMiddleDofStart = 63,
		LeftRingDofStart = 67,
		LeftLittleDofStart = 71,
		RightThumbDofStart = 75,
		RightIndexDofStart = 79,
		RightMiddleDofStart = 83,
		RightRingDofStart = 87,
		RightLittleDofStart = 91,
		LastDof = 95
	}
	public enum HumanBodyBones
	{
		Hips = 0,
		LeftUpperLeg = 1,
		RightUpperLeg = 2,
		LeftLowerLeg = 3,
		RightLowerLeg = 4,
		LeftFoot = 5,
		RightFoot = 6,
		Spine = 7,
		Chest = 8,
		UpperChest = 54,
		Neck = 9,
		Head = 10,
		LeftShoulder = 11,
		RightShoulder = 12,
		LeftUpperArm = 13,
		RightUpperArm = 14,
		LeftLowerArm = 15,
		RightLowerArm = 16,
		LeftHand = 17,
		RightHand = 18,
		LeftToes = 19,
		RightToes = 20,
		LeftEye = 21,
		RightEye = 22,
		Jaw = 23,
		LeftThumbProximal = 24,
		LeftThumbIntermediate = 25,
		LeftThumbDistal = 26,
		LeftIndexProximal = 27,
		LeftIndexIntermediate = 28,
		LeftIndexDistal = 29,
		LeftMiddleProximal = 30,
		LeftMiddleIntermediate = 31,
		LeftMiddleDistal = 32,
		LeftRingProximal = 33,
		LeftRingIntermediate = 34,
		LeftRingDistal = 35,
		LeftLittleProximal = 36,
		LeftLittleIntermediate = 37,
		LeftLittleDistal = 38,
		RightThumbProximal = 39,
		RightThumbIntermediate = 40,
		RightThumbDistal = 41,
		RightIndexProximal = 42,
		RightIndexIntermediate = 43,
		RightIndexDistal = 44,
		RightMiddleProximal = 45,
		RightMiddleIntermediate = 46,
		RightMiddleDistal = 47,
		RightRingProximal = 48,
		RightRingIntermediate = 49,
		RightRingDistal = 50,
		RightLittleProximal = 51,
		RightLittleIntermediate = 52,
		RightLittleDistal = 53,
		LastBone = 55
	}
	internal enum HumanParameter
	{
		UpperArmTwist,
		LowerArmTwist,
		UpperLegTwist,
		LowerLegTwist,
		ArmStretch,
		LegStretch,
		FeetSpacing
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/Animation/Avatar.h")]
	public class Avatar : Object
	{
		public bool isValid
		{
			[NativeMethod("IsValid")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isValid_Injected(intPtr);
			}
		}

		public bool isHuman
		{
			[NativeMethod("IsHuman")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isHuman_Injected(intPtr);
			}
		}

		public HumanDescription humanDescription
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_humanDescription_Injected(intPtr, out var ret);
				return ret;
			}
		}

		private Avatar()
		{
		}

		internal void SetMuscleMinMax(int muscleId, float min, float max)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetMuscleMinMax_Injected(intPtr, muscleId, min, max);
		}

		internal void SetParameter(int parameterId, float value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetParameter_Injected(intPtr, parameterId, value);
		}

		internal float GetAxisLength(int humanId)
		{
			return Internal_GetAxisLength(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		internal Quaternion GetPreRotation(int humanId)
		{
			return Internal_GetPreRotation(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		internal Quaternion GetPostRotation(int humanId)
		{
			return Internal_GetPostRotation(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		internal Quaternion GetZYPostQ(int humanId, Quaternion parentQ, Quaternion q)
		{
			return Internal_GetZYPostQ(HumanTrait.GetBoneIndexFromMono(humanId), parentQ, q);
		}

		internal Quaternion GetZYRoll(int humanId, Vector3 uvw)
		{
			return Internal_GetZYRoll(HumanTrait.GetBoneIndexFromMono(humanId), uvw);
		}

		internal Vector3 GetLimitSign(int humanId)
		{
			return Internal_GetLimitSign(HumanTrait.GetBoneIndexFromMono(humanId));
		}

		[NativeMethod("GetAxisLength")]
		internal float Internal_GetAxisLength(int humanId)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_GetAxisLength_Injected(intPtr, humanId);
		}

		[NativeMethod("GetPreRotation")]
		internal Quaternion Internal_GetPreRotation(int humanId)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetPreRotation_Injected(intPtr, humanId, out var ret);
			return ret;
		}

		[NativeMethod("GetPostRotation")]
		internal Quaternion Internal_GetPostRotation(int humanId)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetPostRotation_Injected(intPtr, humanId, out var ret);
			return ret;
		}

		[NativeMethod("GetZYPostQ")]
		internal Quaternion Internal_GetZYPostQ(int humanId, Quaternion parentQ, Quaternion q)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetZYPostQ_Injected(intPtr, humanId, ref parentQ, ref q, out var ret);
			return ret;
		}

		[NativeMethod("GetZYRoll")]
		internal Quaternion Internal_GetZYRoll(int humanId, Vector3 uvw)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetZYRoll_Injected(intPtr, humanId, ref uvw, out var ret);
			return ret;
		}

		[NativeMethod("GetLimitSign")]
		internal Vector3 Internal_GetLimitSign(int humanId)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Internal_GetLimitSign_Injected(intPtr, humanId, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isValid_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isHuman_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_humanDescription_Injected(IntPtr _unity_self, out HumanDescription ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetMuscleMinMax_Injected(IntPtr _unity_self, int muscleId, float min, float max);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetParameter_Injected(IntPtr _unity_self, int parameterId, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float Internal_GetAxisLength_Injected(IntPtr _unity_self, int humanId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetPreRotation_Injected(IntPtr _unity_self, int humanId, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetPostRotation_Injected(IntPtr _unity_self, int humanId, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetZYPostQ_Injected(IntPtr _unity_self, int humanId, [In] ref Quaternion parentQ, [In] ref Quaternion q, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetZYRoll_Injected(IntPtr _unity_self, int humanId, [In] ref Vector3 uvw, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_GetLimitSign_Injected(IntPtr _unity_self, int humanId, out Vector3 ret);
	}
	[RequiredByNativeCode]
	[NativeHeader("Modules/Animation/HumanDescription.h")]
	[NativeType(CodegenOptions.Custom, "MonoSkeletonBone")]
	public struct SkeletonBone
	{
		[NativeName("m_Name")]
		public string name;

		[NativeName("m_ParentName")]
		internal string parentName;

		[NativeName("m_Position")]
		public Vector3 position;

		[NativeName("m_Rotation")]
		public Quaternion rotation;

		[NativeName("m_Scale")]
		public Vector3 scale;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("transformModified is no longer used and has been deprecated.", true)]
		public int transformModified
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AvatarBuilder.bindings.h")]
	[NativeHeader("Modules/Animation/HumanDescription.h")]
	[NativeType(CodegenOptions.Custom, "MonoHumanLimit")]
	public struct HumanLimit
	{
		private Vector3 m_Min;

		private Vector3 m_Max;

		private Vector3 m_Center;

		private float m_AxisLength;

		private int m_UseDefaultValues;

		public bool useDefaultValues
		{
			get
			{
				return m_UseDefaultValues != 0;
			}
			set
			{
				m_UseDefaultValues = (value ? 1 : 0);
			}
		}

		public Vector3 min
		{
			get
			{
				return m_Min;
			}
			set
			{
				m_Min = value;
			}
		}

		public Vector3 max
		{
			get
			{
				return m_Max;
			}
			set
			{
				m_Max = value;
			}
		}

		public Vector3 center
		{
			get
			{
				return m_Center;
			}
			set
			{
				m_Center = value;
			}
		}

		public float axisLength
		{
			get
			{
				return m_AxisLength;
			}
			set
			{
				m_AxisLength = value;
			}
		}
	}
	[NativeHeader("Modules/Animation/HumanDescription.h")]
	[RequiredByNativeCode]
	[NativeType(CodegenOptions.Custom, "MonoHumanBone")]
	public struct HumanBone
	{
		private string m_BoneName;

		private string m_HumanName;

		[NativeName("m_Limit")]
		public HumanLimit limit;

		public string boneName
		{
			get
			{
				return m_BoneName;
			}
			set
			{
				m_BoneName = value;
			}
		}

		public string humanName
		{
			get
			{
				return m_HumanName;
			}
			set
			{
				m_HumanName = value;
			}
		}
	}
	[NativeHeader("Modules/Animation/HumanDescription.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AvatarBuilder.bindings.h")]
	public struct HumanDescription
	{
		[NativeName("m_Human")]
		public HumanBone[] human;

		[NativeName("m_Skeleton")]
		public SkeletonBone[] skeleton;

		internal float m_ArmTwist;

		internal float m_ForeArmTwist;

		internal float m_UpperLegTwist;

		internal float m_LegTwist;

		internal float m_ArmStretch;

		internal float m_LegStretch;

		internal float m_FeetSpacing;

		internal float m_GlobalScale;

		internal string m_RootMotionBoneName;

		internal bool m_HasTranslationDoF;

		internal bool m_HasExtraRoot;

		internal bool m_SkeletonHasParents;

		public float upperArmTwist
		{
			get
			{
				return m_ArmTwist;
			}
			set
			{
				m_ArmTwist = value;
			}
		}

		public float lowerArmTwist
		{
			get
			{
				return m_ForeArmTwist;
			}
			set
			{
				m_ForeArmTwist = value;
			}
		}

		public float upperLegTwist
		{
			get
			{
				return m_UpperLegTwist;
			}
			set
			{
				m_UpperLegTwist = value;
			}
		}

		public float lowerLegTwist
		{
			get
			{
				return m_LegTwist;
			}
			set
			{
				m_LegTwist = value;
			}
		}

		public float armStretch
		{
			get
			{
				return m_ArmStretch;
			}
			set
			{
				m_ArmStretch = value;
			}
		}

		public float legStretch
		{
			get
			{
				return m_LegStretch;
			}
			set
			{
				m_LegStretch = value;
			}
		}

		public float feetSpacing
		{
			get
			{
				return m_FeetSpacing;
			}
			set
			{
				m_FeetSpacing = value;
			}
		}

		public bool hasTranslationDoF
		{
			get
			{
				return m_HasTranslationDoF;
			}
			set
			{
				m_HasTranslationDoF = value;
			}
		}
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AvatarBuilder.bindings.h")]
	public class AvatarBuilder
	{
		public static Avatar BuildHumanAvatar(GameObject go, HumanDescription humanDescription)
		{
			if (go == null)
			{
				throw new NullReferenceException();
			}
			return BuildHumanAvatarInternal(go, humanDescription);
		}

		[FreeFunction("AvatarBuilderBindings::BuildHumanAvatar")]
		private static Avatar BuildHumanAvatarInternal(GameObject go, HumanDescription humanDescription)
		{
			return Unmarshal.UnmarshalUnityObject<Avatar>(BuildHumanAvatarInternal_Injected(Object.MarshalledUnityObject.Marshal(go), ref humanDescription));
		}

		[FreeFunction("AvatarBuilderBindings::BuildGenericAvatar")]
		public unsafe static Avatar BuildGenericAvatar([NotNull] GameObject go, [NotNull] string rootMotionTransformName)
		{
			//The blocks IL_005c are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)go == null)
			{
				ThrowHelper.ThrowArgumentNullException(go, "go");
			}
			if (rootMotionTransformName == null)
			{
				ThrowHelper.ThrowArgumentNullException(rootMotionTransformName, "rootMotionTransformName");
			}
			IntPtr gcHandlePtr = default(IntPtr);
			Avatar result;
			try
			{
				IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(go);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(go, "go");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(rootMotionTransformName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(rootMotionTransformName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						gcHandlePtr = BuildGenericAvatar_Injected(intPtr, ref managedSpanWrapper);
					}
				}
				else
				{
					gcHandlePtr = BuildGenericAvatar_Injected(intPtr, ref managedSpanWrapper);
				}
			}
			finally
			{
				result = Unmarshal.UnmarshalUnityObject<Avatar>(gcHandlePtr);
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr BuildHumanAvatarInternal_Injected(IntPtr go, [In] ref HumanDescription humanDescription);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr BuildGenericAvatar_Injected(IntPtr go, ref ManagedSpanWrapper rootMotionTransformName);
	}
	[MovedFrom(true, "UnityEditor.Animations", "UnityEditor", null)]
	public enum AvatarMaskBodyPart
	{
		Root,
		Body,
		Head,
		LeftLeg,
		RightLeg,
		LeftArm,
		RightArm,
		LeftFingers,
		RightFingers,
		LeftFootIK,
		RightFootIK,
		LeftHandIK,
		RightHandIK,
		LastBodyPart
	}
	[UsedByNativeCode]
	[MovedFrom(true, "UnityEditor.Animations", "UnityEditor", null)]
	[NativeHeader("Modules/Animation/AvatarMask.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
	public sealed class AvatarMask : Object
	{
		[Obsolete("AvatarMask.humanoidBodyPartCount is deprecated, use AvatarMaskBodyPart.LastBodyPart instead.")]
		public int humanoidBodyPartCount => 13;

		public int transformCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_transformCount_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_transformCount_Injected(intPtr, value);
			}
		}

		internal bool hasFeetIK
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasFeetIK_Injected(intPtr);
			}
		}

		public AvatarMask()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("AnimationBindings::CreateAvatarMask")]
		private static extern void Internal_Create([Writable] AvatarMask self);

		[NativeMethod("GetBodyPart")]
		public bool GetHumanoidBodyPartActive(AvatarMaskBodyPart index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetHumanoidBodyPartActive_Injected(intPtr, index);
		}

		[NativeMethod("SetBodyPart")]
		public void SetHumanoidBodyPartActive(AvatarMaskBodyPart index, bool value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetHumanoidBodyPartActive_Injected(intPtr, index, value);
		}

		public void AddTransformPath(Transform transform)
		{
			AddTransformPath(transform, recursive: true);
		}

		public void AddTransformPath([NotNull] Transform transform, [UnityEngine.Internal.DefaultValue("true")] bool recursive)
		{
			if ((object)transform == null)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(transform);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			AddTransformPath_Injected(intPtr, intPtr2, recursive);
		}

		public void RemoveTransformPath(Transform transform)
		{
			RemoveTransformPath(transform, recursive: true);
		}

		public void RemoveTransformPath([NotNull] Transform transform, [UnityEngine.Internal.DefaultValue("true")] bool recursive)
		{
			if ((object)transform == null)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			IntPtr intPtr2 = MarshalledUnityObject.MarshalNotNull(transform);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			RemoveTransformPath_Injected(intPtr, intPtr2, recursive);
		}

		public string GetTransformPath(int index)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				GetTransformPath_Injected(intPtr, index, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		public unsafe void SetTransformPath(int index, string path)
		{
			//The blocks IL_003a are reachable both inside and outside the pinned region starting at IL_0029. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(path, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(path);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						SetTransformPath_Injected(intPtr, index, ref managedSpanWrapper);
						return;
					}
				}
				SetTransformPath_Injected(intPtr, index, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		private float GetTransformWeight(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTransformWeight_Injected(intPtr, index);
		}

		private void SetTransformWeight(int index, float weight)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTransformWeight_Injected(intPtr, index, weight);
		}

		public bool GetTransformActive(int index)
		{
			return GetTransformWeight(index) > 0.5f;
		}

		public void SetTransformActive(int index, bool value)
		{
			SetTransformWeight(index, value ? 1f : 0f);
		}

		internal void Copy(AvatarMask other)
		{
			for (AvatarMaskBodyPart avatarMaskBodyPart = AvatarMaskBodyPart.Root; avatarMaskBodyPart < AvatarMaskBodyPart.LastBodyPart; avatarMaskBodyPart++)
			{
				SetHumanoidBodyPartActive(avatarMaskBodyPart, other.GetHumanoidBodyPartActive(avatarMaskBodyPart));
			}
			transformCount = other.transformCount;
			for (int i = 0; i < other.transformCount; i++)
			{
				SetTransformPath(i, other.GetTransformPath(i));
				SetTransformActive(i, other.GetTransformActive(i));
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetHumanoidBodyPartActive_Injected(IntPtr _unity_self, AvatarMaskBodyPart index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetHumanoidBodyPartActive_Injected(IntPtr _unity_self, AvatarMaskBodyPart index, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_transformCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_transformCount_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddTransformPath_Injected(IntPtr _unity_self, IntPtr transform, [UnityEngine.Internal.DefaultValue("true")] bool recursive);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveTransformPath_Injected(IntPtr _unity_self, IntPtr transform, [UnityEngine.Internal.DefaultValue("true")] bool recursive);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetTransformPath_Injected(IntPtr _unity_self, int index, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTransformPath_Injected(IntPtr _unity_self, int index, ref ManagedSpanWrapper path);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetTransformWeight_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTransformWeight_Injected(IntPtr _unity_self, int index, float weight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasFeetIK_Injected(IntPtr _unity_self);
	}
	public struct HumanPose
	{
		private static int k_NumIkGoals = Enum.GetValues(typeof(AvatarIKGoal)).Length;

		internal static Quaternion[] s_IKGoalOffsets = new Quaternion[4]
		{
			new Quaternion(0.5f, -0.5f, 0.5f, 0.5f),
			new Quaternion(0.5f, -0.5f, 0.5f, 0.5f),
			new Quaternion(0.707107f, 0f, 0.707107f, 0f),
			new Quaternion(0f, 0.707107f, 0f, 0.707107f)
		};

		public Vector3 bodyPosition;

		public Quaternion bodyRotation;

		public float[] muscles;

		internal Vector3[] m_IkGoalPositions;

		internal Quaternion[] m_IkGoalRotations;

		internal Quaternion[] m_OffsetIkGoalRotations;

		public ReadOnlySpan<Vector3> ikGoalPositions => new ReadOnlySpan<Vector3>(m_IkGoalPositions);

		public ReadOnlySpan<Quaternion> internalIkGoalRotations => new ReadOnlySpan<Quaternion>(m_IkGoalRotations);

		public ReadOnlySpan<Quaternion> ikGoalRotations => new ReadOnlySpan<Quaternion>(m_OffsetIkGoalRotations);

		internal void Init()
		{
			if (muscles != null && muscles.Length != HumanTrait.MuscleCount)
			{
				throw new InvalidOperationException("Bad array size for HumanPose.muscles. Size must equal HumanTrait.MuscleCount");
			}
			if (muscles == null)
			{
				muscles = new float[HumanTrait.MuscleCount];
				if (bodyRotation.x == 0f && bodyRotation.y == 0f && bodyRotation.z == 0f && bodyRotation.w == 0f)
				{
					bodyRotation.w = 1f;
				}
			}
			if (m_IkGoalPositions != null && m_IkGoalPositions.Length != k_NumIkGoals)
			{
				throw new InvalidOperationException("Bad array size for HumanPose.ikGoalPositions. Size must equal AvatakIKGoal size");
			}
			if (m_IkGoalPositions == null)
			{
				m_IkGoalPositions = new Vector3[k_NumIkGoals];
			}
			if (m_IkGoalRotations != null && m_IkGoalRotations.Length != k_NumIkGoals)
			{
				throw new InvalidOperationException("Bad array size for HumanPose.ikGoalPositions. Size must equal AvatakIKGoal size");
			}
			if (m_IkGoalRotations == null)
			{
				m_IkGoalRotations = new Quaternion[k_NumIkGoals];
			}
			if (m_OffsetIkGoalRotations != null && m_OffsetIkGoalRotations.Length != k_NumIkGoals)
			{
				throw new InvalidOperationException("Bad array size for HumanPose.ikGoalPositions. Size must equal AvatakIKGoal size");
			}
			if (m_OffsetIkGoalRotations == null)
			{
				m_OffsetIkGoalRotations = new Quaternion[k_NumIkGoals];
			}
		}
	}
	[NativeHeader("Modules/Animation/HumanPoseHandler.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animation.bindings.h")]
	public class HumanPoseHandler : IDisposable
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(HumanPoseHandler humanPoseHandler)
			{
				return humanPoseHandler.m_Ptr;
			}
		}

		internal IntPtr m_Ptr;

		[FreeFunction("AnimationBindings::CreateHumanPoseHandler")]
		private static IntPtr Internal_CreateFromRoot(Avatar avatar, Transform root)
		{
			return Internal_CreateFromRoot_Injected(Object.MarshalledUnityObject.Marshal(avatar), Object.MarshalledUnityObject.Marshal(root));
		}

		[FreeFunction("AnimationBindings::CreateHumanPoseHandler", IsThreadSafe = true)]
		private static IntPtr Internal_CreateFromJointPaths(Avatar avatar, string[] jointPaths)
		{
			return Internal_CreateFromJointPaths_Injected(Object.MarshalledUnityObject.Marshal(avatar), jointPaths);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("AnimationBindings::DestroyHumanPoseHandler")]
		private static extern void Internal_Destroy(IntPtr ptr);

		private unsafe void GetHumanPose(out Vector3 bodyPosition, out Quaternion bodyRotation, [Out] float[] muscles, [Out] Vector3[] ikGoalPositions, [Out] Quaternion[] ikGoalRotations)
		{
			//The blocks IL_002d, IL_0034, IL_0039, IL_003b, IL_004d, IL_0054, IL_005b, IL_005d, IL_0071 are reachable both inside and outside the pinned region starting at IL_0016. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_004d, IL_0054, IL_005b, IL_005d, IL_0071 are reachable both inside and outside the pinned region starting at IL_0036. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0071 are reachable both inside and outside the pinned region starting at IL_0056. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
			BlittableArrayWrapper blittableArrayWrapper2 = default(BlittableArrayWrapper);
			BlittableArrayWrapper ikGoalRotations2 = default(BlittableArrayWrapper);
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ref BlittableArrayWrapper muscles2;
				ref BlittableArrayWrapper ikGoalPositions2;
				if (muscles != null)
				{
					fixed (float[] array = muscles)
					{
						if (array.Length != 0)
						{
							blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						muscles2 = ref blittableArrayWrapper;
						if (ikGoalPositions != null)
						{
							fixed (Vector3[] array2 = ikGoalPositions)
							{
								if (array2.Length != 0)
								{
									blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
								}
								ikGoalPositions2 = ref blittableArrayWrapper2;
								if (ikGoalRotations != null)
								{
									fixed (Quaternion[] array3 = ikGoalRotations)
									{
										if (array3.Length != 0)
										{
											ikGoalRotations2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
										}
										GetHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotations2);
										return;
									}
								}
								GetHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotations2);
								return;
							}
						}
						ikGoalPositions2 = ref blittableArrayWrapper2;
						if (ikGoalRotations != null)
						{
							array3 = ikGoalRotations;
							if (array3.Length != 0)
							{
								ikGoalRotations2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
							}
						}
						GetHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotations2);
						return;
					}
				}
				muscles2 = ref blittableArrayWrapper;
				if (ikGoalPositions != null)
				{
					array2 = ikGoalPositions;
					if (array2.Length != 0)
					{
						blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
				}
				ikGoalPositions2 = ref blittableArrayWrapper2;
				if (ikGoalRotations != null)
				{
					array3 = ikGoalRotations;
					if (array3.Length != 0)
					{
						ikGoalRotations2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
					}
				}
				GetHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotations2);
			}
			finally
			{
				blittableArrayWrapper.Unmarshal(ref array);
				blittableArrayWrapper2.Unmarshal(ref array2);
				ikGoalRotations2.Unmarshal(ref array3);
			}
		}

		private unsafe void SetHumanPose(ref Vector3 bodyPosition, ref Quaternion bodyRotation, float[] muscles)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<float> span = new Span<float>(muscles);
			fixed (float* begin = span)
			{
				ManagedSpanWrapper muscles2 = new ManagedSpanWrapper(begin, span.Length);
				SetHumanPose_Injected(intPtr, ref bodyPosition, ref bodyRotation, ref muscles2);
			}
		}

		[ThreadSafe]
		private unsafe void GetInternalHumanPose(out Vector3 bodyPosition, out Quaternion bodyRotation, [Out] float[] muscles, [Out] Vector3[] ikGoalPositions, [Out] Quaternion[] ikGoalRotation)
		{
			//The blocks IL_002d, IL_0034, IL_0039, IL_003b, IL_004d, IL_0054, IL_005b, IL_005d, IL_0071 are reachable both inside and outside the pinned region starting at IL_0016. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_004d, IL_0054, IL_005b, IL_005d, IL_0071 are reachable both inside and outside the pinned region starting at IL_0036. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			//The blocks IL_0071 are reachable both inside and outside the pinned region starting at IL_0056. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			BlittableArrayWrapper blittableArrayWrapper = default(BlittableArrayWrapper);
			BlittableArrayWrapper blittableArrayWrapper2 = default(BlittableArrayWrapper);
			BlittableArrayWrapper ikGoalRotation2 = default(BlittableArrayWrapper);
			try
			{
				IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				ref BlittableArrayWrapper muscles2;
				ref BlittableArrayWrapper ikGoalPositions2;
				if (muscles != null)
				{
					fixed (float[] array = muscles)
					{
						if (array.Length != 0)
						{
							blittableArrayWrapper = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
						}
						muscles2 = ref blittableArrayWrapper;
						if (ikGoalPositions != null)
						{
							fixed (Vector3[] array2 = ikGoalPositions)
							{
								if (array2.Length != 0)
								{
									blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
								}
								ikGoalPositions2 = ref blittableArrayWrapper2;
								if (ikGoalRotation != null)
								{
									fixed (Quaternion[] array3 = ikGoalRotation)
									{
										if (array3.Length != 0)
										{
											ikGoalRotation2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
										}
										GetInternalHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotation2);
										return;
									}
								}
								GetInternalHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotation2);
								return;
							}
						}
						ikGoalPositions2 = ref blittableArrayWrapper2;
						if (ikGoalRotation != null)
						{
							array3 = ikGoalRotation;
							if (array3.Length != 0)
							{
								ikGoalRotation2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
							}
						}
						GetInternalHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotation2);
						return;
					}
				}
				muscles2 = ref blittableArrayWrapper;
				if (ikGoalPositions != null)
				{
					array2 = ikGoalPositions;
					if (array2.Length != 0)
					{
						blittableArrayWrapper2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array2[0]), array2.Length);
					}
				}
				ikGoalPositions2 = ref blittableArrayWrapper2;
				if (ikGoalRotation != null)
				{
					array3 = ikGoalRotation;
					if (array3.Length != 0)
					{
						ikGoalRotation2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array3[0]), array3.Length);
					}
				}
				GetInternalHumanPose_Injected(intPtr, out bodyPosition, out bodyRotation, out muscles2, out ikGoalPositions2, out ikGoalRotation2);
			}
			finally
			{
				blittableArrayWrapper.Unmarshal(ref array);
				blittableArrayWrapper2.Unmarshal(ref array2);
				ikGoalRotation2.Unmarshal(ref array3);
			}
		}

		[ThreadSafe]
		private unsafe void SetInternalHumanPose(ref Vector3 bodyPosition, ref Quaternion bodyRotation, float[] muscles)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<float> span = new Span<float>(muscles);
			fixed (float* begin = span)
			{
				ManagedSpanWrapper muscles2 = new ManagedSpanWrapper(begin, span.Length);
				SetInternalHumanPose_Injected(intPtr, ref bodyPosition, ref bodyRotation, ref muscles2);
			}
		}

		[ThreadSafe]
		private unsafe void GetInternalAvatarPose(void* avatarPose, int avatarPoseLength)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetInternalAvatarPose_Injected(intPtr, avatarPose, avatarPoseLength);
		}

		[ThreadSafe]
		private unsafe void SetInternalAvatarPose(void* avatarPose, int avatarPoseLength)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetInternalAvatarPose_Injected(intPtr, avatarPose, avatarPoseLength);
		}

		public void Dispose()
		{
			if (m_Ptr != IntPtr.Zero)
			{
				Internal_Destroy(m_Ptr);
				m_Ptr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}

		public HumanPoseHandler(Avatar avatar, Transform root)
		{
			m_Ptr = IntPtr.Zero;
			if (root == null)
			{
				throw new ArgumentNullException("HumanPoseHandler root Transform is null");
			}
			if (avatar == null)
			{
				throw new ArgumentNullException("HumanPoseHandler avatar is null");
			}
			if (!avatar.isValid)
			{
				throw new ArgumentException("HumanPoseHandler avatar is invalid");
			}
			if (!avatar.isHuman)
			{
				throw new ArgumentException("HumanPoseHandler avatar is not human");
			}
			m_Ptr = Internal_CreateFromRoot(avatar, root);
		}

		public HumanPoseHandler(Avatar avatar, string[] jointPaths)
		{
			m_Ptr = IntPtr.Zero;
			if (jointPaths == null)
			{
				throw new ArgumentNullException("HumanPoseHandler jointPaths array is null");
			}
			if (avatar == null)
			{
				throw new ArgumentNullException("HumanPoseHandler avatar is null");
			}
			if (!avatar.isValid)
			{
				throw new ArgumentException("HumanPoseHandler avatar is invalid");
			}
			if (!avatar.isHuman)
			{
				throw new ArgumentException("HumanPoseHandler avatar is not human");
			}
			m_Ptr = Internal_CreateFromJointPaths(avatar, jointPaths);
		}

		private static void CalculateIKOffsets(in Quaternion[] sourceRotations, ref Quaternion[] destRotations)
		{
			for (int i = 0; i < 4; i++)
			{
				destRotations[i] = sourceRotations[i] * HumanPose.s_IKGoalOffsets[i];
			}
		}

		public void GetHumanPose(ref HumanPose humanPose)
		{
			if (m_Ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("HumanPoseHandler is not initialized properly");
			}
			humanPose.Init();
			GetHumanPose(out humanPose.bodyPosition, out humanPose.bodyRotation, humanPose.muscles, humanPose.m_IkGoalPositions, humanPose.m_IkGoalRotations);
			CalculateIKOffsets(in humanPose.m_IkGoalRotations, ref humanPose.m_OffsetIkGoalRotations);
		}

		public void SetHumanPose(ref HumanPose humanPose)
		{
			if (m_Ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("HumanPoseHandler is not initialized properly");
			}
			humanPose.Init();
			SetHumanPose(ref humanPose.bodyPosition, ref humanPose.bodyRotation, humanPose.muscles);
		}

		public void GetInternalHumanPose(ref HumanPose humanPose)
		{
			if (m_Ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("HumanPoseHandler is not initialized properly");
			}
			humanPose.Init();
			GetInternalHumanPose(out humanPose.bodyPosition, out humanPose.bodyRotation, humanPose.muscles, humanPose.m_IkGoalPositions, humanPose.m_IkGoalRotations);
			CalculateIKOffsets(in humanPose.m_IkGoalRotations, ref humanPose.m_OffsetIkGoalRotations);
		}

		public void SetInternalHumanPose(ref HumanPose humanPose)
		{
			if (m_Ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("HumanPoseHandler is not initialized properly");
			}
			humanPose.Init();
			SetInternalHumanPose(ref humanPose.bodyPosition, ref humanPose.bodyRotation, humanPose.muscles);
		}

		public unsafe void GetInternalAvatarPose(NativeArray<float> avatarPose)
		{
			if (m_Ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("HumanPoseHandler is not initialized properly");
			}
			GetInternalAvatarPose(avatarPose.GetUnsafePtr(), avatarPose.Length);
		}

		public unsafe void SetInternalAvatarPose(NativeArray<float> avatarPose)
		{
			if (m_Ptr == IntPtr.Zero)
			{
				throw new NullReferenceException("HumanPoseHandler is not initialized properly");
			}
			SetInternalAvatarPose(avatarPose.GetUnsafeReadOnlyPtr(), avatarPose.Length);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_CreateFromRoot_Injected(IntPtr avatar, IntPtr root);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Internal_CreateFromJointPaths_Injected(IntPtr avatar, string[] jointPaths);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetHumanPose_Injected(IntPtr _unity_self, out Vector3 bodyPosition, out Quaternion bodyRotation, out BlittableArrayWrapper muscles, out BlittableArrayWrapper ikGoalPositions, out BlittableArrayWrapper ikGoalRotations);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetHumanPose_Injected(IntPtr _unity_self, ref Vector3 bodyPosition, ref Quaternion bodyRotation, ref ManagedSpanWrapper muscles);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetInternalHumanPose_Injected(IntPtr _unity_self, out Vector3 bodyPosition, out Quaternion bodyRotation, out BlittableArrayWrapper muscles, out BlittableArrayWrapper ikGoalPositions, out BlittableArrayWrapper ikGoalRotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetInternalHumanPose_Injected(IntPtr _unity_self, ref Vector3 bodyPosition, ref Quaternion bodyRotation, ref ManagedSpanWrapper muscles);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void GetInternalAvatarPose_Injected(IntPtr _unity_self, void* avatarPose, int avatarPoseLength);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void SetInternalAvatarPose_Injected(IntPtr _unity_self, void* avatarPose, int avatarPoseLength);
	}
	[NativeHeader("Modules/Animation/HumanTrait.h")]
	public class HumanTrait
	{
		public static extern int MuscleCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern string[] MuscleName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("GetMuscleNames")]
			get;
		}

		public static extern int BoneCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static extern string[] BoneName
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("MonoBoneNames")]
			get;
		}

		public static extern int RequiredBoneCount
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			[NativeMethod("RequiredBoneCount")]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetBoneIndexFromMono(int humanId);

		[MethodImpl(MethodImplOptions.InternalCall)]
		internal static extern int GetBoneIndexToMono(int boneIndex);

		public static int MuscleFromBone(int i, int dofIndex)
		{
			return Internal_MuscleFromBone(GetBoneIndexFromMono(i), dofIndex);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("MuscleFromBone")]
		private static extern int Internal_MuscleFromBone(int i, int dofIndex);

		public static int BoneFromMuscle(int i)
		{
			return GetBoneIndexToMono(Internal_BoneFromMuscle(i));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("BoneFromMuscle")]
		private static extern int Internal_BoneFromMuscle(int i);

		public static bool RequiredBone(int i)
		{
			return Internal_RequiredBone(GetBoneIndexFromMono(i));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("RequiredBone")]
		private static extern bool Internal_RequiredBone(int i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetMuscleDefaultMin(int i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern float GetMuscleDefaultMax(int i);

		public static float GetBoneDefaultHierarchyMass(int i)
		{
			return Internal_GetBoneHierarchyMass(GetBoneIndexFromMono(i));
		}

		public static int GetParentBone(int i)
		{
			int num = Internal_GetParent(GetBoneIndexFromMono(i));
			return (num != -1) ? GetBoneIndexToMono(num) : (-1);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetBoneHierarchyMass")]
		private static extern float Internal_GetBoneHierarchyMass(int i);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod("GetParent")]
		private static extern int Internal_GetParent(int i);
	}
	[NativeHeader("Modules/Animation/Motion.h")]
	public class Motion : Object
	{
		public float averageDuration
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_averageDuration_Injected(intPtr);
			}
		}

		public float averageAngularSpeed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_averageAngularSpeed_Injected(intPtr);
			}
		}

		public Vector3 averageSpeed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_averageSpeed_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public float apparentSpeed
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_apparentSpeed_Injected(intPtr);
			}
		}

		public bool isLooping
		{
			[NativeMethod("IsLooping")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isLooping_Injected(intPtr);
			}
		}

		public bool legacy
		{
			[NativeMethod("IsLegacy")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_legacy_Injected(intPtr);
			}
		}

		public bool isHumanMotion
		{
			[NativeMethod("IsHumanMotion")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_isHumanMotion_Injected(intPtr);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("isAnimatorMotion is not supported anymore, please use !legacy instead.", true)]
		public bool isAnimatorMotion { get; }

		protected Motion()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("ValidateIfRetargetable is not supported anymore, please use isHumanMotion instead.", true)]
		public bool ValidateIfRetargetable(bool val)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_averageDuration_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_averageAngularSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_averageSpeed_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_apparentSpeed_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isLooping_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_legacy_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_isHumanMotion_Injected(IntPtr _unity_self);
	}
	[UsedByNativeCode]
	[NativeHeader("Modules/Animation/RuntimeAnimatorController.h")]
	[ExcludeFromObjectFactory]
	public class RuntimeAnimatorController : Object
	{
		public AnimationClip[] animationClips
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_animationClips_Injected(intPtr);
			}
		}

		protected RuntimeAnimatorController()
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationClip[] get_animationClips_Injected(IntPtr _unity_self);
	}
}
namespace UnityEngine.Experimental.Animations
{
	public enum AnimationStreamSource
	{
		DefaultValues,
		PreviousInputs
	}
	[NativeHeader("Modules/Animation/AnimatorDefines.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationPlayableOutputExtensions.bindings.h")]
	[StaticAccessor("AnimationPlayableOutputExtensionsBindings", StaticAccessorType.DoubleColon)]
	public static class AnimationPlayableOutputExtensions
	{
		public static AnimationStreamSource GetAnimationStreamSource(this AnimationPlayableOutput output)
		{
			return InternalGetAnimationStreamSource(output.GetHandle());
		}

		public static void SetAnimationStreamSource(this AnimationPlayableOutput output, AnimationStreamSource streamSource)
		{
			InternalSetAnimationStreamSource(output.GetHandle(), streamSource);
		}

		public static ushort GetSortingOrder(this AnimationPlayableOutput output)
		{
			return (ushort)InternalGetSortingOrder(output.GetHandle());
		}

		public static void SetSortingOrder(this AnimationPlayableOutput output, ushort sortingOrder)
		{
			InternalSetSortingOrder(output.GetHandle(), sortingOrder);
		}

		[NativeThrows]
		private static AnimationStreamSource InternalGetAnimationStreamSource(PlayableOutputHandle output)
		{
			return InternalGetAnimationStreamSource_Injected(ref output);
		}

		[NativeThrows]
		private static void InternalSetAnimationStreamSource(PlayableOutputHandle output, AnimationStreamSource streamSource)
		{
			InternalSetAnimationStreamSource_Injected(ref output, streamSource);
		}

		[NativeThrows]
		private static int InternalGetSortingOrder(PlayableOutputHandle output)
		{
			return InternalGetSortingOrder_Injected(ref output);
		}

		[NativeThrows]
		private static void InternalSetSortingOrder(PlayableOutputHandle output, int sortingOrder)
		{
			InternalSetSortingOrder_Injected(ref output, sortingOrder);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern AnimationStreamSource InternalGetAnimationStreamSource_Injected([In] ref PlayableOutputHandle output);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetAnimationStreamSource_Injected([In] ref PlayableOutputHandle output, AnimationStreamSource streamSource);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int InternalGetSortingOrder_Injected([In] ref PlayableOutputHandle output);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetSortingOrder_Injected([In] ref PlayableOutputHandle output, int sortingOrder);
	}
}
namespace UnityEngine.Playables
{
	public static class AnimationPlayableUtilities
	{
		[Obsolete("This function is no longer used as it overrides the Time Update Mode of the Playable Graph. Refer to the documentation for an example of an equivalent function.")]
		public static void Play(Animator animator, Playable playable, PlayableGraph graph)
		{
			AnimationPlayableOutput output = AnimationPlayableOutput.Create(graph, "AnimationClip", animator);
			output.SetSourcePlayable(playable, 0);
			graph.SyncUpdateAndTimeMode(animator);
			graph.Play();
		}

		public static AnimationClipPlayable PlayClip(Animator animator, AnimationClip clip, out PlayableGraph graph)
		{
			graph = PlayableGraph.Create();
			AnimationPlayableOutput output = AnimationPlayableOutput.Create(graph, "AnimationClip", animator);
			AnimationClipPlayable animationClipPlayable = AnimationClipPlayable.Create(graph, clip);
			output.SetSourcePlayable(animationClipPlayable);
			graph.SyncUpdateAndTimeMode(animator);
			graph.Play();
			return animationClipPlayable;
		}

		public static AnimationMixerPlayable PlayMixer(Animator animator, int inputCount, out PlayableGraph graph)
		{
			graph = PlayableGraph.Create();
			AnimationPlayableOutput output = AnimationPlayableOutput.Create(graph, "Mixer", animator);
			AnimationMixerPlayable animationMixerPlayable = AnimationMixerPlayable.Create(graph, inputCount);
			output.SetSourcePlayable(animationMixerPlayable);
			graph.SyncUpdateAndTimeMode(animator);
			graph.Play();
			return animationMixerPlayable;
		}

		public static AnimationLayerMixerPlayable PlayLayerMixer(Animator animator, int inputCount, out PlayableGraph graph)
		{
			graph = PlayableGraph.Create();
			AnimationPlayableOutput output = AnimationPlayableOutput.Create(graph, "Mixer", animator);
			AnimationLayerMixerPlayable animationLayerMixerPlayable = AnimationLayerMixerPlayable.Create(graph, inputCount);
			output.SetSourcePlayable(animationLayerMixerPlayable);
			graph.SyncUpdateAndTimeMode(animator);
			graph.Play();
			return animationLayerMixerPlayable;
		}

		public static AnimatorControllerPlayable PlayAnimatorController(Animator animator, RuntimeAnimatorController controller, out PlayableGraph graph)
		{
			graph = PlayableGraph.Create();
			AnimationPlayableOutput output = AnimationPlayableOutput.Create(graph, "AnimatorControllerPlayable", animator);
			AnimatorControllerPlayable animatorControllerPlayable = AnimatorControllerPlayable.Create(graph, controller);
			output.SetSourcePlayable(animatorControllerPlayable);
			graph.SyncUpdateAndTimeMode(animator);
			graph.Play();
			return animatorControllerPlayable;
		}
	}
}
namespace UnityEngine.Animations
{
	public static class AnimationPlayableBinding
	{
		public static PlayableBinding Create(string name, Object key)
		{
			return PlayableBinding.CreateInternal(name, key, typeof(Animator), CreateAnimationOutput);
		}

		private static PlayableOutput CreateAnimationOutput(PlayableGraph graph, string name)
		{
			return AnimationPlayableOutput.Create(graph, name, null);
		}
	}
	[RequiredByNativeCode]
	[AttributeUsage(AttributeTargets.Field)]
	public class DiscreteEvaluationAttribute : Attribute
	{
	}
	internal static class DiscreteEvaluationAttributeUtilities
	{
		public unsafe static int ConvertFloatToDiscreteInt(float f)
		{
			float* ptr = &f;
			int* ptr2 = (int*)ptr;
			return *ptr2;
		}

		public unsafe static float ConvertDiscreteIntToFloat(int f)
		{
			int* ptr = &f;
			float* ptr2 = (float*)ptr;
			return *ptr2;
		}
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[JobProducerType(typeof(ProcessAnimationJobStruct<>))]
	public interface IAnimationJob
	{
		void ProcessAnimation(AnimationStream stream);

		void ProcessRootMotion(AnimationStream stream);
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	public interface IAnimationJobPlayable : IPlayable
	{
		T GetJobData<T>() where T : struct, IAnimationJob;

		void SetJobData<T>(T jobData) where T : struct, IAnimationJob;
	}
	[UsedByNativeCode]
	internal interface IAnimationPreviewable
	{
		void OnPreviewUpdate();
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	public interface IAnimationWindowPreview
	{
		void StartPreview();

		void StopPreview();

		void UpdatePreviewGraph(PlayableGraph graph);

		Playable BuildPreviewGraph(PlayableGraph graph, Playable inputPlayable);
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Field)]
	[RequiredByNativeCode]
	public class NotKeyableAttribute : Attribute
	{
	}
	internal enum JobMethodIndex
	{
		ProcessRootMotionMethodIndex,
		ProcessAnimationMethodIndex,
		MethodIndexCount
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct ProcessAnimationJobStruct<T> where T : struct, IAnimationJob
	{
		public delegate void ExecuteJobFunction(ref T data, IntPtr animationStreamPtr, IntPtr unusedPtr, ref JobRanges ranges, int jobIndex);

		private static IntPtr jobReflectionData;

		public static IntPtr GetJobReflectionData()
		{
			if (jobReflectionData == IntPtr.Zero)
			{
				jobReflectionData = JobsUtility.CreateJobReflectionData(typeof(T), new ExecuteJobFunction(Execute));
			}
			return jobReflectionData;
		}

		public unsafe static void Execute(ref T data, IntPtr animationStreamPtr, IntPtr methodIndex, ref JobRanges ranges, int jobIndex)
		{
			UnsafeUtility.CopyPtrToStructure<AnimationStream>((void*)animationStreamPtr, out var output);
			switch ((JobMethodIndex)methodIndex.ToInt32())
			{
			case JobMethodIndex.ProcessRootMotionMethodIndex:
				data.ProcessRootMotion(output);
				break;
			case JobMethodIndex.ProcessAnimationMethodIndex:
				data.ProcessAnimation(output);
				break;
			default:
				throw new NotImplementedException("Invalid Animation jobs method index.");
			}
		}
	}
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	[UsedByNativeCode]
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Modules/Animation/Constraints/AimConstraint.h")]
	public sealed class AimConstraint : Behaviour, IConstraint, IConstraintInternal
	{
		public enum WorldUpType
		{
			SceneUp,
			ObjectUp,
			ObjectRotationUp,
			Vector,
			None
		}

		public float weight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public bool constraintActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraintActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraintActive_Injected(intPtr, value);
			}
		}

		public bool locked
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_locked_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_locked_Injected(intPtr, value);
			}
		}

		public Vector3 rotationAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAtRest_Injected(intPtr, ref value);
			}
		}

		public Vector3 rotationOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationOffset_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationOffset_Injected(intPtr, ref value);
			}
		}

		public Axis rotationAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rotationAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAxis_Injected(intPtr, value);
			}
		}

		public Vector3 aimVector
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_aimVector_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_aimVector_Injected(intPtr, ref value);
			}
		}

		public Vector3 upVector
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_upVector_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_upVector_Injected(intPtr, ref value);
			}
		}

		public Vector3 worldUpVector
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_worldUpVector_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_worldUpVector_Injected(intPtr, ref value);
			}
		}

		public Transform worldUpObject
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Transform>(get_worldUpObject_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_worldUpObject_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public WorldUpType worldUpType
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_worldUpType_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_worldUpType_Injected(intPtr, value);
			}
		}

		public int sourceCount => GetSourceCountInternal(this);

		private AimConstraint()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] AimConstraint self);

		[FreeFunction("ConstraintBindings::GetSourceCount")]
		private static int GetSourceCountInternal([NotNull] AimConstraint self)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			return GetSourceCountInternal_Injected(intPtr);
		}

		[FreeFunction(Name = "ConstraintBindings::GetSources", HasExplicitThis = true)]
		public void GetSources([NotNull] List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				ThrowHelper.ThrowArgumentNullException(sources, "sources");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSources_Injected(intPtr, sources);
		}

		public void SetSources(List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			SetSourcesInternal(this, sources);
		}

		[FreeFunction("ConstraintBindings::SetSources", ThrowsException = true)]
		private static void SetSourcesInternal([NotNull] AimConstraint self, List<ConstraintSource> sources)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			SetSourcesInternal_Injected(intPtr, sources);
		}

		public int AddSource(ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddSource_Injected(intPtr, ref source);
		}

		public void RemoveSource(int index)
		{
			ValidateSourceIndex(index);
			RemoveSourceInternal(index);
		}

		[NativeName("RemoveSource")]
		private void RemoveSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveSourceInternal_Injected(intPtr, index);
		}

		public ConstraintSource GetSource(int index)
		{
			ValidateSourceIndex(index);
			return GetSourceInternal(index);
		}

		[NativeName("GetSource")]
		private ConstraintSource GetSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSourceInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		public void SetSource(int index, ConstraintSource source)
		{
			ValidateSourceIndex(index);
			SetSourceInternal(index, source);
		}

		[NativeName("SetSource")]
		private void SetSourceInternal(int index, ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSourceInternal_Injected(intPtr, index, ref source);
		}

		private void ValidateSourceIndex(int index)
		{
			if (sourceCount == 0)
			{
				throw new InvalidOperationException("The AimConstraint component has no sources.");
			}
			if (index < 0 || index >= sourceCount)
			{
				throw new ArgumentOutOfRangeException("index", $"Constraint source index {index} is out of bounds (0-{sourceCount}).");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_constraintActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraintActive_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_locked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_locked_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationOffset_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationOffset_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Axis get_rotationAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAxis_Injected(IntPtr _unity_self, Axis value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_aimVector_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_aimVector_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_upVector_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_upVector_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_worldUpVector_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_worldUpVector_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_worldUpObject_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_worldUpObject_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern WorldUpType get_worldUpType_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_worldUpType_Injected(IntPtr _unity_self, WorldUpType value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceCountInternal_Injected(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSources_Injected(IntPtr _unity_self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcesInternal_Injected(IntPtr self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddSource_Injected(IntPtr _unity_self, [In] ref ConstraintSource source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveSourceInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourceInternal_Injected(IntPtr _unity_self, int index, out ConstraintSource ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourceInternal_Injected(IntPtr _unity_self, int index, [In] ref ConstraintSource source);
	}
	[RequiredByNativeCode]
	[StaticAccessor("AnimationClipPlayableBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/Animation/Director/AnimationClipPlayable.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationClipPlayable.bindings.h")]
	public struct AnimationClipPlayable : IPlayable, IEquatable<AnimationClipPlayable>
	{
		private PlayableHandle m_Handle;

		public static AnimationClipPlayable Create(PlayableGraph graph, AnimationClip clip)
		{
			PlayableHandle handle = CreateHandle(graph, clip);
			return new AnimationClipPlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, AnimationClip clip)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, clip, ref handle))
			{
				return PlayableHandle.Null;
			}
			return handle;
		}

		internal AnimationClipPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationClipPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationClipPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationClipPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationClipPlayable(Playable playable)
		{
			return new AnimationClipPlayable(playable.GetHandle());
		}

		public bool Equals(AnimationClipPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public AnimationClip GetAnimationClip()
		{
			return GetAnimationClipInternal(ref m_Handle);
		}

		public bool GetApplyFootIK()
		{
			return GetApplyFootIKInternal(ref m_Handle);
		}

		public void SetApplyFootIK(bool value)
		{
			SetApplyFootIKInternal(ref m_Handle, value);
		}

		public bool GetApplyPlayableIK()
		{
			return GetApplyPlayableIKInternal(ref m_Handle);
		}

		public void SetApplyPlayableIK(bool value)
		{
			SetApplyPlayableIKInternal(ref m_Handle, value);
		}

		internal bool GetRemoveStartOffset()
		{
			return GetRemoveStartOffsetInternal(ref m_Handle);
		}

		internal void SetRemoveStartOffset(bool value)
		{
			SetRemoveStartOffsetInternal(ref m_Handle, value);
		}

		internal bool GetOverrideLoopTime()
		{
			return GetOverrideLoopTimeInternal(ref m_Handle);
		}

		internal void SetOverrideLoopTime(bool value)
		{
			SetOverrideLoopTimeInternal(ref m_Handle, value);
		}

		internal bool GetLoopTime()
		{
			return GetLoopTimeInternal(ref m_Handle);
		}

		internal void SetLoopTime(bool value)
		{
			SetLoopTimeInternal(ref m_Handle, value);
		}

		internal float GetSampleRate()
		{
			return GetSampleRateInternal(ref m_Handle);
		}

		internal void SetSampleRate(float value)
		{
			SetSampleRateInternal(ref m_Handle, value);
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, AnimationClip clip, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, Object.MarshalledUnityObject.Marshal(clip), ref handle);
		}

		[NativeThrows]
		private static AnimationClip GetAnimationClipInternal(ref PlayableHandle handle)
		{
			return Unmarshal.UnmarshalUnityObject<AnimationClip>(GetAnimationClipInternal_Injected(ref handle));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetApplyFootIKInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetApplyFootIKInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetApplyPlayableIKInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetApplyPlayableIKInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetRemoveStartOffsetInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetRemoveStartOffsetInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetOverrideLoopTimeInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetOverrideLoopTimeInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetLoopTimeInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetLoopTimeInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetSampleRateInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetSampleRateInternal(ref PlayableHandle handle, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, IntPtr clip, ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetAnimationClipInternal_Injected(ref PlayableHandle handle);
	}
	[RequiredByNativeCode]
	[NativeHeader("Modules/Animation/Director/AnimationHumanStream.h")]
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationHumanStream.bindings.h")]
	public struct AnimationHumanStream
	{
		private IntPtr stream;

		public bool isValid => stream != IntPtr.Zero;

		public float humanScale
		{
			get
			{
				ThrowIfInvalid();
				return GetHumanScale();
			}
		}

		public float leftFootHeight
		{
			get
			{
				ThrowIfInvalid();
				return GetFootHeight(left: true);
			}
		}

		public float rightFootHeight
		{
			get
			{
				ThrowIfInvalid();
				return GetFootHeight(left: false);
			}
		}

		public Vector3 bodyLocalPosition
		{
			get
			{
				ThrowIfInvalid();
				return InternalGetBodyLocalPosition();
			}
			set
			{
				ThrowIfInvalid();
				InternalSetBodyLocalPosition(value);
			}
		}

		public Quaternion bodyLocalRotation
		{
			get
			{
				ThrowIfInvalid();
				return InternalGetBodyLocalRotation();
			}
			set
			{
				ThrowIfInvalid();
				InternalSetBodyLocalRotation(value);
			}
		}

		public Vector3 bodyPosition
		{
			get
			{
				ThrowIfInvalid();
				return InternalGetBodyPosition();
			}
			set
			{
				ThrowIfInvalid();
				InternalSetBodyPosition(value);
			}
		}

		public Quaternion bodyRotation
		{
			get
			{
				ThrowIfInvalid();
				return InternalGetBodyRotation();
			}
			set
			{
				ThrowIfInvalid();
				InternalSetBodyRotation(value);
			}
		}

		public Vector3 leftFootVelocity
		{
			get
			{
				ThrowIfInvalid();
				return GetLeftFootVelocity();
			}
		}

		public Vector3 rightFootVelocity
		{
			get
			{
				ThrowIfInvalid();
				return GetRightFootVelocity();
			}
		}

		private void ThrowIfInvalid()
		{
			if (!isValid)
			{
				throw new InvalidOperationException("The AnimationHumanStream is invalid.");
			}
		}

		public float GetMuscle(MuscleHandle muscle)
		{
			ThrowIfInvalid();
			return InternalGetMuscle(muscle);
		}

		public void SetMuscle(MuscleHandle muscle, float value)
		{
			ThrowIfInvalid();
			InternalSetMuscle(muscle, value);
		}

		public void ResetToStancePose()
		{
			ThrowIfInvalid();
			InternalResetToStancePose();
		}

		public Vector3 GetGoalPositionFromPose(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalPositionFromPose(index);
		}

		public Quaternion GetGoalRotationFromPose(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalRotationFromPose(index);
		}

		public Vector3 GetGoalLocalPosition(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalLocalPosition(index);
		}

		public void SetGoalLocalPosition(AvatarIKGoal index, Vector3 pos)
		{
			ThrowIfInvalid();
			InternalSetGoalLocalPosition(index, pos);
		}

		public Quaternion GetGoalLocalRotation(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalLocalRotation(index);
		}

		public void SetGoalLocalRotation(AvatarIKGoal index, Quaternion rot)
		{
			ThrowIfInvalid();
			InternalSetGoalLocalRotation(index, rot);
		}

		public Vector3 GetGoalPosition(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalPosition(index);
		}

		public void SetGoalPosition(AvatarIKGoal index, Vector3 pos)
		{
			ThrowIfInvalid();
			InternalSetGoalPosition(index, pos);
		}

		public Quaternion GetGoalRotation(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalRotation(index);
		}

		public void SetGoalRotation(AvatarIKGoal index, Quaternion rot)
		{
			ThrowIfInvalid();
			InternalSetGoalRotation(index, rot);
		}

		public void SetGoalWeightPosition(AvatarIKGoal index, float value)
		{
			ThrowIfInvalid();
			InternalSetGoalWeightPosition(index, value);
		}

		public void SetGoalWeightRotation(AvatarIKGoal index, float value)
		{
			ThrowIfInvalid();
			InternalSetGoalWeightRotation(index, value);
		}

		public float GetGoalWeightPosition(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalWeightPosition(index);
		}

		public float GetGoalWeightRotation(AvatarIKGoal index)
		{
			ThrowIfInvalid();
			return InternalGetGoalWeightRotation(index);
		}

		public Vector3 GetHintPosition(AvatarIKHint index)
		{
			ThrowIfInvalid();
			return InternalGetHintPosition(index);
		}

		public void SetHintPosition(AvatarIKHint index, Vector3 pos)
		{
			ThrowIfInvalid();
			InternalSetHintPosition(index, pos);
		}

		public void SetHintWeightPosition(AvatarIKHint index, float value)
		{
			ThrowIfInvalid();
			InternalSetHintWeightPosition(index, value);
		}

		public float GetHintWeightPosition(AvatarIKHint index)
		{
			ThrowIfInvalid();
			return InternalGetHintWeightPosition(index);
		}

		public void SetLookAtPosition(Vector3 lookAtPosition)
		{
			ThrowIfInvalid();
			InternalSetLookAtPosition(lookAtPosition);
		}

		public void SetLookAtClampWeight(float weight)
		{
			ThrowIfInvalid();
			InternalSetLookAtClampWeight(weight);
		}

		public void SetLookAtBodyWeight(float weight)
		{
			ThrowIfInvalid();
			InternalSetLookAtBodyWeight(weight);
		}

		public void SetLookAtHeadWeight(float weight)
		{
			ThrowIfInvalid();
			InternalSetLookAtHeadWeight(weight);
		}

		public void SetLookAtEyesWeight(float weight)
		{
			ThrowIfInvalid();
			InternalSetLookAtEyesWeight(weight);
		}

		public void SolveIK()
		{
			ThrowIfInvalid();
			InternalSolveIK();
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private extern float GetHumanScale();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private extern float GetFootHeight(bool left);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "ResetToStancePose", IsThreadSafe = true)]
		private extern void InternalResetToStancePose();

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetGoalPositionFromPose", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 InternalGetGoalPositionFromPose(AvatarIKGoal index)
		{
			InternalGetGoalPositionFromPose_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetGoalRotationFromPose", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion InternalGetGoalRotationFromPose(AvatarIKGoal index)
		{
			InternalGetGoalRotationFromPose_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetBodyLocalPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 InternalGetBodyLocalPosition()
		{
			InternalGetBodyLocalPosition_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetBodyLocalPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetBodyLocalPosition(Vector3 value)
		{
			InternalSetBodyLocalPosition_Injected(ref this, ref value);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetBodyLocalRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion InternalGetBodyLocalRotation()
		{
			InternalGetBodyLocalRotation_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetBodyLocalRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetBodyLocalRotation(Quaternion value)
		{
			InternalSetBodyLocalRotation_Injected(ref this, ref value);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetBodyPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 InternalGetBodyPosition()
		{
			InternalGetBodyPosition_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetBodyPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetBodyPosition(Vector3 value)
		{
			InternalSetBodyPosition_Injected(ref this, ref value);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetBodyRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion InternalGetBodyRotation()
		{
			InternalGetBodyRotation_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetBodyRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetBodyRotation(Quaternion value)
		{
			InternalSetBodyRotation_Injected(ref this, ref value);
		}

		[NativeMethod(Name = "GetMuscle", IsThreadSafe = true)]
		private float InternalGetMuscle(MuscleHandle muscle)
		{
			return InternalGetMuscle_Injected(ref this, ref muscle);
		}

		[NativeMethod(Name = "SetMuscle", IsThreadSafe = true)]
		private void InternalSetMuscle(MuscleHandle muscle, float value)
		{
			InternalSetMuscle_Injected(ref this, ref muscle, value);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetLeftFootVelocity", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetLeftFootVelocity()
		{
			GetLeftFootVelocity_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetRightFootVelocity", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetRightFootVelocity()
		{
			GetRightFootVelocity_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetGoalLocalPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 InternalGetGoalLocalPosition(AvatarIKGoal index)
		{
			InternalGetGoalLocalPosition_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetGoalLocalPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetGoalLocalPosition(AvatarIKGoal index, Vector3 pos)
		{
			InternalSetGoalLocalPosition_Injected(ref this, index, ref pos);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetGoalLocalRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion InternalGetGoalLocalRotation(AvatarIKGoal index)
		{
			InternalGetGoalLocalRotation_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetGoalLocalRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetGoalLocalRotation(AvatarIKGoal index, Quaternion rot)
		{
			InternalSetGoalLocalRotation_Injected(ref this, index, ref rot);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetGoalPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 InternalGetGoalPosition(AvatarIKGoal index)
		{
			InternalGetGoalPosition_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetGoalPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetGoalPosition(AvatarIKGoal index, Vector3 pos)
		{
			InternalSetGoalPosition_Injected(ref this, index, ref pos);
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetGoalRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion InternalGetGoalRotation(AvatarIKGoal index)
		{
			InternalGetGoalRotation_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetGoalRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetGoalRotation(AvatarIKGoal index, Quaternion rot)
		{
			InternalSetGoalRotation_Injected(ref this, index, ref rot);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetGoalWeightPosition", IsThreadSafe = true)]
		private extern void InternalSetGoalWeightPosition(AvatarIKGoal index, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetGoalWeightRotation", IsThreadSafe = true)]
		private extern void InternalSetGoalWeightRotation(AvatarIKGoal index, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetGoalWeightPosition", IsThreadSafe = true)]
		private extern float InternalGetGoalWeightPosition(AvatarIKGoal index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetGoalWeightRotation", IsThreadSafe = true)]
		private extern float InternalGetGoalWeightRotation(AvatarIKGoal index);

		[NativeMethod(Name = "AnimationHumanStreamBindings::GetHintPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 InternalGetHintPosition(AvatarIKHint index)
		{
			InternalGetHintPosition_Injected(ref this, index, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetHintPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetHintPosition(AvatarIKHint index, Vector3 pos)
		{
			InternalSetHintPosition_Injected(ref this, index, ref pos);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetHintWeightPosition", IsThreadSafe = true)]
		private extern void InternalSetHintWeightPosition(AvatarIKHint index, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetHintWeightPosition", IsThreadSafe = true)]
		private extern float InternalGetHintWeightPosition(AvatarIKHint index);

		[NativeMethod(Name = "AnimationHumanStreamBindings::SetLookAtPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void InternalSetLookAtPosition(Vector3 lookAtPosition)
		{
			InternalSetLookAtPosition_Injected(ref this, ref lookAtPosition);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetLookAtClampWeight", IsThreadSafe = true)]
		private extern void InternalSetLookAtClampWeight(float weight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetLookAtBodyWeight", IsThreadSafe = true)]
		private extern void InternalSetLookAtBodyWeight(float weight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetLookAtHeadWeight", IsThreadSafe = true)]
		private extern void InternalSetLookAtHeadWeight(float weight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetLookAtEyesWeight", IsThreadSafe = true)]
		private extern void InternalSetLookAtEyesWeight(float weight);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SolveIK", IsThreadSafe = true)]
		private extern void InternalSolveIK();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetGoalPositionFromPose_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetGoalRotationFromPose_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetBodyLocalPosition_Injected(ref AnimationHumanStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetBodyLocalPosition_Injected(ref AnimationHumanStream _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetBodyLocalRotation_Injected(ref AnimationHumanStream _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetBodyLocalRotation_Injected(ref AnimationHumanStream _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetBodyPosition_Injected(ref AnimationHumanStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetBodyPosition_Injected(ref AnimationHumanStream _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetBodyRotation_Injected(ref AnimationHumanStream _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetBodyRotation_Injected(ref AnimationHumanStream _unity_self, [In] ref Quaternion value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float InternalGetMuscle_Injected(ref AnimationHumanStream _unity_self, [In] ref MuscleHandle muscle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetMuscle_Injected(ref AnimationHumanStream _unity_self, [In] ref MuscleHandle muscle, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLeftFootVelocity_Injected(ref AnimationHumanStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRightFootVelocity_Injected(ref AnimationHumanStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetGoalLocalPosition_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetGoalLocalPosition_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, [In] ref Vector3 pos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetGoalLocalRotation_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetGoalLocalRotation_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, [In] ref Quaternion rot);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetGoalPosition_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetGoalPosition_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, [In] ref Vector3 pos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetGoalRotation_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetGoalRotation_Injected(ref AnimationHumanStream _unity_self, AvatarIKGoal index, [In] ref Quaternion rot);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetHintPosition_Injected(ref AnimationHumanStream _unity_self, AvatarIKHint index, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetHintPosition_Injected(ref AnimationHumanStream _unity_self, AvatarIKHint index, [In] ref Vector3 pos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetLookAtPosition_Injected(ref AnimationHumanStream _unity_self, [In] ref Vector3 lookAtPosition);
	}
	[RequiredByNativeCode]
	[StaticAccessor("AnimationLayerMixerPlayableBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Modules/Animation/Director/AnimationLayerMixerPlayable.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationLayerMixerPlayable.bindings.h")]
	public struct AnimationLayerMixerPlayable : IPlayable, IEquatable<AnimationLayerMixerPlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationLayerMixerPlayable m_NullPlayable = new AnimationLayerMixerPlayable(PlayableHandle.Null);

		public static AnimationLayerMixerPlayable Null => m_NullPlayable;

		public static AnimationLayerMixerPlayable Create(PlayableGraph graph, int inputCount = 0)
		{
			return Create(graph, inputCount, singleLayerOptimization: true);
		}

		public static AnimationLayerMixerPlayable Create(PlayableGraph graph, int inputCount, bool singleLayerOptimization)
		{
			PlayableHandle handle = CreateHandle(graph, inputCount);
			return new AnimationLayerMixerPlayable(handle, singleLayerOptimization);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, int inputCount = 0)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, ref handle))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(inputCount);
			return handle;
		}

		internal AnimationLayerMixerPlayable(PlayableHandle handle, bool singleLayerOptimization = true)
		{
			if (handle.IsValid())
			{
				if (!handle.IsPlayableOfType<AnimationLayerMixerPlayable>())
				{
					throw new InvalidCastException("Can't set handle: the playable is not an AnimationLayerMixerPlayable.");
				}
				SetSingleLayerOptimizationInternal(ref handle, singleLayerOptimization);
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationLayerMixerPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationLayerMixerPlayable(Playable playable)
		{
			return new AnimationLayerMixerPlayable(playable.GetHandle());
		}

		public bool Equals(AnimationLayerMixerPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public bool IsLayerAdditive(uint layerIndex)
		{
			if (layerIndex >= m_Handle.GetInputCount())
			{
				throw new ArgumentOutOfRangeException("layerIndex", $"layerIndex {layerIndex} must be in the range of 0 to {m_Handle.GetInputCount() - 1}.");
			}
			return IsLayerAdditiveInternal(ref m_Handle, layerIndex);
		}

		public void SetLayerAdditive(uint layerIndex, bool value)
		{
			if (layerIndex >= m_Handle.GetInputCount())
			{
				throw new ArgumentOutOfRangeException("layerIndex", $"layerIndex {layerIndex} must be in the range of 0 to {m_Handle.GetInputCount() - 1}.");
			}
			SetLayerAdditiveInternal(ref m_Handle, layerIndex, value);
		}

		public void SetLayerMaskFromAvatarMask(uint layerIndex, AvatarMask mask)
		{
			if (layerIndex >= m_Handle.GetInputCount())
			{
				throw new ArgumentOutOfRangeException("layerIndex", $"layerIndex {layerIndex} must be in the range of 0 to {m_Handle.GetInputCount() - 1}.");
			}
			if (mask == null)
			{
				throw new ArgumentNullException("mask");
			}
			SetLayerMaskFromAvatarMaskInternal(ref m_Handle, layerIndex, mask);
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool IsLayerAdditiveInternal(ref PlayableHandle handle, uint layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetLayerAdditiveInternal(ref PlayableHandle handle, uint layerIndex, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetSingleLayerOptimizationInternal(ref PlayableHandle handle, bool value);

		[NativeThrows]
		private static void SetLayerMaskFromAvatarMaskInternal(ref PlayableHandle handle, uint layerIndex, AvatarMask mask)
		{
			SetLayerMaskFromAvatarMaskInternal_Injected(ref handle, layerIndex, Object.MarshalledUnityObject.Marshal(mask));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLayerMaskFromAvatarMaskInternal_Injected(ref PlayableHandle handle, uint layerIndex, IntPtr mask);
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationMixerPlayable.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationMixerPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("AnimationMixerPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct AnimationMixerPlayable : IPlayable, IEquatable<AnimationMixerPlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationMixerPlayable m_NullPlayable = new AnimationMixerPlayable(PlayableHandle.Null);

		public static AnimationMixerPlayable Null => m_NullPlayable;

		[Obsolete("normalizeWeights is obsolete. It has no effect and will be removed.")]
		public static AnimationMixerPlayable Create(PlayableGraph graph, int inputCount, bool normalizeWeights)
		{
			return Create(graph, inputCount);
		}

		public static AnimationMixerPlayable Create(PlayableGraph graph, int inputCount = 0)
		{
			PlayableHandle handle = CreateHandle(graph, inputCount);
			return new AnimationMixerPlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, int inputCount = 0)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, ref handle))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(inputCount);
			return handle;
		}

		internal AnimationMixerPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationMixerPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationMixerPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationMixerPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationMixerPlayable(Playable playable)
		{
			return new AnimationMixerPlayable(playable.GetHandle());
		}

		public bool Equals(AnimationMixerPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle);
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationMotionXToDeltaPlayable.bindings.h")]
	[StaticAccessor("AnimationMotionXToDeltaPlayableBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	internal struct AnimationMotionXToDeltaPlayable : IPlayable, IEquatable<AnimationMotionXToDeltaPlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationMotionXToDeltaPlayable m_NullPlayable = new AnimationMotionXToDeltaPlayable(PlayableHandle.Null);

		public static AnimationMotionXToDeltaPlayable Null => m_NullPlayable;

		public static AnimationMotionXToDeltaPlayable Create(PlayableGraph graph)
		{
			PlayableHandle handle = CreateHandle(graph);
			return new AnimationMotionXToDeltaPlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, ref handle))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(1);
			return handle;
		}

		private AnimationMotionXToDeltaPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationMotionXToDeltaPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationMotionXToDeltaPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationMotionXToDeltaPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationMotionXToDeltaPlayable(Playable playable)
		{
			return new AnimationMotionXToDeltaPlayable(playable.GetHandle());
		}

		public bool Equals(AnimationMotionXToDeltaPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public bool IsAbsoluteMotion()
		{
			return IsAbsoluteMotionInternal(ref m_Handle);
		}

		public void SetAbsoluteMotion(bool value)
		{
			SetAbsoluteMotionInternal(ref m_Handle, value);
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool IsAbsoluteMotionInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetAbsoluteMotionInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle);
	}
	[RequiredByNativeCode]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationOffsetPlayable.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationOffsetPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("AnimationOffsetPlayableBindings", StaticAccessorType.DoubleColon)]
	internal struct AnimationOffsetPlayable : IPlayable, IEquatable<AnimationOffsetPlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationOffsetPlayable m_NullPlayable = new AnimationOffsetPlayable(PlayableHandle.Null);

		public static AnimationOffsetPlayable Null => m_NullPlayable;

		public static AnimationOffsetPlayable Create(PlayableGraph graph, Vector3 position, Quaternion rotation, int inputCount)
		{
			PlayableHandle handle = CreateHandle(graph, position, rotation, inputCount);
			return new AnimationOffsetPlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, Vector3 position, Quaternion rotation, int inputCount)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, position, rotation, ref handle))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(inputCount);
			return handle;
		}

		internal AnimationOffsetPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationOffsetPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationOffsetPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationOffsetPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationOffsetPlayable(Playable playable)
		{
			return new AnimationOffsetPlayable(playable.GetHandle());
		}

		public bool Equals(AnimationOffsetPlayable other)
		{
			return Equals(other.GetHandle());
		}

		public Vector3 GetPosition()
		{
			return GetPositionInternal(ref m_Handle);
		}

		public void SetPosition(Vector3 value)
		{
			SetPositionInternal(ref m_Handle, value);
		}

		public Quaternion GetRotation()
		{
			return GetRotationInternal(ref m_Handle);
		}

		public void SetRotation(Quaternion value)
		{
			SetRotationInternal(ref m_Handle, value);
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, Vector3 position, Quaternion rotation, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, ref position, ref rotation, ref handle);
		}

		[NativeThrows]
		private static Vector3 GetPositionInternal(ref PlayableHandle handle)
		{
			GetPositionInternal_Injected(ref handle, out var ret);
			return ret;
		}

		[NativeThrows]
		private static void SetPositionInternal(ref PlayableHandle handle, Vector3 value)
		{
			SetPositionInternal_Injected(ref handle, ref value);
		}

		[NativeThrows]
		private static Quaternion GetRotationInternal(ref PlayableHandle handle)
		{
			GetRotationInternal_Injected(ref handle, out var ret);
			return ret;
		}

		[NativeThrows]
		private static void SetRotationInternal(ref PlayableHandle handle, Quaternion value)
		{
			SetRotationInternal_Injected(ref handle, ref value);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, [In] ref Vector3 position, [In] ref Quaternion rotation, ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPositionInternal_Injected(ref PlayableHandle handle, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPositionInternal_Injected(ref PlayableHandle handle, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRotationInternal_Injected(ref PlayableHandle handle, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetRotationInternal_Injected(ref PlayableHandle handle, [In] ref Quaternion value);
	}
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Modules/Animation/AnimationClip.h")]
	[NativeHeader("Modules/Animation/Director/AnimationPlayableExtensions.h")]
	public static class AnimationPlayableExtensions
	{
		public static void SetAnimatedProperties<U>(this U playable, AnimationClip clip) where U : struct, IPlayable
		{
			PlayableHandle playable2 = playable.GetHandle();
			SetAnimatedPropertiesInternal(ref playable2, clip);
		}

		[NativeThrows]
		internal static void SetAnimatedPropertiesInternal(ref PlayableHandle playable, AnimationClip animatedProperties)
		{
			SetAnimatedPropertiesInternal_Injected(ref playable, Object.MarshalledUnityObject.Marshal(animatedProperties));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAnimatedPropertiesInternal_Injected(ref PlayableHandle playable, IntPtr animatedProperties);
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationPlayableGraphExtensions.bindings.h")]
	[NativeHeader("Modules/Animation/Animator.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("AnimationPlayableGraphExtensionsBindings", StaticAccessorType.DoubleColon)]
	internal static class AnimationPlayableGraphExtensions
	{
		internal static void SyncUpdateAndTimeMode(this PlayableGraph graph, Animator animator)
		{
			InternalSyncUpdateAndTimeMode(ref graph, animator);
		}

		internal static void DestroyOutput(this PlayableGraph graph, PlayableOutputHandle handle)
		{
			InternalDestroyOutput(ref graph, ref handle);
		}

		[NativeThrows]
		internal unsafe static bool InternalCreateAnimationOutput(ref PlayableGraph graph, string name, out PlayableOutputHandle handle)
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
						return InternalCreateAnimationOutput_Injected(ref graph, ref managedSpanWrapper, out handle);
					}
				}
				return InternalCreateAnimationOutput_Injected(ref graph, ref managedSpanWrapper, out handle);
			}
			finally
			{
			}
		}

		[NativeThrows]
		internal static void InternalSyncUpdateAndTimeMode(ref PlayableGraph graph, [NotNull] Animator animator)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalSyncUpdateAndTimeMode_Injected(ref graph, intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void InternalDestroyOutput(ref PlayableGraph graph, ref PlayableOutputHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern int InternalAnimationOutputCount(ref PlayableGraph graph);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool InternalGetAnimationOutput(ref PlayableGraph graph, int index, out PlayableOutputHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalCreateAnimationOutput_Injected(ref PlayableGraph graph, ref ManagedSpanWrapper name, out PlayableOutputHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSyncUpdateAndTimeMode_Injected(ref PlayableGraph graph, IntPtr animator);
	}
	[StaticAccessor("AnimationPlayableOutputBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/Animation/Director/AnimationPlayableOutput.h")]
	[NativeHeader("Modules/Animation/Animator.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	[RequiredByNativeCode]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationPlayableOutput.bindings.h")]
	public struct AnimationPlayableOutput : IPlayableOutput
	{
		private PlayableOutputHandle m_Handle;

		public static AnimationPlayableOutput Null => new AnimationPlayableOutput(PlayableOutputHandle.Null);

		public static AnimationPlayableOutput Create(PlayableGraph graph, string name, Animator target)
		{
			if (!AnimationPlayableGraphExtensions.InternalCreateAnimationOutput(ref graph, name, out var handle))
			{
				return Null;
			}
			AnimationPlayableOutput result = new AnimationPlayableOutput(handle);
			result.SetTarget(target);
			return result;
		}

		internal AnimationPlayableOutput(PlayableOutputHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOutputOfType<AnimationPlayableOutput>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationPlayableOutput.");
			}
			m_Handle = handle;
		}

		public PlayableOutputHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator PlayableOutput(AnimationPlayableOutput output)
		{
			return new PlayableOutput(output.GetHandle());
		}

		public static explicit operator AnimationPlayableOutput(PlayableOutput output)
		{
			return new AnimationPlayableOutput(output.GetHandle());
		}

		public Animator GetTarget()
		{
			return InternalGetTarget(ref m_Handle);
		}

		public void SetTarget(Animator value)
		{
			InternalSetTarget(ref m_Handle, value);
		}

		[NativeThrows]
		private static Animator InternalGetTarget(ref PlayableOutputHandle handle)
		{
			return Unmarshal.UnmarshalUnityObject<Animator>(InternalGetTarget_Injected(ref handle));
		}

		[NativeThrows]
		private static void InternalSetTarget(ref PlayableOutputHandle handle, Animator target)
		{
			InternalSetTarget_Injected(ref handle, Object.MarshalledUnityObject.Marshal(target));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InternalGetTarget_Injected(ref PlayableOutputHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalSetTarget_Injected(ref PlayableOutputHandle handle, IntPtr target);
	}
	[RequiredByNativeCode]
	[StaticAccessor("AnimationPosePlayableBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/Animation/Director/AnimationPosePlayable.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationPosePlayable.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	internal struct AnimationPosePlayable : IPlayable, IEquatable<AnimationPosePlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationPosePlayable m_NullPlayable = new AnimationPosePlayable(PlayableHandle.Null);

		public static AnimationPosePlayable Null => m_NullPlayable;

		public static AnimationPosePlayable Create(PlayableGraph graph)
		{
			PlayableHandle handle = CreateHandle(graph);
			return new AnimationPosePlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, ref handle))
			{
				return PlayableHandle.Null;
			}
			return handle;
		}

		internal AnimationPosePlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationPosePlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationPosePlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationPosePlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationPosePlayable(Playable playable)
		{
			return new AnimationPosePlayable(playable.GetHandle());
		}

		public bool Equals(AnimationPosePlayable other)
		{
			return Equals(other.GetHandle());
		}

		public bool GetMustReadPreviousPose()
		{
			return GetMustReadPreviousPoseInternal(ref m_Handle);
		}

		public void SetMustReadPreviousPose(bool value)
		{
			SetMustReadPreviousPoseInternal(ref m_Handle, value);
		}

		public bool GetReadDefaultPose()
		{
			return GetReadDefaultPoseInternal(ref m_Handle);
		}

		public void SetReadDefaultPose(bool value)
		{
			SetReadDefaultPoseInternal(ref m_Handle, value);
		}

		public bool GetApplyFootIK()
		{
			return GetApplyFootIKInternal(ref m_Handle);
		}

		public void SetApplyFootIK(bool value)
		{
			SetApplyFootIKInternal(ref m_Handle, value);
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetMustReadPreviousPoseInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetMustReadPreviousPoseInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetReadDefaultPoseInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetReadDefaultPoseInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetApplyFootIKInternal(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetApplyFootIKInternal(ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle);
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationRemoveScalePlayable.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationRemoveScalePlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("AnimationRemoveScalePlayableBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	internal struct AnimationRemoveScalePlayable : IPlayable, IEquatable<AnimationRemoveScalePlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationRemoveScalePlayable m_NullPlayable = new AnimationRemoveScalePlayable(PlayableHandle.Null);

		public static AnimationRemoveScalePlayable Null => m_NullPlayable;

		public static AnimationRemoveScalePlayable Create(PlayableGraph graph, int inputCount)
		{
			PlayableHandle handle = CreateHandle(graph, inputCount);
			return new AnimationRemoveScalePlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, int inputCount)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, ref handle))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(inputCount);
			return handle;
		}

		internal AnimationRemoveScalePlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationRemoveScalePlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationRemoveScalePlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public static implicit operator Playable(AnimationRemoveScalePlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationRemoveScalePlayable(Playable playable)
		{
			return new AnimationRemoveScalePlayable(playable.GetHandle());
		}

		public bool Equals(AnimationRemoveScalePlayable other)
		{
			return Equals(other.GetHandle());
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle);
	}
	[RequiredByNativeCode]
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationScriptPlayable.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[StaticAccessor("AnimationScriptPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct AnimationScriptPlayable : IAnimationJobPlayable, IPlayable, IEquatable<AnimationScriptPlayable>
	{
		private PlayableHandle m_Handle;

		private static readonly AnimationScriptPlayable m_NullPlayable = new AnimationScriptPlayable(PlayableHandle.Null);

		public static AnimationScriptPlayable Null => m_NullPlayable;

		public static AnimationScriptPlayable Create<T>(PlayableGraph graph, T jobData, int inputCount = 0) where T : struct, IAnimationJob
		{
			PlayableHandle handle = CreateHandle<T>(graph, inputCount);
			AnimationScriptPlayable result = new AnimationScriptPlayable(handle);
			result.SetJobData(jobData);
			return result;
		}

		private static PlayableHandle CreateHandle<T>(PlayableGraph graph, int inputCount) where T : struct, IAnimationJob
		{
			IntPtr jobReflectionData = ProcessAnimationJobStruct<T>.GetJobReflectionData();
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, ref handle, jobReflectionData))
			{
				return PlayableHandle.Null;
			}
			handle.SetInputCount(inputCount);
			return handle;
		}

		internal AnimationScriptPlayable(PlayableHandle handle)
		{
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimationScriptPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimationScriptPlayable.");
			}
			m_Handle = handle;
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		private void CheckJobTypeValidity<T>()
		{
			Type jobType = GetHandle().GetJobType();
			if (jobType != typeof(T))
			{
				throw new ArgumentException($"Wrong type: the given job type ({typeof(T).FullName}) is different from the creation job type ({jobType.FullName}).");
			}
		}

		public unsafe T GetJobData<T>() where T : struct, IAnimationJob
		{
			CheckJobTypeValidity<T>();
			UnsafeUtility.CopyPtrToStructure<T>((void*)GetHandle().GetJobData(), out var output);
			return output;
		}

		public unsafe void SetJobData<T>(T jobData) where T : struct, IAnimationJob
		{
			CheckJobTypeValidity<T>();
			UnsafeUtility.CopyStructureToPtr(ref jobData, (void*)GetHandle().GetJobData());
		}

		public static implicit operator Playable(AnimationScriptPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimationScriptPlayable(Playable playable)
		{
			return new AnimationScriptPlayable(playable.GetHandle());
		}

		public bool Equals(AnimationScriptPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public void SetProcessInputs(bool value)
		{
			SetProcessInputsInternal(GetHandle(), value);
		}

		public bool GetProcessInputs()
		{
			return GetProcessInputsInternal(GetHandle());
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, ref PlayableHandle handle, IntPtr jobReflectionData)
		{
			return CreateHandleInternal_Injected(ref graph, ref handle, jobReflectionData);
		}

		[NativeThrows]
		private static void SetProcessInputsInternal(PlayableHandle handle, bool value)
		{
			SetProcessInputsInternal_Injected(ref handle, value);
		}

		[NativeThrows]
		private static bool GetProcessInputsInternal(PlayableHandle handle)
		{
			return GetProcessInputsInternal_Injected(ref handle);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, ref PlayableHandle handle, IntPtr jobReflectionData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetProcessInputsInternal_Injected([In] ref PlayableHandle handle, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetProcessInputsInternal_Injected([In] ref PlayableHandle handle);
	}
	internal enum AnimatorBindingsVersion
	{
		kInvalidNotNative,
		kInvalidUnresolved,
		kValidMinVersion
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationStream.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationStream.h")]
	[RequiredByNativeCode]
	public struct AnimationStream
	{
		private uint m_AnimatorBindingsVersion;

		private IntPtr constant;

		private IntPtr input;

		private IntPtr output;

		private IntPtr workspace;

		private IntPtr inputStreamAccessor;

		private IntPtr animationHandleBinder;

		internal const int InvalidIndex = -1;

		internal uint animatorBindingsVersion => m_AnimatorBindingsVersion;

		public bool isValid => m_AnimatorBindingsVersion >= 2 && constant != IntPtr.Zero && input != IntPtr.Zero && output != IntPtr.Zero && workspace != IntPtr.Zero && animationHandleBinder != IntPtr.Zero;

		public float deltaTime
		{
			get
			{
				CheckIsValid();
				return GetDeltaTime();
			}
		}

		public Vector3 velocity
		{
			get
			{
				CheckIsValid();
				return GetVelocity();
			}
			set
			{
				CheckIsValid();
				SetVelocity(value);
			}
		}

		public Vector3 angularVelocity
		{
			get
			{
				CheckIsValid();
				return GetAngularVelocity();
			}
			set
			{
				CheckIsValid();
				SetAngularVelocity(value);
			}
		}

		public Vector3 rootMotionPosition
		{
			get
			{
				CheckIsValid();
				return GetRootMotionPosition();
			}
		}

		public Quaternion rootMotionRotation
		{
			get
			{
				CheckIsValid();
				return GetRootMotionRotation();
			}
		}

		public bool isHumanStream
		{
			get
			{
				CheckIsValid();
				return GetIsHumanStream();
			}
		}

		public int inputStreamCount
		{
			get
			{
				CheckIsValid();
				return GetInputStreamCount();
			}
		}

		internal void CheckIsValid()
		{
			if (!isValid)
			{
				throw new InvalidOperationException("The AnimationStream is invalid.");
			}
		}

		public AnimationHumanStream AsHuman()
		{
			CheckIsValid();
			if (!GetIsHumanStream())
			{
				throw new InvalidOperationException("Cannot create an AnimationHumanStream for a generic rig.");
			}
			return GetHumanStream();
		}

		public AnimationStream GetInputStream(int index)
		{
			CheckIsValid();
			return InternalGetInputStream(index);
		}

		public float GetInputWeight(int index)
		{
			CheckIsValid();
			return InternalGetInputWeight(index);
		}

		public void CopyAnimationStreamMotion(AnimationStream animationStream)
		{
			CheckIsValid();
			animationStream.CheckIsValid();
			CopyAnimationStreamMotionInternal(animationStream);
		}

		private void ReadSceneTransforms()
		{
			CheckIsValid();
			InternalReadSceneTransforms();
		}

		private void WriteSceneTransforms()
		{
			CheckIsValid();
			InternalWriteSceneTransforms();
		}

		[NativeMethod(Name = "AnimationStreamBindings::CopyAnimationStreamMotion", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void CopyAnimationStreamMotionInternal(AnimationStream animationStream)
		{
			CopyAnimationStreamMotionInternal_Injected(ref this, ref animationStream);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private extern float GetDeltaTime();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private extern bool GetIsHumanStream();

		[NativeMethod(Name = "AnimationStreamBindings::GetVelocity", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetVelocity()
		{
			GetVelocity_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationStreamBindings::SetVelocity", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void SetVelocity(Vector3 velocity)
		{
			SetVelocity_Injected(ref this, ref velocity);
		}

		[NativeMethod(Name = "AnimationStreamBindings::GetAngularVelocity", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetAngularVelocity()
		{
			GetAngularVelocity_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationStreamBindings::SetAngularVelocity", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private void SetAngularVelocity(Vector3 velocity)
		{
			SetAngularVelocity_Injected(ref this, ref velocity);
		}

		[NativeMethod(Name = "AnimationStreamBindings::GetRootMotionPosition", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetRootMotionPosition()
		{
			GetRootMotionPosition_Injected(ref this, out var ret);
			return ret;
		}

		[NativeMethod(Name = "AnimationStreamBindings::GetRootMotionRotation", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion GetRootMotionRotation()
		{
			GetRootMotionRotation_Injected(ref this, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = true)]
		private extern int GetInputStreamCount();

		[NativeMethod(Name = "GetInputStream", IsThreadSafe = true)]
		private AnimationStream InternalGetInputStream(int index)
		{
			InternalGetInputStream_Injected(ref this, index, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetInputWeight", IsThreadSafe = true)]
		private extern float InternalGetInputWeight(int index);

		[NativeMethod(IsThreadSafe = true)]
		private AnimationHumanStream GetHumanStream()
		{
			GetHumanStream_Injected(ref this, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "ReadSceneTransforms", IsThreadSafe = true)]
		private extern void InternalReadSceneTransforms();

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "WriteSceneTransforms", IsThreadSafe = true)]
		private extern void InternalWriteSceneTransforms();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CopyAnimationStreamMotionInternal_Injected(ref AnimationStream _unity_self, [In] ref AnimationStream animationStream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetVelocity_Injected(ref AnimationStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVelocity_Injected(ref AnimationStream _unity_self, [In] ref Vector3 velocity);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAngularVelocity_Injected(ref AnimationStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAngularVelocity_Injected(ref AnimationStream _unity_self, [In] ref Vector3 velocity);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRootMotionPosition_Injected(ref AnimationStream _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRootMotionRotation_Injected(ref AnimationStream _unity_self, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalGetInputStream_Injected(ref AnimationStream _unity_self, int index, out AnimationStream ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetHumanStream_Injected(ref AnimationStream _unity_self, out AnimationHumanStream ret);
	}
	internal enum BindType
	{
		Unbound = 0,
		Float = 5,
		Bool = 6,
		GameObjectActive = 7,
		ObjectReference = 9,
		Int = 10,
		DiscreetInt = 11
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationStreamHandles.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationStreamHandles.h")]
	public struct TransformStreamHandle
	{
		private uint m_AnimatorBindingsVersion;

		private int handleIndex;

		private int skeletonIndex;

		private bool createdByNative => animatorBindingsVersion != 0;

		private bool hasHandleIndex => handleIndex != -1;

		private bool hasSkeletonIndex => skeletonIndex != -1;

		internal uint animatorBindingsVersion
		{
			get
			{
				return m_AnimatorBindingsVersion;
			}
			private set
			{
				m_AnimatorBindingsVersion = value;
			}
		}

		public bool IsValid(AnimationStream stream)
		{
			return IsValidInternal(ref stream);
		}

		private bool IsValidInternal(ref AnimationStream stream)
		{
			return stream.isValid && createdByNative && hasHandleIndex;
		}

		private bool IsSameVersionAsStream(ref AnimationStream stream)
		{
			return animatorBindingsVersion == stream.animatorBindingsVersion;
		}

		public void Resolve(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
		}

		public bool IsResolved(AnimationStream stream)
		{
			return IsResolvedInternal(ref stream);
		}

		private bool IsResolvedInternal(ref AnimationStream stream)
		{
			return IsValidInternal(ref stream) && IsSameVersionAsStream(ref stream) && hasSkeletonIndex;
		}

		private void CheckIsValidAndResolve(ref AnimationStream stream)
		{
			stream.CheckIsValid();
			if (!IsResolvedInternal(ref stream))
			{
				if (!createdByNative || !hasHandleIndex)
				{
					throw new InvalidOperationException("The TransformStreamHandle is invalid. Please use proper function to create the handle.");
				}
				if (!IsSameVersionAsStream(ref stream) || (hasHandleIndex && !hasSkeletonIndex))
				{
					ResolveInternal(ref stream);
				}
				if (hasHandleIndex && !hasSkeletonIndex)
				{
					throw new InvalidOperationException("The TransformStreamHandle cannot be resolved.");
				}
			}
		}

		public Vector3 GetPosition(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetPositionInternal(ref stream);
		}

		public void SetPosition(AnimationStream stream, Vector3 position)
		{
			CheckIsValidAndResolve(ref stream);
			SetPositionInternal(ref stream, position);
		}

		public Quaternion GetRotation(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetRotationInternal(ref stream);
		}

		public void SetRotation(AnimationStream stream, Quaternion rotation)
		{
			CheckIsValidAndResolve(ref stream);
			SetRotationInternal(ref stream, rotation);
		}

		public Vector3 GetLocalPosition(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetLocalPositionInternal(ref stream);
		}

		public void SetLocalPosition(AnimationStream stream, Vector3 position)
		{
			CheckIsValidAndResolve(ref stream);
			SetLocalPositionInternal(ref stream, position);
		}

		public Quaternion GetLocalRotation(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetLocalRotationInternal(ref stream);
		}

		public void SetLocalRotation(AnimationStream stream, Quaternion rotation)
		{
			CheckIsValidAndResolve(ref stream);
			SetLocalRotationInternal(ref stream, rotation);
		}

		public Vector3 GetLocalScale(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetLocalScaleInternal(ref stream);
		}

		public void SetLocalScale(AnimationStream stream, Vector3 scale)
		{
			CheckIsValidAndResolve(ref stream);
			SetLocalScaleInternal(ref stream, scale);
		}

		public Matrix4x4 GetLocalToParentMatrix(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetLocalToParentMatrixInternal(ref stream);
		}

		public bool GetPositionReadMask(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetPositionReadMaskInternal(ref stream);
		}

		public bool GetRotationReadMask(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetRotationReadMaskInternal(ref stream);
		}

		public bool GetScaleReadMask(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetScaleReadMaskInternal(ref stream);
		}

		public void GetLocalTRS(AnimationStream stream, out Vector3 position, out Quaternion rotation, out Vector3 scale)
		{
			CheckIsValidAndResolve(ref stream);
			GetLocalTRSInternal(ref stream, out position, out rotation, out scale);
		}

		public void SetLocalTRS(AnimationStream stream, Vector3 position, Quaternion rotation, Vector3 scale, bool useMask)
		{
			CheckIsValidAndResolve(ref stream);
			SetLocalTRSInternal(ref stream, position, rotation, scale, useMask);
		}

		public void GetGlobalTR(AnimationStream stream, out Vector3 position, out Quaternion rotation)
		{
			CheckIsValidAndResolve(ref stream);
			GetGlobalTRInternal(ref stream, out position, out rotation);
		}

		public Matrix4x4 GetLocalToWorldMatrix(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetLocalToWorldMatrixInternal(ref stream);
		}

		public void SetGlobalTR(AnimationStream stream, Vector3 position, Quaternion rotation, bool useMask)
		{
			CheckIsValidAndResolve(ref stream);
			SetGlobalTRInternal(ref stream, position, rotation, useMask);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "Resolve", IsThreadSafe = true)]
		private extern void ResolveInternal(ref AnimationStream stream);

		[NativeMethod(Name = "TransformStreamHandleBindings::GetPositionInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Vector3 GetPositionInternal(ref AnimationStream stream)
		{
			GetPositionInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::SetPositionInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetPositionInternal(ref AnimationStream stream, Vector3 position)
		{
			SetPositionInternal_Injected(ref this, ref stream, ref position);
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::GetRotationInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Quaternion GetRotationInternal(ref AnimationStream stream)
		{
			GetRotationInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::SetRotationInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetRotationInternal(ref AnimationStream stream, Quaternion rotation)
		{
			SetRotationInternal_Injected(ref this, ref stream, ref rotation);
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::GetLocalPositionInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Vector3 GetLocalPositionInternal(ref AnimationStream stream)
		{
			GetLocalPositionInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::SetLocalPositionInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetLocalPositionInternal(ref AnimationStream stream, Vector3 position)
		{
			SetLocalPositionInternal_Injected(ref this, ref stream, ref position);
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::GetLocalRotationInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Quaternion GetLocalRotationInternal(ref AnimationStream stream)
		{
			GetLocalRotationInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::SetLocalRotationInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetLocalRotationInternal(ref AnimationStream stream, Quaternion rotation)
		{
			SetLocalRotationInternal_Injected(ref this, ref stream, ref rotation);
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::GetLocalScaleInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Vector3 GetLocalScaleInternal(ref AnimationStream stream)
		{
			GetLocalScaleInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::SetLocalScaleInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetLocalScaleInternal(ref AnimationStream stream, Vector3 scale)
		{
			SetLocalScaleInternal_Injected(ref this, ref stream, ref scale);
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::GetLocalToParentMatrixInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Matrix4x4 GetLocalToParentMatrixInternal(ref AnimationStream stream)
		{
			GetLocalToParentMatrixInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformStreamHandleBindings::GetPositionReadMaskInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private extern bool GetPositionReadMaskInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformStreamHandleBindings::GetRotationReadMaskInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private extern bool GetRotationReadMaskInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformStreamHandleBindings::GetScaleReadMaskInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private extern bool GetScaleReadMaskInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformStreamHandleBindings::GetLocalTRSInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private extern void GetLocalTRSInternal(ref AnimationStream stream, out Vector3 position, out Quaternion rotation, out Vector3 scale);

		[NativeMethod(Name = "TransformStreamHandleBindings::SetLocalTRSInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetLocalTRSInternal(ref AnimationStream stream, Vector3 position, Quaternion rotation, Vector3 scale, bool useMask)
		{
			SetLocalTRSInternal_Injected(ref this, ref stream, ref position, ref rotation, ref scale, useMask);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformStreamHandleBindings::GetGlobalTRInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private extern void GetGlobalTRInternal(ref AnimationStream stream, out Vector3 position, out Quaternion rotation);

		[NativeMethod(Name = "TransformStreamHandleBindings::GetLocalToWorldMatrixInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Matrix4x4 GetLocalToWorldMatrixInternal(ref AnimationStream stream)
		{
			GetLocalToWorldMatrixInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformStreamHandleBindings::SetGlobalTRInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private void SetGlobalTRInternal(ref AnimationStream stream, Vector3 position, Quaternion rotation, bool useMask)
		{
			SetGlobalTRInternal_Injected(ref this, ref stream, ref position, ref rotation, useMask);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPositionInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetPositionInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Vector3 position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRotationInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetRotationInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalPositionInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalPositionInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Vector3 position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalRotationInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalRotationInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Quaternion rotation);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalScaleInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalScaleInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Vector3 scale);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalToParentMatrixInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLocalTRSInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Vector3 position, [In] ref Quaternion rotation, [In] ref Vector3 scale, bool useMask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalToWorldMatrixInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetGlobalTRInternal_Injected(ref TransformStreamHandle _unity_self, ref AnimationStream stream, [In] ref Vector3 position, [In] ref Quaternion rotation, bool useMask);
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/Director/AnimationStreamHandles.h")]
	public struct PropertyStreamHandle
	{
		private uint m_AnimatorBindingsVersion;

		private int handleIndex;

		private int valueArrayIndex;

		private int bindType;

		private bool createdByNative => animatorBindingsVersion != 0;

		private bool hasHandleIndex => handleIndex != -1;

		private bool hasValueArrayIndex => valueArrayIndex != -1;

		private bool hasBindType => bindType != 0;

		internal uint animatorBindingsVersion
		{
			get
			{
				return m_AnimatorBindingsVersion;
			}
			private set
			{
				m_AnimatorBindingsVersion = value;
			}
		}

		public bool IsValid(AnimationStream stream)
		{
			return IsValidInternal(ref stream);
		}

		private bool IsValidInternal(ref AnimationStream stream)
		{
			return stream.isValid && createdByNative && hasHandleIndex && hasBindType;
		}

		private bool IsSameVersionAsStream(ref AnimationStream stream)
		{
			return animatorBindingsVersion == stream.animatorBindingsVersion;
		}

		public void Resolve(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
		}

		public bool IsResolved(AnimationStream stream)
		{
			return IsResolvedInternal(ref stream);
		}

		private bool IsResolvedInternal(ref AnimationStream stream)
		{
			return IsValidInternal(ref stream) && IsSameVersionAsStream(ref stream) && hasValueArrayIndex;
		}

		private void CheckIsValidAndResolve(ref AnimationStream stream)
		{
			stream.CheckIsValid();
			if (!IsResolvedInternal(ref stream))
			{
				if (!createdByNative || !hasHandleIndex || !hasBindType)
				{
					throw new InvalidOperationException("The PropertyStreamHandle is invalid. Please use proper function to create the handle.");
				}
				if (!IsSameVersionAsStream(ref stream) || (hasHandleIndex && !hasValueArrayIndex))
				{
					ResolveInternal(ref stream);
				}
				if (hasHandleIndex && !hasValueArrayIndex)
				{
					throw new InvalidOperationException("The PropertyStreamHandle cannot be resolved.");
				}
			}
		}

		public float GetFloat(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType != 5)
			{
				throw new InvalidOperationException("GetValue type doesn't match PropertyStreamHandle bound type.");
			}
			return GetFloatInternal(ref stream);
		}

		public void SetFloat(AnimationStream stream, float value)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType != 5)
			{
				throw new InvalidOperationException("SetValue type doesn't match PropertyStreamHandle bound type.");
			}
			SetFloatInternal(ref stream, value);
		}

		public int GetInt(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType == 9)
			{
				Debug.LogWarning("Please Use GetEntityId directly to get the value of an ObjectReference PropertyStreamHandle.");
				return GetEntityId(stream);
			}
			if (bindType != 10 && bindType != 11)
			{
				throw new InvalidOperationException("GetValue type doesn't match PropertyStreamHandle bound type.");
			}
			return GetIntInternal(ref stream);
		}

		public void SetInt(AnimationStream stream, int value)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType == 9)
			{
				Debug.LogWarning("Please Use SetEntityId directly to set the value of an ObjectReference PropertyStreamHandle.");
				SetEntityId(stream, value);
				return;
			}
			if (bindType != 10 && bindType != 11)
			{
				throw new InvalidOperationException("SetValue type doesn't match PropertyStreamHandle bound type.");
			}
			SetIntInternal(ref stream, value);
		}

		public EntityId GetEntityId(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType != 9)
			{
				throw new InvalidOperationException("GetValue type doesn't match PropertyStreamHandle bound type.");
			}
			return GetEntityIdInternal(ref stream);
		}

		public void SetEntityId(AnimationStream stream, EntityId value)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType != 9)
			{
				throw new InvalidOperationException("SetValue type doesn't match PropertyStreamHandle bound type.");
			}
			SetEntityIdInternal(ref stream, value);
		}

		public bool GetBool(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType != 6 && bindType != 7)
			{
				throw new InvalidOperationException("GetValue type doesn't match PropertyStreamHandle bound type.");
			}
			return GetBoolInternal(ref stream);
		}

		public void SetBool(AnimationStream stream, bool value)
		{
			CheckIsValidAndResolve(ref stream);
			if (bindType != 6 && bindType != 7)
			{
				throw new InvalidOperationException("SetValue type doesn't match PropertyStreamHandle bound type.");
			}
			SetBoolInternal(ref stream, value);
		}

		public bool GetReadMask(AnimationStream stream)
		{
			CheckIsValidAndResolve(ref stream);
			return GetReadMaskInternal(ref stream);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "Resolve", IsThreadSafe = true)]
		private extern void ResolveInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetFloat", IsThreadSafe = true)]
		private extern float GetFloatInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetFloat", IsThreadSafe = true)]
		private extern void SetFloatInternal(ref AnimationStream stream, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetInt", IsThreadSafe = true)]
		private extern int GetIntInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetInt", IsThreadSafe = true)]
		private extern void SetIntInternal(ref AnimationStream stream, int value);

		[NativeMethod(Name = "GetEntityId", IsThreadSafe = true)]
		private EntityId GetEntityIdInternal(ref AnimationStream stream)
		{
			GetEntityIdInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "SetEntityId", IsThreadSafe = true)]
		private void SetEntityIdInternal(ref AnimationStream stream, EntityId value)
		{
			SetEntityIdInternal_Injected(ref this, ref stream, ref value);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetBool", IsThreadSafe = true)]
		private extern bool GetBoolInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "SetBool", IsThreadSafe = true)]
		private extern void SetBoolInternal(ref AnimationStream stream, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetReadMask", IsThreadSafe = true)]
		private extern bool GetReadMaskInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetEntityIdInternal_Injected(ref PropertyStreamHandle _unity_self, ref AnimationStream stream, out EntityId ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetEntityIdInternal_Injected(ref PropertyStreamHandle _unity_self, ref AnimationStream stream, [In] ref EntityId value);
	}
	[NativeHeader("Modules/Animation/Director/AnimationSceneHandles.h")]
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationStreamHandles.bindings.h")]
	public struct TransformSceneHandle
	{
		private uint valid;

		private int transformSceneHandleDefinitionIndex;

		private bool createdByNative => valid != 0;

		private bool hasTransformSceneHandleDefinitionIndex => transformSceneHandleDefinitionIndex != -1;

		public bool IsValid(AnimationStream stream)
		{
			return stream.isValid && createdByNative && hasTransformSceneHandleDefinitionIndex && HasValidTransform(ref stream);
		}

		private void CheckIsValid(ref AnimationStream stream)
		{
			stream.CheckIsValid();
			if (!createdByNative || !hasTransformSceneHandleDefinitionIndex)
			{
				throw new InvalidOperationException("The TransformSceneHandle is invalid. Please use proper function to create the handle.");
			}
			if (!HasValidTransform(ref stream))
			{
				throw new NullReferenceException("The transform is invalid.");
			}
		}

		public Vector3 GetPosition(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetPositionInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetPosition(AnimationStream stream, Vector3 position)
		{
		}

		public Vector3 GetLocalPosition(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetLocalPositionInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetLocalPosition(AnimationStream stream, Vector3 position)
		{
		}

		public Quaternion GetRotation(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetRotationInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetRotation(AnimationStream stream, Quaternion rotation)
		{
		}

		public Quaternion GetLocalRotation(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetLocalRotationInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetLocalRotation(AnimationStream stream, Quaternion rotation)
		{
		}

		public Vector3 GetLocalScale(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetLocalScaleInternal(ref stream);
		}

		public void GetLocalTRS(AnimationStream stream, out Vector3 position, out Quaternion rotation, out Vector3 scale)
		{
			CheckIsValid(ref stream);
			GetLocalTRSInternal(ref stream, out position, out rotation, out scale);
		}

		public Matrix4x4 GetLocalToParentMatrix(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetLocalToParentMatrixInternal(ref stream);
		}

		public void GetGlobalTR(AnimationStream stream, out Vector3 position, out Quaternion rotation)
		{
			CheckIsValid(ref stream);
			GetGlobalTRInternal(ref stream, out position, out rotation);
		}

		public Matrix4x4 GetLocalToWorldMatrix(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetLocalToWorldMatrixInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetLocalScale(AnimationStream stream, Vector3 scale)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private extern bool HasValidTransform(ref AnimationStream stream);

		[NativeMethod(Name = "TransformSceneHandleBindings::GetPositionInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetPositionInternal(ref AnimationStream stream)
		{
			GetPositionInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformSceneHandleBindings::GetLocalPositionInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetLocalPositionInternal(ref AnimationStream stream)
		{
			GetLocalPositionInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformSceneHandleBindings::GetRotationInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion GetRotationInternal(ref AnimationStream stream)
		{
			GetRotationInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformSceneHandleBindings::GetLocalRotationInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Quaternion GetLocalRotationInternal(ref AnimationStream stream)
		{
			GetLocalRotationInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TransformSceneHandleBindings::GetLocalScaleInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private Vector3 GetLocalScaleInternal(ref AnimationStream stream)
		{
			GetLocalScaleInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformSceneHandleBindings::GetLocalTRSInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private extern void GetLocalTRSInternal(ref AnimationStream stream, out Vector3 position, out Quaternion rotation, out Vector3 scale);

		[NativeMethod(Name = "TransformSceneHandleBindings::GetLocalToParentMatrixInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Matrix4x4 GetLocalToParentMatrixInternal(ref AnimationStream stream)
		{
			GetLocalToParentMatrixInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TransformSceneHandleBindings::GetGlobalTRInternal", IsFreeFunction = true, IsThreadSafe = true, HasExplicitThis = true)]
		private extern void GetGlobalTRInternal(ref AnimationStream stream, out Vector3 position, out Quaternion rotation);

		[NativeMethod(Name = "TransformSceneHandleBindings::GetLocalToWorldMatrixInternal", IsFreeFunction = true, HasExplicitThis = true, IsThreadSafe = true)]
		private Matrix4x4 GetLocalToWorldMatrixInternal(ref AnimationStream stream)
		{
			GetLocalToWorldMatrixInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetPositionInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalPositionInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRotationInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalRotationInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Quaternion ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalScaleInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalToParentMatrixInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLocalToWorldMatrixInternal_Injected(ref TransformSceneHandle _unity_self, ref AnimationStream stream, out Matrix4x4 ret);
	}
	[NativeHeader("Modules/Animation/Director/AnimationSceneHandles.h")]
	[MovedFrom("UnityEngine.Experimental.Animations")]
	public struct PropertySceneHandle
	{
		private uint valid;

		private int handleIndex;

		private bool createdByNative => valid != 0;

		private bool hasHandleIndex => handleIndex != -1;

		public bool IsValid(AnimationStream stream)
		{
			return IsValidInternal(ref stream);
		}

		private bool IsValidInternal(ref AnimationStream stream)
		{
			return stream.isValid && createdByNative && hasHandleIndex && HasValidTransform(ref stream);
		}

		public void Resolve(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			ResolveInternal(ref stream);
		}

		public bool IsResolved(AnimationStream stream)
		{
			return IsValidInternal(ref stream) && IsBound(ref stream);
		}

		private void CheckIsValid(ref AnimationStream stream)
		{
			stream.CheckIsValid();
			if (!createdByNative || !hasHandleIndex)
			{
				throw new InvalidOperationException("The PropertySceneHandle is invalid. Please use proper function to create the handle.");
			}
			if (!HasValidTransform(ref stream))
			{
				throw new NullReferenceException("The transform is invalid.");
			}
		}

		public float GetFloat(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetFloatInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetFloat(AnimationStream stream, float value)
		{
		}

		public int GetInt(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetIntInternal(ref stream);
		}

		public EntityId GetEntityId(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetEntityIdInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetInt(AnimationStream stream, int value)
		{
		}

		public bool GetBool(AnimationStream stream)
		{
			CheckIsValid(ref stream);
			return GetBoolInternal(ref stream);
		}

		[Obsolete("SceneHandle is now read-only; it was problematic with the engine multithreading and determinism", true)]
		public void SetBool(AnimationStream stream, bool value)
		{
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private extern bool HasValidTransform(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		private extern bool IsBound(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "Resolve", IsThreadSafe = true)]
		private extern void ResolveInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetFloat", IsThreadSafe = true)]
		private extern float GetFloatInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetInt", IsThreadSafe = true)]
		private extern int GetIntInternal(ref AnimationStream stream);

		[NativeMethod(Name = "GetEntityId", IsThreadSafe = true)]
		private EntityId GetEntityIdInternal(ref AnimationStream stream)
		{
			GetEntityIdInternal_Injected(ref this, ref stream, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "GetBool", IsThreadSafe = true)]
		private extern bool GetBoolInternal(ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetEntityIdInternal_Injected(ref PropertySceneHandle _unity_self, ref AnimationStream stream, out EntityId ret);
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationStreamHandles.bindings.h")]
	public static class AnimationSceneHandleUtility
	{
		public unsafe static void ReadInts(AnimationStream stream, NativeArray<PropertySceneHandle> handles, NativeArray<int> buffer)
		{
			int num = ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				ReadSceneIntsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num);
			}
		}

		public unsafe static void ReadFloats(AnimationStream stream, NativeArray<PropertySceneHandle> handles, NativeArray<float> buffer)
		{
			int num = ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				ReadSceneFloatsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num);
			}
		}

		public unsafe static void ReadEntityIds(AnimationStream stream, NativeArray<PropertySceneHandle> handles, NativeArray<EntityId> buffer)
		{
			int num = ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				ReadSceneEntityIdsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num);
			}
		}

		internal static int ValidateAndGetArrayCount<T0, T1>(ref AnimationStream stream, NativeArray<T0> handles, NativeArray<T1> buffer) where T0 : struct where T1 : struct
		{
			stream.CheckIsValid();
			if (!handles.IsCreated)
			{
				throw new NullReferenceException("Handle array is invalid.");
			}
			if (!buffer.IsCreated)
			{
				throw new NullReferenceException("Data buffer is invalid.");
			}
			if (buffer.Length < handles.Length)
			{
				throw new InvalidOperationException("Data buffer array is smaller than handles array.");
			}
			return handles.Length;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::ReadSceneIntsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void ReadSceneIntsInternal(ref AnimationStream stream, void* propertySceneHandles, void* intBuffer, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::ReadSceneFloatsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void ReadSceneFloatsInternal(ref AnimationStream stream, void* propertySceneHandles, void* floatBuffer, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::ReadSceneEntityIdsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void ReadSceneEntityIdsInternal(ref AnimationStream stream, void* propertySceneHandles, void* instanceIDBuffer, int count);
	}
	[NativeHeader("Modules/Animation/ScriptBindings/AnimationStreamHandles.bindings.h")]
	[MovedFrom("UnityEngine.Experimental.Animations")]
	public static class AnimationStreamHandleUtility
	{
		public unsafe static void WriteInts(AnimationStream stream, NativeArray<PropertyStreamHandle> handles, NativeArray<int> buffer, bool useMask)
		{
			stream.CheckIsValid();
			int num = AnimationSceneHandleUtility.ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				WriteStreamIntsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num, useMask);
			}
		}

		public unsafe static void WriteFloats(AnimationStream stream, NativeArray<PropertyStreamHandle> handles, NativeArray<float> buffer, bool useMask)
		{
			stream.CheckIsValid();
			int num = AnimationSceneHandleUtility.ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				WriteStreamFloatsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num, useMask);
			}
		}

		public unsafe static void WriteEntityIds(AnimationStream stream, NativeArray<PropertyStreamHandle> handles, NativeArray<EntityId> buffer, bool useMask)
		{
			stream.CheckIsValid();
			int num = AnimationSceneHandleUtility.ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				WriteStreamEntityIdsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num, useMask);
			}
		}

		public unsafe static void ReadInts(AnimationStream stream, NativeArray<PropertyStreamHandle> handles, NativeArray<int> buffer)
		{
			stream.CheckIsValid();
			int num = AnimationSceneHandleUtility.ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				ReadStreamIntsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num);
			}
		}

		public unsafe static void ReadFloats(AnimationStream stream, NativeArray<PropertyStreamHandle> handles, NativeArray<float> buffer)
		{
			stream.CheckIsValid();
			int num = AnimationSceneHandleUtility.ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				ReadStreamFloatsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num);
			}
		}

		public unsafe static void ReadEntityIds(AnimationStream stream, NativeArray<PropertyStreamHandle> handles, NativeArray<EntityId> buffer)
		{
			stream.CheckIsValid();
			int num = AnimationSceneHandleUtility.ValidateAndGetArrayCount(ref stream, handles, buffer);
			if (num != 0)
			{
				ReadStreamEntityIdsInternal(ref stream, handles.GetUnsafePtr(), buffer.GetUnsafePtr(), num);
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::ReadStreamIntsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void ReadStreamIntsInternal(ref AnimationStream stream, void* propertyStreamHandles, void* intBuffer, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::ReadStreamFloatsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void ReadStreamFloatsInternal(ref AnimationStream stream, void* propertyStreamHandles, void* floatBuffer, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::ReadStreamEntityIdsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void ReadStreamEntityIdsInternal(ref AnimationStream stream, void* propertyStreamHandles, void* instanceIDBuffer, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::WriteStreamIntsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void WriteStreamIntsInternal(ref AnimationStream stream, void* propertyStreamHandles, void* intBuffer, int count, bool useMask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::WriteStreamFloatsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void WriteStreamFloatsInternal(ref AnimationStream stream, void* propertyStreamHandles, void* floatBuffer, int count, bool useMask);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "AnimationHandleUtilityBindings::WriteStreamEntityIdsInternal", IsFreeFunction = true, HasExplicitThis = false, IsThreadSafe = true)]
		private unsafe static extern void WriteStreamEntityIdsInternal(ref AnimationStream stream, void* propertyStreamHandles, void* instanceIDBuffer, int count, bool useMask);
	}
	[StaticAccessor("AnimatorControllerPlayableBindings", StaticAccessorType.DoubleColon)]
	[RequiredByNativeCode]
	[NativeHeader("Modules/Animation/Director/AnimatorControllerPlayable.h")]
	[NativeHeader("Modules/Animation/RuntimeAnimatorController.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/Animator.bindings.h")]
	[NativeHeader("Modules/Animation/AnimatorInfo.h")]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimatorControllerPlayable.bindings.h")]
	public struct AnimatorControllerPlayable : IPlayable, IEquatable<AnimatorControllerPlayable>
	{
		private PlayableHandle m_Handle = PlayableHandle.Null;

		private static readonly AnimatorControllerPlayable m_NullPlayable = new AnimatorControllerPlayable(PlayableHandle.Null);

		public static AnimatorControllerPlayable Null => m_NullPlayable;

		public static AnimatorControllerPlayable Create(PlayableGraph graph, RuntimeAnimatorController controller)
		{
			PlayableHandle handle = CreateHandle(graph, controller);
			return new AnimatorControllerPlayable(handle);
		}

		private static PlayableHandle CreateHandle(PlayableGraph graph, RuntimeAnimatorController controller)
		{
			PlayableHandle handle = PlayableHandle.Null;
			if (!CreateHandleInternal(graph, controller, ref handle))
			{
				return PlayableHandle.Null;
			}
			return handle;
		}

		internal AnimatorControllerPlayable(PlayableHandle handle)
		{
			SetHandle(handle);
		}

		public PlayableHandle GetHandle()
		{
			return m_Handle;
		}

		public void SetHandle(PlayableHandle handle)
		{
			if (m_Handle.IsValid())
			{
				throw new InvalidOperationException("Cannot call IPlayable.SetHandle on an instance that already contains a valid handle.");
			}
			if (handle.IsValid() && !handle.IsPlayableOfType<AnimatorControllerPlayable>())
			{
				throw new InvalidCastException("Can't set handle: the playable is not an AnimatorControllerPlayable.");
			}
			m_Handle = handle;
		}

		public static implicit operator Playable(AnimatorControllerPlayable playable)
		{
			return new Playable(playable.GetHandle());
		}

		public static explicit operator AnimatorControllerPlayable(Playable playable)
		{
			return new AnimatorControllerPlayable(playable.GetHandle());
		}

		public bool Equals(AnimatorControllerPlayable other)
		{
			return GetHandle() == other.GetHandle();
		}

		public float GetFloat(string name)
		{
			return GetFloatString(ref m_Handle, name);
		}

		public float GetFloat(int id)
		{
			return GetFloatID(ref m_Handle, id);
		}

		public void SetFloat(string name, float value)
		{
			SetFloatString(ref m_Handle, name, value);
		}

		public void SetFloat(int id, float value)
		{
			SetFloatID(ref m_Handle, id, value);
		}

		public bool GetBool(string name)
		{
			return GetBoolString(ref m_Handle, name);
		}

		public bool GetBool(int id)
		{
			return GetBoolID(ref m_Handle, id);
		}

		public void SetBool(string name, bool value)
		{
			SetBoolString(ref m_Handle, name, value);
		}

		public void SetBool(int id, bool value)
		{
			SetBoolID(ref m_Handle, id, value);
		}

		public int GetInteger(string name)
		{
			return GetIntegerString(ref m_Handle, name);
		}

		public int GetInteger(int id)
		{
			return GetIntegerID(ref m_Handle, id);
		}

		public void SetInteger(string name, int value)
		{
			SetIntegerString(ref m_Handle, name, value);
		}

		public void SetInteger(int id, int value)
		{
			SetIntegerID(ref m_Handle, id, value);
		}

		public void SetTrigger(string name)
		{
			SetTriggerString(ref m_Handle, name);
		}

		public void SetTrigger(int id)
		{
			SetTriggerID(ref m_Handle, id);
		}

		public void ResetTrigger(string name)
		{
			ResetTriggerString(ref m_Handle, name);
		}

		public void ResetTrigger(int id)
		{
			ResetTriggerID(ref m_Handle, id);
		}

		public bool IsParameterControlledByCurve(string name)
		{
			return IsParameterControlledByCurveString(ref m_Handle, name);
		}

		public bool IsParameterControlledByCurve(int id)
		{
			return IsParameterControlledByCurveID(ref m_Handle, id);
		}

		public int GetLayerCount()
		{
			return GetLayerCountInternal(ref m_Handle);
		}

		public string GetLayerName(int layerIndex)
		{
			return GetLayerNameInternal(ref m_Handle, layerIndex);
		}

		public int GetLayerIndex(string layerName)
		{
			return GetLayerIndexInternal(ref m_Handle, layerName);
		}

		public float GetLayerWeight(int layerIndex)
		{
			return GetLayerWeightInternal(ref m_Handle, layerIndex);
		}

		public void SetLayerWeight(int layerIndex, float weight)
		{
			SetLayerWeightInternal(ref m_Handle, layerIndex, weight);
		}

		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex)
		{
			return GetCurrentAnimatorStateInfoInternal(ref m_Handle, layerIndex);
		}

		public AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex)
		{
			return GetNextAnimatorStateInfoInternal(ref m_Handle, layerIndex);
		}

		public AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex)
		{
			return GetAnimatorTransitionInfoInternal(ref m_Handle, layerIndex);
		}

		public AnimatorClipInfo[] GetCurrentAnimatorClipInfo(int layerIndex)
		{
			return GetCurrentAnimatorClipInfoInternal(ref m_Handle, layerIndex);
		}

		public void GetCurrentAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			if (clips == null)
			{
				throw new ArgumentNullException("clips");
			}
			GetAnimatorClipInfoInternal(ref m_Handle, layerIndex, isCurrent: true, clips);
		}

		public void GetNextAnimatorClipInfo(int layerIndex, List<AnimatorClipInfo> clips)
		{
			if (clips == null)
			{
				throw new ArgumentNullException("clips");
			}
			GetAnimatorClipInfoInternal(ref m_Handle, layerIndex, isCurrent: false, clips);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void GetAnimatorClipInfoInternal(ref PlayableHandle handle, int layerIndex, bool isCurrent, object clips);

		public int GetCurrentAnimatorClipInfoCount(int layerIndex)
		{
			return GetAnimatorClipInfoCountInternal(ref m_Handle, layerIndex, current: true);
		}

		public int GetNextAnimatorClipInfoCount(int layerIndex)
		{
			return GetAnimatorClipInfoCountInternal(ref m_Handle, layerIndex, current: false);
		}

		public AnimatorClipInfo[] GetNextAnimatorClipInfo(int layerIndex)
		{
			return GetNextAnimatorClipInfoInternal(ref m_Handle, layerIndex);
		}

		public bool IsInTransition(int layerIndex)
		{
			return IsInTransitionInternal(ref m_Handle, layerIndex);
		}

		public int GetParameterCount()
		{
			return GetParameterCountInternal(ref m_Handle);
		}

		public AnimatorControllerParameter GetParameter(int index)
		{
			AnimatorControllerParameter parameterInternal = GetParameterInternal(ref m_Handle, index);
			if (parameterInternal.m_Type == (AnimatorControllerParameterType)0)
			{
				throw new IndexOutOfRangeException("Invalid parameter index.");
			}
			return parameterInternal;
		}

		public void CrossFadeInFixedTime(string stateName, float transitionDuration)
		{
			CrossFadeInFixedTimeInternal(ref m_Handle, StringToHash(stateName), transitionDuration, -1, 0f);
		}

		public void CrossFadeInFixedTime(string stateName, float transitionDuration, int layer)
		{
			CrossFadeInFixedTimeInternal(ref m_Handle, StringToHash(stateName), transitionDuration, layer, 0f);
		}

		public void CrossFadeInFixedTime(string stateName, float transitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float fixedTime)
		{
			CrossFadeInFixedTimeInternal(ref m_Handle, StringToHash(stateName), transitionDuration, layer, fixedTime);
		}

		public void CrossFadeInFixedTime(int stateNameHash, float transitionDuration)
		{
			CrossFadeInFixedTimeInternal(ref m_Handle, stateNameHash, transitionDuration, -1, 0f);
		}

		public void CrossFadeInFixedTime(int stateNameHash, float transitionDuration, int layer)
		{
			CrossFadeInFixedTimeInternal(ref m_Handle, stateNameHash, transitionDuration, layer, 0f);
		}

		public void CrossFadeInFixedTime(int stateNameHash, float transitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("0.0f")] float fixedTime)
		{
			CrossFadeInFixedTimeInternal(ref m_Handle, stateNameHash, transitionDuration, layer, fixedTime);
		}

		public void CrossFade(string stateName, float transitionDuration)
		{
			CrossFadeInternal(ref m_Handle, StringToHash(stateName), transitionDuration, -1, float.NegativeInfinity);
		}

		public void CrossFade(string stateName, float transitionDuration, int layer)
		{
			CrossFadeInternal(ref m_Handle, StringToHash(stateName), transitionDuration, layer, float.NegativeInfinity);
		}

		public void CrossFade(string stateName, float transitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime)
		{
			CrossFadeInternal(ref m_Handle, StringToHash(stateName), transitionDuration, layer, normalizedTime);
		}

		public void CrossFade(int stateNameHash, float transitionDuration)
		{
			CrossFadeInternal(ref m_Handle, stateNameHash, transitionDuration, -1, float.NegativeInfinity);
		}

		public void CrossFade(int stateNameHash, float transitionDuration, int layer)
		{
			CrossFadeInternal(ref m_Handle, stateNameHash, transitionDuration, layer, float.NegativeInfinity);
		}

		public void CrossFade(int stateNameHash, float transitionDuration, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime)
		{
			CrossFadeInternal(ref m_Handle, stateNameHash, transitionDuration, layer, normalizedTime);
		}

		public void PlayInFixedTime(string stateName)
		{
			PlayInFixedTimeInternal(ref m_Handle, StringToHash(stateName), -1, float.NegativeInfinity);
		}

		public void PlayInFixedTime(string stateName, int layer)
		{
			PlayInFixedTimeInternal(ref m_Handle, StringToHash(stateName), layer, float.NegativeInfinity);
		}

		public void PlayInFixedTime(string stateName, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float fixedTime)
		{
			PlayInFixedTimeInternal(ref m_Handle, StringToHash(stateName), layer, fixedTime);
		}

		public void PlayInFixedTime(int stateNameHash)
		{
			PlayInFixedTimeInternal(ref m_Handle, stateNameHash, -1, float.NegativeInfinity);
		}

		public void PlayInFixedTime(int stateNameHash, int layer)
		{
			PlayInFixedTimeInternal(ref m_Handle, stateNameHash, layer, float.NegativeInfinity);
		}

		public void PlayInFixedTime(int stateNameHash, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float fixedTime)
		{
			PlayInFixedTimeInternal(ref m_Handle, stateNameHash, layer, fixedTime);
		}

		public void Play(string stateName)
		{
			PlayInternal(ref m_Handle, StringToHash(stateName), -1, float.NegativeInfinity);
		}

		public void Play(string stateName, int layer)
		{
			PlayInternal(ref m_Handle, StringToHash(stateName), layer, float.NegativeInfinity);
		}

		public void Play(string stateName, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime)
		{
			PlayInternal(ref m_Handle, StringToHash(stateName), layer, normalizedTime);
		}

		public void Play(int stateNameHash)
		{
			PlayInternal(ref m_Handle, stateNameHash, -1, float.NegativeInfinity);
		}

		public void Play(int stateNameHash, int layer)
		{
			PlayInternal(ref m_Handle, stateNameHash, layer, float.NegativeInfinity);
		}

		public void Play(int stateNameHash, [UnityEngine.Internal.DefaultValue("-1")] int layer, [UnityEngine.Internal.DefaultValue("float.NegativeInfinity")] float normalizedTime)
		{
			PlayInternal(ref m_Handle, stateNameHash, layer, normalizedTime);
		}

		public bool HasState(int layerIndex, int stateID)
		{
			return HasStateInternal(ref m_Handle, layerIndex, stateID);
		}

		internal string ResolveHash(int hash)
		{
			return ResolveHashInternal(ref m_Handle, hash);
		}

		[NativeThrows]
		private static bool CreateHandleInternal(PlayableGraph graph, RuntimeAnimatorController controller, ref PlayableHandle handle)
		{
			return CreateHandleInternal_Injected(ref graph, Object.MarshalledUnityObject.Marshal(controller), ref handle);
		}

		[NativeThrows]
		private static RuntimeAnimatorController GetAnimatorControllerInternal(ref PlayableHandle handle)
		{
			return Unmarshal.UnmarshalUnityObject<RuntimeAnimatorController>(GetAnimatorControllerInternal_Injected(ref handle));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern int GetLayerCountInternal(ref PlayableHandle handle);

		[NativeThrows]
		private static string GetLayerNameInternal(ref PlayableHandle handle, int layerIndex)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetLayerNameInternal_Injected(ref handle, layerIndex, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[NativeThrows]
		private unsafe static int GetLayerIndexInternal(ref PlayableHandle handle, string layerName)
		{
			//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(layerName, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(layerName);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return GetLayerIndexInternal_Injected(ref handle, ref managedSpanWrapper);
					}
				}
				return GetLayerIndexInternal_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetLayerWeightInternal(ref PlayableHandle handle, int layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetLayerWeightInternal(ref PlayableHandle handle, int layerIndex, float weight);

		[NativeThrows]
		private static AnimatorStateInfo GetCurrentAnimatorStateInfoInternal(ref PlayableHandle handle, int layerIndex)
		{
			GetCurrentAnimatorStateInfoInternal_Injected(ref handle, layerIndex, out var ret);
			return ret;
		}

		[NativeThrows]
		private static AnimatorStateInfo GetNextAnimatorStateInfoInternal(ref PlayableHandle handle, int layerIndex)
		{
			GetNextAnimatorStateInfoInternal_Injected(ref handle, layerIndex, out var ret);
			return ret;
		}

		[NativeThrows]
		private static AnimatorTransitionInfo GetAnimatorTransitionInfoInternal(ref PlayableHandle handle, int layerIndex)
		{
			GetAnimatorTransitionInfoInternal_Injected(ref handle, layerIndex, out var ret);
			return ret;
		}

		[NativeThrows]
		private static AnimatorClipInfo[] GetCurrentAnimatorClipInfoInternal(ref PlayableHandle handle, int layerIndex)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			AnimatorClipInfo[] result;
			try
			{
				GetCurrentAnimatorClipInfoInternal_Injected(ref handle, layerIndex, out ret);
			}
			finally
			{
				AnimatorClipInfo[] array = default(AnimatorClipInfo[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern int GetAnimatorClipInfoCountInternal(ref PlayableHandle handle, int layerIndex, bool current);

		[NativeThrows]
		private static AnimatorClipInfo[] GetNextAnimatorClipInfoInternal(ref PlayableHandle handle, int layerIndex)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			AnimatorClipInfo[] result;
			try
			{
				GetNextAnimatorClipInfoInternal_Injected(ref handle, layerIndex, out ret);
			}
			finally
			{
				AnimatorClipInfo[] array = default(AnimatorClipInfo[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		[NativeThrows]
		private static string ResolveHashInternal(ref PlayableHandle handle, int hash)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				ResolveHashInternal_Injected(ref handle, hash, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool IsInTransitionInternal(ref PlayableHandle handle, int layerIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern AnimatorControllerParameter GetParameterInternal(ref PlayableHandle handle, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern int GetParameterCountInternal(ref PlayableHandle handle);

		[ThreadSafe]
		private unsafe static int StringToHash(string name)
		{
			//The blocks IL_0029 are reachable both inside and outside the pinned region starting at IL_0018. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(name, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(name);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						return StringToHash_Injected(ref managedSpanWrapper);
					}
				}
				return StringToHash_Injected(ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void CrossFadeInFixedTimeInternal(ref PlayableHandle handle, int stateNameHash, float transitionDuration, int layer, float fixedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void CrossFadeInternal(ref PlayableHandle handle, int stateNameHash, float transitionDuration, int layer, float normalizedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void PlayInFixedTimeInternal(ref PlayableHandle handle, int stateNameHash, int layer, float fixedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void PlayInternal(ref PlayableHandle handle, int stateNameHash, int layer, float normalizedTime);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool HasStateInternal(ref PlayableHandle handle, int layerIndex, int stateID);

		[NativeThrows]
		private unsafe static void SetFloatString(ref PlayableHandle handle, string name, float value)
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
						SetFloatString_Injected(ref handle, ref managedSpanWrapper, value);
						return;
					}
				}
				SetFloatString_Injected(ref handle, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetFloatID(ref PlayableHandle handle, int id, float value);

		[NativeThrows]
		private unsafe static float GetFloatString(ref PlayableHandle handle, string name)
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
						return GetFloatString_Injected(ref handle, ref managedSpanWrapper);
					}
				}
				return GetFloatString_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern float GetFloatID(ref PlayableHandle handle, int id);

		[NativeThrows]
		private unsafe static void SetBoolString(ref PlayableHandle handle, string name, bool value)
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
						SetBoolString_Injected(ref handle, ref managedSpanWrapper, value);
						return;
					}
				}
				SetBoolString_Injected(ref handle, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetBoolID(ref PlayableHandle handle, int id, bool value);

		[NativeThrows]
		private unsafe static bool GetBoolString(ref PlayableHandle handle, string name)
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
						return GetBoolString_Injected(ref handle, ref managedSpanWrapper);
					}
				}
				return GetBoolString_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool GetBoolID(ref PlayableHandle handle, int id);

		[NativeThrows]
		private unsafe static void SetIntegerString(ref PlayableHandle handle, string name, int value)
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
						SetIntegerString_Injected(ref handle, ref managedSpanWrapper, value);
						return;
					}
				}
				SetIntegerString_Injected(ref handle, ref managedSpanWrapper, value);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetIntegerID(ref PlayableHandle handle, int id, int value);

		[NativeThrows]
		private unsafe static int GetIntegerString(ref PlayableHandle handle, string name)
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
						return GetIntegerString_Injected(ref handle, ref managedSpanWrapper);
					}
				}
				return GetIntegerString_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern int GetIntegerID(ref PlayableHandle handle, int id);

		[NativeThrows]
		private unsafe static void SetTriggerString(ref PlayableHandle handle, string name)
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
						SetTriggerString_Injected(ref handle, ref managedSpanWrapper);
						return;
					}
				}
				SetTriggerString_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void SetTriggerID(ref PlayableHandle handle, int id);

		[NativeThrows]
		private unsafe static void ResetTriggerString(ref PlayableHandle handle, string name)
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
						ResetTriggerString_Injected(ref handle, ref managedSpanWrapper);
						return;
					}
				}
				ResetTriggerString_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern void ResetTriggerID(ref PlayableHandle handle, int id);

		[NativeThrows]
		private unsafe static bool IsParameterControlledByCurveString(ref PlayableHandle handle, string name)
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
						return IsParameterControlledByCurveString_Injected(ref handle, ref managedSpanWrapper);
					}
				}
				return IsParameterControlledByCurveString_Injected(ref handle, ref managedSpanWrapper);
			}
			finally
			{
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeThrows]
		private static extern bool IsParameterControlledByCurveID(ref PlayableHandle handle, int id);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateHandleInternal_Injected([In] ref PlayableGraph graph, IntPtr controller, ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetAnimatorControllerInternal_Injected(ref PlayableHandle handle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetLayerNameInternal_Injected(ref PlayableHandle handle, int layerIndex, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetLayerIndexInternal_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper layerName);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentAnimatorStateInfoInternal_Injected(ref PlayableHandle handle, int layerIndex, out AnimatorStateInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNextAnimatorStateInfoInternal_Injected(ref PlayableHandle handle, int layerIndex, out AnimatorStateInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetAnimatorTransitionInfoInternal_Injected(ref PlayableHandle handle, int layerIndex, out AnimatorTransitionInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCurrentAnimatorClipInfoInternal_Injected(ref PlayableHandle handle, int layerIndex, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetNextAnimatorClipInfoInternal_Injected(ref PlayableHandle handle, int layerIndex, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResolveHashInternal_Injected(ref PlayableHandle handle, int hash, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int StringToHash_Injected(ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetFloatString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetFloatString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetBoolString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetBoolString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetIntegerString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetIntegerString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTriggerString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResetTriggerString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsParameterControlledByCurveString_Injected(ref PlayableHandle handle, ref ManagedSpanWrapper name);
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	public enum CustomStreamPropertyType
	{
		Float = 5,
		Bool = 6,
		Int = 10
	}
	[NativeHeader("Modules/Animation/Director/AnimationStreamHandles.h")]
	[NativeHeader("Modules/Animation/Animator.h")]
	[NativeHeader("Modules/Animation/Director/AnimationStream.h")]
	[StaticAccessor("AnimatorJobExtensionsBindings", StaticAccessorType.DoubleColon)]
	[NativeHeader("Modules/Animation/ScriptBindings/AnimatorJobExtensions.bindings.h")]
	[NativeHeader("Modules/Animation/Director/AnimationSceneHandles.h")]
	[MovedFrom("UnityEngine.Experimental.Animations")]
	public static class AnimatorJobExtensions
	{
		public static void AddJobDependency(this Animator animator, JobHandle jobHandle)
		{
			InternalAddJobDependency(animator, jobHandle);
		}

		public static TransformStreamHandle BindStreamTransform(this Animator animator, Transform transform)
		{
			TransformStreamHandle transformStreamHandle = default(TransformStreamHandle);
			InternalBindStreamTransform(animator, transform, out transformStreamHandle);
			return transformStreamHandle;
		}

		public static PropertyStreamHandle BindStreamProperty(this Animator animator, Transform transform, Type type, string property)
		{
			return animator.BindStreamProperty(transform, type, property, isObjectReference: false);
		}

		public static PropertyStreamHandle BindCustomStreamProperty(this Animator animator, string property, CustomStreamPropertyType type)
		{
			PropertyStreamHandle propertyStreamHandle = default(PropertyStreamHandle);
			InternalBindCustomStreamProperty(animator, property, type, out propertyStreamHandle);
			return propertyStreamHandle;
		}

		public static PropertyStreamHandle BindStreamProperty(this Animator animator, Transform transform, Type type, string property, [UnityEngine.Internal.DefaultValue("false")] bool isObjectReference)
		{
			PropertyStreamHandle propertyStreamHandle = default(PropertyStreamHandle);
			InternalBindStreamProperty(animator, transform, type, property, isObjectReference, out propertyStreamHandle);
			return propertyStreamHandle;
		}

		public static TransformSceneHandle BindSceneTransform(this Animator animator, Transform transform)
		{
			TransformSceneHandle transformSceneHandle = default(TransformSceneHandle);
			InternalBindSceneTransform(animator, transform, out transformSceneHandle);
			return transformSceneHandle;
		}

		public static PropertySceneHandle BindSceneProperty(this Animator animator, Transform transform, Type type, string property)
		{
			return animator.BindSceneProperty(transform, type, property, isObjectReference: false);
		}

		public static PropertySceneHandle BindSceneProperty(this Animator animator, Transform transform, Type type, string property, [UnityEngine.Internal.DefaultValue("false")] bool isObjectReference)
		{
			PropertySceneHandle propertySceneHandle = default(PropertySceneHandle);
			InternalBindSceneProperty(animator, transform, type, property, isObjectReference, out propertySceneHandle);
			return propertySceneHandle;
		}

		public static bool OpenAnimationStream(this Animator animator, ref AnimationStream stream)
		{
			return InternalOpenAnimationStream(animator, ref stream);
		}

		public static void CloseAnimationStream(this Animator animator, ref AnimationStream stream)
		{
			InternalCloseAnimationStream(animator, ref stream);
		}

		public static void ResolveAllStreamHandles(this Animator animator)
		{
			InternalResolveAllStreamHandles(animator);
		}

		public static void ResolveAllSceneHandles(this Animator animator)
		{
			InternalResolveAllSceneHandles(animator);
		}

		internal static void UnbindAllHandles(this Animator animator)
		{
			InternalUnbindAllStreamHandles(animator);
			InternalUnbindAllSceneHandles(animator);
		}

		public static void UnbindAllStreamHandles(this Animator animator)
		{
			InternalUnbindAllStreamHandles(animator);
		}

		public static void UnbindAllSceneHandles(this Animator animator)
		{
			InternalUnbindAllSceneHandles(animator);
		}

		private static void InternalAddJobDependency([NotNull] Animator animator, JobHandle jobHandle)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalAddJobDependency_Injected(intPtr, ref jobHandle);
		}

		private static void InternalBindStreamTransform([NotNull] Animator animator, [NotNull] Transform transform, out TransformStreamHandle transformStreamHandle)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			if ((object)transform == null)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(transform);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			InternalBindStreamTransform_Injected(intPtr, intPtr2, out transformStreamHandle);
		}

		private unsafe static void InternalBindStreamProperty([NotNull] Animator animator, [NotNull] Transform transform, [NotNull] Type type, [NotNull] string property, bool isObjectReference, out PropertyStreamHandle propertyStreamHandle)
		{
			//The blocks IL_0090 are reachable both inside and outside the pinned region starting at IL_007f. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			if ((object)transform == null)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException(type, "type");
			}
			if (property == null)
			{
				ThrowHelper.ThrowArgumentNullException(property, "property");
			}
			try
			{
				IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(animator, "animator");
				}
				IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(transform);
				if (intPtr2 == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(transform, "transform");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(property, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(property);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						InternalBindStreamProperty_Injected(intPtr, intPtr2, type, ref managedSpanWrapper, isObjectReference, out propertyStreamHandle);
						return;
					}
				}
				InternalBindStreamProperty_Injected(intPtr, intPtr2, type, ref managedSpanWrapper, isObjectReference, out propertyStreamHandle);
			}
			finally
			{
			}
		}

		private unsafe static void InternalBindCustomStreamProperty([NotNull] Animator animator, [NotNull] string property, CustomStreamPropertyType propertyType, out PropertyStreamHandle propertyStreamHandle)
		{
			//The blocks IL_005c are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			if (property == null)
			{
				ThrowHelper.ThrowArgumentNullException(property, "property");
			}
			try
			{
				IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(animator, "animator");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(property, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(property);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						InternalBindCustomStreamProperty_Injected(intPtr, ref managedSpanWrapper, propertyType, out propertyStreamHandle);
						return;
					}
				}
				InternalBindCustomStreamProperty_Injected(intPtr, ref managedSpanWrapper, propertyType, out propertyStreamHandle);
			}
			finally
			{
			}
		}

		private static void InternalBindSceneTransform([NotNull] Animator animator, [NotNull] Transform transform, out TransformSceneHandle transformSceneHandle)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			if ((object)transform == null)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(transform);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			InternalBindSceneTransform_Injected(intPtr, intPtr2, out transformSceneHandle);
		}

		private unsafe static void InternalBindSceneProperty([NotNull] Animator animator, [NotNull] Transform transform, [NotNull] Type type, [NotNull] string property, bool isObjectReference, out PropertySceneHandle propertySceneHandle)
		{
			//The blocks IL_0090 are reachable both inside and outside the pinned region starting at IL_007f. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			if ((object)transform == null)
			{
				ThrowHelper.ThrowArgumentNullException(transform, "transform");
			}
			if ((object)type == null)
			{
				ThrowHelper.ThrowArgumentNullException(type, "type");
			}
			if (property == null)
			{
				ThrowHelper.ThrowArgumentNullException(property, "property");
			}
			try
			{
				IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(animator, "animator");
				}
				IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(transform);
				if (intPtr2 == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(transform, "transform");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				if (!StringMarshaller.TryMarshalEmptyOrNullString(property, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(property);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						InternalBindSceneProperty_Injected(intPtr, intPtr2, type, ref managedSpanWrapper, isObjectReference, out propertySceneHandle);
						return;
					}
				}
				InternalBindSceneProperty_Injected(intPtr, intPtr2, type, ref managedSpanWrapper, isObjectReference, out propertySceneHandle);
			}
			finally
			{
			}
		}

		private static bool InternalOpenAnimationStream([NotNull] Animator animator, ref AnimationStream stream)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			return InternalOpenAnimationStream_Injected(intPtr, ref stream);
		}

		private static void InternalCloseAnimationStream([NotNull] Animator animator, ref AnimationStream stream)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalCloseAnimationStream_Injected(intPtr, ref stream);
		}

		private static void InternalResolveAllStreamHandles([NotNull] Animator animator)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalResolveAllStreamHandles_Injected(intPtr);
		}

		private static void InternalResolveAllSceneHandles([NotNull] Animator animator)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalResolveAllSceneHandles_Injected(intPtr);
		}

		private static void InternalUnbindAllStreamHandles([NotNull] Animator animator)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalUnbindAllStreamHandles_Injected(intPtr);
		}

		private static void InternalUnbindAllSceneHandles([NotNull] Animator animator)
		{
			if ((object)animator == null)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(animator);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(animator, "animator");
			}
			InternalUnbindAllSceneHandles_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalAddJobDependency_Injected(IntPtr animator, [In] ref JobHandle jobHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalBindStreamTransform_Injected(IntPtr animator, IntPtr transform, out TransformStreamHandle transformStreamHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalBindStreamProperty_Injected(IntPtr animator, IntPtr transform, Type type, ref ManagedSpanWrapper property, bool isObjectReference, out PropertyStreamHandle propertyStreamHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalBindCustomStreamProperty_Injected(IntPtr animator, ref ManagedSpanWrapper property, CustomStreamPropertyType propertyType, out PropertyStreamHandle propertyStreamHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalBindSceneTransform_Injected(IntPtr animator, IntPtr transform, out TransformSceneHandle transformSceneHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalBindSceneProperty_Injected(IntPtr animator, IntPtr transform, Type type, ref ManagedSpanWrapper property, bool isObjectReference, out PropertySceneHandle propertySceneHandle);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool InternalOpenAnimationStream_Injected(IntPtr animator, ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalCloseAnimationStream_Injected(IntPtr animator, ref AnimationStream stream);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalResolveAllStreamHandles_Injected(IntPtr animator);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalResolveAllSceneHandles_Injected(IntPtr animator);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalUnbindAllStreamHandles_Injected(IntPtr animator);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InternalUnbindAllSceneHandles_Injected(IntPtr animator);
	}
	[NativeHeader("Modules/Animation/BoundProperty.h")]
	public readonly struct BoundProperty : IEquatable<BoundProperty>, IComparable<BoundProperty>
	{
		private readonly int m_Index;

		private readonly int m_Version;

		public int index => m_Index;

		public int version => m_Version;

		public static BoundProperty Null => default(BoundProperty);

		public static bool operator ==(BoundProperty lhs, BoundProperty rhs)
		{
			return lhs.m_Index == rhs.m_Index && lhs.m_Version == rhs.m_Version;
		}

		public static bool operator !=(BoundProperty lhs, BoundProperty rhs)
		{
			return !(lhs == rhs);
		}

		public override bool Equals(object compare)
		{
			return compare is BoundProperty boundProperty && Equals(boundProperty);
		}

		public bool Equals(BoundProperty boundProperty)
		{
			return boundProperty.m_Index == m_Index && boundProperty.m_Version == m_Version;
		}

		public int CompareTo(BoundProperty other)
		{
			return m_Index - other.m_Index;
		}

		public override int GetHashCode()
		{
			return (m_Version * 397) ^ m_Index;
		}
	}
	[NativeType("Modules/Animation/Constraints/ConstraintEnums.h")]
	[Flags]
	public enum Axis
	{
		None = 0,
		X = 1,
		Y = 2,
		Z = 4
	}
	[Serializable]
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	[NativeType(CodegenOptions = CodegenOptions.Custom, Header = "Modules/Animation/Constraints/ConstraintSource.h", IntermediateScriptingStructName = "MonoConstraintSource")]
	[UsedByNativeCode]
	public struct ConstraintSource
	{
		[NativeName("sourceTransform")]
		private Transform m_SourceTransform;

		[NativeName("weight")]
		private float m_Weight;

		public Transform sourceTransform
		{
			get
			{
				return m_SourceTransform;
			}
			set
			{
				m_SourceTransform = value;
			}
		}

		public float weight
		{
			get
			{
				return m_Weight;
			}
			set
			{
				m_Weight = value;
			}
		}
	}
	public interface IConstraint
	{
		float weight { get; set; }

		bool constraintActive { get; set; }

		bool locked { get; set; }

		int sourceCount { get; }

		int AddSource(ConstraintSource source);

		void RemoveSource(int index);

		ConstraintSource GetSource(int index);

		void SetSource(int index, ConstraintSource source);

		void GetSources(List<ConstraintSource> sources);

		void SetSources(List<ConstraintSource> sources);
	}
	internal interface IConstraintInternal
	{
	}
	[RequireComponent(typeof(Transform))]
	[UsedByNativeCode]
	[NativeHeader("Modules/Animation/Constraints/PositionConstraint.h")]
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	public sealed class PositionConstraint : Behaviour, IConstraint, IConstraintInternal
	{
		public float weight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public Vector3 translationAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_translationAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_translationAtRest_Injected(intPtr, ref value);
			}
		}

		public Vector3 translationOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_translationOffset_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_translationOffset_Injected(intPtr, ref value);
			}
		}

		public Axis translationAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_translationAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_translationAxis_Injected(intPtr, value);
			}
		}

		public bool constraintActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraintActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraintActive_Injected(intPtr, value);
			}
		}

		public bool locked
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_locked_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_locked_Injected(intPtr, value);
			}
		}

		public int sourceCount => GetSourceCountInternal(this);

		private PositionConstraint()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] PositionConstraint self);

		[FreeFunction("ConstraintBindings::GetSourceCount")]
		private static int GetSourceCountInternal([NotNull] PositionConstraint self)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			return GetSourceCountInternal_Injected(intPtr);
		}

		[FreeFunction(Name = "ConstraintBindings::GetSources", HasExplicitThis = true)]
		public void GetSources([NotNull] List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				ThrowHelper.ThrowArgumentNullException(sources, "sources");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSources_Injected(intPtr, sources);
		}

		public void SetSources(List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			SetSourcesInternal(this, sources);
		}

		[FreeFunction("ConstraintBindings::SetSources", ThrowsException = true)]
		private static void SetSourcesInternal([NotNull] PositionConstraint self, List<ConstraintSource> sources)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			SetSourcesInternal_Injected(intPtr, sources);
		}

		public int AddSource(ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddSource_Injected(intPtr, ref source);
		}

		public void RemoveSource(int index)
		{
			ValidateSourceIndex(index);
			RemoveSourceInternal(index);
		}

		[NativeName("RemoveSource")]
		private void RemoveSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveSourceInternal_Injected(intPtr, index);
		}

		public ConstraintSource GetSource(int index)
		{
			ValidateSourceIndex(index);
			return GetSourceInternal(index);
		}

		[NativeName("GetSource")]
		private ConstraintSource GetSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSourceInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		public void SetSource(int index, ConstraintSource source)
		{
			ValidateSourceIndex(index);
			SetSourceInternal(index, source);
		}

		[NativeName("SetSource")]
		private void SetSourceInternal(int index, ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSourceInternal_Injected(intPtr, index, ref source);
		}

		private void ValidateSourceIndex(int index)
		{
			if (sourceCount == 0)
			{
				throw new InvalidOperationException("The PositionConstraint component has no sources.");
			}
			if (index < 0 || index >= sourceCount)
			{
				throw new ArgumentOutOfRangeException("index", $"Constraint source index {index} is out of bounds (0-{sourceCount}).");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_translationAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_translationAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_translationOffset_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_translationOffset_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Axis get_translationAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_translationAxis_Injected(IntPtr _unity_self, Axis value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_constraintActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraintActive_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_locked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_locked_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceCountInternal_Injected(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSources_Injected(IntPtr _unity_self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcesInternal_Injected(IntPtr self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddSource_Injected(IntPtr _unity_self, [In] ref ConstraintSource source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveSourceInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourceInternal_Injected(IntPtr _unity_self, int index, out ConstraintSource ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourceInternal_Injected(IntPtr _unity_self, int index, [In] ref ConstraintSource source);
	}
	[UsedByNativeCode]
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Modules/Animation/Constraints/RotationConstraint.h")]
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	public sealed class RotationConstraint : Behaviour, IConstraint, IConstraintInternal
	{
		public float weight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public Vector3 rotationAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAtRest_Injected(intPtr, ref value);
			}
		}

		public Vector3 rotationOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationOffset_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationOffset_Injected(intPtr, ref value);
			}
		}

		public Axis rotationAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rotationAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAxis_Injected(intPtr, value);
			}
		}

		public bool constraintActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraintActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraintActive_Injected(intPtr, value);
			}
		}

		public bool locked
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_locked_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_locked_Injected(intPtr, value);
			}
		}

		public int sourceCount => GetSourceCountInternal(this);

		private RotationConstraint()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] RotationConstraint self);

		[FreeFunction("ConstraintBindings::GetSourceCount")]
		private static int GetSourceCountInternal([NotNull] RotationConstraint self)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			return GetSourceCountInternal_Injected(intPtr);
		}

		[FreeFunction(Name = "ConstraintBindings::GetSources", HasExplicitThis = true)]
		public void GetSources([NotNull] List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				ThrowHelper.ThrowArgumentNullException(sources, "sources");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSources_Injected(intPtr, sources);
		}

		public void SetSources(List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			SetSourcesInternal(this, sources);
		}

		[FreeFunction("ConstraintBindings::SetSources", ThrowsException = true)]
		private static void SetSourcesInternal([NotNull] RotationConstraint self, List<ConstraintSource> sources)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			SetSourcesInternal_Injected(intPtr, sources);
		}

		public int AddSource(ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddSource_Injected(intPtr, ref source);
		}

		public void RemoveSource(int index)
		{
			ValidateSourceIndex(index);
			RemoveSourceInternal(index);
		}

		[NativeName("RemoveSource")]
		private void RemoveSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveSourceInternal_Injected(intPtr, index);
		}

		public ConstraintSource GetSource(int index)
		{
			ValidateSourceIndex(index);
			return GetSourceInternal(index);
		}

		[NativeName("GetSource")]
		private ConstraintSource GetSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSourceInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		public void SetSource(int index, ConstraintSource source)
		{
			ValidateSourceIndex(index);
			SetSourceInternal(index, source);
		}

		[NativeName("SetSource")]
		private void SetSourceInternal(int index, ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSourceInternal_Injected(intPtr, index, ref source);
		}

		private void ValidateSourceIndex(int index)
		{
			if (sourceCount == 0)
			{
				throw new InvalidOperationException("The RotationConstraint component has no sources.");
			}
			if (index < 0 || index >= sourceCount)
			{
				throw new ArgumentOutOfRangeException("index", $"Constraint source index {index} is out of bounds (0-{sourceCount}).");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationOffset_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationOffset_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Axis get_rotationAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAxis_Injected(IntPtr _unity_self, Axis value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_constraintActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraintActive_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_locked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_locked_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceCountInternal_Injected(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSources_Injected(IntPtr _unity_self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcesInternal_Injected(IntPtr self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddSource_Injected(IntPtr _unity_self, [In] ref ConstraintSource source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveSourceInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourceInternal_Injected(IntPtr _unity_self, int index, out ConstraintSource ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourceInternal_Injected(IntPtr _unity_self, int index, [In] ref ConstraintSource source);
	}
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	[NativeHeader("Modules/Animation/Constraints/ScaleConstraint.h")]
	[RequireComponent(typeof(Transform))]
	[UsedByNativeCode]
	public sealed class ScaleConstraint : Behaviour, IConstraint, IConstraintInternal
	{
		public float weight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public Vector3 scaleAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_scaleAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_scaleAtRest_Injected(intPtr, ref value);
			}
		}

		public Vector3 scaleOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_scaleOffset_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_scaleOffset_Injected(intPtr, ref value);
			}
		}

		public Axis scalingAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_scalingAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_scalingAxis_Injected(intPtr, value);
			}
		}

		public bool constraintActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraintActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraintActive_Injected(intPtr, value);
			}
		}

		public bool locked
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_locked_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_locked_Injected(intPtr, value);
			}
		}

		public int sourceCount => GetSourceCountInternal(this);

		private ScaleConstraint()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] ScaleConstraint self);

		[FreeFunction("ConstraintBindings::GetSourceCount")]
		private static int GetSourceCountInternal([NotNull] ScaleConstraint self)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			return GetSourceCountInternal_Injected(intPtr);
		}

		[FreeFunction(Name = "ConstraintBindings::GetSources", HasExplicitThis = true)]
		public void GetSources([NotNull] List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				ThrowHelper.ThrowArgumentNullException(sources, "sources");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSources_Injected(intPtr, sources);
		}

		public void SetSources(List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			SetSourcesInternal(this, sources);
		}

		[FreeFunction("ConstraintBindings::SetSources", ThrowsException = true)]
		private static void SetSourcesInternal([NotNull] ScaleConstraint self, List<ConstraintSource> sources)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			SetSourcesInternal_Injected(intPtr, sources);
		}

		public int AddSource(ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddSource_Injected(intPtr, ref source);
		}

		public void RemoveSource(int index)
		{
			ValidateSourceIndex(index);
			RemoveSourceInternal(index);
		}

		[NativeName("RemoveSource")]
		private void RemoveSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveSourceInternal_Injected(intPtr, index);
		}

		public ConstraintSource GetSource(int index)
		{
			ValidateSourceIndex(index);
			return GetSourceInternal(index);
		}

		[NativeName("GetSource")]
		private ConstraintSource GetSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSourceInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		public void SetSource(int index, ConstraintSource source)
		{
			ValidateSourceIndex(index);
			SetSourceInternal(index, source);
		}

		[NativeName("SetSource")]
		private void SetSourceInternal(int index, ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSourceInternal_Injected(intPtr, index, ref source);
		}

		private void ValidateSourceIndex(int index)
		{
			if (sourceCount == 0)
			{
				throw new InvalidOperationException("The ScaleConstraint component has no sources.");
			}
			if (index < 0 || index >= sourceCount)
			{
				throw new ArgumentOutOfRangeException("index", $"Constraint source index {index} is out of bounds (0-{sourceCount}).");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_scaleAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_scaleAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_scaleOffset_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_scaleOffset_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Axis get_scalingAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_scalingAxis_Injected(IntPtr _unity_self, Axis value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_constraintActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraintActive_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_locked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_locked_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceCountInternal_Injected(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSources_Injected(IntPtr _unity_self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcesInternal_Injected(IntPtr self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddSource_Injected(IntPtr _unity_self, [In] ref ConstraintSource source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveSourceInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourceInternal_Injected(IntPtr _unity_self, int index, out ConstraintSource ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourceInternal_Injected(IntPtr _unity_self, int index, [In] ref ConstraintSource source);
	}
	internal enum Flags
	{
		kNone = 0,
		kDiscrete = 1,
		kPPtr = 2,
		kSerializeReference = 4,
		kPhantom = 8,
		kUnknown = 0x10
	}
	[NativeType(CodegenOptions.Custom, "UnityEngine::Animation::MonoGenericBinding")]
	[UsedByNativeCode]
	public readonly struct GenericBinding
	{
		private readonly uint m_Path;

		private readonly uint m_PropertyName;

		private readonly EntityId m_ScriptEntityId;

		private readonly int m_TypeID;

		private readonly byte m_CustomType;

		internal readonly Flags m_Flags;

		public bool isObjectReference => (m_Flags & Flags.kPPtr) == Flags.kPPtr;

		public bool isDiscrete => (m_Flags & Flags.kDiscrete) != 0;

		public bool isSerializeReference => (m_Flags & Flags.kSerializeReference) == Flags.kSerializeReference;

		public uint transformPathHash => m_Path;

		public uint propertyNameHash => m_PropertyName;

		public EntityId scriptEntityId => m_ScriptEntityId;

		[Obsolete("scriptInstanceID is deprecated. Use scriptEntityId instead.", false)]
		public int scriptInstanceID => m_ScriptEntityId;

		public int typeID => m_TypeID;

		public byte customTypeID => m_CustomType;
	}
	[NativeHeader("Modules/Animation/ScriptBindings/GenericBinding.bindings.h")]
	[StaticAccessor("UnityEngine::Animation::GenericBindingUtility", StaticAccessorType.DoubleColon)]
	public static class GenericBindingUtility
	{
		public static bool CreateGenericBinding(Object targetObject, string property, GameObject root, bool isObjectReference, out GenericBinding genericBinding)
		{
			if (targetObject == null)
			{
				throw new ArgumentNullException("targetObject");
			}
			if (typeof(Transform).IsAssignableFrom(targetObject.GetType()))
			{
				throw new ArgumentException("Unsupported type for targetObject. Cannot create a generic binding from a Transform component.");
			}
			if (targetObject is Component component)
			{
				return CreateGenericBindingForComponent(component, property, root, isObjectReference, out genericBinding);
			}
			if (targetObject is GameObject gameObject)
			{
				return CreateGenericBindingForGameObject(gameObject, property, root, out genericBinding);
			}
			throw new ArgumentException(string.Format("Type {0} for {1} is unsupported. Expecting either a GameObject or a Component", targetObject.GetType(), "targetObject"));
		}

		[NativeMethod(IsThreadSafe = false)]
		private unsafe static bool CreateGenericBindingForGameObject([NotNull] GameObject gameObject, string property, [NotNull] GameObject root, out GenericBinding genericBinding)
		{
			//The blocks IL_005c, IL_0068, IL_0073 are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)gameObject == null)
			{
				ThrowHelper.ThrowArgumentNullException(gameObject, "gameObject");
			}
			if ((object)root == null)
			{
				ThrowHelper.ThrowArgumentNullException(root, "root");
			}
			try
			{
				IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(gameObject);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(gameObject, "gameObject");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper property2;
				IntPtr intPtr2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(property, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(property);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						property2 = ref managedSpanWrapper;
						intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(root);
						if (intPtr2 == (IntPtr)0)
						{
							ThrowHelper.ThrowArgumentNullException(root, "root");
						}
						return CreateGenericBindingForGameObject_Injected(intPtr, ref property2, intPtr2, out genericBinding);
					}
				}
				property2 = ref managedSpanWrapper;
				intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(root);
				if (intPtr2 == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(root, "root");
				}
				return CreateGenericBindingForGameObject_Injected(intPtr, ref property2, intPtr2, out genericBinding);
			}
			finally
			{
			}
		}

		[NativeMethod(IsThreadSafe = false)]
		private unsafe static bool CreateGenericBindingForComponent([NotNull] Component component, string property, [NotNull] GameObject root, bool isObjectReference, out GenericBinding genericBinding)
		{
			//The blocks IL_005c, IL_0068, IL_0073 are reachable both inside and outside the pinned region starting at IL_004b. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			if ((object)component == null)
			{
				ThrowHelper.ThrowArgumentNullException(component, "component");
			}
			if ((object)root == null)
			{
				ThrowHelper.ThrowArgumentNullException(root, "root");
			}
			try
			{
				IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(component);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(component, "component");
				}
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper property2;
				IntPtr intPtr2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(property, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(property);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						property2 = ref managedSpanWrapper;
						intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(root);
						if (intPtr2 == (IntPtr)0)
						{
							ThrowHelper.ThrowArgumentNullException(root, "root");
						}
						return CreateGenericBindingForComponent_Injected(intPtr, ref property2, intPtr2, isObjectReference, out genericBinding);
					}
				}
				property2 = ref managedSpanWrapper;
				intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(root);
				if (intPtr2 == (IntPtr)0)
				{
					ThrowHelper.ThrowArgumentNullException(root, "root");
				}
				return CreateGenericBindingForComponent_Injected(intPtr, ref property2, intPtr2, isObjectReference, out genericBinding);
			}
			finally
			{
			}
		}

		[NativeMethod(IsThreadSafe = false)]
		public static GenericBinding[] GetAnimatableBindings([NotNull] GameObject targetObject, [NotNull] GameObject root)
		{
			if ((object)targetObject == null)
			{
				ThrowHelper.ThrowArgumentNullException(targetObject, "targetObject");
			}
			if ((object)root == null)
			{
				ThrowHelper.ThrowArgumentNullException(root, "root");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(targetObject);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(targetObject, "targetObject");
			}
			IntPtr intPtr2 = Object.MarshalledUnityObject.MarshalNotNull(root);
			if (intPtr2 == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(root, "root");
			}
			return GetAnimatableBindings_Injected(intPtr, intPtr2);
		}

		[NativeMethod(IsThreadSafe = false)]
		public static GenericBinding[] GetCurveBindings([NotNull] AnimationClip clip)
		{
			if ((object)clip == null)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(clip);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(clip, "clip");
			}
			return GetCurveBindings_Injected(intPtr);
		}

		[Obsolete("This version of BindProperties is deprecated. Use the overload which includes `out instanceIDProperties` instead.", false)]
		public static void BindProperties(GameObject rootGameObject, NativeArray<GenericBinding> genericBindings, out NativeArray<BoundProperty> floatProperties, out NativeArray<BoundProperty> discreteProperties, Allocator allocator)
		{
			BindProperties(rootGameObject, genericBindings, out floatProperties, out discreteProperties, out var _, allocator);
		}

		public unsafe static void BindProperties(GameObject rootGameObject, NativeArray<GenericBinding> genericBindings, out NativeArray<BoundProperty> floatProperties, out NativeArray<BoundProperty> discreteProperties, out NativeArray<BoundProperty> instanceIDProperties, Allocator allocator)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < genericBindings.Length; i++)
			{
				if (genericBindings[i].typeID != 4)
				{
					if (genericBindings[i].isDiscrete)
					{
						num2++;
					}
					if (genericBindings[i].isObjectReference)
					{
						num3++;
					}
					else
					{
						num++;
					}
				}
			}
			floatProperties = new NativeArray<BoundProperty>(num, allocator);
			discreteProperties = new NativeArray<BoundProperty>(num2, allocator);
			instanceIDProperties = new NativeArray<BoundProperty>(num3, allocator);
			void* unsafePtr = genericBindings.GetUnsafePtr();
			void* unsafePtr2 = floatProperties.GetUnsafePtr();
			void* unsafePtr3 = discreteProperties.GetUnsafePtr();
			void* unsafePtr4 = instanceIDProperties.GetUnsafePtr();
			Internal_BindProperties(rootGameObject, unsafePtr, genericBindings.Length, unsafePtr2, unsafePtr3, unsafePtr4);
		}

		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static void Internal_BindProperties([NotNull] GameObject gameObject, void* genericBindings, int genericBindingsCount, void* floatProperties, void* discreteProperties, void* instanceIDProperties)
		{
			if ((object)gameObject == null)
			{
				ThrowHelper.ThrowArgumentNullException(gameObject, "gameObject");
			}
			IntPtr intPtr = Object.MarshalledUnityObject.MarshalNotNull(gameObject);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(gameObject, "gameObject");
			}
			Internal_BindProperties_Injected(intPtr, genericBindings, genericBindingsCount, floatProperties, discreteProperties, instanceIDProperties);
		}

		public unsafe static void UnbindProperties(NativeArray<BoundProperty> boundProperties)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			Internal_UnbindProperties(unsafePtr, boundProperties.Length);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void Internal_UnbindProperties(void* boundProperties, int boundPropertiesCount);

		public unsafe static void SetValues(NativeArray<BoundProperty> boundProperties, NativeArray<float> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			SetFloatValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, values.Length);
		}

		public unsafe static void SetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> indices, NativeArray<float> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(indices);
			void* unsafeBufferPointerWithoutChecks2 = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			SetScatterFloatValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, indices.Length, unsafeBufferPointerWithoutChecks2, values.Length);
		}

		public unsafe static void SetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			SetDiscreteValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, values.Length);
		}

		public unsafe static void SetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> indices, NativeArray<int> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(indices);
			void* unsafeBufferPointerWithoutChecks2 = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			SetScatterDiscreteValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, indices.Length, unsafeBufferPointerWithoutChecks2, values.Length);
		}

		public unsafe static void SetValues(NativeArray<BoundProperty> boundProperties, NativeArray<EntityId> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			SetEntityIdValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, values.Length);
		}

		public unsafe static void SetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> indices, NativeArray<EntityId> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(indices);
			void* unsafeBufferPointerWithoutChecks2 = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			SetScatterEntityIdValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, indices.Length, unsafeBufferPointerWithoutChecks2, values.Length);
		}

		public unsafe static void GetValues(NativeArray<BoundProperty> boundProperties, NativeArray<float> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			GetFloatValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, values.Length);
		}

		public unsafe static void GetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> indices, NativeArray<float> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(indices);
			void* unsafeBufferPointerWithoutChecks2 = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			GetScatterFloatValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, indices.Length, unsafeBufferPointerWithoutChecks2, values.Length);
		}

		public unsafe static void GetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			GetDiscreteValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, values.Length);
		}

		public unsafe static void GetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> indices, NativeArray<int> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(indices);
			void* unsafeBufferPointerWithoutChecks2 = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			GetScatterDiscreteValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, indices.Length, unsafeBufferPointerWithoutChecks2, values.Length);
		}

		public unsafe static void GetValues(NativeArray<BoundProperty> boundProperties, NativeArray<EntityId> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			GetEntityIdValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, values.Length);
		}

		public unsafe static void GetValues(NativeArray<BoundProperty> boundProperties, NativeArray<int> indices, NativeArray<EntityId> values)
		{
			void* unsafePtr = boundProperties.GetUnsafePtr();
			void* unsafeBufferPointerWithoutChecks = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(indices);
			void* unsafeBufferPointerWithoutChecks2 = NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(values);
			GetScatterEntityIdValues(unsafePtr, boundProperties.Length, unsafeBufferPointerWithoutChecks, indices.Length, unsafeBufferPointerWithoutChecks2, values.Length);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void SetFloatValues(void* boundProperties, int boundPropertiesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void SetScatterFloatValues(void* boundProperties, int boundPropertiesCount, void* indices, int indicesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void SetDiscreteValues(void* boundProperties, int boundPropertiesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void SetScatterDiscreteValues(void* boundProperties, int boundPropertiesCount, void* indices, int indicesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void SetEntityIdValues(void* boundProperties, int boundPropertiesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void SetScatterEntityIdValues(void* boundProperties, int boundPropertiesCount, void* indices, int indicesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void GetFloatValues(void* boundProperties, int boundPropertiesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void GetScatterFloatValues(void* boundProperties, int boundPropertiesCount, void* indices, int indicesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void GetDiscreteValues(void* boundProperties, int boundPropertiesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void GetScatterDiscreteValues(void* boundProperties, int boundPropertiesCount, void* indices, int indicesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void GetEntityIdValues(void* boundProperties, int boundPropertiesCount, void* values, int valuesCount);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(IsThreadSafe = false)]
		internal unsafe static extern void GetScatterEntityIdValues(void* boundProperties, int boundPropertiesCount, void* indices, int indicesCount, void* values, int valuesCount);

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void ValidateIsCreated<T>(NativeArray<T> array) where T : unmanaged
		{
			if (!array.IsCreated)
			{
				throw new ArgumentException("NativeArray of " + typeof(T).Name + " is not created.");
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void ValidateIndicesAreInRange(NativeArray<int> indices, int maxValue)
		{
			for (int i = 0; i < indices.Length; i++)
			{
				if (indices[i] < 0 || indices[i] >= maxValue)
				{
					throw new IndexOutOfRangeException($"NativeArray of indices contain element out of range at index '{i}': value '{indices[i]}' is not in the range 0 to {maxValue}.");
				}
			}
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal static void ValidateLengthMatch<T1, T2>(NativeArray<T1> array1, NativeArray<T2> array2) where T1 : unmanaged where T2 : unmanaged
		{
			if (array1.Length != array2.Length)
			{
				throw new ArgumentException("Length must be equals for NativeArray<" + typeof(T1).Name + "> and NativeArray<" + typeof(T2).Name + ">.");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateGenericBindingForGameObject_Injected(IntPtr gameObject, ref ManagedSpanWrapper property, IntPtr root, out GenericBinding genericBinding);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool CreateGenericBindingForComponent_Injected(IntPtr component, ref ManagedSpanWrapper property, IntPtr root, bool isObjectReference, out GenericBinding genericBinding);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern GenericBinding[] GetAnimatableBindings_Injected(IntPtr targetObject, IntPtr root);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern GenericBinding[] GetCurveBindings_Injected(IntPtr clip);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Internal_BindProperties_Injected(IntPtr gameObject, void* genericBindings, int genericBindingsCount, void* floatProperties, void* discreteProperties, void* instanceIDProperties);
	}
	[UsedByNativeCode]
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Modules/Animation/Constraints/LookAtConstraint.h")]
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	public sealed class LookAtConstraint : Behaviour, IConstraint, IConstraintInternal
	{
		public float weight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public float roll
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_roll_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_roll_Injected(intPtr, value);
			}
		}

		public bool constraintActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraintActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraintActive_Injected(intPtr, value);
			}
		}

		public bool locked
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_locked_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_locked_Injected(intPtr, value);
			}
		}

		public Vector3 rotationAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAtRest_Injected(intPtr, ref value);
			}
		}

		public Vector3 rotationOffset
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationOffset_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationOffset_Injected(intPtr, ref value);
			}
		}

		public Transform worldUpObject
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Transform>(get_worldUpObject_Injected(intPtr));
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_worldUpObject_Injected(intPtr, MarshalledUnityObject.Marshal(value));
			}
		}

		public bool useUpObject
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useUpObject_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useUpObject_Injected(intPtr, value);
			}
		}

		public int sourceCount => GetSourceCountInternal(this);

		private LookAtConstraint()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] LookAtConstraint self);

		[FreeFunction("ConstraintBindings::GetSourceCount")]
		private static int GetSourceCountInternal([NotNull] LookAtConstraint self)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			return GetSourceCountInternal_Injected(intPtr);
		}

		[FreeFunction(Name = "ConstraintBindings::GetSources", HasExplicitThis = true)]
		public void GetSources([NotNull] List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				ThrowHelper.ThrowArgumentNullException(sources, "sources");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSources_Injected(intPtr, sources);
		}

		public void SetSources(List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			SetSourcesInternal(this, sources);
		}

		[FreeFunction("ConstraintBindings::SetSources", ThrowsException = true)]
		private static void SetSourcesInternal([NotNull] LookAtConstraint self, List<ConstraintSource> sources)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			SetSourcesInternal_Injected(intPtr, sources);
		}

		public int AddSource(ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddSource_Injected(intPtr, ref source);
		}

		public void RemoveSource(int index)
		{
			ValidateSourceIndex(index);
			RemoveSourceInternal(index);
		}

		[NativeName("RemoveSource")]
		private void RemoveSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveSourceInternal_Injected(intPtr, index);
		}

		public ConstraintSource GetSource(int index)
		{
			ValidateSourceIndex(index);
			return GetSourceInternal(index);
		}

		[NativeName("GetSource")]
		private ConstraintSource GetSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSourceInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		public void SetSource(int index, ConstraintSource source)
		{
			ValidateSourceIndex(index);
			SetSourceInternal(index, source);
		}

		[NativeName("SetSource")]
		private void SetSourceInternal(int index, ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSourceInternal_Injected(intPtr, index, ref source);
		}

		private void ValidateSourceIndex(int index)
		{
			if (sourceCount == 0)
			{
				throw new InvalidOperationException("The LookAtConstraint component has no sources.");
			}
			if (index < 0 || index >= sourceCount)
			{
				throw new ArgumentOutOfRangeException("index", $"Constraint source index {index} is out of bounds (0-{sourceCount}).");
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_roll_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_roll_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_constraintActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraintActive_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_locked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_locked_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationOffset_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationOffset_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_worldUpObject_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_worldUpObject_Injected(IntPtr _unity_self, IntPtr value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useUpObject_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useUpObject_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceCountInternal_Injected(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSources_Injected(IntPtr _unity_self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcesInternal_Injected(IntPtr self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddSource_Injected(IntPtr _unity_self, [In] ref ConstraintSource source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveSourceInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourceInternal_Injected(IntPtr _unity_self, int index, out ConstraintSource ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourceInternal_Injected(IntPtr _unity_self, int index, [In] ref ConstraintSource source);
	}
	[MovedFrom("UnityEngine.Experimental.Animations")]
	[NativeHeader("Modules/Animation/Animator.h")]
	[NativeHeader("Modules/Animation/MuscleHandle.h")]
	public struct MuscleHandle
	{
		public HumanPartDof humanPartDof { get; private set; }

		public int dof { get; private set; }

		public string name => GetName();

		public static int muscleHandleCount => GetMuscleHandleCount();

		public MuscleHandle(BodyDof bodyDof)
		{
			humanPartDof = HumanPartDof.Body;
			dof = (int)bodyDof;
		}

		public MuscleHandle(HeadDof headDof)
		{
			humanPartDof = HumanPartDof.Head;
			dof = (int)headDof;
		}

		public MuscleHandle(HumanPartDof partDof, LegDof legDof)
		{
			if (partDof != HumanPartDof.LeftLeg && partDof != HumanPartDof.RightLeg)
			{
				throw new InvalidOperationException("Invalid HumanPartDof for a leg, please use either HumanPartDof.LeftLeg or HumanPartDof.RightLeg.");
			}
			humanPartDof = partDof;
			dof = (int)legDof;
		}

		public MuscleHandle(HumanPartDof partDof, ArmDof armDof)
		{
			if (partDof != HumanPartDof.LeftArm && partDof != HumanPartDof.RightArm)
			{
				throw new InvalidOperationException("Invalid HumanPartDof for an arm, please use either HumanPartDof.LeftArm or HumanPartDof.RightArm.");
			}
			humanPartDof = partDof;
			dof = (int)armDof;
		}

		public MuscleHandle(HumanPartDof partDof, FingerDof fingerDof)
		{
			if (partDof < HumanPartDof.LeftThumb || partDof > HumanPartDof.RightLittle)
			{
				throw new InvalidOperationException("Invalid HumanPartDof for a finger.");
			}
			humanPartDof = partDof;
			dof = (int)fingerDof;
		}

		public unsafe static void GetMuscleHandles([Out][NotNull] MuscleHandle[] muscleHandles)
		{
			if (muscleHandles == null)
			{
				ThrowHelper.ThrowArgumentNullException(muscleHandles, "muscleHandles");
			}
			BlittableArrayWrapper muscleHandles2 = default(BlittableArrayWrapper);
			try
			{
				fixed (MuscleHandle[] array = muscleHandles)
				{
					if (array.Length != 0)
					{
						muscleHandles2 = new BlittableArrayWrapper(Unsafe.AsPointer(ref array[0]), array.Length);
					}
					GetMuscleHandles_Injected(out muscleHandles2);
				}
			}
			finally
			{
				muscleHandles2.Unmarshal(ref array);
			}
		}

		private string GetName()
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				GetName_Injected(ref this, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetMuscleHandleCount();

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetMuscleHandles_Injected(out BlittableArrayWrapper muscleHandles);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetName_Injected(ref MuscleHandle _unity_self, out ManagedSpanWrapper ret);
	}
	[UsedByNativeCode]
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Modules/Animation/Constraints/ParentConstraint.h")]
	[NativeHeader("Modules/Animation/Constraints/Constraint.bindings.h")]
	public sealed class ParentConstraint : Behaviour, IConstraint, IConstraintInternal
	{
		public float weight
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_weight_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_weight_Injected(intPtr, value);
			}
		}

		public bool constraintActive
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_constraintActive_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_constraintActive_Injected(intPtr, value);
			}
		}

		public bool locked
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_locked_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_locked_Injected(intPtr, value);
			}
		}

		public int sourceCount => GetSourceCountInternal(this);

		public Vector3 translationAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_translationAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_translationAtRest_Injected(intPtr, ref value);
			}
		}

		public Vector3 rotationAtRest
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_rotationAtRest_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAtRest_Injected(intPtr, ref value);
			}
		}

		public unsafe Vector3[] translationOffsets
		{
			get
			{
				BlittableArrayWrapper ret = default(BlittableArrayWrapper);
				Vector3[] result;
				try
				{
					IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					get_translationOffsets_Injected(intPtr, out ret);
				}
				finally
				{
					Vector3[] array = default(Vector3[]);
					ret.Unmarshal(ref array);
					result = array;
				}
				return result;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				Span<Vector3> span = new Span<Vector3>(value);
				fixed (Vector3* begin = span)
				{
					ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
					set_translationOffsets_Injected(intPtr, ref value2);
				}
			}
		}

		public unsafe Vector3[] rotationOffsets
		{
			get
			{
				BlittableArrayWrapper ret = default(BlittableArrayWrapper);
				Vector3[] result;
				try
				{
					IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
					if (intPtr == (IntPtr)0)
					{
						ThrowHelper.ThrowNullReferenceException(this);
					}
					get_rotationOffsets_Injected(intPtr, out ret);
				}
				finally
				{
					Vector3[] array = default(Vector3[]);
					ret.Unmarshal(ref array);
					result = array;
				}
				return result;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				Span<Vector3> span = new Span<Vector3>(value);
				fixed (Vector3* begin = span)
				{
					ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
					set_rotationOffsets_Injected(intPtr, ref value2);
				}
			}
		}

		public Axis translationAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_translationAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_translationAxis_Injected(intPtr, value);
			}
		}

		public Axis rotationAxis
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_rotationAxis_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_rotationAxis_Injected(intPtr, value);
			}
		}

		private ParentConstraint()
		{
			Internal_Create(this);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Internal_Create([Writable] ParentConstraint self);

		[FreeFunction("ConstraintBindings::GetSourceCount")]
		private static int GetSourceCountInternal([NotNull] ParentConstraint self)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			return GetSourceCountInternal_Injected(intPtr);
		}

		public Vector3 GetTranslationOffset(int index)
		{
			ValidateSourceIndex(index);
			return GetTranslationOffsetInternal(index);
		}

		public void SetTranslationOffset(int index, Vector3 value)
		{
			ValidateSourceIndex(index);
			SetTranslationOffsetInternal(index, value);
		}

		[NativeName("GetTranslationOffset")]
		private Vector3 GetTranslationOffsetInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetTranslationOffsetInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		[NativeName("SetTranslationOffset")]
		private void SetTranslationOffsetInternal(int index, Vector3 value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTranslationOffsetInternal_Injected(intPtr, index, ref value);
		}

		public Vector3 GetRotationOffset(int index)
		{
			ValidateSourceIndex(index);
			return GetRotationOffsetInternal(index);
		}

		public void SetRotationOffset(int index, Vector3 value)
		{
			ValidateSourceIndex(index);
			SetRotationOffsetInternal(index, value);
		}

		[NativeName("GetRotationOffset")]
		private Vector3 GetRotationOffsetInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetRotationOffsetInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		[NativeName("SetRotationOffset")]
		private void SetRotationOffsetInternal(int index, Vector3 value)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetRotationOffsetInternal_Injected(intPtr, index, ref value);
		}

		private void ValidateSourceIndex(int index)
		{
			if (sourceCount == 0)
			{
				throw new InvalidOperationException("The ParentConstraint component has no sources.");
			}
			if (index < 0 || index >= sourceCount)
			{
				throw new ArgumentOutOfRangeException("index", $"Constraint source index {index} is out of bounds (0-{sourceCount}).");
			}
		}

		[FreeFunction(Name = "ConstraintBindings::GetSources", HasExplicitThis = true)]
		public void GetSources([NotNull] List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				ThrowHelper.ThrowArgumentNullException(sources, "sources");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSources_Injected(intPtr, sources);
		}

		public void SetSources(List<ConstraintSource> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			SetSourcesInternal(this, sources);
		}

		[FreeFunction("ConstraintBindings::SetSources", ThrowsException = true)]
		private static void SetSourcesInternal([NotNull] ParentConstraint self, List<ConstraintSource> sources)
		{
			if ((object)self == null)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(self);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowArgumentNullException(self, "self");
			}
			SetSourcesInternal_Injected(intPtr, sources);
		}

		public int AddSource(ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return AddSource_Injected(intPtr, ref source);
		}

		public void RemoveSource(int index)
		{
			ValidateSourceIndex(index);
			RemoveSourceInternal(index);
		}

		[NativeName("RemoveSource")]
		private void RemoveSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveSourceInternal_Injected(intPtr, index);
		}

		public ConstraintSource GetSource(int index)
		{
			ValidateSourceIndex(index);
			return GetSourceInternal(index);
		}

		[NativeName("GetSource")]
		private ConstraintSource GetSourceInternal(int index)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetSourceInternal_Injected(intPtr, index, out var ret);
			return ret;
		}

		public void SetSource(int index, ConstraintSource source)
		{
			ValidateSourceIndex(index);
			SetSourceInternal(index, source);
		}

		[NativeName("SetSource")]
		private void SetSourceInternal(int index, ConstraintSource source)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetSourceInternal_Injected(intPtr, index, ref source);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_weight_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_weight_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_constraintActive_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_constraintActive_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_locked_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_locked_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetSourceCountInternal_Injected(IntPtr self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_translationAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_translationAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationAtRest_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAtRest_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_translationOffsets_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_translationOffsets_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_rotationOffsets_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationOffsets_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Axis get_translationAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_translationAxis_Injected(IntPtr _unity_self, Axis value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Axis get_rotationAxis_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_rotationAxis_Injected(IntPtr _unity_self, Axis value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetTranslationOffsetInternal_Injected(IntPtr _unity_self, int index, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTranslationOffsetInternal_Injected(IntPtr _unity_self, int index, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetRotationOffsetInternal_Injected(IntPtr _unity_self, int index, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetRotationOffsetInternal_Injected(IntPtr _unity_self, int index, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSources_Injected(IntPtr _unity_self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourcesInternal_Injected(IntPtr self, List<ConstraintSource> sources);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int AddSource_Injected(IntPtr _unity_self, [In] ref ConstraintSource source);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveSourceInternal_Injected(IntPtr _unity_self, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetSourceInternal_Injected(IntPtr _unity_self, int index, out ConstraintSource ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetSourceInternal_Injected(IntPtr _unity_self, int index, [In] ref ConstraintSource source);
	}
}
