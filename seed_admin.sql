-- Crear usuario admin si no existe
IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE UserName = 'admin')
BEGIN
    INSERT INTO Usuarios 
    (Nombre, Apellido, UserName, Password, Email, RolId, Activo, FechaCreacion, IntentosLoginFallidos)
    VALUES 
    ('Administrador', 'Sistema', 'admin', 'admin123', 'admin@bas.com', 1, 1, GETUTCDATE(), 0);
    
    PRINT 'Usuario admin creado exitosamente';
END
ELSE
BEGIN
    PRINT 'Usuario admin ya existe';
END

-- Verificar que warce tenga el rol de administrador
UPDATE Usuarios 
SET RolId = 1 
WHERE UserName = 'warce' AND RolId != 1;

-- Mostrar usuarios existentes
SELECT 
    u.Id,
    u.Nombre,
    u.Apellido,
    u.UserName,
    u.Email,
    r.Nombre as Rol,
    r.EsAdministrador,
    u.Activo
FROM Usuarios u
LEFT JOIN Roles r ON u.RolId = r.Id
ORDER BY u.FechaCreacion;
