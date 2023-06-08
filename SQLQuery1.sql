
CREATE DATABASE Prueba;

use Prueba

Create table autores(
 _key  int identity(1,1), 
id int  primary key,
nombre varchar(45),
apellido varchar(45)


)

create table libros(
 _key  int identity(1,1), 
IBN int primary key,
esditoriales_id int,
titulo varchar(45),
sinopsis text,
n_paginas varchar (45),

)

create table autores_has_libros(
_key  int identity(1,1) primary key, 
id int ,
autores_id int
)

create table editoriales(
 _key  int identity(1,1), 
id int primary key, 
nombre varchar(45),
sede varchar(45),

)