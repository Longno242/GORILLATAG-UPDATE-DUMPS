using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Meta.XR.BuildingBlocks;
using Meta.XR.Util;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Meta.XR.BuildingBlocks.Editor")]
[assembly: AssemblyVersion("0.0.0.0")]
public class AlertViewHUD : MonoBehaviour
{
	public enum MessageType
	{
		Info,
		Warning,
		Error
	}

	[Tooltip("Set -1 to show always.")]
	[SerializeField]
	internal int _hideAfterSec = 20;

	[SerializeField]
	internal bool _centerInCamera = true;

	[SerializeField]
	private GameObject _panel;

	[SerializeField]
	private Sprite _warningIcon;

	[SerializeField]
	private Sprite _errorIcon;

	[SerializeField]
	private Sprite _infoIcon;

	[SerializeField]
	private Text _messageTextField;

	[SerializeField]
	private Text _messageTypeTextField;

	[SerializeField]
	private Image _messageTypeIconField;

	private Transform _centerEyeTransform;

	private float _initialTime;

	private Vector3 _initialPosition;

	private Quaternion _initialRotation;

	private float _speed = 7f;

	private static AlertViewHUD Instance { get; set; }

	public int HideAfterSec
	{
		get
		{
			return _hideAfterSec;
		}
		set
		{
			_hideAfterSec = value;
		}
	}

	public bool CenterInCamera
	{
		get
		{
			return _centerInCamera;
		}
		set
		{
			_centerInCamera = value;
		}
	}

	private bool Hidden => !_panel.activeSelf;

	private void Awake()
	{
		Instance = this;
		_centerEyeTransform = UnityEngine.Object.FindObjectOfType<OVRCameraRig>()?.centerEyeAnchor;
		_initialTime = Time.time;
		_initialPosition = base.transform.position;
		_initialRotation = base.transform.rotation;
		Hide();
	}

	public static void PostMessage(string message, MessageType messageType = MessageType.Warning)
	{
		if (!(Instance == null))
		{
			Instance.Post(message, messageType);
		}
	}

	private void Post(string message, MessageType type)
	{
		switch (type)
		{
		case MessageType.Info:
			_messageTypeIconField.sprite = _infoIcon;
			_messageTypeTextField.text = "Info";
			break;
		case MessageType.Warning:
			_messageTypeIconField.sprite = _warningIcon;
			_messageTypeTextField.text = "Warning";
			break;
		case MessageType.Error:
			_messageTypeIconField.sprite = _errorIcon;
			_messageTypeTextField.text = "Error";
			break;
		}
		_messageTextField.text = message + "\n";
		Reset();
	}

	private void ClearMessage()
	{
		_messageTextField.text = "";
	}

	private void Update()
	{
		CalculateHideAfterMessage();
		FollowCamera();
	}

	private void CalculateHideAfterMessage()
	{
		if (HideAfterSec != -1 && !Hidden && Time.time - _initialTime >= (float)HideAfterSec)
		{
			Hide();
		}
	}

	private void Reset()
	{
		_initialTime = Time.time;
		_panel.SetActive(value: true);
	}

	private void Hide()
	{
		_panel.SetActive(value: false);
	}

	private void FollowCamera()
	{
		if (!(_centerEyeTransform == null) && !Hidden && CenterInCamera)
		{
			Vector3 b = _centerEyeTransform.TransformPoint(_initialPosition);
			Quaternion b2 = _centerEyeTransform.rotation * _initialRotation;
			Vector3 position = Vector3.Lerp(base.transform.position, b, Time.deltaTime * _speed);
			Quaternion rotation = Quaternion.Lerp(base.transform.rotation, b2, Time.deltaTime * _speed);
			base.transform.SetPositionAndRotation(position, rotation);
		}
	}
}
public class EnableUnpremultipliedAlpha : MonoBehaviour
{
	private void Start()
	{
		OVRManager.eyeFovPremultipliedAlphaModeEnabled = false;
	}
}
public class RoomMeshAnchor : MonoBehaviour
{
	private struct GetTriangleMeshCountsJob : IJob
	{
		public OVRSpace Space;

		[WriteOnly]
		public NativeArray<int> Results;

		public void Execute()
		{
			Results[0] = -1;
			Results[1] = -1;
			if (OVRPlugin.GetSpaceTriangleMeshCounts(Space, out var vertexCount, out var triangleCount))
			{
				Results[0] = vertexCount;
				Results[1] = triangleCount;
			}
		}
	}

	private struct GetTriangleMeshJob : IJob
	{
		public OVRSpace Space;

		[WriteOnly]
		public NativeArray<Vector3> Vertices;

		[WriteOnly]
		public NativeArray<int> Triangles;

		public void Execute()
		{
			OVRPlugin.GetSpaceTriangleMesh(Space, Vertices, Triangles);
		}
	}

	private struct PopulateMeshDataJob : IJob
	{
		[Unity.Collections.ReadOnly]
		public NativeArray<Vector3> Vertices;

		[Unity.Collections.ReadOnly]
		public NativeArray<int> Triangles;

		[WriteOnly]
		public Mesh.MeshData MeshData;

		public void Execute()
		{
			MeshData.SetVertexBufferParams(Vertices.Length, new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, 0), new VertexAttributeDescriptor(VertexAttribute.Normal, VertexAttributeFormat.Float32, 3, 1));
			NativeArray<Vector3> vertexData = MeshData.GetVertexData<Vector3>();
			for (int i = 0; i < vertexData.Length; i++)
			{
				Vector3 vector = Vertices[i];
				vertexData[i] = new Vector3(0f - vector.x, vector.y, vector.z);
			}
			MeshData.SetIndexBufferParams(Triangles.Length, IndexFormat.UInt32);
			NativeArray<int> indexData = MeshData.GetIndexData<int>();
			for (int j = 0; j < indexData.Length; j += 3)
			{
				indexData[j] = Triangles[j];
				indexData[j + 1] = Triangles[j + 2];
				indexData[j + 2] = Triangles[j + 1];
			}
			MeshData.subMeshCount = 1;
			MeshData.SetSubMesh(0, new SubMeshDescriptor(0, Triangles.Length));
		}
	}

	private struct BakeMeshJob : IJob
	{
		public int MeshID;

		public bool Convex;

		public void Execute()
		{
			Physics.BakeMesh(MeshID, Convex);
		}
	}

	private OVRAnchor _anchor;

	private static readonly Quaternion RotateY180 = Quaternion.Euler(0f, 180f, 0f);

	private OVRSemanticLabels _labels;

	private OVRTriangleMesh _triangleMeshComponent;

	private Mesh _mesh;

	private MeshFilter _meshFilter;

	public bool IsCompleted { get; private set; }

	private bool Valid => _anchor.Handle != 0;

	private bool IsComponentEnabled<T>() where T : struct, IOVRAnchorComponent<T>
	{
		if (_anchor.TryGetComponent<T>(out var component))
		{
			return component.IsEnabled;
		}
		return false;
	}

	private void Awake()
	{
		_mesh = new Mesh
		{
			name = "RoomMeshAnchor (anonymous)"
		};
		if (!TryGetComponent<MeshFilter>(out _meshFilter))
		{
			_meshFilter = base.gameObject.AddComponent<MeshFilter>();
		}
		_meshFilter.sharedMesh = _mesh;
	}

	internal async void Initialize(OVRAnchor anchor)
	{
		_anchor = anchor;
		if (TryUpdateTransform())
		{
			UnityEngine.Debug.Log(string.Format("[{0}][{1}] Initial transform set.", "RoomMeshAnchor", _anchor.Uuid), base.gameObject);
		}
		else
		{
			UnityEngine.Debug.LogWarning(string.Format("[{0}][{1}] {2} failed. The entity may have the wrong initial transform.", "RoomMeshAnchor", _anchor.Uuid, "TryLocateSpace"), base.gameObject);
		}
		if (!IsComponentEnabled<OVRSemanticLabels>())
		{
			_labels = await EnableComponent<OVRSemanticLabels>();
		}
		if (!IsComponentEnabled<OVRTriangleMesh>())
		{
			_triangleMeshComponent = await EnableComponent<OVRTriangleMesh>();
		}
		_ = _triangleMeshComponent;
		StartCoroutine(GenerateRoomMesh());
	}

	private IEnumerator GenerateRoomMesh()
	{
		int num;
		int num2;
		using (NativeArray<int> meshCountResults = new NativeArray<int>(2, Allocator.TempJob))
		{
			JobHandle job = new GetTriangleMeshCountsJob
			{
				Space = _anchor.Handle,
				Results = meshCountResults
			}.Schedule();
			while (!IsJobDone(job))
			{
				yield return null;
			}
			num = meshCountResults[0];
			num2 = meshCountResults[1];
		}
		if (num == -1)
		{
			IsCompleted = true;
			yield break;
		}
		NativeArray<Vector3> vertices = new NativeArray<Vector3>(num, Allocator.Persistent);
		NativeArray<int> triangles = new NativeArray<int>(num2 * 3, Allocator.Persistent);
		Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
		JobHandle dependsOn = new GetTriangleMeshJob
		{
			Space = _anchor.Handle,
			Vertices = vertices,
			Triangles = triangles
		}.Schedule();
		JobHandle inputDeps = new PopulateMeshDataJob
		{
			Vertices = vertices,
			Triangles = triangles,
			MeshData = meshDataArray[0]
		}.Schedule(dependsOn);
		JobHandle disposeVerticesJob = JobHandle.CombineDependencies(vertices.Dispose(inputDeps), triangles.Dispose(inputDeps));
		while (!IsJobDone(disposeVerticesJob))
		{
			yield return null;
		}
		Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, _mesh);
		_mesh.RecalculateNormals();
		_mesh.RecalculateBounds();
		if (TryGetComponent<MeshCollider>(out var collider))
		{
			JobHandle job = new BakeMeshJob
			{
				MeshID = _mesh.GetInstanceID(),
				Convex = collider.convex
			}.Schedule();
			while (!IsJobDone(job))
			{
				yield return null;
			}
			collider.sharedMesh = _mesh;
		}
		IsCompleted = true;
	}

	private async Task<T> EnableComponent<T>() where T : struct, IOVRAnchorComponent<T>
	{
		if (_anchor.TryGetComponent<T>(out var component))
		{
			await component.SetEnabledAsync(enable: true);
		}
		return component;
	}

	private bool TryUpdateTransform()
	{
		if (!Valid || !base.enabled || !IsComponentEnabled<OVRLocatable>())
		{
			return false;
		}
		if (!OVRPlugin.TryLocateSpace(_anchor.Handle, OVRPlugin.GetTrackingOriginType(), out var pose, out var locationFlags) || !locationFlags.IsOrientationValid() || !locationFlags.IsPositionValid())
		{
			return false;
		}
		OVRPose oVRPose = new OVRPose
		{
			position = pose.Position.FromFlippedZVector3f(),
			orientation = pose.Orientation.FromFlippedZQuatf() * RotateY180
		}.ToWorldSpacePose(Camera.main);
		base.transform.SetPositionAndRotation(oVRPose.position, oVRPose.orientation);
		return true;
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(_mesh);
	}

	private static bool IsJobDone(JobHandle job)
	{
		bool isCompleted = job.IsCompleted;
		if (isCompleted)
		{
			job.Complete();
		}
		return isCompleted;
	}
}
public class SharedSpatialAnchorCoreBuildingBlock : BuildingBlock
{
}
[Feature(Feature.Anchors)]
public class SharedSpatialAnchorErrorHandler : MonoBehaviour
{
	[Tooltip("Disables the message alerts in headset.")]
	public bool DisableRuntimeGUIAlerts;

