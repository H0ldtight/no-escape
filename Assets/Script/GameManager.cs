using UnityEngine;
using TMPro;
using System.IO;// TextMeshPro�� ����ϱ� ���� ���ӽ����̽�

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    // UserData ��ü�� public���� �����Ͽ� �ν����Ϳ��� ������ Ȯ�� ����
    public UserData userData;
    public PopupBank popupBank;
    static string folderPath => Path.Combine(Application.dataPath, "UserData");
    static string fileName = "userData.json";
    string filePath => Path.Combine(folderPath, fileName);


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
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        if (!File.Exists(filePath))
        {
            userData = new UserData("������", 100000, 50000);
            SaveUserData();  // ������ ����
        }
        LoadUserData();
        popupBank.SetUserData(userData);
        Refresh();
    }

    public void SetUserData(UserData data)
    {
        userData = data;
    }

    public void SaveUserData()
    {
        // UserData ��ü�� JSON ���ڿ��� ��ȯ
        string jsonData = JsonUtility.ToJson(userData);

        // JSON ���ڿ��� ���Ͽ� ����
        File.WriteAllText(filePath, jsonData);
        Debug.Log("UserData�� ����Ǿ����ϴ�: " + filePath);
    }

    public void LoadUserData()
    {
        // UserData ��ü�� JSON ���ڿ��� ��ȯ
        string jsonData = File.ReadAllText(filePath);
        userData = JsonUtility.FromJson<UserData>(jsonData);
        Debug.Log("UserData�� ȣ��Ǿ����ϴ�: " + filePath);
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
