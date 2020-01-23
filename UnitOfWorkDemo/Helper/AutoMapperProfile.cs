using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfWorkDemo.Dtos;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Helper
{
	public class AutoMapperProfile: Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Student, StudentsForDetailedDto>();
			CreateMap<StudentForCreationDto, Student>();
			CreateMap<StudentsForEditDto, Student>();
		}
	}
}
