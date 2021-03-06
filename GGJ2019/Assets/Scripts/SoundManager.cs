﻿using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource; //Drag a reference to the audio source which will play the sound effects.
    public AudioSource efxSource_2; //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource; //Drag a reference to the audio source which will play the music.
    public AudioSource musicSource2; //Drag a reference to the audio source which will play the music.
    public AudioClip sfxCollectWood;
    public AudioClip sfxBurnWood;
    public AudioClip sfxHighScore;
    public static SoundManager instance = null; //Allows other scripts to call functions from SoundManager.             
    public float lowPitchRange = .95f; //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f; //The highest a sound effect will be randomly pitched.


    private void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic()
    {
        if (musicSource2.isPlaying)
        {
            musicSource2.Pause();
        }

        if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void TurnOffMusic()
    {
        musicSource.Stop();
    }

    public void PlayMusic_intense()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
        }

        if (!musicSource2.isPlaying)
        {
            musicSource2.Play();
        }
    }

    public void TurnOffMusic_intense()
    {
        musicSource2.Stop();
    }

    public void Play_CollectWood()
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = sfxCollectWood;

        //Play the clip.
        efxSource.Play();
    }

    public void Play_HighScore()
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = sfxHighScore;

        //Play the clip.
        efxSource.Play();
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

    //Used to play single sound clips.
    public void PlaySingle_2(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource_2.clip = clip;

        //Play the clip.
        efxSource_2.Play();
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }

}

//IEnumerator FadeOutIntenseMusic()
    //{
    //    while (musicSource2.volume > 0)
    //    {
    //        musicSource2.volume -= 1 * Time.deltaTime / 5;
    //        yield return null;
    //    }
    //    musicSource2.Stop();
    //}