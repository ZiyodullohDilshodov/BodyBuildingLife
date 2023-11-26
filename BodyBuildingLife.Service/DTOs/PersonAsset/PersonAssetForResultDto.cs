namespace BodyBuildingLife.Service.DTOs.PersonAsset;

public  class PersonAssetForResultDto 
{
    public long Id { get; set; }
    public long Size { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Type { get; set; }
    public bool IsDeleted { get; set; }
    public long PersonId { get; set; }
    public string Extension { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
}
