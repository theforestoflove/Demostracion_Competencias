
-- ===========================
-- TABLA: Especialidades
-- ===========================
CREATE TABLE especialidades (
    id_especialidad SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

-- ===========================
-- TABLA: Médicos
-- ===========================
CREATE TABLE medicos (
    id_medico SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    correo VARCHAR(100),
    id_especialidad INT,
    FOREIGN KEY (id_especialidad)
        REFERENCES especialidades(id_especialidad)
);

-- ===========================
-- TABLA: Pacientes
-- ===========================
CREATE TABLE pacientes (
    id_paciente SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE,
    sexo VARCHAR(10),
    telefono VARCHAR(20),
    direccion VARCHAR(200)
);

-- ===========================
-- TABLA: Consultorios
-- ===========================
CREATE TABLE consultorios (
    id_consultorio SERIAL PRIMARY KEY,
    numero VARCHAR(10) NOT NULL,
    piso INT
);

-- ===========================
-- TABLA: Citas
-- ===========================
CREATE TABLE citas (
    id_cita SERIAL PRIMARY KEY,
    id_paciente INT NOT NULL,
    id_medico INT NOT NULL,
    id_consultorio INT NOT NULL,
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    estado VARCHAR(20) DEFAULT 'Pendiente',

    FOREIGN KEY (id_paciente)
        REFERENCES pacientes(id_paciente),

    FOREIGN KEY (id_medico)
        REFERENCES medicos(id_medico),

    FOREIGN KEY (id_consultorio)
        REFERENCES consultorios(id_consultorio)
);

-- ===========================
-- TABLA: Habitaciones
-- ===========================
CREATE TABLE habitaciones (
    id_habitacion SERIAL PRIMARY KEY,
    numero VARCHAR(10),
    tipo VARCHAR(50),
    estado VARCHAR(20) DEFAULT 'Libre'
);

-- ===========================
-- TABLA: Internaciones
-- ===========================
CREATE TABLE internaciones (
    id_internacion SERIAL PRIMARY KEY,
    id_paciente INT NOT NULL,
    id_habitacion INT NOT NULL,
    fecha_ingreso DATE NOT NULL,
    fecha_salida DATE,

    FOREIGN KEY (id_paciente)
        REFERENCES pacientes(id_paciente),

    FOREIGN KEY (id_habitacion)
        REFERENCES habitaciones(id_habitacion)
);

-- ===========================
-- TABLA: Medicamentos
-- ===========================
CREATE TABLE medicamentos (
    id_medicamento SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT
);

-- ===========================
-- TABLA: Recetas
-- ===========================
CREATE TABLE recetas (
    id_receta SERIAL PRIMARY KEY,
    id_paciente INT NOT NULL,
    id_medico INT NOT NULL,
    id_medicamento INT NOT NULL,
    dosis VARCHAR(100),
    fecha DATE,

    FOREIGN KEY (id_paciente)
        REFERENCES pacientes(id_paciente),

    FOREIGN KEY (id_medico)
        REFERENCES medicos(id_medico),

    FOREIGN KEY (id_medicamento)
        REFERENCES medicamentos(id_medicamento)
);

-- ===========================
-- TABLA: Historias Clínicas
-- ===========================
CREATE TABLE historias_clinicas (
    id_historia SERIAL PRIMARY KEY,
    id_paciente INT NOT NULL,
    diagnostico TEXT,
    tratamiento TEXT,
    fecha DATE,

    FOREIGN KEY (id_paciente)
        REFERENCES pacientes(id_paciente)
);


