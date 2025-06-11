using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    public ItemData itemData;
    
    public Button itemButton;

    private void Start()
    {
        if (itemButton != null)
        {
            itemButton.onClick.AddListener(OnItemClicked);
        }
    }

    /// <summary>
    /// 버튼 클릭 시 실행, 아이템 데이터를 인벤토리에 추가
    /// </summary>
    private void OnItemClicked()
    {
        if (itemData == null)
        {
            return;
        }

        InventoryManager.Instance.AddItem(itemData); // 직접 전달

        Destroy(gameObject);
    }
}
