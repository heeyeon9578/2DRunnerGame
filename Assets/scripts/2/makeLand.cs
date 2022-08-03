using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeLand : MonoBehaviour
{
    public float timeDiff;
    float timer = 0;
    public GameObject Land;
    public GameObject spike;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeDiff)
        {
            //Land생성(그냥 instantiate만 할 경우, 매 프레임마다 생성)
            GameObject newLand = Instantiate(Land);
            newLand.transform.position = new Vector3(10,Random.Range(-2.04f, 4.5f),0);
            GameObject newSpike = Instantiate(spike);
            newSpike.transform.position = new Vector3(Random.Range(1, 6), 5, 0);



            timer = 0;
            Destroy(newLand, 10.0f);
            Destroy(newSpike, 10.0f);

        }
        
    }
}
