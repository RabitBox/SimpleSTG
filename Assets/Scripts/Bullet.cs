using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseBullet
{
	[SerializeField]
	private int _effect_id = 0;

	protected override void Move()
	{
		Vector2 _move_direction = this._rect_transform.right * this._speed;
		this._rect_transform.anchoredPosition += _move_direction;
	}

	private void OnTriggerEnter2D(Collider2D _collision)
	{
		switch(_collision.gameObject.tag)
		{
			case "Enemy":
				ParticleManager.Instance.Create(_effect_id, gameObject.GetComponent<RectTransform>().anchoredPosition);
				Destroy(this.gameObject);
				break;

			case "Wall":
				Destroy(this.gameObject);
				break;
		}
	}
}
