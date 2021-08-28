using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        SpawnNewCoin();
    }

    private void SpawnNewCoin()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_coin, _spawnPoints[i].transform.position, Quaternion.identity);
        }
    }
}
