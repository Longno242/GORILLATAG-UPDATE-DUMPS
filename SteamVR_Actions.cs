using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
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
			FilePathsData = new byte[256]
			{
				0, 0, 0, 1, 0, 0, 0, 76, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 116, 101, 97,
				109, 86, 82, 95, 73, 110, 112, 117, 116, 92,
				65, 99, 116, 105, 111, 110, 83, 101, 116, 67,
				108, 97, 115, 115, 101, 115, 92, 83, 116, 101,
				97, 109, 86, 82, 95, 73, 110, 112, 117, 116,
				95, 65, 99, 116, 105, 111, 110, 83, 101, 116,
				95, 71, 111, 114, 105, 108, 108, 97, 84, 97,
				103, 46, 99, 115, 0, 0, 0, 1, 0, 0,
				0, 46, 92, 65, 115, 115, 101, 116, 115, 92,
				83, 116, 101, 97, 109, 86, 82, 95, 73, 110,
				112, 117, 116, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 95, 65, 99,
				116, 105, 111, 110, 115, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 49, 92, 65, 115, 115,
				101, 116, 115, 92, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 92, 83, 116,
				101, 97, 109, 86, 82, 95, 73, 110, 112, 117,
				116, 95, 65, 99, 116, 105, 111, 110, 83, 101,
				116, 115, 46, 99, 115, 0, 0, 0, 1, 0,
				0, 0, 53, 92, 65, 115, 115, 101, 116, 115,
				92, 83, 116, 101, 97, 109, 86, 82, 95, 73,
				110, 112, 117, 116, 92, 83, 116, 101, 97, 109,
				86, 82, 95, 73, 110, 112, 117, 116, 95, 73,
				110, 105, 116, 105, 97, 108, 105, 122, 97, 116,
				105, 111, 110, 46, 99, 115
			},
			TypesData = new byte[135]
			{
				0, 0, 0, 0, 43, 86, 97, 108, 118, 101,
				46, 86, 82, 124, 83, 116, 101, 97, 109, 86,
				82, 95, 73, 110, 112, 117, 116, 95, 65, 99,
				116, 105, 111, 110, 83, 101, 116, 95, 71, 111,
				114, 105, 108, 108, 97, 84, 97, 103, 1, 0,
				0, 0, 24, 86, 97, 108, 118, 101, 46, 86,
				82, 124, 83, 116, 101, 97, 109, 86, 82, 95,
				65, 99, 116, 105, 111, 110, 115, 1, 0, 0,
				0, 24, 86, 97, 108, 118, 101, 46, 86, 82,
				124, 83, 116, 101, 97, 109, 86, 82, 95, 65,
				99, 116, 105, 111, 110, 115, 1, 0, 0, 0,
				24, 86, 97, 108, 118, 101, 46, 86, 82, 124,
				83, 116, 101, 97, 109, 86, 82, 95, 65, 99,
				116, 105, 111, 110, 115
			},
			TotalFiles = 4,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace Valve.VR;

public class SteamVR_Input_ActionSet_GorillaTag : SteamVR_ActionSet
{
	public virtual SteamVR_Action_Boolean LeftTriggerTouch => SteamVR_Actions.gorillaTag_LeftTriggerTouch;

	public virtual SteamVR_Action_Boolean LeftTriggerClick => SteamVR_Actions.gorillaTag_LeftTriggerClick;

	public virtual SteamVR_Action_Single LeftTriggerFloat => SteamVR_Actions.gorillaTag_LeftTriggerFloat;

	public virtual SteamVR_Action_Boolean RightTriggerTouch => SteamVR_Actions.gorillaTag_RightTriggerTouch;

	public virtual SteamVR_Action_Boolean RightTriggerClick => SteamVR_Actions.gorillaTag_RightTriggerClick;

	public virtual SteamVR_Action_Single RightTriggerFloat => SteamVR_Actions.gorillaTag_RightTriggerFloat;

	public virtual SteamVR_Action_Boolean LeftGripTouch => SteamVR_Actions.gorillaTag_LeftGripTouch;

	public virtual SteamVR_Action_Boolean LeftGripClick => SteamVR_Actions.gorillaTag_LeftGripClick;

	public virtual SteamVR_Action_Single LeftGripFloat => SteamVR_Actions.gorillaTag_LeftGripFloat;

