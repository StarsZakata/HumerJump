using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformSegment : MonoBehaviour
{
	public void Bounce(float Force, Vector3 centre, float raduis) {
		if (TryGetComponent(out Rigidbody rigidbody)){
			rigidbody.isKinematic = false;
			rigidbody.AddExplosionForce(Force, centre, raduis);
		}
	
	}
}
