insert into employee.dbo.JobPosition values ('Fullstack Developer'),('Backend Developer'),('Frontend Developer'),('Boss');

insert into employee.dbo.Employee values ('Marko', 'Markkovic', 10, NULL),('Nikola', 'Nikolic', 11, 1),('Pajo', 'Pajkanovic', 12, 1);

insert into employee.dbo.EmployeeJobPosition values (1,4), (2,1), (2,2), (2,3), (3,1);

insert into employee.dbo.EmployeePosition values (1,4,'2022-01-01','2024-01-01'), (2,1,'2022-01-01','2024-01-01'), (3,1,'2022-01-01','2024-01-01');

insert into employee.dbo.Salary values (1,3500.0,'2022-01-01','2023-01-01'), (2,3000.0,'2022-01-01','2024-01-01'), (3,2000.0,'2022-01-01','2024-01-01'),(1,4000.0,'2023-01-01','2024-01-01');

insert into employee.dbo.Bonus values (1,200.0,'2023-02-01'), (2,100.0,'2023-03-01'), (3,10.0,'2023-03-01'),(1,100.0,'2023-03-01');

insert into employee.dbo.Deducation values (1,50.0,'2023-02-01'), (2,5.0,'2023-03-01'), (3,2.0,'2023-03-01'),(1,100.0,'2023-03-01');
