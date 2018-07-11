CREATE TABLE lol(
	idregistro NUMERIC, 
	tipo_reg VARCHAR(MAX), 
	campo VARCHAR(MAX), 
	tipo VARCHAR(MAX), 
	longitud NUMERIC, 
	requerido VARCHAR(MAX), 
	posi NUMERIC, 
	posf NUMERIC, 
	orden NUMERIC, 
	campo_bd VARCHAR(MAX), 
	Valor_constante VARCHAR(MAX)
)
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'NSS', 'N', '9', 'S', '2', '10', '1', 'NSS', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'SEGUNDO_NOMBRE', 'A', '40', 'N', '73', '112', '5', 'SEGUNDO_NOMBRE', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'PRIMER_APELLIDO', 'A', '40', 'S', '113', '152', '6', 'PRIMER_APELLIDO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'SEGUNDO_APELLIDO', 'A', '40', 'N', '153', '192', '7', 'SEGUNDO_APELLIDO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'SEXO', 'A', '1', 'S', '193', '193', '8', 'SEXO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'FECHA_NACIMIENTO', 'N', '8', 'S', '194', '201', '9', 'FECHA_NACIMIENTO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'NUMERO_CONTRATO', 'N', '20', 'S', '202', '221', '10', 'NUMERO_CONTRATO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'FECHA_AFILIACION', 'N', '8', 'S', '222', '229', '11', 'FECHA_AFILIACION', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'RNC_EMPRESA', 'A', '11', 'N', '230', '240', '12', 'RNC_EMPRESA', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'PROVINCIA', 'A', '2', 'S', '241', '242', '13', 'PROVINCIA', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'MUNICIPIO', 'A', '3', 'S', '243', '245', '14', 'MUNICIPIO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'TIPO_AFILIADO', 'A', '1', 'S', '246', '246', '15', 'TIPO_AFILIADO', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'CLAVEP', 'A', '2', 'S', '2', '3', '1', 'CLAVEP', 'AF')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'CLAVE_SP', 'A', '2', 'S', '4', '5', '2', 'CLAVE_SP', 'CI')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'TIPO_ENTIDAD', 'N', '2', 'S', '6', '7', '3', 'TIPO_ENTIDAD', '03')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'CLAVE_ARS', 'N', '2', 'S', '8', '9', '4', 'CLAVE_ARS', '13')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'LOG_REG', 'N', '3', 'S', '10', '12', '5', 'LOG_REG', '246')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'FECHA_CARGA', 'F', '8', 'S', '13', '20', '6', 'FECHA_CARGA', '{FECHA}')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'E', 'NOMBRE_ARCHIVO', 'F', '40', 'S', '21', '80', '7', 'NOMBRE_ARCHIVO', '{ARCHIVO}')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'IDREGISTRO', 'N', '1', 'S', '1', '1', '0', 'IDREGISTRO', '{REGISTRO}')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'CEDULA_ANTERIOR', 'N', '11', 'S', '22', '32', '3', 'CEDULA_ANTERIOR', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'CEDULA_NUEVA', 'N', '11', 'S', '11', '21', '2', 'CEDULA_NUEVA', '')
INSERT INTO lol (idregistro, tipo_reg, campo, tipo, longitud, requerido, posi, posf, orden, campo_bd, Valor_constante)
VALUES('62', 'D', 'PRIMER_NOMBRE', 'A', '40', 'S', '33', '72', '4', 'PRIMER_NOMBRE', '')
