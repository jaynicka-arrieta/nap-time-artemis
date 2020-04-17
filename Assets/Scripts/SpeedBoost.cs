using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SpeedBoost : MonoBehaviour
{
    public Flowchart flowchart;
    void OnTriggerEnter2D (Collider2D other) {
        flowchart = GameObject.FindObjectOfType<Flowchart>();
        flowchart.ExecuteBlock("SpeedBoost");
    }
}
