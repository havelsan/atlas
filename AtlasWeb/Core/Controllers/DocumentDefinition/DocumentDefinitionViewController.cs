using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using TTDataDictionary;
using System.Drawing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class DocumentDefinitionViewController : Controller
    {
        [HttpPost]
        public DocumentDefinitionViewModel GetFirstOpen()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DocumentDefinitionViewModel model = new DocumentDefinitionViewModel();
                model.tabs = new List<Tab>();
                IList mainGroups = objectContext.QueryObjects("DOCUMENTDEFINITION", "ISMAINGROUP=1");
                foreach (DocumentDefinition def in mainGroups)
                {
                    Tab newTab = new Tab();
                    newTab.id = def.ObjectID;
                    newTab.text = def.Name;
                    model.tabs.Add(newTab);
                }

                DocumentDefinition firstDocument = (DocumentDefinition)objectContext.GetObject(model.tabs[0].id, typeof(DocumentDefinition));
                List<DocumentDefinition> list = PrepareTree(firstDocument, new List<DocumentDefinition>());
                List<DocumentDefinitionItem> treeItems = new List<DocumentDefinitionItem>();
                foreach (DocumentDefinition treeItem in list)
                {
                    DocumentDefinition t = (DocumentDefinition)objectContext.GetObject(treeItem.ObjectID, typeof(DocumentDefinition));
                    DocumentDefinitionItem Item = new DocumentDefinitionItem();
                    Item.id = t.ObjectID;
                    if (t.ParentDocumentDefinition != null)
                        Item.parentID = t.ParentDocumentDefinition.ObjectID;
                    else
                        Item.parentID = null;
                    if (string.IsNullOrEmpty(t.FileExtension))
                        Item.name = Common.CUCase(t.Name, false, true) + "." + t.FileExtension;
                    else
                        Item.name = Common.CUCase(t.Name, false, true) + "." + t.FileExtension;
                    Item.caption = t.Name;
                    Item.items = new List<DocumentDefinitionItem>();
                    treeItems.Add(Item);
                }
                List<DocumentDefinitionItem> tree = BuildTree(treeItems);
                model.documentDefinitions = tree;
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }

        [HttpGet]
        public List<DocumentDefinitionItem> GetDocuments([FromQuery] string tabID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<DocumentDefinitionItem> items = new List<DocumentDefinitionItem>();
                DocumentDefinition firstDocument = (DocumentDefinition)objectContext.GetObject(new Guid(tabID), typeof(DocumentDefinition));
                List<DocumentDefinition> list = PrepareTree(firstDocument, new List<DocumentDefinition>());
                List<DocumentDefinitionItem> treeItems = new List<DocumentDefinitionItem>();
                foreach (DocumentDefinition treeItem in list)
                {
                    DocumentDefinition t = (DocumentDefinition)objectContext.GetObject(treeItem.ObjectID, typeof(DocumentDefinition));
                    DocumentDefinitionItem Item = new DocumentDefinitionItem();
                    Item.id = t.ObjectID;
                    if (t.ParentDocumentDefinition != null)
                        Item.parentID = t.ParentDocumentDefinition.ObjectID;
                    else
                        Item.parentID = null;
                    if (string.IsNullOrEmpty(t.FileExtension))
                        Item.name = Common.CUCase(t.Name, false, true) + "." + t.FileExtension;
                    else
                        Item.name = Common.CUCase(t.Name, false, true) + "." + t.FileExtension;
                    Item.caption = t.Name;
                    Item.items = new List<DocumentDefinitionItem>();
                    treeItems.Add(Item);
                }
                List<DocumentDefinitionItem> tree = BuildTree(treeItems);
                items = tree;
                objectContext.FullPartialllyLoadedObjects();
                return items;
            }
        }

        public List<DocumentDefinition> PrepareTree(DocumentDefinition documentDefinition, List<DocumentDefinition> definitions)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                definitions.Add(documentDefinition);
                IList documents = objectContext.QueryObjects("DOCUMENTDEFINITION", "PARENTDOCUMENTDEFINITION =" + TTConnectionManager.ConnectionManager.GuidToString(documentDefinition.ObjectID),"ORDERNO,NAME");
                foreach (DocumentDefinition d in documents)
                {
                    IList childdocuments = objectContext.QueryObjects("DOCUMENTDEFINITION", "PARENTDOCUMENTDEFINITION =" + TTConnectionManager.ConnectionManager.GuidToString(d.ObjectID));
                    if (childdocuments.Count > 0)
                        PrepareTree(d, definitions);
                    else
                        definitions.Add(d);
                }
                objectContext.FullPartialllyLoadedObjects();
                return definitions;
            }
        }

        public List<DocumentDefinitionItem> BuildTree(List<DocumentDefinitionItem> source)
        {
            var groups = source.GroupBy(i => i.parentID);
            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();
            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }

            return roots;
        }

        public void AddChildren(DocumentDefinitionItem node, Dictionary<Guid, List<DocumentDefinitionItem>> source)
        {
            if (source.ContainsKey(node.id))
            {
                node.items = source[node.id];
                for (int i = 0; i < node.items.Count; i++)
                    AddChildren(node.items[i], source);
            }
            else
                node.items = new List<DocumentDefinitionItem>();
        }

        public List<Guid> PrepareTree(MaterialTreeItem treeItem, List<Guid> treeList)
        {
            treeList.Add(treeItem.ObjectID);
            if (treeItem.items.Count > 0)
            {
                foreach (MaterialTreeItem child in treeItem.items)
                {
                    PrepareTree(child, treeList);
                }
            }

            return treeList;
        }
    }
}