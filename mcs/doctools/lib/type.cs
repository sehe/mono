// type.cs - Mono Documentation Lib
//
// Author: Adam Treat <manyoso@yahoo.com>
// (c) 2002 Adam Treat
// Licensed under the terms of the GNU GPL

using System;
using System.Collections;

namespace Mono.Util.MonoDoc.Lib {

	public class DocType : IComparable {

		string name, _namespace, fileroot, language, summary, remarks;
		bool isClass, isInterface, isEnum, isStructure, isDelegate, isNested = false;
		ArrayList enums, ctors, dtors, methods, properties, fields, events;

		public DocType ()
		{
			enums = new ArrayList ();
			ctors = new ArrayList ();
			dtors = new ArrayList ();
			methods = new ArrayList ();
			properties = new ArrayList ();
			fields = new ArrayList ();
			events = new ArrayList ();
		}

		public int CompareTo (Object value)
		{
			if (value == null)
				return 1;
			if (!(value is DocType))
				throw new ArgumentException ();
			if (this.Namespace != (value as DocType).Namespace)
				return String.Compare ((value as DocType).Namespace, this.Namespace);
			if (Score (this) > Score (value as DocType))
				return 1;
			else if (Score (this) < Score (value as DocType))
				return -1;
			else
				return String.Compare ((value as DocType).Name, this.Name);
		}

		private int Score (DocType type)
		{
			if (type.IsClass)
				return 5;
			else if (type.IsStructure)
				return 4;
			else if (type.IsInterface)
				return 3;
			else if (type.IsEnum)
				return 2;
			else if (type.IsDelegate)
				return 1;
			else
				return 0;
		}

		public void Sort ()
		{
			enums.Sort ();
			ctors.Sort ();
			dtors.Sort ();
			methods.Sort ();
			properties.Sort ();
			fields.Sort ();
			events.Sort ();
		}

		public void AddCtor (DocMember member)
		{
			ctors.Add (member);
		}

		public void AddDtor (DocMember member)
		{
			dtors.Add (member);
		}

		public void AddMethod (DocMember member)
		{
			methods.Add (member);
		}
		
		public void AddProperty (DocMember member)
		{
			properties.Add (member);
		}

		public void AddField (DocMember member)
		{
			fields.Add (member);
		}
		
		public void AddEvent (DocMember member)
		{
			events.Add (member);
		}

		public string Name
		{
			get {return name;}
			set {name = value;}
		}
		
		public string Namespace
		{
			get {return _namespace;}
			set {_namespace = value;}
		}

		public string FullName
		{
			get {return _namespace+"."+name;}
		}
		
		public string FileRoot
		{
			get {return fileroot;}
			set {fileroot = value;}
		}

		public string FilePath
		{
			get {return fileroot+"/"+language+"/"+_namespace+"/"+name+".xml";}
		}

		public string Language
		{
			get {return language;}
			set {language = value;}
		}
		
		public string Summary
		{
			get {return summary;}
			set {summary = value;}
		}

		public string Remarks
		{
			get {return remarks;}
			set {remarks = value;}
		}

		public bool IsInterface
		{
			get {return isInterface;}
			set {isInterface = value;}
		}

		public bool IsClass
		{
			get {return isClass;}
			set {isClass = value;}
		}

		public bool IsStructure
		{
			get {return isStructure;}
			set {isStructure = value;}
		}
		
		public bool IsEnum
		{
			get {return isEnum;}
			set {isEnum = value;}
		}

		public bool IsDelegate
		{
			get {return isDelegate;}
			set {isDelegate = value;}
		}
		
		public bool IsNested
		{
			get {return isNested;}
			set {isNested = value;}
		}

		public ArrayList Enums
		{
			get {return enums;}
		}

		public ArrayList Ctors
		{
			get {return ctors;}
		}

		public ArrayList Dtors
		{
			get {return dtors;}
		}
		
		public ArrayList Methods
		{
			get {return methods;}
		}
		
		public ArrayList Properties
		{
			get {return properties;}
		}
		
		public ArrayList Fields
		{
			get {return fields;}
		}
		
		public ArrayList Events
		{
			get {return events;}
		}
	}
}
