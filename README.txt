Guaranteed Rate Coding Sample Application
This Application has 4 Projects: 1. GuarRateWebApplication (console application) - this is the console app that allows the user to import the 3 data files (csv, space delimited, or delimited by |) 2. GuarnRateHost (console application) - this is the webserver that hosts the databases and provides access to the database 3. GuarnUI (Web application) - This is an HTML web application that contains javascript and JQuery to access the webserver "GuarRateHost" 4. GuranTest - This is a Unit Test Class to test the Weberver application
Prerequesites: ** NOTE: you must install the 3 sample databases into the the c: drive These Sample databases are as follows: dataInput1.txt, dataInput2.txt, dataInput3.txt
To Install: open up the SelfHost solution in Visual Studio, and build copy the 3 datafiles "dataInput1.txt, dataInput2.txt, dataInput3.txt" to your C:drive
To run the console Application to Import the 3 databases: you can do this 2 ways ... 1) in Visual Studio - Set the StartUP project to "GuarRateWebApplication", add the input files by right-click, properties -> Debug -> Command Line Arguments type in->(dataInput1.txt, dataInput2.txt, dataInput3.txt); Press F5 to run
2) To run on a command like, c:/SelfHost/GuarRateWebApplication/bin/debug/guarRateWebApplication
To run the Web Server: (Start the Webserver)
you can do this 2 ways ... 1) in Visual Studio - Set the StartUP project to "GuarnRateHost" Press F5 to run
2) To run on a command like, c:/SelfHost/GuarnRateHost/bin/debug/GuarnRateHost
To Check the results:
in the Browser:
to Retreive data by Name http://localhost:8080/api/Persons/Name
to Retieve data by Gender Http://localhost:8080/api/Persons/Gender
to Retrieve data by Birth Date http://locathost:8080/api/Persons/BirthDate
to Post Records: you have to run GuranUI which provides all of the Sort methods and a nice interface http://localhost:54993/GuanUI.html#

