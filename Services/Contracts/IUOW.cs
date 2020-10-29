using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    // ფუნქციების შენახვა რომ შევძლოთ ანუ create-ის დროს data გაიგზავნოს ბაზაში
    public interface IUOW : IDisposable
    {
        IMovieRepository Movie { get; }
        IPersonRepository Person { get; }

        void Commit();
    }
}
