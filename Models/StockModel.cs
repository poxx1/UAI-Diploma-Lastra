namespace Models
{
    public class StockModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int Quantity { get; set; }
        public int StockLimit { get; set; }
        public int MiniumStock { get; set; }

    }
}