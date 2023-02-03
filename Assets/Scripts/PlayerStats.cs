using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image health_Stats, stamina_Stats;
    
    [SerializeField]
    private TMP_Text level_Text;

    private void Update()
    {
        health_Stats.fillAmount = FindObjectOfType<PlayerMovment>().health / 100f;
        stamina_Stats.fillAmount = FindObjectOfType<PlayerMovment>().xp / 100f;
        
        if(level_Text.text != FindObjectOfType<PlayerMovment>().level.ToString())
        {
            level_Text.text = FindObjectOfType<PlayerMovment>().level.ToString();
        }
    }

}
