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
        // 예시용 가짜 인벤토리 목록
        List<ItemData> inventoryItems = InventoryManager.Instance.GetItems();

        // 기존 슬롯 제거
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject); // 기존 슬롯 제거
        }

        slotList.Clear(); // 슬롯 리스트 초기화

        // 새 슬롯 생성 및 UI 갱신
        System.Collections.IList list = inventoryItems;
        for (int i = 0; i < list.Count; i++)
        {
            ItemData item = (ItemData)list[i];
            UISlot slot = Instantiate(slotPrefab, slotParent); // 슬롯 프리팹 인스턴스화
            slot.Set(item);                                    // 슬롯에 아이템 정보 설정
            slotList.Add(slot);                                // 리스트에 추가
        }
    }
}
