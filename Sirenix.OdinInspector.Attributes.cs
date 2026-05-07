using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Internal;
using UnityEngine;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: CLSCompliant(false)]
[assembly: AssemblyTitle("Sirenix.OdinInspector.Attributes")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Sirenix ApS")]
[assembly: AssemblyProduct("Sirenix.OdinInspector.Attributes")]
[assembly: AssemblyCopyright("Copyright © 2022")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("981796DA-69ED-42C4-A027-06D576786973")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: TargetFramework(".NETFramework,Version=v4.7.1", FrameworkDisplayName = ".NET Framework 4.7.1")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
public class XAtt : ShowInInspectorAttribute
{
}
namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class AssetListAttribute : Attribute
	{
		public bool AutoPopulate;

		public string Tags;

		public string LayerNames;

		public string AssetNamePrefix;

		public string Path;

		public string CustomFilterMethod;

		public AssetListAttribute()
		{
			AutoPopulate = false;
			Tags = null;
			LayerNames = null;
			AssetNamePrefix = null;
			CustomFilterMethod = null;
		}
	}
	[Conditional("UNITY_EDITOR")]
	public class AssetSelectorAttribute : Attribute
	{
		[LabelWidth(200f)]
		public bool IsUniqueList = true;

		[LabelWidth(200f)]
		public bool DrawDropdownForListElements = true;

		[LabelWidth(200f)]
		public bool DisableListAddButtonBehaviour;

		[LabelWidth(200f)]
		public bool ExcludeExistingValuesInList;

		[LabelWidth(200f)]
		public bool ExpandAllMenuItems = true;

		[LabelWidth(200f)]
		public bool FlattenTreeView;

		public int DropdownWidth;

		public int DropdownHeight;

		public string DropdownTitle;

		public string[] SearchInFolders;

		public string Filter;

		[ShowInInspector]
		[DelayedProperty]
		[OdinDesignerBinding(new string[] { "SearchInFolders" })]
		public string Paths
		{
			get
			{
				if (SearchInFolders != null)
				{
					return string.Join(",", SearchInFolders);
				}
				return null;
			}
			set
			{
				SearchInFolders = (from x in value.Split(new char[1] { '|' })
					select x.Trim().Trim('/', '\\')).ToArray();
			}
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class AssetsOnlyAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class BoxGroupAttribute : PropertyGroupAttribute
	{
		public bool ShowLabel;

		public bool CenterLabel;

		public string LabelText;

		public BoxGroupAttribute(string group, bool showLabel = true, bool centerLabel = false, float order = 0f)
			: base(group, order)
		{
			ShowLabel = showLabel;
			CenterLabel = centerLabel;
		}

		public BoxGroupAttribute()
			: this("_DefaultBoxGroup", showLabel: false)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			BoxGroupAttribute boxGroupAttribute = other as BoxGroupAttribute;
			if (!ShowLabel || !boxGroupAttribute.ShowLabel)
			{
				ShowLabel = false;
				boxGroupAttribute.ShowLabel = false;
			}
			CenterLabel |= boxGroupAttribute.CenterLabel;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public class ButtonAttribute : ShowInInspectorAttribute
	{
		[PropertyOrder(-10f)]
		public string Name;

		[PropertyOrder(-9f)]
		public ButtonStyle Style;

		public bool Expanded;

		public bool DisplayParameters = true;

		public bool DirtyOnClick = true;

		[PropertyOrder(-8f)]
		public SdfIconType Icon;

		private int buttonHeight;

		private bool drawResult;

		private bool drawResultIsSet;

		private bool stretch;

		private IconAlignment buttonIconAlignment;

		private float buttonAlignment;

		[PropertyOrder(-6f)]
		[ShowInInspector]
		[ButtonHeightSelector]
		[OdinDesignerBinding(new string[] { "buttonHeight", "HasDefinedButtonHeight" })]
		public int ButtonHeight
		{
			get
			{
				return buttonHeight;
			}
			set
			{
				buttonHeight = value;
				HasDefinedButtonHeight = true;
			}
		}

		[PropertyOrder(-7f)]
		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "buttonIconAlignment", "HasDefinedButtonIconAlignment" })]
		public IconAlignment IconAlignment
		{
			get
			{
				return buttonIconAlignment;
			}
			set
			{
				buttonIconAlignment = value;
				HasDefinedButtonIconAlignment = true;
			}
		}

		[PropertyOrder(-5f)]
		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "buttonAlignment", "HasDefinedButtonAlignment" })]
		public float ButtonAlignment
		{
			get
			{
				return buttonAlignment;
			}
			set
			{
				buttonAlignment = value;
				HasDefinedButtonAlignment = true;
			}
		}

		[PropertyOrder(-4f)]
		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "stretch", "HasDefinedStretch" })]
		public bool Stretch
		{
			get
			{
				return stretch;
			}
			set
			{
				stretch = value;
				HasDefinedStretch = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "drawResult", "drawResultIsSet" })]
		public bool DrawResult
		{
			get
			{
				return drawResult;
			}
			set
			{
				drawResult = value;
				drawResultIsSet = true;
			}
		}

		public bool DrawResultIsSet => drawResultIsSet;

		public bool HasDefinedButtonHeight { get; private set; }

		public bool HasDefinedIcon => Icon != SdfIconType.None;

		public bool HasDefinedButtonIconAlignment { get; private set; }

		public bool HasDefinedButtonAlignment { get; private set; }

		public bool HasDefinedStretch { get; private set; }

		public ButtonAttribute()
		{
			Name = null;
		}

		public ButtonAttribute(ButtonSizes size)
		{
			Name = null;
			ButtonHeight = (int)size;
		}

		public ButtonAttribute(int buttonSize)
		{
			ButtonHeight = buttonSize;
			Name = null;
		}

		public ButtonAttribute(string name)
		{
			Name = name;
		}

		public ButtonAttribute(string name, ButtonSizes buttonSize)
		{
			Name = name;
			ButtonHeight = (int)buttonSize;
		}

		public ButtonAttribute(string name, int buttonSize)
		{
			Name = name;
			ButtonHeight = buttonSize;
		}

		public ButtonAttribute(ButtonStyle parameterBtnStyle)
		{
			Name = null;
			Style = parameterBtnStyle;
		}

		public ButtonAttribute(int buttonSize, ButtonStyle parameterBtnStyle)
		{
			ButtonHeight = buttonSize;
			Name = null;
			Style = parameterBtnStyle;
		}

		public ButtonAttribute(ButtonSizes size, ButtonStyle parameterBtnStyle)
		{
			ButtonHeight = (int)size;
			Name = null;
			Style = parameterBtnStyle;
		}

		public ButtonAttribute(string name, ButtonStyle parameterBtnStyle)
		{
			Name = name;
			Style = parameterBtnStyle;
		}

		public ButtonAttribute(string name, ButtonSizes buttonSize, ButtonStyle parameterBtnStyle)
		{
			Name = name;
			ButtonHeight = (int)buttonSize;
			Style = parameterBtnStyle;
		}

		public ButtonAttribute(string name, int buttonSize, ButtonStyle parameterBtnStyle)
		{
			Name = name;
			ButtonHeight = buttonSize;
			Style = parameterBtnStyle;
		}

		public ButtonAttribute(SdfIconType icon, IconAlignment iconAlignment)
		{
			Icon = icon;
			IconAlignment = iconAlignment;
			Name = null;
		}

		public ButtonAttribute(SdfIconType icon)
		{
			Icon = icon;
			Name = null;
		}

		public ButtonAttribute(SdfIconType icon, string name)
		{
			Name = name;
			Icon = icon;
		}
	}
	[IncludeMyAttributes]
	[ShowInInspector]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class ButtonGroupAttribute : PropertyGroupAttribute
	{
		[ButtonHeightSelector]
		public int ButtonHeight;

		private IconAlignment buttonIconAlignment;

		private int buttonAlignment;

		private bool stretch;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "buttonIconAlignment", "HasDefinedButtonIconAlignment" })]
		public IconAlignment IconAlignment
		{
			get
			{
				return buttonIconAlignment;
			}
			set
			{
				buttonIconAlignment = value;
				HasDefinedButtonIconAlignment = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "buttonAlignment", "HasDefinedButtonAlignment" })]
		public int ButtonAlignment
		{
			get
			{
				return buttonAlignment;
			}
			set
			{
				buttonAlignment = value;
				HasDefinedButtonAlignment = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "stretch", "HasDefinedStretch" })]
		public bool Stretch
		{
			get
			{
				return stretch;
			}
			set
			{
				stretch = value;
				HasDefinedStretch = true;
			}
		}

		public bool HasDefinedButtonIconAlignment { get; private set; }

		public bool HasDefinedButtonAlignment { get; private set; }

		public bool HasDefinedStretch { get; private set; }

		public ButtonGroupAttribute(string group = "_DefaultGroup", float order = 0f)
			: base(group, order)
		{
		}
	}
	public enum ButtonStyle
	{
		CompactBox,
		FoldoutButton,
		Box
	}
	[Conditional("UNITY_EDITOR")]
	public class ChildGameObjectsOnlyAttribute : Attribute
	{
		public bool IncludeSelf = true;

		public bool IncludeInactive;
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ColorPaletteAttribute : Attribute
	{
		[ColorPaletteNameSelector]
		public string PaletteName;

		public bool ShowAlpha;

		public ColorPaletteAttribute()
		{
			PaletteName = null;
			ShowAlpha = true;
		}

		public ColorPaletteAttribute(string paletteName)
		{
			PaletteName = paletteName;
			ShowAlpha = true;
		}
	}
	public enum ColumnType
	{
		Auto,
		Percent,
		Pixel
	}
	public struct ColumnSize
	{
		public ColumnType ColumnType;

		public float Value;

		public static ColumnSize Auto => new ColumnSize(ColumnType.Auto, 0f);

		public ColumnSize(ColumnType columnType, float value)
		{
			ColumnType = columnType;
			Value = value;
		}

		public static ColumnSize Percent(float percentage)
		{
			return new ColumnSize(ColumnType.Percent, percentage);
		}

		public static ColumnSize Pixel(float pixels)
		{
			return new ColumnSize(ColumnType.Pixel, pixels);
		}

		public override string ToString()
		{
			return ColumnType switch
			{
				ColumnType.Auto => "Auto", 
				ColumnType.Percent => $"{Value * 100f} %", 
				ColumnType.Pixel => $"{Value} px", 
				_ => base.ToString(), 
			};
		}
	}
	public class ColumnGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
	{
		[Conditional("UNITY_EDITOR")]
		public class ColumnSubGroupAttribute : PropertyGroupAttribute
		{
			public ColumnSize Size;

			public ColumnSubGroupAttribute(ColumnGroupAttribute column, string groupId, float order)
				: base(groupId, order)
			{
				if (column == null)
				{
					Size = ColumnSize.Auto;
				}
				else
				{
					Size = column.Size;
				}
			}
		}

		public const string DEFAULT_ROW_NAME = "_DefaultRow";

		public string ColumnId;

		public List<ColumnGroupAttribute> Columns;

		public ColumnSize Size;

		public ColumnGroupAttribute(string rowId, string columnId, ColumnType columnType = ColumnType.Auto, float columnSize = 0f, float order = 0f)
			: base(rowId, order)
		{
			ColumnId = columnId;
			Size = new ColumnSize(columnType, columnSize);
			Columns = new List<ColumnGroupAttribute> { this };
		}

		public ColumnGroupAttribute(string rowId, string columnId, float columnSize, float order = 0f)
			: base(rowId, order)
		{
			ColumnId = columnId;
			Size = ((columnSize <= 0f) ? ColumnSize.Auto : ((!(columnSize <= 1f) || !(columnSize >= 0f)) ? ColumnSize.Pixel(columnSize) : ColumnSize.Percent(columnSize)));
			Columns = new List<ColumnGroupAttribute> { this };
		}

		public ColumnGroupAttribute(string columnId)
			: this("_DefaultRow", columnId)
		{
		}

		public ColumnGroupAttribute(string columnId, float columnSize, float order = 0f)
			: this("_DefaultRow", columnId, columnSize, order)
		{
		}

		public ColumnGroupAttribute(string columnId, ColumnType columnType, float columnSize, float order = 0f)
			: this("_DefaultRow", columnId, columnType, columnSize, order)
		{
		}

		public IList<PropertyGroupAttribute> GetSubGroupAttributes()
		{
			int num = 0;
			List<PropertyGroupAttribute> list = new List<PropertyGroupAttribute>(Columns.Count)
			{
				new ColumnSubGroupAttribute(this, GroupID + "/" + ColumnId, num++)
			};
			foreach (ColumnGroupAttribute column in Columns)
			{
				if (column.ColumnId != ColumnId)
				{
					list.Add(new ColumnSubGroupAttribute(column, GroupID + "/" + column.ColumnId, num++));
				}
			}
			return list;
		}

		public string RepathMemberAttribute(PropertyGroupAttribute attr)
		{
			ColumnGroupAttribute columnGroupAttribute = (ColumnGroupAttribute)attr;
			return GroupID + "/" + columnGroupAttribute.ColumnId;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			ColumnGroupAttribute columnGroupAttribute = (ColumnGroupAttribute)other;
			for (int i = 0; i < Columns.Count; i++)
			{
				if (Columns[i].ColumnId == columnGroupAttribute.ColumnId)
				{
					return;
				}
			}
			Columns.Add(columnGroupAttribute);
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class CustomContextMenuAttribute : Attribute
	{
		public string MenuItem;

		public string Action;

		[Obsolete("Use the Action member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MethodName
		{
			get
			{
				return Action;
			}
			set
			{
				Action = value;
			}
		}

		public CustomContextMenuAttribute(string menuItem, string action)
		{
			MenuItem = menuItem;
			Action = action;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class CustomValueDrawerAttribute : Attribute
	{
		public string Action;

		[Obsolete("Use the Action member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MethodName
		{
			get
			{
				return Action;
			}
			set
			{
				Action = value;
			}
		}

		public CustomValueDrawerAttribute(string action)
		{
			Action = action;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class DelayedPropertyAttribute : Attribute
	{
	}
	public class ButtonHeightSelectorAttribute : Attribute
	{
	}
	public class ColorPaletteNameSelectorAttribute : Attribute
	{
	}
	public class ColorResolverAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public class DetailedInfoBoxAttribute : Attribute
	{
		public string Message;

		public string Details;

		public InfoMessageType InfoMessageType;

		public string VisibleIf;

		public DetailedInfoBoxAttribute(string message, string details, InfoMessageType infoMessageType = InfoMessageType.Info, string visibleIf = null)
		{
			Message = message;
			Details = details;
			InfoMessageType = infoMessageType;
			VisibleIf = visibleIf;
		}
	}
	[Conditional("UNITY_EDITOR")]
	public sealed class DictionaryDrawerSettings : Attribute
	{
		public string KeyLabel = "Key";

		public string ValueLabel = "Value";

		public DictionaryDisplayOptions DisplayMode;

		public bool IsReadOnly;

		public float KeyColumnWidth = 130f;
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class DisableContextMenuAttribute : Attribute
	{
		[LabelWidth(190f)]
		public bool DisableForMember;

		[LabelWidth(190f)]
		public bool DisableForCollectionElements;

		public DisableContextMenuAttribute(bool disableForMember = true, bool disableCollectionElements = false)
		{
			DisableForMember = disableForMember;
			DisableForCollectionElements = disableCollectionElements;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class DisableIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		public DisableIfAttribute(string condition)
		{
			Condition = condition;
		}

		public DisableIfAttribute(string condition, object optionalValue)
		{
			Condition = condition;
			Value = optionalValue;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class DisableInAttribute : Attribute
	{
		public PrefabKind PrefabKind;

		public DisableInAttribute(PrefabKind prefabKind)
		{
			PrefabKind = prefabKind;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class DisableInEditorModeAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class DisableInInlineEditorsAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Conditional("UNITY_EDITOR")]
	[Obsolete("Use [DisableIn(PrefabKind.NonPrefabInstance)] instead.", false)]
	public class DisableInNonPrefabsAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public class DisableInPlayModeAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use [DisableIn(PrefabKind.PrefabAsset)] instead.", false)]
	public class DisableInPrefabAssetsAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use [DisableIn(PrefabKind.PrefabInstance)] instead.", false)]
	public class DisableInPrefabInstancesAttribute : Attribute
	{
	}
	[Obsolete("Use [DisableIn(PrefabKind.PrefabAsset | PrefabKind.PrefabInstance)] instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class DisableInPrefabsAttribute : Attribute
	{
	}
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class DisallowModificationsInAttribute : Attribute
	{
		public PrefabKind PrefabKind;

		public DisallowModificationsInAttribute(PrefabKind kind)
		{
			PrefabKind = kind;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class DisplayAsStringAttribute : Attribute
	{
		public bool Overflow;

		public TextAlignment Alignment;

		public int FontSize;

		public bool EnableRichText;

		public string Format;

		public DisplayAsStringAttribute()
		{
			Overflow = true;
		}

		public DisplayAsStringAttribute(bool overflow)
		{
			Overflow = overflow;
		}

		public DisplayAsStringAttribute(TextAlignment alignment)
		{
			Alignment = alignment;
		}

		public DisplayAsStringAttribute(int fontSize)
		{
			FontSize = fontSize;
		}

		public DisplayAsStringAttribute(bool overflow, TextAlignment alignment)
		{
			Overflow = overflow;
			Alignment = alignment;
		}

		public DisplayAsStringAttribute(bool overflow, int fontSize)
		{
			Overflow = overflow;
			FontSize = fontSize;
		}

		public DisplayAsStringAttribute(int fontSize, TextAlignment alignment)
		{
			FontSize = fontSize;
			Alignment = alignment;
		}

		public DisplayAsStringAttribute(bool overflow, int fontSize, TextAlignment alignment)
		{
			Overflow = overflow;
			FontSize = fontSize;
			Alignment = alignment;
		}

		public DisplayAsStringAttribute(TextAlignment alignment, bool enableRichText)
		{
			Alignment = alignment;
			EnableRichText = enableRichText;
		}

		public DisplayAsStringAttribute(int fontSize, bool enableRichText)
		{
			FontSize = fontSize;
			EnableRichText = enableRichText;
		}

		public DisplayAsStringAttribute(bool overflow, TextAlignment alignment, bool enableRichText)
		{
			Overflow = overflow;
			Alignment = alignment;
			EnableRichText = enableRichText;
		}

		public DisplayAsStringAttribute(bool overflow, int fontSize, bool enableRichText)
		{
			Overflow = overflow;
			FontSize = fontSize;
			EnableRichText = enableRichText;
		}

		public DisplayAsStringAttribute(int fontSize, TextAlignment alignment, bool enableRichText)
		{
			FontSize = fontSize;
			Alignment = alignment;
			EnableRichText = enableRichText;
		}

		public DisplayAsStringAttribute(bool overflow, int fontSize, TextAlignment alignment, bool enableRichText)
		{
			Overflow = overflow;
			FontSize = fontSize;
			Alignment = alignment;
			EnableRichText = enableRichText;
		}
	}
	[Conditional("UNITY_EDITOR")]
	public sealed class DoNotDrawAsReferenceAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class DontApplyToListElementsAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class DontValidateAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class DrawWithUnityAttribute : Attribute
	{
		public bool PreferImGUI;
	}
	public class DrawWithVisualElementsAttribute : Attribute
	{
		public bool DrawCollectionWithImGUI;
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class EnableGUIAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class EnableIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		public EnableIfAttribute(string condition)
		{
			Condition = condition;
		}

		public EnableIfAttribute(string condition, object optionalValue)
		{
			Condition = condition;
			Value = optionalValue;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class EnableInAttribute : Attribute
	{
		public PrefabKind PrefabKind;

		public EnableInAttribute(PrefabKind prefabKind)
		{
			PrefabKind = prefabKind;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class EnumPagingAttribute : Attribute
	{
	}
	[Conditional("UNITY_EDITOR")]
	public class EnumToggleButtonsAttribute : Attribute
	{
	}
	public class ExcludeInOdinDesignerAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class FilePathAttribute : Attribute
	{
		public bool AbsolutePath;

		public string Extensions;

		public string ParentFolder;

		[HideInInspector]
		[Obsolete("Use RequireExistingPath instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RequireValidPath;

		public bool RequireExistingPath;

		public bool UseBackslashes;

		public bool IncludeFileExtension = true;

		[Obsolete("Add a ReadOnly attribute to the property instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ReadOnly { get; set; }
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class FolderPathAttribute : Attribute
	{
		public bool AbsolutePath;

		public string ParentFolder;

		[HideInInspector]
		[Obsolete("Use RequireExistingPath instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool RequireValidPath;

		public bool RequireExistingPath;

		public bool UseBackslashes;
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class FoldoutGroupAttribute : PropertyGroupAttribute
	{
		private bool expanded;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "expanded", "HasDefinedExpanded" })]
		public bool Expanded
		{
			get
			{
				return expanded;
			}
			set
			{
				expanded = value;
				HasDefinedExpanded = true;
			}
		}

		public bool HasDefinedExpanded { get; private set; }

		public FoldoutGroupAttribute(string groupName, float order = 0f)
			: base(groupName, order)
		{
		}

		public FoldoutGroupAttribute(string groupName, bool expanded, float order = 0f)
			: base(groupName, order)
		{
			this.expanded = expanded;
			HasDefinedExpanded = true;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			FoldoutGroupAttribute foldoutGroupAttribute = other as FoldoutGroupAttribute;
			if (foldoutGroupAttribute.HasDefinedExpanded)
			{
				HasDefinedExpanded = true;
				Expanded = foldoutGroupAttribute.Expanded;
			}
			if (HasDefinedExpanded)
			{
				foldoutGroupAttribute.HasDefinedExpanded = true;
				foldoutGroupAttribute.Expanded = Expanded;
			}
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class GUIColorAttribute : Attribute
	{
		public Color Color;

		[ColorResolver]
		public string GetColor;

		public GUIColorAttribute(float r, float g, float b, float a = 1f)
		{
			Color = new Color(r, g, b, a);
		}

		public GUIColorAttribute(string getColor)
		{
			GetColor = getColor;
		}
	}
	[Conditional("UNITY_EDITOR")]
	public class HideDuplicateReferenceBoxAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public sealed class HideIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		public bool Animate;

		[Obsolete("Use the Condition member instead.", false)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		public HideIfAttribute(string condition, bool animate = true)
		{
			Condition = condition;
			Animate = animate;
		}

		public HideIfAttribute(string condition, object optionalValue, bool animate = true)
		{
			Condition = condition;
			Value = optionalValue;
			Animate = animate;
		}
	}
	[Conditional("UNITY_EDITOR")]
	public class HideIfGroupAttribute : PropertyGroupAttribute
	{
		public object Value;

		public bool Animate
		{
			get
			{
				return AnimateVisibility;
			}
			set
			{
				AnimateVisibility = value;
			}
		}

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		public string Condition
		{
			get
			{
				if (!string.IsNullOrEmpty(VisibleIf))
				{
					return VisibleIf;
				}
				return GroupName;
			}
			set
			{
				VisibleIf = value;
			}
		}

		public HideIfGroupAttribute(string path, bool animate = true)
			: base(path)
		{
			Animate = animate;
		}

		public HideIfGroupAttribute(string path, object value, bool animate = true)
			: base(path)
		{
			Value = value;
			Animate = animate;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			HideIfGroupAttribute hideIfGroupAttribute = other as HideIfGroupAttribute;
			if (Value != null)
			{
				hideIfGroupAttribute.Value = Value;
			}
		}
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class HideInAttribute : Attribute
	{
		public PrefabKind PrefabKind;

		public HideInAttribute(PrefabKind prefabKind)
		{
			PrefabKind = prefabKind;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class HideInEditorModeAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class HideInInlineEditorsAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use [HideIn(PrefabKind.NonPrefabInstance)] instead.", false)]
	public class HideInNonPrefabsAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public class HideInPlayModeAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	[Obsolete("Use [HideIn(PrefabKind.PrefabAsset)] instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class HideInPrefabAssetsAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use [HideIn(PrefabKind.PrefabInstance)] instead.", false)]
	public class HideInPrefabInstancesAttribute : Attribute
	{
	}
	[Obsolete("Use [HideIn(PrefabKind.PrefabAsset | PrefabKind.PrefabInstance)] instead.", false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class HideInPrefabsAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class HideInTablesAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class HideLabelAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class HideMonoScriptAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class HideNetworkBehaviourFieldsAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class HideReferenceObjectPickerAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class HorizontalGroupAttribute : PropertyGroupAttribute
	{
		private const int DefaultHorizontalGroupGap = 3;

		public float Width;

		public float MarginLeft;

		public float MarginRight;

		public float PaddingLeft;

		public float PaddingRight;

		public float MinWidth;

		public float MaxWidth;

		public float Gap = 3f;

		public string Title;

		[LabelWidth(200f)]
		public bool DisableAutomaticLabelWidth;

		public float LabelWidth;

		public HorizontalGroupAttribute(string group, float width = 0f, int marginLeft = 0, int marginRight = 0, float order = 0f)
			: base(group, order)
		{
			Width = width;
			MarginLeft = marginLeft;
			MarginRight = marginRight;
		}

		public HorizontalGroupAttribute(float width = 0f, int marginLeft = 0, int marginRight = 0, float order = 0f)
			: this("_DefaultHorizontalGroup", width, marginLeft, marginRight, order)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			if (other is HorizontalGroupAttribute horizontalGroupAttribute)
			{
				Title = Title ?? horizontalGroupAttribute.Title;
				DisableAutomaticLabelWidth = DisableAutomaticLabelWidth || horizontalGroupAttribute.DisableAutomaticLabelWidth;
				if (LabelWidth == 0f && horizontalGroupAttribute.LabelWidth != 0f)
				{
					LabelWidth = horizontalGroupAttribute.LabelWidth;
				}
				if (horizontalGroupAttribute.Gap != 3f)
				{
					Gap = horizontalGroupAttribute.Gap;
				}
			}
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class IndentAttribute : Attribute
	{
		public int IndentLevel;

		public IndentAttribute(int indentLevel = 1)
		{
			IndentLevel = indentLevel;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class InfoBoxAttribute : Attribute
	{
		public string Message;

		public InfoMessageType InfoMessageType;

		public string VisibleIf;

		public bool GUIAlwaysEnabled;

		[ColorResolver]
		public string IconColor;

		private SdfIconType icon;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "icon", "HasDefinedIcon" })]
		public SdfIconType Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value;
				HasDefinedIcon = true;
			}
		}

		public bool HasDefinedIcon { get; private set; }

		public InfoBoxAttribute(string message, InfoMessageType infoMessageType = InfoMessageType.Info, string visibleIfMemberName = null)
		{
			Message = message;
			InfoMessageType = infoMessageType;
			VisibleIf = visibleIfMemberName;
		}

		public InfoBoxAttribute(string message, string visibleIfMemberName)
		{
			Message = message;
			InfoMessageType = InfoMessageType.Info;
			VisibleIf = visibleIfMemberName;
		}

		public InfoBoxAttribute(string message, SdfIconType icon, string visibleIfMemberName = null)
		{
			Message = message;
			Icon = icon;
			VisibleIf = visibleIfMemberName;
			InfoMessageType = InfoMessageType.None;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class InlineButtonAttribute : Attribute
	{
		public string Action;

		public string Label;

		public string ShowIf;

		[ColorResolver]
		public string ButtonColor;

		[ColorResolver]
		public string TextColor;

		public SdfIconType Icon;

		public IconAlignment IconAlignment;

		[Obsolete("Use the Action member instead.", false)]
		public string MemberMethod
		{
			get
			{
				return Action;
			}
			set
			{
				Action = value;
			}
		}

		public InlineButtonAttribute(string action, string label = null)
		{
			Action = action;
			Label = label;
		}

		public InlineButtonAttribute(string action, SdfIconType icon, string label = null)
		{
			Action = action;
			Icon = icon;
			Label = label;
		}
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class InlineEditorAttribute : Attribute
	{
		private bool expanded;

		public bool DrawHeader;

		public bool DrawGUI;

		public bool DrawPreview;

		public float MaxHeight;

		public float PreviewWidth = 100f;

		public float PreviewHeight = 35f;

		[LabelWidth(220f)]
		public bool IncrementInlineEditorDrawerDepth = true;

		[LabelWidth(220f)]
		public bool DisableGUIForVCSLockedAssets = true;

		public InlineEditorObjectFieldModes ObjectFieldMode;

		public PreviewAlignment PreviewAlignment = PreviewAlignment.Right;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "expanded", "ExpandedHasValue" })]
		public bool Expanded
		{
			get
			{
				return expanded;
			}
			set
			{
				expanded = value;
				ExpandedHasValue = true;
			}
		}

		public bool ExpandedHasValue { get; private set; }

		public InlineEditorAttribute(InlineEditorModes inlineEditorMode = InlineEditorModes.GUIOnly, InlineEditorObjectFieldModes objectFieldMode = InlineEditorObjectFieldModes.Boxed)
		{
			ObjectFieldMode = objectFieldMode;
			switch (inlineEditorMode)
			{
			case InlineEditorModes.GUIOnly:
				DrawGUI = true;
				break;
			case InlineEditorModes.GUIAndHeader:
				DrawGUI = true;
				DrawHeader = true;
				break;
			case InlineEditorModes.GUIAndPreview:
				DrawGUI = true;
				DrawPreview = true;
				break;
			case InlineEditorModes.SmallPreview:
				expanded = true;
				DrawPreview = true;
				break;
			case InlineEditorModes.LargePreview:
				expanded = true;
				DrawPreview = true;
				PreviewHeight = 170f;
				break;
			case InlineEditorModes.FullEditor:
				DrawGUI = true;
				DrawHeader = true;
				DrawPreview = true;
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public InlineEditorAttribute(InlineEditorObjectFieldModes objectFieldMode)
			: this(InlineEditorModes.GUIOnly, objectFieldMode)
		{
		}
	}
	[AttributeUsage(AttributeTargets.All, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public class InlinePropertyAttribute : Attribute
	{
		public int LabelWidth;
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class LabelTextAttribute : Attribute
	{
		public string Text;

		public bool NicifyText;

		public SdfIconType Icon;

		[ColorResolver]
		public string IconColor;

		public LabelTextAttribute(string text)
		{
			Text = text;
		}

		public LabelTextAttribute(SdfIconType icon)
		{
			Icon = icon;
		}

		public LabelTextAttribute(string text, bool nicifyText)
		{
			Text = text;
			NicifyText = nicifyText;
		}

		public LabelTextAttribute(string text, SdfIconType icon)
		{
			Text = text;
			Icon = icon;
		}

		public LabelTextAttribute(string text, bool nicifyText, SdfIconType icon)
		{
			Text = text;
			NicifyText = nicifyText;
			Icon = icon;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class LabelWidthAttribute : Attribute
	{
		public float Width;

		public LabelWidthAttribute(float width)
		{
			Width = width;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	public sealed class ListDrawerSettingsAttribute : Attribute
	{
		public bool HideAddButton;

		public bool HideRemoveButton;

		public string ListElementLabelName;

		public string CustomAddFunction;

		[LabelWidth(200f)]
		public string CustomRemoveIndexFunction;

		[LabelWidth(200f)]
		public string CustomRemoveElementFunction;

		public string OnBeginListElementGUI;

		public string OnEndListElementGUI;

		public bool AlwaysAddDefaultValue;

		public bool AddCopiesLastElement;

		[ColorResolver]
		public string ElementColor;

		private string onTitleBarGUI;

		private int numberOfItemsPerPage;

		private bool paging;

		private bool draggable;

		private bool isReadOnly;

		private bool showItemCount;

		private bool pagingHasValue;

		private bool draggableHasValue;

		private bool isReadOnlyHasValue;

		private bool showItemCountHasValue;

		private bool numberOfItemsPerPageHasValue;

		private bool showIndexLabels;

		private bool showIndexLabelsHasValue;

		private bool defaultExpandedStateHasValue;

		private bool defaultExpandedState;

		public bool ShowFoldout = true;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "paging", "pagingHasValue" })]
		public bool ShowPaging
		{
			get
			{
				return paging;
			}
			set
			{
				paging = value;
				pagingHasValue = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "draggable", "draggableHasValue" })]
		public bool DraggableItems
		{
			get
			{
				return draggable;
			}
			set
			{
				draggable = value;
				draggableHasValue = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "numberOfItemsPerPage", "numberOfItemsPerPageHasValue" })]
		public int NumberOfItemsPerPage
		{
			get
			{
				return numberOfItemsPerPage;
			}
			set
			{
				numberOfItemsPerPage = value;
				numberOfItemsPerPageHasValue = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "isReadOnly", "isReadOnlyHasValue" })]
		public bool IsReadOnly
		{
			get
			{
				return isReadOnly;
			}
			set
			{
				isReadOnly = value;
				isReadOnlyHasValue = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showItemCount", "showItemCountHasValue" })]
		public bool ShowItemCount
		{
			get
			{
				return showItemCount;
			}
			set
			{
				showItemCount = value;
				showItemCountHasValue = true;
			}
		}

		[Obsolete("Use ShowFoldout instead, which is what Expanded has always done. If you want to control the default expanded state, use DefaultExpandedState. Expanded has been implemented wrong for a long time.", false)]
		public bool Expanded
		{
			get
			{
				return !ShowFoldout;
			}
			set
			{
				ShowFoldout = !value;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "defaultExpandedState", "defaultExpandedStateHasValue" })]
		public bool DefaultExpandedState
		{
			get
			{
				return defaultExpandedState;
			}
			set
			{
				defaultExpandedStateHasValue = true;
				defaultExpandedState = value;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showIndexLabels", "showIndexLabelsHasValue" })]
		public bool ShowIndexLabels
		{
			get
			{
				return showIndexLabels;
			}
			set
			{
				showIndexLabels = value;
				showIndexLabelsHasValue = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "onTitleBarGUI" })]
		public string OnTitleBarGUI
		{
			get
			{
				return onTitleBarGUI;
			}
			set
			{
				onTitleBarGUI = value;
			}
		}

		public bool PagingHasValue => pagingHasValue;

		public bool ShowItemCountHasValue => showItemCountHasValue;

		public bool NumberOfItemsPerPageHasValue => numberOfItemsPerPageHasValue;

		public bool DraggableHasValue => draggableHasValue;

		public bool IsReadOnlyHasValue => isReadOnlyHasValue;

		public bool ShowIndexLabelsHasValue => showIndexLabelsHasValue;

		public bool DefaultExpandedStateHasValue => defaultExpandedStateHasValue;
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class MaxValueAttribute : Attribute
	{
		public double MaxValue;

		public string Expression;

		public MaxValueAttribute(double maxValue)
		{
			MaxValue = maxValue;
		}

		public MaxValueAttribute(string expression)
		{
			Expression = expression;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class MinMaxSliderAttribute : Attribute
	{
		public float MinValue;

		public float MaxValue;

		public string MinValueGetter;

		public string MaxValueGetter;

		public string MinMaxValueGetter;

		public bool ShowFields;

		[Obsolete("Use the MinValueGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MinMember
		{
			get
			{
				return MinValueGetter;
			}
			set
			{
				MinValueGetter = value;
			}
		}

		[Obsolete("Use the MaxValueGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MaxMember
		{
			get
			{
				return MaxValueGetter;
			}
			set
			{
				MaxValueGetter = value;
			}
		}

		[Obsolete("Use the MinMaxValueGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MinMaxMember
		{
			get
			{
				return MinMaxValueGetter;
			}
			set
			{
				MinMaxValueGetter = value;
			}
		}

		public MinMaxSliderAttribute(float minValue, float maxValue, bool showFields = false)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			ShowFields = showFields;
		}

		public MinMaxSliderAttribute(string minValueGetter, float maxValue, bool showFields = false)
		{
			MinValueGetter = minValueGetter;
			MaxValue = maxValue;
			ShowFields = showFields;
		}

		public MinMaxSliderAttribute(float minValue, string maxValueGetter, bool showFields = false)
		{
			MinValue = minValue;
			MaxValueGetter = maxValueGetter;
			ShowFields = showFields;
		}

		public MinMaxSliderAttribute(string minValueGetter, string maxValueGetter, bool showFields = false)
		{
			MinValueGetter = minValueGetter;
			MaxValueGetter = maxValueGetter;
			ShowFields = showFields;
		}

		public MinMaxSliderAttribute(string minMaxValueGetter, bool showFields = false)
		{
			MinMaxValueGetter = minMaxValueGetter;
			ShowFields = showFields;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class MinValueAttribute : Attribute
	{
		public double MinValue;

		public string Expression;

		public MinValueAttribute(double minValue)
		{
			MinValue = minValue;
		}

		public MinValueAttribute(string expression)
		{
			Expression = expression;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class MultiLinePropertyAttribute : Attribute
	{
		public int Lines;

		public MultiLinePropertyAttribute(int lines = 3)
		{
			Lines = Math.Max(1, lines);
		}
	}
	public class OdinDesignerBindingAttribute : Attribute
	{
		public string[] MemberNames;

		public OdinDesignerBindingAttribute(params string[] memberNames)
		{
			MemberNames = memberNames;
		}

		public MemberInfo GetBindingMemberInfo(Type type, int index)
		{
			FieldInfo field = type.GetField(MemberNames[index], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field != null)
			{
				return field;
			}
			return type.GetProperty(MemberNames[index], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class OnCollectionChangedAttribute : Attribute
	{
		public string Before;

		public string After;

		public OnCollectionChangedAttribute()
		{
		}

		public OnCollectionChangedAttribute(string after)
		{
			After = after;
		}

		public OnCollectionChangedAttribute(string before, string after)
		{
			Before = before;
			After = after;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	[IncludeMyAttributes]
	[HideInTables]
	public class OnInspectorDisposeAttribute : ShowInInspectorAttribute
	{
		public string Action;

		public OnInspectorDisposeAttribute()
		{
		}

		public OnInspectorDisposeAttribute(string action)
		{
			Action = action;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class OnInspectorGUIAttribute : ShowInInspectorAttribute
	{
		public string Prepend;

		public string Append;

		[Obsolete("Use the Prepend member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string PrependMethodName;

		[Obsolete("Use the Append member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string AppendMethodName;

		public OnInspectorGUIAttribute()
		{
		}

		public OnInspectorGUIAttribute(string action, bool append = true)
		{
			if (append)
			{
				Append = action;
			}
			else
			{
				Prepend = action;
			}
		}

		public OnInspectorGUIAttribute(string prepend, string append)
		{
			Prepend = prepend;
			Append = append;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	[IncludeMyAttributes]
	[HideInTables]
	public class OnInspectorInitAttribute : ShowInInspectorAttribute
	{
		public string Action;

		public OnInspectorInitAttribute()
		{
		}

		public OnInspectorInitAttribute(string action)
		{
			Action = action;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	[IncludeMyAttributes]
	[HideInTables]
	public sealed class OnStateUpdateAttribute : Attribute
	{
		public string Action;

		public OnStateUpdateAttribute(string action)
		{
			Action = action;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class OnValueChangedAttribute : Attribute
	{
		public string Action;

		public bool IncludeChildren;

		public bool InvokeOnUndoRedo = true;

		public bool InvokeOnInitialize;

		[Obsolete("Use the Action member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MethodName
		{
			get
			{
				return Action;
			}
			set
			{
				Action = value;
			}
		}

		public OnValueChangedAttribute(string action, bool includeChildren = false)
		{
			Action = action;
			IncludeChildren = includeChildren;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class OptionalAttribute : Attribute
	{
	}
	public enum NonDefaultConstructorPreference
	{
		Exclude,
		ConstructIdeal,
		PreferUninitialized,
		LogWarning
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class PolymorphicDrawerSettingsAttribute : Attribute
	{
		[LabelWidth(190f)]
		public bool ReadOnlyIfNotNullReference;

		public string CreateInstanceFunction;

		[Obsolete("Use OnValueChangedAttribute instead.", false)]
		public string OnInstanceAssigned;

		private bool? showBaseType;

		private NonDefaultConstructorPreference? nonDefaultConstructorPreference;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showBaseType" })]
		public bool ShowBaseType
		{
			get
			{
				return showBaseType == true;
			}
			set
			{
				showBaseType = value;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "nonDefaultConstructorPreference" })]
		[LabelWidth(210f)]
		public NonDefaultConstructorPreference NonDefaultConstructorPreference
		{
			get
			{
				return nonDefaultConstructorPreference ?? NonDefaultConstructorPreference.ConstructIdeal;
			}
			set
			{
				nonDefaultConstructorPreference = value;
			}
		}

		public bool ShowBaseTypeIsSet => showBaseType.HasValue;

		public bool NonDefaultConstructorPreferenceIsSet => nonDefaultConstructorPreference.HasValue;
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class PreviewFieldAttribute : Attribute
	{
		private ObjectFieldAlignment alignment;

		private bool alignmentHasValue;

		private string previewGetter;

		public float Height;

		public FilterMode FilterMode = FilterMode.Bilinear;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "alignment", "alignmentHasValue" })]
		public ObjectFieldAlignment Alignment
		{
			get
			{
				return alignment;
			}
			set
			{
				alignment = value;
				alignmentHasValue = true;
			}
		}

		public bool AlignmentHasValue => alignmentHasValue;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "previewGetter", "PreviewGetterHasValue" })]
		public string PreviewGetter
		{
			get
			{
				return previewGetter;
			}
			set
			{
				previewGetter = value;
				PreviewGetterHasValue = true;
			}
		}

		public bool PreviewGetterHasValue { get; private set; }

		public PreviewFieldAttribute()
		{
			Height = 0f;
		}

		public PreviewFieldAttribute(float height)
		{
			Height = height;
		}

		public PreviewFieldAttribute(string previewGetter, FilterMode filterMode = FilterMode.Bilinear)
		{
			PreviewGetter = previewGetter;
			FilterMode = filterMode;
		}

		public PreviewFieldAttribute(string previewGetter, float height, FilterMode filterMode = FilterMode.Bilinear)
		{
			PreviewGetter = previewGetter;
			Height = height;
			FilterMode = filterMode;
		}

		public PreviewFieldAttribute(float height, ObjectFieldAlignment alignment)
		{
			Height = height;
			Alignment = alignment;
		}

		public PreviewFieldAttribute(string previewGetter, ObjectFieldAlignment alignment, FilterMode filterMode = FilterMode.Bilinear)
		{
			PreviewGetter = previewGetter;
			Alignment = alignment;
			FilterMode = filterMode;
		}

		public PreviewFieldAttribute(string previewGetter, float height, ObjectFieldAlignment alignment, FilterMode filterMode = FilterMode.Bilinear)
		{
			PreviewGetter = previewGetter;
			Height = height;
			Alignment = alignment;
			FilterMode = filterMode;
		}

		public PreviewFieldAttribute(ObjectFieldAlignment alignment)
		{
			Alignment = alignment;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ProgressBarAttribute : Attribute
	{
		public double Min;

		public double Max;

		public string MinGetter;

		public string MaxGetter;

		public float R;

		public float G;

		public float B;

		public int Height;

		[ColorResolver]
		public string ColorGetter;

		public string BackgroundColorGetter;

		public bool Segmented;

		[LabelWidth(160f)]
		public string CustomValueStringGetter;

		private bool drawValueLabel;

		private TextAlignment valueLabelAlignment;

		[Obsolete("Use the MinGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MinMember
		{
			get
			{
				return MinGetter;
			}
			set
			{
				MinGetter = value;
			}
		}

		[Obsolete("Use the MaxGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MaxMember
		{
			get
			{
				return MaxGetter;
			}
			set
			{
				MaxGetter = value;
			}
		}

		[Obsolete("Use the ColorGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string ColorMember
		{
			get
			{
				return ColorGetter;
			}
			set
			{
				ColorGetter = value;
			}
		}

		[Obsolete("Use the BackgroundColorGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string BackgroundColorMember
		{
			get
			{
				return BackgroundColorGetter;
			}
			set
			{
				BackgroundColorGetter = value;
			}
		}

		[Obsolete("Use the CustomValueStringGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string CustomValueStringMember
		{
			get
			{
				return CustomValueStringGetter;
			}
			set
			{
				CustomValueStringGetter = value;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "drawValueLabel", "DrawValueLabelHasValue" })]
		public bool DrawValueLabel
		{
			get
			{
				return drawValueLabel;
			}
			set
			{
				drawValueLabel = value;
				DrawValueLabelHasValue = true;
			}
		}

		public bool DrawValueLabelHasValue { get; private set; }

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "valueLabelAlignment", "ValueLabelAlignmentHasValue" })]
		public TextAlignment ValueLabelAlignment
		{
			get
			{
				return valueLabelAlignment;
			}
			set
			{
				valueLabelAlignment = value;
				ValueLabelAlignmentHasValue = true;
			}
		}

		public bool ValueLabelAlignmentHasValue { get; private set; }

		public Color Color => new Color(R, G, B, 1f);

		public ProgressBarAttribute(double min, double max, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
			Min = min;
			Max = max;
			R = r;
			G = g;
			B = b;
			Height = 12;
			Segmented = false;
			drawValueLabel = true;
			DrawValueLabelHasValue = false;
			valueLabelAlignment = TextAlignment.Center;
			ValueLabelAlignmentHasValue = false;
		}

		public ProgressBarAttribute(string minGetter, double max, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
			MinGetter = minGetter;
			Max = max;
			R = r;
			G = g;
			B = b;
			Height = 12;
			Segmented = false;
			drawValueLabel = true;
			DrawValueLabelHasValue = false;
			valueLabelAlignment = TextAlignment.Center;
			ValueLabelAlignmentHasValue = false;
		}

		public ProgressBarAttribute(double min, string maxGetter, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
			Min = min;
			MaxGetter = maxGetter;
			R = r;
			G = g;
			B = b;
			Height = 12;
			Segmented = false;
			drawValueLabel = true;
			DrawValueLabelHasValue = false;
			valueLabelAlignment = TextAlignment.Center;
			ValueLabelAlignmentHasValue = false;
		}

		public ProgressBarAttribute(string minGetter, string maxGetter, float r = 0.15f, float g = 0.47f, float b = 0.74f)
		{
			MinGetter = minGetter;
			MaxGetter = maxGetter;
			R = r;
			G = g;
			B = b;
			Height = 12;
			Segmented = false;
			drawValueLabel = true;
			DrawValueLabelHasValue = false;
			valueLabelAlignment = TextAlignment.Center;
			ValueLabelAlignmentHasValue = false;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public abstract class PropertyGroupAttribute : Attribute
	{
		[HideInInspector]
		public string GroupID;

		[Delayed]
		[ValidateInput("ValidateGroupName", null, InfoMessageType.Error)]
		public string GroupName;

		[HideInInspector]
		public float Order;

		[LabelWidth(200f)]
		public bool HideWhenChildrenAreInvisible = true;

		[LabelWidth(200f)]
		public bool AnimateVisibility = true;

		public string VisibleIf;

		public PropertyGroupAttribute(string groupId, float order)
		{
			GroupID = groupId;
			Order = order;
			if (groupId == null)
			{
				GroupName = string.Empty;
				return;
			}
			int num = groupId.LastIndexOf('/');
			GroupName = ((num >= 0 && num < groupId.Length) ? groupId.Substring(num + 1) : groupId);
		}

		public PropertyGroupAttribute(string groupId)
			: this(groupId, 0f)
		{
		}

		public PropertyGroupAttribute Combine(PropertyGroupAttribute other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other.GetType() != GetType())
			{
				throw new ArgumentException("Attributes to combine are not of the same type.");
			}
			if (other.GroupID != GroupID)
			{
				throw new ArgumentException("PropertyGroupAttributes to combine must have the same group id.");
			}
			if (Order == 0f)
			{
				Order = other.Order;
			}
			else if (other.Order != 0f)
			{
				Order = Math.Min(Order, other.Order);
			}
			HideWhenChildrenAreInvisible &= other.HideWhenChildrenAreInvisible;
			if (VisibleIf == null)
			{
				VisibleIf = other.VisibleIf;
			}
			AnimateVisibility &= other.AnimateVisibility;
			CombineValuesWith(other);
			return this;
		}

		protected virtual void CombineValuesWith(PropertyGroupAttribute other)
		{
		}

		private static bool ValidateGroupName(string value, ref string errorMessage)
		{
			if (string.IsNullOrEmpty(value))
			{
				return true;
			}
			if (value.Contains("."))
			{
				errorMessage = "GroupName can't contain the '.' character";
				return false;
			}
			return true;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class PropertyOrderAttribute : Attribute
	{
		public float Order;

		public PropertyOrderAttribute()
		{
		}

		public PropertyOrderAttribute(float order)
		{
			Order = order;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class PropertyRangeAttribute : Attribute
	{
		public double Min;

		public double Max;

		public string MinGetter;

		public string MaxGetter;

		[Obsolete("Use the MinGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MinMember
		{
			get
			{
				return MinGetter;
			}
			set
			{
				MinGetter = value;
			}
		}

		[Obsolete("Use the MaxGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MaxMember
		{
			get
			{
				return MaxGetter;
			}
			set
			{
				MaxGetter = value;
			}
		}

		public PropertyRangeAttribute(double min, double max)
		{
			Min = ((min < max) ? min : max);
			Max = ((max > min) ? max : min);
		}

		public PropertyRangeAttribute(string minGetter, double max)
		{
			MinGetter = minGetter;
			Max = max;
		}

		public PropertyRangeAttribute(double min, string maxGetter)
		{
			Min = min;
			MaxGetter = maxGetter;
		}

		public PropertyRangeAttribute(string minGetter, string maxGetter)
		{
			MinGetter = minGetter;
			MaxGetter = maxGetter;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public class PropertySpaceAttribute : Attribute
	{
		public float SpaceBefore;

		public float SpaceAfter;

		public PropertySpaceAttribute()
		{
			SpaceBefore = 8f;
			SpaceAfter = 0f;
		}

		public PropertySpaceAttribute(float spaceBefore)
		{
			SpaceBefore = spaceBefore;
			SpaceAfter = 0f;
		}

		public PropertySpaceAttribute(float spaceBefore, float spaceAfter)
		{
			SpaceBefore = spaceBefore;
			SpaceAfter = spaceAfter;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class PropertyTooltipAttribute : Attribute
	{
		public string Tooltip;

		public PropertyTooltipAttribute(string tooltip)
		{
			Tooltip = tooltip;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ReadOnlyAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class RequiredAttribute : Attribute
	{
		public string ErrorMessage;

		public InfoMessageType MessageType;

		public RequiredAttribute()
		{
			MessageType = InfoMessageType.Error;
		}

		public RequiredAttribute(string errorMessage, InfoMessageType messageType)
		{
			ErrorMessage = errorMessage;
			MessageType = messageType;
		}

		public RequiredAttribute(string errorMessage)
		{
			ErrorMessage = errorMessage;
			MessageType = InfoMessageType.Error;
		}

		public RequiredAttribute(InfoMessageType messageType)
		{
			MessageType = messageType;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class RequiredInAttribute : Attribute
	{
		public string ErrorMessage;

		public PrefabKind PrefabKind;

		public RequiredInAttribute(PrefabKind kind)
		{
			PrefabKind = kind;
		}
	}
	[Obsolete("Use [RequiredIn(PrefabKind.PrefabAsset)] instead.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class RequiredInPrefabAssetsAttribute : Attribute
	{
		public string ErrorMessage;

		public InfoMessageType MessageType;

		public RequiredInPrefabAssetsAttribute()
		{
			MessageType = InfoMessageType.Error;
		}

		public RequiredInPrefabAssetsAttribute(string errorMessage, InfoMessageType messageType)
		{
			ErrorMessage = errorMessage;
			MessageType = messageType;
		}

		public RequiredInPrefabAssetsAttribute(string errorMessage)
		{
			ErrorMessage = errorMessage;
			MessageType = InfoMessageType.Error;
		}

		public RequiredInPrefabAssetsAttribute(InfoMessageType messageType)
		{
			MessageType = messageType;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use [RequiredIn(PrefabKind.PrefabInstance)] instead.", true)]
	public sealed class RequiredInPrefabInstancesAttribute : Attribute
	{
		public string ErrorMessage;

		public InfoMessageType MessageType;

		public RequiredInPrefabInstancesAttribute()
		{
			MessageType = InfoMessageType.Error;
		}

		public RequiredInPrefabInstancesAttribute(string errorMessage, InfoMessageType messageType)
		{
			ErrorMessage = errorMessage;
			MessageType = messageType;
		}

		public RequiredInPrefabInstancesAttribute(string errorMessage)
		{
			ErrorMessage = errorMessage;
			MessageType = InfoMessageType.Error;
		}

		public RequiredInPrefabInstancesAttribute(InfoMessageType messageType)
		{
			MessageType = messageType;
		}
	}
	public sealed class RequiredListLengthAttribute : Attribute
	{
		private PrefabKind prefabKind;

		private bool prefabKindIsSet;

		private int minLength;

		private int maxLength;

		private bool minLengthIsSet;

		private bool maxLengthIsSet;

		public string MinLengthGetter;

		public string MaxLengthGetter;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "minLength", "minLengthIsSet" })]
		public int MinLength
		{
			get
			{
				return minLength;
			}
			set
			{
				minLength = value;
				minLengthIsSet = true;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "maxLength", "maxLengthIsSet" })]
		public int MaxLength
		{
			get
			{
				return maxLength;
			}
			set
			{
				maxLength = value;
				maxLengthIsSet = true;
			}
		}

		public bool MinLengthIsSet => minLengthIsSet;

		public bool MaxLengthIsSet => maxLengthIsSet;

		public bool PrefabKindIsSet => prefabKindIsSet;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "prefabKind", "prefabKindIsSet" })]
		public PrefabKind PrefabKind
		{
			get
			{
				return prefabKind;
			}
			set
			{
				prefabKind = value;
				prefabKindIsSet = true;
			}
		}

		public RequiredListLengthAttribute()
		{
		}

		public RequiredListLengthAttribute(int fixedLength)
		{
			MinLength = fixedLength;
			MaxLength = fixedLength;
		}

		public RequiredListLengthAttribute(int minLength, int maxLength)
		{
			MinLength = minLength;
			MaxLength = maxLength;
		}

		public RequiredListLengthAttribute(int minLength, string maxLengthGetter)
		{
			MinLength = minLength;
			MaxLengthGetter = maxLengthGetter;
		}

		public RequiredListLengthAttribute(string fixedLengthGetter)
		{
			MinLengthGetter = fixedLengthGetter;
			MaxLengthGetter = fixedLengthGetter;
		}

		public RequiredListLengthAttribute(string minLengthGetter, string maxLengthGetter)
		{
			MinLengthGetter = minLengthGetter;
			MaxLengthGetter = maxLengthGetter;
		}

		public RequiredListLengthAttribute(string minLengthGetter, int maxLength)
		{
			MinLengthGetter = minLengthGetter;
			MaxLength = maxLength;
		}
	}
	[IncludeMyAttributes]
	[ShowInInspector]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class ResponsiveButtonGroupAttribute(string group = "_DefaultResponsiveButtonGroup") : PropertyGroupAttribute(group)
	{
		public ButtonSizes DefaultButtonSize = ButtonSizes.Medium;

		public bool UniformLayout;

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			ResponsiveButtonGroupAttribute responsiveButtonGroupAttribute = other as ResponsiveButtonGroupAttribute;
			if (other != null)
			{
				if (responsiveButtonGroupAttribute.DefaultButtonSize != ButtonSizes.Medium)
				{
					DefaultButtonSize = responsiveButtonGroupAttribute.DefaultButtonSize;
				}
				else if (DefaultButtonSize != ButtonSizes.Medium)
				{
					responsiveButtonGroupAttribute.DefaultButtonSize = DefaultButtonSize;
				}
				UniformLayout = UniformLayout || responsiveButtonGroupAttribute.UniformLayout;
			}
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class SceneObjectsOnlyAttribute : Attribute
	{
	}
	[Conditional("UNITY_EDITOR")]
	[DontApplyToListElements]
	public class SearchableAttribute : Attribute
	{
		public bool FuzzySearch = true;

		public SearchFilterOptions FilterOptions = SearchFilterOptions.All;

		public bool Recursive = true;
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class ShowDrawerChainAttribute : Attribute
	{
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ShowIfAttribute : Attribute
	{
		public string Condition;

		public object Value;

		public bool Animate;

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		public ShowIfAttribute(string condition, bool animate = true)
		{
			Condition = condition;
			Animate = animate;
		}

		public ShowIfAttribute(string condition, object optionalValue, bool animate = true)
		{
			Condition = condition;
			Value = optionalValue;
			Animate = animate;
		}
	}
	[Conditional("UNITY_EDITOR")]
	public class ShowIfGroupAttribute : PropertyGroupAttribute
	{
		public object Value;

		public bool Animate
		{
			get
			{
				return AnimateVisibility;
			}
			set
			{
				AnimateVisibility = value;
			}
		}

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		public string Condition
		{
			get
			{
				if (!string.IsNullOrEmpty(VisibleIf))
				{
					return VisibleIf;
				}
				return GroupName;
			}
			set
			{
				VisibleIf = value;
			}
		}

		public ShowIfGroupAttribute(string path, bool animate = true)
			: base(path)
		{
			Animate = animate;
		}

		public ShowIfGroupAttribute(string path, object value, bool animate = true)
			: base(path)
		{
			Value = value;
			Animate = animate;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			ShowIfGroupAttribute showIfGroupAttribute = other as ShowIfGroupAttribute;
			if (Value != null)
			{
				showIfGroupAttribute.Value = Value;
			}
		}
	}
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class ShowInAttribute : Attribute
	{
		public PrefabKind PrefabKind;

		public ShowInAttribute(PrefabKind prefabKind)
		{
			PrefabKind = prefabKind;
		}
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	[Conditional("UNITY_EDITOR")]
	public class ShowInInlineEditorsAttribute : Attribute
	{
	}
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public class ShowInInspectorAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class ShowOdinSerializedPropertiesInInspectorAttribute : Attribute
	{
	}
	[Conditional("UNITY_EDITOR")]
	public class ShowPropertyResolverAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	[Conditional("UNITY_EDITOR")]
	public sealed class SuffixLabelAttribute : Attribute
	{
		public string Label;

		public bool Overlay;

		[ColorResolver]
		public string IconColor;

		private SdfIconType icon;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "icon", "HasDefinedIcon" })]
		public SdfIconType Icon
		{
			get
			{
				return icon;
			}
			set
			{
				icon = value;
				HasDefinedIcon = true;
			}
		}

		public bool HasDefinedIcon { get; private set; }

		public SuffixLabelAttribute(string label, bool overlay = false)
		{
			Label = label;
			Overlay = overlay;
		}

		public SuffixLabelAttribute(string label, SdfIconType icon, bool overlay = false)
		{
			Label = label;
			Icon = icon;
			Overlay = overlay;
		}

		public SuffixLabelAttribute(SdfIconType icon)
		{
			Icon = icon;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class SuppressInvalidAttributeErrorAttribute : Attribute
	{
	}
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class TabGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
	{
		[Conditional("UNITY_EDITOR")]
		public class TabSubGroupAttribute : PropertyGroupAttribute
		{
			public string Name;

			public SdfIconType Icon;

			[ColorResolver]
			public string TextColor;

			public TabSubGroupAttribute(TabGroupAttribute tab, string groupId, float order)
				: base(groupId, order)
			{
				if (tab == null)
				{
					Name = null;
					Icon = SdfIconType.None;
					TextColor = null;
				}
				else
				{
					Name = tab.TabName;
					Icon = tab.Icon;
					TextColor = tab.TextColor;
				}
			}

			public TabSubGroupAttribute(string groupId, float order, string tabName, SdfIconType tabIcon, string textColor)
				: base(groupId, order)
			{
				Name = tabName;
				Icon = tabIcon;
				TextColor = textColor;
			}

			protected override void CombineValuesWith(PropertyGroupAttribute other)
			{
				if (other is TabSubGroupAttribute tabSubGroupAttribute)
				{
					if (TextColor == null)
					{
						TextColor = tabSubGroupAttribute.TextColor;
					}
					if (Icon == SdfIconType.None)
					{
						Icon = tabSubGroupAttribute.Icon;
					}
					if (Name == null)
					{
						Name = tabSubGroupAttribute.Name;
					}
				}
			}
		}

		public const string DEFAULT_NAME = "_DefaultTabGroup";

		[HideInInspector]
		public string TabName;

		[HideInInspector]
		public string TabId;

		public bool UseFixedHeight;

		public bool Paddingless;

		[LabelWidth(270f)]
		public bool HideTabGroupIfTabGroupOnlyHasOneTab;

		[HideInInspector]
		public string TextColor;

		[HideInInspector]
		public SdfIconType Icon;

		public TabLayouting TabLayouting;

		public List<TabGroupAttribute> Tabs;

		public TabGroupAttribute(string tab, bool useFixedHeight = false, float order = 0f)
			: this("_DefaultTabGroup", tab, useFixedHeight, order)
		{
		}

		public TabGroupAttribute(string group, string tab, bool useFixedHeight = false, float order = 0f)
			: base(group, order)
		{
			TabId = tab;
			UseFixedHeight = useFixedHeight;
			Tabs = new List<TabGroupAttribute> { this };
		}

		public TabGroupAttribute(string group, string tab, SdfIconType icon, bool useFixedHeight = false, float order = 0f)
			: this(group, tab, useFixedHeight, order)
		{
			Icon = icon;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			TabGroupAttribute tabGroupAttribute = other as TabGroupAttribute;
			if (tabGroupAttribute.TabId == null)
			{
				return;
			}
			if (tabGroupAttribute.TabLayouting != TabLayouting.MultiRow)
			{
				TabLayouting = tabGroupAttribute.TabLayouting;
			}
			UseFixedHeight = UseFixedHeight || tabGroupAttribute.UseFixedHeight;
			Paddingless = Paddingless || tabGroupAttribute.Paddingless;
			HideTabGroupIfTabGroupOnlyHasOneTab = HideTabGroupIfTabGroupOnlyHasOneTab || tabGroupAttribute.HideTabGroupIfTabGroupOnlyHasOneTab;
			bool flag = false;
			for (int i = 0; i < Tabs.Count; i++)
			{
				TabGroupAttribute tabGroupAttribute2 = Tabs[i];
				if (tabGroupAttribute2.TabId == tabGroupAttribute.TabId)
				{
					if (tabGroupAttribute2.TextColor == null)
					{
						tabGroupAttribute2.TextColor = tabGroupAttribute.TextColor;
					}
					if (tabGroupAttribute2.Icon == SdfIconType.None)
					{
						tabGroupAttribute2.Icon = tabGroupAttribute.Icon;
					}
					if (tabGroupAttribute2.TabName == null)
					{
						tabGroupAttribute2.TabName = tabGroupAttribute.TabName;
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Tabs.Add(tabGroupAttribute);
			}
		}

		IList<PropertyGroupAttribute> ISubGroupProviderAttribute.GetSubGroupAttributes()
		{
			int num = 0;
			List<PropertyGroupAttribute> list = new List<PropertyGroupAttribute>(Tabs.Count)
			{
				new TabSubGroupAttribute(this, GroupID + "/" + TabId, num++)
			};
			foreach (TabGroupAttribute tab in Tabs)
			{
				if (tab.TabId != TabId)
				{
					list.Add(new TabSubGroupAttribute(tab, GroupID + "/" + tab.TabId, num++));
				}
			}
			return list;
		}

		string ISubGroupProviderAttribute.RepathMemberAttribute(PropertyGroupAttribute attr)
		{
			TabGroupAttribute tabGroupAttribute = (TabGroupAttribute)attr;
			return GroupID + "/" + tabGroupAttribute.TabId;
		}
	}
	public enum TabLayouting
	{
		MultiRow,
		Shrink
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class TableColumnWidthAttribute : Attribute
	{
		public int Width;

		public bool Resizable = true;

		public TableColumnWidthAttribute(int width, bool resizable = true)
		{
			Width = width;
			Resizable = resizable;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class TableListAttribute : Attribute
	{
		public int NumberOfItemsPerPage;

		public bool IsReadOnly;

		public int DefaultMinColumnWidth = 40;

		public bool ShowIndexLabels;

		public bool DrawScrollView = true;

		public int MinScrollViewHeight = 350;

		public int MaxScrollViewHeight;

		public bool AlwaysExpanded;

		public bool HideToolbar;

		public int CellPadding = 2;

		[SerializeField]
		[HideInInspector]
		private bool showPagingHasValue;

		[SerializeField]
		[HideInInspector]
		private bool showPaging;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showPaging", "showPagingHasValue" })]
		public bool ShowPaging
		{
			get
			{
				return showPaging;
			}
			set
			{
				showPaging = value;
				showPagingHasValue = true;
			}
		}

		public bool ShowPagingHasValue => showPagingHasValue;

		public int ScrollViewHeight
		{
			get
			{
				return Math.Min(MinScrollViewHeight, MaxScrollViewHeight);
			}
			set
			{
				MinScrollViewHeight = (MaxScrollViewHeight = value);
			}
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	[Conditional("UNITY_EDITOR")]
	public class TableMatrixAttribute : Attribute
	{
		public bool IsReadOnly;

		public bool ResizableColumns = true;

		public string VerticalTitle;

		public string HorizontalTitle;

		public string DrawElementMethod;

		public int RowHeight;

		public bool SquareCells;

		public bool HideColumnIndices;

		public bool HideRowIndices;

		public bool RespectIndentLevel = true;

		public bool Transpose;

		public string Labels;
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class TitleAttribute : Attribute
	{
		public string Title;

		public string Subtitle;

		public bool Bold;

		public bool HorizontalLine;

		public TitleAlignments TitleAlignment;

		public TitleAttribute(string title, string subtitle = null, TitleAlignments titleAlignment = TitleAlignments.Left, bool horizontalLine = true, bool bold = true)
		{
			Title = title ?? "null";
			Subtitle = subtitle;
			Bold = bold;
			TitleAlignment = titleAlignment;
			HorizontalLine = horizontalLine;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class TitleGroupAttribute : PropertyGroupAttribute
	{
		public string Subtitle;

		public TitleAlignments Alignment;

		public bool HorizontalLine;

		public bool BoldTitle;

		public bool Indent;

		public TitleGroupAttribute(string title, string subtitle = null, TitleAlignments alignment = TitleAlignments.Left, bool horizontalLine = true, bool boldTitle = true, bool indent = false, float order = 0f)
			: base(title, order)
		{
			Subtitle = subtitle;
			Alignment = alignment;
			HorizontalLine = horizontalLine;
			BoldTitle = boldTitle;
			Indent = indent;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			TitleGroupAttribute titleGroupAttribute = other as TitleGroupAttribute;
			if (Subtitle != null)
			{
				titleGroupAttribute.Subtitle = Subtitle;
			}
			else
			{
				Subtitle = titleGroupAttribute.Subtitle;
			}
			if (Alignment != TitleAlignments.Left)
			{
				titleGroupAttribute.Alignment = Alignment;
			}
			else
			{
				Alignment = titleGroupAttribute.Alignment;
			}
			if (!HorizontalLine)
			{
				titleGroupAttribute.HorizontalLine = HorizontalLine;
			}
			else
			{
				HorizontalLine = titleGroupAttribute.HorizontalLine;
			}
			if (!BoldTitle)
			{
				titleGroupAttribute.BoldTitle = BoldTitle;
			}
			else
			{
				BoldTitle = titleGroupAttribute.BoldTitle;
			}
			if (Indent)
			{
				titleGroupAttribute.Indent = Indent;
			}
			else
			{
				Indent = titleGroupAttribute.Indent;
			}
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ToggleAttribute : Attribute
	{
		public string ToggleMemberName;

		[LabelWidth(160f)]
		public bool CollapseOthersOnExpand;

		public ToggleAttribute(string toggleMemberName)
		{
			ToggleMemberName = toggleMemberName;
			CollapseOthersOnExpand = true;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ToggleGroupAttribute : PropertyGroupAttribute
	{
		public string ToggleGroupTitle;

		[LabelWidth(160f)]
		public bool CollapseOthersOnExpand;

		public string ToggleMemberName => GroupName;

		[Obsolete("Add a $ infront of group title instead, i.e: \"$MyStringMember\".")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string TitleStringMemberName { get; set; }

		public ToggleGroupAttribute(string toggleMemberName, float order = 0f, string groupTitle = null)
			: base(toggleMemberName, order)
		{
			ToggleGroupTitle = groupTitle;
			CollapseOthersOnExpand = true;
		}

		public ToggleGroupAttribute(string toggleMemberName, string groupTitle)
			: this(toggleMemberName, 0f, groupTitle)
		{
		}

		[Obsolete("Use [ToggleGroup(\"toggleMemberName\", groupTitle: \"$titleStringMemberName\")] instead")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ToggleGroupAttribute(string toggleMemberName, float order, string groupTitle, string titleStringMemberName)
			: base(toggleMemberName, order)
		{
			ToggleGroupTitle = groupTitle;
			CollapseOthersOnExpand = true;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			ToggleGroupAttribute toggleGroupAttribute = other as ToggleGroupAttribute;
			if (ToggleGroupTitle == null)
			{
				ToggleGroupTitle = toggleGroupAttribute.ToggleGroupTitle;
			}
			else if (toggleGroupAttribute.ToggleGroupTitle == null)
			{
				toggleGroupAttribute.ToggleGroupTitle = ToggleGroupTitle;
			}
			CollapseOthersOnExpand = CollapseOthersOnExpand && toggleGroupAttribute.CollapseOthersOnExpand;
			toggleGroupAttribute.CollapseOthersOnExpand = CollapseOthersOnExpand;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ToggleLeftAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class TypeDrawerSettingsAttribute : Attribute
	{
		public Type BaseType;

		public TypeInclusionFilter Filter = TypeInclusionFilter.IncludeAll;
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class TypeFilterAttribute : Attribute
	{
		public string FilterGetter;

		public string DropdownTitle;

		public bool DrawValueNormally;

		[Obsolete("Use the FilterGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return FilterGetter;
			}
			set
			{
				FilterGetter = value;
			}
		}

		public TypeFilterAttribute(string filterGetter)
		{
			FilterGetter = filterGetter;
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class TypeInfoBoxAttribute : Attribute
	{
		public string Message;

		public TypeInfoBoxAttribute(string message)
		{
			Message = message;
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	public class TypeRegistryItemAttribute : Attribute
	{
		public string Name;

		public string CategoryPath;

		public SdfIconType Icon;

		public Color? LightIconColor;

		public Color? DarkIconColor;

		public int Priority;

		public TypeRegistryItemAttribute(string name = null, string categoryPath = null, SdfIconType icon = SdfIconType.None, float lightIconColorR = 0f, float lightIconColorG = 0f, float lightIconColorB = 0f, float lightIconColorA = 0f, float darkIconColorR = 0f, float darkIconColorG = 0f, float darkIconColorB = 0f, float darkIconColorA = 0f, int priority = 0)
		{
			Name = name;
			CategoryPath = categoryPath;
			Icon = icon;
			if (lightIconColorR != 0f || lightIconColorG != 0f || lightIconColorB != 0f || lightIconColorA > 0f)
			{
				LightIconColor = new Color(lightIconColorR, lightIconColorG, lightIconColorB, (lightIconColorA > 0f) ? lightIconColorA : 1f);
			}
			else
			{
				LightIconColor = null;
			}
			if (darkIconColorR != 0f || darkIconColorG != 0f || darkIconColorB != 0f || darkIconColorA > 0f)
			{
				DarkIconColor = new Color(darkIconColorR, darkIconColorG, darkIconColorB, (darkIconColorA > 0f) ? darkIconColorA : 1f);
			}
			else
			{
				DarkIconColor = null;
			}
			Priority = priority;
		}
	}
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class TypeSelectorSettingsAttribute : Attribute
	{
		public const string FILTER_TYPES_FUNCTION_NAMED_VALUE = "type";

		public string FilterTypesFunction;

		private bool? showNoneItem;

		private bool? showCategories;

		private bool? preferNamespaces;

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showNoneItem" })]
		public bool ShowNoneItem
		{
			get
			{
				return showNoneItem == true;
			}
			set
			{
				showNoneItem = value;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "showCategories" })]
		public bool ShowCategories
		{
			get
			{
				return showCategories == true;
			}
			set
			{
				showCategories = value;
			}
		}

		[ShowInInspector]
		[OdinDesignerBinding(new string[] { "preferNamespaces" })]
		public bool PreferNamespaces
		{
			get
			{
				return preferNamespaces == true;
			}
			set
			{
				preferNamespaces = value;
			}
		}

		public bool ShowNoneItemIsSet => showNoneItem.HasValue;

		public bool ShowCategoriesIsSet => showCategories.HasValue;

		public bool PreferNamespacesIsSet => preferNamespaces.HasValue;
	}
	public class UnitAttribute : Attribute
	{
		public Units Base = Units.Unset;

		public Units Display = Units.Unset;

		public string BaseName;

		public string DisplayName;

		public bool DisplayAsString;

		public bool ForceDisplayUnit;

		public UnitAttribute(Units unit)
		{
			Base = unit;
			Display = unit;
		}

		public UnitAttribute(string unit)
		{
			BaseName = unit;
			DisplayName = unit;
		}

		public UnitAttribute(Units @base, Units display)
		{
			Base = @base;
			Display = display;
		}

		public UnitAttribute(Units @base, string display)
		{
			Base = @base;
			DisplayName = display;
		}

		public UnitAttribute(string @base, Units display)
		{
			BaseName = @base;
			Display = display;
		}

		public UnitAttribute(string @base, string display)
		{
			BaseName = @base;
			DisplayName = display;
		}
	}
	public enum Units
	{
		Unset = -1,
		Nanometer,
		Micrometer,
		Millimeter,
		Centimeter,
		Meter,
		Kilometer,
		Inch,
		Feet,
		Mile,
		Yard,
		NauticalMile,
		LightYear,
		Parsec,
		AstronomicalUnit,
		CubicMeter,
		CubicKilometer,
		CubicCentimeter,
		CubicMillimeter,
		Liter,
		Milliliter,
		Centiliter,
		Deciliter,
		Hectoliter,
		CubicInch,
		CubicFeet,
		CubicYard,
		AcreFeet,
		BarrelOil,
		TeaspoonUS,
		TablespoonUS,
		CupUS,
		GillUS,
		PintUS,
		QuartUS,
		GallonUS,
		BarrelUS,
		FluidOunceUS,
		BarrelUK,
		FluidOunceUK,
		TeaspoonUK,
		TablespoonUK,
		CupUK,
		GillUK,
		PintUK,
		QuartUK,
		GallonUK,
		SquareMeter,
		SquareKilometer,
		SquareCentimeter,
		SquareMillimeter,
		SquareMicrometer,
		SquareInch,
		SquareFeet,
		SquareYard,
		SquareMile,
		Hectare,
		Acre,
		Are,
		Joule,
		Kilojoule,
		WattHour,
		KilowattHour,
		HorsepowerHour,
		Newton,
		Kilonewton,
		Meganewton,
		Giganewton,
		Teranewton,
		Centinewton,
		Millinewton,
		JouleMeter,
		JouleCentimeter,
		GramForce,
		KilogramForce,
		TonForce,
		PoundForce,
		KilopoundForce,
		OunceForce,
		MetersPerSecond,
		MetersPerMinute,
		MetersPerHour,
		KilometersPerSecond,
		KilometersPerMinute,
		KilometersPerHour,
		CentimetersPerSecond,
		CentimetersPerMinute,
		CentimetersPerHour,
		MillimetersPerSecond,
		MillimetersPerMinute,
		MillimetersPerHour,
		FeetPerSecond,
		FeetPerMinute,
		FeetPerHour,
		YardsPerSecond,
		YardsPerMinute,
		YardsPerHour,
		MilesPerSecond,
		MilesPerMinute,
		MilesPerHour,
		Knot,
		KnotUK,
		SpeedOfLight,
		Bit,
		Kilobit,
		Megabit,
		Gigabit,
		Terabit,
		Petabit,
		Byte,
		Kilobyte,
		Kibibyte,
		Megabyte,
		Mebibyte,
		Gigabyte,
		Gibibyte,
		Terabyte,
		Tebibyte,
		Petabyte,
		Pebibyte,
		Kilogram,
		Hectogram,
		Dekagram,
		Gram,
		Decigram,
		Centigram,
		Milligram,
		MetricTon,
		Pounds,
		ShortTon,
		LongTon,
		Ounce,
		StoneUS,
		StoneUK,
		QuarterUS,
		QuarterUK,
		Slug,
		Grain,
		Celsius,
		Fahrenheit,
		Kelvin,
		Pascal,
		Decipascal,
		Centipascal,
		Millipascal,
		Micropascal,
		Kilopascal,
		Megapascal,
		Gigapascal,
		Bar,
		Millibar,
		Microbar,
		PSI,
		KSI,
		StandardAtmosphere,
		Watt,
		Kilowatt,
		Megawatt,
		Gigawatt,
		Terawatt,
		Horsepower,
		JouleSecond,
		JouleMinute,
		JouleHour,
		KilojouleSecond,
		KilojouleMinute,
		KilojouleHour,
		Second,
		Millisecond,
		Microsecond,
		Nanosecond,
		Minute,
		Hour,
		Day,
		Week,
		Radian,
		Degree,
		Turn,
		Grad,
		SecondsOfAngle,
		MinutesOfAngle,
		Mil,
		MetersPerSecondSquared,
		DecimetersPerSecondSquared,
		CentimetersPerSecondSquared,
		MillimetersPerSecondSquared,
		MicrometersPerSecondSquared,
		DekametersPerSecondSquared,
		HectometersPerSecondSquared,
		KilometersPerSecondSquared,
		MilePerSecondSquared,
		YardPerSecondSquared,
		FeetPerSecondSquared,
		InchPerSecondSquared,
		GForce,
		NewtonMeter,
		NewtonCentimeter,
		NewtonMillimeter,
		KilonewtonMeter,
		KilogramForceMeter,
		KilogramForceCentimeter,
		KilogramForceMillimeter,
		GramForceMeter,
		GramForceCentimeter,
		GramForceMillimeter,
		PoundFeet,
		PoundInch,
		OuncecFeet,
		OuncecInch,
		RadiansPerSecond,
		RadiansPerMinute,
		RadiansPerHour,
		RadiansPerDay,
		DegreesPerSecond,
		DegreesPerMinute,
		DegreesPerHour,
		DegreesPerDay,
		RevolutionsPerSecond,
		RevolutionsPerMinute,
		RevolutionsPerHour,
		RevolutionsPerDay,
		Hertz,
		Kilohertz,
		Megahertz,
		Gigahertz,
		PercentMultiplier,
		Percent,
		Permille,
		Permyriad
	}
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ValidateInputAttribute : Attribute
	{
		public string DefaultMessage;

		public string Condition;

		public InfoMessageType MessageType;

		public bool IncludeChildren;

		[LabelWidth(170f)]
		public bool ContinuousValidationCheck;

		[Obsolete("Use the Condition member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return Condition;
			}
			set
			{
				Condition = value;
			}
		}

		[Obsolete("Use the ContinuousValidationCheck member instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ContiniousValidationCheck
		{
			get
			{
				return ContinuousValidationCheck;
			}
			set
			{
				ContinuousValidationCheck = value;
			}
		}

		public ValidateInputAttribute(string condition, string defaultMessage = null, InfoMessageType messageType = InfoMessageType.Error)
		{
			Condition = condition;
			DefaultMessage = defaultMessage;
			MessageType = messageType;
			IncludeChildren = true;
		}

		[Obsolete("Rejecting invalid input is no longer supported. Use the other constructor instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ValidateInputAttribute(string condition, string message, InfoMessageType messageType, bool rejectedInvalidInput)
		{
			Condition = condition;
			DefaultMessage = message;
			MessageType = messageType;
			IncludeChildren = true;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class ValueDropdownAttribute : Attribute
	{
		public string ValuesGetter;

		[LabelWidth(230f)]
		public int NumberOfItemsBeforeEnablingSearch;

		[LabelWidth(230f)]
		public bool IsUniqueList;

		[LabelWidth(230f)]
		public bool DrawDropdownForListElements;

		[LabelWidth(230f)]
		public bool DisableListAddButtonBehaviour;

		[LabelWidth(230f)]
		public bool ExcludeExistingValuesInList;

		[LabelWidth(230f)]
		public bool ExpandAllMenuItems;

		[LabelWidth(230f)]
		public bool AppendNextDrawer;

		[LabelWidth(230f)]
		public bool DisableGUIInAppendedDrawer;

		[LabelWidth(230f)]
		public bool DoubleClickToConfirm;

		[LabelWidth(230f)]
		public bool FlattenTreeView;

		public int DropdownWidth;

		public int DropdownHeight;

		public string DropdownTitle;

		[LabelWidth(230f)]
		public bool SortDropdownItems;

		[LabelWidth(230f)]
		public bool HideChildProperties;

		[LabelWidth(230f)]
		public bool CopyValues = true;

		[LabelWidth(230f)]
		public bool OnlyChangeValueOnConfirm;

		[Obsolete("Use the ValuesGetter member instead.", false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string MemberName
		{
			get
			{
				return ValuesGetter;
			}
			set
			{
				ValuesGetter = value;
			}
		}

		public ValueDropdownAttribute(string valuesGetter)
		{
			NumberOfItemsBeforeEnablingSearch = 10;
			ValuesGetter = valuesGetter;
			DrawDropdownForListElements = true;
		}
	}
	public interface IValueDropdownItem
	{
		string GetText();

		object GetValue();
	}
	public class ValueDropdownList<T> : List<ValueDropdownItem<T>>
	{
		public void Add(string text, T value)
		{
			Add(new ValueDropdownItem<T>(text, value));
		}

		public void Add(T value)
		{
			Add(new ValueDropdownItem<T>(value.ToString(), value));
		}
	}
	public struct ValueDropdownItem(string text, object value) : IValueDropdownItem
	{
		public string Text = text;

		public object Value = value;

		public override string ToString()
		{
			return Text ?? Value?.ToString() ?? "";
		}

		string IValueDropdownItem.GetText()
		{
			return Text;
		}

		object IValueDropdownItem.GetValue()
		{
			return Value;
		}
	}
	public struct ValueDropdownItem<T>(string text, T value) : IValueDropdownItem
	{
		public string Text = text;

		public T Value = value;

		string IValueDropdownItem.GetText()
		{
			return Text;
		}

		object IValueDropdownItem.GetValue()
		{
			return Value;
		}

		public override string ToString()
		{
			object obj = Text;
			if (obj == null)
			{
				T value = Value;
				obj = value?.ToString() ?? "";
			}
			return (string)obj;
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class VerticalGroupAttribute : PropertyGroupAttribute
	{
		public float PaddingTop;

		public float PaddingBottom;

		public VerticalGroupAttribute(string groupId, float order = 0f)
			: base(groupId, order)
		{
		}

		public VerticalGroupAttribute(float order = 0f)
			: this("_DefaultVerticalGroup", order)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			if (other is VerticalGroupAttribute verticalGroupAttribute)
			{
				if (verticalGroupAttribute.PaddingTop != 0f)
				{
					PaddingTop = verticalGroupAttribute.PaddingTop;
				}
				if (verticalGroupAttribute.PaddingBottom != 0f)
				{
					PaddingBottom = verticalGroupAttribute.PaddingBottom;
				}
			}
		}
	}
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class WrapAttribute : Attribute
	{
		public double Min;

		public double Max;

		public WrapAttribute(double min, double max)
		{
			Min = ((min < max) ? min : max);
			Max = ((max > min) ? max : min);
		}
	}
	public static class AttributeTargetFlags
	{
		public const AttributeTargets Default = AttributeTargets.All;
	}
	public enum ButtonSizes
	{
		Small = 0,
		Medium = 22,
		Large = 31,
		Gigantic = 62
	}
	public enum DictionaryDisplayOptions
	{
		OneLine,
		Foldout,
		CollapsedFoldout,
		ExpandedFoldout
	}
	public enum IconAlignment
	{
		LeftOfText,
		RightOfText,
		LeftEdge,
		RightEdge
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class IncludeMyAttributesAttribute : Attribute
	{
	}
	public enum InfoMessageType
	{
		None,
		Info,
		Warning,
		Error
	}
	public enum InlineEditorModes
	{
		GUIOnly,
		GUIAndHeader,
		GUIAndPreview,
		SmallPreview,
		LargePreview,
		FullEditor
	}
	public enum InlineEditorObjectFieldModes
	{
		Boxed,
		Foldout,
		Hidden,
		CompletelyHidden
	}
	public interface ISearchFilterable
	{
		bool IsMatch(string searchString);
	}
	public interface ISelfValidator
	{
		void Validate(SelfValidationResult result);
	}
	[EnumToggleButtons]
	public enum ValidatorSeverity
	{
		Error,
		Warning,
		Ignore
	}
	public static class SelfValidationResultItemExtensions
	{
		public static ref SelfValidationResult.ResultItem WithFix(this ref SelfValidationResult.ResultItem item, string title, Action fix, bool offerInInspector = true)
		{
			item.Fix = SelfFix.Create(title, fix, offerInInspector);
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithFix<T>(this ref SelfValidationResult.ResultItem item, string title, Action<T> fix, bool offerInInspector = true) where T : new()
		{
			item.Fix = SelfFix.Create(title, fix, offerInInspector);
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithFix(this ref SelfValidationResult.ResultItem item, Action fix, bool offerInInspector = true)
		{
			item.Fix = SelfFix.Create(fix, offerInInspector);
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithFix<T>(this ref SelfValidationResult.ResultItem item, Action<T> fix, bool offerInInspector = true) where T : new()
		{
			item.Fix = SelfFix.Create(fix, offerInInspector);
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithFix(this ref SelfValidationResult.ResultItem item, SelfFix fix)
		{
			item.Fix = fix;
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithContextClick(this ref SelfValidationResult.ResultItem item, Func<IEnumerable<SelfValidationResult.ContextMenuItem>> onContextClick)
		{
			ref Func<IEnumerable<SelfValidationResult.ContextMenuItem>> onContextClick2 = ref item.OnContextClick;
			onContextClick2 = (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)Delegate.Combine(onContextClick2, onContextClick);
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithContextClick(this ref SelfValidationResult.ResultItem item, string path, Action onClick)
		{
			ref Func<IEnumerable<SelfValidationResult.ContextMenuItem>> onContextClick = ref item.OnContextClick;
			onContextClick = (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)Delegate.Combine(onContextClick, (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)(() => new SelfValidationResult.ContextMenuItem[1]
			{
				new SelfValidationResult.ContextMenuItem
				{
					Path = path,
					OnClick = onClick
				}
			}));
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithContextClick(this ref SelfValidationResult.ResultItem item, string path, bool on, Action onClick)
		{
			ref Func<IEnumerable<SelfValidationResult.ContextMenuItem>> onContextClick = ref item.OnContextClick;
			onContextClick = (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)Delegate.Combine(onContextClick, (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)(() => new SelfValidationResult.ContextMenuItem[1]
			{
				new SelfValidationResult.ContextMenuItem
				{
					Path = path,
					On = on,
					OnClick = onClick
				}
			}));
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithContextClick(this ref SelfValidationResult.ResultItem item, SelfValidationResult.ContextMenuItem onContextClick)
		{
			ref Func<IEnumerable<SelfValidationResult.ContextMenuItem>> onContextClick2 = ref item.OnContextClick;
			onContextClick2 = (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)Delegate.Combine(onContextClick2, (Func<IEnumerable<SelfValidationResult.ContextMenuItem>>)(() => new SelfValidationResult.ContextMenuItem[1] { onContextClick }));
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithSceneGUI(this ref SelfValidationResult.ResultItem item, Action onSceneGUI)
		{
			item.OnSceneGUI = onSceneGUI;
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem SetSelectionObject(this ref SelfValidationResult.ResultItem item, UnityEngine.Object uObj)
		{
			item.SelectionObject = uObj;
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem EnableRichText(this ref SelfValidationResult.ResultItem item)
		{
			item.RichText = true;
			return ref item;
		}

		public static ref SelfValidationResult.ResultItem WithMetaData(this ref SelfValidationResult.ResultItem resultItem, string name, object value, params Attribute[] attributes)
		{
			resultItem.MetaData = resultItem.MetaData ?? new SelfValidationResult.ResultItemMetaData[0];
			Array.Resize(ref resultItem.MetaData, resultItem.MetaData.Length + 1);
			resultItem.MetaData[resultItem.MetaData.Length - 1] = new SelfValidationResult.ResultItemMetaData(name, value, attributes);
			return ref resultItem;
		}

		public static ref SelfValidationResult.ResultItem WithMetaData(this ref SelfValidationResult.ResultItem resultItem, object value, params Attribute[] attributes)
		{
			resultItem.MetaData = resultItem.MetaData ?? new SelfValidationResult.ResultItemMetaData[0];
			Array.Resize(ref resultItem.MetaData, resultItem.MetaData.Length + 1);
			resultItem.MetaData[resultItem.MetaData.Length - 1] = new SelfValidationResult.ResultItemMetaData(null, value, attributes);
			return ref resultItem;
		}

		public static ref SelfValidationResult.ResultItem WithButton(this ref SelfValidationResult.ResultItem resultItem, string name, Action onClick)
		{
			resultItem.MetaData = resultItem.MetaData ?? new SelfValidationResult.ResultItemMetaData[0];
			Array.Resize(ref resultItem.MetaData, resultItem.MetaData.Length + 1);
			resultItem.MetaData[resultItem.MetaData.Length - 1] = new SelfValidationResult.ResultItemMetaData(name, onClick);
			return ref resultItem;
		}
	}
	public class SelfValidationResult
	{
		public struct ContextMenuItem
		{
			public string Path;

			public bool On;

			public bool AddSeparatorBefore;

			public Action OnClick;
		}

		public enum ResultType
		{
			Error,
			Warning,
			Valid
		}

		public struct ResultItem
		{
			public string Message;

			public ResultType ResultType;

			public SelfFix? Fix;

			public ResultItemMetaData[] MetaData;

			public Func<IEnumerable<ContextMenuItem>> OnContextClick;

			public Action OnSceneGUI;

			public UnityEngine.Object SelectionObject;

			public bool RichText;
		}

		public struct ResultItemMetaData(string name, object value, params Attribute[] attributes)
		{
			public string Name = name;

			public object Value = value;

			public Attribute[] Attributes = attributes;
		}

		private static ResultItem NoResultItem;

		private ResultItem[] items;

		private int itemsCount;

		public int Count => itemsCount;

		public ref ResultItem this[int index] => ref items[index];

		public ref ResultItem AddError(string error)
		{
			return ref Add(new ResultItem
			{
				Message = error,
				ResultType = ResultType.Error
			});
		}

		public ref ResultItem AddWarning(string warning)
		{
			return ref Add(new ResultItem
			{
				Message = warning,
				ResultType = ResultType.Warning
			});
		}

		public ref ResultItem Add(ValidatorSeverity severity, string message)
		{
			switch (severity)
			{
			case ValidatorSeverity.Error:
				return ref Add(new ResultItem
				{
					Message = message,
					ResultType = ResultType.Error
				});
			case ValidatorSeverity.Warning:
				return ref Add(new ResultItem
				{
					Message = message,
					ResultType = ResultType.Warning
				});
			default:
				NoResultItem = default(ResultItem);
				return ref NoResultItem;
			}
		}

		public ref ResultItem Add(ResultItem item)
		{
			ResultItem[] array = items;
			if (array == null)
			{
				array = (items = new ResultItem[2]);
			}
			while (array.Length <= itemsCount + 1)
			{
				ResultItem[] array2 = new ResultItem[array.Length * 2];
				for (int i = 0; i < array.Length; i++)
				{
					array2[i] = array[i];
				}
				array = array2;
				items = array2;
			}
			array[itemsCount] = item;
			return ref array[itemsCount++];
		}
	}
	public class SelfMetaData : List<SelfValidationResult.ResultItemMetaData>
	{
		public void Add(string key, object value)
		{
			Add(new SelfValidationResult.ResultItemMetaData(key, value));
		}
	}
	public struct SelfFix
	{
		public string Title;

		public Delegate Action;

		public bool OfferInInspector;

		public SelfFix(string name, Action action, bool offerInInspector)
		{
			Title = name;
			Action = action;
			OfferInInspector = offerInInspector;
		}

		public SelfFix(string name, Delegate action, bool offerInInspector)
		{
			Title = name;
			Action = action;
			OfferInInspector = offerInInspector;
		}

		public static SelfFix Create(Action action, bool offerInInspector = true)
		{
			return new SelfFix("Fix", action, offerInInspector);
		}

		public static SelfFix Create(string title, Action action, bool offerInInspector = true)
		{
			return new SelfFix(title, action, offerInInspector);
		}

		public static SelfFix Create<T>(Action<T> action, bool offerInInspector = true) where T : new()
		{
			return new SelfFix("Fix", action, offerInInspector);
		}

		public static SelfFix Create<T>(string title, Action<T> action, bool offerInInspector = true) where T : new()
		{
			return new SelfFix(title, action, offerInInspector);
		}
	}
	public enum ObjectFieldAlignment
	{
		Left,
		Center,
		Right
	}
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public class OdinRegisterAttributeAttribute : Attribute
	{
		public Type AttributeType;

		public string Categories;

		public string Description;

		public string DocumentationUrl;

		public bool IsEnterprise;

		public OdinRegisterAttributeAttribute(Type attributeType, string category, string description, bool isEnterprise)
		{
			AttributeType = attributeType;
			Categories = category;
			Description = description;
			IsEnterprise = isEnterprise;
		}

		public OdinRegisterAttributeAttribute(Type attributeType, string category, string description, bool isEnterprise, string url)
		{
			AttributeType = attributeType;
			Categories = category;
			Description = description;
			IsEnterprise = isEnterprise;
			DocumentationUrl = url;
		}
	}
	[Flags]
	public enum PrefabKind
	{
		None = 0,
		InstanceInScene = 1,
		InstanceInPrefab = 2,
		Regular = 4,
		Variant = 8,
		NonPrefabInstance = 0x10,
		PrefabInstance = 3,
		PrefabAsset = 0xC,
		PrefabInstanceAndNonPrefabInstance = 0x13,
		All = 0x1F
	}
	public enum PreviewAlignment
	{
		Left,
		Right,
		Top,
		Bottom
	}
	public enum SdfIconType
	{
		None,
		AlarmFill,
		Alarm,
		AlignBottom,
		AlignCenter,
		AlignEnd,
		AlignMiddle,
		AlignStart,
		AlignTop,
		Alt,
		AppIndicator,
		App,
		ArchiveFill,
		Archive,
		Arrow90degDown,
		Arrow90degLeft,
		Arrow90degRight,
		Arrow90degUp,
		ArrowBarDown,
		ArrowBarLeft,
		ArrowBarRight,
		ArrowBarUp,
		ArrowClockwise,
		ArrowCounterclockwise,
		ArrowDownCircleFill,
		ArrowDownCircle,
		ArrowDownLeftCircleFill,
		ArrowDownLeftCircle,
		ArrowDownLeftSquareFill,
		ArrowDownLeftSquare,
		ArrowDownLeft,
		ArrowDownRightCircleFill,
		ArrowDownRightCircle,
		ArrowDownRightSquareFill,
		ArrowDownRightSquare,
		ArrowDownRight,
		ArrowDownShort,
		ArrowDownSquareFill,
		ArrowDownSquare,
		ArrowDownUp,
		ArrowDown,
		ArrowLeftCircleFill,
		ArrowLeftCircle,
		ArrowLeftRight,
		ArrowLeftShort,
		ArrowLeftSquareFill,
		ArrowLeftSquare,
		ArrowLeft,
		ArrowRepeat,
		ArrowReturnLeft,
		ArrowReturnRight,
		ArrowRightCircleFill,
		ArrowRightCircle,
		ArrowRightShort,
		ArrowRightSquareFill,
		ArrowRightSquare,
		ArrowRight,
		ArrowUpCircleFill,
		ArrowUpCircle,
		ArrowUpLeftCircleFill,
		ArrowUpLeftCircle,
		ArrowUpLeftSquareFill,
		ArrowUpLeftSquare,
		ArrowUpLeft,
		ArrowUpRightCircleFill,
		ArrowUpRightCircle,
		ArrowUpRightSquareFill,
		ArrowUpRightSquare,
		ArrowUpRight,
		ArrowUpShort,
		ArrowUpSquareFill,
		ArrowUpSquare,
		ArrowUp,
		ArrowsAngleContract,
		ArrowsAngleExpand,
		ArrowsCollapse,
		ArrowsExpand,
		ArrowsFullscreen,
		ArrowsMove,
		AspectRatioFill,
		AspectRatio,
		Asterisk,
		At,
		AwardFill,
		Award,
		Back,
		BackspaceFill,
		BackspaceReverseFill,
		BackspaceReverse,
		Backspace,
		Badge3dFill,
		Badge3d,
		Badge4kFill,
		Badge4k,
		Badge8kFill,
		Badge8k,
		BadgeAdFill,
		BadgeAd,
		BadgeArFill,
		BadgeAr,
		BadgeCcFill,
		BadgeCc,
		BadgeHdFill,
		BadgeHd,
		BadgeTmFill,
		BadgeTm,
		BadgeVoFill,
		BadgeVo,
		BadgeVrFill,
		BadgeVr,
		BadgeWcFill,
		BadgeWc,
		BagCheckFill,
		BagCheck,
		BagDashFill,
		BagDash,
		BagFill,
		BagPlusFill,
		BagPlus,
		BagXFill,
		BagX,
		Bag,
		BarChartFill,
		BarChartLineFill,
		BarChartLine,
		BarChartSteps,
		BarChart,
		BasketFill,
		Basket,
		Basket2Fill,
		Basket2,
		Basket3Fill,
		Basket3,
		BatteryCharging,
		BatteryFull,
		BatteryHalf,
		Battery,
		BellFill,
		Bell,
		Bezier,
		Bezier2,
		Bicycle,
		BinocularsFill,
		Binoculars,
		BlockquoteLeft,
		BlockquoteRight,
		BookFill,
		BookHalf,
		Book,
		BookmarkCheckFill,
		BookmarkCheck,
		BookmarkDashFill,
		BookmarkDash,
		BookmarkFill,
		BookmarkHeartFill,
		BookmarkHeart,
		BookmarkPlusFill,
		BookmarkPlus,
		BookmarkStarFill,
		BookmarkStar,
		BookmarkXFill,
		BookmarkX,
		Bookmark,
		BookmarksFill,
		Bookmarks,
		Bookshelf,
		BootstrapFill,
		BootstrapReboot,
		Bootstrap,
		BorderAll,
		BorderBottom,
		BorderCenter,
		BorderInner,
		BorderLeft,
		BorderMiddle,
		BorderOuter,
		BorderRight,
		BorderStyle,
		BorderTop,
		BorderWidth,
		Border,
		BoundingBoxCircles,
		BoundingBox,
		BoxArrowDownLeft,
		BoxArrowDownRight,
		BoxArrowDown,
		BoxArrowInDownLeft,
		BoxArrowInDownRight,
		BoxArrowInDown,
		BoxArrowInLeft,
		BoxArrowInRight,
		BoxArrowInUpLeft,
		BoxArrowInUpRight,
		BoxArrowInUp,
		BoxArrowLeft,
		BoxArrowRight,
		BoxArrowUpLeft,
		BoxArrowUpRight,
		BoxArrowUp,
		BoxSeam,
		Box,
		Braces,
		Bricks,
		BriefcaseFill,
		Briefcase,
		BrightnessAltHighFill,
		BrightnessAltHigh,
		BrightnessAltLowFill,
		BrightnessAltLow,
		BrightnessHighFill,
		BrightnessHigh,
		BrightnessLowFill,
		BrightnessLow,
		BroadcastPin,
		Broadcast,
		BrushFill,
		Brush,
		BucketFill,
		Bucket,
		BugFill,
		Bug,
		Building,
		Bullseye,
		CalculatorFill,
		Calculator,
		CalendarCheckFill,
		CalendarCheck,
		CalendarDateFill,
		CalendarDate,
		CalendarDayFill,
		CalendarDay,
		CalendarEventFill,
		CalendarEvent,
		CalendarFill,
		CalendarMinusFill,
		CalendarMinus,
		CalendarMonthFill,
		CalendarMonth,
		CalendarPlusFill,
		CalendarPlus,
		CalendarRangeFill,
		CalendarRange,
		CalendarWeekFill,
		CalendarWeek,
		CalendarXFill,
		CalendarX,
		Calendar,
		Calendar2CheckFill,
		Calendar2Check,
		Calendar2DateFill,
		Calendar2Date,
		Calendar2DayFill,
		Calendar2Day,
		Calendar2EventFill,
		Calendar2Event,
		Calendar2Fill,
		Calendar2MinusFill,
		Calendar2Minus,
		Calendar2MonthFill,
		Calendar2Month,
		Calendar2PlusFill,
		Calendar2Plus,
		Calendar2RangeFill,
		Calendar2Range,
		Calendar2WeekFill,
		Calendar2Week,
		Calendar2XFill,
		Calendar2X,
		Calendar2,
		Calendar3EventFill,
		Calendar3Event,
		Calendar3Fill,
		Calendar3RangeFill,
		Calendar3Range,
		Calendar3WeekFill,
		Calendar3Week,
		Calendar3,
		Calendar4Event,
		Calendar4Range,
		Calendar4Week,
		Calendar4,
		CameraFill,
		CameraReelsFill,
		CameraReels,
		CameraVideoFill,
		CameraVideoOffFill,
		CameraVideoOff,
		CameraVideo,
		Camera,
		Camera2,
		CapslockFill,
		Capslock,
		CardChecklist,
		CardHeading,
		CardImage,
		CardList,
		CardText,
		CaretDownFill,
		CaretDownSquareFill,
		CaretDownSquare,
		CaretDown,
		CaretLeftFill,
		CaretLeftSquareFill,
		CaretLeftSquare,
		CaretLeft,
		CaretRightFill,
		CaretRightSquareFill,
		CaretRightSquare,
		CaretRight,
		CaretUpFill,
		CaretUpSquareFill,
		CaretUpSquare,
		CaretUp,
		CartCheckFill,
		CartCheck,
		CartDashFill,
		CartDash,
		CartFill,
		CartPlusFill,
		CartPlus,
		CartXFill,
		CartX,
		Cart,
		Cart2,
		Cart3,
		Cart4,
		CashStack,
		Cash,
		Cast,
		ChatDotsFill,
		ChatDots,
		ChatFill,
		ChatLeftDotsFill,
		ChatLeftDots,
		ChatLeftFill,
		ChatLeftQuoteFill,
		ChatLeftQuote,
		ChatLeftTextFill,
		ChatLeftText,
		ChatLeft,
		ChatQuoteFill,
		ChatQuote,
		ChatRightDotsFill,
		ChatRightDots,
		ChatRightFill,
		ChatRightQuoteFill,
		ChatRightQuote,
		ChatRightTextFill,
		ChatRightText,
		ChatRight,
		ChatSquareDotsFill,
		ChatSquareDots,
		ChatSquareFill,
		ChatSquareQuoteFill,
		ChatSquareQuote,
		ChatSquareTextFill,
		ChatSquareText,
		ChatSquare,
		ChatTextFill,
		ChatText,
		Chat,
		CheckAll,
		CheckCircleFill,
		CheckCircle,
		CheckSquareFill,
		CheckSquare,
		Check,
		Check2All,
		Check2Circle,
		Check2Square,
		Check2,
		ChevronBarContract,
		ChevronBarDown,
		ChevronBarExpand,
		ChevronBarLeft,
		ChevronBarRight,
		ChevronBarUp,
		ChevronCompactDown,
		ChevronCompactLeft,
		ChevronCompactRight,
		ChevronCompactUp,
		ChevronContract,
		ChevronDoubleDown,
		ChevronDoubleLeft,
		ChevronDoubleRight,
		ChevronDoubleUp,
		ChevronDown,
		ChevronExpand,
		ChevronLeft,
		ChevronRight,
		ChevronUp,
		CircleFill,
		CircleHalf,
		CircleSquare,
		Circle,
		ClipboardCheck,
		ClipboardData,
		ClipboardMinus,
		ClipboardPlus,
		ClipboardX,
		Clipboard,
		ClockFill,
		ClockHistory,
		Clock,
		CloudArrowDownFill,
		CloudArrowDown,
		CloudArrowUpFill,
		CloudArrowUp,
		CloudCheckFill,
		CloudCheck,
		CloudDownloadFill,
		CloudDownload,
		CloudDrizzleFill,
		CloudDrizzle,
		CloudFill,
		CloudFogFill,
		CloudFog,
		CloudFog2Fill,
		CloudFog2,
		CloudHailFill,
		CloudHail,
		CloudHaze1,
		CloudHazeFill,
		CloudHaze,
		CloudHaze2Fill,
		CloudLightningFill,
		CloudLightningRainFill,
		CloudLightningRain,
		CloudLightning,
		CloudMinusFill,
		CloudMinus,
		CloudMoonFill,
		CloudMoon,
		CloudPlusFill,
		CloudPlus,
		CloudRainFill,
		CloudRainHeavyFill,
		CloudRainHeavy,
		CloudRain,
		CloudSlashFill,
		CloudSlash,
		CloudSleetFill,
		CloudSleet,
		CloudSnowFill,
		CloudSnow,
		CloudSunFill,
		CloudSun,
		CloudUploadFill,
		CloudUpload,
		Cloud,
		CloudsFill,
		Clouds,
		CloudyFill,
		Cloudy,
		CodeSlash,
		CodeSquare,
		Code,
		CollectionFill,
		CollectionPlayFill,
		CollectionPlay,
		Collection,
		ColumnsGap,
		Columns,
		Command,
		CompassFill,
		Compass,
		ConeStriped,
		Cone,
		Controller,
		CpuFill,
		Cpu,
		CreditCard2BackFill,
		CreditCard2Back,
		CreditCard2FrontFill,
		CreditCard2Front,
		CreditCardFill,
		CreditCard,
		Crop,
		CupFill,
		CupStraw,
		Cup,
		CursorFill,
		CursorText,
		Cursor,
		DashCircleDotted,
		DashCircleFill,
		DashCircle,
		DashSquareDotted,
		DashSquareFill,
		DashSquare,
		Dash,
		Diagram2Fill,
		Diagram2,
		Diagram3Fill,
		Diagram3,
		DiamondFill,
		DiamondHalf,
		Diamond,
		Dice1Fill,
		Dice1,
		Dice2Fill,
		Dice2,
		Dice3Fill,
		Dice3,
		Dice4Fill,
		Dice4,
		Dice5Fill,
		Dice5,
		Dice6Fill,
		Dice6,
		DiscFill,
		Disc,
		Discord,
		DisplayFill,
		Display,
		DistributeHorizontal,
		DistributeVertical,
		DoorClosedFill,
		DoorClosed,
		DoorOpenFill,
		DoorOpen,
		Dot,
		Download,
		DropletFill,
		DropletHalf,
		Droplet,
		Earbuds,
		EaselFill,
		Easel,
		EggFill,
		EggFried,
		Egg,
		EjectFill,
		Eject,
		EmojiAngryFill,
		EmojiAngry,
		EmojiDizzyFill,
		EmojiDizzy,
		EmojiExpressionlessFill,
		EmojiExpressionless,
		EmojiFrownFill,
		EmojiFrown,
		EmojiHeartEyesFill,
		EmojiHeartEyes,
		EmojiLaughingFill,
		EmojiLaughing,
		EmojiNeutralFill,
		EmojiNeutral,
		EmojiSmileFill,
		EmojiSmileUpsideDownFill,
		EmojiSmileUpsideDown,
		EmojiSmile,
		EmojiSunglassesFill,
		EmojiSunglasses,
		EmojiWinkFill,
		EmojiWink,
		EnvelopeFill,
		EnvelopeOpenFill,
		EnvelopeOpen,
		Envelope,
		EraserFill,
		Eraser,
		ExclamationCircleFill,
		ExclamationCircle,
		ExclamationDiamondFill,
		ExclamationDiamond,
		ExclamationOctagonFill,
		ExclamationOctagon,
		ExclamationSquareFill,
		ExclamationSquare,
		ExclamationTriangleFill,
		ExclamationTriangle,
		Exclamation,
		Exclude,
		EyeFill,
		EyeSlashFill,
		EyeSlash,
		Eye,
		Eyedropper,
		Eyeglasses,
		Facebook,
		FileArrowDownFill,
		FileArrowDown,
		FileArrowUpFill,
		FileArrowUp,
		FileBarGraphFill,
		FileBarGraph,
		FileBinaryFill,
		FileBinary,
		FileBreakFill,
		FileBreak,
		FileCheckFill,
		FileCheck,
		FileCodeFill,
		FileCode,
		FileDiffFill,
		FileDiff,
		FileEarmarkArrowDownFill,
		FileEarmarkArrowDown,
		FileEarmarkArrowUpFill,
		FileEarmarkArrowUp,
		FileEarmarkBarGraphFill,
		FileEarmarkBarGraph,
		FileEarmarkBinaryFill,
		FileEarmarkBinary,
		FileEarmarkBreakFill,
		FileEarmarkBreak,
		FileEarmarkCheckFill,
		FileEarmarkCheck,
		FileEarmarkCodeFill,
		FileEarmarkCode,
		FileEarmarkDiffFill,
		FileEarmarkDiff,
		FileEarmarkEaselFill,
		FileEarmarkEasel,
		FileEarmarkExcelFill,
		FileEarmarkExcel,
		FileEarmarkFill,
		FileEarmarkFontFill,
		FileEarmarkFont,
		FileEarmarkImageFill,
		FileEarmarkImage,
		FileEarmarkLockFill,
		FileEarmarkLock,
		FileEarmarkLock2Fill,
		FileEarmarkLock2,
		FileEarmarkMedicalFill,
		FileEarmarkMedical,
		FileEarmarkMinusFill,
		FileEarmarkMinus,
		FileEarmarkMusicFill,
		FileEarmarkMusic,
		FileEarmarkPersonFill,
		FileEarmarkPerson,
		FileEarmarkPlayFill,
		FileEarmarkPlay,
		FileEarmarkPlusFill,
		FileEarmarkPlus,
		FileEarmarkPostFill,
		FileEarmarkPost,
		FileEarmarkPptFill,
		FileEarmarkPpt,
		FileEarmarkRichtextFill,
		FileEarmarkRichtext,
		FileEarmarkRuledFill,
		FileEarmarkRuled,
		FileEarmarkSlidesFill,
		FileEarmarkSlides,
		FileEarmarkSpreadsheetFill,
		FileEarmarkSpreadsheet,
		FileEarmarkTextFill,
		FileEarmarkText,
		FileEarmarkWordFill,
		FileEarmarkWord,
		FileEarmarkXFill,
		FileEarmarkX,
		FileEarmarkZipFill,
		FileEarmarkZip,
		FileEarmark,
		FileEaselFill,
		FileEasel,
		FileExcelFill,
		FileExcel,
		FileFill,
		FileFontFill,
		FileFont,
		FileImageFill,
		FileImage,
		FileLockFill,
		FileLock,
		FileLock2Fill,
		FileLock2,
		FileMedicalFill,
		FileMedical,
		FileMinusFill,
		FileMinus,
		FileMusicFill,
		FileMusic,
		FilePersonFill,
		FilePerson,
		FilePlayFill,
		FilePlay,
		FilePlusFill,
		FilePlus,
		FilePostFill,
		FilePost,
		FilePptFill,
		FilePpt,
		FileRichtextFill,
		FileRichtext,
		FileRuledFill,
		FileRuled,
		FileSlidesFill,
		FileSlides,
		FileSpreadsheetFill,
		FileSpreadsheet,
		FileTextFill,
		FileText,
		FileWordFill,
		FileWord,
		FileXFill,
		FileX,
		FileZipFill,
		FileZip,
		File,
		FilesAlt,
		Files,
		Film,
		FilterCircleFill,
		FilterCircle,
		FilterLeft,
		FilterRight,
		FilterSquareFill,
		FilterSquare,
		Filter,
		FlagFill,
		Flag,
		Flower1,
		Flower2,
		Flower3,
		FolderCheck,
		FolderFill,
		FolderMinus,
		FolderPlus,
		FolderSymlinkFill,
		FolderSymlink,
		FolderX,
		Folder,
		Folder2Open,
		Folder2,
		Fonts,
		ForwardFill,
		Forward,
		Front,
		FullscreenExit,
		Fullscreen,
		FunnelFill,
		Funnel,
		GearFill,
		GearWideConnected,
		GearWide,
		Gear,
		Gem,
		GeoAltFill,
		GeoAlt,
		GeoFill,
		Geo,
		GiftFill,
		Gift,
		Github,
		Globe,
		Globe2,
		Google,
		GraphDown,
		GraphUp,
		Grid1x2Fill,
		Grid1x2,
		Grid3x2GapFill,
		Grid3x2Gap,
		Grid3x2,
		Grid3x3GapFill,
		Grid3x3Gap,
		Grid3x3,
		GridFill,
		Grid,
		GripHorizontal,
		GripVertical,
		Hammer,
		HandIndexFill,
		HandIndexThumbFill,
		HandIndexThumb,
		HandIndex,
		HandThumbsDownFill,
		HandThumbsDown,
		HandThumbsUpFill,
		HandThumbsUp,
		HandbagFill,
		Handbag,
		Hash,
		HddFill,
		HddNetworkFill,
		HddNetwork,
		HddRackFill,
		HddRack,
		HddStackFill,
		HddStack,
		Hdd,
		Headphones,
		Headset,
		HeartFill,
		HeartHalf,
		Heart,
		HeptagonFill,
		HeptagonHalf,
		Heptagon,
		HexagonFill,
		HexagonHalf,
		Hexagon,
		HourglassBottom,
		HourglassSplit,
		HourglassTop,
		Hourglass,
		HouseDoorFill,
		HouseDoor,
		HouseFill,
		House,
		Hr,
		Hurricane,
		ImageAlt,
		ImageFill,
		Image,
		Images,
		InboxFill,
		Inbox,
		InboxesFill,
		Inboxes,
		InfoCircleFill,
		InfoCircle,
		InfoSquareFill,
		InfoSquare,
		Info,
		InputCursorText,
		InputCursor,
		Instagram,
		Intersect,
		JournalAlbum,
		JournalArrowDown,
		JournalArrowUp,
		JournalBookmarkFill,
		JournalBookmark,
		JournalCheck,
		JournalCode,
		JournalMedical,
		JournalMinus,
		JournalPlus,
		JournalRichtext,
		JournalText,
		JournalX,
		Journal,
		Journals,
		Joystick,
		JustifyLeft,
		JustifyRight,
		Justify,
		KanbanFill,
		Kanban,
		KeyFill,
		Key,
		KeyboardFill,
		Keyboard,
		Ladder,
		LampFill,
		Lamp,
		LaptopFill,
		Laptop,
		LayerBackward,
		LayerForward,
		LayersFill,
		LayersHalf,
		Layers,
		LayoutSidebarInsetReverse,
		LayoutSidebarInset,
		LayoutSidebarReverse,
		LayoutSidebar,
		LayoutSplit,
		LayoutTextSidebarReverse,
		LayoutTextSidebar,
		LayoutTextWindowReverse,
		LayoutTextWindow,
		LayoutThreeColumns,
		LayoutWtf,
		LifePreserver,
		LightbulbFill,
		LightbulbOffFill,
		LightbulbOff,
		Lightbulb,
		LightningChargeFill,
		LightningCharge,
		LightningFill,
		Lightning,
		Link45deg,
		Link,
		Linkedin,
		ListCheck,
		ListNested,
		ListOl,
		ListStars,
		ListTask,
		ListUl,
		List,
		LockFill,
		Lock,
		Mailbox,
		Mailbox2,
		MapFill,
		Map,
		MarkdownFill,
		Markdown,
		Mask,
		MegaphoneFill,
		Megaphone,
		MenuAppFill,
		MenuApp,
		MenuButtonFill,
		MenuButtonWideFill,
		MenuButtonWide,
		MenuButton,
		MenuDown,
		MenuUp,
		MicFill,
		MicMuteFill,
		MicMute,
		Mic,
		MinecartLoaded,
		Minecart,
		Moisture,
		MoonFill,
		MoonStarsFill,
		MoonStars,
		Moon,
		MouseFill,
		Mouse,
		Mouse2Fill,
		Mouse2,
		Mouse3Fill,
		Mouse3,
		MusicNoteBeamed,
		MusicNoteList,
		MusicNote,
		MusicPlayerFill,
		MusicPlayer,
		Newspaper,
		NodeMinusFill,
		NodeMinus,
		NodePlusFill,
		NodePlus,
		NutFill,
		Nut,
		OctagonFill,
		OctagonHalf,
		Octagon,
		Option,
		Outlet,
		PaintBucket,
		PaletteFill,
		Palette,
		Palette2,
		Paperclip,
		Paragraph,
		PatchCheckFill,
		PatchCheck,
		PatchExclamationFill,
		PatchExclamation,
		PatchMinusFill,
		PatchMinus,
		PatchPlusFill,
		PatchPlus,
		PatchQuestionFill,
		PatchQuestion,
		PauseBtnFill,
		PauseBtn,
		PauseCircleFill,
		PauseCircle,
		PauseFill,
		Pause,
		PeaceFill,
		Peace,
		PenFill,
		Pen,
		PencilFill,
		PencilSquare,
		Pencil,
		PentagonFill,
		PentagonHalf,
		Pentagon,
		PeopleFill,
		People,
		Percent,
		PersonBadgeFill,
		PersonBadge,
		PersonBoundingBox,
		PersonCheckFill,
		PersonCheck,
		PersonCircle,
		PersonDashFill,
		PersonDash,
		PersonFill,
		PersonLinesFill,
		PersonPlusFill,
		PersonPlus,
		PersonSquare,
		PersonXFill,
		PersonX,
		Person,
		PhoneFill,
		PhoneLandscapeFill,
		PhoneLandscape,
		PhoneVibrateFill,
		PhoneVibrate,
		Phone,
		PieChartFill,
		PieChart,
		PinAngleFill,
		PinAngle,
		PinFill,
		Pin,
		PipFill,
		Pip,
		PlayBtnFill,
		PlayBtn,
		PlayCircleFill,
		PlayCircle,
		PlayFill,
		Play,
		PlugFill,
		Plug,
		PlusCircleDotted,
		PlusCircleFill,
		PlusCircle,
		PlusSquareDotted,
		PlusSquareFill,
		PlusSquare,
		Plus,
		Power,
		PrinterFill,
		Printer,
		PuzzleFill,
		Puzzle,
		QuestionCircleFill,
		QuestionCircle,
		QuestionDiamondFill,
		QuestionDiamond,
		QuestionOctagonFill,
		QuestionOctagon,
		QuestionSquareFill,
		QuestionSquare,
		Question,
		Rainbow,
		ReceiptCutoff,
		Receipt,
		Reception0,
		Reception1,
		Reception2,
		Reception3,
		Reception4,
		RecordBtnFill,
		RecordBtn,
		RecordCircleFill,
		RecordCircle,
		RecordFill,
		Record,
		Record2Fill,
		Record2,
		ReplyAllFill,
		ReplyAll,
		ReplyFill,
		Reply,
		RssFill,
		Rss,
		Rulers,
		SaveFill,
		Save,
		Save2Fill,
		Save2,
		Scissors,
		Screwdriver,
		Search,
		SegmentedNav,
		Server,
		ShareFill,
		Share,
		ShieldCheck,
		ShieldExclamation,
		ShieldFillCheck,
		ShieldFillExclamation,
		ShieldFillMinus,
		ShieldFillPlus,
		ShieldFillX,
		ShieldFill,
		ShieldLockFill,
		ShieldLock,
		ShieldMinus,
		ShieldPlus,
		ShieldShaded,
		ShieldSlashFill,
		ShieldSlash,
		ShieldX,
		Shield,
		ShiftFill,
		Shift,
		ShopWindow,
		Shop,
		Shuffle,
		Signpost2Fill,
		Signpost2,
		SignpostFill,
		SignpostSplitFill,
		SignpostSplit,
		Signpost,
		SimFill,
		Sim,
		SkipBackwardBtnFill,
		SkipBackwardBtn,
		SkipBackwardCircleFill,
		SkipBackwardCircle,
		SkipBackwardFill,
		SkipBackward,
		SkipEndBtnFill,
		SkipEndBtn,
		SkipEndCircleFill,
		SkipEndCircle,
		SkipEndFill,
		SkipEnd,
		SkipForwardBtnFill,
		SkipForwardBtn,
		SkipForwardCircleFill,
		SkipForwardCircle,
		SkipForwardFill,
		SkipForward,
		SkipStartBtnFill,
		SkipStartBtn,
		SkipStartCircleFill,
		SkipStartCircle,
		SkipStartFill,
		SkipStart,
		Slack,
		SlashCircleFill,
		SlashCircle,
		SlashSquareFill,
		SlashSquare,
		Slash,
		Sliders,
		Smartwatch,
		Snow,
		Snow2,
		Snow3,
		SortAlphaDownAlt,
		SortAlphaDown,
		SortAlphaUpAlt,
		SortAlphaUp,
		SortDownAlt,
		SortDown,
		SortNumericDownAlt,
		SortNumericDown,
		SortNumericUpAlt,
		SortNumericUp,
		SortUpAlt,
		SortUp,
		Soundwave,
		SpeakerFill,
		Speaker,
		Speedometer,
		Speedometer2,
		Spellcheck,
		SquareFill,
		SquareHalf,
		Square,
		Stack,
		StarFill,
		StarHalf,
		Star,
		Stars,
		StickiesFill,
		Stickies,
		StickyFill,
		Sticky,
		StopBtnFill,
		StopBtn,
		StopCircleFill,
		StopCircle,
		StopFill,
		Stop,
		StoplightsFill,
		Stoplights,
		StopwatchFill,
		Stopwatch,
		Subtract,
		SuitClubFill,
		SuitClub,
		SuitDiamondFill,
		SuitDiamond,
		SuitHeartFill,
		SuitHeart,
		SuitSpadeFill,
		SuitSpade,
		SunFill,
		Sun,
		Sunglasses,
		SunriseFill,
		Sunrise,
		SunsetFill,
		Sunset,
		SymmetryHorizontal,
		SymmetryVertical,
		Table,
		TabletFill,
		TabletLandscapeFill,
		TabletLandscape,
		Tablet,
		TagFill,
		Tag,
		TagsFill,
		Tags,
		Telegram,
		TelephoneFill,
		TelephoneForwardFill,
		TelephoneForward,
		TelephoneInboundFill,
		TelephoneInbound,
		TelephoneMinusFill,
		TelephoneMinus,
		TelephoneOutboundFill,
		TelephoneOutbound,
		TelephonePlusFill,
		TelephonePlus,
		TelephoneXFill,
		TelephoneX,
		Telephone,
		TerminalFill,
		Terminal,
		TextCenter,
		TextIndentLeft,
		TextIndentRight,
		TextLeft,
		TextParagraph,
		TextRight,
		TextareaResize,
		TextareaT,
		Textarea,
		ThermometerHalf,
		ThermometerHigh,
		ThermometerLow,
		ThermometerSnow,
		ThermometerSun,
		Thermometer,
		ThreeDotsVertical,
		ThreeDots,
		ToggleOff,
		ToggleOn,
		Toggle2Off,
		Toggle2On,
		Toggles,
		Toggles2,
		Tools,
		Tornado,
		TrashFill,
		Trash,
		Trash2Fill,
		Trash2,
		TreeFill,
		Tree,
		TriangleFill,
		TriangleHalf,
		Triangle,
		TrophyFill,
		Trophy,
		TropicalStorm,
		TruckFlatbed,
		Truck,
		Tsunami,
		TvFill,
		Tv,
		Twitch,
		Twitter,
		TypeBold,
		TypeH1,
		TypeH2,
		TypeH3,
		TypeItalic,
		TypeStrikethrough,
		TypeUnderline,
		Type,
		UiChecksGrid,
		UiChecks,
		UiRadiosGrid,
		UiRadios,
		UmbrellaFill,
		Umbrella,
		Union,
		UnlockFill,
		Unlock,
		UpcScan,
		Upc,
		Upload,
		VectorPen,
		ViewList,
		ViewStacked,
		VinylFill,
		Vinyl,
		Voicemail,
		VolumeDownFill,
		VolumeDown,
		VolumeMuteFill,
		VolumeMute,
		VolumeOffFill,
		VolumeOff,
		VolumeUpFill,
		VolumeUp,
		Vr,
		WalletFill,
		Wallet,
		Wallet2,
		Watch,
		Water,
		Whatsapp,
		Wifi1,
		Wifi2,
		WifiOff,
		Wifi,
		Wind,
		WindowDock,
		WindowSidebar,
		Window,
		Wrench,
		XCircleFill,
		XCircle,
		XDiamondFill,
		XDiamond,
		XOctagonFill,
		XOctagon,
		XSquareFill,
		XSquare,
		X,
		Youtube,
		ZoomIn,
		ZoomOut,
		Bank,
		Bank2,
		BellSlashFill,
		BellSlash,
		CashCoin,
		CheckLg,
		Coin,
		CurrencyBitcoin,
		CurrencyDollar,
		CurrencyEuro,
		CurrencyExchange,
		CurrencyPound,
		CurrencyYen,
		DashLg,
		ExclamationLg,
		FileEarmarkPdfFill,
		FileEarmarkPdf,
		FilePdfFill,
		FilePdf,
		GenderAmbiguous,
		GenderFemale,
		GenderMale,
		GenderTrans,
		HeadsetVr,
		InfoLg,
		Mastodon,
		Messenger,
		PiggyBankFill,
		PiggyBank,
		PinMapFill,
		PinMap,
		PlusLg,
		QuestionLg,
		Recycle,
		Reddit,
		SafeFill,
		Safe2Fill,
		Safe2,
		SdCardFill,
		SdCard,
		Skype,
		SlashLg,
		Translate,
		XLg,
		Safe,
		Apple,
		Microsoft,
		Windows,
		Behance,
		Dribbble,
		Line,
		Medium,
		Paypal,
		Pinterest,
		Signal,
		Snapchat,
		Spotify,
		StackOverflow,
		Strava,
		Wordpress,
		Vimeo,
		Activity,
		Easel2Fill,
		Easel2,
		Easel3Fill,
		Easel3,
		Fan,
		Fingerprint,
		GraphDownArrow,
		GraphUpArrow,
		Hypnotize,
		Magic,
		PersonRolodex,
		PersonVideo,
		PersonVideo2,
		PersonVideo3,
		PersonWorkspace,
		Radioactive,
		WebcamFill,
		Webcam,
		YinYang,
		BandaidFill,
		Bandaid,
		Bluetooth,
		BodyText,
		Boombox,
		Boxes,
		DpadFill,
		Dpad,
		EarFill,
		Ear,
		EnvelopeCheck1,
		EnvelopeCheckFill,
		EnvelopeCheck,
		EnvelopeDash1,
		EnvelopeDashFill,
		EnvelopeDash,
		EnvelopeExclamation1,
		EnvelopeExclamationFill,
		EnvelopeExclamation,
		EnvelopePlusFill,
		EnvelopePlus,
		EnvelopeSlash1,
		EnvelopeSlashFill,
		EnvelopeSlash,
		EnvelopeX1,
		EnvelopeXFill,
		EnvelopeX,
		ExplicitFill,
		Explicit,
		Git,
		Infinity,
		ListColumnsReverse,
		ListColumns,
		Meta,
		MortorboardFill,
		Mortorboard,
		NintendoSwitch,
		PcDisplayHorizontal,
		PcDisplay,
		PcHorizontal,
		Pc,
		Playstation,
		PlusSlashMinus,
		ProjectorFill,
		Projector,
		QrCodeScan,
		QrCode,
		Quora,
		Quote,
		Robot,
		SendCheckFill,
		SendCheck,
		SendDashFill,
		SendDash,
		SendExclamation1,
		SendExclamationFill,
		SendExclamation,
		SendFill,
		SendPlusFill,
		SendPlus,
		SendSlashFill,
		SendSlash,
		SendXFill,
		SendX,
		Send,
		Steam,
		TerminalDash1,
		TerminalDash,
		TerminalPlus,
		TerminalSplit,
		TicketDetailedFill,
		TicketDetailed,
		TicketFill,
		TicketPerforatedFill,
		TicketPerforated,
		Ticket,
		Tiktok,
		WindowDash,
		WindowDesktop,
		WindowFullscreen,
		WindowPlus,
		WindowSplit,
		WindowStack,
		WindowX,
		Xbox,
		Ethernet,
		HdmiFill,
		Hdmi,
		UsbCFill,
		UsbC,
		UsbFill,
		UsbPlugFill,
		UsbPlug,
		UsbSymbol,
		Usb,
		BoomboxFill,
		Displayport1,
		Displayport,
		GpuCard,
		Memory,
		ModemFill,
		Modem,
		MotherboardFill,
		Motherboard,
		OpticalAudioFill,
		OpticalAudio,
		PciCard,
		RouterFill,
		Router,
		SsdFill,
		Ssd,
		ThunderboltFill,
		Thunderbolt,
		UsbDriveFill,
		UsbDrive,
		UsbMicroFill,
		UsbMicro,
		UsbMiniFill,
		UsbMini,
		CloudHaze2,
		DeviceHddFill,
		DeviceHdd,
		DeviceSsdFill,
		DeviceSsd,
		DisplayportFill,
		MortarboardFill,
		Mortarboard,
		TerminalX
	}
	[Flags]
	public enum SearchFilterOptions
	{
		PropertyName = 1,
		PropertyNiceName = 2,
		TypeOfValue = 4,
		ValueToString = 8,
		ISearchFilterableInterface = 0x10,
		All = -1
	}
	public enum TableAxis
	{
		X,
		Y
	}
	public enum LabelDirection
	{
		LeftToRight,
		TopToBottom,
		BottomToTop
	}
	public enum TitleAlignments
	{
		Left,
		Centered,
		Right,
		Split
	}
	[Flags]
	public enum TypeInclusionFilter
	{
		None = 0,
		IncludeConcreteTypes = 1,
		IncludeGenerics = 2,
		IncludeAbstracts = 4,
		IncludeInterfaces = 8,
		IncludeAll = 0xF
	}
}
namespace Sirenix.OdinInspector.Internal
{
	public interface ISubGroupProviderAttribute
	{
		IList<PropertyGroupAttribute> GetSubGroupAttributes();

		string RepathMemberAttribute(PropertyGroupAttribute attr);
	}
}
