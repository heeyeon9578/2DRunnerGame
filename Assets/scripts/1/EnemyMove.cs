using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    //�ൿ��ǥ�� ������ ����
    public int nextMove;
    //�ӷ��� ������ ��
    float moveSpeed = 10f;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Think();
        Invoke("Think", 5);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //�� ������ ����
        rigid.velocity = new Vector2(nextMove* moveSpeed, rigid.velocity.y);

        

        //����üũ
        Vector2 frontVec = new Vector2(rigid.position.x+ nextMove, rigid.position.y);

        //�����ɽ�Ʈ ������� ���� �غ���
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        //�ٴ��� �ִ��� �����ϱ�
        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 5, LayerMask.GetMask("floor"));

        if (rayhit.collider == null)
        {
            Turn();
        }
    }

    //���� �˾Ƽ� �����̵��� ����
    void Think()
    {
        //���� ������ ����
        nextMove = Random.Range(-1, 2);
        float nextThinkTime = Random.Range(2f, 5f);
        //5�ʸ��� �ٽ� ����
        Invoke("Think", nextThinkTime);
        anim.SetInteger("WalkSpeed", nextMove);

    }

    void Turn()
    {
        nextMove *= -1;
        //ĳ���� ������ȯ/ �����̼ǰ��� 180�� �ٲ㼭 ��ȯ
        if (nextMove > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 180.0f));
        }
        else if (nextMove < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 0.0f));
        }
        CancelInvoke();
        Invoke("Think", 2);
    }
}
