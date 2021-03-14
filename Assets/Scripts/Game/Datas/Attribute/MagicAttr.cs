using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo magia
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class MagicAttr : BaseAttribute
    {

        #region constructor

        public MagicAttr() { }

        public override BaseAttribute Clone()
        {
            return new MagicAttr(this);
        }

        public MagicAttr(MagicAttr attribute) : base(attribute)
        {
        }

        public MagicAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }
}