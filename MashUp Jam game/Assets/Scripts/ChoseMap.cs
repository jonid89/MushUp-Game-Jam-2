using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseMap : MonoBehaviour
{


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ChooseSquareMap() { GetComponent<RectTransform>().localPosition = new Vector3(-140,-10,0); }
    public void ChooseHexagonMap() { GetComponent<RectTransform>().localPosition = new Vector3(-0, -10, 0); }
    public void ChooseHourglassMap() { GetComponent<RectTransform>().localPosition = new Vector3(140, -10, 0); }
}
