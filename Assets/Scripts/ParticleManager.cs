using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : SingletonMonoBehavior<ParticleManager>
{
	//--------------------------------------------------
	// 生成時に親オブジェクトとして設定するトランスフォーム
	[SerializeField]
	private Transform _create_target;

	// 生成するパーティクルのプレハブ
	[SerializeField]
	private List<GameObject> _particles;

	// 生成したパーティクルのリスト(削除せず、ヒエラルキー上で管理する)
	private Dictionary<int, List<GameObject>> _in_hierarchy_objects = new Dictionary<int, List<GameObject>>();

	//--------------------------------------------------
	// パーティクルを生成する
	public bool Create(
		int _id,				// 生成するパーティクルのID
		Vector2 _set_position)	// 設定するポジション
	{
		// パーティクルのプレハブが存在しているかを確認する
		if(this._particles.Count <= _id)
		{
			return false;
		}

		// ヒエラルキー上に存在するかを確認する(存在していなければリストが無い)
		if(this._in_hierarchy_objects.ContainsKey(_id) == false)
		{
			// 管理するリストを生成する
			this._in_hierarchy_objects.Add(_id, new List<GameObject>());
		}

		// リストの中身を確認する
		// 中身がまだない場合
		if(this._in_hierarchy_objects[_id].Count == 0)
		{
			AddParticle(_id, _set_position);
			return true;
		}
		// 中身がある場合
		else
		{
			// 再生可能なパーティクルがあるかを調べる
			foreach(var _data in this._in_hierarchy_objects[_id])
			{
				// あれば再生し、return する
				var _particle = _data.GetComponent<ParticleSystem>();
				if(_particle.isPlaying == false)
				{
					_particle.gameObject.GetComponent<RectTransform>().anchoredPosition = _set_position;
					_particle.Play();
					return true;
				}
			}

			// なければ生成する
			AddParticle(_id, _set_position);
			return true;
		}
	}

	// パーティクルをリストに追加
	private void AddParticle(
		int _id,                // 生成するパーティクルのID
		Vector2 _set_position)  // 設定するポジション
	{
		var _created_object = Instantiate(this._particles[_id], this._create_target);
		_created_object.GetComponent<RectTransform>().anchoredPosition = _set_position;
		this._in_hierarchy_objects[_id].Add(_created_object);
	}
}
