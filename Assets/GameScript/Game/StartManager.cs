using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public GameObject Story1;
    public GameObject Story2;
    public GameObject Story3;
    public GameObject Story4;
    public GameObject Story5;
    public GameObject Instruction;

    public string NextName;
    public string NowSceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadBackgoundStory()
    {

        Story1.SetActive(true);
        //Debug.Log("Story1.active" + Story1.active);
    }


    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(NowSceneName);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            if (Story1.activeSelf.Equals(true))
            {
                Story1.SetActive(false);
                Story2.SetActive(true);
            }
            else if (Story2.activeSelf.Equals(true))
            {
                Story2.SetActive(false);
                Story3.SetActive(true);
            }
            else if (Story3.activeSelf.Equals(true))
            {
                Story3.SetActive(false);
                Story4.SetActive(true);
            }
            else if (Story4.activeSelf.Equals(true))
            {
                Story4.SetActive(false);
                Story5.SetActive(true);
            }
            else if (Story5.activeSelf.Equals(true))
            {
                //Story5.SetActive(false);

                //load next scene
                Time.timeScale = 1;
                SceneManager.LoadScene(NextName);
            }

        }
    }


    public void CheckInstructions()
    {
        Instruction.SetActive(true);
    }

    public void CloseInstructions()
    {
        Instruction.SetActive(false);
    }
}
