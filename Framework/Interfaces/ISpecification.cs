using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SimpleSecureStore
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
