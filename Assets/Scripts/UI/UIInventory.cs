using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIInventory : MonoBehaviour
{
    public static UIInventory Instance;

    [Header("UI 기본정보")]
    [SerializeField] private Button backButton;                  // 뒤로 가기 버튼
    [SerializeField] private TMP_Text nameText;                  // 캐릭터 이름 텍스트
    [SerializeField] private TMP_Text levelText;                 // 캐릭터 레벨 텍스트
    [SerializeField] private Slider expSlider;                   // 경험치 슬라이더

    [Header("슬롯 관련")]
    [SerializeField] private UISlot slotPrefab;                  // 슬롯 프리팹
    [SerializeField] private Transform slotParent;               // 슬롯이 배치될 부모 오브젝트 (Content 오브젝트)

    public List<UISlot> slotList = new List<UISlot>();          // 현재 생성된 슬롯 리스트

    public int selectedIndex = -1;

    private void Awake()
    {
        Instance = this;
    }

    // 초기화 시 UI 버튼 이벤트 설정 및 인벤토리 UI 초기화
    private void Start()
    {
        backButton.onClick.AddListener(OnClickBack);             // 뒤로가기 버튼 클릭 시 처리
        InitInventoryUI();                                       // 인벤토리 슬롯 초기화
    }

    /// <summary>
    /// 뒤로가기 버튼 클릭 시 메인 메뉴 UI 열기
    /// </summary>
    private void OnClickBack()
    {
        UIManager.Instance.OpenMainMenu();
    }

    /// <summary>
    /// 전달받은 캐릭터 데이터를 UI에 표시
    /// </summary>
    /// <param name="character">캐릭터 데이터</param>
    public void SetCharacterData(Character character)
    {
        nameText.text = character.Name;                          // 이름 표시
        levelText.text = $"LV. {character.Level}";               // 레벨 표시
        expSlider.value = (float)character.Exp / 12f;            // 경험치 슬라이더 설정

        InitInventoryUI(); // 인벤토리 UI 갱신 호출
    }

    /// <summary>
    /// 인벤토리 아이템 목록을 받아 슬롯 UI를 동적으로 생성
    /// </summary>
    public void InitInventoryUI()
    {
        // 장착된 아이템 임시 저장
        Dictionary<ItemType, ItemData> equippedItems = new Dictionary<ItemType, ItemData>();
        foreach (var slot in slotList)
        {
            if (slot.item != null && slot.equipped)
            {
                equippedItems[slot.item.type] = slot.item;
            }
        }

        // 기존 슬롯 제거
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        slotList.Clear(); // 슬롯 리스트 초기화

        // 새 슬롯 생성
        List<ItemData> inventoryItems = InventoryManager.Instance.GetItems();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            ItemData item = inventoryItems[i];
            UISlot slot = Instantiate(slotPrefab, slotParent);
            slot.index = i;
            slot.Set(item);

            // 복원: 동일 타입의 아이템이 장착 중이었다면
            if (equippedItems.TryGetValue(item.type, out var equippedItem) && equippedItem == item)
            {
                slot.equipped = true;
                slot.outline.enabled = true;
                if (slot.equipText != null)
                    slot.equipText.gameObject.SetActive(true);
            }

            slotList.Add(slot);
        }
    }

}
