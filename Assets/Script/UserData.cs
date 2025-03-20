
using Unity.VisualScripting;
using UnityEngine;
public class UserData : MonoBehaviour
{
    
    public string userName { get; set; } = "";
    public int userCash { get; set; } = 0;
    public int userBalance { get; set; } = 0;
    
    public UserData(string name, int cash, int balance)
    {
        userName = name;
        userCash = balance;
        userBalance = balance;
    }

}