	[SerializeField]
	private GameObject AlertViewHUDPrefab;

	private string cloudPermissionMsg = "Your headset uses on-device point cloud data to determine its position within your room. To expand your headset's capabilities and enable features like local multiplayer, you'll need to share point cloud data with Meta. You can turn off point cloud sharing anytime in Settings.\n\nSettings > Privacy > Device Permissions > Turn on \"Share Point Cloud Data\"";

	private void Awake()
	{
		if ((bool)AlertViewHUDPrefab)
		{
			UnityEngine.Object.Instantiate(AlertViewHUDPrefab);
		}
	}

	public void OnAnchorCreate(OVRSpatialAnchor _, OVRSpatialAnchor.OperationResult result)
	{
		switch (result)
		{
		case OVRSpatialAnchor.OperationResult.Failure_SpaceCloudStorageDisabled:
			LogWarning(cloudPermissionMsg);
			break;
		default:
			LogWarning("Failed to create the spatial anchor.");
			break;
		case OVRSpatialAnchor.OperationResult.Success:
			break;
		}
	}

	public void OnAnchorShare(List<OVRSpatialAnchor> _, OVRSpatialAnchor.OperationResult result)
	{
		switch (result)
		{
		case OVRSpatialAnchor.OperationResult.Failure_SpaceCloudStorageDisabled:
			LogWarning(cloudPermissionMsg);
			break;
		default:
			LogWarning("Failed to share the spatial anchor.");
			break;
		case OVRSpatialAnchor.OperationResult.Success:
			break;
		}
	}

	public void OnSharedSpatialAnchorLoad(List<OVRSpatialAnchor> loadedAnchors, OVRSpatialAnchor.OperationResult result)
	{
		if (result == OVRSpatialAnchor.OperationResult.Failure_SpaceCloudStorageDisabled)
		{
			LogWarning(cloudPermissionMsg);
		}
		else if (loadedAnchors == null || loadedAnchors.Count == 0)
		{
			LogWarning("Failed to load the spatial anchor(s).");
		}
	}

	public void OnAnchorEraseAll(OVRSpatialAnchor.OperationResult result)
	{
		if (result == OVRSpatialAnchor.OperationResult.Failure)
		{
			LogWarning("Failed to erase the spatial anchor(s).");
		}
	}

