using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Basic;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entityes;
using SchoolProject.Service.Abstrcte;

namespace SchoolProject.Core.Features.Students.Commands.Handles
{
	public class StudentCommendHandilar : ResponseHandler,
										IRequestHandler<AddStudentComment, Response<string>>,

										IRequestHandler<EditStudentCommand, Response<string>>,
										IRequestHandler<DeleteStudeentCommand, Response<string>>
	{
		private readonly IStudentServes _studentServes;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResourcesed> _localizer;

		public StudentCommendHandilar(IStudentServes studentServes
			, IMapper mapper
			, IStringLocalizer<SharedResourcesed> Localizer) : base(Localizer)
		{
			this._studentServes = studentServes;
			this._mapper = mapper;
			_localizer = Localizer;
		}
		public async Task<Response<string>> Handle(AddStudentComment request, CancellationToken cancellationToken)
		{
			var StudentMapper = _mapper.Map<Student>(request);
			var result = await _studentServes.AddAsync(StudentMapper);
			if (result == "Success") return Created<string>(_localizer[SharedResourcesKeys.Created]);
			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			//Check if Id is Exist or not
			var Student = await _studentServes.GetByIDsAsync(request.Id);
			//Return Not Found
			if (Student == null) return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);
			//Mapping Between Request and student
			var StudentMapper = _mapper.Map<Student>(request);
			//Call Service that make Edit
			var Ruslt = await _studentServes.EditAsync(StudentMapper);
			//Return response
			if (Ruslt == "Success") return Success($"{StudentMapper.StudID}");
			else return BadRequest<string>();
		}

		public async Task<Response<string>> Handle(DeleteStudeentCommand request, CancellationToken cancellationToken)
		{
			//Check if Id is Exist or not
			var Student = await _studentServes.GetByIDsAsync(request.Id);
			//Return Not Found
			if (Student == null) return NotFound<string>(_localizer[SharedResourcesKeys.NotFound]);
			//Call Service that make Delete
			var Ruslt = await _studentServes.DeleteAsync(Student);
			//Return response
			if (Ruslt == "Success") return Deleted<string>(_localizer[SharedResourcesKeys.Deleted] + $" ID = {request.Id}");
			else return BadRequest<string>();
		}

	}
}
