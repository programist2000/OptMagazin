using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OptMagazin.Models;
using System.Web.Security;
using OptMagazin.Providers;

namespace OptMagazin.Controllers
{

        [AllowAnonymous]
        public class AccountController : Controller
        {
            public ActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Login(LogOnModel model, string returnUrl)
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(model.UserName, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, false);
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный пароль или логин");
                    }
                }
                return View(model);
            }
            public ActionResult LogOff()
            {
                FormsAuthentication.SignOut();

                return RedirectToAction("Login", "Account");
            }

            public ActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    MembershipUser membershipUser = ((CustomMembershipProvider)Membership.Provider).CreateUser(model.Email, model.Password);

                    if (membershipUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Ошибка при регистрации");
                    }
                }
                return View(model);
            }

        }
    }
