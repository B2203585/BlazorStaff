using BlazorStaff.Data;
using BlazorStaff.Repositories;
using Microsoft.AspNetCore.Components;

namespace BlazorStaff.Components;

public class StaffListBase : ComponentBase
{
    [Inject]
    public IStaffRepository staffRepository { get; set; }

    public IEnumerable<Employee> staffs { get; set;}

    protected override async Task OnInitializedAsync()
    {
        staffs = await staffRepository.GetAllStaffs();
    }
}