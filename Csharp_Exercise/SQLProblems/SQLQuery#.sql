select * from tbl_emp_details
create procedure sp_details
@param int as begin
select * from tbl_emp_details where EmpId =@param end

alter Procedure sp_PrintevenNo
@input int
as 
begin
 Declare @StartNo int
 set @StartNo =1

 while(@StartNo < @input)
 begin
   if(@StartNo % 2 = 0)
    begin
	  Print @StartNo
	    
	End
	Set @StartNo = @StartNo + 1
   END
   Print 'Finished Printing even number till' + RTRIM(@input)

END

Declare @input int
set @input = 20
execute sp_PrintevenNo @input
Print 'Done'
exec sp_details 121