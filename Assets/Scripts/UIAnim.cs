using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnim : MonoBehaviour
{
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.2f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.5f).setEaseInBack();
    }
}
