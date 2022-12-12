using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyCounterUI : MonoBehaviour
{
	[SerializeField]
	private FloatSO dataSO;

	private Text moneyText;

	void Awake()
	{
		moneyText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		moneyText.text = "MONEY: " + dataSO.Money.ToString();
	}
}
