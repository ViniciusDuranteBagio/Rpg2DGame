using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //CALCULANDO HP/MANA/STAMINA/DAMAGE/DEFENSE CONFORME OS STATUS DO PERSONAGEM
    public Int32 CalculateHealt(Entity entity)
    {
        //formula (resistencia *10) + (level * 4) + 10
        Int32 result = (entity.resistence * 10) + (entity.level * 4) + 10;
        Debug.LogFormat("CalculateHealth: {0}", result);
        return result;
    }
    public Int32 CalculateMana(Entity entity)
    {
        //formula (inteligence *10) + (level * 4) + 5
        Int32 result = (entity.intelligence * 10) + (entity.level * 4) + 5;
        Debug.LogFormat("CalculateMana: {0}", result);
        return result;
    }
    public Int32 CalculateStamina(Entity entity)
    {
        //formula (resistencia * agility) + (level * 2) + 5;
        Int32 result = (entity.resistence * entity.agility) + (entity.level * 2) + 5;
        Debug.LogFormat("CalculateStamina: {0}", result);
        return result;
    }
    public Int32 CalculateDamage(Entity entity, int weaponDamage)
    {
        System.Random rng = new System.Random();
        //formula (str * 2) + (weapon damage * 2) + (level *3) + ramdom(1-20)
        Int32 result = (entity.strength * 2) + (weaponDamage * 2 )+ (entity.level * 3) + rng.Next(1,20);
        Debug.LogFormat("CalculateDamage: {0}", result);
        return result;
    }

    public Int32 CalculateDefense(Entity entity, int armorDefense)
    {
        //formula (Endurance(defense) * 2) + (armor defense * 2) + (level *3) 
        Int32 result = (entity.resistence * 2) + (armorDefense * 2) + (entity.level * 3);
        Debug.LogFormat("CalculateDefense: {0}", result);
        return result;
    }
}
