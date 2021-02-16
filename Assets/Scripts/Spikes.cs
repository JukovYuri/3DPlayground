using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

	[SerializeField] private float positionUpY;
	[SerializeField] private float positionDownY;
	[SerializeField] private float timeDownY;
	[SerializeField] private float timeUpY;
	[SerializeField] private float timeDelayUpY;
	[SerializeField] private float timeDelayDownY;
	[SerializeField] Sequence sequence;


	// Start is called before the first frame update
	void Start()
	{
		Vector3 position = transform.position;
		position.y = positionDownY;
		transform.position = position;

		sequence = DOTween.Sequence();
		sequence.Append(transform.DOMoveY(positionUpY, timeUpY));
		sequence.Append(transform.DOShakePosition(5f,0.5f,10));
		sequence.AppendInterval(timeDelayUpY);
		sequence.Append(transform.DOMoveY(positionDownY, timeDownY));
		sequence.AppendInterval(timeDelayDownY);
		sequence.SetLoops(-1);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerMovement.Instance.ApplyDamage();
		}
	}
}
