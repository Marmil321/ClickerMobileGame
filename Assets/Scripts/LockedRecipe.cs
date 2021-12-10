using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRecipe : MonoBehaviour
{
    public string[] materials;

    private void Update()
    {
        if (unclock(materials.Length) == true)
        {
            Destroy(this.gameObject);
        }
          
    }
    private bool unclock(int lenght)
    {
        if (lenght == 1)
        {
            string mat1 = materials[0] + "Amount";
            if (PlayerPrefs.GetInt(mat1) > 0)
            {
                return true;
            }
        }
        if(lenght == 2)
        {
            int correct = 0;
            string mat1 = materials[0] + "Amount";
            string mat2 = materials[1] + "Amount";
            if (PlayerPrefs.GetInt(mat1) > 0)
            {
                correct++;
            }
            if(PlayerPrefs.GetInt(mat2) > 0)
            {
                correct++;
            }
            if (correct == 2)
            {
                return true;
            }
        }
        if (lenght == 3)
        {
            int correct = 0;
            string mat1 = materials[0] + "Amount";
            string mat2 = materials[1] + "Amount";
            string mat3 = materials[2] + "Amount";
            if (PlayerPrefs.GetInt(mat1) > 0)
            {
                correct++;
            }
            if (PlayerPrefs.GetInt(mat2) > 0)
            {
                correct++;
            }
            if (PlayerPrefs.GetInt(mat3) > 0)
            {
                correct++;
            }
            if (correct == 3)
            {
                return true;
            }

        }
        return false;
    }
}

