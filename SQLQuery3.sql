
CREATE TRIGGER triggerl
on [dbo].[AspNetUserRoles] 
for update
as

update AspNetUserRoles
SET RoleId='1' where RoleName= 'Administrador'
update AspNetUserRoles
SET RoleId='2' where RoleName= 'Usuario'
update AspNetUserRoles
SET RoleId='3' where RoleName= 'Cliente'