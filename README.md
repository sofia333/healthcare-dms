# Healthcare Data Management System Project
Healthcare platform to manage patients and visualize their heart rate, number of steps, blood pressure (daily average value and weekly trend).
This data has been sent every day by a device equipped with sensors, in the period of time between 2023-1-9 and 2023-1-9 to the database (PatientData table). 

The user after registration and log-in can:
- visualize the patient's list
- create/update/delete patients
- visualize the patient's details by clicking on "Details" in the patient's list page
  
# Details
A dashboard will appear with:
- patient's personal data
- heart rate (daily average value above and weekly trend below)
- number of steps (daily average value above and weekly trend below)
- blood pressure, systolic/dyastolic (daily average value above and weekly trend below)
- select date: option to select the date in which it is possible to visualize the respective health data (average value of the date and trend of the week starting  days earlier).
The weekly trends are shown in charts that update dynamically when the selection date changes

# Database
- SQL server
- Update-Database before start. The DB has been seeded with (SeedData):
  - 4 patients
  - Patient data 2023-1-9 and 2023-1-9 (a record per day) 
# xUNIT
Unit test backend, only one to test Patients/GetNewData
