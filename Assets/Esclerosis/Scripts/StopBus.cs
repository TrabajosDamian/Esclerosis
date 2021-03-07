using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBus : MonoBehaviour
{
    [SerializeField]
    private GameObject ligths;

    private void OnTriggerEnter(Collider other)
    {
        LevelManager.instance.BusStop = true;
        ligths.SetActive(true);
    }
}
