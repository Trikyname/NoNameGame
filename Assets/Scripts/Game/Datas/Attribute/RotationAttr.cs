
using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo rotaciones
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class RotationAttr : BaseAttribute
    {
        
        #region constructor
        public RotationAttr() { }

        public override BaseAttribute Clone()
        {
            return new RotationAttr(this);
        }

        public RotationAttr(RotationAttr attribute) : base(attribute)
        {
        }
        
        public RotationAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }

}