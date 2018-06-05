using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab24b_coffeeshop_cart.Models;

namespace lab24b_coffeeshop_cart.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities db = new CoffeeShopDBEntities();
            List<Item> items = db.Items.ToList();
            ViewBag.Items = items;
            return View();
        }

        public ActionResult ItemList()
        {
            CoffeeShopDBEntities db = new CoffeeShopDBEntities();
            List<Item> items = db.Items.ToList();
            ViewBag.Items = items;


            return View();
        }
        public ActionResult About()
        {
            HttpCookie cookie = Request.Cookies["Counter"];
            //do they ahve a the cookie called counter?
            if (cookie == null)
            {
                //if no, make a cookie :)
                cookie = new HttpCookie("Counter");
                cookie.Value = "0";
            }

            // increment -- increase the visit count
            bool success = int.TryParse(cookie.Value, out int visits);
            if (success)
            {
                visits++;
            }
            else
            {
                visits = 1;
            }


            //storing the info in the cookie
            cookie.Value = visits.ToString();
            cookie.Expires = DateTime.Now.AddDays(14);

            //return the cookie to the user in the HTTP response
            Response.Cookies.Add(cookie);

            ViewBag.Message = "Learn about us!";

            return View();
        }

        public ActionResult Contact()
        {
            if (Session["Counter"] == null)
            {
                Session.Add("Counter", 0);
            }
            int visits = (int)Session["Counter"];
            visits++;

            Session["Counter"] = visits;

            ViewBag.Message = "We'd love to hear from you!";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your Registration page.";
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            ViewBag.Items = ORM.Items.ToList();

            List<Coffee> coffeList = new List<Coffee>();
            Coffee c1 = new Coffee("Bushy Tail", 10, "Nicaragua");
            Coffee c2 = new Coffee("Tarrazu", 16, "Costa Rica");
            Coffee c3 = new Coffee("Don Pablo", 10, "Mexico");
            coffeList.Add(c1);
            coffeList.Add(c2);
            coffeList.Add(c3);
            ViewBag.CoffeeList = coffeList;

            return View();
        }

        public ActionResult Confirmation(User data)
        {
            //build our ORM Object Relational Mapping
            CoffeeShopDBEntities ORM = new CoffeeShopDBEntities();
            if (ModelState.IsValid)
            {
                //if the model is valid then we add to our DB
                ORM.Users.Add(data);
                //we have to save our changes or they won't stay in our DB
                ORM.SaveChanges();
                ViewBag.message = $"{data.FirstName} has been added";
            }
            else
            {
                ViewBag.message = "Item is not valid, cannot add to DB.";
            }

            return View();
        }

        public ActionResult Menu()
        {

            CoffeeShopDBEntities db = new CoffeeShopDBEntities();
            List<Item> items = db.Items.ToList();
            ViewBag.Items = items;

            return View();
        }

        public ActionResult Add(int id)
        {
            CoffeeShopDBEntities db = new CoffeeShopDBEntities();

            //check if the Cart object already exists
            if (Session["Cart"] == null)
            {
                //if it doesn't, make a new list of items
                List<Item> cart = new List<Item>();
                //add this item to it
                cart.Add((from b in db.Items
                          where b.ID == id
                          select b).Single());
                //add the list to the session
                Session.Add("Cart", cart);
            }
            else
            {
                //if it does exist, get the list
                List<Item> cart = (List<Item>)(Session["Cart"]);
                //add this item to it
                cart.Add((from b in db.Items
                          where b.ID == id
                          select b).Single());
            }
            return View();
        }

        public ActionResult ItemListSorted(string column)
        {
            CoffeeShopDBEntities db = new CoffeeShopDBEntities();
            //LINQ Query
            if (column == "Name")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Name
                                 select i).ToList();
            }
            else if (column == "Price")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Price
                                 select i).ToList();
            }
            else if (column == "Quantity")
            {
                ViewBag.Items = (from i in db.Items
                                 orderby i.Quantity
                                 select i).ToList();
            }

            return View("Menu");
        }

        public ActionResult Cart()
        {

            //declare total variables
            double subtotal = 0;
            double tax = 0;
            double grandTotal = 0;

            //declare db model
            CoffeeShopDBEntities db = new CoffeeShopDBEntities();

            //check if the Cart object already exists
            if (Session["Cart"] == null)
            {
                //if it doesn't, make a new list of items
                List<Item> cart = new List<Item>();
                //add the list to the session
                Session.Add("Cart", cart);
            }

            else
            {

                //if it does exist, get the list
                List<Item> cart = (List<Item>)(Session["Cart"]);

                //get the subtotal
                subtotal = cart.Sum(item => (double)item.Price);
            }
            // calculate totals
            tax = subtotal * .06;
            grandTotal = subtotal + tax;

            //viewbags for totals
            ViewBag.Subtotal = $"Subtotal: {subtotal.ToString("C2")}";
            ViewBag.Tax = $"Tax: {tax.ToString("C2")}";
            ViewBag.grandTotal = $"Grand Total: {grandTotal.ToString("C2")}";

            //return view
            return View();
        }

        public ActionResult Clear()
        {
            CoffeeShopDBEntities db = new CoffeeShopDBEntities();
            List<Item> cart = (List<Item>)(Session["Cart"]);
            cart.Clear();

            return View("Cart");
        }
    }
}
