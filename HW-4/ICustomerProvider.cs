namespace HW_4;

public interface ICustomersProvider
{
    IEnumerable<Customer> GetCustomers();
}