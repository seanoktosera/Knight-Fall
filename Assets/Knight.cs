using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knight : MonoBehaviour
{
    float comboAtk = 0f;
    float lastAtk = 0;
    public static GameManager Instance { get; private set; }

    [SerializeField] Vector3 maju = Vector3.zero;
    [SerializeField] float kecepatan = 3f;
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 5f;
    public Transform cameraTransform;

    public GameObject attackHitbox;

    public void EnableHitbox() => attackHitbox.SetActive(true);
    public void DisableHitbox() => attackHitbox.SetActive(false);

    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        PlayerHealthUI health = GetComponent<PlayerHealthUI>();
        if (health != null && health.isDead)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float moveMagnitude = new Vector2(h, v).magnitude;

        anim.SetBool("isWalking", moveMagnitude > 0.1f);

        //putaran berdasarkan posisi camera
        if (h != 0 || v != 0)
        {
            Vector3 targetDirection = new Vector3(h, 0f, v);
            targetDirection = cameraTransform.TransformDirection(targetDirection);
            targetDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            this.transform.rotation = targetRotation;


            //pergerakan berdasarkan posisi camera
            // --- pergerakan berdasarkan posisi camera dengan Raycast anti tembus ---
            Vector3 moveDir =
                Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up) * v +
                Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up) * h;

            float moveDistance = kecepatan * Time.deltaTime;

            // Raycast dari posisi Knight ke arah gerak
            if (!Physics.Raycast(transform.position + Vector3.up * 0.5f, moveDir.normalized, moveDistance + 0.1f))
            {
                this.transform.position += moveDir * moveDistance;
            }

            this.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isWalking", false);
        }

        //Lompat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJump", true);
        }

        //serang 
        if (Input.GetButtonDown("Fire1"))
        {
            lastAtk = Time.time;
            comboAtk++;
            comboAtk = Mathf.Clamp(comboAtk, 0, 3);
            this.GetComponent<Animator>().SetFloat("isAttack", comboAtk);
        }

        //reset serang 
        if (Time.time - lastAtk >= 1f)
        {
            comboAtk = 0;
            Debug.Log("masuk " + comboAtk);
            this.GetComponent<Animator>().SetFloat("isAttack", comboAtk);
        }


        rb.position = transform.position;
    }

    public void reset_lompat()
    {
        anim.SetBool("isJump", false);
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("walkable"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("walkable"))
            isGrounded = false;
    }
}
