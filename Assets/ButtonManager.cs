using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

	[SerializeField]
	string hoverOverSound = "ButtonHover";

	[SerializeField]
	string pressButtonSound = "ButtonPress";

	AudioManager audioManager;

	void Start()
	{
		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("No audiomanager found!");
		}
	}


	public void OnMouseOver()
	{
		audioManager.PlaySound(hoverOverSound);
	}

}
