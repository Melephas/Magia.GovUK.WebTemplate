






function ShowFromDropDown(dropdownid, divid, showval, partial) {
    if ($("#" + dropdownid).val() == showval) {
        GetOccPartial(partial, divid);
    }
    else {
        HideSection(divid);
    }
}


function GetOccPartial(partial, section) {


    //$.ajax({
    //    type: 'GET',
    //    url: @Url.Action("LoadPartial", "Occupancy"),success: function (result) {
    //    alert("yes");
    //}

    var url = $(this).data('request-url');


    //$.ajax({
    //    type: "GET",
    //    url: "~/Occupancy/LoadPartial",
    //    datatype: "html",

    //    success: function (result) {
    //        alert("yes");

    //        //$("#" + se).html(result);
    //    },
    //    error: function () {
    //        alert("fail");
    //    }



    //});
}

   






function ShowSection(partial, section) {
   
    var link = '@Html.Raw(@Url.Action("LoadPartial", "Home", new { part = "partial" }))';

    link = link.replace('partial', partial);

    $.get(link, function (response) { $("#" + section).html(response); });
}

function HideSection(section) {
    $("#" + section).html("");
}

function Inspect(value, acton, partial, section) {
    if (value == acton) {
        ShowSection(partial, section);
    }
}

function HandleError(state, section) {
    var err = document.getElementById(section);

    if (state == "Invalid") {
        $("#" + section).addClass("govuk-form-group--error");
    }
}

function DeleteContact(id, show) {
    $("[id^=deleteContact_]").hide();

    if (show) {
        $("#deleteContact_" + id).show();
    }
    else {
        $("#deleteContact_" + id).hide();
    }
}





