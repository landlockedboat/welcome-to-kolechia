using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using FreeWorld;

[RequireComponent(typeof(EntityMovement))]

public class NetworkMovementSync : NetworkBehaviour {

    [SyncVar(hook = "OnNewDirection")]
    Direction nextDirection = Direction.none;
    [SyncVar]
    Vector2 lastServerDestination;
    [SerializeField]
    bool isServerControlled = false;
    public Vector2 LastServerDestination
    {
        get
        {
            return lastServerDestination;
        }
    }
    EntityMovement entityMovement;
    public Direction NextDirection
    {
        set
        {
            nextDirection = value;
        }
    }
    public bool IsLocal
    {
        get{
            return isLocalPlayer;
        }
    }
    public bool IsServer
    {
        get
        {
            return isServer;
        }
    }
    /*
    [Command]
    public void CmdGetLastServerDestination()
    {
        lastServerDestination = entityMovement.Destination;
    }
    */
    void Awake()
    {
        entityMovement = GetComponent<EntityMovement>();
    }

    public override void OnStartClient()
    {
        if (isServer)
            return;
        FixPosition();
    }

    private void FixPosition()
    {
        float realX = Mathf.CeilToInt(transform.position.x);
        float realY = Mathf.CeilToInt(transform.position.y);
        transform.position = new Vector2(realX, realY);
    }


    [Command]
    public void CmdNewDirection(Direction _nextDirection)
    {
        nextDirection = _nextDirection;
    }

    void OnNewDirection(Direction _nextDirection)
    {
        nextDirection = Direction.none;
        if (isLocalPlayer)
            return;
        if (isServer && isServerControlled)
            return;
        entityMovement.MoveToForced(_nextDirection);
    }
}
