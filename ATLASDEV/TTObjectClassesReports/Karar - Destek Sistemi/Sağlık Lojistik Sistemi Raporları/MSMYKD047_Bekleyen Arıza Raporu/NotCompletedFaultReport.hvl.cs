
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
    /// Bekleyen Arıza Raporu
    /// </summary>
    public partial class NotCompletedFaultReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public NotCompletedFaultReport MyParentReport
            {
                get { return (NotCompletedFaultReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField ReportName { get {return Header().ReportName;} }
            public TTReportField START { get {return Header().START;} }
            public TTReportField END { get {return Header().END;} }
            public TTReportField PrintDate { get {return Footer().PrintDate;} }
            public TTReportField CurrentUser { get {return Footer().CurrentUser;} }
            public TTReportField PageNumber { get {return Footer().PageNumber;} }
            public TTReportShape NewLine11111 { get {return Footer().NewLine11111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public NotCompletedFaultReport MyParentReport
                {
                    get { return (NotCompletedFaultReport)ParentReport; }
                }
                
                public TTReportField ReportName;
                public TTReportField START;
                public TTReportField END; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 21;
                    IsAligned = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ReportName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 257, 20, false);
                    ReportName.Name = "ReportName";
                    ReportName.FieldType = ReportFieldTypeEnum.ftVariable;
                    ReportName.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName.TextFont.Size = 12;
                    ReportName.TextFont.Bold = true;
                    ReportName.TextFont.CharSet = 162;
                    ReportName.Value = @"";

                    START = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, 3, 325, 8, false);
                    START.Name = "START";
                    START.Visible = EvetHayirEnum.ehHayir;
                    START.FieldType = ReportFieldTypeEnum.ftVariable;
                    START.TextFormat = @"dd/MM/yyyy";
                    START.HorzAlign = HorizontalAlignmentEnum.haRight;
                    START.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    START.TextFont.Name = "Arial";
                    START.TextFont.Bold = true;
                    START.TextFont.CharSet = 162;
                    START.Value = @"{@STARTDATE@}";

                    END = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 301, 9, 326, 14, false);
                    END.Name = "END";
                    END.Visible = EvetHayirEnum.ehHayir;
                    END.FieldType = ReportFieldTypeEnum.ftVariable;
                    END.TextFormat = @"dd/MM/yyyy";
                    END.TextFont.Name = "Arial";
                    END.TextFont.Bold = true;
                    END.TextFont.CharSet = 162;
                    END.Value = @"{@ENTDATE@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReportName.CalcValue = @"";
                    START.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    END.CalcValue = MyParentReport.RuntimeParameters.ENTDATE.ToString();
                    return new TTReportObject[] { ReportName,START,END};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if(((NotCompletedFaultReport)ParentReport).RuntimeParameters.STORE == Guid.Empty)
                ((NotCompletedFaultReport)ParentReport).RuntimeParameters.STOREFLAG = 1;
            else
                ((NotCompletedFaultReport)ParentReport).RuntimeParameters.STOREFLAG = 0;
            
            ReportName.CalcValue = START.FormattedValue + " - " + END.FormattedValue +" TARİHLER ARASI BEKLEYEN CİHAZLAR ";
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public NotCompletedFaultReport MyParentReport
                {
                    get { return (NotCompletedFaultReport)ParentReport; }
                }
                
                public TTReportField PrintDate;
                public TTReportField CurrentUser;
                public TTReportField PageNumber;
                public TTReportShape NewLine11111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 26, 5, false);
                    PrintDate.Name = "PrintDate";
                    PrintDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate.TextFormat = @"dd/MM/yyyy";
                    PrintDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate.TextFont.Size = 8;
                    PrintDate.TextFont.CharSet = 162;
                    PrintDate.Value = @"{@printdate@}";

                    CurrentUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 120, 0, 150, 5, false);
                    CurrentUser.Name = "CurrentUser";
                    CurrentUser.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser.NoClip = EvetHayirEnum.ehEvet;
                    CurrentUser.TextFont.Size = 8;
                    CurrentUser.TextFont.CharSet = 162;
                    CurrentUser.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    PageNumber = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 232, 0, 257, 5, false);
                    PageNumber.Name = "PageNumber";
                    PageNumber.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber.TextFont.Size = 8;
                    PageNumber.TextFont.CharSet = 162;
                    PageNumber.Value = @"Sayfa Nu:{@pagenumber@}/{@pagecount@}";

                    NewLine11111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 0, 0, 257, 0, false);
                    NewLine11111.Name = "NewLine11111";
                    NewLine11111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine11111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber.CalcValue = @"Sayfa Nu:" + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate,PageNumber,CurrentUser};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class PARTBGroup : TTReportGroup
        {
            public NotCompletedFaultReport MyParentReport
            {
                get { return (NotCompletedFaultReport)ParentReport; }
            }

            new public PARTBGroupHeader Header()
            {
                return (PARTBGroupHeader)_header;
            }

            new public PARTBGroupFooter Footer()
            {
                return (PARTBGroupFooter)_footer;
            }

            public TTReportField PERSONNEL { get {return Header().PERSONNEL;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField12 { get {return Header().NewField12;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField122 { get {return Header().NewField122;} }
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
                public NotCompletedFaultReport MyParentReport
                {
                    get { return (NotCompletedFaultReport)ParentReport; }
                }
                
                public TTReportField PERSONNEL;
                public TTReportField NewField11111;
                public TTReportField NewField1;
                public TTReportField NewField11;
                public TTReportField NewField12;
                public TTReportField NewField121;
                public TTReportField NewField122; 
                public PARTBGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 7;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    PERSONNEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 1, 153, 7, false);
                    PERSONNEL.Name = "PERSONNEL";
                    PERSONNEL.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    PERSONNEL.DrawWidth = 2;
                    PERSONNEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PERSONNEL.TextFont.Bold = true;
                    PERSONNEL.TextFont.CharSet = 162;
                    PERSONNEL.Value = @"Personel";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 1, 257, 7, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField11111.DrawWidth = 2;
                    NewField11111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Cihazın Arızası";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 1, 19, 7, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField1.DrawWidth = 2;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"İstek Nu.";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 1, 41, 7, false);
                    NewField11.Name = "NewField11";
                    NewField11.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField11.DrawWidth = 2;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"İstek Tarihi";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 1, 63, 7, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField12.DrawWidth = 2;
                    NewField12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12.TextFont.Bold = true;
                    NewField12.TextFont.CharSet = 162;
                    NewField12.Value = @"İstek Türü";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 1, 121, 7, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField121.DrawWidth = 2;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Cihazın Adı";

                    NewField122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 1, 182, 7, false);
                    NewField122.Name = "NewField122";
                    NewField122.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    NewField122.DrawWidth = 2;
                    NewField122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField122.TextFont.Name = "Arial";
                    NewField122.TextFont.Bold = true;
                    NewField122.TextFont.CharSet = 162;
                    NewField122.Value = @"İşlem Durumu";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PERSONNEL.CalcValue = PERSONNEL.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField1.CalcValue = NewField1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField122.CalcValue = NewField122.Value;
                    return new TTReportObject[] { PERSONNEL,NewField11111,NewField1,NewField11,NewField12,NewField121,NewField122};
                }
            }
            public partial class PARTBGroupFooter : TTReportSection
            {
                public NotCompletedFaultReport MyParentReport
                {
                    get { return (NotCompletedFaultReport)ParentReport; }
                }
                 
                public PARTBGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                
            }

        }

        public PARTBGroup PARTB;

        public partial class MAINGroup : TTReportGroup
        {
            public NotCompletedFaultReport MyParentReport
            {
                get { return (NotCompletedFaultReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField RequestNO { get {return Body().RequestNO;} }
            public TTReportField RequestDate { get {return Body().RequestDate;} }
            public TTReportField RequestType { get {return Body().RequestType;} }
            public TTReportField Status { get {return Body().Status;} }
            public TTReportField FaultDescription { get {return Body().FaultDescription;} }
            public TTReportField ObjectID { get {return Body().ObjectID;} }
            public TTReportField FixedAssetName { get {return Body().FixedAssetName;} }
            public TTReportField Personel { get {return Body().Personel;} }
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
                list[0] = new TTReportNqlData<CMRActionRequest.GetNotCompletedFaultReportQuery_Class>("GetNotCompletedFaultReportQuery2", CMRActionRequest.GetNotCompletedFaultReportQuery((DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENTDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.STORE),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.STOREFLAG)));
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
                public NotCompletedFaultReport MyParentReport
                {
                    get { return (NotCompletedFaultReport)ParentReport; }
                }
                
                public TTReportField RequestNO;
                public TTReportField RequestDate;
                public TTReportField RequestType;
                public TTReportField Status;
                public TTReportField FaultDescription;
                public TTReportField ObjectID;
                public TTReportField FixedAssetName;
                public TTReportField Personel; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 9;
                    RepeatCount = 0;
                    
                    RequestNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 1, 0, 19, 9, false);
                    RequestNO.Name = "RequestNO";
                    RequestNO.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    RequestNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestNO.TextFont.CharSet = 162;
                    RequestNO.Value = @"{#REQUESTNO#}";

                    RequestDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 19, 0, 41, 9, false);
                    RequestDate.Name = "RequestDate";
                    RequestDate.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    RequestDate.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestDate.TextFormat = @"dd/MM/yyyy";
                    RequestDate.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestDate.TextFont.CharSet = 162;
                    RequestDate.Value = @"{#REQUESTDATE#}";

                    RequestType = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 41, 0, 63, 9, false);
                    RequestType.Name = "RequestType";
                    RequestType.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    RequestType.FieldType = ReportFieldTypeEnum.ftVariable;
                    RequestType.CaseFormat = CaseFormatEnum.fcTitleCase;
                    RequestType.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RequestType.ObjectDefName = "RequestTypeEnum";
                    RequestType.DataMember = "DISPLAYTEXT";
                    RequestType.TextFont.CharSet = 162;
                    RequestType.Value = @"{#REQUESTTYPE#}";

                    Status = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 153, 0, 182, 9, false);
                    Status.Name = "Status";
                    Status.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    Status.FieldType = ReportFieldTypeEnum.ftVariable;
                    Status.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    Status.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Status.MultiLine = EvetHayirEnum.ehEvet;
                    Status.WordBreak = EvetHayirEnum.ehEvet;
                    Status.TextFont.CharSet = 162;
                    Status.Value = @"";

                    FaultDescription = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 0, 257, 9, false);
                    FaultDescription.Name = "FaultDescription";
                    FaultDescription.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    FaultDescription.FieldType = ReportFieldTypeEnum.ftVariable;
                    FaultDescription.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FaultDescription.MultiLine = EvetHayirEnum.ehEvet;
                    FaultDescription.WordBreak = EvetHayirEnum.ehEvet;
                    FaultDescription.TextFont.CharSet = 162;
                    FaultDescription.Value = @"{#FAULTDESCRIPTION#}";

                    ObjectID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 300, -1, 325, 4, false);
                    ObjectID.Name = "ObjectID";
                    ObjectID.Visible = EvetHayirEnum.ehHayir;
                    ObjectID.FieldType = ReportFieldTypeEnum.ftVariable;
                    ObjectID.TextFont.Name = "Arial";
                    ObjectID.TextFont.CharSet = 162;
                    ObjectID.Value = @"{#OBJECTID#}";

                    FixedAssetName = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 63, 0, 121, 9, false);
                    FixedAssetName.Name = "FixedAssetName";
                    FixedAssetName.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    FixedAssetName.FieldType = ReportFieldTypeEnum.ftVariable;
                    FixedAssetName.CaseFormat = CaseFormatEnum.fcTitleCase;
                    FixedAssetName.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    FixedAssetName.MultiLine = EvetHayirEnum.ehEvet;
                    FixedAssetName.WordBreak = EvetHayirEnum.ehEvet;
                    FixedAssetName.TextFont.CharSet = 162;
                    FixedAssetName.Value = @"{#FIXEDASSETNAME#}";

                    Personel = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 121, 0, 153, 9, false);
                    Personel.Name = "Personel";
                    Personel.DrawStyle = DrawStyleConstants.vbInsideSolid;
                    Personel.FieldType = ReportFieldTypeEnum.ftVariable;
                    Personel.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    Personel.MultiLine = EvetHayirEnum.ehEvet;
                    Personel.WordBreak = EvetHayirEnum.ehEvet;
                    Personel.TextFont.CharSet = 162;
                    Personel.Value = @"{#PERSONNEL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    CMRActionRequest.GetNotCompletedFaultReportQuery_Class dataset_GetNotCompletedFaultReportQuery2 = ParentGroup.rsGroup.GetCurrentRecord<CMRActionRequest.GetNotCompletedFaultReportQuery_Class>(0);
                    RequestNO.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.RequestNo) : "");
                    RequestDate.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.RequestDate) : "");
                    RequestType.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.RequestType) : "");
                    RequestType.PostFieldValueCalculation();
                    Status.CalcValue = @"";
                    FaultDescription.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.FaultDescription) : "");
                    ObjectID.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.ObjectID) : "");
                    FixedAssetName.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.Fixedassetname) : "");
                    Personel.CalcValue = (dataset_GetNotCompletedFaultReportQuery2 != null ? Globals.ToStringCore(dataset_GetNotCompletedFaultReportQuery2.Personnel) : "");
                    return new TTReportObject[] { RequestNO,RequestDate,RequestType,Status,FaultDescription,ObjectID,FixedAssetName,Personel};
                }

                public override void RunScript()
                {
#region MAIN BODY_Script
                    CMRActionRequest action = (CMRActionRequest)MyParentReport.ReportObjectContext.GetObject(new Guid(ObjectID.CalcValue), typeof(CMRActionRequest));
            if(action != null)
                if(action.CurrentStateDef.DisplayText == "İşlem Durumu")
                  Status.CalcValue = "Kademede";
                else
                 Status.CalcValue = "Kademede";
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

        public NotCompletedFaultReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            PARTB = new PARTBGroup(PARTA,"PARTB");
            MAIN = new MAINGroup(PARTB,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlama Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENTDATE", "", "Bitiş Zamanı", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("STORE", "00000000-0000-0000-0000-000000000000", "Depo", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("65405b70-5e35-4486-b140-c95af3d8bf5d");
            reportParameter = Parameters.Add("STOREFLAG", "", "", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENTDATE"))
                _runtimeParameters.ENTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENTDATE"]);
            if (parameters.ContainsKey("STORE"))
                _runtimeParameters.STORE = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["STORE"]);
            if (parameters.ContainsKey("STOREFLAG"))
                _runtimeParameters.STOREFLAG = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["STOREFLAG"]);
            Name = "NOTCOMPLETEDFAULTREPORT";
            Caption = "Bekleyen Arıza Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
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
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
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