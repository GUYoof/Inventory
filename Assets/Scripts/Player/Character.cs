using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 정보 및 아이템 장착/해제 처리
/// </summary>
public class Character : MonoBehaviour
{
    public string Name { get; private set; }         // 캐릭터 이름
    public int Level { get; private set; }           // 레벨
    public int Exp { get; private set; }             // 경험치
    public int Attack { get; private set; }          // 공격력
    public int Defense { get; private set; }         // 방어력
    public int HP { get; private set; }              // 체력
    public int Critical { get; private set; }        // 치명타 확률

    public List<InventoryItem> Inventory { get; private set; }  // 인벤토리

    // 캐릭터 생성자
    public Character(string name, int level, int exp, int attack, int defense, int hp, int critical)
    {
        Name = name;
        Level = level;
        Exp = exp;
        Attack = attack;
        Defense = defense;
        HP = hp;
        Critical = critical;
        Inventory = new List<InventoryItem>();
    }

    // 아이템 추가
    public void AddItem(ItemData item)
    {
        Inventory.Add(new InventoryItem(item));
    }

    // 아이템 장착
    public void Equip(ItemData item)
    {
        var invItem = Inventory.Find(i => i.Data == item);
        if (invItem != null && !invItem.IsEquipped)
        {
            invItem.IsEquipped = true;   // 장착 상태로 변경
            ApplyStat(invItem.Data, +1); // 능력치 적용
        }
    }

    // 아이템 해제
    public void UnEquip(ItemData item)
    {
        var invItem = Inventory.Find(i => i.Data == item);
        if (invItem != null && invItem.IsEquipped)
        {
            invItem.IsEquipped = false;  // 해제 상태로 변경
            ApplyStat(invItem.Data, -1); // 능력치 회복
        }
    }

    // 능력치 적용 처리
    private void ApplyStat(ItemData item, int modifier)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                Attack += item.value * modifier;      // 공격력 변화
                break;
            case ItemType.Shield:
                Defense += item.value * modifier;     // 방어력 변화
                break;
            case ItemType.Ring:
                HP += item.value * modifier;          // 체력 변화
                break;
            case ItemType.Amulet:
                Critical += item.value * modifier;    // 치명타 변화
                break;
        }
    }
}
