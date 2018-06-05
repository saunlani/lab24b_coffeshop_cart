function validate_delete() {
    var r = confirm("Are you sure that you'd like to delete this item?");
    if (r == true) {
        return true;
    }
    else {
        return false;
    }
}

function validate_create() {

    //validates name
    var a = document.getElementById("iname").value;
    if (a == "") {
        alert("Name cannot be empty")
        return false;
    }

    //validates description
    var b = document.getElementById("idescrip").value;
    if (b == "") {
        alert("Description cannot be empty")
        return false;
    }

    //validates quantity
    var c = document.getElementById("iquantity").value;
    if (b == "") {
        alert("Quantity cannot be empty")
        return false;
    }

    //validates price
    var d = document.getElementById("iprice").value;
    if (b == "") {
        alert("Price cannot be empty")
        return false;
    }

    //final validation for creating item
    var r = confirm("Are you sure that you'd like to create this item?");
    if (r == true) {
        return true;
    }
    else {
        return false;
    }

}




//    var Name = $("#Name").val();
//    if (Name == "") {
//        alert("Please enter a name!")
//        return false;
//    }
//    //var Name = document.getElementById("Name").value;
//    //if (Name == "") { }
//    //else { alert("Don't leave blank!"); return false; }
//    //if (isNaN(Tel)) { alert("invalid"); return false; }
//    else { }
//    return true;
//}


//document.getElementById("Edit").onclick = function () {
//    confirm("Press a button!");
//}
