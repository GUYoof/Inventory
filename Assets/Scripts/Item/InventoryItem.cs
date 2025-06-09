using UnityEngine;
/// <summary>
/// 인벤토리에 들어가는 실제 아이템 + 장착 여부 저장용 클래스
/// </summary>
public class InventoryItem
{
    public ItemData Data;      // 아이템 정보
    public bool IsEquipped;    // 장착 여부

    public InventoryItem(ItemData data)
    {
        Data = data;
        IsEquipped = false;
    }
}
