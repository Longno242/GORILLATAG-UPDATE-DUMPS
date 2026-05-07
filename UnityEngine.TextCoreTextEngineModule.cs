#define UNITY_ASSERTIONS
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Microsoft.CodeAnalysis;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngine.Serialization;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.TextCore.Text;

[assembly: InternalsVisibleTo("UnityEngine.VideoModule")]
[assembly: InternalsVisibleTo("UnityEngine.VehiclesModule")]
[assembly: InternalsVisibleTo("UnityEngine.VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.XRModule")]
[assembly: InternalsVisibleTo("UnityEngine.VFXModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestWWWModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestTextureModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAudioModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestAssetBundleModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityTestProtocolModule")]
[assembly: InternalsVisibleTo("UnityEngine.VirtualTexturingModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityCurlModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UmbraModule")]
[assembly: InternalsVisibleTo("UnityEngine.ScreenCaptureModule")]
[assembly: InternalsVisibleTo("UnityEngine.WindModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS4Module")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Android.PlayerBuildAndRun")]
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
[assembly: InternalsVisibleTo("UnityEngine.SwitchModule")]
[assembly: InternalsVisibleTo("UnityEngine.TestRunner")]
[assembly: InternalsVisibleTo("UnityEngine.Advertisements")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommon")]
[assembly: InternalsVisibleTo("UnityEngine.Analytics")]
[assembly: InternalsVisibleTo("Unity.Analytics")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud.Service")]
[assembly: InternalsVisibleTo("UnityEngine.Cloud")]
[assembly: InternalsVisibleTo("UnityEngine.Networking")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine.PS5VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.PS5Module")]
[assembly: InternalsVisibleTo("UnityEngine.PS4VRModule")]
[assembly: InternalsVisibleTo("UnityEngine.Purchasing")]
[assembly: InternalsVisibleTo("UnityEngine.RuntimeInitializeOnLoadManagerInitializerModule")]
[assembly: InternalsVisibleTo("UnityEngine.PropertiesModule")]
[assembly: InternalsVisibleTo("UnityEngine.Physics2DModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsCommonModule")]
[assembly: InternalsVisibleTo("UnityEngine.TLSModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityWebRequestModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityAnalyticsModule")]
[assembly: InternalsVisibleTo("UnityEngine.PerformanceReportingModule")]
[assembly: InternalsVisibleTo("UnityEngine.ParticleSystemModule")]
[assembly: InternalsVisibleTo("UnityEngine.NVIDIAModule")]
[assembly: InternalsVisibleTo("UnityEngine.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEngine.MarshallingModule")]
[assembly: InternalsVisibleTo("UnityEngine.LocalizationModule")]
[assembly: InternalsVisibleTo("UnityEngine.InsightsModule")]
[assembly: InternalsVisibleTo("UnityEngine.UnityConsentModule")]
[assembly: InternalsVisibleTo("UnityEngine.InputForUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.IMGUIModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextEngineModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Animation")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreFontEngineModule")]
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
[assembly: InternalsVisibleTo("UnityEngine.InputLegacyModule")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetBundles")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.AssetImporting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Builds")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.016")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.015")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.014")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.013")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.012")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.011")]
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
[assembly: InternalsVisibleTo("Unity.Entities")]
[assembly: InternalsVisibleTo("Unity.Logging")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.017")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.018")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.019")]
[assembly: InternalsVisibleTo("Unity.InternalAPIEngineBridge.020")]
[assembly: InternalsVisibleTo("UnityEngine.ImguiModule")]
[assembly: InternalsVisibleTo("Unity.UIElements.Text")]
[assembly: InternalsVisibleTo("Unity.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.FontEngine.Tests")]
[assembly: InternalsVisibleTo("Unity.TextCore.Tests")]
[assembly: InternalsVisibleTo("Unity.TextMeshPro.Tests")]
[assembly: InternalsVisibleTo("UnityEngine.TextCore.Tools")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreTextModule")]
[assembly: InternalsVisibleTo("UnityEngine.TextCoreModule")]
[assembly: InternalsVisibleTo("Unity.TextCore.FontEngine.Tools")]
[assembly: InternalsVisibleTo("Unity.TextCore.FontEngine")]
[assembly: InternalsVisibleTo("Unity.Services.QoS")]
[assembly: InternalsVisibleTo("Unity.FontEngine")]
[assembly: InternalsVisibleTo("Unity.Core.Scripting.AssemblyVersion.Tests.Editor")]
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
[assembly: InternalsVisibleTo("Unity.TextMeshPro")]
[assembly: InternalsVisibleTo("Unity.ucg.QoS")]
[assembly: InternalsVisibleTo("Unity.Networking.Transport")]
[assembly: InternalsVisibleTo("Unity.GraphToolsAuthoringFramework.InternalBridge")]
[assembly: InternalsVisibleTo("Unity.Timeline")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.AllIn1Runner")]
[assembly: InternalsVisibleTo("Unity.PerformanceTests.RuntimeTestRunner.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests.Framework")]
[assembly: InternalsVisibleTo("Unity.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.PathTracing.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework.Tests")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Framework")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Timeline")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UnityAnalytics")]
[assembly: InternalsVisibleTo("Unity.Modules.Core.CoreTests.Tests.Runtime")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ExternalVersionControl")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.StandaloneBuilds")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Serialization")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Scripting")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.ScriptCompilation")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.SceneLoading")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Profiler")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Misc")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Mecanim")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.Lightmapping")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.EditorUI")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.CommandLine")]
[assembly: InternalsVisibleTo("Unity.IntegrationTests.UIToolkit")]
[assembly: InternalsVisibleTo("Assembly-CSharp-testable")]
[assembly: InternalsVisibleTo("UnityEngine.SpatialTracking")]
[assembly: InternalsVisibleTo("UnityEngine.UI")]
[assembly: InternalsVisibleTo("Unity.UIElements.RuntimeTests")]
[assembly: InternalsVisibleTo("Unity.UIElements.EditorTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.UXML")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Utils")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.StyleSheets")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Controls")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Bindings")]
[assembly: InternalsVisibleTo("UnityEngine.UIElements.Tests.Base")]
[assembly: InternalsVisibleTo("UnityEditor.UIElements.Tests")]
[assembly: InternalsVisibleTo("Unity.UI.TestFramework.Runtime")]
[assembly: InternalsVisibleTo("Assembly-CSharp-firstpass-testable")]
[assembly: InternalsVisibleTo("Unity.UIElements.PlayModeTests")]
[assembly: InternalsVisibleTo("UnityEngine.UIElementsGameObjectsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.EditorTests")]
[assembly: InternalsVisibleTo("UnityEditor.UIBuilderModule")]
[assembly: InternalsVisibleTo("Unity.UI.Builder.Editor")]
[assembly: InternalsVisibleTo("Universal2DGraphicsTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.EditorTests")]
[assembly: InternalsVisibleTo("Unity.2D.Sprite.Editor")]
[assembly: InternalsVisibleTo("Unity.RenderPipelines.Universal.2D.Runtime")]
[assembly: InternalsVisibleTo("Unity.WindowsMRAutomation")]
[assembly: InternalsVisibleTo("GoogleAR.UnityNative")]
[assembly: InternalsVisibleTo("Unity.UIElements.Editor")]
[assembly: InternalsVisibleTo("UnityEngine.UI.Tests")]
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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
namespace UnityEngine.TextCore
{
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextGenerationSettings.h")]
	[UsedByNativeCode("TextGenerationSettings")]
	internal struct NativeTextGenerationSettings
	{
		public IntPtr fontAsset;

		public IntPtr textSettings;

		public string text;

		public int screenWidth;

		public int screenHeight;

		public WhiteSpace wordWrap;

		public TextOverflow overflow;

		public LanguageDirection languageDirection;

		public int vertexPadding;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal HorizontalAlignment horizontalAlignment;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal VerticalAlignment verticalAlignment;

		public int fontSize;

		public bool bestFit;

		public int maxFontSize;

		public int minFontSize;

		public FontStyles fontStyle;

		public TextFontWeight fontWeight;

		public TextSpan[] textSpans;

		public Color32 color;

		public int characterSpacing;

		public int wordSpacing;

		public int paragraphSpacing;

		public bool hasLink => textSpans != null && Array.Exists(textSpans, (TextSpan span) => span.linkID != -1);

		public static NativeTextGenerationSettings Default => new NativeTextGenerationSettings
		{
			fontStyle = FontStyles.Normal,
			fontWeight = TextFontWeight.Regular,
			color = Color.black
		};

		public readonly TextSpan CreateTextSpan()
		{
			return new TextSpan
			{
				fontAsset = fontAsset,
				fontSize = fontSize,
				color = color,
				fontStyle = fontStyle,
				fontWeight = fontWeight,
				alignment = horizontalAlignment,
				linkID = -1
			};
		}

		public string GetTextSpanContent(int spanIndex)
		{
			if (string.IsNullOrEmpty(text))
			{
				throw new InvalidOperationException("The text property is null or empty.");
			}
			if (textSpans == null || spanIndex < 0 || spanIndex >= textSpans.Length)
			{
				throw new ArgumentOutOfRangeException("spanIndex", "Invalid span index.");
			}
			TextSpan textSpan = textSpans[spanIndex];
			if (textSpan.startIndex < 0 || textSpan.startIndex >= text.Length || textSpan.startIndex + textSpan.length > text.Length)
			{
				throw new ArgumentOutOfRangeException("spanIndex", "Invalid startIndex or length for the current text.");
			}
			return text.Substring(textSpan.startIndex, textSpan.length);
		}

		internal NativeTextGenerationSettings(NativeTextGenerationSettings tgs)
		{
			text = tgs.text;
			fontSize = tgs.fontSize;
			bestFit = tgs.bestFit;
			maxFontSize = tgs.maxFontSize;
			minFontSize = tgs.minFontSize;
			screenWidth = tgs.screenWidth;
			screenHeight = tgs.screenHeight;
			wordWrap = tgs.wordWrap;
			horizontalAlignment = tgs.horizontalAlignment;
			verticalAlignment = tgs.verticalAlignment;
			color = tgs.color;
			fontAsset = tgs.fontAsset;
			textSettings = tgs.textSettings;
			fontStyle = tgs.fontStyle;
			fontWeight = tgs.fontWeight;
			languageDirection = tgs.languageDirection;
			vertexPadding = tgs.vertexPadding;
			overflow = tgs.overflow;
			textSpans = ((tgs.textSpans != null) ? ((TextSpan[])tgs.textSpans.Clone()) : null);
			characterSpacing = tgs.characterSpacing;
			wordSpacing = tgs.wordSpacing;
			paragraphSpacing = tgs.paragraphSpacing;
		}

		public override string ToString()
		{
			string text = "null";
			if (textSpans != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("[");
				for (int i = 0; i < textSpans.Length; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(textSpans[i].ToString());
				}
				stringBuilder.Append("]");
				text = stringBuilder.ToString();
			}
			return string.Format("{0}: {1}\n", "fontAsset", fontAsset) + string.Format("{0}: {1}\n", "textSettings", textSettings) + "text: " + this.text + "\n" + string.Format("{0}: {1}\n", "screenWidth", screenWidth) + string.Format("{0}: {1}\n", "screenHeight", screenHeight) + string.Format("{0}: {1}\n", "fontSize", fontSize) + string.Format("{0}: {1}\n", "bestFit", bestFit) + string.Format("{0}: {1}\n", "maxFontSize", maxFontSize) + string.Format("{0}: {1}\n", "minFontSize", minFontSize) + string.Format("{0}: {1}\n", "wordWrap", wordWrap) + string.Format("{0}: {1}\n", "languageDirection", languageDirection) + string.Format("{0}: {1}\n", "horizontalAlignment", horizontalAlignment) + string.Format("{0}: {1}\n", "verticalAlignment", verticalAlignment) + string.Format("{0}: {1}\n", "color", color) + string.Format("{0}: {1}\n", "fontStyle", fontStyle) + string.Format("{0}: {1}\n", "fontWeight", fontWeight) + string.Format("{0}: {1}\n", "vertexPadding", vertexPadding) + string.Format("{0}: {1}\n", "overflow", overflow) + "textSpans: " + text + "\n" + string.Format("{0}: {1}\n", "characterSpacing", characterSpacing) + string.Format("{0}: {1}\n", "paragraphSpacing", paragraphSpacing) + string.Format("{0}: {1}\n", "wordSpacing", wordSpacing);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal struct TextSpan
	{
		public int startIndex;

		public int length;

		public IntPtr fontAsset;

		public int fontSize;

		public Color32 color;

		public FontStyles fontStyle;

		public TextFontWeight fontWeight;

		public int linkID;

		public HorizontalAlignment alignment;

		public override string ToString()
		{
			return string.Format("{0}: {1}\n", "color", color) + string.Format("{0}: {1}\n", "fontStyle", fontStyle) + string.Format("{0}: {1}\n", "fontWeight", fontWeight) + string.Format("{0}: {1}\n", "linkID", linkID) + string.Format("{0}: {1}\n", "fontSize", fontSize) + string.Format("{0}: {1}", "fontAsset", fontAsset) + string.Format("{0}: {1}\n", "startIndex", startIndex) + string.Format("{0}: {1}", "length", length);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal enum HorizontalAlignment
	{
		Left,
		Center,
		Right,
		Justified
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal enum VerticalAlignment
	{
		Top,
		Middle,
		Bottom
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal enum LanguageDirection
	{
		LTR,
		RTL
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal enum WhiteSpace
	{
		Normal,
		NoWrap,
		Pre,
		PreWrap
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal enum TextOverflow
	{
		Clip,
		Ellipsis
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal static class RichTextTagParser
	{
		public enum TagType
		{
			Hyperlink,
			Align,
			AllCaps,
			Alpha,
			Bold,
			Br,
			Color,
			CSpace,
			Font,
			FontWeight,
			Italic,
			Indent,
			LineHeight,
			LineIndent,
			Link,
			Lowercase,
			Mark,
			Mspace,
			NoBr,
			NoParse,
			Strikethrough,
			Size,
			SmallCaps,
			Space,
			Sprite,
			Style,
			Subscript,
			Superscript,
			Underline,
			Uppercase,
			Unknown
		}

		internal record TagTypeInfo
		{
			public TagType TagType;

			public string name;

			public TagValueType valueType;

			public TagUnitType unitType;

			internal TagTypeInfo(TagType tagType, string name, TagValueType valueType = TagValueType.None, TagUnitType unitType = TagUnitType.Pixels)
			{
				TagType = tagType;
				this.name = name;
				this.valueType = valueType;
				this.unitType = unitType;
			}
		}

		internal enum TagValueType
		{
			None = 0,
			NumericalValue = 1,
			StringValue = 2,
			ColorValue = 4
		}

		internal enum TagUnitType
		{
			Pixels,
			FontUnits,
			Percentage
		}

		internal record TagValue
		{
			internal string? StringValue
			{
				get
				{
					if (type != TagValueType.StringValue)
					{
						throw new InvalidOperationException("Not a string value");
					}
					return m_stringValue;
				}
			}

			internal float NumericalValue
			{
				get
				{
					if (type != TagValueType.NumericalValue)
					{
						throw new InvalidOperationException("Not a numerical value");
					}
					return m_numericalValue;
				}
			}

			internal Color ColorValue
			{
				get
				{
					if (type != TagValueType.ColorValue)
					{
						throw new InvalidOperationException("Not a color value");
					}
					return m_colorValue;
				}
			}

			internal TagValueType type;

			private string? m_stringValue;

			private float m_numericalValue;

			private Color m_colorValue;

			internal TagValue(float value)
			{
				type = TagValueType.NumericalValue;
				m_numericalValue = value;
			}

			internal TagValue(Color value)
			{
				type = TagValueType.ColorValue;
				m_colorValue = value;
			}

			internal TagValue(string value)
			{
				type = TagValueType.StringValue;
				m_stringValue = value;
			}
		}

		internal struct Tag
		{
			public TagType tagType;

			public bool isClosing;

			public int start;

			public int end;

			public TagValue? value;
		}

		public struct Segment
		{
			public List<Tag>? tags;

			public int start;

			public int end;
		}

		internal record ParseError
		{
			public readonly int position;

			public readonly string message;

			internal ParseError(string message, int position)
			{
				this.message = message;
				this.position = position;
			}
		}

		internal static readonly TagTypeInfo[] TagsInfo = new TagTypeInfo[30]
		{
			new TagTypeInfo(TagType.Hyperlink, "a"),
			new TagTypeInfo(TagType.Align, "align"),
			new TagTypeInfo(TagType.AllCaps, "allcaps"),
			new TagTypeInfo(TagType.Alpha, "alpha"),
			new TagTypeInfo(TagType.Bold, "b"),
			new TagTypeInfo(TagType.Br, "br"),
			new TagTypeInfo(TagType.Color, "color", TagValueType.ColorValue),
			new TagTypeInfo(TagType.CSpace, "cspace"),
			new TagTypeInfo(TagType.Font, "font"),
			new TagTypeInfo(TagType.FontWeight, "font-weight"),
			new TagTypeInfo(TagType.Italic, "i"),
			new TagTypeInfo(TagType.Indent, "indent"),
			new TagTypeInfo(TagType.LineHeight, "line-height"),
			new TagTypeInfo(TagType.LineIndent, "line-indent"),
			new TagTypeInfo(TagType.Link, "link"),
			new TagTypeInfo(TagType.Lowercase, "lowercase"),
			new TagTypeInfo(TagType.Mark, "mark"),
			new TagTypeInfo(TagType.Mspace, "mspace"),
			new TagTypeInfo(TagType.NoBr, "nobr"),
			new TagTypeInfo(TagType.NoParse, "noparse"),
			new TagTypeInfo(TagType.Strikethrough, "s"),
			new TagTypeInfo(TagType.Size, "size"),
			new TagTypeInfo(TagType.SmallCaps, "smallcaps"),
			new TagTypeInfo(TagType.Space, "space"),
			new TagTypeInfo(TagType.Sprite, "sprite"),
			new TagTypeInfo(TagType.Style, "style"),
			new TagTypeInfo(TagType.Subscript, "sub"),
			new TagTypeInfo(TagType.Superscript, "sup"),
			new TagTypeInfo(TagType.Underline, "u"),
			new TagTypeInfo(TagType.Uppercase, "uppercase")
		};

		private static bool tagMatch(ReadOnlySpan<char> tagCandidate, string tagName)
		{
			return tagCandidate.StartsWith(MemoryExtensions.AsSpan(tagName)) && (tagCandidate.Length == tagName.Length || (!char.IsLetter(tagCandidate[tagName.Length]) && tagCandidate[tagName.Length] != '-'));
		}

		private static bool SpanToEnum(ReadOnlySpan<char> tagCandidate, out TagType tagType, out string? error, out ReadOnlySpan<char> attribute)
		{
			for (int i = 0; i < TagsInfo.Length; i++)
			{
				string name = TagsInfo[i].name;
				if (tagMatch(tagCandidate, name))
				{
					tagType = TagsInfo[i].TagType;
					error = null;
					attribute = tagCandidate.Slice(name.Length);
					return true;
				}
			}
			if (tagCandidate.Length > 4 && tagCandidate[0] == '#')
			{
				tagType = TagType.Color;
				error = null;
				attribute = tagCandidate;
				return true;
			}
			error = "Unknown tag: " + tagCandidate;
			tagType = TagType.Unknown;
			attribute = null;
			return false;
		}

		internal static List<Tag> FindTags(string inputStr, List<ParseError>? errors = null)
		{
			char[] array = inputStr.ToCharArray();
			List<Tag> list = new List<Tag>();
			int num = 0;
			while (true)
			{
				int num2 = Array.IndexOf(array, '<', num);
				if (num2 == -1)
				{
					break;
				}
				int num3 = Array.IndexOf(array, '>', num2);
				if (num3 == -1)
				{
					break;
				}
				bool flag = array.Length > num2 + 1 && array[num2 + 1] == '/';
				if (num3 == num2 + 1)
				{
					errors?.Add(new ParseError("Empty tag", num2));
					num = num3 + 1;
					continue;
				}
				num = num3 + 1;
				TagType tagType2;
				string error2;
				ReadOnlySpan<char> attribute2;
				if (!flag)
				{
					Span<char> span = MemoryExtensions.AsSpan(array, num2 + 1, num3 - num2 - 1);
					if (SpanToEnum(span, out TagType tagType, out string error, out ReadOnlySpan<char> attribute))
					{
						TagValue tagValue = null;
						if (tagType == TagType.Color)
						{
							attribute = GetAttributeSpan(attribute);
							ColorUtility.TryParseHtmlString(attribute.ToString(), out var color);
							tagValue = new TagValue(color);
							if ((object)tagValue == null)
							{
								errors?.Add(new ParseError("Invalid color value", num2));
								num = num2 + 1;
								continue;
							}
						}
						if (tagType == TagType.Link || tagType == TagType.Hyperlink)
						{
							if (tagType == TagType.Hyperlink && attribute.StartsWith(" href="))
							{
								attribute = attribute.Slice(" href=".Length);
							}
							attribute = GetAttributeSpan(attribute);
							string value = attribute.ToString();
							tagValue = new TagValue(value);
						}
						if (tagType == TagType.Align)
						{
							attribute = GetAttributeSpan(attribute);
							string value2 = attribute.ToString();
							if (Enum.TryParse<HorizontalAlignment>(value2, ignoreCase: true, out var _))
							{
								tagValue = new TagValue(value2);
							}
							if ((object)tagValue == null)
							{
								errors?.Add(new ParseError($"Invalid {tagType} value", num2));
								num = num2 + 1;
								continue;
							}
						}
						list.Add(new Tag
						{
							tagType = tagType,
							start = num2,
							end = num3,
							isClosing = flag,
							value = tagValue
						});
						if (tagType == TagType.NoParse)
						{
							if ((num2 = MemoryExtensions.AsSpan(array, num).IndexOf("</noparse>")) == -1)
							{
								break;
							}
							num2 += num;
							num3 = num2 + "</noparse>".Length;
							list.Add(new Tag
							{
								tagType = TagType.NoParse,
								start = num2,
								end = num3,
								isClosing = true
							});
							num = num3 + 1;
						}
					}
					else
					{
						if (error != null)
						{
							errors?.Add(new ParseError(error, num2));
						}
						num = num2 + 1;
					}
				}
				else if (SpanToEnum(MemoryExtensions.AsSpan(array, num2 + 2, num3 - num2 - 2), out tagType2, out error2, out attribute2))
				{
					list.Add(new Tag
					{
						tagType = tagType2,
						start = num2,
						end = num3,
						isClosing = flag
					});
				}
				else
				{
					if (error2 != null)
					{
						errors?.Add(new ParseError(error2, num2));
					}
					num = num2 + 1;
				}
			}
			return list;
		}

		private static ReadOnlySpan<char> GetAttributeSpan(ReadOnlySpan<char> atributeSection)
		{
			if (atributeSection.Length >= 2 && atributeSection[0] == '=')
			{
				atributeSection = atributeSection.Slice(1);
			}
			if (atributeSection.Length >= 2)
			{
				if (atributeSection[0] == '"')
				{
					if (atributeSection[atributeSection.Length - 1] == '"')
					{
						goto IL_0082;
					}
				}
				if (atributeSection[0] == '\'')
				{
					if (atributeSection[atributeSection.Length - 1] == '\'')
					{
						goto IL_0082;
					}
				}
			}
			return atributeSection;
			IL_0082:
			return atributeSection.Slice(1, atributeSection.Length - 2);
		}

		internal static List<Tag> PickResultingTags(List<Tag> allTags, string input, int atPosition, List<Tag>? applicableTags = null)
		{
			if (applicableTags == null)
			{
				applicableTags = new List<Tag>();
			}
			else
			{
				applicableTags.Clear();
			}
			int num = 0;
			Debug.Assert(string.IsNullOrEmpty(input) || (atPosition < input.Length && atPosition >= 0), "Invalid position");
			Debug.Assert(num <= atPosition && num >= 0, "Invalid starting position");
			int num2 = 0;
			foreach (Tag allTag in allTags)
			{
				Debug.Assert(allTag.start >= num2, "Tags are not sorted");
				num2 = allTag.end + 1;
			}
			foreach (Tag applicableTag in applicableTags)
			{
				Debug.Assert(applicableTag.end <= num, "Tag end pass the point where we should start parsing");
				Debug.Assert(allTags.Contains(applicableTag));
			}
			Span<int?> span = stackalloc int?[allTags.Count];
			Span<int?> span2 = stackalloc int?[TagsInfo.Length];
			int num3 = -1;
			foreach (Tag allTag2 in allTags)
			{
				num3++;
				if (allTag2.end < num || allTag2.tagType == TagType.NoParse)
				{
					continue;
				}
				if (allTag2.start > atPosition)
				{
					break;
				}
				if (allTag2.isClosing)
				{
					if (span2[(int)allTag2.tagType].HasValue)
					{
						if (span[num3].HasValue)
						{
							span2[(int)allTag2.tagType] = span[num3];
						}
						else
						{
							span2[(int)allTag2.tagType] = null;
						}
					}
				}
				else
				{
					int? num4 = span2[(int)allTag2.tagType];
					if (num4.HasValue)
					{
						span[num3] = num4;
					}
					span2[(int)allTag2.tagType] = num3;
				}
			}
			int num5 = 0;
			foreach (Tag allTag3 in allTags)
			{
				int? num6 = span2[(int)allTag3.tagType];
				if (num6.HasValue && num5 == num6.Value)
				{
					applicableTags.Add(allTag3);
				}
				num5++;
			}
			return applicableTags;
		}

		internal static Segment[] GenerateSegments(string input, List<Tag> tags)
		{
			List<Segment> list = new List<Segment>();
			int num = 0;
			for (int i = 0; i < tags.Count; i++)
			{
				Debug.Assert(tags[i].start >= num);
				if (tags[i].start > num)
				{
					list.Add(new Segment
					{
						start = num,
						end = tags[i].start - 1
					});
				}
				num = tags[i].end + 1;
			}
			if (num < input.Length)
			{
				list.Add(new Segment
				{
					start = num,
					end = input.Length - 1
				});
			}
			return list.ToArray();
		}

		internal static void ApplyStateToSegment(string input, List<Tag> tags, Segment[] segments)
		{
			for (int i = 0; i < segments.Length; i++)
			{
				segments[i].tags = PickResultingTags(tags, input, segments[i].start);
			}
		}

		private static int AddLink(TagType type, string value, List<(int, TagType, string)> links)
		{
			foreach (var (result, tagType, text) in links)
			{
				if (type == tagType && value == text)
				{
					return result;
				}
			}
			int count = links.Count;
			links.Add((count, type, value));
			return count;
		}

		private static TextSpan CreateTextSpan(Segment segment, ref NativeTextGenerationSettings tgs, List<(int, TagType, string)> links, Color hyperlinkColor)
		{
			TextSpan result = tgs.CreateTextSpan();
			if (segment.tags == null)
			{
				return result;
			}
			for (int i = 0; i < segment.tags.Count; i++)
			{
				switch (segment.tags[i].tagType)
				{
				case TagType.Bold:
					result.fontWeight = TextFontWeight.Bold;
					break;
				case TagType.Italic:
					result.fontStyle |= FontStyles.Italic;
					break;
				case TagType.Underline:
					result.fontStyle |= FontStyles.Underline;
					break;
				case TagType.Strikethrough:
					result.fontStyle |= FontStyles.Strikethrough;
					break;
				case TagType.Subscript:
					result.fontStyle |= FontStyles.Subscript;
					break;
				case TagType.Superscript:
					result.fontStyle |= FontStyles.Superscript;
					break;
				case TagType.AllCaps:
				case TagType.Uppercase:
					result.fontStyle |= FontStyles.UpperCase;
					break;
				case TagType.Lowercase:
				case TagType.SmallCaps:
					result.fontStyle |= FontStyles.LowerCase;
					break;
				case TagType.Color:
					result.color = segment.tags[i].value.ColorValue;
					break;
				case TagType.Mark:
					result.fontStyle |= FontStyles.Highlight;
					break;
				case TagType.Hyperlink:
					result.linkID = AddLink(TagType.Hyperlink, segment.tags[i].value?.StringValue ?? "", links);
					result.color = hyperlinkColor;
					result.fontStyle |= FontStyles.Underline;
					break;
				case TagType.Link:
					result.linkID = AddLink(TagType.Link, segment.tags[i].value?.StringValue ?? "", links);
					break;
				case TagType.Align:
					Enum.TryParse<HorizontalAlignment>(segment.tags[i].value.StringValue, ignoreCase: true, out result.alignment);
					break;
				case TagType.NoParse:
				case TagType.Unknown:
					throw new InvalidOperationException("Invalid tag type" + segment.tags[i].tagType);
				}
			}
			return result;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static void CreateTextGenerationSettingsArray(ref NativeTextGenerationSettings tgs, List<(int, TagType, string)> links, Color hyperlinkColor)
		{
			links.Clear();
			List<Tag> tags = FindTags(tgs.text);
			Segment[] array = GenerateSegments(tgs.text, tags);
			ApplyStateToSegment(tgs.text, tags, array);
			StringBuilder stringBuilder = new StringBuilder(tgs.text.Length);
			tgs.textSpans = new TextSpan[array.Length];
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				Segment segment = array[i];
				string text = tgs.text.Substring(segment.start, segment.end + 1 - segment.start);
				TextSpan textSpan = CreateTextSpan(segment, ref tgs, links, hyperlinkColor);
				textSpan.startIndex = num;
				textSpan.length = text.Length;
				tgs.textSpans[i] = textSpan;
				stringBuilder.Append(text);
				num += text.Length;
			}
			tgs.text = stringBuilder.ToString();
		}
	}
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextRenderingIndices.h")]
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal struct TextRenderingIndices
	{
		public int meshIndex;

		public int textElementInfoIndex;
	}
}
namespace UnityEngine.TextCore.Text
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/ATGMeshInfo.h")]
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal struct ATGMeshInfo
	{
		public NativeTextElementInfo[] textElementInfos;

		public int fontAssetId;

		public int textElementCount;

		[Ignore]
		public FontAsset fontAsset;

		[Ignore]
		public List<List<int>> textElementInfoIndicesByAtlas;

		[Ignore]
		public bool hasMultipleColors;
	}
	[Serializable]
	public class Character : TextElement
	{
		public Character()
		{
			m_ElementType = TextElementType.Character;
			base.scale = 1f;
		}

		public Character(uint unicode, Glyph glyph)
		{
			m_ElementType = TextElementType.Character;
			base.unicode = unicode;
			base.textAsset = null;
			base.glyph = glyph;
			base.glyphIndex = glyph.index;
			base.scale = 1f;
		}

		public Character(uint unicode, FontAsset fontAsset, Glyph glyph)
		{
			m_ElementType = TextElementType.Character;
			base.unicode = unicode;
			base.textAsset = fontAsset;
			base.glyph = glyph;
			base.glyphIndex = glyph.index;
			base.scale = 1f;
		}

		internal Character(uint unicode, uint glyphIndex)
		{
			m_ElementType = TextElementType.Character;
			base.unicode = unicode;
			base.textAsset = null;
			base.glyph = null;
			base.glyphIndex = glyphIndex;
			base.scale = 1f;
		}
	}
	internal static class ColorUtilities
	{
		internal static bool CompareColors(Color32 a, Color32 b)
		{
			return a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
		}

		internal static Color32 MultiplyColors(Color32 c1, Color32 c2)
		{
			byte r = (byte)((float)(int)c1.r / 255f * ((float)(int)c2.r / 255f) * 255f);
			byte g = (byte)((float)(int)c1.g / 255f * ((float)(int)c2.g / 255f) * 255f);
			byte b = (byte)((float)(int)c1.b / 255f * ((float)(int)c2.b / 255f) * 255f);
			byte a = (byte)((float)(int)c1.a / 255f * ((float)(int)c2.a / 255f) * 255f);
			return new Color32(r, g, b, a);
		}
	}
	public class FastAction
	{
		private LinkedList<Action> delegates = new LinkedList<Action>();

		private Dictionary<Action, LinkedListNode<Action>> lookup = new Dictionary<Action, LinkedListNode<Action>>();

		public void Add(Action rhs)
		{
			if (!lookup.ContainsKey(rhs))
			{
				lookup[rhs] = delegates.AddLast(rhs);
			}
		}

		public void Remove(Action rhs)
		{
			if (lookup.TryGetValue(rhs, out var value))
			{
				lookup.Remove(rhs);
				delegates.Remove(value);
			}
		}

		public void Call()
		{
			for (LinkedListNode<Action> linkedListNode = delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value();
			}
		}
	}
	public class FastAction<A>
	{
		private LinkedList<Action<A>> delegates = new LinkedList<Action<A>>();

		private Dictionary<Action<A>, LinkedListNode<Action<A>>> lookup = new Dictionary<Action<A>, LinkedListNode<Action<A>>>();

		public void Add(Action<A> rhs)
		{
			if (!lookup.ContainsKey(rhs))
			{
				lookup[rhs] = delegates.AddLast(rhs);
			}
		}

		public void Remove(Action<A> rhs)
		{
			if (lookup.TryGetValue(rhs, out var value))
			{
				lookup.Remove(rhs);
				delegates.Remove(value);
			}
		}

		public void Call(A a)
		{
			for (LinkedListNode<Action<A>> linkedListNode = delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value(a);
			}
		}
	}
	public class FastAction<A, B>
	{
		private LinkedList<Action<A, B>> delegates = new LinkedList<Action<A, B>>();

		private Dictionary<Action<A, B>, LinkedListNode<Action<A, B>>> lookup = new Dictionary<Action<A, B>, LinkedListNode<Action<A, B>>>();

		public void Add(Action<A, B> rhs)
		{
			if (!lookup.ContainsKey(rhs))
			{
				lookup[rhs] = delegates.AddLast(rhs);
			}
		}

		public void Remove(Action<A, B> rhs)
		{
			if (lookup.TryGetValue(rhs, out var value))
			{
				lookup.Remove(rhs);
				delegates.Remove(value);
			}
		}

		public void Call(A a, B b)
		{
			for (LinkedListNode<Action<A, B>> linkedListNode = delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value(a, b);
			}
		}
	}
	public class FastAction<A, B, C>
	{
		private LinkedList<Action<A, B, C>> delegates = new LinkedList<Action<A, B, C>>();

		private Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>> lookup = new Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>>();

		public void Add(Action<A, B, C> rhs)
		{
			if (!lookup.ContainsKey(rhs))
			{
				lookup[rhs] = delegates.AddLast(rhs);
			}
		}

		public void Remove(Action<A, B, C> rhs)
		{
			if (lookup.TryGetValue(rhs, out var value))
			{
				lookup.Remove(rhs);
				delegates.Remove(value);
			}
		}

		public void Call(A a, B b, C c)
		{
			for (LinkedListNode<Action<A, B, C>> linkedListNode = delegates.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value(a, b, c);
			}
		}
	}
	public enum OTL_FeatureTag : uint
	{
		kern = 1801810542u,
		liga = 1818847073u,
		mark = 1835102827u,
		mkmk = 1835756907u
	}
	[Serializable]
	public class FontFeatureTable
	{
		[SerializeField]
		internal List<MultipleSubstitutionRecord> m_MultipleSubstitutionRecords;

		[SerializeField]
		internal List<LigatureSubstitutionRecord> m_LigatureSubstitutionRecords;

		[SerializeField]
		private List<GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecords;

		[SerializeField]
		internal List<MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecords;

		[SerializeField]
		internal List<MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecords;

		internal Dictionary<uint, List<LigatureSubstitutionRecord>> m_LigatureSubstitutionRecordLookup;

		internal Dictionary<uint, GlyphPairAdjustmentRecord> m_GlyphPairAdjustmentRecordLookup;

		internal Dictionary<uint, MarkToBaseAdjustmentRecord> m_MarkToBaseAdjustmentRecordLookup;

		internal Dictionary<uint, MarkToMarkAdjustmentRecord> m_MarkToMarkAdjustmentRecordLookup;

		internal List<MultipleSubstitutionRecord> multipleSubstitutionRecords
		{
			get
			{
				return m_MultipleSubstitutionRecords;
			}
			set
			{
				m_MultipleSubstitutionRecords = value;
			}
		}

		internal List<LigatureSubstitutionRecord> ligatureRecords
		{
			get
			{
				return m_LigatureSubstitutionRecords;
			}
			set
			{
				m_LigatureSubstitutionRecords = value;
			}
		}

		internal List<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords => m_GlyphPairAdjustmentRecords;

		internal List<MarkToBaseAdjustmentRecord> MarkToBaseAdjustmentRecords
		{
			get
			{
				return m_MarkToBaseAdjustmentRecords;
			}
			set
			{
				m_MarkToBaseAdjustmentRecords = value;
			}
		}

		internal List<MarkToMarkAdjustmentRecord> MarkToMarkAdjustmentRecords
		{
			get
			{
				return m_MarkToMarkAdjustmentRecords;
			}
			set
			{
				m_MarkToMarkAdjustmentRecords = value;
			}
		}

		internal FontFeatureTable()
		{
			m_LigatureSubstitutionRecords = new List<LigatureSubstitutionRecord>();
			m_LigatureSubstitutionRecordLookup = new Dictionary<uint, List<LigatureSubstitutionRecord>>();
			m_GlyphPairAdjustmentRecords = new List<GlyphPairAdjustmentRecord>();
			m_GlyphPairAdjustmentRecordLookup = new Dictionary<uint, GlyphPairAdjustmentRecord>();
			m_MarkToBaseAdjustmentRecords = new List<MarkToBaseAdjustmentRecord>();
			m_MarkToBaseAdjustmentRecordLookup = new Dictionary<uint, MarkToBaseAdjustmentRecord>();
			m_MarkToMarkAdjustmentRecords = new List<MarkToMarkAdjustmentRecord>();
			m_MarkToMarkAdjustmentRecordLookup = new Dictionary<uint, MarkToMarkAdjustmentRecord>();
		}

		public void SortGlyphPairAdjustmentRecords()
		{
			if (m_GlyphPairAdjustmentRecords.Count > 1)
			{
				m_GlyphPairAdjustmentRecords = (from s in m_GlyphPairAdjustmentRecords
					orderby s.firstAdjustmentRecord.glyphIndex, s.secondAdjustmentRecord.glyphIndex
					select s).ToList();
			}
		}

		public void SortMarkToBaseAdjustmentRecords()
		{
			if (m_MarkToBaseAdjustmentRecords.Count > 0)
			{
				m_MarkToBaseAdjustmentRecords = (from s in m_MarkToBaseAdjustmentRecords
					orderby s.baseGlyphID, s.markGlyphID
					select s).ToList();
			}
		}

		public void SortMarkToMarkAdjustmentRecords()
		{
			if (m_MarkToMarkAdjustmentRecords.Count > 0)
			{
				m_MarkToMarkAdjustmentRecords = (from s in m_MarkToMarkAdjustmentRecords
					orderby s.baseMarkGlyphID, s.combiningMarkGlyphID
					select s).ToList();
			}
		}
	}
	internal struct Extents(Vector2 min, Vector2 max)
	{
		public Vector2 min = min;

		public Vector2 max = max;

		public override string ToString()
		{
			return "Min (" + min.x.ToString("f2") + ", " + min.y.ToString("f2") + ")   Max (" + max.x.ToString("f2") + ", " + max.y.ToString("f2") + ")";
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct LineInfo
	{
		internal int controlCharacterCount;

		public int characterCount;

		public int visibleCharacterCount;

		public int visibleSpaceCount;

		public int spaceCount;

		public int wordCount;

		public int firstCharacterIndex;

		public int firstVisibleCharacterIndex;

		public int lastCharacterIndex;

		public int lastVisibleCharacterIndex;

		public float length;

		public float lineHeight;

		public float ascender;

		public float baseline;

		public float descender;

		public float maxAdvance;

		public float width;

		public float marginLeft;

		public float marginRight;

		public TextAlignment alignment;

		public Extents lineExtents;
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct LinkInfo
	{
		public int hashCode;

		public int linkIdFirstCharacterIndex;

		public int linkIdLength;

		public int linkTextfirstCharacterIndex;

		public int linkTextLength;

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal char[] linkId;

		private string m_LinkIdString;

		private string m_LinkTextString;

		internal void SetLinkId(char[] text, int startIndex, int length)
		{
			if (linkId == null || linkId.Length < length)
			{
				linkId = new char[length];
			}
			for (int i = 0; i < length; i++)
			{
				linkId[i] = text[startIndex + i];
			}
			linkIdLength = length;
			m_LinkIdString = null;
			m_LinkTextString = null;
		}

		public string GetLinkText(TextInfo textInfo)
		{
			if (string.IsNullOrEmpty(m_LinkTextString))
			{
				for (int i = linkTextfirstCharacterIndex; i < linkTextfirstCharacterIndex + linkTextLength; i++)
				{
					m_LinkTextString += (char)textInfo.textElementInfo[i].character;
				}
			}
			return m_LinkTextString;
		}

		public string GetLinkId()
		{
			if (string.IsNullOrEmpty(m_LinkIdString))
			{
				m_LinkIdString = new string(linkId, 0, linkIdLength);
			}
			return m_LinkIdString;
		}
	}
	internal static class MaterialManager
	{
		private static Dictionary<long, Material> s_FallbackMaterials = new Dictionary<long, Material>();

		public static Material GetFallbackMaterial(Material sourceMaterial, Material targetMaterial)
		{
			bool flag = !JobsUtility.IsExecutingJob;
			int hashCode = sourceMaterial.GetHashCode();
			int hashCode2 = targetMaterial.GetHashCode();
			long key = ((long)hashCode << 32) | (uint)hashCode2;
			if (s_FallbackMaterials.TryGetValue(key, out var value))
			{
				if (!(value == null))
				{
					if (!flag)
					{
						return value;
					}
					int num = sourceMaterial.ComputeCRC();
					int num2 = value.ComputeCRC();
					if (num == num2)
					{
						return value;
					}
					CopyMaterialPresetProperties(sourceMaterial, value);
					return value;
				}
				s_FallbackMaterials.Remove(key);
			}
			if (sourceMaterial.HasProperty(TextShaderUtilities.ID_GradientScale) && targetMaterial.HasProperty(TextShaderUtilities.ID_GradientScale))
			{
				Texture texture = targetMaterial.GetTexture(TextShaderUtilities.ID_MainTex);
				value = new Material(sourceMaterial);
				value.hideFlags = HideFlags.HideAndDontSave;
				value.SetTexture(TextShaderUtilities.ID_MainTex, texture);
				value.SetFloat(TextShaderUtilities.ID_GradientScale, targetMaterial.GetFloat(TextShaderUtilities.ID_GradientScale));
				value.SetFloat(TextShaderUtilities.ID_TextureWidth, targetMaterial.GetFloat(TextShaderUtilities.ID_TextureWidth));
				value.SetFloat(TextShaderUtilities.ID_TextureHeight, targetMaterial.GetFloat(TextShaderUtilities.ID_TextureHeight));
				value.SetFloat(TextShaderUtilities.ID_WeightNormal, targetMaterial.GetFloat(TextShaderUtilities.ID_WeightNormal));
				value.SetFloat(TextShaderUtilities.ID_WeightBold, targetMaterial.GetFloat(TextShaderUtilities.ID_WeightBold));
			}
			else
			{
				value = new Material(targetMaterial);
			}
			s_FallbackMaterials.Add(key, value);
			return value;
		}

		public static Material GetFallbackMaterial(FontAsset fontAsset, Material sourceMaterial, int atlasIndex)
		{
			bool flag = !JobsUtility.IsExecutingJob;
			int hashCode = sourceMaterial.GetHashCode();
			Texture texture = fontAsset.atlasTextures[atlasIndex];
			int hashCode2 = texture.GetHashCode();
			long key = ((long)hashCode << 32) | (uint)hashCode2;
			if (s_FallbackMaterials.TryGetValue(key, out var value))
			{
				if (!flag)
				{
					return value;
				}
				int num = sourceMaterial.ComputeCRC();
				int num2 = value.ComputeCRC();
				if (num == num2)
				{
					return value;
				}
				CopyMaterialPresetProperties(sourceMaterial, value);
				return value;
			}
			value = new Material(sourceMaterial);
			value.SetTexture(TextShaderUtilities.ID_MainTex, texture);
			value.hideFlags = HideFlags.HideAndDontSave;
			s_FallbackMaterials.Add(key, value);
			return value;
		}

		private static void CopyMaterialPresetProperties(Material source, Material destination)
		{
			if (source.HasProperty(TextShaderUtilities.ID_GradientScale) && destination.HasProperty(TextShaderUtilities.ID_GradientScale))
			{
				Texture texture = destination.GetTexture(TextShaderUtilities.ID_MainTex);
				float value = destination.GetFloat(TextShaderUtilities.ID_GradientScale);
				float value2 = destination.GetFloat(TextShaderUtilities.ID_TextureWidth);
				float value3 = destination.GetFloat(TextShaderUtilities.ID_TextureHeight);
				float value4 = destination.GetFloat(TextShaderUtilities.ID_WeightNormal);
				float value5 = destination.GetFloat(TextShaderUtilities.ID_WeightBold);
				destination.shader = source.shader;
				destination.CopyPropertiesFromMaterial(source);
				destination.shaderKeywords = source.shaderKeywords;
				destination.SetTexture(TextShaderUtilities.ID_MainTex, texture);
				destination.SetFloat(TextShaderUtilities.ID_GradientScale, value);
				destination.SetFloat(TextShaderUtilities.ID_TextureWidth, value2);
				destination.SetFloat(TextShaderUtilities.ID_TextureHeight, value3);
				destination.SetFloat(TextShaderUtilities.ID_WeightNormal, value4);
				destination.SetFloat(TextShaderUtilities.ID_WeightBold, value5);
			}
		}
	}
	internal struct MaterialReference(int index, FontAsset fontAsset, SpriteAsset spriteAsset, Material material, float padding)
	{
		public int index = index;

		public FontAsset fontAsset = fontAsset;

		public SpriteAsset spriteAsset = spriteAsset;

		public Material material = material;

		public bool isFallbackMaterial = false;

		public Material fallbackMaterial = null;

		public float padding = padding;

		public int referenceCount = 0;

		public static bool Contains(MaterialReference[] materialReferences, FontAsset fontAsset)
		{
			int hashCode = fontAsset.GetHashCode();
			for (int i = 0; i < materialReferences.Length && materialReferences[i].fontAsset != null; i++)
			{
				if (materialReferences[i].fontAsset.GetHashCode() == hashCode)
				{
					return true;
				}
			}
			return false;
		}

		public static int AddMaterialReference(Material material, FontAsset fontAsset, ref MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			int hashCode = material.GetHashCode();
			if (materialReferenceIndexLookup.TryGetValue(hashCode, out var value))
			{
				return value;
			}
			value = (materialReferenceIndexLookup[hashCode] = materialReferenceIndexLookup.Count);
			if (value >= materialReferences.Length)
			{
				Array.Resize(ref materialReferences, Mathf.NextPowerOfTwo(value + 1));
			}
			materialReferences[value].index = value;
			materialReferences[value].fontAsset = fontAsset;
			materialReferences[value].spriteAsset = null;
			materialReferences[value].material = material;
			materialReferences[value].referenceCount = 0;
			return value;
		}

		public static int AddMaterialReference(Material material, SpriteAsset spriteAsset, ref MaterialReference[] materialReferences, Dictionary<int, int> materialReferenceIndexLookup)
		{
			int hashCode = material.GetHashCode();
			if (materialReferenceIndexLookup.TryGetValue(hashCode, out var value))
			{
				return value;
			}
			value = (materialReferenceIndexLookup[hashCode] = materialReferenceIndexLookup.Count);
			if (value >= materialReferences.Length)
			{
				Array.Resize(ref materialReferences, Mathf.NextPowerOfTwo(value + 1));
			}
			materialReferences[value].index = value;
			materialReferences[value].fontAsset = materialReferences[0].fontAsset;
			materialReferences[value].spriteAsset = spriteAsset;
			materialReferences[value].material = material;
			materialReferences[value].referenceCount = 0;
			return value;
		}
	}
	internal class MaterialReferenceManager
	{
		private static MaterialReferenceManager s_Instance;

		private Dictionary<int, Material> m_FontMaterialReferenceLookup = new Dictionary<int, Material>();

		private Dictionary<int, FontAsset> m_FontAssetReferenceLookup = new Dictionary<int, FontAsset>();

		private Dictionary<int, SpriteAsset> m_SpriteAssetReferenceLookup = new Dictionary<int, SpriteAsset>();

		private Dictionary<int, TextColorGradient> m_ColorGradientReferenceLookup = new Dictionary<int, TextColorGradient>();

		public static MaterialReferenceManager instance
		{
			get
			{
				if (s_Instance == null)
				{
					s_Instance = new MaterialReferenceManager();
				}
				return s_Instance;
			}
		}

		public static void AddFontAsset(FontAsset fontAsset)
		{
			instance.AddFontAssetInternal(fontAsset);
		}

		private void AddFontAssetInternal(FontAsset fontAsset)
		{
			if (!m_FontAssetReferenceLookup.ContainsKey(fontAsset.hashCode))
			{
				m_FontAssetReferenceLookup.Add(fontAsset.hashCode, fontAsset);
				m_FontMaterialReferenceLookup.Add(fontAsset.materialHashCode, fontAsset.material);
			}
		}

		public static void AddSpriteAsset(SpriteAsset spriteAsset)
		{
			instance.AddSpriteAssetInternal(spriteAsset);
		}

		private void AddSpriteAssetInternal(SpriteAsset spriteAsset)
		{
			if (!m_SpriteAssetReferenceLookup.ContainsKey(spriteAsset.hashCode))
			{
				m_SpriteAssetReferenceLookup.Add(spriteAsset.hashCode, spriteAsset);
				m_FontMaterialReferenceLookup.Add(spriteAsset.hashCode, spriteAsset.material);
			}
		}

		public static void AddSpriteAsset(int hashCode, SpriteAsset spriteAsset)
		{
			instance.AddSpriteAssetInternal(hashCode, spriteAsset);
		}

		private void AddSpriteAssetInternal(int hashCode, SpriteAsset spriteAsset)
		{
			if (!m_SpriteAssetReferenceLookup.ContainsKey(hashCode))
			{
				m_SpriteAssetReferenceLookup.Add(hashCode, spriteAsset);
				m_FontMaterialReferenceLookup.Add(hashCode, spriteAsset.material);
				if (spriteAsset.hashCode == 0)
				{
					spriteAsset.hashCode = hashCode;
				}
			}
		}

		public static void AddFontMaterial(int hashCode, Material material)
		{
			instance.AddFontMaterialInternal(hashCode, material);
		}

		private void AddFontMaterialInternal(int hashCode, Material material)
		{
			m_FontMaterialReferenceLookup.Add(hashCode, material);
		}

		public static void AddColorGradientPreset(int hashCode, TextColorGradient spriteAsset)
		{
			instance.AddColorGradientPreset_Internal(hashCode, spriteAsset);
		}

		private void AddColorGradientPreset_Internal(int hashCode, TextColorGradient spriteAsset)
		{
			if (!m_ColorGradientReferenceLookup.ContainsKey(hashCode))
			{
				m_ColorGradientReferenceLookup.Add(hashCode, spriteAsset);
			}
		}

		public bool Contains(FontAsset font)
		{
			return m_FontAssetReferenceLookup.ContainsKey(font.hashCode);
		}

		public bool Contains(SpriteAsset sprite)
		{
			return m_FontAssetReferenceLookup.ContainsKey(sprite.hashCode);
		}

		public static bool TryGetFontAsset(int hashCode, out FontAsset fontAsset)
		{
			return instance.TryGetFontAssetInternal(hashCode, out fontAsset);
		}

		private bool TryGetFontAssetInternal(int hashCode, out FontAsset fontAsset)
		{
			fontAsset = null;
			return m_FontAssetReferenceLookup.TryGetValue(hashCode, out fontAsset);
		}

		public static bool TryGetSpriteAsset(int hashCode, out SpriteAsset spriteAsset)
		{
			return instance.TryGetSpriteAssetInternal(hashCode, out spriteAsset);
		}

		private bool TryGetSpriteAssetInternal(int hashCode, out SpriteAsset spriteAsset)
		{
			spriteAsset = null;
			return m_SpriteAssetReferenceLookup.TryGetValue(hashCode, out spriteAsset);
		}

		public static bool TryGetColorGradientPreset(int hashCode, out TextColorGradient gradientPreset)
		{
			return instance.TryGetColorGradientPresetInternal(hashCode, out gradientPreset);
		}

		private bool TryGetColorGradientPresetInternal(int hashCode, out TextColorGradient gradientPreset)
		{
			gradientPreset = null;
			return m_ColorGradientReferenceLookup.TryGetValue(hashCode, out gradientPreset);
		}

		public static bool TryGetMaterial(int hashCode, out Material material)
		{
			return instance.TryGetMaterialInternal(hashCode, out material);
		}

		private bool TryGetMaterialInternal(int hashCode, out Material material)
		{
			material = null;
			return m_FontMaterialReferenceLookup.TryGetValue(hashCode, out material);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule" })]
	[UsedByNativeCode("MeshInfo")]
	[NativeHeader("Modules/TextCoreTextEngine/Native/IMGUI/MeshInfo.h")]
	internal struct MeshInfoBindings
	{
		public TextCoreVertex[] vertexData;

		public Material material;

		public int vertexCount;
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct MeshInfo
	{
		public int vertexCount;

		public TextCoreVertex[] vertexData;

		public Material material;

		[Ignore]
		public int vertexBufferSize;

		[Ignore]
		public bool applySDF;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal GlyphRenderMode glyphRenderMode;

		public MeshInfo(int size, bool isIMGUI)
		{
			this = default(MeshInfo);
			applySDF = true;
			material = null;
			if (isIMGUI)
			{
				size = Mathf.Min(size, 16383);
			}
			int num = size * 4;
			int num2 = size * 6;
			vertexCount = 0;
			vertexBufferSize = num;
			vertexData = new TextCoreVertex[num];
			material = null;
			glyphRenderMode = GlyphRenderMode.DEFAULT;
		}

		internal void ResizeMeshInfo(int size, bool isIMGUI)
		{
			if (isIMGUI)
			{
				size = Mathf.Min(size, 16383);
			}
			int newSize = size * 4;
			int num = size * 6;
			vertexBufferSize = newSize;
			Array.Resize(ref vertexData, newSize);
		}

		internal void Clear(bool uploadChanges)
		{
			if (vertexData != null)
			{
				Array.Clear(vertexData, 0, vertexData.Length);
				vertexBufferSize = vertexData.Length;
				vertexCount = 0;
			}
		}

		internal void ClearUnusedVertices()
		{
			int num = vertexData.Length - vertexCount;
			if (num > 0)
			{
				Array.Clear(vertexData, vertexCount, num);
			}
			vertexBufferSize = vertexData.Length;
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextElementInfo.h")]
	internal struct NativeTextElementInfo
	{
		public int glyphID;

		public TextCoreVertex bottomLeft;

		public TextCoreVertex topLeft;

		public TextCoreVertex topRight;

		public TextCoreVertex bottomRight;
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextInfo.h")]
	internal struct NativeTextInfo
	{
		public ATGMeshInfo[] meshInfos;

		public int totalWidth;

		public int totalHeight;

		public bool isElided;
	}
	public enum TextFontWeight
	{
		Thin = 100,
		ExtraLight = 200,
		Light = 300,
		Regular = 400,
		Medium = 500,
		SemiBold = 600,
		Bold = 700,
		Heavy = 800,
		Black = 900
	}
	[Serializable]
	public struct FontWeightPair
	{
		public FontAsset regularTypeface;

		public FontAsset italicTypeface;
	}
	[Serializable]
	[ExcludeFromDocs]
	public struct FontAssetCreationEditorSettings
	{
		public string sourceFontFileGUID;

		public int faceIndex;

		public int pointSizeSamplingMode;

		public float pointSize;

		public int padding;

		public int paddingMode;

		public int packingMode;

		public int atlasWidth;

		public int atlasHeight;

		public int characterSetSelectionMode;

		public string characterSequence;

		public string referencedFontAssetGUID;

		public string referencedTextAssetGUID;

		public int fontStyle;

		public float fontStyleModifier;

		public int renderMode;

		public bool includeFontFeatures;

		internal FontAssetCreationEditorSettings(string sourceFontFileGUID, float pointSize, int pointSizeSamplingMode, int padding, int packingMode, int atlasWidth, int atlasHeight, int characterSelectionMode, string characterSet, int renderMode)
		{
			this.sourceFontFileGUID = sourceFontFileGUID;
			faceIndex = 0;
			this.pointSize = pointSize;
			this.pointSizeSamplingMode = pointSizeSamplingMode;
			this.padding = padding;
			paddingMode = 2;
			this.packingMode = packingMode;
			this.atlasWidth = atlasWidth;
			this.atlasHeight = atlasHeight;
			characterSequence = characterSet;
			characterSetSelectionMode = characterSelectionMode;
			this.renderMode = renderMode;
			referencedFontAssetGUID = string.Empty;
			referencedTextAssetGUID = string.Empty;
			fontStyle = 0;
			fontStyleModifier = 0f;
			includeFontFeatures = false;
		}
	}
	public enum AtlasPopulationMode
	{
		Static,
		Dynamic,
		DynamicOS
	}
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	[NativeHeader("Modules/TextCoreTextEngine/Native/FontAsset.h")]
	[ExcludeFromPreset]
	public class FontAsset : TextAsset
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(FontAsset fontAsset)
			{
				return fontAsset.m_NativeFontAsset;
			}
		}

		private static Dictionary<int, FontAsset> kFontAssetByInstanceId = new Dictionary<int, FontAsset>();

		[SerializeField]
		internal string m_SourceFontFileGUID;

		[SerializeField]
		internal FontAssetCreationEditorSettings m_fontAssetCreationEditorSettings;

		[SerializeField]
		private Font m_SourceFontFile;

		[SerializeField]
		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal string m_SourceFontFilePath;

		[SerializeField]
		private AtlasPopulationMode m_AtlasPopulationMode;

		[SerializeField]
		internal bool InternalDynamicOS;

		[SerializeField]
		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool IsEditorFont = false;

		[SerializeField]
		internal FaceInfo m_FaceInfo;

		private int m_FamilyNameHashCode;

		private int m_StyleNameHashCode;

		[SerializeField]
		internal List<Glyph> m_GlyphTable = new List<Glyph>();

		internal Dictionary<uint, Glyph> m_GlyphLookupDictionary;

		[SerializeField]
		internal List<Character> m_CharacterTable = new List<Character>();

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal Dictionary<uint, Character> m_CharacterLookupDictionary;

		internal Texture2D m_AtlasTexture;

		[SerializeField]
		internal Texture2D[] m_AtlasTextures;

		[SerializeField]
		internal int m_AtlasTextureIndex;

		[SerializeField]
		private bool m_IsMultiAtlasTexturesEnabled = true;

		[SerializeField]
		private bool m_GetFontFeatures = true;

		[SerializeField]
		private bool m_ClearDynamicDataOnBuild = true;

		[SerializeField]
		internal int m_AtlasWidth;

		[SerializeField]
		internal int m_AtlasHeight;

		[SerializeField]
		internal int m_AtlasPadding;

		[SerializeField]
		internal GlyphRenderMode m_AtlasRenderMode;

		[SerializeField]
		private List<GlyphRect> m_UsedGlyphRects;

		[SerializeField]
		private List<GlyphRect> m_FreeGlyphRects;

		[SerializeField]
		internal FontFeatureTable m_FontFeatureTable = new FontFeatureTable();

		[SerializeField]
		internal bool m_ShouldReimportFontFeatures;

		[SerializeField]
		internal List<FontAsset> m_FallbackFontAssetTable;

		[SerializeField]
		private FontWeightPair[] m_FontWeightTable = new FontWeightPair[10];

		[SerializeField]
		[FormerlySerializedAs("normalStyle")]
		internal float m_RegularStyleWeight = 0f;

		[FormerlySerializedAs("normalSpacingOffset")]
		[SerializeField]
		internal float m_RegularStyleSpacing = 0f;

		[FormerlySerializedAs("boldStyle")]
		[SerializeField]
		internal float m_BoldStyleWeight = 0.75f;

		[SerializeField]
		[FormerlySerializedAs("boldSpacing")]
		internal float m_BoldStyleSpacing = 7f;

		[SerializeField]
		[FormerlySerializedAs("italicStyle")]
		internal byte m_ItalicStyleSlant = 35;

		[SerializeField]
		[FormerlySerializedAs("tabSize")]
		internal byte m_TabMultiple = 10;

		internal bool IsFontAssetLookupTablesDirty;

		private IntPtr m_NativeFontAsset = IntPtr.Zero;

		private List<Glyph> m_GlyphsToRender = new List<Glyph>();

		private List<Glyph> m_GlyphsRendered = new List<Glyph>();

		private List<uint> m_GlyphIndexList = new List<uint>();

		private List<uint> m_GlyphIndexListNewlyAdded = new List<uint>();

		internal List<uint> m_GlyphsToAdd = new List<uint>();

		internal HashSet<uint> m_GlyphsToAddLookup = new HashSet<uint>();

		internal List<Character> m_CharactersToAdd = new List<Character>();

		internal HashSet<uint> m_CharactersToAddLookup = new HashSet<uint>();

		internal List<uint> s_MissingCharacterList = new List<uint>();

		internal HashSet<uint> m_MissingUnicodesFromFontFile = new HashSet<uint>();

		internal Dictionary<(uint, uint), uint> m_VariantGlyphIndexes = new Dictionary<(uint, uint), uint>();

		internal bool m_IsClone;

		private static readonly List<WeakReference<FontAsset>> s_CallbackInstances = new List<WeakReference<FontAsset>>();

		private static ProfilerMarker k_ReadFontAssetDefinitionMarker = new ProfilerMarker("FontAsset.ReadFontAssetDefinition");

		private static ProfilerMarker k_AddSynthesizedCharactersMarker = new ProfilerMarker("FontAsset.AddSynthesizedCharacters");

		private static ProfilerMarker k_TryAddGlyphMarker = new ProfilerMarker("FontAsset.TryAddGlyph");

		private static ProfilerMarker k_TryAddCharacterMarker = new ProfilerMarker("FontAsset.TryAddCharacter");

		private static ProfilerMarker k_TryAddCharactersMarker = new ProfilerMarker("FontAsset.TryAddCharacters");

		private static ProfilerMarker k_UpdateLigatureSubstitutionRecordsMarker = new ProfilerMarker("FontAsset.UpdateLigatureSubstitutionRecords");

		private static ProfilerMarker k_UpdateGlyphAdjustmentRecordsMarker = new ProfilerMarker("FontAsset.UpdateGlyphAdjustmentRecords");

		private static ProfilerMarker k_UpdateDiacriticalMarkAdjustmentRecordsMarker = new ProfilerMarker("FontAsset.UpdateDiacriticalAdjustmentRecords");

		private static ProfilerMarker k_ClearFontAssetDataMarker = new ProfilerMarker("FontAsset.ClearFontAssetData");

		private static ProfilerMarker k_UpdateFontAssetDataMarker = new ProfilerMarker("FontAsset.UpdateFontAssetData");

		private static string s_DefaultMaterialSuffix = " Atlas Material";

		private static HashSet<int> k_SearchedFontAssetLookup;

		private static List<FontAsset> k_FontAssets_FontFeaturesUpdateQueue = new List<FontAsset>();

		private static HashSet<int> k_FontAssets_FontFeaturesUpdateQueueLookup = new HashSet<int>();

		private static List<FontAsset> k_FontAssets_KerningUpdateQueue = new List<FontAsset>();

		private static HashSet<int> k_FontAssets_KerningUpdateQueueLookup = new HashSet<int>();

		private static List<Texture2D> k_FontAssets_AtlasTexturesUpdateQueue = new List<Texture2D>();

		private static HashSet<int> k_FontAssets_AtlasTexturesUpdateQueueLookup = new HashSet<int>();

		internal static uint[] k_GlyphIndexArray;

		private static HashSet<int> visitedFontAssets = new HashSet<int>();

		public FontAssetCreationEditorSettings fontAssetCreationEditorSettings
		{
			get
			{
				return m_fontAssetCreationEditorSettings;
			}
			set
			{
				m_fontAssetCreationEditorSettings = value;
			}
		}

		public Font sourceFontFile
		{
			get
			{
				return m_SourceFontFile;
			}
			internal set
			{
				m_SourceFontFile = value;
			}
		}

		public AtlasPopulationMode atlasPopulationMode
		{
			get
			{
				return m_AtlasPopulationMode;
			}
			set
			{
				m_AtlasPopulationMode = value;
			}
		}

		public FaceInfo faceInfo
		{
			get
			{
				return m_FaceInfo;
			}
			set
			{
				m_FaceInfo = value;
				if (m_NativeFontAsset != IntPtr.Zero)
				{
					UpdateFaceInfo();
				}
			}
		}

		internal int familyNameHashCode
		{
			get
			{
				if (m_FamilyNameHashCode == 0)
				{
					m_FamilyNameHashCode = TextUtilities.GetHashCodeCaseInSensitive(m_FaceInfo.familyName);
				}
				return m_FamilyNameHashCode;
			}
			set
			{
				m_FamilyNameHashCode = value;
			}
		}

		internal int styleNameHashCode
		{
			get
			{
				if (m_StyleNameHashCode == 0)
				{
					m_StyleNameHashCode = TextUtilities.GetHashCodeCaseInSensitive(m_FaceInfo.styleName);
				}
				return m_StyleNameHashCode;
			}
			set
			{
				m_StyleNameHashCode = value;
			}
		}

		public List<Glyph> glyphTable
		{
			get
			{
				return m_GlyphTable;
			}
			internal set
			{
				m_GlyphTable = value;
			}
		}

		public Dictionary<uint, Glyph> glyphLookupTable
		{
			get
			{
				if (m_GlyphLookupDictionary == null)
				{
					ReadFontAssetDefinition();
				}
				return m_GlyphLookupDictionary;
			}
		}

		public List<Character> characterTable
		{
			get
			{
				return m_CharacterTable;
			}
			internal set
			{
				m_CharacterTable = value;
			}
		}

		public Dictionary<uint, Character> characterLookupTable
		{
			get
			{
				if (m_CharacterLookupDictionary == null)
				{
					ReadFontAssetDefinition();
				}
				return m_CharacterLookupDictionary;
			}
		}

		public Texture2D atlasTexture
		{
			get
			{
				if (m_AtlasTexture == null)
				{
					m_AtlasTexture = atlasTextures[0];
				}
				return m_AtlasTexture;
			}
		}

		public Texture2D[] atlasTextures
		{
			get
			{
				return m_AtlasTextures;
			}
			set
			{
				m_AtlasTextures = value;
			}
		}

		public int atlasTextureCount => m_AtlasTextureIndex + 1;

		public bool isMultiAtlasTexturesEnabled
		{
			get
			{
				return m_IsMultiAtlasTexturesEnabled;
			}
			set
			{
				m_IsMultiAtlasTexturesEnabled = value;
			}
		}

		public bool getFontFeatures
		{
			get
			{
				return m_GetFontFeatures;
			}
			set
			{
				m_GetFontFeatures = value;
			}
		}

		internal bool clearDynamicDataOnBuild
		{
			get
			{
				return m_ClearDynamicDataOnBuild;
			}
			set
			{
				m_ClearDynamicDataOnBuild = value;
			}
		}

		public int atlasWidth
		{
			get
			{
				return m_AtlasWidth;
			}
			internal set
			{
				m_AtlasWidth = value;
			}
		}

		public int atlasHeight
		{
			get
			{
				return m_AtlasHeight;
			}
			internal set
			{
				m_AtlasHeight = value;
			}
		}

		public int atlasPadding
		{
			get
			{
				return m_AtlasPadding;
			}
			internal set
			{
				m_AtlasPadding = value;
			}
		}

		public GlyphRenderMode atlasRenderMode
		{
			get
			{
				return m_AtlasRenderMode;
			}
			internal set
			{
				m_AtlasRenderMode = value;
			}
		}

		internal List<GlyphRect> usedGlyphRects
		{
			get
			{
				return m_UsedGlyphRects;
			}
			set
			{
				m_UsedGlyphRects = value;
			}
		}

		internal List<GlyphRect> freeGlyphRects
		{
			get
			{
				return m_FreeGlyphRects;
			}
			set
			{
				m_FreeGlyphRects = value;
			}
		}

		public FontFeatureTable fontFeatureTable
		{
			get
			{
				return m_FontFeatureTable;
			}
			internal set
			{
				m_FontFeatureTable = value;
			}
		}

		public List<FontAsset> fallbackFontAssetTable
		{
			get
			{
				return m_FallbackFontAssetTable;
			}
			set
			{
				m_FallbackFontAssetTable = value;
			}
		}

		public FontWeightPair[] fontWeightTable
		{
			get
			{
				return m_FontWeightTable;
			}
			internal set
			{
				m_FontWeightTable = value;
			}
		}

		public float regularStyleWeight
		{
			get
			{
				return m_RegularStyleWeight;
			}
			set
			{
				m_RegularStyleWeight = value;
			}
		}

		public float regularStyleSpacing
		{
			get
			{
				return m_RegularStyleSpacing;
			}
			set
			{
				m_RegularStyleSpacing = value;
			}
		}

		public float boldStyleWeight
		{
			get
			{
				return m_BoldStyleWeight;
			}
			set
			{
				m_BoldStyleWeight = value;
			}
		}

		public float boldStyleSpacing
		{
			get
			{
				return m_BoldStyleSpacing;
			}
			set
			{
				m_BoldStyleSpacing = value;
			}
		}

		public byte italicStyleSlant
		{
			get
			{
				return m_ItalicStyleSlant;
			}
			set
			{
				m_ItalicStyleSlant = value;
			}
		}

		public byte tabMultiple
		{
			get
			{
				return m_TabMultiple;
			}
			set
			{
				m_TabMultiple = value;
			}
		}

		internal IntPtr nativeFontAsset
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
			get
			{
				EnsureNativeFontAssetIsCreated();
				return m_NativeFontAsset;
			}
		}

		private static void EnsureAdditionalCapacity<T>(List<T> container, int additionalCapacity)
		{
			int num = container.Count + additionalCapacity;
			if (container.Capacity < num)
			{
				container.Capacity = num;
			}
		}

		private static void EnsureAdditionalCapacity<TKey, TValue>(Dictionary<TKey, TValue> container, int additionalCapacity)
		{
			int capacity = container.Count + additionalCapacity;
			container.EnsureCapacity(capacity);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool IsBitmap()
		{
			return ((GlyphRasterModes)m_AtlasRenderMode).HasFlag(GlyphRasterModes.RASTER_MODE_BITMAP) && !((GlyphRasterModes)m_AtlasRenderMode).HasFlag(GlyphRasterModes.RASTER_MODE_COLOR);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool IsRaster()
		{
			return m_AtlasRenderMode == GlyphRenderMode.RASTER_HINTED;
		}

		public static FontAsset CreateFontAsset(string familyName, string styleName, int pointSize = 90)
		{
			FontAsset fontAsset = CreateFontAssetInternal(familyName, styleName, pointSize);
			if (fontAsset == null)
			{
				Debug.Log("Unable to find a font file with the specified Family Name [" + familyName + "] and Style [" + styleName + "].");
				return null;
			}
			return fontAsset;
		}

		internal static FontAsset? CreateFontAssetInternal(string familyName, string styleName, int pointSize = 90)
		{
			if (FontEngine.TryGetSystemFontReference(familyName, styleName, out var fontRef))
			{
				return CreateFontAsset(fontRef.filePath, fontRef.faceIndex, pointSize, 9, GlyphRenderMode.DEFAULT, 1024, 1024, AtlasPopulationMode.DynamicOS);
			}
			return null;
		}

		internal static FontAsset? CreateFontAsset(string familyName, string styleName, int pointSize, int padding, GlyphRenderMode renderMode)
		{
			if (FontEngine.TryGetSystemFontReference(familyName, styleName, out var fontRef))
			{
				return CreateFontAsset(fontRef.filePath, fontRef.faceIndex, pointSize, padding, renderMode, 1024, 1024, AtlasPopulationMode.DynamicOS);
			}
			return null;
		}

		internal static List<FontAsset> CreateFontAssetOSFallbackList(string[] fallbacksFamilyNames, int pointSize = 90)
		{
			List<FontAsset> list = new List<FontAsset>();
			foreach (string familyName in fallbacksFamilyNames)
			{
				FontAsset fontAsset = CreateFontAssetFromFamilyName(familyName, pointSize);
				if (!(fontAsset == null))
				{
					list.Add(fontAsset);
				}
			}
			return list;
		}

		internal static FontAsset CreateFontAssetWithOSFallbackList(string[] fallbacksFamilyNames, int pointSize = 90)
		{
			FontAsset fontAsset = null;
			foreach (string familyName in fallbacksFamilyNames)
			{
				FontAsset fontAsset2 = CreateFontAssetFromFamilyName(familyName, pointSize);
				if (!(fontAsset2 == null))
				{
					if (fontAsset == null)
					{
						fontAsset = fontAsset2;
					}
					if (fontAsset.fallbackFontAssetTable == null)
					{
						fontAsset.fallbackFontAssetTable = new List<FontAsset>();
					}
					fontAsset.fallbackFontAssetTable.Add(fontAsset2);
				}
			}
			return fontAsset;
		}

		private static FontAsset CreateFontAssetFromFamilyName(string familyName, int pointSize = 90)
		{
			FontAsset fontAsset = null;
			if (FontEngine.TryGetSystemFontReference(familyName, null, out var fontRef))
			{
				fontAsset = CreateFontAsset(fontRef.filePath, fontRef.faceIndex, pointSize, 9, GlyphRenderMode.DEFAULT, 1024, 1024, AtlasPopulationMode.DynamicOS);
			}
			if (fontAsset == null)
			{
				return null;
			}
			FontAssetFactory.SetHideFlags(fontAsset);
			fontAsset.isMultiAtlasTexturesEnabled = true;
			fontAsset.InternalDynamicOS = true;
			return fontAsset;
		}

		public static FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight)
		{
			return CreateFontAsset(fontFilePath, faceIndex, samplingPointSize, atlasPadding, renderMode, atlasWidth, atlasHeight, AtlasPopulationMode.Dynamic);
		}

		private static FontAsset CreateFontAsset(string fontFilePath, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport = true)
		{
			if (FontEngine.LoadFontFace(fontFilePath, samplingPointSize, faceIndex) != FontEngineError.Success)
			{
				Debug.Log("Unable to load font face from [" + fontFilePath + "].");
				return null;
			}
			FontAsset fontAsset = CreateFontAssetInstance(null, atlasPadding, renderMode, atlasWidth, atlasHeight, atlasPopulationMode, enableMultiAtlasSupport);
			if ((bool)fontAsset)
			{
				fontAsset.m_SourceFontFilePath = fontFilePath;
			}
			return fontAsset;
		}

		public static FontAsset CreateFontAsset(Font font)
		{
			return CreateFontAsset(font, 90, 9, GlyphRenderMode.SDFAA, 1024, 1024);
		}

		public static FontAsset CreateFontAsset(Font font, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic, bool enableMultiAtlasSupport = true)
		{
			return CreateFontAsset(font, 0, samplingPointSize, atlasPadding, renderMode, atlasWidth, atlasHeight, atlasPopulationMode, enableMultiAtlasSupport);
		}

		private static FontAsset CreateFontAsset(Font font, int faceIndex, int samplingPointSize, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic, bool enableMultiAtlasSupport = true)
		{
			if (font.name == "LegacyRuntime")
			{
				string[] oSFallbacks = Font.GetOSFallbacks();
				if (FontEngine.LoadFontFace(font, samplingPointSize, faceIndex) == FontEngineError.Success)
				{
					FontAsset fontAsset = CreateFontAssetInstance(font, atlasPadding, renderMode, atlasWidth, atlasHeight, atlasPopulationMode, enableMultiAtlasSupport);
					List<FontAsset> list = CreateFontAssetOSFallbackList(oSFallbacks, samplingPointSize);
					fontAsset.fallbackFontAssetTable = list;
					return fontAsset;
				}
				FontAsset fontAsset2 = CreateFontAssetWithOSFallbackList(oSFallbacks, samplingPointSize);
				if (fontAsset2 != null)
				{
					return fontAsset2;
				}
			}
			if (FontEngine.LoadFontFace(font, samplingPointSize, faceIndex) != FontEngineError.Success)
			{
				FontAsset fontAsset3 = CreateFontAsset(font.name, "Regular");
				if (fontAsset3 != null)
				{
					return fontAsset3;
				}
				Debug.LogWarning("Unable to load font face for [" + font.name + "]. Make sure \"Include Font Data\" is enabled in the Font Import Settings.", font);
				return null;
			}
			return CreateFontAssetInstance(font, atlasPadding, renderMode, atlasWidth, atlasHeight, atlasPopulationMode, enableMultiAtlasSupport);
		}

		private static FontAsset CreateFontAssetInstance(Font font, int atlasPadding, GlyphRenderMode renderMode, int atlasWidth, int atlasHeight, AtlasPopulationMode atlasPopulationMode, bool enableMultiAtlasSupport)
		{
			FontAsset fontAsset = ScriptableObject.CreateInstance<FontAsset>();
			fontAsset.m_Version = "1.1.0";
			fontAsset.faceInfo = FontEngine.GetFaceInfo();
			if (renderMode == GlyphRenderMode.DEFAULT)
			{
				renderMode = (FontEngine.IsColorFontFace() ? GlyphRenderMode.COLOR : GlyphRenderMode.SDFAA);
			}
			if (atlasPopulationMode == AtlasPopulationMode.Dynamic && font != null)
			{
				fontAsset.sourceFontFile = font;
			}
			fontAsset.atlasPopulationMode = atlasPopulationMode;
			fontAsset.atlasWidth = atlasWidth;
			fontAsset.atlasHeight = atlasHeight;
			fontAsset.atlasPadding = atlasPadding;
			fontAsset.atlasRenderMode = renderMode;
			fontAsset.atlasTextures = new Texture2D[1];
			TextureFormat textureFormat = (((renderMode & (GlyphRenderMode)65536) != (GlyphRenderMode)65536) ? TextureFormat.Alpha8 : TextureFormat.RGBA32);
			Texture2D texture2D = new Texture2D(1, 1, textureFormat, mipChain: false);
			fontAsset.atlasTextures[0] = texture2D;
			fontAsset.isMultiAtlasTexturesEnabled = enableMultiAtlasSupport;
			int num;
			if ((renderMode & (GlyphRenderMode)16) == (GlyphRenderMode)16)
			{
				num = 0;
				Material material;
				if (textureFormat == TextureFormat.Alpha8)
				{
					if (!TextShaderUtilities.ShaderRef_MobileBitmap)
					{
						return null;
					}
					material = new Material(TextShaderUtilities.ShaderRef_MobileBitmap);
				}
				else
				{
					if (!TextShaderUtilities.ShaderRef_Sprite)
					{
						return null;
					}
					material = new Material(TextShaderUtilities.ShaderRef_Sprite);
				}
				material.SetTexture(TextShaderUtilities.ID_MainTex, texture2D);
				material.SetFloat(TextShaderUtilities.ID_TextureWidth, atlasWidth);
				material.SetFloat(TextShaderUtilities.ID_TextureHeight, atlasHeight);
				fontAsset.material = material;
			}
			else
			{
				num = 1;
				Material material2 = new Material(TextShaderUtilities.ShaderRef_MobileSDF);
				material2.SetTexture(TextShaderUtilities.ID_MainTex, texture2D);
				material2.SetFloat(TextShaderUtilities.ID_TextureWidth, atlasWidth);
				material2.SetFloat(TextShaderUtilities.ID_TextureHeight, atlasHeight);
				material2.SetFloat(TextShaderUtilities.ID_GradientScale, atlasPadding + num);
				material2.SetFloat(TextShaderUtilities.ID_WeightNormal, fontAsset.regularStyleWeight);
				material2.SetFloat(TextShaderUtilities.ID_WeightBold, fontAsset.boldStyleWeight);
				fontAsset.material = material2;
			}
			fontAsset.freeGlyphRects = new List<GlyphRect>(8)
			{
				new GlyphRect(0, 0, atlasWidth - num, atlasHeight - num)
			};
			fontAsset.usedGlyphRects = new List<GlyphRect>(8);
			fontAsset.ReadFontAssetDefinition();
			return fontAsset;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static FontAsset GetFontAssetByID(int id)
		{
			return kFontAssetByInstanceId[id];
		}

		private void RegisterCallbackInstance(FontAsset instance)
		{
			for (int i = 0; i < s_CallbackInstances.Count; i++)
			{
				if (s_CallbackInstances[i].TryGetTarget(out var target) && target == instance)
				{
					return;
				}
			}
			for (int j = 0; j < s_CallbackInstances.Count; j++)
			{
				if (!s_CallbackInstances[j].TryGetTarget(out var _))
				{
					s_CallbackInstances[j] = new WeakReference<FontAsset>(instance);
					return;
				}
			}
			s_CallbackInstances.Add(new WeakReference<FontAsset>(this));
		}

		private void OnDestroy()
		{
			kFontAssetByInstanceId.Remove(base.instanceID);
			if (!m_IsClone)
			{
				DestroyAtlasTextures();
				if ((bool)m_Material)
				{
					Object.Destroy(m_Material);
				}
				m_Material = null;
			}
			if (m_NativeFontAsset != IntPtr.Zero)
			{
				Destroy(m_NativeFontAsset);
				m_NativeFontAsset = IntPtr.Zero;
			}
		}

		public void ReadFontAssetDefinition()
		{
			InitializeDictionaryLookupTables();
			AddSynthesizedCharactersAndFaceMetrics();
			if (m_FaceInfo.capLine == 0f && m_CharacterLookupDictionary.TryGetValue(88u, out var value))
			{
				uint glyphIndex = value.glyphIndex;
				m_FaceInfo.capLine = m_GlyphLookupDictionary[glyphIndex].metrics.horizontalBearingY;
			}
			if (m_FaceInfo.meanLine == 0f && m_CharacterLookupDictionary.TryGetValue(88u, out value))
			{
				uint glyphIndex2 = value.glyphIndex;
				m_FaceInfo.meanLine = m_GlyphLookupDictionary[glyphIndex2].metrics.horizontalBearingY;
			}
			if (m_FaceInfo.scale == 0f)
			{
				m_FaceInfo.scale = 1f;
			}
			if (m_FaceInfo.strikethroughOffset == 0f)
			{
				m_FaceInfo.strikethroughOffset = m_FaceInfo.capLine / 2.5f;
			}
			if (m_AtlasPadding == 0 && base.material.HasProperty(TextShaderUtilities.ID_GradientScale))
			{
				m_AtlasPadding = (int)base.material.GetFloat(TextShaderUtilities.ID_GradientScale) - 1;
			}
			if (m_FaceInfo.unitsPerEM == 0 && atlasPopulationMode != AtlasPopulationMode.Static)
			{
				if (!JobsUtility.IsExecutingJob)
				{
					m_FaceInfo.unitsPerEM = FontEngine.GetFaceInfo().unitsPerEM;
					Debug.Log("Font Asset [" + base.name + "] Units Per EM set to " + m_FaceInfo.unitsPerEM + ". Please commit the newly serialized value.", this);
				}
				else
				{
					Debug.LogError("Font Asset [" + base.name + "] is missing Units Per EM. Please select the 'Reset FaceInfo' menu item on Font Asset [" + base.name + "] to ensure proper serialization.", this);
				}
			}
			base.hashCode = TextUtilities.GetHashCodeCaseInSensitive(base.name);
			familyNameHashCode = TextUtilities.GetHashCodeCaseInSensitive(m_FaceInfo.familyName);
			styleNameHashCode = TextUtilities.GetHashCodeCaseInSensitive(m_FaceInfo.styleName);
			base.materialHashCode = TextUtilities.GetHashCodeCaseInSensitive(base.name + s_DefaultMaterialSuffix);
			TextResourceManager.AddFontAsset(this);
			IsFontAssetLookupTablesDirty = false;
			RegisterCallbackInstance(this);
		}

		internal void InitializeDictionaryLookupTables()
		{
			InitializeGlyphLookupDictionary();
			InitializeCharacterLookupDictionary();
			if ((m_AtlasPopulationMode == AtlasPopulationMode.Dynamic || m_AtlasPopulationMode == AtlasPopulationMode.DynamicOS) && m_ShouldReimportFontFeatures)
			{
				ImportFontFeatures();
			}
			InitializeLigatureSubstitutionLookupDictionary();
			InitializeGlyphPairAdjustmentRecordsLookupDictionary();
			InitializeMarkToBaseAdjustmentRecordsLookupDictionary();
			InitializeMarkToMarkAdjustmentRecordsLookupDictionary();
		}

		private static void InitializeLookup<T>(ICollection source, ref Dictionary<uint, T> lookup, int defaultCapacity = 16)
		{
			int capacity = source?.Count ?? defaultCapacity;
			if (lookup == null)
			{
				lookup = new Dictionary<uint, T>(capacity);
				return;
			}
			lookup.Clear();
			lookup.EnsureCapacity(capacity);
		}

		private static void InitializeList<T>(ICollection source, ref List<T> list, int defaultCapacity = 16)
		{
			int capacity = source?.Count ?? defaultCapacity;
			if (list == null)
			{
				list = new List<T>(capacity);
				return;
			}
			list.Clear();
			list.Capacity = capacity;
		}

		internal void InitializeGlyphLookupDictionary()
		{
			InitializeLookup(m_GlyphTable, ref m_GlyphLookupDictionary);
			InitializeList(m_GlyphTable, ref m_GlyphIndexList);
			InitializeList(null, ref m_GlyphIndexListNewlyAdded);
			foreach (Glyph item in m_GlyphTable)
			{
				uint index = item.index;
				if (m_GlyphLookupDictionary.TryAdd(index, item))
				{
					m_GlyphIndexList.Add(index);
				}
			}
		}

		internal void InitializeCharacterLookupDictionary()
		{
			InitializeLookup(m_CharacterTable, ref m_CharacterLookupDictionary);
			foreach (Character item in m_CharacterTable)
			{
				uint unicode = item.unicode;
				uint glyphIndex = item.glyphIndex;
				if (m_CharacterLookupDictionary.TryAdd(unicode, item))
				{
					item.textAsset = this;
					item.glyph = m_GlyphLookupDictionary[glyphIndex];
				}
			}
			m_MissingUnicodesFromFontFile?.Clear();
		}

		internal void ClearFallbackCharacterTable()
		{
			List<uint> list = new List<uint>();
			foreach (KeyValuePair<uint, Character> item in m_CharacterLookupDictionary)
			{
				Character value = item.Value;
				if (value.textAsset != this)
				{
					list.Add(item.Key);
				}
			}
			foreach (uint item2 in list)
			{
				m_CharacterLookupDictionary.Remove(item2);
			}
		}

		internal void InitializeLigatureSubstitutionLookupDictionary()
		{
			List<LigatureSubstitutionRecord> ligatureSubstitutionRecords = m_FontFeatureTable.m_LigatureSubstitutionRecords;
			InitializeLookup(ligatureSubstitutionRecords, ref m_FontFeatureTable.m_LigatureSubstitutionRecordLookup);
			if (ligatureSubstitutionRecords == null)
			{
				return;
			}
			foreach (LigatureSubstitutionRecord item in ligatureSubstitutionRecords)
			{
				if (item.componentGlyphIDs != null && item.componentGlyphIDs.Length != 0)
				{
					uint key = item.componentGlyphIDs[0];
					if (m_FontFeatureTable.m_LigatureSubstitutionRecordLookup.TryGetValue(key, out var value))
					{
						value.Add(item);
						continue;
					}
					m_FontFeatureTable.m_LigatureSubstitutionRecordLookup.Add(key, new List<LigatureSubstitutionRecord> { item });
				}
			}
		}

		internal void InitializeGlyphPairAdjustmentRecordsLookupDictionary()
		{
			List<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords = m_FontFeatureTable.glyphPairAdjustmentRecords;
			InitializeLookup(glyphPairAdjustmentRecords, ref m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup);
			if (glyphPairAdjustmentRecords == null)
			{
				return;
			}
			foreach (GlyphPairAdjustmentRecord item in glyphPairAdjustmentRecords)
			{
				uint key = (item.secondAdjustmentRecord.glyphIndex << 16) | item.firstAdjustmentRecord.glyphIndex;
				m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryAdd(key, item);
			}
		}

		internal void InitializeMarkToBaseAdjustmentRecordsLookupDictionary()
		{
			List<MarkToBaseAdjustmentRecord> markToBaseAdjustmentRecords = m_FontFeatureTable.m_MarkToBaseAdjustmentRecords;
			InitializeLookup(markToBaseAdjustmentRecords, ref m_FontFeatureTable.m_MarkToBaseAdjustmentRecordLookup);
			if (markToBaseAdjustmentRecords == null)
			{
				return;
			}
			foreach (MarkToBaseAdjustmentRecord item in markToBaseAdjustmentRecords)
			{
				uint key = (item.markGlyphID << 16) | item.baseGlyphID;
				m_FontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryAdd(key, item);
			}
		}

		internal void InitializeMarkToMarkAdjustmentRecordsLookupDictionary()
		{
			List<MarkToMarkAdjustmentRecord> markToMarkAdjustmentRecords = m_FontFeatureTable.m_MarkToMarkAdjustmentRecords;
			InitializeLookup(markToMarkAdjustmentRecords, ref m_FontFeatureTable.m_MarkToMarkAdjustmentRecordLookup);
			if (markToMarkAdjustmentRecords == null)
			{
				return;
			}
			foreach (MarkToMarkAdjustmentRecord item in markToMarkAdjustmentRecords)
			{
				uint key = (item.combiningMarkGlyphID << 16) | item.baseMarkGlyphID;
				m_FontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.TryAdd(key, item);
			}
		}

		internal void AddSynthesizedCharactersAndFaceMetrics()
		{
			bool flag = false;
			if (m_AtlasPopulationMode == AtlasPopulationMode.Dynamic || m_AtlasPopulationMode == AtlasPopulationMode.DynamicOS)
			{
				flag = LoadFontFace() == FontEngineError.Success;
				if (!flag && !InternalDynamicOS)
				{
					Debug.LogWarning("Unable to load font face for [" + base.name + "] font asset.", this);
				}
			}
			AddSynthesizedCharacter(3u, flag, addImmediately: true);
			AddSynthesizedCharacter(9u, flag, addImmediately: true);
			AddSynthesizedCharacter(10u, flag);
			AddSynthesizedCharacter(11u, flag);
			AddSynthesizedCharacter(13u, flag);
			AddSynthesizedCharacter(1564u, flag);
			AddSynthesizedCharacter(8203u, flag);
			AddSynthesizedCharacter(8206u, flag);
			AddSynthesizedCharacter(8207u, flag);
			AddSynthesizedCharacter(8232u, flag);
			AddSynthesizedCharacter(8233u, flag);
			AddSynthesizedCharacter(8288u, flag);
		}

		private void AddSynthesizedCharacter(uint unicode, bool isFontFaceLoaded, bool addImmediately = false)
		{
			if (m_CharacterLookupDictionary.ContainsKey(unicode))
			{
				return;
			}
			Glyph glyph;
			Character value;
			if (isFontFaceLoaded && FontEngine.GetGlyphIndex(unicode) != 0)
			{
				if (!addImmediately)
				{
					return;
				}
				GlyphLoadFlags flags = (((m_AtlasRenderMode & (GlyphRenderMode)4) == (GlyphRenderMode)4) ? (GlyphLoadFlags.LOAD_NO_HINTING | GlyphLoadFlags.LOAD_NO_BITMAP) : GlyphLoadFlags.LOAD_NO_BITMAP);
				if (!FontEngine.TryGetGlyphWithUnicodeValue(unicode, flags, out glyph))
				{
					return;
				}
				value = new Character(unicode, this, glyph);
				{
					foreach (TextFontWeight value2 in Enum.GetValues(typeof(TextFontWeight)))
					{
						m_CharacterLookupDictionary.Add(CreateCompositeKey(unicode, FontStyles.Normal, value2), value);
						m_CharacterLookupDictionary.Add(CreateCompositeKey(unicode, FontStyles.Italic, value2), value);
					}
					return;
				}
			}
			glyph = new Glyph(0u, new GlyphMetrics(0f, 0f, 0f, 0f, 0f), GlyphRect.zero, 1f, 0);
			value = new Character(unicode, this, glyph);
			foreach (TextFontWeight value3 in Enum.GetValues(typeof(TextFontWeight)))
			{
				m_CharacterLookupDictionary.Add(CreateCompositeKey(unicode, FontStyles.Normal, value3), value);
				m_CharacterLookupDictionary.Add(CreateCompositeKey(unicode, FontStyles.Italic, value3), value);
			}
		}

		internal void AddCharacterToLookupCache(uint unicode, Character character)
		{
			AddCharacterToLookupCache(unicode, character, FontStyles.Normal, TextFontWeight.Regular);
		}

		internal void AddCharacterToLookupCache(uint unicode, Character character, FontStyles fontStyle, TextFontWeight fontWeight)
		{
			if (m_CharacterLookupDictionary == null)
			{
				ReadFontAssetDefinition();
			}
			m_CharacterLookupDictionary.TryAdd(CreateCompositeKey(unicode, fontStyle, fontWeight), character);
		}

		internal bool GetCharacterInLookupCache(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight, out Character character)
		{
			if (m_CharacterLookupDictionary == null)
			{
				ReadFontAssetDefinition();
			}
			return m_CharacterLookupDictionary.TryGetValue(CreateCompositeKey(unicode, fontStyle, fontWeight), out character);
		}

		internal void RemoveCharacterInLookupCache(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight)
		{
			if (m_CharacterLookupDictionary == null)
			{
				ReadFontAssetDefinition();
			}
			m_CharacterLookupDictionary.Remove(CreateCompositeKey(unicode, fontStyle, fontWeight));
		}

		internal bool ContainsCharacterInLookupCache(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight)
		{
			if (m_CharacterLookupDictionary == null)
			{
				ReadFontAssetDefinition();
			}
			return m_CharacterLookupDictionary.ContainsKey(CreateCompositeKey(unicode, fontStyle, fontWeight));
		}

		private uint CreateCompositeKey(uint unicode, FontStyles fontStyle = FontStyles.Normal, TextFontWeight fontWeight = TextFontWeight.Regular)
		{
			if (fontStyle == FontStyles.Normal && fontWeight == TextFontWeight.Regular)
			{
				return unicode;
			}
			bool flag = (fontStyle & FontStyles.Italic) == FontStyles.Italic;
			int num = 0;
			if (fontWeight != TextFontWeight.Regular)
			{
				num = TextUtilities.GetTextFontWeightIndex(fontWeight);
			}
			uint num2 = unicode & 0x1FFFFF;
			uint num3 = (uint)((num & 0xF) << 21);
			uint num4 = (flag ? 33554432u : 0u);
			return num2 | num3 | num4;
		}

		internal FontEngineError LoadFontFace()
		{
			if (m_AtlasPopulationMode == AtlasPopulationMode.Dynamic)
			{
				if (FontEngine.LoadFontFace(m_SourceFontFile, m_FaceInfo.pointSize, m_FaceInfo.faceIndex) == FontEngineError.Success)
				{
					return FontEngineError.Success;
				}
				if (!string.IsNullOrEmpty(m_SourceFontFilePath))
				{
					return FontEngine.LoadFontFace(m_SourceFontFilePath, m_FaceInfo.pointSize, m_FaceInfo.faceIndex);
				}
				return FontEngineError.Invalid_Face;
			}
			return FontEngine.LoadFontFace(m_FaceInfo.familyName, m_FaceInfo.styleName, m_FaceInfo.pointSize);
		}

		internal void SortCharacterTable()
		{
			if (m_CharacterTable != null && m_CharacterTable.Count > 0)
			{
				m_CharacterTable = m_CharacterTable.OrderBy((Character c) => c.unicode).ToList();
			}
		}

		internal void SortGlyphTable()
		{
			if (m_GlyphTable != null && m_GlyphTable.Count > 0)
			{
				m_GlyphTable = m_GlyphTable.OrderBy((Glyph c) => c.index).ToList();
			}
		}

		internal void SortFontFeatureTable()
		{
			m_FontFeatureTable.SortGlyphPairAdjustmentRecords();
			m_FontFeatureTable.SortMarkToBaseAdjustmentRecords();
			m_FontFeatureTable.SortMarkToMarkAdjustmentRecords();
		}

		internal void SortAllTables()
		{
			SortGlyphTable();
			SortCharacterTable();
			SortFontFeatureTable();
		}

		public bool HasCharacter(int character)
		{
			if (characterLookupTable == null)
			{
				return false;
			}
			return m_CharacterLookupDictionary.ContainsKey((uint)character);
		}

		public bool HasCharacter(char character, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			return HasCharacter((uint)character, searchFallbacks, tryAddCharacter);
		}

		public bool HasCharacter(uint character, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			if (characterLookupTable == null)
			{
				return false;
			}
			if (m_CharacterLookupDictionary.ContainsKey(character))
			{
				return true;
			}
			if (tryAddCharacter && (m_AtlasPopulationMode == AtlasPopulationMode.Dynamic || m_AtlasPopulationMode == AtlasPopulationMode.DynamicOS) && TryAddCharacterInternal(character, FontStyles.Normal, TextFontWeight.Regular, out var _))
			{
				return true;
			}
			if (searchFallbacks)
			{
				if (k_SearchedFontAssetLookup == null)
				{
					k_SearchedFontAssetLookup = new HashSet<int>();
				}
				else
				{
					k_SearchedFontAssetLookup.Clear();
				}
				k_SearchedFontAssetLookup.Add(GetInstanceID());
				if (fallbackFontAssetTable != null && fallbackFontAssetTable.Count > 0)
				{
					for (int i = 0; i < fallbackFontAssetTable.Count && fallbackFontAssetTable[i] != null; i++)
					{
						FontAsset fontAsset = fallbackFontAssetTable[i];
						int item = fontAsset.GetInstanceID();
						if (k_SearchedFontAssetLookup.Add(item) && fontAsset.HasCharacter_Internal(character, FontStyles.Normal, TextFontWeight.Regular, searchFallbacks: true, tryAddCharacter))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private bool HasCharacterWithStyle_Internal(uint character, FontStyles fontStyle, TextFontWeight fontWeight, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			return HasCharacter_Internal(character, fontStyle, fontWeight, searchFallbacks, tryAddCharacter);
		}

		private bool HasCharacter_Internal(uint character, FontStyles fontStyle = FontStyles.Normal, TextFontWeight fontWeight = TextFontWeight.Regular, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			if (m_CharacterLookupDictionary == null)
			{
				ReadFontAssetDefinition();
				if (m_CharacterLookupDictionary == null)
				{
					return false;
				}
			}
			if (ContainsCharacterInLookupCache(character, fontStyle, fontWeight))
			{
				return true;
			}
			if (tryAddCharacter && (atlasPopulationMode == AtlasPopulationMode.Dynamic || m_AtlasPopulationMode == AtlasPopulationMode.DynamicOS) && TryAddCharacterInternal(character, fontStyle, fontWeight, out var _))
			{
				return true;
			}
			if (searchFallbacks)
			{
				if (fallbackFontAssetTable == null || fallbackFontAssetTable.Count == 0)
				{
					return false;
				}
				for (int i = 0; i < fallbackFontAssetTable.Count && fallbackFontAssetTable[i] != null; i++)
				{
					FontAsset fontAsset = fallbackFontAssetTable[i];
					int item = fontAsset.GetInstanceID();
					if (k_SearchedFontAssetLookup.Add(item) && fontAsset.HasCharacter_Internal(character, fontStyle, fontWeight, searchFallbacks: true, tryAddCharacter))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasCharacters(string text, out List<char> missingCharacters)
		{
			if (characterLookupTable == null)
			{
				missingCharacters = null;
				return false;
			}
			missingCharacters = new List<char>();
			for (int i = 0; i < text.Length; i++)
			{
				uint codePoint = FontAssetUtilities.GetCodePoint(text, ref i);
				if (!m_CharacterLookupDictionary.ContainsKey(codePoint))
				{
					missingCharacters.Add((char)codePoint);
				}
			}
			if (missingCharacters.Count == 0)
			{
				return true;
			}
			return false;
		}

		public bool HasCharacters(string text, out uint[] missingCharacters, bool searchFallbacks = false, bool tryAddCharacter = false)
		{
			missingCharacters = null;
			if (characterLookupTable == null)
			{
				return false;
			}
			s_MissingCharacterList.Clear();
			for (int i = 0; i < text.Length; i++)
			{
				bool flag = true;
				uint codePoint = FontAssetUtilities.GetCodePoint(text, ref i);
				if (m_CharacterLookupDictionary.ContainsKey(codePoint) || (tryAddCharacter && (atlasPopulationMode == AtlasPopulationMode.Dynamic || m_AtlasPopulationMode == AtlasPopulationMode.DynamicOS) && TryAddCharacterInternal(codePoint, FontStyles.Normal, TextFontWeight.Regular, out var _)))
				{
					continue;
				}
				if (searchFallbacks)
				{
					if (k_SearchedFontAssetLookup == null)
					{
						k_SearchedFontAssetLookup = new HashSet<int>();
					}
					else
					{
						k_SearchedFontAssetLookup.Clear();
					}
					k_SearchedFontAssetLookup.Add(GetInstanceID());
					if (fallbackFontAssetTable != null && fallbackFontAssetTable.Count > 0)
					{
						for (int j = 0; j < fallbackFontAssetTable.Count && fallbackFontAssetTable[j] != null; j++)
						{
							FontAsset fontAsset = fallbackFontAssetTable[j];
							int item = fontAsset.GetInstanceID();
							if (k_SearchedFontAssetLookup.Add(item) && fontAsset.HasCharacter_Internal(codePoint, FontStyles.Normal, TextFontWeight.Regular, searchFallbacks: true, tryAddCharacter))
							{
								flag = false;
								break;
							}
						}
					}
				}
				if (flag)
				{
					s_MissingCharacterList.Add(codePoint);
				}
			}
			if (s_MissingCharacterList.Count > 0)
			{
				missingCharacters = s_MissingCharacterList.ToArray();
				return false;
			}
			return true;
		}

		public bool HasCharacters(string text)
		{
			if (characterLookupTable == null)
			{
				return false;
			}
			for (int i = 0; i < text.Length; i++)
			{
				uint codePoint = FontAssetUtilities.GetCodePoint(text, ref i);
				if (!m_CharacterLookupDictionary.ContainsKey(codePoint))
				{
					return false;
				}
			}
			return true;
		}

		public static string GetCharacters(FontAsset fontAsset)
		{
			string text = string.Empty;
			for (int i = 0; i < fontAsset.characterTable.Count; i++)
			{
				text += (char)fontAsset.characterTable[i].unicode;
			}
			return text;
		}

		public static int[] GetCharactersArray(FontAsset fontAsset)
		{
			int[] array = new int[fontAsset.characterTable.Count];
			for (int i = 0; i < fontAsset.characterTable.Count; i++)
			{
				array[i] = (int)fontAsset.characterTable[i].unicode;
			}
			return array;
		}

		internal uint GetGlyphIndex(uint unicode)
		{
			bool success;
			return GetGlyphIndex(unicode, out success);
		}

		internal uint GetGlyphIndex(uint unicode, out bool success)
		{
			success = true;
			if (characterLookupTable.TryGetValue(unicode, out var value))
			{
				return value.glyphIndex;
			}
			if (TextGenerator.IsExecutingJob)
			{
				success = false;
				return 0u;
			}
			return (LoadFontFace() == FontEngineError.Success) ? FontEngine.GetGlyphIndex(unicode) : 0u;
		}

		internal uint GetGlyphVariantIndex(uint unicode, uint variantSelectorUnicode)
		{
			return (LoadFontFace() == FontEngineError.Success) ? FontEngine.GetVariantGlyphIndex(unicode, variantSelectorUnicode) : 0u;
		}

		internal void UpdateFontAssetData()
		{
			uint[] array = new uint[m_CharacterTable.Count];
			for (int i = 0; i < m_CharacterTable.Count; i++)
			{
				array[i] = m_CharacterTable[i].unicode;
			}
			ClearCharacterAndGlyphTables();
			ClearFontFeaturesTables();
			ClearAtlasTextures(setAtlasSizeToZero: true);
			ReadFontAssetDefinition();
			if (array.Length != 0)
			{
				TryAddCharacters(array, m_GetFontFeatures);
			}
		}

		public void ClearFontAssetData(bool setAtlasSizeToZero = false)
		{
			using (k_ClearFontAssetDataMarker.Auto())
			{
				ClearCharacterAndGlyphTables();
				ClearFontFeaturesTables();
				ClearAtlasTextures(setAtlasSizeToZero);
				ReadFontAssetDefinition();
				for (int i = 0; i < s_CallbackInstances.Count; i++)
				{
					if (s_CallbackInstances[i].TryGetTarget(out var target) && target != this)
					{
						target.ClearFallbackCharacterTable();
					}
				}
				TextEventManager.ON_FONT_PROPERTY_CHANGED(isChanged: true, this);
			}
		}

		internal void ClearCharacterAndGlyphTablesInternal()
		{
			ClearCharacterAndGlyphTables();
			ClearAtlasTextures(setAtlasSizeToZero: true);
			ReadFontAssetDefinition();
		}

		private void ClearCharacterAndGlyphTables()
		{
			if (m_GlyphTable != null)
			{
				m_GlyphTable.Clear();
			}
			if (m_CharacterTable != null)
			{
				m_CharacterTable.Clear();
			}
			if (m_UsedGlyphRects != null)
			{
				m_UsedGlyphRects.Clear();
			}
			if (m_FreeGlyphRects != null)
			{
				int num = (((m_AtlasRenderMode & (GlyphRenderMode)16) != (GlyphRenderMode)16) ? 1 : 0);
				m_FreeGlyphRects.Clear();
				m_FreeGlyphRects.Add(new GlyphRect(0, 0, m_AtlasWidth - num, m_AtlasHeight - num));
			}
			if (m_GlyphsToRender != null)
			{
				m_GlyphsToRender.Clear();
			}
			if (m_GlyphsRendered != null)
			{
				m_GlyphsRendered.Clear();
			}
		}

		private void ClearFontFeaturesTables()
		{
			if (m_FontFeatureTable != null && m_FontFeatureTable.m_LigatureSubstitutionRecords != null)
			{
				m_FontFeatureTable.m_LigatureSubstitutionRecords.Clear();
			}
			if (m_FontFeatureTable != null && m_FontFeatureTable.glyphPairAdjustmentRecords != null)
			{
				m_FontFeatureTable.glyphPairAdjustmentRecords.Clear();
			}
			if (m_FontFeatureTable != null && m_FontFeatureTable.m_MarkToBaseAdjustmentRecords != null)
			{
				m_FontFeatureTable.m_MarkToBaseAdjustmentRecords.Clear();
			}
			if (m_FontFeatureTable != null && m_FontFeatureTable.m_MarkToMarkAdjustmentRecords != null)
			{
				m_FontFeatureTable.m_MarkToMarkAdjustmentRecords.Clear();
			}
		}

		internal void ClearAtlasTextures(bool setAtlasSizeToZero = false)
		{
			m_AtlasTextureIndex = 0;
			if (m_AtlasTextures == null)
			{
				return;
			}
			Texture2D texture2D = null;
			for (int i = 1; i < m_AtlasTextures.Length; i++)
			{
				texture2D = m_AtlasTextures[i];
				if ((bool)texture2D)
				{
					Object.Destroy(texture2D);
				}
			}
			Array.Resize(ref m_AtlasTextures, 1);
			texture2D = (m_AtlasTexture = m_AtlasTextures[0]);
			if (!texture2D.isReadable)
			{
			}
			TextureFormat format = (((m_AtlasRenderMode & (GlyphRenderMode)65536) != (GlyphRenderMode)65536) ? TextureFormat.Alpha8 : TextureFormat.RGBA32);
			if (setAtlasSizeToZero)
			{
				texture2D.Reinitialize(1, 1, format, hasMipMap: false);
			}
			else if (texture2D.width != m_AtlasWidth || texture2D.height != m_AtlasHeight)
			{
				texture2D.Reinitialize(m_AtlasWidth, m_AtlasHeight, format, hasMipMap: false);
			}
			FontEngine.ResetAtlasTexture(texture2D);
			texture2D.Apply();
		}

		private void DestroyAtlasTextures()
		{
			m_AtlasTexture = null;
			m_AtlasTextureIndex = -1;
			if (m_AtlasTextures == null)
			{
				return;
			}
			Texture2D[] array = m_AtlasTextures;
			foreach (Texture2D texture2D in array)
			{
				if (texture2D != null)
				{
					Object.Destroy(texture2D);
				}
			}
			m_AtlasTextures = null;
		}

		internal static void RegisterFontAssetForFontFeatureUpdate(FontAsset fontAsset)
		{
			int item = fontAsset.instanceID;
			if (k_FontAssets_FontFeaturesUpdateQueueLookup.Add(item))
			{
				k_FontAssets_FontFeaturesUpdateQueue.Add(fontAsset);
			}
		}

		internal static void RegisterFontAssetForKerningUpdate(FontAsset fontAsset)
		{
			int item = fontAsset.instanceID;
			if (k_FontAssets_KerningUpdateQueueLookup.Add(item))
			{
				k_FontAssets_KerningUpdateQueue.Add(fontAsset);
			}
		}

		internal static void UpdateFontFeaturesForFontAssetsInQueue()
		{
			int count = k_FontAssets_FontFeaturesUpdateQueue.Count;
			for (int i = 0; i < count; i++)
			{
				k_FontAssets_FontFeaturesUpdateQueue[i].UpdateGPOSFontFeaturesForNewlyAddedGlyphs();
			}
			if (count > 0)
			{
				k_FontAssets_FontFeaturesUpdateQueue.Clear();
				k_FontAssets_FontFeaturesUpdateQueueLookup.Clear();
			}
			count = k_FontAssets_KerningUpdateQueue.Count;
			for (int j = 0; j < count; j++)
			{
				k_FontAssets_KerningUpdateQueue[j].UpdateGlyphAdjustmentRecordsForNewGlyphs();
			}
			if (count > 0)
			{
				k_FontAssets_KerningUpdateQueue.Clear();
				k_FontAssets_KerningUpdateQueueLookup.Clear();
			}
		}

		internal static void RegisterAtlasTextureForApply(Texture2D texture)
		{
			int item = texture.GetInstanceID();
			if (k_FontAssets_AtlasTexturesUpdateQueueLookup.Add(item))
			{
				k_FontAssets_AtlasTexturesUpdateQueue.Add(texture);
			}
		}

		internal static void UpdateAtlasTexturesInQueue()
		{
			int count = k_FontAssets_AtlasTexturesUpdateQueueLookup.Count;
			for (int i = 0; i < count; i++)
			{
				k_FontAssets_AtlasTexturesUpdateQueue[i].Apply(updateMipmaps: false, makeNoLongerReadable: false);
			}
			if (count > 0)
			{
				k_FontAssets_AtlasTexturesUpdateQueue.Clear();
				k_FontAssets_AtlasTexturesUpdateQueueLookup.Clear();
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static void UpdateFontAssetsInUpdateQueue()
		{
			UpdateAtlasTexturesInQueue();
			UpdateFontFeaturesForFontAssetsInQueue();
		}

		public bool TryAddCharacters(uint[] unicodes, bool includeFontFeatures = false)
		{
			uint[] missingUnicodes;
			return TryAddCharacters(unicodes, out missingUnicodes, includeFontFeatures);
		}

		public bool TryAddCharacters(uint[] unicodes, out uint[] missingUnicodes, bool includeFontFeatures = false)
		{
			using (k_TryAddCharactersMarker.Auto())
			{
				if (unicodes == null || unicodes.Length == 0 || m_AtlasPopulationMode == AtlasPopulationMode.Static)
				{
					if (m_AtlasPopulationMode == AtlasPopulationMode.Static)
					{
						Debug.LogWarning("Unable to add characters to font asset [" + base.name + "] because its AtlasPopulationMode is set to Static.", this);
					}
					else
					{
						Debug.LogWarning("Unable to add characters to font asset [" + base.name + "] because the provided Unicode list is Null or Empty.", this);
					}
					missingUnicodes = null;
					return false;
				}
				if (LoadFontFace() != FontEngineError.Success)
				{
					missingUnicodes = new uint[unicodes.Length];
					int num = 0;
					foreach (uint num2 in unicodes)
					{
						missingUnicodes[num++] = num2;
					}
					return false;
				}
				if (m_CharacterLookupDictionary == null || m_GlyphLookupDictionary == null)
				{
					ReadFontAssetDefinition();
				}
				Dictionary<uint, Character> characterLookupDictionary = m_CharacterLookupDictionary;
				Dictionary<uint, Glyph> glyphLookupDictionary = m_GlyphLookupDictionary;
				m_GlyphsToAdd.Clear();
				m_GlyphsToAddLookup.Clear();
				m_CharactersToAdd.Clear();
				m_CharactersToAddLookup.Clear();
				s_MissingCharacterList.Clear();
				bool flag = false;
				int num3 = unicodes.Length;
				for (int j = 0; j < num3; j++)
				{
					uint codePoint = FontAssetUtilities.GetCodePoint(unicodes, ref j);
					if (characterLookupDictionary.ContainsKey(codePoint))
					{
						continue;
					}
					uint glyphIndex = FontEngine.GetGlyphIndex(codePoint);
					if (glyphIndex == 0)
					{
						switch (codePoint)
						{
						case 160u:
							glyphIndex = FontEngine.GetGlyphIndex(32u);
							break;
						case 173u:
						case 8209u:
							glyphIndex = FontEngine.GetGlyphIndex(45u);
							break;
						}
						if (glyphIndex == 0)
						{
							s_MissingCharacterList.Add(codePoint);
							flag = true;
							continue;
						}
					}
					Character character = new Character(codePoint, glyphIndex);
					if (glyphLookupDictionary.TryGetValue(glyphIndex, out var value))
					{
						character.glyph = value;
						character.textAsset = this;
						m_CharacterTable.Add(character);
						characterLookupDictionary.Add(codePoint, character);
						continue;
					}
					if (m_GlyphsToAddLookup.Add(glyphIndex))
					{
						m_GlyphsToAdd.Add(glyphIndex);
					}
					if (m_CharactersToAddLookup.Add(codePoint))
					{
						m_CharactersToAdd.Add(character);
					}
				}
				if (m_GlyphsToAdd.Count == 0)
				{
					missingUnicodes = unicodes;
					return !flag;
				}
				if (m_AtlasTextures[m_AtlasTextureIndex].width <= 1 || m_AtlasTextures[m_AtlasTextureIndex].height <= 1)
				{
					m_AtlasTextures[m_AtlasTextureIndex].Reinitialize(m_AtlasWidth, m_AtlasHeight);
					FontEngine.ResetAtlasTexture(m_AtlasTextures[m_AtlasTextureIndex]);
				}
				Glyph[] glyphs;
				bool flag2 = FontEngine.TryAddGlyphsToTexture(m_GlyphsToAdd, m_AtlasPadding, GlyphPackingMode.BestShortSideFit, m_FreeGlyphRects, m_UsedGlyphRects, m_AtlasRenderMode, m_AtlasTextures[m_AtlasTextureIndex], out glyphs);
				int additionalCapacity = glyphs.Length;
				EnsureAdditionalCapacity(m_GlyphTable, additionalCapacity);
				EnsureAdditionalCapacity(glyphLookupDictionary, additionalCapacity);
				EnsureAdditionalCapacity(m_GlyphIndexListNewlyAdded, additionalCapacity);
				EnsureAdditionalCapacity(m_GlyphIndexList, additionalCapacity);
				for (int k = 0; k < glyphs.Length && glyphs[k] != null; k++)
				{
					Glyph glyph = glyphs[k];
					uint index = glyph.index;
					glyph.atlasIndex = m_AtlasTextureIndex;
					m_GlyphTable.Add(glyph);
					glyphLookupDictionary.Add(index, glyph);
					m_GlyphIndexListNewlyAdded.Add(index);
					m_GlyphIndexList.Add(index);
				}
				m_GlyphsToAdd.Clear();
				int count = m_CharactersToAdd.Count;
				EnsureAdditionalCapacity(m_GlyphsToAdd, count);
				EnsureAdditionalCapacity(m_CharacterTable, count);
				EnsureAdditionalCapacity(characterLookupDictionary, count);
				for (int l = 0; l < m_CharactersToAdd.Count; l++)
				{
					Character character2 = m_CharactersToAdd[l];
					if (!glyphLookupDictionary.TryGetValue(character2.glyphIndex, out var value2))
					{
						m_GlyphsToAdd.Add(character2.glyphIndex);
						continue;
					}
					character2.glyph = value2;
					character2.textAsset = this;
					m_CharacterTable.Add(character2);
					characterLookupDictionary.Add(character2.unicode, character2);
					m_CharactersToAdd.RemoveAt(l);
					l--;
				}
				if (m_IsMultiAtlasTexturesEnabled && !flag2)
				{
					while (!flag2)
					{
						flag2 = TryAddGlyphsToNewAtlasTexture();
					}
				}
				else if (!flag2)
				{
					Debug.Log("Atlas is full, consider enabling multi-atlas textures in the Font Asset: " + base.name);
				}
				if (includeFontFeatures)
				{
					UpdateFontFeaturesForNewlyAddedGlyphs();
				}
				foreach (Character item in m_CharactersToAdd)
				{
					s_MissingCharacterList.Add(item.unicode);
				}
				missingUnicodes = null;
				if (s_MissingCharacterList.Count > 0)
				{
					missingUnicodes = s_MissingCharacterList.ToArray();
				}
				return flag2 && !flag;
			}
		}

		public bool TryAddCharacters(string characters, bool includeFontFeatures = false)
		{
			string missingCharacters;
			return TryAddCharacters(characters, out missingCharacters, includeFontFeatures);
		}

		public bool TryAddCharacters(string characters, out string missingCharacters, bool includeFontFeatures = false)
		{
			uint[] array = new uint[characters.Length];
			for (int i = 0; i < characters.Length; i++)
			{
				array[i] = characters[i];
			}
			uint[] missingUnicodes;
			bool result = TryAddCharacters(array, out missingUnicodes, includeFontFeatures);
			if (missingUnicodes == null || missingUnicodes.Length == 0)
			{
				missingCharacters = null;
				return result;
			}
			StringBuilder stringBuilder = new StringBuilder(missingUnicodes.Length);
			uint[] array2 = missingUnicodes;
			foreach (uint num in array2)
			{
				stringBuilder.Append((char)num);
			}
			missingCharacters = stringBuilder.ToString();
			return result;
		}

		internal bool TryAddGlyphVariantIndexInternal(uint unicode, uint nextCharacter, uint variantGlyphIndex)
		{
			return m_VariantGlyphIndexes.TryAdd((unicode, nextCharacter), variantGlyphIndex);
		}

		internal bool TryGetGlyphVariantIndexInternal(uint unicode, uint nextCharacter, out uint variantGlyphIndex)
		{
			return m_VariantGlyphIndexes.TryGetValue((unicode, nextCharacter), out variantGlyphIndex);
		}

		internal bool TryAddGlyphInternal(uint glyphIndex, out Glyph glyph)
		{
			using (k_TryAddGlyphMarker.Auto())
			{
				glyph = null;
				if (glyphLookupTable.TryGetValue(glyphIndex, out glyph))
				{
					return true;
				}
				if (LoadFontFace() != FontEngineError.Success)
				{
					return false;
				}
				return TryAddGlyphToAtlas(glyphIndex, out glyph);
			}
		}

		internal bool TryAddCharacterInternal(uint unicode, out Character character)
		{
			return TryAddCharacterInternal(unicode, FontStyles.Normal, TextFontWeight.Regular, out character);
		}

		internal bool TryAddCharacterInternal(uint unicode, FontStyles fontStyle, TextFontWeight fontWeight, out Character character, bool populateLigatures = true)
		{
			using (k_TryAddCharacterMarker.Auto())
			{
				character = null;
				if (m_MissingUnicodesFromFontFile.Contains(unicode))
				{
					return false;
				}
				if (LoadFontFace() != FontEngineError.Success)
				{
					return false;
				}
				uint glyphIndex = FontEngine.GetGlyphIndex(unicode);
				if (glyphIndex == 0)
				{
					switch (unicode)
					{
					case 160u:
						glyphIndex = FontEngine.GetGlyphIndex(32u);
						break;
					case 173u:
					case 8209u:
						glyphIndex = FontEngine.GetGlyphIndex(45u);
						break;
					}
					if (glyphIndex == 0)
					{
						m_MissingUnicodesFromFontFile.Add(unicode);
						return false;
					}
				}
				if (glyphLookupTable.ContainsKey(glyphIndex))
				{
					character = CreateCharacterAndAddToCache(unicode, m_GlyphLookupDictionary[glyphIndex], fontStyle, fontWeight);
					return true;
				}
				Glyph glyph = null;
				if (TryAddGlyphToAtlas(glyphIndex, out glyph, populateLigatures))
				{
					character = CreateCharacterAndAddToCache(unicode, glyph, fontStyle, fontWeight);
					return true;
				}
				return false;
			}
		}

		private bool TryAddGlyphToAtlas(uint glyphIndex, out Glyph glyph, bool populateLigatures = true)
		{
			glyph = null;
			if (!m_AtlasTextures[m_AtlasTextureIndex].isReadable)
			{
				Debug.LogWarning("Unable to add the requested glyph to font asset [" + base.name + "]'s atlas texture. Please make the texture [" + m_AtlasTextures[m_AtlasTextureIndex].name + "] readable.", m_AtlasTextures[m_AtlasTextureIndex]);
				return false;
			}
			if (m_AtlasTextures[m_AtlasTextureIndex].width <= 1 || m_AtlasTextures[m_AtlasTextureIndex].height <= 1)
			{
				m_AtlasTextures[m_AtlasTextureIndex].Reinitialize(m_AtlasWidth, m_AtlasHeight);
				FontEngine.ResetAtlasTexture(m_AtlasTextures[m_AtlasTextureIndex]);
			}
			FontEngine.SetTextureUploadMode(shouldUploadImmediately: false);
			if (TryAddGlyphToTexture(glyphIndex, out glyph, populateLigatures))
			{
				return true;
			}
			if (m_IsMultiAtlasTexturesEnabled && m_UsedGlyphRects.Count > 0)
			{
				SetupNewAtlasTexture();
				FontEngine.SetTextureUploadMode(shouldUploadImmediately: false);
				if (TryAddGlyphToTexture(glyphIndex, out glyph, populateLigatures))
				{
					return true;
				}
			}
			else if (m_UsedGlyphRects.Count > 0)
			{
				Debug.Log("Atlas is full, consider enabling multi-atlas textures in the Font Asset: " + base.name);
			}
			return false;
		}

		private bool TryAddGlyphToTexture(uint glyphIndex, out Glyph glyph, bool populateLigatures = true)
		{
			if (FontEngine.TryAddGlyphToTexture(glyphIndex, m_AtlasPadding, GlyphPackingMode.BestShortSideFit, m_FreeGlyphRects, m_UsedGlyphRects, m_AtlasRenderMode, m_AtlasTextures[m_AtlasTextureIndex], out glyph))
			{
				glyph.atlasIndex = m_AtlasTextureIndex;
				m_GlyphTable.Add(glyph);
				m_GlyphLookupDictionary.Add(glyphIndex, glyph);
				m_GlyphIndexList.Add(glyphIndex);
				m_GlyphIndexListNewlyAdded.Add(glyphIndex);
				if (m_GetFontFeatures)
				{
					if (populateLigatures)
					{
						UpdateGSUBFontFeaturesForNewGlyphIndex(glyphIndex);
						RegisterFontAssetForFontFeatureUpdate(this);
					}
					else
					{
						RegisterFontAssetForKerningUpdate(this);
					}
				}
				RegisterAtlasTextureForApply(m_AtlasTextures[m_AtlasTextureIndex]);
				FontEngine.SetTextureUploadMode(shouldUploadImmediately: true);
				return true;
			}
			return false;
		}

		private bool TryAddGlyphsToNewAtlasTexture()
		{
			SetupNewAtlasTexture();
			Glyph[] glyphs;
			bool result = FontEngine.TryAddGlyphsToTexture(m_GlyphsToAdd, m_AtlasPadding, GlyphPackingMode.BestShortSideFit, m_FreeGlyphRects, m_UsedGlyphRects, m_AtlasRenderMode, m_AtlasTextures[m_AtlasTextureIndex], out glyphs);
			for (int i = 0; i < glyphs.Length && glyphs[i] != null; i++)
			{
				Glyph glyph = glyphs[i];
				uint index = glyph.index;
				glyph.atlasIndex = m_AtlasTextureIndex;
				m_GlyphTable.Add(glyph);
				m_GlyphLookupDictionary.Add(index, glyph);
				m_GlyphIndexListNewlyAdded.Add(index);
				m_GlyphIndexList.Add(index);
			}
			m_GlyphsToAdd.Clear();
			for (int j = 0; j < m_CharactersToAdd.Count; j++)
			{
				Character character = m_CharactersToAdd[j];
				if (!m_GlyphLookupDictionary.TryGetValue(character.glyphIndex, out var value))
				{
					m_GlyphsToAdd.Add(character.glyphIndex);
					continue;
				}
				character.glyph = value;
				character.textAsset = this;
				m_CharacterTable.Add(character);
				m_CharacterLookupDictionary.Add(character.unicode, character);
				m_CharactersToAdd.RemoveAt(j);
				j--;
			}
			return result;
		}

		private void SetupNewAtlasTexture()
		{
			m_AtlasTextureIndex++;
			if (m_AtlasTextures.Length == m_AtlasTextureIndex)
			{
				Array.Resize(ref m_AtlasTextures, m_AtlasTextures.Length * 2);
			}
			TextureFormat textureFormat = (((m_AtlasRenderMode & (GlyphRenderMode)65536) != (GlyphRenderMode)65536) ? TextureFormat.Alpha8 : TextureFormat.RGBA32);
			m_AtlasTextures[m_AtlasTextureIndex] = new Texture2D(m_AtlasWidth, m_AtlasHeight, textureFormat, mipChain: false);
			m_AtlasTextures[m_AtlasTextureIndex].hideFlags = m_AtlasTextures[0].hideFlags;
			FontEngine.ResetAtlasTexture(m_AtlasTextures[m_AtlasTextureIndex]);
			int num = (((m_AtlasRenderMode & (GlyphRenderMode)16) != (GlyphRenderMode)16) ? 1 : 0);
			m_FreeGlyphRects.Clear();
			m_FreeGlyphRects.Add(new GlyphRect(0, 0, m_AtlasWidth - num, m_AtlasHeight - num));
			m_UsedGlyphRects.Clear();
		}

		private Character CreateCharacterAndAddToCache(uint unicode, Glyph glyph, FontStyles fontStyle, TextFontWeight fontWeight)
		{
			if (!m_CharacterLookupDictionary.TryGetValue(unicode, out var value))
			{
				value = new Character(unicode, this, glyph);
				m_CharacterTable.Add(value);
				AddCharacterToLookupCache(unicode, value, FontStyles.Normal, TextFontWeight.Regular);
			}
			if (fontStyle != FontStyles.Normal || fontWeight != TextFontWeight.Regular)
			{
				AddCharacterToLookupCache(unicode, value, fontStyle, fontWeight);
			}
			return value;
		}

		private void UpdateFontFeaturesForNewlyAddedGlyphs()
		{
			UpdateLigatureSubstitutionRecords();
			UpdateGlyphAdjustmentRecords();
			UpdateDiacriticalMarkAdjustmentRecords();
			m_GlyphIndexListNewlyAdded.Clear();
		}

		private void UpdateGlyphAdjustmentRecordsForNewGlyphs()
		{
			UpdateGlyphAdjustmentRecords();
			m_GlyphIndexListNewlyAdded.Clear();
		}

		private void UpdateGPOSFontFeaturesForNewlyAddedGlyphs()
		{
			UpdateGlyphAdjustmentRecords();
			UpdateDiacriticalMarkAdjustmentRecords();
			m_GlyphIndexListNewlyAdded.Clear();
		}

		internal void ImportFontFeatures()
		{
			if (LoadFontFace() == FontEngineError.Success)
			{
				GlyphPairAdjustmentRecord[] allPairAdjustmentRecords = FontEngine.GetAllPairAdjustmentRecords();
				if (allPairAdjustmentRecords != null)
				{
					AddPairAdjustmentRecords(allPairAdjustmentRecords);
				}
				MarkToBaseAdjustmentRecord[] allMarkToBaseAdjustmentRecords = FontEngine.GetAllMarkToBaseAdjustmentRecords();
				if (allMarkToBaseAdjustmentRecords != null)
				{
					AddMarkToBaseAdjustmentRecords(allMarkToBaseAdjustmentRecords);
				}
				MarkToMarkAdjustmentRecord[] allMarkToMarkAdjustmentRecords = FontEngine.GetAllMarkToMarkAdjustmentRecords();
				if (allMarkToMarkAdjustmentRecords != null)
				{
					AddMarkToMarkAdjustmentRecords(allMarkToMarkAdjustmentRecords);
				}
				LigatureSubstitutionRecord[] allLigatureSubstitutionRecords = FontEngine.GetAllLigatureSubstitutionRecords();
				if (allLigatureSubstitutionRecords != null)
				{
					AddLigatureSubstitutionRecords(allLigatureSubstitutionRecords);
				}
				m_ShouldReimportFontFeatures = false;
			}
		}

		private void UpdateGSUBFontFeaturesForNewGlyphIndex(uint glyphIndex)
		{
			LigatureSubstitutionRecord[] ligatureSubstitutionRecords = FontEngine.GetLigatureSubstitutionRecords(glyphIndex);
			if (ligatureSubstitutionRecords != null)
			{
				AddLigatureSubstitutionRecords(ligatureSubstitutionRecords);
			}
		}

		internal void UpdateLigatureSubstitutionRecords()
		{
			LigatureSubstitutionRecord[] ligatureSubstitutionRecords = FontEngine.GetLigatureSubstitutionRecords(m_GlyphIndexListNewlyAdded);
			if (ligatureSubstitutionRecords != null)
			{
				AddLigatureSubstitutionRecords(ligatureSubstitutionRecords);
			}
		}

		private void AddLigatureSubstitutionRecords(LigatureSubstitutionRecord[] records)
		{
			Dictionary<uint, List<LigatureSubstitutionRecord>> ligatureSubstitutionRecordLookup = m_FontFeatureTable.m_LigatureSubstitutionRecordLookup;
			List<LigatureSubstitutionRecord> ligatureSubstitutionRecords = m_FontFeatureTable.m_LigatureSubstitutionRecords;
			EnsureAdditionalCapacity(ligatureSubstitutionRecordLookup, records.Length);
			EnsureAdditionalCapacity(ligatureSubstitutionRecords, records.Length);
			for (int i = 0; i < records.Length; i++)
			{
				LigatureSubstitutionRecord ligatureSubstitutionRecord = records[i];
				if (ligatureSubstitutionRecord.componentGlyphIDs == null || ligatureSubstitutionRecord.ligatureGlyphID == 0)
				{
					break;
				}
				uint key = ligatureSubstitutionRecord.componentGlyphIDs[0];
				LigatureSubstitutionRecord ligatureSubstitutionRecord2 = new LigatureSubstitutionRecord
				{
					componentGlyphIDs = ligatureSubstitutionRecord.componentGlyphIDs,
					ligatureGlyphID = ligatureSubstitutionRecord.ligatureGlyphID
				};
				if (ligatureSubstitutionRecordLookup.TryGetValue(key, out var value))
				{
					foreach (LigatureSubstitutionRecord item in value)
					{
						if (ligatureSubstitutionRecord2 == item)
						{
							return;
						}
					}
					ligatureSubstitutionRecordLookup[key].Add(ligatureSubstitutionRecord2);
				}
				else
				{
					ligatureSubstitutionRecordLookup.Add(key, new List<LigatureSubstitutionRecord> { ligatureSubstitutionRecord2 });
				}
				ligatureSubstitutionRecords.Add(ligatureSubstitutionRecord2);
			}
		}

		internal void UpdateGlyphAdjustmentRecords()
		{
			GlyphPairAdjustmentRecord[] pairAdjustmentRecords = FontEngine.GetPairAdjustmentRecords(m_GlyphIndexListNewlyAdded);
			if (pairAdjustmentRecords != null)
			{
				AddPairAdjustmentRecords(pairAdjustmentRecords);
			}
		}

		private void AddPairAdjustmentRecords(GlyphPairAdjustmentRecord[] records)
		{
			float num = m_FaceInfo.pointSize / (float)m_FaceInfo.unitsPerEM;
			List<GlyphPairAdjustmentRecord> glyphPairAdjustmentRecords = m_FontFeatureTable.glyphPairAdjustmentRecords;
			Dictionary<uint, GlyphPairAdjustmentRecord> glyphPairAdjustmentRecordLookup = m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup;
			EnsureAdditionalCapacity(glyphPairAdjustmentRecordLookup, records.Length);
			EnsureAdditionalCapacity(glyphPairAdjustmentRecords, records.Length);
			for (int i = 0; i < records.Length; i++)
			{
				GlyphPairAdjustmentRecord glyphPairAdjustmentRecord = records[i];
				GlyphAdjustmentRecord firstAdjustmentRecord = glyphPairAdjustmentRecord.firstAdjustmentRecord;
				GlyphAdjustmentRecord secondAdjustmentRecord = glyphPairAdjustmentRecord.secondAdjustmentRecord;
				uint glyphIndex = firstAdjustmentRecord.glyphIndex;
				uint glyphIndex2 = secondAdjustmentRecord.glyphIndex;
				if (glyphIndex == 0 && glyphIndex2 == 0)
				{
					break;
				}
				uint key = (glyphIndex2 << 16) | glyphIndex;
				GlyphPairAdjustmentRecord glyphPairAdjustmentRecord2 = glyphPairAdjustmentRecord;
				GlyphValueRecord glyphValueRecord = firstAdjustmentRecord.glyphValueRecord;
				glyphValueRecord.xAdvance *= num;
				glyphPairAdjustmentRecord2.firstAdjustmentRecord = new GlyphAdjustmentRecord(glyphIndex, glyphValueRecord);
				if (glyphPairAdjustmentRecordLookup.TryAdd(key, glyphPairAdjustmentRecord2))
				{
					glyphPairAdjustmentRecords.Add(glyphPairAdjustmentRecord2);
				}
			}
		}

		internal void UpdateDiacriticalMarkAdjustmentRecords()
		{
			using (k_UpdateDiacriticalMarkAdjustmentRecordsMarker.Auto())
			{
				MarkToBaseAdjustmentRecord[] markToBaseAdjustmentRecords = FontEngine.GetMarkToBaseAdjustmentRecords(m_GlyphIndexListNewlyAdded);
				if (markToBaseAdjustmentRecords != null)
				{
					AddMarkToBaseAdjustmentRecords(markToBaseAdjustmentRecords);
				}
				MarkToMarkAdjustmentRecord[] markToMarkAdjustmentRecords = FontEngine.GetMarkToMarkAdjustmentRecords(m_GlyphIndexListNewlyAdded);
				if (markToMarkAdjustmentRecords != null)
				{
					AddMarkToMarkAdjustmentRecords(markToMarkAdjustmentRecords);
				}
			}
		}

		private void AddMarkToBaseAdjustmentRecords(MarkToBaseAdjustmentRecord[] records)
		{
			float num = m_FaceInfo.pointSize / (float)m_FaceInfo.unitsPerEM;
			for (int i = 0; i < records.Length; i++)
			{
				MarkToBaseAdjustmentRecord markToBaseAdjustmentRecord = records[i];
				if (markToBaseAdjustmentRecord.baseGlyphID == 0 || markToBaseAdjustmentRecord.markGlyphID == 0)
				{
					break;
				}
				uint key = (markToBaseAdjustmentRecord.markGlyphID << 16) | markToBaseAdjustmentRecord.baseGlyphID;
				if (!m_FontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.ContainsKey(key))
				{
					MarkToBaseAdjustmentRecord markToBaseAdjustmentRecord2 = new MarkToBaseAdjustmentRecord
					{
						baseGlyphID = markToBaseAdjustmentRecord.baseGlyphID,
						baseGlyphAnchorPoint = new GlyphAnchorPoint
						{
							xCoordinate = markToBaseAdjustmentRecord.baseGlyphAnchorPoint.xCoordinate * num,
							yCoordinate = markToBaseAdjustmentRecord.baseGlyphAnchorPoint.yCoordinate * num
						},
						markGlyphID = markToBaseAdjustmentRecord.markGlyphID,
						markPositionAdjustment = new MarkPositionAdjustment
						{
							xPositionAdjustment = markToBaseAdjustmentRecord.markPositionAdjustment.xPositionAdjustment * num,
							yPositionAdjustment = markToBaseAdjustmentRecord.markPositionAdjustment.yPositionAdjustment * num
						}
					};
					m_FontFeatureTable.MarkToBaseAdjustmentRecords.Add(markToBaseAdjustmentRecord2);
					m_FontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.Add(key, markToBaseAdjustmentRecord2);
				}
			}
		}

		private void AddMarkToMarkAdjustmentRecords(MarkToMarkAdjustmentRecord[] records)
		{
			float num = m_FaceInfo.pointSize / (float)m_FaceInfo.unitsPerEM;
			for (int i = 0; i < records.Length; i++)
			{
				MarkToMarkAdjustmentRecord markToMarkAdjustmentRecord = records[i];
				if (records[i].baseMarkGlyphID == 0 || records[i].combiningMarkGlyphID == 0)
				{
					break;
				}
				uint key = (markToMarkAdjustmentRecord.combiningMarkGlyphID << 16) | markToMarkAdjustmentRecord.baseMarkGlyphID;
				if (!m_FontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.ContainsKey(key))
				{
					MarkToMarkAdjustmentRecord markToMarkAdjustmentRecord2 = new MarkToMarkAdjustmentRecord
					{
						baseMarkGlyphID = markToMarkAdjustmentRecord.baseMarkGlyphID,
						baseMarkGlyphAnchorPoint = new GlyphAnchorPoint
						{
							xCoordinate = markToMarkAdjustmentRecord.baseMarkGlyphAnchorPoint.xCoordinate * num,
							yCoordinate = markToMarkAdjustmentRecord.baseMarkGlyphAnchorPoint.yCoordinate * num
						},
						combiningMarkGlyphID = markToMarkAdjustmentRecord.combiningMarkGlyphID,
						combiningMarkPositionAdjustment = new MarkPositionAdjustment
						{
							xPositionAdjustment = markToMarkAdjustmentRecord.combiningMarkPositionAdjustment.xPositionAdjustment * num,
							yPositionAdjustment = markToMarkAdjustmentRecord.combiningMarkPositionAdjustment.yPositionAdjustment * num
						}
					};
					m_FontFeatureTable.MarkToMarkAdjustmentRecords.Add(markToMarkAdjustmentRecord2);
					m_FontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.Add(key, markToMarkAdjustmentRecord2);
				}
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal void EnsureNativeFontAssetIsCreated()
		{
			if (!(m_NativeFontAsset != IntPtr.Zero))
			{
				IntPtr[] fallbacks = GetFallbacks();
				(IntPtr[], IntPtr[]) weightFallbacks = GetWeightFallbacks();
				kFontAssetByInstanceId.TryAdd(base.instanceID, this);
				Font sourceFont_EditorRef = null;
				m_NativeFontAsset = Create(faceInfo, sourceFontFile, sourceFont_EditorRef, m_SourceFontFilePath, base.instanceID, fallbacks, weightFallbacks.Item1, weightFallbacks.Item2);
			}
		}

		internal void UpdateFallbacks()
		{
			UpdateFallbacks(nativeFontAsset, GetFallbacks());
		}

		internal void UpdateWeightFallbacks()
		{
			(IntPtr[], IntPtr[]) weightFallbacks = GetWeightFallbacks();
			UpdateWeightFallbacks(nativeFontAsset, weightFallbacks.Item1, weightFallbacks.Item2);
		}

		internal void UpdateFaceInfo()
		{
			UpdateFaceInfo(nativeFontAsset, faceInfo);
		}

		internal IntPtr[] GetFallbacks()
		{
			List<IntPtr> list = new List<IntPtr>();
			if (fallbackFontAssetTable == null)
			{
				return list.ToArray();
			}
			foreach (FontAsset item in fallbackFontAssetTable)
			{
				if (!(item == null))
				{
					if (item.atlasPopulationMode == AtlasPopulationMode.Static && item.characterTable.Count > 0)
					{
						Debug.LogWarning("Advanced text system cannot use static font asset " + item.name + " as fallback.");
					}
					else if (HasRecursion(item))
					{
						Debug.LogWarning("Circular reference detected. Cannot add " + item.name + " to the fallbacks.");
					}
					else
					{
						list.Add(item.nativeFontAsset);
					}
				}
			}
			return list.ToArray();
		}

		private bool HasRecursion(FontAsset fontAsset)
		{
			visitedFontAssets.Clear();
			return HasRecursionInternal(fontAsset);
		}

		private bool HasRecursionInternal(FontAsset fontAsset)
		{
			if (visitedFontAssets.Contains(fontAsset.instanceID))
			{
				return true;
			}
			visitedFontAssets.Add(fontAsset.instanceID);
			if (fontAsset.fallbackFontAssetTable != null)
			{
				foreach (FontAsset item in fontAsset.fallbackFontAssetTable)
				{
					if (HasRecursionInternal(item))
					{
						return true;
					}
				}
			}
			for (int i = 0; i < fontAsset.fontWeightTable.Length; i++)
			{
				FontWeightPair fontWeightPair = fontAsset.fontWeightTable[i];
				if (fontWeightPair.regularTypeface != null && HasRecursionInternal(fontWeightPair.regularTypeface))
				{
					return true;
				}
				if (fontWeightPair.italicTypeface != null && HasRecursionInternal(fontWeightPair.italicTypeface))
				{
					return true;
				}
			}
			visitedFontAssets.Remove(fontAsset.instanceID);
			return false;
		}

		private (IntPtr[], IntPtr[]) GetWeightFallbacks()
		{
			IntPtr[] array = new IntPtr[10];
			IntPtr[] array2 = new IntPtr[10];
			for (int i = 0; i < fontWeightTable.Length; i++)
			{
				FontWeightPair fontWeightPair = fontWeightTable[i];
				if (fontWeightPair.regularTypeface != null)
				{
					if (fontWeightPair.regularTypeface.atlasPopulationMode == AtlasPopulationMode.Static && fontWeightPair.regularTypeface.characterTable.Count > 0)
					{
						Debug.LogWarning("Advanced text system cannot use static font asset " + fontWeightPair.regularTypeface.name + " as fallback.");
						continue;
					}
					if (HasRecursion(fontWeightPair.regularTypeface))
					{
						Debug.LogWarning("Circular reference detected. Cannot add " + fontWeightPair.regularTypeface.name + " to the fallbacks.");
						continue;
					}
					array[i] = fontWeightPair.regularTypeface.nativeFontAsset;
				}
				if (fontWeightPair.italicTypeface != null)
				{
					if (fontWeightPair.italicTypeface.atlasPopulationMode == AtlasPopulationMode.Static && fontWeightPair.italicTypeface.characterTable.Count > 0)
					{
						Debug.LogWarning("Advanced text system cannot use static font asset " + fontWeightPair.italicTypeface.name + " as fallback.");
					}
					else if (HasRecursion(fontWeightPair.italicTypeface))
					{
						Debug.LogWarning("Circular reference detected. Cannot add " + fontWeightPair.italicTypeface.name + " to the fallbacks.");
					}
					else
					{
						array2[i] = fontWeightPair.italicTypeface.nativeFontAsset;
					}
				}
			}
			return (array, array2);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static extern void CreateHbFaceIfNeeded();

		private unsafe static void UpdateFallbacks(IntPtr ptr, IntPtr[] fallbacks)
		{
			Span<IntPtr> span = new Span<IntPtr>(fallbacks);
			fixed (IntPtr* begin = span)
			{
				ManagedSpanWrapper fallbacks2 = new ManagedSpanWrapper(begin, span.Length);
				UpdateFallbacks_Injected(ptr, ref fallbacks2);
			}
		}

		private unsafe static void UpdateWeightFallbacks(IntPtr ptr, IntPtr[] regularFallbacks, IntPtr[] italicFallbacks)
		{
			Span<IntPtr> span = new Span<IntPtr>(regularFallbacks);
			fixed (IntPtr* begin = span)
			{
				ManagedSpanWrapper regularFallbacks2 = new ManagedSpanWrapper(begin, span.Length);
				Span<IntPtr> span2 = new Span<IntPtr>(italicFallbacks);
				fixed (IntPtr* begin2 = span2)
				{
					ManagedSpanWrapper italicFallbacks2 = new ManagedSpanWrapper(begin2, span2.Length);
					UpdateWeightFallbacks_Injected(ptr, ref regularFallbacks2, ref italicFallbacks2);
				}
			}
		}

		private unsafe static IntPtr Create(FaceInfo faceInfo, Font sourceFontFile, Font sourceFont_EditorRef, string sourceFontFilePath, int fontInstanceID, IntPtr[] fallbacks, IntPtr[] weightFallbacks, IntPtr[] italicFallbacks)
		{
			//The blocks IL_0037, IL_004c, IL_005a, IL_0072, IL_0080, IL_0098, IL_00a6 are reachable both inside and outside the pinned region starting at IL_0026. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			try
			{
				IntPtr intPtr = MarshalledUnityObject.Marshal(sourceFontFile);
				IntPtr sourceFont_EditorRef2 = MarshalledUnityObject.Marshal(sourceFont_EditorRef);
				ManagedSpanWrapper managedSpanWrapper = default(ManagedSpanWrapper);
				ref ManagedSpanWrapper sourceFontFilePath2;
				int fontInstanceID2;
				Span<IntPtr> span;
				ManagedSpanWrapper managedSpanWrapper2;
				ref ManagedSpanWrapper fallbacks2;
				Span<IntPtr> span2;
				ManagedSpanWrapper managedSpanWrapper3;
				ref ManagedSpanWrapper weightFallbacks2;
				Span<IntPtr> span3;
				ManagedSpanWrapper italicFallbacks2;
				if (!StringMarshaller.TryMarshalEmptyOrNullString(sourceFontFilePath, ref managedSpanWrapper))
				{
					ReadOnlySpan<char> readOnlySpan = MemoryExtensions.AsSpan(sourceFontFilePath);
					fixed (char* begin = readOnlySpan)
					{
						managedSpanWrapper = new ManagedSpanWrapper(begin, readOnlySpan.Length);
						sourceFontFilePath2 = ref managedSpanWrapper;
						fontInstanceID2 = fontInstanceID;
						span = new Span<IntPtr>(fallbacks);
						fixed (IntPtr* begin2 = span)
						{
							managedSpanWrapper2 = new ManagedSpanWrapper(begin2, span.Length);
							fallbacks2 = ref managedSpanWrapper2;
							span2 = new Span<IntPtr>(weightFallbacks);
							fixed (IntPtr* begin3 = span2)
							{
								managedSpanWrapper3 = new ManagedSpanWrapper(begin3, span2.Length);
								weightFallbacks2 = ref managedSpanWrapper3;
								span3 = new Span<IntPtr>(italicFallbacks);
								fixed (IntPtr* begin4 = span3)
								{
									italicFallbacks2 = new ManagedSpanWrapper(begin4, span3.Length);
									return Create_Injected(ref faceInfo, intPtr, sourceFont_EditorRef2, ref sourceFontFilePath2, fontInstanceID2, ref fallbacks2, ref weightFallbacks2, ref italicFallbacks2);
								}
							}
						}
					}
				}
				sourceFontFilePath2 = ref managedSpanWrapper;
				fontInstanceID2 = fontInstanceID;
				span = new Span<IntPtr>(fallbacks);
				fixed (IntPtr* begin2 = span)
				{
					managedSpanWrapper2 = new ManagedSpanWrapper(begin2, span.Length);
					fallbacks2 = ref managedSpanWrapper2;
					span2 = new Span<IntPtr>(weightFallbacks);
					fixed (IntPtr* begin3 = span2)
					{
						managedSpanWrapper3 = new ManagedSpanWrapper(begin3, span2.Length);
						weightFallbacks2 = ref managedSpanWrapper3;
						span3 = new Span<IntPtr>(italicFallbacks);
						fixed (IntPtr* begin4 = span3)
						{
							italicFallbacks2 = new ManagedSpanWrapper(begin4, span3.Length);
							return Create_Injected(ref faceInfo, intPtr, sourceFont_EditorRef2, ref sourceFontFilePath2, fontInstanceID2, ref fallbacks2, ref weightFallbacks2, ref italicFallbacks2);
						}
					}
				}
			}
			finally
			{
			}
		}

		private static void UpdateFaceInfo(IntPtr ptr, FaceInfo faceInfo)
		{
			UpdateFaceInfo_Injected(ptr, ref faceInfo);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[FreeFunction("FontAsset::Destroy")]
		private static extern void Destroy(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UpdateFallbacks_Injected(IntPtr ptr, ref ManagedSpanWrapper fallbacks);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UpdateWeightFallbacks_Injected(IntPtr ptr, ref ManagedSpanWrapper regularFallbacks, ref ManagedSpanWrapper italicFallbacks);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create_Injected([In] ref FaceInfo faceInfo, IntPtr sourceFontFile, IntPtr sourceFont_EditorRef, ref ManagedSpanWrapper sourceFontFilePath, int fontInstanceID, ref ManagedSpanWrapper fallbacks, ref ManagedSpanWrapper weightFallbacks, ref ManagedSpanWrapper italicFallbacks);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UpdateFaceInfo_Injected(IntPtr ptr, [In] ref FaceInfo faceInfo);
	}
	internal class FontAssetFactory
	{
		internal const GlyphRenderMode k_SmoothEditorBitmapGlyphRenderMode = GlyphRenderMode.SMOOTH_HINTED;

		internal const GlyphRenderMode k_RasterEditorBitmapGlyphRenderMode = GlyphRenderMode.RASTER_HINTED;

		private static readonly HashSet<FontAsset> visitedFontAssets = new HashSet<FontAsset>();

		public static FontAsset? CloneFontAssetWithBitmapRendering(FontAsset baseFontAsset, int fontSize, bool isRaster)
		{
			visitedFontAssets.Clear();
			return CloneFontAssetWithBitmapRenderingInternal(baseFontAsset, fontSize, isRaster);
		}

		private static FontAsset? CloneFontAssetWithBitmapRenderingInternal(FontAsset baseFontAsset, int fontSize, bool isRaster)
		{
			visitedFontAssets.Add(baseFontAsset);
			FontAsset fontAsset = CloneFontAssetWithBitmapSettings(baseFontAsset, fontSize, isRaster);
			if (fontAsset != null)
			{
				ProcessFontWeights(fontAsset, baseFontAsset, fontSize, isRaster);
				ProcessFallbackFonts(fontAsset, baseFontAsset, fontSize, isRaster);
			}
			return fontAsset;
		}

		private static FontAsset? CloneFontAssetWithBitmapSettings(FontAsset source, int size, bool isRaster)
		{
			bool flag = source.atlasRenderMode != GlyphRenderMode.SDFAA || !source.IsEditorFont || source.sourceFontFile == null;
			FontAsset fontAsset;
			if (source.atlasPopulationMode == AtlasPopulationMode.DynamicOS)
			{
				fontAsset = FontAsset.CreateFontAsset(source.faceInfo.familyName, source.faceInfo.styleName, size, 6, isRaster ? GlyphRenderMode.RASTER_HINTED : GlyphRenderMode.SMOOTH_HINTED);
				if (fontAsset != null)
				{
					SetupFontAssetForBitmapSettings(fontAsset);
				}
			}
			else if (flag)
			{
				fontAsset = Object.Instantiate(source);
				if (fontAsset != null)
				{
					fontAsset.fallbackFontAssetTable = new List<FontAsset>();
					fontAsset.m_IsClone = true;
					fontAsset.IsEditorFont = true;
					SetHideFlags(fontAsset);
				}
			}
			else
			{
				fontAsset = FontAsset.CreateFontAsset(source.sourceFontFile, size, 6, isRaster ? GlyphRenderMode.RASTER_HINTED : GlyphRenderMode.SMOOTH_HINTED, source.atlasWidth, source.atlasHeight);
				if (fontAsset != null)
				{
					SetupFontAssetForBitmapSettings(fontAsset);
				}
			}
			return fontAsset;
		}

		private static void ProcessFontWeights(FontAsset resultFontAsset, FontAsset baseFontAsset, int fontSize, bool isRaster)
		{
			for (int i = 0; i < baseFontAsset.fontWeightTable.Length; i++)
			{
				FontWeightPair fontWeightPair = baseFontAsset.fontWeightTable[i];
				if (fontWeightPair.regularTypeface != null)
				{
					resultFontAsset.fontWeightTable[i].regularTypeface = CloneFontAssetWithBitmapSettings(fontWeightPair.regularTypeface, fontSize, isRaster);
				}
				if (fontWeightPair.italicTypeface != null)
				{
					resultFontAsset.fontWeightTable[i].italicTypeface = CloneFontAssetWithBitmapSettings(fontWeightPair.italicTypeface, fontSize, isRaster);
				}
			}
		}

		private static void ProcessFallbackFonts(FontAsset resultFontAsset, FontAsset baseFontAsset, int fontSize, bool isRaster)
		{
			if (baseFontAsset.fallbackFontAssetTable == null)
			{
				return;
			}
			foreach (FontAsset item in baseFontAsset.fallbackFontAssetTable)
			{
				if (item != null && !visitedFontAssets.Contains(item))
				{
					visitedFontAssets.Add(item);
					if (resultFontAsset.fallbackFontAssetTable == null)
					{
						List<FontAsset> list = (resultFontAsset.fallbackFontAssetTable = new List<FontAsset>());
					}
					FontAsset fontAsset = CloneFontAssetWithBitmapRenderingInternal(item, fontSize, isRaster);
					if ((bool)fontAsset)
					{
						resultFontAsset.fallbackFontAssetTable.Add(fontAsset);
					}
				}
			}
		}

		internal static FontAsset? ConvertFontToFontAsset(Font font)
		{
			if (font == null)
			{
				return null;
			}
			FontAsset fontAsset = null;
			fontAsset = FontAsset.CreateFontAsset(font, 90, 9, GlyphRenderMode.DEFAULT, 1024, 1024);
			if (fontAsset != null)
			{
				SetupFontAssetSettings(fontAsset);
			}
			return fontAsset;
		}

		internal static void SetupFontAssetSettings(FontAsset fontAsset)
		{
			if ((bool)fontAsset)
			{
				SetHideFlags(fontAsset);
				fontAsset.isMultiAtlasTexturesEnabled = true;
				fontAsset.IsEditorFont = true;
			}
		}

		private static void SetupFontAssetForBitmapSettings(FontAsset fontAsset)
		{
			if ((bool)fontAsset)
			{
				SetHideFlags(fontAsset);
				fontAsset.IsEditorFont = true;
				fontAsset.isMultiAtlasTexturesEnabled = true;
				fontAsset.atlasTexture.filterMode = (TextGenerator.EnableCheckerboardPattern ? FilterMode.Bilinear : FilterMode.Point);
			}
		}

		public static void SetHideFlags(FontAsset fontAsset)
		{
			if ((bool)fontAsset)
			{
				fontAsset.hideFlags = HideFlags.DontSave;
				fontAsset.atlasTextures[0].hideFlags = HideFlags.DontSave;
				fontAsset.material.hideFlags = HideFlags.DontSave;
			}
		}
	}
	internal static class FontAssetUtilities
	{
		private static HashSet<int> k_SearchedAssets;

		internal static Character GetCharacterFromFontAsset(uint unicode, FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures)
		{
			if (includeFallbacks)
			{
				if (k_SearchedAssets == null)
				{
					k_SearchedAssets = new HashSet<int>();
				}
				else
				{
					k_SearchedAssets.Clear();
				}
			}
			return GetCharacterFromFontAsset_Internal(unicode, sourceFontAsset, includeFallbacks, fontStyle, fontWeight, out isAlternativeTypeface, populateLigatures);
		}

		private static Character GetCharacterFromFontAsset_Internal(uint unicode, FontAsset sourceFontAsset, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures)
		{
			bool flag = !TextGenerator.IsExecutingJob;
			isAlternativeTypeface = false;
			Character character = null;
			bool flag2 = (fontStyle & FontStyles.Italic) == FontStyles.Italic;
			if (flag2 || fontWeight != TextFontWeight.Regular)
			{
				if (!flag && sourceFontAsset.m_CharacterLookupDictionary == null)
				{
					return null;
				}
				if (sourceFontAsset.GetCharacterInLookupCache(unicode, fontStyle, fontWeight, out character))
				{
					if (character.textAsset != null)
					{
						return character;
					}
					if (!flag)
					{
						return null;
					}
					sourceFontAsset.RemoveCharacterInLookupCache(unicode, fontStyle, fontWeight);
				}
				FontWeightPair[] fontWeightTable = sourceFontAsset.fontWeightTable;
				int textFontWeightIndex = TextUtilities.GetTextFontWeightIndex(fontWeight);
				FontAsset fontAsset = (flag2 ? fontWeightTable[textFontWeightIndex].italicTypeface : fontWeightTable[textFontWeightIndex].regularTypeface);
				if (fontAsset != null)
				{
					if (!flag && fontAsset.m_CharacterLookupDictionary == null)
					{
						return null;
					}
					if (fontAsset.GetCharacterInLookupCache(unicode, fontStyle, fontWeight, out character))
					{
						if (character.textAsset != null)
						{
							isAlternativeTypeface = true;
							return character;
						}
						if (!flag)
						{
							return null;
						}
						fontAsset.RemoveCharacterInLookupCache(unicode, fontStyle, fontWeight);
					}
					if (fontAsset.atlasPopulationMode == AtlasPopulationMode.Dynamic || fontAsset.atlasPopulationMode == AtlasPopulationMode.DynamicOS)
					{
						if (!flag)
						{
							if (!fontAsset.m_MissingUnicodesFromFontFile.Contains(unicode))
							{
								return null;
							}
						}
						else if (fontAsset.TryAddCharacterInternal(unicode, fontStyle, fontWeight, out character, populateLigatures))
						{
							isAlternativeTypeface = true;
							return character;
						}
					}
					else if (fontAsset.GetCharacterInLookupCache(unicode, FontStyles.Normal, TextFontWeight.Regular, out character))
					{
						if (character.textAsset != null)
						{
							isAlternativeTypeface = true;
							return character;
						}
						if (!flag)
						{
							return null;
						}
						fontAsset.RemoveCharacterInLookupCache(unicode, fontStyle, fontWeight);
					}
				}
			}
			if (!flag && sourceFontAsset.m_CharacterLookupDictionary == null)
			{
				return null;
			}
			if (sourceFontAsset.GetCharacterInLookupCache(unicode, FontStyles.Normal, TextFontWeight.Regular, out character))
			{
				if (character.textAsset != null)
				{
					return character;
				}
				if (!flag)
				{
					return null;
				}
				sourceFontAsset.RemoveCharacterInLookupCache(unicode, FontStyles.Normal, TextFontWeight.Regular);
			}
			if (sourceFontAsset.atlasPopulationMode == AtlasPopulationMode.Dynamic || sourceFontAsset.atlasPopulationMode == AtlasPopulationMode.DynamicOS)
			{
				if (!flag)
				{
					return null;
				}
				if (sourceFontAsset.TryAddCharacterInternal(unicode, FontStyles.Normal, TextFontWeight.Regular, out character, populateLigatures))
				{
					return character;
				}
			}
			if (character == null && !flag)
			{
				return null;
			}
			if (character == null && includeFallbacks && sourceFontAsset.fallbackFontAssetTable != null)
			{
				List<FontAsset> fallbackFontAssetTable = sourceFontAsset.fallbackFontAssetTable;
				int count = fallbackFontAssetTable.Count;
				if (count == 0)
				{
					return null;
				}
				for (int i = 0; i < count; i++)
				{
					FontAsset fontAsset2 = fallbackFontAssetTable[i];
					if (fontAsset2 == null)
					{
						continue;
					}
					int hashCode = fontAsset2.GetHashCode();
					if (k_SearchedAssets.Add(hashCode))
					{
						character = GetCharacterFromFontAsset_Internal(unicode, fontAsset2, includeFallbacks: true, fontStyle, fontWeight, out isAlternativeTypeface, populateLigatures);
						if (character != null)
						{
							return character;
						}
					}
				}
			}
			return null;
		}

		public static Character GetCharacterFromFontAssets(uint unicode, FontAsset sourceFontAsset, List<FontAsset> fontAssets, List<FontAsset> OSFallbackList, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface)
		{
			return GetCharacterFromFontAssetsInternal(unicode, sourceFontAsset, fontAssets, OSFallbackList, includeFallbacks, fontStyle, fontWeight, out isAlternativeTypeface);
		}

		internal static Character GetCharacterFromFontAssetsInternal(uint unicode, FontAsset sourceFontAsset, List<FontAsset> fontAssets, List<FontAsset> OSFallbackList, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures = true)
		{
			isAlternativeTypeface = false;
			if (includeFallbacks)
			{
				if (k_SearchedAssets == null)
				{
					k_SearchedAssets = new HashSet<int>();
				}
				else
				{
					k_SearchedAssets.Clear();
				}
			}
			Character characterFromFontAssetsInternal = GetCharacterFromFontAssetsInternal(unicode, fontAssets, includeFallbacks, fontStyle, fontWeight, out isAlternativeTypeface, populateLigatures);
			if (characterFromFontAssetsInternal != null)
			{
				return characterFromFontAssetsInternal;
			}
			return GetCharacterFromFontAssetsInternal(unicode, OSFallbackList, includeFallbacks, fontStyle, fontWeight, out isAlternativeTypeface, populateLigatures);
		}

		private static Character GetCharacterFromFontAssetsInternal(uint unicode, List<FontAsset> fontAssets, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures = true)
		{
			isAlternativeTypeface = false;
			if (fontAssets == null || fontAssets.Count == 0)
			{
				return null;
			}
			if (includeFallbacks)
			{
				if (k_SearchedAssets == null)
				{
					k_SearchedAssets = new HashSet<int>();
				}
				else
				{
					k_SearchedAssets.Clear();
				}
			}
			int count = fontAssets.Count;
			for (int i = 0; i < count; i++)
			{
				FontAsset fontAsset = fontAssets[i];
				if (!(fontAsset == null))
				{
					Character characterFromFontAsset_Internal = GetCharacterFromFontAsset_Internal(unicode, fontAsset, includeFallbacks, fontStyle, fontWeight, out isAlternativeTypeface, populateLigatures);
					if (characterFromFontAsset_Internal != null)
					{
						return characterFromFontAsset_Internal;
					}
				}
			}
			return null;
		}

		internal static TextElement GetTextElementFromTextAssets(uint unicode, FontAsset sourceFontAsset, List<TextAsset> textAssets, bool includeFallbacks, FontStyles fontStyle, TextFontWeight fontWeight, out bool isAlternativeTypeface, bool populateLigatures)
		{
			isAlternativeTypeface = false;
			if (textAssets == null || textAssets.Count == 0)
			{
				return null;
			}
			if (includeFallbacks)
			{
				if (k_SearchedAssets == null)
				{
					k_SearchedAssets = new HashSet<int>();
				}
				else
				{
					k_SearchedAssets.Clear();
				}
			}
			int count = textAssets.Count;
			for (int i = 0; i < count; i++)
			{
				TextAsset textAsset = textAssets[i];
				if (textAsset == null)
				{
					continue;
				}
				if (textAsset.GetType() == typeof(FontAsset))
				{
					FontAsset sourceFontAsset2 = textAsset as FontAsset;
					Character characterFromFontAsset_Internal = GetCharacterFromFontAsset_Internal(unicode, sourceFontAsset2, includeFallbacks, fontStyle, fontWeight, out isAlternativeTypeface, populateLigatures);
					if (characterFromFontAsset_Internal != null)
					{
						return characterFromFontAsset_Internal;
					}
				}
				else
				{
					SpriteAsset spriteAsset = textAsset as SpriteAsset;
					SpriteCharacter spriteCharacterFromSpriteAsset_Internal = GetSpriteCharacterFromSpriteAsset_Internal(unicode, spriteAsset, includeFallbacks: true);
					if (spriteCharacterFromSpriteAsset_Internal != null)
					{
						return spriteCharacterFromSpriteAsset_Internal;
					}
				}
			}
			return null;
		}

		public static SpriteCharacter GetSpriteCharacterFromSpriteAsset(uint unicode, SpriteAsset spriteAsset, bool includeFallbacks)
		{
			bool flag = !TextGenerator.IsExecutingJob;
			if (spriteAsset == null)
			{
				return null;
			}
			if (spriteAsset.spriteCharacterLookupTable.TryGetValue(unicode, out var value))
			{
				return value;
			}
			if (includeFallbacks)
			{
				if (k_SearchedAssets == null)
				{
					k_SearchedAssets = new HashSet<int>();
				}
				else
				{
					k_SearchedAssets.Clear();
				}
				k_SearchedAssets.Add(spriteAsset.GetHashCode());
				List<SpriteAsset> fallbackSpriteAssets = spriteAsset.fallbackSpriteAssets;
				if (fallbackSpriteAssets != null && fallbackSpriteAssets.Count > 0)
				{
					int count = fallbackSpriteAssets.Count;
					for (int i = 0; i < count; i++)
					{
						SpriteAsset spriteAsset2 = fallbackSpriteAssets[i];
						if (spriteAsset2 == null)
						{
							continue;
						}
						int hashCode = spriteAsset2.GetHashCode();
						if (k_SearchedAssets.Add(hashCode))
						{
							value = GetSpriteCharacterFromSpriteAsset_Internal(unicode, spriteAsset2, includeFallbacks: true);
							if (value != null)
							{
								return value;
							}
						}
					}
				}
			}
			return null;
		}

		private static SpriteCharacter GetSpriteCharacterFromSpriteAsset_Internal(uint unicode, SpriteAsset spriteAsset, bool includeFallbacks)
		{
			if (spriteAsset.spriteCharacterLookupTable.TryGetValue(unicode, out var value))
			{
				return value;
			}
			if (includeFallbacks)
			{
				List<SpriteAsset> fallbackSpriteAssets = spriteAsset.fallbackSpriteAssets;
				if (fallbackSpriteAssets != null && fallbackSpriteAssets.Count > 0)
				{
					int count = fallbackSpriteAssets.Count;
					for (int i = 0; i < count; i++)
					{
						SpriteAsset spriteAsset2 = fallbackSpriteAssets[i];
						if (spriteAsset2 == null)
						{
							continue;
						}
						int hashCode = spriteAsset2.GetHashCode();
						if (k_SearchedAssets.Add(hashCode))
						{
							value = GetSpriteCharacterFromSpriteAsset_Internal(unicode, spriteAsset2, includeFallbacks: true);
							if (value != null)
							{
								return value;
							}
						}
					}
				}
			}
			return null;
		}

		public static uint GetCodePoint(string text, ref int index)
		{
			char c = text[index];
			if (char.IsHighSurrogate(c) && index + 1 < text.Length && char.IsLowSurrogate(text[index + 1]))
			{
				uint result = (uint)char.ConvertToUtf32(c, text[index + 1]);
				index++;
				return result;
			}
			return c;
		}

		public static uint GetCodePoint(uint[] codesPoints, ref int index)
		{
			char c = (char)codesPoints[index];
			if (char.IsHighSurrogate(c) && index + 1 < codesPoints.Length && char.IsLowSurrogate((char)codesPoints[index + 1]))
			{
				uint result = (uint)char.ConvertToUtf32(c, (char)codesPoints[index + 1]);
				index++;
				return result;
			}
			return c;
		}
	}
	[HelpURL("https://docs.unity3d.com/2023.3/Documentation/Manual/UIE-sprite.html")]
	[ExcludeFromPreset]
	public class SpriteAsset : TextAsset
	{
		internal Dictionary<int, int> m_NameLookup;

		internal Dictionary<uint, int> m_GlyphIndexLookup;

		[SerializeField]
		internal FaceInfo m_FaceInfo;

		[SerializeField]
		[FormerlySerializedAs("spriteSheet")]
		internal Texture m_SpriteAtlasTexture;

		[SerializeField]
		private List<SpriteCharacter> m_SpriteCharacterTable = new List<SpriteCharacter>();

		internal Dictionary<uint, SpriteCharacter> m_SpriteCharacterLookup;

		[SerializeField]
		private List<SpriteGlyph> m_SpriteGlyphTable = new List<SpriteGlyph>();

		internal Dictionary<uint, SpriteGlyph> m_SpriteGlyphLookup;

		[SerializeField]
		public List<SpriteAsset> fallbackSpriteAssets;

		internal bool m_IsSpriteAssetLookupTablesDirty = false;

		public FaceInfo faceInfo
		{
			get
			{
				return m_FaceInfo;
			}
			internal set
			{
				m_FaceInfo = value;
			}
		}

		public Texture spriteSheet
		{
			get
			{
				return m_SpriteAtlasTexture;
			}
			internal set
			{
				m_SpriteAtlasTexture = value;
				width = m_SpriteAtlasTexture.width;
				height = m_SpriteAtlasTexture.height;
			}
		}

		internal float width { get; private set; }

		internal float height { get; private set; }

		public List<SpriteCharacter> spriteCharacterTable
		{
			get
			{
				if (m_GlyphIndexLookup == null)
				{
					UpdateLookupTables();
				}
				return m_SpriteCharacterTable;
			}
			internal set
			{
				m_SpriteCharacterTable = value;
			}
		}

		public Dictionary<uint, SpriteCharacter> spriteCharacterLookupTable
		{
			get
			{
				if (m_SpriteCharacterLookup == null)
				{
					UpdateLookupTables();
				}
				return m_SpriteCharacterLookup;
			}
			internal set
			{
				m_SpriteCharacterLookup = value;
			}
		}

		public List<SpriteGlyph> spriteGlyphTable
		{
			get
			{
				return m_SpriteGlyphTable;
			}
			internal set
			{
				m_SpriteGlyphTable = value;
			}
		}

		private void Awake()
		{
		}

		public void UpdateLookupTables()
		{
			width = m_SpriteAtlasTexture.width;
			height = m_SpriteAtlasTexture.height;
			if (m_GlyphIndexLookup == null)
			{
				m_GlyphIndexLookup = new Dictionary<uint, int>();
			}
			else
			{
				m_GlyphIndexLookup.Clear();
			}
			if (m_SpriteGlyphLookup == null)
			{
				m_SpriteGlyphLookup = new Dictionary<uint, SpriteGlyph>();
			}
			else
			{
				m_SpriteGlyphLookup.Clear();
			}
			for (int i = 0; i < m_SpriteGlyphTable.Count; i++)
			{
				SpriteGlyph spriteGlyph = m_SpriteGlyphTable[i];
				uint index = spriteGlyph.index;
				if (!m_GlyphIndexLookup.ContainsKey(index))
				{
					m_GlyphIndexLookup.Add(index, i);
				}
				if (!m_SpriteGlyphLookup.ContainsKey(index))
				{
					m_SpriteGlyphLookup.Add(index, spriteGlyph);
				}
			}
			if (m_NameLookup == null)
			{
				m_NameLookup = new Dictionary<int, int>();
			}
			else
			{
				m_NameLookup.Clear();
			}
			if (m_SpriteCharacterLookup == null)
			{
				m_SpriteCharacterLookup = new Dictionary<uint, SpriteCharacter>();
			}
			else
			{
				m_SpriteCharacterLookup.Clear();
			}
			for (int j = 0; j < m_SpriteCharacterTable.Count; j++)
			{
				SpriteCharacter spriteCharacter = m_SpriteCharacterTable[j];
				if (spriteCharacter == null)
				{
					continue;
				}
				uint glyphIndex = spriteCharacter.glyphIndex;
				if (m_SpriteGlyphLookup.ContainsKey(glyphIndex))
				{
					spriteCharacter.glyph = m_SpriteGlyphLookup[glyphIndex];
					spriteCharacter.textAsset = this;
					int hashCodeCaseInSensitive = TextUtilities.GetHashCodeCaseInSensitive(m_SpriteCharacterTable[j].name);
					if (!m_NameLookup.ContainsKey(hashCodeCaseInSensitive))
					{
						m_NameLookup.Add(hashCodeCaseInSensitive, j);
					}
					uint unicode = m_SpriteCharacterTable[j].unicode;
					if (unicode != 65534 && !m_SpriteCharacterLookup.ContainsKey(unicode))
					{
						m_SpriteCharacterLookup.Add(unicode, spriteCharacter);
					}
				}
			}
			m_IsSpriteAssetLookupTablesDirty = false;
		}

		public int GetSpriteIndexFromHashcode(int hashCode)
		{
			if (m_NameLookup == null)
			{
				UpdateLookupTables();
			}
			if (m_NameLookup.TryGetValue(hashCode, out var value))
			{
				return value;
			}
			return -1;
		}

		public int GetSpriteIndexFromUnicode(uint unicode)
		{
			if (m_SpriteCharacterLookup == null)
			{
				UpdateLookupTables();
			}
			if (m_SpriteCharacterLookup.TryGetValue(unicode, out var value))
			{
				return (int)value.glyphIndex;
			}
			return -1;
		}

		public int GetSpriteIndexFromName(string name)
		{
			if (m_NameLookup == null)
			{
				UpdateLookupTables();
			}
			int hashCodeCaseInSensitive = TextUtilities.GetHashCodeCaseInSensitive(name);
			return GetSpriteIndexFromHashcode(hashCodeCaseInSensitive);
		}

		public static SpriteAsset SearchForSpriteByUnicode(SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, out int spriteIndex)
		{
			if (spriteAsset == null)
			{
				spriteIndex = -1;
				return null;
			}
			spriteIndex = spriteAsset.GetSpriteIndexFromUnicode(unicode);
			if (spriteIndex != -1)
			{
				return spriteAsset;
			}
			HashSet<int> hashSet = new HashSet<int>();
			int item = spriteAsset.GetInstanceID();
			hashSet.Add(item);
			if (includeFallbacks && spriteAsset.fallbackSpriteAssets != null && spriteAsset.fallbackSpriteAssets.Count > 0)
			{
				return SearchForSpriteByUnicodeInternal(spriteAsset.fallbackSpriteAssets, unicode, includeFallbacks: true, hashSet, out spriteIndex);
			}
			spriteIndex = -1;
			return null;
		}

		private static SpriteAsset SearchForSpriteByUnicodeInternal(List<SpriteAsset> spriteAssets, uint unicode, bool includeFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex)
		{
			for (int i = 0; i < spriteAssets.Count; i++)
			{
				SpriteAsset spriteAsset = spriteAssets[i];
				if (spriteAsset == null)
				{
					continue;
				}
				int item = spriteAsset.GetInstanceID();
				if (searchedSpriteAssets.Add(item))
				{
					spriteAsset = SearchForSpriteByUnicodeInternal(spriteAsset, unicode, includeFallbacks, searchedSpriteAssets, out spriteIndex);
					if (spriteAsset != null)
					{
						return spriteAsset;
					}
				}
			}
			spriteIndex = -1;
			return null;
		}

		private static SpriteAsset SearchForSpriteByUnicodeInternal(SpriteAsset spriteAsset, uint unicode, bool includeFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex)
		{
			spriteIndex = spriteAsset.GetSpriteIndexFromUnicode(unicode);
			if (spriteIndex != -1)
			{
				return spriteAsset;
			}
			if (includeFallbacks && spriteAsset.fallbackSpriteAssets != null && spriteAsset.fallbackSpriteAssets.Count > 0)
			{
				return SearchForSpriteByUnicodeInternal(spriteAsset.fallbackSpriteAssets, unicode, includeFallbacks: true, searchedSpriteAssets, out spriteIndex);
			}
			spriteIndex = -1;
			return null;
		}

		public static SpriteAsset SearchForSpriteByHashCode(SpriteAsset spriteAsset, int hashCode, bool includeFallbacks, out int spriteIndex, TextSettings textSettings = null)
		{
			if (spriteAsset == null)
			{
				spriteIndex = -1;
				return null;
			}
			spriteIndex = spriteAsset.GetSpriteIndexFromHashcode(hashCode);
			if (spriteIndex != -1)
			{
				return spriteAsset;
			}
			HashSet<int> hashSet = new HashSet<int>();
			int item = spriteAsset.GetHashCode();
			hashSet.Add(item);
			if (includeFallbacks && spriteAsset.fallbackSpriteAssets != null && spriteAsset.fallbackSpriteAssets.Count > 0)
			{
				SpriteAsset result = SearchForSpriteByHashCodeInternal(spriteAsset.fallbackSpriteAssets, hashCode, searchFallbacks: true, hashSet, out spriteIndex);
				if (spriteIndex != -1)
				{
					return result;
				}
			}
			if (textSettings == null)
			{
				spriteIndex = -1;
				return null;
			}
			if (includeFallbacks && textSettings.defaultSpriteAsset != null)
			{
				SpriteAsset result = SearchForSpriteByHashCodeInternal(textSettings.defaultSpriteAsset, hashCode, searchFallbacks: true, hashSet, out spriteIndex);
				if (spriteIndex != -1)
				{
					return result;
				}
			}
			hashSet.Clear();
			uint missingSpriteCharacterUnicode = textSettings.missingSpriteCharacterUnicode;
			spriteIndex = spriteAsset.GetSpriteIndexFromUnicode(missingSpriteCharacterUnicode);
			if (spriteIndex != -1)
			{
				return spriteAsset;
			}
			hashSet.Add(item);
			if (includeFallbacks && spriteAsset.fallbackSpriteAssets != null && spriteAsset.fallbackSpriteAssets.Count > 0)
			{
				SpriteAsset result = SearchForSpriteByUnicodeInternal(spriteAsset.fallbackSpriteAssets, missingSpriteCharacterUnicode, includeFallbacks: true, hashSet, out spriteIndex);
				if (spriteIndex != -1)
				{
					return result;
				}
			}
			if (includeFallbacks && textSettings.defaultSpriteAsset != null)
			{
				SpriteAsset result = SearchForSpriteByUnicodeInternal(textSettings.defaultSpriteAsset, missingSpriteCharacterUnicode, includeFallbacks: true, hashSet, out spriteIndex);
				if (spriteIndex != -1)
				{
					return result;
				}
			}
			spriteIndex = -1;
			return null;
		}

		private static SpriteAsset SearchForSpriteByHashCodeInternal(List<SpriteAsset> spriteAssets, int hashCode, bool searchFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex)
		{
			for (int i = 0; i < spriteAssets.Count; i++)
			{
				SpriteAsset spriteAsset = spriteAssets[i];
				if (spriteAsset == null)
				{
					continue;
				}
				int item = spriteAsset.GetHashCode();
				if (searchedSpriteAssets.Add(item))
				{
					spriteAsset = SearchForSpriteByHashCodeInternal(spriteAsset, hashCode, searchFallbacks, searchedSpriteAssets, out spriteIndex);
					if (spriteAsset != null)
					{
						return spriteAsset;
					}
				}
			}
			spriteIndex = -1;
			return null;
		}

		private static SpriteAsset SearchForSpriteByHashCodeInternal(SpriteAsset spriteAsset, int hashCode, bool searchFallbacks, HashSet<int> searchedSpriteAssets, out int spriteIndex)
		{
			spriteIndex = spriteAsset.GetSpriteIndexFromHashcode(hashCode);
			if (spriteIndex != -1)
			{
				return spriteAsset;
			}
			if (searchFallbacks && spriteAsset.fallbackSpriteAssets != null && spriteAsset.fallbackSpriteAssets.Count > 0)
			{
				return SearchForSpriteByHashCodeInternal(spriteAsset.fallbackSpriteAssets, hashCode, searchFallbacks: true, searchedSpriteAssets, out spriteIndex);
			}
			spriteIndex = -1;
			return null;
		}

		public void SortGlyphTable()
		{
			if (m_SpriteGlyphTable != null && m_SpriteGlyphTable.Count != 0)
			{
				m_SpriteGlyphTable = m_SpriteGlyphTable.OrderBy((SpriteGlyph item) => item.index).ToList();
			}
		}

		internal void SortCharacterTable()
		{
			if (m_SpriteCharacterTable != null && m_SpriteCharacterTable.Count > 0)
			{
				m_SpriteCharacterTable = m_SpriteCharacterTable.OrderBy((SpriteCharacter c) => c.unicode).ToList();
			}
		}

		internal void SortGlyphAndCharacterTables()
		{
			SortGlyphTable();
			SortCharacterTable();
		}
	}
	[Serializable]
	public class SpriteCharacter : TextElement
	{
		[SerializeField]
		private string m_Name;

		public string name
		{
			get
			{
				return m_Name;
			}
			set
			{
				if (!(value == m_Name))
				{
					m_Name = value;
				}
			}
		}

		public SpriteCharacter()
		{
			m_ElementType = TextElementType.Sprite;
		}

		public SpriteCharacter(uint unicode, SpriteGlyph glyph)
		{
			m_ElementType = TextElementType.Sprite;
			base.unicode = unicode;
			base.glyphIndex = glyph.index;
			base.glyph = glyph;
			base.scale = 1f;
		}

		public SpriteCharacter(uint unicode, SpriteAsset spriteAsset, SpriteGlyph glyph)
		{
			m_ElementType = TextElementType.Sprite;
			base.unicode = unicode;
			base.textAsset = spriteAsset;
			base.glyph = glyph;
			base.glyphIndex = glyph.index;
			base.scale = 1f;
		}
	}
	[Serializable]
	public class SpriteGlyph : Glyph
	{
		public Sprite sprite;

		public SpriteGlyph()
		{
		}

		public SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex)
		{
			base.index = index;
			base.metrics = metrics;
			base.glyphRect = glyphRect;
			base.scale = scale;
			base.atlasIndex = atlasIndex;
		}

		public SpriteGlyph(uint index, GlyphMetrics metrics, GlyphRect glyphRect, float scale, int atlasIndex, Sprite sprite)
		{
			base.index = index;
			base.metrics = metrics;
			base.glyphRect = glyphRect;
			base.scale = scale;
			base.atlasIndex = atlasIndex;
			this.sprite = sprite;
		}
	}
	[Serializable]
	[ExcludeFromObjectFactory]
	public abstract class TextAsset : ScriptableObject
	{
		[SerializeField]
		internal string m_Version;

		internal int m_InstanceID;

		internal int m_HashCode;

		[SerializeField]
		[FormerlySerializedAs("material")]
		internal Material m_Material;

		internal int m_MaterialHashCode;

		public string version
		{
			get
			{
				return m_Version;
			}
			internal set
			{
				m_Version = value;
			}
		}

		public int instanceID
		{
			get
			{
				if (m_InstanceID == 0)
				{
					m_InstanceID = GetInstanceID();
				}
				return m_InstanceID;
			}
		}

		public int hashCode
		{
			get
			{
				if (m_HashCode == 0)
				{
					m_HashCode = TextUtilities.GetHashCodeCaseInSensitive(base.name);
				}
				return m_HashCode;
			}
			set
			{
				m_HashCode = value;
			}
		}

		public Material material
		{
			get
			{
				return m_Material;
			}
			set
			{
				m_Material = value;
			}
		}

		public int materialHashCode
		{
			get
			{
				if (m_MaterialHashCode == 0)
				{
					if (m_Material == null)
					{
						return 0;
					}
					m_MaterialHashCode = TextUtilities.GetHashCodeCaseInSensitive(m_Material.name);
				}
				return m_MaterialHashCode;
			}
			set
			{
				m_MaterialHashCode = value;
			}
		}
	}
	public enum ColorGradientMode
	{
		Single,
		HorizontalGradient,
		VerticalGradient,
		FourCornersGradient
	}
	[Serializable]
	[ExcludeFromPreset]
	[ExcludeFromObjectFactory]
	public class TextColorGradient : ScriptableObject
	{
		public ColorGradientMode colorMode = ColorGradientMode.FourCornersGradient;

		public Color topLeft;

		public Color topRight;

		public Color bottomLeft;

		public Color bottomRight;

		private const ColorGradientMode k_DefaultColorMode = ColorGradientMode.FourCornersGradient;

		private static readonly Color k_DefaultColor = Color.white;

		public TextColorGradient()
		{
			colorMode = ColorGradientMode.FourCornersGradient;
			topLeft = k_DefaultColor;
			topRight = k_DefaultColor;
			bottomLeft = k_DefaultColor;
			bottomRight = k_DefaultColor;
		}

		public TextColorGradient(Color color)
		{
			colorMode = ColorGradientMode.FourCornersGradient;
			topLeft = color;
			topRight = color;
			bottomLeft = color;
			bottomRight = color;
		}

		public TextColorGradient(Color color0, Color color1, Color color2, Color color3)
		{
			colorMode = ColorGradientMode.FourCornersGradient;
			topLeft = color0;
			topRight = color1;
			bottomLeft = color2;
			bottomRight = color3;
		}
	}
	[Serializable]
	[ExcludeFromObjectFactory]
	[ExcludeFromPreset]
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextSettings.h")]
	public class TextSettings : ScriptableObject
	{
		[Serializable]
		internal struct FontReferenceMap(Font font, FontAsset fontAsset)
		{
			public Font font = font;

			public FontAsset fontAsset = fontAsset;
		}

		[SerializeField]
		protected string m_Version;

		[SerializeField]
		[FormerlySerializedAs("m_defaultFontAsset")]
		protected FontAsset m_DefaultFontAsset;

		[SerializeField]
		[FormerlySerializedAs("m_defaultFontAssetPath")]
		protected string m_DefaultFontAssetPath = "Fonts & Materials/";

		[SerializeField]
		[FormerlySerializedAs("m_fallbackFontAssets")]
		protected List<FontAsset> m_FallbackFontAssets;

		private static List<FontAsset> s_FallbackOSFontAssetInternal;

		[FormerlySerializedAs("m_matchMaterialPreset")]
		[SerializeField]
		protected bool m_MatchMaterialPreset;

		[SerializeField]
		[FormerlySerializedAs("m_missingGlyphCharacter")]
		protected int m_MissingCharacterUnicode;

		[SerializeField]
		protected bool m_ClearDynamicDataOnBuild = true;

		[SerializeField]
		private bool m_EnableEmojiSupport;

		[SerializeField]
		private List<TextAsset> m_EmojiFallbackTextAssets;

		[FormerlySerializedAs("m_defaultSpriteAsset")]
		[SerializeField]
		protected SpriteAsset m_DefaultSpriteAsset;

		[FormerlySerializedAs("m_defaultSpriteAssetPath")]
		[SerializeField]
		protected string m_DefaultSpriteAssetPath = "Sprite Assets/";

		[SerializeField]
		protected List<SpriteAsset> m_FallbackSpriteAssets;

		[SerializeField]
		protected uint m_MissingSpriteCharacterUnicode;

		[SerializeField]
		[FormerlySerializedAs("m_defaultStyleSheet")]
		protected TextStyleSheet m_DefaultStyleSheet;

		[SerializeField]
		protected string m_StyleSheetsResourcePath = "Text Style Sheets/";

		[FormerlySerializedAs("m_defaultColorGradientPresetsPath")]
		[SerializeField]
		protected string m_DefaultColorGradientPresetsPath = "Text Color Gradients/";

		[SerializeField]
		protected UnicodeLineBreakingRules m_UnicodeLineBreakingRules;

		[FormerlySerializedAs("m_warningsDisabled")]
		[SerializeField]
		protected bool m_DisplayWarnings = false;

		internal Dictionary<int, FontAsset> m_FontLookup;

		internal List<FontReferenceMap> m_FontReferences = new List<FontReferenceMap>();

		private IntPtr m_NativeTextSettings = IntPtr.Zero;

		private bool m_IsNativeTextSettingsDirty = true;

		public string version
		{
			get
			{
				return m_Version;
			}
			internal set
			{
				m_Version = value;
			}
		}

		public FontAsset defaultFontAsset
		{
			get
			{
				return m_DefaultFontAsset;
			}
			set
			{
				m_DefaultFontAsset = value;
			}
		}

		public string defaultFontAssetPath
		{
			get
			{
				return m_DefaultFontAssetPath;
			}
			set
			{
				m_DefaultFontAssetPath = value;
			}
		}

		public List<FontAsset> fallbackFontAssets
		{
			get
			{
				return m_FallbackFontAssets;
			}
			set
			{
				m_FallbackFontAssets = value;
				m_IsNativeTextSettingsDirty = true;
			}
		}

		internal List<FontAsset> fallbackOSFontAssets
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
			get
			{
				if (GetStaticFallbackOSFontAsset() == null)
				{
					SetStaticFallbackOSFontAsset(GetOSFontAssetList());
				}
				return GetStaticFallbackOSFontAsset();
			}
		}

		public bool matchMaterialPreset
		{
			get
			{
				return m_MatchMaterialPreset;
			}
			set
			{
				m_MatchMaterialPreset = value;
			}
		}

		public int missingCharacterUnicode
		{
			get
			{
				return m_MissingCharacterUnicode;
			}
			set
			{
				m_MissingCharacterUnicode = value;
			}
		}

		public bool clearDynamicDataOnBuild
		{
			get
			{
				return m_ClearDynamicDataOnBuild;
			}
			set
			{
				m_ClearDynamicDataOnBuild = value;
			}
		}

		public bool enableEmojiSupport
		{
			get
			{
				return m_EnableEmojiSupport;
			}
			set
			{
				m_EnableEmojiSupport = value;
			}
		}

		public List<TextAsset> emojiFallbackTextAssets
		{
			get
			{
				return m_EmojiFallbackTextAssets;
			}
			set
			{
				m_EmojiFallbackTextAssets = value;
				m_IsNativeTextSettingsDirty = true;
			}
		}

		public SpriteAsset defaultSpriteAsset
		{
			get
			{
				return m_DefaultSpriteAsset;
			}
			set
			{
				m_DefaultSpriteAsset = value;
			}
		}

		public string defaultSpriteAssetPath
		{
			get
			{
				return m_DefaultSpriteAssetPath;
			}
			set
			{
				m_DefaultSpriteAssetPath = value;
			}
		}

		[Obsolete("The Fallback Sprite Assets list is now obsolete. Use the emojiFallbackTextAssets instead.", true)]
		public List<SpriteAsset> fallbackSpriteAssets
		{
			get
			{
				return m_FallbackSpriteAssets;
			}
			set
			{
				m_FallbackSpriteAssets = value;
			}
		}

		internal static SpriteAsset s_GlobalSpriteAsset { get; private set; }

		public uint missingSpriteCharacterUnicode
		{
			get
			{
				return m_MissingSpriteCharacterUnicode;
			}
			set
			{
				m_MissingSpriteCharacterUnicode = value;
			}
		}

		public TextStyleSheet defaultStyleSheet
		{
			get
			{
				return m_DefaultStyleSheet;
			}
			set
			{
				m_DefaultStyleSheet = value;
			}
		}

		public string styleSheetsResourcePath
		{
			get
			{
				return m_StyleSheetsResourcePath;
			}
			set
			{
				m_StyleSheetsResourcePath = value;
			}
		}

		public string defaultColorGradientPresetsPath
		{
			get
			{
				return m_DefaultColorGradientPresetsPath;
			}
			set
			{
				m_DefaultColorGradientPresetsPath = value;
			}
		}

		public UnicodeLineBreakingRules lineBreakingRules
		{
			get
			{
				if (m_UnicodeLineBreakingRules == null)
				{
					m_UnicodeLineBreakingRules = new UnicodeLineBreakingRules();
					m_UnicodeLineBreakingRules.LoadLineBreakingRules();
				}
				return m_UnicodeLineBreakingRules;
			}
			set
			{
				m_UnicodeLineBreakingRules = value;
			}
		}

		public bool displayWarnings
		{
			get
			{
				return m_DisplayWarnings;
			}
			set
			{
				m_DisplayWarnings = value;
			}
		}

		internal IntPtr nativeTextSettings
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
			get
			{
				UpdateNativeTextSettings();
				return m_NativeTextSettings;
			}
		}

		internal virtual List<FontAsset> GetStaticFallbackOSFontAsset()
		{
			return s_FallbackOSFontAssetInternal;
		}

		internal virtual void SetStaticFallbackOSFontAsset(List<FontAsset> fontAssets)
		{
			s_FallbackOSFontAssetInternal = fontAssets;
		}

		internal virtual List<FontAsset> GetFallbackFontAssets(bool isRaster, int textPixelSize = -1)
		{
			return fallbackFontAssets;
		}

		private void OnEnable()
		{
			lineBreakingRules.LoadLineBreakingRules();
			SetStaticFallbackOSFontAsset(null);
			if (s_GlobalSpriteAsset == null)
			{
				s_GlobalSpriteAsset = Resources.Load<SpriteAsset>("Sprite Assets/Default Sprite Asset");
			}
		}

		private void OnDestroy()
		{
			if (m_NativeTextSettings != IntPtr.Zero)
			{
				DestroyNativeObject(m_NativeTextSettings);
			}
		}

		protected void InitializeFontReferenceLookup()
		{
			if (m_FontReferences == null)
			{
				m_FontReferences = new List<FontReferenceMap>();
			}
			for (int i = 0; i < m_FontReferences.Count; i++)
			{
				FontReferenceMap fontReferenceMap = m_FontReferences[i];
				if (fontReferenceMap.font == null || fontReferenceMap.fontAsset == null)
				{
					Debug.LogWarning("Deleting invalid font reference.");
					m_FontReferences.RemoveAt(i);
					i--;
					continue;
				}
				int hashCode = fontReferenceMap.font.GetHashCode();
				if (!m_FontLookup.ContainsKey(hashCode))
				{
					m_FontLookup.Add(hashCode, fontReferenceMap.fontAsset);
				}
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal FontAsset GetCachedFontAsset(Font font)
		{
			if (font == null)
			{
				return null;
			}
			if (m_FontLookup == null)
			{
				m_FontLookup = new Dictionary<int, FontAsset>();
				InitializeFontReferenceLookup();
			}
			int hashCode = font.GetHashCode();
			if (m_FontLookup.ContainsKey(hashCode))
			{
				return m_FontLookup[hashCode];
			}
			if (TextGenerator.IsExecutingJob)
			{
				return null;
			}
			FontAsset fontAsset = FontAssetFactory.ConvertFontToFontAsset(font);
			if (fontAsset != null)
			{
				m_FontReferences.Add(new FontReferenceMap(font, fontAsset));
				m_FontLookup.Add(hashCode, fontAsset);
			}
			return fontAsset;
		}

		private List<FontAsset> GetOSFontAssetList()
		{
			string[] oSFallbacks = Font.GetOSFallbacks();
			return FontAsset.CreateFontAssetOSFallbackList(oSFallbacks);
		}

		[NativeMethod(Name = "TextSettings::Create")]
		private unsafe static IntPtr CreateNativeObject(IntPtr[] fallbacks)
		{
			Span<IntPtr> span = new Span<IntPtr>(fallbacks);
			IntPtr result;
			fixed (IntPtr* begin = span)
			{
				ManagedSpanWrapper fallbacks2 = new ManagedSpanWrapper(begin, span.Length);
				result = CreateNativeObject_Injected(ref fallbacks2);
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSettings::Destroy")]
		private static extern void DestroyNativeObject(IntPtr m_NativeTextSettings);

		private unsafe static void UpdateFallbacks(IntPtr ptr, IntPtr[] fallbacks)
		{
			Span<IntPtr> span = new Span<IntPtr>(fallbacks);
			fixed (IntPtr* begin = span)
			{
				ManagedSpanWrapper fallbacks2 = new ManagedSpanWrapper(begin, span.Length);
				UpdateFallbacks_Injected(ptr, ref fallbacks2);
			}
		}

		private IntPtr[] GetGlobalFallbacks()
		{
			List<IntPtr> globalFontAssetFallbacks = new List<IntPtr>();
			fallbackFontAssets?.ForEach(delegate(FontAsset fallback)
			{
				if (!(fallback == null))
				{
					if (fallback.atlasPopulationMode == AtlasPopulationMode.Static && fallback.characterTable.Count > 0)
					{
						Debug.LogWarning("Advanced text system cannot use static font asset " + fallback.name + " as fallback.");
					}
					else
					{
						globalFontAssetFallbacks.Add(fallback.nativeFontAsset);
					}
				}
			});
			fallbackOSFontAssets?.ForEach(delegate(FontAsset fallback)
			{
				if (!(fallback == null))
				{
					if (fallback.atlasPopulationMode == AtlasPopulationMode.Static && fallback.characterTable.Count > 0)
					{
						Debug.LogWarning("Advanced text system cannot use static font asset " + fallback.name + " as fallback.");
					}
					else
					{
						globalFontAssetFallbacks.Add(fallback.nativeFontAsset);
					}
				}
			});
			emojiFallbackTextAssets?.ForEach(delegate(TextAsset fallback)
			{
				if (fallback is FontAsset fontAsset && !(fontAsset == null))
				{
					if (fontAsset.atlasPopulationMode == AtlasPopulationMode.Static && fontAsset.characterTable.Count > 0)
					{
						Debug.LogWarning("Advanced text system cannot use static font asset " + fallback.name + " as fallback.");
					}
					else
					{
						globalFontAssetFallbacks.Add(fontAsset.nativeFontAsset);
					}
				}
			});
			return globalFontAssetFallbacks.ToArray();
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal void UpdateNativeTextSettings()
		{
			if (m_NativeTextSettings == IntPtr.Zero)
			{
				m_NativeTextSettings = CreateNativeObject(GetGlobalFallbacks());
				m_IsNativeTextSettingsDirty = false;
			}
			else if (m_IsNativeTextSettingsDirty && m_NativeTextSettings != IntPtr.Zero)
			{
				UpdateFallbacks(m_NativeTextSettings, GetGlobalFallbacks());
				m_IsNativeTextSettingsDirty = false;
			}
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreateNativeObject_Injected(ref ManagedSpanWrapper fallbacks);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UpdateFallbacks_Injected(IntPtr ptr, ref ManagedSpanWrapper fallbacks);
	}
	[Serializable]
	public class TextStyle
	{
		internal static TextStyle k_NormalStyle;

		[SerializeField]
		private string m_Name;

		[SerializeField]
		private int m_HashCode;

		[SerializeField]
		private string m_OpeningDefinition;

		[SerializeField]
		private string m_ClosingDefinition;

		[SerializeField]
		private uint[] m_OpeningTagArray;

		[SerializeField]
		private uint[] m_ClosingTagArray;

		[SerializeField]
		internal uint[] m_OpeningTagUnicodeArray;

		[SerializeField]
		internal uint[] m_ClosingTagUnicodeArray;

		public static TextStyle NormalStyle
		{
			get
			{
				if (k_NormalStyle == null)
				{
					k_NormalStyle = new TextStyle("Normal", string.Empty, string.Empty);
				}
				return k_NormalStyle;
			}
		}

		public string name
		{
			get
			{
				return m_Name;
			}
			set
			{
				if (value != m_Name)
				{
					m_Name = value;
				}
			}
		}

		public int hashCode
		{
			get
			{
				return m_HashCode;
			}
			set
			{
				if (value != m_HashCode)
				{
					m_HashCode = value;
				}
			}
		}

		public string styleOpeningDefinition => m_OpeningDefinition;

		public string styleClosingDefinition => m_ClosingDefinition;

		public uint[] styleOpeningTagArray => m_OpeningTagArray;

		public uint[] styleClosingTagArray => m_ClosingTagArray;

		internal TextStyle(string styleName, string styleOpeningDefinition, string styleClosingDefinition)
		{
			m_Name = styleName;
			m_HashCode = TextUtilities.GetHashCodeCaseInSensitive(styleName);
			m_OpeningDefinition = styleOpeningDefinition;
			m_ClosingDefinition = styleClosingDefinition;
			RefreshStyle();
		}

		public void RefreshStyle()
		{
			m_HashCode = TextUtilities.GetHashCodeCaseInSensitive(m_Name);
			int length = m_OpeningDefinition.Length;
			m_OpeningTagArray = new uint[length];
			m_OpeningTagUnicodeArray = new uint[length];
			for (int i = 0; i < length; i++)
			{
				m_OpeningTagArray[i] = m_OpeningDefinition[i];
				m_OpeningTagUnicodeArray[i] = m_OpeningDefinition[i];
			}
			int length2 = m_ClosingDefinition.Length;
			m_ClosingTagArray = new uint[length2];
			m_ClosingTagUnicodeArray = new uint[length2];
			for (int j = 0; j < length2; j++)
			{
				m_ClosingTagArray[j] = m_ClosingDefinition[j];
				m_ClosingTagUnicodeArray[j] = m_ClosingDefinition[j];
			}
		}
	}
	[Serializable]
	[ExcludeFromPreset]
	[ExcludeFromObjectFactory]
	public class TextStyleSheet : ScriptableObject
	{
		[SerializeField]
		private List<TextStyle> m_StyleList = new List<TextStyle>(1);

		private Dictionary<int, TextStyle> m_StyleLookupDictionary;

		private object styleLookupLock = new object();

		internal List<TextStyle> styles => m_StyleList;

		private void Reset()
		{
			LoadStyleDictionaryInternal();
		}

		public TextStyle GetStyle(int hashCode)
		{
			if (m_StyleLookupDictionary == null)
			{
				lock (styleLookupLock)
				{
					if (m_StyleLookupDictionary == null)
					{
						LoadStyleDictionaryInternal();
					}
				}
			}
			if (m_StyleLookupDictionary.TryGetValue(hashCode, out var value))
			{
				return value;
			}
			return null;
		}

		public TextStyle GetStyle(string name)
		{
			if (m_StyleLookupDictionary == null)
			{
				LoadStyleDictionaryInternal();
			}
			int hashCodeCaseInSensitive = TextUtilities.GetHashCodeCaseInSensitive(name);
			if (m_StyleLookupDictionary.TryGetValue(hashCodeCaseInSensitive, out var value))
			{
				return value;
			}
			return null;
		}

		public void RefreshStyles()
		{
			LoadStyleDictionaryInternal();
		}

		private void LoadStyleDictionaryInternal()
		{
			Dictionary<int, TextStyle> dictionary = m_StyleLookupDictionary;
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, TextStyle>();
			}
			else
			{
				dictionary.Clear();
			}
			for (int i = 0; i < m_StyleList.Count; i++)
			{
				m_StyleList[i].RefreshStyle();
				if (!dictionary.ContainsKey(m_StyleList[i].hashCode))
				{
					dictionary.Add(m_StyleList[i].hashCode, m_StyleList[i]);
				}
			}
			int hashCodeCaseInSensitive = TextUtilities.GetHashCodeCaseInSensitive("Normal");
			if (!dictionary.ContainsKey(hashCodeCaseInSensitive))
			{
				TextStyle textStyle = new TextStyle("Normal", string.Empty, string.Empty);
				m_StyleList.Add(textStyle);
				dictionary.Add(hashCodeCaseInSensitive, textStyle);
			}
			m_StyleLookupDictionary = dictionary;
		}
	}
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextCoreVertex.h")]
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	[UsedByNativeCode("TextCoreVertex")]
	internal struct TextCoreVertex
	{
		public Vector3 position;

		public Color32 color;

		public Vector2 uv0;

		public Vector2 uv2;
	}
	public enum TextElementType : byte
	{
		Character = 1,
		Sprite
	}
	[Serializable]
	public abstract class TextElement
	{
		[SerializeField]
		protected TextElementType m_ElementType;

		[SerializeField]
		internal uint m_Unicode;

		internal TextAsset m_TextAsset;

		internal Glyph m_Glyph;

		[SerializeField]
		internal uint m_GlyphIndex;

		[SerializeField]
		internal float m_Scale;

		public TextElementType elementType => m_ElementType;

		public uint unicode
		{
			get
			{
				return m_Unicode;
			}
			set
			{
				m_Unicode = value;
			}
		}

		public TextAsset textAsset
		{
			get
			{
				return m_TextAsset;
			}
			set
			{
				m_TextAsset = value;
			}
		}

		public Glyph glyph
		{
			get
			{
				return m_Glyph;
			}
			set
			{
				m_Glyph = value;
			}
		}

		public uint glyphIndex
		{
			get
			{
				return m_GlyphIndex;
			}
			set
			{
				m_GlyphIndex = value;
			}
		}

		public float scale
		{
			get
			{
				return m_Scale;
			}
			set
			{
				m_Scale = value;
			}
		}
	}
	internal struct TextVertex
	{
		public Vector3 position;

		public Vector4 uv;

		public Vector2 uv2;

		public Color32 color;
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct TextElementInfo
	{
		public uint character;

		public int index;

		public TextElementType elementType;

		public int stringLength;

		public TextElement textElement;

		public Glyph alternativeGlyph;

		public FontAsset fontAsset;

		public SpriteAsset spriteAsset;

		public Material material;

		public int materialReferenceIndex;

		public bool isUsingAlternateTypeface;

		public float pointSize;

		public int lineNumber;

		public int vertexIndex;

		public TextVertex vertexTopLeft;

		public TextVertex vertexBottomLeft;

		public TextVertex vertexTopRight;

		public TextVertex vertexBottomRight;

		public Vector3 topLeft;

		public Vector3 bottomLeft;

		public Vector3 topRight;

		public Vector3 bottomRight;

		public float origin;

		public float ascender;

		public float baseLine;

		public float descender;

		internal float adjustedAscender;

		internal float adjustedDescender;

		internal float adjustedHorizontalAdvance;

		public float xAdvance;

		public float aspectRatio;

		public float scale;

		public Color32 color;

		public Color32 underlineColor;

		public int underlineVertexIndex;

		public Color32 strikethroughColor;

		public int strikethroughVertexIndex;

		public Color32 highlightColor;

		public HighlightState highlightState;

		public FontStyles style;

		public bool isVisible;

		public override string ToString()
		{
			return string.Format("{0}: {1}\n{2}: {3}\n{4}: {5}\n{6}: {7}\n{8}: {9}\n{10}: {11}\n{12}: {13}\n{14}: {15}\n{16}: {17}\n{18}: {19}\n{20}: {21}\n{22}: {23}\n{24}: {25}\n{26}: {27}\n{28}: {29}\n{30}: {31}\n{32}: {33}\n{34}: {35}\n{36}: {37}\n{38}: {39}\n{40}: {41}\n{42}: {43}\n{44}: {45}\n{46}: {47}\n{48}: {49}\n{50}: {51}\n{52}: {53}\n{54}: {55}\n{56}: {57}\n{58}: {59}\n{60}: {61}\n{62}: {63}\n{64}: {65}\n{66}: {67}\n{68}: {69}\n{70}: {71}\n{72}: {73}\n{74}: {75}\n{76}: {77}", "character", character, "index", index, "elementType", elementType, "stringLength", stringLength, "textElement", textElement, "alternativeGlyph", alternativeGlyph, "fontAsset", fontAsset, "spriteAsset", spriteAsset, "material", material, "materialReferenceIndex", materialReferenceIndex, "isUsingAlternateTypeface", isUsingAlternateTypeface, "pointSize", pointSize, "lineNumber", lineNumber, "vertexIndex", vertexIndex, "vertexTopLeft", vertexTopLeft, "vertexBottomLeft", vertexBottomLeft, "vertexTopRight", vertexTopRight, "vertexBottomRight", vertexBottomRight, "topLeft", topLeft, "bottomLeft", bottomLeft, "topRight", topRight, "bottomRight", bottomRight, "origin", origin, "ascender", ascender, "baseLine", baseLine, "descender", descender, "adjustedAscender", adjustedAscender, "adjustedDescender", adjustedDescender, "adjustedHorizontalAdvance", adjustedHorizontalAdvance, "xAdvance", xAdvance, "aspectRatio", aspectRatio, "scale", scale, "color", color, "underlineColor", underlineColor, "strikethroughColor", strikethroughColor, "highlightColor", highlightColor, "highlightState", highlightState, "style", style, "isVisible", isVisible);
		}

		internal string ToStringTest()
		{
			return "topLeft.x: " + topLeft.x.ToString("F4") + "\n topLeft.y: " + topLeft.y.ToString("F4") + "\n topRight.x: " + topRight.x.ToString("F4") + "\n topRight.y: " + topRight.y.ToString("F4") + "\n  bottomLeft.x: " + bottomLeft.x.ToString("F4") + "\n bottomLeft.y: " + bottomLeft.y.ToString("F4") + "\n  bottomRight.x: " + bottomRight.x.ToString("F4") + "\n bottomRight.y: " + bottomRight.y.ToString("F4") + "\norigin: " + origin.ToString("F4") + "\nxAdvance: " + xAdvance.ToString("F4") + "\n";
		}
	}
	public static class TextEventManager
	{
		public static readonly FastAction<bool, Material> MATERIAL_PROPERTY_EVENT = new FastAction<bool, Material>();

		public static readonly FastAction<bool, Object> FONT_PROPERTY_EVENT = new FastAction<bool, Object>();

		public static readonly FastAction<bool, Object> SPRITE_ASSET_PROPERTY_EVENT = new FastAction<bool, Object>();

		public static readonly FastAction<bool, Object> TEXTMESHPRO_PROPERTY_EVENT = new FastAction<bool, Object>();

		public static readonly FastAction<GameObject, Material, Material> DRAG_AND_DROP_MATERIAL_EVENT = new FastAction<GameObject, Material, Material>();

		public static readonly FastAction<bool> TEXT_STYLE_PROPERTY_EVENT = new FastAction<bool>();

		public static readonly FastAction<Object> COLOR_GRADIENT_PROPERTY_EVENT = new FastAction<Object>();

		public static readonly FastAction TMP_SETTINGS_PROPERTY_EVENT = new FastAction();

		public static readonly FastAction RESOURCE_LOAD_EVENT = new FastAction();

		public static readonly FastAction<bool, Object> TEXTMESHPRO_UGUI_PROPERTY_EVENT = new FastAction<bool, Object>();

		public static readonly FastAction OnPreRenderObject_Event = new FastAction();

		public static readonly FastAction<Object> TEXT_CHANGED_EVENT = new FastAction<Object>();

		public static void ON_PRE_RENDER_OBJECT_CHANGED()
		{
			OnPreRenderObject_Event.Call();
		}

		public static void ON_MATERIAL_PROPERTY_CHANGED(bool isChanged, Material mat)
		{
			MATERIAL_PROPERTY_EVENT.Call(isChanged, mat);
		}

		public static void ON_FONT_PROPERTY_CHANGED(bool isChanged, Object font)
		{
			FONT_PROPERTY_EVENT.Call(isChanged, font);
		}

		public static void ON_SPRITE_ASSET_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
			SPRITE_ASSET_PROPERTY_EVENT.Call(isChanged, obj);
		}

		public static void ON_TEXTMESHPRO_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
			TEXTMESHPRO_PROPERTY_EVENT.Call(isChanged, obj);
		}

		public static void ON_DRAG_AND_DROP_MATERIAL_CHANGED(GameObject sender, Material currentMaterial, Material newMaterial)
		{
			DRAG_AND_DROP_MATERIAL_EVENT.Call(sender, currentMaterial, newMaterial);
		}

		public static void ON_TEXT_STYLE_PROPERTY_CHANGED(bool isChanged)
		{
			TEXT_STYLE_PROPERTY_EVENT.Call(isChanged);
		}

		public static void ON_COLOR_GRADIENT_PROPERTY_CHANGED(Object gradient)
		{
			COLOR_GRADIENT_PROPERTY_EVENT.Call(gradient);
		}

		public static void ON_TEXT_CHANGED(Object obj)
		{
			TEXT_CHANGED_EVENT.Call(obj);
		}

		public static void ON_TMP_SETTINGS_CHANGED()
		{
			TMP_SETTINGS_PROPERTY_EVENT.Call();
		}

		public static void ON_RESOURCES_LOADED()
		{
			RESOURCE_LOAD_EVENT.Call();
		}

		public static void ON_TEXTMESHPRO_UGUI_PROPERTY_CHANGED(bool isChanged, Object obj)
		{
			TEXTMESHPRO_UGUI_PROPERTY_EVENT.Call(isChanged, obj);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal class TextGenerator
	{
		public delegate void MissingCharacterEventCallback(uint unicode, int stringIndex, TextInfo text, FontAsset fontAsset);

		protected struct SpecialCharacter(Character character, int materialIndex)
		{
			public Character character = character;

			public FontAsset fontAsset = character.textAsset as FontAsset;

			public Material material = ((fontAsset != null) ? fontAsset.material : null);

			public int materialIndex = materialIndex;
		}

		private const int k_Tab = 9;

		private const int k_LineFeed = 10;

		private const int k_VerticalTab = 11;

		private const int k_CarriageReturn = 13;

		private const int k_Space = 32;

		private const int k_DoubleQuotes = 34;

		private const int k_NumberSign = 35;

		private const int k_PercentSign = 37;

		private const int k_SingleQuote = 39;

		private const int k_Plus = 43;

		private const int k_Period = 46;

		private const int k_LesserThan = 60;

		private const int k_Equal = 61;

		private const int k_GreaterThan = 62;

		private const int k_Underline = 95;

		private const int k_NoBreakSpace = 160;

		private const int k_SoftHyphen = 173;

		private const int k_HyphenMinus = 45;

		private const int k_FigureSpace = 8199;

		private const int k_Hyphen = 8208;

		private const int k_NonBreakingHyphen = 8209;

		private const int k_ZeroWidthSpace = 8203;

		private const int k_NarrowNoBreakSpace = 8239;

		private const int k_WordJoiner = 8288;

		private const int k_HorizontalEllipsis = 8230;

		private const int k_LineSeparator = 8232;

		private const int k_ParagraphSeparator = 8233;

		private const int k_RightSingleQuote = 8217;

		private const int k_Square = 9633;

		private const int k_HangulJamoStart = 4352;

		private const int k_HangulJamoEnd = 4607;

		private const int k_CjkStart = 11904;

		private const int k_CjkEnd = 40959;

		private const int k_HangulJameExtendedStart = 43360;

		private const int k_HangulJameExtendedEnd = 43391;

		private const int k_HangulSyllablesStart = 44032;

		private const int k_HangulSyllablesEnd = 55295;

		private const int k_CjkIdeographsStart = 63744;

		private const int k_CjkIdeographsEnd = 64255;

		private const int k_CjkFormsStart = 65072;

		private const int k_CjkFormsEnd = 65103;

		private const int k_CjkHalfwidthStart = 65280;

		private const int k_CjkHalfwidthEnd = 65519;

		private const int k_EndOfText = 3;

		private const float k_FloatUnset = -32767f;

		private const int k_MaxCharacters = 8;

		private static TextGenerator s_TextGenerator;

		private TextBackingContainer m_TextBackingArray = new TextBackingContainer(4);

		internal TextProcessingElement[] m_TextProcessingArray = new TextProcessingElement[8];

		internal int m_InternalTextProcessingArraySize;

		[SerializeField]
		protected bool m_VertexBufferAutoSizeReduction = false;

		private char[] m_HtmlTag = new char[256];

		internal HighlightState m_HighlightState = new HighlightState(Color.white, Offset.zero);

		protected bool m_IsIgnoringAlignment;

		protected bool m_IsTextTruncated;

		private Vector3[] m_RectTransformCorners = new Vector3[4];

		private float m_MarginWidth;

		private float m_MarginHeight;

		private float m_PreferredWidth;

		private float m_PreferredHeight;

		private FontAsset m_CurrentFontAsset;

		private Material m_CurrentMaterial;

		private int m_CurrentMaterialIndex;

		private TextProcessingStack<MaterialReference> m_MaterialReferenceStack = new TextProcessingStack<MaterialReference>(new MaterialReference[16]);

		private float m_Padding;

		private SpriteAsset m_CurrentSpriteAsset;

		private int m_TotalCharacterCount;

		private float m_FontSize;

		private float m_FontScaleMultiplier;

		private bool m_ShouldRenderBitmap;

		private float m_CurrentFontSize;

		private TextProcessingStack<float> m_SizeStack = new TextProcessingStack<float>(16);

		protected TextProcessingStack<int>[] m_TextStyleStacks = new TextProcessingStack<int>[8];

		protected int m_TextStyleStackDepth = 0;

		private FontStyles m_FontStyleInternal = FontStyles.Normal;

		private FontStyleStack m_FontStyleStack;

		private TextFontWeight m_FontWeightInternal = TextFontWeight.Regular;

		private TextProcessingStack<TextFontWeight> m_FontWeightStack = new TextProcessingStack<TextFontWeight>(8);

		private TextAlignment m_LineJustification;

		private TextProcessingStack<TextAlignment> m_LineJustificationStack = new TextProcessingStack<TextAlignment>(16);

		private float _m_BaselineOffset;

		private TextProcessingStack<float> m_BaselineOffsetStack = new TextProcessingStack<float>(new float[16]);

		private Color32 m_FontColor32;

		private Color32 m_HtmlColor;

		private Color32 m_UnderlineColor;

		private Color32 m_StrikethroughColor;

		private TextProcessingStack<Color32> m_ColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		private TextProcessingStack<Color32> m_UnderlineColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		private TextProcessingStack<Color32> m_StrikethroughColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		private TextProcessingStack<Color32> m_HighlightColorStack = new TextProcessingStack<Color32>(new Color32[16]);

		private TextProcessingStack<HighlightState> m_HighlightStateStack = new TextProcessingStack<HighlightState>(new HighlightState[16]);

		private TextProcessingStack<int> m_ItalicAngleStack = new TextProcessingStack<int>(new int[16]);

		private TextColorGradient m_ColorGradientPreset;

		private TextProcessingStack<TextColorGradient> m_ColorGradientStack = new TextProcessingStack<TextColorGradient>(new TextColorGradient[16]);

		private bool m_ColorGradientPresetIsTinted;

		private TextProcessingStack<int> m_ActionStack = new TextProcessingStack<int>(new int[16]);

		private float _m_LineOffset;

		private float _m_LineHeight;

		private bool m_IsDrivenLineSpacing;

		private float m_CSpacing;

		private float m_MonoSpacing;

		private bool m_DuoSpace;

		private float _m_XAdvance;

		private float m_TagLineIndent;

		private float m_TagIndent;

		private TextProcessingStack<float> m_IndentStack = new TextProcessingStack<float>(new float[16]);

		private bool m_TagNoParsing;

		private int m_CharacterCount;

		private int m_FirstCharacterOfLine;

		private int m_LastCharacterOfLine;

		private int m_FirstVisibleCharacterOfLine;

		private int m_LastVisibleCharacterOfLine;

		private float m_MaxLineAscender;

		private float m_MaxLineDescender;

		private int m_LineNumber;

		private int m_LineVisibleCharacterCount;

		private int m_LineVisibleSpaceCount;

		private int m_FirstOverflowCharacterIndex;

		private float m_MarginLeft;

		private float m_MarginRight;

		private float m_Width;

		private Extents m_MeshExtents;

		private float m_MaxCapHeight;

		private float m_MaxAscender;

		private float m_MaxDescender;

		private bool m_IsNonBreakingSpace;

		private WordWrapState m_SavedWordWrapState;

		private WordWrapState m_SavedLineState;

		private WordWrapState m_SavedEllipsisState = default(WordWrapState);

		private WordWrapState m_SavedLastValidState = default(WordWrapState);

		private WordWrapState m_SavedSoftLineBreakState = default(WordWrapState);

		private TextElementType m_TextElementType;

		private bool m_isTextLayoutPhase;

		private int m_SpriteIndex;

		private Color32 m_SpriteColor;

		private TextElement m_CachedTextElement;

		private Color32 m_HighlightColor;

		private float m_CharWidthAdjDelta;

		private float m_MaxFontSize;

		private float m_MinFontSize;

		private int m_AutoSizeIterationCount;

		private int m_AutoSizeMaxIterationCount = 100;

		private float m_StartOfLineAscender;

		private float m_LineSpacingDelta;

		internal MaterialReference[] m_MaterialReferences = new MaterialReference[8];

		private int m_SpriteCount = 0;

		private TextProcessingStack<int> m_StyleStack = new TextProcessingStack<int>(new int[16]);

		private TextProcessingStack<WordWrapState> m_EllipsisInsertionCandidateStack = new TextProcessingStack<WordWrapState>(8, 8);

		private int m_SpriteAnimationId;

		private int m_ItalicAngle;

		private Vector3 m_FXScale;

		private Quaternion m_FXRotation;

		private int m_LastBaseGlyphIndex;

		private float m_PageAscender;

		private RichTextTagAttribute[] m_XmlAttribute = new RichTextTagAttribute[8];

		private float[] m_AttributeParameterValues = new float[16];

		private Dictionary<int, int> m_MaterialReferenceIndexLookup = new Dictionary<int, int>();

		private bool m_IsCalculatingPreferredValues;

		private bool m_TintSprite;

		protected SpecialCharacter m_Ellipsis;

		protected SpecialCharacter m_Underline;

		private TextElementInfo[] m_InternalTextElementInfo;

		internal static readonly bool EnableTextAlignmentAssertions;

		internal static readonly bool EnableCheckerboardPattern;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static bool IsExecutingJob { get; set; }

		private bool vertexBufferAutoSizeReduction
		{
			get
			{
				return m_VertexBufferAutoSizeReduction;
			}
			set
			{
				m_VertexBufferAutoSizeReduction = value;
			}
		}

		public bool isTextTruncated => m_IsTextTruncated;

		private float m_BaselineOffset
		{
			get
			{
				return _m_BaselineOffset;
			}
			set
			{
				_m_BaselineOffset = Round(value);
			}
		}

		private float m_LineOffset
		{
			get
			{
				return _m_LineOffset;
			}
			set
			{
				_m_LineOffset = Round(value);
			}
		}

		private float m_LineHeight
		{
			get
			{
				return _m_LineHeight;
			}
			set
			{
				_m_LineHeight = Round(value);
			}
		}

		private float m_XAdvance
		{
			get
			{
				return _m_XAdvance;
			}
			set
			{
				float num = Round(value);
				_m_XAdvance = num;
			}
		}

		private bool NeedToRound => m_ShouldRenderBitmap;

		public static event MissingCharacterEventCallback OnMissingCharacter;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static TextGenerator GetTextGenerator()
		{
			if (s_TextGenerator == null)
			{
				s_TextGenerator = new TextGenerator();
			}
			return s_TextGenerator;
		}

		public void GenerateText(TextGenerationSettings settings, TextInfo textInfo)
		{
			bool flag = !IsExecutingJob;
			if (settings.fontAsset == null)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				return;
			}
			if (textInfo == null)
			{
				Debug.LogError("Null TextInfo provided to TextGenerator. Cannot update its content.");
				return;
			}
			Prepare(settings, textInfo);
			if (flag)
			{
				FontAsset.UpdateFontAssetsInUpdateQueue();
			}
			GenerateTextMesh(settings, textInfo);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal void GenerateTextMesh(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			if (generationSettings.fontAsset == null)
			{
				Debug.LogWarning("Can't Generate Mesh! No Font Asset has been assigned.");
				return;
			}
			textInfo?.Clear();
			if (generationSettings.fontSize <= 0 || m_TextProcessingArray == null || m_TextProcessingArray.Length == 0 || m_TextProcessingArray[0].unicode == 0)
			{
				ClearMesh(updateMesh: true, textInfo);
				m_PreferredWidth = 0f;
				m_PreferredHeight = 0f;
				return;
			}
			float num = 0f;
			ParsingPhase(textInfo, generationSettings, out var charCode, out var maxVisibleDescender);
			num = m_MaxFontSize - m_MinFontSize;
			bool flag = false;
			if (m_AutoSizeIterationCount >= m_AutoSizeMaxIterationCount)
			{
				Debug.Log("Auto Size Iteration Count: " + m_AutoSizeIterationCount + ". Final Point Size: " + m_FontSize);
			}
			if (m_CharacterCount == 0 || (m_CharacterCount == 1 && charCode == 3))
			{
				ClearMesh(updateMesh: true, textInfo);
				return;
			}
			if (NeedToRound && EnableTextAlignmentAssertions)
			{
				Debug.AssertFormat((double)Mathf.Abs(generationSettings.screenRect.x - Round(generationSettings.screenRect.x)) < 0.01, "Bitmap Rendering specified and screenRect.x is not rounded:{0}", generationSettings.screenRect.x);
				Debug.AssertFormat((double)Mathf.Abs(generationSettings.screenRect.y - Round(generationSettings.screenRect.y)) < 0.01, "Bitmap Rendering specified and screenRect.y is not rounded:{0}", generationSettings.screenRect.y);
				Debug.AssertFormat((double)Mathf.Abs(generationSettings.screenRect.width - Round(generationSettings.screenRect.width)) < 0.01, "Bitmap Rendering specified and screenRect.width is not rounded:{0}", generationSettings.screenRect.width);
				Debug.AssertFormat((double)Mathf.Abs(generationSettings.screenRect.height - Round(generationSettings.screenRect.height)) < 0.01, "Bitmap Rendering specified and screenRect.height is not rounded:{0}", generationSettings.screenRect.height);
			}
			LayoutPhase(textInfo, generationSettings, maxVisibleDescender);
			for (int i = 1; i < textInfo.materialCount; i++)
			{
				textInfo.meshInfo[i].ClearUnusedVertices();
			}
		}

		private bool ValidateHtmlTag(TextProcessingElement[] chars, int startIndex, out int endIndex, TextGenerationSettings generationSettings, TextInfo textInfo, out bool isThreadSuccess)
		{
			bool flag = !IsExecutingJob;
			isThreadSuccess = true;
			TextSettings textSettings = generationSettings.textSettings;
			int num = 0;
			byte b = 0;
			int num2 = 0;
			ClearMarkupTagAttributes();
			TagValueType tagValueType = TagValueType.None;
			TagUnitType tagUnitType = TagUnitType.Pixels;
			endIndex = startIndex;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			for (int i = startIndex; i < chars.Length && chars[i].unicode != 0; i++)
			{
				if (num >= m_HtmlTag.Length)
				{
					break;
				}
				if (chars[i].unicode == 60)
				{
					break;
				}
				uint unicode = chars[i].unicode;
				if (unicode == 62)
				{
					flag3 = true;
					endIndex = i;
					m_HtmlTag[num] = '\0';
					break;
				}
				m_HtmlTag[num] = (char)unicode;
				num++;
				if (b == 1)
				{
					switch (tagValueType)
					{
					case TagValueType.None:
						if (unicode == 43 || unicode == 45 || unicode == 46 || (unicode >= 48 && unicode <= 57))
						{
							tagUnitType = TagUnitType.Pixels;
							tagValueType = (m_XmlAttribute[num2].valueType = TagValueType.NumericalValue);
							m_XmlAttribute[num2].valueStartIndex = num - 1;
							m_XmlAttribute[num2].valueLength++;
							break;
						}
						switch (unicode)
						{
						case 35u:
							tagUnitType = TagUnitType.Pixels;
							tagValueType = (m_XmlAttribute[num2].valueType = TagValueType.ColorValue);
							m_XmlAttribute[num2].valueStartIndex = num - 1;
							m_XmlAttribute[num2].valueLength++;
							break;
						case 39u:
							tagUnitType = TagUnitType.Pixels;
							tagValueType = (m_XmlAttribute[num2].valueType = TagValueType.StringValue);
							m_XmlAttribute[num2].valueStartIndex = num;
							flag4 = true;
							break;
						case 34u:
							tagUnitType = TagUnitType.Pixels;
							tagValueType = (m_XmlAttribute[num2].valueType = TagValueType.StringValue);
							m_XmlAttribute[num2].valueStartIndex = num;
							flag5 = true;
							break;
						default:
							tagUnitType = TagUnitType.Pixels;
							tagValueType = (m_XmlAttribute[num2].valueType = TagValueType.StringValue);
							m_XmlAttribute[num2].valueStartIndex = num - 1;
							m_XmlAttribute[num2].valueHashCode = ((m_XmlAttribute[num2].valueHashCode << 5) + m_XmlAttribute[num2].valueHashCode) ^ TextGeneratorUtilities.ToUpperFast((char)unicode);
							m_XmlAttribute[num2].valueLength++;
							break;
						}
						break;
					case TagValueType.NumericalValue:
						if (unicode == 112 || unicode == 101 || unicode == 37 || unicode == 32)
						{
							b = 2;
							tagValueType = TagValueType.None;
							tagUnitType = unicode switch
							{
								101u => m_XmlAttribute[num2].unitType = TagUnitType.FontUnits, 
								37u => m_XmlAttribute[num2].unitType = TagUnitType.Percentage, 
								_ => m_XmlAttribute[num2].unitType = TagUnitType.Pixels, 
							};
							num2++;
							m_XmlAttribute[num2].nameHashCode = 0;
							m_XmlAttribute[num2].valueHashCode = 0;
							m_XmlAttribute[num2].valueType = TagValueType.None;
							m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
							m_XmlAttribute[num2].valueStartIndex = 0;
							m_XmlAttribute[num2].valueLength = 0;
						}
						else
						{
							m_XmlAttribute[num2].valueLength++;
						}
						break;
					case TagValueType.ColorValue:
						if (unicode != 32)
						{
							m_XmlAttribute[num2].valueLength++;
							break;
						}
						b = 2;
						tagValueType = TagValueType.None;
						tagUnitType = TagUnitType.Pixels;
						num2++;
						m_XmlAttribute[num2].nameHashCode = 0;
						m_XmlAttribute[num2].valueType = TagValueType.None;
						m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
						m_XmlAttribute[num2].valueHashCode = 0;
						m_XmlAttribute[num2].valueStartIndex = 0;
						m_XmlAttribute[num2].valueLength = 0;
						break;
					case TagValueType.StringValue:
						if ((!flag5 || unicode != 34) && (!flag4 || unicode != 39))
						{
							m_XmlAttribute[num2].valueHashCode = ((m_XmlAttribute[num2].valueHashCode << 5) + m_XmlAttribute[num2].valueHashCode) ^ TextGeneratorUtilities.ToUpperFast((char)unicode);
							m_XmlAttribute[num2].valueLength++;
							break;
						}
						b = 2;
						tagValueType = TagValueType.None;
						tagUnitType = TagUnitType.Pixels;
						num2++;
						if (m_XmlAttribute.Length <= num2)
						{
							int newSize = Mathf.NextPowerOfTwo(num2 + 1);
							Array.Resize(ref m_XmlAttribute, newSize);
						}
						m_XmlAttribute[num2].nameHashCode = 0;
						m_XmlAttribute[num2].valueType = TagValueType.None;
						m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
						m_XmlAttribute[num2].valueHashCode = 0;
						m_XmlAttribute[num2].valueStartIndex = 0;
						m_XmlAttribute[num2].valueLength = 0;
						break;
					}
				}
				if (unicode == 61)
				{
					b = 1;
				}
				if (b == 0 && unicode == 32)
				{
					if (flag2)
					{
						return false;
					}
					flag2 = true;
					b = 2;
					tagValueType = TagValueType.None;
					tagUnitType = TagUnitType.Pixels;
					num2++;
					m_XmlAttribute[num2].nameHashCode = 0;
					m_XmlAttribute[num2].valueType = TagValueType.None;
					m_XmlAttribute[num2].unitType = TagUnitType.Pixels;
					m_XmlAttribute[num2].valueHashCode = 0;
					m_XmlAttribute[num2].valueStartIndex = 0;
					m_XmlAttribute[num2].valueLength = 0;
				}
				if (b == 0)
				{
					m_XmlAttribute[num2].nameHashCode = ((m_XmlAttribute[num2].nameHashCode << 5) + m_XmlAttribute[num2].nameHashCode) ^ TextGeneratorUtilities.ToUpperFast((char)unicode);
				}
				if (b == 2 && unicode == 32)
				{
					b = 0;
				}
			}
			if (!flag3)
			{
				return false;
			}
			if (m_TagNoParsing && m_XmlAttribute[0].nameHashCode != -294095813)
			{
				return false;
			}
			if (m_XmlAttribute[0].nameHashCode == -294095813)
			{
				m_TagNoParsing = false;
				return true;
			}
			if (m_HtmlTag[0] == '#' && num == 4)
			{
				m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, 0, num);
				m_ColorStack.Add(m_HtmlColor);
				return true;
			}
			if (m_HtmlTag[0] == '#' && num == 5)
			{
				m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, 0, num);
				m_ColorStack.Add(m_HtmlColor);
				return true;
			}
			if (m_HtmlTag[0] == '#' && num == 7)
			{
				m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, 0, num);
				m_ColorStack.Add(m_HtmlColor);
				return true;
			}
			if (m_HtmlTag[0] == '#' && num == 9)
			{
				m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, 0, num);
				m_ColorStack.Add(m_HtmlColor);
				return true;
			}
			float num3 = 0f;
			Material material;
			switch ((MarkupTag)m_XmlAttribute[0].nameHashCode)
			{
			case MarkupTag.BOLD:
				m_FontStyleInternal |= FontStyles.Bold;
				m_FontStyleStack.Add(FontStyles.Bold);
				m_FontWeightInternal = TextFontWeight.Bold;
				return true;
			case MarkupTag.SLASH_BOLD:
				if ((generationSettings.fontStyle & FontStyles.Bold) != FontStyles.Bold && m_FontStyleStack.Remove(FontStyles.Bold) == 0)
				{
					m_FontStyleInternal &= ~FontStyles.Bold;
					m_FontWeightInternal = m_FontWeightStack.Peek();
				}
				return true;
			case MarkupTag.ITALIC:
				m_FontStyleInternal |= FontStyles.Italic;
				m_FontStyleStack.Add(FontStyles.Italic);
				if (m_XmlAttribute[1].nameHashCode == 75347905)
				{
					m_ItalicAngle = (int)TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength);
					if (m_ItalicAngle < -180 || m_ItalicAngle > 180)
					{
						return false;
					}
				}
				else
				{
					m_ItalicAngle = m_CurrentFontAsset.italicStyleSlant;
				}
				m_ItalicAngleStack.Add(m_ItalicAngle);
				return true;
			case MarkupTag.SLASH_ITALIC:
				if ((generationSettings.fontStyle & FontStyles.Italic) != FontStyles.Italic)
				{
					m_ItalicAngle = m_ItalicAngleStack.Remove();
					if (m_FontStyleStack.Remove(FontStyles.Italic) == 0)
					{
						m_FontStyleInternal &= ~FontStyles.Italic;
					}
				}
				return true;
			case MarkupTag.STRIKETHROUGH:
				m_FontStyleInternal |= FontStyles.Strikethrough;
				m_FontStyleStack.Add(FontStyles.Strikethrough);
				if (m_XmlAttribute[1].nameHashCode == 81999901)
				{
					m_StrikethroughColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength);
					m_StrikethroughColor.a = ((m_HtmlColor.a < m_StrikethroughColor.a) ? m_HtmlColor.a : m_StrikethroughColor.a);
					if (textInfo != null)
					{
						textInfo.hasMultipleColors = true;
					}
				}
				else
				{
					m_StrikethroughColor = m_HtmlColor;
				}
				m_StrikethroughColorStack.Add(m_StrikethroughColor);
				return true;
			case MarkupTag.SLASH_STRIKETHROUGH:
				if ((generationSettings.fontStyle & FontStyles.Strikethrough) != FontStyles.Strikethrough && m_FontStyleStack.Remove(FontStyles.Strikethrough) == 0)
				{
					m_FontStyleInternal &= ~FontStyles.Strikethrough;
				}
				m_StrikethroughColor = m_StrikethroughColorStack.Remove();
				return true;
			case MarkupTag.UNDERLINE:
				m_FontStyleInternal |= FontStyles.Underline;
				m_FontStyleStack.Add(FontStyles.Underline);
				if (m_XmlAttribute[1].nameHashCode == 81999901)
				{
					m_UnderlineColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength);
					m_UnderlineColor.a = ((m_HtmlColor.a < m_UnderlineColor.a) ? m_HtmlColor.a : m_UnderlineColor.a);
					if (textInfo != null)
					{
						textInfo.hasMultipleColors = true;
					}
				}
				else
				{
					m_UnderlineColor = m_HtmlColor;
				}
				m_UnderlineColorStack.Add(m_UnderlineColor);
				return true;
			case MarkupTag.SLASH_UNDERLINE:
				if ((generationSettings.fontStyle & FontStyles.Underline) != FontStyles.Underline && m_FontStyleStack.Remove(FontStyles.Underline) == 0)
				{
					m_FontStyleInternal &= ~FontStyles.Underline;
				}
				m_UnderlineColor = m_UnderlineColorStack.Remove();
				return true;
			case MarkupTag.MARK:
			{
				m_FontStyleInternal |= FontStyles.Highlight;
				m_FontStyleStack.Add(FontStyles.Highlight);
				Color32 color = new Color32(byte.MaxValue, byte.MaxValue, 0, 64);
				Offset padding = Offset.zero;
				for (int m = 0; m < m_XmlAttribute.Length && m_XmlAttribute[m].nameHashCode != 0; m++)
				{
					switch ((MarkupTag)m_XmlAttribute[m].nameHashCode)
					{
					case MarkupTag.MARK:
						if (m_XmlAttribute[m].valueType == TagValueType.ColorValue)
						{
							color = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
						}
						break;
					case MarkupTag.COLOR:
						color = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, m_XmlAttribute[m].valueStartIndex, m_XmlAttribute[m].valueLength);
						break;
					case MarkupTag.PADDING:
					{
						int attributeParameters2 = TextGeneratorUtilities.GetAttributeParameters(m_HtmlTag, m_XmlAttribute[m].valueStartIndex, m_XmlAttribute[m].valueLength, ref m_AttributeParameterValues);
						if (attributeParameters2 != 4)
						{
							return false;
						}
						padding = new Offset(m_AttributeParameterValues[0], m_AttributeParameterValues[1], m_AttributeParameterValues[2], m_AttributeParameterValues[3]);
						padding *= m_FontSize * 0.01f;
						break;
					}
					}
				}
				color.a = ((m_HtmlColor.a < color.a) ? m_HtmlColor.a : color.a);
				m_HighlightState = new HighlightState(color, padding);
				m_HighlightStateStack.Push(m_HighlightState);
				if (textInfo != null)
				{
					textInfo.hasMultipleColors = true;
				}
				return true;
			}
			case MarkupTag.SLASH_MARK:
				if ((generationSettings.fontStyle & FontStyles.Highlight) != FontStyles.Highlight)
				{
					m_HighlightStateStack.Remove();
					m_HighlightState = m_HighlightStateStack.current;
					if (m_FontStyleStack.Remove(FontStyles.Highlight) == 0)
					{
						m_FontStyleInternal &= ~FontStyles.Highlight;
					}
				}
				return true;
			case MarkupTag.SUBSCRIPT:
			{
				m_FontScaleMultiplier *= ((m_CurrentFontAsset.faceInfo.subscriptSize > 0f) ? m_CurrentFontAsset.faceInfo.subscriptSize : 1f);
				m_BaselineOffsetStack.Push(m_BaselineOffset);
				m_MaterialReferenceStack.Push(m_MaterialReferences[m_CurrentMaterialIndex]);
				float num7 = m_CurrentFontSize / m_CurrentFontAsset.faceInfo.pointSize * m_CurrentFontAsset.faceInfo.scale;
				m_BaselineOffset += m_CurrentFontAsset.faceInfo.subscriptOffset * num7 * m_FontScaleMultiplier;
				m_FontStyleStack.Add(FontStyles.Subscript);
				m_FontStyleInternal |= FontStyles.Subscript;
				return true;
			}
			case MarkupTag.SLASH_SUBSCRIPT:
				if ((m_FontStyleInternal & FontStyles.Subscript) == FontStyles.Subscript)
				{
					FontAsset fontAsset3 = m_MaterialReferenceStack.Pop().fontAsset;
					if (m_FontScaleMultiplier < 1f)
					{
						m_BaselineOffset = m_BaselineOffsetStack.Pop();
						m_FontScaleMultiplier /= ((fontAsset3.faceInfo.subscriptSize > 0f) ? fontAsset3.faceInfo.subscriptSize : 1f);
					}
					if (m_FontStyleStack.Remove(FontStyles.Subscript) == 0)
					{
						m_FontStyleInternal &= ~FontStyles.Subscript;
					}
				}
				return true;
			case MarkupTag.SUPERSCRIPT:
			{
				m_FontScaleMultiplier *= ((m_CurrentFontAsset.faceInfo.superscriptSize > 0f) ? m_CurrentFontAsset.faceInfo.superscriptSize : 1f);
				m_BaselineOffsetStack.Push(m_BaselineOffset);
				m_MaterialReferenceStack.Push(m_MaterialReferences[m_CurrentMaterialIndex]);
				float num7 = m_CurrentFontSize / m_CurrentFontAsset.faceInfo.pointSize * m_CurrentFontAsset.faceInfo.scale;
				m_BaselineOffset += m_CurrentFontAsset.faceInfo.superscriptOffset * num7 * m_FontScaleMultiplier;
				m_FontStyleStack.Add(FontStyles.Superscript);
				m_FontStyleInternal |= FontStyles.Superscript;
				return true;
			}
			case MarkupTag.SLASH_SUPERSCRIPT:
				if ((m_FontStyleInternal & FontStyles.Superscript) == FontStyles.Superscript)
				{
					FontAsset fontAsset = m_MaterialReferenceStack.Pop().fontAsset;
					if (m_FontScaleMultiplier < 1f)
					{
						m_BaselineOffset = m_BaselineOffsetStack.Pop();
						m_FontScaleMultiplier /= ((fontAsset.faceInfo.superscriptSize > 0f) ? fontAsset.faceInfo.superscriptSize : 1f);
					}
					if (m_FontStyleStack.Remove(FontStyles.Superscript) == 0)
					{
						m_FontStyleInternal &= ~FontStyles.Superscript;
					}
				}
				return true;
			case MarkupTag.FONT_WEIGHT:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch ((int)num3)
				{
				case 100:
					m_FontWeightInternal = TextFontWeight.Thin;
					break;
				case 200:
					m_FontWeightInternal = TextFontWeight.ExtraLight;
					break;
				case 300:
					m_FontWeightInternal = TextFontWeight.Light;
					break;
				case 400:
					m_FontWeightInternal = TextFontWeight.Regular;
					break;
				case 500:
					m_FontWeightInternal = TextFontWeight.Medium;
					break;
				case 600:
					m_FontWeightInternal = TextFontWeight.SemiBold;
					break;
				case 700:
					m_FontWeightInternal = TextFontWeight.Bold;
					break;
				case 800:
					m_FontWeightInternal = TextFontWeight.Heavy;
					break;
				case 900:
					m_FontWeightInternal = TextFontWeight.Black;
					break;
				}
				m_FontWeightStack.Add(m_FontWeightInternal);
				return true;
			case MarkupTag.SLASH_FONT_WEIGHT:
				m_FontWeightStack.Remove();
				if (m_FontStyleInternal == FontStyles.Bold)
				{
					m_FontWeightInternal = TextFontWeight.Bold;
				}
				else
				{
					m_FontWeightInternal = m_FontWeightStack.Peek();
				}
				return true;
			case MarkupTag.POSITION:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_XAdvance = num3;
					return true;
				case TagUnitType.FontUnits:
					m_XAdvance = num3 * m_CurrentFontSize;
					return true;
				case TagUnitType.Percentage:
					m_XAdvance = m_MarginWidth * num3 / 100f;
					return true;
				default:
					return false;
				}
			case MarkupTag.SLASH_POSITION:
				m_IsIgnoringAlignment = false;
				return true;
			case MarkupTag.VERTICAL_OFFSET:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_BaselineOffset = num3 * generationSettings.pixelsPerPoint;
					return true;
				case TagUnitType.FontUnits:
					m_BaselineOffset = num3 * m_CurrentFontSize;
					return true;
				case TagUnitType.Percentage:
					return false;
				default:
					return false;
				}
			case MarkupTag.SLASH_VERTICAL_OFFSET:
				m_BaselineOffset = 0f;
				return true;
			case MarkupTag.PAGE:
				return true;
			case MarkupTag.NO_BREAK:
				m_IsNonBreakingSpace = true;
				return true;
			case MarkupTag.SLASH_NO_BREAK:
				m_IsNonBreakingSpace = false;
				return true;
			case MarkupTag.SIZE:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					if (m_HtmlTag[5] == '+')
					{
						m_CurrentFontSize = m_FontSize + num3 * generationSettings.pixelsPerPoint;
						m_SizeStack.Add(m_CurrentFontSize);
						return true;
					}
					if (m_HtmlTag[5] == '-')
					{
						m_CurrentFontSize = m_FontSize + num3 * generationSettings.pixelsPerPoint;
						m_SizeStack.Add(m_CurrentFontSize);
						return true;
					}
					m_CurrentFontSize = num3 * generationSettings.pixelsPerPoint;
					m_SizeStack.Add(m_CurrentFontSize);
					return true;
				case TagUnitType.FontUnits:
					m_CurrentFontSize = m_FontSize * num3;
					m_SizeStack.Add(m_CurrentFontSize);
					return true;
				case TagUnitType.Percentage:
					m_CurrentFontSize = m_FontSize * num3 / 100f;
					m_SizeStack.Add(m_CurrentFontSize);
					return true;
				default:
					return false;
				}
			case MarkupTag.SLASH_SIZE:
				m_CurrentFontSize = m_SizeStack.Remove();
				return true;
			case MarkupTag.FONT:
			{
				int valueHashCode3 = m_XmlAttribute[0].valueHashCode;
				int nameHashCode = m_XmlAttribute[1].nameHashCode;
				int valueHashCode = m_XmlAttribute[1].valueHashCode;
				if (valueHashCode3 == -620974005)
				{
					m_CurrentFontAsset = m_MaterialReferences[0].fontAsset;
					m_CurrentMaterial = m_MaterialReferences[0].material;
					m_CurrentMaterialIndex = 0;
					m_MaterialReferenceStack.Add(m_MaterialReferences[0]);
					return true;
				}
				MaterialReferenceManager.TryGetFontAsset(valueHashCode3, out var fontAsset2);
				if (fontAsset2 == null)
				{
					if (fontAsset2 == null)
					{
						if (!flag)
						{
							isThreadSuccess = false;
							return false;
						}
						fontAsset2 = Resources.Load<FontAsset>(textSettings.defaultFontAssetPath + new string(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength));
					}
					if (fontAsset2 == null)
					{
						return false;
					}
					MaterialReferenceManager.AddFontAsset(fontAsset2);
				}
				if (nameHashCode == 0 && valueHashCode == 0)
				{
					m_CurrentMaterial = fontAsset2.material;
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, fontAsset2, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_MaterialReferenceStack.Add(m_MaterialReferences[m_CurrentMaterialIndex]);
				}
				else
				{
					if (nameHashCode != 825491659)
					{
						return false;
					}
					if (MaterialReferenceManager.TryGetMaterial(valueHashCode, out material))
					{
						m_CurrentMaterial = material;
						m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, fontAsset2, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
						m_MaterialReferenceStack.Add(m_MaterialReferences[m_CurrentMaterialIndex]);
					}
					else
					{
						if (!flag)
						{
							isThreadSuccess = false;
							return false;
						}
						material = Resources.Load<Material>(textSettings.defaultFontAssetPath + new string(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength));
						if (material == null)
						{
							return false;
						}
						MaterialReferenceManager.AddFontMaterial(valueHashCode, material);
						m_CurrentMaterial = material;
						m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, fontAsset2, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
						m_MaterialReferenceStack.Add(m_MaterialReferences[m_CurrentMaterialIndex]);
					}
				}
				m_CurrentFontAsset = fontAsset2;
				return true;
			}
			case MarkupTag.SLASH_FONT:
			{
				MaterialReference materialReference2 = m_MaterialReferenceStack.Remove();
				m_CurrentFontAsset = materialReference2.fontAsset;
				m_CurrentMaterial = materialReference2.material;
				m_CurrentMaterialIndex = materialReference2.index;
				return true;
			}
			case MarkupTag.MATERIAL:
			{
				int valueHashCode = m_XmlAttribute[0].valueHashCode;
				if (valueHashCode == -620974005)
				{
					m_CurrentMaterial = m_MaterialReferences[0].material;
					m_CurrentMaterialIndex = 0;
					m_MaterialReferenceStack.Add(m_MaterialReferences[0]);
					return true;
				}
				if (MaterialReferenceManager.TryGetMaterial(valueHashCode, out material))
				{
					m_CurrentMaterial = material;
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_MaterialReferenceStack.Add(m_MaterialReferences[m_CurrentMaterialIndex]);
				}
				else
				{
					if (!flag)
					{
						isThreadSuccess = false;
						return false;
					}
					material = Resources.Load<Material>(textSettings.defaultFontAssetPath + new string(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength));
					if (material == null)
					{
						return false;
					}
					MaterialReferenceManager.AddFontMaterial(valueHashCode, material);
					m_CurrentMaterial = material;
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_MaterialReferenceStack.Add(m_MaterialReferences[m_CurrentMaterialIndex]);
				}
				return true;
			}
			case MarkupTag.SLASH_MATERIAL:
			{
				MaterialReference materialReference = m_MaterialReferenceStack.Remove();
				m_CurrentMaterial = materialReference.material;
				m_CurrentMaterialIndex = materialReference.index;
				return true;
			}
			case MarkupTag.SPACE:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_XAdvance += num3 * generationSettings.pixelsPerPoint;
					return true;
				case TagUnitType.FontUnits:
					m_XAdvance += num3 * m_CurrentFontSize;
					return true;
				case TagUnitType.Percentage:
					return false;
				default:
					return false;
				}
			case MarkupTag.ALPHA:
				if (m_XmlAttribute[0].valueLength != 3)
				{
					return false;
				}
				m_HtmlColor.a = (byte)(TextGeneratorUtilities.HexToInt(m_HtmlTag[7]) * 16 + TextGeneratorUtilities.HexToInt(m_HtmlTag[8]));
				return true;
			case MarkupTag.A:
				if (m_isTextLayoutPhase && !m_IsCalculatingPreferredValues)
				{
					if (generationSettings.isIMGUI && textInfo != null)
					{
						CloseLastLinkTag(textInfo);
						int linkCount = textInfo.linkCount;
						if (linkCount + 1 > textInfo.linkInfo.Length)
						{
							TextInfo.Resize(ref textInfo.linkInfo, linkCount + 1);
						}
						textInfo.linkInfo[linkCount].hashCode = 2535353;
						textInfo.linkInfo[linkCount].linkTextfirstCharacterIndex = m_CharacterCount;
						textInfo.linkInfo[linkCount].linkIdFirstCharacterIndex = 3;
						int num4 = m_XmlAttribute[1].valueLength;
						for (int num5 = num2; num5 >= 1; num5--)
						{
							if (m_XmlAttribute[num5].valueLength > 0)
							{
								num4 = m_XmlAttribute[num5].valueLength + m_XmlAttribute[num5].valueStartIndex;
								break;
							}
						}
						if (m_XmlAttribute[1].valueLength > 0)
						{
							textInfo.linkInfo[linkCount].SetLinkId(m_HtmlTag, 2, num4 - 1);
						}
						textInfo.linkCount++;
					}
					else if (m_XmlAttribute[1].nameHashCode == 2535353 && textInfo != null)
					{
						CloseLastLinkTag(textInfo);
						int linkCount2 = textInfo.linkCount;
						if (linkCount2 + 1 > textInfo.linkInfo.Length)
						{
							TextInfo.Resize(ref textInfo.linkInfo, linkCount2 + 1);
						}
						textInfo.linkInfo[linkCount2].hashCode = 2535353;
						textInfo.linkInfo[linkCount2].linkTextfirstCharacterIndex = m_CharacterCount;
						textInfo.linkInfo[linkCount2].linkIdFirstCharacterIndex = startIndex + m_XmlAttribute[1].valueStartIndex;
						textInfo.linkInfo[linkCount2].SetLinkId(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength);
						textInfo.linkInfo[linkCount2].linkTextLength = -1;
						textInfo.linkCount++;
					}
				}
				return true;
			case MarkupTag.SLASH_A:
				if (m_isTextLayoutPhase && !m_IsCalculatingPreferredValues && textInfo != null)
				{
					if (textInfo.linkInfo.Length == 0 || textInfo.linkCount <= 0)
					{
						if (generationSettings.textSettings.displayWarnings)
						{
							Debug.LogWarning("There seems to be an issue with the formatting of the <a> tag. Possible issues include: missing or misplaced closing '>', missing or incorrect attribute, or unclosed quotes for attribute values. Please review the tag syntax.");
						}
					}
					else
					{
						int num9 = textInfo.linkCount - 1;
						textInfo.linkInfo[num9].linkTextLength = m_CharacterCount - textInfo.linkInfo[num9].linkTextfirstCharacterIndex;
					}
				}
				return true;
			case MarkupTag.LINK:
				if (m_isTextLayoutPhase && !m_IsCalculatingPreferredValues && textInfo != null)
				{
					CloseLastLinkTag(textInfo);
					int linkCount3 = textInfo.linkCount;
					if (linkCount3 + 1 > textInfo.linkInfo.Length)
					{
						TextInfo.Resize(ref textInfo.linkInfo, linkCount3 + 1);
					}
					textInfo.linkInfo[linkCount3].hashCode = m_XmlAttribute[0].valueHashCode;
					textInfo.linkInfo[linkCount3].linkTextfirstCharacterIndex = m_CharacterCount;
					textInfo.linkInfo[linkCount3].linkIdFirstCharacterIndex = startIndex + m_XmlAttribute[0].valueStartIndex;
					textInfo.linkInfo[linkCount3].SetLinkId(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
					textInfo.linkInfo[linkCount3].linkTextLength = -1;
					textInfo.linkCount++;
				}
				return true;
			case MarkupTag.SLASH_LINK:
				if (m_isTextLayoutPhase && !m_IsCalculatingPreferredValues && textInfo != null)
				{
					if (textInfo.linkInfo.Length == 0 || textInfo.linkCount <= 0)
					{
						if (generationSettings.textSettings.displayWarnings)
						{
							Debug.LogWarning("There seems to be an issue with the formatting of the <link> tag. Possible issues include: missing or misplaced closing '>', missing or incorrect attribute, or unclosed quotes for attribute values. Please review the tag syntax.");
						}
					}
					else
					{
						textInfo.linkInfo[textInfo.linkCount - 1].linkTextLength = m_CharacterCount - textInfo.linkInfo[textInfo.linkCount - 1].linkTextfirstCharacterIndex;
					}
				}
				return true;
			case MarkupTag.ALIGN:
				switch ((MarkupTag)m_XmlAttribute[0].valueHashCode)
				{
				case MarkupTag.LEFT:
					m_LineJustification = TextAlignment.MiddleLeft;
					m_LineJustificationStack.Add(m_LineJustification);
					return true;
				case MarkupTag.RIGHT:
					m_LineJustification = TextAlignment.MiddleRight;
					m_LineJustificationStack.Add(m_LineJustification);
					return true;
				case MarkupTag.CENTER:
					m_LineJustification = TextAlignment.MiddleCenter;
					m_LineJustificationStack.Add(m_LineJustification);
					return true;
				case MarkupTag.JUSTIFIED:
					m_LineJustification = TextAlignment.MiddleJustified;
					m_LineJustificationStack.Add(m_LineJustification);
					return true;
				case MarkupTag.FLUSH:
					m_LineJustification = TextAlignment.MiddleFlush;
					m_LineJustificationStack.Add(m_LineJustification);
					return true;
				default:
					return false;
				}
			case MarkupTag.SLASH_ALIGN:
				m_LineJustification = m_LineJustificationStack.Remove();
				return true;
			case MarkupTag.WIDTH:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_Width = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					return false;
				case TagUnitType.Percentage:
					m_Width = m_MarginWidth * num3 / 100f;
					break;
				}
				return true;
			case MarkupTag.SLASH_WIDTH:
				m_Width = -1f;
				return true;
			case MarkupTag.COLOR:
				if (textInfo != null)
				{
					textInfo.hasMultipleColors = true;
				}
				if (m_HtmlTag[6] == '#' || m_HtmlTag[7] == '#')
				{
					int num6 = num;
					if (m_HtmlTag[6] == '#')
					{
						startIndex = 6;
					}
					else
					{
						startIndex = 7;
						num6--;
					}
					m_HtmlColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, startIndex, num6 - startIndex);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				}
				switch (m_XmlAttribute[0].valueHashCode)
				{
				case 91635:
					m_HtmlColor = Color.red;
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 341063360:
					m_HtmlColor = new Color32(173, 216, 230, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2457214:
					m_HtmlColor = Color.blue;
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2638345:
					m_HtmlColor = new Color32(128, 128, 128, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 81074727:
					m_HtmlColor = Color.black;
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 87065851:
					m_HtmlColor = Color.green;
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 105680263:
					m_HtmlColor = Color.white;
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1108587920:
					m_HtmlColor = new Color32(byte.MaxValue, 128, 0, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1250222130:
					m_HtmlColor = new Color32(160, 32, 240, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -882444668:
					m_HtmlColor = Color.yellow;
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2947772:
					m_HtmlColor = new Color32(0, 128, 128, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2504597:
					m_HtmlColor = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1960309918:
					m_HtmlColor = new Color32(0, 0, 160, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1002715645:
					m_HtmlColor = new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -960329321:
					m_HtmlColor = new Color32(192, 192, 192, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 81017702:
					m_HtmlColor = new Color32(165, 42, 42, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1355621936:
					m_HtmlColor = new Color32(128, 0, 0, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 95492953:
					m_HtmlColor = new Color32(128, 128, 0, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2876352:
					m_HtmlColor = new Color32(0, 0, 128, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2284356:
					m_HtmlColor = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1812576107:
					m_HtmlColor = new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case 2656045:
					m_HtmlColor = new Color32(0, byte.MaxValue, 0, byte.MaxValue);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				case -1014785338:
					m_HtmlColor = new Color32(0, 0, 0, 0);
					m_ColorStack.Add(m_HtmlColor);
					return true;
				default:
					return false;
				}
			case MarkupTag.GRADIENT:
			{
				int valueHashCode5 = m_XmlAttribute[0].valueHashCode;
				if (MaterialReferenceManager.TryGetColorGradientPreset(valueHashCode5, out var gradientPreset))
				{
					m_ColorGradientPreset = gradientPreset;
				}
				else
				{
					if (gradientPreset == null)
					{
						if (!flag)
						{
							isThreadSuccess = false;
							return false;
						}
						gradientPreset = Resources.Load<TextColorGradient>(textSettings.defaultColorGradientPresetsPath + new string(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength));
					}
					if (gradientPreset == null)
					{
						return false;
					}
					MaterialReferenceManager.AddColorGradientPreset(valueHashCode5, gradientPreset);
					m_ColorGradientPreset = gradientPreset;
				}
				m_ColorGradientPresetIsTinted = false;
				for (int l = 1; l < m_XmlAttribute.Length && m_XmlAttribute[l].nameHashCode != 0; l++)
				{
					int nameHashCode3 = m_XmlAttribute[l].nameHashCode;
					MarkupTag markupTag = (MarkupTag)nameHashCode3;
					MarkupTag markupTag2 = markupTag;
					if (markupTag2 == MarkupTag.TINT)
					{
						m_ColorGradientPresetIsTinted = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[l].valueStartIndex, m_XmlAttribute[l].valueLength) != 0f;
					}
				}
				m_ColorGradientStack.Add(m_ColorGradientPreset);
				return true;
			}
			case MarkupTag.SLASH_GRADIENT:
				m_ColorGradientPreset = m_ColorGradientStack.Remove();
				return true;
			case MarkupTag.CHARACTER_SPACE:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_CSpacing = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_CSpacing = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
					return false;
				}
				return true;
			case MarkupTag.SLASH_CHARACTER_SPACE:
				if (!m_isTextLayoutPhase || textInfo == null)
				{
					return true;
				}
				if (m_CharacterCount > 0)
				{
					m_XAdvance -= m_CSpacing;
					textInfo.textElementInfo[m_CharacterCount - 1].xAdvance = m_XAdvance;
				}
				m_CSpacing = 0f;
				return true;
			case MarkupTag.MONOSPACE:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (m_XmlAttribute[0].unitType)
				{
				case TagUnitType.Pixels:
					m_MonoSpacing = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_MonoSpacing = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
					return false;
				}
				if (m_XmlAttribute[1].nameHashCode == 582810522)
				{
					m_DuoSpace = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength) != 0f;
				}
				return true;
			case MarkupTag.SLASH_MONOSPACE:
				m_MonoSpacing = 0f;
				m_DuoSpace = false;
				return true;
			case MarkupTag.CLASS:
				return false;
			case MarkupTag.SLASH_COLOR:
				m_HtmlColor = m_ColorStack.Remove();
				return true;
			case MarkupTag.INDENT:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_TagIndent = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_TagIndent = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
					m_TagIndent = m_MarginWidth * num3 / 100f;
					break;
				}
				m_IndentStack.Add(m_TagIndent);
				m_XAdvance = m_TagIndent;
				return true;
			case MarkupTag.SLASH_INDENT:
				m_TagIndent = m_IndentStack.Remove();
				return true;
			case MarkupTag.LINE_INDENT:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_TagLineIndent = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_TagLineIndent = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
					m_TagLineIndent = m_MarginWidth * num3 / 100f;
					break;
				}
				m_XAdvance += m_TagLineIndent;
				return true;
			case MarkupTag.SLASH_LINE_INDENT:
				m_TagLineIndent = 0f;
				return true;
			case MarkupTag.SPRITE:
			{
				int valueHashCode4 = m_XmlAttribute[0].valueHashCode;
				m_SpriteIndex = -1;
				SpriteAsset spriteAsset;
				if (m_XmlAttribute[0].valueType == TagValueType.None || m_XmlAttribute[0].valueType == TagValueType.NumericalValue)
				{
					if (textSettings.defaultSpriteAsset != null)
					{
						m_CurrentSpriteAsset = textSettings.defaultSpriteAsset;
					}
					else if (TextSettings.s_GlobalSpriteAsset != null)
					{
						m_CurrentSpriteAsset = TextSettings.s_GlobalSpriteAsset;
					}
					if (m_CurrentSpriteAsset == null)
					{
						return false;
					}
				}
				else if (MaterialReferenceManager.TryGetSpriteAsset(valueHashCode4, out spriteAsset))
				{
					m_CurrentSpriteAsset = spriteAsset;
				}
				else
				{
					if (spriteAsset == null && spriteAsset == null)
					{
						if (!flag)
						{
							isThreadSuccess = false;
							return false;
						}
						spriteAsset = Resources.Load<SpriteAsset>(textSettings.defaultSpriteAssetPath + new string(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength));
					}
					if (spriteAsset == null)
					{
						return false;
					}
					MaterialReferenceManager.AddSpriteAsset(valueHashCode4, spriteAsset);
					m_CurrentSpriteAsset = spriteAsset;
				}
				if (!flag && m_CurrentSpriteAsset.m_GlyphIndexLookup == null)
				{
					isThreadSuccess = false;
					return false;
				}
				if (m_XmlAttribute[0].valueType == TagValueType.NumericalValue)
				{
					int num8 = (int)TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
					if ((float)num8 == -32767f)
					{
						return false;
					}
					if (num8 > m_CurrentSpriteAsset.spriteCharacterTable.Count - 1)
					{
						return false;
					}
					m_SpriteIndex = num8;
				}
				m_SpriteColor = Color.white;
				m_TintSprite = false;
				for (int k = 0; k < m_XmlAttribute.Length && m_XmlAttribute[k].nameHashCode != 0; k++)
				{
					int nameHashCode2 = m_XmlAttribute[k].nameHashCode;
					int spriteIndex = 0;
					switch ((MarkupTag)nameHashCode2)
					{
					case MarkupTag.NAME:
						m_CurrentSpriteAsset = SpriteAsset.SearchForSpriteByHashCode(m_CurrentSpriteAsset, m_XmlAttribute[k].valueHashCode, includeFallbacks: true, out spriteIndex);
						if (spriteIndex == -1)
						{
							return false;
						}
						m_SpriteIndex = spriteIndex;
						break;
					case MarkupTag.INDEX:
						spriteIndex = (int)TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[1].valueStartIndex, m_XmlAttribute[1].valueLength);
						if ((float)spriteIndex == -32767f)
						{
							return false;
						}
						if (spriteIndex > m_CurrentSpriteAsset.spriteCharacterTable.Count - 1)
						{
							return false;
						}
						m_SpriteIndex = spriteIndex;
						break;
					case MarkupTag.TINT:
						m_TintSprite = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[k].valueStartIndex, m_XmlAttribute[k].valueLength) != 0f;
						break;
					case MarkupTag.COLOR:
						m_SpriteColor = TextGeneratorUtilities.HexCharsToColor(m_HtmlTag, m_XmlAttribute[k].valueStartIndex, m_XmlAttribute[k].valueLength);
						break;
					case MarkupTag.ANIM:
					{
						int attributeParameters = TextGeneratorUtilities.GetAttributeParameters(m_HtmlTag, m_XmlAttribute[k].valueStartIndex, m_XmlAttribute[k].valueLength, ref m_AttributeParameterValues);
						if (attributeParameters != 3)
						{
							return false;
						}
						m_SpriteIndex = (int)m_AttributeParameterValues[0];
						if (!m_isTextLayoutPhase)
						{
						}
						break;
					}
					default:
						if (nameHashCode2 != -991527447)
						{
							return false;
						}
						break;
					}
				}
				if (m_SpriteIndex == -1)
				{
					return false;
				}
				m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentSpriteAsset.material, m_CurrentSpriteAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
				m_TextElementType = TextElementType.Sprite;
				return true;
			}
			case MarkupTag.LOWERCASE:
				m_FontStyleInternal |= FontStyles.LowerCase;
				m_FontStyleStack.Add(FontStyles.LowerCase);
				return true;
			case MarkupTag.SLASH_LOWERCASE:
				if ((generationSettings.fontStyle & FontStyles.LowerCase) != FontStyles.LowerCase && m_FontStyleStack.Remove(FontStyles.LowerCase) == 0)
				{
					m_FontStyleInternal &= ~FontStyles.LowerCase;
				}
				return true;
			case MarkupTag.UPPERCASE:
			case MarkupTag.ALLCAPS:
				m_FontStyleInternal |= FontStyles.UpperCase;
				m_FontStyleStack.Add(FontStyles.UpperCase);
				return true;
			case MarkupTag.SLASH_ALLCAPS:
			case MarkupTag.SLASH_UPPERCASE:
				if ((generationSettings.fontStyle & FontStyles.UpperCase) != FontStyles.UpperCase && m_FontStyleStack.Remove(FontStyles.UpperCase) == 0)
				{
					m_FontStyleInternal &= ~FontStyles.UpperCase;
				}
				return true;
			case MarkupTag.SMALLCAPS:
				m_FontStyleInternal |= FontStyles.SmallCaps;
				m_FontStyleStack.Add(FontStyles.SmallCaps);
				return true;
			case MarkupTag.SLASH_SMALLCAPS:
				if ((generationSettings.fontStyle & FontStyles.SmallCaps) != FontStyles.SmallCaps && m_FontStyleStack.Remove(FontStyles.SmallCaps) == 0)
				{
					m_FontStyleInternal &= ~FontStyles.SmallCaps;
				}
				return true;
			case MarkupTag.MARGIN:
				switch (m_XmlAttribute[0].valueType)
				{
				case TagValueType.NumericalValue:
					num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
					if (num3 == -32767f)
					{
						return false;
					}
					switch (tagUnitType)
					{
					case TagUnitType.Pixels:
						m_MarginLeft = num3 * generationSettings.pixelsPerPoint;
						break;
					case TagUnitType.FontUnits:
						m_MarginLeft = num3 * m_CurrentFontSize;
						break;
					case TagUnitType.Percentage:
						m_MarginLeft = (m_MarginWidth - ((m_Width != -1f) ? m_Width : 0f)) * num3 / 100f;
						break;
					}
					m_MarginLeft = ((m_MarginLeft >= 0f) ? m_MarginLeft : 0f);
					m_MarginRight = m_MarginLeft;
					return true;
				case TagValueType.None:
				{
					for (int j = 1; j < m_XmlAttribute.Length && m_XmlAttribute[j].nameHashCode != 0; j++)
					{
						switch ((MarkupTag)m_XmlAttribute[j].nameHashCode)
						{
						case MarkupTag.LEFT:
							num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[j].valueStartIndex, m_XmlAttribute[j].valueLength);
							if (num3 == -32767f)
							{
								return false;
							}
							switch (m_XmlAttribute[j].unitType)
							{
							case TagUnitType.Pixels:
								m_MarginLeft = num3 * generationSettings.pixelsPerPoint;
								break;
							case TagUnitType.FontUnits:
								m_MarginLeft = num3 * m_CurrentFontSize;
								break;
							case TagUnitType.Percentage:
								m_MarginLeft = (m_MarginWidth - ((m_Width != -1f) ? m_Width : 0f)) * num3 / 100f;
								break;
							}
							m_MarginLeft = ((m_MarginLeft >= 0f) ? m_MarginLeft : 0f);
							break;
						case MarkupTag.RIGHT:
							num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[j].valueStartIndex, m_XmlAttribute[j].valueLength);
							if (num3 == -32767f)
							{
								return false;
							}
							switch (m_XmlAttribute[j].unitType)
							{
							case TagUnitType.Pixels:
								m_MarginRight = num3 * generationSettings.pixelsPerPoint;
								break;
							case TagUnitType.FontUnits:
								m_MarginRight = num3 * m_CurrentFontSize;
								break;
							case TagUnitType.Percentage:
								m_MarginRight = (m_MarginWidth - ((m_Width != -1f) ? m_Width : 0f)) * num3 / 100f;
								break;
							}
							m_MarginRight = ((m_MarginRight >= 0f) ? m_MarginRight : 0f);
							break;
						}
					}
					return true;
				}
				default:
					return false;
				}
			case MarkupTag.SLASH_MARGIN:
				m_MarginLeft = 0f;
				m_MarginRight = 0f;
				return true;
			case MarkupTag.MARGIN_LEFT:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_MarginLeft = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_MarginLeft = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
					m_MarginLeft = (m_MarginWidth - ((m_Width != -1f) ? m_Width : 0f)) * num3 / 100f;
					break;
				}
				m_MarginLeft = ((m_MarginLeft >= 0f) ? m_MarginLeft : 0f);
				return true;
			case MarkupTag.MARGIN_RIGHT:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_MarginRight = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_MarginRight = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
					m_MarginRight = (m_MarginWidth - ((m_Width != -1f) ? m_Width : 0f)) * num3 / 100f;
					break;
				}
				m_MarginRight = ((m_MarginRight >= 0f) ? m_MarginRight : 0f);
				return true;
			case MarkupTag.LINE_HEIGHT:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				switch (tagUnitType)
				{
				case TagUnitType.Pixels:
					m_LineHeight = num3 * generationSettings.pixelsPerPoint;
					break;
				case TagUnitType.FontUnits:
					m_LineHeight = num3 * m_CurrentFontSize;
					break;
				case TagUnitType.Percentage:
				{
					float num7 = m_CurrentFontSize / m_CurrentFontAsset.faceInfo.pointSize * m_CurrentFontAsset.faceInfo.scale;
					m_LineHeight = generationSettings.fontAsset.faceInfo.lineHeight * num3 / 100f * num7;
					break;
				}
				}
				return true;
			case MarkupTag.SLASH_LINE_HEIGHT:
				m_LineHeight = -32767f;
				return true;
			case MarkupTag.NO_PARSE:
				m_TagNoParsing = true;
				return true;
			case MarkupTag.ACTION:
			{
				int valueHashCode2 = m_XmlAttribute[0].valueHashCode;
				if (m_isTextLayoutPhase)
				{
					m_ActionStack.Add(valueHashCode2);
					Debug.Log("Action ID: [" + valueHashCode2 + "] First character index: " + m_CharacterCount);
				}
				return true;
			}
			case MarkupTag.SLASH_ACTION:
				if (m_isTextLayoutPhase)
				{
					Debug.Log("Action ID: [" + m_ActionStack.CurrentItem() + "] Last character index: " + (m_CharacterCount - 1));
				}
				m_ActionStack.Remove();
				return true;
			case MarkupTag.SCALE:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				m_FXScale = new Vector3(num3, 1f, 1f);
				return true;
			case MarkupTag.SLASH_SCALE:
				m_FXScale = Vector3.one;
				return true;
			case MarkupTag.ROTATE:
				num3 = TextGeneratorUtilities.ConvertToFloat(m_HtmlTag, m_XmlAttribute[0].valueStartIndex, m_XmlAttribute[0].valueLength);
				if (num3 == -32767f)
				{
					return false;
				}
				m_FXRotation = Quaternion.Euler(0f, 0f, num3);
				return true;
			case MarkupTag.SLASH_ROTATE:
				m_FXRotation = Quaternion.identity;
				return true;
			case MarkupTag.TABLE:
				return false;
			case MarkupTag.SLASH_TABLE:
				return false;
			case MarkupTag.TR:
				return false;
			case MarkupTag.SLASH_TR:
				return false;
			case MarkupTag.TH:
				return false;
			case MarkupTag.SLASH_TH:
				return false;
			case MarkupTag.TD:
				return false;
			case MarkupTag.SLASH_TD:
				return false;
			default:
				return false;
			}
		}

		internal void CloseLastLinkTag(TextInfo textInfo)
		{
			if (textInfo.linkInfo.Length != 0 && textInfo.linkCount > 0)
			{
				CloseLinkTag(textInfo, textInfo.linkCount - 1);
			}
		}

		internal void CloseAllLinkTags(TextInfo textInfo)
		{
			for (int num = textInfo.linkCount - 1; num >= 0; num--)
			{
				CloseLinkTag(textInfo, num);
			}
		}

		private void CloseLinkTag(TextInfo textInfo, int index)
		{
			if (textInfo.linkInfo[index].linkTextLength == -1)
			{
				textInfo.linkInfo[index].linkTextLength = m_CharacterCount - textInfo.linkInfo[index].linkTextfirstCharacterIndex;
			}
		}

		private void ClearMarkupTagAttributes()
		{
			int num = m_XmlAttribute.Length;
			for (int i = 0; i < num; i++)
			{
				m_XmlAttribute[i] = default(RichTextTagAttribute);
			}
		}

		private void SaveWordWrappingState(ref WordWrapState state, int index, int count, TextInfo textInfo)
		{
			state.currentFontAsset = m_CurrentFontAsset;
			state.currentSpriteAsset = m_CurrentSpriteAsset;
			state.currentMaterial = m_CurrentMaterial;
			state.currentMaterialIndex = m_CurrentMaterialIndex;
			state.previousWordBreak = index;
			state.totalCharacterCount = count;
			state.visibleCharacterCount = m_LineVisibleCharacterCount;
			state.visibleSpaceCount = m_LineVisibleSpaceCount;
			state.visibleLinkCount = textInfo.linkCount;
			state.firstCharacterIndex = m_FirstCharacterOfLine;
			state.firstVisibleCharacterIndex = m_FirstVisibleCharacterOfLine;
			state.lastVisibleCharIndex = m_LastVisibleCharacterOfLine;
			state.fontStyle = m_FontStyleInternal;
			state.italicAngle = m_ItalicAngle;
			state.fontScaleMultiplier = m_FontScaleMultiplier;
			state.currentFontSize = m_CurrentFontSize;
			state.xAdvance = m_XAdvance;
			state.maxCapHeight = m_MaxCapHeight;
			state.maxAscender = m_MaxAscender;
			state.maxDescender = m_MaxDescender;
			state.maxLineAscender = m_MaxLineAscender;
			state.maxLineDescender = m_MaxLineDescender;
			state.startOfLineAscender = m_StartOfLineAscender;
			state.preferredWidth = m_PreferredWidth;
			state.preferredHeight = m_PreferredHeight;
			state.meshExtents = m_MeshExtents;
			state.pageAscender = m_PageAscender;
			state.lineNumber = m_LineNumber;
			state.lineOffset = m_LineOffset;
			state.baselineOffset = m_BaselineOffset;
			state.isDrivenLineSpacing = m_IsDrivenLineSpacing;
			state.vertexColor = m_HtmlColor;
			state.underlineColor = m_UnderlineColor;
			state.strikethroughColor = m_StrikethroughColor;
			state.highlightColor = m_HighlightColor;
			state.highlightState = m_HighlightState;
			state.isNonBreakingSpace = m_IsNonBreakingSpace;
			state.tagNoParsing = m_TagNoParsing;
			state.fxScale = m_FXScale;
			state.fxRotation = m_FXRotation;
			state.basicStyleStack = m_FontStyleStack;
			state.italicAngleStack = m_ItalicAngleStack;
			state.colorStack = m_ColorStack;
			state.underlineColorStack = m_UnderlineColorStack;
			state.strikethroughColorStack = m_StrikethroughColorStack;
			state.highlightColorStack = m_HighlightColorStack;
			state.colorGradientStack = m_ColorGradientStack;
			state.highlightStateStack = m_HighlightStateStack;
			state.sizeStack = m_SizeStack;
			state.indentStack = m_IndentStack;
			state.fontWeightStack = m_FontWeightStack;
			state.styleStack = m_StyleStack;
			state.baselineStack = m_BaselineOffsetStack;
			state.actionStack = m_ActionStack;
			state.materialReferenceStack = m_MaterialReferenceStack;
			state.lineJustificationStack = m_LineJustificationStack;
			state.lastBaseGlyphIndex = m_LastBaseGlyphIndex;
			state.spriteAnimationId = m_SpriteAnimationId;
			if (m_LineNumber < textInfo.lineInfo.Length)
			{
				state.lineInfo = textInfo.lineInfo[m_LineNumber];
			}
		}

		private int RestoreWordWrappingState(ref WordWrapState state, TextInfo textInfo)
		{
			int previousWordBreak = state.previousWordBreak;
			m_CurrentFontAsset = state.currentFontAsset;
			m_CurrentSpriteAsset = state.currentSpriteAsset;
			m_CurrentMaterial = state.currentMaterial;
			m_CurrentMaterialIndex = state.currentMaterialIndex;
			m_CharacterCount = state.totalCharacterCount + 1;
			m_LineVisibleCharacterCount = state.visibleCharacterCount;
			m_LineVisibleSpaceCount = state.visibleSpaceCount;
			textInfo.linkCount = state.visibleLinkCount;
			m_FirstCharacterOfLine = state.firstCharacterIndex;
			m_FirstVisibleCharacterOfLine = state.firstVisibleCharacterIndex;
			m_LastVisibleCharacterOfLine = state.lastVisibleCharIndex;
			m_FontStyleInternal = state.fontStyle;
			m_ItalicAngle = state.italicAngle;
			m_FontScaleMultiplier = state.fontScaleMultiplier;
			m_CurrentFontSize = state.currentFontSize;
			m_XAdvance = state.xAdvance;
			m_MaxCapHeight = state.maxCapHeight;
			m_MaxAscender = state.maxAscender;
			m_MaxDescender = state.maxDescender;
			m_MaxLineAscender = state.maxLineAscender;
			m_MaxLineDescender = state.maxLineDescender;
			m_StartOfLineAscender = state.startOfLineAscender;
			m_PreferredWidth = state.preferredWidth;
			m_PreferredHeight = state.preferredHeight;
			m_MeshExtents = state.meshExtents;
			m_PageAscender = state.pageAscender;
			m_LineNumber = state.lineNumber;
			m_LineOffset = state.lineOffset;
			m_BaselineOffset = state.baselineOffset;
			m_IsDrivenLineSpacing = state.isDrivenLineSpacing;
			m_HtmlColor = state.vertexColor;
			m_UnderlineColor = state.underlineColor;
			m_StrikethroughColor = state.strikethroughColor;
			m_HighlightColor = state.highlightColor;
			m_HighlightState = state.highlightState;
			m_IsNonBreakingSpace = state.isNonBreakingSpace;
			m_TagNoParsing = state.tagNoParsing;
			m_FXScale = state.fxScale;
			m_FXRotation = state.fxRotation;
			m_FontStyleStack = state.basicStyleStack;
			m_ItalicAngleStack = state.italicAngleStack;
			m_ColorStack = state.colorStack;
			m_UnderlineColorStack = state.underlineColorStack;
			m_StrikethroughColorStack = state.strikethroughColorStack;
			m_HighlightColorStack = state.highlightColorStack;
			m_ColorGradientStack = state.colorGradientStack;
			m_HighlightStateStack = state.highlightStateStack;
			m_SizeStack = state.sizeStack;
			m_IndentStack = state.indentStack;
			m_FontWeightStack = state.fontWeightStack;
			m_StyleStack = state.styleStack;
			m_BaselineOffsetStack = state.baselineStack;
			m_ActionStack = state.actionStack;
			m_MaterialReferenceStack = state.materialReferenceStack;
			m_LineJustificationStack = state.lineJustificationStack;
			m_LastBaseGlyphIndex = state.lastBaseGlyphIndex;
			m_SpriteAnimationId = state.spriteAnimationId;
			if (m_LineNumber < textInfo.lineInfo.Length)
			{
				textInfo.lineInfo[m_LineNumber] = state.lineInfo;
			}
			return previousWordBreak;
		}

		private void SaveGlyphVertexInfo(float padding, float stylePadding, Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.position = textInfo.textElementInfo[m_CharacterCount].bottomLeft;
			textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.position = textInfo.textElementInfo[m_CharacterCount].topLeft;
			textInfo.textElementInfo[m_CharacterCount].vertexTopRight.position = textInfo.textElementInfo[m_CharacterCount].topRight;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.position = textInfo.textElementInfo[m_CharacterCount].bottomRight;
			vertexColor.a = ((m_FontColor32.a < vertexColor.a) ? m_FontColor32.a : vertexColor.a);
			bool flag = (m_CurrentFontAsset.m_AtlasRenderMode & (GlyphRenderMode)65536) == (GlyphRenderMode)65536;
			vertexColor = (flag ? new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, vertexColor.a) : vertexColor);
			textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.color = vertexColor;
			textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.color = vertexColor;
			textInfo.textElementInfo[m_CharacterCount].vertexTopRight.color = vertexColor;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.color = vertexColor;
			if (m_ColorGradientPreset != null && !flag)
			{
				if (m_ColorGradientPresetIsTinted)
				{
					ref Color32 color = ref textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.color;
					color *= m_ColorGradientPreset.bottomLeft;
					ref Color32 color2 = ref textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.color;
					color2 *= m_ColorGradientPreset.topLeft;
					ref Color32 color3 = ref textInfo.textElementInfo[m_CharacterCount].vertexTopRight.color;
					color3 *= m_ColorGradientPreset.topRight;
					ref Color32 color4 = ref textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.color;
					color4 *= m_ColorGradientPreset.bottomRight;
				}
				else
				{
					textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.color = m_ColorGradientPreset.bottomLeft.MinAlpha(vertexColor);
					textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.color = m_ColorGradientPreset.topLeft.MinAlpha(vertexColor);
					textInfo.textElementInfo[m_CharacterCount].vertexTopRight.color = m_ColorGradientPreset.topRight.MinAlpha(vertexColor);
					textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.color = m_ColorGradientPreset.bottomRight.MinAlpha(vertexColor);
				}
			}
			stylePadding = 0f;
			GlyphRect glyphRect = textInfo.textElementInfo[m_CharacterCount].alternativeGlyph?.glyphRect ?? m_CachedTextElement.m_Glyph.glyphRect;
			Vector2 vector = default(Vector2);
			vector.x = ((float)glyphRect.x - padding - stylePadding) / (float)m_CurrentFontAsset.atlasWidth;
			vector.y = ((float)glyphRect.y - padding - stylePadding) / (float)m_CurrentFontAsset.atlasHeight;
			Vector2 vector2 = default(Vector2);
			vector2.x = vector.x;
			vector2.y = ((float)glyphRect.y + padding + stylePadding + (float)glyphRect.height) / (float)m_CurrentFontAsset.atlasHeight;
			Vector2 vector3 = default(Vector2);
			vector3.x = ((float)glyphRect.x + padding + stylePadding + (float)glyphRect.width) / (float)m_CurrentFontAsset.atlasWidth;
			vector3.y = vector2.y;
			Vector2 vector4 = default(Vector2);
			vector4.x = vector3.x;
			vector4.y = vector.y;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.uv = vector;
			textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.uv = vector2;
			textInfo.textElementInfo[m_CharacterCount].vertexTopRight.uv = vector3;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.uv = vector4;
		}

		private void SaveSpriteVertexInfo(Color32 vertexColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.position = textInfo.textElementInfo[m_CharacterCount].bottomLeft;
			textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.position = textInfo.textElementInfo[m_CharacterCount].topLeft;
			textInfo.textElementInfo[m_CharacterCount].vertexTopRight.position = textInfo.textElementInfo[m_CharacterCount].topRight;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.position = textInfo.textElementInfo[m_CharacterCount].bottomRight;
			Color32 color = (m_TintSprite ? ColorUtilities.MultiplyColors(m_SpriteColor, vertexColor) : m_SpriteColor);
			color.a = ((color.a >= m_FontColor32.a) ? m_FontColor32.a : ((color.a < vertexColor.a) ? color.a : vertexColor.a));
			Color32 color2 = color;
			Color32 color3 = color;
			Color32 color4 = color;
			Color32 color5 = color;
			if (m_ColorGradientPreset != null)
			{
				color2 = (m_TintSprite ? ColorUtilities.MultiplyColors(color2, m_ColorGradientPreset.bottomLeft) : color2);
				color3 = (m_TintSprite ? ColorUtilities.MultiplyColors(color3, m_ColorGradientPreset.topLeft) : color3);
				color4 = (m_TintSprite ? ColorUtilities.MultiplyColors(color4, m_ColorGradientPreset.topRight) : color4);
				color5 = (m_TintSprite ? ColorUtilities.MultiplyColors(color5, m_ColorGradientPreset.bottomRight) : color5);
			}
			m_TintSprite = false;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.color = color2;
			textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.color = color3;
			textInfo.textElementInfo[m_CharacterCount].vertexTopRight.color = color4;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.color = color5;
			Vector2 vector = new Vector2((float)m_CachedTextElement.glyph.glyphRect.x / m_CurrentSpriteAsset.width, (float)m_CachedTextElement.glyph.glyphRect.y / m_CurrentSpriteAsset.height);
			Vector2 vector2 = new Vector2(vector.x, (float)(m_CachedTextElement.glyph.glyphRect.y + m_CachedTextElement.glyph.glyphRect.height) / m_CurrentSpriteAsset.height);
			Vector2 vector3 = new Vector2((float)(m_CachedTextElement.glyph.glyphRect.x + m_CachedTextElement.glyph.glyphRect.width) / m_CurrentSpriteAsset.width, vector2.y);
			Vector2 vector4 = new Vector2(vector3.x, vector.y);
			textInfo.textElementInfo[m_CharacterCount].vertexBottomLeft.uv = vector;
			textInfo.textElementInfo[m_CharacterCount].vertexTopLeft.uv = vector2;
			textInfo.textElementInfo[m_CharacterCount].vertexTopRight.uv = vector3;
			textInfo.textElementInfo[m_CharacterCount].vertexBottomRight.uv = vector4;
		}

		private void DrawUnderlineMesh(Vector3 start, Vector3 end, float startScale, float endScale, float maxScale, float sdfScale, Color32 underlineColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			GetUnderlineSpecialCharacter(generationSettings);
			if (m_Underline.character == null)
			{
				if (generationSettings.textSettings.displayWarnings)
				{
					Debug.LogWarning("Unable to add underline or strikethrough since the character [0x5F] used by these features is not present in the Font Asset assigned to this text object.");
				}
				return;
			}
			int materialIndex = m_Underline.materialIndex;
			int vertexCount = textInfo.meshInfo[materialIndex].vertexCount;
			int num = vertexCount + 12;
			if (num > textInfo.meshInfo[materialIndex].vertexBufferSize)
			{
				textInfo.meshInfo[materialIndex].ResizeMeshInfo(num / 4, generationSettings.isIMGUI);
			}
			start.y = Mathf.Min(start.y, end.y);
			end.y = Mathf.Min(start.y, end.y);
			GlyphMetrics metrics = m_Underline.character.glyph.metrics;
			GlyphRect glyphRect = m_Underline.character.glyph.glyphRect;
			float underlineThickness = m_Underline.fontAsset.faceInfo.underlineThickness;
			start.x += (startScale - maxScale) * m_Padding;
			end.x += (maxScale - endScale) * m_Padding;
			float num2 = (metrics.width * 0.5f + m_Padding) * maxScale;
			float num3 = 1f;
			float num4 = 2f * num2;
			float num5 = end.x - start.x;
			if (num5 < num4)
			{
				num3 = num5 / num4;
				num2 *= num3;
			}
			TextCoreVertex[] vertexData = textInfo.meshInfo[materialIndex].vertexData;
			float x = start.x;
			float x2 = start.x + num2;
			float x3 = end.x - num2;
			float x4 = end.x;
			float y = start.y - (underlineThickness + m_Padding) * maxScale;
			float y2 = start.y + m_Padding * maxScale;
			vertexData[vertexCount].position = new Vector3(x, y);
			vertexData[vertexCount + 1].position = new Vector3(x, y2);
			vertexData[vertexCount + 2].position = new Vector3(x2, y2);
			vertexData[vertexCount + 3].position = new Vector3(x2, y);
			vertexData[vertexCount + 4].position = new Vector3(x2, y);
			vertexData[vertexCount + 5].position = new Vector3(x2, y2);
			vertexData[vertexCount + 6].position = new Vector3(x3, y2);
			vertexData[vertexCount + 7].position = new Vector3(x3, y);
			vertexData[vertexCount + 8].position = new Vector3(x3, y);
			vertexData[vertexCount + 9].position = new Vector3(x3, y2);
			vertexData[vertexCount + 10].position = new Vector3(x4, y2);
			vertexData[vertexCount + 11].position = new Vector3(x4, y);
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			vector.y = generationSettings.screenRect.height;
			vector.z = 0f;
			for (int i = 0; i < 12; i++)
			{
				textInfo.meshInfo[materialIndex].vertexData[vertexCount + i].position.y = textInfo.meshInfo[materialIndex].vertexData[vertexCount + i].position.y * -1f + vector.y;
			}
			float num6 = 1f / (float)m_Underline.fontAsset.atlasWidth;
			float num7 = 1f / (float)m_Underline.fontAsset.atlasHeight;
			float num8 = ((float)glyphRect.width * 0.5f + m_Padding) * num3 * num6;
			float num9 = ((float)glyphRect.x - m_Padding) * num6;
			float x5 = num9 + num8;
			float x6 = ((float)glyphRect.x + (float)glyphRect.width * 0.5f) * num6;
			float num10 = ((float)(glyphRect.x + glyphRect.width) + m_Padding) * num6;
			float x7 = num10 - num8;
			float y3 = ((float)glyphRect.y - m_Padding) * num7;
			float y4 = ((float)(glyphRect.y + glyphRect.height) + m_Padding) * num7;
			vertexData[vertexCount].uv0 = new Vector4(num9, y3);
			vertexData[1 + vertexCount].uv0 = new Vector4(num9, y4);
			vertexData[2 + vertexCount].uv0 = new Vector4(x5, y4);
			vertexData[3 + vertexCount].uv0 = new Vector4(x5, y3);
			vertexData[4 + vertexCount].uv0 = new Vector4(x6, y3);
			vertexData[5 + vertexCount].uv0 = new Vector4(x6, y4);
			vertexData[6 + vertexCount].uv0 = new Vector4(x6, y4);
			vertexData[7 + vertexCount].uv0 = new Vector4(x6, y3);
			vertexData[8 + vertexCount].uv0 = new Vector4(x7, y3);
			vertexData[9 + vertexCount].uv0 = new Vector4(x7, y4);
			vertexData[10 + vertexCount].uv0 = new Vector4(num10, y4);
			vertexData[11 + vertexCount].uv0 = new Vector4(num10, y3);
			float num11 = 0f;
			float num12 = 1f / num5;
			float x8 = (vertexData[vertexCount + 2].position.x - start.x) * num12;
			vertexData[vertexCount].uv2 = new Vector2(0f, 0f);
			vertexData[1 + vertexCount].uv2 = new Vector2(0f, 1f);
			vertexData[2 + vertexCount].uv2 = new Vector2(x8, 1f);
			vertexData[3 + vertexCount].uv2 = new Vector2(x8, 0f);
			num11 = (vertexData[vertexCount + 4].position.x - start.x) * num12;
			x8 = (vertexData[vertexCount + 6].position.x - start.x) * num12;
			vertexData[4 + vertexCount].uv2 = new Vector2(num11, 0f);
			vertexData[5 + vertexCount].uv2 = new Vector2(num11, 1f);
			vertexData[6 + vertexCount].uv2 = new Vector2(x8, 1f);
			vertexData[7 + vertexCount].uv2 = new Vector2(x8, 0f);
			num11 = (vertexData[vertexCount + 8].position.x - start.x) * num12;
			vertexData[8 + vertexCount].uv2 = new Vector2(num11, 0f);
			vertexData[9 + vertexCount].uv2 = new Vector2(num11, 1f);
			vertexData[10 + vertexCount].uv2 = new Vector2(1f, 1f);
			vertexData[11 + vertexCount].uv2 = new Vector2(1f, 0f);
			underlineColor.a = ((m_FontColor32.a < underlineColor.a) ? m_FontColor32.a : underlineColor.a);
			for (int j = 0; j < 12; j++)
			{
				vertexData[j + vertexCount].color = underlineColor;
			}
			textInfo.meshInfo[materialIndex].vertexCount += 12;
		}

		private void DrawTextHighlight(Vector3 start, Vector3 end, Color32 highlightColor, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			GetUnderlineSpecialCharacter(generationSettings);
			if (m_Underline.character == null)
			{
				if (generationSettings.textSettings.displayWarnings)
				{
					Debug.LogWarning("Unable to add highlight since the primary Font Asset doesn't contain the underline character.");
				}
				return;
			}
			int vertexCount = textInfo.meshInfo[m_CurrentMaterialIndex].vertexCount;
			int num = vertexCount + 4;
			if (num > textInfo.meshInfo[m_CurrentMaterialIndex].vertexBufferSize)
			{
				textInfo.meshInfo[m_CurrentMaterialIndex].ResizeMeshInfo(num / 4, generationSettings.isIMGUI);
			}
			TextCoreVertex[] vertexData = textInfo.meshInfo[m_CurrentMaterialIndex].vertexData;
			vertexData[vertexCount].position = start;
			vertexData[vertexCount + 1].position = new Vector3(start.x, end.y, 0f);
			vertexData[vertexCount + 2].position = end;
			vertexData[vertexCount + 3].position = new Vector3(end.x, start.y, 0f);
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			vector.y = generationSettings.screenRect.height;
			vector.z = 0f;
			for (int i = 0; i < 4; i++)
			{
				vertexData[vertexCount + i].position.y = vertexData[vertexCount + i].position.y * -1f + vector.y;
			}
			int atlasWidth = m_Underline.fontAsset.atlasWidth;
			int atlasHeight = m_Underline.fontAsset.atlasHeight;
			GlyphRect glyphRect = m_Underline.character.glyph.glyphRect;
			Vector2 vector2 = new Vector2(((float)glyphRect.x + (float)glyphRect.width / 2f) / (float)atlasWidth, ((float)glyphRect.y + (float)glyphRect.height / 2f) / (float)atlasHeight);
			Vector2 vector3 = new Vector2(1f / (float)atlasWidth, 1f / (float)atlasHeight);
			vertexData[vertexCount].uv0 = vector2 - vector3;
			vertexData[1 + vertexCount].uv0 = vector2 + new Vector2(0f - vector3.x, vector3.y);
			vertexData[2 + vertexCount].uv0 = vector2 + vector3;
			vertexData[3 + vertexCount].uv0 = vector2 + new Vector2(vector3.x, 0f - vector3.y);
			Vector2 uv = new Vector2(0f, 1f);
			vertexData[vertexCount].uv2 = uv;
			vertexData[1 + vertexCount].uv2 = uv;
			vertexData[2 + vertexCount].uv2 = uv;
			vertexData[3 + vertexCount].uv2 = uv;
			highlightColor.a = ((m_FontColor32.a < highlightColor.a) ? m_FontColor32.a : highlightColor.a);
			vertexData[vertexCount].color = highlightColor;
			vertexData[1 + vertexCount].color = highlightColor;
			vertexData[2 + vertexCount].color = highlightColor;
			vertexData[3 + vertexCount].color = highlightColor;
			textInfo.meshInfo[m_CurrentMaterialIndex].vertexCount += 4;
		}

		private static void ClearMesh(bool updateMesh, TextInfo textInfo)
		{
			textInfo.ClearMeshInfo(updateMesh);
		}

		public void LayoutPhase(TextInfo textInfo, TextGenerationSettings generationSettings, float maxVisibleDescender)
		{
			int underlineVertexIndex = m_MaterialReferences[m_Underline.materialIndex].referenceCount * 4;
			textInfo.meshInfo[m_CurrentMaterialIndex].Clear(uploadChanges: false);
			Vector3 vector = Vector3.zero;
			Vector3[] rectTransformCorners = m_RectTransformCorners;
			switch (generationSettings.textAlignment)
			{
			case TextAlignment.TopLeft:
			case TextAlignment.TopCenter:
			case TextAlignment.TopRight:
			case TextAlignment.TopJustified:
			case TextAlignment.TopFlush:
			case TextAlignment.TopGeoAligned:
				vector = rectTransformCorners[1] + new Vector3(0f, 0f - m_MaxAscender, 0f);
				break;
			case TextAlignment.MiddleLeft:
			case TextAlignment.MiddleCenter:
			case TextAlignment.MiddleRight:
			case TextAlignment.MiddleJustified:
			case TextAlignment.MiddleFlush:
			case TextAlignment.MiddleGeoAligned:
				vector = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f, 0f - (m_MaxAscender + maxVisibleDescender) / 2f, 0f);
				break;
			case TextAlignment.BottomLeft:
			case TextAlignment.BottomCenter:
			case TextAlignment.BottomRight:
			case TextAlignment.BottomJustified:
			case TextAlignment.BottomFlush:
			case TextAlignment.BottomGeoAligned:
				vector = rectTransformCorners[0] + new Vector3(0f, 0f - maxVisibleDescender, 0f);
				break;
			case TextAlignment.BaselineLeft:
			case TextAlignment.BaselineCenter:
			case TextAlignment.BaselineRight:
			case TextAlignment.BaselineJustified:
			case TextAlignment.BaselineFlush:
			case TextAlignment.BaselineGeoAligned:
				vector = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f, 0f, 0f);
				break;
			case TextAlignment.MidlineLeft:
			case TextAlignment.MidlineCenter:
			case TextAlignment.MidlineRight:
			case TextAlignment.MidlineJustified:
			case TextAlignment.MidlineFlush:
			case TextAlignment.MidlineGeoAligned:
				vector = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f, 0f - (m_MeshExtents.max.y + m_MeshExtents.min.y) / 2f, 0f);
				break;
			case TextAlignment.CaplineLeft:
			case TextAlignment.CaplineCenter:
			case TextAlignment.CaplineRight:
			case TextAlignment.CaplineJustified:
			case TextAlignment.CaplineFlush:
			case TextAlignment.CaplineGeoAligned:
				vector = (rectTransformCorners[0] + rectTransformCorners[1]) / 2f + new Vector3(0f, 0f - m_MaxCapHeight / 2f, 0f);
				break;
			}
			Vector3 vector2 = Vector3.zero;
			Vector3 zero = Vector3.zero;
			int num = 0;
			int lineCount = 0;
			int num2 = 0;
			bool flag = false;
			bool flag2 = false;
			int num3 = 0;
			int num4 = 0;
			Color32 color = Color.white;
			Color32 underlineColor = Color.white;
			HighlightState highlightState = new HighlightState(new Color32(byte.MaxValue, byte.MaxValue, 0, 64), Offset.zero);
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 32767f;
			float num11 = 0f;
			float num12 = 0f;
			float b = 0f;
			bool flag3 = false;
			Vector3 start = Vector3.zero;
			Vector3 zero2 = Vector3.zero;
			bool flag4 = false;
			Vector3 start2 = Vector3.zero;
			Vector3 zero3 = Vector3.zero;
			bool flag5 = false;
			Vector3 start3 = Vector3.zero;
			Vector3 end = Vector3.zero;
			TextElementInfo[] textElementInfo = textInfo.textElementInfo;
			for (int i = 0; i < m_CharacterCount; i++)
			{
				FontAsset fontAsset = textElementInfo[i].fontAsset;
				char c = (char)textElementInfo[i].character;
				bool flag6 = char.IsWhiteSpace(c);
				int lineNumber = textElementInfo[i].lineNumber;
				LineInfo lineInfo = textInfo.lineInfo[lineNumber];
				lineCount = lineNumber + 1;
				TextAlignment alignment = lineInfo.alignment;
				switch (alignment)
				{
				case TextAlignment.TopLeft:
				case TextAlignment.MiddleLeft:
				case TextAlignment.BottomLeft:
				case TextAlignment.BaselineLeft:
				case TextAlignment.MidlineLeft:
				case TextAlignment.CaplineLeft:
					vector2 = (generationSettings.isRightToLeft ? new Vector3(0f - lineInfo.maxAdvance, 0f, 0f) : new Vector3(0f + lineInfo.marginLeft, 0f, 0f));
					break;
				case TextAlignment.TopCenter:
				case TextAlignment.MiddleCenter:
				case TextAlignment.BottomCenter:
				case TextAlignment.BaselineCenter:
				case TextAlignment.MidlineCenter:
				case TextAlignment.CaplineCenter:
					vector2 = new Vector3(lineInfo.marginLeft + lineInfo.width / 2f - lineInfo.maxAdvance / 2f, 0f, 0f);
					break;
				case TextAlignment.TopGeoAligned:
				case TextAlignment.MiddleGeoAligned:
				case TextAlignment.BottomGeoAligned:
				case TextAlignment.BaselineGeoAligned:
				case TextAlignment.MidlineGeoAligned:
				case TextAlignment.CaplineGeoAligned:
					vector2 = new Vector3(lineInfo.marginLeft + lineInfo.width / 2f - (lineInfo.lineExtents.min.x + lineInfo.lineExtents.max.x) / 2f, 0f, 0f);
					break;
				case TextAlignment.TopRight:
				case TextAlignment.MiddleRight:
				case TextAlignment.BottomRight:
				case TextAlignment.BaselineRight:
				case TextAlignment.MidlineRight:
				case TextAlignment.CaplineRight:
					vector2 = (generationSettings.isRightToLeft ? new Vector3(lineInfo.marginLeft + lineInfo.width, 0f, 0f) : new Vector3(lineInfo.marginLeft + lineInfo.width - lineInfo.maxAdvance, 0f, 0f));
					break;
				case TextAlignment.TopJustified:
				case TextAlignment.TopFlush:
				case TextAlignment.MiddleJustified:
				case TextAlignment.MiddleFlush:
				case TextAlignment.BottomJustified:
				case TextAlignment.BottomFlush:
				case TextAlignment.BaselineJustified:
				case TextAlignment.BaselineFlush:
				case TextAlignment.MidlineJustified:
				case TextAlignment.MidlineFlush:
				case TextAlignment.CaplineJustified:
				case TextAlignment.CaplineFlush:
				{
					if (i > lineInfo.lastVisibleCharacterIndex || c == '\n' || c == '\u00ad' || c == '\u200b' || c == '\u2060' || c == '\u0003')
					{
						break;
					}
					char c2 = (char)textElementInfo[lineInfo.lastCharacterIndex].character;
					bool flag7 = (alignment & (TextAlignment)16) == (TextAlignment)16;
					if ((!char.IsControl(c2) && lineNumber < m_LineNumber) || flag7 || lineInfo.maxAdvance > lineInfo.width)
					{
						if (lineNumber != num2 || i == 0 || i == 0)
						{
							vector2 = (generationSettings.isRightToLeft ? new Vector3(lineInfo.marginLeft + lineInfo.width, 0f, 0f) : new Vector3(lineInfo.marginLeft, 0f, 0f));
							flag = (char.IsSeparator(c) ? true : false);
							break;
						}
						float num13 = (generationSettings.isRightToLeft ? (lineInfo.width + lineInfo.maxAdvance) : (lineInfo.width - lineInfo.maxAdvance));
						int num14 = lineInfo.visibleCharacterCount - 1 + lineInfo.controlCharacterCount;
						int num15 = lineInfo.visibleSpaceCount - lineInfo.controlCharacterCount;
						if (flag)
						{
							num15--;
							num14++;
						}
						float num16 = ((num15 > 0) ? 0.4f : 1f);
						if (num15 < 1)
						{
							num15 = 1;
						}
						if (c != '\u00a0' && (c == '\t' || char.IsSeparator(c)))
						{
							if (!generationSettings.isRightToLeft)
							{
								vector2 += new Vector3(num13 * (1f - num16) / (float)num15, 0f, 0f);
							}
							else
							{
								vector2 -= new Vector3(num13 * (1f - num16) / (float)num15, 0f, 0f);
							}
						}
						else if (!generationSettings.isRightToLeft)
						{
							vector2 += new Vector3(num13 * num16 / (float)num14, 0f, 0f);
						}
						else
						{
							vector2 -= new Vector3(num13 * num16 / (float)num14, 0f, 0f);
						}
					}
					else
					{
						vector2 = (generationSettings.isRightToLeft ? new Vector3(lineInfo.marginLeft + lineInfo.width, 0f, 0f) : new Vector3(lineInfo.marginLeft, 0f, 0f));
					}
					break;
				}
				}
				zero = vector + vector2;
				zero = new Vector3(Round(zero.x), Round(zero.y));
				bool isVisible = textElementInfo[i].isVisible;
				if (isVisible)
				{
					TextElementType elementType = textElementInfo[i].elementType;
					switch (elementType)
					{
					case TextElementType.Character:
					{
						Extents lineExtents = lineInfo.lineExtents;
						textElementInfo[i].vertexBottomLeft.uv2.x = 0f;
						textElementInfo[i].vertexTopLeft.uv2.x = 0f;
						textElementInfo[i].vertexTopRight.uv2.x = 1f;
						textElementInfo[i].vertexBottomRight.uv2.x = 1f;
						textElementInfo[i].vertexBottomLeft.uv2.y = 0f;
						textElementInfo[i].vertexTopLeft.uv2.y = 1f;
						textElementInfo[i].vertexTopRight.uv2.y = 1f;
						textElementInfo[i].vertexBottomRight.uv2.y = 0f;
						num5 = textElementInfo[i].scale * (1f - m_CharWidthAdjDelta) * 1f;
						if (!textElementInfo[i].isUsingAlternateTypeface && (textElementInfo[i].style & FontStyles.Bold) == FontStyles.Bold)
						{
							num5 *= -1f;
						}
						textElementInfo[i].vertexBottomLeft.uv.w = num5;
						textElementInfo[i].vertexTopLeft.uv.w = num5;
						textElementInfo[i].vertexTopRight.uv.w = num5;
						textElementInfo[i].vertexBottomRight.uv.w = num5;
						textElementInfo[i].vertexBottomLeft.uv2.x = 1f;
						textElementInfo[i].vertexBottomLeft.uv2.y = num5;
						textElementInfo[i].vertexTopLeft.uv2.x = 1f;
						textElementInfo[i].vertexTopLeft.uv2.y = num5;
						textElementInfo[i].vertexTopRight.uv2.x = 1f;
						textElementInfo[i].vertexTopRight.uv2.y = num5;
						textElementInfo[i].vertexBottomRight.uv2.x = 1f;
						textElementInfo[i].vertexBottomRight.uv2.y = num5;
						break;
					}
					}
					if (i < 99999 && num < 99999 && lineNumber < 99999)
					{
						textElementInfo[i].vertexBottomLeft.position += zero;
						textElementInfo[i].vertexTopLeft.position += zero;
						textElementInfo[i].vertexTopRight.position += zero;
						textElementInfo[i].vertexBottomRight.position += zero;
					}
					else
					{
						textElementInfo[i].vertexBottomLeft.position = Vector3.zero;
						textElementInfo[i].vertexTopLeft.position = Vector3.zero;
						textElementInfo[i].vertexTopRight.position = Vector3.zero;
						textElementInfo[i].vertexBottomRight.position = Vector3.zero;
						textElementInfo[i].isVisible = false;
					}
					switch (elementType)
					{
					case TextElementType.Character:
						TextGeneratorUtilities.FillCharacterVertexBuffers(i, generationSettings.shouldConvertToLinearSpace, generationSettings, textInfo, NeedToRound);
						break;
					case TextElementType.Sprite:
						TextGeneratorUtilities.FillSpriteVertexBuffers(i, generationSettings.shouldConvertToLinearSpace, generationSettings, textInfo);
						break;
					}
				}
				textInfo.textElementInfo[i].bottomLeft += zero;
				textInfo.textElementInfo[i].topLeft += zero;
				textInfo.textElementInfo[i].topRight += zero;
				textInfo.textElementInfo[i].bottomRight += zero;
				textInfo.textElementInfo[i].origin += zero.x;
				textInfo.textElementInfo[i].xAdvance += zero.x;
				textInfo.textElementInfo[i].ascender += zero.y;
				textInfo.textElementInfo[i].descender += zero.y;
				textInfo.textElementInfo[i].baseLine += zero.y;
				if (isVisible)
				{
				}
				if (lineNumber != num2 || i == m_CharacterCount - 1)
				{
					if (lineNumber != num2)
					{
						int num17 = ((generationSettings.textWrappingMode == TextWrappingMode.PreserveWhitespace || generationSettings.textWrappingMode == TextWrappingMode.PreserveWhitespaceNoWrap) ? textInfo.lineInfo[num2].lastCharacterIndex : textInfo.lineInfo[num2].lastVisibleCharacterIndex);
						textInfo.lineInfo[num2].baseline += zero.y;
						textInfo.lineInfo[num2].ascender += zero.y;
						textInfo.lineInfo[num2].descender += zero.y;
						textInfo.lineInfo[num2].maxAdvance += zero.x;
						textInfo.lineInfo[num2].lineExtents.min = new Vector2(textInfo.textElementInfo[textInfo.lineInfo[num2].firstCharacterIndex].bottomLeft.x, textInfo.lineInfo[num2].descender);
						textInfo.lineInfo[num2].lineExtents.max = new Vector2(textInfo.textElementInfo[num17].topRight.x, textInfo.lineInfo[num2].ascender);
					}
					if (i == m_CharacterCount - 1)
					{
						int num18 = ((generationSettings.textWrappingMode == TextWrappingMode.PreserveWhitespace || generationSettings.textWrappingMode == TextWrappingMode.PreserveWhitespaceNoWrap) ? textInfo.lineInfo[lineNumber].lastCharacterIndex : textInfo.lineInfo[lineNumber].lastVisibleCharacterIndex);
						textInfo.lineInfo[lineNumber].baseline += zero.y;
						textInfo.lineInfo[lineNumber].ascender += zero.y;
						textInfo.lineInfo[lineNumber].descender += zero.y;
						textInfo.lineInfo[lineNumber].maxAdvance += zero.x;
						textInfo.lineInfo[lineNumber].lineExtents.min = new Vector2(textInfo.textElementInfo[textInfo.lineInfo[lineNumber].firstCharacterIndex].bottomLeft.x, textInfo.lineInfo[lineNumber].descender);
						textInfo.lineInfo[lineNumber].lineExtents.max = new Vector2(textInfo.textElementInfo[num18].topRight.x, textInfo.lineInfo[lineNumber].ascender);
					}
				}
				if (char.IsLetterOrDigit(c) || c == '-' || c == '\u00ad' || c == '-' || c == '-')
				{
					if (!flag2)
					{
						flag2 = true;
						num3 = i;
					}
					if (flag2 && i == m_CharacterCount - 1)
					{
						int num19 = textInfo.wordInfo.Length;
						int wordCount = textInfo.wordCount;
						if (textInfo.wordCount + 1 > num19)
						{
							TextInfo.Resize(ref textInfo.wordInfo, num19 + 1);
						}
						num4 = i;
						textInfo.wordInfo[wordCount].firstCharacterIndex = num3;
						textInfo.wordInfo[wordCount].lastCharacterIndex = num4;
						textInfo.wordInfo[wordCount].characterCount = num4 - num3 + 1;
						num++;
						textInfo.wordCount++;
						textInfo.lineInfo[lineNumber].wordCount++;
					}
				}
				else if ((flag2 || (i == 0 && (!char.IsPunctuation(c) || flag6 || c == '\u200b' || i == m_CharacterCount - 1))) && (i <= 0 || i >= textElementInfo.Length - 1 || i >= m_CharacterCount || (c != '\'' && c != ''') || !char.IsLetterOrDigit((char)textElementInfo[i - 1].character) || !char.IsLetterOrDigit((char)textElementInfo[i + 1].character)))
				{
					num4 = ((i == m_CharacterCount - 1 && char.IsLetterOrDigit(c)) ? i : (i - 1));
					flag2 = false;
					int num20 = textInfo.wordInfo.Length;
					int wordCount2 = textInfo.wordCount;
					if (textInfo.wordCount + 1 > num20)
					{
						TextInfo.Resize(ref textInfo.wordInfo, num20 + 1);
					}
					textInfo.wordInfo[wordCount2].firstCharacterIndex = num3;
					textInfo.wordInfo[wordCount2].lastCharacterIndex = num4;
					textInfo.wordInfo[wordCount2].characterCount = num4 - num3 + 1;
					num++;
					textInfo.wordCount++;
					textInfo.lineInfo[lineNumber].wordCount++;
				}
				if ((textInfo.textElementInfo[i].style & FontStyles.Underline) == FontStyles.Underline)
				{
					bool flag8 = true;
					textInfo.textElementInfo[i].underlineVertexIndex = underlineVertexIndex;
					if (i > 99999 || lineNumber > 99999)
					{
						flag8 = false;
					}
					if (!flag6 && c != '\u200b')
					{
						num9 = Mathf.Max(num9, textInfo.textElementInfo[i].scale);
						num6 = Mathf.Max(num6, Mathf.Abs(num5));
						num10 = Mathf.Min(num10, textInfo.textElementInfo[i].baseLine + fontAsset.faceInfo.underlineOffset * num9);
					}
					if (!flag3 && flag8 && i <= lineInfo.lastVisibleCharacterIndex && c != '\n' && c != '\v' && c != '\r' && (i != lineInfo.lastVisibleCharacterIndex || !char.IsSeparator(c)))
					{
						flag3 = true;
						num7 = textInfo.textElementInfo[i].scale;
						if (num9 == 0f)
						{
							num9 = num7;
							num6 = num5;
						}
						start = new Vector3(textInfo.textElementInfo[i].bottomLeft.x, num10, 0f);
						color = textInfo.textElementInfo[i].underlineColor;
					}
					if (flag3 && m_CharacterCount == 1)
					{
						flag3 = false;
						zero2 = new Vector3(textInfo.textElementInfo[i].topRight.x, num10, 0f);
						num8 = textInfo.textElementInfo[i].scale;
						DrawUnderlineMesh(start, zero2, num7, num8, num9, num6, color, generationSettings, textInfo);
						num9 = 0f;
						num6 = 0f;
						num10 = 32767f;
					}
					else if (flag3 && (i == lineInfo.lastCharacterIndex || i >= lineInfo.lastVisibleCharacterIndex))
					{
						if (flag6 || c == '\u200b')
						{
							int lastVisibleCharacterIndex = lineInfo.lastVisibleCharacterIndex;
							zero2 = new Vector3(textInfo.textElementInfo[lastVisibleCharacterIndex].topRight.x, num10, 0f);
							num8 = textInfo.textElementInfo[lastVisibleCharacterIndex].scale;
						}
						else
						{
							zero2 = new Vector3(textInfo.textElementInfo[i].topRight.x, num10, 0f);
							num8 = textInfo.textElementInfo[i].scale;
						}
						flag3 = false;
						DrawUnderlineMesh(start, zero2, num7, num8, num9, num6, color, generationSettings, textInfo);
						num9 = 0f;
						num6 = 0f;
						num10 = 32767f;
					}
					else if (flag3 && !flag8)
					{
						flag3 = false;
						zero2 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, num10, 0f);
						num8 = textInfo.textElementInfo[i - 1].scale;
						DrawUnderlineMesh(start, zero2, num7, num8, num9, num6, color, generationSettings, textInfo);
						num9 = 0f;
						num6 = 0f;
						num10 = 32767f;
					}
					else if (flag3 && i < m_CharacterCount - 1 && !ColorUtilities.CompareColors(color, textInfo.textElementInfo[i + 1].underlineColor))
					{
						flag3 = false;
						zero2 = new Vector3(textInfo.textElementInfo[i].topRight.x, num10, 0f);
						num8 = textInfo.textElementInfo[i].scale;
						DrawUnderlineMesh(start, zero2, num7, num8, num9, num6, color, generationSettings, textInfo);
						num9 = 0f;
						num6 = 0f;
						num10 = 32767f;
					}
				}
				else if (flag3)
				{
					flag3 = false;
					zero2 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, num10, 0f);
					num8 = textInfo.textElementInfo[i - 1].scale;
					DrawUnderlineMesh(start, zero2, num7, num8, num9, num6, color, generationSettings, textInfo);
					num9 = 0f;
					num6 = 0f;
					num10 = 32767f;
				}
				bool flag9 = (textInfo.textElementInfo[i].style & FontStyles.Strikethrough) == FontStyles.Strikethrough;
				float strikethroughOffset = fontAsset.faceInfo.strikethroughOffset;
				if (flag9)
				{
					bool flag10 = true;
					textInfo.textElementInfo[i].strikethroughVertexIndex = m_MaterialReferences[m_Underline.materialIndex].referenceCount * 4;
					if (i > 99999 || lineNumber > 99999)
					{
						flag10 = false;
					}
					if (!flag4 && flag10 && i <= lineInfo.lastVisibleCharacterIndex && c != '\n' && c != '\v' && c != '\r' && (i != lineInfo.lastVisibleCharacterIndex || !char.IsSeparator(c)))
					{
						flag4 = true;
						num11 = textInfo.textElementInfo[i].pointSize;
						num12 = textInfo.textElementInfo[i].scale;
						start2 = new Vector3(textInfo.textElementInfo[i].bottomLeft.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num12, 0f);
						underlineColor = textInfo.textElementInfo[i].strikethroughColor;
						b = textInfo.textElementInfo[i].baseLine;
					}
					if (flag4 && m_CharacterCount == 1)
					{
						flag4 = false;
						zero3 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num12, 0f);
						DrawUnderlineMesh(start2, zero3, num12, num12, num12, num5, underlineColor, generationSettings, textInfo);
					}
					else if (flag4 && i == lineInfo.lastCharacterIndex)
					{
						if (flag6 || c == '\u200b')
						{
							int lastVisibleCharacterIndex2 = lineInfo.lastVisibleCharacterIndex;
							zero3 = new Vector3(textInfo.textElementInfo[lastVisibleCharacterIndex2].topRight.x, textInfo.textElementInfo[lastVisibleCharacterIndex2].baseLine + strikethroughOffset * num12, 0f);
						}
						else
						{
							zero3 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num12, 0f);
						}
						flag4 = false;
						DrawUnderlineMesh(start2, zero3, num12, num12, num12, num5, underlineColor, generationSettings, textInfo);
					}
					else if (flag4 && i < m_CharacterCount && (textInfo.textElementInfo[i + 1].pointSize != num11 || !TextGeneratorUtilities.Approximately(textInfo.textElementInfo[i + 1].baseLine + zero.y, b)))
					{
						flag4 = false;
						int lastVisibleCharacterIndex3 = lineInfo.lastVisibleCharacterIndex;
						zero3 = ((i <= lastVisibleCharacterIndex3) ? new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num12, 0f) : new Vector3(textInfo.textElementInfo[lastVisibleCharacterIndex3].topRight.x, textInfo.textElementInfo[lastVisibleCharacterIndex3].baseLine + strikethroughOffset * num12, 0f));
						DrawUnderlineMesh(start2, zero3, num12, num12, num12, num5, underlineColor, generationSettings, textInfo);
					}
					else if (flag4 && i < m_CharacterCount && fontAsset.GetHashCode() != textElementInfo[i + 1].fontAsset.GetHashCode())
					{
						flag4 = false;
						zero3 = new Vector3(textInfo.textElementInfo[i].topRight.x, textInfo.textElementInfo[i].baseLine + strikethroughOffset * num12, 0f);
						DrawUnderlineMesh(start2, zero3, num12, num12, num12, num5, underlineColor, generationSettings, textInfo);
					}
					else if (flag4 && !flag10)
					{
						flag4 = false;
						zero3 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, textInfo.textElementInfo[i - 1].baseLine + strikethroughOffset * num12, 0f);
						DrawUnderlineMesh(start2, zero3, num12, num12, num12, num5, underlineColor, generationSettings, textInfo);
					}
				}
				else if (flag4)
				{
					flag4 = false;
					zero3 = new Vector3(textInfo.textElementInfo[i - 1].topRight.x, textInfo.textElementInfo[i - 1].baseLine + strikethroughOffset * num12, 0f);
					DrawUnderlineMesh(start2, zero3, num12, num12, num12, num5, underlineColor, generationSettings, textInfo);
				}
				if ((textInfo.textElementInfo[i].style & FontStyles.Highlight) == FontStyles.Highlight)
				{
					bool flag11 = true;
					if (i > 99999 || lineNumber > 99999)
					{
						flag11 = false;
					}
					if (!flag5 && flag11 && i <= lineInfo.lastVisibleCharacterIndex && c != '\n' && c != '\v' && c != '\r' && (i != lineInfo.lastVisibleCharacterIndex || !char.IsSeparator(c)))
					{
						flag5 = true;
						start3 = TextGeneratorUtilities.largePositiveVector2;
						end = TextGeneratorUtilities.largeNegativeVector2;
						highlightState = textInfo.textElementInfo[i].highlightState;
					}
					if (flag5)
					{
						TextElementInfo textElementInfo2 = textInfo.textElementInfo[i];
						HighlightState highlightState2 = textElementInfo2.highlightState;
						bool flag12 = false;
						if (highlightState != highlightState2)
						{
							if (flag6)
							{
								end.x = (end.x - highlightState.padding.right + textElementInfo2.origin) / 2f;
							}
							else
							{
								end.x = (end.x - highlightState.padding.right + textElementInfo2.bottomLeft.x) / 2f;
							}
							start3.y = Mathf.Min(start3.y, textElementInfo2.descender);
							end.y = Mathf.Max(end.y, textElementInfo2.ascender);
							DrawTextHighlight(start3, end, highlightState.color, generationSettings, textInfo);
							flag5 = true;
							start3 = new Vector2(end.x, textElementInfo2.descender - highlightState2.padding.bottom);
							end = ((!flag6) ? ((Vector3)new Vector2(textElementInfo2.topRight.x + highlightState2.padding.right, textElementInfo2.ascender + highlightState2.padding.top)) : ((Vector3)new Vector2(textElementInfo2.xAdvance + highlightState2.padding.right, textElementInfo2.ascender + highlightState2.padding.top)));
							highlightState = highlightState2;
							flag12 = true;
						}
						if (!flag12)
						{
							if (flag6)
							{
								start3.x = Mathf.Min(start3.x, textElementInfo2.origin - highlightState.padding.left);
								end.x = Mathf.Max(end.x, textElementInfo2.xAdvance + highlightState.padding.right);
							}
							else
							{
								start3.x = Mathf.Min(start3.x, textElementInfo2.bottomLeft.x - highlightState.padding.left);
								end.x = Mathf.Max(end.x, textElementInfo2.topRight.x + highlightState.padding.right);
							}
							start3.y = Mathf.Min(start3.y, textElementInfo2.descender - highlightState.padding.bottom);
							end.y = Mathf.Max(end.y, textElementInfo2.ascender + highlightState.padding.top);
						}
					}
					if (flag5 && m_CharacterCount == 1)
					{
						flag5 = false;
						DrawTextHighlight(start3, end, highlightState.color, generationSettings, textInfo);
					}
					else if (flag5 && (i == lineInfo.lastCharacterIndex || i >= lineInfo.lastVisibleCharacterIndex))
					{
						flag5 = false;
						DrawTextHighlight(start3, end, highlightState.color, generationSettings, textInfo);
					}
					else if (flag5 && !flag11)
					{
						flag5 = false;
						DrawTextHighlight(start3, end, highlightState.color, generationSettings, textInfo);
					}
				}
				else if (flag5)
				{
					flag5 = false;
					DrawTextHighlight(start3, end, highlightState.color, generationSettings, textInfo);
				}
				num2 = lineNumber;
			}
			textInfo.characterCount = m_CharacterCount;
			textInfo.spriteCount = m_SpriteCount;
			textInfo.lineCount = lineCount;
			textInfo.wordCount = ((num == 0 || m_CharacterCount <= 0) ? 1 : num);
		}

		private float Round(float v)
		{
			if (!NeedToRound)
			{
				return v;
			}
			return Mathf.Floor(v + 0.48f);
		}

		public void ParsingPhase(TextInfo textInfo, TextGenerationSettings generationSettings, out uint charCode, out float maxVisibleDescender)
		{
			TextSettings textSettings = generationSettings.textSettings;
			m_CurrentMaterial = generationSettings.fontAsset.material;
			m_CurrentMaterialIndex = 0;
			m_MaterialReferenceStack.SetDefault(new MaterialReference(m_CurrentMaterialIndex, m_CurrentFontAsset, null, m_CurrentMaterial, m_Padding));
			m_CurrentSpriteAsset = null;
			int totalCharacterCount = m_TotalCharacterCount;
			float num = m_FontSize / generationSettings.fontAsset.m_FaceInfo.pointSize * generationSettings.fontAsset.m_FaceInfo.scale;
			float num2 = num;
			float num3 = m_FontSize * 0.01f;
			m_FontScaleMultiplier = 1f;
			m_ShouldRenderBitmap = generationSettings.fontAsset.IsBitmap();
			m_CurrentFontSize = m_FontSize;
			m_SizeStack.SetDefault(m_CurrentFontSize);
			charCode = 0u;
			m_FontStyleInternal = generationSettings.fontStyle;
			m_FontWeightInternal = (((m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			m_FontWeightStack.SetDefault(m_FontWeightInternal);
			m_FontStyleStack.Clear();
			m_LineJustification = generationSettings.textAlignment;
			m_LineJustificationStack.SetDefault(m_LineJustification);
			float num4 = 0f;
			m_BaselineOffset = 0f;
			m_BaselineOffsetStack.Clear();
			m_FontColor32 = generationSettings.color;
			m_HtmlColor = m_FontColor32;
			m_UnderlineColor = m_HtmlColor;
			m_StrikethroughColor = m_HtmlColor;
			m_ColorStack.SetDefault(m_HtmlColor);
			m_UnderlineColorStack.SetDefault(m_HtmlColor);
			m_StrikethroughColorStack.SetDefault(m_HtmlColor);
			m_HighlightStateStack.SetDefault(new HighlightState(m_HtmlColor, Offset.zero));
			m_ColorGradientPreset = null;
			m_ColorGradientStack.SetDefault(null);
			m_ItalicAngle = m_CurrentFontAsset.italicStyleSlant;
			m_ItalicAngleStack.SetDefault(m_ItalicAngle);
			m_ActionStack.Clear();
			m_FXScale = Vector3.one;
			m_FXRotation = Quaternion.identity;
			m_LineOffset = 0f;
			m_LineHeight = -32767f;
			float num5 = Round(m_CurrentFontAsset.faceInfo.lineHeight - (m_CurrentFontAsset.m_FaceInfo.ascentLine - m_CurrentFontAsset.m_FaceInfo.descentLine));
			m_CSpacing = 0f;
			m_MonoSpacing = 0f;
			m_XAdvance = 0f;
			m_TagLineIndent = 0f;
			m_TagIndent = 0f;
			m_IndentStack.SetDefault(0f);
			m_TagNoParsing = false;
			m_CharacterCount = 0;
			m_FirstCharacterOfLine = 0;
			m_LastCharacterOfLine = 0;
			m_FirstVisibleCharacterOfLine = 0;
			m_LastVisibleCharacterOfLine = 0;
			m_MaxLineAscender = -32767f;
			m_MaxLineDescender = 32767f;
			m_LineNumber = 0;
			m_StartOfLineAscender = 0f;
			m_LineVisibleCharacterCount = 0;
			m_LineVisibleSpaceCount = 0;
			bool flag = true;
			m_IsDrivenLineSpacing = false;
			m_FirstOverflowCharacterIndex = -1;
			m_LastBaseGlyphIndex = int.MinValue;
			bool flag2 = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.kern);
			bool flag3 = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.mark);
			bool flag4 = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.mkmk);
			float num6 = ((m_MarginWidth > 0f) ? m_MarginWidth : 0f);
			float num7 = ((m_MarginHeight > 0f) ? m_MarginHeight : 0f);
			m_MarginLeft = 0f;
			m_MarginRight = 0f;
			m_Width = -1f;
			float num8 = num6 + 0.0001f - m_MarginLeft - m_MarginRight;
			m_MeshExtents.min = TextGeneratorUtilities.largePositiveVector2;
			m_MeshExtents.max = TextGeneratorUtilities.largeNegativeVector2;
			textInfo.ClearLineInfo();
			m_MaxCapHeight = 0f;
			m_MaxAscender = 0f;
			m_MaxDescender = 0f;
			m_PageAscender = 0f;
			maxVisibleDescender = 0f;
			bool isMaxVisibleDescenderSet = false;
			bool flag5 = true;
			m_IsNonBreakingSpace = false;
			bool flag6 = false;
			int num9 = 0;
			CharacterSubstitution characterSubstitution = new CharacterSubstitution(-1, 0u);
			bool flag7 = false;
			TextWrappingMode textWrappingMode = generationSettings.textWrappingMode;
			SaveWordWrappingState(ref m_SavedWordWrapState, -1, -1, textInfo);
			SaveWordWrappingState(ref m_SavedLineState, -1, -1, textInfo);
			SaveWordWrappingState(ref m_SavedEllipsisState, -1, -1, textInfo);
			SaveWordWrappingState(ref m_SavedLastValidState, -1, -1, textInfo);
			SaveWordWrappingState(ref m_SavedSoftLineBreakState, -1, -1, textInfo);
			m_EllipsisInsertionCandidateStack.Clear();
			m_IsTextTruncated = false;
			int num10 = 0;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			Vector3 vector3 = default(Vector3);
			Vector3 vector4 = default(Vector3);
			for (int i = 0; i < m_TextProcessingArray.Length && m_TextProcessingArray[i].unicode != 0; i++)
			{
				charCode = m_TextProcessingArray[i].unicode;
				if (num10 > 5)
				{
					Debug.LogError("Line breaking recursion max threshold hit... Character [" + charCode + "] index: " + i);
					characterSubstitution.index = m_CharacterCount;
					characterSubstitution.unicode = 3u;
				}
				if (charCode == 26)
				{
					continue;
				}
				if (generationSettings.richText && charCode == 60)
				{
					m_isTextLayoutPhase = true;
					m_TextElementType = TextElementType.Character;
					if (ValidateHtmlTag(m_TextProcessingArray, i + 1, out var endIndex, generationSettings, textInfo, out var _))
					{
						i = endIndex;
						if (m_TextElementType == TextElementType.Character)
						{
							continue;
						}
					}
				}
				else
				{
					m_TextElementType = textInfo.textElementInfo[m_CharacterCount].elementType;
					m_CurrentMaterialIndex = textInfo.textElementInfo[m_CharacterCount].materialReferenceIndex;
					m_CurrentFontAsset = textInfo.textElementInfo[m_CharacterCount].fontAsset;
				}
				int currentMaterialIndex = m_CurrentMaterialIndex;
				bool isUsingAlternateTypeface = textInfo.textElementInfo[m_CharacterCount].isUsingAlternateTypeface;
				m_isTextLayoutPhase = false;
				bool flag8 = false;
				if (characterSubstitution.index == m_CharacterCount)
				{
					charCode = characterSubstitution.unicode;
					m_TextElementType = TextElementType.Character;
					flag8 = true;
					switch (charCode)
					{
					case 3u:
						textInfo.textElementInfo[m_CharacterCount].textElement = m_CurrentFontAsset.characterLookupTable[3u];
						m_IsTextTruncated = true;
						break;
					case 8230u:
						textInfo.textElementInfo[m_CharacterCount].textElement = m_Ellipsis.character;
						textInfo.textElementInfo[m_CharacterCount].elementType = TextElementType.Character;
						textInfo.textElementInfo[m_CharacterCount].fontAsset = m_Ellipsis.fontAsset;
						textInfo.textElementInfo[m_CharacterCount].material = m_Ellipsis.material;
						textInfo.textElementInfo[m_CharacterCount].materialReferenceIndex = m_Ellipsis.materialIndex;
						m_MaterialReferences[m_Underline.materialIndex].referenceCount++;
						m_IsTextTruncated = true;
						characterSubstitution.index = m_CharacterCount + 1;
						characterSubstitution.unicode = 3u;
						break;
					}
				}
				if (m_CharacterCount < 0 && charCode != 3)
				{
					textInfo.textElementInfo[m_CharacterCount].isVisible = false;
					textInfo.textElementInfo[m_CharacterCount].character = 8203u;
					textInfo.textElementInfo[m_CharacterCount].lineNumber = 0;
					m_CharacterCount++;
					continue;
				}
				float num11 = 1f;
				if (m_TextElementType == TextElementType.Character)
				{
					if ((m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase)
					{
						if (char.IsLower((char)charCode))
						{
							charCode = char.ToUpper((char)charCode);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase)
					{
						if (char.IsUpper((char)charCode))
						{
							charCode = char.ToLower((char)charCode);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps && char.IsLower((char)charCode))
					{
						num11 = 0.8f;
						charCode = char.ToUpper((char)charCode);
					}
				}
				float num12 = 0f;
				float num13 = 0f;
				float num14 = 0f;
				if (m_TextElementType == TextElementType.Sprite)
				{
					SpriteCharacter spriteCharacter = (SpriteCharacter)textInfo.textElementInfo[m_CharacterCount].textElement;
					m_CurrentSpriteAsset = spriteCharacter.textAsset as SpriteAsset;
					m_SpriteIndex = (int)spriteCharacter.glyphIndex;
					if (charCode == 60)
					{
						charCode = (uint)(57344 + m_SpriteIndex);
					}
					else
					{
						m_SpriteColor = Color.white;
					}
					float num15 = m_CurrentFontSize / m_CurrentFontAsset.faceInfo.pointSize * m_CurrentFontAsset.faceInfo.scale;
					if (m_CurrentSpriteAsset.m_FaceInfo.pointSize > 0f)
					{
						float num16 = m_CurrentFontSize / m_CurrentSpriteAsset.m_FaceInfo.pointSize * m_CurrentSpriteAsset.m_FaceInfo.scale;
						num2 = spriteCharacter.m_Scale * spriteCharacter.m_Glyph.scale * num16;
						num13 = m_CurrentSpriteAsset.m_FaceInfo.ascentLine;
						num12 = m_CurrentSpriteAsset.m_FaceInfo.baseline * num15 * m_FontScaleMultiplier * m_CurrentSpriteAsset.m_FaceInfo.scale;
						num14 = m_CurrentSpriteAsset.m_FaceInfo.descentLine;
					}
					else
					{
						float num17 = m_CurrentFontSize / m_CurrentFontAsset.m_FaceInfo.pointSize * m_CurrentFontAsset.m_FaceInfo.scale;
						num2 = m_CurrentFontAsset.m_FaceInfo.ascentLine / spriteCharacter.m_Glyph.metrics.height * spriteCharacter.m_Scale * spriteCharacter.m_Glyph.scale * num17;
						float num18 = num17 / num2;
						num13 = m_CurrentFontAsset.m_FaceInfo.ascentLine * num18;
						num12 = m_CurrentFontAsset.m_FaceInfo.baseline * num15 * m_FontScaleMultiplier * m_CurrentFontAsset.m_FaceInfo.scale;
						num14 = m_CurrentFontAsset.m_FaceInfo.descentLine * num18;
					}
					m_CachedTextElement = spriteCharacter;
					textInfo.textElementInfo[m_CharacterCount].elementType = TextElementType.Sprite;
					textInfo.textElementInfo[m_CharacterCount].scale = num2;
					textInfo.textElementInfo[m_CharacterCount].spriteAsset = m_CurrentSpriteAsset;
					textInfo.textElementInfo[m_CharacterCount].fontAsset = m_CurrentFontAsset;
					textInfo.textElementInfo[m_CharacterCount].materialReferenceIndex = m_CurrentMaterialIndex;
					m_CurrentMaterialIndex = currentMaterialIndex;
					num4 = 0f;
				}
				else if (m_TextElementType == TextElementType.Character)
				{
					m_CachedTextElement = textInfo.textElementInfo[m_CharacterCount].textElement;
					if (m_CachedTextElement == null)
					{
						continue;
					}
					m_CurrentFontAsset = textInfo.textElementInfo[m_CharacterCount].fontAsset;
					m_CurrentMaterial = textInfo.textElementInfo[m_CharacterCount].material;
					m_CurrentMaterialIndex = textInfo.textElementInfo[m_CharacterCount].materialReferenceIndex;
					float num19 = ((!flag8 || m_TextProcessingArray[i].unicode != 10 || m_CharacterCount == m_FirstCharacterOfLine) ? (m_CurrentFontSize * num11 / m_CurrentFontAsset.m_FaceInfo.pointSize * m_CurrentFontAsset.m_FaceInfo.scale) : (textInfo.textElementInfo[m_CharacterCount - 1].pointSize * num11 / m_CurrentFontAsset.m_FaceInfo.pointSize * m_CurrentFontAsset.m_FaceInfo.scale));
					if (flag8 && charCode == 8230)
					{
						num13 = 0f;
						num14 = 0f;
					}
					else
					{
						num13 = m_CurrentFontAsset.m_FaceInfo.ascentLine;
						num14 = m_CurrentFontAsset.m_FaceInfo.descentLine;
					}
					num2 = num19 * m_FontScaleMultiplier * m_CachedTextElement.m_Scale * m_CachedTextElement.m_Glyph.scale;
					num12 = Round(m_CurrentFontAsset.m_FaceInfo.baseline * num19 * m_FontScaleMultiplier * m_CurrentFontAsset.m_FaceInfo.scale);
					textInfo.textElementInfo[m_CharacterCount].elementType = TextElementType.Character;
					textInfo.textElementInfo[m_CharacterCount].scale = num2;
					num4 = m_Padding;
				}
				float num20 = num2;
				if (charCode == 173 || charCode == 3)
				{
					num2 = 0f;
				}
				textInfo.textElementInfo[m_CharacterCount].character = charCode;
				textInfo.textElementInfo[m_CharacterCount].pointSize = m_CurrentFontSize;
				textInfo.textElementInfo[m_CharacterCount].color = m_HtmlColor;
				textInfo.textElementInfo[m_CharacterCount].underlineColor = m_UnderlineColor;
				textInfo.textElementInfo[m_CharacterCount].strikethroughColor = m_StrikethroughColor;
				textInfo.textElementInfo[m_CharacterCount].highlightState = m_HighlightState;
				textInfo.textElementInfo[m_CharacterCount].style = m_FontStyleInternal;
				if (m_FontWeightInternal == TextFontWeight.Bold)
				{
					textInfo.textElementInfo[m_CharacterCount].style |= FontStyles.Bold;
				}
				GlyphMetrics glyphMetrics = textInfo.textElementInfo[m_CharacterCount].alternativeGlyph?.metrics ?? m_CachedTextElement.m_Glyph.metrics;
				bool flag9 = charCode <= 65535 && char.IsWhiteSpace((char)charCode);
				GlyphValueRecord glyphValueRecord = default(GlyphValueRecord);
				float num21 = generationSettings.characterSpacing;
				if (flag2 && m_TextElementType == TextElementType.Character)
				{
					uint glyphIndex = m_CachedTextElement.m_GlyphIndex;
					GlyphPairAdjustmentRecord value;
					if (m_CharacterCount < totalCharacterCount - 1 && textInfo.textElementInfo[m_CharacterCount + 1].elementType == TextElementType.Character)
					{
						uint glyphIndex2 = textInfo.textElementInfo[m_CharacterCount + 1].textElement.m_GlyphIndex;
						uint key = (glyphIndex2 << 16) | glyphIndex;
						if (m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key, out value))
						{
							glyphValueRecord = value.firstAdjustmentRecord.glyphValueRecord;
							num21 = (((value.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num21);
						}
					}
					if (m_CharacterCount >= 1)
					{
						uint glyphIndex3 = textInfo.textElementInfo[m_CharacterCount - 1].textElement.m_GlyphIndex;
						uint key2 = (glyphIndex << 16) | glyphIndex3;
						if (textInfo.textElementInfo[m_CharacterCount - 1].elementType == TextElementType.Character && m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key2, out value))
						{
							glyphValueRecord += value.secondAdjustmentRecord.glyphValueRecord;
							num21 = (((value.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num21);
						}
					}
					textInfo.textElementInfo[m_CharacterCount].adjustedHorizontalAdvance = glyphValueRecord.xAdvance;
				}
				bool flag10 = TextGeneratorUtilities.IsBaseGlyph(charCode);
				if (flag10)
				{
					m_LastBaseGlyphIndex = m_CharacterCount;
				}
				if (m_CharacterCount > 0 && !flag10)
				{
					if (flag3 && m_LastBaseGlyphIndex != int.MinValue && m_LastBaseGlyphIndex == m_CharacterCount - 1)
					{
						Glyph glyph = textInfo.textElementInfo[m_LastBaseGlyphIndex].textElement.glyph;
						uint index = glyph.index;
						uint glyphIndex4 = m_CachedTextElement.glyphIndex;
						uint key3 = (glyphIndex4 << 16) | index;
						if (m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key3, out var value2))
						{
							float num22 = (textInfo.textElementInfo[m_LastBaseGlyphIndex].origin - m_XAdvance) / num2;
							glyphValueRecord.xPlacement = num22 + value2.baseGlyphAnchorPoint.xCoordinate - value2.markPositionAdjustment.xPositionAdjustment;
							glyphValueRecord.yPlacement = value2.baseGlyphAnchorPoint.yCoordinate - value2.markPositionAdjustment.yPositionAdjustment;
							num21 = 0f;
						}
					}
					else
					{
						bool flag11 = false;
						if (flag4)
						{
							int num23 = m_CharacterCount - 1;
							while (num23 >= 0 && num23 != m_LastBaseGlyphIndex)
							{
								Glyph glyph2 = textInfo.textElementInfo[num23].textElement.glyph;
								uint index2 = glyph2.index;
								uint glyphIndex5 = m_CachedTextElement.glyphIndex;
								uint key4 = (glyphIndex5 << 16) | index2;
								if (m_CurrentFontAsset.fontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.TryGetValue(key4, out var value3))
								{
									float num24 = (textInfo.textElementInfo[num23].origin - m_XAdvance) / num2;
									float num25 = num12 - m_LineOffset + m_BaselineOffset;
									float num26 = (textInfo.textElementInfo[num23].baseLine - num25) / num2;
									glyphValueRecord.xPlacement = num24 + value3.baseMarkGlyphAnchorPoint.xCoordinate - value3.combiningMarkPositionAdjustment.xPositionAdjustment;
									glyphValueRecord.yPlacement = num26 + value3.baseMarkGlyphAnchorPoint.yCoordinate - value3.combiningMarkPositionAdjustment.yPositionAdjustment;
									num21 = 0f;
									flag11 = true;
									break;
								}
								num23--;
							}
						}
						if (flag3 && m_LastBaseGlyphIndex != int.MinValue && !flag11)
						{
							Glyph glyph3 = textInfo.textElementInfo[m_LastBaseGlyphIndex].textElement.glyph;
							uint index3 = glyph3.index;
							uint glyphIndex6 = m_CachedTextElement.glyphIndex;
							uint key5 = (glyphIndex6 << 16) | index3;
							if (m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key5, out var value4))
							{
								float num27 = (textInfo.textElementInfo[m_LastBaseGlyphIndex].origin - m_XAdvance) / num2;
								glyphValueRecord.xPlacement = num27 + value4.baseGlyphAnchorPoint.xCoordinate - value4.markPositionAdjustment.xPositionAdjustment;
								glyphValueRecord.yPlacement = value4.baseGlyphAnchorPoint.yCoordinate - value4.markPositionAdjustment.yPositionAdjustment;
								num21 = 0f;
							}
						}
					}
				}
				num13 += glyphValueRecord.yPlacement;
				num14 += glyphValueRecord.yPlacement;
				if (generationSettings.isRightToLeft)
				{
					m_XAdvance -= glyphMetrics.horizontalAdvance * (1f - m_CharWidthAdjDelta) * num2;
					if (flag9 || charCode == 8203)
					{
						m_XAdvance -= generationSettings.wordSpacing * num3;
					}
				}
				float num28 = 0f;
				if (m_MonoSpacing != 0f && charCode != 8203)
				{
					num28 = ((!m_DuoSpace || (charCode != 46 && charCode != 58 && charCode != 44)) ? ((m_MonoSpacing / 2f - (glyphMetrics.width / 2f + glyphMetrics.horizontalBearingX) * num2) * (1f - m_CharWidthAdjDelta)) : ((m_MonoSpacing / 4f - (glyphMetrics.width / 2f + glyphMetrics.horizontalBearingX) * num2) * (1f - m_CharWidthAdjDelta)));
					m_XAdvance += num28;
				}
				bool flag12 = m_CurrentFontAsset.atlasRenderMode != GlyphRenderMode.SMOOTH && m_CurrentFontAsset.atlasRenderMode != GlyphRenderMode.COLOR;
				float num30;
				float num31;
				if (m_TextElementType == TextElementType.Character && !isUsingAlternateTypeface && (textInfo.textElementInfo[m_CharacterCount].style & FontStyles.Bold) == FontStyles.Bold)
				{
					if (flag12)
					{
						float num29 = ((generationSettings.isIMGUI && m_CurrentMaterial.HasFloat(TextShaderUtilities.ID_GradientScale)) ? m_CurrentMaterial.GetFloat(TextShaderUtilities.ID_GradientScale) : ((float)(m_CurrentFontAsset.atlasPadding + 1)));
						num30 = m_CurrentFontAsset.boldStyleWeight / 4f * num29;
						if (num30 + num4 > num29)
						{
							num4 = num29 - num30;
						}
					}
					else
					{
						num30 = 0f;
					}
					num31 = m_CurrentFontAsset.boldStyleSpacing;
				}
				else
				{
					if (flag12)
					{
						float num32 = ((generationSettings.isIMGUI && m_CurrentMaterial.HasFloat(TextShaderUtilities.ID_GradientScale)) ? m_CurrentMaterial.GetFloat(TextShaderUtilities.ID_GradientScale) : ((float)(m_CurrentFontAsset.atlasPadding + 1)));
						num30 = m_CurrentFontAsset.m_RegularStyleWeight / 4f * num32;
						if (num30 + num4 > num32)
						{
							num4 = num32 - num30;
						}
					}
					else
					{
						num30 = 0f;
					}
					num31 = 0f;
				}
				vector.x = m_XAdvance + (glyphMetrics.horizontalBearingX * m_FXScale.x - num4 - num30 + glyphValueRecord.xPlacement) * num2 * (1f - m_CharWidthAdjDelta);
				vector.y = num12 + Round((glyphMetrics.horizontalBearingY + num4 + glyphValueRecord.yPlacement) * num2) - m_LineOffset + m_BaselineOffset;
				vector.z = 0f;
				vector2.x = vector.x;
				vector2.y = vector.y - (glyphMetrics.height + num4 * 2f) * num2;
				vector2.z = 0f;
				vector3.x = vector2.x + (glyphMetrics.width * m_FXScale.x + num4 * 2f + num30 * 2f) * num2 * (1f - m_CharWidthAdjDelta);
				vector3.y = vector.y;
				vector3.z = 0f;
				vector4.x = vector3.x;
				vector4.y = vector2.y;
				vector4.z = 0f;
				if (m_TextElementType == TextElementType.Character && !isUsingAlternateTypeface && (m_FontStyleInternal & FontStyles.Italic) == FontStyles.Italic)
				{
					float num33 = (float)m_ItalicAngle * 0.01f;
					float num34 = (m_CurrentFontAsset.m_FaceInfo.capLine - (m_CurrentFontAsset.m_FaceInfo.baseline + m_BaselineOffset)) / 2f * m_FontScaleMultiplier * m_CurrentFontAsset.m_FaceInfo.scale;
					Vector3 vector5 = new Vector3(num33 * ((glyphMetrics.horizontalBearingY + num4 + num30 - num34) * num2), 0f, 0f);
					Vector3 vector6 = new Vector3(num33 * ((glyphMetrics.horizontalBearingY - glyphMetrics.height - num4 - num30 - num34) * num2), 0f, 0f);
					vector += vector5;
					vector2 += vector6;
					vector3 += vector5;
					vector4 += vector6;
				}
				if (m_FXRotation != Quaternion.identity)
				{
					Matrix4x4 matrix4x = Matrix4x4.Rotate(m_FXRotation);
					Vector3 vector7 = (vector3 + vector2) / 2f;
					vector = matrix4x.MultiplyPoint3x4(vector - vector7) + vector7;
					vector2 = matrix4x.MultiplyPoint3x4(vector2 - vector7) + vector7;
					vector3 = matrix4x.MultiplyPoint3x4(vector3 - vector7) + vector7;
					vector4 = matrix4x.MultiplyPoint3x4(vector4 - vector7) + vector7;
				}
				textInfo.textElementInfo[m_CharacterCount].bottomLeft = vector2;
				textInfo.textElementInfo[m_CharacterCount].topLeft = vector;
				textInfo.textElementInfo[m_CharacterCount].topRight = vector3;
				textInfo.textElementInfo[m_CharacterCount].bottomRight = vector4;
				textInfo.textElementInfo[m_CharacterCount].origin = Round(m_XAdvance + glyphValueRecord.xPlacement * num2);
				textInfo.textElementInfo[m_CharacterCount].baseLine = Round(num12 - m_LineOffset + m_BaselineOffset + glyphValueRecord.yPlacement * num2);
				textInfo.textElementInfo[m_CharacterCount].aspectRatio = (vector3.x - vector2.x) / (vector.y - vector2.y);
				float num35 = ((m_TextElementType == TextElementType.Character) ? (num13 * num2 / num11 + m_BaselineOffset) : (num13 * num2 + m_BaselineOffset));
				float num36 = ((m_TextElementType == TextElementType.Character) ? (num14 * num2 / num11 + m_BaselineOffset) : (num14 * num2 + m_BaselineOffset));
				float num37 = num35;
				float num38 = num36;
				bool flag13 = m_CharacterCount == m_FirstCharacterOfLine;
				if (flag13 || !flag9)
				{
					if (m_BaselineOffset != 0f)
					{
						num37 = Mathf.Max((num35 - m_BaselineOffset) / m_FontScaleMultiplier, num37);
						num38 = Mathf.Min((num36 - m_BaselineOffset) / m_FontScaleMultiplier, num38);
					}
					m_MaxLineAscender = Mathf.Max(num37, m_MaxLineAscender);
					m_MaxLineDescender = Mathf.Min(num38, m_MaxLineDescender);
				}
				if (flag13 || !flag9)
				{
					textInfo.textElementInfo[m_CharacterCount].adjustedAscender = num37;
					textInfo.textElementInfo[m_CharacterCount].adjustedDescender = num38;
					textInfo.textElementInfo[m_CharacterCount].ascender = num35 - m_LineOffset;
					m_MaxDescender = (textInfo.textElementInfo[m_CharacterCount].descender = num36 - m_LineOffset);
				}
				else
				{
					textInfo.textElementInfo[m_CharacterCount].adjustedAscender = m_MaxLineAscender;
					textInfo.textElementInfo[m_CharacterCount].adjustedDescender = m_MaxLineDescender;
					textInfo.textElementInfo[m_CharacterCount].ascender = m_MaxLineAscender - m_LineOffset;
					m_MaxDescender = (textInfo.textElementInfo[m_CharacterCount].descender = m_MaxLineDescender - m_LineOffset);
				}
				if (m_LineNumber == 0 && (flag13 || !flag9))
				{
					m_MaxAscender = m_MaxLineAscender;
					m_MaxCapHeight = Mathf.Max(m_MaxCapHeight, m_CurrentFontAsset.m_FaceInfo.capLine * num2 / num11);
				}
				if (m_LineOffset == 0f && (flag13 || !flag9))
				{
					m_PageAscender = ((m_PageAscender > num35) ? m_PageAscender : num35);
				}
				textInfo.textElementInfo[m_CharacterCount].isVisible = false;
				if (charCode == 9 || ((textWrappingMode == TextWrappingMode.PreserveWhitespace || textWrappingMode == TextWrappingMode.PreserveWhitespaceNoWrap) && (flag9 || charCode == 8203)) || (!flag9 && charCode != 8203 && charCode != 173 && charCode != 3) || (charCode == 173 && !flag7) || m_TextElementType == TextElementType.Sprite)
				{
					textInfo.textElementInfo[m_CharacterCount].isVisible = true;
					float marginLeft = m_MarginLeft;
					float marginRight = m_MarginRight;
					if (flag8)
					{
						marginLeft = textInfo.lineInfo[m_LineNumber].marginLeft;
						marginRight = textInfo.lineInfo[m_LineNumber].marginRight;
					}
					num8 = ((m_Width != -1f) ? Mathf.Min(num6 + 0.0001f - marginLeft - marginRight, m_Width) : (num6 + 0.0001f - marginLeft - marginRight));
					float num39 = Mathf.Abs(m_XAdvance) + ((!generationSettings.isRightToLeft) ? glyphMetrics.horizontalAdvance : 0f) * (1f - m_CharWidthAdjDelta) * ((charCode == 173) ? num20 : num2);
					float num40 = m_MaxAscender - (m_MaxLineDescender - m_LineOffset) + ((m_LineOffset > 0f && !m_IsDrivenLineSpacing) ? (m_MaxLineAscender - m_StartOfLineAscender) : 0f);
					int characterCount = m_CharacterCount;
					if (num40 > num7 + 0.0001f)
					{
						if (m_FirstOverflowCharacterIndex == -1)
						{
							m_FirstOverflowCharacterIndex = m_CharacterCount;
						}
						bool flag14 = false;
						switch (generationSettings.overflowMode)
						{
						case TextOverflowMode.Truncate:
							i = RestoreWordWrappingState(ref m_SavedLastValidState, textInfo);
							characterSubstitution.index = characterCount;
							characterSubstitution.unicode = 3u;
							continue;
						case TextOverflowMode.Ellipsis:
							if (m_LineNumber > 0)
							{
								if (m_EllipsisInsertionCandidateStack.Count == 0)
								{
									i = -1;
									m_CharacterCount = 0;
									characterSubstitution.index = 0;
									characterSubstitution.unicode = 3u;
									m_FirstCharacterOfLine = 0;
								}
								else
								{
									WordWrapState state = m_EllipsisInsertionCandidateStack.Pop();
									i = RestoreWordWrappingState(ref state, textInfo);
									i--;
									m_CharacterCount--;
									characterSubstitution.index = m_CharacterCount;
									characterSubstitution.unicode = 8230u;
									num10++;
								}
								continue;
							}
							break;
						case TextOverflowMode.Linked:
							i = RestoreWordWrappingState(ref m_SavedLastValidState, textInfo);
							characterSubstitution.index = characterCount;
							characterSubstitution.unicode = 3u;
							continue;
						}
					}
					if (flag10 && num39 > num8)
					{
						if (textWrappingMode != TextWrappingMode.NoWrap && textWrappingMode != TextWrappingMode.PreserveWhitespaceNoWrap && m_CharacterCount != m_FirstCharacterOfLine)
						{
							i = RestoreWordWrappingState(ref m_SavedWordWrapState, textInfo);
							float num41 = 0f;
							if (m_LineHeight == -32767f)
							{
								float adjustedAscender = textInfo.textElementInfo[m_CharacterCount].adjustedAscender;
								num41 = ((m_LineOffset > 0f && !m_IsDrivenLineSpacing) ? (m_MaxLineAscender - m_StartOfLineAscender) : 0f) - m_MaxLineDescender + adjustedAscender + (num5 + m_LineSpacingDelta) * num + 0f * num3;
							}
							else
							{
								num41 = m_LineHeight + 0f * num3;
								m_IsDrivenLineSpacing = true;
							}
							float num42 = m_MaxAscender + num41 + m_LineOffset - textInfo.textElementInfo[m_CharacterCount].adjustedDescender;
							if (textInfo.textElementInfo[m_CharacterCount - 1].character == 173 && !flag7 && (generationSettings.overflowMode == TextOverflowMode.Overflow || num42 < num7 + 0.0001f))
							{
								characterSubstitution.index = m_CharacterCount - 1;
								characterSubstitution.unicode = 45u;
								i--;
								m_CharacterCount--;
								continue;
							}
							flag7 = false;
							if (textInfo.textElementInfo[m_CharacterCount].character == 173)
							{
								flag7 = true;
								continue;
							}
							bool flag15 = false;
							int previousWordBreak = m_SavedSoftLineBreakState.previousWordBreak;
							if (flag5 && previousWordBreak != -1 && previousWordBreak != num9)
							{
								i = RestoreWordWrappingState(ref m_SavedSoftLineBreakState, textInfo);
								num9 = previousWordBreak;
								if (textInfo.textElementInfo[m_CharacterCount - 1].character == 173)
								{
									characterSubstitution.index = m_CharacterCount - 1;
									characterSubstitution.unicode = 45u;
									i--;
									m_CharacterCount--;
									continue;
								}
							}
							if (!(num42 > num7 + 0.0001f))
							{
								InsertNewLine(i, num, num2, num3, num31, num21, num8, num5, ref isMaxVisibleDescenderSet, ref maxVisibleDescender, generationSettings, textInfo);
								flag = true;
								flag5 = true;
								continue;
							}
							if (m_FirstOverflowCharacterIndex == -1)
							{
								m_FirstOverflowCharacterIndex = m_CharacterCount;
							}
							bool flag16 = false;
							switch (generationSettings.overflowMode)
							{
							case TextOverflowMode.Overflow:
							case TextOverflowMode.Masking:
							case TextOverflowMode.ScrollRect:
								InsertNewLine(i, num, num2, num3, num31, num21, num8, num5, ref isMaxVisibleDescenderSet, ref maxVisibleDescender, generationSettings, textInfo);
								flag = true;
								flag5 = true;
								continue;
							case TextOverflowMode.Truncate:
								i = RestoreWordWrappingState(ref m_SavedLastValidState, textInfo);
								characterSubstitution.index = characterCount;
								characterSubstitution.unicode = 3u;
								continue;
							case TextOverflowMode.Ellipsis:
								if (m_EllipsisInsertionCandidateStack.Count == 0)
								{
									i = -1;
									m_CharacterCount = 0;
									characterSubstitution.index = 0;
									characterSubstitution.unicode = 3u;
									m_FirstCharacterOfLine = 0;
								}
								else
								{
									WordWrapState state2 = m_EllipsisInsertionCandidateStack.Pop();
									i = RestoreWordWrappingState(ref state2, textInfo);
									i--;
									m_CharacterCount--;
									characterSubstitution.index = m_CharacterCount;
									characterSubstitution.unicode = 8230u;
									num10++;
								}
								continue;
							case TextOverflowMode.Linked:
								characterSubstitution.index = m_CharacterCount;
								characterSubstitution.unicode = 3u;
								continue;
							}
						}
						else
						{
							bool flag17 = false;
							switch (generationSettings.overflowMode)
							{
							case TextOverflowMode.Truncate:
								i = RestoreWordWrappingState(ref m_SavedWordWrapState, textInfo);
								characterSubstitution.index = characterCount;
								characterSubstitution.unicode = 3u;
								continue;
							case TextOverflowMode.Ellipsis:
								if (m_EllipsisInsertionCandidateStack.Count == 0)
								{
									i = -1;
									m_CharacterCount = 0;
									characterSubstitution.index = 0;
									characterSubstitution.unicode = 3u;
									m_FirstCharacterOfLine = 0;
								}
								else
								{
									WordWrapState state3 = m_EllipsisInsertionCandidateStack.Pop();
									i = RestoreWordWrappingState(ref state3, textInfo);
									i--;
									m_CharacterCount--;
									characterSubstitution.index = m_CharacterCount;
									characterSubstitution.unicode = 8230u;
									num10++;
								}
								continue;
							case TextOverflowMode.Linked:
								i = RestoreWordWrappingState(ref m_SavedWordWrapState, textInfo);
								characterSubstitution.index = m_CharacterCount;
								characterSubstitution.unicode = 3u;
								continue;
							}
						}
					}
					if (flag9)
					{
						textInfo.textElementInfo[m_CharacterCount].isVisible = false;
						m_LineVisibleSpaceCount = ++textInfo.lineInfo[m_LineNumber].spaceCount;
						textInfo.lineInfo[m_LineNumber].marginLeft = marginLeft;
						textInfo.lineInfo[m_LineNumber].marginRight = marginRight;
						textInfo.spaceCount++;
						if (charCode == 160)
						{
							textInfo.lineInfo[m_LineNumber].controlCharacterCount++;
						}
					}
					else if (charCode == 173)
					{
						textInfo.textElementInfo[m_CharacterCount].isVisible = false;
					}
					else
					{
						Color32 htmlColor = m_HtmlColor;
						if (m_TextElementType == TextElementType.Character)
						{
							SaveGlyphVertexInfo(num4, num30, htmlColor, generationSettings, textInfo);
						}
						else if (m_TextElementType == TextElementType.Sprite)
						{
							SaveSpriteVertexInfo(htmlColor, generationSettings, textInfo);
						}
						if (flag)
						{
							flag = false;
							m_FirstVisibleCharacterOfLine = m_CharacterCount;
						}
						m_LineVisibleCharacterCount++;
						m_LastVisibleCharacterOfLine = m_CharacterCount;
						textInfo.lineInfo[m_LineNumber].marginLeft = marginLeft;
						textInfo.lineInfo[m_LineNumber].marginRight = marginRight;
					}
				}
				else
				{
					if (generationSettings.overflowMode == TextOverflowMode.Linked && (charCode == 10 || charCode == 11))
					{
						float num43 = m_MaxAscender - (m_MaxLineDescender - m_LineOffset) + ((m_LineOffset > 0f && !m_IsDrivenLineSpacing) ? (m_MaxLineAscender - m_StartOfLineAscender) : 0f);
						int characterCount2 = m_CharacterCount;
						if (num43 > num7 + 0.0001f)
						{
							if (m_FirstOverflowCharacterIndex == -1)
							{
								m_FirstOverflowCharacterIndex = m_CharacterCount;
							}
							i = RestoreWordWrappingState(ref m_SavedLastValidState, textInfo);
							characterSubstitution.index = characterCount2;
							characterSubstitution.unicode = 3u;
							continue;
						}
					}
					if ((charCode == 10 || charCode == 11 || charCode == 160 || charCode == 8199 || charCode == 8232 || charCode == 8233 || char.IsSeparator((char)charCode)) && charCode != 173 && charCode != 8203 && charCode != 8288)
					{
						textInfo.lineInfo[m_LineNumber].spaceCount++;
						textInfo.spaceCount++;
					}
					if (charCode == 160)
					{
						textInfo.lineInfo[m_LineNumber].controlCharacterCount++;
					}
				}
				if (generationSettings.overflowMode == TextOverflowMode.Ellipsis && (!flag8 || charCode == 45))
				{
					float num44 = m_CurrentFontSize / m_Ellipsis.fontAsset.m_FaceInfo.pointSize * m_Ellipsis.fontAsset.m_FaceInfo.scale;
					float num45 = num44 * m_FontScaleMultiplier * m_Ellipsis.character.m_Scale * m_Ellipsis.character.m_Glyph.scale;
					float marginLeft2 = m_MarginLeft;
					float marginRight2 = m_MarginRight;
					if (charCode == 10 && m_CharacterCount != m_FirstCharacterOfLine)
					{
						num44 = textInfo.textElementInfo[m_CharacterCount - 1].pointSize / m_Ellipsis.fontAsset.m_FaceInfo.pointSize * m_Ellipsis.fontAsset.m_FaceInfo.scale;
						num45 = num44 * m_FontScaleMultiplier * m_Ellipsis.character.m_Scale * m_Ellipsis.character.m_Glyph.scale;
						marginLeft2 = textInfo.lineInfo[m_LineNumber].marginLeft;
						marginRight2 = textInfo.lineInfo[m_LineNumber].marginRight;
					}
					float num46 = Mathf.Abs(m_XAdvance) + ((!generationSettings.isRightToLeft) ? m_Ellipsis.character.m_Glyph.metrics.horizontalAdvance : 0f) * (1f - m_CharWidthAdjDelta) * num45;
					float num47 = ((m_Width != -1f) ? Mathf.Min(num6 + 0.0001f - marginLeft2 - marginRight2, m_Width) : (num6 + 0.0001f - marginLeft2 - marginRight2));
					if (num46 < num47)
					{
						SaveWordWrappingState(ref m_SavedEllipsisState, i, m_CharacterCount, textInfo);
						m_EllipsisInsertionCandidateStack.Push(m_SavedEllipsisState);
					}
				}
				textInfo.textElementInfo[m_CharacterCount].lineNumber = m_LineNumber;
				if ((charCode != 10 && charCode != 11 && charCode != 13 && !flag8) || textInfo.lineInfo[m_LineNumber].characterCount == 1)
				{
					textInfo.lineInfo[m_LineNumber].alignment = m_LineJustification;
				}
				if (charCode != 8203)
				{
					if (charCode == 9)
					{
						float num48 = m_CurrentFontAsset.m_FaceInfo.tabWidth * (float)(int)m_CurrentFontAsset.tabMultiple * num2;
						float num49 = Mathf.Ceil(m_XAdvance / num48) * num48;
						m_XAdvance = ((num49 > m_XAdvance) ? num49 : (m_XAdvance + num48));
					}
					else if (m_MonoSpacing != 0f)
					{
						float num50 = ((!m_DuoSpace || (charCode != 46 && charCode != 58 && charCode != 44)) ? (m_MonoSpacing - num28) : (m_MonoSpacing / 2f - num28));
						m_XAdvance += (num50 + (m_CurrentFontAsset.regularStyleSpacing + num21) * num3 + m_CSpacing) * (1f - m_CharWidthAdjDelta);
						if (flag9 || charCode == 8203)
						{
							m_XAdvance += generationSettings.wordSpacing * num3;
						}
					}
					else if (generationSettings.isRightToLeft)
					{
						m_XAdvance -= (glyphValueRecord.xAdvance * num2 + (m_CurrentFontAsset.regularStyleSpacing + num21 + num31) * num3 + m_CSpacing) * (1f - m_CharWidthAdjDelta);
						if (flag9 || charCode == 8203)
						{
							m_XAdvance -= generationSettings.wordSpacing * num3;
						}
					}
					else
					{
						m_XAdvance += ((glyphMetrics.horizontalAdvance * m_FXScale.x + glyphValueRecord.xAdvance) * num2 + (m_CurrentFontAsset.regularStyleSpacing + num21 + num31) * num3 + m_CSpacing) * (1f - m_CharWidthAdjDelta);
						if (flag9 || charCode == 8203)
						{
							m_XAdvance += generationSettings.wordSpacing * num3;
						}
					}
				}
				textInfo.textElementInfo[m_CharacterCount].xAdvance = m_XAdvance;
				if (charCode == 13)
				{
					m_XAdvance = 0f + m_TagIndent;
				}
				if (charCode == 10 || charCode == 11 || charCode == 3 || charCode == 8232 || charCode == 8232 || (charCode == 45 && flag8) || m_CharacterCount == totalCharacterCount - 1)
				{
					float num51 = m_MaxLineAscender - m_StartOfLineAscender;
					if (m_LineOffset > 0f && Math.Abs(num51) > 0.01f && !m_IsDrivenLineSpacing)
					{
						TextGeneratorUtilities.AdjustLineOffset(m_FirstCharacterOfLine, m_CharacterCount, Round(num51), textInfo);
						m_MaxDescender -= num51;
						m_LineOffset += num51;
						if (m_SavedEllipsisState.lineNumber == m_LineNumber)
						{
							m_SavedEllipsisState = m_EllipsisInsertionCandidateStack.Pop();
							m_SavedEllipsisState.startOfLineAscender += num51;
							m_SavedEllipsisState.lineOffset += num51;
							m_EllipsisInsertionCandidateStack.Push(m_SavedEllipsisState);
						}
					}
					float num52 = m_MaxLineAscender - m_LineOffset;
					float num53 = m_MaxLineDescender - m_LineOffset;
					m_MaxDescender = ((m_MaxDescender < num53) ? m_MaxDescender : num53);
					if (!isMaxVisibleDescenderSet)
					{
						maxVisibleDescender = m_MaxDescender;
					}
					bool flag18 = false;
					textInfo.lineInfo[m_LineNumber].firstCharacterIndex = m_FirstCharacterOfLine;
					textInfo.lineInfo[m_LineNumber].firstVisibleCharacterIndex = (m_FirstVisibleCharacterOfLine = ((m_FirstCharacterOfLine > m_FirstVisibleCharacterOfLine) ? m_FirstCharacterOfLine : m_FirstVisibleCharacterOfLine));
					textInfo.lineInfo[m_LineNumber].lastCharacterIndex = (m_LastCharacterOfLine = m_CharacterCount);
					textInfo.lineInfo[m_LineNumber].lastVisibleCharacterIndex = (m_LastVisibleCharacterOfLine = ((m_LastVisibleCharacterOfLine < m_FirstVisibleCharacterOfLine) ? m_FirstVisibleCharacterOfLine : m_LastVisibleCharacterOfLine));
					int num54 = m_FirstVisibleCharacterOfLine;
					int num55 = m_LastVisibleCharacterOfLine;
					if ((generationSettings.textWrappingMode == TextWrappingMode.PreserveWhitespace || generationSettings.textWrappingMode == TextWrappingMode.PreserveWhitespaceNoWrap) && textInfo.textElementInfo[m_LastCharacterOfLine].xAdvance != 0f)
					{
						num54 = m_FirstCharacterOfLine;
						num55 = m_LastCharacterOfLine;
					}
					textInfo.lineInfo[m_LineNumber].characterCount = textInfo.lineInfo[m_LineNumber].lastCharacterIndex - textInfo.lineInfo[m_LineNumber].firstCharacterIndex + 1;
					textInfo.lineInfo[m_LineNumber].visibleCharacterCount = m_LineVisibleCharacterCount;
					textInfo.lineInfo[m_LineNumber].visibleSpaceCount = textInfo.lineInfo[m_LineNumber].lastVisibleCharacterIndex + 1 - textInfo.lineInfo[m_LineNumber].firstCharacterIndex - m_LineVisibleCharacterCount;
					textInfo.lineInfo[m_LineNumber].lineExtents.min = new Vector2(textInfo.textElementInfo[num54].bottomLeft.x, num53);
					textInfo.lineInfo[m_LineNumber].lineExtents.max = new Vector2(textInfo.textElementInfo[num55].topRight.x, num52);
					textInfo.lineInfo[m_LineNumber].length = (generationSettings.isIMGUI ? textInfo.textElementInfo[num55].xAdvance : (textInfo.lineInfo[m_LineNumber].lineExtents.max.x - num4 * num2));
					textInfo.lineInfo[m_LineNumber].width = num8;
					if (textInfo.lineInfo[m_LineNumber].characterCount == 1)
					{
						textInfo.lineInfo[m_LineNumber].alignment = m_LineJustification;
					}
					float num56 = ((m_CurrentFontAsset.regularStyleSpacing + num21 + num31) * num3 + m_CSpacing) * (1f - m_CharWidthAdjDelta);
					if (textInfo.textElementInfo[m_LastVisibleCharacterOfLine].isVisible)
					{
						textInfo.lineInfo[m_LineNumber].maxAdvance = textInfo.textElementInfo[m_LastVisibleCharacterOfLine].xAdvance + (generationSettings.isRightToLeft ? num56 : (0f - num56));
					}
					else
					{
						textInfo.lineInfo[m_LineNumber].maxAdvance = textInfo.textElementInfo[m_LastCharacterOfLine].xAdvance + (generationSettings.isRightToLeft ? num56 : (0f - num56));
					}
					textInfo.lineInfo[m_LineNumber].baseline = 0f - m_LineOffset;
					textInfo.lineInfo[m_LineNumber].ascender = num52;
					textInfo.lineInfo[m_LineNumber].descender = num53;
					textInfo.lineInfo[m_LineNumber].lineHeight = num52 - num53 + num5 * num;
					if (charCode == 10 || charCode == 11 || charCode == 45 || charCode == 8232 || charCode == 8233)
					{
						SaveWordWrappingState(ref m_SavedLineState, i, m_CharacterCount, textInfo);
						m_LineNumber++;
						flag = true;
						flag6 = false;
						flag5 = true;
						m_FirstCharacterOfLine = m_CharacterCount + 1;
						m_LineVisibleCharacterCount = 0;
						m_LineVisibleSpaceCount = 0;
						if (m_LineNumber >= textInfo.lineInfo.Length)
						{
							TextGeneratorUtilities.ResizeLineExtents(m_LineNumber, textInfo);
						}
						float adjustedAscender2 = textInfo.textElementInfo[m_CharacterCount].adjustedAscender;
						if (m_LineHeight == -32767f)
						{
							float num57 = 0f - m_MaxLineDescender + adjustedAscender2 + (num5 + m_LineSpacingDelta) * num + (0f + ((charCode == 10 || charCode == 8233) ? generationSettings.paragraphSpacing : 0f)) * num3;
							m_LineOffset += num57;
							m_IsDrivenLineSpacing = false;
						}
						else
						{
							m_LineOffset += m_LineHeight + (0f + ((charCode == 10 || charCode == 8233) ? generationSettings.paragraphSpacing : 0f)) * num3;
							m_IsDrivenLineSpacing = true;
						}
						m_MaxLineAscender = -32767f;
						m_MaxLineDescender = 32767f;
						m_StartOfLineAscender = adjustedAscender2;
						m_XAdvance = 0f + m_TagLineIndent + m_TagIndent;
						SaveWordWrappingState(ref m_SavedWordWrapState, i, m_CharacterCount, textInfo);
						SaveWordWrappingState(ref m_SavedLastValidState, i, m_CharacterCount, textInfo);
						m_CharacterCount++;
						continue;
					}
					if (charCode == 3)
					{
						i = m_TextProcessingArray.Length;
					}
				}
				if (textInfo.textElementInfo[m_CharacterCount].isVisible)
				{
					m_MeshExtents.min.x = Mathf.Min(m_MeshExtents.min.x, textInfo.textElementInfo[m_CharacterCount].bottomLeft.x);
					m_MeshExtents.min.y = Mathf.Min(m_MeshExtents.min.y, textInfo.textElementInfo[m_CharacterCount].bottomLeft.y);
					m_MeshExtents.max.x = Mathf.Max(m_MeshExtents.max.x, textInfo.textElementInfo[m_CharacterCount].topRight.x);
					m_MeshExtents.max.y = Mathf.Max(m_MeshExtents.max.y, textInfo.textElementInfo[m_CharacterCount].topRight.y);
				}
				if ((textWrappingMode != TextWrappingMode.NoWrap && textWrappingMode != TextWrappingMode.PreserveWhitespaceNoWrap) || generationSettings.overflowMode == TextOverflowMode.Truncate || generationSettings.overflowMode == TextOverflowMode.Ellipsis || generationSettings.overflowMode == TextOverflowMode.Linked)
				{
					bool flag19 = false;
					bool flag20 = false;
					if ((flag9 || charCode == 8203 || (charCode == 45 && (m_CharacterCount <= 0 || !char.IsWhiteSpace((char)textInfo.textElementInfo[m_CharacterCount - 1].character))) || charCode == 173) && (!m_IsNonBreakingSpace || flag6) && charCode != 160 && charCode != 8199 && charCode != 8209 && charCode != 8239 && charCode != 8288)
					{
						if (charCode != 45 || m_CharacterCount <= 0 || !char.IsWhiteSpace((char)textInfo.textElementInfo[m_CharacterCount - 1].character))
						{
							flag5 = false;
							flag19 = true;
							m_SavedSoftLineBreakState.previousWordBreak = -1;
						}
					}
					else if (!m_IsNonBreakingSpace && ((TextGeneratorUtilities.IsHangul(charCode) && !textSettings.lineBreakingRules.useModernHangulLineBreakingRules) || TextGeneratorUtilities.IsCJK(charCode)))
					{
						bool flag21 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(charCode);
						bool flag22 = m_CharacterCount < totalCharacterCount - 1 && textSettings.lineBreakingRules.followingCharactersLookup.Contains(textInfo.textElementInfo[m_CharacterCount + 1].character);
						if (!flag21)
						{
							if (!flag22)
							{
								flag5 = false;
								flag19 = true;
							}
							if (flag5)
							{
								if (flag9)
								{
									flag20 = true;
								}
								flag19 = true;
							}
						}
						else if (flag5 && flag13)
						{
							if (flag9)
							{
								flag20 = true;
							}
							flag19 = true;
						}
					}
					else if (!m_IsNonBreakingSpace && m_CharacterCount + 1 < totalCharacterCount && TextGeneratorUtilities.IsCJK(textInfo.textElementInfo[m_CharacterCount + 1].character))
					{
						uint character = textInfo.textElementInfo[m_CharacterCount + 1].character;
						bool flag23 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(charCode);
						bool flag24 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(character);
						if (!flag23 && !flag24)
						{
							flag19 = true;
						}
					}
					else if (flag5)
					{
						if ((flag9 && charCode != 160) || (charCode == 173 && !flag7))
						{
							flag20 = true;
						}
						flag19 = true;
					}
					if (flag19)
					{
						SaveWordWrappingState(ref m_SavedWordWrapState, i, m_CharacterCount, textInfo);
					}
					if (flag20)
					{
						SaveWordWrappingState(ref m_SavedSoftLineBreakState, i, m_CharacterCount, textInfo);
					}
				}
				SaveWordWrappingState(ref m_SavedLastValidState, i, m_CharacterCount, textInfo);
				m_CharacterCount++;
			}
			CloseAllLinkTags(textInfo);
		}

		private void InsertNewLine(int i, float baseScale, float currentElementScale, float currentEmScale, float boldSpacingAdjustment, float characterSpacingAdjustment, float width, float lineGap, ref bool isMaxVisibleDescenderSet, ref float maxVisibleDescender, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			float num = m_MaxLineAscender - m_StartOfLineAscender;
			if (m_LineOffset > 0f && Math.Abs(num) > 0.01f && !m_IsDrivenLineSpacing)
			{
				TextGeneratorUtilities.AdjustLineOffset(m_FirstCharacterOfLine, m_CharacterCount, Round(num), textInfo);
				m_MaxDescender -= num;
				m_LineOffset += num;
			}
			float num2 = m_MaxLineAscender - m_LineOffset;
			float num3 = m_MaxLineDescender - m_LineOffset;
			m_MaxDescender = ((m_MaxDescender < num3) ? m_MaxDescender : num3);
			if (!isMaxVisibleDescenderSet)
			{
				maxVisibleDescender = m_MaxDescender;
			}
			bool flag = false;
			textInfo.lineInfo[m_LineNumber].firstCharacterIndex = m_FirstCharacterOfLine;
			textInfo.lineInfo[m_LineNumber].firstVisibleCharacterIndex = (m_FirstVisibleCharacterOfLine = ((m_FirstCharacterOfLine > m_FirstVisibleCharacterOfLine) ? m_FirstCharacterOfLine : m_FirstVisibleCharacterOfLine));
			textInfo.lineInfo[m_LineNumber].lastCharacterIndex = (m_LastCharacterOfLine = ((m_CharacterCount - 1 > 0) ? (m_CharacterCount - 1) : 0));
			textInfo.lineInfo[m_LineNumber].lastVisibleCharacterIndex = (m_LastVisibleCharacterOfLine = ((m_LastVisibleCharacterOfLine < m_FirstVisibleCharacterOfLine) ? m_FirstVisibleCharacterOfLine : m_LastVisibleCharacterOfLine));
			textInfo.lineInfo[m_LineNumber].characterCount = textInfo.lineInfo[m_LineNumber].lastCharacterIndex - textInfo.lineInfo[m_LineNumber].firstCharacterIndex + 1;
			textInfo.lineInfo[m_LineNumber].visibleCharacterCount = m_LineVisibleCharacterCount;
			textInfo.lineInfo[m_LineNumber].visibleSpaceCount = textInfo.lineInfo[m_LineNumber].lastVisibleCharacterIndex + 1 - textInfo.lineInfo[m_LineNumber].firstCharacterIndex - m_LineVisibleCharacterCount;
			textInfo.lineInfo[m_LineNumber].lineExtents.min = new Vector2(textInfo.textElementInfo[m_FirstVisibleCharacterOfLine].bottomLeft.x, num3);
			textInfo.lineInfo[m_LineNumber].lineExtents.max = new Vector2(textInfo.textElementInfo[m_LastVisibleCharacterOfLine].topRight.x, num2);
			textInfo.lineInfo[m_LineNumber].length = (generationSettings.isIMGUI ? textInfo.textElementInfo[m_LastVisibleCharacterOfLine].xAdvance : textInfo.lineInfo[m_LineNumber].lineExtents.max.x);
			textInfo.lineInfo[m_LineNumber].width = width;
			float adjustedHorizontalAdvance = textInfo.textElementInfo[m_LastVisibleCharacterOfLine].adjustedHorizontalAdvance;
			float num4 = (adjustedHorizontalAdvance * currentElementScale + (m_CurrentFontAsset.regularStyleSpacing + characterSpacingAdjustment + boldSpacingAdjustment) * currentEmScale + m_CSpacing) * 1f;
			float v = (textInfo.lineInfo[m_LineNumber].maxAdvance = textInfo.textElementInfo[m_LastVisibleCharacterOfLine].xAdvance + (generationSettings.isRightToLeft ? num4 : (0f - num4)));
			textInfo.textElementInfo[m_LastVisibleCharacterOfLine].xAdvance = Round(v);
			textInfo.lineInfo[m_LineNumber].baseline = 0f - m_LineOffset;
			textInfo.lineInfo[m_LineNumber].ascender = num2;
			textInfo.lineInfo[m_LineNumber].descender = num3;
			textInfo.lineInfo[m_LineNumber].lineHeight = num2 - num3 + lineGap * baseScale;
			m_FirstCharacterOfLine = m_CharacterCount;
			m_LineVisibleCharacterCount = 0;
			m_LineVisibleSpaceCount = 0;
			SaveWordWrappingState(ref m_SavedLineState, i, m_CharacterCount - 1, textInfo);
			m_LineNumber++;
			if (m_LineNumber >= textInfo.lineInfo.Length)
			{
				TextGeneratorUtilities.ResizeLineExtents(m_LineNumber, textInfo);
			}
			if (m_LineHeight == -32767f)
			{
				float adjustedAscender = textInfo.textElementInfo[m_CharacterCount].adjustedAscender;
				float num5 = 0f - m_MaxLineDescender + adjustedAscender + (lineGap + m_LineSpacingDelta) * baseScale + 0f * currentEmScale;
				m_LineOffset += num5;
				m_StartOfLineAscender = adjustedAscender;
			}
			else
			{
				m_LineOffset += m_LineHeight + 0f * currentEmScale;
			}
			m_MaxLineAscender = -32767f;
			m_MaxLineDescender = 32767f;
			m_XAdvance = 0f + m_TagIndent;
		}

		public Vector2 GetPreferredValues(TextGenerationSettings settings, TextInfo textInfo)
		{
			if (settings.fontAsset == null || settings.fontAsset.characterLookupTable == null)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				return Vector2.zero;
			}
			if (settings.fontSize <= 0)
			{
				return Vector2.zero;
			}
			Prepare(settings, textInfo);
			return GetPreferredValuesInternal(settings, textInfo);
		}

		private Vector2 GetPreferredValuesInternal(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			if (generationSettings.textSettings == null)
			{
				return Vector2.zero;
			}
			float fontSize = m_FontSize;
			m_MinFontSize = 0f;
			m_MaxFontSize = 0f;
			m_CharWidthAdjDelta = 0f;
			Vector2 marginSize = new Vector2((m_MarginWidth != 0f) ? m_MarginWidth : 32767f, (m_MarginHeight != 0f) ? m_MarginHeight : 32767f);
			m_AutoSizeIterationCount = 0;
			return CalculatePreferredValues(ref fontSize, marginSize, isTextAutoSizingEnabled: false, generationSettings, textInfo);
		}

		protected virtual Vector2 CalculatePreferredValues(ref float fontSize, Vector2 marginSize, bool isTextAutoSizingEnabled, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			if (generationSettings.fontAsset == null || generationSettings.fontAsset.characterLookupTable == null)
			{
				Debug.LogWarning("Can't Generate Mesh! No Font Asset has been assigned.");
				return Vector2.zero;
			}
			if (m_TextProcessingArray == null || m_TextProcessingArray.Length == 0 || m_TextProcessingArray[0].unicode == 0)
			{
				return Vector2.zero;
			}
			m_CurrentFontAsset = generationSettings.fontAsset;
			m_CurrentMaterial = generationSettings.fontAsset.material;
			m_CurrentMaterialIndex = 0;
			m_MaterialReferenceStack.SetDefault(new MaterialReference(0, m_CurrentFontAsset, null, m_CurrentMaterial, m_Padding));
			int totalCharacterCount = m_TotalCharacterCount;
			if (m_InternalTextElementInfo == null || totalCharacterCount > m_InternalTextElementInfo.Length)
			{
				m_InternalTextElementInfo = new TextElementInfo[(totalCharacterCount > 1024) ? (totalCharacterCount + 256) : Mathf.NextPowerOfTwo(totalCharacterCount)];
			}
			float num = fontSize / generationSettings.fontAsset.faceInfo.pointSize * generationSettings.fontAsset.faceInfo.scale;
			float num2 = num;
			float num3 = fontSize * 0.01f;
			m_FontScaleMultiplier = 1f;
			m_ShouldRenderBitmap = generationSettings.fontAsset.IsBitmap();
			m_CurrentFontSize = fontSize;
			m_SizeStack.SetDefault(m_CurrentFontSize);
			float num4 = 0f;
			m_FontStyleInternal = generationSettings.fontStyle;
			m_FontWeightInternal = (((m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			m_FontWeightStack.SetDefault(m_FontWeightInternal);
			m_FontStyleStack.Clear();
			m_LineJustification = generationSettings.textAlignment;
			m_LineJustificationStack.SetDefault(m_LineJustification);
			m_BaselineOffset = 0f;
			m_BaselineOffsetStack.Clear();
			m_FXScale = Vector3.one;
			m_LineOffset = 0f;
			m_LineHeight = -32767f;
			float num5 = Round(m_CurrentFontAsset.faceInfo.lineHeight - (m_CurrentFontAsset.faceInfo.ascentLine - m_CurrentFontAsset.faceInfo.descentLine));
			m_CSpacing = 0f;
			m_MonoSpacing = 0f;
			m_XAdvance = 0f;
			m_TagLineIndent = 0f;
			m_TagIndent = 0f;
			m_IndentStack.SetDefault(0f);
			m_TagNoParsing = false;
			m_CharacterCount = 0;
			m_FirstCharacterOfLine = 0;
			m_MaxLineAscender = -32767f;
			m_MaxLineDescender = 32767f;
			m_LineNumber = 0;
			m_StartOfLineAscender = 0f;
			m_IsDrivenLineSpacing = false;
			m_LastBaseGlyphIndex = int.MinValue;
			bool flag = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.kern);
			bool flag2 = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.mark);
			bool flag3 = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.mkmk);
			TextSettings textSettings = generationSettings.textSettings;
			float x = marginSize.x;
			float y = marginSize.y;
			m_MarginLeft = 0f;
			m_MarginRight = 0f;
			m_Width = -1f;
			float num6 = x + 0.0001f - m_MarginLeft - m_MarginRight;
			TextWrappingMode textWrappingMode = generationSettings.textWrappingMode;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			m_IsCalculatingPreferredValues = true;
			m_MaxCapHeight = 0f;
			m_MaxAscender = 0f;
			m_MaxDescender = 0f;
			float num10 = 0f;
			bool flag4 = false;
			bool flag5 = true;
			m_IsNonBreakingSpace = false;
			bool flag6 = false;
			CharacterSubstitution characterSubstitution = new CharacterSubstitution(-1, 0u);
			bool flag7 = false;
			WordWrapState state = default(WordWrapState);
			WordWrapState state2 = default(WordWrapState);
			WordWrapState state3 = default(WordWrapState);
			m_IsTextTruncated = false;
			m_AutoSizeIterationCount++;
			for (int i = 0; i < m_TextProcessingArray.Length && m_TextProcessingArray[i].unicode != 0; i++)
			{
				uint num11 = m_TextProcessingArray[i].unicode;
				if (num11 == 26)
				{
					continue;
				}
				if (generationSettings.richText && num11 == 60)
				{
					m_isTextLayoutPhase = true;
					m_TextElementType = TextElementType.Character;
					if (ValidateHtmlTag(m_TextProcessingArray, i + 1, out var endIndex, generationSettings, textInfo, out var _))
					{
						i = endIndex;
						if (m_TextElementType == TextElementType.Character)
						{
							continue;
						}
					}
				}
				else
				{
					m_TextElementType = textInfo.textElementInfo[m_CharacterCount].elementType;
					m_CurrentMaterialIndex = textInfo.textElementInfo[m_CharacterCount].materialReferenceIndex;
					m_CurrentFontAsset = textInfo.textElementInfo[m_CharacterCount].fontAsset;
				}
				int currentMaterialIndex = m_CurrentMaterialIndex;
				bool isUsingAlternateTypeface = textInfo.textElementInfo[m_CharacterCount].isUsingAlternateTypeface;
				m_isTextLayoutPhase = false;
				bool flag8 = false;
				if (characterSubstitution.index == m_CharacterCount)
				{
					num11 = characterSubstitution.unicode;
					m_TextElementType = TextElementType.Character;
					flag8 = true;
					switch (num11)
					{
					case 3u:
						m_InternalTextElementInfo[m_CharacterCount].textElement = m_CurrentFontAsset.characterLookupTable[3u];
						m_IsTextTruncated = true;
						break;
					case 8230u:
						m_InternalTextElementInfo[m_CharacterCount].textElement = m_Ellipsis.character;
						m_InternalTextElementInfo[m_CharacterCount].elementType = TextElementType.Character;
						m_InternalTextElementInfo[m_CharacterCount].fontAsset = m_Ellipsis.fontAsset;
						m_InternalTextElementInfo[m_CharacterCount].material = m_Ellipsis.material;
						m_InternalTextElementInfo[m_CharacterCount].materialReferenceIndex = m_Ellipsis.materialIndex;
						m_IsTextTruncated = true;
						characterSubstitution.index = m_CharacterCount + 1;
						characterSubstitution.unicode = 3u;
						break;
					}
				}
				if (m_CharacterCount < 0 && num11 != 3)
				{
					m_InternalTextElementInfo[m_CharacterCount].isVisible = false;
					m_InternalTextElementInfo[m_CharacterCount].character = 8203u;
					m_InternalTextElementInfo[m_CharacterCount].lineNumber = 0;
					m_CharacterCount++;
					continue;
				}
				float num12 = 1f;
				if (m_TextElementType == TextElementType.Character)
				{
					if ((m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase)
					{
						if (char.IsLower((char)num11))
						{
							num11 = char.ToUpper((char)num11);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase)
					{
						if (char.IsUpper((char)num11))
						{
							num11 = char.ToLower((char)num11);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps && char.IsLower((char)num11))
					{
						num12 = 0.8f;
						num11 = char.ToUpper((char)num11);
					}
				}
				float num13 = 0f;
				float num14 = 0f;
				float num15 = 0f;
				if (m_TextElementType == TextElementType.Sprite)
				{
					SpriteCharacter spriteCharacter = (SpriteCharacter)textInfo.textElementInfo[m_CharacterCount].textElement;
					m_CurrentSpriteAsset = spriteCharacter.textAsset as SpriteAsset;
					m_SpriteIndex = (int)spriteCharacter.glyphIndex;
					if (spriteCharacter == null)
					{
						continue;
					}
					if (num11 == 60)
					{
						num11 = (uint)(57344 + m_SpriteIndex);
					}
					if (m_CurrentSpriteAsset.faceInfo.pointSize > 0f)
					{
						float num16 = m_CurrentFontSize / m_CurrentSpriteAsset.faceInfo.pointSize * m_CurrentSpriteAsset.faceInfo.scale;
						num2 = spriteCharacter.scale * spriteCharacter.glyph.scale * num16;
						num14 = m_CurrentSpriteAsset.faceInfo.ascentLine;
						num15 = m_CurrentSpriteAsset.faceInfo.descentLine;
					}
					else
					{
						float num17 = m_CurrentFontSize / m_CurrentFontAsset.faceInfo.pointSize * m_CurrentFontAsset.faceInfo.scale;
						num2 = m_CurrentFontAsset.faceInfo.ascentLine / spriteCharacter.glyph.metrics.height * spriteCharacter.scale * spriteCharacter.glyph.scale * num17;
						float num18 = num17 / num2;
						num14 = m_CurrentFontAsset.faceInfo.ascentLine * num18;
						num15 = m_CurrentFontAsset.faceInfo.descentLine * num18;
					}
					m_CachedTextElement = spriteCharacter;
					m_InternalTextElementInfo[m_CharacterCount].elementType = TextElementType.Sprite;
					m_InternalTextElementInfo[m_CharacterCount].scale = num2;
					m_CurrentMaterialIndex = currentMaterialIndex;
				}
				else if (m_TextElementType == TextElementType.Character)
				{
					m_CachedTextElement = textInfo.textElementInfo[m_CharacterCount].textElement;
					if (m_CachedTextElement == null)
					{
						continue;
					}
					m_CurrentFontAsset = textInfo.textElementInfo[m_CharacterCount].fontAsset;
					m_CurrentMaterial = textInfo.textElementInfo[m_CharacterCount].material;
					m_CurrentMaterialIndex = textInfo.textElementInfo[m_CharacterCount].materialReferenceIndex;
					float num19 = ((!flag8 || m_TextProcessingArray[i].unicode != 10 || m_CharacterCount == m_FirstCharacterOfLine) ? (m_CurrentFontSize * num12 / m_CurrentFontAsset.m_FaceInfo.pointSize * m_CurrentFontAsset.m_FaceInfo.scale) : (textInfo.textElementInfo[m_CharacterCount - 1].pointSize * num12 / m_CurrentFontAsset.m_FaceInfo.pointSize * m_CurrentFontAsset.m_FaceInfo.scale));
					if (flag8 && num11 == 8230)
					{
						num14 = 0f;
						num15 = 0f;
					}
					else
					{
						num14 = m_CurrentFontAsset.m_FaceInfo.ascentLine;
						num15 = m_CurrentFontAsset.m_FaceInfo.descentLine;
					}
					num2 = num19 * m_FontScaleMultiplier * m_CachedTextElement.scale;
					m_InternalTextElementInfo[m_CharacterCount].elementType = TextElementType.Character;
				}
				float num20 = num2;
				if (num11 == 173 || num11 == 3)
				{
					num2 = 0f;
				}
				m_InternalTextElementInfo[m_CharacterCount].character = (ushort)num11;
				m_InternalTextElementInfo[m_CharacterCount].style = m_FontStyleInternal;
				if (m_FontWeightInternal == TextFontWeight.Bold)
				{
					m_InternalTextElementInfo[m_CharacterCount].style |= FontStyles.Bold;
				}
				GlyphMetrics glyphMetrics = textInfo.textElementInfo[m_CharacterCount].alternativeGlyph?.metrics ?? m_CachedTextElement.m_Glyph.metrics;
				bool flag9 = num11 <= 65535 && char.IsWhiteSpace((char)num11);
				GlyphValueRecord glyphValueRecord = default(GlyphValueRecord);
				float num21 = generationSettings.characterSpacing;
				if (flag && m_TextElementType == TextElementType.Character)
				{
					uint glyphIndex = m_CachedTextElement.m_GlyphIndex;
					GlyphPairAdjustmentRecord value;
					if (m_CharacterCount < totalCharacterCount - 1 && textInfo.textElementInfo[m_CharacterCount + 1].elementType == TextElementType.Character)
					{
						uint glyphIndex2 = textInfo.textElementInfo[m_CharacterCount + 1].textElement.m_GlyphIndex;
						uint key = (glyphIndex2 << 16) | glyphIndex;
						if (m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key, out value))
						{
							glyphValueRecord = value.firstAdjustmentRecord.glyphValueRecord;
							num21 = (((value.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num21);
						}
					}
					if (m_CharacterCount >= 1)
					{
						uint glyphIndex3 = textInfo.textElementInfo[m_CharacterCount - 1].textElement.m_GlyphIndex;
						uint key2 = (glyphIndex << 16) | glyphIndex3;
						if (textInfo.textElementInfo[m_CharacterCount - 1].elementType == TextElementType.Character && m_CurrentFontAsset.m_FontFeatureTable.m_GlyphPairAdjustmentRecordLookup.TryGetValue(key2, out value))
						{
							glyphValueRecord += value.secondAdjustmentRecord.glyphValueRecord;
							num21 = (((value.featureLookupFlags & FontFeatureLookupFlags.IgnoreSpacingAdjustments) == FontFeatureLookupFlags.IgnoreSpacingAdjustments) ? 0f : num21);
						}
					}
					m_InternalTextElementInfo[m_CharacterCount].adjustedHorizontalAdvance = glyphValueRecord.xAdvance;
				}
				bool flag10 = TextGeneratorUtilities.IsBaseGlyph(num11);
				if (flag10)
				{
					m_LastBaseGlyphIndex = m_CharacterCount;
				}
				if (m_CharacterCount > 0 && !flag10)
				{
					if (m_LastBaseGlyphIndex != int.MinValue && m_LastBaseGlyphIndex == m_CharacterCount - 1)
					{
						Glyph glyph = textInfo.textElementInfo[m_LastBaseGlyphIndex].textElement.glyph;
						uint index = glyph.index;
						uint glyphIndex4 = m_CachedTextElement.glyphIndex;
						uint key3 = (glyphIndex4 << 16) | index;
						if (m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key3, out var value2))
						{
							float num22 = (m_InternalTextElementInfo[m_LastBaseGlyphIndex].origin - m_XAdvance) / num2;
							glyphValueRecord.xPlacement = num22 + value2.baseGlyphAnchorPoint.xCoordinate - value2.markPositionAdjustment.xPositionAdjustment;
							glyphValueRecord.yPlacement = value2.baseGlyphAnchorPoint.yCoordinate - value2.markPositionAdjustment.yPositionAdjustment;
							num21 = 0f;
						}
					}
					else
					{
						bool flag11 = false;
						int num23 = m_CharacterCount - 1;
						while (num23 >= 0 && num23 != m_LastBaseGlyphIndex)
						{
							Glyph glyph2 = textInfo.textElementInfo[num23].textElement.glyph;
							uint index2 = glyph2.index;
							uint glyphIndex5 = m_CachedTextElement.glyphIndex;
							uint key4 = (glyphIndex5 << 16) | index2;
							if (m_CurrentFontAsset.fontFeatureTable.m_MarkToMarkAdjustmentRecordLookup.TryGetValue(key4, out var value3))
							{
								float num24 = (textInfo.textElementInfo[num23].origin - m_XAdvance) / num2;
								float num25 = num13 - m_LineOffset + m_BaselineOffset;
								float num26 = (m_InternalTextElementInfo[num23].baseLine - num25) / num2;
								glyphValueRecord.xPlacement = num24 + value3.baseMarkGlyphAnchorPoint.xCoordinate - value3.combiningMarkPositionAdjustment.xPositionAdjustment;
								glyphValueRecord.yPlacement = num26 + value3.baseMarkGlyphAnchorPoint.yCoordinate - value3.combiningMarkPositionAdjustment.yPositionAdjustment;
								num21 = 0f;
								flag11 = true;
								break;
							}
							num23--;
						}
						if (m_LastBaseGlyphIndex != int.MinValue && !flag11)
						{
							Glyph glyph3 = textInfo.textElementInfo[m_LastBaseGlyphIndex].textElement.glyph;
							uint index3 = glyph3.index;
							uint glyphIndex6 = m_CachedTextElement.glyphIndex;
							uint key5 = (glyphIndex6 << 16) | index3;
							if (m_CurrentFontAsset.fontFeatureTable.m_MarkToBaseAdjustmentRecordLookup.TryGetValue(key5, out var value4))
							{
								float num27 = (m_InternalTextElementInfo[m_LastBaseGlyphIndex].origin - m_XAdvance) / num2;
								glyphValueRecord.xPlacement = num27 + value4.baseGlyphAnchorPoint.xCoordinate - value4.markPositionAdjustment.xPositionAdjustment;
								glyphValueRecord.yPlacement = value4.baseGlyphAnchorPoint.yCoordinate - value4.markPositionAdjustment.yPositionAdjustment;
								num21 = 0f;
							}
						}
					}
				}
				num14 += glyphValueRecord.yPlacement;
				num15 += glyphValueRecord.yPlacement;
				float num28 = 0f;
				if (m_MonoSpacing != 0f && num11 != 8203)
				{
					num28 = (m_MonoSpacing / 2f - (m_CachedTextElement.glyph.metrics.width / 2f + m_CachedTextElement.glyph.metrics.horizontalBearingX) * num2) * (1f - m_CharWidthAdjDelta);
					m_XAdvance += num28;
				}
				float num29 = 0f;
				if (m_TextElementType == TextElementType.Character && !isUsingAlternateTypeface && (m_InternalTextElementInfo[m_CharacterCount].style & FontStyles.Bold) == FontStyles.Bold)
				{
					num29 = m_CurrentFontAsset.boldStyleSpacing;
				}
				m_InternalTextElementInfo[m_CharacterCount].origin = Round(m_XAdvance + glyphValueRecord.xPlacement * num2);
				m_InternalTextElementInfo[m_CharacterCount].baseLine = Round(num13 - m_LineOffset + m_BaselineOffset + glyphValueRecord.yPlacement * num2);
				float num30 = ((m_TextElementType == TextElementType.Character) ? (num14 * num2 / num12 + m_BaselineOffset) : (num14 * num2 + m_BaselineOffset));
				float num31 = ((m_TextElementType == TextElementType.Character) ? (num15 * num2 / num12 + m_BaselineOffset) : (num15 * num2 + m_BaselineOffset));
				float num32 = num30;
				float num33 = num31;
				bool flag12 = m_CharacterCount == m_FirstCharacterOfLine;
				if (flag12 || !flag9)
				{
					if (m_BaselineOffset != 0f)
					{
						num32 = Mathf.Max((num30 - m_BaselineOffset) / m_FontScaleMultiplier, num32);
						num33 = Mathf.Min((num31 - m_BaselineOffset) / m_FontScaleMultiplier, num33);
					}
					m_MaxLineAscender = Mathf.Max(num32, m_MaxLineAscender);
					m_MaxLineDescender = Mathf.Min(num33, m_MaxLineDescender);
				}
				if (flag12 || !flag9)
				{
					m_InternalTextElementInfo[m_CharacterCount].adjustedAscender = num32;
					m_InternalTextElementInfo[m_CharacterCount].adjustedDescender = num33;
					m_InternalTextElementInfo[m_CharacterCount].ascender = num30 - m_LineOffset;
					m_MaxDescender = (m_InternalTextElementInfo[m_CharacterCount].descender = num31 - m_LineOffset);
				}
				else
				{
					m_InternalTextElementInfo[m_CharacterCount].adjustedAscender = m_MaxLineAscender;
					m_InternalTextElementInfo[m_CharacterCount].adjustedDescender = m_MaxLineDescender;
					m_InternalTextElementInfo[m_CharacterCount].ascender = m_MaxLineAscender - m_LineOffset;
					m_MaxDescender = (m_InternalTextElementInfo[m_CharacterCount].descender = m_MaxLineDescender - m_LineOffset);
				}
				if (m_LineNumber == 0 && (flag12 || !flag9))
				{
					m_MaxAscender = m_MaxLineAscender;
					m_MaxCapHeight = Mathf.Max(m_MaxCapHeight, m_CurrentFontAsset.m_FaceInfo.capLine * num2 / num12);
				}
				if (m_LineOffset == 0f && (!flag9 || m_CharacterCount == m_FirstCharacterOfLine))
				{
					m_PageAscender = ((m_PageAscender > num30) ? m_PageAscender : num30);
				}
				if (num11 == 9 || num11 == 8203 || ((textWrappingMode == TextWrappingMode.PreserveWhitespace || textWrappingMode == TextWrappingMode.PreserveWhitespaceNoWrap) && (flag9 || num11 == 8203)) || (!flag9 && num11 != 8203 && num11 != 173 && num11 != 3) || (num11 == 173 && !flag7) || m_TextElementType == TextElementType.Sprite)
				{
					num6 = ((m_Width != -1f) ? Mathf.Min(x + 0.0001f - m_MarginLeft - m_MarginRight, m_Width) : (x + 0.0001f - m_MarginLeft - m_MarginRight));
					num9 = Round(Mathf.Abs(m_XAdvance) + glyphMetrics.horizontalAdvance * (1f - m_CharWidthAdjDelta) * ((num11 == 173) ? num20 : num2));
					if (flag10 && num9 > num6 && textWrappingMode != TextWrappingMode.NoWrap && textWrappingMode != TextWrappingMode.PreserveWhitespaceNoWrap && m_CharacterCount != m_FirstCharacterOfLine)
					{
						i = RestoreWordWrappingState(ref state, textInfo);
						if (m_InternalTextElementInfo[m_CharacterCount - 1].character == 173 && !flag7 && generationSettings.overflowMode == TextOverflowMode.Overflow)
						{
							characterSubstitution.index = m_CharacterCount - 1;
							characterSubstitution.unicode = 45u;
							i--;
							m_CharacterCount--;
							continue;
						}
						flag7 = false;
						if (m_InternalTextElementInfo[m_CharacterCount].character == 173)
						{
							flag7 = true;
							continue;
						}
						if (isTextAutoSizingEnabled && flag5)
						{
							if (m_CharWidthAdjDelta < 0f && m_AutoSizeIterationCount < m_AutoSizeMaxIterationCount)
							{
								float num34 = num9;
								if (m_CharWidthAdjDelta > 0f)
								{
									num34 /= 1f - m_CharWidthAdjDelta;
								}
								float num35 = num9 - (num6 - 0.0001f);
								m_CharWidthAdjDelta += num35 / num34;
								m_CharWidthAdjDelta = Mathf.Min(m_CharWidthAdjDelta, 0f);
								return Vector2.zero;
							}
							if (fontSize > 0f && m_AutoSizeIterationCount < m_AutoSizeMaxIterationCount)
							{
								m_MaxFontSize = fontSize;
								float num36 = Mathf.Max((fontSize - m_MinFontSize) / 2f, 0.05f);
								fontSize -= num36;
								fontSize = Mathf.Max((float)(int)(fontSize * 20f + 0.5f) / 20f, 0f);
							}
						}
						float num37 = m_MaxLineAscender - m_StartOfLineAscender;
						if (m_LineOffset > 0f && Math.Abs(num37) > 0.01f && !m_IsDrivenLineSpacing)
						{
							m_MaxDescender -= num37;
							m_LineOffset += num37;
						}
						float num38 = m_MaxLineAscender - m_LineOffset;
						float num39 = m_MaxLineDescender - m_LineOffset;
						m_MaxDescender = ((m_MaxDescender < num39) ? m_MaxDescender : num39);
						if (!flag4)
						{
							num10 = m_MaxDescender;
						}
						bool flag13 = false;
						m_FirstCharacterOfLine = m_CharacterCount;
						m_LineVisibleCharacterCount = 0;
						SaveWordWrappingState(ref state2, i, m_CharacterCount - 1, textInfo);
						m_LineNumber++;
						float adjustedAscender = m_InternalTextElementInfo[m_CharacterCount].adjustedAscender;
						if (m_LineHeight == -32767f)
						{
							m_LineOffset += 0f - m_MaxLineDescender + adjustedAscender + (num5 + m_LineSpacingDelta) * num + 0f * num3;
							m_IsDrivenLineSpacing = false;
						}
						else
						{
							m_LineOffset += m_LineHeight + 0f * num3;
							m_IsDrivenLineSpacing = true;
						}
						m_MaxLineAscender = -32767f;
						m_MaxLineDescender = 32767f;
						m_StartOfLineAscender = adjustedAscender;
						m_XAdvance = 0f + m_TagIndent;
						flag5 = true;
						continue;
					}
					num7 = Mathf.Max(num7, num9 + m_MarginLeft + m_MarginRight);
					num8 = Mathf.Max(num8, m_MaxAscender - m_MaxDescender);
				}
				if (m_LineOffset > 0f && !TextGeneratorUtilities.Approximately(m_MaxLineAscender, m_StartOfLineAscender) && !m_IsDrivenLineSpacing)
				{
					float num40 = m_MaxLineAscender - m_StartOfLineAscender;
					m_MaxDescender -= num40;
					m_LineOffset += num40;
					m_StartOfLineAscender += num40;
					state.lineOffset = m_LineOffset;
					state.startOfLineAscender = m_StartOfLineAscender;
				}
				switch (num11)
				{
				case 9u:
				{
					float num42 = m_CurrentFontAsset.faceInfo.tabWidth * (float)(int)m_CurrentFontAsset.tabMultiple * num2;
					float num43 = Mathf.Ceil(m_XAdvance / num42) * num42;
					m_XAdvance = ((num43 > m_XAdvance) ? num43 : (m_XAdvance + num42));
					break;
				}
				default:
					if (m_MonoSpacing != 0f)
					{
						float num41 = ((!m_DuoSpace || (num11 != 46 && num11 != 58 && num11 != 44)) ? (m_MonoSpacing - num28) : (m_MonoSpacing / 2f - num28));
						m_XAdvance += (num41 + (m_CurrentFontAsset.regularStyleSpacing + num21) * num3 + m_CSpacing) * (1f - m_CharWidthAdjDelta);
						if (flag9 || num11 == 8203)
						{
							m_XAdvance += generationSettings.wordSpacing * num3;
						}
					}
					else
					{
						m_XAdvance += ((glyphMetrics.horizontalAdvance * m_FXScale.x + glyphValueRecord.xAdvance) * num2 + (m_CurrentFontAsset.regularStyleSpacing + num21 + num29) * num3 + m_CSpacing) * (1f - m_CharWidthAdjDelta);
						if (flag9 || num11 == 8203)
						{
							m_XAdvance += generationSettings.wordSpacing * num3;
						}
					}
					break;
				case 8203u:
					break;
				}
				if (num11 == 13)
				{
					m_XAdvance = 0f + m_TagIndent;
				}
				if (num11 == 10 || num11 == 11 || num11 == 3 || num11 == 8232 || num11 == 8233 || m_CharacterCount == totalCharacterCount - 1)
				{
					float num44 = m_MaxLineAscender - m_StartOfLineAscender;
					if (m_LineOffset > 0f && Math.Abs(num44) > 0.01f && !m_IsDrivenLineSpacing)
					{
						m_MaxDescender -= num44;
						m_LineOffset += num44;
					}
					float num45 = m_MaxLineDescender - m_LineOffset;
					m_MaxDescender = ((m_MaxDescender < num45) ? m_MaxDescender : num45);
					if (num11 == 10 || num11 == 11 || num11 == 45 || num11 == 8232 || num11 == 8233)
					{
						SaveWordWrappingState(ref state2, i, m_CharacterCount, textInfo);
						SaveWordWrappingState(ref state, i, m_CharacterCount, textInfo);
						m_LineNumber++;
						m_FirstCharacterOfLine = m_CharacterCount + 1;
						float adjustedAscender2 = m_InternalTextElementInfo[m_CharacterCount].adjustedAscender;
						if (m_LineHeight == -32767f)
						{
							float num46 = 0f - m_MaxLineDescender + adjustedAscender2 + (num5 + m_LineSpacingDelta) * num + (0f + ((num11 == 10 || num11 == 8233) ? generationSettings.paragraphSpacing : 0f)) * num3;
							m_LineOffset += num46;
							m_IsDrivenLineSpacing = false;
						}
						else
						{
							m_LineOffset += m_LineHeight + (0f + ((num11 == 10 || num11 == 8233) ? generationSettings.paragraphSpacing : 0f)) * num3;
							m_IsDrivenLineSpacing = true;
						}
						m_MaxLineAscender = -32767f;
						m_MaxLineDescender = 32767f;
						m_StartOfLineAscender = adjustedAscender2;
						m_XAdvance = 0f + m_TagLineIndent + m_TagIndent;
						m_CharacterCount++;
						continue;
					}
					if (num11 == 3)
					{
						i = m_TextProcessingArray.Length;
					}
				}
				if ((textWrappingMode != TextWrappingMode.NoWrap && textWrappingMode != TextWrappingMode.PreserveWhitespaceNoWrap) || generationSettings.overflowMode == TextOverflowMode.Truncate || generationSettings.overflowMode == TextOverflowMode.Ellipsis)
				{
					bool flag14 = false;
					bool flag15 = false;
					if ((flag9 || num11 == 8203 || num11 == 45 || num11 == 173) && (!m_IsNonBreakingSpace || flag6) && num11 != 160 && num11 != 8199 && num11 != 8209 && num11 != 8239 && num11 != 8288)
					{
						if (num11 != 45 || m_CharacterCount <= 0 || !char.IsWhiteSpace((char)textInfo.textElementInfo[m_CharacterCount - 1].character))
						{
							flag5 = false;
							flag14 = true;
							state3.previousWordBreak = -1;
						}
					}
					else if (!m_IsNonBreakingSpace && ((TextGeneratorUtilities.IsHangul(num11) && !textSettings.lineBreakingRules.useModernHangulLineBreakingRules) || TextGeneratorUtilities.IsCJK(num11)))
					{
						bool flag16 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(num11);
						bool flag17 = m_CharacterCount < totalCharacterCount - 1 && textSettings.lineBreakingRules.leadingCharactersLookup.Contains(m_InternalTextElementInfo[m_CharacterCount + 1].character);
						if (!flag16)
						{
							if (!flag17)
							{
								flag5 = false;
								flag14 = true;
							}
							if (flag5)
							{
								if (flag9)
								{
									flag15 = true;
								}
								flag14 = true;
							}
						}
						else if (flag5 && flag12)
						{
							if (flag9)
							{
								flag15 = true;
							}
							flag14 = true;
						}
					}
					else if (!m_IsNonBreakingSpace && m_CharacterCount + 1 < totalCharacterCount && TextGeneratorUtilities.IsCJK(textInfo.textElementInfo[m_CharacterCount + 1].character))
					{
						uint character = textInfo.textElementInfo[m_CharacterCount + 1].character;
						bool flag18 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(num11);
						bool flag19 = textSettings.lineBreakingRules.leadingCharactersLookup.Contains(character);
						if (!flag18 && !flag19)
						{
							flag14 = true;
						}
					}
					else if (flag5)
					{
						if ((flag9 && num11 != 160) || (num11 == 173 && !flag7))
						{
							flag15 = true;
						}
						flag14 = true;
					}
					if (flag14)
					{
						SaveWordWrappingState(ref state, i, m_CharacterCount, textInfo);
					}
					if (flag15)
					{
						SaveWordWrappingState(ref state3, i, m_CharacterCount, textInfo);
					}
				}
				m_CharacterCount++;
			}
			num4 = m_MaxFontSize - m_MinFontSize;
			if (isTextAutoSizingEnabled && num4 > 0.051f && fontSize < 0f && m_AutoSizeIterationCount < m_AutoSizeMaxIterationCount)
			{
				if (m_CharWidthAdjDelta < 0f)
				{
					m_CharWidthAdjDelta = 0f;
				}
				m_MinFontSize = fontSize;
				float num47 = Mathf.Max((m_MaxFontSize - fontSize) / 2f, 0.05f);
				fontSize += num47;
				fontSize = Mathf.Min((float)(int)(fontSize * 20f + 0.5f) / 20f, 0f);
				return Vector2.zero;
			}
			m_IsCalculatingPreferredValues = false;
			if (NeedToRound)
			{
				Debug.AssertFormat(num7 == Mathf.Round(num7), "renderedWidth was not rounded: {0}", num7);
			}
			else
			{
				if (num7 != 0f)
				{
					num7 = (float)(int)(num7 * 100f + 1f) / 100f;
				}
				if (num8 != 0f)
				{
					num8 = (float)(int)(num8 * 100f + 1f) / 100f;
				}
			}
			return new Vector2(num7, num8);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal void Prepare(TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			m_Padding = generationSettings.extraPadding;
			m_CurrentFontAsset = generationSettings.fontAsset;
			m_ShouldRenderBitmap = generationSettings.fontAsset.IsBitmap();
			m_FontStyleInternal = generationSettings.fontStyle;
			m_FontWeightInternal = (((m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			GetSpecialCharacters(generationSettings);
			ComputeMarginSize(generationSettings.screenRect, Vector4.zero);
			PopulateTextBackingArray(generationSettings.renderedText);
			PopulateTextProcessingArray(generationSettings);
			SetArraySizes(m_TextProcessingArray, generationSettings, textInfo);
			bool flag = false;
			m_FontSize = generationSettings.fontSize;
			m_MaxFontSize = 0f;
			m_MinFontSize = 0f;
			m_LineSpacingDelta = 0f;
			m_CharWidthAdjDelta = 0f;
		}

		internal bool PrepareFontAsset(TextGenerationSettings generationSettings)
		{
			m_CurrentFontAsset = generationSettings.fontAsset;
			m_FontStyleInternal = generationSettings.fontStyle;
			m_FontWeightInternal = (((m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			if (!GetSpecialCharacters(generationSettings))
			{
				return false;
			}
			PopulateTextBackingArray(generationSettings.renderedText);
			PopulateTextProcessingArray(generationSettings);
			return PopulateFontAsset(generationSettings, m_TextProcessingArray);
		}

		private int SetArraySizes(TextProcessingElement[] textProcessingArray, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			TextSettings textSettings = generationSettings.textSettings;
			int num = 0;
			m_TotalCharacterCount = 0;
			m_isTextLayoutPhase = false;
			m_TagNoParsing = false;
			m_FontStyleInternal = generationSettings.fontStyle;
			m_FontStyleStack.Clear();
			m_FontWeightInternal = (((m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			m_FontWeightStack.SetDefault(m_FontWeightInternal);
			m_CurrentFontAsset = generationSettings.fontAsset;
			m_CurrentMaterial = generationSettings.fontAsset.material;
			m_CurrentMaterialIndex = 0;
			m_MaterialReferenceStack.SetDefault(new MaterialReference(m_CurrentMaterialIndex, m_CurrentFontAsset, null, m_CurrentMaterial, m_Padding));
			m_MaterialReferenceIndexLookup.Clear();
			MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
			m_CurrentSpriteAsset = null;
			if (textInfo == null)
			{
				textInfo = new TextInfo();
			}
			else if (textInfo.textElementInfo.Length < m_InternalTextProcessingArraySize)
			{
				TextInfo.Resize(ref textInfo.textElementInfo, m_InternalTextProcessingArraySize, isBlockAllocated: false);
			}
			m_TextElementType = TextElementType.Character;
			if (generationSettings.overflowMode == TextOverflowMode.Ellipsis)
			{
				GetEllipsisSpecialCharacter(generationSettings);
				if (m_Ellipsis.character != null)
				{
					if (m_Ellipsis.fontAsset.GetHashCode() != m_CurrentFontAsset.GetHashCode())
					{
						if (textSettings.matchMaterialPreset && m_CurrentMaterial.GetHashCode() != m_Ellipsis.fontAsset.material.GetHashCode())
						{
							m_Ellipsis.material = MaterialManager.GetFallbackMaterial(m_CurrentMaterial, m_Ellipsis.fontAsset.material);
						}
						else
						{
							m_Ellipsis.material = m_Ellipsis.fontAsset.material;
						}
						m_Ellipsis.materialIndex = MaterialReference.AddMaterialReference(m_Ellipsis.material, m_Ellipsis.fontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
						m_MaterialReferences[m_Ellipsis.materialIndex].referenceCount = 0;
					}
				}
				else
				{
					generationSettings.overflowMode = TextOverflowMode.Truncate;
					if (textSettings.displayWarnings)
					{
						Debug.LogWarning("The character used for Ellipsis is not available in font asset [" + m_CurrentFontAsset.name + "] or any potential fallbacks. Switching Text Overflow mode to Truncate.");
					}
				}
			}
			bool flag = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.liga);
			for (int i = 0; i < textProcessingArray.Length && textProcessingArray[i].unicode != 0; i++)
			{
				if (textInfo.textElementInfo == null || m_TotalCharacterCount >= textInfo.textElementInfo.Length)
				{
					TextInfo.Resize(ref textInfo.textElementInfo, m_TotalCharacterCount + 1, isBlockAllocated: true);
				}
				uint num2 = textProcessingArray[i].unicode;
				int currentMaterialIndex = m_CurrentMaterialIndex;
				if (generationSettings.richText && num2 == 60)
				{
					currentMaterialIndex = m_CurrentMaterialIndex;
					if (ValidateHtmlTag(textProcessingArray, i + 1, out var endIndex, generationSettings, textInfo, out var _))
					{
						int stringIndex = textProcessingArray[i].stringIndex;
						i = endIndex;
						if (m_TextElementType == TextElementType.Sprite)
						{
							m_MaterialReferences[m_CurrentMaterialIndex].referenceCount++;
							textInfo.textElementInfo[m_TotalCharacterCount].character = (ushort)(57344 + m_SpriteIndex);
							textInfo.textElementInfo[m_TotalCharacterCount].fontAsset = m_CurrentFontAsset;
							textInfo.textElementInfo[m_TotalCharacterCount].materialReferenceIndex = m_CurrentMaterialIndex;
							textInfo.textElementInfo[m_TotalCharacterCount].textElement = m_CurrentSpriteAsset.spriteCharacterTable[m_SpriteIndex];
							textInfo.textElementInfo[m_TotalCharacterCount].elementType = m_TextElementType;
							textInfo.textElementInfo[m_TotalCharacterCount].index = stringIndex;
							textInfo.textElementInfo[m_TotalCharacterCount].stringLength = textProcessingArray[i].stringIndex - stringIndex + 1;
							m_TextElementType = TextElementType.Character;
							m_CurrentMaterialIndex = currentMaterialIndex;
							num++;
							m_TotalCharacterCount++;
						}
						continue;
					}
				}
				bool isAlternativeTypeface = false;
				bool flag2 = false;
				FontAsset currentFontAsset = m_CurrentFontAsset;
				Material currentMaterial = m_CurrentMaterial;
				currentMaterialIndex = m_CurrentMaterialIndex;
				if (m_TextElementType == TextElementType.Character)
				{
					if ((m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase)
					{
						if (char.IsLower((char)num2))
						{
							num2 = char.ToUpper((char)num2);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase)
					{
						if (char.IsUpper((char)num2))
						{
							num2 = char.ToLower((char)num2);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps && char.IsLower((char)num2))
					{
						num2 = char.ToUpper((char)num2);
					}
				}
				TextElement textElement = null;
				uint num3 = ((i + 1 < textProcessingArray.Length) ? textProcessingArray[i + 1].unicode : 0u);
				if (generationSettings.emojiFallbackSupport && ((TextGeneratorUtilities.IsEmojiPresentationForm(num2) && num3 != 65038) || (TextGeneratorUtilities.IsEmoji(num2) && num3 == 65039)) && textSettings.emojiFallbackTextAssets != null && textSettings.emojiFallbackTextAssets.Count > 0)
				{
					textElement = FontAssetUtilities.GetTextElementFromTextAssets(num2, m_CurrentFontAsset, textSettings.emojiFallbackTextAssets, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
					if (textElement == null)
					{
					}
				}
				if (textElement == null)
				{
					textElement = GetTextElement(generationSettings, num2, m_CurrentFontAsset, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
				}
				if (textElement == null)
				{
					DoMissingGlyphCallback(num2, textProcessingArray[i].stringIndex, m_CurrentFontAsset, textInfo);
					uint num4 = num2;
					num2 = (textProcessingArray[i].unicode = ((textSettings.missingCharacterUnicode == 0) ? 9633u : ((uint)textSettings.missingCharacterUnicode)));
					textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, m_CurrentFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
					if (textElement == null)
					{
						textElement = FontAssetUtilities.GetCharacterFromFontAssetsInternal(num2, m_CurrentFontAsset, textSettings.GetFallbackFontAssets(m_CurrentFontAsset.IsRaster(), m_ShouldRenderBitmap ? generationSettings.fontSize : (-1)), textSettings.fallbackOSFontAssets, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
					}
					if (textElement == null && textSettings.defaultFontAsset != null)
					{
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, textSettings.defaultFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
					}
					if (textElement == null)
					{
						num2 = (textProcessingArray[i].unicode = 32u);
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, m_CurrentFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
					}
					if (textElement == null)
					{
						num2 = (textProcessingArray[i].unicode = 3u);
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, m_CurrentFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag);
					}
					if (textSettings.displayWarnings)
					{
						bool flag3 = !JobsUtility.IsExecutingJob;
						string message = ((num4 > 65535) ? $"The character with Unicode value \\U{num4:X8} was not found in the [{(flag3 ? generationSettings.fontAsset.name : ((object)generationSettings.fontAsset.GetHashCode()))}] font asset or any potential fallbacks. It was replaced by Unicode character \\u{textElement.unicode:X4}." : $"The character with Unicode value \\u{num4:X4} was not found in the [{(flag3 ? generationSettings.fontAsset.name : ((object)generationSettings.fontAsset.GetHashCode()))}] font asset or any potential fallbacks. It was replaced by Unicode character \\u{textElement.unicode:X4}.");
						Debug.LogWarning(message);
					}
				}
				textInfo.textElementInfo[m_TotalCharacterCount].alternativeGlyph = null;
				if (textElement.elementType == TextElementType.Character)
				{
					if (textElement.textAsset.instanceID != m_CurrentFontAsset.instanceID)
					{
						flag2 = true;
						m_CurrentFontAsset = textElement.textAsset as FontAsset;
					}
					if ((num3 >= 65024 && num3 <= 65039) || (num3 >= 917760 && num3 <= 917999))
					{
						if (!m_CurrentFontAsset.TryGetGlyphVariantIndexInternal(num2, num3, out var variantGlyphIndex))
						{
							variantGlyphIndex = m_CurrentFontAsset.GetGlyphVariantIndex(num2, num3);
							m_CurrentFontAsset.TryAddGlyphVariantIndexInternal(num2, num3, variantGlyphIndex);
						}
						if (variantGlyphIndex != 0 && m_CurrentFontAsset.TryAddGlyphInternal(variantGlyphIndex, out var glyph))
						{
							textInfo.textElementInfo[m_TotalCharacterCount].alternativeGlyph = glyph;
						}
						textProcessingArray[i + 1].unicode = 26u;
						i++;
					}
					if (flag && m_CurrentFontAsset.fontFeatureTable.m_LigatureSubstitutionRecordLookup.TryGetValue(textElement.glyphIndex, out var value))
					{
						if (value == null)
						{
							break;
						}
						for (int j = 0; j < value.Count; j++)
						{
							LigatureSubstitutionRecord ligatureSubstitutionRecord = value[j];
							int num5 = ligatureSubstitutionRecord.componentGlyphIDs.Length;
							uint num6 = ligatureSubstitutionRecord.ligatureGlyphID;
							for (int k = 1; k < num5; k++)
							{
								uint unicode = textProcessingArray[i + k].unicode;
								bool success;
								uint glyphIndex = m_CurrentFontAsset.GetGlyphIndex(unicode, out success);
								if (glyphIndex != ligatureSubstitutionRecord.componentGlyphIDs[k])
								{
									num6 = 0u;
									break;
								}
							}
							if (num6 == 0 || !m_CurrentFontAsset.TryAddGlyphInternal(num6, out var glyph2))
							{
								continue;
							}
							textInfo.textElementInfo[m_TotalCharacterCount].alternativeGlyph = glyph2;
							for (int l = 0; l < num5; l++)
							{
								if (l == 0)
								{
									textProcessingArray[i + l].length = num5;
								}
								else
								{
									textProcessingArray[i + l].unicode = 26u;
								}
							}
							i += num5 - 1;
							break;
						}
					}
				}
				textInfo.textElementInfo[m_TotalCharacterCount].elementType = TextElementType.Character;
				textInfo.textElementInfo[m_TotalCharacterCount].textElement = textElement;
				textInfo.textElementInfo[m_TotalCharacterCount].isUsingAlternateTypeface = isAlternativeTypeface;
				textInfo.textElementInfo[m_TotalCharacterCount].character = (ushort)num2;
				textInfo.textElementInfo[m_TotalCharacterCount].index = textProcessingArray[i].stringIndex;
				textInfo.textElementInfo[m_TotalCharacterCount].stringLength = textProcessingArray[i].length;
				textInfo.textElementInfo[m_TotalCharacterCount].fontAsset = m_CurrentFontAsset;
				if (textElement.elementType == TextElementType.Sprite)
				{
					SpriteAsset spriteAsset = textElement.textAsset as SpriteAsset;
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(spriteAsset.material, spriteAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_MaterialReferences[m_CurrentMaterialIndex].referenceCount++;
					textInfo.textElementInfo[m_TotalCharacterCount].elementType = TextElementType.Sprite;
					textInfo.textElementInfo[m_TotalCharacterCount].materialReferenceIndex = m_CurrentMaterialIndex;
					m_TextElementType = TextElementType.Character;
					m_CurrentMaterialIndex = currentMaterialIndex;
					num++;
					m_TotalCharacterCount++;
					continue;
				}
				if (flag2 && m_CurrentFontAsset.instanceID != generationSettings.fontAsset.instanceID)
				{
					if (textSettings.matchMaterialPreset)
					{
						m_CurrentMaterial = MaterialManager.GetFallbackMaterial(m_CurrentMaterial, m_CurrentFontAsset.material);
					}
					else
					{
						m_CurrentMaterial = m_CurrentFontAsset.material;
					}
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
				}
				if (textElement != null && textElement.glyph.atlasIndex > 0)
				{
					m_CurrentMaterial = MaterialManager.GetFallbackMaterial(m_CurrentFontAsset, m_CurrentMaterial, textElement.glyph.atlasIndex);
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					flag2 = true;
				}
				if (!char.IsWhiteSpace((char)num2) && num2 != 8203)
				{
					if (generationSettings.isIMGUI && m_MaterialReferences[m_CurrentMaterialIndex].referenceCount >= 16383)
					{
						m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(new Material(m_CurrentMaterial), m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					}
					m_MaterialReferences[m_CurrentMaterialIndex].referenceCount++;
				}
				textInfo.textElementInfo[m_TotalCharacterCount].material = m_CurrentMaterial;
				textInfo.textElementInfo[m_TotalCharacterCount].materialReferenceIndex = m_CurrentMaterialIndex;
				m_MaterialReferences[m_CurrentMaterialIndex].isFallbackMaterial = flag2;
				if (flag2)
				{
					m_MaterialReferences[m_CurrentMaterialIndex].fallbackMaterial = currentMaterial;
					m_CurrentFontAsset = currentFontAsset;
					m_CurrentMaterial = currentMaterial;
					m_CurrentMaterialIndex = currentMaterialIndex;
				}
				m_TotalCharacterCount++;
			}
			if (m_IsCalculatingPreferredValues)
			{
				m_IsCalculatingPreferredValues = false;
				return m_TotalCharacterCount;
			}
			textInfo.spriteCount = num;
			int num7 = (textInfo.materialCount = m_MaterialReferenceIndexLookup.Count);
			if (num7 > textInfo.meshInfo.Length)
			{
				TextInfo.Resize(ref textInfo.meshInfo, num7, isBlockAllocated: false);
			}
			if (m_VertexBufferAutoSizeReduction && textInfo.textElementInfo.Length - m_TotalCharacterCount > 256)
			{
				TextInfo.Resize(ref textInfo.textElementInfo, Mathf.Max(m_TotalCharacterCount + 1, 256), isBlockAllocated: true);
			}
			for (int m = 0; m < num7; m++)
			{
				int referenceCount = m_MaterialReferences[m].referenceCount;
				if (textInfo.meshInfo[m].vertexData == null || textInfo.meshInfo[m].vertexBufferSize < referenceCount * 4)
				{
					if (textInfo.meshInfo[m].vertexData == null)
					{
						textInfo.meshInfo[m] = new MeshInfo(referenceCount + 1, generationSettings.isIMGUI);
					}
					else
					{
						textInfo.meshInfo[m].ResizeMeshInfo((referenceCount > 1024) ? (referenceCount + 256) : Mathf.NextPowerOfTwo(referenceCount), generationSettings.isIMGUI);
					}
				}
				else if (textInfo.meshInfo[m].vertexBufferSize - referenceCount * 4 > 1024)
				{
					textInfo.meshInfo[m].ResizeMeshInfo((referenceCount > 1024) ? (referenceCount + 256) : Mathf.Max(Mathf.NextPowerOfTwo(referenceCount), 256), generationSettings.isIMGUI);
				}
				textInfo.meshInfo[m].material = m_MaterialReferences[m].material;
				textInfo.meshInfo[m].glyphRenderMode = m_MaterialReferences[m].fontAsset.atlasRenderMode;
			}
			return m_TotalCharacterCount;
		}

		private TextElement GetTextElement(TextGenerationSettings generationSettings, uint unicode, FontAsset fontAsset, FontStyles fontStyle, TextFontWeight fontWeight, out bool isUsingAlternativeTypeface, bool populateLigatures)
		{
			bool flag = !IsExecutingJob;
			TextSettings textSettings = generationSettings.textSettings;
			Character character = FontAssetUtilities.GetCharacterFromFontAsset(unicode, fontAsset, includeFallbacks: false, fontStyle, fontWeight, out isUsingAlternativeTypeface, populateLigatures);
			if (character != null)
			{
				return character;
			}
			if (!flag && (fontAsset.atlasPopulationMode == AtlasPopulationMode.Dynamic || fontAsset.atlasPopulationMode == AtlasPopulationMode.DynamicOS))
			{
				return null;
			}
			if (fontAsset.m_FallbackFontAssetTable != null && fontAsset.m_FallbackFontAssetTable.Count > 0)
			{
				character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(unicode, fontAsset, fontAsset.m_FallbackFontAssetTable, null, includeFallbacks: true, fontStyle, fontWeight, out isUsingAlternativeTypeface, populateLigatures);
			}
			if (character != null)
			{
				if (isUsingAlternativeTypeface)
				{
					fontAsset.AddCharacterToLookupCache(unicode, character, fontStyle, fontWeight);
				}
				else
				{
					fontAsset.AddCharacterToLookupCache(unicode, character, FontStyles.Normal, TextFontWeight.Regular);
				}
				return character;
			}
			if (!(flag ? (fontAsset.instanceID == generationSettings.fontAsset.instanceID) : (fontAsset == generationSettings.fontAsset)))
			{
				character = FontAssetUtilities.GetCharacterFromFontAsset(unicode, generationSettings.fontAsset, includeFallbacks: false, fontStyle, fontWeight, out isUsingAlternativeTypeface, populateLigatures);
				if (character != null)
				{
					m_CurrentMaterialIndex = 0;
					m_CurrentMaterial = m_MaterialReferences[0].material;
					fontAsset.AddCharacterToLookupCache(unicode, character, fontStyle, fontWeight);
					return character;
				}
				if (generationSettings.fontAsset.m_FallbackFontAssetTable != null && generationSettings.fontAsset.m_FallbackFontAssetTable.Count > 0)
				{
					character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(unicode, fontAsset, generationSettings.fontAsset.m_FallbackFontAssetTable, null, includeFallbacks: true, fontStyle, fontWeight, out isUsingAlternativeTypeface, populateLigatures);
				}
				if (character != null)
				{
					if (isUsingAlternativeTypeface)
					{
						fontAsset.AddCharacterToLookupCache(unicode, character, fontStyle, fontWeight);
					}
					else
					{
						fontAsset.AddCharacterToLookupCache(unicode, character, FontStyles.Normal, TextFontWeight.Regular);
					}
					return character;
				}
			}
			if (textSettings.GetStaticFallbackOSFontAsset() == null && !flag)
			{
				return null;
			}
			character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(unicode, fontAsset, textSettings.GetFallbackFontAssets(fontAsset.IsRaster(), m_ShouldRenderBitmap ? generationSettings.fontSize : (-1)), textSettings.fallbackOSFontAssets, includeFallbacks: true, fontStyle, fontWeight, out isUsingAlternativeTypeface, populateLigatures);
			if (character != null)
			{
				if (isUsingAlternativeTypeface)
				{
					fontAsset.AddCharacterToLookupCache(unicode, character, fontStyle, fontWeight);
				}
				else
				{
					fontAsset.AddCharacterToLookupCache(unicode, character, FontStyles.Normal, TextFontWeight.Regular);
				}
				return character;
			}
			if (textSettings.defaultFontAsset != null)
			{
				character = FontAssetUtilities.GetCharacterFromFontAsset(unicode, textSettings.defaultFontAsset, includeFallbacks: true, fontStyle, fontWeight, out isUsingAlternativeTypeface, populateLigatures);
			}
			if (character != null)
			{
				if (isUsingAlternativeTypeface)
				{
					fontAsset.AddCharacterToLookupCache(unicode, character, fontStyle, fontWeight);
				}
				else
				{
					fontAsset.AddCharacterToLookupCache(unicode, character, FontStyles.Normal, TextFontWeight.Regular);
				}
				return character;
			}
			if (textSettings.defaultSpriteAsset != null)
			{
				if (!flag && textSettings.defaultSpriteAsset.m_SpriteCharacterLookup == null)
				{
					return null;
				}
				SpriteCharacter spriteCharacterFromSpriteAsset = FontAssetUtilities.GetSpriteCharacterFromSpriteAsset(unicode, textSettings.defaultSpriteAsset, includeFallbacks: true);
				if (spriteCharacterFromSpriteAsset != null)
				{
					return spriteCharacterFromSpriteAsset;
				}
			}
			return null;
		}

		private void PopulateTextBackingArray(in RenderedText sourceText)
		{
			int num = 0;
			int characterCount = sourceText.CharacterCount;
			if (characterCount >= m_TextBackingArray.Capacity)
			{
				m_TextBackingArray.Resize(characterCount);
			}
			RenderedText.Enumerator enumerator = sourceText.GetEnumerator();
			while (enumerator.MoveNext())
			{
				char current = enumerator.Current;
				m_TextBackingArray[num] = current;
				num++;
			}
			m_TextBackingArray[num] = 0u;
			m_TextBackingArray.Count = num;
		}

		private void PopulateTextProcessingArray(TextGenerationSettings generationSettings)
		{
			int count = m_TextBackingArray.Count;
			if (m_TextProcessingArray.Length < count)
			{
				TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray, count);
			}
			TextProcessingStack<int>.SetDefault(m_TextStyleStacks, 0);
			m_TextStyleStackDepth = 0;
			int writeIndex = 0;
			int hashCode = m_TextStyleStacks[0].Pop();
			TextStyle style = TextGeneratorUtilities.GetStyle(generationSettings, hashCode);
			if (style != null && style.hashCode != -1183493901)
			{
				TextGeneratorUtilities.InsertOpeningStyleTag(style, ref m_TextProcessingArray, ref writeIndex, ref m_TextStyleStackDepth, ref m_TextStyleStacks, ref generationSettings);
			}
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				uint num = m_TextBackingArray[i];
				if (num == 0)
				{
					break;
				}
				if (num == 92 && i < count - 1)
				{
					switch (m_TextBackingArray[i + 1])
					{
					case 92u:
						if (generationSettings.parseControlCharacters)
						{
							i++;
						}
						break;
					case 110u:
						if (!generationSettings.parseControlCharacters)
						{
							break;
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 1,
							unicode = 10u
						};
						i++;
						writeIndex++;
						continue;
					case 114u:
						if (!generationSettings.parseControlCharacters)
						{
							break;
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 1,
							unicode = 13u
						};
						i++;
						writeIndex++;
						continue;
					case 116u:
						if (!generationSettings.parseControlCharacters)
						{
							break;
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 1,
							unicode = 9u
						};
						i++;
						writeIndex++;
						continue;
					case 118u:
						if (!generationSettings.parseControlCharacters)
						{
							break;
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 1,
							unicode = 11u
						};
						i++;
						writeIndex++;
						continue;
					case 117u:
						if (!generationSettings.parseControlCharacters || count <= i + 5 || !TextGeneratorUtilities.IsValidUTF16(m_TextBackingArray, i + 2))
						{
							break;
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 6,
							unicode = TextGeneratorUtilities.GetUTF16(m_TextBackingArray, i + 2)
						};
						i += 5;
						writeIndex++;
						continue;
					case 85u:
						if (!generationSettings.parseControlCharacters || count <= i + 9 || !TextGeneratorUtilities.IsValidUTF32(m_TextBackingArray, i + 2))
						{
							break;
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 10,
							unicode = TextGeneratorUtilities.GetUTF32(m_TextBackingArray, i + 2)
						};
						i += 9;
						writeIndex++;
						continue;
					}
				}
				if (num >= 55296 && num <= 56319 && count > i + 1 && m_TextBackingArray[i + 1] >= 56320 && m_TextBackingArray[i + 1] <= 57343)
				{
					m_TextProcessingArray[writeIndex] = new TextProcessingElement
					{
						elementType = TextProcessingElementType.TextCharacterElement,
						stringIndex = i,
						length = 2,
						unicode = TextGeneratorUtilities.ConvertToUTF32(num, m_TextBackingArray[i + 1])
					};
					i++;
					writeIndex++;
					continue;
				}
				if (num == 13 && i + 1 < count && m_TextBackingArray[i + 1] == 10)
				{
					m_TextProcessingArray[writeIndex] = new TextProcessingElement
					{
						elementType = TextProcessingElementType.TextCharacterElement,
						stringIndex = i,
						length = 2,
						unicode = 10u
					};
					i++;
					writeIndex++;
					continue;
				}
				if (num == 60 && generationSettings.richText)
				{
					switch ((MarkupTag)TextGeneratorUtilities.GetMarkupTagHashCode(m_TextBackingArray, i + 1))
					{
					case MarkupTag.NO_PARSE:
						flag = true;
						break;
					case MarkupTag.SLASH_NO_PARSE:
						flag = false;
						break;
					case MarkupTag.BR:
						if (flag)
						{
							break;
						}
						if (writeIndex == m_TextProcessingArray.Length)
						{
							TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 4,
							unicode = 10u
						};
						writeIndex++;
						i += 3;
						continue;
					case MarkupTag.CR:
						if (flag)
						{
							break;
						}
						if (writeIndex == m_TextProcessingArray.Length)
						{
							TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 4,
							unicode = 13u
						};
						writeIndex++;
						i += 3;
						continue;
					case MarkupTag.NBSP:
						if (flag)
						{
							break;
						}
						if (writeIndex == m_TextProcessingArray.Length)
						{
							TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 6,
							unicode = 160u
						};
						writeIndex++;
						i += 5;
						continue;
					case MarkupTag.ZWSP:
						if (flag)
						{
							break;
						}
						if (writeIndex == m_TextProcessingArray.Length)
						{
							TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 6,
							unicode = 8203u
						};
						writeIndex++;
						i += 5;
						continue;
					case MarkupTag.ZWJ:
						if (flag)
						{
							break;
						}
						if (writeIndex == m_TextProcessingArray.Length)
						{
							TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 5,
							unicode = 8205u
						};
						writeIndex++;
						i += 4;
						continue;
					case MarkupTag.SHY:
						if (flag)
						{
							break;
						}
						if (writeIndex == m_TextProcessingArray.Length)
						{
							TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
						}
						m_TextProcessingArray[writeIndex] = new TextProcessingElement
						{
							elementType = TextProcessingElementType.TextCharacterElement,
							stringIndex = i,
							length = 5,
							unicode = 173u
						};
						writeIndex++;
						i += 4;
						continue;
					case MarkupTag.A:
						if (m_TextBackingArray.Count > i + 4 && m_TextBackingArray[i + 3] == 104 && m_TextBackingArray[i + 4] == 114)
						{
							TextGeneratorUtilities.InsertOpeningTextStyle(TextGeneratorUtilities.GetStyle(generationSettings, 65), ref m_TextProcessingArray, ref writeIndex, ref m_TextStyleStackDepth, ref m_TextStyleStacks, ref generationSettings);
						}
						break;
					case MarkupTag.STYLE:
					{
						if (flag)
						{
							break;
						}
						int k = writeIndex;
						if (!TextGeneratorUtilities.ReplaceOpeningStyleTag(ref m_TextBackingArray, i, out var srcOffset, ref m_TextProcessingArray, ref writeIndex, ref m_TextStyleStackDepth, ref m_TextStyleStacks, ref generationSettings))
						{
							break;
						}
						for (; k < writeIndex; k++)
						{
							m_TextProcessingArray[k].stringIndex = i;
							m_TextProcessingArray[k].length = srcOffset - i + 1;
						}
						i = srcOffset;
						continue;
					}
					case MarkupTag.SLASH_A:
						TextGeneratorUtilities.InsertClosingTextStyle(TextGeneratorUtilities.GetStyle(generationSettings, 65), ref m_TextProcessingArray, ref writeIndex, ref m_TextStyleStackDepth, ref m_TextStyleStacks, ref generationSettings);
						break;
					case MarkupTag.SLASH_STYLE:
					{
						if (flag)
						{
							break;
						}
						int j = writeIndex;
						TextGeneratorUtilities.ReplaceClosingStyleTag(ref m_TextProcessingArray, ref writeIndex, ref m_TextStyleStackDepth, ref m_TextStyleStacks, ref generationSettings);
						for (; j < writeIndex; j++)
						{
							m_TextProcessingArray[j].stringIndex = i;
							m_TextProcessingArray[j].length = 8;
						}
						i += 7;
						continue;
					}
					}
				}
				if (writeIndex == m_TextProcessingArray.Length)
				{
					TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
				}
				m_TextProcessingArray[writeIndex] = new TextProcessingElement
				{
					elementType = TextProcessingElementType.TextCharacterElement,
					stringIndex = i,
					length = 1,
					unicode = num
				};
				writeIndex++;
			}
			m_TextStyleStackDepth = 0;
			if (style != null && style.hashCode != -1183493901)
			{
				TextGeneratorUtilities.InsertClosingStyleTag(ref m_TextProcessingArray, ref writeIndex, ref m_TextStyleStackDepth, ref m_TextStyleStacks, ref generationSettings);
			}
			if (writeIndex == m_TextProcessingArray.Length)
			{
				TextGeneratorUtilities.ResizeInternalArray(ref m_TextProcessingArray);
			}
			m_TextProcessingArray[writeIndex].unicode = 0u;
			m_InternalTextProcessingArraySize = writeIndex;
		}

		private bool PopulateFontAsset(TextGenerationSettings generationSettings, TextProcessingElement[] textProcessingArray)
		{
			bool flag = !IsExecutingJob;
			TextSettings textSettings = generationSettings.textSettings;
			int num = 0;
			m_TotalCharacterCount = 0;
			m_isTextLayoutPhase = false;
			m_TagNoParsing = false;
			m_FontStyleInternal = generationSettings.fontStyle;
			m_FontStyleStack.Clear();
			m_FontWeightInternal = (((m_FontStyleInternal & FontStyles.Bold) == FontStyles.Bold) ? TextFontWeight.Bold : generationSettings.fontWeight);
			m_FontWeightStack.SetDefault(m_FontWeightInternal);
			m_CurrentFontAsset = generationSettings.fontAsset;
			m_CurrentMaterial = generationSettings.fontAsset.material;
			m_CurrentMaterialIndex = 0;
			m_MaterialReferenceStack.SetDefault(new MaterialReference(m_CurrentMaterialIndex, m_CurrentFontAsset, null, m_CurrentMaterial, m_Padding));
			m_MaterialReferenceIndexLookup.Clear();
			MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
			m_TextElementType = TextElementType.Character;
			if (generationSettings.overflowMode == TextOverflowMode.Ellipsis)
			{
				GetEllipsisSpecialCharacter(generationSettings);
				if (m_Ellipsis.character != null && m_Ellipsis.fontAsset.GetHashCode() != m_CurrentFontAsset.GetHashCode())
				{
					if (textSettings.matchMaterialPreset && m_CurrentMaterial.GetHashCode() != m_Ellipsis.fontAsset.material.GetHashCode())
					{
						if (!flag)
						{
							return false;
						}
						m_Ellipsis.material = MaterialManager.GetFallbackMaterial(m_CurrentMaterial, m_Ellipsis.fontAsset.material);
					}
					else
					{
						m_Ellipsis.material = m_Ellipsis.fontAsset.material;
					}
					m_Ellipsis.materialIndex = MaterialReference.AddMaterialReference(m_Ellipsis.material, m_Ellipsis.fontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_MaterialReferences[m_Ellipsis.materialIndex].referenceCount = 0;
				}
			}
			bool flag2 = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.liga);
			for (int i = 0; i < textProcessingArray.Length && textProcessingArray[i].unicode != 0; i++)
			{
				uint num2 = textProcessingArray[i].unicode;
				int currentMaterialIndex = m_CurrentMaterialIndex;
				if (generationSettings.richText && num2 == 60)
				{
					currentMaterialIndex = m_CurrentMaterialIndex;
					if (ValidateHtmlTag(textProcessingArray, i + 1, out var endIndex, generationSettings, null, out var isThreadSuccess))
					{
						int stringIndex = textProcessingArray[i].stringIndex;
						i = endIndex;
						if (m_TextElementType == TextElementType.Sprite)
						{
							m_TextElementType = TextElementType.Character;
							m_CurrentMaterialIndex = currentMaterialIndex;
							num++;
							m_TotalCharacterCount++;
						}
						continue;
					}
					if (!isThreadSuccess)
					{
						return false;
					}
				}
				bool flag3 = false;
				FontAsset currentFontAsset = m_CurrentFontAsset;
				Material currentMaterial = m_CurrentMaterial;
				currentMaterialIndex = m_CurrentMaterialIndex;
				if (m_TextElementType == TextElementType.Character)
				{
					if ((m_FontStyleInternal & FontStyles.UpperCase) == FontStyles.UpperCase)
					{
						if (char.IsLower((char)num2))
						{
							num2 = char.ToUpper((char)num2);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.LowerCase) == FontStyles.LowerCase)
					{
						if (char.IsUpper((char)num2))
						{
							num2 = char.ToLower((char)num2);
						}
					}
					else if ((m_FontStyleInternal & FontStyles.SmallCaps) == FontStyles.SmallCaps && char.IsLower((char)num2))
					{
						num2 = char.ToUpper((char)num2);
					}
				}
				if (!flag && m_CurrentFontAsset.m_CharacterLookupDictionary == null)
				{
					return false;
				}
				TextElement textElement = null;
				uint num3 = ((i + 1 < textProcessingArray.Length) ? textProcessingArray[i + 1].unicode : 0u);
				bool isAlternativeTypeface;
				if (generationSettings.emojiFallbackSupport && ((TextGeneratorUtilities.IsEmojiPresentationForm(num2) && num3 != 65038) || (TextGeneratorUtilities.IsEmoji(num2) && num3 == 65039)) && textSettings.emojiFallbackTextAssets != null && textSettings.emojiFallbackTextAssets.Count > 0)
				{
					textElement = FontAssetUtilities.GetTextElementFromTextAssets(num2, m_CurrentFontAsset, textSettings.emojiFallbackTextAssets, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
					if (textElement == null)
					{
					}
				}
				if (textElement == null)
				{
					textElement = GetTextElement(generationSettings, num2, m_CurrentFontAsset, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
				}
				if (textElement == null)
				{
					if (!flag)
					{
						return false;
					}
					uint num4 = num2;
					num2 = (textProcessingArray[i].unicode = ((textSettings.missingCharacterUnicode == 0) ? 9633u : ((uint)textSettings.missingCharacterUnicode)));
					textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, m_CurrentFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
					if (textElement == null)
					{
						if (textSettings.GetFallbackFontAssets(m_CurrentFontAsset.IsRaster(), m_ShouldRenderBitmap ? generationSettings.fontSize : (-1)) == null && !flag)
						{
							return false;
						}
						textElement = FontAssetUtilities.GetCharacterFromFontAssetsInternal(num2, m_CurrentFontAsset, textSettings.GetFallbackFontAssets(m_CurrentFontAsset.IsRaster(), m_ShouldRenderBitmap ? generationSettings.fontSize : (-1)), textSettings.fallbackOSFontAssets, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
					}
					if (textElement == null && textSettings.defaultFontAsset != null)
					{
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, textSettings.defaultFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
					}
					if (textElement == null)
					{
						num2 = (textProcessingArray[i].unicode = 32u);
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, m_CurrentFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
					}
					if (textElement == null)
					{
						num2 = (textProcessingArray[i].unicode = 3u);
						textElement = FontAssetUtilities.GetCharacterFromFontAsset(num2, m_CurrentFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, flag2);
					}
					if (textSettings.displayWarnings)
					{
						string message = ((num4 > 65535) ? $"The character with Unicode value \\U{num4:X8} was not found in the [{generationSettings.fontAsset.name}] font asset or any potential fallbacks. It was replaced by Unicode character \\u{textElement.unicode:X4}." : $"The character with Unicode value \\u{num4:X4} was not found in the [{generationSettings.fontAsset.name}] font asset or any potential fallbacks. It was replaced by Unicode character \\u{textElement.unicode:X4}.");
						Debug.LogWarning(message);
					}
				}
				if (textElement.elementType == TextElementType.Character)
				{
					if (!(flag ? (textElement.textAsset.instanceID == m_CurrentFontAsset.instanceID) : (textElement.textAsset == m_CurrentFontAsset)))
					{
						flag3 = true;
						m_CurrentFontAsset = textElement.textAsset as FontAsset;
					}
					if ((num3 >= 65024 && num3 <= 65039) || (num3 >= 917760 && num3 <= 917999))
					{
						if (!m_CurrentFontAsset.TryGetGlyphVariantIndexInternal(num2, num3, out var variantGlyphIndex))
						{
							if (!flag)
							{
								return false;
							}
							variantGlyphIndex = m_CurrentFontAsset.GetGlyphVariantIndex(num2, num3);
							m_CurrentFontAsset.TryAddGlyphVariantIndexInternal(num2, num3, variantGlyphIndex);
						}
						if (variantGlyphIndex != 0)
						{
							m_CurrentFontAsset.TryAddGlyphInternal(variantGlyphIndex, out var _);
						}
						textProcessingArray[i + 1].unicode = 26u;
						i++;
					}
					if (flag2 && m_CurrentFontAsset.fontFeatureTable.m_LigatureSubstitutionRecordLookup.TryGetValue(textElement.glyphIndex, out var value))
					{
						if (value == null)
						{
							break;
						}
						for (int j = 0; j < value.Count; j++)
						{
							LigatureSubstitutionRecord ligatureSubstitutionRecord = value[j];
							int num5 = ligatureSubstitutionRecord.componentGlyphIDs.Length;
							uint num6 = ligatureSubstitutionRecord.ligatureGlyphID;
							for (int k = 1; k < num5; k++)
							{
								uint unicode = textProcessingArray[i + k].unicode;
								bool success;
								uint glyphIndex = m_CurrentFontAsset.GetGlyphIndex(unicode, out success);
								if (!success)
								{
									return false;
								}
								if (glyphIndex != ligatureSubstitutionRecord.componentGlyphIDs[k])
								{
									num6 = 0u;
									break;
								}
							}
							if (num6 == 0)
							{
								continue;
							}
							if (!flag)
							{
								return false;
							}
							if (!m_CurrentFontAsset.TryAddGlyphInternal(num6, out var _))
							{
								continue;
							}
							for (int l = 0; l < num5; l++)
							{
								if (l == 0)
								{
									textProcessingArray[i + l].length = num5;
								}
								else
								{
									textProcessingArray[i + l].unicode = 26u;
								}
							}
							i += num5 - 1;
							break;
						}
					}
				}
				if (textElement.elementType == TextElementType.Sprite)
				{
					SpriteAsset spriteAsset = textElement.textAsset as SpriteAsset;
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(spriteAsset.material, spriteAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_TextElementType = TextElementType.Character;
					m_CurrentMaterialIndex = currentMaterialIndex;
					num++;
					m_TotalCharacterCount++;
					continue;
				}
				if (flag3 && m_CurrentFontAsset.instanceID != generationSettings.fontAsset.instanceID)
				{
					if (flag)
					{
						if (textSettings.matchMaterialPreset)
						{
							m_CurrentMaterial = MaterialManager.GetFallbackMaterial(m_CurrentMaterial, m_CurrentFontAsset.material);
						}
						else
						{
							m_CurrentMaterial = m_CurrentFontAsset.material;
						}
					}
					else
					{
						if (textSettings.matchMaterialPreset)
						{
							return false;
						}
						m_CurrentMaterial = m_CurrentFontAsset.material;
					}
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
				}
				if (textElement != null && textElement.glyph.atlasIndex > 0)
				{
					if (!flag)
					{
						return false;
					}
					m_CurrentMaterial = MaterialManager.GetFallbackMaterial(m_CurrentFontAsset, m_CurrentMaterial, textElement.glyph.atlasIndex);
					m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(m_CurrentMaterial, m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					flag3 = true;
				}
				if (!char.IsWhiteSpace((char)num2) && num2 != 8203)
				{
					if (generationSettings.isIMGUI && m_MaterialReferences[m_CurrentMaterialIndex].referenceCount >= 16383)
					{
						m_CurrentMaterialIndex = MaterialReference.AddMaterialReference(new Material(m_CurrentMaterial), m_CurrentFontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					}
					m_MaterialReferences[m_CurrentMaterialIndex].referenceCount++;
				}
				m_MaterialReferences[m_CurrentMaterialIndex].isFallbackMaterial = flag3;
				if (flag3)
				{
					m_MaterialReferences[m_CurrentMaterialIndex].fallbackMaterial = currentMaterial;
					m_CurrentFontAsset = currentFontAsset;
					m_CurrentMaterial = currentMaterial;
					m_CurrentMaterialIndex = currentMaterialIndex;
				}
				m_TotalCharacterCount++;
			}
			return true;
		}

		private void ComputeMarginSize(Rect rect, Vector4 margins)
		{
			m_MarginWidth = rect.width - margins.x - margins.z;
			m_MarginHeight = rect.height - margins.y - margins.w;
			m_RectTransformCorners[0].x = 0f;
			m_RectTransformCorners[0].y = 0f;
			m_RectTransformCorners[1].x = 0f;
			m_RectTransformCorners[1].y = rect.height;
			m_RectTransformCorners[2].x = rect.width;
			m_RectTransformCorners[2].y = rect.height;
			m_RectTransformCorners[3].x = rect.width;
			m_RectTransformCorners[3].y = 0f;
		}

		protected bool GetSpecialCharacters(TextGenerationSettings generationSettings)
		{
			if (!GetEllipsisSpecialCharacter(generationSettings))
			{
				return false;
			}
			if (!GetUnderlineSpecialCharacter(generationSettings) || m_Underline.character == null)
			{
				return false;
			}
			return true;
		}

		protected bool GetEllipsisSpecialCharacter(TextGenerationSettings generationSettings)
		{
			bool flag = !IsExecutingJob;
			FontAsset fontAsset = m_CurrentFontAsset ?? generationSettings.fontAsset;
			TextSettings textSettings = generationSettings.textSettings;
			bool populateLigatures = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.liga);
			bool isAlternativeTypeface;
			Character character = FontAssetUtilities.GetCharacterFromFontAsset(8230u, fontAsset, includeFallbacks: false, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			if (character == null && fontAsset.m_FallbackFontAssetTable != null && fontAsset.m_FallbackFontAssetTable.Count > 0)
			{
				character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(8230u, fontAsset, fontAsset.m_FallbackFontAssetTable, null, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			}
			if (character == null)
			{
				if (textSettings.GetStaticFallbackOSFontAsset() == null && !flag)
				{
					return false;
				}
				character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(8230u, fontAsset, textSettings.GetFallbackFontAssets(fontAsset.IsRaster(), m_ShouldRenderBitmap ? generationSettings.fontSize : (-1)), textSettings.fallbackOSFontAssets, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			}
			if (character == null && textSettings.defaultFontAsset != null)
			{
				character = FontAssetUtilities.GetCharacterFromFontAsset(8230u, textSettings.defaultFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			}
			if (character != null)
			{
				m_Ellipsis = new SpecialCharacter(character, 0);
			}
			return true;
		}

		protected bool GetUnderlineSpecialCharacter(TextGenerationSettings generationSettings)
		{
			bool flag = !IsExecutingJob;
			FontAsset fontAsset = m_CurrentFontAsset ?? generationSettings.fontAsset;
			TextSettings textSettings = generationSettings.textSettings;
			bool populateLigatures = TextGenerationSettings.fontFeatures.Contains(OTL_FeatureTag.liga);
			bool isAlternativeTypeface;
			Character character = FontAssetUtilities.GetCharacterFromFontAsset(95u, fontAsset, includeFallbacks: false, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			if (character == null && fontAsset.m_FallbackFontAssetTable != null && fontAsset.m_FallbackFontAssetTable.Count > 0)
			{
				character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(95u, fontAsset, fontAsset.m_FallbackFontAssetTable, null, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			}
			if (character == null)
			{
				if (textSettings.GetStaticFallbackOSFontAsset() == null && !flag)
				{
					return false;
				}
				character = FontAssetUtilities.GetCharacterFromFontAssetsInternal(95u, fontAsset, textSettings.GetFallbackFontAssets(fontAsset.IsRaster(), m_ShouldRenderBitmap ? generationSettings.fontSize : (-1)), textSettings.fallbackOSFontAssets, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			}
			if (character == null && textSettings.defaultFontAsset != null)
			{
				character = FontAssetUtilities.GetCharacterFromFontAsset(95u, textSettings.defaultFontAsset, includeFallbacks: true, m_FontStyleInternal, m_FontWeightInternal, out isAlternativeTypeface, populateLigatures);
			}
			if (character != null)
			{
				m_Underline = new SpecialCharacter(character, m_CurrentMaterialIndex);
				if (m_Underline.fontAsset.GetHashCode() != m_CurrentFontAsset.GetHashCode())
				{
					m_Underline.material = ((generationSettings.textSettings.matchMaterialPreset && m_CurrentMaterial.GetHashCode() != m_Underline.fontAsset.material.GetHashCode()) ? MaterialManager.GetFallbackMaterial(m_CurrentMaterial, m_Underline.fontAsset.material) : m_Underline.fontAsset.material);
					m_Underline.materialIndex = MaterialReference.AddMaterialReference(m_Underline.material, m_Underline.fontAsset, ref m_MaterialReferences, m_MaterialReferenceIndexLookup);
					m_MaterialReferences[m_Underline.materialIndex].referenceCount = 0;
				}
			}
			return true;
		}

		protected void DoMissingGlyphCallback(uint unicode, int stringIndex, FontAsset fontAsset, TextInfo textInfo)
		{
			TextGenerator.OnMissingCharacter?.Invoke(unicode, stringIndex, textInfo, fontAsset);
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal class TextGenerationSettings : IEquatable<TextGenerationSettings>
	{
		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static Func<bool> IsEditorTextRenderingModeBitmap;

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static Func<bool> IsEditorTextRenderingModeRaster;

		private RenderedText m_RenderedText;

		private string m_CachedRenderedText;

		public Rect screenRect;

		public FontAsset fontAsset;

		public FontStyles fontStyle = FontStyles.Normal;

		public TextSettings textSettings;

		public TextAlignment textAlignment = TextAlignment.TopLeft;

		public TextOverflowMode overflowMode = TextOverflowMode.Overflow;

		public const float wordWrappingRatio = 0.4f;

		public Color color = Color.white;

		public bool shouldConvertToLinearSpace = true;

		public int fontSize = 18;

		public const bool autoSize = false;

		public const float fontSizeMin = 0f;

		public const float fontSizeMax = 0f;

		internal static readonly List<OTL_FeatureTag> fontFeatures = new List<OTL_FeatureTag> { OTL_FeatureTag.kern };

		public bool emojiFallbackSupport = true;

		public bool richText;

		public bool isRightToLeft;

		public float extraPadding = 6f;

		public bool parseControlCharacters = true;

		public bool isPlaceholder = false;

		public const bool tagNoParsing = false;

		public float characterSpacing;

		public float wordSpacing;

		public const float lineSpacing = 0f;

		public float paragraphSpacing;

		public const float lineSpacingMax = 0f;

		public TextWrappingMode textWrappingMode = TextWrappingMode.Normal;

		public const int maxVisibleCharacters = 99999;

		public const int maxVisibleWords = 99999;

		public const int maxVisibleLines = 99999;

		public const int firstVisibleCharacter = 0;

		public const bool useMaxVisibleDescender = false;

		public TextFontWeight fontWeight = TextFontWeight.Regular;

		public bool isIMGUI;

		public const float charWidthMaxAdj = 0f;

		public float pixelsPerPoint = 1f;

		public RenderedText renderedText
		{
			get
			{
				return m_RenderedText;
			}
			set
			{
				m_RenderedText = value;
				m_CachedRenderedText = null;
			}
		}

		public string text
		{
			get
			{
				return m_CachedRenderedText ?? (m_CachedRenderedText = renderedText.CreateString());
			}
			set
			{
				renderedText = new RenderedText(value);
			}
		}

		public TextGenerationSettings()
		{
		}

		internal TextGenerationSettings(TextGenerationSettings tgs)
		{
			m_RenderedText = tgs.m_RenderedText;
			m_CachedRenderedText = tgs.m_CachedRenderedText;
			screenRect = tgs.screenRect;
			fontAsset = tgs.fontAsset;
			fontStyle = tgs.fontStyle;
			textSettings = tgs.textSettings;
			textAlignment = tgs.textAlignment;
			overflowMode = tgs.overflowMode;
			shouldConvertToLinearSpace = tgs.shouldConvertToLinearSpace;
			fontSize = tgs.fontSize;
			emojiFallbackSupport = tgs.emojiFallbackSupport;
			richText = tgs.richText;
			isRightToLeft = tgs.isRightToLeft;
			extraPadding = tgs.extraPadding;
			parseControlCharacters = tgs.parseControlCharacters;
			isPlaceholder = tgs.isPlaceholder;
			characterSpacing = tgs.characterSpacing;
			wordSpacing = tgs.wordSpacing;
			paragraphSpacing = tgs.paragraphSpacing;
			textWrappingMode = tgs.textWrappingMode;
			fontWeight = tgs.fontWeight;
			isIMGUI = tgs.isIMGUI;
		}

		public bool Equals(TextGenerationSettings other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			return m_RenderedText.Equals(other.m_RenderedText) && screenRect.Equals(other.screenRect) && object.Equals(fontAsset, other.fontAsset) && fontStyle == other.fontStyle && object.Equals(textSettings, other.textSettings) && textAlignment == other.textAlignment && overflowMode == other.overflowMode && color.Equals(other.color) && fontSize.Equals(other.fontSize) && shouldConvertToLinearSpace == other.shouldConvertToLinearSpace && emojiFallbackSupport == other.emojiFallbackSupport && richText == other.richText && isRightToLeft == other.isRightToLeft && extraPadding == other.extraPadding && parseControlCharacters == other.parseControlCharacters && isPlaceholder == other.isPlaceholder && characterSpacing.Equals(other.characterSpacing) && wordSpacing.Equals(other.wordSpacing) && paragraphSpacing.Equals(other.paragraphSpacing) && textWrappingMode == other.textWrappingMode && fontWeight == other.fontWeight && isIMGUI == other.isIMGUI;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((TextGenerationSettings)obj);
		}

		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add(m_RenderedText);
			hashCode.Add(screenRect);
			hashCode.Add(fontAsset);
			hashCode.Add((int)fontStyle);
			hashCode.Add(textSettings);
			hashCode.Add((int)textAlignment);
			hashCode.Add((int)overflowMode);
			hashCode.Add(color);
			hashCode.Add(shouldConvertToLinearSpace);
			hashCode.Add(fontSize);
			hashCode.Add(emojiFallbackSupport);
			hashCode.Add(richText);
			hashCode.Add(isRightToLeft);
			hashCode.Add(extraPadding);
			hashCode.Add(parseControlCharacters);
			hashCode.Add(isPlaceholder);
			hashCode.Add(characterSpacing);
			hashCode.Add(wordSpacing);
			hashCode.Add(paragraphSpacing);
			hashCode.Add((int)textWrappingMode);
			hashCode.Add((int)fontWeight);
			hashCode.Add(isIMGUI);
			return hashCode.ToHashCode();
		}

		public static bool operator ==(TextGenerationSettings left, TextGenerationSettings right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(TextGenerationSettings left, TextGenerationSettings right)
		{
			return !object.Equals(left, right);
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}\n {2}: {3}\n {4}: {5}\n ", "text", text, "screenRect", screenRect, "fontAsset", fontAsset) + string.Format("{0}: {1}\n {2}: {3}\n {4}: {5}\n {6}: {7}\n {8}: {9}\n ", "fontStyle", fontStyle, "textSettings", textSettings, "textAlignment", textAlignment, "overflowMode", overflowMode, "textWrappingMode", textWrappingMode) + string.Format("{0}: {1}\n {2}: {3}\n {4}: {5}\n {6}: {7}\n {8}: {9}\n ", "color", color, "fontSize", fontSize, "richText", richText, "isRightToLeft", isRightToLeft, "extraPadding", extraPadding) + string.Format("{0}: {1}\n {2}: {3}\n {4}: {5}\n {6}: {7}\n ", "parseControlCharacters", parseControlCharacters, "characterSpacing", characterSpacing, "wordSpacing", wordSpacing, "paragraphSpacing", paragraphSpacing) + string.Format("{0}: {1}\n {2}: {3}\n {4}: {5}\n {6}: {7}", "textWrappingMode", textWrappingMode, "fontWeight", fontWeight, "shouldConvertToLinearSpace", shouldConvertToLinearSpace, "isPlaceholder", isPlaceholder);
		}
	}
	[Flags]
	internal enum HorizontalAlignment
	{
		Left = 1,
		Center = 2,
		Right = 4,
		Justified = 8,
		Flush = 0x10,
		Geometry = 0x20
	}
	[Flags]
	internal enum VerticalAlignment
	{
		Top = 0x100,
		Middle = 0x200,
		Bottom = 0x400,
		Baseline = 0x800,
		Midline = 0x1000,
		Capline = 0x2000
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal enum TextAlignment
	{
		TopLeft = 257,
		TopCenter = 258,
		TopRight = 260,
		TopJustified = 264,
		TopFlush = 272,
		TopGeoAligned = 288,
		MiddleLeft = 513,
		MiddleCenter = 514,
		MiddleRight = 516,
		MiddleJustified = 520,
		MiddleFlush = 528,
		MiddleGeoAligned = 544,
		BottomLeft = 1025,
		BottomCenter = 1026,
		BottomRight = 1028,
		BottomJustified = 1032,
		BottomFlush = 1040,
		BottomGeoAligned = 1056,
		BaselineLeft = 2049,
		BaselineCenter = 2050,
		BaselineRight = 2052,
		BaselineJustified = 2056,
		BaselineFlush = 2064,
		BaselineGeoAligned = 2080,
		MidlineLeft = 4097,
		MidlineCenter = 4098,
		MidlineRight = 4100,
		MidlineJustified = 4104,
		MidlineFlush = 4112,
		MidlineGeoAligned = 4128,
		CaplineLeft = 8193,
		CaplineCenter = 8194,
		CaplineRight = 8196,
		CaplineJustified = 8200,
		CaplineFlush = 8208,
		CaplineGeoAligned = 8224
	}
	[Flags]
	public enum FontStyles
	{
		Normal = 0,
		Bold = 1,
		Italic = 2,
		Underline = 4,
		LowerCase = 8,
		UpperCase = 0x10,
		SmallCaps = 0x20,
		Strikethrough = 0x40,
		Superscript = 0x80,
		Subscript = 0x100,
		Highlight = 0x200
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal enum TextOverflowMode
	{
		Overflow = 0,
		Ellipsis = 1,
		Masking = 2,
		Truncate = 3,
		ScrollRect = 4,
		Linked = 6
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal enum TextWrappingMode
	{
		NoWrap,
		Normal,
		PreserveWhitespace,
		PreserveWhitespaceNoWrap
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule", "UnityEditor.GraphToolsFoundationModule" })]
	internal readonly struct RenderedText : IEquatable<RenderedText>, IEquatable<string>
	{
		public struct Enumerator
		{
			private readonly RenderedText m_Source;

			private const int k_ValueStage = 0;

			private const int k_RepeatStage = 1;

			private const int k_SuffixStage = 2;

			private int m_Stage;

			private int m_StageIndex;

			private char m_Current;

			public char Current => m_Current;

			public Enumerator(in RenderedText source)
			{
				m_Source = source;
				m_Stage = 0;
				m_StageIndex = 0;
				m_Current = '\0';
			}

			public bool MoveNext()
			{
				if (m_Stage == 0)
				{
					if (m_Source.value != null)
					{
						int valueStart = m_Source.valueStart;
						int num = m_Source.valueStart + m_Source.valueLength;
						if (m_StageIndex < valueStart)
						{
							m_StageIndex = valueStart;
						}
						if (m_StageIndex < num)
						{
							m_Current = m_Source.value[m_StageIndex];
							m_StageIndex++;
							return true;
						}
					}
					m_Stage = 1;
					m_StageIndex = 0;
				}
				if (m_Stage == 1)
				{
					if (m_StageIndex < m_Source.repeatCount)
					{
						m_Current = m_Source.repeat;
						m_StageIndex++;
						return true;
					}
					m_Stage = 2;
					m_StageIndex = 0;
				}
				if (m_Stage == 2)
				{
					if (m_Source.suffix != null && m_StageIndex < m_Source.suffix.Length)
					{
						m_Current = m_Source.suffix[m_StageIndex];
						m_StageIndex++;
						return true;
					}
					m_Stage = 3;
					m_StageIndex = 0;
				}
				return false;
			}

			public void Reset()
			{
				m_Stage = 0;
				m_StageIndex = 0;
				m_Current = '\0';
			}
		}

		public readonly string value;

		public readonly int valueStart;

		public readonly int valueLength;

		public readonly string suffix;

		public readonly char repeat;

		public readonly int repeatCount;

		public int CharacterCount
		{
			get
			{
				int num = valueLength + repeatCount;
				if (suffix != null)
				{
					num += suffix.Length;
				}
				return num;
			}
		}

		public RenderedText(string value)
			: this(value, 0, value?.Length ?? 0)
		{
		}

		public RenderedText(string value, string suffix)
			: this(value, 0, value?.Length ?? 0, suffix)
		{
		}

		public RenderedText(string value, int start, int length, string suffix = null)
		{
			if (string.IsNullOrEmpty(value))
			{
				start = 0;
				length = 0;
			}
			else
			{
				if (start < 0)
				{
					start = 0;
				}
				else if (start >= value.Length)
				{
					start = value.Length;
					length = 0;
				}
				if (length < 0)
				{
					length = 0;
				}
				else if (length > value.Length - start)
				{
					length = value.Length - start;
				}
			}
			this.value = value;
			valueStart = start;
			valueLength = length;
			this.suffix = suffix;
			repeat = '\0';
			repeatCount = 0;
		}

		public RenderedText(char repeat, int repeatCount, string suffix = null)
		{
			if (repeatCount < 0)
			{
				repeatCount = 0;
			}
			value = null;
			valueStart = 0;
			valueLength = 0;
			this.suffix = suffix;
			this.repeat = repeat;
			this.repeatCount = repeatCount;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		public string CreateString()
		{
			char[] array = new char[CharacterCount];
			int num = 0;
			Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				char current = enumerator.Current;
				array[num++] = current;
			}
			return new string(array);
		}

		public bool Equals(RenderedText other)
		{
			return value == other.value && valueStart == other.valueStart && valueLength == other.valueLength && suffix == other.suffix && repeat == other.repeat && repeatCount == other.repeatCount;
		}

		public bool Equals(string other)
		{
			int num = other?.Length ?? 0;
			int characterCount = CharacterCount;
			if (num != characterCount)
			{
				return false;
			}
			if (num == 0)
			{
				return true;
			}
			int num2 = 0;
			Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				char current = enumerator.Current;
				if (current != other[num2++])
				{
					return false;
				}
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			return (obj is string other && Equals(other)) || (obj is RenderedText other2 && Equals(other2));
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(value, valueStart, valueLength, suffix, repeat, repeatCount);
		}
	}
	[Serializable]
	internal struct MeshExtents(Vector2 min, Vector2 max)
	{
		public Vector2 min = min;

		public Vector2 max = max;

		public override string ToString()
		{
			return "Min (" + min.x.ToString("f2") + ", " + min.y.ToString("f2") + ")   Max (" + max.x.ToString("f2") + ", " + max.y.ToString("f2") + ")";
		}
	}
	internal struct XmlTagAttribute
	{
		public int nameHashCode;

		public TagValueType valueType;

		public int valueStartIndex;

		public int valueLength;

		public int valueHashCode;
	}
	internal struct RichTextTagAttribute
	{
		public int nameHashCode;

		public int valueHashCode;

		public TagValueType valueType;

		public int valueStartIndex;

		public int valueLength;

		public TagUnitType unitType;
	}
	[DebuggerDisplay("Unicode ({unicode})  '{(char)unicode}'")]
	internal struct TextProcessingElement
	{
		public TextProcessingElementType elementType;

		public uint unicode;

		public int stringIndex;

		public int length;
	}
	internal struct TextBackingContainer
	{
		private uint[] m_Array;

		private int m_Count;

		public uint[] Text => m_Array;

		public int Capacity => m_Array.Length;

		public int Count
		{
			get
			{
				return m_Count;
			}
			set
			{
				m_Count = value;
			}
		}

		public uint this[int index]
		{
			get
			{
				return m_Array[index];
			}
			set
			{
				if (index >= m_Array.Length)
				{
					Resize(index);
				}
				m_Array[index] = value;
			}
		}

		public TextBackingContainer(int size)
		{
			m_Array = new uint[size];
			m_Count = 0;
		}

		public void Resize(int size)
		{
			size = Mathf.NextPowerOfTwo(size + 1);
			Array.Resize(ref m_Array, size);
		}
	}
	internal struct CharacterSubstitution(int index, uint unicode)
	{
		public int index = index;

		public uint unicode = unicode;
	}
	internal struct Offset
	{
		private float m_Left;

		private float m_Right;

		private float m_Top;

		private float m_Bottom;

		private static readonly Offset k_ZeroOffset = new Offset(0f, 0f, 0f, 0f);

		public float left
		{
			get
			{
				return m_Left;
			}
			set
			{
				m_Left = value;
			}
		}

		public float right
		{
			get
			{
				return m_Right;
			}
			set
			{
				m_Right = value;
			}
		}

		public float top
		{
			get
			{
				return m_Top;
			}
			set
			{
				m_Top = value;
			}
		}

		public float bottom
		{
			get
			{
				return m_Bottom;
			}
			set
			{
				m_Bottom = value;
			}
		}

		public static Offset zero => k_ZeroOffset;

		public Offset(float left, float right, float top, float bottom)
		{
			m_Left = left;
			m_Right = right;
			m_Top = top;
			m_Bottom = bottom;
		}

		public static bool operator ==(Offset lhs, Offset rhs)
		{
			return lhs.m_Left == rhs.m_Left && lhs.m_Right == rhs.m_Right && lhs.m_Top == rhs.m_Top && lhs.m_Bottom == rhs.m_Bottom;
		}

		public static bool operator !=(Offset lhs, Offset rhs)
		{
			return !(lhs == rhs);
		}

		public static Offset operator *(Offset a, float b)
		{
			return new Offset(a.m_Left * b, a.m_Right * b, a.m_Top * b, a.m_Bottom * b);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public bool Equals(Offset other)
		{
			return base.Equals((object)other);
		}
	}
	internal struct HighlightState(Color32 color, Offset padding)
	{
		public Color32 color = color;

		public Offset padding = padding;

		public static bool operator ==(HighlightState lhs, HighlightState rhs)
		{
			return lhs.color.r == rhs.color.r && lhs.color.g == rhs.color.g && lhs.color.b == rhs.color.b && lhs.color.a == rhs.color.a && lhs.padding == rhs.padding;
		}

		public static bool operator !=(HighlightState lhs, HighlightState rhs)
		{
			return !(lhs == rhs);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public bool Equals(HighlightState other)
		{
			return base.Equals((object)other);
		}
	}
	internal struct WordWrapState
	{
		public int previousWordBreak;

		public int totalCharacterCount;

		public int visibleCharacterCount;

		public int visibleSpaceCount;

		public int visibleSpriteCount;

		public int visibleLinkCount;

		public int firstCharacterIndex;

		public int firstVisibleCharacterIndex;

		public int lastCharacterIndex;

		public int lastVisibleCharIndex;

		public int lineNumber;

		public float maxCapHeight;

		public float maxAscender;

		public float maxDescender;

		public float maxLineAscender;

		public float maxLineDescender;

		public float startOfLineAscender;

		public float xAdvance;

		public float preferredWidth;

		public float preferredHeight;

		public float previousLineScale;

		public float pageAscender;

		public int wordCount;

		public FontStyles fontStyle;

		public float fontScale;

		public float fontScaleMultiplier;

		public int italicAngle;

		public float currentFontSize;

		public float baselineOffset;

		public float lineOffset;

		public TextInfo textInfo;

		public LineInfo lineInfo;

		public Color32 vertexColor;

		public Color32 underlineColor;

		public Color32 strikethroughColor;

		public Color32 highlightColor;

		public HighlightState highlightState;

		public FontStyleStack basicStyleStack;

		public TextProcessingStack<int> italicAngleStack;

		public TextProcessingStack<Color32> colorStack;

		public TextProcessingStack<Color32> underlineColorStack;

		public TextProcessingStack<Color32> strikethroughColorStack;

		public TextProcessingStack<Color32> highlightColorStack;

		public TextProcessingStack<HighlightState> highlightStateStack;

		public TextProcessingStack<TextColorGradient> colorGradientStack;

		public TextProcessingStack<float> sizeStack;

		public TextProcessingStack<float> indentStack;

		public TextProcessingStack<TextFontWeight> fontWeightStack;

		public TextProcessingStack<int> styleStack;

		public TextProcessingStack<float> baselineStack;

		public TextProcessingStack<int> actionStack;

		public TextProcessingStack<MaterialReference> materialReferenceStack;

		public TextProcessingStack<TextAlignment> lineJustificationStack;

		public int lastBaseGlyphIndex;

		public int spriteAnimationId;

		public FontAsset currentFontAsset;

		public SpriteAsset currentSpriteAsset;

		public Material currentMaterial;

		public int currentMaterialIndex;

		public Extents meshExtents;

		public bool tagNoParsing;

		public bool isNonBreakingSpace;

		public bool isDrivenLineSpacing;

		public Vector3 fxScale;

		public Quaternion fxRotation;
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal static class TextGeneratorUtilities
	{
		public static readonly Vector2 largePositiveVector2 = new Vector2(2.1474836E+09f, 2.1474836E+09f);

		public static readonly Vector2 largeNegativeVector2 = new Vector2(-214748370f, -214748370f);

		public const float largePositiveFloat = 32767f;

		public const float largeNegativeFloat = -32767f;

		private const int k_DoubleQuotes = 34;

		private const int k_GreaterThan = 62;

		private const int k_ZeroWidthSpace = 8203;

		private const string k_LookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";

		private static readonly HashSet<uint> k_EmojiLookup = new HashSet<uint>(new uint[1431]
		{
			35u, 42u, 48u, 49u, 50u, 51u, 52u, 53u, 54u, 55u,
			56u, 57u, 169u, 174u, 8252u, 8265u, 8482u, 8505u, 8596u, 8597u,
			8598u, 8599u, 8600u, 8601u, 8617u, 8618u, 8986u, 8987u, 9000u, 9167u,
			9193u, 9194u, 9195u, 9196u, 9197u, 9198u, 9199u, 9200u, 9201u, 9202u,
			9203u, 9208u, 9209u, 9210u, 9410u, 9642u, 9643u, 9654u, 9664u, 9723u,
			9724u, 9725u, 9726u, 9728u, 9729u, 9730u, 9731u, 9732u, 9742u, 9745u,
			9748u, 9749u, 9752u, 9757u, 9760u, 9762u, 9763u, 9766u, 9770u, 9774u,
			9775u, 9784u, 9785u, 9786u, 9792u, 9794u, 9800u, 9801u, 9802u, 9803u,
			9804u, 9805u, 9806u, 9807u, 9808u, 9809u, 9810u, 9811u, 9823u, 9824u,
			9827u, 9829u, 9830u, 9832u, 9851u, 9854u, 9855u, 9874u, 9875u, 9876u,
			9877u, 9878u, 9879u, 9881u, 9883u, 9884u, 9888u, 9889u, 9895u, 9898u,
			9899u, 9904u, 9905u, 9917u, 9918u, 9924u, 9925u, 9928u, 9934u, 9935u,
			9937u, 9939u, 9940u, 9961u, 9962u, 9968u, 9969u, 9970u, 9971u, 9972u,
			9973u, 9975u, 9976u, 9977u, 9978u, 9981u, 9986u, 9989u, 9992u, 9993u,
			9994u, 9995u, 9996u, 9997u, 9999u, 10002u, 10004u, 10006u, 10013u, 10017u,
			10024u, 10035u, 10036u, 10052u, 10055u, 10060u, 10062u, 10067u, 10068u, 10069u,
			10071u, 10083u, 10084u, 10133u, 10134u, 10135u, 10145u, 10160u, 10175u, 10548u,
			10549u, 11013u, 11014u, 11015u, 11035u, 11036u, 11088u, 11093u, 12336u, 12349u,
			12951u, 12953u, 126980u, 127183u, 127344u, 127345u, 127358u, 127359u, 127374u, 127377u,
			127378u, 127379u, 127380u, 127381u, 127382u, 127383u, 127384u, 127385u, 127386u, 127462u,
			127463u, 127464u, 127465u, 127466u, 127467u, 127468u, 127469u, 127470u, 127471u, 127472u,
			127473u, 127474u, 127475u, 127476u, 127477u, 127478u, 127479u, 127480u, 127481u, 127482u,
			127483u, 127484u, 127485u, 127486u, 127487u, 127489u, 127490u, 127514u, 127535u, 127538u,
			127539u, 127540u, 127541u, 127542u, 127543u, 127544u, 127545u, 127546u, 127568u, 127569u,
			127744u, 127745u, 127746u, 127747u, 127748u, 127749u, 127750u, 127751u, 127752u, 127753u,
			127754u, 127755u, 127756u, 127757u, 127758u, 127759u, 127760u, 127761u, 127762u, 127763u,
			127764u, 127765u, 127766u, 127767u, 127768u, 127769u, 127770u, 127771u, 127772u, 127773u,
			127774u, 127775u, 127776u, 127777u, 127780u, 127781u, 127782u, 127783u, 127784u, 127785u,
			127786u, 127787u, 127788u, 127789u, 127790u, 127791u, 127792u, 127793u, 127794u, 127795u,
			127796u, 127797u, 127798u, 127799u, 127800u, 127801u, 127802u, 127803u, 127804u, 127805u,
			127806u, 127807u, 127808u, 127809u, 127810u, 127811u, 127812u, 127813u, 127814u, 127815u,
			127816u, 127817u, 127818u, 127819u, 127820u, 127821u, 127822u, 127823u, 127824u, 127825u,
			127826u, 127827u, 127828u, 127829u, 127830u, 127831u, 127832u, 127833u, 127834u, 127835u,
			127836u, 127837u, 127838u, 127839u, 127840u, 127841u, 127842u, 127843u, 127844u, 127845u,
			127846u, 127847u, 127848u, 127849u, 127850u, 127851u, 127852u, 127853u, 127854u, 127855u,
			127856u, 127857u, 127858u, 127859u, 127860u, 127861u, 127862u, 127863u, 127864u, 127865u,
			127866u, 127867u, 127868u, 127869u, 127870u, 127871u, 127872u, 127873u, 127874u, 127875u,
			127876u, 127877u, 127878u, 127879u, 127880u, 127881u, 127882u, 127883u, 127884u, 127885u,
			127886u, 127887u, 127888u, 127889u, 127890u, 127891u, 127894u, 127895u, 127897u, 127898u,
			127899u, 127902u, 127903u, 127904u, 127905u, 127906u, 127907u, 127908u, 127909u, 127910u,
			127911u, 127912u, 127913u, 127914u, 127915u, 127916u, 127917u, 127918u, 127919u, 127920u,
			127921u, 127922u, 127923u, 127924u, 127925u, 127926u, 127927u, 127928u, 127929u, 127930u,
			127931u, 127932u, 127933u, 127934u, 127935u, 127936u, 127937u, 127938u, 127939u, 127940u,
			127941u, 127942u, 127943u, 127944u, 127945u, 127946u, 127947u, 127948u, 127949u, 127950u,
			127951u, 127952u, 127953u, 127954u, 127955u, 127956u, 127957u, 127958u, 127959u, 127960u,
			127961u, 127962u, 127963u, 127964u, 127965u, 127966u, 127967u, 127968u, 127969u, 127970u,
			127971u, 127972u, 127973u, 127974u, 127975u, 127976u, 127977u, 127978u, 127979u, 127980u,
			127981u, 127982u, 127983u, 127984u, 127987u, 127988u, 127989u, 127991u, 127992u, 127993u,
			127994u, 127995u, 127996u, 127997u, 127998u, 127999u, 128000u, 128001u, 128002u, 128003u,
			128004u, 128005u, 128006u, 128007u, 128008u, 128009u, 128010u, 128011u, 128012u, 128013u,
			128014u, 128015u, 128016u, 128017u, 128018u, 128019u, 128020u, 128021u, 128022u, 128023u,
			128024u, 128025u, 128026u, 128027u, 128028u, 128029u, 128030u, 128031u, 128032u, 128033u,
			128034u, 128035u, 128036u, 128037u, 128038u, 128039u, 128040u, 128041u, 128042u, 128043u,
			128044u, 128045u, 128046u, 128047u, 128048u, 128049u, 128050u, 128051u, 128052u, 128053u,
			128054u, 128055u, 128056u, 128057u, 128058u, 128059u, 128060u, 128061u, 128062u, 128063u,
			128064u, 128065u, 128066u, 128067u, 128068u, 128069u, 128070u, 128071u, 128072u, 128073u,
			128074u, 128075u, 128076u, 128077u, 128078u, 128079u, 128080u, 128081u, 128082u, 128083u,
			128084u, 128085u, 128086u, 128087u, 128088u, 128089u, 128090u, 128091u, 128092u, 128093u,
			128094u, 128095u, 128096u, 128097u, 128098u, 128099u, 128100u, 128101u, 128102u, 128103u,
			128104u, 128105u, 128106u, 128107u, 128108u, 128109u, 128110u, 128111u, 128112u, 128113u,
			128114u, 128115u, 128116u, 128117u, 128118u, 128119u, 128120u, 128121u, 128122u, 128123u,
			128124u, 128125u, 128126u, 128127u, 128128u, 128129u, 128130u, 128131u, 128132u, 128133u,
			128134u, 128135u, 128136u, 128137u, 128138u, 128139u, 128140u, 128141u, 128142u, 128143u,
			128144u, 128145u, 128146u, 128147u, 128148u, 128149u, 128150u, 128151u, 128152u, 128153u,
			128154u, 128155u, 128156u, 128157u, 128158u, 128159u, 128160u, 128161u, 128162u, 128163u,
			128164u, 128165u, 128166u, 128167u, 128168u, 128169u, 128170u, 128171u, 128172u, 128173u,
			128174u, 128175u, 128176u, 128177u, 128178u, 128179u, 128180u, 128181u, 128182u, 128183u,
			128184u, 128185u, 128186u, 128187u, 128188u, 128189u, 128190u, 128191u, 128192u, 128193u,
			128194u, 128195u, 128196u, 128197u, 128198u, 128199u, 128200u, 128201u, 128202u, 128203u,
			128204u, 128205u, 128206u, 128207u, 128208u, 128209u, 128210u, 128211u, 128212u, 128213u,
			128214u, 128215u, 128216u, 128217u, 128218u, 128219u, 128220u, 128221u, 128222u, 128223u,
			128224u, 128225u, 128226u, 128227u, 128228u, 128229u, 128230u, 128231u, 128232u, 128233u,
			128234u, 128235u, 128236u, 128237u, 128238u, 128239u, 128240u, 128241u, 128242u, 128243u,
			128244u, 128245u, 128246u, 128247u, 128248u, 128249u, 128250u, 128251u, 128252u, 128253u,
			128255u, 128256u, 128257u, 128258u, 128259u, 128260u, 128261u, 128262u, 128263u, 128264u,
			128265u, 128266u, 128267u, 128268u, 128269u, 128270u, 128271u, 128272u, 128273u, 128274u,
			128275u, 128276u, 128277u, 128278u, 128279u, 128280u, 128281u, 128282u, 128283u, 128284u,
			128285u, 128286u, 128287u, 128288u, 128289u, 128290u, 128291u, 128292u, 128293u, 128294u,
			128295u, 128296u, 128297u, 128298u, 128299u, 128300u, 128301u, 128302u, 128303u, 128304u,
			128305u, 128306u, 128307u, 128308u, 128309u, 128310u, 128311u, 128312u, 128313u, 128314u,
			128315u, 128316u, 128317u, 128329u, 128330u, 128331u, 128332u, 128333u, 128334u, 128336u,
			128337u, 128338u, 128339u, 128340u, 128341u, 128342u, 128343u, 128344u, 128345u, 128346u,
			128347u, 128348u, 128349u, 128350u, 128351u, 128352u, 128353u, 128354u, 128355u, 128356u,
			128357u, 128358u, 128359u, 128367u, 128368u, 128371u, 128372u, 128373u, 128374u, 128375u,
			128376u, 128377u, 128378u, 128391u, 128394u, 128395u, 128396u, 128397u, 128400u, 128405u,
			128406u, 128420u, 128421u, 128424u, 128433u, 128434u, 128444u, 128450u, 128451u, 128452u,
			128465u, 128466u, 128467u, 128476u, 128477u, 128478u, 128481u, 128483u, 128488u, 128495u,
			128499u, 128506u, 128507u, 128508u, 128509u, 128510u, 128511u, 128512u, 128513u, 128514u,
			128515u, 128516u, 128517u, 128518u, 128519u, 128520u, 128521u, 128522u, 128523u, 128524u,
			128525u, 128526u, 128527u, 128528u, 128529u, 128530u, 128531u, 128532u, 128533u, 128534u,
			128535u, 128536u, 128537u, 128538u, 128539u, 128540u, 128541u, 128542u, 128543u, 128544u,
			128545u, 128546u, 128547u, 128548u, 128549u, 128550u, 128551u, 128552u, 128553u, 128554u,
			128555u, 128556u, 128557u, 128558u, 128559u, 128560u, 128561u, 128562u, 128563u, 128564u,
			128565u, 128566u, 128567u, 128568u, 128569u, 128570u, 128571u, 128572u, 128573u, 128574u,
			128575u, 128576u, 128577u, 128578u, 128579u, 128580u, 128581u, 128582u, 128583u, 128584u,
			128585u, 128586u, 128587u, 128588u, 128589u, 128590u, 128591u, 128640u, 128641u, 128642u,
			128643u, 128644u, 128645u, 128646u, 128647u, 128648u, 128649u, 128650u, 128651u, 128652u,
			128653u, 128654u, 128655u, 128656u, 128657u, 128658u, 128659u, 128660u, 128661u, 128662u,
			128663u, 128664u, 128665u, 128666u, 128667u, 128668u, 128669u, 128670u, 128671u, 128672u,
			128673u, 128674u, 128675u, 128676u, 128677u, 128678u, 128679u, 128680u, 128681u, 128682u,
			128683u, 128684u, 128685u, 128686u, 128687u, 128688u, 128689u, 128690u, 128691u, 128692u,
			128693u, 128694u, 128695u, 128696u, 128697u, 128698u, 128699u, 128700u, 128701u, 128702u,
			128703u, 128704u, 128705u, 128706u, 128707u, 128708u, 128709u, 128715u, 128716u, 128717u,
			128718u, 128719u, 128720u, 128721u, 128722u, 128725u, 128726u, 128727u, 128732u, 128733u,
			128734u, 128735u, 128736u, 128737u, 128738u, 128739u, 128740u, 128741u, 128745u, 128747u,
			128748u, 128752u, 128755u, 128756u, 128757u, 128758u, 128759u, 128760u, 128761u, 128762u,
			128763u, 128764u, 128992u, 128993u, 128994u, 128995u, 128996u, 128997u, 128998u, 128999u,
			129000u, 129001u, 129002u, 129003u, 129008u, 129292u, 129293u, 129294u, 129295u, 129296u,
			129297u, 129298u, 129299u, 129300u, 129301u, 129302u, 129303u, 129304u, 129305u, 129306u,
			129307u, 129308u, 129309u, 129310u, 129311u, 129312u, 129313u, 129314u, 129315u, 129316u,
			129317u, 129318u, 129319u, 129320u, 129321u, 129322u, 129323u, 129324u, 129325u, 129326u,
			129327u, 129328u, 129329u, 129330u, 129331u, 129332u, 129333u, 129334u, 129335u, 129336u,
			129337u, 129338u, 129340u, 129341u, 129342u, 129343u, 129344u, 129345u, 129346u, 129347u,
			129348u, 129349u, 129351u, 129352u, 129353u, 129354u, 129355u, 129356u, 129357u, 129358u,
			129359u, 129360u, 129361u, 129362u, 129363u, 129364u, 129365u, 129366u, 129367u, 129368u,
			129369u, 129370u, 129371u, 129372u, 129373u, 129374u, 129375u, 129376u, 129377u, 129378u,
			129379u, 129380u, 129381u, 129382u, 129383u, 129384u, 129385u, 129386u, 129387u, 129388u,
			129389u, 129390u, 129391u, 129392u, 129393u, 129394u, 129395u, 129396u, 129397u, 129398u,
			129399u, 129400u, 129401u, 129402u, 129403u, 129404u, 129405u, 129406u, 129407u, 129408u,
			129409u, 129410u, 129411u, 129412u, 129413u, 129414u, 129415u, 129416u, 129417u, 129418u,
			129419u, 129420u, 129421u, 129422u, 129423u, 129424u, 129425u, 129426u, 129427u, 129428u,
			129429u, 129430u, 129431u, 129432u, 129433u, 129434u, 129435u, 129436u, 129437u, 129438u,
			129439u, 129440u, 129441u, 129442u, 129443u, 129444u, 129445u, 129446u, 129447u, 129448u,
			129449u, 129450u, 129451u, 129452u, 129453u, 129454u, 129455u, 129456u, 129457u, 129458u,
			129459u, 129460u, 129461u, 129462u, 129463u, 129464u, 129465u, 129466u, 129467u, 129468u,
			129469u, 129470u, 129471u, 129472u, 129473u, 129474u, 129475u, 129476u, 129477u, 129478u,
			129479u, 129480u, 129481u, 129482u, 129483u, 129484u, 129485u, 129486u, 129487u, 129488u,
			129489u, 129490u, 129491u, 129492u, 129493u, 129494u, 129495u, 129496u, 129497u, 129498u,
			129499u, 129500u, 129501u, 129502u, 129503u, 129504u, 129505u, 129506u, 129507u, 129508u,
			129509u, 129510u, 129511u, 129512u, 129513u, 129514u, 129515u, 129516u, 129517u, 129518u,
			129519u, 129520u, 129521u, 129522u, 129523u, 129524u, 129525u, 129526u, 129527u, 129528u,
			129529u, 129530u, 129531u, 129532u, 129533u, 129534u, 129535u, 129648u, 129649u, 129650u,
			129651u, 129652u, 129653u, 129654u, 129655u, 129656u, 129657u, 129658u, 129659u, 129660u,
			129664u, 129665u, 129666u, 129667u, 129668u, 129669u, 129670u, 129671u, 129672u, 129673u,
			129679u, 129680u, 129681u, 129682u, 129683u, 129684u, 129685u, 129686u, 129687u, 129688u,
			129689u, 129690u, 129691u, 129692u, 129693u, 129694u, 129695u, 129696u, 129697u, 129698u,
			129699u, 129700u, 129701u, 129702u, 129703u, 129704u, 129705u, 129706u, 129707u, 129708u,
			129709u, 129710u, 129711u, 129712u, 129713u, 129714u, 129715u, 129716u, 129717u, 129718u,
			129719u, 129720u, 129721u, 129722u, 129723u, 129724u, 129725u, 129726u, 129727u, 129728u,
			129729u, 129730u, 129731u, 129732u, 129733u, 129734u, 129742u, 129743u, 129744u, 129745u,
			129746u, 129747u, 129748u, 129749u, 129750u, 129751u, 129752u, 129753u, 129754u, 129755u,
			129756u, 129759u, 129760u, 129761u, 129762u, 129763u, 129764u, 129765u, 129766u, 129767u,
			129768u, 129769u, 129776u, 129777u, 129778u, 129779u, 129780u, 129781u, 129782u, 129783u,
			129784u
		});

		private static readonly HashSet<uint> k_EmojiPresentationFormLookup = new HashSet<uint>(new uint[1212]
		{
			8986u, 8987u, 9193u, 9194u, 9195u, 9196u, 9200u, 9203u, 9725u, 9726u,
			9748u, 9749u, 9800u, 9801u, 9802u, 9803u, 9804u, 9805u, 9806u, 9807u,
			9808u, 9809u, 9810u, 9811u, 9855u, 9875u, 9889u, 9898u, 9899u, 9917u,
			9918u, 9924u, 9925u, 9934u, 9940u, 9962u, 9970u, 9971u, 9973u, 9978u,
			9981u, 9989u, 9994u, 9995u, 10024u, 10060u, 10062u, 10067u, 10068u, 10069u,
			10071u, 10133u, 10134u, 10135u, 10160u, 10175u, 11035u, 11036u, 11088u, 11093u,
			126980u, 127183u, 127374u, 127377u, 127378u, 127379u, 127380u, 127381u, 127382u, 127383u,
			127384u, 127385u, 127386u, 127462u, 127463u, 127464u, 127465u, 127466u, 127467u, 127468u,
			127469u, 127470u, 127471u, 127472u, 127473u, 127474u, 127475u, 127476u, 127477u, 127478u,
			127479u, 127480u, 127481u, 127482u, 127483u, 127484u, 127485u, 127486u, 127487u, 127489u,
			127514u, 127535u, 127538u, 127539u, 127540u, 127541u, 127542u, 127544u, 127545u, 127546u,
			127568u, 127569u, 127744u, 127745u, 127746u, 127747u, 127748u, 127749u, 127750u, 127751u,
			127752u, 127753u, 127754u, 127755u, 127756u, 127757u, 127758u, 127759u, 127760u, 127761u,
			127762u, 127763u, 127764u, 127765u, 127766u, 127767u, 127768u, 127769u, 127770u, 127771u,
			127772u, 127773u, 127774u, 127775u, 127776u, 127789u, 127790u, 127791u, 127792u, 127793u,
			127794u, 127795u, 127796u, 127797u, 127799u, 127800u, 127801u, 127802u, 127803u, 127804u,
			127805u, 127806u, 127807u, 127808u, 127809u, 127810u, 127811u, 127812u, 127813u, 127814u,
			127815u, 127816u, 127817u, 127818u, 127819u, 127820u, 127821u, 127822u, 127823u, 127824u,
			127825u, 127826u, 127827u, 127828u, 127829u, 127830u, 127831u, 127832u, 127833u, 127834u,
			127835u, 127836u, 127837u, 127838u, 127839u, 127840u, 127841u, 127842u, 127843u, 127844u,
			127845u, 127846u, 127847u, 127848u, 127849u, 127850u, 127851u, 127852u, 127853u, 127854u,
			127855u, 127856u, 127857u, 127858u, 127859u, 127860u, 127861u, 127862u, 127863u, 127864u,
			127865u, 127866u, 127867u, 127868u, 127870u, 127871u, 127872u, 127873u, 127874u, 127875u,
			127876u, 127877u, 127878u, 127879u, 127880u, 127881u, 127882u, 127883u, 127884u, 127885u,
			127886u, 127887u, 127888u, 127889u, 127890u, 127891u, 127904u, 127905u, 127906u, 127907u,
			127908u, 127909u, 127910u, 127911u, 127912u, 127913u, 127914u, 127915u, 127916u, 127917u,
			127918u, 127919u, 127920u, 127921u, 127922u, 127923u, 127924u, 127925u, 127926u, 127927u,
			127928u, 127929u, 127930u, 127931u, 127932u, 127933u, 127934u, 127935u, 127936u, 127937u,
			127938u, 127939u, 127940u, 127941u, 127942u, 127943u, 127944u, 127945u, 127946u, 127951u,
			127952u, 127953u, 127954u, 127955u, 127968u, 127969u, 127970u, 127971u, 127972u, 127973u,
			127974u, 127975u, 127976u, 127977u, 127978u, 127979u, 127980u, 127981u, 127982u, 127983u,
			127984u, 127988u, 127992u, 127993u, 127994u, 127995u, 127996u, 127997u, 127998u, 127999u,
			128000u, 128001u, 128002u, 128003u, 128004u, 128005u, 128006u, 128007u, 128008u, 128009u,
			128010u, 128011u, 128012u, 128013u, 128014u, 128015u, 128016u, 128017u, 128018u, 128019u,
			128020u, 128021u, 128022u, 128023u, 128024u, 128025u, 128026u, 128027u, 128028u, 128029u,
			128030u, 128031u, 128032u, 128033u, 128034u, 128035u, 128036u, 128037u, 128038u, 128039u,
			128040u, 128041u, 128042u, 128043u, 128044u, 128045u, 128046u, 128047u, 128048u, 128049u,
			128050u, 128051u, 128052u, 128053u, 128054u, 128055u, 128056u, 128057u, 128058u, 128059u,
			128060u, 128061u, 128062u, 128064u, 128066u, 128067u, 128068u, 128069u, 128070u, 128071u,
			128072u, 128073u, 128074u, 128075u, 128076u, 128077u, 128078u, 128079u, 128080u, 128081u,
			128082u, 128083u, 128084u, 128085u, 128086u, 128087u, 128088u, 128089u, 128090u, 128091u,
			128092u, 128093u, 128094u, 128095u, 128096u, 128097u, 128098u, 128099u, 128100u, 128101u,
			128102u, 128103u, 128104u, 128105u, 128106u, 128107u, 128108u, 128109u, 128110u, 128111u,
			128112u, 128113u, 128114u, 128115u, 128116u, 128117u, 128118u, 128119u, 128120u, 128121u,
			128122u, 128123u, 128124u, 128125u, 128126u, 128127u, 128128u, 128129u, 128130u, 128131u,
			128132u, 128133u, 128134u, 128135u, 128136u, 128137u, 128138u, 128139u, 128140u, 128141u,
			128142u, 128143u, 128144u, 128145u, 128146u, 128147u, 128148u, 128149u, 128150u, 128151u,
			128152u, 128153u, 128154u, 128155u, 128156u, 128157u, 128158u, 128159u, 128160u, 128161u,
			128162u, 128163u, 128164u, 128165u, 128166u, 128167u, 128168u, 128169u, 128170u, 128171u,
			128172u, 128173u, 128174u, 128175u, 128176u, 128177u, 128178u, 128179u, 128180u, 128181u,
			128182u, 128183u, 128184u, 128185u, 128186u, 128187u, 128188u, 128189u, 128190u, 128191u,
			128192u, 128193u, 128194u, 128195u, 128196u, 128197u, 128198u, 128199u, 128200u, 128201u,
			128202u, 128203u, 128204u, 128205u, 128206u, 128207u, 128208u, 128209u, 128210u, 128211u,
			128212u, 128213u, 128214u, 128215u, 128216u, 128217u, 128218u, 128219u, 128220u, 128221u,
			128222u, 128223u, 128224u, 128225u, 128226u, 128227u, 128228u, 128229u, 128230u, 128231u,
			128232u, 128233u, 128234u, 128235u, 128236u, 128237u, 128238u, 128239u, 128240u, 128241u,
			128242u, 128243u, 128244u, 128245u, 128246u, 128247u, 128248u, 128249u, 128250u, 128251u,
			128252u, 128255u, 128256u, 128257u, 128258u, 128259u, 128260u, 128261u, 128262u, 128263u,
			128264u, 128265u, 128266u, 128267u, 128268u, 128269u, 128270u, 128271u, 128272u, 128273u,
			128274u, 128275u, 128276u, 128277u, 128278u, 128279u, 128280u, 128281u, 128282u, 128283u,
			128284u, 128285u, 128286u, 128287u, 128288u, 128289u, 128290u, 128291u, 128292u, 128293u,
			128294u, 128295u, 128296u, 128297u, 128298u, 128299u, 128300u, 128301u, 128302u, 128303u,
			128304u, 128305u, 128306u, 128307u, 128308u, 128309u, 128310u, 128311u, 128312u, 128313u,
			128314u, 128315u, 128316u, 128317u, 128331u, 128332u, 128333u, 128334u, 128336u, 128337u,
			128338u, 128339u, 128340u, 128341u, 128342u, 128343u, 128344u, 128345u, 128346u, 128347u,
			128348u, 128349u, 128350u, 128351u, 128352u, 128353u, 128354u, 128355u, 128356u, 128357u,
			128358u, 128359u, 128378u, 128405u, 128406u, 128420u, 128507u, 128508u, 128509u, 128510u,
			128511u, 128512u, 128513u, 128514u, 128515u, 128516u, 128517u, 128518u, 128519u, 128520u,
			128521u, 128522u, 128523u, 128524u, 128525u, 128526u, 128527u, 128528u, 128529u, 128530u,
			128531u, 128532u, 128533u, 128534u, 128535u, 128536u, 128537u, 128538u, 128539u, 128540u,
			128541u, 128542u, 128543u, 128544u, 128545u, 128546u, 128547u, 128548u, 128549u, 128550u,
			128551u, 128552u, 128553u, 128554u, 128555u, 128556u, 128557u, 128558u, 128559u, 128560u,
			128561u, 128562u, 128563u, 128564u, 128565u, 128566u, 128567u, 128568u, 128569u, 128570u,
			128571u, 128572u, 128573u, 128574u, 128575u, 128576u, 128577u, 128578u, 128579u, 128580u,
			128581u, 128582u, 128583u, 128584u, 128585u, 128586u, 128587u, 128588u, 128589u, 128590u,
			128591u, 128640u, 128641u, 128642u, 128643u, 128644u, 128645u, 128646u, 128647u, 128648u,
			128649u, 128650u, 128651u, 128652u, 128653u, 128654u, 128655u, 128656u, 128657u, 128658u,
			128659u, 128660u, 128661u, 128662u, 128663u, 128664u, 128665u, 128666u, 128667u, 128668u,
			128669u, 128670u, 128671u, 128672u, 128673u, 128674u, 128675u, 128676u, 128677u, 128678u,
			128679u, 128680u, 128681u, 128682u, 128683u, 128684u, 128685u, 128686u, 128687u, 128688u,
			128689u, 128690u, 128691u, 128692u, 128693u, 128694u, 128695u, 128696u, 128697u, 128698u,
			128699u, 128700u, 128701u, 128702u, 128703u, 128704u, 128705u, 128706u, 128707u, 128708u,
			128709u, 128716u, 128720u, 128721u, 128722u, 128725u, 128726u, 128727u, 128732u, 128733u,
			128734u, 128735u, 128747u, 128748u, 128756u, 128757u, 128758u, 128759u, 128760u, 128761u,
			128762u, 128763u, 128764u, 128992u, 128993u, 128994u, 128995u, 128996u, 128997u, 128998u,
			128999u, 129000u, 129001u, 129002u, 129003u, 129008u, 129292u, 129293u, 129294u, 129295u,
			129296u, 129297u, 129298u, 129299u, 129300u, 129301u, 129302u, 129303u, 129304u, 129305u,
			129306u, 129307u, 129308u, 129309u, 129310u, 129311u, 129312u, 129313u, 129314u, 129315u,
			129316u, 129317u, 129318u, 129319u, 129320u, 129321u, 129322u, 129323u, 129324u, 129325u,
			129326u, 129327u, 129328u, 129329u, 129330u, 129331u, 129332u, 129333u, 129334u, 129335u,
			129336u, 129337u, 129338u, 129340u, 129341u, 129342u, 129343u, 129344u, 129345u, 129346u,
			129347u, 129348u, 129349u, 129351u, 129352u, 129353u, 129354u, 129355u, 129356u, 129357u,
			129358u, 129359u, 129360u, 129361u, 129362u, 129363u, 129364u, 129365u, 129366u, 129367u,
			129368u, 129369u, 129370u, 129371u, 129372u, 129373u, 129374u, 129375u, 129376u, 129377u,
			129378u, 129379u, 129380u, 129381u, 129382u, 129383u, 129384u, 129385u, 129386u, 129387u,
			129388u, 129389u, 129390u, 129391u, 129392u, 129393u, 129394u, 129395u, 129396u, 129397u,
			129398u, 129399u, 129400u, 129401u, 129402u, 129403u, 129404u, 129405u, 129406u, 129407u,
			129408u, 129409u, 129410u, 129411u, 129412u, 129413u, 129414u, 129415u, 129416u, 129417u,
			129418u, 129419u, 129420u, 129421u, 129422u, 129423u, 129424u, 129425u, 129426u, 129427u,
			129428u, 129429u, 129430u, 129431u, 129432u, 129433u, 129434u, 129435u, 129436u, 129437u,
			129438u, 129439u, 129440u, 129441u, 129442u, 129443u, 129444u, 129445u, 129446u, 129447u,
			129448u, 129449u, 129450u, 129451u, 129452u, 129453u, 129454u, 129455u, 129456u, 129457u,
			129458u, 129459u, 129460u, 129461u, 129462u, 129463u, 129464u, 129465u, 129466u, 129467u,
			129468u, 129469u, 129470u, 129471u, 129472u, 129473u, 129474u, 129475u, 129476u, 129477u,
			129478u, 129479u, 129480u, 129481u, 129482u, 129483u, 129484u, 129485u, 129486u, 129487u,
			129488u, 129489u, 129490u, 129491u, 129492u, 129493u, 129494u, 129495u, 129496u, 129497u,
			129498u, 129499u, 129500u, 129501u, 129502u, 129503u, 129504u, 129505u, 129506u, 129507u,
			129508u, 129509u, 129510u, 129511u, 129512u, 129513u, 129514u, 129515u, 129516u, 129517u,
			129518u, 129519u, 129520u, 129521u, 129522u, 129523u, 129524u, 129525u, 129526u, 129527u,
			129528u, 129529u, 129530u, 129531u, 129532u, 129533u, 129534u, 129535u, 129648u, 129649u,
			129650u, 129651u, 129652u, 129653u, 129654u, 129655u, 129656u, 129657u, 129658u, 129659u,
			129660u, 129664u, 129665u, 129666u, 129667u, 129668u, 129669u, 129670u, 129671u, 129672u,
			129673u, 129679u, 129680u, 129681u, 129682u, 129683u, 129684u, 129685u, 129686u, 129687u,
			129688u, 129689u, 129690u, 129691u, 129692u, 129693u, 129694u, 129695u, 129696u, 129697u,
			129698u, 129699u, 129700u, 129701u, 129702u, 129703u, 129704u, 129705u, 129706u, 129707u,
			129708u, 129709u, 129710u, 129711u, 129712u, 129713u, 129714u, 129715u, 129716u, 129717u,
			129718u, 129719u, 129720u, 129721u, 129722u, 129723u, 129724u, 129725u, 129726u, 129727u,
			129728u, 129729u, 129730u, 129731u, 129732u, 129733u, 129734u, 129742u, 129743u, 129744u,
			129745u, 129746u, 129747u, 129748u, 129749u, 129750u, 129751u, 129752u, 129753u, 129754u,
			129755u, 129756u, 129759u, 129760u, 129761u, 129762u, 129763u, 129764u, 129765u, 129766u,
			129767u, 129768u, 129769u, 129776u, 129777u, 129778u, 129779u, 129780u, 129781u, 129782u,
			129783u, 129784u
		});

		public static bool Approximately(float a, float b)
		{
			return b - 0.0001f < a && a < b + 0.0001f;
		}

		public static Color32 HexCharsToColor(char[] hexChars, int startIndex, int tagCount)
		{
			switch (tagCount)
			{
			case 4:
			{
				byte r4 = (byte)(HexToInt(hexChars[startIndex + 1]) * 16 + HexToInt(hexChars[startIndex + 1]));
				byte g4 = (byte)(HexToInt(hexChars[startIndex + 2]) * 16 + HexToInt(hexChars[startIndex + 2]));
				byte b4 = (byte)(HexToInt(hexChars[startIndex + 3]) * 16 + HexToInt(hexChars[startIndex + 3]));
				return new Color32(r4, g4, b4, byte.MaxValue);
			}
			case 5:
			{
				byte r3 = (byte)(HexToInt(hexChars[startIndex + 1]) * 16 + HexToInt(hexChars[startIndex + 1]));
				byte g3 = (byte)(HexToInt(hexChars[startIndex + 2]) * 16 + HexToInt(hexChars[startIndex + 2]));
				byte b3 = (byte)(HexToInt(hexChars[startIndex + 3]) * 16 + HexToInt(hexChars[startIndex + 3]));
				byte a2 = (byte)(HexToInt(hexChars[startIndex + 4]) * 16 + HexToInt(hexChars[startIndex + 4]));
				return new Color32(r3, g3, b3, a2);
			}
			case 7:
			{
				byte r2 = (byte)(HexToInt(hexChars[startIndex + 1]) * 16 + HexToInt(hexChars[startIndex + 2]));
				byte g2 = (byte)(HexToInt(hexChars[startIndex + 3]) * 16 + HexToInt(hexChars[startIndex + 4]));
				byte b2 = (byte)(HexToInt(hexChars[startIndex + 5]) * 16 + HexToInt(hexChars[startIndex + 6]));
				return new Color32(r2, g2, b2, byte.MaxValue);
			}
			case 9:
			{
				byte r = (byte)(HexToInt(hexChars[startIndex + 1]) * 16 + HexToInt(hexChars[startIndex + 2]));
				byte g = (byte)(HexToInt(hexChars[startIndex + 3]) * 16 + HexToInt(hexChars[startIndex + 4]));
				byte b = (byte)(HexToInt(hexChars[startIndex + 5]) * 16 + HexToInt(hexChars[startIndex + 6]));
				byte a = (byte)(HexToInt(hexChars[startIndex + 7]) * 16 + HexToInt(hexChars[startIndex + 8]));
				return new Color32(r, g, b, a);
			}
			default:
				return new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
		}

		public static uint HexToInt(char hex)
		{
			switch (hex)
			{
			case '0':
				return 0u;
			case '1':
				return 1u;
			case '2':
				return 2u;
			case '3':
				return 3u;
			case '4':
				return 4u;
			case '5':
				return 5u;
			case '6':
				return 6u;
			case '7':
				return 7u;
			case '8':
				return 8u;
			case '9':
				return 9u;
			case 'A':
			case 'a':
				return 10u;
			case 'B':
			case 'b':
				return 11u;
			case 'C':
			case 'c':
				return 12u;
			case 'D':
			case 'd':
				return 13u;
			case 'E':
			case 'e':
				return 14u;
			case 'F':
			case 'f':
				return 15u;
			default:
				return 15u;
			}
		}

		public static float ConvertToFloat(char[] chars, int startIndex, int length)
		{
			int lastIndex;
			return ConvertToFloat(chars, startIndex, length, out lastIndex);
		}

		public static float ConvertToFloat(char[] chars, int startIndex, int length, out int lastIndex)
		{
			if (startIndex == 0)
			{
				lastIndex = 0;
				return -32767f;
			}
			int num = startIndex + length;
			bool flag = true;
			float num2 = 0f;
			int num3 = 1;
			if (chars[startIndex] == '+')
			{
				num3 = 1;
				startIndex++;
			}
			else if (chars[startIndex] == '-')
			{
				num3 = -1;
				startIndex++;
			}
			float num4 = 0f;
			for (int i = startIndex; i < num; i++)
			{
				uint num5 = chars[i];
				if ((num5 >= 48 && num5 <= 57) || num5 == 46)
				{
					if (num5 == 46)
					{
						flag = false;
						num2 = 0.1f;
					}
					else if (flag)
					{
						num4 = num4 * 10f + (float)((num5 - 48) * num3);
					}
					else
					{
						num4 += (float)(num5 - 48) * num2 * (float)num3;
						num2 *= 0.1f;
					}
				}
				else if (num5 == 44)
				{
					if (i + 1 < num && chars[i + 1] == ' ')
					{
						lastIndex = i + 1;
					}
					else
					{
						lastIndex = i;
					}
					return num4;
				}
			}
			lastIndex = num;
			return num4;
		}

		public static void ResizeInternalArray<T>(ref T[] array)
		{
			int newSize = Mathf.NextPowerOfTwo(array.Length + 1);
			Array.Resize(ref array, newSize);
		}

		public static void ResizeInternalArray<T>(ref T[] array, int size)
		{
			size = Mathf.NextPowerOfTwo(size + 1);
			Array.Resize(ref array, size);
		}

		private static bool IsTagName(ref string text, string tag, int index)
		{
			if (text.Length < index + tag.Length)
			{
				return false;
			}
			for (int i = 0; i < tag.Length; i++)
			{
				if (TextUtilities.ToUpperFast(text[index + i]) != tag[i])
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsTagName(ref int[] text, string tag, int index)
		{
			if (text.Length < index + tag.Length)
			{
				return false;
			}
			for (int i = 0; i < tag.Length; i++)
			{
				if (TextUtilities.ToUpperFast((char)text[index + i]) != tag[i])
				{
					return false;
				}
			}
			return true;
		}

		internal static void InsertOpeningTextStyle(TextStyle style, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			if (style != null)
			{
				textStyleStackDepth++;
				textStyleStacks[textStyleStackDepth].Push(style.hashCode);
				uint[] styleOpeningTagArray = style.styleOpeningTagArray;
				InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleOpeningTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
				textStyleStackDepth--;
			}
		}

		internal static void InsertClosingTextStyle(TextStyle style, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			if (style != null)
			{
				textStyleStackDepth++;
				textStyleStacks[textStyleStackDepth].Push(style.hashCode);
				uint[] styleClosingTagArray = style.styleClosingTagArray;
				InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleClosingTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
				textStyleStackDepth--;
			}
		}

		public static bool ReplaceOpeningStyleTag(ref TextBackingContainer sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			int styleHashCode = GetStyleHashCode(ref sourceText, srcIndex + 7, out srcOffset);
			TextStyle style = GetStyle(generationSettings, styleHashCode);
			if (style == null || srcOffset == 0)
			{
				return false;
			}
			textStyleStackDepth++;
			textStyleStacks[textStyleStackDepth].Push(style.hashCode);
			uint[] styleOpeningTagArray = style.styleOpeningTagArray;
			InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleOpeningTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
			textStyleStackDepth--;
			return true;
		}

		public static void ReplaceOpeningStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			int hashCode = textStyleStacks[textStyleStackDepth + 1].Pop();
			TextStyle style = GetStyle(generationSettings, hashCode);
			if (style != null)
			{
				textStyleStackDepth++;
				uint[] styleOpeningTagArray = style.styleOpeningTagArray;
				InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleOpeningTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
				textStyleStackDepth--;
			}
		}

		private static bool ReplaceOpeningStyleTag(ref uint[] sourceText, int srcIndex, out int srcOffset, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			int styleHashCode = GetStyleHashCode(ref sourceText, srcIndex + 7, out srcOffset);
			TextStyle style = GetStyle(generationSettings, styleHashCode);
			if (style == null || srcOffset == 0)
			{
				return false;
			}
			textStyleStackDepth++;
			textStyleStacks[textStyleStackDepth].Push(style.hashCode);
			uint[] styleOpeningTagArray = style.styleOpeningTagArray;
			InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleOpeningTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
			textStyleStackDepth--;
			return true;
		}

		public static void ReplaceClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			int hashCode = textStyleStacks[textStyleStackDepth + 1].Pop();
			TextStyle style = GetStyle(generationSettings, hashCode);
			if (style != null)
			{
				textStyleStackDepth++;
				uint[] styleClosingTagArray = style.styleClosingTagArray;
				InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleClosingTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
				textStyleStackDepth--;
			}
		}

		internal static void InsertOpeningStyleTag(TextStyle style, ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			if (style != null)
			{
				textStyleStacks[0].Push(style.hashCode);
				uint[] styleOpeningTagArray = style.styleOpeningTagArray;
				InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleOpeningTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
				textStyleStackDepth = 0;
			}
		}

		internal static void InsertClosingStyleTag(ref TextProcessingElement[] charBuffer, ref int writeIndex, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			int hashCode = textStyleStacks[0].Pop();
			TextStyle style = GetStyle(generationSettings, hashCode);
			uint[] styleClosingTagArray = style.styleClosingTagArray;
			InsertTextStyleInTextProcessingArray(ref charBuffer, ref writeIndex, styleClosingTagArray, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
			textStyleStackDepth = 0;
		}

		private static void InsertTextStyleInTextProcessingArray(ref TextProcessingElement[] charBuffer, ref int writeIndex, uint[] styleDefinition, ref int textStyleStackDepth, ref TextProcessingStack<int>[] textStyleStacks, ref TextGenerationSettings generationSettings)
		{
			bool flag = false;
			int num = styleDefinition.Length;
			if (writeIndex + num >= charBuffer.Length)
			{
				ResizeInternalArray(ref charBuffer, writeIndex + num);
			}
			for (int i = 0; i < num; i++)
			{
				uint num2 = styleDefinition[i];
				if (num2 == 92 && i + 1 < num)
				{
					switch (styleDefinition[i + 1])
					{
					case 92u:
						i++;
						break;
					case 110u:
						num2 = 10u;
						i++;
						break;
					case 117u:
						if (i + 5 < num)
						{
							num2 = GetUTF16(styleDefinition, i + 2);
							i += 5;
						}
						break;
					case 85u:
						if (i + 9 < num)
						{
							num2 = GetUTF32(styleDefinition, i + 2);
							i += 9;
						}
						break;
					}
				}
				if (num2 == 60)
				{
					switch ((MarkupTag)GetMarkupTagHashCode(styleDefinition, i + 1))
					{
					case MarkupTag.NO_PARSE:
						flag = true;
						break;
					case MarkupTag.SLASH_NO_PARSE:
						flag = false;
						break;
					case MarkupTag.BR:
						if (flag)
						{
							break;
						}
						charBuffer[writeIndex].unicode = 10u;
						writeIndex++;
						i += 3;
						continue;
					case MarkupTag.CR:
						if (flag)
						{
							break;
						}
						charBuffer[writeIndex].unicode = 13u;
						writeIndex++;
						i += 3;
						continue;
					case MarkupTag.NBSP:
						if (flag)
						{
							break;
						}
						charBuffer[writeIndex].unicode = 160u;
						writeIndex++;
						i += 5;
						continue;
					case MarkupTag.ZWSP:
						if (flag)
						{
							break;
						}
						charBuffer[writeIndex].unicode = 8203u;
						writeIndex++;
						i += 5;
						continue;
					case MarkupTag.ZWJ:
						if (flag)
						{
							break;
						}
						charBuffer[writeIndex].unicode = 8205u;
						writeIndex++;
						i += 4;
						continue;
					case MarkupTag.SHY:
						if (flag)
						{
							break;
						}
						charBuffer[writeIndex].unicode = 173u;
						writeIndex++;
						i += 4;
						continue;
					case MarkupTag.STYLE:
					{
						if (flag || !ReplaceOpeningStyleTag(ref styleDefinition, i, out var srcOffset, ref charBuffer, ref writeIndex, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings))
						{
							break;
						}
						int num3 = num - srcOffset;
						i = srcOffset;
						if (writeIndex + num3 >= charBuffer.Length)
						{
							ResizeInternalArray(ref charBuffer, writeIndex + num3);
						}
						continue;
					}
					case MarkupTag.SLASH_STYLE:
						if (flag)
						{
							break;
						}
						ReplaceClosingStyleTag(ref charBuffer, ref writeIndex, ref textStyleStackDepth, ref textStyleStacks, ref generationSettings);
						i += 7;
						continue;
					}
				}
				charBuffer[writeIndex].unicode = num2;
				writeIndex++;
			}
		}

		public static TextStyle GetStyle(TextGenerationSettings generationSetting, int hashCode)
		{
			TextStyle textStyle = null;
			TextStyleSheet textStyleSheet = null;
			if (textStyleSheet != null)
			{
				textStyle = textStyleSheet.GetStyle(hashCode);
				if (textStyle != null)
				{
					return textStyle;
				}
			}
			textStyleSheet = generationSetting.textSettings.defaultStyleSheet;
			if (textStyleSheet != null)
			{
				textStyle = textStyleSheet.GetStyle(hashCode);
			}
			return textStyle;
		}

		public static int GetStyleHashCode(ref uint[] text, int index, out int closeIndex)
		{
			int num = 0;
			closeIndex = 0;
			for (int i = index; i < text.Length; i++)
			{
				if (text[i] != 34)
				{
					if (text[i] == 62)
					{
						closeIndex = i;
						break;
					}
					num = ((num << 5) + num) ^ ToUpperASCIIFast((char)text[i]);
				}
			}
			return num;
		}

		public static int GetStyleHashCode(ref TextBackingContainer text, int index, out int closeIndex)
		{
			int num = 0;
			closeIndex = 0;
			for (int i = index; i < text.Capacity; i++)
			{
				if (text[i] != 34)
				{
					if (text[i] == 62)
					{
						closeIndex = i;
						break;
					}
					num = ((num << 5) + num) ^ ToUpperASCIIFast((char)text[i]);
				}
			}
			return num;
		}

		public static uint GetUTF16(uint[] text, int i)
		{
			uint num = 0u;
			num += HexToInt((char)text[i]) << 12;
			num += HexToInt((char)text[i + 1]) << 8;
			num += HexToInt((char)text[i + 2]) << 4;
			return num + HexToInt((char)text[i + 3]);
		}

		public static uint GetUTF16(TextBackingContainer text, int i)
		{
			uint num = 0u;
			num += HexToInt((char)text[i]) << 12;
			num += HexToInt((char)text[i + 1]) << 8;
			num += HexToInt((char)text[i + 2]) << 4;
			return num + HexToInt((char)text[i + 3]);
		}

		public static uint GetUTF32(uint[] text, int i)
		{
			uint num = 0u;
			num += HexToInt((char)text[i]) << 28;
			num += HexToInt((char)text[i + 1]) << 24;
			num += HexToInt((char)text[i + 2]) << 20;
			num += HexToInt((char)text[i + 3]) << 16;
			num += HexToInt((char)text[i + 4]) << 12;
			num += HexToInt((char)text[i + 5]) << 8;
			num += HexToInt((char)text[i + 6]) << 4;
			return num + HexToInt((char)text[i + 7]);
		}

		public static uint GetUTF32(TextBackingContainer text, int i)
		{
			uint num = 0u;
			num += HexToInt((char)text[i]) << 28;
			num += HexToInt((char)text[i + 1]) << 24;
			num += HexToInt((char)text[i + 2]) << 20;
			num += HexToInt((char)text[i + 3]) << 16;
			num += HexToInt((char)text[i + 4]) << 12;
			num += HexToInt((char)text[i + 5]) << 8;
			num += HexToInt((char)text[i + 6]) << 4;
			return num + HexToInt((char)text[i + 7]);
		}

		public static void FillCharacterVertexBuffers(int i, bool convertToLinearSpace, TextGenerationSettings generationSettings, TextInfo textInfo, bool needToRound)
		{
			int materialReferenceIndex = textInfo.textElementInfo[i].materialReferenceIndex;
			int vertexCount = textInfo.meshInfo[materialReferenceIndex].vertexCount;
			if (vertexCount >= textInfo.meshInfo[materialReferenceIndex].vertexBufferSize)
			{
				textInfo.meshInfo[materialReferenceIndex].ResizeMeshInfo(Mathf.NextPowerOfTwo((vertexCount + 4) / 4), generationSettings.isIMGUI);
			}
			if (textInfo.meshInfo[materialReferenceIndex].vertexData.Length >= vertexCount + 4)
			{
				TextElementInfo[] textElementInfo = textInfo.textElementInfo;
				textInfo.textElementInfo[i].vertexIndex = vertexCount;
				Vector3 vector = default(Vector3);
				vector.x = 0f;
				vector.y = generationSettings.screenRect.height;
				if (needToRound)
				{
					vector.y = Mathf.Round(vector.y);
				}
				vector.z = 0f;
				Vector3 position = textElementInfo[i].vertexBottomLeft.position;
				position.y *= -1f;
				textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].position = position + vector;
				position = textElementInfo[i].vertexTopLeft.position;
				position.y *= -1f;
				textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].position = position + vector;
				position = textElementInfo[i].vertexTopRight.position;
				position.y *= -1f;
				textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].position = position + vector;
				position = textElementInfo[i].vertexBottomRight.position;
				position.y *= -1f;
				textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].position = position + vector;
				textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].uv0 = textElementInfo[i].vertexBottomLeft.uv;
				textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].uv0 = textElementInfo[i].vertexTopLeft.uv;
				textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].uv0 = textElementInfo[i].vertexTopRight.uv;
				textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].uv0 = textElementInfo[i].vertexBottomRight.uv;
				textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].uv2 = textElementInfo[i].vertexBottomLeft.uv2;
				textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].uv2 = textElementInfo[i].vertexTopLeft.uv2;
				textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].uv2 = textElementInfo[i].vertexTopRight.uv2;
				textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].uv2 = textElementInfo[i].vertexBottomRight.uv2;
				textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexBottomLeft.color) : textElementInfo[i].vertexBottomLeft.color);
				textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexTopLeft.color) : textElementInfo[i].vertexTopLeft.color);
				textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexTopRight.color) : textElementInfo[i].vertexTopRight.color);
				textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexBottomRight.color) : textElementInfo[i].vertexBottomRight.color);
				textInfo.meshInfo[materialReferenceIndex].vertexCount = vertexCount + 4;
			}
		}

		public static void FillSpriteVertexBuffers(int i, bool convertToLinearSpace, TextGenerationSettings generationSettings, TextInfo textInfo)
		{
			int materialReferenceIndex = textInfo.textElementInfo[i].materialReferenceIndex;
			int vertexCount = textInfo.meshInfo[materialReferenceIndex].vertexCount;
			textInfo.meshInfo[materialReferenceIndex].applySDF = false;
			TextElementInfo[] textElementInfo = textInfo.textElementInfo;
			textInfo.textElementInfo[i].vertexIndex = vertexCount;
			Vector3 vector = default(Vector3);
			vector.x = 0f;
			vector.y = generationSettings.screenRect.height;
			vector.z = 0f;
			Vector3 position = textElementInfo[i].vertexBottomLeft.position;
			position.y *= -1f;
			textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].position = position + vector;
			position = textElementInfo[i].vertexTopLeft.position;
			position.y *= -1f;
			textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].position = position + vector;
			position = textElementInfo[i].vertexTopRight.position;
			position.y *= -1f;
			textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].position = position + vector;
			position = textElementInfo[i].vertexBottomRight.position;
			position.y *= -1f;
			textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].position = position + vector;
			textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].uv0 = textElementInfo[i].vertexBottomLeft.uv;
			textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].uv0 = textElementInfo[i].vertexTopLeft.uv;
			textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].uv0 = textElementInfo[i].vertexTopRight.uv;
			textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].uv0 = textElementInfo[i].vertexBottomRight.uv;
			textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].uv2 = textElementInfo[i].vertexBottomLeft.uv2;
			textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].uv2 = textElementInfo[i].vertexTopLeft.uv2;
			textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].uv2 = textElementInfo[i].vertexTopRight.uv2;
			textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].uv2 = textElementInfo[i].vertexBottomRight.uv2;
			textInfo.meshInfo[materialReferenceIndex].vertexData[vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexBottomLeft.color) : textElementInfo[i].vertexBottomLeft.color);
			textInfo.meshInfo[materialReferenceIndex].vertexData[1 + vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexTopLeft.color) : textElementInfo[i].vertexTopLeft.color);
			textInfo.meshInfo[materialReferenceIndex].vertexData[2 + vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexTopRight.color) : textElementInfo[i].vertexTopRight.color);
			textInfo.meshInfo[materialReferenceIndex].vertexData[3 + vertexCount].color = (convertToLinearSpace ? GammaToLinear(textElementInfo[i].vertexBottomRight.color) : textElementInfo[i].vertexBottomRight.color);
			textInfo.meshInfo[materialReferenceIndex].vertexCount = vertexCount + 4;
		}

		public static void AdjustLineOffset(int startIndex, int endIndex, float offset, TextInfo textInfo)
		{
			Vector3 vector = new Vector3(0f, offset, 0f);
			for (int i = startIndex; i <= endIndex; i++)
			{
				textInfo.textElementInfo[i].bottomLeft -= vector;
				textInfo.textElementInfo[i].topLeft -= vector;
				textInfo.textElementInfo[i].topRight -= vector;
				textInfo.textElementInfo[i].bottomRight -= vector;
				textInfo.textElementInfo[i].ascender -= vector.y;
				textInfo.textElementInfo[i].baseLine -= vector.y;
				textInfo.textElementInfo[i].descender -= vector.y;
				if (textInfo.textElementInfo[i].isVisible)
				{
					textInfo.textElementInfo[i].vertexBottomLeft.position -= vector;
					textInfo.textElementInfo[i].vertexTopLeft.position -= vector;
					textInfo.textElementInfo[i].vertexTopRight.position -= vector;
					textInfo.textElementInfo[i].vertexBottomRight.position -= vector;
				}
			}
		}

		public static void ResizeLineExtents(int size, TextInfo textInfo)
		{
			size = ((size > 1024) ? (size + 256) : Mathf.NextPowerOfTwo(size + 1));
			LineInfo[] array = new LineInfo[size];
			for (int i = 0; i < size; i++)
			{
				if (i < textInfo.lineInfo.Length)
				{
					array[i] = textInfo.lineInfo[i];
					continue;
				}
				array[i].lineExtents.min = largePositiveVector2;
				array[i].lineExtents.max = largeNegativeVector2;
				array[i].ascender = -32767f;
				array[i].descender = 32767f;
			}
			textInfo.lineInfo = array;
		}

		public static FontStyles LegacyStyleToNewStyle(FontStyle fontStyle)
		{
			return fontStyle switch
			{
				FontStyle.Bold => FontStyles.Bold, 
				FontStyle.Italic => FontStyles.Italic, 
				FontStyle.BoldAndItalic => FontStyles.Bold | FontStyles.Italic, 
				_ => FontStyles.Normal, 
			};
		}

		public static TextAlignment LegacyAlignmentToNewAlignment(TextAnchor anchor)
		{
			return anchor switch
			{
				TextAnchor.UpperLeft => TextAlignment.TopLeft, 
				TextAnchor.UpperCenter => TextAlignment.TopCenter, 
				TextAnchor.UpperRight => TextAlignment.TopRight, 
				TextAnchor.MiddleLeft => TextAlignment.MiddleLeft, 
				TextAnchor.MiddleCenter => TextAlignment.MiddleCenter, 
				TextAnchor.MiddleRight => TextAlignment.MiddleRight, 
				TextAnchor.LowerLeft => TextAlignment.BottomLeft, 
				TextAnchor.LowerCenter => TextAlignment.BottomCenter, 
				TextAnchor.LowerRight => TextAlignment.BottomRight, 
				_ => TextAlignment.TopLeft, 
			};
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static UnityEngine.TextCore.HorizontalAlignment GetHorizontalAlignment(TextAnchor anchor)
		{
			switch (anchor)
			{
			case TextAnchor.UpperLeft:
			case TextAnchor.MiddleLeft:
			case TextAnchor.LowerLeft:
				return UnityEngine.TextCore.HorizontalAlignment.Left;
			case TextAnchor.UpperCenter:
			case TextAnchor.MiddleCenter:
			case TextAnchor.LowerCenter:
				return UnityEngine.TextCore.HorizontalAlignment.Center;
			case TextAnchor.UpperRight:
			case TextAnchor.MiddleRight:
			case TextAnchor.LowerRight:
				return UnityEngine.TextCore.HorizontalAlignment.Right;
			default:
				return UnityEngine.TextCore.HorizontalAlignment.Left;
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static UnityEngine.TextCore.VerticalAlignment GetVerticalAlignment(TextAnchor anchor)
		{
			switch (anchor)
			{
			case TextAnchor.LowerLeft:
			case TextAnchor.LowerCenter:
			case TextAnchor.LowerRight:
				return UnityEngine.TextCore.VerticalAlignment.Bottom;
			case TextAnchor.MiddleLeft:
			case TextAnchor.MiddleCenter:
			case TextAnchor.MiddleRight:
				return UnityEngine.TextCore.VerticalAlignment.Middle;
			case TextAnchor.UpperLeft:
			case TextAnchor.UpperCenter:
			case TextAnchor.UpperRight:
				return UnityEngine.TextCore.VerticalAlignment.Top;
			default:
				return UnityEngine.TextCore.VerticalAlignment.Top;
			}
		}

		public static uint ConvertToUTF32(uint highSurrogate, uint lowSurrogate)
		{
			return (highSurrogate - 55296) * 1024 + (lowSurrogate - 56320 + 65536);
		}

		public static int GetMarkupTagHashCode(TextBackingContainer styleDefinition, int readIndex)
		{
			int num = 0;
			int num2 = readIndex + 16;
			int capacity = styleDefinition.Capacity;
			while (readIndex < num2 && readIndex < capacity)
			{
				uint num3 = styleDefinition[readIndex];
				if (num3 == 62 || num3 == 61 || num3 == 32)
				{
					return num;
				}
				num = ((num << 5) + num) ^ (int)ToUpperASCIIFast(num3);
				readIndex++;
			}
			return num;
		}

		public static int GetMarkupTagHashCode(uint[] styleDefinition, int readIndex)
		{
			int num = 0;
			int num2 = readIndex + 16;
			int num3 = styleDefinition.Length;
			while (readIndex < num2 && readIndex < num3)
			{
				uint num4 = styleDefinition[readIndex];
				if (num4 == 62 || num4 == 61 || num4 == 32)
				{
					return num;
				}
				num = ((num << 5) + num) ^ (int)ToUpperASCIIFast(num4);
				readIndex++;
			}
			return num;
		}

		public static char ToUpperASCIIFast(char c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[c];
		}

		public static uint ToUpperASCIIFast(uint c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[(int)c];
		}

		public static char ToUpperFast(char c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[c];
		}

		public static int GetAttributeParameters(char[] chars, int startIndex, int length, ref float[] parameters)
		{
			int lastIndex = startIndex;
			int num = 0;
			while (lastIndex < startIndex + length)
			{
				parameters[num] = ConvertToFloat(chars, startIndex, length, out lastIndex);
				length -= lastIndex - startIndex + 1;
				startIndex = lastIndex + 1;
				num++;
			}
			return num;
		}

		public static bool IsBitmapRendering(GlyphRenderMode glyphRenderMode)
		{
			return glyphRenderMode == GlyphRenderMode.RASTER || glyphRenderMode == GlyphRenderMode.RASTER_HINTED || glyphRenderMode == GlyphRenderMode.SMOOTH || glyphRenderMode == GlyphRenderMode.SMOOTH_HINTED;
		}

		public static bool IsBaseGlyph(uint c)
		{
			return (c < 768 || c > 879) && (c < 6832 || c > 6911) && (c < 7616 || c > 7679) && (c < 8400 || c > 8447) && (c < 65056 || c > 65071) && c != 3633 && (c < 3636 || c > 3642) && (c < 3655 || c > 3662) && (c < 1425 || c > 1469) && c != 1471 && (c < 1473 || c > 1474) && (c < 1476 || c > 1477) && c != 1479 && (c < 1552 || c > 1562) && (c < 1611 || c > 1631) && c != 1648 && (c < 1750 || c > 1756) && (c < 1759 || c > 1764) && (c < 1767 || c > 1768) && (c < 1770 || c > 1773) && (c < 2259 || c > 2273) && (c < 2275 || c > 2303) && (c < 64434 || c > 64449);
		}

		public static Color MinAlpha(this Color c1, Color c2)
		{
			float a = ((c1.a < c2.a) ? c1.a : c2.a);
			return new Color(c1.r, c1.g, c1.b, a);
		}

		internal static Color32 GammaToLinear(Color32 c)
		{
			return new Color32(GammaToLinear(c.r), GammaToLinear(c.g), GammaToLinear(c.b), c.a);
		}

		private static byte GammaToLinear(byte value)
		{
			float num = (float)(int)value / 255f;
			if (num <= 0.04045f)
			{
				return (byte)(num / 12.92f * 255f);
			}
			if (num < 1f)
			{
				return (byte)(Mathf.Pow((num + 0.055f) / 1.055f, 2.4f) * 255f);
			}
			if (num == 1f)
			{
				return byte.MaxValue;
			}
			return (byte)(Mathf.Pow(num, 2.2f) * 255f);
		}

		public static bool IsValidUTF16(TextBackingContainer text, int index)
		{
			for (int i = 0; i < 4; i++)
			{
				uint num = text[index + i];
				if ((num < 48 || num > 57) && (num < 97 || num > 102) && (num < 65 || num > 70))
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsValidUTF32(TextBackingContainer text, int index)
		{
			for (int i = 0; i < 8; i++)
			{
				uint num = text[index + i];
				if ((num < 48 || num > 57) && (num < 97 || num > 102) && (num < 65 || num > 70))
				{
					return false;
				}
			}
			return true;
		}

		internal static bool IsEmoji(uint c)
		{
			return k_EmojiLookup.Contains(c);
		}

		internal static bool IsEmojiPresentationForm(uint c)
		{
			return k_EmojiPresentationFormLookup.Contains(c);
		}

		internal static bool IsHangul(uint c)
		{
			return (c >= 4352 && c <= 4607) || (c >= 43360 && c <= 43391) || (c >= 55216 && c <= 55295) || (c >= 12592 && c <= 12687) || (c >= 65440 && c <= 65500) || (c >= 44032 && c <= 55215);
		}

		internal static bool IsCJK(uint c)
		{
			return (c >= 12288 && c <= 12351) || (c >= 94176 && c <= 5887) || (c >= 12544 && c <= 12591) || (c >= 12704 && c <= 12735) || (c >= 19968 && c <= 40959) || (c >= 13312 && c <= 19903) || (c >= 131072 && c <= 173791) || (c >= 173824 && c <= 177983) || (c >= 177984 && c <= 178207) || (c >= 178208 && c <= 183983) || (c >= 183984 && c <= 191456) || (c >= 196608 && c <= 201546) || (c >= 63744 && c <= 64255) || (c >= 194560 && c <= 195103) || (c >= 12032 && c <= 12255) || (c >= 11904 && c <= 12031) || (c >= 12736 && c <= 12783) || (c >= 12272 && c <= 12287) || (c >= 12352 && c <= 12447) || (c >= 110848 && c <= 110895) || (c >= 110576 && c <= 110591) || (c >= 110592 && c <= 110847) || (c >= 110896 && c <= 110959) || (c >= 12688 && c <= 12703) || (c >= 12448 && c <= 12543) || (c >= 12784 && c <= 12799) || (c >= 65381 && c <= 65439);
		}
	}
	[StructLayout(LayoutKind.Sequential)]
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule", "Unity.UIElements.PlayModeTests" })]
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextLib.h")]
	internal class TextLib
	{
		internal static class BindingsMarshaller
		{
			public static IntPtr ConvertToNative(TextLib textLib)
			{
				return textLib.m_Ptr;
			}
		}

		public const int k_unconstrainedScreenSize = -1;

		private readonly IntPtr m_Ptr;

		public static Func<UnityEngine.TextAsset> GetICUAssetEditorDelegate;

		public TextLib(byte[] icuData)
		{
			m_Ptr = GetInstance(icuData);
		}

		private unsafe static IntPtr GetInstance(byte[] icuData)
		{
			Span<byte> span = new Span<byte>(icuData);
			IntPtr instance_Injected;
			fixed (byte* begin = span)
			{
				ManagedSpanWrapper icuData2 = new ManagedSpanWrapper(begin, span.Length);
				instance_Injected = GetInstance_Injected(ref icuData2);
			}
			return instance_Injected;
		}

		public NativeTextInfo GenerateText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo)
		{
			Debug.Assert((settings.fontStyle & FontStyles.Bold) == 0);
			return GenerateTextInternal(settings, textGenerationInfo);
		}

		public void ProcessMeshInfos(NativeTextInfo textInfo, NativeTextGenerationSettings settings)
		{
			Span<ATGMeshInfo> span = MemoryExtensions.AsSpan(textInfo.meshInfos);
			for (int i = 0; i < span.Length; i++)
			{
				ref ATGMeshInfo reference = ref span[i];
				FontAsset fontAsset = (reference.fontAsset = FontAsset.GetFontAssetByID(reference.fontAssetId));
				reference.textElementInfoIndicesByAtlas = new List<List<int>>(fontAsset.atlasTextures.Length);
				for (int j = 0; j < fontAsset.atlasTextures.Length; j++)
				{
					reference.textElementInfoIndicesByAtlas.Add(new List<int>());
				}
				float num = (float)settings.vertexPadding / 64f;
				float num2 = 1f / (float)fontAsset.atlasWidth;
				float num3 = 1f / (float)fontAsset.atlasHeight;
				bool hasMultipleColors = false;
				Color? color = null;
				for (int k = 0; k < reference.textElementInfos.Length; k++)
				{
					ref NativeTextElementInfo reference2 = ref reference.textElementInfos[k];
					int glyphID = reference2.glyphID;
					if (fontAsset.TryAddGlyphInternal((uint)glyphID, out var glyph))
					{
						Color32 color2 = reference2.topLeft.color;
						if (color.HasValue && color.Value != color2)
						{
							hasMultipleColors = true;
						}
						color = color2;
						GlyphRect glyphRect = glyph.glyphRect;
						while (reference.textElementInfoIndicesByAtlas.Count < fontAsset.atlasTextures.Length)
						{
							reference.textElementInfoIndicesByAtlas.Add(new List<int>());
						}
						reference.textElementInfoIndicesByAtlas[glyph.atlasIndex].Add(k);
						if ((reference2.bottomLeft.uv0.x == 0f || reference2.bottomLeft.uv0.x == 1f) && (reference2.bottomLeft.uv0.y == 0f || reference2.bottomLeft.uv0.y == 1f) && (reference2.topLeft.uv0.x == 0f || reference2.topLeft.uv0.x == 1f) && (reference2.topLeft.uv0.y == 0f || reference2.topLeft.uv0.y == 1f) && (reference2.topRight.uv0.x == 0f || reference2.topRight.uv0.x == 1f) && (reference2.topRight.uv0.y == 0f || reference2.topRight.uv0.y == 1f) && (reference2.bottomRight.uv0.x == 0f || reference2.bottomRight.uv0.x == 1f) && (reference2.bottomRight.uv0.y == 0f || reference2.bottomRight.uv0.y == 1f))
						{
							float x = ((float)glyphRect.x - num) * num2;
							float y = ((float)glyphRect.y - num) * num3;
							float x2 = ((float)(glyphRect.x + glyphRect.width) + num) * num2;
							float y2 = ((float)(glyphRect.y + glyphRect.height) + num) * num3;
							reference2.bottomLeft.uv0 = new Vector2(x, y);
							reference2.topLeft.uv0 = new Vector2(x, y2);
							reference2.topRight.uv0 = new Vector2(x2, y2);
							reference2.bottomRight.uv0 = new Vector2(x2, y);
						}
						else
						{
							Vector2 vector = new Vector2(((float)glyphRect.x - num) * num2, ((float)glyphRect.y - num) * num3);
							Vector2 vector2 = new Vector2(vector.x, ((float)(glyphRect.y + glyphRect.height) + num) * num3);
							Vector2 vector3 = new Vector2(((float)(glyphRect.x + glyphRect.width) + num) * num2, vector2.y);
							reference2.bottomLeft.uv0 = vector3 * reference2.bottomLeft.uv0 + vector * (Vector2.one - reference2.bottomLeft.uv0);
							reference2.topLeft.uv0 = vector3 * reference2.topLeft.uv0 + vector * (Vector2.one - reference2.topLeft.uv0);
							reference2.topRight.uv0 = vector3 * reference2.topRight.uv0 + vector * (Vector2.one - reference2.topRight.uv0);
							reference2.bottomRight.uv0 = vector3 * reference2.bottomRight.uv0 + vector * (Vector2.one - reference2.bottomRight.uv0);
						}
					}
				}
				reference.hasMultipleColors = hasMultipleColors;
			}
		}

		[NativeMethod(Name = "TextLib::GenerateTextMesh", IsThreadSafe = true)]
		private NativeTextInfo GenerateTextInternal(NativeTextGenerationSettings settings, IntPtr textGenerationInfo)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			GenerateTextInternal_Injected(intPtr, ref settings, textGenerationInfo, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TextLib::MeasureText")]
		public Vector2 MeasureText(NativeTextGenerationSettings settings, IntPtr textGenerationInfo)
		{
			IntPtr intPtr = BindingsMarshaller.ConvertToNative(this);
			if (intPtr == (IntPtr)0)
			{
				ThrowHelper.ThrowNullReferenceException(this);
			}
			MeasureText_Injected(intPtr, ref settings, textGenerationInfo, out var ret);
			return ret;
		}

		[NativeMethod(Name = "TextLib::FindIntersectingLink")]
		public static int FindIntersectingLink(Vector2 point, IntPtr textGenerationInfo)
		{
			return FindIntersectingLink_Injected(ref point, textGenerationInfo);
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr GetInstance_Injected(ref ManagedSpanWrapper icuData);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GenerateTextInternal_Injected(IntPtr _unity_self, [In] ref NativeTextGenerationSettings settings, IntPtr textGenerationInfo, out NativeTextInfo ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void MeasureText_Injected(IntPtr _unity_self, [In] ref NativeTextGenerationSettings settings, IntPtr textGenerationInfo, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int FindIntersectingLink_Injected([In] ref Vector2 point, IntPtr textGenerationInfo);
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal static class TextGenerationInfo
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		public static extern IntPtr Create();

		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void Destroy(IntPtr ptr);

		[ThreadSafe]
		public static TextRenderingIndices GetTextRenderingIndices(IntPtr ptr, int glyphIndex)
		{
			GetTextRenderingIndices_Injected(ptr, glyphIndex, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[ThreadSafe]
		public static extern int GetGlyphCount(IntPtr ptr);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetTextRenderingIndices_Injected(IntPtr ptr, int glyphIndex, out TextRenderingIndices ret);
	}
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextSelectionService.h")]
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule", "Unity.UIElements.PlayModeTests" })]
	internal class TextSelectionService
	{
		[NativeMethod(Name = "TextSelectionService::Substring")]
		internal static string Substring(IntPtr textGenerationInfo, int startIndex, int endIndex)
		{
			ManagedSpanWrapper ret = default(ManagedSpanWrapper);
			string stringAndDispose;
			try
			{
				Substring_Injected(textGenerationInfo, startIndex, endIndex, out ret);
			}
			finally
			{
				stringAndDispose = OutStringMarshaller.GetStringAndDispose(ret);
			}
			return stringAndDispose;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::SelectCurrentWord")]
		internal static extern void SelectCurrentWord(IntPtr textGenerationInfo, int currentIndex, ref int startIndex, ref int endIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::PreviousCodePointIndex")]
		internal static extern int PreviousCodePointIndex(IntPtr textGenerationInfo, int currentIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::NextCodePointIndex")]
		internal static extern int NextCodePointIndex(IntPtr textGenerationInfo, int currentIndex);

		[NativeMethod(Name = "TextSelectionService::GetCursorLogicalIndexFromPosition")]
		internal static int GetCursorLogicalIndexFromPosition(IntPtr textGenerationInfo, Vector2 position)
		{
			return GetCursorLogicalIndexFromPosition_Injected(textGenerationInfo, ref position);
		}

		[NativeMethod(Name = "TextSelectionService::GetCursorPositionFromLogicalIndex")]
		internal static Vector2 GetCursorPositionFromLogicalIndex(IntPtr textGenerationInfo, int logicalIndex)
		{
			GetCursorPositionFromLogicalIndex_Injected(textGenerationInfo, logicalIndex, out var ret);
			return ret;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::LineUpCharacterPosition")]
		internal static extern int LineUpCharacterPosition(IntPtr textGenerationInfo, int originalPos);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::LineDownCharacterPosition")]
		internal static extern int LineDownCharacterPosition(IntPtr textGenerationInfo, int originalPos);

		[NativeMethod(Name = "TextSelectionService::GetHighlightRectangles")]
		internal static Rect[] GetHighlightRectangles(IntPtr textGenerationInfo, int cursorIndex, int selectIndex)
		{
			BlittableArrayWrapper ret = default(BlittableArrayWrapper);
			Rect[] result;
			try
			{
				GetHighlightRectangles_Injected(textGenerationInfo, cursorIndex, selectIndex, out ret);
			}
			finally
			{
				Rect[] array = default(Rect[]);
				ret.Unmarshal(ref array);
				result = array;
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetCharacterHeightFromIndex")]
		internal static extern float GetCharacterHeightFromIndex(IntPtr textGenerationInfo, int index);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetStartOfNextWord")]
		internal static extern int GetStartOfNextWord(IntPtr textGenerationInfo, int currentIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetEndOfPreviousWord")]
		internal static extern int GetEndOfPreviousWord(IntPtr textGenerationInfo, int currentIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetFirstCharacterIndexOnLine")]
		internal static extern int GetFirstCharacterIndexOnLine(IntPtr textGenerationInfo, int currentIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetLastCharacterIndexOnLine")]
		internal static extern int GetLastCharacterIndexOnLine(IntPtr textGenerationInfo, int currentIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetLineHeight")]
		internal static extern float GetLineHeight(IntPtr textGenerationInfo, int lineIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::GetLineNumberFromLogicalIndex")]
		internal static extern int GetLineNumber(IntPtr textGenerationInfo, int logicalIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::SelectToPreviousParagraph")]
		internal static extern void SelectToPreviousParagraph(IntPtr textGenerationInfo, ref int cursorIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::SelectToStartOfParagraph")]
		internal static extern void SelectToStartOfParagraph(IntPtr textGenerationInfo, ref int cursorIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::SelectToEndOfParagraph")]
		internal static extern void SelectToEndOfParagraph(IntPtr textGenerationInfo, ref int cursorIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::SelectToNextParagraph")]
		internal static extern void SelectToNextParagraph(IntPtr textGenerationInfo, ref int cursorIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		[NativeMethod(Name = "TextSelectionService::SelectCurrentParagraph")]
		internal static extern void SelectCurrentParagraph(IntPtr textGenerationInfo, ref int cursorIndex, ref int selectIndex);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Substring_Injected(IntPtr textGenerationInfo, int startIndex, int endIndex, out ManagedSpanWrapper ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetCursorLogicalIndexFromPosition_Injected(IntPtr textGenerationInfo, [In] ref Vector2 position);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetCursorPositionFromLogicalIndex_Injected(IntPtr textGenerationInfo, int logicalIndex, out Vector2 ret);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetHighlightRectangles_Injected(IntPtr textGenerationInfo, int cursorIndex, int selectIndex, out BlittableArrayWrapper ret);
	}
	[DebuggerDisplay("{settings.text}")]
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal class TextHandle
	{
		internal readonly record struct GlyphMetricsForOverlay
		{
			public readonly bool isVisible;

			public readonly float origin;

			public readonly float xAdvance;

			public readonly float ascentline;

			public readonly float baseline;

			public readonly float descentline;

			public readonly Vector3 topLeft;

			public readonly Vector3 bottomLeft;

			public readonly Vector3 topRight;

			public readonly Vector3 bottomRight;

			public readonly float scale;

			public readonly int lineNumber;

			public readonly float fontCapLine;

			public readonly float fontMeanLine;

			public GlyphMetricsForOverlay(ref TextElementInfo textElementInfo, float pixelPerPoint)
			{
				float num = 1f / pixelPerPoint;
				isVisible = textElementInfo.isVisible;
				origin = textElementInfo.origin * num;
				xAdvance = textElementInfo.xAdvance * num;
				ascentline = textElementInfo.ascender * num;
				baseline = textElementInfo.baseLine * num;
				descentline = textElementInfo.descender * num;
				topLeft = textElementInfo.topLeft * num;
				bottomLeft = textElementInfo.bottomLeft * num;
				topRight = textElementInfo.topRight * num;
				bottomRight = textElementInfo.bottomRight * num;
				scale = textElementInfo.scale;
				lineNumber = textElementInfo.lineNumber;
				fontCapLine = textElementInfo.fontAsset.faceInfo.capLine * num;
				fontMeanLine = textElementInfo.fontAsset.faceInfo.meanLine * num;
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static TextHandleTemporaryCache s_TemporaryCache = new TextHandleTemporaryCache();

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static TextHandlePermanentCache s_PermanentCache = new TextHandlePermanentCache();

		private static TextGenerationSettings[] s_Settings;

		private static TextGenerator[] s_Generators;

		private static TextInfo[] s_TextInfosCommon;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal NativeTextGenerationSettings nativeSettings = NativeTextGenerationSettings.Default;

		protected Vector2 pixelPreferedSize;

		private Rect m_ScreenRect;

		private float m_LineHeightDefault;

		private bool m_IsPlaceholder;

		protected bool m_IsElided;

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal IntPtr textGenerationInfo = IntPtr.Zero;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal int m_PreviousGenerationSettingsHash;

		protected bool isDirty;

		internal static TextGenerationSettings[] settingsArray
		{
			get
			{
				if (s_Settings == null)
				{
					InitArray(ref s_Settings, () => new TextGenerationSettings());
				}
				return s_Settings;
			}
		}

		internal static TextGenerator[] generators
		{
			get
			{
				if (s_Generators == null)
				{
					InitArray(ref s_Generators, () => new TextGenerator());
				}
				return s_Generators;
			}
		}

		internal static TextInfo[] textInfosCommon
		{
			get
			{
				if (s_TextInfosCommon == null)
				{
					InitArray(ref s_TextInfosCommon, () => new TextInfo());
				}
				return s_TextInfosCommon;
			}
		}

		internal static TextInfo textInfoCommon => textInfosCommon[JobsUtility.ThreadIndex];

		private static TextGenerator generator => generators[JobsUtility.ThreadIndex];

		internal static TextGenerationSettings settings
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
			get
			{
				return settingsArray[JobsUtility.ThreadIndex];
			}
		}

		internal Vector2 preferredSize
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
			get
			{
				return PixelsToPoints(pixelPreferedSize);
			}
		}

		internal LinkedListNode<TextInfo> TextInfoNode { get; set; }

		internal bool IsCachedPermanent { get; set; }

		internal bool IsCachedTemporary { get; set; }

		internal bool useAdvancedText
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
			get
			{
				return IsAdvancedTextEnabledForElement();
			}
		}

		internal int characterCount
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
			get
			{
				return useAdvancedText ? nativeSettings.text.Length : textInfo.characterCount;
			}
		}

		internal TextInfo textInfo
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
			get
			{
				if (TextInfoNode == null)
				{
					return textInfoCommon;
				}
				return TextInfoNode.Value;
			}
		}

		public virtual bool IsPlaceholder => m_IsPlaceholder;

		~TextHandle()
		{
			RemoveTextInfoFromTemporaryCache();
			RemoveTextInfoFromPermanentCache();
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static void InitThreadArrays()
		{
			if (s_Settings == null || s_Generators == null || s_TextInfosCommon == null)
			{
				InitArray(ref s_Settings, () => new TextGenerationSettings());
				InitArray(ref s_Generators, () => new TextGenerator());
				InitArray(ref s_TextInfosCommon, () => new TextInfo());
			}
		}

		private static void InitArray<T>(ref T[] array, Func<T> createInstance)
		{
			if (array == null)
			{
				array = new T[JobsUtility.ThreadIndexCount];
				for (int i = 0; i < JobsUtility.ThreadIndexCount; i++)
				{
					array[i] = createInstance();
				}
			}
		}

		protected float PointsToPixels(float point)
		{
			return point * GetPixelsPerPoint();
		}

		protected float PixelsToPoints(float pixel)
		{
			return pixel / GetPixelsPerPoint();
		}

		protected Vector2 PointsToPixels(Vector2 point)
		{
			return point * GetPixelsPerPoint();
		}

		protected Vector2 PixelsToPoints(Vector2 pixel)
		{
			return pixel / GetPixelsPerPoint();
		}

		protected virtual float GetPixelsPerPoint()
		{
			return 1f;
		}

		public virtual void AddToPermanentCacheAndGenerateMesh()
		{
			if (useAdvancedText)
			{
				throw new InvalidOperationException("Method is virtual and should be overriden in ATGTextHanle, the only valid handle for ATG");
			}
			s_PermanentCache.AddTextInfoToCache(this);
		}

		public void AddTextInfoToTemporaryCache(int hashCode)
		{
			if (!useAdvancedText)
			{
				s_TemporaryCache.AddTextInfoToCache(this, hashCode);
			}
		}

		public void RemoveTextInfoFromTemporaryCache()
		{
			s_TemporaryCache.RemoveTextInfoFromCache(this);
		}

		public void RemoveTextInfoFromPermanentCache()
		{
			if (textGenerationInfo != IntPtr.Zero)
			{
				TextGenerationInfo.Destroy(textGenerationInfo);
				textGenerationInfo = IntPtr.Zero;
			}
			else
			{
				s_PermanentCache.RemoveTextInfoFromCache(this);
			}
		}

		public static void UpdateCurrentFrame()
		{
			s_TemporaryCache.UpdateCurrentFrame();
		}

		internal bool IsTextInfoAllocated()
		{
			return textInfo != null;
		}

		public virtual void SetDirty()
		{
			isDirty = true;
		}

		public bool IsDirty(int hashCode)
		{
			if (m_PreviousGenerationSettingsHash == hashCode && !isDirty && (IsCachedTemporary || IsCachedPermanent))
			{
				return false;
			}
			return true;
		}

		public float ComputeTextWidth(TextGenerationSettings tgs)
		{
			UpdatePreferredValues(tgs);
			return preferredSize.x;
		}

		public float ComputeTextHeight(TextGenerationSettings tgs)
		{
			UpdatePreferredValues(tgs);
			return preferredSize.y;
		}

		protected void UpdatePreferredValues(TextGenerationSettings tgs)
		{
			pixelPreferedSize = generator.GetPreferredValues(tgs, textInfoCommon);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal TextInfo Update()
		{
			return UpdateWithHash(settings.GetHashCode());
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal TextInfo UpdateWithHash(int hashCode)
		{
			m_ScreenRect = settings.screenRect;
			m_LineHeightDefault = GetLineHeightDefault(settings);
			m_IsPlaceholder = settings.isPlaceholder;
			if (!IsDirty(hashCode))
			{
				return textInfo;
			}
			if (settings.fontAsset == null)
			{
				Debug.LogWarning("Can't Generate Mesh, No Font Asset has been assigned.");
				return textInfo;
			}
			generator.GenerateText(settings, textInfo);
			m_PreviousGenerationSettingsHash = hashCode;
			isDirty = false;
			m_IsElided = generator.isTextTruncated;
			return textInfo;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool PrepareFontAsset()
		{
			if (settings.fontAsset == null)
			{
				return false;
			}
			if (!IsDirty(settings.GetHashCode()))
			{
				return true;
			}
			return generator.PrepareFontAsset(settings);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule" })]
		internal void UpdatePreferredSize()
		{
			if (textInfo.characterCount > 0)
			{
				float num = float.MinValue;
				float num2 = textInfo.textElementInfo[textInfo.characterCount - 1].descender;
				float num3 = 0f;
				float num4 = 0f;
				for (int i = 0; i < textInfo.lineCount; i++)
				{
					LineInfo lineInfo = textInfo.lineInfo[i];
					num = Mathf.Max(num, textInfo.textElementInfo[lineInfo.firstVisibleCharacterIndex].ascender);
					num2 = Mathf.Min(num2, textInfo.textElementInfo[lineInfo.firstVisibleCharacterIndex].descender);
					num3 = (settings.isIMGUI ? Mathf.Max(num3, lineInfo.length) : Mathf.Max(num3, lineInfo.lineExtents.max.x - lineInfo.lineExtents.min.x));
				}
				num4 = num - num2;
				num3 = (float)(int)(num3 * 100f + 1f) / 100f;
				num4 = (float)(int)(num4 * 100f + 1f) / 100f;
				pixelPreferedSize = new Vector2(num3, num4);
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static float ConvertPixelUnitsToTextCoreRelativeUnits(float fontSize, FontAsset fontAsset)
		{
			float num = 1f / (float)fontAsset.atlasPadding;
			float num2 = fontAsset.faceInfo.pointSize / fontSize;
			return num * num2;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule" })]
		internal static float GetLineHeightDefault(TextGenerationSettings settings)
		{
			if (settings != null && settings.fontAsset != null)
			{
				return settings.fontAsset.faceInfo.lineHeight / settings.fontAsset.faceInfo.pointSize * (float)settings.fontSize;
			}
			return 0f;
		}

		public virtual Vector2 GetCursorPositionFromStringIndexUsingCharacterHeight(int index, bool inverseYAxis = true)
		{
			AddToPermanentCacheAndGenerateMesh();
			Vector2 pixel = (useAdvancedText ? TextSelectionService.GetCursorPositionFromLogicalIndex(textGenerationInfo, index) : textInfo.GetCursorPositionFromStringIndexUsingCharacterHeight(index, m_ScreenRect, m_LineHeightDefault, inverseYAxis));
			return PixelsToPoints(pixel);
		}

		public Vector2 GetCursorPositionFromStringIndexUsingLineHeight(int index, bool useXAdvance = false, bool inverseYAxis = true)
		{
			AddToPermanentCacheAndGenerateMesh();
			Vector2 pixel = (useAdvancedText ? TextSelectionService.GetCursorPositionFromLogicalIndex(textGenerationInfo, index) : textInfo.GetCursorPositionFromStringIndexUsingLineHeight(index, m_ScreenRect, m_LineHeightDefault, useXAdvance, inverseYAxis));
			return PixelsToPoints(pixel);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal Rect[] GetHighlightRectangles(int cursorIndex, int selectIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use GetHighlightRectangles while using Standard Text");
				return new Rect[0];
			}
			Rect[] highlightRectangles = TextSelectionService.GetHighlightRectangles(textGenerationInfo, cursorIndex, selectIndex);
			float num = 1f / GetPixelsPerPoint();
			for (int i = 0; i < highlightRectangles.Length; i++)
			{
				highlightRectangles[i].x *= num;
				highlightRectangles[i].y *= num;
				highlightRectangles[i].width *= num;
				highlightRectangles[i].height *= num;
			}
			return highlightRectangles;
		}

		public int GetCursorIndexFromPosition(Vector2 position, bool inverseYAxis = true)
		{
			position = PointsToPixels(position);
			return useAdvancedText ? TextSelectionService.GetCursorLogicalIndexFromPosition(textGenerationInfo, position) : textInfo.GetCursorIndexFromPosition(position, m_ScreenRect, inverseYAxis);
		}

		public int LineDownCharacterPosition(int originalLogicalPos)
		{
			return useAdvancedText ? TextSelectionService.LineDownCharacterPosition(textGenerationInfo, originalLogicalPos) : textInfo.LineDownCharacterPosition(originalLogicalPos);
		}

		public int LineUpCharacterPosition(int originalLogicalPos)
		{
			return useAdvancedText ? TextSelectionService.LineUpCharacterPosition(textGenerationInfo, originalLogicalPos) : textInfo.LineUpCharacterPosition(originalLogicalPos);
		}

		public int FindWordIndex(int cursorIndex)
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use FindWordIndex while using Advanced Text");
				return 0;
			}
			return textInfo.FindWordIndex(cursorIndex);
		}

		public int FindNearestLine(Vector2 position)
		{
			position = PointsToPixels(position);
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use FindNearestLine while using Advanced Text");
				return 0;
			}
			return textInfo.FindNearestLine(position);
		}

		public int FindNearestCharacterOnLine(Vector2 position, int line, bool visibleOnly)
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use FindNearestCharacterOnLine while using Advanced Text");
				return 0;
			}
			position = PointsToPixels(position);
			return textInfo.FindNearestCharacterOnLine(position, line, visibleOnly);
		}

		public int FindIntersectingLink(Vector3 position, bool inverseYAxis = true)
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use FindIntersectingLink while using Advanced Text");
				return 0;
			}
			position = PointsToPixels(position);
			return textInfo.FindIntersectingLink(position, m_ScreenRect, inverseYAxis);
		}

		public int GetCorrespondingStringIndex(int index)
		{
			return useAdvancedText ? index : textInfo.GetCorrespondingStringIndex(index);
		}

		public int GetCorrespondingCodePointIndex(int stringIndex)
		{
			return useAdvancedText ? stringIndex : textInfo.GetCorrespondingCodePointIndex(stringIndex);
		}

		public LineInfo GetLineInfoFromCharacterIndex(int index)
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use GetLineInfoFromCharacterIndex while using Advanced Text");
				return default(LineInfo);
			}
			return textInfo.GetLineInfoFromCharacterIndex(index);
		}

		public int GetLineNumber(int index)
		{
			return useAdvancedText ? TextSelectionService.GetLineNumber(textGenerationInfo, index) : textInfo.GetLineNumber(index);
		}

		public float GetLineHeight(int lineNumber)
		{
			return PixelsToPoints(useAdvancedText ? TextSelectionService.GetLineHeight(textGenerationInfo, lineNumber) : textInfo.GetLineHeight(lineNumber));
		}

		public float GetLineHeightFromCharacterIndex(int index)
		{
			return PixelsToPoints(useAdvancedText ? TextSelectionService.GetCharacterHeightFromIndex(textGenerationInfo, index) : textInfo.GetLineHeightFromCharacterIndex(index));
		}

		public float GetCharacterHeightFromIndex(int index)
		{
			return PixelsToPoints(useAdvancedText ? TextSelectionService.GetCharacterHeightFromIndex(textGenerationInfo, index) : textInfo.GetCharacterHeightFromIndex(index));
		}

		public string Substring(int startIndex, int length)
		{
			return useAdvancedText ? TextSelectionService.Substring(textGenerationInfo, startIndex, startIndex + length) : textInfo.Substring(startIndex, length);
		}

		public int PreviousCodePointIndex(int currentIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use PreviousCodePointIndex while using Standard Text");
				return 0;
			}
			return TextSelectionService.PreviousCodePointIndex(textGenerationInfo, currentIndex);
		}

		public int NextCodePointIndex(int currentIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use NextCodePointIndex while using Standard Text");
				return 0;
			}
			return TextSelectionService.NextCodePointIndex(textGenerationInfo, currentIndex);
		}

		public int GetStartOfNextWord(int currentIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use GetStartOfNextWord while using Standard Text");
				return 0;
			}
			return TextSelectionService.GetStartOfNextWord(textGenerationInfo, currentIndex);
		}

		public int GetEndOfPreviousWord(int currentIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use GetEndOfPreviousWord while using Standard Text");
				return 0;
			}
			return TextSelectionService.GetEndOfPreviousWord(textGenerationInfo, currentIndex);
		}

		public int GetFirstCharacterIndexOnLine(int currentIndex)
		{
			if (!useAdvancedText)
			{
				return GetLineInfoFromCharacterIndex(currentIndex).firstCharacterIndex;
			}
			return TextSelectionService.GetFirstCharacterIndexOnLine(textGenerationInfo, currentIndex);
		}

		public int GetLastCharacterIndexOnLine(int currentIndex)
		{
			if (!useAdvancedText)
			{
				return GetLineInfoFromCharacterIndex(currentIndex).lastCharacterIndex;
			}
			return TextSelectionService.GetLastCharacterIndexOnLine(textGenerationInfo, currentIndex);
		}

		public int IndexOf(char value, int startIndex)
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use IndexOf while using Advanced Text");
				return 0;
			}
			return textInfo.IndexOf(value, startIndex);
		}

		public int LastIndexOf(char value, int startIndex)
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use LastIndexOf while using Advanced Text");
				return 0;
			}
			return textInfo.LastIndexOf(value, startIndex);
		}

		public void SelectCurrentWord(int index, ref int cursorIndex, ref int selectIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use SelectCurrentWord while using Standard Text");
			}
			else
			{
				TextSelectionService.SelectCurrentWord(textGenerationInfo, index, ref cursorIndex, ref selectIndex);
			}
		}

		public void SelectCurrentParagraph(ref int cursorIndex, ref int selectIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use SelectCurrentParagraph while using Standard Text");
			}
			else
			{
				TextSelectionService.SelectCurrentParagraph(textGenerationInfo, ref cursorIndex, ref selectIndex);
			}
		}

		public void SelectToPreviousParagraph(ref int cursorIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use SelectToPreviousParagraph while using Standard Text");
			}
			else
			{
				TextSelectionService.SelectToPreviousParagraph(textGenerationInfo, ref cursorIndex);
			}
		}

		public void SelectToNextParagraph(ref int cursorIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use SelectToNextParagraph while using Standard Text");
			}
			else
			{
				TextSelectionService.SelectToNextParagraph(textGenerationInfo, ref cursorIndex);
			}
		}

		public void SelectToStartOfParagraph(ref int cursorIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use SelectToStartOfParagraph while using Standard Text");
			}
			else
			{
				TextSelectionService.SelectToStartOfParagraph(textGenerationInfo, ref cursorIndex);
			}
		}

		public void SelectToEndOfParagraph(ref int cursorIndex)
		{
			if (!useAdvancedText)
			{
				Debug.LogError("Cannot use SelectToEndOfParagraph while using Standard Text");
			}
			else
			{
				TextSelectionService.SelectToEndOfParagraph(textGenerationInfo, ref cursorIndex);
			}
		}

		internal virtual bool IsAdvancedTextEnabledForElement()
		{
			return false;
		}

		internal int GetTextElementCount()
		{
			if (useAdvancedText)
			{
				Debug.LogError("Cannot use GetTextElementCount while using Advanced Text");
				return 0;
			}
			return textInfo.textElementInfo.Length;
		}

		internal GlyphMetricsForOverlay GetScaledCharacterMetrics(int i)
		{
			if (useAdvancedText)
			{
				throw new InvalidOperationException("Cannot use GetScaledCharacterMetrics while using Advanced Text");
			}
			return new GlyphMetricsForOverlay(ref textInfo.textElementInfo[i], GetPixelsPerPoint());
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal class TextHandlePermanentCache
	{
		internal LinkedList<TextInfo> s_TextInfoPool = new LinkedList<TextInfo>();

		private object syncRoot = new object();

		public virtual void AddTextInfoToCache(TextHandle textHandle)
		{
			lock (syncRoot)
			{
				if (textHandle.IsCachedPermanent)
				{
					return;
				}
				if (textHandle.IsCachedTemporary)
				{
					textHandle.RemoveTextInfoFromTemporaryCache();
				}
				if (s_TextInfoPool.Count > 0)
				{
					textHandle.TextInfoNode = s_TextInfoPool.Last;
					s_TextInfoPool.RemoveLast();
				}
				else
				{
					TextInfo value = new TextInfo();
					textHandle.TextInfoNode = new LinkedListNode<TextInfo>(value);
				}
			}
			textHandle.IsCachedPermanent = true;
			textHandle.SetDirty();
			textHandle.Update();
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		public void RemoveTextInfoFromCache(TextHandle textHandle)
		{
			lock (syncRoot)
			{
				if (textHandle.IsCachedPermanent)
				{
					s_TextInfoPool.AddFirst(textHandle.TextInfoNode);
					textHandle.TextInfoNode = null;
					textHandle.IsCachedPermanent = false;
				}
			}
		}
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
	internal class TextHandleTemporaryCache
	{
		internal LinkedList<TextInfo> s_TextInfoPool = new LinkedList<TextInfo>();

		internal const int s_MinFramesInCache = 2;

		internal int currentFrame;

		private object syncRoot = new object();

		public void ClearTemporaryCache()
		{
			for (int i = 0; i < s_TextInfoPool.Count; i++)
			{
				s_TextInfoPool.First.Value.RemoveFromCache();
			}
			s_TextInfoPool.Clear();
		}

		public void AddTextInfoToCache(TextHandle textHandle, int hashCode)
		{
			lock (syncRoot)
			{
				if (textHandle.IsCachedPermanent)
				{
					return;
				}
				if (!TextGenerator.IsExecutingJob)
				{
					currentFrame = Time.frameCount;
				}
				if (s_TextInfoPool.Count > 0 && ((double)currentFrame - s_TextInfoPool.Last.Value.lastTimeInCache < 0.0 || (double)currentFrame - s_TextInfoPool.First.Value.lastTimeInCache < 0.0))
				{
					ClearTemporaryCache();
				}
				if (textHandle.IsCachedTemporary)
				{
					RefreshCaching(textHandle);
					return;
				}
				if (s_TextInfoPool.Count > 0 && (double)currentFrame - s_TextInfoPool.Last.Value.lastTimeInCache > 2.0)
				{
					RecycleTextInfoFromCache(textHandle);
				}
				else
				{
					TextInfo textInfo = new TextInfo();
					textHandle.TextInfoNode = new LinkedListNode<TextInfo>(textInfo);
					s_TextInfoPool.AddFirst(textHandle.TextInfoNode);
					textInfo.lastTimeInCache = currentFrame;
					textInfo.removedFromCache = (Action)Delegate.Combine(textInfo.removedFromCache, new Action(textHandle.RemoveTextInfoFromTemporaryCache));
				}
			}
			textHandle.IsCachedTemporary = true;
			textHandle.SetDirty();
			textHandle.UpdateWithHash(hashCode);
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		public virtual void RemoveTextInfoFromCache(TextHandle textHandle)
		{
			lock (syncRoot)
			{
				if (textHandle.IsCachedTemporary)
				{
					textHandle.IsCachedTemporary = false;
					textHandle.TextInfoNode.Value.lastTimeInCache = 0.0;
					textHandle.TextInfoNode.Value.removedFromCache = null;
					if (textHandle.TextInfoNode != null)
					{
						s_TextInfoPool.Remove(textHandle.TextInfoNode);
						s_TextInfoPool.AddLast(textHandle.TextInfoNode);
					}
					textHandle.TextInfoNode = null;
				}
			}
		}

		private void RefreshCaching(TextHandle textHandle)
		{
			if (!TextGenerator.IsExecutingJob)
			{
				currentFrame = Time.frameCount;
			}
			textHandle.TextInfoNode.Value.lastTimeInCache = currentFrame;
			s_TextInfoPool.Remove(textHandle.TextInfoNode);
			s_TextInfoPool.AddFirst(textHandle.TextInfoNode);
		}

		private void RecycleTextInfoFromCache(TextHandle textHandle)
		{
			if (!TextGenerator.IsExecutingJob)
			{
				currentFrame = Time.frameCount;
			}
			textHandle.TextInfoNode = s_TextInfoPool.Last;
			textHandle.TextInfoNode.Value.RemoveFromCache();
			s_TextInfoPool.RemoveLast();
			s_TextInfoPool.AddFirst(textHandle.TextInfoNode);
			textHandle.IsCachedTemporary = true;
			TextInfo value = textHandle.TextInfoNode.Value;
			value.removedFromCache = (Action)Delegate.Combine(value.removedFromCache, new Action(textHandle.RemoveTextInfoFromTemporaryCache));
			textHandle.TextInfoNode.Value.lastTimeInCache = currentFrame;
		}

		public void UpdateCurrentFrame()
		{
			currentFrame = Time.frameCount;
		}
	}
	internal struct WordInfo
	{
		public int firstCharacterIndex;

		public int lastCharacterIndex;

		public int characterCount;
	}
	[VisibleToOtherModules(new string[] { "UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal class TextInfo
	{
		private static Vector2 s_InfinityVectorPositive = new Vector2(32767f, 32767f);

		private static Vector2 s_InfinityVectorNegative = new Vector2(-32767f, -32767f);

		public int characterCount;

		public int spriteCount;

		public int spaceCount;

		public int wordCount;

		public int linkCount;

		public int lineCount;

		public int materialCount;

		public TextElementInfo[] textElementInfo;

		public WordInfo[] wordInfo;

		public LinkInfo[] linkInfo;

		public LineInfo[] lineInfo;

		public MeshInfo[] meshInfo;

		public double lastTimeInCache;

		public Action removedFromCache;

		public bool hasMultipleColors = false;

		public void RemoveFromCache()
		{
			removedFromCache?.Invoke();
			removedFromCache = null;
		}

		public TextInfo()
		{
			textElementInfo = new TextElementInfo[4];
			wordInfo = new WordInfo[1];
			lineInfo = new LineInfo[1];
			linkInfo = Array.Empty<LinkInfo>();
			meshInfo = Array.Empty<MeshInfo>();
			materialCount = 0;
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal void Clear()
		{
			characterCount = 0;
			spaceCount = 0;
			wordCount = 0;
			linkCount = 0;
			lineCount = 0;
			spriteCount = 0;
			hasMultipleColors = false;
			for (int i = 0; i < meshInfo.Length; i++)
			{
				meshInfo[i].vertexCount = 0;
			}
		}

		internal void ClearMeshInfo(bool updateMesh)
		{
			for (int i = 0; i < meshInfo.Length; i++)
			{
				meshInfo[i].Clear(updateMesh);
			}
		}

		internal void ClearLineInfo()
		{
			if (lineInfo == null)
			{
				lineInfo = new LineInfo[1];
			}
			for (int i = 0; i < lineInfo.Length; i++)
			{
				lineInfo[i].characterCount = 0;
				lineInfo[i].spaceCount = 0;
				lineInfo[i].wordCount = 0;
				lineInfo[i].controlCharacterCount = 0;
				lineInfo[i].ascender = s_InfinityVectorNegative.x;
				lineInfo[i].baseline = 0f;
				lineInfo[i].descender = s_InfinityVectorPositive.x;
				lineInfo[i].maxAdvance = 0f;
				lineInfo[i].marginLeft = 0f;
				lineInfo[i].marginRight = 0f;
				lineInfo[i].lineExtents.min = s_InfinityVectorPositive;
				lineInfo[i].lineExtents.max = s_InfinityVectorNegative;
				lineInfo[i].width = 0f;
			}
		}

		internal static void Resize<T>(ref T[] array, int size)
		{
			int newSize = ((size > 1024) ? (size + 256) : Mathf.NextPowerOfTwo(size));
			Array.Resize(ref array, newSize);
		}

		internal static void Resize<T>(ref T[] array, int size, bool isBlockAllocated)
		{
			if (isBlockAllocated)
			{
				size = ((size > 1024) ? (size + 256) : Mathf.NextPowerOfTwo(size));
			}
			if (size != array.Length)
			{
				Array.Resize(ref array, size);
			}
		}

		public virtual Vector2 GetCursorPositionFromStringIndexUsingCharacterHeight(int index, Rect screenRect, float lineHeight, bool inverseYAxis = true)
		{
			Vector2 position = screenRect.position;
			if (characterCount == 0)
			{
				return inverseYAxis ? new Vector2(0f, lineHeight) : position;
			}
			int num = ((index >= characterCount) ? (characterCount - 1) : index);
			TextElementInfo textElementInfo = this.textElementInfo[num];
			float descender = textElementInfo.descender;
			float x = ((index >= characterCount) ? textElementInfo.xAdvance : textElementInfo.origin);
			return position + (inverseYAxis ? new Vector2(x, screenRect.height - descender) : new Vector2(x, descender));
		}

		public Vector2 GetCursorPositionFromStringIndexUsingLineHeight(int index, Rect screenRect, float lineHeight, bool useXAdvance = false, bool inverseYAxis = true)
		{
			Vector2 position = screenRect.position;
			if (characterCount == 0 || index < 0)
			{
				return inverseYAxis ? new Vector2(0f, lineHeight) : position;
			}
			int num = index;
			if (index >= characterCount)
			{
				num = characterCount - 1;
				useXAdvance = true;
			}
			TextElementInfo textElementInfo = this.textElementInfo[num];
			LineInfo lineInfo = this.lineInfo[textElementInfo.lineNumber];
			float x = (useXAdvance ? textElementInfo.xAdvance : textElementInfo.origin);
			float y = (inverseYAxis ? (screenRect.height - lineInfo.descender) : lineInfo.descender);
			return position + new Vector2(x, y);
		}

		public int GetCursorIndexFromPosition(Vector2 position, Rect screenRect, bool inverseYAxis = true)
		{
			if (inverseYAxis)
			{
				position.y = screenRect.height - position.y;
			}
			int line = 0;
			if (lineCount > 1)
			{
				line = FindNearestLine(position);
			}
			int num = FindNearestCharacterOnLine(position, line, visibleOnly: false);
			TextElementInfo textElementInfo = this.textElementInfo[num];
			Vector3 bottomLeft = textElementInfo.bottomLeft;
			Vector3 topRight = textElementInfo.topRight;
			float num2 = (position.x - bottomLeft.x) / (topRight.x - bottomLeft.x);
			return (num2 < 0.5f || textElementInfo.character == 10) ? num : (num + 1);
		}

		public int LineDownCharacterPosition(int originalPos)
		{
			if (originalPos >= characterCount)
			{
				return characterCount - 1;
			}
			TextElementInfo textElementInfo = this.textElementInfo[originalPos];
			int lineNumber = textElementInfo.lineNumber;
			if (lineNumber + 1 >= lineCount)
			{
				return characterCount - 1;
			}
			int lastCharacterIndex = lineInfo[lineNumber + 1].lastCharacterIndex;
			int num = -1;
			float num2 = float.PositiveInfinity;
			float num3 = 0f;
			for (int i = lineInfo[lineNumber + 1].firstCharacterIndex; i < lastCharacterIndex; i++)
			{
				TextElementInfo textElementInfo2 = this.textElementInfo[i];
				float num4 = textElementInfo.origin - textElementInfo2.origin;
				float num5 = num4 / (textElementInfo2.xAdvance - textElementInfo2.origin);
				if (num5 >= 0f && num5 <= 1f)
				{
					if (num5 < 0.5f)
					{
						return i;
					}
					return i + 1;
				}
				num4 = Mathf.Abs(num4);
				if (num4 < num2)
				{
					num = i;
					num2 = num4;
					num3 = num5;
				}
			}
			if (num == -1)
			{
				return lastCharacterIndex;
			}
			if (num3 < 0.5f)
			{
				return num;
			}
			return num + 1;
		}

		public int LineUpCharacterPosition(int originalPos)
		{
			if (originalPos >= characterCount)
			{
				originalPos--;
			}
			TextElementInfo textElementInfo = this.textElementInfo[originalPos];
			int lineNumber = textElementInfo.lineNumber;
			if (lineNumber - 1 < 0)
			{
				return 0;
			}
			int num = lineInfo[lineNumber].firstCharacterIndex - 1;
			int num2 = -1;
			float num3 = float.PositiveInfinity;
			float num4 = 0f;
			for (int i = lineInfo[lineNumber - 1].firstCharacterIndex; i < num; i++)
			{
				TextElementInfo textElementInfo2 = this.textElementInfo[i];
				float num5 = textElementInfo.origin - textElementInfo2.origin;
				float num6 = num5 / (textElementInfo2.xAdvance - textElementInfo2.origin);
				if (num6 >= 0f && num6 <= 1f)
				{
					if (num6 < 0.5f)
					{
						return i;
					}
					return i + 1;
				}
				num5 = Mathf.Abs(num5);
				if (num5 < num3)
				{
					num2 = i;
					num3 = num5;
					num4 = num6;
				}
			}
			if (num2 == -1)
			{
				return num;
			}
			if (num4 < 0.5f)
			{
				return num2;
			}
			return num2 + 1;
		}

		public int FindWordIndex(int cursorIndex)
		{
			for (int i = 0; i < wordCount; i++)
			{
				WordInfo wordInfo = this.wordInfo[i];
				if (wordInfo.firstCharacterIndex <= cursorIndex && wordInfo.lastCharacterIndex >= cursorIndex)
				{
					return i;
				}
			}
			return -1;
		}

		public int FindNearestLine(Vector2 position)
		{
			float num = float.PositiveInfinity;
			int result = -1;
			for (int i = 0; i < lineCount; i++)
			{
				LineInfo lineInfo = this.lineInfo[i];
				float ascender = lineInfo.ascender;
				float descender = lineInfo.descender;
				if (ascender > position.y && descender < position.y)
				{
					return i;
				}
				float a = Mathf.Abs(ascender - position.y);
				float b = Mathf.Abs(descender - position.y);
				float num2 = Mathf.Min(a, b);
				if (num2 < num)
				{
					num = num2;
					result = i;
				}
			}
			return result;
		}

		public int FindNearestCharacterOnLine(Vector2 position, int line, bool visibleOnly)
		{
			if (line >= lineInfo.Length || line < 0)
			{
				return 0;
			}
			int firstCharacterIndex = lineInfo[line].firstCharacterIndex;
			int lastCharacterIndex = lineInfo[line].lastCharacterIndex;
			float num = float.PositiveInfinity;
			int result = lastCharacterIndex;
			for (int i = firstCharacterIndex; i <= lastCharacterIndex; i++)
			{
				TextElementInfo textElementInfo = this.textElementInfo[i];
				if ((!visibleOnly || textElementInfo.isVisible) && textElementInfo.character != 13 && textElementInfo.character != 10)
				{
					Vector3 bottomLeft = textElementInfo.bottomLeft;
					Vector3 vector = new Vector3(textElementInfo.bottomLeft.x, textElementInfo.topRight.y, 0f);
					Vector3 topRight = textElementInfo.topRight;
					Vector3 vector2 = new Vector3(textElementInfo.topRight.x, textElementInfo.bottomLeft.y, 0f);
					if (PointIntersectRectangle(position, bottomLeft, vector, topRight, vector2))
					{
						result = i;
						break;
					}
					float num2 = DistanceToLine(bottomLeft, vector, position);
					float num3 = DistanceToLine(vector, topRight, position);
					float num4 = DistanceToLine(topRight, vector2, position);
					float num5 = DistanceToLine(vector2, bottomLeft, position);
					float num6 = ((num2 < num3) ? num2 : num3);
					num6 = ((num6 < num4) ? num6 : num4);
					num6 = ((num6 < num5) ? num6 : num5);
					if (num > num6)
					{
						num = num6;
						result = i;
					}
				}
			}
			return result;
		}

		public int FindIntersectingLink(Vector3 position, Rect screenRect, bool inverseYAxis = true)
		{
			if (inverseYAxis)
			{
				position.y = screenRect.height - position.y;
			}
			for (int i = 0; i < linkCount; i++)
			{
				LinkInfo linkInfo = this.linkInfo[i];
				bool flag = false;
				Vector3 a = Vector3.zero;
				Vector3 b = Vector3.zero;
				Vector3 zero = Vector3.zero;
				Vector3 zero2 = Vector3.zero;
				for (int j = 0; j < linkInfo.linkTextLength; j++)
				{
					int num = linkInfo.linkTextfirstCharacterIndex + j;
					TextElementInfo textElementInfo = this.textElementInfo[num];
					int lineNumber = textElementInfo.lineNumber;
					if (!flag)
					{
						flag = true;
						a = new Vector3(textElementInfo.bottomLeft.x, textElementInfo.descender, 0f);
						b = new Vector3(textElementInfo.bottomLeft.x, textElementInfo.ascender, 0f);
						if (linkInfo.linkTextLength == 1)
						{
							flag = false;
							if (PointIntersectRectangle(d: new Vector3(textElementInfo.topRight.x, textElementInfo.descender, 0f), c: new Vector3(textElementInfo.topRight.x, textElementInfo.ascender, 0f), m: position, a: a, b: b))
							{
								return i;
							}
						}
					}
					if (flag && j == linkInfo.linkTextLength - 1)
					{
						flag = false;
						if (PointIntersectRectangle(d: new Vector3(textElementInfo.topRight.x, textElementInfo.descender, 0f), c: new Vector3(textElementInfo.topRight.x, textElementInfo.ascender, 0f), m: position, a: a, b: b))
						{
							return i;
						}
					}
					else if (flag && lineNumber != this.textElementInfo[num + 1].lineNumber)
					{
						flag = false;
						if (PointIntersectRectangle(d: new Vector3(textElementInfo.topRight.x, textElementInfo.descender, 0f), c: new Vector3(textElementInfo.topRight.x, textElementInfo.ascender, 0f), m: position, a: a, b: b))
						{
							return i;
						}
					}
				}
			}
			return -1;
		}

		public int GetCorrespondingStringIndex(int index)
		{
			if (index <= 0)
			{
				return 0;
			}
			return textElementInfo[index - 1].index + textElementInfo[index - 1].stringLength;
		}

		public int GetCorrespondingCodePointIndex(int stringIndex)
		{
			if (stringIndex <= 0)
			{
				return 0;
			}
			for (int i = 0; i < characterCount; i++)
			{
				TextElementInfo textElementInfo = this.textElementInfo[i];
				if (textElementInfo.index + textElementInfo.stringLength >= stringIndex)
				{
					return i + 1;
				}
			}
			return characterCount;
		}

		public LineInfo GetLineInfoFromCharacterIndex(int index)
		{
			return lineInfo[GetLineNumber(index)];
		}

		private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			Vector3 vector = Vector3.Cross(b - a, d - a);
			if (vector == Vector3.zero)
			{
				return false;
			}
			Vector3 vector2 = b - a;
			Vector3 rhs = m - a;
			Vector3 vector3 = c - b;
			Vector3 rhs2 = m - b;
			float num = Vector3.Dot(vector2, rhs);
			float num2 = Vector3.Dot(vector3, rhs2);
			return 0f <= num && num <= Vector3.Dot(vector2, vector2) && 0f <= num2 && num2 <= Vector3.Dot(vector3, vector3);
		}

		private static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point)
		{
			if (a == b)
			{
				Vector3 vector = point - a;
				return Vector3.Dot(vector, vector);
			}
			Vector3 vector2 = b - a;
			Vector3 vector3 = a - point;
			float num = Vector3.Dot(vector2, vector3);
			if (num > 0f)
			{
				return Vector3.Dot(vector3, vector3);
			}
			Vector3 vector4 = point - b;
			if (Vector3.Dot(vector2, vector4) > 0f)
			{
				return Vector3.Dot(vector4, vector4);
			}
			Vector3 vector5 = vector3 - vector2 * (num / Vector3.Dot(vector2, vector2));
			return Vector3.Dot(vector5, vector5);
		}

		public int GetLineNumber(int index)
		{
			if (index <= 0)
			{
				index = 0;
			}
			if (index >= characterCount)
			{
				index = Mathf.Max(0, characterCount - 1);
			}
			return textElementInfo[index].lineNumber;
		}

		public float GetLineHeight(int lineNumber)
		{
			if (lineNumber <= 0)
			{
				lineNumber = 0;
			}
			if (lineNumber >= lineCount)
			{
				lineNumber = Mathf.Max(0, lineCount - 1);
			}
			return lineInfo[lineNumber].lineHeight;
		}

		public float GetLineHeightFromCharacterIndex(int index)
		{
			if (index <= 0)
			{
				index = 0;
			}
			if (index >= characterCount)
			{
				index = Mathf.Max(0, characterCount - 1);
			}
			return GetLineHeight(textElementInfo[index].lineNumber);
		}

		public float GetCharacterHeightFromIndex(int index)
		{
			if (index <= 0)
			{
				index = 0;
			}
			if (index >= characterCount)
			{
				index = Mathf.Max(0, characterCount - 1);
			}
			TextElementInfo textElementInfo = this.textElementInfo[index];
			return textElementInfo.ascender - textElementInfo.descender;
		}

		public string Substring(int startIndex, int length)
		{
			if (startIndex < 0 || startIndex + length > characterCount)
			{
				throw new ArgumentOutOfRangeException();
			}
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = startIndex; i < startIndex + length; i++)
			{
				uint character = textElementInfo[i].character;
				if (character >= 65536 && character <= 1114111)
				{
					uint num = 55296 + (character - 65536 >> 10);
					uint num2 = 56320 + ((character - 65536) & 0x3FF);
					stringBuilder.Append((char)num);
					stringBuilder.Append((char)num2);
				}
				else
				{
					stringBuilder.Append((char)character);
				}
			}
			return stringBuilder.ToString();
		}

		public int IndexOf(char value, int startIndex)
		{
			if (startIndex < 0 || startIndex >= characterCount)
			{
				throw new ArgumentOutOfRangeException();
			}
			for (int i = startIndex; i < characterCount; i++)
			{
				if (textElementInfo[i].character == value)
				{
					return i;
				}
			}
			return -1;
		}

		public int LastIndexOf(char value, int startIndex)
		{
			if (startIndex < 0 || startIndex >= characterCount)
			{
				throw new ArgumentOutOfRangeException();
			}
			for (int num = startIndex; num >= 0; num--)
			{
				if (textElementInfo[num].character == value)
				{
					return num;
				}
			}
			return -1;
		}
	}
	internal enum MarkupTag
	{
		BOLD = 66,
		SLASH_BOLD = 1613,
		ITALIC = 73,
		SLASH_ITALIC = 1606,
		UNDERLINE = 85,
		SLASH_UNDERLINE = 1626,
		STRIKETHROUGH = 83,
		SLASH_STRIKETHROUGH = 1628,
		MARK = 2699125,
		SLASH_MARK = 57644506,
		SUBSCRIPT = 92132,
		SLASH_SUBSCRIPT = 1770219,
		SUPERSCRIPT = 92150,
		SLASH_SUPERSCRIPT = 1770233,
		COLOR = 81999901,
		SLASH_COLOR = 1909026194,
		ALPHA = 75165780,
		A = 65,
		SLASH_A = 1614,
		SIZE = 3061285,
		SLASH_SIZE = 58429962,
		SPRITE = -991527447,
		NO_BREAK = 2856657,
		SLASH_NO_BREAK = 57477502,
		STYLE = 100252951,
		SLASH_STYLE = 1927738392,
		FONT = 2586451,
		SLASH_FONT = 57747708,
		SLASH_MATERIAL = -1100708252,
		LINK = 2656128,
		SLASH_LINK = 57686191,
		FONT_WEIGHT = -1889896162,
		SLASH_FONT_WEIGHT = -757976431,
		NO_PARSE = -408011596,
		SLASH_NO_PARSE = -294095813,
		POSITION = 85420,
		SLASH_POSITION = 1777699,
		VERTICAL_OFFSET = 1952379995,
		SLASH_VERTICAL_OFFSET = -11107948,
		SPACE = 100083556,
		SLASH_SPACE = 1927873067,
		PAGE = 2808691,
		SLASH_PAGE = 58683868,
		ALIGN = 75138797,
		SLASH_ALIGN = 1916026786,
		WIDTH = 105793766,
		SLASH_WIDTH = 1923459625,
		GRADIENT = -1999759898,
		SLASH_GRADIENT = -1854491959,
		CHARACTER_SPACE = -1584382009,
		SLASH_CHARACTER_SPACE = -1394426712,
		MONOSPACE = -1340221943,
		SLASH_MONOSPACE = -1638865562,
		CLASS = 82115566,
		INDENT = -1514123076,
		SLASH_INDENT = -1496889389,
		LINE_INDENT = -844305121,
		SLASH_LINE_INDENT = 93886352,
		MARGIN = -1355614050,
		SLASH_MARGIN = -1649644303,
		MARGIN_LEFT = -272933656,
		MARGIN_RIGHT = -447416589,
		LINE_HEIGHT = -799081892,
		SLASH_LINE_HEIGHT = 200452819,
		ACTION = -1827519330,
		SLASH_ACTION = -1187217679,
		SCALE = 100553336,
		SLASH_SCALE = 1928413879,
		ROTATE = -1000007783,
		SLASH_ROTATE = -764695562,
		TABLE = 226476955,
		SLASH_TABLE = -979118220,
		TH = 5862489,
		SLASH_TH = 193346070,
		TR = 5862467,
		SLASH_TR = 193346060,
		TD = 5862485,
		SLASH_TD = 193346074,
		LOWERCASE = -1506899689,
		SLASH_LOWERCASE = -1451284584,
		ALLCAPS = 218273952,
		SLASH_ALLCAPS = -797437649,
		UPPERCASE = -305409418,
		SLASH_UPPERCASE = -582368199,
		SMALLCAPS = -766062114,
		SLASH_SMALLCAPS = 199921873,
		LIGA = 2655971,
		SLASH_LIGA = 57686604,
		FRAC = 2598518,
		SLASH_FRAC = 57774681,
		NAME = 2875623,
		INDEX = 84268030,
		TINT = 2960519,
		ANIM = 2283339,
		MATERIAL = 825491659,
		HREF = 2535353,
		ANGLE = 75347905,
		PADDING = -2144568463,
		FAMILYNAME = 704251153,
		STYLENAME = -1207081936,
		DUOSPACE = 582810522,
		RED = 91635,
		GREEN = 87065851,
		BLUE = 2457214,
		YELLOW = -882444668,
		ORANGE = -1108587920,
		BLACK = 81074727,
		WHITE = 105680263,
		PURPLE = -1250222130,
		GREY = 2638345,
		LIGHTBLUE = 341063360,
		TEAL = 2947772,
		CYAN = 2504597,
		DARKBLUE = -1960309918,
		FUCHSIA = -1002715645,
		SILVER = -960329321,
		BROWN = 81017702,
		MAROON = -1355621936,
		OLIVE = 95492953,
		NAVY = 2876352,
		AQUA = 2284356,
		MAGENTA = -1812576107,
		TRANSPARENT = -1014785338,
		LIME = 2656045,
		BR = 2256,
		CR = 2289,
		ZWSP = 3288238,
		ZWJ = 99623,
		NBSP = 2869039,
		SHY = 92674,
		LEFT = 2660507,
		RIGHT = 99937376,
		CENTER = -1591113269,
		JUSTIFIED = 817091359,
		FLUSH = 85552164,
		NONE = 2857034,
		PLUS = 43,
		MINUS = 45,
		PX = 2568,
		PLUS_PX = 49507,
		MINUS_PX = 47461,
		EM = 2216,
		PLUS_EM = 49091,
		MINUS_EM = 46789,
		PCT = 85031,
		PLUS_PCT = 1634348,
		MINUS_PCT = 1567082,
		PERCENTAGE = 37,
		PLUS_PERCENTAGE = 1454,
		MINUS_PERCENTAGE = 1512,
		TRUE = 2932022,
		FALSE = 85422813,
		INVALID = 1585415185,
		NOTDEF = 612146780,
		NORMAL = -1183493901,
		DEFAULT = -620974005,
		REGULAR = 1291372090
	}
	internal enum TagValueType
	{
		None = 0,
		NumericalValue = 1,
		StringValue = 2,
		ColorValue = 4
	}
	internal enum TagUnitType
	{
		Pixels,
		FontUnits,
		Percentage
	}
	internal static class CodePoint
	{
		public const uint SPACE = 32u;

		public const uint DOUBLE_QUOTE = 34u;

		public const uint NUMBER_SIGN = 35u;

		public const uint PERCENTAGE = 37u;

		public const uint PLUS = 43u;

		public const uint MINUS = 45u;

		public const uint PERIOD = 46u;

		public const uint HYPHEN_MINUS = 45u;

		public const uint SOFT_HYPHEN = 173u;

		public const uint HYPHEN = 8208u;

		public const uint NON_BREAKING_HYPHEN = 8209u;

		public const uint ZERO_WIDTH_SPACE = 8203u;

		public const uint RIGHT_SINGLE_QUOTATION = 8217u;

		public const uint APOSTROPHE = 39u;

		public const uint WORD_JOINER = 8288u;

		public const uint HIGH_SURROGATE_START = 55296u;

		public const uint HIGH_SURROGATE_END = 56319u;

		public const uint LOW_SURROGATE_START = 56320u;

		public const uint LOW_SURROGATE_END = 57343u;

		public const uint UNICODE_PLANE01_START = 65536u;

		public const uint UNICODE_PLANE16_END = 1114111u;

		public const uint LOWEST_10BITS_MASK = 1023u;

		public const uint LINE_FEED = 10u;

		public const uint CARRIAGE_RETURN = 13u;
	}
	internal enum TextProcessingElementType
	{
		Undefined,
		TextCharacterElement,
		TextMarkupElement
	}
	internal struct MarkupAttribute
	{
		private int m_NameHashCode;

		private int m_ValueHashCode;

		private int m_ValueStartIndex;

		private int m_ValueLength;

		public int NameHashCode
		{
			get
			{
				return m_NameHashCode;
			}
			set
			{
				m_NameHashCode = value;
			}
		}

		public int ValueHashCode
		{
			get
			{
				return m_ValueHashCode;
			}
			set
			{
				m_ValueHashCode = value;
			}
		}

		public int ValueStartIndex
		{
			get
			{
				return m_ValueStartIndex;
			}
			set
			{
				m_ValueStartIndex = value;
			}
		}

		public int ValueLength
		{
			get
			{
				return m_ValueLength;
			}
			set
			{
				m_ValueLength = value;
			}
		}
	}
	internal struct MarkupElement
	{
		private MarkupAttribute[] m_Attributes = new MarkupAttribute[8];

		public int NameHashCode
		{
			get
			{
				return (m_Attributes != null) ? m_Attributes[0].NameHashCode : 0;
			}
			set
			{
				if (m_Attributes == null)
				{
					m_Attributes = new MarkupAttribute[8];
				}
				m_Attributes[0].NameHashCode = value;
			}
		}

		public int ValueHashCode
		{
			get
			{
				return (m_Attributes != null) ? m_Attributes[0].ValueHashCode : 0;
			}
			set
			{
				m_Attributes[0].ValueHashCode = value;
			}
		}

		public int ValueStartIndex
		{
			get
			{
				return (m_Attributes != null) ? m_Attributes[0].ValueStartIndex : 0;
			}
			set
			{
				m_Attributes[0].ValueStartIndex = value;
			}
		}

		public int ValueLength
		{
			get
			{
				return (m_Attributes != null) ? m_Attributes[0].ValueLength : 0;
			}
			set
			{
				m_Attributes[0].ValueLength = value;
			}
		}

		public MarkupAttribute[] Attributes
		{
			get
			{
				return m_Attributes;
			}
			set
			{
				m_Attributes = value;
			}
		}

		public MarkupElement(int nameHashCode, int startIndex, int length)
		{
			m_Attributes[0].NameHashCode = nameHashCode;
			m_Attributes[0].ValueStartIndex = startIndex;
			m_Attributes[0].ValueLength = length;
		}
	}
	internal struct FontStyleStack
	{
		public byte bold;

		public byte italic;

		public byte underline;

		public byte strikethrough;

		public byte highlight;

		public byte superscript;

		public byte subscript;

		public byte uppercase;

		public byte lowercase;

		public byte smallcaps;

		public void Clear()
		{
			bold = 0;
			italic = 0;
			underline = 0;
			strikethrough = 0;
			highlight = 0;
			superscript = 0;
			subscript = 0;
			uppercase = 0;
			lowercase = 0;
			smallcaps = 0;
		}

		public byte Add(FontStyles style)
		{
			switch (style)
			{
			case FontStyles.Bold:
				bold++;
				return bold;
			case FontStyles.Italic:
				italic++;
				return italic;
			case FontStyles.Underline:
				underline++;
				return underline;
			case FontStyles.UpperCase:
				uppercase++;
				return uppercase;
			case FontStyles.LowerCase:
				lowercase++;
				return lowercase;
			case FontStyles.Strikethrough:
				strikethrough++;
				return strikethrough;
			case FontStyles.Superscript:
				superscript++;
				return superscript;
			case FontStyles.Subscript:
				subscript++;
				return subscript;
			case FontStyles.Highlight:
				highlight++;
				return highlight;
			default:
				return 0;
			}
		}

		public byte Remove(FontStyles style)
		{
			switch (style)
			{
			case FontStyles.Bold:
				if (bold > 1)
				{
					bold--;
				}
				else
				{
					bold = 0;
				}
				return bold;
			case FontStyles.Italic:
				if (italic > 1)
				{
					italic--;
				}
				else
				{
					italic = 0;
				}
				return italic;
			case FontStyles.Underline:
				if (underline > 1)
				{
					underline--;
				}
				else
				{
					underline = 0;
				}
				return underline;
			case FontStyles.UpperCase:
				if (uppercase > 1)
				{
					uppercase--;
				}
				else
				{
					uppercase = 0;
				}
				return uppercase;
			case FontStyles.LowerCase:
				if (lowercase > 1)
				{
					lowercase--;
				}
				else
				{
					lowercase = 0;
				}
				return lowercase;
			case FontStyles.Strikethrough:
				if (strikethrough > 1)
				{
					strikethrough--;
				}
				else
				{
					strikethrough = 0;
				}
				return strikethrough;
			case FontStyles.Highlight:
				if (highlight > 1)
				{
					highlight--;
				}
				else
				{
					highlight = 0;
				}
				return highlight;
			case FontStyles.Superscript:
				if (superscript > 1)
				{
					superscript--;
				}
				else
				{
					superscript = 0;
				}
				return superscript;
			case FontStyles.Subscript:
				if (subscript > 1)
				{
					subscript--;
				}
				else
				{
					subscript = 0;
				}
				return subscript;
			default:
				return 0;
			}
		}
	}
	[DebuggerDisplay("Item count = {m_Count}")]
	internal struct TextProcessingStack<T>
	{
		public T[] itemStack;

		public int index;

		private T m_DefaultItem;

		private int m_Capacity;

		private int m_RolloverSize;

		private int m_Count;

		private const int k_DefaultCapacity = 4;

		public int Count => m_Count;

		public T current
		{
			get
			{
				if (index > 0)
				{
					return itemStack[index - 1];
				}
				return itemStack[0];
			}
		}

		public int rolloverSize
		{
			get
			{
				return m_RolloverSize;
			}
			set
			{
				m_RolloverSize = value;
			}
		}

		public TextProcessingStack(T[] stack)
		{
			itemStack = stack;
			m_Capacity = stack.Length;
			index = 0;
			m_RolloverSize = 0;
			m_DefaultItem = default(T);
			m_Count = 0;
		}

		public TextProcessingStack(int capacity)
		{
			itemStack = new T[capacity];
			m_Capacity = capacity;
			index = 0;
			m_RolloverSize = 0;
			m_DefaultItem = default(T);
			m_Count = 0;
		}

		public TextProcessingStack(int capacity, int rolloverSize)
		{
			itemStack = new T[capacity];
			m_Capacity = capacity;
			index = 0;
			m_RolloverSize = rolloverSize;
			m_DefaultItem = default(T);
			m_Count = 0;
		}

		internal static void SetDefault(TextProcessingStack<T>[] stack, T item)
		{
			for (int i = 0; i < stack.Length; i++)
			{
				stack[i].SetDefault(item);
			}
		}

		public void Clear()
		{
			index = 0;
			m_Count = 0;
		}

		public void SetDefault(T item)
		{
			if (itemStack == null)
			{
				m_Capacity = 4;
				itemStack = new T[m_Capacity];
				m_DefaultItem = default(T);
			}
			itemStack[0] = item;
			index = 1;
			m_Count = 1;
		}

		public void Add(T item)
		{
			if (index < itemStack.Length)
			{
				itemStack[index] = item;
				index++;
			}
		}

		public T Remove()
		{
			index--;
			m_Count--;
			if (index <= 0)
			{
				m_Count = 0;
				index = 1;
				return itemStack[0];
			}
			return itemStack[index - 1];
		}

		public void Push(T item)
		{
			if (index == m_Capacity)
			{
				m_Capacity *= 2;
				if (m_Capacity == 0)
				{
					m_Capacity = 4;
				}
				Array.Resize(ref itemStack, m_Capacity);
			}
			itemStack[index] = item;
			if (m_RolloverSize == 0)
			{
				index++;
				m_Count++;
			}
			else
			{
				index = (index + 1) % m_RolloverSize;
				m_Count = ((m_Count < m_RolloverSize) ? (m_Count + 1) : m_RolloverSize);
			}
		}

		public T Pop()
		{
			if (index == 0 && m_RolloverSize == 0)
			{
				return default(T);
			}
			if (m_RolloverSize == 0)
			{
				index--;
			}
			else
			{
				index = (index - 1) % m_RolloverSize;
				index = ((index < 0) ? (index + m_RolloverSize) : index);
			}
			T result = itemStack[index];
			itemStack[index] = m_DefaultItem;
			m_Count = ((m_Count > 0) ? (m_Count - 1) : 0);
			return result;
		}

		public T Peek()
		{
			if (index == 0)
			{
				return m_DefaultItem;
			}
			return itemStack[index - 1];
		}

		public T CurrentItem()
		{
			if (index > 0)
			{
				return itemStack[index - 1];
			}
			return itemStack[0];
		}

		public T PreviousItem()
		{
			if (index > 1)
			{
				return itemStack[index - 2];
			}
			return itemStack[0];
		}
	}
	internal class TextResourceManager
	{
		private struct FontAssetRef(int nameHashCode, int familyNameHashCode, int styleNameHashCode, FontAsset fontAsset)
		{
			public int nameHashCode = ((nameHashCode != 0) ? nameHashCode : familyNameHashCode);

			public int familyNameHashCode = familyNameHashCode;

			public int styleNameHashCode = styleNameHashCode;

			public long familyNameAndStyleHashCode = ((long)styleNameHashCode << 32) | (uint)familyNameHashCode;

			public readonly FontAsset fontAsset = fontAsset;
		}

		private static readonly Dictionary<int, FontAssetRef> s_FontAssetReferences = new Dictionary<int, FontAssetRef>();

		private static readonly Dictionary<int, FontAsset> s_FontAssetNameReferenceLookup = new Dictionary<int, FontAsset>();

		private static readonly Dictionary<long, FontAsset> s_FontAssetFamilyNameAndStyleReferenceLookup = new Dictionary<long, FontAsset>();

		private static readonly List<int> s_FontAssetRemovalList = new List<int>(16);

		private static readonly int k_RegularStyleHashCode = TextUtilities.GetHashCodeCaseInSensitive("Regular");

		internal static void AddFontAsset(FontAsset fontAsset)
		{
			int instanceID = fontAsset.instanceID;
			if (!s_FontAssetReferences.ContainsKey(instanceID))
			{
				FontAssetRef value = new FontAssetRef(fontAsset.hashCode, fontAsset.familyNameHashCode, fontAsset.styleNameHashCode, fontAsset);
				s_FontAssetReferences.Add(instanceID, value);
				if (!s_FontAssetNameReferenceLookup.ContainsKey(value.nameHashCode))
				{
					s_FontAssetNameReferenceLookup.Add(value.nameHashCode, fontAsset);
				}
				if (!s_FontAssetFamilyNameAndStyleReferenceLookup.ContainsKey(value.familyNameAndStyleHashCode))
				{
					s_FontAssetFamilyNameAndStyleReferenceLookup.Add(value.familyNameAndStyleHashCode, fontAsset);
				}
				return;
			}
			FontAssetRef value2 = s_FontAssetReferences[instanceID];
			if (value2.nameHashCode == fontAsset.hashCode && value2.familyNameHashCode == fontAsset.familyNameHashCode && value2.styleNameHashCode == fontAsset.styleNameHashCode)
			{
				return;
			}
			if (value2.nameHashCode != fontAsset.hashCode)
			{
				s_FontAssetNameReferenceLookup.Remove(value2.nameHashCode);
				value2.nameHashCode = fontAsset.hashCode;
				if (!s_FontAssetNameReferenceLookup.ContainsKey(value2.nameHashCode))
				{
					s_FontAssetNameReferenceLookup.Add(value2.nameHashCode, fontAsset);
				}
			}
			if (value2.familyNameHashCode != fontAsset.familyNameHashCode || value2.styleNameHashCode != fontAsset.styleNameHashCode)
			{
				s_FontAssetFamilyNameAndStyleReferenceLookup.Remove(value2.familyNameAndStyleHashCode);
				value2.familyNameHashCode = fontAsset.familyNameHashCode;
				value2.styleNameHashCode = fontAsset.styleNameHashCode;
				value2.familyNameAndStyleHashCode = ((long)fontAsset.styleNameHashCode << 32) | (uint)fontAsset.familyNameHashCode;
				if (!s_FontAssetFamilyNameAndStyleReferenceLookup.ContainsKey(value2.familyNameAndStyleHashCode))
				{
					s_FontAssetFamilyNameAndStyleReferenceLookup.Add(value2.familyNameAndStyleHashCode, fontAsset);
				}
			}
			s_FontAssetReferences[instanceID] = value2;
		}

		public static void RemoveFontAsset(FontAsset fontAsset)
		{
			int instanceID = fontAsset.instanceID;
			if (s_FontAssetReferences.TryGetValue(instanceID, out var value))
			{
				s_FontAssetNameReferenceLookup.Remove(value.nameHashCode);
				s_FontAssetFamilyNameAndStyleReferenceLookup.Remove(value.familyNameAndStyleHashCode);
				s_FontAssetReferences.Remove(instanceID);
			}
		}

		internal static bool TryGetFontAssetByName(int nameHashcode, out FontAsset fontAsset)
		{
			fontAsset = null;
			return s_FontAssetNameReferenceLookup.TryGetValue(nameHashcode, out fontAsset);
		}

		internal static bool TryGetFontAssetByFamilyName(int familyNameHashCode, int styleNameHashCode, out FontAsset fontAsset)
		{
			fontAsset = null;
			if (styleNameHashCode == 0)
			{
				styleNameHashCode = k_RegularStyleHashCode;
			}
			long key = ((long)styleNameHashCode << 32) | (uint)familyNameHashCode;
			return s_FontAssetFamilyNameAndStyleReferenceLookup.TryGetValue(key, out fontAsset);
		}

		public static void ClearFontAssetGlyphCache()
		{
			RebuildFontAssetCache();
		}

		internal static void RebuildFontAssetCache()
		{
			foreach (KeyValuePair<int, FontAssetRef> s_FontAssetReference in s_FontAssetReferences)
			{
				FontAssetRef value = s_FontAssetReference.Value;
				FontAsset fontAsset = value.fontAsset;
				if (fontAsset == null)
				{
					s_FontAssetNameReferenceLookup.Remove(value.nameHashCode);
					s_FontAssetFamilyNameAndStyleReferenceLookup.Remove(value.familyNameAndStyleHashCode);
					s_FontAssetRemovalList.Add(s_FontAssetReference.Key);
				}
				else
				{
					fontAsset.InitializeCharacterLookupDictionary();
					fontAsset.AddSynthesizedCharactersAndFaceMetrics();
				}
			}
			for (int i = 0; i < s_FontAssetRemovalList.Count; i++)
			{
				s_FontAssetReferences.Remove(s_FontAssetRemovalList[i]);
			}
			s_FontAssetRemovalList.Clear();
			TextEventManager.ON_FONT_PROPERTY_CHANGED(isChanged: true, null);
		}
	}
	[ExcludeFromDocs]
	public static class TextShaderUtilities
	{
		public static int ID_MainTex;

		public static int ID_FaceTex;

		public static int ID_FaceColor;

		public static int ID_FaceDilate;

		public static int ID_Shininess;

		public static int ID_OutlineOffset1;

		public static int ID_OutlineOffset2;

		public static int ID_OutlineOffset3;

		public static int ID_OutlineMode;

		public static int ID_IsoPerimeter;

		public static int ID_Softness;

		public static int ID_UnderlayColor;

		public static int ID_UnderlayOffsetX;

		public static int ID_UnderlayOffsetY;

		public static int ID_UnderlayDilate;

		public static int ID_UnderlaySoftness;

		public static int ID_UnderlayOffset;

		public static int ID_UnderlayIsoPerimeter;

		public static int ID_WeightNormal;

		public static int ID_WeightBold;

		public static int ID_OutlineTex;

		public static int ID_OutlineWidth;

		public static int ID_OutlineSoftness;

		public static int ID_OutlineColor;

		public static int ID_Outline2Color;

		public static int ID_Outline2Width;

		public static int ID_Padding;

		public static int ID_GradientScale;

		public static int ID_ScaleX;

		public static int ID_ScaleY;

		public static int ID_PerspectiveFilter;

		public static int ID_Sharpness;

		public static int ID_TextureWidth;

		public static int ID_TextureHeight;

		public static int ID_BevelAmount;

		public static int ID_GlowColor;

		public static int ID_GlowOffset;

		public static int ID_GlowPower;

		public static int ID_GlowOuter;

		public static int ID_GlowInner;

		public static int ID_LightAngle;

		public static int ID_EnvMap;

		public static int ID_EnvMatrix;

		public static int ID_EnvMatrixRotation;

		public static int ID_MaskCoord;

		public static int ID_ClipRect;

		public static int ID_MaskSoftnessX;

		public static int ID_MaskSoftnessY;

		public static int ID_VertexOffsetX;

		public static int ID_VertexOffsetY;

		public static int ID_UseClipRect;

		public static int ID_StencilID;

		public static int ID_StencilOp;

		public static int ID_StencilComp;

		public static int ID_StencilReadMask;

		public static int ID_StencilWriteMask;

		public static int ID_ShaderFlags;

		public static int ID_ScaleRatio_A;

		public static int ID_ScaleRatio_B;

		public static int ID_ScaleRatio_C;

		public static string Keyword_Bevel;

		public static string Keyword_Glow;

		public static string Keyword_Underlay;

		public static string Keyword_Ratios;

		public static string Keyword_MASK_SOFT;

		public static string Keyword_MASK_HARD;

		public static string Keyword_MASK_TEX;

		public static string Keyword_Outline;

		public static string ShaderTag_ZTestMode;

		public static string ShaderTag_CullMode;

		private static float m_clamp;

		public static bool isInitialized;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static readonly string k_SDFText;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static readonly string k_BitmapText;

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal static readonly string k_SpriteText;

		private static Shader k_ShaderRef_MobileSDF;

		private static Shader k_ShaderRef_MobileBitmap;

		private static Shader k_ShaderRef_Sprite;

		internal static Shader ShaderRef_MobileSDF
		{
			[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
			get
			{
				if ((object)k_ShaderRef_MobileSDF == null)
				{
					k_ShaderRef_MobileSDF = Shader.Find(k_SDFText);
				}
				return k_ShaderRef_MobileSDF;
			}
		}

		internal static Shader ShaderRef_MobileBitmap
		{
			get
			{
				if (k_ShaderRef_MobileBitmap == null)
				{
					k_ShaderRef_MobileBitmap = Shader.Find(k_BitmapText);
				}
				return k_ShaderRef_MobileBitmap;
			}
		}

		internal static Shader ShaderRef_Sprite
		{
			get
			{
				if (k_ShaderRef_Sprite == null)
				{
					k_ShaderRef_Sprite = Shader.Find("Text/Sprite");
					if (k_ShaderRef_Sprite == null)
					{
						k_ShaderRef_Sprite = Shader.Find(k_SpriteText);
					}
				}
				return k_ShaderRef_Sprite;
			}
		}

		static TextShaderUtilities()
		{
			Keyword_Bevel = "BEVEL_ON";
			Keyword_Glow = "GLOW_ON";
			Keyword_Underlay = "UNDERLAY_ON";
			Keyword_Ratios = "RATIOS_OFF";
			Keyword_MASK_SOFT = "MASK_SOFT";
			Keyword_MASK_HARD = "MASK_HARD";
			Keyword_MASK_TEX = "MASK_TEX";
			Keyword_Outline = "OUTLINE_ON";
			ShaderTag_ZTestMode = "unity_GUIZTestMode";
			ShaderTag_CullMode = "_CullMode";
			m_clamp = 1f;
			isInitialized = false;
			k_SDFText = "Hidden/TextCore/Distance Field SSD";
			k_BitmapText = "Hidden/Internal-GUITextureClipText";
			k_SpriteText = "Hidden/TextCore/Sprite";
			GetShaderPropertyIDs();
		}

		internal static void GetShaderPropertyIDs()
		{
			if (!isInitialized)
			{
				isInitialized = true;
				ID_MainTex = Shader.PropertyToID("_MainTex");
				ID_FaceTex = Shader.PropertyToID("_FaceTex");
				ID_FaceColor = Shader.PropertyToID("_FaceColor");
				ID_FaceDilate = Shader.PropertyToID("_FaceDilate");
				ID_Shininess = Shader.PropertyToID("_FaceShininess");
				ID_OutlineOffset1 = Shader.PropertyToID("_OutlineOffset1");
				ID_OutlineOffset2 = Shader.PropertyToID("_OutlineOffset2");
				ID_OutlineOffset3 = Shader.PropertyToID("_OutlineOffset3");
				ID_OutlineMode = Shader.PropertyToID("_OutlineMode");
				ID_IsoPerimeter = Shader.PropertyToID("_IsoPerimeter");
				ID_Softness = Shader.PropertyToID("_Softness");
				ID_UnderlayColor = Shader.PropertyToID("_UnderlayColor");
				ID_UnderlayOffsetX = Shader.PropertyToID("_UnderlayOffsetX");
				ID_UnderlayOffsetY = Shader.PropertyToID("_UnderlayOffsetY");
				ID_UnderlayDilate = Shader.PropertyToID("_UnderlayDilate");
				ID_UnderlaySoftness = Shader.PropertyToID("_UnderlaySoftness");
				ID_UnderlayOffset = Shader.PropertyToID("_UnderlayOffset");
				ID_UnderlayIsoPerimeter = Shader.PropertyToID("_UnderlayIsoPerimeter");
				ID_WeightNormal = Shader.PropertyToID("_WeightNormal");
				ID_WeightBold = Shader.PropertyToID("_WeightBold");
				ID_OutlineTex = Shader.PropertyToID("_OutlineTex");
				ID_OutlineWidth = Shader.PropertyToID("_OutlineWidth");
				ID_OutlineSoftness = Shader.PropertyToID("_OutlineSoftness");
				ID_OutlineColor = Shader.PropertyToID("_OutlineColor");
				ID_Outline2Color = Shader.PropertyToID("_Outline2Color");
				ID_Outline2Width = Shader.PropertyToID("_Outline2Width");
				ID_Padding = Shader.PropertyToID("_Padding");
				ID_GradientScale = Shader.PropertyToID("_GradientScale");
				ID_ScaleX = Shader.PropertyToID("_ScaleX");
				ID_ScaleY = Shader.PropertyToID("_ScaleY");
				ID_PerspectiveFilter = Shader.PropertyToID("_PerspectiveFilter");
				ID_Sharpness = Shader.PropertyToID("_Sharpness");
				ID_TextureWidth = Shader.PropertyToID("_TextureWidth");
				ID_TextureHeight = Shader.PropertyToID("_TextureHeight");
				ID_BevelAmount = Shader.PropertyToID("_Bevel");
				ID_LightAngle = Shader.PropertyToID("_LightAngle");
				ID_EnvMap = Shader.PropertyToID("_Cube");
				ID_EnvMatrix = Shader.PropertyToID("_EnvMatrix");
				ID_EnvMatrixRotation = Shader.PropertyToID("_EnvMatrixRotation");
				ID_GlowColor = Shader.PropertyToID("_GlowColor");
				ID_GlowOffset = Shader.PropertyToID("_GlowOffset");
				ID_GlowPower = Shader.PropertyToID("_GlowPower");
				ID_GlowOuter = Shader.PropertyToID("_GlowOuter");
				ID_GlowInner = Shader.PropertyToID("_GlowInner");
				ID_MaskCoord = Shader.PropertyToID("_MaskCoord");
				ID_ClipRect = Shader.PropertyToID("_ClipRect");
				ID_UseClipRect = Shader.PropertyToID("_UseClipRect");
				ID_MaskSoftnessX = Shader.PropertyToID("_MaskSoftnessX");
				ID_MaskSoftnessY = Shader.PropertyToID("_MaskSoftnessY");
				ID_VertexOffsetX = Shader.PropertyToID("_VertexOffsetX");
				ID_VertexOffsetY = Shader.PropertyToID("_VertexOffsetY");
				ID_StencilID = Shader.PropertyToID("_Stencil");
				ID_StencilOp = Shader.PropertyToID("_StencilOp");
				ID_StencilComp = Shader.PropertyToID("_StencilComp");
				ID_StencilReadMask = Shader.PropertyToID("_StencilReadMask");
				ID_StencilWriteMask = Shader.PropertyToID("_StencilWriteMask");
				ID_ShaderFlags = Shader.PropertyToID("_ShaderFlags");
				ID_ScaleRatio_A = Shader.PropertyToID("_ScaleRatioA");
				ID_ScaleRatio_B = Shader.PropertyToID("_ScaleRatioB");
				ID_ScaleRatio_C = Shader.PropertyToID("_ScaleRatioC");
			}
		}

		private static void UpdateShaderRatios(Material mat)
		{
			float num = 1f;
			float num2 = 1f;
			float num3 = 1f;
			bool flag = !Enumerable.Contains(mat.shaderKeywords, Keyword_Ratios);
			if (mat.HasProperty(ID_GradientScale) && mat.HasProperty(ID_FaceDilate))
			{
				float num4 = mat.GetFloat(ID_GradientScale);
				float num5 = mat.GetFloat(ID_FaceDilate);
				float num6 = mat.GetFloat(ID_OutlineWidth);
				float num7 = mat.GetFloat(ID_OutlineSoftness);
				float num8 = Mathf.Max(mat.GetFloat(ID_WeightNormal), mat.GetFloat(ID_WeightBold)) / 4f;
				float num9 = Mathf.Max(1f, num8 + num5 + num6 + num7);
				num = (flag ? ((num4 - m_clamp) / (num4 * num9)) : 1f);
				mat.SetFloat(ID_ScaleRatio_A, num);
				if (mat.HasProperty(ID_GlowOffset))
				{
					float num10 = mat.GetFloat(ID_GlowOffset);
					float num11 = mat.GetFloat(ID_GlowOuter);
					float num12 = (num8 + num5) * (num4 - m_clamp);
					num9 = Mathf.Max(1f, num10 + num11);
					num2 = (flag ? (Mathf.Max(0f, num4 - m_clamp - num12) / (num4 * num9)) : 1f);
					mat.SetFloat(ID_ScaleRatio_B, num2);
				}
				if (mat.HasProperty(ID_UnderlayOffsetX))
				{
					float f = mat.GetFloat(ID_UnderlayOffsetX);
					float f2 = mat.GetFloat(ID_UnderlayOffsetY);
					float num13 = mat.GetFloat(ID_UnderlayDilate);
					float num14 = mat.GetFloat(ID_UnderlaySoftness);
					float num15 = (num8 + num5) * (num4 - m_clamp);
					num9 = Mathf.Max(1f, Mathf.Max(Mathf.Abs(f), Mathf.Abs(f2)) + num13 + num14);
					num3 = (flag ? (Mathf.Max(0f, num4 - m_clamp - num15) / (num4 * num9)) : 1f);
					mat.SetFloat(ID_ScaleRatio_C, num3);
				}
			}
		}

		internal static Vector4 GetFontExtent(Material material)
		{
			return Vector4.zero;
		}

		internal static bool IsMaskingEnabled(Material material)
		{
			if (material == null || !material.HasProperty(ID_ClipRect))
			{
				return false;
			}
			if (Enumerable.Contains(material.shaderKeywords, Keyword_MASK_SOFT) || Enumerable.Contains(material.shaderKeywords, Keyword_MASK_HARD) || Enumerable.Contains(material.shaderKeywords, Keyword_MASK_TEX))
			{
				return true;
			}
			return false;
		}

		internal static float GetPadding(Material material, bool enableExtraPadding, bool isBold)
		{
			if (!isInitialized)
			{
				GetShaderPropertyIDs();
			}
			if (material == null)
			{
				return 0f;
			}
			int num = (enableExtraPadding ? 4 : 0);
			if (!material.HasProperty(ID_GradientScale))
			{
				if (material.HasProperty(ID_Padding))
				{
					num += (int)material.GetFloat(ID_Padding);
				}
				return (float)num + 1f;
			}
			if (material.HasProperty(ID_IsoPerimeter))
			{
				return ComputePaddingForProperties(material) + 0.25f + (float)num;
			}
			Vector4 zero = Vector4.zero;
			Vector4 zero2 = Vector4.zero;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			float num11 = 0f;
			UpdateShaderRatios(material);
			string[] shaderKeywords = material.shaderKeywords;
			if (material.HasProperty(ID_ScaleRatio_A))
			{
				num5 = material.GetFloat(ID_ScaleRatio_A);
			}
			if (material.HasProperty(ID_FaceDilate))
			{
				num2 = material.GetFloat(ID_FaceDilate) * num5;
			}
			if (material.HasProperty(ID_OutlineSoftness))
			{
				num3 = material.GetFloat(ID_OutlineSoftness) * num5;
			}
			if (material.HasProperty(ID_OutlineWidth))
			{
				num4 = material.GetFloat(ID_OutlineWidth) * num5;
			}
			num11 = num4 + num3 + num2;
			if (material.HasProperty(ID_GlowOffset) && Enumerable.Contains(shaderKeywords, Keyword_Glow))
			{
				if (material.HasProperty(ID_ScaleRatio_B))
				{
					num6 = material.GetFloat(ID_ScaleRatio_B);
				}
				num8 = material.GetFloat(ID_GlowOffset) * num6;
				num9 = material.GetFloat(ID_GlowOuter) * num6;
			}
			num11 = Mathf.Max(num11, num2 + num8 + num9);
			if (material.HasProperty(ID_UnderlaySoftness) && Enumerable.Contains(shaderKeywords, Keyword_Underlay))
			{
				if (material.HasProperty(ID_ScaleRatio_C))
				{
					num7 = material.GetFloat(ID_ScaleRatio_C);
				}
				float num12 = 0f;
				float num13 = 0f;
				float num14 = 0f;
				float num15 = 0f;
				if (material.HasProperty(ID_UnderlayOffset))
				{
					Vector2 vector = material.GetVector(ID_UnderlayOffset);
					num12 = vector.x;
					num13 = vector.y;
					num14 = material.GetFloat(ID_UnderlayDilate);
					num15 = material.GetFloat(ID_UnderlaySoftness);
				}
				else if (material.HasProperty(ID_UnderlayOffsetX))
				{
					num12 = material.GetFloat(ID_UnderlayOffsetX) * num7;
					num13 = material.GetFloat(ID_UnderlayOffsetY) * num7;
					num14 = material.GetFloat(ID_UnderlayDilate) * num7;
					num15 = material.GetFloat(ID_UnderlaySoftness) * num7;
				}
				zero.x = Mathf.Max(zero.x, num2 + num14 + num15 - num12);
				zero.y = Mathf.Max(zero.y, num2 + num14 + num15 - num13);
				zero.z = Mathf.Max(zero.z, num2 + num14 + num15 + num12);
				zero.w = Mathf.Max(zero.w, num2 + num14 + num15 + num13);
			}
			zero.x = Mathf.Max(zero.x, num11);
			zero.y = Mathf.Max(zero.y, num11);
			zero.z = Mathf.Max(zero.z, num11);
			zero.w = Mathf.Max(zero.w, num11);
			zero.x += num;
			zero.y += num;
			zero.z += num;
			zero.w += num;
			zero.x = Mathf.Min(zero.x, 1f);
			zero.y = Mathf.Min(zero.y, 1f);
			zero.z = Mathf.Min(zero.z, 1f);
			zero.w = Mathf.Min(zero.w, 1f);
			zero2.x = ((zero2.x < zero.x) ? zero.x : zero2.x);
			zero2.y = ((zero2.y < zero.y) ? zero.y : zero2.y);
			zero2.z = ((zero2.z < zero.z) ? zero.z : zero2.z);
			zero2.w = ((zero2.w < zero.w) ? zero.w : zero2.w);
			num10 = material.GetFloat(ID_GradientScale);
			zero *= num10;
			num11 = Mathf.Max(zero.x, zero.y);
			num11 = Mathf.Max(zero.z, num11);
			num11 = Mathf.Max(zero.w, num11);
			return num11 + 1.25f;
		}

		private static float ComputePaddingForProperties(Material mat)
		{
			Vector4 vector = mat.GetVector(ID_IsoPerimeter);
			Vector2 vector2 = mat.GetVector(ID_OutlineOffset1);
			Vector2 vector3 = mat.GetVector(ID_OutlineOffset2);
			Vector2 vector4 = mat.GetVector(ID_OutlineOffset3);
			bool flag = mat.GetFloat(ID_OutlineMode) != 0f;
			Vector4 vector5 = mat.GetVector(ID_Softness);
			float num = mat.GetFloat(ID_GradientScale);
			float a = Mathf.Max(0f, vector.x + vector5.x * 0.5f);
			if (!flag)
			{
				a = Mathf.Max(a, vector.y + vector5.y * 0.5f + Mathf.Max(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y)));
				a = Mathf.Max(a, vector.z + vector5.z * 0.5f + Mathf.Max(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y)));
				a = Mathf.Max(a, vector.w + vector5.w * 0.5f + Mathf.Max(Mathf.Abs(vector4.x), Mathf.Abs(vector4.y)));
			}
			else
			{
				float num2 = Mathf.Max(Mathf.Abs(vector2.x), Mathf.Abs(vector2.y));
				float num3 = Mathf.Max(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y));
				a = Mathf.Max(a, vector.y + vector5.y * 0.5f + num2);
				a = Mathf.Max(a, vector.z + vector5.z * 0.5f + num3);
				float num4 = Mathf.Max(num2, num3);
				a += Mathf.Max(0f, vector.w + vector5.w * 0.5f - Mathf.Max(0f, a - num4));
			}
			Vector2 vector6 = mat.GetVector(ID_UnderlayOffset);
			float num5 = mat.GetFloat(ID_UnderlayDilate);
			float num6 = mat.GetFloat(ID_UnderlaySoftness);
			a = Mathf.Max(a, num5 + num6 * 0.5f + Mathf.Max(Mathf.Abs(vector6.x), Mathf.Abs(vector6.y)));
			return a * num;
		}

		internal static float GetPadding(Material[] materials, bool enableExtraPadding, bool isBold)
		{
			if (!isInitialized)
			{
				GetShaderPropertyIDs();
			}
			if (materials == null)
			{
				return 0f;
			}
			int num = (enableExtraPadding ? 4 : 0);
			if (materials[0].HasProperty(ID_Padding))
			{
				return (float)num + materials[0].GetFloat(ID_Padding);
			}
			Vector4 zero = Vector4.zero;
			Vector4 zero2 = Vector4.zero;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float num9 = 0f;
			float num10 = 0f;
			for (int i = 0; i < materials.Length; i++)
			{
				UpdateShaderRatios(materials[i]);
				string[] shaderKeywords = materials[i].shaderKeywords;
				if (materials[i].HasProperty(ID_ScaleRatio_A))
				{
					num5 = materials[i].GetFloat(ID_ScaleRatio_A);
				}
				if (materials[i].HasProperty(ID_FaceDilate))
				{
					num2 = materials[i].GetFloat(ID_FaceDilate) * num5;
				}
				if (materials[i].HasProperty(ID_OutlineSoftness))
				{
					num3 = materials[i].GetFloat(ID_OutlineSoftness) * num5;
				}
				if (materials[i].HasProperty(ID_OutlineWidth))
				{
					num4 = materials[i].GetFloat(ID_OutlineWidth) * num5;
				}
				num10 = num4 + num3 + num2;
				if (materials[i].HasProperty(ID_GlowOffset) && Enumerable.Contains(shaderKeywords, Keyword_Glow))
				{
					if (materials[i].HasProperty(ID_ScaleRatio_B))
					{
						num6 = materials[i].GetFloat(ID_ScaleRatio_B);
					}
					num8 = materials[i].GetFloat(ID_GlowOffset) * num6;
					num9 = materials[i].GetFloat(ID_GlowOuter) * num6;
				}
				num10 = Mathf.Max(num10, num2 + num8 + num9);
				if (materials[i].HasProperty(ID_UnderlaySoftness) && Enumerable.Contains(shaderKeywords, Keyword_Underlay))
				{
					if (materials[i].HasProperty(ID_ScaleRatio_C))
					{
						num7 = materials[i].GetFloat(ID_ScaleRatio_C);
					}
					float num11 = materials[i].GetFloat(ID_UnderlayOffsetX) * num7;
					float num12 = materials[i].GetFloat(ID_UnderlayOffsetY) * num7;
					float num13 = materials[i].GetFloat(ID_UnderlayDilate) * num7;
					float num14 = materials[i].GetFloat(ID_UnderlaySoftness) * num7;
					zero.x = Mathf.Max(zero.x, num2 + num13 + num14 - num11);
					zero.y = Mathf.Max(zero.y, num2 + num13 + num14 - num12);
					zero.z = Mathf.Max(zero.z, num2 + num13 + num14 + num11);
					zero.w = Mathf.Max(zero.w, num2 + num13 + num14 + num12);
				}
				zero.x = Mathf.Max(zero.x, num10);
				zero.y = Mathf.Max(zero.y, num10);
				zero.z = Mathf.Max(zero.z, num10);
				zero.w = Mathf.Max(zero.w, num10);
				zero.x += num;
				zero.y += num;
				zero.z += num;
				zero.w += num;
				zero.x = Mathf.Min(zero.x, 1f);
				zero.y = Mathf.Min(zero.y, 1f);
				zero.z = Mathf.Min(zero.z, 1f);
				zero.w = Mathf.Min(zero.w, 1f);
				zero2.x = ((zero2.x < zero.x) ? zero.x : zero2.x);
				zero2.y = ((zero2.y < zero.y) ? zero.y : zero2.y);
				zero2.z = ((zero2.z < zero.z) ? zero.z : zero2.z);
				zero2.w = ((zero2.w < zero.w) ? zero.w : zero2.w);
			}
			float num15 = materials[0].GetFloat(ID_GradientScale);
			zero *= num15;
			num10 = Mathf.Max(zero.x, zero.y);
			num10 = Mathf.Max(zero.z, num10);
			num10 = Mathf.Max(zero.w, num10);
			return num10 + 0.25f;
		}
	}
	internal static class TextUtilities
	{
		private const string k_LookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-";

		private const string k_LookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";

		internal static void ResizeArray<T>(ref T[] array)
		{
			int newSize = NextPowerOfTwo(array.Length);
			Array.Resize(ref array, newSize);
		}

		internal static void ResizeArray<T>(ref T[] array, int size)
		{
			size = NextPowerOfTwo(size);
			Array.Resize(ref array, size);
		}

		internal static int NextPowerOfTwo(int v)
		{
			v |= v >> 16;
			v |= v >> 8;
			v |= v >> 4;
			v |= v >> 2;
			v |= v >> 1;
			return v + 1;
		}

		internal static char ToLowerFast(char c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"[c];
		}

		internal static char ToUpperFast(char c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[c];
		}

		internal static uint ToUpperASCIIFast(uint c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-"[(int)c];
		}

		internal static uint ToLowerASCIIFast(uint c)
		{
			if (c > "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-".Length - 1)
			{
				return c;
			}
			return "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-"[(int)c];
		}

		public static int GetHashCodeCaseSensitive(string s)
		{
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num) ^ s[i];
			}
			return num;
		}

		public static int GetHashCodeCaseInSensitive(string s)
		{
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num) ^ ToUpperFast(s[i]);
			}
			return num;
		}

		public static int GetHashCode(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num) ^ ToUpperFast(s[i]);
			}
			return num;
		}

		public static int GetSimpleHashCode(string s)
		{
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num) ^ s[i];
			}
			return num;
		}

		public static uint GetSimpleHashCodeLowercase(string s)
		{
			uint num = 0u;
			for (int i = 0; i < s.Length; i++)
			{
				num = ((num << 5) + num) ^ ToLowerFast(s[i]);
			}
			return num;
		}

		internal static uint ConvertToUTF32(uint highSurrogate, uint lowSurrogate)
		{
			return (highSurrogate - 55296) * 1024 + (lowSurrogate - 56320 + 65536);
		}

		internal static uint ReadUTF16(uint[] text, int index)
		{
			uint num = 0u;
			num += HexToInt((char)text[index]) << 12;
			num += HexToInt((char)text[index + 1]) << 8;
			num += HexToInt((char)text[index + 2]) << 4;
			return num + HexToInt((char)text[index + 3]);
		}

		internal static uint ReadUTF32(uint[] text, int index)
		{
			uint num = 0u;
			num += HexToInt((char)text[index]) << 30;
			num += HexToInt((char)text[index + 1]) << 24;
			num += HexToInt((char)text[index + 2]) << 20;
			num += HexToInt((char)text[index + 3]) << 16;
			num += HexToInt((char)text[index + 4]) << 12;
			num += HexToInt((char)text[index + 5]) << 8;
			num += HexToInt((char)text[index + 6]) << 4;
			return num + HexToInt((char)text[index + 7]);
		}

		private static uint HexToInt(char hex)
		{
			return hex switch
			{
				'0' => 0u, 
				'1' => 1u, 
				'2' => 2u, 
				'3' => 3u, 
				'4' => 4u, 
				'5' => 5u, 
				'6' => 6u, 
				'7' => 7u, 
				'8' => 8u, 
				'9' => 9u, 
				'A' => 10u, 
				'B' => 11u, 
				'C' => 12u, 
				'D' => 13u, 
				'E' => 14u, 
				'F' => 15u, 
				'a' => 10u, 
				'b' => 11u, 
				'c' => 12u, 
				'd' => 13u, 
				'e' => 14u, 
				'f' => 15u, 
				_ => 15u, 
			};
		}

		public static uint StringHexToInt(string s)
		{
			uint num = 0u;
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				num += HexToInt(s[i]) * (uint)Mathf.Pow(16f, length - 1 - i);
			}
			return num;
		}

		internal static string UintToString(this List<uint> unicodes)
		{
			char[] array = new char[unicodes.Count];
			for (int i = 0; i < unicodes.Count; i++)
			{
				array[i] = (char)unicodes[i];
			}
			return new string(array);
		}

		internal static int GetTextFontWeightIndex(TextFontWeight fontWeight)
		{
			return fontWeight switch
			{
				TextFontWeight.Thin => 1, 
				TextFontWeight.ExtraLight => 2, 
				TextFontWeight.Light => 3, 
				TextFontWeight.Regular => 4, 
				TextFontWeight.Medium => 5, 
				TextFontWeight.SemiBold => 6, 
				TextFontWeight.Bold => 7, 
				TextFontWeight.Heavy => 8, 
				TextFontWeight.Black => 9, 
				_ => 4, 
			};
		}
	}
	[Serializable]
	public class UnicodeLineBreakingRules
	{
		[SerializeField]
		private UnityEngine.TextAsset m_UnicodeLineBreakingRules;

		[SerializeField]
		private UnityEngine.TextAsset m_LeadingCharacters;

		[SerializeField]
		private UnityEngine.TextAsset m_FollowingCharacters;

		[SerializeField]
		private bool m_UseModernHangulLineBreakingRules;

		private HashSet<uint> m_LeadingCharactersLookup;

		private HashSet<uint> m_FollowingCharactersLookup;

		public UnityEngine.TextAsset lineBreakingRules => m_UnicodeLineBreakingRules;

		public UnityEngine.TextAsset leadingCharacters => m_LeadingCharacters;

		public UnityEngine.TextAsset followingCharacters => m_FollowingCharacters;

		internal HashSet<uint> leadingCharactersLookup
		{
			get
			{
				if (m_LeadingCharactersLookup == null)
				{
					LoadLineBreakingRules();
				}
				return m_LeadingCharactersLookup;
			}
			set
			{
				m_LeadingCharactersLookup = value;
			}
		}

		internal HashSet<uint> followingCharactersLookup
		{
			get
			{
				if (m_LeadingCharactersLookup == null)
				{
					LoadLineBreakingRules();
				}
				return m_FollowingCharactersLookup;
			}
			set
			{
				m_FollowingCharactersLookup = value;
			}
		}

		public bool useModernHangulLineBreakingRules
		{
			get
			{
				return m_UseModernHangulLineBreakingRules;
			}
			set
			{
				m_UseModernHangulLineBreakingRules = value;
			}
		}

		[VisibleToOtherModules(new string[] { "UnityEngine.UIElementsModule" })]
		internal void LoadLineBreakingRules()
		{
			if (m_LeadingCharactersLookup == null)
			{
				if (m_LeadingCharacters == null)
				{
					m_LeadingCharacters = Resources.Load<UnityEngine.TextAsset>("LineBreaking Leading Characters");
				}
				m_LeadingCharactersLookup = ((m_LeadingCharacters != null) ? GetCharacters(m_LeadingCharacters) : new HashSet<uint>());
				if (m_FollowingCharacters == null)
				{
					m_FollowingCharacters = Resources.Load<UnityEngine.TextAsset>("LineBreaking Following Characters");
				}
				m_FollowingCharactersLookup = ((m_FollowingCharacters != null) ? GetCharacters(m_FollowingCharacters) : new HashSet<uint>());
			}
		}

		internal void LoadLineBreakingRules(UnityEngine.TextAsset leadingRules, UnityEngine.TextAsset followingRules)
		{
			if (m_LeadingCharactersLookup == null)
			{
				if (leadingRules == null)
				{
					leadingRules = Resources.Load<UnityEngine.TextAsset>("LineBreaking Leading Characters");
				}
				m_LeadingCharactersLookup = ((leadingRules != null) ? GetCharacters(leadingRules) : new HashSet<uint>());
				if (followingRules == null)
				{
					followingRules = Resources.Load<UnityEngine.TextAsset>("LineBreaking Following Characters");
				}
				m_FollowingCharactersLookup = ((followingRules != null) ? GetCharacters(followingRules) : new HashSet<uint>());
			}
		}

		private static HashSet<uint> GetCharacters(UnityEngine.TextAsset file)
		{
			HashSet<uint> hashSet = new HashSet<uint>();
			string text = file.text;
			for (int i = 0; i < text.Length; i++)
			{
				hashSet.Add(text[i]);
			}
			return hashSet;
		}
	}
}
