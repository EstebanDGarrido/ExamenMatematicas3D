using UnityEngine;
using TMPro;

public class AnswerObject : MonoBehaviour
{
    private QuestionManager questionManager;
    public TextMeshPro textMesh;
    public string answerText;
    public bool isCorrect;

    void Start()
    {
        questionManager = FindAnyObjectByType<QuestionManager>();
    }

    public void UpdateVisual()
    {
        if (textMesh != null)
        {
            textMesh.text = answerText;
        }
    }

    void OnMouseDown()
    {
        questionManager.CheckAnswer(isCorrect);
    }
}