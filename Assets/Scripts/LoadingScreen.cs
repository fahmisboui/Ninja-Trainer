using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider progressBar;
    [SerializeField] GameObject slideHandle;

    public void LoadingScene(int id)
    {
        StartCoroutine(LoadingCoroutine(id));
    }

    public IEnumerator LoadingCoroutine(int id)
    {
        progressBar.value = 0;
        loadingScreen.SetActive(true);

        AsyncOperation scene = SceneManager.LoadSceneAsync(id);
        scene.allowSceneActivation = false;
        float prg = 0;
        while (!scene.isDone)
        {
            prg = Mathf.MoveTowards(prg, scene.progress, Time.deltaTime);
            progressBar.value = prg;
            float rotationAmount = -progressBar.value * 360f;
            slideHandle.LeanRotateZ(rotationAmount, 0.1f);

            if (prg >= 0.9f)
            {
                progressBar.value = 1;
                scene.allowSceneActivation = true;
                loadingScreen.SetActive(false);
            }
            
        yield return null;
        }
    }
}
