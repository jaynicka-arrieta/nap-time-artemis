using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Movement : MonoBehaviour
{
    public float speed;
    public Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        flowchart = GameObject.FindObjectOfType<Flowchart>();
        speed = 0;
        Debug.Log($"start");
    }

    // Update is called once per frame
    void Update()
    {
        speed = flowchart.GetFloatVariable("currentSpeed");
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
