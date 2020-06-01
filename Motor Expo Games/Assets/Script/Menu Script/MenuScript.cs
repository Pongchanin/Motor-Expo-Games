using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
	public void StartButton()
	{
        StartCoroutine(LOADLEVEL(6));
	}
	public void OptionButton()
	{
		Application.LoadLevel("Option"); 
	}

	public void QuitButton()
	{
		Application.Quit();
	}

    IEnumerator LOADLEVEL(int buildindex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(buildindex);
    }
}
