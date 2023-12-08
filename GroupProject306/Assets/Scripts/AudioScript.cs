using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource windMillDestroyed;
    public AudioSource coinCollected;
    public AudioSource menuSwitch;
    public AudioSource insufficientFunds;
    public AudioSource confirmPlant;
    public AudioSource confirmUpgrade;
	public AudioSource backgroundMusic; 

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

    public void playInsufficentFunds()
    {
        insufficientFunds.Play();
    }

    public void playConfirmPlant()
    {
        confirmPlant.Play();
    }

    public void playConfirmUpgrade()
    {
        confirmUpgrade.Play();
    }

	public void playBackgroundMusic()
	{
		backgroundMusic.Play();
	}

    
}
