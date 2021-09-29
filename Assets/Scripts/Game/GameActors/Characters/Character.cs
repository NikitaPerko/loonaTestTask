using System;
using LoonaTest.Game.GameActors.Penguins;
using LoonaTest.Game.Settings;
using UnityEngine;

namespace LoonaTest.Game.GameActors.Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        private IMovable _movable;
        private CharactersSettings _charactersSettings;

        public void Init(CharacterOwner owner, PenguinsContainer penguins, CharactersSettings charactersSettings)
        {
            _charactersSettings = charactersSettings;

            switch (owner)
            {
                case CharacterOwner.Player:
                    _movable = new PlayerMovement();
                    break;
                case CharacterOwner.Computer:
                    _movable = new ComputerMovement(penguins.Penguins, transform);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(owner), owner, null);
            }
        }

        private void Update()
        {
            var direction = _movable.GetMovementDirection();

            if (direction != Vector3.zero)
            {
                _rigidbody.velocity = (direction + _rigidbody.transform.forward).normalized * _charactersSettings.Speed;

                _rigidbody.rotation =
                    Quaternion.RotateTowards(_rigidbody.rotation,
                        Quaternion.LookRotation(direction), 1000f * Time.deltaTime);
            }
        }
    }
}