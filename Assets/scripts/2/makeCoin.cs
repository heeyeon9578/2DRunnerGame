using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeCoin : MonoBehaviour
{
    public float timeDiff;
    float timer = 0;
    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            //Land����(�׳� instantiate�� �� ���, �� �����Ӹ��� ����)
            GameObject newGold = Instantiate(gold);
            newGold.transform.position = new Vector3(10, Random.Range(-2.04f, 4.5f), 0);
            GameObject newSilver = Instantiate(silver);
            newSilver.transform.position = new Vector3(10, Random.Range(-2.04f, 4.5f), 0);
            GameObject newBronze = Instantiate(bronze);
            newSilver.transform.position = new Vector3(10, Random.Range(-2.04f, 4.5f), 0);

            timer = 0;
            Destroy(newGold, 10.0f);
            Destroy(newSilver, 10.0f);
            Destroy(newBronze, 10.0f); 

        }

    }
}
