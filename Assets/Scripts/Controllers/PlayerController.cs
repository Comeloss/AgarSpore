using System.Collections;
using Assets.GlebScript;
using Models;
using UnityEngine;

namespace Controllers
{
    public class PlayerController : Singleton<PlayerController>
    {
        [SerializeField] float speed = 1f;

        [SerializeField] private LazerController lazer;
        
        [SerializeField] private TextMesh text;

        [SerializeField] private Transform body;

        private MdlPlayer currentPlayer { get; set; }

        public void Init(MdlPlayer mdlPlayer)
        {
            currentPlayer = mdlPlayer;
            
            text.text = mdlPlayer.Id;
            
            
            
            mdlPlayer.PlayerUpdated += MdlPlayerOnPlayerUpdated;
        }

        private void MdlPlayerOnPlayerUpdated()
        {
            transform.SetX(currentPlayer.Position.x).SetY(currentPlayer.Position.y);
            transform.RotateZ(currentPlayer.Rotation);
        }

        void Update()
        {
            if (currentPlayer == null)
            {
                return;
                
            }

            if (currentPlayer.Id != ConnectionManager.Instance.UserId)
            {
                return;
            }

            Look();
            
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeftX(true);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveLeftX(false);
            }
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                MoveUpY(true);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                MoveUpY(false);
            }

            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
       
        void Shoot()
        {
            lazer.Shoot();
        }

        void Look()
        {
            if (lazer.isShooting)
            {
                return;
            }

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
 
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            body.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

        void MoveLeftX(bool left)
        {
            var newPosX = transform.position.x + (left ? -speed : speed); 
            
            transform.SetX(newPosX);
        }
        
        void MoveUpY(bool up)
        {
            var newPosY = transform.position.y + (up ? speed : -speed);
            
            transform.SetY(newPosY);
        }
    }
}
