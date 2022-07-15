using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour
{
    [Header("Controler")]
    public Entity entity = new Entity();
    public GameManager manager;

    [Header("Patrol")]
    public Transform[] waypointlist;
    public float arrivalDistance = 0.5f;
    public float waitTime = 5f;

    //privates
    Transform targetWayPoint;
    int currentWayPoint = 0;
    float lastDistanceToTrarget = 0f;
    float currentWaitTime = 0f;

    [Header("Experience Reward")]
    public int rewardExperencie = 10;
    public int lootGoldMin = 0;
    public int lootGoldMax = 100;

    [Header("Respawn")]
    public GameObject prefab;
    public bool respawn = true;
    public float respawnTime = 10f;

    Rigidbody2D rb2D;
    Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        entity.maxHealth = manager.CalculateHealt(entity);
        entity.maxMana = manager.CalculateMana(entity);
        entity.maxStamina = manager.CalculateStamina(entity);

        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;
        entity.currentStamina = entity.maxStamina;

        currentWaitTime = waitTime;
        if(waypointlist.Length > 0)
        {
            targetWayPoint = waypointlist[currentWayPoint];
            lastDistanceToTrarget = Vector2.Distance(transform.position, targetWayPoint.position);
        }
    }

}

