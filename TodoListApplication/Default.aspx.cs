using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoListApplication.DataModels;

namespace TodoListApplication
{
    public partial class _Default : Page
    {
        ToDoListEntities _db = new ToDoListEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProjeler();
                int id = 0;
                int durum_id = 1;
                if (!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    id = Convert.ToInt32(Request.QueryString["id"]);
                    durum_id = Convert.ToInt32(Request.QueryString["durum"]);
                    GetGorevler(id, durum_id);
                    GetKullanicis();
                    GetEtikets();
                    GetDepartmans();
                    GetDurums();
                    GetDurumMenu();
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                }
            }
        }

        private void GetProjeler()
        {
            StringBuilder sb = new StringBuilder();
            var projelers = _db.Projelers.ToList();
            foreach (var item in projelers)
            {
                sb.Append("<li class='nav-item'>");
                sb.Append("<a class='d-flex align-items-center' href='Default.aspx?id=" + item.id + "&durum=1'>");
                sb.Append("<span class='menu-title text-truncate'>" + item.adi + "</span></a>");
                sb.Append("</li>");
            }
            PlaceHolder2.Controls.Add(new Literal { Text = sb.ToString() });
        }
        private void GetDurumMenu()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            StringBuilder sb = new StringBuilder();
            var durumlars = _db.Durumlars.ToList();
            foreach (var item in durumlars)
            {
                string link = "Default.aspx?id=" + id + "&durum=" + item.id;
                sb.Append("<a href='" + link + "' class='list-group-item list-group-item-action'><span class='align-middle'>" + item.adi + "</span></a>");
            }
            PlaceHolder3.Controls.Add(new Literal { Text = sb.ToString() });
        }
        private void GetGorevler(int id, int durum_id)
        {
            StringBuilder sb = new StringBuilder();
            var gorevs = _db.Gorevlers.Where(p => p.proje_id == id && p.durum_id == durum_id).ToList();
            foreach (var item in gorevs)
            {
                sb.Append("<li class='todo-item'>");
                sb.Append("<div class='todo-title-wrapper'>");
                sb.Append("<div class='todo-title-area'>");
                sb.Append("<div class='title-wrapper'>");
                sb.Append("<span class='todo-title'>" + item.adi + "</span>");
                sb.Append(" ||| <small class='text-muted me-1'>" + item.aciklama + "</small> </div>");
                sb.Append(" </div>");
                sb.Append("<div class='todo-item-action'>");
                sb.Append("<div class='badge-wrapper me-1'>");
                sb.Append("<span class='badge rounded-pill badge-light-danger'>" + item.Etiketler.adi + "</span>");
                sb.Append("<span class='badge rounded-pill badge-light-primary'>" + item.Departmanlar.adi + "</span>");
                sb.Append("</div>");
                sb.Append(" <small class='text-nowrap text-muted me-1'>" + item.bitirilmesi_gereken_zaman + "</small>");
                sb.Append(" <button type='button' class='btn btn-primary w-100 btn-sm' data-bs-toggle='modal' data-bs-target='#detail-task-modal' onclick='EditRecord(" + item.id + ")'>İşlem</button>");
                sb.Append(" </div>");
                sb.Append("</div>");
                sb.Append("</li>");
            }
            PlaceHolder1.Controls.Add(new Literal { Text = sb.ToString() });
        }

        public string GetIslem()
        {
            return "Hello";
        }
        public void GetKullanicis()
        {
            string sb = string.Empty;
            var kullanicilar = _db.Kullanicilars.Select(p => new { p.id, p.adi_soyadi }).ToList();
            DropDownList1.DataSource = kullanicilar;
            DropDownList1.DataBind();
        }
        public void GetEtikets()
        {
            string sb = string.Empty;
            var etiketler = _db.Etiketlers.Select(p => new { p.id, p.adi }).ToList();
            DropDownList2.DataSource = etiketler;
            DropDownList2.DataBind();
        }
        public void GetDepartmans()
        {
            string sb = string.Empty;
            var departmanlar = _db.Departmanlars.Select(p => new { p.id, p.adi }).ToList();
            DropDownList3.DataSource = departmanlar;
            DropDownList3.DataBind();
        }
        public void GetDurums()
        {
            string sb = string.Empty;
            var durumlar = _db.Durumlars.Select(p => new { p.id, p.adi }).ToList();
            DropDownList4.DataSource = durumlar;
            DropDownList4.DataBind();
        }

        protected void Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Gorevler gorev = new Gorevler();
                gorev.aciklama = gorev_aciklama.Text;
                gorev.adi = gorev_baslik.Text;
                gorev.departman_id = Convert.ToInt32(HttpContext.Current.Request.Form[DropDownList3.UniqueID]);
                gorev.durum_id = 1;
                gorev.etiket_id = Convert.ToInt32(HttpContext.Current.Request.Form[DropDownList2.UniqueID]);
                gorev.kullanici_id = Convert.ToInt32(HttpContext.Current.Request.Form[DropDownList1.UniqueID]);
                gorev.olusturulma_zamani = DateTime.Now;
                gorev.olusturan_kullanici = "Mehmet AYDEMİR";
                gorev.silindi = false;
                gorev.aktif = CheckBox1.Checked;
                gorev.bitirilmesi_gereken_zaman = Convert.ToDateTime(TextBox1.Text);
                gorev.proje_id = id;
                _db.Gorevlers.Add(gorev);
                _db.SaveChangesAsync();
                Response.Redirect("Default.aspx?id=" + id + "&durum=1", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Proje_Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                Projeler proje = new Projeler();
                proje.aciklama = proje_aciklama.Text;
                proje.adi = proje_adi.Text;
                proje.olusturulma_zamani = DateTime.Now;
                proje.olusturan_kullanici = "Mehmet AYDEMİR";
                proje.silindi = false;
                proje.aktif = CheckBox2.Checked;
                _db.Projelers.Add(proje);
                _db.SaveChanges();
                Response.Redirect("Default.aspx?id=" + proje.id + "&durum=1", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int ids = Convert.ToInt32(Request.QueryString["id"]);
                int gorevids = Convert.ToInt32(gorev_ids.Value);
                int durum_id = Convert.ToInt32(Request.QueryString["durum"]);

                var gorev = _db.Gorevlers.FirstOrDefault(p => p.id == gorevids && p.proje_id == ids);
                gorev.durum_id = Convert.ToInt32(HttpContext.Current.Request.Form[DropDownList4.UniqueID]);
                _db.SaveChanges();
                Response.Redirect("Default.aspx?id=" + gorev.proje_id + "&durum=" + durum_id, false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cmdLogout_ServerClick(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);
        }
    }
}