using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedHorizontal;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float speedVertical;
    private Animator anim;
    private bool isGrounded;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (GameController.Instance.state == PlayerState.Idle)
        {
            anim.SetBool(Constant.Anim_Die, false);           
        }
        if (GameController.Instance.state == PlayerState.Moving)
        {
            anim.SetBool(Constant.Anim_FastRun,true);
            transform.position += Vector3.forward * speedVertical * Time.deltaTime;
            Vector3 targetPos = transform.position;
            if (Input.GetKeyDown(KeyCode.A))
            {
                targetPos -= new Vector3(speedHorizontal, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                targetPos += new Vector3(speedHorizontal, 0, 0);
            }
            targetPos.x = Mathf.Clamp(targetPos.x, -speedHorizontal, speedHorizontal);
            transform.position = targetPos;
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                anim.SetBool(Constant.Anim_Jump, true);
                rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }
    public void setComponentAnim(GameObject player)
    {
        anim=player.GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constant.Tag_Ground))
        {
            anim.SetBool(Constant.Anim_Jump, false);
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(Constant.Tag_Obstacle))
        {
            GameController.Instance.state = PlayerState.Die;
            anim.SetBool(Constant.Anim_Die, true);
            anim.SetBool(Constant.Anim_FastRun, false);
            GameController.Instance.restartPanel.transform.DOScale(1, 1f);
        }
    }
}
