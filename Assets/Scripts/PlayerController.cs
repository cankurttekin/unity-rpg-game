using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float speed = 6f;
    public GameObject maulHand;
    public GameObject maulBack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        anim.SetFloat("turningspeed", horizontalInput);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("speed", verticalInput*2);
        }
        else
        {
            anim.SetFloat("speed", verticalInput);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetInteger("Equip", 1);
            equip();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetInteger("AttackValue", Random.Range(0, 3));
            anim.SetTrigger("attack");   
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    }



    void equip()
    {
        maulBack.SetActive(false);
        maulHand.SetActive(true);
    }
}
