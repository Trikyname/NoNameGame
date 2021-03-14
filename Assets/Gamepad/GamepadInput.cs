using UnityEngine;
/**
*Descripcion de la clase:
*  Clase para instanciar el GamepadController que almacena los botones y los stick del Gamepad.
*  Desde aqui se puede configurar la velocidad de movimiento y rotacion.
*  No realiza el movimiento.
*  No se obtiene los valores de los stick
*  
*  Autores: Miguel Calvache
*Version:v01
*Fecha: 13/02/2021
**/
namespace Assets.Gamepad
{

    public class GamepadInput : MonoBehaviour
    {
        public string Name { get => _name; set => _name = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }
        public GamepadController Controls { get => controls; set => controls = value; }

        //Movimiento
        //private CharacterController _controller;
        private Vector3 _movement;
        private float _gravity = 0f;//

        // Control del Gamepad 
        private GamepadController controls;
        private Vector2 _move = Vector2.zero;

        [SerializeField] private string _name;

        [Header("Editables")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _rotationSpeed = 500f; // Debe estar siempre a un valor muy elevado

        

        private void Awake()
        {

            #region Controles del GamePad
            controls = new GamepadController();

            #endregion
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Debug.DrawRay(transform.position, transform.forward * 5);
        }
        

    } 
}
