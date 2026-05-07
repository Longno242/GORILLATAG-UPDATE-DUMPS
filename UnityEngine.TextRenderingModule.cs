using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

[assembly: InternalsVisibleTo("UnityEngine.UIModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Tooling")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.CommonUtils")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Application")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.Deployment")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android")]
[assembly: InternalsVisibleTo("Unity.DeploymentTests.Services")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("Unity.Burst.Editor")]
[assembly: InternalsVisibleTo("Unity.Burst")]
[assembly: InternalsVisibleTo("Unity.Automation")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.2D")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("UnityEngine.Core.Runtime.Tests")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.001")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.004")]
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
[assembly: InternalsVisibleTo("Unity.Subsystem.Registration")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.005")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.004")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.003")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.002")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridgeDev.001")]
[assembly: InternalsVisibleTo("Unity.Core")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.024")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.022")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.021")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.023")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("Unity.Runtime")]
[assembly: InternalsVisibleTo("Unity.Entities.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
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
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("Unity.Collections")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("UnityEngine.TerrainPhysicsModule")]
[assembly: InternalsVisibleTo("UnityEngine.DSPGraphModule")]
[assembly: InternalsVisibleTo("UnityEngine.CrashReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IdentifiersModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConnectModule")]
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
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("UnityEngine.DirectorModule")]
[assembly: InternalsVisibleTo("UnityEngine.GIModule")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.GameCenterModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ImageConversionModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.GraphicsStateCollectionSerializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.GridModule")]
[assembly: InternalsVisibleTo("UnityEngine.HierarchyCoreModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextRenderingModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine;

public enum FontStyle
{
	Normal,
	Bold,
	Italic,
	BoldAndItalic
}
[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
[ExcludeFromPreset]
[ExcludeFromObjectFactory]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class GUIText
{
	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public bool text
	{
		get
		{
			FeatureRemoved();
			return false;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public Material material
	{
		get
		{
			FeatureRemoved();
			return null;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public Font font
	{
		get
		{
			FeatureRemoved();
			return null;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public TextAlignment alignment
	{
		get
		{
			FeatureRemoved();
			return TextAlignment.Left;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public TextAnchor anchor
	{
		get
		{
			FeatureRemoved();
			return TextAnchor.UpperLeft;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public float lineSpacing
	{
		get
		{
			FeatureRemoved();
			return 0f;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public float tabSize
	{
		get
		{
			FeatureRemoved();
			return 0f;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public int fontSize
	{
		get
		{
			FeatureRemoved();
			return 0;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public FontStyle fontStyle
	{
		get
		{
			FeatureRemoved();
			return FontStyle.Normal;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public bool richText
	{
		get
		{
			FeatureRemoved();
			return false;
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public Color color
	{
		get
		{
			FeatureRemoved();
			return new Color(0f, 0f, 0f);
		}
		set
		{
			FeatureRemoved();
		}
	}

	[Obsolete("GUIText has been removed. Use UI.Text instead.", true)]
	public Vector2 pixelOffset
	{
		get
		{
			FeatureRemoved();
			return new Vector2(0f, 0f);
		}
		set
		{
			FeatureRemoved();
		}
	}

	private static void FeatureRemoved()
	{
		throw new Exception("GUIText has been removed from Unity. Use UI.Text instead.");
	}
}
[Flags]
internal enum TextGenerationError
{
	None = 0,
	CustomSizeOnNonDynamicFont = 1,
	CustomStyleOnNonDynamicFont = 2,
	NoFont = 4
}
public struct TextGenerationSettings
{
	public Font font;

	public Color color;

	public int fontSize;

	public float lineSpacing;

	public bool richText;

	public float scaleFactor;

	public FontStyle fontStyle;

	public TextAnchor textAnchor;

	public bool alignByGeometry;

	public bool resizeTextForBestFit;

	public int resizeTextMinSize;

	public int resizeTextMaxSize;

	public bool updateBounds;

	public VerticalWrapMode verticalOverflow;

	public HorizontalWrapMode horizontalOverflow;

	public Vector2 generationExtents;

	public Vector2 pivot;

	public bool generateOutOfBounds;

	private bool CompareColors(Color left, Color right)
	{
		return Mathf.Approximately(left.r, right.r) && Mathf.Approximately(left.g, right.g) && Mathf.Approximately(left.b, right.b) && Mathf.Approximately(left.a, right.a);
	}

	private bool CompareVector2(Vector2 left, Vector2 right)
	{
		return Mathf.Approximately(left.x, right.x) && Mathf.Approximately(left.y, right.y);
	}

	public bool Equals(TextGenerationSettings other)
	{
		return CompareColors(color, other.color) && fontSize == other.fontSize && Mathf.Approximately(scaleFactor, other.scaleFactor) && resizeTextMinSize == other.resizeTextMinSize && resizeTextMaxSize == other.resizeTextMaxSize && Mathf.Approximately(lineSpacing, other.lineSpacing) && fontStyle == other.fontStyle && richText == other.richText && textAnchor == other.textAnchor && alignByGeometry == other.alignByGeometry && resizeTextForBestFit == other.resizeTextForBestFit && updateBounds == other.updateBounds && horizontalOverflow == other.horizontalOverflow && verticalOverflow == other.verticalOverflow && CompareVector2(generationExtents, other.generationExtents) && CompareVector2(pivot, other.pivot) && font == other.font;
	}
}
[StructLayout(LayoutKind.Sequential)]
[UsedByNativeCode]
[NativeHeader("Modules/TextRendering/TextGenerator.h")]
public sealed class TextGenerator : IDisposable
{
	internal static class BindingsMarshaller
	{
		public static IntPtr ConvertToNative(TextGenerator textGenerator)
		{
			return textGenerator.m_Ptr;
		}
	}

	internal IntPtr m_Ptr;

	private string m_LastString;

	private TextGenerationSettings m_LastSettings;

	private bool m_HasGenerated;

	private TextGenerationError m_LastValid;

	private readonly List<UIVertex> m_Verts;

	private readonly List<UICharInfo> m_Characters;

	private readonly List<UILineInfo> m_Lines;

	private bool m_CachedVerts;

	private bool m_CachedCharacters;

	private bool m_CachedLines;

	public int characterCountVisible => characterCount - 1;

	public IList<UIVertex> verts
	{
		get
		{
			if (!m_CachedVerts)
			{
				GetVertices(m_Verts);
				m_CachedVerts = true;
			}
			return m_Verts;
		}
	}

	public IList<UICharInfo> characters
	{
		get
		{
			if (!m_CachedCharacters)
			{
				GetCharacters(m_Characters);
				m_CachedCharacters = true;
			}
			return m_Characters;
		}
	}

	public IList<UILineInfo> lines
	{
		get
		{
			if (!m_CachedLines)
			{
				GetLines(m_Lines);
				m_CachedLines = true;
			}
			return m_Lines;
		}
	}

	public Rect rectExtents
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			get_rectExtents_Injected(intPtr, out var ret);
			return ret;
		}
	}

	public int vertexCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_vertexCount_Injected(intPtr);
		}
	}

	public int characterCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_characterCount_Injected(intPtr);
		}
	}

	public int lineCount
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_lineCount_Injected(intPtr);
		}
	}

	[NativeProperty("FontSizeFoundForBestFit", false, TargetType.Function)]
	public int fontSizeUsedForBestFit
	{
		get
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontSizeUsedForBestFit_Injected(intPtr);
		}
	}

	public TextGenerator()
		: this(50)
	{
	}

	public TextGenerator(int initialCapacity)
	{
		m_Ptr = Internal_Create();
		m_Verts = new List<UIVertex>((initialCapacity + 1) * 4);
		m_Characters = new List<UICharInfo>(initialCapacity + 1);
		m_Lines = new List<UILineInfo>(20);
	}

	~TextGenerator()
	{
		((IDisposable)this).Dispose();
	}

	void IDisposable.Dispose()
	{
		if (m_Ptr != IntPtr.Zero)
		{
			Internal_Destroy(m_Ptr);
			m_Ptr = IntPtr.Zero;
		}
	}

	private TextGenerationSettings ValidatedSettings(TextGenerationSettings settings)
	{
		if (settings.font != null && settings.font.dynamic)
		{
			return settings;
		}
		if (settings.fontSize != 0 || settings.fontStyle != FontStyle.Normal)
		{
			if (settings.font != null)
			{
				Debug.LogWarningFormat(settings.font, "Font size and style overrides are only supported for dynamic fonts. Font '{0}' is not dynamic.", settings.font.name);
			}
			settings.fontSize = 0;
			settings.fontStyle = FontStyle.Normal;
		}
		if (settings.resizeTextForBestFit)
		{
			if (settings.font != null)
			{
				Debug.LogWarningFormat(settings.font, "BestFit is only supported for dynamic fonts. Font '{0}' is not dynamic.", settings.font.name);
			}
			settings.resizeTextForBestFit = false;
		}
		return settings;
	}

	public void Invalidate()
	{
		m_HasGenerated = false;
	}

	public void GetCharacters(List<UICharInfo> characters)
	{
		GetCharactersInternal(characters);
	}

	public void GetLines(List<UILineInfo> lines)
	{
		GetLinesInternal(lines);
	}

	public void GetVertices(List<UIVertex> vertices)
	{
		GetVerticesInternal(vertices);
	}

	public float GetPreferredWidth(string str, TextGenerationSettings settings)
	{
		settings.horizontalOverflow = HorizontalWrapMode.Overflow;
		settings.verticalOverflow = VerticalWrapMode.Overflow;
		settings.updateBounds = true;
		Populate(str, settings);
		return rectExtents.width;
	}

	public float GetPreferredHeight(string str, TextGenerationSettings settings)
	{
		settings.verticalOverflow = VerticalWrapMode.Overflow;
		settings.updateBounds = true;
		Populate(str, settings);
		return rectExtents.height;
	}

	public bool PopulateWithErrors(string str, TextGenerationSettings settings, GameObject context)
	{
		TextGenerationError textGenerationError = PopulateWithError(str, settings);
		if (textGenerationError == TextGenerationError.None)
		{
			return true;
		}
		if ((textGenerationError & TextGenerationError.CustomSizeOnNonDynamicFont) != TextGenerationError.None)
		{
			Debug.LogErrorFormat(context, "Font '{0}' is not dynamic, which is required to override its size", settings.font);
		}
		if ((textGenerationError & TextGenerationError.CustomStyleOnNonDynamicFont) != TextGenerationError.None)
		{
			Debug.LogErrorFormat(context, "Font '{0}' is not dynamic, which is required to override its style", settings.font);
		}
		return false;
	}

	public bool Populate(string str, TextGenerationSettings settings)
	{
		TextGenerationError textGenerationError = PopulateWithError(str, settings);
		return textGenerationError == TextGenerationError.None;
	}

	private TextGenerationError PopulateWithError(string str, TextGenerationSettings settings)
	{
		if (m_HasGenerated && str == m_LastString && settings.Equals(m_LastSettings))
		{
			return m_LastValid;
		}
		m_LastValid = PopulateAlways(str, settings);
		return m_LastValid;
	}

	private TextGenerationError PopulateAlways(string str, TextGenerationSettings settings)
	{
		m_LastString = str;
		m_HasGenerated = true;
		m_CachedVerts = false;
		m_CachedCharacters = false;
		m_CachedLines = false;
		m_LastSettings = settings;
		TextGenerationSettings textGenerationSettings = ValidatedSettings(settings);
		Populate_Internal(str, textGenerationSettings.font, textGenerationSettings.color, textGenerationSettings.fontSize, textGenerationSettings.scaleFactor, textGenerationSettings.lineSpacing, textGenerationSettings.fontStyle, textGenerationSettings.richText, textGenerationSettings.resizeTextForBestFit, textGenerationSettings.resizeTextMinSize, textGenerationSettings.resizeTextMaxSize, textGenerationSettings.verticalOverflow, textGenerationSettings.horizontalOverflow, textGenerationSettings.updateBounds, textGenerationSettings.textAnchor, textGenerationSettings.generationExtents, textGenerationSettings.pivot, textGenerationSettings.generateOutOfBounds, textGenerationSettings.alignByGeometry, out var error);
		m_LastValid = error;
		return error;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true)]
	private static extern IntPtr Internal_Create();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[NativeMethod(IsThreadSafe = true)]
	private static extern void Internal_Destroy(IntPtr ptr);

	internal unsafe bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error)
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
			if (!StringMarshaller.TryMarshalEmptyOrNullString(str, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(str);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					return Populate_Internal_Injected(intPtr, ref managedSpanWrapper, Object.MarshalledUnityObject.Marshal(font), ref color, fontSize, scaleFactor, lineSpacing, style, richText, resizeTextForBestFit, resizeTextMinSize, resizeTextMaxSize, verticalOverFlow, horizontalOverflow, updateBounds, anchor, extentsX, extentsY, pivotX, pivotY, generateOutOfBounds, alignByGeometry, out error);
				}
			}
			return Populate_Internal_Injected(intPtr, ref managedSpanWrapper, Object.MarshalledUnityObject.Marshal(font), ref color, fontSize, scaleFactor, lineSpacing, style, richText, resizeTextForBestFit, resizeTextMinSize, resizeTextMaxSize, verticalOverFlow, horizontalOverflow, updateBounds, anchor, extentsX, extentsY, pivotX, pivotY, generateOutOfBounds, alignByGeometry, out error);
		}
		finally
		{
		}
	}

	internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, VerticalWrapMode verticalOverFlow, HorizontalWrapMode horizontalOverflow, bool updateBounds, TextAnchor anchor, Vector2 extents, Vector2 pivot, bool generateOutOfBounds, bool alignByGeometry, out TextGenerationError error)
	{
		if (font == null)
		{
			error = TextGenerationError.NoFont;
			return false;
		}
		uint error2 = 0u;
		bool result = Populate_Internal(str, font, color, fontSize, scaleFactor, lineSpacing, style, richText, resizeTextForBestFit, resizeTextMinSize, resizeTextMaxSize, (int)verticalOverFlow, (int)horizontalOverflow, updateBounds, anchor, extents.x, extents.y, pivot.x, pivot.y, generateOutOfBounds, alignByGeometry, out error2);
		error = (TextGenerationError)error2;
		return result;
	}

	public UIVertex[] GetVerticesArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		UIVertex[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetVerticesArray_Injected(intPtr, out ret);
		}
		finally
		{
			UIVertex[] array = default(UIVertex[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public UICharInfo[] GetCharactersArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		UICharInfo[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetCharactersArray_Injected(intPtr, out ret);
		}
		finally
		{
			UICharInfo[] array = default(UICharInfo[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	public UILineInfo[] GetLinesArray()
	{
		BlittableArrayWrapper ret = default(BlittableArrayWrapper);
		UILineInfo[] result;
		try
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GetLinesArray_Injected(intPtr, out ret);
		}
		finally
		{
			UILineInfo[] array = default(UILineInfo[]);
			ret.Unmarshal(ref array);
			result = array;
		}
		return result;
	}

	[NativeThrows]
	private void GetVerticesInternal(object vertices)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetVerticesInternal_Injected(intPtr, vertices);
	}

	[NativeThrows]
	private void GetCharactersInternal(object characters)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetCharactersInternal_Injected(intPtr, characters);
	}

	[NativeThrows]
	private void GetLinesInternal(object lines)
	{
		IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		GetLinesInternal_Injected(intPtr, lines);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_rectExtents_Injected(IntPtr _unity_self, out Rect ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_vertexCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_characterCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_lineCount_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_fontSizeUsedForBestFit_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Populate_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper str, IntPtr font, [In] ref Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVerticesArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCharactersArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLinesArray_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetVerticesInternal_Injected(IntPtr _unity_self, object vertices);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetCharactersInternal_Injected(IntPtr _unity_self, object characters);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetLinesInternal_Injected(IntPtr _unity_self, object lines);
}
public enum TextAlignment
{
	Left,
	Center,
	Right
}
public enum TextAnchor
{
	UpperLeft,
	UpperCenter,
	UpperRight,
	MiddleLeft,
	MiddleCenter,
	MiddleRight,
	LowerLeft,
	LowerCenter,
	LowerRight
}
public enum TextGeneratorType
{
	Standard,
	Advanced
}
public enum HorizontalWrapMode
{
	Wrap,
	Overflow
}
public enum VerticalWrapMode
{
	Truncate,
	Overflow
}
[NativeHeader("Modules/TextRendering/Public/TextMesh.h")]
[NativeClass("TextRenderingPrivate::TextMesh")]
[RequireComponent(typeof(Transform), typeof(MeshRenderer))]
public sealed class TextMesh : Component
{
	public unsafe string text
	{
		get
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
				get_text_Injected(intPtr, out ret);
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
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
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
						set_text_Injected(intPtr, ref managedSpanWrapper);
						return;
					}
				}
				set_text_Injected(intPtr, ref managedSpanWrapper);
			}
			finally
			{
			}
		}
	}

	public Font font
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Font>(get_font_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_font_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public int fontSize
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontSize_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_fontSize_Injected(intPtr, value);
		}
	}

	public FontStyle fontStyle
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontStyle_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_fontStyle_Injected(intPtr, value);
		}
	}

	public float offsetZ
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_offsetZ_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_offsetZ_Injected(intPtr, value);
		}
	}

	public TextAlignment alignment
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_alignment_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_alignment_Injected(intPtr, value);
		}
	}

	public TextAnchor anchor
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_anchor_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_anchor_Injected(intPtr, value);
		}
	}

	public float characterSize
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_characterSize_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_characterSize_Injected(intPtr, value);
		}
	}

	public float lineSpacing
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_lineSpacing_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_lineSpacing_Injected(intPtr, value);
		}
	}

	public float tabSize
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_tabSize_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_tabSize_Injected(intPtr, value);
		}
	}

	public bool richText
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_richText_Injected(intPtr);
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_richText_Injected(intPtr, value);
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

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_text_Injected(IntPtr _unity_self, out ManagedSpanWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_text_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_font_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_font_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_fontSize_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_fontSize_Injected(IntPtr _unity_self, int value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern FontStyle get_fontStyle_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_fontStyle_Injected(IntPtr _unity_self, FontStyle value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_offsetZ_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_offsetZ_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TextAlignment get_alignment_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_alignment_Injected(IntPtr _unity_self, TextAlignment value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern TextAnchor get_anchor_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_anchor_Injected(IntPtr _unity_self, TextAnchor value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_characterSize_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_characterSize_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_lineSpacing_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_lineSpacing_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern float get_tabSize_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_tabSize_Injected(IntPtr _unity_self, float value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_richText_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_richText_Injected(IntPtr _unity_self, bool value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_color_Injected(IntPtr _unity_self, out Color ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_color_Injected(IntPtr _unity_self, [In] ref Color value);
}
[UsedByNativeCode]
public struct CharacterInfo
{
	public int index;

	[Obsolete("CharacterInfo.uv is deprecated. Use uvBottomLeft, uvBottomRight, uvTopRight or uvTopLeft instead.")]
	public Rect uv;

	[Obsolete("CharacterInfo.vert is deprecated. Use minX, maxX, minY, maxY instead.")]
	public Rect vert;

	[NativeName("advance")]
	[Obsolete("CharacterInfo.width is deprecated. Use advance instead.")]
	public float width;

	public int size;

	public FontStyle style;

	[Obsolete("CharacterInfo.flipped is deprecated. Use uvBottomLeft, uvBottomRight, uvTopRight or uvTopLeft instead, which will be correct regardless of orientation.")]
	public bool flipped;

	public int advance
	{
		get
		{
			return (int)Math.Round(width, MidpointRounding.AwayFromZero);
		}
		set
		{
			width = value;
		}
	}

	public int glyphWidth
	{
		get
		{
			return (int)vert.width;
		}
		set
		{
			vert.width = value;
		}
	}

	public int glyphHeight
	{
		get
		{
			return (int)(0f - vert.height);
		}
		set
		{
			float height = vert.height;
			vert.height = -value;
			vert.y += height - vert.height;
		}
	}

	public int bearing
	{
		get
		{
			return (int)vert.x;
		}
		set
		{
			vert.x = value;
		}
	}

	public int minY
	{
		get
		{
			return (int)(vert.y + vert.height);
		}
		set
		{
			vert.height = (float)value - vert.y;
		}
	}

	public int maxY
	{
		get
		{
			return (int)vert.y;
		}
		set
		{
			float y = vert.y;
			vert.y = value;
			vert.height += y - vert.y;
		}
	}

	public int minX
	{
		get
		{
			return (int)vert.x;
		}
		set
		{
			float x = vert.x;
			vert.x = value;
			vert.width += x - vert.x;
		}
	}

	public int maxX
	{
		get
		{
			return (int)(vert.x + vert.width);
		}
		set
		{
			vert.width = (float)value - vert.x;
		}
	}

	internal Vector2 uvBottomLeftUnFlipped
	{
		get
		{
			return new Vector2(uv.x, uv.y);
		}
		set
		{
			Vector2 vector = uvTopRightUnFlipped;
			uv.x = value.x;
			uv.y = value.y;
			uv.width = vector.x - uv.x;
			uv.height = vector.y - uv.y;
		}
	}

	internal Vector2 uvBottomRightUnFlipped
	{
		get
		{
			return new Vector2(uv.x + uv.width, uv.y);
		}
		set
		{
			Vector2 vector = uvTopRightUnFlipped;
			uv.width = value.x - uv.x;
			uv.y = value.y;
			uv.height = vector.y - uv.y;
		}
	}

	internal Vector2 uvTopRightUnFlipped
	{
		get
		{
			return new Vector2(uv.x + uv.width, uv.y + uv.height);
		}
		set
		{
			uv.width = value.x - uv.x;
			uv.height = value.y - uv.y;
		}
	}

	internal Vector2 uvTopLeftUnFlipped
	{
		get
		{
			return new Vector2(uv.x, uv.y + uv.height);
		}
		set
		{
			Vector2 vector = uvTopRightUnFlipped;
			uv.x = value.x;
			uv.height = value.y - uv.y;
			uv.width = vector.x - uv.x;
		}
	}

	public Vector2 uvBottomLeft
	{
		get
		{
			return uvBottomLeftUnFlipped;
		}
		set
		{
			uvBottomLeftUnFlipped = value;
		}
	}

	public Vector2 uvBottomRight
	{
		get
		{
			return flipped ? uvTopLeftUnFlipped : uvBottomRightUnFlipped;
		}
		set
		{
			if (flipped)
			{
				uvTopLeftUnFlipped = value;
			}
			else
			{
				uvBottomRightUnFlipped = value;
			}
		}
	}

	public Vector2 uvTopRight
	{
		get
		{
			return uvTopRightUnFlipped;
		}
		set
		{
			uvTopRightUnFlipped = value;
		}
	}

	public Vector2 uvTopLeft
	{
		get
		{
			return flipped ? uvBottomRightUnFlipped : uvTopLeftUnFlipped;
		}
		set
		{
			if (flipped)
			{
				uvBottomRightUnFlipped = value;
			}
			else
			{
				uvTopLeftUnFlipped = value;
			}
		}
	}
}
[UsedByNativeCode]
public struct UICharInfo
{
	public Vector2 cursorPos;

	public float charWidth;
}
[UsedByNativeCode]
public struct UILineInfo
{
	public int startCharIdx;

	public int height;

	public float topY;

	public float leading;
}
[UsedByNativeCode]
public struct UIVertex
{
	public Vector3 position;

	public Vector3 normal;

	public Vector4 tangent;

	public Color32 color;

	public Vector4 uv0;

	public Vector4 uv1;

	public Vector4 uv2;

	public Vector4 uv3;

	private static readonly Color32 s_DefaultColor = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	private static readonly Vector4 s_DefaultTangent = new Vector4(1f, 0f, 0f, -1f);

	public static UIVertex simpleVert = new UIVertex
	{
		position = Vector3.zero,
		normal = Vector3.back,
		tangent = s_DefaultTangent,
		color = s_DefaultColor,
		uv0 = Vector4.zero,
		uv1 = Vector4.zero,
		uv2 = Vector4.zero,
		uv3 = Vector4.zero
	};
}
[NativeClass("TextRendering::Font")]
[NativeHeader("Modules/TextRendering/Public/Font.h")]
[NativeHeader("Modules/TextRendering/Public/FontImpl.h")]
[StaticAccessor("TextRenderingPrivate", StaticAccessorType.DoubleColon)]
public sealed class Font : Object
{
	public delegate void FontTextureRebuildCallback();

	public Material material
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return Unmarshal.UnmarshalUnityObject<Material>(get_material_Injected(intPtr));
		}
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_material_Injected(intPtr, MarshalledUnityObject.Marshal(value));
		}
	}

	public string[] fontNames
	{
		[return: Unmarshalled]
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontNames_Injected(intPtr);
		}
		[param: Unmarshalled]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			set_fontNames_Injected(intPtr, value);
		}
	}

	public bool dynamic
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_dynamic_Injected(intPtr);
		}
	}

	public int ascent
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_ascent_Injected(intPtr);
		}
	}

	public int fontSize
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_fontSize_Injected(intPtr);
		}
	}

	public unsafe CharacterInfo[] characterInfo
	{
		[FreeFunction("TextRenderingPrivate::GetFontCharacterInfo", HasExplicitThis = true)]
		get
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			CharacterInfo[] result;
			try
			{
				IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
				if (intPtr == (IntPtr)0)
				{
					ThrowHelper.ThrowNullReferenceException(this);
				}
				get_characterInfo_Injected(intPtr, out ret);
			}
			finally
			{
				CharacterInfo[] array = default(CharacterInfo[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}
		[FreeFunction("TextRenderingPrivate::SetFontCharacterInfo", HasExplicitThis = true)]
		set
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			Span<CharacterInfo> span = new Span<CharacterInfo>(value);
			fixed (CharacterInfo* begin = span)
			{
				ManagedSpanWrapper value2 = new ManagedSpanWrapper(begin, span.Length);
				set_characterInfo_Injected(intPtr, ref value2);
			}
		}
	}

	[NativeProperty("LineSpacing", false, TargetType.Function)]
	public int lineHeight
	{
		get
		{
			IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			return get_lineHeight_Injected(intPtr);
		}
	}

	[Obsolete("Font.textureRebuildCallback has been deprecated. Use Font.textureRebuilt instead.")]
	public FontTextureRebuildCallback textureRebuildCallback
	{
		get
		{
			return this.m_FontTextureRebuildCallback;
		}
		set
		{
			this.m_FontTextureRebuildCallback = value;
		}
	}

	public static event Action<Font> textureRebuilt;

	private event FontTextureRebuildCallback m_FontTextureRebuildCallback;

	public Font()
	{
		Internal_CreateFont(this, null);
	}

	public Font(string name)
	{
		if (Path.GetDirectoryName(name) == string.Empty)
		{
			Internal_CreateFont(this, name);
		}
		else
		{
			Internal_CreateFontFromPath(this, name);
		}
	}

	private Font(string[] names, int size)
	{
		Internal_CreateDynamicFont(this, names, size);
	}

	public static Font CreateDynamicFontFromOSFont(string fontname, int size)
	{
		return new Font(new string[1] { fontname }, size);
	}

	public static Font CreateDynamicFontFromOSFont(string[] fontnames, int size)
	{
		return new Font(fontnames, size);
	}

	[RequiredByNativeCode]
	internal static void InvokeTextureRebuilt_Internal(Font font)
	{
		Font.textureRebuilt?.Invoke(font);
		font.m_FontTextureRebuildCallback?.Invoke();
	}

	public static int GetMaxVertsForString(string str)
	{
		return str.Length * 4 + 4;
	}

	internal static Font GetDefault()
	{
		return Unmarshal.UnmarshalUnityObject<Font>(GetDefault_Injected());
	}

	public bool HasCharacter(char c)
	{
		return HasCharacter((int)c);
	}

	private bool HasCharacter(int c)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return HasCharacter_Injected(intPtr, c);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] GetOSInstalledFontNames();

	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern string[] GetPathsToOSFonts();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[VisibleToOtherModules(new string[] { "UnityEngine.TextCoreTextEngineModule" })]
	internal static extern string[] GetOSFallbacks();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[ThreadSafe]
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal static extern bool IsFontSmoothingEnabled();

	private unsafe static void Internal_CreateFont([Writable] Font self, string name)
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
					Internal_CreateFont_Injected(self, ref managedSpanWrapper);
					return;
				}
			}
			Internal_CreateFont_Injected(self, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	private unsafe static void Internal_CreateFontFromPath([Writable] Font self, string fontPath)
	{
		//The blocks IL_002a are reachable both inside and outside the pinned region starting at IL_0019. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
		try
		{
			ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
			if (!StringMarshaller.TryMarshalEmptyOrNullString(fontPath, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(fontPath);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					Internal_CreateFontFromPath_Injected(self, ref managedSpanWrapper);
					return;
				}
			}
			Internal_CreateFontFromPath_Injected(self, ref managedSpanWrapper);
		}
		finally
		{
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateDynamicFont([Writable] Font self, [Unmarshalled] string[] _names, int size);

	[FreeFunction("TextRenderingPrivate::GetCharacterInfo", HasExplicitThis = true)]
	public bool GetCharacterInfo(char ch, out CharacterInfo info, [UnityEngine.Internal.DefaultValue("0")] int size, [UnityEngine.Internal.DefaultValue("FontStyle.Normal")] FontStyle style)
	{
		IntPtr intPtr = MarshalledUnityObject.MarshalNotNull(this);
		if (intPtr == (IntPtr)0)
		{
			ThrowHelper.ThrowNullReferenceException(this);
		}
		return GetCharacterInfo_Injected(intPtr, ch, out info, size, style);
	}

	[ExcludeFromDocs]
	public bool GetCharacterInfo(char ch, out CharacterInfo info, int size)
	{
		return GetCharacterInfo(ch, out info, size, FontStyle.Normal);
	}

	[ExcludeFromDocs]
	public bool GetCharacterInfo(char ch, out CharacterInfo info)
	{
		return GetCharacterInfo(ch, out info, 0, FontStyle.Normal);
	}

	public unsafe void RequestCharactersInTexture(string characters, [UnityEngine.Internal.DefaultValue("0")] int size, [UnityEngine.Internal.DefaultValue("FontStyle.Normal")] FontStyle style)
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
			if (!StringMarshaller.TryMarshalEmptyOrNullString(characters, ref managedSpanWrapper))
			{
				ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(characters);
				fixed (char* begin = readOnlySpan)
				{
					managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
					RequestCharactersInTexture_Injected(intPtr, ref managedSpanWrapper, size, style);
					return;
				}
			}
			RequestCharactersInTexture_Injected(intPtr, ref managedSpanWrapper, size, style);
		}
		finally
		{
		}
	}

	[ExcludeFromDocs]
	public void RequestCharactersInTexture(string characters, int size)
	{
		RequestCharactersInTexture(characters, size, FontStyle.Normal);
	}

	[ExcludeFromDocs]
	public void RequestCharactersInTexture(string characters)
	{
		RequestCharactersInTexture(characters, 0, FontStyle.Normal);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr get_material_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_material_Injected(IntPtr _unity_self, IntPtr value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern string[] get_fontNames_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_fontNames_Injected(IntPtr _unity_self, string[] value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool get_dynamic_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_ascent_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_fontSize_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void get_characterInfo_Injected(IntPtr _unity_self, out BlittableArrayWrapper ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void set_characterInfo_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern int get_lineHeight_Injected(IntPtr _unity_self);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern IntPtr GetDefault_Injected();

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool HasCharacter_Injected(IntPtr _unity_self, int c);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateFont_Injected([Writable] Font self, ref ManagedSpanWrapper name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void Internal_CreateFontFromPath_Injected([Writable] Font self, ref ManagedSpanWrapper fontPath);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool GetCharacterInfo_Injected(IntPtr _unity_self, char ch, out CharacterInfo info, [UnityEngine.Internal.DefaultValue("0")] int size, [UnityEngine.Internal.DefaultValue("FontStyle.Normal")] FontStyle style);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void RequestCharactersInTexture_Injected(IntPtr _unity_self, ref ManagedSpanWrapper characters, [UnityEngine.Internal.DefaultValue("0")] int size, [UnityEngine.Internal.DefaultValue("FontStyle.Normal")] FontStyle style);
}
