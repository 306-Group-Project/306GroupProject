using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource windMillDestroyed;

    public AudioSource coinCollected;

    public AudioSource menuSwitch;

    public AudioSource confirmPlant;

    public AudioSource confirmUpgrade;

    public void playCoinSound()
    {
        coinCollected.Play();
    }

    public void playWindmillDestroyed()
    {
        windMillDestroyed.Play();
    }

    public void playMenuSwitch()
    {
        menuSwitch.Play();
    }

    public void playConfirmPlant()
    {
        confirmPlant.Play();
    }

    public void playConfirmUpgrade()
    {
        confirmUpgrade.Play();
    }
    
}
