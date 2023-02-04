using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] IAbility currentAbility = null;
    [SerializeField] public string currentAbilityName = null;

    [SerializeField] Button[] buttons;

    public int level = 1;

    [SerializeField] GameObject canvas;



    private void Start()
    {


        //set canvas position
        




    }

    // Update is called once per frame
    void Update()
    {
        level = FindObjectOfType<PlayerMovment>().level;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            useFreeze();
        }

        if (FindObjectOfType<PlayerMovment>().isLevelUp)
        {
            ShuffleAbilities();
        }


        if (FindObjectOfType<PlayerMovment>().isLevelUp)
        {
        

        } 

    }

    private void ShuffleAbilities()
    {

     

        //shuffle the abilities on the buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, buttons.Length);
            Button temp = buttons[i];
            buttons[i] = buttons[randomIndex];
            buttons[randomIndex] = temp;
        }

        //set the abilities on the buttons
        for (int i = 0; i < buttons.Length; i++)
        {

            UnityEngine.Debug.Log("ForLoop");

            if (i == 0)
            {
                buttons[i].onClick.AddListener(HealMe);
                buttons[i].name = "HealMe";
                //change the name in the text

                buttons[i].GetComponentInChildren<Text>().text = "HealMe";

            }
            else if (i == 1)
            {
                buttons[i].onClick.AddListener(useFreeze);
                buttons[i].name = "Freeze Enemies";
                buttons[i].GetComponentInChildren<Text>().text = "Freeze Enemies";
            }
            else if (i == 2)
            {
                buttons[i].onClick.AddListener(increasePlayerSpeed);
                buttons[i].name = "Increase Speed";
                buttons[i].GetComponentInChildren<Text>().text = "Increase Speed";
            }
        }
        FindObjectOfType<PlayerMovment>().isLevelUp = false;
    }

    public void HealMe()
    {
        currentAbility = new Heal();
            UnityEngine.Debug.Log("heal");
        

        UseAbility();

    }



    public void useFreeze()
    {
        currentAbility = new FreezeEnemy();
        currentAbilityName = "FreezeEnemy";
        


        UseAbility();
        UnityEngine.Debug.Log("freeze");

    }


    public void increasePlayerSpeed()
    {
        currentAbility = new IncreaseSpeed();
        currentAbilityName = "Increase Speed";
       
        ;

        UnityEngine.Debug.Log("speed");

        UseAbility();

    }


    public void UseAbility()
    {
        currentAbility.Use();

        
    }


    public interface IAbility
    {
        void Use();
    }

    public class Ability : IAbility
    {
        public void Use()
        {
           // UnityEngine.Debug.Log("Ability used");
        }
    }
    
    public class IncreaseSpeed : MonoBehaviour, IAbility
    {
        public void Use()
        {


            PlayerMovment playerMovment = FindObjectOfType<PlayerMovment>();

            if (playerMovment.speed < 10)
            {
                playerMovment.speed += 1;
            }
            else
            {
                UnityEngine.Debug.Log("Max speed reached");
            }

            UnityEngine.Debug.Log("IncreaseSpeed used");
           
          


        }
    }

    public class Heal : MonoBehaviour, IAbility
    {
        public void Use()
        {
            UnityEngine.Debug.Log("Heal used");
            PlayerMovment playerMovment = FindObjectOfType<PlayerMovment>();
            playerMovment.health = playerMovment.health + 50;

        }
    }



    public class FreezeEnemy : MonoBehaviour, IAbility
    {
        public void Use()
        {

            Stopwatch stopwatch = new Stopwatch();

            

            stopwatch.Start();


            //find all the sprite renderers in the EnemyBehavior
                


            foreach (var enemy in FindObjectsOfType<EnemyBehavior>())
            {
                enemy.speed = 1f;

                

                if (stopwatch.ElapsedMilliseconds > 1000)
                {

                    enemy.speed = 5f;

                    //check if 5 seconds have passed
                    UnityEngine.Debug.Log("Elapsed time: " + stopwatch.Elapsed.Seconds);

                    stopwatch.Reset();

                }
            }

            

           

            UnityEngine.Debug.Log("FreezeEnemy used");

      
            
           

        }
    }

}
