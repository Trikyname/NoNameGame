using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo ataque a distancia
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class AttackDistanceAttr : BaseAttribute
    {
        
        #region constructor
        
        public AttackDistanceAttr() { }

        public override BaseAttribute Clone()
        {
            return new AttackDistanceAttr(this);
        }

        public AttackDistanceAttr(AttackDistanceAttr attribute) : base(attribute)
        {
        }
        
        public AttackDistanceAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }

}