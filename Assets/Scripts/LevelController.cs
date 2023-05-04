using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : SingletonG<LevelController>
{
	//Bu class daha derin olabilirdi tabiki ama maksat basit mekaniði hazýrlamak olduðu için olabildiðince projeyi saf halde tutmaya çalýþtým


	[SerializeField] int width;
	[SerializeField] int height;
	int[] grid;

	public Board levelBoard { get; private set; } 

	void Start()
	{
		CreateLevelBoard();
	}

	//Board'u oluþturup karýþtýrýyor. 
	void CreateLevelBoard()
	{
		grid = new int[width * height];
		levelBoard = new Board(width, height, grid);

		GridUI.instance.CreateGridObjects(width, height);

		MatchManager.Shuffle(levelBoard); 
	}

	
}
