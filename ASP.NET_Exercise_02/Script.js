function ConfirmDelete() {
    var confirm_delete = document.createElement("INPUT");
    confirm_delete.type = "hidden";
    confirm_delete.name = "confirm_delete";
    if (confirm("Are You Sure... You Want To Delete This Entry?")) {
        confirm_delete.value = "Yes";
    } else {
        confirm_delete.value = "No";
    }
    document.forms[0].appendChild(confirm_delete);
}

function ConfirmExit() {
    var confirm_exit = document.createElement("INPUT");
    confirm_exit.type = "hidden";
    confirm_exit.name = "confirm_exit";
    if (confirm("Are You Sure... You Want To Exit?")) {
        confirm_exit.value = "Yes";
    } else {
        confirm_exit.value = "No";
    }
    document.forms[0].appendChild(confirm_exit);
}