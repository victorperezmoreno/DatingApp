namespace API.DTOs
{
  public class PhotoDto
  {
    public PhotoDto()
    {
      
    }

    public PhotoDto(int id, string url, bool isMain)
    {
      Id = id;
      Url = url;
      IsMain = isMain;
    }

    public int Id { get; set; }
    public string Url { get; set; }
    public bool IsMain { get; set; }
  }
}