using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinaryGuessController : MonoBehaviour
{
    private const string isHigherEqualString = "Is your number higher or equal ";
    private const string isYourNumberString = "Is your number : ";
    private const string yourNumberIsString = "Your number is :";

    [SerializeField]
    private GameObject firstPanel;
    [SerializeField]
    private GameObject secondPanel;
    [SerializeField]
    private Text questionField;
    [SerializeField]
    private List<GameObject> objectsToDisable;

    private int rangeStart = 0;
    private int rangeEnd = 1000;

    private bool isActionPerformed = false;
    private bool guessCondition;
    private bool isFinished;

    private int midPoint = 500;

    void Update()
    {
        if (!isFinished)
        {
            GuesNumber();
        }
        else
        {
            FinishGame();
        }
    }

    private void GuesNumber()
    {
        questionField.text = isHigherEqualString + midPoint;
        midPoint = GetMidPoint(rangeEnd, rangeStart);
        if (isActionPerformed)
        {
            if (guessCondition)
            {
                rangeStart = midPoint;
            }
            else
            {
                rangeEnd = midPoint;
            }
            CheckFinishCondition();
            isActionPerformed = false;
        }
    }

    private void FinishGame()
    {
        questionField.text = isYourNumberString + rangeStart;

        if (isActionPerformed)
        {
            if (guessCondition)
            {
                questionField.text = yourNumberIsString + rangeStart;
            }
            else
            {
                questionField.text = yourNumberIsString + rangeEnd;
            }

            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }

    private void CheckFinishCondition()
    {
        if (rangeEnd - rangeStart <= 1)
        {
            questionField.text = yourNumberIsString + rangeEnd;
            isFinished = true;
        }
    }

    private int GetMidPoint(int highPoint, int lowPoint)
    {
        return (highPoint + lowPoint) / 2;
    }

    public void OnStartButtonClicked()
    {
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);
    }

    public void OnYesClicked()
    {
        isActionPerformed = true;
        guessCondition = true;
    }

    public void OnNoClick()
    {
        isActionPerformed = true;
        guessCondition = false;
    }
}
