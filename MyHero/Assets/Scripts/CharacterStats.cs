using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Health
    public int currentHealth = 100;
    public int maxHealth = 100;
    public bool takesDamage = true;
    public bool takesHealing = false;
    public bool isDead = false;
    //Attack
    public int damage = 50;
    public float attackSpeed = 1f;
    public float attackDelay = 0.5f;

    int incomingDamage;
    public int healAmount = 50;
    float healCD = 0f;

    // Update is called once per frame
    private void Update()
    {
        if (healCD > 0) healCD -= Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && other.gameObject.layer != this.gameObject.layer)
        {
            incomingDamage = other.gameObject.GetComponentInParent<CharacterStats>().damage;
            ReceiveDamage();
        }
    }
        void ReceiveDamage()
    {
        if (!isDead)
        {
            currentHealth -= incomingDamage;
            HUDController.hud.UpdateHP();
            if (currentHealth <= 0)
            {
                isDead = true;
                gameObject.SetActive(false);
            }
        }
    }
    public void ReceiveHeal(int healAmount)
    {
        if(healCD <= 0)
        { 
            currentHealth += healAmount; 
            healCD = 5f;
            if (currentHealth > maxHealth) currentHealth = maxHealth;
            HUDController.hud.UpdateHP();
        }
    }
}
