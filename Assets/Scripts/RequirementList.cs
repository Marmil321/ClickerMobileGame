using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementList : MonoBehaviour
{
    public UpgradeManger manager;

    //Level 1 Stone: Bronze
    //Level 2 Stone: Iron
    //Level 3 Stone: Gold
    //Level 4 Stone: Gems

    //Level 1 Tree: Wood
    //Level 2 Tree: Apples
    //Level 3 Tree: 

    private void Start()
    {
        manager = GetComponent<UpgradeManger>();
    }
    private void ResetList()
    {
        for(int i = 0; i < manager.reqs.Count; i++)
        {
            manager.reqs[i] = 0;
        }
    }
    public void Wood()
    {
        ResetList();

        switch (manager.upgradeAmounts[0])
        {
            case 1:
                manager.reqs[0] = 100;
                manager.reqs[3] = 25;
                break;
            case 2:
                manager.reqs[0] = 300;
                manager.reqs[1] = 100;
                manager.reqs[3] = 50;
                break;
            case 3:
                manager.reqs[0] = 500;
                manager.reqs[1] = 100;
                manager.reqs[2] = 10;
                manager.reqs[3] = 150;
                break;
            case 4:
                manager.reqs[0] = 1500;
                manager.reqs[2] = 15;
                manager.reqs[3] = 500;
                break;
        }
    }
    public void Stone()
    {

        ResetList();

        switch (manager.upgradeAmounts[1])
        {
            case 1:        
                manager.reqs[1] = 100;
                manager.reqs[2] = 5;
                break;
            case 2:      
                manager.reqs[1] = 500;
                manager.reqs[2] = 15;
                break;
            case 3:
                manager.reqs[1] = 1000;
                manager.reqs[2] = 50;
                break;
            case 4:
                break;
        }
    }
    public void Furnace()
    {

    }
}