	public void OnAnchorErase(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
	{
		if (result == OVRSpatialAnchor.OperationResult.Failure)
		{
			LogWarning($"Failed to erase the spatial anchor with uuid: {anchor}");
		}
	}

	private void LogWarning(string msg)
	{
		if (!DisableRuntimeGUIAlerts)
		{
			AlertViewHUD.PostMessage(msg, AlertViewHUD.MessageType.Error);
		}
		UnityEngine.Debug.LogWarning("[SharedSpatialAnchorErrorHandler] " + msg);
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
			FilePathsData = new byte[2374]
			{
				0, 0, 0, 1, 0, 0, 0, 107, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 99, 111, 114, 101,
				64, 53, 48, 51, 97, 55, 50, 99, 97, 53,
				52, 57, 54, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 92, 65, 108, 101,
				114, 116, 86, 105, 101, 119, 72, 85, 68, 92,
				65, 108, 101, 114, 116, 86, 105, 101, 119, 72,
				85, 68, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 95, 92, 76, 105, 98, 114, 97, 114,
				121, 92, 80, 97, 99, 107, 97, 103, 101, 67,
				97, 99, 104, 101, 92, 99, 111, 109, 46, 109,
				101, 116, 97, 46, 120, 114, 46, 115, 100, 107,
				46, 99, 111, 114, 101, 64, 53, 48, 51, 97,
				55, 50, 99, 97, 53, 52, 57, 54, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 66, 117, 105,
				108, 100, 105, 110, 103, 66, 108, 111, 99, 107,
				115, 92, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 46, 99, 115, 0, 0,
				0, 2, 0, 0, 0, 136, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 109, 101, 116, 97, 46, 120, 114, 46,
				115, 100, 107, 46, 99, 111, 114, 101, 64, 53,
				48, 51, 97, 55, 50, 99, 97, 53, 52, 57,
				54, 92, 83, 99, 114, 105, 112, 116, 115, 92,
				66, 117, 105, 108, 100, 105, 110, 103, 66, 108,
				111, 99, 107, 115, 92, 67, 111, 110, 116, 114,
				111, 108, 108, 101, 114, 66, 117, 116, 116, 111,
				110, 115, 77, 97, 112, 112, 101, 114, 83, 99,
				114, 105, 112, 116, 115, 92, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 66, 117, 116, 116,
				111, 110, 115, 77, 97, 112, 112, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 123,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 99, 111,
				114, 101, 64, 53, 48, 51, 97, 55, 50, 99,
				97, 53, 52, 57, 54, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 115, 92, 80,
				97, 115, 115, 116, 104, 114, 111, 117, 103, 104,
				80, 114, 111, 106, 101, 99, 116, 105, 111, 110,
				83, 117, 114, 102, 97, 99, 101, 66, 117, 105,
				108, 100, 105, 110, 103, 66, 108, 111, 99, 107,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				126, 92, 76, 105, 98, 114, 97, 114, 121, 92,
				80, 97, 99, 107, 97, 103, 101, 67, 97, 99,
				104, 101, 92, 99, 111, 109, 46, 109, 101, 116,
				97, 46, 120, 114, 46, 115, 100, 107, 46, 99,
				111, 114, 101, 64, 53, 48, 51, 97, 55, 50,
				99, 97, 53, 52, 57, 54, 92, 83, 99, 114,
				105, 112, 116, 115, 92, 66, 117, 105, 108, 100,
				105, 110, 103, 66, 108, 111, 99, 107, 115, 92,
				80, 97, 115, 115, 116, 104, 114, 111, 117, 103,
				104, 87, 105, 110, 100, 111, 119, 92, 69, 110,
				97, 98, 108, 101, 85, 110, 112, 114, 101, 109,
				117, 108, 116, 105, 112, 108, 105, 101, 100, 65,
				108, 112, 104, 97, 46, 99, 115, 0, 0, 0,
				5, 0, 0, 0, 105, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 82, 111, 111, 109, 77, 101,
				115, 104, 92, 82, 111, 111, 109, 77, 101, 115,
				104, 65, 110, 99, 104, 111, 114, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 109, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 99, 111, 114, 101,
				64, 53, 48, 51, 97, 55, 50, 99, 97, 53,
				52, 57, 54, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 92, 82, 111, 111,
				109, 77, 101, 115, 104, 92, 82, 111, 111, 109,
				77, 101, 115, 104, 67, 111, 110, 116, 114, 111,
				108, 108, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 104, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 82, 111, 111, 109, 77, 101,
				115, 104, 92, 82, 111, 111, 109, 77, 101, 115,
				104, 69, 118, 101, 110, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 94, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 99, 111, 114, 101, 64,
				53, 48, 51, 97, 55, 50, 99, 97, 53, 52,
				57, 54, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 92, 82, 117, 110, 84,
				105, 109, 101, 85, 116, 105, 108, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 151, 92,
				76, 105, 98, 114, 97, 114, 121, 92, 80, 97,
				99, 107, 97, 103, 101, 67, 97, 99, 104, 101,
				92, 99, 111, 109, 46, 109, 101, 116, 97, 46,
				120, 114, 46, 115, 100, 107, 46, 99, 111, 114,
				101, 64, 53, 48, 51, 97, 55, 50, 99, 97,
				53, 52, 57, 54, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 115, 92, 83, 97,
				109, 112, 108, 101, 83, 112, 97, 116, 105, 97,
				108, 65, 110, 99, 104, 111, 114, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 83, 99, 114,
				105, 112, 116, 115, 92, 83, 112, 97, 116, 105,
				97, 108, 65, 110, 99, 104, 111, 114, 76, 111,
				97, 100, 101, 114, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 164, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 109, 101, 116, 97, 46, 120,
				114, 46, 115, 100, 107, 46, 99, 111, 114, 101,
				64, 53, 48, 51, 97, 55, 50, 99, 97, 53,
				52, 57, 54, 92, 83, 99, 114, 105, 112, 116,
				115, 92, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 92, 83, 97, 109,
				112, 108, 101, 83, 112, 97, 116, 105, 97, 108,
				65, 110, 99, 104, 111, 114, 67, 111, 110, 116,
				114, 111, 108, 108, 101, 114, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 112, 97, 116, 105, 97,
				108, 65, 110, 99, 104, 111, 114, 76, 111, 99,
				97, 108, 83, 116, 111, 114, 97, 103, 101, 77,
				97, 110, 97, 103, 101, 114, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 152,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 99, 111,
				114, 101, 64, 53, 48, 51, 97, 55, 50, 99,
				97, 53, 52, 57, 54, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 115, 92, 83,
				97, 109, 112, 108, 101, 83, 112, 97, 116, 105,
				97, 108, 65, 110, 99, 104, 111, 114, 67, 111,
				110, 116, 114, 111, 108, 108, 101, 114, 83, 99,
				114, 105, 112, 116, 115, 92, 83, 112, 97, 116,
				105, 97, 108, 65, 110, 99, 104, 111, 114, 83,
				112, 97, 119, 110, 101, 114, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 129,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 109, 101, 116, 97,
				46, 120, 114, 46, 115, 100, 107, 46, 99, 111,
				114, 101, 64, 53, 48, 51, 97, 55, 50, 99,
				97, 53, 52, 57, 54, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 115, 92, 83,
				104, 97, 114, 101, 100, 83, 112, 97, 116, 105,
				97, 108, 65, 110, 99, 104, 111, 114, 67, 111,
				114, 101, 92, 83, 104, 97, 114, 101, 100, 83,
				112, 97, 116, 105, 97, 108, 65, 110, 99, 104,
				111, 114, 67, 111, 114, 101, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 142, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 99, 111, 114, 101, 64,
				53, 48, 51, 97, 55, 50, 99, 97, 53, 52,
				57, 54, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 92, 83, 104, 97, 114,
				101, 100, 83, 112, 97, 116, 105, 97, 108, 65,
				110, 99, 104, 111, 114, 67, 111, 114, 101, 92,
				83, 104, 97, 114, 101, 100, 83, 112, 97, 116,
				105, 97, 108, 65, 110, 99, 104, 111, 114, 67,
				111, 114, 101, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 137, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 109, 101, 116, 97, 46, 120, 114,
				46, 115, 100, 107, 46, 99, 111, 114, 101, 64,
				53, 48, 51, 97, 55, 50, 99, 97, 53, 52,
				57, 54, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 92, 83, 104, 97, 114,
				101, 100, 83, 112, 97, 116, 105, 97, 108, 65,
				110, 99, 104, 111, 114, 67, 111, 114, 101, 92,
				83, 104, 97, 114, 101, 100, 83, 112, 97, 116,
				105, 97, 108, 65, 110, 99, 104, 111, 114, 69,
				114, 114, 111, 114, 72, 97, 110, 100, 108, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 145, 92, 76, 105, 98, 114, 97, 114, 121,
				92, 80, 97, 99, 107, 97, 103, 101, 67, 97,
				99, 104, 101, 92, 99, 111, 109, 46, 109, 101,
				116, 97, 46, 120, 114, 46, 115, 100, 107, 46,
				99, 111, 114, 101, 64, 53, 48, 51, 97, 55,
				50, 99, 97, 53, 52, 57, 54, 92, 83, 99,
				114, 105, 112, 116, 115, 92, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 115,
				92, 83, 112, 97, 116, 105, 97, 108, 65, 110,
				99, 104, 111, 114, 77, 97, 110, 97, 103, 101,
				114, 66, 108, 111, 99, 107, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 112, 97, 116, 105, 97,
				108, 65, 110, 99, 104, 111, 114, 67, 111, 114,
				101, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 91, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 109, 101, 116, 97, 46, 120, 114, 46, 115,
				100, 107, 46, 99, 111, 114, 101, 64, 53, 48,
				51, 97, 55, 50, 99, 97, 53, 52, 57, 54,
				92, 83, 99, 114, 105, 112, 116, 115, 92, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 115, 92, 84, 101, 108, 101, 109, 101,
				116, 114, 121, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 120, 92, 76, 105, 98, 114, 97,
				114, 121, 92, 80, 97, 99, 107, 97, 103, 101,
				67, 97, 99, 104, 101, 92, 99, 111, 109, 46,
				109, 101, 116, 97, 46, 120, 114, 46, 115, 100,
				107, 46, 99, 111, 114, 101, 64, 53, 48, 51,
				97, 55, 50, 99, 97, 53, 52, 57, 54, 92,
				83, 99, 114, 105, 112, 116, 115, 92, 66, 117,
				105, 108, 100, 105, 110, 103, 66, 108, 111, 99,
				107, 115, 92, 86, 97, 114, 105, 97, 110, 116,
				115, 92, 73, 110, 115, 116, 97, 108, 108, 97,
				116, 105, 111, 110, 82, 111, 117, 116, 105, 110,
				101, 67, 104, 101, 99, 107, 112, 111, 105, 110,
				116, 46, 99, 115
			},
			TypesData = new byte[1100]
			{
				0, 0, 0, 0, 13, 124, 65, 108, 101, 114,
				116, 86, 105, 101, 119, 72, 85, 68, 0, 0,
				0, 0, 36, 77, 101, 116, 97, 46, 88, 82,
				46, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 124, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 0,
				0, 0, 0, 46, 77, 101, 116, 97, 46, 88,
				82, 46, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 124, 67, 111, 110,
				116, 114, 111, 108, 108, 101, 114, 66, 117, 116,
				116, 111, 110, 115, 77, 97, 112, 112, 101, 114,
				0, 0, 0, 0, 64, 77, 101, 116, 97, 46,
				88, 82, 46, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 115, 46, 67, 111,
				110, 116, 114, 111, 108, 108, 101, 114, 66, 117,
				116, 116, 111, 110, 115, 77, 97, 112, 112, 101,
				114, 124, 66, 117, 116, 116, 111, 110, 67, 108,
				105, 99, 107, 65, 99, 116, 105, 111, 110, 0,
				0, 0, 0, 64, 77, 101, 116, 97, 46, 88,
				82, 46, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 124, 80, 97, 115,
				115, 116, 104, 114, 111, 117, 103, 104, 80, 114,
				111, 106, 101, 99, 116, 105, 111, 110, 83, 117,
				114, 102, 97, 99, 101, 66, 117, 105, 108, 100,
				105, 110, 103, 66, 108, 111, 99, 107, 0, 0,
				0, 0, 27, 124, 69, 110, 97, 98, 108, 101,
				85, 110, 112, 114, 101, 109, 117, 108, 116, 105,
				112, 108, 105, 101, 100, 65, 108, 112, 104, 97,
				0, 0, 0, 0, 15, 124, 82, 111, 111, 109,
				77, 101, 115, 104, 65, 110, 99, 104, 111, 114,
				0, 0, 0, 0, 39, 82, 111, 111, 109, 77,
				101, 115, 104, 65, 110, 99, 104, 111, 114, 124,
				71, 101, 116, 84, 114, 105, 97, 110, 103, 108,
				101, 77, 101, 115, 104, 67, 111, 117, 110, 116,
				115, 74, 111, 98, 0, 0, 0, 0, 33, 82,
				111, 111, 109, 77, 101, 115, 104, 65, 110, 99,
				104, 111, 114, 124, 71, 101, 116, 84, 114, 105,
				97, 110, 103, 108, 101, 77, 101, 115, 104, 74,
				111, 98, 0, 0, 0, 0, 34, 82, 111, 111,
				109, 77, 101, 115, 104, 65, 110, 99, 104, 111,
				114, 124, 80, 111, 112, 117, 108, 97, 116, 101,
				77, 101, 115, 104, 68, 97, 116, 97, 74, 111,
				98, 0, 0, 0, 0, 26, 82, 111, 111, 109,
				77, 101, 115, 104, 65, 110, 99, 104, 111, 114,
				124, 66, 97, 107, 101, 77, 101, 115, 104, 74,
				111, 98, 0, 0, 0, 0, 41, 77, 101, 116,
				97, 46, 88, 82, 46, 66, 117, 105, 108, 100,
				105, 110, 103, 66, 108, 111, 99, 107, 115, 124,
				82, 111, 111, 109, 77, 101, 115, 104, 67, 111,
				110, 116, 114, 111, 108, 108, 101, 114, 0, 0,
				0, 0, 36, 77, 101, 116, 97, 46, 88, 82,
				46, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 124, 82, 111, 111, 109,
				77, 101, 115, 104, 69, 118, 101, 110, 116, 0,
				0, 0, 0, 35, 77, 101, 116, 97, 46, 88,
				82, 46, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 124, 82, 117, 110,
				84, 105, 109, 101, 85, 116, 105, 108, 115, 0,
				0, 0, 0, 55, 77, 101, 116, 97, 46, 88,
				82, 46, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 124, 83, 112, 97,
				116, 105, 97, 108, 65, 110, 99, 104, 111, 114,
				76, 111, 97, 100, 101, 114, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 0,
				0, 0, 0, 68, 77, 101, 116, 97, 46, 88,
				82, 46, 66, 117, 105, 108, 100, 105, 110, 103,
				66, 108, 111, 99, 107, 115, 124, 83, 112, 97,
				116, 105, 97, 108, 65, 110, 99, 104, 111, 114,
				76, 111, 99, 97, 108, 83, 116, 111, 114, 97,
				103, 101, 77, 97, 110, 97, 103, 101, 114, 66,
				117, 105, 108, 100, 105, 110, 103, 66, 108, 111,
				99, 107, 0, 0, 0, 0, 56, 77, 101, 116,
				97, 46, 88, 82, 46, 66, 117, 105, 108, 100,
				105, 110, 103, 66, 108, 111, 99, 107, 115, 124,
				83, 112, 97, 116, 105, 97, 108, 65, 110, 99,
				104, 111, 114, 83, 112, 97, 119, 110, 101, 114,
				66, 117, 105, 108, 100, 105, 110, 103, 66, 108,
				111, 99, 107, 0, 0, 0, 0, 46, 77, 101,
				116, 97, 46, 88, 82, 46, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 115,
				124, 83, 104, 97, 114, 101, 100, 83, 112, 97,
				116, 105, 97, 108, 65, 110, 99, 104, 111, 114,
				67, 111, 114, 101, 0, 0, 0, 0, 37, 124,
				83, 104, 97, 114, 101, 100, 83, 112, 97, 116,
				105, 97, 108, 65, 110, 99, 104, 111, 114, 67,
				111, 114, 101, 66, 117, 105, 108, 100, 105, 110,
				103, 66, 108, 111, 99, 107, 0, 0, 0, 0,
				32, 124, 83, 104, 97, 114, 101, 100, 83, 112,
				97, 116, 105, 97, 108, 65, 110, 99, 104, 111,
				114, 69, 114, 114, 111, 114, 72, 97, 110, 100,
				108, 101, 114, 0, 0, 0, 0, 53, 77, 101,
				116, 97, 46, 88, 82, 46, 66, 117, 105, 108,
				100, 105, 110, 103, 66, 108, 111, 99, 107, 115,
				124, 83, 112, 97, 116, 105, 97, 108, 65, 110,
				99, 104, 111, 114, 67, 111, 114, 101, 66, 117,
				105, 108, 100, 105, 110, 103, 66, 108, 111, 99,
				107, 0, 0, 0, 0, 32, 77, 101, 116, 97,
				46, 88, 82, 46, 66, 117, 105, 108, 100, 105,
				110, 103, 66, 108, 111, 99, 107, 115, 124, 84,
				101, 108, 101, 109, 101, 116, 114, 121, 0, 0,
				0, 0, 52, 77, 101, 116, 97, 46, 88, 82,
				46, 66, 117, 105, 108, 100, 105, 110, 103, 66,
				108, 111, 99, 107, 115, 124, 73, 110, 115, 116,
				97, 108, 108, 97, 116, 105, 111, 110, 82, 111,
				117, 116, 105, 110, 101, 67, 104, 101, 99, 107,
				112, 111, 105, 110, 116, 0, 0, 0, 0, 40,
				77, 101, 116, 97, 46, 88, 82, 46, 66, 117,
				105, 108, 100, 105, 110, 103, 66, 108, 111, 99,
				107, 115, 124, 86, 97, 114, 105, 97, 110, 116,
				67, 104, 101, 99, 107, 112, 111, 105, 110, 116
			},
			TotalFiles = 18,
			TotalTypes = 24,
			IsEditorOnly = false
		};
	}
}
namespace Meta.XR.BuildingBlocks;

