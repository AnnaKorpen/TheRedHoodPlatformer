using UnityEngine;

public class PlayerFallEffect : MonoBehaviour
{
    [SerializeField] private GameObject jumpEffector;
    [SerializeField] private Rigidbody2D playerRigidbody;

    private void Update()
    {
        if (playerRigidbody.velocity.y < 0)
        {
            jumpEffector.SetActive(true);
        }
        else
        {
            jumpEffector.SetActive(false);
        }
    }
}
