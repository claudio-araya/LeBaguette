using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class CargaryGuardar : MonoBehaviour
{
    private string rutaArchivo;
    static bool primeraVez = true;

    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/Datos.dat";
        if (primeraVez)
        {
            Cargar();
            primeraVez = false;
        }
    }
    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(rutaArchivo);
        DatosAGuardar datos = new DatosAGuardar(ControlJuego.nivelesDesbloqueados);
        bf.Serialize(file, datos);
        file.Close();
    }

    public void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(rutaArchivo, FileMode.Open);
            DatosAGuardar datos = (DatosAGuardar)bf.Deserialize(file);
            ControlJuego.nivelesDesbloqueados = datos.nivelesDesbloqueados;
        } else
        {
            ControlJuego.nivelesDesbloqueados = 0;
        }
    }
}

[System.Serializable]
class DatosAGuardar
{
    public int nivelesDesbloqueados;

    public DatosAGuardar(int nivelesDesbloqueados_)
    {
        nivelesDesbloqueados = nivelesDesbloqueados_;
    }
      
}
