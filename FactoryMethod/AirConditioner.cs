using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    public class AirConditioner
    {
        private readonly Dictionary<Actions, AirConditionerFactory> _factories;
        public AirConditioner()
        {
            foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
                _factories.Add(action, factory);
            }
           
            //    _factories = new Dictionary<Actions, AirConditionerFactory>
            //{
            //    { Actions.Cooling, new CoolingFactory() },
            //    { Actions.Warming, new WarmingFactory() }
            //};
        }
        public IAirConditioner ExecuteCreation(Actions action, double temperature)
               => _factories[action].Create(temperature);
    }
}
