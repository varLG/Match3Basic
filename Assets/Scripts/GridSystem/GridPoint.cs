using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GridPoint : MonoBehaviour, IPointerDownHandler, IDragHandler
{
	public int gridIndex { get; private set; } 
	public int gridValue { get; private set; } 
	public TextMeshProUGUI textIndex;

	[SerializeField] GridItem gridItem;


 
	public void SetIndex(int _index)
	{
		gridIndex = _index;
		textIndex.text = gridIndex.ToString();
		gameObject.name = "grid[" + gridIndex + "]";
	}  
	public void SetItem(GridItem _gridItem)
	{
		gridItem= _gridItem; 
	}
	public void SetGridValue(int _gridValue)
	{
		gridValue = _gridValue;
		gridItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		gridItem.SetItemValues(gridValue);
	}


	 
	//Objeye gelen mouse hareketlerini takip etmek için
	public void OnPointerDown(PointerEventData eventData)
	{  
		GridController.instance.ClickPoint(this, eventData.position);
	} 
	public void OnDrag(PointerEventData eventData)
	{  
		GridController.instance.DragPoint(this, eventData.position);
	}
}
