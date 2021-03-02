using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public AnimationCurve animationCurve;


    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalRotate(new Vector3(90, 0, 0), Random.value)).SetEase(Ease.OutCubic);
        sequence.AppendInterval(Random.value);
        sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 0), 1f));
        sequence.SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.Instance.ApplyDamage();
            print("hit");
        }
    }

}
