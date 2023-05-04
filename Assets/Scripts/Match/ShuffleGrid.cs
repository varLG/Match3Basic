using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShuffleGrid
{
	static int[] fakeGrid;
	static int length;

	//Gridin �nceki halinden farkl� olup olmad���n� kontrol ediyorum duruma g�re d�ng� �al���p return ediyor
	public static int[] BoardGrid(int[] _grid)
	{
		fakeGrid = new int[_grid.Length];
		length = _grid.Length;

		for (int i = 1; i < length; i++)
		{
			fakeGrid[i] = Random.Range(0, GridController.instance.itemColors.Count);
		}

		if (fakeGrid.Equals(_grid))
		{
			BoardGrid(_grid);
		}

		return fakeGrid;
	}

}
