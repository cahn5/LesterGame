using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{
	public static GameMaster gm;

	[SerializeField]
	private int maxLives = 3;

	[SerializeField]
	private FloatSO dataSO;

	[SerializeField]
	private UpgradeMenu menu;

	[SerializeField]
	private bool allowUpgrade;

	void Awake()
	{
		if (gm == null)
		{
			gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
			
		}
		menu.UpdateValues();
		dataSO.CurHealth = dataSO.MaxHealth;
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public float spawnDelay = 2;
	public Transform spawnPrefab;
	public string respawnCountdownSoundName = "RespawnCountdown";
	public string spawnSoundName = "Spawn";

	public string gameOverSoundName = "GameOver";

	//public CameraShake cameraShake;

	[SerializeField]
	private GameObject gameOverUI;

	[SerializeField]
	private GameObject upgradeMenu;

	//[SerializeField]
	//private WaveSpawner waveSpawner;

	public delegate void UpgradeMenuCallback(bool active);
	public UpgradeMenuCallback onToggleUpgradeMenu;

	//cache
	private AudioManager audioManager;

	void Start()
	{
        //if (cameraShake == null)
        //{
        //	Debug.LogError("No camera shake referenced in GameMaster");
        //}

        //caching
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("FREAK OUT! No AudioManager found in the scene.");
        }

    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && allowUpgrade == true)
		{
			ToggleUpgradeMenu();
		}
	}

	private void ToggleUpgradeMenu()
	{
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
		//waveSpawner.enabled = !upgradeMenu.activeSelf;
		onToggleUpgradeMenu.Invoke(upgradeMenu.activeSelf);
	}

	public void EndGame()
	{
		//audioManager.PlaySound(gameOverSoundName);

		Debug.Log("GAME OVER");
		gameOverUI.SetActive(true);
	}

	public IEnumerator _RespawnPlayer()
	{
		//audioManager.PlaySound(respawnCountdownSoundName);
		yield return new WaitForSeconds(spawnDelay);

		audioManager.PlaySound("Spawn");
		Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
		Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
		Destroy(clone.gameObject, 3f);
	}

	public static void KillPlayer(Player player)
	{
		Destroy(player.gameObject);

		gm.EndGame();

	}

	public static void KillEnemy(Enemy enemy)
	{
		gm._KillEnemy(enemy);
	}
	public void _KillEnemy(Enemy _enemy)
	{
		// Let's play some sound
		//audioManager.PlaySound(_enemy.deathSoundName);

		string enemyname = _enemy.name;
		// Gain some money
		dataSO.Money += (int)(_enemy.moneyDrop * dataSO.CashBonus);
        //audiomanager.playsound("money");

        // Add particles
        //GameObject _clone = Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity) as GameObject;
        //Destroy(_clone, 5f);

        // Go camerashake
        //cameraShake.Shake(_enemy.shakeAmt, _enemy.shakeLength);
        Destroy(_enemy.gameObject);
		if (enemyname.Contains("Bat"))
		{
			audioManager.PlaySound("BatDeath");
		}
		if (enemyname.Contains("Knight"))
		{
			audioManager.PlaySound("KnightDeath");
		}
		if (enemyname.Contains("Santa"))
		{
			audioManager.PlaySound("SantaDeath");
		}
	}

}
