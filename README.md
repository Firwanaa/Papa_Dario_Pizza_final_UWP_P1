C# .Net UWP application represent orders portal for pizza restaurant. 
Part 1: User UI. 
Part 2: Admin UI.

# Introduction
**Papa Dario’s Pizza website**, is a system created by using one of .Net technologies the Universal Windows Platform “UWP” and coded with C#, it consist of with two parts:
● User Interface: which provide a variety of functionalities, like:
○ Users can place orders.
○ Users can see Papa Dario’s Pizza today’s Combo deals.
○ Users can join Fan Club.
○ Get discounts “club members only”.
○ See the receipt and be able to save it locally.
○ Logged in users can view all their orders.
○ Logged in users can edit their info.
○ Navigate between pages and view About page.
Most operations represent an interaction between UI and the database.
The user is provided with limited ability to edit info.
![p1](https://user-images.githubusercontent.com/65984781/133002064-79518576-fc8d-41c3-b594-038f3ac96d18.png)

**Admin Interface**, represents a separate application with a higher access to the database , admin using this UI can view all users in the DB, insert, update, find and delete any user “CRUD operations”.
![p2](https://user-images.githubusercontent.com/65984781/133002092-0b4d785e-82b2-4b12-8cc1-684661ac4f88.png)

# Connected Database Model
This project uses connected architecture, where connections need to be maintained in order to be able to interact with the database, using DataReader to fetch data from the database. The advantages of using Connected architecture are that Insert, Update, View and Delete operations can be accessed directly from the database. In this model the central database is always up-to-date. The disadvantages of this model is that it’s slower and needs a consistent connection available.

# SQL Injection Prevention
To prevent SQL injection attacks all queries used in this application “both parts” where parameterized queries, which will isolate any data provided by any parameter from the body of the query “ex. @tempUser.Username”, This process will replace any data provided by textual placeholders.
![image](https://user-images.githubusercontent.com/65984781/133002261-37cf953d-aa24-461f-ab10-52a1838a0077.png)
![image](https://user-images.githubusercontent.com/65984781/133002266-95ac5f08-d60b-416a-9028-052e26e45315.png)

# CRUD
Since the core of this application depends on an interaction between the database and the end user. In the first part, the CRUD operations are represented by the user being able to register in the website “create” and
able to log in “read”, and edit user info “update”. Also, the logged in users will be able to view their orders history as well. The Admin UI provides the system admin the control over User tables, using the admin portal, admin can view all registered users, insert new user, update any user and delete any user as well.

# General Features 
**Order UI:**
Logged in users get a 10% discount.
Logged in users can view their order history
Choosing combo from front page will auto direct to direct to Order page and pre-fill required fields.
Once logged in, log in fields will be disabled till the user clicks logout.
Once logged in, register form will be disabled and enabled on logout.
Edit Button will hide login form and show update form pre-filled with user info.
Unique username, can not be registered twice.
Logged user username will be displayed in the new order page and will be passed to each receipt.
Username letter casing will be handled with the application despite user input.

**Admin UI:**
The application auto loads all users in the View page.
Once admin inserts a new user all fields will be cleared.
To update users, admin can look it up first in the DB, if found all fields will be auto-filled by current values in the DB, username field will be disabled.
Once the user is done updating, the fields will be cleared out and the username field will be enabled.
To delete any user the program will check if the user exists first and will show a message accordingly. Users with admin roles can not be deleted.

#### *Notes: I had modified few things in my system and the project itself to be able to connect UWP project to DB and to gain file access:*
**1- SQL Server Configuration Manager:**
-
Enabled Named Pipes and TCP/IP
![image](https://user-images.githubusercontent.com/65984781/133002381-fc37bd52-1419-47d0-b83d-072bcf05df09.png)

**2- The project manifest capabilities and code:**
![image](https://user-images.githubusercontent.com/65984781/133002412-f33063f9-c514-4ada-abf8-53362c0d6ef9.png)

*Note: This app was designed based on specific requirements for the C#.Net Final exam. The information included in `readme.md` is part of the PDF file included with assignment final submission*

# References
1. All class materials
2. Asigitov, Anton. “How to Load Data from an SQLite Database into a UWP ListView.”
Anton Sigitov, 8 Sept. 2019,
https://www.sigitov.de/how-to-load-data-from-an-sqlite-database-into-a-uwp-listview/
3. Jwmsft. “NavigationView - Windows Apps.” Windows Apps | Microsoft Docs,
https://www.docs.microsoft.com/en-us/windows/apps/design/controls/navigationview
4. Kamthe, Kedar, et al. “Connected vs Disconnected Architecture in Asp.net.” Stack
Overflow, 1 Apr. 1957,
https://www.stackoverflow.com/questions/283029/connected-vs-disconnected-architecture-in-asp-net
5. Lastnameholiu. “File Access Permissions - UWP Applications.” UWP Applications |
Microsoft
Docs,https://www.docs.microsoft.com/en-us/windows/uwp/files/file-access-permissions#accessing-additional-locations
6. Mylim, et al. “UWP C# WINUI NavigationView How to Access Other Pages/Views.”
Stack Overflow, 1 Jan. 1969,
https://www.stackoverflow.com/questions/63229824/uwp-c-sharp-winui-navigationview-how-to-acces
s-other-pages-views.
7. Patrick, Tim. “Create Parameterized Queries in ADO.NET.” Visual Studio Magazine,
https://www.visualstudiomagazine.com/articles/2017/07/01/parameterized-queries.aspx
8. Praveer KumarPraveer Kumar 54266 silver badges1717 bronze badges, et al. “How to
Read a File from the Local Storage (Say ‘C:\\" ) Using UWP Background Task?” Stack
Overflow, 1 Feb.
1968, https://www.stackoverflow.com/questions/57553056/how-to-read-a-file-from-the-local-storage-say-c-using-uwp-backbround-tas
9. Pngegg. (2021, August 8). Pizza Image [Png]. https://www.pngegg.com/en/png-wbiar
10. Pngegg. (2021, August 8). Pizza Image2 [Png]. https://www.pngegg.com/en/png-bxyho
11. Pngegg. (2021, August 8). Gulab Jamun [Png]. https://www.pngegg.com/en/png-cjnpi
12. Pngegg. (2021, August 8). Coca Cola [Png]. https://www.pngegg.com/en/png-bkyop
13. Lastnameholiu. “Use a SQLite Database in a UWP App - UWP Applications.” UWP
Applications | Microsoft Docs,
https://www.docs.microsoft.com/en-us/windows/uwp/data-access/sqlite-databases
14. “Windows.Storage.Pickers.” Uno Platform,
https://www.platform.uno/docs/articles/features/windows-storage-pickers.html
