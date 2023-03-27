
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Marka/Model/Gövde Yapısı/ Uç Yapısı / Uzunluk İstek  
    /// </summary>
    public  partial class MarkModelRequestAction : BaseCentralAction
    {
        
                    
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
            if(string.IsNullOrEmpty(WorkListDescription))
            {
                if (FixedAssetDetailMainClassDef  != null)
                    WorkListDescription = FixedAssetDetailMainClassDef.MainClassName +" İstek";
            }

#endregion PreInsert
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
#region PreTransition_New2Approval
            
            
            List<TTObject> objList = new List<TTObject>();
            objList.Add(this);
          //  MarkModelRequestAction.RemoteMethods.SendAction(Sites.SiteMerkezSagKom, objList);

#endregion PreTransition_New2Approval
        }

        protected void PreTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PreTransition_Approval2Completed
            
            FixedAssetDetailMarkDef newMark = null;
            FixedAssetDetailModelDef newModel = null;
            FixedAssetDetailBodyDef newBody = null;
            FixedAssetDetailEdgeDef newEdge = null;
            FixedAssetDetailLengthDef newLenght = null;

            
            
            
            if (FixedAssetDetailMarkDef == null)
            {
                if (string.IsNullOrEmpty(MarkName) == false)
                {
                    if (!CheckMark(FixedAssetDetailMainClassDef, MarkName))
                        newMark = CreateMark(FixedAssetDetailMainClassDef, MarkName);
                }

                if (string.IsNullOrEmpty(ModelName) == false)
                {
                    if (!CheckModel(newMark, ModelName))
                        newModel = CreateModel(newMark, ModelName);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(ModelName) == false)
                {
                    if (!CheckMark(FixedAssetDetailMainClassDef, MarkName))
                        newMark = CreateMark(FixedAssetDetailMainClassDef, MarkName);
                    
                    if(newMark != null)
                    {
                        if (!CheckModel(newMark, ModelName))
                            newModel = CreateModel(FixedAssetDetailMarkDef, ModelName);
                    }
                    else
                    {
                        if (!CheckModel(FixedAssetDetailMarkDef, ModelName))
                            newModel = CreateModel(FixedAssetDetailMarkDef, ModelName);
                    }
                    
                }
            }
            
            
            if (FixedAssetDetailBodyDef == null)
            {
                if (string.IsNullOrEmpty(BodyName) == false)
                {
                    if (!CheckBody(FixedAssetDetailMainClassDef, BodyName))
                        newBody = CreateBody(FixedAssetDetailMainClassDef, BodyName);

                    if (string.IsNullOrEmpty(EdgeName) == false)
                    {
                        if(newBody != null)
                        {
                            if (!CheckEdge(newBody, EdgeName))
                                newEdge = CreateEdge(newBody, EdgeName);
                        }
                        else
                        {
                            if (!CheckEdge(FixedAssetDetailBodyDef, EdgeName))
                                newEdge = CreateEdge(newBody, EdgeName);
                        }
                    }

                    if (string.IsNullOrEmpty(Length) == false)
                    {
                        if(newEdge != null)
                        {
                            if (!CheckLenght(newEdge, Length))
                                newLenght = CreateLenght(newEdge, Length);
                        }
                        else
                        {
                            if (!CheckLenght(FixedAssetDetailEdgeDef, Length))
                                newLenght = CreateLenght(newEdge, Length);
                        }
                    }

                }
            }
            else
            {
                if (FixedAssetDetailEdgeDef == null)
                {
                    if (string.IsNullOrEmpty(EdgeName) == false)
                    {
                        if (!CheckBody(FixedAssetDetailMainClassDef, BodyName))
                            newBody = CreateBody(FixedAssetDetailMainClassDef, BodyName);
                        
                        if(newBody != null)
                        {
                            if (!CheckEdge(newBody, EdgeName))
                                newEdge = CreateEdge(FixedAssetDetailBodyDef, EdgeName);
                        }
                        else
                        {
                            if (!CheckEdge(FixedAssetDetailBodyDef, EdgeName))
                                newEdge = CreateEdge(FixedAssetDetailBodyDef, EdgeName);
                        }
                        
                        
                        if (string.IsNullOrEmpty(Length) == false)
                        {
                            if(newEdge != null)
                            {
                                if (!CheckLenght(newEdge, Length))
                                    newLenght = CreateLenght(newEdge, Length);
                            }
                            else
                            {
                                if (!CheckLenght(FixedAssetDetailEdgeDef, Length))
                                    newLenght = CreateLenght(newEdge, Length);
                                
                            }
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Length) == false)
                    {
                        if (!CheckBody(FixedAssetDetailMainClassDef, BodyName))
                            newBody = CreateBody(FixedAssetDetailMainClassDef, BodyName);
                        
                        if(newBody != null)
                        {
                            if (!CheckEdge(newBody, EdgeName))
                                newEdge = CreateEdge(FixedAssetDetailBodyDef, EdgeName);
                        }
                        else
                        {
                            if (!CheckEdge(FixedAssetDetailBodyDef, EdgeName))
                                newEdge = CreateEdge(FixedAssetDetailBodyDef, EdgeName);
                        }
                        
                        if(newEdge != null)
                        {
                            if (!CheckLenght(newEdge, Length))
                                newLenght = CreateLenght(FixedAssetDetailEdgeDef, Length);
                        }
                        else
                        {
                            if (!CheckLenght(FixedAssetDetailEdgeDef, Length))
                                newLenght = CreateLenght(FixedAssetDetailEdgeDef, Length);
                        }
                    }
                }
            }


            if (newMark != null)
                FixedAssetDetailMarkDef = newMark;

            if (newModel != null)
                FixedAssetDetailModelDef = newModel;

            if (newBody != null)
                FixedAssetDetailBodyDef = newBody;

            if (newEdge != null)
                FixedAssetDetailEdgeDef = newEdge;

            if (newLenght != null)
                FixedAssetDetailLengthDef = newLenght;



