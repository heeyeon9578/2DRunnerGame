using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    //행동지표를 결정할 변수
    public int nextMove;
    //속력을 높여줄 값
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

        //적 움직임 구현
        rigid.velocity = new Vector2(nextMove* moveSpeed, rigid.velocity.y);

        

        //지형체크
        Vector2 frontVec = new Vector2(rigid.position.x+ nextMove, rigid.position.y);

        //레이케스트 녹색으로 감지 해보기
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));

        //바닥이 있는지 감지하기
        RaycastHit2D rayhit = Physics2D.Raycast(frontVec, Vector3.down, 5, LayerMask.GetMask("floor"));

        if (rayhit.collider == null)
        {
            Turn();
        }
    }

    //적이 알아서 움직이도록 구현
    void Think()
    {
        //다음 동작을 결정
        nextMove = Random.Range(-1, 2);
        float nextThinkTime = Random.Range(2f, 5f);
        //5초마다 다시 실행
        Invoke("Think", nextThinkTime);
        anim.SetInteger("WalkSpeed", nextMove);

    }

    void Turn()
    {
        nextMove *= -1;
        //캐릭터 방향전환/ 로테이션값을 180도 바꿔서 전환
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
