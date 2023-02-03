using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
   [SerializeField] public int hp;
    [SerializeField] public int attack;
    [SerializeField] public Sprite sprite;
}