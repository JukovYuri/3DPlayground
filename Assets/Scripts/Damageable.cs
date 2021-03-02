using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
	public Action <int> OnApplyDamage = delegate { };
	public void ApplyDamage(int damage)
	{
		print(name + " получил урон");
		OnApplyDamage(damage);
	}
}
