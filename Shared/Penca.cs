namespace Shared
{
    public class Penca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Double costo_entrada { get; set; }
        public Double poso { get; set; }
        public Double comision { get; set; }
        public int cant_participantes { get; set; }
        public bool priada { get; set; }
        public int codigo { get; set; }
        public virtual ICollection<User_Penca> User_Penca { get; set; }
        public int? CampeonatoId { get; set; }
    }
}