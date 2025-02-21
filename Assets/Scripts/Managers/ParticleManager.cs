using Events;
using UnityEngine;

namespace Managers
{
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private GameObject _markParticle;  
        [SerializeField] private GameObject _unmarkParticle;
        
        public void SubscribeEvents()
        {
            ViewEvents.OnTileMarked   += PlayMarkParticle;
            ViewEvents.OnTileUnmarked += PlayUnmarkParticle;
        }
        
        public void UnsubscribeEvents()
        {
            ViewEvents.OnTileMarked   -= PlayMarkParticle;
            ViewEvents.OnTileUnmarked -= PlayUnmarkParticle;
        }

        private void PlayMarkParticle(Vector3 position)
        {
            if (_markParticle == null) return;

            GameObject particle = Instantiate(_markParticle);
            particle.transform.position = position;
        }

        private void PlayUnmarkParticle(Vector3 position)
        {
            if (_unmarkParticle == null) return;

            GameObject particle = Instantiate(_unmarkParticle);
            particle.transform.position = position;
        }
    }
}