using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove2 : MonoBehaviour
{
    public static int count;
    public GameObject score1;
    float jumpPower=3f;
    float moveSpeed = 10f;
    Rigidbody2D rigid;
    Animator anim;

    SpriteRenderer spriteRenderer;
     void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        //���� �Է� �ޱ�
        float h = Input.GetAxis("Horizontal");

        //ĳ���� ������ȯ/ �����̼ǰ��� 180�� �ٲ㼭 ��ȯ
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 180.0f));
        }else if(h > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector2(0.0f, 0.0f));
        }

        //ĳ���� �ִϸ��̼� - ����
        if (Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);

        }
       

        //ĳ���� �ִϸ��̼� - �����̵�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isSliding", true);
        }
        else
        {

            anim.SetBool("isSliding", false);
        }

  
    }
    private void FixedUpdate()
    {
        //���� �� �ٴ� Ž��
        if (rigid.velocity.y < 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);

            }
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayhit = Physics2D.Raycast(rigid.position, Vector3.down, 5, LayerMask.GetMask("floor"));
            if (rayhit.collider != null)
            {
                anim.SetBool("isJumping", false);
            }
        }
        
    }

    //������ �浹 ����
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            score.Score -= 2;
            PlayerMove2.count++;
            if (PlayerMove2.count > 4)
            {
                SceneManager.LoadScene("2-1");
            }
            OnDamaged(collision.transform.position);
        }

    }

    //�浹 �� ������ �Լ�
    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 11;
        spriteRenderer.color = new Color(1,1,1,0.4f);
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;

        anim.SetTrigger("damaged");

        //�ð����� �ΰ� ���� ������ �Ĺ�
        Invoke("OffDamaged", 1);
    }

    void OffDamaged()
    {
        gameObject.layer = 10;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    //Ʈ���� ó��
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (score.Score > score.bestScore)
        {
            score.bestScore = score.Score;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("gameover"))
        {
            

            DontDestroyOnLoad(score1);
            //2-1 ������ ��ȯ
            SceneManager.LoadScene("2-1");
        }

        if (collision.gameObject.CompareTag("gold"))
        {
            score.Score += 3;
            Debug.Log("Gold");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("silver"))
        {
            score.Score += 2;
            Debug.Log("silver");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("bronze"))
        {
            score.Score += 1;
            Debug.Log("bronze");
            Destroy(collision.gameObject);
        }
    }
}
