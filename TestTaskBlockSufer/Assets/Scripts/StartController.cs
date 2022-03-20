using UnityEngine;

public class StartController : MonoBehaviour
{
    public bool isGameStart;
    public GameObject startScreen;
    private void Start()
    {
        isGameStart = false;
    }

    public void StartGame()
    {
        isGameStart = true;
        startScreen.SetActive(false);
    }
}
