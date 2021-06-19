using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public Stat damage;
    public Stat armor;

    public int maxHealth;
    public int currentHealth { get; private set; }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //Meant to be overwritten
    public virtual void Die()
    {
        Debug.Log("Character has died.");
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
    }
}
