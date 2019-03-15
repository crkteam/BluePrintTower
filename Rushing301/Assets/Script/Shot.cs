using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet, copy_bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject buffer = Instantiate(copy_bullet);
            buffer.transform.position = bullet.transform.position;

            buffer.GetComponent<Rigidbody2D>().velocity = new Vector2(0,10);
        }
    }
}
