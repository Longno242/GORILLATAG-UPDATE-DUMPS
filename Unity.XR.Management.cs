using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.Analytics;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Unity.XR.Management.Editor")]
[assembly: InternalsVisibleTo("Unity.XR.Management.Tests")]
[assembly: InternalsVisibleTo("Unity.XR.Management.EditorTests")]
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
			FilePathsData = new byte[564]
			{
				0, 0, 0, 1, 0, 0, 0, 89, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				120, 114, 46, 109, 97, 110, 97, 103, 101, 109,
				101, 110, 116, 64, 102, 53, 56, 57, 99, 55,
				98, 97, 52, 57, 102, 102, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 88, 82, 67, 111, 110,
				102, 105, 103, 117, 114, 97, 116, 105, 111, 110,
				68, 97, 116, 97, 46, 99, 115, 0, 0, 0,
				1, 0, 0, 0, 87, 92, 76, 105, 98, 114,
				97, 114, 121, 92, 80, 97, 99, 107, 97, 103,
				101, 67, 97, 99, 104, 101, 92, 99, 111, 109,
				46, 117, 110, 105, 116, 121, 46, 120, 114, 46,
				109, 97, 110, 97, 103, 101, 109, 101, 110, 116,
				64, 102, 53, 56, 57, 99, 55, 98, 97, 52,
				57, 102, 102, 92, 82, 117, 110, 116, 105, 109,
				101, 92, 88, 82, 71, 101, 110, 101, 114, 97,
				108, 83, 101, 116, 116, 105, 110, 103, 115, 46,
				99, 115, 0, 0, 0, 1, 0, 0, 0, 78,
				92, 76, 105, 98, 114, 97, 114, 121, 92, 80,
				97, 99, 107, 97, 103, 101, 67, 97, 99, 104,
				101, 92, 99, 111, 109, 46, 117, 110, 105, 116,
				121, 46, 120, 114, 46, 109, 97, 110, 97, 103,
				101, 109, 101, 110, 116, 64, 102, 53, 56, 57,
				99, 55, 98, 97, 52, 57, 102, 102, 92, 82,
				117, 110, 116, 105, 109, 101, 92, 88, 82, 76,
				111, 97, 100, 101, 114, 46, 99, 115, 0, 0,
				0, 1, 0, 0, 0, 84, 92, 76, 105, 98,
				114, 97, 114, 121, 92, 80, 97, 99, 107, 97,
				103, 101, 67, 97, 99, 104, 101, 92, 99, 111,
				109, 46, 117, 110, 105, 116, 121, 46, 120, 114,
				46, 109, 97, 110, 97, 103, 101, 109, 101, 110,
				116, 64, 102, 53, 56, 57, 99, 55, 98, 97,
				52, 57, 102, 102, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 88, 82, 76, 111, 97, 100, 101,
				114, 72, 101, 108, 112, 101, 114, 46, 99, 115,
				0, 0, 0, 3, 0, 0, 0, 91, 92, 76,
				105, 98, 114, 97, 114, 121, 92, 80, 97, 99,
				107, 97, 103, 101, 67, 97, 99, 104, 101, 92,
				99, 111, 109, 46, 117, 110, 105, 116, 121, 46,
				120, 114, 46, 109, 97, 110, 97, 103, 101, 109,
				101, 110, 116, 64, 102, 53, 56, 57, 99, 55,
				98, 97, 52, 57, 102, 102, 92, 82, 117, 110,
				116, 105, 109, 101, 92, 88, 82, 77, 97, 110,
				97, 103, 101, 109, 101, 110, 116, 65, 110, 97,
				108, 121, 116, 105, 99, 115, 46, 99, 115, 0,
				0, 0, 1, 0, 0, 0, 87, 92, 76, 105,
				98, 114, 97, 114, 121, 92, 80, 97, 99, 107,
				97, 103, 101, 67, 97, 99, 104, 101, 92, 99,
				111, 109, 46, 117, 110, 105, 116, 121, 46, 120,
				114, 46, 109, 97, 110, 97, 103, 101, 109, 101,
				110, 116, 64, 102, 53, 56, 57, 99, 55, 98,
				97, 52, 57, 102, 102, 92, 82, 117, 110, 116,
				105, 109, 101, 92, 88, 82, 77, 97, 110, 97,
				103, 101, 114, 83, 101, 116, 116, 105, 110, 103,
				115, 46, 99, 115
			},
			TypesData = new byte[427]
			{
				0, 0, 0, 0, 54, 85, 110, 105, 116, 121,
				69, 110, 103, 105, 110, 101, 46, 88, 82, 46,
				77, 97, 110, 97, 103, 101, 109, 101, 110, 116,
				124, 88, 82, 67, 111, 110, 102, 105, 103, 117,
				114, 97, 116, 105, 111, 110, 68, 97, 116, 97,
				65, 116, 116, 114, 105, 98, 117, 116, 101, 0,
				0, 0, 0, 43, 85, 110, 105, 116, 121, 69,
				110, 103, 105, 110, 101, 46, 88, 82, 46, 77,
				97, 110, 97, 103, 101, 109, 101, 110, 116, 124,
				88, 82, 71, 101, 110, 101, 114, 97, 108, 83,
				101, 116, 116, 105, 110, 103, 115, 0, 0, 0,
				0, 34, 85, 110, 105, 116, 121, 69, 110, 103,
				105, 110, 101, 46, 88, 82, 46, 77, 97, 110,
				97, 103, 101, 109, 101, 110, 116, 124, 88, 82,
				76, 111, 97, 100, 101, 114, 0, 0, 0, 0,
				40, 85, 110, 105, 116, 121, 69, 110, 103, 105,
				110, 101, 46, 88, 82, 46, 77, 97, 110, 97,
				103, 101, 109, 101, 110, 116, 124, 88, 82, 76,
				111, 97, 100, 101, 114, 72, 101, 108, 112, 101,
				114, 0, 0, 0, 0, 47, 85, 110, 105, 116,
				121, 69, 110, 103, 105, 110, 101, 46, 88, 82,
				46, 77, 97, 110, 97, 103, 101, 109, 101, 110,
				116, 124, 88, 82, 77, 97, 110, 97, 103, 101,
				109, 101, 110, 116, 65, 110, 97, 108, 121, 116,
				105, 99, 115, 0, 0, 0, 0, 58, 85, 110,
				105, 116, 121, 69, 110, 103, 105, 110, 101, 46,
				88, 82, 46, 77, 97, 110, 97, 103, 101, 109,
				101, 110, 116, 46, 88, 82, 77, 97, 110, 97,
				103, 101, 109, 101, 110, 116, 65, 110, 97, 108,
				121, 116, 105, 99, 115, 124, 66, 117, 105, 108,
				100, 69, 118, 101, 110, 116, 0, 0, 0, 0,
				68, 85, 110, 105, 116, 121, 69, 110, 103, 105,
				110, 101, 46, 88, 82, 46, 77, 97, 110, 97,
				103, 101, 109, 101, 110, 116, 46, 88, 82, 77,
				97, 110, 97, 103, 101, 109, 101, 110, 116, 65,
				110, 97, 108, 121, 116, 105, 99, 115, 124, 88,
				114, 73, 110, 105, 116, 105, 97, 108, 105, 122,
				101, 65, 110, 97, 108, 121, 116, 105, 99, 0,
				0, 0, 0, 43, 85, 110, 105, 116, 121, 69,
				110, 103, 105, 110, 101, 46, 88, 82, 46, 77,
				97, 110, 97, 103, 101, 109, 101, 110, 116, 124,
				88, 82, 77, 97, 110, 97, 103, 101, 114, 83,
				101, 116, 116, 105, 110, 103, 115
			},
			TotalFiles = 6,
			TotalTypes = 8,
			IsEditorOnly = false
		};
	}
}
namespace UnityEngine.XR.Management;

