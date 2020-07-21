PLEASE READ THE FOLLOWING INSTRUCTIONS CAREFULLY BEFORE YOU PROCEED WITH YOUR TEST (we really mean it!!! ) Guidelines:

● Always make use of the OOP (abstraction, polymorphism, encapsulation, and Inheritance) principles when designing your Solution
● Keep in mind the separation of concerns principle so your code is more organized
● The design and use of best practices will be evaluated.
● You will need to send us the link of a public available repository (github, bitbucket, etc), once you finish.
● The application you upload should be able to run in a standard Visual Studio 2017 installation that we will use to review it. Avoid Using external
tools/software that can cause us trouble when reviewing your solution.

Create a simple web application following the next steps:

1. Create a data access layer that consumes the following API as your data repository.

2. Create a Business Logic layer so you can retrieve the employees’ information including a calculated Annual Salary following these rules:
- Create your DTO(Data Transfer Object) Classes depending on the type of Contract that a given employee has(Hourly or Monthly).
- Make use of a simple Factory Method to create the concrete classes so you can calculate the salary depending on the type of contract.
- Employees can have to 2 types of Contracts: Hourly Salary Contract and Monthly Salary Contract.

  ● For Hourly Salary Employees the Annual Salary is: 120 * HourlySalary * 12
  ● For Monthly Salary Employees the Annual Salary is: MonthtlySalary * 12

3. Create a WEB API Controller that can return information for a given employee or multiple employees.

4. In your MVC Application Create a View and a Controller following these guidelines:You can use the front end technologies you are familiar 
with (JavaScript, JQuery, Angular etc.)
- The view must contain a textbox so the user can type the id of a particular employee.
- The view must contain a Get Employees button
- If the textbox is empty, when the Get Employees button is clicked, retrieve the information for all the employees including the calculated 
Annual Salaries by calling your APIs
- If the textbox has the id of a given employee, retrieve only the information for that particular employee including the calculated Annual 
Salary by calling your APIs
- Information must be displayed in a table and can be manually styled or using Bootstrap.

5. OPTIONAL BONUS POINT: Create one Unit test to test one of the methods of your
Business Logic Layer
