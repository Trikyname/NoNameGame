

using Assets.Scripts.Game.Commun;
/**
*Descripcion de la clase: Clase abstracta base para la definicion de todos los equipos que hereden de esta
*Version:v01
*Fecha:02/01/2021
**/
namespace Assets.Scripts.Game.Datas.Device
{
    [System.Serializable]
    public abstract class BaseDevice
    {

        /// <summary>
        /// Estos valores nunca se puede modificar. Son los valores base leidos de BD o Json.
        /// </summary>
        public float Value { get; private set; }//Valor actual. 
        public float MinValue { get; private set; }//Minimo valor posible. 
        public float MaxValue { get; private set; }//Maximos valor posible. 
        public float IncreaseStep { get; private set; }//Valor de incremento para subir este device por la experiencia por ejemplo. 
        public GameEnums.Modifier Modifier { get; private set; }

        public string Name { get { return GetType().Name; } }//devuelve el nombre de la clase de device, que representa el tipo


        #region constructor

        public BaseDevice() { }

        public BaseDevice(
            float value,
            float minvalue,
            float maxvalue,
            float increasestep, 
            GameEnums.Modifier modifier)
        {
            Value = value;
            MinValue = minvalue;
            MaxValue = maxvalue;
            IncreaseStep = increasestep;
            Modifier = modifier;
        }
        
        public BaseDevice(BaseDevice attr)
        {
            Value = attr.Value;
            MinValue = attr.MinValue;
            MaxValue = attr.MaxValue;
            IncreaseStep = attr.IncreaseStep;
            Modifier = attr.Modifier;
        }
        
        public virtual BaseDevice Clone()
        {
            return null;
        }
        
        #endregion

    }

}