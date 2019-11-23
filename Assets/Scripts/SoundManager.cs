using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;
    void Awake()

    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }



        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (!s.source.isPlaying) { 
        s.source.Play();
        }

        if (PauseMenu.GameIsPaused)
        {
            s.source.pitch *= .5f;
        }

    }


    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void PlayButtonHover()
    {
        Play("buttonHover");
    }
    public void PlayButtonDown()
    {
        Play("buttonPressed");
    }

    public void PlayMenuTheme()
    {
        Play("menuTheme");
    }
    public void PlayBackGround()
    {
        Play("backGround");
        Play("bg2");
    }
    public void PlayYouLoose()
    {
        Stop("backGround");
        Stop("bg2");
        Play("youLoose");
    }

    public void PlayYouWin()
    {
        Stop("backGround");
        Stop("bg2");
        Play("youWin");
    }
    public void PlayVirusObtained()
    {
        Play("virusObtained");
    }

    public void PlayDeepT()
    {
        Play("deepT");
    }

    public void PlaySalgi()
    {
        Play("salgi");
    }
    public void StopSalgi()
    {
        Stop("salgi");
    }

    public void PlayZzz()
    {
        Play("zzz");
    }
}
