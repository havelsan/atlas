using AtlasModel.Enterprise.Enums;
using System;

namespace AtlasModel.Enterprise
{
    public partial class TTWebMethodDef
    {
        public Guid WebMethodDefId { get; set; }
        public string Name { get; set; }
        public string ReturnType { get; set; }
        public short CheckOutStatus { get; set; }
        public RemoteMethodCallModeEnum CallMode { get; set; }
        public TTMessagePriorityEnum Priority { get; set; }
        public Guid ObjectDefId { get; set; }
        public string Description { get; set; }
        public string DisplayText { get; set; }
        public TTWebMethodAuthenticationTypeEnum AuthenticationType { get; set; }
        public string UserNameParameterName { get; set; }
        public string PasswordParameterName { get; set; }
        public TTWebMethodResourceParameterEnum ResourceParameterType { get; set; }
        public bool GenerateProcedureParameter { get; set; }
        public string MethodName { get; set; }
        public string FirmUserNameParameterName { get; set; }
        public string FirmPasswordParameterName { get; set; }
        public int? CallTimeout { get; set; }
        public HttpVerbMethod? HttpVerb { get; set; }
        public string ApplicationCodeParameterName { get; set; }
        public string OrganizationCodeParameterName { get; set; }
    }
}