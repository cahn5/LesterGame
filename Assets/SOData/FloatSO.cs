using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float _value;

    [SerializeField]
    private int _damage = 10;

    [SerializeField]
    private int _curHealth = 100;

    [SerializeField]
    private int _maxHealth = 100;

    [SerializeField]
    private float _cashBonus = 1.0f;

    [SerializeField]
    private int _lives = 1;

    [SerializeField]
    private int _money = 0;

    [SerializeField]
    private int _damageUpgradeCost = 100;

    [SerializeField]
    private int _cashUpgradeCost = 100;

    [SerializeField]
    private int _healthUpgradeCost = 100;

    public float Value
    {
        get{ return _value; }
        set{ _value = value; }
    }

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public int CurHealth
    {
        get { return _curHealth; }
        set { _curHealth = _curHealth = Mathf.Clamp(value, 0, MaxHealth); ; }
    }
    public int MaxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }
    public float CashBonus
    {
        get { return _cashBonus; }
        set { _cashBonus = value; }
    }
    public int Lives
    {
        get { return _lives; }
        set { _lives = value; }
    }
    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }
    public int DamageUpgradeCost
    {
        get { return _damageUpgradeCost; }
        set { _damageUpgradeCost = value; }
    }
    public int CashUpgradeCost
    {
        get { return _cashUpgradeCost; }
        set { _cashUpgradeCost = value; }
    }
    public int HealthUpgradeCost
    {
        get { return _healthUpgradeCost; }
        set { _healthUpgradeCost = value; }
    }


}
