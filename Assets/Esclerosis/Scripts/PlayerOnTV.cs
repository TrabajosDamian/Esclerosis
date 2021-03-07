using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTV : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip tvAudio;
    public AudioClip finalAudio;
    public Animator animatorScreen;
    private bool audioAlreadyPlayed = false;
    private bool audioFinalPlayed = false;

    private void Update()
    {
        if (audioFinalPlayed && !audio.isPlaying)
            GlobalManager.instance.fadeOut("House");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !audioAlreadyPlayed)
        {
            audio.Stop();
            audio.PlayOneShot(tvAudio);
            audioAlreadyPlayed = true;
            animatorScreen.SetBool("grab", true);
            StartCoroutine(WaitBeforeFinal());
        }
    }

    IEnumerator WaitBeforeFinal()
    {
        yield return new WaitForSeconds(60);
        audio.Stop();
        audio.PlayOneShot(finalAudio);
        audioFinalPlayed = true;
    }
}
