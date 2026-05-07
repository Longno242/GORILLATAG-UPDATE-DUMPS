using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using DigitalOpus.MB.Core;
using UnityEngine;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
public class BakeTexturesAtRuntime : MonoBehaviour
{
	public GameObject target;

	private float elapsedTime;

	private MB3_TextureCombiner.CreateAtlasesCoroutineResult result = new MB3_TextureCombiner.CreateAtlasesCoroutineResult();

	public string GetShaderNameForPipeline()
	{
		if (MBVersion.DetectPipeline() == MBVersion.PipelineType.URP)
		{
			return "Universal Render Pipeline/Lit";
		}
		if (MBVersion.DetectPipeline() == MBVersion.PipelineType.HDRP)
		{
			return "HDRP/Lit";
		}
		return "Diffuse";
	}

	private void OnGUI()
	{
		GUILayout.Label("Time to bake textures: " + elapsedTime);
		if (GUILayout.Button("Combine textures & build combined mesh all at once"))
		{
			MB3_MeshBaker componentInChildren = target.GetComponentInChildren<MB3_MeshBaker>();
			MB3_TextureBaker component = target.GetComponent<MB3_TextureBaker>();
			((MB3_MeshCombinerSingle)componentInChildren.meshCombiner).SetMesh(null);
			component.textureBakeResults = ScriptableObject.CreateInstance<MB2_TextureBakeResults>();
			component.resultMaterial = new Material(Shader.Find(GetShaderNameForPipeline()));
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			component.CreateAtlases();
			elapsedTime = Time.realtimeSinceStartup - realtimeSinceStartup;
			componentInChildren.ClearMesh();
			componentInChildren.textureBakeResults = component.textureBakeResults;
			if (componentInChildren.AddDeleteGameObjects(component.GetObjectsToCombine().ToArray(), null, disableRendererInSource: true))
			{
				componentInChildren.Apply();
			}
		}
		if (GUILayout.Button("Combine textures & build combined mesh using coroutine"))
		{
			UnityEngine.Debug.Log("Starting to bake textures on frame " + Time.frameCount);
			MB3_MeshBaker componentInChildren2 = target.GetComponentInChildren<MB3_MeshBaker>();
			MB3_TextureBaker component2 = target.GetComponent<MB3_TextureBaker>();
			((MB3_MeshCombinerSingle)componentInChildren2.meshCombiner).SetMesh(null);
			component2.textureBakeResults = ScriptableObject.CreateInstance<MB2_TextureBakeResults>();
			component2.resultMaterial = new Material(Shader.Find(GetShaderNameForPipeline()));
			component2.onBuiltAtlasesSuccess = OnBuiltAtlasesSuccess;
			StartCoroutine(component2.CreateAtlasesCoroutine(null, result));
		}
	}

	private void OnBuiltAtlasesSuccess()
	{
		UnityEngine.Debug.Log("Calling success callback. baking meshes");
		MB3_MeshBaker componentInChildren = target.GetComponentInChildren<MB3_MeshBaker>();
		MB3_TextureBaker component = target.GetComponent<MB3_TextureBaker>();
		if (result.isFinished && result.success)
		{
			componentInChildren.ClearMesh();
			componentInChildren.textureBakeResults = component.textureBakeResults;
			if (componentInChildren.AddDeleteGameObjects(component.GetObjectsToCombine().ToArray(), null, disableRendererInSource: true))
			{
				componentInChildren.Apply();
			}
		}
		UnityEngine.Debug.Log("Completed baking textures on frame " + Time.frameCount);
	}
}
public class MB_BatchPrepareObjectsForDynamicBatchingDescription : MonoBehaviour
{
	private void OnGUI()
	{
		GUILayout.Label("This scene is set up to create a combined material and meshes with adjusted UVs so \n objects can share a material and be batched by Unity's static/dynamic batching.\n This scene has added a BatchPrefabBaker component to a Mesh and Material Baker which \n  can bake many prefabs (each of which can have several renderers) in one click.\n The batching tool accepts prefab assets instead of scene objects. \n");
	}
}
public class MB_SwapShirts : MonoBehaviour
{
	public MB3_MeshBaker meshBaker;

	public Renderer[] clothingAndBodyPartsBareTorso;

	public Renderer[] clothingAndBodyPartsBareTorsoDamagedArm;

	public Renderer[] clothingAndBodyPartsHoodie;

	private void Start()
	{
		GameObject[] array = new GameObject[clothingAndBodyPartsBareTorso.Length];
		for (int i = 0; i < clothingAndBodyPartsBareTorso.Length; i++)
		{
			array[i] = clothingAndBodyPartsBareTorso[i].gameObject;
		}
		meshBaker.ClearMesh();
		if (meshBaker.AddDeleteGameObjects(array, null, disableRendererInSource: true))
		{
			meshBaker.Apply();
		}
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Wear Hoodie"))
		{
			ChangeOutfit(clothingAndBodyPartsHoodie);
		}
		if (GUILayout.Button("Bare Torso"))
		{
			ChangeOutfit(clothingAndBodyPartsBareTorso);
		}
		if (GUILayout.Button("Damaged Arm"))
		{
			ChangeOutfit(clothingAndBodyPartsBareTorsoDamagedArm);
		}
	}

