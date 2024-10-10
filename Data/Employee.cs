using System;
using System.Collections.Generic;

namespace BlazorStaff.Data;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? StartingDate { get; set; }

    public string? GenderId { get; set; }

    public string? DepartmentId { get; set; }
}
