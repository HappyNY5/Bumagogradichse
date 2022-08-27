using UnityEngine;

public class UIAnimBack : MonoBehaviour
{
    private CanvasGroup back;
    void Start()
    {
        back = transform.GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        back.LeanAlpha(0.7f, 0.2f);
    }

    public void Close()
    {
        back.LeanAlpha(0, 0.2f);
    }
}
