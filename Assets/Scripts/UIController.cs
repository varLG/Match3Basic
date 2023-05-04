using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : SingletonG<UIController>
{
	[SerializeField] Image matchImage;
	[SerializeField] Button shuffleButton;

	//Genel oyun ekraný için daha çok arayüzde bilgilendirme maksatlý hazýrladým çok bi önemi yok aslýnda
	private void Start()
	{
		shuffleButton.onClick.AddListener(() => MatchManager.Shuffle(LevelController.instance.levelBoard));
	}

	public void SetMatchImage()
	{
		matchImage.color = Color.black;
	}
	public void SetMatchImage(bool _state)
	{
		if (_state)
		{
			matchImage.color = Color.green;
		}
		else
		{
			matchImage.color = Color.red;
		}
	}
}
