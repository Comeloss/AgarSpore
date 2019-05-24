using UnityEngine;

namespace Controllers
{
   public class LazerController : MonoBehaviour
   {
      [SerializeField] Animator Lazer;
      [SerializeField] AudioSource _source;

      public bool isShooting { get; private set; }

      //anim event
      void ShootEnded()
      {
         isShooting = false;
      }

      public void Shoot()
      {
         if (isShooting)
         {
            return;
         }

         isShooting = true;
         Lazer.SetTrigger("Shoot");
         _source.Play();
      
      }
   }
}
