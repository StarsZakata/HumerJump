using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracing : MonoBehaviour
{
	[SerializeField] private Vector3 directionOffset;
	[SerializeField] private float length;

	private Ball ball;
	private Beam beam;

	private Vector3 camerPosition;
	private Vector3 minimemBallPosistion;
	private void Start()
	{
		ball = FindObjectOfType<Ball>();
		beam = FindObjectOfType<Beam>();

		camerPosition = ball.transform.position;
		minimemBallPosistion = ball.transform.position;
		
		TrackBall();

	}
	private void Update()
	{
		if (ball.transform.position.y < minimemBallPosistion.y)
		{
			TrackBall();
			minimemBallPosistion = ball.transform.position;
		}
	}
	private void TrackBall()
	{
		Vector3 beamPosition = beam.transform.position;
		beamPosition.y = ball.transform.position.y;
		camerPosition = ball.transform.position;
		Vector3 direction = (beamPosition - ball.transform.position).normalized + directionOffset;
		camerPosition -= direction * length;
		transform.position = camerPosition;
		transform.LookAt(ball.transform);
	}
}
