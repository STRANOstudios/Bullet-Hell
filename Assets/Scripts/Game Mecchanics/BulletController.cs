using UnityEngine;

[System.Serializable]
public class GameObjectState
{
    public float m_Acceleration;
    public float m_Curve;
    public float m_Damage;
    public float m_Direction;
    public float m_DirX;
    public float m_DirY;
    public float m_Speed;
    public float m_Ttl, m_Timer;
}

namespace BulletHell.Spawners
{
    public class BulletController : MonoBehaviour
    {
        private GameObjectState initialState;

        private Vector3 _dirVector = Vector3.zero;
        // Start is called before the first frame update

        private bool _hasCollided = false;

        private Transform _transform;
        public float m_Acceleration;

        public float m_Curve;

        public float m_Damage;

        public float m_Direction;

        public float m_DirX;

        public float m_DirY;

        public float m_Speed;

        public float m_Ttl, m_Timer;

        //private void Awake()
        //{
        //    SaveInitialState();
        //}

        private void SaveInitialState()
        {
            initialState = new GameObjectState
            {
                m_Acceleration = this.m_Acceleration,
                m_Curve = this.m_Curve,
                m_Damage = this.m_Damage,
                m_Direction = this.m_Direction,
                m_DirX = this.m_DirX,
                m_DirY = this.m_DirY,
                m_Speed = this.m_Speed,
                m_Ttl = this.m_Ttl,
                m_Timer = this.m_Timer
            };
        }

        public void ResetGameObject()
        {
            //m_Acceleration = initialState.m_Acceleration;
            //m_Curve = initialState.m_Curve;
            //m_Damage = initialState.m_Damage;
            //m_Direction = initialState.m_Direction;
            //m_DirX = initialState.m_DirX;
            //m_DirY = initialState.m_DirY;
            //m_Speed = initialState.m_Speed;
            //m_Ttl = initialState.m_Ttl;
            //m_Timer = initialState.m_Timer;
        }

        public void Launch(float x, float z, float direction, float speed, float acceleration, float curve, float ttl)
        {
            var transform1 = transform;
            var transformPosition = transform1.position;
            transformPosition.x = x;
            transformPosition.y = z;
            transform1.position = transformPosition;
            m_Direction = direction;
            m_Speed = speed;
            m_Acceleration = acceleration;
            m_Curve = curve;
            m_Ttl = ttl;
            m_Timer = 0f;

            //SaveInitialState();
        }

        protected virtual void OnCollisionEnter(Collision other)
        {
            if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy") Hit(other.collider);
        }


        protected virtual void Hit(Collider other)
        {
            DestroyBullet();
            //var otherComponent = other.GetComponent<CharacterCombatComponent>();
            //if (otherComponent) DoDamage(otherComponent, m_Color, m_Damage);
        }

        protected virtual void DestroyBullet()
        {
            //PoolManager.ReleaseObject(gameObject);
            ResetGameObject();
            gameObject.SetActive(false);
        }

        // Update is called once per frame
        private void Update()
        {
            RunProjectile();

            // check if outside of screen

            // destroy after timeout
        }

        private void RunProjectile()
        {
            if (m_Timer >= m_Ttl) DestroyBullet();

            m_Direction += m_Curve * Time.deltaTime;
            m_Speed += m_Acceleration * Time.deltaTime;

            m_DirX = XDir(m_Direction);
            m_DirY = YDir(m_Direction);

            _dirVector.x = m_DirX;
            _dirVector.y = m_DirY;

            var transform1 = transform;
            transform1.position += _dirVector * (m_Speed * Time.deltaTime);
            m_Timer += Time.deltaTime;
        }

        private static float XDir(float angle)
        {
            var rad = Mathf.PI * angle / 180f;
            return Mathf.Cos(rad);
        }

        private static float YDir(float angle)
        {
            var rad = Mathf.PI * angle / 180f;
            return -1f * Mathf.Sin(rad);
        }
    }
}