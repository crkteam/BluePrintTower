using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private GameController _gameController;

    [SerializeField] private int order;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("bullet"))
        {
            _gameController.minus(order);
        }
    }
}