namespace BaseLibrary
{
    public class ColumnDetails
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public string NameBracketed => $"[{Name}]";

        public override string ToString()
        {
            return Name;
        }
    }
}
