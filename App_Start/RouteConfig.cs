using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyRenLuyen
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");// IgnoreRoute sẽ loại bỏ việc xử lý các yêu cầu đối với các tệp .axd
            // MapRoute đăng ký một định tuyến tùy chỉnh với tên "XemDiem" cho action "XemDiem" của controller "SinhVien"
            routes.MapRoute(
               name: "XemDiem",
               url: "SinhVien/XemDiem/{idHocKy}/{idSinhVien}",
               defaults: new { controller = "SinhVien", action = "XemDiem", id = UrlParameter.Optional }
           );
            // MapRoute đăng ký một định tuyến mặc định với pattern chuẩn cho controller, action và id (có thể không có)
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
