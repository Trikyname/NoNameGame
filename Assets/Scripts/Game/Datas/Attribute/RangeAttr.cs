using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo rango.
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class RangeAttr : BaseAttribute
    {
        #region constructor
        public RangeAttr() { }

        public override BaseAttribute Clone()
        {
            return new RangeAttr(this);
        }

        public RangeAttr(RangeAttr attr) : base(attr)
        {
        }

        public RangeAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }


}
