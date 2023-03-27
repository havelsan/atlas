using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Infrastructure.Helpers
{
    //public enum ListBoxFieldTypeEnum
    //{
    //    TextBox = 0,
    //    CheckBox = 1,
    //    ComboBox = 2
    //}
    //public enum ListBoxCriteriaEnum
    //{
    //    Equals = 0,
    //    BeginsWith = 1,
    //    Contains = 2,
    //    NotEquals = 3
    //}
    //public class ListBoxConfig
    //{
    //    public IEnumerable<ListBoxField> Fields { get; set; }
    //    public IEnumerable<string> Columns { get; set; }
    //    public string PostUrl { get; set; }
    //    public string DisplayPath { get; set; }
    //}
    public class ListBoxField
    {
        public string FieldTag
        {
            get;
            set;
        }

        public string FieldLabel
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }

    public interface IListBoxBuilder
    {
        IListBoxBuilder AddField(string fieldTag, string fieldLabel);
        IListBoxBuilder AddColumn(string column);
        HtmlString Render(string displayExpression, string postUrl);
    }

    public class ListBoxBuilder : IListBoxBuilder
    {
        List<ListBoxField> Fields
        {
            get;
            set;
        }

        List<string> Columns
        {
            get;
            set;
        }

        TagBuilder _TagBuilder;
        string _Binding;
        string _Title;
        string _Param;
        string _DefitionName;
        private string JsonSerializeWithoutQuoteInNames(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                var writer = new JsonTextWriter(stringWriter);
                writer.QuoteName = false;
                new JsonSerializer().Serialize(writer, obj);
                return stringWriter.ToString().Replace("\"", "'");
            }
        }

        public ListBoxBuilder(TagBuilder builder, string binding, string title, string param, string definitionName)
        {
            _DefitionName = definitionName;
            _Title = title;
            _Param = param;
            _Binding = binding;
            _TagBuilder = builder;
            Columns = new List<string>();
            Fields = new List<ListBoxField>();
        }

        public IListBoxBuilder AddColumn(string column)
        {
            if (String.IsNullOrWhiteSpace(column))
            {
                throw new ArgumentNullException("column");
            }

            Columns.Add(column);
            return this;
        }

        public IListBoxBuilder AddField(string tag, string fieldLabel)
        {
            if (String.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException("tag");
            }

            Fields.Add(new ListBoxField()
            { FieldTag = tag, FieldLabel = fieldLabel });
            return this;
        }

        public HtmlString Render(string displayExpression, string postUrl)
        {
            //ListBoxConfig cfg = new ListBoxConfig()
            //{
            //    Columns = this.Columns,
            //    Fields = this.Fields,
            //    PostUrl = postUrl,
            //    DisplayPath = displayExpression
            //};
            //_TagBuilder.MergeAttribute("[Config]", JsonSerializeWithoutQuoteInNames(cfg));
            _TagBuilder.MergeAttribute("[(SelectedObject)]", "Model." + _Binding);
            _TagBuilder.MergeAttribute("(SelectedObjectChange)", _Param + "($event)");
            _TagBuilder.MergeAttribute("DialogTitle", _Title);
            _TagBuilder.MergeAttribute("DefinitionName", _DefitionName);
            return new HtmlString(_TagBuilder.ToString());
        }
    }
}