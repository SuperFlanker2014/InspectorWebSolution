Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=InspectorWebDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsDB -force
Scaffold-DbContext "Server=EIBRAGIMOV\SQLDEVELOPER2017;Database=InspectorWebDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsDB -force
Scaffold-DbContext "Server=localhost;Database=InspectorWebDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir ModelsDB -force

удалить пустой конструктор

var $result = jsGrid.fields.control.prototype.itemTemplate.apply(this, arguments);

var $customButton = $("<button>")
    .text(item.Name)
    .click(function (e) {
        alert(item.guid);
        e.stopPropagation();
    });

return $result.add($customButton);

dotnet publish -c Release -r win10-x64

dotnet ef dbcontext scaffold
Scaffolds a DbContext and entity types for a database.
Arguments:	
<CONNECTION> 	The connection string to the database.
<PROVIDER> 	The provider to use. (E.g. Microsoft.EntityFrameworkCore.SqlServer)
Options:		
-d 	--data-annotations 	Use attributes to configure the model (where possible). If omitted, only the fluent API is used.
-c 	--context <NAME> 	The name of the DbContext.
-f 	--force 	Overwrite existing files.
-o 	--output-dir <PATH> 	The directory to put files in. Paths are relative to the project directory.
	--schema <SCHEMA_NAME>... 	The schemas of tables to generate entity types for.
-t 	--table <TABLE_NAME>... 	The tables to generate entity types for.
	--use-database-names 	Use table and column names directly from the database.

jsGrid changes

validationErrors.push.apply(validationErrors,
    $.map(errors, function(message) {
        return { field: field.name, message: message };
    }));

editItem: function(item) {
var $row = this.rowByItem(item);
            
if($row.length) {
    this._editRow($row.first());
}