[AttributeUsage(AttributeTargets.Class)]
public sealed class XRConfigurationDataAttribute : Attribute
{
	public string displayName { get; set; }

	public string buildSettingsKey { get; set; }

	private XRConfigurationDataAttribute()
	{
	}

	public XRConfigurationDataAttribute(string displayName, string buildSettingsKey)
	{
		this.displayName = displayName;
		this.buildSettingsKey = buildSettingsKey;
	}
}
public class XRGeneralSettings : ScriptableObject
{
	public static string k_SettingsKey = "com.unity.xr.management.loader_settings";

	internal static XRGeneralSettings s_RuntimeSettingsInstance = null;

	[SerializeField]
	internal XRManagerSettings m_LoaderManagerInstance;

	[SerializeField]
	[Tooltip("Toggling this on/off will enable/disable the automatic startup of XR at run time.")]
	internal bool m_InitManagerOnStart = true;

	private XRManagerSettings m_XRManager;

	private bool m_ProviderIntialized;

	private bool m_ProviderStarted;

	public XRManagerSettings Manager
	{
		get
		{
			return m_LoaderManagerInstance;
		}
		set
		{
			m_LoaderManagerInstance = value;
		}
	}

	public static XRGeneralSettings Instance => s_RuntimeSettingsInstance;

