# BlogEngine

This is a blog web api project for interview on zemoga


## Project Structure
```
├── BlogEngine.API
│   ├── Controllers
│   │	├──AuthenticationController.cs
│   │	├──BlogController.cs
│   │	├──CommentsController.cs
│   │	├──PostController.cs
│   │	└──PublishController.cs
│   ├── appsettings.js
│   ├── Program.cs
│   ├── Startup.cs
│   └── UserSesion.cs
├── BlogEngine.Domain
│   ├── Models
│   │	└──PostDto.cs
│   ├── Profiles
│   │	└──AutoMapperProfiles.cs
│   └── Services
│   	├──Exceptions
│		│	├──CannotEditPublishedPostException.cs
│		│	├──CannotEditSubmittedPostException.cs
│		│	├──CannotSubmitPublishedPostException.cs
│		│	├──NotTheAuthorOfPostException.cs
│		│	├──PostNotFoundException.cs
│		│	├──PostNotPublishException.cs
│		│	└──PostStatusNotValidException.cs
│   	├──Interfaces
│		│	├──ICommentService.cs
│		│	├──IPostService.cs
│		│	└──IPublishService.cs
│   	├──CommentService.cs
│   	├──PostService.cs
│   	└──PublishService.cs
├── BlogEngine.Data
│   ├── DbContexts
│   │	└──BlogEngineContext.cs
│   ├── Entities
│	│	├──Comment.cs
│	│	├──Post.cs
│	│	├──Role.cs
│	│	└──User.cs
│   ├── Migrations
│	├──Repository.cs
│	└──UnitOfWork.cs
├── BlogEngine.Core
│   ├── IEntity.cs
│   ├── IRepository.cs
│   ├── IUnitOfWork.cs
│   └── IUserSession.cs
├── BlogEngine.Test
│   ├── BaseTest.cs
│   ├── CommentService_Shoud.cs
│   ├── DbFixture.cs
│   ├── MockUserSession.cs
│   ├── PostService_Should.cs
│   ├── PublishService_Should.cs
│   └── Usings.cs
├──Zemoga.BlogEngine.postman_collection.json   
```

- `BlogEngine.API` is .NET Core Web API main app
- `BlogEngine.Domain` Contains de the domain logic of project, Dtos, Mappers
- `BlogEngine.Data` Contains Ef DbContext and entities
- `BlogEngine.Core` Contains infraestructure utils of project as IRepository, IUserSession
- `BlogEngine.Test` Contains the UnitTest of the application.
- `Zemoga.BlogEngine.postman_collection.json ` is the postman collection on local

## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/ddo88/blogengine.git
```

## Run Migrations

```sh
$ Update-Database
```
this create the db structure and seed initial data as users, roles, and some post with comments

## Run API Project

On visual Studio run BlogEngine.API project


## WebAPI publish on Azure

**Url:** https://zemoga.azurewebsites.net/swagger/index.html

**Users:**

	*public role*
		u: public@mail.com p: 123qwe123

	*writer role*
		u: writer1@mail.com p: 123qwe123
		u: writer2@mail.com p: 123qwe123

	*editor role*
		u: editor@mail.com p: 123qwe123
	