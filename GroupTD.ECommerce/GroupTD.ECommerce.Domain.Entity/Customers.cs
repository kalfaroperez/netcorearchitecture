using System;

namespace GroupTD.ECommerce.Domain.Entity
{
    public class Customers
    {
        public string? CustomerID { set; get; }
        public string? CompanyName { set; get; }
        public string? ContactName { set; get; }
        public string? ContactTitle { set; get; }
        public string? Address { set; get; }
        public string? City { set; get; }
        public string? Region { set; get; }
        public string? PostalCode { get ; set; }
        public string? Country { set; get; }
        public string? Phone { set; get; }
        public string? Fax { set; get; }
    }
}
