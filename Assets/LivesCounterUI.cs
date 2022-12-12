using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesCounterUI : MonoBehaviour
{
	[SerializeField]
	private FloatSO dataSO;

	private Text livesText;

	void Awake()
	{
		livesText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		livesText.text = "LIVES: " + dataSO.Lives.ToString();
	}
}
