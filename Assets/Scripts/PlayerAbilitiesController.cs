using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] int abilityCount = 10;
    [SerializeField] List<IAbility> abilityList = new List<IAbility>();
    [SerializeField] IAbility currentAbility = null;
    [SerializeField] IAbility currentFirstAbility = null;
    [SerializeField] IAbility currentSecondAbility = null;
    [SerializeField] IAbility currentThirdAbility = null;
    [SerializeField] public string currentAbilityName = null;

    [SerializeField] GameObject powerUpScreen;
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite[] abIconsList;
    List<Ability> abilities = new List<Ability>();

    public int level = 1;

    [SerializeField] GameObject canvas;



    private void Start()
    {
        //set canvas position


        // Initialize Abilities
        abilityList.Add(new IncreaseSpeed());
        abilityList[0].SetAbility(0, "Increase Speed", abIconsList[0]);
        abilityList.Add(new Heal());
        abilityList[1].SetAbility(1, "Heal Me", abIconsList[1]);
        abilityList.Add(new FreezeEnemy());
        abilityList[2].SetAbility(2, "Freeze Enemies", abIconsList[2]);
        abilityList.Add(new IncreaseEXP());
        abilityList[3].SetAbility(3, "Increase EXP Gain", abIconsList[3]);
        abilityList.Add(new IncreaseMaxHP());
        abilityList[4].SetAbility(4, "Increase Max HP", abIconsList[4]);
        abilityList.Add(new IncreaseAxeDamage());
        abilityList[5].SetAbility(5, "Increase Axe Damage", abIconsList[5]);
        abilityList.Add(new IncreasePickupRadius());
        abilityList[6].SetAbility(6, "Increase Pickup radius", abIconsList[6]);

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
            powerUpScreen.SetActive(true);
            //ShuffleAbilities();
            SetRandomPowerButtons();
            Time.timeScale = 0f;
        }


        if (FindObjectOfType<PlayerMovment>().isLevelUp)
        {
        

        } 

    }

    private void SetRandomPowerButtons()
    {
        int firstPower = UnityEngine.Random.Range(0, abilityList.Count);
        int secondPower = UnityEngine.Random.Range(0, abilityList.Count);
        int thirdPower = UnityEngine.Random.Range(0, abilityList.Count);

        while (secondPower == firstPower)
            secondPower = UnityEngine.Random.Range(0, abilityList.Count);
        while (thirdPower == firstPower || thirdPower == secondPower)
            thirdPower = UnityEngine.Random.Range(0, abilityList.Count);

        UnityEngine.Debug.Log("firstPower = " + firstPower);
        UnityEngine.Debug.Log("secondPower = " + secondPower);
        UnityEngine.Debug.Log("thirdPower = " + thirdPower);

        currentFirstAbility = abilityList[firstPower];
        currentSecondAbility = abilityList[secondPower];
        currentThirdAbility = abilityList[thirdPower];

        buttons[0].onClick.AddListener(UseFirstAbility);
        buttons[0].name = currentFirstAbility.abName;
        buttons[0].GetComponentInChildren<Text>().text = currentFirstAbility.abName;
        buttons[0].transform.Find("Icon").GetComponent<Image>().sprite = abIconsList[firstPower];

        buttons[1].onClick.AddListener(UseSecondAbility);
        buttons[1].name = currentSecondAbility.abName;
        buttons[1].GetComponentInChildren<Text>().text = currentSecondAbility.abName;
        buttons[1].transform.Find("Icon").GetComponent<Image>().sprite = abIconsList[secondPower];

        buttons[2].onClick.AddListener(UseThirdAbility);
        buttons[2].name = currentThirdAbility.abName;
        buttons[2].GetComponentInChildren<Text>().text = currentThirdAbility.abName;
        buttons[2].transform.Find("Icon").GetComponent<Image>().sprite = abIconsList[thirdPower];

        FindObjectOfType<PlayerMovment>().isLevelUp = false;
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
        powerUpScreen.SetActive(false);
    }

    public void UseFirstAbility()
    {
        currentFirstAbility.Use();
        powerUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UseSecondAbility()
    {
        currentSecondAbility.Use();
        powerUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UseThirdAbility()
    {
        currentThirdAbility.Use();
        powerUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }


    public class IAbility
    {
        public int abNum;
        public string abName;
        public Sprite abIcon;

        public void SetAbility(int num, string name, Sprite icon)
        {
            abNum = num;
            abName = name;
            abIcon = icon;
        }

        public virtual void Use()
        {
        }
    }

    public class Ability : IAbility
    {

        public override void Use()
        {
           // UnityEngine.Debug.Log("Ability used");
        }
    }
    
    public class IncreaseSpeed : IAbility
    {

        public override void Use()
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

    public class Heal : IAbility
    {
        public override void Use()
        {
            UnityEngine.Debug.Log("Heal used");
            PlayerMovment playerMovment = FindObjectOfType<PlayerMovment>();
            playerMovment.health = playerMovment.health + 50;

        }
    }



    public class FreezeEnemy :  IAbility
    {
        public override void Use()
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

    public class IncreaseEXP : IAbility
    {

        public override void Use()
        {

            PlayerMovment playerMovment = FindObjectOfType<PlayerMovment>();

            playerMovment.xpAmount *= (float)1.1;

            UnityEngine.Debug.Log("IncreaseEXP used");

        }
    }

    public class IncreaseMaxHP : IAbility
    {

        public override void Use()
        {

            PlayerMovment playerMovment = FindObjectOfType<PlayerMovment>();

            playerMovment.health *= (float)1.2;

            UnityEngine.Debug.Log("IncreaseHP used");

        }
    }

    public class IncreaseAxeDamage : IAbility
    {

        public override void Use()
        {

            AxeShooter axeShooter = FindObjectOfType<AxeShooter>();
            
            axeShooter.axeDamage = axeShooter.axeDamage + 10;

            UnityEngine.Debug.Log("IncreaseDamage for axe used");

        }
    }



    public class IncreasePickupRadius : IAbility
    {

        public override void Use()
        {


            PlayerMovment playerMovment = FindObjectOfType<PlayerMovment>();

            playerMovment.pickupRadius = playerMovment.pickupRadius + 1f;


            UnityEngine.Debug.Log("Pickup radius  used");

        }
    }


}
