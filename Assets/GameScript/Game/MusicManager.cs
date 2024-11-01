using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    public AudioSource Level2BGMBeep;
    public AudioSource Level1BGMBeep;
    public AudioSource StartBGMBeep;
    public GameObject on;
    public GameObject off;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ClickOnBGM()
    {
        //Level2BGMBeep.Stop();
        on.SetActive(false);
        off.SetActive(true);
    }

    public void ClickOffBGM()
    {
        //Level2BGMBeep.Stop();
        on.SetActive(true);
        off.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
