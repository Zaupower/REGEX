using System.Text.RegularExpressions;

namespace RegularExpression
{
    public static class RegularExpressionStore
    {

        // should return a bool indicating whether the input string is
        // a valid team international email address: firstName.lastName@domain (serhii.mykhailov@teaminternational.com etc.)
        // address cannot contain numbers
        // address cannot contain spaces inside, but can contain spaces at the beginning and end of the string
        public static bool Method1(string input)
        {
            Regex regex = new Regex(@"^\s?[a-zA-Z._-]+@\w+\.com\s?$");
            bool isMatch = regex.IsMatch(input);
            return isMatch;
        }

        // the method should return a collection of field names from the json input
        public static IEnumerable<string> Method2(string inputJson)
        {
            //Full regex (?<="").+(?="" ?: ?("".+""|(\d+(.\d+)?)|true|null))
            //need to change .+(greedy basterd)
            Regex _test2Regex = new Regex(@"(?<="")+[a-zA-Z._0-9-*]+(?="":)");
            var matchList = _test2Regex.Matches(inputJson).ToList();
            IEnumerable<string> result = matchList.Cast<Match>().Select(match => match.Value).ToList();

            return result;
        }

        // the method should return a collection of field values from the json input
        public static IEnumerable<string> Method3(string inputJson)
        {
            Regex _test2Regex = new Regex(@"(?<=.+"":""|.+"":)+[a-zA-Z._0-9-*]+(?=}|""|,)");
            var matchList = _test2Regex.Matches(inputJson).ToList();
            IEnumerable<string> result = matchList.Cast<Match>().Select(match => match.Value).ToList();

            return result;
        }

        // the method should return a collection of field names from the xml input
        public static IEnumerable<string> Method4(string inputXml)
        {
            //Fields from Root: TestClass
            string rootElement = "TestClass";
            Regex _test2Regex = new Regex(@"(?<=<"+rootElement+".*<)+[a-zA-Z._0-9-*]+(?=|/>)");
            var matchList = _test2Regex.Matches(inputXml).ToList();
            IEnumerable<string> result = matchList.Cast<Match>().Select(match => match.Value).ToList();

            return result;
        }

        // the method should return a collection of field values from the input xml
        // omit null values
        public static IEnumerable<string> Method5(string inputXml)
        {
            //(?<=<)[a-zA-Z._0-9-*]+(?=.+\/>)(?=!\n)
            //V2   
            //(?<=<)[a-zA-Z._0-9-*]+(?=.+\/>|>)
            //(?<=<)+[a-zA-Z._0-9-*]+(?=>|(.*)\/>)
            Regex _test2Regex = new Regex(@"(?<=<TestClass .*>)+[a-zA-Z._0-9-*]+(?=|/>)");
            var matchList = _test2Regex.Matches(inputXml).ToList();
            IEnumerable<string> result = matchList.Cast<Match>().Select(match => match.Value).ToList();

            return result;
        }

        // read from the input string and return Ukrainian phone numbers written in the formats of 0671234567 | +380671234567 | (067)1234567 | (067) - 123 - 45 - 67
        // +38 - optional Ukrainian country code
         
        // make a decision for operators 067, 068, 095 and any subscriber part.
        // numbers can be separated by symbols , | ; /
        public static IEnumerable<string> Method6(string input)
        {
            //To get just the numbers: (?<=.*)[a-zA-Z._0-9( - )\-]+(?=.*) 
            Regex _test2Regex = new Regex(@"\s*(\+?(\d{1,3}))?[-. ()]*(\d{3})?[-. ()]*(\d{2})");
            var matchList = _test2Regex.Matches(input).ToList();
            IEnumerable<string> result = matchList.Cast<Match>().Select(match => match.Value).ToList();
            //IEnumerable<string> resultsReplace =result.Select(i=> Regex.Replace(i, @"\s+|\(|\)|\-|\.", "")).ToList();

            return result;
        }
    }
}