namespace NZwalks.API.Model.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
       
        public Regions Regions { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
