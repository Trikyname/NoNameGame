using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo velocidad de movimiento
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/

namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class MovementSpeedAttr : BaseAttribute
    {
        
        #region constructor
        public MovementSpeedAttr() { }

        public override BaseAttribute Clone()
        {
            return new MovementSpeedAttr(this);
        }

        public MovementSpeedAttr(MovementSpeedAttr attribute) : base(attribute)
        {
        }
        
        public MovementSpeedAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }

}