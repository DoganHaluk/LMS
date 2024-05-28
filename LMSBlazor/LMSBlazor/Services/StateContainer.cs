namespace LMSBlazor.Services
{
	public class StateContainer
	{
		private readonly LocalStorageService _storageService;
		private CurrentUser currentUser;

		public StateContainer(LocalStorageService storageService)
		{
			_storageService = storageService;
		}

		// event used to subscribe on changes in the StateContainer
		public event Action? OnChange;

		// trigger event handlers on subscribed components
		private void NotifyStateChanged() => OnChange?.Invoke();

		public async Task<CurrentUser> GetUserAsync()
		{
			// if available, return user from memory
			if (currentUser != null) { return currentUser; }

			// else, try to retrieve user from localstorage (previous login)
			else return await _storageService.GetItem<CurrentUser>("currentUser");
		}

		public async Task SetUserAsync(CurrentUser user)
		{
			// store user in localstorage
			if (user != null) await _storageService.SetItem("currentUser", user);
			else _storageService.RemoveItem("currentUser");

			// assign user to in-memory variable
			currentUser = user;

			// trigger eventhandler to notify state change to subscribed components
			NotifyStateChanged();
		}
	}
}
