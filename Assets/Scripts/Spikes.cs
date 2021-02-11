using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{

	[SerializeField] float downY;
	[SerializeField] float UpY;
	[SerializeField] float upTime = 10f;
	[SerializeField] float downTime = 10f;

	[SerializeField] float upDelay = 1f;
	[SerializeField] float downDelay = 1f;


	// Start is called before the first frame update
	void Start()
	{
		Vector3 startPosition = transform.position;
		startPosition.y = downY;
		transform.position = startPosition;
	}

	// Update is called once per frame
	void Update()
	{

		Sequence moveSequence = DOTween.Sequence();
		moveSequence.Append(transform.DOMoveY(UpY, upTime));
		moveSequence.AppendInterval(upDelay);
		moveSequence.Append(transform.DOMoveY(downY, downTime));
		moveSequence.AppendInterval(downDelay);
		moveSequence.SetLoops(-1);

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerMovement.Instance.DoDamage();
		}
	}
}
