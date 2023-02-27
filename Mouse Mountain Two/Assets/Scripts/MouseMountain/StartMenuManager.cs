using UnityEngine;
using UnityEngine.SceneManagement;

namespace MouseMountain
{
    public class StartMenuManager : MonoBehaviour
    {
        public void ClickStartButton()
        {
            AudioManager.Instance.PlayFX();
            SceneManager.LoadScene(1);
        }
    }
}
