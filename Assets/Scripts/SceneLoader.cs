using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using Fusion;
//using Fusion.Sockets;
using System;

[RequireComponent(typeof(ScreenFade))]
public class SceneLoader : MonoBehaviour
{
	[SerializeField] GameObject loadingUI;
	[SerializeField] Slider loadingMeterUI;
	ScreenFade screenFade;

    private void Awake()
    {
		if (screenFade == null) screenFade = GetComponent<ScreenFade>();
    }

    public void Load(string sceneName)
	{
		StartCoroutine(LoadScene(sceneName));
	}

	IEnumerator LoadScene(string sceneName)
	{
		Time.timeScale = 1;

		// fade out screen
		screenFade.FadeOut();
		yield return new WaitUntil(() => screenFade.isDone);

		// load scene
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
		asyncOperation.allowSceneActivation = false;
		Pause.Instance.paused = false;

		// show loading ui
		loadingUI.SetActive(true);

		// update progress meter
		while (asyncOperation.progress < 0.9f)
		{
			loadingMeterUI.value = asyncOperation.progress;
			yield return null;
		}
		loadingMeterUI.value = 1;
		yield return new WaitForSeconds(1);

		// hide loading ui
		loadingUI.SetActive(false);
		
		// scene loaded / start
		asyncOperation.allowSceneActivation = true;

		// fade in screen
		screenFade.FadeIn();
		yield return new WaitUntil(() => screenFade.isDone);
	}

	public void NetworkedLoadScene(string sceneName)
    {
		//GameManager.Instance.runner.SetActiveScene(sceneName);
	}
}
