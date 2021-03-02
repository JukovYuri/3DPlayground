using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    public void MeleeAttackStart()
    {
        col.enabled = true;
    }
    
    public void MeleeAttackEnd()
    {
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable !=null)
        {
            damageable.ApplyDamage(damage);
        }

    }
}
