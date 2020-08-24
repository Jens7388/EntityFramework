using Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static NortwindContext context = new NortwindContext();
        static void Main()
        {
            // GetExpiredProducts();
            //GetQuebecoisSuppliers();
            //GetGermanAndFrenchSuppliers();
            //GetSuppliersWithoutHomePage();
            //GetEuropeanSuppliersWithHomePage();
            //GetEmployeesWithNamesStartingWithM();
            //GetEmployeesWithNamesEndingWithAn();
            //GetFemaleNonDoctors();
            //GetBritishSalesRepresentatives();
            //GetAllProducts();
            //GetAveragePriceOfProducts();
            //GetProductsCostingOver20();
            //GetProductsNotInStock();
            //GetProductsNotInStockAndNotOnOrder();
            //GetFrenchOwnersAndBritishSellers();
            GetAmericanCustomersWithoutFax();
            Console.ReadLine();
        }

        private static void GetExpiredProducts()
        {
            IQueryable<products> products = context.Products.Where(p => p.Discontinued);
            foreach(products product in products)
            {
                Console.WriteLine(product.ProductName, product.UnitPrice);
            }           
        }

        private static void GetQuebecoisSuppliers()
        {
            IQueryable<Suppliers> suppliers = context.Suppliers.Where(s => s.Region == "Québec");
            foreach(Suppliers supplier in suppliers)
            {
                Console.WriteLine(supplier.CompanyName);
            }
        }

        private static void GetGermanAndFrenchSuppliers()
        {
            IQueryable<Suppliers> suppliers = context.Suppliers.Where(s => s.Country == "France" || s.Country == "Germany");
            foreach(Suppliers supplier in suppliers)
            {
                Console.WriteLine(supplier.CompanyName);
            }
        }

        private static void GetSuppliersWithoutHomePage()
        {
            IQueryable<Suppliers> suppliers = context.Suppliers.Where(s => s.HomePage == null);
            foreach(Suppliers supplier in suppliers)
            {
                Console.WriteLine(supplier.CompanyName);
            }
        }

        private static void GetEuropeanSuppliersWithHomePage()
        {
            IQueryable<Suppliers> suppliers = context.Suppliers.Where(s => s.Country == "Germany"
            || s.Country == "France" || s.Country == "UK" || s.Country == "Sweden" ||
            s.Country == "Spain" || s.Country == "Italy" || s.Country == "Norway" ||
            s.Country == "Denmark" || s.Country == "Netherlands" || s.Country == "Finland"
            && s.HomePage != null);
            foreach(Suppliers supplier in suppliers)
            {
                Console.WriteLine(supplier.CompanyName);
            }
        }

        private static void GetEmployeesWithNamesStartingWithM()
        {
            IQueryable<Employees> employees = context.Employees.Where(e => e.FirstName.StartsWith("M"));
            foreach(Employees employee in employees)
            {
                Console.WriteLine(employee.FirstName, employee.LastName);
            }
        }

        private static void GetEmployeesWithNamesEndingWithAn()
        {
            IQueryable<Employees> employees = context.Employees.Where(e => e.LastName.EndsWith("an"));
            foreach(Employees employee in employees)
            {
                Console.WriteLine(employee.FirstName, employee.LastName);
            }
        }

        private static void GetFemaleNonDoctors()
        {
            IQueryable<Employees> employees = context.Employees.Where(e => e.TitleOfCourtesy == "Ms."
            || e.TitleOfCourtesy == "Mrs.");
            foreach(Employees employee in employees)
            {
                Console.WriteLine(employee.FirstName, employee.LastName);
            }
        }

        private static void GetBritishSalesRepresentatives()
        {
            IQueryable<Employees> employees = context.Employees.Where(e => e.Country == "UK" &&
            e.Title == "Sales Representative");
            foreach(Employees employee in employees)
            {
                Console.WriteLine(employee.FirstName, employee.LastName);
            }
        }

        private static void GetAllProducts()
        {
            IQueryable<products> products = context.Products;
            foreach(products product in products)
            {
                Console.WriteLine(product.ProductName, product.UnitPrice);
            }
        }

        private static void GetAveragePriceOfProducts()
        {
            decimal? averagePrice = context.Products.Sum(p => p.UnitPrice) / context.Products.Count<products>();
            Console.WriteLine(averagePrice);
        }

        private static void GetProductsCostingOver20()
        {
            IQueryable<products> products = context.Products.Where(p => p.UnitPrice > 20);
            IQueryable<products> orderedProducts =  products.OrderByDescending(p => p.UnitPrice);
            foreach(products product in orderedProducts)
            {
                Console.WriteLine($"{ product.ProductName} {product.UnitPrice}");
            }                
        }

        private static void GetProductsNotInStock()
        {
            IQueryable<products> products = context.Products.Where(p => p.UnitsInStock == 0);
            IQueryable<products> orderedProducts = products.OrderBy(p => p.ProductName);
            foreach(products product in orderedProducts)
            {
                Console.WriteLine($"{ product.ProductName} {product.UnitPrice}");
            }
        }

        private static void GetProductsNotInStockAndNotOnOrder()
        {
            IQueryable<products> products = context.Products.Where(p => p.UnitsInStock == 0
            && p.UnitsOnOrder == 0 && !p.Discontinued);
            IQueryable<products> orderedProducts = products.OrderByDescending(p => p.ProductName);
            foreach(products product in orderedProducts)
            {
                Console.WriteLine($"{ product.ProductName} {product.UnitPrice}");
            }
        }

        private static void GetFrenchOwnersAndBritishSellers()
        {
            IQueryable<Customers> customers = context.Customers.Where(c => c.Country == "France"
            && c.ContactTitle == "Owner" || c.Country == "UK" && c.ContactTitle.StartsWith("Sales"));
            IQueryable<Customers> orderedCustomers = customers.OrderBy(c => c.Country + c.ContactName);
            foreach(Customers customer in orderedCustomers)
            {
                Console.WriteLine($"{customer.ContactName} {customer.Country}");
            }
        }

        private static void GetAmericanCustomersWithoutFax()
        {
            IQueryable<Customers> customers = context.Customers.Where(c => c.Country == "USA"
            || c.Country == "Mexico" || c.Country == "Brazil" || c.Country == "Venezuela" ||
            c.Country == "Argentina" || c.Country == "Canada" && c.Fax == null);
            IQueryable<Customers> orderedCustomers = customers.OrderBy(c => c.ContactName);
            foreach(Customers customer in orderedCustomers)
            {
                Console.WriteLine($"{customer.ContactName} {customer.Country}");
            }
        }
    }
}