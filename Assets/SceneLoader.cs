using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using UnityEditor;

public class SceneLoader : Singleton<SceneLoader>
{
	public static Action<string> transition;
	public static Action<string> onSceneCall;

	public void Start()
	{
		SceneLoader.onSceneCall += loadScene;
		Time.timeScale = 1;
	}

    private void OnDisable()
    {
		SceneLoader.onSceneCall -= loadScene;
	}

    public static void loadNextScene()
	{
		string resultString = Regex.Match(SceneManager.GetSceneAt(0).name, @"\d+").Value;
	
		string levelString = "Level_" + (int.Parse(resultString) + 1).ToString();

		if (Application.CanStreamedLevelBeLoaded(levelString))
		{
            loadScene(levelString);
			transition?.Invoke(levelString);
		}
	}

	public static void loadCurrentScene()
	{
		transition?.Invoke(SceneManager.GetSceneAt(0).name);
		loadScene(SceneManager.GetSceneAt(0).name);
	}

	public static void loadScene(string sceneName)
	{
		//PauseManager.isPauasable = true;
		if (Application.CanStreamedLevelBeLoaded(sceneName))
		{
			Time.timeScale = 1;
			SceneManager.LoadScene(sceneName);
			//transition?.Invoke(sceneName);
		}
	}
}
