using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnBus : MonoBehaviour
{
	public AudioSource audio;
	public AudioClip busStopAudio;
	private bool audioAlreadyPlayed = false;
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !audioAlreadyPlayed)
		{
			audio.Stop();
			audio.PlayOneShot(busStopAudio);
			audioAlreadyPlayed = true;
		}
	}
}
