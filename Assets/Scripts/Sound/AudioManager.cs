using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public float fadeTime = 5f;

    [Header("Liste De Sons")]
    public SoundClass[] sounds;

    public IEnumerator FadeInMusicGame;
    public IEnumerator FadeOutMusicMenu;
    public IEnumerator FadeOutPeopleEntry;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (SoundClass s in sounds)
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
        FadeInMusicGame = FadeIn(sounds[2], fadeTime);
        FadeOutMusicMenu = FadeOut(sounds[0], fadeTime);
        FadeOutPeopleEntry = FadeOut(sounds[1], fadeTime);

        PlaySound("MusiqueMenu");
    }

    public void PlaySound(string name)
    {
        SoundClass s = Array.Find(sounds, SoundClass => SoundClass.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StartCoroutineFadeOutMenuSound()
    {
        StartCoroutine(FadeOutMusicMenu); //Musique nom : MusiqueMenu
        PlaySound("PeopleEntry");
        StartCoroutine(FadeOutPeopleEntry); //Musique nom : PeopleEntry
        PlaySound("MusiqueGame");
        StartCoroutine(FadeInMusicGame); //Musique nom : MusiqueGame
    }

    public IEnumerator FadeIn(SoundClass soundClass, float FadeTime)
    {
        //float startVolume = soundClass.source.volume;

        while (soundClass.source.volume < .5f)
        {
            soundClass.source.volume += Time.deltaTime / FadeTime;
            yield return null;
        }

    }

    public IEnumerator FadeOut(SoundClass soundClass, float FadeTime)
    {
        float startVolume = soundClass.source.volume;

        while (soundClass.source.volume > 0)
        {
            soundClass.source.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        soundClass.source.Stop();
        soundClass.source.volume = startVolume;
    }

}
