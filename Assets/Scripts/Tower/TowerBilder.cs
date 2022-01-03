using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBilder : MonoBehaviour
{
	[SerializeField] private int _levelCount;

	[SerializeField] private GameObject _beam;

	[SerializeField] private SpawnPlatform _spawnPlatform;
	[SerializeField] private Platform[] _Platform;
	[SerializeField] private FinichPlatform _finichPlatform;


	[SerializeField] private float _additionalScale;

	//Scale в учет нашего финиша и старта
	private float startAndFinifAdditionalSceale = 0.5f;

	public float BeamScaleY => _levelCount / 2f + startAndFinifAdditionalSceale + _additionalScale / 2f;
	private void Awake()
	{
		Build();
	}


	private void Build() {

		GameObject beam = Instantiate(_beam, transform);
		beam.transform.localScale = new Vector3(1, BeamScaleY, 1);


		Vector3 spawnPosition = beam.transform.position;
		spawnPosition.y += beam.transform.localScale.y - _additionalScale;

		SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);


		for (int i = 0; i < _levelCount; i++)
		{
			///в зависимости от видов плафторм выбирается одна
			SpawnPlatform(
				_Platform[Random.Range(0, _Platform.Length)], 
				ref spawnPosition,
				beam.transform);  

		}

		SpawnPlatform(_finichPlatform, ref spawnPosition, beam.transform);


	}

	private void SpawnPlatform(Platform platform, ref Vector3 SpawnPosition, Transform parent) {
		Instantiate(platform, SpawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
		SpawnPosition.y -= 1;
	}


}