[HelpURL("https://developer.oculus.com/documentation/unity/bb-overview/")]
[DisallowMultipleComponent]
[ExecuteInEditMode]
public class BuildingBlock : MonoBehaviour
{
	[SerializeField]
	[OVRReadOnly]
	internal string blockId;

	[SerializeField]
	[HideInInspector]
	internal string instanceId = Guid.NewGuid().ToString();

	[SerializeField]
	[OVRReadOnly]
	internal int version = 1;

	[SerializeField]
	[HideInInspector]
	private InstallationRoutineCheckpoint installationRoutineCheckpoint;

	public string BlockId => blockId;

	public string InstanceId => instanceId;

	public int Version => version;

	public InstallationRoutineCheckpoint InstallationRoutineCheckpoint
	{
		get
		{
			return installationRoutineCheckpoint;
		}
		set
		{
			installationRoutineCheckpoint = value;
		}
	}

	private void Awake()
	{
		if (!Application.isPlaying && HasDuplicateInstanceId())
		{
			ResetInstanceId();
		}
	}

	private void ResetInstanceId()
	{
		instanceId = Guid.NewGuid().ToString();
	}

	private bool HasDuplicateInstanceId()
	{
		BuildingBlock[] array = UnityEngine.Object.FindObjectsByType<BuildingBlock>(FindObjectsSortMode.InstanceID);
		foreach (BuildingBlock buildingBlock in array)
		{
			if (buildingBlock != this && buildingBlock.InstanceId == InstanceId)
			{
				return true;
			}
		}
		return false;
	}

	private void Start()
	{
		OVRTelemetry.Start(163063912, 0, -1L).AddBlockInfo(this).SendIf(Application.isPlaying);
	}
}
public class ControllerButtonsMapper : MonoBehaviour
{
	[Serializable]
	public struct ButtonClickAction
	{
		public enum ButtonClickMode
		{
			OnButtonUp,
			OnButtonDown,
			OnButton
		}

		public string Title;

		public OVRInput.Button Button;

		public ButtonClickMode ButtonMode;

		public InputActionReference InputActionReference;

		public UnityEvent<InputAction.CallbackContext> CallbackWithContext;

		public UnityEvent Callback;

		public void OnCallbackWithContext(InputAction.CallbackContext callbackContext)
		{
			CallbackWithContext?.Invoke(callbackContext);
		}
	}

	[SerializeField]
	private List<ButtonClickAction> _buttonClickActions;

	internal const bool UseNewInputSystem = true;

	internal const bool UseLegacyInputSystem = false;

	public List<ButtonClickAction> ButtonClickActions
	{
		get
		{
			return _buttonClickActions;
		}
		set
		{
			_buttonClickActions = value;
		}
	}

	private void OnEnable()
	{
		foreach (ButtonClickAction buttonClickAction in ButtonClickActions)
		{
			if (!(buttonClickAction.InputActionReference == null))
			{
				buttonClickAction.InputActionReference.action.Enable();
				buttonClickAction.InputActionReference.action.performed += buttonClickAction.OnCallbackWithContext;
			}
		}
	}

	private void OnDisable()
	{
		foreach (ButtonClickAction buttonClickAction in ButtonClickActions)
		{
			if (!(buttonClickAction.InputActionReference == null))
			{
				buttonClickAction.InputActionReference.action.Disable();
				buttonClickAction.InputActionReference.action.performed -= buttonClickAction.OnCallbackWithContext;
			}
		}
	}

	private void Update()
	{
		foreach (ButtonClickAction buttonClickAction in ButtonClickActions)
		{
			if (IsActionTriggered(buttonClickAction))
			{
				buttonClickAction.Callback?.Invoke();
			}
		}
	}

	private static bool IsActionTriggered(ButtonClickAction buttonClickAction)
	{
		if (!IsLegacyInputActionTriggered(buttonClickAction.ButtonMode, buttonClickAction.Button))
		{
			return IsNewInputSystemActionTriggered(buttonClickAction);
		}
		return true;
	}

