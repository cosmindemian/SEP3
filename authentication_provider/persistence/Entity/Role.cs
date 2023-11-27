using System.ComponentModel.DataAnnotations;

namespace persistance.Entity;

public class Role
{
    [Key]
   public long Id { set; get; }
   public string Name { set; get; }
    List<Credential> Credentials { set; get; }
    
    private Role(long id, string name)
    {
        Id = id;
        Name = name;
        Credentials = new List<Credential>();
    }

    private Role()
    {
        Credentials = new List<Credential>();
    }
}