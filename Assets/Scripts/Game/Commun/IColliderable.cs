using UnityEngine;
/**
*Descripcion de la clase:
*Interface para implementar metodos propios de colision.
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Commun
{
    public interface IColliderable
    {
        void IOnCollisionEnter(Collision collision);
        void IOnCollisionExit(Collision collision);
        void IOnCollisionStay(Collision collision);
    }
}