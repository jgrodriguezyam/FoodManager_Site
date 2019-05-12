using System;
using System.Web.Optimization;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;

namespace FoodManager.Infrastructure.Bundles
{
    public static class StyleBundleModule 
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Themes

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, "Shared", "Master"))
                .Include("~/Content/Components/Bootstrap/Css/Bootstrap-fonts.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Components/Pace/Css/Pace.min.css",
                    "~/Content/Components/Bootstrap/Css/Bootstrap.min.css",
                    "~/Content/Components/Messenger/Css/Messenger.min.css",
                    "~/Content/Components/JQuery/Css/JQuery-ui.css",
                    "~/Content/Css/System.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, "Shared", "Login"))
                .Include("~/Content/Components/Bootstrap/Css/Bootstrap-fonts.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/Components/Pace/Css/Pace.min.css",
                    "~/Content/Components/Bootstrap/Css/Bootstrap.min.css",
                    "~/Content/Css/System.css"));

            #endregion

            #region Account

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Account, ActionType.Login))
                .Include(
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Account, ActionType.ChangePassword))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Home

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Home, ActionType.Index)));

            #endregion

            #region Branch

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Branch, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Branch, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Branch, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            #endregion

            #region Company

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Company, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Company, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Company, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Dealer

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Dealer, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Dealer, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Dealer, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Department

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Department, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Department, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Department, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Disease

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Disease, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Disease, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Disease, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Ingredient

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Ingredient, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Ingredient, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Ingredient, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css"));

            #endregion

            #region IngredientGroup

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.IngredientGroup, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.IngredientGroup, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/MiniColors/Css/MiniColors.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.IngredientGroup, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/MiniColors/Css/MiniColors.min.css"));

            #endregion

            #region Job

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Job, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Job, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Job, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Menu

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Menu, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Menu, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css",
                    "~/Content/Components/DateRangePicker/Css/daterangepicker.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Menu, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css",
                    "~/Content/Components/DateRangePicker/Css/daterangepicker.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Menu, ActionType.NewWithTemplate))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css",
                    "~/Content/Components/DateRangePicker/Css/daterangepicker.css"));

            #endregion

            #region Region

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Region, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Region, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Region, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region Reservation

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Reservation, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/DateRangePicker/Css/daterangepicker.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Reservation, ActionType.IndexWithoutFilters))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/DateRangePicker/Css/daterangepicker.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Reservation, ActionType.Report))
                .Include(
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            #endregion

            #region Saucer

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Saucer, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Saucer, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Saucer, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Saucer, ActionType.Report))
                .Include(
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            #endregion

            #region Tip

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Tip, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Tip, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Tip, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            #endregion

            #region User

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.User, ActionType.Login))
                .Include(
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.User, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.User, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTab/Css/Tab.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.User, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            #endregion

            #region Warning

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Warning, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Warning, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Warning, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            #endregion

            #region Worker

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Worker, ActionType.Login))
                .Include(
                    "~/Content/Components/Required-field/Css/Required-field.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Worker, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Worker, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Worker, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/Required-field/Css/Required-field.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css",
                    "~/Content/Components/BootstrapTouchspin/Css/BootstrapTouchspin.min.css"));

            bundles.Add(new StyleBundle(String.Format(SystemConstants.RootBundleStyles, EntityType.Worker, ActionType.Report))
                .Include(
                    "~/Content/Components/Bootstrap/Css/Bootstrap-dialog.min.css",
                    "~/Content/Components/BootstrapTable/Css/bootstrap-table.min.css",
                    "~/Content/Components/Selectize/Css/Selectize.min.css"));

            #endregion

        }
    }
}
