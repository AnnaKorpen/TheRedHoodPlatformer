using System.Collections;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    private float explosionTime = 0.1f;

    public void StartTimer()
    {
        StartCoroutine(CountExplosionTime());
    }

    private IEnumerator CountExplosionTime()
    {
        yield return new WaitForSeconds(explosionTime);
        Destroy(gameObject);
    }
}
