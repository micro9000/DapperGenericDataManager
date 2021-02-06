using DapperGenericDataManager;
using MVCDotNetFrameworkSample.Models;

namespace MVCDotNetFrameworkSample.Services
{
    public interface IStudentsData : IDataManagerCRUD<Student>
    {
        Student GetByStdNum(string stdNum);
    }
}