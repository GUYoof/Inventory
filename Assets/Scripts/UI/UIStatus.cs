using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private Button backButton;

    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider expSlider;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text hpText;
    public TMP_Text criticalText;

    private void Start()
    {
        // 뒤로 가기 버튼 클릭 시 메인 메뉴 열기
        backButton.onClick.AddListener(OnClickBack);
    }

    private void OnClickBack()
    {
        UIManager.Instance.OpenMainMenu();
    }

    public void SetCharacterData(Character character)
    {
        nameText.text = character.Name;
        levelText.text = $"LV. {character.Level}";
        expSlider.value = (float)character.Exp / 12f;
        attackText.text = $"{character.Attack}";
        defenseText.text = $"{character.Defense}";
        hpText.text = $"{character.HP}";
        criticalText.text = $"{character.Critical}";
    }
}
