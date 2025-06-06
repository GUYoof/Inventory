using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 메인 메뉴 UI에서 버튼 입력을 처리하는 클래스.
/// </summary>
public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider expSlider;

    private void Start()
    {
        // 버튼에 클릭 이벤트 등록
        statusButton.onClick.AddListener(OnClickStatus);
        inventoryButton.onClick.AddListener(OnClickInventory);
    }

    private void OnClickStatus()
    {
        // UIManager를 통해 상태 보기 UI 열기
        UIManager.Instance.OpenStatus();
    }

    private void OnClickInventory()
    {
        // UIManager를 통해 인벤토리 UI 열기
        UIManager.Instance.OpenInventory();
    }

    public void SetCharacterData(Character character)
    {
        nameText.text = character.Name;
        levelText.text = $"LV. {character.Level}";
        expSlider.value = (float)character.Exp / 12f;
    }
}
