using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed=5.0f;
    public Transform movePoint;

    public LayerMask moveObstacles;
    public LayerMask ground;

    //public Animator charAnim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        MoveFunction();
    }

    void MoveFunction(){
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.01f){
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics.CheckSphere(movePoint.position + new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")*3), 0.01f, moveObstacles)){
                    movePoint.position += new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")*3);
                }
            } 
            else if(Input.GetAxisRaw("Vertical") == 1f){
                Debug.Log("Çalışıyor1");
                    if(Physics.CheckSphere(movePoint.position + new Vector3(0f, -3f, 0f), 0.2f, ground)){
                    Debug.Log("Çalışıyor2");
                    movePoint.position += new Vector3(0f, 3f, 0f);
                    Invoke("ReturntoGround", 0.5f);
                    
                }
    
            }
            //charAnim.SetBool("moving", false);
        }
        else {
            //charAnim.SetBool("moving", true);
        }
    }

    void ReturntoGround(){
        movePoint.position += new Vector3(0f, -3f, 0f);
    }
   
}
