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

        private void Update()
        {
            foreach (var character in _characters.Characters)
            {
                if ((character.transform.position - transform.position).sqrMagnitude < _penguinsSettings.DangerRadiusSqr)
                {
                    _penguinBehaviour.SwitchState(PenguinState.Danger);
                }
            }
        }
    }
}