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
        // ���۽�, â UI ��Ȱ��ȭ
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
        // ���� ��ü���� TMP_InputField ������Ʈ�� ã�� ������ �Ҵ�
        TMP_InputField inputField = GetComponentInChildren<TMP_InputField>();
        // ��ǥ ���� �� textValue�� ����
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
            // ������ �ʰ��� ���, ���� �������� �ʰ� ���â ���
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


