using AutoMapper;
using MediatR;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entityes;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Students.Commands.Handles
{
	public class StudentCommendHandilar : ResponseHandler,
										IRequestHandler<AddStudentComment, Response<string>>,
										IRequestHandler<EditStudentCommand, Response<string>>
	{
		private readonly IStudentServes _studentServes;
		private readonly IMapper _mapper;

		public StudentCommendHandilar(IStudentServes studentServes, IMapper mapper)
		{
			this._studentServes = studentServes;
			this._mapper = mapper;
		}
		public async Task<Response<string>> Handle(AddStudentComment request, CancellationToken cancellationToken)
		{
			var StudentMapper = _mapper.Map<Student>(request);
			var result = await _studentServes.AddAsync(StudentMapper);
			if (result == "Success") return Created("Added Sussessfully");
			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			//Check if Id is Exist or not
			var Student = await _studentServes.GetStudentByIDsAsync(request.Id);
			//Return Not Found
			if (Student == null) return NotFound<string>("Student Not Found ");
			//Mapping Between Request and student
			var StudentMapper = _mapper.Map<Student>(request);
			//Call Service that make Edit
			var Ruslt = await _studentServes.EditAsync(StudentMapper);
			//Return response
			if (Ruslt == "Success") return Success($"Edit Sussessfully{StudentMapper.StudID}");
			else return BadRequest<string>();
		}
	}
}
