using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public bool isDead = false;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
    }

    void UpdateHPText()
    {
        hpText.text = "HP: " + currentHP;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPText();

        if (currentHP <= 0)
        {
            Die();
            Debug.Log("GAME OVER");
            // nanti bisa kamu ganti ke GameOver UI
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Knight mati!");
        GetComponent<Animator>().SetTrigger("Die"); // pastikan animator Knight punya trigger "Die"

        GetComponent<Knight>().enabled = false;
    }

    public void OnDeathAnimationEnd()
    {
        FindObjectOfType<GameOverManager>().ShowGameOver();
    }

    public void Heal(int heal)
    {
        currentHP += heal;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
