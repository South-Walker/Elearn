﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elearn.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="bds240792229_db")]
	public partial class ElearnDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void Insertprocesses(processes instance);
    partial void Updateprocesses(processes instance);
    partial void Deleteprocesses(processes instance);
    partial void Insertparts(parts instance);
    partial void Updateparts(parts instance);
    partial void Deleteparts(parts instance);
    partial void Insertewords(ewords instance);
    partial void Updateewords(ewords instance);
    partial void Deleteewords(ewords instance);
    partial void Insertstudents(students instance);
    partial void Updatestudents(students instance);
    partial void Deletestudents(students instance);
    partial void Insertwechatids(wechatids instance);
    partial void Updatewechatids(wechatids instance);
    partial void Deletewechatids(wechatids instance);
    #endregion
		
		public ElearnDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["bds240792229_dbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ElearnDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ElearnDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ElearnDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ElearnDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<processes> processes
		{
			get
			{
				return this.GetTable<processes>();
			}
		}
		
		public System.Data.Linq.Table<parts> parts
		{
			get
			{
				return this.GetTable<parts>();
			}
		}
		
		public System.Data.Linq.Table<ewords> ewords
		{
			get
			{
				return this.GetTable<ewords>();
			}
		}
		
		public System.Data.Linq.Table<students> students
		{
			get
			{
				return this.GetTable<students>();
			}
		}
		
		public System.Data.Linq.Table<wechatids> wechatids
		{
			get
			{
				return this.GetTable<wechatids>();
			}
		}
		
		public System.Data.Linq.Table<wechat_process_view> wechat_process_view
		{
			get
			{
				return this.GetTable<wechat_process_view>();
			}
		}
		
		public System.Data.Linq.Table<wechat_student_view> wechat_student_view
		{
			get
			{
				return this.GetTable<wechat_student_view>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.processes")]
	public partial class processes : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private System.Nullable<int> _eword_id;
		
		private System.Nullable<int> _part_id;
		
		private EntityRef<parts> _parts;
		
		private EntityRef<ewords> _ewords;
		
		private EntityRef<students> _students;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Oneword_idChanging(System.Nullable<int> value);
    partial void Oneword_idChanged();
    partial void Onpart_idChanging(System.Nullable<int> value);
    partial void Onpart_idChanged();
    #endregion
		
		public processes()
		{
			this._parts = default(EntityRef<parts>);
			this._ewords = default(EntityRef<ewords>);
			this._students = default(EntityRef<students>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._students.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_eword_id", DbType="Int")]
		public System.Nullable<int> eword_id
		{
			get
			{
				return this._eword_id;
			}
			set
			{
				if ((this._eword_id != value))
				{
					if (this._ewords.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Oneword_idChanging(value);
					this.SendPropertyChanging();
					this._eword_id = value;
					this.SendPropertyChanged("eword_id");
					this.Oneword_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_part_id", DbType="Int")]
		public System.Nullable<int> part_id
		{
			get
			{
				return this._part_id;
			}
			set
			{
				if ((this._part_id != value))
				{
					if (this._parts.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onpart_idChanging(value);
					this.SendPropertyChanging();
					this._part_id = value;
					this.SendPropertyChanged("part_id");
					this.Onpart_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="parts_processes", Storage="_parts", ThisKey="part_id", OtherKey="part_id", IsForeignKey=true)]
		public parts parts
		{
			get
			{
				return this._parts.Entity;
			}
			set
			{
				parts previousValue = this._parts.Entity;
				if (((previousValue != value) 
							|| (this._parts.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._parts.Entity = null;
						previousValue.processes.Remove(this);
					}
					this._parts.Entity = value;
					if ((value != null))
					{
						value.processes.Add(this);
						this._part_id = value.part_id;
					}
					else
					{
						this._part_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("parts");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ewords_processes", Storage="_ewords", ThisKey="eword_id", OtherKey="eword_id", IsForeignKey=true)]
		public ewords ewords
		{
			get
			{
				return this._ewords.Entity;
			}
			set
			{
				ewords previousValue = this._ewords.Entity;
				if (((previousValue != value) 
							|| (this._ewords.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ewords.Entity = null;
						previousValue.processes.Remove(this);
					}
					this._ewords.Entity = value;
					if ((value != null))
					{
						value.processes.Add(this);
						this._eword_id = value.eword_id;
					}
					else
					{
						this._eword_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("ewords");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="students_processes", Storage="_students", ThisKey="user_id", OtherKey="user_id", IsForeignKey=true)]
		public students students
		{
			get
			{
				return this._students.Entity;
			}
			set
			{
				students previousValue = this._students.Entity;
				if (((previousValue != value) 
							|| (this._students.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._students.Entity = null;
						previousValue.processes = null;
					}
					this._students.Entity = value;
					if ((value != null))
					{
						value.processes = this;
						this._user_id = value.user_id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("students");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.parts")]
	public partial class parts : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _part_id;
		
		private string _bookname;
		
		private string _unitname;
		
		private string _partname;
		
		private EntitySet<processes> _processes;
		
		private EntitySet<ewords> _ewords;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onpart_idChanging(int value);
    partial void Onpart_idChanged();
    partial void OnbooknameChanging(string value);
    partial void OnbooknameChanged();
    partial void OnunitnameChanging(string value);
    partial void OnunitnameChanged();
    partial void OnpartnameChanging(string value);
    partial void OnpartnameChanged();
    #endregion
		
		public parts()
		{
			this._processes = new EntitySet<processes>(new Action<processes>(this.attach_processes), new Action<processes>(this.detach_processes));
			this._ewords = new EntitySet<ewords>(new Action<ewords>(this.attach_ewords), new Action<ewords>(this.detach_ewords));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_part_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int part_id
		{
			get
			{
				return this._part_id;
			}
			set
			{
				if ((this._part_id != value))
				{
					this.Onpart_idChanging(value);
					this.SendPropertyChanging();
					this._part_id = value;
					this.SendPropertyChanged("part_id");
					this.Onpart_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bookname", DbType="VarChar(20)")]
		public string bookname
		{
			get
			{
				return this._bookname;
			}
			set
			{
				if ((this._bookname != value))
				{
					this.OnbooknameChanging(value);
					this.SendPropertyChanging();
					this._bookname = value;
					this.SendPropertyChanged("bookname");
					this.OnbooknameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_unitname", DbType="VarChar(10)")]
		public string unitname
		{
			get
			{
				return this._unitname;
			}
			set
			{
				if ((this._unitname != value))
				{
					this.OnunitnameChanging(value);
					this.SendPropertyChanging();
					this._unitname = value;
					this.SendPropertyChanged("unitname");
					this.OnunitnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_partname", DbType="VarChar(10)")]
		public string partname
		{
			get
			{
				return this._partname;
			}
			set
			{
				if ((this._partname != value))
				{
					this.OnpartnameChanging(value);
					this.SendPropertyChanging();
					this._partname = value;
					this.SendPropertyChanged("partname");
					this.OnpartnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="parts_processes", Storage="_processes", ThisKey="part_id", OtherKey="part_id")]
		public EntitySet<processes> processes
		{
			get
			{
				return this._processes;
			}
			set
			{
				this._processes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="parts_ewords", Storage="_ewords", ThisKey="part_id", OtherKey="part_id")]
		public EntitySet<ewords> ewords
		{
			get
			{
				return this._ewords;
			}
			set
			{
				this._ewords.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_processes(processes entity)
		{
			this.SendPropertyChanging();
			entity.parts = this;
		}
		
		private void detach_processes(processes entity)
		{
			this.SendPropertyChanging();
			entity.parts = null;
		}
		
		private void attach_ewords(ewords entity)
		{
			this.SendPropertyChanging();
			entity.parts = this;
		}
		
		private void detach_ewords(ewords entity)
		{
			this.SendPropertyChanging();
			entity.parts = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.ewords")]
	public partial class ewords : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _eword_id;
		
		private string _eword;
		
		private string _chinese;
		
		private string _wordpart;
		
		private System.Nullable<int> _part_id;
		
		private EntitySet<processes> _processes;
		
		private EntityRef<parts> _parts;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oneword_idChanging(int value);
    partial void Oneword_idChanged();
    partial void OnewordChanging(string value);
    partial void OnewordChanged();
    partial void OnchineseChanging(string value);
    partial void OnchineseChanged();
    partial void OnwordpartChanging(string value);
    partial void OnwordpartChanged();
    partial void Onpart_idChanging(System.Nullable<int> value);
    partial void Onpart_idChanged();
    #endregion
		
		public ewords()
		{
			this._processes = new EntitySet<processes>(new Action<processes>(this.attach_processes), new Action<processes>(this.detach_processes));
			this._parts = default(EntityRef<parts>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_eword_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int eword_id
		{
			get
			{
				return this._eword_id;
			}
			set
			{
				if ((this._eword_id != value))
				{
					this.Oneword_idChanging(value);
					this.SendPropertyChanging();
					this._eword_id = value;
					this.SendPropertyChanged("eword_id");
					this.Oneword_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_eword", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string eword
		{
			get
			{
				return this._eword;
			}
			set
			{
				if ((this._eword != value))
				{
					this.OnewordChanging(value);
					this.SendPropertyChanging();
					this._eword = value;
					this.SendPropertyChanged("eword");
					this.OnewordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chinese", DbType="VarChar(40)")]
		public string chinese
		{
			get
			{
				return this._chinese;
			}
			set
			{
				if ((this._chinese != value))
				{
					this.OnchineseChanging(value);
					this.SendPropertyChanging();
					this._chinese = value;
					this.SendPropertyChanged("chinese");
					this.OnchineseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wordpart", DbType="VarChar(10)")]
		public string wordpart
		{
			get
			{
				return this._wordpart;
			}
			set
			{
				if ((this._wordpart != value))
				{
					this.OnwordpartChanging(value);
					this.SendPropertyChanging();
					this._wordpart = value;
					this.SendPropertyChanged("wordpart");
					this.OnwordpartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_part_id", DbType="Int")]
		public System.Nullable<int> part_id
		{
			get
			{
				return this._part_id;
			}
			set
			{
				if ((this._part_id != value))
				{
					if (this._parts.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onpart_idChanging(value);
					this.SendPropertyChanging();
					this._part_id = value;
					this.SendPropertyChanged("part_id");
					this.Onpart_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ewords_processes", Storage="_processes", ThisKey="eword_id", OtherKey="eword_id")]
		public EntitySet<processes> processes
		{
			get
			{
				return this._processes;
			}
			set
			{
				this._processes.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="parts_ewords", Storage="_parts", ThisKey="part_id", OtherKey="part_id", IsForeignKey=true)]
		public parts parts
		{
			get
			{
				return this._parts.Entity;
			}
			set
			{
				parts previousValue = this._parts.Entity;
				if (((previousValue != value) 
							|| (this._parts.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._parts.Entity = null;
						previousValue.ewords.Remove(this);
					}
					this._parts.Entity = value;
					if ((value != null))
					{
						value.ewords.Add(this);
						this._part_id = value.part_id;
					}
					else
					{
						this._part_id = default(Nullable<int>);
					}
					this.SendPropertyChanged("parts");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_processes(processes entity)
		{
			this.SendPropertyChanging();
			entity.ewords = this;
		}
		
		private void detach_processes(processes entity)
		{
			this.SendPropertyChanging();
			entity.ewords = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.students")]
	public partial class students : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _studentnum;
		
		private string _jwcpassword;
		
		private EntityRef<processes> _processes;
		
		private EntityRef<wechatids> _wechatids;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void OnstudentnumChanging(string value);
    partial void OnstudentnumChanged();
    partial void OnjwcpasswordChanging(string value);
    partial void OnjwcpasswordChanged();
    #endregion
		
		public students()
		{
			this._processes = default(EntityRef<processes>);
			this._wechatids = default(EntityRef<wechatids>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					if (this._wechatids.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentnum", DbType="VarChar(10)")]
		public string studentnum
		{
			get
			{
				return this._studentnum;
			}
			set
			{
				if ((this._studentnum != value))
				{
					this.OnstudentnumChanging(value);
					this.SendPropertyChanging();
					this._studentnum = value;
					this.SendPropertyChanged("studentnum");
					this.OnstudentnumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_jwcpassword", DbType="VarChar(11)")]
		public string jwcpassword
		{
			get
			{
				return this._jwcpassword;
			}
			set
			{
				if ((this._jwcpassword != value))
				{
					this.OnjwcpasswordChanging(value);
					this.SendPropertyChanging();
					this._jwcpassword = value;
					this.SendPropertyChanged("jwcpassword");
					this.OnjwcpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="students_processes", Storage="_processes", ThisKey="user_id", OtherKey="user_id", IsUnique=true, IsForeignKey=false)]
		public processes processes
		{
			get
			{
				return this._processes.Entity;
			}
			set
			{
				processes previousValue = this._processes.Entity;
				if (((previousValue != value) 
							|| (this._processes.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._processes.Entity = null;
						previousValue.students = null;
					}
					this._processes.Entity = value;
					if ((value != null))
					{
						value.students = this;
					}
					this.SendPropertyChanged("processes");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="wechatids_students", Storage="_wechatids", ThisKey="user_id", OtherKey="user_id", IsForeignKey=true)]
		public wechatids wechatids
		{
			get
			{
				return this._wechatids.Entity;
			}
			set
			{
				wechatids previousValue = this._wechatids.Entity;
				if (((previousValue != value) 
							|| (this._wechatids.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._wechatids.Entity = null;
						previousValue.students = null;
					}
					this._wechatids.Entity = value;
					if ((value != null))
					{
						value.students = this;
						this._user_id = value.user_id;
					}
					else
					{
						this._user_id = default(int);
					}
					this.SendPropertyChanged("wechatids");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.wechatids")]
	public partial class wechatids : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _user_id;
		
		private string _wechat_id;
		
		private System.Nullable<System.DateTime> _followdate;
		
		private EntityRef<students> _students;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Onwechat_idChanging(string value);
    partial void Onwechat_idChanged();
    partial void OnfollowdateChanging(System.Nullable<System.DateTime> value);
    partial void OnfollowdateChanged();
    #endregion
		
		public wechatids()
		{
			this._students = default(EntityRef<students>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wechat_id", DbType="VarChar(40)")]
		public string wechat_id
		{
			get
			{
				return this._wechat_id;
			}
			set
			{
				if ((this._wechat_id != value))
				{
					this.Onwechat_idChanging(value);
					this.SendPropertyChanging();
					this._wechat_id = value;
					this.SendPropertyChanged("wechat_id");
					this.Onwechat_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_followdate", DbType="DateTime")]
		public System.Nullable<System.DateTime> followdate
		{
			get
			{
				return this._followdate;
			}
			set
			{
				if ((this._followdate != value))
				{
					this.OnfollowdateChanging(value);
					this.SendPropertyChanging();
					this._followdate = value;
					this.SendPropertyChanged("followdate");
					this.OnfollowdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="wechatids_students", Storage="_students", ThisKey="user_id", OtherKey="user_id", IsUnique=true, IsForeignKey=false)]
		public students students
		{
			get
			{
				return this._students.Entity;
			}
			set
			{
				students previousValue = this._students.Entity;
				if (((previousValue != value) 
							|| (this._students.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._students.Entity = null;
						previousValue.wechatids = null;
					}
					this._students.Entity = value;
					if ((value != null))
					{
						value.wechatids = this;
					}
					this.SendPropertyChanged("students");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.wechat_process_view")]
	public partial class wechat_process_view
	{
		
		private string _wechat_id;
		
		private System.Nullable<int> _eword_id;
		
		private System.Nullable<int> _part_id;
		
		public wechat_process_view()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wechat_id", DbType="VarChar(40)")]
		public string wechat_id
		{
			get
			{
				return this._wechat_id;
			}
			set
			{
				if ((this._wechat_id != value))
				{
					this._wechat_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_eword_id", DbType="Int")]
		public System.Nullable<int> eword_id
		{
			get
			{
				return this._eword_id;
			}
			set
			{
				if ((this._eword_id != value))
				{
					this._eword_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_part_id", DbType="Int")]
		public System.Nullable<int> part_id
		{
			get
			{
				return this._part_id;
			}
			set
			{
				if ((this._part_id != value))
				{
					this._part_id = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="elearndb.wechat_student_view")]
	public partial class wechat_student_view
	{
		
		private string _wechat_id;
		
		private string _studentnum;
		
		private string _jwcpassword;
		
		public wechat_student_view()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_wechat_id", DbType="VarChar(40)")]
		public string wechat_id
		{
			get
			{
				return this._wechat_id;
			}
			set
			{
				if ((this._wechat_id != value))
				{
					this._wechat_id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_studentnum", DbType="VarChar(10)")]
		public string studentnum
		{
			get
			{
				return this._studentnum;
			}
			set
			{
				if ((this._studentnum != value))
				{
					this._studentnum = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_jwcpassword", DbType="VarChar(11)")]
		public string jwcpassword
		{
			get
			{
				return this._jwcpassword;
			}
			set
			{
				if ((this._jwcpassword != value))
				{
					this._jwcpassword = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
