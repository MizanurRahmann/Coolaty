## Coolaty
Coolaty is an e-commerce web application for selling ice cream to consumers having both customer and admin panel made with ASP .NET CORE MVC and raw HTML, CSS and Javascript.

## Architecture
This is a MVC (Model View Controller) project. To separate view and business logics I’ve using Onion architecture for this project. This architecture have three main layers (1) Controller layer (2) Service layer and (3) Repository layer. The controller layer interacts with users and ensures all the requested services are provided properly.
<br/><br/>
<img width="1512" alt="project-architecture" src="https://github.com/MizanurRahmann/Coolaty/assets/37991614/d51a6751-99d6-47d5-9a87-c19f3749299b">
<br/><br/>
The service layer is a bridge between the controller and Repository layers. This layer takes instructions from the controller and passes them to the repository. After performing the instruction from the repository, it takes the result from the repository and performs modifications (if needed), then passes the information to the controller.

## Build With
[![ASP.NET][dotnet]][dotnet-url] [![C#][csharp]][csharp-url] [![Javascript][Javascript]][Javascript-url] [![html5][html5]][html5-url] [![css3][css3]][css3-url]

<!-- MARKDOWN LINKS & IMAGES -->
[csharp]: https://img.shields.io/badge/csharp-20232A?style=for-the-badge&logo=csharp&logoColor=239120
[csharp-url]: https://nextjs.org/
[dotnet]: https://img.shields.io/badge/ASP.NET-20232A?style=for-the-badge&logo=.NET&logoColor=512BD4
[dotnet-url]: https://learn.microsoft.com/en-us/dotnet/
[Javascript]: https://img.shields.io/badge/Javascript-20232A?style=for-the-badge&logo=Javascript&logoColor=F7DF1E
[Javascript-url]: https://learn.microsoft.com/en-us/dotnet/
[html5]: https://img.shields.io/badge/html5-20232A?style=for-the-badge&logo=html5&logoColor=E34F26
[html5-url]: https://learn.microsoft.com/en-us/dotnet/
[css3]: https://img.shields.io/badge/css3-20232A?style=for-the-badge&logo=css3&logoColor=1572B6
[css3-url]: https://learn.microsoft.com/en-us/dotnet/