using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager: MonoBehaviour
{
    public GameObject ATM;
    public GameObject Deposit;

    [SerializeField]
    public GameObject Withdraw;// 변경할 UI 요소
    public Button SelectDeposit;
    public Button SelectWithdraw;// 버튼

    void Start()
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        // 버튼 클릭 이벤트에 함수 연결
        SelectDeposit.onClick.AddListener(DepositButton);
        SelectWithdraw.onClick.AddListener(WithdrawButton);

        Button[] buttons = GameObject.FindObjectsOfType<Button>(true);
        foreach (Button button in buttons)
        {
            if (button.name == "BackButton")
            {
                button.onClick.AddListener(BackButton);
            }
        }
    }

    // UI 요소의 활성화 상태를 토글하는 함수
    void DepositButton()
    {
        ATM.SetActive(false);
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
    }

    void WithdrawButton()
    {
        ATM.SetActive(false);
        Withdraw.SetActive(true);
        Deposit.SetActive(false);
    }

    void BackButton()
    {
        ATM.SetActive(true);
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
    }
}
