using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
	//------------------------------
	[SerializeField]
	private GameObject			_bullet = null;

	[SerializeField]
	private int					_fire_rate = 10;
	private int					_now_interval = 0;

	[SerializeField]
	private List<CreateData>	_data = new List<CreateData>();

	private RectTransform		_rect_transform = null;

	//------------------------------
	private void Start()
	{
		this._rect_transform = this.gameObject.GetComponent<RectTransform>();
		this.gameObject.GetComponent<Player>().AddShooter(this);
	}

	// 射出
	public void Shoot()
	{
		if(this._bullet != null						// ヌルチェック
			&& this._now_interval <= 0)				// インターバルチェック
		{
			if(this._data.Count > 0)				// 生成データが0以上か確認
			{
				foreach(var _value in this._data)
				{
					var _create_object_transform = Instantiate(this._bullet, this.transform.parent).GetComponent<RectTransform>();
					_create_object_transform.anchoredPosition = this._rect_transform.anchoredPosition + _value.create_position;
					_create_object_transform.eulerAngles = new Vector3(0f, 0f, _value.angle);
				}
			}
			else
			{
				Instantiate(this._bullet, this.transform.parent);
			}

			this._now_interval = this._fire_rate;
		}
	}

	// インターバルを減少する
	public void IntervalCount()
	{
		if (this._now_interval > 0)
		{
			this._now_interval--;
		}
	}

	//------------------------------
	[System.Serializable]
	struct CreateData
	{
		public Vector2	create_position;    // 生成座標
		public float	angle;				// 生成角度
	}
}
