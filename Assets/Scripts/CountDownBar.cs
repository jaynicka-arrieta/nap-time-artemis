using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class CountDownBar : MonoBehaviour {
    public static Image fillImg;
    float totalTime;
    float currentTime;
    public Text timeText;
    public bool boosted;
    public Flowchart flowchart;
    public GameObject timer;
    public GameObject boostRemaining;

    // Use this for initialization
    void Start () {
        fillImg = this.GetComponent<Image>();
        totalTime = 5;
        // flowchart = GameObject.FindObjectOfType<Flowchart>();
    }
    
    // Update is called once per frame
    void Update () {
        boosted = flowchart.GetBooleanVariable("boosted");
        if (boosted == true) {
            currentTime -= Time.deltaTime;
            fillImg.fillAmount = currentTime / totalTime; 
            timeText.text = currentTime.ToString("F");
        }
        if (currentTime <= 0) {
            currentTime = 5;
            fillImg.fillAmount = 1;
        }
    }
}