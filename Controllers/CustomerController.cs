using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;
using System.Data.Entity;
using Movie.ViewModel;

namespace Movie.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                Customers = new Customers(),
                MembershipTypes = membershipTypes

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customers)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customers = customers,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customers.Id == 0)
            _context.Customers.Add(customers);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customers.Id);

                customerInDb.Name = customers.Name;
                customerInDb.BirthDate = customers.BirthDate;
                customerInDb.MembershipTypeId = customers.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customers.IsSubscribedToNewsletter;
            
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);

        }
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);

        }
        [Route("{controller}/{action}/{Id}")]
        public ActionResult Details(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        

 
    }
}