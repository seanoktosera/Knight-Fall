using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;
    private bool isDead = false;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // udah mati, gak bisa diserang lagi

        currentHP -= damage;
        Debug.Log("Skeleton kena hit! Sisa HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(HitReaction());
        }
    }

    IEnumerator HitReaction()
    {
        anim.SetTrigger("Hit");

        // Tunggu durasi animasi Hit (misalnya 0.6 detik)
        yield return new WaitForSeconds(0.6f);

        // Lanjut ke serang lagi
        anim.SetTrigger("isAttack");
    }

    void Die()
    {
        isDead = true;
        anim.SetTrigger("Die"); // pastikan ada parameter trigger "Die" di animator

        // Matikan collider biar gak ke-trigger lagi
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        // Matikan script AI / gerakan kalau ada
        MonoBehaviour[] allScripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in allScripts)
        {
            if (script != this) script.enabled = false;
        }

        // Hapus dari scene setelah beberapa detik
        Destroy(gameObject, 5f);
    }

    public void OnDeathAnimationEnd()
    {
        FindObjectOfType<WinManager>().ShowWinScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
