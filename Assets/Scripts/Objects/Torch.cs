using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] ParticleSystem fireEffect;
    [SerializeField] GameObject fireLight;
    Damageable damageable;
    void Start()
    {
        Damageable damageable = GetComponent<Damageable>();
        damageable.OnApplyDamage += ActivateTorch;
        fireLight.SetActive(false);
        fireEffect.Stop();
    }

    private void ActivateTorch(int damage)
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
        fireLight.SetActive(false);

        if (fireEffect.isPlaying)
        {
            fireEffect.Stop();
            fireLight.SetActive(false);
        }
        else
        {
            fireEffect.Play();
            fireLight.SetActive(true);
        }
    }

}
