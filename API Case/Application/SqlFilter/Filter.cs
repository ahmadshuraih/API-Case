namespace API_Case.Application.SqlFilter
{
    //Deze klasse zorgt voor de conditie deel van de query (WHERE.....)
    public class Filter
    {
        //De kolomnaam die gaat vergeleken worden
        public string Field { get; set; }

        //De opertor van het vergeleken, een lijst daarvan staat hieronder (Operators)
        public string Operator { get; set; }

        //De gewenste waarde
        public dynamic Value { get; set; }

        //De koppel logica dit filter en de volgende filter (or, and)
        //Als er geen vervolg conditie, hou dit maar leeg ""
        public string Logic { get; set; }

        public Filter(){}

        public Filter(string field, string op, dynamic value, string logic)
        {
            Field = field;
            Operator = op;
            Value = value;
            Logic = logic;
        }

        //De operaties lijst
        private static readonly IDictionary<string, string> Operators = new Dictionary<string, string>
        {
            {"eq", "= {1}"},                    //Equals
            {"neq", "!= {1}"},                  //Not Equals
            {"lt", "< {1}"},                    //Less Than
            {"lte", "<= {1}"},                  //Less Than or Equal
            {"gt", "> {1}"},                    //Greater Than
            {"gte", ">= {1}"},                  //Greater than or Equal
            {"in", "in ({1})"},                 //In list, voorbeeld van list items door value attribuut val1,val2,val3
            {"nin", "not in ({1})"},            //Not in list, voorbeeld van list items door value attribuut val1,val2,val3
            {"like", "like '{1}'"},             //Like string
            {"startswith", "like '{1}%'"},      //Starts with string
            {"endswith", "like '%{1}'"},        //Ends with string
            {"contains", "like '%{1}%'"},       //Contains string
            {"notcontain", "not like '%{1}%'"}  //Not contains string
        };

        //Maak een conditie aan op basis van de waarden van dit filter
        public string CreateFilterString(bool withLogic)
        {
            string filterString = "";

            if (Field != null && !Field.Equals("") && Operator != null && !Operator.Equals("") && !Value.Equals(""))
            {
                filterString = string.Format(" {0} " + Operators[Operator], Field, Value);
            }

            //Als dit filter niet het laatste filter in filters lijst is
            if (withLogic && Logic != null)
            {
                filterString += " " + Logic;
            }
            return filterString;
        }
    }
}
