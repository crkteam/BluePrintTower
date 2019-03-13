using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pika : MonoBehaviour
{
    private int count = 0;
    private Quaternion origin;

    private bool life = true;

    private void Start()
    {
        origin = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (life)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (transform.position.y > -1)
                {
                    count = 0;
                    CancelInvoke();
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 3.5f);
                    InvokeRepeating("rotate", 0, 0.01f);
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 3);
                }
            }
            
        }
    }

    void rotate()
    {
        transform.Rotate(0, 0, -6);
        count++;

        if (count > 60)
        {
            count = 0;
            CancelInvoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Block"))
        {
            Debug.Log("死亡");
            life = false;
            gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(8, -8), 8);
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // 左71
    // 正-18
    // 倒161
    // 右-108
}