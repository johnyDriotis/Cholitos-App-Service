
/*
	Crear columna Estado,
	Crear default constraint.
	Crear check constraint para valores A, I
*/
ALTER TABLE Cliente
ADD Estado CHAR(1) NOT NULL 
CONSTRAINT Ck_Estado_02 DEFAULT ('A')
CONSTRAINT Ck_Estado_01 CHECK (Estado IN ('A', 'I'))


