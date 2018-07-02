using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : BaseBullet
{
	[SerializeField]
	private RectTransform	_target_transform = null;	// ターゲットのトランスフォーム

	[SerializeField]
	private float			_rotation_speed = 5f;		// 回転速度

	private bool			_target_rock = false;		// ターゲットロック

	protected override void Start()
	{
		base.Start();

		// ザックリとターゲットセッティング
		float _distance = 10000f;
		foreach(var _target in GameController.Instance.EnemyList)
		{
			var _now_distance = Vector2.Distance(this._rect_transform.anchoredPosition, _target.anchoredPosition);
			if(_distance > _now_distance)
			{
				this._target_transform = _target;
				_distance = _now_distance;
			}
			
		}
	}

	private void OnTriggerEnter2D(Collider2D _collision)
	{
		//if (_collision.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}

	// 移動処理
	protected override void Move()
	{
		Rotato();

		Vector2 _move_direction = this._rect_transform.right * this._speed;
		this._rect_transform.anchoredPosition += _move_direction;
	}

	// 回転処理を行う
	private void Rotato()
	{
		if (this._target_rock == true)	// ターゲットロックがTrueの場合はもう回転をしない
		{
			return;
		}

		if (this._target_transform != null)
		{
			var _target_angle = this.GetTargetEulerAngle(this._rect_transform.anchoredPosition, this._target_transform.anchoredPosition);
			var _delta_angle = Mathf.DeltaAngle(this._rect_transform.eulerAngles.z, _target_angle);

			var _rotation = _rotation_speed;

			if (Mathf.Abs(_delta_angle) >= _rotation_speed)
			{
				if (_delta_angle < 0)
				{
					_rotation *= -1;
				}
			}
			else
			{
				_rotation = _delta_angle;
				this._target_rock = true;
			}
			
			this._rect_transform.eulerAngles += new Vector3(0, 0, _rotation);
		}
	}

	// 2点間の角度(オイラー角)を取得する
	private float GetTargetEulerAngle(Vector2 _from, Vector2 _to)
	{
		var _target_vector = _to - _from;
		var _degree = Mathf.Atan2(_target_vector.y, _target_vector.x) * Mathf.Rad2Deg;
		return _degree;
	}
}
