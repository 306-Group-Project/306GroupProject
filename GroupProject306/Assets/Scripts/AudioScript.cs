using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource windMillDestroyed;

    public AudioSource coinCollected;

    public void playCoinSound()
    {
        coinCollected.Play();
    }

    public void playWindmillDestroyed()
    {
        windMillDestroyed.Play();
    }
}
