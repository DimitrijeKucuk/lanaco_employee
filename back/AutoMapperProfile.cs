using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee,GetEmployeeDTO>()
            .ForMember(
                dest => dest.FirstAndLastName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            ).ForMember(
                dest => dest.JobPosition,
                opt => opt.MapFrom(src => src.EmployeePositions.MaxBy(job => job.DateFrom).JobPosition.PositionName)
            ).ForMember(
                dest => dest.JobPositionPeriod,
                opt => opt.MapFrom(src => src.EmployeePositions.MaxBy(job => job.DateFrom).getPeriod())
            ).ForMember(
                dest => dest.BossFirstAndLastName,
                opt => opt.MapFrom(src => src.Boss.FirstName + " " + src.Boss.LastName)
            ).ForMember(
                dest => dest.Salary,
                opt => opt.MapFrom(src => src.Salaries.MaxBy(sal => sal.DateFrom).Amount)
            ).ForMember(
                dest => dest.ActiveBonus,
                opt => opt.MapFrom(src => src.Bonuses.Where(bon => bon.BonusDate.Month == DateTime.Today.Month).Sum(bon => bon.Amount))
            ).ForMember(
                dest => dest.ActiveDeducation,
                opt => opt.MapFrom(src => src.Deducations.Where(ded => ded.DeducationDate.Month == DateTime.Today.Month).Sum(ded => ded.Amount))
            );

            CreateMap<Employee,GetSalaryChangesDTO>()
            .ForMember(
                dest => dest.EmployeeFirstAndLastName,
                opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            ).ForMember(
                dest => dest.JobPosition,
                opt => opt.MapFrom(src => src.EmployeePositions.MaxBy(job => job.DateFrom).JobPosition.PositionName)
            ).ForMember(
                dest => dest.SalaryChanges,
                opt => opt.MapFrom(src => src.GetSalaryChanges())
            );

            // CreateMap<Employee,GetEmployeeWithPossiblePositions>()
            // .ForMember(
            //     dest => dest.EmployeeId,
            //     opt => opt.MapFrom(src => src.Id)
            // )
            // .ForMember(
            //     dest => dest.EmployeeFirstAndLastName,
            //     opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            // );
        }
    }
}