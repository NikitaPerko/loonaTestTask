using LoonaTest.Game.GameEventHandlers;
using UnityEngine;

namespace LoonaTest.Game.GameActors
{
    public class GameField : MonoBehaviour
    {
        [SerializeField]
        private ExitBorder _exitBorder;

        [SerializeField]
        private Transform _leftBotPos;

        [SerializeField]
        private Transform _rightTopPos;

        public void Init(GameEventsHandler gameEventsHandler)
        {
            _exitBorder.Init(gameEventsHandler);
        }

        public (Vector2 leftBot, Vector2 rightTop) GetFieldBordersXZ()
        {
            var leftBotPosition = _leftBotPos.position;
            var leftBotPositionXZ = new Vector2(leftBotPosition.x, leftBotPosition.z);
            var rightTopPosition = _rightTopPos.position;
            var rightTopPositionXZ = new Vector2(rightTopPosition.x, rightTopPosition.z);
            return (leftBotPositionXZ, rightTopPositionXZ);
        }

        public Vector2 GetRandomFieldXZPos()
        {
            var leftBotPosition = _leftBotPos.position;
            var rightTopPosition = _rightTopPos.position;

            float x = Mathf.Lerp(leftBotPosition.x, rightTopPosition.x, Random.value);
            float z = Mathf.Lerp(leftBotPosition.z, rightTopPosition.z, Random.value);
            return new Vector2(x, z);
        }
    }
}