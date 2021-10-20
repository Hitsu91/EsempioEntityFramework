using EsempioEntityFramework.Data;
using EsempioEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsempioEntityFramework.Services
{
    public class SuperEroeService : ISuperEroeService
    {
        private readonly DataContext _ctx;

        // Tramite DI ci facciamo passare un oggetto di tipo DataContext
        public SuperEroeService(DataContext ctx)
        {
            _ctx = ctx;
        }

        public SuperEroe AddNew(SuperEroe newSuperEroe)
        {
            // Per persistere un nuovo dato andiamo a prendere il DbSet
            // di riferimento; usando il metodo Add
            // ci restituisce poi il nuovo oggetto che è stato salvato
            // con l'ID
            var addedObj = _ctx.SuperHeroes.Add(newSuperEroe);
            // Di Default EF finché effettuiamo delle operazioni non andrà MAI
            // a salvare le modifiche sul DB, fin quando non viene richiamato
            // il metodo SaveChanges(), ci dà la possibilità di effettuare un
            // RollBack Automatico, qualora ci fossero dei problemi
            _ctx.SaveChanges(); // ATTENZIONE BISOGNA RICORDARSI DI FARLO!!!!
            return addedObj.Entity;
        }

        public SuperEroe DeleteById(int id)
        {
            // Sempre per mezzo di Linq, vado a trovare l'entity da rimuovere
            var toBeRemoved = _ctx.SuperHeroes.FirstOrDefault(hero => hero.Id == id);
            if (toBeRemoved is null)
            {
                return toBeRemoved;
            }
            // Per mezzo del metodo Remove, a cui passo l'oggetto da rimuovere dal DB
            _ctx.SuperHeroes.Remove(toBeRemoved);
            // Ricordarsi di effettuare SaveChanges
            _ctx.SaveChanges();
            // Lo restituisco in quanto richiesto dalla firma del metodo
            return toBeRemoved;
        }

        public List<SuperEroe> GetAll()
        {
            // Questa proprietà che abbia definito in DataContext ci 
            // permetterà di effettuare le varie operazioni sugli oggetti
            // SuperEroe
            return _ctx.SuperHeroes.ToList();
            // Dal DbSet uso il metodo ToList()
            // Che in sostanza andrà ad effettuare una select sul DB
            // e mi restituirà la lista degli oggetti
            // Effettuando tutte le operazioni di ORM
            // EF usa le API di Linq per fornire il grosso delle implementazioni
        }

        public SuperEroe GetById(int id)
        {
            return _ctx.SuperHeroes.FirstOrDefault(hero => hero.Id == id);
        }
    }
}
