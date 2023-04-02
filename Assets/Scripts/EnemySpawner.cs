using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private readonly WaitForSeconds TwoSeconds = new WaitForSeconds(2);

    [SerializeField] private Transform _templePoints;
    [SerializeField] private EnemyBehaviour _enemy;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_templePoints.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _templePoints.GetChild(i);
        }

        StartCoroutine(routine: SpawnEnemyOnPoints());
    }

    private IEnumerator SpawnEnemyOnPoints()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            yield return TwoSeconds;
            Instantiate(_enemy, _points[i]);
        }
    }
}

