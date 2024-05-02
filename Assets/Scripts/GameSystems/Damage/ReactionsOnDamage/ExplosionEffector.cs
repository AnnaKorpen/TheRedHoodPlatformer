using UnityEngine;

public class ExplosionEffector : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffectorPref;

    private GameObject explosionEffector;

    public void Explode()
    {
        explosionEffector = Instantiate(explosionEffectorPref);
        explosionEffector.transform.position = transform.position;
        explosionEffector.gameObject.GetComponent<ExplosionTimer>().StartTimer();
        Destroy(gameObject);
    }

}
