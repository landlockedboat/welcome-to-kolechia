using UnityEngine;
using System.Collections;
using FreeWorld;

[RequireComponent(typeof(NetworkMovementSync))]

public class PlayerMovementInput : EntityMovement {

    NetworkMovementSync networkMove;    

    void Start () {
        networkMove = GetComponent<NetworkMovementSync>();
    }
	
	void Update () {
        if (!networkMove.IsLocal || isMoving)
            return;
        Direction inputDirection = Direction.none;
	    if(Input.GetAxisRaw("Horizontal") > 0)
        {
            inputDirection = Direction.right;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            inputDirection = Direction.left;
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            inputDirection = Direction.up;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            inputDirection = Direction.down;
        }
        if(inputDirection != Direction.none)
        {
            MoveTo(inputDirection);
            networkMove.CmdNewDirection(inputDirection);                
        }
    }
}
