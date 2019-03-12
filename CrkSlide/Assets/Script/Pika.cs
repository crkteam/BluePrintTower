using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pika : MonoBehaviour
{
    private int count = 0;
    private Quaternion origin;

    private void Start()
    {
        origin = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0,8);
            
            CancelInvoke();
            count = 0;
            InvokeRepeating("rotate",0,0.01f);
        }
    }

    void rotate()
    {
        
        transform.Rotate(0,0,-5);
        count++;

        if (count > 70)
        {
            gameObject.transform.rotation = origin;
            count = 0;
            CancelInvoke();
        }
    }
}