	private void ChangeOutfit(Renderer[] outfit)
	{
		List<GameObject> list = new List<GameObject>();
		foreach (GameObject item in meshBaker.meshCombiner.GetObjectsInCombined())
		{
			Renderer component = item.GetComponent<Renderer>();
			bool flag = false;
			for (int i = 0; i < outfit.Length; i++)
			{
				if (component == outfit[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(component.gameObject);
				UnityEngine.Debug.Log("Removing " + component.gameObject);
			}
		}
		List<GameObject> list2 = new List<GameObject>();
		for (int j = 0; j < outfit.Length; j++)
		{
			if (!meshBaker.meshCombiner.GetObjectsInCombined().Contains(outfit[j].gameObject))
			{
				list2.Add(outfit[j].gameObject);
				UnityEngine.Debug.Log("Adding " + outfit[j].gameObject);
			}
		}
		if (meshBaker.AddDeleteGameObjects(list2.ToArray(), list.ToArray(), disableRendererInSource: true))
		{
			meshBaker.Apply();
		}
	}
}
public class MB_PrepareObjectsForDynamicBatchingDescription : MonoBehaviour
{
	private void OnGUI()
	{
		GUILayout.Label("This scene creates a combined material and meshes with adjusted UVs so objects \n can share a material and be batched by Unity's static/dynamic batching.\n Output has been set to 'bakeMeshAssetsInPlace' on the Mesh Baker\n Position, Scale and Rotation will be baked into meshes so place them appropriately.\n Dynamic batching requires objects with uniform scale. You can fix non-uniform scale here\n After baking you need to duplicate your source prefab assets and replace the  \n meshes and materials with the generated ones.\n");
	}
}
public class MB_DynamicAddDeleteExample : MonoBehaviour
{
	public GameObject prefab;

	private List<GameObject> objsInCombined = new List<GameObject>();

	private MB3_MultiMeshBaker mbd;

	private GameObject[] objs;

	private float GaussianValue()
	{
		float num;
		float num3;
		do
		{
			num = 2f * Random.Range(0f, 1f) - 1f;
			float num2 = 2f * Random.Range(0f, 1f) - 1f;
			num3 = num * num + num2 * num2;
		}
		while (num3 >= 1f);
		num3 = Mathf.Sqrt(-2f * Mathf.Log(num3) / num3);
		return num * num3;
	}

	private void Start()
	{
		mbd = GetComponentInChildren<MB3_MultiMeshBaker>();
		int num = 10;
		GameObject[] array = new GameObject[num * num];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				GameObject gameObject = Object.Instantiate(prefab);
				array[i * num + j] = gameObject.GetComponentInChildren<MeshRenderer>().gameObject;
				float num2 = Random.Range(-4f, 4f);
				float num3 = Random.Range(-4f, 4f);
				gameObject.transform.position = new Vector3(3f * (float)i + num2, 0f, 3f * (float)j + num3);
				float y = Random.Range(0, 360);
				gameObject.transform.rotation = Quaternion.Euler(0f, y, 0f);
				Vector3 localScale = Vector3.one + Vector3.one * GaussianValue() * 0.15f;
				gameObject.transform.localScale = localScale;
				if ((i * num + j) % 3 == 0)
				{
					objsInCombined.Add(array[i * num + j]);
				}
			}
		}
		mbd.ClearMesh();
		if (mbd.AddDeleteGameObjects(array, null, disableRendererInSource: true))
		{
			mbd.Apply();
		}
		objs = objsInCombined.ToArray();
		StartCoroutine(largeNumber());
	}

	private IEnumerator largeNumber()
	{
		while (true)
		{
			yield return new WaitForSeconds(1.5f);
			if (mbd.AddDeleteGameObjects(null, objs, disableRendererInSource: true))
			{
				mbd.Apply();
			}
			yield return new WaitForSeconds(1.5f);
			if (mbd.AddDeleteGameObjects(objs, null, disableRendererInSource: true))
			{
				mbd.Apply();
			}
		}
	}

	private void OnGUI()
	{
		GUILayout.Label("Dynamically instantiates game objects. \nRepeatedly adds and removes some of them\n from the combined mesh.");
	}
}
public class MB_Example : MonoBehaviour
{
	public MB3_MeshBaker meshbaker;

	public GameObject[] objsToCombine;

	private void Start()
	{
		if (meshbaker.AddDeleteGameObjects(objsToCombine, null, disableRendererInSource: true))
		{
			meshbaker.Apply();
		}
	}

	private void LateUpdate()
	{
		if (meshbaker.UpdateGameObjects(objsToCombine))
		{
			meshbaker.Apply(triangles: false, vertices: true, normals: true, tangents: true, uvs: false, uv2: false, uv3: false, uv4: false, colors: false);
		}
	}

