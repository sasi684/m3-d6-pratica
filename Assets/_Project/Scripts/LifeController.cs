using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp = 100;

    public int GetHp() => _hp;
    public void SetHp(int hp) => _hp = hp < 0 ? 0 : hp;
    public void AddHp(int amount) => SetHp(_hp + amount);
}
