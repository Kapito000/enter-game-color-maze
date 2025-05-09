using UnityEditor;
using UnityEditor.SceneManagement;
using static CapLib.SceneBootstrapper.Constant;

namespace CapLib.SceneBootstrapper
{
	[InitializeOnLoad]
	public class SceneBootstrapper
	{
		const string _previousScene = FullModuleName + "PreviousScene";
		const string _shouldLoadBootstrap = FullModuleName + "LoadBootstrapScene";

		const string _loadBootstrapMenu = FullModuleName +
			"Load Bootstrap Scene On Play";
		const string _dontLoadBootstrapMenu = FullModuleName +
			"Don't Load Bootstrap Scene On Play";

		static string BootstrapScene => EditorBuildSettings.scenes[0].path;

		static string PreviousScene
		{
			get => EditorPrefs.GetString(_previousScene);
			set => EditorPrefs.SetString(_previousScene, value);
		}

		static bool ShouldLoadBootstrapScene
		{
			get => EditorPrefs.GetBool(_shouldLoadBootstrap, true);
			set => EditorPrefs.SetBool(_shouldLoadBootstrap, value);
		}

		static SceneBootstrapper() =>
			EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

		static void OnPlayModeStateChanged(
			PlayModeStateChange playModeStateChange)
		{
			if (!ShouldLoadBootstrapScene)
				return;

			switch (playModeStateChange)
			{
				case PlayModeStateChange.ExitingEditMode:
					PreviousScene = EditorSceneManager.GetActiveScene().path;

					if (/*EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo() &&*/
					    IsSceneInBuildSettings(BootstrapScene))
					{
						EditorSceneManager.OpenScene(BootstrapScene);
					}

					break;

				case PlayModeStateChange.EnteredEditMode:
					if (!string.IsNullOrEmpty(PreviousScene))
					{
						EditorSceneManager.OpenScene(PreviousScene);
					}

					break;
			}
		}

		[MenuItem(_loadBootstrapMenu)]
		static void EnableBootstrapper() =>
			ShouldLoadBootstrapScene = true;

		[MenuItem(_loadBootstrapMenu, true)]
		static bool ValidateEnableBootstrapper() =>
			!ShouldLoadBootstrapScene;

		[MenuItem(_dontLoadBootstrapMenu)]
		static void DisableBootstrapper() =>
			ShouldLoadBootstrapScene = false;

		[MenuItem(_dontLoadBootstrapMenu, true)]
		static bool ValidateDisableBootstrapper() =>
			ShouldLoadBootstrapScene;

		static bool IsSceneInBuildSettings(string scenePath)
		{
			if (string.IsNullOrEmpty(scenePath))
				return false;

			foreach (var scene in EditorBuildSettings.scenes)
				if (scene.path == scenePath)
					return true;

			return false;
		}
	}
}