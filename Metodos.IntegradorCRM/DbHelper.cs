namespace Metodos.IntegradorCRM
{
    public static class DbHelper
    {
        public static int GetInt(object value) => value == DBNull.Value ? 0 : Convert.ToInt32(value);
        public static decimal GetDecimal(object value) => value == DBNull.Value ? 0m : Convert.ToDecimal(value);
        public static string GetString(object value) => value == DBNull.Value ? string.Empty : value.ToString();
        public static DateTime? GetDateTime(object value) => value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(value);
    }

}
