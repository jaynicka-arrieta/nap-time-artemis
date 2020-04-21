using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerEvent : MonoBehaviour {
    //public string sceneName;

    void OnTriggerEnter2D(Collider col) {
        Debug.Log("Entered Trigger Object");
        if (col.gameObject.CompareTag("changeScene")) {
            SceneManager.LoadScene(1);

        }
    }
}
