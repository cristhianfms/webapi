using System;
using System.Collections.Generic;
using System.Text;
using Reports.Domain;

namespace Reports.Webapi.Models
{
    public class IndicatorModel : Model<Indicator, IndicatorModel>
    {

        public Guid Id { get; set; }
        public string Color { get; set; }
        public string Expression { get; set; }
        public Dictionary<char, ConditionModel> Conditions { get; set; }


        public IndicatorModel() {
            Conditions = new Dictionary<char, ConditionModel>();
        }
    
        public IndicatorModel(Indicator entity)
        {
            SetModel(entity);
        }



        public override Indicator ToEntity()
        {
            return new Indicator()
            {
                Id = this.Id,
                Color = this.Color,
                Component = ToEntityComponent()
            };
        }



        private Component ToEntityComponent()
        {
            if(Expression.Length == 1)
            {
                ConditionModel cModel = Conditions.GetValueOrDefault(Expression[0]);
                Condition cEntity = cModel.ToEntity();
                return cEntity;
            }

            LogicExpression raiz = CreateComponentNode(Expression[0]);
            raiz.CompIzq = Conditions.GetValueOrDefault(Expression[1]).ToEntity();
            raiz.CompDer = Conditions.GetValueOrDefault(Expression[2]).ToEntity();

            int index = 3;
            while (index < Expression.Length)
            {
                LogicExpression aux = raiz;
                raiz = CreateComponentNode(Expression[index]);
                index++;
                raiz.CompIzq = aux;
                raiz.CompDer = Conditions.GetValueOrDefault(Expression[index]).ToEntity();
                index++;
            }

            return raiz;
        }

        private LogicExpression CreateComponentNode(char type)
        {
            if (type == '+')
            {
                return new LogicOr();
            }
            else if (type == '*')
            {
                return new LogicAnd();
            }
            return null;
        }





        protected override IndicatorModel SetModel(Indicator entity)
        {
            this.Id = entity.Id;
            this.Color = entity.Color;

            Dictionary<char, ConditionModel> conditions = new Dictionary<char, ConditionModel>();
            String expresion = "";
            char c = 'a';
            CreateDictionary(entity.Component, conditions, ref expresion, ref c);
            this.Conditions = conditions;
            this.Expression = expresion;
            return this;
        }

        private void CreateDictionary(Component component, Dictionary<char, ConditionModel> dictionary,
            ref String expresion, ref char c)
        {
            if (component.GetType().Name == "Condition")
            {
                ConditionModel conditionModel = new ConditionModel((Condition)component);
                dictionary.Add(c, conditionModel);
                expresion += c;
                c++;
            }

            else if (component.GetType().Name == "LogicOr")
            {
                expresion += '+';
                CreateDictionary(((LogicOr)component).CompDer, dictionary, ref expresion,ref c);
                CreateDictionary(((LogicOr)component).CompIzq, dictionary, ref expresion, ref c);
            }
            else if (component.GetType().Name == "LogicAnd")
            {
                expresion += '*';
                CreateDictionary(((LogicAnd)component).CompDer, dictionary, ref expresion, ref c);
                CreateDictionary(((LogicAnd)component).CompIzq, dictionary, ref expresion, ref c);
            }
        }






    }
}
