using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMesh point_ui;

    private int point;

    private void Start()
    {
        point = 102;
    }

    public void minus(int order)
    {
        point -= order;
        
        if (point < 0)
        {
            Debug.Log("GameOver");
        }
        else if (point == 0)
        {
            Debug.Log("Win");
        }


        point_ui.text = point.ToString();
    }
}