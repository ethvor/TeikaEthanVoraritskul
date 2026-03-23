using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void goToMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
