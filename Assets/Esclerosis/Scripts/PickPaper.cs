using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPaper : MonoBehaviour
{
    public OpenDoor openDoor;
    public AudioSource audio;
    public GameObject paper;
    public AudioClip afterPaperAudio;
    private bool gameObjectActive = false;
    void Update()
    {
        if (!audio.isPlaying && !gameObjectActive)
        {
            gameObjectActive = true;
            paper.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.name == "RightHandAnchor" || other.name == "LeftHandAnchor") && !openDoor.pickedPaper)
        {
            StartCoroutine(pickedPaperTrue());
            audio.PlayOneShot(afterPaperAudio);
        }
    }

    private IEnumerator pickedPaperTrue()
    {
        yield return new WaitForSeconds(3);

        gameObject.SetActive(false);
        openDoor.pickedPaper = true;
    }
}
