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
        userData = new UserData("������", 100000, 50000);
        Refresh();
    }

    // UI�� �����͸� �ݿ��ϴ� �޼���
    public void Refresh()
    {
        if (userName != null && userCash != null && userBalance != null)
        {
            userName.text = userData.userName;
            userCash.text = userData.userCash.ToString("N0");
            userBalance.text = userData.userBalance.ToString("N0");
        }
    }
}
