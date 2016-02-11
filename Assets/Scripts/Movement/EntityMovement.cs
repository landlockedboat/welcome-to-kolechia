using UnityEngine;
using System.Collections;
using FreeWorld;

public class EntityMovement : MonoBehaviour {
    [SerializeField]
    float snapDistance = .1f;
    [SerializeField]
    float lerpRate = 15;
    protected bool isMoving = false;
    Vector3 destination;
    float initialDestinationX;

    /*
    public Vector2 Destination
    {
        get
        {
            Vector2 destination_v2 = new Vector2(
                destination.x,
                destination.y);
            return destination_v2;
        }
        set
        {
            destination = new Vector3(value.x,value.y,0);
        }
    } 
    */

    void Start()
    {
        initialDestinationX = 0.1f;
        destination = new Vector3(initialDestinationX, 0, 0);
    }

    protected void MoveTo(Direction direction)
    {
        if (!isMoving)
        {
            isMoving = true;
            destination = GetPositionTowards(transform.position, direction);
            StartCoroutine("LerpTo");
        }
    }   

    public void MoveToForced(Direction direction)
    {
        isMoving = false;
        if (destination.x != initialDestinationX)
            transform.position = destination;
        MoveTo(direction);
    }

    IEnumerator LerpTo()
    {
        while(Vector3.Distance(transform.position, destination) > snapDistance)
        {
            transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * lerpRate);
            yield return null;
        }
        transform.position = destination;
        isMoving = false;
    }

    private Vector3 GetPositionTowards(Vector3 startingPosition, Direction direction)
    {
        Vector3 finalPosition = transform.position;
        switch (direction)
        {
            case Direction.up:
                finalPosition += Vector3.up * Constants.tileSize;
                break;
            case Direction.down:
                finalPosition += Vector3.down * Constants.tileSize;
                break;
            case Direction.left:
                finalPosition += Vector3.left * Constants.tileSize;
                break;
            case Direction.right:
                finalPosition += Vector3.right * Constants.tileSize;
                break;
            case Direction.none:
                Debug.LogError("Warning in EntityMovement.cs: Direction.none provided");
                break;
            default:
                Debug.LogError("Error in EntityMovement.cs: provided direction does not exist.");
                break;
        }
        return finalPosition;
    }
}
