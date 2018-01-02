SELECT max(Salary) as SecondHighestSalary 
FROM Employee
WHERE Salary < (SELECT max(Salary) FROM Employee);



SELECT MAX(Salary)
 FROM (SELECT E1.Salary
 FROM Employee as E1 JOIN Employee as E2
 ON E1.Salary < E2.Salary
 GROUP BY E1.Id HAVING COUNT(E2.Id) = 1
 )  AS SecondHighestSalary
 ORDER BY Salary DESC LIMIT 1;