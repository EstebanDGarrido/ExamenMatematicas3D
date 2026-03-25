using UnityEngine;

public class BoardToggle : MonoBehaviour
{
    public GameObject drawingPanel;

    public void ToggleBoard()
    {
        drawingPanel.SetActive(!drawingPanel.activeSelf);
    }
}