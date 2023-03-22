/*
 * @fileoverview    {Mascota}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Mascota}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Mascota {

        [Key]
        public Int64? IntIdMascota { get; set; }
        public String? StrNombre { get; set; }
        public String? StrEdad { get; set; }
        public String? StrUbicacion { get; set; }
        public String? StrRaza { get; set; }
        public String? StrTipo { get; set; }
        public Int64? IntIdPersona { get; set; }

    }

}