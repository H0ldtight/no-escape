using TMPro;
using UnityEngine;

public class PopupBank : MonoBehaviour
{
    [SerializeField]
    public UserData userData;

    public GameObject Insufficient;
    public GameObject ATM;
    public GameObject Deposit;
    public GameObject Withdraw;

    void Start()
    {
        // 시작시, 창 UI 비활성화
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        Insufficient.SetActive(false);
    }
    public void SetUserData(UserData data)
    {
        userData = data;
    }
    
    public void InputDepositButtonAction()
    {
        // 하위 개체에서 TMP_InputField 컴포넌트를 찾아 변수에 할당
        TMP_InputField inputField = GetComponentInChildren<TMP_InputField>();
        // 쉼표 제거 후 textValue에 저장
        string textValue = inputField.text.Replace(",", "");
        int.TryParse(textValue, out int value);
        DepositProcess(value);
    }

    public void DepositProcess(int value)
    {
        if (value <= userData.userCash)
        {
            userData.userBalance += value;
            userData.userCash -= value;
        }
        else
        {   
            // 범위를 초과할 경우, 값을 저장하지 않고 경고창 출력
            Insufficient.SetActive(true);
            return;
        }
        GameManager.Instance.SaveUserData();
        GameManager.Instance.Refresh();
    }

    public void InputWithdrawButtonAction()
    {
        TMP_InputField inputField = GetComponentInChildren<TMP_InputField>();
        string textValue = inputField.text.Replace(",", "");
        int.TryParse(textValue, out int value);
        WithdrawProcess(value);
    }

    public void WithdrawProcess(int value)
    {
        if (value <= userData.userBalance)
        {
            userData.userBalance -= value;
            userData.userCash += value;
        }
        else
        {
            Insufficient.SetActive(true);
            return;
        }
        GameManager.Instance.SaveUserData();
        GameManager.Instance.Refresh();
    }

    public void DepositToggleButton()
    {

        ATM.SetActive(false);
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
    }

    public void WithdrawToggleButton()
    {

        ATM.SetActive(false);
        Withdraw.SetActive(true);
        Deposit.SetActive(false);
    }

    public void BackButtonAction()
    {

        ATM.SetActive(true);
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
    }

    public void InsufficientButtonAction()
    {
        Insufficient.SetActive(false);
    }
    
}


