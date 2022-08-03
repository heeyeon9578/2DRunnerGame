using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove2 : MonoBehaviour
{
    Rigidbody2D rigid;
    //�ൿ��ǥ�� ������ ����
    public int nextMove=-1;
    //�ӷ��� ������ ��
    float moveSpeed = 5f;
    Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("WalkSpeed", nextMove);

    }
    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime; // -1,0,0 
    }

}
