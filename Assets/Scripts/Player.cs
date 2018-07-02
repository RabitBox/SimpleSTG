using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//------------------------------
	[SerializeField]
	private float			_move_speed = 100f;
	private RectTransform	_rect_transform = null;

	private List<BulletShooter> _shooters = new List<BulletShooter>();

	//------------------------------
	// Use this for initialization
	void Start()
	{
		this._rect_transform = this.gameObject.GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();

		_shooters.ForEach(e => e.IntervalCount());
		_shooters.ForEach(e => e.Shoot());
	}

	// 移動処理
	private void Move()
	{
		var _move_vector = Vector2.zero;
		if (Input.GetKey(KeyCode.UpArrow))
		{
			_move_vector += Vector2.up;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			_move_vector += Vector2.down;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			_move_vector += Vector2.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			_move_vector += Vector2.left;
		}
		this._rect_transform.anchoredPosition += _move_vector * (this._move_speed * Time.deltaTime);
	}

	// 
	public void AddShooter(BulletShooter _shooter)
	{
		if(this._shooters != null)
		{
			this._shooters.Add(_shooter);
		}
	}
}
