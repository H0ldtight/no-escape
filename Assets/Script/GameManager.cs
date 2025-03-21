using UnityEngine;
using TMPro;  // TextMeshPro�� ����ϱ� ���� ���ӽ����̽�

public class GameManager : MonoBehaviour
{
    // UserData ��ü�� public���� �����Ͽ� �ν����Ϳ��� ������ Ȯ�� ����
    public UserData userData;

    // TextMeshProUGUI ������Ʈ�� UI���� ������ ����
    public TextMeshProUGUI userName;    // ���� �̸� ǥ��
    public TextMeshProUGUI userCash;        // ���� ǥ��
    public TextMeshProUGUI userBalance;     // ���� �ܾ� ǥ��

    private void Start()
    {
        // �ʱ� ������ ���� (����)
        userData = new UserData("Player1", 1000, 5000);

        // ������ �ʱ�ȭ �� UI�� �ݿ�
        RefreshUI();
    }

    // UI�� �����͸� �ݿ��ϴ� �޼���
    public void RefreshUI()
    {
        // TextMeshProUGUI ������Ʈ�� ���� ������ ���
        if (userName != null)
            userName.text = "Name: " + userData.userName;

        if (userCash != null)
            userCash.text = "Cash: " + userData.userCash.ToString("C0");  // ������ ��ȭ �������� ���

        if (userBalance != null)
            userBalance.text = "Balance: " + userData.userBalance.ToString("C0");  // ���� �ܾ��� ��ȭ �������� ���
    }
}
