using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Character Player { get; private set; }

    public UIMainMenu uiMainMenu;
    public UIStatus uiStatus;
    public UIInventory uiInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SetData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SetData()
    {
        Player = new Character("Chad", 10, 9, 15, 10, 100, 5);

        // Resources 폴더에서 아이템 ScriptableObject 불러오기
        ItemData Sword = Resources.Load<ItemData>("Items/Sword");
        ItemData Shield = Resources.Load<ItemData>("Items/Shield");

        // 아이템을 플레이어 인벤토리에 추가
        Player.AddItem(Sword);
        Player.AddItem(Shield);

        // UI에 데이터 전달
        uiMainMenu.SetCharacterData(Player);
        uiStatus.SetCharacterData(Player);
        uiInventory.SetCharacterData(Player);
    }

}
