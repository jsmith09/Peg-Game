using UnityEngine;
using System.Collections;

public class Hole2 : MonoBehaviour
{
   //Used to check for valid moves 
   public GameObject insertedPeg;
   public int holeNum;
   public GameObject upperLeftHole;
   public GameObject upperRightHole;
   public GameObject lowerLeftHole;
   public GameObject lowerRightHole;
   public GameObject leftHole;
   public GameObject rightHole;
   public GameObject targetForUpperLeftHole;
   public GameObject targetForUpperRightHole;
   public GameObject targetForLowerLeftHole;
   public GameObject targetForLowerRightHole;
   public GameObject targetForLeftHole;
   public GameObject targetForRightHole;


  //*Code is not used and is for you to look at my thought process*


    //void Start()
  //{
     //if(upperLeftHole != null)
     //{
     //  upperLeftHoleNum = upperLeftHole.GetComponent<Hole2>().holeNum; 
     //}

     //if(upperRightHole != null)
     //{
     //  upperRightHoleNum = upperRightHole.GetComponent<Hole2>().holeNum;
     //}

     //if (lowerLeftHole != null)
     //{
     //  lowerLeftHoleNum = lowerLeftHole.GetComponent<Hole2>().holeNum;
     //}

     //if (lowerRightHole != null)
     //{
     //  lowerRightHoleNum = lowerRightHole.GetComponent<Hole2>().holeNum;
     //}

     //if (leftHole != null)
     //{
     //  leftHoleNum = leftHole.GetComponent<Hole2>().holeNum;
     //}

     //if(rightHole != null)
     //{
     //  rightHoleNum = rightHole.GetComponent<Hole2>().holeNum;
     //}

  //}

  //void Update()
  //{
  //      if (readyPeg || readyToJump)
  //      {
  //          //insertIntoHole();
  //      }

  //      if (readyToJump)
  //      {
  //          //checkForJump(jumpingPeg);
  //      }
  //  }

  //void OnTriggerEnter2D (Collider2D col)
  //  {
  //      if (canInsertPeg)
  //      {
  //          Debug.Log("Can be inserted");
  //          pegToBeInserted = col.transform.gameObject;
  //          readyPeg = true;
  //      }

  //      else
  //      {
  //          readyToJump = true;
  //          jumpingPeg = col.transform.gameObject;
  //      }
  //  }

  //  void OnTriggerExit2D(Collider2D peg)
  //  {
  //      if (!readyToJump)
  //      {
  //          canInsertPeg = true;
  //          readyPeg = false;
  //          pegToBeInserted = null;
  //      }
  //  }

    //void insertIntoHole()
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        Debug.Log("Peg is inserted");
    //        canInsertPeg = false;
    //        readyPeg = false;
    //        Peg2 peg = pegToBeInserted.GetComponent<Peg2>();
    //        peg.holeInsertedIn = transform.gameObject;
    //        pegToBeInserted.transform.position = transform.position;
    //        if(readyToJump)
    //        {
    //            Debug.Log("Jumped Peg");
    //            //GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //            readyToJump = false;
    //            canInsertPeg = true;
    //        }
    //    }
    //}

    //void checkForJump(GameObject jumpingPeg)
    //{
    //    Hole2 pastHole = jumpingPeg.GetComponent<Peg2>().holeInsertedIn.GetComponent<Hole2>();
    //    int pegHoleNum = pastHole.holeNum;

    //    if(upperLeftHole != null && upperLeftHole.GetComponent<Hole2>().pegToBeInserted == null)
    //    {
    //        if(upperLeftHoleNum == pegHoleNum)
    //        {
    //            Debug.Log("Jump down to lower right hole");
    //            jumpingPeg.transform.position = lowerRightHole.transform.position;
    //            GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //        }
    //    }

    //    else if(upperRightHole != null && upperRightHole.GetComponent<Hole2>().pegToBeInserted == null)
    //    {
    //        if(upperRightHoleNum == pegHoleNum)
    //        {
    //            Debug.Log("Jump down to lower left hole");
    //            jumpingPeg.transform.position = lowerLeftHole.transform.position;
    //            GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //        }
    //    }

    //    else if (lowerRightHole != null && lowerRightHole.GetComponent<Hole2>().pegToBeInserted == null)
    //    {
    //        if (lowerRightHoleNum == pegHoleNum)
    //        {
    //            Debug.Log("Jump to upper left hole");
    //            jumpingPeg.transform.position = upperLeftHole.transform.position;
    //            GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //        }
    //    }

    //    else if (lowerLeftHole != null && lowerLeftHole.GetComponent<Hole2>().pegToBeInserted == null)
    //    {
    //        if (lowerLeftHoleNum == pegHoleNum)
    //        {
    //            Debug.Log("Jump to upper right hole");
    //            jumpingPeg.transform.position = upperRightHole.transform.position;
    //            GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //        }
    //    }

    //    else if (leftHole != null && leftHole.GetComponent<Hole2>().pegToBeInserted == null)
    //    {
    //        if (leftHoleNum == pegHoleNum)
    //        {
    //            Debug.Log("Jump to right hole");
    //            jumpingPeg.transform.position = rightHole.transform.position;
    //            GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //        }
    //    }

    //    else if (rightHole != null && rightHole.GetComponent<Hole2>().pegToBeInserted == null)
    //    {
    //        if (rightHoleNum == pegHoleNum)
    //        {
    //            Debug.Log("Jump to left hole");
    //            jumpingPeg.transform.position = leftHole.transform.position;
    //            GameObject.Destroy(pegToBeInserted.transform.gameObject);
    //        }
    //    }

    //    else
    //    {
    //        readyToJump = false;
    //    }
    //}

}
