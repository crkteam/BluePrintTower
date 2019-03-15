using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private TextMesh point_ui;

    private int point;

    private void Start()
    {
        point = 301;
    }

    public void minus(int order)
    {
        point -= order;
        point_ui.text = point.ToString();
    }
    
    
}
