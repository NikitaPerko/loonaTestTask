using System.Collections.Generic;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace LoonaTest.Game.GameActors.Penguins
{
    public class Penguin : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent _navMeshAgent;

        private CharactersContainer _characters;
        private PenguinsSettings _penguinsSettings;
        private PenguinBehaviour _penguinBehaviour;

        public void Init(CharactersContainer characters, PenguinsSettings penguinsSettings, GameField gameField)
        {
            _penguinsSettings = penguinsSettings;
            _characters = characters;
            _penguinBehaviour = new PenguinBehaviour(_navMeshAgent, this, gameField, _penguinsSettings);
            _penguinBehaviour.SwitchState(PenguinState.Idle);
        }

        public void Deinit()
        {
            _penguinBehaviour.Deinit();
        }

        private void Update()
        {
            Character closestCharacter = null;
            float closestCharacterSqrtDist = float.MaxValue;
            bool wasFinded = false;

            foreach (var character in _characters.Characters)
            {
                float squrtDist = (character.transform.position - transform.position).sqrMagnitude;

                if (squrtDist < _penguinsSettings.DangerRadiusSqr)
                {
                    if (squrtDist < closestCharacterSqrtDist)
                    {
                        closestCharacterSqrtDist = squrtDist;
                        wasFinded = true;
                        closestCharacter = character;
                    }
                }
            }

            if (wasFinded)
            {
                _penguinBehaviour.SwitchState(PenguinState.Danger, closestCharacter);
            }
        }
    }
}