using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public float threshold;
    private Vector3 startingPos;

    private void Start() {
        startingPos = transform.position;
    }


    private void FixedUpdate() {
        if (transform.position.y < threshold)
            transform.position = startingPos;
    }
}
