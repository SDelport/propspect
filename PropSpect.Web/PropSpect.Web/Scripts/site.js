
//This is added back to fix selects
function select_refresh(objectName)
{
    $(objectName).removeClass('hide');
    $(objectName).material_select();
    $(objectName).addClass('hide');
}