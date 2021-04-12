using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalTimer : MonoBehaviour
{
    public GameObject timeDisplay1;
    public GameObject timeDisplay2;
    public bool isTakingTime = false;
    public int theSeconds = 150;
    public static int extendScore;

    void Update()
    {
        extendScore = theSeconds;
       if(isTakingTime == false)
        {
            StartCoroutine(SubtractSecond());
        }
    }
    IEnumerator SubtractSecond()
    {
        isTakingTime = true;
        theSeconds -= 1;
        timeDisplay1.GetComponent<Text>().text = "" + theSeconds;
        timeDisplay2.GetComponent<Text>().text = "" + theSeconds;
        yield return new WaitForSeconds(1);
        isTakingTime = false;
    }
}
