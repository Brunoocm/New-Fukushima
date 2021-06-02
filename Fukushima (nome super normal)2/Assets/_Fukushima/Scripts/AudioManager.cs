using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //FindObjectOfType<AudioManager>().Play("Lanterna");

    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null) 
            instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //musica principal
    }

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sounds=> sounds.name == name);
        if(s == null)
        {
            Debug.LogError("[AudioManager] Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
