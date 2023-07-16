using Entities;
using Microsoft.EntityFrameworkCore;
using NewComplexManagment.Services.Complexes.Contracts;
using NewComplexManagment.Services.Complexes.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.EFPresistence.Repositories.Complexes
{
    public class EFComplexRepository : ComplexRepository
    {
        private readonly DbSet<Complex> _complexes;
        private readonly DbSet<ComplexUsageType> _complexUsageTypes;
        private readonly DbSet<UsageType> _usageType;
        public EFComplexRepository(EFDataContext context) 
        {
            _complexes = context.Set<Complex>();
            _complexUsageTypes = context.Set<ComplexUsageType>();
            _usageType = context.Set<UsageType>();
        }
        public void Add(Complex complex)
        {
            _complexes.Add(complex);
        }

        public bool ComplexHasUnit(int id)
        {
            return
                _complexes.Where(_ => _.Id == id).Select(_ => _.Blocks.Select(_=>_.Units.Count()).Count() == 0).Any();
        }

        public bool ComplexIdIsExist(int id)
        {
            return _complexes.Any(_=>_.Id==id);
        }

        public Complex? FindById(int id)
        {
            return _complexes.Where(_=>_.Id == id).First(); 
        }

        public List<GetAllComplexDto> GetAllComplexDto(int? id, string? name)
        {

            var resualt=
                _complexes.Select(_=> new GetAllComplexDto
                {
                    Id=_.Id,
                    Name=_.Name,
                    UnitCount=_.UnitCount,
                    SubmitedUnitCount=_.Blocks.SelectMany(_=>_.Units).Count(),
                    RemainUnitCount=_.UnitCount - _.Blocks.SelectMany(_ => _.Units).Count()

                }).ToList();
            
            if (id != null)
            {
                resualt= resualt.Where(_=>_.Id==id ).ToList();
            }
            if (name != null)
            {
                resualt=resualt.Where(_=>_.Name==name).ToList();
            }
            return resualt;
        }

        public GetOneComplexDto GetOne(int id)
        {
            return _complexes.Where(_=>_.Id== id)
                .Select(_=> new GetOneComplexDto
                {
                    Id=_.Id,
                    Name=_.Name,
                    UnitCount=_.UnitCount,
                    SubmitedBlockCount=_.Blocks.Count(),
                    SubmitedUnitCount=_.Blocks.SelectMany(_=>_.Units).Count(),
                    RemainUnitCount=_.UnitCount - _.Blocks.SelectMany(_ => _.Units).Count()
                }).First();
        }

        public List<GetOneComplexUsageTypeDto>? GetOneComplexUsageType(int id)
        {
            return
                (from usagetype in _usageType
                 join complexusagetype in _complexUsageTypes on usagetype.Id equals complexusagetype.UsageTypeId
                 where complexusagetype.ComplexId == id
                 select new GetOneComplexUsageTypeDto
                 {
                     Name = usagetype.Name,
                     Id = usagetype.Id,

                 }).ToList();
        }

        public GetOneComplexWithBlockDto GetOneComplexWithBlockDto(int id, string? name)
        {
            var resualt = _complexes.Where(_ => _.Id == id)
                .Select(_ => new GetOneComplexWithBlockDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    GetBlockForComplexes = 
                    _.Blocks.Where(_=>name != null? _.Name==name:true).Select(block => new GetBlockForComplex
                    {
                        Id = block.Id,
                        Name = block.Name,
                        UnitCount = block.UnitCount,
                    }).ToList(),
                }).First();
            return resualt;
        }

        public int GetUnitCountById(int id)
        {
            return _complexes
               .Where(_ => _.Id == id)
               .Select(_ => _.UnitCount)
               .FirstOrDefault();
        }

        public void Update( Complex complex)
        {
            _complexes.Update(complex);
        }
    }
}
