using UnityEngine;

public class EndGame : MonoBehaviour
{
    public void Close()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
