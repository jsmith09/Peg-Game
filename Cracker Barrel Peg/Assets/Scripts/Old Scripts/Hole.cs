using UnityEngine;
using System.Collections;

//*CODE IS NOT USED. IS TO LOOK AT MY THOUGHT PROCESS*
public class Hole : MonoBehaviour
{
   private bool canInsertPeg;
   private GameObject pegToBeInserted;

  void OnTriggerEnter2D (Collider2D peg)
    {
        Debug.Log("Peg has entered hole");
        canInsertPeg = true;
        pegToBeInserted = peg.transform.gameObject; 
    }

    void OnTriggerExit2D(Collider2D peg)
    {
        canInsertPeg = false;
        pegToBeInserted = null;
    }

    void Update()
    {
        insertIntoHole();
    }

    void insertIntoHole()
    {
        if(canInsertPeg)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Peg is inserted");
                pegToBeInserted.transform.position = transform.position;
                Peg peg = pegToBeInserted.GetComponent<Peg>();
                jumpAPeg(peg);
            }
        }
    }

    void jumpAPeg(Peg peg)
    {
       if(peg.directionOfPeg == 0)
        {

        }
    }

}
