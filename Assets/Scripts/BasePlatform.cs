using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlatform : MonoBehaviour
{
    public GameObject Platform;
    public Transform LastPlatfrom;

    Vector3 lastPos;
    Vector3 newPos;

    private bool stop;

    private void Start()
    {
        lastPos = LastPlatfrom.position;
        StartCoroutine(spawnPrefab());
    }

    void GeneratePos()
    {
        newPos = lastPos;
        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }       
    }
    IEnumerator spawnPrefab()
    {
        while (!stop)
        {
            GeneratePos();
            lastPos = newPos;
            GameObject platform = Instantiate(Platform, newPos, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);   
        }
    }

}
