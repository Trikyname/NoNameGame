using System.Collections;
using UnityEngine;
/**
*Descripcion de la clase:
*  Struct que define la accion de empujar y sirve para filtrar en los ISetData de los componentes por clase. 
*  Es un vehiculo tansmisor de informacion
*  
*  Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Actions
{
    public class PushORDrag:ActionsPlayer
    {
        
        public PushORDrag(uint id, bool isPushingORDragging):base(id, isPushingORDragging)
        {
            
        }
    }
}