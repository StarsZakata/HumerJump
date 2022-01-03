using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
	[SerializeField] private float _jumpForce = 5;

	private Rigidbody rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
		}
	}


}
