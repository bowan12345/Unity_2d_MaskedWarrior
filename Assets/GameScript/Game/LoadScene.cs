using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    public string SceneName;

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
