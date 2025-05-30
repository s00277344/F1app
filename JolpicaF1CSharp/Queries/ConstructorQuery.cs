﻿namespace JolpicaF1CSharp
{
    public class ConstructorQuery : BaseQuery<ConstructorFilters>
    {
        private static readonly string DEFAULT_QUERY = $"{IJolpicaF1Query.JOLPICAF1_ADDRESS}";
        private static readonly string END_QUERY = "/constructors";
        private static readonly List<string> FILTER_ORDER = new List<string>() { "Season", "Round", "Circuit", "Constructor", "Driver", "Fastest", "Grid", "Results", "Status" };
        public ConstructorQuery() : base(DEFAULT_QUERY, END_QUERY, FILTER_ORDER)
        {
            this.Filter(nameof(ConstructorFilters.season), 2025);
        }
    }
}
