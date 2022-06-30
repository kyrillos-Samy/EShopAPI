using Domain.Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helper.Extension
{
    internal static class MappingExtention
    {

        internal static TEntity ToEntity<TEntity>(this BaseDTO dto) where TEntity : BaseEntity
        {
            return AutoMapperConfiguration.Mapper.Map<TEntity>(dto);
        }
        internal static IList<TEntity> ToEntityList<TEntity>(this IEnumerable<BaseDTO> dtos)
            where TEntity : BaseEntity
        {
            return AutoMapperConfiguration.Mapper.Map<IList<TEntity>>(dtos);
        }
        internal static TDto ToDto<TDto>(this BaseEntity entity) where TDto : BaseDTO
        {
            return AutoMapperConfiguration.Mapper.Map<TDto>(entity);
        }
        internal static IList<TDto> ToDtoList<TDto>(this IEnumerable<BaseEntity> entity)
            where TDto : BaseDTO
        {
            return AutoMapperConfiguration.Mapper.Map<IList<TDto>>(entity);
        }


        internal static T As<T>(this object obj)
        {
            return AutoMapperConfiguration.Mapper.Map(obj, default(T));
        }
    }
}
