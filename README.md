# CodeChallenge
Premium Calculator
---------------------

INTRODUCTION
------------
The application Premium Calculator gathers the User data and calculates the 
premium. The application calls the Web API Services to get the relevant information.



System Prerequisites
--------------------
* UI: The UI is built on:
    - Angular 8.0 and HTML 5.0 (for UI)
    - TS-Lint (for validation and error correction)
    - BootStrap v4.3 (for UI styling and organization)

* Backend: The back end is built on:
    - .Net Core 2.2.0 (framework)
    - Web API (the service interface)
    - NUnit (for unit tests)


Project Structure
------------------
The project is divided into two directories:
* CodeTask-SPA : a single page application built on Angular.
* CodeTask.API : a service layer interfacing with the Angular project.


Running the application
------------------------
The Angular application is production built and deployed in CodeTask.API/wwwroot. Open the solution CodeTask.sln in the visual studio and run the application. The localhost URL is: http://localhost:5000


Assumptions
--------------------
 - The application is assumed to be a single page application
 - UI: The Name field has restriction of minimum 3 characters and maximum 25 characters.
 - UI: The minimum Sum Issured value is $100 and maximum is $999,999,999.


Running the Tests on the application
-------------------------------------
Unit test coverage is work in progress.


Work in progress Items
---------------------
The application is in MVP state and some essential aspects are still in development. They are:
    - Service Layer's Unit testing is work in progress.
    - Date of birth field's validation for invalid dates is in progress.
    - Sanitization of the UI layer to stop XSS attacks is in progress.
    - Code refactoring on Web API is in progress.
