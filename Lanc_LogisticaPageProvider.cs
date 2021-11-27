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
	public class Lanc_LogisticaPageProvider : GeneralProvider
	{
		public Lanc_Logistica_Grid1GridDataProvider Lanc_Logistica_Grid1Provider;
		public Lanc_Logistica_Grid2GridDataProvider Lanc_Logistica_Grid2Provider;

		public Lanc_LogisticaPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _BD_DADOS_TB_LOGISTICADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_LOGISTICA", "Lanc_Logistica");
			MainProvider.DataProvider.PageProvider = this;
			Lanc_Logistica_Grid1Provider = new Lanc_Logistica_Grid1GridDataProvider(this);
			Lanc_Logistica_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Lanc_Logistica_Grid1Provider_SetRelationFields);
			Lanc_Logistica_Grid2Provider = new Lanc_Logistica_Grid2GridDataProvider(this);
			Lanc_Logistica_Grid2Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Lanc_Logistica_Grid2Provider_SetRelationFields);
		}


		private void Lanc_Logistica_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Lanc_Logistica_Grid1Provider.AliasVariables = new Dictionary<string, object>();
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("LOG_RETORNOField", MainProvider.DataProvider.Item["LOG_RETORNO"].Value);
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("LOG_PROBLEMAField", MainProvider.DataProvider.Item["LOG_PROBLEMA"].Value);
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("LOG_IDField", MainProvider.DataProvider.Item["LOG_ID"].Value);
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("NUMERO_PEDIDOField", MainProvider.DataProvider.Item["NUMERO_PEDIDO"].Value);
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("TB_AVISOS_IDField", MainProvider.DataProvider.Item["TB_AVISOS_ID"].Value);
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("CLI_IDField", MainProvider.DataProvider.Item["CLI_ID"].Value);
				Lanc_Logistica_Grid1Provider.AliasVariables.Add("LOG_VENDEDORField", MainProvider.DataProvider.Item["LOG_VENDEDOR"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void Lanc_Logistica_Grid2Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Lanc_Logistica_Grid2Provider.AliasVariables = new Dictionary<string, object>();
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("LOG_RETORNOField", MainProvider.DataProvider.Item["LOG_RETORNO"].Value);
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("LOG_PROBLEMAField", MainProvider.DataProvider.Item["LOG_PROBLEMA"].Value);
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("LOG_IDField", MainProvider.DataProvider.Item["LOG_ID"].Value);
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("NUMERO_PEDIDOField", MainProvider.DataProvider.Item["NUMERO_PEDIDO"].Value);
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("TB_AVISOS_IDField", MainProvider.DataProvider.Item["TB_AVISOS_ID"].Value);
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("CLI_IDField", MainProvider.DataProvider.Item["CLI_ID"].Value);
				Lanc_Logistica_Grid2Provider.AliasVariables.Add("LOG_VENDEDORField", MainProvider.DataProvider.Item["LOG_VENDEDOR"].Value);
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _BD_DADOS_TB_LOGISTICAItem(MainProvider.DatabaseName);
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
			MainProvider.DataProvider.FindRecord("PK_TB_LOGISTICA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "LOG_ID") });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			if(FieldName == "DATA_LANCAMENTO")
			{
				return MainProvider.DataProvider.Dao.ToSql(new DateField(MainProvider.DataProvider.SelectCommand.DateFormat,EnvironmentVariable.ActualDate).GetFormattedValue(MainProvider.DataProvider.SelectCommand.DateFormat),FieldType.Date);
			}
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
		
		public DataRow ComboBox7_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + Dao.PoeColAspas("TB_AVISOS_TIPO") + " = " + Dao.ToSql("LOG", FieldType.Text);
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("TB_AVISOS_DESC") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("TB_AVISOS_ID") + " FROM  " + Dao.PoeColAspas("TB_AVISOS") + " WHERE " + Dao.PoeColAspas("TB_AVISOS_ID") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox7(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string CboFilter = "";
			try
			{
				CboFilter = Dao.PoeColAspas("TB_AVISOS_TIPO") + " = " + Dao.ToSql("LOG", FieldType.Text);
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("TB_AVISOS_DESC");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_AVISOS", DisplayFields, "TB_AVISOS_ID", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("TB_AVISOS_DESC") + " Asc", false, "");
		}
		
		public DataRow ComboBox1_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_ID") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
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
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("CLI_NOME") + " Asc", false, "");
		}
		
		public DataRow ComboBox8_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_NAME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox8(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string CboFilter = "";
			try
			{
				CboFilter = CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_NAME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_LOGIN", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		public DataRow Grid1_GridColumn4_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("TB_AVISOS_DESC") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("TB_AVISOS_ID") + " FROM  " + Dao.PoeColAspas("TB_AVISOS") + " WHERE " + Dao.PoeColAspas("TB_AVISOS_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn4_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("TB_AVISOS_DESC");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_AVISOS", DisplayFields, "TB_AVISOS_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("TB_AVISOS_DESC") + " Asc", false, "");
		}
		
		public DataRow Grid1_GridColumn5_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_NAME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn5_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string CboFilter = "";
			try
			{
				CboFilter = CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_NAME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_LOGIN", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("LOGIN_USER_NAME") + " Asc", false, "");
		}
		
		public DataRow Grid1_GridColumn6_ComboBox_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_ID") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillGrid1_GridColumn6_ComboBox(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("BD_DADOS");
			string DisplayFields =  Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("CLI_NOME") + " Asc", false, "");
		}


		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			DataTable dt;
			string Select = "";
			DataAccessObject Dao;
			string CboFilter = "";
			switch (GridColumnId)
			{
				case "Grid1_GridColumn4":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("TB_AVISOS_DESC") + " FROM " + Dao.PoeColAspas("TB_AVISOS") + " WHERE " + Dao.PoeColAspas("TB_AVISOS_ID") + " = '{0}'", FieldId)).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid1_GridColumn5":
					Dao = Utility.GetDAO("BD_DADOS");
					try
					{
						CboFilter = CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
					}
					catch { }
					Select = String.Format("SELECT "+  Dao.PoeColAspas("LOGIN_USER_NAME") + " FROM " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", FieldId);
					if (CboFilter.Length > 0)
					{
						Select += string.Format(" AND {0}", CboFilter);
					}
					dt = Dao.RunSql(Select).Tables[0];
					if (dt.Rows.Count > 0) return dt.Rows[0][0].ToString();
					return "";
				case "Grid1_GridColumn6":
					Dao = Utility.GetDAO("BD_DADOS");
					dt = Dao.RunSql(String.Format("SELECT " +  Dao.PoeColAspas("CLI_NOME") + " FROM " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_ID") + " = '{0}'", FieldId)).Tables[0];
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["LOG_VENDEDORField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox8", "LOG_VENDEDOR não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["LOG_PROBLEMAField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox2", "LOG_PROBLEMA não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Lanc_Logistica_Grid1GridDataProvider : GeneralGridProvider
	{
		public long LOG_IDField;
		public long NUMERO_PEDIDOField;
		public long TB_AVISOS_IDField;
		public string LOG_VENDEDORField;
		public long CLI_IDField;
		public long LOJACORField;
		public string LOG_PROBLEMAField;
		public DateTime DATA_LANCAMENTOField;
		public string LOG_RETORNOField;
		public long CLI_CODFASTRAXField;
		public string LOG_IMAGEMField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private _BD_DADOS_TB_LOGISTICADataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_TB_LOGISTICADataProvider;
			}
		}

		public Lanc_LogisticaPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_LOGISTICA"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29844"; } }
		
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

		public Lanc_Logistica_Grid1GridDataProvider(Lanc_LogisticaPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_TB_LOGISTICADataProvider(this, TableName, DatabaseName, "PK_TB_LOGISTICA", "Lanc_Logistica_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public _BD_DADOS_TB_LOGISTICAItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_TB_LOGISTICAItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Lanc_Logistica_Grid1")
			{
				return new _BD_DADOS_TB_LOGISTICAItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Lanc_LogisticaPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			LOG_IDField = Convert.ToInt64(Item["LOG_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOG_IDField"))
			{
				AliasVariables["LOG_IDField"] = LOG_IDField;
			}
			else
			{
				AliasVariables.Add("LOG_IDField" ,LOG_IDField);
			}
			NUMERO_PEDIDOField = Convert.ToInt64(Item["NUMERO_PEDIDO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NUMERO_PEDIDOField"))
			{
				AliasVariables["NUMERO_PEDIDOField"] = NUMERO_PEDIDOField;
			}
			else
			{
				AliasVariables.Add("NUMERO_PEDIDOField" ,NUMERO_PEDIDOField);
			}
			TB_AVISOS_IDField = Convert.ToInt64(Item["TB_AVISOS_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("TB_AVISOS_IDField"))
			{
				AliasVariables["TB_AVISOS_IDField"] = TB_AVISOS_IDField;
			}
			else
			{
				AliasVariables.Add("TB_AVISOS_IDField" ,TB_AVISOS_IDField);
			}
			LOG_VENDEDORField = Convert.ToString(Item["LOG_VENDEDOR"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOG_VENDEDORField"))
			{
				AliasVariables["LOG_VENDEDORField"] = LOG_VENDEDORField;
			}
			else
			{
				AliasVariables.Add("LOG_VENDEDORField" ,LOG_VENDEDORField);
			}
			CLI_IDField = Convert.ToInt64(Item["CLI_ID"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("CLI_IDField"))
			{
				AliasVariables["CLI_IDField"] = CLI_IDField;
			}
			else
			{
				AliasVariables.Add("CLI_IDField" ,CLI_IDField);
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
			LOG_PROBLEMAField = Convert.ToString(Item["LOG_PROBLEMA"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOG_PROBLEMAField"))
			{
				AliasVariables["LOG_PROBLEMAField"] = LOG_PROBLEMAField;
			}
			else
			{
				AliasVariables.Add("LOG_PROBLEMAField" ,LOG_PROBLEMAField);
			}
			DATA_LANCAMENTOField = Convert.ToDateTime(Item["DATA_LANCAMENTO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DATA_LANCAMENTOField"))
			{
				AliasVariables["DATA_LANCAMENTOField"] = DATA_LANCAMENTOField;
			}
			else
			{
				AliasVariables.Add("DATA_LANCAMENTOField" ,DATA_LANCAMENTOField);
			}
			LOG_RETORNOField = Convert.ToString(Item["LOG_RETORNO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOG_RETORNOField"))
			{
				AliasVariables["LOG_RETORNOField"] = LOG_RETORNOField;
			}
			else
			{
				AliasVariables.Add("LOG_RETORNOField" ,LOG_RETORNOField);
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
			LOG_IMAGEMField = Convert.ToString(Item["LOG_IMAGEM"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOG_IMAGEMField"))
			{
				AliasVariables["LOG_IMAGEMField"] = LOG_IMAGEMField;
			}
			else
			{
				AliasVariables.Add("LOG_IMAGEMField" ,LOG_IMAGEMField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_LOGISTICA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "LOG_ID") });
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
	public class Lanc_Logistica_Grid2GridDataProvider : GeneralGridProvider
	{
		public DateTime DataOPEField;
		public long NOTAENTField;
		public DateTime PRE_CHEField;
		public long PROD_CODFASTRAXField;
		public string NOMELONGField;
		public long ID_compra_previsaoField;
		public long QTDEField;
		public string UsuarioField;
		public string NuevoField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private _BD_DADOS_VW_COMPRA_PREVISAODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as _BD_DADOS_VW_COMPRA_PREVISAODataProvider;
			}
		}

		public Lanc_LogisticaPageProvider ParentPageProvider;
		
		public override string TableName { get { return "VW_COMPRA_PREVISAO"; } }

		public override string DatabaseName { get { return "BD_DADOS"; } }

		public override string FormID { get { return "29844"; } }
		
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

		public Lanc_Logistica_Grid2GridDataProvider(Lanc_LogisticaPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new _BD_DADOS_VW_COMPRA_PREVISAODataProvider(this, TableName, DatabaseName, "PK_VW_COMPRA_PREVISAO", "Lanc_Logistica_Grid2");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public _BD_DADOS_VW_COMPRA_PREVISAOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as _BD_DADOS_VW_COMPRA_PREVISAOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Lanc_Logistica_Grid2")
			{
				return new _BD_DADOS_VW_COMPRA_PREVISAOItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Lanc_LogisticaPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			DataOPEField = Convert.ToDateTime(Item["DataOPE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DataOPEField"))
			{
				AliasVariables["DataOPEField"] = DataOPEField;
			}
			else
			{
				AliasVariables.Add("DataOPEField" ,DataOPEField);
			}
			NOTAENTField = Convert.ToInt64(Item["NOTAENT"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOTAENTField"))
			{
				AliasVariables["NOTAENTField"] = NOTAENTField;
			}
			else
			{
				AliasVariables.Add("NOTAENTField" ,NOTAENTField);
			}
			PRE_CHEField = Convert.ToDateTime(Item["PRE_CHE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PRE_CHEField"))
			{
				AliasVariables["PRE_CHEField"] = PRE_CHEField;
			}
			else
			{
				AliasVariables.Add("PRE_CHEField" ,PRE_CHEField);
			}
			PROD_CODFASTRAXField = Convert.ToInt64(Item["PROD_CODFASTRAX"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("PROD_CODFASTRAXField"))
			{
				AliasVariables["PROD_CODFASTRAXField"] = PROD_CODFASTRAXField;
			}
			else
			{
				AliasVariables.Add("PROD_CODFASTRAXField" ,PROD_CODFASTRAXField);
			}
			NOMELONGField = Convert.ToString(Item["NOMELONG"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NOMELONGField"))
			{
				AliasVariables["NOMELONGField"] = NOMELONGField;
			}
			else
			{
				AliasVariables.Add("NOMELONGField" ,NOMELONGField);
			}
			ID_compra_previsaoField = Convert.ToInt64(Item["ID_compra_previsao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ID_compra_previsaoField"))
			{
				AliasVariables["ID_compra_previsaoField"] = ID_compra_previsaoField;
			}
			else
			{
				AliasVariables.Add("ID_compra_previsaoField" ,ID_compra_previsaoField);
			}
			QTDEField = Convert.ToInt64(Item["QTDE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("QTDEField"))
			{
				AliasVariables["QTDEField"] = QTDEField;
			}
			else
			{
				AliasVariables.Add("QTDEField" ,QTDEField);
			}
			UsuarioField = Convert.ToString(Item["Usuario"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("UsuarioField"))
			{
				AliasVariables["UsuarioField"] = UsuarioField;
			}
			else
			{
				AliasVariables.Add("UsuarioField" ,UsuarioField);
			}
			NuevoField = Convert.ToString(Item["Nuevo"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("NuevoField"))
			{
				AliasVariables["NuevoField"] = NuevoField;
			}
			else
			{
				AliasVariables.Add("NuevoField" ,NuevoField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_VW_COMPRA_PREVISAO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "ID_compra_previsao") });
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
