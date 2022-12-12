using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
	public static UpgradeMenu instance;

	[SerializeField]
	private Text damageText;

	[SerializeField]
	private Text cashText;

	[SerializeField]
	private Text healthText;

	[SerializeField]
	private Text damageCostText;

	[SerializeField]
	private Text cashCostText;

	[SerializeField]
	private Text healthCostText;

	[SerializeField]
	private float damageMultiplier = 1.3f;

	[SerializeField]
	private float cashEarningsMultiplier = 1.05f;

	[SerializeField]
	private float upgradeCostMultiplier = 1.05f;

	[SerializeField]
	private int maxHealthAdditive = 10;

	[SerializeField]
	private FloatSO dataSO;

	AudioManager audioManager;
	void OnEnable()
	{
		if (instance == null)
		{
			instance = this;
		}
		UpdateValues();
	}

	public void UpdateValues()
	{
		damageText.text = "DAMAGE: " + dataSO.Damage.ToString();
		float cashIncrease = Mathf.Round((dataSO.CashBonus - 1) * 10000)/100;
		cashText.text = "CASH INCREASE: +" + cashIncrease.ToString() + "%";
		healthText.text = "MAX HEALTH: " + dataSO.MaxHealth.ToString();

		damageCostText.text = "$" + dataSO.DamageUpgradeCost.ToString();
		cashCostText.text = "$" + dataSO.CashUpgradeCost.ToString();
		healthCostText.text = "$" + dataSO.HealthUpgradeCost.ToString();

	}

	public void UpgradeDamage()
	{
		if (dataSO.Money < dataSO.DamageUpgradeCost)
		{
			AudioManager.instance.PlaySound("NoMoney");
			return;
		}


		dataSO.Damage = (int)(dataSO.Damage * damageMultiplier);

		dataSO.Money -= dataSO.DamageUpgradeCost;
		AudioManager.instance.PlaySound("Money");
		dataSO.DamageUpgradeCost = (int)(dataSO.DamageUpgradeCost * upgradeCostMultiplier);
		UpdateValues();
	}

	public void UpgradeCash()
	{
		if (dataSO.Money < dataSO.CashUpgradeCost)
		{
			AudioManager.instance.PlaySound("NoMoney");
			return;
		}


		dataSO.CashBonus = dataSO.CashBonus * cashEarningsMultiplier;

		dataSO.Money -= dataSO.CashUpgradeCost;
		AudioManager.instance.PlaySound("Money");
		dataSO.CashUpgradeCost = (int)(dataSO.CashUpgradeCost * upgradeCostMultiplier);
		UpdateValues();
	}

	public void UpgradeHealth()
	{
		if (dataSO.Money < dataSO.HealthUpgradeCost)
		{
			AudioManager.instance.PlaySound("NoMoney");
			return;
		}


		dataSO.MaxHealth = dataSO.MaxHealth + maxHealthAdditive;

		dataSO.Money -= dataSO.HealthUpgradeCost;
		AudioManager.instance.PlaySound("Money");
		dataSO.HealthUpgradeCost = (int)(dataSO.HealthUpgradeCost * upgradeCostMultiplier);
		UpdateValues();
	}

	//public void UpgradeSpeed()
	//{
	//	stats.movementSpeed = Mathf.Round(stats.movementSpeed * cashEarningsMultiplier);
	//	UpdateValues();
	//}

}
