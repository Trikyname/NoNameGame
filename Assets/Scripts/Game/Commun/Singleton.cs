/**
*Descripcion de la clase:
*  Clase abstracta templatizada singleton para que cualquier clase que quiera ser singleton pueda heradarla
*  y tomar las caracteristicas de una clase singleton.
*  
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public class Singleton<T>
    {

        private static Singleton<T> _instance;
        


        #region propiedad publica
        //1 forma de acceder a la instancia. No en caso de ser MonoBehaviour(no permite new)
        public static Singleton<T> Instance 
        { 
            get {
                    if (_instance == null)
                    {
                        _instance = new Singleton<T>();

                    }
                return _instance;
        }     }

        #endregion

        #region metodo propio
        //2 forma de acceder a la instancia
        public  Singleton<T> GetInstance()
        {   //Se crea una unica instancia de esta clase, si no existia antes
            if (_instance == null)
            {
                _instance = this;

            }
            return _instance;
        }


        #endregion

        #region Metodos propios del motor
        //3 forma de acceder a la instancia, caso de ser MonoBehaviour
        private void Awake()
        {
            if (Instance == null)
            {

                _instance = this;

            }
            
        }

        #endregion

    }
}
