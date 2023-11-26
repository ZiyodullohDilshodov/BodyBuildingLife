using BodyBuildingLife.Domain.Entities.Trainers;

namespace BodyBuildingLife.Domain.Entities.Assets;

public  class TrainerAsset : Asset
{
    public long TrainerId { get; set; }
    public Trainer Trainer { get; set; }
}
