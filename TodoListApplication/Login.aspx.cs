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

        private bool ValidateUser(string giris_adi, string sifre)
        {
            Kullanicilar kullanici = null;            
            try
            {
                kullanici = _db.Kullanicilars.FirstOrDefault(p => p.giris_adi == giris_adi && p.giris_sifre == sifre);
                if (kullanici == null)return false;
                else return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Hata : " + ex.Message);
                return false;
            }
        }

        public void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(giris_adi.Value, sifre.Value))
            {
                FormsAuthentication.RedirectFromLoginPage(giris_adi.Value, false);
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }
}