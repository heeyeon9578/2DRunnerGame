using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    //static���� �����ؾ� �ܺο����� �����ؼ� ����� �� ����.
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
