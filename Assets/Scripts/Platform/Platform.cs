using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] private float BounceForce;
	[SerializeField] private float BonceRadius;

	public void Break()
	{
		PlatformSegment[]  PlatformSegment = GetComponentsInChildren<PlatformSegment>();

		foreach (var segment in PlatformSegment) {
			segment.Bounce(BounceForce, transform.position, BonceRadius);
		}
	}
}
