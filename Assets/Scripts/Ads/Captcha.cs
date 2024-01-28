using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Captcha : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] answer;
    [SerializeField] Sprite[] numberSprite;
    [SerializeField] BasicButton[] buttons;

    List<int> question = new List<int>();
    Queue<int> answerSequence = new Queue<int>();

    int currentNumber;

    public UnityEvent onComplete;

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            int j;
            do
            {
                j = Random.Range(0, 10);
            }
            while (question.Contains(j));

            question.Add(j);
        }

        for(int i = 0; i < 4; i++)
        {
            answerSequence.Enqueue(question[i]);
            answer[i].sprite = numberSprite[question[i]];
        }

        UpdateCurrentNumber();
    }

    public void checkNumber(int input)
    {
        if(input == currentNumber)
        {
            buttons[input].DisableButton();
            UpdateCurrentNumber();
        }
        else
        {
            ResetSequence();
        }
    }

    void UpdateCurrentNumber()
    {
        if(answerSequence.TryDequeue(out int result))
        {
            currentNumber = result;
        }
        else
        {
            onComplete.Invoke();
        }
    }

    void ResetSequence()
    {
        answerSequence.Clear();
        foreach(var button in buttons)
        {
            button.EnableButton();
        }
        foreach (int number in question)
        {
            answerSequence.Enqueue(number);
        }
        UpdateCurrentNumber();
    }
}