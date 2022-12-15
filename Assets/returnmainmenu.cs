
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnmainmenu : MonoBehaviour
{
    public void ReturnToFirstScene()
    {
        SceneManager.LoadScene(0);
    }
}