	public virtual SteamVR_Action_Boolean RightGripTouch => SteamVR_Actions.gorillaTag_RightGripTouch;

	public virtual SteamVR_Action_Boolean RightGripClick => SteamVR_Actions.gorillaTag_RightGripClick;

	public virtual SteamVR_Action_Single RightGripFloat => SteamVR_Actions.gorillaTag_RightGripFloat;

	public virtual SteamVR_Action_Boolean LeftPrimaryClick => SteamVR_Actions.gorillaTag_LeftPrimaryClick;

	public virtual SteamVR_Action_Boolean LeftPrimaryTouch => SteamVR_Actions.gorillaTag_LeftPrimaryTouch;

	public virtual SteamVR_Action_Boolean RightPrimaryClick => SteamVR_Actions.gorillaTag_RightPrimaryClick;

	public virtual SteamVR_Action_Boolean RightPrimaryTouch => SteamVR_Actions.gorillaTag_RightPrimaryTouch;

	public virtual SteamVR_Action_Boolean LeftSecondaryClick => SteamVR_Actions.gorillaTag_LeftSecondaryClick;

	public virtual SteamVR_Action_Boolean LeftSecondaryTouch => SteamVR_Actions.gorillaTag_LeftSecondaryTouch;

	public virtual SteamVR_Action_Boolean RightSecondaryClick => SteamVR_Actions.gorillaTag_RightSecondaryClick;

	public virtual SteamVR_Action_Boolean RightSecondaryTouch => SteamVR_Actions.gorillaTag_RightSecondaryTouch;

	public virtual SteamVR_Action_Boolean LeftJoystickTouch => SteamVR_Actions.gorillaTag_LeftJoystickTouch;

	public virtual SteamVR_Action_Boolean LeftJoystickClick => SteamVR_Actions.gorillaTag_LeftJoystickClick;

	public virtual SteamVR_Action_Vector2 LeftJoystick2DAxis => SteamVR_Actions.gorillaTag_LeftJoystick2DAxis;

	public virtual SteamVR_Action_Boolean RightJoystickTouch => SteamVR_Actions.gorillaTag_RightJoystickTouch;

	public virtual SteamVR_Action_Boolean RightJoystickClick => SteamVR_Actions.gorillaTag_RightJoystickClick;

	public virtual SteamVR_Action_Vector2 RightJoystick2DAxis => SteamVR_Actions.gorillaTag_RightJoystick2DAxis;

	public virtual SteamVR_Action_Boolean System => SteamVR_Actions.gorillaTag_System;

	public virtual SteamVR_Action_Vibration LeftHaptics => SteamVR_Actions.gorillaTag_LeftHaptics;

	public virtual SteamVR_Action_Vibration RightHaptics => SteamVR_Actions.gorillaTag_RightHaptics;
}
public class SteamVR_Actions
{
	private static SteamVR_Action_Boolean p_gorillaTag_LeftTriggerTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftTriggerClick;

	private static SteamVR_Action_Single p_gorillaTag_LeftTriggerFloat;

	private static SteamVR_Action_Boolean p_gorillaTag_RightTriggerTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_RightTriggerClick;

	private static SteamVR_Action_Single p_gorillaTag_RightTriggerFloat;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftGripTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftGripClick;

	private static SteamVR_Action_Single p_gorillaTag_LeftGripFloat;

	private static SteamVR_Action_Boolean p_gorillaTag_RightGripTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_RightGripClick;

	private static SteamVR_Action_Single p_gorillaTag_RightGripFloat;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftPrimaryClick;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftPrimaryTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_RightPrimaryClick;

	private static SteamVR_Action_Boolean p_gorillaTag_RightPrimaryTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftSecondaryClick;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftSecondaryTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_RightSecondaryClick;

	private static SteamVR_Action_Boolean p_gorillaTag_RightSecondaryTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftJoystickTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_LeftJoystickClick;

	private static SteamVR_Action_Vector2 p_gorillaTag_LeftJoystick2DAxis;

	private static SteamVR_Action_Boolean p_gorillaTag_RightJoystickTouch;

	private static SteamVR_Action_Boolean p_gorillaTag_RightJoystickClick;

	private static SteamVR_Action_Vector2 p_gorillaTag_RightJoystick2DAxis;

