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
    public GameObject Withdraw;// ������ UI ���
    public Button SelectDeposit;
    public Button SelectWithdraw;// ��ư

    void Start()
    {
        Withdraw.SetActive(false);
        Deposit.SetActive(false);
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

                button.onClick.AddListener(DepositButton);
            }

            if (button.CompareTag("Withdraw"))
            {

                button.onClick.AddListener(BackButton);
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

    void DepositToggleButton()
    {
        Text buttonText = button.GetComponentInChildren<Text>();
        // userData�� �ݿ�
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
