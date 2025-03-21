using UnityEngine;
using TMPro;  // TextMeshPro를 사용하기 위한 네임스페이스

public class GameManager : MonoBehaviour
{
    // UserData 객체를 public으로 설정하여 인스펙터에서 데이터 확인 가능
    public UserData userData;

    // TextMeshProUGUI 컴포넌트를 UI에서 참조할 변수
    public TextMeshProUGUI userName;    // 유저 이름 표시
    public TextMeshProUGUI userCash;        // 현금 표시
    public TextMeshProUGUI userBalance;     // 통장 잔액 표시

    private void Start()
    {
        // 초기 데이터 설정 (예시)
        userData = new UserData("Player1", 1000, 5000);

        // 데이터 초기화 후 UI에 반영
        RefreshUI();
    }

    // UI에 데이터를 반영하는 메서드
    public void RefreshUI()
    {
        // TextMeshProUGUI 컴포넌트를 통해 데이터 출력
        if (userName != null)
            userName.text = "Name: " + userData.userName;

        if (userCash != null)
            userCash.text = "Cash: " + userData.userCash.ToString("C0");  // 현금을 통화 형식으로 출력

        if (userBalance != null)
            userBalance.text = "Balance: " + userData.userBalance.ToString("C0");  // 통장 잔액을 통화 형식으로 출력
    }
}
