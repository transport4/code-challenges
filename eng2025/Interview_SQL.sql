-- Customers(CustomerId PK, Name, Status)
-- Orders(OrderId PK, CustomerId FK, CreatedAt, Status, Total)
-- OrderItems(ItemId PK, OrderId FK, Sku, Qty, UnitPrice)

CREATE PROC dbo.usp_GetOpenOrders
  @CustomerId NVARCHAR(10) = NULL,
  @FromDate   VARCHAR(10)  = NULL,
  @ToDate     VARCHAR(10)  = NULL
AS
BEGIN
  SET NOCOUNT ON;

  SELECT
    o.OrderId,
    o.CustomerId,
    o.CreatedAt,
    o.Status,
    SUM(oi.Qty * oi.UnitPrice) AS CalcTotal
  FROM Orders o WITH (NOLOCK)
  JOIN OrderItems oi WITH (NOLOCK)
    ON oi.OrderId = o.OrderId
  LEFT JOIN Customers c WITH (NOLOCK)
    ON c.CustomerId = o.CustomerId
  WHERE o.Status IN ('Open','Pending')
    AND (@CustomerId IS NULL OR o.CustomerId = @CustomerId)
    AND (@FromDate IS NULL OR o.CreatedAt >= @FromDate)
    AND (@ToDate IS NULL OR o.CreatedAt <= @ToDate)
  GROUP BY o.OrderId, o.CustomerId, o.CreatedAt, o.Status
  HAVING SUM(oi.Qty) > 0
  ORDER BY o.CreatedAt DESC;
END