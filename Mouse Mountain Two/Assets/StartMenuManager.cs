using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{

    public void ClickStartButton()
    {
        SceneManager.LoadScene(1);
    }
}
