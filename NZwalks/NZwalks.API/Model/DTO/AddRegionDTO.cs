namespace NZwalks.API.Model.DTO
{
    public class AddRegionDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}
