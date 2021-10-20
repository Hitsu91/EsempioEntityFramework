using EsempioEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsempioEntityFramework.Services
{
    public interface ISuperEroeService
    {
        List<SuperEroe> GetAll();
        SuperEroe GetById(int id);
        // Quando verrà aggiunto un SuperEroe
        // Voglio restituire l'oggetto che è stato appena salvato nel Db
        // Perché in un sistema REST quando qualcuno effettua il POST
        // Dovrei restituirgli l'oggetto che è stato appena creato
        // (Perché lui ce lo manda senza Id, noi glielo restituiamo con l'Id)
        SuperEroe AddNew(SuperEroe newSuperEroe);
        // Stesso discorso restituisco l'oggetto che è stato appena eliminato
        SuperEroe DeleteById(int id);
    }
}
