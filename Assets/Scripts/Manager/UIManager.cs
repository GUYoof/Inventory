using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    public static UIManager Instance { get; private set; }

    [Header("UI 패널 오브젝트")]
    [SerializeField] private GameObject uiMainMenu;   // 메인 메뉴 UI 패널
    [SerializeField] private GameObject uiStatus;     // 상태 보기 UI 패널
    [SerializeField] private GameObject uiInventory;  // 인벤토리 UI 패널

    // 외부에서 읽기 가능한 프로퍼티
    public GameObject UIMainMenu => uiMainMenu;
    public GameObject UIStatus => uiStatus;
    public GameObject UIInventory => uiInventory;

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 중복 방지
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        OpenMainMenu();
    }

    /// <summary>
    /// 뒤로가기 기능 또는 초기 진입 시 사용
    /// </summary>
    public void OpenMainMenu()
    {
        uiMainMenu.SetActive(true);
        uiStatus.SetActive(false);
        uiInventory.SetActive(false);
    }

    /// <summary>
    /// 메인 메뉴의 'Status' 버튼에서 호출
    /// </summary>
    public void OpenStatus()
    {
        uiMainMenu.SetActive(false);
        uiStatus.SetActive(true);
    }

    /// <summary>
    /// 메인 메뉴의 '인벤토리' 버튼에서 호출
    /// </summary>
    public void OpenInventory()
    {
        uiMainMenu.SetActive(false);
        uiInventory.SetActive(true);
    }
}
