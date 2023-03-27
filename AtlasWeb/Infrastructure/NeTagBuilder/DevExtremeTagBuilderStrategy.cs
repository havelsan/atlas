using Infrastructure.Enums;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Infrastructure.NeTagBuilder
{
    [NeTagBuilderStrategyData("DevExtreme", IsDefault = false)]
    public class DevExtremeTagBuilderStrategy : ITagBuilderStrategy
    {
        const string _ModelPrefix = "Model.";
        public List<ValidationAttribute> ModelPropertyAttributes
        {
            get;
            set;
        }

        public static string JsonSerializeWithoutQuoteInNames(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                var writer = new JsonTextWriter(stringWriter);
                writer.QuoteName = false;
                new JsonSerializer().Serialize(writer, obj);
                return stringWriter.ToString().Replace("\"", "'");
            }
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        TagBuilder GetBaseRadioButton(IHtmlHelper htmlHelper, string name, string selectedValueField, string displayValueField, string valueChanged, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBindingName))
            {
                throw new ArgumentNullException("name");
            }

            var tagBuilder = new TagBuilder("dx-radio-group");
            string selectedValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(selectedValueField);
            if (!String.IsNullOrWhiteSpace(selectedValueBindingName))
            {
                tagBuilder.MergeAttribute("valueExpr", selectedValueBindingName);
            }

            string displayValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(displayValueField);
            if (!String.IsNullOrWhiteSpace(displayValueBindingName))
            {
                tagBuilder.MergeAttribute("displayExpr", displayValueBindingName);
            }

            tagBuilder.MergeAttribute("[(value)]", _ModelPrefix + nameBindingName);
            if (!String.IsNullOrWhiteSpace(disabled))
            {
                tagBuilder.MergeAttribute("[disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                tagBuilder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                tagBuilder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (!String.IsNullOrWhiteSpace(valueChanged))
            {
                tagBuilder.MergeAttribute("(onValueChanged)", valueChanged);
            }

            return tagBuilder;
        }

        TagBuilder GetBaseSelect(IHtmlHelper htmlHelper, string name, string valueField, string displayField, bool allowMultiple, string placeHolder, string selectedItemChange = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            string fullDisplayBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(displayField);
            if (string.IsNullOrEmpty(fullDisplayBindingName))
            {
                throw new ArgumentNullException("displayValue");
            }

            string fullItemsValueFieldBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(valueField);
            if (string.IsNullOrEmpty(fullItemsValueFieldBindingName))
            {
                throw new ArgumentNullException("valueField");
            }

            TagBuilder builder = null;
            if (allowMultiple)
            {
                builder = new TagBuilder("dx-tag-box");
                builder.MergeAttribute("[(value)]", _ModelPrefix + fullValueBindingName);
                builder.MergeAttribute("displayExpr", fullDisplayBindingName);
                builder.MergeAttribute("valueExpr", fullItemsValueFieldBindingName);
                builder.MergeAttribute("placeholder", placeHolder);
                //if (!String.IsNullOrWhiteSpace(eventName))
                //{
                //    builder.MergeAttribute("(onValueChanged)", MakeEvent(eventName));
                //}
            }
            else
            {
                builder = new TagBuilder("dx-select-box");
                builder.MergeAttribute("displayExpr", fullDisplayBindingName);
                builder.MergeAttribute("valueExpr", fullItemsValueFieldBindingName);
                builder.MergeAttribute("placeholder", placeHolder);
                builder.MergeAttribute("[(value)]", _ModelPrefix + fullValueBindingName);
                if (!String.IsNullOrWhiteSpace(selectedItemChange))
                {
                    builder.MergeAttribute("(selectedItemChange)", selectedItemChange);
                }
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            return builder;
        }

        public HtmlString Input(IHtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata, string name, object value, string onChanged, IDictionary<string, object> htmlAttributes)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = null;
            if (inputType == InputType.Radio || inputType == InputType.CheckBox)
            {
                throw new InvalidOperationException(TTUtils.CultureService.GetText("M26719", "radio button ve checkbox icin kendi helperlarını kullanınız"));
            }

            Action setup = () =>
            {
                builder.MergeAttribute("[(value)]", _ModelPrefix + name);
                if (!String.IsNullOrWhiteSpace(onChanged))
                {
                    builder.MergeAttribute("(onValueChanged)", onChanged);
                }
            }

            ;
            if (inputType == InputType.Password)
            {
                builder = new TagBuilder("dx-text-box");
                builder.MergeAttribute("mode", "password");
                setup();
            }
            else if (inputType == InputType.Hidden)
            {
                builder = new TagBuilder("input");
                builder.MergeAttribute("type", "hidden");
            }
            else if (inputType == InputType.Text)
            {
                builder = new TagBuilder("dx-text-box");
                setup();
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString MaskInput(IHtmlHelper htmlHelper, string name, string onChanged, string mask, bool reqired = false, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(mask))
            {
                throw new ArgumentNullException("Mask");
            }

            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = null;
            builder = new TagBuilder("hvl-masktext-box");
            builder.MergeAttribute("mask", mask);
            builder.MergeAttribute("[(Value)]", _ModelPrefix + name);
            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[Visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (!String.IsNullOrWhiteSpace(onChanged))
            {
                builder.MergeAttribute("(ValueChange)", onChanged);
            }

            if (reqired)
            {
                builder.MergeAttribute("Required", "true");
            }

            return new HtmlString(builder.ToHtmlString().Replace("<hvl-masktext-box", "<hvl-masktext-box #Validation"));
        }

        public HtmlString RichInput(IHtmlHelper htmlHelper, string name, string onChanged, string disabled = null)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("hvl-richtext-box");
            }

            TagBuilder builder = null;
            builder = new TagBuilder("hvl-richtext-box");
            builder.MergeAttribute("[(Value)]", _ModelPrefix + name);
            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(onChanged))
            {
                builder.MergeAttribute("(ValueChange)", onChanged);
            }

            return new HtmlString(builder.ToHtmlString().Replace("<hvl-richtext-box", "<hvl-richtext-box #Validation"));
        }

        public HtmlString AutocompleteInput(IHtmlHelper htmlHelper, string name, string dataSource, string displayExpr, string valueExpr, string placeholder, string valueChanged, string itemTemplate = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = null;
            builder = new TagBuilder("dx-autocomplete");
            builder.MergeAttribute("[(value)]", _ModelPrefix + name);
            if (!String.IsNullOrWhiteSpace(dataSource))
            {
                builder.MergeAttribute("[items]", dataSource);
            }

            if (!String.IsNullOrWhiteSpace(displayExpr))
            {
                builder.MergeAttribute("displayExpr", displayExpr);
            }

            if (!String.IsNullOrWhiteSpace(valueExpr))
            {
                builder.MergeAttribute("valueExpr", valueExpr);
            }

            if (!String.IsNullOrWhiteSpace(placeholder))
            {
                builder.MergeAttribute("placeholder", placeholder);
            }

            if (!String.IsNullOrWhiteSpace(itemTemplate))
            {
                builder.MergeAttribute("itemTemplate", itemTemplate);
            }

            if (!String.IsNullOrWhiteSpace(valueChanged))
            {
                builder.MergeAttribute("(onValueChanged)", valueChanged);
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString IndicatorInput(string onChanged, string visible = null)
        {
            TagBuilder builder = null;
            builder = new TagBuilder("dx-load-indicator");
            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (!String.IsNullOrWhiteSpace(onChanged))
            {
                builder.MergeAttribute("(visibleChange)", onChanged);
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString NumberInput(IHtmlHelper htmlHelper, string name, string onChanged, int min, int max, bool showSpinButtons, int step, bool required = false, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = null;
            builder = new TagBuilder("hvl-number-box");
            builder.MergeAttribute("[(Value)]", _ModelPrefix + name);
            if (min > 0)
            {
                builder.MergeAttribute("[min]", min.ToString());
            }

            if (max > 0)
            {
                builder.MergeAttribute("[max]", max.ToString());
            }

            if (step > 0)
            {
                builder.MergeAttribute("[step]", step.ToString());
            }

            if (showSpinButtons)
            {
                builder.MergeAttribute("[showSpinButtons]", "true");
            }

            if (required)
            {
                builder.MergeAttribute("Required", "true");
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[Visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (!String.IsNullOrWhiteSpace(onChanged))
            {
                builder.MergeAttribute("(ValueChange)", onChanged);
            }

            return new HtmlString(builder.ToHtmlString().Replace("<hvl-number-box", "<hvl-number-box #Validation"));
        }

        public HtmlString GridInput(IHtmlHelper htmlHelper, string name, string[] columns, string dataSource, string paging, bool pager, bool filterRow, bool groupPanel, string onSelectionChanged, string onRowClick = null, string onRowInserted = null, string onRowRemoved = null, string onRowUpdated = null, bool editable = false, bool allRowEditable = false, bool formEdit = false, bool selection = false, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = null;
            builder = new TagBuilder("dx-data-grid");
            //builder.MergeAttribute("[(value)]", _ModelPrefix + name);
            if (!String.IsNullOrWhiteSpace(onSelectionChanged))
            {
                builder.MergeAttribute("(onSelectionChanged)", onSelectionChanged);
            }

            if (!String.IsNullOrWhiteSpace(onRowClick))
            {
                builder.MergeAttribute("(onRowClick)", onRowClick);
            }

            if (!String.IsNullOrWhiteSpace(onRowInserted))
            {
                builder.MergeAttribute("(onRowInserted)", onRowInserted);
            }

            if (!String.IsNullOrWhiteSpace(onRowRemoved))
            {
                builder.MergeAttribute("(onRowRemoved)", onRowRemoved);
            }

            if (!String.IsNullOrWhiteSpace(onRowUpdated))
            {
                builder.MergeAttribute("(onRowUpdated)", onRowUpdated);
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (!String.IsNullOrWhiteSpace(dataSource))
            {
                builder.MergeAttribute("[dataSource]", dataSource);
            }

            if (!String.IsNullOrWhiteSpace(paging))
            {
                builder.MergeAttribute("[paging]", "{pageSize:" + paging + "}");
            }

            if (columns != null)
            {
                builder.MergeAttribute("[columns]", JsonSerializeWithoutQuoteInNames(columns));
            }

            if (pager)
            {
                builder.MergeAttribute("[pager]", "{showInfo: true}");
            }

            if (filterRow)
            {
                builder.MergeAttribute("[filterRow]", "{visible: true}");
            }

            if (groupPanel)
            {
                builder.MergeAttribute("[groupPanel]", "{visible: true}");
            }

            if (formEdit)
            {
                allRowEditable = false;
                editable = false;
                builder.MergeAttribute("[editing]", "{mode: 'form',allowUpdating: true}");
            }

            if (allRowEditable)
            {
                editable = false;
                builder.MergeAttribute("[editing]", "{mode: 'batch',allowUpdating: true}");
            }

            if (editable)
            {
                builder.MergeAttribute("[editing]", "{editEnabled: true,insertEnabled: true,removeEnabled: true}");
            }

            if (selection)
            {
                builder.MergeAttribute("[selection]", "{mode: 'multiple',allowSelectAll: false}");
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString TextBoxFor(IHtmlHelper htmlHelper, string name, bool required, string valueChanged, bool isPassword, HorizontalAlignment alignment = HorizontalAlignment.Right, bool multiLine = false, bool enableTurkishChars = true, CharacterCasing casing = CharacterCasing.Normal, InputFormat inputFormat = InputFormat.Normal, string visibilityBinding = null, string enabledBinding = null, string disabled = null, int tabIndex = 0)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = null;
            builder = new TagBuilder("hvl-text-box");
            builder.MergeAttribute("Casing", casing.ToString());
            builder.MergeAttribute("AlphaNumericOnly", (inputFormat == InputFormat.AlphaOnly).ToString().ToLower());
            builder.MergeAttribute("LatinOnly", (!enableTurkishChars).ToString().ToLower());
            builder.MergeAttribute("Required", required.ToString());
            builder.MergeAttribute("MultiLine", multiLine.ToString().ToLower());
            if (alignment == HorizontalAlignment.Left)
                builder.MergeAttribute("style", "text-align:left");
            if (alignment == HorizontalAlignment.Center)
                builder.MergeAttribute("style", "text-align:center");
            if (alignment == HorizontalAlignment.Right)
                builder.MergeAttribute("style", "text-align:right");
            builder.MergeAttribute("[(Text)]", _ModelPrefix + name);
            builder.MergeAttribute("name", _ModelPrefix + name);
            if (!String.IsNullOrWhiteSpace(valueChanged))
            {
                builder.MergeAttribute("(TextChange)", valueChanged);
            }

            if (!String.IsNullOrWhiteSpace(visibilityBinding))
            {
                builder.MergeAttribute("[Visible]", visibilityBinding);
            }

            var validations = Util.GetValidationConfigs(this.ModelPropertyAttributes);
            if (validations != null && validations.Count > 0)
            {
                builder.MergeAttribute("[ValidationConfiguration]", JsonSerializeWithoutQuoteInNames(validations));
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled.ToString());
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (isPassword)
            {
                builder.MergeAttribute("Mode", "password");
            }

            return new HtmlString(builder.ToHtmlString().Replace("<hvl-text-box", "<hvl-text-box #Validation"));
        }

        public HtmlString Lookup(IHtmlHelper htmlHelper, ModelMetadata metadata, string name, object value, IDictionary<string, object> htmlAttributes)
        {
            throw new NotImplementedException();
        }

        public HtmlString Select(IHtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, string placeHolder, string eventName = null, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            TagBuilder builder = GetBaseSelect(htmlHelper, name, "Value", "Text", allowMultiple, placeHolder, eventName, disabled, visible, tabIndex);
            builder.MergeAttribute("[dataSource]", JsonSerializeWithoutQuoteInNames(selectList));
            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString Select(IHtmlHelper htmlHelper, string name, string itemsBinding, string valueBinding, string textBinding, bool allowMultiple, string eventName = null, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            TagBuilder builder = GetBaseSelect(htmlHelper, name, valueBinding, textBinding, allowMultiple, null, eventName, disabled, visible, tabIndex);
            builder.MergeAttribute("[dataSource]", itemsBinding);
            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString Select(IHtmlHelper htmlHelper, string optionLabel, string name, string valueField, string displayField, string dataSourceBinding, bool allowMultiple, string eventName = null, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string fullDataSourceBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(dataSourceBinding);
            if (String.IsNullOrWhiteSpace(dataSourceBinding))
            {
                throw new ArgumentNullException("dataSourceBinding");
            }

            TagBuilder builder = GetBaseSelect(htmlHelper, name, valueField, displayField, allowMultiple, null, eventName, disabled, visible, tabIndex);
            builder.MergeAttribute("[dataSource]", fullDataSourceBindingName);
            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString Date(IHtmlHelper htmlHelper, ModelMetadata metadata, string onChange, string name, object value, string format, string displayFormat, bool required, string disabled = null, string visible = null, int tabIndex = 0, IDictionary<string, object> htmlAttributes = null)
        {
            string fullValueBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullValueBindingName))
            {
                throw new ArgumentNullException("valueBinding");
            } //

            TagBuilder tagBuilder = new TagBuilder("hvl-date-picker");
            tagBuilder.MergeAttribute("[(Value)]", _ModelPrefix + fullValueBindingName);
            if (!String.IsNullOrWhiteSpace(format))
            {
                tagBuilder.MergeAttribute("format", format);
            }

            if (!String.IsNullOrWhiteSpace(displayFormat))
            {
                tagBuilder.MergeAttribute("displayFormat", displayFormat);
            }

            if (!String.IsNullOrWhiteSpace(onChange))
            {
                tagBuilder.MergeAttribute("(ValueChange)", onChange);
            }

            tagBuilder.MergeAttribute("Required", required.ToString());
            if (!String.IsNullOrWhiteSpace(disabled))
            {
                tagBuilder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                tagBuilder.MergeAttribute("[Visible]", visible);
            }

            if (tabIndex > 0)
            {
                tagBuilder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            //var tagBuilder = GetBaseDatePicker(htmlHelper, onChange, name, format, displayFormat, disabled, visible, tabIndex);
            return new HtmlString(tagBuilder.ToHtmlString().Replace("<hvl-date-picker", "<hvl-date-picker #Validation"));
        }

        public HtmlString RadioButton(IHtmlHelper htmlHelper, ModelMetadata metadata, string name, string selectedValueField, string displayValueField, string dataSourceBinding, string valueChanged, string disabled = null, string visible = null, int tabIndex = 0, IDictionary<string, object> htmlAttributes = null)
        {
            string dataSourceBindingName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(dataSourceBinding);
            if (String.IsNullOrWhiteSpace(dataSourceBindingName))
            {
                throw new ArgumentNullException("dataSourceBinding");
            }

            var tagBuilder = GetBaseRadioButton(htmlHelper, name, selectedValueField, displayValueField, valueChanged, disabled, visible, tabIndex);
            tagBuilder.MergeAttribute("[items]", dataSourceBindingName);
            return new HtmlString(tagBuilder.ToString());
        }

        public HtmlString RadioButton(IHtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> dataSource, string valueChanged, string disabled = null, string visible = null, int tabIndex = 0, IDictionary<string, object> htmlAttributes = null)
        {
            if (dataSource == null || dataSource.Count() == 0)
            {
                throw new InvalidOperationException("datasource can not be empty");
            }

            var tagBuilder = GetBaseRadioButton(htmlHelper, name, "Value", "Text", valueChanged, disabled, visible, tabIndex);
            tagBuilder.MergeAttribute("[items]", JsonConvert.SerializeObject(dataSource));
            return new HtmlString(tagBuilder.ToString());
        }

        public HtmlString CheckBox(IHtmlHelper htmlHelper, string name, string valueChanged, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBinding = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBinding))
            {
                throw new ArgumentNullException(nameBinding);
            }

            TagBuilder builder = new TagBuilder("dx-check-box");
            builder.MergeAttribute("[(value)]", _ModelPrefix + nameBinding);
            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (!String.IsNullOrWhiteSpace(valueChanged))
            {
                builder.MergeAttribute("(onValueChanged)", valueChanged);
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString SwitchBox(IHtmlHelper htmlHelper, string name, string valueChanged, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBinding = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBinding))
            {
                throw new ArgumentNullException(nameBinding);
            }

            TagBuilder builder = new TagBuilder("dx-switch");
            builder.MergeAttribute("[(value)]", _ModelPrefix + nameBinding);
            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            if (!String.IsNullOrWhiteSpace(valueChanged))
            {
                builder.MergeAttribute("(onValueChanged)", valueChanged);
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public NePopup Popup(IHtmlHelper htmlHelper, string title, string visibilityBinding, string onShowing, string onHiding)
        {
            TagBuilder builder = new TagBuilder("dx-popup");
            if (String.IsNullOrWhiteSpace(visibilityBinding))
            {
                throw new ArgumentNullException("visibilityBinding");
            }

            if (!String.IsNullOrWhiteSpace(title))
            {
                builder.MergeAttribute("title", title);
            }

            Action<TextWriter> onBegin = (startWriter) => //{2} {3},
            //!String.IsNullOrWhiteSpace(onShowing) ? "(onShowing)=" + onShowing : "", !String.IsNullOrWhiteSpace(onHiding) ? "(onHiding)=" + onHiding : "")
            {
                startWriter.WriteLine(string.Format("<dx-popup title=\"{0}\" [(visible)]=\"{1}\"  ><div *dxTemplate=\"let t = data of 'contentTemplate'\">", title, visibilityBinding));
            }

            ;
            Action<TextWriter> onEnd = (endWriter) =>
            {
                endWriter.WriteLine(string.Format("</div></dx-popup>"));
            }

            ;
            return new NePopup(htmlHelper.ViewContext, visibilityBinding, onBegin, onEnd);
        }

        public NePanel Panel(IHtmlHelper htmlHelper, PanelTypeEnum panelType, string header, string body, string footer, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            return new NePanel(htmlHelper, panelType, header, body, footer);
        }

        public NeTabPanel TabPanel(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBinding = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBinding))
            {
                throw new ArgumentNullException(nameBinding);
            }

            return new NeTabPanel(htmlHelper, name, width, height, dataSource, disabled, visible, tabIndex);
        }

        public NeTabs Tabs(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBinding = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBinding))
            {
                throw new ArgumentNullException(nameBinding);
            }

            return new NeTabs(htmlHelper, name, width, height, dataSource, disabled, visible, tabIndex);
        }

        public NeScheduler Scheduler(IHtmlHelper htmlHelper, string name, string height, string dataSource, int startDayHour, int endDayHour, string currentView, DateTime currentDate, IDictionary<string, object> htmlAttributes, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBinding = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBinding))
            {
                throw new ArgumentNullException(nameBinding);
            }

            return new NeScheduler(htmlHelper, name, height, dataSource, startDayHour, endDayHour, currentView, currentDate);
        }

        public NeAccordion Accordion(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0)
        {
            string nameBinding = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrWhiteSpace(nameBinding))
            {
                throw new ArgumentNullException(nameBinding);
            }

            return new NeAccordion(htmlHelper, name, width, height, dataSource, disabled, visible, tabIndex);
        }

        public HtmlString Button(IHtmlHelper htmlHelper, string text, string onClicked, IDictionary<string, string> extraAttributes, string disabled = null, string visible = null, int tabIndex = 0)
        {
            TagBuilder builder = new TagBuilder("dx-button");
            if (String.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException("text");
            }

            if (String.IsNullOrWhiteSpace(onClicked))
            {
                throw new ArgumentNullException("onClicked");
            }

            if (!String.IsNullOrWhiteSpace(disabled))
            {
                builder.MergeAttribute("[Disabled]", disabled);
            }

            if (!String.IsNullOrWhiteSpace(visible))
            {
                builder.MergeAttribute("[visible]", visible);
            }

            if (tabIndex > 0)
            {
                builder.MergeAttribute("[tabIndex]", tabIndex.ToString());
            }

            builder.MergeAttribute("text", text);
            builder.MergeAttribute("(onClick)", onClicked);
            if (extraAttributes != null)
            {
                foreach (KeyValuePair<string, string> kp in extraAttributes)
                {
                    builder.MergeAttribute(kp.Key, kp.Value);
                }
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString SubComponent(IHtmlHelper htmlHelper, string tagName, string modelBinding, IDictionary<string, string> extraBindings)
        {
            if (String.IsNullOrWhiteSpace(tagName))
            {
                throw new ArgumentNullException("tagName");
            }

            if (String.IsNullOrWhiteSpace(modelBinding))
            {
                throw new ArgumentNullException("modelBinding");
            }

            TagBuilder builder = new TagBuilder(tagName);
            builder.MergeAttribute("[(Model)]", _ModelPrefix + modelBinding);
            foreach (var pair in extraBindings)
            {
                builder.MergeAttribute(pair.Key, pair.Value);
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString ListBoxFor(IHtmlHelper htmlHelper, string name, string dialogContentUrl, IEnumerable<string> dialogDirectives)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            TagBuilder builder = new TagBuilder("hvl-list-box");
            builder.MergeAttribute("[(SelectedObject)]", _ModelPrefix + name);
            builder.MergeAttribute("ContentUrl", dialogContentUrl);
            if (dialogDirectives != null && dialogDirectives.Count() > 0)
            {
                builder.MergeAttribute("[ContentDirectives]", JsonConvert.SerializeObject(dialogDirectives));
            }

            return new HtmlString(builder.ToHtmlString());
        }

        public HtmlString TreeView(IHtmlHelper htmlHelper, string idExpression, string parentIdExpression, string displayExpression, string hasItemsExpression, string selectedObjectPath, string onSelectionChanged, string postUrl, string extraParametersPath)
        {
            if (String.IsNullOrWhiteSpace(idExpression) || String.IsNullOrWhiteSpace(parentIdExpression) || String.IsNullOrWhiteSpace(displayExpression) || String.IsNullOrWhiteSpace(hasItemsExpression) || String.IsNullOrWhiteSpace(selectedObjectPath) || String.IsNullOrWhiteSpace(postUrl))
            {
                throw new ArgumentNullException("idExpression,parentIdExpression,displayExpression,hasItemsExpression,selectedObjectPath,postUrl parametreleri girilmelidir");
            }

            TagBuilder builder = new TagBuilder("hvl-tree-view");
            builder.MergeAttribute("IdExpression", idExpression);
            builder.MergeAttribute("ParentIdExpression", parentIdExpression);
            builder.MergeAttribute("DisplayExpression", displayExpression);
            builder.MergeAttribute("HasItemsExpression", hasItemsExpression);
            builder.MergeAttribute("[(SelectedObject)]", _ModelPrefix + selectedObjectPath);
            builder.MergeAttribute("PostUrl", postUrl);
            if (!String.IsNullOrWhiteSpace(onSelectionChanged))
                builder.MergeAttribute("(SelectedObjectChange)", onSelectionChanged);
            if (!String.IsNullOrWhiteSpace(extraParametersPath))
                builder.MergeAttribute("[Parameters]", extraParametersPath);
            return new HtmlString(builder.ToHtmlString());
        }
    }
}