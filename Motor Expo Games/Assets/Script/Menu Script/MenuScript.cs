using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
	public GameObject selectmode;
	public GameObject option;
	public GameObject exit;
	public GameObject start;
	public void StartButton()
	{
		selectmode.SetActive(true);
		option.SetActive(false);
		exit.SetActive(false);
		start.SetActive(false);
		//StartCoroutine(LOADLEVEL(6));
	}

	public void modeselectback()
    {
		selectmode.SetActive(false);
		option.SetActive(true);
		exit.SetActive(true);
		start.SetActive(true);
	}

	public void OptionButton()
	{
		SceneManager.LoadScene("Option");
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
