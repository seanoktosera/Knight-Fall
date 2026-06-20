using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHitbox : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Knight kena musuh!");
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(40); // sesuaikan damage
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