	public XRManagerSettings AssignedSettings => m_LoaderManagerInstance;

	public bool InitManagerOnStart => m_InitManagerOnStart;

	private void Awake()
	{
		Debug.Log("XRGeneral Settings awakening...");
		s_RuntimeSettingsInstance = this;
		Application.quitting += Quit;
		Object.DontDestroyOnLoad(s_RuntimeSettingsInstance);
	}

	private static void Quit()
	{
		XRGeneralSettings instance = Instance;
		if (!(instance == null))
		{
			instance.DeInitXRSDK();
		}
	}

	private void Start()
	{
		StartXRSDK();
	}

	private void OnDestroy()
	{
		DeInitXRSDK();
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
	internal static void AttemptInitializeXRSDKOnLoad()
	{
		XRGeneralSettings instance = Instance;
		if (!(instance == null) && instance.InitManagerOnStart)
		{
			instance.InitXRSDK();
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
	internal static void AttemptStartXRSDKOnBeforeSplashScreen()
	{
		XRGeneralSettings instance = Instance;
		if (!(instance == null) && instance.InitManagerOnStart)
		{
			instance.StartXRSDK();
		}
	}

	private void InitXRSDK()
	{
		if (!(Instance == null) && !(Instance.m_LoaderManagerInstance == null) && Instance.m_InitManagerOnStart)
		{
			m_XRManager = Instance.m_LoaderManagerInstance;
			if (m_XRManager == null)
			{
				Debug.LogError("Assigned GameObject for XR Management loading is invalid. No XR Providers will be automatically loaded.");
				return;
			}
			m_XRManager.automaticLoading = false;
			m_XRManager.automaticRunning = false;
			m_XRManager.InitializeLoaderSync();
			m_ProviderIntialized = true;
		}
	}

	private void StartXRSDK()
	{
		if (m_XRManager != null && m_XRManager.activeLoader != null)
		{
			m_XRManager.StartSubsystems();
			m_ProviderStarted = true;
		}
	}

	private void StopXRSDK()
	{
		if (m_XRManager != null && m_XRManager.activeLoader != null)
		{
			m_XRManager.StopSubsystems();
			m_ProviderStarted = false;
		}
	}

	private void DeInitXRSDK()
	{
		if (m_XRManager != null && m_XRManager.activeLoader != null)
		{
			m_XRManager.DeinitializeLoader();
			m_XRManager = null;
			m_ProviderIntialized = false;
		}
	}
}
public abstract class XRLoader : ScriptableObject
{
	public virtual bool Initialize()
	{
		return true;
	}

	public virtual bool Start()
	{
		return true;
	}

	public virtual bool Stop()
	{
		return true;
	}

	public virtual bool Deinitialize()
	{
		return true;
	}

	public abstract T GetLoadedSubsystem<T>() where T : class, ISubsystem;

	public virtual List<GraphicsDeviceType> GetSupportedGraphicsDeviceTypes(bool buildingPlayer)
	{
		return new List<GraphicsDeviceType>();
	}
}
public abstract class XRLoaderHelper : XRLoader
{
	protected Dictionary<Type, ISubsystem> m_SubsystemInstanceMap = new Dictionary<Type, ISubsystem>();

	public override T GetLoadedSubsystem<T>()
	{
		Type typeFromHandle = typeof(T);
		m_SubsystemInstanceMap.TryGetValue(typeFromHandle, out var value);
		return value as T;
	}

	protected void StartSubsystem<T>() where T : class, ISubsystem
	{
		GetLoadedSubsystem<T>()?.Start();
	}

	protected void StopSubsystem<T>() where T : class, ISubsystem
	{
		GetLoadedSubsystem<T>()?.Stop();
	}

	protected void DestroySubsystem<T>() where T : class, ISubsystem
	{
		T loadedSubsystem = GetLoadedSubsystem<T>();
		if (loadedSubsystem != null)
		{
			Type typeFromHandle = typeof(T);
			if (m_SubsystemInstanceMap.ContainsKey(typeFromHandle))
			{
				m_SubsystemInstanceMap.Remove(typeFromHandle);
			}
			loadedSubsystem.Destroy();
		}
	}

	protected void CreateSubsystem<TDescriptor, TSubsystem>(List<TDescriptor> descriptors, string id) where TDescriptor : ISubsystemDescriptor where TSubsystem : ISubsystem
	{
		if (descriptors == null)
		{
			throw new ArgumentNullException("descriptors");
		}
		SubsystemManager.GetSubsystemDescriptors(descriptors);
		if (descriptors.Count <= 0)
		{
			return;
		}
		foreach (TDescriptor descriptor in descriptors)
		{
			ISubsystem subsystem = null;
			if (string.Compare(descriptor.id, id, ignoreCase: true) == 0)
			{
				subsystem = descriptor.Create();
			}
			if (subsystem != null)
			{
				m_SubsystemInstanceMap[typeof(TSubsystem)] = subsystem;
				break;
			}
		}
	}

	[Obsolete("This method is obsolete. Please use the geenric CreateSubsystem method.", false)]
	protected void CreateIntegratedSubsystem<TDescriptor, TSubsystem>(List<TDescriptor> descriptors, string id) where TDescriptor : IntegratedSubsystemDescriptor where TSubsystem : IntegratedSubsystem
	{
		CreateSubsystem<TDescriptor, TSubsystem>(descriptors, id);
	}

	[Obsolete("This method is obsolete. Please use the generic CreateSubsystem method.", false)]
	protected void CreateStandaloneSubsystem<TDescriptor, TSubsystem>(List<TDescriptor> descriptors, string id) where TDescriptor : SubsystemDescriptor where TSubsystem : Subsystem
	{
		CreateSubsystem<TDescriptor, TSubsystem>(descriptors, id);
	}

	public override bool Deinitialize()
	{
		m_SubsystemInstanceMap.Clear();
		return base.Deinitialize();
	}
}
internal static class XRManagementAnalytics
{
	[Serializable]
	private struct BuildEvent : IAnalytic.IData
	{
		public string buildGuid;

		public string buildTarget;

		public string buildTargetGroup;

		public string[] assigned_loaders;
	}

	[AnalyticInfo("xrmanagment_build", "unity.xrmanagement", 1, 1000, 1000)]
	private class XrInitializeAnalytic : IAnalytic
	{
		private BuildEvent? data;

		public XrInitializeAnalytic(BuildEvent data)
		{
			this.data = data;
		}

		public bool TryGatherData(out IAnalytic.IData data, [NotNullWhen(false)] out Exception error)
		{
			error = null;
			data = this.data;
			return data != null;
		}
	}

	private const int kMaxEventsPerHour = 1000;

	private const int kMaxNumberOfElements = 1000;

	private const string kVendorKey = "unity.xrmanagement";

	private const string kEventBuild = "xrmanagment_build";

	private static bool s_Initialized;

	private static bool Initialize()
	{
		return s_Initialized;
	}
}
public sealed class XRManagerSettings : ScriptableObject
{
	[HideInInspector]
	private bool m_InitializationComplete;

	[HideInInspector]
	[SerializeField]
	private bool m_RequiresSettingsUpdate;

	[SerializeField]
	[Tooltip("Determines if the XR Manager instance is responsible for creating and destroying the appropriate loader instance.")]
	[FormerlySerializedAs("AutomaticLoading")]
	private bool m_AutomaticLoading;

	[SerializeField]
	[Tooltip("Determines if the XR Manager instance is responsible for starting and stopping subsystems for the active loader instance.")]
	[FormerlySerializedAs("AutomaticRunning")]
	private bool m_AutomaticRunning;

	[SerializeField]
	[Tooltip("List of XR Loader instances arranged in desired load order.")]
	[FormerlySerializedAs("Loaders")]
	private List<XRLoader> m_Loaders = new List<XRLoader>();

	[SerializeField]
	[HideInInspector]
	private HashSet<XRLoader> m_RegisteredLoaders = new HashSet<XRLoader>();

	public bool automaticLoading
	{
		get
		{
			return m_AutomaticLoading;
		}
		set
		{
			m_AutomaticLoading = value;
		}
	}

	public bool automaticRunning
	{
		get
		{
			return m_AutomaticRunning;
		}
		set
		{
			m_AutomaticRunning = value;
		}
	}

	[Obsolete("'XRManagerSettings.loaders' property is obsolete. Use 'XRManagerSettings.activeLoaders' instead to get a list of the current loaders.")]
	public List<XRLoader> loaders => m_Loaders;

	public IReadOnlyList<XRLoader> activeLoaders => m_Loaders;

	public bool isInitializationComplete => m_InitializationComplete;

	[HideInInspector]
	public XRLoader activeLoader { get; private set; }

	internal List<XRLoader> currentLoaders
	{
		get
		{
			return m_Loaders;
		}
		set
		{
			m_Loaders = value;
		}
	}

	internal HashSet<XRLoader> registeredLoaders => m_RegisteredLoaders;

	public T ActiveLoaderAs<T>() where T : XRLoader
	{
		return activeLoader as T;
	}

	public void InitializeLoaderSync()
	{
		if (activeLoader != null)
		{
			Debug.LogWarning("XR Management has already initialized an active loader in this scene. Please make sure to stop all subsystems and deinitialize the active loader before initializing a new one.");
			return;
		}
		foreach (XRLoader currentLoader in currentLoaders)
		{
			if (currentLoader != null && CheckGraphicsAPICompatibility(currentLoader) && currentLoader.Initialize())
			{
				activeLoader = currentLoader;
				m_InitializationComplete = true;
				return;
			}
		}
		activeLoader = null;
	}

	public IEnumerator InitializeLoader()
	{
		if (activeLoader != null)
		{
			Debug.LogWarning("XR Management has already initialized an active loader in this scene. Please make sure to stop all subsystems and deinitialize the active loader before initializing a new one.");
			yield break;
		}
		foreach (XRLoader currentLoader in currentLoaders)
		{
			if (currentLoader != null && CheckGraphicsAPICompatibility(currentLoader) && currentLoader.Initialize())
			{
				activeLoader = currentLoader;
				m_InitializationComplete = true;
				yield break;
			}
			yield return null;
		}
		activeLoader = null;
	}

	public bool TryAddLoader(XRLoader loader, int index = -1)
	{
		if (loader == null || currentLoaders.Contains(loader))
		{
			return false;
		}
		if (!m_RegisteredLoaders.Contains(loader))
		{
			return false;
		}
		if (index < 0 || index >= currentLoaders.Count)
		{
			currentLoaders.Add(loader);
		}
		else
		{
			currentLoaders.Insert(index, loader);
		}
		return true;
	}

	public bool TryRemoveLoader(XRLoader loader)
	{
		bool result = true;
		if (currentLoaders.Contains(loader))
		{
			result = currentLoaders.Remove(loader);
		}
		return result;
	}

	public bool TrySetLoaders(List<XRLoader> reorderedLoaders)
	{
		List<XRLoader> list = new List<XRLoader>(activeLoaders);
		currentLoaders.Clear();
		foreach (XRLoader reorderedLoader in reorderedLoaders)
		{
			if (!TryAddLoader(reorderedLoader))
			{
				currentLoaders = list;
				return false;
			}
		}
		return true;
	}

	private void Awake()
	{
		foreach (XRLoader currentLoader in currentLoaders)
		{
			if (!m_RegisteredLoaders.Contains(currentLoader))
			{
				m_RegisteredLoaders.Add(currentLoader);
			}
		}
	}

	private bool CheckGraphicsAPICompatibility(XRLoader loader)
	{
		GraphicsDeviceType graphicsDeviceType = SystemInfo.graphicsDeviceType;
		List<GraphicsDeviceType> supportedGraphicsDeviceTypes = loader.GetSupportedGraphicsDeviceTypes(buildingPlayer: false);
		if (supportedGraphicsDeviceTypes.Count > 0 && !supportedGraphicsDeviceTypes.Contains(graphicsDeviceType))
		{
			Debug.LogWarning($"The {loader.name} does not support the initialized graphics device, {graphicsDeviceType.ToString()}. Please change the preffered Graphics API in PlayerSettings. Attempting to start the next XR loader.");
			return false;
		}
		return true;
	}

	public void StartSubsystems()
	{
		if (!m_InitializationComplete)
		{
			Debug.LogWarning("Call to StartSubsystems without an initialized manager.Please make sure wait for initialization to complete before calling this API.");
		}
		else if (activeLoader != null)
		{
			activeLoader.Start();
		}
	}

	public void StopSubsystems()
	{
		if (!m_InitializationComplete)
		{
			Debug.LogWarning("Call to StopSubsystems without an initialized manager.Please make sure wait for initialization to complete before calling this API.");
		}
		else if (activeLoader != null)
		{
			activeLoader.Stop();
		}
	}

	public void DeinitializeLoader()
	{
		if (!m_InitializationComplete)
		{
			Debug.LogWarning("Call to DeinitializeLoader without an initialized manager.Please make sure wait for initialization to complete before calling this API.");
			return;
		}
		StopSubsystems();
		if (activeLoader != null)
		{
			activeLoader.Deinitialize();
			activeLoader = null;
		}
		m_InitializationComplete = false;
	}

	private void Start()
	{
		if (automaticLoading && automaticRunning)
		{
			StartSubsystems();
		}
	}

	private void OnDisable()
	{
		if (automaticLoading && automaticRunning)
		{
			StopSubsystems();
		}
	}

	private void OnDestroy()
	{
		if (automaticLoading)
		{
			DeinitializeLoader();
		}
	}
}
