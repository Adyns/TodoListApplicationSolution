using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoListApplication.DataModels;

namespace TodoListApplication
{
    public partial class Login : System.Web.UI.Page
    {
        ToDoListEntities _db = new ToDoListEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string ValidateUser(string giris_adi, string sifre)
        {
            Kullanicilar kullanici = null;            
            try
            {
                kullanici = _db.Kullanicilars.FirstOrDefault(p => p.giris_adi == giris_adi && p.giris_sifre == sifre);
                if (kullanici == null)return "";
                else return kullanici.departman_yoneticisi.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Hata : " + ex.Message);
                return "";
            }
        }

        public void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            string deger = ValidateUser(giris_adi.Value, sifre.Value);
            if (deger != "")
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, giris_adi.Value, DateTime.Now,
                DateTime.Now.AddMinutes(30), false, deger);
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                //if (chkPersistCookie.Checked)
                //    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "default.aspx";
                Response.Redirect(strRedirect, true);
                //FormsAuthentication.RedirectFromLoginPage(giris_adi.Value, false);
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }
}