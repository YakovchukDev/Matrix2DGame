
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeTextWriter : MonoBehaviour
{
	private Text txt;
	private string story;

	[SerializeField]
	private float secondsToWait;

	void Awake()
	{
		txt = GetComponent<Text>();
		story = txt.text;
		txt.text = "";

		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(secondsToWait);
		}
	}

}
