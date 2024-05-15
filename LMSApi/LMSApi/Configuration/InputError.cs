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

		public static InputError CheckEmail(string email)
		{
			if (!email.Contains("@"))
			{
				InputError emailError = new InputError();
				emailError.Name = "Email";
				emailError.Message = "Missing @";
				emailError.Code = "WrongEmailAddress";
				emailError.Value = "@";
				return emailError;
			}
			else if (email.Length < 5)
			{
				InputError emailError = new InputError();
				emailError.Name = "Email";
				emailError.Message = "Less than 5 characters";
				emailError.Code = "MinimumCharacters";
				emailError.Value = "More than 5";
				return emailError;
			}
			else if (email.Length > 50)
			{
				InputError emailError = new InputError();
				emailError.Name = "Email";
				emailError.Message = "More than 50 characters";
				emailError.Code = "MaxCharacters";
				emailError.Value = "50";
				return emailError;
			}
			else { return null; }
		}


	}
}