	private static bool IsLegacyInputActionTriggered(ButtonClickAction.ButtonClickMode buttonMode, OVRInput.Button button)
	{
		return false;
	}

	private static bool IsNewInputSystemActionTriggered(ButtonClickAction buttonClickAction)
	{
		if (buttonClickAction.InputActionReference != null)
		{
			return buttonClickAction.InputActionReference.action.triggered;
		}
		return false;
	}
}
public class PassthroughProjectionSurfaceBuildingBlock : MonoBehaviour
{
	public MeshFilter projectionObject;

	private void Start()
	{
		OVRPassthroughLayer[] array = UnityEngine.Object.FindObjectsByType<OVRPassthroughLayer>(FindObjectsSortMode.None);
		bool flag = false;
		OVRPassthroughLayer[] array2 = array;
		foreach (OVRPassthroughLayer oVRPassthroughLayer in array2)
		{
			if ((bool)oVRPassthroughLayer.GetComponent<BuildingBlock>())
			{
				flag = true;
				oVRPassthroughLayer.AddSurfaceGeometry(projectionObject.gameObject, updateTransform: true);
			}
		}
		if (flag)
		{
			projectionObject.GetComponent<MeshRenderer>().enabled = false;
			return;
		}
		throw new InvalidOperationException("A Building Block with the passthrough overlay layer was not found");
	}
}
public class RoomMeshController : MonoBehaviour
{
	[SerializeField]
	private GameObject _meshPrefab;

	private RoomMeshEvent _roomMeshEvent;

	private RoomMeshAnchor _roomMeshAnchor;

	private void Awake()
	{
		_roomMeshAnchor = GetComponent<RoomMeshAnchor>();
		_roomMeshEvent = UnityEngine.Object.FindObjectOfType<RoomMeshEvent>();
	}

	private IEnumerator Start()
	{
		float timeout = 10f;
		float startTime = Time.time;
		while (!OVRPermissionsRequester.IsPermissionGranted(OVRPermissionsRequester.Permission.Scene))
		{
			if (Time.time - startTime > timeout)
			{
				UnityEngine.Debug.LogWarning("[RoomMeshController] Spatial Data permission is required to load Room Mesh.");
				yield break;
			}
			yield return null;
		}
		yield return LoadRoomMesh();
		yield return UpdateVolume();
		if (_roomMeshAnchor == null)
		{
			yield break;
		}
		timeout = 3f;
		startTime = Time.time;
		while (!_roomMeshAnchor.IsCompleted)
		{
			if (Time.time - startTime > timeout)
			{
				UnityEngine.Debug.LogWarning("[RoomMeshController] Failed to create Room Mesh.");
				yield break;
			}
			yield return null;
		}
		_roomMeshEvent.OnRoomMeshLoadCompleted?.Invoke(_roomMeshAnchor.GetComponent<MeshFilter>());
	}

	private IEnumerator UpdateVolume()
	{
		if (!(_roomMeshAnchor == null))
		{
			while (!_roomMeshAnchor.IsCompleted)
			{
				yield return null;
			}
			MeshFilter component = _roomMeshAnchor.GetComponent<MeshFilter>();
			Mesh sharedMesh = component.sharedMesh;
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			sharedMesh.GetVertices(list);
			sharedMesh.GetTriangles(list2, 0);
			Color[] array = new Color[list2.Count];
			Vector3[] array2 = new Vector3[list2.Count];
			int[] array3 = new int[list2.Count];
			for (int i = 0; i < list2.Count; i++)
			{
				array[i] = new Color((i % 3 == 0) ? 1f : 0f, (i % 3 == 1) ? 1f : 0f, (i % 3 == 2) ? 1f : 0f);
				array2[i] = list[list2[i]];
				array3[i] = i;
			}
			Mesh mesh = new Mesh
			{
				indexFormat = IndexFormat.UInt32
			};
			mesh.SetVertices(array2);
			mesh.SetColors(array);
			mesh.SetIndices(array3, MeshTopology.Triangles, 0, calculateBounds: true, 0);
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			component.sharedMesh = mesh;
		}
	}

	private IEnumerator LoadRoomMesh()
	{
		List<OVRAnchor> anchors;
		using (new OVRObjectPool.ListScope<OVRAnchor>(out anchors))
		{
			OVRTask<OVRResult<List<OVRAnchor>, OVRAnchor.FetchResult>> task = OVRAnchor.FetchAnchorsAsync(anchors, new OVRAnchor.FetchOptions
			{
				SingleComponentType = typeof(OVRTriangleMesh)
			});
			while (task.IsPending)
			{
				yield return null;
			}
			if (anchors.Count == 0)
			{
				UnityEngine.Debug.LogWarning("[RoomMeshController] No RoomMesh available.");
				yield break;
			}
			foreach (OVRAnchor anchor in anchors)
			{
				if (!anchor.TryGetComponent<OVRLocatable>(out var component))
				{
					UnityEngine.Debug.LogWarning("[RoomMeshController] Failed to localize the room mesh anchor.");
					continue;
				}
				OVRTask<bool> localizeTask = component.SetEnabledAsync(enabled: true);
				while (localizeTask.IsPending)
				{
					yield return null;
				}
				InstantiateRoomMesh(anchor, _meshPrefab);
			}
		}
	}

	private void InstantiateRoomMesh(OVRAnchor anchor, GameObject prefab)
	{
		_roomMeshAnchor = UnityEngine.Object.Instantiate(prefab, Vector3.zero, Quaternion.identity).GetComponent<RoomMeshAnchor>();
		_roomMeshAnchor.gameObject.name = _meshPrefab.name;
		_roomMeshAnchor.gameObject.SetActive(value: true);
		_roomMeshAnchor.Initialize(anchor);
	}
}
public class RoomMeshEvent : MonoBehaviour
{
	public UnityEvent<MeshFilter> OnRoomMeshLoadCompleted;
}
public static class RunTimeUtils
{
	public static T GetInterfaceComponent<T>(this MonoBehaviour monoBehaviour) where T : class
	{
		MonoBehaviour[] components = monoBehaviour.GetComponents<MonoBehaviour>();
		for (int i = 0; i < components.Length; i++)
		{
			if (components[i] is T result)
			{
				return result;
			}
		}
		return null;
	}

	public static string GenerateRandomString(int size, bool includeLowercase = true, bool includeUppercase = true, bool includeNumeric = true, bool includeSpecial = false)
	{
		string text = "";
		if (includeLowercase)
		{
			text += "abcdefghijklmnopqrstuvwxyz";
		}
		if (includeUppercase)
		{
			text += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		}
		if (includeNumeric)
		{
			text += "0123456789";
		}
		if (includeSpecial)
		{
			text += "!@#$%^&*()_-+=[{]};:<>|./?";
		}
		char[] array = new char[size];
		for (int i = 0; i < size; i++)
		{
			array[i] = text[UnityEngine.Random.Range(0, text.Length)];
		}
		return new string(array);
	}
}
[RequireComponent(typeof(SpatialAnchorSpawnerBuildingBlock))]
public class SpatialAnchorLoaderBuildingBlock : MonoBehaviour
{
	private SpatialAnchorCoreBuildingBlock _spatialAnchorCore;

	private SpatialAnchorSpawnerBuildingBlock _spatialAnchorSpawner;

	private void Awake()
	{
		_spatialAnchorSpawner = GetComponent<SpatialAnchorSpawnerBuildingBlock>();
		_spatialAnchorCore = SpatialAnchorCoreBuildingBlock.GetFirstInstance();
	}

	public virtual void LoadAndInstantiateAnchors(List<Guid> uuids)
	{
		_spatialAnchorCore.LoadAndInstantiateAnchors(_spatialAnchorSpawner.AnchorPrefab, uuids);
	}

	public virtual void LoadAnchorsFromDefaultLocalStorage()
	{
		SpatialAnchorLocalStorageManagerBuildingBlock spatialAnchorLocalStorageManagerBuildingBlock = UnityEngine.Object.FindAnyObjectByType<SpatialAnchorLocalStorageManagerBuildingBlock>();
		if (!spatialAnchorLocalStorageManagerBuildingBlock)
		{
			UnityEngine.Debug.Log("[SpatialAnchorLocalStorageManagerBuildingBlock] component is missing.");
			return;
		}
		List<Guid> list;
		using (new OVRObjectPool.ListScope<Guid>(out list))
		{
			spatialAnchorLocalStorageManagerBuildingBlock.GetAnchorAnchorUuidFromLocalStorage(list);
			if (list.Count > 0)
			{
				_spatialAnchorCore.LoadAndInstantiateAnchors(_spatialAnchorSpawner.AnchorPrefab, list);
			}
		}
	}
}
public class SpatialAnchorLocalStorageManagerBuildingBlock : MonoBehaviour
{
	private SpatialAnchorCoreBuildingBlock _spatialAnchorCore;

	private const string NumUuidsPlayerPref = "numUuids";

