using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"start");
    }

    // Update is called once per frame
    void Update()
    {
        float diff = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            diff -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            diff += speed * Time.deltaTime;
        }

        transform.Translate(new Vector3(diff, 0, 0));
    
    }
}
