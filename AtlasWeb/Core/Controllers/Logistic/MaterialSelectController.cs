using System.Collections.Generic;
using System.Linq;
using Core.Models;
using TTInstanceManagement;
using System;
using TTObjectClasses;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Filters;

namespace Core.Controllers.Logistic
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public class MaterialSelectController : Controller
    {
        public class MaterialListInputDVO
        {
            public string StoreObjectId
            {
                get;
                set;
            }

            public MaterialTreeItem MaterialTreeItem
            {
                get;
                set;
            }
        }

        [HttpGet]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public MaterialSelectViewModel GetTreeList([FromQuery] string StoreObjectId, [FromQuery] string IncludeDrugDefinition = "false")
        {
            MaterialSelectViewModel materialSelectViewModel = new MaterialSelectViewModel();
            List<MenuDefinition> menuList = new List<MenuDefinition>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                string filterString = "AND  MATERIAL.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION') ";
                if (IncludeDrugDefinition == "true")
                    filterString = "AND MATERIAL.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";
                IBindingList stockInheldList = objectContext.QueryObjects("STOCK", "STORE ='" + StoreObjectId + "'  AND INHELD > 0 AND MATERIAL.ALLOWTOGIVEPATIENT = 1" + filterString);
                if (stockInheldList.Count > 0)
                {
                    List<MaterialTreeDefinition> baseMaterialTreeList = new List<MaterialTreeDefinition>();
                    foreach (Stock stock in stockInheldList)
                    {
                        if (baseMaterialTreeList.Contains(stock.Material.MaterialTree) == false)
                            baseMaterialTreeList.Add(stock.Material.MaterialTree);
                    }

                    List<MaterialTreeDefinition> materialTreeList = new List<MaterialTreeDefinition>();
                    foreach (MaterialTreeDefinition mt in baseMaterialTreeList)
                        materialTreeList = treeList(materialTreeList, mt);
                    List<MaterialTreeItem> treeItems = new List<MaterialTreeItem>();
                    foreach (MaterialTreeDefinition treeItem in materialTreeList)
                    {
                        MaterialTreeItem materialTreeItem = new MaterialTreeItem();
                        materialTreeItem.ObjectID = treeItem.ObjectID;
                        if (treeItem.ParentMaterialTree != null)
                            materialTreeItem.ParentID = treeItem.ParentMaterialTree.ObjectID;
                        else
                            materialTreeItem.ParentID = null;
                        materialTreeItem.text = treeItem.Name;
                        materialTreeItem.items = new List<MaterialTreeItem>();
                        materialTreeItem.expanded = true;
                        treeItems.Add(materialTreeItem);
                    }

                    List<MaterialTreeItem> tree = BuildTree(treeItems);
                    materialSelectViewModel.Materials = tree;
                }

                objectContext.FullPartialllyLoadedObjects();
                return materialSelectViewModel;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<MaterialItem> GetMaterials(MaterialListInputDVO materialListInputDVO)
        {
            List<MaterialItem> materials = new List<MaterialItem>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<Guid> materialTreelist = new List<Guid>();
                materialTreelist = PrepareTree(materialListInputDVO.MaterialTreeItem, materialTreelist);
                IBindingList stockInheldList = objectContext.QueryObjects("STOCK", "STORE ='" + materialListInputDVO.StoreObjectId + "' AND INHELD > 0 AND MATERIAL.ALLOWTOGIVEPATIENT = 1 AND MATERIAL.ISACTIVE = 1");
                if (stockInheldList.Count > 0)
                {
                    foreach (Stock stock in stockInheldList)
                    {
                        if (materialTreelist.Contains(stock.Material.MaterialTree.ObjectID))
                        {
                            MaterialItem materialItem = new MaterialItem();
                            materialItem.ObjectID = stock.Material.ObjectID.ToString();
                            materialItem.MaterialName = stock.Material.Name;
                            materialItem.Inheld = Convert.ToDouble(stock.CalculatedInheld);
                            materialItem.Barcode = stock.Material.Barcode;
                            materialItem.DistributionType = stock.CalculatedDistributionType;
                            materialItem.MaterialTreeName = stock.Material.MaterialTreeName;
                            if (stock.Material.DivideAmountToPatient == true)
                            {
                                materialItem.IsDivide = true;
                                materialItem.DivideUnitAmount = stock.Material.DivideUnitAmount.Value;
                                materialItem.DivideTotalAmount = stock.Material.DivideTotalAmount.Value;
                            }
                            else
                            {
                                materialItem.IsDivide = false;
                                materialItem.DivideUnitAmount = 0;
                                materialItem.DivideTotalAmount = 0;
                            }
                                
                            if (TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", "") == "40d3a1a8-198d-4c5a-bfa4-4487136e4cb8") //PURSAKLAR
                            {
                                if (stock.Material is DrugDefinition)
                                {
                                    if (((DrugDefinition)stock.Material).DrugSpecifications.Count > 0)
                                    {
                                        for (int i = 0; i < ((DrugDefinition)stock.Material).DrugSpecifications.Count; i++)
                                        {
                                            string specification = Common.GetDisplayTextOfEnumValue("DrugSpecificationEnum", (int)((DrugDefinition)stock.Material).DrugSpecifications[i].DrugSpecification);
                                            materialItem.drugSpecification += specification + " - ";
                                        }
                                    }
                                }
                            }
                            materials.Add(materialItem);
                        }
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return materials;
            }
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<MaterialTreeDefinition> treeList(List<MaterialTreeDefinition> list, MaterialTreeDefinition materialTree)
        {
            if (list.Contains(materialTree) == false)
                list.Add(materialTree);
            if (materialTree.ParentMaterialTree != null)
                treeList(list, materialTree.ParentMaterialTree);
            return list;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<MaterialTreeItem> BuildTree(List<MaterialTreeItem> source)
        {
            var groups = source.GroupBy(i => i.ParentID);
            var roots = groups.FirstOrDefault(g => g.Key.HasValue == false).ToList();
            if (roots.Count > 0)
            {
                var dict = groups.Where(g => g.Key.HasValue).ToDictionary(g => g.Key.Value, g => g.ToList());
                for (int i = 0; i < roots.Count; i++)
                    AddChildren(roots[i], dict);
            }

            return roots;
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
        public void AddChildren(MaterialTreeItem node, Dictionary<Guid, List<MaterialTreeItem>> source)
        {
            if (source.ContainsKey(node.ObjectID))
            {
                node.items = source[node.ObjectID];
                for (int i = 0; i < node.items.Count; i++)
                    AddChildren(node.items[i], source);
            }
            else
                node.items = new List<MaterialTreeItem>();
        }

        [Core.Security.AtlasRequiredRoles(TTRoleNames.Everyone)]
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