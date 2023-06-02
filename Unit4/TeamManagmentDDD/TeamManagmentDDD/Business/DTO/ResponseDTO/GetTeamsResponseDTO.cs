namespace Business.DTO.ResponseDTO
{
    public class GetTeamsResponseDTO
    {
        public int IdTeam { get; set; }
        public string NameTeam { get; set; }

        public override string ToString()
        {
            return $"Id: {IdTeam} Name: {NameTeam}";
        }
    }
}
