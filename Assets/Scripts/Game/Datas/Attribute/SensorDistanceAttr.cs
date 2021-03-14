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
    public class SensorDistanceAttr : BaseAttribute
    {
        
        #region constructor
        
        public SensorDistanceAttr() { }

        public override BaseAttribute Clone()
        {
            return new SensorDistanceAttr(this);
        }

        public SensorDistanceAttr(SensorDistanceAttr attribute) : base(attribute)
        {
        }
        
        public SensorDistanceAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }

}