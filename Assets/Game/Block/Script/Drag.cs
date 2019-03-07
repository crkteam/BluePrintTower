using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private int mark1, mark2, mark3;

    private int type;
    
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 prev;

    private GreenBlock buffer;
    private Vector3 purpose;


    private void Start()
    {
        type = 0;
        init(0, 1, 999);
    }

    void init(int mark1, int mark2, int mark3)
    {
        this.mark1 = mark1;
        this.mark2 = mark2;
        this.mark3 = mark3;
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, 0, 90);
        }

        if (mark3 == 999)
        {
            GameObject.Find("Grid_Map").GetComponent<Grid_Map>().detector(type,mark1, mark2);
        }
        else
        {
            GameObject.Find("Grid_Map").GetComponent<Grid_Map>().detector(type,mark1, mark2,mark3);
        }


        prev = transform.position;
        transform.position += new Vector3(Random.Range(-0.05f, 0.05f), 0.05f); // 典籍會有抬起來的效果
        offset = gameObject.transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) // 轉向
        {
            
            if (type == 0)
            {
                gameObject.transform.Rotate(0,0,-90);
                type = 1;
            }
            else
            {
                gameObject.transform.Rotate(0,0,90);
                type = 0;
            }
        }
    }


    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        if (buffer != null)
        {
            transform.position = purpose;
            endDrag();
            buffer.setDestroyPoint();
        }
        else
        {
            transform.position = prev;
        }

        GameObject[] green = GameObject.FindGameObjectsWithTag("GreenBlock");
        foreach (var value in green)
        {
            Destroy(value);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GreenBlock"))
        {
            buffer = other.GetComponent<GreenBlock>();
            purpose = other.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("GreenBlock"))
        {
            buffer = null;
        }
    }

    private void endDrag()
    {
        setRigibodyStatus();
        Destroy(gameObject.GetComponent<Drag>());
    }

    private void setRigibodyStatus()
    {
        gameObject.GetComponent<Rigidbody2D>().mass = 5;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;

        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}