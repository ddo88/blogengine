using Microsoft.AspNetCore.Identity;

namespace BlogEngine.API.Entities
{
    public class User : IdentityUser<int>//, IEntity<int>
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        public string FullName { get; set; }
    }
}
