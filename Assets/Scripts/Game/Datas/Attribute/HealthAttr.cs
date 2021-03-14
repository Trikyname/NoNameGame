using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo salud
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class HealthAttr : BaseAttribute
    {
        #region constructor
        public HealthAttr() { }

        public override BaseAttribute Clone()
        {
            return new HealthAttr(this);
        }

        public HealthAttr(HealthAttr attr):base(attr)
        {
        }
        
        public HealthAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
        }
        #endregion

    }
    

}