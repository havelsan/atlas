
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// İBF Miktar Formu
    /// </summary>
    public partial class İBFMiktarFormu : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public string MAINSTOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
            public int? IBFAmount = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public string IBFYear = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue("");
        }

        public partial class PARTBGroup : TTReportGroup
        {
            public İBFMiktarFormu MyParentReport
            {
                get { return (İBFMiktarFormu)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK { get {return Header().XXXXXXBASLIK;} }
            public TTReportField XXXXXXLOGO { get {return Header().XXXXXXLOGO;} }
            public TTReportField FORMBASLIGI { get {return Header().FORMBASLIGI;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CURRENTUSER { get {return Footer().CURRENTUSER;} }
            public TTReportField PAGENUMBER { get {return Footer().PAGENUMBER;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public PARTBGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTBGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTBGroupHeader(this);
                _footer = new PARTBGroupFooter(this);

            }

            public partial class PARTBGroupHeader : TTReportSection
            {
                public İBFMiktarFormu MyParentReport
                {
                    get { return (İBFMiktarFormu)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK;
                public TTReportField XXXXXXLOGO;
                public TTReportField FORMBASLIGI; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 33;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 0, 170, 23, false);
                    XXXXXXBASLIK.Name = "XXXXXXBASLIK";
                    XXXXXXBASLIK.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK.TextFont.Name = "Arial";
                    XXXXXXBASLIK.TextFont.Size = 12;
                    XXXXXXBASLIK.TextFont.Bold = true;
                    XXXXXXBASLIK.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    XXXXXXLOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 40, 20, false);
                    XXXXXXLOGO.Name = "XXXXXXLOGO";
                    XXXXXXLOGO.TextFont.CharSet = 1;
                    XXXXXXLOGO.Value = @"";

                    FORMBASLIGI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 25, 170, 30, false);
                    FORMBASLIGI.Name = "FORMBASLIGI";
                    FORMBASLIGI.FieldType = ReportFieldTypeEnum.ftVariable;
                    FORMBASLIGI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    FORMBASLIGI.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FORMBASLIGI.TextFont.Name = "Arial";
                    FORMBASLIGI.TextFont.Size = 11;
                    FORMBASLIGI.TextFont.Bold = true;
                    FORMBASLIGI.Value = @"{@IBFYear@} Yılı İBF İsteklerine Göre Depo Malzeme Durumları";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    XXXXXXLOGO.CalcValue = XXXXXXLOGO.Value;
                    FORMBASLIGI.CalcValue = MyParentReport.RuntimeParameters.IBFYear.ToString() + @" Yılı İBF İsteklerine Göre Depo Malzeme Durumları";
                    XXXXXXBASLIK.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { XXXXXXLOGO,FORMBASLIGI,XXXXXXBASLIK};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public İBFMiktarFormu MyParentReport
                {
                    get { return (İBFMiktarFormu)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CURRENTUSER;
                public TTReportField PAGENUMBER;
                public TTReportShape NewLine11111; 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 35;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 0, 25, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Name = "Arial";
                    PrintDate.TextFont.Size = 8;
                    PrintDate.Value = @"{@printdate@}";

                    CURRENTUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 100, 5, false);
                    CURRENTUSER.Name = "CURRENTUSER";
                    CURRENTUSER.FieldType = ReportFieldTypeEnum.ftExpression;
                    CURRENTUSER.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CURRENTUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CURRENTUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CURRENTUSER.NoClip = EvetHayirEnum.ehEvet;
                    CURRENTUSER.TextFont.Name = "Arial";
                    CURRENTUSER.TextFont.Size = 8;
                    CURRENTUSER.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PAGENUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 170, 5, false);
                    PAGENUMBER.Name = "PAGENUMBER";
                    PAGENUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PAGENUMBER.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PAGENUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PAGENUMBER.TextFont.Name = "Arial";
                    PAGENUMBER.TextFont.Size = 8;
                    PAGENUMBER.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 170, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PAGENUMBER.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CURRENTUSER.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PAGENUMBER,CURRENTUSER};
                }
            }


            protected override bool RunScript()
            {
#region PARTB_Script
                //    if (Globals.IsGuid(this.MyParentReport.RuntimeParameters.TTOBJECTID))
            //{
            //    MilitaryDrugProductionProcedure militaryDrugProductionProcedure = this.MyParentReport.ReportObjectContext.GetObject(new Guid(this.MyParentReport.RuntimeParameters.TTOBJECTID), typeof(MilitaryDrugProductionProcedure)) as MilitaryDrugProductionProcedure;

            //    if (militaryDrugProductionProcedure != null)
            //    {
            //        TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(AnalysisStageEnum).Name];
            //        EnumValueDef enumValueDef = dataType.EnumValueDefs[militaryDrugProductionProcedure.CurrentStateDef.Name];

            //        this.MyParentReport._productAnalysisTestStageDetails = this.MyParentReport.ReportObjectContext.QueryObjects(typeof(ProductAnalysisTestStageDetail).Name, "ANALYSISSTAGE = " + enumValueDef.Value);
            //        if (this.MyParentReport._productAnalysisTestStageDetails != null && this.MyParentReport._productAnalysisTestStageDetails.Count > 0)
            //        {
            //            if(militaryDrugProductionProcedure.PrevState.User.UserObject != null)
            //            {
            //                ResUser resUser = (ResUser)militaryDrugProductionProcedure.PrevState.User.UserObject;
            //                this.REQUESTUSERDETAIL.Value = resUser.Name;
            //            }

            //            this.SubGroup.RepeatCount = this.MyParentReport._productAnalysisTestStageDetails.Count;
            //        }
            //    }
            //}
            return true;
#endregion PARTB_Script
            }
        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public İBFMiktarFormu MyParentReport
            {
                get { return (İBFMiktarFormu)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField NewField112021 { get {return Body().NewField112021;} }
            public TTReportShape NewLine1 { get {return Body().NewLine1;} }
            public TTReportField NewField1120211 { get {return Body().NewField1120211;} }
            public TTReportField NewField11120211 { get {return Body().NewField11120211;} }
            public TTReportField AMOUNT { get {return Body().AMOUNT;} }
            public TTReportShape NewLine11 { get {return Body().NewLine11;} }
            public TTReportField InheldDistype { get {return Body().InheldDistype;} }
            public TTReportField RequestAmountLabel { get {return Body().RequestAmountLabel;} }
            public TTReportField REQUESTAMOUNT { get {return Body().REQUESTAMOUNT;} }
            public TTReportField IBFAMOUNT { get {return Body().IBFAMOUNT;} }
            public TTReportField SAMPLEAMOUNT { get {return Body().SAMPLEAMOUNT;} }
            public TTReportField TOTALAMOUNT { get {return Body().TOTALAMOUNT;} }
            public TTReportField DISTYPE { get {return Body().DISTYPE;} }
            public TTReportField INHELD { get {return Body().INHELD;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ProductTreeDetail.GetIBFAmountReportQuery_Class>("GetIBFAmountReportQuery", ProductTreeDetail.GetIBFAmountReportQuery((string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID),(string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(MyParentReport.RuntimeParameters.MAINSTOREID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public İBFMiktarFormu MyParentReport
                {
                    get { return (İBFMiktarFormu)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField NewField112021;
                public TTReportShape NewLine1;
                public TTReportField NewField1120211;
                public TTReportField NewField11120211;
                public TTReportField AMOUNT;
                public TTReportShape NewLine11;
                public TTReportField InheldDistype;
                public TTReportField RequestAmountLabel;
                public TTReportField REQUESTAMOUNT;
                public TTReportField IBFAMOUNT;
                public TTReportField SAMPLEAMOUNT;
                public TTReportField TOTALAMOUNT;
                public TTReportField DISTYPE;
                public TTReportField INHELD; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 17;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 27, 2, 170, 7, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.ObjectDefName = "ProductTreeDetail";
                    MATERIALNAME.DataMember = "CONSUMABLEMATERIAL.NAME";
                    MATERIALNAME.TextFont.Name = "Arial";
                    MATERIALNAME.TextFont.Bold = true;
                    MATERIALNAME.Value = @"{#OBJECTID#}";

                    NewField112021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 2, 27, 7, false);
                    NewField112021.Name = "NewField112021";
                    NewField112021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112021.TextFont.Name = "Arial";
                    NewField112021.TextFont.Bold = true;
                    NewField112021.Value = @"Malzeme Adı :";

                    NewLine1 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 8, 170, 8, false);
                    NewLine1.Name = "NewLine1";
                    NewLine1.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1.DrawWidth = 2;

                    NewField1120211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 0, 9, 24, 14, false);
                    NewField1120211.Name = "NewField1120211";
                    NewField1120211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1120211.TextFont.Name = "Arial";
                    NewField1120211.TextFont.Size = 9;
                    NewField1120211.TextFont.Bold = true;
                    NewField1120211.Value = @"Gerekli Miktar=";

                    NewField11120211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 52, 9, 74, 14, false);
                    NewField11120211.Name = "NewField11120211";
                    NewField11120211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11120211.TextFont.Name = "Arial";
                    NewField11120211.TextFont.Size = 9;
                    NewField11120211.TextFont.Bold = true;
                    NewField11120211.Value = @"Depo Miktarı=";

                    AMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 2, 275, 7, false);
                    AMOUNT.Name = "AMOUNT";
                    AMOUNT.Visible = EvetHayirEnum.ehHayir;
                    AMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT.TextFont.Name = "Arial";
                    AMOUNT.Value = @"{#AMOUNT#}";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 1, 170, 1, false);
                    NewLine11.Name = "NewLine11";
                    NewLine11.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11.DrawWidth = 2;

                    InheldDistype = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 74, 9, 112, 14, false);
                    InheldDistype.Name = "InheldDistype";
                    InheldDistype.FieldType = ReportFieldTypeEnum.ftVariable;
                    InheldDistype.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    InheldDistype.TextFont.Name = "Arial";
                    InheldDistype.TextFont.Size = 9;
                    InheldDistype.Value = @"{#INHELD#} {%DISTYPE%}";

                    RequestAmountLabel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 113, 9, 135, 14, false);
                    RequestAmountLabel.Name = "RequestAmountLabel";
                    RequestAmountLabel.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestAmountLabel.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestAmountLabel.TextFont.Name = "Arial";
                    RequestAmountLabel.TextFont.Size = 9;
                    RequestAmountLabel.TextFont.Bold = true;
                    RequestAmountLabel.Value = @"";

                    REQUESTAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 9, 170, 14, false);
                    REQUESTAMOUNT.Name = "REQUESTAMOUNT";
                    REQUESTAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTAMOUNT.TextFont.Name = "Arial";
                    REQUESTAMOUNT.TextFont.Size = 9;
                    REQUESTAMOUNT.Value = @"";

                    IBFAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 8, 246, 13, false);
                    IBFAMOUNT.Name = "IBFAMOUNT";
                    IBFAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    IBFAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    IBFAMOUNT.TextFont.Name = "Arial";
                    IBFAMOUNT.Value = @"{@IBFAmount@}";

                    SAMPLEAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 2, 246, 7, false);
                    SAMPLEAMOUNT.Name = "SAMPLEAMOUNT";
                    SAMPLEAMOUNT.Visible = EvetHayirEnum.ehHayir;
                    SAMPLEAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    SAMPLEAMOUNT.ObjectDefName = "ProductTreeDefinition";
                    SAMPLEAMOUNT.DataMember = "SAMPLEAMOUNT";
                    SAMPLEAMOUNT.TextFont.Name = "Arial";
                    SAMPLEAMOUNT.Value = @"{@TTOBJECTID@}";

                    TOTALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 24, 9, 51, 14, false);
                    TOTALAMOUNT.Name = "TOTALAMOUNT";
                    TOTALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALAMOUNT.WordBreak = EvetHayirEnum.ehEvet;
                    TOTALAMOUNT.TextFont.Name = "Arial";
                    TOTALAMOUNT.TextFont.Size = 9;
                    TOTALAMOUNT.Value = @"";

                    DISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 8, 275, 13, false);
                    DISTYPE.Name = "DISTYPE";
                    DISTYPE.Visible = EvetHayirEnum.ehHayir;
                    DISTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTYPE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DISTYPE.ObjectDefName = "ProductTreeDetail";
                    DISTYPE.DataMember = "CONSUMABLEMATERIAL.STOCKCARD.DISTRIBUTIONTYPE.DISTRIBUTIONTYPE";
                    DISTYPE.TextFont.Name = "Arial";
                    DISTYPE.TextFont.Size = 9;
                    DISTYPE.Value = @"{#OBJECTID#}";

                    INHELD = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 278, 2, 303, 7, false);
                    INHELD.Name = "INHELD";
                    INHELD.Visible = EvetHayirEnum.ehHayir;
                    INHELD.FieldType = ReportFieldTypeEnum.ftVariable;
                    INHELD.TextFont.Name = "Arial Narrow";
                    INHELD.TextFont.CharSet = 1;
                    INHELD.Value = @"{#INHELD#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ProductTreeDetail.GetIBFAmountReportQuery_Class dataset_GetIBFAmountReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ProductTreeDetail.GetIBFAmountReportQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_GetIBFAmountReportQuery != null ? Globals.ToStringCore(dataset_GetIBFAmountReportQuery.ObjectID) : "");
                    MATERIALNAME.PostFieldValueCalculation();
                    NewField112021.CalcValue = NewField112021.Value;
                    NewField1120211.CalcValue = NewField1120211.Value;
                    NewField11120211.CalcValue = NewField11120211.Value;
                    AMOUNT.CalcValue = (dataset_GetIBFAmountReportQuery != null ? Globals.ToStringCore(dataset_GetIBFAmountReportQuery.Amount) : "");
                    DISTYPE.CalcValue = (dataset_GetIBFAmountReportQuery != null ? Globals.ToStringCore(dataset_GetIBFAmountReportQuery.ObjectID) : "");
                    DISTYPE.PostFieldValueCalculation();
                    InheldDistype.CalcValue = (dataset_GetIBFAmountReportQuery != null ? Globals.ToStringCore(dataset_GetIBFAmountReportQuery.Inheld) : "") + @" " + MyParentReport.MAIN.DISTYPE.CalcValue;
                    RequestAmountLabel.CalcValue = @"";
                    REQUESTAMOUNT.CalcValue = @"";
                    IBFAMOUNT.CalcValue = MyParentReport.RuntimeParameters.IBFAmount.ToString();
                    SAMPLEAMOUNT.CalcValue = MyParentReport.RuntimeParameters.TTOBJECTID.ToString();
                    SAMPLEAMOUNT.PostFieldValueCalculation();
                    TOTALAMOUNT.CalcValue = @"";
                    INHELD.CalcValue = (dataset_GetIBFAmountReportQuery != null ? Globals.ToStringCore(dataset_GetIBFAmountReportQuery.Inheld) : "");
                    return new TTReportObject[] { MATERIALNAME,NewField112021,NewField1120211,NewField11120211,AMOUNT,DISTYPE,InheldDistype,RequestAmountLabel,REQUESTAMOUNT,IBFAMOUNT,SAMPLEAMOUNT,TOTALAMOUNT,INHELD};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    double sampleAmount = Convert.ToDouble(this.SAMPLEAMOUNT.CalcValue);
                    double ibfAmount = Convert.ToDouble(this.IBFAMOUNT.CalcValue); 
                    double amount = Convert.ToDouble(this.AMOUNT.CalcValue);
                    double inheld = Convert.ToDouble(this.INHELD.CalcValue);
                    double totalAmount = (amount / sampleAmount) * ibfAmount;
                    double requestAmount = inheld - totalAmount;
                    TOTALAMOUNT.CalcValue = totalAmount.ToString() + " " + DISTYPE.CalcValue;
                    
                    if (requestAmount < 0)
                    {
                        RequestAmountLabel.CalcValue = "Eksik Miktar = ";
                        requestAmount = requestAmount * -1;
                        REQUESTAMOUNT.CalcValue = requestAmount.ToString() + " " + DISTYPE.CalcValue;
                        REQUESTAMOUNT.TextColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        RequestAmountLabel.CalcValue = "Fazla Miktar = ";
                        REQUESTAMOUNT.CalcValue = requestAmount.ToString() + " " + DISTYPE.CalcValue;
                        REQUESTAMOUNT.TextColor = System.Drawing.Color.Black;
                    }
#endregion MAIN BODY_Script
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public İBFMiktarFormu()
        {
            PARTB = new PARTBGroup(this,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "Object ID", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter = Parameters.Add("MAINSTOREID", "", "Ana Depo", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
            reportParameter.ListDefID = new Guid("cd051a98-4361-4c40-8ad6-6f7b69696f8e");
            reportParameter = Parameters.Add("IBFAmount", "", "İBF Miktarı", @"", true, true, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("IBFYear", "", "İBF Yılı", @"", true, true, false, new Guid("cf463436-3c34-4659-a92f-d2d0af106485"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            if (parameters.ContainsKey("MAINSTOREID"))
                _runtimeParameters.MAINSTOREID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["MAINSTOREID"]);
            if (parameters.ContainsKey("IBFAmount"))
                _runtimeParameters.IBFAmount = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["IBFAmount"]);
            if (parameters.ContainsKey("IBFYear"))
                _runtimeParameters.IBFYear = (string)TTObjectDefManager.Instance.DataTypes["String10"].ConvertValue(parameters["IBFYear"]);
            Name = "İBFMIKTARFORMU";
            Caption = "İBF Miktar Formu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
            UserMarginLeft = 25;
            UserMarginTop = 15;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Courier New";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}