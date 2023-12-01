using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource windMillDestroyed;

    public AudioSource coinCollected;

    public AudioSource menuSwitch;

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
}
