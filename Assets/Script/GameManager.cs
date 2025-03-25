using UnityEngine;
using TMPro;  // TextMeshPro를 사용하기 위한 네임스페이스

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    // UserData 객체를 public으로 설정하여 인스펙터에서 데이터 확인 가능
    public UserData userData;
    public PopupBank popupBank;

    // TextMeshProUGUI 컴포넌트를 UI에서 참조할 변수
    public TextMeshProUGUI userName;    // 유저 이름 표시
    public TextMeshProUGUI userCash;        // 현금 표시
    public TextMeshProUGUI userBalance;     // 통장 잔액 표시
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    

    private void Start()
    {
        userData = new UserData("오우택", 100000, 50000);
        popupBank.SetUserData(userData);
        Refresh();
    }
    public void SetUserData(UserData data)
    {
        userData = data;
    }

    // UI에 데이터를 반영하는 메서드
    public void Refresh()
    {
        
        if (userName != null && userCash != null && userBalance != null)
        {
            userName.text = userData.userName;
            userCash.text = userData.userCash.ToString("N0");
            userBalance.text = userData.userBalance.ToString("N0");
        }
    }
}
