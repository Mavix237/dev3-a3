using UnityEngine;
using UnityEngine.AI;

using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerMove : MonoBehaviour
{
    public LayerMask navLayer;
    Camera mainCam;
    NavMeshAgent navAgent;
    Animator anim;
    bool walking = false;
    void Start()
    {
        EnhancedTouchSupport.Enable();
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
    }

    void Update(){
        if (Touch.activeTouches.Count == 1)
        {
            Touch touch1 = Touch.activeTouches[0];

            if (touch1.phase == TouchPhase.Began)
            {
                Ray ray = mainCam.ScreenPointToRay(touch1.screenPosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 20, navLayer))
                {
                    navAgent.SetDestination(hit.point);
                    walking = true;
                    anim.SetBool("Walking", walking);

                }
            }

            anim.SetFloat("Speed", navAgent.velocity.sqrMagnitude);
            // if(navAgent.remainingDistance < 0.1f){
            //     walking = false;
            //     anim.SetBool("Walking", walking);
            // }
    }
    }


}
