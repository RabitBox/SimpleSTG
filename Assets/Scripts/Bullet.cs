using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseBullet
{
	protected override void Move()
	{
		Vector2 _move_direction = this._rect_transform.right * this._speed;
		this._rect_transform.anchoredPosition += _move_direction;
	}

	private void OnTriggerEnter2D(Collider2D _collision)
	{
		if(_collision.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}
