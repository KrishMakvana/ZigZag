using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class CarController : MonoBehaviour
{
    public float speed = 10f;
    bool faceLeft, fackTab;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (GameManager.Instance.isStarted)
        {
            Move();
            checkInput();

        }
        if(transform.position.y <= -2)
        {
            GameManager.Instance.GameOver();
        }
    }
    private void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }
    void ChangeDirection()
    {
        if (faceLeft )
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
