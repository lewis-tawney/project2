using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextDisappear : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // Check if the player has pressed the jump button
        if (Input.GetButtonDown("Jump"))
        {
            // Call the DisappearOnJump() method
            gameObject.SetActive(false);
        }
    }
}

