namespace Soccer.ViewModels
{
    public class MainViewModel
    {
        #region Atributtes
        public LoginViewModel Login { get; set; }
        #endregion

        #region Properties

        #endregion


        #region Constructor
        public MainViewModel()
        {
            Login = new LoginViewModel();
        }
        #endregion
    }
}
