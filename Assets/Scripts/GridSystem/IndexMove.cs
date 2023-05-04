using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public static class IndexMove 
{ 
	static MoveType moveType;
	static int index1;
	static int index2;


	//Index hareket edebilir mi hareket edebilirse e�le�me var m� onun kontrol�n� yap�yor.
	public static void CheckStatus(MoveType _moveType, int _index1)
	{
		moveType = _moveType;
		index1 = _index1;

		index2 = CalculateSecondIndex();

		if (MoveStatus() && MatchStatus())
		{  
			Debug.Log("HAMLEDE E�LE�ME VAR!");
			UIController.instance.SetMatchImage(true);
		}
		else
		{
			Debug.Log("HAMLEDE E�LE�ME YOK!");
			UIController.instance.SetMatchImage(false);
		}

	}

	//Index hareket edebilir mi kontrol�
	static bool MoveStatus()
	{
		switch (moveType)
		{
			case MoveType.Up:
				if (index1 >= ((LevelController.instance.levelBoard.Width - 1) * LevelController.instance.levelBoard.Height)
					&& index1 < (LevelController.instance.levelBoard.Width * LevelController.instance.levelBoard.Height))
					return false;
				else
					return true;
			case MoveType.Down:
				if (index1 >= 0 && index1 < LevelController.instance.levelBoard.Width)
					return false;
				else
					return true;
			case MoveType.Left:
				if (index1 % LevelController.instance.levelBoard.Width == 0)
					return false;
				else
					return true;
			case MoveType.Right:
				if ((index1 - (LevelController.instance.levelBoard.Width - 1)) % LevelController.instance.levelBoard.Width == 0)
					return false;
				else
					return true;
			default:
				return false;
		}
	}

	//Index match kontrol�
	static bool MatchStatus()
	{
		switch (moveType)
		{
			case MoveType.Up:
				return MatchManager.MatchExists(LevelController.instance.levelBoard, index1, index2);
			case MoveType.Down:
				return MatchManager.MatchExists(LevelController.instance.levelBoard, index1, index2);
			case MoveType.Left:
				return MatchManager.MatchExists(LevelController.instance.levelBoard, index1, index2);
			case MoveType.Right:
				return MatchManager.MatchExists(LevelController.instance.levelBoard, index1, index2);
			default:
				return false;
		}
	}

	//E�le�tirme veya hareketi yapacakken s�radaki indexi hesaplatma
	static int CalculateSecondIndex()
	{
		switch (moveType)
		{
			case MoveType.Up:
				return (index1 + LevelController.instance.levelBoard.Width);
			case MoveType.Down:
				return (index1 - LevelController.instance.levelBoard.Width);
			case MoveType.Left:
				return (index1 - 1);
			case MoveType.Right:
				return (index1 + 1);
			default:
				return -1;
		}
	}

}




public enum MoveType
{
	Up, Down, Left, Right
}
