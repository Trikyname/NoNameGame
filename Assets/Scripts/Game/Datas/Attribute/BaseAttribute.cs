

using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: Clase abstracta base para la definicion de todos los atributos que hereden de esta
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Attribute
{
    [System.Serializable]
    public abstract class BaseAttribute
    {

        /// <summary>
        /// Estos valores nunca se puede modificar. Son los valores base leidos de BD o Json.
        /// </summary>
        public float Value { get; private set; }//Valor actual. 
        public float MinValue { get; private set; }//Minimo valor posible. 
        public float MaxValue { get; private set; }//Maximos valor posible. 
        public float IncreaseStep { get; private set; }//Valor de incremento para subir este atributo por la experiencia por ejemplo. 
        public GameEnums.Modifier FormulaType { get; private set; }

        public string AttributeName { get; private set; }//el nombre de la clase de atributo, que representa el tipo


        #region constructor

        public BaseAttribute() { }

        public BaseAttribute(
            float value,
            float minvalue,
            float maxvalue,
            float increasestep, 
            string attributeName,
            GameEnums.Modifier formulaType)
        {
            Value = value;
            MinValue = minvalue;
            MaxValue = maxvalue;
            IncreaseStep = increasestep;
            FormulaType = formulaType;
            AttributeName = attributeName;
        }
        
        public BaseAttribute(BaseAttribute attr)
        {
            Value = attr.Value;
            MinValue = attr.MinValue;
            MaxValue = attr.MaxValue;
            IncreaseStep = attr.IncreaseStep;
            FormulaType = attr.FormulaType;
            AttributeName = attr.AttributeName;
        }
        
        public virtual BaseAttribute Clone()
        {
            return null;
        }
        
        #endregion

    }

}