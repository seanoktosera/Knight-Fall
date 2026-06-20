using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float turnSpeed = 4.0f;
    private Transform posHero;
    private Vector3 offset;

    [SerializeField] private float minDistance = 2.0f;  // jarak minimum kamera
    [SerializeField] private float maxDistance = 8.0f;  // jarak maksimum kamera
    [SerializeField] private float zoomSpeed = 2.0f;

    void Start()
    {
        posHero = GameObject.FindGameObjectWithTag("Knight").transform.Find("char_point_cam").transform;
        offset = new Vector3(posHero.localPosition.x, posHero.localPosition.y, posHero.localPosition.z-3.2f);
    }

    private void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        offset = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offset;


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            // ubah panjang offset (jarak kamera ke hero)
            float distance = offset.magnitude;
            distance -= scroll * zoomSpeed;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);

            offset = offset.normalized * distance;
        }

        transform.position = posHero.position + offset;
        transform.LookAt(posHero.position);
    }
}