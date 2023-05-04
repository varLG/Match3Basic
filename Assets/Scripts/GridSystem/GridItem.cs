using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridItem : MonoBehaviour
{ 
	[SerializeField] Image gridImage;
	 
	public void SetItemValues( int _gridValue)
	{ 
		gridImage.color = GridController.instance.itemColors[_gridValue]; 
	}
}
