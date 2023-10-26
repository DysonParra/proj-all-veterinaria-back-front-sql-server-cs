/*
 * @fileoverview    {Foto}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.ComponentModel.DataAnnotations;

/**
 * TODO: Definición de {@code Foto}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Foto {

        [Key]
        public Int64? IntIdFoto { get; set; }
        public String? StrImagen { get; set; }
        public Int64? IntIdMascota { get; set; }

    }

}