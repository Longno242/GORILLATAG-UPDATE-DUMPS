using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.XR;
using UnityEngine.XR.Management;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("meta.xr.mrutilitykit")]
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
				0, 0, 0, 5, 0, 0, 0, 107, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 99, 111, 114, 101,
				64, 53, 48, 51, 97, 55, 50, 99, 97, 53,
				52, 57, 54, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 69, 110, 118, 105, 114, 111, 110, 109,
				101, 110, 116, 68, 101, 112, 116, 104, 92, 69,
				110, 118, 105, 114, 111, 110, 109, 101, 110, 116,
				68, 101, 112, 116, 104, 77, 97, 110, 97, 103,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 105, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 99, 111, 114, 101, 64, 53, 48, 51, 97,
				55, 50, 99, 97, 53, 52, 57, 54, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 69, 110, 118,
				105, 114, 111, 110, 109, 101, 110, 116, 68, 101,
				112, 116, 104, 92, 69, 110, 118, 105, 114, 111,
				110, 109, 101, 110, 116, 68, 101, 112, 116, 104,
				85, 116, 105, 108, 115, 46, 99, 115
			},
			TypesData = new byte[305]
			{
				0, 0, 0, 0, 48, 77, 101, 116, 97, 46,
				88, 82, 46, 69, 110, 118, 105, 114, 111, 110,
				109, 101, 110, 116, 68, 101, 112, 116, 104, 124,
				69, 110, 118, 105, 114, 111, 110, 109, 101, 110,
				116, 68, 101, 112, 116, 104, 77, 97, 110, 97,
				103, 101, 114, 0, 0, 0, 0, 53, 77, 101,
				116, 97, 46, 88, 82, 46, 69, 110, 118, 105,
				114, 111, 110, 109, 101, 110, 116, 68, 101, 112,
				116, 104, 46, 69, 110, 118, 105, 114, 111, 110,
				109, 101, 110, 116, 68, 101, 112, 116, 104, 77,
				97, 110, 97, 103, 101, 114, 124, 77, 97, 115,
				107, 0, 0, 0, 0, 39, 77, 101, 116, 97,
				46, 88, 82, 46, 69, 110, 118, 105, 114, 111,
				110, 109, 101, 110, 116, 68, 101, 112, 116, 104,
				124, 73, 68, 101, 112, 116, 104, 80, 114, 111,
				118, 105, 100, 101, 114, 0, 0, 0, 0, 50,
				77, 101, 116, 97, 46, 88, 82, 46, 69, 110,
				118, 105, 114, 111, 110, 109, 101, 110, 116, 68,
				101, 112, 116, 104, 124, 68, 101, 112, 116, 104,
				80, 114, 111, 118, 105, 100, 101, 114, 78, 111,
				116, 83, 117, 112, 112, 111, 114, 116, 101, 100,
				0, 0, 0, 0, 39, 77, 101, 116, 97, 46,
				88, 82, 46, 69, 110, 118, 105, 114, 111, 110,
				109, 101, 110, 116, 68, 101, 112, 116, 104, 124,
				68, 101, 112, 116, 104, 70, 114, 97, 109, 101,
				68, 101, 115, 99, 0, 0, 0, 0, 46, 77,
				101, 116, 97, 46, 88, 82, 46, 69, 110, 118,
				105, 114, 111, 110, 109, 101, 110, 116, 68, 101,
				112, 116, 104, 124, 69, 110, 118, 105, 114, 111,
				110, 109, 101, 110, 116, 68, 101, 112, 116, 104,
				85, 116, 105, 108, 115
			},
			TotalFiles = 2,
			TotalTypes = 6,
			IsEditorOnly = false
		};
	}
}
namespace Meta.XR.EnvironmentDepth;

public class EnvironmentDepthManager : MonoBehaviour
{
	private class Mask
	{
		internal readonly Material _maskMaterial;

		private readonly RenderTexture _maskDepthRt;

		private readonly RenderTexture _maskedDepthTexture;

		private readonly CommandBuffer _maskCommandBuffer;

		private readonly Matrix4x4[] _mvpMatrices = new Matrix4x4[2];

		internal Mask(int width, int height, float bias)
		{
			Shader shader = Shader.Find("Meta/EnvironmentDepth/DepthMask");
			_maskMaterial = new Material(shader)
			{
				enableInstancing = true
			};
			_maskMaterial.SetFloat(MaskBiasID, bias);
			_maskDepthRt = new RenderTexture(width, height, GraphicsFormat.R16_UNorm, GraphicsFormat.D16_UNorm)
			{
				dimension = TextureDimension.Tex2DArray,
				volumeDepth = 2
			};
			_maskedDepthTexture = new RenderTexture(width, height, GraphicsFormat.R16_UNorm, GraphicsFormat.None)
			{
				dimension = TextureDimension.Tex2DArray,
				volumeDepth = 2,
				depth = 0
			};
			_maskCommandBuffer = new CommandBuffer();
		}

