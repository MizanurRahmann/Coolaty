<p style="font-size: 25px"><b>Coolaty</b></p>
Coolaty is an e-commerce web application for selling ice cream to consumers having both customer and admin panel made with ASP .NET CORE MVC and raw HTML, CSS and Javascript.
<br/><br/>

<p style="font-size: 25px"><b>Architecture</b></p>
This is a MVC (Model View Controller) project. To separate view and business logics I’ve using Onion architecture for this project. This architecture have three main layers (1) Controller layer (2) Service layer and (3) Repository layer.

<img width="1512" alt="project-architecture" src="https://github.com/MizanurRahmann/Coolaty/assets/37991614/d51a6751-99d6-47d5-9a87-c19f3749299b">

The controller layer interacts with users and ensures all the requested services are provided properly. The service layer is a bridge between the controller and Repository layers. This layer takes instructions from the controller and passes them to the repository. After performing the instruction from the repository, it takes the result from the repository and performs modifications (if needed), then passes the information to the controller.

