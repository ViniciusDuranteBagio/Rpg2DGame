using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Entity entity;

    [Header("Player Regen System")]
    public bool regenHPEnabled = true;
    public float regenHPTime = 5f;
    public int regenHPValue = 5;

    public bool rengenManaEnable = true;
    public float rengenManaTime = 10f;
    public int regenManaValue = 5;

    [Header("Game Manager")]
    public GameManager manager;

    [Header("PLayer UI")]
    public Slider health;
    public Slider mana;
    public Slider stamina;
    public Slider exp;
    void Start()
    {
        if (manager == null)
        {
            Debug.LogError("Você precisa anexar o game manager aqui no player");
            return;
        }

        entity.maxHealth = manager.CalculateHealt(entity);
        entity.maxMana = manager.CalculateMana(entity);
        entity.maxStamina = manager.CalculateStamina(entity);

        int dmg = manager.CalculateDamage(entity, 10); // ser usado no player
        int def = manager.CalculateDefense(entity, 5); //ser usado no inimigo


        entity.currentHealth = entity.maxHealth;
        entity.currentMana = entity.maxMana;
        entity.currentStamina = entity.maxStamina;


        health.maxValue = entity.maxHealth;
        health.value = health.maxValue;

        mana.maxValue = entity.maxMana;
        mana.value = mana.maxValue;

        stamina.maxValue = entity.maxStamina;
        stamina.value = stamina.maxValue;

        exp.value = 0;

        // iniciar regen System
        StartCoroutine(RegenHelth());
        StartCoroutine(RegenMana());
    }

    private void Update()
    {
        health.value = entity.currentHealth;
        mana.value = entity.currentMana;
        stamina.value = entity.currentStamina;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Dano de teste
            entity.currentHealth -= 10;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Skill teste
            entity.currentMana -= 10;
        }
    }

    IEnumerator RegenHelth() 
    {
            while (true)//loop infinito
            {
                if (regenHPEnabled)
                {
                    if (entity.currentHealth < entity.maxHealth)
                    {
                    Debug.LogFormat("Recuperando HP do Jogador");
                        entity.currentHealth += regenHPValue;
                        yield return new WaitForSeconds(regenHPTime);

                    }
                    else
                    {   
                    yield return null;
                    }
                }
                    else
                    {
                    yield return null;
                    }
            } 
    }
    IEnumerator RegenMana()
    {
        while (true)
        {
            if (rengenManaEnable)
            {
                if (entity.currentMana < entity.maxMana)
                {
                    Debug.LogFormat("Recuperando Mana do Jogador");
                    entity.currentMana += regenManaValue;
                    yield return new WaitForSeconds(rengenManaTime);
                }
                else
                {
                    yield return null;
                }
            }
            else
            {
                yield return null;
            }

        }
    }

}
