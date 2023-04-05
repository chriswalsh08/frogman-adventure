using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("BG Music") != null)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        }

        if ((GameObject.Find("ScoreUI") != null) && (GameObject.Find("Settings Panel") != null))
        {
            GameObject[] objsUI = GameObject.FindGameObjectsWithTag("UI");
        
            if (objsUI.Length > 1)
            {
                Destroy(this.gameObject);
            }
        
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
