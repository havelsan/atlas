using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Infrastructure.Helpers
{
    public enum GridColumnTypeEnum
    {
        TextBox,
        DateTime,
        ComboBox,
        CheckBox,
        EnumComboBox,
        Button,
        Image,
        ListBox,
        TagCustom,
        Custom
    }

    public class GridColumn
    {
        public GridColumnTypeEnum Type
        {
            get;
            set;
        }

        public string Binding
        {
            get;
            set;
        }

        public string Caption
        {
            get;
            set;
        }

        public IList Items
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public string CssClass
        {
            get;
            set;
        }

        public string displayExpr
        {
            get;
            set;
        }

        public string valueExpr
        {
            get;
            set;
        }

        public string Function
        {
            get;
            set;
        }

        public string Tag
        {
            get;
            set;
        }

        public string TemplateName
        {
            get;
            set;
        }

        public string HtmlString
        {
            get;
            set;
        }

        public bool AllowSorting
        {
            get;
            set;
        }
    }

    public class GridHelper
    {
        bool CustomColumn = false;
        TagBuilder _Builder;
        string _DataSource;
        List<GridColumn> _Columns;
        public GridHelper(TagBuilder builder, string dataSource)
        {
            _Columns = new List<GridColumn>();
            this._Builder = builder;
            this._DataSource = dataSource;
        }

        public GridHelper onSelectionChanged(string onSelectionChanged)
        {
            _Builder.MergeAttribute("(onSelectionChanged)", onSelectionChanged);
            return this;
        }

        public GridHelper onRowClick(string onRowClick)
        {
            _Builder.MergeAttribute("(onRowClick)", onRowClick);
            return this;
        }

        public GridHelper visibleChange(string visibleChange)
        {
            _Builder.MergeAttribute("(visibleChange)", visibleChange);
            return this;
        }

        public GridHelper columnsChange(string columnsChange)
        {
            _Builder.MergeAttribute("(columnsChange)", columnsChange);
            return this;
        }

        public GridHelper editingChange(string editingChange)
        {
            _Builder.MergeAttribute("(editingChange)", editingChange);
            return this;
        }

        public GridHelper dataSourceChange(string dataSourceChange)
        {
            _Builder.MergeAttribute("(dataSourceChange)", dataSourceChange);
            return this;
        }

        public GridHelper groupingChange(string groupingChange)
        {
            _Builder.MergeAttribute("(groupingChange)", groupingChange);
            return this;
        }

        public GridHelper onRowInserted(string onRowInserted)
        {
            _Builder.MergeAttribute("(onRowInserted)", onRowInserted);
            return this;
        }

        public GridHelper onRowPrepared(string onRowPrepared)
        {
            _Builder.MergeAttribute("(onRowPrepared)", onRowPrepared);
            return this;
        }

        public GridHelper onRowRemoved(string onRowRemoved)
        {
            _Builder.MergeAttribute("(onRowRemoved)", onRowRemoved);
            return this;
        }

        public GridHelper onRowUpdated(string onRowUpdated)
        {
            _Builder.MergeAttribute("(onRowUpdated)", onRowUpdated);
            return this;
        }

        public GridHelper Disabled(string disabled)
        {
            _Builder.MergeAttribute("[Disabled]", disabled);
            return this;
        }

        public GridHelper Visible(string visible)
        {
            _Builder.MergeAttribute("[visible]", visible);
            return this;
        }

        public GridHelper TabIndex(int tabIndex)
        {
            _Builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            return this;
        }

        public GridHelper Paging(int paging)
        {
            _Builder.MergeAttribute("[paging]", "{pageSize:" + paging + "}");
            return this;
        }

        public GridHelper Pager()
        {
            _Builder.MergeAttribute("[pager]", "{showInfo: true}");
            return this;
        }

        public GridHelper setColums(string colums)
        {
            _Builder.MergeAttribute("[columns]", colums);
            CustomColumn = true;
            return this;
        }

        public GridHelper FilterRow()
        {
            _Builder.MergeAttribute("[filterRow]", "{visible: true}");
            return this;
        }

        public GridHelper GroupPanel()
        {
            _Builder.MergeAttribute("[groupPanel]", "{visible: true}");
            return this;
        }

        public GridHelper FormEdit(bool editEnabled, bool insertEnabled, bool removeEnabled)
        {
            _Builder.MergeAttribute("[editing]", "{mode: 'form' ,editEnabled: " + editEnabled.ToString().ToLower() + ",insertEnabled: " + insertEnabled.ToString().ToLower() + ",removeEnabled: " + removeEnabled.ToString().ToLower() + "}");
            return this;
        }

        public GridHelper AllRowEdit(bool editEnabled, bool insertEnabled, bool removeEnabled)
        {
            _Builder.MergeAttribute("[editing]", "{mode: 'batch' ,editEnabled: " + editEnabled.ToString().ToLower() + ",insertEnabled: " + insertEnabled.ToString().ToLower() + ",removeEnabled: " + removeEnabled.ToString().ToLower() + "}");
            return this;
        }

        public GridHelper RowEdit(bool editEnabled, bool insertEnabled, bool removeEnabled)
        {
            _Builder.MergeAttribute("[editing]", "{mode: 'row' ,editEnabled: " + editEnabled.ToString().ToLower() + ",insertEnabled: " + insertEnabled.ToString().ToLower() + ",removeEnabled: " + removeEnabled.ToString().ToLower() + "}");
            return this;
        }

        public GridHelper CellEdit(bool editEnabled, bool insertEnabled, bool removeEnabled)
        {
            _Builder.MergeAttribute("[editing]", "{mode: 'cell' ,editEnabled: " + editEnabled.ToString().ToLower() + ",insertEnabled: " + insertEnabled.ToString().ToLower() + ",removeEnabled: " + removeEnabled.ToString().ToLower() + "}");
            return this;
        }

        public GridHelper Selection(string mode, bool allowSelectAll)
        {
            _Builder.MergeAttribute("[selection]", "{mode: '" + mode + "',allowSelectAll:" + allowSelectAll.ToString().ToLower() + "}");
            return this;
        }

        public GridHelper AddTextBoxColumn(string caption, string binding, int width, bool allowSorting, string cssClass = null)
        {
            if (CustomColumn)
            {
                throw new ArgumentNullException(TTUtils.CultureService.GetText("M25374", "Custom kolon yaptığınızda, kolon ekleyemezsiniz."));
            }

            _Columns.Add(new GridColumn()
            {AllowSorting = allowSorting, CssClass = cssClass, Caption = caption, Binding = binding, Type = GridColumnTypeEnum.TextBox, Width = width});
            return this;
        }

        public GridHelper AddDateTimeColumn(string caption, string binding, int width, string templateName, bool allowSorting, HtmlString dateTime, string cssClass = null)
        {
            AddCustomColumn(caption, binding, width, templateName, allowSorting, dateTime, cssClass);
            return this;
        }

        public GridHelper AddCheckBoxColumn(string caption, string binding, int width, string templateName, bool allowSorting, HtmlString checkBox, string cssClass = null)
        {
            AddCustomColumn(caption, binding, width, templateName, allowSorting, checkBox, cssClass);
            return this;
        }

        // Template Columns...
        public GridHelper AddTagCustomColumn(string caption, string binding, int width, string tag, bool allowSorting, string templateName)
        {
            _Columns.Add(new GridColumn()
            {AllowSorting = allowSorting, Caption = caption, Binding = binding, Type = GridColumnTypeEnum.TagCustom, Width = width, Tag = tag, TemplateName = templateName});
            return this;
        }

        public GridHelper AddEnumComboBoxColumn(string caption, string binding, Type enumType, int width, string cssClass = null)
        {
            if (CustomColumn)
            {
                throw new ArgumentNullException(TTUtils.CultureService.GetText("M25374", "Custom kolon yaptığınızda, kolon ekleyemezsiniz."));
            }

            _Columns.Add(new GridColumn()
            {CssClass = cssClass, Caption = caption, Binding = binding, Type = GridColumnTypeEnum.EnumComboBox, Width = width});
            return this;
        }

        public GridHelper AddImageColumn(string caption, string binding, int width, bool allowSorting, string templateName, string cssClass = null)
        {
            if (CustomColumn)
            {
                throw new ArgumentNullException(TTUtils.CultureService.GetText("M25374", "Custom kolon yaptığınızda, kolon ekleyemezsiniz."));
            }

            _Columns.Add(new GridColumn()
            {CssClass = cssClass, AllowSorting = allowSorting, Caption = caption, Binding = binding, Type = GridColumnTypeEnum.Image, Width = width, TemplateName = templateName});
            return this;
        }

        public GridHelper AddListBoxColumn(string caption, string binding, int width, bool allowSorting, string templateName, HtmlString listBox, string cssClass = null)
        {
            _Columns.Add(new GridColumn()
            {AllowSorting = allowSorting, CssClass = cssClass, HtmlString = listBox.ToString(), Caption = caption, Binding = binding, Type = GridColumnTypeEnum.ListBox, Width = width, TemplateName = templateName});
            return this;
        }

        public GridHelper AddButtonColumn(string caption, string binding, int width, bool allowSorting, string templateName, HtmlString button, string cssClass = null)
        {
            _Columns.Add(new GridColumn()
            {AllowSorting = allowSorting, CssClass = cssClass, HtmlString = button.ToString(), Caption = caption, Binding = binding, Type = GridColumnTypeEnum.Button, Width = width, TemplateName = templateName});
            return this;
        }

        public GridHelper AddEnumComboBoxColumn(string caption, string binding, int width, bool allowSorting, string templateName, HtmlString enumComboBox, string cssClass = null)
        {
            _Columns.Add(new GridColumn()
            {AllowSorting = allowSorting, CssClass = cssClass, HtmlString = enumComboBox.ToString(), Caption = caption, Binding = binding, Type = GridColumnTypeEnum.EnumComboBox, Width = width, TemplateName = templateName});
            return this;
        }

        public GridHelper AddCustomColumn(string caption, string binding, int width, string templateName, bool allowSorting, HtmlString customComponent, string cssClass = null)
        {
            _Columns.Add(new GridColumn()
            {AllowSorting = allowSorting, CssClass = cssClass, HtmlString = customComponent.ToString(), Caption = caption, Binding = binding, Type = GridColumnTypeEnum.Custom, Width = width, TemplateName = templateName});
            return this;
        }

        public HtmlString Render()
        {
            string columnsString = "[";
            string customColumnTemplate = "";
            for (int i = 0; i < _Columns.Count; i++)
            {
                if (i == _Columns.Count - 1)
                {
                    if (_Columns[i].Type == GridColumnTypeEnum.TextBox)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + "}";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.TagCustom)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'}";
                        customColumnTemplate += "<div *dxTemplate=\"let t = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += "<" + _Columns[i].Tag + ">{{" + _Columns[i].Binding + "}}</" + _Columns[i].Tag + ">";
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.Image)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'}";
                        customColumnTemplate += "<div *dxTemplate=\"let t = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += " <img ng-src=\"{{" + _Columns[i].Binding + "}}\"/>";
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.ListBox)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'}";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.EnumComboBox)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'}";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.Button)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'}";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.Custom)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'}";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }
                }
                else
                {
                    if (_Columns[i].Type == GridColumnTypeEnum.TextBox)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + "},";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.TagCustom)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'},";
                        customColumnTemplate += "<div *dxTemplate=\"let t = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += "<" + _Columns[i].Tag + ">{{" + _Columns[i].Binding + "}}</" + _Columns[i].Tag + ">";
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.Image)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'},";
                        customColumnTemplate += "<div *dxTemplate=\"let t = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += " <img ng-src=\"{{" + _Columns[i].Binding + "}}\"/>";
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.ListBox)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'},";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.EnumComboBox)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'},";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.Button)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'},";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }

                    if (_Columns[i].Type == GridColumnTypeEnum.Custom)
                    {
                        columnsString += "{dataField: '" + _Columns[i].Binding + "',caption: '" + _Columns[i].Caption + "',width: " + _Columns[i].Width + ",cssClass: '" + _Columns[i].CssClass + "',allowSorting: " + _Columns[i].AllowSorting.ToString().ToLower() + ",cellTemplate:'" + _Columns[i].TemplateName + "'},";
                        customColumnTemplate += "<div *dxTemplate=\"let Model = data of '" + _Columns[i].TemplateName + "'\">";
                        customColumnTemplate += _Columns[i].HtmlString;
                        customColumnTemplate += "</div>";
                    }
                }
            }

            _Builder.MergeAttribute("[dataSource]", this._DataSource);
            _Builder.MergeAttribute("[columns]", columnsString + "]");
            _Builder.SetInnerHtml(customColumnTemplate);
            return new HtmlString(_Builder.ToString());
        }
    }
}