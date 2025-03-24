using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager: MonoBehaviour
{
    public GameObject ATM;
    public GameObject Deposit;

    [SerializeField]
    public GameObject Withdraw;// ������ UI ���
    public Button SelectDeposit;
    public Button SelectWithdraw;// ��ư

    void Start()
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
        // ��ư Ŭ�� �̺�Ʈ�� �Լ� ����
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

    // UI ����� Ȱ��ȭ ���¸� ����ϴ� �Լ�
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
