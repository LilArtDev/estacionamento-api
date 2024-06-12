namespace EstacionamentoAPI.Shared
{
    public static partial class StringUtils
    {

        public static string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = MyRegex().Match(input);
            return startUnderscores + MyRegex1().Replace(input, "$1_$2").ToLower();
        }

        [System.Text.RegularExpressions.GeneratedRegex(@"^_+")]
        private static partial System.Text.RegularExpressions.Regex MyRegex();
        [System.Text.RegularExpressions.GeneratedRegex(@"([a-z0-9])([A-Z])")]
        private static partial System.Text.RegularExpressions.Regex MyRegex1();
    }

}