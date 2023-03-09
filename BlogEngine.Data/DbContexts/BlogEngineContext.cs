using BlogEngine.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogEngine.API.DbContexts
{
    public class BlogEngineContext:IdentityDbContext<User,Role,int>
    {
        public BlogEngineContext(DbContextOptions<BlogEngineContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed admin role
            modelBuilder.Entity<Role>().HasData(
                new IdentityRole<int>
            {
                Name = "Public",
                NormalizedName = "PUBLIC",
                Id = 1,
                ConcurrencyStamp = "public"
            },
                new IdentityRole<int>
            {
                Name = "Editor",
                NormalizedName = "EDITOR",
                Id = 2,
                ConcurrencyStamp = "editor"
            },
                new IdentityRole<int>
            {
                Name = "Writer",
                NormalizedName = "WRITER",
                Id = 3,
                ConcurrencyStamp = "writer"
            });

            //create user
            var userPublic = new User
            {
                Id = 1,
                Email = "public@mail.com",
                EmailConfirmed = true,
                //FirstName = "pedro",
                //LastName =  "perez",
                UserName = "public@mail.com",
                NormalizedUserName = "PUBLIC@MAIL.COM", ConcurrencyStamp="1",
                FullName ="Alejandro Fernandez - Public"
            };
            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            userPublic.PasswordHash = ph.HashPassword(userPublic, "123qwe123");

            var userEditor = new User
            {
                Id = 2,
                Email = "editor@mail.com",
                EmailConfirmed = true,
                //FirstName = "pedro",
                //LastName =  "perez",
                UserName = "editor@mail.com",
                NormalizedUserName = "EDITOR@MAIL.COM",
                ConcurrencyStamp = "1",
                FullName = "Pedro Perez - Editor"
            };
            //set user password
            userEditor.PasswordHash = ph.HashPassword(userEditor, "123qwe123");

            var userWriter = new User
            {
                Id = 3,
                Email = "writer@mail.com",
                EmailConfirmed = true,
                //FirstName = "pedro",
                //LastName =  "perez",
                UserName = "writer@mail.com",
                NormalizedUserName = "WRITER@MAIL.COM",
                ConcurrencyStamp = "1",
                FullName = "HP Lovecraft - Writer"
            };
            //set user password
            userWriter.PasswordHash = ph.HashPassword(userWriter, "123qwe123");

            var userWriter2 = new User
            {
                Id = 4,
                Email = "writer2@mail.com",
                EmailConfirmed = true,
                //FirstName = "pedro",
                //LastName =  "perez",
                UserName = "writer2@mail.com",
                NormalizedUserName = "WRITER2@MAIL.COM",
                ConcurrencyStamp = "1",
                FullName = "J.R.R Tolkien - Writer"
            };
            //set user password
            userWriter.PasswordHash = ph.HashPassword(userWriter, "123qwe123");

            //seed user
            modelBuilder.Entity<User>().HasData(userPublic);
            modelBuilder.Entity<User>().HasData(userEditor);
            modelBuilder.Entity<User>().HasData(userWriter);
            modelBuilder.Entity<User>().HasData(userWriter2);

            //set user role to admin
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 2
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 3,
                UserId = 3
            });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 3,
                UserId = 4
            });


            //blog seed

            modelBuilder.Entity<Post>().HasData(
                new Post
            {
                Id = 1,
                Title = "Post demo 1",
                Content = "this is a demo description", 
                CreatorId = 3, 
                IsPublish= true, 
                PublishDate = DateTime.Now.AddDays(-3),
            },
                new Post
            {
                Id = 2,
                Title = "Post demo 2",
                Content = "this is a demo description",
                CreatorId = 4,
                IsPublish = true,
                PublishDate = DateTime.Now.AddDays(-2),
            });

            modelBuilder.Entity<Comment>().HasData(
                    new Comment { 
                        Id = 1, 
                        Message = "Excelente post", 
                        PostId = 2 , 
                        CreatorId = 1
                    },
                    new Comment { 
                        Id = 2, 
                        Message = "lo que dijo el de arriba", 
                        PostId = 2 ,
                        CreatorId = 2
                    });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
