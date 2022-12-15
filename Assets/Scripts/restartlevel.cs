using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restartlevel : MonoBehaviour
{
    int reloadCounter = 0;

    public Text counterText;  // Assign this in the Inspector

    void Awake()
    {
        // Find the Canvas GameObject in the scene
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        // Search for the counterText GameObject within the hierarchy of the Canvas
        counterText = canvas.transform.Find("CounterText").GetComponent<Text>();

        // Set the DontDestroyOnLoad flag on the Canvas GameObject
        DontDestroyOnLoad(canvas);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            reloadCounter++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            // Check if counterText is not null before using it
            if (counterText != null)
            {
                // Update the text on the screen with the new value of reloadCounter
                counterText.text = "Attempts: " + reloadCounter;
            }
        }
    }
}


