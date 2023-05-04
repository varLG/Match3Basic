using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : SingletonG<GridUI>
{
	[SerializeField] RectTransform bgRectTransform;
	[SerializeField] GameObject gridPointPrefab;
	[SerializeField] GameObject gridItemPrefab;

	GameObject createdGridPointObject, createdGridItemObject;
	GridPoint createdGridPoint; 

	int pointIndex; 
	int pointRectSize;


	//Match3 grid objelerini oluþturup ekrana diziyor.
	public void CreateGridObjects(int gridX, int gridY)
	{
		pointRectSize = ((int)gridPointPrefab.GetComponent<RectTransform>().rect.size.x);
		for (int y = 0; y < gridY; y++)
		{
			for (int x = 0; x < gridX; x++)
			{
				pointIndex = x + (y * gridX);

				createdGridPointObject = Instantiate(gridPointPrefab, new Vector3(0, 0, 0), Quaternion.identity, bgRectTransform);
				createdGridItemObject = Instantiate(gridItemPrefab, new Vector3(0, 0, 0), Quaternion.identity, createdGridPointObject.transform);

				createdGridPointObject.transform.localPosition = new Vector3(
					(x * pointRectSize) - ((gridX / 2f) * pointRectSize),
					(y * pointRectSize) - ((gridY / 2f) * pointRectSize),
					0);


				createdGridPoint = createdGridPointObject.GetComponent<GridPoint>();
				createdGridPoint.SetIndex(pointIndex);
				createdGridPoint.SetItem(createdGridItemObject.GetComponent<GridItem>()); 
				GridController.instance.gridPoints.Add(createdGridPoint);
			}
		}

	}
}
