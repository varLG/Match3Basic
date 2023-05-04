using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonG<LevelController>
{
	//Bu class daha derin olabilirdi tabiki ama maksat basit mekani�i haz�rlamak oldu�u i�in olabildi�ince projeyi saf halde tutmaya �al��t�m


	[SerializeField] int width;
	[SerializeField] int height;
	int[] grid;

	public Board levelBoard { get; private set; } 

	void Start()
	{
		CreateLevelBoard();
	}

	//Board'u olu�turup kar��t�r�yor. 
	void CreateLevelBoard()
	{
		grid = new int[width * height];
		levelBoard = new Board(width, height, grid);

		GridUI.instance.CreateGridObjects(width, height);

		MatchManager.Shuffle(levelBoard); 
	}

	
}
