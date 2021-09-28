using System.Collections;
using LoonaTest.Game.GameActors.Characters;
using LoonaTest.Game.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace LoonaTest.Game.GameActors.Penguins
{
    public class PenguinDangerAction : IAction
    {
        private readonly Penguin _penguin;
        private readonly PenguinBehaviour _penguinBehaviour;
        private readonly NavMeshAgent _navMeshAgent;
        private readonly PenguinsSettings _penguinsSettings;

        public PenguinDangerAction(Penguin penguin, PenguinBehaviour penguinBehaviour, NavMeshAgent navMeshAgent,
            PenguinsSettings penguinsSettings)
        {
            _penguin = penguin;
            _penguinBehaviour = penguinBehaviour;
            _navMeshAgent = navMeshAgent;
            _penguinsSettings = penguinsSettings;
        }

        public void Act(object data = null)
        {
            if (data is Character character)
            {
                _penguinBehaviour.StartActivity(WalkingOutFromCharacter(character));
            }
        }

        private IEnumerator WalkingOutFromCharacter(Character character)
        {
            var penguinPos = _penguin.transform.position;
            var characterTransform = character.transform;
            var fromCharacterToPenguin = penguinPos - characterTransform.position;
            var runDirection = (characterTransform.forward + fromCharacterToPenguin).normalized;
            _navMeshAgent.ResetPath();

            while (true)
            {
                float squrtDist = (character.transform.position - penguinPos).sqrMagnitude;

                if (squrtDist > _penguinsSettings.DangerRadiusSqr)
                {
                    yield return new WaitForSeconds(Random.Range(0.5f, 2f));
                    _penguinBehaviour.SwitchState(PenguinState.Idle);
                }

                _penguin.transform.rotation =
                    Quaternion.RotateTowards(_penguin.transform.rotation,
                        Quaternion.LookRotation(runDirection), 2000f * Time.deltaTime);
                _navMeshAgent.Move(runDirection * _penguinsSettings.dangerSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}