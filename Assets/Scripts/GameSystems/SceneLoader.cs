using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int currentSceneId;

    private void Awake()
    {
        currentSceneId = SceneManager.GetActiveScene().buildIndex;
    }
    private IEnumerator LoadScene(int sceneId, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(sceneId);
    }

    public void LoadCurrentScene(float timeDelay = 0)
    {
        StartCoroutine(LoadScene(currentSceneId, timeDelay));
    }
}
