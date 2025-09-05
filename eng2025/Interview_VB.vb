Partial Class Orders_Open
    Inherits System.Web.UI.Page
      Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
          Dim ds = OrderRepository.GetOpenOrders(txtCustomerId.Text, txtFrom.Text, txtTo.Text)
          grd.DataSource = ds.Tables(0)
          grd.DataBind()
          lblCount.Text = "Rows: " & ds.Tables(0).Rows.Count
      End Sub
End Class