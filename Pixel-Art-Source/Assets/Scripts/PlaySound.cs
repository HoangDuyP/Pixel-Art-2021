using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource JumpSound;
    public AudioClip Sound;
    public void PlayWhenClick()
    {
        JumpSound.PlayOneShot(Sound);
    }
}
