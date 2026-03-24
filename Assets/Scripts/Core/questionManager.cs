using UnityEngine;
using UnityEngine.InputSystem;
using static questionList;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public QuestionList questionList;
    private int currentQuestionIndex = 0;

    void Start()
    {
        LoadQuestions();
        ShowCurrentQuestion();
    }

    void LoadQuestions()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("questions");

        if (jsonFile != null)
        {
            questionList = JsonUtility.FromJson<QuestionList>(jsonFile.text);
        }
        else
        {
            Debug.LogError("No se pudo cargar el JSON");
        }
    }

    void ShowCurrentQuestion()
    {
        QuestionData q = questionList.questions[currentQuestionIndex];

        questionText.text = q.question;

        Debug.Log("Pregunta: " + q.question);
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questionList.questions.Length)
        {
            ShowCurrentQuestion();
        }
        else
        {
            Debug.Log("Examen terminado");
        }
    }

    private void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            NextQuestion();
        }
    }
}