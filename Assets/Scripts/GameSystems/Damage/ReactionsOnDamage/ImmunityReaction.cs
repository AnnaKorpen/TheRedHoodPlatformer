using System.Collections;
using UnityEngine;

public class ImmunityReaction : MonoBehaviour
{
    [SerializeField] private PlayerCurrentStateSO playerState;
    [SerializeField] private PlayerConfigSO playerConfig;

    public void GiveImmunity()
    {
        playerState.isImmuned = true;

        StartCoroutine(StartImmunityTimer());
    }

    private IEnumerator StartImmunityTimer()
    {
        yield return new WaitForSeconds(playerConfig.reactionConfig.knockTime);

        playerState.isImmuned = false;
    }
}