	private void OnGUI()
	{
		GUILayout.Label("Dynamically updates the vertices, normals and tangents in combined mesh every frame.\nThis is similar to dynamic batching. It is not recommended to do this every frame.\nAlso consider baking the mesh renderer objects into a skinned mesh renderer\nThe skinned mesh approach is faster for objects that need to move independently of each other every frame.");
	}
}
public class MB_ExampleMover : MonoBehaviour
{
	public int axis;

	private void Update()
	{
		Vector3 position = new Vector3(5f, 5f, 5f);
		position[axis] *= Mathf.Sin(Time.time);
		base.transform.position = position;
	}
}
public class MB_ExampleSkinnedMeshDescription : MonoBehaviour
{
	private void OnGUI()
	{
		GUILayout.Label("Mesh Renderer objects have been baked into a skinned mesh. Each source object\n is still in the scene (with renderer disabled) and becomes a bone. Any scripts, animations,\n or physics that affect the invisible source objects will be visible in the\nSkinned Mesh. This approach is more efficient than either dynamic batching or updating every frame \n for many small objects that constantly and independently move. \n With this approach pay attention to the SkinnedMeshRenderer Bounds and Animation Culling\nsettings. You may need to write your own script to manage/update these or your object may vanish or stop animating.\n You can update the combined mesh at runtime as objects are added and deleted from the scene.");
	}
}
[ExecuteInEditMode]
public class MB_MigrateMaterialsToDifferentPipeline : MonoBehaviour
{
}
public class MB_SkinnedMeshSceneController : MonoBehaviour
{
	public GameObject swordPrefab;

	public GameObject hatPrefab;

	public GameObject glassesPrefab;

	public GameObject workerPrefab;

	public GameObject targetCharacter;

	public MB3_MeshBaker skinnedMeshBaker;

	private GameObject swordInstance;

	private GameObject glassesInstance;

	private GameObject hatInstance;

	private void Start()
	{
		GameObject gameObject = Object.Instantiate(workerPrefab);
		gameObject.transform.position = new Vector3(1.31f, 0.985f, -0.25f);
		Animation component = gameObject.GetComponent<Animation>();
		component.wrapMode = WrapMode.Loop;
		component.cullingType = AnimationCullingType.AlwaysAnimate;
		component.Play("run");
		List<GameObject> objectsToCombine = skinnedMeshBaker.GetObjectsToCombine();
		GameObject[] array = new GameObject[objectsToCombine.Count + 1];
		objectsToCombine.CopyTo(array, 0);
		array[^1] = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
		skinnedMeshBaker.ClearMesh();
		skinnedMeshBaker.AddDeleteGameObjects(array, null, disableRendererInSource: true);
		skinnedMeshBaker.Apply();
	}

