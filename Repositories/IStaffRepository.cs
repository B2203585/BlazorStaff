namespace BlazorStaff.Repositories;
using BlazorStaff.Data;

public interface IStaffRepository{
    Task <IEnumerable<Employee>> GetAllStaffs();
    Task <Employee> GetStaff(int id);
}