	private static SteamVR_Action_Boolean p_gorillaTag_System;

	private static SteamVR_Action_Vibration p_gorillaTag_LeftHaptics;

	private static SteamVR_Action_Vibration p_gorillaTag_RightHaptics;

	private static SteamVR_Input_ActionSet_GorillaTag p_GorillaTag;

	public static SteamVR_Action_Boolean gorillaTag_LeftTriggerTouch => p_gorillaTag_LeftTriggerTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftTriggerClick => p_gorillaTag_LeftTriggerClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Single gorillaTag_LeftTriggerFloat => p_gorillaTag_LeftTriggerFloat.GetCopy<SteamVR_Action_Single>();

	public static SteamVR_Action_Boolean gorillaTag_RightTriggerTouch => p_gorillaTag_RightTriggerTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightTriggerClick => p_gorillaTag_RightTriggerClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Single gorillaTag_RightTriggerFloat => p_gorillaTag_RightTriggerFloat.GetCopy<SteamVR_Action_Single>();

	public static SteamVR_Action_Boolean gorillaTag_LeftGripTouch => p_gorillaTag_LeftGripTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftGripClick => p_gorillaTag_LeftGripClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Single gorillaTag_LeftGripFloat => p_gorillaTag_LeftGripFloat.GetCopy<SteamVR_Action_Single>();

	public static SteamVR_Action_Boolean gorillaTag_RightGripTouch => p_gorillaTag_RightGripTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightGripClick => p_gorillaTag_RightGripClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Single gorillaTag_RightGripFloat => p_gorillaTag_RightGripFloat.GetCopy<SteamVR_Action_Single>();

	public static SteamVR_Action_Boolean gorillaTag_LeftPrimaryClick => p_gorillaTag_LeftPrimaryClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftPrimaryTouch => p_gorillaTag_LeftPrimaryTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightPrimaryClick => p_gorillaTag_RightPrimaryClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightPrimaryTouch => p_gorillaTag_RightPrimaryTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftSecondaryClick => p_gorillaTag_LeftSecondaryClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftSecondaryTouch => p_gorillaTag_LeftSecondaryTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightSecondaryClick => p_gorillaTag_RightSecondaryClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightSecondaryTouch => p_gorillaTag_RightSecondaryTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftJoystickTouch => p_gorillaTag_LeftJoystickTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_LeftJoystickClick => p_gorillaTag_LeftJoystickClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Vector2 gorillaTag_LeftJoystick2DAxis => p_gorillaTag_LeftJoystick2DAxis.GetCopy<SteamVR_Action_Vector2>();

	public static SteamVR_Action_Boolean gorillaTag_RightJoystickTouch => p_gorillaTag_RightJoystickTouch.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Boolean gorillaTag_RightJoystickClick => p_gorillaTag_RightJoystickClick.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Vector2 gorillaTag_RightJoystick2DAxis => p_gorillaTag_RightJoystick2DAxis.GetCopy<SteamVR_Action_Vector2>();

	public static SteamVR_Action_Boolean gorillaTag_System => p_gorillaTag_System.GetCopy<SteamVR_Action_Boolean>();

	public static SteamVR_Action_Vibration gorillaTag_LeftHaptics => p_gorillaTag_LeftHaptics.GetCopy<SteamVR_Action_Vibration>();

	public static SteamVR_Action_Vibration gorillaTag_RightHaptics => p_gorillaTag_RightHaptics.GetCopy<SteamVR_Action_Vibration>();

	public static SteamVR_Input_ActionSet_GorillaTag GorillaTag => p_GorillaTag.GetCopy<SteamVR_Input_ActionSet_GorillaTag>();

