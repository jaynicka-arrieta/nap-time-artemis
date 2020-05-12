using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class nextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;
    void Start()
    {
        video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!video.isPlaying) {
            SceneManager.LoadScene(0);
            Debug.Log("reached end of video");
        }
    }




}
