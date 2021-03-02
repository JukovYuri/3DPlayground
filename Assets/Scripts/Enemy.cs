using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (Damageable), typeof (Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;

    Animator animator;
    Damageable damageable;
    void Start()
    {
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
        damageable.OnApplyDamage += ApplyDamage; 

    }

    private void ApplyDamage(int damage)
    {
        animator.SetTrigger("Hit");
        SubHealth(damage);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int bonus)
    {
        health += bonus;
    }
    public void SubHealth(int damage)
    {
        health -= damage;
    }
}
