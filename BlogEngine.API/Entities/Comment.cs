using BlogEngine.API.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.API.Entities
{
    [Table("Blog_PostComments")]
    public class Comment:IEntity<int>//,IAuditEntity<User, int>
    {
        public int Id { get; set; }
        
        [StringLength(200)]
        public string Message { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }
    }
}
