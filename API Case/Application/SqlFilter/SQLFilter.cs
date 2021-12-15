namespace API_Case.Application.SqlFilter
{
    //Het hoofd klasse van het filtering
    public class SQLFilter
    {
        //De offset waarde van de query, niet nodig dan laat maar leeg ""
        public string Offset { get; set; }

        //De limit waarde van de query, niet nodig dan laat maar leeg ""
        public string Limit { get; set; }

        //De sort object
        public Sort Sort { get; set; }

        //De filters lijst
        public List<Filter> Filters { get; set; }

        public SQLFilter() { }

        public SQLFilter(string offset, string limit, Sort sort, List<Filter> filters)
        {
            Offset = offset;
            Limit = limit;
            Sort = sort;
            Filters = filters;
        }

        //Voeg een filter naar het lijst toe
        public void addFilter(Filter filter)
        {
            Filters.Add(filter);
        }

        //Maak het gehele filter en soort string
        public string CreateFiltersAndSortString()
        {
            string offsetString = "";
            string limitString = "";
            string sortString = "";
            string filterString = "";

            if (!Offset.Equals("") && Offset != null)
            {
                offsetString = " offset " + Offset;
            }

            if (!Limit.Equals("") && Limit != null)
            {
                limitString = " limit " + Limit;
            }

            if (Sort != null)
            {   //Maak de sortstring aan
                sortString = Sort.CreateSortString();
            }

            if (Filters != null && Filters.Any())
            {   //loop in door het lijst en maak de filterstring als het lijst niet leeg is
                for (int i=0; i < Filters.Count(); i++)
                {
                    //lastFilter attribuut wordt gebruikt om te bepalen of de filter logic moet hebben of niet
                    bool notLastFilter = i != (Filters.Count() - 1);
                    filterString += Filters[i].CreateFilterString(notLastFilter);
                }

                //Als de filter string niet leeg is, voeg " where " aan het begin toe
                if (!filterString.Equals(""))
                {
                    filterString = " where" + filterString;
                }
            }

            return filterString + sortString + limitString + offsetString;
        }
    }
}
