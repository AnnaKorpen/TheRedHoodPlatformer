using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class GameEventSceneRestarter : MonoBehaviour
{
    [SerializeField] private List<CodedGameEventListener> gameEventListeners;
    [SerializeField] private float loadTimeDelay;

    private SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = GetComponent<SceneLoader>();
    }
    private void OnEnable()
    {
        if (gameEventListeners.Count < 1) return;

        foreach (CodedGameEventListener gameEventListener in gameEventListeners)
        {
            gameEventListener.OnEnabled(OnEventTriggered);
        }
    }

    private void OnDisable()
    {
        foreach (CodedGameEventListener gameEventListener in gameEventListeners)
        {
            gameEventListener.OnDisable();
        }
    }

    private void OnEventTriggered()
    {
        sceneLoader.LoadCurrentScene(loadTimeDelay);
    }


}
