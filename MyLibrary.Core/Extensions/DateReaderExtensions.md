# DateReader Extensions

```csharp
SqlCommand command = new SqlCommand("SELECT EmployeeID, EmployeeIDGuid, FirstName, LastName, Birthday, Salary, DAYS(TODAY() - StartDate) as DaysEmployed, IsManager FROM Employees;", connection);
connection.Open()
var dataReader = command.ExecuteReader();
```

---
#### Get&lt;T&gt;(string) : T
Gets the value of a named column from a DataReader, returning the default(T) if null
```csharp
var firstName = dataReader.Get("FirstName");
```
**Output:**  
_`Mark`_

---
#### Get&lt;T&gt;(string, T) : T
Gets the value of a column from a DataReader, returning a specified default value if null, then converts it to T
```csharp
string EmployeeId = dataReader.Get<string>("EmployeeID", "Non-Member");
```
**Output:**  
_`"2345"`_

---
#### GetInt32(string, Int32) : int
Gets the value of a named column from a DataReader, returning a default value if null
```csharp
var EmployeeId = dataReader.GetInt32("EmployeeID");
```
**Output:**  
_`2345`_

---
#### GetString(string, T) : string
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var firstName = dataReader.GetString("FirstName");
```
**Output:**  
_`Mark`_

---
#### GetBoolean(string, T) : bool
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var isManager = dataReader.GetBoolean("IsManager");
```
**Output:**  
_`false`_

---
#### GetDateTime(string, T) : DateTime
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var birthday = dataReader.GetDateTime("Birthday");
```
**Output:**  
_`1991-03-02T00:00:00Z`_

---
#### GetDecimal(string, T) : decimal
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var salary = dataReader.GetDecimal("Salary");
```
**Output:**  
_`65,960.00`_

---
#### GetDouble(string, T) : double
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var salary = dataReader.GetDouble("Salary");
```
**Output:**  
_`65,960.0`_

---
#### GetFloat(string, T) : float
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var salary = dataReader.GetFloat("Salary");
```
**Output:**  
_`65,960.0`_

---
#### GetGuid(string, T) : Guid
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var employeeIdAsGuid = dataReader.GetDouble("EmployeeIDGuid");
```
**Output:**  
_`1A3B944E-3632-467B-A53A-206305310BAE`_

---
#### GetInt16(string, T) : short
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var daysEmployed = dataReader.GetDouble("DaysEmployed");
```
**Output:**  
_`220`_

---
#### GetInt64(string, T) : long
Gets the value of a column from a DataReader, returning a default value if null
```csharp
var daysEmployed = dataReader.GetInt64("DaysEmployed") * 14400;
```
**Output:**  
_`525990`_

---
#### AsEnumerable() : IEnumerable&lt;IDataRecord&gt;
Allows for LINQ operations on a DataReader
```csharp
var results = dr.AsEnumerable()
      .Select(record => new Employee {
            Name = (string)record["FirstName"],
            Id = (int)record["EmployeeID"],
            Salary = (decimal)record["Salary"]
        })
      .GroupBy(ee => ee.Id);
```
**Output:**  
_`(IEnumerable<IDataRecord>)`_

---