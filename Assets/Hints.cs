using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Hints : MonoBehaviour
{
    //  int currentHintIndex = 0;
    string currentHintHeader;
    [SerializeReference] string[] hintsHeaders = new string[4];

    string currentHint;
    [SerializeReference] string[] hints = new string[4];


    void Start()
    {
        Debug.Log("Array Length: " + hints.Length);
        AddHints();
    }

    public void AddHints()
    {
        hintsHeaders[0] = "Tap or Click to Control Butterfly Flight: ";
        hints[0] = "- Use taps on the screen or clicks of the mouse to control the butterfly's flight and navigate through the world.";

        hintsHeaders[1] = "Avoid Colliding with Fire and Bamboo Fences: ";
        hints[1] = "- Watch out for dangerous obstacles! Colliding with them will end the game.";

        hintsHeaders[2] = "Manage Energy Levels: ";
        hints[2] = "- Keep an eye on your energy gauge and ensure you have enough energy. If you run out of it, the game is over.";

        hintsHeaders[3] = "Collect Nectar for Energy & Score Points: ";
        hints[3] = "- Guide the butterfly to collect nectar from the flowers. ";
    }

    public string ShowNextHintHeader()
    {
        return GetHintString(hintsHeaders, currentHintHeader);
    }

    public string ShowNextHint()
    {
        return GetHintString(hints, currentHint);
    }
    string GetHintString(string[] _array, string _currentText)
    {
        int currentHintIndex = 0;

        if (_array.Length == 0)
        {
            return "- No hints available."; // Return a message indicating that there are no hints
        }

        if (currentHintIndex < _array.Length)
        {
            if (_array[currentHintIndex] != null)
            {
                _currentText = _array[currentHintIndex];
                // Display the current hint to the player
                // You can use a UI element or print it to the console
                // For example:
                Debug.Log(_currentText);
                currentHintIndex++;
                return _currentText;
            }
            else
            {
                return "- No hints available.";
            }

        }
        else
        {
            string empty = "- We don't have any more hints.";
            return empty; // string.Empty; 
        }

    }



}
