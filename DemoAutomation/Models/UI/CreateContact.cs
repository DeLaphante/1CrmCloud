using CynkyUtilities;
using System.Collections.Generic;

namespace DemoAutomation.Models.UI
{
    public class CreateContact
    {
        public string Title { get; set; } = "Dr.";
        public string FirstName { get; set; } = StringGenerator.GetRandomString();
        public string LastName { get; set; } = StringGenerator.GetRandomString();
        public string Role { get; set; } = "CEO";
        public List<string> Category { get; set; } = new List<string>() { "Customers", "Suppliers" };

    }
}
