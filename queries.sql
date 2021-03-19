Create procedure GetStore OUT Table @tbl
as
Begin
declare @StoreID int ,
@StoreName varchar(40)

Select StoreID,StoreName from PizzaStore order by 1

END

Select StoreID,StoreName from 

update PizzaStore 
set StoreName='Church st Store' where StoreID=2

Select StoreID,StoreName from PizzaStore order by 1

Select top 10 PizzaId,PizzaName, p.PizzaSizeID,PizzaSize, p.PizzaCrustId,PizzaCrustDescription, PizzaTopping1, pt.PizzaToppingDescription  ,PizzaTopping2,  pt2.PizzaToppingDescription  ,PizzaTopping3,  pt3.PizzaToppingDescription 
from Pizza p
Left Join PizzaSize ps on p.PizzaSizeID=ps.PizzaSizeID
Left join PizzaCrust pc on p.PizzaCrustID=pc.PizzaCrustID
left join  PizzaTopping pt on p.PizzaTopping1=pt.PizzaToppingID 
left join  PizzaTopping pt2 on p.PizzaTopping2=pt2.PizzaToppingID 
left join  PizzaTopping pt3 on p.PizzaTopping3=pt3.PizzaToppingID 
order by 1

Select top 10 PizzaId,PizzaName, PizzaSize, PizzaCrustDescription as Crust, pt.PizzaToppingDescription tp1, pt2.PizzaToppingDescription tp2 , pt3.PizzaToppingDescription tp3
from Pizza p
Left Join PizzaSize ps on p.PizzaSizeID=ps.PizzaSizeID
Left join PizzaCrust pc on p.PizzaCrustID=pc.PizzaCrustID
left join  PizzaTopping pt on p.PizzaTopping1=pt.PizzaToppingID 
left join  PizzaTopping pt2 on p.PizzaTopping2=pt2.PizzaToppingID 
left join  PizzaTopping pt3 on p.PizzaTopping3=pt3.PizzaToppingID 
order by 1

select po.PizzaOrderId, po.CustomerID,  c.FirstName + c.LastName CustomerName,  po.StoreID,   StoreName,  OrderDateTime,po.OrderStatus,pod.PizzaQuantity,pod.Price , pod.PizzaOrderDetailID, pod.PizzaID 
from PizzaOrder po
left join PizzaOrderDetails pod on po.PizzaOrderId=pod.PizzaOrderId
Left join Customer c on po.CustomerID=c.CustomerID
Left join  PizzaStore ps on po.StoreID=ps.StoreID
left join Pizza p on pod.PizzaID=p.PizzaID


select * from PizzaOrderDetails