	private void OnGUI()
	{
		if (GUILayout.Button("Add/Remove Sword"))
		{
			if (swordInstance == null)
			{
				Transform parent = SearchHierarchyForBone(targetCharacter.transform, "RightHandAttachPoint");
				swordInstance = Object.Instantiate(swordPrefab);
				swordInstance.transform.parent = parent;
				swordInstance.transform.localPosition = Vector3.zero;
				swordInstance.transform.localRotation = Quaternion.identity;
				swordInstance.transform.localScale = Vector3.one;
				MeshRenderer componentInChildren = swordInstance.GetComponentInChildren<MeshRenderer>();
				componentInChildren.gameObject.name = "Sword";
				GameObject[] gos = new GameObject[1] { componentInChildren.gameObject };
				skinnedMeshBaker.AddDeleteGameObjects(gos, null, disableRendererInSource: true);
				skinnedMeshBaker.Apply();
				UnityEngine.Debug.Log("Done adding sword.");
			}
			else if (skinnedMeshBaker.CombinedMeshContains(swordInstance.GetComponentInChildren<MeshRenderer>().gameObject))
			{
				GameObject[] deleteGOs = new GameObject[1] { swordInstance.GetComponentInChildren<MeshRenderer>().gameObject };
				skinnedMeshBaker.AddDeleteGameObjects(null, deleteGOs, disableRendererInSource: true);
				skinnedMeshBaker.Apply();
				Object.Destroy(swordInstance);
				UnityEngine.Debug.Log("Done deleting sword.");
				swordInstance = null;
			}
		}
		if (GUILayout.Button("Add/Remove Hat"))
		{
			if (hatInstance == null)
			{
				Transform parent2 = SearchHierarchyForBone(targetCharacter.transform, "HeadAttachPoint");
				hatInstance = Object.Instantiate(hatPrefab);
				hatInstance.transform.parent = parent2;
				hatInstance.transform.localPosition = Vector3.zero;
				hatInstance.transform.localRotation = Quaternion.identity;
				hatInstance.transform.localScale = Vector3.one;
				MeshRenderer componentInChildren2 = hatInstance.GetComponentInChildren<MeshRenderer>();
				componentInChildren2.gameObject.name = "Hat";
				GameObject[] gos2 = new GameObject[1] { componentInChildren2.gameObject };
				skinnedMeshBaker.AddDeleteGameObjects(gos2, null, disableRendererInSource: true);
				skinnedMeshBaker.Apply();
				UnityEngine.Debug.Log("Done adding Hat");
			}
			else if (skinnedMeshBaker.CombinedMeshContains(hatInstance.GetComponentInChildren<MeshRenderer>().gameObject))
			{
				GameObject[] deleteGOs2 = new GameObject[1] { hatInstance.GetComponentInChildren<MeshRenderer>().gameObject };
				skinnedMeshBaker.AddDeleteGameObjects(null, deleteGOs2, disableRendererInSource: true);
				skinnedMeshBaker.Apply();
				Object.Destroy(hatInstance);
				UnityEngine.Debug.Log("Done deleting Hat");
				hatInstance = null;
			}
		}
		if (GUILayout.Button("Add/Remove Glasses"))
		{
			if (glassesInstance == null)
			{
				Transform parent3 = SearchHierarchyForBone(targetCharacter.transform, "NoseAttachPoint");
				glassesInstance = Object.Instantiate(glassesPrefab);
				glassesInstance.transform.parent = parent3;
				glassesInstance.transform.localPosition = Vector3.zero;
				glassesInstance.transform.localRotation = Quaternion.identity;
				glassesInstance.transform.localScale = Vector3.one;
				MeshRenderer componentInChildren3 = glassesInstance.GetComponentInChildren<MeshRenderer>();
				componentInChildren3.gameObject.name = "Glasses";
				GameObject[] gos3 = new GameObject[1] { componentInChildren3.gameObject };
				skinnedMeshBaker.AddDeleteGameObjects(gos3, null, disableRendererInSource: true);
				skinnedMeshBaker.Apply();
				UnityEngine.Debug.Log("Done adding glasses");
			}
			else if (skinnedMeshBaker.CombinedMeshContains(glassesInstance.GetComponentInChildren<MeshRenderer>().gameObject))
			{
				GameObject[] deleteGOs3 = new GameObject[1] { glassesInstance.GetComponentInChildren<MeshRenderer>().gameObject };
				skinnedMeshBaker.AddDeleteGameObjects(null, deleteGOs3, disableRendererInSource: true);
				skinnedMeshBaker.Apply();
				Object.Destroy(glassesInstance);
				glassesInstance = null;
				UnityEngine.Debug.Log("Done deleting glasses");
			}
		}
	}

	public Transform SearchHierarchyForBone(Transform current, string name)
	{
		if (current.name.Equals(name))
		{
			return current;
		}
		for (int i = 0; i < current.childCount; i++)
		{
			Transform transform = SearchHierarchyForBone(current.GetChild(i), name);
			if (transform != null)
			{
				return transform;
			}
		}
		return null;
	}
}
public class MB_SwitchBakedObjectsTexture : MonoBehaviour
{
	public MeshRenderer targetRenderer;

	public Material[] materials;

	public MB3_MeshBaker meshBaker;

	public void OnGUI()
	{
		GUILayout.Label("Press space to switch the material on one of the cubes. This scene reuses the Texture Bake Result from the SceneBasic example.");
	}

	public void Start()
	{
		meshBaker.ClearMesh();
		if (meshBaker.AddDeleteGameObjects(meshBaker.GetObjectsToCombine().ToArray(), null, disableRendererInSource: true))
		{
			meshBaker.Apply();
		}
	}

