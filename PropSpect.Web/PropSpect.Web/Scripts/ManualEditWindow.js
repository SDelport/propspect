function ShowWindow(id, name, description,isAreaID) {
    document.getElementById("edit-window").style.display = "block";
    document.getElementById("ID-control").value = id;
    document.getElementById("Name-control").value = name;
    if (description != "") {
        document.getElementById("Description-control").value = description;
    }
    if (isAreaID!="false") {
        document.getElementById("isAreaID-control").value = isAreaID;
    }
}
function DismissWindow() {
    document.getElementById("edit-window").style.display = "none";
}
