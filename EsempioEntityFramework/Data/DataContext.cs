using EsempioEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsempioEntityFramework.Data
{
    // Questa classe avrà in gestione tutti i dati della nostra applicazione
    public class DataContext : DbContext
    // Estendiamo la classe DbContext (Per configurazione
    // Il framework andrà poi a fornirci tutti gli strumenti
    // necessari per operare sui dati degli oggetti delle Classi
    // che andremo a specificare all'interno di questa classe
    {
        // Il Costruttore della nostra classe deve passare un parametro
        // al costruttore della classe padre
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Il Framework passerà al costruttore le options
            // che noi ripassiamo al costruttore padre
        }

        // All'interno di questa classe andiamo a definire delle proprietà
        // che corrisponderanno a degli oggetti che sono in grado
        // di effettuare ORM su un determinato Modello
        // DbSet è praticamente la tabella, ci fornisce una serie di metodi
        // per andare ad effettuare le operazioni sulla tabella
        public DbSet<SuperEroe> SuperHeroes { get; set; }
        // Per ogni modello su cui abbiamo bisogno di far persistenza
        // basterà definire un'altra proprietà DbSet<ModelClass>

    }
}
