using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectCar : MonoBehaviour
{
    [SerializeField]
    Button prevBnt;

    [SerializeField]
    Button nextBnt;

    [SerializeField]
    Button useBnt;


    int currentCar;
    string ownCarIndex;

    Color redColor = new Color(1f, 0.1f, 0.1f, 1f);
    Color greenColor = new Color(0.5f, 1f, 0.4f, 1f);

    private void Awake()
    {
        ChangeCar(0);
    }
    void ChooseCar(int _index)
    {
        prevBnt.interactable = (_index != 0);
        nextBnt.interactable= (_index != transform.childCount -1 );
        for (int i = 0; i < transform.childCount; i++) 
        {
            string carNo = "carNo" + i;
            if (i == _index)
            {
                PlayerPrefs.SetInt(carNo, 1);
            }
            else
            {
                PlayerPrefs.SetInt(carNo, 0);
            }
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }
    public void ChangeCar(int _change)
    {
        currentCar += _change;

        ChooseCar(currentCar);
        ownCarIndex ="carNo" + currentCar;
        Debug.Log("current car " + currentCar);
        if (PlayerPrefs.GetInt(ownCarIndex) == 1)
        {
            useBnt.GetComponent<Image>().color = greenColor;
            useBnt.GetComponentInChildren<Text>().text = "SELECT";
        }
    }

    public void useBntClick()
    {
        if (PlayerPrefs.GetInt(ownCarIndex) == 1)
        {
            
            PlayerPrefs.SetInt("SelectCar", currentCar);
            SceneManager.LoadScene("Level");
        }
    }
}
