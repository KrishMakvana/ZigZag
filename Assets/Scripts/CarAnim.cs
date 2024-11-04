using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnim : MonoBehaviour
{
    [SerializeField]
    Vector3 finalPos;

    Vector3 initialPos;

    private void Awake()
    {
        initialPos = transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPos, 0.2f);
        transform.Rotate( new Vector3(0f,20f,0f) * Time.deltaTime);
    }

    private void OnDisable()
    {
        transform.position = initialPos;
        transform.rotation = Quaternion.Euler(0f,180f,0f);   
    }
}
