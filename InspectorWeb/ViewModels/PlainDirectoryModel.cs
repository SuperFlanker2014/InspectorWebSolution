using System;
using System.Collections.Generic;

namespace InspectorWeb.ViewModels
{
	public class PlainDirectoryModel
	{
		public PlainDirectoryModel()
		{
			Access = DirectoryAccessRights.None;
			HeaderButtons = new List<CustomControlButton>();
			ItemButtons = new List<CustomControlButton>();			
			Properties = new List<DirectoryProperty>();
			Directories = new List<DirectoryItem>();
			DirectoryDropdowns = new Dictionary<string, string>();			
		}

		public string DirectoryName { get; set; }
		public DirectoryAccessRights Access { get; set; }
		public List<CustomControlButton> HeaderButtons { get; set; }
		public List<CustomControlButton> ItemButtons { get; set; }		
		public List<DirectoryProperty> Properties { get; set; }
		public List<DirectoryItem> Directories { get; set; }

		public Dictionary<string, string> DirectoryDropdowns { get; set; }		
	}

	public struct DirectoryItem
	{
		public DirectoryItem(string name, string title)
		{
			Name = name;
			Title = title;
		}

		public string Name { get; set; }
		public string Title { get; set; }
	}

	public struct DirectoryProperty
	{
		public DirectoryProperty(string name, string title, string type)
		{
			Name = name;
			Title = title;
			Type = type;
		}

		public string Name { get; set; }
		public string Title { get; set; }
		public string Type { get; set; }
	}

	public struct CustomControlButton
	{
		public CustomControlButton(string link, string title, string classes)
		{
			Link = link;
			Title = title;
			Classes = classes;
		}

		public string Link { get; set; }
		public string Title { get; set; }
		public string Classes { get; set; }
	}

	public enum DirectoryAccessRights
	{
		None = 0,
		Edit = 1,
		Insert = 2,
		Delete = 4
	}
}