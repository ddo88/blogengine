# BlogEngine

This is a Blog created for inteview on Zemoga
# .NET Core Web API Starter Project

This is a boilerplate template for building / deploying a .NET Core Web API microservice on Kubernetes / Azure Container Instance.
This leverages .NET 6, new hosting model, and new routing API to enhance .NET performance. You can learn .NET 6 more on [ASP.NET Core minimal APIs](https://www.dotnetthailand.com/web-frameworks/asp-net-core/asp-net-core-minimal-apis).

## Versioning
| GitHub Release | .NET Core Version | Diagnostics HealthChecks Version |
|----------------|------------ |---------------------|
| main | 6.0.100-preview.6.21355.2 | 2.2.0 |

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

- `Dockerfile` is .NET Core Web API Multistage Dockerfile (following Docker Best Practices)
- `KubernetesLocalProcessConfig.yaml` is [Bridge to Kubernetes](https://devblogs.microsoft.com/visualstudio/bridge-to-kubernetes-ga/) config to supports developing .NET Core Web API microservice on Kubernetes
- `configs` folder will contain .NET Core Web API centralized config structure
- `appsettings.Development.json` is .NET Core Web API development environment config
- `manifests` folder will contain Kubernetes manifests (deployment, service)
- `Startup.cs` is .NET Core Web API startup & path routing config 
- `Program.cs` is .NET Core Web API environment variable mapping config 

## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/kubeopsskills/dotnet-core-web-api.git
$ cd dotnet-core-web-api
```

followed by

```sh
$ dotnet restore
```
