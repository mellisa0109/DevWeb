using System.Web;
using System.Web.Optimization;

namespace RecoWeb.WebUI
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS style (bootstrap/inspinia)
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/reco_style.css"
                      ));

            // Vendor scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.1.min.js"));

            // Devexpress Extreme
            bundles.Add(new ScriptBundle("~/plugins/Dx").Include(
                      "~/Scripts/plugins/Dx/dx.all.js"));

            // SheetJS
            bundles.Add(new ScriptBundle("~/plugins/sheetJs").Include(
                    "~/Scripts/plugins/sheetJs/shim.min.js",
                      "~/Scripts/plugins/sheetJs/xlsx.full.min.js"));

            // FileSaver
            bundles.Add(new ScriptBundle("~/plugins/fileSaver").Include(
                    "~/Scripts/FileSaver.js"));
            
            bundles.Add(new StyleBundle("~/Content/plugins/Dx/DxCss").Include(
                                    "~/Content/plugins/Dx/dx.common.css",
                                    "~/Content/plugins/Dx/dx.light.css",
                                    "~/Content/plugins/Dx/dx.spa.css"));

            // ChartJS chart
            bundles.Add(new ScriptBundle("~/plugins/chartJs").Include(
                      "~/Scripts/plugins/chartjs/Chart.min.js"));
            
            // Lightbox gallery css styles
            bundles.Add(new StyleBundle("~/Content/plugins/blueimp/css").Include(
                      "~/Content/plugins/blueimp/css/blueimp-gallery.min.css"));

            // Lightbox gallery
            bundles.Add(new ScriptBundle("~/plugins/lightboxGallery").Include(
                      "~/Scripts/plugins/blueimp/jquery.blueimp-gallery.min.js"));

            // Morriss chart css styles
            bundles.Add(new StyleBundle("~/plugins/morrisStyles").Include(
                      "~/Content/plugins/morris/morris-0.4.3.min.css"));

            // Morriss chart
            bundles.Add(new ScriptBundle("~/plugins/morris").Include(
                      "~/Scripts/plugins/morris/raphael-2.1.0.min.js",
                      "~/Scripts/plugins/morris/morris.js"));
            
            // dom-to-image
            bundles.Add(new ScriptBundle("~/plugins/dom-to-image").Include(
                    "~/Scripts/dom-to-image.js"));


            // html2canvas
            bundles.Add(new ScriptBundle("~/plugins/html2canvas").Include(
                    "~/Scripts/html2canvas.js",
                      "~/Scripts/Canvas2Image.js"));

            // es6-promise
            bundles.Add(new ScriptBundle("~/plugins/es6-promise").Include(
                    "~/Scripts/es6-promise.js"));
            // Sweet alert Styless
            bundles.Add(new StyleBundle("~/plugins/sweetAlertStyles").Include(
                      "~/Content/plugins/sweetalert/sweetalert.css"));

            // Sweet alert
            bundles.Add(new ScriptBundle("~/plugins/sweetAlert").Include(
                      "~/Scripts/plugins/sweetalert/sweetalert.min.js"));
            // jqGrid styles
            bundles.Add(new StyleBundle("~/Content/plugins/jqGrid/jqGridStyles").Include(
                      "~/Content/plugins/jqGrid/ui.jqgrid.css"));

            // jqGrid 
            bundles.Add(new ScriptBundle("~/plugins/jqGrid").Include(
                      "~/Scripts/plugins/jqGrid/i18n/grid.locale-en.js",
                      "~/Scripts/plugins/jqGrid/jquery.jqGrid.min.js"));
        }
    }
}
