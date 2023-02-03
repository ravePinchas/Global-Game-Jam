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


    public int level = 1;




    private void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        level = FindObjectOfType<PlayerMovment>().level;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            useFreeze();
        }

    }



    public void HealMe()
    {
        currentAbility = new Heal();
        
        UseAbility();

    }



    public void useFreeze()
    {
        currentAbility = new FreezeEnemy();
        currentAbilityName = "FreezeEnemy";
        UseAbility();

    }


    public void increasePlayerSpeed()
    {
        currentAbility = new IncreaseSpeed();
        currentAbilityName = "Increase Speed";

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
