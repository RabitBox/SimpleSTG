using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
	//------------------------------
	[SerializeField]
	protected float			_speed;
	protected RectTransform _rect_transform = null;

	protected abstract void Move();
	
	//------------------------------
	// Use this for initialization
	void Start()
	{
		this._rect_transform = this.gameObject.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		this.Move();
	}
}
