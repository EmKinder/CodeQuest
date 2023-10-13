using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextTypeWriter : MonoBehaviour
{
	// Start is called before the first frame update
	public TextMeshProUGUI txt;
	string story;

	void Awake()
	{
		//txt = GetComponent<TextMeshPro>();
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
			yield return new WaitForSeconds(0.125f);
		}
	}

}
