using System;
using System.Collections.Generic;
using System.Linq;
using TTObjectClasses;

namespace Core.Models
{
    public class EditorTemplateModel
    {
        private Guid _objectID;
        public Guid ObjectID
        {
            get
            {
                return _objectID;
            }
        }

        private string _menuCaption;
        public string MenuCaption
        {
            get
            {
                return _menuCaption;
            }
        }

        public BaseTemplate Template;
        public EditorTemplateModel(string menuCaption, Guid objectID)
        {
            _objectID = objectID;
            _menuCaption = menuCaption;
            Template = null;
        }

        public EditorTemplateModel(BaseTemplate template)
        {
            _objectID = template.ObjectID;
            _menuCaption = template.MenuCaption;
            Template = template;
        }
    }
}