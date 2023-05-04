
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonG<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = FindObjectOfType<T>();
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
