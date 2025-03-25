using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    [SerializeField]
    public UserData userData;

    public GameObject Insufficient;
    public GameObject ATM;
    public GameObject Deposit;
    public GameObject Withdraw;

    private GameObject clickedButton;

    void Start()
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        Insufficient.SetActive(false);
        clickedButton = null;
    }

    public void SetUserData(UserData data)
    {
        userData = data;
    }
    private void SetClickedButton()
    {
        clickedButton = EventSystem.current.currentSelectedGameObject;
    }

    // UI 요소의 활성화 상태를 토글하는 함수
    public void DepositButtonAction(int value)
    {
        SetClickedButton();
        DepositProcess(value);
    }

    public void InputDepositButtonAction()  // 인스펙터에서 연결할 함수
    {
        SetClickedButton();
        TMP_InputField inputField = clickedButton.GetComponentInChildren<TMP_InputField>();
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
            Insufficient.SetActive(true);
        }
        GameManager.Instance.SaveUserData();
        GameManager.Instance.Refresh();
    }

    public void DepositToggleButton()
    {
        SetClickedButton();
        ATM.SetActive(false);
        Deposit.SetActive(true);
        Withdraw.SetActive(false);
    }

    public void WithdrawToggleButton()
    {
        SetClickedButton();
        ATM.SetActive(false);
        Withdraw.SetActive(true);
        Deposit.SetActive(false);
    }

    public void BackButtonAction()
    {
        SetClickedButton();
        ATM.SetActive(true);
        Deposit.SetActive(false);
        Withdraw.SetActive(false);
    }

    public void InsufficientButtonAction()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Insufficient.SetActive(false);
    }
    
}


