public static class OrderRepository
{
    public static DataSet GetOpenOrders(string customerId, string fromDate, string toDate)
    {
        var sql = "EXEC dbo.usp_GetOpenOrders " +
                  "@CustomerId = '" + customerId + "', " +
                  "@FromDate = '" + fromDate + "', " +
                  "@ToDate = '" + toDate + "'";

        var ds = new DataSet();
        var cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["LegacyDb"].ConnectionString
        );
        var da = new SqlDataAdapter(sql, cn);
        da.Fill(ds);

        return ds;
    }
}