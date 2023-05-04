using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPossibles : MonoBehaviour
{
	static List<Tuple<int, int>> possibleMatches = new List<Tuple<int, int>>();
	public static List<Tuple<int, int>> PossiblesBoard(Board _board)
	{
		possibleMatches = new List<Tuple<int, int>>();

		int firstIndex, secondIndex;
		for (int i = 0; i < _board.Height; i++)
		{
			for (int j = 0; j < _board.Width; j++)
			{
				// Yatay ikililer
				if (j < _board.Width - 1)
				{
					firstIndex = j + (_board.Width * i);
					secondIndex = firstIndex + 1;

					CheckIt(_board, firstIndex, secondIndex);
				}

				// Dikey ikililer
				if (i < _board.Height - 1)
				{
					firstIndex = j + (i * _board.Width);
					secondIndex = firstIndex + _board.Width;

					CheckIt(_board, firstIndex, secondIndex);
				}
			}
		}

		return possibleMatches;
	}

	private static void CheckIt(Board _board, int firstIndex, int secondIndex)
	{
		// Yeni Board oluþturarak durum kontrolü yapýyoruz ona göre olasý eþleþmeleri listeye ekliyoruz.

		Board newBoard = new Board(_board);
		GridController.SwapIndex(newBoard, firstIndex, secondIndex);

		if (CheckMatch.CheckStates(newBoard))
		{
			Tuple<int, int> possibleMatch = Tuple.Create(firstIndex, secondIndex);
			possibleMatches.Add(possibleMatch);
		}
	}
}
