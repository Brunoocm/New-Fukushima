using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Video;

public class VidUI : MonoBehaviour
{
    public GameObject vidObject;
    public GameObject text;

    public VideoPlayer vid;

    private Volume volume;
    private LensDistortion LD;

    void Start()
    {
    }

    void Update()
    {
        //volume = GameObject.Find("Post-process Volume").GetComponent<Volume>();
        //volume.profile.TryGet(out LD);
    }

    public void SetVideo(VideoClip vidRender)
    {
        vid.clip = vidRender;
        text.SetActive(true);
    }

    public void ResetObjects()
    {
        //LD.intensity.value = 0f;
        text.SetActive(false);
        vidObject.SetActive(false);
    }

    public void PlayVideo()
    {
        //LD.intensity.value = 0.7f;
        vidObject.SetActive(true);
    }
}
