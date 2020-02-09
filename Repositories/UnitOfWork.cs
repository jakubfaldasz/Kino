using KinoDotNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoDotNetCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private KinoContext context;
        private SeanseRepository seanseRepository;
        private OpinieRepository opinieRepository;
        private FilmyRepository filmyRepository;
        private PracownicyRepository pracownicyRepository;
        private KlienciRepository klienciRepository;
        private BiletyRepository biletyRepository;

        public SeanseRepository SeanseRepository
        {
            get
            {
                return seanseRepository = seanseRepository ?? new SeanseRepository(context);
            }
        }

        public OpinieRepository OpinieRepository
        {
            get
            {
                return opinieRepository = opinieRepository ?? new OpinieRepository(context);
            }
        }

        public FilmyRepository FilmyRepository
        {
            get
            {
                return filmyRepository = filmyRepository ?? new FilmyRepository(context);
            }
        }

        public PracownicyRepository PracownicyRepository
        {
            get
            {
                return pracownicyRepository = pracownicyRepository ?? new PracownicyRepository(context);
            }
        }

        public KlienciRepository KlienciRepository
        {
            get
            {
                return klienciRepository = klienciRepository ?? new KlienciRepository(context);
            }
        }

        public BiletyRepository BiletyRepository
        {
            get
            {
                return biletyRepository = biletyRepository ?? new BiletyRepository(context);
            }
        }

        public UnitOfWork(KinoContext dbContext)
        {
            this.context = dbContext;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
