using UnityEngine;

public class UserDataManager: MonoBehaviour
{
    /**PlayerController�μ� �ʿ��� ������ �޼��尡 �ִ� **/
    public UserData userData;
}

[System.Serializable]
public class UserData
{
    public string userName;
    public int userCash;
    public int userBalance;
    
    public UserData(string name, int cash, int balance)
    {
        userName = name;
        userCash = cash;
        userBalance = balance;
    }

}
