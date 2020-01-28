using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Lock : MonoBehaviour {
	// [SerializeField] Button up1, down1, up2, down2, up3, down3, up4, down4, unlock;
	[SerializeField] Text num1, num2, num3, num4, instructions;
	[SerializeField] GameObject start, numbers, explosion, circle, cross, end, chinese1;

	int n1=0, n2=0, n3=0, n4=0;

	int level = 0;

	readonly int ans1 = 3908, ans2 = 5055, ans3 = 6123;
	readonly string q1 = "There are two dates that neither of you should ever forget. Add them together!",
					q2 = "You both travelled a long way to meet each other and make each other sMILE, didn't you?",
					q3 = "",
					final = "WELL DONE AND HAPPY BIRTHDAY!\nI wish you only the best for the future!!!";

	public void Unlock()
	{
		if (level == 0)
		{
			start.SetActive(false);
			numbers.SetActive(true);
			instructions.text = q1;
			level = 1;
			return;
		}
		int answer = n1*1000 + n2*100 + n3*10 + n4;
		if (level == 1)
		{
			if (answer == ans1)
			{
				level = 2;
				instructions.text = q2;
				Next();
			}
			else
			{
				Wrong();
			}
		} 
		else if (level == 2)
		{
			if (answer == ans2)
			{
				level = 3;
				instructions.text = q3;
				chinese1.SetActive(true);
				Next();
			}
			else
			{
				Wrong();
			}
		}
		else if (level == 3)
		{
			if (answer == ans3)
			{
				instructions.text = final;
				chinese1.SetActive(false);
				End();
			}
			else
			{
				Wrong();
			}
		}
		else
		{
			return;
		}
	}
	void Next()
	{
		circle.SetActive(false);
		circle.SetActive(true);
		n1 = n2 = n3 = n4 = 0;
		num1.text = num2.text = num3.text = num4.text = "0";
	}
	void Wrong()
	{
		cross.SetActive(false);
		cross.SetActive(true);
	}
	[SerializeField] UnityEvent finish;
	void End()
	{
		explosion.SetActive(false);
		explosion.SetActive(true);

		numbers.SetActive(false);
		end.SetActive(true);
		
		finish.Invoke();
	}

	public void Up(int num)
	{
		if (num < 1 || num > 4)
			throw new System.Exception("what");

		if (num == 1)
		{
			n1 = n1==9? 0 : n1+1;
			num1.text = n1.ToString();
		}
		else if (num == 2)
		{
			n2 = n2==9? 0 : n2+1;
			num2.text = n2.ToString();
		}
		else if (num == 3)
		{
			n3 = n3==9? 0 : n3+1;
			num3.text = n3.ToString();
		}
		else
		{
			n4 = n4==9? 0 : n4+1;
			num4.text = n4.ToString();
		}
	}
	public void Down(int num)
	{
		if (num < 1 || num > 4)
			throw new System.Exception("what");

		if (num == 1)
		{
			n1 = n1==0? 9 : n1-1;
			num1.text = n1.ToString();
		}
		else if (num == 2)
		{
			n2 = n2==0? 9 : n2-1;
			num2.text = n2.ToString();
		}
		else if (num == 3)
		{
			n3 = n3==0? 9 : n3-1;
			num3.text = n3.ToString();
		}
		else
		{
			n4 = n4==0? 9 : n4-1;
			num4.text = n4.ToString();
		}
	}
	// float h = 0;
	// void FixedUpdate()
	// {
	// 	Camera.main.backgroundColor = Color.HSVToRGB(h, .1f, 1f);
	// 	h = h>1? 0 : h+.001f;
	// }
}
