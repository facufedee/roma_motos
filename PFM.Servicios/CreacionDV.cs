using System;
using System.Collections.Generic;
using BE;
using SERVICIOS;

namespace FRAMEWORK
{
    public class CreacionDV
    {
        // Genera el DVH para un usuario específico
        public string Generar(BEUser usuario)
        {
            string cadena = usuario.Username + usuario.Nombre + usuario.Apellido + usuario.Mail;
            Criptografia Enc = new Criptografia();
            string dvh = Enc.Encriptador(cadena);
            return dvh;
        }


        public List<string> listasDVH()
        {


            return listasDVH();

        }


        // Genera el DVV a partir de una lista de DVHs
        public string GenerarDVV(List<string> listasDVH)
        {
            string cadena = string.Join("", listasDVH);
            Criptografia Enc = new Criptografia();
            string dvv = Enc.Encriptador(cadena);
            return dvv;
        }
    }
}
