using BlogEngine.API.Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogEngine.API.Entities
{
    [Table("Blog_Post")]
    public class Post: IEntity<int>//,IAuditEntity<User,int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Content { get; set; }

        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        public User Creator { get; set; }

        public bool IsPublish { get; set; }
        public DateTime? PublishDate { get; set; }

        [DefaultValue(0)]
        public PostStatus Status { get; set; }

        public string? ReasonOfReject { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }

    public enum PostStatus
    { 
        Created = 0,
        Submitted = 1,
        Publish = 2
    }
}
