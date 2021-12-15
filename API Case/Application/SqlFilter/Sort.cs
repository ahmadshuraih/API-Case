namespace API_Case.Application.SqlFilter
{
    //Deze klasse zorgt voor het sorteren van de opgevraagde gegevens (order by ....)
    public class Sort
    {
        //De kolomnaam waar de sortering afhankelijk van is
        public string Field { get; set; }

        //De sorteer type (asc, desc)
        public string SortType { get; set; }

        public Sort(string field, string sortType)
        {
            Field = field;
            SortType = sortType;
        }

        //Maak het soort gedeelte aan op basis van de waarden van sort
        public string CreateSortString()
        {
            if (Field != null && !Field.Equals("") && SortType != null && !SortType.Equals(""))
            {
                return string.Format(" order by {0} {1}", Field, SortType);
            }
            return "";
        }
    }
}