	public void Update()
	{
		if (!Input.GetKeyDown(KeyCode.Space))
		{
			return;
		}
		Material sharedMaterial = targetRenderer.sharedMaterial;
		int num = -1;
		for (int i = 0; i < materials.Length; i++)
		{
			if (materials[i] == sharedMaterial)
			{
				num = i;
			}
		}
		num++;
		if (num >= materials.Length)
		{
			num = 0;
		}
		if (num != -1)
		{
			targetRenderer.sharedMaterial = materials[num];
			UnityEngine.Debug.Log("Updating Material to: " + targetRenderer.sharedMaterial);
			GameObject[] gos = new GameObject[1] { targetRenderer.gameObject };
			if (meshBaker.UpdateGameObjects(gos, recalcBounds: false, updateVertices: false, updateNormals: false, updateTangents: false, updateUV: true, updateUV1: false, updateUV2: false, updateColors: false, updateSkinningInfo: false))
			{
				meshBaker.Apply();
			}
		}
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
			FilePathsData = new byte[1137]
			{
				0, 0, 0, 1, 0, 0, 0, 73, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 69, 120, 97, 109,
				112, 108, 101, 115, 92, 66, 97, 107, 101, 84,
				101, 120, 116, 117, 114, 101, 115, 65, 116, 82,
				117, 110, 116, 105, 109, 101, 92, 66, 97, 107,
				101, 84, 101, 120, 116, 117, 114, 101, 115, 65,
				116, 82, 117, 110, 116, 105, 109, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 119, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 69, 120, 97,
				109, 112, 108, 101, 115, 92, 66, 97, 116, 99,
				104, 80, 114, 101, 112, 97, 114, 101, 79, 98,
				106, 101, 99, 116, 115, 70, 111, 114, 68, 121,
				110, 97, 109, 105, 99, 66, 97, 116, 99, 104,
				105, 110, 103, 92, 77, 66, 95, 66, 97, 116,
				99, 104, 80, 114, 101, 112, 97, 114, 101, 79,
				98, 106, 101, 99, 116, 115, 70, 111, 114, 68,
				121, 110, 97, 109, 105, 99, 66, 97, 116, 99,
				104, 105, 110, 103, 68, 101, 115, 99, 114, 105,
				112, 116, 105, 111, 110, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 66, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 69, 120, 97, 109, 112, 108,
				101, 115, 92, 67, 104, 97, 114, 97, 99, 116,
				101, 114, 67, 117, 115, 116, 111, 109, 105, 122,
				97, 116, 105, 111, 110, 92, 77, 66, 95, 83,
				119, 97, 112, 83, 104, 105, 114, 116, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 71,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 69, 120,
				97, 109, 112, 108, 101, 115, 92, 72, 97, 99,
				107, 84, 101, 120, 116, 117, 114, 101, 65, 116,
				108, 97, 115, 92, 77, 66, 95, 67, 117, 115,
				116, 111, 109, 105, 122, 101, 67, 104, 97, 114,
				97, 99, 116, 101, 114, 71, 85, 73, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 71, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 69, 120, 97,
				109, 112, 108, 101, 115, 92, 72, 97, 99, 107,
				84, 101, 120, 116, 117, 114, 101, 65, 116, 108,
				97, 115, 92, 77, 66, 95, 84, 101, 120, 116,
				117, 114, 101, 66, 97, 107, 101, 114, 81, 117,
				105, 99, 107, 72, 97, 99, 107, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 109, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 69, 120, 97, 109,
				112, 108, 101, 115, 92, 80, 114, 101, 112, 97,
				114, 101, 79, 98, 106, 101, 99, 116, 115, 70,
				111, 114, 68, 121, 110, 97, 109, 105, 99, 66,
				97, 116, 99, 104, 105, 110, 103, 92, 77, 66,
				95, 80, 114, 101, 112, 97, 114, 101, 79, 98,
				106, 101, 99, 116, 115, 70, 111, 114, 68, 121,
				110, 97, 109, 105, 99, 66, 97, 116, 99, 104,
				105, 110, 103, 68, 101, 115, 99, 114, 105, 112,
				116, 105, 111, 110, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 78, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 69, 120, 97, 109, 112, 108, 101,
				115, 92, 83, 99, 101, 110, 101, 68, 121, 110,
				97, 109, 105, 99, 65, 100, 100, 68, 101, 108,
				101, 116, 101, 92, 77, 66, 95, 68, 121, 110,
				97, 109, 105, 99, 65, 100, 100, 68, 101, 108,
				101, 116, 101, 69, 120, 97, 109, 112, 108, 101,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				60, 92, 65, 115, 115, 101, 116, 115, 92, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 92, 69,
				120, 97, 109, 112, 108, 101, 115, 92, 83, 99,
				101, 110, 101, 82, 117, 110, 116, 105, 109, 101,
				69, 120, 97, 109, 112, 108, 101, 92, 77, 66,
				95, 69, 120, 97, 109, 112, 108, 101, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 65, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 69, 120, 97,
				109, 112, 108, 101, 115, 92, 83, 99, 101, 110,
				101, 82, 117, 110, 116, 105, 109, 101, 69, 120,
				97, 109, 112, 108, 101, 92, 77, 66, 95, 69,
				120, 97, 109, 112, 108, 101, 77, 111, 118, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 82, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				69, 120, 97, 109, 112, 108, 101, 115, 92, 83,
				99, 101, 110, 101, 82, 117, 110, 116, 105, 109,
				101, 69, 120, 97, 109, 112, 108, 101, 92, 77,
				66, 95, 69, 120, 97, 109, 112, 108, 101, 83,
				107, 105, 110, 110, 101, 100, 77, 101, 115, 104,
				68, 101, 115, 99, 114, 105, 112, 116, 105, 111,
				110, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 76, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				69, 120, 97, 109, 112, 108, 101, 115, 92, 83,
				99, 114, 105, 112, 116, 115, 92, 77, 66, 95,
				77, 105, 103, 114, 97, 116, 101, 77, 97, 116,
				101, 114, 105, 97, 108, 115, 84, 111, 68, 105,
				102, 102, 101, 114, 101, 110, 116, 80, 105, 112,
				101, 108, 105, 110, 101, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 79, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 69, 120, 97, 109, 112, 108,
				101, 115, 92, 83, 107, 105, 110, 110, 101, 100,
				77, 101, 115, 104, 82, 101, 110, 100, 101, 114,
				101, 114, 92, 77, 66, 95, 83, 107, 105, 110,
				110, 101, 100, 77, 101, 115, 104, 83, 99, 101,
				110, 101, 67, 111, 110, 116, 114, 111, 108, 108,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 84, 92, 65, 115, 115, 101, 116, 115,
				92, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				92, 69, 120, 97, 109, 112, 108, 101, 115, 92,
				83, 119, 105, 116, 99, 104, 66, 97, 107, 101,
				100, 79, 98, 106, 101, 99, 116, 115, 84, 101,
				120, 116, 117, 114, 101, 92, 77, 66, 95, 83,
				119, 105, 116, 99, 104, 66, 97, 107, 101, 100,
				79, 98, 106, 101, 99, 116, 115, 84, 101, 120,
				116, 117, 114, 101, 46, 99, 115
			},
			TypesData = new byte[515]
			{
				0, 0, 0, 0, 22, 124, 66, 97, 107, 101,
				84, 101, 120, 116, 117, 114, 101, 115, 65, 116,
				82, 117, 110, 116, 105, 109, 101, 0, 0, 0,
				0, 52, 124, 77, 66, 95, 66, 97, 116, 99,
				104, 80, 114, 101, 112, 97, 114, 101, 79, 98,
				106, 101, 99, 116, 115, 70, 111, 114, 68, 121,
				110, 97, 109, 105, 99, 66, 97, 116, 99, 104,
				105, 110, 103, 68, 101, 115, 99, 114, 105, 112,
				116, 105, 111, 110, 0, 0, 0, 0, 14, 124,
				77, 66, 95, 83, 119, 97, 112, 83, 104, 105,
				114, 116, 115, 0, 0, 0, 0, 65, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 95, 69, 120,
				97, 109, 112, 108, 101, 115, 95, 50, 48, 49,
				55, 46, 72, 97, 99, 107, 84, 101, 120, 116,
				117, 114, 101, 65, 116, 108, 97, 115, 124, 77,
				66, 95, 67, 117, 115, 116, 111, 109, 105, 122,
				101, 67, 104, 97, 114, 97, 99, 116, 101, 114,
				71, 85, 73, 0, 0, 0, 0, 65, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 95, 69, 120,
				97, 109, 112, 108, 101, 115, 95, 50, 48, 49,
				55, 46, 72, 97, 99, 107, 84, 101, 120, 116,
				117, 114, 101, 65, 116, 108, 97, 115, 124, 77,
				66, 95, 84, 101, 120, 116, 117, 114, 101, 66,
				97, 107, 101, 114, 81, 117, 105, 99, 107, 72,
				97, 99, 107, 0, 0, 0, 0, 47, 124, 77,
				66, 95, 80, 114, 101, 112, 97, 114, 101, 79,
				98, 106, 101, 99, 116, 115, 70, 111, 114, 68,
				121, 110, 97, 109, 105, 99, 66, 97, 116, 99,
				104, 105, 110, 103, 68, 101, 115, 99, 114, 105,
				112, 116, 105, 111, 110, 0, 0, 0, 0, 27,
				124, 77, 66, 95, 68, 121, 110, 97, 109, 105,
				99, 65, 100, 100, 68, 101, 108, 101, 116, 101,
				69, 120, 97, 109, 112, 108, 101, 0, 0, 0,
				0, 11, 124, 77, 66, 95, 69, 120, 97, 109,
				112, 108, 101, 0, 0, 0, 0, 16, 124, 77,
				66, 95, 69, 120, 97, 109, 112, 108, 101, 77,
				111, 118, 101, 114, 0, 0, 0, 0, 33, 124,
				77, 66, 95, 69, 120, 97, 109, 112, 108, 101,
				83, 107, 105, 110, 110, 101, 100, 77, 101, 115,
				104, 68, 101, 115, 99, 114, 105, 112, 116, 105,
				111, 110, 0, 0, 0, 0, 39, 124, 77, 66,
				95, 77, 105, 103, 114, 97, 116, 101, 77, 97,
				116, 101, 114, 105, 97, 108, 115, 84, 111, 68,
				105, 102, 102, 101, 114, 101, 110, 116, 80, 105,
				112, 101, 108, 105, 110, 101, 0, 0, 0, 0,
				30, 124, 77, 66, 95, 83, 107, 105, 110, 110,
				101, 100, 77, 101, 115, 104, 83, 99, 101, 110,
				101, 67, 111, 110, 116, 114, 111, 108, 108, 101,
				114, 0, 0, 0, 0, 29, 124, 77, 66, 95,
				83, 119, 105, 116, 99, 104, 66, 97, 107, 101,
				100, 79, 98, 106, 101, 99, 116, 115, 84, 101,
				120, 116, 117, 114, 101
			},
			TotalFiles = 13,
			TotalTypes = 13,
			IsEditorOnly = false
		};
	}
}
namespace MeshBaker_Examples_2017.HackTextureAtlas;

