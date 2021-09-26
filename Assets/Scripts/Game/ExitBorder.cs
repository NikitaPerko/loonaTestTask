using UnityEngine;

namespace LoonaTest.Game
{
    public class ExitBorder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var penguin = other.GetComponent<Penguin>();

            if (penguin != null)
            {
                
            }
        }
    }
}