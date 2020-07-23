using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
	[SerializeField] private float _speed;
	[SerializeField] private ObstaclesSpeed _obstaclesSpeedController;
	[SerializeField] private Transform _obstacleTransform;
	[SerializeField] private Vector3 _movingVector;

	private void Start()
	{
		_obstaclesSpeedController = FindObjectOfType<ObstaclesSpeed>();
		_obstacleTransform = GetComponent<Transform>();
	}
	private void FixedUpdate()
	{
		_speed = _obstaclesSpeedController.SpeedOfObstacle;
		MoveObstacle();
	}
	private void MoveObstacle()
	{
		_movingVector = _obstacleTransform.position;
		_movingVector.z -= _speed;
		_obstacleTransform.position = _movingVector;
	}
}