public class MB_CustomizeCharacterGUI : MonoBehaviour
{
	public Material[] sourceMaterials;

	public GameObject[] objectsToBeCombined;

	[Header("Mesh Baker Config")]
	public MB3_MeshBaker targetMeshBaker;

	private MB_TextureBakerQuickHack textureBakerQuickHack;

	private string colorTintPropertyName;

	private string albedoTexturePropertyName;

	private string shaderName;

	private void Start()
	{
		switch (MBVersion.DetectPipeline())
		{
		case MBVersion.PipelineType.Default:
			colorTintPropertyName = "_Color";
			albedoTexturePropertyName = "_MainTex";
			shaderName = "Standard";
			break;
		case MBVersion.PipelineType.URP:
			colorTintPropertyName = "_BaseColor";
			albedoTexturePropertyName = "_BaseMap";
			shaderName = "Universal Render Pipeline/Lit";
			break;
		case MBVersion.PipelineType.HDRP:
			colorTintPropertyName = "_BaseColor";
			albedoTexturePropertyName = "_BaseColorMap";
			shaderName = "HDRP/Lit";
			break;
		default:
			UnityEngine.Debug.LogError("Unknown pipeline type");
			break;
		}
		textureBakerQuickHack = GetComponent<MB_TextureBakerQuickHack>();
		UnityEngine.Debug.Log("Creating atlas using TextureBakerQuickHack method");
		textureBakerQuickHack.colorTintPropertyName = colorTintPropertyName;
		textureBakerQuickHack.albedoTexturePropertyName = albedoTexturePropertyName;
		textureBakerQuickHack.shaderName = shaderName;
		textureBakerQuickHack.CreateAtlas(sourceMaterials);
		UnityEngine.Debug.Log("Baking MeshBaker using TextureBakerQuickHack output");
		BakeMeshBaker();
	}

