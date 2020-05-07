using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Death : MonoBehaviour
{
 public Flowchart flowchart;

     void Start() {
        flowchart = GameObject.FindObjectOfType<Flowchart>();
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log("dead");
        flowchart.ExecuteBlock("Death");
    }
}