using congngheweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace congngheweb.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        //public String updatepass()
        //{
        //    string password = "admin";
        //    string hashedPassword = "AIePb7m0wCLxjEM0vO5Uydj5bem0/Z26thYIW4HNZF4vu/fE/ilbwmV4rXJdL22YSw==";
        //    // Kiểm tra mật khẩu đã mã hóa

        //    return Crypto.VerifyHashedPassword(hashedPassword, password);
        //}
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult auth(FormCollection form)
        {
            string email = form["email"];
            string password = form["pass"];

            
            DB db = new DB();
            admin admin = db.admins.FirstOrDefault(m => m.email == email);

            if (admin != null)
            {
                if(Crypto.VerifyHashedPassword(admin.password, password))
                {
                    Session["email"] = admin.email;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    TempData["Error"] = "Password incorrect";
                    return RedirectToAction("Login");
                }
                
            }
            else
            {
                TempData["Error"] = "Email incorrect";
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            // Xóa session và đăng xuất người dùng
            Session.Clear();
            Session.Abandon();

            // Chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login");
        }

        public ActionResult Dashboard()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Rooms()
        {
            DB db = new DB();
            List<room> rooms = db.rooms.ToList();
            return View(rooms);
        }

        
        public ActionResult Addroom()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login");
            }
            DB db = new DB();
            List<room_status> status = db.room_status.ToList();
            return View(status);
        }
        public ActionResult Editroom(int id)
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login");
            }
            DB db = new DB();
            List<room_status> status = db.room_status.ToList();
            room room = db.rooms.Where(r => r.id == id).FirstOrDefault();
            ViewBag.room = room;
            return View(status);
        }

        [HttpPost]
        public ActionResult _Editroom(FormCollection form)
        {
            int id = Int32.Parse(form["id"]);
            var number = form["number"];
            var status = Int32.Parse(form["status"]);
            var price = form["price"];
            DB db = new DB();
            room room = db.rooms.Where(r => r.id == id).FirstOrDefault();
            room.room_number = number;
            room.price = Int32.Parse(price);
            room.status = status;
            db.SaveChanges();
            return RedirectToAction("Rooms");
        }

        [HttpPost]
        public ActionResult _Addroom(FormCollection form)
        {
            var number = form["number"];
            var status = form["status"];
            var price = form["price"];
            DB db = new DB();
            room room = new room
            {
                room_number = number,
                price = Int32.Parse(price),
                status = Int32.Parse(status),

            };
            db.rooms.Add(room);
            db.SaveChanges();
            return RedirectToAction("Rooms");
        }

        public ActionResult Delroom(int id)
        {
            DB db = new DB();
            room room = db.rooms.Where(r => r.id == id).FirstOrDefault();
            db.rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("Rooms");
        }


        public ActionResult BookingHistory()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login");
            }

            DB db = new DB();
            List<booking> bk = db.bookings.ToList();
            return View(bk);
        }

        public ActionResult Confirm(int id)
        {
            DB db = new DB();
            var bk = db.bookings.FirstOrDefault(m => m.id == id);
            if(bk != null)
            {

                bk.status = 1;
                db.SaveChanges();
            }
            return RedirectToAction("BookingHistory");
        }

        public ActionResult DeleteRequest(int id)
        {
            DB db = new DB();
            var bk = db.bookings.FirstOrDefault(m => m.id == id);
            if (bk != null)
            {

                db.bookings.Remove(bk);
                db.SaveChanges();
            }
            return RedirectToAction("BookingHistory");
        }

        public ActionResult BookingDetail(int id)
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login");
            }
            DB db = new DB();
            var bk = db.bookings.FirstOrDefault(m => m.id == id);
            return View(bk);
        }

        

        public ActionResult Comment()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login");
            }
            DB db = new DB();
            List<comment> cm = db.comments.OrderBy(c => c.created_at).ToList();
            cm.Reverse();
            return View(cm);
        }

    }
}