using Infrastructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Models
{
    public class ObjectDefItem
    {
        public Guid ObjectDefID { get; set; }
        public string ObjectDefName { get; set; }
        public string ModulePath { get; set; }
    }

    public class FormDefItem
    {
        public Guid FormDefID { get; set; }
        public string FormName { get; set; }
        public string ModuleName { get; set; }
        public string ModulePath { get; set; }
    }

    public class ReportDefinition
    {
        public Guid ReportDefID { get; set; }
        public Guid ModuleDefID { get; set; }
        public string ReportNO { get; set; }
        public string CodeName { get; set; }
        public string InterfaceName { get; set; }
        public string ModifiedName { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string ReportXML { get; set; }
        public ReportParameters Parameters { get; set; }
    }

    [XmlRoot("PARAMS")]
    public class ReportParameters
    {
        [XmlElement("PARAM")]
        public List<ReportParameter> List { get; set; }
    }

    public class ReportParameter
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        public string DataTypeID { get; set; }
        public bool Required { get; set; }
        public string ListFilterExpression { get; set; }
        public string ListDefID { get; set; }
        public string LinkedParameterName { get; set; }
        public string LinkedRelationDefID { get; set; }
        public string DataTypeName { get; set; }
        public bool IsEnum { get; set; }
        public bool Visible { get; set; } = true;
        [XmlIgnore]
        public IList<EnumLookupItem> EnumList { get; set; }
    }

    public class ListDefinition
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string DisplayExpression { get; set; }
        public string ValuePropertyName { get; set; }
        public IList<ListColumnDefinition> Columns { get; set; }
        public IList DataSource { get; set; }
    }

    public class ListColumnDefinition
    {
        public string Name { get; set; }
        public string MemberName { get; set; }
        public string Caption { get; set; }
        public int ColumnOrder { get; set; }
        public int ColumnWidth { get; set; }
        public ListColumnLookupDefinition Lookup { get; set; }
    }

    public class ListColumnLookupDefinition
    {
        public string DisplayExpression { get; set; }
        public string ValueExpression { get; set; }
        public IEnumerable DataSource { get; set; }
    }
}