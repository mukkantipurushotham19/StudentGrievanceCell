CREATE DATABASE CollegeGrievanceCellDB

CREATE TABLE StudentLogin(UserId int UNIQUE NOT NULL ,UserName varchar(27) PRIMARY KEY,
Password varchar(27) NOT NULL,Department varchar(27) NOT NULL,PhoneNumber bigint UNIQUE NOT NULL,
EmailId varchar(37) UNIQUE NOT NULL,Designation varchar(27) NOT NULL)

select * from StudentLogin
drop  TABLE  StudentLogin  

CREATE PROCEDURE GETCREDENTIALS
AS BEGIN 
SELECT Username,Password,Designation from StudentLogin
END

CREATE PROCEDURE INSERTDETAILS
(@UserId int,@UserName varchar(27),@Password varchar(27),@Department varchar(27),@PhoneNumber bigint,@EmailId varchar(37),@Designation varchar(27))
AS BEGIN
INSERT INTO StudentLogin (UserId,UserName,Password,Department,PhoneNumber,EmailId,Designation)
VALUES (@UserId,@UserName,@Password,@Department,@PhoneNumber,@EmailId,@Designation)
END

select * from StudentLogin

----------------------------------------------------------------------------------------------------------
--Complaint Form

CREATE TABLE ComplaintForm(ComplaintId int identity primary key,ComplaintType varchar(107) not null,
Description varchar(107) not null,DateOfComplaint datetime,Status varchar(107),UpdateStatus varchar(107))

create procedure RegisterComplaint
(@ComplaintType varchar(107),@Description varchar(107),@DateOfComplaint 
datetime,@Status varchar(107),@UpdateStatus varchar(107))
AS BEGIN
INSERT INTO ComplaintForm (ComplaintType,Description,DateOfComplaint,Status,UpdateStatus) VALUES 
(@ComplaintType,@Description,@DateOfComplaint,@Status,@UpdateStatus)
END


create procedure GetComplaint 
@ComplaintId int  
As Begin
Select * from Complaintform where ComplaintId=@ComplaintId
end

create procedure GetPendingComplaints 
@UpdateStatus varchar(107)  
As Begin
Select * from Complaintform where UpdateStatus=@UpdateStatus
end


create procedure GetSolveComplaints 
@UpdateStatus varchar(107)  
As Begin
Select * from Complaintform where UpdateStatus=@UpdateStatus
end


select * from complaintform where UpdateStatus='null'

---------------------------------------------------------------------------------------------------------
--HOME CONTROLLER

create procedure GetAllComplaints 
As Begin
Select * from Complaintform 
end

create procedure UpdateStatus
(@ComplaintId int,@Status varchar(107),@UpdateStatus varchar(107))
AS BEGIN
UPDATE Complaintform SET Status=@Status,UpdateStatus=@UpdateStatus 
WHERE ComplaintId=@ComplaintId
END

-------------------------------------------------------------------------------------------------------
--Admin Controller


Create procedure SolvedComplaints
as begin
select * from complaintform where UpdateStatus='Solved'
end


create procedure DeleteStudent
@UserId int
AS BEGIN
delete from StudentLogin where UserId=@UserId
end

select * from StudentLogin

-------------------------------------------------------------------------------------------------------