		internal RenderTexture ApplyMask(RenderTexture depthTexture, List<MeshFilter> meshFilters, Matrix4x4 trackingSpaceWorldToLocal, DepthFrameDesc[] frameDescriptors)
		{
			EnvironmentDepthUtils.CalculateDepthCameraMatrices(frameDescriptors[0], out var projMatrix, out var viewMatrix);
			EnvironmentDepthUtils.CalculateDepthCameraMatrices(frameDescriptors[1], out var projMatrix2, out var viewMatrix2);
			_maskCommandBuffer.SetRenderTarget(new RenderTargetIdentifier(_maskDepthRt, 0, CubemapFace.Unknown, -1), RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.DontCare);
			_maskCommandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.white);
			foreach (MeshFilter meshFilter in meshFilters)
			{
				if (meshFilter == null || meshFilter.sharedMesh == null)
				{
					UnityEngine.Debug.LogError("MeshFilter or sharedMesh is null.");
					continue;
				}
				_mvpMatrices[0] = GL.GetGPUProjectionMatrix(projMatrix, renderIntoTexture: true) * viewMatrix * trackingSpaceWorldToLocal * meshFilter.transform.localToWorldMatrix;
				_mvpMatrices[1] = GL.GetGPUProjectionMatrix(projMatrix2, renderIntoTexture: true) * viewMatrix2 * trackingSpaceWorldToLocal * meshFilter.transform.localToWorldMatrix;
				_maskCommandBuffer.SetGlobalMatrixArray(MvpMatricesID, _mvpMatrices);
				_maskCommandBuffer.DrawMeshInstancedProcedural(meshFilter.sharedMesh, 0, _maskMaterial, 0, 2);
			}
			_maskMaterial.SetTexture(DepthTextureID, depthTexture);
			_maskMaterial.SetTexture(MaskTextureID, _maskDepthRt);
			_maskCommandBuffer.SetRenderTarget(new RenderTargetIdentifier(_maskedDepthTexture, 0, CubemapFace.Unknown, -1), RenderBufferLoadAction.DontCare, RenderBufferStoreAction.Store, RenderBufferLoadAction.DontCare, RenderBufferStoreAction.DontCare);
			_maskCommandBuffer.DrawProcedural(Matrix4x4.identity, _maskMaterial, 1, MeshTopology.Triangles, 3, 2);
			Graphics.ExecuteCommandBuffer(_maskCommandBuffer);
			_maskCommandBuffer.Clear();
			return _maskedDepthTexture;
		}

