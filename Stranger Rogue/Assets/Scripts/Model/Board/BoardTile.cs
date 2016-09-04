

public class BoardTile
{
  public int FoodAvailableResource;
  public int ScienceAvailableResource;
  public int IndustryAvailableResource;
  public TileType Type  { get; set; }

  public BoardTile(TileType type, int food, int science, int industry)
  {
    Type = type;
    FoodAvailableResource = food;
    ScienceAvailableResource = science;
    IndustryAvailableResource = industry;
  }

  public BoardTile(TileType type)
  {
    Type = type;
  }
}
