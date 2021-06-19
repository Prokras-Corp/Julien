using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookshotController : MonoBehaviour
{
    public CharacterController cc;
    PhotonView PV;

    //[SerializeField] Transform debugHitPointTransform;
    
    private State state;
    public Vector3 HookshotPosition;

    private enum State
    {
        Normal,
        HookshotFlyingPlayer
    }

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        PV = GetComponent<PhotonView>();
        state = State.Normal;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Normal:
                HandleHookshotStart();
                break;
            case State.HookshotFlyingPlayer:
                break;
        }
    }

    private void HandleHookshotStart()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit))
            {
                //debugHitPointTransform.position = raycastHit.point;
                HookshotPosition = raycastHit.point;
                state = State.HookshotFlyingPlayer;
            }
        }
    }

    private void HandleHookshotMovement()
    {
        Vector3 HookshotDirection = (HookshotPosition - transform.position).normalized;
        float hookshotSpeed = 25f;
        cc.Move(HookshotDirection * hookshotSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, HookshotPosition) < 1)
        {
            state = State.Normal;
        }
    }
}
