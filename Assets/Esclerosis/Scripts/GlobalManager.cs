using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalManager : Singleton_Template<GlobalManager>
{
    public OVRScreenFade ovrScreen;
    public string nextScene;
    public float time = 2400f;
    

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 0;
        }
    }
    public void fadeOut(string scene)
    {
        ovrScreen.fadeTime = 5f;
        ovrScreen.FadeOut();
        StartCoroutine(LoadScene(scene));
        
    }

    public IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene(scene);
    }

}
