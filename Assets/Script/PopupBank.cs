using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PopupBank: MonoBehaviour
{
    public GameObject ATM;
    public GameObject Deposit;
    public GameManager userData;
    [SerializeField]
    public GameObject Withdraw;// 변경할 UI 요소
    public Button SelectDeposit;
    public Button SelectWithdraw;// 버튼

    void Start()
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        // 버튼 클릭 이벤트에 함수 연결
        SelectDeposit.onClick.AddListener(DepositToggleButton);
        SelectWithdraw.onClick.AddListener(WithdrawToggleButton);

        Button[] buttons = GameObject.FindObjectsOfType<Button>(true);
        foreach (Button button in buttons)
        {
            if (button.CompareTag("Back"))
            {
                button.onClick.AddListener(BackButton);
            }

            if (button.CompareTag("Deposit"))
            {

                button.onClick.AddListener(DepositButton);
            }

            if (button.CompareTag("Withdraw"))
            {

                button.onClick.AddListener(BackButton);
            }
        }
    }


    // UI 요소의 활성화 상태를 토글하는 함수
    void DepositToggleButton()
    {
        ATM.SetActive(false);
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
    }

    void DepositToggleButton()
    {
        Text buttonText = button.GetComponentInChildren<Text>();
        // userData에 반영
        userData += value;

    }

    void WithdrawToggleButton()
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
