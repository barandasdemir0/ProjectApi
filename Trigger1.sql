--update Abouts set RoomCount = (select count(*) from Rooms),
--StaffCount = (select count(*) from Staffs),
--CustomerCount = (select count(*) from Guests)
--select * from Abouts

--create trigger Roomincrease
--on Rooms
--after insert
--as 
--update Abouts set RoomCount = RoomCount+1
--Declare @RoomCount int
--Select @RoomCount = 

--create trigger Roomdecrease
--on Rooms
--after insert
--as 
--update Abouts set RoomCount = RoomCount-1

--create trigger Staffincrease
--on Staffs
--after insert
--as 
--update Abouts set StaffCount = StaffCount+1

--create trigger Staffdecrease
--on Staffs
--after insert
--as 
--update Abouts set StaffCount = StaffCount-1

--create trigger Guestincrease
--on Guests
--after insert
--as 
--update Abouts set CustomerCount = CustomerCount+1

--create trigger Guestdecrease
--on Guests
--after insert
--as 
--update Abouts set CustomerCount = CustomerCount-1



