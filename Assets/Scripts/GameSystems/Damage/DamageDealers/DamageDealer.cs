using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Collider2D))]
public class DamageDealer : MonoBehaviour
{
    [Header("Damage vars")]
    [SerializeField] private FloatValueSO damage;
    [SerializeField] private LayerMask damageIgnoreLayer;

    [Header("Settings")]
    [SerializeField] bool disabledAfterTime;
    [SerializeField] private float lifeTime;
    [SerializeField] bool disabledAfterDamage;

    [Header("Events")]
    public UnityEvent damageEvent;

    private void OnEnable()
    {
        if(disabledAfterTime)
        {
            StartCoroutine(CountLifeTime());
        }
    }

    private IEnumerator CountLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (((1 << collision.gameObject.layer) & damageIgnoreLayer.value) == 0)
        {
            IDamageable health = collision.gameObject.GetComponentInParent<IDamageable>();
            IGetPosition reciver = collision.gameObject.GetComponentInParent<IGetPosition>();

            if (health != null && health.IsAlive())
            {
                if (reciver != null)
                {
                    reciver.TakePosition(transform.position);
                }

                health.TakeDamage(damage.runtimeValue);
                damageEvent.Invoke();
            }

            DisableAfterDamage();
        }
    }

    private void DisableAfterDamage()
    {
        if (disabledAfterDamage)
        {
            gameObject.SetActive(false);
        }
    }


}
