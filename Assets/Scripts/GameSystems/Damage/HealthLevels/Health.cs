
public class Health
{
    public Health(float health)
    {
        currentHealth = health;
        isAlive = true;
    }

    public float currentHealth {  get; private set; }
    private bool isAlive;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth <= 0)
        {
            isAlive = false;

            currentHealth = 0;
        }

    }

    public bool IsAlive()
    { 
        return isAlive; 
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
