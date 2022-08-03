using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float jumpPower=10f;
    float moveSpeed = 10f;
    Rigidbody2D rigid;
    Animator anim;
    public GameObject canvas;
     void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        //수평값 입력 받기
        float h = Input.GetAxis("Horizontal");

        //캐릭터 좌우로 움직이기, -3.0f로 바꿔줘야 더 점프 후 빨리 떨어짐
        rigid.velocity = new Vector2(h * moveSpeed, rigid.velocity.y) ;

        //캐릭터 방향전환/ 로테이션값을 180도 바꿔서 전환
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 180.0f));
        }else if(h > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 0.0f));
        }

        //캐릭터 애니메이션 - 뛰기(걷기)
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        //캐릭터 애니메이션 - 점프
        if (Input.GetButton("Jump")&& !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);


        }


    }
    private void FixedUpdate()
    {
        //점프 후 바닥 탐지
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("floor"));
            if (rayhit.collider != null)
            {
                anim.SetBool("isJumping", false);
            }
        }
        
        //카메라가 플레이어를 따라가도록 구현
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("플레이어가 적에게 맞았습니다.");
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("gameover"))
        {
            Debug.Log("플레이어가 추락하였습니다.");
            canvas.SetActive(true);
        }
    }
}
