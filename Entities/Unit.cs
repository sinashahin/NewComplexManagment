namespace Entities
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlockId { get; set; }
        public ResidenceType ResidenceType { get; set; }

        public Block Block { get; set; }
    }
}
