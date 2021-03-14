using System.Collections;
using UnityEngine;
/**
*Descripcion de la clase:
*  Struct que define la accion de arrastrar y sirve para filtrar en los ISetData de los componentes por clase. 
*  Es un vehiculo tansmisor de informacion
*  
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Actions
{
    public  abstract class ActionsPlayer
    {
        public bool _isActing;
        public uint _id;

        public ActionsPlayer(uint id,bool isActing)
        {
            _id = id;
            _isActing = isActing;
        }
    }
}