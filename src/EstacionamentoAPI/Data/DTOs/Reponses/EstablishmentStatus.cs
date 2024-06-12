namespace EstacionamentoAPI.DTOs.Responses
{
    public class EstablishmentStatus
    {
        public int EstablishmentId { get; set; }

        public int TotalMotorcycleSpaces { get; set; }
        public int TotalCarSpaces { get; set; }
        public int OccupiedCarSpaces { get; set; }
        public int OccupiedMotorcycleSpaces { get; set; }
        public int AvailableCarSpaces { get; set; }
        public int AvailableMotorcycleSpaces { get; set; }
    }
}