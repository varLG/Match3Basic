using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : SingletonG<UIController>
{
	[SerializeField] Image matchImage;
	[SerializeField] Button shuffleButton;

	//Genel oyun ekran� i�in daha �ok aray�zde bilgilendirme maksatl� haz�rlad�m �ok bi �nemi yok asl�nda
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
