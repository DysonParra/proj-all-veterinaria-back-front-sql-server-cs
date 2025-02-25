/*
 * @fileoverview    {Persona}
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

namespace Project.Models {

    /**
     * TODO: Description of {@code Persona}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class Persona {

        [Key]
        public Int64? IntIdPersona { get; set; }
        public String? StrNombres { get; set; }
        public String? StrCelular { get; set; }
        public String? StrEmail { get; set; }
        public String? StrUsuario { get; set; }
        public String? StrClave { get; set; }

    }

}