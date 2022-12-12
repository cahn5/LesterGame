using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

[RequireComponent(typeof(Platformer2DUserControl))]
public class Player : MonoBehaviour
{
	public int fallBoundary = -20;

	private AudioManager audioManager;

	[SerializeField]
	private StatusIndicator statusIndicator;

	[SerializeField]
	private FloatSO dataSO;

	void Start()
	{


		if (statusIndicator == null)
		{
			Debug.LogError("No status indicator referenced on Player");
		}
		else
		{
			statusIndicator.SetHealth(dataSO.CurHealth, dataSO.MaxHealth);
		}

		GameMaster.gm.onToggleUpgradeMenu += OnUpgradeMenuToggle;

		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("PANIC! No audiomanager in scene.");
		}

		//InvokeRepeating("RegenHealth", 1f / stats.healthRegenRate, 1f / stats.healthRegenRate);
	}

	//void regenhealth()
	//{
	//	stats.curhealth += 1;
	//	statusindicator.sethealth(stats.curhealth, stats.maxhealth);
	//}

	void Update()
	{
		if (transform.position.y <= fallBoundary)
			DamagePlayer(9999999);
	}

	void OnUpgradeMenuToggle(bool active)
	{
		GetComponent<Platformer2DUserControl>().enabled = !active;
		Weapon _weapon = GetComponentInChildren<Weapon>();
		if (_weapon != null)
			_weapon.enabled = !active;
	}

	void OnDestroy()
	{
		GameMaster.gm.onToggleUpgradeMenu -= OnUpgradeMenuToggle;
	}

	public void DamagePlayer(int damage)
	{
		dataSO.CurHealth -= damage;

		if (dataSO.CurHealth <= 0)
		{
			//play death sound
			audioManager.PlaySound("DeathSound");

			//kill player
			GameMaster.KillPlayer(this);
		}
		else
		{
			//play damage sound

			audioManager.PlaySound("GruntSound2");
		}

		statusIndicator.SetHealth(dataSO.CurHealth, dataSO.MaxHealth);
	}

}
