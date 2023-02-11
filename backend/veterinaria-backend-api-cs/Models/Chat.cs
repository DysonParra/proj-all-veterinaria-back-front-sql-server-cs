/*
 * @fileoverview    {Chat} se encarga de realizar tareas específicas.
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
 * TODO: Definición de {@code Chat}.
 *
 * @author Dyson Parra
 */
namespace Project.Models {

    public class Chat {

        [Key]
        public Int64? IntIdChat { get; set; }
        public Int32? IntRemitente { get; set; }
        public Int32? IntReceptor { get; set; }
        public String? TxtMensaje { get; set; }
        public DateTime? DtFecha { get; set; }
        public Int32? IntEstado { get; set; }
        public Int64? IntIdChatDetalle { get; set; }

    }

}