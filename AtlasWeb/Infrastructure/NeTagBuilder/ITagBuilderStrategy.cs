using Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Infrastructure.NeTagBuilder
{
    public interface ITagBuilderStrategy
    {
        List<ValidationAttribute> ModelPropertyAttributes
        {
            get;
            set;
        }

        HtmlString Date(IHtmlHelper htmlHelper, ModelMetadata metadata, string onChange, string name, object value, string format, string displayFormat, bool required, string disabled = null, string visible = null, int tabIndex = 0, IDictionary<string, object> htmlAttributes = null);
        HtmlString Input(IHtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata, string name, object value, string onChanged, IDictionary<string, object> htmlAttributes);
        HtmlString MaskInput(IHtmlHelper htmlHelper, string name, string onChanged, string mask, bool reqired = false, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString RichInput(IHtmlHelper htmlHelper, string name, string onChanged, string disabled = null);
        HtmlString AutocompleteInput(IHtmlHelper htmlHelper, string name, string dataSource, string displayExpr, string valueExpr, string placeholder, string valueChanged, string itemTemplate = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString GridInput(IHtmlHelper htmlHelper, string name, string[] columns, string dataSource, string paging, bool pager, bool filterRow, bool groupPanel, string onSelectionChanged, string onRowClick = null, string onRowInserted = null, string onRowRemoved = null, string onRowUpdated = null, bool editable = false, bool allRowEditable = false, bool formEdit = false, bool selection = false, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString TextBoxFor(IHtmlHelper htmlHelper, string name, bool required = false, string valueChanged = null, bool isPassword = false, HorizontalAlignment alignment = HorizontalAlignment.Right, bool multiLine = false, bool enableTurkishChars = true, CharacterCasing casing = CharacterCasing.Normal, InputFormat inputFormat = InputFormat.Normal, string visibilityBinding = null, string enabledBinding = null, string disabled = null, int tabIndex = 0);
        NeScheduler Scheduler(IHtmlHelper htmlHelper, string name, string height, string dataSource, int startDayHour, int endDayHour, string currentView, DateTime currentDate, IDictionary<string, object> htmlAttributes, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString RadioButton(IHtmlHelper htmlHelper, ModelMetadata metadata, string name, string selectedValueField, string displayValueField, string dataSourceBinding, string valueChanged, string disabled = null, string visible = null, int tabIndex = 0, IDictionary<string, object> htmlAttributes = null);
        HtmlString RadioButton(IHtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<SelectListItem> dataSource, string valueChanged, string disabled = null, string visible = null, int tabIndex = 0, IDictionary<string, object> htmlAttributes = null);
        HtmlString Select(IHtmlHelper htmlHelper, string name, string itemsBinding, string valueBinding, string textBinding, bool allowMultiple, string eventName = null, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString Select(IHtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, string placeHolder, string eventName = null, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString Select(IHtmlHelper htmlHelper, string optionLabel, string name, string valueField, string displayField, string dataSourceBinding, bool allowMultiple, string eventName = null, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString CheckBox(IHtmlHelper htmlHelper, string name, string valueChanged, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString SwitchBox(IHtmlHelper htmlHelper, string name, string valueChanged, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        NePopup Popup(IHtmlHelper htmlHelper, string title, string visibilityBinding, string onShowing, string onHiding);
        NePanel Panel(IHtmlHelper htmlHelper, PanelTypeEnum panelType, string header, string body, string footer, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString NumberInput(IHtmlHelper htmlHelper, string name, string onChanged, int min, int max, bool showSpinButtons, int step, bool required = false, string disabled = null, string visible = null, int tabIndex = 0);
        NeTabPanel TabPanel(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        NeTabs Tabs(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        NeAccordion Accordion(IHtmlHelper htmlHelper, string name, string width, string height, string dataSource, IDictionary<string, object> htmlAttributes = null, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString Button(IHtmlHelper htmlHelper, string text, string onClicked, IDictionary<string, string> extraAttributes, string disabled = null, string visible = null, int tabIndex = 0);
        HtmlString SubComponent(IHtmlHelper htmlHelper, string tagName, string modelBinding, IDictionary<string, string> extraBindings);
        HtmlString IndicatorInput(string onChanged, string visible);
        HtmlString TreeView(IHtmlHelper htmlHelper, string idExpression, string parentIdExpression, string displayExpression, string hasItemsExpression, string selectedObjectPath, string onSelectionChanged, string postUrl, string extraParametersPath);
    }
}