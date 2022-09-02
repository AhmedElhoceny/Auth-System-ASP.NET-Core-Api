namespace El_Lo2ma.Constants
{
    public static class Routes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        // Main Routes
        public const string SignUp = Base + "/auth/signup";
        public const string LogIn = Base + "/auth/logIn";
        public const string RefreshToken = Base + "/auth/refreshtoken";
        public const string ListOfUsers = Base + "/auth/listofusers";
        public const string RemoveUser = Base + "/auth/removeuser/{UserId}";
        public const string UpdateUser = Base + "/auth/updateuser/{userId}";
        public const string ListOfRoles = Base + "/auth/listofroles";
        public const string ChangeActivationUser = Base + "/auth/changeactivationuser/{userId}";
        public const string ForgetPassWordRequest = Base + "/auth/forgetpasswordrequest/{userId}";
        public const string ForgetPassWordPost = Base + "/auth/forgetpasswordpost";
        public const string ChangePassWord = Base + "/auth/changepassword";
    }
}