#endregion PreTransition_Approval2Completed
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            

            if (FixedAssetDetailMainClassDef != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(FixedAssetDetailMainClassDef);

            if (FixedAssetDetailMarkDef != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(FixedAssetDetailMarkDef);

            if (FixedAssetDetailModelDef != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(FixedAssetDetailModelDef);

            if (FixedAssetDetailBodyDef != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(FixedAssetDetailBodyDef);

            if (FixedAssetDetailEdgeDef != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(FixedAssetDetailEdgeDef);

            if (FixedAssetDetailLengthDef != null)
                TerminologyManagerDef.RunSendWithTerminologyManagerDef(FixedAssetDetailLengthDef);

            List<TTObject> objList = new List<TTObject>();
            objList.Add(this);
           // MarkModelRequestAction.RemoteMethods.SendAction(this.FromSite.ObjectID, objList);

#endregion PostTransition_Approval2Completed
        }

#region Methods
        public bool CheckMark(FixedAssetDetailMainClassDefinition mainClass, string markName)
        {
            bool check = true;

            IList allMark = ObjectContext.QueryObjects("FIXEDASSETDETAILMARKDEF", "FIXEDASSETDETAILMAINCLASS =" + ConnectionManager.GuidToString(mainClass.ObjectID));
            Dictionary<string, FixedAssetDetailMarkDef> markDic = new Dictionary<string, FixedAssetDetailMarkDef>();
            foreach (FixedAssetDetailMarkDef mark in allMark)
            {
                string mName = mark.MarkName.Trim();
                if (markDic.ContainsKey(mName.ToUpper()) == false)
                    markDic.Add(mName, mark);
            }
            string mmark = markName.ToUpper().Trim();
            if (markDic.ContainsKey(mmark) == false)
            {
                check = false;
            }
            return check;
        }

        public bool CheckModel(FixedAssetDetailMarkDef markDef, string modelName)
        {
            bool check = true;

            IList allModel = ObjectContext.QueryObjects("FIXEDASSETDETAILMODELDEF", "FIXEDASSETDETAILMARKDEF =" + ConnectionManager.GuidToString(markDef.ObjectID));
            Dictionary<string, FixedAssetDetailModelDef> modelDic = new Dictionary<string, FixedAssetDetailModelDef>();
            foreach (FixedAssetDetailModelDef model in allModel)
            {
                string mName = model.ModelName.Trim();
                if (modelDic.ContainsKey(mName.ToUpper()) == false)
                    modelDic.Add(mName, model);
            }
            string mmName = modelName.ToUpper().Trim();
            if (modelDic.ContainsKey(mmName) == false)
            {
                check = false;
            }
            return check;
        }

        public bool CheckBody(FixedAssetDetailMainClassDefinition mainClass, string bodyName)
        {
            bool check = true;
            IList allBody = ObjectContext.QueryObjects("FIXEDASSETDETAILBODYDEF", "FIXEDASSETDETAILMAINCLASS =" + ConnectionManager.GuidToString(mainClass.ObjectID));
            Dictionary<string, FixedAssetDetailBodyDef> bodyDic = new Dictionary<string, FixedAssetDetailBodyDef>();
            foreach (FixedAssetDetailBodyDef body in allBody)
            {
                string bName = body.BodyName.Trim();
                if (bodyDic.ContainsKey(bName.ToUpper()) == false)
                    bodyDic.Add(bName, body);
            }
            string bbname = bodyName.ToUpper().Trim();
            if (bodyDic.ContainsKey(bbname) == false)
                check = false;

            return check;
        }

        public bool CheckEdge(FixedAssetDetailBodyDef body, string edgeName)
        {
            bool check = true;

            IList allEdge = ObjectContext.QueryObjects("FIXEDASSETDETAILEDGEDEF", "FIXEDASSETDETAILBODYDEF =" + ConnectionManager.GuidToString(body.ObjectID));
            Dictionary<string, FixedAssetDetailEdgeDef> edgeDic = new Dictionary<string, FixedAssetDetailEdgeDef>();
            foreach (FixedAssetDetailEdgeDef edge in allEdge)
            {
                string eName = edge.EdgeName.Trim();
                if (edgeDic.ContainsKey(eName.ToUpper()) == false)
                    edgeDic.Add(eName, edge);
            }
            string edname = edgeName.ToUpper().Trim();
            if (edgeDic.ContainsKey(edname) == false)
                check = false;

            return check;
        }

        public bool CheckLenght(FixedAssetDetailEdgeDef edge, string lengthName)
        {
            bool check = true;

            IList allLength = ObjectContext.QueryObjects("FIXEDASSETDETAILLENGTHDEF", "FIXEDASSETDETAILEDGEDEF =" + ConnectionManager.GuidToString(edge.ObjectID));
            Dictionary<string, FixedAssetDetailLengthDef> lengthDic = new Dictionary<string, FixedAssetDetailLengthDef>();
            foreach (FixedAssetDetailLengthDef length in allLength)
            {
                string lName = length.Length.Trim();
                if (lengthDic.ContainsKey(lName.ToUpper()) == false)
                    lengthDic.Add(lName, length);
            }
            string lname = lengthName.ToUpper().Trim();
            if (lengthDic.ContainsKey(lname) == false)
                check = false;

            return check;
        }


        public FixedAssetDetailMarkDef CreateMark(FixedAssetDetailMainClassDefinition mainClass, string markName)
        {
            FixedAssetDetailMarkDef newMark = new FixedAssetDetailMarkDef(ObjectContext);
            newMark.MarkName = markName.ToUpper();
            newMark.FixedAssetDetailMainClass = mainClass;
            newMark.IsActive = true;
            newMark.LastUpdate = Common.RecTime();

          
            
            
            return newMark;
        }


        public FixedAssetDetailModelDef CreateModel(FixedAssetDetailMarkDef mark, string modelName)
        {
            FixedAssetDetailModelDef newModel = new FixedAssetDetailModelDef(ObjectContext);
            newModel.ModelName = modelName.ToUpper();
            newModel.FixedAssetDetailMarkDef = mark;
            newModel.IsActive = true;
            newModel.LastUpdate = Common.RecTime();

            
            
            return newModel;
        }

        public FixedAssetDetailBodyDef CreateBody(FixedAssetDetailMainClassDefinition mainClass, string bodyName)
        {
            FixedAssetDetailBodyDef newBody = new FixedAssetDetailBodyDef(ObjectContext);
            newBody.BodyName = bodyName.ToUpper();
            newBody.FixedAssetDetailMainClass = mainClass;
            newBody.IsActive = true;
            newBody.LastUpdate = Common.RecTime();

         
            
            return newBody;
        }

        public FixedAssetDetailEdgeDef CreateEdge(FixedAssetDetailBodyDef body, string edgeName)
        {
            FixedAssetDetailEdgeDef newEdge = new FixedAssetDetailEdgeDef(ObjectContext);
            newEdge.EdgeName = edgeName.ToUpper();
            newEdge.FixedAssetDetailBodyDef = body;
            newEdge.IsActive = true;
            newEdge.LastUpdate = Common.RecTime();

            
            
            return newEdge;
        }

        public FixedAssetDetailLengthDef CreateLenght(FixedAssetDetailEdgeDef edge, string lengthName)
        {
            FixedAssetDetailLengthDef newLength = new FixedAssetDetailLengthDef(ObjectContext);
            newLength.Length = lengthName.ToUpper();
            newLength.FixedAssetDetailEdgeDef = edge;
            newLength.IsActive = true;
            newLength.LastUpdate = Common.RecTime();

           
            
            return newLength;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MarkModelRequestAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MarkModelRequestAction.States.New && toState == MarkModelRequestAction.States.Approval)
                PreTransition_New2Approval();
            else if (fromState == MarkModelRequestAction.States.Approval && toState == MarkModelRequestAction.States.Completed)
                PreTransition_Approval2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MarkModelRequestAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MarkModelRequestAction.States.Approval && toState == MarkModelRequestAction.States.Completed)
                PostTransition_Approval2Completed();
        }

    }
}