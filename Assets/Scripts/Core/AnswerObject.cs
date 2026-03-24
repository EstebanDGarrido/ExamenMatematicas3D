using UnityEngine;
using TMPro;

public class AnswerObject : MonoBehaviour
{
    public string answerText;
    public bool isCorrect;

    public TextMeshPro textMesh;

    private QuestionManager questionManager;

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