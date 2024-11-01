using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManger : MonoBehaviour
{
    //public string NowSceneName;
    //public string NextName;
    public GameObject EndStory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            if (EndStory.activeSelf.Equals(true))
            {
                //load next scene
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }

        }
    }
}
