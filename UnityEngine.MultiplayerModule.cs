using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Bindings;

[assembly: InternalsVisibleTo("Unity.DedicatedServer.MultiplayerRoles")]
[assembly: InternalsVisibleTo("UnityEditor.MultiplayerModule")]
[assembly: InternalsVisibleTo("UnityEditor.CoreModule")]
[assembly: InternalsVisibleTo("Unity.Modules.Multiplayer.MultiplayerRoles.Tests.Performance")]
[assembly: InternalsVisibleTo("Unity.Modules.Multiplayer.MultiplayerRoles.Tests.Editor")]
[assembly: UnityEngineModuleAssembly]
[assembly: InternalsVisibleTo("UnityEngine")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: InternalsVisibleTo("Unity.DedicatedServer.MultiplayerRoles.Editor")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
namespace UnityEngine
{
	[NativeType(Header = "Modules/Multiplayer/MultiplayerRolesData.h")]
	internal class MultiplayerRolesData : Component
	{
	}
}
namespace UnityEngine.Multiplayer.Internal
{
	[StaticAccessor("GetMultiplayerManager()", StaticAccessorType.Dot)]
	[NativeHeader("Modules/Multiplayer/MultiplayerManager.h")]
	internal static class MultiplayerManager
	{
		public static extern MultiplayerRoleFlags activeMultiplayerRoleMask
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		public static MultiplayerRoleFlags GetMultiplayerRoleMaskForGameObject(GameObject gameObject)
		{
			return GetMultiplayerRoleMaskForGameObject_Injected(Object.MarshalledUnityObject.Marshal(gameObject));
		}

		public static MultiplayerRoleFlags GetMultiplayerRoleMaskForComponent(Component component)
		{
			return GetMultiplayerRoleMaskForComponent_Injected(Object.MarshalledUnityObject.Marshal(component));
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern MultiplayerRoleFlags GetMultiplayerRoleMaskForGameObject_Injected(IntPtr gameObject);

		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern MultiplayerRoleFlags GetMultiplayerRoleMaskForComponent_Injected(IntPtr component);
	}
	[VisibleToOtherModules]
	internal enum MultiplayerRole
	{
		Client,
		Server
	}
	[Flags]
	[VisibleToOtherModules]
	internal enum MultiplayerRoleFlags
	{
		Client = 1,
		Server = 2,
		ClientAndServer = 3
	}
}
