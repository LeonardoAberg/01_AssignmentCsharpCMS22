// Program-delen där vi kör menyn och får tillgång till vår menuhelper. Instansierar menyn och kör den.
using _01_AssignmentCsharpCMS22.Services;

var menuHelper = new MenuHelper();
do
{
    menuHelper.GetMenu();
} while (true);