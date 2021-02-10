using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Datas/Player", order = 1)]
public class DataPlayer : ScriptableObject
{
    [Header("Settings")]
    public float health = 100.0f;
    public float healthMax = 100.0f;
    public float mana = 100.0f;
    public float manaMax = 100.0f;
    public float adrenaline = 100.0f;
    public float adrenalineMax = 100.0f;
    public float invulnerabilityDuration = 2.0f;
    [Header("States")]
    public bool isDead = false;
    public bool isInvulnerable = false;
    [Header("Internal Utility")]
    public const float Min = 0.0f;
}
