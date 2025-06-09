using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // 싱글톤 인스턴스

    private List<ItemData> items = new List<ItemData>(); // 인벤토리 아이템 리스트

    /// <summary>
    /// 싱글톤 인스턴스 설정 및 테스트 아이템 추가
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadItems(); // 아이템 로드
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Resources 폴더에서 아이템을 불러와 인벤토리에 추가
    /// </summary>
    private void LoadItems()
    {
        ItemData shield = Resources.Load<ItemData>("Items/Shield");
        ItemData sword = Resources.Load<ItemData>("Items/Sword");

        if (shield != null) items.Add(shield);
        if (sword != null) items.Add(sword);
    }

    /// <summary>
    /// 현재 인벤토리의 모든 아이템을 반환
    /// </summary>
    public List<ItemData> GetItems()
    {
        return items;
    }

    public void AddItem(ItemData itemData)
    {
        items.Add(itemData);  // 아이템 리스트에 추가
        UIInventory.Instance.InitInventoryUI();  // UI 갱신
    }
}
