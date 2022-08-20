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
    }
}
