using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    //static으로 지정해야 외부에서도 접근해서 사용할 수 있음.
     public static int Score = 0;
    public static int bestScore = 0;

    void Start()
    {
        Score = 0;
    }

    
    void Update()
    {
        GetComponent<Text>().text = "score: "+Score.ToString();
    }
}
