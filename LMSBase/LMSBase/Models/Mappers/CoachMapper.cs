using LMSBase.Models.Domain;
using LMSBase.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Mappers
{
	public class CoachMapper
	{
		public static Coach ToDomain (CoachDto coachDto)
		{
			Coach coach = new Coach()
			{
				UserId = coachDto.UserId,
				UserName = coachDto.UserName,
				Email = coachDto.Email,
				Password = coachDto.Password
			};
			return coach;
		}

		public static CoachDto ToDto (Coach coach)
		{
			CoachDto coachDto = new CoachDto()
			{
				UserId = coach.UserId,
				UserName = coach.UserName,
				Email = coach.Email,
			};
			return coachDto;
		}
	}
}
