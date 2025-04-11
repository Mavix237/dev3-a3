using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TextProgression : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    [SerializeField] private List<string> textSequence = new List<string>();
    private int currentIndex = 0;
    private bool hasShownAllMessages = false;
    private bool isReadyToLoadScene = false;

    void Start()
    {
        if (textSequence.Count > 0)
        {
            displayText.text = textSequence[0];
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            GoToNextText();
        }
    }

    public void GoToNextText()
    {
        if (isReadyToLoadScene)
        {
            SceneManager.LoadScene("main");
            return;
        }

        if (hasShownAllMessages)
        {
            displayText.text = "Click again to start the performance :)";
            isReadyToLoadScene = true;
            return;
        }

        currentIndex++;
        
        if (currentIndex >= textSequence.Count)
        {
            hasShownAllMessages = true;
            displayText.text = textSequence[textSequence.Count - 1];
        }
        else
        {
            displayText.text = textSequence[currentIndex];
        }
    }
}