using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private List<RectTransform> _enemys = new List<RectTransform>();

	public List<RectTransform> EnemyList
	{
		get { return _enemys; }
	}

	public void AddEnemyList(RectTransform _enemy)
	{
		this._enemys.Add(_enemy);
	}

	public void RemoveEnemyList()
	{
		this._enemys.RemoveAll(obj => obj.gameObject.activeSelf == false);
	}

	//------------------------------
	private static GameController _instance = null;
	public static GameController Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<GameController>();
			}
			return _instance;
		}
	}
	//------------------------------
}
