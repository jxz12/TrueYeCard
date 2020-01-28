using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GetComponent<Animator>().SetTrigger("Down");
		}
		if (Input.GetMouseButtonUp(0))
		{
			GetComponent<Animator>().SetTrigger("Up");
		}
		transform.position = Input.mousePosition;
	}
	float h = 0;
	void FixedUpdate()
	{
		h = h>1? 0 : h+.005f;
		Color newCol = Color.HSVToRGB(h, .3f, 1f);
		var im = GetComponent<Image>();
		// newCol.a = im.color.a;
		im.color = newCol;
	}
}
