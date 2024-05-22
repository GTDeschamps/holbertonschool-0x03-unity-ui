using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Material trapMat;
	public Material goalMat;
	public Toggle colorBlindMode;
	public void PlayMaze()
	{
		SceneManager.LoadScene("maze");

		if (colorBlindMode.isOn)
		{
			// Change trap material color to orange
            trapMat.color = new Color32(255, 112, 0, 1);

            // Change goal material color to blue
            goalMat.color = Color.blue;
		}
		else
		{
			trapMat.color = Color.red;
			goalMat.color = Color.green;
		}
	}

	public void QuitMaze()
    {
        Application.Quit();
		Debug.Log("Quit Game");
    }
}

