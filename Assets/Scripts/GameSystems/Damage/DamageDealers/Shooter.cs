using UnityEngine;

public class Shooter : MonoBehaviour, IWeapon
{
    [SerializeField] private ObjectPool energyBallPool;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameEventSO onShoot;

    private GameObject ActivateEnergyBall()
    {
        GameObject energyBall = energyBallPool.GetPooledObject();

        if (energyBall != null)
        {
            energyBall.transform.position = firePoint.position;
            energyBall.SetActive(true);

            return energyBall;
        }

        return null;
    }

    public void Attack(bool lookForward)
    {
        GameObject energyBall = ActivateEnergyBall();

        if (energyBall != null)
        {
            Rigidbody2D bulletRigidbody = energyBall.GetComponent<Rigidbody2D>();

            if (lookForward)
            {
                bulletRigidbody.velocity = new Vector2(fireSpeed * 1, bulletRigidbody.velocity.y);
            }
            else
            {
                bulletRigidbody.velocity = new Vector2(fireSpeed * -1, bulletRigidbody.velocity.y);
            }

            onShoot?.TriggerEvent();
        }
    }
}
