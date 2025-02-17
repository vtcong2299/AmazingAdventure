using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : Singleton<Scene>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator LoadSceneWithDelay(int sceneIndex, GameObject panelLoading)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        panelLoading.SetActive(true);
        float progress = 0;
        while (!operation.isDone)
        {
            progress = Mathf.MoveTowards(progress, operation.progress, Time.deltaTime);
            if (progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }

}
