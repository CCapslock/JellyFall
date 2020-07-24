using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	public bool NeedToMove = false;
	public Transform ObstacleTransform;
	private LVLGenerator _lvlGenerator;
	private Vector3 _endingVector;
	public Vector3 PoolPositionVector;
	 
	[SerializeField] private float _speed;
	[SerializeField] private ObstaclesSpeed _obstaclesSpeedController;
	[SerializeField] private Vector3 _movingVector;

	private void Start()
	{
		ObstacleTransform = GetComponent<Transform>();
		_lvlGenerator = FindObjectOfType<LVLGenerator>();
		_endingVector = new Vector3(0, 0, -40);
		_obstaclesSpeedController = FindObjectOfType<ObstaclesSpeed>();
	}
	private void FixedUpdate()
	{
		if (ObstacleTransform.position.z <= _endingVector.z)
		{

			NeedToMove = false;
			ObstacleTransform.position = PoolPositionVector;
			_lvlGenerator.AddNextObstacle();
		}
		_speed = _obstaclesSpeedController.SpeedOfObstacle;
		if(NeedToMove)
			MoveObstacle();
	}
	private void MoveObstacle()
	{
		_movingVector = ObstacleTransform.position;
		_movingVector.z -= _speed;
		ObstacleTransform.position = _movingVector;
	}
}
