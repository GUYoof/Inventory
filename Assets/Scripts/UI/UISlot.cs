using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public ItemData item;              // 슬롯에 할당된 아이템 데이터
    public UIInventory inventory;     // 아이템 인벤토리 UI 참조
    public Button button;             // 슬롯에 연결된 버튼 컴포넌트
    public Image icon;                // 아이템 아이콘 이미지
    public TextMeshProUGUI nameText;  // 아이템 이름 텍스트
    public TextMeshProUGUI equipText;  // 아이템 장착확인 텍스트
    public Outline outline;          // 슬롯 외곽선 강조 컴포넌트

    public int index;                 // 슬롯 인덱스
    public bool equipped;             // 아이템 장착 여부

    /// <summary>
    /// 슬롯 초기화 시 Outline 컴포넌트를 가져옴
    /// </summary>
    private void Awake()
    {
        outline = GetComponent<Outline>();

        if (icon == null)
            icon = transform.Find("Icon")?.GetComponent<Image>();

        if (nameText == null)
            nameText = transform.Find("NameText")?.GetComponent<TextMeshProUGUI>();

        if (button == null)
            button = GetComponent<Button>();

        // inventory 자동 할당 시도
        if (inventory == null)
        {
            inventory = GetComponentInParent<UIInventory>();
        }
    }

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(Equip);
        }
        else
        {
        }
    }

    /// <summary>
    /// 슬롯이 활성화될 때 장착 상태에 따라 Outline 활성화
    /// </summary>
    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    /// <summary>
    /// 슬롯에 아이템 정보를 설정하고 UI 갱신
    /// </summary>
    public void Set(ItemData item)
    {
        this.item = item;

        if (item == null)
        {
            Clear();
            return;
        }

        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;

        if (nameText != null)
            nameText.text = item.itemName;
        else

        if (outline != null)
            outline.enabled = equipped;
    }

    /// <summary>
    /// 슬롯 정보를 초기화하고 UI를 비움
    /// </summary>
    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        nameText.text = string.Empty;
    }

    public void Equip()
    {
        if (item == null || inventory == null)
        {
            return;
        }

        // 같은 타입의 장착 아이템이 있으면 해제
        foreach (var otherSlot in inventory.slotList)
        {
            if (otherSlot != this &&
                otherSlot.item != null &&
                otherSlot.item.type == this.item.type &&
                otherSlot.equipped)
            {
                otherSlot.equipped = false;

                if (otherSlot.outline != null)
                    otherSlot.outline.enabled = false;

                if (otherSlot.equipText != null)
                    otherSlot.equipText.gameObject.SetActive(false);
            }
        }

        // 현재 슬롯 장착/해제 토글
        equipped = !equipped;


        if (outline != null)
            outline.enabled = equipped;

        if (equipText != null)
            equipText.gameObject.SetActive(equipped);

        // 선택된 슬롯 인덱스를 인벤토리에 전달
        inventory.selectedIndex = this.index;

        // 장비 변경 후 스탯 갱신
        if (UIStatus.Instance != null)
        {
            // 현재 캐릭터는 어디 저장되어 있든 간에 불러와야 합니다
            // 예시로 GameManager에서 불러오는 식:
            Character currentChar = GameManager.Instance.Player;
            UIStatus.Instance.UpdateStatTexts(currentChar);
        }
    }
}
