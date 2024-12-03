using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(AudioSource))]

public class PlayVideo : MonoBehaviour
{
    public VideoClip videoClip;

    private VideoPlayer videoPlayer;
    private AudioSource audioScource;

    
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        audioScource = GetComponent<AudioSource>();

        // disable PLAY ON AWAKE FOR BOTH VIDEO AND AUDIO
        videoPlayer.playOnAwake = false;
        audioScource.playOnAwake = false;

        // assign video clip
        videoPlayer.source = VideoSource.VideoClip;
        videoPlayer.clip = videoClip;

        // setup AudioSource
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioScource);

        // render video to main texture of assigned GAmeobject
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
    }

 
    void Update()
    {
        // space bar to start / pause
        if (Input.GetButtonDown("Jump"))//ooks for person to hit space bar for play or pause
            PlayPause();
    }
    private void PlayPause()
    {
        if (videoPlayer.isPlaying)//
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }
}