	private void Start()
	{
		_spatialAnchorCore = SpatialAnchorCoreBuildingBlock.GetFirstInstance();
		_spatialAnchorCore.OnAnchorCreateCompleted.AddListener(SaveAnchorUuidToLocalStorage);
		_spatialAnchorCore.OnAnchorEraseCompleted.AddListener(RemoveAnchorFromLocalStorage);
	}

	internal void SaveAnchorUuidToLocalStorage(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
	{
		if (result == OVRSpatialAnchor.OperationResult.Success)
		{
			if (!PlayerPrefs.HasKey("numUuids"))
			{
				PlayerPrefs.SetInt("numUuids", 0);
			}
			int num = PlayerPrefs.GetInt("numUuids");
			PlayerPrefs.SetString("uuid" + num, anchor.Uuid.ToString());
			PlayerPrefs.SetInt("numUuids", ++num);
		}
	}

	internal void RemoveAnchorFromLocalStorage(OVRSpatialAnchor anchor, OVRSpatialAnchor.OperationResult result)
	{
		Guid uuid = anchor.Uuid;
		if (result == OVRSpatialAnchor.OperationResult.Failure)
		{
			return;
		}
		int num = PlayerPrefs.GetInt("numUuids", 0);
		for (int i = 0; i < num; i++)
		{
			string key = "uuid" + i;
			if (PlayerPrefs.GetString(key, "").Equals(uuid.ToString()))
			{
				string key2 = "uuid" + (num - 1);
				string value = PlayerPrefs.GetString(key2);
				PlayerPrefs.SetString(key, value);
				PlayerPrefs.DeleteKey(key2);
				num--;
				if (num < 0)
				{
					num = 0;
				}
				PlayerPrefs.SetInt("numUuids", num);
				break;
			}
		}
	}

	internal void GetAnchorAnchorUuidFromLocalStorage(List<Guid> uuids)
	{
		if (!PlayerPrefs.HasKey("numUuids"))
		{
			Reset();
			UnityEngine.Debug.Log("[SpatialAnchorLocalStorageManagerBuildingBlock] Anchor not found.");
			return;
		}
		uuids.Clear();
		int num = PlayerPrefs.GetInt("numUuids");
		for (int i = 0; i < num; i++)
		{
			string key = "uuid" + i;
			if (PlayerPrefs.HasKey(key))
			{
				string g = PlayerPrefs.GetString(key);
				uuids.Add(new Guid(g));
			}
		}
	}

	public void Reset()
	{
		PlayerPrefs.SetInt("numUuids", 0);
	}

	private void OnDestroy()
	{
		_spatialAnchorCore.OnAnchorCreateCompleted.RemoveAllListeners();
	}
}
public class SpatialAnchorSpawnerBuildingBlock : MonoBehaviour
{
	[Tooltip("A placeholder object to place in the anchor's position.")]
	[SerializeField]
	private GameObject _anchorPrefab;

	[Tooltip("Anchor prefab GameObject will follow the user's right hand.")]
	[SerializeField]
	private bool _followHand = true;

	private SpatialAnchorCoreBuildingBlock _spatialAnchorCore;

	private OVRCameraRig _cameraRig;

	private Transform _anchorPrefabTransform;

	private Vector3 _initialPosition;

	private Quaternion _initialRotation;

	public GameObject AnchorPrefab
	{
		get
		{
			return _anchorPrefab;
		}
		set
		{
			_anchorPrefab = value;
			if ((bool)_anchorPrefabTransform)
			{
				UnityEngine.Object.Destroy(_anchorPrefabTransform.gameObject);
			}
			_anchorPrefabTransform = UnityEngine.Object.Instantiate(AnchorPrefab).transform;
			FollowHand = _followHand;
		}
	}

	public bool FollowHand
	{
		get
		{
			return _followHand;
		}
		set
		{
			_followHand = value;
			if (_followHand)
			{
				_initialPosition = _anchorPrefabTransform.position;
				_initialRotation = _anchorPrefabTransform.rotation;
				_anchorPrefabTransform.parent = _cameraRig.rightControllerAnchor;
				_anchorPrefabTransform.localPosition = Vector3.zero;
				_anchorPrefabTransform.localRotation = Quaternion.identity;
			}
			else
			{
				_anchorPrefabTransform.parent = null;
				_anchorPrefabTransform.SetPositionAndRotation(_initialPosition, _initialRotation);
			}
		}
	}

	private void Awake()
	{
		_spatialAnchorCore = SpatialAnchorCoreBuildingBlock.GetFirstInstance();
		_cameraRig = UnityEngine.Object.FindAnyObjectByType<OVRCameraRig>();
		AnchorPrefab = _anchorPrefab;
		FollowHand = _followHand;
	}

	public void SpawnSpatialAnchor(Vector3 position, Quaternion rotation)
	{
		_spatialAnchorCore.InstantiateSpatialAnchor(AnchorPrefab, position, rotation);
	}

	internal void SpawnSpatialAnchor()
	{
		if (!FollowHand)
		{
			SpawnSpatialAnchor(AnchorPrefab.transform.position, AnchorPrefab.transform.rotation);
		}
		else
		{
			SpawnSpatialAnchor(_anchorPrefabTransform.position, _anchorPrefabTransform.rotation);
		}
	}
}
public class SharedSpatialAnchorCore : SpatialAnchorCoreBuildingBlock
{
	[SerializeField]
	private UnityEvent<List<OVRSpatialAnchor>, OVRSpatialAnchor.OperationResult> _onSpatialAnchorsShareCompleted;

	[SerializeField]
	private UnityEvent<List<OVRSpatialAnchor>, OVRAnchor.ShareResult> _onSpatialAnchorsShareToGroupCompleted;

	[SerializeField]
	private UnityEvent<List<OVRSpatialAnchor>, OVRSpatialAnchor.OperationResult> _onSharedSpatialAnchorsLoadCompleted;

	private Action<OVRSpatialAnchor.OperationResult, IEnumerable<OVRSpatialAnchor>> _onShareCompleted;

	private Action<OVRResult<OVRAnchor.ShareResult>, IEnumerable<OVRSpatialAnchor>> _onShareToGroupCompleted;

	public UnityEvent<List<OVRSpatialAnchor>, OVRSpatialAnchor.OperationResult> OnSpatialAnchorsShareCompleted
	{
		get
		{
			return _onSpatialAnchorsShareCompleted;
		}
		set
		{
			_onSpatialAnchorsShareCompleted = value;
		}
	}

	public UnityEvent<List<OVRSpatialAnchor>, OVRAnchor.ShareResult> OnSpatialAnchorsShareToGroupCompleted
	{
		get
		{
			return _onSpatialAnchorsShareToGroupCompleted;
		}
		set
		{
			_onSpatialAnchorsShareToGroupCompleted = value;
		}
	}

	public UnityEvent<List<OVRSpatialAnchor>, OVRSpatialAnchor.OperationResult> OnSharedSpatialAnchorsLoadCompleted
	{
		get
		{
			return _onSharedSpatialAnchorsLoadCompleted;
		}
		set
		{
			_onSharedSpatialAnchorsLoadCompleted = value;
		}
	}

	private void Start()
	{
		_onShareCompleted = (Action<OVRSpatialAnchor.OperationResult, IEnumerable<OVRSpatialAnchor>>)Delegate.Combine(_onShareCompleted, new Action<OVRSpatialAnchor.OperationResult, IEnumerable<OVRSpatialAnchor>>(OnShareCompleted));
		_onShareToGroupCompleted = (Action<OVRResult<OVRAnchor.ShareResult>, IEnumerable<OVRSpatialAnchor>>)Delegate.Combine(_onShareToGroupCompleted, new Action<OVRResult<OVRAnchor.ShareResult>, IEnumerable<OVRSpatialAnchor>>(OnShareToGroupCompleted));
	}

	public new async void InstantiateSpatialAnchor(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		if (prefab == null)
		{
			prefab = new GameObject("Shared Spatial Anchor");
		}
		OVRSpatialAnchor anchor = UnityEngine.Object.Instantiate(prefab, position, rotation).AddComponent<OVRSpatialAnchor>();
		await InitSpatialAnchor(anchor);
	}

	private async Task InitSpatialAnchor(OVRSpatialAnchor anchor)
	{
		await WaitForInit(anchor);
		if (base.Result == OVRSpatialAnchor.OperationResult.Failure)
		{
			base.OnAnchorCreateCompleted?.Invoke(anchor, base.Result);
			return;
		}
		await SaveAsync(anchor);
		if (base.Result.IsError())
		{
			base.OnAnchorCreateCompleted?.Invoke(anchor, base.Result);
		}
		else
		{
			base.OnAnchorCreateCompleted?.Invoke(anchor, base.Result);
		}
	}

	public override async void LoadAndInstantiateAnchors(GameObject prefab, List<Guid> uuids)
	{
		if (uuids == null)
		{
			throw new ArgumentNullException();
		}
		if (uuids.Count == 0)
		{
			throw new ArgumentException("[SpatialAnchorCoreBuildingBlock] Uuid list is empty.");
		}
		List<OVRSpatialAnchor.UnboundAnchor> list;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor.UnboundAnchor>(out list))
		{
			LoadSharedSpatialAnchorsRoutine(prefab, await OVRSpatialAnchor.LoadUnboundSharedAnchorsAsync(uuids, list));
		}
	}

