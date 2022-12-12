using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
	[SerializeField]
	private string SceneName = "MainMenu";
	AudioManager audioManager;

	void Start()
	{
		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("FREAK OUT! No AudioManager found in the scene.");
		}
	}
	public void Quit()
	{
		audioManager.PlaySound("ButtonPress");
		Debug.Log("APPLICATION QUIT!");
		Application.Quit();
	}

	public void Retry()
	{
		audioManager.PlaySound("ButtonPress");
		SceneManager.LoadScene(SceneName);
	}
	public void OnMouseOver()
	{
		audioManager.PlaySound("ButtonHover");
	}
}
