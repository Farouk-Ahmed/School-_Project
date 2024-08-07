﻿using MediatR;
using SchoolProject.Core.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.AppUser.Commands.Models
{
	public class ChangeUserPasswordCommand:IRequest<Response<string>>
	{
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfierPassword { get; set; }
    }
}
