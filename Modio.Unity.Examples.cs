using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Modio;
using Modio.Authentication;
using Modio.Mods;
using Modio.Mods.Builder;
using Modio.Unity;
using Modio.Users;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyVersion("0.0.0.0")]
public class ModioUnityExample : MonoBehaviour
{
	private readonly struct DummyModData(string name, string summary, Texture2D logo, string path)
	{
		public readonly string name = name;

		public readonly string summary = summary;

		public readonly Texture2D logo = logo;

		public readonly string path = path;
	}

	private static readonly byte[] Megabyte = new byte[1048576];

	private static readonly System.Random RandomBytes = new System.Random();

	[Header("Authentication")]
	[SerializeField]
	private GameObject authContainer;

	[SerializeField]
	private InputField authInput;

	[SerializeField]
	private Button authRequest;

	[SerializeField]
	private Button authSubmit;

	[Header("Terms of Use")]
	[SerializeField]
	private GameObject tosContainer;

	[SerializeField]
	private Button termsLink;

	[SerializeField]
	private Button privacyLink;

	[SerializeField]
	private Button denyButton;

	[SerializeField]
	private Button acceptButton;

	[Header("Random Mod")]
	[SerializeField]
	private GameObject randomContainer;

	[SerializeField]
	private Text randomName;

	[SerializeField]
	private Image randomLogo;

	[SerializeField]
	private Button randomButton;

	private Mod[] allMods;

	private Mod currentDownload;

	private float downloadProgress;

	private float timeToProgressCheck = 1f;

	private void Awake()
	{
		ModioServices.Bind<IModioAuthService>().FromInstance(new ModioEmailAuthService(GetAuthCode));
		authContainer.SetActive(value: false);
		tosContainer.SetActive(value: false);
		randomContainer.SetActive(value: false);
	}

	private void Start()
	{
		InitPlugin();
	}

