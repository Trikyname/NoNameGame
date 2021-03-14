using Assets.Scripts.Game.Datas;
using System.Collections;
using UnityEngine;
/**
*Descripcion de la clase:
*Interface para implementar metodos propios de una clase de tipo controller.
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public interface IControllerable
    {

        // Metodo para iniciar el controlador. Permite un array de objetos indeterminados
        void Init(EntityData data,
            Camera camera,
            uint level,
            params object[] arg);

        // Metodo Update propio desacoplado del motor
        void IOnUpdate();
        // Metodo FixedUpdate propio desacoplado del motor
        void IOnFixedUpdate();

    }
}