	public async void LoadAndInstantiateAnchorsFromGroup(GameObject prefab, Guid groupUuid)
	{
		List<OVRSpatialAnchor.UnboundAnchor> list;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor.UnboundAnchor>(out list))
		{
			LoadSharedSpatialAnchorsRoutine(prefab, await OVRSpatialAnchor.LoadUnboundSharedAnchorsAsync(groupUuid, list));
		}
	}

	private async void LoadSharedSpatialAnchorsRoutine(GameObject prefab, OVRResult<List<OVRSpatialAnchor.UnboundAnchor>, OVRSpatialAnchor.OperationResult> result)
	{
		if (!result.Success)
		{
			UnityEngine.Debug.LogWarning(string.Format("[{0}] Failed to load the shared spatial anchors: {1}", "SharedSpatialAnchorCore", result.Status));
			OnSharedSpatialAnchorsLoadCompleted?.Invoke(null, result.Status);
			return;
		}
		List<OVRSpatialAnchor.UnboundAnchor> unboundAnchors = result.Value;
		if (unboundAnchors.Count == 0)
		{
			UnityEngine.Debug.LogWarning("[SharedSpatialAnchorCore] There's no shared spatial anchors being loaded.");
			OnSharedSpatialAnchorsLoadCompleted?.Invoke(null, result.Status);
			return;
		}
		List<OVRSpatialAnchor> loadedAnchors;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor>(out loadedAnchors))
		{
			for (int i = 0; i < unboundAnchors.Count; i++)
			{
				OVRSpatialAnchor.UnboundAnchor unboundAnchor = unboundAnchors[i];
				if (!unboundAnchor.Localized && !(await unboundAnchor.LocalizeAsync()))
				{
					UnityEngine.Debug.LogWarning(string.Format("[{0}] Failed to localize the anchor. Uuid: {1}", "SharedSpatialAnchorCore", unboundAnchor.Uuid));
					continue;
				}
				Pose pose;
				bool num = unboundAnchor.TryGetPose(out pose);
				if (!num)
				{
					UnityEngine.Debug.LogWarning("Unable to acquire initial anchor pose. Instantiating prefab at the origin.");
				}
				OVRSpatialAnchor oVRSpatialAnchor = (num ? UnityEngine.Object.Instantiate(prefab, pose.position, pose.rotation) : UnityEngine.Object.Instantiate(prefab)).AddComponent<OVRSpatialAnchor>();
				unboundAnchor.BindTo(oVRSpatialAnchor);
				loadedAnchors.Add(oVRSpatialAnchor);
			}
			OnSharedSpatialAnchorsLoadCompleted?.Invoke(new List<OVRSpatialAnchor>(loadedAnchors), result.Status);
		}
	}

	public void ShareSpatialAnchors(List<OVRSpatialAnchor> anchors, List<OVRSpaceUser> users)
	{
		if (anchors == null || users == null)
		{
			throw new ArgumentNullException();
		}
		if (anchors.Count == 0 || users.Count == 0)
		{
			throw new ArgumentException("[SharedSpatialAnchorCore] Anchors or users cannot be zero.");
		}
		OVRSpatialAnchor.ShareAsync(anchors, users).ContinueWith(_onShareCompleted, anchors);
	}

	public void ShareSpatialAnchors(List<OVRSpatialAnchor> anchors, Guid groupUuid)
	{
		if (anchors == null)
		{
			throw new ArgumentNullException();
		}
		if (anchors.Count == 0)
		{
			throw new ArgumentException("[SharedSpatialAnchorCore] Anchors list cannot be zero.");
		}
		OVRSpatialAnchor.ShareAsync(anchors, groupUuid).ContinueWith(_onShareToGroupCompleted, anchors);
	}

	private void OnShareCompleted(OVRSpatialAnchor.OperationResult result, IEnumerable<OVRSpatialAnchor> anchors)
	{
		if (result != OVRSpatialAnchor.OperationResult.Success)
		{
			OnSpatialAnchorsShareCompleted?.Invoke(null, result);
			return;
		}
		List<OVRSpatialAnchor> list;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor>(out list))
		{
			list.AddRange(anchors);
			OnSpatialAnchorsShareCompleted?.Invoke(new List<OVRSpatialAnchor>(list), OVRSpatialAnchor.OperationResult.Success);
		}
	}

	private void OnShareToGroupCompleted(OVRResult<OVRAnchor.ShareResult> result, IEnumerable<OVRSpatialAnchor> anchors)
	{
		if (!result.Success)
		{
			OnSpatialAnchorsShareToGroupCompleted?.Invoke(null, result.Status);
			return;
		}
		List<OVRSpatialAnchor> list;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor>(out list))
		{
			list.AddRange(anchors);
			OnSpatialAnchorsShareToGroupCompleted?.Invoke(new List<OVRSpatialAnchor>(list), result.Status);
		}
	}

	private void OnDestroy()
	{
		_onShareCompleted = (Action<OVRSpatialAnchor.OperationResult, IEnumerable<OVRSpatialAnchor>>)Delegate.Remove(_onShareCompleted, new Action<OVRSpatialAnchor.OperationResult, IEnumerable<OVRSpatialAnchor>>(OnShareCompleted));
		_onShareToGroupCompleted = (Action<OVRResult<OVRAnchor.ShareResult>, IEnumerable<OVRSpatialAnchor>>)Delegate.Remove(_onShareToGroupCompleted, new Action<OVRResult<OVRAnchor.ShareResult>, IEnumerable<OVRSpatialAnchor>>(OnShareToGroupCompleted));
	}
}
public class SpatialAnchorCoreBuildingBlock : MonoBehaviour
{
	[Header("# Events")]
	[SerializeField]
	private UnityEvent<OVRSpatialAnchor, OVRSpatialAnchor.OperationResult> _onAnchorCreateCompleted;

	[SerializeField]
	private UnityEvent<List<OVRSpatialAnchor>> _onAnchorsLoadCompleted;

	[SerializeField]
	private UnityEvent<OVRSpatialAnchor.OperationResult> _onAnchorsEraseAllCompleted;

	[SerializeField]
	private UnityEvent<OVRSpatialAnchor, OVRSpatialAnchor.OperationResult> _onAnchorEraseCompleted;

	public UnityEvent<OVRSpatialAnchor, OVRSpatialAnchor.OperationResult> OnAnchorCreateCompleted
	{
		get
		{
			return _onAnchorCreateCompleted;
		}
		set
		{
			_onAnchorCreateCompleted = value;
		}
	}

	public UnityEvent<List<OVRSpatialAnchor>> OnAnchorsLoadCompleted
	{
		get
		{
			return _onAnchorsLoadCompleted;
		}
		set
		{
			_onAnchorsLoadCompleted = value;
		}
	}

	public UnityEvent<OVRSpatialAnchor.OperationResult> OnAnchorsEraseAllCompleted
	{
		get
		{
			return _onAnchorsEraseAllCompleted;
		}
		set
		{
			_onAnchorsEraseAllCompleted = value;
		}
	}

	public UnityEvent<OVRSpatialAnchor, OVRSpatialAnchor.OperationResult> OnAnchorEraseCompleted
	{
		get
		{
			return _onAnchorEraseCompleted;
		}
		set
		{
			_onAnchorEraseCompleted = value;
		}
	}

	protected OVRSpatialAnchor.OperationResult Result { get; set; }

	public void InstantiateSpatialAnchor(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		if (prefab == null)
		{
			prefab = new GameObject("Spatial Anchor");
		}
		OVRSpatialAnchor anchor = UnityEngine.Object.Instantiate(prefab, position, rotation).AddComponent<OVRSpatialAnchor>();
		InitSpatialAnchorAsync(anchor);
	}

	private async void InitSpatialAnchorAsync(OVRSpatialAnchor anchor)
	{
		await WaitForInit(anchor);
		if (Result == OVRSpatialAnchor.OperationResult.Failure)
		{
			OnAnchorCreateCompleted?.Invoke(anchor, Result);
			return;
		}
		await SaveAsync(anchor);
		OnAnchorCreateCompleted?.Invoke(anchor, Result);
	}

	protected async Task WaitForInit(OVRSpatialAnchor anchor)
	{
		float timeoutThreshold = 5f;
		float startTime = Time.time;
		while ((bool)anchor && !anchor.Created)
		{
			if (Time.time - startTime >= timeoutThreshold)
			{
				UnityEngine.Debug.LogWarning("[SpatialAnchorCoreBuildingBlock] Failed to create the spatial anchor due to timeout.");
				Result = OVRSpatialAnchor.OperationResult.Failure;
				return;
			}
			await Task.Yield();
		}
		if (anchor == null)
		{
			UnityEngine.Debug.LogWarning("[SpatialAnchorCoreBuildingBlock] Failed to create the spatial anchor.");
			Result = OVRSpatialAnchor.OperationResult.Failure;
		}
	}

