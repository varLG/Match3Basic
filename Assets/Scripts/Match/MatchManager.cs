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
		// Indexlerin range durumunun kontrolü
		if (index1 < 0 || index1 >= board.Grid.Length || index2 < 0 || index2 >= board.Grid.Length)
			return false;

		// Deðerleri deðiþtiriyorum
		GridController.SwapIndex(board, index1, index2);


		// Satýr sütun kontrolleri yapýlýyor, deðerler geri alýnýyor.
		if (CheckMatch.CheckStates(board))
		{
			GridController.SwapIndex(board, index1, index2);
			return true;
		}
		 

		// Match yoksa geri dönüþ
		GridController.SwapIndex(board, index1, index2);
		return false;
	}
	  
	public static List<Tuple<int, int>> GetAllPossibleMatches(Board _board)
	{
		//Olasý ihtimal kontrolleri
		return CheckPossibles.PossiblesBoard(_board);
	}
	 

	public static void Shuffle(Board board)
	{
		//ShuffleGrid.BoardGrid fonksiyonunda orjinalinden farklý grid oluþturup burada eþitliyoruz
		int[] newGrid = ShuffleGrid.BoardGrid((int[])(board.Grid.Clone()));
		Board newBoard = new Board(board.Width, board.Height, newGrid);

		//Eðer istenilen koþullar saðlanmazsa olana kadar döngüye sokuyoruz, koþullar saðlanýrsa Arrayý board'a yerleþtiriyoruz.
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
		//Halihazýrda 3 ve 3ten fazla match durumu var mý kontrol ediyor.
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