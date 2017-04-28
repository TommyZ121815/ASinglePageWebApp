I built this project with dependencies injection and Façade design pattern. Used Entity framework, Newtonsoft, Moq and Ninject these frameworks.

The whole project has been divided into six parts. There are Model, Data access layer, Service layer(.Net library and web API), MVC and Unit Testing. 

1. Model: Contains the data entities with C# Object

2. DAL: Interact with the database. 

IGenericRepository provides a contact for building Repository.

GenericRepository implements basic CRUD functions.

ContactRepository is a repository only for providing data and doing operations on contact. It has an inner interface IContactRepository for restricting itself behavior

3. SL:

ContactService is for wrapping up the data from the repository. Using dependency injection injects the ContactRepository with IContactRepository.

4. SL(Web Api):

Built a REST service and providing with webProviding the data and operations through HTTP verbs. Authentication and authorization could be done in future with requirement file. Still working on the pagtation

Using dependency injection injects the ContactService with IContactService.

5. MVC

Consuming the data from Web Api by using HTTPClient. The presentation layer can be done in mutilated ways. Like using AngluarJS with AJAX or mobile technology.

6. Unit Test

Using MSTest and Moq created dump data and tested do the functionalities work properly.
