using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))] 
public class TowerRotater : MonoBehaviour
{
	[SerializeField] private float _rotateSpeed = 5;

	private Rigidbody rigidbody;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody>();

	}

	private void Update()
	{
		//есть есть палец 
		if (Input.touchCount > 0){
			//получаем палец 
			Touch touch = Input.GetTouch(0);
			//если палец двигается 
			if (touch.phase == TouchPhase.Moved){
				//считаем как далеко двинулся и рассчитываем
				float torgue = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
				rigidbody.AddTorque(Vector3.up * torgue);

			}
		}
	}
}
