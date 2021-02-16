using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Money : MonoBehaviour
{
	[Header("Animation")]
	[SerializeField] private float moveY = 2f;
	[SerializeField] private float speedRotationY = 2f;
	[SerializeField] private float timemoveY = 2f;

	void Start()
	{
		LevelManager.Instance.AddMoney();

		Sequence sequence = DOTween.Sequence();
		sequence.Append(transform.DOMoveY(moveY, timemoveY,).SetRelative()).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
	}

	private void Update()
	{
		transform.Rotate(Vector3.up, Time.deltaTime * speedRotationY, Space.World);
	}

	private void OnTriggerEnter(Collider other)
	{
		LevelManager.Instance.SubMoney();
		Destroy(gameObject);
	}


}
