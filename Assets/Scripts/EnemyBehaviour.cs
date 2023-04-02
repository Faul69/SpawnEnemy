using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private int _maxMove;
    private WaitForSeconds _wait;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxMove = 10;
        _wait = new WaitForSeconds(1);
        StartCoroutine(routine: MoveRightLeft());
    }

    private IEnumerator MoveRightLeft()
    {
        int count = 0;

        while (count < _maxMove)
        {
            yield return _wait;
            _rigidbody2D.AddForce(Vector2.right, ForceMode2D.Impulse);
            yield return _wait;
            _rigidbody2D.AddForce(Vector2.left, ForceMode2D.Impulse);
            count++;
        }
    }
}