		internal void Dispose()
		{
			UnityEngine.Object.Destroy(_maskMaterial);
			UnityEngine.Object.Destroy(_maskDepthRt);
			UnityEngine.Object.Destroy(_maskedDepthTexture);
			_maskCommandBuffer.Dispose();
		}
	}

	public const string HardOcclusionKeyword = "HARD_OCCLUSION";

	public const string SoftOcclusionKeyword = "SOFT_OCCLUSION";

	private const int numViews = 2;

	private static readonly int DepthTextureID = Shader.PropertyToID("_EnvironmentDepthTexture");

	private static readonly int ReprojectionMatricesID = Shader.PropertyToID("_EnvironmentDepthReprojectionMatrices");

	private static readonly int ZBufferParamsID = Shader.PropertyToID("_EnvironmentDepthZBufferParams");

	private static readonly int PreprocessedEnvironmentDepthTexture = Shader.PropertyToID("_PreprocessedEnvironmentDepthTexture");

	private static readonly int MvpMatricesID = Shader.PropertyToID("_DepthMask_MVP_Matrices");

	private static readonly int MaskTextureID = Shader.PropertyToID("_MaskTexture");

	private static readonly int MaskBiasID = Shader.PropertyToID("_MaskBias");

	[SerializeField]
	private OcclusionShadersMode _occlusionShadersMode = OcclusionShadersMode.SoftOcclusion;

	[SerializeField]
	[Tooltip("If set to true, hands will be removed from the depth texture.")]
	private bool _removeHands;

	[SerializeField]
	public Transform CustomTrackingSpace;

	private bool _isCameraRigCached;

	[SerializeField]
	[HideInInspector]
	private OVRCameraRig _cameraRig;

	private static IDepthProvider _provider;

	private bool _hasPermission;

	private Material _preprocessMaterial;

	[CanBeNull]
	private RenderTexture _preprocessTexture;

	private RenderTargetSetup _preprocessRenderTargetSetup;

	internal readonly DepthFrameDesc[] frameDescriptors = new DepthFrameDesc[2];

	private float _maskBias = 0.1f;

	private Mask _mask;

	private readonly Matrix4x4[] _reprojectionMatrices = new Matrix4x4[2];

	[field: SerializeField]
	public List<MeshFilter> MaskMeshFilters { get; set; } = new List<MeshFilter>();

	private static IDepthProvider provider => _provider ?? (_provider = CreateProvider());

	public static bool IsSupported => provider.IsSupported;

	public bool IsDepthAvailable { get; private set; }

	public OcclusionShadersMode OcclusionShadersMode
	{
		get
		{
			return _occlusionShadersMode;
		}
		set
		{
			if (_occlusionShadersMode != value)
			{
				_occlusionShadersMode = value;
				if (IsDepthAvailable)
				{
					SetOcclusionShaderKeywords(value);
				}
			}
		}
	}

	public bool RemoveHands
	{
		get
		{
			return _removeHands;
		}
		set
		{
			if (_removeHands != value)
			{
				_removeHands = value;
				if (base.enabled && IsSupported)
				{
					provider.RemoveHands = value;
				}
			}
		}
	}

	public float MaskBias
	{
		get
		{
			return _maskBias;
		}
		set
		{
			_maskBias = value;
			if (_mask != null)
			{
				_mask._maskMaterial.SetFloat(MaskBiasID, value);
			}
		}
	}

	internal event Action<RenderTexture> onDepthTextureUpdate;

	[NotNull]
	private static IDepthProvider CreateProvider()
	{
		if (XRGeneralSettings.Instance != null && XRGeneralSettings.Instance.Manager != null && XRGeneralSettings.Instance.Manager.activeLoader != null)
		{
			XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRDisplaySubsystem>();
		}
		UnityEngine.Debug.LogError("EnvironmentDepth is disabled. Please enable XR provider in 'Project Settings / XR Plug-in Management'.");
		return new DepthProviderNotSupported();
	}

	private void Awake()
	{
		if (IsSupported)
		{
			Shader shader = Shader.Find("Meta/EnvironmentDepth/Preprocessing");
			_preprocessMaterial = new Material(shader);
		}
	}

	private void OnEnable()
	{
		Application.onBeforeRender += OnBeforeRender;
		if (!IsSupported)
		{
			UnityEngine.Debug.LogError("Environment Depth is not supported. Please check EnvironmentDepthManager.IsSupported before enabling EnvironmentDepthManager.\nOpen 'Oculus -> Tools -> Project Setup Tool' to see requirements.\n");
			base.enabled = false;
			return;
		}
		_hasPermission = Permission.HasUserAuthorizedPermission("com.oculus.permission.USE_SCENE");
		if (_hasPermission)
		{
			provider.SetDepthEnabled(isEnabled: true, _removeHands);
		}
	}

	private void ResetDepthTextureIfAvailable()
	{
		if (IsDepthAvailable)
		{
			IsDepthAvailable = false;
			Shader.SetGlobalTexture(DepthTextureID, null);
			if (_occlusionShadersMode != OcclusionShadersMode.None)
			{
				SetOcclusionShaderKeywords(OcclusionShadersMode.None);
			}
		}
	}

	private void OnDisable()
	{
		Application.onBeforeRender -= OnBeforeRender;
		ResetDepthTextureIfAvailable();
		if (IsSupported && _hasPermission)
		{
			provider.SetDepthEnabled(isEnabled: false, removeHands: false);
		}
	}

	private void OnDestroy()
	{
		if (_preprocessMaterial != null)
		{
			UnityEngine.Object.Destroy(_preprocessMaterial);
		}
		if (_preprocessTexture != null)
		{
			UnityEngine.Object.Destroy(_preprocessTexture);
		}
		_mask?.Dispose();
	}

	private void OnBeforeRender()
	{
		if (!_hasPermission)
		{
			if (!Permission.HasUserAuthorizedPermission("com.oculus.permission.USE_SCENE"))
			{
				return;
			}
			_hasPermission = true;
			provider.SetDepthEnabled(isEnabled: true, _removeHands);
		}
		Matrix4x4 trackingSpaceWorldToLocalMatrix = GetTrackingSpaceWorldToLocalMatrix();
		TryFetchDepthTexture(trackingSpaceWorldToLocalMatrix);
		if (IsDepthAvailable)
		{
			DepthFrameDesc depthFrameDesc = frameDescriptors[0];
			Vector4 value = EnvironmentDepthUtils.ComputeNdcToLinearDepthParameters(depthFrameDesc.nearZ, depthFrameDesc.farZ);
			Shader.SetGlobalVector(ZBufferParamsID, value);
			for (int i = 0; i < 2; i++)
			{
				_reprojectionMatrices[i] = EnvironmentDepthUtils.CalculateReprojection(frameDescriptors[i]) * trackingSpaceWorldToLocalMatrix;
			}
			Shader.SetGlobalMatrixArray(ReprojectionMatricesID, _reprojectionMatrices);
		}
	}

	private void CacheCameraRig()
	{
		if (_cameraRig == null)
		{
			_cameraRig = UnityEngine.Object.FindObjectOfType<OVRCameraRig>();
		}
	}

	private static void SetOcclusionShaderKeywords(OcclusionShadersMode mode)
	{
		switch (mode)
		{
		case OcclusionShadersMode.HardOcclusion:
			Shader.DisableKeyword("SOFT_OCCLUSION");
			Shader.EnableKeyword("HARD_OCCLUSION");
			break;
		case OcclusionShadersMode.SoftOcclusion:
			Shader.DisableKeyword("HARD_OCCLUSION");
			Shader.EnableKeyword("SOFT_OCCLUSION");
			break;
		case OcclusionShadersMode.None:
			Shader.DisableKeyword("HARD_OCCLUSION");
			Shader.DisableKeyword("SOFT_OCCLUSION");
			break;
		default:
			UnityEngine.Debug.LogError(string.Format("Environment Depth: unknown {0} {1}", "OcclusionShadersMode", mode));
			break;
		}
	}

	private void TryFetchDepthTexture(Matrix4x4 trackingSpaceWorldToLocal)
	{
		if (!provider.TryGetUpdatedDepthTexture(out var depthTexture, frameDescriptors))
		{
			return;
		}
		if (depthTexture == null)
		{
			ResetDepthTextureIfAvailable();
			return;
		}
		this.onDepthTextureUpdate?.Invoke(depthTexture);
		if (MaskMeshFilters != null && MaskMeshFilters.Count > 0)
		{
			if (_mask == null)
			{
				_mask = new Mask(depthTexture.width, depthTexture.height, _maskBias);
			}
			depthTexture = _mask.ApplyMask(depthTexture, MaskMeshFilters, trackingSpaceWorldToLocal, frameDescriptors);
		}
		Shader.SetGlobalTexture(DepthTextureID, depthTexture);
		if (!IsDepthAvailable)
		{
			IsDepthAvailable = true;
			if (_occlusionShadersMode != OcclusionShadersMode.None)
			{
				SetOcclusionShaderKeywords(_occlusionShadersMode);
			}
		}
		if (_occlusionShadersMode == OcclusionShadersMode.SoftOcclusion)
		{
			PreprocessDepthTexture(depthTexture);
		}
	}

	internal Matrix4x4 GetTrackingSpaceWorldToLocalMatrix()
	{
		if (CustomTrackingSpace != null)
		{
			return CustomTrackingSpace.worldToLocalMatrix;
		}
		if (!_isCameraRigCached)
		{
			_isCameraRigCached = true;
			CacheCameraRig();
		}
		if (!(_cameraRig != null))
		{
			return Matrix4x4.identity;
		}
		return _cameraRig.trackingSpace.worldToLocalMatrix;
	}

	private void PreprocessDepthTexture(RenderTexture depthTexture)
	{
		if (_preprocessTexture == null)
		{
			_preprocessTexture = new RenderTexture(depthTexture.width, depthTexture.height, GraphicsFormat.R16G16B16A16_SFloat, GraphicsFormat.None)
			{
				dimension = TextureDimension.Tex2DArray,
				volumeDepth = 2,
				name = "_preprocessTexture",
				depth = 0
			};
			_preprocessTexture.Create();
			Shader.SetGlobalTexture(PreprocessedEnvironmentDepthTexture, _preprocessTexture);
			_preprocessRenderTargetSetup = new RenderTargetSetup
			{
				color = new RenderBuffer[1] { _preprocessTexture.colorBuffer },
				depth = _preprocessTexture.depthBuffer,
				depthSlice = -1,
				colorLoad = new RenderBufferLoadAction[1] { RenderBufferLoadAction.DontCare },
				colorStore = new RenderBufferStoreAction[1],
				depthLoad = RenderBufferLoadAction.DontCare,
				depthStore = RenderBufferStoreAction.DontCare,
				mipLevel = 0,
				cubemapFace = CubemapFace.Unknown
			};
		}
		Graphics.SetRenderTarget(_preprocessRenderTargetSetup);
		_preprocessMaterial.SetPass(0);
		Graphics.DrawProceduralNow(MeshTopology.Triangles, 3, 2);
	}

	[Conditional("UNITY_ASSERTIONS")]
	private static void Log(LogType type, string msg)
	{
		UnityEngine.Debug.unityLogger.Log(type, msg);
	}
}
internal interface IDepthProvider
{
	bool IsSupported { get; }

