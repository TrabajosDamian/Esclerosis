using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton_Template<LevelManager>
{
    public bool BusStop = false;
    public List<GameObject> carsNormalDirectionPrefab;
    public List<GameObject> carsOppositeDirectionPrefab;
    private float freqSpan = 5;
    public GameObject bus133;
    public AudioSource audio;
    void Update()
    {
        if (!audio.isPlaying && !bus133.activeSelf)
        {
            StartCoroutine(WaitBeforeBus133());
        }
    }
    private void Start()
    {
        foreach (var car in carsNormalDirectionPrefab)
        {
            PoolManager.instance.Load(car, 3);
        }

        foreach (var car in carsOppositeDirectionPrefab)
        {
            PoolManager.instance.Load(car, 3);
        }
        StartCoroutine(SpawnCarsNormalDir());
        StartCoroutine(SpawnCarOppositeDir());
    }

    public IEnumerator SpawnCarsNormalDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(freqSpan);
            var go = PoolManager.instance.Spawn(carsNormalDirectionPrefab[Mathf.FloorToInt(Random.value * (carsNormalDirectionPrefab.Count - 1))]);
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, 15f);
        }
    }

    public IEnumerator SpawnCarOppositeDir()
    {
        while (true)
        {
            yield return new WaitForSeconds(freqSpan);
            var go = PoolManager.instance.Spawn(carsOppositeDirectionPrefab[Mathf.FloorToInt(Random.value * (carsOppositeDirectionPrefab.Count - 1))]);
            go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y, -109f);
        }
    }

    public IEnumerator WaitBeforeBus133()
    {
        yield return new WaitForSeconds(35);
        bus133.SetActive(true);
    }
}
