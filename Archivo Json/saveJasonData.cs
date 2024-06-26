﻿using Newtonsoft.Json;
using Practica3.Moldels_Usuer;
using System.IO;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace Practica3.Verificacion_de_carpeta_Json_y_Txt
{
    public class saveJasonData
    {
            public static void SerializeJsonFile(List<UsuarioInformacion> informacion)
            {
                string informacionJson = JsonConvert.SerializeObject(informacion.ToArray(), Formatting.Indented);
                File.WriteAllText(Verificacion.JsonPath, informacionJson);
            }
            public static List<UsuarioInformacion> GetUsuarioInformacions(UsuarioInformacion info)
            {
                List<UsuarioInformacion> informacion = new List<UsuarioInformacion> {

                  new UsuarioInformacion
                  {
                    name = info.name,
                    lastName = info.lastName,
                    userName = info.userName,
                    mailAddress = info.mailAddress,
                    password = info.password,
                    phoneNumber = info.phoneNumber,

                  }

                };
                   // SerializeJsonFile(informacion);
                  return informacion;
             }

            public static string GetInformacionRegistro()
            {
                string Informacionregistro;
                using (var reader = new StreamReader(Verificacion.JsonPath))
                {
                    Informacionregistro = reader.ReadToEnd();
                }
                return Informacionregistro;
            }

            public static List<UsuarioInformacion> DeserializeJsonFile()
            {
                try
                {
                    string jsonText = File.ReadAllText(Verificacion.JsonPath);
                    List<UsuarioInformacion> usuarios = JsonConvert.DeserializeObject<List<UsuarioInformacion>>(jsonText);
                    return usuarios;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al cargar los usuarios registrados: " + ex.Message);
                    return new List<UsuarioInformacion>();
                }
            }
        
    }
}