	private async Task InitPlugin()
	{
		Error error = await ModioClient.Init();
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error initializing mod.io: {error}");
			return;
		}
		UnityEngine.Debug.Log("mod.io plugin initialized");
		OnInit();
	}

	private void OnInit()
	{
		if (User.Current.IsAuthenticated)
		{
			OnAuth();
			return;
		}
		authRequest.onClick.AddListener(delegate
		{
			Authenticate();
		});
	}

	private async Task Authenticate()
	{
		Error error = await ModioClient.AuthService.Authenticate(displayedTerms: true, (authInput.text.Length > 0) ? authInput.text : null);
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error authenticating user: {error}");
		}
		else
		{
			OnAuth();
		}
	}

	private async Task<string> GetAuthCode()
	{
		bool codeEntered = false;
		authSubmit.onClick.AddListener(delegate
		{
			codeEntered = true;
		});
		while (!codeEntered)
		{
			await Task.Yield();
		}
		return authInput.text;
	}

	private async void OnAuth()
	{
		UnityEngine.Debug.Log("Authenticated user: " + User.Current.Profile.Username);
		authContainer.SetActive(value: false);
		tosContainer.SetActive(value: false);
		await AddModsIfNone();
		allMods = await GetAllMods();
		UnityEngine.Debug.Log("Available mods:\n" + string.Join("\n", allMods.Select((Mod mod) => $"{mod.Name} (id: {mod.Id})")));
		randomButton.onClick.AddListener(SetRandomMod);
		randomContainer.SetActive(value: true);
		SetRandomMod();
		while (User.Current.IsUpdating)
		{
			await Task.Yield();
		}
		Mod[] subscribedMods = GetSubscribedMods();
		UnityEngine.Debug.Log("Subscribed mods:\n" + ((subscribedMods.Length != 0) ? string.Join("\n", subscribedMods.Select((Mod mod) => $"{mod.Name} (id: {mod.Id})")) : "None"));
		await SubscribeToMod(allMods[UnityEngine.Random.Range(0, allMods.Length - 1)]);
		WakeUpModManagement();
		ICollection<Mod> collection = await ModInstallationManagement.GetAllInstalledMods();
		UnityEngine.Debug.Log("Installed mods:\n" + ((collection.Count > 0) ? string.Join("\n", collection.Select((Mod mod) => $"{mod.Name} (id: {mod.Id})")) : "None"));
	}

	private async Task AddModsIfNone()
	{
		var (error, modioPage) = await Mod.GetMods(new ModSearchFilter());
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error getting mods: {error}");
			return;
		}
		if (modioPage.Data.Length != 0)
		{
			UnityEngine.Debug.Log($"{modioPage.Data.Length} mods found. Not adding mods");
			return;
		}
		DummyModData dummyModData = await GenerateDummyMod("Cool Weapon", "A really cool weapon.", "24466B", "FDA576", 10);
		DummyModData dummyModData2 = await GenerateDummyMod("Funny Sound Pack", "You'll laugh a lot using this.", "B85675", "633E63", 50);
		DummyModData dummyModData3 = await GenerateDummyMod("Klingon Language Pack", "tlhIngan Hol Dajatlh'a'?", "93681C", "FFEAD0", 1);
		DummyModData dummyModData4 = await GenerateDummyMod("Ten New Missions", "Ported from the sequel to the prequel!", "FDA576", "D45B7A", 99);
		DummyModData[] array = new DummyModData[4] { dummyModData, dummyModData2, dummyModData3, dummyModData4 };
		DummyModData[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			DummyModData dummyModData5 = array2[i];
			await UploadMod(dummyModData5.name, dummyModData5.summary, dummyModData5.logo, dummyModData5.path);
		}
	}

	private async Task UploadMod(string modName, string summary, Texture2D logo, string path)
	{
		UnityEngine.Debug.Log("Starting upload: " + modName);
		ModBuilder modBuilder = Mod.Create();
		modBuilder.SetName(modName).SetSummary(summary).SetLogo(logo.EncodeToPNG(), ImageFormat.Png)
			.EditModfile()
			.SetSourceDirectoryPath(path)
			.FinishModfile();
		var (error, mod) = await modBuilder.Publish();
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error uploading mod {modName}: {error}");
		}
		else
		{
			UnityEngine.Debug.Log($"Successfully created mod {mod.Name} with Id {mod.Id}");
		}
	}

	private async Task<Mod[]> GetAllMods()
	{
		var (error, modioPage) = await Mod.GetMods(new ModSearchFilter());
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error getting mods: {error}");
			return Array.Empty<Mod>();
		}
		return modioPage.Data;
	}

	private async void SetRandomMod()
	{
		Mod mod = allMods[UnityEngine.Random.Range(0, allMods.Length - 1)];
		randomName.text = mod.Name;
		var (error, texture2D) = await mod.Logo.DownloadAsTexture2D(Mod.LogoResolution.X320_Y180);
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error downloading {mod.Name}'s logo: {error}");
		}
		else
		{
			randomLogo.sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
		}
	}

	private static Mod[] GetSubscribedMods()
	{
		return User.Current.ModRepository.GetSubscribed().ToArray();
	}

	private async Task SubscribeToMod(Mod mod)
	{
		Error error = await mod.Subscribe();
		if ((bool)error)
		{
			UnityEngine.Debug.LogError($"Error subscribing to {mod.Name}: {error}");
		}
		else
		{
			UnityEngine.Debug.Log("Subscribed to mod: " + mod.Name);
		}
	}

	private void WakeUpModManagement()
	{
		ModInstallationManagement.ManagementEvents += HandleModManagementEvent;
		void HandleModManagementEvent(Mod mod, Modfile modfile, ModInstallationManagement.OperationType jobType, ModInstallationManagement.OperationPhase jobPhase)
		{
			UnityEngine.Debug.Log($"{jobType} {jobPhase}: {mod.Name}");
			switch (jobPhase)
			{
			case ModInstallationManagement.OperationPhase.Started:
				if (jobType != ModInstallationManagement.OperationType.Uninstall)
				{
					currentDownload = mod;
				}
				break;
			case ModInstallationManagement.OperationPhase.Cancelled:
			case ModInstallationManagement.OperationPhase.Failed:
				currentDownload = null;
				break;
			case ModInstallationManagement.OperationPhase.Completed:
				if (jobType != ModInstallationManagement.OperationType.Uninstall)
				{
					UnityEngine.Debug.Log("Mod " + mod.Name + " installed at " + mod.File.InstallLocation);
					currentDownload = null;
				}
				else
				{
					UnityEngine.Debug.Log("Mod " + mod.Name + " uninstalled");
				}
				break;
			}
		}
	}

	private void Update()
	{
		if (currentDownload != null)
		{
			timeToProgressCheck -= Time.deltaTime;
			if (!(timeToProgressCheck > 0f))
			{
				UnityEngine.Debug.Log($"Downloading {currentDownload.Name}: [{Mathf.RoundToInt(currentDownload.File.FileStateProgress * 100f)}%]");
				timeToProgressCheck += 1f;
			}
		}
	}

	private async Task<DummyModData> GenerateDummyMod(string dummyName, string summary, string backgroundColor, string textColor, int megabytes)
	{
		UnityEngine.Debug.Log("Writing temporary mod file: " + dummyName);
		string path = Path.Combine(Application.dataPath, "../_temp_dummy_mods/" + dummyName);
		Directory.CreateDirectory(path);
		using (FileStream fs = File.OpenWrite(Path.Combine(path, dummyName + ".dummy")))
		{
			for (int i = 0; i < megabytes; i++)
			{
				RandomBytes.NextBytes(Megabyte);
				await fs.WriteAsync(Megabyte, 0, Megabyte.Length);
			}
		}
		return new DummyModData(dummyName, summary, await GenerateLogo(dummyName.Replace(' ', '+'), backgroundColor, textColor), path);
	}

	private async Task<Texture2D> GenerateLogo(string text, string backgroundColor, string textColor)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture("https://placehold.co/512x288/" + backgroundColor + "/" + textColor + ".png?text=" + text);
		request.SendWebRequest();
		while (!request.isDone)
		{
			await Task.Yield();
		}
		if (request.result != UnityWebRequest.Result.Success)
		{
			UnityEngine.Debug.LogError("GenerateLogo failed: " + request.error);
			return null;
		}
		return DownloadHandlerTexture.GetContent(request);
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
			FilePathsData = new byte[146]
			{
				0, 0, 0, 2, 0, 0, 0, 58, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
				105, 110, 115, 92, 109, 111, 100, 46, 105, 111,
				92, 85, 110, 105, 116, 121, 92, 69, 120, 97,
				109, 112, 108, 101, 115, 92, 77, 111, 100, 105,
				111, 85, 110, 105, 116, 121, 69, 120, 97, 109,
				112, 108, 101, 46, 99, 115, 0, 0, 0, 2,
				0, 0, 0, 72, 92, 65, 115, 115, 101, 116,
				115, 92, 80, 108, 117, 103, 105, 110, 115, 92,
				109, 111, 100, 46, 105, 111, 92, 85, 110, 105,
				116, 121, 92, 69, 120, 97, 109, 112, 108, 101,
				115, 92, 77, 111, 100, 105, 111, 85, 110, 105,
				116, 121, 80, 108, 97, 116, 102, 111, 114, 109,
				69, 120, 97, 109, 112, 108, 101, 76, 111, 97,
				100, 101, 114, 46, 99, 115
			},
			TypesData = new byte[189]
			{
				0, 0, 0, 0, 18, 124, 77, 111, 100, 105,
				111, 85, 110, 105, 116, 121, 69, 120, 97, 109,
				112, 108, 101, 0, 0, 0, 0, 30, 77, 111,
				100, 105, 111, 85, 110, 105, 116, 121, 69, 120,
				97, 109, 112, 108, 101, 124, 68, 117, 109, 109,
				121, 77, 111, 100, 68, 97, 116, 97, 0, 0,
				0, 0, 52, 77, 111, 100, 105, 111, 46, 85,
				110, 105, 116, 121, 46, 69, 120, 97, 109, 112,
				108, 101, 115, 124, 77, 111, 100, 105, 111, 85,
				110, 105, 116, 121, 80, 108, 97, 116, 102, 111,
				114, 109, 69, 120, 97, 109, 112, 108, 101, 76,
				111, 97, 100, 101, 114, 0, 0, 0, 0, 69,
				77, 111, 100, 105, 111, 46, 85, 110, 105, 116,
				121, 46, 69, 120, 97, 109, 112, 108, 101, 115,
				46, 77, 111, 100, 105, 111, 85, 110, 105, 116,
				121, 80, 108, 97, 116, 102, 111, 114, 109, 69,
				120, 97, 109, 112, 108, 101, 76, 111, 97, 100,
				101, 114, 124, 80, 108, 97, 116, 102, 111, 114,
				109, 69, 120, 97, 109, 112, 108, 101, 115
			},
			TotalFiles = 2,
			TotalTypes = 4,
			IsEditorOnly = false
		};
	}
}
namespace Modio.Unity.Examples;

