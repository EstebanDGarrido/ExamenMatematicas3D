using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DrawingBoard : MonoBehaviour
{
    [Header("UI")]
    [Header("Texture Settings")]
    [Header("Brush Settings")]
    public RawImage rawImage;
    private Texture2D texture;
    public Color drawColor = Color.black;
    private Vector2 lastDrawPosition;
    public int textureWidth = 512;
    public int textureHeight = 512;
    public int brushSize = 5;
    private bool isDrawing = false;

    void Start()
    {
        texture = new Texture2D(textureWidth, textureHeight, TextureFormat.RGBA32, false);
        texture.filterMode = FilterMode.Point;
        ClearBoard();
        rawImage.texture = texture;
    }

    void Update()
    {
        if (Mouse.current == null) return;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            isDrawing = true;
            lastDrawPosition = Mouse.current.position.ReadValue();
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDrawing = false;
        }
        if (isDrawing)
        {
            Draw();
        }
    }

    void Draw()
    {
        Vector2 currentMousePosition = Mouse.current.position.ReadValue();
        DrawLine(lastDrawPosition, currentMousePosition);
        lastDrawPosition = currentMousePosition;
    }

    void DrawLine(Vector2 start, Vector2 end)
    {
        float distance = Vector2.Distance(start, end);
        int steps = Mathf.CeilToInt(distance);
        for (int i = 0; i < steps; i++)
        {
            float t = i / (float)steps;
            Vector2 point = Vector2.Lerp(start, end, t);
            DrawAt(point);
        }
    }

    void DrawAt(Vector2 screenPosition)
    {
        Vector2 localPoint;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rawImage.rectTransform,
            screenPosition,
            null,
            out localPoint))
            return;
        Rect rect = rawImage.rectTransform.rect;
        float x = (localPoint.x - rect.x) / rect.width;
        float y = (localPoint.y - rect.y) / rect.height;
        int texX = Mathf.FloorToInt(x * textureWidth);
        int texY = Mathf.FloorToInt(y * textureHeight);
        for (int i = -brushSize; i <= brushSize; i++)
        {
            for (int j = -brushSize; j <= brushSize; j++)
            {
                int px = texX + i;
                int py = texY + j;
                if (px >= 0 && px < textureWidth && py >= 0 && py < textureHeight)
                {
                    if (i * i + j * j <= brushSize * brushSize)
                    {
                        texture.SetPixel(px, py, drawColor);
                    }
                }
            }
        }
        texture.Apply();
    }

    public void ClearBoard()
    {
        Color[] pixels = new Color[textureWidth * textureHeight];
        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = Color.white;
        }
        texture.SetPixels(pixels);
        texture.Apply();
    }
}