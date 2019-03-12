using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(-0.01f,0,0);
        if (gameObject.transform.position.x < -13.5)
        {
            gameObject.transform.position += new Vector3(0,0,0);
        }
    }
}
