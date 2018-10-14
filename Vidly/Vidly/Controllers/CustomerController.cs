using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            this._context.Dispose();
        }

        private ViewModel.CustomersViewModel GetCustomers()
        {
            var customerList = _context.Customers.Include(c => c.MembershipType).ToList();
            return new ViewModel.CustomersViewModel()
            {
                Customers = customerList
            };
        }
       

        [Route("customer/detail/{id:regex(\\d{2})}")]
        public ActionResult CustomerDetail(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType ).FirstOrDefault(i => i.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        public ActionResult New()
        {
            var newCustomerViewModel = new NewCustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            };
            return View("FormCustomer", newCustomerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer(Customer customer)
        {
            if (!ModelState.IsValid){
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = this._context.MembershipTypes.ToList()
                };
                return View("FormCustomer", viewModel);
            }
            if (customer.Id == 0)
            {
                this._context.Customers.Add(customer);
            }
            else {
                var customerInDB = this._context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.IsSuscribeToNewsLetter = customer.IsSuscribeToNewsLetter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
            }
            
            this._context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id) {
            var customer = this._context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var newCustomerViewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = this._context.MembershipTypes.ToList()
            };
            return View("FormCustomer", newCustomerViewModel);
        }
    }
}