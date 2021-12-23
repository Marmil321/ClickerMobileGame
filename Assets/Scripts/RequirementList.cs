using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementList : MonoBehaviour
{
    public UpgradeManger manager;
    public StateManager state;

    private void Start()
    {
        manager = GetComponent<UpgradeManger>();
        state = GetComponent<StateManager>();
    }

    public void Wood()
    {   
        switch (manager.upgradeAmounts[0])
        {
            case 1:
                manager.reqs[0] = 100;
                manager.reqs[1] = 0;
                manager.reqs[2] = 0;
                manager.reqs[3] = 25;
                break;
            case 2:
                manager.reqs[0] = 300;
                manager.reqs[1] = 50;
                manager.reqs[2] = 0;
                manager.reqs[3] = 50;
                break;
            case 3:
                manager.reqs[0] = 500;
                manager.reqs[1] = 100;
                manager.reqs[2] = 10;
                manager.reqs[3] = 150;
                break;
        }
    }
}
