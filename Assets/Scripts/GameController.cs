using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehavior<GameController>
{
	[SerializeField]
	private List<RectTransform> _enemy_list = new List<RectTransform>();

	public List<RectTransform> EnemyList
	{
		get { return _enemy_list; }
	}

	public void AddEnemyList(RectTransform _enemy)
	{
		this._enemy_list.Add(_enemy);
	}

	public void RemoveEnemyList()
	{
		this._enemy_list.RemoveAll(obj => obj.gameObject.activeSelf == false);
	}
}
