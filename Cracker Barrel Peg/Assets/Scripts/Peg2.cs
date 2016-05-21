using UnityEngine;
using System.Collections;

public class Peg2 : MonoBehaviour
{
    //Used to see if the peg is able to do a vaild jump
    public GameObject holeInsertedIn;

    //trigger to change holeInsertedIn when the peg moves
    void OnTriggerEnter2D(Collider2D col)
    {
        holeInsertedIn = col.transform.gameObject;
    }
}