public class ModioUnityPlatformExampleLoader : MonoBehaviour
{
	[Serializable]
	private class PlatformExamples
	{
		public RuntimePlatform[] platforms;

		public string[] prefabNames;
	}

	[SerializeField]
	private PlatformExamples[] platformExamplesPerPlatform;

	private void Awake()
	{
		RuntimePlatform platform = Application.platform;
		PlatformExamples[] array = platformExamplesPerPlatform;
		foreach (PlatformExamples platformExamples in array)
		{
			if (!Enumerable.Contains(platformExamples.platforms, platform))
			{
				continue;
			}
			string[] prefabNames = platformExamples.prefabNames;
			foreach (string text in prefabNames)
			{
				GameObject gameObject = Resources.Load<GameObject>(text);
				if (gameObject != null)
				{
					UnityEngine.Debug.Log($"Instantiating platform {text} for platform {platform}");
					UnityEngine.Object.Instantiate(gameObject, base.transform);
				}
				else
				{
					UnityEngine.Debug.LogError($"Couldn't find expected platformExample {text} for platform {platform}");
				}
			}
		}
	}

	[ContextMenu("TestAllPrefabNamesAreFound")]
	private void TestAllPrefabNamesAreFound()
	{
		bool flag = false;
		PlatformExamples[] array = platformExamplesPerPlatform;
		foreach (PlatformExamples platformExamples in array)
		{
			string[] prefabNames = platformExamples.prefabNames;
			foreach (string text in prefabNames)
			{
				if (Resources.Load<GameObject>(text) == null)
				{
					UnityEngine.Debug.LogError($"Couldn't find expected platformExample {text} for platform {platformExamples.platforms.FirstOrDefault()}");
					flag = true;
				}
			}
		}
		if (!flag)
		{
			UnityEngine.Debug.Log("No issues found");
		}
	}
}
