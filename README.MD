# C#: Hair Salon Management
#### By _Shruti Priya_

### Description
_This program is a web application designed for managing a hair salon. It will allow the owner to add stylists to a list, add clients for each stylist, and store the information. The program will also allow for basic data manipulation such as: removing a stylist from the salon database, removing a client from a stylist's records, and deleting all stylists and clients._

### Specifications
| Behavior | Input | Output |
|:---  | :---  | :----  |
|Adds a new stylist to a list| `new stylist = "Nancy"`| `"List of Stylists: Nancy"`|
|Edits stylist name| `stylist = "Nancy", new name = "Nancy Jr."`| `"List of Stylists: Nancy Jr."`|
|Removes a stylist from list| `remove stylist "Nancy"`| `No stylists in list.`|
|Adds a client to a list of stylist's clients| `new client: name = "Beck", stylist = "Nancy";`| `"List of Nancy's clients: Beck"`|
|Edits client name| `client = "Beck", new name = "Becky"`| `"List of Nancy's clients: Becky"`|
|Removes a client from stylist records| `remove client "Becky"`| `No clients in Nancy's list.`|


### Setup/Installation Requirements
This program can only be accessed on a PC with Windows 10, and with Git, Atom, and Sql Server Management Studio (SSMS) installed.

* Clone this repository
* Import the database and test database:
  * Open SSMS
  * Select the following buttons from the top nav bar to open the database scripts file: File>Open>File>"Desktop\HairSalon\SqlDatabases\hair_salon.sql"
  * Save the hair_salon.sql file
  * To create the database: click the "!Execute" button on the top nav bar
  * To create the database another way, type the following into the top of the sql file:
    * CREATE DATABASE hair_salon;
    * GO
  * Refresh SSMS
  * Repeat the above steps to import the test database
* Test the program:
  * Type following command into PowerShell > dnx test
  * All tests should be passing, if not run dnx test again. Otherwise, fix the errors before launching the program on the browser.
* View the web page:
  * Type following command into PowerShell > dnx kestrel
* View "http://localhost:5004" in your default web browser

#### Step 2

Create the database using the following commands in PowerShell's SQLCMD:

* **CREATE DATABASE hair_salon;**
* **GO**
* **USE hair_salon;**
* **GO**
* **CREATE TABLE stylists (id INT IDENTITY(1,1), clientname VARCHAR(255));**
* **CREATE TABLE clients (id INT IDENTITY(1,1), clientname VARCHAR(255), stylist_id INT);**
* **GO**

### Known Bugs
No known bugs yet.

### Support and Contact Details
You can reach me via email: **shrutipriya1808@gmail.com**

### Technologies Used
C#, Nancy framework, HTML, Bootstrap framework, ASP.NET,SQL.

#### License
MIT

Copyright (c) 2016 **_(Shruti Priya)_**
