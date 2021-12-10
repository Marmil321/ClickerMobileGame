using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject tree, stone, furnace;

    public Button nextButton;
    public Dropdown changeBG;
    public Dropdown changeRes;
    public GameObject BG;
    public Sprite[] colors;

    public int page  = -1;
    public int i;

    bool paused = false;
    public GameObject pauseMenu, inventory;

    private void Start()
    {
        changeBG.value = PlayerPrefs.GetInt("bgValue");
    }
    public void GoHome()
    {
        HomeManager();

        if (i == 0)
        {
            i++;
        }
        else
        {
            i--;
        }
    }
    public void GoToStone()
    {
        PageManager();

        if (page == 0)
        {
            page++;
        }else
        {
            page--;
        }
    }
    private void Update()
    {
        

        if (i > 0)
        {
            nextButton.gameObject.SetActive(false);
        }else
        {
            nextButton.gameObject.SetActive(true);
        }
    }
    void PageManager()
    {
        switch (page)
        {
            case 0:
                stone.GetComponent<Stone>().FadeInn();
                tree.GetComponent<Tree>().FadeOut();
                
                break;
            case 1:
                stone.GetComponent<Stone>().FadeOut();
                tree.GetComponent<Tree>().FadeInn();
                break;
            case 3:
                page = 0;
                break;

        }
    }
    void HomeManager()
    {
        switch (i)
        {
            case 0:
                if (page == 0) 
                {
                    tree.GetComponent<Tree>().FadeDown();
                }
                else if(page == 1)
                {
                    stone.GetComponent<Stone>().FadeDown();
                }

                furnace.GetComponent<FurnaceAnimationController>().FadeDown();
                break;
            case 1:
                if (page == 0)
                {
                    tree.GetComponent<Tree>().FadeUp();
                }
                else if (page == 1)
                {
                    stone.GetComponent<Stone>().FadeUp();
                }

                furnace.GetComponent<FurnaceAnimationController>().FadeUp();
                break;
        }
    }
    public void BackgroundChange()
    {
        switch (changeBG.value)
        {
            case 0:
                PlayerPrefs.SetInt("bgValue", changeBG.value);
                foreach (Transform child in BG.transform)
                {
                    //print(child);
                    child.GetComponentInChildren<SpriteRenderer>().sprite = colors[0];
                }
                break;
            case 1:
                PlayerPrefs.SetInt("bgValue", changeBG.value);
                foreach (Transform child in BG.transform)
                {
                    child.GetComponentInChildren<SpriteRenderer>().sprite = colors[1];
                }

                break;
            case 2:
                PlayerPrefs.SetInt("bgValue", changeBG.value);
                foreach (Transform child in BG.transform)
                {
                    child.GetComponentInChildren<SpriteRenderer>().sprite = colors[2];
                }

                break;
            case 3:
                PlayerPrefs.SetInt("bgValue", changeBG.value);
                foreach (Transform child in BG.transform)
                {
                    child.GetComponentInChildren<SpriteRenderer>().sprite = colors[3];
                }

                break;

        }
    }
    public void ChangeResolution()
    {
        //Resolution[] resolutions;

        switch (changeRes.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                print(Screen.currentResolution);
                break;
            case 1:
                Screen.SetResolution(2160, 1080, true);
                print(Screen.currentResolution);
                break;
            case 2:
                Screen.SetResolution(2960, 1440, true);
                print(Screen.currentResolution);
                break;
        }
    }
    public void CheckReq()
    {
        StateManager state = FindObjectOfType<StateManager>();
        UpgradeManger upgrade = FindObjectOfType<UpgradeManger>();
        InventoryManager inv = FindObjectOfType<InventoryManager>();


        switch (state.activeState)
        {
            case "tree":
                if (PlayerPrefs.GetInt("WoodAmount") >= upgrade.treeReq)
                {
                    inv.RemoveItem("WoodAmount", upgrade.treeReq);
                    Upgrade();
                }
                break;
            case "stone":
                if (PlayerPrefs.GetInt("StoneAmount") >= upgrade.stoneReq)
                {
                    inv.RemoveItem("StoneAmount", upgrade.stoneReq);
                    Upgrade();
                }
                break;
            case "furnace":
                if (PlayerPrefs.GetInt("IronAmount") >= upgrade.ironReq)
                {
                    inv.RemoveItem("IronAmount", upgrade.ironReq);
                    Upgrade();
                }
                break;
        }
    }
    public void Upgrade()
    {
        StateManager state = FindObjectOfType<StateManager>();
        UpgradeManger upgrade = FindObjectOfType<UpgradeManger>();

        switch (state.activeState)
        {
            case "tree":
                PlayerPrefs.SetInt("TreeLevel", upgrade.upgradeAmounts[0]++);
                break;
            case "stone":
                PlayerPrefs.SetInt("StoneLevel", upgrade.upgradeAmounts[1]++);
                break;
            case "furnace":
                PlayerPrefs.SetInt("FurnaceLevel", upgrade.upgradeAmounts[2]++);
                break;
        }
    }
    public void OpenInventory()
    {
        inventory.SetActive(true);
    }
    public void Pause()
    {
        
        if (!paused)
        {
            paused = true;
            pauseMenu.SetActive(true);
            //Time.timeScale = 0;

        }else
        {
            paused = false;
            pauseMenu.SetActive(false);
            //Time.timeScale = 1;
        }
    }
}
