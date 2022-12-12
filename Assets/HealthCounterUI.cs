using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthCounterUI : MonoBehaviour
{
	[SerializeField]
	private FloatSO dataSO;

	private Text healthText;

	void Awake()
	{
		healthText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		healthText.text = "HEALTH: " + dataSO.CurHealth.ToString() + "/" + dataSO.MaxHealth.ToString();
	}
}
