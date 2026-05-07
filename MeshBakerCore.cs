using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using DigitalOpus.MB.Core;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;
using UnityEngine.Scripting;
using UnityEngine.Serialization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("MeshBakerTests2")]
[assembly: InternalsVisibleTo("MeshBakerTests")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
public class AssemblyInfo
{
}
public class MB_TextureCombinerRenderTexture
{
	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	private Material mat;

	private RenderTexture _destinationTexture;

	private Camera myCamera;

	private int _padding;

	private bool _isNormalMap;

	private bool _fixOutOfBoundsUVs;

	private bool _doRenderAtlas;

	private Rect[] rs;

	private List<MB_TexSet> textureSets;

	private int indexOfTexSetToRender;

	private ShaderTextureProperty _texPropertyName;

	private MB3_TextureCombinerNonTextureProperties _resultMaterialTextureBlender;

	private Texture2D targTex;

	public Texture2D DoRenderAtlas(GameObject gameObject, int width, int height, int padding, Rect[] rss, List<MB_TexSet> textureSetss, int indexOfTexSetToRenders, ShaderTextureProperty texPropertyname, MB3_TextureCombinerNonTextureProperties resultMaterialTextureBlender, bool isNormalMap, bool fixOutOfBoundsUVs, bool considerNonTextureProperties, MB3_TextureCombiner texCombiner, MB2_LogLevel LOG_LEV)
	{
		LOG_LEVEL = LOG_LEV;
		textureSets = textureSetss;
		indexOfTexSetToRender = indexOfTexSetToRenders;
		_texPropertyName = texPropertyname;
		_padding = padding;
		_isNormalMap = isNormalMap;
		_fixOutOfBoundsUVs = fixOutOfBoundsUVs;
		_resultMaterialTextureBlender = resultMaterialTextureBlender;
		rs = rss;
		Shader shader = ((!_isNormalMap) ? Shader.Find("MeshBaker/AlbedoShader") : ((!MBVersion.IsSwizzledNormalMapPlatform()) ? Shader.Find("MeshBaker/AlbedoShader") : Shader.Find("MeshBaker/NormalMapShaderSwizzle")));
		if (shader == null)
		{
			UnityEngine.Debug.LogError("Could not find shader for RenderTexture. Try reimporting mesh baker");
			return null;
		}
		mat = new Material(shader);
		RenderTextureReadWrite readWrite = ((!texPropertyname.isGammaCorrected) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
		_destinationTexture = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, readWrite);
		_destinationTexture.filterMode = FilterMode.Point;
		myCamera = gameObject.GetComponent<Camera>();
		myCamera.orthographic = true;
		myCamera.orthographicSize = height >> 1;
		myCamera.aspect = (float)width / (float)height;
		myCamera.targetTexture = _destinationTexture;
		myCamera.clearFlags = CameraClearFlags.Color;
		Transform component = myCamera.GetComponent<Transform>();
		component.localPosition = new Vector3((float)width / 2f, (float)height / 2f, 3f);
		component.localRotation = Quaternion.Euler(0f, 180f, 180f);
		_doRenderAtlas = true;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log(string.Format("Begin Camera.Render destTex w={0} h={1} camPos={2} camSize={3} camAspect={4}", width, height, component.localPosition, myCamera.orthographicSize, myCamera.aspect.ToString("f5")));
		}
		myCamera.Render();
		_doRenderAtlas = false;
		MB_Utility.Destroy(mat);
		MB_Utility.Destroy(_destinationTexture);
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Finished Camera.Render ");
		}
		Texture2D texture2D = targTex;
		targTex = null;
		if (texture2D == null)
		{
			UnityEngine.Debug.LogError(" Generated atlas was null. This can happen when using HDRP. Try using the Texture Packer 'Mesh Baker Texture Packer Fast V2' ");
		}
		return texture2D;
	}

	public void OnRenderObject()
	{
		if (!_doRenderAtlas)
		{
			return;
		}
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		bool yIsFlipped = YisFlipped(LOG_LEVEL);
		for (int i = 0; i < rs.Length; i++)
		{
			MeshBakerMaterialTexture meshBakerMaterialTexture = textureSets[i].ts[indexOfTexSetToRender];
			Texture2D texture2D = meshBakerMaterialTexture.GetTexture2D();
			if (LOG_LEVEL >= MB2_LogLevel.trace && texture2D != null)
			{
				string[] obj = new string[14]
				{
					"Added ",
					texture2D?.ToString(),
					" to atlas w=",
					texture2D.width.ToString(),
					" h=",
					texture2D.height.ToString(),
					" offset=",
					meshBakerMaterialTexture.matTilingRect.min.ToString(),
					" scale=",
					meshBakerMaterialTexture.matTilingRect.size.ToString(),
					" rect=",
					null,
					null,
					null
				};
				Rect rect = rs[i];
				obj[11] = rect.ToString();
				obj[12] = " padding=";
				obj[13] = _padding.ToString();
				UnityEngine.Debug.Log(string.Concat(obj));
			}
			CopyScaledAndTiledToAtlas(textureSets[i], meshBakerMaterialTexture, textureSets[i].obUVoffset, textureSets[i].obUVscale, rs[i], _texPropertyName, _resultMaterialTextureBlender, yIsFlipped);
		}
		stopwatch.Stop();
		stopwatch.Start();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Total time for Graphics.DrawTexture calls " + stopwatch.ElapsedMilliseconds.ToString("f5"));
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Copying RenderTexture to Texture2D. destW" + _destinationTexture.width + " destH" + _destinationTexture.height);
		}
		Texture2D tempTexture = new Texture2D(_destinationTexture.width, _destinationTexture.height, TextureFormat.ARGB32, mipChain: true, !_texPropertyName.isGammaCorrected);
		ConvertRenderTextureToTexture2D(_destinationTexture, yIsFlipped, doLinearColorSpace: false, LOG_LEVEL, tempTexture);
		myCamera.targetTexture = null;
		targTex = tempTexture;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Total time to copy RenderTexture to Texture2D " + stopwatch.ElapsedMilliseconds.ToString("f5"));
		}
	}

	public static void ConvertRenderTextureToTexture2D(RenderTexture _destinationTexture, bool yIsFlipped, bool doLinearColorSpace, MB2_LogLevel LOG_LEVEL, Texture2D tempTexture)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _destinationTexture;
		int num = Mathf.CeilToInt((float)_destinationTexture.width / 512f);
		int num2 = Mathf.CeilToInt((float)_destinationTexture.height / 512f);
		if (num == 0 || num2 == 0)
		{
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("Copying all in one shot");
			}
			tempTexture.ReadPixels(new Rect(0f, 0f, _destinationTexture.width, _destinationTexture.height), 0, 0, recalculateMipMaps: true);
		}
		else
		{
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("yIsFlipped copying blocks");
			}
			if (!yIsFlipped)
			{
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < num2; j++)
					{
						int num3 = i * 512;
						int num4 = j * 512;
						Rect source = new Rect(num3, num4, 512f, 512f);
						tempTexture.ReadPixels(source, i * 512, j * 512, recalculateMipMaps: true);
					}
				}
			}
			else
			{
				for (int k = 0; k < num; k++)
				{
					for (int l = 0; l < num2; l++)
					{
						int num5 = k * 512;
						int num6 = _destinationTexture.height - 512 - l * 512;
						Rect source2 = new Rect(num5, num6, 512f, 512f);
						tempTexture.ReadPixels(source2, k * 512, l * 512, recalculateMipMaps: true);
					}
				}
			}
		}
		RenderTexture.active = active;
		tempTexture.Apply();
		if (LOG_LEVEL >= MB2_LogLevel.trace && tempTexture.height <= 16 && tempTexture.width <= 16)
		{
			_printTexture(tempTexture);
		}
	}

	private Color32 ConvertNormalFormatFromUnity_ToStandard(Color32 c)
	{
		Vector3 zero = Vector3.zero;
		zero.x = (float)(int)c.a * 2f - 1f;
		zero.y = (float)(int)c.g * 2f - 1f;
		zero.z = Mathf.Sqrt(1f - zero.x * zero.x - zero.y * zero.y);
		return new Color32
		{
			a = 1,
			r = (byte)((zero.x + 1f) * 0.5f),
			g = (byte)((zero.y + 1f) * 0.5f),
			b = (byte)((zero.z + 1f) * 0.5f)
		};
	}

	public static bool YisFlipped(MB2_LogLevel LOG_LEVEL)
	{
		bool result = (MBVersion.GraphicsUVStartsAtTop() ? true : false);
		if (LOG_LEVEL == MB2_LogLevel.debug)
		{
			string text = SystemInfo.graphicsDeviceVersion.ToLower();
			UnityEngine.Debug.Log("Graphics device version is: " + text + " flipY:" + result);
		}
		return result;
	}

	private void CopyScaledAndTiledToAtlas(MB_TexSet texSet, MeshBakerMaterialTexture source, Vector2 obUVoffset, Vector2 obUVscale, Rect rec, ShaderTextureProperty texturePropertyName, MB3_TextureCombinerNonTextureProperties resultMatTexBlender, bool yIsFlipped)
	{
		Rect rect = rec;
		myCamera.backgroundColor = resultMatTexBlender.GetColorForTemporaryTexture(texSet.matsAndGOs.mats[0].mat, texturePropertyName);
		rect.y = 1f - (rect.y + rect.height);
		rect.x *= _destinationTexture.width;
		rect.y *= _destinationTexture.height;
		rect.width *= _destinationTexture.width;
		rect.height *= _destinationTexture.height;
		Rect rect2 = rect;
		rect2.x -= _padding;
		rect2.y -= _padding;
		rect2.width += _padding * 2;
		rect2.height += _padding * 2;
		Rect screenRect = default(Rect);
		Rect rect3 = texSet.ts[indexOfTexSetToRender].GetEncapsulatingSamplingRect().GetRect();
		Texture2D texture2D = source.GetTexture2D();
		TextureWrapMode wrapMode = texture2D.wrapMode;
		if (rect3.width == 1f && rect3.height == 1f && rect3.x == 0f && rect3.y == 0f)
		{
			texture2D.wrapMode = TextureWrapMode.Clamp;
		}
		else
		{
			texture2D.wrapMode = TextureWrapMode.Repeat;
		}
		if (LOG_LEVEL >= MB2_LogLevel.trace)
		{
			string[] obj = new string[8] { "DrawTexture tex=", texture2D.name, " destRect=", null, null, null, null, null };
			Rect rect4 = rect;
			obj[3] = rect4.ToString();
			obj[4] = " srcRect=";
			rect4 = rect3;
			obj[5] = rect4.ToString();
			obj[6] = " Mat=";
			obj[7] = mat?.ToString();
			UnityEngine.Debug.Log(string.Concat(obj));
		}
		Rect sourceRect = new Rect
		{
			x = rect3.x,
			y = rect3.y + 1f - 1f / (float)texture2D.height,
			width = rect3.width,
			height = 1f / (float)texture2D.height
		};
		screenRect.x = rect.x;
		screenRect.y = rect2.y;
		screenRect.width = rect.width;
		screenRect.height = _padding;
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = _destinationTexture;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x;
		sourceRect.y = rect3.y;
		sourceRect.width = rect3.width;
		sourceRect.height = 1f / (float)texture2D.height;
		screenRect.x = rect.x;
		screenRect.y = rect.y + rect.height;
		screenRect.width = rect.width;
		screenRect.height = _padding;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x;
		sourceRect.y = rect3.y;
		sourceRect.width = 1f / (float)texture2D.width;
		sourceRect.height = rect3.height;
		screenRect.x = rect2.x;
		screenRect.y = rect.y;
		screenRect.width = _padding;
		screenRect.height = rect.height;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x + 1f - 1f / (float)texture2D.width;
		sourceRect.y = rect3.y;
		sourceRect.width = 1f / (float)texture2D.width;
		sourceRect.height = rect3.height;
		screenRect.x = rect.x + rect.width;
		screenRect.y = rect.y;
		screenRect.width = _padding;
		screenRect.height = rect.height;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x;
		sourceRect.y = rect3.y + 1f - 1f / (float)texture2D.height;
		sourceRect.width = 1f / (float)texture2D.width;
		sourceRect.height = 1f / (float)texture2D.height;
		screenRect.x = rect2.x;
		screenRect.y = rect2.y;
		screenRect.width = _padding;
		screenRect.height = _padding;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x + 1f - 1f / (float)texture2D.width;
		sourceRect.y = rect3.y + 1f - 1f / (float)texture2D.height;
		sourceRect.width = 1f / (float)texture2D.width;
		sourceRect.height = 1f / (float)texture2D.height;
		screenRect.x = rect.x + rect.width;
		screenRect.y = rect2.y;
		screenRect.width = _padding;
		screenRect.height = _padding;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x;
		sourceRect.y = rect3.y;
		sourceRect.width = 1f / (float)texture2D.width;
		sourceRect.height = 1f / (float)texture2D.height;
		screenRect.x = rect2.x;
		screenRect.y = rect.y + rect.height;
		screenRect.width = _padding;
		screenRect.height = _padding;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		sourceRect.x = rect3.x + 1f - 1f / (float)texture2D.width;
		sourceRect.y = rect3.y;
		sourceRect.width = 1f / (float)texture2D.width;
		sourceRect.height = 1f / (float)texture2D.height;
		screenRect.x = rect.x + rect.width;
		screenRect.y = rect.y + rect.height;
		screenRect.width = _padding;
		screenRect.height = _padding;
		Graphics.DrawTexture(screenRect, texture2D, sourceRect, 0, 0, 0, 0, mat);
		Graphics.DrawTexture(rect, texture2D, rect3, 0, 0, 0, 0, mat);
		RenderTexture.active = active;
		texture2D.wrapMode = wrapMode;
	}

	private static void _printTexture(Texture2D t)
	{
		if (t.width * t.height > 100)
		{
			UnityEngine.Debug.Log("Not printing texture too large.");
			return;
		}
		try
		{
			Color32[] pixels = t.GetPixels32();
			string text = "";
			for (int i = 0; i < t.height; i++)
			{
				for (int j = 0; j < t.width; j++)
				{
					string text2 = text;
					Color32 color = pixels[i * t.width + j];
					text = text2 + color.ToString() + ", ";
				}
				text += "\n";
			}
			UnityEngine.Debug.Log(text);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.Log("Could not print texture. texture may not be readable." + ex.Message + "\n" + ex.StackTrace.ToString());
		}
	}
}
[ExecuteInEditMode]
public class MB3_AtlasPackerRenderTexture : MonoBehaviour
{
	private MB_TextureCombinerRenderTexture fastRenderer;

	private bool _doRenderAtlas;

	public int width;

	public int height;

	public int padding;

	public bool isNormalMap;

	public bool fixOutOfBoundsUVs;

	public bool considerNonTextureProperties;

	public MB3_TextureCombinerNonTextureProperties resultMaterialTextureBlender;

	public Rect[] rects;

	public Texture2D tex1;

	public List<MB_TexSet> textureSets;

	public int indexOfTexSetToRender;

	public ShaderTextureProperty texPropertyName;

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	public Texture2D testTex;

	public Material testMat;

	public Texture2D OnRenderAtlas(MB3_TextureCombiner combiner)
	{
		fastRenderer = new MB_TextureCombinerRenderTexture();
		_doRenderAtlas = true;
		Texture2D result = fastRenderer.DoRenderAtlas(base.gameObject, width, height, padding, rects, textureSets, indexOfTexSetToRender, texPropertyName, resultMaterialTextureBlender, isNormalMap, fixOutOfBoundsUVs, considerNonTextureProperties, combiner, LOG_LEVEL);
		_doRenderAtlas = false;
		return result;
	}

	private void OnRenderObject()
	{
		if (_doRenderAtlas)
		{
			fastRenderer.OnRenderObject();
			_doRenderAtlas = false;
		}
	}
}
[Serializable]
public class MB_AtlasesAndRects
{
	public Texture2D[] atlases;

	[NonSerialized]
	public List<MB_MaterialAndUVRect> mat2rect_map;

	public string[] texPropertyNames;
}
public class MB_TextureArrayResultMaterial
{
	public MB_AtlasesAndRects[] slices;
}
[Serializable]
public class MB_MultiMaterial
{
	public Material combinedMaterial;

	public bool considerMeshUVs;

	[NonReorderable]
	public List<Material> sourceMaterials = new List<Material>();
}
[Serializable]
public class MB_TexArraySliceRendererMatPair
{
	public Material sourceMaterial;

	public GameObject renderer;
}
[Serializable]
public class MB_TexArraySlice
{
	public bool considerMeshUVs;

	[NonReorderable]
	public List<MB_TexArraySliceRendererMatPair> sourceMaterials = new List<MB_TexArraySliceRendererMatPair>();

	public bool ContainsMaterial(Material mat)
	{
		for (int i = 0; i < sourceMaterials.Count; i++)
		{
			if (sourceMaterials[i].sourceMaterial == mat)
			{
				return true;
			}
		}
		return false;
	}

	public HashSet<Material> GetDistinctMaterials()
	{
		HashSet<Material> hashSet = new HashSet<Material>();
		if (sourceMaterials == null)
		{
			return hashSet;
		}
		for (int i = 0; i < sourceMaterials.Count; i++)
		{
			hashSet.Add(sourceMaterials[i].sourceMaterial);
		}
		return hashSet;
	}

	public bool ContainsMaterialAndMesh(Material mat, Mesh mesh)
	{
		for (int i = 0; i < sourceMaterials.Count; i++)
		{
			if (sourceMaterials[i].sourceMaterial == mat && MB_Utility.GetMesh(sourceMaterials[i].renderer) == mesh)
			{
				return true;
			}
		}
		return false;
	}

	public List<Material> GetAllUsedMaterials(List<Material> usedMats)
	{
		usedMats.Clear();
		for (int i = 0; i < sourceMaterials.Count; i++)
		{
			usedMats.Add(sourceMaterials[i].sourceMaterial);
		}
		return usedMats;
	}

	public List<GameObject> GetAllUsedRenderers(List<GameObject> allObjsFromTextureBaker)
	{
		if (considerMeshUVs)
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < sourceMaterials.Count; i++)
			{
				list.Add(sourceMaterials[i].renderer);
			}
			return list;
		}
		return allObjsFromTextureBaker;
	}
}
[Serializable]
public class MB_TextureArrayReference
{
	public string texFromatSetName;

	public Texture2DArray texArray;

	public MB_TextureArrayReference(string formatSetName, Texture2DArray ta)
	{
		texFromatSetName = formatSetName;
		texArray = ta;
	}
}
[Serializable]
public class MB_TexArrayForProperty
{
	public string texPropertyName;

	[NonReorderable]
	public MB_TextureArrayReference[] formats = new MB_TextureArrayReference[0];

	public MB_TexArrayForProperty(string name, MB_TextureArrayReference[] texRefs)
	{
		texPropertyName = name;
		formats = texRefs;
	}
}
[Serializable]
public class MB_MultiMaterialTexArray
{
	public Material combinedMaterial;

	[NonReorderable]
	public List<MB_TexArraySlice> slices = new List<MB_TexArraySlice>();

	[NonReorderable]
	public List<MB_TexArrayForProperty> textureProperties = new List<MB_TexArrayForProperty>();
}
[Serializable]
public class MB_TextureArrayFormat
{
	public string propertyName;

	public TextureFormat format;

	[Tooltip("The ammount of time Unity takes exploring different compression options to find the compressed version of a texture that most closely matches the original art.This is only used For iOS (and some Android formats)")]
	public MB_TextureCompressionQuality compressionQuality = MB_TextureCompressionQuality.normal;
}
[Serializable]
public class MB_TextureArrayFormatSet
{
	public string name;

	public TextureFormat defaultFormat;

	[Tooltip("The ammount of time Unity takes exploring different compression options to find the compressed version of a texture that most closely matches the original art.This is only used For iOS (and some Android formats)")]
	public MB_TextureCompressionQuality defaultCompressionQuality = MB_TextureCompressionQuality.normal;

	[NonReorderable]
	public MB_TextureArrayFormat[] formatOverrides;

	public bool ValidateTextureImporterFormatsExistsForTextureFormats(MB2_EditorMethodsInterface editorMethods, int idx)
	{
		if (editorMethods == null)
		{
			return true;
		}
		if (!editorMethods.TextureImporterFormatExistsForTextureFormat(defaultFormat))
		{
			UnityEngine.Debug.LogError("TextureImporter format does not exist for Texture Array Output Formats: " + idx + " Defaut Format " + defaultFormat);
			return false;
		}
		for (int i = 0; i < formatOverrides.Length; i++)
		{
			if (!editorMethods.TextureImporterFormatExistsForTextureFormat(formatOverrides[i].format))
			{
				UnityEngine.Debug.LogError("TextureImporter format does not exist for Texture Array Output Formats: " + idx + " Format Overrides: " + i + " (" + formatOverrides[i].format.ToString() + ")");
				return false;
			}
		}
		return true;
	}

	public TextureFormat GetFormatForProperty(string propName, out MB_TextureCompressionQuality compressionQuality)
	{
		for (int i = 0; i < formatOverrides.Length; i++)
		{
			if (formatOverrides.Equals(formatOverrides[i].propertyName))
			{
				compressionQuality = formatOverrides[i].compressionQuality;
				return formatOverrides[i].format;
			}
		}
		compressionQuality = defaultCompressionQuality;
		return defaultFormat;
	}
}
[Serializable]
public class MB_MaterialAndUVRect
{
	public Material material;

	public Rect atlasRect;

	public string srcObjName;

	public int textureArraySliceIdx = -1;

	public bool allPropsUseSameTiling = true;

	[FormerlySerializedAs("sourceMaterialTiling")]
	public Rect allPropsUseSameTiling_sourceMaterialTiling;

	[FormerlySerializedAs("samplingEncapsulatinRect")]
	public Rect allPropsUseSameTiling_samplingEncapsulatinRect;

	public Rect propsUseDifferntTiling_srcUVsamplingRect;

	[NonSerialized]
	public List<GameObject> objectsThatUse;

	public MB_TextureTilingTreatment tilingTreatment = MB_TextureTilingTreatment.unknown;

	public MB_MaterialAndUVRect(Material mat, Rect destRect, bool allPropsUseSameTiling, Rect sourceMaterialTiling, Rect samplingEncapsulatingRect, Rect srcUVsamplingRect, MB_TextureTilingTreatment treatment, string objName)
	{
		material = mat;
		atlasRect = destRect;
		tilingTreatment = treatment;
		this.allPropsUseSameTiling = allPropsUseSameTiling;
		allPropsUseSameTiling_sourceMaterialTiling = sourceMaterialTiling;
		allPropsUseSameTiling_samplingEncapsulatinRect = samplingEncapsulatingRect;
		propsUseDifferntTiling_srcUVsamplingRect = srcUVsamplingRect;
		srcObjName = objName;
	}

	public override int GetHashCode()
	{
		return material.GetInstanceID() ^ allPropsUseSameTiling_samplingEncapsulatinRect.GetHashCode() ^ propsUseDifferntTiling_srcUVsamplingRect.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is MB_MaterialAndUVRect))
		{
			return false;
		}
		MB_MaterialAndUVRect mB_MaterialAndUVRect = (MB_MaterialAndUVRect)obj;
		if (material == mB_MaterialAndUVRect.material && allPropsUseSameTiling_samplingEncapsulatinRect == mB_MaterialAndUVRect.allPropsUseSameTiling_samplingEncapsulatinRect && allPropsUseSameTiling_sourceMaterialTiling == mB_MaterialAndUVRect.allPropsUseSameTiling_sourceMaterialTiling && allPropsUseSameTiling == mB_MaterialAndUVRect.allPropsUseSameTiling)
		{
			return propsUseDifferntTiling_srcUVsamplingRect == mB_MaterialAndUVRect.propsUseDifferntTiling_srcUVsamplingRect;
		}
		return false;
	}

	public Rect GetEncapsulatingRect()
	{
		if (allPropsUseSameTiling)
		{
			return allPropsUseSameTiling_samplingEncapsulatinRect;
		}
		return propsUseDifferntTiling_srcUVsamplingRect;
	}

	public Rect GetMaterialTilingRect()
	{
		if (allPropsUseSameTiling)
		{
			return allPropsUseSameTiling_sourceMaterialTiling;
		}
		return new Rect(0f, 0f, 1f, 1f);
	}
}
public class MB2_TextureBakeResults : ScriptableObject
{
	public class CoroutineResult
	{
		public bool isComplete;
	}

	public enum ResultType
	{
		atlas,
		textureArray
	}

	public int version;

	public ResultType resultType;

	[NonReorderable]
	public MB_MaterialAndUVRect[] materialsAndUVRects;

	[NonReorderable]
	public MB_MultiMaterial[] resultMaterials;

	[NonReorderable]
	public MB_MultiMaterialTexArray[] resultMaterialsTexArray;

	public bool doMultiMaterial;

	public static int VERSION => 3252;

	public MB2_TextureBakeResults()
	{
		version = VERSION;
	}

	private void OnEnable()
	{
		if (version < 3251)
		{
			for (int i = 0; i < materialsAndUVRects.Length; i++)
			{
				materialsAndUVRects[i].allPropsUseSameTiling = true;
			}
		}
		version = VERSION;
	}

	public int NumResultMaterials()
	{
		if (resultType == ResultType.atlas)
		{
			return resultMaterials.Length;
		}
		return resultMaterialsTexArray.Length;
	}

	public Material GetCombinedMaterialForSubmesh(int idx)
	{
		if (resultType == ResultType.atlas)
		{
			return resultMaterials[idx].combinedMaterial;
		}
		return resultMaterialsTexArray[idx].combinedMaterial;
	}

	public IEnumerator FindRuntimeMaterialsFromAddresses(CoroutineResult isComplete)
	{
		yield return MBVersion.FindRuntimeMaterialsFromAddresses(this, isComplete);
		isComplete.isComplete = true;
	}

	public bool GetConsiderMeshUVs(int idxInSrcMats, Material srcMaterial)
	{
		if (resultType == ResultType.atlas)
		{
			return resultMaterials[idxInSrcMats].considerMeshUVs;
		}
		List<MB_TexArraySlice> slices = resultMaterialsTexArray[idxInSrcMats].slices;
		for (int i = 0; i < slices.Count; i++)
		{
			if (slices[i].ContainsMaterial(srcMaterial))
			{
				return slices[i].considerMeshUVs;
			}
		}
		UnityEngine.Debug.LogError("There were no source materials for any slice in this result material.");
		return false;
	}

	public List<Material> GetSourceMaterialsUsedByResultMaterial(int resultMatIdx)
	{
		if (resultType == ResultType.atlas)
		{
			return resultMaterials[resultMatIdx].sourceMaterials;
		}
		HashSet<Material> hashSet = new HashSet<Material>();
		List<MB_TexArraySlice> slices = resultMaterialsTexArray[resultMatIdx].slices;
		for (int i = 0; i < slices.Count; i++)
		{
			List<Material> list = new List<Material>();
			slices[i].GetAllUsedMaterials(list);
			for (int j = 0; j < list.Count; j++)
			{
				hashSet.Add(list[j]);
			}
		}
		return new List<Material>(hashSet);
	}

	public static MB2_TextureBakeResults CreateForMaterialsOnRenderer(GameObject[] gos, List<Material> matsOnTargetRenderer)
	{
		HashSet<Material> hashSet = new HashSet<Material>(matsOnTargetRenderer);
		for (int i = 0; i < gos.Length; i++)
		{
			if (gos[i] == null)
			{
				UnityEngine.Debug.LogError($"Game object {i} in list of objects to add was null");
				return null;
			}
			Material[] gOMaterials = MB_Utility.GetGOMaterials(gos[i]);
			if (gOMaterials.Length == 0)
			{
				UnityEngine.Debug.LogError($"Game object {i} in list of objects to add no renderer");
				return null;
			}
			for (int j = 0; j < gOMaterials.Length; j++)
			{
				if (!hashSet.Contains(gOMaterials[j]))
				{
					hashSet.Add(gOMaterials[j]);
				}
			}
		}
		Material[] array = new Material[hashSet.Count];
		hashSet.CopyTo(array);
		MB2_TextureBakeResults mB2_TextureBakeResults = (MB2_TextureBakeResults)ScriptableObject.CreateInstance(typeof(MB2_TextureBakeResults));
		List<MB_MaterialAndUVRect> list = new List<MB_MaterialAndUVRect>();
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] != null)
			{
				MB_MaterialAndUVRect item = new MB_MaterialAndUVRect(array[k], new Rect(0f, 0f, 1f, 1f), allPropsUseSameTiling: true, new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, 1f, 1f), new Rect(0f, 0f, 0f, 0f), MB_TextureTilingTreatment.none, "");
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		mB2_TextureBakeResults.resultMaterials = new MB_MultiMaterial[list.Count];
		for (int l = 0; l < list.Count; l++)
		{
			mB2_TextureBakeResults.resultMaterials[l] = new MB_MultiMaterial();
			List<Material> list2 = new List<Material>();
			list2.Add(list[l].material);
			mB2_TextureBakeResults.resultMaterials[l].sourceMaterials = list2;
			mB2_TextureBakeResults.resultMaterials[l].combinedMaterial = list[l].material;
			mB2_TextureBakeResults.resultMaterials[l].considerMeshUVs = false;
		}
		if (array.Length == 1)
		{
			mB2_TextureBakeResults.doMultiMaterial = false;
		}
		else
		{
			mB2_TextureBakeResults.doMultiMaterial = true;
		}
		mB2_TextureBakeResults.materialsAndUVRects = list.ToArray();
		return mB2_TextureBakeResults;
	}

	public bool DoAnyResultMatsUseConsiderMeshUVs()
	{
		if (resultType == ResultType.atlas)
		{
			if (resultMaterials == null)
			{
				return false;
			}
			for (int i = 0; i < resultMaterials.Length; i++)
			{
				if (resultMaterials[i].considerMeshUVs)
				{
					return true;
				}
			}
			return false;
		}
		if (resultMaterialsTexArray == null)
		{
			return false;
		}
		for (int j = 0; j < resultMaterialsTexArray.Length; j++)
		{
			MB_MultiMaterialTexArray mB_MultiMaterialTexArray = resultMaterialsTexArray[j];
			for (int k = 0; k < mB_MultiMaterialTexArray.slices.Count; k++)
			{
				if (mB_MultiMaterialTexArray.slices[k].considerMeshUVs)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool ContainsMaterial(Material m)
	{
		for (int i = 0; i < materialsAndUVRects.Length; i++)
		{
			if (materialsAndUVRects[i].material == m)
			{
				return true;
			}
		}
		return false;
	}

	public string GetDescription()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Shaders:\n");
		HashSet<Shader> hashSet = new HashSet<Shader>();
		if (materialsAndUVRects != null)
		{
			for (int i = 0; i < materialsAndUVRects.Length; i++)
			{
				if (materialsAndUVRects[i].material != null)
				{
					hashSet.Add(materialsAndUVRects[i].material.shader);
				}
			}
		}
		foreach (Shader item in hashSet)
		{
			stringBuilder.Append("  ").Append(item.name).AppendLine();
		}
		stringBuilder.Append("Materials:\n");
		if (materialsAndUVRects != null)
		{
			for (int j = 0; j < materialsAndUVRects.Length; j++)
			{
				if (materialsAndUVRects[j].material != null)
				{
					stringBuilder.Append("  ").Append(materialsAndUVRects[j].material.name).AppendLine();
				}
			}
		}
		return stringBuilder.ToString();
	}

	public void UpgradeToCurrentVersion(MB2_TextureBakeResults tbr)
	{
		if (tbr.version < 3252)
		{
			for (int i = 0; i < tbr.materialsAndUVRects.Length; i++)
			{
				tbr.materialsAndUVRects[i].allPropsUseSameTiling = true;
			}
		}
	}

	public static bool IsMeshAndMaterialRectEnclosedByAtlasRect(MB_TextureTilingTreatment tilingTreatment, Rect uvR, Rect sourceMaterialTiling, Rect samplingEncapsulatinRect, MB2_LogLevel logLevel)
	{
		Rect rect = default(Rect);
		rect = MB3_UVTransformUtility.CombineTransforms(ref uvR, ref sourceMaterialTiling);
		if (logLevel >= MB2_LogLevel.trace && logLevel >= MB2_LogLevel.trace)
		{
			UnityEngine.Debug.Log("IsMeshAndMaterialRectEnclosedByAtlasRect Rect in atlas uvR=" + uvR.ToString("f5") + " sourceMaterialTiling=" + sourceMaterialTiling.ToString("f5") + "Potential Rect (must fit in encapsulating) " + rect.ToString("f5") + " encapsulating=" + samplingEncapsulatinRect.ToString("f5") + " tilingTreatment=" + tilingTreatment);
		}
		switch (tilingTreatment)
		{
		case MB_TextureTilingTreatment.edgeToEdgeX:
			if (MB3_UVTransformUtility.LineSegmentContainsShifted(samplingEncapsulatinRect.y, samplingEncapsulatinRect.height, rect.y, rect.height))
			{
				return true;
			}
			break;
		case MB_TextureTilingTreatment.edgeToEdgeY:
			if (MB3_UVTransformUtility.LineSegmentContainsShifted(samplingEncapsulatinRect.x, samplingEncapsulatinRect.width, rect.x, rect.width))
			{
				return true;
			}
			break;
		case MB_TextureTilingTreatment.edgeToEdgeXY:
			return true;
		default:
			if (MB3_UVTransformUtility.RectContainsShifted(ref samplingEncapsulatinRect, ref rect))
			{
				return true;
			}
			break;
		}
		return false;
	}
}
public class MB2_UpdateSkinnedMeshBoundsFromBones : MonoBehaviour
{
	private SkinnedMeshRenderer smr;

	private Transform[] bones;

	private void Start()
	{
		smr = GetComponent<SkinnedMeshRenderer>();
		if (smr == null)
		{
			UnityEngine.Debug.LogError("Need to attach MB2_UpdateSkinnedMeshBoundsFromBones script to an object with a SkinnedMeshRenderer component attached.");
			return;
		}
		bones = smr.bones;
		bool updateWhenOffscreen = smr.updateWhenOffscreen;
		smr.updateWhenOffscreen = true;
		smr.updateWhenOffscreen = updateWhenOffscreen;
	}

	private void Update()
	{
		if (smr != null)
		{
			MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBonesStatic(bones, smr);
		}
	}
}
public class MB2_UpdateSkinnedMeshBoundsFromBounds : MonoBehaviour
{
	public List<GameObject> objects;

	private SkinnedMeshRenderer smr;

	private void Start()
	{
		smr = GetComponent<SkinnedMeshRenderer>();
		if (smr == null)
		{
			UnityEngine.Debug.LogError("Need to attach MB2_UpdateSkinnedMeshBoundsFromBounds script to an object with a SkinnedMeshRenderer component attached.");
			return;
		}
		if (objects == null || objects.Count == 0)
		{
			UnityEngine.Debug.LogWarning("The MB2_UpdateSkinnedMeshBoundsFromBounds had no Game Objects. It should have the same list of game objects that the MeshBaker does.");
			smr = null;
			return;
		}
		for (int i = 0; i < objects.Count; i++)
		{
			if (objects[i] == null || objects[i].GetComponent<Renderer>() == null)
			{
				UnityEngine.Debug.LogError("The list of objects had nulls or game objects without a renderer attached at position " + i);
				smr = null;
				return;
			}
		}
		bool updateWhenOffscreen = smr.updateWhenOffscreen;
		smr.updateWhenOffscreen = true;
		smr.updateWhenOffscreen = updateWhenOffscreen;
	}

	private void Update()
	{
		if (smr != null && objects != null)
		{
			MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(objects, smr);
		}
	}
}
public class MB3_BatchPrefabBaker : MonoBehaviour
{
	[Serializable]
	public class MB3_PrefabBakerRow
	{
		public GameObject sourcePrefab;

		public GameObject resultPrefab;
	}

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	[NonReorderable]
	public MB3_PrefabBakerRow[] prefabRows = new MB3_PrefabBakerRow[0];

	public string outputPrefabFolder = "";

	[ContextMenu("Create Instances For Prefab Rows")]
	public void CreateSourceAndResultPrefabInstances()
	{
		UnityEngine.Debug.LogError("Cannot be used outside the editor");
	}
}
public class MB3_BoneWeightCopier : MonoBehaviour
{
	public GameObject inputGameObject;

	public GameObject outputPrefab;

	public float radius = 0.01f;

	public SkinnedMeshRenderer seamMesh;

	public string outputFolder;
}
public class MB3_DisableHiddenAnimations : MonoBehaviour
{
	public List<Animation> animationsToCull = new List<Animation>();

	private void Start()
	{
		if (GetComponent<SkinnedMeshRenderer>() == null)
		{
			UnityEngine.Debug.LogError("The MB3_CullHiddenAnimations script was placed on and object " + base.name + " which has no SkinnedMeshRenderer attached");
		}
	}

	private void OnBecameVisible()
	{
		for (int i = 0; i < animationsToCull.Count; i++)
		{
			if (animationsToCull[i] != null)
			{
				animationsToCull[i].enabled = true;
			}
		}
	}

	private void OnBecameInvisible()
	{
		for (int i = 0; i < animationsToCull.Count; i++)
		{
			if (animationsToCull[i] != null)
			{
				animationsToCull[i].enabled = false;
			}
		}
	}
}
public class MB3_MeshBaker : MB3_MeshBakerCommon
{
	[SerializeField]
	protected MB3_MeshCombinerSingle _meshCombiner = new MB3_MeshCombinerSingle();

	public override MB3_MeshCombiner meshCombiner => _meshCombiner;

	public void PrintTimings()
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		MB3_MeshCombinerSingle mB3_MeshCombinerSingle = _meshCombiner;
		num += mB3_MeshCombinerSingle.db_showHideGameObjects.Elapsed.TotalSeconds;
		num2 += mB3_MeshCombinerSingle.db_addDeleteGameObjects.Elapsed.TotalSeconds;
		num7 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_CollectMeshData.Elapsed.TotalSeconds;
		num8 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_CollectMeshData_a.Elapsed.TotalSeconds;
		num9 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_CollectMeshData_b.Elapsed.TotalSeconds;
		num10 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_CollectMeshData_c.Elapsed.TotalSeconds;
		num3 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_InitFromMeshCombiner.Elapsed.TotalSeconds;
		num4 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_Init.Elapsed.TotalSeconds;
		num5 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers.Elapsed.TotalSeconds;
		num6 += mB3_MeshCombinerSingle.db_addDeleteGameObjects_CopyFromDGOMeshToBuffers.Elapsed.TotalSeconds;
		num11 += mB3_MeshCombinerSingle.db_apply.Elapsed.TotalSeconds;
		num12 += mB3_MeshCombinerSingle.db_applyShowHide.Elapsed.TotalSeconds;
		num13 += mB3_MeshCombinerSingle.db_updateGameObjects.Elapsed.TotalSeconds;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Timings  " + ((_meshCombiner.settings.meshAPI == MB_MeshCombineAPIType.betaNativeArrayAPI) ? "  newMeshAPI " : " oldMeshAPI"));
		stringBuilder.AppendLine("db_showHideGameObjects\t" + num);
		stringBuilder.AppendLine("db_addDeleteGameObjects\t" + num2);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshData\t" + num7);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshDataA\t\t" + num8);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshDataB\t\t" + num9);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshDataC\t\t" + num10);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_InitFromMeshCombiner\t" + num3);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_Init\t" + num4);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers\t" + num5);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CopyFromDGOMeshToBuffers\t" + num6);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshData  tdb_addDeleteGameObjects_CollectMeshData ");
		stringBuilder.AppendLine("db_apply\t" + num11);
		stringBuilder.AppendLine("db_applyShowHide\t" + num12);
		stringBuilder.AppendLine("db_updateGameObjects\t" + num13);
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}

	public void BuildSceneMeshObject()
	{
		_meshCombiner.BuildSceneMeshObject();
	}

	public virtual bool ShowHide(GameObject[] gos, GameObject[] deleteGOs)
	{
		return _meshCombiner.ShowHideGameObjects(gos, deleteGOs);
	}

	public virtual void ApplyShowHide()
	{
		_meshCombiner.ApplyShowHide();
	}

	public override bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource)
	{
		UpgradeToCurrentVersionIfNecessary();
		_meshCombiner.name = base.name + "-mesh";
		return _meshCombiner.AddDeleteGameObjects(gos, deleteGOs, disableRendererInSource);
	}

	public override bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource)
	{
		UpgradeToCurrentVersionIfNecessary();
		_meshCombiner.name = base.name + "-mesh";
		return _meshCombiner.AddDeleteGameObjectsByID(gos, deleteGOinstanceIDs, disableRendererInSource);
	}

	public void OnDestroy()
	{
		if (meshCombiner != null)
		{
			meshCombiner.Dispose();
		}
	}
}
public abstract class MB3_MeshBakerCommon : MB3_MeshBakerRoot
{
	public int version;

	[NonReorderable]
	public List<GameObject> objsToMesh;

	public bool useObjsToMeshFromTexBaker = true;

	[FormerlySerializedAs("clearBuffersAfterBake")]
	[SerializeField]
	[HideInInspector]
	private bool _clearBuffersAfterBake;

	public string bakeAssetsInPlaceFolderPath;

	[HideInInspector]
	public GameObject resultPrefab;

	[HideInInspector]
	public bool resultPrefabLeaveInstanceInSceneAfterBake;

	[HideInInspector]
	public Transform parentSceneObject;

	public static int VERSION => 100;

	public abstract MB3_MeshCombiner meshCombiner { get; }

	public bool clearBuffersAfterBake
	{
		get
		{
			if (version < 100)
			{
				UpgradeToCurrentVersionIfNecessary();
				return _clearBuffersAfterBake;
			}
			UnityEngine.Debug.LogError("MeshBaker.clearBuffersAfterBake is deprecated, use the meshCombiner.clearBuffersAfterBake field");
			return meshCombiner.clearBuffersAfterBake;
		}
		set
		{
			if (version < 100)
			{
				UpgradeToCurrentVersionIfNecessary();
				_clearBuffersAfterBake = value;
			}
			else
			{
				UnityEngine.Debug.LogError("MeshBaker.clearBuffersAfterBake is deprecated, use the meshCombiner.clearBuffersAfterBake field");
				meshCombiner.clearBuffersAfterBake = value;
			}
		}
	}

	public override MB2_TextureBakeResults textureBakeResults
	{
		get
		{
			return meshCombiner.textureBakeResults;
		}
		set
		{
			meshCombiner.textureBakeResults = value;
		}
	}

	public void UpgradeToCurrentVersionIfNecessary()
	{
		if (version != VERSION)
		{
			if (version < 100)
			{
				meshCombiner.clearBuffersAfterBake = _clearBuffersAfterBake;
			}
			version = VERSION;
		}
	}

	public override List<GameObject> GetObjectsToCombine()
	{
		if (useObjsToMeshFromTexBaker)
		{
			MB3_TextureBaker component = base.gameObject.GetComponent<MB3_TextureBaker>();
			if (component == null && base.gameObject.transform.parent != null)
			{
				component = base.gameObject.transform.parent.GetComponent<MB3_TextureBaker>();
			}
			if (component != null)
			{
				return component.GetObjectsToCombine();
			}
			UnityEngine.Debug.LogWarning("Use Objects To Mesh From Texture Baker was checked but no texture baker");
			return new List<GameObject>();
		}
		if (objsToMesh == null)
		{
			objsToMesh = new List<GameObject>();
		}
		return objsToMesh;
	}

	[ContextMenu("Purge Objects to Combine of null references")]
	public override void PurgeNullsFromObjectsToCombine()
	{
		if (useObjsToMeshFromTexBaker)
		{
			MB3_TextureBaker component = base.gameObject.GetComponent<MB3_TextureBaker>();
			if (component == null && base.gameObject.transform.parent != null)
			{
				component = base.gameObject.transform.parent.GetComponent<MB3_TextureBaker>();
			}
			if (component != null)
			{
				component.PurgeNullsFromObjectsToCombine();
			}
			else
			{
				UnityEngine.Debug.LogWarning("Use Objects To Mesh From Texture Baker was checked but no texture baker, could not purge");
			}
		}
		else
		{
			if (objsToMesh == null)
			{
				objsToMesh = new List<GameObject>();
			}
			UnityEngine.Debug.Log($"Purged {objsToMesh.RemoveAll((GameObject obj) => obj == null)} null references from objects to combine list.");
		}
	}

	public void EnableDisableSourceObjectRenderers(bool show)
	{
		for (int i = 0; i < GetObjectsToCombine().Count; i++)
		{
			GameObject gameObject = GetObjectsToCombine()[i];
			if (!(gameObject != null))
			{
				continue;
			}
			Renderer renderer = MB_Utility.GetRenderer(gameObject);
			if (renderer != null)
			{
				renderer.enabled = show;
			}
			LODGroup componentInParent = renderer.GetComponentInParent<LODGroup>();
			if (!(componentInParent != null))
			{
				continue;
			}
			bool flag = true;
			LOD[] lODs = componentInParent.GetLODs();
			for (int j = 0; j < lODs.Length; j++)
			{
				for (int k = 0; k < lODs[j].renderers.Length; k++)
				{
					if (lODs[j].renderers[k] != renderer)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				componentInParent.enabled = show;
			}
		}
	}

	public virtual void ClearMesh()
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.ClearMesh();
	}

	public virtual void ClearMesh(MB2_EditorMethodsInterface editorMethods)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.ClearMesh(editorMethods);
	}

	public virtual void DestroyMesh()
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.DestroyMesh();
	}

	public virtual void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods)
	{
		meshCombiner.DestroyMeshEditor(editorMethods);
	}

	public virtual int GetNumObjectsInCombined()
	{
		return meshCombiner.GetNumObjectsInCombined();
	}

	public MB3_TextureBaker GetTextureBaker()
	{
		MB3_TextureBaker component = GetComponent<MB3_TextureBaker>();
		if (component != null)
		{
			return component;
		}
		if (base.transform.parent != null && base.gameObject.transform.parent != null)
		{
			return base.transform.parent.GetComponent<MB3_TextureBaker>();
		}
		return null;
	}

	public abstract bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true);

	public abstract bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource = true);

	public virtual bool Apply(MB3_MeshCombiner.GenerateUV2Delegate uv2GenerationMethod = null)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.name = base.name + "-mesh";
		bool result = meshCombiner.Apply(uv2GenerationMethod);
		if (parentSceneObject != null && meshCombiner.resultSceneObject != null)
		{
			meshCombiner.resultSceneObject.transform.parent = parentSceneObject;
		}
		return result;
	}

	public virtual bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, MB3_MeshCombiner.GenerateUV2Delegate uv2GenerationMethod = null)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.name = base.name + "-mesh";
		bool result = meshCombiner.Apply(triangles, vertices, normals, tangents, uvs, uv2, uv3, uv4, colors, bones, blendShapesFlag, uv2GenerationMethod);
		if (parentSceneObject != null && meshCombiner.resultSceneObject != null)
		{
			meshCombiner.resultSceneObject.transform.parent = parentSceneObject;
		}
		return result;
	}

	public virtual bool CombinedMeshContains(GameObject go)
	{
		return meshCombiner.CombinedMeshContains(go);
	}

	public virtual bool UpdateGameObjects(GameObject[] gos)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.name = base.name + "-mesh";
		return meshCombiner.UpdateGameObjects(gos, recalcBounds: true, updateVertices: true, updateNormals: true, updateTangents: true, updateUV: true, updateUV2: false, updateUV3: false, updateUV4: false, updateUV5: false, updateUV6: false, updateUV7: false, updateUV8: false, updateColors: false, updateSkinningInfo: false);
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool updateBounds)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.name = base.name + "-mesh";
		return meshCombiner.UpdateGameObjects(gos, recalcBounds: true, updateVertices: true, updateNormals: true, updateTangents: true, updateUV: true, updateUV2: false, updateUV3: false, updateUV4: false, updateUV5: false, updateUV6: false, updateUV7: false, updateUV8: false, updateColors: false, updateSkinningInfo: false);
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV1, bool updateUV2, bool updateColors, bool updateSkinningInfo)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.name = base.name + "-mesh";
		return meshCombiner.UpdateGameObjects(gos, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3: false, updateUV4: false, updateColors, updateSkinningInfo);
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
	{
		UpgradeToCurrentVersionIfNecessary();
		meshCombiner.name = base.name + "-mesh";
		return meshCombiner.UpdateGameObjects(gos, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5, updateUV6, updateUV7, updateUV8, updateColors, updateSkinningInfo);
	}

	public virtual void UpdateSkinnedMeshApproximateBounds()
	{
		if (_ValidateForUpdateSkinnedMeshBounds())
		{
			meshCombiner.UpdateSkinnedMeshApproximateBounds();
		}
	}

	public virtual void UpdateSkinnedMeshApproximateBoundsFromBones()
	{
		if (_ValidateForUpdateSkinnedMeshBounds())
		{
			meshCombiner.UpdateSkinnedMeshApproximateBoundsFromBones();
		}
	}

	public virtual void UpdateSkinnedMeshApproximateBoundsFromBounds()
	{
		if (_ValidateForUpdateSkinnedMeshBounds())
		{
			meshCombiner.UpdateSkinnedMeshApproximateBoundsFromBounds();
		}
	}

	protected virtual bool _ValidateForUpdateSkinnedMeshBounds()
	{
		if (meshCombiner.outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
		{
			UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBounds when output type is bakeMeshAssetsInPlace");
			return false;
		}
		if (meshCombiner.resultSceneObject == null)
		{
			UnityEngine.Debug.LogWarning("Result Scene Object does not exist. No point in calling UpdateSkinnedMeshApproximateBounds.");
			return false;
		}
		if (meshCombiner.resultSceneObject.GetComponentInChildren<SkinnedMeshRenderer>() == null)
		{
			UnityEngine.Debug.LogWarning("No SkinnedMeshRenderer on result scene object.");
			return false;
		}
		return true;
	}
}
public class MB3_MeshBakerGrouper : MonoBehaviour, MB_IMeshBakerSettingsHolder
{
	public enum ClusterType
	{
		none,
		grid,
		pie,
		agglomerative
	}

	public static readonly Color WHITE_TRANSP = new Color(1f, 1f, 1f, 0.1f);

	public MB3_MeshBakerGrouperBehaviour grouper;

	public ClusterType clusterType;

	public Transform parentSceneObject;

	public GrouperData data;

	[HideInInspector]
	public Bounds sourceObjectBounds = new Bounds(Vector3.zero, Vector3.one);

	public string prefabOptions_outputFolder = "";

	public bool prefabOptions_autoGeneratePrefabs;

	public bool prefabOptions_mergeOutputIntoSinglePrefab;

	public MB3_MeshCombinerSettings meshBakerSettingsAsset;

	public MB3_MeshCombinerSettingsData meshBakerSettings;

	public MB_IMeshBakerSettings GetMeshBakerSettings()
	{
		if (meshBakerSettingsAsset == null)
		{
			if (meshBakerSettings == null)
			{
				meshBakerSettings = new MB3_MeshCombinerSettingsData();
			}
			return meshBakerSettings;
		}
		return meshBakerSettingsAsset.GetMeshBakerSettings();
	}

	public void GetMeshBakerSettingsAsSerializedProperty(out string propertyName, out UnityEngine.Object targetObj)
	{
		if (meshBakerSettingsAsset == null)
		{
			targetObj = this;
			propertyName = "meshBakerSettings";
		}
		else
		{
			targetObj = meshBakerSettingsAsset;
			propertyName = "data";
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (grouper == null)
		{
			grouper = CreateGrouper(clusterType);
		}
		grouper.DrawGizmos(sourceObjectBounds, data);
	}

	public MB3_MeshBakerGrouperBehaviour CreateGrouper(ClusterType t)
	{
		if (t == ClusterType.grid)
		{
			grouper = new MB3_MeshBakerGrouperGrid();
		}
		if (t == ClusterType.pie)
		{
			grouper = new MB3_MeshBakerGrouperPie();
		}
		if (t == ClusterType.agglomerative)
		{
			grouper = new MB3_MeshBakerGrouperCluster();
		}
		if (t == ClusterType.none)
		{
			grouper = new MB3_MeshBakerGrouperNone();
		}
		return grouper;
	}

	public void DeleteAllChildMeshBakers()
	{
		MB3_MeshBakerCommon[] componentsInChildren = GetComponentsInChildren<MB3_MeshBakerCommon>();
		foreach (MB3_MeshBakerCommon obj in componentsInChildren)
		{
			MB_Utility.Destroy(obj.meshCombiner.resultSceneObject);
			MB_Utility.Destroy(obj.gameObject);
		}
	}

	public List<MB3_MeshBakerCommon> GenerateMeshBakers()
	{
		MB3_TextureBaker component = GetComponent<MB3_TextureBaker>();
		if (component == null)
		{
			UnityEngine.Debug.LogError("There must be an MB3_TextureBaker attached to this game object.");
			return new List<MB3_MeshBakerCommon>();
		}
		if (component.GetObjectsToCombine().Count == 0)
		{
			UnityEngine.Debug.LogError("The MB3_MeshBakerGrouper creates clusters based on the objects to combine in the MB3_TextureBaker component. There were no objects in this list.");
			return new List<MB3_MeshBakerCommon>();
		}
		if (parentSceneObject == null || !MB_Utility.IsSceneInstance(parentSceneObject.gameObject))
		{
			GameObject gameObject = new GameObject("CombinedMeshes-" + base.name);
			parentSceneObject = gameObject.transform;
		}
		List<GameObject> objectsToCombine = component.GetObjectsToCombine();
		MB3_MeshBakerCommon[] componentsInChildren = GetComponentsInChildren<MB3_MeshBakerCommon>();
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			List<GameObject> objectsToCombine2 = componentsInChildren[i].GetObjectsToCombine();
			for (int j = 0; j < objectsToCombine2.Count; j++)
			{
				if (objectsToCombine2[j] != null && objectsToCombine.Contains(objectsToCombine2[j]))
				{
					flag = true;
					break;
				}
			}
		}
		bool flag2 = true;
		if (flag)
		{
			flag2 = false;
			UnityEngine.Debug.LogError("There are previously generated MeshBaker objects. Please use the editor to delete or replace them");
		}
		if (Application.isPlaying && prefabOptions_autoGeneratePrefabs)
		{
			UnityEngine.Debug.LogError("Can only use Auto Generate Prefabs in the editor when the game is not playing.");
			flag2 = false;
		}
		if (flag2)
		{
			if (flag)
			{
				DeleteAllChildMeshBakers();
			}
			if (grouper == null || grouper.GetClusterType() != clusterType)
			{
				grouper = CreateGrouper(clusterType);
			}
			return grouper.DoClustering(component, this, data);
		}
		return new List<MB3_MeshBakerCommon>();
	}
}
public abstract class MB3_MeshBakerRoot : MonoBehaviour
{
	public class ZSortObjects
	{
		public class Item
		{
			public GameObject go;

			public Vector3 point;
		}

		public class ItemComparer : IComparer<Item>
		{
			public int Compare(Item a, Item b)
			{
				return (int)Mathf.Sign(b.point.z - a.point.z);
			}
		}

		public Vector3 sortAxis;

		public void SortByDistanceAlongAxis(List<GameObject> gos)
		{
			if (sortAxis == Vector3.zero)
			{
				UnityEngine.Debug.LogError("The sort axis cannot be the zero vector.");
				return;
			}
			UnityEngine.Debug.Log("Z sorting meshes along axis numObjs=" + gos.Count);
			List<Item> list = new List<Item>();
			Quaternion quaternion = Quaternion.FromToRotation(sortAxis, Vector3.forward);
			for (int i = 0; i < gos.Count; i++)
			{
				if (gos[i] != null)
				{
					Item item = new Item();
					item.point = gos[i].transform.position;
					item.go = gos[i];
					item.point = quaternion * item.point;
					list.Add(item);
				}
			}
			list.Sort(new ItemComparer());
			for (int j = 0; j < gos.Count; j++)
			{
				gos[j] = list[j].go;
			}
		}
	}

	public Vector3 sortAxis;

	[HideInInspector]
	public abstract MB2_TextureBakeResults textureBakeResults { get; set; }

	public virtual List<GameObject> GetObjectsToCombine()
	{
		return null;
	}

	public virtual void PurgeNullsFromObjectsToCombine()
	{
	}

	public static bool DoCombinedValidate(MB3_MeshBakerRoot mom, MB_ObjsToCombineTypes objToCombineType, MB2_EditorMethodsInterface editorMethods, MB2_ValidationLevel validationLevel)
	{
		if (mom.textureBakeResults == null)
		{
			UnityEngine.Debug.LogError("Need to set Texture Bake Result on " + mom);
			return false;
		}
		if (mom is MB3_MeshBakerCommon)
		{
			MB3_TextureBaker textureBaker = ((MB3_MeshBakerCommon)mom).GetTextureBaker();
			if (textureBaker != null && textureBaker.textureBakeResults != mom.textureBakeResults)
			{
				UnityEngine.Debug.LogWarning("Texture Bake Result on this component is not the same as the Texture Bake Result on the MB3_TextureBaker.");
			}
		}
		List<GameObject> objectsToCombine = mom.GetObjectsToCombine();
		if (!ValidateTextureBakerGameObjects(mom, objectsToCombine, validationLevel))
		{
			return false;
		}
		if (mom is MB3_MeshBaker)
		{
			List<GameObject> objectsToCombine2 = mom.GetObjectsToCombine();
			if (objectsToCombine2 == null || objectsToCombine2.Count == 0)
			{
				UnityEngine.Debug.LogError("No meshes to combine. Please assign some meshes to combine.");
				return false;
			}
			if (mom is MB3_MeshBaker && ((MB3_MeshBaker)mom).meshCombiner.settings.renderType == MB_RenderType.skinnedMeshRenderer && !editorMethods.ValidateSkinnedMeshes(objectsToCombine2))
			{
				return false;
			}
		}
		editorMethods?.CheckPrefabTypes(objToCombineType, objectsToCombine);
		return true;
	}

	public static bool ValidateTextureBakerGameObjects(MB3_MeshBakerRoot mom, List<GameObject> objsToMesh, MB2_ValidationLevel validationLevel)
	{
		Dictionary<int, MB_Utility.MeshAnalysisResult> dictionary = null;
		if (validationLevel == MB2_ValidationLevel.robust)
		{
			dictionary = new Dictionary<int, MB_Utility.MeshAnalysisResult>();
		}
		Dictionary<string, Material> dictionary2 = new Dictionary<string, Material>();
		for (int i = 0; i < objsToMesh.Count; i++)
		{
			GameObject gameObject = objsToMesh[i];
			if (gameObject == null)
			{
				UnityEngine.Debug.LogError($"The list of objects to combine contains a null at position {i}. Select and use [shift + delete] to remove the object, or purge all null objects from the context menu.");
				return false;
			}
			for (int j = i + 1; j < objsToMesh.Count; j++)
			{
				if (objsToMesh[i] == objsToMesh[j])
				{
					UnityEngine.Debug.LogError("The list of objects to combine contains duplicates at " + i + " and " + j);
					return false;
				}
			}
			Material[] gOMaterials = MB_Utility.GetGOMaterials(gameObject);
			if (gOMaterials.Length == 0)
			{
				UnityEngine.Debug.LogError("Object " + gameObject?.ToString() + " in the list of objects to be combined does not have a material");
				return false;
			}
			Mesh mesh = MB_Utility.GetMesh(gameObject);
			if (mesh == null)
			{
				UnityEngine.Debug.LogError("Object " + gameObject?.ToString() + " in the list of objects to be combined does not have a mesh");
				return false;
			}
			if (mesh != null && mom.textureBakeResults != null && Application.isEditor && !Application.isPlaying && mom.textureBakeResults.doMultiMaterial && validationLevel >= MB2_ValidationLevel.robust)
			{
				if (!dictionary.TryGetValue(mesh.GetInstanceID(), out var value))
				{
					MB_Utility.doSubmeshesShareVertsOrTris(mesh, ref value);
					dictionary.Add(mesh.GetInstanceID(), value);
				}
				if (value.hasOverlappingSubmeshVerts)
				{
					UnityEngine.Debug.LogWarning("Object " + objsToMesh[i]?.ToString() + " in the list of objects to combine has overlapping submeshes (submeshes share vertices). If the UVs associated with the shared vertices are important then this bake may not work. If you are using multiple materials then this object can only be combined with objects that use the exact same set of textures (each atlas contains one texture). There may be other undesirable side affects as well. Mesh Master, available in the asset store can fix overlapping submeshes.");
				}
			}
			if (!MBVersion.IsUsingAddressables())
			{
				continue;
			}
			HashSet<string> hashSet = new HashSet<string>();
			for (int k = 0; k < gOMaterials.Length; k++)
			{
				if (!(gOMaterials[k] != null))
				{
					continue;
				}
				if (dictionary2.ContainsKey(gOMaterials[k].name))
				{
					if (gOMaterials[k] != dictionary2[gOMaterials[k].name])
					{
						hashSet.Add(gOMaterials[k].name);
					}
				}
				else
				{
					dictionary2.Add(gOMaterials[k].name, gOMaterials[k]);
				}
			}
			if (hashSet.Count > 0)
			{
				string[] array = new string[hashSet.Count];
				hashSet.CopyTo(array);
				string text = string.Join(",", array);
				UnityEngine.Debug.LogError("The source objects use different materials that have the same name (" + text + "). If using addressables, materials with the same name are considered to be the same material when baking meshes at runtime. If you want to use this Material Bake Result at runtime then all source materials must have distinct names. Baking in edit-mode will still work.");
			}
		}
		return true;
	}
}
public class MB3_MultiMeshBaker : MB3_MeshBakerCommon
{
	[SerializeField]
	protected MB3_MultiMeshCombiner _meshCombiner = new MB3_MultiMeshCombiner();

	public override MB3_MeshCombiner meshCombiner => _meshCombiner;

	public void PrintTimings()
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		for (int i = 0; i < _meshCombiner.meshCombiners.Count; i++)
		{
			MB3_MeshCombinerSingle combinedMesh = _meshCombiner.meshCombiners[i].combinedMesh;
			num += combinedMesh.db_showHideGameObjects.Elapsed.TotalSeconds;
			num2 += combinedMesh.db_addDeleteGameObjects.Elapsed.TotalSeconds;
			num7 += combinedMesh.db_addDeleteGameObjects_CollectMeshData.Elapsed.TotalSeconds;
			num3 += combinedMesh.db_addDeleteGameObjects_InitFromMeshCombiner.Elapsed.TotalSeconds;
			num4 += combinedMesh.db_addDeleteGameObjects_Init.Elapsed.TotalSeconds;
			num5 += combinedMesh.db_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers.Elapsed.TotalSeconds;
			num6 += combinedMesh.db_addDeleteGameObjects_CopyFromDGOMeshToBuffers.Elapsed.TotalSeconds;
			num8 += combinedMesh.db_apply.Elapsed.TotalSeconds;
			num9 += combinedMesh.db_applyShowHide.Elapsed.TotalSeconds;
			num10 += combinedMesh.db_updateGameObjects.Elapsed.TotalSeconds;
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Timings  " + ((_meshCombiner.settings.meshAPI == MB_MeshCombineAPIType.betaNativeArrayAPI) ? "  newMeshAPI " : " oldMeshAPI"));
		stringBuilder.AppendLine("db_showHideGameObjects\t" + num);
		stringBuilder.AppendLine("db_addDeleteGameObjects\t" + num2);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshData\t" + num7);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_InitFromMeshCombiner\t" + num3);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_Init\t" + num4);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers\t" + num5);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CopyFromDGOMeshToBuffers\t" + num6);
		stringBuilder.AppendLine("\t\tdb_addDeleteGameObjects_CollectMeshData  tdb_addDeleteGameObjects_CollectMeshData ");
		stringBuilder.AppendLine("db_apply\t" + num8);
		stringBuilder.AppendLine("db_applyShowHide\t" + num9);
		stringBuilder.AppendLine("db_updateGameObjects\t" + num10);
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}

	public override bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource)
	{
		UpgradeToCurrentVersionIfNecessary();
		if (_meshCombiner.resultSceneObject == null)
		{
			_meshCombiner.resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		meshCombiner.name = base.name + "-mesh";
		return _meshCombiner.AddDeleteGameObjects(gos, deleteGOs, disableRendererInSource);
	}

	public override bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOs, bool disableRendererInSource)
	{
		UpgradeToCurrentVersionIfNecessary();
		if (_meshCombiner.resultSceneObject == null)
		{
			_meshCombiner.resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		meshCombiner.name = base.name + "-mesh";
		return _meshCombiner.AddDeleteGameObjectsByID(gos, deleteGOs, disableRendererInSource);
	}

	public void OnDestroy()
	{
		if (_meshCombiner != null)
		{
			_meshCombiner.Dispose();
		}
	}
}
public class MB3_TextureBaker : MB3_MeshBakerRoot
{
	public delegate void OnCombinedTexturesCoroutineSuccess();

	public delegate void OnCombinedTexturesCoroutineFail();

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	[SerializeField]
	protected MB2_TextureBakeResults _textureBakeResults;

	[SerializeField]
	protected int _atlasPadding = 1;

	[SerializeField]
	protected int _maxAtlasSize = 8192;

	[SerializeField]
	protected bool _useMaxAtlasWidthOverride;

	[SerializeField]
	protected int _maxAtlasWidthOverride = 8192;

	[SerializeField]
	protected bool _useMaxAtlasHeightOverride;

	[SerializeField]
	protected int _maxAtlasHeightOverride = 8192;

	[SerializeField]
	protected bool _resizePowerOfTwoTextures;

	[SerializeField]
	protected bool _fixOutOfBoundsUVs;

	[SerializeField]
	protected int _maxTilingBakeSize = 1024;

	[SerializeField]
	protected MB2_PackingAlgorithmEnum _packingAlgorithm = MB2_PackingAlgorithmEnum.MeshBakerTexturePacker;

	[SerializeField]
	protected int _layerTexturePackerFastMesh = -1;

	[SerializeField]
	protected bool _meshBakerTexturePackerForcePowerOfTwo = true;

	[SerializeField]
	[NonReorderable]
	protected List<ShaderTextureProperty> _customShaderProperties = new List<ShaderTextureProperty>();

	[SerializeField]
	[NonReorderable]
	protected List<string> _texturePropNamesToIgnore = new List<string>();

	[SerializeField]
	protected List<string> _customShaderPropNames_Depricated = new List<string>();

	[SerializeField]
	protected MB2_TextureBakeResults.ResultType _resultType;

	[SerializeField]
	protected bool _doMultiMaterial;

	[SerializeField]
	protected bool _doMultiMaterialSplitAtlasesIfTooBig = true;

	[SerializeField]
	protected bool _doMultiMaterialSplitAtlasesIfOBUVs = true;

	[SerializeField]
	protected Material _resultMaterial;

	[SerializeField]
	protected bool _considerNonTextureProperties;

	[SerializeField]
	protected bool _doSuggestTreatment = true;

	private MB3_TextureCombiner.CreateAtlasesCoroutineResult _coroutineResult;

	[NonReorderable]
	public MB_MultiMaterial[] resultMaterials = new MB_MultiMaterial[0];

	[NonReorderable]
	public MB_MultiMaterialTexArray[] resultMaterialsTexArray = new MB_MultiMaterialTexArray[0];

	[NonReorderable]
	public MB_TextureArrayFormatSet[] textureArrayOutputFormats;

	[NonReorderable]
	public List<GameObject> objsToMesh;

	public OnCombinedTexturesCoroutineSuccess onBuiltAtlasesSuccess;

	public OnCombinedTexturesCoroutineFail onBuiltAtlasesFail;

	public MB_AtlasesAndRects[] OnCombinedTexturesCoroutineAtlasesAndRects;

	public override MB2_TextureBakeResults textureBakeResults
	{
		get
		{
			return _textureBakeResults;
		}
		set
		{
			_textureBakeResults = value;
		}
	}

	public virtual int atlasPadding
	{
		get
		{
			return _atlasPadding;
		}
		set
		{
			_atlasPadding = value;
		}
	}

	public virtual int maxAtlasSize
	{
		get
		{
			return _maxAtlasSize;
		}
		set
		{
			_maxAtlasSize = value;
		}
	}

	public virtual bool useMaxAtlasWidthOverride
	{
		get
		{
			return _useMaxAtlasWidthOverride;
		}
		set
		{
			_useMaxAtlasWidthOverride = value;
		}
	}

	public virtual int maxAtlasWidthOverride
	{
		get
		{
			return _maxAtlasWidthOverride;
		}
		set
		{
			_maxAtlasWidthOverride = value;
		}
	}

	public virtual bool useMaxAtlasHeightOverride
	{
		get
		{
			return _useMaxAtlasHeightOverride;
		}
		set
		{
			_useMaxAtlasHeightOverride = value;
		}
	}

	public virtual int maxAtlasHeightOverride
	{
		get
		{
			return _maxAtlasHeightOverride;
		}
		set
		{
			_maxAtlasHeightOverride = value;
		}
	}

	public virtual bool resizePowerOfTwoTextures
	{
		get
		{
			return _resizePowerOfTwoTextures;
		}
		set
		{
			_resizePowerOfTwoTextures = value;
		}
	}

	public virtual bool fixOutOfBoundsUVs
	{
		get
		{
			return _fixOutOfBoundsUVs;
		}
		set
		{
			_fixOutOfBoundsUVs = value;
		}
	}

	public virtual int maxTilingBakeSize
	{
		get
		{
			return _maxTilingBakeSize;
		}
		set
		{
			_maxTilingBakeSize = value;
		}
	}

	public virtual MB2_PackingAlgorithmEnum packingAlgorithm
	{
		get
		{
			return _packingAlgorithm;
		}
		set
		{
			_packingAlgorithm = value;
		}
	}

	public virtual int layerForTexturePackerFastMesh
	{
		get
		{
			return _layerTexturePackerFastMesh;
		}
		set
		{
			_layerTexturePackerFastMesh = value;
		}
	}

	public bool meshBakerTexturePackerForcePowerOfTwo
	{
		get
		{
			return _meshBakerTexturePackerForcePowerOfTwo;
		}
		set
		{
			_meshBakerTexturePackerForcePowerOfTwo = value;
		}
	}

	public virtual List<ShaderTextureProperty> customShaderProperties
	{
		get
		{
			return _customShaderProperties;
		}
		set
		{
			_customShaderProperties = value;
		}
	}

	public virtual List<string> texturePropNamesToIgnore
	{
		get
		{
			return _texturePropNamesToIgnore;
		}
		set
		{
			_texturePropNamesToIgnore = value;
		}
	}

	public virtual List<string> customShaderPropNames
	{
		get
		{
			return _customShaderPropNames_Depricated;
		}
		set
		{
			_customShaderPropNames_Depricated = value;
		}
	}

	public virtual MB2_TextureBakeResults.ResultType resultType
	{
		get
		{
			return _resultType;
		}
		set
		{
			_resultType = value;
		}
	}

	public virtual bool doMultiMaterial
	{
		get
		{
			return _doMultiMaterial;
		}
		set
		{
			_doMultiMaterial = value;
		}
	}

	public virtual bool doMultiMaterialSplitAtlasesIfTooBig
	{
		get
		{
			return _doMultiMaterialSplitAtlasesIfTooBig;
		}
		set
		{
			_doMultiMaterialSplitAtlasesIfTooBig = value;
		}
	}

	public virtual bool doMultiMaterialSplitAtlasesIfOBUVs
	{
		get
		{
			return _doMultiMaterialSplitAtlasesIfOBUVs;
		}
		set
		{
			_doMultiMaterialSplitAtlasesIfOBUVs = value;
		}
	}

	public virtual Material resultMaterial
	{
		get
		{
			return _resultMaterial;
		}
		set
		{
			_resultMaterial = value;
		}
	}

	public bool considerNonTextureProperties
	{
		get
		{
			return _considerNonTextureProperties;
		}
		set
		{
			_considerNonTextureProperties = value;
		}
	}

	public bool doSuggestTreatment
	{
		get
		{
			return _doSuggestTreatment;
		}
		set
		{
			_doSuggestTreatment = value;
		}
	}

	public MB3_TextureCombiner.CreateAtlasesCoroutineResult CoroutineResult => _coroutineResult;

	public override List<GameObject> GetObjectsToCombine()
	{
		if (objsToMesh == null)
		{
			objsToMesh = new List<GameObject>();
		}
		return objsToMesh;
	}

	[ContextMenu("Purge Objects to Combine of null references")]
	public override void PurgeNullsFromObjectsToCombine()
	{
		if (objsToMesh == null)
		{
			objsToMesh = new List<GameObject>();
		}
		UnityEngine.Debug.Log($"Purged {objsToMesh.RemoveAll((GameObject obj) => obj == null)} null references from objects to combine list.");
	}

	public MB_AtlasesAndRects[] CreateAtlases()
	{
		return CreateAtlases(null);
	}

	public IEnumerator CreateAtlasesCoroutine(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		yield return _CreateAtlasesCoroutine(progressInfo, coroutineResult, saveAtlasesAsAssets, editorMethods, maxTimePerFrame);
		if (coroutineResult.success && onBuiltAtlasesSuccess != null)
		{
			onBuiltAtlasesSuccess();
		}
		if (!coroutineResult.success && onBuiltAtlasesFail != null)
		{
			onBuiltAtlasesFail();
		}
	}

	private IEnumerator _CreateAtlasesCoroutineAtlases(MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		int num = 1;
		if (_doMultiMaterial)
		{
			num = resultMaterials.Length;
		}
		OnCombinedTexturesCoroutineAtlasesAndRects = new MB_AtlasesAndRects[num];
		for (int i = 0; i < OnCombinedTexturesCoroutineAtlasesAndRects.Length; i++)
		{
			OnCombinedTexturesCoroutineAtlasesAndRects[i] = new MB_AtlasesAndRects();
		}
		for (int j = 0; j < OnCombinedTexturesCoroutineAtlasesAndRects.Length; j++)
		{
			List<Material> allowedMaterialsFilter = null;
			Material combinedMaterial;
			if (_doMultiMaterial)
			{
				allowedMaterialsFilter = resultMaterials[j].sourceMaterials;
				combinedMaterial = resultMaterials[j].combinedMaterial;
				combiner.fixOutOfBoundsUVs = resultMaterials[j].considerMeshUVs;
			}
			else
			{
				combinedMaterial = _resultMaterial;
			}
			MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult coroutineResult2 = new MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult();
			yield return combiner.CombineTexturesIntoAtlasesCoroutine(progressInfo, OnCombinedTexturesCoroutineAtlasesAndRects[j], combinedMaterial, objsToMesh, allowedMaterialsFilter, texturePropNamesToIgnore, editorMethods, coroutineResult2, maxTimePerFrame);
			coroutineResult.success = coroutineResult2.success;
			if (!coroutineResult.success)
			{
				coroutineResult.isFinished = true;
				yield break;
			}
		}
		unpackMat2RectMap(OnCombinedTexturesCoroutineAtlasesAndRects);
		if (coroutineResult.success)
		{
			editorMethods?.GetMaterialPrimaryKeysIfAddressables(textureBakeResults);
		}
		textureBakeResults.resultType = MB2_TextureBakeResults.ResultType.atlas;
		textureBakeResults.resultMaterialsTexArray = new MB_MultiMaterialTexArray[0];
		textureBakeResults.doMultiMaterial = _doMultiMaterial;
		if (_doMultiMaterial)
		{
			textureBakeResults.resultMaterials = resultMaterials;
		}
		else
		{
			MB_MultiMaterial[] array = new MB_MultiMaterial[1]
			{
				new MB_MultiMaterial()
			};
			array[0].combinedMaterial = _resultMaterial;
			array[0].considerMeshUVs = _fixOutOfBoundsUVs;
			array[0].sourceMaterials = new List<Material>();
			for (int k = 0; k < textureBakeResults.materialsAndUVRects.Length; k++)
			{
				array[0].sourceMaterials.Add(textureBakeResults.materialsAndUVRects[k].material);
			}
			textureBakeResults.resultMaterials = array;
		}
		if (LOG_LEVEL >= MB2_LogLevel.info)
		{
			UnityEngine.Debug.Log("Created Atlases");
		}
	}

	internal IEnumerator _CreateAtlasesCoroutineTextureArray(MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		if (textureArrayOutputFormats == null || textureArrayOutputFormats.Length == 0)
		{
			UnityEngine.Debug.LogError("No Texture Array Output Formats. There must be at least one entry.");
			coroutineResult.isFinished = true;
			yield break;
		}
		for (int i = 0; i < textureArrayOutputFormats.Length; i++)
		{
			if (!textureArrayOutputFormats[i].ValidateTextureImporterFormatsExistsForTextureFormats(editorMethods, i))
			{
				UnityEngine.Debug.LogError("Could not map the selected texture format to a Texture Importer Format. Safest options are ARGB32, or RGB24.");
				coroutineResult.isFinished = true;
				yield break;
			}
		}
		for (int j = 0; j < resultMaterialsTexArray.Length; j++)
		{
			MB_MultiMaterialTexArray mB_MultiMaterialTexArray = resultMaterialsTexArray[j];
			if (mB_MultiMaterialTexArray.combinedMaterial == null)
			{
				UnityEngine.Debug.LogError("Material is null for Texture Array Slice Configuration: " + j + ".");
				coroutineResult.isFinished = true;
				yield break;
			}
			List<MB_TexArraySlice> slices = mB_MultiMaterialTexArray.slices;
			for (int k = 0; k < slices.Count; k++)
			{
				for (int l = 0; l < slices[k].sourceMaterials.Count; l++)
				{
					MB_TexArraySliceRendererMatPair mB_TexArraySliceRendererMatPair = slices[k].sourceMaterials[l];
					if (mB_TexArraySliceRendererMatPair.sourceMaterial == null)
					{
						UnityEngine.Debug.LogError("Source material is null for Texture Array Slice Configuration: " + j + " slice: " + k);
						coroutineResult.isFinished = true;
						yield break;
					}
					if (slices[k].considerMeshUVs && mB_TexArraySliceRendererMatPair.renderer == null)
					{
						UnityEngine.Debug.LogError("Renderer is null for Texture Array Slice Configuration: " + j + " slice: " + k + ". If considerUVs is enabled then a renderer must be supplied for each source material. The same source material can be used multiple times.");
						coroutineResult.isFinished = true;
						yield break;
					}
				}
			}
		}
		int num = resultMaterialsTexArray.Length;
		MB_TextureArrayResultMaterial[] bakedMatsAndSlices = new MB_TextureArrayResultMaterial[num];
		for (int m = 0; m < bakedMatsAndSlices.Length; m++)
		{
			bakedMatsAndSlices[m] = new MB_TextureArrayResultMaterial();
			int count = resultMaterialsTexArray[m].slices.Count;
			MB_AtlasesAndRects[] array = (bakedMatsAndSlices[m].slices = new MB_AtlasesAndRects[count]);
			for (int n = 0; n < count; n++)
			{
				array[n] = new MB_AtlasesAndRects();
			}
		}
		for (int resMatIdx = 0; resMatIdx < bakedMatsAndSlices.Length; resMatIdx++)
		{
			yield return MB_TextureArrays._CreateAtlasesCoroutineSingleResultMaterial(resMatIdx, bakedMatsAndSlices[resMatIdx], resultMaterialsTexArray[resMatIdx], objsToMesh, combiner, textureArrayOutputFormats, resultMaterialsTexArray, customShaderProperties, texturePropNamesToIgnore, progressInfo, coroutineResult, saveAtlasesAsAssets, editorMethods, maxTimePerFrame);
			if (!coroutineResult.success)
			{
				yield break;
			}
		}
		if (coroutineResult.success)
		{
			unpackMat2RectMap(bakedMatsAndSlices);
			editorMethods?.GetMaterialPrimaryKeysIfAddressables(textureBakeResults);
			textureBakeResults.resultType = MB2_TextureBakeResults.ResultType.textureArray;
			textureBakeResults.resultMaterials = new MB_MultiMaterial[0];
			textureBakeResults.resultMaterialsTexArray = resultMaterialsTexArray;
			if (LOG_LEVEL >= MB2_LogLevel.info)
			{
				UnityEngine.Debug.Log("Created Texture2DArrays");
			}
		}
		else if (LOG_LEVEL >= MB2_LogLevel.info)
		{
			UnityEngine.Debug.Log("Failed to create Texture2DArrays");
		}
	}

	private IEnumerator _CreateAtlasesCoroutine(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		new MBVersionConcrete();
		OnCombinedTexturesCoroutineAtlasesAndRects = null;
		if (maxTimePerFrame <= 0f)
		{
			UnityEngine.Debug.LogError("maxTimePerFrame must be a value greater than zero");
			coroutineResult.isFinished = true;
			yield break;
		}
		MB2_ValidationLevel validationLevel = (Application.isPlaying ? MB2_ValidationLevel.quick : MB2_ValidationLevel.robust);
		if (!MB3_MeshBakerRoot.DoCombinedValidate(this, MB_ObjsToCombineTypes.dontCare, null, validationLevel))
		{
			coroutineResult.isFinished = true;
			yield break;
		}
		if (_doMultiMaterial && !_ValidateResultMaterials())
		{
			coroutineResult.isFinished = true;
			yield break;
		}
		if (resultType != MB2_TextureBakeResults.ResultType.textureArray && !_doMultiMaterial)
		{
			if (_resultMaterial == null)
			{
				UnityEngine.Debug.LogError("Combined Material is null please create and assign a result material.");
				coroutineResult.isFinished = true;
				yield break;
			}
			Shader shader = _resultMaterial.shader;
			for (int i = 0; i < objsToMesh.Count; i++)
			{
				Material[] gOMaterials = MB_Utility.GetGOMaterials(objsToMesh[i]);
				foreach (Material material in gOMaterials)
				{
					if (material != null && material.shader != shader)
					{
						UnityEngine.Debug.LogWarning("Game object " + objsToMesh[i]?.ToString() + " does not use shader " + shader?.ToString() + " it may not have the required textures. If not small solid color textures will be generated.");
					}
				}
			}
		}
		MB3_TextureCombiner mB3_TextureCombiner = CreateAndConfigureTextureCombiner();
		mB3_TextureCombiner.saveAtlasesAsAssets = saveAtlasesAsAssets;
		OnCombinedTexturesCoroutineAtlasesAndRects = null;
		if (resultType == MB2_TextureBakeResults.ResultType.textureArray)
		{
			yield return _CreateAtlasesCoroutineTextureArray(mB3_TextureCombiner, progressInfo, coroutineResult, saveAtlasesAsAssets, editorMethods, maxTimePerFrame);
			if (!coroutineResult.success)
			{
				yield break;
			}
		}
		else
		{
			yield return _CreateAtlasesCoroutineAtlases(mB3_TextureCombiner, progressInfo, coroutineResult, saveAtlasesAsAssets, editorMethods, maxTimePerFrame);
			if (!coroutineResult.success)
			{
				yield break;
			}
		}
		MB3_MeshBakerCommon[] componentsInChildren = GetComponentsInChildren<MB3_MeshBakerCommon>();
		for (int k = 0; k < componentsInChildren.Length; k++)
		{
			componentsInChildren[k].textureBakeResults = textureBakeResults;
		}
		coroutineResult.isFinished = true;
	}

	public MB_AtlasesAndRects[] CreateAtlases(ProgressUpdateDelegate progressInfo, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null)
	{
		MB_AtlasesAndRects[] array = null;
		try
		{
			_coroutineResult = new MB3_TextureCombiner.CreateAtlasesCoroutineResult();
			MB3_TextureCombiner.RunCorutineWithoutPause(CreateAtlasesCoroutine(progressInfo, _coroutineResult, saveAtlasesAsAssets, editorMethods, 1000f), 0);
			if (_coroutineResult.success && textureBakeResults != null)
			{
				array = OnCombinedTexturesCoroutineAtlasesAndRects;
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(ex.Message + "\n" + ex.StackTrace.ToString());
		}
		finally
		{
			if (saveAtlasesAsAssets && array != null)
			{
				foreach (MB_AtlasesAndRects mB_AtlasesAndRects in array)
				{
					if (mB_AtlasesAndRects == null || mB_AtlasesAndRects.atlases == null)
					{
						continue;
					}
					for (int j = 0; j < mB_AtlasesAndRects.atlases.Length; j++)
					{
						if (mB_AtlasesAndRects.atlases[j] != null)
						{
							if (editorMethods != null)
							{
								editorMethods.Destroy(mB_AtlasesAndRects.atlases[j]);
							}
							else
							{
								MB_Utility.Destroy(mB_AtlasesAndRects.atlases[j]);
							}
						}
					}
				}
			}
		}
		return array;
	}

	private void unpackMat2RectMap(MB_AtlasesAndRects[] rawResults)
	{
		List<MB_MaterialAndUVRect> list = new List<MB_MaterialAndUVRect>();
		for (int i = 0; i < rawResults.Length; i++)
		{
			List<MB_MaterialAndUVRect> mat2rect_map = rawResults[i].mat2rect_map;
			if (mat2rect_map != null)
			{
				for (int j = 0; j < mat2rect_map.Count; j++)
				{
					mat2rect_map[j].textureArraySliceIdx = -1;
					list.Add(mat2rect_map[j]);
				}
			}
		}
		textureBakeResults.version = MB2_TextureBakeResults.VERSION;
		textureBakeResults.materialsAndUVRects = list.ToArray();
	}

	internal void unpackMat2RectMap(MB_TextureArrayResultMaterial[] rawResults)
	{
		List<MB_MaterialAndUVRect> list = new List<MB_MaterialAndUVRect>();
		for (int i = 0; i < rawResults.Length; i++)
		{
			MB_AtlasesAndRects[] slices = rawResults[i].slices;
			for (int j = 0; j < slices.Length; j++)
			{
				List<MB_MaterialAndUVRect> mat2rect_map = slices[j].mat2rect_map;
				if (mat2rect_map != null)
				{
					for (int k = 0; k < mat2rect_map.Count; k++)
					{
						mat2rect_map[k].textureArraySliceIdx = j;
						list.Add(mat2rect_map[k]);
					}
				}
			}
		}
		textureBakeResults.version = MB2_TextureBakeResults.VERSION;
		textureBakeResults.materialsAndUVRects = list.ToArray();
	}

	public MB3_TextureCombiner CreateAndConfigureTextureCombiner()
	{
		return new MB3_TextureCombiner
		{
			LOG_LEVEL = LOG_LEVEL,
			atlasPadding = _atlasPadding,
			maxAtlasSize = _maxAtlasSize,
			maxAtlasHeightOverride = _maxAtlasHeightOverride,
			maxAtlasWidthOverride = _maxAtlasWidthOverride,
			useMaxAtlasHeightOverride = _useMaxAtlasHeightOverride,
			useMaxAtlasWidthOverride = _useMaxAtlasWidthOverride,
			customShaderPropNames = _customShaderProperties,
			fixOutOfBoundsUVs = _fixOutOfBoundsUVs,
			maxTilingBakeSize = _maxTilingBakeSize,
			packingAlgorithm = _packingAlgorithm,
			layerTexturePackerFastMesh = _layerTexturePackerFastMesh,
			resultType = _resultType,
			meshBakerTexturePackerForcePowerOfTwo = _meshBakerTexturePackerForcePowerOfTwo,
			resizePowerOfTwoTextures = _resizePowerOfTwoTextures,
			considerNonTextureProperties = _considerNonTextureProperties
		};
	}

	public static void ConfigureNewMaterialToMatchOld(Material newMat, Material original)
	{
		if (original == null)
		{
			UnityEngine.Debug.LogWarning("Original material is null, could not copy properties to " + newMat?.ToString() + ". Setting shader to " + newMat.shader);
			return;
		}
		newMat.shader = original.shader;
		newMat.CopyPropertiesFromMaterial(original);
		ShaderTextureProperty[] shaderTexPropertyNames = MB3_TextureCombinerPipeline.shaderTexPropertyNames;
		for (int i = 0; i < shaderTexPropertyNames.Length; i++)
		{
			Vector2 one = Vector2.one;
			Vector2 zero = Vector2.zero;
			if (newMat.HasProperty(shaderTexPropertyNames[i].name))
			{
				newMat.SetTextureOffset(shaderTexPropertyNames[i].name, zero);
				newMat.SetTextureScale(shaderTexPropertyNames[i].name, one);
			}
		}
	}

	private string PrintSet(HashSet<Material> s)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (Material item in s)
		{
			stringBuilder.Append(item?.ToString() + ",");
		}
		return stringBuilder.ToString();
	}

	private bool _ValidateResultMaterials()
	{
		HashSet<Material> hashSet = new HashSet<Material>();
		for (int i = 0; i < objsToMesh.Count; i++)
		{
			if (!(objsToMesh[i] != null))
			{
				continue;
			}
			Material[] gOMaterials = MB_Utility.GetGOMaterials(objsToMesh[i]);
			for (int j = 0; j < gOMaterials.Length; j++)
			{
				if (gOMaterials[j] != null)
				{
					hashSet.Add(gOMaterials[j]);
				}
			}
		}
		if (resultMaterials.Length < 1)
		{
			UnityEngine.Debug.LogError("Using multiple materials but there are no 'Source Material To Combined Mappings'. You need at least one.");
		}
		HashSet<Material> hashSet2 = new HashSet<Material>();
		for (int k = 0; k < resultMaterials.Length; k++)
		{
			for (int l = k + 1; l < resultMaterials.Length; l++)
			{
				if (resultMaterials[k].combinedMaterial == resultMaterials[l].combinedMaterial)
				{
					UnityEngine.Debug.LogError($"Source To Combined Mapping: Submesh {k} and Submesh {l} use the same combined material. These should be different");
					return false;
				}
			}
			MB_MultiMaterial mB_MultiMaterial = resultMaterials[k];
			if (mB_MultiMaterial.combinedMaterial == null)
			{
				UnityEngine.Debug.LogError("Combined Material is null please create and assign a result material.");
				return false;
			}
			Shader shader = mB_MultiMaterial.combinedMaterial.shader;
			for (int m = 0; m < mB_MultiMaterial.sourceMaterials.Count; m++)
			{
				if (mB_MultiMaterial.sourceMaterials[m] == null)
				{
					UnityEngine.Debug.LogError("There are null entries in the list of Source Materials");
					return false;
				}
				if (shader != mB_MultiMaterial.sourceMaterials[m].shader)
				{
					UnityEngine.Debug.LogWarning("Source material " + mB_MultiMaterial.sourceMaterials[m]?.ToString() + " does not use shader " + shader?.ToString() + " it may not have the required textures. If not empty textures will be generated.");
				}
				if (hashSet2.Contains(mB_MultiMaterial.sourceMaterials[m]))
				{
					UnityEngine.Debug.LogError("A Material " + mB_MultiMaterial.sourceMaterials[m]?.ToString() + " appears more than once in the list of source materials in the source material to combined mapping. Each source material must be unique.");
					return false;
				}
				hashSet2.Add(mB_MultiMaterial.sourceMaterials[m]);
			}
		}
		if (hashSet.IsProperSubsetOf(hashSet2))
		{
			hashSet2.ExceptWith(hashSet);
			UnityEngine.Debug.LogWarning("There are materials in the mapping that are not used on your source objects: " + PrintSet(hashSet2));
		}
		if (resultMaterials != null && resultMaterials.Length != 0 && hashSet2.IsProperSubsetOf(hashSet))
		{
			hashSet.ExceptWith(hashSet2);
			UnityEngine.Debug.LogError("There are materials on the objects to combine that are not in the mapping: " + PrintSet(hashSet));
			return false;
		}
		return true;
	}
}
[ExecuteInEditMode]
public class MB_PreserveLightmapData : MonoBehaviour
{
	public int lightmapIndex;

	public Vector4 lightmapScaleOffset;

	private void Awake()
	{
		MeshRenderer component = GetComponent<MeshRenderer>();
		if (component == null)
		{
			UnityEngine.Debug.LogError("The MB_PreserveLightmapData script must be on a GameObject with a MeshRenderer. There was no MeshRenderer on object: " + base.name);
			return;
		}
		if (component.lightmapIndex != -1)
		{
			lightmapIndex = component.lightmapIndex;
		}
		if (component.lightmapIndex == -1)
		{
			component.lightmapIndex = lightmapIndex;
		}
		lightmapScaleOffset = new Vector4(1f, 1f, 0f, 0f);
		component.lightmapScaleOffset = lightmapScaleOffset;
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
			FilePathsData = new byte[5802]
			{
				0, 0, 0, 1, 0, 0, 0, 41, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 65, 115, 115, 101, 109, 98,
				108, 121, 73, 110, 102, 111, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 94, 92, 65, 115,
				115, 101, 116, 115, 92, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 65, 115, 115, 105, 103, 110, 84,
				111, 77, 101, 115, 104, 67, 117, 115, 116, 111,
				109, 105, 122, 101, 114, 115, 92, 67, 117, 115,
				116, 111, 109, 105, 122, 101, 114, 78, 97, 116,
				105, 118, 101, 65, 114, 114, 97, 121, 80, 117,
				116, 83, 108, 105, 99, 101, 73, 110, 100, 101,
				120, 73, 110, 85, 86, 48, 95, 122, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 83, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 65, 115, 115, 105, 103,
				110, 84, 111, 77, 101, 115, 104, 67, 117, 115,
				116, 111, 109, 105, 122, 101, 114, 115, 92, 67,
				117, 115, 116, 111, 109, 105, 122, 101, 114, 80,
				117, 116, 83, 108, 105, 99, 101, 73, 110, 100,
				101, 120, 73, 110, 85, 86, 48, 95, 122, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 42,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 99, 111, 114, 101,
				92, 77, 66, 50, 95, 67, 111, 114, 101, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 41,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 99, 111, 114, 101,
				92, 77, 66, 50, 95, 76, 111, 103, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 47, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 99, 111, 114, 101, 92,
				77, 66, 50, 95, 77, 66, 86, 101, 114, 115,
				105, 111, 110, 46, 99, 115, 0, 0, 0, 4,
				0, 0, 0, 61, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 77, 66, 51, 95, 65,
				103, 103, 108, 111, 109, 101, 114, 97, 116, 105,
				118, 101, 67, 108, 117, 115, 116, 101, 114, 105,
				110, 103, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 53, 92, 65, 115, 115, 101, 116, 115,
				92, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 99,
				111, 114, 101, 92, 77, 66, 51, 95, 67, 111,
				112, 121, 66, 111, 110, 101, 87, 101, 105, 103,
				104, 116, 115, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 52, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 77, 66, 51, 95, 71,
				114, 111, 117, 112, 101, 114, 67, 108, 117, 115,
				116, 101, 114, 46, 99, 115, 0, 0, 0, 3,
				0, 0, 0, 50, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 58, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 99, 111,
				114, 101, 92, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				101, 116, 116, 105, 110, 103, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 56, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 46, 99, 115, 0, 0, 0, 2, 0, 0,
				0, 55, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 99, 111,
				114, 101, 92, 77, 66, 51, 95, 77, 117, 108,
				116, 105, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 51, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 99, 111, 114, 101, 92, 77, 66, 51, 95,
				80, 114, 105, 111, 114, 105, 116, 121, 81, 117,
				101, 117, 101, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 60, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 77, 66, 51, 95, 83,
				104, 97, 100, 101, 114, 115, 84, 104, 97, 116,
				83, 104, 97, 114, 101, 84, 105, 108, 105, 110,
				103, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 49, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 99, 111,
				114, 101, 92, 77, 66, 51, 95, 85, 86, 84,
				114, 97, 110, 115, 102, 111, 114, 109, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 59, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 99, 111, 114, 101, 92,
				77, 66, 95, 66, 108, 101, 110, 100, 83, 104,
				97, 112, 101, 50, 67, 111, 109, 98, 105, 110,
				101, 100, 77, 97, 112, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 64, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 115, 99, 114, 105, 112, 116,
				115, 92, 99, 111, 114, 101, 92, 77, 66, 95,
				68, 101, 102, 97, 117, 108, 116, 77, 101, 115,
				104, 65, 115, 115, 105, 103, 110, 67, 117, 115,
				116, 111, 109, 105, 122, 101, 114, 46, 99, 115,
				0, 0, 0, 3, 0, 0, 0, 60, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 77,
				66, 95, 73, 65, 115, 115, 105, 103, 110, 84,
				111, 77, 101, 115, 104, 67, 117, 115, 116, 111,
				109, 105, 122, 101, 114, 46, 99, 115, 0, 0,
				0, 3, 0, 0, 0, 55, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 115, 99, 114, 105, 112, 116,
				115, 92, 99, 111, 114, 101, 92, 77, 66, 95,
				73, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				83, 101, 116, 116, 105, 110, 103, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 70, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 99, 111, 114, 101, 92,
				77, 66, 95, 73, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 95, 66, 111, 110, 101, 80, 114, 111,
				99, 101, 115, 115, 111, 114, 46, 99, 115, 0,
				0, 0, 2, 0, 0, 0, 75, 92, 65, 115,
				115, 101, 116, 115, 92, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 99, 111, 114, 101, 92, 77, 66,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 95,
				66, 108, 101, 110, 100, 83, 104, 97, 112, 101,
				80, 114, 111, 99, 101, 115, 115, 111, 114, 46,
				99, 115, 0, 0, 0, 2, 0, 0, 0, 69,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 99, 111, 114, 101,
				92, 77, 66, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 95, 66, 111, 110, 101, 80, 114, 111,
				99, 101, 115, 115, 111, 114, 46, 99, 115, 0,
				0, 0, 2, 0, 0, 0, 75, 92, 65, 115,
				115, 101, 116, 115, 92, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 99, 111, 114, 101, 92, 77, 66,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 95,
				66, 111, 110, 101, 80, 114, 111, 99, 101, 115,
				115, 111, 114, 78, 101, 119, 65, 80, 73, 46,
				99, 115, 0, 0, 0, 11, 0, 0, 0, 60,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 99, 111, 114, 101,
				92, 77, 66, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 95, 68, 97, 116, 97, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 83, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 77,
				66, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				95, 73, 86, 101, 114, 116, 101, 120, 65, 110,
				100, 84, 114, 105, 97, 110, 103, 108, 101, 80,
				114, 111, 99, 101, 115, 115, 111, 114, 46, 99,
				115, 0, 0, 0, 2, 0, 0, 0, 67, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 99, 111, 114, 101, 92,
				77, 66, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 95, 83, 117, 98, 67, 111, 109, 98, 105,
				110, 101, 114, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 71, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 77, 66, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 95, 85, 86, 65,
				100, 106, 117, 115, 116, 101, 114, 65, 116, 108,
				97, 115, 46, 99, 115, 0, 0, 0, 2, 0,
				0, 0, 82, 92, 65, 115, 115, 101, 116, 115,
				92, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 99,
				111, 114, 101, 92, 77, 66, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 95, 86, 101, 114, 116,
				101, 120, 65, 110, 100, 84, 114, 105, 97, 110,
				103, 108, 101, 80, 114, 111, 99, 101, 115, 115,
				111, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 77, 92, 65, 115, 115, 101, 116, 115,
				92, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 99,
				111, 114, 101, 92, 77, 66, 95, 83, 101, 114,
				105, 97, 108, 105, 122, 97, 98, 108, 101, 83,
				111, 117, 114, 99, 101, 66, 108, 101, 110, 100,
				83, 104, 97, 112, 101, 50, 67, 111, 109, 98,
				105, 110, 101, 100, 77, 97, 112, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 46, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 77,
				66, 95, 84, 71, 65, 87, 114, 105, 116, 101,
				114, 46, 99, 115, 0, 0, 0, 3, 0, 0,
				0, 44, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 99, 111,
				114, 101, 92, 77, 66, 95, 85, 116, 105, 108,
				105, 116, 121, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 92, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 78, 97, 116, 105, 118,
				101, 65, 114, 114, 97, 121, 65, 80, 73, 92,
				77, 66, 95, 68, 101, 102, 97, 117, 108, 116,
				77, 101, 115, 104, 65, 115, 115, 105, 103, 110,
				67, 117, 115, 116, 111, 109, 105, 122, 101, 114,
				95, 78, 97, 116, 105, 118, 101, 65, 114, 114,
				97, 121, 115, 46, 99, 115, 0, 0, 0, 3,
				0, 0, 0, 86, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 78, 97, 116, 105, 118,
				101, 65, 114, 114, 97, 121, 65, 80, 73, 92,
				77, 66, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 95, 68, 97, 116, 97, 78, 97, 116, 105,
				118, 101, 65, 114, 114, 97, 121, 46, 99, 115,
				0, 0, 0, 40, 0, 0, 0, 92, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 78,
				97, 116, 105, 118, 101, 65, 114, 114, 97, 121,
				65, 80, 73, 92, 77, 66, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 95, 77, 101, 115, 104,
				78, 97, 116, 105, 118, 101, 65, 114, 114, 97,
				121, 72, 101, 108, 112, 101, 114, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 108, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 78,
				97, 116, 105, 118, 101, 65, 114, 114, 97, 121,
				65, 80, 73, 92, 77, 66, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 95, 86, 101, 114, 116,
				101, 120, 65, 110, 100, 84, 114, 105, 97, 110,
				103, 108, 101, 80, 114, 111, 99, 101, 115, 115,
				111, 114, 78, 97, 116, 105, 118, 101, 65, 114,
				114, 97, 121, 46, 99, 115, 0, 0, 0, 12,
				0, 0, 0, 67, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 84, 101, 120, 116, 117,
				114, 101, 67, 111, 109, 98, 105, 110, 101, 114,
				92, 77, 66, 50, 95, 84, 101, 120, 116, 117,
				114, 101, 80, 97, 99, 107, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 81, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 99, 111, 114, 101, 92,
				84, 101, 120, 116, 117, 114, 101, 67, 111, 109,
				98, 105, 110, 101, 114, 92, 77, 66, 50, 95,
				84, 101, 120, 116, 117, 114, 101, 80, 97, 99,
				107, 101, 114, 72, 111, 114, 105, 122, 111, 110,
				116, 97, 108, 86, 101, 114, 116, 46, 99, 115,
				0, 0, 0, 2, 0, 0, 0, 78, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 92, 77, 66, 51, 95, 65,
				116, 108, 97, 115, 80, 97, 99, 107, 101, 114,
				82, 101, 110, 100, 101, 114, 84, 101, 120, 116,
				117, 114, 101, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 76, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 84, 101, 120, 116, 117,
				114, 101, 67, 111, 109, 98, 105, 110, 101, 114,
				92, 77, 66, 51, 95, 73, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 80, 97, 99, 107, 101, 114, 46, 99, 115,
				0, 0, 0, 5, 0, 0, 0, 69, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 92, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 46, 99, 115, 0, 0, 0,
				7, 0, 0, 0, 78, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 99, 111, 114, 101, 92, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 92, 77, 66, 51, 95, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 65, 116, 108, 97, 115, 82, 101, 99, 116,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				76, 92, 65, 115, 115, 101, 116, 115, 92, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 92, 115,
				99, 114, 105, 112, 116, 115, 92, 99, 111, 114,
				101, 92, 84, 101, 120, 116, 117, 114, 101, 67,
				111, 109, 98, 105, 110, 101, 114, 92, 77, 66,
				51, 95, 84, 101, 120, 116, 117, 114, 101, 67,
				111, 109, 98, 105, 110, 101, 114, 77, 101, 114,
				103, 105, 110, 103, 46, 99, 115, 0, 0, 0,
				11, 0, 0, 0, 89, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 99, 111, 114, 101, 92, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 92, 77, 66, 51, 95, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 78, 111, 110, 84, 101, 120, 116, 117, 114,
				101, 80, 114, 111, 112, 101, 114, 116, 105, 101,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 84, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 99, 111,
				114, 101, 92, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 92, 77,
				66, 51, 95, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 80, 97,
				99, 107, 101, 114, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 88, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				99, 111, 114, 101, 92, 84, 101, 120, 116, 117,
				114, 101, 67, 111, 109, 98, 105, 110, 101, 114,
				92, 77, 66, 51, 95, 84, 101, 120, 116, 117,
				114, 101, 67, 111, 109, 98, 105, 110, 101, 114,
				80, 97, 99, 107, 101, 114, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 70, 97, 115, 116, 46,
				99, 115, 0, 0, 0, 4, 0, 0, 0, 90,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 99, 111, 114, 101,
				92, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 92, 77, 66, 51,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 80, 97, 99, 107,
				101, 114, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 70, 97, 115, 116, 86, 50, 46, 99, 115,
				0, 0, 0, 4, 0, 0, 0, 102, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 92, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 80, 97, 99, 107, 101, 114,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 72,
				111, 114, 105, 122, 111, 110, 116, 97, 108, 86,
				101, 114, 116, 105, 99, 97, 108, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 92, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 92, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 80, 97, 99, 107, 101, 114,
				79, 110, 101, 84, 101, 120, 116, 117, 114, 101,
				73, 110, 65, 116, 108, 97, 115, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 80, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 99, 111, 114, 101, 92, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 92, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 80, 97, 99, 107, 101, 114,
				85, 110, 105, 116, 121, 46, 99, 115, 0, 0,
				0, 3, 0, 0, 0, 77, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 115, 99, 114, 105, 112, 116,
				115, 92, 99, 111, 114, 101, 92, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 92, 77, 66, 51, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 80, 105, 112, 101, 108, 105, 110, 101,
				46, 99, 115, 0, 0, 0, 2, 0, 0, 0,
				66, 92, 65, 115, 115, 101, 116, 115, 92, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 92, 115,
				99, 114, 105, 112, 116, 115, 92, 99, 111, 114,
				101, 92, 84, 101, 120, 116, 117, 114, 101, 67,
				111, 109, 98, 105, 110, 101, 114, 92, 77, 66,
				95, 84, 101, 120, 116, 117, 114, 101, 65, 114,
				114, 97, 121, 115, 46, 99, 115, 0, 0, 0,
				3, 0, 0, 0, 77, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 99, 111, 114, 101, 92, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 92, 77, 66, 95, 84, 101, 120, 116, 117,
				114, 101, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 82, 80, 67, 117, 115, 116, 111, 109, 46,
				99, 115, 0, 0, 0, 13, 0, 0, 0, 51,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 66, 50, 95,
				84, 101, 120, 116, 117, 114, 101, 66, 97, 107,
				101, 82, 101, 115, 117, 108, 116, 115, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 65, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 77, 66, 50, 95, 85,
				112, 100, 97, 116, 101, 83, 107, 105, 110, 110,
				101, 100, 77, 101, 115, 104, 66, 111, 117, 110,
				100, 115, 70, 114, 111, 109, 66, 111, 110, 101,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 66, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 77, 66,
				50, 95, 85, 112, 100, 97, 116, 101, 83, 107,
				105, 110, 110, 101, 100, 77, 101, 115, 104, 66,
				111, 117, 110, 100, 115, 70, 114, 111, 109, 66,
				111, 117, 110, 100, 115, 46, 99, 115, 0, 0,
				0, 2, 0, 0, 0, 49, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 115, 99, 114, 105, 112, 116,
				115, 92, 77, 66, 51, 95, 66, 97, 116, 99,
				104, 80, 114, 101, 102, 97, 98, 66, 97, 107,
				101, 114, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 49, 92, 65, 115, 115, 101, 116, 115,
				92, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 77,
				66, 51, 95, 66, 111, 110, 101, 87, 101, 105,
				103, 104, 116, 67, 111, 112, 105, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 40,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 66, 51, 95,
				67, 111, 109, 109, 101, 110, 116, 46, 99, 115,
				0, 0, 0, 1, 0, 0, 0, 56, 92, 65,
				115, 115, 101, 116, 115, 92, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 92, 115, 99, 114, 105,
				112, 116, 115, 92, 77, 66, 51, 95, 68, 105,
				115, 97, 98, 108, 101, 72, 105, 100, 100, 101,
				110, 65, 110, 105, 109, 97, 116, 105, 111, 110,
				115, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 50, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 77, 66,
				51, 95, 77, 66, 86, 101, 114, 115, 105, 111,
				110, 67, 111, 110, 99, 114, 101, 116, 101, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 42,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 66, 51, 95,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 48,
				92, 65, 115, 115, 101, 116, 115, 92, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 92, 115, 99,
				114, 105, 112, 116, 115, 92, 77, 66, 51, 95,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 67,
				111, 109, 109, 111, 110, 46, 99, 115, 0, 0,
				0, 7, 0, 0, 0, 49, 92, 65, 115, 115,
				101, 116, 115, 92, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 92, 115, 99, 114, 105, 112, 116,
				115, 92, 77, 66, 51, 95, 77, 101, 115, 104,
				66, 97, 107, 101, 114, 71, 114, 111, 117, 112,
				101, 114, 46, 99, 115, 0, 0, 0, 4, 0,
				0, 0, 46, 92, 65, 115, 115, 101, 116, 115,
				92, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				92, 115, 99, 114, 105, 112, 116, 115, 92, 77,
				66, 51, 95, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 82, 111, 111, 116, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 47, 92, 65, 115,
				115, 101, 116, 115, 92, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 77, 66, 51, 95, 77, 117, 108,
				116, 105, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 45, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 77, 66,
				51, 95, 84, 101, 120, 116, 117, 114, 101, 66,
				97, 107, 101, 114, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 52, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 77, 66, 95, 80, 114, 101, 115, 101, 114,
				118, 101, 76, 105, 103, 104, 116, 109, 97, 112,
				68, 97, 116, 97, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 59, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 84, 101, 120, 116, 117, 114, 101, 66, 108,
				101, 110, 100, 101, 114, 115, 92, 84, 101, 120,
				116, 117, 114, 101, 66, 108, 101, 110, 100, 101,
				114, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 67, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 84, 101,
				120, 116, 117, 114, 101, 66, 108, 101, 110, 100,
				101, 114, 115, 92, 84, 101, 120, 116, 117, 114,
				101, 66, 108, 101, 110, 100, 101, 114, 70, 97,
				108, 108, 98, 97, 99, 107, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 66, 92, 65, 115,
				115, 101, 116, 115, 92, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 84, 101, 120, 116, 117, 114, 101,
				66, 108, 101, 110, 100, 101, 114, 115, 92, 84,
				101, 120, 116, 117, 114, 101, 66, 108, 101, 110,
				100, 101, 114, 72, 68, 82, 80, 76, 105, 116,
				46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
				76, 92, 65, 115, 115, 101, 116, 115, 92, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 92, 115,
				99, 114, 105, 112, 116, 115, 92, 84, 101, 120,
				116, 117, 114, 101, 66, 108, 101, 110, 100, 101,
				114, 115, 92, 84, 101, 120, 116, 117, 114, 101,
				66, 108, 101, 110, 100, 101, 114, 76, 101, 103,
				97, 99, 121, 66, 117, 109, 112, 68, 105, 102,
				102, 117, 115, 101, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 72, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 84, 101, 120, 116, 117, 114, 101, 66, 108,
				101, 110, 100, 101, 114, 115, 92, 84, 101, 120,
				116, 117, 114, 101, 66, 108, 101, 110, 100, 101,
				114, 76, 101, 103, 97, 99, 121, 68, 105, 102,
				102, 117, 115, 101, 46, 99, 115, 0, 0, 0,
				2, 0, 0, 0, 86, 92, 65, 115, 115, 101,
				116, 115, 92, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 92, 115, 99, 114, 105, 112, 116, 115,
				92, 84, 101, 120, 116, 117, 114, 101, 66, 108,
				101, 110, 100, 101, 114, 115, 92, 84, 101, 120,
				116, 117, 114, 101, 66, 108, 101, 110, 100, 101,
				114, 77, 97, 116, 101, 114, 105, 97, 108, 80,
				114, 111, 112, 101, 114, 116, 121, 67, 97, 99,
				104, 101, 72, 101, 108, 112, 101, 114, 46, 99,
				115, 0, 0, 0, 1, 0, 0, 0, 75, 92,
				65, 115, 115, 101, 116, 115, 92, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 92, 115, 99, 114,
				105, 112, 116, 115, 92, 84, 101, 120, 116, 117,
				114, 101, 66, 108, 101, 110, 100, 101, 114, 115,
				92, 84, 101, 120, 116, 117, 114, 101, 66, 108,
				101, 110, 100, 101, 114, 83, 116, 97, 110, 100,
				97, 114, 100, 77, 101, 116, 97, 108, 108, 105,
				99, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 84, 92, 65, 115, 115, 101, 116, 115, 92,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 92,
				115, 99, 114, 105, 112, 116, 115, 92, 84, 101,
				120, 116, 117, 114, 101, 66, 108, 101, 110, 100,
				101, 114, 115, 92, 84, 101, 120, 116, 117, 114,
				101, 66, 108, 101, 110, 100, 101, 114, 83, 116,
				97, 110, 100, 97, 114, 100, 77, 101, 116, 97,
				108, 108, 105, 99, 82, 111, 117, 103, 104, 110,
				101, 115, 115, 46, 99, 115, 0, 0, 0, 1,
				0, 0, 0, 75, 92, 65, 115, 115, 101, 116,
				115, 92, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 92, 115, 99, 114, 105, 112, 116, 115, 92,
				84, 101, 120, 116, 117, 114, 101, 66, 108, 101,
				110, 100, 101, 114, 115, 92, 84, 101, 120, 116,
				117, 114, 101, 66, 108, 101, 110, 100, 101, 114,
				83, 116, 97, 110, 100, 97, 114, 100, 83, 112,
				101, 99, 117, 108, 97, 114, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 65, 92, 65, 115,
				115, 101, 116, 115, 92, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 92, 115, 99, 114, 105, 112,
				116, 115, 92, 84, 101, 120, 116, 117, 114, 101,
				66, 108, 101, 110, 100, 101, 114, 115, 92, 84,
				101, 120, 116, 117, 114, 101, 66, 108, 101, 110,
				100, 101, 114, 85, 82, 80, 76, 105, 116, 46,
				99, 115
			},
			TypesData = new byte[12215]
			{
				0, 0, 0, 0, 13, 124, 65, 115, 115, 101,
				109, 98, 108, 121, 73, 110, 102, 111, 0, 0,
				0, 0, 61, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 67, 117, 115, 116, 111, 109, 105,
				122, 101, 114, 78, 97, 116, 105, 118, 101, 65,
				114, 114, 97, 121, 80, 117, 116, 83, 108, 105,
				99, 101, 73, 110, 100, 101, 120, 73, 110, 85,
				86, 48, 95, 122, 0, 0, 0, 0, 50, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 67,
				117, 115, 116, 111, 109, 105, 122, 101, 114, 80,
				117, 116, 83, 108, 105, 99, 101, 73, 110, 100,
				101, 120, 73, 110, 85, 86, 48, 95, 122, 0,
				0, 0, 0, 46, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 50, 95, 69, 100,
				105, 116, 111, 114, 77, 101, 116, 104, 111, 100,
				115, 73, 110, 116, 101, 114, 102, 97, 99, 101,
				0, 0, 0, 0, 27, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 50, 95, 76,
				111, 103, 0, 0, 0, 0, 29, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 124, 79, 98, 106,
				101, 99, 116, 76, 111, 103, 0, 0, 0, 0,
				38, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 77, 66, 86, 101, 114, 115, 105, 111, 110,
				73, 110, 116, 101, 114, 102, 97, 99, 101, 0,
				0, 0, 0, 29, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 86, 101, 114, 115,
				105, 111, 110, 0, 0, 0, 0, 47, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 77, 66,
				51, 95, 65, 103, 103, 108, 111, 109, 101, 114,
				97, 116, 105, 118, 101, 67, 108, 117, 115, 116,
				101, 114, 105, 110, 103, 0, 0, 0, 0, 59,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 65, 103, 103, 108, 111, 109,
				101, 114, 97, 116, 105, 118, 101, 67, 108, 117,
				115, 116, 101, 114, 105, 110, 103, 124, 67, 108,
				117, 115, 116, 101, 114, 78, 111, 100, 101, 0,
				0, 0, 0, 54, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 46, 77, 66, 51, 95, 65, 103,
				103, 108, 111, 109, 101, 114, 97, 116, 105, 118,
				101, 67, 108, 117, 115, 116, 101, 114, 105, 110,
				103, 124, 105, 116, 101, 109, 95, 115, 0, 0,
				0, 0, 63, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 65, 103, 103,
				108, 111, 109, 101, 114, 97, 116, 105, 118, 101,
				67, 108, 117, 115, 116, 101, 114, 105, 110, 103,
				124, 67, 108, 117, 115, 116, 101, 114, 68, 105,
				115, 116, 97, 110, 99, 101, 0, 0, 0, 0,
				39, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 77, 66, 51, 95, 67, 111, 112, 121, 66,
				111, 110, 101, 87, 101, 105, 103, 104, 116, 115,
				0, 0, 0, 0, 40, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 75,
				77, 101, 97, 110, 115, 67, 108, 117, 115, 116,
				101, 114, 105, 110, 103, 0, 0, 0, 0, 50,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 75, 77, 101, 97, 110, 115,
				67, 108, 117, 115, 116, 101, 114, 105, 110, 103,
				124, 68, 97, 116, 97, 80, 111, 105, 110, 116,
				0, 0, 0, 0, 36, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 0, 0, 0, 0, 52, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				77, 101, 115, 104, 67, 111, 109, 98, 105, 110,
				101, 114, 124, 77, 66, 66, 108, 101, 110, 100,
				83, 104, 97, 112, 101, 75, 101, 121, 0, 0,
				0, 0, 54, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 124,
				77, 66, 66, 108, 101, 110, 100, 83, 104, 97,
				112, 101, 86, 97, 108, 117, 101, 0, 0, 0,
				0, 48, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 101,
				116, 116, 105, 110, 103, 115, 68, 97, 116, 97,
				0, 0, 0, 0, 44, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 101, 116, 116, 105, 110, 103, 115, 1,
				0, 0, 0, 42, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 51, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 0, 0, 0, 0,
				41, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 77, 66, 51, 95, 77, 117, 108, 116, 105,
				77, 101, 115, 104, 67, 111, 109, 98, 105, 110,
				101, 114, 0, 0, 0, 0, 54, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 117, 108, 116, 105, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 124, 67,
				111, 109, 98, 105, 110, 101, 100, 77, 101, 115,
				104, 0, 0, 0, 0, 33, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 80, 114, 105, 111,
				114, 105, 116, 121, 81, 117, 101, 117, 101, 0,
				0, 0, 0, 46, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 51, 95, 83, 104,
				97, 100, 101, 114, 115, 84, 104, 97, 116, 83,
				104, 97, 114, 101, 84, 105, 108, 105, 110, 103,
				0, 0, 0, 0, 69, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 83,
				104, 97, 100, 101, 114, 115, 84, 104, 97, 116,
				83, 104, 97, 114, 101, 84, 105, 108, 105, 110,
				103, 124, 83, 104, 97, 100, 101, 114, 84, 104,
				97, 116, 83, 104, 97, 114, 101, 115, 84, 105,
				108, 105, 110, 103, 0, 0, 0, 0, 28, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 68,
				86, 101, 99, 116, 111, 114, 50, 0, 0, 0,
				0, 25, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 68, 82, 101, 99, 116, 0, 0, 0,
				0, 42, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 66, 51, 95, 85, 86, 84, 114,
				97, 110, 115, 102, 111, 114, 109, 85, 116, 105,
				108, 105, 116, 121, 0, 0, 0, 0, 45, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 95, 66, 108, 101, 110, 100, 83, 104, 97,
				112, 101, 50, 67, 111, 109, 98, 105, 110, 101,
				100, 77, 97, 112, 0, 0, 0, 0, 50, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 95, 68, 101, 102, 97, 117, 108, 116, 77,
				101, 115, 104, 65, 115, 115, 105, 103, 110, 67,
				117, 115, 116, 111, 109, 105, 122, 101, 114, 0,
				0, 0, 0, 43, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 73, 65, 115, 115, 105, 103,
				110, 84, 111, 77, 101, 115, 104, 67, 117, 115,
				116, 111, 109, 105, 122, 101, 114, 0, 0, 0,
				0, 53, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 73, 65, 115, 115, 105, 103, 110, 84,
				111, 77, 101, 115, 104, 67, 117, 115, 116, 111,
				109, 105, 122, 101, 114, 95, 83, 105, 109, 112,
				108, 101, 65, 80, 73, 0, 0, 0, 0, 56,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 124,
				73, 65, 115, 115, 105, 103, 110, 84, 111, 77,
				101, 115, 104, 67, 117, 115, 116, 111, 109, 105,
				122, 101, 114, 95, 78, 97, 116, 105, 118, 101,
				65, 114, 114, 97, 121, 115, 0, 0, 0, 0,
				47, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 77, 66, 95, 73, 77, 101, 115, 104, 66,
				97, 107, 101, 114, 83, 101, 116, 116, 105, 110,
				103, 115, 72, 111, 108, 100, 101, 114, 0, 0,
				0, 0, 41, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 77, 66, 95, 73, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 83, 101, 116, 116,
				105, 110, 103, 115, 0, 0, 0, 0, 44, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 83, 101,
				116, 116, 105, 110, 103, 115, 85, 116, 105, 108,
				105, 116, 121, 0, 0, 0, 0, 56, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 77, 66,
				95, 73, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				95, 66, 111, 110, 101, 80, 114, 111, 99, 101,
				115, 115, 111, 114, 1, 0, 0, 0, 42, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 0, 0, 0, 0, 84, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				77, 101, 115, 104, 67, 111, 109, 98, 105, 110,
				101, 114, 83, 105, 110, 103, 108, 101, 124, 77,
				66, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				95, 66, 108, 101, 110, 100, 83, 104, 97, 112,
				101, 80, 114, 111, 99, 101, 115, 115, 111, 114,
				1, 0, 0, 0, 42, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 0, 0, 0,
				0, 78, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 124, 77, 66, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 95, 66, 111, 110,
				101, 80, 114, 111, 99, 101, 115, 115, 111, 114,
				1, 0, 0, 0, 42, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 0, 0, 0,
				0, 84, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 124, 77, 66, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 95, 66, 111, 110,
				101, 80, 114, 111, 99, 101, 115, 115, 111, 114,
				78, 101, 119, 65, 80, 73, 1, 0, 0, 0,
				42, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 0, 0, 0, 0, 69, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				51, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				124, 66, 117, 102, 102, 101, 114, 68, 97, 116,
				97, 70, 114, 111, 109, 80, 114, 101, 118, 105,
				111, 117, 115, 66, 97, 107, 101, 0, 0, 0,
				0, 63, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 124, 83, 101, 114, 105, 97,
				108, 105, 122, 97, 98, 108, 101, 73, 110, 116,
				65, 114, 114, 97, 121, 0, 0, 0, 0, 64,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 124, 66, 111, 110, 101, 87, 101, 105,
				103, 104, 116, 68, 97, 116, 97, 70, 111, 114,
				77, 101, 115, 104, 0, 0, 0, 0, 63, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 124, 77, 66, 95, 68, 121, 110, 97, 109,
				105, 99, 71, 97, 109, 101, 79, 98, 106, 101,
				99, 116, 0, 0, 0, 0, 55, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 124,
				77, 101, 115, 104, 67, 104, 97, 110, 110, 101,
				108, 115, 0, 0, 0, 0, 60, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 124,
				77, 66, 66, 108, 101, 110, 100, 83, 104, 97,
				112, 101, 70, 114, 97, 109, 101, 0, 0, 0,
				0, 55, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 124, 77, 66, 66, 108, 101,
				110, 100, 83, 104, 97, 112, 101, 0, 0, 0,
				0, 58, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 124, 66, 111, 110, 101, 65,
				110, 100, 66, 105, 110, 100, 112, 111, 115, 101,
				0, 0, 0, 0, 77, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 124, 73, 77,
				101, 115, 104, 67, 104, 97, 110, 110, 101, 108,
				115, 67, 97, 99, 104, 101, 84, 97, 103, 103,
				105, 110, 103, 73, 110, 116, 101, 114, 102, 97,
				99, 101, 0, 0, 0, 0, 60, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 124,
				77, 101, 115, 104, 67, 104, 97, 110, 110, 101,
				108, 115, 67, 97, 99, 104, 101, 1, 0, 0,
				0, 42, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 0, 0, 0, 0, 70, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 124, 73, 86, 101, 114, 116, 101, 120, 65,
				110, 100, 84, 114, 105, 97, 110, 103, 108, 101,
				80, 114, 111, 99, 101, 115, 115, 111, 114, 1,
				0, 0, 0, 42, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 51, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 0, 0, 0, 0,
				76, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 124, 77, 66, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 95, 83, 117, 98, 67,
				111, 109, 98, 105, 110, 101, 114, 1, 0, 0,
				0, 42, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 0, 0, 0, 0, 59, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 124, 85, 86, 65, 100, 106, 117, 115, 116,
				101, 114, 95, 65, 116, 108, 97, 115, 1, 0,
				0, 0, 42, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 0, 0, 0, 0, 69,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 124, 86, 101, 114, 116, 101, 120, 65,
				110, 100, 84, 114, 105, 97, 110, 103, 108, 101,
				80, 114, 111, 99, 101, 115, 115, 111, 114, 0,
				0, 0, 0, 57, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 83, 101, 114, 105, 97, 108,
				105, 122, 97, 98, 108, 101, 83, 111, 117, 114,
				99, 101, 66, 108, 101, 110, 100, 83, 104, 97,
				112, 101, 50, 67, 111, 109, 98, 105, 110, 101,
				100, 0, 0, 0, 0, 32, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 77, 66, 95, 84,
				71, 65, 87, 114, 105, 116, 101, 114, 0, 0,
				0, 0, 30, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 77, 66, 95, 85, 116, 105, 108,
				105, 116, 121, 0, 0, 0, 0, 49, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				95, 85, 116, 105, 108, 105, 116, 121, 124, 77,
				101, 115, 104, 65, 110, 97, 108, 121, 115, 105,
				115, 82, 101, 115, 117, 108, 116, 0, 0, 0,
				0, 42, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 95, 85, 116, 105, 108, 105,
				116, 121, 124, 77, 66, 95, 84, 114, 105, 97,
				110, 103, 108, 101, 0, 0, 0, 0, 62, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 95, 68, 101, 102, 97, 117, 108, 116, 77,
				101, 115, 104, 65, 115, 115, 105, 103, 110, 67,
				117, 115, 116, 111, 109, 105, 122, 101, 114, 95,
				78, 97, 116, 105, 118, 101, 65, 114, 114, 97,
				121, 1, 0, 0, 0, 42, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 77, 66, 51, 95,
				77, 101, 115, 104, 67, 111, 109, 98, 105, 110,
				101, 114, 83, 105, 110, 103, 108, 101, 0, 0,
				0, 0, 72, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 124, 77, 101, 115, 104,
				67, 104, 97, 110, 110, 101, 108, 115, 67, 97,
				99, 104, 101, 95, 78, 97, 116, 105, 118, 101,
				65, 114, 114, 97, 121, 0, 0, 0, 0, 66,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 124, 77, 101, 115, 104, 67, 104, 97,
				110, 110, 101, 108, 115, 78, 97, 116, 105, 118,
				101, 65, 114, 114, 97, 121, 1, 0, 0, 0,
				42, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 0, 0, 0, 0, 86, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				51, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				124, 77, 66, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 95, 77, 101, 115, 104, 78, 97, 116,
				105, 118, 101, 65, 114, 114, 97, 121, 72, 101,
				108, 112, 101, 114, 0, 0, 0, 0, 51, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 43, 124, 83, 73, 90, 69, 82, 95, 52,
				0, 0, 0, 0, 51, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 43, 124, 83,
				73, 90, 69, 82, 95, 56, 0, 0, 0, 0,
				52, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 43, 124, 83, 73, 90, 69, 82,
				95, 49, 50, 0, 0, 0, 0, 52, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				51, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				43, 124, 83, 73, 90, 69, 82, 95, 49, 54,
				0, 0, 0, 0, 52, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 43, 124, 83,
				73, 90, 69, 82, 95, 50, 48, 0, 0, 0,
				0, 52, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 43, 124, 83, 73, 90, 69,
				82, 95, 50, 52, 0, 0, 0, 0, 52, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 43, 124, 83, 73, 90, 69, 82, 95, 50,
				56, 0, 0, 0, 0, 52, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				77, 101, 115, 104, 67, 111, 109, 98, 105, 110,
				101, 114, 83, 105, 110, 103, 108, 101, 43, 124,
				83, 73, 90, 69, 82, 95, 51, 50, 0, 0,
				0, 0, 52, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 43, 124, 83, 73, 90,
				69, 82, 95, 51, 54, 0, 0, 0, 0, 52,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 43, 124, 83, 73, 90, 69, 82, 95,
				52, 48, 0, 0, 0, 0, 52, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 43,
				124, 83, 73, 90, 69, 82, 95, 52, 52, 0,
				0, 0, 0, 52, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 46, 77, 66, 51, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 43, 124, 83, 73,
				90, 69, 82, 95, 52, 56, 0, 0, 0, 0,
				52, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 43, 124, 83, 73, 90, 69, 82,
				95, 53, 50, 0, 0, 0, 0, 52, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				51, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				43, 124, 83, 73, 90, 69, 82, 95, 53, 54,
				0, 0, 0, 0, 52, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 43, 124, 83,
				73, 90, 69, 82, 95, 54, 48, 0, 0, 0,
				0, 52, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 77, 101, 115, 104,
				67, 111, 109, 98, 105, 110, 101, 114, 83, 105,
				110, 103, 108, 101, 43, 124, 83, 73, 90, 69,
				82, 95, 54, 52, 0, 0, 0, 0, 52, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 43, 124, 83, 73, 90, 69, 82, 95, 54,
				56, 0, 0, 0, 0, 52, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				77, 101, 115, 104, 67, 111, 109, 98, 105, 110,
				101, 114, 83, 105, 110, 103, 108, 101, 43, 124,
				83, 73, 90, 69, 82, 95, 55, 50, 0, 0,
				0, 0, 52, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 43, 124, 83, 73, 90,
				69, 82, 95, 55, 54, 0, 0, 0, 0, 52,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 77, 101, 115, 104, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 105, 110, 103,
				108, 101, 43, 124, 83, 73, 90, 69, 82, 95,
				56, 48, 0, 0, 0, 0, 52, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 43,
				124, 83, 73, 90, 69, 82, 95, 56, 52, 0,
				0, 0, 0, 52, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 46, 77, 66, 51, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 43, 124, 83, 73,
				90, 69, 82, 95, 56, 56, 0, 0, 0, 0,
				52, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 43, 124, 83, 73, 90, 69, 82,
				95, 57, 50, 0, 0, 0, 0, 52, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				51, 95, 77, 101, 115, 104, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 105, 110, 103, 108, 101,
				43, 124, 83, 73, 90, 69, 82, 95, 57, 54,
				0, 0, 0, 0, 53, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 43, 124, 83,
				73, 90, 69, 82, 95, 49, 48, 48, 0, 0,
				0, 0, 53, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 43, 124, 83, 73, 90,
				69, 82, 95, 49, 48, 52, 0, 0, 0, 0,
				53, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 43, 124, 83, 73, 90, 69, 82,
				95, 49, 48, 56, 0, 0, 0, 0, 53, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 43, 124, 83, 73, 90, 69, 82, 95, 49,
				49, 50, 0, 0, 0, 0, 53, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 43,
				124, 83, 73, 90, 69, 82, 95, 49, 49, 54,
				0, 0, 0, 0, 53, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 43, 124, 83,
				73, 90, 69, 82, 95, 49, 50, 48, 0, 0,
				0, 0, 53, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 43, 124, 83, 73, 90,
				69, 82, 95, 49, 50, 52, 0, 0, 0, 0,
				53, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 43, 124, 83, 73, 90, 69, 82,
				95, 49, 50, 56, 0, 0, 0, 0, 53, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 43, 124, 83, 73, 90, 69, 82, 95, 49,
				51, 50, 0, 0, 0, 0, 53, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 43,
				124, 83, 73, 90, 69, 82, 95, 49, 51, 54,
				0, 0, 0, 0, 53, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 77,
				101, 115, 104, 67, 111, 109, 98, 105, 110, 101,
				114, 83, 105, 110, 103, 108, 101, 43, 124, 83,
				73, 90, 69, 82, 95, 49, 52, 48, 0, 0,
				0, 0, 53, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 77, 101, 115,
				104, 67, 111, 109, 98, 105, 110, 101, 114, 83,
				105, 110, 103, 108, 101, 43, 124, 83, 73, 90,
				69, 82, 95, 49, 52, 52, 0, 0, 0, 0,
				53, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 77, 101, 115, 104, 67,
				111, 109, 98, 105, 110, 101, 114, 83, 105, 110,
				103, 108, 101, 43, 124, 83, 73, 90, 69, 82,
				95, 49, 52, 56, 0, 0, 0, 0, 53, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 77, 101, 115, 104, 67, 111, 109,
				98, 105, 110, 101, 114, 83, 105, 110, 103, 108,
				101, 43, 124, 83, 73, 90, 69, 82, 95, 49,
				53, 50, 1, 0, 0, 0, 42, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 124, 77, 66, 51,
				95, 77, 101, 115, 104, 67, 111, 109, 98, 105,
				110, 101, 114, 83, 105, 110, 103, 108, 101, 0,
				0, 0, 0, 80, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 46, 77, 66, 51, 95, 77, 101,
				115, 104, 67, 111, 109, 98, 105, 110, 101, 114,
				83, 105, 110, 103, 108, 101, 124, 86, 101, 114,
				116, 101, 120, 65, 110, 100, 84, 114, 105, 97,
				110, 103, 108, 101, 80, 114, 111, 99, 101, 115,
				115, 111, 114, 78, 97, 116, 105, 118, 101, 65,
				114, 114, 97, 121, 0, 0, 0, 0, 32, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 65,
				116, 108, 97, 115, 80, 97, 100, 100, 105, 110,
				103, 0, 0, 0, 0, 38, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 65, 116, 108, 97,
				115, 80, 97, 99, 107, 105, 110, 103, 82, 101,
				115, 117, 108, 116, 0, 0, 0, 0, 37, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 50, 95, 84, 101, 120, 116, 117, 114, 101,
				80, 97, 99, 107, 101, 114, 0, 0, 0, 0,
				45, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 50, 95, 84, 101, 120, 116, 117,
				114, 101, 80, 97, 99, 107, 101, 114, 124, 80,
				105, 120, 82, 101, 99, 116, 0, 0, 0, 0,
				43, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 50, 95, 84, 101, 120, 116, 117,
				114, 101, 80, 97, 99, 107, 101, 114, 124, 73,
				109, 97, 103, 101, 0, 0, 0, 0, 51, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 50, 95, 84, 101, 120, 116, 117, 114, 101,
				80, 97, 99, 107, 101, 114, 124, 73, 109, 103,
				73, 68, 67, 111, 109, 112, 97, 114, 101, 114,
				0, 0, 0, 0, 57, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 50, 95, 84,
				101, 120, 116, 117, 114, 101, 80, 97, 99, 107,
				101, 114, 124, 73, 109, 97, 103, 101, 72, 101,
				105, 103, 104, 116, 67, 111, 109, 112, 97, 114,
				101, 114, 0, 0, 0, 0, 56, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 50,
				95, 84, 101, 120, 116, 117, 114, 101, 80, 97,
				99, 107, 101, 114, 124, 73, 109, 97, 103, 101,
				87, 105, 100, 116, 104, 67, 111, 109, 112, 97,
				114, 101, 114, 0, 0, 0, 0, 55, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				50, 95, 84, 101, 120, 116, 117, 114, 101, 80,
				97, 99, 107, 101, 114, 124, 73, 109, 97, 103,
				101, 65, 114, 101, 97, 67, 111, 109, 112, 97,
				114, 101, 114, 0, 0, 0, 0, 44, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 77, 66,
				50, 95, 84, 101, 120, 116, 117, 114, 101, 80,
				97, 99, 107, 101, 114, 82, 101, 103, 117, 108,
				97, 114, 0, 0, 0, 0, 56, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 50,
				95, 84, 101, 120, 116, 117, 114, 101, 80, 97,
				99, 107, 101, 114, 82, 101, 103, 117, 108, 97,
				114, 124, 80, 114, 111, 98, 101, 82, 101, 115,
				117, 108, 116, 0, 0, 0, 0, 49, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				50, 95, 84, 101, 120, 116, 117, 114, 101, 80,
				97, 99, 107, 101, 114, 82, 101, 103, 117, 108,
				97, 114, 124, 78, 111, 100, 101, 0, 0, 0,
				0, 51, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 66, 50, 95, 84, 101, 120, 116,
				117, 114, 101, 80, 97, 99, 107, 101, 114, 72,
				111, 114, 105, 122, 111, 110, 116, 97, 108, 86,
				101, 114, 116, 0, 0, 0, 0, 32, 124, 77,
				66, 95, 84, 101, 120, 116, 117, 114, 101, 67,
				111, 109, 98, 105, 110, 101, 114, 82, 101, 110,
				100, 101, 114, 84, 101, 120, 116, 117, 114, 101,
				0, 0, 0, 0, 29, 124, 77, 66, 51, 95,
				65, 116, 108, 97, 115, 80, 97, 99, 107, 101,
				114, 82, 101, 110, 100, 101, 114, 84, 101, 120,
				116, 117, 114, 101, 0, 0, 0, 0, 45, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 95, 73, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 80, 97,
				99, 107, 101, 114, 0, 0, 0, 0, 49, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 51, 95, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 80, 97,
				99, 107, 101, 114, 82, 111, 111, 116, 0, 0,
				0, 0, 41, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 83, 104, 97, 100, 101, 114, 84,
				101, 120, 116, 117, 114, 101, 80, 114, 111, 112,
				101, 114, 116, 121, 0, 0, 0, 0, 39, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 51, 95, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 0, 0,
				0, 0, 68, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 124, 67, 114, 101, 97, 116, 101, 65,
				116, 108, 97, 115, 101, 115, 67, 111, 114, 111,
				117, 116, 105, 110, 101, 82, 101, 115, 117, 108,
				116, 0, 0, 0, 0, 56, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				84, 101, 120, 116, 117, 114, 101, 67, 111, 109,
				98, 105, 110, 101, 114, 124, 84, 101, 109, 112,
				111, 114, 97, 114, 121, 84, 101, 120, 116, 117,
				114, 101, 0, 0, 0, 0, 81, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 124, 67, 111, 109,
				98, 105, 110, 101, 84, 101, 120, 116, 117, 114,
				101, 115, 73, 110, 116, 111, 65, 116, 108, 97,
				115, 101, 115, 67, 111, 114, 111, 117, 116, 105,
				110, 101, 82, 101, 115, 117, 108, 116, 0, 0,
				0, 0, 44, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 77, 97, 116, 101, 114, 105, 97, 108,
				84, 101, 120, 116, 117, 114, 101, 0, 0, 0,
				0, 43, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 97, 116, 65, 110, 100, 84, 114,
				97, 110, 115, 102, 111, 114, 109, 84, 111, 77,
				101, 114, 103, 101, 100, 0, 0, 0, 0, 30,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 124,
				77, 97, 116, 115, 65, 110, 100, 71, 79, 115,
				0, 0, 0, 0, 29, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 95, 84, 101,
				120, 83, 101, 116, 0, 0, 0, 0, 47, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 95, 84, 101, 120, 83, 101, 116, 124, 80,
				105, 112, 101, 108, 105, 110, 101, 86, 97, 114,
				105, 97, 116, 105, 111, 110, 0, 0, 0, 0,
				74, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 95, 84, 101, 120, 83, 101, 116,
				124, 80, 105, 112, 101, 108, 105, 110, 101, 86,
				97, 114, 105, 97, 116, 105, 111, 110, 65, 108,
				108, 84, 101, 120, 116, 117, 114, 101, 115, 85,
				115, 101, 83, 97, 109, 101, 77, 97, 116, 84,
				105, 108, 105, 110, 103, 0, 0, 0, 0, 80,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 95, 84, 101, 120, 83, 101, 116, 124,
				80, 105, 112, 101, 108, 105, 110, 101, 86, 97,
				114, 105, 97, 116, 105, 111, 110, 83, 111, 109,
				101, 84, 101, 120, 116, 117, 114, 101, 115, 85,
				115, 101, 68, 105, 102, 102, 101, 114, 101, 110,
				116, 77, 97, 116, 84, 105, 108, 105, 110, 103,
				0, 0, 0, 0, 46, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 77, 101, 114, 103, 105, 110,
				103, 0, 0, 0, 0, 59, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 77, 66, 51, 95,
				84, 101, 120, 116, 117, 114, 101, 67, 111, 109,
				98, 105, 110, 101, 114, 78, 111, 110, 84, 101,
				120, 116, 117, 114, 101, 80, 114, 111, 112, 101,
				114, 116, 105, 101, 115, 0, 0, 0, 0, 76,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 46,
				77, 66, 51, 95, 84, 101, 120, 116, 117, 114,
				101, 67, 111, 109, 98, 105, 110, 101, 114, 78,
				111, 110, 84, 101, 120, 116, 117, 114, 101, 80,
				114, 111, 112, 101, 114, 116, 105, 101, 115, 124,
				77, 97, 116, 101, 114, 105, 97, 108, 80, 114,
				111, 112, 101, 114, 116, 121, 0, 0, 0, 0,
				81, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				46, 77, 66, 51, 95, 84, 101, 120, 116, 117,
				114, 101, 67, 111, 109, 98, 105, 110, 101, 114,
				78, 111, 110, 84, 101, 120, 116, 117, 114, 101,
				80, 114, 111, 112, 101, 114, 116, 105, 101, 115,
				124, 77, 97, 116, 101, 114, 105, 97, 108, 80,
				114, 111, 112, 101, 114, 116, 121, 70, 108, 111,
				97, 116, 0, 0, 0, 0, 81, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 78, 111, 110, 84,
				101, 120, 116, 117, 114, 101, 80, 114, 111, 112,
				101, 114, 116, 105, 101, 115, 124, 77, 97, 116,
				101, 114, 105, 97, 108, 80, 114, 111, 112, 101,
				114, 116, 121, 67, 111, 108, 111, 114, 0, 0,
				0, 0, 89, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 78, 111, 110, 84, 101, 120, 116, 117,
				114, 101, 80, 114, 111, 112, 101, 114, 116, 105,
				101, 115, 124, 77, 97, 116, 101, 114, 105, 97,
				108, 80, 114, 111, 112, 101, 114, 116, 121, 86,
				97, 108, 117, 101, 65, 118, 101, 114, 97, 103,
				101, 100, 0, 0, 0, 0, 94, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 78, 111, 110, 84,
				101, 120, 116, 117, 114, 101, 80, 114, 111, 112,
				101, 114, 116, 105, 101, 115, 124, 77, 97, 116,
				101, 114, 105, 97, 108, 80, 114, 111, 112, 101,
				114, 116, 121, 86, 97, 108, 117, 101, 65, 118,
				101, 114, 97, 103, 101, 100, 70, 108, 111, 97,
				116, 0, 0, 0, 0, 94, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				84, 101, 120, 116, 117, 114, 101, 67, 111, 109,
				98, 105, 110, 101, 114, 78, 111, 110, 84, 101,
				120, 116, 117, 114, 101, 80, 114, 111, 112, 101,
				114, 116, 105, 101, 115, 124, 77, 97, 116, 101,
				114, 105, 97, 108, 80, 114, 111, 112, 101, 114,
				116, 121, 86, 97, 108, 117, 101, 65, 118, 101,
				114, 97, 103, 101, 100, 67, 111, 108, 111, 114,
				0, 0, 0, 0, 84, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 78, 111, 110, 84, 101, 120,
				116, 117, 114, 101, 80, 114, 111, 112, 101, 114,
				116, 105, 101, 115, 124, 84, 101, 120, 80, 114,
				111, 112, 101, 114, 116, 121, 78, 97, 109, 101,
				67, 111, 108, 111, 114, 80, 97, 105, 114, 0,
				0, 0, 0, 80, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 46, 77, 66, 51, 95, 84, 101,
				120, 116, 117, 114, 101, 67, 111, 109, 98, 105,
				110, 101, 114, 78, 111, 110, 84, 101, 120, 116,
				117, 114, 101, 80, 114, 111, 112, 101, 114, 116,
				105, 101, 115, 124, 78, 111, 110, 84, 101, 120,
				116, 117, 114, 101, 80, 114, 111, 112, 101, 114,
				116, 105, 101, 115, 0, 0, 0, 0, 94, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 46, 77,
				66, 51, 95, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 78, 111,
				110, 84, 101, 120, 116, 117, 114, 101, 80, 114,
				111, 112, 101, 114, 116, 105, 101, 115, 124, 78,
				111, 110, 84, 101, 120, 116, 117, 114, 101, 80,
				114, 111, 112, 101, 114, 116, 105, 101, 115, 68,
				111, 110, 116, 66, 108, 101, 110, 100, 80, 114,
				111, 112, 115, 0, 0, 0, 0, 90, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 46, 77, 66,
				51, 95, 84, 101, 120, 116, 117, 114, 101, 67,
				111, 109, 98, 105, 110, 101, 114, 78, 111, 110,
				84, 101, 120, 116, 117, 114, 101, 80, 114, 111,
				112, 101, 114, 116, 105, 101, 115, 124, 78, 111,
				110, 84, 101, 120, 116, 117, 114, 101, 80, 114,
				111, 112, 101, 114, 116, 105, 101, 115, 66, 108,
				101, 110, 100, 80, 114, 111, 112, 115, 0, 0,
				0, 0, 54, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 77, 66, 51, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 80, 97, 99, 107, 101, 114, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 0, 0, 0,
				0, 58, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 124, 77, 66, 51, 95, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 80, 97, 99, 107, 101, 114, 77, 101, 115,
				104, 66, 97, 107, 101, 114, 70, 97, 115, 116,
				0, 0, 0, 0, 60, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 80, 97, 99, 107, 101, 114,
				77, 101, 115, 104, 66, 97, 107, 101, 114, 70,
				97, 115, 116, 86, 50, 0, 0, 0, 0, 57,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 124,
				77, 66, 51, 95, 65, 116, 108, 97, 115, 80,
				97, 99, 107, 101, 114, 82, 101, 110, 100, 101,
				114, 84, 101, 120, 116, 117, 114, 101, 85, 115,
				105, 110, 103, 77, 101, 115, 104, 0, 0, 0,
				0, 70, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 65, 116, 108, 97,
				115, 80, 97, 99, 107, 101, 114, 82, 101, 110,
				100, 101, 114, 84, 101, 120, 116, 117, 114, 101,
				85, 115, 105, 110, 103, 77, 101, 115, 104, 124,
				77, 101, 115, 104, 82, 101, 99, 116, 73, 110,
				102, 111, 0, 0, 0, 0, 67, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 65, 116, 108, 97, 115, 80, 97, 99, 107,
				101, 114, 82, 101, 110, 100, 101, 114, 84, 101,
				120, 116, 117, 114, 101, 85, 115, 105, 110, 103,
				77, 101, 115, 104, 124, 77, 101, 115, 104, 65,
				116, 108, 97, 115, 0, 0, 0, 0, 72, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 51, 95, 84, 101, 120, 116, 117, 114, 101,
				67, 111, 109, 98, 105, 110, 101, 114, 80, 97,
				99, 107, 101, 114, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 72, 111, 114, 105, 122, 111, 110,
				116, 97, 108, 86, 101, 114, 116, 105, 99, 97,
				108, 0, 0, 0, 0, 82, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 46, 77, 66, 51, 95,
				84, 101, 120, 116, 117, 114, 101, 67, 111, 109,
				98, 105, 110, 101, 114, 80, 97, 99, 107, 101,
				114, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				72, 111, 114, 105, 122, 111, 110, 116, 97, 108,
				86, 101, 114, 116, 105, 99, 97, 108, 124, 73,
				80, 105, 112, 101, 108, 105, 110, 101, 0, 0,
				0, 0, 89, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 46, 77, 66, 51, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 80, 97, 99, 107, 101, 114, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 72, 111, 114,
				105, 122, 111, 110, 116, 97, 108, 86, 101, 114,
				116, 105, 99, 97, 108, 124, 86, 101, 114, 116,
				105, 99, 97, 108, 80, 105, 112, 101, 108, 105,
				110, 101, 0, 0, 0, 0, 91, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 80, 97, 99, 107,
				101, 114, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 72, 111, 114, 105, 122, 111, 110, 116, 97,
				108, 86, 101, 114, 116, 105, 99, 97, 108, 124,
				72, 111, 114, 105, 122, 111, 110, 116, 97, 108,
				80, 105, 112, 101, 108, 105, 110, 101, 0, 0,
				0, 0, 62, 68, 105, 103, 105, 116, 97, 108,
				79, 112, 117, 115, 46, 77, 66, 46, 67, 111,
				114, 101, 124, 77, 66, 51, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 80, 97, 99, 107, 101, 114, 79, 110,
				101, 84, 101, 120, 116, 117, 114, 101, 73, 110,
				65, 116, 108, 97, 115, 0, 0, 0, 0, 50,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 124,
				77, 66, 51, 95, 84, 101, 120, 116, 117, 114,
				101, 67, 111, 109, 98, 105, 110, 101, 114, 80,
				97, 99, 107, 101, 114, 85, 110, 105, 116, 121,
				0, 0, 0, 0, 47, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 80, 105, 112, 101, 108, 105,
				110, 101, 0, 0, 0, 0, 70, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 46, 77, 66, 51,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 80, 105, 112, 101,
				108, 105, 110, 101, 124, 67, 114, 101, 97, 116,
				101, 65, 116, 108, 97, 115, 70, 111, 114, 80,
				114, 111, 112, 101, 114, 116, 121, 0, 0, 0,
				0, 67, 68, 105, 103, 105, 116, 97, 108, 79,
				112, 117, 115, 46, 77, 66, 46, 67, 111, 114,
				101, 46, 77, 66, 51, 95, 84, 101, 120, 116,
				117, 114, 101, 67, 111, 109, 98, 105, 110, 101,
				114, 80, 105, 112, 101, 108, 105, 110, 101, 124,
				84, 101, 120, 116, 117, 114, 101, 80, 105, 112,
				101, 108, 105, 110, 101, 68, 97, 116, 97, 0,
				0, 0, 0, 36, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 95, 84, 101, 120,
				116, 117, 114, 101, 65, 114, 114, 97, 121, 115,
				0, 0, 0, 0, 56, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 46, 77, 66, 95, 84, 101,
				120, 116, 117, 114, 101, 65, 114, 114, 97, 121,
				115, 124, 84, 101, 120, 116, 117, 114, 101, 80,
				114, 111, 112, 101, 114, 116, 121, 68, 97, 116,
				97, 0, 0, 0, 0, 47, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 77, 66, 95, 84,
				101, 120, 116, 117, 114, 101, 67, 111, 109, 98,
				105, 110, 101, 114, 83, 82, 80, 67, 117, 115,
				116, 111, 109, 0, 0, 0, 0, 51, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 77, 66,
				95, 84, 101, 120, 116, 117, 114, 101, 67, 111,
				109, 98, 105, 110, 101, 114, 83, 82, 80, 67,
				117, 115, 116, 111, 109, 95, 85, 82, 80, 0,
				0, 0, 0, 56, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 77, 66, 95, 84, 101, 120,
				116, 117, 114, 101, 67, 111, 109, 98, 105, 110,
				101, 114, 83, 82, 80, 67, 117, 115, 116, 111,
				109, 95, 83, 116, 97, 110, 100, 97, 114, 100,
				0, 0, 0, 0, 19, 124, 77, 66, 95, 65,
				116, 108, 97, 115, 101, 115, 65, 110, 100, 82,
				101, 99, 116, 115, 0, 0, 0, 0, 30, 124,
				77, 66, 95, 84, 101, 120, 116, 117, 114, 101,
				65, 114, 114, 97, 121, 82, 101, 115, 117, 108,
				116, 77, 97, 116, 101, 114, 105, 97, 108, 0,
				0, 0, 0, 17, 124, 77, 66, 95, 77, 117,
				108, 116, 105, 77, 97, 116, 101, 114, 105, 97,
				108, 0, 0, 0, 0, 32, 124, 77, 66, 95,
				84, 101, 120, 65, 114, 114, 97, 121, 83, 108,
				105, 99, 101, 82, 101, 110, 100, 101, 114, 101,
				114, 77, 97, 116, 80, 97, 105, 114, 0, 0,
				0, 0, 17, 124, 77, 66, 95, 84, 101, 120,
				65, 114, 114, 97, 121, 83, 108, 105, 99, 101,
				0, 0, 0, 0, 25, 124, 77, 66, 95, 84,
				101, 120, 116, 117, 114, 101, 65, 114, 114, 97,
				121, 82, 101, 102, 101, 114, 101, 110, 99, 101,
				0, 0, 0, 0, 23, 124, 77, 66, 95, 84,
				101, 120, 65, 114, 114, 97, 121, 70, 111, 114,
				80, 114, 111, 112, 101, 114, 116, 121, 0, 0,
				0, 0, 25, 124, 77, 66, 95, 77, 117, 108,
				116, 105, 77, 97, 116, 101, 114, 105, 97, 108,
				84, 101, 120, 65, 114, 114, 97, 121, 0, 0,
				0, 0, 22, 124, 77, 66, 95, 84, 101, 120,
				116, 117, 114, 101, 65, 114, 114, 97, 121, 70,
				111, 114, 109, 97, 116, 0, 0, 0, 0, 25,
				124, 77, 66, 95, 84, 101, 120, 116, 117, 114,
				101, 65, 114, 114, 97, 121, 70, 111, 114, 109,
				97, 116, 83, 101, 116, 0, 0, 0, 0, 21,
				124, 77, 66, 95, 77, 97, 116, 101, 114, 105,
				97, 108, 65, 110, 100, 85, 86, 82, 101, 99,
				116, 0, 0, 0, 0, 23, 124, 77, 66, 50,
				95, 84, 101, 120, 116, 117, 114, 101, 66, 97,
				107, 101, 82, 101, 115, 117, 108, 116, 115, 0,
				0, 0, 0, 38, 77, 66, 50, 95, 84, 101,
				120, 116, 117, 114, 101, 66, 97, 107, 101, 82,
				101, 115, 117, 108, 116, 115, 124, 67, 111, 114,
				111, 117, 116, 105, 110, 101, 82, 101, 115, 117,
				108, 116, 0, 0, 0, 0, 37, 124, 77, 66,
				50, 95, 85, 112, 100, 97, 116, 101, 83, 107,
				105, 110, 110, 101, 100, 77, 101, 115, 104, 66,
				111, 117, 110, 100, 115, 70, 114, 111, 109, 66,
				111, 110, 101, 115, 0, 0, 0, 0, 38, 124,
				77, 66, 50, 95, 85, 112, 100, 97, 116, 101,
				83, 107, 105, 110, 110, 101, 100, 77, 101, 115,
				104, 66, 111, 117, 110, 100, 115, 70, 114, 111,
				109, 66, 111, 117, 110, 100, 115, 0, 0, 0,
				0, 21, 124, 77, 66, 51, 95, 66, 97, 116,
				99, 104, 80, 114, 101, 102, 97, 98, 66, 97,
				107, 101, 114, 0, 0, 0, 0, 39, 77, 66,
				51, 95, 66, 97, 116, 99, 104, 80, 114, 101,
				102, 97, 98, 66, 97, 107, 101, 114, 124, 77,
				66, 51, 95, 80, 114, 101, 102, 97, 98, 66,
				97, 107, 101, 114, 82, 111, 119, 0, 0, 0,
				0, 21, 124, 77, 66, 51, 95, 66, 111, 110,
				101, 87, 101, 105, 103, 104, 116, 67, 111, 112,
				105, 101, 114, 0, 0, 0, 0, 31, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 77, 66,
				51, 95, 67, 111, 109, 109, 101, 110, 116, 0,
				0, 0, 0, 28, 124, 77, 66, 51, 95, 68,
				105, 115, 97, 98, 108, 101, 72, 105, 100, 100,
				101, 110, 65, 110, 105, 109, 97, 116, 105, 111,
				110, 115, 0, 0, 0, 0, 37, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 124, 77, 66, 86,
				101, 114, 115, 105, 111, 110, 67, 111, 110, 99,
				114, 101, 116, 101, 0, 0, 0, 0, 14, 124,
				77, 66, 51, 95, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 0, 0, 0, 0, 20, 124, 77,
				66, 51, 95, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 67, 111, 109, 109, 111, 110, 0, 0,
				0, 0, 21, 124, 77, 66, 51, 95, 77, 101,
				115, 104, 66, 97, 107, 101, 114, 71, 114, 111,
				117, 112, 101, 114, 0, 0, 0, 0, 31, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 71,
				114, 111, 117, 112, 101, 114, 68, 97, 116, 97,
				0, 0, 0, 0, 49, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 71, 114,
				111, 117, 112, 101, 114, 66, 101, 104, 97, 118,
				105, 111, 117, 114, 0, 0, 0, 0, 44, 68,
				105, 103, 105, 116, 97, 108, 79, 112, 117, 115,
				46, 77, 66, 46, 67, 111, 114, 101, 124, 77,
				66, 51, 95, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 71, 114, 111, 117, 112, 101, 114, 78,
				111, 110, 101, 0, 0, 0, 0, 44, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 77, 66,
				51, 95, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 71, 114, 111, 117, 112, 101, 114, 71, 114,
				105, 100, 0, 0, 0, 0, 43, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 124, 77, 66, 51,
				95, 77, 101, 115, 104, 66, 97, 107, 101, 114,
				71, 114, 111, 117, 112, 101, 114, 80, 105, 101,
				0, 0, 0, 0, 47, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 77, 66, 51, 95, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 71, 114,
				111, 117, 112, 101, 114, 67, 108, 117, 115, 116,
				101, 114, 0, 0, 0, 0, 18, 124, 77, 66,
				51, 95, 77, 101, 115, 104, 66, 97, 107, 101,
				114, 82, 111, 111, 116, 0, 0, 0, 0, 30,
				77, 66, 51, 95, 77, 101, 115, 104, 66, 97,
				107, 101, 114, 82, 111, 111, 116, 124, 90, 83,
				111, 114, 116, 79, 98, 106, 101, 99, 116, 115,
				0, 0, 0, 0, 35, 77, 66, 51, 95, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 82, 111,
				111, 116, 43, 90, 83, 111, 114, 116, 79, 98,
				106, 101, 99, 116, 115, 124, 73, 116, 101, 109,
				0, 0, 0, 0, 43, 77, 66, 51, 95, 77,
				101, 115, 104, 66, 97, 107, 101, 114, 82, 111,
				111, 116, 43, 90, 83, 111, 114, 116, 79, 98,
				106, 101, 99, 116, 115, 124, 73, 116, 101, 109,
				67, 111, 109, 112, 97, 114, 101, 114, 0, 0,
				0, 0, 19, 124, 77, 66, 51, 95, 77, 117,
				108, 116, 105, 77, 101, 115, 104, 66, 97, 107,
				101, 114, 0, 0, 0, 0, 17, 124, 77, 66,
				51, 95, 84, 101, 120, 116, 117, 114, 101, 66,
				97, 107, 101, 114, 0, 0, 0, 0, 24, 124,
				77, 66, 95, 80, 114, 101, 115, 101, 114, 118,
				101, 76, 105, 103, 104, 116, 109, 97, 112, 68,
				97, 116, 97, 0, 0, 0, 0, 34, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 84, 101,
				120, 116, 117, 114, 101, 66, 108, 101, 110, 100,
				101, 114, 0, 0, 0, 0, 42, 68, 105, 103,
				105, 116, 97, 108, 79, 112, 117, 115, 46, 77,
				66, 46, 67, 111, 114, 101, 124, 84, 101, 120,
				116, 117, 114, 101, 66, 108, 101, 110, 100, 101,
				114, 70, 97, 108, 108, 98, 97, 99, 107, 0,
				0, 0, 0, 41, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 124, 84, 101, 120, 116, 117, 114,
				101, 66, 108, 101, 110, 100, 101, 114, 72, 68,
				82, 80, 76, 105, 116, 0, 0, 0, 0, 51,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 124,
				84, 101, 120, 116, 117, 114, 101, 66, 108, 101,
				110, 100, 101, 114, 76, 101, 103, 97, 99, 121,
				66, 117, 109, 112, 68, 105, 102, 102, 117, 115,
				101, 0, 0, 0, 0, 47, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 84, 101, 120, 116,
				117, 114, 101, 66, 108, 101, 110, 100, 101, 114,
				76, 101, 103, 97, 99, 121, 68, 105, 102, 102,
				117, 115, 101, 0, 0, 0, 0, 61, 68, 105,
				103, 105, 116, 97, 108, 79, 112, 117, 115, 46,
				77, 66, 46, 67, 111, 114, 101, 124, 84, 101,
				120, 116, 117, 114, 101, 66, 108, 101, 110, 100,
				101, 114, 77, 97, 116, 101, 114, 105, 97, 108,
				80, 114, 111, 112, 101, 114, 116, 121, 67, 97,
				99, 104, 101, 72, 101, 108, 112, 101, 114, 0,
				0, 0, 0, 82, 68, 105, 103, 105, 116, 97,
				108, 79, 112, 117, 115, 46, 77, 66, 46, 67,
				111, 114, 101, 46, 84, 101, 120, 116, 117, 114,
				101, 66, 108, 101, 110, 100, 101, 114, 77, 97,
				116, 101, 114, 105, 97, 108, 80, 114, 111, 112,
				101, 114, 116, 121, 67, 97, 99, 104, 101, 72,
				101, 108, 112, 101, 114, 124, 77, 97, 116, 101,
				114, 105, 97, 108, 80, 114, 111, 112, 101, 114,
				116, 121, 80, 97, 105, 114, 0, 0, 0, 0,
				50, 68, 105, 103, 105, 116, 97, 108, 79, 112,
				117, 115, 46, 77, 66, 46, 67, 111, 114, 101,
				124, 84, 101, 120, 116, 117, 114, 101, 66, 108,
				101, 110, 100, 101, 114, 83, 116, 97, 110, 100,
				97, 114, 100, 77, 101, 116, 97, 108, 108, 105,
				99, 0, 0, 0, 0, 59, 68, 105, 103, 105,
				116, 97, 108, 79, 112, 117, 115, 46, 77, 66,
				46, 67, 111, 114, 101, 124, 84, 101, 120, 116,
				117, 114, 101, 66, 108, 101, 110, 100, 101, 114,
				83, 116, 97, 110, 100, 97, 114, 100, 77, 101,
				116, 97, 108, 108, 105, 99, 82, 111, 117, 103,
				104, 110, 101, 115, 115, 0, 0, 0, 0, 50,
				68, 105, 103, 105, 116, 97, 108, 79, 112, 117,
				115, 46, 77, 66, 46, 67, 111, 114, 101, 124,
				84, 101, 120, 116, 117, 114, 101, 66, 108, 101,
				110, 100, 101, 114, 83, 116, 97, 110, 100, 97,
				114, 100, 83, 112, 101, 99, 117, 108, 97, 114,
				0, 0, 0, 0, 40, 68, 105, 103, 105, 116,
				97, 108, 79, 112, 117, 115, 46, 77, 66, 46,
				67, 111, 114, 101, 124, 84, 101, 120, 116, 117,
				114, 101, 66, 108, 101, 110, 100, 101, 114, 85,
				82, 80, 76, 105, 116
			},
			TotalFiles = 78,
			TotalTypes = 223,
			IsEditorOnly = false
		};
	}
}
namespace DigitalOpus.MB.Core;

[CreateAssetMenu(fileName = "MeshAssignCustomizerNativeArrayPutSliceIdxInUV0_z", menuName = "Mesh Baker/Assign To Mesh Customizer/NativeArray API Put Slice Index In UV0.z", order = 1)]
public class CustomizerNativeArrayPutSliceIndexInUV0_z : MB_DefaultMeshAssignCustomizer_NativeArray
{
	public override int UVchannelWithExtraParameter()
	{
		return 0;
	}

	public override void meshAssign_UV(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, NativeSlice<Vector3> outUVsInMesh, NativeSlice<float> sliceIndexes)
	{
		if (textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.atlas)
		{
			return;
		}
		if (outUVsInMesh.Length == sliceIndexes.Length)
		{
			for (int i = 0; i < outUVsInMesh.Length; i++)
			{
				outUVsInMesh[i] = new Vector3(outUVsInMesh[i].x, outUVsInMesh[i].y, sliceIndexes[i]);
			}
		}
		else
		{
			UnityEngine.Debug.LogError("UV slice buffer was not the same size as the uv buffer");
		}
	}
}
[CreateAssetMenu(fileName = "MeshAssignCustomizerSimpleAPIPutSliceIdxInUV0_z", menuName = "Mesh Baker/Assign To Mesh Customizer/Simple API Put Slice Index In UV0.z", order = 1)]
public class CustomizerPutSliceIndexInUV0_z : MB_DefaultMeshAssignCustomizer
{
	public override void meshAssign_UV0(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		if (textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.atlas)
		{
			mesh.uv = uvs;
		}
		else if (uvs.Length == sliceIndexes.Length)
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < uvs.Length; i++)
			{
				list.Add(new Vector3(uvs[i].x, uvs[i].y, sliceIndexes[i]));
			}
			mesh.SetUVs(0, list);
		}
		else
		{
			UnityEngine.Debug.LogError("UV slice buffer was not the same size as the uv buffer");
		}
	}
}
public delegate void ProgressUpdateDelegate(string msg, float progress);
public delegate bool ProgressUpdateCancelableDelegate(string msg, float progress);
public enum MB_ObjsToCombineTypes
{
	prefabOnly,
	sceneObjOnly,
	dontCare
}
public enum MB_OutputOptions
{
	bakeIntoPrefab,
	bakeMeshsInPlace,
	bakeTextureAtlasesOnly,
	bakeIntoSceneObject
}
public enum MB_RenderType
{
	meshRenderer,
	skinnedMeshRenderer
}
public enum MB2_OutputOptions
{
	bakeIntoSceneObject,
	bakeMeshAssetsInPlace,
	bakeIntoPrefab
}
public enum MB2_LightmapOptions
{
	preserve_current_lightmapping,
	ignore_UV2,
	copy_UV2_unchanged,
	generate_new_UV2_layout,
	copy_UV2_unchanged_to_separate_rects
}
public enum MB2_PackingAlgorithmEnum
{
	UnitysPackTextures,
	MeshBakerTexturePacker,
	MeshBakerTexturePacker_Fast,
	MeshBakerTexturePacker_Horizontal,
	MeshBakerTexturePacker_Vertical,
	MeshBakerTexturePaker_Fast_V2_Beta
}
public enum MB_TextureTilingTreatment
{
	none,
	considerUVs,
	edgeToEdgeX,
	edgeToEdgeY,
	edgeToEdgeXY,
	unknown
}
public enum MB2_ValidationLevel
{
	none,
	quick,
	robust
}
public enum MB_TextureCompressionQuality
{
	fast = 0,
	normal = 50,
	best = 100
}
[Flags]
public enum MB_MeshVertexChannelFlags
{
	none = 0,
	vertex = 1,
	normal = 2,
	tangent = 4,
	colors = 8,
	uv0 = 0x10,
	nuvsSliceIdx = 0x20,
	uv2 = 0x40,
	uv3 = 0x80,
	uv4 = 0x100,
	uv5 = 0x200,
	uv6 = 0x400,
	uv7 = 0x800,
	uv8 = 0x1000,
	blendWeight = 0x2000,
	blendIndices = 0x4000
}
public interface MB2_EditorMethodsInterface
{
	void Clear();

	void RestoreReadFlagsAndFormats(ProgressUpdateDelegate progressInfo);

	void SetReadWriteFlag(Texture2D tx, bool isReadable, bool addToList);

	void ConvertTextureFormat_DefaultPlatform(Texture2D tx, TextureFormat targetFormat, bool isNormalMap);

	void ConvertTextureFormat_PlatformOverride(Texture2D tx, TextureFormat targetFormat, MB_TextureCompressionQuality compressionQuality, bool isNormalMap);

	void SaveTextureArrayToAssetDatabase(Texture2DArray atlas, TextureFormat foramt, string texPropertyName, int atlasNum, Material resMat);

	void SaveAtlasToAssetDatabase(Texture2D atlas, ShaderTextureProperty texPropertyName, int atlasNum, bool doAnySrcMatsHaveProperty, Material resMat);

	bool IsNormalMap(Texture2D tx);

	string GetPlatformString();

	void SetTextureSize(Texture2D tx, int size);

	bool IsCompressed(Texture2D tx);

	void CheckBuildSettings(long estimatedAtlasSize);

	bool CheckPrefabTypes(MB_ObjsToCombineTypes prefabType, List<GameObject> gos);

	bool ValidateSkinnedMeshes(List<GameObject> mom);

	void CommitChangesToAssets();

	void OnPreTextureBake();

	void OnPostTextureBake();

	void Destroy(UnityEngine.Object o);

	void DestroyAsset(UnityEngine.Object o);

	bool IsAnAsset(UnityEngine.Object o);

	Texture2D CreateTemporaryAssetCopyForTextureArray(ShaderTextureProperty prop, Texture2D sliceTex, int w, int h, TextureFormat format, MB2_LogLevel logLevel);

	bool TextureImporterFormatExistsForTextureFormat(TextureFormat texFormat);

	bool ConvertTexture2DArray(Texture2DArray inArray, Texture2DArray outArray, TextureFormat outFormat);

	void GetMaterialPrimaryKeysIfAddressables(MB2_TextureBakeResults textureBakeResults);
}
public enum MB2_LogLevel
{
	none,
	error,
	warn,
	info,
	debug,
	trace
}
public class MB2_Log
{
	public static void Log(MB2_LogLevel l, string msg, MB2_LogLevel currentThreshold)
	{
		if (l <= currentThreshold)
		{
			if (l == MB2_LogLevel.error)
			{
				UnityEngine.Debug.LogError(msg);
			}
			if (l == MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning($"frm={Time.frameCount} WARN {msg}");
			}
			if (l == MB2_LogLevel.info)
			{
				UnityEngine.Debug.Log($"frm={Time.frameCount} INFO {msg}");
			}
			if (l == MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log($"frm={Time.frameCount} DEBUG {msg}");
			}
			if (l == MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"frm={Time.frameCount} TRACE {msg}");
			}
		}
	}

	public static string Error(string msg, params object[] args)
	{
		string arg = string.Format(msg, args);
		string text = $"f={Time.frameCount} ERROR {arg}";
		UnityEngine.Debug.LogError(text);
		return text;
	}

	public static string Warn(string msg, params object[] args)
	{
		string arg = string.Format(msg, args);
		string text = $"f={Time.frameCount} WARN {arg}";
		UnityEngine.Debug.LogWarning(text);
		return text;
	}

	public static string Info(string msg, params object[] args)
	{
		string arg = string.Format(msg, args);
		string text = $"f={Time.frameCount} INFO {arg}";
		UnityEngine.Debug.Log(text);
		return text;
	}

	public static string LogDebug(string msg, params object[] args)
	{
		string arg = string.Format(msg, args);
		string text = $"f={Time.frameCount} DEBUG {arg}";
		UnityEngine.Debug.Log(text);
		return text;
	}

	public static string Trace(string msg, params object[] args)
	{
		string arg = string.Format(msg, args);
		string text = $"f={Time.frameCount} TRACE {arg}";
		UnityEngine.Debug.Log(text);
		return text;
	}
}
public class ObjectLog
{
	private int pos;

	private string[] logMessages;

	private void _CacheLogMessage(string msg)
	{
		if (logMessages.Length != 0)
		{
			logMessages[pos] = msg;
			pos++;
			if (pos >= logMessages.Length)
			{
				pos = 0;
			}
		}
	}

	public ObjectLog(short bufferSize)
	{
		logMessages = new string[bufferSize];
	}

	public void Log(MB2_LogLevel l, string msg, MB2_LogLevel currentThreshold)
	{
		MB2_Log.Log(l, msg, currentThreshold);
		_CacheLogMessage(msg);
	}

	public void Error(string msg, params object[] args)
	{
		_CacheLogMessage(MB2_Log.Error(msg, args));
	}

	public void Warn(string msg, params object[] args)
	{
		_CacheLogMessage(MB2_Log.Warn(msg, args));
	}

	public void Info(string msg, params object[] args)
	{
		_CacheLogMessage(MB2_Log.Info(msg, args));
	}

	public void LogDebug(string msg, params object[] args)
	{
		_CacheLogMessage(MB2_Log.LogDebug(msg, args));
	}

	public void Trace(string msg, params object[] args)
	{
		_CacheLogMessage(MB2_Log.Trace(msg, args));
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		if (logMessages[logMessages.Length - 1] != null)
		{
			num = pos;
		}
		for (int i = 0; i < logMessages.Length; i++)
		{
			int num2 = (num + i) % logMessages.Length;
			if (logMessages[num2] == null)
			{
				break;
			}
			stringBuilder.AppendLine(logMessages[num2]);
		}
		return stringBuilder.ToString();
	}
}
public interface MBVersionInterface
{
	string version();

	bool Is_2018_3_OrNewer();

	bool Is_2017_1_OrNewer();

	bool GetActive(GameObject go);

	void SetActive(GameObject go, bool isActive);

	void SetActiveRecursively(GameObject go, bool isActive);

	UnityEngine.Object[] FindSceneObjectsOfType(Type t);

	bool IsRunningAndMeshNotReadWriteable(Mesh m);

	Vector2[] GetMeshUVChannel(int channel, Mesh m, MB2_LogLevel LOG_LEVEL);

	void MeshClear(Mesh m, bool t);

	void MeshAssignUVChannel(int channel, Mesh m, Vector2[] uvs);

	Vector4 GetLightmapTilingOffset(Renderer r);

	Transform[] GetBones(Renderer r, bool isSkinnedMeshWithBones);

	void OptimizeMesh(Mesh m);

	int GetBlendShapeFrameCount(Mesh m, int shapeIndex);

	float GetBlendShapeFrameWeight(Mesh m, int shapeIndex, int frameIndex);

	void GetBlendShapeFrameVertices(Mesh m, int shapeIndex, int frameIndex, Vector3[] vs, Vector3[] ns, Vector3[] ts);

	void ClearBlendShapes(Mesh m);

	void AddBlendShapeFrame(Mesh m, string nm, float wt, Vector3[] vs, Vector3[] ns, Vector3[] ts);

	int MaxMeshVertexCount();

	void SetMeshIndexFormatAndClearMesh(Mesh m, int numVerts, bool vertices, bool justClearTriangles);

	bool GraphicsUVStartsAtTop();

	bool IsTextureReadable(Texture2D tex);

	bool IsSwizzledNormalMapPlatform();

	bool IsMaterialKeywordValid(Material mat, string keyword);

	bool IsTexture_sRGBgammaCorrected(Texture2D tex, bool hint);

	bool CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, ShaderTextureProperty[] shaderTexPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, Material resultMaterial, MB2_LogLevel LOG_LEVEL);

	void DoSpecialRenderPipeline_TexturePackerFastSetup(GameObject cameraGameObject);

	ColorSpace GetProjectColorSpace();

	MBVersion.PipelineType DetectPipeline();

	string UnescapeURL(string url);

	IEnumerator FindRuntimeMaterialsFromAddresses(MB2_TextureBakeResults textureBakeResult, MB2_TextureBakeResults.CoroutineResult isComplete);

	float GetScaleInLightmap(MeshRenderer r);

	bool IsAssetInProject(UnityEngine.Object target);
}
public class MBVersion
{
	public enum PipelineType
	{
		Unsupported,
		Default,
		URP,
		HDRP
	}

	public const string MB_USING_HDRP = "MB_USING_HDRP";

	private static MBVersionInterface _MBVersion;

	private static MBVersionInterface _CreateMBVersionConcrete()
	{
		return (MBVersionInterface)Activator.CreateInstance(typeof(MBVersionConcrete));
	}

	public static string version()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.version();
	}

	public static bool Is_2018_3_OrNewer()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.Is_2018_3_OrNewer();
	}

	public static bool Is_2017_1_OrNewer()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.Is_2017_1_OrNewer();
	}

	public static bool GetActive(GameObject go)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetActive(go);
	}

	public static void SetActive(GameObject go, bool isActive)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.SetActive(go, isActive);
	}

	public static void SetActiveRecursively(GameObject go, bool isActive)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.SetActiveRecursively(go, isActive);
	}

	public static UnityEngine.Object[] FindSceneObjectsOfType(Type t)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.FindSceneObjectsOfType(t);
	}

	public static bool IsRunningAndMeshNotReadWriteable(Mesh m)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.IsRunningAndMeshNotReadWriteable(m);
	}

	public static Vector2[] GetMeshChannel(int channel, Mesh m, MB2_LogLevel LOG_LEVEL)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetMeshUVChannel(channel, m, LOG_LEVEL);
	}

	public static float GetScaleInLightmap(MeshRenderer r)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetScaleInLightmap(r);
	}

	public static void MeshClear(Mesh m, bool t)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.MeshClear(m, t);
	}

	public static void MeshAssignUVChannel(int channel, Mesh m, Vector2[] uvs)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.MeshAssignUVChannel(channel, m, uvs);
	}

	public static Vector4 GetLightmapTilingOffset(Renderer r)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetLightmapTilingOffset(r);
	}

	public static Transform[] GetBones(Renderer r, bool isSkinnedMeshWithBones)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetBones(r, isSkinnedMeshWithBones);
	}

	public static bool IsSwizzledNormalMapPlatform()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.IsSwizzledNormalMapPlatform();
	}

	public static bool IsMaterialKeywordValid(Material mat, string keyword)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.IsMaterialKeywordValid(mat, keyword);
	}

	public static void OptimizeMesh(Mesh m)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.OptimizeMesh(m);
	}

	public static int GetBlendShapeFrameCount(Mesh m, int shapeIndex)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetBlendShapeFrameCount(m, shapeIndex);
	}

	public static float GetBlendShapeFrameWeight(Mesh m, int shapeIndex, int frameIndex)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetBlendShapeFrameWeight(m, shapeIndex, frameIndex);
	}

	public static void GetBlendShapeFrameVertices(Mesh m, int shapeIndex, int frameIndex, Vector3[] vs, Vector3[] ns, Vector3[] ts)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.GetBlendShapeFrameVertices(m, shapeIndex, frameIndex, vs, ns, ts);
	}

	public static void ClearBlendShapes(Mesh m)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.ClearBlendShapes(m);
	}

	public static void AddBlendShapeFrame(Mesh m, string nm, float wt, Vector3[] vs, Vector3[] ns, Vector3[] ts)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.AddBlendShapeFrame(m, nm, wt, vs, ns, ts);
	}

	public static int MaxMeshVertexCount()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.MaxMeshVertexCount();
	}

	public static void SetMeshIndexFormatAndClearMesh(Mesh m, int numVerts, bool vertices, bool justClearTriangles)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.SetMeshIndexFormatAndClearMesh(m, numVerts, vertices, justClearTriangles);
	}

	public static bool GraphicsUVStartsAtTop()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GraphicsUVStartsAtTop();
	}

	public static bool IsTexture_sRGBgammaCorrected(Texture2D tex, bool hint)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.IsTexture_sRGBgammaCorrected(tex, hint);
	}

	public static bool IsTextureReadable(Texture2D tex)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.IsTextureReadable(tex);
	}

	public static void CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, ShaderTextureProperty[] shaderTexPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, Material resultMaterial, MB2_LogLevel LOG_LEVEL)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.CollectPropertyNames(texPropertyNames, shaderTexPropertyNames, _customShaderPropNames, resultMaterial, LOG_LEVEL);
	}

	internal static void DoSpecialRenderPipeline_TexturePackerFastSetup(GameObject cameraGameObject)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		_MBVersion.DoSpecialRenderPipeline_TexturePackerFastSetup(cameraGameObject);
	}

	public static ColorSpace GetProjectColorSpace()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.GetProjectColorSpace();
	}

	public static PipelineType DetectPipeline()
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.DetectPipeline();
	}

	public static string UnescapeURL(string url)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.UnescapeURL(url);
	}

	public static bool IsAssetInProject(UnityEngine.Object target)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		return _MBVersion.IsAssetInProject(target);
	}

	public static bool IsUsingAddressables()
	{
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (assembly.ToString().Contains("Addressables") && assembly.GetType("UnityEngine.AddressableAssets.AssetReference") != null)
			{
				return true;
			}
		}
		return false;
	}

	internal static IEnumerator FindRuntimeMaterialsFromAddresses(MB2_TextureBakeResults textureBakeResult, MB2_TextureBakeResults.CoroutineResult isComplete)
	{
		if (_MBVersion == null)
		{
			_MBVersion = _CreateMBVersionConcrete();
		}
		yield return _MBVersion.FindRuntimeMaterialsFromAddresses(textureBakeResult, isComplete);
	}
}
[Serializable]
public class MB3_AgglomerativeClustering
{
	[Serializable]
	public class ClusterNode
	{
		public item_s leaf;

		public ClusterNode cha;

		public ClusterNode chb;

		public int height;

		public float distToMergedCentroid;

		public Vector3 centroid;

		public int[] leafs;

		public int idx;

		public bool isUnclustered = true;

		public ClusterNode(item_s ii, int index)
		{
			leaf = ii;
			idx = index;
			leafs = new int[1];
			leafs[0] = index;
			centroid = ii.coord;
			height = 0;
		}

		public ClusterNode(ClusterNode a, ClusterNode b, int index, int h, float dist, ClusterNode[] clusters)
		{
			cha = a;
			chb = b;
			idx = index;
			leafs = new int[a.leafs.Length + b.leafs.Length];
			Array.Copy(a.leafs, leafs, a.leafs.Length);
			Array.Copy(b.leafs, 0, leafs, a.leafs.Length, b.leafs.Length);
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < leafs.Length; i++)
			{
				zero += clusters[leafs[i]].centroid;
			}
			centroid = zero / leafs.Length;
			height = h;
			distToMergedCentroid = dist;
		}
	}

	[Serializable]
	public class item_s
	{
		public GameObject go;

		public Vector3 coord;
	}

	public class ClusterDistance
	{
		public ClusterNode a;

		public ClusterNode b;

		public ClusterDistance(ClusterNode aa, ClusterNode bb)
		{
			a = aa;
			b = bb;
		}
	}

	public List<item_s> items = new List<item_s>();

	public ClusterNode[] clusters;

	public bool wasCanceled;

	private const int MAX_PRIORITY_Q_SIZE = 2048;

	private float euclidean_distance(Vector3 a, Vector3 b)
	{
		return Vector3.Distance(a, b);
	}

	public bool agglomerate(ProgressUpdateCancelableDelegate progFunc)
	{
		wasCanceled = true;
		if (progFunc != null)
		{
			wasCanceled = progFunc("Filling Priority Queue:", 0f);
		}
		if (items.Count <= 1)
		{
			clusters = new ClusterNode[0];
			return false;
		}
		clusters = new ClusterNode[items.Count * 2 - 1];
		for (int i = 0; i < items.Count; i++)
		{
			clusters[i] = new ClusterNode(items[i], i);
		}
		int num = items.Count;
		List<ClusterNode> list = new List<ClusterNode>();
		for (int j = 0; j < num; j++)
		{
			clusters[j].isUnclustered = true;
			list.Add(clusters[j]);
		}
		int num2 = 0;
		new Stopwatch().Start();
		float num3 = 0f;
		long num4 = GC.GetTotalMemory(forceFullCollection: false) / 1000000;
		PriorityQueue<float, ClusterDistance> priorityQueue = new PriorityQueue<float, ClusterDistance>();
		int num5 = 0;
		while (list.Count > 1)
		{
			int num6 = 0;
			num2++;
			if (priorityQueue.Count == 0)
			{
				num5++;
				num4 = GC.GetTotalMemory(forceFullCollection: false) / 1000000;
				if (progFunc != null)
				{
					wasCanceled = progFunc("Refilling Q:" + (float)(items.Count - list.Count) * 100f / (float)items.Count + " unclustered:" + list.Count + " inQ:" + priorityQueue.Count + " usedMem:" + num4, (float)(items.Count - list.Count) / (float)items.Count);
				}
				num3 = _RefillPriorityQWithSome(priorityQueue, list, clusters, progFunc);
				if (priorityQueue.Count == 0)
				{
					break;
				}
			}
			KeyValuePair<float, ClusterDistance> keyValuePair = priorityQueue.Dequeue();
			while (!keyValuePair.Value.a.isUnclustered || !keyValuePair.Value.b.isUnclustered)
			{
				if (priorityQueue.Count == 0)
				{
					num5++;
					num4 = GC.GetTotalMemory(forceFullCollection: false) / 1000000;
					if (progFunc != null)
					{
						wasCanceled = progFunc("Creating clusters:" + (float)(items.Count - list.Count) * 100f / (float)items.Count + " unclustered:" + list.Count + " inQ:" + priorityQueue.Count + " usedMem:" + num4, (float)(items.Count - list.Count) / (float)items.Count);
					}
					num3 = _RefillPriorityQWithSome(priorityQueue, list, clusters, progFunc);
					if (priorityQueue.Count == 0)
					{
						break;
					}
				}
				keyValuePair = priorityQueue.Dequeue();
				num6++;
			}
			num++;
			ClusterNode clusterNode = new ClusterNode(keyValuePair.Value.a, keyValuePair.Value.b, num - 1, num2, keyValuePair.Key, clusters);
			list.Remove(keyValuePair.Value.a);
			list.Remove(keyValuePair.Value.b);
			keyValuePair.Value.a.isUnclustered = false;
			keyValuePair.Value.b.isUnclustered = false;
			int num7 = num - 1;
			if (num7 == clusters.Length)
			{
				UnityEngine.Debug.LogError("how did this happen");
			}
			clusters[num7] = clusterNode;
			list.Add(clusterNode);
			clusterNode.isUnclustered = true;
			for (int k = 0; k < list.Count - 1; k++)
			{
				float num8 = euclidean_distance(clusterNode.centroid, list[k].centroid);
				if (num8 < num3)
				{
					priorityQueue.Add(new KeyValuePair<float, ClusterDistance>(num8, new ClusterDistance(clusterNode, list[k])));
				}
			}
			if (wasCanceled)
			{
				break;
			}
			num4 = GC.GetTotalMemory(forceFullCollection: false) / 1000000;
			if (progFunc != null)
			{
				wasCanceled = progFunc("Creating clusters:" + (float)(items.Count - list.Count) * 100f / (float)items.Count + " unclustered:" + list.Count + " inQ:" + priorityQueue.Count + " usedMem:" + num4, (float)(items.Count - list.Count) / (float)items.Count);
			}
		}
		if (progFunc != null)
		{
			wasCanceled = progFunc("Finished clustering:", 100f);
		}
		if (wasCanceled)
		{
			return false;
		}
		return true;
	}

	private float _RefillPriorityQWithSome(PriorityQueue<float, ClusterDistance> pq, List<ClusterNode> unclustered, ClusterNode[] clusters, ProgressUpdateCancelableDelegate progFunc)
	{
		List<float> list = new List<float>(2048);
		for (int i = 0; i < unclustered.Count; i++)
		{
			for (int j = i + 1; j < unclustered.Count; j++)
			{
				list.Add(euclidean_distance(unclustered[i].centroid, unclustered[j].centroid));
			}
			wasCanceled = progFunc("Refilling Queue Part A:", (float)i / ((float)unclustered.Count * 2f));
			if (wasCanceled)
			{
				return 10f;
			}
		}
		if (list.Count == 0)
		{
			return 1E+11f;
		}
		float num = NthSmallestElement(list, 2048);
		for (int k = 0; k < unclustered.Count; k++)
		{
			for (int l = k + 1; l < unclustered.Count; l++)
			{
				int idx = unclustered[k].idx;
				int idx2 = unclustered[l].idx;
				float num2 = euclidean_distance(unclustered[k].centroid, unclustered[l].centroid);
				if (num2 <= num)
				{
					pq.Add(new KeyValuePair<float, ClusterDistance>(num2, new ClusterDistance(clusters[idx], clusters[idx2])));
				}
			}
			wasCanceled = progFunc("Refilling Queue Part B:", (float)(unclustered.Count + k) / ((float)unclustered.Count * 2f));
			if (wasCanceled)
			{
				return 10f;
			}
		}
		return num;
	}

	public int TestRun(List<GameObject> gos)
	{
		List<item_s> list = new List<item_s>();
		for (int i = 0; i < gos.Count; i++)
		{
			item_s item_s2 = new item_s();
			item_s2.go = gos[i];
			item_s2.coord = gos[i].transform.position;
			list.Add(item_s2);
		}
		items = list;
		if (items.Count > 0)
		{
			agglomerate(null);
		}
		return 0;
	}

	public static void Main()
	{
		List<float> list = new List<float>();
		list.AddRange(new float[10] { 19f, 18f, 17f, 16f, 15f, 10f, 11f, 12f, 13f, 14f });
		UnityEngine.Debug.Log("Loop quick select 10 times.");
		UnityEngine.Debug.Log(NthSmallestElement(list, 0));
	}

	public static T NthSmallestElement<T>(List<T> array, int n) where T : IComparable<T>
	{
		if (n < 0)
		{
			n = 0;
		}
		if (n > array.Count - 1)
		{
			n = array.Count - 1;
		}
		if (array.Count == 0)
		{
			throw new ArgumentException("Array is empty.", "array");
		}
		if (array.Count == 1)
		{
			return array[0];
		}
		return QuickSelectSmallest(array, n)[n];
	}

	private static List<T> QuickSelectSmallest<T>(List<T> input, int n) where T : IComparable<T>
	{
		int num = 0;
		int num2 = input.Count - 1;
		int pivotIndex = n;
		System.Random random = new System.Random();
		while (num2 > num)
		{
			pivotIndex = QuickSelectPartition(input, num, num2, pivotIndex);
			if (pivotIndex == n)
			{
				break;
			}
			if (pivotIndex > n)
			{
				num2 = pivotIndex - 1;
			}
			else
			{
				num = pivotIndex + 1;
			}
			pivotIndex = random.Next(num, num2);
		}
		return input;
	}

	private static int QuickSelectPartition<T>(List<T> array, int startIndex, int endIndex, int pivotIndex) where T : IComparable<T>
	{
		T other = array[pivotIndex];
		Swap(array, pivotIndex, endIndex);
		for (int i = startIndex; i < endIndex; i++)
		{
			if (array[i].CompareTo(other) <= 0)
			{
				Swap(array, i, startIndex);
				startIndex++;
			}
		}
		Swap(array, endIndex, startIndex);
		return startIndex;
	}

	private static void Swap<T>(List<T> array, int index1, int index2)
	{
		if (index1 != index2)
		{
			T value = array[index1];
			array[index1] = array[index2];
			array[index2] = value;
		}
	}
}
public class MB3_CopyBoneWeights
{
	public static void CopyBoneWeightsFromSeamMeshToOtherMeshes(float radius, Mesh seamMesh, Mesh[] targetMeshes, Transform[][] newBonesForSMRs, Transform[] seamMeshBones, Transform[][] targMeshBones)
	{
		List<int> list = new List<int>();
		if (seamMesh == null)
		{
			UnityEngine.Debug.LogError($"The SeamMesh cannot be null");
			return;
		}
		if (seamMesh.vertexCount == 0)
		{
			UnityEngine.Debug.LogError("The seam mesh has no vertices. Check that the Asset Importer for the seam mesh does not have 'Optimize Mesh' checked.");
			return;
		}
		Vector3[] vertices = seamMesh.vertices;
		BoneWeight[] boneWeights = seamMesh.boneWeights;
		Vector3[] normals = seamMesh.normals;
		Vector4[] tangents = seamMesh.tangents;
		Vector2[] uv = seamMesh.uv;
		if (uv.Length != vertices.Length)
		{
			UnityEngine.Debug.LogError("The seam mesh needs uvs to identify which vertices are part of the seam. Vertices with UV > .5 are part of the seam. Vertices with UV < .5 are not part of the seam.");
			return;
		}
		for (int i = 0; i < uv.Length; i++)
		{
			if (uv[i].x > 0.5f && uv[i].y > 0.5f)
			{
				list.Add(i);
			}
		}
		UnityEngine.Debug.Log($"The seam mesh has {seamMesh.vertices.Length} vertices of which {list.Count} are seam vertices.");
		if (list.Count == 0)
		{
			UnityEngine.Debug.LogError("None of the vertices in the Seam Mesh were marked as seam vertices. To mark a vertex as a seam vertex the UV must be greater than (.5,.5). Vertices with UV less than (.5,.5) are excluded.");
			return;
		}
		bool flag = false;
		if (radius <= 0f)
		{
			UnityEngine.Debug.LogError("radius must be greater than zero.");
		}
		for (int j = 0; j < targetMeshes.Length; j++)
		{
			if (targetMeshes[j] == null)
			{
				UnityEngine.Debug.LogError($"Mesh {j} was null");
				flag = true;
			}
		}
		if (flag)
		{
			return;
		}
		Dictionary<Transform, int> dictionary = new Dictionary<Transform, int>();
		int[] array = new int[seamMeshBones.Length];
		for (int k = 0; k < seamMeshBones.Length; k++)
		{
			dictionary.Add(seamMeshBones[k], k);
		}
		Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
		for (int l = 0; l < targetMeshes.Length; l++)
		{
			Mesh mesh = targetMeshes[l];
			if (mesh == seamMesh)
			{
				continue;
			}
			Vector3[] vertices2 = mesh.vertices;
			BoneWeight[] boneWeights2 = mesh.boneWeights;
			Vector3[] normals2 = mesh.normals;
			Vector4[] tangents2 = mesh.tangents;
			dictionary2.Clear();
			for (int m = 0; m < array.Length; m++)
			{
				array[m] = -1;
			}
			Transform[] array2 = targMeshBones[l];
			for (int n = 0; n < array2.Length; n++)
			{
				Transform key = array2[n];
				if (dictionary.ContainsKey(key))
				{
					int num = dictionary[key];
					array[num] = n;
				}
			}
			int num2 = 0;
			for (int num3 = 0; num3 < vertices2.Length; num3++)
			{
				for (int num4 = 0; num4 < list.Count; num4++)
				{
					int num5 = list[num4];
					if (Vector3.Distance(vertices2[num3], vertices[num5]) <= radius)
					{
						if (seamMesh == targetMeshes[l] && num3 != num5)
						{
							UnityEngine.Debug.LogError("Same mesh but different verts overlapped. radius too big " + num3 + "  " + num5);
						}
						num2++;
						BoneWeight seamMeshBw = boneWeights[num5];
						RemapBoneWeightIndexes(targetMeshes[l].name, ref seamMeshBw, array, targMeshBones[l], dictionary2, seamMeshBones);
						boneWeights2[num3] = seamMeshBw;
						vertices2[num3] = vertices[num5];
						if (normals2.Length == vertices2.Length && normals.Length == normals.Length)
						{
							normals2[num3] = normals[num5];
						}
						if (tangents2.Length == vertices2.Length && tangents.Length == vertices.Length)
						{
							tangents2[num3] = tangents[num5];
						}
					}
				}
			}
			if (dictionary2.Count > 0)
			{
				int num6 = targMeshBones[l].Length + dictionary2.Count;
				Transform[] array3 = new Transform[num6];
				Matrix4x4[] array4 = new Matrix4x4[num6];
				Matrix4x4[] bindposes = targetMeshes[l].bindposes;
				for (int num7 = 0; num7 < targMeshBones[l].Length; num7++)
				{
					array4[num7] = bindposes[num7];
					array3[num7] = targMeshBones[l][num7];
				}
				Matrix4x4[] bindposes2 = seamMesh.bindposes;
				foreach (KeyValuePair<int, int> item in dictionary2)
				{
					array3[item.Value] = seamMeshBones[item.Key];
					array4[item.Value] = bindposes2[item.Key];
				}
				for (int num8 = 0; num8 < dictionary2.Count; num8++)
				{
					if (array3[num8] == null)
					{
						UnityEngine.Debug.LogError("Should never happend. Not all target indexes were covered.");
					}
				}
				newBonesForSMRs[l] = array3;
				targetMeshes[l].bindposes = array4;
			}
			if (num2 > 0)
			{
				targetMeshes[l].vertices = vertices2;
				targetMeshes[l].boneWeights = boneWeights2;
				targetMeshes[l].normals = normals2;
				targetMeshes[l].tangents = tangents2;
			}
			UnityEngine.Debug.Log(string.Format("Copied boneweights for {1} vertices in mesh {0} that matched positions in the seam mesh.", targetMeshes[l].name, num2));
		}
	}

	private static void RemapBoneWeightIndexes(string nm, ref BoneWeight seamMeshBw, int[] map_seamMeshIdx2targMeshIdx, Transform[] targBones, Dictionary<int, int> extraBones, Transform[] seamBones)
	{
		int num = map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex0];
		int num2 = map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex1];
		int num3 = map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex2];
		int num4 = map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex3];
		if (num == -1)
		{
			num = targBones.Length + extraBones.Count;
			extraBones.Add(seamMeshBw.boneIndex0, num);
			map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex0] = num;
		}
		if (num2 == -1)
		{
			num2 = targBones.Length + extraBones.Count;
			extraBones.Add(seamMeshBw.boneIndex1, num2);
			map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex1] = num2;
		}
		if (num3 == -1)
		{
			num3 = targBones.Length + extraBones.Count;
			extraBones.Add(seamMeshBw.boneIndex2, num3);
			map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex2] = num3;
		}
		if (num4 == -1)
		{
			num4 = targBones.Length + extraBones.Count;
			extraBones.Add(seamMeshBw.boneIndex3, num4);
			map_seamMeshIdx2targMeshIdx[seamMeshBw.boneIndex3] = num4;
		}
		seamMeshBw.boneIndex0 = num;
		seamMeshBw.boneIndex1 = num2;
		seamMeshBw.boneIndex2 = num3;
		seamMeshBw.boneIndex3 = num4;
	}
}
public class MB3_KMeansClustering
{
	private class DataPoint
	{
		public Vector3 center;

		public GameObject gameObject;

		public int Cluster;

		public DataPoint(GameObject go)
		{
			gameObject = go;
			center = go.transform.position;
			if (go.GetComponent<Renderer>() == null)
			{
				UnityEngine.Debug.LogError("Object does not have a renderer " + go);
			}
		}
	}

	private List<DataPoint> _normalizedDataToCluster = new List<DataPoint>();

	private Vector3[] _clusters = new Vector3[0];

	private int _numberOfClusters;

	public MB3_KMeansClustering(List<GameObject> gos, int numClusters)
	{
		for (int i = 0; i < gos.Count; i++)
		{
			if (gos[i] != null)
			{
				DataPoint item = new DataPoint(gos[i]);
				_normalizedDataToCluster.Add(item);
			}
			else
			{
				UnityEngine.Debug.LogWarning($"Object {i} in list of objects to cluster was null.");
			}
		}
		if (numClusters <= 0)
		{
			UnityEngine.Debug.LogError("Number of clusters must be posititve.");
			numClusters = 1;
		}
		if (_normalizedDataToCluster.Count <= numClusters)
		{
			UnityEngine.Debug.LogError("There must be fewer clusters than objects to cluster");
			numClusters = _normalizedDataToCluster.Count - 1;
		}
		_numberOfClusters = numClusters;
		if (_numberOfClusters <= 0)
		{
			_numberOfClusters = 1;
		}
		_clusters = new Vector3[_numberOfClusters];
	}

	private void InitializeCentroids()
	{
		for (int i = 0; i < _numberOfClusters; i++)
		{
			_normalizedDataToCluster[i].Cluster = i;
		}
		for (int j = _numberOfClusters; j < _normalizedDataToCluster.Count; j++)
		{
			_normalizedDataToCluster[j].Cluster = UnityEngine.Random.Range(0, _numberOfClusters);
		}
	}

	private bool UpdateDataPointMeans(bool force)
	{
		if (AnyAreEmpty(_normalizedDataToCluster) && !force)
		{
			return false;
		}
		Vector3[] array = new Vector3[_numberOfClusters];
		int[] array2 = new int[_numberOfClusters];
		for (int i = 0; i < _normalizedDataToCluster.Count; i++)
		{
			int cluster = _normalizedDataToCluster[i].Cluster;
			array[cluster] += _normalizedDataToCluster[i].center;
			array2[cluster]++;
		}
		for (int j = 0; j < _numberOfClusters; j++)
		{
			_clusters[j] = array[j] / array2[j];
		}
		return true;
	}

	private bool AnyAreEmpty(List<DataPoint> data)
	{
		int[] array = new int[_numberOfClusters];
		for (int i = 0; i < _normalizedDataToCluster.Count; i++)
		{
			array[_normalizedDataToCluster[i].Cluster]++;
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] == 0)
			{
				return true;
			}
		}
		return false;
	}

	private bool UpdateClusterMembership()
	{
		bool flag = false;
		float[] array = new float[_numberOfClusters];
		for (int i = 0; i < _normalizedDataToCluster.Count; i++)
		{
			for (int j = 0; j < _numberOfClusters; j++)
			{
				array[j] = ElucidanDistance(_normalizedDataToCluster[i], _clusters[j]);
			}
			int num = MinIndex(array);
			if (num != _normalizedDataToCluster[i].Cluster)
			{
				flag = true;
				_normalizedDataToCluster[i].Cluster = num;
			}
		}
		if (!flag)
		{
			return false;
		}
		return true;
	}

	private float ElucidanDistance(DataPoint dataPoint, Vector3 mean)
	{
		return Vector3.Distance(dataPoint.center, mean);
	}

	private int MinIndex(float[] distances)
	{
		int result = 0;
		double num = distances[0];
		for (int i = 0; i < distances.Length; i++)
		{
			if ((double)distances[i] < num)
			{
				num = distances[i];
				result = i;
			}
		}
		return result;
	}

	public List<Renderer> GetCluster(int idx, out Vector3 mean, out float size)
	{
		if (idx < 0 || idx >= _numberOfClusters)
		{
			UnityEngine.Debug.LogError("idx is out of bounds");
			mean = Vector3.zero;
			size = 1f;
			return new List<Renderer>();
		}
		UpdateDataPointMeans(force: true);
		List<Renderer> list = new List<Renderer>();
		mean = _clusters[idx];
		float num = 0f;
		for (int i = 0; i < _normalizedDataToCluster.Count; i++)
		{
			if (_normalizedDataToCluster[i].Cluster == idx)
			{
				float num2 = Vector3.Distance(mean, _normalizedDataToCluster[i].center);
				if (num2 > num)
				{
					num = num2;
				}
				list.Add(_normalizedDataToCluster[i].gameObject.GetComponent<Renderer>());
			}
		}
		mean = _clusters[idx];
		size = num;
		return list;
	}

	public void Cluster()
	{
		bool flag = true;
		bool flag2 = true;
		InitializeCentroids();
		int num = _normalizedDataToCluster.Count * 1000;
		int num2 = 0;
		while (flag2 && flag && num2 < num)
		{
			num2++;
			flag2 = UpdateDataPointMeans(force: false);
			flag = UpdateClusterMembership();
		}
	}
}
[Serializable]
public abstract class MB3_MeshCombiner : MB_IMeshBakerSettings, IDisposable
{
	public enum MeshCombiningStatus
	{
		preAddDeleteOrUpdate,
		readyForApply
	}

	public delegate void GenerateUV2Delegate(Mesh m, float hardAngle, float packMargin);

	public class MBBlendShapeKey
	{
		public GameObject gameObject;

		public int blendShapeIndexInSrc;

		public MBBlendShapeKey(GameObject srcSkinnedMeshRenderGameObject, int blendShapeIndexInSource)
		{
			gameObject = srcSkinnedMeshRenderGameObject;
			blendShapeIndexInSrc = blendShapeIndexInSource;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is MBBlendShapeKey) || obj == null)
			{
				return false;
			}
			MBBlendShapeKey mBBlendShapeKey = (MBBlendShapeKey)obj;
			if (gameObject == mBBlendShapeKey.gameObject)
			{
				return blendShapeIndexInSrc == mBBlendShapeKey.blendShapeIndexInSrc;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (23 * 31 + gameObject.GetInstanceID()) * 31 + blendShapeIndexInSrc;
		}
	}

	public class MBBlendShapeValue
	{
		public GameObject combinedMeshGameObject;

		public int blendShapeIndex;
	}

	[SerializeField]
	protected MeshCombiningStatus _bakeStatus;

	[SerializeField]
	protected MB2_ValidationLevel _validationLevel = MB2_ValidationLevel.robust;

	[SerializeField]
	protected string _name;

	[SerializeField]
	protected MB2_TextureBakeResults _textureBakeResults;

	[SerializeField]
	protected GameObject _resultSceneObject;

	[SerializeField]
	protected Renderer _targetRenderer;

	[SerializeField]
	protected MB2_LogLevel _LOG_LEVEL = MB2_LogLevel.info;

	[SerializeField]
	protected UnityEngine.Object _settingsHolder;

	[SerializeField]
	protected MB2_OutputOptions _outputOption;

	[SerializeField]
	protected MB_RenderType _renderType;

	[SerializeField]
	protected MB2_LightmapOptions _lightmapOption = MB2_LightmapOptions.ignore_UV2;

	[SerializeField]
	protected bool _doNorm = true;

	[SerializeField]
	protected bool _doTan = true;

	[SerializeField]
	protected bool _doCol;

	[SerializeField]
	protected bool _doUV = true;

	[SerializeField]
	protected bool _doUV3;

	[SerializeField]
	protected bool _doUV4;

	[SerializeField]
	protected bool _doUV5;

	[SerializeField]
	protected bool _doUV6;

	[SerializeField]
	protected bool _doUV7;

	[SerializeField]
	protected bool _doUV8;

	[SerializeField]
	protected bool _doBlendShapes;

	[FormerlySerializedAs("_recenterVertsToBoundsCenter")]
	[SerializeField]
	protected MB_MeshPivotLocation _pivotLocationType;

	[SerializeField]
	protected Vector3 _pivotLocation;

	[SerializeField]
	protected bool _clearBuffersAfterBake;

	[SerializeField]
	public bool _optimizeAfterBake = true;

	[SerializeField]
	[FormerlySerializedAs("uv2UnwrappingParamsHardAngle")]
	protected float _uv2UnwrappingParamsHardAngle = 60f;

	[SerializeField]
	[FormerlySerializedAs("uv2UnwrappingParamsPackMargin")]
	protected float _uv2UnwrappingParamsPackMargin = 0.005f;

	[SerializeField]
	protected bool _smrNoExtraBonesWhenCombiningMeshRenderers;

	[SerializeField]
	protected bool _smrMergeBlendShapesWithSameNames;

	[SerializeField]
	protected UnityEngine.Object _assignToMeshCustomizer;

	[SerializeField]
	protected MB_MeshCombineAPIType _meshAPItoUse = MB_MeshCombineAPIType.betaNativeArrayAPI;

	protected bool _usingTemporaryTextureBakeResult;

	private bool _disposed;

	public static bool EVAL_VERSION => false;

	public virtual MeshCombiningStatus bakeStatus => _bakeStatus;

	public virtual MB2_ValidationLevel validationLevel
	{
		get
		{
			return _validationLevel;
		}
		set
		{
			_validationLevel = value;
		}
	}

	public string name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public virtual MB2_TextureBakeResults textureBakeResults
	{
		get
		{
			return _textureBakeResults;
		}
		set
		{
			_textureBakeResults = value;
		}
	}

	public virtual GameObject resultSceneObject
	{
		get
		{
			return _resultSceneObject;
		}
		set
		{
			_resultSceneObject = value;
		}
	}

	public virtual Renderer targetRenderer
	{
		get
		{
			return _targetRenderer;
		}
		set
		{
			if (_targetRenderer != null && _targetRenderer != value)
			{
				UnityEngine.Debug.LogWarning("Previous targetRenderer was not null. Combined mesh may be shared by more than one Renderer");
			}
			_targetRenderer = value;
			if (value != null && MB_Utility.IsSceneInstance(value.gameObject) && value.transform.parent != null)
			{
				_resultSceneObject = value.transform.parent.gameObject;
			}
		}
	}

	public virtual MB2_LogLevel LOG_LEVEL
	{
		get
		{
			return _LOG_LEVEL;
		}
		set
		{
			_LOG_LEVEL = value;
		}
	}

	public MB_IMeshBakerSettings settings
	{
		get
		{
			if (_settingsHolder != null)
			{
				return settingsHolder.GetMeshBakerSettings();
			}
			return this;
		}
	}

	public virtual MB_IMeshBakerSettingsHolder settingsHolder
	{
		get
		{
			if (_settingsHolder != null)
			{
				if (_settingsHolder is MB_IMeshBakerSettingsHolder)
				{
					return (MB_IMeshBakerSettingsHolder)_settingsHolder;
				}
				_settingsHolder = null;
			}
			return null;
		}
		set
		{
			if (value is UnityEngine.Object)
			{
				_settingsHolder = (UnityEngine.Object)value;
			}
			else
			{
				UnityEngine.Debug.LogError("The settings holder must be a UnityEngine.Object");
			}
		}
	}

	public virtual MB2_OutputOptions outputOption
	{
		get
		{
			return _outputOption;
		}
		set
		{
			_outputOption = value;
		}
	}

	public virtual MB_RenderType renderType
	{
		get
		{
			return _renderType;
		}
		set
		{
			_renderType = value;
		}
	}

	public virtual MB2_LightmapOptions lightmapOption
	{
		get
		{
			return _lightmapOption;
		}
		set
		{
			_lightmapOption = value;
		}
	}

	public virtual bool doNorm
	{
		get
		{
			return _doNorm;
		}
		set
		{
			_doNorm = value;
		}
	}

	public virtual bool doTan
	{
		get
		{
			return _doTan;
		}
		set
		{
			_doTan = value;
		}
	}

	public virtual bool doCol
	{
		get
		{
			return _doCol;
		}
		set
		{
			_doCol = value;
		}
	}

	public virtual bool doUV
	{
		get
		{
			return _doUV;
		}
		set
		{
			_doUV = value;
		}
	}

	public virtual bool doUV1
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual bool doUV3
	{
		get
		{
			return _doUV3;
		}
		set
		{
			_doUV3 = value;
		}
	}

	public virtual bool doUV4
	{
		get
		{
			return _doUV4;
		}
		set
		{
			_doUV4 = value;
		}
	}

	public virtual bool doUV5
	{
		get
		{
			return _doUV5;
		}
		set
		{
			_doUV5 = value;
		}
	}

	public virtual bool doUV6
	{
		get
		{
			return _doUV6;
		}
		set
		{
			_doUV6 = value;
		}
	}

	public virtual bool doUV7
	{
		get
		{
			return _doUV7;
		}
		set
		{
			_doUV7 = value;
		}
	}

	public virtual bool doUV8
	{
		get
		{
			return _doUV8;
		}
		set
		{
			_doUV8 = value;
		}
	}

	public virtual bool doBlendShapes
	{
		get
		{
			return _doBlendShapes;
		}
		set
		{
			_doBlendShapes = value;
		}
	}

	public virtual MB_MeshPivotLocation pivotLocationType
	{
		get
		{
			return _pivotLocationType;
		}
		set
		{
			_pivotLocationType = value;
		}
	}

	public virtual Vector3 pivotLocation
	{
		get
		{
			return _pivotLocation;
		}
		set
		{
			_pivotLocation = value;
		}
	}

	public virtual bool clearBuffersAfterBake
	{
		get
		{
			return _clearBuffersAfterBake;
		}
		set
		{
			_clearBuffersAfterBake = value;
		}
	}

	public bool optimizeAfterBake
	{
		get
		{
			return _optimizeAfterBake;
		}
		set
		{
			_optimizeAfterBake = value;
		}
	}

	public float uv2UnwrappingParamsHardAngle
	{
		get
		{
			return _uv2UnwrappingParamsHardAngle;
		}
		set
		{
			_uv2UnwrappingParamsHardAngle = value;
		}
	}

	public float uv2UnwrappingParamsPackMargin
	{
		get
		{
			return _uv2UnwrappingParamsPackMargin;
		}
		set
		{
			_uv2UnwrappingParamsPackMargin = value;
		}
	}

	public bool smrNoExtraBonesWhenCombiningMeshRenderers
	{
		get
		{
			return _smrNoExtraBonesWhenCombiningMeshRenderers;
		}
		set
		{
			_smrNoExtraBonesWhenCombiningMeshRenderers = value;
		}
	}

	public bool smrMergeBlendShapesWithSameNames
	{
		get
		{
			return _smrMergeBlendShapesWithSameNames;
		}
		set
		{
			_smrMergeBlendShapesWithSameNames = value;
		}
	}

	public IAssignToMeshCustomizer assignToMeshCustomizer
	{
		get
		{
			if (_assignToMeshCustomizer is IAssignToMeshCustomizer)
			{
				return (IAssignToMeshCustomizer)_assignToMeshCustomizer;
			}
			_assignToMeshCustomizer = null;
			return null;
		}
		set
		{
			_assignToMeshCustomizer = (UnityEngine.Object)value;
		}
	}

	public MB_MeshCombineAPIType meshAPI
	{
		get
		{
			return _meshAPItoUse;
		}
		set
		{
			_meshAPItoUse = value;
		}
	}

	public virtual bool doUV2()
	{
		if (settings.lightmapOption != MB2_LightmapOptions.copy_UV2_unchanged && settings.lightmapOption != MB2_LightmapOptions.preserve_current_lightmapping)
		{
			return settings.lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects;
		}
		return true;
	}

	public virtual void DisposeRuntimeCreated()
	{
		Dispose();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	public bool IsDisposed()
	{
		return _disposed;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			_DisposeRuntimeCreated();
			_disposed = true;
		}
	}

	public abstract int GetLightmapIndex();

	public abstract void ClearBuffers();

	public abstract void ClearMesh();

	public abstract void ClearMesh(MB2_EditorMethodsInterface editorMethods);

	internal abstract void _DisposeRuntimeCreated();

	public abstract void DestroyMesh();

	public abstract void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods);

	public abstract List<GameObject> GetObjectsInCombined();

	public abstract int GetNumObjectsInCombined();

	public virtual bool Apply()
	{
		return Apply(null);
	}

	public abstract bool Apply(GenerateUV2Delegate uv2GenerationMethod);

	public abstract bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapeFlag = false, GenerateUV2Delegate uv2GenerationMethod = null);

	public abstract bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapeFlag = false, GenerateUV2Delegate uv2GenerationMethod = null);

	public virtual bool UpdateGameObjects(GameObject[] gos)
	{
		return UpdateGameObjects(gos, recalcBounds: true, updateVertices: true, updateNormals: true, updateTangents: true, updateUV: true, updateUV2: false, updateUV3: false, updateUV4: false, updateUV5: false, updateUV6: false, updateUV7: false, updateUV8: false, updateColors: false, updateSkinningInfo: false);
	}

	public virtual bool UpdateGameObjects(GameObject[] gos, bool updateBounds)
	{
		return UpdateGameObjects(gos, updateBounds, updateVertices: true, updateNormals: true, updateTangents: true, updateUV: true, updateUV2: false, updateUV3: false, updateUV4: false, updateUV5: false, updateUV6: false, updateUV7: false, updateUV8: false, updateColors: false, updateSkinningInfo: false);
	}

	public abstract bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo);

	public abstract bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo);

	public abstract bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true);

	public abstract bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource);

	public abstract bool CombinedMeshContains(GameObject go);

	public abstract void UpdateSkinnedMeshApproximateBounds();

	public abstract void UpdateSkinnedMeshApproximateBoundsFromBones();

	public abstract void CheckIntegrity();

	public abstract void UpdateSkinnedMeshApproximateBoundsFromBounds();

	public static void UpdateSkinnedMeshApproximateBoundsFromBonesStatic(Transform[] bs, SkinnedMeshRenderer smr)
	{
		Vector3 position = bs[0].position;
		Vector3 position2 = bs[0].position;
		for (int i = 1; i < bs.Length; i++)
		{
			Vector3 position3 = bs[i].position;
			if (position3.x < position2.x)
			{
				position2.x = position3.x;
			}
			if (position3.y < position2.y)
			{
				position2.y = position3.y;
			}
			if (position3.z < position2.z)
			{
				position2.z = position3.z;
			}
			if (position3.x > position.x)
			{
				position.x = position3.x;
			}
			if (position3.y > position.y)
			{
				position.y = position3.y;
			}
			if (position3.z > position.z)
			{
				position.z = position3.z;
			}
		}
		Vector3 vector = (position + position2) / 2f;
		Vector3 vector2 = position - position2;
		Matrix4x4 worldToLocalMatrix = smr.worldToLocalMatrix;
		Bounds localBounds = new Bounds(worldToLocalMatrix * vector, worldToLocalMatrix * vector2);
		smr.localBounds = localBounds;
	}

	public static void UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(List<GameObject> objectsInCombined, SkinnedMeshRenderer smr)
	{
		Bounds b = default(Bounds);
		Bounds bounds = default(Bounds);
		if (MB_Utility.GetBounds(objectsInCombined[0], out b))
		{
			bounds = b;
			for (int i = 1; i < objectsInCombined.Count; i++)
			{
				if (MB_Utility.GetBounds(objectsInCombined[i], out b))
				{
					bounds.Encapsulate(b);
					continue;
				}
				UnityEngine.Debug.LogError("Could not get bounds. Not updating skinned mesh bounds");
				return;
			}
			smr.localBounds = bounds;
		}
		else
		{
			UnityEngine.Debug.LogError("Could not get bounds. Not updating skinned mesh bounds");
		}
	}

	protected virtual bool _CreateTemporaryTextrueBakeResult(GameObject[] gos, List<Material> matsOnTargetRenderer)
	{
		if (GetNumObjectsInCombined() > 0)
		{
			UnityEngine.Debug.LogError("Can't add objects if there are already objects in combined mesh when 'Texture Bake Result' is not set. Perhaps enable 'Clear Buffers After Bake'");
			return false;
		}
		_usingTemporaryTextureBakeResult = true;
		_textureBakeResults = MB2_TextureBakeResults.CreateForMaterialsOnRenderer(gos, matsOnTargetRenderer);
		return true;
	}

	public abstract List<Material> GetMaterialsOnTargetRenderer();
}
public enum MB_MeshPivotLocation
{
	worldOrigin,
	boundsCenter,
	customLocation
}
[Serializable]
public class MB3_MeshCombinerSettingsData : MB_IMeshBakerSettings
{
	[SerializeField]
	protected MB_RenderType _renderType;

	[SerializeField]
	protected MB2_OutputOptions _outputOption;

	[SerializeField]
	protected MB2_LightmapOptions _lightmapOption = MB2_LightmapOptions.ignore_UV2;

	[SerializeField]
	protected bool _doNorm = true;

	[SerializeField]
	protected bool _doTan = true;

	[SerializeField]
	protected bool _doCol;

	[SerializeField]
	protected bool _doUV = true;

	[SerializeField]
	protected bool _doUV3;

	[SerializeField]
	protected bool _doUV4;

	[SerializeField]
	protected bool _doUV5;

	[SerializeField]
	protected bool _doUV6;

	[SerializeField]
	protected bool _doUV7;

	[SerializeField]
	protected bool _doUV8;

	[SerializeField]
	protected bool _doBlendShapes;

	[FormerlySerializedAs("_recenterVertsToBoundsCenter")]
	[SerializeField]
	protected MB_MeshPivotLocation _pivotLocationType;

	[SerializeField]
	protected Vector3 _pivotLocation;

	[SerializeField]
	protected bool _clearBuffersAfterBake;

	[SerializeField]
	public bool _optimizeAfterBake = true;

	[SerializeField]
	protected float _uv2UnwrappingParamsHardAngle = 60f;

	[SerializeField]
	protected float _uv2UnwrappingParamsPackMargin = 0.005f;

	[SerializeField]
	protected bool _smrNoExtraBonesWhenCombiningMeshRenderers;

	[SerializeField]
	protected bool _smrMergeBlendShapesWithSameNames;

	[SerializeField]
	protected UnityEngine.Object _assignToMeshCustomizer;

	[SerializeField]
	protected MB_MeshCombineAPIType _meshAPItoUse = MB_MeshCombineAPIType.betaNativeArrayAPI;

	public virtual MB_RenderType renderType
	{
		get
		{
			return _renderType;
		}
		set
		{
			_renderType = value;
		}
	}

	public virtual MB2_OutputOptions outputOption
	{
		get
		{
			return _outputOption;
		}
		set
		{
			_outputOption = value;
		}
	}

	public virtual MB2_LightmapOptions lightmapOption
	{
		get
		{
			return _lightmapOption;
		}
		set
		{
			_lightmapOption = value;
		}
	}

	public virtual bool doNorm
	{
		get
		{
			return _doNorm;
		}
		set
		{
			_doNorm = value;
		}
	}

	public virtual bool doTan
	{
		get
		{
			return _doTan;
		}
		set
		{
			_doTan = value;
		}
	}

	public virtual bool doCol
	{
		get
		{
			return _doCol;
		}
		set
		{
			_doCol = value;
		}
	}

	public virtual bool doUV
	{
		get
		{
			return _doUV;
		}
		set
		{
			_doUV = value;
		}
	}

	public virtual bool doUV3
	{
		get
		{
			return _doUV3;
		}
		set
		{
			_doUV3 = value;
		}
	}

	public virtual bool doUV4
	{
		get
		{
			return _doUV4;
		}
		set
		{
			_doUV4 = value;
		}
	}

	public virtual bool doUV5
	{
		get
		{
			return _doUV5;
		}
		set
		{
			_doUV5 = value;
		}
	}

	public virtual bool doUV6
	{
		get
		{
			return _doUV6;
		}
		set
		{
			_doUV6 = value;
		}
	}

	public virtual bool doUV7
	{
		get
		{
			return _doUV7;
		}
		set
		{
			_doUV7 = value;
		}
	}

	public virtual bool doUV8
	{
		get
		{
			return _doUV8;
		}
		set
		{
			_doUV8 = value;
		}
	}

	public virtual bool doBlendShapes
	{
		get
		{
			return _doBlendShapes;
		}
		set
		{
			_doBlendShapes = value;
		}
	}

	public virtual MB_MeshPivotLocation pivotLocationType
	{
		get
		{
			return _pivotLocationType;
		}
		set
		{
			_pivotLocationType = value;
		}
	}

	public virtual Vector3 pivotLocation
	{
		get
		{
			return _pivotLocation;
		}
		set
		{
			_pivotLocation = value;
		}
	}

	public bool clearBuffersAfterBake
	{
		get
		{
			return _clearBuffersAfterBake;
		}
		set
		{
			_clearBuffersAfterBake = value;
		}
	}

	public bool optimizeAfterBake
	{
		get
		{
			return _optimizeAfterBake;
		}
		set
		{
			_optimizeAfterBake = value;
		}
	}

	public float uv2UnwrappingParamsHardAngle
	{
		get
		{
			return _uv2UnwrappingParamsHardAngle;
		}
		set
		{
			_uv2UnwrappingParamsHardAngle = value;
		}
	}

	public float uv2UnwrappingParamsPackMargin
	{
		get
		{
			return _uv2UnwrappingParamsPackMargin;
		}
		set
		{
			_uv2UnwrappingParamsPackMargin = value;
		}
	}

	public bool smrNoExtraBonesWhenCombiningMeshRenderers
	{
		get
		{
			return _smrNoExtraBonesWhenCombiningMeshRenderers;
		}
		set
		{
			_smrNoExtraBonesWhenCombiningMeshRenderers = value;
		}
	}

	public bool smrMergeBlendShapesWithSameNames
	{
		get
		{
			return _smrMergeBlendShapesWithSameNames;
		}
		set
		{
			_smrMergeBlendShapesWithSameNames = value;
		}
	}

	public IAssignToMeshCustomizer assignToMeshCustomizer
	{
		get
		{
			if (_assignToMeshCustomizer is IAssignToMeshCustomizer)
			{
				return (IAssignToMeshCustomizer)_assignToMeshCustomizer;
			}
			_assignToMeshCustomizer = null;
			return null;
		}
		set
		{
			_assignToMeshCustomizer = (UnityEngine.Object)value;
		}
	}

	public MB_MeshCombineAPIType meshAPI
	{
		get
		{
			return _meshAPItoUse;
		}
		set
		{
			_meshAPItoUse = value;
		}
	}
}
[CreateAssetMenu(fileName = "MeshBakerSettings", menuName = "Mesh Baker/Mesh Baker Settings")]
public class MB3_MeshCombinerSettings : ScriptableObject, MB_IMeshBakerSettingsHolder
{
	public MB3_MeshCombinerSettingsData data;

	public MB_IMeshBakerSettings GetMeshBakerSettings()
	{
		return data;
	}

	public void GetMeshBakerSettingsAsSerializedProperty(out string propertyName, out UnityEngine.Object targetObj)
	{
		targetObj = this;
		propertyName = "data";
	}
}
[Serializable]
public class MB3_MeshCombinerSingle : MB3_MeshCombiner
{
	internal class MB_MeshCombinerSingle_BlendShapeProcessor
	{
		private MB3_MeshCombinerSingle combiner;

		private MBBlendShape[] nblendShapes;

		private bool _disposed;

		protected void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					combiner = null;
					nblendShapes = null;
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public MB_MeshCombinerSingle_BlendShapeProcessor(MB3_MeshCombinerSingle cm)
		{
			combiner = cm;
		}

		public static MBBlendShape[] GetBlendShapes(Mesh m, GameObject gameObject, Dictionary<int, MeshChannels> meshID2MeshChannels)
		{
			if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
			{
				value = new MeshChannels();
				meshID2MeshChannels.Add(m.GetInstanceID(), value);
			}
			if (value.blendShapes == null)
			{
				MBBlendShape[] array = new MBBlendShape[m.blendShapeCount];
				int vertexCount = m.vertexCount;
				for (int i = 0; i < array.Length; i++)
				{
					MBBlendShape mBBlendShape = (array[i] = new MBBlendShape());
					mBBlendShape.frames = new MBBlendShapeFrame[MBVersion.GetBlendShapeFrameCount(m, i)];
					mBBlendShape.name = m.GetBlendShapeName(i);
					mBBlendShape.indexInSource = i;
					mBBlendShape.gameObject = gameObject;
					for (int j = 0; j < mBBlendShape.frames.Length; j++)
					{
						MBBlendShapeFrame mBBlendShapeFrame = (mBBlendShape.frames[j] = new MBBlendShapeFrame());
						mBBlendShapeFrame.frameWeight = MBVersion.GetBlendShapeFrameWeight(m, i, j);
						mBBlendShapeFrame.vertices = new Vector3[vertexCount];
						mBBlendShapeFrame.normals = new Vector3[vertexCount];
						mBBlendShapeFrame.tangents = new Vector3[vertexCount];
						MBVersion.GetBlendShapeFrameVertices(m, i, j, mBBlendShapeFrame.vertices, mBBlendShapeFrame.normals, mBBlendShapeFrame.tangents);
					}
				}
				value.blendShapes = array;
				return value.blendShapes;
			}
			MBBlendShape[] array2 = new MBBlendShape[value.blendShapes.Length];
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = new MBBlendShape();
				array2[k].name = value.blendShapes[k].name;
				array2[k].indexInSource = value.blendShapes[k].indexInSource;
				array2[k].frames = value.blendShapes[k].frames;
				array2[k].gameObject = gameObject;
			}
			return array2;
		}

		internal void ApplyBlendShapeFramesToMeshAndBuildMap(int newVertCount)
		{
			Renderer targetRenderer = combiner._targetRenderer;
			Mesh mesh = combiner._mesh;
			if (combiner.blendShapes.Length != nblendShapes.Length)
			{
				combiner.blendShapes = new MBBlendShape[nblendShapes.Length];
			}
			Vector3[] array = new Vector3[newVertCount];
			Vector3[] array2 = new Vector3[newVertCount];
			Vector3[] array3 = new Vector3[newVertCount];
			((SkinnedMeshRenderer)targetRenderer).sharedMesh = null;
			MBVersion.ClearBlendShapes(mesh);
			for (int i = 0; i < nblendShapes.Length; i++)
			{
				MBBlendShape mBBlendShape = nblendShapes[i];
				MB_DynamicGameObject mB_DynamicGameObject = combiner.instance2Combined_MapGet(mBBlendShape.gameObject);
				if (mB_DynamicGameObject != null)
				{
					int vertIdx = mB_DynamicGameObject.vertIdx;
					for (int j = 0; j < mBBlendShape.frames.Length; j++)
					{
						MBBlendShapeFrame mBBlendShapeFrame = mBBlendShape.frames[j];
						Array.Copy(mBBlendShapeFrame.vertices, 0, array, vertIdx, mBBlendShapeFrame.vertices.Length);
						Array.Copy(mBBlendShapeFrame.normals, 0, array2, vertIdx, mBBlendShapeFrame.normals.Length);
						Array.Copy(mBBlendShapeFrame.tangents, 0, array3, vertIdx, mBBlendShapeFrame.tangents.Length);
						MBVersion.AddBlendShapeFrame(mesh, _ConvertBlendShapeNameToOutputName(mBBlendShape.name) + mBBlendShape.gameObject.GetInstanceID(), mBBlendShapeFrame.frameWeight, array, array2, array3);
						_ZeroArray(array, vertIdx, mBBlendShapeFrame.vertices.Length);
						_ZeroArray(array2, vertIdx, mBBlendShapeFrame.normals.Length);
						_ZeroArray(array3, vertIdx, mBBlendShapeFrame.tangents.Length);
					}
				}
				else
				{
					UnityEngine.Debug.LogError("InstanceID in blend shape that was not in instance2combinedMap");
				}
				combiner.blendShapes[i] = mBBlendShape;
			}
			((SkinnedMeshRenderer)targetRenderer).sharedMesh = null;
			((SkinnedMeshRenderer)targetRenderer).sharedMesh = mesh;
			if (combiner.settings.doBlendShapes)
			{
				MB_BlendShape2CombinedMap mB_BlendShape2CombinedMap = targetRenderer.GetComponent<MB_BlendShape2CombinedMap>();
				if (mB_BlendShape2CombinedMap == null)
				{
					mB_BlendShape2CombinedMap = targetRenderer.gameObject.AddComponent<MB_BlendShape2CombinedMap>();
				}
				SerializableSourceBlendShape2Combined map = mB_BlendShape2CombinedMap.GetMap();
				_BuildSrcShape2CombinedMap(combiner, map, nblendShapes);
			}
		}

		public void AllocateBlendShapeArrayIfNecessary(int nBlendShapeSize)
		{
			if (combiner.settings.doBlendShapes)
			{
				nblendShapes = new MBBlendShape[nBlendShapeSize];
			}
		}

		public void AssignNewBlendShapesToCombinerIfNecessary()
		{
			if (combiner.settings.doBlendShapes)
			{
				combiner.blendShapes = nblendShapes;
			}
		}

		public void CopyBlendShapesInCurrentMeshIfNecessary(ref int targBlendShapeIdx, MB_DynamicGameObject dgo)
		{
			if (combiner.settings.doBlendShapes)
			{
				Array.Copy(combiner.blendShapes, dgo.blendShapeIdx, nblendShapes, targBlendShapeIdx, dgo.numBlendShapes);
				dgo.blendShapeIdx = targBlendShapeIdx;
				targBlendShapeIdx += dgo.numBlendShapes;
			}
		}

		public void CopyBlendShapesForNewMeshIfNecessary(ref int targBlendShapeIdx, MB_DynamicGameObject dgo, Mesh mesh, IMeshChannelsCacheTaggingInterface meshChannelCache)
		{
			if (combiner.settings.doBlendShapes)
			{
				int index = targBlendShapeIdx;
				MBBlendShape[] blendShapes = meshChannelCache.GetBlendShapes(mesh, dgo.gameObject.GetInstanceID(), dgo.gameObject);
				blendShapes.CopyTo(nblendShapes, index);
				dgo.blendShapeIdx = targBlendShapeIdx;
				targBlendShapeIdx += blendShapes.Length;
			}
		}

		private static string _ConvertBlendShapeNameToOutputName(string bs)
		{
			return bs.Split('.')[^1];
		}

		internal void ApplyBlendShapeFramesToMeshAndBuildMap_MergeBlendShapesWithTheSameName(int newVertCount)
		{
			Renderer targetRenderer = combiner._targetRenderer;
			Mesh mesh = combiner._mesh;
			Vector3[] array = new Vector3[newVertCount];
			Vector3[] array2 = new Vector3[newVertCount];
			Vector3[] array3 = new Vector3[newVertCount];
			MBVersion.ClearBlendShapes(mesh);
			bool flag = false;
			Dictionary<string, List<MBBlendShape>> dictionary = new Dictionary<string, List<MBBlendShape>>();
			for (int i = 0; i < nblendShapes.Length; i++)
			{
				MBBlendShape mBBlendShape = nblendShapes[i];
				string key = _ConvertBlendShapeNameToOutputName(mBBlendShape.name);
				if (!dictionary.TryGetValue(key, out var value))
				{
					value = new List<MBBlendShape>();
					dictionary.Add(key, value);
				}
				value.Add(mBBlendShape);
				if (value.Count > 1 && value[0].frames.Length != mBBlendShape.frames.Length)
				{
					UnityEngine.Debug.LogError("BlendShapes with the same name must have the same number of frames.");
					flag = true;
				}
			}
			if (flag)
			{
				return;
			}
			if (combiner.blendShapes.Length != nblendShapes.Length)
			{
				combiner.blendShapes = new MBBlendShape[dictionary.Keys.Count];
			}
			int num = 0;
			foreach (string key2 in dictionary.Keys)
			{
				List<MBBlendShape> list = dictionary[key2];
				MBBlendShape mBBlendShape2 = list[0];
				int num2 = mBBlendShape2.frames.Length;
				int num3 = 0;
				int num4 = 0;
				string text = "";
				for (int j = 0; j < num2; j++)
				{
					float frameWeight = mBBlendShape2.frames[j].frameWeight;
					for (int k = 0; k < list.Count; k++)
					{
						MBBlendShape mBBlendShape3 = list[k];
						int vertIdx = combiner.instance2Combined_MapGet(mBBlendShape3.gameObject).vertIdx;
						MBBlendShapeFrame mBBlendShapeFrame = mBBlendShape3.frames[j];
						Array.Copy(mBBlendShapeFrame.vertices, 0, array, vertIdx, mBBlendShapeFrame.vertices.Length);
						Array.Copy(mBBlendShapeFrame.normals, 0, array2, vertIdx, mBBlendShapeFrame.normals.Length);
						Array.Copy(mBBlendShapeFrame.tangents, 0, array3, vertIdx, mBBlendShapeFrame.tangents.Length);
						if (j == 0)
						{
							num3 += mBBlendShapeFrame.vertices.Length;
							text = text + mBBlendShape3.gameObject.name + " " + vertIdx + ":" + (vertIdx + mBBlendShapeFrame.vertices.Length) + ", ";
						}
					}
					num4 += list.Count;
					MBVersion.AddBlendShapeFrame(mesh, key2, frameWeight, array, array2, array3);
					_ZeroArray(array, 0, array.Length);
					_ZeroArray(array2, 0, array2.Length);
					_ZeroArray(array3, 0, array3.Length);
				}
				combiner.blendShapes[num] = mBBlendShape2;
				num++;
			}
			((SkinnedMeshRenderer)targetRenderer).sharedMesh = null;
			((SkinnedMeshRenderer)targetRenderer).sharedMesh = mesh;
			if (combiner.settings.doBlendShapes)
			{
				MB_BlendShape2CombinedMap mB_BlendShape2CombinedMap = targetRenderer.GetComponent<MB_BlendShape2CombinedMap>();
				if (mB_BlendShape2CombinedMap == null)
				{
					mB_BlendShape2CombinedMap = targetRenderer.gameObject.AddComponent<MB_BlendShape2CombinedMap>();
				}
				SerializableSourceBlendShape2Combined map = mB_BlendShape2CombinedMap.GetMap();
				_BuildSrcShape2CombinedMap(combiner, map, combiner.blendShapes);
			}
		}

		private static void _BuildSrcShape2CombinedMap(MB3_MeshCombinerSingle combiner, SerializableSourceBlendShape2Combined map, MBBlendShape[] bs)
		{
			MBBlendShape[] blendShapes = combiner.blendShapes;
			Renderer targetRenderer = combiner._targetRenderer;
			if (combiner._mesh != null && combiner._mesh.blendShapeCount != combiner.blendShapes.Length)
			{
				UnityEngine.Debug.LogError("Blend shapes in combiner did not match blend shapes in mesh. Map will probably be invalid.");
			}
			GameObject[] array = new GameObject[bs.Length];
			int[] array2 = new int[bs.Length];
			GameObject[] array3 = new GameObject[bs.Length];
			int[] array4 = new int[bs.Length];
			for (int i = 0; i < blendShapes.Length; i++)
			{
				array[i] = blendShapes[i].gameObject;
				array2[i] = blendShapes[i].indexInSource;
				array3[i] = targetRenderer.gameObject;
				array4[i] = i;
			}
			map.SetBuffers(array, array2, array3, array4);
		}

		private static void _ZeroArray(Vector3[] arr, int idx, int length)
		{
			int num = idx + length;
			for (int i = idx; i < num; i++)
			{
				arr[i] = Vector3.zero;
			}
		}
	}

	public class MB_MeshCombinerSingle_BoneProcessor : MB_IMeshCombinerSingle_BoneProcessor, IDisposable
	{
		private MB3_MeshCombinerSingle combiner;

		private List<MB_DynamicGameObject>[] boneIdx2dgoMap;

		private HashSet<int> boneIdxsToDelete = new HashSet<int>();

		private HashSet<BoneAndBindpose> bonesToAdd = new HashSet<BoneAndBindpose>();

		private Dictionary<BoneAndBindpose, int> boneAndBindPose2idx = new Dictionary<BoneAndBindpose, int>();

		private Transform[] oldBonesPreviousBake;

		private Matrix4x4[] oldBindPosesPreviousBake;

		private Transform[] nbones;

		private Matrix4x4[] nbindPoses;

		private BoneWeight[] nboneWeights;

		private BoneWeight[] boneWeights = new BoneWeight[0];

		private int _newBonesStartAtIdx;

		private bool _disposed;

		private bool _didSetup;

		protected void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					combiner = null;
					boneIdx2dgoMap = null;
					boneIdxsToDelete = null;
					bonesToAdd = null;
					boneAndBindPose2idx = null;
					boneWeights = null;
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public int GetNewBonesSize()
		{
			if (nbones != null)
			{
				return nbones.Length;
			}
			return 0;
		}

		public MB_MeshCombinerSingle_BoneProcessor(MB3_MeshCombinerSingle cm)
		{
			combiner = cm;
			oldBonesPreviousBake = combiner.bones;
			oldBindPosesPreviousBake = combiner.bindPoses;
		}

		public HashSet<BoneAndBindpose> GetBonesToAdd()
		{
			return bonesToAdd;
		}

		public int GetNumBonesToDelete()
		{
			return boneIdxsToDelete.Count;
		}

		public void BuildBoneIdx2DGOMapIfNecessary(int[] _goToDelete)
		{
			_didSetup = false;
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				if (_goToDelete != null && _goToDelete.Length != 0)
				{
					boneIdx2dgoMap = _buildBoneIdx2dgoMap();
				}
				for (int i = 0; i < oldBonesPreviousBake.Length; i++)
				{
					BoneAndBindpose key = new BoneAndBindpose(oldBonesPreviousBake[i], oldBindPosesPreviousBake[i]);
					boneAndBindPose2idx.Add(key, i);
				}
				_didSetup = true;
			}
		}

		public void RemoveBonesForDgosWeAreDeleting(MB_DynamicGameObject dgo)
		{
			for (int i = 0; i < dgo.indexesOfBonesUsed.Length; i++)
			{
				int num = dgo.indexesOfBonesUsed[i];
				List<MB_DynamicGameObject> list = boneIdx2dgoMap[num];
				if (list.Contains(dgo))
				{
					list.Remove(dgo);
					if (list.Count == 0)
					{
						boneIdxsToDelete.Add(num);
					}
				}
			}
		}

		public void AllocateAndSetupSMRDataStructures(List<MB_DynamicGameObject> toAddDGOs, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, int newVertSize, IVertexAndTriangleProcessor vertexAndTriangleProcessor)
		{
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				_CollectSkinningDataForDGOsInCombinedMesh(toAddDGOs);
				int newBonesLength = GetNewBonesLength();
				nbones = new Transform[newBonesLength];
				nbindPoses = new Matrix4x4[newBonesLength];
				nboneWeights = new BoneWeight[newVertSize];
				_newBonesStartAtIdx = oldBindPosesPreviousBake.Length - GetNumBonesToDelete();
				boneWeights = combiner._mesh.boneWeights;
			}
		}

		public void UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh()
		{
			if (combiner.settings.renderType != MB_RenderType.skinnedMeshRenderer)
			{
				return;
			}
			boneWeights = combiner._mesh.boneWeights;
			if (combiner.mbDynamicObjectsInCombinedMesh.Count <= 0 || combiner.mbDynamicObjectsInCombinedMesh[0].indexesOfBonesUsed.Length != 0 || combiner.settings.renderType != MB_RenderType.skinnedMeshRenderer || boneWeights == null || boneWeights.Length == 0)
			{
				return;
			}
			for (int i = 0; i < combiner.mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[i];
				HashSet<int> hashSet = new HashSet<int>();
				for (int j = mB_DynamicGameObject.vertIdx; j < mB_DynamicGameObject.vertIdx + mB_DynamicGameObject.numVerts; j++)
				{
					if (boneWeights[j].weight0 > 0f)
					{
						hashSet.Add(boneWeights[j].boneIndex0);
					}
					if (boneWeights[j].weight1 > 0f)
					{
						hashSet.Add(boneWeights[j].boneIndex1);
					}
					if (boneWeights[j].weight2 > 0f)
					{
						hashSet.Add(boneWeights[j].boneIndex2);
					}
					if (boneWeights[j].weight3 > 0f)
					{
						hashSet.Add(boneWeights[j].boneIndex3);
					}
				}
				mB_DynamicGameObject.indexesOfBonesUsed = new int[hashSet.Count];
				hashSet.CopyTo(mB_DynamicGameObject.indexesOfBonesUsed);
			}
			if (combiner.LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Baker used old systems that duplicated bones. Upgrading to new system by building indexesOfBonesUsed");
			}
		}

		public int GetNewBonesLength()
		{
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				return oldBindPosesPreviousBake.Length + bonesToAdd.Count - boneIdxsToDelete.Count;
			}
			return 0;
		}

		internal void _CollectSkinningDataForDGOsInCombinedMesh(List<MB_DynamicGameObject> objsToAdd)
		{
			for (int i = 0; i < objsToAdd.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = objsToAdd[i];
				CollectBonesToAddForDGO(mB_DynamicGameObject, MB_Utility.GetRenderer(mB_DynamicGameObject.gameObject), combiner.settings.smrNoExtraBonesWhenCombiningMeshRenderers);
			}
		}

		public bool CollectBonesToAddForDGO(MB_DynamicGameObject dgo, Renderer r, bool noExtraBonesForMeshRenderers)
		{
			bool flag = true;
			MeshChannelsCache meshChannelsCache = (MeshChannelsCache)combiner._meshChannelsCache;
			List<Matrix4x4> list = (dgo._tmpSMR_CachedBindposes = meshChannelsCache.GetBindposes(r, out dgo.isSkinnedMeshWithBones));
			dgo._tmpSMR_CachedBoneWeights = meshChannelsCache.GetBoneWeights(r, dgo.numVerts, dgo.isSkinnedMeshWithBones);
			Transform[] array = (dgo._tmpSMR_CachedBones = combiner._getBones(r, dgo.isSkinnedMeshWithBones));
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					UnityEngine.Debug.LogError("Source mesh r had a 'null' bone. Bones must not be null: " + r);
					flag = false;
				}
			}
			if (!flag)
			{
				return flag;
			}
			if (noExtraBonesForMeshRenderers && MB_Utility.GetRenderer(dgo.gameObject) is MeshRenderer)
			{
				bool flag2 = false;
				BoneAndBindpose boneAndBindpose = default(BoneAndBindpose);
				Transform parent = dgo.gameObject.transform.parent;
				while (parent != null)
				{
					foreach (BoneAndBindpose key in boneAndBindPose2idx.Keys)
					{
						if (key.bone == parent)
						{
							boneAndBindpose = key;
							flag2 = true;
							break;
						}
					}
					foreach (BoneAndBindpose item in bonesToAdd)
					{
						if (item.bone == parent)
						{
							boneAndBindpose = item;
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						break;
					}
					parent = parent.parent;
				}
				if (flag2)
				{
					array[0] = boneAndBindpose.bone;
					list[0] = boneAndBindpose.bindPose;
				}
			}
			int[] array2 = new int[array.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = j;
			}
			for (int k = 0; k < array.Length; k++)
			{
				bool flag3 = false;
				int num = array2[k];
				BoneAndBindpose boneAndBindpose2 = new BoneAndBindpose(array[num], list[num]);
				if (boneAndBindPose2idx.TryGetValue(boneAndBindpose2, out var value) && array[num] == oldBonesPreviousBake[value] && !boneIdxsToDelete.Contains(value) && list[num] == oldBindPosesPreviousBake[value])
				{
					flag3 = true;
				}
				if (!flag3 && !bonesToAdd.Contains(boneAndBindpose2))
				{
					bonesToAdd.Add(boneAndBindpose2);
				}
			}
			dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx = array2;
			return flag;
		}

		private List<MB_DynamicGameObject>[] _buildBoneIdx2dgoMap()
		{
			List<MB_DynamicGameObject>[] array = new List<MB_DynamicGameObject>[oldBonesPreviousBake.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new List<MB_DynamicGameObject>();
			}
			for (int j = 0; j < combiner.mbDynamicObjectsInCombinedMesh.Count; j++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[j];
				for (int k = 0; k < mB_DynamicGameObject.indexesOfBonesUsed.Length; k++)
				{
					array[mB_DynamicGameObject.indexesOfBonesUsed[k]].Add(mB_DynamicGameObject);
				}
			}
			return array;
		}

		public void CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(int totalDeleteVerts)
		{
			if (boneIdxsToDelete.Count > 0)
			{
				int[] array = new int[boneIdxsToDelete.Count];
				boneIdxsToDelete.CopyTo(array);
				Array.Sort(array);
				int[] array2 = new int[oldBonesPreviousBake.Length];
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < oldBonesPreviousBake.Length; i++)
				{
					if (num2 < array.Length && array[num2] == i)
					{
						num2++;
						array2[i] = -1;
						continue;
					}
					array2[i] = num;
					nbones[num] = oldBonesPreviousBake[i];
					nbindPoses[num] = oldBindPosesPreviousBake[i];
					num++;
				}
				int num3 = boneWeights.Length - totalDeleteVerts;
				for (int j = 0; j < num3; j++)
				{
					BoneWeight boneWeight = nboneWeights[j];
					boneWeight.boneIndex0 = array2[boneWeight.boneIndex0];
					boneWeight.boneIndex1 = array2[boneWeight.boneIndex1];
					boneWeight.boneIndex2 = array2[boneWeight.boneIndex2];
					boneWeight.boneIndex3 = array2[boneWeight.boneIndex3];
					nboneWeights[j] = boneWeight;
				}
				for (int k = 0; k < combiner.mbDynamicObjectsInCombinedMesh.Count; k++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[k];
					for (int l = 0; l < mB_DynamicGameObject.indexesOfBonesUsed.Length; l++)
					{
						mB_DynamicGameObject.indexesOfBonesUsed[l] = array2[mB_DynamicGameObject.indexesOfBonesUsed[l]];
					}
				}
			}
			else
			{
				Array.Copy(oldBonesPreviousBake, nbones, oldBonesPreviousBake.Length);
				Array.Copy(oldBindPosesPreviousBake, nbindPoses, oldBindPosesPreviousBake.Length);
			}
		}

		public void InsertNewBonesIntoBonesArray()
		{
			if (combiner.settings.renderType != MB_RenderType.skinnedMeshRenderer)
			{
				return;
			}
			boneWeights = nboneWeights;
			combiner.bindPoses = nbindPoses;
			combiner.bones = nbones;
			int num = 0;
			foreach (BoneAndBindpose item in GetBonesToAdd())
			{
				int num2 = _newBonesStartAtIdx + num;
				nbones[num2] = item.bone;
				nbindPoses[num2] = item.bindPose;
				num++;
			}
		}

		public void AddBonesToNewBonesArrayAndAdjustBWIndexes1(MB_DynamicGameObject dgo, int vertsIdx)
		{
			Transform[] tmpSMR_CachedBones = dgo._tmpSMR_CachedBones;
			List<Matrix4x4> tmpSMR_CachedBindposes = dgo._tmpSMR_CachedBindposes;
			BoneWeight[] tmpSMR_CachedBoneWeights = dgo._tmpSMR_CachedBoneWeights;
			int[] array = new int[tmpSMR_CachedBones.Length];
			for (int i = 0; i < dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx.Length; i++)
			{
				for (int j = 0; j < nbones.Length; j++)
				{
					if (tmpSMR_CachedBones[i] == nbones[j] && tmpSMR_CachedBindposes[i] == nbindPoses[j])
					{
						array[i] = j;
						break;
					}
				}
			}
			for (int k = 0; k < tmpSMR_CachedBoneWeights.Length; k++)
			{
				int num = vertsIdx + k;
				nboneWeights[num].boneIndex0 = array[tmpSMR_CachedBoneWeights[k].boneIndex0];
				nboneWeights[num].boneIndex1 = array[tmpSMR_CachedBoneWeights[k].boneIndex1];
				nboneWeights[num].boneIndex2 = array[tmpSMR_CachedBoneWeights[k].boneIndex2];
				nboneWeights[num].boneIndex3 = array[tmpSMR_CachedBoneWeights[k].boneIndex3];
				nboneWeights[num].weight0 = tmpSMR_CachedBoneWeights[k].weight0;
				nboneWeights[num].weight1 = tmpSMR_CachedBoneWeights[k].weight1;
				nboneWeights[num].weight2 = tmpSMR_CachedBoneWeights[k].weight2;
				nboneWeights[num].weight3 = tmpSMR_CachedBoneWeights[k].weight3;
			}
			for (int l = 0; l < dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx.Length; l++)
			{
				dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx[l] = array[dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx[l]];
			}
			dgo.indexesOfBonesUsed = dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx;
			dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx = null;
			dgo._tmpSMR_CachedBones = null;
			dgo._tmpSMR_CachedBindposes = null;
			dgo._tmpSMR_CachedBoneWeights = null;
		}

		public void UpdateGameObjects_UpdateBWIndexes(MB_DynamicGameObject dgo)
		{
			Transform[] bones = MBVersion.GetBones(dgo._renderer, dgo.isSkinnedMeshWithBones);
			BoneWeight[] array = ((MeshChannelsCache)combiner._meshChannelsCache).GetBoneWeights(dgo._renderer, dgo.numVerts, dgo.isSkinnedMeshWithBones);
			int num = dgo.vertIdx;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (bones[array[i].boneIndex0] != oldBonesPreviousBake[boneWeights[num].boneIndex0])
				{
					flag = true;
					break;
				}
				boneWeights[num].weight0 = array[i].weight0;
				boneWeights[num].weight1 = array[i].weight1;
				boneWeights[num].weight2 = array[i].weight2;
				boneWeights[num].weight3 = array[i].weight3;
				num++;
			}
			if (flag)
			{
				UnityEngine.Debug.LogError("Detected that some of the boneweights reference different bones than when initial added. Boneweights must reference the same bones " + dgo.name);
			}
		}

		public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, NativeSlice<Vector3> nnorms, NativeSlice<Vector4> ntangs, NativeSlice<Vector3> nverts, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents, NativeSlice<Vector3> verts)
		{
			UnityEngine.Debug.LogError("The simple bone processor doesn't use this.");
		}

		public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, Vector3[] nnorms, Vector4[] ntangs, Vector3[] nverts, Vector3[] normals, Vector4[] tangents, Vector3[] verts)
		{
			bool flag = dgo._renderer is MeshRenderer;
			if (settings.smrNoExtraBonesWhenCombiningMeshRenderers && flag && dgo._tmpSMR_CachedBones[0] != dgo.gameObject.transform)
			{
				Matrix4x4 matrix4x = dgo._tmpSMR_CachedBindposes[0].inverse * dgo._tmpSMR_CachedBones[0].worldToLocalMatrix * dgo.gameObject.transform.localToWorldMatrix;
				Matrix4x4 matrix4x2 = matrix4x;
				float num = (matrix4x2[2, 3] = 0f);
				float value = (matrix4x2[1, 3] = num);
				matrix4x2[0, 3] = value;
				matrix4x2 = matrix4x2.inverse.transpose;
				for (int i = 0; i < dgo._mesh.vertexCount; i++)
				{
					int num4 = vertsIdx + i;
					if (verts != null)
					{
						verts[vertsIdx + i] = matrix4x.MultiplyPoint3x4(nverts[i]);
					}
					if (settings.doNorm && nnorms != null)
					{
						normals[num4] = matrix4x2.MultiplyPoint3x4(nnorms[i]).normalized;
					}
					if (settings.doTan && ntangs != null)
					{
						float w = ntangs[i].w;
						tangents[num4] = matrix4x2.MultiplyPoint3x4(ntangs[i]).normalized;
						tangents[num4].w = w;
					}
				}
			}
			else
			{
				if (settings.doNorm)
				{
					nnorms?.CopyTo(normals, vertsIdx);
				}
				if (settings.doTan)
				{
					ntangs?.CopyTo(tangents, vertsIdx);
				}
				if (verts != null)
				{
					nverts.CopyTo(verts, vertsIdx);
				}
			}
		}

		public void DisposeOfTemporarySMRData()
		{
			if (boneIdxsToDelete != null)
			{
				boneIdxsToDelete.Clear();
			}
			if (boneAndBindPose2idx != null)
			{
				boneAndBindPose2idx.Clear();
			}
			boneIdxsToDelete = null;
			boneAndBindPose2idx = null;
			boneIdx2dgoMap = null;
		}

		public void CopyBoneWeightsFromMeshForDGOsInCombined(MB_DynamicGameObject dgo, int targVidx)
		{
			Array.Copy(boneWeights, dgo.vertIdx, nboneWeights, targVidx, dgo.numVerts);
		}

		public void ApplySMRdataToMeshToBuffer()
		{
		}

		public void ApplySMRdataToMesh(MB3_MeshCombinerSingle combiner, Mesh mesh)
		{
			mesh.bindposes = combiner.bindPoses;
			mesh.boneWeights = boneWeights;
		}

		public bool GetCachedSMRMeshData(MB_DynamicGameObject dgo)
		{
			return true;
		}

		public bool DB_CheckIntegrity()
		{
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				for (int i = 0; i < combiner.mbDynamicObjectsInCombinedMesh.Count; i++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[i];
					HashSet<int> hashSet = new HashSet<int>();
					HashSet<int> hashSet2 = new HashSet<int>();
					for (int j = mB_DynamicGameObject.vertIdx; j < mB_DynamicGameObject.vertIdx + mB_DynamicGameObject.numVerts; j++)
					{
						hashSet.Add(boneWeights[j].boneIndex0);
						hashSet.Add(boneWeights[j].boneIndex1);
						hashSet.Add(boneWeights[j].boneIndex2);
						hashSet.Add(boneWeights[j].boneIndex3);
					}
					for (int k = 0; k < mB_DynamicGameObject.indexesOfBonesUsed.Length; k++)
					{
						hashSet2.Add(mB_DynamicGameObject.indexesOfBonesUsed[k]);
					}
					hashSet2.ExceptWith(hashSet);
					if (hashSet2.Count > 0)
					{
						UnityEngine.Debug.LogError("The bone indexes were not the same. " + hashSet.Count + " " + hashSet2.Count);
					}
					for (int l = 0; l < mB_DynamicGameObject.indexesOfBonesUsed.Length; l++)
					{
						if (l < 0 || l > oldBonesPreviousBake.Length)
						{
							UnityEngine.Debug.LogError("Bone index was out of bounds.");
						}
					}
					if (mB_DynamicGameObject.indexesOfBonesUsed.Length < 1)
					{
						UnityEngine.Debug.Log("DGO had no bones");
					}
				}
			}
			return true;
		}
	}

	public class MB_MeshCombinerSingle_BoneProcessorNewAPI : MB_IMeshCombinerSingle_BoneProcessor, IDisposable
	{
		private MB2_LogLevel LOG_LEVEL;

		private bool _initialized;

		private bool _disposed;

		private MB3_MeshCombinerSingle combiner;

		private HashSet<BoneAndBindpose> bonesToAddAndInCombined = new HashSet<BoneAndBindpose>();

		private List<BoneAndBindpose> masterList = new List<BoneAndBindpose>();

		private Matrix4x4[] nBindPoses;

		private Transform[] nbones;

		private int boneWeightSize;

		private int targBoneWeightIdx;

		private Dictionary<MB_DynamicGameObject, int> dgo2firstIdxInBoneWeightsArray = new Dictionary<MB_DynamicGameObject, int>();

		private NativeArray<byte> bonesPerVertex_nvarr;

		private NativeArray<BoneWeight1> boneWeight1s_nvarr;

		public MB_MeshCombinerSingle_BoneProcessorNewAPI(MB3_MeshCombinerSingle cm)
		{
			targBoneWeightIdx = 0;
			boneWeightSize = 0;
			combiner = cm;
			LOG_LEVEL = cm.LOG_LEVEL;
		}

		public int GetNewBonesSize()
		{
			return masterList.Count;
		}

		public void BuildBoneIdx2DGOMapIfNecessary(int[] _goToDelete)
		{
			_initialized = false;
			masterList.Clear();
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				_initialized = true;
			}
		}

		public void RemoveBonesForDgosWeAreDeleting(MB_DynamicGameObject dgo)
		{
		}

		public bool GetCachedSMRMeshData(MB_DynamicGameObject dgo)
		{
			bool result = true;
			Renderer renderer = dgo._renderer;
			MeshChannelsCache_NativeArray meshChannelsCache_NativeArray = (MeshChannelsCache_NativeArray)combiner._meshChannelsCache;
			dgo._tmpSMR_CachedBindposes = meshChannelsCache_NativeArray.GetBindposes(renderer, out dgo.isSkinnedMeshWithBones);
			int count = dgo._tmpSMR_CachedBindposes.Count;
			dgo._tmpSMR_CachedBoneWeightData = meshChannelsCache_NativeArray.GetBoneWeightData(renderer, count, dgo.isSkinnedMeshWithBones);
			dgo.numBoneWeights = dgo._tmpSMR_CachedBoneWeightData.boneWeights.Length;
			Transform[] array = (dgo._tmpSMR_CachedBones = combiner._getBones(renderer, dgo.isSkinnedMeshWithBones));
			if (array.Length > count)
			{
				Array.Resize(ref dgo._tmpSMR_CachedBones, count);
				array = dgo._tmpSMR_CachedBones;
			}
			if (array.Length < count)
			{
				UnityEngine.Debug.LogWarning(dgo.name + " SkinnedMeshRenderer had fewer bones than mesh had bindposes. Mesh may not deform properly: " + array.Length + "  " + count);
			}
			dgo._tmpSMR_CachedBoneAndBindPose = new BoneAndBindpose[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					UnityEngine.Debug.LogError("Source mesh r had a 'null' bone. Bones must not be null: " + renderer);
					result = false;
				}
			}
			if (combiner.settings.smrNoExtraBonesWhenCombiningMeshRenderers)
			{
				for (int j = 0; j < array.Length; j++)
				{
					BoneAndBindpose item = new BoneAndBindpose(array[j], dgo._tmpSMR_CachedBindposes[j]);
					bonesToAddAndInCombined.Add(item);
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("GetCachedSMRMeshData for : " + dgo.name);
				stringBuilder.AppendLine("   _tmpSMR_CachedBindposes: " + dgo._tmpSMR_CachedBindposes.Count);
				stringBuilder.AppendLine("   _tmpSMR_CachedBoneAndBindPose: " + dgo._tmpSMR_CachedBoneAndBindPose.Length);
				stringBuilder.AppendLine("   _tmpSMR_CachedBones: " + dgo._tmpSMR_CachedBones.Length);
				stringBuilder.AppendLine("   _tmpSMR_CachedBoneWeightData: " + dgo._tmpSMR_CachedBoneWeightData.boneWeights.Length);
				UnityEngine.Debug.Log(stringBuilder.ToString());
			}
			return result;
		}

		public void AllocateAndSetupSMRDataStructures(List<MB_DynamicGameObject> dgosToAdd, List<MB_DynamicGameObject> dgosInCombinedMesh, int newVertSize, IVertexAndTriangleProcessor vertexAndTriangleProcessor)
		{
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				MeshChannelsCache_NativeArray meshChannelsCache = (MeshChannelsCache_NativeArray)combiner._meshChannelsCache;
				_CollectSkinningDataForDGOsInCombinedMesh(dgosToAdd, dgosInCombinedMesh, meshChannelsCache);
				_BuildMasterBonesArray(dgosToAdd, dgosInCombinedMesh);
				_AllocateNewArraysForCombinedMesh(newVertSize, vertexAndTriangleProcessor);
			}
		}

		public void UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh()
		{
			if (combiner.settings.renderType != MB_RenderType.skinnedMeshRenderer)
			{
				return;
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh");
			}
			NativeArray<BoneWeight1> allBoneWeights = combiner._mesh.GetAllBoneWeights();
			NativeArray<byte> bonesPerVertex = combiner._mesh.GetBonesPerVertex();
			boneWeight1s_nvarr = new NativeArray<BoneWeight1>(allBoneWeights, Allocator.Persistent);
			bonesPerVertex_nvarr = new NativeArray<byte>(bonesPerVertex, Allocator.Persistent);
			dgo2firstIdxInBoneWeightsArray.Clear();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			MB_DynamicGameObject mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[num3];
			dgo2firstIdxInBoneWeightsArray[mB_DynamicGameObject] = 0;
			for (int i = 0; i < combiner._mesh.vertexCount; i++)
			{
				if (num2 >= mB_DynamicGameObject.numVerts)
				{
					num3++;
					mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[num3];
					dgo2firstIdxInBoneWeightsArray[mB_DynamicGameObject] = num;
					if (num3 == combiner.mbDynamicObjectsInCombinedMesh.Count - 1)
					{
						break;
					}
					num2 = 0;
				}
				num += bonesPerVertex_nvarr[i];
				num2++;
			}
		}

		public void CopyBoneWeightsFromMeshForDGOsInCombined(MB_DynamicGameObject dgo, int targVidx)
		{
			AddBonesToNewBonesArrayAndAdjustBWIndexes1(dgo, targVidx);
		}

		public void AddBonesToNewBonesArrayAndAdjustBWIndexes1(MB_DynamicGameObject dgo, int firstVertexIdxForThisDGO)
		{
			int[] tmpSMR_srcMeshBoneIdx2masterListBoneIdx = dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx;
			int num = 0;
			for (int i = 0; i < dgo.numVerts; i++)
			{
				byte b = dgo._tmpSMR_CachedBoneWeightData.bonesPerVertex[i];
				bonesPerVertex_nvarr[firstVertexIdxForThisDGO + i] = b;
				for (int j = 0; j < b; j++)
				{
					BoneWeight1 value = dgo._tmpSMR_CachedBoneWeightData.boneWeights[num];
					value.boneIndex = tmpSMR_srcMeshBoneIdx2masterListBoneIdx[value.boneIndex];
					boneWeight1s_nvarr[targBoneWeightIdx + num] = value;
					num++;
				}
			}
			for (int k = 0; k < dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx.Length; k++)
			{
				int num2 = dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx[k];
				dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx[k] = num2;
			}
			dgo.indexesOfBonesUsed = dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx;
			targBoneWeightIdx += dgo.numBoneWeights;
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("AddBonesToNewBonesArrayAndAdjustBWIndexes1  " + dgo.name + "  remapped indexes for " + dgo._tmpSMR_CachedBoneWeightData.boneWeights.Length + "  boneweigts.");
			}
			dgo._tmpSMR_srcMeshBoneIdx2masterListBoneIdx = null;
			dgo._tmpSMR_CachedBones = null;
			dgo._tmpSMR_CachedBindposes = null;
			dgo._tmpSMR_CachedBoneWeights = null;
			dgo._tmpSMR_CachedBoneAndBindPose = null;
		}

		public void CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(int totalDeleteVerts)
		{
		}

		public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, Vector3[] nnorms, Vector4[] ntangs, Vector3[] nverts, Vector3[] normals, Vector4[] tangents, Vector3[] verts)
		{
			UnityEngine.Debug.LogError("TODO should call the non-native array version of this");
		}

		public void CopyVertsNormsTansToBuffers(MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, NativeSlice<Vector3> nnorms, NativeSlice<Vector4> ntangs, NativeSlice<Vector3> nverts, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents, NativeSlice<Vector3> verts)
		{
			bool flag = dgo._renderer is MeshRenderer;
			if (settings.smrNoExtraBonesWhenCombiningMeshRenderers && flag && dgo._tmpSMR_CachedBones[0] != dgo.gameObject.transform)
			{
				Matrix4x4 matrix4x = dgo._tmpSMR_CachedBindposes[0].inverse * dgo._tmpSMR_CachedBones[0].worldToLocalMatrix * dgo.gameObject.transform.localToWorldMatrix;
				Matrix4x4 matrix4x2 = matrix4x;
				float num = (matrix4x2[2, 3] = 0f);
				float value = (matrix4x2[1, 3] = num);
				matrix4x2[0, 3] = value;
				matrix4x2 = matrix4x2.inverse.transpose;
				for (int i = 0; i < dgo._mesh.vertexCount; i++)
				{
					int index = vertsIdx + i;
					verts[vertsIdx + i] = matrix4x.MultiplyPoint3x4(nverts[i]);
					if (settings.doNorm)
					{
						normals[index] = matrix4x2.MultiplyPoint3x4(nnorms[i]).normalized;
					}
					if (settings.doTan)
					{
						float w = ntangs[i].w;
						Vector4 value2 = matrix4x2.MultiplyPoint3x4(ntangs[i]).normalized;
						value2.w = w;
						tangents[index] = value2;
					}
				}
			}
			else
			{
				if (settings.doNorm)
				{
					MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(nnorms, normals, vertsIdx);
				}
				if (settings.doTan)
				{
					MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(ntangs, tangents, vertsIdx);
				}
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(nverts, verts, vertsIdx);
			}
		}

		public void InsertNewBonesIntoBonesArray()
		{
			if (combiner.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("InsertNewBonesIntoBonesArray ");
				}
				combiner.bindPoses = nBindPoses;
				combiner.bones = nbones;
				return;
			}
			if (combiner.bindPoses == null || combiner.bindPoses.Length != 0)
			{
				combiner.bindPoses = new Matrix4x4[0];
			}
			if (combiner.bones == null || combiner.bones.Length != 0)
			{
				combiner.bones = new Transform[0];
			}
		}

		public void ApplySMRdataToMeshToBuffer()
		{
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("ApplySMRdataToMeshToBuffer ");
			}
		}

		public void ApplySMRdataToMesh(MB3_MeshCombinerSingle combiner, Mesh mesh)
		{
			mesh.bindposes = nBindPoses;
			mesh.SetBoneWeights(bonesPerVertex_nvarr, boneWeight1s_nvarr);
			nBindPoses = null;
			nbones = null;
			bonesPerVertex_nvarr.Dispose();
			boneWeight1s_nvarr.Dispose();
		}

		public void UpdateGameObjects_UpdateBWIndexes(MB_DynamicGameObject dgo)
		{
			NativeArray<BoneWeight1> boneWeights = dgo._tmpSMR_CachedBoneWeightData.boneWeights;
			bool flag = false;
			int num = dgo2firstIdxInBoneWeightsArray[dgo];
			for (int i = 0; i < boneWeights.Length; i++)
			{
				BoneWeight1 value = boneWeights[i];
				value.boneIndex = dgo.indexesOfBonesUsed[value.boneIndex];
				boneWeight1s_nvarr[num] = value;
				num++;
			}
			if (flag)
			{
				UnityEngine.Debug.LogError("Detected that some of the boneweights reference different bones than when initial added. Boneweights must reference the same bones " + dgo.name);
			}
		}

		protected void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			if (disposing)
			{
				if (boneWeight1s_nvarr.IsCreated)
				{
					boneWeight1s_nvarr.Dispose();
				}
				if (bonesPerVertex_nvarr.IsCreated)
				{
					bonesPerVertex_nvarr.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public void DisposeOfTemporarySMRData()
		{
			if (bonesToAddAndInCombined != null)
			{
				bonesToAddAndInCombined.Clear();
			}
			if (masterList != null)
			{
				masterList.Clear();
			}
			if (dgo2firstIdxInBoneWeightsArray != null)
			{
				dgo2firstIdxInBoneWeightsArray.Clear();
			}
			for (int i = 0; i < combiner.mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = combiner.mbDynamicObjectsInCombinedMesh[i];
				mB_DynamicGameObject._tmpSMR_srcMeshBoneIdx2masterListBoneIdx = null;
				mB_DynamicGameObject._tmpSMR_CachedBindposes = null;
				mB_DynamicGameObject._tmpSMR_CachedBoneAndBindPose = null;
				mB_DynamicGameObject._tmpSMR_CachedBones = null;
				mB_DynamicGameObject._tmpSMR_CachedBoneWeightData.Dispose();
				mB_DynamicGameObject._tmpSMR_CachedBoneWeights = null;
			}
		}

		internal void _AllocateNewArraysForCombinedMesh(int newVertSize, IVertexAndTriangleProcessor vertexAndTriangleProcessor)
		{
			if (boneWeight1s_nvarr.IsCreated)
			{
				boneWeight1s_nvarr.Dispose();
			}
			if (bonesPerVertex_nvarr.IsCreated)
			{
				bonesPerVertex_nvarr.Dispose();
			}
			boneWeight1s_nvarr = new NativeArray<BoneWeight1>(boneWeightSize, Allocator.Persistent);
			bonesPerVertex_nvarr = new NativeArray<byte>(newVertSize, Allocator.Persistent);
			nBindPoses = new Matrix4x4[masterList.Count];
			nbones = new Transform[masterList.Count];
			for (int i = 0; i < masterList.Count; i++)
			{
				nBindPoses[i] = masterList[i].bindPose;
				nbones[i] = masterList[i].bone;
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("  _AllocateNewArraysForCombinedMesh boneWeight1s_nvarr:" + boneWeight1s_nvarr.Length + " bonesPerVertex_nvarr:" + bonesPerVertex_nvarr.Length + "  numBones: " + masterList.Count);
			}
			targBoneWeightIdx = 0;
		}

		private bool _CollectBonesToAddForDGO_Pass2(MB_DynamicGameObject dgo, bool noExtraBonesForMeshRenderers)
		{
			bool result = true;
			List<Matrix4x4> tmpSMR_CachedBindposes = dgo._tmpSMR_CachedBindposes;
			Transform[] tmpSMR_CachedBones = dgo._tmpSMR_CachedBones;
			if (noExtraBonesForMeshRenderers && dgo._renderer is MeshRenderer)
			{
				bool flag = false;
				BoneAndBindpose boneAndBindpose = default(BoneAndBindpose);
				Transform parent = dgo.gameObject.transform.parent;
				while (parent != null)
				{
					foreach (BoneAndBindpose item in bonesToAddAndInCombined)
					{
						if (item.bone == parent)
						{
							boneAndBindpose = item;
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
					parent = parent.parent;
				}
				if (flag)
				{
					tmpSMR_CachedBones[0] = boneAndBindpose.bone;
					tmpSMR_CachedBindposes[0] = boneAndBindpose.bindPose;
				}
			}
			for (int i = 0; i < tmpSMR_CachedBones.Length; i++)
			{
				if (dgo._tmpSMR_CachedBoneWeightData.UsedBoneIdxsInSrcMesh[i])
				{
					BoneAndBindpose boneAndBindpose2 = new BoneAndBindpose(tmpSMR_CachedBones[i], tmpSMR_CachedBindposes[i]);
					dgo._tmpSMR_CachedBoneAndBindPose[i] = boneAndBindpose2;
				}
			}
			return result;
		}

		private int _BuildMasterBonesArray(List<MB_DynamicGameObject> dgosToAdd, List<MB_DynamicGameObject> dgosInCombinedMesh)
		{
			boneWeightSize = 0;
			Dictionary<BoneAndBindpose, int> dictionary = new Dictionary<BoneAndBindpose, int>();
			masterList.Clear();
			StringBuilder stringBuilder = null;
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("_BuildMasterBonesArray");
			}
			for (int i = 0; i < dgosInCombinedMesh.Count; i++)
			{
				if (dgosInCombinedMesh[i]._beingDeleted)
				{
					continue;
				}
				MB_DynamicGameObject mB_DynamicGameObject = dgosInCombinedMesh[i];
				boneWeightSize += mB_DynamicGameObject.numBoneWeights;
				int num = mB_DynamicGameObject._tmpSMR_CachedBoneAndBindPose.Length;
				int[] array = new int[num];
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					if (mB_DynamicGameObject._tmpSMR_CachedBoneWeightData.UsedBoneIdxsInSrcMesh[j])
					{
						BoneAndBindpose boneAndBindpose = mB_DynamicGameObject._tmpSMR_CachedBoneAndBindPose[j];
						if (!dictionary.TryGetValue(boneAndBindpose, out var value))
						{
							dictionary.Add(boneAndBindpose, masterList.Count);
							value = masterList.Count;
							num2++;
							masterList.Add(boneAndBindpose);
						}
						array[j] = value;
					}
				}
				mB_DynamicGameObject._tmpSMR_srcMeshBoneIdx2masterListBoneIdx = array;
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					stringBuilder.AppendLine(mB_DynamicGameObject.name + "  addedToMasterList: " + num2 + "    srcMeshBoneIdx2masterListBoneIdx: " + array.Length);
				}
			}
			for (int k = 0; k < dgosToAdd.Count; k++)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = dgosToAdd[k];
				boneWeightSize += mB_DynamicGameObject2.numBoneWeights;
				int num3 = mB_DynamicGameObject2._tmpSMR_CachedBoneAndBindPose.Length;
				int[] array2 = new int[num3];
				for (int l = 0; l < num3; l++)
				{
					if (mB_DynamicGameObject2._tmpSMR_CachedBoneWeightData.UsedBoneIdxsInSrcMesh[l])
					{
						BoneAndBindpose boneAndBindpose2 = mB_DynamicGameObject2._tmpSMR_CachedBoneAndBindPose[l];
						if (!dictionary.TryGetValue(boneAndBindpose2, out var value2))
						{
							dictionary.Add(boneAndBindpose2, masterList.Count);
							value2 = masterList.Count;
							masterList.Add(boneAndBindpose2);
						}
						array2[l] = value2;
					}
				}
				mB_DynamicGameObject2._tmpSMR_srcMeshBoneIdx2masterListBoneIdx = array2;
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					stringBuilder.AppendLine(mB_DynamicGameObject2.name + "    srcMeshBoneIdx2masterListBoneIdx: " + array2.Length);
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				stringBuilder.AppendLine("Master List Length: " + masterList.Count);
				UnityEngine.Debug.Log(stringBuilder);
			}
			return masterList.Count;
		}

		internal void _CollectSkinningDataForDGOsInCombinedMesh(List<MB_DynamicGameObject> dgosAdding, List<MB_DynamicGameObject> dgosInCombinedMesh, MeshChannelsCache_NativeArray meshChannelsCache)
		{
			for (int i = 0; i < dgosAdding.Count; i++)
			{
				MB_DynamicGameObject dgo = dgosAdding[i];
				_CollectBonesToAddForDGO_Pass2(dgo, combiner.settings.smrNoExtraBonesWhenCombiningMeshRenderers);
			}
			int num = 0;
			for (int j = 0; j < dgosInCombinedMesh.Count; j++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = dgosInCombinedMesh[j];
				if (!mB_DynamicGameObject._beingDeleted)
				{
					num++;
					_CollectBonesToAddForDGO_Pass2(mB_DynamicGameObject, combiner.settings.smrNoExtraBonesWhenCombiningMeshRenderers);
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("_CollectSkinningDataForDGOsInCombinedMesh: dgosAdding:" + dgosAdding.Count + " dgosInCombined:" + num);
			}
		}

		public bool DB_CheckIntegrity()
		{
			return true;
		}
	}

	public enum MeshCreationConditions
	{
		NoMesh,
		CreatedInEditor,
		CreatedAtRuntime,
		AssignedByUser
	}

	[Serializable]
	public struct BufferDataFromPreviousBake
	{
		public int numVertsBaked;

		public Vector3 meshVerticesShift;

		public bool meshVerticiesWereShifted;
	}

	[Serializable]
	public class SerializableIntArray
	{
		[SerializeField]
		public int[] data;

		public SerializableIntArray()
		{
			data = new int[0];
		}

		public SerializableIntArray(int len)
		{
			data = new int[len];
		}
	}

	public struct BoneWeightDataForMesh
	{
		private bool _disposed;

		public bool initialized;

		public bool weMustDispose;

		public NativeArray<byte> bonesPerVertex;

		public NativeArray<BoneWeight1> boneWeights;

		public bool[] UsedBoneIdxsInSrcMesh;

		public int numUsedbones;

		internal void Dispose()
		{
			Dispose(disposing: true);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				_disposed = true;
				initialized = false;
				if (bonesPerVertex.IsCreated && weMustDispose)
				{
					bonesPerVertex.Dispose();
				}
				if (boneWeights.IsCreated && weMustDispose)
				{
					boneWeights.Dispose();
				}
			}
		}
	}

	[Serializable]
	public class MB_DynamicGameObject : IComparable<MB_DynamicGameObject>
	{
		public int instanceID;

		public GameObject gameObject;

		public string name;

		public int vertIdx;

		public int blendShapeIdx;

		public int numVerts;

		public int numBlendShapes;

		public int numBoneWeights;

		public bool isSkinnedMeshWithBones;

		public int[] indexesOfBonesUsed = new int[0];

		public int lightmapIndex = -1;

		public Vector4 lightmapTilingOffset = new Vector4(1f, 1f, 0f, 0f);

		public Vector3 meshSize = Vector3.one;

		public bool show = true;

		public bool invertTriangles;

		public int[] submeshTriIdxs;

		public int[] submeshNumTris;

		public int[] targetSubmeshIdxs;

		public Rect[] uvRects;

		public Rect[] encapsulatingRect;

		public Rect[] sourceMaterialTiling;

		public Rect[] obUVRects;

		public int[] textureArraySliceIdx;

		public Material[] sourceSharedMaterials;

		[NonSerialized]
		internal bool _initialized;

		[NonSerialized]
		internal bool _beingDeleted;

		[NonSerialized]
		internal Mesh _mesh;

		[NonSerialized]
		internal Renderer _renderer;

		[NonSerialized]
		internal SerializableIntArray[] _tmpSubmeshTris;

		[NonSerialized]
		internal Transform[] _tmpSMR_CachedBones;

		[NonSerialized]
		internal List<Matrix4x4> _tmpSMR_CachedBindposes;

		[NonSerialized]
		internal BoneAndBindpose[] _tmpSMR_CachedBoneAndBindPose;

		[NonSerialized]
		internal int[] _tmpSMR_srcMeshBoneIdx2masterListBoneIdx;

		[NonSerialized]
		internal BoneWeight[] _tmpSMR_CachedBoneWeights;

		[NonSerialized]
		internal BoneWeightDataForMesh _tmpSMR_CachedBoneWeightData;

		public bool Initialize(bool beingDeleted)
		{
			_initialized = true;
			_beingDeleted = beingDeleted;
			if (!beingDeleted)
			{
				_mesh = MB_Utility.GetMesh(gameObject);
				_renderer = MB_Utility.GetRenderer(gameObject);
				if (_mesh != null)
				{
					return _renderer != null;
				}
				return false;
			}
			return true;
		}

		public bool InitializeNew(bool beingDeleted, GameObject go)
		{
			gameObject = go;
			name = $"{gameObject.ToString()} {gameObject.GetInstanceID()}";
			if (go == null)
			{
				return false;
			}
			instanceID = gameObject.GetInstanceID();
			return Initialize(beingDeleted);
		}

		public void UnInitialize()
		{
			_initialized = false;
			_beingDeleted = false;
			_mesh = null;
			_renderer = null;
		}

		public int CompareTo(MB_DynamicGameObject b)
		{
			return vertIdx - b.vertIdx;
		}
	}

	public class MeshChannels : IDisposable
	{
		private bool _disposed;

		public Vector3[] vertices;

		public Vector3[] normals;

		public Vector4[] tangents;

		public Vector2[] uv0raw;

		public Vector2[] uv0modified;

		public Vector2[] uv2raw;

		public Vector2[] uv2modified;

		public Vector2[] uv3;

		public Vector2[] uv4;

		public Vector2[] uv5;

		public Vector2[] uv6;

		public Vector2[] uv7;

		public Vector2[] uv8;

		public Color[] colors;

		public BoneWeight[] boneWeights;

		public List<Matrix4x4> bindPoses = new List<Matrix4x4>(128);

		public int[] triangles;

		public MBBlendShape[] blendShapes;

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public bool IsDisposed()
		{
			return _disposed;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				_disposed = true;
				vertices = null;
				normals = null;
				tangents = null;
				uv0raw = null;
				uv0modified = null;
				uv2raw = null;
				uv2modified = null;
				uv3 = null;
				uv4 = null;
				uv5 = null;
				uv6 = null;
				uv7 = null;
				uv8 = null;
				colors = null;
				boneWeights = null;
				bindPoses = null;
				triangles = null;
				blendShapes = null;
			}
		}
	}

	[Serializable]
	public class MBBlendShapeFrame
	{
		public float frameWeight;

		public Vector3[] vertices;

		public Vector3[] normals;

		public Vector3[] tangents;
	}

	[Serializable]
	public class MBBlendShape
	{
		public GameObject gameObject;

		public string name;

		public int indexInSource;

		public MBBlendShapeFrame[] frames;
	}

	public struct BoneAndBindpose(Transform t, Matrix4x4 bp)
	{
		public Transform bone = t;

		public Matrix4x4 bindPose = bp;

		public override bool Equals(object obj)
		{
			if (obj is BoneAndBindpose && bone == ((BoneAndBindpose)obj).bone && bindPose == ((BoneAndBindpose)obj).bindPose)
			{
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (bone.GetInstanceID() % int.MaxValue) ^ (int)bindPose[0, 0];
		}
	}

	public interface IMeshChannelsCacheTaggingInterface
	{
		void Dispose();

		bool HasCollectedMeshData();

		void CollectChannelDataForAllMeshesInList(List<MB_DynamicGameObject> toUpdateDGOs, List<MB_DynamicGameObject> toAddDGOs, MB_MeshVertexChannelFlags newChannels, MB_RenderType renderType, bool doBlendShapes);

		MBBlendShape[] GetBlendShapes(Mesh mesh, int instanceID, GameObject gameObject);

		bool hasOutOfBoundsUVs(Mesh m, ref MB_Utility.MeshAnalysisResult mar, int submeshIdx);
	}

	public class MeshChannelsCache : IDisposable, IMeshChannelsCacheTaggingInterface
	{
		private MB2_LogLevel LOG_LEVEL;

		private MB2_LightmapOptions lightmapOption;

		protected Dictionary<int, MeshChannels> meshID2MeshChannels = new Dictionary<int, MeshChannels>();

		private bool _collectedMeshData;

		private bool _disposed;

		private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

		public MeshChannelsCache(MB2_LogLevel ll, MB2_LightmapOptions lo)
		{
			LOG_LEVEL = ll;
			lightmapOption = lo;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			foreach (MeshChannels value in meshID2MeshChannels.Values)
			{
				value.Dispose();
			}
			_collectedMeshData = false;
			_disposed = true;
		}

		public bool HasCollectedMeshData()
		{
			return _collectedMeshData;
		}

		public bool hasOutOfBoundsUVs(Mesh m, ref MB_Utility.MeshAnalysisResult mar, int submeshIdx)
		{
			return MB_Utility.hasOutOfBoundsUVs(GetUv0Raw(m), m, ref mar, submeshIdx);
		}

		internal Vector3[] GetVertices(Mesh m)
		{
			if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
			{
				UnityEngine.Debug.LogError("Could not find mesh in the MeshChannelsCache." + m);
			}
			return value.vertices;
		}

		internal Vector3[] GetNormals(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.normals;
		}

		internal Vector4[] GetTangents(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.tangents;
		}

		internal Vector2[] GetUv0Raw(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.uv0raw;
		}

		internal Vector2[] GetUv0Modified(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.uv0modified;
		}

		internal Vector2[] GetUv2Modified(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.uv2modified;
		}

		internal Vector2[] GetUVChannel(int channel, Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			switch (channel)
			{
			case 0:
				return value.uv0raw;
			case 2:
				return value.uv2raw;
			case 3:
				return value.uv3;
			case 4:
				return value.uv4;
			case 5:
				return value.uv5;
			case 6:
				return value.uv6;
			case 7:
				return value.uv7;
			case 8:
				return value.uv8;
			default:
				UnityEngine.Debug.LogError("Error mesh channel " + channel + " not supported");
				return null;
			}
		}

		internal Color[] GetColors(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.colors;
		}

		public void CollectChannelDataForAllMeshesInList(List<MB_DynamicGameObject> toUpdateDGOs, List<MB_DynamicGameObject> toAddDGOs, MB_MeshVertexChannelFlags newChannels, MB_RenderType renderType, bool doBlendShapes)
		{
			bool flag = (newChannels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex;
			bool flag2 = (newChannels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal;
			bool flag3 = (newChannels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent;
			bool flag4 = (newChannels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0;
			bool flag5 = (newChannels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2;
			bool flag6 = (newChannels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3;
			bool flag7 = (newChannels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4;
			bool flag8 = (newChannels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5;
			bool flag9 = (newChannels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6;
			bool flag10 = (newChannels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7;
			bool flag11 = (newChannels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8;
			bool flag12 = (newChannels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors;
			List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
			list.AddRange(toUpdateDGOs);
			list.AddRange(toAddDGOs);
			for (int i = 0; i < list.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = list[i];
				Mesh mesh = mB_DynamicGameObject._mesh;
				if (meshID2MeshChannels.ContainsKey(mesh.GetInstanceID()))
				{
					continue;
				}
				MeshChannels meshChannels = new MeshChannels();
				meshID2MeshChannels.Add(mesh.GetInstanceID(), meshChannels);
				if (flag)
				{
					meshChannels.vertices = mesh.vertices;
				}
				if (flag4)
				{
					meshChannels.uv0raw = _getMeshUVs(mesh);
				}
				if (flag5)
				{
					meshChannels.uv2raw = _getMeshUV2s(mesh, ref meshChannels.uv2modified);
				}
				if (flag2)
				{
					meshChannels.normals = _getMeshNormals(mesh);
				}
				if (flag3)
				{
					meshChannels.tangents = _getMeshTangents(mesh);
				}
				if (flag6)
				{
					meshChannels.uv3 = MBVersion.GetMeshChannel(3, mesh, LOG_LEVEL);
				}
				if (flag7)
				{
					meshChannels.uv4 = MBVersion.GetMeshChannel(4, mesh, LOG_LEVEL);
				}
				if (flag8)
				{
					meshChannels.uv5 = MBVersion.GetMeshChannel(5, mesh, LOG_LEVEL);
				}
				if (flag9)
				{
					meshChannels.uv6 = MBVersion.GetMeshChannel(6, mesh, LOG_LEVEL);
				}
				if (flag10)
				{
					meshChannels.uv7 = MBVersion.GetMeshChannel(7, mesh, LOG_LEVEL);
				}
				if (flag11)
				{
					meshChannels.uv8 = MBVersion.GetMeshChannel(8, mesh, LOG_LEVEL);
				}
				if (flag12)
				{
					meshChannels.colors = _getMeshColors(mesh);
				}
				if (renderType != MB_RenderType.skinnedMeshRenderer)
				{
					continue;
				}
				Renderer renderer = mB_DynamicGameObject._renderer;
				_getBindPoses(renderer, meshChannels.bindPoses, out var isSkinnedMeshWithBones);
				meshChannels.boneWeights = _getBoneWeights(renderer, mesh.vertexCount, isSkinnedMeshWithBones);
				if (!doBlendShapes)
				{
					continue;
				}
				MBBlendShape[] array = new MBBlendShape[mesh.blendShapeCount];
				int vertexCount = mesh.vertexCount;
				for (int j = 0; j < array.Length; j++)
				{
					MBBlendShape mBBlendShape = (array[j] = new MBBlendShape());
					mBBlendShape.frames = new MBBlendShapeFrame[MBVersion.GetBlendShapeFrameCount(mesh, j)];
					mBBlendShape.name = mesh.GetBlendShapeName(j);
					mBBlendShape.indexInSource = j;
					mBBlendShape.gameObject = mB_DynamicGameObject.gameObject;
					for (int k = 0; k < mBBlendShape.frames.Length; k++)
					{
						MBBlendShapeFrame mBBlendShapeFrame = (mBBlendShape.frames[k] = new MBBlendShapeFrame());
						mBBlendShapeFrame.frameWeight = MBVersion.GetBlendShapeFrameWeight(mesh, j, k);
						mBBlendShapeFrame.vertices = new Vector3[vertexCount];
						mBBlendShapeFrame.normals = new Vector3[vertexCount];
						mBBlendShapeFrame.tangents = new Vector3[vertexCount];
						MBVersion.GetBlendShapeFrameVertices(mesh, j, k, mBBlendShapeFrame.vertices, mBBlendShapeFrame.normals, mBBlendShapeFrame.tangents);
					}
				}
				meshChannels.blendShapes = array;
			}
			_collectedMeshData = true;
		}

		internal List<Matrix4x4> GetBindposes(Renderer r, out bool isSkinnedMeshWithBones)
		{
			Mesh mesh = MB_Utility.GetMesh(r.gameObject);
			meshID2MeshChannels.TryGetValue(mesh.GetInstanceID(), out var value);
			if (r is SkinnedMeshRenderer && value.bindPoses.Count > 0)
			{
				isSkinnedMeshWithBones = true;
			}
			else
			{
				isSkinnedMeshWithBones = false;
				_ = r is SkinnedMeshRenderer;
			}
			return value.bindPoses;
		}

		internal BoneWeight[] GetBoneWeights(Renderer r, int numVertsInMeshBeingAdded, bool isSkinnedMeshWithBones)
		{
			Mesh mesh = MB_Utility.GetMesh(r.gameObject);
			meshID2MeshChannels.TryGetValue(mesh.GetInstanceID(), out var value);
			return value.boneWeights;
		}

		public MBBlendShape[] GetBlendShapes(Mesh m, int gameObjectID, GameObject gameObject)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			MBBlendShape[] array = new MBBlendShape[value.blendShapes.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new MBBlendShape();
				array[i].name = value.blendShapes[i].name;
				array[i].indexInSource = value.blendShapes[i].indexInSource;
				array[i].frames = value.blendShapes[i].frames;
				array[i].gameObject = gameObject;
			}
			return array;
		}

		private Color[] _getMeshColors(Mesh m)
		{
			Color[] array = m.colors;
			if (array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no colors. Generating");
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have colors. Generating an array of white colors");
				}
				array = new Color[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Color.white;
				}
			}
			return array;
		}

		private Vector3[] _getMeshNormals(Mesh m)
		{
			Vector3[] normals = m.normals;
			if (normals.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no normals. Generating");
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have normals. Generating normals.");
				}
				Mesh mesh = UnityEngine.Object.Instantiate(m);
				mesh.RecalculateNormals();
				normals = mesh.normals;
				MB_Utility.Destroy(mesh);
			}
			return normals;
		}

		private Vector4[] _getMeshTangents(Mesh m)
		{
			Vector4[] array = m.tangents;
			if (array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no tangents. Generating");
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have tangents. Generating tangents.");
				}
				Vector3[] vertices = m.vertices;
				Vector2[] uv0Raw = GetUv0Raw(m);
				Vector3[] normals = _getMeshNormals(m);
				array = new Vector4[m.vertexCount];
				for (int i = 0; i < m.subMeshCount; i++)
				{
					int[] triangles = m.GetTriangles(i);
					_generateTangents(triangles, vertices, uv0Raw, normals, array);
				}
			}
			return array;
		}

		private Vector2[] _getMeshUVs(Mesh m)
		{
			Vector2[] array = m.uv;
			if (array.Length == 0)
			{
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
				}
			}
			return array;
		}

		private Vector2[] _getMeshUV2s(Mesh m, ref Vector2[] uv2modified)
		{
			Vector2[] uv = m.uv2;
			if (uv.Length == 0)
			{
				uv2modified = new Vector2[m.vertexCount];
				for (int i = 0; i < uv2modified.Length; i++)
				{
					uv2modified[i] = _HALF_UV;
				}
			}
			return uv;
		}

		private static void _getBindPoses(Renderer r, List<Matrix4x4> poses, out bool isSkinnedMeshWithBones)
		{
			poses.Clear();
			isSkinnedMeshWithBones = r is SkinnedMeshRenderer;
			if (r is SkinnedMeshRenderer)
			{
				Mesh mesh = MB_Utility.GetMesh(r.gameObject);
				mesh.GetBindposes(poses);
				if (poses.Count == 0)
				{
					if (mesh.blendShapeCount > 0)
					{
						isSkinnedMeshWithBones = false;
					}
					else
					{
						UnityEngine.Debug.LogError("Skinned mesh " + r?.ToString() + " had no bindposes AND no blend shapes");
					}
				}
			}
			if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
			{
				poses.Clear();
				poses.Add(Matrix4x4.identity);
			}
			if (poses == null || poses.Count == 0)
			{
				UnityEngine.Debug.LogError("Could not _getBindPoses. Object does not have a renderer");
			}
		}

		private static BoneWeight[] _getBoneWeights(Renderer r, int numVertsInMeshBeingAdded, bool isSkinnedMeshWithBones)
		{
			if (isSkinnedMeshWithBones)
			{
				return ((SkinnedMeshRenderer)r).sharedMesh.boneWeights;
			}
			if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
			{
				BoneWeight boneWeight = default(BoneWeight);
				int num = (boneWeight.boneIndex3 = 0);
				int num3 = (boneWeight.boneIndex2 = num);
				int boneIndex = (boneWeight.boneIndex1 = num3);
				boneWeight.boneIndex0 = boneIndex;
				boneWeight.weight0 = 1f;
				float num6 = (boneWeight.weight3 = 0f);
				float weight = (boneWeight.weight2 = num6);
				boneWeight.weight1 = weight;
				BoneWeight[] array = new BoneWeight[numVertsInMeshBeingAdded];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = boneWeight;
				}
				return array;
			}
			UnityEngine.Debug.LogError("Could not _getBoneWeights. Object does not have a renderer");
			return null;
		}

		private void _generateTangents(int[] triangles, Vector3[] verts, Vector2[] uvs, Vector3[] normals, Vector4[] outTangents)
		{
			int num = triangles.Length;
			int num2 = verts.Length;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			for (int i = 0; i < num; i += 3)
			{
				int num3 = triangles[i];
				int num4 = triangles[i + 1];
				int num5 = triangles[i + 2];
				Vector3 vector = verts[num3];
				Vector3 vector2 = verts[num4];
				Vector3 vector3 = verts[num5];
				Vector2 vector4 = uvs[num3];
				Vector2 vector5 = uvs[num4];
				Vector2 vector6 = uvs[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = num12 * num15 - num13 * num14;
				if (num16 == 0f)
				{
					UnityEngine.Debug.LogError("Could not compute tangents. All UVs need to form a valid triangles in UV space. If any UV triangles are collapsed, tangents cannot be generated.");
					return;
				}
				float num17 = 1f / num16;
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num17, (num15 * num8 - num14 * num9) * num17, (num15 * num10 - num14 * num11) * num17);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num17, (num12 * num9 - num13 * num8) * num17, (num12 * num11 - num13 * num10) * num17);
				array[num3] += vector7;
				array[num4] += vector7;
				array[num5] += vector7;
				array2[num3] += vector8;
				array2[num4] += vector8;
				array2[num5] += vector8;
			}
			for (int j = 0; j < num2; j++)
			{
				Vector3 vector9 = normals[j];
				Vector3 vector10 = array[j];
				Vector3 normalized = (vector10 - vector9 * Vector3.Dot(vector9, vector10)).normalized;
				outTangents[j] = new Vector4(normalized.x, normalized.y, normalized.z);
				outTangents[j].w = ((Vector3.Dot(Vector3.Cross(vector9, vector10), array2[j]) < 0f) ? (-1f) : 1f);
			}
		}
	}

	public interface IVertexAndTriangleProcessor : IDisposable
	{
		MB_MeshVertexChannelFlags channels { get; }

		bool IsInitialized();

		bool IsDisposed();

		void Init(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int vertexCount, int[] newSubmeshTrisSize, int uvChannelWithExtraParameter, IMeshChannelsCacheTaggingInterface meshChannelsCache, bool loadDataFromCombinedMesh, MB2_LogLevel logLevel);

		void InitShowHide(MB3_MeshCombinerSingle combiner);

		void InitFromMeshCombiner(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int uvChannelWithExtraParameter);

		int GetVertexCount();

		int GetSubmeshCount();

		void TransferOwnershipOfSerializableBuffersToCombiner(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags channelsToTransfer, BufferDataFromPreviousBake serializableBufferData);

		void CopyArraysFromPreviousBakeBuffersToNewBuffers(MB_DynamicGameObject dgo, ref IVertexAndTriangleProcessor iOldBuffers, int destStartVertIdx, int triangleIdxAdjustment, int[] targSubmeshTidx, MB2_LogLevel LOG_LEVEL);

		void CopyFromDGOMeshToBuffers(MB_DynamicGameObject dgo, int destStartVertsIdx, MB_MeshVertexChannelFlags channelsToUpdate, bool updateTris, bool updateBWdata, MB_IMeshBakerSettings settings, MB_IMeshCombinerSingle_BoneProcessor boneProcessor, int[] targSubmeshTidx, MB2_TextureBakeResults textureBakeResults, UVAdjuster_Atlas uvAdjuster, MB2_LogLevel LOG_LEVEL, IMeshChannelsCacheTaggingInterface meshChannelCache);

		void AssignBuffersToMesh(Mesh mesh, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, MB_MeshVertexChannelFlags channelsToWriteToMesh, bool doWriteTrisToMesh, IAssignToMeshCustomizer assignToMeshCustomizer, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, out BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes);

		void AssignTriangleDataForSubmeshes(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes);

		void AssignTriangleDataForSubmeshes_ShowHide(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes);

		void CopyUV2unchangedToSeparateRects(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, float uv2UnwrappingParamsPackMargin);

		int[] GetTriangleSizes();
	}

	public class MB_MeshCombinerSingle_SubCombiner
	{
		public static void instance2Combined_MapAdd(ref Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map, GameObject gameObjectID, MB_DynamicGameObject dgo)
		{
			_instance2combined_map.Add(gameObjectID, dgo);
		}

		public static void instance2Combined_MapRemove(ref Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map, GameObject gameObjectID)
		{
			_instance2combined_map.Remove(gameObjectID);
		}

		internal static bool _ShowHideGameObjects(MB3_MeshCombinerSingle c)
		{
			c._vertexAndTriProcessor.InitShowHide(c);
			return true;
		}

		internal static bool _AddToCombined(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags newChannels, int totalAddVerts, int totalDeleteVerts, int numResultMats, int totalAddBlendShapes, int totalDeleteBlendShapes, int[] totalAddSubmeshTris, int[] totalDeleteSubmeshTris, int[] _goToDelete, List<MB_DynamicGameObject> toAddDGOs, GameObject[] _goToAdd, UVAdjuster_Atlas uvAdjuster, ref IVertexAndTriangleProcessor oldMeshData, Stopwatch sw)
		{
			MB_IMeshCombinerSingle_BoneProcessor boneProcessor = c._boneProcessor;
			MB_MeshCombinerSingle_BlendShapeProcessor blendShapeProcessor = c._blendShapeProcessor;
			IMeshChannelsCacheTaggingInterface meshChannelsCache = c._meshChannelsCache;
			MB_IMeshBakerSettings settings = c.settings;
			MB2_LogLevel lOG_LEVEL = c.LOG_LEVEL;
			MB2_TextureBakeResults textureBakeResults = c.textureBakeResults;
			List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh = c.mbDynamicObjectsInCombinedMesh;
			List<GameObject> objectsInCombinedMesh = c.objectsInCombinedMesh;
			Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map = c._instance2combined_map;
			int uvChannelWithExtraParameter = ((c.settings.assignToMeshCustomizer == null || !(c.settings.assignToMeshCustomizer is IAssignToMeshCustomizer_NativeArrays)) ? (-1) : ((IAssignToMeshCustomizer_NativeArrays)c.settings.assignToMeshCustomizer).UVchannelWithExtraParameter());
			c.db_addDeleteGameObjects_InitFromMeshCombiner.Start();
			int num;
			int[] array;
			if (!settings.clearBuffersAfterBake && mbDynamicObjectsInCombinedMesh.Count > 0)
			{
				oldMeshData.InitFromMeshCombiner(c, newChannels, uvChannelWithExtraParameter);
				num = oldMeshData.GetVertexCount();
				array = oldMeshData.GetTriangleSizes();
			}
			else
			{
				num = 0;
				array = new int[numResultMats];
			}
			c.db_addDeleteGameObjects_InitFromMeshCombiner.Stop();
			c.db_addDeleteGameObjects_Init.Start();
			int num2 = num + totalAddVerts - totalDeleteVerts;
			int nBlendShapeSize = 0;
			if (settings.doBlendShapes)
			{
				nBlendShapeSize = c.blendShapes.Length + totalAddBlendShapes - totalDeleteBlendShapes;
			}
			if (lOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Verts adding:" + totalAddVerts + " deleting:" + totalDeleteVerts + " submeshes:" + numResultMats + " blendShapes:" + nBlendShapeSize);
			}
			int[] array2 = new int[numResultMats];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[i] + totalAddSubmeshTris[i] - totalDeleteSubmeshTris[i];
				if (lOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("    submesh :" + i + " already contains:" + array[i] + " tris to be Added:" + totalAddSubmeshTris[i] + " tris to be Deleted:" + totalDeleteSubmeshTris[i]);
				}
			}
			if (num2 >= MBVersion.MaxMeshVertexCount())
			{
				UnityEngine.Debug.LogError("Cannot add objects. Resulting mesh will have more than " + MBVersion.MaxMeshVertexCount() + " vertices. Try using a Multi-MeshBaker component. This will split the combined mesh into several meshes. You don't have to re-configure the MB2_TextureBaker. Just remove the MB2_MeshBaker component and add a MB2_MultiMeshBaker component.");
				return false;
			}
			IVertexAndTriangleProcessor vertexAndTriProcessor = c._vertexAndTriProcessor;
			vertexAndTriProcessor.Init(c, newChannels, num2, array2, uvChannelWithExtraParameter, meshChannelsCache, loadDataFromCombinedMesh: false, c.LOG_LEVEL);
			boneProcessor.AllocateAndSetupSMRDataStructures(toAddDGOs, mbDynamicObjectsInCombinedMesh, num2, c._vertexAndTriProcessor);
			blendShapeProcessor.AllocateBlendShapeArrayIfNecessary(nBlendShapeSize);
			c.db_addDeleteGameObjects_Init.Stop();
			if (lOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Allocating buffers: " + vertexAndTriProcessor.channels.ToString() + "  vertexCount:" + num2);
			}
			mbDynamicObjectsInCombinedMesh.Sort();
			int targBlendShapeIdx = 0;
			int num3 = 0;
			int[] array3 = new int[numResultMats];
			int num4 = 0;
			c.db_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers.Start();
			if (!settings.clearBuffersAfterBake && mbDynamicObjectsInCombinedMesh.Count > 0)
			{
				for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[j];
					if (!mB_DynamicGameObject._beingDeleted)
					{
						if (lOG_LEVEL >= MB2_LogLevel.debug)
						{
							MB2_Log.LogDebug("Copying obj in combined arrays idx:" + j, lOG_LEVEL);
						}
						vertexAndTriProcessor.CopyArraysFromPreviousBakeBuffersToNewBuffers(mB_DynamicGameObject, ref oldMeshData, num3, num4, array3, lOG_LEVEL);
						if (settings.doBlendShapes)
						{
							blendShapeProcessor.CopyBlendShapesInCurrentMeshIfNecessary(ref targBlendShapeIdx, mB_DynamicGameObject);
						}
						if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
						{
							boneProcessor.CopyBoneWeightsFromMeshForDGOsInCombined(mB_DynamicGameObject, num3);
						}
						mB_DynamicGameObject.vertIdx = num3;
						for (int k = 0; k < array3.Length; k++)
						{
							mB_DynamicGameObject.submeshTriIdxs[k] = array3[k];
							array3[k] += mB_DynamicGameObject.submeshNumTris[k];
						}
						num3 += mB_DynamicGameObject.numVerts;
					}
					else
					{
						if (lOG_LEVEL >= MB2_LogLevel.debug)
						{
							MB2_Log.LogDebug("Not copying obj: " + j, lOG_LEVEL);
						}
						num4 += mB_DynamicGameObject.numVerts;
					}
				}
				if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					boneProcessor.CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(totalDeleteVerts);
				}
				for (int num5 = mbDynamicObjectsInCombinedMesh.Count - 1; num5 >= 0; num5--)
				{
					if (mbDynamicObjectsInCombinedMesh[num5]._beingDeleted)
					{
						instance2Combined_MapRemove(ref _instance2combined_map, mbDynamicObjectsInCombinedMesh[num5].gameObject);
						objectsInCombinedMesh.RemoveAt(num5);
						mbDynamicObjectsInCombinedMesh.RemoveAt(num5);
					}
				}
			}
			c.db_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers.Stop();
			c.db_addDeleteGameObjects_CopyFromDGOMeshToBuffers.Start();
			if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				boneProcessor.InsertNewBonesIntoBonesArray();
			}
			for (int l = 0; l < toAddDGOs.Count; l++)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = toAddDGOs[l];
				GameObject gameObject = _goToAdd[l];
				int vertsIdx = num3;
				Mesh mesh = mB_DynamicGameObject2._mesh;
				bool updateBWdata = false;
				vertexAndTriProcessor.CopyFromDGOMeshToBuffers(mB_DynamicGameObject2, num3, vertexAndTriProcessor.channels, updateTris: true, updateBWdata, settings, boneProcessor, array3, textureBakeResults, uvAdjuster, lOG_LEVEL, meshChannelsCache);
				int subMeshCount = mesh.subMeshCount;
				if (mB_DynamicGameObject2.uvRects.Length < subMeshCount)
				{
					if (lOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("Mesh " + mB_DynamicGameObject2.name + " has more submeshes than materials");
					}
				}
				else if (mB_DynamicGameObject2.uvRects.Length > subMeshCount && lOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + mB_DynamicGameObject2.name + " has fewer submeshes than materials");
				}
				if (settings.doBlendShapes)
				{
					blendShapeProcessor.CopyBlendShapesForNewMeshIfNecessary(ref targBlendShapeIdx, mB_DynamicGameObject2, mesh, meshChannelsCache);
				}
				if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					boneProcessor.AddBonesToNewBonesArrayAndAdjustBWIndexes1(mB_DynamicGameObject2, vertsIdx);
				}
				mB_DynamicGameObject2.vertIdx = num3;
				instance2Combined_MapAdd(ref _instance2combined_map, gameObject, mB_DynamicGameObject2);
				objectsInCombinedMesh.Add(gameObject);
				mbDynamicObjectsInCombinedMesh.Add(mB_DynamicGameObject2);
				num3 += mB_DynamicGameObject2.numVerts;
				for (int m = 0; m < mB_DynamicGameObject2._tmpSubmeshTris.Length; m++)
				{
					mB_DynamicGameObject2._tmpSubmeshTris[m] = null;
				}
				mB_DynamicGameObject2._tmpSubmeshTris = null;
				if (lOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Added to combined:" + mB_DynamicGameObject2.name + " verts:" + vertexAndTriProcessor.GetVertexCount() + " bindPoses:" + boneProcessor.GetNewBonesSize(), lOG_LEVEL);
				}
			}
			if (settings.lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects)
			{
				vertexAndTriProcessor.CopyUV2unchangedToSeparateRects(mbDynamicObjectsInCombinedMesh, settings.uv2UnwrappingParamsPackMargin);
			}
			if (lOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("===== _addToCombined completed. Verts in buffer: " + vertexAndTriProcessor.GetVertexCount() + " time(ms): " + sw.ElapsedMilliseconds, lOG_LEVEL);
			}
			c.db_addDeleteGameObjects_CopyFromDGOMeshToBuffers.Stop();
			return true;
		}

		public static bool _UpdateGameObjects(MB3_MeshCombinerSingle combiner, List<MB_DynamicGameObject> dgosToUpdate, MB_MeshVertexChannelFlags newChannels, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo, UVAdjuster_Atlas uVAdjuster, MB2_LogLevel LOG_LEVEL)
		{
			IMeshChannelsCacheTaggingInterface meshChannelsCache = combiner._meshChannelsCache;
			MB_IMeshBakerSettings settings = combiner.settings;
			IVertexAndTriangleProcessor vertexAndTriProcessor = combiner._vertexAndTriProcessor;
			vertexAndTriProcessor.Init(uvChannelWithExtraParameter: (combiner.settings.assignToMeshCustomizer == null || !(combiner.settings.assignToMeshCustomizer is IAssignToMeshCustomizer_NativeArrays)) ? (-1) : ((IAssignToMeshCustomizer_NativeArrays)combiner.settings.assignToMeshCustomizer).UVchannelWithExtraParameter(), combiner: combiner, newChannels: newChannels, vertexCount: combiner._mesh.vertexCount, newSubmeshTrisSize: new int[0], meshChannelsCache: combiner._meshChannelsCache, loadDataFromCombinedMesh: true, logLevel: LOG_LEVEL);
			if (settings.renderType == MB_RenderType.skinnedMeshRenderer && updateSkinningInfo)
			{
				combiner._boneProcessor.UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh();
			}
			MB_MeshVertexChannelFlags channelsToUpdate = (MB_MeshVertexChannelFlags)((updateVertices ? 1 : 0) | (updateNormals ? 2 : 0) | (updateTangents ? 4 : 0) | (updateColors ? 8 : 0) | (updateUV ? 16 : 0) | (updateUV2 ? 64 : 0) | (updateUV3 ? 128 : 0) | (updateUV4 ? 256 : 0) | (updateUV5 ? 512 : 0) | (updateUV6 ? 1024 : 0) | (updateUV7 ? 2048 : 0) | (updateUV8 ? 4096 : 0));
			for (int i = 0; i < dgosToUpdate.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = dgosToUpdate[i];
				bool updateBWdata = settings.renderType == MB_RenderType.skinnedMeshRenderer && updateSkinningInfo;
				vertexAndTriProcessor.CopyFromDGOMeshToBuffers(mB_DynamicGameObject, mB_DynamicGameObject.vertIdx, channelsToUpdate, updateTris: false, updateBWdata, settings, combiner._boneProcessor, null, combiner.textureBakeResults, uVAdjuster, LOG_LEVEL, meshChannelsCache);
				mB_DynamicGameObject.UnInitialize();
			}
			combiner._bakeStatus = MeshCombiningStatus.readyForApply;
			if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				((SkinnedMeshRenderer)combiner.targetRenderer).sharedMesh = null;
				((SkinnedMeshRenderer)combiner.targetRenderer).sharedMesh = combiner._mesh;
			}
			return true;
		}

		public static bool Apply(MB3_MeshCombinerSingle combiner, GenerateUV2Delegate uv2GenerationMethod)
		{
			MB_IMeshBakerSettings settings = combiner.settings;
			bool bones = false;
			if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				bones = true;
			}
			return Apply(combiner, triangles: true, vertices: true, settings.doNorm, settings.doTan, settings.doUV, MeshBakerSettingsUtility.DoUV2getDataFromSourceMeshes(ref settings), settings.doUV3, settings.doUV4, settings.doUV5, settings.doUV6, settings.doUV7, settings.doUV8, settings.doCol, bones, settings.doBlendShapes, suppressClearMesh: false, uv2GenerationMethod);
		}

		public static bool Apply(MB3_MeshCombinerSingle combiner, bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
		{
			return Apply(combiner, triangles, vertices, normals, tangents, uvs, uv2, uv3, uv4, uv5: false, uv6: false, uv7: false, uv8: false, colors, bones, blendShapesFlag, suppressClearMesh: false, uv2GenerationMethod);
		}

		internal static bool Apply(MB3_MeshCombinerSingle combiner, bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapesFlag = false, bool suppressClearMesh = false, GenerateUV2Delegate uv2GenerationMethod = null)
		{
			MB2_LogLevel lOG_LEVEL = combiner.LOG_LEVEL;
			MB2_ValidationLevel validationLevel = combiner._validationLevel;
			MB_IMeshBakerSettings settings = combiner.settings;
			bool flag = false;
			if (bones && combiner._boneProcessor == null)
			{
				UnityEngine.Debug.LogError("Apply was called with 'bones = true', but the meshCombiner did not contain valid bone data. Was AddDelete(...), Update(...) or ShowHide() called with 'renderType = skinnedMeshRenderer'?");
				flag = true;
			}
			if (validationLevel >= MB2_ValidationLevel.quick && !combiner.ValidateTargRendererAndMeshAndResultSceneObj())
			{
				flag = true;
			}
			if (combiner._bakeStatus != MeshCombiningStatus.readyForApply)
			{
				UnityEngine.Debug.LogError("Apply was called when combiner was not in 'readyForApply' state. Did you call AddDelete(), Update() or ShowHide()");
				flag = true;
			}
			if (combiner._vertexAndTriProcessor != null && combiner._vertexAndTriProcessor.IsDisposed() && combiner._vertexAndTriProcessor.IsInitialized())
			{
				UnityEngine.Debug.LogError("Apply was called with bad meshDataBuffer");
				flag = true;
			}
			if (flag)
			{
				return false;
			}
			Mesh mesh = combiner._mesh;
			Renderer targetRenderer = combiner.targetRenderer;
			MB2_TextureBakeResults textureBakeResults = combiner._textureBakeResults;
			MB2_TextureBakeResults textureBakeResults2 = combiner.textureBakeResults;
			Stopwatch stopwatch = null;
			if (lOG_LEVEL >= MB2_LogLevel.debug)
			{
				stopwatch = new Stopwatch();
				stopwatch.Start();
			}
			if (mesh != null)
			{
				IVertexAndTriangleProcessor vertexAndTriProcessor = combiner._vertexAndTriProcessor;
				if (lOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Apply called:\n tri={triangles}\n vert={vertices}\n norm={normals}\n tan={tangents}\n uv={uvs}\n col={colors}\n uv3={uv3}\n uv4={uv4}\n uv2={uv2}\n bone={bones}\n blendShape{blendShapesFlag}\n meshID={mesh.GetInstanceID()}\n");
				}
				if (!suppressClearMesh && (triangles || mesh.vertexCount != vertexAndTriProcessor.GetVertexCount()))
				{
					bool justClearTriangles = triangles && !vertices && !normals && !tangents && !uvs && !colors && !uv3 && !uv4 && !uv2 && !bones;
					MBVersion.SetMeshIndexFormatAndClearMesh(mesh, vertexAndTriProcessor.GetVertexCount(), vertices, justClearTriangles);
				}
				MB_MeshVertexChannelFlags mB_MeshVertexChannelFlags = MB_MeshVertexChannelFlags.none;
				bool flag2 = false;
				if (vertices)
				{
					mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.vertex;
				}
				if (triangles && (bool)textureBakeResults)
				{
					if (textureBakeResults == null)
					{
						UnityEngine.Debug.LogError("Texture Bake Result was not set.");
					}
					else
					{
						flag2 = true;
					}
				}
				if (normals)
				{
					if (settings.doNorm)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.normal;
					}
					else
					{
						UnityEngine.Debug.LogError("normal flag was set in Apply but MeshBaker didn't generate normals");
					}
				}
				if (tangents)
				{
					if (settings.doTan)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.tangent;
					}
					else
					{
						UnityEngine.Debug.LogError("tangent flag was set in Apply but MeshBaker didn't generate tangents");
					}
				}
				if (colors)
				{
					if (settings.doCol)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.colors;
					}
					else
					{
						UnityEngine.Debug.LogError("color flag was set in Apply but MeshBaker didn't generate colors");
					}
				}
				if (uvs)
				{
					if (settings.doUV)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv0;
					}
					else
					{
						UnityEngine.Debug.LogError("uv flag was set in Apply but MeshBaker didn't generate uvs");
					}
				}
				if (uv2)
				{
					if (MeshBakerSettingsUtility.DoUV2getDataFromSourceMeshes(ref settings))
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv2;
					}
					else
					{
						UnityEngine.Debug.LogError("uv2 flag was set in Apply but lightmapping option was set to " + settings.lightmapOption);
					}
				}
				if (uv3)
				{
					if (settings.doUV3)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv3;
					}
					else
					{
						UnityEngine.Debug.LogError("uv3 flag was set in Apply but MeshBaker didn't generate uv3s");
					}
				}
				if (uv4)
				{
					if (settings.doUV4)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv4;
					}
					else
					{
						UnityEngine.Debug.LogError("uv4 flag was set in Apply but MeshBaker didn't generate uv4s");
					}
				}
				if (uv5)
				{
					if (settings.doUV5)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv5;
					}
					else
					{
						UnityEngine.Debug.LogError("uv5 flag was set in Apply but MeshBaker didn't generate uv5s");
					}
				}
				if (uv6)
				{
					if (settings.doUV6)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv6;
					}
					else
					{
						UnityEngine.Debug.LogError("uv6 flag was set in Apply but MeshBaker didn't generate uv6s");
					}
				}
				if (uv7)
				{
					if (settings.doUV7)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv7;
					}
					else
					{
						UnityEngine.Debug.LogError("uv7 flag was set in Apply but MeshBaker didn't generate uv7s");
					}
				}
				if (uv8)
				{
					if (settings.doUV8)
					{
						mB_MeshVertexChannelFlags |= MB_MeshVertexChannelFlags.uv8;
					}
					else
					{
						UnityEngine.Debug.LogError("uv8 flag was set in Apply but MeshBaker didn't generate uv8s");
					}
				}
				if (bones)
				{
					combiner._boneProcessor.ApplySMRdataToMeshToBuffer();
				}
				vertexAndTriProcessor.AssignBuffersToMesh(mesh, settings, textureBakeResults2, mB_MeshVertexChannelFlags, flag2, settings.assignToMeshCustomizer, combiner.mbDynamicObjectsInCombinedMesh, out var serializableBufferData, out var submeshTrisToUse, out var numNonZeroLengthSubmeshes);
				vertexAndTriProcessor.TransferOwnershipOfSerializableBuffersToCombiner(combiner, vertexAndTriProcessor.channels, serializableBufferData);
				vertexAndTriProcessor.Dispose();
				if ((mB_MeshVertexChannelFlags & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
				{
					targetRenderer.transform.position = serializableBufferData.meshVerticesShift;
				}
				if (flag2)
				{
					_UpdateMaterialsOnTargetRenderer(combiner.textureBakeResults, combiner.targetRenderer, submeshTrisToUse, numNonZeroLengthSubmeshes);
				}
				bool flag3 = false;
				if (settings.renderType != MB_RenderType.skinnedMeshRenderer && settings.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
				{
					if (uv2GenerationMethod != null)
					{
						uv2GenerationMethod(mesh, settings.uv2UnwrappingParamsHardAngle, settings.uv2UnwrappingParamsPackMargin);
						if (lOG_LEVEL >= MB2_LogLevel.trace)
						{
							UnityEngine.Debug.Log("generating new UV2 layout for the combined mesh ");
						}
					}
					else
					{
						UnityEngine.Debug.LogError("No GenerateUV2Delegate method was supplied. UV2 cannot be generated.");
					}
					flag3 = true;
				}
				else if (settings.renderType == MB_RenderType.skinnedMeshRenderer && settings.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout && lOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("UV2 cannot be generated for SkinnedMeshRenderer objects.");
				}
				if (settings.renderType != MB_RenderType.skinnedMeshRenderer && settings.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout && !flag3)
				{
					UnityEngine.Debug.LogError("Failed to generate new UV2 layout. Only works in editor.");
				}
				if (bones)
				{
					combiner._boneProcessor.ApplySMRdataToMesh(combiner, mesh);
					combiner._boneProcessor.Dispose();
					combiner._boneProcessor = null;
				}
				if (blendShapesFlag)
				{
					combiner._blendShapeProcessor.AssignNewBlendShapesToCombinerIfNecessary();
					if (settings.smrMergeBlendShapesWithSameNames)
					{
						combiner._blendShapeProcessor.ApplyBlendShapeFramesToMeshAndBuildMap_MergeBlendShapesWithTheSameName(combiner._mesh.vertexCount);
					}
					else
					{
						combiner._blendShapeProcessor.ApplyBlendShapeFramesToMeshAndBuildMap(combiner._mesh.vertexCount);
					}
					combiner._blendShapeProcessor.Dispose();
					combiner._blendShapeProcessor = null;
				}
				if (triangles || vertices)
				{
					if (lOG_LEVEL >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log("recalculating bounds on mesh.");
					}
					mesh.RecalculateBounds();
				}
				if (settings.optimizeAfterBake && !Application.isPlaying)
				{
					MBVersion.OptimizeMesh(mesh);
				}
				combiner._SetLightmapIndexIfPreserveLightmapping(targetRenderer);
				if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					if (combiner._mesh.vertexCount == 0)
					{
						if (lOG_LEVEL >= MB2_LogLevel.debug)
						{
							UnityEngine.Debug.Log(" combined mesh had zero vertices. Disabling combined SkinnedMeshRenderer.");
						}
						targetRenderer.enabled = false;
					}
					else
					{
						targetRenderer.enabled = true;
						SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)targetRenderer;
						bool updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
						skinnedMeshRenderer.updateWhenOffscreen = true;
						skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
						skinnedMeshRenderer.sharedMesh = null;
						skinnedMeshRenderer.sharedMesh = mesh;
						skinnedMeshRenderer.bones = combiner.bones;
						if (lOG_LEVEL >= MB2_LogLevel.debug)
						{
							UnityEngine.Debug.Log(" Applying bones and mesh to SkinnedMeshRenderer component  numbones: " + combiner.bones.Length);
						}
						MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(combiner.objectsInCombinedMesh, skinnedMeshRenderer);
					}
				}
				combiner._boneProcessor = null;
			}
			else
			{
				UnityEngine.Debug.LogError("Need to add objects to this meshbaker before calling Apply or ApplyAll");
			}
			if (lOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Apply Complete time: " + stopwatch.ElapsedMilliseconds + " vertices: " + mesh.vertexCount);
			}
			combiner._bakeStatus = MeshCombiningStatus.preAddDeleteOrUpdate;
			if (settings.clearBuffersAfterBake)
			{
				combiner.ClearBuffers();
			}
			return true;
		}

		public static bool ApplyShowHide(MB3_MeshCombinerSingle combiner)
		{
			MB_IMeshBakerSettings settings = combiner.settings;
			Renderer targetRenderer = combiner.targetRenderer;
			bool flag = false;
			if (combiner._bakeStatus != MeshCombiningStatus.readyForApply)
			{
				UnityEngine.Debug.LogError("Apply was called when combiner was not in 'readyForApply' state. Did you call AddDelete(), Update() or ShowHide()");
				flag = true;
			}
			if (combiner._vertexAndTriProcessor != null && combiner._vertexAndTriProcessor.IsDisposed() && combiner._vertexAndTriProcessor.IsInitialized())
			{
				UnityEngine.Debug.LogError("Apply was called with bad meshDataBuffer");
				flag = true;
			}
			if (flag)
			{
				return false;
			}
			IVertexAndTriangleProcessor vertexAndTriProcessor = combiner._vertexAndTriProcessor;
			BufferDataFromPreviousBake serializableBufferData = combiner.bufferDataFromPrevious;
			vertexAndTriProcessor.AssignTriangleDataForSubmeshes_ShowHide(combiner._mesh, combiner.mbDynamicObjectsInCombinedMesh, ref serializableBufferData, out var submeshTrisToUse, out var numNonZeroLengthSubmeshes);
			vertexAndTriProcessor.TransferOwnershipOfSerializableBuffersToCombiner(combiner, MB_MeshVertexChannelFlags.none, serializableBufferData);
			vertexAndTriProcessor.Dispose();
			_UpdateMaterialsOnTargetRenderer(combiner.textureBakeResults, combiner.targetRenderer, submeshTrisToUse, numNonZeroLengthSubmeshes);
			if (settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				if (combiner._mesh.vertexCount == 0)
				{
					if (combiner.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log(" combined mesh had zero vertices. Disabling combined SkinnedMeshRenderer.");
					}
					targetRenderer.enabled = false;
				}
				else
				{
					targetRenderer.enabled = true;
					SkinnedMeshRenderer skinnedMeshRenderer = (SkinnedMeshRenderer)targetRenderer;
					bool updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
					skinnedMeshRenderer.updateWhenOffscreen = true;
					skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
					skinnedMeshRenderer.sharedMesh = null;
					skinnedMeshRenderer.sharedMesh = combiner._mesh;
					skinnedMeshRenderer.bones = combiner.bones;
					if (combiner.LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log(" Applying bones and mesh to SkinnedMeshRenderer component  numbones: " + combiner.bones.Length);
					}
					MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(combiner.objectsInCombinedMesh, skinnedMeshRenderer);
				}
			}
			if (combiner.LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("ApplyShowHide");
			}
			return true;
		}
	}

	public class UVAdjuster_Atlas
	{
		private MB2_TextureBakeResults textureBakeResults;

		private MB2_LogLevel LOG_LEVEL;

		private int[] numTimesMatAppearsInAtlas;

		private MB_MaterialAndUVRect[] matsAndSrcUVRect;

		private bool compareNamesWhenComparingMaterials;

		public UVAdjuster_Atlas(MB2_TextureBakeResults tbr, MB2_LogLevel ll)
		{
			textureBakeResults = tbr;
			LOG_LEVEL = ll;
			matsAndSrcUVRect = tbr.materialsAndUVRects;
			compareNamesWhenComparingMaterials = false;
			if (MBVersion.IsUsingAddressables() && Application.isPlaying)
			{
				compareNamesWhenComparingMaterials = true;
			}
			else
			{
				compareNamesWhenComparingMaterials = false;
			}
			numTimesMatAppearsInAtlas = new int[matsAndSrcUVRect.Length];
			for (int i = 0; i < matsAndSrcUVRect.Length; i++)
			{
				if (numTimesMatAppearsInAtlas[i] > 1)
				{
					continue;
				}
				int num = 1;
				for (int j = i + 1; j < matsAndSrcUVRect.Length; j++)
				{
					if (matsAndSrcUVRect[i].material == matsAndSrcUVRect[j].material)
					{
						num++;
					}
				}
				numTimesMatAppearsInAtlas[i] = num;
				if (num <= 1)
				{
					continue;
				}
				for (int k = i + 1; k < matsAndSrcUVRect.Length; k++)
				{
					if (matsAndSrcUVRect[i].material == matsAndSrcUVRect[k].material)
					{
						numTimesMatAppearsInAtlas[k] = num;
					}
				}
			}
		}

		public bool MapSharedMaterialsToAtlasRects(Material[] sharedMaterials, bool checkTargetSubmeshIdxsFromPreviousBake, Mesh m, IMeshChannelsCacheTaggingInterface meshChannelsCache, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache, OrderedDictionary sourceMats2submeshIdx_map, GameObject go, MB_DynamicGameObject dgoOut)
		{
			MB_TextureTilingTreatment[] array = new MB_TextureTilingTreatment[sharedMaterials.Length];
			Rect[] array2 = new Rect[sharedMaterials.Length];
			Rect[] array3 = new Rect[sharedMaterials.Length];
			Rect[] array4 = new Rect[sharedMaterials.Length];
			int[] array5 = new int[sharedMaterials.Length];
			string errorMsg = "";
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				object obj = null;
				foreach (DictionaryEntry item in sourceMats2submeshIdx_map)
				{
					if (IsSameMaterialInTextureBakeResult(sharedMaterials[i], (Material)item.Key))
					{
						obj = (int)item.Value;
					}
				}
				if (obj == null)
				{
					UnityEngine.Debug.LogError("Source object " + go.name + " used a material " + sharedMaterials[i]?.ToString() + " that was not in the baked materials.");
					if (sharedMaterials[i].name.Contains("(Instance)"))
					{
						UnityEngine.Debug.LogError("The material may be a duplicate of a material that was baked. Materials on a Renderer can be duplicated if the .material field is accessed by a script.");
					}
					return false;
				}
				int num = (int)obj;
				if (checkTargetSubmeshIdxsFromPreviousBake && num != dgoOut.targetSubmeshIdxs[i])
				{
					UnityEngine.Debug.LogError($"Update failed for object {go.name}. Material {sharedMaterials[i]} is mapped to a different submesh in the combined mesh than the previous material. This is not supported. Try using AddDelete.");
					return false;
				}
				if (!TryMapMaterialToUVRect(sharedMaterials[i], m, i, num, meshChannelsCache, meshAnalysisResultsCache, out array[i], out array2[i], out array3[i], out array4[i], out array5[i], ref errorMsg, LOG_LEVEL))
				{
					UnityEngine.Debug.LogError(errorMsg);
					return false;
				}
			}
			dgoOut.uvRects = array2;
			dgoOut.encapsulatingRect = array3;
			dgoOut.sourceMaterialTiling = array4;
			dgoOut.textureArraySliceIdx = array5;
			return true;
		}

		public bool IsSameMaterialInTextureBakeResult(Material a, Material b)
		{
			if (a == b)
			{
				return true;
			}
			if (compareNamesWhenComparingMaterials && a != null && b != null && a.name.Equals(b.name))
			{
				return true;
			}
			return false;
		}

		public bool TryMapMaterialToUVRect(Material mat, Mesh m, int submeshIdx, int idxInResultMats, IMeshChannelsCacheTaggingInterface meshChannelCache, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisCache, out MB_TextureTilingTreatment tilingTreatment, out Rect rectInAtlas, out Rect encapsulatingRectOut, out Rect sourceMaterialTilingOut, out int sliceIdx, ref string errorMsg, MB2_LogLevel logLevel)
		{
			if (textureBakeResults.version < MB2_TextureBakeResults.VERSION)
			{
				textureBakeResults.UpgradeToCurrentVersion(textureBakeResults);
			}
			tilingTreatment = MB_TextureTilingTreatment.unknown;
			if (textureBakeResults.materialsAndUVRects.Length == 0)
			{
				errorMsg = "The 'Texture Bake Result' needs to be re-baked to be compatible with this version of Mesh Baker. Please re-bake using the MB3_TextureBaker.";
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				sliceIdx = -1;
				return false;
			}
			if (mat == null)
			{
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				sliceIdx = -1;
				errorMsg = $"Mesh {m.name} Had no material on submesh {submeshIdx} cannot map to a material in the atlas";
				return false;
			}
			if (submeshIdx >= m.subMeshCount)
			{
				errorMsg = "Submesh index is greater than the number of submeshes";
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				sliceIdx = -1;
				return false;
			}
			int num = -1;
			for (int i = 0; i < matsAndSrcUVRect.Length; i++)
			{
				if (IsSameMaterialInTextureBakeResult(mat, matsAndSrcUVRect[i].material))
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				rectInAtlas = default(Rect);
				encapsulatingRectOut = default(Rect);
				sourceMaterialTilingOut = default(Rect);
				sliceIdx = -1;
				errorMsg = $"Material {mat.name} could not be found in the Texture Bake Result";
				return false;
			}
			if (!textureBakeResults.GetConsiderMeshUVs(idxInResultMats, mat))
			{
				if (numTimesMatAppearsInAtlas[num] != 1)
				{
					UnityEngine.Debug.LogError("There is a problem with this TextureBakeResults. FixOutOfBoundsUVs is false and a material appears more than once: " + matsAndSrcUVRect[num].material?.ToString() + " appears: " + numTimesMatAppearsInAtlas[num]);
				}
				MB_MaterialAndUVRect mB_MaterialAndUVRect = matsAndSrcUVRect[num];
				rectInAtlas = mB_MaterialAndUVRect.atlasRect;
				tilingTreatment = mB_MaterialAndUVRect.tilingTreatment;
				encapsulatingRectOut = mB_MaterialAndUVRect.GetEncapsulatingRect();
				sourceMaterialTilingOut = mB_MaterialAndUVRect.GetMaterialTilingRect();
				sliceIdx = mB_MaterialAndUVRect.textureArraySliceIdx;
				return true;
			}
			if (!meshAnalysisCache.TryGetValue(m.GetInstanceID(), out var value))
			{
				value = new MB_Utility.MeshAnalysisResult[m.subMeshCount];
				for (int j = 0; j < m.subMeshCount; j++)
				{
					meshChannelCache.hasOutOfBoundsUVs(m, ref value[j], j);
				}
				meshAnalysisCache.Add(m.GetInstanceID(), value);
			}
			bool flag = false;
			Rect rect = new Rect(0f, 0f, 0f, 0f);
			Rect rect2 = new Rect(0f, 0f, 0f, 0f);
			if (logLevel >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log(string.Format("Trying to find a rectangle in atlas capable of holding tiled sampling rect for mesh {0} using material {1} meshUVrect={2}", m, mat, value[submeshIdx].uvRect.ToString("f5")));
			}
			for (int k = num; k < matsAndSrcUVRect.Length; k++)
			{
				MB_MaterialAndUVRect mB_MaterialAndUVRect2 = matsAndSrcUVRect[k];
				if (!IsSameMaterialInTextureBakeResult(mat, mB_MaterialAndUVRect2.material))
				{
					continue;
				}
				if (mB_MaterialAndUVRect2.allPropsUseSameTiling)
				{
					rect = mB_MaterialAndUVRect2.allPropsUseSameTiling_samplingEncapsulatinRect;
					rect2 = mB_MaterialAndUVRect2.allPropsUseSameTiling_sourceMaterialTiling;
				}
				else
				{
					rect = mB_MaterialAndUVRect2.propsUseDifferntTiling_srcUVsamplingRect;
					rect2 = new Rect(0f, 0f, 1f, 1f);
				}
				if (MB2_TextureBakeResults.IsMeshAndMaterialRectEnclosedByAtlasRect(mB_MaterialAndUVRect2.tilingTreatment, value[submeshIdx].uvRect, rect2, rect, logLevel))
				{
					if (logLevel >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log("Found rect in atlas capable of containing tiled sampling rect for mesh " + m?.ToString() + " at idx=" + k);
					}
					num = k;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				MB_MaterialAndUVRect mB_MaterialAndUVRect3 = matsAndSrcUVRect[num];
				rectInAtlas = mB_MaterialAndUVRect3.atlasRect;
				tilingTreatment = mB_MaterialAndUVRect3.tilingTreatment;
				encapsulatingRectOut = mB_MaterialAndUVRect3.GetEncapsulatingRect();
				sourceMaterialTilingOut = mB_MaterialAndUVRect3.GetMaterialTilingRect();
				sliceIdx = mB_MaterialAndUVRect3.textureArraySliceIdx;
				return true;
			}
			rectInAtlas = default(Rect);
			encapsulatingRectOut = default(Rect);
			sourceMaterialTilingOut = default(Rect);
			sliceIdx = -1;
			errorMsg = $"Objects To Be Combined mesh {m.name} uses material {mat} on submesh {submeshIdx}. This material requires a rectangle in the atlas that tiles the texture {value[submeshIdx].uvRect.ToString()}. However, MeshBaker could not find a rectangle in the atlas that can contain this tiled rectangle.\n\nTo explain in greater detail, suppose there are two meshes:\n\n - A single-brick mesh that uses a small UV rectangle in a brick-wall.png texture.\n - A brick-wall mesh that tiles the same brick-wall.png texture three times.\n\nIf TextureBaker is used to bake a texture atlas that includes only the single-brick mesh (NOT the brick-wall mesh) and the \"considerUVs\" feature is used, then the TextureBaker will copy only the small UV rectangle (the single brick) with the brick-wall.png texture to the texture atlas.\n\nTHE PROBLEM: If one now attempts to use the same atlas in a MeshBaker-bake with the brick-wall-mesh, this will not work because the brick-wall mesh requires more of the brick-wall.png texture than was copied to the atlas. The brick-wall mesh needs the entire brick-wall.png texture tiled three times.\n\nTHE SOLUTION: To resolve this issue, both the \"single-brick mesh\" and the \"brick-wall mesh\" in the original texture bake, then the TextureBaker will copy the entire brick-wall.png to the atlas tiled three times. This atlas rectangle will work for both the single-brick mesh and the brick-wall mesh.";
			return false;
		}
	}

	public struct VertexAndTriangleProcessor : IVertexAndTriangleProcessor, IDisposable
	{
		private bool _disposed;

		private bool _isInitialized;

		internal MB2_LogLevel LOG_LEVEL;

		private Vector3[] verticies;

		private Vector3[] normals;

		private Vector4[] tangents;

		private Color[] colors;

		private Vector2[] uv0s;

		private float[] uvsSliceIdx;

		private Vector2[] uv2s;

		private Vector2[] uv3s;

		private Vector2[] uv4s;

		private Vector2[] uv5s;

		private Vector2[] uv6s;

		private Vector2[] uv7s;

		private Vector2[] uv8s;

		private SerializableIntArray[] submeshTris;

		public MB_MeshVertexChannelFlags channels { get; private set; }

		public void Dispose()
		{
			if (!_disposed)
			{
				_isInitialized = false;
				channels = MB_MeshVertexChannelFlags.none;
				verticies = null;
				normals = null;
				tangents = null;
				colors = null;
				uv0s = null;
				uvsSliceIdx = null;
				uv2s = null;
				uv3s = null;
				uv4s = null;
				uv5s = null;
				uv6s = null;
				uv7s = null;
				uv8s = null;
				submeshTris = null;
				_disposed = true;
			}
		}

		public bool IsInitialized()
		{
			return _isInitialized;
		}

		public bool IsDisposed()
		{
			return _disposed;
		}

		public void Init(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int vertexCount, int[] newSubmeshTrisSize, int uvChannelWithExtraParameter, IMeshChannelsCacheTaggingInterface meshChannelsCache, bool loadDataFromCombinedMesh, MB2_LogLevel logLevel)
		{
			if (loadDataFromCombinedMesh)
			{
				InitFromMeshCombiner(combiner, newChannels, uvChannelWithExtraParameter);
			}
			else
			{
				channels = newChannels;
				if ((channels & MB_MeshVertexChannelFlags.vertex) != MB_MeshVertexChannelFlags.none)
				{
					verticies = new Vector3[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.normal) != MB_MeshVertexChannelFlags.none)
				{
					normals = new Vector3[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.tangent) != MB_MeshVertexChannelFlags.none)
				{
					tangents = new Vector4[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.colors) != MB_MeshVertexChannelFlags.none)
				{
					colors = new Color[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv0) != MB_MeshVertexChannelFlags.none)
				{
					uv0s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.nuvsSliceIdx) != MB_MeshVertexChannelFlags.none)
				{
					uvsSliceIdx = new float[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv2) != MB_MeshVertexChannelFlags.none)
				{
					uv2s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv3) != MB_MeshVertexChannelFlags.none)
				{
					uv3s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv4) != MB_MeshVertexChannelFlags.none)
				{
					uv4s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv5) != MB_MeshVertexChannelFlags.none)
				{
					uv5s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv6) != MB_MeshVertexChannelFlags.none)
				{
					uv6s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv7) != MB_MeshVertexChannelFlags.none)
				{
					uv7s = new Vector2[vertexCount];
				}
				if ((channels & MB_MeshVertexChannelFlags.uv8) != MB_MeshVertexChannelFlags.none)
				{
					uv8s = new Vector2[vertexCount];
				}
				submeshTris = new SerializableIntArray[newSubmeshTrisSize.Length];
				for (int i = 0; i < newSubmeshTrisSize.Length; i++)
				{
					submeshTris[i] = new SerializableIntArray(newSubmeshTrisSize[i]);
				}
			}
			_isInitialized = true;
		}

		public void InitShowHide(MB3_MeshCombinerSingle combiner)
		{
			channels = MB_MeshVertexChannelFlags.none;
			submeshTris = combiner.submeshTris;
			_isInitialized = true;
		}

		public void InitFromMeshCombiner(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int uvChannelWithExtraParameter)
		{
			if (combiner.channelsLastBake != newChannels)
			{
				if (combiner.channelsLastBake == MB_MeshVertexChannelFlags.none && combiner.verts.Length != 0)
				{
					combiner.channelsLastBake = newChannels;
				}
				else
				{
					UnityEngine.Debug.LogError("Shouldn't change channels between bakes. \n" + combiner.channelsLastBake.ToString() + " \n" + newChannels);
				}
			}
			channels = combiner.channelsLastBake;
			if ((channels & MB_MeshVertexChannelFlags.vertex) != MB_MeshVertexChannelFlags.none)
			{
				verticies = combiner.verts;
			}
			if ((channels & MB_MeshVertexChannelFlags.normal) != MB_MeshVertexChannelFlags.none)
			{
				normals = combiner.normals;
			}
			if ((channels & MB_MeshVertexChannelFlags.tangent) != MB_MeshVertexChannelFlags.none)
			{
				tangents = combiner.tangents;
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) != MB_MeshVertexChannelFlags.none)
			{
				colors = combiner.colors;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) != MB_MeshVertexChannelFlags.none)
			{
				uv0s = combiner.uvs;
			}
			if ((channels & MB_MeshVertexChannelFlags.nuvsSliceIdx) != MB_MeshVertexChannelFlags.none)
			{
				uvsSliceIdx = combiner.uvsSliceIdx;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) != MB_MeshVertexChannelFlags.none)
			{
				uv2s = combiner.uv2s;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) != MB_MeshVertexChannelFlags.none)
			{
				uv3s = combiner.uv3s;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) != MB_MeshVertexChannelFlags.none)
			{
				uv4s = combiner.uv4s;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) != MB_MeshVertexChannelFlags.none)
			{
				uv5s = combiner.uv5s;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) != MB_MeshVertexChannelFlags.none)
			{
				uv6s = combiner.uv6s;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) != MB_MeshVertexChannelFlags.none)
			{
				uv7s = combiner.uv7s;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) != MB_MeshVertexChannelFlags.none)
			{
				uv8s = combiner.uv8s;
			}
			submeshTris = combiner.submeshTris;
			_isInitialized = true;
		}

		public int GetVertexCount()
		{
			return verticies.Length;
		}

		public int GetSubmeshCount()
		{
			return submeshTris.Length;
		}

		public void TransferOwnershipOfSerializableBuffersToCombiner(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags channelsToTransfer, BufferDataFromPreviousBake serializableBufferData)
		{
			c.channelsLastBake = channels;
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.vertex) != MB_MeshVertexChannelFlags.none)
			{
				c.verts = verticies;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.normal) != MB_MeshVertexChannelFlags.none)
			{
				c.normals = normals;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.tangent) != MB_MeshVertexChannelFlags.none)
			{
				c.tangents = tangents;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv0) != MB_MeshVertexChannelFlags.none)
			{
				c.uvs = uv0s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.nuvsSliceIdx) != MB_MeshVertexChannelFlags.none)
			{
				c.uvsSliceIdx = uvsSliceIdx;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv2) != MB_MeshVertexChannelFlags.none)
			{
				c.uv2s = uv2s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv3) != MB_MeshVertexChannelFlags.none)
			{
				c.uv3s = uv3s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv4) != MB_MeshVertexChannelFlags.none)
			{
				c.uv4s = uv4s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv5) != MB_MeshVertexChannelFlags.none)
			{
				c.uv5s = uv5s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv6) != MB_MeshVertexChannelFlags.none)
			{
				c.uv6s = uv6s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv7) != MB_MeshVertexChannelFlags.none)
			{
				c.uv7s = uv7s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.uv8) != MB_MeshVertexChannelFlags.none)
			{
				c.uv8s = uv8s;
			}
			if ((channelsToTransfer & MB_MeshVertexChannelFlags.colors) != MB_MeshVertexChannelFlags.none)
			{
				c.colors = colors;
			}
			c.submeshTris = submeshTris;
			c.bufferDataFromPrevious = serializableBufferData;
			verticies = null;
			normals = null;
			tangents = null;
			uv0s = null;
			uvsSliceIdx = null;
			uv2s = null;
			uv3s = null;
			uv4s = null;
			uv5s = null;
			uv6s = null;
			uv7s = null;
			uv8s = null;
			colors = null;
			submeshTris = null;
			_isInitialized = false;
		}

		public void CopyArraysFromPreviousBakeBuffersToNewBuffers(MB_DynamicGameObject dgo, ref IVertexAndTriangleProcessor iOldBuffers, int destStartVertIdx, int triangleIdxAdjustment, int[] targSubmeshTidx, MB2_LogLevel LOG_LEVEL)
		{
			VertexAndTriangleProcessor vertexAndTriangleProcessor = (VertexAndTriangleProcessor)(object)iOldBuffers;
			int vertIdx = dgo.vertIdx;
			int numVerts = dgo.numVerts;
			if ((channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				Array.Copy(vertexAndTriangleProcessor.verticies, vertIdx, verticies, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				Array.Copy(vertexAndTriangleProcessor.normals, vertIdx, normals, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				Array.Copy(vertexAndTriangleProcessor.tangents, vertIdx, tangents, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				Array.Copy(vertexAndTriangleProcessor.uv0s, vertIdx, uv0s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.nuvsSliceIdx) == MB_MeshVertexChannelFlags.nuvsSliceIdx)
			{
				Array.Copy(vertexAndTriangleProcessor.uvsSliceIdx, vertIdx, uvsSliceIdx, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				Array.Copy(vertexAndTriangleProcessor.uv2s, vertIdx, uv2s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				Array.Copy(vertexAndTriangleProcessor.uv3s, vertIdx, uv3s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				Array.Copy(vertexAndTriangleProcessor.uv4s, vertIdx, uv4s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				Array.Copy(vertexAndTriangleProcessor.uv5s, vertIdx, uv5s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				Array.Copy(vertexAndTriangleProcessor.uv6s, vertIdx, uv6s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				Array.Copy(vertexAndTriangleProcessor.uv7s, vertIdx, uv7s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				Array.Copy(vertexAndTriangleProcessor.uv8s, vertIdx, uv8s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				Array.Copy(vertexAndTriangleProcessor.colors, vertIdx, colors, destStartVertIdx, numVerts);
			}
			for (int i = 0; i < submeshTris.Length; i++)
			{
				int[] data = vertexAndTriangleProcessor.submeshTris[i].data;
				int num = dgo.submeshTriIdxs[i];
				int num2 = dgo.submeshNumTris[i];
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("    Adjusting submesh triangles submesh:" + i + " startIdx:" + num + " num:" + num2 + " nsubmeshTris:" + submeshTris.Length + " targSubmeshTidx:" + targSubmeshTidx.Length, LOG_LEVEL);
				}
				for (int j = num; j < num + num2; j++)
				{
					data[j] -= triangleIdxAdjustment;
				}
				Array.Copy(data, num, submeshTris[i].data, targSubmeshTidx[i], num2);
			}
		}

		public void CopyFromDGOMeshToBuffers(MB_DynamicGameObject dgo, int destStartVertsIdx, MB_MeshVertexChannelFlags channelsToUpdate, bool updateTris, bool updateBWdata, MB_IMeshBakerSettings settings, MB_IMeshCombinerSingle_BoneProcessor boneProcessor, int[] targSubmeshTidx, MB2_TextureBakeResults textureBakeResults, UVAdjuster_Atlas uvAdjuster, MB2_LogLevel LOG_LEVEL, IMeshChannelsCacheTaggingInterface meshChannelCacheParam)
		{
			MeshChannelsCache meshChannelsCache = (MeshChannelsCache)meshChannelCacheParam;
			bool flag = (channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex && (channelsToUpdate & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex;
			bool flag2 = (channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal && (channelsToUpdate & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal;
			bool flag3 = (channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent && (channelsToUpdate & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent;
			if (flag || flag2 || flag3)
			{
				Vector3[] array = null;
				Vector3[] array2 = null;
				Vector4[] array3 = null;
				if (flag)
				{
					array = meshChannelsCache.GetVertices(dgo._mesh);
				}
				if (flag2)
				{
					array2 = meshChannelsCache.GetNormals(dgo._mesh);
				}
				if (flag3)
				{
					array3 = meshChannelsCache.GetTangents(dgo._mesh);
				}
				if (settings.renderType != MB_RenderType.skinnedMeshRenderer)
				{
					_LocalToWorld(dgo.gameObject.transform, flag2, flag3, destStartVertsIdx, array, array2, array3, verticies, normals, tangents);
				}
				else
				{
					boneProcessor.CopyVertsNormsTansToBuffers(dgo, settings, destStartVertsIdx, array2, array3, array, normals, tangents, verticies);
				}
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				_copyAndAdjustUVsFromMesh(textureBakeResults, dgo, dgo._mesh, 0, destStartVertsIdx, uv0s, uvsSliceIdx, meshChannelsCache, LOG_LEVEL, textureBakeResults);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				_CopyAndAdjustUV2FromMesh(settings, meshChannelsCache, dgo, destStartVertsIdx, LOG_LEVEL);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				meshChannelsCache.GetUVChannel(3, dgo._mesh).CopyTo(uv3s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				meshChannelsCache.GetUVChannel(4, dgo._mesh).CopyTo(uv4s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				meshChannelsCache.GetUVChannel(5, dgo._mesh).CopyTo(uv5s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				meshChannelsCache.GetUVChannel(6, dgo._mesh).CopyTo(uv6s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				meshChannelsCache.GetUVChannel(7, dgo._mesh).CopyTo(uv7s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				meshChannelsCache.GetUVChannel(8, dgo._mesh).CopyTo(uv8s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors && (channelsToUpdate & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				meshChannelsCache.GetColors(dgo._mesh).CopyTo(colors, destStartVertsIdx);
			}
			if (updateBWdata)
			{
				boneProcessor.UpdateGameObjects_UpdateBWIndexes(dgo);
			}
			if (!updateTris)
			{
				return;
			}
			for (int i = 0; i < targSubmeshTidx.Length; i++)
			{
				dgo.submeshTriIdxs[i] = targSubmeshTidx[i];
			}
			for (int j = 0; j < dgo._tmpSubmeshTris.Length; j++)
			{
				int[] data = dgo._tmpSubmeshTris[j].data;
				if (destStartVertsIdx != 0)
				{
					for (int k = 0; k < data.Length; k++)
					{
						data[k] += destStartVertsIdx;
					}
				}
				if (dgo.invertTriangles)
				{
					for (int l = 0; l < data.Length; l += 3)
					{
						int num = data[l];
						data[l] = data[l + 1];
						data[l + 1] = num;
					}
				}
				int num2 = dgo.targetSubmeshIdxs[j];
				data.CopyTo(submeshTris[num2].data, targSubmeshTidx[num2]);
				dgo.submeshNumTris[num2] += data.Length;
				targSubmeshTidx[num2] += data.Length;
			}
		}

		public void AssignBuffersToMesh(Mesh mesh, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, MB_MeshVertexChannelFlags channelsToWriteToMesh, bool doWriteTrisToMesh, IAssignToMeshCustomizer assignToMeshCustomizer, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, out BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
		{
			if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				AdjustVertsToWriteAccordingToPivotPositionIfNecessary(settings.pivotLocationType, settings.renderType, settings.clearBuffersAfterBake, settings.pivotLocation, out serializableBufferData, out var verts2Write);
				mesh.vertices = verts2Write;
			}
			else
			{
				serializableBufferData.numVertsBaked = mesh.vertexCount;
				serializableBufferData.meshVerticesShift = Vector3.zero;
				serializableBufferData.meshVerticiesWereShifted = false;
			}
			if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				mesh.normals = normals;
			}
			if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				mesh.tangents = tangents;
			}
			if (assignToMeshCustomizer != null)
			{
				IAssignToMeshCustomizer_SimpleAPI assignToMeshCustomizer_SimpleAPI = (IAssignToMeshCustomizer_SimpleAPI)assignToMeshCustomizer;
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV0(0, settings, textureBakeResults, mesh, uv0s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV2(2, settings, textureBakeResults, mesh, uv2s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV3(3, settings, textureBakeResults, mesh, uv3s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV4(4, settings, textureBakeResults, mesh, uv4s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV5(5, settings, textureBakeResults, mesh, uv5s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV6(6, settings, textureBakeResults, mesh, uv6s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV7(7, settings, textureBakeResults, mesh, uv7s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_UV8(8, settings, textureBakeResults, mesh, uv8s, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
				{
					assignToMeshCustomizer_SimpleAPI.meshAssign_colors(settings, textureBakeResults, mesh, colors, uvsSliceIdx);
				}
			}
			else
			{
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
				{
					MBVersion.MeshAssignUVChannel(0, mesh, uv0s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
				{
					MBVersion.MeshAssignUVChannel(2, mesh, uv2s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
				{
					MBVersion.MeshAssignUVChannel(3, mesh, uv3s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
				{
					MBVersion.MeshAssignUVChannel(4, mesh, uv4s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
				{
					MBVersion.MeshAssignUVChannel(5, mesh, uv5s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
				{
					MBVersion.MeshAssignUVChannel(6, mesh, uv6s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
				{
					MBVersion.MeshAssignUVChannel(7, mesh, uv7s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
				{
					MBVersion.MeshAssignUVChannel(8, mesh, uv8s);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
				{
					mesh.colors = colors;
				}
			}
			if (doWriteTrisToMesh)
			{
				AssignTriangleDataForSubmeshes(mesh, mbDynamicObjectsInCombinedMesh, ref serializableBufferData, out submeshTrisToUse, out numNonZeroLengthSubmeshes);
				return;
			}
			submeshTrisToUse = null;
			numNonZeroLengthSubmeshes = -1;
		}

		public void AssignTriangleDataForSubmeshes(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
		{
			submeshTrisToUse = GetSubmeshTrisWithShowHideApplied(mbDynamicObjectsInCombinedMesh);
			int numIndexes = 0;
			numNonZeroLengthSubmeshes = _NumNonZeroLengthSubmeshTris(submeshTrisToUse, out numIndexes);
			mesh.subMeshCount = numNonZeroLengthSubmeshes;
			int num = 0;
			for (int i = 0; i < submeshTrisToUse.Length; i++)
			{
				if (submeshTrisToUse[i].data.Length != 0)
				{
					mesh.SetTriangles(submeshTrisToUse[i].data, num);
					num++;
				}
			}
		}

		public void AssignTriangleDataForSubmeshes_ShowHide(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
		{
			AssignTriangleDataForSubmeshes(mesh, mbDynamicObjectsInCombinedMesh, ref serializableBufferData, out submeshTrisToUse, out numNonZeroLengthSubmeshes);
		}

		private void AdjustVertsToWriteAccordingToPivotPositionIfNecessary(MB_MeshPivotLocation pivotLocationType, MB_RenderType renderType, bool clearBuffersAfterBake, Vector3 pivotLocation_wld, out BufferDataFromPreviousBake serializableBufferData, out Vector3[] verts2Write)
		{
			verts2Write = verticies;
			serializableBufferData.numVertsBaked = verticies.Length;
			if (verticies.Length != 0)
			{
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					serializableBufferData.numVertsBaked = verticies.Length;
					serializableBufferData.meshVerticesShift = Vector3.zero;
					serializableBufferData.meshVerticiesWereShifted = false;
					return;
				}
				switch (pivotLocationType)
				{
				case MB_MeshPivotLocation.worldOrigin:
					serializableBufferData.numVertsBaked = verticies.Length;
					serializableBufferData.meshVerticesShift = Vector3.zero;
					serializableBufferData.meshVerticiesWereShifted = false;
					break;
				case MB_MeshPivotLocation.boundsCenter:
				case MB_MeshPivotLocation.customLocation:
				{
					Vector3 vector4;
					if (pivotLocationType == MB_MeshPivotLocation.boundsCenter)
					{
						Vector3 vector = verticies[0];
						Vector3 vector2 = verticies[0];
						for (int i = 1; i < verticies.Length; i++)
						{
							Vector3 vector3 = verticies[i];
							if (vector.x < vector3.x)
							{
								vector.x = vector3.x;
							}
							if (vector.y < vector3.y)
							{
								vector.y = vector3.y;
							}
							if (vector.z < vector3.z)
							{
								vector.z = vector3.z;
							}
							if (vector2.x > vector3.x)
							{
								vector2.x = vector3.x;
							}
							if (vector2.y > vector3.y)
							{
								vector2.y = vector3.y;
							}
							if (vector2.z > vector3.z)
							{
								vector2.z = vector3.z;
							}
						}
						vector4 = (vector + vector2) * 0.5f;
					}
					else
					{
						vector4 = pivotLocation_wld;
					}
					if (!clearBuffersAfterBake)
					{
						verts2Write = new Vector3[verticies.Length];
					}
					for (int j = 0; j < verticies.Length; j++)
					{
						verts2Write[j] = verticies[j] - vector4;
					}
					serializableBufferData.numVertsBaked = verticies.Length;
					serializableBufferData.meshVerticesShift = vector4;
					serializableBufferData.meshVerticiesWereShifted = true;
					break;
				}
				default:
					UnityEngine.Debug.LogError("Unsupported Pivot Location Type: " + pivotLocationType);
					serializableBufferData.numVertsBaked = verticies.Length;
					serializableBufferData.meshVerticesShift = Vector3.zero;
					serializableBufferData.meshVerticiesWereShifted = false;
					break;
				}
			}
			else
			{
				serializableBufferData.numVertsBaked = verticies.Length;
				serializableBufferData.meshVerticesShift = Vector3.zero;
				serializableBufferData.meshVerticiesWereShifted = false;
			}
		}

		private static int _NumNonZeroLengthSubmeshTris(SerializableIntArray[] subTris, out int numIndexes)
		{
			numIndexes = 0;
			int num = 0;
			for (int i = 0; i < subTris.Length; i++)
			{
				if (subTris[i].data.Length != 0)
				{
					num++;
					numIndexes += subTris[i].data.Length;
				}
			}
			return num;
		}

		private void _copyAndAdjustUVsFromMesh(MB2_TextureBakeResults tbr, MB_DynamicGameObject dgo, Mesh mesh, int uvChannel, int vertsIdx, Vector2[] uvsOut, float[] uvsSliceIdx, MeshChannelsCache meshChannelsCache, MB2_LogLevel LOG_LEVEL, MB2_TextureBakeResults textureBakeResults)
		{
			Vector2[] uVChannel = meshChannelsCache.GetUVChannel(uvChannel, mesh);
			int[] array = new int[uVChannel.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			bool flag = false;
			bool flag2 = tbr.resultType == MB2_TextureBakeResults.ResultType.textureArray;
			for (int j = 0; j < dgo.targetSubmeshIdxs.Length; j++)
			{
				int[] array2 = ((dgo._tmpSubmeshTris == null) ? mesh.GetTriangles(j) : dgo._tmpSubmeshTris[j].data);
				float num = dgo.textureArraySliceIdx[j];
				int idxInSrcMats = dgo.targetSubmeshIdxs[j];
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Build UV transform for mesh {dgo.name} submesh {j} encapsulatingRect {dgo.encapsulatingRect[j]}");
				}
				Rect rect = MB3_TextureCombinerMerging.BuildTransformMeshUV2AtlasRect(textureBakeResults.GetConsiderMeshUVs(idxInSrcMats, dgo.sourceSharedMaterials[j]), dgo.uvRects[j], (dgo.obUVRects == null || dgo.obUVRects.Length == 0) ? new Rect(0f, 0f, 1f, 1f) : dgo.obUVRects[j], dgo.sourceMaterialTiling[j], dgo.encapsulatingRect[j]);
				foreach (int num2 in array2)
				{
					if (array[num2] == -1)
					{
						array[num2] = j;
						Vector2 vector = uVChannel[num2];
						vector.x = rect.x + vector.x * rect.width;
						vector.y = rect.y + vector.y * rect.height;
						int num3 = vertsIdx + num2;
						uvsOut[num3] = vector;
						if (flag2)
						{
							uvsSliceIdx[num3] = num;
						}
					}
					if (array[num2] != j)
					{
						flag = true;
					}
				}
			}
			if (flag && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning(dgo.name + "has submeshes which share verticies. Adjusted uvs may not map correctly in combined atlas.");
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"_copyAndAdjustUVsFromMesh copied {uVChannel.Length} verts");
			}
		}

		private void _CopyAndAdjustUV2FromMesh(MB_IMeshBakerSettings settings, MeshChannelsCache meshChannelsCache, MB_DynamicGameObject dgo, int vertsIdx, MB2_LogLevel LOG_LEVEL)
		{
			Vector2[] array = meshChannelsCache.GetUVChannel(2, dgo._mesh);
			if (settings.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
			{
				if (array == null || array.Length == 0)
				{
					Vector2[] uVChannel = meshChannelsCache.GetUVChannel(0, dgo._mesh);
					if (uVChannel != null && uVChannel.Length != 0)
					{
						array = uVChannel;
					}
					else
					{
						if (LOG_LEVEL >= MB2_LogLevel.warn)
						{
							UnityEngine.Debug.LogWarning("Mesh " + dgo._mesh?.ToString() + " didn't have uv2s. Generating uv2s.");
						}
						array = meshChannelsCache.GetUv2Modified(dgo._mesh);
					}
				}
				Vector4 lightmapTilingOffset = dgo.lightmapTilingOffset;
				Vector2 vector = new Vector2(lightmapTilingOffset.x, lightmapTilingOffset.y);
				Vector2 vector2 = new Vector2(lightmapTilingOffset.z, lightmapTilingOffset.w);
				Vector2 vector3 = default(Vector2);
				for (int i = 0; i < array.Length; i++)
				{
					vector3.x = vector.x * array[i].x;
					vector3.y = vector.y * array[i].y;
					uv2s[vertsIdx + i] = vector2 + vector3;
				}
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("_copyAndAdjustUV2FromMesh copied and modify for preserve current lightmapping " + array.Length);
				}
				return;
			}
			if (array == null || array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + dgo._mesh?.ToString() + " didn't have uv2s. Generating uv2s.");
				}
				if (settings.lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects && (array == null || array.Length == 0))
				{
					UnityEngine.Debug.LogError("Mesh " + dgo._mesh?.ToString() + " did not have a UV2 channel. Nothing to copy when trying to copy UV2 to separate rects. The combined mesh will not lightmap properly. Try using generate new uv2 layout.");
				}
				array = meshChannelsCache.GetUv2Modified(dgo._mesh);
			}
			array.CopyTo(uv2s, vertsIdx);
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("_copyAndAdjustUV2FromMesh copied without modifying " + array.Length);
			}
		}

		public void CopyUV2unchangedToSeparateRects(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, float uv2UnwrappingParamsPackMargin)
		{
			int num = Mathf.CeilToInt(8192f * uv2UnwrappingParamsPackMargin);
			if (num < 1)
			{
				num = 1;
			}
			List<Vector2> list = new List<Vector2>(mbDynamicObjectsInCombinedMesh.Count);
			float[] array = new float[mbDynamicObjectsInCombinedMesh.Count];
			Rect[] array2 = new Rect[mbDynamicObjectsInCombinedMesh.Count];
			float num2 = 0f;
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[i];
				float num3 = 1f;
				if (Application.isEditor && mB_DynamicGameObject._renderer is MeshRenderer)
				{
					num3 = MBVersion.GetScaleInLightmap((MeshRenderer)mB_DynamicGameObject._renderer);
					if (num3 <= 0f)
					{
						num3 = 1f;
					}
				}
				float magnitude = mB_DynamicGameObject.meshSize.magnitude;
				array[i] = num3 * magnitude;
				num2 += array[i];
			}
			for (int j = 0; j < array.Length; j++)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[j];
				int num4 = mB_DynamicGameObject2.vertIdx + mB_DynamicGameObject2.numVerts;
				float x;
				float num5 = (x = uv2s[mB_DynamicGameObject2.vertIdx].x);
				float y;
				float num6 = (y = uv2s[mB_DynamicGameObject2.vertIdx].y);
				for (int k = mB_DynamicGameObject2.vertIdx; k < num4; k++)
				{
					if (uv2s[k].x < num5)
					{
						num5 = uv2s[k].x;
					}
					if (uv2s[k].x > x)
					{
						x = uv2s[k].x;
					}
					if (uv2s[k].y < num6)
					{
						num6 = uv2s[k].y;
					}
					if (uv2s[k].y > y)
					{
						y = uv2s[k].y;
					}
				}
				array2[j] = new Rect(num5, num6, x - num5, y - num6);
				array[j] /= num2;
				Vector2 item = new Vector2(array2[j].width, array2[j].height) * (array[j] * 8192f);
				list.Add(item);
			}
			AtlasPackingResult atlasPackingResult = new MB2_TexturePackerRegular
			{
				atlasMustBePowerOfTwo = false
			}.GetRects(list, 8192, 8192, num)[0];
			Vector2 vector = default(Vector2);
			for (int l = 0; l < mbDynamicObjectsInCombinedMesh.Count; l++)
			{
				MB_DynamicGameObject mB_DynamicGameObject3 = mbDynamicObjectsInCombinedMesh[l];
				int num7 = mB_DynamicGameObject3.vertIdx + mB_DynamicGameObject3.numVerts;
				Rect rect = array2[l];
				Rect rect2 = atlasPackingResult.rects[l];
				for (int m = mB_DynamicGameObject3.vertIdx; m < num7; m++)
				{
					vector.x = (uv2s[m].x - rect.x) / rect.width * rect2.width + rect2.x;
					vector.y = (uv2s[m].y - rect.y) / rect.height * rect2.height + rect2.y;
					uv2s[m] = vector;
				}
				if (atlasPackingResult.atlasX == atlasPackingResult.atlasY)
				{
					continue;
				}
				if (atlasPackingResult.atlasX < atlasPackingResult.atlasY)
				{
					float num8 = (float)atlasPackingResult.atlasX / (float)atlasPackingResult.atlasY;
					for (int n = mB_DynamicGameObject3.vertIdx; n < num7; n++)
					{
						Vector2 vector2 = uv2s[n];
						vector2.x *= num8;
						uv2s[n] = vector2;
					}
				}
				else
				{
					float num9 = (float)atlasPackingResult.atlasY / (float)atlasPackingResult.atlasX;
					for (int num10 = mB_DynamicGameObject3.vertIdx; num10 < num7; num10++)
					{
						Vector2 vector3 = uv2s[num10];
						vector3.y *= num9;
						uv2s[num10] = vector3;
					}
				}
			}
		}

		private SerializableIntArray[] GetSubmeshTrisWithShowHideApplied(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh)
		{
			bool flag = false;
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				if (!mbDynamicObjectsInCombinedMesh[i].show)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int[] array = new int[submeshTris.Length];
				SerializableIntArray[] array2 = new SerializableIntArray[submeshTris.Length];
				for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[j];
					if (mB_DynamicGameObject.show)
					{
						for (int k = 0; k < mB_DynamicGameObject.submeshNumTris.Length; k++)
						{
							array[k] += mB_DynamicGameObject.submeshNumTris[k];
						}
					}
				}
				for (int l = 0; l < array2.Length; l++)
				{
					array2[l] = new SerializableIntArray(array[l]);
				}
				int[] array3 = new int[array2.Length];
				for (int m = 0; m < mbDynamicObjectsInCombinedMesh.Count; m++)
				{
					MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[m];
					if (!mB_DynamicGameObject2.show)
					{
						continue;
					}
					for (int n = 0; n < submeshTris.Length; n++)
					{
						int[] data = submeshTris[n].data;
						int num = mB_DynamicGameObject2.submeshTriIdxs[n];
						int num2 = num + mB_DynamicGameObject2.submeshNumTris[n];
						for (int num3 = num; num3 < num2; num3++)
						{
							array2[n].data[array3[n]] = data[num3];
							array3[n]++;
						}
					}
				}
				return array2;
			}
			return submeshTris;
		}

		public int[] GetTriangleSizes()
		{
			int[] array = new int[submeshTris.Length];
			for (int i = 0; i < submeshTris.Length; i++)
			{
				array[i] = submeshTris[i].data.Length;
			}
			return array;
		}

		private void _LocalToWorld(Transform t, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts, Vector3[] dgoMeshNorms, Vector4[] dgoMeshTans, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
		{
			Vector3 lossyScale = t.lossyScale;
			if (lossyScale == Vector3.one)
			{
				_LocalToWorld_TR(t.rotation, t.position, doNorm, doTan, destStartVertsIdx, dgoMeshVerts, dgoMeshNorms, dgoMeshTans, verticies, normals, tangents);
			}
			else if (lossyScale.x > Mathf.Epsilon && lossyScale.y > Mathf.Epsilon && lossyScale.z > Mathf.Epsilon)
			{
				Matrix4x4 wld_X_local = t.localToWorldMatrix;
				_LocalToWorldMatrix_TRS(ref wld_X_local, doNorm, doTan, destStartVertsIdx, dgoMeshVerts, dgoMeshNorms, dgoMeshTans, verticies, normals, tangents);
			}
			else
			{
				_LocalToWorld_TRS(t.rotation, t.position, t.lossyScale, doNorm, doTan, destStartVertsIdx, dgoMeshVerts, dgoMeshNorms, dgoMeshTans, verticies, normals, tangents);
			}
		}

		private static void _LocalToWorldMatrix_TRS(ref Matrix4x4 wld_X_local, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts, Vector3[] dgoMeshNorms, Vector4[] dgoMeshTans, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
		{
			Matrix4x4 matrix4x = Matrix4x4.zero;
			if (doNorm || doTan)
			{
				matrix4x = wld_X_local;
				float num = (matrix4x[2, 3] = 0f);
				float value = (matrix4x[1, 3] = num);
				matrix4x[0, 3] = value;
				matrix4x = matrix4x.inverse.transpose;
			}
			for (int i = 0; i < dgoMeshVerts.Length; i++)
			{
				int num4 = destStartVertsIdx + i;
				verticies[num4] = wld_X_local.MultiplyPoint3x4(dgoMeshVerts[i]);
				if (doNorm)
				{
					normals[num4] = matrix4x.MultiplyPoint3x4(dgoMeshNorms[i]).normalized;
				}
				if (doTan)
				{
					float w = dgoMeshTans[i].w;
					Vector4 vector = matrix4x.MultiplyPoint3x4(dgoMeshTans[i]).normalized;
					vector.w = w;
					tangents[num4] = vector;
				}
			}
		}

		private static void _LocalToWorld_TR(Quaternion wld_Rot_local, Vector3 position_wld, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts_local, Vector3[] dgoMeshNorms_local, Vector4[] dgoMeshTans_local, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
		{
			for (int i = 0; i < dgoMeshVerts_local.Length; i++)
			{
				int num = destStartVertsIdx + i;
				Vector3 vector = dgoMeshVerts_local[i];
				vector = wld_Rot_local * vector;
				vector += position_wld;
				verticies[num] = vector;
				if (doNorm)
				{
					Vector3 vector2 = dgoMeshNorms_local[i];
					vector2 = wld_Rot_local * vector2;
					normals[num] = vector2;
				}
				if (doTan)
				{
					Vector3 vector3 = dgoMeshTans_local[i];
					float w = dgoMeshTans_local[i].w;
					vector3 = wld_Rot_local * vector3;
					Vector4 vector4 = vector3;
					vector4.w = w;
					tangents[num] = vector4;
				}
			}
		}

		private static void _LocalToWorld_TRS(Quaternion wld_Rot_local, Vector3 position_wld, Vector3 scale, bool doNorm, bool doTan, int destStartVertsIdx, Vector3[] dgoMeshVerts_local, Vector3[] dgoMeshNorms_local, Vector4[] dgoMeshTans_local, Vector3[] verticies, Vector3[] normals, Vector4[] tangents)
		{
			Vector3 one = Vector3.one;
			if (doNorm || doTan)
			{
				one.x = ((scale.x < Mathf.Epsilon) ? 0f : (1f / scale.x));
				one.y = ((scale.y < Mathf.Epsilon) ? 0f : (1f / scale.y));
				one.z = ((scale.z < Mathf.Epsilon) ? 0f : (1f / scale.z));
			}
			for (int i = 0; i < dgoMeshVerts_local.Length; i++)
			{
				int num = destStartVertsIdx + i;
				Vector3 vector = dgoMeshVerts_local[i];
				vector.x *= scale.x;
				vector.y *= scale.y;
				vector.z *= scale.z;
				vector = wld_Rot_local * vector;
				vector += position_wld;
				verticies[num] = vector;
				if (doNorm)
				{
					Vector3 vector2 = dgoMeshNorms_local[i];
					vector2.x *= one.x;
					vector2.y *= one.y;
					vector2.z *= one.z;
					vector2 = wld_Rot_local * vector2;
					vector2.Normalize();
					normals[num] = vector2;
				}
				if (doTan)
				{
					Vector3 vector3 = dgoMeshTans_local[i];
					float w = dgoMeshTans_local[i].w;
					vector3.x *= one.x;
					vector3.y *= one.y;
					vector3.z *= one.z;
					vector3 = wld_Rot_local * vector3;
					vector3.Normalize();
					tangents[num] = new Vector4(vector3.x, vector3.y, vector3.z, w);
				}
			}
		}
	}

	public class MeshChannelsCache_NativeArray : IDisposable, IMeshChannelsCacheTaggingInterface
	{
		private MB2_LogLevel LOG_LEVEL;

		private MB2_LightmapOptions lightmapOption;

		protected Dictionary<int, MeshChannelsNativeArray> meshID2MeshChannels = new Dictionary<int, MeshChannelsNativeArray>();

		private bool _collectedMeshData;

		private bool _disposed;

		private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

		public MeshChannelsCache_NativeArray(MB2_LogLevel ll, MB2_LightmapOptions lo)
		{
			LOG_LEVEL = ll;
			lightmapOption = lo;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			foreach (MeshChannelsNativeArray value in meshID2MeshChannels.Values)
			{
				value.Dispose();
			}
			_collectedMeshData = false;
			_disposed = true;
		}

		public bool HasCollectedMeshData()
		{
			return _collectedMeshData;
		}

		public bool hasOutOfBoundsUVs(Mesh m, ref MB_Utility.MeshAnalysisResult mar, int submeshIdx)
		{
			return MB_Utility.hasOutOfBoundsUVs(GetUv0RawAsNativeArray(m), m, ref mar, submeshIdx);
		}

		internal NativeArray<Vector3> GetVerticiesAsNativeArray(Mesh m)
		{
			if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
			{
				UnityEngine.Debug.LogError("Could not find mesh in the MeshChannelsCache." + m);
			}
			return value.vertcies_NativeArray;
		}

		internal NativeArray<Vector3> GetNormalsAsNativeArray(Mesh m)
		{
			if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
			{
				UnityEngine.Debug.LogError("Could not find mesh in the MeshChannelsCache." + m);
			}
			return value.normals_NativeArray;
		}

		internal NativeArray<Vector4> GetTangentsAsNativeArray(Mesh m)
		{
			if (!meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value))
			{
				UnityEngine.Debug.LogError("Could not find mesh in the MeshChannelsCache." + m);
			}
			return value.tangents_NativeArray;
		}

		internal NativeArray<Vector2> GetUv0RawAsNativeArray(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.uv0raw_NativeArray;
		}

		internal NativeArray<Vector2> GetUv0ModifiedAsNativeArray(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			if (!value.uv0modified_NativeArray.IsCreated)
			{
				value.uv0modified_NativeArray = new NativeArray<Vector2>(value.vertcies_NativeArray.Length, Allocator.Temp);
			}
			return value.uv0modified_NativeArray;
		}

		internal NativeArray<Vector2> GetUv2ModifiedAsNativeArray(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			if (!value.uv2modified_NativeArray.IsCreated)
			{
				value.uv2modified_NativeArray = new NativeArray<Vector2>(value.vertcies_NativeArray.Length, Allocator.Temp);
			}
			return value.uv2modified_NativeArray;
		}

		internal NativeArray<Vector2> GetUVChannelAsNativeArray(int channel, Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			switch (channel)
			{
			case 0:
				return value.uv0raw_NativeArray;
			case 2:
				return value.uv2raw_NativeArray;
			case 3:
				return value.uv3_NativeArray;
			case 4:
				return value.uv4_NativeArray;
			case 5:
				return value.uv5_NativeArray;
			case 6:
				return value.uv6_NativeArray;
			case 7:
				return value.uv7_NativeArray;
			case 8:
				return value.uv8_NativeArray;
			default:
				UnityEngine.Debug.LogError("Error mesh channel " + channel + " not supported");
				return default(NativeArray<Vector2>);
			}
		}

		internal NativeArray<Color> GetColorsAsNativeArray(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.colors_NativeArray;
		}

		public void CollectChannelDataForAllMeshesInList(List<MB_DynamicGameObject> toUpdateDGOs, List<MB_DynamicGameObject> toAddDGOs, MB_MeshVertexChannelFlags newChannels, MB_RenderType renderType, bool doBlendShapes)
		{
			bool flag = (newChannels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex;
			bool flag2 = (newChannels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal;
			bool flag3 = (newChannels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent;
			bool flag4 = (newChannels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0;
			bool flag5 = (newChannels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2;
			bool flag6 = (newChannels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3;
			bool flag7 = (newChannels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4;
			bool flag8 = (newChannels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5;
			bool flag9 = (newChannels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6;
			bool flag10 = (newChannels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7;
			bool flag11 = (newChannels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8;
			bool flag12 = (newChannels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors;
			List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
			list.AddRange(toUpdateDGOs);
			list.AddRange(toAddDGOs);
			for (int i = 0; i < list.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = list[i];
				Mesh mesh = mB_DynamicGameObject._mesh;
				if (meshID2MeshChannels.ContainsKey(mesh.GetInstanceID()))
				{
					continue;
				}
				MeshChannelsNativeArray meshChannelsNativeArray = new MeshChannelsNativeArray();
				meshID2MeshChannels.Add(mesh.GetInstanceID(), meshChannelsNativeArray);
				if (flag)
				{
					meshChannelsNativeArray.vertcies_NativeArray = new NativeArray<Vector3>(mesh.vertices, Allocator.Temp);
				}
				if (flag4)
				{
					meshChannelsNativeArray.uv0raw_NativeArray = new NativeArray<Vector2>(_getMeshUVs(mesh), Allocator.Temp);
				}
				if (flag5)
				{
					meshChannelsNativeArray.uv2raw_NativeArray = new NativeArray<Vector2>(_getMeshUV2s(mesh, ref meshChannelsNativeArray.uv2modified_NativeArray), Allocator.Temp);
				}
				if (flag2)
				{
					meshChannelsNativeArray.normals_NativeArray = new NativeArray<Vector3>(_getMeshNormals(mesh), Allocator.Temp);
				}
				if (flag3)
				{
					meshChannelsNativeArray.tangents_NativeArray = new NativeArray<Vector4>(_getMeshTangents(mesh), Allocator.Temp);
				}
				if (flag6)
				{
					meshChannelsNativeArray.uv3_NativeArray = new NativeArray<Vector2>(MBVersion.GetMeshChannel(3, mesh, LOG_LEVEL), Allocator.Temp);
				}
				if (flag7)
				{
					meshChannelsNativeArray.uv4_NativeArray = new NativeArray<Vector2>(MBVersion.GetMeshChannel(4, mesh, LOG_LEVEL), Allocator.Temp);
				}
				if (flag8)
				{
					meshChannelsNativeArray.uv5_NativeArray = new NativeArray<Vector2>(MBVersion.GetMeshChannel(5, mesh, LOG_LEVEL), Allocator.Temp);
				}
				if (flag9)
				{
					meshChannelsNativeArray.uv6_NativeArray = new NativeArray<Vector2>(MBVersion.GetMeshChannel(6, mesh, LOG_LEVEL), Allocator.Temp);
				}
				if (flag10)
				{
					meshChannelsNativeArray.uv7_NativeArray = new NativeArray<Vector2>(MBVersion.GetMeshChannel(7, mesh, LOG_LEVEL), Allocator.Temp);
				}
				if (flag11)
				{
					meshChannelsNativeArray.uv8_NativeArray = new NativeArray<Vector2>(MBVersion.GetMeshChannel(8, mesh, LOG_LEVEL), Allocator.Temp);
				}
				if (flag12)
				{
					meshChannelsNativeArray.colors_NativeArray = new NativeArray<Color>(_getMeshColors(mesh), Allocator.Temp);
				}
				if (renderType != MB_RenderType.skinnedMeshRenderer)
				{
					continue;
				}
				bool isSkinnedMeshWithBones = false;
				Renderer renderer = mB_DynamicGameObject._renderer;
				if (meshChannelsNativeArray.bindPoses == null || meshChannelsNativeArray.bindPoses.Count == 0)
				{
					_getBindPoses(renderer, meshChannelsNativeArray.bindPoses, out isSkinnedMeshWithBones);
					_getBoneWeightData(ref meshChannelsNativeArray.boneWeightData, renderer, meshChannelsNativeArray.bindPoses.Count, isSkinnedMeshWithBones);
				}
				if (!doBlendShapes)
				{
					continue;
				}
				MBBlendShape[] array = new MBBlendShape[mesh.blendShapeCount];
				int vertexCount = mesh.vertexCount;
				for (int j = 0; j < array.Length; j++)
				{
					MBBlendShape mBBlendShape = (array[j] = new MBBlendShape());
					mBBlendShape.frames = new MBBlendShapeFrame[MBVersion.GetBlendShapeFrameCount(mesh, j)];
					mBBlendShape.name = mesh.GetBlendShapeName(j);
					mBBlendShape.indexInSource = j;
					mBBlendShape.gameObject = mB_DynamicGameObject.gameObject;
					for (int k = 0; k < mBBlendShape.frames.Length; k++)
					{
						MBBlendShapeFrame mBBlendShapeFrame = (mBBlendShape.frames[k] = new MBBlendShapeFrame());
						mBBlendShapeFrame.frameWeight = MBVersion.GetBlendShapeFrameWeight(mesh, j, k);
						mBBlendShapeFrame.vertices = new Vector3[vertexCount];
						mBBlendShapeFrame.normals = new Vector3[vertexCount];
						mBBlendShapeFrame.tangents = new Vector3[vertexCount];
						MBVersion.GetBlendShapeFrameVertices(mesh, j, k, mBBlendShapeFrame.vertices, mBBlendShapeFrame.normals, mBBlendShapeFrame.tangents);
					}
				}
				meshChannelsNativeArray.blendShapes = array;
			}
			_collectedMeshData = true;
		}

		internal List<Matrix4x4> GetBindposes(Renderer r, out bool isSkinnedMeshWithBones)
		{
			Mesh mesh = MB_Utility.GetMesh(r.gameObject);
			meshID2MeshChannels.TryGetValue(mesh.GetInstanceID(), out var value);
			if (r is SkinnedMeshRenderer && value.bindPoses.Count > 0)
			{
				isSkinnedMeshWithBones = true;
			}
			else
			{
				isSkinnedMeshWithBones = false;
				_ = r is SkinnedMeshRenderer;
			}
			return value.bindPoses;
		}

		internal BoneWeightDataForMesh GetBoneWeightData(Renderer r, int numbones, bool isSkinnedMeshWithBones)
		{
			Mesh mesh = MB_Utility.GetMesh(r.gameObject);
			meshID2MeshChannels.TryGetValue(mesh.GetInstanceID(), out var value);
			return value.boneWeightData;
		}

		public MBBlendShape[] GetBlendShapes(Mesh m, int gameObjectID, GameObject gameObject)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			MBBlendShape[] array = new MBBlendShape[value.blendShapes.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new MBBlendShape();
				array[i].name = value.blendShapes[i].name;
				array[i].indexInSource = value.blendShapes[i].indexInSource;
				array[i].frames = value.blendShapes[i].frames;
				array[i].gameObject = gameObject;
			}
			return array;
		}

		private Color[] _getMeshColors(Mesh m)
		{
			Color[] array = m.colors;
			if (array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no colors. Generating");
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have colors. Generating an array of white colors");
				}
				array = new Color[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Color.white;
				}
			}
			return array;
		}

		private Vector3[] _getMeshNormals(Mesh m)
		{
			Vector3[] normals = m.normals;
			if (normals.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no normals. Generating");
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have normals. Generating normals.");
				}
				Mesh mesh = UnityEngine.Object.Instantiate(m);
				mesh.RecalculateNormals();
				normals = mesh.normals;
				MB_Utility.Destroy(mesh);
			}
			return normals;
		}

		private Vector4[] _getMeshTangents(Mesh m)
		{
			Vector4[] array = m.tangents;
			if (array.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no tangents. Generating");
				}
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have tangents. Generating tangents.");
				}
				Vector3[] vertices = m.vertices;
				NativeArray<Vector2> uv0Raw = GetUv0Raw(m);
				Vector3[] normals = _getMeshNormals(m);
				array = new Vector4[m.vertexCount];
				for (int i = 0; i < m.subMeshCount; i++)
				{
					int[] triangles = m.GetTriangles(i);
					_generateTangents(triangles, vertices, uv0Raw, normals, array);
				}
			}
			return array;
		}

		private Vector2[] _getMeshUVs(Mesh m)
		{
			Vector2[] array = m.uv;
			if (array.Length == 0)
			{
				array = new Vector2[m.vertexCount];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = _HALF_UV;
				}
			}
			return array;
		}

		private Vector2[] _getMeshUV2s(Mesh m, ref NativeArray<Vector2> uv2modified)
		{
			Vector2[] uv = m.uv2;
			if (uv.Length == 0)
			{
				uv2modified = new NativeArray<Vector2>(m.vertexCount, Allocator.TempJob);
				for (int i = 0; i < uv2modified.Length; i++)
				{
					uv2modified[i] = _HALF_UV;
				}
			}
			return uv;
		}

		private static void _getBindPoses(Renderer r, List<Matrix4x4> poses, out bool isSkinnedMeshWithBones)
		{
			poses.Clear();
			isSkinnedMeshWithBones = r is SkinnedMeshRenderer;
			if (r is SkinnedMeshRenderer)
			{
				Mesh mesh = MB_Utility.GetMesh(r.gameObject);
				mesh.GetBindposes(poses);
				if (poses.Count == 0)
				{
					if (mesh.blendShapeCount > 0)
					{
						isSkinnedMeshWithBones = false;
					}
					else
					{
						UnityEngine.Debug.LogError("Skinned mesh " + r?.ToString() + " had no bindposes AND no blend shapes");
					}
				}
			}
			if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
			{
				poses.Clear();
				poses.Add(Matrix4x4.identity);
			}
			if (poses == null || poses.Count == 0)
			{
				UnityEngine.Debug.LogError("Could not _getBindPoses. Object does not have a renderer");
			}
		}

		private static void _getBoneWeightData(ref BoneWeightDataForMesh bwd, Renderer r, int numBones, bool isSkinnedMeshWithBones)
		{
			if (isSkinnedMeshWithBones)
			{
				Mesh sharedMesh = ((SkinnedMeshRenderer)r).sharedMesh;
				bwd.initialized = true;
				bwd.weMustDispose = false;
				bwd.bonesPerVertex = sharedMesh.GetBonesPerVertex();
				bwd.boneWeights = sharedMesh.GetAllBoneWeights();
			}
			else if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
			{
				Mesh mesh = MB_Utility.GetMesh(r.gameObject);
				bwd.initialized = true;
				bwd.weMustDispose = true;
				bwd.boneWeights = new NativeArray<BoneWeight1>(mesh.vertexCount, Allocator.Temp);
				bwd.bonesPerVertex = new NativeArray<byte>(mesh.vertexCount, Allocator.Temp);
				BoneWeight1 value = new BoneWeight1
				{
					boneIndex = 0,
					weight = 1f
				};
				for (int i = 0; i < mesh.vertexCount; i++)
				{
					bwd.bonesPerVertex[i] = 1;
					bwd.boneWeights[i] = value;
				}
			}
			else
			{
				UnityEngine.Debug.LogError("Could not _getBoneWeights. Object does not have a renderer");
			}
			bwd.UsedBoneIdxsInSrcMesh = new bool[numBones];
			for (int j = 0; j < bwd.boneWeights.Length; j++)
			{
				bwd.UsedBoneIdxsInSrcMesh[bwd.boneWeights[j].boneIndex] = true;
			}
			bwd.numUsedbones = 0;
			for (int k = 0; k < bwd.UsedBoneIdxsInSrcMesh.Length; k++)
			{
				if (bwd.UsedBoneIdxsInSrcMesh[k])
				{
					bwd.numUsedbones++;
				}
			}
		}

		internal NativeArray<Vector2> GetUv0Raw(Mesh m)
		{
			meshID2MeshChannels.TryGetValue(m.GetInstanceID(), out var value);
			return value.uv0raw_NativeArray;
		}

		private static BoneWeight[] _getBoneWeights(Renderer r, int numVertsInMeshBeingAdded, bool isSkinnedMeshWithBones)
		{
			if (isSkinnedMeshWithBones)
			{
				return ((SkinnedMeshRenderer)r).sharedMesh.boneWeights;
			}
			if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
			{
				BoneWeight boneWeight = default(BoneWeight);
				int num = (boneWeight.boneIndex3 = 0);
				int num3 = (boneWeight.boneIndex2 = num);
				int boneIndex = (boneWeight.boneIndex1 = num3);
				boneWeight.boneIndex0 = boneIndex;
				boneWeight.weight0 = 1f;
				float num6 = (boneWeight.weight3 = 0f);
				float weight = (boneWeight.weight2 = num6);
				boneWeight.weight1 = weight;
				BoneWeight[] array = new BoneWeight[numVertsInMeshBeingAdded];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = boneWeight;
				}
				return array;
			}
			UnityEngine.Debug.LogError("Could not _getBoneWeights. Object does not have a renderer");
			return null;
		}

		private void _generateTangents(int[] triangles, Vector3[] verts, NativeArray<Vector2> uvs, Vector3[] normals, Vector4[] outTangents)
		{
			int num = triangles.Length;
			int num2 = verts.Length;
			Vector3[] array = new Vector3[num2];
			Vector3[] array2 = new Vector3[num2];
			for (int i = 0; i < num; i += 3)
			{
				int num3 = triangles[i];
				int num4 = triangles[i + 1];
				int num5 = triangles[i + 2];
				Vector3 vector = verts[num3];
				Vector3 vector2 = verts[num4];
				Vector3 vector3 = verts[num5];
				Vector2 vector4 = uvs[num3];
				Vector2 vector5 = uvs[num4];
				Vector2 vector6 = uvs[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = num12 * num15 - num13 * num14;
				if (num16 == 0f)
				{
					UnityEngine.Debug.LogError("Could not compute tangents. All UVs need to form a valid triangles in UV space. If any UV triangles are collapsed, tangents cannot be generated.");
					return;
				}
				float num17 = 1f / num16;
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num17, (num15 * num8 - num14 * num9) * num17, (num15 * num10 - num14 * num11) * num17);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num17, (num12 * num9 - num13 * num8) * num17, (num12 * num11 - num13 * num10) * num17);
				array[num3] += vector7;
				array[num4] += vector7;
				array[num5] += vector7;
				array2[num3] += vector8;
				array2[num4] += vector8;
				array2[num5] += vector8;
			}
			for (int j = 0; j < num2; j++)
			{
				Vector3 vector9 = normals[j];
				Vector3 vector10 = array[j];
				Vector3 normalized = (vector10 - vector9 * Vector3.Dot(vector9, vector10)).normalized;
				outTangents[j] = new Vector4(normalized.x, normalized.y, normalized.z);
				outTangents[j].w = ((Vector3.Dot(Vector3.Cross(vector9, vector10), array2[j]) < 0f) ? (-1f) : 1f);
			}
		}
	}

	public class MeshChannelsNativeArray : IDisposable
	{
		private bool _disposed;

		public NativeArray<Vector3> vertcies_NativeArray;

		public NativeArray<Vector3> normals_NativeArray;

		public NativeArray<Vector4> tangents_NativeArray;

		public NativeArray<Color> colors_NativeArray;

		public NativeArray<Vector2> uv0raw_NativeArray;

		public NativeArray<Vector2> uv0modified_NativeArray;

		public NativeArray<Vector2> uv2raw_NativeArray;

		public NativeArray<Vector2> uv2modified_NativeArray;

		public NativeArray<Vector2> uv3_NativeArray;

		public NativeArray<Vector2> uv4_NativeArray;

		public NativeArray<Vector2> uv5_NativeArray;

		public NativeArray<Vector2> uv6_NativeArray;

		public NativeArray<Vector2> uv7_NativeArray;

		public NativeArray<Vector2> uv8_NativeArray;

		public List<Matrix4x4> bindPoses = new List<Matrix4x4>(128);

		public BoneWeightDataForMesh boneWeightData;

		public MBBlendShape[] blendShapes;

		public void Dispose()
		{
			Dispose(disposing: true);
		}

		public bool IsDisposed()
		{
			return _disposed;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				_disposed = true;
				boneWeightData.Dispose();
				if (vertcies_NativeArray.IsCreated)
				{
					vertcies_NativeArray.Dispose();
				}
				if (normals_NativeArray.IsCreated)
				{
					normals_NativeArray.Dispose();
				}
				if (tangents_NativeArray.IsCreated)
				{
					tangents_NativeArray.Dispose();
				}
				if (colors_NativeArray.IsCreated)
				{
					colors_NativeArray.Dispose();
				}
				if (uv0raw_NativeArray.IsCreated)
				{
					uv0raw_NativeArray.Dispose();
				}
				if (uv0modified_NativeArray.IsCreated)
				{
					uv0modified_NativeArray.Dispose();
				}
				if (uv2raw_NativeArray.IsCreated)
				{
					uv2raw_NativeArray.Dispose();
				}
				if (uv2modified_NativeArray.IsCreated)
				{
					uv2modified_NativeArray.Dispose();
				}
				if (uv3_NativeArray.IsCreated)
				{
					uv3_NativeArray.Dispose();
				}
				if (uv4_NativeArray.IsCreated)
				{
					uv4_NativeArray.Dispose();
				}
				if (uv5_NativeArray.IsCreated)
				{
					uv5_NativeArray.Dispose();
				}
				if (uv6_NativeArray.IsCreated)
				{
					uv6_NativeArray.Dispose();
				}
				if (uv7_NativeArray.IsCreated)
				{
					uv7_NativeArray.Dispose();
				}
				if (uv8_NativeArray.IsCreated)
				{
					uv8_NativeArray.Dispose();
				}
			}
		}
	}

	public struct MB_MeshCombinerSingle_MeshNativeArrayHelper
	{
		public struct SIZER_4
		{
			public unsafe fixed byte data[4];
		}

		public struct SIZER_8
		{
			public unsafe fixed byte data[8];
		}

		public struct SIZER_12
		{
			public unsafe fixed byte data[12];
		}

		public struct SIZER_16
		{
			public unsafe fixed byte data[16];
		}

		public struct SIZER_20
		{
			public unsafe fixed byte data[20];
		}

		public struct SIZER_24
		{
			public unsafe fixed byte data[24];
		}

		public struct SIZER_28
		{
			public unsafe fixed byte data[28];
		}

		public struct SIZER_32
		{
			public unsafe fixed byte data[32];
		}

		public struct SIZER_36
		{
			public unsafe fixed byte data[36];
		}

		public struct SIZER_40
		{
			public unsafe fixed byte data[40];
		}

		public struct SIZER_44
		{
			public unsafe fixed byte data[44];
		}

		public struct SIZER_48
		{
			public unsafe fixed byte data[48];
		}

		public struct SIZER_52
		{
			public unsafe fixed byte data[52];
		}

		public struct SIZER_56
		{
			public unsafe fixed byte data[56];
		}

		public struct SIZER_60
		{
			public unsafe fixed byte data[60];
		}

		public struct SIZER_64
		{
			public unsafe fixed byte data[64];
		}

		public struct SIZER_68
		{
			public unsafe fixed byte data[68];
		}

		public struct SIZER_72
		{
			public unsafe fixed byte data[72];
		}

		public struct SIZER_76
		{
			public unsafe fixed byte data[72];
		}

		public struct SIZER_80
		{
			public unsafe fixed byte data[80];
		}

		public struct SIZER_84
		{
			public unsafe fixed byte data[84];
		}

		public struct SIZER_88
		{
			public unsafe fixed byte data[88];
		}

		public struct SIZER_92
		{
			public unsafe fixed byte data[92];
		}

		public struct SIZER_96
		{
			public unsafe fixed byte data[96];
		}

		public struct SIZER_100
		{
			public unsafe fixed byte data[100];
		}

		public struct SIZER_104
		{
			public unsafe fixed byte data[104];
		}

		public struct SIZER_108
		{
			public unsafe fixed byte data[108];
		}

		public struct SIZER_112
		{
			public unsafe fixed byte data[112];
		}

		public struct SIZER_116
		{
			public unsafe fixed byte data[116];
		}

		public struct SIZER_120
		{
			public unsafe fixed byte data[120];
		}

		public struct SIZER_124
		{
			public unsafe fixed byte data[124];
		}

		public struct SIZER_128
		{
			public unsafe fixed byte data[128];
		}

		public struct SIZER_132
		{
			public unsafe fixed byte data[132];
		}

		public struct SIZER_136
		{
			public unsafe fixed byte data[136];
		}

		public struct SIZER_140
		{
			public unsafe fixed byte data[140];
		}

		public struct SIZER_144
		{
			public unsafe fixed byte data[144];
		}

		public struct SIZER_148
		{
			public unsafe fixed byte data[148];
		}

		public struct SIZER_152
		{
			public unsafe fixed byte data[152];
		}

		private static Type[] _TypeForStride;

		public Mesh.MeshDataArray dataArray;

		public Mesh.MeshData data;

		public int vertexCount;

		[Preserve]
		public void _ENSURE_IL2CPP_CREATES_NECESSARY_CODE(ref Mesh.MeshData m)
		{
			UnityEngine.Debug.LogError("This should never be called directly. It is only here to ensure these methodes are generated by the il2cpp compiler and not stripped so that they can be found by reflection.");
			NativeArray<SIZER_4> vertexData = m.GetVertexData<SIZER_4>();
			NativeSlice<SIZER_4> nativeSlice = new NativeSlice<SIZER_4>(vertexData);
			nativeSlice.SliceWithStride<Vector2>(0);
			nativeSlice.SliceWithStride<Vector3>(0);
			nativeSlice.SliceWithStride<Vector4>(0);
			nativeSlice.SliceWithStride<Color32>(0);
			NativeArray<SIZER_8> vertexData2 = m.GetVertexData<SIZER_8>();
			NativeSlice<SIZER_8> nativeSlice2 = new NativeSlice<SIZER_8>(vertexData2);
			nativeSlice2.SliceWithStride<Vector2>(0);
			nativeSlice2.SliceWithStride<Vector3>(0);
			nativeSlice2.SliceWithStride<Vector4>(0);
			nativeSlice2.SliceWithStride<Color32>(0);
			NativeArray<SIZER_12> vertexData3 = m.GetVertexData<SIZER_12>();
			NativeSlice<SIZER_12> nativeSlice3 = new NativeSlice<SIZER_12>(vertexData3);
			nativeSlice3.SliceWithStride<Vector2>(0);
			nativeSlice3.SliceWithStride<Vector3>(0);
			nativeSlice3.SliceWithStride<Vector4>(0);
			nativeSlice3.SliceWithStride<Color32>(0);
			NativeArray<SIZER_16> vertexData4 = m.GetVertexData<SIZER_16>();
			NativeSlice<SIZER_16> nativeSlice4 = new NativeSlice<SIZER_16>(vertexData4);
			nativeSlice4.SliceWithStride<Vector2>(0);
			nativeSlice4.SliceWithStride<Vector3>(0);
			nativeSlice4.SliceWithStride<Vector4>(0);
			nativeSlice4.SliceWithStride<Color32>(0);
			NativeArray<SIZER_20> vertexData5 = m.GetVertexData<SIZER_20>();
			NativeSlice<SIZER_20> nativeSlice5 = new NativeSlice<SIZER_20>(vertexData5);
			nativeSlice5.SliceWithStride<Vector2>(0);
			nativeSlice5.SliceWithStride<Vector3>(0);
			nativeSlice5.SliceWithStride<Vector4>(0);
			nativeSlice5.SliceWithStride<Color32>(0);
			NativeArray<SIZER_24> vertexData6 = m.GetVertexData<SIZER_24>();
			NativeSlice<SIZER_24> nativeSlice6 = new NativeSlice<SIZER_24>(vertexData6);
			nativeSlice6.SliceWithStride<Vector2>(0);
			nativeSlice6.SliceWithStride<Vector3>(0);
			nativeSlice6.SliceWithStride<Vector4>(0);
			nativeSlice6.SliceWithStride<Color32>(0);
			NativeArray<SIZER_28> vertexData7 = m.GetVertexData<SIZER_28>();
			NativeSlice<SIZER_28> nativeSlice7 = new NativeSlice<SIZER_28>(vertexData7);
			nativeSlice7.SliceWithStride<Vector2>(0);
			nativeSlice7.SliceWithStride<Vector3>(0);
			nativeSlice7.SliceWithStride<Vector4>(0);
			nativeSlice7.SliceWithStride<Color32>(0);
			NativeArray<SIZER_32> vertexData8 = m.GetVertexData<SIZER_32>();
			NativeSlice<SIZER_32> nativeSlice8 = new NativeSlice<SIZER_32>(vertexData8);
			nativeSlice8.SliceWithStride<Vector2>(0);
			nativeSlice8.SliceWithStride<Vector3>(0);
			nativeSlice8.SliceWithStride<Vector4>(0);
			nativeSlice8.SliceWithStride<Color32>(0);
			NativeArray<SIZER_36> vertexData9 = m.GetVertexData<SIZER_36>();
			NativeSlice<SIZER_36> nativeSlice9 = new NativeSlice<SIZER_36>(vertexData9);
			nativeSlice9.SliceWithStride<Vector2>(0);
			nativeSlice9.SliceWithStride<Vector3>(0);
			nativeSlice9.SliceWithStride<Vector4>(0);
			nativeSlice9.SliceWithStride<Color32>(0);
			NativeArray<SIZER_40> vertexData10 = m.GetVertexData<SIZER_40>();
			NativeSlice<SIZER_40> nativeSlice10 = new NativeSlice<SIZER_40>(vertexData10);
			nativeSlice10.SliceWithStride<Vector2>(0);
			nativeSlice10.SliceWithStride<Vector3>(0);
			nativeSlice10.SliceWithStride<Vector4>(0);
			nativeSlice10.SliceWithStride<Color32>(0);
			NativeArray<SIZER_44> vertexData11 = m.GetVertexData<SIZER_44>();
			NativeSlice<SIZER_44> nativeSlice11 = new NativeSlice<SIZER_44>(vertexData11);
			nativeSlice11.SliceWithStride<Vector2>(0);
			nativeSlice11.SliceWithStride<Vector3>(0);
			nativeSlice11.SliceWithStride<Vector4>(0);
			nativeSlice11.SliceWithStride<Color32>(0);
			NativeArray<SIZER_48> vertexData12 = m.GetVertexData<SIZER_48>();
			NativeSlice<SIZER_48> nativeSlice12 = new NativeSlice<SIZER_48>(vertexData12);
			nativeSlice12.SliceWithStride<Vector2>(0);
			nativeSlice12.SliceWithStride<Vector3>(0);
			nativeSlice12.SliceWithStride<Vector4>(0);
			nativeSlice12.SliceWithStride<Color32>(0);
			NativeArray<SIZER_52> vertexData13 = m.GetVertexData<SIZER_52>();
			NativeSlice<SIZER_52> nativeSlice13 = new NativeSlice<SIZER_52>(vertexData13);
			nativeSlice13.SliceWithStride<Vector2>(0);
			nativeSlice13.SliceWithStride<Vector3>(0);
			nativeSlice13.SliceWithStride<Vector4>(0);
			nativeSlice13.SliceWithStride<Color32>(0);
			NativeArray<SIZER_56> vertexData14 = m.GetVertexData<SIZER_56>();
			NativeSlice<SIZER_56> nativeSlice14 = new NativeSlice<SIZER_56>(vertexData14);
			nativeSlice14.SliceWithStride<Vector2>(0);
			nativeSlice14.SliceWithStride<Vector3>(0);
			nativeSlice14.SliceWithStride<Vector4>(0);
			nativeSlice14.SliceWithStride<Color32>(0);
			NativeArray<SIZER_60> vertexData15 = m.GetVertexData<SIZER_60>();
			NativeSlice<SIZER_60> nativeSlice15 = new NativeSlice<SIZER_60>(vertexData15);
			nativeSlice15.SliceWithStride<Vector2>(0);
			nativeSlice15.SliceWithStride<Vector3>(0);
			nativeSlice15.SliceWithStride<Vector4>(0);
			nativeSlice15.SliceWithStride<Color32>(0);
			NativeArray<SIZER_64> vertexData16 = m.GetVertexData<SIZER_64>();
			NativeSlice<SIZER_64> nativeSlice16 = new NativeSlice<SIZER_64>(vertexData16);
			nativeSlice16.SliceWithStride<Vector2>(0);
			nativeSlice16.SliceWithStride<Vector3>(0);
			nativeSlice16.SliceWithStride<Vector4>(0);
			nativeSlice16.SliceWithStride<Color32>(0);
			NativeArray<SIZER_68> vertexData17 = m.GetVertexData<SIZER_68>();
			NativeSlice<SIZER_68> nativeSlice17 = new NativeSlice<SIZER_68>(vertexData17);
			nativeSlice17.SliceWithStride<Vector2>(0);
			nativeSlice17.SliceWithStride<Vector3>(0);
			nativeSlice17.SliceWithStride<Vector4>(0);
			nativeSlice17.SliceWithStride<Color32>(0);
			NativeArray<SIZER_72> vertexData18 = m.GetVertexData<SIZER_72>();
			NativeSlice<SIZER_72> nativeSlice18 = new NativeSlice<SIZER_72>(vertexData18);
			nativeSlice18.SliceWithStride<Vector2>(0);
			nativeSlice18.SliceWithStride<Vector3>(0);
			nativeSlice18.SliceWithStride<Vector4>(0);
			nativeSlice18.SliceWithStride<Color32>(0);
			NativeArray<SIZER_76> vertexData19 = m.GetVertexData<SIZER_76>();
			NativeSlice<SIZER_76> nativeSlice19 = new NativeSlice<SIZER_76>(vertexData19);
			nativeSlice19.SliceWithStride<Vector2>(0);
			nativeSlice19.SliceWithStride<Vector3>(0);
			nativeSlice19.SliceWithStride<Vector4>(0);
			nativeSlice19.SliceWithStride<Color32>(0);
			NativeArray<SIZER_80> vertexData20 = m.GetVertexData<SIZER_80>();
			NativeSlice<SIZER_80> nativeSlice20 = new NativeSlice<SIZER_80>(vertexData20);
			nativeSlice20.SliceWithStride<Vector2>(0);
			nativeSlice20.SliceWithStride<Vector3>(0);
			nativeSlice20.SliceWithStride<Vector4>(0);
			nativeSlice20.SliceWithStride<Color32>(0);
			NativeArray<SIZER_84> vertexData21 = m.GetVertexData<SIZER_84>();
			NativeSlice<SIZER_84> nativeSlice21 = new NativeSlice<SIZER_84>(vertexData21);
			nativeSlice21.SliceWithStride<Vector2>(0);
			nativeSlice21.SliceWithStride<Vector3>(0);
			nativeSlice21.SliceWithStride<Vector4>(0);
			nativeSlice21.SliceWithStride<Color32>(0);
			NativeArray<SIZER_88> vertexData22 = m.GetVertexData<SIZER_88>();
			NativeSlice<SIZER_88> nativeSlice22 = new NativeSlice<SIZER_88>(vertexData22);
			nativeSlice22.SliceWithStride<Vector2>(0);
			nativeSlice22.SliceWithStride<Vector3>(0);
			nativeSlice22.SliceWithStride<Vector4>(0);
			nativeSlice22.SliceWithStride<Color32>(0);
			NativeArray<SIZER_92> vertexData23 = m.GetVertexData<SIZER_92>();
			NativeSlice<SIZER_92> nativeSlice23 = new NativeSlice<SIZER_92>(vertexData23);
			nativeSlice23.SliceWithStride<Vector2>(0);
			nativeSlice23.SliceWithStride<Vector3>(0);
			nativeSlice23.SliceWithStride<Vector4>(0);
			nativeSlice23.SliceWithStride<Color32>(0);
			NativeArray<SIZER_96> vertexData24 = m.GetVertexData<SIZER_96>();
			NativeSlice<SIZER_96> nativeSlice24 = new NativeSlice<SIZER_96>(vertexData24);
			nativeSlice24.SliceWithStride<Vector2>(0);
			nativeSlice24.SliceWithStride<Vector3>(0);
			nativeSlice24.SliceWithStride<Vector4>(0);
			nativeSlice24.SliceWithStride<Color32>(0);
			NativeArray<SIZER_100> vertexData25 = m.GetVertexData<SIZER_100>();
			NativeSlice<SIZER_100> nativeSlice25 = new NativeSlice<SIZER_100>(vertexData25);
			nativeSlice25.SliceWithStride<Vector2>(0);
			nativeSlice25.SliceWithStride<Vector3>(0);
			nativeSlice25.SliceWithStride<Vector4>(0);
			nativeSlice25.SliceWithStride<Color32>(0);
			NativeArray<SIZER_104> vertexData26 = m.GetVertexData<SIZER_104>();
			NativeSlice<SIZER_104> nativeSlice26 = new NativeSlice<SIZER_104>(vertexData26);
			nativeSlice26.SliceWithStride<Vector2>(0);
			nativeSlice26.SliceWithStride<Vector3>(0);
			nativeSlice26.SliceWithStride<Vector4>(0);
			nativeSlice26.SliceWithStride<Color32>(0);
			NativeArray<SIZER_108> vertexData27 = m.GetVertexData<SIZER_108>();
			NativeSlice<SIZER_108> nativeSlice27 = new NativeSlice<SIZER_108>(vertexData27);
			nativeSlice27.SliceWithStride<Vector2>(0);
			nativeSlice27.SliceWithStride<Vector3>(0);
			nativeSlice27.SliceWithStride<Vector4>(0);
			nativeSlice27.SliceWithStride<Color32>(0);
			NativeArray<SIZER_112> vertexData28 = m.GetVertexData<SIZER_112>();
			NativeSlice<SIZER_112> nativeSlice28 = new NativeSlice<SIZER_112>(vertexData28);
			nativeSlice28.SliceWithStride<Vector2>(0);
			nativeSlice28.SliceWithStride<Vector3>(0);
			nativeSlice28.SliceWithStride<Vector4>(0);
			nativeSlice28.SliceWithStride<Color32>(0);
			NativeArray<SIZER_116> vertexData29 = m.GetVertexData<SIZER_116>();
			NativeSlice<SIZER_116> nativeSlice29 = new NativeSlice<SIZER_116>(vertexData29);
			nativeSlice29.SliceWithStride<Vector2>(0);
			nativeSlice29.SliceWithStride<Vector3>(0);
			nativeSlice29.SliceWithStride<Vector4>(0);
			nativeSlice29.SliceWithStride<Color32>(0);
			NativeArray<SIZER_120> vertexData30 = m.GetVertexData<SIZER_120>();
			NativeSlice<SIZER_120> nativeSlice30 = new NativeSlice<SIZER_120>(vertexData30);
			nativeSlice30.SliceWithStride<Vector2>(0);
			nativeSlice30.SliceWithStride<Vector3>(0);
			nativeSlice30.SliceWithStride<Vector4>(0);
			nativeSlice30.SliceWithStride<Color32>(0);
			NativeArray<SIZER_124> vertexData31 = m.GetVertexData<SIZER_124>();
			NativeSlice<SIZER_124> nativeSlice31 = new NativeSlice<SIZER_124>(vertexData31);
			nativeSlice31.SliceWithStride<Vector2>(0);
			nativeSlice31.SliceWithStride<Vector3>(0);
			nativeSlice31.SliceWithStride<Vector4>(0);
			nativeSlice31.SliceWithStride<Color32>(0);
			NativeArray<SIZER_128> vertexData32 = m.GetVertexData<SIZER_128>();
			NativeSlice<SIZER_128> nativeSlice32 = new NativeSlice<SIZER_128>(vertexData32);
			nativeSlice32.SliceWithStride<Vector2>(0);
			nativeSlice32.SliceWithStride<Vector3>(0);
			nativeSlice32.SliceWithStride<Vector4>(0);
			nativeSlice32.SliceWithStride<Color32>(0);
			NativeArray<SIZER_132> vertexData33 = m.GetVertexData<SIZER_132>();
			NativeSlice<SIZER_132> nativeSlice33 = new NativeSlice<SIZER_132>(vertexData33);
			nativeSlice33.SliceWithStride<Vector2>(0);
			nativeSlice33.SliceWithStride<Vector3>(0);
			nativeSlice33.SliceWithStride<Vector4>(0);
			nativeSlice33.SliceWithStride<Color32>(0);
			NativeArray<SIZER_136> vertexData34 = m.GetVertexData<SIZER_136>();
			NativeSlice<SIZER_136> nativeSlice34 = new NativeSlice<SIZER_136>(vertexData34);
			nativeSlice34.SliceWithStride<Vector2>(0);
			nativeSlice34.SliceWithStride<Vector3>(0);
			nativeSlice34.SliceWithStride<Vector4>(0);
			nativeSlice34.SliceWithStride<Color32>(0);
			NativeArray<SIZER_140> vertexData35 = m.GetVertexData<SIZER_140>();
			NativeSlice<SIZER_140> nativeSlice35 = new NativeSlice<SIZER_140>(vertexData35);
			nativeSlice35.SliceWithStride<Vector2>(0);
			nativeSlice35.SliceWithStride<Vector3>(0);
			nativeSlice35.SliceWithStride<Vector4>(0);
			nativeSlice35.SliceWithStride<Color32>(0);
			NativeArray<SIZER_144> vertexData36 = m.GetVertexData<SIZER_144>();
			NativeSlice<SIZER_144> nativeSlice36 = new NativeSlice<SIZER_144>(vertexData36);
			nativeSlice36.SliceWithStride<Vector2>(0);
			nativeSlice36.SliceWithStride<Vector3>(0);
			nativeSlice36.SliceWithStride<Vector4>(0);
			nativeSlice36.SliceWithStride<Color32>(0);
			NativeArray<SIZER_148> vertexData37 = m.GetVertexData<SIZER_148>();
			NativeSlice<SIZER_148> nativeSlice37 = new NativeSlice<SIZER_148>(vertexData37);
			nativeSlice37.SliceWithStride<Vector2>(0);
			nativeSlice37.SliceWithStride<Vector3>(0);
			nativeSlice37.SliceWithStride<Vector4>(0);
			nativeSlice37.SliceWithStride<Color32>(0);
			NativeArray<SIZER_152> vertexData38 = m.GetVertexData<SIZER_152>();
			NativeSlice<SIZER_152> nativeSlice38 = new NativeSlice<SIZER_152>(vertexData38);
			nativeSlice38.SliceWithStride<Vector2>(0);
			nativeSlice38.SliceWithStride<Vector3>(0);
			nativeSlice38.SliceWithStride<Vector4>(0);
			nativeSlice38.SliceWithStride<Color32>(0);
		}

		public static int CalcStride(MB_MeshVertexChannelFlags channels, int uvChannelWithExtraParameter, out int strideVertexBuffer, out int strideUVbuffer)
		{
			strideVertexBuffer = 0;
			strideUVbuffer = 0;
			if ((channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				strideVertexBuffer += 12;
			}
			if ((channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				strideVertexBuffer += 12;
			}
			if ((channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				strideVertexBuffer += 16;
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				strideUVbuffer += 16;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				strideUVbuffer += 8;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				strideUVbuffer += 8;
			}
			_ = channels & MB_MeshVertexChannelFlags.blendWeight;
			_ = 8192;
			if (uvChannelWithExtraParameter >= 0)
			{
				strideUVbuffer += 4;
			}
			return strideVertexBuffer + strideUVbuffer;
		}

		public static void Init(MB_MeshVertexChannelFlags channels, VertexAttributeDescriptor[] vertexAttributes, ref VertexAndTriangleProcessorNativeArray nativeSlices, int vertexCount, int[] submeshCount, int uvChannelWithExtraParameter)
		{
			CalcStride(channels, uvChannelWithExtraParameter, out var strideVertexBuffer, out var strideUVbuffer);
			int num = 0;
			int num2 = 0;
			int stream = 1;
			int stream2 = 2;
			int num3 = 0;
			num2 = num3;
			num++;
			num3++;
			if (strideUVbuffer > 0)
			{
				stream = num3;
				num3++;
				num++;
			}
			int num4 = 0;
			if ((channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.Position, VertexAttributeFormat.Float32, 3, num2);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.Normal, VertexAttributeFormat.Float32, 3, num2);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.Tangent, VertexAttributeFormat.Float32, 4, num2);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.Color, VertexAttributeFormat.Float32, 4, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				int dimension = ((uvChannelWithExtraParameter == 0) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord0, VertexAttributeFormat.Float32, dimension, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				int dimension2 = ((uvChannelWithExtraParameter == 1) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord1, VertexAttributeFormat.Float32, dimension2, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				int dimension3 = ((uvChannelWithExtraParameter == 2) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord2, VertexAttributeFormat.Float32, dimension3, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				int dimension4 = ((uvChannelWithExtraParameter == 3) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord3, VertexAttributeFormat.Float32, dimension4, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				int dimension5 = ((uvChannelWithExtraParameter == 4) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord4, VertexAttributeFormat.Float32, dimension5, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				int dimension6 = ((uvChannelWithExtraParameter == 5) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord5, VertexAttributeFormat.Float32, dimension6, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				int dimension7 = ((uvChannelWithExtraParameter == 6) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord6, VertexAttributeFormat.Float32, dimension7, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				int dimension8 = ((uvChannelWithExtraParameter == 7) ? 3 : 2);
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.TexCoord7, VertexAttributeFormat.Float32, dimension8, stream);
				num4++;
			}
			if ((channels & MB_MeshVertexChannelFlags.blendWeight) == MB_MeshVertexChannelFlags.blendWeight)
			{
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.BlendWeight, VertexAttributeFormat.UNorm16, 4, stream2);
				num4++;
				vertexAttributes[num4] = new VertexAttributeDescriptor(VertexAttribute.BlendIndices, VertexAttributeFormat.UInt16, 4, stream2);
				num4++;
			}
			AllocateWriteableMeshData(ref nativeSlices, vertexAttributes, vertexCount, num);
			SetupNativeSlices(ref nativeSlices, strideVertexBuffer, strideUVbuffer, uvChannelWithExtraParameter);
			nativeSlices.triangleBuffer = nativeSlices.data.GetIndexData<ushort>();
		}

		public static void AllocateWriteableMeshData(ref VertexAndTriangleProcessorNativeArray nativeSlices, VertexAttributeDescriptor[] channels, int vertexCount, int numBuffers)
		{
			nativeSlices.dataArray = Mesh.AllocateWritableMeshData(1);
			nativeSlices.dataArrayAllocated = true;
			nativeSlices.data = nativeSlices.dataArray[0];
			if (nativeSlices.LOG_LEVEL >= MB2_LogLevel.debug)
			{
				string text = "Allocating VertexChannels for combined mesh: ";
				for (int i = 0; i < channels.Length; i++)
				{
					string text2 = text;
					VertexAttributeDescriptor vertexAttributeDescriptor = channels[i];
					text = text2 + "\n   " + vertexAttributeDescriptor.ToString();
				}
				UnityEngine.Debug.Log(text);
			}
			nativeSlices.data.SetVertexBufferParams(vertexCount, channels);
		}

		public unsafe static void SetupNativeSlices(ref VertexAndTriangleProcessorNativeArray nativeSlices, int strideVertexData, int strideUVdata, int uvChannelWithExtraParameter)
		{
			ref Mesh.MeshData reference = ref nativeSlices.data;
			nativeSlices.bufferStride_0 = strideVertexData;
			nativeSlices.bufferStride_1 = strideUVdata;
			int num = 0;
			Type type = (nativeSlices.rawSliceSizerType_0 = _TypeForStride[strideVertexData]);
			object obj = reference.GetType().GetMethod("GetVertexData", new Type[1] { typeof(int) }).MakeGenericMethod(type)
				.Invoke(reference, new object[1] { num });
			Type type2 = typeof(NativeSlice<>).MakeGenericType(type);
			nativeSlices.rawSliceVertexStream_0 = Activator.CreateInstance(type2, obj);
			int num2 = (int)nativeSlices.rawSliceVertexStream_0.GetType().GetProperty("Length").GetValue(nativeSlices.rawSliceVertexStream_0, null);
			nativeSlices.vertexCount = num2;
			MethodInfo method = nativeSlices.rawSliceVertexStream_0.GetType().GetMethod("SliceWithStride", new Type[1] { typeof(int) });
			int num3 = 0;
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				MethodInfo methodInfo = method.MakeGenericMethod(typeof(Vector3));
				nativeSlices.verticies = (NativeSlice<Vector3>)methodInfo.Invoke(nativeSlices.rawSliceVertexStream_0, new object[1] { num3 });
				num3 += sizeof(Vector3);
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				MethodInfo methodInfo2 = method.MakeGenericMethod(typeof(Vector3));
				nativeSlices.normals = (NativeSlice<Vector3>)methodInfo2.Invoke(nativeSlices.rawSliceVertexStream_0, new object[1] { num3 });
				num3 += sizeof(Vector3);
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				MethodInfo methodInfo3 = method.MakeGenericMethod(typeof(Vector4));
				nativeSlices.tangents = (NativeSlice<Vector4>)methodInfo3.Invoke(nativeSlices.rawSliceVertexStream_0, new object[1] { num3 });
				num3 += sizeof(Vector4);
			}
			if (strideUVdata <= 0)
			{
				return;
			}
			num++;
			Type type3 = (nativeSlices.rawSliceSizerType_1 = _TypeForStride[strideUVdata]);
			object obj2 = reference.GetType().GetMethod("GetVertexData", new Type[1] { typeof(int) }).MakeGenericMethod(type3)
				.Invoke(reference, new object[1] { num });
			Type type4 = typeof(NativeSlice<>).MakeGenericType(type3);
			nativeSlices.rawSliceVertexStream_1 = Activator.CreateInstance(type4, obj2);
			MethodInfo method2 = nativeSlices.rawSliceVertexStream_1.GetType().GetMethod("SliceWithStride", new Type[1] { typeof(int) });
			int num4 = 0;
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				MethodInfo methodInfo4 = method2.MakeGenericMethod(typeof(Color));
				nativeSlices.colors = (NativeSlice<Color>)methodInfo4.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				num4 += sizeof(Color);
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				MethodInfo methodInfo5 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv0s = (NativeSlice<Vector2>)methodInfo5.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 0)
				{
					methodInfo5 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo5.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo5 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo5.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				MethodInfo methodInfo6 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv2s = (NativeSlice<Vector2>)methodInfo6.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 1)
				{
					methodInfo6 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo6.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo6 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo6.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				MethodInfo methodInfo7 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv3s = (NativeSlice<Vector2>)methodInfo7.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 2)
				{
					methodInfo7 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo7.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo7 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo7.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				MethodInfo methodInfo8 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv4s = (NativeSlice<Vector2>)methodInfo8.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 3)
				{
					methodInfo8 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo8.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo8 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo8.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				MethodInfo methodInfo9 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv5s = (NativeSlice<Vector2>)methodInfo9.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 4)
				{
					methodInfo9 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo9.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo9 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo9.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				MethodInfo methodInfo10 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv6s = (NativeSlice<Vector2>)methodInfo10.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 5)
				{
					methodInfo10 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo10.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo10 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo10.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				MethodInfo methodInfo11 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv7s = (NativeSlice<Vector2>)methodInfo11.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 6)
				{
					methodInfo11 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo11.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo11 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo11.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
			if ((nativeSlices.channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				MethodInfo methodInfo12 = method2.MakeGenericMethod(typeof(Vector2));
				nativeSlices.uv8s = (NativeSlice<Vector2>)methodInfo12.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
				if (uvChannelWithExtraParameter == 7)
				{
					methodInfo12 = method2.MakeGenericMethod(typeof(Vector3));
					nativeSlices.uvsWithExtraIndex = (NativeSlice<Vector3>)methodInfo12.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					methodInfo12 = method2.MakeGenericMethod(typeof(float));
					num4 += sizeof(Vector2);
					nativeSlices.uvsSliceIdx = (NativeSlice<float>)methodInfo12.Invoke(nativeSlices.rawSliceVertexStream_1, new object[1] { num4 });
					num4 += 4;
				}
				else
				{
					num4 += sizeof(Vector2);
				}
			}
		}

		public static void NativeSliceCopyFrom(object toHereSlice, Type toHereSizerType, object fromHereSlice, Type fromHereSizerType)
		{
			Type type = typeof(NativeSlice<>).MakeGenericType(fromHereSizerType);
			type.GetMethod("CopyFrom", new Type[1] { type }).Invoke(toHereSlice, new object[1] { fromHereSlice });
		}

		public static void NativeSliceCopy<T>(NativeSlice<T> srcArray, int srcStartIdx, NativeSlice<T> destArray, int destStartIdx, int length) where T : struct
		{
			NativeSlice<T> slice = srcArray.Slice(srcStartIdx, length);
			destArray.Slice(destStartIdx, length).CopyFrom(slice);
		}

		public static void NativeSliceCopyTo<T>(NativeSlice<T> srcArray, NativeSlice<T> destArray, int destStartIdx) where T : struct
		{
			destArray.Slice(destStartIdx, srcArray.Length).CopyFrom(srcArray);
		}

		static MB_MeshCombinerSingle_MeshNativeArrayHelper()
		{
			Type[] array = new Type[153];
			array[4] = typeof(SIZER_4);
			array[8] = typeof(SIZER_8);
			array[12] = typeof(SIZER_12);
			array[16] = typeof(SIZER_16);
			array[20] = typeof(SIZER_20);
			array[24] = typeof(SIZER_24);
			array[28] = typeof(SIZER_28);
			array[32] = typeof(SIZER_32);
			array[36] = typeof(SIZER_36);
			array[40] = typeof(SIZER_40);
			array[44] = typeof(SIZER_44);
			array[48] = typeof(SIZER_48);
			array[52] = typeof(SIZER_52);
			array[56] = typeof(SIZER_56);
			array[60] = typeof(SIZER_60);
			array[64] = typeof(SIZER_64);
			array[68] = typeof(SIZER_68);
			array[72] = typeof(SIZER_72);
			array[76] = typeof(SIZER_76);
			array[80] = typeof(SIZER_80);
			array[84] = typeof(SIZER_84);
			array[88] = typeof(SIZER_88);
			array[92] = typeof(SIZER_92);
			array[96] = typeof(SIZER_96);
			array[100] = typeof(SIZER_100);
			array[104] = typeof(SIZER_104);
			array[108] = typeof(SIZER_108);
			array[112] = typeof(SIZER_112);
			array[116] = typeof(SIZER_116);
			array[120] = typeof(SIZER_120);
			array[124] = typeof(SIZER_124);
			array[128] = typeof(SIZER_128);
			array[132] = typeof(SIZER_132);
			array[136] = typeof(SIZER_136);
			array[140] = typeof(SIZER_140);
			array[144] = typeof(SIZER_144);
			array[148] = typeof(SIZER_148);
			array[152] = typeof(SIZER_152);
			_TypeForStride = array;
		}
	}

	public struct VertexAndTriangleProcessorNativeArray : IVertexAndTriangleProcessor, IDisposable
	{
		private bool _disposed;

		private bool _isInitialized;

		internal MB2_LogLevel LOG_LEVEL;

		internal VertexAttributeDescriptor[] vertexAttributes;

		internal bool dataArrayAllocated;

		internal Mesh.MeshDataArray dataArray;

		internal Mesh.MeshData data;

		internal int vertexCount;

		internal NativeArray<Vector3> verticiesModified;

		internal NativeSlice<Vector3> verticies;

		internal NativeSlice<Vector3> normals;

		internal NativeSlice<Vector4> tangents;

		internal NativeSlice<Color> colors;

		internal NativeSlice<Vector2> uv0s;

		internal NativeSlice<Vector2> uv2s;

		internal NativeSlice<Vector2> uv3s;

		internal NativeSlice<Vector2> uv4s;

		internal NativeSlice<Vector2> uv5s;

		internal NativeSlice<Vector2> uv6s;

		internal NativeSlice<Vector2> uv7s;

		internal NativeSlice<Vector2> uv8s;

		internal NativeSlice<float> uvsSliceIdx;

		internal NativeSlice<Vector3> uvsWithExtraIndex;

		private SerializableIntArray[] submeshTris;

		internal NativeArray<ushort> triangleBuffer;

		internal int bufferStride_0;

		internal int bufferStride_1;

		internal int bufferStride_2;

		internal Type rawSliceSizerType_0;

		internal Type rawSliceSizerType_1;

		internal object rawSliceVertexStream_0;

		internal object rawSliceVertexStream_1;

		public MB_MeshVertexChannelFlags channels { get; private set; }

		public void Dispose()
		{
			if (!_disposed)
			{
				_isInitialized = false;
				channels = MB_MeshVertexChannelFlags.none;
				if (dataArrayAllocated)
				{
					dataArray.Dispose();
					dataArrayAllocated = false;
				}
				if (verticiesModified.IsCreated)
				{
					verticiesModified.Dispose();
				}
				submeshTris = null;
				_disposed = true;
			}
		}

		public bool IsInitialized()
		{
			return _isInitialized;
		}

		public bool IsDisposed()
		{
			return _disposed;
		}

		public void Init(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int vertexCount, int[] newSubmeshTrisSize, int uvChannelWithExtraParameter, IMeshChannelsCacheTaggingInterface meshChannelsCache, bool loadDataFromCombinedMesh, MB2_LogLevel logLevel)
		{
			channels = newChannels;
			LOG_LEVEL = logLevel;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if ((channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				num++;
			}
			if ((channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				num++;
			}
			if ((channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				num++;
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				num2++;
			}
			if ((channels & MB_MeshVertexChannelFlags.blendWeight) == MB_MeshVertexChannelFlags.blendWeight)
			{
				num3++;
			}
			if ((channels & MB_MeshVertexChannelFlags.blendIndices) == MB_MeshVertexChannelFlags.blendIndices)
			{
				num3++;
			}
			vertexAttributes = new VertexAttributeDescriptor[num + num2 + num3];
			MB_MeshCombinerSingle_MeshNativeArrayHelper.Init(channels, vertexAttributes, ref this, vertexCount, newSubmeshTrisSize, uvChannelWithExtraParameter);
			if (loadDataFromCombinedMesh)
			{
				submeshTris = combiner.submeshTris;
				VertexAndTriangleProcessorNativeArray vertexAndTriangleProcessorNativeArray = default(VertexAndTriangleProcessorNativeArray);
				vertexAndTriangleProcessorNativeArray.InitFromMeshCombiner(combiner, channels, -1);
				if (vertexAndTriangleProcessorNativeArray.bufferStride_0 > 0)
				{
					MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyFrom(rawSliceVertexStream_0, rawSliceSizerType_0, vertexAndTriangleProcessorNativeArray.rawSliceVertexStream_0, vertexAndTriangleProcessorNativeArray.rawSliceSizerType_0);
				}
				if (vertexAndTriangleProcessorNativeArray.bufferStride_1 > 0)
				{
					MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyFrom(rawSliceVertexStream_1, rawSliceSizerType_1, vertexAndTriangleProcessorNativeArray.rawSliceVertexStream_1, vertexAndTriangleProcessorNativeArray.rawSliceSizerType_1);
				}
				if (vertexAndTriangleProcessorNativeArray.data.indexFormat == IndexFormat.UInt16)
				{
					NativeArray<ushort> indexData = vertexAndTriangleProcessorNativeArray.data.GetIndexData<ushort>();
					data.SetIndexBufferParams(indexData.Length, IndexFormat.UInt16);
					data.GetIndexData<ushort>().CopyFrom(indexData);
					data.subMeshCount = vertexAndTriangleProcessorNativeArray.data.subMeshCount;
					for (int i = 0; i < data.subMeshCount; i++)
					{
						SubMeshDescriptor subMesh = vertexAndTriangleProcessorNativeArray.data.GetSubMesh(i);
						data.SetSubMesh(i, subMesh);
					}
				}
				else
				{
					NativeArray<uint> indexData2 = vertexAndTriangleProcessorNativeArray.data.GetIndexData<uint>();
					data.SetIndexBufferParams(indexData2.Length, IndexFormat.UInt32);
					data.GetIndexData<uint>().CopyFrom(indexData2);
					data.subMeshCount = vertexAndTriangleProcessorNativeArray.data.subMeshCount;
					for (int j = 0; j < data.subMeshCount; j++)
					{
						SubMeshDescriptor subMesh2 = vertexAndTriangleProcessorNativeArray.data.GetSubMesh(j);
						data.SetSubMesh(j, subMesh2);
					}
				}
				vertexAndTriangleProcessorNativeArray.Dispose();
			}
			else
			{
				submeshTris = new SerializableIntArray[newSubmeshTrisSize.Length];
				for (int k = 0; k < newSubmeshTrisSize.Length; k++)
				{
					submeshTris[k] = new SerializableIntArray(newSubmeshTrisSize[k]);
				}
			}
			_isInitialized = true;
		}

		public void InitShowHide(MB3_MeshCombinerSingle combiner)
		{
			channels = combiner.channelsLastBake;
			submeshTris = combiner.submeshTris;
			_isInitialized = true;
		}

		public void InitFromMeshCombiner(MB3_MeshCombinerSingle combiner, MB_MeshVertexChannelFlags newChannels, int uvChannelWithExtraParameter)
		{
			if (combiner.channelsLastBake != newChannels)
			{
				if (combiner.channelsLastBake == MB_MeshVertexChannelFlags.none && combiner.verts.Length != 0)
				{
					combiner.channelsLastBake = newChannels;
				}
				else
				{
					UnityEngine.Debug.LogError("Shouldn't change channels between bakes. \n" + combiner.channelsLastBake.ToString() + " \n" + newChannels);
				}
			}
			channels = combiner.channelsLastBake;
			dataArray = Mesh.AcquireReadOnlyMeshData(combiner._mesh);
			dataArrayAllocated = true;
			data = dataArray[0];
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				string text = "Vertex attributes in combined mesh: ";
				for (int i = 0; i < combiner._mesh.vertexAttributeCount; i++)
				{
					VertexAttributeDescriptor vertexAttribute = combiner._mesh.GetVertexAttribute(i);
					string[] obj = new string[5]
					{
						text,
						"\n    ",
						i.ToString(),
						"  VertexAttribute: ",
						null
					};
					VertexAttributeDescriptor vertexAttributeDescriptor = vertexAttribute;
					obj[4] = vertexAttributeDescriptor.ToString();
					text = string.Concat(obj);
				}
				UnityEngine.Debug.Log(text);
			}
			MB_MeshCombinerSingle_MeshNativeArrayHelper.CalcStride(channels, uvChannelWithExtraParameter, out var strideVertexBuffer, out var strideUVbuffer);
			MB_MeshCombinerSingle_MeshNativeArrayHelper.SetupNativeSlices(ref this, strideVertexBuffer, strideUVbuffer, uvChannelWithExtraParameter);
			if (combiner.bufferDataFromPrevious.meshVerticiesWereShifted)
			{
				verticiesModified = new NativeArray<Vector3>(verticies.Length, Allocator.Temp);
				Vector3 meshVerticesShift = combiner.bufferDataFromPrevious.meshVerticesShift;
				for (int j = 0; j < verticies.Length; j++)
				{
					verticiesModified[j] = verticies[j] + meshVerticesShift;
				}
				verticies = verticiesModified.Slice();
			}
			submeshTris = combiner.submeshTris;
			_isInitialized = true;
		}

		public void ApplyDataBufferToMesh(Mesh m)
		{
			data.subMeshCount = 1;
			data.SetSubMesh(0, new SubMeshDescriptor(0, triangleBuffer.Length));
			Mesh.ApplyAndDisposeWritableMeshData(dataArray, m);
			dataArrayAllocated = false;
			m.RecalculateBounds();
		}

		public int GetVertexCount()
		{
			return verticies.Length;
		}

		public int GetSubmeshCount()
		{
			return submeshTris.Length;
		}

		public void TransferOwnershipOfSerializableBuffersToCombiner(MB3_MeshCombinerSingle c, MB_MeshVertexChannelFlags channelsToTransfer, BufferDataFromPreviousBake serializableBufferData)
		{
			c.channelsLastBake = channels;
			c.bufferDataFromPrevious = serializableBufferData;
			c.submeshTris = submeshTris;
			submeshTris = null;
			_isInitialized = false;
		}

		public void CopyArraysFromPreviousBakeBuffersToNewBuffers(MB_DynamicGameObject dgo, ref IVertexAndTriangleProcessor iOldBuffers, int destStartVertIdx, int triangleIdxAdjustment, int[] targSubmeshTidx, MB2_LogLevel LOG_LEVEL)
		{
			VertexAndTriangleProcessorNativeArray vertexAndTriangleProcessorNativeArray = (VertexAndTriangleProcessorNativeArray)(object)iOldBuffers;
			int vertIdx = dgo.vertIdx;
			int numVerts = dgo.numVerts;
			if ((channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.verticies, vertIdx, verticies, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.normals, vertIdx, normals, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.tangents, vertIdx, tangents, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv0s, vertIdx, uv0s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.nuvsSliceIdx) == MB_MeshVertexChannelFlags.nuvsSliceIdx)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uvsSliceIdx, vertIdx, uvsSliceIdx, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv2s, vertIdx, uv2s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv3s, vertIdx, uv3s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv4s, vertIdx, uv4s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv5s, vertIdx, uv5s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv6s, vertIdx, uv6s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv7s, vertIdx, uv7s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.uv8s, vertIdx, uv8s, destStartVertIdx, numVerts);
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopy(vertexAndTriangleProcessorNativeArray.colors, vertIdx, colors, destStartVertIdx, numVerts);
			}
			for (int i = 0; i < submeshTris.Length; i++)
			{
				int[] array = vertexAndTriangleProcessorNativeArray.submeshTris[i].data;
				int num = dgo.submeshTriIdxs[i];
				int num2 = dgo.submeshNumTris[i];
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("    Adjusting submesh triangles submesh:" + i + " startIdx:" + num + " num:" + num2 + " nsubmeshTris:" + submeshTris.Length + " targSubmeshTidx:" + targSubmeshTidx.Length, LOG_LEVEL);
				}
				for (int j = num; j < num + num2; j++)
				{
					array[j] -= triangleIdxAdjustment;
				}
				Array.Copy(array, num, submeshTris[i].data, targSubmeshTidx[i], num2);
			}
		}

		public void CopyFromDGOMeshToBuffers(MB_DynamicGameObject dgo, int destStartVertsIdx, MB_MeshVertexChannelFlags channelsToUpdate, bool updateTris, bool updateBWdata, MB_IMeshBakerSettings settings, MB_IMeshCombinerSingle_BoneProcessor boneProcessor, int[] targSubmeshTidx, MB2_TextureBakeResults textureBakeResults, UVAdjuster_Atlas uvAdjuster, MB2_LogLevel LOG_LEVEL, IMeshChannelsCacheTaggingInterface meshChannelCacheParam)
		{
			MeshChannelsCache_NativeArray meshChannelsCache_NativeArray = (MeshChannelsCache_NativeArray)meshChannelCacheParam;
			bool flag = (channels & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex && (channelsToUpdate & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex;
			bool flag2 = (channels & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal && (channelsToUpdate & MB_MeshVertexChannelFlags.normal) == MB_MeshVertexChannelFlags.normal;
			bool flag3 = (channels & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent && (channelsToUpdate & MB_MeshVertexChannelFlags.tangent) == MB_MeshVertexChannelFlags.tangent;
			if (flag || flag2 || flag3)
			{
				NativeArray<Vector3> nativeArray = default(NativeArray<Vector3>);
				NativeArray<Vector3> nativeArray2 = default(NativeArray<Vector3>);
				NativeArray<Vector4> nativeArray3 = default(NativeArray<Vector4>);
				if (flag)
				{
					nativeArray = meshChannelsCache_NativeArray.GetVerticiesAsNativeArray(dgo._mesh);
				}
				if (flag2)
				{
					nativeArray2 = meshChannelsCache_NativeArray.GetNormalsAsNativeArray(dgo._mesh);
				}
				if (flag3)
				{
					nativeArray3 = meshChannelsCache_NativeArray.GetTangentsAsNativeArray(dgo._mesh);
				}
				if (settings.renderType != MB_RenderType.skinnedMeshRenderer)
				{
					_LocalToWorld(dgo.gameObject.transform, flag2, flag3, destStartVertsIdx, nativeArray, nativeArray2, nativeArray3, verticies, normals, tangents);
				}
				else
				{
					boneProcessor.CopyVertsNormsTansToBuffers(dgo, settings, destStartVertsIdx, nativeArray2, nativeArray3, nativeArray, normals, tangents, verticies);
				}
			}
			if ((channels & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
			{
				_copyAndAdjustUVsFromMesh(textureBakeResults, dgo, dgo._mesh, 0, destStartVertsIdx, uv0s, uvsSliceIdx, meshChannelsCache_NativeArray, LOG_LEVEL, textureBakeResults);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
			{
				_CopyAndAdjustUV2FromMesh(settings, meshChannelsCache_NativeArray, dgo, destStartVertsIdx, LOG_LEVEL);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetUVChannelAsNativeArray(3, dgo._mesh), uv3s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetUVChannelAsNativeArray(4, dgo._mesh), uv4s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetUVChannelAsNativeArray(5, dgo._mesh), uv5s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetUVChannelAsNativeArray(6, dgo._mesh), uv6s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetUVChannelAsNativeArray(7, dgo._mesh), uv7s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8 && (channelsToUpdate & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetUVChannelAsNativeArray(8, dgo._mesh), uv8s, destStartVertsIdx);
			}
			if ((channels & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors && (channelsToUpdate & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
			{
				MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(meshChannelsCache_NativeArray.GetColorsAsNativeArray(dgo._mesh), colors, destStartVertsIdx);
			}
			if (updateBWdata)
			{
				boneProcessor.UpdateGameObjects_UpdateBWIndexes(dgo);
			}
			if (!updateTris)
			{
				return;
			}
			for (int i = 0; i < targSubmeshTidx.Length; i++)
			{
				dgo.submeshTriIdxs[i] = targSubmeshTidx[i];
			}
			for (int j = 0; j < dgo._tmpSubmeshTris.Length; j++)
			{
				int[] array = dgo._tmpSubmeshTris[j].data;
				if (destStartVertsIdx != 0)
				{
					for (int k = 0; k < array.Length; k++)
					{
						array[k] += destStartVertsIdx;
					}
				}
				if (dgo.invertTriangles)
				{
					for (int l = 0; l < array.Length; l += 3)
					{
						int num = array[l];
						array[l] = array[l + 1];
						array[l + 1] = num;
					}
				}
				int num2 = dgo.targetSubmeshIdxs[j];
				array.CopyTo(submeshTris[num2].data, targSubmeshTidx[num2]);
				dgo.submeshNumTris[num2] += array.Length;
				targSubmeshTidx[num2] += array.Length;
			}
		}

		public void AssignBuffersToMesh(Mesh mesh, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, MB_MeshVertexChannelFlags channelsToWriteToMesh, bool doWriteTrisToMesh, IAssignToMeshCustomizer assignToMeshCustomizer, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, out BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
		{
			if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.vertex) == MB_MeshVertexChannelFlags.vertex)
			{
				AdjustVertsToWriteAccordingToPivotPositionIfNecessary(settings.pivotLocationType, settings.renderType, settings.clearBuffersAfterBake, settings.pivotLocation, out serializableBufferData);
			}
			else
			{
				serializableBufferData.numVertsBaked = data.vertexCount;
				serializableBufferData.meshVerticesShift = Vector3.zero;
				serializableBufferData.meshVerticiesWereShifted = false;
			}
			if (assignToMeshCustomizer != null)
			{
				IAssignToMeshCustomizer_NativeArrays assignToMeshCustomizer_NativeArrays = (IAssignToMeshCustomizer_NativeArrays)assignToMeshCustomizer;
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv0) == MB_MeshVertexChannelFlags.uv0)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(0, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv2) == MB_MeshVertexChannelFlags.uv2)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(1, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv3) == MB_MeshVertexChannelFlags.uv3)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(2, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv4) == MB_MeshVertexChannelFlags.uv4)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(3, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv5) == MB_MeshVertexChannelFlags.uv5)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(4, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv6) == MB_MeshVertexChannelFlags.uv6)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(5, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv7) == MB_MeshVertexChannelFlags.uv7)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(6, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.uv8) == MB_MeshVertexChannelFlags.uv8)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_UV(7, settings, textureBakeResults, uvsWithExtraIndex, uvsSliceIdx);
				}
				if ((channelsToWriteToMesh & MB_MeshVertexChannelFlags.colors) == MB_MeshVertexChannelFlags.colors)
				{
					assignToMeshCustomizer_NativeArrays.meshAssign_colors(settings, textureBakeResults, colors, uvsSliceIdx);
				}
			}
			else if (textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.textureArray)
			{
				UnityEngine.Debug.LogError("No AssignToMeshCustomizer was assigned.");
			}
			if (doWriteTrisToMesh)
			{
				AssignTriangleDataForSubmeshes(mesh, mbDynamicObjectsInCombinedMesh, ref serializableBufferData, out submeshTrisToUse, out numNonZeroLengthSubmeshes);
			}
			else
			{
				submeshTrisToUse = null;
				numNonZeroLengthSubmeshes = -1;
			}
			Mesh.ApplyAndDisposeWritableMeshData(dataArray, mesh);
			dataArrayAllocated = false;
		}

		public void AssignTriangleDataForSubmeshes(Mesh mmesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
		{
			submeshTrisToUse = GetSubmeshTrisWithShowHideApplied(mbDynamicObjectsInCombinedMesh);
			numNonZeroLengthSubmeshes = _NumNonZeroLengthSubmeshTris(submeshTrisToUse, out var numIndexes);
			IndexFormat indexFormat = ((numIndexes > 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			data.SetIndexBufferParams(numIndexes, indexFormat);
			if (indexFormat == IndexFormat.UInt16)
			{
				int num = 0;
				int num2 = 0;
				NativeArray<ushort> indexData = data.GetIndexData<ushort>();
				for (int i = 0; i < submeshTrisToUse.Length; i++)
				{
					if (submeshTrisToUse[i].data.Length != 0)
					{
						SerializableIntArray serializableIntArray = submeshTrisToUse[i];
						for (int j = 0; j < serializableIntArray.data.Length; j++)
						{
							indexData[num2 + j] = (ushort)serializableIntArray.data[j];
						}
						num++;
						num2 += serializableIntArray.data.Length;
					}
				}
			}
			else
			{
				int num3 = 0;
				int num4 = 0;
				NativeArray<uint> indexData2 = data.GetIndexData<uint>();
				for (int k = 0; k < submeshTrisToUse.Length; k++)
				{
					if (submeshTrisToUse[k].data.Length != 0)
					{
						SerializableIntArray serializableIntArray2 = submeshTrisToUse[k];
						for (int l = 0; l < serializableIntArray2.data.Length; l++)
						{
							indexData2[num4 + l] = (uint)serializableIntArray2.data[l];
						}
						num3++;
						num4 += serializableIntArray2.data.Length;
					}
				}
			}
			data.subMeshCount = numNonZeroLengthSubmeshes;
			int num5 = 0;
			int num6 = 0;
			for (int m = 0; m < submeshTrisToUse.Length; m++)
			{
				if (submeshTrisToUse[m].data.Length != 0)
				{
					SerializableIntArray serializableIntArray3 = submeshTrisToUse[m];
					SubMeshDescriptor desc = new SubMeshDescriptor(num6, serializableIntArray3.data.Length);
					data.SetSubMesh(num5, desc);
					num5++;
					num6 += serializableIntArray3.data.Length;
				}
			}
		}

		public void AssignTriangleDataForSubmeshes_ShowHide(Mesh mesh, List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, ref BufferDataFromPreviousBake serializableBufferData, out SerializableIntArray[] submeshTrisToUse, out int numNonZeroLengthSubmeshes)
		{
			submeshTrisToUse = GetSubmeshTrisWithShowHideApplied(mbDynamicObjectsInCombinedMesh);
			numNonZeroLengthSubmeshes = _NumNonZeroLengthSubmeshTris(submeshTrisToUse, out var numIndexes);
			IndexFormat indexFormat = ((numIndexes > 65535) ? IndexFormat.UInt32 : IndexFormat.UInt16);
			mesh.subMeshCount = 1;
			mesh.SetIndexBufferParams(numIndexes, indexFormat);
			if (indexFormat == IndexFormat.UInt16)
			{
				int num = 0;
				int num2 = 0;
				NativeArray<ushort> nativeArray = new NativeArray<ushort>(numIndexes, Allocator.Temp);
				for (int i = 0; i < submeshTrisToUse.Length; i++)
				{
					if (submeshTrisToUse[i].data.Length != 0)
					{
						SerializableIntArray serializableIntArray = submeshTrisToUse[i];
						for (int j = 0; j < serializableIntArray.data.Length; j++)
						{
							nativeArray[num2 + j] = (ushort)serializableIntArray.data[j];
						}
						num++;
						num2 += serializableIntArray.data.Length;
					}
				}
				mesh.SetIndexBufferData(nativeArray, 0, 0, nativeArray.Length, MeshUpdateFlags.DontValidateIndices);
				if (nativeArray.IsCreated)
				{
					nativeArray.Dispose();
				}
			}
			else
			{
				int num3 = 0;
				int num4 = 0;
				NativeArray<uint> nativeArray2 = new NativeArray<uint>(numIndexes, Allocator.Temp);
				for (int k = 0; k < submeshTrisToUse.Length; k++)
				{
					if (submeshTrisToUse[k].data.Length != 0)
					{
						SerializableIntArray serializableIntArray2 = submeshTrisToUse[k];
						for (int l = 0; l < serializableIntArray2.data.Length; l++)
						{
							nativeArray2[num4 + l] = (uint)serializableIntArray2.data[l];
						}
						num3++;
						num4 += serializableIntArray2.data.Length;
					}
				}
				mesh.SetIndexBufferData(nativeArray2, 0, 0, nativeArray2.Length, MeshUpdateFlags.DontValidateIndices);
				if (nativeArray2.IsCreated)
				{
					nativeArray2.Dispose();
				}
			}
			mesh.subMeshCount = numNonZeroLengthSubmeshes;
			int num5 = 0;
			int num6 = 0;
			for (int m = 0; m < submeshTrisToUse.Length; m++)
			{
				if (submeshTrisToUse[m].data.Length != 0)
				{
					SerializableIntArray serializableIntArray3 = submeshTrisToUse[m];
					SubMeshDescriptor desc = new SubMeshDescriptor(num6, serializableIntArray3.data.Length);
					mesh.SetSubMesh(num5, desc);
					num5++;
					num6 += serializableIntArray3.data.Length;
				}
			}
		}

		private void AdjustVertsToWriteAccordingToPivotPositionIfNecessary(MB_MeshPivotLocation pivotLocationType, MB_RenderType renderType, bool clearBuffersAfterBake, Vector3 pivotLocation_wld, out BufferDataFromPreviousBake serializableBufferData)
		{
			serializableBufferData.numVertsBaked = data.vertexCount;
			if (verticies.Length > 0)
			{
				if (renderType == MB_RenderType.skinnedMeshRenderer)
				{
					serializableBufferData.meshVerticesShift = Vector3.zero;
					serializableBufferData.meshVerticiesWereShifted = false;
					return;
				}
				switch (pivotLocationType)
				{
				case MB_MeshPivotLocation.worldOrigin:
					serializableBufferData.meshVerticesShift = Vector3.zero;
					serializableBufferData.meshVerticiesWereShifted = false;
					break;
				case MB_MeshPivotLocation.boundsCenter:
				case MB_MeshPivotLocation.customLocation:
				{
					Vector3 vector4;
					if (pivotLocationType == MB_MeshPivotLocation.boundsCenter)
					{
						Vector3 vector = verticies[0];
						Vector3 vector2 = verticies[0];
						for (int i = 1; i < verticies.Length; i++)
						{
							Vector3 vector3 = verticies[i];
							if (vector.x < vector3.x)
							{
								vector.x = vector3.x;
							}
							if (vector.y < vector3.y)
							{
								vector.y = vector3.y;
							}
							if (vector.z < vector3.z)
							{
								vector.z = vector3.z;
							}
							if (vector2.x > vector3.x)
							{
								vector2.x = vector3.x;
							}
							if (vector2.y > vector3.y)
							{
								vector2.y = vector3.y;
							}
							if (vector2.z > vector3.z)
							{
								vector2.z = vector3.z;
							}
						}
						vector4 = (vector + vector2) * 0.5f;
					}
					else
					{
						vector4 = pivotLocation_wld;
					}
					for (int j = 0; j < verticies.Length; j++)
					{
						verticies[j] -= vector4;
					}
					serializableBufferData.meshVerticesShift = vector4;
					serializableBufferData.meshVerticiesWereShifted = true;
					break;
				}
				default:
					UnityEngine.Debug.LogError("Unsupported Pivot Location Type: " + pivotLocationType);
					serializableBufferData.meshVerticesShift = Vector3.zero;
					serializableBufferData.meshVerticiesWereShifted = false;
					break;
				}
			}
			else
			{
				serializableBufferData.meshVerticesShift = Vector3.zero;
				serializableBufferData.meshVerticiesWereShifted = false;
			}
		}

		private static int _NumNonZeroLengthSubmeshTris(SerializableIntArray[] subTris, out int numIndexes)
		{
			numIndexes = 0;
			int num = 0;
			for (int i = 0; i < subTris.Length; i++)
			{
				if (subTris[i].data.Length != 0)
				{
					num++;
					numIndexes += subTris[i].data.Length;
				}
			}
			return num;
		}

		private void _copyAndAdjustUVsFromMesh(MB2_TextureBakeResults tbr, MB_DynamicGameObject dgo, Mesh mesh, int uvChannel, int vertsIdx, NativeSlice<Vector2> uvsOut, NativeSlice<float> uvsSliceIdx, MeshChannelsCache_NativeArray meshChannelsCache, MB2_LogLevel LOG_LEVEL, MB2_TextureBakeResults textureBakeResults)
		{
			NativeArray<Vector2> uVChannelAsNativeArray = meshChannelsCache.GetUVChannelAsNativeArray(uvChannel, mesh);
			int[] array = new int[uVChannelAsNativeArray.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			bool flag = false;
			bool flag2 = tbr.resultType == MB2_TextureBakeResults.ResultType.textureArray;
			for (int j = 0; j < dgo.targetSubmeshIdxs.Length; j++)
			{
				int[] array2 = ((dgo._tmpSubmeshTris == null) ? mesh.GetTriangles(j) : dgo._tmpSubmeshTris[j].data);
				float value = dgo.textureArraySliceIdx[j];
				int idxInSrcMats = dgo.targetSubmeshIdxs[j];
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Build UV transform for mesh {dgo.name} submesh {j} encapsulatingRect {dgo.encapsulatingRect[j]}");
				}
				Rect rect = MB3_TextureCombinerMerging.BuildTransformMeshUV2AtlasRect(textureBakeResults.GetConsiderMeshUVs(idxInSrcMats, dgo.sourceSharedMaterials[j]), dgo.uvRects[j], (dgo.obUVRects == null || dgo.obUVRects.Length == 0) ? new Rect(0f, 0f, 1f, 1f) : dgo.obUVRects[j], dgo.sourceMaterialTiling[j], dgo.encapsulatingRect[j]);
				foreach (int num in array2)
				{
					if (array[num] == -1)
					{
						array[num] = j;
						Vector2 value2 = uVChannelAsNativeArray[num];
						value2.x = rect.x + value2.x * rect.width;
						value2.y = rect.y + value2.y * rect.height;
						int index = vertsIdx + num;
						uvsOut[index] = value2;
						if (flag2)
						{
							uvsSliceIdx[index] = value;
						}
					}
					if (array[num] != j)
					{
						flag = true;
					}
				}
			}
			if (flag && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning(dgo.name + "has submeshes which share verticies. Adjusted uvs may not map correctly in combined atlas.");
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"_copyAndAdjustUVsFromMesh copied {uVChannelAsNativeArray.Length} verts");
			}
		}

		private void _CopyAndAdjustUV2FromMesh(MB_IMeshBakerSettings settings, MeshChannelsCache_NativeArray meshChannelsCache, MB_DynamicGameObject dgo, int vertsIdx, MB2_LogLevel LOG_LEVEL)
		{
			NativeArray<Vector2> nativeArray = meshChannelsCache.GetUVChannelAsNativeArray(2, dgo._mesh);
			if (settings.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
			{
				if (nativeArray.Length == 0)
				{
					NativeArray<Vector2> uVChannelAsNativeArray = meshChannelsCache.GetUVChannelAsNativeArray(0, dgo._mesh);
					if (uVChannelAsNativeArray.Length > 0)
					{
						nativeArray = uVChannelAsNativeArray;
					}
					else
					{
						if (LOG_LEVEL >= MB2_LogLevel.warn)
						{
							UnityEngine.Debug.LogWarning("Mesh " + dgo._mesh?.ToString() + " didn't have uv2s. Generating uv2s.");
						}
						nativeArray = meshChannelsCache.GetUv2ModifiedAsNativeArray(dgo._mesh);
					}
				}
				Vector4 lightmapTilingOffset = dgo.lightmapTilingOffset;
				Vector2 vector = new Vector2(lightmapTilingOffset.x, lightmapTilingOffset.y);
				Vector2 vector2 = new Vector2(lightmapTilingOffset.z, lightmapTilingOffset.w);
				Vector2 vector3 = default(Vector2);
				for (int i = 0; i < nativeArray.Length; i++)
				{
					vector3.x = vector.x * nativeArray[i].x;
					vector3.y = vector.y * nativeArray[i].y;
					uv2s[vertsIdx + i] = vector2 + vector3;
				}
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("_copyAndAdjustUV2FromMesh copied and modify for preserve current lightmapping " + nativeArray.Length);
				}
				return;
			}
			if (nativeArray.Length == 0)
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Mesh " + dgo._mesh?.ToString() + " didn't have uv2s. Generating uv2s.");
				}
				if (settings.lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects && nativeArray.Length == 0)
				{
					UnityEngine.Debug.LogError("Mesh " + dgo._mesh?.ToString() + " did not have a UV2 channel. Nothing to copy when trying to copy UV2 to separate rects. The combined mesh will not lightmap properly. Try using generate new uv2 layout.");
				}
				nativeArray = meshChannelsCache.GetUv2ModifiedAsNativeArray(dgo._mesh);
			}
			MB_MeshCombinerSingle_MeshNativeArrayHelper.NativeSliceCopyTo(nativeArray, uv2s, vertsIdx);
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("_copyAndAdjustUV2FromMesh copied without modifying " + nativeArray.Length);
			}
		}

		public void CopyUV2unchangedToSeparateRects(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, float uv2UnwrappingParamsPackMargin)
		{
			int num = Mathf.CeilToInt(8192f * uv2UnwrappingParamsPackMargin);
			if (num < 1)
			{
				num = 1;
			}
			List<Vector2> list = new List<Vector2>(mbDynamicObjectsInCombinedMesh.Count);
			float[] array = new float[mbDynamicObjectsInCombinedMesh.Count];
			Rect[] array2 = new Rect[mbDynamicObjectsInCombinedMesh.Count];
			float num2 = 0f;
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[i];
				float num3 = 1f;
				if (Application.isEditor && mB_DynamicGameObject._renderer is MeshRenderer)
				{
					num3 = MBVersion.GetScaleInLightmap((MeshRenderer)mB_DynamicGameObject._renderer);
					if (num3 <= 0f)
					{
						num3 = 1f;
					}
				}
				float magnitude = mB_DynamicGameObject.meshSize.magnitude;
				array[i] = num3 * magnitude;
				num2 += array[i];
			}
			for (int j = 0; j < array.Length; j++)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[j];
				int num4 = mB_DynamicGameObject2.vertIdx + mB_DynamicGameObject2.numVerts;
				float x;
				float num5 = (x = uv2s[mB_DynamicGameObject2.vertIdx].x);
				float y;
				float num6 = (y = uv2s[mB_DynamicGameObject2.vertIdx].y);
				for (int k = mB_DynamicGameObject2.vertIdx; k < num4; k++)
				{
					if (uv2s[k].x < num5)
					{
						num5 = uv2s[k].x;
					}
					if (uv2s[k].x > x)
					{
						x = uv2s[k].x;
					}
					if (uv2s[k].y < num6)
					{
						num6 = uv2s[k].y;
					}
					if (uv2s[k].y > y)
					{
						y = uv2s[k].y;
					}
				}
				array2[j] = new Rect(num5, num6, x - num5, y - num6);
				array[j] /= num2;
				Vector2 item = new Vector2(array2[j].width, array2[j].height) * (array[j] * 8192f);
				list.Add(item);
			}
			AtlasPackingResult atlasPackingResult = new MB2_TexturePackerRegular
			{
				atlasMustBePowerOfTwo = false
			}.GetRects(list, 8192, 8192, num)[0];
			Vector2 value = default(Vector2);
			for (int l = 0; l < mbDynamicObjectsInCombinedMesh.Count; l++)
			{
				MB_DynamicGameObject mB_DynamicGameObject3 = mbDynamicObjectsInCombinedMesh[l];
				int num7 = mB_DynamicGameObject3.vertIdx + mB_DynamicGameObject3.numVerts;
				Rect rect = array2[l];
				Rect rect2 = atlasPackingResult.rects[l];
				for (int m = mB_DynamicGameObject3.vertIdx; m < num7; m++)
				{
					value.x = (uv2s[m].x - rect.x) / rect.width * rect2.width + rect2.x;
					value.y = (uv2s[m].y - rect.y) / rect.height * rect2.height + rect2.y;
					uv2s[m] = value;
				}
				if (atlasPackingResult.atlasX == atlasPackingResult.atlasY)
				{
					continue;
				}
				if (atlasPackingResult.atlasX < atlasPackingResult.atlasY)
				{
					float num8 = (float)atlasPackingResult.atlasX / (float)atlasPackingResult.atlasY;
					for (int n = mB_DynamicGameObject3.vertIdx; n < num7; n++)
					{
						Vector2 value2 = uv2s[n];
						value2.x *= num8;
						uv2s[n] = value2;
					}
				}
				else
				{
					float num9 = (float)atlasPackingResult.atlasY / (float)atlasPackingResult.atlasX;
					for (int num10 = mB_DynamicGameObject3.vertIdx; num10 < num7; num10++)
					{
						Vector2 value3 = uv2s[num10];
						value3.y *= num9;
						uv2s[num10] = value3;
					}
				}
			}
		}

		private SerializableIntArray[] GetSubmeshTrisWithShowHideApplied(List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh)
		{
			bool flag = false;
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				if (!mbDynamicObjectsInCombinedMesh[i].show)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int[] array = new int[submeshTris.Length];
				SerializableIntArray[] array2 = new SerializableIntArray[submeshTris.Length];
				for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
				{
					MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[j];
					if (mB_DynamicGameObject.show)
					{
						for (int k = 0; k < mB_DynamicGameObject.submeshNumTris.Length; k++)
						{
							array[k] += mB_DynamicGameObject.submeshNumTris[k];
						}
					}
				}
				for (int l = 0; l < array2.Length; l++)
				{
					array2[l] = new SerializableIntArray(array[l]);
				}
				int[] array3 = new int[array2.Length];
				for (int m = 0; m < mbDynamicObjectsInCombinedMesh.Count; m++)
				{
					MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[m];
					if (!mB_DynamicGameObject2.show)
					{
						continue;
					}
					for (int n = 0; n < submeshTris.Length; n++)
					{
						int[] array4 = submeshTris[n].data;
						int num = mB_DynamicGameObject2.submeshTriIdxs[n];
						int num2 = num + mB_DynamicGameObject2.submeshNumTris[n];
						for (int num3 = num; num3 < num2; num3++)
						{
							array2[n].data[array3[n]] = array4[num3];
							array3[n]++;
						}
					}
				}
				return array2;
			}
			return submeshTris;
		}

		public int[] GetTriangleSizes()
		{
			int[] array = new int[submeshTris.Length];
			for (int i = 0; i < submeshTris.Length; i++)
			{
				array[i] = submeshTris[i].data.Length;
			}
			return array;
		}

		private void _LocalToWorld(Transform t, bool doNorm, bool doTan, int destStartVertsIdx, NativeArray<Vector3> dgoMeshVerts, NativeArray<Vector3> dgoMeshNorms, NativeArray<Vector4> dgoMeshTans, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
		{
			Vector3 lossyScale = t.lossyScale;
			if (lossyScale == Vector3.one)
			{
				_LocalToWorld_TR(t.rotation, t.position, doNorm, doTan, destStartVertsIdx, dgoMeshVerts, dgoMeshNorms, dgoMeshTans, verticies, normals, tangents);
			}
			else if (lossyScale.x > Mathf.Epsilon && lossyScale.y > Mathf.Epsilon && lossyScale.z > Mathf.Epsilon)
			{
				Matrix4x4 wld_X_local = t.localToWorldMatrix;
				_LocalToWorldMatrix_TRS(ref wld_X_local, doNorm, doTan, destStartVertsIdx, dgoMeshVerts, dgoMeshNorms, dgoMeshTans, verticies, normals, tangents);
			}
			else
			{
				_LocalToWorld_TRS(t.rotation, t.position, t.lossyScale, doNorm, doTan, destStartVertsIdx, dgoMeshVerts, dgoMeshNorms, dgoMeshTans, verticies, normals, tangents);
			}
		}

		private static void _LocalToWorldMatrix_TRS(ref Matrix4x4 wld_X_local, bool doNorm, bool doTan, int destStartVertsIdx, NativeSlice<Vector3> dgoMeshVerts, NativeSlice<Vector3> dgoMeshNorms, NativeSlice<Vector4> dgoMeshTans, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
		{
			Matrix4x4 matrix4x = Matrix4x4.zero;
			if (doNorm || doTan)
			{
				matrix4x = wld_X_local;
				float num = (matrix4x[2, 3] = 0f);
				float value = (matrix4x[1, 3] = num);
				matrix4x[0, 3] = value;
				matrix4x = matrix4x.inverse.transpose;
			}
			for (int i = 0; i < dgoMeshVerts.Length; i++)
			{
				int index = destStartVertsIdx + i;
				verticies[index] = wld_X_local.MultiplyPoint3x4(dgoMeshVerts[i]);
				if (doNorm)
				{
					normals[index] = matrix4x.MultiplyPoint3x4(dgoMeshNorms[i]).normalized;
				}
				if (doTan)
				{
					float w = dgoMeshTans[i].w;
					Vector4 value2 = matrix4x.MultiplyPoint3x4(dgoMeshTans[i]).normalized;
					value2.w = w;
					tangents[index] = value2;
				}
			}
		}

		private static void _LocalToWorld_TR(Quaternion wld_Rot_local, Vector3 position_wld, bool doNorm, bool doTan, int destStartVertsIdx, NativeSlice<Vector3> dgoMeshVerts_local, NativeSlice<Vector3> dgoMeshNorms_local, NativeSlice<Vector4> dgoMeshTans_local, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
		{
			for (int i = 0; i < dgoMeshVerts_local.Length; i++)
			{
				int index = destStartVertsIdx + i;
				Vector3 vector = dgoMeshVerts_local[i];
				vector = wld_Rot_local * vector;
				vector += position_wld;
				verticies[index] = vector;
				if (doNorm)
				{
					Vector3 vector2 = dgoMeshNorms_local[i];
					vector2 = wld_Rot_local * vector2;
					normals[index] = vector2;
				}
				if (doTan)
				{
					Vector3 vector3 = dgoMeshTans_local[i];
					float w = dgoMeshTans_local[i].w;
					vector3 = wld_Rot_local * vector3;
					Vector4 value = vector3;
					value.w = w;
					tangents[index] = value;
				}
			}
		}

		private static void _LocalToWorld_TRS(Quaternion wld_Rot_local, Vector3 position_wld, Vector3 scale, bool doNorm, bool doTan, int destStartVertsIdx, NativeSlice<Vector3> dgoMeshVerts_local, NativeSlice<Vector3> dgoMeshNorms_local, NativeSlice<Vector4> dgoMeshTans_local, NativeSlice<Vector3> verticies, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents)
		{
			Vector3 one = Vector3.one;
			if (doNorm || doTan)
			{
				one.x = ((scale.x < Mathf.Epsilon) ? 0f : (1f / scale.x));
				one.y = ((scale.y < Mathf.Epsilon) ? 0f : (1f / scale.y));
				one.z = ((scale.z < Mathf.Epsilon) ? 0f : (1f / scale.z));
			}
			for (int i = 0; i < dgoMeshVerts_local.Length; i++)
			{
				int index = destStartVertsIdx + i;
				Vector3 vector = dgoMeshVerts_local[i];
				vector.x *= scale.x;
				vector.y *= scale.y;
				vector.z *= scale.z;
				vector = wld_Rot_local * vector;
				vector += position_wld;
				verticies[index] = vector;
				if (doNorm)
				{
					Vector3 vector2 = dgoMeshNorms_local[i];
					vector2.x *= one.x;
					vector2.y *= one.y;
					vector2.z *= one.z;
					vector2 = wld_Rot_local * vector2;
					vector2.Normalize();
					normals[index] = vector2;
				}
				if (doTan)
				{
					Vector3 vector3 = dgoMeshTans_local[i];
					float w = dgoMeshTans_local[i].w;
					vector3.x *= one.x;
					vector3.y *= one.y;
					vector3.z *= one.z;
					vector3 = wld_Rot_local * vector3;
					vector3.Normalize();
					tangents[index] = new Vector4(vector3.x, vector3.y, vector3.z, w);
				}
			}
		}
	}

	public Stopwatch db_showHideGameObjects = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_CollectMeshData = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_CollectMeshData_a = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_CollectMeshData_b = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_CollectMeshData_c = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_InitFromMeshCombiner = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_Init = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_CopyArraysFromPreviousBakeBuffersToNewBuffers = new Stopwatch();

	public Stopwatch db_addDeleteGameObjects_CopyFromDGOMeshToBuffers = new Stopwatch();

	public Stopwatch db_apply = new Stopwatch();

	public Stopwatch db_applyShowHide = new Stopwatch();

	public Stopwatch db_updateGameObjects = new Stopwatch();

	[SerializeField]
	protected List<GameObject> objectsInCombinedMesh = new List<GameObject>();

	[SerializeField]
	private int lightmapIndex = -1;

	[SerializeField]
	public List<MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh = new List<MB_DynamicGameObject>();

	private Dictionary<GameObject, MB_DynamicGameObject> _instance2combined_map = new Dictionary<GameObject, MB_DynamicGameObject>();

	[SerializeField]
	private MB_MeshVertexChannelFlags channelsLastBake;

	[SerializeField]
	private Vector3[] verts = new Vector3[0];

	[SerializeField]
	private Vector3[] normals = new Vector3[0];

	[SerializeField]
	private Vector4[] tangents = new Vector4[0];

	[SerializeField]
	private Vector2[] uvs = new Vector2[0];

	[SerializeField]
	private float[] uvsSliceIdx = new float[0];

	[SerializeField]
	private Vector2[] uv2s = new Vector2[0];

	[SerializeField]
	private Vector2[] uv3s = new Vector2[0];

	[SerializeField]
	private Vector2[] uv4s = new Vector2[0];

	[SerializeField]
	private Vector2[] uv5s = new Vector2[0];

	[SerializeField]
	private Vector2[] uv6s = new Vector2[0];

	[SerializeField]
	private Vector2[] uv7s = new Vector2[0];

	[SerializeField]
	private Vector2[] uv8s = new Vector2[0];

	[SerializeField]
	private Color[] colors = new Color[0];

	[SerializeField]
	private SerializableIntArray[] submeshTris = new SerializableIntArray[0];

	[SerializeField]
	private Matrix4x4[] bindPoses = new Matrix4x4[0];

	[SerializeField]
	private Transform[] bones = new Transform[0];

	[SerializeField]
	internal MBBlendShape[] blendShapes = new MBBlendShape[0];

	[SerializeField]
	internal BufferDataFromPreviousBake bufferDataFromPrevious;

	[SerializeField]
	private MeshCreationConditions _meshBirth;

	[SerializeField]
	private Mesh _mesh;

	internal IVertexAndTriangleProcessor _vertexAndTriProcessor;

	protected MB_IMeshCombinerSingle_BoneProcessor _boneProcessor;

	internal MB_MeshCombinerSingle_BlendShapeProcessor _blendShapeProcessor;

	protected IMeshChannelsCacheTaggingInterface _meshChannelsCache;

	private GameObject[] empty = new GameObject[0];

	private int[] emptyIDs = new int[0];

	public override MB2_TextureBakeResults textureBakeResults
	{
		set
		{
			if (GetVertexCount() > 0 && _textureBakeResults != value && _textureBakeResults != null && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("If Texture Bake Result is changed then objects currently in combined mesh may be invalid.");
			}
			_textureBakeResults = value;
		}
	}

	public override MB_RenderType renderType
	{
		set
		{
			if (value == MB_RenderType.skinnedMeshRenderer && _renderType == MB_RenderType.meshRenderer && GetVertexCount() > 0 && (bones == null || bones.Length == 0))
			{
				UnityEngine.Debug.LogError("Can't set the render type to SkinnedMeshRenderer without clearing the mesh first. Try deleting the CombinedMesh scene object.");
			}
			_renderType = value;
		}
	}

	public override GameObject resultSceneObject
	{
		set
		{
			if (_resultSceneObject != value && _resultSceneObject != null)
			{
				_targetRenderer = null;
				if (_mesh != null && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Result Scene Object was changed when this mesh baker component had a reference to a mesh. If mesh is being used by another object make sure to reset the mesh to none before baking to avoid overwriting the other mesh.");
				}
			}
			_resultSceneObject = value;
		}
	}

	public void StartProfile()
	{
		db_showHideGameObjects.Reset();
		db_addDeleteGameObjects.Reset();
		db_apply.Reset();
		db_applyShowHide.Reset();
		db_updateGameObjects.Reset();
	}

	public void PrintProfileInfo()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Timings  " + ((base.settings.meshAPI == MB_MeshCombineAPIType.betaNativeArrayAPI) ? "  newMeshAPI " : " oldMeshAPI"));
		stringBuilder.AppendLine("db_showHideGameObjects " + db_showHideGameObjects.Elapsed.Seconds);
		stringBuilder.AppendLine("db_addDeleteGameObjects " + db_addDeleteGameObjects.Elapsed.Seconds);
		stringBuilder.AppendLine("db_apply " + db_apply.Elapsed.Seconds);
		stringBuilder.AppendLine("db_applyShowHide " + db_applyShowHide.Elapsed.Seconds);
		stringBuilder.AppendLine("db_updateGameObjects " + db_updateGameObjects.Elapsed.Seconds);
		UnityEngine.Debug.Log(stringBuilder.ToString());
	}

	protected override void Dispose(bool disposing)
	{
		if (!IsDisposed())
		{
			base.Dispose(disposing);
			if (_boneProcessor != null)
			{
				_boneProcessor.DisposeOfTemporarySMRData();
				_boneProcessor.Dispose();
				_boneProcessor = null;
			}
			if (_blendShapeProcessor != null)
			{
				_blendShapeProcessor.Dispose();
				_blendShapeProcessor = null;
			}
			if (_meshChannelsCache != null)
			{
				_meshChannelsCache.Dispose();
				_meshChannelsCache = null;
			}
			if (_vertexAndTriProcessor != null)
			{
				_vertexAndTriProcessor.Dispose();
			}
		}
	}

	public int GetVertexCount()
	{
		return verts.Length;
	}

	private MB_DynamicGameObject instance2Combined_MapGet(GameObject gameObjectID)
	{
		return _instance2combined_map[gameObjectID];
	}

	private void instance2Combined_MapAdd(GameObject gameObjectID, MB_DynamicGameObject dgo)
	{
		_instance2combined_map.Add(gameObjectID, dgo);
	}

	private void instance2Combined_MapRemove(GameObject gameObjectID)
	{
		_instance2combined_map.Remove(gameObjectID);
	}

	private bool instance2Combined_MapTryGetValue(GameObject gameObjectID, out MB_DynamicGameObject dgo)
	{
		return _instance2combined_map.TryGetValue(gameObjectID, out dgo);
	}

	private int instance2Combined_MapCount()
	{
		return _instance2combined_map.Count;
	}

	private void instance2Combined_MapClear()
	{
		_instance2combined_map.Clear();
	}

	private bool instance2Combined_MapContainsKey(GameObject gameObjectID)
	{
		return _instance2combined_map.ContainsKey(gameObjectID);
	}

	public bool InstanceID2DGO(int instanceID, out MB_DynamicGameObject dgoGameObject)
	{
		for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
		{
			if (mbDynamicObjectsInCombinedMesh[i].gameObject != null)
			{
				if (mbDynamicObjectsInCombinedMesh[i].gameObject.GetInstanceID() == instanceID)
				{
					dgoGameObject = mbDynamicObjectsInCombinedMesh[i];
					return true;
				}
			}
			else if (mbDynamicObjectsInCombinedMesh[i].instanceID == instanceID)
			{
				dgoGameObject = mbDynamicObjectsInCombinedMesh[i];
				return true;
			}
		}
		UnityEngine.Debug.LogError("Could not find a cached game object matching InstanceID: " + instanceID);
		dgoGameObject = null;
		return false;
	}

	public override int GetNumObjectsInCombined()
	{
		return mbDynamicObjectsInCombinedMesh.Count;
	}

	public override List<GameObject> GetObjectsInCombined()
	{
		List<GameObject> list = new List<GameObject>();
		list.AddRange(objectsInCombinedMesh);
		return list;
	}

	public Mesh GetMesh()
	{
		if (_mesh == null)
		{
			_mesh = _NewMesh();
		}
		return _mesh;
	}

	public MeshCreationConditions SetMesh(Mesh m)
	{
		if (m == null)
		{
			_meshBirth = MeshCreationConditions.NoMesh;
		}
		else
		{
			_meshBirth = MeshCreationConditions.AssignedByUser;
		}
		_mesh = m;
		return _meshBirth;
	}

	public Transform[] GetBones()
	{
		return bones;
	}

	public override int GetLightmapIndex()
	{
		if (base.settings.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout || base.settings.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
		{
			return lightmapIndex;
		}
		return -1;
	}

	private bool _Initialize(int numResultMats)
	{
		if (mbDynamicObjectsInCombinedMesh.Count == 0)
		{
			lightmapIndex = -1;
		}
		if (_mesh == null)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("_initialize Creating new Mesh");
			}
			_mesh = GetMesh();
		}
		if (instance2Combined_MapCount() != mbDynamicObjectsInCombinedMesh.Count)
		{
			instance2Combined_MapClear();
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				if (mbDynamicObjectsInCombinedMesh[i] != null)
				{
					if (mbDynamicObjectsInCombinedMesh[i].gameObject == null)
					{
						UnityEngine.Debug.LogError("This MeshBaker contains information from a previous bake that is incomlete. It may have been baked by a previous version of Mesh Baker. If you are trying to update/modify a previously baked combined mesh. Try doing the original bake.");
						return false;
					}
					instance2Combined_MapAdd(mbDynamicObjectsInCombinedMesh[i].gameObject, mbDynamicObjectsInCombinedMesh[i]);
				}
			}
		}
		if (LOG_LEVEL >= MB2_LogLevel.trace)
		{
			UnityEngine.Debug.Log($"_initialize numObjsInCombined={mbDynamicObjectsInCombinedMesh.Count}");
		}
		return true;
	}

	private bool _collectMaterialTriangles(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map)
	{
		int num = m.subMeshCount;
		if (sharedMaterials.Length < num)
		{
			num = sharedMaterials.Length;
		}
		dgo._tmpSubmeshTris = new SerializableIntArray[num];
		dgo.targetSubmeshIdxs = new int[num];
		for (int i = 0; i < num; i++)
		{
			if (_textureBakeResults.doMultiMaterial || _textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.textureArray)
			{
				if (!sourceMats2submeshIdx_map.Contains(sharedMaterials[i]))
				{
					UnityEngine.Debug.LogError("Object " + dgo.name + " has a material that was not found in the result materials maping. " + sharedMaterials[i]);
					return false;
				}
				dgo.targetSubmeshIdxs[i] = (int)sourceMats2submeshIdx_map[sharedMaterials[i]];
			}
			else
			{
				dgo.targetSubmeshIdxs[i] = 0;
			}
			dgo._tmpSubmeshTris[i] = new SerializableIntArray();
			dgo._tmpSubmeshTris[i].data = m.GetTriangles(i);
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Collecting triangles for: " + dgo.name + " submesh:" + i + " maps to submesh:" + dgo.targetSubmeshIdxs[i] + " added:" + dgo._tmpSubmeshTris[i].data.Length, LOG_LEVEL);
			}
		}
		return true;
	}

	private bool _collectOutOfBoundsUVRects2(Mesh m, MB_DynamicGameObject dgo, Material[] sharedMaterials, OrderedDictionary sourceMats2submeshIdx_map, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResults)
	{
		if (_textureBakeResults == null)
		{
			UnityEngine.Debug.LogError("Need to bake textures into combined material");
			return false;
		}
		if (!meshAnalysisResults.TryGetValue(m.GetInstanceID(), out var value))
		{
			int subMeshCount = m.subMeshCount;
			value = new MB_Utility.MeshAnalysisResult[subMeshCount];
			for (int i = 0; i < subMeshCount; i++)
			{
				_meshChannelsCache.hasOutOfBoundsUVs(m, ref value[i], i);
			}
			meshAnalysisResults.Add(m.GetInstanceID(), value);
		}
		int num = sharedMaterials.Length;
		if (num > m.subMeshCount)
		{
			num = m.subMeshCount;
		}
		dgo.obUVRects = new Rect[num];
		for (int j = 0; j < num; j++)
		{
			int idxInSrcMats = dgo.targetSubmeshIdxs[j];
			if (_textureBakeResults.GetConsiderMeshUVs(idxInSrcMats, sharedMaterials[j]))
			{
				dgo.obUVRects[j] = value[j].uvRect;
			}
		}
		return true;
	}

	private bool _validateTextureBakeResults()
	{
		if (_textureBakeResults == null)
		{
			UnityEngine.Debug.LogError("Texture Bake Results is null. Can't combine meshes.");
			return false;
		}
		if (_textureBakeResults.materialsAndUVRects == null || _textureBakeResults.materialsAndUVRects.Length == 0)
		{
			UnityEngine.Debug.LogError("Texture Bake Results has no materials in material to sourceUVRect map. Try baking materials. Can't combine meshes. If you are trying to combine meshes without combining materials, try removing the Texture Bake Result.");
			return false;
		}
		if (_textureBakeResults.NumResultMaterials() == 0)
		{
			UnityEngine.Debug.LogError("Texture Bake Results has no result materials. Try baking materials. Can't combine meshes.");
			return false;
		}
		return true;
	}

	internal bool _ShowHide(GameObject[] goToShow, GameObject[] goToHide)
	{
		if (goToShow == null)
		{
			goToShow = empty;
		}
		if (goToHide == null)
		{
			goToHide = empty;
		}
		int numResultMats = _textureBakeResults.NumResultMaterials();
		if (!_Initialize(numResultMats))
		{
			return false;
		}
		for (int i = 0; i < goToHide.Length; i++)
		{
			if (!instance2Combined_MapContainsKey(goToHide[i]))
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Trying to hide an object " + goToHide[i]?.ToString() + " that is not in combined mesh. Did you initially bake with 'clear buffers after bake' enabled?");
				}
				return false;
			}
		}
		for (int j = 0; j < goToShow.Length; j++)
		{
			if (!instance2Combined_MapContainsKey(goToShow[j]))
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Trying to show an object " + goToShow[j]?.ToString() + " that is not in combined mesh. Did you initially bake with 'clear buffers after bake' enabled?");
				}
				return false;
			}
		}
		for (int k = 0; k < goToHide.Length; k++)
		{
			_instance2combined_map[goToHide[k]].show = false;
		}
		for (int l = 0; l < goToShow.Length; l++)
		{
			_instance2combined_map[goToShow[l]].show = true;
		}
		if (_vertexAndTriProcessor != null && !_vertexAndTriProcessor.IsDisposed())
		{
			_vertexAndTriProcessor.Dispose();
		}
		bool flag = _UseNativeArrayAPIorNot();
		_vertexAndTriProcessor = Create_VertexAndTriangleProcessor(flag);
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			if (flag)
			{
				UnityEngine.Debug.Log("using NativeArray mesh API");
			}
			else
			{
				UnityEngine.Debug.Log("using simple mesh API");
			}
		}
		bool flag2 = false;
		try
		{
			flag2 = MB_MeshCombinerSingle_SubCombiner._ShowHideGameObjects(this);
			if (flag2)
			{
				_bakeStatus = MeshCombiningStatus.readyForApply;
			}
		}
		catch
		{
			flag2 = false;
			throw;
		}
		return flag2;
	}

	internal bool _AddToCombined(GameObject[] goToAdd, int[] goToDelete, bool disableRendererInSource)
	{
		Stopwatch stopwatch = null;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			stopwatch = new Stopwatch();
			stopwatch.Start();
		}
		if (!_validateTextureBakeResults())
		{
			return false;
		}
		if (!ValidateTargRendererAndMeshAndResultSceneObj())
		{
			return false;
		}
		if (outputOption != MB2_OutputOptions.bakeMeshAssetsInPlace && base.settings.renderType == MB_RenderType.skinnedMeshRenderer && (_targetRenderer == null || !(_targetRenderer is SkinnedMeshRenderer)))
		{
			UnityEngine.Debug.LogError("Target renderer must be set and must be a SkinnedMeshRenderer");
			return false;
		}
		if (base.settings.doBlendShapes && base.settings.renderType != MB_RenderType.skinnedMeshRenderer)
		{
			UnityEngine.Debug.LogError("If doBlendShapes is set then RenderType must be skinnedMeshRenderer.");
			return false;
		}
		GameObject[] array = ((goToAdd != null) ? ((GameObject[])goToAdd.Clone()) : empty);
		int[] array2 = ((goToDelete != null) ? ((int[])goToDelete.Clone()) : emptyIDs);
		if (_mesh == null)
		{
			DestroyMesh();
		}
		int numResultMats = _textureBakeResults.NumResultMaterials();
		if (!_Initialize(numResultMats))
		{
			return false;
		}
		if (_mesh.vertexCount > 0 && _instance2combined_map.Count == 0)
		{
			UnityEngine.Debug.LogWarning("There were vertices in the combined mesh but nothing in the MeshBaker buffers. If you are trying to bake in the editor and modify at runtime, make sure 'Clear Buffers After Bake' is unchecked.");
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("==== Calling _addToCombined objs adding:" + array.Length + " objs deleting:" + array2.Length + " fixOutOfBounds:" + textureBakeResults.DoAnyResultMatsUseConsiderMeshUVs() + " doMultiMaterial:" + textureBakeResults.doMultiMaterial + " disableRenderersInSource:" + disableRendererInSource);
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				for (int i = 0; i < array.Length; i++)
				{
					stringBuilder.AppendLine("    adding obj[" + i + "]=" + array[i]);
				}
				HashSet<int> hashSet = new HashSet<int>(array2);
				for (int j = 0; j < objectsInCombinedMesh.Count; j++)
				{
					if (!hashSet.Contains(objectsInCombinedMesh[j].gameObject.GetInstanceID()))
					{
						stringBuilder.AppendLine("    keeping in combined:" + objectsInCombinedMesh[j]);
					}
					else
					{
						stringBuilder.AppendLine("    deleting in combined:" + objectsInCombinedMesh[j]);
					}
				}
			}
			UnityEngine.Debug.Log(stringBuilder);
		}
		if (_textureBakeResults.NumResultMaterials() == 0)
		{
			UnityEngine.Debug.LogError("No resultMaterials in this TextureBakeResults. Try baking textures.");
			return false;
		}
		if (!base.settings.clearBuffersAfterBake && mbDynamicObjectsInCombinedMesh.Count > 0)
		{
			if (_mesh == null)
			{
				UnityEngine.Debug.LogError("Trying to add and delete to a combined mesh that was previously baked but the mesh is null.");
				return false;
			}
			if (_mesh.vertexCount != bufferDataFromPrevious.numVertsBaked)
			{
				UnityEngine.Debug.LogError("Trying to add and delete to a combined mesh that was previously baked but the mesh vertex count is different. " + _mesh.vertexCount + " != " + bufferDataFromPrevious.numVertsBaked);
				return false;
			}
		}
		OrderedDictionary orderedDictionary = BuildSourceMatsToSubmeshIdxMap(numResultMats);
		if (orderedDictionary == null)
		{
			return false;
		}
		bool uvsSliceIdx_w = base.settings.doUV && textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.textureArray;
		MB_MeshVertexChannelFlags meshChannelsAsFlags = MeshBakerSettingsUtility.GetMeshChannelsAsFlags(base.settings, doVerts: true, uvsSliceIdx_w);
		if (!base.settings.clearBuffersAfterBake && channelsLastBake != MB_MeshVertexChannelFlags.none && mbDynamicObjectsInCombinedMesh.Count > 0 && channelsLastBake != meshChannelsAsFlags)
		{
			UnityEngine.Debug.LogError("There is data in the combined mesh and channels have changed since previous bake. Can't bake:\n channelsLastBake:" + channelsLastBake.ToString() + "\n channels current bake: " + meshChannelsAsFlags);
			return false;
		}
		if (_vertexAndTriProcessor != null && !_vertexAndTriProcessor.IsDisposed())
		{
			_vertexAndTriProcessor.Dispose();
		}
		bool flag = _UseNativeArrayAPIorNot();
		_meshChannelsCache = Create_MeshChannelsCache(flag, LOG_LEVEL, base.settings.lightmapOption);
		_vertexAndTriProcessor = Create_VertexAndTriangleProcessor(flag);
		IVertexAndTriangleProcessor oldMeshData = Create_VertexAndTriangleProcessor(flag);
		_blendShapeProcessor = new MB_MeshCombinerSingle_BlendShapeProcessor(this);
		_boneProcessor = Create_BoneProcessor(flag);
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			if (flag)
			{
				UnityEngine.Debug.Log("using NativeArray mesh API");
			}
			else
			{
				UnityEngine.Debug.Log("using simple mesh API");
			}
		}
		bool flag2 = false;
		try
		{
			return __AddToCombined(array, array2, disableRendererInSource, numResultMats, orderedDictionary, ref oldMeshData, meshChannelsAsFlags, stopwatch);
		}
		catch
		{
			flag2 = false;
			throw;
		}
		finally
		{
			_meshChannelsCache.Dispose();
			_boneProcessor.DisposeOfTemporarySMRData();
			oldMeshData.Dispose();
			for (int k = 0; k < mbDynamicObjectsInCombinedMesh.Count; k++)
			{
				mbDynamicObjectsInCombinedMesh[k].UnInitialize();
			}
		}
	}

	internal bool __AddToCombined(GameObject[] _goToAdd, int[] _goToDelete, bool disableRendererInSource, int numResultMats, OrderedDictionary sourceMats2submeshIdx_map, ref IVertexAndTriangleProcessor oldMeshData, MB_MeshVertexChannelFlags newChannels, Stopwatch sw)
	{
		if (textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.textureArray && base.settings.assignToMeshCustomizer == null)
		{
			UnityEngine.Debug.LogError("Baking combined mesh failed because textures were baked into TextureArrays and no AssignToMeshCustomizer was assigned in the Mesh Baker Settings.");
			return false;
		}
		UVAdjuster_Atlas uVAdjuster_Atlas = new UVAdjuster_Atlas(textureBakeResults, LOG_LEVEL);
		List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
		int i;
		for (i = 0; i < _goToAdd.Length; i++)
		{
			if (!instance2Combined_MapContainsKey(_goToAdd[i]) || Array.FindIndex(_goToDelete, (int o) => o == _goToAdd[i].GetInstanceID()) != -1)
			{
				MB_DynamicGameObject mB_DynamicGameObject = new MB_DynamicGameObject();
				mB_DynamicGameObject.InitializeNew(beingDeleted: false, _goToAdd[i]);
				if (mB_DynamicGameObject._renderer == null)
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.gameObject.name + " does not have a Renderer");
					_goToAdd[i] = null;
					return false;
				}
				Material[] array = mB_DynamicGameObject._renderer.sharedMaterials;
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Getting {array.Length} shared materials for {mB_DynamicGameObject.gameObject}");
				}
				if (array == null)
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.name + " does not have a Renderer");
					_goToAdd[i] = null;
					return false;
				}
				Mesh mesh = mB_DynamicGameObject._mesh;
				if (mesh == null)
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.gameObject.name + " MeshFilter or SkinnedMeshRenderer had no mesh");
					_goToAdd[i] = null;
					return false;
				}
				if (MBVersion.IsRunningAndMeshNotReadWriteable(mesh))
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.gameObject.name + " Mesh Importer has read/write flag set to 'false'. This needs to be set to 'true' in order to read data from this mesh.");
					_goToAdd[i] = null;
					return false;
				}
				if (array.Length > mesh.subMeshCount)
				{
					Array.Resize(ref array, mesh.subMeshCount);
				}
				if (_goToAdd[i] != null)
				{
					list.Add(mB_DynamicGameObject);
					mB_DynamicGameObject.name = $"{_goToAdd[i].ToString()} {_goToAdd[i].GetInstanceID()}";
					mB_DynamicGameObject.instanceID = _goToAdd[i].GetInstanceID();
					mB_DynamicGameObject.gameObject = _goToAdd[i];
					mB_DynamicGameObject.numVerts = mesh.vertexCount;
					mB_DynamicGameObject.sourceSharedMaterials = array;
				}
			}
			else
			{
				if (LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Object " + _goToAdd[i].name + " has already been added. This MeshBaker may have been baked previously with 'Clear Buffers After Bake' unchecked. You can clear the buffers by checking 'Clear Buffers After Bake' and baking. If you want to update a combined mesh by baking several times, you should uncheck 'Clear Buffers After Bake'.");
				}
				_goToAdd[i] = null;
			}
		}
		for (int num = 0; num < mbDynamicObjectsInCombinedMesh.Count; num++)
		{
			if (!mbDynamicObjectsInCombinedMesh[num]._beingDeleted)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[num];
				if (!mB_DynamicGameObject2.Initialize(beingDeleted: false))
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject2.gameObject.name + " does not have a Renderer");
					return false;
				}
			}
		}
		db_addDeleteGameObjects_CollectMeshData.Start();
		db_addDeleteGameObjects_CollectMeshData_a.Start();
		_meshChannelsCache.CollectChannelDataForAllMeshesInList(mbDynamicObjectsInCombinedMesh, list, newChannels, base.settings.renderType, base.settings.doBlendShapes);
		db_addDeleteGameObjects_CollectMeshData_a.Stop();
		int num2 = 0;
		int[] array2 = new int[numResultMats];
		int num3 = 0;
		_boneProcessor.BuildBoneIdx2DGOMapIfNecessary(_goToDelete);
		for (int num4 = 0; num4 < _goToDelete.Length; num4++)
		{
			MB_DynamicGameObject dgoGameObject = null;
			InstanceID2DGO(_goToDelete[num4], out dgoGameObject);
			if (dgoGameObject != null)
			{
				dgoGameObject.Initialize(beingDeleted: true);
				num2 += dgoGameObject.numVerts;
				num3 += dgoGameObject.numBlendShapes;
				if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer)
				{
					_boneProcessor.RemoveBonesForDgosWeAreDeleting(dgoGameObject);
				}
				for (int num5 = 0; num5 < dgoGameObject.submeshNumTris.Length; num5++)
				{
					array2[num5] += dgoGameObject.submeshNumTris[num5];
				}
			}
			else if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Trying to delete an object that is not in combined mesh");
			}
		}
		db_addDeleteGameObjects_CollectMeshData_b.Start();
		for (int num6 = 0; num6 < mbDynamicObjectsInCombinedMesh.Count; num6++)
		{
			if (!mbDynamicObjectsInCombinedMesh[num6]._beingDeleted)
			{
				MB_DynamicGameObject mB_DynamicGameObject3 = mbDynamicObjectsInCombinedMesh[num6];
				if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer && !_boneProcessor.GetCachedSMRMeshData(mB_DynamicGameObject3))
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject3.gameObject.name + " could not retrieve skinning data");
					return false;
				}
			}
		}
		db_addDeleteGameObjects_CollectMeshData_b.Stop();
		db_addDeleteGameObjects_CollectMeshData.Stop();
		Dictionary<int, MB_Utility.MeshAnalysisResult[]> dictionary = new Dictionary<int, MB_Utility.MeshAnalysisResult[]>();
		int num7 = 0;
		int[] array3 = new int[numResultMats];
		int num8 = 0;
		for (int num9 = 0; num9 < list.Count; num9++)
		{
			MB_DynamicGameObject mB_DynamicGameObject4 = list[num9];
			Mesh mesh2 = mB_DynamicGameObject4._mesh;
			Material[] sourceSharedMaterials = mB_DynamicGameObject4.sourceSharedMaterials;
			if (!uVAdjuster_Atlas.MapSharedMaterialsToAtlasRects(sourceSharedMaterials, checkTargetSubmeshIdxsFromPreviousBake: false, mesh2, _meshChannelsCache, dictionary, sourceMats2submeshIdx_map, mB_DynamicGameObject4.gameObject, mB_DynamicGameObject4))
			{
				_goToAdd[num9] = null;
				return false;
			}
			if (!(_goToAdd[num9] != null))
			{
				continue;
			}
			if (base.settings.doBlendShapes)
			{
				mB_DynamicGameObject4.numBlendShapes = mesh2.blendShapeCount;
			}
			Renderer renderer = mB_DynamicGameObject4._renderer;
			if (lightmapIndex == -1)
			{
				lightmapIndex = renderer.lightmapIndex;
			}
			if (base.settings.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
			{
				if (lightmapIndex != renderer.lightmapIndex && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Object " + mB_DynamicGameObject4.gameObject.name + " has a different lightmap index. Lightmapping will not work.");
				}
				if (!MBVersion.GetActive(mB_DynamicGameObject4.gameObject) && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Object " + mB_DynamicGameObject4.gameObject.name + " is inactive. Can only get lightmap index of active objects.");
				}
				if (renderer.lightmapIndex == -1 && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Object " + mB_DynamicGameObject4.gameObject.name + " does not have an index to a lightmap.");
				}
			}
			mB_DynamicGameObject4.lightmapIndex = renderer.lightmapIndex;
			mB_DynamicGameObject4.lightmapTilingOffset = MBVersion.GetLightmapTilingOffset(renderer);
			if (!_collectMaterialTriangles(mesh2, mB_DynamicGameObject4, sourceSharedMaterials, sourceMats2submeshIdx_map))
			{
				return false;
			}
			mB_DynamicGameObject4.meshSize = renderer.bounds.size;
			mB_DynamicGameObject4.submeshNumTris = new int[numResultMats];
			mB_DynamicGameObject4.submeshTriIdxs = new int[numResultMats];
			mB_DynamicGameObject4.sourceSharedMaterials = sourceSharedMaterials;
			if (textureBakeResults.DoAnyResultMatsUseConsiderMeshUVs() && !_collectOutOfBoundsUVRects2(mesh2, mB_DynamicGameObject4, sourceSharedMaterials, sourceMats2submeshIdx_map, dictionary))
			{
				return false;
			}
			if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer)
			{
				db_addDeleteGameObjects_CollectMeshData.Start();
				db_addDeleteGameObjects_CollectMeshData_c.Start();
				if (!_boneProcessor.GetCachedSMRMeshData(mB_DynamicGameObject4))
				{
					return false;
				}
				db_addDeleteGameObjects_CollectMeshData_c.Stop();
				db_addDeleteGameObjects_CollectMeshData.Stop();
			}
			if (base.settings.assignToMeshCustomizer != null)
			{
				if (_UseNativeArrayAPIorNot())
				{
					if (!(base.settings.assignToMeshCustomizer is IAssignToMeshCustomizer_NativeArrays))
					{
						UnityEngine.Debug.LogError("Assign To Mesh Customizer must implement IAssignToMeshCustomizer_NativeArrays");
						return false;
					}
				}
				else if (!(base.settings.assignToMeshCustomizer is IAssignToMeshCustomizer_SimpleAPI))
				{
					UnityEngine.Debug.LogError("Assign To Mesh Customizer must implemennt IAssignToMeshCustomizer_SimpleAPI");
					return false;
				}
			}
			num7 += mB_DynamicGameObject4.numVerts;
			num8 += mB_DynamicGameObject4.numBlendShapes;
			for (int num10 = 0; num10 < mB_DynamicGameObject4._tmpSubmeshTris.Length; num10++)
			{
				array3[mB_DynamicGameObject4.targetSubmeshIdxs[num10]] += mB_DynamicGameObject4._tmpSubmeshTris[num10].data.Length;
			}
			mB_DynamicGameObject4.invertTriangles = IsMirrored(mB_DynamicGameObject4.gameObject.transform.localToWorldMatrix);
		}
		for (int num11 = 0; num11 < _goToAdd.Length; num11++)
		{
			if (_goToAdd[num11] != null && disableRendererInSource)
			{
				MB_Utility.DisableRendererInSource(_goToAdd[num11]);
				if (LOG_LEVEL == MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("Disabling renderer on " + _goToAdd[num11].name + " id=" + _goToAdd[num11].GetInstanceID());
				}
			}
		}
		bool num12 = MB_MeshCombinerSingle_SubCombiner._AddToCombined(this, newChannels, num7, num2, numResultMats, num8, num3, array3, array2, _goToDelete, list, _goToAdd, uVAdjuster_Atlas, ref oldMeshData, sw);
		if (num12)
		{
			_bakeStatus = MeshCombiningStatus.readyForApply;
		}
		return num12;
	}

	private Transform[] _getBones(Renderer r, bool isSkinnedMeshWithBones)
	{
		return MBVersion.GetBones(r, isSkinnedMeshWithBones);
	}

	public override bool Apply(GenerateUV2Delegate uv2GenerationMethod)
	{
		db_apply.Start();
		bool result = MB_MeshCombinerSingle_SubCombiner.Apply(this, uv2GenerationMethod);
		db_apply.Stop();
		return result;
	}

	public virtual void ApplyShowHide()
	{
		db_applyShowHide.Start();
		if (_validationLevel < MB2_ValidationLevel.quick || ValidateTargRendererAndMeshAndResultSceneObj())
		{
			MB_MeshCombinerSingle_SubCombiner.ApplyShowHide(this);
			db_applyShowHide.Stop();
		}
	}

	public override bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
	{
		db_apply.Start();
		bool result = MB_MeshCombinerSingle_SubCombiner.Apply(this, triangles, vertices, normals, tangents, uvs, uv2, uv3, uv4, colors, bones, blendShapesFlag, uv2GenerationMethod);
		db_apply.Stop();
		return result;
	}

	public override bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
	{
		db_apply.Start();
		bool result = MB_MeshCombinerSingle_SubCombiner.Apply(this, triangles, vertices, normals, tangents, uvs, uv2, uv3, uv4, uv5, uv6, uv7, uv8, colors, bones, blendShapesFlag, suppressClearMesh: false, uv2GenerationMethod);
		db_apply.Stop();
		return result;
	}

	public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo)
	{
		db_updateGameObjects.Start();
		bool result = _UpdateGameObjects(gos, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5: false, updateUV6: false, updateUV7: false, updateUV8: false, updateColors, updateSkinningInfo);
		db_updateGameObjects.Stop();
		return result;
	}

	public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
	{
		db_updateGameObjects.Start();
		bool result = _UpdateGameObjects(gos, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5, updateUV6, updateUV7, updateUV8, updateColors, updateSkinningInfo);
		db_updateGameObjects.Stop();
		return result;
	}

	internal bool _UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("UpdateGameObjects called on " + gos.Length + " objects.");
		}
		int numResultMats = 1;
		if (textureBakeResults.doMultiMaterial)
		{
			numResultMats = textureBakeResults.NumResultMaterials();
		}
		if (!_Initialize(numResultMats))
		{
			return false;
		}
		bool uvsSliceIdx_w = base.settings.doUV && textureBakeResults.resultType == MB2_TextureBakeResults.ResultType.textureArray;
		MB_MeshVertexChannelFlags meshChannelsAsFlags = MeshBakerSettingsUtility.GetMeshChannelsAsFlags(base.settings, doVerts: true, uvsSliceIdx_w);
		if (channelsLastBake != meshChannelsAsFlags)
		{
			UnityEngine.Debug.LogError("Channels changed since previous bake. Can't Update GameObjects.");
			return false;
		}
		if (_bakeStatus != MeshCombiningStatus.preAddDeleteOrUpdate)
		{
			UnityEngine.Debug.LogError("Bake Status of combiner was not 'preAddDeleteOrUpdate'. This can happen if AddDeleteGameObjects or UpdateGameObjects is called twice without calling Apply. You can call 'ClearBuffers' to reset the combiner.");
			return false;
		}
		if (_mesh.vertexCount > 0 && _instance2combined_map.Count == 0)
		{
			UnityEngine.Debug.LogWarning("There were vertices in the combined mesh but nothing in the MeshBaker buffers. If you are trying to bake in the editor and modify at runtime, make sure 'Clear Buffers After Bake' is unchecked.");
		}
		if (base.settings.assignToMeshCustomizer != null)
		{
			if (_UseNativeArrayAPIorNot())
			{
				if (!(base.settings.assignToMeshCustomizer is IAssignToMeshCustomizer_NativeArrays))
				{
					UnityEngine.Debug.LogError("Assign To Mesh Customizer must implement IAssignToMeshCustomizer_NativeArrays");
					return false;
				}
			}
			else if (!(base.settings.assignToMeshCustomizer is IAssignToMeshCustomizer_SimpleAPI))
			{
				UnityEngine.Debug.LogError("Assign To Mesh Customizer must implemennt IAssignToMeshCustomizer_SimpleAPI");
				return false;
			}
		}
		UVAdjuster_Atlas uVAdjuster = null;
		OrderedDictionary orderedDictionary = null;
		Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache = null;
		if (updateUV)
		{
			orderedDictionary = BuildSourceMatsToSubmeshIdxMap(numResultMats);
			if (orderedDictionary == null)
			{
				return false;
			}
			uVAdjuster = new UVAdjuster_Atlas(textureBakeResults, LOG_LEVEL);
			meshAnalysisResultsCache = new Dictionary<int, MB_Utility.MeshAnalysisResult[]>();
		}
		if (_vertexAndTriProcessor != null && !_vertexAndTriProcessor.IsDisposed())
		{
			_vertexAndTriProcessor.Dispose();
		}
		_blendShapeProcessor = new MB_MeshCombinerSingle_BlendShapeProcessor(this);
		bool flag = _UseNativeArrayAPIorNot();
		_meshChannelsCache = Create_MeshChannelsCache(flag, LOG_LEVEL, base.settings.lightmapOption);
		_vertexAndTriProcessor = Create_VertexAndTriangleProcessor(flag);
		_boneProcessor = Create_BoneProcessor(flag);
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			if (flag)
			{
				UnityEngine.Debug.Log("using NativeArray mesh API");
			}
			else
			{
				UnityEngine.Debug.Log("using simple mesh API");
			}
		}
		bool flag2 = true;
		try
		{
			return flag2 && __UpdateGameObjects(gos, recalcBounds, meshChannelsAsFlags, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5, updateUV6, updateUV7, updateUV8, updateColors, updateSkinningInfo, meshAnalysisResultsCache, orderedDictionary, uVAdjuster);
		}
		catch
		{
			flag2 = false;
			throw;
		}
		finally
		{
			_meshChannelsCache.Dispose();
			_boneProcessor.DisposeOfTemporarySMRData();
			for (int i = 0; i < mbDynamicObjectsInCombinedMesh.Count; i++)
			{
				MB_DynamicGameObject mB_DynamicGameObject = mbDynamicObjectsInCombinedMesh[i];
				if (mB_DynamicGameObject._initialized)
				{
					mB_DynamicGameObject.UnInitialize();
				}
			}
		}
	}

	private bool __UpdateGameObjects(GameObject[] gos, bool recalcBounds, MB_MeshVertexChannelFlags newChannels, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo, Dictionary<int, MB_Utility.MeshAnalysisResult[]> meshAnalysisResultsCache, OrderedDictionary sourceMats2submeshIdx_map, UVAdjuster_Atlas uVAdjuster)
	{
		List<MB_DynamicGameObject> list = new List<MB_DynamicGameObject>();
		for (int i = 0; i < gos.Length; i++)
		{
			MB_DynamicGameObject mB_DynamicGameObject = _instance2combined_map[gos[i]];
			if (!mB_DynamicGameObject.Initialize(beingDeleted: false))
			{
				UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.name + " could not be initialized");
				return false;
			}
			list.Add(mB_DynamicGameObject);
			if (mB_DynamicGameObject._mesh == null)
			{
				UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.name + " had no renderer");
				return false;
			}
			if (mB_DynamicGameObject._renderer == null)
			{
				UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.name + " had no renderer");
				return false;
			}
			Mesh mesh = mB_DynamicGameObject._mesh;
			if (mB_DynamicGameObject.numVerts != mesh.vertexCount)
			{
				UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject.gameObject.name + " source mesh has been modified since being added. To update it must have the same number of verts");
				return false;
			}
		}
		for (int j = 0; j < mbDynamicObjectsInCombinedMesh.Count; j++)
		{
			if (!mbDynamicObjectsInCombinedMesh[j]._beingDeleted)
			{
				MB_DynamicGameObject mB_DynamicGameObject2 = mbDynamicObjectsInCombinedMesh[j];
				if (!mB_DynamicGameObject2.Initialize(beingDeleted: false))
				{
					UnityEngine.Debug.LogError("Object " + mB_DynamicGameObject2.gameObject.name + " does not have a Renderer");
					return false;
				}
			}
		}
		_meshChannelsCache.CollectChannelDataForAllMeshesInList(mbDynamicObjectsInCombinedMesh, list, newChannels, base.settings.renderType, base.settings.doBlendShapes);
		for (int k = 0; k < gos.Length; k++)
		{
			MB_DynamicGameObject mB_DynamicGameObject3 = _instance2combined_map[gos[k]];
			if (base.settings.doUV && updateUV)
			{
				Material[] sharedMaterials = mB_DynamicGameObject3._renderer.sharedMaterials;
				if (!uVAdjuster.MapSharedMaterialsToAtlasRects(sharedMaterials, checkTargetSubmeshIdxsFromPreviousBake: true, mB_DynamicGameObject3._mesh, _meshChannelsCache, meshAnalysisResultsCache, sourceMats2submeshIdx_map, mB_DynamicGameObject3.gameObject, mB_DynamicGameObject3))
				{
					return false;
				}
			}
		}
		_boneProcessor.BuildBoneIdx2DGOMapIfNecessary(null);
		bool num = MB_MeshCombinerSingle_SubCombiner._UpdateGameObjects(this, list, newChannels, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5, updateUV6, updateUV7, updateUV8, updateColors, updateSkinningInfo, uVAdjuster, LOG_LEVEL);
		if (num && recalcBounds)
		{
			_mesh.RecalculateBounds();
		}
		return num;
	}

	public bool ShowHideGameObjects(GameObject[] toShow, GameObject[] toHide)
	{
		db_showHideGameObjects.Start();
		if (textureBakeResults == null)
		{
			UnityEngine.Debug.LogError("TextureBakeResults must be set.");
			return false;
		}
		bool result = _ShowHide(toShow, toHide);
		db_showHideGameObjects.Stop();
		return result;
	}

	public override bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true)
	{
		db_addDeleteGameObjects.Start();
		int[] array = null;
		if (deleteGOs != null)
		{
			array = new int[deleteGOs.Length];
			for (int i = 0; i < deleteGOs.Length; i++)
			{
				if (deleteGOs[i] == null)
				{
					UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to delete is 'Null'");
				}
				else
				{
					array[i] = deleteGOs[i].GetInstanceID();
				}
			}
		}
		bool result = AddDeleteGameObjectsByID(gos, array, disableRendererInSource);
		db_addDeleteGameObjects.Stop();
		return result;
	}

	public override bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource)
	{
		db_addDeleteGameObjects.Start();
		if (validationLevel > MB2_ValidationLevel.none)
		{
			if (gos != null)
			{
				for (int i = 0; i < gos.Length; i++)
				{
					if (gos[i] == null)
					{
						UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
						return false;
					}
					if (validationLevel < MB2_ValidationLevel.robust)
					{
						continue;
					}
					for (int j = i + 1; j < gos.Length; j++)
					{
						if (gos[i] == gos[j])
						{
							UnityEngine.Debug.LogError("GameObject " + gos[i]?.ToString() + " appears twice in list of game objects to add");
							return false;
						}
					}
				}
			}
			if (deleteGOinstanceIDs != null)
			{
				bool flag = true;
				HashSet<int> hashSet = new HashSet<int>(deleteGOinstanceIDs);
				for (int k = 0; k < mbDynamicObjectsInCombinedMesh.Count; k++)
				{
					if (!hashSet.Contains(mbDynamicObjectsInCombinedMesh[k].instanceID))
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					for (int l = 0; l < mbDynamicObjectsInCombinedMesh.Count; l++)
					{
						if (mbDynamicObjectsInCombinedMesh[l].gameObject == null)
						{
							UnityEngine.Debug.LogError("An instanceID to be deleted does not match any of the cached instanceIDs from the bake and the  corresponding source game object has already been deleted. This can happen if objects were baked, then the scene was saved, closed, opened and a delete bake is attempted. Try deleting a source object from the baked mesh by passing in the source game object instead of the instance ID");
							return false;
						}
						mbDynamicObjectsInCombinedMesh[l].instanceID = mbDynamicObjectsInCombinedMesh[l].gameObject.GetInstanceID();
					}
				}
				if (validationLevel >= MB2_ValidationLevel.robust)
				{
					for (int m = 0; m < deleteGOinstanceIDs.Length; m++)
					{
						for (int n = m + 1; n < deleteGOinstanceIDs.Length; n++)
						{
							if (deleteGOinstanceIDs[m] == deleteGOinstanceIDs[n])
							{
								UnityEngine.Debug.LogError("GameObject " + deleteGOinstanceIDs[m] + "appears twice in list of game objects to delete");
								return false;
							}
						}
					}
				}
			}
		}
		if (_bakeStatus != MeshCombiningStatus.preAddDeleteOrUpdate)
		{
			UnityEngine.Debug.LogError("Bake Status of combiner was not 'preAddDeleteOrUpdate'. This can happen if AddDeleteGameObjects or UpdateGameObjects is called twice without calling Apply. You can call 'ClearBuffers' to reset the combiner.");
			return false;
		}
		if (_usingTemporaryTextureBakeResult && gos != null && gos.Length != 0)
		{
			MB_Utility.Destroy(_textureBakeResults);
			_textureBakeResults = null;
			_usingTemporaryTextureBakeResult = false;
		}
		if (_textureBakeResults == null && gos != null && gos.Length != 0 && gos[0] != null && !_CreateTemporaryTextrueBakeResult(gos, GetMaterialsOnTargetRenderer()))
		{
			return false;
		}
		BuildSceneMeshObject(gos);
		if (!_AddToCombined(gos, deleteGOinstanceIDs, disableRendererInSource))
		{
			UnityEngine.Debug.LogError("Failed to add/delete objects to combined mesh");
			return false;
		}
		db_addDeleteGameObjects.Stop();
		return true;
	}

	public override bool CombinedMeshContains(GameObject go)
	{
		return objectsInCombinedMesh.Contains(go);
	}

	public override void ClearBuffers()
	{
		bones = new Transform[0];
		bindPoses = new Matrix4x4[0];
		blendShapes = new MBBlendShape[0];
		mbDynamicObjectsInCombinedMesh.Clear();
		objectsInCombinedMesh.Clear();
		if (_vertexAndTriProcessor != null && !_vertexAndTriProcessor.IsDisposed())
		{
			_vertexAndTriProcessor.Dispose();
		}
		_vertexAndTriProcessor = Create_VertexAndTriangleProcessor(_UseNativeArrayAPIorNot());
		verts = new Vector3[0];
		normals = new Vector3[0];
		tangents = new Vector4[0];
		uvs = new Vector2[0];
		uvsSliceIdx = new float[0];
		uv2s = new Vector2[0];
		uv3s = new Vector2[0];
		uv4s = new Vector2[0];
		uv5s = new Vector2[0];
		uv6s = new Vector2[0];
		uv7s = new Vector2[0];
		uv8s = new Vector2[0];
		colors = new Color[0];
		submeshTris = new SerializableIntArray[0];
		if (submeshTris != null)
		{
			for (int i = 0; i < submeshTris.Length; i++)
			{
				if (submeshTris[i].data == null)
				{
					submeshTris[i].data = new int[0];
				}
				else if (submeshTris[i].data.Length != 0)
				{
					submeshTris[i].data = new int[0];
				}
			}
			submeshTris = null;
		}
		instance2Combined_MapClear();
		if (_usingTemporaryTextureBakeResult)
		{
			MB_Utility.Destroy(_textureBakeResults);
			_textureBakeResults = null;
			_usingTemporaryTextureBakeResult = false;
		}
		_bakeStatus = MeshCombiningStatus.preAddDeleteOrUpdate;
		if (LOG_LEVEL >= MB2_LogLevel.trace)
		{
			MB2_Log.LogDebug("ClearBuffers called");
		}
	}

	private Mesh _NewMesh()
	{
		if (Application.isPlaying)
		{
			_meshBirth = MeshCreationConditions.CreatedAtRuntime;
		}
		else
		{
			_meshBirth = MeshCreationConditions.CreatedInEditor;
		}
		return new Mesh();
	}

	public override void ClearMesh()
	{
		if (_mesh != null)
		{
			MBVersion.MeshClear(_mesh, t: false);
		}
		else
		{
			_mesh = _NewMesh();
		}
		ClearBuffers();
	}

	public override void ClearMesh(MB2_EditorMethodsInterface editorMethods)
	{
		ClearMesh();
	}

	internal override void _DisposeRuntimeCreated()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (_meshBirth == MeshCreationConditions.CreatedAtRuntime)
		{
			if (!MBVersion.IsAssetInProject(_mesh))
			{
				UnityEngine.Object.Destroy(_mesh);
			}
		}
		else if (_meshBirth == MeshCreationConditions.AssignedByUser)
		{
			_mesh = null;
		}
		ClearBuffers();
	}

	public override void DestroyMesh()
	{
		if (_mesh != null)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Destroying Mesh");
			}
			MB_Utility.Destroy(_mesh);
			_meshBirth = MeshCreationConditions.NoMesh;
		}
		ClearBuffers();
	}

	public override void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods)
	{
		if (_mesh != null && editorMethods != null && !Application.isPlaying)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Destroying Mesh");
			}
			editorMethods.Destroy(_mesh);
		}
		ClearBuffers();
	}

	public bool ValidateTargRendererAndMeshAndResultSceneObj()
	{
		if (_resultSceneObject == null)
		{
			if (_LOG_LEVEL >= MB2_LogLevel.error)
			{
				UnityEngine.Debug.LogError("Result Scene Object was not set.");
			}
			return false;
		}
		if (_targetRenderer == null)
		{
			if (_LOG_LEVEL >= MB2_LogLevel.error)
			{
				UnityEngine.Debug.LogError("Target Renderer was not set.");
			}
			return false;
		}
		if (_resultSceneObject != null && _targetRenderer.transform.parent != _resultSceneObject.transform)
		{
			if (_LOG_LEVEL >= MB2_LogLevel.error)
			{
				UnityEngine.Debug.LogError("Target Renderer game object is not a child of Result Scene Object.");
			}
			return false;
		}
		if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer && !(_targetRenderer is SkinnedMeshRenderer))
		{
			if (_LOG_LEVEL >= MB2_LogLevel.error)
			{
				UnityEngine.Debug.LogError("Render Type is skinned mesh renderer but Target Renderer is not.");
			}
			return false;
		}
		if (base.settings.renderType == MB_RenderType.meshRenderer)
		{
			if (!(_targetRenderer is MeshRenderer))
			{
				if (_LOG_LEVEL >= MB2_LogLevel.error)
				{
					UnityEngine.Debug.LogError("Render Type is mesh renderer but Target Renderer is not.");
				}
				return false;
			}
			MeshFilter component = _targetRenderer.GetComponent<MeshFilter>();
			if (_mesh != component.sharedMesh)
			{
				if (_LOG_LEVEL >= MB2_LogLevel.error)
				{
					UnityEngine.Debug.LogError("Target renderer mesh is not equal to mesh.");
				}
				return false;
			}
		}
		return true;
	}

	private OrderedDictionary BuildSourceMatsToSubmeshIdxMap(int numResultMats)
	{
		OrderedDictionary orderedDictionary = new OrderedDictionary();
		for (int i = 0; i < numResultMats; i++)
		{
			List<Material> sourceMaterialsUsedByResultMaterial = _textureBakeResults.GetSourceMaterialsUsedByResultMaterial(i);
			for (int j = 0; j < sourceMaterialsUsedByResultMaterial.Count; j++)
			{
				if (sourceMaterialsUsedByResultMaterial[j] == null)
				{
					UnityEngine.Debug.LogError("Found null material in source materials for combined mesh materials " + i);
					return null;
				}
				if (!orderedDictionary.Contains(sourceMaterialsUsedByResultMaterial[j]))
				{
					orderedDictionary.Add(sourceMaterialsUsedByResultMaterial[j], i);
				}
			}
		}
		return orderedDictionary;
	}

	internal Renderer BuildSceneHierarchPreBake(MB3_MeshCombinerSingle mom, GameObject root, Mesh m, bool createNewChild = false, GameObject[] objsToBeAdded = null)
	{
		if (mom._LOG_LEVEL >= MB2_LogLevel.trace)
		{
			UnityEngine.Debug.Log("Building Scene Hierarchy createNewChild=" + createNewChild);
		}
		MeshFilter meshFilter = null;
		MeshRenderer meshRenderer = null;
		SkinnedMeshRenderer skinnedMeshRenderer = null;
		Transform transform = null;
		if (root == null)
		{
			UnityEngine.Debug.LogError("root was null.");
			return null;
		}
		if (mom.textureBakeResults == null)
		{
			UnityEngine.Debug.LogError("textureBakeResults must be set.");
			return null;
		}
		if (root.GetComponent<Renderer>() != null)
		{
			UnityEngine.Debug.LogError("root game object cannot have a renderer component");
			return null;
		}
		if (!createNewChild)
		{
			if (mom.targetRenderer != null && mom.targetRenderer.transform.parent == root.transform)
			{
				transform = mom.targetRenderer.transform;
			}
			else
			{
				Renderer[] componentsInChildren = root.GetComponentsInChildren<Renderer>(includeInactive: true);
				if (componentsInChildren.Length == 1)
				{
					if (componentsInChildren[0].transform.parent != root.transform)
					{
						UnityEngine.Debug.LogError("Target Renderer is not an immediate child of Result Scene Object. Try using a game object with no children as the Result Scene Object..");
					}
					transform = componentsInChildren[0].transform;
				}
			}
		}
		if (transform != null && transform.parent != root.transform)
		{
			transform = null;
		}
		GameObject gameObject;
		if (transform == null)
		{
			gameObject = new GameObject(mom.name + "-mesh");
			gameObject.transform.parent = root.transform;
			transform = gameObject.transform;
		}
		transform.parent = root.transform;
		gameObject = transform.gameObject;
		if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer)
		{
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			if (component != null)
			{
				MB_Utility.Destroy(component);
			}
			MeshFilter component2 = gameObject.GetComponent<MeshFilter>();
			if (component2 != null)
			{
				MB_Utility.Destroy(component2);
			}
			skinnedMeshRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
			if (skinnedMeshRenderer == null)
			{
				skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
			}
		}
		else
		{
			SkinnedMeshRenderer component3 = gameObject.GetComponent<SkinnedMeshRenderer>();
			if (component3 != null)
			{
				MB_Utility.Destroy(component3);
			}
			meshFilter = gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = gameObject.AddComponent<MeshFilter>();
			}
			meshRenderer = gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = gameObject.AddComponent<MeshRenderer>();
			}
		}
		if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer)
		{
			skinnedMeshRenderer.bones = mom.GetBones();
			bool updateWhenOffscreen = skinnedMeshRenderer.updateWhenOffscreen;
			skinnedMeshRenderer.updateWhenOffscreen = true;
			skinnedMeshRenderer.updateWhenOffscreen = updateWhenOffscreen;
		}
		_ConfigureSceneHierarch(mom, root, meshRenderer, meshFilter, skinnedMeshRenderer, m, objsToBeAdded);
		if (base.settings.renderType == MB_RenderType.skinnedMeshRenderer)
		{
			return skinnedMeshRenderer;
		}
		return meshRenderer;
	}

	private static void _ConfigureSceneHierarch(MB3_MeshCombinerSingle mom, GameObject root, MeshRenderer mr, MeshFilter mf, SkinnedMeshRenderer smr, Mesh m, GameObject[] objsToBeAdded = null)
	{
		GameObject gameObject;
		if (mom.settings.renderType == MB_RenderType.skinnedMeshRenderer)
		{
			gameObject = smr.gameObject;
			smr.lightmapIndex = mom.GetLightmapIndex();
		}
		else
		{
			gameObject = mr.gameObject;
			mf.sharedMesh = m;
			mom._SetLightmapIndexIfPreserveLightmapping(mr);
		}
		if (mom.settings.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping || mom.settings.lightmapOption == MB2_LightmapOptions.generate_new_UV2_layout)
		{
			gameObject.isStatic = true;
		}
		if (objsToBeAdded == null || objsToBeAdded.Length == 0 || !(objsToBeAdded[0] != null))
		{
			return;
		}
		bool flag = true;
		bool flag2 = true;
		string tag = objsToBeAdded[0].tag;
		int layer = objsToBeAdded[0].layer;
		for (int i = 0; i < objsToBeAdded.Length; i++)
		{
			if (objsToBeAdded[i] != null)
			{
				if (!objsToBeAdded[i].tag.Equals(tag))
				{
					flag = false;
				}
				if (objsToBeAdded[i].layer != layer)
				{
					flag2 = false;
				}
			}
		}
		if (flag)
		{
			root.tag = tag;
			gameObject.tag = tag;
		}
		if (flag2)
		{
			root.layer = layer;
			gameObject.layer = layer;
		}
	}

	private void _SetLightmapIndexIfPreserveLightmapping(Renderer tr)
	{
		tr.lightmapIndex = GetLightmapIndex();
		tr.lightmapScaleOffset = new Vector4(1f, 1f, 0f, 0f);
		if (base.settings.lightmapOption == MB2_LightmapOptions.preserve_current_lightmapping)
		{
			MB_PreserveLightmapData mB_PreserveLightmapData = tr.gameObject.GetComponent<MB_PreserveLightmapData>();
			if (mB_PreserveLightmapData == null)
			{
				mB_PreserveLightmapData = tr.gameObject.AddComponent<MB_PreserveLightmapData>();
			}
			mB_PreserveLightmapData.lightmapIndex = GetLightmapIndex();
			mB_PreserveLightmapData.lightmapScaleOffset = new Vector4(1f, 1f, 0f, 0f);
		}
	}

	public void BuildSceneMeshObject(GameObject[] gos = null, bool createNewChild = false)
	{
		if (_resultSceneObject == null)
		{
			_resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		_targetRenderer = BuildSceneHierarchPreBake(this, _resultSceneObject, GetMesh(), createNewChild, gos);
	}

	private bool IsMirrored(Matrix4x4 tm)
	{
		Vector3 lhs = tm.GetRow(0);
		Vector3 rhs = tm.GetRow(1);
		Vector3 rhs2 = tm.GetRow(2);
		lhs.Normalize();
		rhs.Normalize();
		rhs2.Normalize();
		if (!(Vector3.Dot(Vector3.Cross(lhs, rhs), rhs2) >= 0f))
		{
			return true;
		}
		return false;
	}

	public override void CheckIntegrity()
	{
		if (MB_Utility.DO_INTEGRITY_CHECKS)
		{
			if (_boneProcessor != null)
			{
				_boneProcessor.DB_CheckIntegrity();
			}
			if (base.settings.doBlendShapes && base.settings.renderType != MB_RenderType.skinnedMeshRenderer)
			{
				UnityEngine.Debug.LogError("Blend shapes can only be used with skinned meshes.");
			}
		}
	}

	public override List<Material> GetMaterialsOnTargetRenderer()
	{
		List<Material> list = new List<Material>();
		if (_targetRenderer != null)
		{
			list.AddRange(_targetRenderer.sharedMaterials);
		}
		return list;
	}

	private bool _UseNativeArrayAPIorNot()
	{
		if (base.settings.meshAPI == MB_MeshCombineAPIType.betaNativeArrayAPI)
		{
			return true;
		}
		return false;
	}

	public MB_IMeshCombinerSingle_BoneProcessor Create_BoneProcessor(bool doNativeArrays)
	{
		if (doNativeArrays)
		{
			return new MB_MeshCombinerSingle_BoneProcessorNewAPI(this);
		}
		return new MB_MeshCombinerSingle_BoneProcessor(this);
	}

	public static IVertexAndTriangleProcessor Create_VertexAndTriangleProcessor(bool doNativeArrays)
	{
		IVertexAndTriangleProcessor vertexAndTriangleProcessor = null;
		if (doNativeArrays)
		{
			return default(VertexAndTriangleProcessorNativeArray);
		}
		return default(VertexAndTriangleProcessor);
	}

	public static IMeshChannelsCacheTaggingInterface Create_MeshChannelsCache(bool doNativeArrays, MB2_LogLevel LOG_LEVEL, MB2_LightmapOptions lightmapOption)
	{
		IMeshChannelsCacheTaggingInterface meshChannelsCacheTaggingInterface = null;
		if (doNativeArrays)
		{
			return new MeshChannelsCache_NativeArray(LOG_LEVEL, lightmapOption);
		}
		return new MeshChannelsCache(LOG_LEVEL, lightmapOption);
	}

	public override void UpdateSkinnedMeshApproximateBounds()
	{
		UpdateSkinnedMeshApproximateBoundsFromBounds();
	}

	public override void UpdateSkinnedMeshApproximateBoundsFromBones()
	{
		if (outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBounds when output type is bakeMeshAssetsInPlace");
			}
		}
		else if (bones.Length == 0)
		{
			if (GetVertexCount() > 0 && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("No bones in SkinnedMeshRenderer. Could not UpdateSkinnedMeshApproximateBounds.");
			}
		}
		else if (_targetRenderer == null)
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Target Renderer is not set. No point in calling UpdateSkinnedMeshApproximateBounds.");
			}
		}
		else if (!_targetRenderer.GetType().Equals(typeof(SkinnedMeshRenderer)))
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Target Renderer is not a SkinnedMeshRenderer. No point in calling UpdateSkinnedMeshApproximateBounds.");
			}
		}
		else
		{
			MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBonesStatic(bones, (SkinnedMeshRenderer)targetRenderer);
		}
	}

	public override void UpdateSkinnedMeshApproximateBoundsFromBounds()
	{
		if (outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Can't UpdateSkinnedMeshApproximateBoundsFromBounds when output type is bakeMeshAssetsInPlace");
			}
		}
		else if (GetVertexCount() == 0 || mbDynamicObjectsInCombinedMesh.Count == 0)
		{
			if (GetVertexCount() > 0 && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Nothing in SkinnedMeshRenderer. CoulddoBlendShapes not UpdateSkinnedMeshApproximateBoundsFromBounds.");
			}
		}
		else if (_targetRenderer == null)
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Target Renderer is not set. No point in calling UpdateSkinnedMeshApproximateBoundsFromBounds.");
			}
		}
		else if (!_targetRenderer.GetType().Equals(typeof(SkinnedMeshRenderer)))
		{
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Target Renderer is not a SkinnedMeshRenderer. No point in calling UpdateSkinnedMeshApproximateBoundsFromBounds.");
			}
		}
		else
		{
			MB3_MeshCombiner.UpdateSkinnedMeshApproximateBoundsFromBoundsStatic(objectsInCombinedMesh, (SkinnedMeshRenderer)targetRenderer);
		}
	}

	private static void _UpdateMaterialsOnTargetRenderer(MB2_TextureBakeResults textureBakeResults, Renderer targetRenderer, SerializableIntArray[] subTris, int numNonZeroLengthSubmeshTris)
	{
		if (subTris.Length != textureBakeResults.NumResultMaterials())
		{
			UnityEngine.Debug.LogError("Mismatch between number of submeshes and number of result materials " + subTris.Length + " " + textureBakeResults.NumResultMaterials());
		}
		Material[] array = new Material[numNonZeroLengthSubmeshTris];
		int num = 0;
		for (int i = 0; i < subTris.Length; i++)
		{
			if (subTris[i].data.Length != 0)
			{
				array[num] = textureBakeResults.GetCombinedMaterialForSubmesh(i);
				num++;
			}
		}
		targetRenderer.materials = array;
	}
}
[Serializable]
public class MB3_MultiMeshCombiner : MB3_MeshCombiner
{
	[Serializable]
	public class CombinedMesh
	{
		public MB3_MeshCombinerSingle combinedMesh;

		public int extraSpace = -1;

		public int numVertsInListToDelete;

		public int numVertsInListToAdd;

		public List<GameObject> gosToAdd;

		public List<int> gosToDelete;

		public List<GameObject> gosToUpdate;

		public bool isDirty;

		public CombinedMesh(int maxNumVertsInMesh, GameObject resultSceneObject, MB2_LogLevel ll)
		{
			combinedMesh = new MB3_MeshCombinerSingle();
			combinedMesh.resultSceneObject = resultSceneObject;
			combinedMesh.LOG_LEVEL = ll;
			extraSpace = maxNumVertsInMesh;
			numVertsInListToDelete = 0;
			numVertsInListToAdd = 0;
			gosToAdd = new List<GameObject>();
			gosToDelete = new List<int>();
			gosToUpdate = new List<GameObject>();
		}

		public bool isEmpty()
		{
			List<GameObject> list = new List<GameObject>();
			list.AddRange(combinedMesh.GetObjectsInCombined());
			for (int i = 0; i < gosToDelete.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].GetInstanceID() == gosToDelete[i])
					{
						list.RemoveAt(j);
						break;
					}
				}
			}
			if (list.Count == 0)
			{
				return true;
			}
			return false;
		}
	}

	private static GameObject[] empty = new GameObject[0];

	private static int[] emptyIDs = new int[0];

	public Dictionary<int, CombinedMesh> obj2MeshCombinerMap = new Dictionary<int, CombinedMesh>();

	[SerializeField]
	public List<CombinedMesh> meshCombiners = new List<CombinedMesh>();

	[SerializeField]
	private int _maxVertsInMesh = 65535;

	public override MB2_LogLevel LOG_LEVEL
	{
		get
		{
			return _LOG_LEVEL;
		}
		set
		{
			_LOG_LEVEL = value;
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				meshCombiners[i].combinedMesh.LOG_LEVEL = value;
			}
		}
	}

	public override MB2_ValidationLevel validationLevel
	{
		get
		{
			return _validationLevel;
		}
		set
		{
			_validationLevel = value;
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				meshCombiners[i].combinedMesh.validationLevel = _validationLevel;
			}
		}
	}

	public int maxVertsInMesh
	{
		get
		{
			return _maxVertsInMesh;
		}
		set
		{
			if (obj2MeshCombinerMap.Count <= 0)
			{
				if (value < 3)
				{
					UnityEngine.Debug.LogError("Max verts in mesh must be greater than three.");
				}
				else if (value > MBVersion.MaxMeshVertexCount())
				{
					UnityEngine.Debug.LogError("MultiMeshCombiner error in maxVertsInMesh. Meshes in unity cannot have more than " + MBVersion.MaxMeshVertexCount() + " vertices. " + value);
				}
				else
				{
					_maxVertsInMesh = value;
				}
			}
		}
	}

	public override int GetNumObjectsInCombined()
	{
		return obj2MeshCombinerMap.Count;
	}

	public override List<GameObject> GetObjectsInCombined()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			list.AddRange(meshCombiners[i].combinedMesh.GetObjectsInCombined());
		}
		return list;
	}

	public override int GetLightmapIndex()
	{
		if (meshCombiners.Count > 0)
		{
			return meshCombiners[0].combinedMesh.GetLightmapIndex();
		}
		return -1;
	}

	public override bool CombinedMeshContains(GameObject go)
	{
		return obj2MeshCombinerMap.ContainsKey(go.GetInstanceID());
	}

	private bool _validateTextureBakeResults()
	{
		if (_textureBakeResults == null)
		{
			UnityEngine.Debug.LogError("Texture Bake Results is null. Can't combine meshes.");
			return false;
		}
		if (_textureBakeResults.materialsAndUVRects == null || _textureBakeResults.materialsAndUVRects.Length == 0)
		{
			UnityEngine.Debug.LogError("Texture Bake Results has no materials in material to sourceUVRect map. Try baking materials. Can't combine meshes. If you are trying to combine meshes without combining materials, try removing the Texture Bake Result.");
			return false;
		}
		if (_textureBakeResults.NumResultMaterials() == 0)
		{
			UnityEngine.Debug.LogError("Texture Bake Results has no result materials. Try baking materials. Can't combine meshes.");
			return false;
		}
		return true;
	}

	public override bool Apply(GenerateUV2Delegate uv2GenerationMethod)
	{
		bool flag = true;
		if (_bakeStatus != MeshCombiningStatus.readyForApply)
		{
			UnityEngine.Debug.LogError("Apply was called when combiner was not in 'readyForApply' state. Did you call AddDelete(), Update() or ShowHide()");
			return false;
		}
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			if (meshCombiners[i].isDirty)
			{
				flag &= meshCombiners[i].combinedMesh.Apply(uv2GenerationMethod);
				meshCombiners[i].isDirty = false;
			}
		}
		if (base.settings.clearBuffersAfterBake)
		{
			obj2MeshCombinerMap.Clear();
		}
		_bakeStatus = MeshCombiningStatus.preAddDeleteOrUpdate;
		return flag;
	}

	public override bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool colors, bool bones = false, bool blendShapeFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
	{
		return Apply(triangles, vertices, normals, tangents, uvs, uv2, uv3, uv4, uv5: false, uv6: false, uv7: false, uv8: false, colors, bones, blendShapeFlag, uv2GenerationMethod);
	}

	public override bool Apply(bool triangles, bool vertices, bool normals, bool tangents, bool uvs, bool uv2, bool uv3, bool uv4, bool uv5, bool uv6, bool uv7, bool uv8, bool colors, bool bones = false, bool blendShapesFlag = false, GenerateUV2Delegate uv2GenerationMethod = null)
	{
		if (_bakeStatus != MeshCombiningStatus.readyForApply)
		{
			UnityEngine.Debug.LogError("Apply was called when combiner was not in 'readyForApply' state. Did you call AddDelete(), Update() or ShowHide()");
			return false;
		}
		bool flag = true;
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			if (meshCombiners[i].isDirty)
			{
				flag &= meshCombiners[i].combinedMesh.Apply(triangles, vertices, normals, tangents, uvs, uv2, uv3, uv4, colors, bones, blendShapesFlag, uv2GenerationMethod);
				meshCombiners[i].isDirty = false;
			}
		}
		if (base.settings.clearBuffersAfterBake)
		{
			obj2MeshCombinerMap.Clear();
		}
		_bakeStatus = MeshCombiningStatus.preAddDeleteOrUpdate;
		return flag;
	}

	public override void UpdateSkinnedMeshApproximateBounds()
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].combinedMesh.UpdateSkinnedMeshApproximateBounds();
		}
	}

	public override void UpdateSkinnedMeshApproximateBoundsFromBones()
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].combinedMesh.UpdateSkinnedMeshApproximateBoundsFromBones();
		}
	}

	public override void UpdateSkinnedMeshApproximateBoundsFromBounds()
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].combinedMesh.UpdateSkinnedMeshApproximateBoundsFromBounds();
		}
	}

	public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateColors, bool updateSkinningInfo)
	{
		return UpdateGameObjects(gos, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5: false, updateUV6: false, updateUV7: false, updateUV8: false, updateColors, updateSkinningInfo);
	}

	public override bool UpdateGameObjects(GameObject[] gos, bool recalcBounds, bool updateVertices, bool updateNormals, bool updateTangents, bool updateUV, bool updateUV2, bool updateUV3, bool updateUV4, bool updateUV5, bool updateUV6, bool updateUV7, bool updateUV8, bool updateColors, bool updateSkinningInfo)
	{
		if (gos == null)
		{
			UnityEngine.Debug.LogError("list of game objects cannot be null");
			return false;
		}
		if (_bakeStatus != MeshCombiningStatus.preAddDeleteOrUpdate)
		{
			UnityEngine.Debug.LogError("Bake Status of combiner was not 'preAddDeleteOrUpdate'. This can happen if AddDeleteGameObjects or UpdateGameObjects is called twice without calling Apply. You can call 'ClearBuffers' to reset the combiner.");
			return false;
		}
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].gosToUpdate.Clear();
		}
		for (int j = 0; j < gos.Length; j++)
		{
			CombinedMesh value = null;
			obj2MeshCombinerMap.TryGetValue(gos[j].GetInstanceID(), out value);
			if (value != null)
			{
				value.gosToUpdate.Add(gos[j]);
			}
			else
			{
				UnityEngine.Debug.LogWarning("Object " + gos[j]?.ToString() + " is not in the combined mesh.");
			}
		}
		bool flag = true;
		for (int k = 0; k < meshCombiners.Count; k++)
		{
			if (meshCombiners[k].gosToUpdate.Count > 0)
			{
				meshCombiners[k].isDirty = true;
				GameObject[] gos2 = meshCombiners[k].gosToUpdate.ToArray();
				flag = flag && meshCombiners[k].combinedMesh.UpdateGameObjects(gos2, recalcBounds, updateVertices, updateNormals, updateTangents, updateUV, updateUV2, updateUV3, updateUV4, updateUV5, updateUV6, updateUV7, updateUV8, updateColors, updateSkinningInfo);
			}
		}
		_bakeStatus = MeshCombiningStatus.readyForApply;
		return flag;
	}

	public override bool AddDeleteGameObjects(GameObject[] gos, GameObject[] deleteGOs, bool disableRendererInSource = true)
	{
		int[] array = null;
		if (deleteGOs != null)
		{
			array = new int[deleteGOs.Length];
			for (int i = 0; i < deleteGOs.Length; i++)
			{
				if (deleteGOs[i] == null)
				{
					UnityEngine.Debug.LogError("The " + i + "th object on the list of objects to delete is 'Null'");
				}
				else
				{
					array[i] = deleteGOs[i].GetInstanceID();
				}
			}
		}
		return AddDeleteGameObjectsByID(gos, array, disableRendererInSource);
	}

	public override bool AddDeleteGameObjectsByID(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource = true)
	{
		if (_bakeStatus != MeshCombiningStatus.preAddDeleteOrUpdate)
		{
			UnityEngine.Debug.LogError("Bake Status of combiner was not 'preAddDeleteOrUpdate'. This can happen if AddDeleteGameObjects or UpdateGameObjects is called twice without calling Apply. You can call 'ClearBuffers' to reset the combiner.");
			return false;
		}
		if (deleteGOinstanceIDs == null)
		{
			deleteGOinstanceIDs = emptyIDs;
		}
		if (_usingTemporaryTextureBakeResult && gos != null && gos.Length != 0)
		{
			MB_Utility.Destroy(_textureBakeResults);
			_textureBakeResults = null;
			_usingTemporaryTextureBakeResult = false;
		}
		if (_textureBakeResults == null && gos != null && gos.Length != 0 && gos[0] != null && !_CreateTemporaryTextrueBakeResult(gos, GetMaterialsOnTargetRenderer()))
		{
			return false;
		}
		if (!_validate(gos, deleteGOinstanceIDs))
		{
			return false;
		}
		_distributeAmongBakers(gos, deleteGOinstanceIDs);
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			MB2_Log.LogDebug("MB2_MultiMeshCombiner.AddDeleteGameObjects numCombinedMeshes: " + meshCombiners.Count + " added:" + ((gos != null) ? gos.Length : 0) + " deleted:" + ((deleteGOinstanceIDs != null) ? deleteGOinstanceIDs.Length : 0) + " disableRendererInSource:" + disableRendererInSource + " maxVertsPerCombined:" + _maxVertsInMesh);
		}
		bool result = _bakeStep1(gos, deleteGOinstanceIDs, disableRendererInSource);
		_bakeStatus = MeshCombiningStatus.readyForApply;
		return result;
	}

	private bool _validate(GameObject[] gos, int[] deleteGOinstanceIDs)
	{
		if (_validationLevel == MB2_ValidationLevel.none)
		{
			return true;
		}
		if (_maxVertsInMesh < 3)
		{
			UnityEngine.Debug.LogError("Invalid value for maxVertsInMesh=" + _maxVertsInMesh);
		}
		_validateTextureBakeResults();
		int num = 0;
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			num += meshCombiners[i].combinedMesh.GetNumObjectsInCombined();
		}
		if (obj2MeshCombinerMap.Count != num)
		{
			obj2MeshCombinerMap.Clear();
			for (int j = 0; j < meshCombiners.Count; j++)
			{
				List<MB3_MeshCombinerSingle.MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh = meshCombiners[j].combinedMesh.mbDynamicObjectsInCombinedMesh;
				for (int k = 0; k < mbDynamicObjectsInCombinedMesh.Count; k++)
				{
					if (mbDynamicObjectsInCombinedMesh[k].gameObject != null)
					{
						int instanceID = mbDynamicObjectsInCombinedMesh[k].gameObject.GetInstanceID();
						mbDynamicObjectsInCombinedMesh[k].instanceID = instanceID;
					}
					obj2MeshCombinerMap.Add(mbDynamicObjectsInCombinedMesh[k].instanceID, meshCombiners[j]);
				}
			}
		}
		if (gos != null)
		{
			for (int l = 0; l < gos.Length; l++)
			{
				if (gos[l] == null)
				{
					UnityEngine.Debug.LogError("The " + l + "th object on the list of objects to combine is 'None'. Use Command-Delete on Mac OS X; Delete or Shift-Delete on Windows to remove this one element.");
					return false;
				}
				if (_validationLevel < MB2_ValidationLevel.robust)
				{
					continue;
				}
				for (int m = l + 1; m < gos.Length; m++)
				{
					if (gos[l] == gos[m])
					{
						UnityEngine.Debug.LogError("GameObject " + gos[l]?.ToString() + "appears twice in list of game objects to add");
						return false;
					}
				}
				if (!obj2MeshCombinerMap.ContainsKey(gos[l].GetInstanceID()))
				{
					continue;
				}
				bool flag = false;
				if (deleteGOinstanceIDs != null)
				{
					for (int n = 0; n < deleteGOinstanceIDs.Length; n++)
					{
						if (deleteGOinstanceIDs[n] == gos[l].GetInstanceID())
						{
							flag = true;
						}
					}
				}
				if (!flag)
				{
					UnityEngine.Debug.LogError("GameObject " + gos[l]?.ToString() + " is already in the combined mesh " + gos[l].GetInstanceID());
					return false;
				}
			}
		}
		if (deleteGOinstanceIDs != null && _validationLevel >= MB2_ValidationLevel.robust)
		{
			for (int num2 = 0; num2 < deleteGOinstanceIDs.Length; num2++)
			{
				for (int num3 = num2 + 1; num3 < deleteGOinstanceIDs.Length; num3++)
				{
					if (deleteGOinstanceIDs[num2] == deleteGOinstanceIDs[num3])
					{
						UnityEngine.Debug.LogError("GameObject " + deleteGOinstanceIDs[num2] + "appears twice in list of game objects to delete");
						return false;
					}
				}
				if (!obj2MeshCombinerMap.ContainsKey(deleteGOinstanceIDs[num2]))
				{
					UnityEngine.Debug.LogWarning("GameObject with instance ID " + deleteGOinstanceIDs[num2] + " on the list of objects to delete is not in the combined mesh.");
				}
			}
		}
		return true;
	}

	private void _distributeAmongBakers(GameObject[] gos, int[] deleteGOinstanceIDs)
	{
		if (gos == null)
		{
			gos = empty;
		}
		if (deleteGOinstanceIDs == null)
		{
			deleteGOinstanceIDs = emptyIDs;
		}
		if (resultSceneObject == null)
		{
			resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].extraSpace = _maxVertsInMesh - meshCombiners[i].combinedMesh.GetMesh().vertexCount;
		}
		for (int j = 0; j < deleteGOinstanceIDs.Length; j++)
		{
			CombinedMesh value = null;
			if (obj2MeshCombinerMap.TryGetValue(deleteGOinstanceIDs[j], out value))
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("MB2_MultiMeshCombiner.Removing " + deleteGOinstanceIDs[j] + " from meshCombiner " + meshCombiners.IndexOf(value));
				}
				value.combinedMesh.InstanceID2DGO(deleteGOinstanceIDs[j], out var dgoGameObject);
				value.numVertsInListToDelete += dgoGameObject.numVerts;
				value.gosToDelete.Add(deleteGOinstanceIDs[j]);
			}
			else
			{
				UnityEngine.Debug.LogWarning("Object " + deleteGOinstanceIDs[j] + " in the list of objects to delete is not in the combined mesh.");
			}
		}
		for (int k = 0; k < gos.Length; k++)
		{
			GameObject gameObject = gos[k];
			int vertexCount = MB_Utility.GetMesh(gameObject).vertexCount;
			CombinedMesh combinedMesh = null;
			for (int l = 0; l < meshCombiners.Count; l++)
			{
				if (meshCombiners[l].extraSpace + meshCombiners[l].numVertsInListToDelete - meshCombiners[l].numVertsInListToAdd > vertexCount)
				{
					combinedMesh = meshCombiners[l];
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						MB2_Log.LogDebug("MB2_MultiMeshCombiner.Added " + gos[k]?.ToString() + " to combinedMesh " + l, LOG_LEVEL);
					}
					break;
				}
			}
			if (combinedMesh == null)
			{
				combinedMesh = new CombinedMesh(maxVertsInMesh, _resultSceneObject, _LOG_LEVEL);
				_setMBValues(combinedMesh.combinedMesh);
				meshCombiners.Add(combinedMesh);
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("MB2_MultiMeshCombiner.Created new combinedMesh");
				}
			}
			combinedMesh.gosToAdd.Add(gameObject);
			combinedMesh.numVertsInListToAdd += vertexCount;
		}
	}

	private bool _bakeStep1(GameObject[] gos, int[] deleteGOinstanceIDs, bool disableRendererInSource)
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			CombinedMesh combinedMesh = meshCombiners[i];
			if (combinedMesh.combinedMesh.targetRenderer == null)
			{
				combinedMesh.combinedMesh.resultSceneObject = _resultSceneObject;
				combinedMesh.combinedMesh.BuildSceneMeshObject(gos, createNewChild: true);
				if (_LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("BuildSO combiner {0} goID {1} targetRenID {2} meshID {3}", i, combinedMesh.combinedMesh.targetRenderer.gameObject.GetInstanceID(), combinedMesh.combinedMesh.targetRenderer.GetInstanceID(), combinedMesh.combinedMesh.GetMesh().GetInstanceID());
				}
			}
			else if (resultSceneObject != null && combinedMesh.combinedMesh.targetRenderer.transform.parent != resultSceneObject.transform)
			{
				UnityEngine.Debug.LogError("targetRender objects must be children of resultSceneObject");
				return false;
			}
			if (combinedMesh.gosToAdd.Count > 0 || combinedMesh.gosToDelete.Count > 0)
			{
				combinedMesh.combinedMesh.AddDeleteGameObjectsByID(combinedMesh.gosToAdd.ToArray(), combinedMesh.gosToDelete.ToArray(), disableRendererInSource);
				if (_LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Baked combiner {0} obsAdded {1} objsRemoved {2} goID {3} targetRenID {4} meshID {5}", i, combinedMesh.gosToAdd.Count, combinedMesh.gosToDelete.Count, combinedMesh.combinedMesh.targetRenderer.gameObject.GetInstanceID(), combinedMesh.combinedMesh.targetRenderer.GetInstanceID(), combinedMesh.combinedMesh.GetMesh().GetInstanceID());
				}
			}
			Renderer renderer = combinedMesh.combinedMesh.targetRenderer;
			Mesh mesh = combinedMesh.combinedMesh.GetMesh();
			if (renderer is MeshRenderer)
			{
				renderer.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
			}
			else
			{
				((SkinnedMeshRenderer)renderer).sharedMesh = mesh;
			}
		}
		for (int j = 0; j < meshCombiners.Count; j++)
		{
			CombinedMesh combinedMesh2 = meshCombiners[j];
			for (int k = 0; k < combinedMesh2.gosToDelete.Count; k++)
			{
				obj2MeshCombinerMap.Remove(combinedMesh2.gosToDelete[k]);
			}
		}
		for (int l = 0; l < meshCombiners.Count; l++)
		{
			CombinedMesh combinedMesh3 = meshCombiners[l];
			for (int m = 0; m < combinedMesh3.gosToAdd.Count; m++)
			{
				obj2MeshCombinerMap.Add(combinedMesh3.gosToAdd[m].GetInstanceID(), combinedMesh3);
			}
			if (combinedMesh3.gosToAdd.Count > 0 || combinedMesh3.gosToDelete.Count > 0)
			{
				combinedMesh3.gosToDelete.Clear();
				combinedMesh3.gosToAdd.Clear();
				combinedMesh3.numVertsInListToDelete = 0;
				combinedMesh3.numVertsInListToAdd = 0;
				combinedMesh3.isDirty = true;
			}
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			string text = "Meshes in combined:";
			for (int n = 0; n < meshCombiners.Count; n++)
			{
				text = text + " mesh" + n + "(" + meshCombiners[n].combinedMesh.GetObjectsInCombined().Count + ")\n";
			}
			text = text + "children in result: " + resultSceneObject.transform.childCount;
			MB2_Log.LogDebug(text, LOG_LEVEL);
		}
		if (meshCombiners.Count > 0)
		{
			return true;
		}
		return false;
	}

	public override void ClearBuffers()
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].combinedMesh.ClearBuffers();
		}
		obj2MeshCombinerMap.Clear();
		_bakeStatus = MeshCombiningStatus.preAddDeleteOrUpdate;
	}

	public override void ClearMesh()
	{
		DestroyMesh();
		ClearBuffers();
	}

	public override void ClearMesh(MB2_EditorMethodsInterface editorMethods)
	{
		DestroyMeshEditor(editorMethods);
		ClearBuffers();
	}

	internal override void _DisposeRuntimeCreated()
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].combinedMesh._DisposeRuntimeCreated();
		}
	}

	public override void DestroyMesh()
	{
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			if (meshCombiners[i].combinedMesh.targetRenderer != null)
			{
				MB_Utility.Destroy(meshCombiners[i].combinedMesh.targetRenderer.gameObject);
			}
			meshCombiners[i].combinedMesh.Dispose();
		}
		obj2MeshCombinerMap.Clear();
		meshCombiners.Clear();
	}

	public override void DestroyMeshEditor(MB2_EditorMethodsInterface editorMethods)
	{
		editorMethods.Destroy(resultSceneObject);
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			meshCombiners[i].combinedMesh.ClearMesh();
		}
		obj2MeshCombinerMap.Clear();
		meshCombiners.Clear();
	}

	private void _setMBValues(MB3_MeshCombinerSingle targ)
	{
		targ.validationLevel = _validationLevel;
		targ.textureBakeResults = textureBakeResults;
		targ.outputOption = MB2_OutputOptions.bakeIntoSceneObject;
		if (settingsHolder != null)
		{
			targ.settingsHolder = settingsHolder;
			return;
		}
		targ.renderType = renderType;
		targ.lightmapOption = lightmapOption;
		targ.doNorm = doNorm;
		targ.doTan = doTan;
		targ.doCol = doCol;
		targ.doUV = doUV;
		targ.doUV3 = doUV3;
		targ.doUV4 = doUV4;
		targ.doUV5 = doUV5;
		targ.doUV6 = doUV6;
		targ.doUV7 = doUV7;
		targ.doUV8 = doUV8;
		targ.doBlendShapes = doBlendShapes;
		targ.optimizeAfterBake = base.optimizeAfterBake;
		targ.pivotLocationType = pivotLocationType;
		targ.uv2UnwrappingParamsHardAngle = base.uv2UnwrappingParamsHardAngle;
		targ.uv2UnwrappingParamsPackMargin = base.uv2UnwrappingParamsPackMargin;
		targ.assignToMeshCustomizer = base.assignToMeshCustomizer;
	}

	public override List<Material> GetMaterialsOnTargetRenderer()
	{
		HashSet<Material> hashSet = new HashSet<Material>();
		for (int i = 0; i < meshCombiners.Count; i++)
		{
			hashSet.UnionWith(meshCombiners[i].combinedMesh.GetMaterialsOnTargetRenderer());
		}
		return new List<Material>(hashSet);
	}

	public override void CheckIntegrity()
	{
		if (MB_Utility.DO_INTEGRITY_CHECKS)
		{
			for (int i = 0; i < meshCombiners.Count; i++)
			{
				meshCombiners[i].combinedMesh.CheckIntegrity();
			}
		}
	}
}
public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>, IEnumerable<KeyValuePair<TPriority, TValue>>, IEnumerable
{
	public List<KeyValuePair<TPriority, TValue>> _baseHeap;

	private IComparer<TPriority> _comparer;

	public bool IsEmpty => _baseHeap.Count == 0;

	public int Count => _baseHeap.Count;

	public bool IsReadOnly => false;

	public PriorityQueue()
		: this((IComparer<TPriority>)Comparer<TPriority>.Default)
	{
	}

	public PriorityQueue(int capacity)
		: this(capacity, (IComparer<TPriority>)Comparer<TPriority>.Default)
	{
	}

	public PriorityQueue(int capacity, IComparer<TPriority> comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException();
		}
		_baseHeap = new List<KeyValuePair<TPriority, TValue>>(capacity);
		_comparer = comparer;
	}

	public PriorityQueue(IComparer<TPriority> comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException();
		}
		_baseHeap = new List<KeyValuePair<TPriority, TValue>>();
		_comparer = comparer;
	}

	public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data)
		: this(data, (IComparer<TPriority>)Comparer<TPriority>.Default)
	{
	}

	public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
	{
		if (data == null || comparer == null)
		{
			throw new ArgumentNullException();
		}
		_comparer = comparer;
		_baseHeap = new List<KeyValuePair<TPriority, TValue>>(data);
		for (int num = _baseHeap.Count / 2 - 1; num >= 0; num--)
		{
			HeapifyFromBeginningToEnd(num);
		}
	}

	public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2)
	{
		if (pq1 == null || pq2 == null)
		{
			throw new ArgumentNullException();
		}
		if (pq1._comparer != pq2._comparer)
		{
			throw new InvalidOperationException("Priority queues to be merged must have equal comparers");
		}
		return MergeQueues(pq1, pq2, pq1._comparer);
	}

	public static PriorityQueue<TPriority, TValue> MergeQueues(PriorityQueue<TPriority, TValue> pq1, PriorityQueue<TPriority, TValue> pq2, IComparer<TPriority> comparer)
	{
		if (pq1 == null || pq2 == null || comparer == null)
		{
			throw new ArgumentNullException();
		}
		PriorityQueue<TPriority, TValue> priorityQueue = new PriorityQueue<TPriority, TValue>(pq1.Count + pq2.Count, pq1._comparer);
		priorityQueue._baseHeap.AddRange(pq1._baseHeap);
		priorityQueue._baseHeap.AddRange(pq2._baseHeap);
		for (int num = priorityQueue._baseHeap.Count / 2 - 1; num >= 0; num--)
		{
			priorityQueue.HeapifyFromBeginningToEnd(num);
		}
		return priorityQueue;
	}

	public void Enqueue(TPriority priority, TValue value)
	{
		Insert(priority, value);
	}

	public KeyValuePair<TPriority, TValue> Dequeue()
	{
		if (!IsEmpty)
		{
			KeyValuePair<TPriority, TValue> result = _baseHeap[0];
			DeleteRoot();
			return result;
		}
		throw new InvalidOperationException("Priority queue is empty");
	}

	public TValue DequeueValue()
	{
		return Dequeue().Value;
	}

	public KeyValuePair<TPriority, TValue> Peek()
	{
		if (!IsEmpty)
		{
			return _baseHeap[0];
		}
		throw new InvalidOperationException("Priority queue is empty");
	}

	public TValue PeekValue()
	{
		return Peek().Value;
	}

	private void ExchangeElements(int pos1, int pos2)
	{
		KeyValuePair<TPriority, TValue> value = _baseHeap[pos1];
		_baseHeap[pos1] = _baseHeap[pos2];
		_baseHeap[pos2] = value;
	}

	private void Insert(TPriority priority, TValue value)
	{
		KeyValuePair<TPriority, TValue> item = new KeyValuePair<TPriority, TValue>(priority, value);
		_baseHeap.Add(item);
		HeapifyFromEndToBeginning(_baseHeap.Count - 1);
	}

	private int HeapifyFromEndToBeginning(int pos)
	{
		if (pos >= _baseHeap.Count)
		{
			return -1;
		}
		while (pos > 0)
		{
			int num = (pos - 1) / 2;
			if (_comparer.Compare(_baseHeap[num].Key, _baseHeap[pos].Key) <= 0)
			{
				break;
			}
			ExchangeElements(num, pos);
			pos = num;
		}
		return pos;
	}

	private void DeleteRoot()
	{
		if (_baseHeap.Count <= 1)
		{
			_baseHeap.Clear();
			return;
		}
		_baseHeap[0] = _baseHeap[_baseHeap.Count - 1];
		_baseHeap.RemoveAt(_baseHeap.Count - 1);
		HeapifyFromBeginningToEnd(0);
	}

	private void HeapifyFromBeginningToEnd(int pos)
	{
		if (pos >= _baseHeap.Count)
		{
			return;
		}
		while (true)
		{
			int num = pos;
			int num2 = 2 * pos + 1;
			int num3 = 2 * pos + 2;
			if (num2 < _baseHeap.Count && _comparer.Compare(_baseHeap[num].Key, _baseHeap[num2].Key) > 0)
			{
				num = num2;
			}
			if (num3 < _baseHeap.Count && _comparer.Compare(_baseHeap[num].Key, _baseHeap[num3].Key) > 0)
			{
				num = num3;
			}
			if (num != pos)
			{
				ExchangeElements(num, pos);
				pos = num;
				continue;
			}
			break;
		}
	}

	public void Add(KeyValuePair<TPriority, TValue> item)
	{
		Enqueue(item.Key, item.Value);
	}

	public void Clear()
	{
		_baseHeap.Clear();
	}

	public bool Contains(KeyValuePair<TPriority, TValue> item)
	{
		return _baseHeap.Contains(item);
	}

	public bool TryFindValue(TPriority item, out TValue foundVersion)
	{
		for (int i = 0; i < _baseHeap.Count; i++)
		{
			if (_comparer.Compare(item, _baseHeap[i].Key) == 0)
			{
				foundVersion = _baseHeap[i].Value;
				return true;
			}
		}
		foundVersion = default(TValue);
		return false;
	}

	public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
	{
		_baseHeap.CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<TPriority, TValue> item)
	{
		int num = _baseHeap.IndexOf(item);
		if (num < 0)
		{
			return false;
		}
		_baseHeap[num] = _baseHeap[_baseHeap.Count - 1];
		_baseHeap.RemoveAt(_baseHeap.Count - 1);
		if (HeapifyFromEndToBeginning(num) == num)
		{
			HeapifyFromBeginningToEnd(num);
		}
		return true;
	}

	public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
	{
		return _baseHeap.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
public class MB3_ShadersThatShareTiling
{
	public struct ShaderThatSharesTiling
	{
		public string shadername;

		public bool allPropsShareTiling;

		public string tilingTexturePropName;
	}

	private static MB3_ShadersThatShareTiling _singleton;

	private Dictionary<string, ShaderThatSharesTiling> shadersThatShareTiling;

	public static MB3_ShadersThatShareTiling GetShadersThatShareTiling()
	{
		if (_singleton == null)
		{
			Init();
		}
		return _singleton;
	}

	public static void GetScaleAndOffsetForTextureProp(Material m, string texturePropName, out Vector2 offset, out Vector2 scale)
	{
		if (GetShadersThatShareTiling().shadersThatShareTiling.TryGetValue(m.shader.name, out var value) && value.allPropsShareTiling && m.HasProperty(value.tilingTexturePropName))
		{
			scale = m.GetTextureScale(value.tilingTexturePropName);
			offset = m.GetTextureOffset(value.tilingTexturePropName);
		}
		else
		{
			scale = m.GetTextureScale(texturePropName);
			offset = m.GetTextureOffset(texturePropName);
		}
	}

	private static void Init()
	{
		_singleton = new MB3_ShadersThatShareTiling();
		Dictionary<string, ShaderThatSharesTiling> dictionary = (_singleton.shadersThatShareTiling = new Dictionary<string, ShaderThatSharesTiling>());
		ShaderThatSharesTiling value = default(ShaderThatSharesTiling);
		value.shadername = "Standard";
		value.allPropsShareTiling = true;
		value.tilingTexturePropName = "_MainTex";
		ShaderThatSharesTiling value2 = default(ShaderThatSharesTiling);
		value2.shadername = "Standard (Specular setup)";
		value2.allPropsShareTiling = true;
		value2.tilingTexturePropName = "_MainTex";
		ShaderThatSharesTiling value3 = default(ShaderThatSharesTiling);
		value3.shadername = "Universal Render Pipeline/Lit";
		value3.allPropsShareTiling = true;
		value3.tilingTexturePropName = "_BaseMap";
		ShaderThatSharesTiling shaderThatSharesTiling = default(ShaderThatSharesTiling);
		shaderThatSharesTiling.shadername = "Universal Render Pipeline/Simple Lit";
		shaderThatSharesTiling.allPropsShareTiling = true;
		shaderThatSharesTiling.tilingTexturePropName = "_BaseMap";
		ShaderThatSharesTiling shaderThatSharesTiling2 = default(ShaderThatSharesTiling);
		shaderThatSharesTiling2.shadername = "Universal Render Pipeline/Complex Lit";
		shaderThatSharesTiling2.allPropsShareTiling = true;
		shaderThatSharesTiling2.tilingTexturePropName = "_BaseMap";
		ShaderThatSharesTiling shaderThatSharesTiling3 = default(ShaderThatSharesTiling);
		shaderThatSharesTiling3.shadername = "Universal Render Pipeline/Baked Lit";
		shaderThatSharesTiling3.allPropsShareTiling = true;
		shaderThatSharesTiling3.tilingTexturePropName = "_BaseMap";
		dictionary.Add(value.shadername, value);
		dictionary.Add(value2.shadername, value2);
		dictionary.Add(value3.shadername, value3);
		dictionary.Add(shaderThatSharesTiling.shadername, value3);
		dictionary.Add(shaderThatSharesTiling2.shadername, value3);
		dictionary.Add(shaderThatSharesTiling3.shadername, value3);
	}
}
public struct DVector2
{
	private static double epsilon;

	public double x;

	public double y;

	public static DVector2 Subtract(DVector2 a, DVector2 b)
	{
		return new DVector2(a.x - b.x, a.y - b.y);
	}

	public DVector2(double xx, double yy)
	{
		x = xx;
		y = yy;
	}

	public DVector2(DVector2 r)
	{
		x = r.x;
		y = r.y;
	}

	public Vector2 GetVector2()
	{
		return new Vector2((float)x, (float)y);
	}

	public bool IsContainedIn(DRect r)
	{
		if (x >= r.x && y >= r.y && x <= r.x + r.width && y <= r.y + r.height)
		{
			return true;
		}
		return false;
	}

	public bool IsContainedInWithMargin(DRect r)
	{
		if (x >= r.x - epsilon && y >= r.y - epsilon && x <= r.x + r.width + epsilon && y <= r.y + r.height + epsilon)
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return $"({x},{y})";
	}

	public string ToString(string formatS)
	{
		return $"({x.ToString(formatS)},{y.ToString(formatS)})";
	}

	public static double Distance(DVector2 a, DVector2 b)
	{
		double num = b.x - a.x;
		double num2 = b.y - a.y;
		return Math.Sqrt(num * num + num2 * num2);
	}

	static DVector2()
	{
		epsilon = 1E-05;
	}
}
public struct DRect
{
	public double x;

	public double y;

	public double width;

	public double height;

	public DVector2 minD => new DVector2(x, y);

	public DVector2 maxD => new DVector2(x + width, y + height);

	public Vector2 min => new Vector2((float)x, (float)y);

	public Vector2 max => new Vector2((float)(x + width), (float)(y + height));

	public Vector2 size => new Vector2((float)width, (float)height);

	public DVector2 center => new DVector2(x + width / 2.0, y + height / 2.0);

	public DRect(Rect r)
	{
		x = r.x;
		y = r.y;
		width = r.width;
		height = r.height;
	}

	public DRect(Vector2 o, Vector2 s)
	{
		x = o.x;
		y = o.y;
		width = s.x;
		height = s.y;
	}

	public DRect(DRect r)
	{
		x = r.x;
		y = r.y;
		width = r.width;
		height = r.height;
	}

	public DRect(float xx, float yy, float w, float h)
	{
		x = xx;
		y = yy;
		width = w;
		height = h;
	}

	public DRect(double xx, double yy, double w, double h)
	{
		x = xx;
		y = yy;
		width = w;
		height = h;
	}

	public Rect GetRect()
	{
		return new Rect((float)x, (float)y, (float)width, (float)height);
	}

	public override bool Equals(object obj)
	{
		DRect dRect = (DRect)obj;
		if (dRect.x == x && dRect.y == y && dRect.width == width && dRect.height == height)
		{
			return true;
		}
		return false;
	}

	public static bool operator ==(DRect a, DRect b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(DRect a, DRect b)
	{
		return !a.Equals(b);
	}

	public override string ToString()
	{
		return string.Format("(x={0},y={1},w={2},h={3})", x.ToString("F5"), y.ToString("F5"), width.ToString("F5"), height.ToString("F5"));
	}

	public void Expand(float amt)
	{
		x -= amt;
		y -= amt;
		width += amt * 2f;
		height += amt * 2f;
	}

	public bool Encloses(DRect smallToTestIfFits)
	{
		double num = smallToTestIfFits.x;
		double num2 = smallToTestIfFits.y;
		double num3 = smallToTestIfFits.x + smallToTestIfFits.width;
		double num4 = smallToTestIfFits.y + smallToTestIfFits.height;
		double num5 = x;
		double num6 = y;
		double num7 = x + width;
		double num8 = y + height;
		if (num5 <= num && num <= num7 && num5 <= num3 && num3 <= num7 && num6 <= num2 && num2 <= num8 && num6 <= num4)
		{
			return num4 <= num8;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x.GetHashCode() ^ y.GetHashCode() ^ width.GetHashCode() ^ height.GetHashCode();
	}
}
public class MB3_UVTransformUtility
{
	public static void Test()
	{
		DRect t = new DRect(0.5, 0.5, 2.0, 2.0);
		DRect t2 = new DRect(0.25, 0.25, 3.0, 3.0);
		DRect r = InverseTransform(ref t);
		DRect r2 = InverseTransform(ref t2);
		DRect r3 = CombineTransforms(ref t, ref r2);
		UnityEngine.Debug.Log(r);
		UnityEngine.Debug.Log(r3);
		UnityEngine.Debug.Log("one mat trans " + TransformPoint(ref t, new Vector2(1f, 1f)).ToString());
		UnityEngine.Debug.Log("one inv mat trans " + TransformPoint(ref r, new Vector2(1f, 1f)).ToString("f4"));
		UnityEngine.Debug.Log("zero " + TransformPoint(ref r3, new Vector2(0f, 0f)).ToString("f4"));
		UnityEngine.Debug.Log("one " + TransformPoint(ref r3, new Vector2(1f, 1f)).ToString("f4"));
	}

	public static float TransformX(DRect r, double x)
	{
		return (float)(r.width * x + r.x);
	}

	public static DRect CombineTransforms(ref DRect r1, ref DRect r2)
	{
		return new DRect(r1.x * r2.width + r2.x, r1.y * r2.height + r2.y, r1.width * r2.width, r1.height * r2.height);
	}

	public static Rect CombineTransforms(ref Rect r1, ref Rect r2)
	{
		return new Rect(r1.x * r2.width + r2.x, r1.y * r2.height + r2.y, r1.width * r2.width, r1.height * r2.height);
	}

	public static DRect InverseTransform(ref DRect t)
	{
		return new DRect
		{
			x = (0.0 - t.x) / t.width,
			y = (0.0 - t.y) / t.height,
			width = 1.0 / t.width,
			height = 1.0 / t.height
		};
	}

	public static DRect GetShiftTransformToFitBinA(ref DRect A, ref DRect B)
	{
		DVector2 center = A.center;
		DVector2 center2 = B.center;
		DVector2 dVector = DVector2.Subtract(center, center2);
		double xx = Convert.ToInt32(dVector.x);
		double yy = Convert.ToInt32(dVector.y);
		return new DRect(xx, yy, 1.0, 1.0);
	}

	public static DRect GetEncapsulatingRectShifted(ref DRect uvRect1, ref DRect willBeIn)
	{
		DVector2 center = uvRect1.center;
		DVector2 center2 = willBeIn.center;
		DVector2 dVector = DVector2.Subtract(center, center2);
		double num = Convert.ToInt32(dVector.x);
		double num2 = Convert.ToInt32(dVector.y);
		DRect dRect = new DRect(willBeIn);
		dRect.x += num;
		dRect.y += num2;
		double x = uvRect1.x;
		double y = uvRect1.y;
		double num3 = uvRect1.x + uvRect1.width;
		double num4 = uvRect1.y + uvRect1.height;
		double x2 = dRect.x;
		double y2 = dRect.y;
		double num5 = dRect.x + dRect.width;
		double num6 = dRect.y + dRect.height;
		double num8;
		double num7 = (num8 = x);
		double num10;
		double num9 = (num10 = y);
		if (x2 < num7)
		{
			num7 = x2;
		}
		if (x < num7)
		{
			num7 = x;
		}
		if (y2 < num9)
		{
			num9 = y2;
		}
		if (y < num9)
		{
			num9 = y;
		}
		if (num5 > num8)
		{
			num8 = num5;
		}
		if (num3 > num8)
		{
			num8 = num3;
		}
		if (num6 > num10)
		{
			num10 = num6;
		}
		if (num4 > num10)
		{
			num10 = num4;
		}
		return new DRect(num7, num9, num8 - num7, num10 - num9);
	}

	public static DRect GetEncapsulatingRect(ref DRect uvRect1, ref DRect uvRect2)
	{
		double x = uvRect1.x;
		double y = uvRect1.y;
		double num = uvRect1.x + uvRect1.width;
		double num2 = uvRect1.y + uvRect1.height;
		double x2 = uvRect2.x;
		double y2 = uvRect2.y;
		double num3 = uvRect2.x + uvRect2.width;
		double num4 = uvRect2.y + uvRect2.height;
		double num6;
		double num5 = (num6 = x);
		double num8;
		double num7 = (num8 = y);
		if (x2 < num5)
		{
			num5 = x2;
		}
		if (x < num5)
		{
			num5 = x;
		}
		if (y2 < num7)
		{
			num7 = y2;
		}
		if (y < num7)
		{
			num7 = y;
		}
		if (num3 > num6)
		{
			num6 = num3;
		}
		if (num > num6)
		{
			num6 = num;
		}
		if (num4 > num8)
		{
			num8 = num4;
		}
		if (num2 > num8)
		{
			num8 = num2;
		}
		return new DRect(num5, num7, num6 - num5, num8 - num7);
	}

	public static bool RectContainsShifted(ref DRect bucket, ref DRect tryFit)
	{
		DVector2 center = bucket.center;
		DVector2 center2 = tryFit.center;
		DVector2 dVector = DVector2.Subtract(center, center2);
		double num = Convert.ToInt32(dVector.x);
		double num2 = Convert.ToInt32(dVector.y);
		DRect smallToTestIfFits = new DRect(tryFit);
		smallToTestIfFits.x += num;
		smallToTestIfFits.y += num2;
		return bucket.Encloses(smallToTestIfFits);
	}

	public static bool RectContainsShifted(ref Rect bucket, ref Rect tryFit)
	{
		Vector2 center = bucket.center;
		Vector2 center2 = tryFit.center;
		Vector2 vector = center - center2;
		float num = Convert.ToInt32(vector.x);
		float num2 = Convert.ToInt32(vector.y);
		Rect smallToTestIfFits = new Rect(tryFit);
		smallToTestIfFits.x += num;
		smallToTestIfFits.y += num2;
		return RectContains(ref bucket, ref smallToTestIfFits);
	}

	public static bool LineSegmentContainsShifted(float bucketOffset, float bucketLength, float tryFitOffset, float tryFitLength)
	{
		float num = bucketOffset + bucketLength / 2f;
		float num2 = tryFitOffset + tryFitLength / 2f;
		float num3 = Convert.ToInt32(num - num2);
		tryFitOffset += num3;
		float num4 = tryFitOffset;
		float num5 = tryFitOffset + tryFitLength;
		float num6 = bucketOffset - 0.01f;
		float num7 = bucketOffset + bucketLength + 0.01f;
		if (num6 <= num4 && num4 <= num7 && num6 <= num5)
		{
			return num5 <= num7;
		}
		return false;
	}

	public static bool RectContains(ref DRect bigRect, ref DRect smallToTestIfFits)
	{
		double x = smallToTestIfFits.x;
		double y = smallToTestIfFits.y;
		double num = smallToTestIfFits.x + smallToTestIfFits.width;
		double num2 = smallToTestIfFits.y + smallToTestIfFits.height;
		double num3 = bigRect.x - 0.009999999776482582;
		double num4 = bigRect.y - 0.009999999776482582;
		double num5 = bigRect.x + bigRect.width + 0.009999999776482582;
		double num6 = bigRect.y + bigRect.height + 0.009999999776482582;
		if (num3 <= x && x <= num5 && num3 <= num && num <= num5 && num4 <= y && y <= num6 && num4 <= num2)
		{
			return num2 <= num6;
		}
		return false;
	}

	public static bool RectContains(ref Rect bigRect, ref Rect smallToTestIfFits)
	{
		float x = smallToTestIfFits.x;
		float y = smallToTestIfFits.y;
		float num = smallToTestIfFits.x + smallToTestIfFits.width;
		float num2 = smallToTestIfFits.y + smallToTestIfFits.height;
		float num3 = bigRect.x - 0.01f;
		float num4 = bigRect.y - 0.01f;
		float num5 = bigRect.x + bigRect.width + 0.01f;
		float num6 = bigRect.y + bigRect.height + 0.01f;
		if (num3 <= x && x <= num5 && num3 <= num && num <= num5 && num4 <= y && y <= num6 && num4 <= num2)
		{
			return num2 <= num6;
		}
		return false;
	}

	public static Vector2 TransformPoint(ref DRect r, Vector2 p)
	{
		return new Vector2((float)(r.width * (double)p.x + r.x), (float)(r.height * (double)p.y + r.y));
	}

	public static DVector2 TransformPoint(ref DRect r, DVector2 p)
	{
		return new DVector2(r.width * p.x + r.x, r.height * p.y + r.y);
	}
}
public class MB_BlendShape2CombinedMap : MonoBehaviour
{
	public SerializableSourceBlendShape2Combined srcToCombinedMap;

	public SerializableSourceBlendShape2Combined GetMap()
	{
		if (srcToCombinedMap == null)
		{
			srcToCombinedMap = new SerializableSourceBlendShape2Combined();
		}
		return srcToCombinedMap;
	}
}
public class MB_DefaultMeshAssignCustomizer : ScriptableObject, IAssignToMeshCustomizer_SimpleAPI, IAssignToMeshCustomizer
{
	public virtual void meshAssign_UV0(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv = uvs;
	}

	public virtual void meshAssign_UV2(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv2 = uvs;
	}

	public virtual void meshAssign_UV3(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv3 = uvs;
	}

	public virtual void meshAssign_UV4(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv4 = uvs;
	}

	public virtual void meshAssign_UV5(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv5 = uvs;
	}

	public virtual void meshAssign_UV6(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv6 = uvs;
	}

	public virtual void meshAssign_UV7(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv7 = uvs;
	}

	public virtual void meshAssign_UV8(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes)
	{
		mesh.uv8 = uvs;
	}

	public virtual void meshAssign_colors(MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Color[] colors, float[] sliceIndexes)
	{
		mesh.colors = colors;
	}

	public static void DefaultDelegateAssignMeshColors(MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Color[] colors, float[] sliceIndexes)
	{
		mesh.colors = colors;
	}
}
public interface IAssignToMeshCustomizer
{
}
public interface IAssignToMeshCustomizer_SimpleAPI : IAssignToMeshCustomizer
{
	void meshAssign_UV0(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV2(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV3(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV4(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV5(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV6(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV7(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_UV8(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Vector2[] uvs, float[] sliceIndexes);

	void meshAssign_colors(MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, Mesh mesh, Color[] colors, float[] sliceIndexes);
}
public interface IAssignToMeshCustomizer_NativeArrays : IAssignToMeshCustomizer
{
	int UVchannelWithExtraParameter();

	void meshAssign_UV(int channel_0_to_7, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, NativeSlice<Vector3> outUVsInMesh, NativeSlice<float> sliceIndexes);

	void meshAssign_colors(MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, NativeSlice<Color> outUVsInMesh, NativeSlice<float> sliceIndexes);
}
public enum MB_MeshCombineAPIType
{
	simpleMeshAPI,
	betaNativeArrayAPI
}
public interface MB_IMeshBakerSettingsHolder
{
	MB_IMeshBakerSettings GetMeshBakerSettings();

	void GetMeshBakerSettingsAsSerializedProperty(out string propertyName, out UnityEngine.Object targetObj);
}
public interface MB_IMeshBakerSettings
{
	bool doBlendShapes { get; set; }

	bool doCol { get; set; }

	bool doNorm { get; set; }

	bool doTan { get; set; }

	bool doUV { get; set; }

	bool doUV3 { get; set; }

	bool doUV4 { get; set; }

	bool doUV5 { get; set; }

	bool doUV6 { get; set; }

	bool doUV7 { get; set; }

	bool doUV8 { get; set; }

	MB2_LightmapOptions lightmapOption { get; set; }

	float uv2UnwrappingParamsHardAngle { get; set; }

	float uv2UnwrappingParamsPackMargin { get; set; }

	bool optimizeAfterBake { get; set; }

	MB_MeshPivotLocation pivotLocationType { get; set; }

	Vector3 pivotLocation { get; set; }

	bool clearBuffersAfterBake { get; set; }

	MB_RenderType renderType { get; set; }

	bool smrNoExtraBonesWhenCombiningMeshRenderers { get; set; }

	bool smrMergeBlendShapesWithSameNames { get; set; }

	IAssignToMeshCustomizer assignToMeshCustomizer { get; set; }

	MB_MeshCombineAPIType meshAPI { get; set; }
}
public static class MeshBakerSettingsUtility
{
	public static MB_MeshVertexChannelFlags GetMeshChannelsAsFlags(MB_IMeshBakerSettings settings, bool doVerts, bool uvsSliceIdx_w)
	{
		return (MB_MeshVertexChannelFlags)((doVerts ? 1 : 0) | (settings.doNorm ? 2 : 0) | (settings.doTan ? 4 : 0) | (settings.doCol ? 8 : 0) | (settings.doUV ? 16 : 0) | (uvsSliceIdx_w ? 32 : 0) | (DoUV2getDataFromSourceMeshes(ref settings) ? 64 : 0) | (settings.doUV3 ? 128 : 0) | (settings.doUV4 ? 256 : 0) | (settings.doUV5 ? 512 : 0) | (settings.doUV6 ? 1024 : 0) | (settings.doUV7 ? 2048 : 0) | (settings.doUV8 ? 4096 : 0) | ((settings.renderType == MB_RenderType.skinnedMeshRenderer) ? 8192 : 0) | ((settings.renderType == MB_RenderType.skinnedMeshRenderer) ? 16384 : 0));
	}

	public static bool DoUV2getDataFromSourceMeshes(ref MB_IMeshBakerSettings settings)
	{
		if (settings.lightmapOption != MB2_LightmapOptions.copy_UV2_unchanged && settings.lightmapOption != MB2_LightmapOptions.preserve_current_lightmapping)
		{
			return settings.lightmapOption == MB2_LightmapOptions.copy_UV2_unchanged_to_separate_rects;
		}
		return true;
	}
}
public interface MB_IMeshCombinerSingle_BoneProcessor : IDisposable
{
	bool GetCachedSMRMeshData(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo);

	void AddBonesToNewBonesArrayAndAdjustBWIndexes1(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo, int vertsIdx);

	void AllocateAndSetupSMRDataStructures(List<MB3_MeshCombinerSingle.MB_DynamicGameObject> toAddDGOs, List<MB3_MeshCombinerSingle.MB_DynamicGameObject> mbDynamicObjectsInCombinedMesh, int newVertSize, MB3_MeshCombinerSingle.IVertexAndTriangleProcessor vertexAndTriangleProcessor);

	void BuildBoneIdx2DGOMapIfNecessary(int[] _goToDelete);

	void CopyBonesWeAreKeepingToNewBonesArrayAndAdjustBWIndexes(int totalDeleteVerts);

	void InsertNewBonesIntoBonesArray();

	int GetNewBonesSize();

	void RemoveBonesForDgosWeAreDeleting(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo);

	void CopyBoneWeightsFromMeshForDGOsInCombined(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo, int targVidx);

	void CopyVertsNormsTansToBuffers(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, Vector3[] nnorms, Vector4[] ntangs, Vector3[] nverts, Vector3[] normals, Vector4[] tangents, Vector3[] verts);

	void CopyVertsNormsTansToBuffers(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo, MB_IMeshBakerSettings settings, int vertsIdx, NativeSlice<Vector3> nnorms, NativeSlice<Vector4> ntangs, NativeSlice<Vector3> nverts, NativeSlice<Vector3> normals, NativeSlice<Vector4> tangents, NativeSlice<Vector3> verts);

	void DisposeOfTemporarySMRData();

	void ApplySMRdataToMeshToBuffer();

	void ApplySMRdataToMesh(MB3_MeshCombinerSingle combiner, Mesh mesh);

	void UpdateGameObjects_ReadBoneWeightInfoFromCombinedMesh();

	void UpdateGameObjects_UpdateBWIndexes(MB3_MeshCombinerSingle.MB_DynamicGameObject dgo);

	bool DB_CheckIntegrity();
}
[Serializable]
public class SerializableSourceBlendShape2Combined
{
	public GameObject[] srcGameObject;

	public int[] srcBlendShapeIdx;

	public GameObject[] combinedMeshTargetGameObject;

	public int[] blendShapeIdx;

	public void SetBuffers(GameObject[] srcGameObjs, int[] srcBlendShapeIdxs, GameObject[] targGameObjs, int[] targBlendShapeIdx)
	{
		srcGameObject = srcGameObjs;
		srcBlendShapeIdx = srcBlendShapeIdxs;
		combinedMeshTargetGameObject = targGameObjs;
		blendShapeIdx = targBlendShapeIdx;
	}

	public void DebugPrint()
	{
		if (srcGameObject == null)
		{
			UnityEngine.Debug.LogError("Empty");
			return;
		}
		for (int i = 0; i < srcGameObject.Length; i++)
		{
			UnityEngine.Debug.LogFormat("{0} {1} {2} {3}", srcGameObject[i], srcBlendShapeIdx[i], combinedMeshTargetGameObject[i], blendShapeIdx[i]);
		}
	}

	public Dictionary<MB3_MeshCombiner.MBBlendShapeKey, MB3_MeshCombiner.MBBlendShapeValue> GenerateMapFromSerializedData()
	{
		if (srcGameObject == null || srcBlendShapeIdx == null || combinedMeshTargetGameObject == null || blendShapeIdx == null || srcGameObject.Length != srcBlendShapeIdx.Length || srcGameObject.Length != combinedMeshTargetGameObject.Length || srcGameObject.Length != blendShapeIdx.Length)
		{
			UnityEngine.Debug.LogError("Error GenerateMapFromSerializedData. Serialized data was malformed or missing.");
			return null;
		}
		Dictionary<MB3_MeshCombiner.MBBlendShapeKey, MB3_MeshCombiner.MBBlendShapeValue> dictionary = new Dictionary<MB3_MeshCombiner.MBBlendShapeKey, MB3_MeshCombiner.MBBlendShapeValue>();
		for (int i = 0; i < srcGameObject.Length; i++)
		{
			GameObject gameObject = srcGameObject[i];
			GameObject gameObject2 = combinedMeshTargetGameObject[i];
			if (gameObject == null || gameObject2 == null)
			{
				UnityEngine.Debug.LogError("Error GenerateMapFromSerializedData. There were null references in the serialized data to source or target game objects. This can happen if the SerializableSourceBlendShape2Combined was serialized in a prefab but the source and target SkinnedMeshRenderer GameObjects  were not.");
				return null;
			}
			dictionary.Add(new MB3_MeshCombiner.MBBlendShapeKey(gameObject, srcBlendShapeIdx[i]), new MB3_MeshCombiner.MBBlendShapeValue
			{
				combinedMeshGameObject = gameObject2,
				blendShapeIndex = blendShapeIdx[i]
			});
		}
		return dictionary;
	}
}
public static class MB_TGAWriter
{
	public static void Write(Color[] pixels, int width, int height, string path)
	{
		if (File.Exists(path))
		{
			File.Delete(path);
		}
		FileStream output = File.Create(path);
		Write(pixels, width, height, output);
	}

	public static void Write(Color[] pixels, int width, int height, Stream output)
	{
		byte[] array = new byte[pixels.Length * 4];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				Color color = pixels[num];
				array[num2] = (byte)(color.b * 255f);
				array[num2 + 1] = (byte)(color.g * 255f);
				array[num2 + 2] = (byte)(color.r * 255f);
				array[num2 + 3] = (byte)(color.a * 255f);
				num++;
				num2 += 4;
			}
		}
		byte[] buffer = new byte[18]
		{
			0,
			0,
			2,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			(byte)(width & 0xFF),
			(byte)((width & 0xFF00) >> 8),
			(byte)(height & 0xFF),
			(byte)((height & 0xFF00) >> 8),
			32,
			0
		};
		using BinaryWriter binaryWriter = new BinaryWriter(output);
		binaryWriter.Write(buffer);
		binaryWriter.Write(array);
	}
}
public class MB_Utility
{
	public struct MeshAnalysisResult
	{
		public Rect uvRect;

		public bool hasOutOfBoundsUVs;

		public bool hasOverlappingSubmeshVerts;

		public bool hasUVs;

		public float submeshArea;
	}

	private class MB_Triangle
	{
		private int submeshIdx;

		private int[] vs = new int[3];

		public bool isSame(object obj)
		{
			MB_Triangle mB_Triangle = (MB_Triangle)obj;
			if (vs[0] == mB_Triangle.vs[0] && vs[1] == mB_Triangle.vs[1] && vs[2] == mB_Triangle.vs[2] && submeshIdx != mB_Triangle.submeshIdx)
			{
				return true;
			}
			return false;
		}

		public bool sharesVerts(MB_Triangle obj)
		{
			if ((vs[0] == obj.vs[0] || vs[0] == obj.vs[1] || vs[0] == obj.vs[2]) && submeshIdx != obj.submeshIdx)
			{
				return true;
			}
			if ((vs[1] == obj.vs[0] || vs[1] == obj.vs[1] || vs[1] == obj.vs[2]) && submeshIdx != obj.submeshIdx)
			{
				return true;
			}
			if ((vs[2] == obj.vs[0] || vs[2] == obj.vs[1] || vs[2] == obj.vs[2]) && submeshIdx != obj.submeshIdx)
			{
				return true;
			}
			return false;
		}

		public void Initialize(int[] ts, int idx, int sIdx)
		{
			vs[0] = ts[idx];
			vs[1] = ts[idx + 1];
			vs[2] = ts[idx + 2];
			submeshIdx = sIdx;
			Array.Sort(vs);
		}
	}

	public static bool DO_INTEGRITY_CHECKS;

	public static Texture2D createTextureCopy(Texture2D source, bool expectedToBeGammaCorrectedHint)
	{
		Texture2D texture2D = new Texture2D(source.width, source.height, TextureFormat.ARGB32, mipChain: true, !MBVersion.IsTexture_sRGBgammaCorrected(source, expectedToBeGammaCorrectedHint));
		texture2D.SetPixels(source.GetPixels());
		return texture2D;
	}

	public static bool ArrayBIsSubsetOfA(object[] a, object[] b)
	{
		for (int i = 0; i < b.Length; i++)
		{
			bool flag = false;
			for (int j = 0; j < a.Length; j++)
			{
				if (a[j] == b[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		return true;
	}

	public static Material[] GetGOMaterials(GameObject go)
	{
		if (go == null)
		{
			return new Material[0];
		}
		Material[] array = null;
		Mesh mesh = null;
		MeshRenderer component = go.GetComponent<MeshRenderer>();
		if (component != null)
		{
			array = component.sharedMaterials;
			MeshFilter component2 = go.GetComponent<MeshFilter>();
			if (component2 == null)
			{
				throw new Exception("Object " + go?.ToString() + " has a MeshRenderer but no MeshFilter.");
			}
			mesh = component2.sharedMesh;
		}
		SkinnedMeshRenderer component3 = go.GetComponent<SkinnedMeshRenderer>();
		if (component3 != null)
		{
			array = component3.sharedMaterials;
			mesh = component3.sharedMesh;
		}
		if (array == null)
		{
			UnityEngine.Debug.LogError("Object " + go.name + " does not have a MeshRenderer or a SkinnedMeshRenderer component");
			return new Material[0];
		}
		if (mesh == null)
		{
			UnityEngine.Debug.LogError("Object " + go.name + " has a MeshRenderer or SkinnedMeshRenderer but no mesh.");
			return new Material[0];
		}
		if (mesh.subMeshCount < array.Length)
		{
			UnityEngine.Debug.LogWarning("Object " + go?.ToString() + " has only " + mesh.subMeshCount + " submeshes and has " + array.Length + " materials. Extra materials do nothing.");
			Material[] array2 = new Material[mesh.subMeshCount];
			Array.Copy(array, array2, array2.Length);
			array = array2;
		}
		return array;
	}

	public static Mesh GetMesh(GameObject go)
	{
		if (go == null)
		{
			return null;
		}
		MeshFilter component = go.GetComponent<MeshFilter>();
		if (component != null)
		{
			return component.sharedMesh;
		}
		SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			return component2.sharedMesh;
		}
		return null;
	}

	public static void SetMesh(GameObject go, Mesh m)
	{
		if (go == null)
		{
			return;
		}
		MeshFilter component = go.GetComponent<MeshFilter>();
		if (component != null)
		{
			component.sharedMesh = m;
			return;
		}
		SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			component2.sharedMesh = m;
		}
	}

	public static Renderer GetRenderer(GameObject go)
	{
		if (go == null)
		{
			return null;
		}
		MeshRenderer component = go.GetComponent<MeshRenderer>();
		if (component != null)
		{
			return component;
		}
		SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			return component2;
		}
		return null;
	}

	public static void DisableRendererInSource(GameObject go)
	{
		if (go == null)
		{
			return;
		}
		MeshRenderer component = go.GetComponent<MeshRenderer>();
		if (component != null)
		{
			component.enabled = false;
			return;
		}
		SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
	}

	public static bool hasOutOfBoundsUVs(Mesh m, ref Rect uvBounds)
	{
		MeshAnalysisResult putResultHere = default(MeshAnalysisResult);
		bool result = hasOutOfBoundsUVs(m, ref putResultHere);
		uvBounds = putResultHere.uvRect;
		return result;
	}

	public static bool hasOutOfBoundsUVs(Mesh m, ref MeshAnalysisResult putResultHere, int submeshIndex = -1, int uvChannel = 0)
	{
		if (m == null)
		{
			putResultHere.hasOutOfBoundsUVs = false;
			return putResultHere.hasOutOfBoundsUVs;
		}
		return hasOutOfBoundsUVs(uvChannel switch
		{
			0 => m.uv, 
			1 => m.uv2, 
			2 => m.uv3, 
			_ => m.uv4, 
		}, m, ref putResultHere, submeshIndex);
	}

	public static bool hasOutOfBoundsUVs(Vector2[] uvs, Mesh m, ref MeshAnalysisResult putResultHere, int submeshIndex = -1)
	{
		putResultHere.hasUVs = true;
		if (uvs.Length == 0)
		{
			putResultHere.hasUVs = false;
			putResultHere.hasOutOfBoundsUVs = false;
			putResultHere.uvRect = default(Rect);
			return putResultHere.hasOutOfBoundsUVs;
		}
		if (submeshIndex >= m.subMeshCount)
		{
			putResultHere.hasOutOfBoundsUVs = false;
			putResultHere.uvRect = default(Rect);
			return putResultHere.hasOutOfBoundsUVs;
		}
		float num;
		float x;
		float num2;
		float y;
		if (submeshIndex >= 0)
		{
			int[] triangles = m.GetTriangles(submeshIndex);
			if (triangles.Length == 0)
			{
				putResultHere.hasOutOfBoundsUVs = false;
				putResultHere.uvRect = default(Rect);
				return putResultHere.hasOutOfBoundsUVs;
			}
			num = (x = uvs[triangles[0]].x);
			num2 = (y = uvs[triangles[0]].y);
			foreach (int num3 in triangles)
			{
				if (uvs[num3].x < num)
				{
					num = uvs[num3].x;
				}
				if (uvs[num3].x > x)
				{
					x = uvs[num3].x;
				}
				if (uvs[num3].y < num2)
				{
					num2 = uvs[num3].y;
				}
				if (uvs[num3].y > y)
				{
					y = uvs[num3].y;
				}
			}
		}
		else
		{
			num = (x = uvs[0].x);
			num2 = (y = uvs[0].y);
			for (int j = 0; j < uvs.Length; j++)
			{
				if (uvs[j].x < num)
				{
					num = uvs[j].x;
				}
				if (uvs[j].x > x)
				{
					x = uvs[j].x;
				}
				if (uvs[j].y < num2)
				{
					num2 = uvs[j].y;
				}
				if (uvs[j].y > y)
				{
					y = uvs[j].y;
				}
			}
		}
		Rect uvRect = new Rect
		{
			x = num,
			y = num2,
			width = x - num,
			height = y - num2
		};
		if (x > 1f || num < 0f || y > 1f || num2 < 0f)
		{
			putResultHere.hasOutOfBoundsUVs = true;
		}
		else
		{
			putResultHere.hasOutOfBoundsUVs = false;
		}
		putResultHere.uvRect = uvRect;
		return putResultHere.hasOutOfBoundsUVs;
	}

	public static bool hasOutOfBoundsUVs(NativeArray<Vector2> uvs, Mesh m, ref MeshAnalysisResult putResultHere, int submeshIndex = -1)
	{
		putResultHere.hasUVs = true;
		if (uvs.Length == 0)
		{
			putResultHere.hasUVs = false;
			putResultHere.hasOutOfBoundsUVs = false;
			putResultHere.uvRect = default(Rect);
			return putResultHere.hasOutOfBoundsUVs;
		}
		if (submeshIndex >= m.subMeshCount)
		{
			putResultHere.hasOutOfBoundsUVs = false;
			putResultHere.uvRect = default(Rect);
			return putResultHere.hasOutOfBoundsUVs;
		}
		float num;
		float x;
		float num2;
		float y;
		if (submeshIndex >= 0)
		{
			int[] triangles = m.GetTriangles(submeshIndex);
			if (triangles.Length == 0)
			{
				putResultHere.hasOutOfBoundsUVs = false;
				putResultHere.uvRect = default(Rect);
				return putResultHere.hasOutOfBoundsUVs;
			}
			num = (x = uvs[triangles[0]].x);
			num2 = (y = uvs[triangles[0]].y);
			foreach (int index in triangles)
			{
				if (uvs[index].x < num)
				{
					num = uvs[index].x;
				}
				if (uvs[index].x > x)
				{
					x = uvs[index].x;
				}
				if (uvs[index].y < num2)
				{
					num2 = uvs[index].y;
				}
				if (uvs[index].y > y)
				{
					y = uvs[index].y;
				}
			}
		}
		else
		{
			num = (x = uvs[0].x);
			num2 = (y = uvs[0].y);
			for (int j = 0; j < uvs.Length; j++)
			{
				if (uvs[j].x < num)
				{
					num = uvs[j].x;
				}
				if (uvs[j].x > x)
				{
					x = uvs[j].x;
				}
				if (uvs[j].y < num2)
				{
					num2 = uvs[j].y;
				}
				if (uvs[j].y > y)
				{
					y = uvs[j].y;
				}
			}
		}
		Rect uvRect = new Rect
		{
			x = num,
			y = num2,
			width = x - num,
			height = y - num2
		};
		if (x > 1f || num < 0f || y > 1f || num2 < 0f)
		{
			putResultHere.hasOutOfBoundsUVs = true;
		}
		else
		{
			putResultHere.hasOutOfBoundsUVs = false;
		}
		putResultHere.uvRect = uvRect;
		return putResultHere.hasOutOfBoundsUVs;
	}

	public static void setSolidColor(Texture2D t, Color c)
	{
		Color[] pixels = t.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = c;
		}
		t.SetPixels(pixels);
		t.Apply();
	}

	public static Texture2D resampleTexture(Texture2D source, bool expectToBeGammaCorrectedHint, int newWidth, int newHeight)
	{
		TextureFormat format = source.format;
		if (format == TextureFormat.ARGB32 || format == TextureFormat.RGBA32 || format == TextureFormat.BGRA32 || format == TextureFormat.RGB24 || format == TextureFormat.Alpha8 || format == TextureFormat.DXT1)
		{
			Texture2D texture2D = new Texture2D(newWidth, newHeight, TextureFormat.ARGB32, mipChain: true, !MBVersion.IsTexture_sRGBgammaCorrected(source, expectToBeGammaCorrectedHint));
			float num = newWidth;
			float num2 = newHeight;
			for (int i = 0; i < newWidth; i++)
			{
				for (int j = 0; j < newHeight; j++)
				{
					float u = (float)i / num;
					float v = (float)j / num2;
					texture2D.SetPixel(i, j, source.GetPixelBilinear(u, v));
				}
			}
			texture2D.Apply();
			return texture2D;
		}
		UnityEngine.Debug.LogError("Can only resize textures in formats ARGB32, RGBA32, BGRA32, RGB24, Alpha8 or DXT. texture:" + source?.ToString() + " was in format: " + source.format);
		return null;
	}

	public static bool AreAllSharedMaterialsDistinct(Material[] sharedMaterials)
	{
		for (int i = 0; i < sharedMaterials.Length; i++)
		{
			for (int j = i + 1; j < sharedMaterials.Length; j++)
			{
				if (sharedMaterials[i] == sharedMaterials[j])
				{
					return false;
				}
			}
		}
		return true;
	}

	public static void doSubmeshesShareVertsOrTris(Mesh m, ref MeshAnalysisResult mar)
	{
		int[][] array = new int[m.subMeshCount][];
		for (int i = 0; i < m.subMeshCount; i++)
		{
			array[i] = m.GetTriangles(i);
		}
		int[] array2 = new int[m.vertexCount];
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] = -1;
		}
		bool flag = false;
		for (int k = 0; k < m.subMeshCount; k++)
		{
			int[] array3 = array[k];
			foreach (int num in array3)
			{
				if (array2[num] != -1 && array2[num] != k)
				{
					flag = true;
					break;
				}
				array2[num] = k;
			}
		}
		if (flag)
		{
			mar.hasOverlappingSubmeshVerts = true;
		}
		else
		{
			mar.hasOverlappingSubmeshVerts = false;
		}
	}

	public static bool GetBounds(GameObject go, out Bounds b)
	{
		if (go == null)
		{
			UnityEngine.Debug.LogError("go paramater was null");
			b = new Bounds(Vector3.zero, Vector3.zero);
			return false;
		}
		Renderer renderer = GetRenderer(go);
		if (renderer == null)
		{
			UnityEngine.Debug.LogError("GetBounds must be called on an object with a Renderer");
			b = new Bounds(Vector3.zero, Vector3.zero);
			return false;
		}
		if (renderer is MeshRenderer)
		{
			b = renderer.bounds;
			return true;
		}
		if (renderer is SkinnedMeshRenderer)
		{
			b = renderer.bounds;
			return true;
		}
		UnityEngine.Debug.LogError("GetBounds must be called on an object with a MeshRender or a SkinnedMeshRenderer.");
		b = new Bounds(Vector3.zero, Vector3.zero);
		return false;
	}

	public static void Destroy(UnityEngine.Object o)
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(o);
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(o, allowDestroyingAssets: false);
		}
	}

	public static string ConvertAssetsRelativePathToFullSystemPath(string pth)
	{
		return Application.dataPath.Replace("Assets", "") + pth;
	}

	public static bool IsSceneInstance(GameObject go)
	{
		return go.scene.name != null;
	}

	public static string BoneWeightToString(BoneWeight bw)
	{
		return $"BoneWeight  {bw.boneIndex0}:{bw.weight0},  {bw.boneIndex1}:{bw.weight1},  {bw.boneIndex2}:{bw.weight2}, {bw.boneIndex3}:{bw.weight3}";
	}
}
public class MB_DefaultMeshAssignCustomizer_NativeArray : ScriptableObject, IAssignToMeshCustomizer_NativeArrays, IAssignToMeshCustomizer
{
	public virtual int UVchannelWithExtraParameter()
	{
		return -1;
	}

	public virtual void meshAssign_UV(int channel, MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, NativeSlice<Vector3> outUVsInMesh, NativeSlice<float> sliceIndexes)
	{
	}

	public virtual void meshAssign_colors(MB_IMeshBakerSettings settings, MB2_TextureBakeResults textureBakeResults, NativeSlice<Color> outUVsInMesh, NativeSlice<float> sliceIndexes)
	{
	}
}
[Serializable]
public struct AtlasPadding
{
	public int topBottom;

	public int leftRight;

	public AtlasPadding(int p)
	{
		topBottom = p;
		leftRight = p;
	}

	public AtlasPadding(int px, int py)
	{
		topBottom = py;
		leftRight = px;
	}
}
[Serializable]
public class AtlasPackingResult
{
	public int atlasX;

	public int atlasY;

	public int usedW;

	public int usedH;

	public Rect[] rects;

	public AtlasPadding[] padding;

	public int[] srcImgIdxs;

	public object data;

	public AtlasPackingResult(AtlasPadding[] pds)
	{
		padding = pds;
	}

	public void CalcUsedWidthAndHeight()
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		for (int i = 0; i < rects.Length; i++)
		{
			num3 += (float)padding[i].leftRight * 2f;
			num4 += (float)padding[i].topBottom * 2f;
			num = Mathf.Max(num, rects[i].x + rects[i].width);
			num2 = Mathf.Max(num2, rects[i].y + rects[i].height);
		}
		usedW = Mathf.CeilToInt(num * (float)atlasX + num3);
		usedH = Mathf.CeilToInt(num2 * (float)atlasY + num4);
		if (usedW > atlasX)
		{
			usedW = atlasX;
		}
		if (usedH > atlasY)
		{
			usedH = atlasY;
		}
	}

	public override string ToString()
	{
		return $"numRects: {rects.Length}, atlasX: {atlasX} atlasY: {atlasY} usedW: {usedW} usedH: {usedH}";
	}
}
public abstract class MB2_TexturePacker
{
	internal enum NodeType
	{
		Container,
		maxDim,
		regular
	}

	internal class PixRect
	{
		public int x;

		public int y;

		public int w;

		public int h;

		public PixRect()
		{
		}

		public PixRect(int xx, int yy, int ww, int hh)
		{
			x = xx;
			y = yy;
			w = ww;
			h = hh;
		}

		public override string ToString()
		{
			return $"x={x},y={y},w={w},h={h}";
		}
	}

	internal class Image
	{
		public int imgId;

		public int w;

		public int h;

		public int x;

		public int y;

		public Image(int id, int tw, int th, AtlasPadding padding, int minImageSizeX, int minImageSizeY)
		{
			imgId = id;
			w = Mathf.Max(tw + padding.leftRight * 2, minImageSizeX);
			h = Mathf.Max(th + padding.topBottom * 2, minImageSizeY);
		}

		public Image(Image im)
		{
			imgId = im.imgId;
			w = im.w;
			h = im.h;
			x = im.x;
			y = im.y;
		}
	}

	internal class ImgIDComparer : IComparer<Image>
	{
		public int Compare(Image x, Image y)
		{
			if (x.imgId > y.imgId)
			{
				return 1;
			}
			if (x.imgId == y.imgId)
			{
				return 0;
			}
			return -1;
		}
	}

	internal class ImageHeightComparer : IComparer<Image>
	{
		public int Compare(Image x, Image y)
		{
			if (x.h > y.h)
			{
				return -1;
			}
			if (x.h == y.h)
			{
				return 0;
			}
			return 1;
		}
	}

	internal class ImageWidthComparer : IComparer<Image>
	{
		public int Compare(Image x, Image y)
		{
			if (x.w > y.w)
			{
				return -1;
			}
			if (x.w == y.w)
			{
				return 0;
			}
			return 1;
		}
	}

	internal class ImageAreaComparer : IComparer<Image>
	{
		public int Compare(Image x, Image y)
		{
			int num = x.w * x.h;
			int num2 = y.w * y.h;
			if (num > num2)
			{
				return -1;
			}
			if (num == num2)
			{
				return 0;
			}
			return 1;
		}
	}

	public const int MAX_ATLAS_SIZE = 8192;

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	internal const int MAX_RECURSION_DEPTH = 10;

	public bool atlasMustBePowerOfTwo = true;

	public static int RoundToNearestPositivePowerOfTwo(int x)
	{
		int num = (int)Mathf.Pow(2f, Mathf.RoundToInt(Mathf.Log(x) / Mathf.Log(2f)));
		if (num == 0 || num == 1)
		{
			num = 2;
		}
		return num;
	}

	public static int CeilToNearestPowerOfTwo(int x)
	{
		int num = (int)Mathf.Pow(2f, Mathf.Ceil(Mathf.Log(x) / Mathf.Log(2f)));
		if (num == 0 || num == 1)
		{
			num = 2;
		}
		return num;
	}

	public abstract AtlasPackingResult[] GetRects(List<Vector2> imgWidthHeights, int maxDimensionX, int maxDimensionY, int padding);

	public abstract AtlasPackingResult[] GetRects(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionX, int maxDimensionY, bool doMultiAtlas);

	internal bool ScaleAtlasToFitMaxDim(Vector2 rootWH, List<Image> images, int maxDimensionX, int maxDimensionY, AtlasPadding padding, int minImageSizeX, int minImageSizeY, int masterImageSizeX, int masterImageSizeY, ref int outW, ref int outH, out float padX, out float padY, out int newMinSizeX, out int newMinSizeY)
	{
		newMinSizeX = minImageSizeX;
		newMinSizeY = minImageSizeY;
		bool result = false;
		padX = (float)padding.leftRight / (float)outW;
		if (rootWH.x > (float)maxDimensionX)
		{
			padX = (float)padding.leftRight / (float)maxDimensionX;
			float num = (float)maxDimensionX / rootWH.x;
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Packing exceeded atlas width shrinking to " + num);
			}
			for (int i = 0; i < images.Count; i++)
			{
				Image image = images[i];
				if ((float)image.w * num < (float)masterImageSizeX)
				{
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Small images are being scaled to zero. Will need to redo packing with larger minTexSizeX.");
					}
					result = true;
					newMinSizeX = Mathf.CeilToInt((float)minImageSizeX / num);
				}
				int num2 = (int)((float)(image.x + image.w) * num);
				image.x = (int)(num * (float)image.x);
				image.w = num2 - image.x;
			}
			outW = maxDimensionX;
		}
		padY = (float)padding.topBottom / (float)outH;
		if (rootWH.y > (float)maxDimensionY)
		{
			padY = (float)padding.topBottom / (float)maxDimensionY;
			float num3 = (float)maxDimensionY / rootWH.y;
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Packing exceeded atlas height shrinking to " + num3);
			}
			for (int j = 0; j < images.Count; j++)
			{
				Image image2 = images[j];
				if ((float)image2.h * num3 < (float)masterImageSizeY)
				{
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Small images are being scaled to zero. Will need to redo packing with larger minTexSizeY.");
					}
					result = true;
					newMinSizeY = Mathf.CeilToInt((float)minImageSizeY / num3);
				}
				int num4 = (int)((float)(image2.y + image2.h) * num3);
				image2.y = (int)(num3 * (float)image2.y);
				image2.h = num4 - image2.y;
			}
			outH = maxDimensionY;
		}
		return result;
	}

	public void ConvertToRectsWithoutPaddingAndNormalize01(AtlasPackingResult rr, AtlasPadding padding)
	{
		for (int i = 0; i < rr.rects.Length; i++)
		{
			rr.rects[i].x = (rr.rects[i].x + (float)padding.leftRight) / (float)rr.atlasX;
			rr.rects[i].y = (rr.rects[i].y + (float)padding.topBottom) / (float)rr.atlasY;
			rr.rects[i].width = (rr.rects[i].width - (float)(padding.leftRight * 2)) / (float)rr.atlasX;
			rr.rects[i].height = (rr.rects[i].height - (float)(padding.topBottom * 2)) / (float)rr.atlasY;
		}
	}
}
public class MB2_TexturePackerRegular : MB2_TexturePacker
{
	private class ProbeResult
	{
		public int w;

		public int h;

		public int outW;

		public int outH;

		public Node root;

		public bool largerOrEqualToMaxDim;

		public float efficiency;

		public float squareness;

		public float totalAtlasArea;

		public int numAtlases;

		public void Set(int ww, int hh, int outw, int outh, Node r, bool fits, float e, float sq)
		{
			w = ww;
			h = hh;
			outW = outw;
			outH = outh;
			root = r;
			largerOrEqualToMaxDim = fits;
			efficiency = e;
			squareness = sq;
		}

		public float GetScore(bool doPowerOfTwoScore)
		{
			float num = (largerOrEqualToMaxDim ? 1f : 0f);
			if (doPowerOfTwoScore)
			{
				return num * 2f + efficiency;
			}
			return squareness + 2f * efficiency + num;
		}

		public void PrintTree()
		{
			printTree(root, "  ");
		}
	}

	internal class Node
	{
		internal NodeType isFullAtlas;

		internal Node[] child = new Node[2];

		internal PixRect r;

		internal Image img;

		private ProbeResult bestRoot;

		internal Node(NodeType rootType)
		{
			isFullAtlas = rootType;
		}

		private bool isLeaf()
		{
			if (child[0] == null || child[1] == null)
			{
				return true;
			}
			return false;
		}

		internal Node Insert(Image im, bool handed)
		{
			int num;
			int num2;
			if (handed)
			{
				num = 0;
				num2 = 1;
			}
			else
			{
				num = 1;
				num2 = 0;
			}
			if (!isLeaf())
			{
				Node node = child[num].Insert(im, handed);
				if (node != null)
				{
					return node;
				}
				return child[num2].Insert(im, handed);
			}
			if (img != null)
			{
				return null;
			}
			if (r.w < im.w || r.h < im.h)
			{
				return null;
			}
			if (r.w == im.w && r.h == im.h)
			{
				img = im;
				return this;
			}
			child[num] = new Node(NodeType.regular);
			child[num2] = new Node(NodeType.regular);
			int num3 = r.w - im.w;
			int num4 = r.h - im.h;
			if (num3 > num4)
			{
				child[num].r = new PixRect(r.x, r.y, im.w, r.h);
				child[num2].r = new PixRect(r.x + im.w, r.y, r.w - im.w, r.h);
			}
			else
			{
				child[num].r = new PixRect(r.x, r.y, r.w, im.h);
				child[num2].r = new PixRect(r.x, r.y + im.h, r.w, r.h - im.h);
			}
			return child[num].Insert(im, handed);
		}
	}

	private ProbeResult bestRoot;

	public int atlasY;

	private static void printTree(Node r, string spc)
	{
		UnityEngine.Debug.Log(spc + "Nd img=" + (r.img != null) + " r=" + r.r);
		if (r.child[0] != null)
		{
			printTree(r.child[0], spc + "      ");
		}
		if (r.child[1] != null)
		{
			printTree(r.child[1], spc + "      ");
		}
	}

	private static void flattenTree(Node r, List<Image> putHere)
	{
		if (r.img != null)
		{
			r.img.x = r.r.x;
			r.img.y = r.r.y;
			putHere.Add(r.img);
		}
		if (r.child[0] != null)
		{
			flattenTree(r.child[0], putHere);
		}
		if (r.child[1] != null)
		{
			flattenTree(r.child[1], putHere);
		}
	}

	private static void drawGizmosNode(Node r)
	{
		Vector3 size = new Vector3(r.r.w, r.r.h, 0f);
		Vector3 center = new Vector3((float)r.r.x + size.x / 2f, (float)(-r.r.y) - size.y / 2f, 0f);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(center, size);
		if (r.img != null)
		{
			Gizmos.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
			size = new Vector3(r.img.w, r.img.h, 0f);
			Gizmos.DrawCube(new Vector3((float)r.r.x + size.x / 2f, (float)(-r.r.y) - size.y / 2f, 0f), size);
		}
		if (r.child[0] != null)
		{
			Gizmos.color = Color.red;
			drawGizmosNode(r.child[0]);
		}
		if (r.child[1] != null)
		{
			Gizmos.color = Color.green;
			drawGizmosNode(r.child[1]);
		}
	}

	public void DrawGizmos()
	{
		if (bestRoot != null)
		{
			drawGizmosNode(bestRoot.root);
			Gizmos.color = Color.yellow;
			Vector3 size = new Vector3(bestRoot.outW, -bestRoot.outH, 0f);
			Gizmos.DrawWireCube(new Vector3(size.x / 2f, size.y / 2f, 0f), size);
		}
	}

	private bool ProbeSingleAtlas(Image[] imgsToAdd, int idealAtlasW, int idealAtlasH, float imgArea, int maxAtlasDimX, int maxAtlasDimY, ProbeResult pr)
	{
		Node node = new Node(NodeType.maxDim);
		node.r = new PixRect(0, 0, idealAtlasW, idealAtlasH);
		for (int i = 0; i < imgsToAdd.Length; i++)
		{
			if (node.Insert(imgsToAdd[i], handed: false) == null)
			{
				return false;
			}
			if (i != imgsToAdd.Length - 1)
			{
				continue;
			}
			int x = 0;
			int y = 0;
			GetExtent(node, ref x, ref y);
			int num = x;
			int num2 = y;
			bool fits;
			float e;
			float sq;
			if (atlasMustBePowerOfTwo)
			{
				num = Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(x), maxAtlasDimX);
				num2 = Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(y), maxAtlasDimY);
				if (num2 < num / 2)
				{
					num2 = num / 2;
				}
				if (num < num2 / 2)
				{
					num = num2 / 2;
				}
				fits = x <= maxAtlasDimX && y <= maxAtlasDimY;
				float num3 = Mathf.Max(1f, (float)x / (float)maxAtlasDimX);
				float num4 = Mathf.Max(1f, (float)y / (float)maxAtlasDimY);
				float num5 = (float)num * num3 * (float)num2 * num4;
				e = 1f - (num5 - imgArea) / num5;
				sq = 1f;
			}
			else
			{
				e = 1f - ((float)(x * y) - imgArea) / (float)(x * y);
				sq = ((x >= y) ? ((float)y / (float)x) : ((float)x / (float)y));
				fits = x <= maxAtlasDimX && y <= maxAtlasDimY;
			}
			pr.Set(x, y, num, num2, node, fits, e, sq);
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Probe success efficiency w=" + x + " h=" + y + " e=" + e + " sq=" + sq + " fits=" + fits);
			}
			return true;
		}
		UnityEngine.Debug.LogError("Should never get here.");
		return false;
	}

	private bool ProbeMultiAtlas(Image[] imgsToAdd, int idealAtlasW, int idealAtlasH, float imgArea, int maxAtlasDimX, int maxAtlasDimY, ProbeResult pr)
	{
		int num = 0;
		Node node = new Node(NodeType.maxDim);
		node.r = new PixRect(0, 0, idealAtlasW, idealAtlasH);
		for (int i = 0; i < imgsToAdd.Length; i++)
		{
			if (node.Insert(imgsToAdd[i], handed: false) == null)
			{
				if (imgsToAdd[i].x > idealAtlasW && imgsToAdd[i].y > idealAtlasH)
				{
					return false;
				}
				Node obj = new Node(NodeType.Container)
				{
					r = new PixRect(0, 0, node.r.w + idealAtlasW, idealAtlasH)
				};
				Node node2 = new Node(NodeType.maxDim)
				{
					r = new PixRect(node.r.w, 0, idealAtlasW, idealAtlasH)
				};
				obj.child[1] = node2;
				obj.child[0] = node;
				node = obj;
				node.Insert(imgsToAdd[i], handed: false);
				num++;
			}
		}
		pr.numAtlases = num;
		pr.root = node;
		pr.totalAtlasArea = num * maxAtlasDimX * maxAtlasDimY;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			MB2_Log.LogDebug("Probe success efficiency numAtlases=" + num + " totalArea=" + pr.totalAtlasArea);
		}
		return true;
	}

	internal void GetExtent(Node r, ref int x, ref int y)
	{
		if (r.img != null)
		{
			if (r.r.x + r.img.w > x)
			{
				x = r.r.x + r.img.w;
			}
			if (r.r.y + r.img.h > y)
			{
				y = r.r.y + r.img.h;
			}
		}
		if (r.child[0] != null)
		{
			GetExtent(r.child[0], ref x, ref y);
		}
		if (r.child[1] != null)
		{
			GetExtent(r.child[1], ref x, ref y);
		}
	}

	private int StepWidthHeight(int oldVal, int step, int maxDim)
	{
		if (atlasMustBePowerOfTwo && oldVal < maxDim)
		{
			return oldVal * 2;
		}
		int num = oldVal + step;
		if (num > maxDim && oldVal < maxDim)
		{
			num = maxDim;
		}
		return num;
	}

	public override AtlasPackingResult[] GetRects(List<Vector2> imgWidthHeights, int maxDimensionX, int maxDimensionY, int atPadding)
	{
		List<AtlasPadding> list = new List<AtlasPadding>();
		for (int i = 0; i < imgWidthHeights.Count; i++)
		{
			AtlasPadding item = default(AtlasPadding);
			item.leftRight = (item.topBottom = atPadding);
			list.Add(item);
		}
		return GetRects(imgWidthHeights, list, maxDimensionX, maxDimensionY, doMultiAtlas: false);
	}

	public override AtlasPackingResult[] GetRects(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionX, int maxDimensionY, bool doMultiAtlas)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < paddings.Count; i++)
		{
			num = Mathf.Max(num, paddings[i].leftRight);
			num2 = Mathf.Max(num2, paddings[i].topBottom);
		}
		if (doMultiAtlas)
		{
			return _GetRectsMultiAtlas(imgWidthHeights, paddings, maxDimensionX, maxDimensionY, 2 + num * 2, 2 + num2 * 2, 2 + num * 2, 2 + num2 * 2);
		}
		AtlasPackingResult atlasPackingResult = _GetRectsSingleAtlas(imgWidthHeights, paddings, maxDimensionX, maxDimensionY, 2 + num * 2, 2 + num2 * 2, 2 + num * 2, 2 + num2 * 2, 0);
		if (atlasPackingResult == null)
		{
			return null;
		}
		return new AtlasPackingResult[1] { atlasPackingResult };
	}

	private AtlasPackingResult _GetRectsSingleAtlas(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionX, int maxDimensionY, int minImageSizeX, int minImageSizeY, int masterImageSizeX, int masterImageSizeY, int recursionDepth)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"_GetRects numImages={imgWidthHeights.Count}, maxDimension={maxDimensionX}, minImageSizeX={minImageSizeX}, minImageSizeY={minImageSizeY}, masterImageSizeX={masterImageSizeX}, masterImageSizeY={masterImageSizeY}, recursionDepth={recursionDepth}");
		}
		if (recursionDepth > 10 && LOG_LEVEL >= MB2_LogLevel.error)
		{
			UnityEngine.Debug.LogError("Maximum recursion depth reached. The baked atlas is likely not very good.  This happens when the packed atlases exceeds the maximum atlas size in one or both dimensions so that the atlas needs to be downscaled AND there are some very thin or very small images (only-a-few-pixels). these very thin images can 'vanish' completely when the atlas is downscaled.\n\n Try one or more of the following: using multiple atlases, increase the maximum atlas size, don't use 'force-power-of-two', remove the source materials that are are using very small/thin textures.");
		}
		float num = 0f;
		int num2 = 0;
		int num3 = 0;
		Image[] array = new Image[imgWidthHeights.Count];
		for (int i = 0; i < array.Length; i++)
		{
			int tw = (int)imgWidthHeights[i].x;
			int th = (int)imgWidthHeights[i].y;
			Image image = (array[i] = new Image(i, tw, th, paddings[i], minImageSizeX, minImageSizeY));
			num += (float)(image.w * image.h);
			num2 = Mathf.Max(num2, image.w);
			num3 = Mathf.Max(num3, image.h);
		}
		if ((float)num3 / (float)num2 > 2f)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Using height Comparer");
			}
			Array.Sort(array, new ImageHeightComparer());
		}
		else if ((double)((float)num3 / (float)num2) < 0.5)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Using width Comparer");
			}
			Array.Sort(array, new ImageWidthComparer());
		}
		else
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Using area Comparer");
			}
			Array.Sort(array, new ImageAreaComparer());
		}
		int num4 = (int)Mathf.Sqrt(num);
		int num5;
		int num6;
		if (atlasMustBePowerOfTwo)
		{
			num5 = (num6 = MB2_TexturePacker.RoundToNearestPositivePowerOfTwo(num4));
			if (num2 > num5)
			{
				num5 = MB2_TexturePacker.CeilToNearestPowerOfTwo(num5);
			}
			if (num3 > num6)
			{
				num6 = MB2_TexturePacker.CeilToNearestPowerOfTwo(num6);
			}
		}
		else
		{
			num5 = num4;
			num6 = num4;
			if (num2 > num4)
			{
				num5 = num2;
				num6 = Mathf.Max(Mathf.CeilToInt(num / (float)num2), num3);
			}
			if (num3 > num4)
			{
				num5 = Mathf.Max(Mathf.CeilToInt(num / (float)num3), num2);
				num6 = num3;
			}
		}
		if (num5 == 0)
		{
			num5 = 4;
		}
		if (num6 == 0)
		{
			num6 = 4;
		}
		int num7 = (int)((float)num5 * 0.15f);
		int num8 = (int)((float)num6 * 0.15f);
		if (num7 == 0)
		{
			num7 = 1;
		}
		if (num8 == 0)
		{
			num8 = 1;
		}
		int num9 = 2;
		int num10 = num5;
		int num11 = num6;
		while (num9 >= 1 && num11 < num4 * 1000)
		{
			bool flag = false;
			num9 = 0;
			num10 = num5;
			while (!flag && num10 < num4 * 1000)
			{
				ProbeResult probeResult = new ProbeResult();
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("Probing h=" + num11 + " w=" + num10);
				}
				if (ProbeSingleAtlas(array, num10, num11, num, maxDimensionX, maxDimensionY, probeResult))
				{
					flag = true;
					if (bestRoot == null)
					{
						bestRoot = probeResult;
					}
					else if (probeResult.GetScore(atlasMustBePowerOfTwo) > bestRoot.GetScore(atlasMustBePowerOfTwo))
					{
						bestRoot = probeResult;
					}
				}
				else
				{
					num9++;
					num10 = StepWidthHeight(num10, num7, maxDimensionX);
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						MB2_Log.LogDebug("increasing Width h=" + num11 + " w=" + num10);
					}
				}
			}
			num11 = StepWidthHeight(num11, num8, maxDimensionY);
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("increasing Height h=" + num11 + " w=" + num10);
			}
		}
		if (bestRoot == null)
		{
			return null;
		}
		int num12 = 0;
		int num13 = 0;
		if (atlasMustBePowerOfTwo)
		{
			num12 = Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(bestRoot.w), maxDimensionX);
			num13 = Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(bestRoot.h), maxDimensionY);
			if (num13 < num12 / 2)
			{
				num13 = num12 / 2;
			}
			if (num12 < num13 / 2)
			{
				num12 = num13 / 2;
			}
		}
		else
		{
			num12 = Mathf.Min(bestRoot.w, maxDimensionX);
			num13 = Mathf.Min(bestRoot.h, maxDimensionY);
		}
		bestRoot.outW = num12;
		bestRoot.outH = num13;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Best fit found: atlasW=" + num12 + " atlasH" + num13 + " w=" + bestRoot.w + " h=" + bestRoot.h + " efficiency=" + bestRoot.efficiency + " squareness=" + bestRoot.squareness + " fits in max dimension=" + bestRoot.largerOrEqualToMaxDim);
		}
		List<Image> list = new List<Image>();
		flattenTree(bestRoot.root, list);
		list.Sort(new ImgIDComparer());
		Vector2 rootWH = new Vector2(bestRoot.w, bestRoot.h);
		if (!ScaleAtlasToFitMaxDim(rootWH, list, maxDimensionX, maxDimensionY, paddings[0], minImageSizeX, minImageSizeY, masterImageSizeX, masterImageSizeY, ref num12, ref num13, out var padX, out var padY, out var newMinSizeX, out var newMinSizeY) || recursionDepth > 10)
		{
			AtlasPackingResult atlasPackingResult = new AtlasPackingResult(paddings.ToArray());
			atlasPackingResult.rects = new Rect[list.Count];
			atlasPackingResult.srcImgIdxs = new int[list.Count];
			atlasPackingResult.atlasX = num12;
			atlasPackingResult.atlasY = num13;
			atlasPackingResult.usedW = -1;
			atlasPackingResult.usedH = -1;
			for (int j = 0; j < list.Count; j++)
			{
				Image image2 = list[j];
				Rect rect = (atlasPackingResult.rects[j] = new Rect((float)image2.x / (float)num12 + padX, (float)image2.y / (float)num13 + padY, (float)image2.w / (float)num12 - padX * 2f, (float)image2.h / (float)num13 - padY * 2f));
				atlasPackingResult.srcImgIdxs[j] = image2.imgId;
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Image: " + j + " imgID=" + image2.imgId + " x=" + rect.x * (float)num12 + " y=" + rect.y * (float)num13 + " w=" + rect.width * (float)num12 + " h=" + rect.height * (float)num13 + " padding=" + paddings[j].leftRight * 2 + "x" + paddings[j].topBottom * 2);
				}
			}
			atlasPackingResult.CalcUsedWidthAndHeight();
			return atlasPackingResult;
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("==================== REDOING PACKING ================");
		}
		return _GetRectsSingleAtlas(imgWidthHeights, paddings, maxDimensionX, maxDimensionY, newMinSizeX, newMinSizeY, masterImageSizeX, masterImageSizeY, recursionDepth + 1);
	}

	private AtlasPackingResult[] _GetRectsMultiAtlas(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionPassedX, int maxDimensionPassedY, int minImageSizeX, int minImageSizeY, int masterImageSizeX, int masterImageSizeY)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"_GetRects numImages={imgWidthHeights.Count}, maxDimensionX={maxDimensionPassedX}, maxDimensionY={maxDimensionPassedY} minImageSizeX={minImageSizeX}, minImageSizeY={minImageSizeY}, masterImageSizeX={masterImageSizeX}, masterImageSizeY={masterImageSizeY}");
		}
		float num = 0f;
		int a = 0;
		int a2 = 0;
		Image[] array = new Image[imgWidthHeights.Count];
		int num2 = maxDimensionPassedX;
		int num3 = maxDimensionPassedY;
		if (atlasMustBePowerOfTwo)
		{
			num2 = MB2_TexturePacker.RoundToNearestPositivePowerOfTwo(num2);
			num3 = MB2_TexturePacker.RoundToNearestPositivePowerOfTwo(num3);
		}
		for (int i = 0; i < array.Length; i++)
		{
			int a3 = (int)imgWidthHeights[i].x;
			int a4 = (int)imgWidthHeights[i].y;
			a3 = Mathf.Min(a3, num2 - paddings[i].leftRight * 2);
			a4 = Mathf.Min(a4, num3 - paddings[i].topBottom * 2);
			Image image = (array[i] = new Image(i, a3, a4, paddings[i], minImageSizeX, minImageSizeY));
			num += (float)(image.w * image.h);
			a = Mathf.Max(a, image.w);
			a2 = Mathf.Max(a2, image.h);
		}
		int num4;
		int num5;
		if (atlasMustBePowerOfTwo)
		{
			num4 = MB2_TexturePacker.RoundToNearestPositivePowerOfTwo(num3);
			num5 = MB2_TexturePacker.RoundToNearestPositivePowerOfTwo(num2);
		}
		else
		{
			num4 = num3;
			num5 = num2;
		}
		if (num5 == 0)
		{
			num5 = 4;
		}
		if (num4 == 0)
		{
			num4 = 4;
		}
		ProbeResult probeResult = new ProbeResult();
		Array.Sort(array, new ImageHeightComparer());
		if (ProbeMultiAtlas(array, num5, num4, num, num2, num3, probeResult))
		{
			bestRoot = probeResult;
		}
		Array.Sort(array, new ImageWidthComparer());
		if (ProbeMultiAtlas(array, num5, num4, num, num2, num3, probeResult) && probeResult.totalAtlasArea < bestRoot.totalAtlasArea)
		{
			bestRoot = probeResult;
		}
		Array.Sort(array, new ImageAreaComparer());
		if (ProbeMultiAtlas(array, num5, num4, num, num2, num3, probeResult) && probeResult.totalAtlasArea < bestRoot.totalAtlasArea)
		{
			bestRoot = probeResult;
		}
		if (bestRoot == null)
		{
			return null;
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Best fit found: w=" + bestRoot.w + " h=" + bestRoot.h + " efficiency=" + bestRoot.efficiency + " squareness=" + bestRoot.squareness + " fits in max dimension=" + bestRoot.largerOrEqualToMaxDim);
		}
		List<AtlasPackingResult> list = new List<AtlasPackingResult>();
		List<Node> list2 = new List<Node>();
		Stack<Node> stack = new Stack<Node>();
		for (Node node = bestRoot.root; node != null; node = node.child[0])
		{
			stack.Push(node);
		}
		while (stack.Count > 0)
		{
			Node node = stack.Pop();
			if (node.isFullAtlas == NodeType.maxDim)
			{
				list2.Add(node);
			}
			if (node.child[1] != null)
			{
				for (node = node.child[1]; node != null; node = node.child[0])
				{
					stack.Push(node);
				}
			}
		}
		for (int j = 0; j < list2.Count; j++)
		{
			List<Image> list3 = new List<Image>();
			flattenTree(list2[j], list3);
			Rect[] array2 = new Rect[list3.Count];
			int[] array3 = new int[list3.Count];
			for (int k = 0; k < list3.Count; k++)
			{
				array2[k] = new Rect(list3[k].x - list2[j].r.x, list3[k].y, list3[k].w, list3[k].h);
				array3[k] = list3[k].imgId;
			}
			AtlasPackingResult atlasPackingResult = new AtlasPackingResult(paddings.ToArray());
			GetExtent(list2[j], ref atlasPackingResult.usedW, ref atlasPackingResult.usedH);
			atlasPackingResult.usedW -= list2[j].r.x;
			int w = list2[j].r.w;
			int h = list2[j].r.h;
			if (atlasMustBePowerOfTwo)
			{
				w = Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(atlasPackingResult.usedW), list2[j].r.w);
				h = Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(atlasPackingResult.usedH), list2[j].r.h);
				if (h < w / 2)
				{
					h = w / 2;
				}
				if (w < h / 2)
				{
					w = h / 2;
				}
			}
			else
			{
				w = atlasPackingResult.usedW;
				h = atlasPackingResult.usedH;
			}
			atlasPackingResult.atlasY = h;
			atlasPackingResult.atlasX = w;
			atlasPackingResult.rects = array2;
			atlasPackingResult.srcImgIdxs = array3;
			atlasPackingResult.CalcUsedWidthAndHeight();
			list.Add(atlasPackingResult);
			ConvertToRectsWithoutPaddingAndNormalize01(atlasPackingResult, paddings[j]);
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug($"Done GetRects ");
			}
		}
		return list.ToArray();
	}
}
public class MB2_TexturePackerHorizontalVert : MB2_TexturePacker
{
	public enum TexturePackingOrientation
	{
		horizontal,
		vertical
	}

	public TexturePackingOrientation packingOrientation;

	public bool stretchImagesToEdges = true;

	public override AtlasPackingResult[] GetRects(List<Vector2> imgWidthHeights, int maxDimensionX, int maxDimensionY, int padding)
	{
		List<AtlasPadding> list = new List<AtlasPadding>();
		for (int i = 0; i < imgWidthHeights.Count; i++)
		{
			AtlasPadding item = default(AtlasPadding);
			if (packingOrientation == TexturePackingOrientation.horizontal)
			{
				item.leftRight = 0;
				item.topBottom = 8;
			}
			else
			{
				item.leftRight = 8;
				item.topBottom = 0;
			}
			list.Add(item);
		}
		return GetRects(imgWidthHeights, list, maxDimensionX, maxDimensionY, doMultiAtlas: false);
	}

	public override AtlasPackingResult[] GetRects(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionX, int maxDimensionY, bool doMultiAtlas)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < paddings.Count; i++)
		{
			num = Mathf.Max(num, paddings[i].leftRight);
			num2 = Mathf.Max(num2, paddings[i].topBottom);
		}
		if (doMultiAtlas)
		{
			if (packingOrientation == TexturePackingOrientation.vertical)
			{
				return _GetRectsMultiAtlasVertical(imgWidthHeights, paddings, maxDimensionX, maxDimensionY, 2 + num * 2, 2 + num2 * 2, 2 + num * 2, 2 + num2 * 2);
			}
			return _GetRectsMultiAtlasHorizontal(imgWidthHeights, paddings, maxDimensionX, maxDimensionY, 2 + num * 2, 2 + num2 * 2, 2 + num * 2, 2 + num2 * 2);
		}
		AtlasPackingResult atlasPackingResult = _GetRectsSingleAtlas(imgWidthHeights, paddings, maxDimensionX, maxDimensionY, 2 + num * 2, 2 + num2 * 2, 2 + num * 2, 2 + num2 * 2, 0);
		if (atlasPackingResult == null)
		{
			return null;
		}
		return new AtlasPackingResult[1] { atlasPackingResult };
	}

	private AtlasPackingResult _GetRectsSingleAtlas(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionX, int maxDimensionY, int minImageSizeX, int minImageSizeY, int masterImageSizeX, int masterImageSizeY, int recursionDepth)
	{
		AtlasPackingResult atlasPackingResult = new AtlasPackingResult(paddings.ToArray());
		List<Rect> list = new List<Rect>();
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		List<Image> list2 = new List<Image>();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Packing rects for: " + imgWidthHeights.Count);
		}
		for (int i = 0; i < imgWidthHeights.Count; i++)
		{
			Image image = new Image(i, (int)imgWidthHeights[i].x, (int)imgWidthHeights[i].y, paddings[i], minImageSizeX, minImageSizeY);
			if (packingOrientation == TexturePackingOrientation.vertical)
			{
				image.h -= paddings[i].topBottom * 2;
				image.x = num;
				image.y = 0;
				list.Add(new Rect(image.w, image.h, num, 0f));
				num += image.w;
				num2 = Mathf.Max(num2, image.h);
			}
			else
			{
				image.w -= paddings[i].leftRight * 2;
				image.y = num;
				image.x = 0;
				list.Add(new Rect(image.w, image.h, 0f, num));
				num += image.h;
				num3 = Mathf.Max(num3, image.w);
			}
			list2.Add(image);
		}
		Vector2 rootWH = ((packingOrientation != TexturePackingOrientation.vertical) ? new Vector2(num3, num) : new Vector2(num, num2));
		int outW = (int)rootWH.x;
		int outH = (int)rootWH.y;
		if (packingOrientation != TexturePackingOrientation.vertical)
		{
			outH = ((!atlasMustBePowerOfTwo) ? Mathf.Min(outH, maxDimensionY) : Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(outH), maxDimensionY));
		}
		else
		{
			outW = ((!atlasMustBePowerOfTwo) ? Mathf.Min(outW, maxDimensionX) : Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(outW), maxDimensionX));
		}
		if (!ScaleAtlasToFitMaxDim(rootWH, list2, maxDimensionX, maxDimensionY, paddings[0], minImageSizeX, minImageSizeY, masterImageSizeX, masterImageSizeY, ref outW, ref outH, out var padX, out var padY, out var _, out var _))
		{
			atlasPackingResult = new AtlasPackingResult(paddings.ToArray());
			atlasPackingResult.rects = new Rect[list2.Count];
			atlasPackingResult.srcImgIdxs = new int[list2.Count];
			atlasPackingResult.atlasX = outW;
			atlasPackingResult.atlasY = outH;
			for (int j = 0; j < list2.Count; j++)
			{
				Image image2 = list2[j];
				Rect rect = ((packingOrientation != TexturePackingOrientation.vertical) ? (atlasPackingResult.rects[j] = new Rect((float)image2.x / (float)outW, (float)image2.y / (float)outH + padY, stretchImagesToEdges ? 1f : ((float)image2.w / (float)outW), (float)image2.h / (float)outH - padY * 2f)) : (atlasPackingResult.rects[j] = new Rect((float)image2.x / (float)outW + padX, (float)image2.y / (float)outH, (float)image2.w / (float)outW - padX * 2f, stretchImagesToEdges ? 1f : ((float)image2.h / (float)outH))));
				atlasPackingResult.srcImgIdxs[j] = image2.imgId;
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					MB2_Log.LogDebug("Image: " + j + " imgID=" + image2.imgId + " x=" + rect.x * (float)outW + " y=" + rect.y * (float)outH + " w=" + rect.width * (float)outW + " h=" + rect.height * (float)outH + " padding=" + paddings[j].ToString() + " outW=" + outW + " outH=" + outH);
				}
			}
			atlasPackingResult.CalcUsedWidthAndHeight();
			return atlasPackingResult;
		}
		UnityEngine.Debug.Log("Packing failed returning null atlas result");
		return null;
	}

	private AtlasPackingResult[] _GetRectsMultiAtlasVertical(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionPassedX, int maxDimensionPassedY, int minImageSizeX, int minImageSizeY, int masterImageSizeX, int masterImageSizeY)
	{
		List<AtlasPackingResult> list = new List<AtlasPackingResult>();
		int num = 0;
		int num2 = 0;
		int atlasX = 0;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Packing rects for: " + imgWidthHeights.Count);
		}
		List<Image> list2 = new List<Image>();
		for (int i = 0; i < imgWidthHeights.Count; i++)
		{
			Image image = new Image(i, (int)imgWidthHeights[i].x, (int)imgWidthHeights[i].y, paddings[i], minImageSizeX, minImageSizeY);
			image.h -= paddings[i].topBottom * 2;
			list2.Add(image);
		}
		list2.Sort(new ImageWidthComparer());
		List<Image> list3 = new List<Image>();
		List<Rect> list4 = new List<Rect>();
		int spaceRemaining = maxDimensionPassedX;
		while (list2.Count > 0 || list3.Count > 0)
		{
			Image image2 = PopLargestThatFits(list2, spaceRemaining, maxDimensionPassedX, list3.Count == 0);
			if (image2 == null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Atlas filled creating a new atlas ");
				}
				AtlasPackingResult atlasPackingResult = new AtlasPackingResult(paddings.ToArray());
				atlasPackingResult.atlasX = atlasX;
				atlasPackingResult.atlasY = num2;
				Rect[] array = new Rect[list3.Count];
				int[] array2 = new int[list3.Count];
				for (int j = 0; j < list3.Count; j++)
				{
					Rect rect = new Rect(list3[j].x, list3[j].y, list3[j].w, stretchImagesToEdges ? num2 : list3[j].h);
					array[j] = rect;
					array2[j] = list3[j].imgId;
				}
				atlasPackingResult.rects = array;
				atlasPackingResult.srcImgIdxs = array2;
				atlasPackingResult.CalcUsedWidthAndHeight();
				list3.Clear();
				list4.Clear();
				num = 0;
				num2 = 0;
				list.Add(atlasPackingResult);
				spaceRemaining = maxDimensionPassedX;
			}
			else
			{
				image2.x = num;
				image2.y = 0;
				list3.Add(image2);
				list4.Add(new Rect(num, 0f, image2.w, image2.h));
				num += image2.w;
				num2 = Mathf.Max(num2, image2.h);
				atlasX = num;
				spaceRemaining = maxDimensionPassedX - num;
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			int atlasX2 = list[k].atlasX;
			int outH = Mathf.Min(list[k].atlasY, maxDimensionPassedY);
			atlasX2 = ((!atlasMustBePowerOfTwo) ? Mathf.Min(atlasX2, maxDimensionPassedX) : Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(atlasX2), maxDimensionPassedX));
			list[k].atlasX = atlasX2;
			ScaleAtlasToFitMaxDim(new Vector2(list[k].atlasX, list[k].atlasY), list3, maxDimensionPassedX, maxDimensionPassedY, paddings[0], minImageSizeX, minImageSizeY, masterImageSizeX, masterImageSizeY, ref atlasX2, ref outH, out var _, out var _, out var _, out var _);
		}
		for (int l = 0; l < list.Count; l++)
		{
			ConvertToRectsWithoutPaddingAndNormalize01(list[l], paddings[l]);
			list[l].CalcUsedWidthAndHeight();
		}
		return list.ToArray();
	}

	private AtlasPackingResult[] _GetRectsMultiAtlasHorizontal(List<Vector2> imgWidthHeights, List<AtlasPadding> paddings, int maxDimensionPassedX, int maxDimensionPassedY, int minImageSizeX, int minImageSizeY, int masterImageSizeX, int masterImageSizeY)
	{
		List<AtlasPackingResult> list = new List<AtlasPackingResult>();
		int num = 0;
		int atlasY = 0;
		int num2 = 0;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Packing rects for: " + imgWidthHeights.Count);
		}
		List<Image> list2 = new List<Image>();
		for (int i = 0; i < imgWidthHeights.Count; i++)
		{
			Image image = new Image(i, (int)imgWidthHeights[i].x, (int)imgWidthHeights[i].y, paddings[i], minImageSizeX, minImageSizeY);
			image.w -= paddings[i].leftRight * 2;
			list2.Add(image);
		}
		list2.Sort(new ImageHeightComparer());
		List<Image> list3 = new List<Image>();
		List<Rect> list4 = new List<Rect>();
		int spaceRemaining = maxDimensionPassedY;
		while (list2.Count > 0 || list3.Count > 0)
		{
			Image image2 = PopLargestThatFits(list2, spaceRemaining, maxDimensionPassedY, list3.Count == 0);
			if (image2 == null)
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Atlas filled creating a new atlas ");
				}
				AtlasPackingResult atlasPackingResult = new AtlasPackingResult(paddings.ToArray());
				atlasPackingResult.atlasX = num2;
				atlasPackingResult.atlasY = atlasY;
				Rect[] array = new Rect[list3.Count];
				int[] array2 = new int[list3.Count];
				for (int j = 0; j < list3.Count; j++)
				{
					Rect rect = new Rect(list3[j].x, list3[j].y, stretchImagesToEdges ? num2 : list3[j].w, list3[j].h);
					array[j] = rect;
					array2[j] = list3[j].imgId;
				}
				atlasPackingResult.rects = array;
				atlasPackingResult.srcImgIdxs = array2;
				list3.Clear();
				list4.Clear();
				num = 0;
				atlasY = 0;
				list.Add(atlasPackingResult);
				spaceRemaining = maxDimensionPassedY;
			}
			else
			{
				image2.x = 0;
				image2.y = num;
				list3.Add(image2);
				list4.Add(new Rect(0f, num, image2.w, image2.h));
				num += image2.h;
				num2 = Mathf.Max(num2, image2.w);
				atlasY = num;
				spaceRemaining = maxDimensionPassedY - num;
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			int atlasY2 = list[k].atlasY;
			int outW = Mathf.Min(list[k].atlasX, maxDimensionPassedX);
			atlasY2 = ((!atlasMustBePowerOfTwo) ? Mathf.Min(atlasY2, maxDimensionPassedY) : Mathf.Min(MB2_TexturePacker.CeilToNearestPowerOfTwo(atlasY2), maxDimensionPassedY));
			list[k].atlasY = atlasY2;
			ScaleAtlasToFitMaxDim(new Vector2(list[k].atlasX, list[k].atlasY), list3, maxDimensionPassedX, maxDimensionPassedY, paddings[0], minImageSizeX, minImageSizeY, masterImageSizeX, masterImageSizeY, ref outW, ref atlasY2, out var _, out var _, out var _, out var _);
		}
		for (int l = 0; l < list.Count; l++)
		{
			ConvertToRectsWithoutPaddingAndNormalize01(list[l], paddings[l]);
			list[l].CalcUsedWidthAndHeight();
		}
		return list.ToArray();
	}

	private Image PopLargestThatFits(List<Image> images, int spaceRemaining, int maxDim, bool emptyAtlas)
	{
		if (images.Count == 0)
		{
			return null;
		}
		int num = ((packingOrientation != TexturePackingOrientation.vertical) ? images[0].h : images[0].w);
		if (images.Count > 0 && num >= maxDim)
		{
			if (emptyAtlas)
			{
				Image result = images[0];
				images.RemoveAt(0);
				return result;
			}
			return null;
		}
		int i;
		for (i = 0; i < images.Count; i++)
		{
			if (num < spaceRemaining)
			{
				break;
			}
		}
		if (i < images.Count)
		{
			Image result2 = images[i];
			images.RemoveAt(i);
			return result2;
		}
		return null;
	}
}
internal interface MB_ITextureCombinerPacker
{
	bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data);

	IEnumerator ConvertTexturesToReadableFormats(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL);

	AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL);

	IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL);
}
internal abstract class MB3_TextureCombinerPackerRoot : MB_ITextureCombinerPacker
{
	public abstract bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data);

	internal static void CreateTemporaryTexturesForAtlas(List<MB_TexSet> distinctMaterialTextures, MB3_TextureCombiner combiner, int propIdx, MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
		{
			MB_TexSet mB_TexSet = data.distinctMaterialTextures[i];
			if (mB_TexSet.ts[propIdx].isNull)
			{
				Color colorForTemporaryTexture = data.nonTexturePropertyBlender.GetColorForTemporaryTexture(mB_TexSet.matsAndGOs.mats[0].mat, data.texPropertyNames[propIdx]);
				mB_TexSet.CreateColoredTexToReplaceNull(data.texPropertyNames[propIdx].name, propIdx, data._fixOutOfBoundsUVs, combiner, colorForTemporaryTexture, MB3_TextureCombiner.ShouldTextureBeLinear(data.texPropertyNames[propIdx]));
			}
		}
	}

	internal static void SaveAtlasAndConfigureResultMaterial(MB3_TextureCombinerPipeline.TexturePipelineData data, MB2_EditorMethodsInterface textureEditorMethods, Texture2D atlas, ShaderTextureProperty property, int propIdx)
	{
		bool flag = MB3_TextureCombinerPipeline._DoAnySrcMatsHaveProperty(propIdx, data.allTexturesAreNullAndSameColor);
		if (data._saveAtlasesAsAssets && textureEditorMethods != null)
		{
			textureEditorMethods.SaveAtlasToAssetDatabase(atlas, property, propIdx, flag, data.resultMaterial);
		}
		else if (flag)
		{
			SetPropertyOnMaterial(data.resultMaterial, property.name, atlas);
		}
		if (flag)
		{
			data.resultMaterial.SetTextureOffset(property.name, Vector2.zero);
			data.resultMaterial.SetTextureScale(property.name, Vector2.one);
		}
	}

	internal static void SetPropertyOnMaterial(Material mat, string propertyName, Texture2D atlas)
	{
		mat.SetTexture(propertyName, atlas);
	}

	public static AtlasPackingResult[] CalculateAtlasRectanglesStatic(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		List<Vector2> list = new List<Vector2>();
		for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
		{
			list.Add(new Vector2(data.distinctMaterialTextures[i].idealWidth_pix, data.distinctMaterialTextures[i].idealHeight_pix));
		}
		MB2_TexturePacker mB2_TexturePacker = MB3_TextureCombinerPipeline.CreateTexturePacker(data._packingAlgorithm);
		mB2_TexturePacker.atlasMustBePowerOfTwo = data._meshBakerTexturePackerForcePowerOfTwo;
		List<AtlasPadding> list2 = new List<AtlasPadding>();
		for (int j = 0; j < list.Count; j++)
		{
			AtlasPadding item = new AtlasPadding
			{
				topBottom = data._atlasPadding_pix,
				leftRight = data._atlasPadding_pix
			};
			if (data._packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal)
			{
				item.leftRight = 0;
			}
			if (data._packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical)
			{
				item.topBottom = 0;
			}
			list2.Add(item);
		}
		return mB2_TexturePacker.GetRects(list, list2, data._maxAtlasWidth, data._maxAtlasHeight, doMultiAtlas);
	}

	public static void MakeProceduralTexturesReadable(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
	}

	public virtual IEnumerator ConvertTexturesToReadableFormats(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
		{
			for (int j = 0; j < data.texPropertyNames.Count; j++)
			{
				MeshBakerMaterialTexture meshBakerMaterialTexture = data.distinctMaterialTextures[i].ts[j];
				if (!meshBakerMaterialTexture.isNull && textureEditorMethods != null)
				{
					Texture texture2D = meshBakerMaterialTexture.GetTexture2D();
					TextureFormat targetFormat = TextureFormat.RGBA32;
					progressInfo?.Invoke($"Convert texture {texture2D} to readable format ", 0.5f);
					textureEditorMethods.ConvertTextureFormat_DefaultPlatform((Texture2D)texture2D, targetFormat, data.texPropertyNames[j].isNormalMap);
				}
			}
		}
		yield break;
	}

	public virtual AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		return CalculateAtlasRectanglesStatic(data, doMultiAtlas, LOG_LEVEL);
	}

	public abstract IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL);
}
[Serializable]
public class ShaderTextureProperty
{
	public string name;

	public bool isNormalMap;

	public bool isGammaCorrected;

	[HideInInspector]
	public bool isNormalDontKnow;

	public ShaderTextureProperty(string n, bool norm)
	{
		name = n;
		isNormalMap = norm;
		isGammaCorrected = !isNormalMap;
		isNormalDontKnow = false;
	}

	public ShaderTextureProperty(string n, bool norm, bool isGamma, bool isNormalDontKnow)
	{
		name = n;
		isNormalMap = norm;
		isGammaCorrected = isGamma;
		this.isNormalDontKnow = isNormalDontKnow;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ShaderTextureProperty))
		{
			return false;
		}
		ShaderTextureProperty shaderTextureProperty = (ShaderTextureProperty)obj;
		if (!name.Equals(shaderTextureProperty.name))
		{
			return false;
		}
		if (isNormalMap != shaderTextureProperty.isNormalMap)
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static string[] GetNames(List<ShaderTextureProperty> props)
	{
		string[] array = new string[props.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = props[i].name;
		}
		return array;
	}
}
[Serializable]
public class MB3_TextureCombiner
{
	public class CreateAtlasesCoroutineResult
	{
		public bool success = true;

		public bool isFinished;
	}

	internal class TemporaryTexture
	{
		internal string property;

		internal Texture2D texture;

		public TemporaryTexture(string prop, Texture2D tex)
		{
			property = prop;
			texture = tex;
		}
	}

	public class CombineTexturesIntoAtlasesCoroutineResult
	{
		public bool success = true;

		public bool isFinished;
	}

	public const int TEMP_SOLID_COLOR_TEXTURE_SIZE = 16;

	public static Color NEUTRAL_NORMAL_MAP_COLOR_SWIZZLED = new Color(1f, 0.5f, 0.5f, 0.5f);

	public static Color NEUTRAL_NORMAL_MAP_COLOR_NON_SWIZZLED = new Color(0.5f, 0.5f, 1f, 0.5f);

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	[SerializeField]
	protected MB2_TextureBakeResults _textureBakeResults;

	[SerializeField]
	protected int _atlasPadding = 1;

	[SerializeField]
	protected int _maxAtlasSize = 1;

	[SerializeField]
	protected int _maxAtlasWidthOverride = 8192;

	[SerializeField]
	protected int _maxAtlasHeightOverride = 8192;

	[SerializeField]
	protected bool _useMaxAtlasWidthOverride;

	[SerializeField]
	protected bool _useMaxAtlasHeightOverride;

	[SerializeField]
	protected bool _resizePowerOfTwoTextures;

	[SerializeField]
	protected bool _fixOutOfBoundsUVs;

	[SerializeField]
	protected int _layerTexturePackerFastMesh = -1;

	[SerializeField]
	protected int _maxTilingBakeSize = 1024;

	[SerializeField]
	protected bool _saveAtlasesAsAssets;

	[SerializeField]
	protected MB2_TextureBakeResults.ResultType _resultType;

	[SerializeField]
	protected MB2_PackingAlgorithmEnum _packingAlgorithm;

	[SerializeField]
	protected bool _meshBakerTexturePackerForcePowerOfTwo = true;

	[SerializeField]
	protected List<ShaderTextureProperty> _customShaderPropNames = new List<ShaderTextureProperty>();

	[SerializeField]
	protected bool _normalizeTexelDensity;

	[SerializeField]
	protected bool _considerNonTextureProperties;

	protected bool _doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize;

	private List<TemporaryTexture> _temporaryTextures = new List<TemporaryTexture>();

	public static bool _RunCorutineWithoutPauseIsRunning = false;

	public MB2_TextureBakeResults textureBakeResults
	{
		get
		{
			return _textureBakeResults;
		}
		set
		{
			_textureBakeResults = value;
		}
	}

	public int atlasPadding
	{
		get
		{
			return _atlasPadding;
		}
		set
		{
			_atlasPadding = value;
		}
	}

	public int maxAtlasSize
	{
		get
		{
			return _maxAtlasSize;
		}
		set
		{
			_maxAtlasSize = value;
		}
	}

	public virtual int maxAtlasWidthOverride
	{
		get
		{
			return _maxAtlasWidthOverride;
		}
		set
		{
			_maxAtlasWidthOverride = value;
		}
	}

	public virtual int maxAtlasHeightOverride
	{
		get
		{
			return _maxAtlasHeightOverride;
		}
		set
		{
			_maxAtlasHeightOverride = value;
		}
	}

	public virtual bool useMaxAtlasWidthOverride
	{
		get
		{
			return _useMaxAtlasWidthOverride;
		}
		set
		{
			_useMaxAtlasWidthOverride = value;
		}
	}

	public virtual bool useMaxAtlasHeightOverride
	{
		get
		{
			return _useMaxAtlasHeightOverride;
		}
		set
		{
			_useMaxAtlasHeightOverride = value;
		}
	}

	public bool resizePowerOfTwoTextures
	{
		get
		{
			return _resizePowerOfTwoTextures;
		}
		set
		{
			_resizePowerOfTwoTextures = value;
		}
	}

	public bool fixOutOfBoundsUVs
	{
		get
		{
			return _fixOutOfBoundsUVs;
		}
		set
		{
			_fixOutOfBoundsUVs = value;
		}
	}

	public int layerTexturePackerFastMesh
	{
		get
		{
			return _layerTexturePackerFastMesh;
		}
		set
		{
			_layerTexturePackerFastMesh = value;
		}
	}

	public int maxTilingBakeSize
	{
		get
		{
			return _maxTilingBakeSize;
		}
		set
		{
			_maxTilingBakeSize = value;
		}
	}

	public bool saveAtlasesAsAssets
	{
		get
		{
			return _saveAtlasesAsAssets;
		}
		set
		{
			_saveAtlasesAsAssets = value;
		}
	}

	public MB2_TextureBakeResults.ResultType resultType
	{
		get
		{
			return _resultType;
		}
		set
		{
			_resultType = value;
		}
	}

	public MB2_PackingAlgorithmEnum packingAlgorithm
	{
		get
		{
			return _packingAlgorithm;
		}
		set
		{
			_packingAlgorithm = value;
		}
	}

	public bool meshBakerTexturePackerForcePowerOfTwo
	{
		get
		{
			return _meshBakerTexturePackerForcePowerOfTwo;
		}
		set
		{
			_meshBakerTexturePackerForcePowerOfTwo = value;
		}
	}

	public List<ShaderTextureProperty> customShaderPropNames
	{
		get
		{
			return _customShaderPropNames;
		}
		set
		{
			_customShaderPropNames = value;
		}
	}

	public bool considerNonTextureProperties
	{
		get
		{
			return _considerNonTextureProperties;
		}
		set
		{
			_considerNonTextureProperties = value;
		}
	}

	public bool doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize
	{
		get
		{
			return _doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize;
		}
		set
		{
			_doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize = value;
		}
	}

	public static void RunCorutineWithoutPause(IEnumerator cor, int recursionDepth)
	{
		if (recursionDepth == 0)
		{
			_RunCorutineWithoutPauseIsRunning = true;
		}
		if (recursionDepth > 20)
		{
			UnityEngine.Debug.LogError("Recursion Depth Exceeded.");
			return;
		}
		while (cor.MoveNext())
		{
			object current = cor.Current;
			if (!(current is YieldInstruction) && current != null && current is IEnumerator)
			{
				RunCorutineWithoutPause((IEnumerator)cor.Current, recursionDepth + 1);
			}
		}
		if (recursionDepth == 0)
		{
			_RunCorutineWithoutPauseIsRunning = false;
		}
	}

	public bool CombineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects resultAtlasesAndRects, Material resultMaterial, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, MB2_EditorMethodsInterface textureEditorMethods = null, List<AtlasPackingResult> packingResults = null, bool onlyPackRects = false, bool splitAtlasWhenPackingIfTooBig = false)
	{
		CombineTexturesIntoAtlasesCoroutineResult combineTexturesIntoAtlasesCoroutineResult = new CombineTexturesIntoAtlasesCoroutineResult();
		RunCorutineWithoutPause(_CombineTexturesIntoAtlases(progressInfo, combineTexturesIntoAtlasesCoroutineResult, resultAtlasesAndRects, resultMaterial, objsToMesh, allowedMaterialsFilter, texPropsToIgnore, textureEditorMethods, packingResults, onlyPackRects, splitAtlasWhenPackingIfTooBig), 0);
		if (!combineTexturesIntoAtlasesCoroutineResult.success)
		{
			UnityEngine.Debug.LogError("Failed to generate atlases.");
		}
		return combineTexturesIntoAtlasesCoroutineResult.success;
	}

	public IEnumerator CombineTexturesIntoAtlasesCoroutine(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects resultAtlasesAndRects, Material resultMaterial, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, MB2_EditorMethodsInterface textureEditorMethods = null, CombineTexturesIntoAtlasesCoroutineResult coroutineResult = null, float maxTimePerFrame = 0.01f, List<AtlasPackingResult> packingResults = null, bool onlyPackRects = false, bool splitAtlasWhenPackingIfTooBig = false)
	{
		coroutineResult.success = true;
		coroutineResult.isFinished = false;
		if (maxTimePerFrame <= 0f)
		{
			UnityEngine.Debug.LogError("maxTimePerFrame must be a value greater than zero");
			coroutineResult.isFinished = true;
		}
		else
		{
			yield return _CombineTexturesIntoAtlases(progressInfo, coroutineResult, resultAtlasesAndRects, resultMaterial, objsToMesh, allowedMaterialsFilter, texPropsToIgnore, textureEditorMethods, packingResults, onlyPackRects, splitAtlasWhenPackingIfTooBig);
			coroutineResult.isFinished = true;
		}
	}

	private IEnumerator _CombineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, CombineTexturesIntoAtlasesCoroutineResult result, MB_AtlasesAndRects resultAtlasesAndRects, Material resultMaterial, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, MB2_EditorMethodsInterface textureEditorMethods, List<AtlasPackingResult> atlasPackingResult, bool onlyPackRects, bool splitAtlasWhenPackingIfTooBig)
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();
		try
		{
			_temporaryTextures.Clear();
			MeshBakerMaterialTexture.readyToBuildAtlases = false;
			if (textureEditorMethods != null)
			{
				textureEditorMethods.Clear();
				textureEditorMethods.OnPreTextureBake();
			}
			if (splitAtlasWhenPackingIfTooBig && !onlyPackRects)
			{
				UnityEngine.Debug.LogError("Can only use 'splitAtlasWhenPackingIfTooLarge' with 'onlyPackRects'");
				result.success = false;
				yield break;
			}
			if (objsToMesh == null || objsToMesh.Count == 0)
			{
				UnityEngine.Debug.LogError("No meshes to combine. Please assign some meshes to combine.");
				result.success = false;
				yield break;
			}
			if (_atlasPadding < 0)
			{
				UnityEngine.Debug.LogError("Atlas padding must be zero or greater.");
				result.success = false;
				yield break;
			}
			if (_maxTilingBakeSize < 2 || _maxTilingBakeSize > 8192)
			{
				UnityEngine.Debug.LogError("Invalid value for max tiling bake size.");
				result.success = false;
				yield break;
			}
			for (int i = 0; i < objsToMesh.Count; i++)
			{
				Material[] gOMaterials = MB_Utility.GetGOMaterials(objsToMesh[i]);
				for (int j = 0; j < gOMaterials.Length; j++)
				{
					if (gOMaterials[j] == null)
					{
						UnityEngine.Debug.LogError("Game object " + objsToMesh[i]?.ToString() + " has a null material");
						result.success = false;
						yield break;
					}
				}
			}
			progressInfo?.Invoke("Collecting textures for " + objsToMesh.Count + " meshes.", 0.01f);
			MB3_TextureCombinerPipeline.TexturePipelineData texturePipelineData = LoadPipelineData(resultMaterial, new List<ShaderTextureProperty>(), objsToMesh, allowedMaterialsFilter, texPropsToIgnore, new List<MB_TexSet>());
			if (!MB3_TextureCombinerPipeline._CollectPropertyNames(texturePipelineData, LOG_LEVEL))
			{
				result.success = false;
				yield break;
			}
			if (_fixOutOfBoundsUVs && (_packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal || _packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical) && LOG_LEVEL >= MB2_LogLevel.info)
			{
				UnityEngine.Debug.LogWarning("'Consider Mesh UVs' is enabled but packing algorithm is MeshBakerTexturePacker_Horizontal or MeshBakerTexturePacker_Vertical. It is recommended to use these packers without using 'Consider Mesh UVs'");
			}
			texturePipelineData.nonTexturePropertyBlender.LoadTextureBlendersIfNeeded(texturePipelineData.resultMaterial);
			if (onlyPackRects)
			{
				yield return __RunTexturePackerOnly(result, resultAtlasesAndRects, texturePipelineData, splitAtlasWhenPackingIfTooBig, textureEditorMethods, atlasPackingResult);
			}
			else
			{
				yield return __CombineTexturesIntoAtlases(progressInfo, result, resultAtlasesAndRects, texturePipelineData, textureEditorMethods);
			}
		}
		finally
		{
			MB3_TextureCombiner mB3_TextureCombiner = this;
			mB3_TextureCombiner._destroyAllTemporaryTextures();
			mB3_TextureCombiner._restoreProceduralMaterials();
			if (textureEditorMethods != null)
			{
				textureEditorMethods.RestoreReadFlagsAndFormats(progressInfo);
				textureEditorMethods.OnPostTextureBake();
			}
			if (mB3_TextureCombiner.LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("===== Done creating atlases for " + resultMaterial?.ToString() + " Total time to create atlases " + sw.Elapsed);
			}
		}
	}

	private MB3_TextureCombinerPipeline.TexturePipelineData LoadPipelineData(Material resultMaterial, List<ShaderTextureProperty> texPropertyNames, List<GameObject> objsToMesh, List<Material> allowedMaterialsFilter, List<string> texPropsToIgnore, List<MB_TexSet> distinctMaterialTextures)
	{
		MB3_TextureCombinerPipeline.TexturePipelineData texturePipelineData = new MB3_TextureCombinerPipeline.TexturePipelineData();
		texturePipelineData._textureBakeResults = _textureBakeResults;
		texturePipelineData._atlasPadding_pix = _atlasPadding;
		if (_packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical && _useMaxAtlasHeightOverride)
		{
			texturePipelineData._maxAtlasHeight = _maxAtlasHeightOverride;
			texturePipelineData._useMaxAtlasHeightOverride = true;
		}
		else
		{
			texturePipelineData._maxAtlasHeight = _maxAtlasSize;
		}
		if (_packingAlgorithm == MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal && _useMaxAtlasWidthOverride)
		{
			texturePipelineData._maxAtlasWidth = _maxAtlasWidthOverride;
			texturePipelineData._useMaxAtlasWidthOverride = true;
		}
		else
		{
			texturePipelineData._maxAtlasWidth = _maxAtlasSize;
		}
		texturePipelineData._saveAtlasesAsAssets = _saveAtlasesAsAssets;
		texturePipelineData.resultType = _resultType;
		texturePipelineData._resizePowerOfTwoTextures = _resizePowerOfTwoTextures;
		texturePipelineData._fixOutOfBoundsUVs = _fixOutOfBoundsUVs;
		texturePipelineData._maxTilingBakeSize = _maxTilingBakeSize;
		texturePipelineData._packingAlgorithm = _packingAlgorithm;
		texturePipelineData._layerTexturePackerFastV2 = _layerTexturePackerFastMesh;
		texturePipelineData._meshBakerTexturePackerForcePowerOfTwo = _meshBakerTexturePackerForcePowerOfTwo;
		texturePipelineData._customShaderPropNames = _customShaderPropNames;
		texturePipelineData._normalizeTexelDensity = _normalizeTexelDensity;
		texturePipelineData._considerNonTextureProperties = _considerNonTextureProperties;
		texturePipelineData.doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize = _doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize;
		texturePipelineData.nonTexturePropertyBlender = new MB3_TextureCombinerNonTextureProperties(LOG_LEVEL, _considerNonTextureProperties);
		texturePipelineData.resultMaterial = resultMaterial;
		texturePipelineData.distinctMaterialTextures = distinctMaterialTextures;
		texturePipelineData.allObjsToMesh = objsToMesh;
		texturePipelineData.allowedMaterialsFilter = allowedMaterialsFilter;
		texturePipelineData.texPropertyNames = texPropertyNames;
		texturePipelineData.texPropNamesToIgnore = texPropsToIgnore;
		texturePipelineData.colorSpace = MBVersion.GetProjectColorSpace();
		return texturePipelineData;
	}

	private IEnumerator __CombineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, CombineTexturesIntoAtlasesCoroutineResult result, MB_AtlasesAndRects resultAtlasesAndRects, MB3_TextureCombinerPipeline.TexturePipelineData data, MB2_EditorMethodsInterface textureEditorMethods)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("__CombineTexturesIntoAtlases texture properties in shader:" + data.texPropertyNames.Count + " objsToMesh:" + data.allObjsToMesh.Count + " _fixOutOfBoundsUVs:" + data._fixOutOfBoundsUVs);
		}
		progressInfo?.Invoke("Collecting textures ", 0.01f);
		MB3_TextureCombinerPipeline pipeline = new MB3_TextureCombinerPipeline();
		List<GameObject> usedObjsToMesh = new List<GameObject>();
		yield return pipeline.__Step1_CollectDistinctMatTexturesAndUsedObjects(progressInfo, result, data, this, textureEditorMethods, usedObjsToMesh, LOG_LEVEL);
		if (!result.success)
		{
			yield break;
		}
		yield return pipeline.CalculateIdealSizesForTexturesInAtlasAndPadding(progressInfo, result, data, this, textureEditorMethods, LOG_LEVEL);
		if (!result.success)
		{
			yield break;
		}
		StringBuilder report = pipeline.GenerateReport(data);
		MB_ITextureCombinerPacker texturePaker = pipeline.CreatePacker(data.OnlyOneTextureInAtlasReuseTextures(), data._packingAlgorithm);
		if (!texturePaker.Validate(data))
		{
			result.success = false;
			yield break;
		}
		yield return texturePaker.ConvertTexturesToReadableFormats(progressInfo, result, data, this, textureEditorMethods, LOG_LEVEL);
		if (result.success)
		{
			AtlasPackingResult[] array = texturePaker.CalculateAtlasRectangles(data, doMultiAtlas: false, LOG_LEVEL);
			yield return pipeline.__Step3_BuildAndSaveAtlasesAndStoreResults(result, progressInfo, data, this, texturePaker, array[0], textureEditorMethods, resultAtlasesAndRects, report, LOG_LEVEL);
		}
	}

	private IEnumerator __RunTexturePackerOnly(CombineTexturesIntoAtlasesCoroutineResult result, MB_AtlasesAndRects resultAtlasesAndRects, MB3_TextureCombinerPipeline.TexturePipelineData data, bool splitAtlasWhenPackingIfTooBig, MB2_EditorMethodsInterface textureEditorMethods, List<AtlasPackingResult> packingResult)
	{
		MB3_TextureCombinerPipeline pipeline = new MB3_TextureCombinerPipeline();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("__RunTexturePacker texture properties in shader:" + data.texPropertyNames.Count + " objsToMesh:" + data.allObjsToMesh.Count + " _fixOutOfBoundsUVs:" + data._fixOutOfBoundsUVs);
		}
		List<GameObject> usedObjsToMesh = new List<GameObject>();
		yield return pipeline.__Step1_CollectDistinctMatTexturesAndUsedObjects(null, result, data, this, textureEditorMethods, usedObjsToMesh, LOG_LEVEL);
		if (!result.success)
		{
			yield break;
		}
		data.allTexturesAreNullAndSameColor = new MB3_TextureCombinerPipeline.CreateAtlasForProperty[data.texPropertyNames.Count];
		yield return pipeline.CalculateIdealSizesForTexturesInAtlasAndPadding(null, result, data, this, textureEditorMethods, LOG_LEVEL);
		if (result.success)
		{
			MB_ITextureCombinerPacker texturePacker = pipeline.CreatePacker(data.OnlyOneTextureInAtlasReuseTextures(), data._packingAlgorithm);
			AtlasPackingResult[] array = pipeline.RunTexturePackerOnly(data, splitAtlasWhenPackingIfTooBig, resultAtlasesAndRects, texturePacker, LOG_LEVEL);
			for (int i = 0; i < array.Length; i++)
			{
				packingResult.Add(array[i]);
			}
		}
	}

	internal int _getNumTemporaryTextures()
	{
		return _temporaryTextures.Count;
	}

	public Texture2D _createTemporaryTexture(string propertyName, int w, int h, TextureFormat texFormat, bool mipMaps, bool linear)
	{
		Texture2D texture2D = new Texture2D(w, h, texFormat, mipMaps, linear);
		texture2D.name = $"tmp{_temporaryTextures.Count}_{w}x{h}";
		MB_Utility.setSolidColor(texture2D, Color.clear);
		TemporaryTexture item = new TemporaryTexture(propertyName, texture2D);
		_temporaryTextures.Add(item);
		return texture2D;
	}

	internal void AddTemporaryTexture(TemporaryTexture tt)
	{
		_temporaryTextures.Add(tt);
	}

	internal Texture2D _createTextureCopy(ShaderTextureProperty propertyName, Texture2D t)
	{
		Texture2D texture2D = MB_Utility.createTextureCopy(t, propertyName.isGammaCorrected);
		texture2D.name = $"tmpCopy{_temporaryTextures.Count}_{texture2D.width}x{texture2D.height}";
		TemporaryTexture item = new TemporaryTexture(propertyName.name, texture2D);
		_temporaryTextures.Add(item);
		return texture2D;
	}

	internal Texture2D _resizeTexture(ShaderTextureProperty propertyName, Texture2D t, int w, int h)
	{
		Texture2D texture2D = MB_Utility.resampleTexture(t, propertyName.isGammaCorrected, w, h);
		texture2D.name = $"tmpResampled{_temporaryTextures.Count}_{w}x{h}";
		TemporaryTexture item = new TemporaryTexture(propertyName.name, texture2D);
		_temporaryTextures.Add(item);
		return texture2D;
	}

	internal void _destroyAllTemporaryTextures()
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Destroying " + _temporaryTextures.Count + " temporary textures");
		}
		for (int i = 0; i < _temporaryTextures.Count; i++)
		{
			MB_Utility.Destroy(_temporaryTextures[i].texture);
		}
		_temporaryTextures.Clear();
	}

	internal void _destroyTemporaryTextures(string propertyName)
	{
		int num = 0;
		for (int num2 = _temporaryTextures.Count - 1; num2 >= 0; num2--)
		{
			if (_temporaryTextures[num2].property.Equals(propertyName))
			{
				num++;
				MB_Utility.Destroy(_temporaryTextures[num2].texture);
				_temporaryTextures.RemoveAt(num2);
			}
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Destroying " + num + " temporary textures " + propertyName + " num remaining " + _temporaryTextures.Count);
		}
	}

	public void _restoreProceduralMaterials()
	{
	}

	public void SuggestTreatment(List<GameObject> objsToMesh, Material[] resultMaterials, List<ShaderTextureProperty> _customShaderPropNames, List<string> texPropsToIgnore)
	{
		this._customShaderPropNames = _customShaderPropNames;
		StringBuilder stringBuilder = new StringBuilder();
		Dictionary<int, MB_Utility.MeshAnalysisResult[]> dictionary = new Dictionary<int, MB_Utility.MeshAnalysisResult[]>();
		for (int i = 0; i < objsToMesh.Count; i++)
		{
			GameObject gameObject = objsToMesh[i];
			if (gameObject == null)
			{
				continue;
			}
			Material[] gOMaterials = MB_Utility.GetGOMaterials(objsToMesh[i]);
			if (gOMaterials.Length > 1)
			{
				stringBuilder.AppendFormat("\nObject {0} uses {1} materials. Possible treatments:\n", objsToMesh[i].name, gOMaterials.Length);
				stringBuilder.AppendFormat("  1) Collapse the submeshes together into one submesh in the combined mesh. Each of the original submesh materials will map to a different UV rectangle in the atlas(es) used by the combined material.\n");
				stringBuilder.AppendFormat("  2) Use the multiple materials feature to map submeshes in the source mesh to submeshes in the combined mesh.\n");
			}
			Mesh mesh = MB_Utility.GetMesh(gameObject);
			if (!dictionary.TryGetValue(mesh.GetInstanceID(), out var value))
			{
				value = new MB_Utility.MeshAnalysisResult[mesh.subMeshCount];
				MB_Utility.doSubmeshesShareVertsOrTris(mesh, ref value[0]);
				for (int j = 0; j < mesh.subMeshCount; j++)
				{
					MB_Utility.hasOutOfBoundsUVs(mesh, ref value[j], j);
					value[j].hasOverlappingSubmeshVerts = value[0].hasOverlappingSubmeshVerts;
				}
				dictionary.Add(mesh.GetInstanceID(), value);
			}
			for (int k = 0; k < gOMaterials.Length; k++)
			{
				if (value[k].hasOutOfBoundsUVs)
				{
					DRect dRect = new DRect(value[k].uvRect);
					stringBuilder.AppendFormat("\nObject {0} submesh={1} material={2} uses UVs outside the range 0,0 .. 1,1 to create tiling that tiles the box {3},{4} .. {5},{6}. This is a problem because the UVs outside the 0,0 .. 1,1 rectangle will pick up neighboring textures in the atlas. Possible Treatments:\n", gameObject, k, gOMaterials[k], dRect.x.ToString("G4"), dRect.y.ToString("G4"), (dRect.x + dRect.width).ToString("G4"), (dRect.y + dRect.height).ToString("G4"));
					stringBuilder.AppendFormat("    1) Ignore the problem. The tiling may not affect result significantly.\n");
					stringBuilder.AppendFormat("    2) Use the 'Consider Mesh UVs' feature to bake the tiling and scale the UVs to fit in the 0,0 .. 1,1 rectangle.\n");
					stringBuilder.AppendFormat("    3) Use the Multiple Materials feature to map the material on this submesh to its own submesh in the combined mesh. No other materials should map to this submesh. This will result in only one texture in the atlas(es) and the UVs should tile correctly.\n");
					stringBuilder.AppendFormat("    4) Combine only meshes that use the same (or subset of) the set of materials on this mesh. The original material(s) can be applied to the result\n");
				}
			}
			if (value[0].hasOverlappingSubmeshVerts)
			{
				stringBuilder.AppendFormat("\nObject {0} has submeshes that share vertices. This is a problem because each vertex can have only one UV coordinate and may be required to map to different positions in the various atlases that are generated. Possible treatments:\n", objsToMesh[i]);
				stringBuilder.AppendFormat(" 1) Ignore the problem. The vertices may not affect the result.\n");
				stringBuilder.AppendFormat(" 2) Use the Multiple Materials feature to map the submeshs that overlap to their own submeshs in the combined mesh. No other materials should map to this submesh. This will result in only one texture in the atlas(es) and the UVs should tile correctly.\n");
				stringBuilder.AppendFormat(" 3) Combine only meshes that use the same (or subset of) the set of materials on this mesh. The original material(s) can be applied to the result\n");
			}
		}
		Dictionary<Material, List<GameObject>> dictionary2 = new Dictionary<Material, List<GameObject>>();
		for (int l = 0; l < objsToMesh.Count; l++)
		{
			if (!(objsToMesh[l] != null))
			{
				continue;
			}
			Material[] gOMaterials2 = MB_Utility.GetGOMaterials(objsToMesh[l]);
			for (int m = 0; m < gOMaterials2.Length; m++)
			{
				if (gOMaterials2[m] != null)
				{
					if (!dictionary2.TryGetValue(gOMaterials2[m], out var value2))
					{
						value2 = new List<GameObject>();
						dictionary2.Add(gOMaterials2[m], value2);
					}
					if (!value2.Contains(objsToMesh[l]))
					{
						value2.Add(objsToMesh[l]);
					}
				}
			}
		}
		for (int n = 0; n < resultMaterials.Length; n++)
		{
			string shaderName = ((resultMaterials[n] != null) ? "None" : resultMaterials[n].shader.name);
			MB3_TextureCombinerPipeline.TexturePipelineData texturePipelineData = LoadPipelineData(resultMaterials[n], new List<ShaderTextureProperty>(), objsToMesh, new List<Material>(), texPropsToIgnore, new List<MB_TexSet>());
			MB3_TextureCombinerPipeline._CollectPropertyNames(texturePipelineData, LOG_LEVEL);
			foreach (Material key in dictionary2.Keys)
			{
				for (int num = 0; num < texturePipelineData.texPropertyNames.Count; num++)
				{
					if (!key.HasProperty(texturePipelineData.texPropertyNames[num].name))
					{
						continue;
					}
					Texture textureConsideringStandardShaderKeywords = MB3_TextureCombinerPipeline.GetTextureConsideringStandardShaderKeywords(shaderName, key, texturePipelineData.texPropertyNames[num].name);
					if (textureConsideringStandardShaderKeywords != null)
					{
						Vector2 textureOffset = key.GetTextureOffset(texturePipelineData.texPropertyNames[num].name);
						Vector3 vector = key.GetTextureScale(texturePipelineData.texPropertyNames[num].name);
						if (textureOffset.x < 0f || textureOffset.x + vector.x > 1f || textureOffset.y < 0f || textureOffset.y + vector.y > 1f)
						{
							stringBuilder.AppendFormat("\nMaterial {0} used by objects {1} uses texture {2} that is tiled (scale={3} offset={4}). If there is more than one texture in the atlas  then Mesh Baker will bake the tiling into the atlas. If the baked tiling is large then quality can be lost. Possible treatments:\n", key, PrintList(dictionary2[key]), textureConsideringStandardShaderKeywords, vector, textureOffset);
							stringBuilder.AppendFormat("  1) Use the baked tiling.\n");
							stringBuilder.AppendFormat("  2) Use the Multiple Materials feature to map the material on this object/submesh to its own submesh in the combined mesh. No other materials should map to this submesh. The original material can be applied to this submesh.\n");
							stringBuilder.AppendFormat("  3) Combine only meshes that use the same (or subset of) the set of textures on this mesh. The original material can be applied to the result.\n");
						}
					}
				}
			}
		}
		string text = "";
		text = ((stringBuilder.Length != 0) ? ("====== There are possible problems with these meshes that may prevent them from combining well. TREATMENT SUGGESTIONS (copy and paste to text editor if too big) =====\n" + stringBuilder.ToString()) : "====== No problems detected. These meshes should combine well ====\n  If there are problems with the combined meshes please report the problem to digitalOpus.ca so we can improve Mesh Baker.");
		UnityEngine.Debug.Log(text);
	}

	public static bool ShouldTextureBeLinear(ShaderTextureProperty shaderTextureProperty)
	{
		if (shaderTextureProperty.isNormalMap || !shaderTextureProperty.isGammaCorrected)
		{
			return true;
		}
		return false;
	}

	private string PrintList(List<GameObject> gos)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < gos.Count; i++)
		{
			stringBuilder.Append(gos[i]?.ToString() + ",");
		}
		return stringBuilder.ToString();
	}
}
public class MeshBakerMaterialTexture
{
	private Texture2D _t;

	public float texelDensity;

	internal static bool readyToBuildAtlases;

	private DRect encapsulatingSamplingRect;

	public Texture2D t
	{
		set
		{
			_t = value;
		}
	}

	public DRect matTilingRect { get; private set; }

	public int isImportedAsNormalMap { get; private set; }

	public bool isNull => _t == null;

	public int width
	{
		get
		{
			if (_t != null)
			{
				return _t.width;
			}
			return 16;
		}
	}

	public int height
	{
		get
		{
			if (_t != null)
			{
				return _t.height;
			}
			return 16;
		}
	}

	public MeshBakerMaterialTexture(Texture tx, Vector2 matTilingOffset, Vector2 matTilingScale, float texelDens, int isImportedAsNormalMap)
	{
		if (tx is Texture2D)
		{
			_t = (Texture2D)tx;
		}
		else if (!(tx == null))
		{
			UnityEngine.Debug.LogError("An error occured. Texture must be Texture2D " + tx);
		}
		matTilingRect = new DRect(matTilingOffset, matTilingScale);
		texelDensity = texelDens;
		this.isImportedAsNormalMap = isImportedAsNormalMap;
	}

	public DRect GetEncapsulatingSamplingRect()
	{
		return encapsulatingSamplingRect;
	}

	public void SetEncapsulatingSamplingRect(MB_TexSet ts, DRect r)
	{
		encapsulatingSamplingRect = r;
	}

	public Texture2D GetTexture2D()
	{
		if (!readyToBuildAtlases)
		{
			UnityEngine.Debug.LogError("This function should not be called before Step3. For steps 1 and 2 should always call methods like isNull, width, height");
			throw new Exception("GetTexture2D called before ready to build atlases");
		}
		return _t;
	}

	public string GetTexName()
	{
		if (_t != null)
		{
			return _t.name;
		}
		return "null";
	}

	public bool AreTexturesEqual(MeshBakerMaterialTexture b)
	{
		if (_t == b._t)
		{
			return true;
		}
		return false;
	}
}
public class MatAndTransformToMerged
{
	public Material mat;

	public string objName;

	public DRect obUVRectIfTilingSame { get; private set; }

	public DRect samplingRectMatAndUVTiling { get; private set; }

	public DRect materialTiling { get; private set; }

	public MatAndTransformToMerged(DRect obUVrect, bool fixOutOfBoundsUVs)
	{
		_init(obUVrect, fixOutOfBoundsUVs, null);
	}

	public MatAndTransformToMerged(DRect obUVrect, bool fixOutOfBoundsUVs, Material m)
	{
		_init(obUVrect, fixOutOfBoundsUVs, m);
	}

	private void _init(DRect obUVrect, bool fixOutOfBoundsUVs, Material m)
	{
		if (fixOutOfBoundsUVs)
		{
			obUVRectIfTilingSame = obUVrect;
		}
		else
		{
			obUVRectIfTilingSame = new DRect(0f, 0f, 1f, 1f);
		}
		mat = m;
	}

	public override bool Equals(object obj)
	{
		if (obj is MatAndTransformToMerged)
		{
			MatAndTransformToMerged matAndTransformToMerged = (MatAndTransformToMerged)obj;
			if (matAndTransformToMerged.mat == mat && matAndTransformToMerged.obUVRectIfTilingSame == obUVRectIfTilingSame)
			{
				return true;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return mat.GetHashCode() ^ obUVRectIfTilingSame.GetHashCode() ^ samplingRectMatAndUVTiling.GetHashCode();
	}

	public string GetMaterialName()
	{
		if (mat != null)
		{
			return mat.name;
		}
		if (objName != null)
		{
			return $"[matFor: {objName}]";
		}
		return "Unknown";
	}

	public void AssignInitialValuesForMaterialTilingAndSamplingRectMatAndUVTiling(bool allTexturesUseSameMatTiling, DRect matTiling)
	{
		if (allTexturesUseSameMatTiling)
		{
			materialTiling = matTiling;
		}
		else
		{
			materialTiling = new DRect(0f, 0f, 1f, 1f);
		}
		DRect r = materialTiling;
		DRect r2 = obUVRectIfTilingSame;
		samplingRectMatAndUVTiling = MB3_UVTransformUtility.CombineTransforms(ref r2, ref r);
	}
}
public class MatsAndGOs
{
	public List<MatAndTransformToMerged> mats;

	public List<GameObject> gos;
}
public class MB_TexSet
{
	private interface PipelineVariation
	{
		void GetRectsForTextureBakeResults(out Rect allPropsUseSameTiling_encapsulatingSamplingRect, out Rect propsUseDifferntTiling_obUVRect);

		void SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(MB_TextureTilingTreatment newTilingTreatment);

		Rect GetMaterialTilingRectForTextureBakerResults(int materialIndex);

		void AdjustResultMaterialNonTextureProperties(Material resultMaterial, List<ShaderTextureProperty> props);
	}

	private class PipelineVariationAllTexturesUseSameMatTiling : PipelineVariation
	{
		private MB_TexSet texSet;

		public PipelineVariationAllTexturesUseSameMatTiling(MB_TexSet ts)
		{
			texSet = ts;
		}

		public void GetRectsForTextureBakeResults(out Rect allPropsUseSameTiling_encapsulatingSamplingRect, out Rect propsUseDifferntTiling_obUVRect)
		{
			propsUseDifferntTiling_obUVRect = new Rect(0f, 0f, 0f, 0f);
			allPropsUseSameTiling_encapsulatingSamplingRect = texSet.GetEncapsulatingSamplingRectIfTilingSame();
			if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeX)
			{
				allPropsUseSameTiling_encapsulatingSamplingRect.x = 0f;
				allPropsUseSameTiling_encapsulatingSamplingRect.width = 1f;
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeY)
			{
				allPropsUseSameTiling_encapsulatingSamplingRect.y = 0f;
				allPropsUseSameTiling_encapsulatingSamplingRect.height = 1f;
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeXY)
			{
				allPropsUseSameTiling_encapsulatingSamplingRect = new Rect(0f, 0f, 1f, 1f);
			}
		}

		public void SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(MB_TextureTilingTreatment newTilingTreatment)
		{
			if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeX)
			{
				MeshBakerMaterialTexture[] ts = texSet.ts;
				foreach (MeshBakerMaterialTexture obj in ts)
				{
					DRect encapsulatingSamplingRect = obj.GetEncapsulatingSamplingRect();
					encapsulatingSamplingRect.width = 1.0;
					obj.SetEncapsulatingSamplingRect(texSet, encapsulatingSamplingRect);
				}
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeY)
			{
				MeshBakerMaterialTexture[] ts = texSet.ts;
				foreach (MeshBakerMaterialTexture obj2 in ts)
				{
					DRect encapsulatingSamplingRect2 = obj2.GetEncapsulatingSamplingRect();
					encapsulatingSamplingRect2.height = 1.0;
					obj2.SetEncapsulatingSamplingRect(texSet, encapsulatingSamplingRect2);
				}
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeXY)
			{
				MeshBakerMaterialTexture[] ts = texSet.ts;
				foreach (MeshBakerMaterialTexture obj3 in ts)
				{
					DRect encapsulatingSamplingRect3 = obj3.GetEncapsulatingSamplingRect();
					encapsulatingSamplingRect3.height = 1.0;
					encapsulatingSamplingRect3.width = 1.0;
					obj3.SetEncapsulatingSamplingRect(texSet, encapsulatingSamplingRect3);
				}
			}
		}

		public Rect GetMaterialTilingRectForTextureBakerResults(int materialIndex)
		{
			return texSet.matsAndGOs.mats[materialIndex].materialTiling.GetRect();
		}

		public void AdjustResultMaterialNonTextureProperties(Material resultMaterial, List<ShaderTextureProperty> props)
		{
		}
	}

	private class PipelineVariationSomeTexturesUseDifferentMatTiling : PipelineVariation
	{
		private MB_TexSet texSet;

		public PipelineVariationSomeTexturesUseDifferentMatTiling(MB_TexSet ts)
		{
			texSet = ts;
		}

		public void GetRectsForTextureBakeResults(out Rect allPropsUseSameTiling_encapsulatingSamplingRect, out Rect propsUseDifferntTiling_obUVRect)
		{
			allPropsUseSameTiling_encapsulatingSamplingRect = new Rect(0f, 0f, 0f, 0f);
			propsUseDifferntTiling_obUVRect = texSet.obUVrect.GetRect();
			if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeX)
			{
				propsUseDifferntTiling_obUVRect.x = 0f;
				propsUseDifferntTiling_obUVRect.width = 1f;
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeY)
			{
				propsUseDifferntTiling_obUVRect.y = 0f;
				propsUseDifferntTiling_obUVRect.height = 1f;
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeXY)
			{
				propsUseDifferntTiling_obUVRect = new Rect(0f, 0f, 1f, 1f);
			}
		}

		public void SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(MB_TextureTilingTreatment newTilingTreatment)
		{
			if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeX)
			{
				MeshBakerMaterialTexture[] ts = texSet.ts;
				foreach (MeshBakerMaterialTexture obj in ts)
				{
					DRect encapsulatingSamplingRect = obj.GetEncapsulatingSamplingRect();
					encapsulatingSamplingRect.width = 1.0;
					obj.SetEncapsulatingSamplingRect(texSet, encapsulatingSamplingRect);
				}
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeY)
			{
				MeshBakerMaterialTexture[] ts = texSet.ts;
				foreach (MeshBakerMaterialTexture obj2 in ts)
				{
					DRect encapsulatingSamplingRect2 = obj2.GetEncapsulatingSamplingRect();
					encapsulatingSamplingRect2.height = 1.0;
					obj2.SetEncapsulatingSamplingRect(texSet, encapsulatingSamplingRect2);
				}
			}
			else if (texSet.tilingTreatment == MB_TextureTilingTreatment.edgeToEdgeXY)
			{
				MeshBakerMaterialTexture[] ts = texSet.ts;
				foreach (MeshBakerMaterialTexture obj3 in ts)
				{
					DRect encapsulatingSamplingRect3 = obj3.GetEncapsulatingSamplingRect();
					encapsulatingSamplingRect3.height = 1.0;
					encapsulatingSamplingRect3.width = 1.0;
					obj3.SetEncapsulatingSamplingRect(texSet, encapsulatingSamplingRect3);
				}
			}
		}

		public Rect GetMaterialTilingRectForTextureBakerResults(int materialIndex)
		{
			return new Rect(0f, 0f, 0f, 0f);
		}

		public void AdjustResultMaterialNonTextureProperties(Material resultMaterial, List<ShaderTextureProperty> props)
		{
			if (!texSet.thisIsOnlyTexSetInAtlas)
			{
				return;
			}
			for (int i = 0; i < props.Count; i++)
			{
				if (resultMaterial.HasProperty(props[i].name))
				{
					resultMaterial.SetTextureOffset(props[i].name, texSet.ts[i].matTilingRect.min);
					resultMaterial.SetTextureScale(props[i].name, texSet.ts[i].matTilingRect.size);
				}
			}
		}
	}

	public MeshBakerMaterialTexture[] ts;

	public MatsAndGOs matsAndGOs;

	public int idealWidth_pix;

	public int idealHeight_pix;

	private PipelineVariation pipelineVariation;

	public bool allTexturesUseSameMatTiling { get; private set; }

	public bool thisIsOnlyTexSetInAtlas { get; private set; }

	public MB_TextureTilingTreatment tilingTreatment { get; private set; }

	public Vector2 obUVoffset { get; private set; }

	public Vector2 obUVscale { get; private set; }

	internal DRect obUVrect => new DRect(obUVoffset, obUVscale);

	public MB_TexSet(MeshBakerMaterialTexture[] tss, Vector2 uvOffset, Vector2 uvScale, MB_TextureTilingTreatment treatment)
	{
		ts = tss;
		tilingTreatment = treatment;
		obUVoffset = uvOffset;
		obUVscale = uvScale;
		allTexturesUseSameMatTiling = false;
		thisIsOnlyTexSetInAtlas = false;
		matsAndGOs = new MatsAndGOs();
		matsAndGOs.mats = new List<MatAndTransformToMerged>();
		matsAndGOs.gos = new List<GameObject>();
		pipelineVariation = new PipelineVariationSomeTexturesUseDifferentMatTiling(this);
	}

	internal bool IsEqual(object obj, bool fixOutOfBoundsUVs, MB3_TextureCombinerNonTextureProperties resultMaterialTextureBlender)
	{
		if (!(obj is MB_TexSet))
		{
			return false;
		}
		MB_TexSet mB_TexSet = (MB_TexSet)obj;
		if (mB_TexSet.ts.Length != ts.Length)
		{
			return false;
		}
		for (int i = 0; i < ts.Length; i++)
		{
			if (ts[i].matTilingRect != mB_TexSet.ts[i].matTilingRect)
			{
				return false;
			}
			if (!ts[i].AreTexturesEqual(mB_TexSet.ts[i]))
			{
				return false;
			}
			if (!resultMaterialTextureBlender.NonTexturePropertiesAreEqual(matsAndGOs.mats[0].mat, mB_TexSet.matsAndGOs.mats[0].mat))
			{
				return false;
			}
		}
		if (fixOutOfBoundsUVs && (obUVoffset.x != mB_TexSet.obUVoffset.x || obUVoffset.y != mB_TexSet.obUVoffset.y))
		{
			return false;
		}
		if (fixOutOfBoundsUVs && (obUVscale.x != mB_TexSet.obUVscale.x || obUVscale.y != mB_TexSet.obUVscale.y))
		{
			return false;
		}
		return true;
	}

	public Vector2 GetMaxRawTextureHeightWidth()
	{
		Vector2 result = new Vector2(0f, 0f);
		for (int i = 0; i < ts.Length; i++)
		{
			MeshBakerMaterialTexture meshBakerMaterialTexture = ts[i];
			if (!meshBakerMaterialTexture.isNull)
			{
				result.x = Mathf.Max(result.x, meshBakerMaterialTexture.width);
				result.y = Mathf.Max(result.y, meshBakerMaterialTexture.height);
			}
		}
		return result;
	}

	private Rect GetEncapsulatingSamplingRectIfTilingSame()
	{
		if (ts.Length != 0)
		{
			return ts[0].GetEncapsulatingSamplingRect().GetRect();
		}
		return new Rect(0f, 0f, 1f, 1f);
	}

	public void SetEncapsulatingSamplingRectWhenMergingTexSets(DRect newEncapsulatingSamplingRect)
	{
		for (int i = 0; i < ts.Length; i++)
		{
			ts[i].SetEncapsulatingSamplingRect(this, newEncapsulatingSamplingRect);
		}
	}

	public void SetEncapsulatingSamplingRectForTesting(int propIdx, DRect newEncapsulatingSamplingRect)
	{
		ts[propIdx].SetEncapsulatingSamplingRect(this, newEncapsulatingSamplingRect);
	}

	public void SetEncapsulatingRect(int propIdx, bool considerMeshUVs)
	{
		if (considerMeshUVs)
		{
			ts[propIdx].SetEncapsulatingSamplingRect(this, obUVrect);
		}
		else
		{
			ts[propIdx].SetEncapsulatingSamplingRect(this, new DRect(0f, 0f, 1f, 1f));
		}
	}

	public void CreateColoredTexToReplaceNull(string propName, int propIdx, bool considerMeshUVs, MB3_TextureCombiner combiner, Color col, bool isLinear)
	{
		MeshBakerMaterialTexture obj = ts[propIdx];
		Texture2D t = combiner._createTemporaryTexture(propName, 16, 16, TextureFormat.ARGB32, mipMaps: true, isLinear);
		obj.t = t;
		MB_Utility.setSolidColor(obj.GetTexture2D(), col);
	}

	public void SetThisIsOnlyTexSetInAtlasTrue()
	{
		thisIsOnlyTexSetInAtlas = true;
	}

	public void SetAllTexturesUseSameMatTilingTrue()
	{
		allTexturesUseSameMatTiling = true;
		pipelineVariation = new PipelineVariationAllTexturesUseSameMatTiling(this);
	}

	public void AdjustResultMaterialNonTextureProperties(Material resultMaterial, List<ShaderTextureProperty> props)
	{
		pipelineVariation.AdjustResultMaterialNonTextureProperties(resultMaterial, props);
	}

	public void SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(MB_TextureTilingTreatment newTilingTreatment)
	{
		tilingTreatment = newTilingTreatment;
		pipelineVariation.SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(newTilingTreatment);
	}

	internal void GetRectsForTextureBakeResults(out Rect allPropsUseSameTiling_encapsulatingSamplingRect, out Rect propsUseDifferntTiling_obUVRect)
	{
		pipelineVariation.GetRectsForTextureBakeResults(out allPropsUseSameTiling_encapsulatingSamplingRect, out propsUseDifferntTiling_obUVRect);
	}

	internal Rect GetMaterialTilingRectForTextureBakerResults(int materialIndex)
	{
		return pipelineVariation.GetMaterialTilingRectForTextureBakerResults(materialIndex);
	}

	internal void CalcInitialFullSamplingRects(bool fixOutOfBoundsUVs)
	{
		DRect r = new DRect(0f, 0f, 1f, 1f);
		if (fixOutOfBoundsUVs)
		{
			r = obUVrect;
		}
		for (int i = 0; i < ts.Length; i++)
		{
			if (!ts[i].isNull)
			{
				DRect r2 = ts[i].matTilingRect;
				DRect r3 = ((!fixOutOfBoundsUVs) ? new DRect(0.0, 0.0, 1.0, 1.0) : obUVrect);
				ts[i].SetEncapsulatingSamplingRect(this, MB3_UVTransformUtility.CombineTransforms(ref r3, ref r2));
				r = ts[i].GetEncapsulatingSamplingRect();
			}
		}
		for (int j = 0; j < ts.Length; j++)
		{
			if (ts[j].isNull)
			{
				ts[j].SetEncapsulatingSamplingRect(this, r);
			}
		}
	}

	internal void CalcMatAndUVSamplingRects()
	{
		DRect matTiling = new DRect(0f, 0f, 1f, 1f);
		if (allTexturesUseSameMatTiling)
		{
			for (int i = 0; i < ts.Length; i++)
			{
				if (!ts[i].isNull)
				{
					matTiling = ts[i].matTilingRect;
					break;
				}
			}
		}
		for (int j = 0; j < matsAndGOs.mats.Count; j++)
		{
			matsAndGOs.mats[j].AssignInitialValuesForMaterialTilingAndSamplingRectMatAndUVTiling(allTexturesUseSameMatTiling, matTiling);
		}
	}

	public bool AllTexturesAreSameForMerge(MB_TexSet other, bool considerNonTextureProperties, MB3_TextureCombinerNonTextureProperties resultMaterialTextureBlender)
	{
		if (other.ts.Length != ts.Length)
		{
			return false;
		}
		if (!other.allTexturesUseSameMatTiling || !allTexturesUseSameMatTiling)
		{
			return false;
		}
		int num = -1;
		for (int i = 0; i < ts.Length; i++)
		{
			if (!ts[i].AreTexturesEqual(other.ts[i]))
			{
				return false;
			}
			if (num == -1 && !ts[i].isNull)
			{
				num = i;
			}
			if (considerNonTextureProperties && !resultMaterialTextureBlender.NonTexturePropertiesAreEqual(matsAndGOs.mats[0].mat, other.matsAndGOs.mats[0].mat))
			{
				return false;
			}
		}
		if (num != -1)
		{
			for (int j = 0; j < ts.Length; j++)
			{
				if (!ts[j].AreTexturesEqual(other.ts[j]))
				{
					return false;
				}
			}
		}
		return true;
	}

	public void DrawRectsToMergeGizmos(Color encC, Color innerC)
	{
		DRect A = ts[0].GetEncapsulatingSamplingRect();
		A.Expand(0.05f);
		Gizmos.color = encC;
		Gizmos.DrawWireCube(A.center.GetVector2(), A.size);
		for (int i = 0; i < matsAndGOs.mats.Count; i++)
		{
			DRect B = matsAndGOs.mats[i].samplingRectMatAndUVTiling;
			DRect r = MB3_UVTransformUtility.GetShiftTransformToFitBinA(ref A, ref B);
			Vector2 vector = MB3_UVTransformUtility.TransformPoint(ref r, B.min);
			B.x = vector.x;
			B.y = vector.y;
			Gizmos.color = innerC;
			Gizmos.DrawWireCube(B.center.GetVector2(), B.size);
		}
	}

	internal string GetDescription()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("[GAME_OBJS=");
		for (int i = 0; i < matsAndGOs.gos.Count; i++)
		{
			stringBuilder.AppendFormat("{0},", matsAndGOs.gos[i].name);
		}
		stringBuilder.AppendFormat("MATS=");
		for (int j = 0; j < matsAndGOs.mats.Count; j++)
		{
			stringBuilder.AppendFormat("{0},", matsAndGOs.mats[j].GetMaterialName());
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	internal string GetMatSubrectDescriptions()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < matsAndGOs.mats.Count; i++)
		{
			stringBuilder.AppendFormat("\n    {0}={1},", matsAndGOs.mats[i].GetMaterialName(), matsAndGOs.mats[i].samplingRectMatAndUVTiling);
		}
		return stringBuilder.ToString();
	}
}
public class MB3_TextureCombinerMerging
{
	public static bool DO_INTEGRITY_CHECKS;

	private bool _HasBeenInitialized;

	private bool _considerNonTextureProperties;

	private MB3_TextureCombinerNonTextureProperties resultMaterialTextureBlender;

	private bool fixOutOfBoundsUVs = true;

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	private static bool LOG_LEVEL_TRACE_MERGE_MAT_SUBRECTS;

	public static Rect BuildTransformMeshUV2AtlasRect(bool considerMeshUVs, Rect _atlasRect, Rect _obUVRect, Rect _sourceMaterialTiling, Rect _encapsulatingRect)
	{
		DRect r = new DRect(_atlasRect);
		DRect t = ((!considerMeshUVs) ? new DRect(0.0, 0.0, 1.0, 1.0) : new DRect(_obUVRect));
		DRect r2 = new DRect(_sourceMaterialTiling);
		DRect t2 = new DRect(_encapsulatingRect);
		DRect r3 = MB3_UVTransformUtility.InverseTransform(ref t2);
		DRect r4 = MB3_UVTransformUtility.InverseTransform(ref t);
		DRect B = MB3_UVTransformUtility.CombineTransforms(ref t, ref r2);
		DRect r5 = MB3_UVTransformUtility.GetShiftTransformToFitBinA(ref t2, ref B);
		B = MB3_UVTransformUtility.CombineTransforms(ref B, ref r5);
		DRect r6 = MB3_UVTransformUtility.CombineTransforms(ref B, ref r3);
		DRect r7 = MB3_UVTransformUtility.CombineTransforms(ref r4, ref r6);
		return MB3_UVTransformUtility.CombineTransforms(ref r7, ref r).GetRect();
	}

	public MB3_TextureCombinerMerging(bool considerNonTextureProps, MB3_TextureCombinerNonTextureProperties resultMaterialTexBlender, bool fixObUVs, MB2_LogLevel logLevel)
	{
		LOG_LEVEL = logLevel;
		_considerNonTextureProperties = considerNonTextureProps;
		resultMaterialTextureBlender = resultMaterialTexBlender;
		fixOutOfBoundsUVs = fixObUVs;
	}

	public void MergeOverlappingDistinctMaterialTexturesAndCalcMaterialSubrects(List<MB_TexSet> distinctMaterialTextures)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("MergeOverlappingDistinctMaterialTexturesAndCalcMaterialSubrects num atlas rects" + distinctMaterialTextures.Count);
		}
		int num = 0;
		for (int i = 0; i < distinctMaterialTextures.Count; i++)
		{
			MB_TexSet mB_TexSet = distinctMaterialTextures[i];
			int num2 = -1;
			bool flag = true;
			DRect dRect = default(DRect);
			for (int j = 0; j < mB_TexSet.ts.Length; j++)
			{
				if (num2 != -1)
				{
					if (!mB_TexSet.ts[j].isNull && dRect != mB_TexSet.ts[j].matTilingRect)
					{
						flag = false;
					}
				}
				else if (!mB_TexSet.ts[j].isNull)
				{
					num2 = j;
					dRect = mB_TexSet.ts[j].matTilingRect;
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug || LOG_LEVEL_TRACE_MERGE_MAT_SUBRECTS)
			{
				if (flag)
				{
					UnityEngine.Debug.LogFormat("TextureSet {0} allTexturesUseSameMatTiling = {1}", i, flag);
				}
				else
				{
					UnityEngine.Debug.Log($"Textures in material(s) do not all use the same material tiling. This set of textures will not be considered for merge: {mB_TexSet.GetDescription()} ");
				}
			}
			if (flag)
			{
				mB_TexSet.SetAllTexturesUseSameMatTilingTrue();
			}
		}
		for (int k = 0; k < distinctMaterialTextures.Count; k++)
		{
			MB_TexSet mB_TexSet2 = distinctMaterialTextures[k];
			for (int l = 0; l < mB_TexSet2.matsAndGOs.mats.Count; l++)
			{
				if (mB_TexSet2.matsAndGOs.gos.Count > 0)
				{
					mB_TexSet2.matsAndGOs.mats[l].objName = mB_TexSet2.matsAndGOs.gos[0].name;
				}
				else if (mB_TexSet2.ts[0] != null)
				{
					mB_TexSet2.matsAndGOs.mats[l].objName = $"[objWithTx:{mB_TexSet2.ts[0].GetTexName()} atlasBlock:{k} matIdx{l}]";
				}
				else
				{
					mB_TexSet2.matsAndGOs.mats[l].objName = string.Format("[objWithTx:{0} atlasBlock:{1} matIdx{2}]", "Unknown", k, l);
				}
			}
			mB_TexSet2.CalcInitialFullSamplingRects(fixOutOfBoundsUVs);
			mB_TexSet2.CalcMatAndUVSamplingRects();
		}
		_HasBeenInitialized = true;
		List<int> list = new List<int>();
		for (int m = 0; m < distinctMaterialTextures.Count; m++)
		{
			MB_TexSet mB_TexSet3 = distinctMaterialTextures[m];
			for (int n = m + 1; n < distinctMaterialTextures.Count; n++)
			{
				MB_TexSet mB_TexSet4 = distinctMaterialTextures[n];
				if (!mB_TexSet4.AllTexturesAreSameForMerge(mB_TexSet3, _considerNonTextureProperties, resultMaterialTextureBlender))
				{
					continue;
				}
				double num3 = 0.0;
				double num4 = 0.0;
				DRect dRect2 = default(DRect);
				int num5 = -1;
				for (int num6 = 0; num6 < mB_TexSet3.ts.Length; num6++)
				{
					if (!mB_TexSet3.ts[num6].isNull && num5 == -1)
					{
						num5 = num6;
					}
				}
				DRect uvRect = default(DRect);
				DRect uvRect2 = default(DRect);
				if (num5 != -1)
				{
					uvRect = mB_TexSet4.matsAndGOs.mats[0].samplingRectMatAndUVTiling;
					for (int num7 = 1; num7 < mB_TexSet4.matsAndGOs.mats.Count; num7++)
					{
						DRect willBeIn = mB_TexSet4.matsAndGOs.mats[num7].samplingRectMatAndUVTiling;
						uvRect = MB3_UVTransformUtility.GetEncapsulatingRectShifted(ref uvRect, ref willBeIn);
					}
					uvRect2 = mB_TexSet3.matsAndGOs.mats[0].samplingRectMatAndUVTiling;
					for (int num8 = 1; num8 < mB_TexSet3.matsAndGOs.mats.Count; num8++)
					{
						DRect willBeIn2 = mB_TexSet3.matsAndGOs.mats[num8].samplingRectMatAndUVTiling;
						uvRect2 = MB3_UVTransformUtility.GetEncapsulatingRectShifted(ref uvRect2, ref willBeIn2);
					}
					dRect2 = MB3_UVTransformUtility.GetEncapsulatingRectShifted(ref uvRect, ref uvRect2);
					num3 += dRect2.width * dRect2.height;
					num4 += uvRect.width * uvRect.height + uvRect2.width * uvRect2.height;
				}
				else
				{
					dRect2 = new DRect(0f, 0f, 1f, 1f);
				}
				if (num3 < num4)
				{
					num++;
					StringBuilder stringBuilder = null;
					if (LOG_LEVEL >= MB2_LogLevel.info)
					{
						stringBuilder = new StringBuilder();
						stringBuilder.AppendFormat("About To Merge:\n   TextureSet1 {0}\n   TextureSet2 {1}\n", mB_TexSet4.GetDescription(), mB_TexSet3.GetDescription());
						if (LOG_LEVEL >= MB2_LogLevel.trace)
						{
							for (int num9 = 0; num9 < mB_TexSet4.matsAndGOs.mats.Count; num9++)
							{
								stringBuilder.AppendFormat("tx1 Mat {0} matAndMeshUVRect {1} fullSamplingRect {2}\n", mB_TexSet4.matsAndGOs.mats[num9].mat, mB_TexSet4.matsAndGOs.mats[num9].samplingRectMatAndUVTiling, mB_TexSet4.ts[0].GetEncapsulatingSamplingRect());
							}
							for (int num10 = 0; num10 < mB_TexSet3.matsAndGOs.mats.Count; num10++)
							{
								stringBuilder.AppendFormat("tx2 Mat {0} matAndMeshUVRect {1} fullSamplingRect {2}\n", mB_TexSet3.matsAndGOs.mats[num10].mat, mB_TexSet3.matsAndGOs.mats[num10].samplingRectMatAndUVTiling, mB_TexSet3.ts[0].GetEncapsulatingSamplingRect());
							}
						}
					}
					for (int num11 = 0; num11 < mB_TexSet3.matsAndGOs.gos.Count; num11++)
					{
						if (!mB_TexSet4.matsAndGOs.gos.Contains(mB_TexSet3.matsAndGOs.gos[num11]))
						{
							mB_TexSet4.matsAndGOs.gos.Add(mB_TexSet3.matsAndGOs.gos[num11]);
						}
					}
					for (int num12 = 0; num12 < mB_TexSet3.matsAndGOs.mats.Count; num12++)
					{
						mB_TexSet4.matsAndGOs.mats.Add(mB_TexSet3.matsAndGOs.mats[num12]);
					}
					mB_TexSet4.SetEncapsulatingSamplingRectWhenMergingTexSets(dRect2);
					if (!list.Contains(m))
					{
						list.Add(m);
					}
					if (LOG_LEVEL < MB2_LogLevel.debug)
					{
						break;
					}
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						stringBuilder.AppendFormat("=== After Merge TextureSet {0}\n", mB_TexSet4.GetDescription());
						for (int num13 = 0; num13 < mB_TexSet4.matsAndGOs.mats.Count; num13++)
						{
							stringBuilder.AppendFormat("tx1 Mat {0} matAndMeshUVRect {1} fullSamplingRect {2}\n", mB_TexSet4.matsAndGOs.mats[num13].mat, mB_TexSet4.matsAndGOs.mats[num13].samplingRectMatAndUVTiling, mB_TexSet4.ts[0].GetEncapsulatingSamplingRect());
						}
						if (DO_INTEGRITY_CHECKS && DO_INTEGRITY_CHECKS)
						{
							DoIntegrityCheckMergedEncapsulatingSamplingRects(distinctMaterialTextures);
						}
					}
					UnityEngine.Debug.Log(stringBuilder.ToString());
					break;
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					string description = mB_TexSet4.GetDescription();
					DRect dRect3 = uvRect;
					string arg = description + dRect3.ToString();
					string description2 = mB_TexSet3.GetDescription();
					dRect3 = uvRect2;
					UnityEngine.Debug.Log($"Considered merging {arg} and {description2 + dRect3.ToString()} but there was not enough overlap. It is more efficient to bake these to separate rectangles.");
				}
			}
		}
		for (int num14 = list.Count - 1; num14 >= 0; num14--)
		{
			distinctMaterialTextures.RemoveAt(list[num14]);
		}
		list.Clear();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"MergeOverlappingDistinctMaterialTexturesAndCalcMaterialSubrects complete merged {num} now have {distinctMaterialTextures.Count}");
		}
		if (DO_INTEGRITY_CHECKS)
		{
			DoIntegrityCheckMergedEncapsulatingSamplingRects(distinctMaterialTextures);
		}
	}

	public void MergeDistinctMaterialTexturesThatWouldExceedMaxAtlasSizeAndCalcMaterialSubrects(List<MB_TexSet> distinctMaterialTextures, int maxAtlasSize)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("MergeDistinctMaterialTexturesThatWouldExceedMaxAtlasSizeAndCalcMaterialSubrects num atlas rects" + distinctMaterialTextures.Count);
		}
		int num = 0;
		List<int> list = new List<int>();
		for (int i = 0; i < distinctMaterialTextures.Count; i++)
		{
			MB_TexSet mB_TexSet = distinctMaterialTextures[i];
			for (int j = i + 1; j < distinctMaterialTextures.Count; j++)
			{
				MB_TexSet mB_TexSet2 = distinctMaterialTextures[j];
				if (!mB_TexSet2.AllTexturesAreSameForMerge(mB_TexSet, _considerNonTextureProperties, resultMaterialTextureBlender))
				{
					continue;
				}
				DRect dRect = default(DRect);
				int num2 = -1;
				for (int k = 0; k < mB_TexSet.ts.Length; k++)
				{
					if (!mB_TexSet.ts[k].isNull && num2 == -1)
					{
						num2 = k;
					}
				}
				DRect uvRect = default(DRect);
				DRect uvRect2 = default(DRect);
				if (num2 != -1)
				{
					uvRect = mB_TexSet2.matsAndGOs.mats[0].samplingRectMatAndUVTiling;
					for (int l = 1; l < mB_TexSet2.matsAndGOs.mats.Count; l++)
					{
						DRect willBeIn = mB_TexSet2.matsAndGOs.mats[l].samplingRectMatAndUVTiling;
						uvRect = MB3_UVTransformUtility.GetEncapsulatingRectShifted(ref uvRect, ref willBeIn);
					}
					uvRect2 = mB_TexSet.matsAndGOs.mats[0].samplingRectMatAndUVTiling;
					for (int m = 1; m < mB_TexSet.matsAndGOs.mats.Count; m++)
					{
						DRect willBeIn2 = mB_TexSet.matsAndGOs.mats[m].samplingRectMatAndUVTiling;
						uvRect2 = MB3_UVTransformUtility.GetEncapsulatingRectShifted(ref uvRect2, ref willBeIn2);
					}
					dRect = MB3_UVTransformUtility.GetEncapsulatingRectShifted(ref uvRect, ref uvRect2);
				}
				else
				{
					dRect = new DRect(0f, 0f, 1f, 1f);
				}
				Vector2 maxRawTextureHeightWidth = mB_TexSet2.GetMaxRawTextureHeightWidth();
				if (dRect.width * (double)maxRawTextureHeightWidth.x > (double)maxAtlasSize || dRect.height * (double)maxRawTextureHeightWidth.y > (double)maxAtlasSize)
				{
					num++;
					StringBuilder stringBuilder = null;
					if (LOG_LEVEL >= MB2_LogLevel.info)
					{
						stringBuilder = new StringBuilder();
						stringBuilder.AppendFormat("About To Merge:\n   TextureSet1 {0}\n   TextureSet2 {1}\n", mB_TexSet2.GetDescription(), mB_TexSet.GetDescription());
						if (LOG_LEVEL >= MB2_LogLevel.trace)
						{
							for (int n = 0; n < mB_TexSet2.matsAndGOs.mats.Count; n++)
							{
								stringBuilder.AppendFormat("tx1 Mat {0} matAndMeshUVRect {1} fullSamplingRect {2}\n", mB_TexSet2.matsAndGOs.mats[n].mat, mB_TexSet2.matsAndGOs.mats[n].samplingRectMatAndUVTiling, mB_TexSet2.ts[0].GetEncapsulatingSamplingRect());
							}
							for (int num3 = 0; num3 < mB_TexSet.matsAndGOs.mats.Count; num3++)
							{
								stringBuilder.AppendFormat("tx2 Mat {0} matAndMeshUVRect {1} fullSamplingRect {2}\n", mB_TexSet.matsAndGOs.mats[num3].mat, mB_TexSet.matsAndGOs.mats[num3].samplingRectMatAndUVTiling, mB_TexSet.ts[0].GetEncapsulatingSamplingRect());
							}
						}
					}
					for (int num4 = 0; num4 < mB_TexSet.matsAndGOs.gos.Count; num4++)
					{
						if (!mB_TexSet2.matsAndGOs.gos.Contains(mB_TexSet.matsAndGOs.gos[num4]))
						{
							mB_TexSet2.matsAndGOs.gos.Add(mB_TexSet.matsAndGOs.gos[num4]);
						}
					}
					for (int num5 = 0; num5 < mB_TexSet.matsAndGOs.mats.Count; num5++)
					{
						mB_TexSet2.matsAndGOs.mats.Add(mB_TexSet.matsAndGOs.mats[num5]);
					}
					mB_TexSet2.SetEncapsulatingSamplingRectWhenMergingTexSets(dRect);
					if (!list.Contains(i))
					{
						list.Add(i);
					}
					if (LOG_LEVEL < MB2_LogLevel.debug)
					{
						break;
					}
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						stringBuilder.AppendFormat("=== After Merge TextureSet {0}\n", mB_TexSet2.GetDescription());
						for (int num6 = 0; num6 < mB_TexSet2.matsAndGOs.mats.Count; num6++)
						{
							stringBuilder.AppendFormat("tx1 Mat {0} matAndMeshUVRect {1} fullSamplingRect {2}\n", mB_TexSet2.matsAndGOs.mats[num6].mat, mB_TexSet2.matsAndGOs.mats[num6].samplingRectMatAndUVTiling, mB_TexSet2.ts[0].GetEncapsulatingSamplingRect());
						}
						if (DO_INTEGRITY_CHECKS && DO_INTEGRITY_CHECKS)
						{
							DoIntegrityCheckMergedEncapsulatingSamplingRects(distinctMaterialTextures);
						}
					}
					UnityEngine.Debug.Log(stringBuilder.ToString());
					break;
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					string description = mB_TexSet2.GetDescription();
					DRect dRect2 = uvRect;
					string arg = description + dRect2.ToString();
					string description2 = mB_TexSet.GetDescription();
					dRect2 = uvRect2;
					UnityEngine.Debug.Log($"Considered merging {arg} and {description2 + dRect2.ToString()} but there was not enough overlap. It is more efficient to bake these to separate rectangles.");
				}
			}
		}
		for (int num7 = list.Count - 1; num7 >= 0; num7--)
		{
			distinctMaterialTextures.RemoveAt(list[num7]);
		}
		list.Clear();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"MergeDistinctMaterialTexturesThatWouldExceedMaxAtlasSizeAndCalcMaterialSubrects complete merged {num} now have {distinctMaterialTextures.Count}");
		}
		if (DO_INTEGRITY_CHECKS)
		{
			DoIntegrityCheckMergedEncapsulatingSamplingRects(distinctMaterialTextures);
		}
	}

	public void DoIntegrityCheckMergedEncapsulatingSamplingRects(List<MB_TexSet> distinctMaterialTextures)
	{
		if (!DO_INTEGRITY_CHECKS)
		{
			return;
		}
		for (int i = 0; i < distinctMaterialTextures.Count; i++)
		{
			MB_TexSet mB_TexSet = distinctMaterialTextures[i];
			if (!mB_TexSet.allTexturesUseSameMatTiling)
			{
				continue;
			}
			for (int j = 0; j < mB_TexSet.matsAndGOs.mats.Count; j++)
			{
				MatAndTransformToMerged matAndTransformToMerged = mB_TexSet.matsAndGOs.mats[j];
				DRect obUVRectIfTilingSame = matAndTransformToMerged.obUVRectIfTilingSame;
				DRect materialTiling = matAndTransformToMerged.materialTiling;
				if (!MB2_TextureBakeResults.IsMeshAndMaterialRectEnclosedByAtlasRect(mB_TexSet.tilingTreatment, obUVRectIfTilingSame.GetRect(), materialTiling.GetRect(), mB_TexSet.ts[0].GetEncapsulatingSamplingRect().GetRect(), MB2_LogLevel.info))
				{
					string[] obj = new string[11]
					{
						"mesh ",
						mB_TexSet.matsAndGOs.mats[j].objName,
						"\n uv=",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					DRect dRect = obUVRectIfTilingSame;
					obj[3] = dRect.ToString();
					obj[4] = "\n mat=";
					obj[5] = materialTiling.GetRect().ToString("f5");
					obj[6] = "\n samplingRect=";
					obj[7] = mB_TexSet.matsAndGOs.mats[j].samplingRectMatAndUVTiling.GetRect().ToString("f4");
					obj[8] = "\n encapsulatingRect ";
					obj[9] = mB_TexSet.ts[0].GetEncapsulatingSamplingRect().GetRect().ToString("f4");
					obj[10] = "\n";
					UnityEngine.Debug.LogErrorFormat(string.Concat(obj));
					UnityEngine.Debug.LogErrorFormat(string.Format("Integrity check failed. " + mB_TexSet.matsAndGOs.mats[j].objName + " Encapsulating sampling rect failed to contain potentialRect\n"));
					MB2_TextureBakeResults.IsMeshAndMaterialRectEnclosedByAtlasRect(mB_TexSet.tilingTreatment, obUVRectIfTilingSame.GetRect(), materialTiling.GetRect(), mB_TexSet.ts[0].GetEncapsulatingSamplingRect().GetRect(), MB2_LogLevel.trace);
				}
			}
		}
	}
}
public class MB3_TextureCombinerNonTextureProperties
{
	public interface MaterialProperty
	{
		string PropertyName { get; set; }

		MaterialPropertyValueAveraged GetAverageCalculator();

		object GetDefaultValue();
	}

	public class MaterialPropertyFloat : MaterialProperty
	{
		private MaterialPropertyValueAveragedFloat _averageCalc;

		private float _defaultValue;

		public string PropertyName { get; set; }

		public MaterialPropertyFloat(string name, float defValue)
		{
			_averageCalc = new MaterialPropertyValueAveragedFloat();
			_defaultValue = defValue;
			PropertyName = name;
		}

		public MaterialPropertyValueAveraged GetAverageCalculator()
		{
			return _averageCalc;
		}

		public object GetDefaultValue()
		{
			return _defaultValue;
		}
	}

	public class MaterialPropertyColor : MaterialProperty
	{
		private MaterialPropertyValueAveragedColor _averageCalc;

		private Color _defaultValue;

		public string PropertyName { get; set; }

		public MaterialPropertyColor(string name, Color defaultVal)
		{
			_averageCalc = new MaterialPropertyValueAveragedColor();
			_defaultValue = defaultVal;
			PropertyName = name;
		}

		public MaterialPropertyValueAveraged GetAverageCalculator()
		{
			return _averageCalc;
		}

		public object GetDefaultValue()
		{
			return _defaultValue;
		}
	}

	public interface MaterialPropertyValueAveraged
	{
		void TryGetPropValueFromMaterialAndBlendIntoAverage(Material mat, MaterialProperty property);

		object GetAverage();

		int NumValues();

		void SetAverageValueOrDefaultOnMaterial(Material mat, MaterialProperty property);
	}

	public class MaterialPropertyValueAveragedFloat : MaterialPropertyValueAveraged
	{
		public float averageVal;

		public int numValues;

		public void TryGetPropValueFromMaterialAndBlendIntoAverage(Material mat, MaterialProperty property)
		{
			if (mat.HasProperty(property.PropertyName))
			{
				float num = mat.GetFloat(property.PropertyName);
				averageVal = averageVal * (float)numValues / (float)(numValues + 1) + num / (float)(numValues + 1);
				numValues++;
			}
		}

		public object GetAverage()
		{
			return averageVal;
		}

		public int NumValues()
		{
			return numValues;
		}

		public void SetAverageValueOrDefaultOnMaterial(Material mat, MaterialProperty property)
		{
			if (mat.HasProperty(property.PropertyName))
			{
				if (numValues > 0)
				{
					mat.SetFloat(property.PropertyName, averageVal);
				}
				else
				{
					mat.SetFloat(property.PropertyName, (float)property.GetDefaultValue());
				}
			}
		}
	}

	public class MaterialPropertyValueAveragedColor : MaterialPropertyValueAveraged
	{
		public Color averageVal;

		public int numValues;

		public void TryGetPropValueFromMaterialAndBlendIntoAverage(Material mat, MaterialProperty property)
		{
			if (mat.HasProperty(property.PropertyName))
			{
				Color color = mat.GetColor(property.PropertyName);
				averageVal = averageVal * numValues / (numValues + 1) + color / (numValues + 1);
				numValues++;
			}
		}

		public object GetAverage()
		{
			return averageVal;
		}

		public int NumValues()
		{
			return numValues;
		}

		public void SetAverageValueOrDefaultOnMaterial(Material mat, MaterialProperty property)
		{
			if (mat.HasProperty(property.PropertyName))
			{
				if (numValues > 0)
				{
					mat.SetColor(property.PropertyName, averageVal);
				}
				else
				{
					mat.SetColor(property.PropertyName, (Color)property.GetDefaultValue());
				}
			}
		}
	}

	public struct TexPropertyNameColorPair(string nm, Color col)
	{
		public string name = nm;

		public Color color = col;
	}

	private interface NonTextureProperties
	{
		bool NonTexturePropertiesAreEqual(Material a, Material b);

		Texture2D TintTextureWithTextureCombiner(Texture2D t, MB_TexSet sourceMaterial, ShaderTextureProperty shaderPropertyName);

		void AdjustNonTextureProperties(Material resultMat, List<ShaderTextureProperty> texPropertyNames, MB2_EditorMethodsInterface editorMethods);

		Color GetColorForTemporaryTexture(Material matIfBlender, ShaderTextureProperty texProperty);

		Color GetColorAsItWouldAppearInAtlasIfNoTexture(Material matIfBlender, ShaderTextureProperty texProperty);
	}

	private class NonTexturePropertiesDontBlendProps : NonTextureProperties
	{
		private MB3_TextureCombinerNonTextureProperties _textureProperties;

		public NonTexturePropertiesDontBlendProps(MB3_TextureCombinerNonTextureProperties textureProperties)
		{
			_textureProperties = textureProperties;
		}

		public bool NonTexturePropertiesAreEqual(Material a, Material b)
		{
			return true;
		}

		public Texture2D TintTextureWithTextureCombiner(Texture2D t, MB_TexSet sourceMaterial, ShaderTextureProperty shaderPropertyName)
		{
			UnityEngine.Debug.LogError("TintTextureWithTextureCombiner should never be called if resultMaterialTextureBlender is null");
			return t;
		}

		public void AdjustNonTextureProperties(Material resultMat, List<ShaderTextureProperty> texPropertyNames, MB2_EditorMethodsInterface editorMethods)
		{
			if (resultMat == null || texPropertyNames == null)
			{
				return;
			}
			for (int i = 0; i < _textureProperties._nonTextureProperties.Length; i++)
			{
				MaterialProperty materialProperty = _textureProperties._nonTextureProperties[i];
				if (resultMat.HasProperty(materialProperty.PropertyName))
				{
					materialProperty.GetAverageCalculator().SetAverageValueOrDefaultOnMaterial(resultMat, materialProperty);
				}
			}
			editorMethods?.CommitChangesToAssets();
		}

		public Color GetColorAsItWouldAppearInAtlasIfNoTexture(Material matIfBlender, ShaderTextureProperty texProperty)
		{
			return Color.white;
		}

		public Color GetColorForTemporaryTexture(Material matIfBlender, ShaderTextureProperty texProperty)
		{
			if (texProperty.isNormalMap)
			{
				if (MBVersion.IsSwizzledNormalMapPlatform())
				{
					return MB3_TextureCombiner.NEUTRAL_NORMAL_MAP_COLOR_SWIZZLED;
				}
				return MB3_TextureCombiner.NEUTRAL_NORMAL_MAP_COLOR_NON_SWIZZLED;
			}
			if (_textureProperties.textureProperty2DefaultColorMap.ContainsKey(texProperty.name))
			{
				return _textureProperties.textureProperty2DefaultColorMap[texProperty.name];
			}
			return new Color(1f, 1f, 1f, 0f);
		}
	}

	private class NonTexturePropertiesBlendProps : NonTextureProperties
	{
		private MB3_TextureCombinerNonTextureProperties _textureProperties;

		private TextureBlender resultMaterialTextureBlender;

		public NonTexturePropertiesBlendProps(MB3_TextureCombinerNonTextureProperties textureProperties, TextureBlender resultMats)
		{
			resultMaterialTextureBlender = resultMats;
			_textureProperties = textureProperties;
		}

		public bool NonTexturePropertiesAreEqual(Material a, Material b)
		{
			return resultMaterialTextureBlender.NonTexturePropertiesAreEqual(a, b);
		}

		public Texture2D TintTextureWithTextureCombiner(Texture2D t, MB_TexSet sourceMaterial, ShaderTextureProperty shaderPropertyName)
		{
			resultMaterialTextureBlender.OnBeforeTintTexture(sourceMaterial.matsAndGOs.mats[0].mat, shaderPropertyName.name);
			if (_textureProperties.LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"Blending texture {t.name} mat {sourceMaterial.matsAndGOs.mats[0].mat} with non-texture properties using TextureBlender {resultMaterialTextureBlender}");
			}
			for (int i = 0; i < t.height; i++)
			{
				Color[] pixels = t.GetPixels(0, i, t.width, 1);
				for (int j = 0; j < pixels.Length; j++)
				{
					pixels[j] = resultMaterialTextureBlender.OnBlendTexturePixel(shaderPropertyName.name, pixels[j]);
				}
				t.SetPixels(0, i, t.width, 1, pixels);
			}
			t.Apply();
			return t;
		}

		public void AdjustNonTextureProperties(Material resultMat, List<ShaderTextureProperty> texPropertyNames, MB2_EditorMethodsInterface editorMethods)
		{
			if (!(resultMat == null) && texPropertyNames != null)
			{
				if (_textureProperties.LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Adjusting non texture properties using TextureBlender for shader: " + resultMat.shader.name);
				}
				resultMaterialTextureBlender.SetNonTexturePropertyValuesOnResultMaterial(resultMat);
				editorMethods?.CommitChangesToAssets();
			}
		}

		public Color GetColorAsItWouldAppearInAtlasIfNoTexture(Material matIfBlender, ShaderTextureProperty texProperty)
		{
			resultMaterialTextureBlender.OnBeforeTintTexture(matIfBlender, texProperty.name);
			Color colorForTemporaryTexture = GetColorForTemporaryTexture(matIfBlender, texProperty);
			return resultMaterialTextureBlender.OnBlendTexturePixel(texProperty.name, colorForTemporaryTexture);
		}

		public Color GetColorForTemporaryTexture(Material matIfBlender, ShaderTextureProperty texProperty)
		{
			return resultMaterialTextureBlender.GetColorIfNoTexture(matIfBlender, texProperty);
		}
	}

	private TexPropertyNameColorPair[] defaultTextureProperty2DefaultColorMap = new TexPropertyNameColorPair[6]
	{
		new TexPropertyNameColorPair("_MainTex", new Color(1f, 1f, 1f, 0f)),
		new TexPropertyNameColorPair("_MetallicGlossMap", new Color(0f, 0f, 0f, 1f)),
		new TexPropertyNameColorPair("_ParallaxMap", new Color(0f, 0f, 0f, 0f)),
		new TexPropertyNameColorPair("_OcclusionMap", new Color(1f, 1f, 1f, 1f)),
		new TexPropertyNameColorPair("_EmissionMap", new Color(0f, 0f, 0f, 0f)),
		new TexPropertyNameColorPair("_DetailMask", new Color(0f, 0f, 0f, 0f))
	};

	private MaterialProperty[] _nonTextureProperties = new MaterialProperty[8]
	{
		new MaterialPropertyColor("_Color", Color.white),
		new MaterialPropertyFloat("_Glossiness", 0.5f),
		new MaterialPropertyFloat("_GlossMapScale", 1f),
		new MaterialPropertyFloat("_Metallic", 0f),
		new MaterialPropertyFloat("_BumpScale", 0.1f),
		new MaterialPropertyFloat("_Parallax", 0.02f),
		new MaterialPropertyFloat("_OcclusionStrength", 1f),
		new MaterialPropertyColor("_EmissionColor", Color.black)
	};

	private MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	private bool _considerNonTextureProperties;

	private TextureBlender resultMaterialTextureBlender;

	private TextureBlender[] textureBlenders = new TextureBlender[0];

	private Dictionary<string, Color> textureProperty2DefaultColorMap = new Dictionary<string, Color>();

	private NonTextureProperties _nonTexturePropertiesBlender;

	public MB3_TextureCombinerNonTextureProperties(MB2_LogLevel ll, bool considerNonTextureProps)
	{
		_considerNonTextureProperties = considerNonTextureProps;
		textureProperty2DefaultColorMap = new Dictionary<string, Color>();
		for (int i = 0; i < defaultTextureProperty2DefaultColorMap.Length; i++)
		{
			textureProperty2DefaultColorMap.Add(defaultTextureProperty2DefaultColorMap[i].name, defaultTextureProperty2DefaultColorMap[i].color);
			_nonTexturePropertiesBlender = new NonTexturePropertiesDontBlendProps(this);
		}
	}

	internal void CollectAverageValuesOfNonTextureProperties(Material resultMaterial, Material mat)
	{
		for (int i = 0; i < _nonTextureProperties.Length; i++)
		{
			MaterialProperty materialProperty = _nonTextureProperties[i];
			if (resultMaterial.HasProperty(materialProperty.PropertyName))
			{
				materialProperty.GetAverageCalculator().TryGetPropValueFromMaterialAndBlendIntoAverage(mat, materialProperty);
			}
		}
	}

	internal void LoadTextureBlendersIfNeeded(Material resultMaterial)
	{
		if (_considerNonTextureProperties)
		{
			LoadTextureBlenders();
			FindBestTextureBlender(resultMaterial);
		}
	}

	private static bool InterfaceFilter(Type typeObj, object criteriaObj)
	{
		return typeObj.ToString() == criteriaObj.ToString();
	}

	private void FindBestTextureBlender(Material resultMaterial)
	{
		resultMaterialTextureBlender = FindMatchingTextureBlender(resultMaterial.shader.name);
		if (resultMaterialTextureBlender != null)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Using Consider Non-Texture Properties found a TextureBlender for result material. Using: " + resultMaterialTextureBlender);
			}
		}
		else
		{
			resultMaterialTextureBlender = new TextureBlenderFallback();
		}
		if (resultMaterialTextureBlender is TextureBlenderFallback && LOG_LEVEL >= MB2_LogLevel.error)
		{
			UnityEngine.Debug.LogWarning("Using _considerNonTextureProperties could not find a TextureBlender that matches the shader on the result material (" + resultMaterial.shader.name + "). Using the Fallback Texture Blender.");
		}
		_nonTexturePropertiesBlender = new NonTexturePropertiesBlendProps(this, resultMaterialTextureBlender);
	}

	private void LoadTextureBlenders()
	{
		string filterCriteria = "DigitalOpus.MB.Core.TextureBlender";
		TypeFilter filter = InterfaceFilter;
		List<Type> list = new List<Type>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			IEnumerable enumerable = null;
			try
			{
				enumerable = assembly.GetTypes();
			}
			catch (Exception ex)
			{
				ex.Equals(null);
			}
			if (enumerable == null)
			{
				continue;
			}
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (type.FindInterfaces(filter, filterCriteria).Length != 0)
				{
					list.Add(type);
				}
			}
		}
		TextureBlender textureBlender = null;
		List<TextureBlender> list2 = new List<TextureBlender>();
		foreach (Type item in list)
		{
			if (!item.IsAbstract && !item.IsInterface)
			{
				TextureBlender textureBlender2 = (TextureBlender)Activator.CreateInstance(item);
				if (textureBlender2 is TextureBlenderFallback)
				{
					textureBlender = textureBlender2;
				}
				else
				{
					list2.Add(textureBlender2);
				}
			}
		}
		if (textureBlender != null)
		{
			list2.Add(textureBlender);
		}
		textureBlenders = list2.ToArray();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"Loaded {textureBlenders.Length} TextureBlenders.");
		}
	}

	internal bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		return _nonTexturePropertiesBlender.NonTexturePropertiesAreEqual(a, b);
	}

	internal Texture2D TintTextureWithTextureCombiner(Texture2D t, MB_TexSet sourceMaterial, ShaderTextureProperty shaderPropertyName)
	{
		return _nonTexturePropertiesBlender.TintTextureWithTextureCombiner(t, sourceMaterial, shaderPropertyName);
	}

	internal void AdjustNonTextureProperties(Material resultMat, List<ShaderTextureProperty> texPropertyNames, MB2_EditorMethodsInterface editorMethods)
	{
		if (!(resultMat == null) && texPropertyNames != null)
		{
			_nonTexturePropertiesBlender.AdjustNonTextureProperties(resultMat, texPropertyNames, editorMethods);
		}
	}

	internal Color GetColorAsItWouldAppearInAtlasIfNoTexture(Material matIfBlender, ShaderTextureProperty texProperty)
	{
		return _nonTexturePropertiesBlender.GetColorAsItWouldAppearInAtlasIfNoTexture(matIfBlender, texProperty);
	}

	internal Color GetColorForTemporaryTexture(Material matIfBlender, ShaderTextureProperty texProperty)
	{
		return _nonTexturePropertiesBlender.GetColorForTemporaryTexture(matIfBlender, texProperty);
	}

	private TextureBlender FindMatchingTextureBlender(string shaderName)
	{
		for (int i = 0; i < textureBlenders.Length; i++)
		{
			if (textureBlenders[i].DoesShaderNameMatch(shaderName))
			{
				return textureBlenders[i];
			}
		}
		return null;
	}
}
internal class MB3_TextureCombinerPackerMeshBaker : MB3_TextureCombinerPackerRoot
{
	public override bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		return true;
	}

	public override IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		Rect[] uvRects = packedAtlasRects.rects;
		int atlasSizeX = packedAtlasRects.atlasX;
		int atlasSizeY = packedAtlasRects.atlasY;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Generated atlas will be " + atlasSizeX + "x" + atlasSizeY);
		}
		for (int propIdx = 0; propIdx < data.numAtlases; propIdx++)
		{
			ShaderTextureProperty property = data.texPropertyNames[propIdx];
			Texture2D texture2D;
			if (!MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(propIdx, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
			{
				texture2D = null;
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("=== Not creating atlas for " + property.name + " because textures are null and default value parameters are the same.");
				}
			}
			else
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("=== Creating atlas for " + property.name);
				}
				GC.Collect();
				MB3_TextureCombinerPackerRoot.CreateTemporaryTexturesForAtlas(data.distinctMaterialTextures, combiner, propIdx, data);
				Color[][] atlasPixels = new Color[atlasSizeY][];
				for (int i = 0; i < atlasPixels.Length; i++)
				{
					atlasPixels[i] = new Color[atlasSizeX];
				}
				bool isNormalMap = false;
				if (property.isNormalMap)
				{
					isNormalMap = true;
				}
				for (int texSetIdx = 0; texSetIdx < data.distinctMaterialTextures.Count; texSetIdx++)
				{
					MB_TexSet mB_TexSet = data.distinctMaterialTextures[texSetIdx];
					MeshBakerMaterialTexture meshBakerMaterialTexture = mB_TexSet.ts[propIdx];
					string text = "Creating Atlas '" + property.name + "' texture " + meshBakerMaterialTexture.GetTexName();
					progressInfo?.Invoke(text, 0.01f);
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log($"Adding texture {meshBakerMaterialTexture.GetTexName()} to atlas {property.name} for texSet {texSetIdx} srcMat {mB_TexSet.matsAndGOs.mats[0].GetMaterialName()}");
					}
					Rect rect = uvRects[texSetIdx];
					Texture2D texture2D2 = mB_TexSet.ts[propIdx].GetTexture2D();
					int targX = Mathf.RoundToInt(rect.x * (float)atlasSizeX);
					int targY = Mathf.RoundToInt(rect.y * (float)atlasSizeY);
					int num = Mathf.RoundToInt(rect.width * (float)atlasSizeX);
					int num2 = Mathf.RoundToInt(rect.height * (float)atlasSizeY);
					if (num == 0 || num2 == 0)
					{
						Rect rect2 = rect;
						UnityEngine.Debug.LogError("Image in atlas has no height or width " + rect2.ToString());
					}
					progressInfo?.Invoke(text + " set ReadWrite flag", 0.01f);
					textureEditorMethods?.SetReadWriteFlag(texture2D2, isReadable: true, addToList: true);
					progressInfo?.Invoke(text + "Copying to atlas: '" + meshBakerMaterialTexture.GetTexName() + "'", 0.02f);
					DRect encapsulatingSamplingRect = mB_TexSet.ts[propIdx].GetEncapsulatingSamplingRect();
					yield return CopyScaledAndTiledToAtlas(mB_TexSet.ts[propIdx], mB_TexSet, property, encapsulatingSamplingRect, targX, targY, num, num2, packedAtlasRects.padding[texSetIdx], atlasPixels, isNormalMap, data, combiner, progressInfo, LOG_LEVEL);
				}
				yield return data.numAtlases;
				progressInfo?.Invoke("Applying changes to atlas: '" + property.name + "'", 0.03f);
				texture2D = new Texture2D(atlasSizeX, atlasSizeY, TextureFormat.ARGB32, mipChain: true, property.isGammaCorrected);
				for (int j = 0; j < atlasPixels.Length; j++)
				{
					texture2D.SetPixels(0, j, atlasSizeX, 1, atlasPixels[j]);
				}
				texture2D.Apply();
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Saving atlas " + property.name + " w=" + texture2D.width + " h=" + texture2D.height);
				}
			}
			atlases[propIdx] = texture2D;
			progressInfo?.Invoke("Saving atlas: '" + property.name + "'", 0.04f);
			new Stopwatch().Start();
			if (data.resultType == MB2_TextureBakeResults.ResultType.atlas)
			{
				MB3_TextureCombinerPackerRoot.SaveAtlasAndConfigureResultMaterial(data, textureEditorMethods, atlases[propIdx], data.texPropertyNames[propIdx], propIdx);
			}
			combiner._destroyTemporaryTextures(data.texPropertyNames[propIdx].name);
		}
	}

	internal static IEnumerator CopyScaledAndTiledToAtlas(MeshBakerMaterialTexture source, MB_TexSet sourceMaterial, ShaderTextureProperty shaderPropertyName, DRect srcSamplingRect, int targX, int targY, int targW, int targH, AtlasPadding padding, Color[][] atlasPixels, bool isNormalMap, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, ProgressUpdateDelegate progressInfo = null, MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info)
	{
		Texture2D texture2D = source.GetTexture2D();
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"CopyScaledAndTiledToAtlas: {texture2D} inAtlasX={targX} inAtlasY={targY} inAtlasW={targW} inAtlasH={targH} paddX={padding.leftRight} paddY={padding.topBottom} srcSamplingRect={srcSamplingRect}");
		}
		float num = targW;
		float num2 = targH;
		float num3 = (float)srcSamplingRect.width;
		float num4 = (float)srcSamplingRect.height;
		float num5 = (float)srcSamplingRect.x;
		float num6 = (float)srcSamplingRect.y;
		int w = (int)num;
		int h = (int)num2;
		if (data._considerNonTextureProperties)
		{
			texture2D = combiner._createTextureCopy(shaderPropertyName, texture2D);
			texture2D = data.nonTexturePropertyBlender.TintTextureWithTextureCombiner(texture2D, sourceMaterial, shaderPropertyName);
		}
		for (int i = 0; i < w; i++)
		{
			if (progressInfo != null && w > 0)
			{
				progressInfo("CopyScaledAndTiledToAtlas " + ((float)i / (float)w * 100f).ToString("F0"), 0.2f);
			}
			for (int j = 0; j < h; j++)
			{
				float u = (float)i / num * num3 + num5;
				float v = (float)j / num2 * num4 + num6;
				atlasPixels[targY + j][targX + i] = texture2D.GetPixelBilinear(u, v);
			}
		}
		for (int k = 0; k < w; k++)
		{
			for (int l = 1; l <= padding.topBottom; l++)
			{
				atlasPixels[targY - l][targX + k] = atlasPixels[targY][targX + k];
				atlasPixels[targY + h - 1 + l][targX + k] = atlasPixels[targY + h - 1][targX + k];
			}
		}
		for (int m = 0; m < h; m++)
		{
			for (int n = 1; n <= padding.leftRight; n++)
			{
				atlasPixels[targY + m][targX - n] = atlasPixels[targY + m][targX];
				atlasPixels[targY + m][targX + w + n - 1] = atlasPixels[targY + m][targX + w - 1];
			}
		}
		for (int num7 = 1; num7 <= padding.leftRight; num7++)
		{
			for (int num8 = 1; num8 <= padding.topBottom; num8++)
			{
				atlasPixels[targY - num8][targX - num7] = atlasPixels[targY][targX];
				atlasPixels[targY + h - 1 + num8][targX - num7] = atlasPixels[targY + h - 1][targX];
				atlasPixels[targY + h - 1 + num8][targX + w + num7 - 1] = atlasPixels[targY + h - 1][targX + w - 1];
				atlasPixels[targY - num8][targX + w + num7 - 1] = atlasPixels[targY][targX + w - 1];
				yield return null;
			}
			yield return null;
		}
	}
}
internal class MB3_TextureCombinerPackerMeshBakerFast : MB_ITextureCombinerPacker
{
	public bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		return true;
	}

	public IEnumerator ConvertTexturesToReadableFormats(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		yield break;
	}

	public virtual AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		return MB3_TextureCombinerPackerRoot.CalculateAtlasRectanglesStatic(data, doMultiAtlas, LOG_LEVEL);
	}

	public IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		Rect[] rects = packedAtlasRects.rects;
		int atlasX = packedAtlasRects.atlasX;
		int atlasY = packedAtlasRects.atlasY;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Generated atlas will be " + atlasX + "x" + atlasY);
		}
		GameObject gameObject = null;
		try
		{
			gameObject = new GameObject("MBrenderAtlasesGO");
			MB3_AtlasPackerRenderTexture mB3_AtlasPackerRenderTexture = gameObject.AddComponent<MB3_AtlasPackerRenderTexture>();
			gameObject.AddComponent<Camera>();
			if (data._considerNonTextureProperties && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogError("Blend Non-Texture Properties has limited functionality when used with Mesh Baker Texture Packer Fast. If no texture is pesent, then a small texture matching the non-texture property will be created and used in the atlas. But non-texture properties will not be blended into texture.");
			}
			for (int i = 0; i < data.numAtlases; i++)
			{
				Texture2D texture2D;
				if (!MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					texture2D = null;
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Not creating atlas for " + data.texPropertyNames[i].name + " because textures are null and default value parameters are the same.");
					}
				}
				else
				{
					GC.Collect();
					MB3_TextureCombinerPackerRoot.CreateTemporaryTexturesForAtlas(data.distinctMaterialTextures, combiner, i, data);
					progressInfo?.Invoke("Creating Atlas '" + data.texPropertyNames[i].name + "'", 0.01f);
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("About to render " + data.texPropertyNames[i].name + " isNormal=" + data.texPropertyNames[i].isNormalMap);
					}
					mB3_AtlasPackerRenderTexture.LOG_LEVEL = LOG_LEVEL;
					mB3_AtlasPackerRenderTexture.width = atlasX;
					mB3_AtlasPackerRenderTexture.height = atlasY;
					mB3_AtlasPackerRenderTexture.padding = data._atlasPadding_pix;
					mB3_AtlasPackerRenderTexture.rects = rects;
					mB3_AtlasPackerRenderTexture.textureSets = data.distinctMaterialTextures;
					mB3_AtlasPackerRenderTexture.indexOfTexSetToRender = i;
					mB3_AtlasPackerRenderTexture.texPropertyName = data.texPropertyNames[i];
					mB3_AtlasPackerRenderTexture.isNormalMap = data.texPropertyNames[i].isNormalMap;
					mB3_AtlasPackerRenderTexture.fixOutOfBoundsUVs = data._fixOutOfBoundsUVs;
					mB3_AtlasPackerRenderTexture.considerNonTextureProperties = data._considerNonTextureProperties;
					mB3_AtlasPackerRenderTexture.resultMaterialTextureBlender = data.nonTexturePropertyBlender;
					texture2D = mB3_AtlasPackerRenderTexture.OnRenderAtlas(combiner);
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Saving atlas " + data.texPropertyNames[i].name + " w=" + texture2D.width + " h=" + texture2D.height + " id=" + texture2D.GetInstanceID());
					}
				}
				atlases[i] = texture2D;
				progressInfo?.Invoke("Saving atlas: '" + data.texPropertyNames[i].name + "'", 0.04f);
				if (data.resultType == MB2_TextureBakeResults.ResultType.atlas)
				{
					MB3_TextureCombinerPackerRoot.SaveAtlasAndConfigureResultMaterial(data, textureEditorMethods, atlases[i], data.texPropertyNames[i], i);
				}
				combiner._destroyTemporaryTextures(data.texPropertyNames[i].name);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(ex.Message + "\n" + ex.StackTrace.ToString());
		}
		finally
		{
			if (gameObject != null)
			{
				MB_Utility.Destroy(gameObject);
			}
		}
		yield break;
	}
}
internal class MB3_TextureCombinerPackerMeshBakerFastV2 : MB_ITextureCombinerPacker
{
	private Mesh mesh;

	private GameObject renderAtlasesGO;

	private GameObject cameraGameObject;

	public bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		string text = LayerMask.LayerToName(data._layerTexturePackerFastV2);
		if (text == null || text.Length == 0)
		{
			UnityEngine.Debug.LogError("The MB3_MeshBaker -> 'Atlas Render Layer' has not been set. This should be set to a layer that has no other renderers on it.");
			return false;
		}
		if (Application.isEditor)
		{
			Renderer[] array = UnityEngine.Object.FindObjectsOfType<Renderer>();
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].gameObject.layer == data._layerTexturePackerFastV2)
				{
					flag = true;
				}
			}
			if (flag)
			{
				UnityEngine.Debug.LogError("There are Renderers in the scene that are on layer '" + text + "'. 'Atlas Render Layer' layer should have no renderers that use it.");
				return false;
			}
		}
		return true;
	}

	public IEnumerator ConvertTexturesToReadableFormats(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		yield break;
	}

	public virtual AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		return MB3_TextureCombinerPackerRoot.CalculateAtlasRectanglesStatic(data, doMultiAtlas, LOG_LEVEL);
	}

	public IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		int atlasX = packedAtlasRects.atlasX;
		int atlasY = packedAtlasRects.atlasY;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Generated atlas will be " + atlasX + "x" + atlasY);
		}
		int layerTexturePackerFastV = data._layerTexturePackerFastV2;
		mesh = new Mesh();
		renderAtlasesGO = null;
		cameraGameObject = null;
		try
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			renderAtlasesGO = new GameObject("MBrenderAtlasesGO");
			cameraGameObject = new GameObject("MBCameraGameObject");
			MB3_AtlasPackerRenderTextureUsingMesh mB3_AtlasPackerRenderTextureUsingMesh = new MB3_AtlasPackerRenderTextureUsingMesh();
			OneTimeSetup(mB3_AtlasPackerRenderTextureUsingMesh, renderAtlasesGO, cameraGameObject, atlasX, atlasY, data._atlasPadding_pix, layerTexturePackerFastV, LOG_LEVEL);
			if (data._considerNonTextureProperties && LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Blend Non-Texture Properties has limited functionality when used with Mesh Baker Texture Packer Fast.");
			}
			List<Material> list = new List<Material>();
			for (int i = 0; i < data.numAtlases; i++)
			{
				Texture2D texture2D;
				if (!MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					texture2D = null;
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Not creating atlas for " + data.texPropertyNames[i].name + " because textures are null and default value parameters are the same.");
					}
				}
				else
				{
					progressInfo?.Invoke("Creating Atlas '" + data.texPropertyNames[i].name + "'", 0.01f);
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("About to render " + data.texPropertyNames[i].name + " isNormal=" + data.texPropertyNames[i].isNormalMap);
					}
					list.Clear();
					MB3_AtlasPackerRenderTextureUsingMesh.MeshAtlas.BuildAtlas(packedAtlasRects, data.distinctMaterialTextures, i, packedAtlasRects.atlasX, packedAtlasRects.atlasY, mesh, list, data.texPropertyNames[i], data, combiner, textureEditorMethods, LOG_LEVEL);
					renderAtlasesGO.GetComponent<MeshFilter>().sharedMesh = mesh;
					MeshRenderer component = renderAtlasesGO.GetComponent<MeshRenderer>();
					Material[] sharedMaterials = list.ToArray();
					component.sharedMaterials = sharedMaterials;
					texture2D = mB3_AtlasPackerRenderTextureUsingMesh.DoRenderAtlas(cameraGameObject, packedAtlasRects.atlasX, packedAtlasRects.atlasY, data.texPropertyNames[i].isNormalMap, data.texPropertyNames[i]);
					for (int j = 0; j < list.Count; j++)
					{
						MB_Utility.Destroy(list[j]);
					}
					list.Clear();
					if (LOG_LEVEL >= MB2_LogLevel.debug)
					{
						UnityEngine.Debug.Log("Saving atlas " + data.texPropertyNames[i].name + " w=" + texture2D.width + " h=" + texture2D.height + " id=" + texture2D.GetInstanceID());
					}
				}
				atlases[i] = texture2D;
				progressInfo?.Invoke("Saving atlas: '" + data.texPropertyNames[i].name + "'", 0.04f);
				if (data.resultType == MB2_TextureBakeResults.ResultType.atlas)
				{
					MB3_TextureCombinerPackerRoot.SaveAtlasAndConfigureResultMaterial(data, textureEditorMethods, atlases[i], data.texPropertyNames[i], i);
				}
				combiner._destroyTemporaryTextures(data.texPropertyNames[i].name);
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.LogFormat("Timing MB3_TextureCombinerPackerMeshBakerFastV2.CreateAtlases={0}", (float)stopwatch.ElapsedMilliseconds * 0.001f);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(ex.Message + "\n" + ex.StackTrace.ToString());
		}
		finally
		{
			if (renderAtlasesGO != null)
			{
				MB_Utility.Destroy(renderAtlasesGO);
			}
			if (cameraGameObject != null)
			{
				MB_Utility.Destroy(cameraGameObject);
			}
			if (mesh != null)
			{
				MB_Utility.Destroy(mesh);
			}
		}
		yield break;
	}

	private void OneTimeSetup(MB3_AtlasPackerRenderTextureUsingMesh atlasRenderer, GameObject atlasMesh, GameObject cameraGameObject, int atlasWidth, int atlasHeight, int padding, int layer, MB2_LogLevel logLevel)
	{
		atlasMesh.AddComponent<MeshFilter>();
		atlasMesh.AddComponent<MeshRenderer>();
		atlasMesh.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		atlasMesh.transform.position = new Vector3(0f, 0f, 0.5f);
		atlasMesh.gameObject.layer = layer;
		atlasRenderer.Initialize(layer, atlasWidth, atlasHeight, padding, logLevel);
		atlasRenderer.SetupCameraGameObject(cameraGameObject);
	}
}
public class MB3_AtlasPackerRenderTextureUsingMesh
{
	public class MeshRectInfo
	{
		public int vertIdx;

		public int triIdx;

		public int atlasIdx;
	}

	public class MeshAtlas
	{
		internal static void BuildAtlas(AtlasPackingResult packedAtlasRects, List<MB_TexSet> distinctMaterialTextures, int propIdx, int atlasSizeX, int atlasSizeY, Mesh m, List<Material> generatedMats, ShaderTextureProperty property, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
		{
			generatedMats.Clear();
			List<Vector3> list = new List<Vector3>();
			List<Vector2> list2 = new List<Vector2>();
			List<int>[] array = new List<int>[distinctMaterialTextures.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new List<int>();
			}
			MeshBakerMaterialTexture.readyToBuildAtlases = true;
			GC.Collect();
			MB3_TextureCombinerPackerRoot.CreateTemporaryTexturesForAtlas(data.distinctMaterialTextures, combiner, propIdx, data);
			Rect[] rects = packedAtlasRects.rects;
			for (int j = 0; j < distinctMaterialTextures.Count; j++)
			{
				MB_TexSet mB_TexSet = distinctMaterialTextures[j];
				MeshBakerMaterialTexture meshBakerMaterialTexture = mB_TexSet.ts[propIdx];
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Adding texture {meshBakerMaterialTexture.GetTexName()} to atlas {property.name} for texSet {j} srcMat {mB_TexSet.matsAndGOs.mats[0].GetMaterialName()}");
				}
				Rect rect = rects[j];
				Texture2D texture2D = meshBakerMaterialTexture.GetTexture2D();
				int num = Mathf.RoundToInt(rect.x * (float)atlasSizeX);
				int num2 = Mathf.RoundToInt(rect.y * (float)atlasSizeY);
				int num3 = Mathf.RoundToInt(rect.width * (float)atlasSizeX);
				int num4 = Mathf.RoundToInt(rect.height * (float)atlasSizeY);
				rect = new Rect(num, num2, num3, num4);
				if (num3 == 0 || num4 == 0)
				{
					Rect rect2 = rect;
					UnityEngine.Debug.LogError("Image in atlas has no height or width " + rect2.ToString());
				}
				DRect encapsulatingSamplingRect = mB_TexSet.ts[propIdx].GetEncapsulatingSamplingRect();
				AtlasPadding atlasPadding = packedAtlasRects.padding[j];
				AddNineSlicedRect(rect, atlasPadding.leftRight, atlasPadding.topBottom, encapsulatingSamplingRect.GetRect(), list, list2, array[j], texture2D.width, texture2D.height, texture2D.name);
				Material material = new Material(Shader.Find("MeshBaker/Unlit/UnlitWithAlpha"));
				bool isSavingAsANormalMapAssetThatWillBeImported = property.isNormalMap && data._saveAtlasesAsAssets;
				switch (MBVersion.DetectPipeline())
				{
				case MBVersion.PipelineType.URP:
					ConfigureMaterial_DefaultPipeline(material, texture2D, isSavingAsANormalMapAssetThatWillBeImported, LOG_LEVEL);
					break;
				case MBVersion.PipelineType.HDRP:
					ConfigureMaterial_DefaultPipeline(material, texture2D, isSavingAsANormalMapAssetThatWillBeImported, LOG_LEVEL);
					break;
				default:
					ConfigureMaterial_DefaultPipeline(material, texture2D, isSavingAsANormalMapAssetThatWillBeImported, LOG_LEVEL);
					break;
				}
				generatedMats.Add(material);
			}
			m.Clear();
			m.vertices = list.ToArray();
			m.uv = list2.ToArray();
			m.subMeshCount = array.Length;
			for (int k = 0; k < m.subMeshCount; k++)
			{
				m.SetIndices(array[k].ToArray(), MeshTopology.Triangles, k);
			}
			MeshBakerMaterialTexture.readyToBuildAtlases = false;
		}

		private static void ConfigureMaterial_DefaultPipeline(Material mt, Texture2D t, bool isSavingAsANormalMapAssetThatWillBeImported, MB2_LogLevel LOG_LEVEL)
		{
			Shader shader = null;
			shader = Shader.Find("MeshBaker/Unlit/UnlitWithAlpha");
			mt.shader = shader;
			mt.SetTexture("_MainTex", t);
			if (isSavingAsANormalMapAssetThatWillBeImported)
			{
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log("Unswizling normal map channels NM");
				}
				mt.SetFloat("_SwizzleNormalMapChannelsNM", 1f);
				mt.EnableKeyword("_SWIZZLE_NORMAL_CHANNELS_NM");
			}
			else
			{
				mt.SetFloat("_SwizzleNormalMapChannelsNM", 0f);
				mt.DisableKeyword("_SWIZZLE_NORMAL_CHANNELS_NM");
			}
		}

		public static MeshRectInfo AddQuad(Rect wldRect, Rect uvRect, List<Vector3> verts, List<Vector2> uvs, List<int> tris)
		{
			MeshRectInfo meshRectInfo = new MeshRectInfo();
			int num = (meshRectInfo.vertIdx = verts.Count);
			meshRectInfo.triIdx = tris.Count;
			verts.Add(new Vector3(wldRect.x, wldRect.y, 0f));
			verts.Add(new Vector3(wldRect.x + wldRect.width, wldRect.y, 0f));
			verts.Add(new Vector3(wldRect.x, wldRect.y + wldRect.height, 0f));
			verts.Add(new Vector3(wldRect.x + wldRect.width, wldRect.y + wldRect.height, 0f));
			uvs.Add(new Vector2(uvRect.x, uvRect.y));
			uvs.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y));
			uvs.Add(new Vector2(uvRect.x, uvRect.y + uvRect.height));
			uvs.Add(new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height));
			tris.Add(num);
			tris.Add(num + 2);
			tris.Add(num + 1);
			tris.Add(num + 2);
			tris.Add(num + 3);
			tris.Add(num + 1);
			return meshRectInfo;
		}

		public static void AddNineSlicedRect(Rect atlasRectRaw, float paddingX, float paddingY, Rect srcUVRectt, List<Vector3> verts, List<Vector2> uvs, List<int> tris, float srcTexWidth, float srcTexHeight, string texName)
		{
			float num = 0.5f / srcTexWidth;
			float num2 = 0.5f / srcTexHeight;
			float num3 = 0f;
			float num4 = 0f;
			Rect uvRect = srcUVRectt;
			Rect rect = srcUVRectt;
			rect.x += num;
			rect.y += num2;
			rect.width -= num * 2f;
			rect.height -= num2 * 2f;
			Rect rect2 = atlasRectRaw;
			AddQuad(atlasRectRaw, uvRect, verts, uvs, tris);
			bool num5 = paddingY > 0f;
			bool flag = paddingX > 0f;
			if (num5)
			{
				AddQuad(uvRect: new Rect(uvRect.x, uvRect.y + uvRect.height - num2 - num4, uvRect.width, num4), wldRect: new Rect(rect2.x, rect2.y + rect2.height, rect2.width, paddingY), verts: verts, uvs: uvs, tris: tris);
			}
			if (num5)
			{
				AddQuad(uvRect: new Rect(uvRect.x, uvRect.y + num2 - num4, uvRect.width, num4), wldRect: new Rect(rect2.x, rect2.y - paddingY, rect2.width, paddingY), verts: verts, uvs: uvs, tris: tris);
			}
			if (flag)
			{
				AddQuad(uvRect: new Rect(uvRect.x + num, uvRect.y, num3, uvRect.height), wldRect: new Rect(rect2.x - paddingX, rect2.y, paddingX, rect2.height), verts: verts, uvs: uvs, tris: tris);
			}
			if (flag)
			{
				AddQuad(uvRect: new Rect(uvRect.x + uvRect.width - num - num3, uvRect.y, num3, uvRect.height), wldRect: new Rect(rect2.x + rect2.width, rect2.y, paddingX, rect2.height), verts: verts, uvs: uvs, tris: tris);
			}
			if (num5 && flag)
			{
				AddQuad(uvRect: new Rect(uvRect.x + num, uvRect.y + num2, num3, num4), wldRect: new Rect(rect2.x - paddingX, rect2.y - paddingY, paddingX, paddingY), verts: verts, uvs: uvs, tris: tris);
			}
			if (num5 && flag)
			{
				AddQuad(uvRect: new Rect(uvRect.x + num, uvRect.y + uvRect.height - num2 - num4, num3, num4), wldRect: new Rect(rect2.x - paddingX, rect2.y + rect2.height, paddingX, paddingY), verts: verts, uvs: uvs, tris: tris);
			}
			if (num5 && flag)
			{
				AddQuad(uvRect: new Rect(uvRect.x + uvRect.width - num - num3, uvRect.y + uvRect.height - num2 - num4, num3, num4), wldRect: new Rect(rect2.x + rect2.width, rect2.y + rect2.height, paddingX, paddingY), verts: verts, uvs: uvs, tris: tris);
			}
			if (num5 && flag)
			{
				AddQuad(uvRect: new Rect(uvRect.x + uvRect.width - num - num3, uvRect.y + num2 - num4, num3, num4), wldRect: new Rect(rect2.x + rect2.width, rect2.y - paddingY, paddingX, paddingY), verts: verts, uvs: uvs, tris: tris);
			}
		}
	}

	public int camMaskLayer;

	public int width;

	public int height;

	public int padding;

	public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info;

	private bool _initialized;

	private bool _camSetup;

	public void Initialize(int camMaskLayer, int width, int height, int padding, MB2_LogLevel LOG_LEVEL = MB2_LogLevel.info)
	{
		this.camMaskLayer = camMaskLayer;
		this.width = width;
		this.height = height;
		this.padding = padding;
		this.LOG_LEVEL = LOG_LEVEL;
		_initialized = true;
	}

	internal void SetupCameraGameObject(GameObject camGameObject)
	{
		LayerMask layerMask = 1 << camMaskLayer;
		Camera camera = camGameObject.AddComponent<Camera>();
		camera.enabled = false;
		camera.orthographic = true;
		camera.orthographicSize = (float)height / 2f;
		camera.aspect = (float)width / (float)height;
		camera.rect = new Rect(0f, 0f, 1f, 1f);
		camera.clearFlags = CameraClearFlags.Color;
		camera.cullingMask = layerMask;
		Transform component = camera.GetComponent<Transform>();
		component.localPosition = new Vector3((float)width / 2f, (float)height / 2f, 0f);
		component.localRotation = Quaternion.Euler(0f, 0f, 0f);
		MBVersion.DoSpecialRenderPipeline_TexturePackerFastSetup(camGameObject);
		_camSetup = true;
	}

	internal Texture2D DoRenderAtlas(GameObject go, int width, int height, bool isNormalMap, ShaderTextureProperty propertyName)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		RenderTexture renderTexture = ((!isNormalMap) ? new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB) : new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB));
		renderTexture.filterMode = FilterMode.Point;
		Camera component = go.GetComponent<Camera>();
		component.targetTexture = renderTexture;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log(string.Format("Begin Camera.Render destTex w={0} h={1} camPos={2} camSize={3} camAspect={4}", width, height, go.transform.localPosition, component.orthographicSize, component.aspect.ToString("f5")));
		}
		component.Render();
		Stopwatch stopwatch2 = new Stopwatch();
		stopwatch2.Start();
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, mipChain: true, linear: false);
		MB_TextureCombinerRenderTexture.ConvertRenderTextureToTexture2D(renderTexture, MB_TextureCombinerRenderTexture.YisFlipped(LOG_LEVEL), isNormalMap, LOG_LEVEL, texture2D);
		if (LOG_LEVEL >= MB2_LogLevel.trace)
		{
			UnityEngine.Debug.Log("Finished rendering atlas " + propertyName.name + "  db_time_DoRenderAtlas:" + (float)stopwatch.ElapsedMilliseconds * 0.001f + "  db_ConvertRenderTextureToTexture2D:" + (float)stopwatch2.ElapsedMilliseconds * 0.001f);
		}
		MB_Utility.Destroy(renderTexture);
		return texture2D;
	}
}
internal class MB3_TextureCombinerPackerMeshBakerHorizontalVertical : MB3_TextureCombinerPackerMeshBaker
{
	private interface IPipeline
	{
		MB2_PackingAlgorithmEnum GetPackingAlg();

		void SortTexSetIntoBins(MB_TexSet texSet, List<MB_TexSet> horizontalVert, List<MB_TexSet> regular, int maxAtlasWidth, int maxAtlasHeight);

		MB_TextureTilingTreatment GetEdge2EdgeTreatment();

		void InitializeAtlasPadding(ref AtlasPadding padding, int paddingValue);

		void MergeAtlasPackingResultStackBonAInternal(AtlasPackingResult a, AtlasPackingResult b, out Rect AatlasToFinal, out Rect BatlasToFinal, bool stretchBToAtlasWidth, int maxWidthDim, int maxHeightDim, out int atlasX, out int atlasY);

		void GetExtraRoomForRegularAtlas(int usedHorizontalVertWidth, int usedHorizontalVertHeight, int maxAtlasWidth, int maxAtlasHeight, out int atlasRegularMaxWidth, out int atlasRegularMaxHeight);
	}

	private class VerticalPipeline : IPipeline
	{
		public MB2_PackingAlgorithmEnum GetPackingAlg()
		{
			return MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical;
		}

		public void SortTexSetIntoBins(MB_TexSet texSet, List<MB_TexSet> horizontalVert, List<MB_TexSet> regular, int maxAtlasWidth, int maxAtlasHeight)
		{
			if (texSet.idealHeight_pix >= maxAtlasHeight && texSet.ts[0].GetEncapsulatingSamplingRect().height >= 1.0)
			{
				horizontalVert.Add(texSet);
			}
			else
			{
				regular.Add(texSet);
			}
		}

		public MB_TextureTilingTreatment GetEdge2EdgeTreatment()
		{
			return MB_TextureTilingTreatment.edgeToEdgeY;
		}

		public void InitializeAtlasPadding(ref AtlasPadding padding, int paddingValue)
		{
			padding.topBottom = 0;
			padding.leftRight = paddingValue;
		}

		public void MergeAtlasPackingResultStackBonAInternal(AtlasPackingResult a, AtlasPackingResult b, out Rect AatlasToFinal, out Rect BatlasToFinal, bool stretchBToAtlasWidth, int maxWidthDim, int maxHeightDim, out int atlasX, out int atlasY)
		{
			float num = a.usedW + b.usedW;
			if (num > (float)maxWidthDim)
			{
				float num2 = (float)maxWidthDim / num;
				float num3 = (float)Mathf.FloorToInt((float)a.usedW * num2) / (float)maxWidthDim;
				num2 = num3;
				float width = 1f - num3;
				AatlasToFinal = new Rect(0f, 0f, num2, 1f);
				BatlasToFinal = new Rect(num3, 0f, width, 1f);
			}
			else
			{
				float num4 = (float)a.usedW / num;
				AatlasToFinal = new Rect(0f, 0f, num4, 1f);
				BatlasToFinal = new Rect(num4, 0f, (float)b.usedW / num, 1f);
			}
			if (a.atlasX > b.atlasX)
			{
				if (!stretchBToAtlasWidth)
				{
					BatlasToFinal.width = (float)b.atlasX / (float)a.atlasX;
				}
			}
			else if (b.atlasX > a.atlasX)
			{
				AatlasToFinal.width = (float)a.atlasX / (float)b.atlasX;
			}
			atlasX = a.usedW + b.usedW;
			atlasY = Mathf.Max(a.usedH, b.usedH);
		}

		public void GetExtraRoomForRegularAtlas(int usedHorizontalVertWidth, int usedHorizontalVertHeight, int maxAtlasWidth, int maxAtlasHeight, out int atlasRegularMaxWidth, out int atlasRegularMaxHeight)
		{
			atlasRegularMaxWidth = maxAtlasWidth - usedHorizontalVertWidth;
			atlasRegularMaxHeight = maxAtlasHeight;
		}
	}

	private class HorizontalPipeline : IPipeline
	{
		public MB2_PackingAlgorithmEnum GetPackingAlg()
		{
			return MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal;
		}

		public void SortTexSetIntoBins(MB_TexSet texSet, List<MB_TexSet> horizontalVert, List<MB_TexSet> regular, int maxAtlasWidth, int maxAtlasHeight)
		{
			if (texSet.idealWidth_pix >= maxAtlasWidth && texSet.ts[0].GetEncapsulatingSamplingRect().width >= 1.0)
			{
				horizontalVert.Add(texSet);
			}
			else
			{
				regular.Add(texSet);
			}
		}

		public MB_TextureTilingTreatment GetEdge2EdgeTreatment()
		{
			return MB_TextureTilingTreatment.edgeToEdgeX;
		}

		public void InitializeAtlasPadding(ref AtlasPadding padding, int paddingValue)
		{
			padding.topBottom = paddingValue;
			padding.leftRight = 0;
		}

		public void MergeAtlasPackingResultStackBonAInternal(AtlasPackingResult a, AtlasPackingResult b, out Rect AatlasToFinal, out Rect BatlasToFinal, bool stretchBToAtlasWidth, int maxWidthDim, int maxHeightDim, out int atlasX, out int atlasY)
		{
			float num = a.usedH + b.usedH;
			if (num > (float)maxHeightDim)
			{
				float num2 = (float)maxHeightDim / num;
				float num3 = (float)Mathf.FloorToInt((float)a.usedH * num2) / (float)maxHeightDim;
				num2 = num3;
				float height = 1f - num3;
				AatlasToFinal = new Rect(0f, 0f, 1f, num2);
				BatlasToFinal = new Rect(0f, num3, 1f, height);
			}
			else
			{
				float num4 = (float)a.usedH / num;
				AatlasToFinal = new Rect(0f, 0f, 1f, num4);
				BatlasToFinal = new Rect(0f, num4, 1f, (float)b.usedH / num);
			}
			if (a.atlasX > b.atlasX)
			{
				if (!stretchBToAtlasWidth)
				{
					BatlasToFinal.width = (float)b.atlasX / (float)a.atlasX;
				}
			}
			else if (b.atlasX > a.atlasX)
			{
				AatlasToFinal.width = (float)a.atlasX / (float)b.atlasX;
			}
			atlasX = Mathf.Max(a.usedW, b.usedW);
			atlasY = a.usedH + b.usedH;
		}

		public void GetExtraRoomForRegularAtlas(int usedHorizontalVertWidth, int usedHorizontalVertHeight, int maxAtlasWidth, int maxAtlasHeight, out int atlasRegularMaxWidth, out int atlasRegularMaxHeight)
		{
			atlasRegularMaxWidth = maxAtlasWidth;
			atlasRegularMaxHeight = maxAtlasHeight - usedHorizontalVertHeight;
		}
	}

	public enum AtlasDirection
	{
		horizontal,
		vertical
	}

	private AtlasDirection _atlasDirection;

	public MB3_TextureCombinerPackerMeshBakerHorizontalVertical(AtlasDirection ad)
	{
		_atlasDirection = ad;
	}

	public override AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		IPipeline pipeline = ((_atlasDirection != AtlasDirection.horizontal) ? ((IPipeline)new VerticalPipeline()) : ((IPipeline)new HorizontalPipeline()));
		if (_atlasDirection == AtlasDirection.horizontal)
		{
			if (!data._useMaxAtlasWidthOverride)
			{
				int num = 2;
				for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
				{
					MB_TexSet mB_TexSet = data.distinctMaterialTextures[i];
					int num2 = ((!data._fixOutOfBoundsUVs) ? mB_TexSet.idealWidth_pix : ((int)mB_TexSet.GetMaxRawTextureHeightWidth().x));
					if (mB_TexSet.idealWidth_pix > num)
					{
						num = num2;
					}
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Calculated max atlas width: " + num);
				}
				data._maxAtlasWidth = num;
			}
		}
		else if (!data._useMaxAtlasHeightOverride)
		{
			int num3 = 2;
			for (int j = 0; j < data.distinctMaterialTextures.Count; j++)
			{
				MB_TexSet mB_TexSet2 = data.distinctMaterialTextures[j];
				int num4 = ((!data._fixOutOfBoundsUVs) ? mB_TexSet2.idealHeight_pix : ((int)mB_TexSet2.GetMaxRawTextureHeightWidth().y));
				if (mB_TexSet2.idealHeight_pix > num3)
				{
					num3 = num4;
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Calculated max atlas height: " + num3);
			}
			data._maxAtlasHeight = num3;
		}
		List<MB_TexSet> list = new List<MB_TexSet>();
		List<MB_TexSet> list2 = new List<MB_TexSet>();
		for (int k = 0; k < data.distinctMaterialTextures.Count; k++)
		{
			pipeline.SortTexSetIntoBins(data.distinctMaterialTextures[k], list, list2, data._maxAtlasWidth, data._maxAtlasHeight);
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"Splitting list of distinctMaterialTextures numHorizontalVertical={list.Count} numRegular={list2.Count} maxAtlasWidth={data._maxAtlasWidth} maxAtlasHeight={data._maxAtlasHeight}");
		}
		AtlasPackingResult[] array;
		if (list.Count > 0)
		{
			MB2_PackingAlgorithmEnum packingAlg = pipeline.GetPackingAlg();
			List<Vector2> list3 = new List<Vector2>();
			for (int l = 0; l < list.Count; l++)
			{
				list[l].SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(pipeline.GetEdge2EdgeTreatment());
				list3.Add(new Vector2(list[l].idealWidth_pix, list[l].idealHeight_pix));
			}
			MB2_TexturePacker mB2_TexturePacker = MB3_TextureCombinerPipeline.CreateTexturePacker(packingAlg);
			mB2_TexturePacker.atlasMustBePowerOfTwo = false;
			List<AtlasPadding> list4 = new List<AtlasPadding>();
			for (int m = 0; m < list3.Count; m++)
			{
				AtlasPadding padding = default(AtlasPadding);
				pipeline.InitializeAtlasPadding(ref padding, data._atlasPadding_pix);
				list4.Add(padding);
			}
			mB2_TexturePacker.LOG_LEVEL = MB2_LogLevel.trace;
			array = mB2_TexturePacker.GetRects(list3, list4, data._maxAtlasWidth, data._maxAtlasHeight, doMultiAtlas: false);
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"Packed {list.Count} textures with edgeToEdge tiling into an atlas of size {array[0].atlasX} by {array[0].atlasY} usedW {array[0].usedW} usedH {array[0].usedH}");
			}
		}
		else
		{
			array = new AtlasPackingResult[0];
		}
		AtlasPackingResult[] array2;
		if (list2.Count > 0)
		{
			MB2_PackingAlgorithmEnum packingAlg = MB2_PackingAlgorithmEnum.MeshBakerTexturePacker;
			List<Vector2> list5 = new List<Vector2>();
			for (int n = 0; n < list2.Count; n++)
			{
				list5.Add(new Vector2(list2[n].idealWidth_pix, list2[n].idealHeight_pix));
			}
			MB2_TexturePacker mB2_TexturePacker = MB3_TextureCombinerPipeline.CreateTexturePacker(MB2_PackingAlgorithmEnum.MeshBakerTexturePacker);
			mB2_TexturePacker.atlasMustBePowerOfTwo = false;
			List<AtlasPadding> list6 = new List<AtlasPadding>();
			for (int num5 = 0; num5 < list5.Count; num5++)
			{
				list6.Add(new AtlasPadding
				{
					topBottom = data._atlasPadding_pix,
					leftRight = data._atlasPadding_pix
				});
			}
			int usedHorizontalVertWidth = 0;
			int usedHorizontalVertHeight = 0;
			if (array.Length != 0)
			{
				usedHorizontalVertHeight = array[0].atlasY;
				usedHorizontalVertWidth = array[0].atlasX;
			}
			pipeline.GetExtraRoomForRegularAtlas(usedHorizontalVertWidth, usedHorizontalVertHeight, data._maxAtlasWidth, data._maxAtlasHeight, out var atlasRegularMaxWidth, out var atlasRegularMaxHeight);
			array2 = mB2_TexturePacker.GetRects(list5, list6, atlasRegularMaxWidth, atlasRegularMaxHeight, doMultiAtlas: false);
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log($"Packed {list2.Count} textures without edgeToEdge tiling into an atlas of size {array2[0].atlasX} by {array2[0].atlasY} usedW {array2[0].usedW} usedH {array2[0].usedH}");
			}
		}
		else
		{
			array2 = new AtlasPackingResult[0];
		}
		AtlasPackingResult atlasPackingResult = null;
		if (array.Length == 0 && array2.Length == 0)
		{
			return null;
		}
		if (array.Length != 0 && array2.Length != 0)
		{
			atlasPackingResult = MergeAtlasPackingResultStackBonA(array[0], array2[0], data._maxAtlasWidth, data._maxAtlasHeight, stretchBToAtlasWidth: true, pipeline);
		}
		else if (array.Length != 0)
		{
			atlasPackingResult = array[0];
		}
		else if (array2.Length != 0)
		{
			atlasPackingResult = array2[0];
		}
		list.AddRange(list2);
		data.distinctMaterialTextures = list;
		if (atlasPackingResult != null)
		{
			return new AtlasPackingResult[1] { atlasPackingResult };
		}
		return new AtlasPackingResult[0];
	}

	public static AtlasPackingResult TestStackRectanglesHorizontal(AtlasPackingResult a, AtlasPackingResult b, int maxHeightDim, int maxWidthDim, bool stretchBToAtlasWidth)
	{
		return MergeAtlasPackingResultStackBonA(a, b, maxWidthDim, maxHeightDim, stretchBToAtlasWidth, new HorizontalPipeline());
	}

	public static AtlasPackingResult TestStackRectanglesVertical(AtlasPackingResult a, AtlasPackingResult b, int maxHeightDim, int maxWidthDim, bool stretchBToAtlasWidth)
	{
		return MergeAtlasPackingResultStackBonA(a, b, maxWidthDim, maxHeightDim, stretchBToAtlasWidth, new VerticalPipeline());
	}

	private static AtlasPackingResult MergeAtlasPackingResultStackBonA(AtlasPackingResult a, AtlasPackingResult b, int maxWidthDim, int maxHeightDim, bool stretchBToAtlasWidth, IPipeline pipeline)
	{
		pipeline.MergeAtlasPackingResultStackBonAInternal(a, b, out var AatlasToFinal, out var BatlasToFinal, stretchBToAtlasWidth, maxWidthDim, maxHeightDim, out var atlasX, out var atlasY);
		Rect[] array = new Rect[a.rects.Length + b.rects.Length];
		AtlasPadding[] array2 = new AtlasPadding[a.rects.Length + b.rects.Length];
		int[] array3 = new int[a.rects.Length + b.rects.Length];
		Array.Copy(a.padding, array2, a.padding.Length);
		Array.Copy(b.padding, 0, array2, a.padding.Length, b.padding.Length);
		Array.Copy(a.srcImgIdxs, array3, a.srcImgIdxs.Length);
		Array.Copy(b.srcImgIdxs, 0, array3, a.srcImgIdxs.Length, b.srcImgIdxs.Length);
		Array.Copy(a.rects, array, a.rects.Length);
		for (int i = 0; i < a.rects.Length; i++)
		{
			Rect rect = a.rects[i];
			rect.x = AatlasToFinal.x + rect.x * AatlasToFinal.width;
			rect.y = AatlasToFinal.y + rect.y * AatlasToFinal.height;
			rect.width *= AatlasToFinal.width;
			rect.height *= AatlasToFinal.height;
			array[i] = rect;
			array3[i] = a.srcImgIdxs[i];
		}
		for (int j = 0; j < b.rects.Length; j++)
		{
			Rect rect2 = b.rects[j];
			rect2.x = BatlasToFinal.x + rect2.x * BatlasToFinal.width;
			rect2.y = BatlasToFinal.y + rect2.y * BatlasToFinal.height;
			rect2.width *= BatlasToFinal.width;
			rect2.height *= BatlasToFinal.height;
			array[a.rects.Length + j] = rect2;
			array3[a.rects.Length + j] = b.srcImgIdxs[j];
		}
		AtlasPackingResult atlasPackingResult = new AtlasPackingResult(array2);
		atlasPackingResult.atlasX = atlasX;
		atlasPackingResult.atlasY = atlasY;
		atlasPackingResult.padding = array2;
		atlasPackingResult.rects = array;
		atlasPackingResult.srcImgIdxs = array3;
		atlasPackingResult.CalcUsedWidthAndHeight();
		return atlasPackingResult;
	}
}
internal class MB3_TextureCombinerPackerOneTextureInAtlas : MB_ITextureCombinerPacker
{
	public virtual bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		if (!data.OnlyOneTextureInAtlasReuseTextures())
		{
			UnityEngine.Debug.LogError("There must be only one texture in the atlas to use MB3_TextureCombinerPackerOneTextureInAtlas");
			return false;
		}
		return true;
	}

	public IEnumerator ConvertTexturesToReadableFormats(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		yield break;
	}

	public AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Only one image per atlas. Will re-use original texture");
		}
		AtlasPackingResult[] array = new AtlasPackingResult[1];
		AtlasPadding[] pds = new AtlasPadding[1]
		{
			new AtlasPadding(data._atlasPadding_pix)
		};
		array[0] = new AtlasPackingResult(pds);
		array[0].rects = new Rect[1];
		array[0].srcImgIdxs = new int[1];
		array[0].rects[0] = new Rect(0f, 0f, 1f, 1f);
		MeshBakerMaterialTexture meshBakerMaterialTexture = null;
		if (data.distinctMaterialTextures[0].ts.Length != 0)
		{
			meshBakerMaterialTexture = data.distinctMaterialTextures[0].ts[0];
		}
		if (meshBakerMaterialTexture == null || meshBakerMaterialTexture.isNull)
		{
			array[0].atlasX = 16;
			array[0].atlasY = 16;
			array[0].usedW = 16;
			array[0].usedH = 16;
		}
		else
		{
			array[0].atlasX = meshBakerMaterialTexture.width;
			array[0].atlasY = meshBakerMaterialTexture.height;
			array[0].usedW = meshBakerMaterialTexture.width;
			array[0].usedH = meshBakerMaterialTexture.height;
		}
		return array;
	}

	public IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Only one image per atlas. Will re-use original texture");
		}
		for (int i = 0; i < data.numAtlases; i++)
		{
			MeshBakerMaterialTexture meshBakerMaterialTexture = data.distinctMaterialTextures[0].ts[i];
			atlases[i] = meshBakerMaterialTexture.GetTexture2D();
			if (data.resultType == MB2_TextureBakeResults.ResultType.atlas)
			{
				data.resultMaterial.SetTexture(data.texPropertyNames[i].name, atlases[i]);
				data.resultMaterial.SetTextureScale(data.texPropertyNames[i].name, Vector2.one);
				data.resultMaterial.SetTextureOffset(data.texPropertyNames[i].name, Vector2.zero);
			}
		}
		yield break;
	}
}
internal class MB3_TextureCombinerPackerUnity : MB3_TextureCombinerPackerRoot
{
	public override bool Validate(MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		return true;
	}

	public override AtlasPackingResult[] CalculateAtlasRectangles(MB3_TextureCombinerPipeline.TexturePipelineData data, bool doMultiAtlas, MB2_LogLevel LOG_LEVEL)
	{
		return new AtlasPackingResult[1]
		{
			new AtlasPackingResult(new AtlasPadding[0])
		};
	}

	public override IEnumerator CreateAtlases(ProgressUpdateDelegate progressInfo, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, AtlasPackingResult packedAtlasRects, Texture2D[] atlases, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		long num = 0L;
		int w = 1;
		int h = 1;
		Rect[] array = null;
		for (int i = 0; i < data.numAtlases; i++)
		{
			ShaderTextureProperty shaderTextureProperty = data.texPropertyNames[i];
			Texture2D texture2D;
			if (!MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
			{
				texture2D = null;
			}
			else
			{
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.LogWarning("Beginning loop " + i + " num temporary textures " + combiner._getNumTemporaryTextures());
				}
				MB3_TextureCombinerPackerRoot.CreateTemporaryTexturesForAtlas(data.distinctMaterialTextures, combiner, i, data);
				Texture2D[] array2 = new Texture2D[data.distinctMaterialTextures.Count];
				for (int j = 0; j < data.distinctMaterialTextures.Count; j++)
				{
					MB_TexSet mB_TexSet = data.distinctMaterialTextures[j];
					int idealWidth_pix = mB_TexSet.idealWidth_pix;
					int idealHeight_pix = mB_TexSet.idealHeight_pix;
					Texture2D texture2D2 = mB_TexSet.ts[i].GetTexture2D();
					progressInfo?.Invoke("Adjusting for scale and offset " + texture2D2, 0.01f);
					textureEditorMethods?.SetReadWriteFlag(texture2D2, isReadable: true, addToList: true);
					texture2D2 = GetAdjustedForScaleAndOffset2(shaderTextureProperty, mB_TexSet.ts[i], mB_TexSet.obUVoffset, mB_TexSet.obUVscale, data, combiner, LOG_LEVEL);
					if (texture2D2.width != idealWidth_pix || texture2D2.height != idealHeight_pix)
					{
						progressInfo?.Invoke("Resizing texture '" + texture2D2?.ToString() + "'", 0.01f);
						if (LOG_LEVEL >= MB2_LogLevel.debug)
						{
							UnityEngine.Debug.LogWarning("Copying and resizing texture " + shaderTextureProperty.name + " from " + texture2D2.width + "x" + texture2D2.height + " to " + idealWidth_pix + "x" + idealHeight_pix);
						}
						texture2D2 = combiner._resizeTexture(shaderTextureProperty, texture2D2, idealWidth_pix, idealHeight_pix);
					}
					num += texture2D2.width * texture2D2.height;
					if (data._considerNonTextureProperties)
					{
						texture2D2 = combiner._createTextureCopy(shaderTextureProperty, texture2D2);
						data.nonTexturePropertyBlender.TintTextureWithTextureCombiner(texture2D2, data.distinctMaterialTextures[j], shaderTextureProperty);
					}
					array2[j] = texture2D2;
				}
				textureEditorMethods?.CheckBuildSettings(num);
				if (Math.Sqrt(num) > 6144.0 && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("The maximum possible atlas size is " + 8192 + ". Textures may be shrunk");
				}
				texture2D = new Texture2D(1, 1, TextureFormat.ARGB32, mipChain: true);
				progressInfo?.Invoke("Packing texture atlas " + shaderTextureProperty.name, 0.25f);
				if (i == 0)
				{
					progressInfo?.Invoke("Estimated min size of atlases: " + Math.Sqrt(num).ToString("F0"), 0.1f);
					if (LOG_LEVEL >= MB2_LogLevel.info)
					{
						UnityEngine.Debug.Log("Estimated atlas minimum size:" + Math.Sqrt(num).ToString("F0"));
					}
					array = texture2D.PackTextures(array2, data._atlasPadding_pix, 8192, makeNoLongerReadable: false);
					if (LOG_LEVEL >= MB2_LogLevel.info)
					{
						UnityEngine.Debug.Log("After pack textures atlas numTextures " + array2.Length + " size " + texture2D.width + " " + texture2D.height);
					}
					w = texture2D.width;
					h = texture2D.height;
					texture2D.Apply();
				}
				else
				{
					progressInfo?.Invoke("Copying Textures Into: " + shaderTextureProperty.name, 0.1f);
					texture2D = _copyTexturesIntoAtlas(shaderTextureProperty, array2, data._atlasPadding_pix, array, w, h, combiner);
				}
			}
			atlases[i] = texture2D;
			if (data._saveAtlasesAsAssets && textureEditorMethods != null)
			{
				MB3_TextureCombinerPackerRoot.SaveAtlasAndConfigureResultMaterial(data, textureEditorMethods, atlases[i], data.texPropertyNames[i], i);
			}
			data.resultMaterial.SetTextureOffset(shaderTextureProperty.name, Vector2.zero);
			data.resultMaterial.SetTextureScale(shaderTextureProperty.name, Vector2.one);
			combiner._destroyTemporaryTextures(shaderTextureProperty.name);
			GC.Collect();
		}
		packedAtlasRects.rects = array;
		yield break;
	}

	internal static Texture2D _copyTexturesIntoAtlas(ShaderTextureProperty prop, Texture2D[] texToPack, int padding, Rect[] rs, int w, int h, MB3_TextureCombiner combiner)
	{
		Texture2D texture2D = new Texture2D(w, h, TextureFormat.ARGB32, mipChain: true);
		MB_Utility.setSolidColor(texture2D, Color.clear);
		for (int i = 0; i < rs.Length; i++)
		{
			Rect rect = rs[i];
			Texture2D texture2D2 = texToPack[i];
			Texture2D texture2D3 = null;
			int x = Mathf.RoundToInt(rect.x * (float)w);
			int y = Mathf.RoundToInt(rect.y * (float)h);
			int num = Mathf.RoundToInt(rect.width * (float)w);
			int num2 = Mathf.RoundToInt(rect.height * (float)h);
			if (texture2D2.width != num && texture2D2.height != num2)
			{
				texture2D3 = (texture2D2 = MB_Utility.resampleTexture(texture2D2, prop.isGammaCorrected, num, num2));
			}
			texture2D.SetPixels(x, y, num, num2, texture2D2.GetPixels());
			if (texture2D3 != null)
			{
				MB_Utility.Destroy(texture2D3);
			}
		}
		texture2D.Apply();
		return texture2D;
	}

	internal static Texture2D GetAdjustedForScaleAndOffset2(ShaderTextureProperty propertyName, MeshBakerMaterialTexture source, Vector2 obUVoffset, Vector2 obUVscale, MB3_TextureCombinerPipeline.TexturePipelineData data, MB3_TextureCombiner combiner, MB2_LogLevel LOG_LEVEL)
	{
		Texture2D texture2D = source.GetTexture2D();
		if (source.matTilingRect.x == 0.0 && source.matTilingRect.y == 0.0 && source.matTilingRect.width == 1.0 && source.matTilingRect.height == 1.0)
		{
			if (!data._fixOutOfBoundsUVs)
			{
				return texture2D;
			}
			if (obUVoffset.x == 0f && obUVoffset.y == 0f && obUVscale.x == 1f && obUVscale.y == 1f)
			{
				return texture2D;
			}
		}
		Vector2 adjustedForScaleAndOffset2Dimensions = MB3_TextureCombinerPipeline.GetAdjustedForScaleAndOffset2Dimensions(source, obUVoffset, obUVscale, data, LOG_LEVEL);
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			string[] obj = new string[6]
			{
				"GetAdjustedForScaleAndOffset2: ",
				texture2D?.ToString(),
				" ",
				null,
				null,
				null
			};
			Vector2 vector = obUVoffset;
			obj[3] = vector.ToString();
			obj[4] = " ";
			vector = obUVscale;
			obj[5] = vector.ToString();
			UnityEngine.Debug.LogWarning(string.Concat(obj));
		}
		float x = adjustedForScaleAndOffset2Dimensions.x;
		float y = adjustedForScaleAndOffset2Dimensions.y;
		float num = (float)source.matTilingRect.width;
		float num2 = (float)source.matTilingRect.height;
		float num3 = (float)source.matTilingRect.x;
		float num4 = (float)source.matTilingRect.y;
		if (data._fixOutOfBoundsUVs)
		{
			num *= obUVscale.x;
			num2 *= obUVscale.y;
			num3 = (float)(source.matTilingRect.x * (double)obUVscale.x + (double)obUVoffset.x);
			num4 = (float)(source.matTilingRect.y * (double)obUVscale.y + (double)obUVoffset.y);
		}
		Texture2D texture2D2 = combiner._createTemporaryTexture(propertyName.name, (int)x, (int)y, TextureFormat.ARGB32, mipMaps: true, MB3_TextureCombiner.ShouldTextureBeLinear(propertyName));
		for (int i = 0; i < texture2D2.width; i++)
		{
			for (int j = 0; j < texture2D2.height; j++)
			{
				float u = (float)i / x * num + num3;
				float v = (float)j / y * num2 + num4;
				texture2D2.SetPixel(i, j, texture2D.GetPixelBilinear(u, v));
			}
		}
		texture2D2.Apply();
		return texture2D2;
	}
}
public class MB3_TextureCombinerPipeline
{
	public struct CreateAtlasForProperty
	{
		public bool allTexturesAreNull;

		public bool allTexturesAreSame;

		public bool allNonTexturePropsAreSame;

		public bool allSrcMatsOmittedTextureProperty;

		public override string ToString()
		{
			return $"AllTexturesNull={allTexturesAreNull} areSame={allTexturesAreSame} nonTexPropsAreSame={allNonTexturePropsAreSame} allSrcMatsOmittedTextureProperty={allSrcMatsOmittedTextureProperty}";
		}
	}

	internal class TexturePipelineData
	{
		internal MB2_TextureBakeResults _textureBakeResults;

		internal int _atlasPadding_pix = 1;

		internal int _maxAtlasWidth = 1;

		internal int _maxAtlasHeight = 1;

		internal bool _useMaxAtlasHeightOverride;

		internal bool _useMaxAtlasWidthOverride;

		internal bool _resizePowerOfTwoTextures;

		internal bool _fixOutOfBoundsUVs;

		internal int _maxTilingBakeSize = 1024;

		internal bool _saveAtlasesAsAssets;

		internal MB2_PackingAlgorithmEnum _packingAlgorithm;

		internal int _layerTexturePackerFastV2 = -1;

		internal bool _meshBakerTexturePackerForcePowerOfTwo = true;

		internal List<ShaderTextureProperty> _customShaderPropNames = new List<ShaderTextureProperty>();

		internal bool _normalizeTexelDensity;

		internal bool _considerNonTextureProperties;

		internal bool doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize;

		internal ColorSpace colorSpace;

		internal MB3_TextureCombinerNonTextureProperties nonTexturePropertyBlender;

		internal List<MB_TexSet> distinctMaterialTextures;

		internal List<GameObject> allObjsToMesh;

		internal List<Material> allowedMaterialsFilter;

		internal List<ShaderTextureProperty> texPropertyNames;

		internal List<string> texPropNamesToIgnore;

		internal CreateAtlasForProperty[] allTexturesAreNullAndSameColor;

		internal MB2_TextureBakeResults.ResultType resultType;

		internal Material resultMaterial;

		internal int numAtlases
		{
			get
			{
				if (texPropertyNames != null)
				{
					return texPropertyNames.Count;
				}
				return 0;
			}
		}

		internal bool OnlyOneTextureInAtlasReuseTextures()
		{
			if (distinctMaterialTextures != null && distinctMaterialTextures.Count == 1 && distinctMaterialTextures[0].thisIsOnlyTexSetInAtlas && !_fixOutOfBoundsUVs && !_considerNonTextureProperties)
			{
				return true;
			}
			return false;
		}
	}

	public static bool USE_EXPERIMENTAL_HOIZONTALVERTICAL = true;

	public static ShaderTextureProperty[] shaderTexPropertyNames = new ShaderTextureProperty[34]
	{
		new ShaderTextureProperty("_MainTex", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_BaseMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_BaseColorMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_BumpMap", norm: true, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_Normal", norm: true, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_NormalMap", norm: true, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_BumpSpecMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_DecalTex", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_MaskMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_BentNormalMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_TangentMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_AnisotropyMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_SubsurfaceMaskMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_ThicknessMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_IridescenceThicknessMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_IridescenceMaskMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_SpecularColorMap", norm: false, isGamma: true, isNormalDontKnow: true),
		new ShaderTextureProperty("_EmissiveColorMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_DistortionVectorMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_TransmittanceColorMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_Detail", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_GlossMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_Illum", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_LightTextureB0", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_ParallaxMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_ShadowOffset", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_TranslucencyMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_SpecMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_SpecGlossMap", norm: false, isGamma: false, isNormalDontKnow: false),
		new ShaderTextureProperty("_TranspMap", norm: false, isGamma: false, isNormalDontKnow: true),
		new ShaderTextureProperty("_MetallicGlossMap", norm: false, isGamma: false, isNormalDontKnow: true),
		new ShaderTextureProperty("_OcclusionMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_EmissionMap", norm: false, isGamma: true, isNormalDontKnow: false),
		new ShaderTextureProperty("_DetailMask", norm: false, isGamma: false, isNormalDontKnow: false)
	};

	internal static bool _ShouldWeCreateAtlasForThisProperty(int propertyIndex, bool considerNonTextureProperties, CreateAtlasForProperty[] allTexturesAreNullAndSameColor)
	{
		CreateAtlasForProperty createAtlasForProperty = allTexturesAreNullAndSameColor[propertyIndex];
		if (considerNonTextureProperties)
		{
			if (!createAtlasForProperty.allNonTexturePropsAreSame || !createAtlasForProperty.allTexturesAreNull)
			{
				return true;
			}
			return false;
		}
		if (!createAtlasForProperty.allTexturesAreNull)
		{
			return true;
		}
		return false;
	}

	internal static bool _DoAnySrcMatsHaveProperty(int propertyIndex, CreateAtlasForProperty[] allTexturesAreNullAndSameColor)
	{
		return !allTexturesAreNullAndSameColor[propertyIndex].allSrcMatsOmittedTextureProperty;
	}

	internal static bool _CollectPropertyNames(TexturePipelineData data, MB2_LogLevel LOG_LEVEL)
	{
		return _CollectPropertyNames(data.texPropertyNames, data._customShaderPropNames, data.texPropNamesToIgnore, data.resultMaterial, LOG_LEVEL);
	}

	internal static bool _CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, List<string> texPropsToIgnore, Material resultMaterial, MB2_LogLevel LOG_LEVEL)
	{
		int i;
		for (i = 0; i < texPropertyNames.Count; i++)
		{
			ShaderTextureProperty shaderTextureProperty = _customShaderPropNames.Find((ShaderTextureProperty x) => x.name.Equals(texPropertyNames[i].name));
			if (shaderTextureProperty != null)
			{
				_customShaderPropNames.Remove(shaderTextureProperty);
			}
		}
		if (resultMaterial == null)
		{
			UnityEngine.Debug.LogError("Please assign a result material. The combined mesh will use this material.");
			return false;
		}
		MBVersion.CollectPropertyNames(texPropertyNames, shaderTexPropertyNames, _customShaderPropNames, resultMaterial, LOG_LEVEL);
		for (int num = texPropertyNames.Count - 1; num >= 0; num--)
		{
			for (int num2 = 0; num2 < texPropsToIgnore.Count; num2++)
			{
				if (texPropsToIgnore[num2].Equals(texPropertyNames[num].name))
				{
					texPropertyNames.RemoveAt(num);
				}
			}
		}
		return true;
	}

	public static Texture GetTextureConsideringStandardShaderKeywords(string shaderName, Material mat, string propertyName)
	{
		if ((shaderName.Equals("Standard") || shaderName.Equals("Standard (Specular setup)") || shaderName.Equals("Standard (Roughness setup")) && propertyName.Equals("_EmissionMap"))
		{
			if (mat.IsKeywordEnabled("_EMISSION"))
			{
				return mat.GetTexture(propertyName);
			}
			return null;
		}
		return mat.GetTexture(propertyName);
	}

	internal virtual IEnumerator __Step1_CollectDistinctMatTexturesAndUsedObjects(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, List<GameObject> usedObjsToMesh, MB2_LogLevel LOG_LEVEL)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		bool flag = false;
		Dictionary<int, MB_Utility.MeshAnalysisResult[]> dictionary = new Dictionary<int, MB_Utility.MeshAnalysisResult[]>();
		for (int i = 0; i < data.allObjsToMesh.Count; i++)
		{
			GameObject gameObject = data.allObjsToMesh[i];
			progressInfo?.Invoke("Collecting textures for " + gameObject, (float)i / (float)data.allObjsToMesh.Count / 2f);
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Collecting textures for object " + gameObject);
			}
			if (gameObject == null)
			{
				UnityEngine.Debug.LogError("The list of objects to mesh contained nulls.");
				result.success = false;
				yield break;
			}
			Mesh mesh = MB_Utility.GetMesh(gameObject);
			if (mesh == null)
			{
				UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects to mesh has no mesh.");
				result.success = false;
				yield break;
			}
			Material[] gOMaterials = MB_Utility.GetGOMaterials(gameObject);
			if (gOMaterials.Length == 0)
			{
				UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects has no materials.");
				result.success = false;
				yield break;
			}
			if (!dictionary.TryGetValue(mesh.GetInstanceID(), out var value))
			{
				value = new MB_Utility.MeshAnalysisResult[mesh.subMeshCount];
				for (int j = 0; j < mesh.subMeshCount; j++)
				{
					MB_Utility.hasOutOfBoundsUVs(mesh, ref value[j], j);
					if (data._normalizeTexelDensity)
					{
						value[j].submeshArea = GetSubmeshArea(mesh, j);
					}
					if (data._fixOutOfBoundsUVs && !value[j].hasUVs)
					{
						value[j].uvRect = new Rect(0f, 0f, 1f, 1f);
						UnityEngine.Debug.LogWarning("Mesh for object " + gameObject?.ToString() + " has no UV channel but 'consider UVs' is enabled. Assuming UVs will be generated filling 0,0,1,1 rectangle.");
					}
				}
				dictionary.Add(mesh.GetInstanceID(), value);
			}
			if (data._fixOutOfBoundsUVs && LOG_LEVEL >= MB2_LogLevel.trace)
			{
				string[] obj = new string[8]
				{
					"Mesh Analysis for object ",
					gameObject?.ToString(),
					" numSubmesh=",
					value.Length.ToString(),
					" HasOBUV=",
					value[0].hasOutOfBoundsUVs.ToString(),
					" UVrectSubmesh0=",
					null
				};
				Rect uvRect = value[0].uvRect;
				obj[7] = uvRect.ToString();
				UnityEngine.Debug.Log(string.Concat(obj));
			}
			for (int k = 0; k < gOMaterials.Length; k++)
			{
				progressInfo?.Invoke($"Collecting textures for {gameObject} submesh {k}", (float)i / (float)data.allObjsToMesh.Count / 2f);
				Material material = gOMaterials[k];
				if (data.allowedMaterialsFilter != null && !data.allowedMaterialsFilter.Contains(material))
				{
					continue;
				}
				flag = flag || value[k].hasOutOfBoundsUVs;
				if (material.name.Contains("(Instance)"))
				{
					UnityEngine.Debug.LogWarning("The sharedMaterial on object " + gameObject.name + " has been 'Instanced'. This was probably caused by a script accessing the meshRender.material property in the editor.  The material to UV Rectangle mapping may be incorrect. To fix this recreate the object from its prefab or re-assign its material from the correct asset.");
				}
				if (data._fixOutOfBoundsUVs && !MB_Utility.AreAllSharedMaterialsDistinct(gOMaterials) && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Object " + gameObject.name + " uses the same material on multiple submeshes. This may generate strange resultAtlasesAndRects especially when used with Consider Mesh UVs. Try duplicating the material.");
				}
				MeshBakerMaterialTexture[] array = new MeshBakerMaterialTexture[data.texPropertyNames.Count];
				for (int l = 0; l < data.texPropertyNames.Count; l++)
				{
					Texture texture = null;
					Vector2 scale = Vector2.one;
					Vector2 offset = Vector2.zero;
					float texelDens = 0f;
					int isImportedAsNormalMap = 0;
					if (material.HasProperty(data.texPropertyNames[l].name))
					{
						Texture textureConsideringStandardShaderKeywords = GetTextureConsideringStandardShaderKeywords(data.resultMaterial.shader.name, material, data.texPropertyNames[l].name);
						if (textureConsideringStandardShaderKeywords != null)
						{
							if (!(textureConsideringStandardShaderKeywords is Texture2D))
							{
								UnityEngine.Debug.LogError("Object '" + gameObject.name + "' in the list of objects to mesh uses a Texture that is not a Texture2D. Cannot build atlases with this object.");
								result.success = false;
								yield break;
							}
							texture = textureConsideringStandardShaderKeywords;
							TextureFormat format = ((Texture2D)texture).format;
							bool flag2 = false;
							if (!Application.isPlaying && textureEditorMethods != null)
							{
								flag2 = textureEditorMethods.IsNormalMap((Texture2D)texture);
								isImportedAsNormalMap = ((!flag2) ? 1 : (-1));
							}
							if ((format != TextureFormat.ARGB32 && format != TextureFormat.RGBA32 && format != TextureFormat.BGRA32 && format != TextureFormat.RGB24 && format != TextureFormat.Alpha8) || flag2)
							{
								if (Application.isPlaying && data.resultType == MB2_TextureBakeResults.ResultType.atlas && data._packingAlgorithm != MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Fast && data._packingAlgorithm != MB2_PackingAlgorithmEnum.MeshBakerTexturePaker_Fast_V2_Beta)
								{
									UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects to mesh uses Texture " + texture.name + " uses format " + format.ToString() + " that is not in: ARGB32, RGBA32, BGRA32, RGB24, Alpha8 or DXT. These textures cannot be resized at runtime. Try changing texture format. If format says 'compressed' try changing it to 'truecolor'");
									result.success = false;
									yield break;
								}
								texture = (Texture2D)material.GetTexture(data.texPropertyNames[l].name);
							}
						}
						if (texture != null && data._normalizeTexelDensity)
						{
							texelDens = ((value[l].submeshArea != 0f) ? ((float)(texture.width * texture.height) / value[l].submeshArea) : 0f);
						}
						GetMaterialScaleAndOffset(material, data.texPropertyNames[l].name, out offset, out scale);
					}
					array[l] = new MeshBakerMaterialTexture(texture, offset, scale, texelDens, isImportedAsNormalMap);
				}
				data.nonTexturePropertyBlender.CollectAverageValuesOfNonTextureProperties(data.resultMaterial, material);
				Vector2 vector = new Vector2(value[k].uvRect.width, value[k].uvRect.height);
				Vector2 vector2 = new Vector2(value[k].uvRect.x, value[k].uvRect.y);
				MB_TextureTilingTreatment treatment = MB_TextureTilingTreatment.none;
				if (data._fixOutOfBoundsUVs)
				{
					treatment = MB_TextureTilingTreatment.considerUVs;
				}
				MB_TexSet setOfTexs = new MB_TexSet(array, vector2, vector, treatment);
				MatAndTransformToMerged item = new MatAndTransformToMerged(new DRect(vector2, vector), data._fixOutOfBoundsUVs, material);
				setOfTexs.matsAndGOs.mats.Add(item);
				MB_TexSet mB_TexSet = data.distinctMaterialTextures.Find((MB_TexSet x) => x.IsEqual(setOfTexs, data._fixOutOfBoundsUVs, data.nonTexturePropertyBlender));
				if (mB_TexSet != null)
				{
					setOfTexs = mB_TexSet;
				}
				else
				{
					data.distinctMaterialTextures.Add(setOfTexs);
				}
				if (!setOfTexs.matsAndGOs.mats.Contains(item))
				{
					setOfTexs.matsAndGOs.mats.Add(item);
				}
				if (!setOfTexs.matsAndGOs.gos.Contains(gameObject))
				{
					setOfTexs.matsAndGOs.gos.Add(gameObject);
					if (!usedObjsToMesh.Contains(gameObject))
					{
						usedObjsToMesh.Add(gameObject);
					}
				}
			}
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log($"Step1_CollectDistinctTextures collected {data.distinctMaterialTextures.Count} sets of textures fixOutOfBoundsUV={data._fixOutOfBoundsUVs} considerNonTextureProperties={data._considerNonTextureProperties}");
		}
		if (data.distinctMaterialTextures.Count == 0)
		{
			string[] array2 = new string[data.allowedMaterialsFilter.Count];
			for (int num = 0; num < array2.Length; num++)
			{
				array2[num] = data.allowedMaterialsFilter[num].name;
			}
			string text = string.Join(", ", array2);
			UnityEngine.Debug.LogError("None of the materials on the objects to combine matched any of the allowed materials for submesh with result material: " + data.resultMaterial?.ToString() + " allowedMaterials: " + text + ". Do any of the source objects use the allowed materials?");
			result.success = false;
			yield break;
		}
		MB3_TextureCombinerMerging mB3_TextureCombinerMerging = new MB3_TextureCombinerMerging(data._considerNonTextureProperties, data.nonTexturePropertyBlender, data._fixOutOfBoundsUVs, LOG_LEVEL);
		mB3_TextureCombinerMerging.MergeOverlappingDistinctMaterialTexturesAndCalcMaterialSubrects(data.distinctMaterialTextures);
		if (data.doMergeDistinctMaterialTexturesThatWouldExceedAtlasSize)
		{
			mB3_TextureCombinerMerging.MergeDistinctMaterialTexturesThatWouldExceedMaxAtlasSizeAndCalcMaterialSubrects(data.distinctMaterialTextures, Mathf.Max(data._maxAtlasHeight, data._maxAtlasWidth));
		}
		for (int num2 = 0; num2 < data.texPropertyNames.Count; num2++)
		{
			ShaderTextureProperty shaderTextureProperty = data.texPropertyNames[num2];
			if (shaderTextureProperty.isNormalDontKnow)
			{
				int num3 = 0;
				for (int num4 = 0; num4 < data.distinctMaterialTextures.Count; num4++)
				{
					MeshBakerMaterialTexture meshBakerMaterialTexture = data.distinctMaterialTextures[num4].ts[num2];
					num3 += meshBakerMaterialTexture.isImportedAsNormalMap;
				}
				shaderTextureProperty.isNormalMap = num3 < 0;
				shaderTextureProperty.isNormalDontKnow = false;
			}
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Total time Step1_CollectDistinctTextures " + stopwatch.ElapsedMilliseconds.ToString("f5"));
		}
	}

	private static CreateAtlasForProperty[] CalculateAllTexturesAreNullAndSameColor(TexturePipelineData data, MB2_LogLevel LOG_LEVEL)
	{
		CreateAtlasForProperty[] array = new CreateAtlasForProperty[data.texPropertyNames.Count];
		for (int i = 0; i < data.texPropertyNames.Count; i++)
		{
			MeshBakerMaterialTexture meshBakerMaterialTexture = data.distinctMaterialTextures[0].ts[i];
			Color color = Color.black;
			if (data._considerNonTextureProperties)
			{
				color = data.nonTexturePropertyBlender.GetColorAsItWouldAppearInAtlasIfNoTexture(data.distinctMaterialTextures[0].matsAndGOs.mats[0].mat, data.texPropertyNames[i]);
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			bool flag = true;
			for (int j = 0; j < data.distinctMaterialTextures.Count; j++)
			{
				MB_TexSet mB_TexSet = data.distinctMaterialTextures[j];
				if (!mB_TexSet.ts[i].isNull)
				{
					num++;
				}
				if (meshBakerMaterialTexture.AreTexturesEqual(mB_TexSet.ts[i]))
				{
					num2++;
				}
				if (data._considerNonTextureProperties && data.nonTexturePropertyBlender.GetColorAsItWouldAppearInAtlasIfNoTexture(mB_TexSet.matsAndGOs.mats[0].mat, data.texPropertyNames[i]) == color)
				{
					num3++;
				}
				for (int k = 0; k < mB_TexSet.matsAndGOs.mats.Count; k++)
				{
					flag = !mB_TexSet.matsAndGOs.mats[k].mat.HasProperty(data.texPropertyNames[i].name);
				}
			}
			array[i].allTexturesAreNull = num == 0;
			array[i].allTexturesAreSame = num2 == data.distinctMaterialTextures.Count;
			array[i].allNonTexturePropsAreSame = num3 == data.distinctMaterialTextures.Count;
			array[i].allSrcMatsOmittedTextureProperty |= flag;
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log($"AllTexturesAreNullAndSameColor prop: {data.texPropertyNames[i].name} createAtlas:{_ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, array)}  val:{array[i]}");
			}
		}
		return array;
	}

	internal virtual IEnumerator CalculateIdealSizesForTexturesInAtlasAndPadding(ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, TexturePipelineData data, MB3_TextureCombiner combiner, MB2_EditorMethodsInterface textureEditorMethods, MB2_LogLevel LOG_LEVEL)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		MeshBakerMaterialTexture.readyToBuildAtlases = true;
		data.allTexturesAreNullAndSameColor = CalculateAllTexturesAreNullAndSameColor(data, LOG_LEVEL);
		if (MB3_MeshCombiner.EVAL_VERSION)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < data.allTexturesAreNullAndSameColor.Length; i++)
			{
				if (_ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					if ((data.texPropertyNames[i].name.Equals("_Albedo") || data.texPropertyNames[i].name.Equals("_MainTex") || data.texPropertyNames[i].name.Equals("_BaseMap") || data.texPropertyNames[i].name.Equals("_BaseColorMap")) && list.Count < 2)
					{
						list.Add(i);
					}
					if ((data.texPropertyNames[i].name.Equals("_BumpMap") || data.texPropertyNames[i].name.Equals("_Normal") || data.texPropertyNames[i].name.Equals("_NormalMap") || data.texPropertyNames[i].name.Equals("_BentNormalMap")) && list.Count < 2)
					{
						list.Add(i);
					}
				}
			}
			List<string> list2 = new List<string>();
			List<int> list3 = new List<int>();
			for (int j = 0; j < data.allTexturesAreNullAndSameColor.Length; j++)
			{
				if (_ShouldWeCreateAtlasForThisProperty(j, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor) && list.Count >= 2 && !list.Contains(j))
				{
					list2.Add(data.texPropertyNames[j].name);
					list3.Add(j);
				}
			}
			for (int k = 0; k < list3.Count; k++)
			{
				data.allTexturesAreNullAndSameColor[list3[k]].allTexturesAreNull = true;
				data.allTexturesAreNullAndSameColor[list3[k]].allTexturesAreSame = true;
				data.allTexturesAreNullAndSameColor[list3[k]].allNonTexturePropsAreSame = true;
			}
			if (list2.Count > 0)
			{
				UnityEngine.Debug.LogError("The free version of Mesh Baker will generate a maximum of two atlases per combined material. The source materials had more than two properties with textures. Atlases will not be generated for: " + string.Join(",", list2.ToArray()));
			}
		}
		int num = data._atlasPadding_pix;
		if (data.distinctMaterialTextures.Count == 1 && !data._fixOutOfBoundsUVs && !data._considerNonTextureProperties)
		{
			if (LOG_LEVEL >= MB2_LogLevel.info)
			{
				UnityEngine.Debug.Log("All objects use the same textures in this set of atlases. Original textures will be reused instead of creating atlases.");
			}
			num = 0;
			data.distinctMaterialTextures[0].SetThisIsOnlyTexSetInAtlasTrue();
			data.distinctMaterialTextures[0].SetTilingTreatmentAndAdjustEncapsulatingSamplingRect(MB_TextureTilingTreatment.edgeToEdgeXY);
		}
		for (int l = 0; l < data.distinctMaterialTextures.Count; l++)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				UnityEngine.Debug.Log("Calculating ideal sizes for texSet TexSet " + l + " of " + data.distinctMaterialTextures.Count);
			}
			MB_TexSet mB_TexSet = data.distinctMaterialTextures[l];
			mB_TexSet.idealWidth_pix = 1;
			mB_TexSet.idealHeight_pix = 1;
			int num2 = 1;
			int num3 = 1;
			for (int m = 0; m < data.texPropertyNames.Count; m++)
			{
				if (!_ShouldWeCreateAtlasForThisProperty(m, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					continue;
				}
				MeshBakerMaterialTexture meshBakerMaterialTexture = mB_TexSet.ts[m];
				if (LOG_LEVEL >= MB2_LogLevel.trace)
				{
					UnityEngine.Debug.Log($"Calculating ideal size for texSet {l} property {data.texPropertyNames[m].name}");
				}
				if (!meshBakerMaterialTexture.matTilingRect.size.Equals(Vector2.one) && data.distinctMaterialTextures.Count > 1 && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Texture " + meshBakerMaterialTexture.GetTexName() + "is tiled by " + meshBakerMaterialTexture.matTilingRect.size.ToString() + " tiling will be baked into a texture with maxSize:" + data._maxTilingBakeSize);
				}
				if (!mB_TexSet.obUVscale.Equals(Vector2.one) && data.distinctMaterialTextures.Count > 1 && data._fixOutOfBoundsUVs && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Texture " + meshBakerMaterialTexture.GetTexName() + " has out of bounds UVs that effectively tile by " + mB_TexSet.obUVscale.ToString() + " tiling will be baked into a texture with maxSize:" + data._maxTilingBakeSize);
				}
				if (meshBakerMaterialTexture.isNull)
				{
					Vector2 adjustedForScaleAndOffset2Dimensions = GetAdjustedForScaleAndOffset2Dimensions(meshBakerMaterialTexture, mB_TexSet.obUVoffset, mB_TexSet.obUVscale, data, LOG_LEVEL);
					if ((int)(adjustedForScaleAndOffset2Dimensions.x * adjustedForScaleAndOffset2Dimensions.y) > num2 * num3)
					{
						if (LOG_LEVEL >= MB2_LogLevel.trace)
						{
							string[] obj = new string[8]
							{
								"    matTex ",
								meshBakerMaterialTexture.GetTexName(),
								" ",
								null,
								null,
								null,
								null,
								null
							};
							Vector2 vector = adjustedForScaleAndOffset2Dimensions;
							obj[3] = vector.ToString();
							obj[4] = " has a bigger size than ";
							obj[5] = num2.ToString();
							obj[6] = " ";
							obj[7] = num3.ToString();
							UnityEngine.Debug.Log(string.Concat(obj));
						}
						num2 = (int)adjustedForScaleAndOffset2Dimensions.x;
						num3 = (int)adjustedForScaleAndOffset2Dimensions.y;
					}
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log($"No source texture creating a 16x16 texture for {data.texPropertyNames[m].name} texSet {l} srcMat {mB_TexSet.matsAndGOs.mats[0].GetMaterialName()}");
					}
				}
				if (meshBakerMaterialTexture.isNull)
				{
					continue;
				}
				Vector2 adjustedForScaleAndOffset2Dimensions2 = GetAdjustedForScaleAndOffset2Dimensions(meshBakerMaterialTexture, mB_TexSet.obUVoffset, mB_TexSet.obUVscale, data, LOG_LEVEL);
				if ((int)(adjustedForScaleAndOffset2Dimensions2.x * adjustedForScaleAndOffset2Dimensions2.y) > num2 * num3)
				{
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						string[] obj2 = new string[8]
						{
							"    matTex ",
							meshBakerMaterialTexture.GetTexName(),
							" ",
							null,
							null,
							null,
							null,
							null
						};
						Vector2 vector = adjustedForScaleAndOffset2Dimensions2;
						obj2[3] = vector.ToString();
						obj2[4] = " has a bigger size than ";
						obj2[5] = num2.ToString();
						obj2[6] = " ";
						obj2[7] = num3.ToString();
						UnityEngine.Debug.Log(string.Concat(obj2));
					}
					num2 = (int)adjustedForScaleAndOffset2Dimensions2.x;
					num3 = (int)adjustedForScaleAndOffset2Dimensions2.y;
				}
			}
			if (data._resizePowerOfTwoTextures)
			{
				if (num2 <= num * 5)
				{
					UnityEngine.Debug.LogWarning(string.Format("Some of the textures have widths close to the size of the padding. It is not recommended to use _resizePowerOfTwoTextures with widths this small.", mB_TexSet.ToString()));
				}
				if (num3 <= num * 5)
				{
					UnityEngine.Debug.LogWarning(string.Format("Some of the textures have heights close to the size of the padding. It is not recommended to use _resizePowerOfTwoTextures with heights this small.", mB_TexSet.ToString()));
				}
				if (IsPowerOfTwo(num2))
				{
					num2 -= num * 2;
				}
				if (IsPowerOfTwo(num3))
				{
					num3 -= num * 2;
				}
				if (num2 < 1)
				{
					num2 = 1;
				}
				if (num3 < 1)
				{
					num3 = 1;
				}
			}
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log("    Ideal size is " + num2 + " " + num3);
			}
			mB_TexSet.idealWidth_pix = num2;
			mB_TexSet.idealHeight_pix = num3;
		}
		data._atlasPadding_pix = num;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Total time Step2 Calculate Ideal Sizes part1: " + stopwatch.Elapsed);
		}
		yield break;
	}

	internal virtual AtlasPackingResult[] RunTexturePackerOnly(TexturePipelineData data, bool doSplitIntoMultiAtlasIfTooBig, MB_AtlasesAndRects resultAtlasesAndRects, MB_ITextureCombinerPacker texturePacker, MB2_LogLevel LOG_LEVEL)
	{
		AtlasPackingResult[] array = texturePacker.CalculateAtlasRectangles(data, doSplitIntoMultiAtlasIfTooBig, LOG_LEVEL);
		FillAtlasPackingResultAuxillaryData(data, array);
		Texture2D[] atlases = new Texture2D[data.texPropertyNames.Count];
		if (!doSplitIntoMultiAtlasIfTooBig)
		{
			FillResultAtlasesAndRects(data, array[0], resultAtlasesAndRects, atlases);
		}
		return array;
	}

	internal virtual MB_ITextureCombinerPacker CreatePacker(bool onlyOneTextureInAtlasReuseTextures, MB2_PackingAlgorithmEnum packingAlgorithm)
	{
		if (onlyOneTextureInAtlasReuseTextures)
		{
			return new MB3_TextureCombinerPackerOneTextureInAtlas();
		}
		switch (packingAlgorithm)
		{
		case MB2_PackingAlgorithmEnum.UnitysPackTextures:
			return new MB3_TextureCombinerPackerUnity();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal:
			if (USE_EXPERIMENTAL_HOIZONTALVERTICAL)
			{
				return new MB3_TextureCombinerPackerMeshBakerHorizontalVertical(MB3_TextureCombinerPackerMeshBakerHorizontalVertical.AtlasDirection.horizontal);
			}
			return new MB3_TextureCombinerPackerMeshBaker();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical:
			if (USE_EXPERIMENTAL_HOIZONTALVERTICAL)
			{
				return new MB3_TextureCombinerPackerMeshBakerHorizontalVertical(MB3_TextureCombinerPackerMeshBakerHorizontalVertical.AtlasDirection.vertical);
			}
			return new MB3_TextureCombinerPackerMeshBaker();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker:
			return new MB3_TextureCombinerPackerMeshBaker();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePaker_Fast_V2_Beta:
			return new MB3_TextureCombinerPackerMeshBakerFastV2();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Fast:
			return new MB3_TextureCombinerPackerMeshBakerFast();
		default:
			UnityEngine.Debug.LogError("Unknown texture packer type. " + packingAlgorithm.ToString() + " This should never happen.");
			return null;
		}
	}

	internal virtual IEnumerator __Step3_BuildAndSaveAtlasesAndStoreResults(MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult result, ProgressUpdateDelegate progressInfo, TexturePipelineData data, MB3_TextureCombiner combiner, MB_ITextureCombinerPacker packer, AtlasPackingResult atlasPackingResult, MB2_EditorMethodsInterface textureEditorMethods, MB_AtlasesAndRects resultAtlasesAndRects, StringBuilder report, MB2_LogLevel LOG_LEVEL)
	{
		Stopwatch sw = new Stopwatch();
		sw.Start();
		GC.Collect();
		Texture2D[] atlases = new Texture2D[data.numAtlases];
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("time Step 3 Create And Save Atlases part 1 " + sw.Elapsed);
		}
		MB_TextureCombinerSRPCustom.ConfigureMaterialKeywordsIfNecessary(data);
		yield return packer.CreateAtlases(progressInfo, data, combiner, atlasPackingResult, atlases, textureEditorMethods, LOG_LEVEL);
		float num = sw.ElapsedMilliseconds;
		data.nonTexturePropertyBlender.AdjustNonTextureProperties(data.resultMaterial, data.texPropertyNames, textureEditorMethods);
		if (data.distinctMaterialTextures.Count > 0)
		{
			data.distinctMaterialTextures[0].AdjustResultMaterialNonTextureProperties(data.resultMaterial, data.texPropertyNames);
		}
		progressInfo?.Invoke("Building Report", 0.7f);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("---- Atlases ------");
		for (int i = 0; i < data.numAtlases; i++)
		{
			if (atlases[i] != null)
			{
				stringBuilder.AppendLine("Created Atlas For: " + data.texPropertyNames[i].name + " h=" + atlases[i].height + " w=" + atlases[i].width);
			}
			else if (!_ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
			{
				stringBuilder.AppendLine("Did not create atlas for " + data.texPropertyNames[i].name + " because all source textures were null.");
			}
		}
		report.Append(stringBuilder.ToString());
		FillResultAtlasesAndRects(data, atlasPackingResult, resultAtlasesAndRects, atlases);
		progressInfo?.Invoke("Restoring Texture Formats & Read Flags", 0.8f);
		combiner._destroyAllTemporaryTextures();
		textureEditorMethods?.RestoreReadFlagsAndFormats(progressInfo);
		if (report != null && LOG_LEVEL >= MB2_LogLevel.info)
		{
			UnityEngine.Debug.Log(report.ToString());
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Time Step 3 Create And Save Atlases part 3 " + ((float)sw.ElapsedMilliseconds - num).ToString("f5"));
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("Total time Step 3 Create And Save Atlases " + sw.Elapsed);
		}
	}

	private void FillAtlasPackingResultAuxillaryData(TexturePipelineData data, AtlasPackingResult[] atlasPackingResults)
	{
		foreach (AtlasPackingResult atlasPackingResult in atlasPackingResults)
		{
			List<MB_MaterialAndUVRect> list = new List<MB_MaterialAndUVRect>();
			for (int j = 0; j < atlasPackingResult.srcImgIdxs.Length; j++)
			{
				int index = atlasPackingResult.srcImgIdxs[j];
				MB_TexSet mB_TexSet = data.distinctMaterialTextures[index];
				List<MatAndTransformToMerged> mats = mB_TexSet.matsAndGOs.mats;
				mB_TexSet.GetRectsForTextureBakeResults(out var allPropsUseSameTiling_encapsulatingSamplingRect, out var propsUseDifferntTiling_obUVRect);
				for (int k = 0; k < mats.Count; k++)
				{
					Rect materialTilingRectForTextureBakerResults = mB_TexSet.GetMaterialTilingRectForTextureBakerResults(k);
					MB_MaterialAndUVRect mB_MaterialAndUVRect = new MB_MaterialAndUVRect(mats[k].mat, atlasPackingResult.rects[j], mB_TexSet.allTexturesUseSameMatTiling, materialTilingRectForTextureBakerResults, allPropsUseSameTiling_encapsulatingSamplingRect, propsUseDifferntTiling_obUVRect, mB_TexSet.tilingTreatment, mats[k].objName);
					mB_MaterialAndUVRect.objectsThatUse = new List<GameObject>(mB_TexSet.matsAndGOs.gos);
					list.Add(mB_MaterialAndUVRect);
				}
			}
			atlasPackingResult.data = list;
		}
	}

	private void FillResultAtlasesAndRects(TexturePipelineData data, AtlasPackingResult atlasPackingResult, MB_AtlasesAndRects resultAtlasesAndRects, Texture2D[] atlases)
	{
		List<MB_MaterialAndUVRect> list = new List<MB_MaterialAndUVRect>();
		for (int i = 0; i < data.distinctMaterialTextures.Count; i++)
		{
			MB_TexSet mB_TexSet = data.distinctMaterialTextures[i];
			List<MatAndTransformToMerged> mats = mB_TexSet.matsAndGOs.mats;
			mB_TexSet.GetRectsForTextureBakeResults(out var allPropsUseSameTiling_encapsulatingSamplingRect, out var propsUseDifferntTiling_obUVRect);
			for (int j = 0; j < mats.Count; j++)
			{
				Rect materialTilingRectForTextureBakerResults = mB_TexSet.GetMaterialTilingRectForTextureBakerResults(j);
				MB_MaterialAndUVRect item = new MB_MaterialAndUVRect(mats[j].mat, atlasPackingResult.rects[i], mB_TexSet.allTexturesUseSameMatTiling, materialTilingRectForTextureBakerResults, allPropsUseSameTiling_encapsulatingSamplingRect, propsUseDifferntTiling_obUVRect, mB_TexSet.tilingTreatment, mats[j].objName);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		resultAtlasesAndRects.atlases = atlases;
		resultAtlasesAndRects.texPropertyNames = ShaderTextureProperty.GetNames(data.texPropertyNames);
		resultAtlasesAndRects.mat2rect_map = list;
	}

	internal virtual StringBuilder GenerateReport(TexturePipelineData data)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (data.numAtlases > 0)
		{
			stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Report");
			if (data.texPropNamesToIgnore.Count > 0)
			{
				stringBuilder.Append("Ignoring texture properties: ");
				for (int i = 0; i < data.texPropNamesToIgnore.Count; i++)
				{
					stringBuilder.Append(data.texPropNamesToIgnore[i]);
					stringBuilder.Append(", ");
				}
				stringBuilder.AppendLine();
			}
			for (int j = 0; j < data.distinctMaterialTextures.Count; j++)
			{
				MB_TexSet mB_TexSet = data.distinctMaterialTextures[j];
				stringBuilder.AppendLine("----------");
				stringBuilder.Append("This set of textures will be a rectangle in the atlas. It will be resized to:" + mB_TexSet.idealWidth_pix + "x" + mB_TexSet.idealHeight_pix + "\n");
				for (int k = 0; k < mB_TexSet.ts.Length; k++)
				{
					if (!mB_TexSet.ts[k].isNull)
					{
						stringBuilder.Append("   [" + data.texPropertyNames[k].name + " " + mB_TexSet.ts[k].GetTexName() + " " + mB_TexSet.ts[k].width + "x" + mB_TexSet.ts[k].height + "]");
						if (mB_TexSet.ts[k].matTilingRect.size != Vector2.one || mB_TexSet.ts[k].matTilingRect.min != Vector2.zero)
						{
							stringBuilder.AppendFormat(" material scale {0} offset{1} ", mB_TexSet.ts[k].matTilingRect.size.ToString("G4"), mB_TexSet.ts[k].matTilingRect.min.ToString("G4"));
						}
						if (mB_TexSet.obUVscale != Vector2.one || mB_TexSet.obUVoffset != Vector2.zero)
						{
							stringBuilder.AppendFormat(" obUV scale {0} offset{1} ", mB_TexSet.obUVscale.ToString("G4"), mB_TexSet.obUVoffset.ToString("G4"));
						}
						stringBuilder.AppendLine("");
					}
					else
					{
						stringBuilder.Append("   [" + data.texPropertyNames[k].name + " null ");
						if (!_ShouldWeCreateAtlasForThisProperty(k, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
						{
							stringBuilder.Append("no atlas will be created all textures null]\n");
						}
						else
						{
							stringBuilder.AppendFormat("a 16x16 texture will be created]\n");
						}
					}
				}
				stringBuilder.AppendLine("");
				stringBuilder.Append("Materials using this rectangle:");
				for (int l = 0; l < mB_TexSet.matsAndGOs.mats.Count; l++)
				{
					stringBuilder.Append(mB_TexSet.matsAndGOs.mats[l].mat.name + ", ");
				}
				stringBuilder.AppendLine("");
			}
		}
		return stringBuilder;
	}

	internal static MB2_TexturePacker CreateTexturePacker(MB2_PackingAlgorithmEnum _packingAlgorithm)
	{
		switch (_packingAlgorithm)
		{
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker:
			return new MB2_TexturePackerRegular();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Fast:
			return new MB2_TexturePackerRegular();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePaker_Fast_V2_Beta:
			return new MB2_TexturePackerRegular();
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Horizontal:
			return new MB2_TexturePackerHorizontalVert
			{
				packingOrientation = MB2_TexturePackerHorizontalVert.TexturePackingOrientation.horizontal
			};
		case MB2_PackingAlgorithmEnum.MeshBakerTexturePacker_Vertical:
			return new MB2_TexturePackerHorizontalVert
			{
				packingOrientation = MB2_TexturePackerHorizontalVert.TexturePackingOrientation.vertical
			};
		default:
			UnityEngine.Debug.LogError("packing algorithm must be one of the MeshBaker options to create a Texture Packer");
			return null;
		}
	}

	internal static Vector2 GetAdjustedForScaleAndOffset2Dimensions(MeshBakerMaterialTexture source, Vector2 obUVoffset, Vector2 obUVscale, TexturePipelineData data, MB2_LogLevel LOG_LEVEL)
	{
		if (source.matTilingRect.x == 0.0 && source.matTilingRect.y == 0.0 && source.matTilingRect.width == 1.0 && source.matTilingRect.height == 1.0)
		{
			if (!data._fixOutOfBoundsUVs)
			{
				return new Vector2(source.width, source.height);
			}
			if (obUVoffset.x == 0f && obUVoffset.y == 0f && obUVscale.x == 1f && obUVscale.y == 1f)
			{
				return new Vector2(source.width, source.height);
			}
		}
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			string[] obj = new string[6]
			{
				"GetAdjustedForScaleAndOffset2Dimensions: ",
				source.GetTexName(),
				" ",
				null,
				null,
				null
			};
			Vector2 vector = obUVoffset;
			obj[3] = vector.ToString();
			obj[4] = " ";
			vector = obUVscale;
			obj[5] = vector.ToString();
			UnityEngine.Debug.Log(string.Concat(obj));
		}
		Rect rect = source.GetEncapsulatingSamplingRect().GetRect();
		float num = rect.width * (float)source.width;
		float num2 = rect.height * (float)source.height;
		if (num > (float)data._maxTilingBakeSize)
		{
			num = data._maxTilingBakeSize;
		}
		if (num2 > (float)data._maxTilingBakeSize)
		{
			num2 = data._maxTilingBakeSize;
		}
		if (num < 1f)
		{
			num = 1f;
		}
		if (num2 < 1f)
		{
			num2 = 1f;
		}
		return new Vector2(num, num2);
	}

	internal static Color32 ConvertNormalFormatFromUnity_ToStandard(Color32 c)
	{
		Vector3 zero = Vector3.zero;
		zero.x = (float)(int)c.a * 2f - 1f;
		zero.y = (float)(int)c.g * 2f - 1f;
		zero.z = Mathf.Sqrt(1f - zero.x * zero.x - zero.y * zero.y);
		return new Color32
		{
			a = 1,
			r = (byte)((zero.x + 1f) * 0.5f),
			g = (byte)((zero.y + 1f) * 0.5f),
			b = (byte)((zero.z + 1f) * 0.5f)
		};
	}

	internal static void GetMaterialScaleAndOffset(Material mat, string propertyName, out Vector2 offset, out Vector2 scale)
	{
		if (mat == null)
		{
			UnityEngine.Debug.LogError("Material was null. Should never happen.");
			offset = Vector2.zero;
			scale = Vector2.one;
		}
		else
		{
			MB3_ShadersThatShareTiling.GetScaleAndOffsetForTextureProp(mat, propertyName, out offset, out scale);
		}
	}

	internal static float GetSubmeshArea(Mesh m, int submeshIdx)
	{
		if (submeshIdx >= m.subMeshCount || submeshIdx < 0)
		{
			return 0f;
		}
		Vector3[] vertices = m.vertices;
		int[] indices = m.GetIndices(submeshIdx);
		float num = 0f;
		for (int i = 0; i < indices.Length; i += 3)
		{
			Vector3 vector = vertices[indices[i]];
			Vector3 vector2 = vertices[indices[i + 1]];
			Vector3 vector3 = vertices[indices[i + 2]];
			num += Vector3.Cross(vector2 - vector, vector3 - vector).magnitude / 2f;
		}
		return num;
	}

	internal static bool IsPowerOfTwo(int x)
	{
		return (x & (x - 1)) == 0;
	}
}
public class MB_TextureArrays
{
	internal class TexturePropertyData
	{
		public bool[] doMips;

		public int[] numMipMaps;

		public TextureFormat[] formats;

		public MB_TextureCompressionQuality[] compressionQualities;

		public Vector2[] sizes;
	}

	internal static bool[] DetermineWhichPropertiesHaveTextures(MB_AtlasesAndRects[] resultAtlasesAndRectSlices)
	{
		bool[] array = new bool[resultAtlasesAndRectSlices[0].texPropertyNames.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = false;
		}
		int num = resultAtlasesAndRectSlices.Length;
		for (int j = 0; j < num; j++)
		{
			MB_AtlasesAndRects mB_AtlasesAndRects = resultAtlasesAndRectSlices[j];
			for (int k = 0; k < array.Length; k++)
			{
				if (mB_AtlasesAndRects.atlases[k] != null)
				{
					array[k] = true;
				}
			}
		}
		return array;
	}

	private static bool IsLinearProperty(List<ShaderTextureProperty> shaderPropertyNames, string shaderProperty)
	{
		for (int i = 0; i < shaderPropertyNames.Count; i++)
		{
			if (shaderPropertyNames[i].name == shaderProperty && shaderPropertyNames[i].isNormalMap)
			{
				return true;
			}
		}
		return false;
	}

	internal static Texture2DArray[] CreateTextureArraysForResultMaterial(TexturePropertyData texPropertyData, List<ShaderTextureProperty> masterListOfTexProperties, MB_AtlasesAndRects[] resultAtlasesAndRectSlices, bool[] hasTexForProperty, MB3_TextureCombiner combiner, MB2_LogLevel LOG_LEVEL)
	{
		string[] texPropertyNames = resultAtlasesAndRectSlices[0].texPropertyNames;
		Texture2DArray[] array = new Texture2DArray[texPropertyNames.Length];
		for (int i = 0; i < texPropertyNames.Length; i++)
		{
			if (!hasTexForProperty[i])
			{
				continue;
			}
			string text = texPropertyNames[i];
			int num = resultAtlasesAndRectSlices.Length;
			int num2 = (int)texPropertyData.sizes[i].x;
			int num3 = (int)texPropertyData.sizes[i].y;
			int num4 = texPropertyData.numMipMaps[i];
			TextureFormat textureFormat = texPropertyData.formats[i];
			bool flag = texPropertyData.doMips[i];
			bool flag2 = MB3_TextureCombiner.ShouldTextureBeLinear(masterListOfTexProperties[i]);
			Texture2DArray texture2DArray = new Texture2DArray(num2, num3, num, textureFormat, flag, flag2);
			if (LOG_LEVEL >= MB2_LogLevel.info)
			{
				UnityEngine.Debug.LogFormat("Creating Texture2DArray for property: {0} w: {1} h: {2} format: {3} doMips: {4} isLinear: {5}", text, num2, num3, textureFormat, flag, flag2);
			}
			for (int j = 0; j < num; j++)
			{
				Texture2D texture2D = resultAtlasesAndRectSlices[j].atlases[i];
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.LogFormat("Slice: {0}  texture: {1}  w: {2}  h: {3}  prop: {4}", j, texture2D, texture2D.width, texture2D.height, texPropertyNames[i]);
				}
				bool flag3 = false;
				if (texture2D == null)
				{
					if (LOG_LEVEL >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.LogFormat("Texture is null for slice: {0} creating temporary texture", j);
					}
					texture2D = combiner._createTemporaryTexture(text, num2, num3, textureFormat, flag, flag2);
				}
				for (int k = 0; k < num4; k++)
				{
					Graphics.CopyTexture(texture2D, 0, k, texture2DArray, j, k);
				}
				if (flag3)
				{
					MB_Utility.Destroy(texture2D);
				}
			}
			array[i] = texture2DArray;
		}
		return array;
	}

	internal static bool ConvertTexturesToReadableFormat(TexturePropertyData texturePropertyData, MB_AtlasesAndRects[] resultAtlasesAndRectSlices, bool[] hasTexForProperty, List<ShaderTextureProperty> textureShaderProperties, MB3_TextureCombiner combiner, MB2_LogLevel logLevel, List<Texture2D> createdTemporaryTextureAssets, MB2_EditorMethodsInterface textureEditorMethods)
	{
		for (int i = 0; i < hasTexForProperty.Length; i++)
		{
			if (!hasTexForProperty[i])
			{
				continue;
			}
			TextureFormat textureFormat = texturePropertyData.formats[i];
			MB_TextureCompressionQuality compressionQuality = texturePropertyData.compressionQualities[i];
			if (textureEditorMethods != null && !textureEditorMethods.TextureImporterFormatExistsForTextureFormat(textureFormat))
			{
				UnityEngine.Debug.LogError("Could not find target importer format matching " + textureFormat);
				return false;
			}
			int num = resultAtlasesAndRectSlices.Length;
			int num2 = (int)texturePropertyData.sizes[i].x;
			int num3 = (int)texturePropertyData.sizes[i].y;
			for (int j = 0; j < num; j++)
			{
				Texture2D texture2D = resultAtlasesAndRectSlices[j].atlases[i];
				if (texture2D != null)
				{
					if (!MBVersion.IsTextureReadable(texture2D))
					{
						if (textureEditorMethods == null)
						{
							UnityEngine.Debug.LogError("Source texture must be readable: " + texture2D);
							return false;
						}
						textureEditorMethods.SetReadWriteFlag(texture2D, isReadable: true, addToList: true);
					}
					bool flag = true;
					if (textureEditorMethods != null)
					{
						flag = textureEditorMethods.IsAnAsset(texture2D);
					}
					if (logLevel >= MB2_LogLevel.trace)
					{
						UnityEngine.Debug.Log("Considering format of property:" + textureShaderProperties[i].name + " texture: '" + texture2D.name + "' format:" + texture2D.format);
					}
					if (Application.isPlaying)
					{
						if (texture2D.width != num2 || texture2D.height != num3 || texture2D.format != textureFormat)
						{
							UnityEngine.Debug.LogError("If creating Texture Arrays at runtime then source textures must be the same size as the texture array and in the same format as the texture array.Texture " + texture2D.name + " is not in the correct format or does not have the correct size. (" + texture2D.width + ", " + texture2D.height + ", " + texture2D.format);
							return false;
						}
					}
					else if (texture2D.width != num2 || texture2D.height != num3 || (!flag && texture2D.format != textureFormat))
					{
						resultAtlasesAndRectSlices[j].atlases[i] = textureEditorMethods.CreateTemporaryAssetCopyForTextureArray(textureShaderProperties[i], texture2D, num2, num3, textureFormat, logLevel);
						createdTemporaryTextureAssets.Add(resultAtlasesAndRectSlices[j].atlases[i]);
					}
					else if (texture2D.format != textureFormat)
					{
						textureEditorMethods.ConvertTextureFormat_PlatformOverride(texture2D, textureFormat, compressionQuality, textureShaderProperties[i].isNormalMap);
					}
				}
				if (resultAtlasesAndRectSlices[j].atlases[i].format != textureFormat)
				{
					UnityEngine.Debug.LogError("Could not convert texture to format " + textureFormat.ToString() + ". This can happen if the target build platform in build settings does not support textures in this format. It may be necessary to switch the build platform in order to build texture arrays in this format.");
					return false;
				}
			}
		}
		return true;
	}

	internal static void FindBestSizeAndMipCountAndFormatForTextureArrays(List<ShaderTextureProperty> texPropertyNames, int maxAtlasSize, MB_TextureArrayFormatSet targetFormatSet, MB_AtlasesAndRects[] resultAtlasesAndRectSlices, TexturePropertyData texturePropertyData)
	{
		texturePropertyData.sizes = new Vector2[texPropertyNames.Count];
		texturePropertyData.doMips = new bool[texPropertyNames.Count];
		texturePropertyData.numMipMaps = new int[texPropertyNames.Count];
		texturePropertyData.formats = new TextureFormat[texPropertyNames.Count];
		texturePropertyData.compressionQualities = new MB_TextureCompressionQuality[texPropertyNames.Count];
		for (int i = 0; i < texPropertyNames.Count; i++)
		{
			int num = resultAtlasesAndRectSlices.Length;
			texturePropertyData.sizes[i] = new Vector3(16f, 16f, 1f);
			bool flag = false;
			int num2 = 1;
			for (int j = 0; j < num; j++)
			{
				Texture2D texture2D = resultAtlasesAndRectSlices[j].atlases[i];
				if (texture2D != null)
				{
					if (texture2D.mipmapCount > 1)
					{
						flag = true;
					}
					num2 = Mathf.Max(num2, texture2D.mipmapCount);
					texturePropertyData.sizes[i].x = Mathf.Min(Mathf.Max(texturePropertyData.sizes[i].x, texture2D.width), maxAtlasSize);
					texturePropertyData.sizes[i].y = Mathf.Min(Mathf.Max(texturePropertyData.sizes[i].y, texture2D.height), maxAtlasSize);
					texturePropertyData.formats[i] = targetFormatSet.GetFormatForProperty(texPropertyNames[i].name, out texturePropertyData.compressionQualities[i]);
				}
			}
			int a = Mathf.CeilToInt(Mathf.Log(maxAtlasSize, 2f)) + 1;
			texturePropertyData.numMipMaps[i] = Mathf.Min(a, num2);
			texturePropertyData.doMips[i] = flag;
		}
	}

	public static IEnumerator _CreateAtlasesCoroutineSingleResultMaterial(int resMatIdx, MB_TextureArrayResultMaterial bakedMatsAndSlicesResMat, MB_MultiMaterialTexArray resMatConfig, List<GameObject> objsToMesh, MB3_TextureCombiner combiner, MB_TextureArrayFormatSet[] textureArrayOutputFormats, MB_MultiMaterialTexArray[] resultMaterialsTexArray, List<ShaderTextureProperty> customShaderProperties, List<string> texPropNamesToIgnore, ProgressUpdateDelegate progressInfo, MB3_TextureCombiner.CreateAtlasesCoroutineResult coroutineResult, bool saveAtlasesAsAssets = false, MB2_EditorMethodsInterface editorMethods = null, float maxTimePerFrame = 0.01f)
	{
		MB2_LogLevel LOG_LEVEL = combiner.LOG_LEVEL;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("=== STAGE 1   Baking atlases for result material " + resMatIdx + " num slices:" + resMatConfig.slices.Count);
		}
		List<MB3_TextureCombiner.TemporaryTexture> generatedTemporaryAtlases = new List<MB3_TextureCombiner.TemporaryTexture>();
		combiner.saveAtlasesAsAssets = false;
		List<MB_TexArraySlice> slicesConfig = resMatConfig.slices;
		for (int sliceIdx = 0; sliceIdx < slicesConfig.Count; sliceIdx++)
		{
			List<MB_TexArraySliceRendererMatPair> srcMatAndObjPairs = slicesConfig[sliceIdx].sourceMaterials;
			if (LOG_LEVEL >= MB2_LogLevel.trace)
			{
				UnityEngine.Debug.Log(" Baking atlases for result material:" + resMatIdx + " slice:" + sliceIdx);
			}
			Material combinedMaterial = resMatConfig.combinedMaterial;
			combiner.fixOutOfBoundsUVs = slicesConfig[sliceIdx].considerMeshUVs;
			MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult coroutineResult2 = new MB3_TextureCombiner.CombineTexturesIntoAtlasesCoroutineResult();
			MB_AtlasesAndRects sliceAtlasesAndRectOutput = bakedMatsAndSlicesResMat.slices[sliceIdx];
			List<Material> list = new List<Material>();
			slicesConfig[sliceIdx].GetAllUsedMaterials(list);
			yield return combiner.CombineTexturesIntoAtlasesCoroutine(progressInfo, sliceAtlasesAndRectOutput, combinedMaterial, slicesConfig[sliceIdx].GetAllUsedRenderers(objsToMesh), list, texPropNamesToIgnore, editorMethods, coroutineResult2, maxTimePerFrame);
			coroutineResult.success = coroutineResult2.success;
			if (!coroutineResult.success)
			{
				coroutineResult.isFinished = true;
				yield break;
			}
			for (int i = 0; i < sliceAtlasesAndRectOutput.atlases.Length; i++)
			{
				Texture2D texture2D = sliceAtlasesAndRectOutput.atlases[i];
				if (!(texture2D != null))
				{
					continue;
				}
				bool flag = false;
				for (int j = 0; j < srcMatAndObjPairs.Count; j++)
				{
					Material sourceMaterial = srcMatAndObjPairs[j].sourceMaterial;
					if (sourceMaterial.HasProperty(sliceAtlasesAndRectOutput.texPropertyNames[i]) && sourceMaterial.GetTexture(sliceAtlasesAndRectOutput.texPropertyNames[i]) == texture2D)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					generatedTemporaryAtlases.Add(new MB3_TextureCombiner.TemporaryTexture(sliceAtlasesAndRectOutput.texPropertyNames[i], texture2D));
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("Property: " + sliceAtlasesAndRectOutput.texPropertyNames[i] + " atlasWasSrcTex:" + flag);
				}
			}
		}
		combiner.saveAtlasesAsAssets = saveAtlasesAsAssets;
		if (LOG_LEVEL >= MB2_LogLevel.debug)
		{
			UnityEngine.Debug.Log("=== STAGE 2 Generate Temporary Textures");
		}
		for (int k = 0; k < generatedTemporaryAtlases.Count; k++)
		{
			combiner.AddTemporaryTexture(generatedTemporaryAtlases[k]);
		}
		List<ShaderTextureProperty> list2 = new List<ShaderTextureProperty>();
		MB3_TextureCombinerPipeline._CollectPropertyNames(list2, customShaderProperties, texPropNamesToIgnore, resMatConfig.combinedMaterial, LOG_LEVEL);
		bool[] array = DetermineWhichPropertiesHaveTextures(bakedMatsAndSlicesResMat.slices);
		List<Texture2D> list3 = new List<Texture2D>();
		try
		{
			Dictionary<string, MB_TexArrayForProperty> dictionary = new Dictionary<string, MB_TexArrayForProperty>();
			for (int l = 0; l < list2.Count; l++)
			{
				if (array[l])
				{
					dictionary[list2[l].name] = new MB_TexArrayForProperty(list2[l].name, new MB_TextureArrayReference[textureArrayOutputFormats.Length]);
				}
			}
			MB3_TextureCombinerNonTextureProperties mB3_TextureCombinerNonTextureProperties = new MB3_TextureCombinerNonTextureProperties(LOG_LEVEL, combiner.considerNonTextureProperties);
			mB3_TextureCombinerNonTextureProperties.LoadTextureBlendersIfNeeded(resMatConfig.combinedMaterial);
			mB3_TextureCombinerNonTextureProperties.AdjustNonTextureProperties(resMatConfig.combinedMaterial, list2, editorMethods);
			for (int m = 0; m < textureArrayOutputFormats.Length; m++)
			{
				MB_TextureArrayFormatSet mB_TextureArrayFormatSet = textureArrayOutputFormats[m];
				editorMethods?.Clear();
				TexturePropertyData texturePropertyData = new TexturePropertyData();
				FindBestSizeAndMipCountAndFormatForTextureArrays(list2, combiner.maxAtlasSize, mB_TextureArrayFormatSet, bakedMatsAndSlicesResMat.slices, texturePropertyData);
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("=== STAGE 3 formatSet: " + mB_TextureArrayFormatSet.name + " generate necessary temporary textures ");
				}
				for (int n = 0; n < array.Length; n++)
				{
					if (!array[n])
					{
						continue;
					}
					TextureFormat format = texturePropertyData.formats[n];
					int num = bakedMatsAndSlicesResMat.slices.Length;
					int num2 = (int)texturePropertyData.sizes[n].x;
					int num3 = (int)texturePropertyData.sizes[n].y;
					for (int num4 = 0; num4 < num; num4++)
					{
						if (bakedMatsAndSlicesResMat.slices[num4].atlases[n] == null)
						{
							Texture2D texture2D2 = new Texture2D(num2, num3, TextureFormat.ARGB32, texturePropertyData.doMips[n]);
							ShaderTextureProperty shaderTextureProperty = list2[n];
							Color c = ((!shaderTextureProperty.isNormalMap) ? mB3_TextureCombinerNonTextureProperties.GetColorForTemporaryTexture(resMatConfig.slices[num4].sourceMaterials[0].sourceMaterial, shaderTextureProperty) : MB3_TextureCombiner.NEUTRAL_NORMAL_MAP_COLOR_NON_SWIZZLED);
							MB_Utility.setSolidColor(texture2D2, c);
							bakedMatsAndSlicesResMat.slices[num4].atlases[n] = editorMethods.CreateTemporaryAssetCopyForTextureArray(list2[n], texture2D2, num2, num3, format, LOG_LEVEL);
							list3.Add(bakedMatsAndSlicesResMat.slices[num4].atlases[n]);
							MB_Utility.Destroy(texture2D2);
						}
					}
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("=== STAGE 4 formatSet: " + mB_TextureArrayFormatSet.name + " Converting source textures to readable formats.");
				}
				if (!ConvertTexturesToReadableFormat(texturePropertyData, bakedMatsAndSlicesResMat.slices, array, list2, combiner, LOG_LEVEL, list3, editorMethods))
				{
					continue;
				}
				if (LOG_LEVEL >= MB2_LogLevel.debug)
				{
					UnityEngine.Debug.Log("=== STAGE 5 formatSet: " + mB_TextureArrayFormatSet.name + " Creating texture array");
				}
				Texture2DArray[] array2 = CreateTextureArraysForResultMaterial(texturePropertyData, list2, bakedMatsAndSlicesResMat.slices, array, combiner, LOG_LEVEL);
				for (int num5 = 0; num5 < array2.Length; num5++)
				{
					if (array[num5])
					{
						MB_TextureArrayReference mB_TextureArrayReference = new MB_TextureArrayReference(mB_TextureArrayFormatSet.name, array2[num5]);
						dictionary[list2[num5].name].formats[m] = mB_TextureArrayReference;
						if (saveAtlasesAsAssets)
						{
							editorMethods.SaveTextureArrayToAssetDatabase(array2[num5], mB_TextureArrayFormatSet.GetFormatForProperty(list2[num5].name, out var _), bakedMatsAndSlicesResMat.slices[0].texPropertyNames[num5], num5, resMatConfig.combinedMaterial);
						}
					}
				}
			}
			resMatConfig.textureProperties = new List<MB_TexArrayForProperty>();
			foreach (MB_TexArrayForProperty value in dictionary.Values)
			{
				resMatConfig.textureProperties.Add(value);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(ex.Message + "\n" + ex.StackTrace.ToString());
			coroutineResult.isFinished = true;
			coroutineResult.success = false;
		}
		finally
		{
			editorMethods?.RestoreReadFlagsAndFormats(progressInfo);
			combiner._destroyAllTemporaryTextures();
			for (int num6 = 0; num6 < list3.Count; num6++)
			{
				editorMethods?.DestroyAsset(list3[num6]);
			}
			list3.Clear();
		}
	}
}
public static class MB_TextureCombinerSRPCustom
{
	private static bool IsURPMaterial(Material m)
	{
		if (m.HasProperty("_BaseMap"))
		{
			return true;
		}
		return false;
	}

	internal static void ConfigureMaterialKeywordsIfNecessary(MB3_TextureCombinerPipeline.TexturePipelineData data)
	{
		if (MBVersion.DetectPipeline() == MBVersion.PipelineType.URP && IsURPMaterial(data.resultMaterial))
		{
			MB_TextureCombinerSRPCustom_URP.ConfigureMaterialKeywords(data, data.resultMaterial);
		}
		if (MBVersion.DetectPipeline() == MBVersion.PipelineType.Default && data.resultMaterial != null && data.resultMaterial.name.Contains("Standard"))
		{
			MB_TextureCombinerSRPCustom_Standard.ConfigureMaterialKeywords(data, data.resultMaterial);
		}
	}
}
public static class MB_TextureCombinerSRPCustom_URP
{
	private static bool _IsCreatingAtlasForProperty(MB3_TextureCombinerPipeline.TexturePipelineData data, string property)
	{
		for (int i = 0; i < data.texPropertyNames.Count; i++)
		{
			if (property.Equals(data.texPropertyNames[i].name))
			{
				if (MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					return true;
				}
				return false;
			}
		}
		return false;
	}

	internal static void ConfigureMaterialKeywords(MB3_TextureCombinerPipeline.TexturePipelineData data, Material resultMat)
	{
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_NORMALMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_BumpMap"))
			{
				resultMat.EnableKeyword("_NORMALMAP");
			}
			else
			{
				resultMat.DisableKeyword("_NORMALMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_SPECGLOSSMAP"))
		{
			_IsCreatingAtlasForProperty(data, "_SpecGlossMap");
			if (_IsCreatingAtlasForProperty(data, "_SpecGlossMap"))
			{
				resultMat.EnableKeyword("_SPECGLOSSMAP");
			}
			else
			{
				resultMat.DisableKeyword("_SPECGLOSSMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_METALLICSPECGLOSSMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_MetallicGlossMap"))
			{
				resultMat.EnableKeyword("_METALLICSPECGLOSSMAP");
			}
			else
			{
				resultMat.DisableKeyword("_METALLICSPECGLOSSMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_PARALLAXMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_ParallaxMap"))
			{
				resultMat.EnableKeyword("_PARALLAXMAP");
			}
			else
			{
				resultMat.DisableKeyword("_PARALLAXMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_OCCLUSIONMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_OcclusionMap"))
			{
				resultMat.EnableKeyword("_OCCLUSIONMAP");
			}
			else
			{
				resultMat.DisableKeyword("_OCCLUSIONMAP");
			}
		}
	}
}
public static class MB_TextureCombinerSRPCustom_Standard
{
	private static bool _IsCreatingAtlasForProperty(MB3_TextureCombinerPipeline.TexturePipelineData data, string property)
	{
		for (int i = 0; i < data.texPropertyNames.Count; i++)
		{
			if (property.Equals(data.texPropertyNames[i].name))
			{
				if (MB3_TextureCombinerPipeline._ShouldWeCreateAtlasForThisProperty(i, data._considerNonTextureProperties, data.allTexturesAreNullAndSameColor))
				{
					return true;
				}
				return false;
			}
		}
		return false;
	}

	internal static void ConfigureMaterialKeywords(MB3_TextureCombinerPipeline.TexturePipelineData data, Material resultMat)
	{
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_NORMALMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_BumpMap"))
			{
				resultMat.EnableKeyword("_NORMALMAP");
			}
			else
			{
				resultMat.DisableKeyword("_NORMALMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_METALLICGLOSSMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_MetallicGlossMap"))
			{
				resultMat.EnableKeyword("_METALLICGLOSSMAP");
			}
			else
			{
				resultMat.DisableKeyword("_METALLICGLOSSMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_METALLICSPECGLOSSMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_MetallicGlossMap"))
			{
				resultMat.EnableKeyword("_METALLICSPECGLOSSMAP");
			}
			else
			{
				resultMat.DisableKeyword("_METALLICSPECGLOSSMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_PARALLAXMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_ParallaxMap"))
			{
				resultMat.EnableKeyword("_PARALLAXMAP");
			}
			else
			{
				resultMat.DisableKeyword("_PARALLAXMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_OCCLUSIONMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_OcclusionMap"))
			{
				resultMat.EnableKeyword("_OCCLUSIONMAP");
			}
			else
			{
				resultMat.DisableKeyword("_OCCLUSIONMAP");
			}
		}
		if (MBVersion.IsMaterialKeywordValid(resultMat, "_EMISSIONMAP"))
		{
			if (_IsCreatingAtlasForProperty(data, "_EmissionMap"))
			{
				resultMat.EnableKeyword("_EMISSIONMAP");
			}
			else
			{
				resultMat.DisableKeyword("_EMISSIONMAP");
			}
		}
	}
}
public class MB3_Comment : MonoBehaviour
{
	[Multiline]
	public string comment;
}
public class MBVersionConcrete : MBVersionInterface
{
	private Vector2 _HALF_UV = new Vector2(0.5f, 0.5f);

	public string version()
	{
		return "3.39.0";
	}

	public bool Is_2017_1_OrNewer()
	{
		return true;
	}

	public bool Is_2018_3_OrNewer()
	{
		return true;
	}

	public bool GetActive(GameObject go)
	{
		return go.activeInHierarchy;
	}

	public void SetActive(GameObject go, bool isActive)
	{
		go.SetActive(isActive);
	}

	public void SetActiveRecursively(GameObject go, bool isActive)
	{
		go.SetActive(isActive);
	}

	public UnityEngine.Object[] FindSceneObjectsOfType(Type t)
	{
		return UnityEngine.Object.FindObjectsOfType(t);
	}

	public bool IsSwizzledNormalMapPlatform()
	{
		bool result = !GraphicsSettings.HasShaderDefine(BuiltinShaderDefine.UNITY_NO_DXT5nm);
		_ = Application.isEditor;
		return result;
	}

	public bool IsMaterialKeywordValid(Material mat, string keyword)
	{
		return mat.shader.keywordSpace.FindKeyword(keyword).isValid;
	}

	public void OptimizeMesh(Mesh m)
	{
	}

	public bool IsRunningAndMeshNotReadWriteable(Mesh m)
	{
		if (Application.isPlaying)
		{
			return !m.isReadable;
		}
		return false;
	}

	public Vector2[] GetMeshUV1s(Mesh m, MB2_LogLevel LOG_LEVEL)
	{
		if (LOG_LEVEL >= MB2_LogLevel.warn)
		{
			MB2_Log.LogDebug("UV1 does not exist in Unity 5+");
		}
		Vector2[] array = m.uv;
		if (array.Length == 0)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no uv1s. Generating");
			}
			if (LOG_LEVEL >= MB2_LogLevel.warn)
			{
				UnityEngine.Debug.LogWarning("Mesh " + m?.ToString() + " didn't have uv1s. Generating uv1s.");
			}
			array = new Vector2[m.vertexCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _HALF_UV;
			}
		}
		return array;
	}

	public Vector2[] GetMeshUVChannel(int channel, Mesh m, MB2_LogLevel LOG_LEVEL)
	{
		Vector2[] array = new Vector2[0];
		switch (channel)
		{
		case 0:
			array = m.uv;
			break;
		case 2:
			array = m.uv2;
			break;
		case 3:
			array = m.uv3;
			break;
		case 4:
			array = m.uv4;
			break;
		case 5:
			array = m.uv5;
			break;
		case 6:
			array = m.uv6;
			break;
		case 7:
			array = m.uv7;
			break;
		case 8:
			array = m.uv8;
			break;
		default:
			UnityEngine.Debug.LogError("Mesh does not have UV channel " + channel);
			break;
		}
		if (array.Length == 0)
		{
			if (LOG_LEVEL >= MB2_LogLevel.debug)
			{
				MB2_Log.LogDebug("Mesh " + m?.ToString() + " has no uv" + channel + ". Generating");
			}
			array = new Vector2[m.vertexCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _HALF_UV;
			}
		}
		return array;
	}

	public void MeshClear(Mesh m, bool t)
	{
		m.Clear(t);
	}

	public void MeshAssignUVChannel(int channel, Mesh m, Vector2[] uvs)
	{
		switch (channel)
		{
		case 0:
			m.uv = uvs;
			break;
		case 2:
			m.uv2 = uvs;
			break;
		case 3:
			m.uv3 = uvs;
			break;
		case 4:
			m.uv4 = uvs;
			break;
		case 5:
			m.uv5 = uvs;
			break;
		case 6:
			m.uv6 = uvs;
			break;
		case 7:
			m.uv7 = uvs;
			break;
		case 8:
			m.uv8 = uvs;
			break;
		default:
			UnityEngine.Debug.LogError("Mesh does not have UV channel " + channel);
			break;
		}
	}

	public Vector4 GetLightmapTilingOffset(Renderer r)
	{
		return r.lightmapScaleOffset;
	}

	public Transform[] GetBones(Renderer r, bool isSkinnedMeshWithBones)
	{
		if (isSkinnedMeshWithBones)
		{
			return ((SkinnedMeshRenderer)r).bones;
		}
		if (r is MeshRenderer || (r is SkinnedMeshRenderer && !isSkinnedMeshWithBones))
		{
			return new Transform[1] { r.transform };
		}
		UnityEngine.Debug.LogError("Could not getBones. Object does not have a renderer");
		return null;
	}

	public int GetBlendShapeFrameCount(Mesh m, int shapeIndex)
	{
		return m.GetBlendShapeFrameCount(shapeIndex);
	}

	public float GetBlendShapeFrameWeight(Mesh m, int shapeIndex, int frameIndex)
	{
		return m.GetBlendShapeFrameWeight(shapeIndex, frameIndex);
	}

	public void GetBlendShapeFrameVertices(Mesh m, int shapeIndex, int frameIndex, Vector3[] vs, Vector3[] ns, Vector3[] ts)
	{
		m.GetBlendShapeFrameVertices(shapeIndex, frameIndex, vs, ns, ts);
	}

	public void ClearBlendShapes(Mesh m)
	{
		m.ClearBlendShapes();
	}

	public void AddBlendShapeFrame(Mesh m, string nm, float wt, Vector3[] vs, Vector3[] ns, Vector3[] ts)
	{
		m.AddBlendShapeFrame(nm, wt, vs, ns, ts);
	}

	public int MaxMeshVertexCount()
	{
		return 2147483646;
	}

	public void SetMeshIndexFormatAndClearMesh(Mesh m, int numVerts, bool vertices, bool justClearTriangles)
	{
		if (vertices && numVerts > 65534 && m.indexFormat == IndexFormat.UInt16)
		{
			MBVersion.MeshClear(m, t: false);
			m.indexFormat = IndexFormat.UInt32;
		}
		else if (vertices && numVerts <= 65534 && m.indexFormat == IndexFormat.UInt32)
		{
			MBVersion.MeshClear(m, t: false);
			m.indexFormat = IndexFormat.UInt16;
		}
		else if (justClearTriangles)
		{
			MBVersion.MeshClear(m, t: true);
		}
		else
		{
			MBVersion.MeshClear(m, t: false);
		}
	}

	public bool GraphicsUVStartsAtTop()
	{
		return false;
	}

	public bool IsTexture_sRGBgammaCorrected(Texture2D tex, bool hint)
	{
		return tex.isDataSRGB;
	}

	public bool IsTextureReadable(Texture2D tex)
	{
		return tex.isReadable;
	}

	public float GetScaleInLightmap(MeshRenderer r)
	{
		return 1f;
	}

	public bool CollectPropertyNames(List<ShaderTextureProperty> texPropertyNames, ShaderTextureProperty[] shaderTexPropertyNames, List<ShaderTextureProperty> _customShaderPropNames, Material resultMaterial, MB2_LogLevel LOG_LEVEL)
	{
		if (resultMaterial != null && resultMaterial.shader != null)
		{
			Shader shader = resultMaterial.shader;
			for (int i = 0; i < shader.GetPropertyCount(); i++)
			{
				if (shader.GetPropertyType(i) != ShaderPropertyType.Texture)
				{
					continue;
				}
				string propertyName = shader.GetPropertyName(i);
				if (resultMaterial.GetTextureOffset(propertyName) != new Vector2(0f, 0f) && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Result material has non-zero offset for property " + propertyName + ". This is probably incorrect.");
				}
				if (resultMaterial.GetTextureScale(propertyName) != new Vector2(1f, 1f) && LOG_LEVEL >= MB2_LogLevel.warn)
				{
					UnityEngine.Debug.LogWarning("Result material should probably have tiling of 1,1 for propert " + propertyName);
				}
				ShaderTextureProperty shaderTextureProperty = null;
				for (int j = 0; j < shaderTexPropertyNames.Length; j++)
				{
					if (shaderTexPropertyNames[j].name == propertyName)
					{
						shaderTextureProperty = new ShaderTextureProperty(propertyName, shaderTexPropertyNames[j].isNormalMap, shaderTexPropertyNames[j].isGammaCorrected, shaderTexPropertyNames[j].isNormalDontKnow);
					}
				}
				for (int k = 0; k < _customShaderPropNames.Count; k++)
				{
					if (_customShaderPropNames[k].name == propertyName)
					{
						shaderTextureProperty = new ShaderTextureProperty(propertyName, _customShaderPropNames[k].isNormalMap, _customShaderPropNames[k].isGammaCorrected, _customShaderPropNames[k].isNormalDontKnow);
					}
				}
				if (shaderTextureProperty == null)
				{
					shaderTextureProperty = new ShaderTextureProperty(propertyName, norm: false, isGamma: true, isNormalDontKnow: true);
				}
				texPropertyNames.Add(shaderTextureProperty);
			}
			MBVersion.PipelineType pipelineType = DetectPipeline();
			int num = texPropertyNames.FindIndex((ShaderTextureProperty pn) => pn.name.Equals("_MainTex"));
			if (pipelineType == MBVersion.PipelineType.URP && shader.name.StartsWith("Universal Render Pipeline/") && num != -1 && texPropertyNames.FindIndex((ShaderTextureProperty pn) => pn.name.Equals("_BaseMap")) != -1)
			{
				texPropertyNames.RemoveAt(num);
			}
			else if (pipelineType == MBVersion.PipelineType.HDRP && shader.name.StartsWith("HDRP/") && num != -1 && texPropertyNames.FindIndex((ShaderTextureProperty pn) => pn.name.Equals("_BaseColorMap")) != -1)
			{
				texPropertyNames.RemoveAt(num);
			}
		}
		return true;
	}

	public void DoSpecialRenderPipeline_TexturePackerFastSetup(GameObject cameraGameObject)
	{
	}

	public ColorSpace GetProjectColorSpace()
	{
		if (QualitySettings.desiredColorSpace != QualitySettings.activeColorSpace)
		{
			UnityEngine.Debug.LogError("The active color space (" + QualitySettings.activeColorSpace.ToString() + ") is not the desired color space (" + QualitySettings.desiredColorSpace.ToString() + "). Baked atlases may be off.");
		}
		return QualitySettings.activeColorSpace;
	}

	public MBVersion.PipelineType DetectPipeline()
	{
		RenderPipelineAsset defaultRenderPipeline = GraphicsSettings.defaultRenderPipeline;
		defaultRenderPipeline = ((QualitySettings.renderPipeline != null) ? QualitySettings.renderPipeline : defaultRenderPipeline);
		if (defaultRenderPipeline != null)
		{
			string text = defaultRenderPipeline.GetType().ToString();
			if (text.Contains("HDRenderPipelineAsset"))
			{
				return MBVersion.PipelineType.HDRP;
			}
			if (text.Contains("UniversalRenderPipelineAsset") || text.Contains("LightweightRenderPipelineAsset"))
			{
				return MBVersion.PipelineType.URP;
			}
			return MBVersion.PipelineType.Unsupported;
		}
		return MBVersion.PipelineType.Default;
	}

	public string UnescapeURL(string url)
	{
		return UnityWebRequest.UnEscapeURL(url);
	}

	public IEnumerator FindRuntimeMaterialsFromAddresses(MB2_TextureBakeResults texBakeResult, MB2_TextureBakeResults.CoroutineResult isComplete)
	{
		if (!Application.isPlaying)
		{
			UnityEngine.Debug.LogError("FindRuntimeMaterialsFromAddresses is a coroutine. It is only necessary to use this at runtime.");
		}
		UnityEngine.Debug.LogError("The MB_USING_ADDRESSABLES define was not set in PlayerSettings -> Script Define Symbols. If you are using addressables and you want to use this method, that must be set.");
		isComplete.isComplete = true;
		yield break;
	}

	public bool IsAssetInProject(UnityEngine.Object target)
	{
		return false;
	}
}
[Serializable]
public class GrouperData
{
	public bool clusterOnLMIndex;

	public bool clusterByLODLevel;

	public Vector3 origin;

	public Vector3 cellSize = new Vector3(5f, 5f, 5f);

	public int pieNumSegments = 4;

	public Vector3 pieAxis = Vector3.up;

	public float ringSpacing = 100f;

	public bool combineSegmentsInInnermostRing;

	public bool includeCellsWithOnlyOneRenderer = true;

	public MB3_AgglomerativeClustering cluster;

	public float maxDistBetweenClusters = 1f;

	public float _lastMaxDistBetweenClusters;

	public float _ObjsExtents = 10f;

	public float _minDistBetweenClusters = 0.001f;

	public List<MB3_AgglomerativeClustering.ClusterNode> _clustersToDraw = new List<MB3_AgglomerativeClustering.ClusterNode>();

	public float[] _radii;
}
public abstract class MB3_MeshBakerGrouperBehaviour
{
	public abstract Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d);

	public abstract void DrawGizmos(Bounds sourceObjectBounds, GrouperData d);

	public List<MB3_MeshBakerCommon> DoClustering(MB3_TextureBaker tb, MB3_MeshBakerGrouper grouper, GrouperData d)
	{
		List<MB3_MeshBakerCommon> list = new List<MB3_MeshBakerCommon>();
		if ((grouper.prefabOptions_autoGeneratePrefabs || grouper.prefabOptions_mergeOutputIntoSinglePrefab) && Application.isPlaying)
		{
			UnityEngine.Debug.LogError("Cannot generate prefabs while playing. Prefabs can only be generated in the editor and not in play mode.");
			return list;
		}
		Dictionary<string, List<Renderer>> dictionary = FilterIntoGroups(tb.GetObjectsToCombine(), d);
		if (d.clusterOnLMIndex)
		{
			Dictionary<string, List<Renderer>> dictionary2 = new Dictionary<string, List<Renderer>>();
			foreach (string key4 in dictionary.Keys)
			{
				List<Renderer> gaws = dictionary[key4];
				Dictionary<int, List<Renderer>> dictionary3 = GroupByLightmapIndex(gaws);
				foreach (int key5 in dictionary3.Keys)
				{
					string key = key4 + "-LM-" + key5;
					dictionary2.Add(key, dictionary3[key5]);
				}
			}
			dictionary = dictionary2;
		}
		if (d.clusterByLODLevel)
		{
			Dictionary<string, List<Renderer>> dictionary4 = new Dictionary<string, List<Renderer>>();
			foreach (string key6 in dictionary.Keys)
			{
				foreach (Renderer r in dictionary[key6])
				{
					if (r == null)
					{
						continue;
					}
					bool flag = false;
					LODGroup componentInParent = r.GetComponentInParent<LODGroup>();
					if (componentInParent != null)
					{
						LOD[] lODs = componentInParent.GetLODs();
						for (int i = 0; i < lODs.Length; i++)
						{
							if (Array.Find(lODs[i].renderers, (Renderer x) => x == r) != null)
							{
								flag = true;
								string key2 = $"{key6}_LOD{i}";
								if (!dictionary4.TryGetValue(key2, out var value))
								{
									value = new List<Renderer>();
									dictionary4.Add(key2, value);
								}
								if (!value.Contains(r))
								{
									value.Add(r);
								}
							}
						}
					}
					if (!flag)
					{
						string key3 = $"{key6}_LOD0";
						if (!dictionary4.TryGetValue(key3, out var value2))
						{
							value2 = new List<Renderer>();
							dictionary4.Add(key3, value2);
						}
						if (!value2.Contains(r))
						{
							value2.Add(r);
						}
					}
				}
			}
			dictionary = dictionary4;
		}
		int num = 0;
		foreach (string key7 in dictionary.Keys)
		{
			List<Renderer> list2 = dictionary[key7];
			if (list2.Count > 1 || grouper.data.includeCellsWithOnlyOneRenderer)
			{
				list.Add(AddMeshBaker(grouper, tb, key7, list2));
			}
			else
			{
				num++;
			}
		}
		UnityEngine.Debug.Log($"Found {dictionary.Count} cells with Renderers. Not creating bakers for {num} because there is only one mesh in the cell. Creating {dictionary.Count - num} bakers.");
		return list;
	}

	private Dictionary<int, List<Renderer>> GroupByLightmapIndex(List<Renderer> gaws)
	{
		Dictionary<int, List<Renderer>> dictionary = new Dictionary<int, List<Renderer>>();
		for (int i = 0; i < gaws.Count; i++)
		{
			List<Renderer> list = null;
			if (dictionary.ContainsKey(gaws[i].lightmapIndex))
			{
				list = dictionary[gaws[i].lightmapIndex];
			}
			else
			{
				list = new List<Renderer>();
				dictionary.Add(gaws[i].lightmapIndex, list);
			}
			list.Add(gaws[i]);
		}
		return dictionary;
	}

	private MB3_MeshBakerCommon AddMeshBaker(MB3_MeshBakerGrouper grouper, MB3_TextureBaker tb, string key, List<Renderer> gaws)
	{
		int num = 0;
		for (int i = 0; i < gaws.Count; i++)
		{
			Mesh mesh = MB_Utility.GetMesh(gaws[i].gameObject);
			if (mesh != null)
			{
				num += mesh.vertexCount;
			}
		}
		GameObject gameObject = new GameObject("MeshBaker-" + key);
		gameObject.transform.position = Vector3.zero;
		MB3_MeshBakerCommon mB3_MeshBakerCommon;
		if (num >= 65535)
		{
			mB3_MeshBakerCommon = gameObject.AddComponent<MB3_MultiMeshBaker>();
			mB3_MeshBakerCommon.useObjsToMeshFromTexBaker = false;
		}
		else
		{
			mB3_MeshBakerCommon = gameObject.AddComponent<MB3_MeshBaker>();
			mB3_MeshBakerCommon.useObjsToMeshFromTexBaker = false;
		}
		mB3_MeshBakerCommon.textureBakeResults = tb.textureBakeResults;
		mB3_MeshBakerCommon.transform.parent = tb.transform;
		mB3_MeshBakerCommon.meshCombiner.settingsHolder = grouper;
		for (int j = 0; j < gaws.Count; j++)
		{
			mB3_MeshBakerCommon.GetObjectsToCombine().Add(gaws[j].gameObject);
		}
		return mB3_MeshBakerCommon;
	}

	public virtual MB3_MeshBakerGrouper.ClusterType GetClusterType()
	{
		return MB3_MeshBakerGrouper.ClusterType.none;
	}
}
public class MB3_MeshBakerGrouperNone : MB3_MeshBakerGrouperBehaviour
{
	public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
	{
		UnityEngine.Debug.Log("Filtering into groups none");
		Dictionary<string, List<Renderer>> dictionary = new Dictionary<string, List<Renderer>>();
		List<Renderer> list = new List<Renderer>();
		for (int i = 0; i < selection.Count; i++)
		{
			if (selection[i] != null)
			{
				list.Add(selection[i].GetComponent<Renderer>());
			}
		}
		dictionary.Add("MeshBaker", list);
		return dictionary;
	}

	public override void DrawGizmos(Bounds sourceObjectBounds, GrouperData d)
	{
	}

	public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
	{
		return MB3_MeshBakerGrouper.ClusterType.none;
	}
}
public class MB3_MeshBakerGrouperGrid : MB3_MeshBakerGrouperBehaviour
{
	public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
	{
		Dictionary<string, List<Renderer>> dictionary = new Dictionary<string, List<Renderer>>();
		if (d.cellSize.x <= 0f || d.cellSize.y <= 0f || d.cellSize.z <= 0f)
		{
			UnityEngine.Debug.LogError("cellSize x,y,z must all be greater than zero.");
			return dictionary;
		}
		UnityEngine.Debug.Log("Collecting renderers in each cell");
		foreach (GameObject item in selection)
		{
			if (item == null)
			{
				continue;
			}
			Renderer component = item.GetComponent<Renderer>();
			if (component is MeshRenderer || component is SkinnedMeshRenderer)
			{
				Vector3 center = component.bounds.center;
				center.x = Mathf.Floor((center.x - d.origin.x) / d.cellSize.x) * d.cellSize.x;
				center.y = Mathf.Floor((center.y - d.origin.y) / d.cellSize.y) * d.cellSize.y;
				center.z = Mathf.Floor((center.z - d.origin.z) / d.cellSize.z) * d.cellSize.z;
				List<Renderer> list = null;
				string key = center.ToString();
				if (dictionary.ContainsKey(key))
				{
					list = dictionary[key];
				}
				else
				{
					list = new List<Renderer>();
					dictionary.Add(key, list);
				}
				if (!list.Contains(component))
				{
					list.Add(component);
				}
			}
		}
		return dictionary;
	}

	public override void DrawGizmos(Bounds sourceObjectBounds, GrouperData d)
	{
		Vector3 cellSize = d.cellSize;
		if (cellSize.x <= 1E-05f || cellSize.y <= 1E-05f || cellSize.z <= 1E-05f)
		{
			return;
		}
		Gizmos.color = MB3_MeshBakerGrouper.WHITE_TRANSP;
		Vector3 vector = sourceObjectBounds.center - sourceObjectBounds.extents;
		Vector3 origin = d.origin;
		origin.x %= cellSize.x;
		origin.y %= cellSize.y;
		origin.z %= cellSize.z;
		vector.x = Mathf.Round(vector.x / cellSize.x) * cellSize.x + origin.x;
		vector.y = Mathf.Round(vector.y / cellSize.y) * cellSize.y + origin.y;
		vector.z = Mathf.Round(vector.z / cellSize.z) * cellSize.z + origin.z;
		if (vector.x > sourceObjectBounds.center.x - sourceObjectBounds.extents.x)
		{
			vector.x -= cellSize.x;
		}
		if (vector.y > sourceObjectBounds.center.y - sourceObjectBounds.extents.y)
		{
			vector.y -= cellSize.y;
		}
		if (vector.z > sourceObjectBounds.center.z - sourceObjectBounds.extents.z)
		{
			vector.z -= cellSize.z;
		}
		Vector3 vector2 = vector;
		if (Mathf.CeilToInt(sourceObjectBounds.size.x / cellSize.x + sourceObjectBounds.size.y / cellSize.y + sourceObjectBounds.size.z / cellSize.z) > 200)
		{
			Gizmos.DrawWireCube(d.origin + cellSize / 2f, cellSize);
			return;
		}
		while (vector.x < sourceObjectBounds.center.x + sourceObjectBounds.extents.x)
		{
			vector.y = vector2.y;
			while (vector.y < sourceObjectBounds.center.y + sourceObjectBounds.extents.y)
			{
				vector.z = vector2.z;
				while (vector.z < sourceObjectBounds.center.z + sourceObjectBounds.extents.z)
				{
					Gizmos.DrawWireCube(vector + cellSize / 2f, cellSize);
					vector.z += cellSize.z;
				}
				vector.y += cellSize.y;
			}
			vector.x += cellSize.x;
		}
	}

	public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
	{
		return MB3_MeshBakerGrouper.ClusterType.grid;
	}
}
public class MB3_MeshBakerGrouperPie : MB3_MeshBakerGrouperBehaviour
{
	public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
	{
		Dictionary<string, List<Renderer>> dictionary = new Dictionary<string, List<Renderer>>();
		if (d.pieNumSegments == 0)
		{
			UnityEngine.Debug.LogError("pieNumSegments must be greater than zero.");
			return dictionary;
		}
		if (d.pieAxis.magnitude <= 1E-06f)
		{
			UnityEngine.Debug.LogError("Pie axis vector is too short.");
			return dictionary;
		}
		if (d.ringSpacing <= 1E-06f)
		{
			UnityEngine.Debug.LogError("Ring spacing is too small.");
			return dictionary;
		}
		d.pieAxis.Normalize();
		Quaternion quaternion = Quaternion.FromToRotation(d.pieAxis, Vector3.up);
		UnityEngine.Debug.Log("Collecting renderers in each cell");
		foreach (GameObject item in selection)
		{
			if (item == null)
			{
				continue;
			}
			Renderer component = item.GetComponent<Renderer>();
			if (!(component is MeshRenderer) && !(component is SkinnedMeshRenderer))
			{
				continue;
			}
			Vector3 vector = component.bounds.center - d.origin;
			vector = quaternion * vector;
			float magnitude = new Vector2(vector.x, vector.z).magnitude;
			vector.Normalize();
			float num = 0f;
			if (Mathf.Abs(vector.x) < 0.0001f && Mathf.Abs(vector.z) < 0.0001f)
			{
				num = 0f;
			}
			else
			{
				num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				if (num < 0f)
				{
					num = 360f + num;
				}
			}
			int num2 = Mathf.FloorToInt(num / 360f * (float)d.pieNumSegments);
			int num3 = Mathf.FloorToInt(magnitude / d.ringSpacing);
			if (num3 == 0 && d.combineSegmentsInInnermostRing)
			{
				num2 = 0;
			}
			List<Renderer> list = null;
			string key = "seg_" + num2 + "_ring_" + num3;
			if (dictionary.ContainsKey(key))
			{
				list = dictionary[key];
			}
			else
			{
				list = new List<Renderer>();
				dictionary.Add(key, list);
			}
			if (!list.Contains(component))
			{
				list.Add(component);
			}
		}
		return dictionary;
	}

	public override void DrawGizmos(Bounds sourceObjectBounds, GrouperData d)
	{
		if (d.pieAxis.magnitude < 0.1f || d.pieNumSegments < 1)
		{
			return;
		}
		Gizmos.color = MB3_MeshBakerGrouper.WHITE_TRANSP;
		int b = Mathf.CeilToInt(sourceObjectBounds.extents.magnitude / d.ringSpacing);
		b = Mathf.Max(1, b);
		for (int i = 0; i < b; i++)
		{
			DrawCircle(d.pieAxis.normalized, d.origin, d.ringSpacing * (float)(i + 1), 24);
		}
		Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, d.pieAxis);
		Quaternion quaternion2 = Quaternion.AngleAxis(180f / (float)d.pieNumSegments, Vector3.up);
		Vector3 vector = Vector3.forward;
		for (int j = 0; j < d.pieNumSegments; j++)
		{
			Vector3 vector2 = quaternion * vector;
			Vector3 vector3 = d.origin;
			int num = b;
			if (d.combineSegmentsInInnermostRing)
			{
				vector3 = d.origin + vector2.normalized * d.ringSpacing;
				num = b - 1;
			}
			if (num != 0)
			{
				Gizmos.DrawLine(vector3, vector3 + (float)num * d.ringSpacing * vector2.normalized);
				vector = quaternion2 * vector;
				vector = quaternion2 * vector;
				continue;
			}
			break;
		}
	}

	private static int MaxIndexInVector3(Vector3 v)
	{
		int result = 0;
		float num = v.x;
		if (v.y > num)
		{
			result = 1;
			num = v.y;
		}
		if (v.z > num)
		{
			result = 2;
			num = v.z;
		}
		return result;
	}

	public static void DrawCircle(Vector3 axis, Vector3 center, float radius, int subdiv)
	{
		Quaternion quaternion = Quaternion.AngleAxis(360 / subdiv, axis);
		int num = MaxIndexInVector3(axis);
		int index = ((num == 0) ? (num + 1) : (num - 1));
		Vector3 vector = axis;
		float num2 = vector[num];
		vector[num] = vector[index];
		vector[index] = 0f - num2;
		vector = Vector3.ProjectOnPlane(vector, axis);
		vector.Normalize();
		vector *= radius;
		for (int i = 0; i < subdiv + 1; i++)
		{
			Vector3 vector2 = quaternion * vector;
			Gizmos.color = MB3_MeshBakerGrouper.WHITE_TRANSP;
			Gizmos.DrawLine(center + vector, center + vector2);
			vector = vector2;
		}
	}

	public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
	{
		return MB3_MeshBakerGrouper.ClusterType.pie;
	}
}
public class MB3_MeshBakerGrouperCluster : MB3_MeshBakerGrouperBehaviour
{
	public override Dictionary<string, List<Renderer>> FilterIntoGroups(List<GameObject> selection, GrouperData d)
	{
		Dictionary<string, List<Renderer>> dictionary = new Dictionary<string, List<Renderer>>();
		for (int i = 0; i < d._clustersToDraw.Count; i++)
		{
			MB3_AgglomerativeClustering.ClusterNode clusterNode = d._clustersToDraw[i];
			List<Renderer> list = new List<Renderer>();
			for (int j = 0; j < clusterNode.leafs.Length; j++)
			{
				Renderer component = d.cluster.clusters[clusterNode.leafs[j]].leaf.go.GetComponent<Renderer>();
				if (component is MeshRenderer || component is SkinnedMeshRenderer)
				{
					list.Add(component);
				}
			}
			dictionary.Add("Cluster_" + i, list);
		}
		return dictionary;
	}

	public void BuildClusters(List<GameObject> gos, ProgressUpdateCancelableDelegate progFunc, GrouperData d)
	{
		if (gos.Count == 0)
		{
			UnityEngine.Debug.LogWarning("No objects to cluster. Add some objects to the list of Objects To Combine.");
			return;
		}
		if (d.cluster == null)
		{
			d.cluster = new MB3_AgglomerativeClustering();
		}
		List<MB3_AgglomerativeClustering.item_s> list = new List<MB3_AgglomerativeClustering.item_s>();
		int i;
		for (i = 0; i < gos.Count; i++)
		{
			if (gos[i] != null && list.Find((MB3_AgglomerativeClustering.item_s x) => x.go == gos[i]) == null)
			{
				Renderer component = gos[i].GetComponent<Renderer>();
				if (component != null && (component is MeshRenderer || component is SkinnedMeshRenderer))
				{
					MB3_AgglomerativeClustering.item_s item_s = new MB3_AgglomerativeClustering.item_s();
					item_s.go = gos[i];
					item_s.coord = component.bounds.center;
					list.Add(item_s);
				}
			}
		}
		d.cluster.items = list;
		d.cluster.agglomerate(progFunc);
		if (!d.cluster.wasCanceled)
		{
			_BuildListOfClustersToDraw(progFunc, out var smallest, out var largest, d);
			d.maxDistBetweenClusters = Mathf.Lerp(smallest, largest, 0.9f);
		}
	}

	public void _BuildListOfClustersToDraw(ProgressUpdateCancelableDelegate progFunc, out float smallest, out float largest, GrouperData d)
	{
		if (d._clustersToDraw == null)
		{
			d._clustersToDraw = new List<MB3_AgglomerativeClustering.ClusterNode>();
		}
		d._clustersToDraw.Clear();
		if (d.cluster.clusters == null || d.cluster.clusters.Length == 0)
		{
			smallest = 1f;
			largest = 10f;
		}
		else
		{
			progFunc?.Invoke("Building Clusters To Draw A:", 0f);
			largest = 1f;
			smallest = 10000000f;
			for (int i = 0; i < d.cluster.clusters.Length; i++)
			{
				MB3_AgglomerativeClustering.ClusterNode clusterNode = d.cluster.clusters[i];
				if (clusterNode.distToMergedCentroid <= d.maxDistBetweenClusters)
				{
					if (d.includeCellsWithOnlyOneRenderer)
					{
						d._clustersToDraw.Add(clusterNode);
					}
					else if (clusterNode.leaf == null)
					{
						d._clustersToDraw.Add(clusterNode);
					}
				}
				if (clusterNode.distToMergedCentroid > largest)
				{
					largest = clusterNode.distToMergedCentroid;
				}
				if (clusterNode.height > 0 && clusterNode.distToMergedCentroid < smallest)
				{
					smallest = clusterNode.distToMergedCentroid;
				}
			}
		}
		progFunc?.Invoke("Building Clusters To Draw B:", 0f);
		List<MB3_AgglomerativeClustering.ClusterNode> list = new List<MB3_AgglomerativeClustering.ClusterNode>();
		for (int j = 0; j < d._clustersToDraw.Count; j++)
		{
			list.Add(d._clustersToDraw[j].cha);
			list.Add(d._clustersToDraw[j].chb);
		}
		for (int k = 0; k < list.Count; k++)
		{
			d._clustersToDraw.Remove(list[k]);
		}
		d._radii = new float[d._clustersToDraw.Count];
		progFunc?.Invoke("Building Clusters To Draw C:", 0f);
		for (int l = 0; l < d._radii.Length; l++)
		{
			MB3_AgglomerativeClustering.ClusterNode clusterNode2 = d._clustersToDraw[l];
			Bounds bounds = new Bounds(clusterNode2.centroid, Vector3.one);
			for (int m = 0; m < clusterNode2.leafs.Length; m++)
			{
				Renderer component = d.cluster.clusters[clusterNode2.leafs[m]].leaf.go.GetComponent<Renderer>();
				if (component != null)
				{
					bounds.Encapsulate(component.bounds);
				}
			}
			d._radii[l] = bounds.extents.magnitude;
		}
		progFunc?.Invoke("Building Clusters To Draw D:", 0f);
		if (smallest >= largest)
		{
			UnityEngine.Debug.LogError("The smallest distance between clusters is greater than the largest distance between clusters. This should not happen.");
			smallest = 1E-05f;
			if (largest < 10f)
			{
				largest = 10f;
			}
		}
		d._ObjsExtents = largest + 1f;
		d._minDistBetweenClusters = 0.1f * smallest;
		if (d._ObjsExtents < 2f)
		{
			d._ObjsExtents = 2f;
		}
	}

	public override void DrawGizmos(Bounds sceneObjectBounds, GrouperData d)
	{
		if (d.cluster != null && d.cluster.clusters != null)
		{
			Gizmos.color = MB3_MeshBakerGrouper.WHITE_TRANSP;
			for (int i = 0; i < d._clustersToDraw.Count; i++)
			{
				Gizmos.color = MB3_MeshBakerGrouper.WHITE_TRANSP;
				Gizmos.DrawWireSphere(d._clustersToDraw[i].centroid, d._radii[i]);
			}
		}
	}

	public override MB3_MeshBakerGrouper.ClusterType GetClusterType()
	{
		return MB3_MeshBakerGrouper.ClusterType.agglomerative;
	}
}
public interface TextureBlender
{
	bool DoesShaderNameMatch(string shaderName);

	void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName);

	Color OnBlendTexturePixel(string shaderPropertyName, Color pixelColor);

	bool NonTexturePropertiesAreEqual(Material a, Material b);

	void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial);

	Color GetColorIfNoTexture(Material m, ShaderTextureProperty texPropertyName);
}
public class TextureBlenderFallback : TextureBlender
{
	private bool m_doTintColor;

	private Color m_tintColor;

	private Color m_defaultColor = Color.white;

	public bool DoesShaderNameMatch(string shaderName)
	{
		return true;
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (shaderTexturePropertyName.Equals("_MainTex"))
		{
			m_doTintColor = true;
			m_tintColor = Color.white;
			if (sourceMat.HasProperty("_Color"))
			{
				m_tintColor = sourceMat.GetColor("_Color");
			}
			else if (sourceMat.HasProperty("_TintColor"))
			{
				m_tintColor = sourceMat.GetColor("_TintColor");
			}
		}
		else
		{
			m_doTintColor = false;
		}
	}

	public Color OnBlendTexturePixel(string shaderPropertyName, Color pixelColor)
	{
		if (m_doTintColor)
		{
			return new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		if (a.HasProperty("_Color"))
		{
			if (_compareColor(a, b, m_defaultColor, "_Color"))
			{
				return true;
			}
		}
		else if (a.HasProperty("_TintColor") && _compareColor(a, b, m_defaultColor, "_TintColor"))
		{
			return true;
		}
		return false;
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		if (resultMaterial.HasProperty("_Color"))
		{
			resultMaterial.SetColor("_Color", m_defaultColor);
		}
		else if (resultMaterial.HasProperty("_TintColor"))
		{
			resultMaterial.SetColor("_TintColor", m_defaultColor);
		}
	}

	public static Color GetDefaultNormalMapColor()
	{
		if (MBVersion.IsSwizzledNormalMapPlatform())
		{
			return new Color(1f, 0.5f, 0.5f, 0.5f);
		}
		return new Color(0.5f, 0.5f, 1f, 0.5f);
	}

	public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texProperty)
	{
		if (texProperty.isNormalMap)
		{
			return GetDefaultNormalMapColor();
		}
		if (texProperty.name.Equals("_MainTex"))
		{
			if (mat != null && mat.HasProperty("_Color"))
			{
				return Color.white;
			}
			if (mat != null && mat.HasProperty("_TintColor"))
			{
				return Color.white;
			}
		}
		else if (texProperty.name.Equals("_SpecGlossMap"))
		{
			if (mat != null && mat.HasProperty("_SpecColor"))
			{
				try
				{
					Color color = mat.GetColor("_SpecColor");
					if (mat.HasProperty("_Glossiness"))
					{
						try
						{
							color.a = mat.GetFloat("_Glossiness");
						}
						catch (Exception)
						{
						}
					}
					return color;
				}
				catch (Exception)
				{
				}
			}
		}
		else if (texProperty.name.Equals("_MetallicGlossMap"))
		{
			if (mat != null && mat.HasProperty("_Metallic"))
			{
				try
				{
					float num = mat.GetFloat("_Metallic");
					Color result = new Color(num, num, num);
					if (mat.HasProperty("_Glossiness"))
					{
						try
						{
							result.a = mat.GetFloat("_Glossiness");
						}
						catch (Exception)
						{
						}
					}
					return result;
				}
				catch (Exception)
				{
				}
			}
		}
		else
		{
			if (texProperty.name.Equals("_ParallaxMap"))
			{
				return new Color(0f, 0f, 0f, 0f);
			}
			if (texProperty.name.Equals("_OcclusionMap"))
			{
				return new Color(1f, 1f, 1f, 1f);
			}
			if (texProperty.name.Equals("_EmissionMap"))
			{
				if (mat != null && mat.HasProperty("_EmissionScaleUI"))
				{
					if (mat.HasProperty("_EmissionColor") && mat.HasProperty("_EmissionColorUI"))
					{
						try
						{
							Color color2 = mat.GetColor("_EmissionColor");
							Color color3 = mat.GetColor("_EmissionColorUI");
							float num2 = mat.GetFloat("_EmissionScaleUI");
							if (color2 == new Color(0f, 0f, 0f, 0f) && color3 == new Color(1f, 1f, 1f, 1f))
							{
								return new Color(num2, num2, num2, num2);
							}
							return color3;
						}
						catch (Exception)
						{
						}
					}
					else
					{
						try
						{
							float num3 = mat.GetFloat("_EmissionScaleUI");
							return new Color(num3, num3, num3, num3);
						}
						catch (Exception)
						{
						}
					}
				}
			}
			else if (texProperty.name.Equals("_DetailMask"))
			{
				return new Color(0f, 0f, 0f, 0f);
			}
		}
		return new Color(1f, 1f, 1f, 0f);
	}

	public static bool _compareColor(Material a, Material b, Color defaultVal, string propertyName)
	{
		Color color = defaultVal;
		Color color2 = defaultVal;
		if (a.HasProperty(propertyName))
		{
			color = a.GetColor(propertyName);
		}
		if (b.HasProperty(propertyName))
		{
			color2 = b.GetColor(propertyName);
		}
		if (color != color2)
		{
			return false;
		}
		return true;
	}

	public static bool _compareFloat(Material a, Material b, float defaultVal, string propertyName)
	{
		float num = defaultVal;
		float num2 = defaultVal;
		if (a.HasProperty(propertyName))
		{
			num = a.GetFloat(propertyName);
		}
		if (b.HasProperty(propertyName))
		{
			num2 = b.GetFloat(propertyName);
		}
		if (num != num2)
		{
			return false;
		}
		return true;
	}
}
public class TextureBlenderHDRPLit : TextureBlender
{
	private enum Prop
	{
		doColor,
		doMask,
		doSpecular,
		doEmission,
		doNone
	}

	private enum MaterialType
	{
		unknown,
		subsurfaceScattering,
		standard,
		anisotropy,
		iridescence,
		specularColor,
		translucent
	}

	private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache = new TextureBlenderMaterialPropertyCacheHelper();

	private MaterialType m_materialType;

	private Color m_tintColor;

	private bool m_hasMaskMap;

	private float m_smoothness;

	private float m_metallic;

	private bool m_hasSpecMap;

	private Color m_specularColor;

	private Color m_emissiveColor;

	private Prop propertyToDo = Prop.doNone;

	private Color m_generatingTintedAtlaColor = Color.white;

	private Color m_generatingTintedAtlaSpecular = Color.white;

	private Color m_generatingTintedAtlaEmission = Color.white;

	private Color m_notGeneratingAtlasDefaultColor = Color.white;

	private float m_notGeneratingAtlasDefaultMetallic;

	private float m_notGeneratingAtlasDefaultSmoothness = 0.5f;

	private Color m_notGeneratingAtlasDefaultSpecular = Color.white;

	private Color m_notGeneratingAtlasDefaultEmissiveColor = Color.black;

	public bool DoesShaderNameMatch(string shaderName)
	{
		return shaderName.Equals("HDRP/Lit");
	}

	private MaterialType _MapFloatToMaterialType(float materialType)
	{
		if (materialType == 0f)
		{
			return MaterialType.subsurfaceScattering;
		}
		if (materialType == 1f)
		{
			return MaterialType.standard;
		}
		if (materialType == 2f)
		{
			return MaterialType.anisotropy;
		}
		if (materialType == 3f)
		{
			return MaterialType.iridescence;
		}
		if (materialType == 4f)
		{
			return MaterialType.specularColor;
		}
		if (materialType == 5f)
		{
			return MaterialType.translucent;
		}
		return MaterialType.unknown;
	}

	private float _MapMaterialTypeToFloat(MaterialType materialType)
	{
		return materialType switch
		{
			MaterialType.subsurfaceScattering => 0f, 
			MaterialType.standard => 1f, 
			MaterialType.anisotropy => 2f, 
			MaterialType.iridescence => 3f, 
			MaterialType.specularColor => 4f, 
			MaterialType.translucent => 5f, 
			_ => -1f, 
		};
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (m_materialType == MaterialType.unknown)
		{
			if (sourceMat.HasProperty("_MaterialID"))
			{
				m_materialType = _MapFloatToMaterialType(sourceMat.GetFloat("_MaterialID"));
			}
		}
		else if (sourceMat.HasProperty("_MaterialID") && _MapFloatToMaterialType(sourceMat.GetFloat("_MaterialID")) != m_materialType)
		{
			UnityEngine.Debug.LogError("Using the High Definition Render Pipeline TextureBlender to blend non-texture-properties. Some of the source materials use different 'MaterialType'. These  cannot be blended properly. Results will be unpredictable.");
		}
		if (shaderTexturePropertyName.Equals("_BaseColorMap"))
		{
			propertyToDo = Prop.doColor;
			if (sourceMat.HasProperty("_BaseColor"))
			{
				m_tintColor = sourceMat.GetColor("_BaseColor");
			}
			else
			{
				m_tintColor = m_notGeneratingAtlasDefaultColor;
			}
		}
		else if (shaderTexturePropertyName.Equals("_MaskMap"))
		{
			propertyToDo = Prop.doMask;
			if (sourceMat.HasProperty("_MaskMap") && sourceMat.GetTexture("_MaskMap") != null)
			{
				m_hasMaskMap = true;
				return;
			}
			m_hasMaskMap = false;
			if (m_materialType == MaterialType.standard && sourceMat.HasProperty("_Metallic"))
			{
				m_metallic = sourceMat.GetFloat("_Metallic");
			}
			else
			{
				m_metallic = m_notGeneratingAtlasDefaultMetallic;
			}
			if (sourceMat.HasProperty("_Smoothness"))
			{
				m_smoothness = sourceMat.GetFloat("_Smoothness");
			}
			else
			{
				m_smoothness = m_notGeneratingAtlasDefaultSmoothness;
			}
		}
		else if (shaderTexturePropertyName.Equals("_SpecularColorMap") && m_materialType == MaterialType.specularColor)
		{
			propertyToDo = Prop.doSpecular;
			if (sourceMat.HasProperty("_SpecularColorMap") && sourceMat.GetTexture("_SpecularColorMap") != null)
			{
				m_hasSpecMap = true;
			}
			else
			{
				m_hasSpecMap = false;
			}
			if (sourceMat.HasProperty("_SpecularColor"))
			{
				m_specularColor = sourceMat.GetColor("_SpecularColor");
			}
		}
		else if (shaderTexturePropertyName.Equals("_EmissiveColorMap"))
		{
			propertyToDo = Prop.doEmission;
			if (sourceMat.HasProperty("_EmissiveColor"))
			{
				m_emissiveColor = sourceMat.GetColor("_EmissiveColor");
			}
			else
			{
				m_emissiveColor = m_notGeneratingAtlasDefaultEmissiveColor;
			}
		}
		else
		{
			propertyToDo = Prop.doNone;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (propertyToDo == Prop.doColor)
		{
			return new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
		}
		if (propertyToDo == Prop.doMask)
		{
			if (m_hasMaskMap)
			{
				return new Color(pixelColor.r * m_metallic, pixelColor.g, pixelColor.b, pixelColor.a * m_smoothness);
			}
			return new Color(m_metallic, 0f, 0f, m_smoothness);
		}
		if (propertyToDo == Prop.doSpecular)
		{
			if (m_hasSpecMap)
			{
				return new Color(pixelColor.r * m_specularColor.r, pixelColor.g * m_specularColor.g, pixelColor.b * m_specularColor.g, pixelColor.a * m_specularColor.a);
			}
			return m_specularColor;
		}
		if (propertyToDo == Prop.doEmission)
		{
			return new Color(pixelColor.r * m_emissiveColor.r, pixelColor.g * m_emissiveColor.g, pixelColor.b * m_emissiveColor.b, pixelColor.a * m_emissiveColor.a);
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		if (!TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaColor, "_BaseColor"))
		{
			return false;
		}
		bool num = a.HasProperty("_MaskMap") && a.GetTexture("_MaskMap") != null;
		bool flag = b.HasProperty("_MaskMap") && b.GetTexture("_MaskMap") != null;
		if (!num && !flag && !TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultMetallic, "_Metallic") && !TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultSmoothness, "_Smoothness"))
		{
			return false;
		}
		if (m_materialType == MaterialType.specularColor && !TextureBlenderFallback._compareColor(a, b, m_notGeneratingAtlasDefaultSpecular, "_SpecularColor"))
		{
			return false;
		}
		if (!TextureBlenderFallback._compareColor(a, b, m_notGeneratingAtlasDefaultEmissiveColor, "_EmissiveColor"))
		{
			return false;
		}
		return true;
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		if (m_materialType != MaterialType.unknown)
		{
			resultMaterial.SetFloat("_MaterialID", _MapMaterialTypeToFloat(m_materialType));
		}
		if (resultMaterial.GetTexture("_BaseColorMap") != null)
		{
			resultMaterial.SetColor("_BaseColor", m_generatingTintedAtlaColor);
		}
		else
		{
			resultMaterial.SetColor("_BaseColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_BaseColor", m_notGeneratingAtlasDefaultColor));
		}
		if (!(resultMaterial.GetTexture("_MaskMap") != null))
		{
			resultMaterial.SetFloat("_Metallic", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Metallic", m_notGeneratingAtlasDefaultMetallic));
			resultMaterial.SetFloat("_Smoothness", m_notGeneratingAtlasDefaultSmoothness);
		}
		if (m_materialType == MaterialType.specularColor)
		{
			if (resultMaterial.GetTexture("_SpecularColorMap") != null)
			{
				resultMaterial.SetColor("_SpecularColor", m_generatingTintedAtlaSpecular);
				resultMaterial.SetFloat("_AORemapMin", 1f);
			}
			else
			{
				resultMaterial.SetColor("_SpecularColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_SpecularColor", m_notGeneratingAtlasDefaultSpecular));
				resultMaterial.SetFloat("_AORemapMin", 1f);
			}
		}
		if (resultMaterial.GetTexture("_EmissiveColorMap") != null)
		{
			resultMaterial.SetColor("_EmissiveColor", m_generatingTintedAtlaEmission);
		}
		else
		{
			resultMaterial.SetColor("_EmissiveColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_EmissiveColor", m_notGeneratingAtlasDefaultEmissiveColor));
		}
	}

	public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_BaseColorMap"))
		{
			if (mat != null && mat.HasProperty("_BaseColor"))
			{
				return m_notGeneratingAtlasDefaultColor;
			}
		}
		else
		{
			if (texPropertyName.name.Equals("_BumpMap"))
			{
				return TextureBlenderFallback.GetDefaultNormalMapColor();
			}
			if (texPropertyName.name.Equals("_Metallic"))
			{
				if (mat != null && mat.HasProperty("_Metallic"))
				{
					try
					{
						float num = mat.GetFloat("_Metallic");
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Metallic", num);
					}
					catch (Exception)
					{
					}
					return new Color(0f, 0f, 0f, m_notGeneratingAtlasDefaultSmoothness);
				}
				return new Color(0f, 0f, 0f, m_notGeneratingAtlasDefaultSmoothness);
			}
			if (texPropertyName.name.Equals("_Smoothness"))
			{
				if (mat != null && mat.HasProperty("_Smoothness"))
				{
					try
					{
						float num2 = mat.GetFloat("_Smoothness");
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Smoothness", num2);
					}
					catch (Exception)
					{
					}
					return new Color(0f, 0f, 0f, m_notGeneratingAtlasDefaultSmoothness);
				}
				return new Color(0f, 0f, 0f, m_notGeneratingAtlasDefaultSmoothness);
			}
			if (texPropertyName.name.Equals("_SpecularColorMap"))
			{
				if (mat != null && mat.HasProperty("_SpecularColor"))
				{
					try
					{
						Color color = mat.GetColor("_SpecularColor");
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_SpecularColor", color);
					}
					catch (Exception)
					{
					}
				}
				return m_notGeneratingAtlasDefaultSpecular;
			}
			if (texPropertyName.name.Equals("_EmissiveColorMap") && mat != null)
			{
				if (!mat.HasProperty("_EmissiveColor"))
				{
					return m_notGeneratingAtlasDefaultEmissiveColor;
				}
				try
				{
					Color color2 = mat.GetColor("_EmissiveColor");
					sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_EmissiveColor", color2);
				}
				catch (Exception)
				{
				}
			}
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
public class TextureBlenderLegacyBumpDiffuse : TextureBlender
{
	private bool doColor;

	private Color m_tintColor;

	private Color m_defaultTintColor = Color.white;

	public bool DoesShaderNameMatch(string shaderName)
	{
		if (shaderName.Equals("Legacy Shaders/Bumped Diffuse"))
		{
			return true;
		}
		if (shaderName.Equals("Bumped Diffuse"))
		{
			return true;
		}
		return false;
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (shaderTexturePropertyName.EndsWith("_MainTex"))
		{
			doColor = true;
			m_tintColor = sourceMat.GetColor("_Color");
		}
		else
		{
			doColor = false;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (doColor)
		{
			return new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		return TextureBlenderFallback._compareColor(a, b, m_defaultTintColor, "_Color");
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		resultMaterial.SetColor("_Color", Color.white);
	}

	public Color GetColorIfNoTexture(Material m, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_BumpMap"))
		{
			return TextureBlenderFallback.GetDefaultNormalMapColor();
		}
		if (texPropertyName.name.Equals("_MainTex"))
		{
			return Color.white;
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
public class TextureBlenderLegacyDiffuse : TextureBlender
{
	private bool doColor;

	private Color m_tintColor;

	private Color m_defaultTintColor = Color.white;

	public bool DoesShaderNameMatch(string shaderName)
	{
		if (shaderName.Equals("Legacy Shaders/Diffuse"))
		{
			return true;
		}
		if (shaderName.Equals("Diffuse"))
		{
			return true;
		}
		return false;
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (shaderTexturePropertyName.EndsWith("_MainTex"))
		{
			doColor = true;
			m_tintColor = sourceMat.GetColor("_Color");
		}
		else
		{
			doColor = false;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (doColor)
		{
			return new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		return TextureBlenderFallback._compareColor(a, b, m_defaultTintColor, "_Color");
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		resultMaterial.SetColor("_Color", Color.white);
	}

	public Color GetColorIfNoTexture(Material m, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_MainTex") && m != null && m.HasProperty("_Color"))
		{
			return Color.white;
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
public class TextureBlenderMaterialPropertyCacheHelper
{
	private struct MaterialPropertyPair(Material m, string prop)
	{
		public Material material = m;

		public string property = prop;

		public override bool Equals(object obj)
		{
			if (!(obj is MaterialPropertyPair materialPropertyPair))
			{
				return false;
			}
			if (!material.Equals(materialPropertyPair.material))
			{
				return false;
			}
			if (property != materialPropertyPair.property)
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}

	private Dictionary<MaterialPropertyPair, object> nonTexturePropertyValuesForSourceMaterials = new Dictionary<MaterialPropertyPair, object>();

	private bool AllNonTexturePropertyValuesAreEqual(string prop)
	{
		bool flag = false;
		object obj = null;
		foreach (MaterialPropertyPair key in nonTexturePropertyValuesForSourceMaterials.Keys)
		{
			if (key.property.Equals(prop))
			{
				if (!flag)
				{
					obj = nonTexturePropertyValuesForSourceMaterials[key];
					flag = true;
				}
				else if (!obj.Equals(nonTexturePropertyValuesForSourceMaterials[key]))
				{
					return false;
				}
			}
		}
		return true;
	}

	public void CacheMaterialProperty(Material m, string property, object value)
	{
		nonTexturePropertyValuesForSourceMaterials[new MaterialPropertyPair(m, property)] = value;
	}

	public object GetValueIfAllSourceAreTheSameOrDefault(string property, object defaultValue)
	{
		if (AllNonTexturePropertyValuesAreEqual(property))
		{
			foreach (MaterialPropertyPair key in nonTexturePropertyValuesForSourceMaterials.Keys)
			{
				if (key.property.Equals(property))
				{
					return nonTexturePropertyValuesForSourceMaterials[key];
				}
			}
		}
		return defaultValue;
	}
}
public class TextureBlenderStandardMetallic : TextureBlender
{
	private enum Prop
	{
		doColor,
		doMetallic,
		doEmission,
		doBump,
		doNone
	}

	private static Color NeutralNormalMap = new Color(0.5f, 0.5f, 1f);

	private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache = new TextureBlenderMaterialPropertyCacheHelper();

	private Color m_tintColor;

	private bool m_doScaleAlphaCutoff;

	private float m_alphaCutoff;

	private float m_glossiness;

	private float m_glossMapScale;

	private float m_metallic;

	private bool m_hasMetallicGlossMap;

	private float m_bumpScale;

	private bool m_shaderDoesEmission;

	private Color m_emissionColor;

	private Prop propertyToDo = Prop.doNone;

	private Color m_generatingTintedAtlasColor = Color.white;

	private float m_generatingTintedAtlasMetallic;

	private float m_generatingTintedAtlasGlossiness = 1f;

	private float m_generatingTintedAtlasGlossMapScale = 1f;

	private float m_generatingTintedAtlasBumpScale = 1f;

	private Color m_generatingTintedAtlasEmission = Color.white;

	private const float m_generatedAlphaCutoff = 0.5f;

	private Color m_notGeneratingAtlasDefaultColor = Color.white;

	private float m_notGeneratingAtlasDefaultMetallic;

	private float m_notGeneratingAtlasDefaultGlossiness = 0.5f;

	private Color m_notGeneratingAtlasDefaultEmisionColor = Color.black;

	public bool DoesShaderNameMatch(string shaderName)
	{
		if (!shaderName.Equals("Standard"))
		{
			return shaderName.EndsWith("StandardTextureArray");
		}
		return true;
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (shaderTexturePropertyName.Equals("_MainTex"))
		{
			propertyToDo = Prop.doColor;
			if (sourceMat.HasProperty("_Color"))
			{
				m_tintColor = sourceMat.GetColor("_Color");
			}
			else
			{
				m_tintColor = m_generatingTintedAtlasColor;
			}
			if (sourceMat.HasProperty("_Mode") && sourceMat.HasProperty("_Cutoff") && sourceMat.GetFloat("_Mode") == 1f)
			{
				m_doScaleAlphaCutoff = true;
				m_alphaCutoff = sourceMat.GetFloat("_Cutoff");
				m_alphaCutoff = Mathf.Clamp(m_alphaCutoff, 0.0001f, 0.9999f);
			}
			else
			{
				m_doScaleAlphaCutoff = false;
				m_alphaCutoff = 0.5f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_MetallicGlossMap"))
		{
			propertyToDo = Prop.doMetallic;
			m_metallic = m_generatingTintedAtlasMetallic;
			if (sourceMat.GetTexture("_MetallicGlossMap") != null)
			{
				m_hasMetallicGlossMap = true;
			}
			else
			{
				m_hasMetallicGlossMap = false;
			}
			if (sourceMat.HasProperty("_Metallic"))
			{
				m_metallic = sourceMat.GetFloat("_Metallic");
			}
			else
			{
				m_metallic = 0f;
			}
			if (sourceMat.HasProperty("_GlossMapScale"))
			{
				m_glossMapScale = sourceMat.GetFloat("_GlossMapScale");
			}
			else
			{
				m_glossMapScale = 1f;
			}
			if (sourceMat.HasProperty("_Glossiness"))
			{
				m_glossiness = sourceMat.GetFloat("_Glossiness");
			}
			else
			{
				m_glossiness = 0f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_BumpMap"))
		{
			propertyToDo = Prop.doBump;
			if (sourceMat.HasProperty(shaderTexturePropertyName))
			{
				if (sourceMat.HasProperty("_BumpScale"))
				{
					m_bumpScale = sourceMat.GetFloat("_BumpScale");
				}
			}
			else
			{
				m_bumpScale = m_generatingTintedAtlasBumpScale;
			}
		}
		else if (shaderTexturePropertyName.Equals("_EmissionMap"))
		{
			propertyToDo = Prop.doEmission;
			m_shaderDoesEmission = sourceMat.IsKeywordEnabled("_EMISSION");
			if (sourceMat.HasProperty("_EmissionColor"))
			{
				m_emissionColor = sourceMat.GetColor("_EmissionColor");
			}
			else
			{
				m_emissionColor = m_notGeneratingAtlasDefaultEmisionColor;
			}
		}
		else
		{
			propertyToDo = Prop.doNone;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (propertyToDo == Prop.doColor)
		{
			Color result = new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
			if (m_doScaleAlphaCutoff)
			{
				if (result.a >= m_alphaCutoff)
				{
					result.a = 0.5f + 0.5f * (result.a - m_alphaCutoff) / (1f - m_alphaCutoff);
				}
				else
				{
					result.a = 0.5f * result.a / m_alphaCutoff;
				}
			}
			return result;
		}
		if (propertyToDo == Prop.doMetallic)
		{
			if (m_hasMetallicGlossMap)
			{
				pixelColor = new Color(pixelColor.r, pixelColor.g, pixelColor.b, pixelColor.a * m_glossMapScale);
				return pixelColor;
			}
			return new Color(m_metallic, 0f, 0f, m_glossiness);
		}
		if (propertyToDo == Prop.doBump)
		{
			return Color.Lerp(NeutralNormalMap, pixelColor, m_bumpScale);
		}
		if (propertyToDo == Prop.doEmission)
		{
			if (m_shaderDoesEmission)
			{
				return new Color(pixelColor.r * m_emissionColor.r, pixelColor.g * m_emissionColor.g, pixelColor.b * m_emissionColor.b, pixelColor.a * m_emissionColor.a);
			}
			return Color.black;
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		if (!TextureBlenderFallback._compareColor(a, b, m_notGeneratingAtlasDefaultColor, "_Color"))
		{
			return false;
		}
		if (a.HasProperty("_Mode") && b.HasProperty("_Mode") && a.GetFloat("_Mode") == 1f && b.GetFloat("_Mode") == 1f && a.HasProperty("_Cutoff") && b.HasProperty("_Cutoff") && a.HasProperty("_Cutoff") != b.HasProperty("_Cutoff"))
		{
			return false;
		}
		if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultGlossiness, "_Glossiness"))
		{
			return false;
		}
		bool flag = a.HasProperty("_MetallicGlossMap") && a.GetTexture("_MetallicGlossMap") != null;
		bool flag2 = b.HasProperty("_MetallicGlossMap") && b.GetTexture("_MetallicGlossMap") != null;
		if (flag && flag2)
		{
			if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultMetallic, "_GlossMapScale"))
			{
				return false;
			}
		}
		else
		{
			if (flag || flag2)
			{
				return false;
			}
			if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultMetallic, "_Metallic"))
			{
				return false;
			}
		}
		if (a.IsKeywordEnabled("_EMISSION") != b.IsKeywordEnabled("_EMISSION"))
		{
			return false;
		}
		if (a.IsKeywordEnabled("_EMISSION") && !TextureBlenderFallback._compareColor(a, b, m_notGeneratingAtlasDefaultEmisionColor, "_EmissionColor"))
		{
			return false;
		}
		return true;
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		if (resultMaterial.GetTexture("_MainTex") != null)
		{
			resultMaterial.SetColor("_Color", m_generatingTintedAtlasColor);
			if (resultMaterial.GetFloat("_Mode") == 1f)
			{
				resultMaterial.SetFloat("_Cutoff", 0.5f);
			}
		}
		else
		{
			resultMaterial.SetColor("_Color", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Color", m_notGeneratingAtlasDefaultColor));
		}
		if (resultMaterial.GetTexture("_MetallicGlossMap") != null)
		{
			resultMaterial.SetFloat("_Metallic", m_generatingTintedAtlasMetallic);
			resultMaterial.SetFloat("_GlossMapScale", m_generatingTintedAtlasGlossMapScale);
			resultMaterial.SetFloat("_Glossiness", m_generatingTintedAtlasGlossiness);
		}
		else
		{
			resultMaterial.SetFloat("_Metallic", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Metallic", m_notGeneratingAtlasDefaultMetallic));
			resultMaterial.SetFloat("_Glossiness", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Glossiness", m_notGeneratingAtlasDefaultGlossiness));
		}
		if (resultMaterial.GetTexture("_BumpMap") != null)
		{
			resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlasBumpScale);
		}
		if (resultMaterial.GetTexture("_EmissionMap") != null)
		{
			resultMaterial.EnableKeyword("_EMISSION");
			resultMaterial.SetColor("_EmissionColor", m_generatingTintedAtlasEmission);
		}
		else
		{
			resultMaterial.DisableKeyword("_EMISSION");
			resultMaterial.SetColor("_EmissionColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_EmissionColor", m_notGeneratingAtlasDefaultEmisionColor));
		}
	}

	public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_BumpMap"))
		{
			return TextureBlenderFallback.GetDefaultNormalMapColor();
		}
		if (texPropertyName.name.Equals("_MainTex"))
		{
			if (mat != null && mat.HasProperty("_Color"))
			{
				return Color.white;
			}
		}
		else
		{
			if (texPropertyName.name.Equals("_MetallicGlossMap"))
			{
				if (mat != null && mat.HasProperty("_Metallic"))
				{
					try
					{
						float num = mat.GetFloat("_Metallic");
						Color result = new Color(num, num, num);
						if (mat.HasProperty("_Glossiness"))
						{
							try
							{
								result.a = mat.GetFloat("_Glossiness");
							}
							catch (Exception)
							{
							}
						}
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Metallic", num);
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Glossiness", result.a);
						return result;
					}
					catch (Exception)
					{
					}
					return new Color(0f, 0f, 0f, 0.5f);
				}
				return new Color(0f, 0f, 0f, 0.5f);
			}
			if (texPropertyName.name.Equals("_ParallaxMap"))
			{
				return new Color(0f, 0f, 0f, 0f);
			}
			if (texPropertyName.name.Equals("_OcclusionMap"))
			{
				return new Color(1f, 1f, 1f, 1f);
			}
			if (texPropertyName.name.Equals("_EmissionMap"))
			{
				if (mat != null)
				{
					if (!mat.IsKeywordEnabled("_EMISSION"))
					{
						return Color.black;
					}
					if (!mat.HasProperty("_EmissionColor"))
					{
						return Color.black;
					}
					try
					{
						Color color = mat.GetColor("_EmissionColor");
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_EmissionColor", color);
						return color;
					}
					catch (Exception)
					{
					}
				}
			}
			else if (texPropertyName.name.Equals("_DetailMask"))
			{
				return new Color(0f, 0f, 0f, 0f);
			}
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
public class TextureBlenderStandardMetallicRoughness : TextureBlender
{
	private enum Prop
	{
		doColor,
		doMetallic,
		doRoughness,
		doEmission,
		doBump,
		doNone
	}

	private static Color NeutralNormalMap = new Color(0.5f, 0.5f, 1f);

	private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache = new TextureBlenderMaterialPropertyCacheHelper();

	private Color m_tintColor;

	private float m_roughness;

	private float m_metallic;

	private bool m_hasMetallicGlossMap;

	private bool m_hasSpecGlossMap;

	private float m_bumpScale;

	private bool m_shaderDoesEmission;

	private Color m_emissionColor;

	private Prop propertyToDo = Prop.doNone;

	private Color m_generatingTintedAtlasColor = Color.white;

	private float m_generatingTintedAtlasMetallic;

	private float m_generatingTintedAtlasRoughness = 0.5f;

	private float m_generatingTintedAtlasBumpScale = 1f;

	private Color m_generatingTintedAtlasEmission = Color.white;

	private Color m_notGeneratingAtlasDefaultColor = Color.white;

	private float m_notGeneratingAtlasDefaultMetallic;

	private float m_notGeneratingAtlasDefaultGlossiness = 0.5f;

	private Color m_notGeneratingAtlasDefaultEmisionColor = Color.black;

	public bool DoesShaderNameMatch(string shaderName)
	{
		return shaderName.Equals("Standard (Roughness setup)");
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (shaderTexturePropertyName.Equals("_MainTex"))
		{
			propertyToDo = Prop.doColor;
			if (sourceMat.HasProperty("_Color"))
			{
				m_tintColor = sourceMat.GetColor("_Color");
			}
			else
			{
				m_tintColor = m_generatingTintedAtlasColor;
			}
		}
		else if (shaderTexturePropertyName.Equals("_MetallicGlossMap"))
		{
			propertyToDo = Prop.doMetallic;
			m_metallic = m_generatingTintedAtlasMetallic;
			if (sourceMat.GetTexture("_MetallicGlossMap") != null)
			{
				m_hasMetallicGlossMap = true;
			}
			else
			{
				m_hasMetallicGlossMap = false;
			}
			if (sourceMat.HasProperty("_Metallic"))
			{
				m_metallic = sourceMat.GetFloat("_Metallic");
			}
			else
			{
				m_metallic = 0f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_SpecGlossMap"))
		{
			propertyToDo = Prop.doRoughness;
			m_roughness = m_generatingTintedAtlasRoughness;
			if (sourceMat.GetTexture("_SpecGlossMap") != null)
			{
				m_hasSpecGlossMap = true;
			}
			else
			{
				m_hasSpecGlossMap = false;
			}
			if (sourceMat.HasProperty("_Glossiness"))
			{
				m_roughness = sourceMat.GetFloat("_Glossiness");
			}
			else
			{
				m_roughness = 1f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_BumpMap"))
		{
			propertyToDo = Prop.doBump;
			if (sourceMat.HasProperty(shaderTexturePropertyName))
			{
				if (sourceMat.HasProperty("_BumpScale"))
				{
					m_bumpScale = sourceMat.GetFloat("_BumpScale");
				}
			}
			else
			{
				m_bumpScale = m_generatingTintedAtlasBumpScale;
			}
		}
		else if (shaderTexturePropertyName.Equals("_EmissionMap"))
		{
			propertyToDo = Prop.doEmission;
			m_shaderDoesEmission = sourceMat.IsKeywordEnabled("_EMISSION");
			if (sourceMat.HasProperty("_EmissionColor"))
			{
				m_emissionColor = sourceMat.GetColor("_EmissionColor");
			}
			else
			{
				m_emissionColor = m_notGeneratingAtlasDefaultEmisionColor;
			}
		}
		else
		{
			propertyToDo = Prop.doNone;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (propertyToDo == Prop.doColor)
		{
			return new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
		}
		if (propertyToDo == Prop.doMetallic)
		{
			if (m_hasMetallicGlossMap)
			{
				return pixelColor;
			}
			return new Color(m_metallic, 0f, 0f, m_roughness);
		}
		if (propertyToDo == Prop.doRoughness)
		{
			if (m_hasSpecGlossMap)
			{
				return pixelColor;
			}
			return new Color(m_roughness, 0f, 0f, 0f);
		}
		if (propertyToDo == Prop.doBump)
		{
			return Color.Lerp(NeutralNormalMap, pixelColor, m_bumpScale);
		}
		if (propertyToDo == Prop.doEmission)
		{
			if (m_shaderDoesEmission)
			{
				return new Color(pixelColor.r * m_emissionColor.r, pixelColor.g * m_emissionColor.g, pixelColor.b * m_emissionColor.b, pixelColor.a * m_emissionColor.a);
			}
			return Color.black;
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		if (!TextureBlenderFallback._compareColor(a, b, m_notGeneratingAtlasDefaultColor, "_Color"))
		{
			return false;
		}
		bool num = a.HasProperty("_MetallicGlossMap") && a.GetTexture("_MetallicGlossMap") != null;
		bool flag = b.HasProperty("_MetallicGlossMap") && b.GetTexture("_MetallicGlossMap") != null;
		if (!num && !flag)
		{
			if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultMetallic, "_Metallic"))
			{
				return false;
			}
			bool num2 = a.HasProperty("_SpecGlossMap") && a.GetTexture("_SpecGlossMap") != null;
			bool flag2 = b.HasProperty("_SpecGlossMap") && b.GetTexture("_SpecGlossMap") != null;
			if (!num2 && !flag2)
			{
				if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlasRoughness, "_Glossiness"))
				{
					return false;
				}
				if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlasBumpScale, "_bumpScale"))
				{
					return false;
				}
				if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlasRoughness, "_Glossiness"))
				{
					return false;
				}
				if (a.IsKeywordEnabled("_EMISSION") != b.IsKeywordEnabled("_EMISSION"))
				{
					return false;
				}
				if (a.IsKeywordEnabled("_EMISSION") && !TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlasEmission, "_EmissionColor"))
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return false;
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		if (resultMaterial.GetTexture("_MainTex") != null)
		{
			resultMaterial.SetColor("_Color", m_generatingTintedAtlasColor);
		}
		else
		{
			resultMaterial.SetColor("_Color", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Color", m_notGeneratingAtlasDefaultColor));
		}
		if (resultMaterial.GetTexture("_MetallicGlossMap") != null)
		{
			resultMaterial.SetFloat("_Metallic", m_generatingTintedAtlasMetallic);
		}
		else
		{
			resultMaterial.SetFloat("_Metallic", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Metallic", m_notGeneratingAtlasDefaultMetallic));
		}
		if (!(resultMaterial.GetTexture("_SpecGlossMap") != null))
		{
			resultMaterial.SetFloat("_Glossiness", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Glossiness", m_notGeneratingAtlasDefaultGlossiness));
		}
		if (resultMaterial.GetTexture("_BumpMap") != null)
		{
			resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlasBumpScale);
		}
		else
		{
			resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlasBumpScale);
		}
		if (resultMaterial.GetTexture("_EmissionMap") != null)
		{
			resultMaterial.EnableKeyword("_EMISSION");
			resultMaterial.SetColor("_EmissionColor", Color.white);
		}
		else
		{
			resultMaterial.DisableKeyword("_EMISSION");
			resultMaterial.SetColor("_EmissionColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_EmissionColor", m_notGeneratingAtlasDefaultEmisionColor));
		}
	}

	public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_BumpMap"))
		{
			return TextureBlenderFallback.GetDefaultNormalMapColor();
		}
		if (texPropertyName.name.Equals("_MainTex"))
		{
			if (mat != null && mat.HasProperty("_Color"))
			{
				return Color.white;
			}
		}
		else
		{
			if (texPropertyName.name.Equals("_MetallicGlossMap"))
			{
				if (mat != null && mat.HasProperty("_Metallic"))
				{
					try
					{
						float num = mat.GetFloat("_Metallic");
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Metallic", num);
					}
					catch (Exception)
					{
					}
					return new Color(0f, 0f, 0f, 0.5f);
				}
				return new Color(0f, 0f, 0f, 0.5f);
			}
			if (texPropertyName.name.Equals("_SpecGlossMap"))
			{
				bool flag = false;
				try
				{
					Color color = new Color(0f, 0f, 0f, 0.5f);
					if (mat.HasProperty("_Glossiness"))
					{
						try
						{
							flag = true;
							color.a = mat.GetFloat("_Glossiness");
						}
						catch (Exception)
						{
						}
					}
					sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Glossiness", color.a);
					return new Color(0f, 0f, 0f, 0.5f);
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					return new Color(0f, 0f, 0f, 0.5f);
				}
			}
			else
			{
				if (texPropertyName.name.Equals("_ParallaxMap"))
				{
					return new Color(0f, 0f, 0f, 0f);
				}
				if (texPropertyName.name.Equals("_OcclusionMap"))
				{
					return new Color(1f, 1f, 1f, 1f);
				}
				if (texPropertyName.name.Equals("_EmissionMap"))
				{
					if (mat != null)
					{
						if (!mat.IsKeywordEnabled("_EMISSION"))
						{
							return Color.black;
						}
						if (!mat.HasProperty("_EmissionColor"))
						{
							return Color.black;
						}
						try
						{
							Color color2 = mat.GetColor("_EmissionColor");
							sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_EmissionColor", color2);
							return color2;
						}
						catch (Exception)
						{
						}
					}
				}
				else if (texPropertyName.name.Equals("_DetailMask"))
				{
					return new Color(0f, 0f, 0f, 0f);
				}
			}
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
public class TextureBlenderStandardSpecular : TextureBlender
{
	private enum Prop
	{
		doColor,
		doSpecular,
		doEmission,
		doBump,
		doNone
	}

	private static Color NeutralNormalMap = new Color(0.5f, 0.5f, 1f);

	private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache = new TextureBlenderMaterialPropertyCacheHelper();

	private Color m_tintColor;

	private bool m_doScaleAlphaCutoff;

	private float m_alphaCutoff;

	private float m_glossiness;

	private float m_SpecGlossMapScale;

	private Color m_specColor;

	private bool m_hasSpecGlossMap;

	private float m_bumpScale;

	private bool m_shaderDoesEmission;

	private Color m_emissionColor;

	private Prop propertyToDo = Prop.doNone;

	private Color m_generatingTintedAtlaColor = Color.white;

	private Color m_generatingTintedAtlaSpecular = Color.black;

	private float m_generatingTintedAtlaGlossiness = 1f;

	private float m_generatingTintedAtlaSpecGlossMapScale = 1f;

	private float m_generatingTintedAtlaBumpScale = 1f;

	private Color m_generatingTintedAtlaEmission = Color.white;

	private const float m_generatedAlphaCutoff = 0.5f;

	private Color m_notGeneratingAtlasDefaultColor = Color.white;

	private Color m_notGeneratingAtlasDefaultSpecularColor = new Color(0f, 0f, 0f, 1f);

	private float m_notGeneratingAtlasDefaultGlossiness = 0.5f;

	private Color m_notGeneratingAtlasDefaultEmisionColor = Color.black;

	public bool DoesShaderNameMatch(string shaderName)
	{
		return shaderName.Equals("Standard (Specular setup)");
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (shaderTexturePropertyName.Equals("_MainTex"))
		{
			propertyToDo = Prop.doColor;
			if (sourceMat.HasProperty("_Color"))
			{
				m_tintColor = sourceMat.GetColor("_Color");
			}
			else
			{
				m_tintColor = m_generatingTintedAtlaColor;
			}
			if (sourceMat.HasProperty("_Mode") && sourceMat.HasProperty("_Cutoff") && sourceMat.GetFloat("_Mode") == 1f)
			{
				m_doScaleAlphaCutoff = true;
				m_alphaCutoff = sourceMat.GetFloat("_Cutoff");
				m_alphaCutoff = Mathf.Clamp(m_alphaCutoff, 0.0001f, 0.9999f);
			}
			else
			{
				m_doScaleAlphaCutoff = false;
				m_alphaCutoff = 0.5f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_SpecGlossMap"))
		{
			propertyToDo = Prop.doSpecular;
			m_specColor = m_generatingTintedAtlaSpecular;
			if (sourceMat.GetTexture("_SpecGlossMap") != null)
			{
				m_hasSpecGlossMap = true;
			}
			else
			{
				m_hasSpecGlossMap = false;
			}
			if (sourceMat.HasProperty("_SpecColor"))
			{
				m_specColor = sourceMat.GetColor("_SpecColor");
			}
			else
			{
				m_specColor = new Color(0f, 0f, 0f, 1f);
			}
			if (sourceMat.HasProperty("_GlossMapScale"))
			{
				m_SpecGlossMapScale = sourceMat.GetFloat("_GlossMapScale");
			}
			else
			{
				m_SpecGlossMapScale = 1f;
			}
			if (sourceMat.HasProperty("_Glossiness"))
			{
				m_glossiness = sourceMat.GetFloat("_Glossiness");
			}
			else
			{
				m_glossiness = 0f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_BumpMap"))
		{
			propertyToDo = Prop.doBump;
			if (sourceMat.HasProperty(shaderTexturePropertyName))
			{
				if (sourceMat.HasProperty("_BumpScale"))
				{
					m_bumpScale = sourceMat.GetFloat("_BumpScale");
				}
			}
			else
			{
				m_bumpScale = m_generatingTintedAtlaBumpScale;
			}
		}
		else if (shaderTexturePropertyName.Equals("_EmissionMap"))
		{
			propertyToDo = Prop.doEmission;
			m_shaderDoesEmission = sourceMat.IsKeywordEnabled("_EMISSION");
			if (sourceMat.HasProperty("_EmissionColor"))
			{
				m_emissionColor = sourceMat.GetColor("_EmissionColor");
			}
			else
			{
				m_generatingTintedAtlaColor = m_notGeneratingAtlasDefaultEmisionColor;
			}
		}
		else
		{
			propertyToDo = Prop.doNone;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (propertyToDo == Prop.doColor)
		{
			Color result = new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
			if (m_doScaleAlphaCutoff)
			{
				if (result.a >= m_alphaCutoff)
				{
					result.a = 0.5f + 0.5f * (result.a - m_alphaCutoff) / (1f - m_alphaCutoff);
				}
				else
				{
					result.a = 0.5f * result.a / m_alphaCutoff;
				}
			}
			return result;
		}
		if (propertyToDo == Prop.doSpecular)
		{
			if (m_hasSpecGlossMap)
			{
				pixelColor = new Color(pixelColor.r, pixelColor.g, pixelColor.b, pixelColor.a * m_SpecGlossMapScale);
				return pixelColor;
			}
			Color specColor = m_specColor;
			specColor.a = m_glossiness;
			return specColor;
		}
		if (propertyToDo == Prop.doBump)
		{
			return Color.Lerp(NeutralNormalMap, pixelColor, m_bumpScale);
		}
		if (propertyToDo == Prop.doEmission)
		{
			if (m_shaderDoesEmission)
			{
				return new Color(pixelColor.r * m_emissionColor.r, pixelColor.g * m_emissionColor.g, pixelColor.b * m_emissionColor.b, pixelColor.a * m_emissionColor.a);
			}
			return Color.black;
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		if (!TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaColor, "_Color"))
		{
			return false;
		}
		if (!TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaSpecular, "_SpecColor"))
		{
			return false;
		}
		if (a.HasProperty("_Mode") && b.HasProperty("_Mode") && a.GetFloat("_Mode") == 1f && b.GetFloat("_Mode") == 1f && a.HasProperty("_Cutoff") && b.HasProperty("_Cutoff") && a.HasProperty("_Cutoff") != b.HasProperty("_Cutoff"))
		{
			return false;
		}
		bool flag = a.HasProperty("_SpecGlossMap") && a.GetTexture("_SpecGlossMap") != null;
		bool flag2 = b.HasProperty("_SpecGlossMap") && b.GetTexture("_SpecGlossMap") != null;
		if (flag && flag2)
		{
			if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlaSpecGlossMapScale, "_GlossMapScale"))
			{
				return false;
			}
		}
		else
		{
			if (flag || flag2)
			{
				return false;
			}
			if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlaGlossiness, "_Glossiness"))
			{
				return false;
			}
		}
		if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlaBumpScale, "_BumpScale"))
		{
			return false;
		}
		if (a.IsKeywordEnabled("_EMISSION") != b.IsKeywordEnabled("_EMISSION"))
		{
			return false;
		}
		if (a.IsKeywordEnabled("_EMISSION") && !TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaEmission, "_EmissionColor"))
		{
			return false;
		}
		return true;
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		if (resultMaterial.GetTexture("_MainTex") != null)
		{
			resultMaterial.SetColor("_Color", m_generatingTintedAtlaColor);
			if (resultMaterial.GetFloat("_Mode") == 1f)
			{
				resultMaterial.SetFloat("_Cutoff", 0.5f);
			}
		}
		else
		{
			resultMaterial.SetColor("_Color", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Color", m_notGeneratingAtlasDefaultColor));
		}
		if (resultMaterial.GetTexture("_SpecGlossMap") != null)
		{
			resultMaterial.SetColor("_SpecColor", m_generatingTintedAtlaSpecular);
			resultMaterial.SetFloat("_GlossMapScale", m_generatingTintedAtlaSpecGlossMapScale);
			resultMaterial.SetFloat("_Glossiness", m_generatingTintedAtlaGlossiness);
		}
		else
		{
			resultMaterial.SetColor("_SpecColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_SpecColor", m_notGeneratingAtlasDefaultSpecularColor));
			resultMaterial.SetFloat("_Glossiness", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Glossiness", m_notGeneratingAtlasDefaultGlossiness));
		}
		if (resultMaterial.GetTexture("_BumpMap") != null)
		{
			resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlaBumpScale);
		}
		else
		{
			resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlaBumpScale);
		}
		if (resultMaterial.GetTexture("_EmissionMap") != null)
		{
			resultMaterial.EnableKeyword("_EMISSION");
			resultMaterial.SetColor("_EmissionColor", Color.white);
		}
		else
		{
			resultMaterial.DisableKeyword("_EMISSION");
			resultMaterial.SetColor("_EmissionColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_EmissionColor", m_notGeneratingAtlasDefaultEmisionColor));
		}
	}

	public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_BumpMap"))
		{
			return TextureBlenderFallback.GetDefaultNormalMapColor();
		}
		if (texPropertyName.name.Equals("_MainTex"))
		{
			if (mat != null && mat.HasProperty("_Color"))
			{
				return Color.white;
			}
		}
		else
		{
			if (texPropertyName.name.Equals("_SpecGlossMap"))
			{
				if (mat != null && mat.HasProperty("_SpecColor"))
				{
					try
					{
						Color color = mat.GetColor("_SpecColor");
						if (mat.HasProperty("_Glossiness"))
						{
							try
							{
								color.a = mat.GetFloat("_Glossiness");
							}
							catch (Exception)
							{
							}
						}
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_SpecColor", color);
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Glossiness", color.a);
						return color;
					}
					catch (Exception)
					{
					}
				}
				return new Color(0f, 0f, 0f, 0.5f);
			}
			if (texPropertyName.name.Equals("_ParallaxMap"))
			{
				return new Color(0f, 0f, 0f, 0f);
			}
			if (texPropertyName.name.Equals("_OcclusionMap"))
			{
				return new Color(1f, 1f, 1f, 1f);
			}
			if (texPropertyName.name.Equals("_EmissionMap"))
			{
				if (mat != null)
				{
					if (!mat.IsKeywordEnabled("_EMISSION"))
					{
						return Color.black;
					}
					if (!mat.HasProperty("_EmissionColor"))
					{
						return Color.black;
					}
					try
					{
						Color color2 = mat.GetColor("_EmissionColor");
						sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_EmissionColor", color2);
						return color2;
					}
					catch (Exception)
					{
					}
				}
			}
			else if (texPropertyName.name.Equals("_DetailMask"))
			{
				return new Color(0f, 0f, 0f, 0f);
			}
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
public class TextureBlenderURPLit : TextureBlender
{
	private enum Prop
	{
		doColor,
		doSpecular,
		doMetallic,
		doEmission,
		doBump,
		doNone
	}

	private enum WorkflowMode
	{
		unknown,
		metallic,
		specular
	}

	private enum SmoothnessTextureChannel
	{
		unknown,
		albedo,
		metallicSpecular
	}

	private static Color NeutralNormalMap = new Color(0.5f, 0.5f, 1f);

	private TextureBlenderMaterialPropertyCacheHelper sourceMaterialPropertyCache = new TextureBlenderMaterialPropertyCacheHelper();

	private WorkflowMode m_workflowMode;

	private SmoothnessTextureChannel m_smoothnessTextureChannel;

	private Color m_tintColor;

	private bool m_doScaleAlphaCutoff;

	private float m_alphaCutoff;

	private float m_smoothness;

	private Color m_specColor;

	private bool m_hasSpecGlossMap;

	private float m_metallic;

	private bool m_hasMetallicGlossMap;

	private float m_bumpScale;

	private bool m_shaderDoesEmission;

	private Color m_emissionColor;

	private Prop propertyToDo = Prop.doNone;

	private Color m_generatingTintedAtlaColor = Color.white;

	private float m_generatingTintedAtlasMetallic;

	private Color m_generatingTintedAtlaSpecular = Color.black;

	private float m_generatingTintedAtlasMetallic_smoothness = 1f;

	private float m_generatingTintedAtlasSpecular_somoothness = 1f;

	private float m_generatingTintedAtlaBumpScale = 1f;

	private Color m_generatingTintedAtlaEmission = Color.white;

	private const float m_generatedAlphaCutoff = 0.5f;

	private Color m_notGeneratingAtlasDefaultColor = Color.white;

	private float m_notGeneratingAtlasDefaultMetallic;

	private float m_notGeneratingAtlasDefaultSmoothness_MetallicWorkflow;

	private float m_notGeneratingAtlasDefaultSmoothness_SpecularWorkflow = 1f;

	private Color m_notGeneratingAtlasDefaultSpecularColor = new Color(0.2f, 0.2f, 0.2f, 1f);

	private Color m_notGeneratingAtlasDefaultEmisionColor = Color.black;

	public bool DoesShaderNameMatch(string shaderName)
	{
		if (!shaderName.Equals("Universal Render Pipeline/Lit") && !shaderName.Equals("Universal Render Pipeline/Simple Lit") && !shaderName.Equals("Universal Render Pipeline/Baked Lit") && !shaderName.Equals("Universal Render Pipeline/Unlit") && !shaderName.Equals("Universal Render Pipeline/Complex Lit") && !shaderName.Equals("Universal Render Pipeline/Particles/Lit") && !shaderName.Equals("Universal Render Pipeline/Particles/Unlit"))
		{
			return shaderName.Equals("Universal Render Pipeline/Particles/Simple Lit");
		}
		return true;
	}

	private WorkflowMode _MapFloatToWorkflowMode(float workflowMode)
	{
		if (workflowMode == 0f)
		{
			return WorkflowMode.specular;
		}
		return WorkflowMode.metallic;
	}

	private float _MapWorkflowModeToFloat(WorkflowMode workflowMode)
	{
		if (workflowMode == WorkflowMode.specular)
		{
			return 0f;
		}
		return 1f;
	}

	private SmoothnessTextureChannel _MapFloatToTextureChannel(float texChannel)
	{
		if (texChannel == 0f)
		{
			return SmoothnessTextureChannel.metallicSpecular;
		}
		return SmoothnessTextureChannel.albedo;
	}

	private float _MapTextureChannelToFloat(SmoothnessTextureChannel workflowMode)
	{
		if (workflowMode == SmoothnessTextureChannel.metallicSpecular)
		{
			return 0f;
		}
		return 1f;
	}

	public void OnBeforeTintTexture(Material sourceMat, string shaderTexturePropertyName)
	{
		if (m_workflowMode == WorkflowMode.unknown)
		{
			if (sourceMat.HasProperty("_WorkflowMode"))
			{
				m_workflowMode = _MapFloatToWorkflowMode(sourceMat.GetFloat("_WorkflowMode"));
			}
		}
		else if (sourceMat.HasProperty("_WorkflowMode") && _MapFloatToWorkflowMode(sourceMat.GetFloat("_WorkflowMode")) != m_workflowMode)
		{
			UnityEngine.Debug.LogError("Using the Universal Render Pipeline TextureBlender to blend non-texture-propertyes. Some of the source materials used different 'WorkflowModes'. These  cannot be blended properly. Results will be unpredictable.");
		}
		if (m_smoothnessTextureChannel == SmoothnessTextureChannel.unknown)
		{
			if (sourceMat.HasProperty("_SmoothnessTextureChannel"))
			{
				m_smoothnessTextureChannel = _MapFloatToTextureChannel(sourceMat.GetFloat("_SmoothnessTextureChannel"));
			}
		}
		else if (sourceMat.HasProperty("_SmoothnessTextureChannel") && _MapFloatToTextureChannel(sourceMat.GetFloat("_SmoothnessTextureChannel")) != m_smoothnessTextureChannel)
		{
			UnityEngine.Debug.LogError("Using the Universal Render Pipeline TextureBlender to blend non-texture-properties. Some of the source materials store smoothness in the Albedo texture alpha and some source materials store smoothness in the Metallic/Specular texture alpha channel. The result material can only read smoothness from one or the other. Results will be unpredictable.");
		}
		if (shaderTexturePropertyName.Equals("_BaseMap"))
		{
			propertyToDo = Prop.doColor;
			if (sourceMat.HasProperty("_BaseColor"))
			{
				m_tintColor = sourceMat.GetColor("_BaseColor");
			}
			else
			{
				m_tintColor = m_generatingTintedAtlaColor;
			}
			if (sourceMat.HasProperty("_Surface") && sourceMat.HasProperty("_AlphaClip") && sourceMat.HasProperty("_Cutoff") && sourceMat.GetFloat("_Surface") == 1f && sourceMat.GetFloat("_AlphaClip") == 1f)
			{
				m_doScaleAlphaCutoff = true;
				m_alphaCutoff = sourceMat.GetFloat("_Cutoff");
				m_alphaCutoff = Mathf.Clamp(m_alphaCutoff, 0.0001f, 0.9999f);
			}
			else
			{
				m_doScaleAlphaCutoff = false;
				m_alphaCutoff = 0.5f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_SpecGlossMap"))
		{
			propertyToDo = Prop.doSpecular;
			m_specColor = m_generatingTintedAtlaSpecular;
			if (sourceMat.GetTexture("_SpecGlossMap") != null)
			{
				m_hasSpecGlossMap = true;
			}
			else
			{
				m_hasSpecGlossMap = false;
			}
			if (sourceMat.HasProperty("_SpecColor"))
			{
				m_specColor = sourceMat.GetColor("_SpecColor");
			}
			else
			{
				m_specColor = new Color(0f, 0f, 0f, 1f);
			}
			if (sourceMat.HasProperty("_Smoothness") && m_workflowMode == WorkflowMode.specular)
			{
				m_smoothness = sourceMat.GetFloat("_Smoothness");
			}
			else if (m_workflowMode == WorkflowMode.specular)
			{
				m_smoothness = 1f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_MetallicGlossMap"))
		{
			propertyToDo = Prop.doMetallic;
			if (sourceMat.GetTexture("_MetallicGlossMap") != null)
			{
				m_hasMetallicGlossMap = true;
			}
			else
			{
				m_hasMetallicGlossMap = false;
			}
			if (sourceMat.HasProperty("_Metallic"))
			{
				m_metallic = sourceMat.GetFloat("_Metallic");
			}
			else
			{
				m_metallic = 0f;
			}
			if (sourceMat.HasProperty("_Smoothness") && m_workflowMode == WorkflowMode.metallic)
			{
				m_smoothness = sourceMat.GetFloat("_Smoothness");
			}
			else if (m_workflowMode == WorkflowMode.metallic)
			{
				m_smoothness = 0f;
			}
		}
		else if (shaderTexturePropertyName.Equals("_BumpMap"))
		{
			propertyToDo = Prop.doBump;
			if (sourceMat.HasProperty(shaderTexturePropertyName))
			{
				if (sourceMat.HasProperty("_BumpScale"))
				{
					m_bumpScale = sourceMat.GetFloat("_BumpScale");
				}
			}
			else
			{
				m_bumpScale = m_generatingTintedAtlaBumpScale;
			}
		}
		else if (shaderTexturePropertyName.Equals("_EmissionMap"))
		{
			propertyToDo = Prop.doEmission;
			m_shaderDoesEmission = sourceMat.IsKeywordEnabled("_EMISSION");
			if (sourceMat.HasProperty("_EmissionColor"))
			{
				m_emissionColor = sourceMat.GetColor("_EmissionColor");
			}
			else
			{
				m_generatingTintedAtlaColor = m_notGeneratingAtlasDefaultEmisionColor;
			}
		}
		else
		{
			propertyToDo = Prop.doNone;
		}
	}

	public Color OnBlendTexturePixel(string propertyToDoshaderPropertyName, Color pixelColor)
	{
		if (propertyToDo == Prop.doColor)
		{
			Color result = new Color(pixelColor.r * m_tintColor.r, pixelColor.g * m_tintColor.g, pixelColor.b * m_tintColor.b, pixelColor.a * m_tintColor.a);
			if (m_doScaleAlphaCutoff)
			{
				if (result.a >= m_alphaCutoff)
				{
					result.a = 0.5f + 0.5f * (result.a - m_alphaCutoff) / (1f - m_alphaCutoff);
				}
				else
				{
					result.a = 0.5f * result.a / m_alphaCutoff;
				}
			}
			return result;
		}
		if (propertyToDo == Prop.doMetallic)
		{
			if (m_hasMetallicGlossMap)
			{
				pixelColor = new Color(pixelColor.r, pixelColor.g, pixelColor.b, pixelColor.a * m_smoothness);
				return pixelColor;
			}
			return new Color(m_metallic, 0f, 0f, m_smoothness);
		}
		if (propertyToDo == Prop.doSpecular)
		{
			if (m_hasSpecGlossMap)
			{
				pixelColor = new Color(pixelColor.r, pixelColor.g, pixelColor.b, pixelColor.a * m_smoothness);
				return pixelColor;
			}
			Color specColor = m_specColor;
			specColor.a = m_smoothness;
			return specColor;
		}
		if (propertyToDo == Prop.doBump)
		{
			return Color.Lerp(NeutralNormalMap, pixelColor, m_bumpScale);
		}
		if (propertyToDo == Prop.doEmission)
		{
			if (m_shaderDoesEmission)
			{
				return new Color(pixelColor.r * m_emissionColor.r, pixelColor.g * m_emissionColor.g, pixelColor.b * m_emissionColor.b, pixelColor.a * m_emissionColor.a);
			}
			return Color.black;
		}
		return pixelColor;
	}

	public bool NonTexturePropertiesAreEqual(Material a, Material b)
	{
		if (!TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaColor, "_BaseColor"))
		{
			return false;
		}
		if (!TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaSpecular, "_SpecColor"))
		{
			return false;
		}
		if (a.HasProperty("_Surface") && b.HasProperty("_Surface") && a.GetFloat("_AlphaClip") == 1f && b.GetFloat("_AlphaClip") == 1f && a.HasProperty("_Cutoff") && b.HasProperty("_Cutoff") && a.HasProperty("_Cutoff") != b.HasProperty("_Cutoff"))
		{
			return false;
		}
		if (m_workflowMode == WorkflowMode.specular)
		{
			bool flag = a.HasProperty("_SpecGlossMap") && a.GetTexture("_SpecGlossMap") != null;
			bool flag2 = b.HasProperty("_SpecGlossMap") && b.GetTexture("_SpecGlossMap") != null;
			if (flag && flag2)
			{
				if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultSmoothness_SpecularWorkflow, "_Smoothness"))
				{
					return false;
				}
			}
			else
			{
				if (flag || flag2)
				{
					return false;
				}
				if (!TextureBlenderFallback._compareColor(a, b, m_notGeneratingAtlasDefaultSpecularColor, "_SpecColor") && !TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultSmoothness_SpecularWorkflow, "_Smoothness"))
				{
					return false;
				}
			}
		}
		if (m_workflowMode == WorkflowMode.metallic)
		{
			bool flag3 = a.HasProperty("_MetallicGlossMap") && a.GetTexture("_MetallicGlossMap") != null;
			bool flag4 = b.HasProperty("_MetallicGlossMap") && b.GetTexture("_MetallicGlossMap") != null;
			if (flag3 && flag4)
			{
				if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultSmoothness_MetallicWorkflow, "_Smoothness"))
				{
					return false;
				}
			}
			else
			{
				if (flag3 || flag4)
				{
					return false;
				}
				if (!TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultMetallic, "_Metallic") && !TextureBlenderFallback._compareFloat(a, b, m_notGeneratingAtlasDefaultSmoothness_MetallicWorkflow, "_Smoothness"))
				{
					return false;
				}
			}
		}
		if (!TextureBlenderFallback._compareFloat(a, b, m_generatingTintedAtlaBumpScale, "_BumpScale"))
		{
			return false;
		}
		if (a.IsKeywordEnabled("_EMISSION") != b.IsKeywordEnabled("_EMISSION"))
		{
			return false;
		}
		if (a.IsKeywordEnabled("_EMISSION") && !TextureBlenderFallback._compareColor(a, b, m_generatingTintedAtlaEmission, "_EmissionColor"))
		{
			return false;
		}
		return true;
	}

	public void SetNonTexturePropertyValuesOnResultMaterial(Material resultMaterial)
	{
		if (m_workflowMode != WorkflowMode.unknown)
		{
			resultMaterial.SetFloat("_WorkflowMode", _MapWorkflowModeToFloat(m_workflowMode));
		}
		if (m_smoothnessTextureChannel != SmoothnessTextureChannel.unknown)
		{
			resultMaterial.SetFloat("_SmoothnessTextureChannel", _MapTextureChannelToFloat(m_smoothnessTextureChannel));
		}
		if (resultMaterial.GetTexture("_BaseMap") != null)
		{
			resultMaterial.SetColor("_BaseColor", m_generatingTintedAtlaColor);
			if (resultMaterial.GetFloat("_Surface") == 1f && resultMaterial.GetFloat("_AlphaClip") == 1f && resultMaterial.HasProperty("_Cutoff"))
			{
				resultMaterial.SetFloat("_Cutoff", 0.5f);
			}
		}
		else
		{
			resultMaterial.SetColor("_BaseColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_BaseColor", m_notGeneratingAtlasDefaultColor));
		}
		if (m_workflowMode == WorkflowMode.specular && resultMaterial.HasProperty("_SpecGlossMap"))
		{
			if (resultMaterial.GetTexture("_SpecGlossMap") != null)
			{
				resultMaterial.SetColor("_SpecColor", m_generatingTintedAtlaSpecular);
				resultMaterial.SetFloat("_Smoothness", m_generatingTintedAtlasSpecular_somoothness);
			}
			else
			{
				resultMaterial.SetColor("_SpecColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_SpecColor", m_notGeneratingAtlasDefaultSpecularColor));
				resultMaterial.SetFloat("_Smoothness", m_smoothness);
			}
		}
		if (m_workflowMode == WorkflowMode.metallic && resultMaterial.HasProperty("_MetallicGlossMap"))
		{
			if (resultMaterial.GetTexture("_MetallicGlossMap") != null)
			{
				resultMaterial.SetFloat("_Metallic", m_generatingTintedAtlasMetallic);
				resultMaterial.SetFloat("_Smoothness", m_generatingTintedAtlasMetallic_smoothness);
			}
			else
			{
				resultMaterial.SetFloat("_Metallic", (float)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_Metallic", m_notGeneratingAtlasDefaultMetallic));
				resultMaterial.SetFloat("_Smoothness", m_smoothness);
			}
		}
		if (resultMaterial.HasProperty("_BumpMap") && resultMaterial.HasProperty("_BumpScale"))
		{
			if (resultMaterial.GetTexture("_BumpMap") != null)
			{
				resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlaBumpScale);
			}
			else
			{
				resultMaterial.SetFloat("_BumpScale", m_generatingTintedAtlaBumpScale);
			}
		}
		if (resultMaterial.HasProperty("_EmissionMap") && resultMaterial.HasProperty("_EmissionColor"))
		{
			if (resultMaterial.GetTexture("_EmissionMap") != null)
			{
				resultMaterial.EnableKeyword("_EMISSION");
				resultMaterial.SetColor("_EmissionColor", Color.white);
			}
			else
			{
				resultMaterial.DisableKeyword("_EMISSION");
				resultMaterial.SetColor("_EmissionColor", (Color)sourceMaterialPropertyCache.GetValueIfAllSourceAreTheSameOrDefault("_EmissionColor", m_notGeneratingAtlasDefaultEmisionColor));
			}
		}
	}

	public Color GetColorIfNoTexture(Material mat, ShaderTextureProperty texPropertyName)
	{
		if (texPropertyName.name.Equals("_BumpMap"))
		{
			return TextureBlenderFallback.GetDefaultNormalMapColor();
		}
		if (texPropertyName.name.Equals("_BaseMap"))
		{
			return Color.white;
		}
		if (texPropertyName.name.Equals("_SpecGlossMap"))
		{
			if (mat != null && mat.HasProperty("_SpecColor"))
			{
				try
				{
					Color color = mat.GetColor("_SpecColor");
					sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_SpecColor", color);
				}
				catch (Exception)
				{
				}
			}
			return new Color(0f, 0f, 0f, 0.5f);
		}
		if (texPropertyName.name.Equals("_MetallicGlossMap"))
		{
			if (mat != null && mat.HasProperty("_Metallic"))
			{
				try
				{
					float num = mat.GetFloat("_Metallic");
					Color color2 = new Color(num, num, num);
					if (mat.HasProperty("_Smoothness"))
					{
						try
						{
							color2.a = mat.GetFloat("_Smoothness");
						}
						catch (Exception)
						{
						}
					}
					sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Metallic", num);
					sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_Smoothness", color2.a);
				}
				catch (Exception)
				{
				}
				return new Color(0f, 0f, 0f, 0.5f);
			}
			return new Color(0f, 0f, 0f, 0.5f);
		}
		if (texPropertyName.name.Equals("_OcclusionMap"))
		{
			return new Color(1f, 1f, 1f, 1f);
		}
		if (texPropertyName.name.Equals("_EmissionMap"))
		{
			if (mat != null)
			{
				if (!mat.IsKeywordEnabled("_EMISSION"))
				{
					return Color.black;
				}
				if (!mat.HasProperty("_EmissionColor"))
				{
					return Color.black;
				}
				try
				{
					Color color3 = mat.GetColor("_EmissionColor");
					sourceMaterialPropertyCache.CacheMaterialProperty(mat, "_EmissionColor", color3);
				}
				catch (Exception)
				{
				}
			}
		}
		else if (texPropertyName.name.Equals("_DetailMask"))
		{
			return new Color(0f, 0f, 0f, 0f);
		}
		return new Color(1f, 1f, 1f, 0f);
	}
}
