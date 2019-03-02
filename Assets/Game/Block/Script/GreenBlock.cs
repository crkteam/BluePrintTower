using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : MonoBehaviour
{
    private Grid_Map _gridMap;
    
    private int x1, x2, x3;
    private int y1, y2, y3;

    public void key(int x1, int y1, int x2, int y2)
    {
        this.x1 = x1;
        this.x2 = x2;
        x3 = 999;
        this.y1 = y1;
        this.y2 = y2;
        y3 = 999;
    }

    public void key(int x1, int y1, int x2, int y2, int x3, int y3)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.x3 = x3;
        this.y1 = y1;
        this.y2 = y2; 
        this.y3 = y3;
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