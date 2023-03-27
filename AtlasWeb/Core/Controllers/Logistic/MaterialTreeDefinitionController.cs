using Core.Models;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TTInstanceManagement;
using TTObjectClasses;
using TTStorageManager.Security;
using TTUtils;
using static TTObjectClasses.UTSServis;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class MaterialTreeDefinitionController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MaterialTreeDefinitionDataSource getAllMaterialTreeDefinition()
        {
            MaterialTreeDefinitionDataSource dataSource = new MaterialTreeDefinitionDataSource();
            dataSource.materialTreeDefs = new List<MaterialTreeDef>();
            dataSource.parentMaterialTreeDefs = new List<ParentMaterialTreeDef>();

            List<MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class> materialParentTreeDefList = MaterialTreeDefinition.GetMaterialTreeDefAllProperty("WHERE ISGROUP = 1").ToList();
            foreach(MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class parentItem in materialParentTreeDefList)
            {
                ParentMaterialTreeDef newparentMaterialTreeDef = new ParentMaterialTreeDef();
                newparentMaterialTreeDef.Name = parentItem.Name;
                newparentMaterialTreeDef.ObjectID = parentItem.ObjectID.Value;
                newparentMaterialTreeDef.Code = parentItem.GroupCode;
                dataSource.parentMaterialTreeDefs.Add(newparentMaterialTreeDef);
            }


            List<MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class> materialTreeDefList = MaterialTreeDefinition.GetMaterialTreeDefAllProperty(string.Empty).ToList();
            foreach (MaterialTreeDefinition.GetMaterialTreeDefAllProperty_Class item in materialTreeDefList)
            {
                MaterialTreeDef materialTreeItem = new MaterialTreeDef();
                materialTreeItem.Name = item.Name;
                materialTreeItem.ObjectID = item.ObjectID.Value;
                materialTreeItem.Code = item.GroupCode;
                materialTreeItem.IsGroup = item.IsGroup.Value;
                if (item.ParentMaterialTree != null)
                {
                    ParentMaterialTreeDef parentMaterialTree = dataSource.parentMaterialTreeDefs.Where(x => x.ObjectID == item.ParentMaterialTree).FirstOrDefault();
                    materialTreeItem.ParentMaterialTree = parentMaterialTree;
                }
                dataSource.materialTreeDefs.Add(materialTreeItem);
            }
            return dataSource;
        }


        [HttpPost]
        public string saveObject(MaterialTreeInputDTO input)
        {
            try
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                MaterialTreeDefinition materialTreeDefinition = null;
                if (input.isNew == true)
                {
                    materialTreeDefinition = new MaterialTreeDefinition(objectContext);

                }
                else
                {
                    materialTreeDefinition = objectContext.GetObject<MaterialTreeDefinition>(input.ObjectID);
                }
                materialTreeDefinition.GroupCode = input.Code;
                materialTreeDefinition.IsGroup = input.IsGroup;
                materialTreeDefinition.Name = input.Name;
                if (input.ParentMaterialTreeObjectId != null)
                {
                    MaterialTreeDefinition parentMatDef = objectContext.GetObject<MaterialTreeDefinition>(input.ParentMaterialTreeObjectId.Value);
                    materialTreeDefinition.ParentMaterialTree = parentMatDef;
                }
                objectContext.Save();
                objectContext.Dispose();
                return "Kayıt İşlemi Yapılmıştır";
            }
            catch
            {
                return "Kayıt İşlemi Sırasında Hata Alınmıştır..";
            }
        }
    }
}
