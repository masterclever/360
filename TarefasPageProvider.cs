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
	public class TarefasPageProvider : GeneralProvider
	{
		public _25246FASTRAX_TB_CLIENTEDataProvider AUX_Tarefas_TB_CLIENTEProvider;
		public List<RadComboBoxDataItem> ComboBox1Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "Visita"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "Reunion"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem3").ToString(), "Propuesta"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem4").ToString(), "Llamada"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem5").ToString(), "Email"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem6").ToString(), "Whatsapp"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem7").ToString(), "Video Conferencia"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem8").ToString(), "Minuta"),
				};
			}
		}

		public TarefasPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new _25246FASTRAX_TB_TAREFADataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_TAREFA", "Tarefas");
			MainProvider.DataProvider.PageProvider = this;
			AUX_Tarefas_TB_CLIENTEProvider = new _25246FASTRAX_TB_CLIENTEDataProvider(MainProvider, "TB_CLIENTE", "25246FASTRAX", "PK_TB_CLIENTE", "AUX_Tarefas_TB_CLIENTE");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new _25246FASTRAX_TB_TAREFAItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "AUX_Tarefas_TB_CLIENTE")
			{
				return new _25246FASTRAX_TB_CLIENTEItem("25246FASTRAX");
			}
			return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_Tarefas_TB_CLIENTEProvider);
			AUX_Tarefas_TB_CLIENTEProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_Tarefas_TB_CLIENTEProvider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_TAREFA", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "TAR_ID") });
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
			if (MainProvider.DataProvider.PageNumber > 0 && (ProcessName == "CRIADOR" || ((AllProcess && Pos == 0) && (((GeneralDataPage)MainProvider)).PageState == FormStateEnum.Insert)))
			{
				RawValue = EnvironmentVariable.LoggedLoginUser;
				MainProvider.DataProvider.Item["TAR_CRIADOR"].SetValue(RawValue);
				ValueField = MainProvider.DataProvider.Dao.ToSql(MainProvider.DataProvider.Item["TAR_CRIADOR"].GetFormattedValue() ,FieldType.Text);
				RelationField = MainProvider.DataProvider.ProviderFilterExpression();
				Process CRIADOR= new Process(MainProvider.DataProvider.Dao.PoeColAspas("TB_TAREFA"),MainProvider.DataProvider.Dao.PoeColAspas("TAR_CRIADOR"), ValueField, RelationField,0,false);
				Process.Add("CRIADOR410842", CRIADOR);
			}
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
				return ComboBox1Items.Find(i => i.Value == Value).ToDataRow();
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox1(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, ComboBox1Items.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, ComboBox1Items);
		}
		
		public DataRow ComboBox2_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "NEG_RESPONSAVEL = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("CLI_NOME") + " + '-' + " + Dao.PoeColAspas("NEG_TITULO") + " + '-' + " + Dao.PoeColAspas("NEG_STATUS") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("NEG_ID") + " FROM  " + Dao.PoeColAspas("VIEW_LISTANEGOCIO") + " WHERE " + Dao.PoeColAspas("NEG_ID") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox2(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string CboFilter = "";
			try
			{
				CboFilter = CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "NEG_RESPONSAVEL = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("CLI_NOME") + " + '-' + " + Dao.PoeColAspas("NEG_TITULO") + " + '-' + " + Dao.PoeColAspas("NEG_STATUS");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "VIEW_LISTANEGOCIO", DisplayFields, "NEG_ID", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("NEG_ID") + " Desc", false, "");
		}
		
		public DataRow ComboBox5_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " + "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("CLI_ID") + " FROM  " + Dao.PoeColAspas("TB_CLIENTE") + " WHERE " + Dao.PoeColAspas("CLI_ID") + " = '{0}'", Value)).Tables[0].Rows[0];
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
			string DisplayFields = "cast(" + Dao.PoeColAspas("CLI_CODFASTRAX") + " as varchar) " + " + '-' + " + Dao.PoeColAspas("CLI_NOME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_CLIENTE", DisplayFields, "CLI_ID", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
		}
		
		public DataRow ComboBox3_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				string CboFilter = "";
				try
				{
					CboFilter = " AND " + CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
				}
				catch { }
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_LOGIN") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_LOGIN") + " = '{0}'", Value) + CboFilter).Tables[0].Rows[0];
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
			string CboFilter = "";
			try
			{
				CboFilter = CRMSSI.IIf(EnvironmentVariable.LoggedNameGroup == "VENDEDOR", "LOGIN_USER_LOGIN = '" + EnvironmentVariable.LoggedLoginUser + "'", "1 = 1");
			}
			catch { }
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_LOGIN");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_LOGIN", Dao, false, CboFilter, GComboBoxOnDemandStyle.Contains, Dao.PoeColAspas("LOGIN_USER_LOGIN") + " Asc", false, "");
		}
		
		public DataRow ComboBox6_GetComboItem(string Value)
		{
			try
			{
				DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
				DataRow dr = Dao.RunSql(String.Format("SELECT TOP 1 " +  Dao.PoeColAspas("LOGIN_USER_NAME") +  " as DISPLAY_FIELD, " + Dao.PoeColAspas("LOGIN_USER_NAME") + " FROM  " + Dao.PoeColAspas("TB_LOGIN_USER") + " WHERE " + Dao.PoeColAspas("LOGIN_USER_NAME") + " = '{0}'", Value)).Tables[0].Rows[0];
				Dao.CloseConnection();
				Dao.Dispose();
				return dr;
			}
			catch
			{
				return null;
			}
		}
		
		public bool FillComboBox6(RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			DataAccessObject Dao = Utility.GetDAO("25246FASTRAX");
			string DisplayFields =  Dao.PoeColAspas("LOGIN_USER_NAME");
			return Utility.FillComboBox(ComboBox, NumberOfItems, TextFilter, AllowFilter, 15, "TB_LOGIN_USER", DisplayFields, "LOGIN_USER_NAME", Dao, false, "", GComboBoxOnDemandStyle.Contains, "", false, "");
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["TAR_TIPOField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Informe la Atención!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["TAR_DATAHORAField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker1", "La fecha no pueda estar vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["TAR_RESPONSAVELField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox3", "TAR_RESPONSAVEL não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}
