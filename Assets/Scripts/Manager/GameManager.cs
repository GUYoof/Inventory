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
        // 예시 캐릭터 생성
        Player = new Character("Chad", 10, 9, 15, 10, 100, 5);

        // UI에 데이터 전달
        uiMainMenu.SetCharacterData(Player);
        uiStatus.SetCharacterData(Player);
        uiInventory.SetCharacterData(Player);
    }
}
