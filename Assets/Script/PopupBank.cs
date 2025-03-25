using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank: MonoBehaviour
{
    [SerializeField]

    public UserData userData;

    public GameObject Insufficient;
    public GameObject ATM;
    public GameObject Deposit;
    public GameObject Withdraw;

    public Button SelectDeposit;
    public Button SelectWithdraw;// ��ư


    void Start()
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        Insufficient.SetActive(false);

        // ��ư Ŭ�� �̺�Ʈ�� �Լ� ����
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

                button.onClick.AddListener(() => DepositButton(button));
            }

            if (button.CompareTag("InputDeposit"))
            {

                button.onClick.AddListener(() => InputDepositButton(button));
            }

            if (button.CompareTag("Withdraw"))
            {

                //button.onClick.AddListener(WithdrawButton);
            }
            if (button.CompareTag("Insufficient"))
            {
                button.onClick.AddListener(InsufficientButton);
            }
        }
    }


    // UI ����� Ȱ��ȭ ���¸� ����ϴ� �Լ�
    void DepositToggleButton()
    {
        ATM.SetActive(false);
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
    }
    public void SetUserData(UserData data)
    {
        userData = data;
    }

    void DepositButton(Button button)
    {
        TMP_Text tmpText = button.GetComponentInChildren<TMP_Text>();
        DepositProcess(tmpText.text);
    }

    void InputDepositButton(Button button)
    {
        TMP_InputField InputField = button.GetComponentInChildren<TMP_InputField>();
        // userData�� �ݿ�
        DepositProcess(InputField.text);
    }
    
    void DepositProcess(string textValue)
    {
        textValue = textValue.Replace(",", ""); // �޸� ����
        int value;
        int.TryParse(textValue, out value);
        if (value <= userData.userCash)
        {
            userData.userBalance += value;
            userData.userCash -= value;
        }
        else
        {
            Insufficient.SetActive(true);
        }
        GameManager.Instance.Refresh();
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

    void InsufficientButton()
    {
        Insufficient.SetActive(false);
    }
}
