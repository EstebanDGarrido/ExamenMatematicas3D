using UnityEngine;
using UnityEngine.InputSystem;
using static questionList;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public QuestionList questionList;
    private int currentQuestionIndex = 0;
    public AnswerObject[] answerObjects;

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

        string[] answers = new string[4];
        answers[0] = q.correctAnswer;

        for (int i = 0; i < q.incorrectAnswers.Length; i++)
        {
            answers[i + 1] = q.incorrectAnswers[i];
        }

        for (int i = 0; i < answers.Length; i++)
        {
            int randomIndex = Random.Range(0, answers.Length);
            string temp = answers[i];
            answers[i] = answers[randomIndex];
            answers[randomIndex] = temp;
        }

        for (int i = 0; i < answerObjects.Length; i++)
        {
            answerObjects[i].answerText = answers[i];
            answerObjects[i].isCorrect = (answers[i] == q.correctAnswer);

            answerObjects[i].UpdateVisual();
        }
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

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("Correcto!");
        }
        else
        {
            Debug.Log("Incorrecto");
        }

        NextQuestion();
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