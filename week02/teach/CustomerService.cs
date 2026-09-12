/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(0);
        Console.WriteLine(cs1);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: 
        // Expected Result: 
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(10);
        cs2.AddNewCustomer("Sam", "123", "Password reset");
        Console.WriteLine(cs2);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: Fill queue to max size (2), then try adding one more
        // Expected Result: Error message; queue size stays at 2
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(2);
        cs3.AddNewCustomer("A", "1", "Issue A");
        cs3.AddNewCustomer("B", "2", "Issue B");
        cs3.AddNewCustomer("C", "3", "Issue C"); // should be rejected
        Console.WriteLine(cs3);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Serve a customer from a non-empty queue
        // Expected Result: Displays and removes the first customer added
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(10);
        cs4.AddNewCustomer("First", "1", "Issue 1");
        cs4.AddNewCustomer("Second", "2", "Issue 2");
        cs4.ServeCustomer(); // should display "First"
        Console.WriteLine(cs4);
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serve a customer from an empty queue
        // Expected Result: Error message, no exception
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(10);
        cs5.ServeCustomer();
        // Defect(s) Found: 
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer(string name, string accountId, string problem) {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
    
        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in the queue to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}