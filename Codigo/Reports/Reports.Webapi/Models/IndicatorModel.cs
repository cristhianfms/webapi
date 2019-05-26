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
                Condition = ToEntityCondition()
            };
        }



        private BaseCondition ToEntityCondition()
        {
            if(Expression.Length == 1)
            {
                ConditionModel cModel = Conditions.GetValueOrDefault(Expression[0]);
                Condition cEntity = cModel.ToEntity();
                return cEntity;
            }

            CompositeCondition raiz = CreateConditionNode(Expression[0]);
            raiz.Izq = Conditions.GetValueOrDefault(Expression[1]).ToEntity();
            raiz.Der = Conditions.GetValueOrDefault(Expression[2]).ToEntity();

            int index = 3;
            while (index < Expression.Length)
            {
                CompositeCondition aux = raiz;
                raiz = CreateConditionNode(Expression[index]);
                index++;
                raiz.Izq = aux;
                raiz.Der = Conditions.GetValueOrDefault(Expression[index]).ToEntity();
                index++;
            }

            return raiz;
        }

        private CompositeCondition CreateConditionNode(char type)
        {
            if (type == '+')
            {
                return new OrCondition();
            }
            else if (type == '*')
            {
                return new AndCondition();
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
            CreateDictionary(entity.Condition, conditions, ref expresion, ref c);
            
            this.Conditions = conditions;
            this.Expression = expresion;
            return this;
        }

        private void CreateDictionary(BaseCondition condition, Dictionary<char, ConditionModel> dictionary,
            ref String expresion, ref char c)
        {
            if (condition.GetType().Name == "ConditionProxy" ||
                condition.GetType().Name == "Condition")
            {
                ConditionModel conditionModel = new ConditionModel((Condition)condition);
                dictionary.Add(c, conditionModel);
                expresion += c;
                c++;
            }

            else if (condition.GetType().Name == "OrConditionProxy" ||
                condition.GetType().Name == "OrCondition")
            {
                expresion += '+';
                CreateDictionary(((OrCondition)condition).Der, dictionary, ref expresion,ref c);
                CreateDictionary(((OrCondition)condition).Izq, dictionary, ref expresion, ref c);
            }
            else if (condition.GetType().Name == "AndConditionProxy" ||
                condition.GetType().Name == "AndCondition")
            {
                expresion += '*';
                CreateDictionary(((AndCondition)condition).Der, dictionary, ref expresion, ref c);
                CreateDictionary(((AndCondition)condition).Izq, dictionary, ref expresion, ref c);
            }
        }






    }
}
