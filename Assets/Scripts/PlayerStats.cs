using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image health_Stats, stamina_Stats;

    private void Update()
    {
        health_Stats.fillAmount = FindObjectOfType<PlayerMovment>().health / 100f;
        stamina_Stats.fillAmount = FindObjectOfType<PlayerMovment>().xp / 100f;
    }

}
