using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Datas/Skill", order = 0)]
public class DataSkills : ScriptableObject
{
    [Header("Settings")]
    public float range;
    public float cooldown;
    public float castTime;
    public float repulseForce;
    public float lifeSkill;
    public float speed;
    public float timeSkill;
    [Header("Character")]
    public float damage;
    public float manaCost;
    public float adrenalineCost;
    public float lifeCost;
    [Header("Projectile")]
    public GameObject prefab;
    public int numberProjectile;
}
