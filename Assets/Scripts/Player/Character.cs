using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name { get; private set; }         // 캐릭터 이름
    public int Level { get; private set; }           // 레벨
    public int Exp { get; private set; }             // 경험치
    public int Attack { get; private set; }          // 공격력
    public int Defense { get; private set; }         // 방어력
    public int HP { get; private set; }              // 체력
    public int Critical { get; private set; }        // 치명타

    public Character(string name, int level, int exp, int attack, int defense, int hp, int critical)
    {
        Name = name;
        Level = level;
        Exp = exp;
        Attack = attack;
        Defense = defense;
        HP = hp;
        Critical = critical;
    }
}

