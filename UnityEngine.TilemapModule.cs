using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.U2D;

[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
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
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.010")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.009")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.008")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.007")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.006")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
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
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.ARModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputModule")]
[assembly: InternalsVisibleTo("UnityEngine.JSONSerializeModule")]
[assembly: InternalsVisibleTo("UnityEngine.PhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.AMDModule")]
[assembly: InternalsVisibleTo("UnityEngine.AIModule")]
[assembly: InternalsVisibleTo("UnityEngine.CoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.SharedInternalsModule")]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine
{
	[AttributeUsage(AttributeTargets.Class)]
	public class CustomGridBrushAttribute : Attribute
	{
		private bool m_HideAssetInstances;

		private bool m_HideDefaultInstance;

		private bool m_DefaultBrush;

		private string m_DefaultName;

		public bool hideAssetInstances => m_HideAssetInstances;

		public bool hideDefaultInstance => m_HideDefaultInstance;

		public bool defaultBrush => m_DefaultBrush;

		public string defaultName => m_DefaultName;

		public CustomGridBrushAttribute()
		{
			m_HideAssetInstances = false;
			m_HideDefaultInstance = false;
			m_DefaultBrush = false;
			m_DefaultName = "";
		}

		public CustomGridBrushAttribute(bool hideAssetInstances, bool hideDefaultInstance, bool defaultBrush, string defaultName)
		{
			m_HideAssetInstances = hideAssetInstances;
			m_HideDefaultInstance = hideDefaultInstance;
			m_DefaultBrush = defaultBrush;
			m_DefaultName = defaultName;
		}
	}
	public abstract class GridBrushBase : ScriptableObject
	{
		public enum Tool
		{
			Select,
			Move,
			Paint,
			Box,
			Pick,
			Erase,
			FloodFill,
			Other
		}

		public enum RotationDirection
		{
			Clockwise,
			CounterClockwise
		}

		public enum FlipAxis
		{
			X,
			Y
		}

		public virtual void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
		{
		}

		public virtual void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
		{
		}

		public virtual void BoxFill(GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
			for (int i = position.zMin; i < position.zMax; i++)
			{
				for (int j = position.yMin; j < position.yMax; j++)
				{
					for (int k = position.xMin; k < position.xMax; k++)
					{
						Paint(gridLayout, brushTarget, new Vector3Int(k, j, i));
					}
				}
			}
		}

		public virtual void BoxErase(GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
			for (int i = position.zMin; i < position.zMax; i++)
			{
				for (int j = position.yMin; j < position.yMax; j++)
				{
					for (int k = position.xMin; k < position.xMax; k++)
					{
						Erase(gridLayout, brushTarget, new Vector3Int(k, j, i));
					}
				}
			}
		}

		public virtual void Select(GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
		}

		public virtual void FloodFill(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
		{
		}

		public virtual void Rotate(RotationDirection direction, GridLayout.CellLayout layout)
		{
		}

		public virtual void Flip(FlipAxis flip, GridLayout.CellLayout layout)
		{
		}

		public virtual void Pick(GridLayout gridLayout, GameObject brushTarget, BoundsInt position, Vector3Int pivot)
		{
		}

		public virtual void Move(GridLayout gridLayout, GameObject brushTarget, BoundsInt from, BoundsInt to)
		{
		}

		public virtual void MoveStart(GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
		}

		public virtual void MoveEnd(GridLayout gridLayout, GameObject brushTarget, BoundsInt position)
		{
		}

		public virtual void ChangeZPosition(int change)
		{
		}

		public virtual void ResetZPosition()
		{
		}
	}
}
namespace UnityEngine.Tilemaps
{
	[RequiredByNativeCode]
	public class ITilemap
	{
		internal static ITilemap s_Instance;

		internal Tilemap m_Tilemap;

		internal bool m_AddToList;

		internal int m_RefreshCount;

		internal NativeArray<Vector3Int> m_RefreshPos;

		public Vector3Int origin => m_Tilemap.origin;

		public Vector3Int size => m_Tilemap.size;

		public Bounds localBounds => m_Tilemap.localBounds;

		public BoundsInt cellBounds => m_Tilemap.cellBounds;

		internal ITilemap()
		{
		}

		public ITilemap(Tilemap tilemap)
		{
			if (tilemap == null)
			{
				throw new ArgumentNullException("Argument tilemap cannot be null");
			}
			m_Tilemap = tilemap;
		}

		public static implicit operator ITilemap(Tilemap tilemap)
		{
			return new ITilemap(tilemap);
		}

		internal void SetTilemapInstance(Tilemap tilemap)
		{
			m_Tilemap = tilemap;
		}

		public virtual Sprite GetSprite(Vector3Int position)
		{
			return m_Tilemap.GetSprite(position);
		}

		public virtual Color GetColor(Vector3Int position)
		{
			return m_Tilemap.GetColor(position);
		}

		public virtual Matrix4x4 GetTransformMatrix(Vector3Int position)
		{
			return m_Tilemap.GetTransformMatrix(position);
		}

		public virtual TileFlags GetTileFlags(Vector3Int position)
		{
			return m_Tilemap.GetTileFlags(position);
		}

		public virtual TileBase GetTile(Vector3Int position)
		{
			return m_Tilemap.GetTile(position);
		}

		public virtual T GetTile<T>(Vector3Int position) where T : TileBase
		{
			return m_Tilemap.GetTile<T>(position);
		}

		public void RefreshTile(Vector3Int position)
		{
			if (m_AddToList)
			{
				if (m_RefreshCount >= m_RefreshPos.Length)
				{
					NativeArray<Vector3Int> nativeArray = new NativeArray<Vector3Int>(Math.Max(1, m_RefreshCount * 2), Allocator.Temp);
					NativeArray<Vector3Int>.Copy(m_RefreshPos, nativeArray, m_RefreshPos.Length);
					m_RefreshPos.Dispose();
					m_RefreshPos = nativeArray;
				}
				m_RefreshPos[m_RefreshCount++] = position;
			}
			else
			{
				m_Tilemap.RefreshTile(position);
			}
		}

		public T GetComponent<T>()
		{
			if (typeof(T) == typeof(Tilemap))
			{
				return (T)(object)m_Tilemap;
			}
			return m_Tilemap.GetComponent<T>();
		}

		[RequiredByNativeCode]
		private static ITilemap CreateInstance()
		{
			s_Instance = new ITilemap();
			return s_Instance;
		}

		[RequiredByNativeCode]
		private unsafe static void FindAllRefreshPositions(ITilemap tilemap, int count, IntPtr oldTilesIntPtr, IntPtr newTilesIntPtr, IntPtr positionsIntPtr)
		{
			tilemap.m_AddToList = true;
			_ = tilemap.m_RefreshPos;
			if (!tilemap.m_RefreshPos.IsCreated || tilemap.m_RefreshPos.Length < count)
			{
				tilemap.m_RefreshPos = new NativeArray<Vector3Int>(Math.Max(16, count), Allocator.Temp);
			}
			tilemap.m_RefreshCount = 0;
			void* dataPointer = oldTilesIntPtr.ToPointer();
			void* dataPointer2 = newTilesIntPtr.ToPointer();
			void* dataPointer3 = positionsIntPtr.ToPointer();
			NativeArray<int> nativeArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(dataPointer, count, Allocator.Invalid);
			NativeArray<int> nativeArray2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(dataPointer2, count, Allocator.Invalid);
			NativeArray<Vector3Int> nativeArray3 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3Int>(dataPointer3, count, Allocator.Invalid);
			for (int i = 0; i < count; i++)
			{
				int num = nativeArray[i];
				int num2 = nativeArray2[i];
				Vector3Int position = nativeArray3[i];
				if (num != 0)
				{
					TileBase tileBase = (TileBase)Object.ForceLoadFromInstanceID(num);
					tileBase.RefreshTile(position, tilemap);
				}
				if (num2 != 0)
				{
					TileBase tileBase2 = (TileBase)Object.ForceLoadFromInstanceID(num2);
					tileBase2.RefreshTile(position, tilemap);
				}
			}
			tilemap.m_Tilemap.RefreshTilesNative(tilemap.m_RefreshPos.m_Buffer, tilemap.m_RefreshCount);
			tilemap.m_RefreshPos.Dispose();
			tilemap.m_AddToList = false;
		}

		[RequiredByNativeCode]
		private unsafe static void GetAllTileData(ITilemap tilemap, int count, IntPtr tilesIntPtr, IntPtr positionsIntPtr, IntPtr outTileDataIntPtr)
		{
			void* dataPointer = tilesIntPtr.ToPointer();
			void* dataPointer2 = positionsIntPtr.ToPointer();
			void* dataPointer3 = outTileDataIntPtr.ToPointer();
			NativeArray<int> nativeArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<int>(dataPointer, count, Allocator.Invalid);
			NativeArray<Vector3Int> nativeArray2 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3Int>(dataPointer2, count, Allocator.Invalid);
			NativeArray<TileData> nativeArray3 = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<TileData>(dataPointer3, count, Allocator.Invalid);
			for (int i = 0; i < count; i++)
			{
				TileData tileData = TileData.Default;
				int num = nativeArray[i];
				if (num != 0)
				{
					TileBase tileBase = (TileBase)Object.ForceLoadFromInstanceID(num);
					tileBase.GetTileData(nativeArray2[i], tilemap, ref UnsafeUtility.ArrayElementAsRef<TileData>(nativeArray3.GetUnsafePtr(), i));
				}
			}
		}
	}
	[Serializable]
	[HelpURL("https://docs.unity3d.com/Manual/Tilemap-TileAsset.html")]
	[RequiredByNativeCode]
	public class Tile : TileBase
	{
		public enum ColliderType
		{
			None,
			Sprite,
			Grid
		}

		[SerializeField]
		private Sprite m_Sprite;

		[SerializeField]
		private Color m_Color = Color.white;

		[SerializeField]
		private Matrix4x4 m_Transform = Matrix4x4.identity;

		[SerializeField]
		private GameObject m_InstancedGameObject;

		[SerializeField]
		private TileFlags m_Flags = TileFlags.LockColor;

		[SerializeField]
		private ColliderType m_ColliderType = ColliderType.Sprite;

		public Sprite sprite
		{
			get
			{
				return m_Sprite;
			}
			set
			{
				m_Sprite = value;
			}
		}

		public Color color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public Matrix4x4 transform
		{
			get
			{
				return m_Transform;
			}
			set
			{
				m_Transform = value;
			}
		}

		public GameObject gameObject
		{
			get
			{
				return m_InstancedGameObject;
			}
			set
			{
				m_InstancedGameObject = value;
			}
		}

		public TileFlags flags
		{
			get
			{
				return m_Flags;
			}
			set
			{
				m_Flags = value;
			}
		}

		public ColliderType colliderType
		{
			get
			{
				return m_ColliderType;
			}
			set
			{
				m_ColliderType = value;
			}
		}

		public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
			tileData.sprite = m_Sprite;
			tileData.color = m_Color;
			tileData.transform = m_Transform;
			tileData.gameObject = m_InstancedGameObject;
			tileData.flags = m_Flags;
			tileData.colliderType = m_ColliderType;
		}
	}
	[RequiredByNativeCode]
	public abstract class TileBase : ScriptableObject
	{
		[RequiredByNativeCode]
		public virtual void RefreshTile(Vector3Int position, ITilemap tilemap)
		{
			tilemap.RefreshTile(position);
		}

		[RequiredByNativeCode]
		public virtual void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
		{
		}

		private TileData GetTileDataNoRef(Vector3Int position, ITilemap tilemap)
		{
			TileData tileData = default(TileData);
			GetTileData(position, tilemap, ref tileData);
			return tileData;
		}

		[RequiredByNativeCode]
		public virtual bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
		{
			return false;
		}

		private TileAnimationData GetTileAnimationDataNoRef(Vector3Int position, ITilemap tilemap)
		{
			TileAnimationData tileAnimationData = default(TileAnimationData);
			GetTileAnimationData(position, tilemap, ref tileAnimationData);
			return tileAnimationData;
		}

		[RequiredByNativeCode]
		private void GetTileAnimationDataRef(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData, ref bool hasAnimation)
		{
			hasAnimation = GetTileAnimationData(position, tilemap, ref tileAnimationData);
		}

		[RequiredByNativeCode]
		public virtual bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
		{
			return false;
		}

		[RequiredByNativeCode]
		private void StartUpRef(Vector3Int position, ITilemap tilemap, GameObject go, ref bool startUpInvokedByUser)
		{
			startUpInvokedByUser = StartUp(position, tilemap, go);
		}
	}
	[NativeType(Header = "Modules/Tilemap/Public/Tilemap.h")]
	[RequireComponent(typeof(Transform))]
	[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
	[NativeHeader("Modules/Grid/Public/Grid.h")]
	[NativeHeader("Runtime/Graphics/SpriteFrame.h")]
	[NativeHeader("Modules/Tilemap/Public/TilemapTile.h")]
	[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
	public sealed class Tilemap : GridLayout
	{
		public enum Orientation
		{
			XY,
			XZ,
			YX,
			YZ,
			ZX,
			ZY,
			Custom
		}

		[RequiredByNativeCode]
		public struct SyncTile
		{
			internal Vector3Int m_Position;

			internal TileBase m_Tile;

			internal TileData m_TileData;

			public Vector3Int position => m_Position;

			public TileBase tile => m_Tile;

			public TileData tileData => m_TileData;
		}

		internal struct SyncTileCallbackSettings
		{
			internal bool hasSyncTileCallback;

			internal bool hasPositionsChangedCallback;

			internal bool isBufferSyncTile;
		}

		private bool m_BufferSyncTile;

		internal bool bufferSyncTile
		{
			get
			{
				return m_BufferSyncTile;
			}
			set
			{
				if (!value && m_BufferSyncTile != value && HasSyncTileCallback())
				{
					SendAndClearSyncTileBuffer();
				}
				m_BufferSyncTile = value;
			}
		}

		public Grid layoutGrid
		{
			[NativeMethod(Name = "GetAttachedGrid")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return Unmarshal.UnmarshalUnityObject<Grid>(get_layoutGrid_Injected(intPtr));
			}
		}

		public BoundsInt cellBounds => new BoundsInt(origin, size);

		[NativeProperty("TilemapBoundsScripting")]
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
		}

		[NativeProperty("TilemapFrameBoundsScripting")]
		internal Bounds localFrameBounds
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_localFrameBounds_Injected(intPtr, out var ret);
				return ret;
			}
		}

		public float animationFrameRate
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_animationFrameRate_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_animationFrameRate_Injected(intPtr, value);
			}
		}

		public Color color
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_color_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_color_Injected(intPtr, ref value);
			}
		}

		public Vector3Int origin
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_origin_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_origin_Injected(intPtr, ref value);
			}
		}

		public Vector3Int size
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_size_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_size_Injected(intPtr, ref value);
			}
		}

		[NativeProperty(Name = "TileAnchorScripting")]
		public Vector3 tileAnchor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_tileAnchor_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_tileAnchor_Injected(intPtr, ref value);
			}
		}

		public Orientation orientation
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_orientation_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_orientation_Injected(intPtr, value);
			}
		}

		public Matrix4x4 orientationMatrix
		{
			[NativeMethod(Name = "GetTileOrientationMatrix")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_orientationMatrix_Injected(intPtr, out var ret);
				return ret;
			}
			[NativeMethod(Name = "SetOrientationMatrix")]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_orientationMatrix_Injected(intPtr, ref value);
			}
		}

		public static event Action<Tilemap, SyncTile[]> tilemapTileChanged;

		public static event Action<Tilemap, NativeArray<Vector3Int>> tilemapPositionsChanged;

		public static event Action<Tilemap, NativeArray<Vector3Int>> loopEndedForTileAnimation;

		internal static bool HasLoopEndedForTileAnimationCallback()
		{
			return Tilemap.loopEndedForTileAnimation != null;
		}

		private unsafe void HandleLoopEndedForTileAnimationCallback(int count, IntPtr positionsIntPtr)
		{
			if (HasLoopEndedForTileAnimationCallback())
			{
				void* dataPointer = positionsIntPtr.ToPointer();
				NativeArray<Vector3Int> positions = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3Int>(dataPointer, count, Allocator.Invalid);
				SendLoopEndedForTileAnimationCallback(positions);
			}
		}

		private void SendLoopEndedForTileAnimationCallback(NativeArray<Vector3Int> positions)
		{
			try
			{
				Tilemap.loopEndedForTileAnimation(this, positions);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception, this);
			}
		}

		internal static bool HasSyncTileCallback()
		{
			return Tilemap.tilemapTileChanged != null;
		}

		internal static bool HasPositionsChangedCallback()
		{
			return Tilemap.tilemapPositionsChanged != null;
		}

		private void HandleSyncTileCallback(SyncTile[] syncTiles)
		{
			if (Tilemap.tilemapTileChanged != null)
			{
				SendTilemapTileChangedCallback(syncTiles);
			}
		}

		private unsafe void HandlePositionsChangedCallback(int count, IntPtr positionsIntPtr)
		{
			if (HasPositionsChangedCallback())
			{
				void* dataPointer = positionsIntPtr.ToPointer();
				NativeArray<Vector3Int> positions = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<Vector3Int>(dataPointer, count, Allocator.Invalid);
				SendTilemapPositionsChangedCallback(positions);
			}
		}

		private void SendTilemapTileChangedCallback(SyncTile[] syncTiles)
		{
			try
			{
				Tilemap.tilemapTileChanged(this, syncTiles);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception, this);
			}
		}

		private void SendTilemapPositionsChangedCallback(NativeArray<Vector3Int> positions)
		{
			try
			{
				Tilemap.tilemapPositionsChanged(this, positions);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception, this);
			}
		}

		internal static void SetSyncTileCallback(Action<Tilemap, SyncTile[]> callback)
		{
			tilemapTileChanged += callback;
		}

		internal static void RemoveSyncTileCallback(Action<Tilemap, SyncTile[]> callback)
		{
			tilemapTileChanged -= callback;
		}

		public Vector3 GetCellCenterLocal(Vector3Int position)
		{
			return CellToLocalInterpolated(position) + CellToLocalInterpolated(tileAnchor);
		}

		public Vector3 GetCellCenterWorld(Vector3Int position)
		{
			return LocalToWorld(CellToLocalInterpolated(position) + CellToLocalInterpolated(tileAnchor));
		}

		internal Object GetTileAsset(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Object>(GetTileAsset_Injected(intPtr, ref position));
		}

		public TileBase GetTile(Vector3Int position)
		{
			return GetTileAsset(position) as TileBase;
		}

		public T GetTile<T>(Vector3Int position) where T : TileBase
		{
			return GetTileAsset(position) as T;
		}

		internal Object[] GetTileAssetsBlock(Vector3Int position, Vector3Int blockDimensions)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTileAssetsBlock_Injected(intPtr, ref position, ref blockDimensions);
		}

		public TileBase[] GetTilesBlock(BoundsInt bounds)
		{
			Object[] tileAssetsBlock = GetTileAssetsBlock(bounds.min, bounds.size);
			TileBase[] array = new TileBase[tileAssetsBlock.Length];
			for (int i = 0; i < tileAssetsBlock.Length; i++)
			{
				array[i] = (TileBase)tileAssetsBlock[i];
			}
			return array;
		}

		[FreeFunction(Name = "TilemapBindings::GetTileAssetsBlockNonAlloc", HasExplicitThis = true)]
		internal int GetTileAssetsBlockNonAlloc(Vector3Int startPosition, Vector3Int endPosition, [Unmarshalled] Object[] tiles)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTileAssetsBlockNonAlloc_Injected(intPtr, ref startPosition, ref endPosition, tiles);
		}

		public int GetTilesBlockNonAlloc(BoundsInt bounds, TileBase[] tiles)
		{
			return GetTileAssetsBlockNonAlloc(bounds.min, bounds.size, tiles);
		}

		public int GetTilesRangeCount(Vector3Int startPosition, Vector3Int endPosition)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTilesRangeCount_Injected(intPtr, ref startPosition, ref endPosition);
		}

		[FreeFunction(Name = "TilemapBindings::GetTileAssetsRangeNonAlloc", HasExplicitThis = true)]
		internal unsafe int GetTileAssetsRangeNonAlloc(Vector3Int startPosition, Vector3Int endPosition, Vector3Int[] positions, [Unmarshalled] Object[] tiles)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<Vector3Int> span = new Span<Vector3Int>(positions);
			int tileAssetsRangeNonAlloc_Injected;
			fixed (Vector3Int* begin = span)
			{
				ManagedSpanWrapper positions2 = new ManagedSpanWrapper(begin, span.Length);
				tileAssetsRangeNonAlloc_Injected = GetTileAssetsRangeNonAlloc_Injected(intPtr, ref startPosition, ref endPosition, ref positions2, tiles);
			}
			return tileAssetsRangeNonAlloc_Injected;
		}

		public int GetTilesRangeNonAlloc(Vector3Int startPosition, Vector3Int endPosition, Vector3Int[] positions, TileBase[] tiles)
		{
			return GetTileAssetsRangeNonAlloc(startPosition, endPosition, positions, tiles);
		}

		internal void SetTileAsset(Vector3Int position, Object tile)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTileAsset_Injected(intPtr, ref position, MarshalledUnityObject.Marshal(tile));
		}

		public void SetTile(Vector3Int position, TileBase tile)
		{
			SetTileAsset(position, tile);
		}

		internal unsafe void SetTileAssets(Vector3Int[] positionArray, Object[] tileArray)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<Vector3Int> span = new Span<Vector3Int>(positionArray);
			fixed (Vector3Int* begin = span)
			{
				ManagedSpanWrapper positionArray2 = new ManagedSpanWrapper(begin, span.Length);
				SetTileAssets_Injected(intPtr, ref positionArray2, tileArray);
			}
		}

		public void SetTiles(Vector3Int[] positionArray, TileBase[] tileArray)
		{
			SetTileAssets(positionArray, tileArray);
		}

		[NativeMethod(Name = "SetTileAssetsBlock")]
		private void INTERNAL_CALL_SetTileAssetsBlock(Vector3Int position, Vector3Int blockDimensions, Object[] tileArray)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			INTERNAL_CALL_SetTileAssetsBlock_Injected(intPtr, ref position, ref blockDimensions, tileArray);
		}

		public void SetTilesBlock(BoundsInt position, TileBase[] tileArray)
		{
			INTERNAL_CALL_SetTileAssetsBlock(position.min, position.size, tileArray);
		}

		[NativeMethod(Name = "SetTileChangeData")]
		public void SetTile(TileChangeData tileChangeData, bool ignoreLockFlags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTile_Injected(intPtr, ref tileChangeData, ignoreLockFlags);
		}

		[NativeMethod(Name = "SetTileChangeDataArray")]
		public void SetTiles(TileChangeData[] tileChangeDataArray, bool ignoreLockFlags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTiles_Injected(intPtr, tileChangeDataArray, ignoreLockFlags);
		}

		public bool HasTile(Vector3Int position)
		{
			return GetTileAsset(position) != null;
		}

		[NativeMethod(Name = "RefreshTileAsset")]
		public void RefreshTile(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RefreshTile_Injected(intPtr, ref position);
		}

		[FreeFunction(Name = "TilemapBindings::RefreshTileAssetsNative", HasExplicitThis = true)]
		internal unsafe void RefreshTilesNative(void* positions, int count)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RefreshTilesNative_Injected(intPtr, positions, count);
		}

		[NativeMethod(Name = "RefreshAllTileAssets")]
		public void RefreshAllTiles()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RefreshAllTiles_Injected(intPtr);
		}

		internal void SwapTileAsset(Object changeTile, Object newTile)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SwapTileAsset_Injected(intPtr, MarshalledUnityObject.Marshal(changeTile), MarshalledUnityObject.Marshal(newTile));
		}

		public void SwapTile(TileBase changeTile, TileBase newTile)
		{
			SwapTileAsset(changeTile, newTile);
		}

		internal bool ContainsTileAsset(Object tileAsset)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return ContainsTileAsset_Injected(intPtr, MarshalledUnityObject.Marshal(tileAsset));
		}

		public bool ContainsTile(TileBase tileAsset)
		{
			return ContainsTileAsset(tileAsset);
		}

		public int GetUsedTilesCount()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUsedTilesCount_Injected(intPtr);
		}

		public int GetUsedSpritesCount()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetUsedSpritesCount_Injected(intPtr);
		}

		public int GetUsedTilesNonAlloc(TileBase[] usedTiles)
		{
			return Internal_GetUsedTilesNonAlloc(usedTiles);
		}

		public int GetUsedSpritesNonAlloc(Sprite[] usedSprites)
		{
			return Internal_GetUsedSpritesNonAlloc(usedSprites);
		}

		[FreeFunction(Name = "TilemapBindings::GetUsedTilesNonAlloc", HasExplicitThis = true)]
		internal int Internal_GetUsedTilesNonAlloc([Unmarshalled] Object[] usedTiles)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_GetUsedTilesNonAlloc_Injected(intPtr, usedTiles);
		}

		[FreeFunction(Name = "TilemapBindings::GetUsedSpritesNonAlloc", HasExplicitThis = true)]
		internal int Internal_GetUsedSpritesNonAlloc([Unmarshalled] Object[] usedSprites)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Internal_GetUsedSpritesNonAlloc_Injected(intPtr, usedSprites);
		}

		public Sprite GetSprite(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Sprite>(GetSprite_Injected(intPtr, ref position));
		}

		public Matrix4x4 GetTransformMatrix(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetTransformMatrix_Injected(intPtr, ref position, out var ret);
			return ret;
		}

		public void SetTransformMatrix(Vector3Int position, Matrix4x4 transform)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTransformMatrix_Injected(intPtr, ref position, ref transform);
		}

		[NativeMethod(Name = "GetTileColor")]
		public Color GetColor(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetColor_Injected(intPtr, ref position, out var ret);
			return ret;
		}

		[NativeMethod(Name = "SetTileColor")]
		public void SetColor(Vector3Int position, Color color)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetColor_Injected(intPtr, ref position, ref color);
		}

		public TileFlags GetTileFlags(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTileFlags_Injected(intPtr, ref position);
		}

		public void SetTileFlags(Vector3Int position, TileFlags flags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTileFlags_Injected(intPtr, ref position, flags);
		}

		public void AddTileFlags(Vector3Int position, TileFlags flags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddTileFlags_Injected(intPtr, ref position, flags);
		}

		public void RemoveTileFlags(Vector3Int position, TileFlags flags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveTileFlags_Injected(intPtr, ref position, flags);
		}

		[NativeMethod(Name = "GetTileInstantiatedObject")]
		public GameObject GetInstantiatedObject(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<GameObject>(GetInstantiatedObject_Injected(intPtr, ref position));
		}

		[NativeMethod(Name = "GetTileObjectToInstantiate")]
		public GameObject GetObjectToInstantiate(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<GameObject>(GetObjectToInstantiate_Injected(intPtr, ref position));
		}

		[NativeMethod(Name = "SetTileColliderType")]
		public void SetColliderType(Vector3Int position, Tile.ColliderType colliderType)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetColliderType_Injected(intPtr, ref position, colliderType);
		}

		[NativeMethod(Name = "GetTileColliderType")]
		public Tile.ColliderType GetColliderType(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetColliderType_Injected(intPtr, ref position);
		}

		[NativeMethod(Name = "GetTileAnimationFrameCount")]
		public int GetAnimationFrameCount(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAnimationFrameCount_Injected(intPtr, ref position);
		}

		[NativeMethod(Name = "GetTileAnimationFrame")]
		public int GetAnimationFrame(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAnimationFrame_Injected(intPtr, ref position);
		}

		[NativeMethod(Name = "SetTileAnimationFrame")]
		public void SetAnimationFrame(Vector3Int position, int frame)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetAnimationFrame_Injected(intPtr, ref position, frame);
		}

		[NativeMethod(Name = "GetTileAnimationTime")]
		public float GetAnimationTime(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetAnimationTime_Injected(intPtr, ref position);
		}

		[NativeMethod(Name = "SetTileAnimationTime")]
		public void SetAnimationTime(Vector3Int position, float time)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetAnimationTime_Injected(intPtr, ref position, time);
		}

		public TileAnimationFlags GetTileAnimationFlags(Vector3Int position)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return GetTileAnimationFlags_Injected(intPtr, ref position);
		}

		public void SetTileAnimationFlags(Vector3Int position, TileAnimationFlags flags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SetTileAnimationFlags_Injected(intPtr, ref position, flags);
		}

		public void AddTileAnimationFlags(Vector3Int position, TileAnimationFlags flags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			AddTileAnimationFlags_Injected(intPtr, ref position, flags);
		}

		public void RemoveTileAnimationFlags(Vector3Int position, TileAnimationFlags flags)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			RemoveTileAnimationFlags_Injected(intPtr, ref position, flags);
		}

		public void FloodFill(Vector3Int position, TileBase tile)
		{
			FloodFillTileAsset(position, tile);
		}

		[NativeMethod(Name = "FloodFill")]
		private void FloodFillTileAsset(Vector3Int position, Object tile)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			FloodFillTileAsset_Injected(intPtr, ref position, MarshalledUnityObject.Marshal(tile));
		}

		public void BoxFill(Vector3Int position, TileBase tile, int startX, int startY, int endX, int endY)
		{
			BoxFillTileAsset(position, tile, startX, startY, endX, endY);
		}

		[NativeMethod(Name = "BoxFill")]
		private void BoxFillTileAsset(Vector3Int position, Object tile, int startX, int startY, int endX, int endY)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			BoxFillTileAsset_Injected(intPtr, ref position, MarshalledUnityObject.Marshal(tile), startX, startY, endX, endY);
		}

		public void InsertCells(Vector3Int position, Vector3Int insertCells)
		{
			InsertCells(position, insertCells.x, insertCells.y, insertCells.z);
		}

		public void InsertCells(Vector3Int position, int numColumns, int numRows, int numLayers)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			InsertCells_Injected(intPtr, ref position, numColumns, numRows, numLayers);
		}

		public void DeleteCells(Vector3Int position, Vector3Int deleteCells)
		{
			DeleteCells(position, deleteCells.x, deleteCells.y, deleteCells.z);
		}

		public void DeleteCells(Vector3Int position, int numColumns, int numRows, int numLayers)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			DeleteCells_Injected(intPtr, ref position, numColumns, numRows, numLayers);
		}

		public void ClearAllTiles()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ClearAllTiles_Injected(intPtr);
		}

		public void ResizeBounds()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ResizeBounds_Injected(intPtr);
		}

		[NativeMethod(Name = "CompressBounds")]
		private void CompressTilemapBounds(bool keepEditorPreview)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			CompressTilemapBounds_Injected(intPtr, keepEditorPreview);
		}

		public void CompressBounds()
		{
			CompressTilemapBounds(keepEditorPreview: false);
		}

		[RequiredByNativeCode]
		internal void GetLoopEndedForTileAnimationCallbackSettings(ref bool hasEndLoopForTileAnimationCallback)
		{
			hasEndLoopForTileAnimationCallback = HasLoopEndedForTileAnimationCallback();
		}

		[RequiredByNativeCode]
		private void DoLoopEndedForTileAnimationCallback(int count, IntPtr positionsIntPtr)
		{
			HandleLoopEndedForTileAnimationCallback(count, positionsIntPtr);
		}

		[RequiredByNativeCode]
		internal void GetSyncTileCallbackSettings(ref SyncTileCallbackSettings settings)
		{
			settings.hasSyncTileCallback = HasSyncTileCallback();
			settings.hasPositionsChangedCallback = HasPositionsChangedCallback();
			settings.isBufferSyncTile = bufferSyncTile;
		}

		internal void SendAndClearSyncTileBuffer()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			SendAndClearSyncTileBuffer_Injected(intPtr);
		}

		[RequiredByNativeCode]
		private void DoSyncTileCallback(SyncTile[] syncTiles)
		{
			HandleSyncTileCallback(syncTiles);
		}

		[RequiredByNativeCode]
		private void DoPositionsChangedCallback(int count, IntPtr positionsIntPtr)
		{
			HandlePositionsChangedCallback(count, positionsIntPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr get_layoutGrid_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_localBounds_Injected(IntPtr _unity_self, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_localFrameBounds_Injected(IntPtr _unity_self, out Bounds ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_animationFrameRate_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_animationFrameRate_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_color_Injected(IntPtr _unity_self, out Color ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_color_Injected(IntPtr _unity_self, [In] ref Color value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_origin_Injected(IntPtr _unity_self, out Vector3Int ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_origin_Injected(IntPtr _unity_self, [In] ref Vector3Int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_size_Injected(IntPtr _unity_self, out Vector3Int ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_size_Injected(IntPtr _unity_self, [In] ref Vector3Int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_tileAnchor_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_tileAnchor_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Orientation get_orientation_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_orientation_Injected(IntPtr _unity_self, Orientation value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_orientationMatrix_Injected(IntPtr _unity_self, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_orientationMatrix_Injected(IntPtr _unity_self, [In] ref Matrix4x4 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Object[] GetTileAssetsBlock_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Vector3Int blockDimensions);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetTileAssetsBlockNonAlloc_Injected(IntPtr _unity_self, [In] ref Vector3Int startPosition, [In] ref Vector3Int endPosition, Object[] tiles);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetTilesRangeCount_Injected(IntPtr _unity_self, [In] ref Vector3Int startPosition, [In] ref Vector3Int endPosition);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetTileAssetsRangeNonAlloc_Injected(IntPtr _unity_self, [In] ref Vector3Int startPosition, [In] ref Vector3Int endPosition, ref ManagedSpanWrapper positions, Object[] tiles);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position, IntPtr tile);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTileAssets_Injected(IntPtr _unity_self, ref ManagedSpanWrapper positionArray, Object[] tileArray);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void INTERNAL_CALL_SetTileAssetsBlock_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Vector3Int blockDimensions, Object[] tileArray);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTile_Injected(IntPtr _unity_self, [In] ref TileChangeData tileChangeData, bool ignoreLockFlags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTiles_Injected(IntPtr _unity_self, TileChangeData[] tileChangeDataArray, bool ignoreLockFlags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RefreshTile_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void RefreshTilesNative_Injected(IntPtr _unity_self, void* positions, int count);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RefreshAllTiles_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SwapTileAsset_Injected(IntPtr _unity_self, IntPtr changeTile, IntPtr newTile);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ContainsTileAsset_Injected(IntPtr _unity_self, IntPtr tileAsset);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetUsedTilesCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetUsedSpritesCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int Internal_GetUsedTilesNonAlloc_Injected(IntPtr _unity_self, Object[] usedTiles);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int Internal_GetUsedSpritesNonAlloc_Injected(IntPtr _unity_self, Object[] usedSprites);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetSprite_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetTransformMatrix_Injected(IntPtr _unity_self, [In] ref Vector3Int position, out Matrix4x4 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTransformMatrix_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Matrix4x4 transform);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetColor_Injected(IntPtr _unity_self, [In] ref Vector3Int position, out Color ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetColor_Injected(IntPtr _unity_self, [In] ref Vector3Int position, [In] ref Color color);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TileFlags GetTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveTileFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetInstantiatedObject_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetObjectToInstantiate_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetColliderType_Injected(IntPtr _unity_self, [In] ref Vector3Int position, Tile.ColliderType colliderType);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Tile.ColliderType GetColliderType_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetAnimationFrameCount_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetAnimationFrame_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAnimationFrame_Injected(IntPtr _unity_self, [In] ref Vector3Int position, int frame);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float GetAnimationTime_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetAnimationTime_Injected(IntPtr _unity_self, [In] ref Vector3Int position, float time);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern TileAnimationFlags GetTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileAnimationFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void AddTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileAnimationFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RemoveTileAnimationFlags_Injected(IntPtr _unity_self, [In] ref Vector3Int position, TileAnimationFlags flags);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FloodFillTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position, IntPtr tile);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BoxFillTileAsset_Injected(IntPtr _unity_self, [In] ref Vector3Int position, IntPtr tile, int startX, int startY, int endX, int endY);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void InsertCells_Injected(IntPtr _unity_self, [In] ref Vector3Int position, int numColumns, int numRows, int numLayers);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void DeleteCells_Injected(IntPtr _unity_self, [In] ref Vector3Int position, int numColumns, int numRows, int numLayers);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ClearAllTiles_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ResizeBounds_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CompressTilemapBounds_Injected(IntPtr _unity_self, bool keepEditorPreview);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SendAndClearSyncTileBuffer_Injected(IntPtr _unity_self);
	}
	[Flags]
	public enum TileFlags
	{
		None = 0,
		LockColor = 1,
		LockTransform = 2,
		InstantiateGameObjectRuntimeOnly = 4,
		KeepGameObjectRuntimeOnly = 8,
		LockAll = 3
	}
	[Flags]
	public enum TileAnimationFlags
	{
		None = 0,
		LoopOnce = 1,
		PauseAnimation = 2,
		UpdatePhysics = 4,
		UnscaledTime = 8,
		SyncAnimation = 0x10
	}
	[RequireComponent(typeof(Tilemap))]
	[NativeHeader("Modules/Tilemap/TilemapRendererJobs.h")]
	[NativeHeader("Modules/Grid/Public/GridMarshalling.h")]
	[NativeType(Header = "Modules/Tilemap/Public/TilemapRenderer.h")]
	[NativeHeader("Modules/Tilemap/Public/TilemapMarshalling.h")]
	public sealed class TilemapRenderer : Renderer
	{
		public enum SortOrder
		{
			BottomLeft,
			BottomRight,
			TopLeft,
			TopRight
		}

		public enum Mode
		{
			Chunk,
			Individual,
			SRPBatch
		}

		public enum DetectChunkCullingBounds
		{
			Auto,
			Manual
		}

		public Vector3Int chunkSize
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_chunkSize_Injected(intPtr, out var ret);
				return ret;
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_chunkSize_Injected(intPtr, ref value);
			}
		}

		public Vector3 chunkCullingBounds
		{
			[FreeFunction("TilemapRendererBindings::GetChunkCullingBounds", HasExplicitThis = true)]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_chunkCullingBounds_Injected(intPtr, out var ret);
				return ret;
			}
			[FreeFunction("TilemapRendererBindings::SetChunkCullingBounds", HasExplicitThis = true)]
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_chunkCullingBounds_Injected(intPtr, ref value);
			}
		}

		public int maxChunkCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxChunkCount_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxChunkCount_Injected(intPtr, value);
			}
		}

		public int maxFrameAge
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maxFrameAge_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maxFrameAge_Injected(intPtr, value);
			}
		}

		public SortOrder sortOrder
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_sortOrder_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_sortOrder_Injected(intPtr, value);
			}
		}

		[NativeProperty("RenderMode")]
		public Mode mode
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_mode_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_mode_Injected(intPtr, value);
			}
		}

		public DetectChunkCullingBounds detectChunkCullingBounds
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_detectChunkCullingBounds_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_detectChunkCullingBounds_Injected(intPtr, value);
			}
		}

		public SpriteMaskInteraction maskInteraction
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maskInteraction_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maskInteraction_Injected(intPtr, value);
			}
		}

		[RequiredByNativeCode]
		internal void RegisterSpriteAtlasRegistered()
		{
			SpriteAtlasManager.atlasRegistered += OnSpriteAtlasRegistered;
		}

		[RequiredByNativeCode]
		internal void UnregisterSpriteAtlasRegistered()
		{
			SpriteAtlasManager.atlasRegistered -= OnSpriteAtlasRegistered;
		}

		internal void OnSpriteAtlasRegistered(SpriteAtlas atlas)
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			OnSpriteAtlasRegistered_Injected(intPtr, MarshalledUnityObject.Marshal(atlas));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_chunkSize_Injected(IntPtr _unity_self, out Vector3Int ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_chunkSize_Injected(IntPtr _unity_self, [In] ref Vector3Int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void get_chunkCullingBounds_Injected(IntPtr _unity_self, out Vector3 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_chunkCullingBounds_Injected(IntPtr _unity_self, [In] ref Vector3 value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_maxChunkCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxChunkCount_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int get_maxFrameAge_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maxFrameAge_Injected(IntPtr _unity_self, int value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern SortOrder get_sortOrder_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_sortOrder_Injected(IntPtr _unity_self, SortOrder value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Mode get_mode_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_mode_Injected(IntPtr _unity_self, Mode value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern DetectChunkCullingBounds get_detectChunkCullingBounds_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_detectChunkCullingBounds_Injected(IntPtr _unity_self, DetectChunkCullingBounds value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern SpriteMaskInteraction get_maskInteraction_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maskInteraction_Injected(IntPtr _unity_self, SpriteMaskInteraction value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void OnSpriteAtlasRegistered_Injected(IntPtr _unity_self, IntPtr atlas);
	}
	[RequiredByNativeCode]
	[NativeType(Header = "Modules/Tilemap/TilemapScripting.h")]
	public struct TileData
	{
		private int m_Sprite;

		private Color m_Color;

		private Matrix4x4 m_Transform;

		private int m_GameObject;

		private TileFlags m_Flags;

		private Tile.ColliderType m_ColliderType;

		internal static readonly TileData Default = CreateDefault();

		public Sprite sprite
		{
			get
			{
				return Object.ForceLoadFromInstanceID(m_Sprite) as Sprite;
			}
			set
			{
				m_Sprite = ((value != null) ? value.GetInstanceID() : 0);
			}
		}

		public Color color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public Matrix4x4 transform
		{
			get
			{
				return m_Transform;
			}
			set
			{
				m_Transform = value;
			}
		}

		public GameObject gameObject
		{
			get
			{
				return Object.ForceLoadFromInstanceID(m_GameObject) as GameObject;
			}
			set
			{
				m_GameObject = ((value != null) ? value.GetInstanceID() : 0);
			}
		}

		public TileFlags flags
		{
			get
			{
				return m_Flags;
			}
			set
			{
				m_Flags = value;
			}
		}

		public Tile.ColliderType colliderType
		{
			get
			{
				return m_ColliderType;
			}
			set
			{
				m_ColliderType = value;
			}
		}

		private static TileData CreateDefault()
		{
			return new TileData
			{
				color = Color.white,
				transform = Matrix4x4.identity,
				flags = TileFlags.None,
				colliderType = Tile.ColliderType.None
			};
		}
	}
	[RequiredByNativeCode]
	[NativeType(Header = "Modules/Tilemap/TilemapScripting.h")]
	internal struct TileDataNative
	{
		private int m_Sprite;

		private Color m_Color;

		private Matrix4x4 m_Transform;

		private int m_GameObject;

		private TileFlags m_Flags;

		private Tile.ColliderType m_ColliderType;

		public int sprite
		{
			get
			{
				return m_Sprite;
			}
			set
			{
				m_Sprite = value;
			}
		}

		public Color color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public Matrix4x4 transform
		{
			get
			{
				return m_Transform;
			}
			set
			{
				m_Transform = value;
			}
		}

		public int gameObject
		{
			get
			{
				return m_GameObject;
			}
			set
			{
				m_GameObject = value;
			}
		}

		public TileFlags flags
		{
			get
			{
				return m_Flags;
			}
			set
			{
				m_Flags = value;
			}
		}

		public Tile.ColliderType colliderType
		{
			get
			{
				return m_ColliderType;
			}
			set
			{
				m_ColliderType = value;
			}
		}

		public static implicit operator TileDataNative(TileData td)
		{
			return new TileDataNative
			{
				sprite = ((td.sprite != null) ? td.sprite.GetInstanceID() : 0),
				color = td.color,
				transform = td.transform,
				gameObject = ((td.gameObject != null) ? td.gameObject.GetInstanceID() : 0),
				flags = td.flags,
				colliderType = td.colliderType
			};
		}
	}
	[Serializable]
	[RequiredByNativeCode]
	[NativeType(Header = "Modules/Tilemap/TilemapScripting.h")]
	public struct TileChangeData
	{
		[SerializeField]
		private Vector3Int m_Position;

		[SerializeField]
		private Object m_TileAsset;

		[SerializeField]
		private Color m_Color;

		[SerializeField]
		private Matrix4x4 m_Transform;

		public Vector3Int position
		{
			get
			{
				return m_Position;
			}
			set
			{
				m_Position = value;
			}
		}

		public TileBase tile
		{
			get
			{
				return (TileBase)m_TileAsset;
			}
			set
			{
				m_TileAsset = value;
			}
		}

		public Color color
		{
			get
			{
				return m_Color;
			}
			set
			{
				m_Color = value;
			}
		}

		public Matrix4x4 transform
		{
			get
			{
				return m_Transform;
			}
			set
			{
				m_Transform = value;
			}
		}

		public TileChangeData(Vector3Int position, TileBase tile, Color color, Matrix4x4 transform)
		{
			m_Position = position;
			m_TileAsset = tile;
			m_Color = color;
			m_Transform = transform;
		}
	}
	[RequiredByNativeCode]
	[NativeType(Header = "Modules/Tilemap/TilemapScripting.h")]
	public struct TileAnimationData
	{
		private Sprite[] m_AnimatedSprites;

		private float m_AnimationSpeed;

		private float m_AnimationStartTime;

		private TileAnimationFlags m_Flags;

		public Sprite[] animatedSprites
		{
			get
			{
				return m_AnimatedSprites;
			}
			set
			{
				m_AnimatedSprites = value;
			}
		}

		public float animationSpeed
		{
			get
			{
				return m_AnimationSpeed;
			}
			set
			{
				m_AnimationSpeed = value;
			}
		}

		public float animationStartTime
		{
			get
			{
				return m_AnimationStartTime;
			}
			set
			{
				m_AnimationStartTime = value;
			}
		}

		public TileAnimationFlags flags
		{
			get
			{
				return m_Flags;
			}
			set
			{
				m_Flags = value;
			}
		}
	}
	[NativeType(Header = "Modules/Tilemap/Public/TilemapCollider2D.h")]
	[RequireComponent(typeof(Tilemap))]
	public sealed class TilemapCollider2D : Collider2D
	{
		public bool useDelaunayMesh
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_useDelaunayMesh_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_useDelaunayMesh_Injected(intPtr, value);
			}
		}

		public uint maximumTileChangeCount
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_maximumTileChangeCount_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_maximumTileChangeCount_Injected(intPtr, value);
			}
		}

		public float extrusionFactor
		{
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_extrusionFactor_Injected(intPtr);
			}
			set
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				set_extrusionFactor_Injected(intPtr, value);
			}
		}

		public bool hasTilemapChanges
		{
			[NativeMethod("HasTilemapChanges")]
			get
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				return get_hasTilemapChanges_Injected(intPtr);
			}
		}

		[NativeMethod(Name = "ProcessTileChangeQueue")]
		public void ProcessTilemapChanges()
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			ProcessTilemapChanges_Injected(intPtr);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_useDelaunayMesh_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_useDelaunayMesh_Injected(IntPtr _unity_self, bool value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern uint get_maximumTileChangeCount_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_maximumTileChangeCount_Injected(IntPtr _unity_self, uint value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float get_extrusionFactor_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void set_extrusionFactor_Injected(IntPtr _unity_self, float value);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool get_hasTilemapChanges_Injected(IntPtr _unity_self);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ProcessTilemapChanges_Injected(IntPtr _unity_self);
	}
}
