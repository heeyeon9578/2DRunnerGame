using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeEnemy : MonoBehaviour
{
    public float timeDiff;
    float timer = 0;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            //Land생성(그냥 instantiate만 할 경우, 매 프레임마다 생성)
            GameObject newEnemy = Instantiate(enemy);
            newEnemy.transform.position = new Vector3(Random.Range(1,6), 5, 0);
            timer = 0;
            Destroy(newEnemy, 10.0f);
        }
    }
}
