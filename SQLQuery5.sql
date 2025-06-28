INSERT INTO Admins (FullName, Email, PasswordHash, Role)
VALUES 
('Super Admin', 'superadmin@example.com', 'super123', 'SuperAdmin'),
('Manager 1', 'manager@example.com', 'manager123', 'Manager');
select * from Admins;