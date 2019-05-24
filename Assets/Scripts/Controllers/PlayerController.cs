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

        [SerializeField] private SpriteRenderer _healthBar;

        [SerializeField] private ParticleSystem damageEffect;

        private MdlPlayer currentPlayer { get; set; }

        private int fullHp;

        public void Init(MdlPlayer mdlPlayer)
        {
            currentPlayer = mdlPlayer;
            
            text.text = mdlPlayer.Id;

            fullHp = currentPlayer.fullHp;
            
            currentPlayer.PlayerUpdated += MdlPlayerOnPlayerUpdated;
            currentPlayer.PlayerDamadged += Hit;
        }

        private void MdlPlayerOnPlayerUpdated()
        {
            if (currentPlayer == null)
            {
                return;
            }

            if (currentPlayer.Id == ConnectionManager.Instance.UserId)
            {
                return;
            }

            transform.position = currentPlayer.Position;
            
            body.RotateZ(currentPlayer.Rotation);
                                    
            if (currentPlayer.isShooting)
            {
                Shoot();    
            }
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
            
            ConnectionManager.Instance.SendUpdate(transform.position.x, transform.position.y, body.rotation.eulerAngles.z, lazer.isShooting);

            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
       
        void Shoot()
        {
            lazer.Shoot();
        }

        void Hit()
        {
            if (currentPlayer.fullHp != 0)
            {
                var percent = (float)currentPlayer.currentHp / (float)currentPlayer.fullHp;
                
                _healthBar.size = new Vector2(percent * _healthBar.size.x, _healthBar.size.y);    
                
                _healthBar.color = Color.Lerp(Color.green, Color.red, percent);
            }
            
            damageEffect.Play();
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
