using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public int hp;
    public int attack;
    public Sprite sprite;
}