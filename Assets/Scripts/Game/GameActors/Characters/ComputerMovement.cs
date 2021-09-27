using System.Collections.Generic;
using LoonaTest.Game.GameActors.Penguins;
using UnityEngine;

namespace LoonaTest.Game.GameActors.Characters
{
    public class ComputerMovement : IMovable
    {
        private readonly List<Penguin> _penguins;
        private readonly Transform _characterTransform;

        public ComputerMovement(List<Penguin> penguins, Transform characterTransform)
        {
            _penguins = penguins;
            _characterTransform = characterTransform;
        }

        public Vector3 GetMovementDirection()
        {
            Transform minDistancedPenguin = null;
            float minSqrDistance = float.MaxValue;
            bool wasFinded = false;

            foreach (var penguin in _penguins)
            {
                var penguinTransform = penguin.transform;
                var currentSqrDistance = (_characterTransform.position - penguinTransform.position).sqrMagnitude;

                if (currentSqrDistance < minSqrDistance)
                {
                    minSqrDistance = currentSqrDistance;
                    minDistancedPenguin = penguinTransform;
                    wasFinded = true;
                }
            }

            if (!wasFinded)
            {
                return Vector3.zero;
            }

            return (minDistancedPenguin.position - _characterTransform.position).normalized;
        }
    }
}