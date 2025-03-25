using UnityEngine;
using TMPro;  // TextMeshPro�� ����ϱ� ���� ���ӽ����̽�

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    // UserData ��ü�� public���� �����Ͽ� �ν����Ϳ��� ������ Ȯ�� ����
    public UserData userData;
    public PopupBank popupBank;

    // TextMeshProUGUI ������Ʈ�� UI���� ������ ����
    public TextMeshProUGUI userName;    // ���� �̸� ǥ��
    public TextMeshProUGUI userCash;        // ���� ǥ��
    public TextMeshProUGUI userBalance;     // ���� �ܾ� ǥ��
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    

    private void Start()
    {
        userData = new UserData("������", 100000, 50000);
        popupBank.SetUserData(userData);
        Refresh();
    }
    public void SetUserData(UserData data)
    {
        userData = data;
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
