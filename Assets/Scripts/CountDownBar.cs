using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Fungus;

public class CountDownBar : MonoBehaviour {
    public static Image fillImg;
    float sprintTime;
    float rechargeTime;
    float currentTime;
    public bool boosted;
    public Flowchart flowchart;

    // Use this for initialization
    void Start () {
        fillImg = this.GetComponent<Image>();
        sprintTime = 3; // If changed, also change fungus wait time
        rechargeTime = 5;
        currentTime = rechargeTime;
        fillImg.fillAmount = 1;
        boosted = false;
    }
    
    // Update is called once per frame
    void Update () {
        boosted = flowchart.GetBooleanVariable("boosted");
        if (boosted == true) {
            fillImg.sprite = Resources.Load <Sprite>("SettingsBold");
            if (currentTime > 3) {
                currentTime = 3;
            }
            currentTime -= Time.deltaTime;
            fillImg.fillAmount = (currentTime / sprintTime);
        } else {
            fillImg.sprite = Resources.Load <Sprite>("settings");
            if (currentTime < 5) {
                currentTime += Time.deltaTime;
                fillImg.fillAmount = currentTime / rechargeTime; 
            }
        }
        if (currentTime >= 5) {
            fillImg.sprite = Resources.Load <Sprite>("SettingsBold");
        }
    }
}