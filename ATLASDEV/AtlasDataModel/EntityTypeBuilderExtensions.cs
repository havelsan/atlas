using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AtlasDataModel
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> HasParenRelation<TEntity, TRelatedEntity, TProperty>(this EntityTypeBuilder<TEntity> builder
            , Expression<Func<TEntity, TRelatedEntity>> navigationExpression
            , Expression<Func<TEntity, TProperty>> propertyExpression) 
            where TEntity : class
            where TRelatedEntity : class
        {
            

            return builder;
        }
    }
}
