using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Services.Contracts
{
    //აღვწეროთ ის ფუნქციები, რომლებსაც გამოვიყენებთ კლასებში
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> FindAll();
        //find data by condition
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        //get by id
        T Get(int id);
        void Create(T entity);

        void Update(T entity);
        void Delete(T entity);
    }
}
