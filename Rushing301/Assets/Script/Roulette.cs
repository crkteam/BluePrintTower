using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    private int count = 0;

    private bool type;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spinRotate(3, -3, 200);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("bullet"))
        {
            Destroy(other.gameObject);
        }
    }

    void normalRotate(float speed)
    {
        // speed = 3
        gameObject.transform.Rotate(0, 0, speed);
    }

    void spinRotate(float a_speed, float b_speed, int switch_time)
    {
        count++;
        if (count == switch_time)
        {
            if (type)
            {
                type = false;
                count = 0;
            }
            else
            {
                type = true;
                count = 0;
            }
        }

        if (type)
        {
            gameObject.transform.Rotate(0, 0, b_speed);
        }
        else
        {
            gameObject.transform.Rotate(0, 0, a_speed);
        }
        
        Debug.Log(count);
    }
    
    
}