	private static void InitializeActionArrays()
	{
		SteamVR_Input.actions = new SteamVR_Action[29]
		{
			gorillaTag_LeftTriggerTouch, gorillaTag_LeftTriggerClick, gorillaTag_LeftTriggerFloat, gorillaTag_RightTriggerTouch, gorillaTag_RightTriggerClick, gorillaTag_RightTriggerFloat, gorillaTag_LeftGripTouch, gorillaTag_LeftGripClick, gorillaTag_LeftGripFloat, gorillaTag_RightGripTouch,
			gorillaTag_RightGripClick, gorillaTag_RightGripFloat, gorillaTag_LeftPrimaryClick, gorillaTag_LeftPrimaryTouch, gorillaTag_RightPrimaryClick, gorillaTag_RightPrimaryTouch, gorillaTag_LeftSecondaryClick, gorillaTag_LeftSecondaryTouch, gorillaTag_RightSecondaryClick, gorillaTag_RightSecondaryTouch,
			gorillaTag_LeftJoystickTouch, gorillaTag_LeftJoystickClick, gorillaTag_LeftJoystick2DAxis, gorillaTag_RightJoystickTouch, gorillaTag_RightJoystickClick, gorillaTag_RightJoystick2DAxis, gorillaTag_System, gorillaTag_LeftHaptics, gorillaTag_RightHaptics
		};
		SteamVR_Input.actionsIn = new ISteamVR_Action_In[27]
		{
			gorillaTag_LeftTriggerTouch, gorillaTag_LeftTriggerClick, gorillaTag_LeftTriggerFloat, gorillaTag_RightTriggerTouch, gorillaTag_RightTriggerClick, gorillaTag_RightTriggerFloat, gorillaTag_LeftGripTouch, gorillaTag_LeftGripClick, gorillaTag_LeftGripFloat, gorillaTag_RightGripTouch,
			gorillaTag_RightGripClick, gorillaTag_RightGripFloat, gorillaTag_LeftPrimaryClick, gorillaTag_LeftPrimaryTouch, gorillaTag_RightPrimaryClick, gorillaTag_RightPrimaryTouch, gorillaTag_LeftSecondaryClick, gorillaTag_LeftSecondaryTouch, gorillaTag_RightSecondaryClick, gorillaTag_RightSecondaryTouch,
			gorillaTag_LeftJoystickTouch, gorillaTag_LeftJoystickClick, gorillaTag_LeftJoystick2DAxis, gorillaTag_RightJoystickTouch, gorillaTag_RightJoystickClick, gorillaTag_RightJoystick2DAxis, gorillaTag_System
		};
		SteamVR_Input.actionsOut = new ISteamVR_Action_Out[2] { gorillaTag_LeftHaptics, gorillaTag_RightHaptics };
		SteamVR_Input.actionsVibration = new SteamVR_Action_Vibration[2] { gorillaTag_LeftHaptics, gorillaTag_RightHaptics };
		SteamVR_Input.actionsPose = new SteamVR_Action_Pose[0];
		SteamVR_Input.actionsBoolean = new SteamVR_Action_Boolean[21]
		{
			gorillaTag_LeftTriggerTouch, gorillaTag_LeftTriggerClick, gorillaTag_RightTriggerTouch, gorillaTag_RightTriggerClick, gorillaTag_LeftGripTouch, gorillaTag_LeftGripClick, gorillaTag_RightGripTouch, gorillaTag_RightGripClick, gorillaTag_LeftPrimaryClick, gorillaTag_LeftPrimaryTouch,
			gorillaTag_RightPrimaryClick, gorillaTag_RightPrimaryTouch, gorillaTag_LeftSecondaryClick, gorillaTag_LeftSecondaryTouch, gorillaTag_RightSecondaryClick, gorillaTag_RightSecondaryTouch, gorillaTag_LeftJoystickTouch, gorillaTag_LeftJoystickClick, gorillaTag_RightJoystickTouch, gorillaTag_RightJoystickClick,
			gorillaTag_System
		};
		SteamVR_Input.actionsSingle = new SteamVR_Action_Single[4] { gorillaTag_LeftTriggerFloat, gorillaTag_RightTriggerFloat, gorillaTag_LeftGripFloat, gorillaTag_RightGripFloat };
		SteamVR_Input.actionsVector2 = new SteamVR_Action_Vector2[2] { gorillaTag_LeftJoystick2DAxis, gorillaTag_RightJoystick2DAxis };
		SteamVR_Input.actionsVector3 = new SteamVR_Action_Vector3[0];
		SteamVR_Input.actionsSkeleton = new SteamVR_Action_Skeleton[0];
		SteamVR_Input.actionsNonPoseNonSkeletonIn = new ISteamVR_Action_In[27]
		{
			gorillaTag_LeftTriggerTouch, gorillaTag_LeftTriggerClick, gorillaTag_LeftTriggerFloat, gorillaTag_RightTriggerTouch, gorillaTag_RightTriggerClick, gorillaTag_RightTriggerFloat, gorillaTag_LeftGripTouch, gorillaTag_LeftGripClick, gorillaTag_LeftGripFloat, gorillaTag_RightGripTouch,
			gorillaTag_RightGripClick, gorillaTag_RightGripFloat, gorillaTag_LeftPrimaryClick, gorillaTag_LeftPrimaryTouch, gorillaTag_RightPrimaryClick, gorillaTag_RightPrimaryTouch, gorillaTag_LeftSecondaryClick, gorillaTag_LeftSecondaryTouch, gorillaTag_RightSecondaryClick, gorillaTag_RightSecondaryTouch,
			gorillaTag_LeftJoystickTouch, gorillaTag_LeftJoystickClick, gorillaTag_LeftJoystick2DAxis, gorillaTag_RightJoystickTouch, gorillaTag_RightJoystickClick, gorillaTag_RightJoystick2DAxis, gorillaTag_System
		};
	}