	bool RemoveHands { set; }

	void SetDepthEnabled(bool isEnabled, bool removeHands);

	bool TryGetUpdatedDepthTexture(out RenderTexture depthTexture, DepthFrameDesc[] frameDescriptors);
}
internal class DepthProviderNotSupported : IDepthProvider
{
	bool IDepthProvider.IsSupported => false;

	bool IDepthProvider.RemoveHands
	{
		set
		{
		}
	}

	void IDepthProvider.SetDepthEnabled(bool isEnabled, bool removeHands)
	{
	}

	bool IDepthProvider.TryGetUpdatedDepthTexture(out RenderTexture depthTexture, DepthFrameDesc[] frameDescriptors)
	{
		throw new NotSupportedException();
	}
}
internal struct DepthFrameDesc
{
	internal Vector3 createPoseLocation;

	internal Quaternion createPoseRotation;

	internal float fovLeftAngleTangent;

	internal float fovRightAngleTangent;

	internal float fovTopAngleTangent;

	internal float fovDownAngleTangent;

	internal float nearZ;

	internal float farZ;
}
public enum OcclusionShadersMode
{
	None,
	HardOcclusion,
	SoftOcclusion
}
internal static class EnvironmentDepthUtils
{
	private static readonly Vector3 _scalingVector3 = new Vector3(1f, 1f, -1f);

