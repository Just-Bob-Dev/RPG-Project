using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 20f;

    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        health = Mathf.Max(health - damage, 0); //gives you whichever is higher.
        print(health);
    }
}