	private static void PreInitActions()
	{
		p_gorillaTag_LeftTriggerTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftTriggerTouch");
		p_gorillaTag_LeftTriggerClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftTriggerClick");
		p_gorillaTag_LeftTriggerFloat = SteamVR_Action.Create<SteamVR_Action_Single>("/actions/GorillaTag/in/LeftTriggerFloat");
		p_gorillaTag_RightTriggerTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightTriggerTouch");
		p_gorillaTag_RightTriggerClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightTriggerClick");
		p_gorillaTag_RightTriggerFloat = SteamVR_Action.Create<SteamVR_Action_Single>("/actions/GorillaTag/in/RightTriggerFloat");
		p_gorillaTag_LeftGripTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftGripTouch");
		p_gorillaTag_LeftGripClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftGripClick");
		p_gorillaTag_LeftGripFloat = SteamVR_Action.Create<SteamVR_Action_Single>("/actions/GorillaTag/in/LeftGripFloat");
		p_gorillaTag_RightGripTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightGripTouch");
		p_gorillaTag_RightGripClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightGripClick");
		p_gorillaTag_RightGripFloat = SteamVR_Action.Create<SteamVR_Action_Single>("/actions/GorillaTag/in/RightGripFloat");
		p_gorillaTag_LeftPrimaryClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftPrimaryClick");
		p_gorillaTag_LeftPrimaryTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftPrimaryTouch");
		p_gorillaTag_RightPrimaryClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightPrimaryClick");
		p_gorillaTag_RightPrimaryTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightPrimaryTouch");
		p_gorillaTag_LeftSecondaryClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftSecondaryClick");
		p_gorillaTag_LeftSecondaryTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftSecondaryTouch");
		p_gorillaTag_RightSecondaryClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightSecondaryClick");
		p_gorillaTag_RightSecondaryTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightSecondaryTouch");
		p_gorillaTag_LeftJoystickTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftJoystickTouch");
		p_gorillaTag_LeftJoystickClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/LeftJoystickClick");
		p_gorillaTag_LeftJoystick2DAxis = SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/GorillaTag/in/LeftJoystick2DAxis");
		p_gorillaTag_RightJoystickTouch = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightJoystickTouch");
		p_gorillaTag_RightJoystickClick = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/RightJoystickClick");
		p_gorillaTag_RightJoystick2DAxis = SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/GorillaTag/in/RightJoystick2DAxis");
		p_gorillaTag_System = SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/GorillaTag/in/System");
		p_gorillaTag_LeftHaptics = SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/GorillaTag/out/LeftHaptics");
		p_gorillaTag_RightHaptics = SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/GorillaTag/out/RightHaptics");
	}

	private static void StartPreInitActionSets()
	{
		p_GorillaTag = SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_GorillaTag>("/actions/GorillaTag");
		SteamVR_Input.actionSets = new SteamVR_ActionSet[1] { GorillaTag };
	}

	public static void PreInitialize()
	{
		StartPreInitActionSets();
		SteamVR_Input.PreinitializeActionSetDictionaries();
		PreInitActions();
		InitializeActionArrays();
		SteamVR_Input.PreinitializeActionDictionaries();
		SteamVR_Input.PreinitializeFinishActionSets();
	}
}
