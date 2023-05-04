using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MatchManager
{ 
	public static bool MatchExists(Board board, int index1, int index2)
	{
		// Indexlerin range durumunun kontrol�
		if (index1 < 0 || index1 >= board.Grid.Length || index2 < 0 || index2 >= board.Grid.Length)
			return false;

		// De�erleri de�i�tiriyorum
		GridController.SwapIndex(board, index1, index2);


		// Sat�r s�tun kontrolleri yap�l�yor, de�erler geri al�n�yor.
		if (CheckMatch.CheckStates(board))
		{
			GridController.SwapIndex(board, index1, index2);
			return true;
		}
		 

		// Match yoksa geri d�n��
		GridController.SwapIndex(board, index1, index2);
		return false;
	}
	  
	public static List<Tuple<int, int>> GetAllPossibleMatches(Board _board)
	{
		//Olas� ihtimal kontrolleri
		return CheckPossibles.PossiblesBoard(_board);
	}
	 

	public static void Shuffle(Board board)
	{
		//ShuffleGrid.BoardGrid fonksiyonunda orjinalinden farkl� grid olu�turup burada e�itliyoruz
		int[] newGrid = ShuffleGrid.BoardGrid((int[])(board.Grid.Clone()));
		Board newBoard = new Board(board.Width, board.Height, newGrid);

		//E�er istenilen ko�ullar sa�lanmazsa olana kadar d�ng�ye sokuyoruz, ko�ullar sa�lan�rsa Array� board'a yerle�tiriyoruz.
		if (CheckPossibles.PossiblesBoard(newBoard).Count == 0 || IsAnyMatchExistsInBoard(newBoard))
		{
			Shuffle(board);
		}
		else
		{
			Array.Copy(newGrid, board.Grid, board.Grid.Length);
			GridController.instance.SetGridPoints();
			UIController.instance.SetMatchImage();
		}
	}

	public static bool IsAnyMatchExistsInBoard(Board board)
	{
		//Halihaz�rda 3 ve 3ten fazla match durumu var m� kontrol ediyor.
		if (CheckMatch.CheckStates(board))
		{
			return true;
		}
		else
		{
			return false;
		}
	} 
}