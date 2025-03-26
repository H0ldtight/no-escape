using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    // UserData 객체를 public으로 설정하여 인스펙터에서 데이터 확인 가능

    public UserData userData;
    public PopupBank popupBank;
    static string folderPath => Path.Combine(Application.dataPath, "UserData");
    // 폴더 경로 > no-escape\Assets\UserData
    static string fileName = "userData.json";
    string filePath => Path.Combine(folderPath, fileName);


    public TextMeshProUGUI userName;        // 유저 이름
    public TextMeshProUGUI userCash;        // 현금
    public TextMeshProUGUI userBalance;     // 통장 잔액
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    private void Start()
    {
        if (!Directory.Exists(folderPath))      // 폴더가 경로상에 없으면 폴더 생성
        {
            Directory.CreateDirectory(folderPath);
        }
        if (!File.Exists(filePath))             // 파일이 경로상에 없으면 기본값 설정 후 생성
        {
            userData = new UserData("오우택", 100000, 50000);
            SaveUserData();                     // 파일 저장
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
        string jsonData = JsonUtility.ToJson(userData);

        // JSON 문자열을 파일에 저장
        File.WriteAllText(filePath, jsonData);
        Debug.Log("저장되었습니다." + filePath);
    }

    public void LoadUserData()
    {
        // UserData 객체를 JSON 문자열로 변환
        string jsonData = File.ReadAllText(filePath);
        userData = JsonUtility.FromJson<UserData>(jsonData);
        Debug.Log("호출되었습니다: " + filePath);
    }
    

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
