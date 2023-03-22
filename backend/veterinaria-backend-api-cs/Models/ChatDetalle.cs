/*
 * @fileoverview    {ChatDetalle}
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
 * TODO: Definición de {@code ChatDetalle}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class ChatDetalle {

        [Key]
        public Int64? IntIdChatDetalle { get; set; }
        public DateTime? DtUltima { get; set; }
        public String? EnmEscribiendo { get; set; }
        public Int64? IntIdPersona { get; set; }

    }

}