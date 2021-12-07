using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class Lanc_LearningPageProvider : GeneralProvider
	{
		public Lanc_Learning_Grid1GridDataProvider Lanc_Learning_Grid1Provider;
		public Lanc_Learning_Grid2GridDataProvider Lanc_Learning_Grid2Provider;

		public Lanc_LearningPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_TB_LEARNINGDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_LEARNING", "Lanc_Learning");
			MainProvider.DataProvider.PageProvider = this;
			Lanc_Learning_Grid1Provider = new Lanc_Learning_Grid1GridDataProvider(this);
			Lanc_Learning_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Lanc_Learning_Grid1Provider_SetRelationFields);
			Lanc_Learning_Grid2Provider = new Lanc_Learning_Grid2GridDataProvider(this);
			Lanc_Learning_Grid2Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Lanc_Learning_Grid2Provider_SetRelationFields);
		}


		private void Lanc_Learning_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Lanc_Learning_Grid1Provider.AliasVariables = new Dictionary<string, object>();
				Lanc_Learning_Grid1Provider.AliasVariables.Add("CLI_CODFASTRAXField", MainProvider.DataProvider.Item["CLI_CODFASTRAX"].Value);
				Lanc_Learning_Grid1Provider.AliasVariables.Add("LE_VENDEDORField", MainProvider.DataProvider.Item["LE_VENDEDOR"].Value);
				Lanc_Learning_Grid1Provider.AliasVariables.Add("LE_DATAField", MainProvider.DataProvider.Item["LE_DATA"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void Lanc_Learning_Grid2Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Lanc_Learning_Grid2Provider.AliasVariables = new Dictionary<string, object>();
				Lanc_Learning_Grid2Provider.AliasVariables.Add("CLI_CODFASTRAXField", MainProvider.DataProvider.Item["CLI_CODFASTRAX"].Value);
				Lanc_Learning_Grid2Provider.AliasVariables.Add("LE_VENDEDORField", MainProvider.DataProvider.Item["LE_VENDEDOR"].Value);
				Lanc_Learning_Grid2Provider.AliasVariables.Add("LE_DATAField", MainProvider.DataProvider.Item["LE_DATA"].Value);
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_TB_LEARNINGItem(MainProvider.DatabaseName);
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_LEARNING", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "LE_ID") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			if(FieldName == "LOJACOR")
			{
				return MainProvider.DataProvider.Dao.ToSql(new LongField("",HttpContext.Current.Session["EmprCod"].ToString()).GetFormattedValue(""),FieldType.Long);
			}
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void ExecuteSingleProcess(string ProcessName)
        {
            CreateProcess(ProcessName, false);
            List<Process> ProcList = new List<Process>(Process.Values);
            if (ProcList.Count > 0)
                DataProcessEntry.ExecuteProcess(ProcList, MainProvider.DataProvider.Dao);
        }
		
		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
		}

		public override void CreateReverseProcess(int Pos , string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			object ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}
		
		public DataRow ComboBox1_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_CODFASTRAX") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox1(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) ";
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_CODFASTRAX", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow ComboBox3_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("LE_QTDPUBLICO") + " as varchar) " +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LE_QTDPUBLICO") + " FROM  " + Dao.PoeColAspas("TB_LEARNING") + " WHERE " + Dao.PoeColAspas("LE_QTDPUBLICO") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox3(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields = "cast(" + Dao.PoeColAspas("LE_QTDPUBLICO") + " as varchar) ";
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LEARNING", DisplayFields, "LE_QTDPUBLICO", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		
		public DataRow ComboBox5_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_NAME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox5(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_NAME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_LOGIN", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("LOGIN_GROUP_NAME") + " Asc", false, "");
		}
		
		public DataRow ComboBox2_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + Dao.PoeColAspas("CLI_CODFASTRAX") + " = " + Dao.ToSql(AliasVariables["CLI_CODFASTRAXField"].ToString(), FieldType.Integer);
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_NOME") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_NOME") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox2(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter, Dictionary<string, object> ClientFields)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string CboFilter = "";
			try
			{
				CboFilter = Dao.PoeColAspas("CLI_CODFASTRAX") + " = " + Dao.ToSql(ClientFields["ComboBox1"].ToString(), FieldType.Integer);
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_NOME", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("CLI_NOME") + " Asc", false, "");
		}
		public DataRow Grid1_GridColumn17_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_ID") + " FROM  " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn17_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields = "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) ";
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_PRODUTO", DisplayFields, "PROD_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow Grid1_GridColumn18_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("PROD_EDS") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("PROD_EDS") + " FROM  " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_EDS") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn18_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields =  Dao.PoeColAspas("PROD_EDS");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_PRODUTO", DisplayFields, "PROD_EDS", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}


		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			DataTable dt;
			string Select = "";
			DataAccessObject Dao;
			string CboFilter = "";
			switch (GridColumnId)
			{
				case "Grid1_GridColumn17":
					Dao = Utility.GetDAO("25246FASTRAX");
					dt = Dao.RunSql(String.Format("SELECT " + "cast(" + Dao.PoeColAspas("PROD_CODFASTRAX") + " as varchar) " + " FROM " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_ID") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid1_GridColumn18":
					Dao = Utility.GetDAO("25246FASTRAX");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("PROD_EDS") + " FROM " + Dao.PoeColAspas("TB_PRODUTO") + " WHERE " + Dao.PoeColAspas("PROD_EDS") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				default:
					return "";
			}
		}
		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["CLI_IDField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox2", "CLI_ID não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["LE_DATAField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker1", "LE_DATA não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["LE_VENDEDORField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox5", "LE_VENDEDOR não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Lanc_Learning_Grid1GridDataProvider : GeneralGridProvider
	{
		public long PROD_IDField;
		public string LE_LINEAField;
		public long LOJACORField;
		public long LE_IDField;
		public string LE_VENDEDORField;
		public DateTime LE_DATAField;
		public long LE_QTDPUBLICOField;
		public string LE_LOCALTREINAField;
		public string LE_OJETIVOField;
		public string MKT_CAMPANHAField;
		public string LE_DESCRIPCIONField;
		public long CLI_CODFASTRAXField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private _25246FASTRAX_TB_LEARNINGDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _25246FASTRAX_TB_LEARNINGDataProvider;
			}
		}

		public Lanc_LearningPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_LEARNING"; } }

		public override string DatabaseName { get { return "25246FASTRAX"; } }

		public override string FormID { get { return "30311"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public Lanc_Learning_Grid1GridDataProvider(Lanc_LearningPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _25246FASTRAX_TB_LEARNINGDataProvider(this, TableName, DatabaseName, "PK_TB_LEARNING", "Lanc_Learning_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public _25246FASTRAX_TB_LEARNINGItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _25246FASTRAX_TB_LEARNINGItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Lanc_Learning_Grid1")
			{
				return new _25246FASTRAX_TB_LEARNINGItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Lanc_LearningPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			PROD_IDField = Convert.ToInt64(Item["PROD_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_IDField"))
			{
				AliasVariables["PROD_IDField"] = PROD_IDField;
			}
			else
			{
				AliasVariables.Add("PROD_IDField" ,PROD_IDField);
			}
			LE_LINEAField = Convert.ToString(Item["LE_LINEA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_LINEAField"))
			{
				AliasVariables["LE_LINEAField"] = LE_LINEAField;
			}
			else
			{
				AliasVariables.Add("LE_LINEAField" ,LE_LINEAField);
			}
			LOJACORField = Convert.ToInt64(Item["LOJACOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOJACORField"))
			{
				AliasVariables["LOJACORField"] = LOJACORField;
			}
			else
			{
				AliasVariables.Add("LOJACORField" ,LOJACORField);
			}
			LE_IDField = Convert.ToInt64(Item["LE_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_IDField"))
			{
				AliasVariables["LE_IDField"] = LE_IDField;
			}
			else
			{
				AliasVariables.Add("LE_IDField" ,LE_IDField);
			}
			LE_VENDEDORField = Convert.ToString(Item["LE_VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_VENDEDORField"))
			{
				AliasVariables["LE_VENDEDORField"] = LE_VENDEDORField;
			}
			else
			{
				AliasVariables.Add("LE_VENDEDORField" ,LE_VENDEDORField);
			}
			LE_DATAField = Convert.ToDateTime(Item["LE_DATA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_DATAField"))
			{
				AliasVariables["LE_DATAField"] = LE_DATAField;
			}
			else
			{
				AliasVariables.Add("LE_DATAField" ,LE_DATAField);
			}
			LE_QTDPUBLICOField = Convert.ToInt64(Item["LE_QTDPUBLICO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_QTDPUBLICOField"))
			{
				AliasVariables["LE_QTDPUBLICOField"] = LE_QTDPUBLICOField;
			}
			else
			{
				AliasVariables.Add("LE_QTDPUBLICOField" ,LE_QTDPUBLICOField);
			}
			LE_LOCALTREINAField = Convert.ToString(Item["LE_LOCALTREINA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_LOCALTREINAField"))
			{
				AliasVariables["LE_LOCALTREINAField"] = LE_LOCALTREINAField;
			}
			else
			{
				AliasVariables.Add("LE_LOCALTREINAField" ,LE_LOCALTREINAField);
			}
			LE_OJETIVOField = Convert.ToString(Item["LE_OJETIVO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_OJETIVOField"))
			{
				AliasVariables["LE_OJETIVOField"] = LE_OJETIVOField;
			}
			else
			{
				AliasVariables.Add("LE_OJETIVOField" ,LE_OJETIVOField);
			}
			MKT_CAMPANHAField = Convert.ToString(Item["MKT_CAMPANHA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("MKT_CAMPANHAField"))
			{
				AliasVariables["MKT_CAMPANHAField"] = MKT_CAMPANHAField;
			}
			else
			{
				AliasVariables.Add("MKT_CAMPANHAField" ,MKT_CAMPANHAField);
			}
			LE_DESCRIPCIONField = Convert.ToString(Item["LE_DESCRIPCION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_DESCRIPCIONField"))
			{
				AliasVariables["LE_DESCRIPCIONField"] = LE_DESCRIPCIONField;
			}
			else
			{
				AliasVariables.Add("LE_DESCRIPCIONField" ,LE_DESCRIPCIONField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_LEARNING", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "LE_ID") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}

}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Lanc_Learning_Grid2GridDataProvider : GeneralGridProvider
	{
		public string LE_VENDEDORField;
		public long CLI_CODFASTRAXField;
		public DateTime LE_DATAField;
		public string LE_LINEAField;
		public long LE_QTDPUBLICOField;
		public string LE_LOCALTREINAField;
		public string LE_OJETIVOField;
		public string MKT_CAMPANHAField;
		public long LOJACORField;
		public long LE_IDField;
		public long PROD_IDField;
		public string LE_DESCRIPCIONField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private _25246FASTRAX_TB_LEARNINGDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _25246FASTRAX_TB_LEARNINGDataProvider;
			}
		}

		public Lanc_LearningPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_LEARNING"; } }

		public override string DatabaseName { get { return "25246FASTRAX"; } }

		public override string FormID { get { return "30311"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public Lanc_Learning_Grid2GridDataProvider(Lanc_LearningPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _25246FASTRAX_TB_LEARNINGDataProvider(this, TableName, DatabaseName, "PK_TB_LEARNING", "Lanc_Learning_Grid2");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public _25246FASTRAX_TB_LEARNINGItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _25246FASTRAX_TB_LEARNINGItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Lanc_Learning_Grid2")
			{
				return new _25246FASTRAX_TB_LEARNINGItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Lanc_LearningPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			LE_VENDEDORField = Convert.ToString(Item["LE_VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_VENDEDORField"))
			{
				AliasVariables["LE_VENDEDORField"] = LE_VENDEDORField;
			}
			else
			{
				AliasVariables.Add("LE_VENDEDORField" ,LE_VENDEDORField);
			}
			CLI_CODFASTRAXField = Convert.ToInt64(Item["CLI_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_CODFASTRAXField"))
			{
				AliasVariables["CLI_CODFASTRAXField"] = CLI_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("CLI_CODFASTRAXField" ,CLI_CODFASTRAXField);
			}
			LE_DATAField = Convert.ToDateTime(Item["LE_DATA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_DATAField"))
			{
				AliasVariables["LE_DATAField"] = LE_DATAField;
			}
			else
			{
				AliasVariables.Add("LE_DATAField" ,LE_DATAField);
			}
			LE_LINEAField = Convert.ToString(Item["LE_LINEA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_LINEAField"))
			{
				AliasVariables["LE_LINEAField"] = LE_LINEAField;
			}
			else
			{
				AliasVariables.Add("LE_LINEAField" ,LE_LINEAField);
			}
			LE_QTDPUBLICOField = Convert.ToInt64(Item["LE_QTDPUBLICO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_QTDPUBLICOField"))
			{
				AliasVariables["LE_QTDPUBLICOField"] = LE_QTDPUBLICOField;
			}
			else
			{
				AliasVariables.Add("LE_QTDPUBLICOField" ,LE_QTDPUBLICOField);
			}
			LE_LOCALTREINAField = Convert.ToString(Item["LE_LOCALTREINA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_LOCALTREINAField"))
			{
				AliasVariables["LE_LOCALTREINAField"] = LE_LOCALTREINAField;
			}
			else
			{
				AliasVariables.Add("LE_LOCALTREINAField" ,LE_LOCALTREINAField);
			}
			LE_OJETIVOField = Convert.ToString(Item["LE_OJETIVO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_OJETIVOField"))
			{
				AliasVariables["LE_OJETIVOField"] = LE_OJETIVOField;
			}
			else
			{
				AliasVariables.Add("LE_OJETIVOField" ,LE_OJETIVOField);
			}
			MKT_CAMPANHAField = Convert.ToString(Item["MKT_CAMPANHA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("MKT_CAMPANHAField"))
			{
				AliasVariables["MKT_CAMPANHAField"] = MKT_CAMPANHAField;
			}
			else
			{
				AliasVariables.Add("MKT_CAMPANHAField" ,MKT_CAMPANHAField);
			}
			LOJACORField = Convert.ToInt64(Item["LOJACOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOJACORField"))
			{
				AliasVariables["LOJACORField"] = LOJACORField;
			}
			else
			{
				AliasVariables.Add("LOJACORField" ,LOJACORField);
			}
			LE_IDField = Convert.ToInt64(Item["LE_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_IDField"))
			{
				AliasVariables["LE_IDField"] = LE_IDField;
			}
			else
			{
				AliasVariables.Add("LE_IDField" ,LE_IDField);
			}
			PROD_IDField = Convert.ToInt64(Item["PROD_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_IDField"))
			{
				AliasVariables["PROD_IDField"] = PROD_IDField;
			}
			else
			{
				AliasVariables.Add("PROD_IDField" ,PROD_IDField);
			}
			LE_DESCRIPCIONField = Convert.ToString(Item["LE_DESCRIPCION"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LE_DESCRIPCIONField"))
			{
				AliasVariables["LE_DESCRIPCIONField"] = LE_DESCRIPCIONField;
			}
			else
			{
				AliasVariables.Add("LE_DESCRIPCIONField" ,LE_DESCRIPCIONField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_LEARNING", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "LE_ID") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

		public override void CreateEntries(EntryCommand EntryCommand)
		{   
			Entries = new Dictionary<string, Entry>();
			Entries.Clear();
			if (EntryCommand == EntryCommand.Insert || EntryCommand == EntryCommand.Update)
            {
			}				
			else if (EntryCommand == EntryCommand.Delete)
            {
            }
		}
		
		public override void CreateEntriesItems(Entry Entry,int vgNparc)
		{
			Entry.EntryItems.Clear(); 
			string ValueField="";
			switch (Entry.Title)
			{
				default:
					break;
			}
		}

}

}
