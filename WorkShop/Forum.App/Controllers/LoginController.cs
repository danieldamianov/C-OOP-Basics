namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class LogInController : IController, IReadUserInfoController
    {
        public string Username { get; private set; }

        private string Password { get; set; }

        private bool Error { get; set; }

        public LogInController()
        {
            this.ResetLogin();
        }

        private enum Command
        {
            ReadUsername, ReadPassword, LogIn, Back
        }

        private void ResetLogin()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void ReadPassword()
        {
            throw new System.NotImplementedException();
        }

        public void ReadUsername()
        {
            throw new System.NotImplementedException();
        }
    }
}
