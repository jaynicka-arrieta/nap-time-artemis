using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Fungus;

public class Respawn : MonoBehaviour
{   
    // public Flowchart flowchart;
    //  void Start() {
    //     flowchart = GameObject.FindObjectOfType<Flowchart>();
    // }
    
    void OnTriggerEnter2D (Collider2D other) {
        // flowchart.ExecuteBlock("Respawn");
        Debug.Log("respawn");
        transform.position = new Vector3 (-40.06f, -5.88f, 0f);
    }
}
