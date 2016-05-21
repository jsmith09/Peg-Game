using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Holes;
    [SerializeField]
    private GameObject selectedPeg;
    [SerializeField]
    private GameObject selectedHole;
    [SerializeField]
    private GameObject[] Pegs;
    [SerializeField]
    GameObject pastSelectedHole;
    private GameObject PegList;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private AudioSource jumpSound;


    //Sets up the peg the board
    void Start ()
    {
       PegList = new GameObject();
       PegList.name = "Pegs";
      for(int i = 0; i < Holes.Length; i++)
      {
            int rand = Random.Range(0, 4);
            GameObject peg = Instantiate(Pegs[rand]);
            peg.AddComponent<Peg2>();
            peg.transform.position = Holes[i].transform.position;
            Hole2 holeScript = Holes[i].GetComponent<Hole2>();
            holeScript.insertedPeg = peg;
            peg.transform.SetParent(PegList.transform);
       }
	}
	
	//Checking for a reset and for selection of a peg
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        selectPeg();
	
	}

    //Resets the board
    void Reset()
    {
        winText.SetActive(false);

        foreach ( Transform child in PegList.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < Holes.Length; i++)
        {
            int rand = Random.Range(0, 4);
            GameObject peg = Instantiate(Pegs[rand]);
            peg.AddComponent<Peg2>();
            peg.transform.SetParent(PegList.transform);
            peg.transform.position = Holes[i].transform.position;
            Hole2 holeScript = Holes[i].GetComponent<Hole2>();
            holeScript.insertedPeg = peg;
        }
    }

    /// <summary>
    /// Checks for a peg or hole using raycasting. If its a peg, the selected peg is highlighted.
    /// If it is a hole then then it checks if the selected peg can do that move using the checkJump method.
    /// </summary>
    void selectPeg()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit)
            {
                if(hit.transform.tag == "Peg")
                {
                    hit.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
                    pastSelectedHole = hit.transform.gameObject.GetComponent<Peg2>().holeInsertedIn;
                    if(selectedPeg != null && selectedPeg != hit.transform.gameObject)
                    {
                        selectedPeg.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    }

                    if (selectedPeg != hit.transform.gameObject)
                    {
                        selectedPeg = hit.transform.gameObject;
                    }
                }

                if(hit.transform.tag == "Hole")
                {
                    selectedHole = hit.transform.gameObject;
                    if(selectedPeg != null && selectedHole.GetComponent<Hole2>().insertedPeg == null)
                    {
                        bool canMove = checkJump(pastSelectedHole.GetComponent<Hole2>(), selectedHole.GetComponent<Hole2>());
                        Debug.Log(canMove);
                        if (canMove)
                        {
                            jumpSound.Play();
                            GameObject hole = selectedPeg.GetComponent<Peg2>().holeInsertedIn;
                            hole.GetComponent<Hole2>().insertedPeg = null;
                            selectedPeg.transform.position = selectedHole.transform.position;
                            selectedHole.GetComponent<Hole2>().insertedPeg = selectedPeg;
                            selectedPeg.GetComponent<Peg2>().holeInsertedIn = selectedHole;
                            pastSelectedHole = selectedHole;
                            if (PegList.transform.childCount - 1 == 1)
                            {
                                winText.SetActive(true);
                            }
                        }
                    }
                }
            }

            else
            {
                
            }
        }
    }

    //Checks if its a valid move by the peg using the peg's current hole
    bool checkJump(Hole2 jumpedHole, Hole2 compareHole)
    {
        if(compareHole.upperLeftHole != null && compareHole.targetForUpperLeftHole.GetComponent<Hole2>().insertedPeg != null)
        {
            int holeNum = compareHole.upperLeftHole.GetComponent<Hole2>().holeNum;
            if(holeNum == jumpedHole.holeNum)
            {
                 Hole2 holeWithPegforDeletion = compareHole.targetForUpperLeftHole.GetComponent<Hole2>();
                 Destroy(holeWithPegforDeletion.insertedPeg);
                return true;
            }
        }

        if (compareHole.upperRightHole != null && compareHole.targetForUpperRightHole.GetComponent<Hole2>().insertedPeg != null)
        {
            int holeNum = compareHole.upperRightHole.GetComponent<Hole2>().holeNum;
            if (holeNum == jumpedHole.holeNum)
            {
                Hole2 holeWithPegforDeletion = compareHole.targetForUpperRightHole.GetComponent<Hole2>();
                Destroy(holeWithPegforDeletion.insertedPeg);
                return true;
            }
        }

        if (compareHole.lowerLeftHole != null && compareHole.targetForLowerLeftHole.GetComponent<Hole2>().insertedPeg != null)
        {
            int holeNum = compareHole.lowerLeftHole.GetComponent<Hole2>().holeNum;
            if (holeNum == jumpedHole.holeNum)
            {
                Hole2 holeWithPegforDeletion = compareHole.targetForLowerLeftHole.GetComponent<Hole2>();
                Destroy(holeWithPegforDeletion.insertedPeg);
                return true;
            }
        }

        if (compareHole.lowerRightHole != null && compareHole.targetForLowerRightHole.GetComponent<Hole2>().insertedPeg != null)
        {
            int holeNum = compareHole.lowerRightHole.GetComponent<Hole2>().holeNum;
            if (holeNum == jumpedHole.holeNum)
            {
                Hole2 holeWithPegforDeletion = compareHole.targetForLowerRightHole.GetComponent<Hole2>();
                Destroy(holeWithPegforDeletion.insertedPeg);
                return true;
            }
        }

        if (compareHole.leftHole != null && compareHole.targetForLeftHole.GetComponent<Hole2>().insertedPeg != null)
        {
            int holeNum = compareHole.leftHole.GetComponent<Hole2>().holeNum;
            if (holeNum == jumpedHole.holeNum)
            {
                Hole2 holeWithPegforDeletion = compareHole.targetForLeftHole.GetComponent<Hole2>();
                Destroy(holeWithPegforDeletion.insertedPeg);
                return true;
            }
        }

        if (compareHole.rightHole != null && compareHole.targetForRightHole.GetComponent<Hole2>().insertedPeg != null)
        {
            int holeNum = compareHole.rightHole.GetComponent<Hole2>().holeNum;
            if (holeNum == jumpedHole.holeNum)
            {
                Hole2 holeWithPegforDeletion = compareHole.targetForRightHole.GetComponent<Hole2>();
                Destroy(holeWithPegforDeletion.insertedPeg);
                return true;
            }
        }

        return false;

    }
}
