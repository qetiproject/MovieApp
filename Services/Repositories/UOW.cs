using DAL.Context;
using Services.Contracts;

namespace Services.Repositories
{
    public class UOW : IUOW
    {
        private MovieDbContext Context;
        private MovieRepository movieRepository;
        private PersonRepository personRepository;

        public UOW(MovieDbContext context)
        {
            Context = context;
        }
        public IMovieRepository Movie
        {
            get
            {
                if(movieRepository == null)
                    movieRepository = new MovieRepository(Context);
                    return movieRepository;          
            }
        }

        public IPersonRepository Person
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(Context);
                return personRepository;
            }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
