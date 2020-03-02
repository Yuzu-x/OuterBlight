using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableRecruits : MonoBehaviour
{
    public RecruitClass recruit;

    public GameObject recruitbody;

    public float myClass;
    public string myClassString;
    public float myTribe;
    public float mySex;
    public string myName;

    public Text classText;
    public Text nameText;
    public Image classIcon;

    void Start()
    {
        myClass = Random.Range(1, 13);
        myTribe = Random.Range(1, 7);
        mySex = Random.Range(1, 3);

        if(myClass == 1)
        {
            myClassString = "Paladin";
        }
        else if(myClass == 2)
        {
            myClassString = "Knight";
        }
        else if (myClass == 3)
        {
            myClassString = "Engineer";
        }
        else if (myClass == 4)
        {
            myClassString = "Priest";
        }
        else if (myClass == 5)
        {
            myClassString = "Witch";
            myTribe = Random.Range(1, 8);
        }
        else if (myClass == 6)
        {
            myClassString = "Miasmatic";
        }
        else if (myClass == 7)
        {
            myClassString = "Assassin";
            myTribe = Random.Range(1, 9);
            if(myTribe == 7)
            {
                myTribe = 8;
            }
        }
        else if (myClass == 8)
        {
            myClassString = "Fighter";
        }
        else if (myClass == 9)
        {
            myClassString = "Mage";
        }
        else if (myClass == 10)
        {
            myClassString = "Necromancer";
        }
        else if (myClass == 11)
        {
            myClassString = "Ranger";
        }
        else if (myClass == 12)
        {
            myClassString = "Tamer";
        }

        classText.text = myClassString;
        nameText.text = myName;
    }
}
