using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public bool isHit = true;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knight"))
        {
            if (isHit)
            {
                isHit = false;
                Debug.Log("hero hit");

                anim.SetTrigger("isAttack");

                PlayerHealthUI hp = other.GetComponent<PlayerHealthUI>();
                if (hp != null)
                {
                    hp.TakeDamage(20); // atur damage sesuka kamu
                }

                StartCoroutine(delayHit());
            }


        }
    }

    IEnumerator delayHit()
    {
        yield return new WaitForSeconds(2f);
        isHit = true;
    }
}
