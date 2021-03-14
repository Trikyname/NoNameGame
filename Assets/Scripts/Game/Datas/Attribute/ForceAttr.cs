using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo fuerza
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class ForceAttr : BaseAttribute
    {

        #region constructor

        public ForceAttr() { }

        public override BaseAttribute Clone()
        {
            return new ForceAttr(this);
        }

        public ForceAttr(ForceAttr attribute) : base(attribute)
        {
        }

        public ForceAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }
}