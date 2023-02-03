using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [SerializeField] int currentLevel = 1;
    [SerializeField] int lastLevel = 1;
    [SerializeField] int randomAbility;

    [SerializeField] PlayerAbilitiesController playerAbilitiesController;

    [SerializeField] Button[] buttons;

    private void Update()
    {
        currentLevel = FindObjectOfType<PlayerMovment>().level;

        //check if the current level is bigger than last level
        if (currentLevel > lastLevel)
        {


            //shuffle random number between 1-3
            randomAbility = Random.Range(1, 4);

            //check if the random number is 1
            if (randomAbility == 1)
            {
                for (int i = 0; i < buttons.Length; i++)
                {

                }
                randomAbility = Random.Range(1, 4);

                buttons[1].onClick.AddListener(playerAbilitiesController.useFreeze);

                buttons[1].GetComponentInChildren<Text>().text = playerAbilitiesController.currentAbilityName;

            }

            //check if the random number is 2
            if (randomAbility == 2)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    randomAbility = Random.Range(1, 4);

                    buttons[i].onClick.AddListener(playerAbilitiesController.increasePlayerSpeed);

                    buttons[i].GetComponentInChildren<Text>().text = playerAbilitiesController.currentAbilityName;
                }
            }

            //check if the random number is 3
            if (randomAbility == 3)
            {

                for (int i = 0; i < buttons.Length; i++)
                {
                    randomAbility = Random.Range(1, 4);
                    buttons[i].onClick.AddListener(playerAbilitiesController.HealMe);

                    buttons[i].GetComponentInChildren<Text>().text = playerAbilitiesController.currentAbilityName;
                }
               
            }

            //set last level to current level
            lastLevel = currentLevel;


        } 

    }

    


}
