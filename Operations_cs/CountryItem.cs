﻿namespace Operations
{
    public class CountryItem
    {
        public string Name { get; set; }
        public string Compact => Name.Replace(" ", "").Replace("'", "");
    }
}
