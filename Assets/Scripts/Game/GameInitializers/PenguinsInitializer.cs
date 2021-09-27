using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.GameInitializers
{
    public class PenguinsInitializer
    {
        private readonly PenguinsSettings _penguinsSettings;

        public PenguinsInitializer(PenguinsSettings penguinsSettings)
        {
            _penguinsSettings = penguinsSettings;
        }

        public void Init(GameField gameField)
        {
            var fieldBorders = gameField.GetFieldBordersXZ();

            for (int i = 0; i < _penguinsSettings.penguinsCount; i++)
            {
                float x = Mathf.Lerp(fieldBorders.leftBot.x, fieldBorders.rightTop.x, Random.value);
                float z = Mathf.Lerp(fieldBorders.leftBot.y, fieldBorders.rightTop.y, Random.value);
                var position = new Vector3(x, 0, z);
                var rotation = Quaternion.Euler(0, Random.value * 360, 0);
                var penguin = Object.Instantiate(_penguinsSettings.PenguinPrefab, position, rotation);
            }
        }
    }
}