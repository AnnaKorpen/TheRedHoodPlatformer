using System.Collections;
using UnityEngine;


public class MeleeWeapon : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameEventSO onAttack;
    [SerializeField] private float attackDelay = 0.1f;
    [SerializeField] private float attackTime = 0.5f;

    private bool isAttacking;
    private Collider2D weaponCollider;
    private Vector2 weaponPosition;

    private void Start()
    {
        weaponCollider = weapon.GetComponent<Collider2D>();
        weaponPosition = weaponCollider.offset;

        weapon.SetActive(false);
        isAttacking = false;
    }

    public void Attack(bool lookForward)
    {
        if (!isAttacking)
        {
            StartCoroutine(StartAttack());
            onAttack?.TriggerEvent();

            ChangeWeaponPosition(lookForward);
        }
    }

    private IEnumerator StartAttack()
    {
        isAttacking = true;

        // To synchronize with animation
        yield return new WaitForSeconds(attackDelay);

        weapon.SetActive(true);

        yield return new WaitForSeconds(GlobalFloatVars.FIXED_TIMESTEP);

        weapon.SetActive(false);

        // To avoid attack spam
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }

    private void ChangeWeaponPosition(bool lookForward)
    {
        // Set weapon position (right or left side)
        if (lookForward)
        {
            weaponCollider.offset = weaponPosition;
        }
        else
        {
            weaponCollider.offset = new Vector2(weaponPosition.x * -1, weaponPosition.y);
        }
    }

}
