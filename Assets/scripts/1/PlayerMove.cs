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
        //���� �Է� �ޱ�
        float h = Input.GetAxis("Horizontal");

        //ĳ���� �¿�� �����̱�, -3.0f�� �ٲ���� �� ���� �� ���� ������
        rigid.velocity = new Vector2(h * moveSpeed, rigid.velocity.y) ;

        //ĳ���� ������ȯ/ �����̼ǰ��� 180�� �ٲ㼭 ��ȯ
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 180.0f));
        }else if(h > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 0.0f));
        }

        //ĳ���� �ִϸ��̼� - �ٱ�(�ȱ�)
        if (rigid.velocity.normalized.x == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        //ĳ���� �ִϸ��̼� - ����
        if (Input.GetButton("Jump")&& !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);


        }


    }
    private void FixedUpdate()
    {
        //���� �� �ٴ� Ž��
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("floor"));
            if (rayhit.collider != null)
            {
                anim.SetBool("isJumping", false);
            }
        }
        
        //ī�޶� �÷��̾ ���󰡵��� ����
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("�÷��̾ ������ �¾ҽ��ϴ�.");
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("gameover"))
        {
            Debug.Log("�÷��̾ �߶��Ͽ����ϴ�.");
            canvas.SetActive(true);
        }
    }
}
