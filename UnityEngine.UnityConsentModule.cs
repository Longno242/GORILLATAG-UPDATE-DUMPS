using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: UnityEngineModuleAssembly]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine.UnityConsent;

public struct ConsentState
{
	public ConsentStatus AdsIntent = ConsentStatus.Unspecified;

	public ConsentStatus AnalyticsIntent = ConsentStatus.Unspecified;

	public ConsentState()
	{
	}

	public override string ToString()
	{
		return string.Format("{0}: {1}, {2}: {3}", "AdsIntent", AdsIntent, "AnalyticsIntent", AnalyticsIntent);
	}
}
public enum ConsentStatus
{
	Unspecified,
	Granted,
	Denied
}
[NativeHeader("Modules/UnityConsent/EndUserConsent.h")]
public static class EndUserConsent
{
	public static event Action<ConsentState> consentStateChanged;

	[NativeMethod("GetConsentStateStatic")]
	public static ConsentState GetConsentState()
	{
		GetConsentState_Injected(out var ret);
		return ret;
	}

	[NativeMethod("SetConsentStateStatic")]
	public static void SetConsentState(ConsentState consentState)
	{
		SetConsentState_Injected(ref consentState);
	}

	[RequiredByNativeCode]
	private static void OnConsentStateChanged()
	{
		if (EndUserConsent.consentStateChanged != null)
		{
			EndUserConsent.consentStateChanged(GetConsentState());
		}
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void GetConsentState_Injected(out ConsentState ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void SetConsentState_Injected([In] ref ConsentState consentState);
}
