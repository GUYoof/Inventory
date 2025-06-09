using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private Button backButton;

    public static UIStatus Instance;

    public UIInventory inventory;

    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider expSlider;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text hpText;
    public TMP_Text criticalText;

    private void Awake()
    {
        Instance = this;
    }

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

        UpdateStatTexts(character); // 분리한 함수 호출
    }

    public void UpdateStatTexts(Character character)
    {
        int addAtk = 0, addDef = 0, addHP = 0, addCri = 0;

        if (inventory != null && inventory.slotList != null)
        {
            foreach (var slot in inventory.slotList)
            {
                if (slot.equipped && slot.item != null)
                {
                    switch (slot.item.type)
                    {
                        case ItemType.Weapon: addAtk += slot.item.value; break;
                        case ItemType.Armor:
                        case ItemType.Shield: addDef += slot.item.value; break;
                        case ItemType.Ring: addHP += slot.item.value; break;
                        case ItemType.Amulet: addCri += slot.item.value; break;
                    }
                }
            }
        }

        attackText.text = character.Attack.ToString();
        if (addAtk > 0) attackText.text += $" + {addAtk}";

        defenseText.text = character.Defense.ToString();
        if (addDef > 0) defenseText.text += $" + {addDef}";

        hpText.text = character.HP.ToString();
        if (addHP > 0) hpText.text += $" + {addHP}";

        criticalText.text = character.Critical.ToString();
        if (addCri > 0) criticalText.text += $" + {addCri}";
    }

}