	internal static Vector4 ComputeNdcToLinearDepthParameters(float near, float far)
	{
		float x;
		float y;
		if (far < near || float.IsInfinity(far))
		{
			x = -2f * near;
			y = -1f;
		}
		else
		{
			x = -2f * far * near / (far - near);
			y = (0f - (far + near)) / (far - near);
		}
		return new Vector4(x, y, 0f, 0f);
	}

	internal static Matrix4x4 CalculateReprojection(DepthFrameDesc frameDesc)
	{
		CalculateDepthCameraMatrices(frameDesc, out var projMatrix, out var viewMatrix);
		return projMatrix * viewMatrix;
	}

	internal static void CalculateDepthCameraMatrices(DepthFrameDesc frameDesc, out Matrix4x4 projMatrix, out Matrix4x4 viewMatrix)
	{
		float fovLeftAngleTangent = frameDesc.fovLeftAngleTangent;
		float fovRightAngleTangent = frameDesc.fovRightAngleTangent;
		float fovDownAngleTangent = frameDesc.fovDownAngleTangent;
		float fovTopAngleTangent = frameDesc.fovTopAngleTangent;
		float nearZ = frameDesc.nearZ;
		float farZ = frameDesc.farZ;
		float m = 2f / (fovRightAngleTangent + fovLeftAngleTangent);
		float m2 = 2f / (fovTopAngleTangent + fovDownAngleTangent);
		float m3 = (fovRightAngleTangent - fovLeftAngleTangent) / (fovRightAngleTangent + fovLeftAngleTangent);
		float m4 = (fovTopAngleTangent - fovDownAngleTangent) / (fovTopAngleTangent + fovDownAngleTangent);
		float m5;
		float m6;
		if (float.IsInfinity(farZ))
		{
			m5 = -1f;
			m6 = -2f * nearZ;
		}
		else
		{
			m5 = (0f - (farZ + nearZ)) / (farZ - nearZ);
			m6 = (0f - 2f * farZ * nearZ) / (farZ - nearZ);
		}
		float m7 = -1f;
		projMatrix = new Matrix4x4
		{
			m00 = m,
			m01 = 0f,
			m02 = m3,
			m03 = 0f,
			m10 = 0f,
			m11 = m2,
			m12 = m4,
			m13 = 0f,
			m20 = 0f,
			m21 = 0f,
			m22 = m5,
			m23 = m6,
			m30 = 0f,
			m31 = 0f,
			m32 = m7,
			m33 = 0f
		};
		viewMatrix = Matrix4x4.TRS(frameDesc.createPoseLocation, frameDesc.createPoseRotation, _scalingVector3).inverse;
	}
}
