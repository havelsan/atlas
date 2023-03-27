using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using System.Globalization;
using System.Text;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class PatientFolderContentDefService : Controller
    {

        [HttpGet]
        public PatientFolderContentDefFormViewModel LoadFolderContentDefFormViewModel()
        {
            PatientFolderContentDefFormViewModel viewModel = new PatientFolderContentDefFormViewModel();
            viewModel.FolderList = new List<PatientFolderContent>();
            viewModel.FolderList = this.GetPatientFolderContentList("");
            return viewModel;
        }

        [HttpGet]
        public List<PatientFolderContent> SaveOrUpdateFolder(string name, bool active, Guid? FolderObjectID = null)
        {
            List<PatientFolderContent> FolderList = new List<PatientFolderContent>();
            using (var objectContext = new TTObjectContext(false))
            {
                PatientFolderContentDefinition folder;

                if (FolderObjectID == null)
                    folder = new PatientFolderContentDefinition(objectContext);
                else
                    folder = objectContext.GetObject<PatientFolderContentDefinition>((Guid)FolderObjectID);


                folder.FileName = name;
                folder.Active = active;

                objectContext.Save();

                FolderList = this.GetPatientFolderContentList("");

            }
            return FolderList;
        }

        [HttpGet]
        public List<PatientFolderContent> DeleteDefinitionObject(Guid? ObjectID)
        {
            List<PatientFolderContent> FolderList = new List<PatientFolderContent>();
            using (var objectContext = new TTObjectContext(false))
            {

                PatientFolderContentDefinition Folder = objectContext.GetObject<PatientFolderContentDefinition>((Guid)ObjectID);
                ((ITTObject)Folder).Delete();
                objectContext.Save();

                FolderList = this.GetPatientFolderContentList("");

                return FolderList;
            }
        }

        public List<PatientFolderContent> GetPatientFolderContentList(string filter)
        {
            List<PatientFolderContent> FolderList = new List<PatientFolderContent>();
            var list = PatientFolderContentDefinition.GetPatientFolderContent(filter);
            foreach (PatientFolderContentDefinition.GetPatientFolderContent_Class item in list)
            {
                PatientFolderContent model = new PatientFolderContent();
                model.ObjectID = item.ObjectID;
                model.Name = item.FileName;
                model.Active = item.Active;

                FolderList.Add(model);
            }

            return FolderList;
        }

        
    }
}

namespace Core.Models
{
    public class PatientFolderContentDefFormViewModel
    {
        public List<PatientFolderContent> FolderList { get; set; }

    }

    public class PatientFolderContent
    {
        public Guid? ObjectID { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
    }

}
