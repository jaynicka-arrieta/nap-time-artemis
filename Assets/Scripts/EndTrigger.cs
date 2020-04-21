using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Fungus;

public class EndTrigger : MonoBehaviour
{
    public Flowchart flowchart;

     void Start() {
        flowchart = GameObject.FindObjectOfType<Flowchart>();
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        flowchart.ExecuteBlock("End");
    }
}
