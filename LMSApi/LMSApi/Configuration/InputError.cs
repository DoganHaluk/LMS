using LMSBase.Models.Domain;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace LMSApi.Configuration
{
	public class InputError
	{
		public string Name { get; set; }
		public string Message { get; set; }
		public string Code { get; set; }
		public string Value { get; set; }

		public static InputError CheckName(string name)
		{
			if (name.Length > 50)
			{
				InputError nameError = new InputError();
				nameError.Name = "Name";
				nameError.Message = "Above 50 characters";
				nameError.Code = "MaxCharacters";
				nameError.Value = "50";
				return nameError;
			}
			else if (string.IsNullOrEmpty(name))
			{
				InputError nameError = new InputError();
				nameError.Name = "Name";
				nameError.Message = "Empty Field";
				nameError.Code = "Empty_String";
				nameError.Value = "more than 1";
				return nameError;
			}
			else { return null; }
		}

		public static InputError CheckDescription(string description)
		{
			if (description.Length > 400)
			{
				InputError descriptionError = new InputError();
				descriptionError.Name = "Description";
				descriptionError.Message = "Above 400 characters";
				descriptionError.Code = "MaxCharacters";
				descriptionError.Value = "400";
				return descriptionError;
			}
			else if (string.IsNullOrEmpty(description))
			{
				InputError descriptionError = new InputError();
				descriptionError.Name = "Description";
				descriptionError.Message = "Empty Field";
				descriptionError.Code = "Empty_String";
				descriptionError.Value = "more than 1";
				return descriptionError;
			}
			else { return null; }
		}

		public static List<InputError> CheckEmail(string email)
		{
			List<InputError> errors = new List<InputError>();
			if (!email.Contains("@"))
			{
				InputError emailError = new InputError();
				emailError.Name = "Email";
				emailError.Message = "Missing @";
				emailError.Code = "WrongEmailAddress";
				emailError.Value = "@";
				errors.Add(emailError);
			}
			if (email.Length < 5)
			{
				InputError emailError = new InputError();
				emailError.Name = "Email";
				emailError.Message = "Less than 5 characters";
				emailError.Code = "MinimumCharacters";
				emailError.Value = "More than 5";
				errors.Add(emailError);
			}
			if (email.Length > 50)
			{
				InputError emailError = new InputError();
				emailError.Name = "Email";
				emailError.Message = "More than 50 characters";
				emailError.Code = "MaxCharacters";
				emailError.Value = "50";
				errors.Add(emailError);
			}
			return errors;
		}

		public static InputError CheckRepeatPassword(string password, string repeatPassword)
		{
			if (password != repeatPassword)
			{
				InputError passwordError = new InputError();
				passwordError.Name = "Password";
				passwordError.Message = "The two passwords are different";
				passwordError.Code = "CorrectEntry";
				passwordError.Value = "Identical";
				return passwordError;
			}
			else
			{
				return null;
			}
		}

		public static InputError CheckOwner(int urlId, int tokenId)
		{
			if (urlId != tokenId)
			{
				InputError ownerError = new InputError();
				ownerError.Name = "Owner";
				ownerError.Message = "Not allowed to make modifications";
				ownerError.Code = "Wrong Owner";
				ownerError.Value = "Wrong credentials";
				return ownerError;
			}
			else
			{
				return null;
			}
		}

		public static InputError CheckSchoolClass()
		{
			InputError schoolClassError = new InputError();
			schoolClassError.Name = "SchoolClass";
			schoolClassError.Message = "This SchoolClass is not in our database";
			schoolClassError.Code = "Wrong SchoolClass";
			schoolClassError.Value = "Wrong SchoolClassId";
			return schoolClassError;
		}

		public static InputError CheckCoach()
		{
			InputError coachError = new InputError();
			coachError.Name = "Coach";
			coachError.Message = "This Coach is not in our database";
			coachError.Code = "Wrong Coach";
			coachError.Value = "Wrong CoachId";
			return coachError;
		}

		public static InputError CheckExistingName(string name1, string name2)
		{
			if (!name2.IsNullOrEmpty() && name1 == name2)
			{
				InputError sameNameError = new InputError();
				sameNameError.Name = "Existing Name";
				sameNameError.Message = "An element with the same name already exist";
				sameNameError.Code = "Redundance";
				sameNameError.Value = "Change Name";
				return sameNameError;
			}
			else
			{
				return null;
			}
		}

		public static InputError CheckCourse()
		{
			InputError courseError = new InputError();
			courseError.Name = "Course";
			courseError.Message = "This Course is not in our database";
			courseError.Code = "Wrong Course";
			courseError.Value = "Wrong CourseId";
			return courseError;
		}

		public static InputError CheckLearningModule(LearningModule learningModule)
		{
			if (learningModule == null)
			{
				InputError learningModuleError = new InputError();
				learningModuleError.Name = "Learning Module";
				learningModuleError.Message = "This module is not in our database";
				learningModuleError.Code = "Wrong module";
				learningModuleError.Value = "Wrong moduleId";
				return learningModuleError;
			}
			else
			{
				return null;
			}
		}

		public static InputError CheckCodelab(Codelab codelab)
		{
			if (codelab == null)
			{
				InputError codelabError = new InputError();
				codelabError.Name = "Codelab";
				codelabError.Message = "This codelab is not in our database";
				codelabError.Code = "Wrong codelab";
				codelabError.Value = "Wrong codelabId";
				return codelabError;
			}
			else
			{
				return null;
			}
		}

		public static InputError CheckSchoolClassCourse()
		{
			InputError schoolClassCourseError = new InputError();
			schoolClassCourseError.Name = "SchoolClassCourse";
			schoolClassCourseError.Message = "This Course is already in this Class";
			schoolClassCourseError.Code = "Wrong Course";
			schoolClassCourseError.Value = "Wrong SchoolClassCourseId";
			return schoolClassCourseError;
		}


	}
}
