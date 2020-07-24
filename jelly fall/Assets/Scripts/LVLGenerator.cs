using UnityEngine;

public class LVLGenerator : MonoBehaviour
{
	public GameObject[] ObstaclePrefabs;
	private GameObject[] _obstacles;
	private ObstacleController[] _obstacleControllers;
	private float _obstacleLength = 40f;
	private Vector3 _transformVector;

	private void Start()
	{
		_obstacles = new GameObject[ObstaclePrefabs.Length];
		_obstacleControllers = new ObstacleController[ObstaclePrefabs.Length];
		Vector3 PoolTransformVector = new Vector3(0, 10, 0);
		for (int i = 0; i < ObstaclePrefabs.Length; i++)
		{
			_obstacles[i] = Instantiate(ObstaclePrefabs[i], PoolTransformVector, Quaternion.identity);
			_obstacleControllers[i] = _obstacles[i].GetComponent<ObstacleController>();
			_obstacleControllers[i].PoolPositionVector = PoolTransformVector;
			PoolTransformVector.x += 10;
		}
		AddFirstLayerOfObstacles(5);
	}

	private void AddFirstLayerOfObstacles(int AmountOfObstacles)
	{
		int ObstacleNum = 0;
		bool NumCounted = false;
		for (int i = 0; i < AmountOfObstacles; i++)
		{
			do
			{
				ObstacleNum = Random.Range(0, _obstacleControllers.Length - 1);
				Debug.Log(ObstacleNum);
				if (!_obstacleControllers[ObstacleNum].NeedToMove)
				{
					NumCounted = true;
				}
			}
			while (!NumCounted);
			_obstacles[ObstacleNum].transform.position = _transformVector;
			_obstacleControllers[ObstacleNum].NeedToMove = true;
			if (i != AmountOfObstacles - 1)
				_transformVector.z += _obstacleLength;
			NumCounted = false;
		}
	}

	public void AddNextObstacle()
	{
		int ObstacleNum = 0;
		bool NumCounted = false;
		do
		{
			ObstacleNum = Random.Range(0, _obstacleControllers.Length - 1);
			Debug.Log(ObstacleNum);
			if (!_obstacleControllers[ObstacleNum].NeedToMove)
			{
				NumCounted = true;
			}
		}
		while (!NumCounted);
		_obstacles[ObstacleNum].transform.position = _transformVector;
		_obstacleControllers[ObstacleNum].NeedToMove = true;
	}
}
