/// <summary>
/// Customer controller implementation 
/// </summary>

namespace Ado.Host.Controllers
{
    #region import namespaces

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ado.DataAccess.Entities;
    using Ado.DataAccess.Repositories.Interfaces;
    using Ado.Host.Models;
    using Ado.Host.Helper;

    #endregion

    public class CustomerController : Controller
    {
        #region properties

        private readonly ICustomerRepository customerRepository;

        #endregion

        #region constructor(s)

        public CustomerController(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        #endregion

        #region read all

        public ActionResult Index()
        {
            var allCustomers = customerRepository.GetAll();

            List<CustomerModel> customersList = new List<CustomerModel>();

            foreach (var item in allCustomers)
            {
                CustomerModel customerModel = new CustomerModel();

                customerModel.Id = item.Id;
                customerModel.Name = item.Name;
                customerModel.Address = item.Address;
                customerModel.Mobile = item.Mobile;
                customerModel.BirthDate = item.BirthDate;
                customerModel.Email = item.Email;

                customersList.Add(customerModel);
            }

            return View(customersList);
        }

        #endregion

        #region create

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            try
            {
                model.BirthDate = Convert.ToDateTime(model.BirthDate);

                if (ModelState.IsValid)
                {
                    Customer customer = Mapping.ModelToEntity(model);
                    string result = customerRepository.Add(customer);

                    ViewData["result"] = result;

                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region read

        public ActionResult Details(int id)
        {
            Customer customer = customerRepository.GetById(id);

            CustomerModel model = Mapping.EntityToModel(customer);

            return View(model);
        }

        #endregion

        #region update

        public ActionResult Edit(int id)
        {
            Customer customer = customerRepository.GetById(id);

            CustomerModel customerModel = new CustomerModel();

            customerModel.Id = customer.Id;
            customerModel.Name = customer.Name;
            customerModel.Address = customer.Address;
            customerModel.Mobile = customer.Mobile;
            customerModel.BirthDate = customer.BirthDate;
            customerModel.Email = customer.Email;

            return View(customerModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerModel model)
        {
            try
            {
                model.BirthDate = Convert.ToDateTime(model.BirthDate);

                if (ModelState.IsValid)
                {
                    Customer customer = Mapping.ModelToEntity(model);

                    string result = customerRepository.Update(customer);
                    ViewData["result"] = result;

                    ModelState.Clear();
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region delete

        public ActionResult Delete(int id)
        {
            Customer customer = customerRepository.GetById(id);

            CustomerModel model = Mapping.EntityToModel(customer);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(CustomerModel model)
        {
            try
            {
                string result = customerRepository.Delete(model.Id);

                ViewData["result"] = result;
                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
