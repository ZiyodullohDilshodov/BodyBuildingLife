namespace BodyBuildingLife.Service.Exceptions;

public  class BodyBuildingLifeException : Exception
{
    public int StatusCode { get; set; }
    public BodyBuildingLifeException(int code ,string massage):base(massage)
    {
        StatusCode = code;
    }
}
