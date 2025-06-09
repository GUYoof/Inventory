using UnityEngine;

public enum ItemType
{
    Weapon,     // 공격력 (ATK)
    Armor,      // 방어력 (DEF)
    Shield,     // 방어력 (DEF)
    Ring,       // 체력 (HP)
    Amulet      // 치명타 확률 (CRI)
}

/// <summary>
/// 아이템 정보 ScriptableObject
/// </summary>
[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string itemName;    // 아이템 이름
    public Sprite icon;         // 아이템 아이콘
    public ItemType type;      // 아이템 타입
    public int value;          // 능력치 수치 (타입에 따라 다르게 적용됨)
}
