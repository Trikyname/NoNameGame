using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: 
*Clase para controlar un tipo de atributo defensa
*
*Autor: Miguel Calvache
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public class DefenseAttr : BaseAttribute
    {
        #region constructor
        public DefenseAttr() { }

        public override BaseAttribute Clone()
        {
            return new DefenseAttr(this);
        }

        public DefenseAttr(DefenseAttr attribute):base(attribute)
        {
            
        }
        
        public DefenseAttr(float value, float minvalue, float maxvalue, float increasestep, string attributeName, GameEnums.Modifier modifier)
            : base(value, minvalue, maxvalue, increasestep, attributeName, modifier)
        {
            
        }
        #endregion

    }

}