using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	RectTransform _rect_transform = null;

	// Use this for initialization
	void Start()
	{
		this._rect_transform = this.gameObject.GetComponent<RectTransform>();
		GameController.Instance.AddEnemyList(_rect_transform);
	}

	private void OnDisable()
	{
		GameController.Instance.RemoveEnemyList();
		Destroy(this.gameObject);
	}
}
