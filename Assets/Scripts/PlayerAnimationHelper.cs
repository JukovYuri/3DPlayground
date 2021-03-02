using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{
	[SerializeField] private Weapon weapon;
	Animator animator;
	private bool checkCombo;
	private bool isAttacking;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (isAttacking)
		{
			return;
		}

		if (Input.GetButtonDown("Fire1"))
		{
			if (checkCombo)
			{
				animator.SetTrigger("Attack2");

			}
			else
			{
				animator.SetTrigger("Attack");
			}
		}
	}

	public void MeleeAttackStart()
	{
		isAttacking = true;
		weapon.MeleeAttackStart();
	}

	public void MeleeAttackEnd()
	{
		isAttacking = false;
		weapon.MeleeAttackEnd();
		animator.ResetTrigger("Attack");
		checkCombo = true;
	}
	public void DeathEnd()
	{
		PlayerMovement.Instance.ResetAfterDeath();
	}

	public void ComboStart()
	{
		checkCombo = true;
	}

	public void ComboEnd()
	{
		if (checkCombo)
		{
			checkCombo = false;
			animator.SetTrigger("Attack2");
		}
	}
}
