using GenericApi.Model;
using GenericApi.Model.Models.Base;
using GenericAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericApi.Service.Services
{
    public class EntityService
    {
        private readonly GenericApiContext _context;
        public EntityService(GenericApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetData(QueryDto query)
        {
            var clazz = Type.GetType("GenericApi.Model.Models." + query.Entity + ",GenericApi.Model");
            dynamic param = Activator.CreateInstance(clazz);

            return await GetData(param, query);
        }

        private async Task<IEnumerable<T>> GetData<T>(T param, QueryDto query) where T : BaseModel
        {
            IQueryable<T> entities = GetDbSet(param);

            IOrderedQueryable orderedQueryable;

            foreach (var criteria in query.Criterias)
            {
                entities = AddCriteria(param, entities, criteria);
            }

            if (query.OrderBy != null)
            {
                orderedQueryable = OrderBy(param, entities, query.OrderBy);
            }
            else if (query.OrderByDescending != null)
            {
                orderedQueryable = OrderByDescending(param, entities, query.OrderByDescending);
            }
            else
            {
                orderedQueryable = entities.OrderBy(x => x.Id);
            }



            return await entities.ToArrayAsync();
        }

        private IQueryable<T> AddCriteria<T>(T _, IQueryable<T> dbSet, QueryCriteriaDto criteria) where T : BaseModel
        {
            return AddCriteria(dbSet, criteria);
        }

        private sealed class holdPropertyValue<T>
        {
            public T v;
        }

        private IQueryable<T> AddCriteria<T>(IQueryable<T> dbSet, QueryCriteriaDto criteria) where T : BaseModel
        {

            var parameter = Expression.Parameter(typeof(T), "x");


            var property = Expression.PropertyOrField(parameter, criteria.Property);

            var left = property;
            var rigth = Expression.Constant(criteria.Value);

            BinaryExpression whereBody;
            if (criteria.Operator == Operators.EQUAL)
            {
                whereBody = Expression.Equal(left, rigth);
            }
            else if (criteria.Operator == Operators.GRATER_THAN_OR_EQUAL)
            {
                whereBody = Expression.GreaterThanOrEqual(left, rigth);
            }
            else if (criteria.Operator == Operators.LESS_THAN_OR_EQUAL)
            {
                whereBody = Expression.LessThanOrEqual(left, rigth);
            }
            else if (criteria.Operator == Operators.NOT_EQUAL)
            {
                whereBody = Expression.NotEqual(left, rigth);
            }
            else
            {
                whereBody = Expression.Equal(left, rigth);
            }

            var whereLambda = Expression.Lambda<Func<T, bool>>(whereBody, parameter);

            var whereCallExpression = Expression.Call(
                typeof(IQueryable),
                "Where",
                new[] { typeof(T) },
                dbSet.Expression,
                whereLambda
            );

            return dbSet.Provider.CreateQuery<T>(whereCallExpression);
        }

        private IQueryable<T> GetDbSet<T>(T _) where T : BaseModel
        {
            return _context.Set<T>().AsQueryable<T>();
        }

        private IOrderedQueryable<T> OrderBy<T>(T _, IQueryable<T> dbSet, string propertyName) where T : BaseModel
        {
            return ToOrderBy(dbSet, propertyName, "OrderBy");
        }

        private IOrderedQueryable<T> OrderByDescending<T>(T _, IQueryable<T> dbSet, string propertyName) where T : BaseModel
        {
            return ToOrderBy(dbSet, propertyName, "OrderByDescending");
        }

        private static IOrderedQueryable<T> ToOrderBy<T>(IQueryable<T> dbSet, string propertyName, string orderByOption) where T : BaseModel
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            Expression property = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            var orderByMethod = typeof(Queryable).GetMethods().First(x => x.Name == orderByOption && x.GetParameters().Length == 2);
            var orderByGeneric = orderByMethod.MakeGenericMethod(typeof(T), property.Type);
            var result = orderByGeneric.Invoke(null, new object[] { dbSet, lambda });

            return (IOrderedQueryable<T>)result;
        }
    }
}
