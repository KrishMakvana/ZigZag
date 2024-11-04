using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    Vector3 distance;
    public float speed;
    [SerializeField]
    [Range(0f, 1f)] float lerpTime;

    [SerializeField]
    Color[] myColor;

    int colorIndex = 0; 
    float change = 0f;
    int len;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        distance = target.position - transform.position;
        len = myColor.Length;
    }
    private void Update()
    {
        if(target.position.y >= 0)
            follow();

        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, myColor[colorIndex],lerpTime*Time.deltaTime);
        change = Mathf.Lerp(change,1f,lerpTime*Time.deltaTime); 
        if(change > 0.9f)
        {
            change = 0f;
            colorIndex++;
            colorIndex = (colorIndex>=len)? 0: colorIndex;
        }
    }
    void follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos,targetPos,speed*Time.deltaTime);
    }
}
