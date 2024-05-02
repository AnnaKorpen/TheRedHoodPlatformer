using UnityEngine;
using UnityEngine.Events;

public class EnemyDisappearanceFromPlayer : MonoBehaviour
{
    [Header("Disappearing GameObjects")]
    [SerializeField] private GameObject enemySprite;
    [SerializeField] private GameObject damageDealer;
    [SerializeField] private GameObject enemyCollider;

    [Header("Disappearence Settings")]
    [SerializeField] private float disappearanceTime;
    [SerializeField] private float warningTime;
    [SerializeField] private int nonInteractableLayer;
    [SerializeField] private NPCConfigSO enemyConfig;

    private EnemyStateCreator enemyState;
    private bool isDisappeared;
    private int currentLayer;
    private float disappearanceDelay;
    private float timer;

    private void Awake()
    {
        enemyState = GetComponent<EnemyStateCreator>();

        disappearanceDelay = Random.Range(enemyConfig.minDesicionTime, enemyConfig.maxDesicionTime);
        currentLayer = gameObject.layer;
        isDisappeared = false;
    }

    private void Update()
    {
        if ((enemyState.instance.currentActionState == EnemyActionState.PlayerDetecting) || 
            (enemyState.instance.currentActionState == EnemyActionState.Revert))
        {
            if (!isDisappeared)
            {
                AppearingBehaviour();
            }

            if (isDisappeared)
            {
                DisappearingBehaviour();
            }
        }
    }

    private void DisappearingBehaviour()
    {
        timer += Time.deltaTime;

        if (timer > disappearanceTime)
        {
            timer = 0f;
            Appear();
        }
    }

    private void AppearingBehaviour()
    {
        timer += Time.deltaTime;

        if (timer > disappearanceDelay)
        {
            timer = 0f;

            disappearanceDelay = Random.Range(enemyConfig.minDesicionTime, enemyConfig.maxDesicionTime);

            Disappear();
        }
    }

    private void Disappear()
    {
        enemySprite.SetActive(false);
        damageDealer.SetActive(false);

        foreach (Transform child in enemyCollider.transform)
        {
            child.gameObject.layer = nonInteractableLayer;
        }

        isDisappeared = true;
    }

    private void Appear()
    {
        enemySprite.SetActive(true);
        damageDealer.SetActive(true);

        foreach (Transform child in enemyCollider.transform)
        {
            child.gameObject.layer = currentLayer;
        }

        isDisappeared = false;
    }
}
