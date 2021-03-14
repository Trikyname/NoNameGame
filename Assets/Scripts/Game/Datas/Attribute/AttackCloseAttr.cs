
using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo ataque a corta distancia
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class AttackCloseAttr : BaseAttribute
    {
        
        #region constructor
        
        public AttackCloseAttr() { }

        public override BaseAttribute Clone()
        {
            return new AttackCloseAttr(this);
        }

        public AttackCloseAttr(AttackCloseAttr attribute) : base(attribute)
        {
        }
        
        public AttackCloseAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier) 
            : base(value, minvalue, maxvalue, increasestep, attributeName,modifier)
        {
        }
        #endregion

    }

}