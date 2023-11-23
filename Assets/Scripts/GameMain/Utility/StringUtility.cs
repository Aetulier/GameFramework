
namespace GameMain
{
    public static class StringUtility 
    {
        public static string GetUserName(string AllUserName)
        {
            string name_ = "";
            var match = System.Text.RegularExpressions.Regex.Match(AllUserName, "(?i)(?<=\\[)(.*)(?=\\])");
            if (match.Success)
            {
                name_= match.Value;
            }
            return name_;
        }
    }
}

