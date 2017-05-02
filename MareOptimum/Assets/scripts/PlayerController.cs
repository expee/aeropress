using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerController : MonoBehaviour {

    public float speed;
    public float acceleration;    

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    string currentAnim = null;
   
    public bool boostMove = false;
    public float boostTime;
    private BackgroundManager bgmanager;
    private Animator anim;
    private Rigidbody rb;
    public float xMin;
    public float xMax;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
        anim = transform.GetComponent<Animator>();
        bgmanager = GameObject.Find("BackgroundManager").GetComponent<BackgroundManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), transform.position.y, transform.position.z);
       
        // boostTimer
        
        if (boostTime > 0 && boostMove)
        {
            bgmanager.speed = 50;
            boostTime -= Time.deltaTime;
            bgmanager.boost = true;
           // SetAnimation("SwimBoost");            
        }
        else if (boostTime <=  0 && boostMove)
        {
            bgmanager.speed = 2;
            SetAnimation("EndBoost");            
            boostTime = 0;
            boostMove = false;
        }
            

       // Debug.Log("bgmanager.speed " + bgmanager.speed);
        

        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            
            //normalize the 2d vector
            currentSwipe.Normalize();
            //Debug.Log("currentSwipe.x = " + currentSwipe.x);
            //Debug.Log("currentSwipe.y = " + currentSwipe.y);
            float diff = 0.3f;

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -diff && currentSwipe.x < diff)
            {
            //   Debug.Log("up swipe");               
               SetAnimation("SwimUp");              
            }
            //swipe down
            else if (currentSwipe.y < 0 && currentSwipe.x > -diff && currentSwipe.x < diff)
            {
           //     Debug.Log("down swipe");                
                SetAnimation("SwimDown");               
            }
            //swipe left
            else if (currentSwipe.x < 0 && currentSwipe.y > -diff && currentSwipe.y < diff)
            {               
           //     Debug.Log("left swipe");
                SetAnimation("SwimBackward");                
            }
            //swipe right
            else if (currentSwipe.x > 0 && currentSwipe.y > -diff && currentSwipe.y < diff)
            {              
            //   Debug.Log("right swipe");
               SetAnimation("SwimBoost");
               if (!boostMove)
               {
                   //SetAnimation("SwimBoost");
                   boostMove = true;
                   boostTime = 5.0f;
               }                              
            }
            // Swipe up left
            else if (currentSwipe.y > diff && currentSwipe.x < 0) 
            {
              //  Debug.Log("Up Left swipe: " + currentSwipe.y);
                 SetAnimation("SwimBackward");            
            }
            // Swipe up right
            else if (currentSwipe.y > diff && currentSwipe.x > 0) 
            {
            //    Debug.Log("Up Right swipe : " + currentSwipe.y);                
                SetAnimation("SwimUp");             
            }
            // Swipe down left
            else if (currentSwipe.y < -diff && currentSwipe.x < 0) 
            {
            //    Debug.Log("Down Left swipe: " + currentSwipe.y);
                SetAnimation("SwimBackward");            
            }
            // Swipe down right
            else if (currentSwipe.y < -diff && currentSwipe.x > 0) 
            {
            //    Debug.Log("Down Right swipe: " + currentSwipe.y);                
                SetAnimation("SwimDown");            
            }
            // move player
            rb.AddForce(currentSwipe * speed * acceleration);            
        }
       

    
	}

    void SetAnimation(string InputString)
    {
        //Debug.Log("InputString  = " + InputString);
        //Debug.Log("currentanimation 1 = " + currentAnim);
        
        if (currentAnim == InputString)
        {
            //Debug.Log("currentAnim == InputString ");
            anim.SetTrigger(InputString);
            currentAnim = InputString;
        }
        else if(currentAnim == "SwimBackward"){
            //Debug.Log("currentanimation 1.1 = " + currentAnim);
            anim.ResetTrigger(currentAnim);
            anim.SetTrigger("SwimBackToNorm");
            currentAnim = "SwimBackToNorm";
        }
        else if (currentAnim == "SwimBoost" && InputString != "EndBoost")
        {
           // Debug.Log("currentanimation 1.2 = " + currentAnim);
            //anim.ResetTrigger(currentAnim);
            //anim.SetTrigger("EndBoost");
            currentAnim = "SwimBoost";
        }
        else
        {
            //Debug.Log("currentanimation 2 = " + currentAnim);
            if (currentAnim != null)
            {
               // Debug.Log("reset curranim  " );
                anim.ResetTrigger(currentAnim);
                anim.SetTrigger(InputString);
                currentAnim = InputString;
            }
            else
            {
               // Debug.Log("else play anim = ");
                anim.SetTrigger(InputString);
                currentAnim = InputString;
            }
        }
    }
}