	private void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.Label("This example demonstrates how to create\r\nsolid-color-rectangle texture atlases at\r\nruntime for character customization. This\r\nis MUCH faster and more flexible than using\r\nthe full TextureBaker. These atlases can be\r\nused at runtime with a Mesh Baker.\r\n".ToString());
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Hoof Color");
		if (GUILayout.Button("Red"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[0], Color.red);
		}
		if (GUILayout.Button("Green"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[0], Color.green);
		}
		if (GUILayout.Button("Blue"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[0], Color.blue);
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Body Color");
		if (GUILayout.Button("Red"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[1], Color.red);
		}
		if (GUILayout.Button("Green"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[1], Color.green);
		}
		if (GUILayout.Button("Blue"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[1], Color.blue);
		}
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Horns Color");
		if (GUILayout.Button("Red"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[2], Color.red);
		}
		if (GUILayout.Button("Green"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[2], Color.green);
		}
		if (GUILayout.Button("Blue"))
		{
			SetColorInMaterialBakeResultAndBakeMeshBaker(sourceMaterials[2], Color.blue);
		}
		GUILayout.EndHorizontal();
	}

	private void SetColorInMaterialBakeResultAndBakeMeshBaker(Material bodyPartMaterial, Color color)
	{
		UnityEngine.Debug.Log("Changing color of material " + bodyPartMaterial?.ToString() + " used in atlas generation");
		bodyPartMaterial.SetColor(colorTintPropertyName, color);
		UnityEngine.Debug.Log("Creating atlas using TextureBakerQuickHack method");
		textureBakerQuickHack.CreateAtlas(sourceMaterials);
		UnityEngine.Debug.Log("Baking MeshBaker using TextureBakerQuickHack output");
		BakeMeshBaker();
	}

	[ContextMenu("Bake Mesh Baker")]
	private void BakeMeshBaker()
	{
		targetMeshBaker.textureBakeResults = textureBakerQuickHack.materialBakeResult;
		targetMeshBaker.ClearMesh();
		if (targetMeshBaker.AddDeleteGameObjects(objectsToBeCombined, null, disableRendererInSource: true))
		{
			targetMeshBaker.Apply();
		}
	}
}
public class MB_TextureBakerQuickHack : MonoBehaviour
{
	[Header("Hack Atlas Generation")]
	public string colorTintPropertyName;

	public string albedoTexturePropertyName;

	public string shaderName;

	public Material[] sourceMaterials;

	[Space(20f)]
	[Header("Generated Output")]
	public MB2_TextureBakeResults materialBakeResult;

	public Material atlasMaterial;

	public Texture2D atlasTexture;