	protected async Task SaveAsync(OVRSpatialAnchor anchor)
	{
		List<OVRSpatialAnchor> list;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor>(out list))
		{
			list.Add(anchor);
			OVRResult<OVRAnchor.SaveResult> oVRResult = await OVRSpatialAnchor.SaveAnchorsAsync(list);
			if (!oVRResult.Success)
			{
				UnityEngine.Debug.LogWarning(string.Format("[{0}] Failed to save the spatial anchor with result {1}.", "SpatialAnchorCoreBuildingBlock", oVRResult));
				OVRSpatialAnchor.OperationResult result = ((oVRResult.Status != OVRAnchor.SaveResult.FailureInsufficientView) ? OVRSpatialAnchor.OperationResult.Failure : OVRSpatialAnchor.OperationResult.Failure_SpaceMappingInsufficient);
				Result = result;
			}
		}
	}

	public virtual void LoadAndInstantiateAnchors(GameObject prefab, List<Guid> uuids)
	{
		if (uuids == null)
		{
			throw new ArgumentNullException();
		}
		if (uuids.Count == 0)
		{
			UnityEngine.Debug.Log("[SpatialAnchorCoreBuildingBlock] Uuid list is empty.");
		}
		else
		{
			LoadAnchorsAsync(prefab, uuids);
		}
	}

	public void EraseAllAnchors()
	{
		if (OVRSpatialAnchor.SpatialAnchors.Count != 0)
		{
			EraseAnchorsAsync();
		}
	}

	public async void EraseAnchorByUuid(Guid uuid)
	{
		if (OVRSpatialAnchor.SpatialAnchors.Count != 0)
		{
			if (!OVRSpatialAnchor.SpatialAnchors.TryGetValue(uuid, out var value))
			{
				UnityEngine.Debug.LogWarning(string.Format("[{0}] Spatial anchor with uuid [{1}] not found.", "SpatialAnchorCoreBuildingBlock", uuid));
			}
			else
			{
				await EraseAnchorByUuidAsync(value);
			}
		}
	}

	protected async void LoadAnchorsAsync(GameObject prefab, IEnumerable<Guid> uuids)
	{
		List<OVRSpatialAnchor.UnboundAnchor> unboundAnchors;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor.UnboundAnchor>(out unboundAnchors))
		{
			OVRResult<List<OVRSpatialAnchor.UnboundAnchor>, OVRAnchor.FetchResult> oVRResult = await OVRSpatialAnchor.LoadUnboundAnchorsAsync(uuids, unboundAnchors);
			if (!oVRResult.Success || unboundAnchors.Count == 0)
			{
				UnityEngine.Debug.LogWarning(string.Format("[{0}] Failed to load the anchors: {1}", "SpatialAnchorCoreBuildingBlock", oVRResult.Status));
				return;
			}
			List<OVRSpatialAnchor> loadedAnchors;
			using (new OVRObjectPool.ListScope<OVRSpatialAnchor>(out loadedAnchors))
			{
				foreach (OVRSpatialAnchor.UnboundAnchor unboundAnchor in unboundAnchors)
				{
					if (!unboundAnchor.Localized && !(await unboundAnchor.LocalizeAsync()))
					{
						UnityEngine.Debug.LogWarning(string.Format("[{0}] Failed to localize the anchor. Uuid: {1}", "SpatialAnchorCoreBuildingBlock", unboundAnchor.Uuid));
						continue;
					}
					Pose pose;
					bool num = unboundAnchor.TryGetPose(out pose);
					if (!num)
					{
						UnityEngine.Debug.LogWarning("Unable to acquire initial anchor pose. Instantiating prefab at the origin.");
					}
					OVRSpatialAnchor oVRSpatialAnchor = (num ? UnityEngine.Object.Instantiate(prefab, pose.position, pose.rotation) : UnityEngine.Object.Instantiate(prefab)).AddComponent<OVRSpatialAnchor>();
					unboundAnchor.BindTo(oVRSpatialAnchor);
					loadedAnchors.Add(oVRSpatialAnchor);
				}
				OnAnchorsLoadCompleted?.Invoke(new List<OVRSpatialAnchor>(loadedAnchors));
			}
		}
	}

	private async void EraseAnchorsAsync()
	{
		List<OVRSpatialAnchor> anchorsToErase;
		using (new OVRObjectPool.ListScope<OVRSpatialAnchor>(out anchorsToErase))
		{
			foreach (OVRSpatialAnchor value in OVRSpatialAnchor.SpatialAnchors.Values)
			{
				anchorsToErase.Add(value);
			}
			for (int i = 0; i < anchorsToErase.Count; i++)
			{
				OVRSpatialAnchor anchor = anchorsToErase[i];
				await EraseAnchorByUuidAsync(anchor);
			}
			OVRSpatialAnchor.OperationResult arg = ((OVRSpatialAnchor.SpatialAnchors.Count != 0) ? OVRSpatialAnchor.OperationResult.Failure : OVRSpatialAnchor.OperationResult.Success);
			OnAnchorsEraseAllCompleted?.Invoke(arg);
		}
	}

	private async Task EraseAnchorByUuidAsync(OVRSpatialAnchor anchor)
	{
		if (!(await anchor.EraseAnchorAsync()).Success)
		{
			OnAnchorEraseCompleted?.Invoke(anchor, OVRSpatialAnchor.OperationResult.Failure);
			return;
		}
		UnityEngine.Object.Destroy(anchor.gameObject);
		if (OVRSpatialAnchor.SpatialAnchors.ContainsKey(anchor.Uuid))
		{
			await Task.Yield();
		}
		OnAnchorEraseCompleted?.Invoke(anchor, OVRSpatialAnchor.OperationResult.Success);
	}

	internal static SpatialAnchorCoreBuildingBlock GetFirstInstance()
	{
		SpatialAnchorCoreBuildingBlock[] array = UnityEngine.Object.FindObjectsByType<SpatialAnchorCoreBuildingBlock>(FindObjectsSortMode.None);
		foreach (SpatialAnchorCoreBuildingBlock spatialAnchorCoreBuildingBlock in array)
		{
			if (spatialAnchorCoreBuildingBlock != null && spatialAnchorCoreBuildingBlock.GetType() == typeof(SpatialAnchorCoreBuildingBlock))
			{
				return spatialAnchorCoreBuildingBlock;
			}
		}
		return null;
	}
}
internal static class Telemetry
{
	public static OVRTelemetryMarker AddBlockInfo(this OVRTelemetryMarker marker, BuildingBlock block)
	{
		return marker.AddAnnotation("BlockId", block.BlockId).AddAnnotation("InstanceId", block.InstanceId).AddAnnotation("BlockName", block.gameObject.name)
			.AddAnnotation("Version", block.Version.ToString())
			.AddBlockVariantInfo(block);
	}

	private static OVRTelemetryMarker AddBlockVariantInfo(this OVRTelemetryMarker marker, BuildingBlock block)
	{
		if (block.InstallationRoutineCheckpoint == null || string.IsNullOrEmpty(block.InstallationRoutineCheckpoint.InstallationRoutineId))
		{
			return marker;
		}
		return marker.AddAnnotation("InstallationRoutineId", block.InstallationRoutineCheckpoint.InstallationRoutineId).AddInstallationRoutineInfo(block.InstallationRoutineCheckpoint);
	}

	private static OVRTelemetryMarker AddInstallationRoutineInfo(this OVRTelemetryMarker marker, InstallationRoutineCheckpoint checkpoint)
	{
		if (checkpoint == null)
		{
			return marker;
		}
		List<string> list;
		using (new OVRObjectPool.ListScope<string>(out list))
		{
			foreach (VariantCheckpoint installationVariant in checkpoint.InstallationVariants)
			{
				if (installationVariant != null)
				{
					list.Add(installationVariant.MemberName + ":" + installationVariant.Value);
				}
			}
			if (list.Count > 0)
			{
				marker.AddAnnotation("InstallationRoutineData", string.Join(',', list));
			}
		}
		return marker;
	}

	public static OVRTelemetryMarker AddSceneInfo(this OVRTelemetryMarker marker, Scene scene)
	{
		long num = 0L;
		if (File.Exists(scene.path))
		{
			num = new FileInfo(scene.path).Length;
		}
		return marker.AddAnnotation("SceneSizeInB", num.ToString());
	}
}
[Serializable]
public class InstallationRoutineCheckpoint
{
	[SerializeField]
	[HideInInspector]
	private string _installationRoutineId;

	[SerializeField]
	[HideInInspector]
	private List<VariantCheckpoint> _installationVariants;

	public string InstallationRoutineId => _installationRoutineId;

	public List<VariantCheckpoint> InstallationVariants => _installationVariants;

	public InstallationRoutineCheckpoint(string installationRoutineId, List<VariantCheckpoint> installationVariants)
	{
		_installationRoutineId = installationRoutineId;
		_installationVariants = installationVariants;
	}
}
[Serializable]
public class VariantCheckpoint
{
	[SerializeField]
	protected string _memberName;

	[SerializeField]
	protected string _value;

	public string MemberName => _memberName;

	public string Value => _value;

	public VariantCheckpoint(string memberName, string value)
	{
		_memberName = memberName;
		_value = value;
	}
}
