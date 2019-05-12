namespace FoodManager.Infrastructure.Constants
{
    public static class MessageConstants
    {
        //General
        public const string Create = "Registro creado con éxito!";
        public const string CreateWithErrors = "Registro creado con errores!";
        public const string Update = "Registro actualizado con éxito!";
        public const string Delete = "Registro eliminado con éxito!";
        public const string Activate = "Registro activado con éxito!";
        public const string Deactivate = "Registro desactivado con éxito!";
        public const string Save = "Registros guardados con éxito!";
        public const string ChangePassword = "Contraseña actualizada con éxito!";
        public const string ExportWithErrors = "Error al generar el archivo: Favor de contactar al administrador del sistema!";
        public const string FormWithoutAssign = "Activar el registro para habilitar la sección de asignación!";
        public const string FormWithoutAssigns = "Activar el registro para habilitar las secciones de asignación!";
        public const string WorkerReportInformation = "Seleccionar la opción 'Exportar' para generar el reporte de la ingesta calórica diaria por colaborador!";

        //Dates
        public const string InvalidRangeDates = "El rango de fechas original ({0} - {1}) es inválido, por lo que se actualizó a la fecha actual!";
        public const string InvalidStartDate = "La fecha inicio original ({0}) es inválida, por lo que se actualizó a la fecha actual!";

        //References
        public const string InactiveBranch = "La sucursal '{0}' está inactiva, favor de seleccionar otra sucursal!";
        public const string InactiveCompany = "La compañía '{0}' está inactiva, favor de seleccionar otra compañía!";
        public const string InactiveDealer = "El concesionario '{0}' está inactivo, favor de seleccionar otro concesionario!";
        public const string InactiveDepartment = "El departamento '{0}' está inactivo, favor de seleccionar otro departamento!";
        public const string InactiveDisease = "La enfermedad '{0}' está inactiva, favor de seleccionar otra enfermedad!";
        public const string InactiveIngredientGroup = "El grupo de ingredientes '{0}' está inactivo, favor de seleccionar otro grupo!";
        public const string InactiveJob = "El puesto '{0}' está inactivo, favor de seleccionar otro puesto!";
        public const string InactiveRegion = "La región '{0}' está inactiva, favor de seleccionar otra región!";
        public const string InactiveRole = "El rol '{0}' está inactivo, favor de seleccionar otro rol!";
        public const string InactiveSaucer = "El platillo '{0}' está inactivo, favor de seleccionar otro platillo!";
    }
}