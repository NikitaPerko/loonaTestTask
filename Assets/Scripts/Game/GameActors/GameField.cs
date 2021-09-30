using LoonaTest.Game.GameEventHandlers;
using UnityEngine;
using VContainer;

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

        [Inject]
        public void Construct(IPenguinOutOfBorderHandler penguinOutOfBorderHandler)
        {
            _exitBorder.Init(penguinOutOfBorderHandler);
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