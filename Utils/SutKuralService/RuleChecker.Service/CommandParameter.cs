using System.Data;

namespace RuleChecker.Service
{
    public class CommandParameter
    {
        public CommandParameter(string name, object value)
        {
            ParamName = name;
            ParamType = DbType.Object;
            ParamValue = value;
        }

        public CommandParameter(string name, object value, DbType dbType)
        {
            ParamName = name;
            ParamType = dbType;
            ParamValue = value;
        }

        public DbType ParamType { get; set; }
        public string ParamName { get; set; }
        public object ParamValue { get; set; }
    }
}
