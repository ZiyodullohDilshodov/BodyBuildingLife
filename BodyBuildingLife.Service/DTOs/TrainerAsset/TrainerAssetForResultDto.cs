namespace BodyBuildingLife.Service.DTOs.TrainerAsset;

public  class TrainerAssetForResultDto
{
    public long Id { get; set; }
    public long Size { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public string Type { get; set; }
    public long TrainerId { get; set; }
    public string Extension { get; set; }
    public DateTime CreateAtt { get; set; }
    public DateTime UpdateAtt { get; set; }
}
