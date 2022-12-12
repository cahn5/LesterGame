using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	[SerializeField]
	private FloatSO dataSO;

	public float fireRate = 0;
	public static Weapon instance;
	public int Damage;
	public LayerMask whatToHit;
	
	public Transform ArrowPrefab;
	float timeToSpawnEffect = 0;
	public float effectSpawnRate = 10;
	
	float timeToFire = 0;
	Transform firePoint;

	AudioManager audioManager;

	// Use this for initialization
	void Awake () {
		firePoint = transform.Find ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
		if (instance == null)
		{
			instance = this;
		}
		audioManager = AudioManager.instance;
		if (audioManager == null)
		{
			Debug.LogError("No audiomanager found!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire2")) {
				Shoot();
			}
		}
		else {
			if (Input.GetButton ("Fire2") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}

	//void Shoot () {
	//	Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
	//	Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
	//	RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);

	//	Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
	//	if (hit.collider != null) {
	//		Debug.DrawLine (firePointPosition, hit.point, Color.red);

	//		Enemy enemy = hit.collider.GetComponent<Enemy>();
	//		if (enemy != null)
	//           {
	//			enemy.DamageEnemy(dataSO.Damage);
	//			Debug.Log("We hit " + hit.collider.name + " and did " + dataSO.Damage + " damage.");
	//		}
	//	}

	//	if (Time.time >= timeToSpawnEffect)
	//	{
	//		Vector3 hitPos;
	//		Vector3 hitNormal;

	//		if (hit.collider == null)
	//		{
	//			hitPos = (mousePosition - firePointPosition) * 30;
	//			hitNormal = new Vector3(9999, 9999, 9999);
	//		}
	//		else
	//		{
	//			hitPos = hit.point;
	//			hitNormal = hit.normal;
	//		}

	//		Effect(hitPos, hitNormal);
	//		timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
	//	}
	//}

	void Shoot()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePoint.position, mousePosition - (Vector2)firePoint.position, 5000, whatToHit);

		Debug.DrawLine(firePoint.position, mousePosition, Color.cyan,0.1f);
		if (hit.collider != null)
		{
			Debug.DrawLine(firePointPosition, hit.point, Color.red);

			Enemy enemy = hit.collider.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.DamageEnemy(dataSO.Damage);
				Debug.Log("We hit " + hit.collider.name + " and did " + dataSO.Damage + " damage.");
			}
		}

		if (Time.time >= timeToSpawnEffect)
		{
			Vector3 hitPos;
			Vector3 hitNormal;

			if (hit.collider == null)
			{
				hitPos = mousePosition;
				hitNormal = new Vector3(9999, 9999, 9999);
			}
			else
			{
				hitPos = hit.point;
				hitNormal = hit.normal;
			}

			Effect(hitPos, hitNormal);
			timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
		}
		audioManager.PlaySound("Shot");
	}

	void Effect (Vector3 hitPos, Vector3 hitNormal) {
		Transform trail = Instantiate(ArrowPrefab, firePoint.position, firePoint.rotation) as Transform;
		LineRenderer lr = trail.GetComponent<LineRenderer>();
		
		if (lr != null)
		{
			lr.SetPosition(0, firePoint.position);
			lr.SetPosition(1, hitPos);
		}

		Destroy(trail.gameObject, 0.1f);

		
	}
}