	[ContextMenu("Generate Material Bake Result")]
	public void CreateAtlas(Material[] passedInSourceMaterials)
	{
		UnityEngine.Debug.Log("Validating source materials");
		bool flag = true;
		if (new HashSet<Material>(passedInSourceMaterials).Count != passedInSourceMaterials.Length)
		{
			UnityEngine.Debug.LogError("Source materials are not unique");
			flag = false;
		}
		if (passedInSourceMaterials.Length == 0)
		{
			UnityEngine.Debug.LogError("No source materials were passed in");
			flag = false;
		}
		if (string.IsNullOrEmpty(colorTintPropertyName))
		{
			UnityEngine.Debug.LogError("ColorTintProperty is not set");
			flag = false;
		}
		sourceMaterials = new Material[passedInSourceMaterials.Length];
		for (int i = 0; i < passedInSourceMaterials.Length; i++)
		{
			if (passedInSourceMaterials[i] == null)
			{
				UnityEngine.Debug.LogError("Source material " + i + " is null");
				flag = false;
			}
			if (!passedInSourceMaterials[i].HasProperty(colorTintPropertyName))
			{
				UnityEngine.Debug.LogError("Source material " + i + " does not have the colorTint property");
				flag = false;
			}
			sourceMaterials[i] = passedInSourceMaterials[i];
			sourceMaterials[i].shader = Shader.Find(shaderName);
		}
		if (!flag)
		{
			UnityEngine.Debug.LogError("Some validation of the source materials failed and the atlas was not generated.");
			return;
		}
		int num = 2;
		int num2 = 8;
		bool linear = MBVersion.GetProjectColorSpace() == ColorSpace.Linear;
		Texture2D[] array = new Texture2D[sourceMaterials.Length];
		StringBuilder stringBuilder = new StringBuilder("Collecting color tints from source materials: \n");
		Color[] array2 = new Color[num2 * num2];
		for (int j = 0; j < sourceMaterials.Length; j++)
		{
			Material material = sourceMaterials[j];
			Color color = material.GetColor(colorTintPropertyName);
			string[] obj = new string[5] { "Material: ", material.name, " - colorTint: ", null, null };
			Color color2 = color;
			obj[3] = color2.ToString();
			obj[4] = "\n";
			stringBuilder.Append(string.Concat(obj));
			Texture2D texture2D = (array[j] = new Texture2D(num2, num2, TextureFormat.ARGB32, mipChain: false, linear));
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = color;
			}
			texture2D.SetPixels(array2);
			texture2D.Apply();
		}
		UnityEngine.Debug.Log(stringBuilder);
		UnityEngine.Debug.Log("Calculating the atlas dimensions");
		int num3 = (int)Mathf.Ceil(Mathf.Sqrt(sourceMaterials.Length)) * num2;
		UnityEngine.Debug.Log("Creating atlas for " + sourceMaterials.Length + " textures");
		atlasTexture = new Texture2D(num3, num3, TextureFormat.ARGB32, mipChain: false, linear);
		Rect[] array3 = atlasTexture.PackTextures(array, 0, num3);
		UnityEngine.Debug.Log("Atlas size: w:" + atlasTexture.width + "  h:" + atlasTexture.height + "  numTex: " + array.Length + " (" + num2 + "x" + num2 + " each)");
		atlasTexture.filterMode = FilterMode.Point;
		atlasMaterial = new Material(Shader.Find(shaderName));
		atlasMaterial.SetTexture(albedoTexturePropertyName, atlasTexture);
		atlasMaterial.SetColor(colorTintPropertyName, Color.white);
		StringBuilder stringBuilder2 = new StringBuilder("Creating MB2_TextureBakeResult for storing atlas rectangle information: \n");
		for (int l = 0; l < array.Length; l++)
		{
			string[] obj2 = new string[5]
			{
				"Material: ",
				sourceMaterials[l].name,
				" will use rectangle: ",
				null,
				null
			};
			Rect rect = array3[l];
			obj2[3] = rect.ToString();
			obj2[4] = "\n";
			stringBuilder2.Append(string.Concat(obj2));
		}
		UnityEngine.Debug.Log(stringBuilder2);
		UnityEngine.Debug.Log("Creating and setting up MB2_TextureBakeResults");
		materialBakeResult = ScriptableObject.CreateInstance<MB2_TextureBakeResults>();
		materialBakeResult.resultType = MB2_TextureBakeResults.ResultType.atlas;
		materialBakeResult.materialsAndUVRects = new MB_MaterialAndUVRect[array.Length];
		float num4 = (float)num / (float)atlasTexture.width;
		float num5 = (float)num / (float)atlasTexture.height;
		for (int m = 0; m < array.Length; m++)
		{
			Rect destRect = array3[m];
			destRect.x += num4;
			destRect.y += num5;
			destRect.width -= 2f * num4;
			destRect.height -= 2f * num5;
			bool allPropsUseSameTiling = true;
			materialBakeResult.materialsAndUVRects[m] = new MB_MaterialAndUVRect(sourceMaterials[m], destRect, allPropsUseSameTiling, new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, 0f, 0f), MB_TextureTilingTreatment.none, sourceMaterials[m].name);
		}
		materialBakeResult.resultMaterials = new MB_MultiMaterial[1];
		materialBakeResult.resultMaterials[0] = new MB_MultiMaterial();
		materialBakeResult.resultMaterials[0].combinedMaterial = atlasMaterial;
		materialBakeResult.resultMaterials[0].considerMeshUVs = false;
		List<Material> list = new List<Material>();
		list.AddRange(sourceMaterials);
		materialBakeResult.resultMaterials[0].sourceMaterials = list;
	}
}
