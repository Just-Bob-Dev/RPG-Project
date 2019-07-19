using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 100f;

    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0); //gives you whichever is higher.
        if(healthPoints == 0)
        {
            Die();
        }
        print(healthPoints);
    }

    private void Die()
    {
        if(isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
