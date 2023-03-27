using Infrastructure.Filters;
using Core.Models;
using Core.Services;
using System.Collections.Generic;

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using TTObjectClasses;
using TTInstanceManagement;
using System;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class EditorTemplateController : Controller
    {
        private readonly EditorTemplateService _editorTemplateService;
        public EditorTemplateController(EditorTemplateService editorTemplateService)
        {
            _editorTemplateService = editorTemplateService;
        }

        public class GetEditorTemplatesInput
        {
            public string TemplateGroupName { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public IEnumerable<EditorTemplateModel> GetEditorTemplates(GetEditorTemplatesInput input)
        {
            return _editorTemplateService.GetEditorTemplates(input.TemplateGroupName);
        }

        public class SaveEditorTemplateInput
        {
            public string GroupName { get; set; }
            public string MenuCaption { get; set; }
            public string Description { get; set; }
            public string Content { get; set; }
        }
        public class UpdateEditorTemplateInput
        {
            public string GroupName { get; set; }
            public string MenuCaption { get; set; }
            public string Description { get; set; }
            public string Content { get; set; }
            public Guid ObjectID { get; set; }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EditorTemplateModel SaveEditorTemplate(SaveEditorTemplateInput input)
        {
            var result = _editorTemplateService.SaveEditorTemplate(input.MenuCaption, input.Description, input.GroupName, input.Content);
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public EditorTemplateModel UpdateEditorTemplate(UpdateEditorTemplateInput input)
        {
            var result = _editorTemplateService.UpdateEditorTemplate(input.MenuCaption, input.Description, input.GroupName, input.Content, input.ObjectID);
            return result;
        }
        [HttpGet]
        public bool SetEnableDisable(string objectID, bool enable)
        {
            using (TTObjectContext _context = new TTObjectContext(false))
            {
                var dashboard = _context.QueryObjects<TTObjectClasses.BaseTemplate>("ObjectID = '" + objectID + "'").FirstOrDefault();
                dashboard.Enabled = enable;
                _context.Save();
            }
            return true;
        }
    }
}