using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public static class CheckMatch
{
	static Board board;

	static bool rowState, colState;


	public static int count;
	static int colorThis, colorNext;

	static int checkIndex;
	static int nextIndex;

	public static List<int> matchList = new List<int>();
	public static bool CheckStates(Board _board)
	{
		board = _board;

		//Önce satýrlarý sonra sütunlarý döngüler içerisinde kontrol ediyorum.
		rowState = CheckRow();
		colState = CheckColumn();

		matchList.Clear();

		//Durumu geri gönderiyoruz.
		if (rowState || colState) return true;
		else return false;
	}

	static bool CheckRow()
	{
		for (int i = 0; i < board.Height; i++)
		{
			matchList.Clear();
			count = 1;
			for (int j = 0; j < board.Width - 1; j++)
			{
				checkIndex = j + (i * board.Width);
				nextIndex = checkIndex + 1;

				colorThis = board.Grid[checkIndex];
				colorNext = board.Grid[nextIndex];

				if (colorThis == colorNext)
				{
					matchList.Add(checkIndex);
					count++;
				}
				else
				{
					if (count >= 3)
					{
						return true;
					}


					matchList.Clear();
					count = 1;
				}
			}

			if (count >= 3) return true;
		}

		return false;
	}
	static bool CheckColumn()
	{
		for (int i = 0; i < board.Width; i++)
		{
			matchList.Clear();
			count = 1;
			for (int j = 0; j < board.Height - 1; j++)
			{
				checkIndex = i + (j + (j * (board.Width - 1)));
				nextIndex = checkIndex + board.Width;

				colorThis = board.Grid[checkIndex];
				colorNext = board.Grid[nextIndex];

				if (colorThis == colorNext)
				{
					matchList.Add(checkIndex);
					count++;
				}
				else
				{
					if (count >= 3)
					{
						return true;
					}


					matchList.Clear();
					count = 1;
				}

			}

			if (count >= 3) return true;
		}

		return false;
	}

}