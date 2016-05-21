using UnityEngine;
using System.Collections;

//*CODE IS NOT USED. IS TO LOOK AT MY THOUGHT PROCESS*
public class Peg : MonoBehaviour
{
    [SerializeField]
    int distance = 10;
    [SerializeField]
    public Direction directionOfPeg = Direction.up;
    private Vector3 pastPosition = Vector3.zero;
    private Vector3 direction = Vector3.zero;
    public enum Direction { up, down, left, right };



    void OnMouseDrag()
    {
        Vector3 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 newPegPositon = Camera.main.ScreenToWorldPoint(mouseposition);
        Vector3 heading = Input.mousePosition - pastPosition;
        direction = heading/heading.sqrMagnitude;
        getDirection(direction);
        //Debug.Log(direction);
        transform.position = newPegPositon;
        pastPosition = Input.mousePosition;
    }

    void getDirection(Vector3 direction)
    {
        float dotUp = Vector3.Dot(direction, Vector3.up);
        float dotRight = Vector3.Dot(direction, Vector3.right);

        if (dotRight > 0)
        {
            directionOfPeg = Direction.right;
        }

        else if( dotUp > 0)
        {
            directionOfPeg = Direction.up;
        }

        else if(dotUp < 0)
        {
            directionOfPeg = Direction.down;
        }

        else if(dotRight < 0)
        {
            directionOfPeg = Direction.left;
        }

        else
        {
            Debug.Log("Cannot find direction");
        }

    }


}
