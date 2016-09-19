function ShowWindow(id, name, description) {
    document.getElementById("edit-window").style.display = "block";
    document.getElementById("ID-control").value = id;
    document.getElementById("Name-control").value = name;
    if (description != "") {
        document.getElementById("Description-control").value = description;
    }
}
function DismissWindow() {
    document.getElementById("edit-window").style.display = "none";
}
