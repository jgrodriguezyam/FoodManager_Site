using System;
using System.Web.Optimization;
using FoodManager.Infrastructure.Constants;
using FoodManager.Infrastructure.Enums;

namespace FoodManager.Infrastructure.Bundles
{
    public static class ScriptBundleModule
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Themes

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, "Shared", "Master"))
                .Include("~/Content/Components/JQuery/Scripts/JQuery.min.js",
                    "~/Content/Components/Pace/Scripts/Pace.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-autohidingnavbar.min.js",
                    "~/Content/Components/Messenger/Scripts/Messenger.min.js",
                    "~/Content/Components/PopupOverlay/Scripts/PopupOverlay.min.js",
                    "~/Content/Components/SlimScroll/Scripts/SlimScroll.min.js",
                    "~/Content/Scripts/General.js",
                    "~/Content/Scripts/Layout.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, "Shared", "Login"))
                .Include("~/Content/Components/JQuery/Scripts/JQuery.min.js",
                    "~/Content/Components/Pace/Scripts/Pace.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap.min.js",
                    "~/Content/Scripts/General.js"));

            #endregion

            #region Account

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Account, ActionType.Login))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Account, ActionType.ChangePassword))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/User/ChangePassword.js"));

            #endregion

            #region Home

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Home, ActionType.Index))
                .Include(
                    "~/Content/Scripts/Home/Index.js"));

            #endregion

            #region Branch

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Branch, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/Branch/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Branch, ActionType.New))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Branch/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Branch, ActionType.Edit))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Branch/Form.js"));


            #endregion

            #region Company

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Company, ActionType.Index))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Company/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Company, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Company/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Company, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Company/Form.js"));

            #endregion

            #region Dealer

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Dealer, ActionType.Index))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/ModalMultimedia.js",
                    "~/Content/Scripts/Dealer/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Dealer,
                ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Dealer/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Dealer, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Dealer/Form.js"));

            #endregion

            #region Department

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Department, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Department/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Department, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Department/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Department, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Department/Form.js"));

            #endregion

            #region Disease

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Disease, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Disease/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Disease, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Disease/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Disease, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Disease/Form.js"));

            #endregion

            #region Ingredient

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Ingredient, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/Ingredient/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Ingredient, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Ingredient/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Ingredient, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Ingredient/Form.js"));

            #endregion

            #region IngredientGroup

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.IngredientGroup, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/IngredientGroup/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.IngredientGroup, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/MiniColors/Scripts/Minicolors.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/IngredientGroup/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.IngredientGroup, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/MiniColors/Scripts/Minicolors.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/IngredientGroup/Form.js"));

            #endregion

            #region Job

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Job, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Job/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Job, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Job/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Job, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Job/Form.js"));

            #endregion

            #region Menu

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Menu, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/Menu/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Menu, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/moment.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/daterangepicker.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Menu/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Menu, ActionType.NewWithTemplate))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/moment.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/daterangepicker.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Menu/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Menu, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/moment.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/daterangepicker.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Menu/Form.js"));

            #endregion

            #region Region

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Region, ActionType.Index))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Region/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Region, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Region/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Region, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Region/Form.js"));

            #endregion

            #region Reservation

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Reservation, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/moment.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/daterangepicker.js",
                    "~/Content/Components/SparkLines/Scripts/SparkLines.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/ModalMultimedia.js",
                    "~/Content/Scripts/Reservation/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Reservation, ActionType.IndexWithoutFilters))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/moment.min.js",
                    "~/Content/Components/DateRangePicker/Scripts/daterangepicker.js",
                    "~/Content/Components/SparkLines/Scripts/SparkLines.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/ModalMultimedia.js",
                    "~/Content/Scripts/Reservation/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Reservation, ActionType.Report))
                .Include(
                    "~/Content/Components/SparkLines/Scripts/SparkLines.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Reservation/Report.js"));

            #endregion

            #region Saucer

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Saucer, ActionType.Index))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/ModalMultimedia.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Saucer/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Saucer, ActionType.New))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Saucer/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Saucer, ActionType.Edit))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Scripts/Selectable.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Saucer/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Saucer, ActionType.Report))
                .Include(
                    "~/Content/Components/SparkLines/Scripts/SparkLines.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Saucer/Report.js"));

            #endregion

            #region Tip

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Tip, ActionType.Index))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Tip/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Tip, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Tip/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Tip, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Tip/Form.js"));

            #endregion

            #region User

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.User, ActionType.Login))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.User, ActionType.Index))
                .Include(
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/User/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.User, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/User/New.js",
                    "~/Content/Scripts/User/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.User, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/User/Form.js",
                    "~/Content/Scripts/User/Edit.js",
                    "~/Content/Scripts/User/ChangePassword.js"));

            #endregion

            #region Warning

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Warning, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Warning/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Warning, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Warning/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Warning, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Warning/Form.js"));

            #endregion

            #region Worker

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Worker, ActionType.Login))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Worker, ActionType.Index))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/Worker/Index.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Worker, ActionType.New))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Worker/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Worker, ActionType.Edit))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-validator.min.js",
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-maxlength.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Components/BootstrapTouchspin/Scripts/BootstrapTouchspin.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/Validator.js",
                    "~/Content/Scripts/Worker/Form.js"));

            bundles.Add(new ScriptBundle(String.Format(SystemConstants.RootBundleScripts, EntityType.Worker, ActionType.Report))
                .Include(
                    "~/Content/Components/Bootstrap/Scripts/Bootstrap-dialog.min.js",
                    "~/Content/Components/BootstrapTable/Scripts/BootstrapTable.min.js",
                    "~/Content/Components/Selectize/Scripts/Selectize.min.js",
                    "~/Content/Scripts/Dialog.js",
                    "~/Content/Scripts/Table.js",
                    "~/Content/Scripts/Selectize.js",
                    "~/Content/Scripts/ModalDetails.js",
                    "~/Content/Scripts/Worker/Report.js"));

            #endregion

        } 
    }
}