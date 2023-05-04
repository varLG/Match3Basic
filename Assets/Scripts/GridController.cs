using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : SingletonG<GridController>
{
	public GridPoint clickedItem { get; private set; }
	public Vector2 clickedPoint { get; private set; }

	public List<GridPoint> gridPoints;

	[SerializeField] float pointDistanceRange;


	[SerializeField] List<Color> _itemColors;
	public List<Color> itemColors
	{
		get { return _itemColors; }
		private set { }
	}

	Vector2 pointDistance;

	//Týklanan obje-index leri alýyor.
	public void ClickPoint(GridPoint _clickedGridItem, Vector2 _clickedPoint)
	{
		clickedItem = _clickedGridItem;
		clickedPoint = _clickedPoint;
	}
	public void ClickPoint()
	{
		clickedItem = null;
		clickedPoint = Vector2.zero;
	}

	//Gelen týklama-sürükleme hareketlerini yorumluyor
	public void DragPoint(GridPoint _clickedItem, Vector2 _clickedPoint)
	{
		if (_clickedItem != clickedItem)
			clickedItem = null;
		else if (clickedItem != null)
		{
			pointDistance = _clickedPoint - clickedPoint;
			if (Mathf.Abs(pointDistance.x) < pointDistanceRange && Mathf.Abs(pointDistance.y) < pointDistanceRange)
				return;

			if (Mathf.Abs(pointDistance.x) > Mathf.Abs(pointDistance.y))
			{
				if (pointDistance.x > 0)
				{
					//Debug.Log(_clickedItem.gridIndex + " Sað");
					IndexMove.CheckStatus(MoveType.Right, _clickedItem.gridIndex);
				}
				else
				{
					//Debug.Log(_clickedItem.gridIndex + " Sol");
					IndexMove.CheckStatus(MoveType.Left, _clickedItem.gridIndex);
				}
			}
			else
			{
				if (pointDistance.y > 0)
				{
					//Debug.Log(_clickedItem.gridIndex + " Yukarý");
					IndexMove.CheckStatus(MoveType.Up, _clickedItem.gridIndex);
				}
				else
				{
					//Debug.Log(_clickedItem.gridIndex + " Aþaðý");
					IndexMove.CheckStatus(MoveType.Down, _clickedItem.gridIndex);
				}
			}
			ClickPoint();

		}
	}


	//Grid üzerindeki deðerleri girmek için
	public void SetGridPoints()
	{
		for (int i = 0; i < LevelController.instance.levelBoard.Grid.Length; i++)
		{
			gridPoints[i].SetGridValue(LevelController.instance.levelBoard.Grid[i]);
		}

	}

	//Board üzerindeki deðerlerin yerini deðiþtirmek için
	public static Board SwapIndex(Board _board, int _index1, int _index2)
	{
		int oldIndex = _board.Grid[_index1];
		_board.Grid[_index1] = _board.Grid[_index2];
		_board.Grid[_index2] = oldIndex;

		return _board;
	}
}
