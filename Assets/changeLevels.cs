using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevels : MonoBehaviour
{
    [SerializeField]
    private string SceneName = "MainMenu";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Character")
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
