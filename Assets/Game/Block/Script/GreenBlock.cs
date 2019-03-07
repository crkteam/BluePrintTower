using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
{
    private Grid_Map _gridMap;
    
    private int x1, x2, x3;
    private int y1, y2, y3;

    public void key(int type, int length, int x, int y) // type 0: 橫的 1: 直的
    {
        if (type == 0)
        {
            x1 = x;
            y1 = y;

            x2 = x + 1;
            y2 = y;

            if (length == 3)
            {
                x3 = x + 2;
                y3 = y;
            }
            else
            {
                x3 = 999;
                y3 = 999;
            }

        }
        else
        {
            x1 = x;
            y1 = y;

            x2 = x;
            y2 = y + 1;

            if (length == 3)
            {
                x3 = x;
                y3 = y + 2;
            }
            else
            {
                x3 = 999;
                y3 = 999;
            }
        }
    }
    
    public void setDestroyPoint()
    {
        _gridMap = GameObject.Find("Grid_Map").GetComponent<Grid_Map>();
            
        if (x3 == 999)
            _gridMap.setExistsBlock(x1,y1,x2,y2);
        else
            _gridMap.setExistsBlock(x1,y1,x2,y2,x3,y3);
        
    }
}