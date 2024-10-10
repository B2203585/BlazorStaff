namespace BlazorStaff.Repositories;
using BlazorStaff.Data;

public class StaffRepository : IStaffRepository{
    public DatabaseContext staffsContext;

    public StaffRepository(DatabaseContext staffsContext){
        this.staffsContext = staffsContext;
    }

    public async Task<Employee> GetStaff(int id){
        return (from staff in staffsContext.Employees
                where staff.EmployeeId == id
                select staff).First();
    }

    public async Task<IEnumerable<Employee>> GetAllStaffs(){
        return staffsContext.Employees;
    }
}