using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entityes;
using SchoolProject.Service.Abstrcte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handles
{
	public class StudentCommendHandilar : ResponseHandler,
										IRequestHandler<AddStudentComment, Response<string>>
	{
		private readonly IStudentServes _studentServes;
		private readonly IMapper _mapper;

		public StudentCommendHandilar(IStudentServes studentServes,IMapper mapper)
        {
			this._studentServes = studentServes;
			this._mapper = mapper;
		}
        public async Task<Response<string>> Handle(AddStudentComment request, CancellationToken cancellationToken)
		{
			var StudentMapper = _mapper.Map<Student>(request);
			var result = await _studentServes.AddAsync(StudentMapper);
			if (result == "Exist") return UnprocessableEntity<string>("Name Is Exist");
			else if (result == "Success") return Created("Added Sussessfully");
			else return BadRequest<string>();
		}
	}
}
