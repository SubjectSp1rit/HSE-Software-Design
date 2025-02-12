namespace HW_4;

public class CustomerStorage : ICustomersProvider
{
    private readonly List<Customer> customers = new List<Customer>();

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public IEnumerable<Customer> GetCustomers()
    {
        return customers;
    }

    public void PrintCustomers()
    {
        Console.WriteLine("Список покупателей:");
        foreach (var customer in customers)
        {
            Console.WriteLine(customer);
        }
    }
}