using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FlowHandler : MonoBehaviour
{

    public VideoPlayer videoPlayer;

    public string nextSceneName;


    // Start is called before the first frame update
    void Start()
    {
        // detect end of flatline video
        videoPlayer.loopPointReached += OnVideoEndReached;
    }

    void OnVideoEndReached(VideoPlayer vp)
    {
        // go to next scene (leaderboard)
        SceneManager.LoadScene(nextSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
