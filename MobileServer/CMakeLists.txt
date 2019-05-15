cmake_minimum_required(VERSION 3.14)
project(MobileServer VERSION 1.0 LANGUAGES CSharp)

add_executable(MobileServer
	Program.cs
	Server.cs
	Properties/AssemblyInfo.cs
)
	
set_property(TARGET MobileServer PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
    "System.Core"
    "System.Data"
    "System.Data.DataSetExtensions"
    "System.Net.Http"
    "System.Xml"
    "System.Xml.Linq"
    "WindowsBase"
)
	