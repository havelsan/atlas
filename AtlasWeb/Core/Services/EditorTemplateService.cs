using Infrastructure.Constants;
using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;

namespace Core.Services
{
    [HvlResult]
    public class EditorTemplateService
    {
        private IEnumerable<EditorTemplateModel> GetTemplateList(string contentType, string templateGroupName)
        {
            var templates = new List<EditorTemplateModel>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<BaseTemplate> templateList = new BindingList<BaseTemplate>();
                if (!string.IsNullOrWhiteSpace(templateGroupName))
                {
                    //templateList = BaseTemplate.GetUserTemplates(objectContext, templateGroupName, Common.CurrentResource.ObjectID.ToString());

                    var templateGroupID = objectContext.QueryObjects<TemplateGroup>("GroupName='" + templateGroupName + "'").FirstOrDefault();

                    if (templateGroupID == null)
                    {
                        return templates;
                    }
                    var rtfTemplates = objectContext.QueryObjects<RTFTemplate>($"RESUSER='{Common.CurrentResource.ObjectID.ToString()}' and TemplateGroup='" + templateGroupID.ObjectID + "' and Enabled = 1");
                    foreach (var rtfTemplate in rtfTemplates)
                    {
                        templateList.Add(rtfTemplate);
                    }
                }
                else
                {
                    templateList = new BindingList<BaseTemplate>();
                    if (contentType.Equals("RTF"))
                    {
                        var rtfTemplates = objectContext.QueryObjects<RTFTemplate>($"RESUSER='{Common.CurrentResource.ObjectID.ToString()}' and Enabled = 1");
                        foreach (var rtfTemplate in rtfTemplates)
                        {
                            templateList.Add(rtfTemplate);
                        }
                    }
                }

                foreach (BaseTemplate template in templateList)
                {
                    if (contentType.Equals("RTF"))
                        if (template is RTFTemplate)
                            templates.Add(new EditorTemplateModel(template));
                    if (contentType.Equals("IMG"))
                        if (template is IMGTemplate)
                            templates.Add(new EditorTemplateModel(template));
                }

                objectContext.FullPartialllyLoadedObjects();
            }

            return templates;
        }

        public IEnumerable<EditorTemplateModel> GetEditorTemplates(string templateGroupName)
        {
            return GetTemplateList(TemplateContentTypes.Rtf, templateGroupName);
        }

        public EditorTemplateModel SaveEditorTemplate(string menuCaption, string description, string templateGroupName, string templateContent)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<TemplateGroup> templateGroupList = objectContext.QueryObjects<TemplateGroup>($"GROUPNAME='{templateGroupName}'");
                var templateGroup = templateGroupList.FirstOrDefault();
                if (templateGroup == null)
                {
                    templateGroup = new TemplateGroup(objectContext);
                    templateGroup.GroupName = templateGroupName;
                }

                var rtfTemplate = new RTFTemplate(objectContext);
                rtfTemplate.TemplateGroup = templateGroup;
                rtfTemplate.MenuCaption = menuCaption;
                rtfTemplate.ResUser = TTUser.CurrentUser.UserObject as ResUser;
                rtfTemplate.Description = description;
                rtfTemplate.Content = templateContent;
                rtfTemplate.Enabled = true;
                objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                return new EditorTemplateModel(rtfTemplate);
            }
        }

        public EditorTemplateModel UpdateEditorTemplate(string menuCaption, string description, string templateGroupName, string templateContent, Guid objectId)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    RTFTemplate rtfTemplate = objectContext.GetObject<RTFTemplate>(objectId);

                    rtfTemplate.Description = description;
                    rtfTemplate.Content = templateContent;

                    objectContext.Save();
                    objectContext.FullPartialllyLoadedObjects();

                    return new EditorTemplateModel(rtfTemplate);
                }
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
    }
}