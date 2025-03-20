using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;
    public UserData userData;

    public void SetUserData()
    {
        userData = new UserData("ø¿øÏ≈√", 100000, 50000);
    }

    // Start is called before the first frame update
    void Start()
    {
        // SetUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
