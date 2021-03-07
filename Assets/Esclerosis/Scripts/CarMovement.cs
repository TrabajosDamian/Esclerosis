using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool normalDirection = true;
    private bool busStoped = false;
    public AudioClip audioBusUp;
    public AudioClip audioBusFailed;
    public AudioSource audioSource;
    private bool playAudioFailed = false;
    private bool transition = false;
    void Update()
    {
        if (name == "Bus_133")
        {
            if (transform.position.z < -63.5f && transform.position.z > -64.5f && LevelManager.instance.BusStop && !busStoped)
            {
                busStoped = true;
                audioSource.Stop();
                audioSource.PlayOneShot(audioBusUp);
            }
            else if (!busStoped)
            {
                CarMove();
                if (transform.position.z < -73f && !playAudioFailed)
                {
                    playAudioFailed = true;
                    audioSource.Stop();
                    audioSource.PlayOneShot(audioBusFailed);
                }
            }

            if (LevelManager.instance.BusStop && busStoped && !transition)
            {
                GlobalManager.instance.fadeOut("WaitingRoom");
            }
            else if (playAudioFailed && !audioSource.isPlaying && !transition)
            {
                transition = true;
                GlobalManager.instance.fadeOut("Park");
            }

        }
        else
        {
            CarMove();
        }
        DesactiveCar();
    }

    private void CarMove()
    {
        if (normalDirection)
        {
            this.gameObject.transform.position = new Vector3(
    this.gameObject.transform.position.x,
    this.gameObject.transform.position.y,
    this.gameObject.transform.position.z - 0.03f);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(
    this.gameObject.transform.position.x,
    this.gameObject.transform.position.y,
    this.gameObject.transform.position.z + 0.03f);
        }
    }

    private void DesactiveCar()
    {
        if (transform.position.z < -115f || transform.position.z > 23f)
        {
            PoolManager.instance.Despawn(this.gameObject);
        }
    }


}
